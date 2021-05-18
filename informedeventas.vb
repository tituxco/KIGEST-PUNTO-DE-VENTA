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

        cmbhistorialProductosAlmacen.DataSource = readAlmac.Tables(0)
        cmbhistorialProductosAlmacen.DisplayMember = readAlmac.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbhistorialProductosAlmacen.ValueMember = readAlmac.Tables(0).Columns(0).Caption.ToString
        cmbhistorialProductosAlmacen.SelectedValue = My.Settings.idAlmacen



        Dim tablaVend As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,', ',nombre) from fact_vendedor", conexionPrinc)
        Dim readVend As New DataSet
        tablaVend.Fill(readVend)
        cmbvendedor.DataSource = readVend.Tables(0)
        cmbvendedor.DisplayMember = readVend.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbvendedor.ValueMember = readVend.Tables(0).Columns(0).Caption.ToString
        cmbvendedor.SelectedIndex = -1

        cmbVendedorHistorial.DataSource = readVend.Tables(0)
        cmbVendedorHistorial.DisplayMember = readVend.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbVendedorHistorial.ValueMember = readVend.Tables(0).Columns(0).Caption.ToString
        cmbVendedorHistorial.SelectedIndex = -1

        cmbseguimientoProductosVendedores.DataSource = readVend.Tables(0)
        cmbseguimientoProductosVendedores.DisplayMember = readVend.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbseguimientoProductosVendedores.ValueMember = readVend.Tables(0).Columns(0).Caption.ToString
        cmbseguimientoProductosVendedores.SelectedIndex = -1

        If InStr(DatosAcceso.Moduloacc, "4f") = False Then tabseguimientoVendedores.Parent = Nothing

        Dim tablaCajas As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, descripcion from fact_cajas", conexionPrinc)
        Dim readcajas As New DataSet
        tablaCajas.Fill(readcajas)
        cmbcajas.DataSource = readcajas.Tables(0)
        cmbcajas.DisplayMember = readcajas.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbcajas.ValueMember = readcajas.Tables(0).Columns(0).Caption.ToString



    End Sub
    Private Function CalcularComisiones(idVendedor As Integer) As Double
        Try
            If idVendedor = 0 Or idVendedor = -1 Then
                Reconectar()
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("", conexionPrinc)
                Dim tablal As DataTable
                consulta.Fill(tablal)
            End If
        Catch ex As Exception

        End Try
    End Function


    Private Sub rdInforProv_Click(sender As Object, e As EventArgs) Handles rdInforProv.Click
        If rdInforProv.Checked = True Then
            cmbInforCateg.Enabled = False
            cmbInforProv.Enabled = True
            txtInforProd.Enabled = False
            txtdiasventa.Enabled = False

        End If
    End Sub

    Private Sub rdInforCategoria_Click(sender As Object, e As EventArgs) Handles rdInforCategoria.Click

        If rdInforCategoria.Checked = True Then
            cmbInforCateg.Enabled = True
            cmbInforProv.Enabled = False
            txtInforProd.Enabled = False
            txtdiasventa.Enabled = False

        End If
    End Sub

    Private Sub rdInforgeneral_Click(sender As Object, e As EventArgs) Handles rdInforgeneral.Click
        If rdInforgeneral.Checked = True Then
            cmbInforCateg.Enabled = False
            cmbInforProv.Enabled = False
            txtInforProd.Enabled = False
            txtdiasventa.Enabled = False

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
            Dim tablaVta As New DataTable
            Dim tablaDev As New DataTable
            Dim consIdAlmacen As String = ""
            Dim consIdVendedor As String = ""
            Dim ComisionVendedor As Double = 0
            Dim IdVendedorSel As Integer = 0
            tablaVta.Clear()
            tablaDev.Clear()
            tablaVta.Columns.Clear()
            tablaDev.Columns.Clear()
            ' If cmbAlmacenes.SelectedValue <> 0 And cmbAlmacenes.SelectedIndex <> -1 Then
            If cmbAlmacenes.SelectedValue = 0 Then
                consIdAlmacen = " and itm.idAlmacen like '%'"
            Else
                consIdAlmacen = " and itm.idAlmacen=" & cmbAlmacenes.SelectedValue
            End If


            If cmbvendedor.SelectedValue = 0 Or cmbvendedor.SelectedIndex = -1 Then
                consIdVendedor = " "
                IdVendedorSel = 0
            Else
                consIdVendedor = " and fact.vendedor=" & cmbvendedor.SelectedValue
                IdVendedorSel = cmbvendedor.SelectedValue
            End If

            Dim consultaVend As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
			    comision from fact_vendedor where activo=1 and id= " & IdVendedorSel, conexionPrinc)
            Dim TablaVend As New DataTable
            consultaVend.Fill(TablaVend)

            If TablaVend.Rows.Count <> 0 Then ComisionVendedor = TablaVend.Rows(0)(0)

            If rdInforgeneral.Checked = True And chkproductos.CheckState = CheckState.Unchecked Then
                Dim consultaVTAS As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
			    fact.fecha,  
                round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * 
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,
			    
                round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact and 
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "'" & consIdAlmacen & consIdVendedor & " group by fact.fecha", conexionPrinc)

                Dim consultaDEV As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
			    fact.fecha,  
                round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * 
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,
			    
                round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact and 
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'C') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "'" & consIdAlmacen & consIdVendedor & " group by fact.fecha", conexionPrinc)

                'MsgBox(consulta.SelectCommand.CommandText)
                consultaVTAS.Fill(tablaVta)
                consultaDEV.Fill(tablaDev)

            ElseIf rdInforgeneral.Checked = True And chkproductos.CheckState = CheckState.Checked Then
                Dim prodBusq As String = ""
                If txtInforProd.Text <> "" Then
                    prodBusq = "and ins.descripcion like '%" & txtInforProd.Text & "%'"
                End If

                Dim consultaVTAS As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 	ins.codigo,	ins.descripcion, format(sum(itm.cantidad),2,'es_AR') as cantidadVendida,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,

			    round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact  and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & prodBusq & consIdAlmacen & consIdVendedor & " 
                group by ins.descripcion order by ins.descripcion asc", conexionPrinc)

                Dim consultaDEV As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 	ins.codigo,	ins.descripcion, format(sum(itm.cantidad),2,'es_AR') as cantidadVendida,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,

			    round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact  and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'C') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & prodBusq & consIdAlmacen & consIdVendedor & " 
                group by ins.descripcion order by ins.descripcion asc", conexionPrinc)

                consultaVTAS.Fill(tablaVta)
                consultaDEV.Fill(tablaDev)

            ElseIf rdInforProv.Checked = True And chkproductos.CheckState = CheckState.Unchecked Then
                Dim provSel As String = ""
                If cmbInforProv.SelectedIndex <> -1 And cmbInforProv.SelectedValue <> 0 Then
                    provSel = " and ins.codprov=" & cmbInforProv.SelectedValue
                End If
                Dim consultaVTAS As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 		prov.razon,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,

                round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact, fact_proveedores as prov where
                ins.id=itm.cod and fact.id=itm.id_fact and ins.codprov=prov.id and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & provSel & consIdAlmacen & consIdVendedor & " group by ins.codprov order by prov.razon asc", conexionPrinc)

                Dim consultaDEV As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 		prov.razon,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,

                round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact, fact_proveedores as prov where
                ins.id=itm.cod and fact.id=itm.id_fact and ins.codprov=prov.id and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'C') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & provSel & consIdAlmacen & consIdVendedor & " group by ins.codprov order by prov.razon asc", conexionPrinc)

                consultaVTAS.Fill(tablaVta)
                consultaDEV.Fill(tablaDev)

            ElseIf rdInforProv.Checked = True And chkproductos.CheckState = CheckState.Checked Then
                Dim provSel As String = ""
                If cmbInforProv.SelectedIndex <> -1 And cmbInforProv.SelectedValue <> 0 Then
                    provSel = " and ins.codprov=" & cmbInforProv.SelectedValue
                End If

                Dim prodBusq As String = ""
                If txtInforProd.Text <> "" Then
                    prodBusq = "and ins.descripcion like '%" & txtInforProd.Text & "%'"
                End If
                Dim consultaVTAS As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 	ins.codigo,	ins.descripcion, format(sum(itm.cantidad),2,'es_AR') as cantidadVendida,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,

			    round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                        
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact  and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & provSel & prodBusq & consIdAlmacen & consIdVendedor & " 
                group by ins.descripcion order by ins.descripcion asc", conexionPrinc)

                Dim consultaDEV As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 	ins.codigo,	ins.descripcion, format(sum(itm.cantidad),2,'es_AR') as cantidadVendida,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,

			    round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                        
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact  and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'C') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & provSel & prodBusq & consIdAlmacen & consIdVendedor & " 
                group by ins.descripcion order by ins.descripcion asc", conexionPrinc)

                consultaVTAS.Fill(tablaVta)
                consultaDEV.Fill(tablaDev)

            ElseIf rdInforCategoria.Checked = True And chkproductos.CheckState = CheckState.Unchecked Then
                Dim catSel As String = ""
                If cmbInforCateg.SelectedIndex <> -1 And cmbInforCateg.SelectedValue <> 0 Then
                    catSel = " and ins.categoria=" & cmbInforCateg.SelectedValue
                End If
                Dim consultaVTAS As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 		cat.nombre,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,

                round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact, fact_categoria_insum as cat where
                ins.id=itm.cod and fact.id=itm.id_fact and ins.categoria=cat.id and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & catSel & consIdAlmacen & consIdVendedor & " group by ins.categoria order by cat.nombre asc", conexionPrinc)

                Dim consultaDEV As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 		cat.nombre,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,

                round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact, fact_categoria_insum as cat where
                ins.id=itm.cod and fact.id=itm.id_fact and ins.categoria=cat.id and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'C') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & catSel & consIdAlmacen & consIdVendedor & " group by ins.categoria order by cat.nombre asc", conexionPrinc)

                consultaVTAS.Fill(tablaVta)
                consultaDEV.Fill(tablaDev)

            ElseIf rdInforCategoria.Checked = True And chkproductos.CheckState = CheckState.Checked Then
                Dim catSel As String = ""
                If cmbInforCateg.SelectedIndex <> -1 And cmbInforCateg.SelectedValue <> 0 Then
                    catSel = " and ins.categoria=" & cmbInforCateg.SelectedValue
                End If
                Dim prodBusq As String = ""
                If txtInforProd.Text <> "" Then
                    prodBusq = "and ins.descripcion like '%" & txtInforProd.Text & "%'"
                End If
                Dim consultaVTAS As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 	ins.codigo,	ins.descripcion, format(sum(itm.cantidad),2,'es_AR') as cantidadVendida,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,
			    
                round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact  and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & catSel & prodBusq & consIdAlmacen & consIdVendedor & " 
                group by ins.descripcion order by ins.descripcion asc", conexionPrinc)

                Dim consultaDEV As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 	ins.codigo,	ins.descripcion, format(sum(itm.cantidad),2,'es_AR') as cantidadVendida,
			    round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad *
                (select cotizacion from fact_moneda where id=ins.moneda)),2) as pcosto,
			    
                round(sum(                
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)),2) as pventa,
							
                round(sum(
                if(itm.tipofact in(1,2,3),
                itm.ptotal*((itm.iva+100)/100),
                itm.ptotal)) - 
                sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad * (select cotizacion from fact_moneda where id=ins.moneda)),2)  as ganancia      
                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact  and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'C') and itm.cod<>0 and 
                fact.fecha between '" & desde & "' and '" & hasta & "' " & catSel & prodBusq & consIdAlmacen & consIdVendedor & " 
                group by ins.descripcion order by ins.descripcion asc", conexionPrinc)

                consultaVTAS.Fill(tablaVta)
                consultaDEV.Fill(tablaDev)

            ElseIf rdPocaRotacion.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 	ins.codigo,	ins.descripcion, max(fact.fecha) FechaUltVta, datediff(curdate(), max(fact.fecha)) as Dias			    
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact  and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                datediff(curdate(), fact.fecha) >=" & CInt(txtdiasventa.Text) & consIdAlmacen & "
                group by ins.codigo desc order by max(fact.fecha) asc", conexionPrinc)
                consulta.Fill(tablaVta)
            End If

            Reconectar()
            Dim consultaComis As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 	ins.codigo,	ins.descripcion, format(sum(itm.cantidad),2,'es_AR') as cantidadVendida,
			    round(sum(itm.ptotal),2) as MontoVenta,
                promo.compra_min as VentaObjetivo, promo.descuento_porc as PorcComision,
                round(sum(itm.ptotal) * (promo.descuento_porc /100),2) as MontoComision
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact, fact_promociones as promo where
                ins.id=itm.cod and fact.id=itm.id_fact  and itm.cod=promo.idproducto and promo.nombrepromo like 'COMISION PRODUCTO' and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                itm.cod in(select idproducto from fact_promociones where nombrepromo like 'COMISION PRODUCTO') and
                fact.fecha between '" & desde & "' and '" & hasta & "' " & consIdAlmacen & consIdVendedor & " 
                group by ins.descripcion 
                having sum(itm.cantidad)>promo.compra_min
                order by ins.descripcion asc", conexionPrinc)
            Dim tablaComis As New DataTable

            consultaComis.Fill(tablaComis)

            Dim consultaComisCAT As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 'NaN', concat('COMISION CAT','-',cat.nombre) as tipo, 'NaN',
			    round(sum(itm.ptotal),2) as MontoVenta,
                'NaN', promo.descuento_porc as PorcComision,
                round(sum(itm.ptotal) * (promo.descuento_porc /100),2) as MontoComision                
                FROM fact_items as itm, fact_categoria_insum as cat, fact_facturas as fact, fact_promociones as promo, fact_insumos as ins                 
                where
                ins.id=itm.cod and 
                ins.categoria=cat.id and
                fact.id=itm.id_fact  and 
                ins.categoria=promo.idcategoria and promo.nombrepromo like 'COMISION CATEGORIA' and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
                ins.categoria in(select idcategoria from fact_promociones where nombrepromo like 'COMISION CATEGORIA') and
                fact.fecha between '" & desde & "' and '" & hasta & "' " & consIdAlmacen & consIdVendedor, conexionPrinc)
            Dim consultaComisDEV As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 'NaN', concat('DEVOLUCION CAT','-',cat.nombre) as tipo, 'NaN',
			    - round(sum(itm.ptotal),2) as MontoVenta,
                'NaN', promo.descuento_porc as PorcComision,
                - round(sum(itm.ptotal) * (promo.descuento_porc /100),2) as MontoComision                
                FROM fact_items as itm, fact_categoria_insum as cat, fact_facturas as fact, fact_promociones as promo, fact_insumos as ins                 
                where
                ins.id=itm.cod and 
                ins.categoria=cat.id and
                fact.id=itm.id_fact  and 
                ins.categoria=promo.idcategoria and promo.nombrepromo like 'COMISION CATEGORIA' and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'C') and itm.cod<>0 and 
                ins.categoria in(select idcategoria from fact_promociones where nombrepromo like 'COMISION CATEGORIA') and
                fact.fecha between '" & desde & "' and '" & hasta & "' " & consIdAlmacen & consIdVendedor, conexionPrinc)
            Dim tablaComisCat As New DataTable
            Dim tablacomiscatDEV As New DataTable
            consultaComisCAT.Fill(tablaComisCat)
            consultaComisDEV.Fill(tablacomiscatDEV)
            'MsgBox(tablacomiscatDEV.Rows.Count)
            'If tablacomiscatDEV.Rows.Count > 1 Then
            tablaComisCat.Merge(tablacomiscatDEV)
            'End If
            Dim i As Integer
            For i = 0 To tablaComisCat.Rows.Count - 1
                Dim FilaCat As DataRow = tablaComis.NewRow()
                FilaCat("codigo") = tablaComisCat.Rows(i).Item(0)
                FilaCat("descripcion") = tablaComisCat.Rows(i).Item(1)
                FilaCat("cantidadVendida") = tablaComisCat.Rows(i).Item(2)
                If IsDBNull(tablaComisCat.Rows(i).Item(3)) Then
                    FilaCat("MontoVenta") = 0
                Else
                    FilaCat("MontoVenta") = tablaComisCat.Rows(i).Item(3)
                End If
                FilaCat("VentaObjetivo") = tablaComisCat.Rows(i).Item(4)
                FilaCat("PorcComision") = tablaComisCat.Rows(i).Item(5)
                If IsDBNull(tablaComisCat.Rows(i).Item(6)) Then
                    FilaCat("MontoComision") = 0
                Else
                    FilaCat("MontoComision") = tablaComisCat.Rows(i).Item(6)
                End If
                tablaComis.Rows.Add(FilaCat)
            Next

            dtventashistoricas.DataSource = tablaVta
            dtgcomisiones.DataSource = tablaComis
            dtdevoluciones.DataSource = tablaDev


            Dim TotalVentas As Double = 0
            Dim TotalVentasObjetivo As Double = 0
            Dim TotalVentasNoCodif As Double = 0
            Dim TotalDevoluciones As Double = 0

            Reconectar()
            Dim consultaNoCodif As New MySql.Data.MySqlClient.MySqlDataAdapter("
                SELECT  ins.descripcion, format(sum(itm.cantidad),2,'es_AR') as cantidadVendida,			    
			    round(sum(itm.ptotal),2) as pventa                
                FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
                ins.id=itm.cod and fact.id=itm.id_fact  and
                itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod=0 and
                fact.fecha between '" & desde & "' and '" & hasta & "' " & consIdAlmacen & consIdVendedor & " 
                group by ins.descripcion order by ins.descripcion asc", conexionPrinc)
            Dim tablaNoCodif As New DataTable
            consultaNoCodif.Fill(tablaNoCodif)

            If tablaNoCodif.Rows.Count <> 0 Then
                TotalVentasNoCodif = tablaNoCodif(0)(2)
            End If

            If rdInforgeneral.Checked = True Then
                lblbalancecosto.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 1), 2)
                lblbalanceventas.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 2), 2)
                lblvalDevoluciones.Text = "$" & Math.Round(SumarTotal(dtdevoluciones, 2), 2)
                TotalVentas = Math.Round(SumarTotal(dtventashistoricas, 2) - SumarTotal(dtdevoluciones, 2), 2)
                TotalDevoluciones = Math.Round(SumarTotal(dtdevoluciones, 2), 2)
                lblbalanceganancia.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 3) - SumarTotal(dtdevoluciones, 3), 2)
                lblBalanProdNodCod.Text = "$" & TotalVentasNoCodif

            ElseIf rdInforProv.Checked = True Then
                lblbalancecosto.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 1), 2)
                lblbalanceventas.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 2), 2)
                lblvalDevoluciones.Text = "$" & Math.Round(SumarTotal(dtdevoluciones, 2), 2)
                TotalVentas = Math.Round(SumarTotal(dtventashistoricas, 2) - SumarTotal(dtdevoluciones, 2), 2)
                TotalDevoluciones = Math.Round(SumarTotal(dtdevoluciones, 2), 2)
                lblbalanceganancia.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 3) - SumarTotal(dtdevoluciones, 3), 2)
                lblBalanProdNodCod.Text = "$" & TotalVentasNoCodif
            ElseIf rdInforCategoria.Checked = True Then
                lblbalancecosto.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 1), 2)
                lblbalanceventas.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 2), 2)
                lblvalDevoluciones.Text = "$" & Math.Round(SumarTotal(dtdevoluciones, 2), 2)
                TotalVentas = Math.Round(SumarTotal(dtventashistoricas, 2) - SumarTotal(dtdevoluciones, 2), 2)
                TotalDevoluciones = Math.Round(SumarTotal(dtdevoluciones, 2), 2)
                lblbalanceganancia.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 3) - SumarTotal(dtdevoluciones, 3), 2)
                lblBalanProdNodCod.Text = "$" & TotalVentasNoCodif
            End If
            If chkproductos.CheckState = CheckState.Checked Then
                lblbalancecosto.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 3), 2)
                lblbalanceventas.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 4), 2)
                lblvalDevoluciones.Text = "$" & Math.Round(SumarTotal(dtdevoluciones, 4), 2)
                TotalVentas = Math.Round(SumarTotal(dtventashistoricas, 4) - SumarTotal(dtdevoluciones, 4), 2)
                TotalDevoluciones = Math.Round(SumarTotal(dtdevoluciones, 4), 2)
                lblbalanceganancia.Text = "$" & Math.Round(SumarTotal(dtventashistoricas, 5) - SumarTotal(dtdevoluciones, 4), 2)
                lblBalanProdNodCod.Text = "$" & TotalVentasNoCodif
            End If


            'MsgBox("COMISION TOTAL" & TotalVentas & "-" & TotalDevoluciones & " * " & ComisionVendedor & "/ 100")

            lblvendedor.Text = cmbvendedor.Text
            lblComisvtas.Text = Math.Round((TotalVentas) * (ComisionVendedor / 100), 2)
            lblcomisobjetivos.Text = Math.Round(SumarTotal(dtgcomisiones, 6), 2)
            lblcomistotal.Text = Math.Round(SumarTotal(dtgcomisiones, 6) + (TotalVentas) * (ComisionVendedor / 100), 2)

            'lblcomisiones.Text = "Comisiones por productos objetivos: $" & Math.Round(SumarTotal(dtgcomisiones, 6), 2) &
            '    " Comision por ventas: $" & Math.Round(TotalVentas * (ComisionVendedor / 100), 2) &
            '    " Total: $" & Math.Round(SumarTotal(dtgcomisiones, 6), 2) + Math.Round(TotalVentas * (ComisionVendedor / 100), 2)
            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub

    Private Sub CalcularComisiones()
        If cmbvendedor.SelectedValue = 0 Or cmbvendedor.SelectedIndex = -1 Then

        End If
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each fila As DataGridViewRow In dtventashistoricas.Rows


            Dim cant As Double = FormatNumber(fila.Cells(2).Value, 4)
            Dim codigo As String = fila.Cells(6).Value
            Dim lotes As Integer = 0

            Reconectar()
            Dim consultastock As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id, stock FROM fact_insumos_lotes " _
            & "where stock >0 and idproducto=" & codigo & " and idalmacen= " & cmbAlmacenes.SelectedValue & " order by id asc", conexionPrinc)
            Dim tablastock As New DataTable
            Dim infostock() As DataRow
            consultastock.Fill(tablastock)
            infostock = tablastock.Select("")
            'MsgBox(cant)
            If tablastock.Rows.Count = 0 Then
                Continue For
            End If

            Do Until cant = 0
                If infostock(lotes)(1) <= cant Then
                    Dim StockLote As Double = infostock(lotes)(1)
                    cant = cant - StockLote
                    Reconectar()
                    Dim updstock As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos_lotes Set stock=0 where id=" & infostock(lotes)(0), conexionPrinc)
                    updstock.ExecuteNonQuery()
                    If tablastock.Rows.Count - lotes > 1 Then
                        lotes += 1
                    Else
                        cant = 0
                        'Continue For
                    End If
                ElseIf infostock(lotes)(1) > cant Then
                    Dim stockLote As Double = infostock(lotes)(1)
                    Dim CantUpd As Double = infostock(lotes)(1) - cant
                    Reconectar()
                    Dim updstock As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos_lotes Set stock='" & CantUpd & "' where id=" & infostock(lotes)(0), conexionPrinc)
                    updstock.ExecuteNonQuery()
                    cant = 0
                    'ElseIf infostock(lotes)(1) > cant
                End If
            Loop
        Next
    End Sub


    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        cmbvendedor.SelectedIndex = -1
        cmbInforCateg.SelectedIndex = -1
        cmbInforProv.SelectedIndex = -1

    End Sub

    Private Sub rdPocaRotacion_Click(sender As Object, e As EventArgs) Handles rdPocaRotacion.Click
        If rdPocaRotacion.Checked = True Then
            cmbInforCateg.Enabled = False
            cmbInforProv.Enabled = False
            txtInforProd.Enabled = False

            txtdiasventa.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim datosInformes As New datosInformes
            For Each venta As DataGridViewRow In dtventashistoricas.Rows
                'If rdInforgeneral.Checked = True And chkproductos.Checked = True Then

                'End If
                datosInformes.Tables("ventasTotales").Rows.Add(
                venta.Cells("codigo").Value,
                venta.Cells("cantidadVendida").Value,
                venta.Cells("descripcion").Value,
                venta.Cells("pventa").Value)


            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkproductos_CheckedChanged(sender As Object, e As EventArgs) Handles chkproductos.CheckedChanged

        If chkproductos.Checked = True Then
            '    cmbInforCateg.Enabled = False
            '    cmbInforProv.Enabled = False
            txtInforProd.Enabled = True
            '    txtdiasventa.Enabled = False
        Else
            txtInforProd.Enabled = False

        End If
    End Sub

    Private Sub chkproductos_Click(sender As Object, e As EventArgs) Handles chkproductos.Click
        If rdInforProductos.Checked = True Then

            txtInforProd.Enabled = True


        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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

        EnProgreso.Show()
        Application.DoEvents()
        If cmbVendedorHistorial.SelectedIndex = -1 Or Val(txtmeseshistorial.Text) = 0 Then
            MsgBox("Debe seleccionar un vendedor y establecer una cantidad de meses para ver")
            Exit Sub
        End If
        dgvHistorialVtasCliente.DataSource = Nothing
        'DgvHistorialVtasCliente.dgvVista.Columns.Clear()

        Try
            Reconectar()

            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select cli.idclientes,cli.nomapell_razon, format(sum(fact.total),2,'es_AR')as totalVenta,
            concat(monthname(fact.fecha),'-',YEAR(fact.fecha)) as Periodo
            from fact_facturas as fact, fact_clientes as cli
            where fact.id_cliente= cli.idclientes
            and fact.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') 
            and fact.fecha between date_sub(date_format(now(),'%Y-%m-01'),interval " & Val(txtmeseshistorial.Text) & " month) and date_format(now(),'%Y-%m-%d')
            and cli.vendedor=" & cmbVendedorHistorial.SelectedValue & "
            group by month(fact.fecha),fact.id_cliente order by month(fact.fecha) asc", conexionPrinc)
            Dim tablaDatosHistorial As New DataTable
            consulta.Fill(tablaDatosHistorial)
            Dim HistorialCliente As New DataTable

            HistorialCliente.Columns.Add("idclientes")
            HistorialCliente.Columns.Add("nomapell_razon")
            'HistorialCliente.Columns.Add("totalVenta")
            Dim textocol As String
            Dim existecol As Boolean = False
            'MsgBox(tablaDatosHistorial.Rows.Count)
            For Each datos As DataRow In tablaDatosHistorial.Rows
                textocol = datos.Item(3)
                '   MsgBox(textocol)
                For Each columna As DataColumn In HistorialCliente.Columns
                    If textocol = columna.ColumnName Then
                        existecol = True
                        Exit For
                    Else
                        'MsgBox(textocol & "<>" & columna.ColumnName)
                        existecol = False
                    End If
                Next
                If existecol = False Then
                    HistorialCliente.Columns.Add(textocol)
                End If
            Next

            Dim idcliente As String
            Dim nomapell As String
            Dim totalvta As String
            Dim periodo As String
            Dim AgregarFila As Boolean
            tablaDatosHistorial.DefaultView.Sort = "idclientes asc"
            tablaDatosHistorial = tablaDatosHistorial.DefaultView.ToTable
            For Each datos As DataRow In tablaDatosHistorial.Rows
                idcliente = datos.Item(0)
                nomapell = datos.Item(1)
                totalvta = datos.Item(2)
                periodo = datos.Item(3)

                If HistorialCliente.Rows.Count = 0 Then
                    '       MsgBox("primera FIla ")
                    AgregarFila = True
                Else
                    For Each dtosHistorial As DataRow In HistorialCliente.Rows
                        If dtosHistorial.Item("idclientes") = idcliente Then
                            '              MsgBox("igual fila distintos datos" & periodo & "-->" & totalvta)
                            dtosHistorial.Item(periodo) = totalvta
                            AgregarFila = False
                        Else
                            '             MsgBox("Datos distintos se pude que se agregue nueva fila")
                            AgregarFila = True
                        End If
                    Next
                End If

                If AgregarFila = True Then
                    '    MsgBox("agregando fila nueva" & idcliente & "-->" & nomapell)
                    Dim fila As DataRow = HistorialCliente.NewRow()
                    fila("idclientes") = idcliente
                    fila("nomapell_razon") = nomapell
                    fila(periodo) = totalvta
                    HistorialCliente.Rows.Add(fila)
                End If
            Next

            dgvHistorialVtasCliente.DataSource = HistorialCliente
            EnProgreso.Close()
        Catch ex As Exception
            EnProgreso.Close()

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
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

        EnProgreso.Show()
        Application.DoEvents()

        Dim almacenHistorial As String = ""
        Dim vendedorHistorial As String = ""

        If cmbhistorialProductosAlmacen.SelectedIndex <> -1 And cmbhistorialProductosAlmacen.SelectedValue <> 0 Then
            almacenHistorial = " and itm.idAlmacen= " & cmbhistorialProductosAlmacen.SelectedValue
        End If

        If cmbVendedorHistorial.SelectedIndex <> -1 And cmbVendedorHistorial.SelectedValue <> 0 Then
            vendedorHistorial = " and fact.vendedor= " & cmbVendedorHistorial.SelectedValue
        End If

        dgvSeguimientoProductos.dgvVista.DataSource = Nothing
        'DgvHistorialVtasCliente.dgvVista.Columns.Clear()

        Try
            Reconectar()

            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select itm.cod,itm.descripcion, 
            concat('(',format(sum(itm.cantidad),2,'es_AR'),')',format(sum(itm.ptotal),2,'es_AR'))as totalVenta,
            concat(monthname(fact.fecha),'-',YEAR(fact.fecha)) as Periodo
            from fact_facturas as fact, fact_clientes as cli,fact_items as itm
            where fact.id_cliente= cli.idclientes and fact.id=itm.id_fact
            and fact.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') 
            and fact.fecha between date_sub(date_format(now(),'%Y-%m-01'),interval " & Val(txthistorialProductosMeses.Text) & " month) and date_format(now(),'%Y-%m-%d')
            and itm.descripcion like '%" & txthistorialProductosBusqueda.Text.Replace(" ", "%") & "%'" & almacenHistorial & vendedorHistorial & "

            
            group by month(fact.fecha),itm.cod order by month(fact.fecha) asc", conexionPrinc)
            'MsgBox(consulta.SelectCommand.CommandText)
            Dim tablaDatosHistorial As New DataTable
            consulta.Fill(tablaDatosHistorial)
            Dim HistorialCliente As New DataTable

            HistorialCliente.Columns.Add("cod")
            HistorialCliente.Columns.Add("descripcion")
            'HistorialCliente.Columns.Add("totalVenta")
            Dim textocol As String
            Dim existecol As Boolean = False
            'MsgBox(tablaDatosHistorial.Rows.Count)
            For Each datos As DataRow In tablaDatosHistorial.Rows
                textocol = datos.Item(3)
                '   MsgBox(textocol)
                For Each columna As DataColumn In HistorialCliente.Columns
                    If textocol = columna.ColumnName Then
                        existecol = True
                        Exit For
                    Else
                        'MsgBox(textocol & "<>" & columna.ColumnName)
                        existecol = False
                    End If
                Next
                If existecol = False Then
                    HistorialCliente.Columns.Add(textocol)
                End If
            Next

            Dim idcliente As String
            Dim nomapell As String
            Dim totalvta As String
            Dim periodo As String
            Dim AgregarFila As Boolean
            tablaDatosHistorial.DefaultView.Sort = "cod asc"
            tablaDatosHistorial = tablaDatosHistorial.DefaultView.ToTable
            For Each datos As DataRow In tablaDatosHistorial.Rows
                idcliente = datos.Item(0)
                nomapell = datos.Item(1)
                totalvta = datos.Item(2)
                periodo = datos.Item(3)

                If HistorialCliente.Rows.Count = 0 Then
                    '       MsgBox("primera FIla ")
                    AgregarFila = True
                Else
                    For Each dtosHistorial As DataRow In HistorialCliente.Rows
                        If dtosHistorial.Item("cod") = idcliente Then
                            '              MsgBox("igual fila distintos datos" & periodo & "-->" & totalvta)
                            dtosHistorial.Item(periodo) = totalvta
                            AgregarFila = False
                        Else
                            '             MsgBox("Datos distintos se pude que se agregue nueva fila")
                            AgregarFila = True
                        End If
                    Next
                End If

                If AgregarFila = True Then
                    '    MsgBox("agregando fila nueva" & idcliente & "-->" & nomapell)
                    Dim fila As DataRow = HistorialCliente.NewRow()
                    fila("cod") = idcliente
                    fila("descripcion") = nomapell
                    fila(periodo) = totalvta
                    HistorialCliente.Rows.Add(fila)
                End If
            Next

            dgvSeguimientoProductos.Cargar_Datos(HistorialCliente)
            EnProgreso.Close()
        Catch ex As Exception
            EnProgreso.Close()

        End Try
    End Sub

    Private Sub DgvHistorialVtasCliente_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "frmaspirantes" Then
                Me.MdiChildren(i).BringToFront()

                Exit Sub
            End If
        Next

        Dim clientes As New frmaspirantes
        clientes.txtbuscar.Text = dgvHistorialVtasCliente.CurrentRow.Cells(1).Value
        clientes.CargarPersonal(dgvHistorialVtasCliente.CurrentRow.Cells(1).Value)
        clientes.Idcliente = dgvHistorialVtasCliente.CurrentRow.Cells(0).Value
        clientes.Button8.PerformClick()
        clientes.MdiParent = Me.MdiParent

        clientes.Show()
    End Sub

    Private Sub dtdevoluciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtdevoluciones.CellContentClick

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim fecha As String = Format(CDate(dtpFecha.Value), "yyyy-MM-dd")
            If cmbcajas.SelectedValue = -1 Then
                MsgBox("No selecciono caja")
                Exit Sub
            End If

            Reconectar()
            Dim consultaLectura As New MySql.Data.MySqlClient.MySqlDataAdapter("select codProd, producto, sum(replace(cant,',','.')) 
            from fact_insumos_historial_lectura where fecha like '" & fecha & " %%:%%:%%'
            and tmp_caja=" & cmbcajas.SelectedValue & "
            group by codProd
            order by producto asc    ", conexionPrinc)
            'MsgBox(consulta.SelectCommand.CommandText)
            Dim tablaLectura As New DataTable
            consultaLectura.Fill(tablaLectura)
            dgvLecturas.DataSource = tablaLectura

            Reconectar()
            Dim consultaSalida As New MySql.Data.MySqlClient.MySqlDataAdapter("select cod,descripcion,sum(cantidad) 
            from fact_items where fecha_alta like '" & fecha & " %%:%%:%%'
            and idCaja=" & cmbcajas.SelectedValue & " 
            and tipofact in(select donfdesc from tipos_comprobantes where debcred like 'D')
            group by cod
            order by descripcion asc", conexionPrinc)
            'MsgBox(consulta.SelectCommand.CommandText)
            Dim tablaSalida As New DataTable
            consultaSalida.Fill(tablaSalida)
            dgvSalidas.DataSource = tablaSalida

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvLecturas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLecturas.CellEnter
        Try
            'MsgBox(dgvLecturas.Rows(e.RowIndex).Cells(0).Value)
            Dim existeProd As Boolean = False
            For Each fila As DataGridViewRow In dgvSalidas.Rows
                If fila.Cells(0).Value = dgvLecturas.Rows(e.RowIndex).Cells(0).Value Then
                    fila.Selected = True
                    lbldiferencia.Text = dgvLecturas.Rows(e.RowIndex).Cells(2).Value - fila.Cells(2).Value
                    existeProd = True
                    dgvSalidas.FirstDisplayedScrollingRowIndex = fila.Index
                    'Exit For
                Else
                    fila.Selected = False
                    'lbldiferencia.Text = "Producto no facturado"
                End If
            Next
            If existeProd = False Then
                lbldiferencia.Text = "Producto no facturado"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim desde As String = Format(CDate(dtdesdefact.Value), "yyyy-MM-dd")
        Dim hasta As String = Format(CDate(dthastafact.Value), "yyyy-MM-dd")

        Dim BusqFacturados As String = ""
        If chkfacturado.Checked = True Then
            BusqFacturados = " and facturado=0 "
        End If
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM 
            fact_insumos_produccion where 
            fecha_alta between '" & desde & "' and '" & hasta & "'" &
            BusqFacturados, conexionPrinc)
        Dim TablaEnvasados As New DataTable

        consulta.Fill(TablaEnvasados)
        dgvProduccionEnvasados.DataSource = TablaEnvasados
    End Sub

    Private Sub dgvLecturas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLecturas.CellContentClick

    End Sub
End Class