Public Class selListaPrecios
    Dim listaPrecios As List(Of
    datosEstructura.fact_listaPrecios)
    Public llama As String
    Private Sub selListaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            listaPrecios = datosEstructura.fact_listaPrecios.ObtenerTodos
            dtlistas.DataSource = listaPrecios
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtlistas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtlistas.CellDoubleClick
        Try
            Select Case llama
                Case "ptovta"
                    CType(frmprincipal.ActiveMdiChild, puntoventa).listaPrecios = dtlistas.CurrentRow.Cells(0).Value
                    CType(frmprincipal.ActiveMdiChild, puntoventa).lblfactlistaprecios.Text = dtlistas.CurrentRow.Cells(1).Value
                    CType(frmprincipal.ActiveMdiChild, puntoventa).RecalcularPreciosLista()
                    CType(frmprincipal.ActiveMdiChild, puntoventa).txtcodPLU.Focus()
                    Me.Close()
                Case "ptovtaNvo"
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).facturaListaPrecios = CType(dtlistas.CurrentRow.DataBoundItem, datosEstructura.fact_listaPrecios)
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).CargarDatosListaPrecios()
                    Me.Close()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtlistas_KeyDown(sender As Object, e As KeyEventArgs) Handles dtlistas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case llama
                Case "ptovta"
                    CType(frmprincipal.ActiveMdiChild, puntoventa).listaPrecios = dtlistas.CurrentRow.Cells(0).Value
                    CType(frmprincipal.ActiveMdiChild, puntoventa).lblfactlistaprecios.Text = dtlistas.CurrentRow.Cells(1).Value
                    CType(frmprincipal.ActiveMdiChild, puntoventa).RecalcularPreciosLista()
                    CType(frmprincipal.ActiveMdiChild, puntoventa).txtcodPLU.Focus()
                    Me.Close()
                Case "ptovtaNvo"
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).facturaListaPrecios = CType(dtlistas.CurrentRow.DataBoundItem, datosEstructura.fact_listaPrecios)
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).CargarDatosListaPrecios()
                    Me.Close()
            End Select

        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub dtlistas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtlistas.CellContentClick

    End Sub
End Class