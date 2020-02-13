Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting


Public Class CONTABLE


    Private Sub CONTABLE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtdesdefact.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
        dtpdecob.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
        dtpdeestado.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
        dtpchequesde.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
        dtpdesdedetallecta.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
        dtdesdecuentaprov.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
        tabplancuentas.Parent = Nothing

        'tabdtostecni.Parent = Nothing
        tablibromayor.Parent = Nothing
        'tabgraficas.Parent = Nothing

        If InStr(DatosAcceso.Moduloacc, "4aa") = False Then tabcomprobantes.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ab") = False Then tabcobranzas.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ac") = False Then balance.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ad") = False Then tabremitos.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ae") = False Then tabcheques.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4af") = False Then tabchequespropios.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ag") = False Then tabestadocuentas.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ah") = False Then tabcuentasclientes.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ai") = False Then tabcuentasproveedores.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "2d") = False Then tabstockvalorizado.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4aa-4ab") = False Then tabgraficas.Parent = Nothing

        If InStr(DatosAcceso.Moduloacc, "5") = False Then tabdtostecni.Parent = Nothing

        ' tabgraficas.Parent = Nothing
        cargarDatosGrales()
    End Sub

    Private Sub cargarDatosGrales()
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

            Dim tablaftipo As New MySql.Data.MySqlClient.MySqlDataAdapter("select donfdesc, concat('<',ptovta,'>','-',abrev) from tipos_comprobantes where tip=1 order by ptovta, id", conexionPrinc)
            Dim readftipo As New DataSet
            tablaftipo.Fill(readftipo)
            cmbtipofac.DataSource = readftipo.Tables(0)
            cmbtipofac.DisplayMember = readftipo.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbtipofac.ValueMember = readftipo.Tables(0).Columns(0).Caption.ToString
            cmbtipofac.SelectedIndex = -1

            Dim tablavend As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,', ', nombre) from fact_vendedor where activo=1", conexionPrinc)
            Dim readvend As New DataSet
            tablavend.Fill(readvend)
            cmbvendedor.DataSource = readvend.Tables(0)
            cmbvendedor.DisplayMember = readvend.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbvendedor.ValueMember = readvend.Tables(0).Columns(0).Caption.ToString
            'cmbvendedor.SelectedIndex = -1

            cmbvendedorctacte.DataSource = readvend.Tables(0)
            cmbvendedorctacte.DisplayMember = readvend.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbvendedorctacte.ValueMember = readvend.Tables(0).Columns(0).Caption.ToString
            'cmbvendedorctacte.SelectedIndex = -1

            cmbcobvendedor.DataSource = readvend.Tables(0)
            cmbcobvendedor.DisplayMember = readvend.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcobvendedor.ValueMember = readvend.Tables(0).Columns(0).Caption.ToString
            'cmbcobvendedor.SelectedIndex = -1


        Catch ex As Exception

        End Try
        EnProgreso.Close()
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
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
        Dim columna As Integer
        Try

            Dim desde As String = Format(CDate(dtdesdefact.Value), "yyyy-MM-dd")
            Dim hasta As String = Format(CDate(dthastafact.Value), "yyyy-MM-dd")
            Dim parambusq As String = ""

            If cmbtipofac.SelectedValue = 0 And chktodosfact.Checked = False Then
                MsgBox("No selecciono tipo de factura")
                EnProgreso.Close()
                Exit Sub
            ElseIf cmbtipofac.SelectedValue <> 0 And chktodosfact.Checked = False Then
                Dim SelPtoVta As String = cmbtipofac.Text.ToString.Substring(1, 1)

                parambusq = " and fact.tipofact=" & cmbtipofac.SelectedValue & " and fact.ptovta=" & SelPtoVta
            ElseIf cmbtipofac.SelectedValue = 0 And chktodosfact.Checked = True Then
                parambusq = " and fact.tipofact in( select donfdesc from tipos_comprobantes where debcred like 'D')"
            End If
            If grpagrupar.Enabled = True Then
                If chktodosvendedores.Checked = False And cmbvendedor.SelectedValue = 0 Then
                    MsgBox("debe seleccionar un vendedor")
                    EnProgreso.Close()
                    Exit Sub
                ElseIf chktodosvendedores.Checked = False And cmbvendedor.SelectedValue <> 0 Then
                    parambusq &= " and fact.vendedor=" & cmbvendedor.SelectedValue
                End If

                If chkctactlievtas.Checked = True And txtctaclievtas.Text = "" Then
                    MsgBox("Ingrese el numero de cuenta del cliente")
                    EnProgreso.Close()
                    Exit Sub
                ElseIf chkctactlievtas.Checked = True And Val(txtctaclievtas.Text) = 0 Then
                    MsgBox("No es una cuenta de cliente valida")
                    EnProgreso.Close()
                    Exit Sub
                ElseIf chkctactlievtas.Checked = True And Val(txtctaclievtas.Text) <> 0 Then
                    parambusq &= " and fact.id_cliente=" & txtctaclievtas.Text
                End If
            End If

            Reconectar()
            Dim tablaprod As New DataTable
            'Dim filasProd() As DataRow
            If rdninguno.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
                fact.id, concat(fis.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) as factnum ,fact.fecha,fact.razon,fact.direccion, 
                fact.localidad, con.condicion, 
                case when fis.debcred='C' then 
                concat('-',FORMAT(fact.total,2,'es_AR')) 
                else FORMAT(fact.total,2,'es_AR') end as total, fact.observaciones2, fact.tipofact, fact.ptovta
                from fact_conffiscal as fis, fact_facturas as fact, fact_condventas as con 
                where fis.donfdesc=fact.tipofact and con.id=fact.condvta and fis.ptovta=fact.ptovta
                and fact.fecha between '" & desde & "' and '" & hasta & "'" & parambusq, conexionPrinc)
                columna = 7
                consulta.Fill(tablaprod)
            End If
            If rdventadiaria.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
                '' as factid, 'TOTAL DIARIO' as factnum ,fact.fecha,'-' as razon,'-' as direccion, 
                '-' as localidad, '-' as condicion, 
                case when fis.debcred='C' then 
                concat('-',FORMAT(sum(fact.total),2,'es_AR')) 
                else FORMAT(sum(fact.total),2,'es_AR') end as total, 
                '' as observaciones2, fact.tipofact from fact_conffiscal as fis, fact_facturas as fact, fact_condventas as con 
                where fis.donfdesc=fact.tipofact and con.id=fact.condvta  
                and fact.fecha between '" & desde & "' and '" & hasta & "'" & parambusq & " group by fact.fecha", conexionPrinc)
                columna = 7
                consulta.Fill(tablaprod)


            End If


            Dim i As Integer


            dtfacturas.DataSource = tablaprod
            dtfacturas.Columns(0).Visible = False
            dtfacturas.Columns(9).Visible = False
            dtfacturas.Columns(10).Visible = False
            lbltotalfact.Text = SumarTotal(dtfacturas, columna)

            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub

    Public Sub cargarCuentaClie(ByRef idcliente As Integer)
        Dim debegral As Double = 0
        Dim habergral As Double = 0
        Dim saldo As Double = 0
        Dim saldoant As Double = 0
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
            Dim consultaclie As New MySql.Data.MySqlClient.MySqlDataAdapter("select clie.nomapell_razon as razon," _
            & " concat(clie.dir_domicilio, ' - ',loc.nombre, '  ', ivt.tipo,' CUIT: ', clie.cuit) from fact_clientes as clie,  cm_localidad as  loc,  fact_ivatipo as ivt " _
            & " where clie.dir_localidad=loc.id and clie.iva_tipo=ivt.id and idclientes=" & idcliente, conexionPrinc)

            Dim tablaclie As New DataTable
            consultaclie.Fill(tablaclie)
            Dim dtocli() As DataRow
            dtocli = tablaclie.Select("razon like '%'")
            lblclientecta.Text = dtocli(0)(0)
            lbldtoscliecta.Text = dtocli(0)(1)


            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cuentaclie where id_cliente=" & Val(txtcuentabus.Text), conexionPrinc)

            Dim tabla As New DataTable
            consulta.Fill(tabla)
            Dim tablacta() As DataRow
            tablacta = tabla.Select("")

            Dim i As Integer
            dtcuentaclie.Rows.Clear()
            For i = 0 To tablacta.GetUpperBound(0)
                Dim fechacomprob As Date = CType(tablacta(i)(1).ToString, Date)
                Dim fechainicio As Date = CType(dtpdesdedetallecta.Value, Date)
                Dim dias As Integer = DateDiff(DateInterval.Day, fechacomprob, fechainicio)
                Select Case tablacta(i)(6)
                    Case 1 To 3, 8, 11, 13, 14, 17, 18, 29, 30
                        If dias <= 0 Then
                            debegral += tablacta(i)(5)
                            saldo = FormatNumber(debegral - habergral, 2)
                            dtcuentaclie.Rows.Add(tablacta(i)(0), tablacta(i)(1).ToString, tablacta(i)(2) & " " & tablacta(i)(3) & "-" & tablacta(i)(4), tablacta(i)(5), "0", saldo, tablacta(i)(8), tablacta(i)(6))
                            If tablacta(i)(7) = 1 Then
                                dtcuentaclie.Rows(dtcuentaclie.RowCount - 1).DefaultCellStyle.BackColor = Color.GreenYellow
                            End If
                        Else
                            debegral += tablacta(i)(5)
                            saldoant = FormatNumber(debegral - habergral, 2)
                        End If

                    Case 4, 5, 10, 12, 15, 16
                        If dias <= 0 Then
                            habergral += tablacta(i)(5)
                            saldo = FormatNumber(debegral - habergral, 2)
                            dtcuentaclie.Rows.Add(tablacta(i)(0), tablacta(i)(1).ToString, tablacta(i)(2) & " " & tablacta(i)(3) & "-" & tablacta(i)(4), "0", tablacta(i)(5), saldo, tablacta(i)(8), tablacta(i)(6))
                            dtcuentaclie.Rows(dtcuentaclie.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        Else
                            habergral += tablacta(i)(5)
                            saldoant = FormatNumber(debegral - habergral, 2)
                        End If
                End Select

            Next
            lblsaldoanterior.Text = "El saldo anterior a esta fecha es de: $ " & saldoant
            dttotales.Rows.Clear()
            dttotales.Rows.Add("", "", "TOTALES", FormatNumber(debegral, 2), FormatNumber(habergral, 2), saldo)
            dttotales.Rows(dttotales.RowCount - 1).DefaultCellStyle.BackColor = Color.YellowGreen
            dttotales.Rows(dttotales.RowCount - 1).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            dtcuentaclie.Columns(0).Visible = False
            dtcuentaclie.Columns(6).Visible = False
            dtcuentaclie.Columns(7).Visible = False
            'dtcuentaclie.Rows(dtcuentaclie.RowCount - 1).Frozen = True
            EnProgreso.Close()

        Catch ex As Exception
            EnProgreso.Close()
        End Try
    End Sub

    Public Sub cargarCuentaProv(ByRef idprov As Integer)
        Dim debegral As Double = 0
        Dim habergral As Double = 0
        Dim saldo As Double = 0
        Dim saldoant As Double = 0
        Try
            Reconectar()
            Dim consultaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select razon," _
            & " direccion from fact_proveedores as clie,  fact_ivatipo as ivt " _
            & " where clie.tipo_iva=ivt.id and clie.id=" & idprov, conexionPrinc)

            Dim tablaprov As New DataTable
            consultaprov.Fill(tablaprov)
            Dim dtoprov() As DataRow
            dtoprov = tablaprov.Select()
            lblproveedorcuenta.Text = dtoprov(0)(0)
            lbldatoscuentaprov.Text = dtoprov(0)(1)

            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cuentaprov where idproveedor=" & idprov, conexionPrinc)

            Dim tabla As New DataTable
            consulta.Fill(tabla)
            Dim tablacta() As DataRow
            tablacta = tabla.Select("")

            Dim i As Integer
            dtcuentaprov.Rows.Clear()
            'MsgBox(tabla.Rows.Count)
            For i = 0 To tablacta.GetUpperBound(0)
                Dim fechacomprob As Date = CType(tablacta(i)(1).ToString, Date)
                Dim fechainicio As Date = CType(dtdesdecuentaprov.Value, Date)
                Dim dias As Integer = DateDiff(DateInterval.Day, fechacomprob, fechainicio)
                Select Case tablacta(i)(6)
                    Case 1, 2, 3, 4
                        If dias <= 0 Then
                            debegral = debegral + tablacta(i)(4)
                            saldo = FormatNumber(debegral - habergral, 2)
                            dtcuentaprov.Rows.Add(tablacta(i)(0), tablacta(i)(1).ToString, tablacta(i)(3), tablacta(i)(4), "0", tablacta(i)(5), saldo)
                            If tablacta(i)(8) = 1 Then
                                dtcuentaprov.Rows(dtcuentaprov.RowCount - 1).DefaultCellStyle.BackColor = Color.GreenYellow
                            End If
                        Else
                            debegral = debegral + tablacta(i)(4)
                            saldoant = FormatNumber(debegral - habergral, 2)
                        End If
                    Case 6
                        If dias <= 0 Then
                            If tablacta(i)(7) = 2 Then
                                habergral = habergral + tablacta(i)(4)
                                saldo = FormatNumber(debegral - habergral, 2)
                                dtcuentaprov.Rows.Add(tablacta(i)(0), tablacta(i)(1).ToString, tablacta(i)(3), "0", tablacta(i)(4), " ", saldo)
                                dtcuentaprov.Rows(dtcuentaprov.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            debegral = debegral - tablacta(i)(4)
                            saldoant = FormatNumber(debegral - habergral, 2)
                        End If

                End Select
            Next
            lblsaldocuentaprov.Text = "El saldo anterior a esta fecha es de: $ " & saldoant
            dttotalesprov.Rows.Clear()
            dttotalesprov.Rows.Add("", "TOTALES", FormatNumber(debegral, 2), FormatNumber(habergral, 2), "", saldo)
            dttotalesprov.Rows(dttotalesprov.RowCount - 1).DefaultCellStyle.BackColor = Color.YellowGreen
            dttotalesprov.Rows(dttotalesprov.RowCount - 1).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            'dtcuentaclie.Rows(dtcuentaclie.RowCount - 1).Frozen = True
            dttotalesprov.ClearSelection()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalcularCuentaCte()
        Dim saldo As Double
        Dim debe As Double
        Dim haber As Double


    End Sub
    Private Sub txtcuentabus_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcuentabus.KeyUp
        If e.KeyCode = Keys.Enter Then
            cargarCuentaClie(Val(txtcuentabus.Text))
        End If
    End Sub

    Private Sub txtcliebus_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcliebus.KeyUp
        If e.KeyCode = Keys.Enter Then
            selclie.busqueda = txtcliebus.Text
            selclie.llama = "ctacte"
            selclie.dtpersonal.Focus()
            selclie.Show()
            selclie.TopMost = True
        End If
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub cmbproveedores_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbproveedores.SelectionChangeCommitted
        cargarCuentaProv(cmbproveedores.SelectedValue)
    End Sub

    Private Sub cargarIngresosMensuales()
        Try
            dtingresos.Rows.Clear()
            Dim totaling As Double
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("Select sum(replace(ie.monto,',','.')),ie.concepto, ie.caja, ca.descripcion, ic.concepto " _
            & "FROM kigest_fact.fact_ingreso_egreso as ie, fact_ingresos_concepto as ic, fact_cajas as ca " _
            & "where ie.tipo=1 and ca.id=ie.caja and ic.id=ie.concepto and ie.fecha like '" & cmbano.Text & "-" & cmbperiodo.Text & "-%%' group by ie.caja, ie.concepto", conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            Dim i As Integer

            For i = 0 To infocl.GetUpperBound(0)
                dtingresos.Rows.Add(infocl(i)(3), infocl(i)(4), infocl(i)(0))
                totaling += infocl(i)(0)
            Next
            lbltotaling.Text = totaling
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarEgresosMensuales()
        Try
            dtegresos.Rows.Clear()
            Dim totaleg As Double
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT sum(replace(ie.monto,',','.')),ie.concepto, ie.caja, ca.descripcion, ec.concepto " _
            & "FROM kigest_fact.fact_ingreso_egreso as ie, fact_egresos_concepto as ec, fact_cajas as ca " _
            & "where ie.tipo=2 and ca.id=ie.caja and ec.id=ie.concepto and ie.fecha like '" & cmbano.Text & "-" & cmbperiodo.Text & "-%%' group by ie.caja, ie.concepto", conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            Dim i As Integer

            For i = 0 To infocl.GetUpperBound(0)
                dtegresos.Rows.Add(infocl(i)(3), infocl(i)(4), infocl(i)(0))
                totaleg += infocl(i)(0)
            Next
            lbltotaleg.Text = totaleg
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbperiodo_TextChanged(sender As Object, e As EventArgs) Handles cmbperiodo.TextChanged
        dtingresos.Rows.Clear()
        dtegresos.Rows.Clear()
        cargarIngresosMensuales()
        cargarEgresosMensuales()
    End Sub

    Private Sub dtingresos_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        'el e.columnindex son las columnas que checara para ver si se pueden combinar las celdas iguales
        ' en este caso checara las 4
        Try
            If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 AndAlso e.RowIndex <> -1 Then

                Using gridBrush As Brush = New SolidBrush(Me.dtingresos.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                    Using gridLinePen As Pen = New Pen(gridBrush)
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                        If e.RowIndex < dtingresos.RowCount - 1 AndAlso dtingresos.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                        End If
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
                        If Not e.Value Is Nothing Then
                            If e.RowIndex > 0 AndAlso dtingresos.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then
                            Else
                                e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                            End If
                        End If

                        e.Handled = True
                    End Using
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtegresos_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        'el e.columnindex son las columnas que checara para ver si se pueden combinar las celdas iguales
        ' en este caso checara las 4
        Try
            If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 AndAlso e.RowIndex <> -1 Then

                Using gridBrush As Brush = New SolidBrush(Me.dtegresos.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                    Using gridLinePen As Pen = New Pen(gridBrush)
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                        If e.RowIndex < dtegresos.RowCount - 1 AndAlso dtegresos.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                        End If
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
                        If Not e.Value Is Nothing Then
                            If e.RowIndex > 0 AndAlso dtegresos.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then
                            Else
                                e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)
                            End If
                        End If

                        e.Handled = True
                    End Using
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cargarEstadodeCuentas()
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
        Dim desde As String
        Dim hasta As String
        Dim vendedor As String
        If CheckBox1.Checked = False Then
            desde = Format(CDate(dtpdeestado.Value), "yyyy-MM-dd")
            hasta = Format(CDate(dtphastaestado.Value), "yyyy-MM-dd")
        Else
            desde = "%%%%-%%-%%"
            hasta = Format(CDate(dtphastaestado.Value), "yyyy-MM-dd")
        End If

        If chkvendedorctacte.Checked = True Then
            vendedor = "%"
        Else
            vendedor = cmbvendedorctacte.SelectedValue
        End If

        Try
            Dim consultaComp As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from debe_cliente", conexionPrinc)


            Dim consultaCobr As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from haber_cliente", conexionPrinc)


            Dim tablacomp As New DataTable
            Dim tablacobr As New DataTable

            consultaComp.Fill(tablacomp)
            consultaCobr.Fill(tablacobr)

            Dim filaComp() As DataRow = tablacomp.Select()
            Dim filaCobr() As DataRow = tablacobr.Select()

            'creamos la tabla de datos para las cuentas
            Dim estadocuentas As New DataTable
            Dim columestado As DataColumn
            Dim filaestado As DataRow

            columestado = New DataColumn
            columestado.DataType = System.Type.GetType("System.String")
            columestado.ColumnName = "Cuenta"
            estadocuentas.Columns.Add(columestado)

            columestado = New DataColumn
            columestado.DataType = System.Type.GetType("System.String")
            columestado.ColumnName = "Razon Social"
            estadocuentas.Columns.Add(columestado)

            columestado = New DataColumn
            columestado.DataType = System.Type.GetType("System.Decimal")
            columestado.ColumnName = "Saldo"
            estadocuentas.Columns.Add(columestado)

            For Each fila As DataRow In tablacomp.Rows


                'MsgBox(filapago(0).Item(2))
                filaestado = estadocuentas.NewRow
                filaestado(0) = fila.Item(0)
                filaestado(1) = fila.Item(1)
                Dim saldo As Double
                Dim filapago() As Data.DataRow
                filapago = tablacobr.Select("cuenta like '" & fila(0) & "'")
                If filapago.Length = 0 Then
                    saldo = fila.Item(2)
                Else
                    saldo = Math.Round(fila.Item(2) - filapago(0).Item(2), 2)
                End If
                filaestado(2) = saldo
                If chknegativos.Checked = True And saldo > 0 Then
                    estadocuentas.Rows.Add(filaestado)
                ElseIf chknegativos.Checked = False And saldo <> 0 Then
                    estadocuentas.Rows.Add(filaestado)
                End If
            Next
            dtestadocuentas.DataSource = estadocuentas
            dtestadocuentas.Columns(0).FillWeight = 30
            dtestadocuentas.Columns(2).FillWeight = 30
            SumarTotal(dtestadocuentas, 2)
            EnProgreso.Close()
        Catch ex As Exception
            EnProgreso.Close()
        End Try

    End Sub

    Private Sub cargarStockValorizado()
        Try
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
            cat.nombre as Categoria, 
            round(sum((select round(sum(replace(precio,',','.')*mon.cotizacion),2) from fact_insumos where moneda=mon.id and id=prod.id)* 
            (select sum(stock) from fact_insumos_lotes where idproducto=prod.id)),2) as Saldo
            from fact_insumos as prod, fact_moneda as mon, fact_categoria_insum as cat, fact_insumos_lotes as st 
            where cat.id=prod.categoria and mon.id=prod.moneda and st.stock>0 and st.idproducto=prod.id group by cat.nombre order by cat.nombre asc", conexionPrinc)

            Dim tablastock As New DataTable
            consulta.Fill(tablastock)
            'infoestado = tablaestado.Select()
            dtstockvalorizado.DataSource = tablastock


        Catch ex As Exception

        End Try

    End Sub


    Private Sub dtestadocuentas_DoubleClick(sender As Object, e As EventArgs) Handles dtestadocuentas.DoubleClick
        Try
            txtcuentabus.Text = dtestadocuentas.CurrentRow.Cells(0).Value
            cargarCuentaClie(Val(dtestadocuentas.CurrentRow.Cells(0).Value))
            tabcontable.SelectedTab = tabcuentasclientes
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim idFactura As Integer = dtfacturas.CurrentRow.Cells(0).Value
        Try
            If My.Settings.ImprTikets = 1 Then
                Dim PrintTxt As New PrintDocument
                Dim pgSize As New PaperSize
                pgSize.RawKind = Printing.PaperKind.Custom
                pgSize.Width = 147 '196.8 '
                'pgSize.Height = 173.23 '100
                PrintTxt.DefaultPageSettings.PaperSize = pgSize
                ' evento print

                AddHandler PrintTxt.PrintPage, AddressOf ImprimirTiketFiscal
                PrintTxt.PrinterSettings.PrinterName = My.Settings.ImprTiketsNombre
                PrintTxt.Print()

            Else

                'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
                Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
                Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
                Dim fac As New datosfacturas

                Reconectar()

                tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
            emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
            emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, 
            concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.fecha as facfech, 
            concat(fac.id_cliente,'-',fac.razon) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, 
            concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21,
            '','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra 
            FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac,fact_condventas as condvent  
            where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and fac.ptovta=fis.ptovta and condvent.id=fac.condvta and fac.id=" & idFactura, conexionPrinc)

                tabEmp.Fill(fac.Tables("factura_enca"))
                Reconectar()

                tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal 
            from fact_items where id_fact=" & idFactura, conexionPrinc)

                tabFac.Fill(fac.Tables("facturax"))
                'buscamos el punto de venta el que pertenece el comprobante
                Dim ptovta As Integer
                'Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select ptovta from fact_conffiscal where donfdesc=" & dtfacturas.CurrentRow.Cells(9).Value, conexionPrinc)
                'Dim tablacl As New DataTable
                'Dim infocl() As DataRow
                'consulta.Fill(tablacl)
                'infocl = tablacl.Select("")
                'ptovta = infocl(0)(0)
                ptovta = dtfacturas.CurrentRow.Cells(10).Value
                Dim imprimirx As New imprimirFX
                With imprimirx
                    .MdiParent = Me.MdiParent
                    .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                    'MsgBox(FacturaElectro.puntovtaelect)
                    If ptovta <> FacturaElectro.puntovtaelect Then
                        Select Case ptovta
                            Case 1
                                Select Case dtfacturas.CurrentRow.Cells(9).Value
                                    Case 1, 3
                                        .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturaleg.rdlc"
                                    Case 999
                                        .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturax.rdlc"
                                    Case 3
                                        .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\notacredleg.rdlc"
                                    Case 991
                                        .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturax.rdlc"
                                End Select
                        End Select
                    Else
                        .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturaelectro.rdlc"
                    End If

                    .rptfx.LocalReport.DataSources.Clear()
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("facturax")))
                    .rptfx.DocumentMapCollapsed = True
                    .rptfx.RefreshReport()
                    .Show()
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ImprimirTiketFiscal(ByVal sender As System.Object, ByVal e As PrintPageEventArgs)
        ' letra
        'Dim font1 As New Font("EAN-13", 40)

        Dim idFactura As Integer = dtfacturas.CurrentRow.Cells(0).Value
        Dim printfont As New Font("Courier New", 6)
        Dim font3 As New Font("Courier New", 8)
        Dim font4 As New Font("Courier New", 18)
        Dim font5 As New Font("Courier New", 6)

        Dim alto As Single = 0
        Dim topMargin As Double '= e.MarginBounds.Top
        Dim yPos As Integer = 0
        Dim count As Integer = 0
        Dim texto As String = ""

        Dim codigo As String = ""
        Dim unidad As String = ""
        Dim detalle As String = ""
        Dim valoruni As String = ""
        Dim valortot As String = ""
        Dim tabulacion As String = ""
        Dim compensador As Integer = 0
        Dim total As String = ""
        Dim lvalor As String
        Dim lineatotal As String
        Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ivaProd As String = ""
        Dim fac As New datosfacturas

        Dim facTotal As String = ""
        Dim facSubtotal As String = ""
        Dim FacIva21 As String = ""
        Dim FacIva105 As String = ""


        Reconectar()

        tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
        emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
        emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, 
        concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.fecha as facfech, 
        concat(fac.id_cliente,'-',fac.razon) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, 
        concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21,
        '','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra, format(fac.total,2,'es_AR'),format(fac.subtotal,2,'es_AR')   
        FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac,fact_condventas as condvent  
        where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and condvent.id=fac.condvta and fac.id=" & IdFactura, conexionPrinc)

        Dim tablaEmpresa As New DataTable
        tabEmp.Fill(tablaEmpresa)

        Reconectar()

        tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal 
            from fact_items where id_fact=" & IdFactura, conexionPrinc)
        Dim tablaProd As New DataTable
        tabFac.Fill(tablaProd)

        facTotal = tablaEmpresa.Rows(0).Item(30)
        facSubtotal = tablaEmpresa.Rows(0).Item(31)
        FacIva21 = tablaEmpresa.Rows(0).Item(21)
        FacIva105 = ""

        Dim factCAE As String = tablaEmpresa.Rows(0).Item(29)


        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(1), font5, Brushes.Black, 0, 100) 'RAZON SOCIAL
        e.Graphics.DrawString("CUIT Nro: " & tablaEmpresa.Rows(0).Item(4), font5, Brushes.Black, 0, 110) '
        e.Graphics.DrawString("Ing. Brutos: " & tablaEmpresa.Rows(0).Item(5).ToString, font5, Brushes.Black, 0, 120) '
        e.Graphics.DrawString("Domicilio: " & tablaEmpresa.Rows(0).Item(2), font5, Brushes.Black, 0, 130)
        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(3), font5, Brushes.Black, 0, 140) '
        e.Graphics.DrawString("Inicio de actividades: " & tablaEmpresa.Rows(0).Item(7), font5, Brushes.Black, 0, 150)
        e.Graphics.DrawString("IVA " & tablaEmpresa.Rows(0).Item(6), font5, Brushes.Black, 0, 160)

        e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 170)
        e.Graphics.DrawString("FACTURA '" & tablaEmpresa.Rows(0).Item(26) & "' (" & tablaEmpresa.Rows(0).Item(27) & ")", font5, Brushes.Black, 0, 180)
        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(10).ToString, font5, Brushes.Black, 0, 190)
        e.Graphics.DrawString("Fecha: " & tablaEmpresa.Rows(0).Item(11).ToString, font5, Brushes.Black, 0, 200)
        e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 210)

        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(12), font5, Brushes.Black, 0, 220)
        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(13), font5, Brushes.Black, 0, 230)
        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(14), font5, Brushes.Black, 0, 240)
        e.Graphics.DrawString("CUIT Nro: " & tablaEmpresa.Rows(0).Item(16), font5, Brushes.Black, 0, 250)
        e.Graphics.DrawString("IVA " & tablaEmpresa.Rows(0).Item(15), font5, Brushes.Black, 0, 260)
        e.Graphics.DrawString("CONDICION DE VENTA " & tablaEmpresa.Rows(0).Item(18), font5, Brushes.Black, 0, 270)
        e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 280)

        Dim i As Integer
        Dim j As Integer
        Dim car As Integer

        For i = 0 To tablaProd.Rows.Count - 1
            codigo = tablaProd.Rows(i).Item(0)
            unidad = tablaProd(i).Item(1)
            detalle = tablaProd(i).Item(2)
            valoruni = tablaProd(i).Item(4)
            valortot = FormatNumber(tablaProd(i).Item(5), 2)
            ivaProd = tablaProd(i).Item(3)
            texto = unidad & " x " & valoruni & Chr(9) & "  (" & ivaProd & ")"
            yPos = 290 + topMargin + (count * printfont.GetHeight(e.Graphics)) ' Calcula la posición en la que se escribe la línea            


            If detalle.Length <= 25 Then
                car = 25 - detalle.Length
                For j = 0 To car
                    detalle &= " "
                Next
            Else
                car = detalle.Length - 25
                detalle = detalle.Remove(26, car - 1)
            End If

            If valortot.Length <= 7 Then
                car = 7 - valortot.Length
                For j = 0 To car
                    valortot = " " & valortot
                Next

            End If


            'If Not row.IsNewRow Then
            e.Graphics.DrawString(texto, printfont, System.Drawing.Brushes.Black, 0, yPos)
            count += 1
            yPos = yPos + 10
            e.Graphics.DrawString(detalle & "  " & valortot, printfont, System.Drawing.Brushes.Black, 0, yPos)
            'total += valor
            'End If
            count += 1

        Next
        If FacIva21.Length <= 7 Then
            car = 7 - FacIva21.Length
            For j = 0 To car
                FacIva21 = " " & FacIva21
            Next

        End If


        If facSubtotal.Length <= 7 Then
            car = 7 - facSubtotal.Length
            For j = 0 To car
                facSubtotal = " " & facSubtotal
            Next
        End If

        If facTotal.Length <= 7 Then
            car = 7 - facTotal.Length
            For j = 0 To car
                facTotal = " " & facTotal
            Next
        End If




        yPos += 20
        Dim textosub As String = "Subtotal"
        Dim textoIva21 As String = "Alicuota 21%"
        Dim textoTotal As String = "Total"



        Dim lineaSep = StrDup(27, " ")
        e.Graphics.DrawString(lineaSep & "__________", printfont, System.Drawing.Brushes.Black, 0, yPos)
        Dim XXX As Integer = 0

        XXX = 27 - (textosub.Length + facSubtotal.Length)
        lineatotal = StrDup(XXX, ".")
        yPos += 10
        e.Graphics.DrawString(textosub & lineatotal & facSubtotal, font3, System.Drawing.Brushes.Black, 0, yPos)

        XXX = 27 - (textoIva21.Length + FacIva21.Length)
        lineatotal = StrDup(XXX, ".")
        yPos += 10
        e.Graphics.DrawString(textoIva21 & lineatotal & FacIva21, font3, System.Drawing.Brushes.Black, 0, yPos)

        XXX = 27 - (textoTotal.Length + facTotal.Length)
        lineatotal = StrDup(XXX, ".")
        yPos += 10
        e.Graphics.DrawString(textoTotal & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)

        yPos += 30


        Dim bm As Bitmap = Nothing
        bm = Codigos.codigo128(factCAE, False, 20)
        If Not IsNothing(bm) Then
            PictureBox1.Image = bm
        End If

        e.Graphics.DrawImage(PictureBox1.Image, 0, yPos)
        yPos += 25
        e.Graphics.DrawString(factCAE, font3, System.Drawing.Brushes.Black, 15, yPos)

        e.Graphics.DrawString(My.Settings.TextoPieTiket, font3, System.Drawing.Brushes.Black, 15, yPos)
        yPos += 10
        e.Graphics.DrawString("Gracias por tu compra!!!", font3, System.Drawing.Brushes.Black, 15, yPos)



    End Sub

    Private Sub cargarListas()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_listas_precio", conexionPrinc)
            Dim tablalistas As New DataTable
            consulta.Fill(tablalistas)
            dtlistasprecio.DataSource = tablalistas
            dtlistasprecio.Columns(0).Visible = False 'FillWeight = 10

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarCategorias()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_categoria_insum order by nombre asc", conexionPrinc)
            Dim tablalistas As New DataTable
            consulta.Fill(tablalistas)
            dtcategorias.DataSource = tablalistas
            dtcategorias.Columns(0).Width = 30

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarFiscal(ByVal ptovta As Integer)
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from tipos_comprobantes where ptovta =" & ptovta, conexionPrinc)
            Dim tablafiscal As New DataTable
            consulta.Fill(tablafiscal)
            dtfiscal.DataSource = tablafiscal
            dtfiscal.Columns(0).FillWeight = 10
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarVendedores()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_vendedor", conexionPrinc)
            Dim tablalistas As New DataTable
            consulta.Fill(tablalistas)
            dtvendedores.DataSource = tablalistas
            dtvendedores.Columns(0).FillWeight = 10

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarConceptosIngresos()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_ingresos_concepto", conexionPrinc)
            Dim tablalistas As New DataTable
            consulta.Fill(tablalistas)
            dtconceptosingresos.DataSource = tablalistas
            dtconceptosingresos.Columns(0).FillWeight = 10
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarConceptosEgresos()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_egresos_concepto", conexionPrinc)
            Dim tablalistas As New DataTable
            consulta.Fill(tablalistas)
            dtconceptosegresos.DataSource = tablalistas
            dtconceptosegresos.Columns(0).FillWeight = 10

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarDescuentos()
        Try
            dtdescuentos.Rows.Clear()
            Reconectar()
            Dim consultaDescProd As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT prom.id,concat('Descuento producto ' , ins.descripcion,' ', prom.descuento_porc ,'%'),prom.compra_min,prom.descuento_porc " &
            "From fact_promociones As prom, fact_insumos As ins Where ins.id = prom.idproducto ", conexionPrinc)
            Dim tablaDescProd As New DataTable
            Dim filasDescProd() As DataRow
            consultaDescProd.Fill(tablaDescProd)
            filasDescProd = tablaDescProd.Select("")

            Reconectar()
            Dim consultaDescCat As New MySql.Data.MySqlClient.MySqlDataAdapter("Select prom.id, concat('Descuento categoria ' , cat.nombre,' ', prom.descuento_porc ,'%'),prom.compra_min,prom.descuento_porc " &
            "FROM fact_promociones As prom, fact_categoria_insum as cat  " &
            "where prom.idcategoria=cat.id and cat.id<>0", conexionPrinc)
            Dim tablaDescCat As New DataTable
            Dim filasDescCat() As DataRow
            consultaDescCat.Fill(tablaDescCat)
            filasDescCat = tablaDescCat.Select("")

            For i As Integer = 0 To tablaDescProd.Rows.Count - 1
                dtdescuentos.Rows.Add(filasDescProd(i)(0), filasDescProd(i)(1), filasDescProd(i)(2), filasDescProd(i)(3))
            Next

            For i As Integer = 0 To tablaDescCat.Rows.Count - 1
                dtdescuentos.Rows.Add(filasDescCat(i)(0), filasDescCat(i)(1), filasDescCat(i)(2), filasDescCat(i)(3))
            Next



        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarMoneda()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_moneda", conexionPrinc)
            Dim tablalistas As New DataTable
            consulta.Fill(tablalistas)
            dtmoneda.DataSource = tablalistas
            dtmoneda.Columns(0).Visible = False
            dtmoneda.Columns(0).ReadOnly = True
            dtmoneda.AllowUserToDeleteRows = True
            dtmoneda.AllowUserToAddRows = False
        Catch ex As Exception

        End Try


    End Sub
    'Private Sub dtlistasprecio_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
    '    Try
    '        Reconectar()
    '        Dim sql As String
    '        Select Case e.ColumnIndex
    '            Case 1
    '                sql = "update fact_listas_precio set nombre='" & dtlistasprecio.CurrentRow.Cells(1).Value & "' where id=" & dtlistasprecio.CurrentRow.Cells(0).Value
    '            Case 2
    '                sql = "update fact_listas_precio set utilidad='" & dtlistasprecio.CurrentRow.Cells(2).Value & "' where id=" & dtlistasprecio.CurrentRow.Cells(0).Value
    '        End Select

    '        Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
    '        comandoadd.ExecuteNonQuery()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub TabPage13_Enter(sender As Object, e As EventArgs) Handles TabPage13.Enter
        Try
            Reconectar()
            Dim tablaptovta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, numero from fact_puntosventa", conexionPrinc)
            Dim readtptovta As New DataSet
            tablaptovta.Fill(readtptovta)
            cmbptovtaconf.DataSource = readtptovta.Tables(0)
            cmbptovtaconf.DisplayMember = readtptovta.Tables(0).Columns(1).Caption.ToString
            cmbptovtaconf.ValueMember = readtptovta.Tables(0).Columns(0).Caption.ToString
            cmbptovtaconf.SelectedIndex = 0
            'cargarFiscal(CInt(cmbptovtaconf.Text))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TabPage8_Click(sender As Object, e As EventArgs) Handles tabconfiguracion.Click
        cargarListas()
    End Sub



    Private Sub dtfiscal_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtfiscal.CellEndEdit
        Try
            Reconectar()
            Dim sql As String
            Select Case e.ColumnIndex
                Case 1
                    sql = "update fact_conffiscal set confnume='" & dtfiscal.CurrentCell.Value & "' where id=" & dtfiscal.CurrentRow.Cells(0).Value
            End Select

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            comandoadd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
            Dim hasta As String = Format(CDate(dthastafact.Value), "yyyy-MM-dd")
            Dim parambusq As String = ""
            If cmbtipofac.SelectedValue = 0 And chktodosfact.Checked = False Then
                MsgBox("No selecciono tipo de factura")
                Exit Sub
            ElseIf cmbtipofac.SelectedValue <> 0 And chktodosfact.Checked = False Then
                parambusq = " and fac.tipofact=" & cmbtipofac.SelectedValue
            ElseIf cmbtipofac.SelectedValue = 0 And chktodosfact.Checked = True Then
                parambusq = " and fac.tipofact in (select id from fact_conffiscal where tip=1)"
            End If

            If chktodosvendedores.Checked = False And cmbvendedor.SelectedValue = 0 Then
                MsgBox("debe seleccionar un vendedor")
                Exit Sub
            ElseIf chktodosvendedores.Checked = False And cmbvendedor.SelectedValue <> 0 Then
                parambusq &= " and fac.vendedor=" & cmbvendedor.SelectedValue
            End If

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

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT " _
            & " fac.id, concat(fis.abrev,' ',lpad(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as factnum ,fac.fecha,fac.razon,fac.direccion, " _
            & " fac.localidad, con.condicion, " _
            & " case when fis.debcred='C' then " _
            & " concat('-',format(fac.total,2,'es_AR')) " _
            & " else format(fac.total,2,'es_AR') end as total, " _
            & " fac.observaciones from fact_conffiscal as fis, fact_facturas as fac, fact_condventas as con " _
            & " where fis.donfdesc=fac.tipofact and con.id=fac.condvta " _
            & " and fac.fecha between '" & desde & "' and '" & hasta & "'" & parambusq, conexionPrinc)
            tabFac.Fill(fac.Tables("listadofacturas"))
            Dim imprimirx As New imprimirFX
            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("vendedor", vendedor))
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listadofacturas.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("membreteenca", fac.Tables("membreteenca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadofacturas")))
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Select Case dtfacturas.CurrentRow.Cells(9).Value
                Case 9, 6, 3, 12, 15, 18
                    MsgBox("No se puede anular una factura electronica, debe hacer nota de credito correspondiente")
                    Exit Sub
            End Select
            If MsgBox("Esta seguro que desea anular esta factura?", vbYesNo + vbQuestion) = vbNo Then
                Exit Sub
            End If
            Dim idFactura As Integer = dtfacturas.CurrentRow.Cells(0).Value
            Dim sql As String = "update fact_facturas set razon='FACTURA ANULADA', direccion='FACTURA ANULADA', localidad='FACTURA ANULADA'," _
            & "tipocontr='FACTURA ANULADA', cuit='FACTURA ANULADA', subtotal=0,iva105=0, iva21=0, total=0 where id=" & idFactura

            Dim comandodelfact As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            comandodelfact.ExecuteNonQuery()

            Dim consultaitmtrab As New MySql.Data.MySqlClient.MySqlDataAdapter("select cod from fact_items where id_fact=" & idFactura, conexionPrinc)
            Dim tablaitm As New DataTable
            Dim infoitm() As DataRow
            consultaitmtrab.Fill(tablaitm)
            infoitm = tablaitm.Select("")
            Dim numtrab As Integer
            Dim i As Integer
            For i = 0 To infoitm.GetUpperBound(0)
                If InStr(infoitm(i)(0), "&") <> 0 Then
                    Reconectar()
                    numtrab = Replace(infoitm(i)(0), "&", "")
                    sql = "update tecni_taller set trab_estado=3 where id=" & numtrab
                    Dim consultaupdtrab As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
                    consultaupdtrab.ExecuteNonQuery()
                End If
            Next

            sql = "delete from fact_items where id_fact=" & idFactura
            Dim consultadelitm As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            consultadelitm.ExecuteNonQuery()

            MsgBox("factura anulada correctamente")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try



            Select Case dtcuentaclie.CurrentRow.Cells(7).Value
                Case 5
                    Dim idfactura = dtcuentaclie.CurrentRow.Cells(6).Value
                    'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
                    Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
                    Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
                    Dim tabVal As New MySql.Data.MySqlClient.MySqlDataAdapter
                    Dim tabtarj As New MySql.Data.MySqlClient.MySqlDataAdapter
                    Dim totrec As New MySql.Data.MySqlClient.MySqlDataAdapter

                    Dim fac As New datosfacturas

                    Reconectar()
                    tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
                    & "emp.nombrefantasia As empnombre, emp.razonsocial As emprazon, emp.direccion As empdire, emp.localidad As emploca, " _
                    & "emp.cuit As empcuit, emp.ingbrutos As empib, emp.ivatipo As empcontr, emp.inicioact As empinicioact, emp.drei As empdrei, emp.logo As emplogo, " _
                    & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum,fac.fecha as facfech,concat(fac.id_cliente,'-',fac.razon) as facrazon, " _
                    & "fac.direccion As facdire, fac.localidad As facloca, fac.tipocontr As factipocontr, fac.cuit As faccuit, fac.vendedor As facvend, " _
                    & "fac.condvta as faccondvta, format(fac.iva105,2,'es_AR'), format(fac.iva21,2,'es_AR'),format(fac.total,2,'es_AR'),    " _
                    & "fac.observaciones as facobserva " _
                    & "FROM fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac where emp.id=1 and fis.donfdesc=fac.tipofact and fac.id=" & idfactura, conexionPrinc)
                    tabEmp.Fill(fac.Tables("factura_enca"))

                    Reconectar()
                    tabVal.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
                    & "banco, serie as numero, fecha_cobro as fcobro, format(importe,2,'es_AR') as importe from fact_cheques where comprobante = " & idfactura, conexionPrinc)
                    tabVal.Fill(fac.Tables("valoresrecibo"))


                    Reconectar()
                    tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
                    & "descripcion,format(ptotal,2,'es_AR') as ptotal from fact_items where " _
                    & "id_fact=" & idfactura, conexionPrinc)
                    tabFac.Fill(fac.Tables("reciboitems"))

                    Reconectar()
                    tabtarj.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
                    & "nombre,autorizacion,format(importe,2,'es_AR') as importe from fact_tarjetas where comprobante=" & idfactura, conexionPrinc)
                    tabtarj.Fill(fac.Tables(("tarjetarecbo")))

                    Reconectar()
                    totrec.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
                    & "efectivo,cheque,transferencias,retenciones,tarjetas,total FROM cobranzas where id= " & idfactura, conexionPrinc)
                    totrec.Fill(fac.Tables("totalesrecibo"))

                    Dim imprimirx As New imprimirFX
                    With imprimirx
                        .MdiParent = Me.MdiParent
                        .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                        .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\recibo.rdlc"
                        .rptfx.LocalReport.DataSources.Clear()
                        .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                        .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("valores", fac.Tables("valoresrecibo")))
                        .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("reciboitems")))
                        .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("tarjetas", fac.Tables("tarjetarecbo")))
                        .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("totalesrecibo", fac.Tables("totalesrecibo")))

                        .rptfx.DocumentMapCollapsed = True
                        .rptfx.RefreshReport()
                        .Show()
                    End With
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim i As Integer
        For i = 0 To frmprincipal.MdiChildren.Length - 1
            If frmprincipal.MdiChildren(i).Name = "movimientocaja" Then
                'frmprincipal.MdiChildren(i).BringToFront()
                MsgBox("la ventana de movimiento de cuenta ya esta abierta, por favor complete la operacion antes de efectuar otra", vbCritical)
                Exit Sub
            End If
        Next

        Dim mov As New movimientodecaja
        mov.MdiParent = Me.MdiParent
        mov.movrap = True
        mov.movraptip = 19
        mov.movrapclie = txtcuentabus.Text
        mov.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas
            Dim desde As String
            Dim hasta As String
            Dim vendedor As String
            Dim vendedor2 As String

            If CheckBox1.Checked = False Then
                desde = Format(CDate(dtpdeestado.Value), "yyyy-MM-dd")
                hasta = Format(CDate(dtphastaestado.Value), "yyyy-MM-dd")
            Else
                desde = "%%%%-%%-%%"
                hasta = Format(CDate(dtphastaestado.Value), "yyyy-MM-dd")
            End If

            If chkvendedorctacte.Checked = True Then
                vendedor = "%"
                vendedor2 = "todos"
            Else
                vendedor = cmbvendedorctacte.SelectedValue
                vendedor2 = cmbvendedorctacte.Text
            End If

            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo " _
            & "FROM fact_empresa as emp where emp.id=1", conexionPrinc)

            tabEmp.Fill(fac.Tables("membreteenca"))
            Reconectar()

            Dim consultaComp As New MySql.Data.MySqlClient.MySqlDataAdapter("select fac.id_cliente as cuenta, cli.nomapell_razon as razon, " _
            & "if(round(sum(replace(total,',','.')),2) is null,0,round(sum(replace(total,',','.')),2)) as compra " _
            & "FROM fact_facturas as fac, fact_clientes as cli, fact_conffiscal as fis " _
            & "where fis.donfdesc=fac.tipofact and fis.debcred in ('D') and   " _
            & "fac.id_cliente=cli.idclientes and fac.id_cliente<>9999 and " _
            & "fac.fecha between @de and @hasta and fac.vendedor like @vendedor " _
            & "group by fac.id_cliente", conexionPrinc)
            consultaComp.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@de", MySql.Data.MySqlClient.MySqlDbType.Text))
            consultaComp.SelectCommand.Parameters("@de").Value = desde
            consultaComp.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@hasta", MySql.Data.MySqlClient.MySqlDbType.Text))
            consultaComp.SelectCommand.Parameters("@hasta").Value = hasta
            consultaComp.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@vendedor", MySql.Data.MySqlClient.MySqlDbType.Text))
            consultaComp.SelectCommand.Parameters("@vendedor").Value = vendedor

            Dim consultaCobr As New MySql.Data.MySqlClient.MySqlDataAdapter("select fac.id_cliente as cuenta, cli.nomapell_razon as razon, " _
            & "if(round(sum(replace(total,',','.')),2) is null,0,round(sum(replace(total,',','.')),2)) as pago " _
            & "FROM fact_facturas as fac, fact_clientes as cli, fact_conffiscal as fis " _
            & "where fis.donfdesc=fac.tipofact and fis.debcred in ('C') and " _
            & "fac.id_cliente=cli.idclientes and fac.id_cliente<>9999 and " _
            & "fac.fecha between @de and @hasta " _
            & "group by fac.id_cliente ", conexionPrinc)
            consultaCobr.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@de", MySql.Data.MySqlClient.MySqlDbType.Text))
            consultaCobr.SelectCommand.Parameters("@de").Value = desde
            consultaCobr.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@hasta", MySql.Data.MySqlClient.MySqlDbType.Text))
            consultaCobr.SelectCommand.Parameters("@hasta").Value = hasta
            'consultaCobr.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@vendedor", MySql.Data.MySqlClient.MySqlDbType.Text))
            'consultaCobr.SelectCommand.Parameters("@vendedor").Value = vendedor


            Dim tablacomp As New DataTable
            Dim tablacobr As New DataTable

            consultaComp.Fill(tablacomp)
            consultaCobr.Fill(tablacobr)

            Dim filaComp() As DataRow = tablacomp.Select()
            Dim filaCobr() As DataRow = tablacobr.Select()

            'creamos la tabla de datos para las cuentas
            Dim estadocuentas As New DataTable
            Dim columestado As DataColumn
            Dim filaestado As DataRow

            columestado = New DataColumn
            columestado.DataType = System.Type.GetType("System.String")
            columestado.ColumnName = "Cuenta"
            estadocuentas.Columns.Add(columestado)

            columestado = New DataColumn
            columestado.DataType = System.Type.GetType("System.String")
            columestado.ColumnName = "Razon"
            estadocuentas.Columns.Add(columestado)

            columestado = New DataColumn
            columestado.DataType = System.Type.GetType("System.Decimal")
            columestado.ColumnName = "Saldo"
            estadocuentas.Columns.Add(columestado)

            For Each fila As DataRow In tablacomp.Rows
                filaestado = estadocuentas.NewRow
                filaestado(0) = fila.Item(0)
                filaestado(1) = fila.Item(1)
                Dim saldo As Double
                Dim filapago() As Data.DataRow
                filapago = tablacobr.Select("cuenta like '" & fila(0) & "'")
                If filapago.Length = 0 Then
                    saldo = fila.Item(2)
                Else
                    saldo = Math.Round(fila.Item(2) - filapago(0).Item(2), 2)
                End If
                filaestado(2) = saldo
                If saldo <> 0 Then
                    estadocuentas.Rows.Add(filaestado)
                End If
            Next

            For Each row As DataRow In estadocuentas.Rows
                fac.Tables("estadocuenta").ImportRow(row)
            Next

            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("desde", desde))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("hasta", hasta))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("vendedor", vendedor2))
            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\estadocuentas.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("membreteenca", fac.Tables("membreteenca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("cuentas", fac.Tables("estadocuenta")))
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



    Private Sub dtcuentaclie_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtcuentaclie.UserDeletedRow
        cargarCuentaClie(txtcuentabus.Text)
        MsgBox("Comprobante eliminado")
    End Sub


    Private Sub dtcuentaclie_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtcuentaclie.UserDeletingRow
        Try
            If MsgBox("Esta seguro que desa eliminar este comprobante? esto no se puede deshacer: " & dtcuentaclie.CurrentRow.Cells(0).Value, vbYesNo + vbQuestion) = vbNo Then
                e.Cancel = True
                Exit Sub
            End If
            Dim elimctaitm As String = "delete from fact_cuentaclie where id=" & dtcuentaclie.CurrentRow.Cells(0).Value
            Dim elimfact As String = "delete from fact_facturas where id=" & dtcuentaclie.CurrentRow.Cells(6).Value
            Dim elimfactitm As String = "delete from fact_items where id_fact=" & dtcuentaclie.CurrentRow.Cells(6).Value

            Dim cmdelcta As New MySql.Data.MySqlClient.MySqlCommand(elimctaitm, conexionPrinc)
            Dim cmdelfac As New MySql.Data.MySqlClient.MySqlCommand(elimfact, conexionPrinc)
            Dim cmdelfacitm As New MySql.Data.MySqlClient.MySqlCommand(elimfactitm, conexionPrinc)
            Reconectar()
            cmdelcta.ExecuteNonQuery()
            Reconectar()
            cmdelfacitm.ExecuteNonQuery()
            Reconectar()
            cmdelfac.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chktodosvendedores_CheckedChanged(sender As Object, e As EventArgs) Handles chktodosvendedores.CheckedChanged
        Try
            If chktodosvendedores.Checked = True Then
                cmbvendedor.Enabled = False
                cmbvendedor.SelectedIndex = -1
            Else
                cmbvendedor.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chktodosfact_CheckedChanged(sender As Object, e As EventArgs) Handles chktodosfact.CheckedChanged
        Try
            If chktodosfact.Checked = True Then
                cmbtipofac.Enabled = False
                cmbtipofac.SelectedIndex = -1
            Else
                cmbtipofac.Enabled = True
            End If
        Catch ex As Exception

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

            For Each fila As DataGridViewRow In dtfacturas.Rows
                total += fila.Cells(columna).Value
            Next

            lbltotalfact.Text = total


            For Each fila As DataGridViewRow In dtlistacob.Rows
                total += fila.Cells(columna).Value
            Next
            lbltotcob.Text = total

            total = 0

            For Each fila As DataGridViewRow In dtestadocuentas.Rows
                total += fila.Cells(columna).Value
            Next
            lbltotctacte.Text = total

            total = 0

            For Each fila As DataGridViewRow In dtcheques.Rows
                total += fila.Cells(columna).Value
            Next
            lbltotalcheques.Text = total

            total = 0
            For Each fila As DataGridViewRow In dtchequespropios.Rows
                total += fila.Cells(columna).Value
            Next
            lbltotalchequespropios.Text = total

        Catch ex As Exception

        End Try
    End Function

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles cmdverestadocuentas.Click
        cargarEstadodeCuentas()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            dtpdeestado.Enabled = False
            dtphastaestado.Enabled = False
            dtphastaestado.Value = Now()
        Else
            dtpdeestado.Enabled = True
            dtphastaestado.Enabled = True
        End If
    End Sub

    Private Sub chkvendedorctacte_CheckedChanged(sender As Object, e As EventArgs) Handles chkvendedorctacte.CheckedChanged
        Try
            If chkvendedorctacte.Checked = True Then
                cmbvendedorctacte.Enabled = False
                cmbvendedorctacte.SelectedIndex = -1
            Else
                cmbvendedorctacte.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkctactlievtas_CheckedChanged(sender As Object, e As EventArgs) Handles chkctactlievtas.CheckedChanged
        Try
            If chkctactlievtas.Checked = True Then
                txtctaclievtas.Enabled = True
            Else
                txtctaclievtas.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdbuscarcomp_Click(sender As Object, e As EventArgs) Handles cmdbuscarcomp.Click
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
            Dim columna As Integer
            Dim desde As String = Format(CDate(dtpdecob.Value), "yyyy-MM-dd")
            Dim hasta As String = Format(CDate(dtphastacob.Value), "yyyy-MM-dd")
            Dim tablacob As New DataTable
            tablacob.Clear()
            ' Dim parambusq As String = " and fac.tipofact in ('5') "
            If rdcobranzadiaria.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cobranzas_diarias where fecha between '" & desde & "' and '" & hasta & "'", conexionPrinc)
                columna = 6
                consulta.Fill(tablacob)
                dtlistacob.DataSource = tablacob
            End If
            If rdcobranzaintervalo.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cobranzas where fecha between '" & desde & "' and '" & hasta & "'", conexionPrinc)
                columna = 11

                consulta.Fill(tablacob)
                dtlistacob.DataSource = tablacob
                dtlistacob.Columns(0).Visible = False
            End If



            lbltotcob.Text = SumarTotal(dtlistacob, columna)
            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub

    Private Sub cmbbuscarcheques_Click(sender As Object, e As EventArgs) Handles cmdbuscarcheques.Click
        Try
            Dim consul As String

            If chkchequecobro.Checked Then
                Dim de As String = Format(CDate(dtpchequesde.Value), "yyyy-MM-dd")
                Dim hasta As String = Format(CDate(dtpchequeshasta.Value), "yyyy-MM-dd")
                consul &= " and fecha_cobro between '" & de & "' and '" & hasta & "' "
            End If

            If chkchequeclie.Checked = True And txtchequescliente.Text <> "" Then
                consul &= " and cliente = " & txtchequescliente.Text
            End If

            If chkchequenumero.Checked = True And txtchequenumero.Text <> "" Then
                consul &= " and serie = " & txtchequenumero.Text
            End If

            If chkchequebanco.Checked = True Then
                consul &= " and banco = " & cmbchequebanco.Text
            End If

            If chkchequeestado.Checked = True Then
                consul &= " and estado_cheque = " & cmbchequeestado.SelectedValue
            End If



            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select fac.fecha as FechaRec, clie.nomapell_razon as Cliente, che.banco, che.serie, " _
            & "(select estado from fact_cheques_estado where idcheques_estado=che.estado_cheque) as estado, " _
            & "case che.estado_cheque " _
            & "when 4 then " _
            & "(select pro.razon from fact_proveedores as pro, fact_proveedores_fact as fac where pro.id=fac.idproveedor and fac.id=che.comprobante_eg) " _
            & "when 3 then " _
            & "(select descripcion from fact_cajas where id=che.cuenta) " _
            & "end as destino, " _
            & "che.fecha_cobro, format(che.importe,2,'es_AR') " _
            & "from fact_clientes as clie, fact_facturas as fac, fact_cheques as che " _
            & "where che.tipo_cheque=1 and che.comprobante = fac.id And fac.id_cliente = clie.idclientes " & consul, conexionPrinc)
            Dim tablacheques As New DataTable

            consulta.Fill(tablacheques)
            dtcheques.DataSource = tablacheques
            lbltotalcheques.Text = SumarTotal(dtcheques, 7)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles chkchequecobro.CheckedChanged
        Try
            If chkchequecobro.Checked = True Then
                dtpchequesde.Enabled = True
                dtpchequeshasta.Enabled = True
            Else
                dtpchequesde.Enabled = False
                dtpchequeshasta.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkcuentacheques_CheckedChanged(sender As Object, e As EventArgs) Handles chkchequeclie.CheckedChanged
        Try
            If chkchequeclie.Checked = True Then
                txtchequescliente.Enabled = True
            Else
                txtchequescliente.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chknumerocheque_CheckedChanged(sender As Object, e As EventArgs) Handles chkchequenumero.CheckedChanged
        Try
            If chkchequenumero.Checked = True Then
                txtchequenumero.Enabled = True
            Else
                txtchequenumero.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox2_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkchequebanco.CheckedChanged
        Try
            If chkchequebanco.Checked = True Then
                cmbchequebanco.Enabled = True
            Else
                cmbchequebanco.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkestadocheque_CheckedChanged(sender As Object, e As EventArgs) Handles chkchequeestado.CheckedChanged
        Try
            If chkchequeestado.Checked = True Then
                cmbchequeestado.Enabled = True
            Else
                cmbchequeestado.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles cmdbuscarchequepropio.Click
        Try
            Dim consul As String
            If chkvencepropio.Checked Then
                Dim de As String = Format(CDate(dtdechequepropio.Value), "yyyy-MM-dd")
                Dim hasta As String = Format(CDate(dtphastachequepropio.Value), "yyyy-MM-dd")
                consul &= " and fecha_cobro between '" & de & "' and '" & hasta & "' "
            End If

            If chkseriepropio.Checked = True And txtseriepropio.Text <> "" Then
                consul &= " and serie = " & txtseriepropio.Text
            End If

            If chkbancopropio.Checked = True Then
                consul &= " and banco = " & cmbbancopropio.Text
            End If

            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select che.fecha_emision, " _
            & "(select pro.razon from fact_proveedores as pro, fact_proveedores_fact as fac where pro.id=fac.idproveedor and fac.id=che.comprobante_eg) as PagadoA, " _
            & "(select fecha from fact_proveedores_fact where id=che.comprobante_eg) as FechaPago,  " _
            & "che.banco, che.serie, " _
            & "che.fecha_cobro,format(che.importe,2,'es_AR'),che.observaciones" _
            & "from fact_cheques as che " _
            & "where che.tipo_cheque=2 " & consul, conexionPrinc)
            Dim tablacheques As New DataTable

            consulta.Fill(tablacheques)
            dtchequespropios.DataSource = tablacheques
            lbltotalchequespropios.Text = SumarTotal(dtchequespropios, 6)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        With ingreso_valores_propios
            .Show()
            .TopMost = True
        End With
    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs)
        Try
            Dim i As Integer
            chrestad.Series.Clear()
            Reconectar()
            Dim tablaVTAS As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT " _
            & "concat(year(fecha),'/',lpad(month(fecha),2,'0')) as periodo, round(sum(replace(total,',','.')),2) FROM kigest_fact.fact_facturas where tipofact in (1,2,3,8,10,12) " _
            & "group by concat(year(fecha),'/',lpad(month(fecha),2,'0'))", conexionPrinc)
            Dim tablaCOBR As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT " _
            & "concat(year(fecha),'/',lpad(month(fecha),2,'0')) as periodo, round(sum(replace(total,',','.')),2) FROM kigest_fact.fact_facturas where tipofact in (4,5,11,13) " _
            & "group by concat(year(fecha),'/',lpad(month(fecha),2,'0'))", conexionPrinc)
            Dim readvtas As New DataTable
            Dim readcobr As New DataTable

            tablaVTAS.Fill(readvtas)
            tablaCOBR.Fill(readcobr)

            Dim grafvtascob As New DataTable
            grafvtascob.Columns.Add("periodo")
            grafvtascob.Columns.Add("ventas")
            grafvtascob.Columns.Add("cobranza")

            'emparejamos las tablas
            If readvtas.Rows.Count > readcobr.Rows.Count Then
                Dim resta = readvtas.Rows.Count - readcobr.Rows.Count
                For i = 1 To resta
                    readcobr.Rows.Add()
                Next

                For i = 0 To readvtas.Rows.Count - 1
                    If readvtas.Rows(i).Item(0) = readcobr.Rows(i).Item(0) Then
                        grafvtascob.Rows.Add(readvtas.Rows(i).Item(0), readvtas.Rows(i).Item(1), readcobr.Rows(i).Item(1))
                    End If
                Next

            ElseIf readvtas.Rows.Count < readcobr.Rows.Count Then
                Dim resta = readcobr.Rows.Count - readvtas.Rows.Count
                For i = 1 To resta
                    readvtas.Rows.Add()
                Next

                For i = 0 To readcobr.Rows.Count - 1
                    If readvtas.Rows(i).Item(0) = readcobr.Rows(i).Item(0) Then
                        grafvtascob.Rows.Add(readvtas.Rows(i).Item(0), readvtas.Rows(i).Item(1), readcobr.Rows(i).Item(1))
                    End If
                Next

            End If

            chrestad.DataSource = grafvtascob

            Dim ingresos As New Series
            chrestad.Series.Add(ingresos)
            ingresos.Name = "grafica"

            chrestad.Series(ingresos.Name).XValueMember = "periodo"
            chrestad.Series(ingresos.Name).YValueMembers = "ventas"
            chrestad.Series(ingresos.Name).YValueMembers = "cobranza"

            chrestad.Series.Item(0).ChartType = SeriesChartType.Line
            chrestad.Series.Item(0).BorderWidth = 3
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles cmdcargargrafico.Click
        Try
            Dim i As Integer
            chrestad.Series.Clear()
            Reconectar()
            Dim tablaVTAS As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
