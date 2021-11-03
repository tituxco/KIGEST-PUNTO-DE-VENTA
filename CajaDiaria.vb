
Public Class CajaDiaria
    Dim saldoCaja As Double = 0
    Dim CajaDef As Integer = My.Settings.CajaDef
    Private Sub CajaDiaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tablacierres As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, fecha from fact_cajas_cierres where caja=" & CajaDef & " order by id desc", conexionPrinc)
        Dim readcierres As New DataSet
        tablacierres.Fill(readcierres)
        cmbcierresCajas.DataSource = readcierres.Tables(0)
        cmbcierresCajas.DisplayMember = readcierres.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbcierresCajas.ValueMember = readcierres.Tables(0).Columns(0).Caption.ToString
        cmbcierresCajas.SelectedIndex = 0 'My.Settings.CajaDef
        CargarCaja(False)

        If InStr(DatosAcceso.Moduloacc, "4bba") = False Then cmdnuevomov.Visible = False
        'If InStr(DatosAcceso.Moduloacc, "4bba") = False Then grpdetalleCaja.Visible = False

    End Sub
    Private Sub CargarCaja(historial As Boolean)
        Dim egresos As Double = 0
        Dim ingresos As Double = 0

        Dim totalesEfectivo As Double = 0
        Dim totalesCheques As Double = 0
        Dim totalesTarjetas As Double = 0

        Dim idCierreSel As Integer = cmbcierresCajas.SelectedValue
        saldoCaja = 0

        Dim ultimoCierr As String
        Dim fechacaja As String
        'If chkfiltrofecha.Checked = True Then
        '    fechacaja = " and cc.fecha <='" & Format(DateAdd(DateInterval.Day, 1, dtpfechacaja.Value), "yyyy-MM-dd") & "'"
        '    MsgBox(fechacaja)
        'End If
        Dim SQLARQUEO As String = ""
        Dim SQLCAJA As String = ""
        Dim SQLtarjetas As String = ""
        Dim SQLcheques As String = ""
        dtcaja.Rows.Clear()
        If historial = True Then
            SQLARQUEO = "select fecha, monto from fact_cajas_cierres where caja=" & CajaDef & " and fecha=(select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & CajaDef & " and cc.id<" & idCierreSel & ")"

        Else
            SQLARQUEO = "select fecha, monto from fact_cajas_cierres where caja=" & CajaDef & " and fecha=(select max(cc.fecha)from fact_cajas_cierres as cc where cc.caja=" & CajaDef & ")"

        End If
        Reconectar()
        Dim consultacierre As New MySql.Data.MySqlClient.MySqlDataAdapter(SQLARQUEO, conexionPrinc)
        Dim tablacierr As New DataTable
        Dim infocierr() As DataRow
        consultacierre.Fill(tablacierr)

        If tablacierr.Rows.Count = 0 Then
            'ultimoCierr = "%%%%-%%-%%"
        Else
            infocierr = tablacierr.Select()
            'ultimoCierr = Format(CDate(tablacierr(0)(0).ToString), "yyyy-MM-dd")
            dtcaja.Rows.Add(tablacierr(0)(0), "", "ARQUEO DE CAJA", tablacierr(0)(1), "0")
            ingresos = ingresos + tablacierr(0)(1)
        End If

        If historial = True Then
            SQLCAJA = "select ie.fecha, 
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
				Select concat(tip.abrev,' - ',lpad(fac.ptovta,'3','0'),'-',lpad(fac.num_fact,'8','0')) 				from fact_facturas as fac, fact_conffiscal as tip ,  fact_puntosventa as ptovta
				where  tip.donfdesc=fac.tipofact and ptovta.id=tip.ptovta and fac.ptovta=ptovta.id and fac.id=ie.comprobante 
				and ie.tipo=1 )  
			when 2 then (select concat(tip.abrev,' - ',fac.numero) 
				from fact_proveedores_fact as fac, fact_conffiscal as tip, fact_puntosventa as ptovta
				where tip.donfdesc=fac.tipo and fac.id=ie.comprobante and tip.ptovta=left(fac.numero,4) 
				and ptovta.id=tip.ptovta and ie.tipo=2) 
			end as detalles,  
				format(replace(ie.monto,',','.'),2,'es_AR') AS MONTO, ie.tipo, ie.descripcion
			from fact_ingreso_egreso as ie where ie.caja= " & CajaDef & "
				and ie.fecha between (select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & CajaDef & " and cc.id<" & idCierreSel & ")
                and (select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & CajaDef & " and cc.id=" & idCierreSel & ")"

            SQLtarjetas = "select tar.importe, ie.tipo           
            from fact_ingreso_egreso as ie, fact_tarjetas as tar where ie.caja= " & CajaDef & " and          
            tar.comprobante=ie.comprobante
			and ie.fecha between (select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & CajaDef & " and cc.id<" & idCierreSel & ")
            and (select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & CajaDef & " and cc.id=" & idCierreSel & ")"

            SQLcheques = "select che.importe, ie.tipo                        
            from fact_ingreso_egreso as ie, fact_cheques as che where ie.caja= " & CajaDef & " and
			che.comprobante=ie.comprobante
            and ie.fecha between (select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & CajaDef & " and cc.id<" & idCierreSel & ")
            and (select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & CajaDef & " and cc.id=" & idCierreSel & ")"
        Else

            SQLCAJA = "select ie.fecha, 
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
				from fact_ingreso_egreso as ie where ie.caja= " & CajaDef & "
				and ie.fecha >(select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & CajaDef & ")"

            SQLtarjetas = "select tar.importe, ie.tipo
            from fact_ingreso_egreso as ie, fact_tarjetas as tar where ie.caja= " & CajaDef & "
            and tar.comprobante=ie.comprobante            
				and ie.fecha >(select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & CajaDef & ")"

            SQLcheques = "select che.importe, ie.tipo
            from fact_ingreso_egreso as ie, fact_cheques as che where ie.caja= " & CajaDef & "
            and che.comprobante=ie.comprobante            
				and ie.fecha >(select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & CajaDef & ")"
        End If
        Reconectar()
        Dim consultacaja As New MySql.Data.MySqlClient.MySqlDataAdapter(SQLCAJA, conexionPrinc)
        Dim consultacheques As New MySql.Data.MySqlClient.MySqlDataAdapter(SQLcheques, conexionPrinc)
        Dim consultatarjetas As New MySql.Data.MySqlClient.MySqlDataAdapter(SQLtarjetas, conexionPrinc)
        Dim tablacheques As New DataTable
        Dim tablatarjetas As New DataTable
        Dim tablacaja As New DataTable

        Dim infocaja() As DataRow
        consultacaja.Fill(tablacaja)
        consultacheques.Fill(tablacheques)
        consultatarjetas.Fill(tablatarjetas)
        infocaja = tablacaja.Select()

        For Each Cheque As DataRow In tablacheques.Rows
            If Cheque.Item("tipo") = 1 Then
                totalesCheques += FormatNumber(Cheque.Item("importe"))
            Else
                totalesCheques -= FormatNumber(Cheque.Item("importe"))
            End If
        Next

        For Each tarjetas As DataRow In tablatarjetas.Rows
            If tarjetas.Item("tipo") = 1 Then
                totalesTarjetas += FormatNumber(tarjetas.Item("importe"))
            Else
                totalesTarjetas -= FormatNumber(tarjetas.Item("importe"))
            End If
        Next


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
        lbltarjeta.Text = "TARJETA= $" & totalesTarjetas
        lblcheques.Text = "CHEQUES= $" & totalesCheques
        lblefectivo.Text = "EFECTIVO= $" & saldoCaja - (totalesTarjetas + totalesCheques)
        dttotales.Rows.Clear()
        dttotales.Rows.Add("", "", "TOTALES", FormatNumber(ingresos, 2), FormatNumber(egresos, 2), FormatNumber(saldoCaja, 2))
        dttotales.Rows(dttotales.RowCount - 1).DefaultCellStyle.BackColor = Color.YellowGreen
        dttotales.Rows(dttotales.RowCount - 1).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
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
        mov.cmbcajaeg.Enabled = False
        mov.cmbcajaeg.SelectedValue = My.Settings.CajaDef
        mov.cmbcajas.Enabled = False
        mov.cmbcajas.SelectedValue = My.Settings.CajaDef

    End Sub

    Private Sub cmdcerrarcaja_Click(sender As Object, e As EventArgs) Handles cmdcerrarcaja.Click
        Try
            If chkfiltrofecha.Checked = True Then
                MsgBox("no se puede cerrar caja si tiene el historial activado")
                Exit Sub
            End If
            If MsgBox("Realmente desa realizar el arqueo de caja?", vbYesNo + vbQuestion, "Cierre de caja") = vbYes Then
                Dim fecha As String = Format(Now, "yyyy-MM-dd")
                Dim sqlQuery As String

                Reconectar()
                sqlQuery = "insert into fact_cajas_cierres(monto,caja) values (?monto,?caja)"

                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters
                    .AddWithValue("?monto", FormatNumber(saldoCaja, 2))
                    .AddWithValue("?caja", My.Settings.CajaDef)
                End With
                comandoadd.ExecuteNonQuery()
                MsgBox("El cierre de caja fue exitoso")
                saldoCaja = 0
                CargarCaja(False)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If chkfiltrofecha.Checked = True Then
            CargarCaja(True)
        Else
            CargarCaja(False)
        End If
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GenerarExcel(dtcaja)
    End Sub

    Private Sub chkfiltrofecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkfiltrofecha.CheckedChanged
        If chkfiltrofecha.Checked = True Then
            cmbcierresCajas.Enabled = True
            CargarCaja(True)
        Else
            cmbcierresCajas.Enabled = False
            CargarCaja(False)
        End If
    End Sub
End Class