Imports MySql.Data.MySqlClient
Imports WSAFIPFE.Factura

Public Class GestorPublicidad


    Public Class OrdenPublicidad
        Public Property Id As Integer
        Public Property CodigoPrestamo As String
        Public Property Fecha As Date
        Public Property IdCliente As Integer
        Public Property PlazoMeses As Integer
        Public Property CuotaMensual As Decimal
        Public Property MontoTotal As Decimal
        Public Property Descripcion As String
        Public Property Concepto As String
        Public Property Observaciones As String
        Public Property Estado As Integer
        Public Property Cobrador As Integer
    End Class

    Public Class DetalleCuota
        Public Property Id As Integer
        Public Property CodigoPrestamo As String
        Public Property Periodo As Integer
        Public Property FechaVencimiento As Date
        Public Property MontoCuota As Decimal
    End Class

    Public Class PagoPublicidad
        Public Property Id As Integer
        Public Property FechaPago As Date
        Public Property CodigoPrestamo As String
        Public Property Periodo As Integer
        Public Property MontoPagado As Decimal
    End Class

    ' ==========================================
    ' 2. CLASE GESTORA (Lógica de BD y Negocio)
    ' ==========================================


    ' Propiedad privada para obtener la cadena de conexión de forma segura
    Private Shared ReadOnly Property CadenaConexion As String
        Get
            Return "Server=" & DatosAcceso.CLOUDserv & ";" &
                    "Port=" & DatosAcceso.puerto & ";" &
                    "Database=" & DatosAcceso.bd & ";" &
                    "Uid=" & DatosAcceso.usuario & ";" &
                    "Pwd=" & DatosAcceso.pass & ";" &
                    "Default Command Timeout=300;" ' <-- Se aplica a todos los comandos
        End Get
    End Property


    ' =========================================================================
    ' VINCULACIÓN DE COMPROBANTES CON CUOTAS DE PUBLICIDAD
    ' =========================================================================
    Public Shared Sub VincularComprobanteAutomatico(idCuota As Integer, idComprobante As Integer, esRecibo As Boolean)
        ' Verificamos si el código corresponde al formato de publicidad: #idPrestamo-idCuota
        Try
            ' 1. Determinamos columnas y estados según el tipo de comprobante
            Dim columna As String = If(esRecibo, "id_recibo", "id_factura")
            Dim estado As String = If(esRecibo, "PAGADA", "FACTURADA")

            ' 2. Armamos la consulta de actualización directa
            Dim query As String = "UPDATE rym_detalle_prestamo SET " & columna & " = @idComp, estado = @estado WHERE ID = @idCuota"

            Using conn As New MySqlConnection(CadenaConexion)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    ' Asignamos los parámetros de forma segura
                    cmd.Parameters.AddWithValue("@idComp", idComprobante)
                    cmd.Parameters.AddWithValue("@estado", estado)
                    cmd.Parameters.AddWithValue("@idCuota", idCuota)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            ' Si ocurre un error, no frena la facturación, pero queda registrado
            Console.WriteLine("Error al vincular comprobante en publicidad: " & ex.Message)
        End Try
    End Sub
    ' --- AQUI EMPEZAMOS A MUDAR LA LOGICA DEL FORMULARIO ---

    ''' <summary>
    ''' Obtiene los períodos (meses) que un cliente aún no pagó de una orden específica.
    ''' </summary>
    Public Shared Function ObtenerCuotasPendientes(codigoPrestamo As String) As List(Of DetalleCuota)
        Dim listaPendientes As New List(Of DetalleCuota)

        Dim query As String = "SELECT ID, ID_PRESTAMO, PERIODO, FECHA, CUOTA " &
                                "FROM rym_detalle_prestamo AS pr " &
                                "WHERE pr.PERIODO NOT IN (SELECT PERIODO FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO) " &
                                "AND pr.ID_PRESTAMO = ?idPrestamo " &
                                "ORDER BY pr.PERIODO ASC"

        Try
            ' Usamos Using para la conexión, el comando y el lector. Se cierran solos al terminar.
            Using conn As New MySqlConnection(CadenaConexion)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("?idPrestamo", codigoPrestamo)
                    conn.Open()

                    Using lector As MySqlDataReader = cmd.ExecuteReader()
                        While lector.Read()
                            Dim cuota As New DetalleCuota()
                            cuota.Id = Convert.ToInt32(lector("ID"))
                            cuota.CodigoPrestamo = lector("ID_PRESTAMO").ToString()
                            cuota.Periodo = Convert.ToInt32(lector("PERIODO"))
                            cuota.FechaVencimiento = Convert.ToDateTime(lector("FECHA"))

                            ' Limpiamos posibles puntos/comas del varchar antes de convertir a Decimal
                            Dim montoString As String = lector("CUOTA").ToString().Replace(".", "").Replace(",", ".")
                            cuota.MontoCuota = Val(montoString)

                            listaPendientes.Add(cuota)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error al leer cuotas pendientes: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        Return listaPendientes
    End Function

    ''' <summary>
    ''' Registra un pago. Si el monto alcanza para varios meses, los cancela en orden.
    ''' </summary>
    Public Shared Sub RegistrarPagoMasivo(codigoPrestamo As String, montoAbonado As Decimal)
        ' Agregamos el tipado estricto acá (As List(Of DetalleCuota))
        Dim cuotasAdeudadas As List(Of DetalleCuota) = ObtenerCuotasPendientes(codigoPrestamo)
        Dim saldoRestanteDelPago As Decimal = montoAbonado

        If cuotasAdeudadas.Count = 0 OrElse saldoRestanteDelPago <= 0 Then Exit Sub

        Dim queryPago As String = "INSERT INTO rym_pagos (FECHA, ID_PRESTAMO, PERIODO, MONTO_PAGADO) " &
                                    "VALUES (?fecha, ?idprestamo, ?periodo, ?monto)"

        Try
            ' Abrimos la conexión una sola vez para guardar todos los pagos de este recibo
            Using conn As New MySqlConnection(CadenaConexion)
                conn.Open()

                ' Iteramos sobre la deuda más vieja primero
                For Each cuota As DetalleCuota In cuotasAdeudadas
                    If saldoRestanteDelPago <= 0 Then Exit For ' Si ya se gastó la plata, cortamos

                    Dim montoAAplicar As Decimal = 0

                    If saldoRestanteDelPago >= cuota.MontoCuota Then
                        montoAAplicar = cuota.MontoCuota
                        saldoRestanteDelPago -= cuota.MontoCuota
                    Else
                        montoAAplicar = saldoRestanteDelPago
                        saldoRestanteDelPago = 0
                    End If

                    ' Guardamos el pago usando un comando aislado
                    Using cmd As New MySqlCommand(queryPago, conn)
                        cmd.Parameters.AddWithValue("?fecha", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        cmd.Parameters.AddWithValue("?idprestamo", codigoPrestamo)
                        cmd.Parameters.AddWithValue("?periodo", cuota.Periodo)
                        cmd.Parameters.AddWithValue("?monto", montoAAplicar.ToString().Replace(",", "."))

                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Catch ex As Exception
            MsgBox("Error al registrar el pago: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Public Shared Function ObtenerListado(vista As TipoVistaPublicidad, filtros As FiltrosPublicidad) As DataTable
        Dim dtResultados As New DataTable()
        Dim filtrosSql As String = ""
        Dim queryBase As String = ""
        Dim havingSql As String = ""



        ' 1. DEFINICIÓN DE QUERIES SEGÚN LA VISTA
        Select Case vista
       ' ===========================================================================
       ' VISTA OPERADOR: Solo información de ejecución, nada de montos ni facturas
       ' ===========================================================================
            Case TipoVistaPublicidad.Operador
                ' Se agrega "0 AS ID_CUOTA" para mantener la consistencia de columnas en la grilla
                queryBase = "SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, 0 AS ID_CUOTA, pr.FECHA as INICIO, " &
                       "(SELECT MAX(fecha) FROM rym_detalle_prestamo WHERE ID_PRESTAMO = pr.ID_PRESTAMO) as FIN, " &
                       "cl.nomapell_razon as CLIENTE, pr.DESCRIPCION, pr.CONCEPTO, pr.OBSERVACIONES, " &
                       "cl.vendedor, pr.COBRADOR " &
                       "FROM rym_prestamo as pr " &
                       "INNER JOIN fact_clientes as cl ON pr.ID_CLIENTE = cl.idclientes " &
                       "WHERE pr.ESTADO = 1 "

                ' Filtro de vigencia para el operador
                havingSql = " HAVING FIN >= DATE_FORMAT(?fechaDesde, '%Y-%m-01') "

                ' ===========================================================================
                ' VISTAS CONTABLES: Vigentes, A Facturar, A Vencer (Con montos y estados)
                ' ===========================================================================
            Case Else
                ' ACÁ AGREGAMOS "dt.ID AS ID_CUOTA"
                queryBase = "SELECT
                      pr.ID_PRESTAMO AS ID_PUBLICIDAD,
                      dt.ID AS ID_CUOTA,
                      pr.FECHA AS INICIO,
                      dt.FECHA AS VencActual,
                      (SELECT DATE_SUB(MAX(fecha), INTERVAL 1 DAY)
                         FROM rym_detalle_prestamo
                        WHERE ID_PRESTAMO = pr.ID_PRESTAMO) AS FIN,
                      cl.idclientes,
                      cl.nomapell_razon AS CLIENTE,
                      pr.DESCRIPCION,
                      ROUND(pr.MONTO_PRESTAMO, 2) AS MONTO_TOTAL,
                      ROUND(pr.CUOTA, 2) AS MONTO_MENSUAL,
                      ROUND(pr.MONTO_PRESTAMO - (SELECT IFNULL(SUM(MONTO_PAGADO), 0)
                                                  FROM rym_pagos
                                                 WHERE ID_PRESTAMO = pr.ID_PRESTAMO), 2) AS SALDO,
                      pr.CONCEPTO,
                      pr.OBSERVACIONES,
                      cl.vendedor,
                      pr.COBRADOR,
                      CASE
                        WHEN dt.id_recibo > 0 THEN 'PAGADA'
                        WHEN dt.id_factura > 0 THEN 'FACTURADA'
                        WHEN dt.ID IS NOT NULL THEN 'PENDIENTE'
                        ELSE 'SIN CUOTA'
                      END AS ESTADO_MES_CURSO,
                      -- Número de factura: ptovta (4) + num_fact (8) con ceros a la izquierda; vacío si no existe factura
                      COALESCE(CONCAT(LPAD(f.ptovta, 4, '0'), '-', LPAD(f.num_fact, 8, '0')), '') AS NUMERO_FACTURA,
                      -- Monto de la factura (total) convertido a decimal y redondeado; NULL si no existe factura o total vacío
                      CASE
                        WHEN f.total IS NULL OR TRIM(f.total) = '' THEN NULL
                        ELSE ROUND(CAST(REPLACE(f.total, ',', '.') AS DECIMAL(15,2)), 2)
                      END AS MONTO_FACTURA
                    FROM rym_prestamo AS pr
                    INNER JOIN fact_clientes AS cl ON pr.ID_CLIENTE = cl.idclientes
                    LEFT JOIN rym_detalle_prestamo AS dt
                      ON dt.ID_PRESTAMO = pr.ID_PRESTAMO
                      AND MONTH(dt.FECHA) = MONTH(?fechaDesde)
                      AND YEAR(dt.FECHA) = YEAR(?fechaDesde)
                    LEFT JOIN fact_facturas AS f ON f.id = NULLIF(dt.id_factura, 0)
                    WHERE pr.ESTADO = 1  "

                ' Lógica de filtrado por tipo de vista contable
                Select Case vista
                    Case TipoVistaPublicidad.AFacturar
                        ' CORRECCIÓN AQUÍ: Se cambió dt.ID_DETALLE por dt.ID (que es la clave primaria real de la tabla)
                        filtrosSql &= " AND dt.ID IS NOT NULL AND dt.id_factura = 0 "

                    Case TipoVistaPublicidad.AVencer
                        ' Solo las que la última cuota (FIN) es en este mes
                        havingSql = " HAVING MONTH(FIN) = MONTH(?fechaDesde) AND YEAR(FIN) = YEAR(?fechaDesde) "

                    Case TipoVistaPublicidad.Vigentes
                        ' Todo lo que termina de hoy en adelante
                        havingSql = " HAVING FIN >= DATE_FORMAT(?fechaDesde, '%Y-%m-01') "
                End Select
        End Select

        ' 2. FILTROS DINÁMICOS (Buscador, Cobrador, etc.)
        If Not String.IsNullOrWhiteSpace(filtros.TextoBusqueda) Then
            filtrosSql &= " AND (cl.nomapell_razon LIKE ?textoBusqueda OR pr.ID_PRESTAMO = ?codigoPrestamo) "
        End If

        ' Cambio de  idCobrador
        If filtros.IdCobrador > 0 Then
            filtrosSql &= " AND pr.COBRADOR = ?idCobrador "
        End If
        If filtros.IdVendedor > 0 Then
            filtrosSql &= " AND cl.vendedor = ?idVendedor "
        End If
        ' 3. ENSAMBLADO FINAL
        Dim queryFinal As String = queryBase & filtrosSql & havingSql & " ORDER BY " & filtros.OrdenarPor
        'sgBox(queryFinal)
        Try
            Using conn As New MySqlConnection(CadenaConexion)
                Using cmd As New MySqlCommand(queryFinal, conn)
                    cmd.Parameters.AddWithValue("?fechaDesde", filtros.FechaDesde)

                    If Not String.IsNullOrWhiteSpace(filtros.TextoBusqueda) Then
                        cmd.Parameters.AddWithValue("?textoBusqueda", "%" & filtros.TextoBusqueda & "%")
                        cmd.Parameters.AddWithValue("?codigoPrestamo", filtros.TextoBusqueda.Trim())
                    End If
                    If filtros.IdCobrador > 0 Then
                        cmd.Parameters.AddWithValue("?idCobrador", filtros.IdCobrador)
                    End If

                    If filtros.IdVendedor > 0 Then
                        cmd.Parameters.AddWithValue("?idVendedor", filtros.IdVendedor)
                    End If

                    conn.Open()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtResultados)
                    End Using
                End Using
            End Using

            ' 4. FILA DE TOTALES CON FORMATO
            If dtResultados.Rows.Count > 0 AndAlso vista <> TipoVistaPublicidad.Operador Then
                Dim sumaMensual As Decimal = 0
                For Each row As DataRow In dtResultados.Rows
                    If Not IsDBNull(row("MONTO_MENSUAL")) Then sumaMensual += Convert.ToDecimal(row("MONTO_MENSUAL"))
                Next

                Dim drTotal As DataRow = dtResultados.NewRow()
                drTotal("CLIENTE") = ">>> TOTALES <<<"
                drTotal("MONTO_MENSUAL") = sumaMensual
                dtResultados.Rows.Add(drTotal)
            End If

        Catch ex As Exception
            Throw New Exception("Error en Listado: " & ex.Message)
        End Try

        Return dtResultados
    End Function

    Public Shared Function ObtenerInformeAnualPivot(anio As Integer, porFechaInicio As Boolean) As DataTable
        Dim dtResultados As New DataTable()

        ' Si es por inicio, restamos 1 mes a la fecha del detalle para que la cuota de Febrero se vea en Enero.
        ' Si es por vencimiento, dejamos el desplazamiento mínimo de 1 día que ya tenías.
        Dim intervalo As String = If(porFechaInicio, " INTERVAL 1 MONTH ", "interval 1 day")

        ' Usamos la variable {intervalo} dentro de los DATE_SUB de la consulta
        Dim query As String = "SELECT 
                     MAX(publi.ID_PRESTAMO) AS IDPUBLICIDAD,
                     cli.idClientes, 
                     cli.nomapell_razon, 
                     publi.CONCEPTO, 
                     CAST(GROUP_CONCAT(DISTINCT publi.DESCRIPCION SEPARATOR ' | ') AS CHAR) AS DESCRIPCION,
    
                     -- ENERO 
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 1 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 1 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 1 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS enero,
    
                     -- FEBRERO
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 2 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 2 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 2 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS febrero,
    
                     -- MARZO
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 3 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 3 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 3 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS marzo,
    
                     -- ABRIL
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 4 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 4 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 4 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS abril,
    
                     -- MAYO
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 5 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 5 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 5 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS mayo,
    
                     -- JUNIO
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 6 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 6 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 6 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS junio,
    
                     -- JULIO
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 7 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 7 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 7 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS julio,
    
                     -- AGOSTO
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 8 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 8 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 8 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS agosto,
    
                     -- SEPTIEMBRE
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 9 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 9 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 9 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS septiembre,
    
                     -- OCTUBRE
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 10 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 10 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 10 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS octubre,
    
                     -- NOVIEMBRE
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 11 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 11 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 11 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS noviembre,
    
                     -- DICIEMBRE
                     CAST(CONCAT(
                         SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 12 
                             THEN REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.') ELSE 0 END),
                         CASE 
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 12 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN MONTH(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = 12 
                                            AND DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS diciembre,
    
                     -- TOTAL ANUAL
                     CAST(CONCAT(
                         -- el monto total anual incluye todas las cuotas (proyección incluida)
                         SUM(REPLACE(REPLACE(publiDet.CUOTA,'.',''),',','.')),
                         -- pero los asteriscos sólo si la fecha ajustada ya venció y está sin factura/recibo
                         CASE 
                             WHEN SUM(CASE WHEN DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_factura = 0 OR publiDet.id_factura IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (**)'
                             WHEN SUM(CASE WHEN DATE_SUB(publiDet.FECHA, " & intervalo & ") <= CURDATE()
                                            AND (publiDet.id_recibo = 0 OR publiDet.id_recibo IS NULL) THEN 1 ELSE 0 END) > 0 THEN ' (*)'
                             ELSE '' 
                         END
                     ) AS CHAR) AS total 

                 FROM fact_clientes AS cli
                 INNER JOIN rym_prestamo AS publi ON cli.idClientes = publi.ID_CLIENTE
                 INNER JOIN rym_detalle_prestamo AS publiDet ON publi.ID_PRESTAMO = publiDet.ID_PRESTAMO

                 WHERE publi.estado = 1 
                   AND YEAR(DATE_SUB(publiDet.FECHA, " & intervalo & ")) = @anio

                 GROUP BY 
                     cli.idClientes, 
                     cli.nomapell_razon, 
                     publi.CONCEPTO
    
                 ORDER BY 
                     cli.nomapell_razon ASC, 
                     publi.CONCEPTO ASC;
"

        'MsgBox(query)
        Try
            Using conn As New MySqlConnection(CadenaConexion)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@anio", anio)
                    conn.Open()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtResultados)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener informe anual pivot: " & ex.Message)
        End Try

        Return dtResultados

    End Function

    Public Shared Function ObtenerDetallePublicidad(idPrestamo As String, diasMora As Integer) As DataTable
        Dim dtResultados As New DataTable()

        ' Consulta optimizada: JOIN directo por IDs.
        ' Si DTP.id_factura es 0 o NULL, el JOIN devuelve NULL (celda vacía en grilla).
        Dim sql As String = "SELECT DTP.ID, " &
            "CASE " &
            "  WHEN DTP.id_recibo > 0 THEN 'PAGADA' " &
            "  WHEN DATEDIFF(NOW(), DTP.FECHA) > @DIASMORA THEN 'MOROSO' " &
            "  ELSE 'DEBE' " &
            "END AS ESTADO, " &
            "DTP.PERIODO, " &
            "DTP.FECHA AS VENCIMIENTO, " &
            "DTP.CUOTA AS MONTO, " &
            "CONCAT(compF.abrev, ' ', LPAD(fFact.ptovta, 4, '0'), '-', LPAD(fFact.num_fact, 8, '0')) AS FACTURA, " &
            "CONCAT(compR.abrev, ' ', LPAD(fRec.ptovta, 4, '0'), '-', LPAD(fRec.num_fact, 8, '0')) AS RECIBO " &
            "FROM rym_detalle_prestamo AS DTP " &
            "LEFT JOIN fact_facturas AS fFact ON DTP.id_factura = fFact.id " &
            "LEFT JOIN tipos_comprobantes AS compF ON fFact.tipofact = compF.donfdesc AND fFact.ptovta = compF.ptovta " &
            "LEFT JOIN fact_facturas AS fRec ON DTP.id_recibo = fRec.id " &
            "LEFT JOIN tipos_comprobantes AS compR ON fRec.tipofact = compR.donfdesc AND fRec.ptovta = compR.ptovta " &
            "WHERE DTP.ID_PRESTAMO = @idPrestamo AND DTP.PERIODO <> 0 " &
            "ORDER BY DTP.ID ASC"

        Try
            Using conn As New MySqlConnection(CadenaConexion)
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idPrestamo", idPrestamo)
                    cmd.Parameters.AddWithValue("@DIASMORA", diasMora)

                    conn.Open()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtResultados)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al cargar detalle (Optimizado): " & ex.Message)
        End Try

        Return dtResultados
    End Function

    ''' <summary>
    ''' Genera el informe detallado filtrado por estado (PAGADA, MOROSO, DEBE).
    ''' </summary>
    Public Shared Function ObtenerInformeDetallado(anio As Integer, estadoInforme As String, incluirCancelados As Boolean) As DataTable
        Dim dtResultados As New DataTable()
        ' Filtro extra si se necesitan montos positivos
        Dim filtroCancelados As String = If(incluirCancelados, " AND DTP.CUOTA > 0 ", "")

        ' Consulta optimizada: JOINs directos por ID
        Dim query As String = "SELECT 
                            DTP.ID_PRESTAMO AS ID, 
                            cli.idClientes, 
                            cli.nomapell_razon, 
                            publi.CONCEPTO, 
                            publi.DESCRIPCION, 
                            DTP.FECHA AS VENCIMIENTO, 
                            DTP.CUOTA AS MONTO, 
                            CONCAT(compF.abrev, ' ', LPAD(fFact.ptovta, 4, '0'), '-', LPAD(fFact.num_fact, 8, '0')) AS FACTURA, 
                            CONCAT(compR.abrev, ' ', LPAD(fRec.ptovta, 4, '0'), '-', LPAD(fRec.num_fact, 8, '0')) AS RECIBO, 
    
                            /* AQUI EVALUAMOS EL ESTADO DINÁMICAMENTE */
                            CASE 
                                WHEN DTP.estado = 'facturado' AND DATEDIFF(CURDATE(), fFact.fecha) > 15 THEN 'MOROSO'
                                ELSE DTP.estado 
                            END AS ESTADO 
                        FROM rym_detalle_prestamo AS DTP 
                        INNER JOIN rym_prestamo AS publi ON DTP.ID_PRESTAMO = publi.ID_PRESTAMO 
                        INNER JOIN fact_clientes AS cli ON publi.ID_CLIENTE = cli.idClientes 
                        LEFT JOIN fact_facturas AS fFact ON DTP.id_factura = fFact.id 
                        LEFT JOIN tipos_comprobantes AS compF ON fFact.tipofact = compF.donfdesc AND fFact.ptovta = compF.ptovta 
                        LEFT JOIN fact_facturas AS fRec ON DTP.id_recibo = fRec.id 
                        LEFT JOIN tipos_comprobantes AS compR ON fRec.tipofact = compR.donfdesc AND fRec.ptovta = compR.ptovta 
                        WHERE YEAR(publi.fecha) = @anio 
                        AND publi.estado=1 " & filtroCancelados &
                        "HAVING ESTADO LIKE '" & estadoInforme & "'" &
                        "ORDER BY cli.nomapell_razon ASC, DTP.ID_PRESTAMO ASC, DTP.FECHA ASC"
        'MsgBox(query)
        Try
            Using conn As New MySqlConnection(CadenaConexion)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@anio", anio)
                    cmd.Parameters.AddWithValue("@estado", estadoInforme)
                    conn.Open()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtResultados)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener informe optimizado: " & ex.Message)
        End Try

        Return dtResultados
    End Function
    ''' <summary>
    ''' Obtiene el listado de Cuenta Corriente / Facturación de publicidades.
    ''' </summary>
    Public Shared Function ObtenerListadoCtaCte(fechaCorte As Date, busqueda As String) As DataTable
        Dim dtResultados As New DataTable()

        ' La consulta original que pasaste, pero parametrizada
        Dim query As String = "SELECT pr.ID_PRESTAMO as ID_PUBLICIDAD, pr.ID_CLIENTE, cl.nomapell_razon AS CLIENTE, " &
                          "cl.vendedor as VENDEDOR, pr.DESCRIPCION, pr.CONCEPTO, pr.FECHA as INICIO, " &
                          "(select date_add(max(fecha), interval -1 day) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO) as FIN, " &
                          "pr.MONTO_PRESTAMO as IMPORTE_TOTAL, " &
                          "ifnull((select sum(itm.ptotal) from fact_items as itm where itm.tipofact in(1,2,6,7,11,12,999) " &
                          "and itm.plu like concat('%#', pr.ID_PRESTAMO, '%')), 0) AS FACTURADO " &
                          "from fact_clientes as cl, rym_prestamo as pr " &
                          "where pr.ID_CLIENTE=cl.idclientes "

        ' Agregamos filtros dinámicos seguros
        Dim filtros As String = ""
        If Not String.IsNullOrWhiteSpace(busqueda) Then
            filtros &= " AND (cl.nomapell_razon LIKE @busq OR pr.ID_PRESTAMO LIKE @busqId) "
        End If

        ' El having para la fecha
        Dim havingSql As String = " HAVING FIN >= date_add(@fecha, interval -1 day) "

        Dim queryFinal As String = query & filtros & havingSql & " ORDER BY cl.nomapell_razon ASC"

        Try
            Using conn As New MySqlConnection(CadenaConexion)
                Using cmd As New MySqlCommand(queryFinal, conn)
                    cmd.Parameters.AddWithValue("@fecha", fechaCorte.ToString("yyyy-MM-dd"))

                    If Not String.IsNullOrWhiteSpace(busqueda) Then
                        cmd.Parameters.AddWithValue("@busq", "%" & busqueda.Replace(" ", "%") & "%")
                        cmd.Parameters.AddWithValue("@busqId", busqueda.Trim())
                    End If

                    conn.Open()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtResultados)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error en consulta CtaCte: " & ex.Message)
        End Try

        Return dtResultados
    End Function

    Public Shared Function DesactivarPublicidad(idPublicidad As Integer, motivo As String) As Boolean
        Try
            Using conn As New MySqlConnection(CadenaConexion)
                conn.Open()
                ' Actualizamos el estado a 0 y concatenamos el motivo en OBSERVACIONES
                ' Usamos COALESCE para evitar problemas si observaciones es NULL
                Dim sql As String = "UPDATE rym_prestamo SET " &
                                "ESTADO = 0, " &
                                "OBSERVACIONES = CONCAT(COALESCE(OBSERVACIONES, ''), ' [BAJA: ', @motivo, ' - ', @fecha, ']') " &
                                "WHERE ID_PRESTAMO = @id"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", idPublicidad)
                    cmd.Parameters.AddWithValue("@motivo", motivo.Trim().ToUpper())
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("dd/MM/yy"))
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al desactivar la publicidad: " & ex.Message)
        End Try
    End Function
    ' ==========================================
    ' 3. CLASES DE TRANSFERENCIA Y ENUMS (DTO)
    ' ==========================================
    Public Enum TipoVistaPublicidad
        Vigentes = 1
        AFacturar = 2
        AVencer = 3
            Operador = 4
        End Enum

    Public Class FiltrosPublicidad
        Public Property FechaDesde As Date
        Public Property TextoBusqueda As String
        Public Property SoloMorosos As Boolean
        Public Property SoloSinFacturar As Boolean
        Public Property IdVendedor As Integer
        Public Property IdCobrador As Integer
        Public Property Concepto As String
        Public Property OrdenarPor As String

        Public Sub New()
            TextoBusqueda = String.Empty
            Concepto = String.Empty
            OrdenarPor = "CLIENTE asc" ' Valor por defecto seguro
            IdVendedor = 0
            IdCobrador = 0
            SoloMorosos = False
            SoloSinFacturar = False
            FechaDesde = Date.Now
        End Sub
    End Class
End Class
