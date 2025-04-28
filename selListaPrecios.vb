Public Class selListaPrecios
    Private Sub selListaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_listas_precio", conexionPrinc)
            Dim tablalistas As New DataTable
            consulta.Fill(tablalistas)
            dtlistas.DataSource = tablalistas
            dtlistas.Columns(2).Visible = False
            dtlistas.Columns(3).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtlistas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtlistas.CellDoubleClick
        Try
            CType(frmprincipal.ActiveMdiChild, puntoventa).listaPrecios = dtlistas.CurrentRow.Cells(0).Value
            CType(frmprincipal.ActiveMdiChild, puntoventa).lblfactlistaprecios.Text = dtlistas.CurrentRow.Cells(1).Value
            CType(frmprincipal.ActiveMdiChild, puntoventa).RecalcularPreciosLista()
            CType(frmprincipal.ActiveMdiChild, puntoventa).txtcodPLU.Focus()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtlistas_KeyDown(sender As Object, e As KeyEventArgs) Handles dtlistas.KeyDown
        If e.KeyCode = Keys.Enter Then
            CType(frmprincipal.ActiveMdiChild, puntoventa).listaPrecios = dtlistas.CurrentRow.Cells(0).Value
            CType(frmprincipal.ActiveMdiChild, puntoventa).lblfactlistaprecios.Text = dtlistas.CurrentRow.Cells(1).Value
            CType(frmprincipal.ActiveMdiChild, puntoventa).RecalcularPreciosLista()
            CType(frmprincipal.ActiveMdiChild, puntoventa).txtcodPLU.Focus()

            Me.Close()
        End If
    End Sub

    Private Sub dtlistas_KeyUp(sender As Object, e As KeyEventArgs) Handles dtlistas.KeyUp

    End Sub

    Private Sub dtlistas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtlistas.KeyPress

    End Sub
End Class