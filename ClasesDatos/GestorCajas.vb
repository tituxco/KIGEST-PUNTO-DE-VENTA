Public Class GestorCajas
    Public Class fact_cajas
        Public Property id As Integer
        Public Property descripcion As String
    End Class

    Public Class fact_cajas_cierres
        Public Property id As Integer
        Public Property fecha As DateTime
        Public Property monto As String
        Public Property caja As Integer
    End Class

    Public Shared Function ObtenerCajaActualDefecto() As Integer
        Try
            ' Si usás una configuración local por defecto
            If My.Settings.CajaDef > 0 Then
                Return My.Settings.CajaDef
            End If

            ' O por defecto devolvemos 1
            Return 1
        Catch ex As Exception
            Return 1
        End Try
    End Function

    Public Shared Function RegistrarCierreCaja(monto As Decimal, numeroCaja As Integer) As Boolean
        Try
            Reconectar()
            Dim query As String = "INSERT INTO fact_cajas_cierres (monto, caja) VALUES (@monto, @caja)"

            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, GestorConexiones.conexionPrinc)
                cmd.Parameters.AddWithValue("@monto", monto.ToString(System.Globalization.CultureInfo.InvariantCulture))
                cmd.Parameters.AddWithValue("@caja", numeroCaja)
                cmd.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            MsgBox("Error al registrar cierre de caja: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

End Class