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
        Consultas("SELECT pr.ID_PRESTAMO AS ID_PUBLICIDAD, pr.FECHA as INICIO, 
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
        (select concat(comp.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) from 
        fact_facturas as fact, fact_items as itm, tipos_comprobantes as comp where
        itm.id_fact= fact.id and fact.tipofact=comp.donfdesc and
        itm.plu like concat('%#',pr.ID_PRESTAMO,'%') and
        date_format(fact.fecha,'%Y-%m') = date_format(now(),'%Y-%m') limit 1) AS FACTURA_ACTUAL,		
        cl.vendedor
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes" &
        fechaBusq & morosoBusq & clienteBusq & facturadosBusq)

        'MsgBox()
    End Sub

    Public Sub Consultas(ByVal Cadena As String)
        Reconectar()
        'Dim fecha As MySql.Data.Types.MySqlDateTime()
        cmd = New MySql.Data.MySqlClient.MySqlCommand(Cadena, conexionPrinc)
        cmd.Parameters.AddWithValue("@FECHA", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Today.Date
        cmd.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = txtdiasmora.Text
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(cmd)
        'MsgBox(cmd.CommandText)
        ds = New DataSet
        da.Fill(ds)

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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
        Me.Text = "LISTADO " & DatosAcceso.ServMensual
        dtdesdefact.Value = obtenerPrimerDiaMes()
        Label1.Text = DatosAcceso.ServMensual
        cmdbuscar.PerformClick()

    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostarInfo.CheckedChanged

    End Sub

    Private Sub chkMostarInfo_Click(sender As Object, e As EventArgs) Handles chkMostarInfo.Click
        If chkMostarInfo.Checked = False Then
            dgvPrestamos.dgvVista.Columns("idclientes").Visible = False
            dgvPrestamos.dgvVista.Columns("MONTO_TOTAL").Visible = False
            dgvPrestamos.dgvVista.Columns("MESES_DEBE").Visible = False
            dgvPrestamos.dgvVista.Columns("MOROSO_MESES").Visible = False
            dgvPrestamos.dgvVista.Columns("MONTO_MENSUAL").Visible = False
            dgvPrestamos.dgvVista.Columns("SALDO").Visible = False
            dgvPrestamos.dgvVista.Columns("vendedor").Visible = False
        Else
            dgvPrestamos.dgvVista.Columns("idclientes").Visible = True
            dgvPrestamos.dgvVista.Columns("MONTO_TOTAL").Visible = True
            dgvPrestamos.dgvVista.Columns("MESES_DEBE").Visible = True
            dgvPrestamos.dgvVista.Columns("MOROSO_MESES").Visible = True
            dgvPrestamos.dgvVista.Columns("MONTO_MENSUAL").Visible = True
            dgvPrestamos.dgvVista.Columns("SALDO").Visible = True
            dgvPrestamos.dgvVista.Columns("vendedor").Visible = True
        End If
    End Sub
End Class