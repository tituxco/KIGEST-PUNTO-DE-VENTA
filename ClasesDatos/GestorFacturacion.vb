Imports MySql.Data.MySqlClient
Imports SIGT__KIGEST.datosEstructura
Imports SIGT__KIGEST.GestorAcademia
Imports SIGT__KIGEST.GestorClientes
Imports SIGT__KIGEST.GestorInsumos
Imports System.Data
Public Class GestorFacturacion
    Private Shared ReadOnly Property CadenaConexion As String
        Get
            Return "Server=" & DatosAcceso.CLOUDserv & ";" &
                   "Port=" & DatosAcceso.puerto & ";" &
                   "Database=" & DatosAcceso.bd & ";" &
                   "Uid=" & DatosAcceso.usuario & ";" &
                   "Pwd=" & DatosAcceso.pass & ";" &
                   "Default Command Timeout=300;"
        End Get
    End Property
    Public Class TotalesFacturaViewModel
        Public Property SubtotalNeto As Decimal = 0
        Public Property Iva21 As Decimal = 0
        Public Property Iva105 As Decimal = 0
        Public Property OtroIva As Decimal = 0
        Public Property TotalImpuestos As Decimal = 0
        Public Property OtrosTributos As Decimal = 0
        Public Property TotalGeneral As Decimal = 0
        Public Property TotalIDC As Decimal = 0
        Public Property TotalICL As Decimal = 0
        Public Property Subtotal21 As Decimal = 0
        Public Property Subtotal105 As Decimal = 0
        Public Property Subtotal0 As Decimal = 0
    End Class
    Public Class fact_factura
        Public Property id As Integer
        Public Property ptovta As Integer
        Public Property num_fact As Integer
        Public Property fecha As DateTime
        Public Property id_cliente As Integer
        Public Property razon As String
        Public Property direccion As String
        Public Property localidad As String
        Public Property tipocontr As String
        Public Property cuit As String
        Public Property condvta As String
        Public Property subtotal As Decimal
        Public Property iva105 As Decimal
        Public Property iva21 As Decimal
        Public Property otroiva As Decimal
        Public Property total As Decimal
        Public Property vendedor As String
        Public Property tipofact As String
        Public Property observaciones As String
        Public Property observaciones2 As String
        Public Property remito As String
        Public Property cae As String
        Public Property vtocae As String
        Public Property codbarra As String
        Public Property codigo_qr As String
    End Class
    Public Class factNuevaFactura_Datos
        Public Property IdDevuelto As Integer
        Public Property cliente As fact_clientes
        Public Property condvta As fact_condventas
        Public Property ivatipo As fact_ivaTipo
        Public Property vendedor As fact_vendedor
        Public Property tipofact As fact_comprobantes_tipo
        Public Property ptovta As fact_puntosventa
        Public Property Items As New List(Of factNuevaFactura_Items)
        Public Property Almacen As fact_insumos_almacenes
        Public Property num_fact As Integer
        Public Property fecha As DateTime
        Public Property subtotal As Decimal
        Public Property subtotal21 As Decimal
        Public Property subtotal105 As Decimal
        Public Property subtotal0 As Decimal

        Public Property iva105 As Decimal
        Public Property iva21 As Decimal
        Public Property otroiva As Decimal
        Public Property total As Decimal
        Public Property observaciones As String
        Public Property observaciones2 As String
        Public Property remito As String
        Public Property cae As String
        Public Property vtocae As DateTime
        Public Property codbarra As String
        Public Property codigo_qr As Byte()
        Public Property caja As Integer = 1
        Public Property cuentaContable As Integer = 1
        Public Property descontarStock As Boolean = False
        Public Property listaPedidos As String
        'propiedades necesarias en el caso de que se necesite autorizar una nota de credito con comprobantes asociados
        Public Property ComprobanteAsociadoNro As Integer
        Public Property ComprobanteAsociadoTipo As Integer
        Public Property ComprobanteAsociadoFecha As String
    End Class
    Public Class factNuevaFactura_Items
        Public Property id As Integer
        Public Property cod As String
        Public Property plu As String
        Public Property cantidad As Decimal
        Public Property descripcion As String
        Public Property iva As Decimal
        Public Property punit As Decimal
        Public Property ptotal As Decimal
        Public Property codint As String
        Public Property impuestoFijo01 As Decimal
        Public Property impuestoFijo02 As Decimal
        Public Property fecha_alta As DateTime
        Public Property id_fact As Integer
        Public Property idCaja As Integer
        Public Property StockSuficiente As Boolean = False
        Public Property factura As factNuevaFactura_Datos
        Public Property Almacen As fact_insumos_almacenes
        Public Property tipofact As fact_comprobantes_tipo
    End Class
    Public Class DatosReciboCobro
        Public TipoFac As Integer
        Public PtoVta As Integer
        Public NumRecibo As Integer
        Public Fecha As String ' Formato yyyy-MM-dd
        Public CtaClie As Integer
        Public RazonSocial As String
        Public Direccion As String
        Public Localidad As String
        Public TipoContr As String
        Public CUIT As String
        Public Total As Decimal
        Public EsTarjeta As Boolean
        Public TarjetaNombre As String
        Public TarjetaAutorizacion As String
        Public IdFacturaCTA As Integer
        Public IdFacturaComp As Integer
        Public IdAlmacen As Integer
        Public IdCaja As Integer
    End Class

    ' ESTRUCTURAS DE DATOS PARA EL PEDIDO
    Public Class DatosItemPedido
        Public Codigo As String
        Public CodInt As String
        Public Cantidad As Decimal
        Public Descripcion As String
        Public Iva As Decimal
        Public PUnit As Decimal
        Public PTotal As Decimal
    End Class
    Public Class DatosPedidoFacturar
        Public IdPedido As Integer
        Public IdCondVta As Integer
        Public IdVendedor As Integer
        Public IdCliente As Integer
        Public Items As New List(Of DatosItemPedido)
    End Class

    Public Class fact_facturasrapidas
        Public Property id As Integer
        Public Property nombre As String
        Public Property idPtoVta As Integer
        Public Property punto_venta As fact_puntosventa
        Public Property idTipoFact As Integer
        Public Property tipofact As fact_comprobantes_tipo
        Public Overrides Function ToString() As String
            Return $"({id}) {nombre}"
        End Function
        Public Shared Function ObtenerTodos() As List(Of fact_facturasrapidas)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_facturasrapidas)
                    Using comando As New MySqlCommand("SELECT * from fact_facturasrapidas ", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_facturasrapidas
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.idPtoVta = lector("punto_venta")
                                item.idTipoFact = lector("tipofact")
                                lista.Add(item)
                            End While
                            lector.Close()
                            For Each itm As fact_facturasrapidas In lista
                                itm.punto_venta = fact_puntosventa.BuscarPorID(itm.idPtoVta)
                                itm.tipofact = fact_comprobantes_tipo.BuscarPorID(itm.idTipoFact)
                            Next
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_facturasrapidas
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_facturasrapidas where id = " & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_facturasrapidas
                            If lector.Read() Then
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.idPtoVta = lector("punto_venta")
                                item.idTipoFact = lector("tipofact")
                                lector.Close()
                                item.punto_venta = fact_puntosventa.BuscarPorID(item.idPtoVta)
                                item.tipofact = fact_comprobantes_tipo.BuscarPorID(item.idTipoFact)
                            End If
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
    Public Class fact_comprobantes_tipo
        Public Property id As Integer
        Public Property nombre As String
        Public Property disp As Integer
        Public Overrides Function ToString() As String
            Return $"{nombre}"
        End Function
        Public Shared Function ObtenerTodos() As List(Of fact_comprobantes_tipo)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_comprobantes_tipo)
                    Using comando As New MySqlCommand("SELECT * from fact_comprobantes_tipo", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_comprobantes_tipo
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.disp = lector("disp")
                            End While
                            lector.Close()
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_comprobantes_tipo
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_comprobantes_tipo where id = " & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_comprobantes_tipo
                            If lector.Read() Then
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.disp = lector("disp")
                            End If
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
    End Class
    Public Class fact_puntosventa
        Public Property id As Integer
        Public Property numero As Integer
        Public Property descripcion As String
        Public Property idEmpresa As Integer
        Public Property empresa As fact_Empresa
        Public Overrides Function ToString() As String
            Return $"({numero}) {descripcion}"
        End Function

        Public Shared Function ObtenerTodos() As List(Of fact_puntosventa)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_puntosventa)
                    Using comando As New MySqlCommand("SELECT * from fact_puntosventa", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_puntosventa
                                item.id = lector("id")
                                item.numero = lector("numero").ToString
                                item.descripcion = lector("descripcion").ToString
                                item.idEmpresa = lector("idEmpresa")
                                lista.Add(item)
                            End While
                            lector.Close()
                            For Each pto As fact_puntosventa In lista
                                pto.empresa = fact_Empresa.BuscarPorID(pto.idEmpresa)
                            Next
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_puntosventa
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_puntosventa where id = " & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_puntosventa
                            If lector.Read() Then
                                item.id = lector("id")
                                item.numero = lector("numero").ToString
                                item.descripcion = lector("descripcion").ToString
                                item.idEmpresa = lector("idEmpresa")
                                lector.Close()
                                item.empresa = fact_Empresa.BuscarPorID(item.idEmpresa)
                            End If
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
    End Class
    Public Class fact_ivaTipo
        Public Property id As Integer
        Public Property nombre As String
        Public Overrides Function ToString() As String
            Return nombre
        End Function

        Public Shared Sub Agregar(addID As Integer,
                            addNombre As String)

            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim tipo As New fact_ivaTipo
                    Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into fact_ivatipo (id,nombre) values " & "(?id,?nmb)", conn)
                        With comandoadd.Parameters
                            .AddWithValue("?id", addID)
                            .AddWithValue("?nmb", addNombre)
                        End With
                        comandoadd.ExecuteNonQuery()
                        addID = comandoadd.LastInsertedId
                        tipo.id = addID
                        tipo.nombre = addNombre
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_ivaTipo)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_ivaTipo)
                    Using comando As New MySqlCommand("SELECT * from fact_ivatipo", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_ivaTipo
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                lista.Add(item)
                            End While
                            lector.Close()
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_ivaTipo
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_ivatipo where id=" & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_ivaTipo
                            If lector.Read() Then
                                item.id = lector("id")
                                item.nombre = lector("tipo").ToString
                            End If
                            lector.Close()
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
    ' FUNCIÓN PARA LEER TARJETAS
    Public Shared Function ObtenerNombresTarjetas() As DataTable
        Dim dt As New DataTable()
        Try
            Reconectar()
            Dim sql As String = "SELECT * FROM fact_tarjetasNombres"
            Using adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(sql, GestorConexiones.conexionPrinc)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
            MsgBox("Error al obtener tarjetas: " & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return dt
    End Function

    ' FUNCIÓN REUTILIZABLE PARA BUSCAR ÍTEMS DE UN COMPROBANTE ( para Cursos y Publicidad)
    Public Shared Function ObtenerPLUsPorComprobante(idFactura As Integer, filtroLike As String) As List(Of String)
        Dim lista As New List(Of String)()
        Try
            Reconectar()
            Dim query As String = "SELECT plu FROM fact_items WHERE id_fact = @idFact AND plu LIKE @filtro"
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, GestorConexiones.conexionPrinc)
                cmd.Parameters.AddWithValue("@idFact", idFactura)
                cmd.Parameters.AddWithValue("@filtro", filtroLike)
                Using dr As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        lista.Add(dr("plu").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error al leer PLUs: " & ex.Message)
        End Try
        Return lista
    End Function

    Public Shared Function BuscarProductoProduccion(codigoBuscado As String, ByRef cantidadSalida As Decimal) As GestorInsumos.fact_insumos
        Try

            ' Solo buscamos los datos transaccionales de la producción
            Dim query As String = "SELECT codigo_producto, cantidad, precio " &
                                  "FROM fact_insumos_produccion " &
                                  "WHERE facturado = 0 AND codigobarras = @cod LIMIT 1"


            Using comando As New MySqlCommand(query, GestorConexiones.conexionPrinc)
                comando.Parameters.AddWithValue("@cod", codigoBuscado)

                Using lector As MySqlDataReader = comando.ExecuteReader()
                    If lector.Read() Then
                        ' 1. Capturamos el código real del insumo asociado
                        Dim codProductoInterno As String = lector("codigo_producto").ToString()

                        ' 2. Procesamos cantidad y precio (con la limpieza de comas/puntos)
                        Dim strCantidad As Decimal = ParsearDecimal(lector("cantidad").ToString())

                        Dim strPrecio As Decimal = ParsearDecimal(lector("precio").ToString())

                        ' Cerramos el lector ANTES de llamar a la otra clase
                        lector.Close()

                        ' 3. Le pedimos al Gestor de Insumos que nos traiga el objeto armado (stock incluido)
                        Dim item As GestorInsumos.fact_insumos = GestorInsumos.fact_insumos.BuscarPorCodigoOLector(codProductoInterno)

                        If item IsNot Nothing Then
                            item.precio = Math.Round(strPrecio / strCantidad, 2)
                            cantidadSalida = strCantidad
                        End If

                        Return item
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error al buscar ticket de producción: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        Return Nothing
    End Function
    ' EL GUARDADO DEL RECIBO
    Public Shared Function GuardarReciboDePago(datos As DatosReciboCobro, ByRef idReciboGenerado As Integer) As Boolean
        ' Opcional: Podrías envolver todo en una Transaction, pero lo mantendremos 
        ' lineal como lo venías manejando para respetar tu conexión
        Try
            Reconectar()
            Dim observacionesVenta As String = If(datos.EsTarjeta, "VENTA MOSTRADOR", "VENTA CONTADO")

            ' A. CABECERA DEL RECIBO
            Dim sqlCabecera As String = "INSERT INTO fact_facturas " &
                "(tipofact, ptovta, num_fact, fecha, id_cliente, razon, direccion, localidad, tipocontr, cuit, total, observaciones) " &
                "VALUES (@tipofact, @ptov, @nfac, @fech, @idclie, @razon, @dire, @loca, @tipocont, @cuit, @tot, @observa)"

            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(sqlCabecera, GestorConexiones.conexionPrinc)
                cmd.Parameters.AddWithValue("@tipofact", datos.TipoFac)
                cmd.Parameters.AddWithValue("@ptov", datos.PtoVta)
                cmd.Parameters.AddWithValue("@nfac", datos.NumRecibo)
                cmd.Parameters.AddWithValue("@fech", datos.Fecha)
                cmd.Parameters.AddWithValue("@idclie", datos.CtaClie)
                cmd.Parameters.AddWithValue("@razon", datos.RazonSocial)
                cmd.Parameters.AddWithValue("@dire", datos.Direccion)
                cmd.Parameters.AddWithValue("@loca", datos.Localidad)
                cmd.Parameters.AddWithValue("@tipocont", datos.TipoContr)
                cmd.Parameters.AddWithValue("@cuit", datos.CUIT)
                cmd.Parameters.AddWithValue("@tot", datos.Total)
                cmd.Parameters.AddWithValue("@observa", observacionesVenta)
                cmd.ExecuteNonQuery()
                idReciboGenerado = CInt(cmd.LastInsertedId)
            End Using

            ' B. INSERTAR DATOS TARJETA (Solo si es Tarjeta)
            If datos.EsTarjeta Then
                Dim sqlTarjeta As String = "INSERT INTO fact_tarjetas (fecha, nombre, autorizacion, cliente, importe, comprobante) " &
                                           "VALUES (@fecha, @nombre, @autorizacion, @cliente, @importe, @comprobante)"
                Using cmdT As New MySql.Data.MySqlClient.MySqlCommand(sqlTarjeta, GestorConexiones.conexionPrinc)
                    cmdT.Parameters.AddWithValue("@fecha", datos.Fecha)
                    cmdT.Parameters.AddWithValue("@nombre", datos.TarjetaNombre)
                    cmdT.Parameters.AddWithValue("@autorizacion", datos.TarjetaAutorizacion)
                    cmdT.Parameters.AddWithValue("@cliente", datos.CtaClie)
                    cmdT.Parameters.AddWithValue("@importe", datos.Total)
                    cmdT.Parameters.AddWithValue("@comprobante", idReciboGenerado)
                    cmdT.ExecuteNonQuery()
                End Using
            End If

            ' C. ACTUALIZAR CORRELATIVO
            Dim sqlConf As String = "UPDATE fact_conffiscal SET confnume=@num WHERE donfdesc=@tipo AND ptovta=@ptov"
            Using cmdConf As New MySql.Data.MySqlClient.MySqlCommand(sqlConf, GestorConexiones.conexionPrinc)
                cmdConf.Parameters.AddWithValue("@num", datos.NumRecibo)
                cmdConf.Parameters.AddWithValue("@tipo", datos.TipoFac)
                cmdConf.Parameters.AddWithValue("@ptov", datos.PtoVta)
                cmdConf.ExecuteNonQuery()
            End Using

            ' D. ACTUALIZAR CUENTA CLIENTE
            Dim sqlCta As String = "UPDATE fact_cuentaclie SET pago=1 WHERE id=@idCta"
            Using cmdCta As New MySql.Data.MySqlClient.MySqlCommand(sqlCta, GestorConexiones.conexionPrinc)
                cmdCta.Parameters.AddWithValue("@idCta", datos.IdFacturaCTA)
                cmdCta.ExecuteNonQuery()
            End Using

            ' E. ACTUALIZAR OBSERVACIONES DE LA FACTURA ORIGEN
            Dim numRboStr As String = "RBO " & CompletarCeros(datos.PtoVta, 2) & "-" & CompletarCeros(datos.NumRecibo, 1)
            Dim sqlFacOrigen As String = "UPDATE fact_facturas SET observaciones2=@obs WHERE id=@idComp"
            Using cmdObs As New MySql.Data.MySqlClient.MySqlCommand(sqlFacOrigen, GestorConexiones.conexionPrinc)
                cmdObs.Parameters.AddWithValue("@obs", numRboStr)
                cmdObs.Parameters.AddWithValue("@idComp", datos.IdFacturaComp)
                cmdObs.ExecuteNonQuery()
            End Using

            ' F. INSERTAR ÍTEM GENÉRICO PARA EL RECIBO
            Dim sqlItem As String = "INSERT INTO fact_items (cod, descripcion, ptotal, tipofact, idAlmacen, idCaja, id_fact) " &
                                    "VALUES ('0', @desc, @ptot, @tipofact, @idAlmacen, @idCaja, @id_fact)"
            Using cmdItm As New MySql.Data.MySqlClient.MySqlCommand(sqlItem, GestorConexiones.conexionPrinc)
                cmdItm.Parameters.AddWithValue("@desc", numRboStr)
                cmdItm.Parameters.AddWithValue("@ptot", datos.Total)
                cmdItm.Parameters.AddWithValue("@tipofact", datos.TipoFac)
                cmdItm.Parameters.AddWithValue("@idAlmacen", datos.IdAlmacen)
                cmdItm.Parameters.AddWithValue("@idCaja", datos.IdCaja)
                cmdItm.Parameters.AddWithValue("@id_fact", idReciboGenerado)
                cmdItm.ExecuteNonQuery()
            End Using

            ' G. ACTUALIZAR MOVIMIENTO DE CAJA
            Dim sqlCaja As String = "INSERT INTO fact_ingreso_egreso (concepto, monto, comprobante, caja, tipo) " &
                                    "VALUES ('1', @monto, @comp, @caja, '1')"
            Using cmdCaja As New MySql.Data.MySqlClient.MySqlCommand(sqlCaja, GestorConexiones.conexionPrinc)
                cmdCaja.Parameters.AddWithValue("@monto", datos.Total)
                cmdCaja.Parameters.AddWithValue("@comp", idReciboGenerado)
                cmdCaja.Parameters.AddWithValue("@caja", datos.IdCaja)
                cmdCaja.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            MsgBox("Error en GestorFacturacion al guardar pago: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function
    Public Shared Function ObtenerProximoNumeroComprobante(tipoFactura As Integer, puntoVenta As Integer) As Integer
        Try
            Reconectar()
            Dim query As String = "SELECT confnume FROM fact_conffiscal WHERE donfdesc = @tipofact AND ptovta = @ptov LIMIT 1"

            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, GestorConexiones.conexionPrinc)
                cmd.Parameters.AddWithValue("@tipofact", tipoFactura)
                cmd.Parameters.AddWithValue("@ptov", puntoVenta)

                Dim resultado As Object = cmd.ExecuteScalar()

                If resultado IsNot Nothing AndAlso Not DBNull.Value.Equals(resultado) Then
                    ' Retorna el último número usado + 1
                    Return Convert.ToInt32(resultado) + 1
                End If
            End Using

            ' Si por algún motivo no existe el registro en la tabla, arranca en 1
            Return 1
        Catch ex As Exception
            MsgBox("Error al obtener el número de comprobante: " & ex.Message, MsgBoxStyle.Critical)
            Return 0
        End Try
    End Function
    Public Shared Function GuardarFacturaCompleta(factura As factNuevaFactura_Datos) As Boolean
        Dim idComprobante As Integer = 0
        Try

            'MsgBox(factura.fecha & "------>>" & Format(CDate(factura.fecha.ToString), "yyyy-MM-dd"))
            ' 1. Guardamos la Cabecera (fact_facturas)
            Dim sqlCabecera As String = "INSERT INTO fact_facturas " &
                "(tipofact, ptovta, num_fact, fecha, id_cliente, razon, direccion, localidad, tipocontr, cuit, " &
                "condvta, subtotal, iva105, iva21, otroiva, total, vendedor, observaciones2, cae, vtocae, codbarra, observaciones, codigo_qr) " &
                "VALUES " &
                "(@tipofact, @ptov, @nfac, @fech, @idclie, @razon, @dire, @loca, @tipocont, @cuit, " &
                "@condvta, @subt, @105, @21, @otroiva, @tot, @vend, @obs2, @cae, @vtocae, @codbarra, @obs, @qr)"

            Using comando As New MySqlCommand(sqlCabecera, GestorConexiones.conexionPrinc)
                With comando.Parameters
                    .AddWithValue("@tipofact", factura.tipofact.id)
                    .AddWithValue("@ptov", factura.ptovta.id)
                    .AddWithValue("@nfac", factura.num_fact)
                    .AddWithValue("@fech", factura.fecha)
                    .AddWithValue("@idclie", factura.cliente.idCliente)
                    .AddWithValue("@razon", factura.cliente.nomapellRazon)
                    .AddWithValue("@dire", factura.cliente.dirDomicilio)
                    .AddWithValue("@loca", factura.cliente.dirLocalidad.nombre)
                    .AddWithValue("@tipocont", factura.cliente.ivaTipo.nombre)
                    .AddWithValue("@cuit", factura.cliente.cuit)
                    .AddWithValue("@condvta", factura.condvta.id)
                    .AddWithValue("@subt", factura.subtotal)
                    .AddWithValue("@105", factura.iva105)
                    .AddWithValue("@21", factura.iva21)
                    .AddWithValue("@otroiva", factura.otroiva)
                    .AddWithValue("@tot", factura.total)
                    .AddWithValue("@vend", factura.vendedor.id)
                    .AddWithValue("@obs2", factura.observaciones2)
                    .AddWithValue("@cae", factura.cae)
                    .AddWithValue("@vtocae", factura.vtocae)
                    .AddWithValue("@codbarra", factura.codbarra)
                    .AddWithValue("@obs", factura.observaciones)
                    .AddWithValue("@qr", factura.codigo_qr)
                End With
                comando.ExecuteNonQuery()
                ' Recuperamos el ID recién insertado y se lo asignamos al objeto
                idComprobante = comando.LastInsertedId
                factura.IdDevuelto = idComprobante
            End Using

            ' 2. Actualizamos el numerario (si no es electrónica)
            ' If factura.ptovta.id <> FacturaElectro.puntovtaelect Then
            Dim sqlNum As String = "UPDATE fact_conffiscal SET confnume=@nfac WHERE donfdesc=@tipofact AND ptovta=@ptov"
                Using cmdUpd As New MySqlCommand(sqlNum, GestorConexiones.conexionPrinc)
                    cmdUpd.Parameters.AddWithValue("@nfac", factura.num_fact)
                    cmdUpd.Parameters.AddWithValue("@tipofact", factura.tipofact.id)
                    cmdUpd.Parameters.AddWithValue("@ptov", factura.ptovta.id)
                    cmdUpd.ExecuteNonQuery()
                End Using
            ' End If

            ' 3. Guardamos los Ítems (fact_items)
            Dim sqlItem As String = "INSERT INTO fact_items " &
                "(cod, plu, cantidad, descripcion, iva, punit, ptotal, tipofact, idAlmacen, idCaja, id_fact, impuestoFijo01, impuestoFijo02) " &
                "VALUES (@cod, @plu, @cant, @desc, @iva, @punit, @ptot, @tipofact, @idAlmacen, @idCaja, @id_fact, @idc, @icl)"

            For Each item As factNuevaFactura_Items In factura.Items
                item.id_fact = idComprobante
                Using cmdItem As New MySqlCommand(sqlItem, GestorConexiones.conexionPrinc)
                    With cmdItem.Parameters
                        .AddWithValue("@cod", item.cod)
                        .AddWithValue("@plu", item.plu)
                        .AddWithValue("@cant", item.cantidad)
                        .AddWithValue("@desc", item.descripcion)
                        .AddWithValue("@iva", item.iva)
                        .AddWithValue("@punit", item.punit)
                        .AddWithValue("@ptot", item.ptotal)
                        .AddWithValue("@tipofact", factura.tipofact.id)
                        .AddWithValue("@idAlmacen", item.Almacen.id)
                        .AddWithValue("@idCaja", item.idCaja)
                        .AddWithValue("@id_fact", item.id_fact) ' El ID que recuperamos arriba
                        .AddWithValue("@idc", item.impuestoFijo01)
                        .AddWithValue("@icl", item.impuestoFijo02)
                    End With
                    cmdItem.ExecuteNonQuery()
                End Using

            Next

            ' ==========================================
            ' INTEGRACIÓN GENERAL Y CABECERA
            ' ==========================================

            ' A. HISTORIAL DEL CLIENTE (Cuenta Corriente)
            Dim sqlCuentaClie As String = "INSERT INTO fact_cuentaclie (idclie, idcomp) VALUES (@idclie, @idcomp)"
            Using cmdCta As New MySqlCommand(sqlCuentaClie, GestorConexiones.conexionPrinc)
                cmdCta.Parameters.AddWithValue("@idclie", factura.cliente.idCliente)
                cmdCta.Parameters.AddWithValue("@idcomp", idComprobante)
                cmdCta.ExecuteNonQuery()
            End Using

            ' B. ACTUALIZAR PEDIDOS (Si había alguno)
            If Not String.IsNullOrEmpty(factura.listaPedidos) Then
                Dim sqlPedidos As String = "UPDATE fact_facturas SET observaciones ='FACTURADO' WHERE tipofact=995 AND id IN (" & factura.listaPedidos & ")"
                Using cmdPed As New MySqlCommand(sqlPedidos, GestorConexiones.conexionPrinc)
                    cmdPed.ExecuteNonQuery()
                End Using
            End If

            ' ==========================================
            ' ITERACIÓN PARA SUBSISTEMAS (Por cada ítem)
            ' ==========================================
            Dim esNotaCredito As Boolean = (factura.tipofact.id = 3 Or factura.tipofact.id = 8 Or factura.tipofact.id = 13 Or factura.tipofact.id = 991)
            Dim idComprobanteDev As Integer = 0

            ' Si descuenta stock y es Nota de Crédito, preparamos la cabecera de devolución (proveedores)
            If factura.descontarStock AndAlso esNotaCredito Then
                Dim sqlDev As String = "INSERT INTO fact_proveedores_fact (fecha, tipo, numero, idproveedor) VALUES (@fech, 'DEV', 'DEV-MERCADERIA', 1)"
                Using cmdDev As New MySqlCommand(sqlDev, GestorConexiones.conexionPrinc)
                    cmdDev.Parameters.AddWithValue("@fech", factura.fecha)
                    cmdDev.ExecuteNonQuery()
                    idComprobanteDev = cmdDev.LastInsertedId
                End Using
            End If

            For Each item As factNuevaFactura_Items In factura.Items
                '¿ MsgBox("MODULO DE STOCK")
                ' 1. MÓDULO DE STOCK (Lotes FIFO)
                If factura.descontarStock Then
                    If esNotaCredito Then
                        ' Reingreso de mercadería
                        ' MsgBox("REINGRESO DE MERCADERIA")
                        GestorInsumos.GuardarStockProducto(idComprobanteDev, item.id, item.cantidad, factura.Almacen.id)
                    Else
                        'MsgBox("DESCUENTO DE MERCADERIA>: " & (item.id & "-->" & item.cantidad & "-->" & factura.Almacen.id))
                        ' Descuento de mercadería (Llamá a un método externo para no ensuciar acá)
                        GestorInsumos.DescontarStockPorLotes(item.id, item.cantidad, factura.Almacen.id)
                    End If
                End If

                ' 2. MÓDULO DE PRODUCCIÓN (Empieza con 00)
                If item.plu.StartsWith("00") Then
                    Dim sqlProd As String = "UPDATE fact_insumos_produccion SET facturado=1, fecha_venta=@fech WHERE codigobarras=@codbar"
                    Using cmdProd As New MySqlCommand(sqlProd, GestorConexiones.conexionPrinc)
                        cmdProd.Parameters.AddWithValue("@fech", factura.fecha)
                        cmdProd.Parameters.AddWithValue("@codbar", item.plu)
                        cmdProd.ExecuteNonQuery()
                    End Using
                End If

                ' 3. MÓDULO DE TALLER (Descripción empieza con &)
                If item.descripcion.StartsWith("&") Then
                    ' Le saca el primer caracter y lo convierte a ID
                    Dim idTrab As Integer
                    If Integer.TryParse(item.descripcion.Substring(1), idTrab) Then
                        Dim sqlTaller As String = "UPDATE tecni_taller SET trab_estado=1, factura=@idFac WHERE id=@idT"
                        Using cmdTaller As New MySqlCommand(sqlTaller, GestorConexiones.conexionPrinc)
                            cmdTaller.Parameters.AddWithValue("@idFac", idComprobante)
                            cmdTaller.Parameters.AddWithValue("@idT", idTrab)
                            cmdTaller.ExecuteNonQuery()
                        End Using
                    End If
                End If

                ' 4. MÓDULO DE CURSOS (CTA-xxx)
                If item.plu.StartsWith("CTA-") Then
                    Dim idCuota As Integer
                    If Integer.TryParse(item.plu.Replace("CTA-", ""), idCuota) Then
                        serv_detalle.ActualizarEstado(idCuota, "FACTURADA")
                    End If
                End If

                ' 5. MÓDULO DE PUBLICIDAD (#Prestamo-Cuota)
                If item.plu.StartsWith("#") AndAlso item.plu.Contains("-") Then
                    Try
                        Dim partes() As String = item.plu.Replace("#", "").Split("-"c)
                        If partes.Length = 2 Then
                            GestorPublicidad.VincularComprobanteAutomatico(Convert.ToInt32(partes(1)), idComprobante, False)
                        End If
                    Catch ex As Exception
                        Debug.WriteLine("Error Publicidad: " & ex.Message)
                    End Try
                End If
            Next

            ' C. ASIENTOS CONTABLES (Si se especificó una cuenta)
            If factura.cuentaContable > 0 Then
                ' Llama a tu función contable usando factura.CuentaContable, factura.total, etc.
                ' GuardarAsientoContable(....)
            End If



            Return True
        Catch ex As Exception
            ' ==========================================
            ' ROLLBACK MANUAL PARA MYISAM
            ' ==========================================
            If idComprobante > 0 Then
                Try
                    ' 1. Borramos los ítems huérfanos
                    Dim sqlBorrarItems As String = "DELETE FROM fact_items WHERE id_fact = @id_fact"
                    Using cmdLimpItems As New MySqlCommand(sqlBorrarItems, GestorConexiones.conexionPrinc)
                        cmdLimpItems.Parameters.AddWithValue("@id_fact", idComprobante)
                        cmdLimpItems.ExecuteNonQuery()
                    End Using

                    ' 2. Borramos la cabecera truncada
                    ' OJO ACA: Asumo que la PK de fact_facturas se llama 'id'. Si se llama distinto, cambialo.
                    Dim sqlBorrarCab As String = "DELETE FROM fact_facturas WHERE id = @id"
                    Using cmdLimpCab As New MySqlCommand(sqlBorrarCab, GestorConexiones.conexionPrinc)
                        cmdLimpCab.Parameters.AddWithValue("@id", idComprobante)
                        cmdLimpCab.ExecuteNonQuery()
                    End Using

                Catch exLimpieza As Exception
                    ' Si llega a fallar también la limpieza (ej. se cortó la red de golpe), avisamos
                    MsgBox("ATENCIÓN: Falló el guardado y no se pudieron limpiar los datos incompletos. ID afectado: " & idComprobante & vbCrLf & exLimpieza.Message, MsgBoxStyle.Critical, "Alerta de Datos")
                End Try
            End If

            MsgBox("Se produjo un error al guardar. Se han revertido los datos para evitar inconsistencias." & vbCrLf & vbCrLf & "Detalle: " & ex.Message, MsgBoxStyle.Exclamation, "Proceso cancelado")
            Return False
        End Try
    End Function
    Public Shared Function ObtenerFechaFacturaElectro(numFac As Integer, tipoFac As Integer) As String
        Try
            Reconectar()
            Dim query As String = "SELECT REPLACE(fecha, '-', '') FROM fact_facturas WHERE tipofact = @tipofact AND num_fact = @numfac LIMIT 1"

            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, GestorConexiones.conexionPrinc)
                cmd.Parameters.AddWithValue("@tipofact", tipoFac)
                cmd.Parameters.AddWithValue("@numfac", numFac)

                Dim resultado As Object = cmd.ExecuteScalar()

                If resultado IsNot Nothing AndAlso Not DBNull.Value.Equals(resultado) Then
                    Return resultado.ToString()
                End If
            End Using

            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ' 2. MÉTODO PARA BUSCAR EL PEDIDO LIMPIO (En GestorFacturacion)
    Public Shared Function ObtenerPedidoParaFacturar(numPedido As Integer, ptoVtaPedido As Integer) As DatosPedidoFacturar
        Dim pedido As New DatosPedidoFacturar()
        Try
            Reconectar()

            ' A. BUSCAR CABECERA DEL PEDIDO (Tipo 995)
            Dim sqlCabecera As String = "SELECT id, id_cliente, condVta, vendedor FROM fact_facturas WHERE observaciones LIKE 'PENDIENTE' AND ptovta=@ptovta AND num_fact=@numfact AND tipofact=995"
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(sqlCabecera, GestorConexiones.conexionPrinc)
                cmd.Parameters.AddWithValue("@ptovta", ptoVtaPedido)
                cmd.Parameters.AddWithValue("@numfact", numPedido)

                Using dr As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        pedido.IdPedido = Convert.ToInt32(dr("id"))
                        pedido.IdCondVta = Convert.ToInt32(dr("condVta"))
                        pedido.IdVendedor = Convert.ToInt32(dr("vendedor"))
                        pedido.IdCliente = Convert.ToInt32(dr("id_cliente"))

                    Else
                        Return Nothing ' No se encontró o ya está facturado
                    End If
                End Using
            End Using

            ' B. BUSCAR ÍTEMS DEL PEDIDO
            Dim sqlItems As String = "SELECT cod, codint, cantidad, descripcion, iva, punit, ptotal FROM fact_items WHERE id_fact=@idPedido"
            Using cmdItm As New MySql.Data.MySqlClient.MySqlCommand(sqlItems, GestorConexiones.conexionPrinc)
                cmdItm.Parameters.AddWithValue("@idPedido", pedido.IdPedido)
                Using drItm As MySql.Data.MySqlClient.MySqlDataReader = cmdItm.ExecuteReader()
                    While drItm.Read()
                        Dim item As New DatosItemPedido With {
                            .Codigo = drItm("cod").ToString(),
                            .CodInt = drItm("codint").ToString(),
                            .Cantidad = Convert.ToDecimal(drItm("cantidad")),
                            .Descripcion = drItm("descripcion").ToString(),
                            .Iva = Convert.ToDecimal(drItm("iva")),
                            .PUnit = Convert.ToDecimal(drItm("punit")),
                            .PTotal = Convert.ToDecimal(drItm("ptotal"))
                        }
                        pedido.Items.Add(item)
                    End While
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine("Error al cargar pedido: " & ex.Message)
            Return Nothing
        End Try

        Return pedido
    End Function
End Class
