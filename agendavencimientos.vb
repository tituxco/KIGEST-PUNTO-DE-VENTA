Public Class agendavencimientos
    Public Shared Function ObtenerPrimerDiaSemana(diaSemana As DateTime) As DateTime

        Dim primerDiaSemana As DateTime = diaSemana.Date
        While primerDiaSemana.DayOfWeek <> DayOfWeek.Monday
            primerDiaSemana = primerDiaSemana.AddDays(-1)
        End While

        Return primerDiaSemana

    End Function
    Public Shared Function ObtenerUltimoDiaSemanahabil(diaSemana As DateTime) As DateTime

        Dim primerDiaSemana As DateTime = diaSemana.Date
        While primerDiaSemana.DayOfWeek <> DayOfWeek.Friday
            primerDiaSemana = primerDiaSemana.AddDays(+1)
        End While

        Return primerDiaSemana

    End Function
    Private Sub CargarFacturasProveedor()
        Dim monto As Double = 0
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select proveedor, comprobante, vencimiento, monto from facturasproveedores_impagas " _
            & " where vencimiento between '" & Format(CDate(dtpdesde.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(dtphasta.Value), "yyyy-MM-dd") & "' ", conexionPrinc)

            Dim tablaPers As New DataTable
            consulta.Fill(tablaPers)
            dtagendafacturas.DataSource = tablaPers
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        For Each facturas As DataGridViewRow In dtagendafacturas.Rows
            monto += facturas.Cells(3).Value
        Next
        lbltotalfacturas.Text = "Total de facturas a vencer: $ " & monto

    End Sub
    Private Sub CargarchequesVencimiento()
        Dim monto As Double = 0
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from vencimiento_cheques " _
            & " where fecha_cobro between '" & Format(CDate(dtpdesde.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(dtphasta.Value), "yyyy-MM-dd") & "' ", conexionPrinc)

            Dim tablaPers As New DataTable
            consulta.Fill(tablaPers)
            dtagendachequesterceros.DataSource = tablaPers
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        For Each facturas As DataGridViewRow In dtagendachequesterceros.Rows
            monto += facturas.Cells(4).Value
        Next
        lbltotalchequesterceros.Text = "Total de cheques de terceros a cobrar: $ " & monto

    End Sub

    Private Sub CargarchequespropiosVencimiento()
        Dim monto As Double = 0
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from vencimiento_cheques " _
            & " where fecha_cobro between '" & Format(CDate(dtpdesde.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(dtphasta.Value), "yyyy-MM-dd") & "' ", conexionPrinc)

            Dim tablaPers As New DataTable
            consulta.Fill(tablaPers)
            dtagendachequesterceros.DataSource = tablaPers
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        For Each facturas As DataGridViewRow In dtagendachequesterceros.Rows
            monto += facturas.Cells(4).Value
        Next
        lbltotalchequesterceros.Text = "Total de cheques de terceros a cobrar: $ " & monto

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        CargarchequesVencimiento()
        CargarFacturasProveedor()
    End Sub

    Private Sub agendavencimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim diaViernes As DateTime = ObtenerUltimoDiaSemanahabil(Convert.ToDateTime(Now))
        dtphasta.Value = diaViernes
        CargarFacturasProveedor()
        CargarchequesVencimiento()
    End Sub
End Class