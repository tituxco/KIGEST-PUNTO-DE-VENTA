Public Class selCondVta
    Dim listaCondVta As List(Of
    datosEstructura.fact_condventas)
    Public llama As String
    Private Sub selCondVta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            listaCondVta = datosEstructura.fact_condventas.ObtenerTodos
            dtCondVtas.DataSource = listaCondVta
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtCondVtas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtCondVtas.CellContentClick

    End Sub

    Private Sub dtCondVtas_DoubleClick(sender As Object, e As EventArgs) Handles dtCondVtas.DoubleClick
        Try
            Select Case llama
                Case "ptovta"

                Case "ptovtaNvo"
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).facturaCondicionVenta = CType(dtCondVtas.CurrentRow.DataBoundItem, datosEstructura.fact_condventas)
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).CargarDatosCondicionVenta()
                    Me.Close()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtCondVtas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtCondVtas.KeyPress

    End Sub

    Private Sub dtCondVtas_KeyDown(sender As Object, e As KeyEventArgs) Handles dtCondVtas.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case llama
                    Case "ptovta"

                    Case "ptovtaNvo"
                        CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).facturaCondicionVenta = CType(dtCondVtas.CurrentRow.DataBoundItem, datosEstructura.fact_condventas)
                        CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).CargarDatosCondicionVenta()
                        Me.Close()
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class