Public Class informedeventas
    Private Sub informedeventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tablaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, razon from fact_proveedores", conexionPrinc)
        Dim readprov As New DataSet
        tablaprov.Fill(readprov)
        cmbInforProv.DataSource = readprov.Tables(0)
        cmbInforProv.DisplayMember = readprov.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbInforProv.ValueMember = readprov.Tables(0).Columns(0).Caption.ToString
        cmbInforProv.SelectedIndex = -1

        Dim tablaCateg As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_categoria_insum", conexionPrinc)
        Dim readCat As New DataSet
        tablaCateg.Fill(readCat)
        cmbInforCateg.DataSource = readCat.Tables(0)
        cmbInforCateg.DisplayMember = readCat.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbInforCateg.ValueMember = readCat.Tables(0).Columns(0).Caption.ToString
        cmbInforCateg.SelectedIndex = -1

        Dim tablaAlmac As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_insumos_almacenes", conexionPrinc)
        Dim readAlmac As New DataSet
        tablaAlmac.Fill(readAlmac)
        cmbAlmacenes.DataSource = readAlmac.Tables(0)
        cmbAlmacenes.DisplayMember = readAlmac.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbAlmacenes.ValueMember = readAlmac.Tables(0).Columns(0).Caption.ToString


        cmbAlmacenes.SelectedValue = My.Settings.idAlmacen
    End Sub


    Private Sub rdInforProv_Click(sender As Object, e As EventArgs) Handles rdInforProv.Click
        If rdInforProv.Checked = True Then
            cmbInforCateg.Enabled = False
            cmbInforProv.Enabled = True
            txtInforProd.Enabled = False
        End If
    End Sub

    Private Sub rdInforCategoria_Click(sender As Object, e As EventArgs) Handles rdInforCategoria.Click
        If rdInforCategoria.Checked = True Then
            cmbInforCateg.Enabled = True
            cmbInforProv.Enabled = False
            txtInforProd.Enabled = False
        End If
    End Sub

    Private Sub rdInforgeneral_Click(sender As Object, e As EventArgs) Handles rdInforgeneral.Click
        If rdInforgeneral.Checked = True Then
            cmbInforCateg.Enabled = False
            cmbInforProv.Enabled = False
            txtInforProd.Enabled = False
        End If
    End Sub

    Private Sub rdInforProductos_Click(sender As Object, e As EventArgs) Handles rdInforProductos.Click
        If rdInforProductos.Checked = True Then
            cmbInforCateg.Enabled = False
            cmbInforProv.Enabled = False
            txtInforProd.Enabled = True
        End If
    End Sub



    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim EnProgreso As New Form
        EnProgreso.ControlBox = False
        EnProgreso.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        EnProgreso.Size = New Point(430, 30)
        EnProgreso.StartPosition = FormStartPosition.CenterScreen
        EnProgreso.TopMost = True
        Dim Etiqueta As New Label
        Etiqueta.AutoSize = True
        Etiqueta.Text = "La consulta esta en progreso, esto puede tardar unos momentos, por favor espere ..."
        Etiqueta.Location = New Point(5, 5)
        EnProgreso.Controls.Add(Etiqueta)
        'Dim Barra As New ProgressBar
        'Barra.Style = ProgressBarStyle.Marquee
        'Barra.Size = New Point(270, 40)
        'Barra.Location = New Point(10, 30)
        'Barra.Value = 100
        'EnProgreso.Controls.Add(Barra)
        EnProgreso.Show()
        Application.DoEvents()

        Try
            Reconectar()
            'Dim columna As Integer
            Dim desde As String = Format(CDate(dtpvtashisdesde.Value), "yyyy-MM-dd")
            Dim hasta As String = Format(CDate(dtpvtashishasta.Value), "yyyy-MM-dd")
            Dim tablabal As New DataTable
            Dim consIdAlmacen As String = ""
            tablabal.Clear()
            ' If cmbAlmacenes.SelectedValue <> 0 And cmbAlmacenes.SelectedIndex <> -1 Then
            consIdAlmacen = " and itm.ptovta=" & cmbAlmacenes.SelectedValue
            'End If

            If rdInforgeneral.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
			    fact.fecha,  
                round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * 
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,
			    round(sum(itm.ptotal),2) as pventa, 
                round(sum(itm.ptotal) - sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact and 
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & consIdAlmacen & " ' group by fact.fecha", conexionPrinc)
                consulta.Fill(tablabal)

            ElseIf rdInforProv.Checked = True Then
                Dim provSel As String = ""
                If cmbInforProv.SelectedIndex <> -1 And cmbInforProv.SelectedValue <> 0 Then
                    provSel = " and ins.codprov=" & cmbInforProv.SelectedValue
                End If
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 		prov.razon,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,
			    round(sum(itm.ptotal),2) as pventa, 
                round(sum(itm.ptotal) - sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact, fact_proveedores as prov where
                ins.id=itm.cod and fact.id=itm.id_fact and ins.codprov=prov.id and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & provSel & consIdAlmacen & " group by ins.codprov order by prov.razon asc", conexionPrinc)
                consulta.Fill(tablabal)

            ElseIf rdInforCategoria.Checked = True Then
                Dim catSel As String = ""
                If cmbInforCateg.SelectedIndex <> -1 And cmbInforCateg.SelectedValue <> 0 Then
                    catSel = " and ins.categoria=" & cmbInforCateg.SelectedValue
                End If
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 		cat.nombre,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,
			    round(sum(itm.ptotal),2) as pventa, 
                round(sum(itm.ptotal) - sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact, fact_categoria_insum as cat where
                ins.id=itm.cod and fact.id=itm.id_fact and ins.categoria=cat.id and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & catSel & consIdAlmacen & " group by ins.categoria order by cat.nombre asc", conexionPrinc)
                consulta.Fill(tablabal)

            ElseIf rdInforProductos.Checked = True Then
                Dim prodBusq As String = ""
                If txtInforProd.Text <> "" Then
                    prodBusq = "and ins.descripcion like '%" & txtInforProd.Text & "%'"
                End If

                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 	ins.codigo,	ins.descripcion, format(sum(itm.cantidad),2,'es_AR') as cantidadVendida,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,
			    round(sum(itm.ptotal),2) as pventa, 
                round(sum(itm.ptotal) - sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact  and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & prodBusq & consIdAlmacen & " group by ins.descripcion order by ins.descripcion asc", conexionPrinc)
                consulta.Fill(tablabal)


            End If

            dtventashistoricas.DataSource = tablabal

            If rdInforgeneral.Checked = True Then
                lblbalancecosto.Text = "Total costo: $" & Math.Round(SumarTotal(dtventashistoricas, 1), 2)
                lblbalanceventas.Text = "Total ventas: $" & Math.Round(SumarTotal(dtventashistoricas, 2), 2)
                lblbalanceganancia.Text = "Total ganancia: $" & Math.Round(SumarTotal(dtventashistoricas, 3), 2)
            ElseIf rdInforProv.Checked = True Then
                lblbalancecosto.Text = "Total costo: $" & Math.Round(SumarTotal(dtventashistoricas, 1), 2)
                lblbalanceventas.Text = "Total ventas: $" & Math.Round(SumarTotal(dtventashistoricas, 2), 2)
                lblbalanceganancia.Text = "Total ganancia: $" & Math.Round(SumarTotal(dtventashistoricas, 3), 2)
            ElseIf rdInforCategoria.Checked = True Then
                lblbalancecosto.Text = "Total costo: $" & Math.Round(SumarTotal(dtventashistoricas, 1), 2)
                lblbalanceventas.Text = "Total ventas: $" & Math.Round(SumarTotal(dtventashistoricas, 2), 2)
                lblbalanceganancia.Text = "Total ganancia: $" & Math.Round(SumarTotal(dtventashistoricas, 3), 2)
            ElseIf rdInforProductos.Checked = True Then
                lblbalancecosto.Text = "Total costo: $" & Math.Round(SumarTotal(dtventashistoricas, 3), 2)
                lblbalanceventas.Text = "Total ventas: $" & Math.Round(SumarTotal(dtventashistoricas, 4), 2)
                lblbalanceganancia.Text = "Total ganancia: $" & Math.Round(SumarTotal(dtventashistoricas, 5), 2)
                'ElseIf rdInforMes.Checked = True Then
                '    lblbalancecosto.Text = "Total costo: $" & 0 'Math.Round(SumarTotal(dtventashistoricas, 2), 2)
                '    lblbalanceventas.Text = "Total ventas: $" & Math.Round(SumarTotal(dtventashistoricas, 1), 2)
                '    lblbalanceganancia.Text = "Total ganancia: $" & 0 '& Math.Round(SumarTotal(dtventashistoricas, 4), 2)
            End If
            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub
    Private Function SumarTotal(ByRef list As DataGridView, ByVal columna As Integer) As Double
        Try


            Dim total As Double = 0
            Dim i As Integer
            For i = 0 To list.RowCount - 1
                total += FormatNumber(list.Rows(i).Cells(columna).Value, 2)

            Next
            Return total
            'Dim numcol As Integer
            'If tabcontable.SelectedTab.Name = "VENTAS" Then
            '    If rdninguno.Checked = True Then numcol = 7
            '    If rdcliente.Checked = True Then numcol = 4
            '    If rdvendedor.Checked = True Then numcol = 1
            '    If rdproducto.Checked = True Then numcol = 3
            'ElseIf tabcontable.SelectedTab.Name = "COBRANZAS" Then
            '    If chkcobselvendedor.Checked = True Then numcol = 10
            '    If chkcobselvendedor.Checked = False Then numcol = 10
            'End If

            'For Each fila As DataGridViewRow In dtfacturas.Rows
            '    total += fila.Cells(columna).Value
            'Next

            'lbltotalfact.Text = total


            'For Each fila As DataGridViewRow In dtlistacob.Rows
            '    total += fila.Cells(columna).Value
            'Next
            'lbltotcob.Text = total

            'total = 0

            'For Each fila As DataGridViewRow In dtestadocuentas.Rows
            '    total += fila.Cells(columna).Value
            'Next
            'lbltotctacte.Text = total

            'total = 0

            'For Each fila As DataGridViewRow In dtcheques.Rows
            '    total += fila.Cells(columna).Value
            'Next
            'lbltotalcheques.Text = total

            'total = 0
            'For Each fila As DataGridViewRow In dtchequespropios.Rows
            '    total += fila.Cells(columna).Value
            'Next
            'lbltotalchequespropios.Text = total

        Catch ex As Exception

        End Try
    End Function

End Class