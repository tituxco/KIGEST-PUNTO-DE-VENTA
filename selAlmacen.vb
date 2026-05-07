Public Class selAlmacen
    Dim listaAlmacen As List(Of
    datosEstructura.fact_insumos_almacenes)
    Public llama As String
    Private Sub selAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            listaAlmacen = datosEstructura.fact_insumos_almacenes.ObtenerTodos
            dtAlmacen.DataSource = listaAlmacen
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dtAlmacenes_DoubleClick(sender As Object, e As EventArgs) Handles dtAlmacen.DoubleClick
        Try
            Select Case llama
                Case "ptovta"

                Case "ptovtaNvo"
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).facturaAlmacen = CType(dtAlmacen.CurrentRow.DataBoundItem, datosEstructura.fact_insumos_almacenes)
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).CargarDatosAlmacen()
                    Me.Close()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtAlmacenes_KeyDown(sender As Object, e As KeyEventArgs) Handles dtAlmacen.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case llama
                Case "ptovta"

                Case "ptovtaNvo"
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).facturaAlmacen = CType(dtAlmacen.CurrentRow.DataBoundItem, datosEstructura.fact_insumos_almacenes)
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).CargarDatosAlmacen()
                    Me.Close()
            End Select
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class