Public Class caja
    Dim saldoCaja As Double = 0

    Private Sub caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDtosGrales()
    End Sub
    Private Sub CargarDtosGrales()
        Try
            Reconectar()

            Dim tablacajas As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_cajas", conexionPrinc)
            Dim readcajas As New DataSet
            tablacajas.Fill(readcajas)
            cmbcajas.DataSource = readcajas.Tables(0)
            cmbcajas.DisplayMember = readcajas.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcajas.ValueMember = readcajas.Tables(0).Columns(0).Caption.ToString
            cmbcajas.SelectedIndex = -1 'My.Settings.CajaDef       

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbcajas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcajas.SelectionChangeCommitted
        Try
            Dim tablacierres As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, fecha from fact_cajas_cierres where caja=" & cmbcajas.SelectedValue & " order by id desc", conexionPrinc)
            Dim readcierres As New DataSet
            tablacierres.Fill(readcierres)
            cmbcierresCajas.DataSource = readcierres.Tables(0)
            cmbcierresCajas.DisplayMember = readcierres.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcierresCajas.ValueMember = readcierres.Tables(0).Columns(0).Caption.ToString
            cmbcierresCajas.SelectedIndex = 0 'My.Settings.CajaDef
            CargarCaja(False)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcerrarcaja_Click(sender As Object, e As EventArgs) Handles cmdcerrarcaja.Click
        Try
            Dim fecha As String = Format(Now, "yyyy-MM-dd")
            Dim sqlQuery As String

            Reconectar()
            sqlQuery = "insert into fact_cajas_cierres(monto,caja) values (?monto,?caja)"

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?monto", FormatNumber(saldoCaja, 2))
                .AddWithValue("?caja", cmbcajas.SelectedValue)
            End With
            comandoadd.ExecuteNonQuery()
            MsgBox("El cierre de caja fue exitoso")
            saldoCaja = 0
            CargarCaja(False)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarCaja(historial As Boolean)
        Try
            Dim egresos As Double = 0
            Dim ingresos As Double = 0
            saldoCaja = 0
            Dim CajaDef As Integer = cmbcajas.SelectedValue
            Dim ultimoCierr As String
            Dim fechacaja As String
            Dim SqlCierres As String

            Dim idCajaSel As Integer = cmbcajas.SelectedValue
            Dim idCierreSel As Integer = cmbcierresCajas.SelectedValue

            'If chkfiltrofecha.Checked = True Then
            '    fechacaja = " and cc.fecha <='" & Format(DateAdd(DateInterval.Day, 1, dtpfechacaja.Value), "yyyy-MM-dd") & "'"
            '    'MsgBox(fechacaja)
            'End If

            dtcaja.Rows.Clear()
            Reconectar()

            Dim SQLARQUEO As String
            If historial = True Then
                SQLARQUEO = "select fecha, monto from fact_cajas_cierres where caja=" & idCajaSel & " and fecha=(select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & idCajaSel & " and cc.id<" & idCierreSel & ")"
                ' MsgBox(SQLARQUEO)
            Else

                SQLARQUEO = "select fecha, monto from fact_cajas_cierres where caja=" & idCajaSel & " and fecha=(select max(cc.fecha)from fact_cajas_cierres as cc where cc.caja=" & idCajaSel & ")"
                'MsgBox(SQLARQUEO)
            End If

            Dim consultacierre As New MySql.Data.MySqlClient.MySqlDataAdapter(SQLARQUEO, conexionPrinc)
            'MsgBox(consultacierre.SelectCommand.CommandText)
            Dim tablacierr As New DataTable
            Dim infocierr() As DataRow

            consultacierre.Fill(tablacierr)
            'MsgBox(tablacierr.Rows.Count)
            If tablacierr.Rows.Count = 0 Then
                'ultimoCierr = "%%%%-%%-%%
            Else
                '    If historial = False Then
                infocierr = tablacierr.Select()
                'ultimoCierr = Format(CDate(tablacierr(0)(0).ToString), "yyyy-MM-dd")
                dtcaja.Rows.Add(tablacierr(0)(0), "", "ARQUEO DE CAJA", tablacierr(0)(1), "0")
                ' MsgBox(tablacierr(0)(1))
                ingresos = ingresos + tablacierr(0)(1)
                '   End If
            End If

            Reconectar()
            Dim SqlTEXT As String
            If historial = True Then
                SqlTEXT = "select ie.fecha, 
		case ie.tipo
			When 1 Then (
				Select concat(ic.concepto,' - ', cl.nomapell_razon) from  fact_ingresos_concepto as ic,  
                fact_facturas as fact, fact_clientes as cl 
                where ic.id=ie.concepto and ie.comprobante=fact.id and
                cl.idclientes=fact.id_cliente                
                ) 
			when 2 then (
				select concat(ec.concepto,' - ',prov.razon) from fact_egresos_concepto  as ec, 
				fact_proveedores_fact as fact, fact_proveedores as prov 
				where ec.id=ie.concepto and ie.comprobante=fact.id and fact.idproveedor=prov.id) 
			end as concepto, 
        case ie.tipo
			When 1 Then (
				Select concat(tip.abrev,' - ',lpad(fac.ptovta,'3','0'),'-',lpad(fac.num_fact,'8','0')) 
				from fact_facturas as fac, fact_conffiscal as tip ,  fact_puntosventa as ptovta
				where  tip.donfdesc=fac.tipofact and ptovta.id=tip.ptovta and fac.ptovta=ptovta.id and fac.id=ie.comprobante 
				and ie.tipo=1 )  
			when 2 then (select concat(tip.abrev,' - ',fac.numero) 
				from fact_proveedores_fact as fac, fact_conffiscal as tip, fact_puntosventa as ptovta
				where tip.donfdesc=fac.tipo and fac.id=ie.comprobante and tip.ptovta=left(fac.numero,4) 
				and ptovta.id=tip.ptovta and ie.tipo=2) 
			end as detalles,  
				format(replace(ie.monto,',','.'),2,'es_AR') AS MONTO, ie.tipo, ie.descripcion
			from fact_ingreso_egreso as ie where ie.caja= " & idCajaSel & "
				and ie.fecha between (select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & idCajaSel & " and cc.id<" & idCierreSel & ")
                and (select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & idCajaSel & " and cc.id=" & idCierreSel & ")"
            Else
                SqlTEXT = "select ie.fecha, 
		case ie.tipo
			When 1 Then (
				Select concat(ic.concepto,' - ', cl.nomapell_razon) from  fact_ingresos_concepto as ic,  
                fact_facturas as fact, fact_clientes as cl 
                where ic.id=ie.concepto and ie.comprobante=fact.id and
                cl.idclientes=fact.id_cliente                
                ) 
			when 2 then (
				select concat(ec.concepto,' - ',prov.razon) from fact_egresos_concepto  as ec, 
				fact_proveedores_fact as fact, fact_proveedores as prov 
				where ec.id=ie.concepto and ie.comprobante=fact.id and fact.idproveedor=prov.id) 
			end as concepto, 
        case ie.tipo
			When 1 Then (
				Select concat(tip.abrev,' - ',lpad(fac.ptovta,'3','0'),'-',lpad(fac.num_fact,'8','0')) 
				from fact_facturas as fac, fact_conffiscal as tip ,  fact_puntosventa as ptovta
				where  tip.donfdesc=fac.tipofact and ptovta.id=tip.ptovta and fac.ptovta=ptovta.id and fac.id=ie.comprobante 
				and ie.tipo=1 )  
			when 2 then (select concat(tip.abrev,' - ',fac.numero) 
				from fact_proveedores_fact as fac, fact_conffiscal as tip, fact_puntosventa as ptovta
				where tip.donfdesc=fac.tipo and fac.id=ie.comprobante and tip.ptovta=left(fac.numero,4) 
				and ptovta.id=tip.ptovta and ie.tipo=2) 
			end as detalles,  
				format(replace(ie.monto,',','.'),2,'es_AR') AS MONTO, ie.tipo,ie.descripcion 
				from fact_ingreso_egreso as ie where ie.caja= " & idCajaSel & "
				and ie.fecha >(select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & idCajaSel & ")"
            End If
            'MsgBox(SqlTEXT)
            Dim consultacaja As New MySql.Data.MySqlClient.MySqlDataAdapter(SqlTEXT, conexionPrinc)
            Dim tablacaja As New DataTable
            Dim infocaja() As DataRow
            consultacaja.Fill(tablacaja)
            infocaja = tablacaja.Select()
            Dim i As Integer

            For i = 0 To infocaja.GetUpperBound(0)
                If infocaja(i)("tipo") = 1 Then   'INGRESOS
                    ingresos = ingresos + (infocaja(i)("MONTO")) 'remplazarcoma(infocaja(i)(3))
                    saldoCaja = ingresos - egresos
                    dtcaja.Rows.Add(infocaja(i)("fecha"), infocaja(i)("concepto") & "(" & infocaja(i)("descripcion") & ")", infocaja(i)("detalles"), infocaja(i)("MONTO"), "0", FormatNumber(saldoCaja, 2))
                ElseIf infocaja(i)("tipo") = 2 Then 'EGRESOS
                    egresos = egresos + (infocaja(i)("MONTO")) 'remplazarcoma(infocaja(i)(3))
                    saldoCaja = ingresos - egresos
                    dtcaja.Rows.Add(infocaja(i)("fecha"), infocaja(i)("concepto") & "(" & infocaja(i)("descripcion") & ")", infocaja(i)("detalles"), "0", infocaja(i)("MONTO"), FormatNumber(saldoCaja, 2))
                End If
            Next
            dttotales.Rows.Clear()
            dttotales.Rows.Add("", "", "TOTALES", FormatNumber(ingresos, 2), FormatNumber(egresos, 2), FormatNumber(saldoCaja, 2))
            dttotales.Rows(dttotales.RowCount - 1).DefaultCellStyle.BackColor = Color.YellowGreen
            dttotales.Rows(dttotales.RowCount - 1).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdnuevomov_Click(sender As Object, e As EventArgs) Handles cmdnuevomov.Click
        Dim i As Integer
        For i = 0 To frmprincipal.MdiChildren.Length - 1
            If frmprincipal.MdiChildren(i).Name = "movimientocaja" Then
                frmprincipal.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim mov As New movimientodecaja
        mov.MdiParent = Me.MdiParent
        mov.Show()
    End Sub

    Private Sub cmbcajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcajas.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        CargarCaja(False)
    End Sub

    Private Sub chkfiltrofecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkfiltrofecha.CheckedChanged
        If CType(sender, CheckBox).Checked = True Then
            cmbcierresCajas.Enabled = True
        Else
            cmbcierresCajas.Enabled = False
        End If
    End Sub

    Private Sub Cmbcajas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbcajas.SelectedValueChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If chkfiltrofecha.CheckState = True Then
            CargarCaja(True)
        Else
            CargarCaja(False)
        End If


    End Sub

    Private Sub cmbcierresCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcierresCajas.SelectedIndexChanged

    End Sub

    Private Sub cmbcierresCajas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcierresCajas.SelectionChangeCommitted
        CargarCaja(True)
    End Sub
End Class