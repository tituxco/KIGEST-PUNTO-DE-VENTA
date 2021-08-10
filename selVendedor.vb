Public Class selVendedor

    Private Sub selVendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_vendedor where activo=1", conexionPrinc)
            Dim tablalistas As New DataTable
            consulta.Fill(tablalistas)
            dtvendedor.DataSource = tablalistas
            dtvendedor.Columns(2).Visible = False
            dtvendedor.Columns(3).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtvendedor_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtvendedor.CellDoubleClick
        Try
            CType(frmprincipal.ActiveMdiChild, puntoventa).listaPrecios = dtvendedor.CurrentRow.Cells(0).Value
            CType(frmprincipal.ActiveMdiChild, puntoventa).lblfactlistaprecios.Text = dtvendedor.CurrentRow.Cells(1).Value
            CType(frmprincipal.ActiveMdiChild, puntoventa).txtcodPLU.Focus()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtvendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles dtvendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            CType(frmprincipal.ActiveMdiChild, puntoventa).listaPrecios = dtvendedor.CurrentRow.Cells(0).Value
            CType(frmprincipal.ActiveMdiChild, puntoventa).lblfactlistaprecios.Text = dtvendedor.CurrentRow.Cells(1).Value
            CType(frmprincipal.ActiveMdiChild, puntoventa).txtcodPLU.Focus()
            Me.Close()
        End If
    End Sub
End Class