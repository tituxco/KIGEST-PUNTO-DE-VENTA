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
            cmbcajas.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbcajas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcajas.SelectionChangeCommitted
        Try
            CargarCaja()
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
            CargarCaja()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarCaja()
        Dim egresos As Double = 0
        Dim ingresos As Double = 0
        saldoCaja = 0

        Dim ultimoCierr As String
        Dim fechacaja As String
        If chkfiltrofecha.Checked = True Then
            fechacaja = " and cc.fecha <='" & Format(DateAdd(DateInterval.Day, 1, dtpfechacaja.Value), "yyyy-MM-dd") & "'"
            MsgBox(fechacaja)
        End If

        dtcaja.Rows.Clear()
        Reconectar()
        Dim consultacierre As New MySql.Data.MySqlClient.MySqlDataAdapter("select fecha, monto from fact_cajas_cierres where caja=" & cmbcajas.SelectedValue & " and fecha=(select max(cc.fecha)from fact_cajas_cierres as cc where cc.caja=" & cmbcajas.SelectedValue & fechacaja & ")", conexionPrinc)
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

        Reconectar()
        Dim consultacaja As New MySql.Data.MySqlClient.MySqlDataAdapter("select ie.fecha, case ie.tipo " _
        & " when 1 then (select ic.concepto from  fact_ingresos_concepto  as ic where ic.id=ie.concepto) " _
        & " when 2 then (select concat(ec.concepto,'(',ie.descripcion,')') from fact_egresos_concepto  as ec where ec.id=ie.concepto) end as concepto, case ie.tipo " _
        & " when 1 then (select concat(tip.abrev,' - ',lpad(fac.ptovta,'3','0'),'-',lpad(fac.num_fact,'8','0')) from fact_facturas as fac, fact_conffiscal as tip where tip.donfdesc=fac.tipofact and fac.id=ie.comprobante)  " _
        & " when 2 then (select concat(tip.abrev,' - ',fac.numero) from fact_proveedores_fact as fac, fact_conffiscal as tip where tip.donfdesc=fac.tipo and fac.id=ie.comprobante) end as detalles,  format(ie.monto,2,'es_AR'), ie.tipo from fact_ingreso_egreso as ie where ie.caja= " & cmbcajas.SelectedValue _
        & " and ie.fecha >(select max(cc.fecha) from fact_cajas_cierres as cc where cc.caja=" & cmbcajas.SelectedValue & fechacaja & ")", conexionPrinc)
        Dim tablacaja As New DataTable
        Dim infocaja() As DataRow
        consultacaja.Fill(tablacaja)
        infocaja = tablacaja.Select()
        Dim i As Integer

        For i = 0 To infocaja.GetUpperBound(0)
            If infocaja(i)(4) = 1 Then
                ingresos = ingresos + (infocaja(i)(3)) 'remplazarcoma(infocaja(i)(3))
                saldoCaja = ingresos - egresos
                dtcaja.Rows.Add(infocaja(i)(0), infocaja(i)(1), infocaja(i)(2), infocaja(i)(3), "0", FormatNumber(saldoCaja, 2))
            ElseIf infocaja(i)(4) = 2 Then
                egresos = egresos + (infocaja(i)(3)) 'remplazarcoma(infocaja(i)(3))
                saldoCaja = ingresos - egresos
                dtcaja.Rows.Add(infocaja(i)(0), infocaja(i)(1), infocaja(i)(2), "0", infocaja(i)(3), FormatNumber(saldoCaja, 2))
            End If
        Next
        dttotales.Rows.Clear()
        dttotales.Rows.Add("", "", "TOTALES", FormatNumber(ingresos, 2), FormatNumber(egresos, 2), FormatNumber(saldoCaja, 2))
        dttotales.Rows(dttotales.RowCount - 1).DefaultCellStyle.BackColor = Color.YellowGreen
        dttotales.Rows(dttotales.RowCount - 1).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CargarCaja()
    End Sub

    Private Sub chkfiltrofecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkfiltrofecha.CheckedChanged
        If dtpfechacaja.Enabled = False Then
            dtpfechacaja.Enabled = True
        Else
            dtpfechacaja.Enabled = False
        End If
    End Sub
End Class