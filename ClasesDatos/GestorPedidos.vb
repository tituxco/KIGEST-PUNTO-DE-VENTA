Imports MySql.Data.MySqlClient
Imports SIGT__KIGEST.GestorFacturacion ' Para reutilizar los DTOs como factNuevaFactura_Datos si aplica

Public Class GestorPedidos

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
    ' =========================================================================
    ' 1. OBTENER LISTADO DE PEDIDOS (Optimizado y parametrizado)
    ' =========================================================================
    Public Shared Function ObtenerListadoPedidos(desde As Date, hasta As Date, idVendedor As Integer, busqCliente As String, filtroEstado As String) As DataTable
        Dim tabla As New DataTable()

        Try
            Dim sql As New System.Text.StringBuilder()
            sql.Append("SELECT fac.id, ")
            sql.Append("CONCAT(LPAD(fac.ptovta, 4, '0'), '-', LPAD(fac.num_fact, 8, '0')) AS pedidonum, ")
            sql.Append("DATE_FORMAT(fac.fecha, '%d-%m-%Y') AS fecha_formateada, ")
            sql.Append("IF(fac.id_cliente = 9999, CONCAT(fac.id_cliente, '(', fac.razon, ')'), CONCAT(fac.id_cliente, '(', cli.nomapell_razon, ')')) AS razon, ")
            sql.Append("cli.dir_domicilio AS direccion, ")
            sql.Append("loc.nombre AS localidad, ")
            sql.Append("con.condicion, ")
            sql.Append("FORMAT(fac.total, 2, 'es_AR') AS total, ")
            sql.Append("fac.observaciones AS estado, ")
            sql.Append("fac.observaciones2 AS observaciones, ")
            sql.Append("fac.f_alta AS FEnviado ")
            sql.Append("FROM fact_facturas AS fac ")
            sql.Append("INNER JOIN fact_condventas AS con ON con.id = fac.condvta ")
            sql.Append("INNER JOIN fact_clientes AS cli ON cli.idclientes = fac.id_cliente ")
            sql.Append("LEFT JOIN cm_localidad AS loc ON loc.id = cli.dir_localidad ")
            sql.Append("WHERE fac.tipofact = 995 AND fac.fecha BETWEEN @desde AND @hasta ")

            ' Filtros dinámicos
            If idVendedor > 0 Then sql.Append("AND fac.vendedor = @vendedor ")
            If Not String.IsNullOrWhiteSpace(busqCliente) Then sql.Append("AND fac.razon LIKE @busqCliente ")

            Select Case filtroEstado
                Case "PENDIENTE"
                    sql.Append("AND fac.observaciones = 'PENDIENTE' ")
                Case "FACTURADO"
                    sql.Append("AND fac.observaciones = 'FACTURADO' ")
                Case "IMPORTAR"
                    sql.Append("AND fac.observaciones NOT IN ('FACTURADO', 'PENDIENTE') ")
            End Select

            sql.Append("ORDER BY fac.id ASC")

            Using conexion As New MySqlConnection(CadenaConexion)
                conexion.Open()
                Using cmd As New MySqlCommand(sql.ToString(), conexion)
                    cmd.Parameters.AddWithValue("@desde", desde.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@hasta", hasta.ToString("yyyy-MM-dd"))
                    If idVendedor > 0 Then cmd.Parameters.AddWithValue("@vendedor", idVendedor)
                    If Not String.IsNullOrWhiteSpace(busqCliente) Then cmd.Parameters.AddWithValue("@busqCliente", "%" & busqCliente & "%")

                    Using adapter As New MySqlDataAdapter(cmd)
                        adapter.Fill(tabla)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error al obtener los pedidos: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        Return tabla
    End Function

    ' =========================================================================
    ' 2. ELIMINAR PEDIDO (Con transacción de seguridad)
    ' =========================================================================
    Public Shared Function EliminarPedido(idPedido As Integer, modoImportacion As Boolean, codIntImportacion As String) As Boolean
        Try
            Using conexion As New MySqlConnection(CadenaConexion)
                conexion.Open()

                Try
                    Using cmd As New MySqlCommand()
                        cmd.Connection = conexion
                        ' Eliminar ítems
                        If modoImportacion Then
                            cmd.CommandText = "DELETE FROM fact_items WHERE codint LIKE @codint"
                            cmd.Parameters.AddWithValue("@codint", codIntImportacion)
                        Else
                            cmd.CommandText = "DELETE FROM fact_items WHERE id_fact = @idPedido"
                            cmd.Parameters.AddWithValue("@idPedido", idPedido)
                        End If
                        cmd.ExecuteNonQuery()

                        ' Eliminar cabecera
                        cmd.CommandText = "DELETE FROM fact_facturas WHERE id = @idPedidoCab"
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@idPedidoCab", idPedido)
                        cmd.ExecuteNonQuery()

                    End Using
                    Return True
                Catch ex As Exception
                    Throw New Exception("Error durante la eliminación transaccional: " & ex.Message)
                End Try
            End Using
        Catch ex As Exception
        MsgBox("Error al eliminar: " & ex.Message, MsgBoxStyle.Critical)
        Return False
        End Try
    End Function

End Class