concat(year(fecha),'/',lpad(month(fecha),2,'0')) as periodo, round(sum(replace(total,',','.')),2) 
FROM fact_facturas where tipofact in (select donfdesc from tipos_comprobantes where debcred='D') 
group by concat(year(fecha),'/',lpad(month(fecha),2,'0'))", conexionPrinc)

            Dim tablaCOBR As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
concat(year(fecha),'/',lpad(month(fecha),2,'0')) as periodo, round(sum(replace(total,',','.')),2) 
FROM fact_facturas where tipofact in (select donfdesc from tipos_comprobantes where debcred='C') 
group by concat(year(fecha),'/',lpad(month(fecha),2,'0'))", conexionPrinc)

            Dim readvtas As New DataTable
            Dim readcobr As New DataTable

            tablaVTAS.Fill(readvtas)
            tablaCOBR.Fill(readcobr)

            Dim grafvtascob As New DataTable
            grafvtascob.Columns.Add("periodo")

            grafvtascob.Columns.Add("ventas")
            grafvtascob.Columns(1).DataType = GetType(Decimal)

            grafvtascob.Columns.Add("cobranza")
            grafvtascob.Columns(2).DataType = GetType(Decimal)

            'emparejamos las tablas
            If readvtas.Rows.Count > readcobr.Rows.Count Then
                Dim resta = readvtas.Rows.Count - readcobr.Rows.Count
                For i = 1 To resta
                    readcobr.Rows.Add()
                Next

                For i = 0 To readvtas.Rows.Count - 1
                    'If readvtas.Rows(i).Item(0).ToString = readcobr.Rows(i).Item(0).ToString Then
                    grafvtascob.Rows.Add(readvtas.Rows(i).Item(0), readvtas.Rows(i).Item(1), readcobr.Rows(i).Item(1))
                    'End If
                Next

            ElseIf readvtas.Rows.Count < readcobr.Rows.Count Then
                Dim resta = readcobr.Rows.Count - readvtas.Rows.Count
                For i = 1 To resta
                    readvtas.Rows.Add()
                Next

                For i = 0 To readcobr.Rows.Count - 1
                    'If readvtas.Rows(i).Item(0).ToString = readcobr.Rows(i).Item(0).ToString Then
                    grafvtascob.Rows.Add(readvtas.Rows(i).Item(0), readvtas.Rows(i).Item(1), readcobr.Rows(i).Item(1))
                    'End If
                Next
            Else
                For i = 0 To readcobr.Rows.Count - 1
                    'If readvtas.Rows(i).Item(0).ToString = readcobr.Rows(i).Item(0).ToString Then
                    grafvtascob.Rows.Add(readvtas.Rows(i).Item(0), readvtas.Rows(i).Item(1), readcobr.Rows(i).Item(1))
                    'End If
                Next
            End If
            'MsgBox(grafvtascob.Rows.Count)
            chrestad.DataSource = grafvtascob

            Dim ventas As New Series
            Dim cobranza As New Series
            chrestad.Series.Add(ventas)
            ventas.Name = "ventas"

            chrestad.Series(ventas.Name).XValueMember = "periodo"
            chrestad.Series(ventas.Name).YValueMembers = "ventas"
            'chrestad.Series(ventas.Name).YValueMembers = "cobranza"

            chrestad.Series.Item(0).ChartType = SeriesChartType.Line
            chrestad.Series.Item(0).BorderWidth = 3

            '----------------------------
            chrestad.Series.Add(cobranza)
            cobranza.Name = "Cobranza"

            chrestad.Series(cobranza.Name).XValueMember = "periodo"
            chrestad.Series(cobranza.Name).YValueMembers = "cobranza"
            'chrestad.Series(ventas.Name).YValueMembers = "cobranza"

            chrestad.Series.Item(1).ChartType = SeriesChartType.Line
            chrestad.Series.Item(1).BorderWidth = 3
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TabPage1_Enter_1(sender As Object, e As EventArgs) Handles TabPage1.Enter
        cargarVendedores()
    End Sub

    Private Sub dtvendedores_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtvendedores.CellEndEdit
        Try
            Reconectar()
            Dim sql As String
            Select Case e.ColumnIndex
                Case 1
                    sql = "update fact_vendedor set nombre='" & dtvendedores.CurrentCell.Value.ToString.ToUpper & "' where id=" & dtvendedores.CurrentRow.Cells(0).Value
                Case 2
                    sql = "update fact_vendedor set apellido='" & dtvendedores.CurrentCell.Value.ToString.ToUpper & "' where id=" & dtvendedores.CurrentRow.Cells(0).Value
                Case 3
                    sql = "update fact_vendedor set comision='" & dtvendedores.CurrentCell.Value.ToString.ToUpper & "' where id=" & dtvendedores.CurrentRow.Cells(0).Value
                Case 4
                    sql = "update fact_vendedor set activo='" & dtvendedores.CurrentCell.Value.ToString.ToUpper & "' where id=" & dtvendedores.CurrentRow.Cells(0).Value
            End Select

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            comandoadd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtvendedores_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtvendedores.UserAddedRow
        Try
            Dim sql As String
            sql = "insert into fact_vendedor (nombre,apellido,comision,activo) values ('" & dtvendedores.CurrentRow.Cells(1).Value.ToString.ToUpper & "'," _
            & "'" & dtvendedores.CurrentRow.Cells(2).Value.ToString.ToUpper & "','" & dtvendedores.CurrentRow.Cells(3).Value & "','1')"
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            dtvendedores.CurrentRow.Cells(0).Value = comandoadd.LastInsertedId
            'cargarVendedores()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtconceptosingresos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtconceptosingresos.CellContentClick

    End Sub

    Private Sub dtconceptosingresos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtconceptosingresos.CellEndEdit
        Try
            Reconectar()
            Dim sql As String
            Select Case e.ColumnIndex
                Case 1
                    sql = "update fact_ingresos_concepto set concepto='" & dtconceptosingresos.CurrentCell.Value.ToString.ToUpper & "' where id=" & dtconceptosingresos.CurrentRow.Cells(0).Value
            End Select

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            comandoadd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdninguno_CheckedChanged(sender As Object, e As EventArgs) Handles rdninguno.CheckedChanged
        If rdninguno.Checked = True Then
            grpfiltrar.Enabled = True
            grpacciones.Enabled = True
            grpcomprobantes.Enabled = True
        Else
            grpfiltrar.Enabled = False
            grpacciones.Enabled = False
            grpcomprobantes.Enabled = False
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        GenerarExcel(dtfacturas)
    End Sub

    Private Sub TabPage3_Enter1(sender As Object, e As EventArgs) Handles TabPage3.Enter
        cargarConceptosIngresos()

    End Sub

    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        cargarConceptosEgresos()

    End Sub

    Private Sub dtconceptosegresos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtconceptosegresos.CellContentClick

    End Sub

    Private Sub dtconceptosegresos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtconceptosegresos.CellEndEdit
        Try
            Reconectar()
            Dim sql As String
            Select Case e.ColumnIndex
                Case 1
                    sql = "update fact_egresos_concepto set concepto='" & dtconceptosegresos.CurrentCell.Value.ToString.ToUpper & "' where id=" & dtconceptosegresos.CurrentRow.Cells(0).Value
            End Select

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            comandoadd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtconceptosingresos_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtconceptosingresos.UserAddedRow
        Try
            Dim sql As String
            sql = "insert into fact_ingresos_concepto (concepto) values ('" & dtconceptosingresos.CurrentCell.Value.ToString.ToUpper & "' )"
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            dtconceptosingresos.CurrentRow.Cells(0).Value = comandoadd.LastInsertedId
            'cargarConceptosIngresos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtconceptosegresos_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtconceptosegresos.UserAddedRow
        Try
            Dim sql As String
            sql = "insert into fact_egresos_concepto (concepto) values ('" & dtconceptosegresos.CurrentCell.Value.ToString.ToUpper & "' )"
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            dtconceptosegresos.CurrentRow.Cells(0).Value = comandoadd.LastInsertedId
            'cargarConceptosEgresos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        GenerarExcel(dtcuentaclie)
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
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

            Dim desde As String = Format(CDate(dtpdecob.Value), "yyyy-MM-dd")
            Dim hasta As String = Format(CDate(dtphastacob.Value), "yyyy-MM-dd")
            Dim parambusq As String = " and fac.tipofact in ('19')"

            Dim vendedor As String = ""

            If chkcobselvendedor.Checked = True Then
                vendedor = "Todos"
            Else
                vendedor = cmbcobvendedor.Text
            End If

            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo " _
            & "FROM fact_empresa as emp where emp.id=1", conexionPrinc)

            tabEmp.Fill(fac.Tables("membreteenca"))
            Reconectar()
            'If chkcobselvendedor.Checked = True Then
            '    tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT " _
            '    & "fac.id, concat(fis.abrev,' ',lpad(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as recnum ,fac.fecha,fac.razon,fac.direccion, " _
            '    & "fac.localidad, " _
            '    & "round(replace(fac.total,',','.') - ( " _
            '    & "(select if(sum(replace(che.importe,',','.')) is null,0,sum(replace(che.importe,',','.'))) " _
            '    & "from fact_cheques as che where fac.id=che.comprobante) + " _
            '    & "(select if(sum(replace(tra.importe,',','.')) is null,0,sum(replace(tra.importe,',','.'))) " _
            '    & "from fact_transferencias as tra where fac.id=tra.comprobante)+ " _
            '    & "(select if(sum(replace(ret.importe,',','.')) is null,0,sum(replace(ret.importe,',','.')))  " _
            '    & "from fact_retenciones as ret where fac.id=ret.comprobante) " _
            '    & "),2) as efectivo, " _
            '    & "(select if(sum(replace(che.importe,',','.')) is null,0,sum(replace(che.importe,',','.'))) " _
            '    & "from fact_cheques as che where fac.id=che.comprobante)as cheque, " _
            '    & "(select if(sum(replace(tra.importe,',','.')) is null,0,sum(replace(tra.importe,',','.'))) " _
            '    & "from fact_transferencias as tra where fac.id=tra.comprobante) as transferencias, " _
            '    & "(select if(sum(replace(ret.importe,',','.')) is null,0,sum(replace(ret.importe,',','.')))  " _
            '    & "from fact_retenciones as ret where fac.id=ret.comprobante) as retenciones, " _
            '    & "fac.total from fact_conffiscal as fis, fact_facturas as fac " _
            '    & "where fis.id=fac.tipofact " _
            '    & "and fac.fecha between '" & desde & "' and '" & hasta & "'" & parambusq, conexionPrinc)
            '    tabFac.Fill(fac.Tables("listadorecibos"))
            'Else
            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select * from cobranzas where fecha between '" & desde & "' and '" & hasta & "'", conexionPrinc)
            tabFac.Fill(fac.Tables("listadorecibos"))
            'End If
            Dim imprimirx As New imprimirFX
            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("vendedor", vendedor))
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listadorecibos.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("membreteenca", fac.Tables("membreteenca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadorecibos")))
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

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            Dim idfactura = dtlistacob.CurrentRow.Cells(0).Value
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabVal As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabtarj As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim totrec As New MySql.Data.MySqlClient.MySqlDataAdapter

            Dim fac As New datosfacturas

            Reconectar()
            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia As empnombre, emp.razonsocial As emprazon, emp.direccion As empdire, emp.localidad As emploca, " _
            & "emp.cuit As empcuit, emp.ingbrutos As empib, emp.ivatipo As empcontr, emp.inicioact As empinicioact, emp.drei As empdrei, emp.logo As emplogo, " _
            & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum,fac.fecha as facfech,concat(fac.id_cliente,'-',fac.razon) as facrazon, " _
            & "fac.direccion As facdire, fac.localidad As facloca, fac.tipocontr As factipocontr, fac.cuit As faccuit, fac.vendedor As facvend, " _
            & "fac.condvta as faccondvta, fac.iva105, fac.iva21,fac.total,  " _
            & "fac.observaciones as facobserva " _
            & "FROM fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac where emp.id=1 and fis.donfdesc=fac.tipofact and fac.id=" & idfactura, conexionPrinc)
            tabEmp.Fill(fac.Tables("factura_enca"))

            Reconectar()
            tabVal.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "banco, serie as numero, fecha_cobro as fcobro, format(importe,2,'es_AR') as importe from fact_cheques where comprobante = " & idfactura, conexionPrinc)
            tabVal.Fill(fac.Tables("valoresrecibo"))


            Reconectar()
            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "descripcion,format(ptotal,2,'es_AR') as ptotal from fact_items where " _
            & "id_fact=" & idfactura, conexionPrinc)
            tabFac.Fill(fac.Tables("reciboitems"))

            Reconectar()
            tabtarj.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "nombre,autorizacion,format(importe,2,'es_AR') as importe from fact_tarjetas where comprobante=" & idfactura, conexionPrinc)
            tabtarj.Fill(fac.Tables(("tarjetarecbo")))

            Reconectar()
            totrec.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
             & "efectivo,cheque,transferencias,retenciones,tarjetas,total FROM cobranzas where id= " & idfactura, conexionPrinc)
            totrec.Fill(fac.Tables("totalesrecibo"))

            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & " \reportes\recibo.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("valores", fac.Tables("valoresrecibo")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("reciboitems")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("tarjetas", fac.Tables("tarjetarecbo")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("totalesrecibo", fac.Tables("totalesrecibo")))

                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub Button8_Click(sender As Object, e As EventArgs)
    '    Try
    '        If MsgBox("Esta seguro que desea aumentar un " & txtporcentaje.Text & " porciento los precios de la categoria " & dtcategorias.CurrentRow.Cells(1).Value, vbYesNo + vbQuestion) = vbYes Then
    '            Dim coef As Double = FormatNumber((txtporcentaje.Text + 100) / 100)
    '            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("update kigest_igp.fact_insumos Set precio= replace(precio*?coef,'.',',') where categoria = " & dtcategorias.CurrentRow.Cells(0).Value, conexionPrinc)
    '            With comandoadd.Parameters
    '                .AddWithValue("?coef", coef)
    '            End With
    '            comandoadd.ExecuteNonQuery()
    '            MsgBox("se ha aumentado el precio de la categoria seleccionada")
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub Button18_Click(sender As Object, e As EventArgs)
    '    Try
    '        If MsgBox("Esta seguro que desea rebajar un " & txtporcentaje.Text & " porciento los precios de la categoria " & dtcategorias.CurrentRow.Cells(1).Value, vbYesNo + vbQuestion) = vbYes Then
    '            Dim coef As Double = FormatNumber((txtporcentaje.Text + 100) / 100)
    '            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("update kigest_igp.fact_insumos set precio= replace(precio/?coef,'.',',') where categoria = " & dtcategorias.CurrentRow.Cells(0).Value, conexionPrinc)
    '            With comandoadd.Parameters
    '                .AddWithValue("?coef", coef)
    '            End With
    '            comandoadd.ExecuteNonQuery()
    '            MsgBox("se ha rebajado el precio de la categoria seleccionada")
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub chkcobselvendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chkcobselvendedor.CheckedChanged
        If chkcobselvendedor.Checked = True Then
            cmbcobvendedor.Enabled = False
        Else
            cmbcobvendedor.Enabled = True
        End If
    End Sub
    Private Sub tabcomprobantes_Enter(sender As Object, e As EventArgs) Handles tabcomprobantes.Enter
        'If InStrRev(DatosAcceso.Moduloacc, "5a") = 0 Then
        '    MsgBox("NO esta autorizado")
        '    cmdbuscar.Enabled = False
        '    Exit Sub
        'End If
    End Sub

    Private Sub tabcobranzas_Enter(sender As Object, e As EventArgs) Handles tabcobranzas.Enter
        'If InStrRev(DatosAcceso.Moduloacc, "5b") = 0 Then
        '    MsgBox("NO esta autorizado")
        '    cmdbuscarcomp.Enabled = False
        '    Exit Sub
        'End If
    End Sub


    Private Sub tabcheques_Enter(sender As Object, e As EventArgs) Handles tabcheques.Enter
        'If InStrRev(DatosAcceso.Moduloacc, "5c") = 0 Then
        '    MsgBox("NO esta autorizado")
        '    
        '    Exit Sub
        'End If

        'cargamos bancos
        Dim tablabco As New MySql.Data.MySqlClient.MySqlDataAdapter("select distinct(banco) from fact_cheques order by banco desc", conexionPrinc)
        Dim readbco As New DataSet
        tablabco.Fill(readbco)
        cmbchequebanco.DataSource = readbco.Tables(0)
        cmbchequebanco.DisplayMember = readbco.Tables(0).Columns(0).Caption.ToString

        'cargamos estados cheques
        Dim tablaest As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_cheques_estado order by estado desc", conexionPrinc)
        Dim readest As New DataSet
        tablaest.Fill(readest)
        cmbchequeestado.DataSource = readest.Tables(0)
        cmbchequeestado.DisplayMember = readest.Tables(0).Columns(1).Caption.ToString
        cmbchequeestado.ValueMember = readest.Tables(0).Columns(0).Caption.ToString
        'cmbcondiva.SelectedValue = 4

        'cmbcondiva.SelectedValue = 4
    End Sub

    Private Sub tabchequespropios_Enter(sender As Object, e As EventArgs) Handles tabchequespropios.Enter
        'If InStrRev(DatosAcceso.Moduloacc, "5d") = 0 Then
        '    MsgBox("NO esta autorizado")
        '    cmdbuscarchequepropio.Enabled = False
        '    Exit Sub
        'End If
    End Sub

    Private Sub tabestadocuentas_Enter(sender As Object, e As EventArgs) Handles tabestadocuentas.Enter
        'If InStrRev(DatosAcceso.Moduloacc, "5e") = 0 Then
        '    MsgBox("NO esta autorizado")
        '    cmdverestadocuentas.Enabled = False
        '    Exit Sub
        'End If
    End Sub

    Private Sub tabcuentasclientes_Enter(sender As Object, e As EventArgs) Handles tabcuentasclientes.Enter
        'If InStrRev(DatosAcceso.Moduloacc, "5f") = 0 Then
        '    MsgBox("NO esta autorizado")
        '    txtcuentabus.Enabled = False
        '    txtcliebus.Enabled = False
        '    Exit Sub
        'End If

    End Sub

    Private Sub tabcuentasproveedores_Enter(sender As Object, e As EventArgs) Handles tabcuentasproveedores.Enter
        'If InStrRev(DatosAcceso.Moduloacc, "5g") = 0 Then
        '    MsgBox("NO esta autorizado")
        '    cmbproveedores.Enabled = False
        '    Exit Sub
        'End If
        Dim tablaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, razon from fact_proveedores", conexionPrinc)
        Dim readprov As New DataSet
        tablaprov.Fill(readprov)
        cmbproveedores.DataSource = readprov.Tables(0)
        cmbproveedores.DisplayMember = readprov.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbproveedores.ValueMember = readprov.Tables(0).Columns(0).Caption.ToString
        cmbproveedores.SelectedIndex = -1
    End Sub

    Private Sub tabconfiguracion_Enter(sender As Object, e As EventArgs) Handles tabconfiguracion.Enter
        'If InStrRev(DatosAcceso.Moduloacc, "5h") = 0 Then
        '    MsgBox("NO esta autorizado")
        '    TabControl2.Visible = False
        '    Exit Sub
        'End If
        cargardatosempresa()

    End Sub
    Private Sub cargardatosempresa()
        Try
            Reconectar()
            Dim datosEmp As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_empresa where id=1 ", conexionPrinc)
            Dim tablaemp As New DataTable
            Dim infoemp() As DataRow
            datosEmp.Fill(tablaemp)
            infoemp = tablaemp.Select("")
            txtdatosempfantasia.Text = infoemp(0)(1)
            txtdatosemprazon.Text = infoemp(0)(2)
            txtdatosempdireccion.Text = infoemp(0)(3)
            txtdatosemplocalidad.Text = infoemp(0)(4)
            txtdatosempcuit.Text = infoemp(0)(6)
            txtdatosempingbrutos.Text = infoemp(0)(7)
            txtdatosempinicioact.Text = infoemp(0)(9)
            txtdatosempdrei.Text = infoemp(0)(10)
            If Not IsDBNull(infoemp(0)(11)) Then pctdatosemplogo.Image = Bytes_Imagen(infoemp(0)(11))

            lblfactelectroptovta.Text = "Punto de venta electronico: " & FacturaElectro.puntovtaelect
            lblfactelectrocuit.Text = "CUIT: " & FacturaElectro.cuit
            lblfactelectrocertif.Text = "Certificado digital: " & FacturaElectro.certificado

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tabstockvalorizado_Enter(sender As Object, e As EventArgs) Handles tabstockvalorizado.Enter

        cargarStockValorizado()
        Dim i As Integer
        Dim sumatot As Double
        For i = 0 To dtstockvalorizado.Rows.Count - 1
            sumatot += dtstockvalorizado.Rows(i).Cells(1).Value
        Next
        dttotstock.Rows.Clear()
        dttotstock.Rows.Add("TOTAL", sumatot)
        dttotstock.Rows(dttotales.RowCount - 1).DefaultCellStyle.BackColor = Color.YellowGreen
        dttotstock.Rows(dttotales.RowCount - 1).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)

    End Sub

    Private Sub tabgraficas_Enter(sender As Object, e As EventArgs) Handles tabgraficas.Enter
        'If InStrRev(DatosAcceso.Moduloacc, "5l") = 0 Then
        '    MsgBox("NO esta autorizado")
        '    cmdcargargrafico.Enabled = False
        '    Exit Sub
        'End If
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        GenerarExcel(dtlistacob)
    End Sub

    Private Sub cmdAplicarRecibo_Click(sender As Object, e As EventArgs) Handles cmdAplicarRecibo.Click
        Try
            If dtcuentaclie.CurrentRow.Cells(7).Value = 5 Then
                MsgBox("aplicar recibo")
                With selfac
                    .LLAMA = "ingreso"
                    .provclie = txtcuentabus.Text
                    .fila = dtcuentaclie.CurrentRow.Cells(2).Value
                    .Show()
                    .TopMost = True
                    .AplicarRec = True
                    .lbltotalrecibo.Text = "Total recibo: " & dtcuentaclie.CurrentRow.Cells(4).Value & " -- "
                End With
            Else
                MsgBox("El comprobante seleccionado no es un recibo")
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub cmdbuscarremitos_Click(sender As Object, e As EventArgs) Handles cmdbuscarremitos.Click
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
        Dim columna As Integer
        Try

            Dim desde As String = Format(CDate(dtderemitos.Value), "yyyy-MM-dd")
            Dim hasta As String = Format(CDate(dthastaremitos.Value), "yyyy-MM-dd")
            Dim parambusq As String = " and fact.tipofact=20 "


            Reconectar()
            Dim tablaprod As New DataTable
            'Dim filasProd() As DataRow
            If rdninguno.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT " _
                & " fact.id, concat(fis.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) as factnum ,fact.fecha,fact.razon,fact.direccion, " _
                & " fact.localidad, con.condicion, " _
                & " fact.observaciones, fact.tipofact from fact_conffiscal as fis, fact_facturas as fact, fact_condventas as con " _
                & " where fis.donfdesc=fact.tipofact and con.id=fact.condvta " _
                & " and fact.fecha between '" & desde & "' and '" & hasta & "'" & parambusq, conexionPrinc)

                consulta.Fill(tablaprod)
            End If


            Dim i As Integer


            dtremitos.DataSource = tablaprod
            'dtfacturas.Columns(0).Visible = False

            lbltotalfact.Text = SumarTotal(dtfacturas, columna)
            'filasProd = tablaprod.Select(" num_fact >0")
            'dtfacturas.Rows.Clear()

            'For i = 0 To filasProd.GetUpperBound(0)
            'dtfacturas.Rows.Add(filasProd(i)(0), CompletarCeros(filasProd(i)(1), 1), filasProd(i)(1))
            'Next
            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub

    Private Sub cmdreimprimirremitos_Click(sender As Object, e As EventArgs) Handles cmdreimprimirremitos.Click
        Try
            Dim idFactura As Integer = dtremitos.CurrentRow.Cells(0).Value
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas

            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, " _
            & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.fecha as facfech, " _
            & "concat(fac.id_cliente,'-',fac.razon,' - tel: ',cl.telefono) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, " _
            & "concat(vend.apellido,', ',vend.nombre) as facvend, fac.condvta as faccondvta, fac.observaciones as facobserva,fac.iva105, fac.iva21, fac.total,'',fis.donfdesc as descfact " _
            & "FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac  " _
            & "where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and fac.id=" & idFactura, conexionPrinc)

            tabEmp.Fill(fac.Tables("factura_enca"))
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "cantidad as cant, descripcion, iva ,punit ,ptotal as ptotal from fact_items where id_fact=" & idFactura, conexionPrinc)
            tabFac.Fill(fac.Tables("facturax"))
            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\remito.rdlc"
                '.rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\facturax.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("facturax")))
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button13_Click_1(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            If MsgBox("Esta seguro que desea anular este remito?", vbYesNo + vbQuestion) = vbNo Then
                Exit Sub
            End If
            Dim idFactura As Integer = dtremitos.CurrentRow.Cells(0).Value
            Dim sql As String = "update fact_facturas set razon='REMITO ANULADO', direccion='REMITO ANULADO', localidad='REMITO ANULADO'," _
            & "tipocontr='REMITO ANULADO', cuit='REMITO ANULADO', subtotal=0,iva105=0, iva21=0, total=0 where id=" & idFactura

            Dim comandodelfact As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            comandodelfact.ExecuteNonQuery()

            Dim consultaitmtrab As New MySql.Data.MySqlClient.MySqlDataAdapter("select cod from fact_items where id_fact=" & idFactura, conexionPrinc)
            Dim tablaitm As New DataTable
            Dim infoitm() As DataRow
            consultaitmtrab.Fill(tablaitm)
            infoitm = tablaitm.Select("")
            Dim numtrab As Integer
            Dim i As Integer
            For i = 0 To infoitm.GetUpperBound(0)
                If InStr(infoitm(i)(0), "&") <> 0 Then
                    Reconectar()
                    numtrab = Replace(infoitm(i)(0), "&", "")
                    sql = "update tecni_taller set trab_estado=3 where id=" & numtrab
                    Dim consultaupdtrab As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
                    consultaupdtrab.ExecuteNonQuery()
                End If
            Next

            sql = "delete from fact_items where id_fact=" & idFactura
            Dim consultadelitm As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            consultadelitm.ExecuteNonQuery()

            MsgBox("REMITO anulada correctamente")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button15_Click_1(sender As Object, e As EventArgs) Handles Button15.Click
        Try
            Dim idFactura As Integer = dtfacturas.CurrentRow.Cells(0).Value
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas
            Dim fa As Boolean

            Reconectar()
            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT " _
            & "fac.razon as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr, " _
            & "fac.cuit as faccuit, fac.vendedor as facvend, fac.condvta as faccondvta, fac.total, fac.ptovta, fac.id_cliente,fac.tipofact, fac.remito,fac.fecha " _
            & "FROM fact_facturas as fac  " _
            & "where fac.id=" & idFactura, conexionPrinc)
            tabEmp.Fill(fac.Tables("EncaRemito"))
            Dim encabezado() As DataRow
            encabezado = fac.Tables("EncaRemito").Select()

            If encabezado(0)(11) <> 0 Then
                MsgBox("Esta factura ya esta remitada")
                Exit Sub
            End If

            If encabezado(0)(10) = 4 Or encabezado(0)(10) = 5 Or encabezado(0)(10) = 6 Then
                fa = True
            End If
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "cantidad as cant, descripcion, iva ,punit ,ptotal as ptotal,cod as codigo from fact_items where id_fact=" & idFactura, conexionPrinc)
            tabFac.Fill(fac.Tables("facturax"))
            Dim items() As DataRow
            items = fac.Tables("facturax").Select()

            Dim ptovta As String = 1 'encabezado(0)(8)
            Dim tipoFact As Integer = 20
            Dim num_remit As Integer = ObtenerNumerosFact(tipoFact, ptovta)
            Dim idRemito As Integer
            Dim coef As Double = 0
            Dim SqlQuery As String

            If MsgBox("el numero de remito sera: " & ptovta & "-" & num_remit & "   esto es correcto? ", vbYesNo + vbQuestion) = vbNo Then
                Exit Sub
            End If

            Dim fecha As String = Format(CDate(encabezado(0)(12)), "yyyy-MM-dd")
            Dim razon As String = encabezado(0)(0)
            Dim direccion As String = encabezado(0)(1)
            Dim localidad As String = encabezado(0)(2)
            Dim tipocontr As String = encabezado(0)(3)
            Dim cuit As String = encabezado(0)(4)
            Dim vendedor As String = encabezado(0)(5)
            Dim condvta As Integer = encabezado(0)(6)
            Dim total As String = encabezado(0)(7)
            Dim idcliente As String = encabezado(0)(9)
            Dim transporte As String = ""

            Reconectar()
            SqlQuery = "insert into fact_facturas  " _
                & "(tipofact,ptovta, num_fact,fecha,id_cliente,razon,direccion,localidad,tipocontr,cuit,condvta,subtotal,iva105,iva21,total,vendedor,observaciones2) values " _
                & "(?tipofact, ?ptov,?nfac,?fech,?idclie,?razon,?dire,?loca,?tipocont,?cuit,?condvta,?subt,?105,?21,?tot,?vend,?transp)"

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?ptov", Val(ptovta))
                .AddWithValue("?tipofact", tipoFact)
                .AddWithValue("?nfac", Val(num_remit))
                .AddWithValue("?fech", fecha)
                .AddWithValue("?idclie", idcliente)
                .AddWithValue("?razon", razon)
                .AddWithValue("?dire", direccion)
                .AddWithValue("?loca", localidad)
                .AddWithValue("?tipocont", tipocontr)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?condvta", condvta)
                .AddWithValue("?subt", 0)
                .AddWithValue("?105", 0)
                .AddWithValue("?21", 0)
                .AddWithValue("?tot", total)
                .AddWithValue("?vend", vendedor)
                .AddWithValue("?transp", transporte)
            End With
            comandoadd.ExecuteNonQuery()
            idRemito = comandoadd.LastInsertedId

            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_conffiscal set confnume=" & Val(num_remit) & " where id= " & tipoFact
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()



            'asignamos el remito a la factura
            SqlQuery = "update fact_facturas set remito=?idremito where id=?idfactura"
            Reconectar()
            Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, conexionPrinc)
            With comandoupd.Parameters
                .AddWithValue("?idremito", idRemito)
                .AddWithValue("?idfactura", idFactura)
            End With
            comandoupd.ExecuteNonQuery()



            Dim cod As String
            Dim cantidad As String
            Dim descripcion As String
            Dim iva As String
            Dim punit As String
            Dim ptotal As String
            Dim codbar As String
            Dim i As Integer

            If Val(num_remit) = 0 Then
                MsgBox("No se pueden guardar los items del remito")
                Exit Sub
            End If

            For i = 0 To items.GetUpperBound(0)

                If fa = True Then
                    coef = (items(i)(2) + 100) / 100
                End If
                cod = items(i)(5)
                codbar = "0"
                cantidad = items(i)(0)
                descripcion = items(i)(1)
                iva = items(i)(2)
                punit = items(i)(3) * coef
                ptotal = items(i)(4) * coef


                SqlQuery = "insert into fact_items " _
                & "(cod,cantidad, descripcion, iva, punit, ptotal, tipofact,ptovta,num_fact,id_fact) values" _
                & "(?cod, ?cant,?desc,?iva,?punit,?ptot,?tipofact,?ptovta,?num_fact,?id_fact)"

                Reconectar()
                Dim comandoadditm As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, conexionPrinc)
                With comandoadditm.Parameters

                    .AddWithValue("?cod", cod)
                    .AddWithValue("?cant", cantidad)
                    .AddWithValue("?desc", descripcion)
                    .AddWithValue("?iva", iva)
                    .AddWithValue("?punit", punit)
                    .AddWithValue("?ptot", ptotal)
                    .AddWithValue("?tipofact", tipoFact)
                    .AddWithValue("?ptovta", ptovta)
                    .AddWithValue("?num_fact", num_remit)
                    .AddWithValue("?id_fact", idRemito)
                End With
                comandoadditm.ExecuteNonQuery()
            Next

            'imprimimos
            'Reconectar()

            'tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            '& "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            '& "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, " _
            '& "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.fecha as facfech, " _
            '& "concat(fac.id_cliente,'-',fac.razon,' - tel: ',cl.telefono) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, " _
            '& "concat(vend.apellido,', ',vend.nombre) as facvend, fac.condvta as faccondvta, fac.observaciones2 as facobserva,fac.iva105, fac.iva21," _
            '& "fac.total,'',fis.donfdesc " _
            '& "FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac  " _
            '& "where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.id=fac.tipofact and fac.id=" & idRemito, conexionPrinc)

            'tabEmp.Fill(fac.Tables("factura_enca"))
            'Reconectar()

            'tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            '& "cantidad as cant, descripcion,iva,punit,ptotal from fact_items where " _
            '& "id_fact=" & idRemito, conexionPrinc)
            'tabFac.Fill(fac.Tables("facturax"))

            'Dim imprimirx As New imprimirFX
            'With imprimirx
            '    .MdiParent = Me.MdiParent
            '    .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            '    .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\remito.rdlc"
            '    .rptfx.LocalReport.DataSources.Clear()
            '    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
            '    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("facturax")))
            '    .rptfx.DocumentMapCollapsed = True
            '    .rptfx.RefreshReport()

            '    .Show()
            'End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub chkvencepropio_CheckedChanged(sender As Object, e As EventArgs) Handles chkvencepropio.CheckedChanged
        If chkvencepropio.Checked = True Then
            dtdechequepropio.Enabled = True
            dtphastachequepropio.Enabled = True
        Else
            dtdechequepropio.Enabled = False
            dtphastachequepropio.Enabled = False

        End If
    End Sub

    Private Sub chkseriepropio_CheckedChanged(sender As Object, e As EventArgs) Handles chkseriepropio.CheckedChanged
        If chkseriepropio.Checked = True Then
            txtseriepropio.Enabled = True
        Else
            txtseriepropio.Enabled = False
        End If
    End Sub

    Private Sub chkbancopropio_CheckedChanged(sender As Object, e As EventArgs) Handles chkbancopropio.CheckedChanged
        If chkbancopropio.Checked = True Then
            cmbbancopropio.Enabled = True
        Else
            cmbbancopropio.Enabled = False
        End If
    End Sub

    Private Sub cmbimplistacheques_Click(sender As Object, e As EventArgs) Handles cmbimplistacheques.Click
        GenerarExcel(dtcheques)
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim fe As New WSAFIPFE.Factura
        Dim existecomp As Boolean
        Dim lresultado As Boolean

        lresultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, FacturaElectro.cuit, Application.StartupPath & FacturaElectro.certificado, Application.StartupPath & FacturaElectro.licencia)
        fe.ArchivoCertificadoPassword = FacturaElectro.passcertificado
        If lresultado Then
            lresultado = fe.f1ObtenerTicketAcceso()
        End If

        existecomp = fe.F1CompConsultar(txtptovtaconsul.Text, txttipocbte.Text, txtfacturaconsul.Text)
        If existecomp Then
            txtresultadoconsulta.Text = ""
            txtresultadoconsulta.Text &= "Numero de Comprobante: " & fe.F1CabeceraPtoVta & "-" & fe.F1DetalleCbteDesdeS & vbNewLine
            txtresultadoconsulta.Text &= "Cuit del comprador: " & fe.F1DetalleDocNro & vbNewLine
            txtresultadoconsulta.Text &= "Numero de CAE otorgado: " & fe.F1RespuestaDetalleCae & vbNewLine
            txtresultadoconsulta.Text &= "Fecha de Vto CAE: " & fe.F1RespuestaDetalleCAEFchVto & vbNewLine
            txtresultadoconsulta.Text &= "Fecha del Comprobante: " & fe.F1DetalleCbteFch & vbNewLine

            txtresultadoconsulta.Text &= "Importe de la factura: " & fe.F1DetalleImpTotal & vbNewLine & "Neto: " _
            & fe.F1DetalleImpNeto & vbNewLine & "ALICUOTAS:" & fe.F1DetalleIvaItemCantidad & vbNewLine & vbNewLine
            Dim i As Integer
            For i = 0 To fe.F1DetalleIvaItemCantidad - 1
                fe.f1IndiceItem = i
                txtresultadoconsulta.Text &= "alicuota " & fe.F1DetalleIvaId & vbNewLine & "importe neto:" & fe.F1DetalleIvaBaseImp & vbNewLine & vbNewLine
            Next
            txtresultadoconsulta.Text &= "Codigo de barras: " & fe.f1CodigoDeBarraAFIP & vbNewLine & vbNewLine

        Else
            MsgBox("No existe comprobante")
        End If

    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        cargarCuentaClie(Val(txtcuentabus.Text))
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim i As Integer
        For i = 0 To frmprincipal.MdiChildren.Length - 1
            If frmprincipal.MdiChildren(i).Name = "movimientocaja" Then
                'frmprincipal.MdiChildren(i).BringToFront()
                MsgBox("la ventana de movimiento de cuenta ya esta abierta, por favor complete la operacion antes de efectuar otra", vbCritical)
                Exit Sub
            End If
        Next

        Dim mov As New movimientodecaja
        mov.MdiParent = Me.MdiParent
        mov.movrap = True
        mov.movraptip = 6
        mov.movrapclie = cmbproveedores.SelectedValue
        mov.Show()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        cargarCuentaProv(cmbproveedores.SelectedValue)
    End Sub
    Private Sub dtlistasprecio_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtlistasprecio.CellEndEdit
        Reconectar()
        Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("update fact_listas_precio set nombre=?nmb, utilidad=?util where id=?id", conexionPrinc)
        With comandoadd.Parameters
            .AddWithValue("?nmb", dtlistasprecio.Rows(e.RowIndex).Cells(1).Value)
            .AddWithValue("?util", dtlistasprecio.Rows(e.RowIndex).Cells(2).Value)
            .AddWithValue("?id", dtlistasprecio.Rows(e.RowIndex).Cells(0).Value)
        End With
        comandoadd.ExecuteNonQuery()
        ' MsgBox("Lista de precio actualizada")

    End Sub

    Private Sub dtmoneda_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtmoneda.CellEndEdit
        Reconectar()
        Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("update fact_moneda set nombre=?nmb, cotizacion=?coti where id=?id", conexionPrinc)
        With comandoadd.Parameters
            .AddWithValue("?nmb", dtmoneda.Rows(e.RowIndex).Cells(1).Value)
            .AddWithValue("?coti", dtmoneda.Rows(e.RowIndex).Cells(2).Value)
            .AddWithValue("?id", dtmoneda.Rows(e.RowIndex).Cells(0).Value)
        End With
        comandoadd.ExecuteNonQuery()
        MsgBox("Moneda actualizada")

    End Sub


    Private Sub dtlistasprecio_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtlistasprecio.UserDeletingRow
        If MsgBox("Esta seguro que desea eliminar esta lista de precios?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("delete from fact_listas_precio where id=?id", conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?id", e.Row.Cells(0).Value)
            End With
            comandoadd.ExecuteNonQuery()
            MsgBox("lista eliminada")
        Else
            e.Cancel = True
        End If
    End Sub


    Private Sub dtlistasprecio_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtlistasprecio.UserAddedRow
        Try
            Reconectar()
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_listas_precio (nombre,utilidad) values " _
        & "(?nmb,?util)", conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?nmb", dtlistasprecio.CurrentRow.Cells(1).Value.ToString.ToUpper)
                .AddWithValue("?util", dtlistasprecio.CurrentRow.Cells(2).Value)
                '.AddWithValue("?id", dtlistasprecio.Rows(e.RowIndex).Cells(0).Value)
            End With
            comandoadd.ExecuteNonQuery()
            dtlistasprecio.CurrentRow.Cells(0).Value = comandoadd.LastInsertedId
            'cargarListas()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmbptovtaconf_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbptovtaconf.SelectionChangeCommitted

    End Sub

    Private Sub TabPage5_Enter(sender As Object, e As EventArgs) Handles TabPage5.Enter
        txtptovtaconsul.Text = FacturaElectro.puntovtaelect
    End Sub


    Private Sub dtcategorias_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtcategorias.CellEndEdit
        Try
            Reconectar()
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("update fact_categoria_insum set nombre=?nmb where id=?id", conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?nmb", dtcategorias.CurrentRow.Cells(1).Value)
                .AddWithValue("?id", dtcategorias.CurrentRow.Cells(0).Value)
            End With
            comandoadd.ExecuteNonQuery()
            'MsgBox("categoria actualizada  ")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtdescuentos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtdescuentos.CellEndEdit
        Try
            Dim compramin As Double = dtdescuentos.CurrentRow.Cells(2).Value
            Dim descuento As Double = dtdescuentos.CurrentRow.Cells(3).Value
            Dim iddesc As Integer = dtdescuentos.CurrentRow.Cells(0).Value
            Reconectar()
            Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_promociones set compra_min='" & compramin & "', descuento_porc='" & descuento & "' " &
            "where id=" & iddesc, conexionPrinc)
            comandoupd.ExecuteNonQuery()
            MsgBox("Promocion actualizada")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdbalancebuscar_Click(sender As Object, e As EventArgs) Handles cmdbalancebuscar.Click
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
            Dim columna As Integer
            Dim fecha As String = Format(CDate(dtpbalancefecha.Value), "yyyy-MM-dd")
            'Dim hasta As String = Format(CDate(dtpbalancehasta.Value), "yyyy-MM-dd")
            Dim tablabal As New DataTable
            tablabal.Clear()
            ' Dim parambusq As String = " and fac.tipofact in ('5') "
            'If rdbalancediario.Checked = True Then
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
			concat(lpad(itm.ptovta,4,'0'),'-', lpad(itm.num_fact,8,'0')) as factura,
            fact.fecha,  
            round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad),2) as pcosto,
			round(sum(itm.ptotal),2) as pventa, 
            round(sum(itm.ptotal) - sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad),2)  as ganancia      
            FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
            ins.id=itm.cod and fact.id=itm.id_fact and 
            itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
            fact.fecha like '" & fecha & "' group by itm.num_fact", conexionPrinc)
            'columna = 6

            consulta.Fill(tablabal)
            'MsgBox(consulta.SelectCommand.CommandText)
            lstbalancecomprobantes.DataSource = tablabal
            lblbalancecosto.Text = "Total costo: $" & Math.Round(SumarTotal(lstbalancecomprobantes, 2), 2)
            lblbalanceventas.Text = "Total ventas: $" & Math.Round(SumarTotal(lstbalancecomprobantes, 3), 2)
            lblbalanceganancia.Text = "Total ganancia: $" & Math.Round(SumarTotal(lstbalancecomprobantes, 4), 2)
            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub
    Private Function ExisteBalance() As Boolean
        Try
            Reconectar()
            Dim fecha As String = Format(CDate(dtpbalancefecha.Value), "yyyy-MM-dd")
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_balances_diarios where fecha like '" & fecha & "'", conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            If tablacl.Rows.Count <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function
    Private Sub cmdbalanceGuardar_Click(sender As Object, e As EventArgs) Handles cmdbalanceGuardar.Click
        Try
            Reconectar()
            If ExisteBalance() = True Then
                MsgBox("No se puede guardar este balance, puede que exista ya en la base de datos. por favor verifique")
                Exit Sub
            End If
            Dim fecha As String = Format(CDate(dtpbalancefecha.Value), "yyyy-MM-dd")
            Dim total_ventas As String = SumarTotal(lstbalancecomprobantes, 3)
            Dim total_costo As String = SumarTotal(lstbalancecomprobantes, 2)
            Dim total_ganancia As String = SumarTotal(lstbalancecomprobantes, 4)
            Dim sqlQuery As String = "insert into fact_balances_diarios (fecha,total_ventas, total_costo, total_ganancia) values
            ('" & fecha & "','" & total_ventas & "','" & total_costo & "','" & total_ganancia & "')"
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteNonQuery()

            MsgBox("el balance ha sido guardado")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtpbalancefecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpbalancefecha.ValueChanged
        cmdbalancebuscar.PerformClick()
    End Sub

    Private Sub cmdbalhistorbuscar_Click(sender As Object, e As EventArgs) Handles cmdbalhistorbuscar.Click
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
            Dim desde As String = Format(CDate(dtpbalancede.Value), "yyyy-MM-dd")
            Dim hasta As String = Format(CDate(dtpbalancehasta.Value), "yyyy-MM-dd")
            Dim tablabal As New DataTable
            tablabal.Clear()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT fecha, total_ventas,total_costo,total_ganancia FROM fact_balances_diarios
            where fecha between '" & desde & "' and '" & hasta & "'", conexionPrinc)
            'columna = 6

            consulta.Fill(tablabal)
            lstbalancehistorico.DataSource = tablabal
            lblbalancecosto.Text = "Total costo: $" & Math.Round(SumarTotal(lstbalancehistorico, 2), 2)
            lblbalanceventas.Text = "Total ventas: $" & Math.Round(SumarTotal(lstbalancehistorico, 1), 2)
            lblbalanceganancia.Text = "Total ganancia: $" & Math.Round(SumarTotal(lstbalancehistorico, 3), 2)
            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim consAFIP As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_archivos order by id asc", conexionPrinc)
        Dim tablaAFIP As New DataTable
        Dim infoAFIP() As DataRow
        consAFIP.Fill(tablaAFIP)
        infoAFIP = tablaAFIP.Select("")

        Try

            If File.Exists(Application.StartupPath & "\" & infoAFIP(0)(1) & ".pfx") Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & infoAFIP(0)(1) & ".pfx")
            End If
            If File.Exists(Application.StartupPath & "\" & infoAFIP(1)(1) & ".lic") Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & infoAFIP(1)(1) & ".lic")
            End If
            If File.Exists(Application.StartupPath & "\" & infoAFIP(2)(1) & ".jpg") Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & infoAFIP(2)(1) & ".jpg")
            End If

            If tablaAFIP.Rows.Count <> 0 Then
                If Not IO.File.Exists(Application.StartupPath & "\" & infoAFIP(0)(1) & ".pfx") Then
                    If Not IsDBNull(infoAFIP(0)(2)) Then
                        Dim certificado As Byte() = infoAFIP(0)(2)
                        Dim s As IO.FileStream
                        s = IO.File.Open(Application.StartupPath & "\" & infoAFIP(0)(1) & ".pfx", IO.FileMode.Append)
                        s.Write(certificado, 0, certificado.Length)
                        s.Close()
                    End If
                End If
                    If Not IO.File.Exists(Application.StartupPath & "\" & infoAFIP(1)(1) & ".lic") Then
                    If Not IsDBNull(infoAFIP(1)(2)) Then
                        Dim licencia As Byte() = infoAFIP(1)(2)
                        Dim sL As IO.FileStream
                        sL = IO.File.Open(Application.StartupPath & "\" & infoAFIP(1)(1) & ".lic", IO.FileMode.Append)
                        sL.Write(licencia, 0, licencia.Length)
                        sL.Close()
                    End If
                End If
                    If Not IO.File.Exists(Application.StartupPath & "\" & infoAFIP(2)(1) & ".jpg") Then
                    If Not IsDBNull(infoAFIP(2)(2)) Then
                        Dim logo As Byte() = infoAFIP(2)(2)
                        Dim sL As IO.FileStream
                        sL = IO.File.Open(Application.StartupPath & "\" & infoAFIP(2)(1) & ".jpg", IO.FileMode.Append)
                        sL.Write(logo, 0, logo.Length)
                        sL.Close()
                    End If
                End If
                End If
            MsgBox("los certificados y los archivos se han descargado correctamente")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcategDefecto.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dtcategorias_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtcategorias.UserDeletingRow

        'If MsgBox("esta seguro que desea eliminar esta/s categorias/s? los productos vinculados se cambiaran a la categoria " & txtcategDefecto.Text, vbYesNo + vbQuestion) = vbYes Then
        Dim categSel As String
        Dim categDef As String = txtcategDefecto.Text
        For Each categProd As DataGridViewRow In dtcategorias.Rows
            If categProd.Selected = True Then
                If categProd.Cells(0).Value = categDef Then
                    MsgBox("no puede eliminar la categoria seleccionada por defecto, se deseleccionara la categoria y se continuara con el reemplazo")
                    categProd.Selected = False
                    Continue For
                End If
                If categSel = "" Then
                    categSel = categProd.Cells(0).Value
                Else
                    categSel += "," & categProd.Cells(0).Value
                End If

            End If
        Next
        'Dim sqlQuery As String =
        Dim comandoUPD As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos set categoria= '" & categDef & "' where categoria in (" & categSel & ")", conexionPrinc)
        'MsgBox(comandoUPD.CommandText)
        comandoUPD.ExecuteNonQuery()
        Dim comandoELIM As New MySql.Data.MySqlClient.MySqlCommand("delete from fact_categoria_insum where id  in (" & categSel & ")", conexionPrinc)
        comandoELIM.ExecuteNonQuery()

        'MsgBox("Categorias actualizadas")

        'Else
        '   e.Cancel = True
        'End If
    End Sub

    Private Sub TabPage8_Enter(sender As Object, e As EventArgs) Handles TabPage8.Enter
        cargarListas()
    End Sub

    Private Sub TabPage10_Enter(sender As Object, e As EventArgs) Handles TabPage10.Enter
        cargarCategorias()
    End Sub

    Private Sub TabPage11_Enter(sender As Object, e As EventArgs) Handles TabPage11.Enter
        cargarMoneda()
    End Sub

    Private Sub TabPage15_Enter(sender As Object, e As EventArgs) Handles TabPage15.Enter
        cargarDescuentos()
    End Sub
    Private Sub cmbptovtaconf_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbptovtaconf.SelectedValueChanged
        Try
            cargarFiscal(cmbptovtaconf.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage10_Click(sender As Object, e As EventArgs) Handles TabPage10.Click

    End Sub

    Private Sub dtcategorias_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtcategorias.CellContentClick

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
            tablabal.Clear()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 		prov.razon,
			round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad),2) as pcosto,
			round(sum(itm.ptotal),2) as pventa, 
            round(sum(itm.ptotal) - sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad),2)  as ganancia      
            FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact, fact_proveedores as prov where
            ins.id=itm.cod and fact.id=itm.id_fact and ins.codprov=prov.id and
            itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
            fact.fecha between '" & desde & "' and '" & hasta & "' group by ins.codprov order by prov.razon asc", conexionPrinc)
            'columna = 6

            consulta.Fill(tablabal)
            dtventashistoricas.DataSource = tablabal
            lblbalancecosto.Text = "Total costo: $" & Math.Round(SumarTotal(dtventashistoricas, 2), 2)
            lblbalanceventas.Text = "Total ventas: $" & Math.Round(SumarTotal(dtventashistoricas, 1), 2)
            lblbalanceganancia.Text = "Total ganancia: $" & Math.Round(SumarTotal(dtventashistoricas, 3), 2)
            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub
End Class