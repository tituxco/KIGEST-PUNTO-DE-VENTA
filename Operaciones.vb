Module Operaciones

    Public Function Calculacuota(ByVal Monto As Double, ByVal TasaAnual As Double, ByVal Plazo As Integer)
        Dim CuotaPagar As Double = 0
        Dim Periodo As Double = 0
        Dim R As Double
        Dim Interes As Double = 0
        TasaAnual = TasaAnual / 100

        Periodo = 12
        Interes = CDbl(TasaAnual) / 100 / 12

        R = (1 + TasaAnual / Periodo)



        If TasaAnual = 0 Then
            CuotaPagar = Monto / Plazo
        Else
            CuotaPagar = Monto * (R - 1) / (1 - R ^ (-Plazo))
        End If

        Return CuotaPagar
    End Function


    Public Sub Guardar(ByVal Cadena As String, ByVal Fecha As Date)
        Reconectar()
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand(Cadena, conexionPrinc)
        cmd.Parameters.Add("@fecha", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Fecha
        cmd.ExecuteNonQuery()
    End Sub

    Public Sub Eliminar(ByVal Cadena As String)
        Reconectar()
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand(Cadena, conexionPrinc)
        cmd.ExecuteNonQuery()
    End Sub
End Module
