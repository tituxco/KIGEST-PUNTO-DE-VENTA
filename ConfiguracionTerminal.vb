Public Class ConfiguracionTerminal
    Private Sub ConfiguracionTerminal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtidfacrapdef.Text = My.Settings.idfacRap
        txtptovtadef.Text = My.Settings.idPtoVta
        txtidalmacen.Text = My.Settings.idAlmacen
        txtunidadDef.Text = My.Settings.UnidDef
        cmbtipoTiketEtiqueta.SelectedIndex = My.Settings.TipoEtiqueta
        txttipoetiqueta.Text = My.Settings.TipoEtiqueta

        txtcajaDef.Text = My.Settings.CajaDef

        'txtEtiquetaNombre.Text = My.Settings.EtiquetadoraNmb
        cmbImpresoraEtiquetas.SelectedText = My.Settings.EtiquetadoraNmb



        txtTextoPietiket.Text = My.Settings.TextoPieTiket
        txtidmoneda.Text = My.Settings.monedaDef
        txtidDevolucion.Text = My.Settings.idDevolucion
        cmbMetodoBusquedaProd.SelectedIndex = My.Settings.metodoBusquedaProd
        txttipotaller.Text = My.Settings.tipoTaller
        cmbVisualizacionProd.SelectedIndex = My.Settings.visualizacionProducto

        If My.Settings.ImprTikets = 1 Then
            chkimprimirtikets.CheckState = CheckState.Checked
            cmbimpresoraTiket.SelectedText = My.Settings.ImprTiketsNombre
        End If

        If My.Settings.obtCodProd = "cod_bar" Then rdcod_bar.Checked = True Else rdIdInterno.Checked = True
        If My.Settings.metodoCalculo = 1 Then rdcalculo1.Checked = True Else rdcalculo2.Checked = True
        For Each impresora As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cmbimpresoraTiket.Items.Add(impresora.ToString)
            cmbImpresoraEtiquetas.Items.Add(impresora.ToString)
        Next



    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        My.Settings.idfacRap = txtidfacrapdef.Text
        My.Settings.idPtoVta = txtptovtadef.Text
        My.Settings.idAlmacen = txtidalmacen.Text
        If chkimprimirtikets.CheckState = CheckState.Checked Then My.Settings.ImprTikets = 1
        If chkimprimirtikets.CheckState = CheckState.Unchecked Then My.Settings.ImprTikets = 0

        DatosAcceso.idFacRap = txtidfacrapdef.Text
        DatosAcceso.IdPtoVtaDef = txtptovtadef.Text
        DatosAcceso.IdAlmacen = txtidalmacen.Text
        My.Settings.UnidDef = txtunidadDef.Text
        My.Settings.TipoEtiqueta = cmbtipoTiketEtiqueta.SelectedIndex
        My.Settings.EtiquetadoraNmb = cmbImpresoraEtiquetas.Text ' txtEtiquetaNombre.Text
        My.Settings.ImprTiketsNombre = cmbimpresoraTiket.Text ' txtimptiketsnombre.Text
        My.Settings.CajaDef = txtcajaDef.Text
        My.Settings.TextoPieTiket = txtTextoPietiket.Text
        My.Settings.monedaDef = txtidmoneda.Text
        My.Settings.idDevolucion = txtidDevolucion.Text
        My.Settings.metodoBusquedaProd = cmbMetodoBusquedaProd.SelectedIndex
        If rdcod_bar.Checked = True Then My.Settings.obtCodProd ="cod_bar" Else My.Settings.obtCodProd ="id"

        If rdcalculo2.Checked = True Then My.Settings.metodoCalculo = 0 Else My.Settings.metodoCalculo = 1
        My.Settings.tipoTaller = txttipotaller.Text
        My.Settings.visualizacionProducto = cmbVisualizacionProd.SelectedIndex
        My.Settings.Save()

        MsgBox("Configuración Guardada")

    End Sub
End Class