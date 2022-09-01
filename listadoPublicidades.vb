Public Class listadoPublicidades
    Private cmd As MySql.Data.MySqlClient.MySqlCommand
    Private da As MySql.Data.MySqlClient.MySqlDataAdapter
    Private ds As DataSet
    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim fechaBusq As String = ""
        Dim morosoBusq As String = ""
        Dim clienteBusq As String = ""
        Dim facturadosBusq As String = ""
        fechaBusq = " having FIN >= '" & Format(dtdesdefact.Value, "yyyy-MM-dd") & "'" ' and FIN >="

        If chkSoloMorosos.Checked = True Then
            morosoBusq = " and MOROSO_MESES>0 "
        End If

        If txtbuscar.Text <> "" Then
            clienteBusq = " and CLIENTE LIKE '%" & txtbuscar.Text.Replace(" ", "%") & "%' "
        End If

        If chksinFact.Checked = True Then
            facturadosBusq = " and FACTURA_ACTUAL IS NULL "
        End If

        Reconectar()
        If rdvigentes.Checked = True Then
            Consultas("SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO,(SELECT min(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO) as 1erVENCIMIENTO, 
		date_sub((select MAX(fecha) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO), interval 1 month) as FIN,
        cl.idclientes,cl.nomapell_razon as CLIENTE,pr.DESCRIPCION as DESCRIPCION,        
        (select count(*) from rym_detalle_prestamo as DTP 
	    	where DTP.ID_PRESTAMO 
		    not in (select id FROM rym_pagos as pg where pg.PERIODO=DTP.PERIODO and DTP.ID_PRESTAMO=pr.ID_PRESTAMO)
            and DTP.ID_PRESTAMO=pr.ID_PRESTAMO
            )AS MESES_DEBE,
        (select count(*) from rym_detalle_prestamo as DTP 
		    where DTP.ID_PRESTAMO 
		    not in (select id FROM rym_pagos as pg where pg.ID_PRESTAMO=DTP.ID_PRESTAMO)
            and DTP.ID_PRESTAMO=pr.ID_PRESTAMO AND DATEDIFF(NOW(),DTP.FECHA)>@DIASMORA
            )AS MOROSO_MESES,        
        round(pr.MONTO_PRESTAMO,2) AS MONTO_TOTAL, round(pr.CUOTA,2) AS MONTO_MENSUAL, 
        ROUND(pr.MONTO_PRESTAMO - (SELECT SUM(MONTO_PAGADO) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO),2)AS SALDO, pr.CONCEPTO,        
        pr.OBSERVACIONES,
        (select concat(comp.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) from 
        fact_facturas as fact, fact_items as itm, tipos_comprobantes as comp where
        itm.id_fact= fact.id and fact.tipofact=comp.donfdesc and
        itm.plu like concat('%#',pr.ID_PRESTAMO,'%') and
        date_format(fact.fecha,'%Y-%m') = date_format(now(),'%Y-%m') limit 1) AS FACTURA_ACTUAL,		
        cl.vendedor
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1 " &
        fechaBusq & morosoBusq & clienteBusq & facturadosBusq)
        ElseIf rdAVencer.Checked = True Then
            Consultas("SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, (SELECT min(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO) as 1erVENCIMIENTO,
		date_sub((select MAX(fecha) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO), interval 1 month) as FIN,
        cl.idclientes,cl.nomapell_razon as CLIENTE,pr.DESCRIPCION as DESCRIPCION,        
        (select count(*) from rym_detalle_prestamo as DTP 
	    	where DTP.ID_PRESTAMO 
		    not in (select id FROM rym_pagos as pg where pg.PERIODO=DTP.PERIODO and DTP.ID_PRESTAMO=pr.ID_PRESTAMO)
            and DTP.ID_PRESTAMO=pr.ID_PRESTAMO
            )AS MESES_DEBE,
        (select count(*) from rym_detalle_prestamo as DTP 
		    where DTP.ID_PRESTAMO 
		    not in (select id FROM rym_pagos as pg where pg.ID_PRESTAMO=DTP.ID_PRESTAMO)
            and DTP.ID_PRESTAMO=pr.ID_PRESTAMO AND DATEDIFF(NOW(),DTP.FECHA)>@DIASMORA
            )AS MOROSO_MESES,        
        round(pr.MONTO_PRESTAMO,2) AS MONTO_TOTAL, round(pr.CUOTA,2) AS MONTO_MENSUAL, 
        ROUND(pr.MONTO_PRESTAMO - (SELECT SUM(MONTO_PAGADO) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO),2)AS SALDO, pr.CONCEPTO,
        pr.OBSERVACIONES,
        (select concat(comp.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) from 
        fact_facturas as fact, fact_items as itm, tipos_comprobantes as comp where
        itm.id_fact= fact.id and fact.tipofact=comp.donfdesc and
        itm.plu like concat('%#',pr.ID_PRESTAMO,'%') and
        date_format(fact.fecha,'%Y-%m') = date_format(now(),'%Y-%m') limit 1) AS FACTURA_ACTUAL,		
        cl.vendedor
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1
        having date_format(FIN,'%Y-%m') = date_format('" & Format(dtdesdefact.Value, "yyyy-MM-dd") & "','%Y-%m')")
        ElseIf rdOper.Checked = True Then
            Consultas("SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, (SELECT min(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO) as 1erVENCIMIENTO,
		date_sub((select MAX(fecha) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO), interval 1 month) as FIN,
        cl.nomapell_razon as CLIENTE,pr.DESCRIPCION as DESCRIPCION,        
		pr.CONCEPTO,
        pr.OBSERVACIONES,        		
        cl.vendedor
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1 " &
        fechaBusq & morosoBusq & clienteBusq & facturadosBusq)
        End If
        'MsgBox(Consultas())
    End Sub

    Public Sub Consultas(ByVal Cadena As String)
        Reconectar()
        'Dim fecha As MySql.Data.Types.MySqlDateTime()
        cmd = New MySql.Data.MySqlClient.MySqlCommand(Cadena, conexionPrinc)

        cmd.Parameters.AddWithValue("@FECHA", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Today.Date
        cmd.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = txtdiasmora.Text

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(cmd)
        ' MsgBox(cmd.CommandText)
        ds = New DataSet
        da.Fill(ds)
        'MsgBox(Cadena)
        If ds.Tables(0).Rows.Count > 0 Then
            dgvPrestamos.Cargar_Datos(ds.Tables(0))
            dgvPrestamos.dgvVista.Columns(0).Visible = True
            'DataGridView1.DataSource = ds.Tables(0)
        Else

            dgvPrestamos.Cargar_Datos(Nothing)
        End If



    End Sub

    Private Sub cmdver_Click(sender As Object, e As EventArgs) Handles cmdver.Click
        Try
            Dim i As Integer
            For i = 0 To Me.MdiChildren.Length - 1
                If MdiChildren(i).Name = "NvaPublicidad" Then
                    Me.MdiChildren(i).BringToFront()
                    Exit Sub
                End If
            Next

            Dim tec As New NvaPublicidad
            tec.MdiParent = Me.MdiParent
            tec.Show()
            tec.txtBuscaPrestamo.Text = dgvPrestamos.dgvVista.CurrentRow.Cells(0).Value
            tec.Button1.Enabled = False
            tec.btnCalcular.Enabled = False
            tec.diasMora = txtdiasmora.Text
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnNuevaPublicidad.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "NvaPublicidad" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New NvaPublicidad
        tec.MdiParent = Me.MdiParent
        tec.diasMora = txtdiasmora.Text
        tec.Show()
    End Sub

    Private Sub listadoPublicidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvPrestamos.dgvVista.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        If InStr(DatosAcceso.Moduloacc, "OPERADORRAD") <> 0 Then
            rdOper.Checked = True
            rdAVencer.Visible = False
            rdvigentes.Visible = False
            btnExportar.Visible = False
            btnFacturar.Visible = False
            btnNuevaPublicidad.Visible = False
            cmdver.Visible = False


        End If
        Me.Text = "LISTADO " & DatosAcceso.ServMensual
        dtdesdefact.Value = obtenerPrimerDiaMes()
        Label1.Text = DatosAcceso.ServMensual
        tabListadoSerivicios.Text = DatosAcceso.ServMensual
        cmdbuscar.PerformClick()

    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click
        Try

            If ElementoFacturado("#" & dgvPrestamos.dgvVista.CurrentRow.Cells("ID_PUBLICIDAD").Value) = True Then
                If MsgBox("ESTA PUBLICIDAD A HA SIDO FACTURADA EN EL MES EN CURSO, ESTA SEGURO QUE DESA FACTURAR NUEVAMENTE?", vbYesNo + vbQuestion, "PUBLICIDAD YA FACTURADA") = vbNo Then
                    Exit Sub
                End If
            End If

            Dim vta As New puntoventa
            vta.MdiParent = Me.MdiParent
            vta.idfacrap = My.Settings.idfacRap

            Dim ptovtapedido As String = My.Settings.idPtoVta
            With vta
                .Idcliente = dgvPrestamos.dgvVista.CurrentRow.Cells("idclientes").Value
                .condVta = 2
                .cargarCliente(False)
                .txtcodPLU.Focus()
                .dtproductos.Rows.Add("0", "#" & dgvPrestamos.dgvVista.CurrentRow.Cells("ID_PUBLICIDAD").Value, "1",
                 dgvPrestamos.dgvVista.CurrentRow.Cells("CONCEPTO").Value & " #" &
                 dgvPrestamos.dgvVista.CurrentRow.Cells("ID_PUBLICIDAD").Value &
                 " (" & Format(Now().AddMonths(-1), "MMMM yyyy") & ")".ToUpper, "21",
                 dgvPrestamos.dgvVista.CurrentRow.Cells("MONTO_MENSUAL").Value,
                 dgvPrestamos.dgvVista.CurrentRow.Cells("MONTO_MENSUAL").Value)
                .condVta = 2
                .lblfacvendedor.Text = dgvPrestamos.dgvVista.CurrentRow.Cells("vendedor").Value
                .Show()
            End With
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    'Private Sub chkMostarInfo_Click(sender As Object, e As EventArgs)
    '    If chkMostarInfo.Checked = False Then
    '        dgvPrestamos.dgvVista.Columns("idclientes").Visible = False
    '        dgvPrestamos.dgvVista.Columns("MONTO_TOTAL").Visible = False
    '        dgvPrestamos.dgvVista.Columns("MESES_DEBE").Visible = False
    '        dgvPrestamos.dgvVista.Columns("MOROSO_MESES").Visible = False
    '        dgvPrestamos.dgvVista.Columns("MONTO_MENSUAL").Visible = False
    '        dgvPrestamos.dgvVista.Columns("SALDO").Visible = False
    '        dgvPrestamos.dgvVista.Columns("vendedor").Visible = False
    '    Else
    '        dgvPrestamos.dgvVista.Columns("idclientes").Visible = True
    '        dgvPrestamos.dgvVista.Columns("MONTO_TOTAL").Visible = True
    '        dgvPrestamos.dgvVista.Columns("MESES_DEBE").Visible = True
    '        dgvPrestamos.dgvVista.Columns("MOROSO_MESES").Visible = True
    '        dgvPrestamos.dgvVista.Columns("MONTO_MENSUAL").Visible = True
    '        dgvPrestamos.dgvVista.Columns("SALDO").Visible = True
    '        dgvPrestamos.dgvVista.Columns("vendedor").Visible = True
    '    End If
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'GenerarExcel(dgvPrestamos.dgvVista)
        Dim EnProgreso As New Form
        Try
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

            'Dim idFactura As Integer = dtfacturas.CurrentRow.Cells(0).Value
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas

            Dim desde As String = Format(CDate(dtdesdefact.Value), "yyyy-MM-dd")
            'Dim hasta As String = Format(CDate(dthastafact.Value), "yyyy-MM-dd")
            Dim parambusq As String = ""
            Dim vendedor As String
            If cmbvendedor.SelectedValue = 0 Then
                vendedor = "TODOS"
            Else
                vendedor = cmbvendedor.Text
            End If
            'MsgBox(vendedor)
            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo " _
            & "FROM fact_empresa as emp where emp.id=1", conexionPrinc)

            tabEmp.Fill(fac.Tables("membreteenca"))
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, (SELECT min(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO) as 1erVENCIMIENTO,
            date_sub((select MAX(fecha) from rym_detalle_prestamo As DTP where DTP.ID_PRESTAMO= pr.ID_PRESTAMO), interval 1 month) As FIN,
        cl.idclientes, cl.nomapell_razon As CLIENTE, pr.DESCRIPCION As DESCRIPCION,        
        (select count(*) from rym_detalle_prestamo as DTP 
	    	where DTP.ID_PRESTAMO 
		    Not in (select id FROM rym_pagos as pg where pg.PERIODO=DTP.PERIODO And DTP.ID_PRESTAMO=pr.ID_PRESTAMO)
            And DTP.ID_PRESTAMO=pr.ID_PRESTAMO
            )AS MESES_DEBE,
        (select count(*) from rym_detalle_prestamo as DTP 
		    where DTP.ID_PRESTAMO 
		    Not in (select id FROM rym_pagos as pg where pg.ID_PRESTAMO=DTP.ID_PRESTAMO)
            And DTP.ID_PRESTAMO=pr.ID_PRESTAMO And DATEDIFF(NOW(),DTP.FECHA)>@DIASMORA
            )AS MOROSO_MESES,        
        round(pr.MONTO_PRESTAMO, 2) As MONTO_TOTAL, round(pr.CUOTA,2) As MONTO_MENSUAL, 
        ROUND(pr.MONTO_PRESTAMO - (SELECT SUM(MONTO_PAGADO) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO),2)As SALDO, pr.CONCEPTO,
        pr.OBSERVACIONES,
        (select concat(comp.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) from 
        fact_facturas As fact, fact_items As itm, tipos_comprobantes as comp where
        itm.id_fact = fact.id And fact.tipofact = comp.donfdesc And
        itm.plu Like concat('%#',pr.ID_PRESTAMO,'%') and
        date_format(fact.fecha,'%Y-%m') = date_format(now(),'%Y-%m') limit 1) AS FACTURA_ACTUAL,		
            cl.vendedor
            From rym_prestamo As pr, fact_clientes As cl
            Where pr.ID_CLIENTE = cl.idclientes
            having date_format(FIN,'%Y-%m') = date_format('" & Format(dtdesdefact.Value, "yyyy-MM-dd") & "','%Y-%m')", conexionPrinc)
            'MsgBox(tabFac.SelectCommand.CommandText)
            tabFac.SelectCommand.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = txtdiasmora.Text
            '.Add("@DIASMORA", txtdiasmora.Text)
            tabFac.Fill(fac.Tables("datosOrdenPublicidad"))

            Dim imprimirx As New imprimirFX
            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("vendedor", cmbvendedor.Text))

            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listadoOrdenes.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("membreteenca", fac.Tables("membreteenca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("datosOrdenPublicidad")))
                .rptfx.LocalReport.SetParameters(parameters)
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With
            EnProgreso.Close()
        Catch ex As Exception
            EnProgreso.Close()
            MsgBox(ex.Message)
        End Try

    End Sub
End Class