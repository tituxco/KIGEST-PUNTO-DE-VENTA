Public Class selVendedor
    Dim listaVendedor As List(Of
    datosEstructura.fact_vendedor)
    Public llama As String
    Private Sub selVendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            listaVendedor = datosEstructura.fact_vendedor.ObtenerTodos
            dtvendedor.DataSource = listaVendedor
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtvendedor_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtvendedor.CellDoubleClick
        Try
            Select Case llama
                Case "ptovta"
                    CType(frmprincipal.ActiveMdiChild, puntoventa).listaPrecios = dtvendedor.CurrentRow.Cells(0).Value
                    CType(frmprincipal.ActiveMdiChild, puntoventa).lblfactlistaprecios.Text = dtvendedor.CurrentRow.Cells(1).Value
                    CType(frmprincipal.ActiveMdiChild, puntoventa).txtcodPLU.Focus()
                    Me.Close()
                Case "ptovtaNvo"
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).facturaVendedor = CType(dtvendedor.CurrentRow.DataBoundItem, datosEstructura.fact_vendedor)
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).CargarDatosVendedor()
                    Me.Close()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtvendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles dtvendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Select Case llama
                    Case "ptovta"
                        CType(frmprincipal.ActiveMdiChild, puntoventa).listaPrecios = dtvendedor.CurrentRow.Cells(0).Value
                        CType(frmprincipal.ActiveMdiChild, puntoventa).lblfactlistaprecios.Text = dtvendedor.CurrentRow.Cells(1).Value
                        CType(frmprincipal.ActiveMdiChild, puntoventa).txtcodPLU.Focus()
                        Me.Close()
                    Case "ptovtaNvo"
                        CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).facturaVendedor = CType(dtvendedor.CurrentRow.DataBoundItem, datosEstructura.fact_vendedor)
                        CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).CargarDatosVendedor()
                        Me.Close()
                End Select

            Catch ex As Exception

            End Try
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class