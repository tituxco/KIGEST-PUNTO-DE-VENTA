Imports MySql.Data.MySqlClient

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
                queryBase = "SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, dt.ID AS ID_CUOTA, pr.FECHA as INICIO, " &
                       "dt.FECHA as VencActual, " &
                       "(SELECT MAX(fecha) FROM rym_detalle_prestamo WHERE ID_PRESTAMO = pr.ID_PRESTAMO) as FIN, " &
                       "cl.idclientes, cl.nomapell_razon as CLIENTE, pr.DESCRIPCION, " &
                       "ROUND(pr.MONTO_PRESTAMO, 2) AS MONTO_TOTAL, ROUND(pr.CUOTA, 2) AS MONTO_MENSUAL, " &
                       "ROUND(pr.MONTO_PRESTAMO - (SELECT IFNULL(SUM(MONTO_PAGADO), 0) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO), 2) AS SALDO, " &
                       "pr.CONCEPTO, pr.OBSERVACIONES, cl.vendedor, pr.COBRADOR, " &
                       "CASE " &
                       "  WHEN dt.id_recibo > 0 THEN 'PAGADA' " &
                       "  WHEN dt.id_factura > 0 THEN 'FACTURADA' " &
                       "  WHEN dt.ID IS NOT NULL THEN 'PENDIENTE' " &
                       "  ELSE 'SIN CUOTA' " &
                       "END AS ESTADO_MES_CURSO " &
                       "FROM rym_prestamo as pr " &
                       "INNER JOIN fact_clientes as cl ON pr.ID_CLIENTE = cl.idclientes " &
                       "LEFT JOIN rym_detalle_prestamo as dt ON dt.ID_PRESTAMO = pr.ID_PRESTAMO " &
                       "   AND MONTH(dt.FECHA) = MONTH(?fechaDesde) AND YEAR(dt.FECHA) = YEAR(?fechaDesde) " &
                       "WHERE pr.ESTADO = 1 "

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

        ' 2. FILTROS DINÁMICOS (Buscador, Vendedor, etc.)
        If Not String.IsNullOrWhiteSpace(filtros.TextoBusqueda) Then
            filtrosSql &= " AND (cl.nomapell_razon LIKE ?textoBusqueda OR pr.ID_PRESTAMO = ?codigoPrestamo) "
        End If
        If filtros.IdVendedor > 0 Then filtrosSql &= " AND cl.vendedor = ?idVendedor "

        ' 3. ENSAMBLADO FINAL
        Dim queryFinal As String = queryBase & filtrosSql & havingSql & " ORDER BY " & filtros.OrdenarPor

        Try
            Using conn As New MySqlConnection(CadenaConexion)
                Using cmd As New MySqlCommand(queryFinal, conn)
                    cmd.Parameters.AddWithValue("?fechaDesde", filtros.FechaDesde)

                    If Not String.IsNullOrWhiteSpace(filtros.TextoBusqueda) Then
                        cmd.Parameters.AddWithValue("?textoBusqueda", "%" & filtros.TextoBusqueda & "%")
                        cmd.Parameters.AddWithValue("?codigoPrestamo", filtros.TextoBusqueda.Trim())
                    End If
                    If filtros.IdVendedor > 0 Then cmd.Parameters.AddWithValue("?idVendedor", filtros.IdVendedor)

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
    'Public Shared Function ObtenerListado(vista As TipoVistaPublicidad, filtros As FiltrosPublicidad) As DataTable
    '    Dim dtResultados As New DataTable()
    '    Dim filtrosSql As String = ""
    '    Dim queryBase As String = ""
    '    Dim havingSql As String = ""

    '    ' 1. DEFINICIÓN DE QUERIES SEGÚN LA VISTA
    '    Select Case vista
    '    ' ===========================================================================
    '    ' VISTA OPERADOR: Solo información de ejecución, nada de montos ni facturas
    '    ' ===========================================================================
    '        Case TipoVistaPublicidad.Operador
    '            queryBase = "SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, " &
    '                    "(SELECT MAX(fecha) FROM rym_detalle_prestamo WHERE ID_PRESTAMO = pr.ID_PRESTAMO) as FIN, " &
    '                    "cl.nomapell_razon as CLIENTE, pr.DESCRIPCION, pr.CONCEPTO, pr.OBSERVACIONES, " &
    '                    "cl.vendedor, pr.COBRADOR " &
    '                    "FROM rym_prestamo as pr " &
    '                    "INNER JOIN fact_clientes as cl ON pr.ID_CLIENTE = cl.idclientes " &
    '                    "WHERE pr.ESTADO = 1 "

    '            ' Filtro de vigencia para el operador
    '            havingSql = " HAVING FIN >= DATE_FORMAT(?fechaDesde, '%Y-%m-01') "

    '            ' ===========================================================================
    '            ' VISTAS CONTABLES: Vigentes, A Facturar, A Vencer (Con montos y estados)
    '            ' ===========================================================================
    '        Case Else
    '            queryBase = "SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, " &
    '                    "dt.FECHA as VencActual, " &
    '                    "(SELECT MAX(fecha) FROM rym_detalle_prestamo WHERE ID_PRESTAMO = pr.ID_PRESTAMO) as FIN, " &
    '                    "cl.idclientes, cl.nomapell_razon as CLIENTE, pr.DESCRIPCION, " &
    '                    "ROUND(pr.MONTO_PRESTAMO, 2) AS MONTO_TOTAL, ROUND(pr.CUOTA, 2) AS MONTO_MENSUAL, " &
    '                    "ROUND(pr.MONTO_PRESTAMO - (SELECT IFNULL(SUM(MONTO_PAGADO), 0) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO), 2) AS SALDO, " &
    '                    "pr.CONCEPTO, pr.OBSERVACIONES, cl.vendedor, pr.COBRADOR, " &
    '                    "CASE " &
    '                    "  WHEN dt.id_recibo > 0 THEN 'PAGADA' " &
    '                    "  WHEN dt.id_factura > 0 THEN 'FACTURADA' " &
    '                    "  WHEN dt.ID IS NOT NULL THEN 'PENDIENTE' " &
    '                    "  ELSE 'SIN CUOTA' " &
    '                    "END AS ESTADO_MES_CURSO " &
    '                    "FROM rym_prestamo as pr " &
    '                    "INNER JOIN fact_clientes as cl ON pr.ID_CLIENTE = cl.idclientes " &
    '                    "LEFT JOIN rym_detalle_prestamo as dt ON dt.ID_PRESTAMO = pr.ID_PRESTAMO " &
    '                    "   AND MONTH(dt.FECHA) = MONTH(?fechaDesde) AND YEAR(dt.FECHA) = YEAR(?fechaDesde) " &
    '                    "WHERE pr.ESTADO = 1 "

    '            ' Lógica de filtrado por tipo de vista contable
    '            Select Case vista
    '                Case TipoVistaPublicidad.AFacturar
    '                    ' Solo las que tienen cuota programada este mes y no tienen factura
    '                    filtrosSql &= " AND dt.ID_DETALLE IS NOT NULL AND dt.id_factura = 0 "

    '                Case TipoVistaPublicidad.AVencer
    '                    ' Solo las que la última cuota (FIN) es en este mes
    '                    havingSql = " HAVING MONTH(FIN) = MONTH(?fechaDesde) AND YEAR(FIN) = YEAR(?fechaDesde) "

    '                Case TipoVistaPublicidad.Vigentes
    '                    ' Todo lo que termina de hoy en adelante
    '                    havingSql = " HAVING FIN >= DATE_FORMAT(?fechaDesde, '%Y-%m-01') "
    '            End Select
    '    End Select

    '    ' 2. FILTROS DINÁMICOS (Buscador, Vendedor, etc.)
    '    If Not String.IsNullOrWhiteSpace(filtros.TextoBusqueda) Then
    '        filtrosSql &= " AND (cl.nomapell_razon LIKE ?textoBusqueda OR pr.ID_PRESTAMO = ?codigoPrestamo) "
    '    End If
    '    If filtros.IdVendedor > 0 Then filtrosSql &= " AND cl.vendedor = ?idVendedor "

    '    ' 3. ENSAMBLADO FINAL
    '    Dim queryFinal As String = queryBase & filtrosSql & havingSql & " ORDER BY " & filtros.OrdenarPor

    '    Try
    '        Using conn As New MySqlConnection(CadenaConexion)
    '            Using cmd As New MySqlCommand(queryFinal, conn)
    '                cmd.Parameters.AddWithValue("?fechaDesde", filtros.FechaDesde)

    '                If Not String.IsNullOrWhiteSpace(filtros.TextoBusqueda) Then
    '                    cmd.Parameters.AddWithValue("?textoBusqueda", "%" & filtros.TextoBusqueda & "%")
    '                    cmd.Parameters.AddWithValue("?codigoPrestamo", filtros.TextoBusqueda.Trim())
    '                End If
    '                If filtros.IdVendedor > 0 Then cmd.Parameters.AddWithValue("?idVendedor", filtros.IdVendedor)

    '                conn.Open()
    '                Using da As New MySqlDataAdapter(cmd)
    '                    da.Fill(dtResultados)
    '                End Using
    '            End Using
    '        End Using

    '        ' 4. FILA DE TOTALES CON FORMATO
    '        If dtResultados.Rows.Count > 0 AndAlso vista <> TipoVistaPublicidad.Operador Then
    '            Dim sumaMensual As Decimal = 0
    '            For Each row As DataRow In dtResultados.Rows
    '                If Not IsDBNull(row("MONTO_MENSUAL")) Then sumaMensual += Convert.ToDecimal(row("MONTO_MENSUAL"))
    '            Next

    '            Dim drTotal As DataRow = dtResultados.NewRow()
    '            drTotal("CLIENTE") = ">>> TOTALES <<<"
    '            ' Formateamos el número como String para que incluya los puntos y comas en la última fila
    '            ' "N2" aplica el formato numérico con 2 decimales y separador de miles
    '            drTotal("MONTO_MENSUAL") = sumaMensual
    '            dtResultados.Rows.Add(drTotal)
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("Error en Listado: " & ex.Message)
    '    End Try

    '    Return dtResultados
    'End Function
    '''' <summary>
    '''' Ejecuta la consulta principal del listado de publicidades devolviendo un DataTable.
    '''' </summary>
    'Public Shared Function ObtenerListado(vista As TipoVistaPublicidad, filtros As FiltrosPublicidad) As DataTable
    '    Dim dtResultados As New DataTable()
    '    Dim queryBase As String = ""
    '    Dim filtrosSql As String = ""
    '    Dim havingSql As String = ""

    '    ' 1. Armamos la consulta base según la vista
    '    Select Case vista
    '        Case TipoVistaPublicidad.Vigentes
    '            queryBase = "SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, " &
    '                            "(SELECT group_concat(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO and MONTH(FECHA) LIKE MONTH(date_sub(?fechaDesde, interval 1 month))) as VencActual, " &
    '                            "(select date_add(max(fecha),interval -1 day) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO) as FIN, " &
    '                            "cl.idclientes, cl.nomapell_razon as CLIENTE, pr.DESCRIPCION as DESCRIPCION, " &
    '                            "round(pr.MONTO_PRESTAMO,2) AS MONTO_TOTAL, round(pr.CUOTA,2) AS MONTO_MENSUAL, " &
    '                            "ROUND(pr.MONTO_PRESTAMO - (SELECT SUM(MONTO_PAGADO) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO),2) AS SALDO, pr.CONCEPTO, " &
    '                            "pr.OBSERVACIONES, " &
    '                            "(select group_concat(facturaActual) from factura_actual_servicios where plu like concat('%#',pr.ID_PRESTAMO,'%')) AS FACTURA_ACTUAL, " &
    '                            "cl.vendedor, pr.COBRADOR " &
    '                            "FROM rym_prestamo as pr, fact_clientes as cl " &
    '                            "WHERE pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1 "
    '            havingSql = " HAVING FIN >= date_add(?fechaDesde, interval -1 day) "

    '        Case TipoVistaPublicidad.AFacturar
    '            queryBase = "SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, " &
    '                            "(SELECT group_concat(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO and MONTH(FECHA) LIKE MONTH(date_sub(now(),interval 1 month)) and YEAR(fecha)=YEAR(now())) as VencActual, " &
    '                            "(select date_add(max(fecha),interval -1 day) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO) as FIN, " &
    '                            "cl.idclientes, cl.nomapell_razon as CLIENTE, pr.DESCRIPCION as DESCRIPCION, " &
    '                            "round(pr.MONTO_PRESTAMO,2) AS MONTO_TOTAL, round(pr.CUOTA,2) AS MONTO_MENSUAL, " &
    '                            "ROUND(pr.MONTO_PRESTAMO - (SELECT SUM(MONTO_PAGADO) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO),2) AS SALDO, pr.CONCEPTO, " &
    '                            "pr.OBSERVACIONES, " &
    '                            "(select group_concat(facturaActual) from factura_actual_servicios where plu like concat('%#',pr.ID_PRESTAMO,'%')) AS FACTURA_ACTUAL, " &
    '                            "cl.vendedor, pr.COBRADOR " &
    '                            "FROM rym_prestamo as pr, fact_clientes as cl " &
    '                            "WHERE pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1 "
    '            havingSql = " HAVING VencActual is not null "

    '        Case TipoVistaPublicidad.AVencer
    '            queryBase = "SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, " &
    '                            "(SELECT group_concat(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO and MONTH(FECHA) LIKE MONTH(date_sub(now(),interval 1 month))) as VencActual, " &
    '                            "(select date_add(max(fecha),interval -1 day) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO) as FIN, " &
    '                            "cl.idclientes, cl.nomapell_razon as CLIENTE, pr.DESCRIPCION as DESCRIPCION, " &
    '                            "round(pr.MONTO_PRESTAMO,2) AS MONTO_TOTAL, round(pr.CUOTA,2) AS MONTO_MENSUAL, " &
    '                            "ROUND(pr.MONTO_PRESTAMO - (SELECT SUM(MONTO_PAGADO) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO),2) AS SALDO, pr.CONCEPTO, " &
    '                            "pr.OBSERVACIONES, " &
    '                            "(select group_concat(facturaActual) from factura_actual_servicios where plu like concat('%#',pr.ID_PRESTAMO,'%')) AS FACTURA_ACTUAL, " &
    '                            "cl.vendedor, pr.COBRADOR " &
    '                            "FROM rym_prestamo as pr, fact_clientes as cl " &
    '                            "WHERE pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1 "
    '            havingSql = " HAVING date_format(FIN,'%Y-%m') = date_format(?fechaDesde,'%Y-%m') "

    '        Case TipoVistaPublicidad.Operador
    '            queryBase = "SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, " &
    '                            "(SELECT FECHA FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO and MONTH(FECHA) LIKE MONTH(date_sub(now(),interval 1 month))) as VencActual, " &
    '                            "(select date_add(max(fecha),interval -1 day) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO) as FIN, " &
    '                            "cl.nomapell_razon as CLIENTE, pr.DESCRIPCION as DESCRIPCION, " &
    '                            "pr.CONCEPTO, pr.OBSERVACIONES, cl.vendedor, pr.COBRADOR " &
    '                            "FROM rym_prestamo as pr, fact_clientes as cl " &
    '                            "WHERE pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1 "
    '            havingSql = " HAVING FIN >= date_add(?fechaDesde, interval -1 day) "
    '    End Select

    '    ' 2. Agregamos los filtros dinámicos (Cláusulas AND)
    '    If Not String.IsNullOrWhiteSpace(filtros.TextoBusqueda) Then
    '        filtrosSql &= " AND (cl.nomapell_razon LIKE ?textoBusqueda OR pr.ID_PRESTAMO = ?codigoPrestamo) "
    '    End If

    '    If filtros.IdVendedor > 0 Then filtrosSql &= " AND cl.vendedor = ?idVendedor "
    '    If filtros.IdCobrador > 0 Then filtrosSql &= " AND pr.COBRADOR = ?idCobrador "
    '    If Not String.IsNullOrWhiteSpace(filtros.Concepto) Then filtrosSql &= " AND pr.CONCEPTO = ?concepto "

    '    ' Filtros que actúan sobre el HAVING (Resultados calculados)
    '    If filtros.SoloMorosos Then
    '        ' Reemplazamos la lógica vieja por una condición segura en el HAVING
    '        Dim sqlMoroso As String = " (select count(*) from rym_detalle_prestamo as DTP where DTP.ID_PRESTAMO not in (select id FROM rym_pagos as pg where pg.ID_PRESTAMO=DTP.ID_PRESTAMO) and DTP.ID_PRESTAMO=pr.ID_PRESTAMO AND DATEDIFF(NOW(),DTP.FECHA) > 14) > 0 "
    '        havingSql &= If(havingSql.Contains("HAVING"), " AND " & sqlMoroso, " HAVING " & sqlMoroso)
    '    End If

    '    If filtros.SoloSinFacturar Then
    '        havingSql &= If(havingSql.Contains("HAVING"), " AND FACTURA_ACTUAL IS NULL ", " HAVING FACTURA_ACTUAL IS NULL ")
    '    End If

    '    ' 3. Ensamblamos la consulta
    '    Dim queryFinal As String = queryBase & filtrosSql & havingSql & " ORDER BY " & filtros.OrdenarPor

    '    ' 4. Ejecutamos usando parámetros para evitar inyecciones SQL
    '    Try
    '        Using conn As New MySqlConnection(CadenaConexion)
    '            Using cmd As New MySqlCommand(queryFinal, conn)
    '                ' Asignamos los parámetros de forma limpia
    '                cmd.Parameters.AddWithValue("?fechaDesde", filtros.FechaDesde.ToString("yyyy-MM-dd"))

    '                If Not String.IsNullOrWhiteSpace(filtros.TextoBusqueda) Then
    '                    cmd.Parameters.AddWithValue("?textoBusqueda", "%" & filtros.TextoBusqueda & "%")
    '                    cmd.Parameters.AddWithValue("?codigoPrestamo", filtros.TextoBusqueda.Trim())
    '                End If

    '                If filtros.IdVendedor > 0 Then cmd.Parameters.AddWithValue("?idVendedor", filtros.IdVendedor)
    '                If filtros.IdCobrador > 0 Then cmd.Parameters.AddWithValue("?idCobrador", filtros.IdCobrador)
    '                If Not String.IsNullOrWhiteSpace(filtros.Concepto) Then cmd.Parameters.AddWithValue("?concepto", filtros.Concepto)

    '                conn.Open()
    '                Using da As New MySqlDataAdapter(cmd)
    '                    da.Fill(dtResultados)
    '                End Using
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        Throw New Exception("Error al obtener listado de publicidades: " & ex.Message)
    '    End Try
    '    ' 5. Agregamos la fila de Totales al final del DataTable
    '    If dtResultados.Rows.Count > 0 Then
    '        Dim drTotal As DataRow = dtResultados.NewRow()

    '        ' Sumamos las columnas numéricas
    '        ' Usamos un bucle para evitar errores si la vista no tiene alguna columna
    '        Dim sumaTotal As Decimal = 0
    '        Dim sumaMensual As Decimal = 0
    '        Dim sumaSaldo As Decimal = 0

    '        For Each row As DataRow In dtResultados.Rows
    '            If dtResultados.Columns.Contains("MONTO_TOTAL") AndAlso Not IsDBNull(row("MONTO_TOTAL")) Then
    '                sumaTotal += Convert.ToDecimal(row("MONTO_TOTAL"))
    '            End If
    '            If dtResultados.Columns.Contains("MONTO_MENSUAL") AndAlso Not IsDBNull(row("MONTO_MENSUAL")) Then
    '                sumaMensual += Convert.ToDecimal(row("MONTO_MENSUAL"))
    '            End If
    '            If dtResultados.Columns.Contains("SALDO") AndAlso Not IsDBNull(row("SALDO")) Then
    '                sumaSaldo += Convert.ToDecimal(row("SALDO"))
    '            End If
    '        Next

    '        ' Asignamos los valores a la fila especial
    '        drTotal("CLIENTE") = ">>> TOTALES GENERALES <<<"
    '        If dtResultados.Columns.Contains("MONTO_TOTAL") Then drTotal("MONTO_TOTAL") = sumaTotal
    '        If dtResultados.Columns.Contains("MONTO_MENSUAL") Then drTotal("MONTO_MENSUAL") = sumaMensual
    '        If dtResultados.Columns.Contains("SALDO") Then drTotal("SALDO") = sumaSaldo

    '        dtResultados.Rows.Add(drTotal)
    '    End If

    '    Return dtResultados
    'End Function

    ''' <summary>
    ''' Genera el informe anual pivot. 
    ''' Si porFechaInicio es True, desplaza las cuotas un mes hacia atrás para coincidir con la prestación del servicio.
    ''' </summary>
    Public Shared Function ObtenerInformeAnualPivot(anio As Integer, porFechaInicio As Boolean) As DataTable
        Dim dtResultados As New DataTable()

        ' Si es por inicio, restamos 1 mes a la fecha del detalle para que la cuota de Febrero se vea en Enero.
        ' Si es por vencimiento, dejamos el desplazamiento mínimo de 1 día que ya tenías.
        Dim intervalo As String = If(porFechaInicio, "interval 1 month", "interval 1 day")

        ' Usamos la variable {intervalo} dentro de los DATE_SUB de la consulta
        Dim query As String = "SELECT publi.ID_PRESTAMO as ID, cli.idClientes, cli.nomapell_razon, publi.CONCEPTO, publi.DESCRIPCION, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=1) as enero, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=2) as febrero, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=3) as marzo, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=4) as abril, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=5) as mayo, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=6) as junio, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=7) as julio, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=8) as agosto, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=9) as septiembre, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=10) as octubre, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=11) as noviembre, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio and month(date_sub(publiDet.FECHA, " & intervalo & "))=12) as diciembre, " &
                                  "(select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(date_sub(publiDet.FECHA, " & intervalo & "))=@anio) as total " &
                                  "from fact_clientes as cli, rym_prestamo as publi " &
                                  "where cli.idclientes = publi.ID_CLIENTE " &
                                  "AND EXISTS (SELECT 1 FROM rym_detalle_prestamo as dp WHERE dp.ID_PRESTAMO = publi.ID_PRESTAMO AND YEAR(date_sub(dp.FECHA, " & intervalo & ")) = @anio) " &
                                  "order by cli.nomapell_razon asc, publi.ID_PRESTAMO asc"

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
        Dim query As String = "SELECT DTP.ID_PRESTAMO AS ID, cli.idClientes, cli.nomapell_razon, publi.CONCEPTO, publi.DESCRIPCION, " &
                          "DTP.FECHA AS VENCIMIENTO, DTP.CUOTA AS MONTO, " &
                          "CONCAT(compF.abrev, ' ', LPAD(fFact.ptovta, 4, '0'), '-', LPAD(fFact.num_fact, 8, '0')) AS FACTURA, " &
                          "CONCAT(compR.abrev, ' ', LPAD(fRec.ptovta, 4, '0'), '-', LPAD(fRec.num_fact, 8, '0')) AS RECIBO, " &
                          "DTP.estado AS ESTADO " &
                          "FROM rym_detalle_prestamo AS DTP " &
                          "INNER JOIN rym_prestamo AS publi ON DTP.ID_PRESTAMO = publi.ID_PRESTAMO " &
                          "INNER JOIN fact_clientes AS cli ON publi.ID_CLIENTE = cli.idClientes " &
                          "LEFT JOIN fact_facturas AS fFact ON DTP.id_factura = fFact.id " &
                          "LEFT JOIN tipos_comprobantes AS compF ON fFact.tipofact = compF.donfdesc AND fFact.ptovta = compF.ptovta " &
                          "LEFT JOIN fact_facturas AS fRec ON DTP.id_recibo = fRec.id " &
                          "LEFT JOIN tipos_comprobantes AS compR ON fRec.tipofact = compR.donfdesc AND fRec.ptovta = compR.ptovta " &
                          "WHERE YEAR(publi.fecha) = @anio " &
                          "AND DTP.estado LIKE @estado " & filtroCancelados & " " &
                          "ORDER BY cli.nomapell_razon ASC, DTP.ID_PRESTAMO ASC, DTP.FECHA ASC"

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
