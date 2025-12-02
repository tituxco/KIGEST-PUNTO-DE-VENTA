Imports Org.BouncyCastle.Asn1
Imports System.ComponentModel
Imports System.Net.WebRequestMethods
Imports System.Windows.Interop

Public Class listadoPublicidades
    Private cmd As MySql.Data.MySqlClient.MySqlCommand
    Private da As MySql.Data.MySqlClient.MySqlDataAdapter
    Private ds As DataSet
    Dim TipoInforme As Integer
    Dim anioInforme As Integer
    Dim estadoInforme As String
    Dim periodosCancelados As String
    Public OpcBusquedaOrdenes As VariablesBusquedaOrdenes
    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        frmprincipal.pbprincipal.Visible = True
        frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
        frmprincipal.pbprincipal.MarqueeAnimationSpeed = 30
        frmprincipal.lblprocesando.Visible = True


        With OpcBusquedaOrdenes

            .morosoBusq = ""
            .clienteBusq = ""
            .facturadosBusq = ""
            .vendedorBusq = ""
            .cobradorBusq = ""
            .orderBy = " order by CLIENTE asc"
            .conceptoBusq = ""



            .fechaBusq = " having FIN >= date_add('" & Format(dtdesdefact.Value, "yyyy-MM-dd") & "', interval -1 day)" ' and FIN >="

            If chkSoloMorosos.Checked = True Then
                .morosoBusq = " and MOROSO_MESES>0 "
            End If

            If txtbuscar.Text <> "" Then
                .clienteBusq = " and CLIENTE LIKE '%" & txtbuscar.Text.Replace(" ", "%") & "%' or ID_PRESTAMO LIKE '" & txtbuscar.Text.Trim & "'"
            End If

            If chksinFact.Checked = True Then
                .facturadosBusq = " and FACTURA_ACTUAL IS NULL "
            End If

            If cmbvendedor.SelectedIndex <> -1 Then
                .vendedorBusq = " and vendedor like " & cmbvendedor.SelectedValue
            End If

            If cmbcobrador.SelectedIndex <> -1 Then
                .cobradorBusq = " and COBRADOR like " & cmbcobrador.SelectedValue
            End If

            If cmbOrdenarPor.Text <> "" Then
                .orderBy = " order by " & cmbOrdenarPor.Text
            End If

            If cmbconcepto.Text <> "" Then
                .conceptoBusq = " and CONCEPTO = '" & cmbconcepto.Text.ToUpper() & "'"
            End If

        End With
        CargarListadoOrdenesAsync.RunWorkerAsync()
    End Sub

    Public  Structure VariablesBusquedaOrdenes
        Public Property fechaBusq As String
        Public Property morosoBusq As String
        Public Property clienteBusq As String
        Public Property facturadosBusq As String
        Public Property vendedorBusq As String
        Public Property cobradorBusq As String
        Public Property orderBy As String
        Public Property conceptoBusq As String
    End Structure
    Private Sub cargarListadoOrdenes()
        Try


            Reconectar()
            If rdvigentes.Checked = True Then
                Consultas("SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO,
        (SELECT group_concat(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO and MONTH(FECHA) LIKE MONTH(date_sub('" & Format(dtdesdefact.Value, "yyyy-MM-dd") & "',interval 1 month))) as VencActual, 
		(select date_add(max(fecha),interval -1 day) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO) as FIN,
        cl.idclientes,cl.nomapell_razon as CLIENTE,pr.DESCRIPCION as DESCRIPCION,        
        
        round(pr.MONTO_PRESTAMO,2) AS MONTO_TOTAL, round(pr.CUOTA,2) AS MONTO_MENSUAL, 
        ROUND(pr.MONTO_PRESTAMO - (SELECT SUM(MONTO_PAGADO) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO),2)AS SALDO, pr.CONCEPTO,        
        pr.OBSERVACIONES,
        (select group_concat(facturaActual)from factura_actual_servicios where plu like concat('%#',pr.ID_PRESTAMO,'%')) AS FACTURA_ACTUAL,		
        cl.vendedor, pr.COBRADOR
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1 " &
        OpcBusquedaOrdenes.fechaBusq & OpcBusquedaOrdenes.morosoBusq & OpcBusquedaOrdenes.clienteBusq & OpcBusquedaOrdenes.facturadosBusq & OpcBusquedaOrdenes.vendedorBusq & OpcBusquedaOrdenes.cobradorBusq & OpcBusquedaOrdenes.conceptoBusq & OpcBusquedaOrdenes.orderBy, 1)

            ElseIf rdAFacturar.Checked = True Then
                Consultas("SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO,
        (SELECT group_concat(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO and MONTH(FECHA) LIKE MONTH(date_sub(now(),interval 1 month)) and 
        YEAR(fecha)=YEAR(now())) as VencActual, 
		(select date_add(max(fecha),interval -1 day) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO) as FIN,
        cl.idclientes,cl.nomapell_razon as CLIENTE,pr.DESCRIPCION as DESCRIPCION,        
        
        round(pr.MONTO_PRESTAMO,2) AS MONTO_TOTAL, round(pr.CUOTA,2) AS MONTO_MENSUAL, 
        ROUND(pr.MONTO_PRESTAMO - (SELECT SUM(MONTO_PAGADO) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO),2)AS SALDO, pr.CONCEPTO,        
        pr.OBSERVACIONES,
        (select group_concat(facturaActual)from factura_actual_servicios where plu like concat('%#',pr.ID_PRESTAMO,'%')) AS FACTURA_ACTUAL,		
        cl.vendedor, pr.COBRADOR
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1 " & " having VencActual is not null " &
             OpcBusquedaOrdenes.morosoBusq & OpcBusquedaOrdenes.clienteBusq & OpcBusquedaOrdenes.facturadosBusq & OpcBusquedaOrdenes.vendedorBusq & OpcBusquedaOrdenes.cobradorBusq & OpcBusquedaOrdenes.conceptoBusq & OpcBusquedaOrdenes.orderBy, 1)
            ElseIf rdAVencer.Checked = True Then
                Consultas("SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, 
        (SELECT group_concat(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO and MONTH(FECHA) LIKE MONTH(date_sub(now(),interval 1 month))) as VencActual, 
        (select date_add(max(fecha),interval -1 day) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO) as FIN,
        cl.idclientes,cl.nomapell_razon as CLIENTE,pr.DESCRIPCION as DESCRIPCION,        
       
        round(pr.MONTO_PRESTAMO,2) AS MONTO_TOTAL, round(pr.CUOTA,2) AS MONTO_MENSUAL, 
        ROUND(pr.MONTO_PRESTAMO - (SELECT SUM(MONTO_PAGADO) FROM rym_pagos WHERE ID_PRESTAMO = pr.ID_PRESTAMO),2)AS SALDO, pr.CONCEPTO,
        pr.OBSERVACIONES,
        (select group_concat(facturaActual)from factura_actual_servicios where plu like concat('%#',pr.ID_PRESTAMO,'%')) AS FACTURA_ACTUAL,		
        cl.vendedor, pr.COBRADOR
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1
        having date_format(FIN,'%Y-%m') = date_format('" & Format(dtdesdefact.Value, "yyyy-MM-dd") & "','%Y-%m')" & OpcBusquedaOrdenes.vendedorBusq & OpcBusquedaOrdenes.cobradorBusq & OpcBusquedaOrdenes.orderBy, 1)
            ElseIf rdOper.Checked = True Then
                Consultas("SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, 
        (SELECT FECHA FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO and MONTH(FECHA) LIKE MONTH(date_sub(now(),interval 1 month))) as VencActual, 
		(select date_add(max(fecha),interval -1 day) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO) as FIN,
        cl.nomapell_razon as CLIENTE,pr.DESCRIPCION as DESCRIPCION,        
		pr.CONCEPTO,
        pr.OBSERVACIONES,        		
        cl.vendedor, pr.COBRADOR
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1 " &
        OpcBusquedaOrdenes.fechaBusq & OpcBusquedaOrdenes.morosoBusq & OpcBusquedaOrdenes.clienteBusq & OpcBusquedaOrdenes.facturadosBusq & OpcBusquedaOrdenes.orderBy, 1)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub Consultas(ByVal Cadena As String, ByVal pestana As Integer)
        Reconectar()
        'Dim fecha As MySql.Data.Types.MySqlDateTime()
        cmd = New MySql.Data.MySqlClient.MySqlCommand(Cadena, conexionPrinc)
        cmd.CommandTimeout = 300

        cmd.Parameters.AddWithValue("@FECHA", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Today.Date
        cmd.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = txtdiasmora.Text

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(cmd)

        ' MsgBox(cmd.CommandText)
        ds = New DataSet
        da.Fill(ds)
        'MsgBox(Cadena)
        If pestana = 1 Then
            If ds.Tables(0).Rows.Count > 0 Then
                dgvPrestamos.Cargar_Datos(ds.Tables(0))
                dgvPrestamos.dgvVista.Columns(0).Visible = True
                dgvPrestamos.dgvVista.Columns("VencActual").Visible = False
                dgvPrestamos.dgvVista.Columns("idclientes").Visible = False
                dgvPrestamos.dgvVista.Columns("DESCRIPCION").Visible = True
                dgvPrestamos.dgvVista.Columns("MESES_DEBE").Visible = False
                dgvPrestamos.dgvVista.Columns("MONTO_TOTAL").Visible = False
                dgvPrestamos.dgvVista.Columns("SALDO").Visible = False
                dgvPrestamos.dgvVista.Columns("vendedor").Visible = False
                'DataGridView1.DataSource = ds.Tables(0)
            Else

                dgvPrestamos.Cargar_Datos(Nothing)
            End If
        ElseIf pestana = 2 Then
            dgvCtaCte.Cargar_Datos(ds.Tables(0))
            dgvCtaCte.dgvVista.Columns(0).Visible = True
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
            tec.txtPrestamo.Text = dgvPrestamos.dgvVista.CurrentRow.Cells(0).Value
            tec.NvaPubli = False
            'tec.cmdGuardarEditar.Enabled = False
            tec.btnCalcular.Enabled = False
            tec.btnPagar.Enabled = True
            tec.diasMora = txtdiasmora.Text
            tec.idVendedor = dgvPrestamos.dgvVista.CurrentRow.Cells("VENDEDOR").Value
        Catch ex As Exception
            MsgBox(ex.Message)
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

        tec.NvaPubli = True
        tec.Show()
    End Sub

    Private Sub listadoPublicidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tablavend As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,', ', nombre) from fact_vendedor where activo=1", conexionPrinc)
        Dim readvend As New DataSet
        tablavend.Fill(readvend)
        cmbvendedor.DataSource = readvend.Tables(0)
        cmbvendedor.DisplayMember = readvend.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbvendedor.ValueMember = readvend.Tables(0).Columns(0).Caption.ToString
        cmbvendedor.SelectedIndex = -1

        Dim tablacob As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,', ', nombre) from fact_cobrador where activo=1", conexionPrinc)
        Dim readcob As New DataSet
        tablacob.Fill(readcob)
        cmbcobrador.DataSource = readcob.Tables(0)
        cmbcobrador.DisplayMember = readcob.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbcobrador.ValueMember = readcob.Tables(0).Columns(0).Caption.ToString
        cmbcobrador.SelectedIndex = -1
        dgvPrestamos.dgvVista.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Dim tablacons As New MySql.Data.MySqlClient.MySqlDataAdapter("select DISTINCT (concepto) from rym_prestamo  order by CONCEPTO desc", conexionPrinc)
        Dim readcons As New DataSet
        tablacons.Fill(readcons)
        cmbconcepto.DataSource = readcons.Tables(0)
        cmbconcepto.DisplayMember = readcons.Tables(0).Columns(0).Caption.ToString.ToUpper
        cmbconcepto.SelectedIndex = -1
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
        'cmdbuscar.PerformClick()

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
                .txtobservaciones.Text = dgvPrestamos.dgvVista.CurrentRow.Cells("DESCRIPCION").Value
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
            Dim timer As New Timer

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
            Dim fechaBusq As String = ""
            Dim morosoBusq As String = ""
            Dim clienteBusq As String = ""
            Dim facturadosBusq As String = ""
            Dim vendedorBusq As String = ""
            Dim cobradorBusq As String = ""
            Dim orderBy As String = " order by CLIENTE asc"

            fechaBusq = " having FIN >= date_add('" & Format(dtdesdefact.Value, "yyyy-MM-dd") & "', interval -1 day)" ' and FIN >="

            If chkSoloMorosos.Checked = True Then
                morosoBusq = " and MOROSO_MESES>0 "
            End If

            If txtbuscar.Text <> "" Then
                clienteBusq = " and CLIENTE LIKE '%" & txtbuscar.Text.Replace(" ", "%") & "%' or ID_PRESTAMO LIKE '" & txtbuscar.Text.Trim & "'"
            End If

            If chksinFact.Checked = True Then
                facturadosBusq = " and FACTURA_ACTUAL IS NULL "
            End If

            If cmbvendedor.SelectedIndex <> -1 Then
                vendedorBusq = " and vendedor like " & cmbvendedor.SelectedValue
            End If

            If cmbcobrador.SelectedIndex <> -1 Then
                cobradorBusq = " and COBRADOR like " & cmbcobrador.SelectedValue
            End If



            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo " _
            & "FROM fact_empresa as emp where emp.id=1", conexionPrinc)

            tabEmp.Fill(fac.Tables("membreteenca"))
            Reconectar()
            Dim consultatxt = ""

            If rdvigentes.Checked = True Then
                consultatxt = "SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO,
        (SELECT group_concat(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO and MONTH(FECHA) LIKE MONTH(date_sub('" & Format(dtdesdefact.Value, "yyyy-MM-dd") & "',interval 1 month))) as VencActual, 
		(select date_add(max(fecha),interval -1 day) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO) as FIN,
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
        cl.vendedor, pr.COBRADOR
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1" &
                fechaBusq & morosoBusq & clienteBusq & facturadosBusq & vendedorBusq & cobradorBusq & orderBy
            ElseIf rdAVencer.Checked = True Then
                consultatxt = "SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, 
        (SELECT group_concat(FECHA) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO and MONTH(FECHA) LIKE MONTH(date_sub(now(),interval 1 month))) as VencActual, 
        (select date_add(max(fecha),interval -1 day) from rym_detalle_prestamo AS DTP where DTP.ID_PRESTAMO=pr.ID_PRESTAMO) as FIN,
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
        cl.vendedor, pr.COBRADOR
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes and pr.ESTADO=1
        having date_format(FIN,'%Y-%m') = date_format('" & Format(dtdesdefact.Value, "yyyy-MM-dd") & "','%Y-%m')" & vendedorBusq & cobradorBusq & orderBy

            End If



            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand(consultatxt, conexionPrinc)
            tabFac.SelectCommand.CommandTimeout = 300
            ' MsgBox(tabFac.SelectCommand.CommandText)
            tabFac.SelectCommand.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = txtdiasmora.Text
            '.Add("@DIASMORA", txtdiasmora.Text)
            tabFac.Fill(fac.Tables("datosOrdenPublicidad"))

            Dim imprimirx As New imprimirFX
            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("vendedor", cmbvendedor.Text))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("cobrador", cmbcobrador.Text))

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

    Private Sub rdAFacturar_CheckedChanged(sender As Object, e As EventArgs) Handles rdAFacturar.CheckedChanged
        If rdAFacturar.Checked = True Then
            dtdesdefact.Enabled = False
        Else
            dtdesdefact.Enabled = True
        End If

    End Sub

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged

    End Sub

    Private Sub txtbuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdbuscar.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
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

            Dim fechaBusq As String = ""
            Dim clienteBusq As String = ""

            fechaBusq = " having FIN >= date_add('" & Format(dtpFechaCtaCte.Value, "yyyy-MM-dd") & "', interval -1 day)" ' and FIN >="

            If txtbusqctacte.Text <> "" Then
                clienteBusq = " and cl.nomapell_razon LIKE '%" & txtbusqctacte.Text.Replace(" ", "%") & "%' or pr.ID_PRESTAMO LIKE '" & txtbusqctacte.Text.Trim & "'"
            End If

            Consultas("SELECT pr.ID_PRESTAMO as ID_PUBLICIDAD,pr.ID_CLIENTE,cl.nomapell_razon AS CLIENTE, cl.vendedor as VENDEDOR, pr.DESCRIPCION, pr.CONCEPTO, pr.FECHA as INICIO,
            (select date_add(max(fecha), interval -1 day) FROM rym_detalle_prestamo where ID_PRESTAMO=pr.ID_PRESTAMO) as FIN,
            pr.MONTO_PRESTAMO as IMPORTE_TOTAL, 
            ifnull((select sum(itm.ptotal) from fact_items as itm where itm.tipofact in(1,2,6,7,11,12,999) and itm.plu like concat('#',pr.ID_PRESTAMO)),0) AS FACTURADO          

            from fact_clientes as cl, rym_prestamo as pr
            where pr.ID_CLIENTE=cl.idclientes" &
            clienteBusq & fechaBusq & "
            order by cl.nomapell_razon asc", 2)
            EnProgreso.Close()
        Catch ex As Exception
            EnProgreso.Close()
            MsgBox("ERROR " + ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
            tec.txtBuscaPrestamo.Text = dgvCtaCte.dgvVista.CurrentRow.Cells(0).Value
            tec.txtPrestamo.Text = dgvCtaCte.dgvVista.CurrentRow.Cells(0).Value
            tec.NvaPubli = False
            tec.cmdGuardarEditar.Enabled = False
            tec.btnCalcular.Enabled = False
            tec.btnPagar.Enabled = True
            tec.diasMora = txtdiasmora.Text
            tec.idVendedor = dgvCtaCte.dgvVista.CurrentRow.Cells("VENDEDOR").Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If txtanio.Text = "" Or IsNumeric(txtanio.Text) = False Then
            MsgBox("Ingrse un año para ver (ej:2025)")
            Exit Sub
        Else
            anioInforme = txtanio.Text
            TipoInforme = cmbinforme.SelectedIndex
            estadoInforme = cmbestadoInforme.Text
            If chkPeriodosCancelados.CheckState = CheckState.Checked Then
                periodosCancelados = " and monto >0"
            Else
                periodosCancelados = " "
            End If

        End If
        frmprincipal.pbprincipal.Visible = True
        frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
        frmprincipal.pbprincipal.MarqueeAnimationSpeed = 30
        frmprincipal.lblprocesando.Visible = True

        CargarDatosAsync.RunWorkerAsync()


    End Sub

    Private Sub CargarInforme()


        Reconectar()
        If TipoInforme = 0 Then
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select publi.ID_PRESTAMO as ID, cli.idClientes, cli.nomapell_razon, publi.CONCEPTO, publi.DESCRIPCION, 
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=1  ))  as enero,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=2  ))  as febrero,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=3  ))  as marzo,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=4  ))  as abril,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=5  ))  as mayo,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=6  ))  as junio,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=7  ))  as julio,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=8  ))  as agosto,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=9  ))  as septiembre,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=10  ))  as octubre,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=11  ))  as noviembre,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and (year(Date_add(publiDet.FECHA, interval -1 day))=@anio and month(Date_add(publiDet.FECHA,interval -1 day))=12  )) as diciembre,
	            (select sum(replace(replace(CUOTA,'.',''),',','.')) from rym_detalle_prestamo as publiDet where publiDet.ID_PRESTAMO = publi.ID_PRESTAMO and year(Date_add(publiDet.FECHA, interval -1 day))=@anio ) as total
            from fact_clientes as cli, rym_prestamo as publi, rym_detalle_prestamo as dp
            where cli.idclientes =publi.ID_CLIENTE and 
            publi.id_prestamo=dp.id_prestamo and
            year(publi.fecha)=@anio
            group by id
            order by cli.nomapell_razon asc", conexionPrinc)
            Dim tablaPers As New DataTable
            'Dim ds As New DataSet
            consulta.SelectCommand.CommandTimeout = 300
            'MsgBox(consulta.SelectCommand.CommandText)            
            consulta.SelectCommand.Parameters.AddWithValue("@anio", MySql.Data.MySqlClient.MySqlDbType.Text).Value = anioInforme
            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)

            consulta.Fill(tablaPers)
            dgvInformes.Cargar_Datos(tablaPers)
        ElseIf TipoInforme = 1 Then

            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select publi.ID_PRESTAMO as ID, cli.idClientes, cli.nomapell_razon, publi.CONCEPTO, publi.DESCRIPCION, publiDet.FECHA as VENCIMIENTO, publiDet.cuota AS MONTO,
                (select group_concat(comp.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) from 
                fact_facturas as fact, fact_items as itm, tipos_comprobantes as comp where
                itm.id_fact= fact.id and fact.tipofact=comp.donfdesc and fact.ptovta=comp.ptovta and 
                itm.plu like concat('%#',publiDet.ID_PRESTAMO,'%') and
                date_format(date_add(publiDet.FECHA, interval -1 month),'%Y-%m')=
                date_format(str_to_date(
                 CASE WHEN INSTR(trim(substring(descripcion,locate('ENERO',descripcion), length(descripcion)-locate('ENERO',descripcion))),'ENERO')<>0 THEN
                 REPLACE (trim(substring(descripcion,locate('ENERO',descripcion), length(descripcion)-locate('ENERO',descripcion)+1)),'ENERO','JANUARY')
                 WHEN INSTR(trim(substring(descripcion,locate('FEBRERO',descripcion), length(descripcion)-locate('FEBRERO',descripcion))),'FEBRERO')<>0 THEN
                 REPLACE (trim(substring(descripcion,locate('FEBRERO',descripcion), length(descripcion)-locate('FEBRERO',descripcion)+1)),'FEBRERO','FEBRUARY')
                 WHEN INSTR(trim(substring(descripcion,locate('MARZO',descripcion), length(descripcion)-locate('MARZO',descripcion))),'MARZO')<>0 THEN
                 REPLACE (trim(substring(descripcion,locate('MARZO',descripcion), length(descripcion)-locate('MARZO',descripcion)+1)),'MARZO','MARCH')
                 WHEN INSTR(trim(substring(descripcion,locate('ABRIL',descripcion), length(descripcion)-locate('ABRIL',descripcion))),'ABRIL')<>0 THEN 
                 REPLACE (trim(substring(descripcion,locate('ABRIL',descripcion), length(descripcion)-locate('ABRIL',descripcion)+1)),'ABRIL','APRIL')
                 WHEN INSTR(trim(substring(descripcion,locate('MAYO',descripcion), length(descripcion)-locate('MAYO',descripcion))),'MAYO')<>0 THEN 
                 REPLACE (trim(substring(descripcion,locate('MAYO',descripcion), length(descripcion)-locate('MAYO',descripcion)+1)),'MAYO','MAY')
                 WHEN INSTR(trim(substring(descripcion,locate('JUNIO',descripcion), length(descripcion)-locate('JUNIO',descripcion))),'JUNIO')<>0 THEN 
                 REPLACE (trim(substring(descripcion,locate('JUNIO',descripcion), length(descripcion)-locate('JUNIO',descripcion)+1)),'JUNIO','JUNE')
                 WHEN INSTR(trim(substring(descripcion,locate('JULIO',descripcion), length(descripcion)-locate('JULIO',descripcion))),'JULIO')<>0 THEN
                 REPLACE (trim(substring(descripcion,locate('JULIO',descripcion), length(descripcion)-locate('JULIO',descripcion)+1)),'JULIO','JULY')
                 WHEN INSTR(trim(substring(descripcion,locate('AGOSTO',descripcion), length(descripcion)-locate('AGOSTO',descripcion))),'AGOSTO')<>0 THEN
                 REPLACE (trim(substring(descripcion,locate('AGOSTO',descripcion), length(descripcion)-locate('AGOSTO',descripcion)+1)),'AGOSTO','AUGUST')
                 WHEN INSTR(trim(substring(descripcion,locate('SEPTIEMBRE',descripcion), length(descripcion)-locate('SEPTIEMBRE',descripcion))),'SEPTIEMBRE')<>0 THEN 
                 REPLACE (trim(substring(descripcion,locate('SEPTIEMBRE',descripcion), length(descripcion)-locate('SEPTIEMBRE',descripcion)+1)),'SEPTIEMBRE','SEPTEMBER')
                 WHEN INSTR(trim(substring(descripcion,locate('OCTUBRE',descripcion), length(descripcion)-locate('OCTUBRE',descripcion))),'OCTUBRE')<>0 THEN 
                 REPLACE (trim(substring(descripcion,locate('OCTUBRE',descripcion), length(descripcion)-locate('OCTUBRE',descripcion)+1)),'OCTUBRE','OCTOBER')
                 WHEN INSTR(trim(substring(descripcion,locate('NOVIEMBRE',descripcion), length(descripcion)-locate('NOVIEMBRE',descripcion))),'NOVIEMBRE')<>0 THEN 
                 REPLACE (trim(substring(descripcion,locate('NOVIEMBRE',descripcion), length(descripcion)-locate('NOVIEMBRE',descripcion)+1)),'NOVIEMBRE','NOVEMBER')
                 WHEN INSTR(trim(substring(descripcion,locate('DICIEMBRE',descripcion), length(descripcion)-locate('DICIEMBRE',descripcion))),'DICIEMBRE')<>0 THEN 
                 REPLACE (trim(substring(descripcion,locate('DICIEMBRE',descripcion), length(descripcion)-locate('DICIEMBRE',descripcion)+1)),'DICIEMBRE','DECEMBER')
                 ELSE '1' END,'%M %Y'),'%Y-%m')
                ) AS FACTURA,
                IF((SELECT count(*) from rym_pagos where ID_PRESTAMO=publiDet.ID_PRESTAMO and periodo=publiDet.PERIODO)=1,
		        'PAGADA',IF(DATEDIFF(NOW(),publiDet.FECHA)>@DIASMORA,'MOROSO','DEBE')
		        ) AS ESTADO        
                from fact_clientes as cli, rym_prestamo as publi, rym_detalle_prestamo as publiDet
                where cli.idclientes =publi.ID_CLIENTE and 
                publi.ID_PRESTAMO = publiDet.ID_PRESTAMO and 
                year(publi.fecha)=@anio
                having ESTADO LIKE '" & estadoInforme & "'" & periodosCancelados & "
                order by cli.nomapell_razon ASC, VENCIMIENTO  asc", conexionPrinc)
            Dim tablaPers As New DataTable
            'Dim ds As New DataSet
            consulta.SelectCommand.CommandTimeout = 300
            'MsgBox(consulta.SelectCommand.CommandText)
            consulta.SelectCommand.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = 14
            consulta.SelectCommand.Parameters.AddWithValue("@anio", MySql.Data.MySqlClient.MySqlDbType.Text).Value = anioInforme
            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)

            consulta.Fill(tablaPers)
            dgvInformes.Cargar_Datos(tablaPers)

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        '        GenerarExcel(dgvInformes.dgvVista)
        frmprincipal.pbprincipal.Visible = True
        frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
        frmprincipal.pbprincipal.MarqueeAnimationSpeed = 30

        CargarExcelAsync.RunWorkerAsync()
    End Sub

    Private Sub CargarDatosAsync_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles CargarDatosAsync.DoWork
        CargarInforme()
        dgvInformes.dgvVista.Columns(0).Visible = True
    End Sub

    Private Sub CargarDatosAsync_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles CargarDatosAsync.ProgressChanged
        'no hay progreso

    End Sub

    Private Sub CargarDatosAsync_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CargarDatosAsync.RunWorkerCompleted
        frmprincipal.pbprincipal.Visible = False
        frmprincipal.lblprocesando.Visible = False
    End Sub

    Private Sub CargarExcelAsync_DoWork(sender As Object, e As DoWorkEventArgs) Handles CargarExcelAsync.DoWork
        GenerarExcelDT(dgvInformes.todos_los_datos)
    End Sub

    Private Sub CargarExcelAsync_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CargarExcelAsync.RunWorkerCompleted
        frmprincipal.pbprincipal.Visible = False

        frmprincipal.lblprocesando.Visible = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbestadoInforme.SelectedIndexChanged

    End Sub

    Private Sub tabInformes_Click(sender As Object, e As EventArgs) Handles tabInformes.Click

    End Sub

    Private Sub tabInformes_Enter(sender As Object, e As EventArgs) Handles tabInformes.Enter
        cmbestadoInforme.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
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
            tec.txtBuscaPrestamo.Text = dgvInformes.dgvVista.CurrentRow.Cells(0).Value
            tec.txtPrestamo.Text = dgvInformes.dgvVista.CurrentRow.Cells(0).Value
            tec.NvaPubli = False
            tec.cmdGuardarEditar.Enabled = False
            tec.btnCalcular.Enabled = False
            tec.btnPagar.Enabled = True
            tec.diasMora = txtdiasmora.Text
            'tec.idVendedor = dgvInformes.dgvVista.CurrentRow.Cells("VENDEDOR").Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim i As Integer
            For i = 0 To Me.MdiChildren.Length - 1
                If MdiChildren(i).Name = "CONTABLE" Then
                    Me.MdiChildren(i).Close()
                End If
            Next

            Dim ventana As New CONTABLE
            ventana.MdiParent = Me.MdiParent
            With ventana
                .Show()
                .txtcuentabus.Text = dgvInformes.dgvVista.CurrentRow.Cells("idClientes").Value
                .txtcliebus.Text = dgvInformes.dgvVista.CurrentRow.Cells("nomapell_razon").Value.ToString.ToUpper
                .cargarCuentaClie(Val(dgvInformes.dgvVista.CurrentRow.Cells("idClientes").Value))
                .tabcontable.SelectedTab = .tabcuentasclientes
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarListadoOrdenesAsync_DoWork(sender As Object, e As DoWorkEventArgs) Handles CargarListadoOrdenesAsync.DoWork
        cargarListadoOrdenes()
    End Sub

    Private Sub CargarListadoOrdenesAsync_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CargarListadoOrdenesAsync.RunWorkerCompleted
        frmprincipal.pbprincipal.Visible = False
        frmprincipal.lblprocesando.Visible = False
    End Sub
End Class