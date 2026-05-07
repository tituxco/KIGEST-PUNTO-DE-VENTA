Public Class selPtoVta
    Dim listaFacturasRapidas As List(Of
    datosEstructura.fact_facturasrapidas)
    Public llama As String
    Public ptovta As datosEstructura.fact_puntosventa
    Public tipoFact As datosEstructura.fact_comprobantes_tipo
    Private Sub selPtoVta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            listaFacturasRapidas = datosEstructura.fact_facturasrapidas.ObtenerTodos
            Dim admitidasEnTerminal = listaFacturasRapidas.Where(
                Function(X) X.punto_venta.id = ptovta.id Or
                X.punto_venta.id = FacturaElectro.puntovtaelect).ToList
            dtPtoVta.DataSource = admitidasEnTerminal

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtPtoVta_DoubleClick(sender As Object, e As EventArgs) Handles dtPtoVta.DoubleClick
        Try
            Select Case llama
                Case "ptovta"
                    CType(frmprincipal.ActiveMdiChild, puntoventa).listaPrecios = dtPtoVta.CurrentRow.Cells(0).Value
                    CType(frmprincipal.ActiveMdiChild, puntoventa).lblfactlistaprecios.Text = dtPtoVta.CurrentRow.Cells(1).Value
                    CType(frmprincipal.ActiveMdiChild, puntoventa).RecalcularPreciosLista()
                    CType(frmprincipal.ActiveMdiChild, puntoventa).txtcodPLU.Focus()
                    Me.Close()
                Case "ptovtaNvo"
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).comprobanteDatosGenerales = CType(dtPtoVta.CurrentRow.DataBoundItem, datosEstructura.fact_facturasrapidas)
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).cargarDatosCoprobanteSeleccionado()
                    Me.Close()
            End Select

        Catch ex As Exception

        End Try
    End Sub


    Private Sub dtPtoVta_KeyDown(sender As Object, e As KeyEventArgs) Handles dtPtoVta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case llama
                Case "ptovta"
                    CType(frmprincipal.ActiveMdiChild, puntoventa).listaPrecios = dtPtoVta.CurrentRow.Cells(0).Value
                    CType(frmprincipal.ActiveMdiChild, puntoventa).lblfactlistaprecios.Text = dtPtoVta.CurrentRow.Cells(1).Value
                    CType(frmprincipal.ActiveMdiChild, puntoventa).RecalcularPreciosLista()
                    CType(frmprincipal.ActiveMdiChild, puntoventa).txtcodPLU.Focus()
                    Me.Close()
                Case "ptovtaNvo"
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).comprobanteDatosGenerales = CType(dtPtoVta.CurrentRow.DataBoundItem, datosEstructura.fact_facturasrapidas)
                    CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo).cargarDatosCoprobanteSeleccionado()
                    Me.Close()
            End Select
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class