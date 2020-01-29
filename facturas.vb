Public Class facturas

    Private Sub facturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub cargar_facturas()
        Try
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select fac.id, " _
            & "concat(lpad(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as pedidonum,fac.fecha,fac.razon,fac.direccion, fac.localidad, con.condicion, fac.total, fac.observaciones as estado " _
            & "from fact_facturas as fac, fact_condventas as con where con.id=fac.condvta and fac.tipofact=9", conexionPrinc)
            Dim tablaped As New DataTable
            consulta.Fill(tablaped)

            dtfacturas.DataSource = tablaped
            dtfacturas.Columns(0).Visible = False
        Catch ex As Exception

        End Try
    End Sub
End Class