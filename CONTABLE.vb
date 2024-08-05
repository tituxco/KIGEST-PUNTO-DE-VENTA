Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting


Public Class CONTABLE
    Dim ModificaPlanDeCuentas As Boolean = False
    Public DtPlanCuentas As New DataTable
    Dim saldoAnteriorCuenta As Double = 0
    Dim tabCuentasConSaldos As New DataTable

    Dim idPLanCuenta As String

    Private Sub SumarTotalesCompras()
        Dim TOTneto21 As Double
        Dim TOTneto105 As Double
        Dim TOTneto27 As Double
        Dim TOTiva As Double
        Dim TOTmonot As Double
        Dim TOTacuenta As Double
        Dim TOTnogr As Double
        Dim TOTperib As Double
        Dim TOTperiv As Double
        Dim TOTgral As Double
        txtTotacuenta.Text = 0
        txtTotgral.Text = 0
        txtTotiva.Text = 0
        txtTotmono.Text = 0
        txtTotNeto.Text = 0
        txttotNeto105.Text = 0
        txttotNeto27.Text = 0
        txtTotNogr.Text = 0
        txtTotperib.Text = 0
        txtTotperiv.Text = 0
        For Each row As DataGridViewRow In dtlibrocomp.Rows
            If row.Cells.Item(14).Value <> "BIEN DE USO" Then
                TOTneto21 += FormatNumber(row.Cells.Item(6).Value, 2)
                TOTneto105 += FormatNumber(row.Cells.Item(7).Value, 2)
                TOTneto27 += FormatNumber(row.Cells.Item(8).Value, 2)
                TOTiva += FormatNumber(row.Cells.Item(9).Value, 2)
                TOTmonot += FormatNumber(row.Cells.Item(10).Value, 2)
                TOTacuenta += FormatNumber(row.Cells.Item(11).Value, 2)
                TOTnogr += FormatNumber(row.Cells.Item(12).Value, 2)
                TOTperib += FormatNumber(row.Cells.Item(13).Value, 2)
                TOTperiv += FormatNumber(row.Cells.Item(14).Value, 2)
                TOTgral += FormatNumber(row.Cells.Item(15).Value, 2)
            End If
        Next
        txtTotacuenta.Text = TOTacuenta
        txtTotgral.Text = TOTgral
        txtTotiva.Text = TOTiva
        txtTotmono.Text = TOTmonot
        txtTotNeto.Text = TOTneto21
        txttotNeto105.Text = TOTneto105
        txttotNeto27.Text = TOTneto27
        txtTotNogr.Text = TOTnogr
        txtTotperib.Text = TOTperib
        txtTotperiv.Text = TOTperiv
    End Sub
    Private Sub CONTABLE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtdesdefact.Value = obtenerPrimerDiaMes()
        dtpdecob.Value = obtenerPrimerDiaMes()
        'dtpdeestado.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
        dtpchequesde.Value = obtenerPrimerDiaMes()
        dtpdesdedetallecta.Value = obtenerPrimerDiaMes()
        dtdesdecuentaprov.Value = obtenerPrimerDiaMes()
        dtpgastosdesde.Value = obtenerPrimerDiaMes()
        'balance.Parent = Nothing
        cmbMovimientosHistoricos.SelectedIndex = 1
        If InStr(DatosAcceso.Moduloacc, "CONFVAR") = False Then tabconfiguracion.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "CONFUSER") = False Then tabUsuarios.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "CONFUSER") = False Then tabLog.Parent = Nothing

        If InStr(DatosAcceso.Moduloacc, "4ak") = False Then tabBalanceCtas.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ak") = False Then tabplancuentas.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ak") = False Then tablibromayor.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ak") = False Then tabEjercicios.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4aa") = False Then tabcomprobantes.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ab") = False Then tabcobranzas.Parent = Nothing
        ''If InStr(DatosAcceso.Moduloacc, "4ac") = False Then balance.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ad") = False Then tabremitos.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ae") = False Then tabcheques.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4af") = False Then tabchequespropios.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ah") = False Then tabestadocuentas.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ah") = False Then tabcuentasclientes.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ai") = False Then tabcuentasproveedores.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4aj") = False Then ivaVentas.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4aj") = False Then tabCompras.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "2d") = False Then tabstockvalorizado.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4aa-4ab") = False Then tabgraficas.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "5") = False Then tabdtostecni.Parent = Nothing
        If InStr(DatosAcceso.Moduloacc, "4ea") = False Then tabmoneda.Parent = Nothing

        ' tabgraficas.Parent = Nothing
        cargarDatosGrales()
    End Sub
    Private Sub SumarTotalesvtas()
        Dim TOTmono As Double
        Dim TOTcf As Double
        Dim TOTri As Double
        Dim TOTexc As Double

        Dim TOT105 As Double
        Dim TOT21 As Double

        Dim TOTneto As Double
        Dim TOTiva As Double
        Dim TOTgral As Double

        For Each row As DataGridViewRow In dtivaventas.Rows
            If row.Cells.Item(14).Value <> "BIEN DE USO" Then
                Select Case row.Cells.Item(5).Value
                    Case "CF", "CONSUMIDOR FINAL"
                        TOTcf += row.Cells.Item(6).Value
                    Case "RI", "RESPONSABLE INSCRIPTO"
                        TOTri += row.Cells.Item(6).Value
                    Case "EX", "EXCENTO"
                        TOTexc += row.Cells.Item(6).Value
                    Case "MON", "MONOTRIBUTO"
                        TOTmono += row.Cells.Item(6).Value
                End Select
                TOT105 += row.Cells.Item(8).Value
                TOT21 += row.Cells.Item(7).Value

                TOTneto = TOTmono + TOTcf + TOTri + TOTexc

                TOTiva = TOT105 + TOT21

                TOTgral = TOTneto + TOTiva
            End If
        Next
        txtvtatotcf.Text = Math.Round(TOTcf, 2)
        txtvtatotexc.Text = Math.Round(TOTexc, 2)
        txtvtatotmono.Text = Math.Round(TOTmono, 2)
        txtvtatotri.Text = Math.Round(TOTri, 2)

        txtvtatot105.Text = Math.Round(TOT105, 2)
        txtvtatot21.Text = Math.Round(TOT21, 2)

        txtvtatotneto.Text = Math.Round(TOTneto, 2)
        txtvtatotiva.Text = Math.Round(TOTiva, 2)

        txtvtatotgral.Text = Math.Round(TOTgral, 2)
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

            Dim tablaptovta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, descripcion from fact_puntosventa", conexionPrinc)
            Dim readptovta As New DataSet
            tablaptovta.Fill(readptovta)
            cmbInforPtoVta.DataSource = readptovta.Tables(0)
            cmbInforPtoVta.DisplayMember = readptovta.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbInforPtoVta.ValueMember = readptovta.Tables(0).Columns(0).Caption.ToString

            cmbInforPtoVta2.DataSource = readptovta.Tables(0)
            cmbInforPtoVta2.DisplayMember = readptovta.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbInforPtoVta2.ValueMember = readptovta.Tables(0).Columns(0).Caption.ToString

            Dim tablaAlmacen As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_insumos_almacenes", conexionPrinc)
            Dim readAlmacen As New DataSet
            tablaAlmacen.Fill(readAlmacen)
            cmbinforalmacen.DataSource = readAlmacen.Tables(0)
            cmbinforalmacen.DisplayMember = readAlmacen.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbinforalmacen.ValueMember = readAlmacen.Tables(0).Columns(0).Caption.ToString

            Dim tablaCajas As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, descripcion from fact_cajas", conexionPrinc)
            Dim readCajas As New DataSet
            tablaCajas.Fill(readCajas)
            cmbGtosCaja.DataSource = readCajas.Tables(0)
            cmbGtosCaja.DisplayMember = readCajas.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbGtosCaja.ValueMember = readCajas.Tables(0).Columns(0).Caption.ToString

            Dim tablaConceptos As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concepto from fact_egresos_concepto", conexionPrinc)
            Dim readConceptos As New DataSet
            tablaConceptos.Fill(readConceptos)
            cmbGtosConcepto.DataSource = readConceptos.Tables(0)
            cmbGtosConcepto.DisplayMember = readConceptos.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbGtosConcepto.ValueMember = readConceptos.Tables(0).Columns(0).Caption.ToString

            'cmbvendedor.SelectedIndex = -1

            'tabCuentasConSaldos.Columns.Add("id")
            'tabCuentasConSaldos.Columns.Add("numCuenta")
            'tabCuentasConSaldos.Columns.Add("nombreCuenta")
            'tabCuentasConSaldos.Columns.Add("saldoAnterior")
            'tabCuentasConSaldos.Columns.Add("debitosMes")
            'tabCuentasConSaldos.Columns.Add("creditosMes")
            'tabCuentasConSaldos.Columns.Add("saldoMes")
            'tabCuentasConSaldos.Columns.Add("saldoFinal")
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
            Dim consAlmacen As String
            Dim consPtovta As String

            If cmbtipofac.SelectedValue = 0 And chktodosfact.Checked = False Then
                MsgBox("No selecciono tipo de factura")
                EnProgreso.Close()
                Exit Sub
            ElseIf cmbtipofac.SelectedValue <> 0 And chktodosfact.Checked = False Then
                Dim SelPtoVta As String = cmbtipofac.Text.ToString.Substring(1, 1)

                parambusq = " and fact.tipofact=" & cmbtipofac.SelectedValue & " and fact.ptovta=" & SelPtoVta
            ElseIf cmbtipofac.SelectedValue = 0 And chktodosfact.Checked = True Then
                parambusq = " and fact.tipofact in( select donfdesc from tipos_comprobantes where tip =1)"
            End If
            If cmbinforalmacen.SelectedValue = 0 Then
                consAlmacen = " and itm.idAlmacen like '%' " 'es el almacen no el punto de venta, esta mal el nombre
            Else
                consAlmacen = " and itm.idAlmacen = " & cmbinforalmacen.SelectedValue & " "
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
                fact.id, concat(fis.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) as FacturaNum,
                fact.fecha,fact.razon,fact.direccion, 
                fact.localidad, con.condicion, 
                case when fis.debcred='C' then 
                concat('-',FORMAT(fact.total,2,'es_AR')) 

                else FORMAT(fact.total,2,'es_AR') end as total, 
                (select codigoAsiento from cm_libroDiario where comprobanteInterno like FacturaNum limit 1) as NumeroAsiento,
                fact.observaciones2 as ReciboAplicado, fact.tipofact, fact.ptovta,fact.f_alta
                from fact_conffiscal as fis, fact_facturas as fact, fact_condventas as con, fact_items as itm 
                where fis.donfdesc=fact.tipofact and con.id=fact.condvta and fis.ptovta=fact.ptovta and fact.id=itm.id_fact                
                and fact.fecha between  '" & desde & "' and '" & hasta & "'" & parambusq & consAlmacen &
                "group by fact.id", conexionPrinc)
                columna = 7
                'MsgBox(consulta.SelectCommand.CommandText)
                consulta.Fill(tablaprod)
                'MsgBox(consulta.SelectCommand.CommandText)
            End If
            If rdventadiaria.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT '' as factid, 'TOTAL DIARIO' as factnum ,fact.fecha as fecha,'-' as razon,'-' as direccion, 
                '-' as localidad, '-' as condicion,  FORMAT(sum(itm.ptotal),2,'es_AR') as total, '' as observaciones2, ' ' as tipofact, '' as ptovta                 
                FROM fact_items as itm, fact_facturas as fact
                where itm.id_fact=fact.id and fact.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') 
                and fact.fecha between '" & desde & "' and '" & hasta & "'" & consAlmacen & " group by fact.fecha", conexionPrinc)
                columna = 7
                consulta.Fill(tablaprod)
            End If


            Dim i As Integer


            dtfacturas.DataSource = tablaprod
            dtfacturas.Columns(0).Visible = False
            dtfacturas.Columns(10).Visible = False
            dtfacturas.Columns(11).Visible = False
            lbltotalfact.Text = SumarTotal(dtfacturas, columna, 0)
            lbltotalCobrado.Text = SumarTotal(dtfacturas, columna, 1)

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

            Dim consultaSTR As String = ""

            Reconectar()
            'MsgBox(cmbMovimientosHistoricos.SelectedIndex)
            If cmbMovimientosHistoricos.SelectedIndex = 0 Or cmbMovimientosHistoricos.SelectedIndex = -1 Then
                consultaSTR = "
            SELECT 
            fact.id,fact.fecha,tip.abrev, LPAD(fact.ptovta, 4, '0'),LPAD(fact.num_fact, 8, '0'), format((fact.total),2,'es_AR') AS total,
            fact.tipofact,fact.pago,fact.id as idfactura,fact.id_cliente from
            tipos_comprobantes as tip, fact_facturas as fact where         
            tip.donfdesc = fact.tipofact AND 
            tip.ptovta = fact.ptovta and 
            fact.id_cliente<>9999 and
            fact.tipofact in (select donfdesc from tipos_comprobantes where debcred ='D' or debcred ='C')
            and fact.id_cliente=" & idcliente & "
            order by fecha,id asc"
            Else
                consultaSTR = "SELECT * FROM cuentaclie where id_cliente=" & idcliente & " order by fecha,id asc"
            End If
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(consultaSTR, conexionPrinc)
            ' MsgBox(consulta.SelectCommand.CommandText)
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
                    Case 1, 2, 6, 7, 11, 12, 999, 992
                        If dias <= 0 Then
                            debegral += FormatNumber(tablacta(i)(5), 2)
                            saldo = FormatNumber(debegral - habergral, 2)
                            dtcuentaclie.Rows.Add(
                            tablacta(i)(0), tablacta(i)(1).ToString, tablacta(i)(2) & " " & tablacta(i)(3) & "-" & tablacta(i)(4), tablacta(i)("total"), "0", saldo, tablacta(i)(8), tablacta(i)(6))
                            If tablacta(i)(7) = 1 Then
                                dtcuentaclie.Rows(dtcuentaclie.RowCount - 1).DefaultCellStyle.BackColor = Color.GreenYellow
                            End If
                        Else
                            debegral += FormatNumber(tablacta(i)(5), 2)
                            saldoant = FormatNumber(debegral - habergral, 2)
                        End If

                    Case 3, 8, 13, 991, 996
                        If dias <= 0 Then
                            habergral += FormatNumber(tablacta(i)(5), 2)
                            saldo = FormatNumber(debegral - habergral, 2)
                            dtcuentaclie.Rows.Add(tablacta(i)(0), tablacta(i)(1).ToString, tablacta(i)(2) & " " & tablacta(i)(3) & "-" & tablacta(i)(4), "0", tablacta(i)(5), saldo, tablacta(i)(8), tablacta(i)(6))
                            dtcuentaclie.Rows(dtcuentaclie.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        Else
                            habergral += FormatNumber(tablacta(i)(5), 2)
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
            'MsgBox(consulta.SelectCommand.CommandText)
            Dim i As Integer
            dtcuentaprov.Rows.Clear()

            For i = 0 To tablacta.GetUpperBound(0)
                Dim fechacomprob As Date = CType(tablacta(i)(1).ToString, Date)
                Dim fechainicio As Date = CType(dtdesdecuentaprov.Value, Date)
                Dim dias As Integer = DateDiff(DateInterval.Day, fechacomprob, fechainicio)
                Select Case tablacta(i)(6)
                    Case 1, 2, 6, 7, 11, 12, 999, 992
                        If dias <= 0 Then
                            debegral = debegral + tablacta(i)("monto")
                            saldo = FormatNumber(debegral - habergral, 2)
                            dtcuentaprov.Rows.Add(tablacta(i)("id"), tablacta(i)(3), tablacta(i)("fecha").ToString, tablacta(i)("monto"), "0", tablacta(i)("vencimiento"), saldo)
                            If tablacta(i)(8) = 1 Then
                                dtcuentaprov.Rows(dtcuentaprov.RowCount - 1).DefaultCellStyle.BackColor = Color.GreenYellow
                            End If
                        Else
                            debegral = debegral + tablacta(i)(4)
                            saldoant = FormatNumber(debegral - habergral, 2)
                        End If
                    Case 3, 8, 13, 991, 993
                        If dias <= 0 Then
                            If tablacta(i)(7) = 2 Then
                                habergral = habergral + tablacta(i)("monto")
                                saldo = FormatNumber(debegral - habergral, 2)
                                dtcuentaprov.Rows.Add(tablacta(i)("id"), tablacta(i)(3).ToString, tablacta(i)("fecha"), "0", tablacta(i)("monto"), " ", saldo)
                                dtcuentaprov.Rows(dtcuentaprov.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            End If
                        Else
                            debegral = debegral - tablacta(i)("monto")
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


        If chkvendedorctacte.Checked = True Then
            vendedor = "%"
        Else
            vendedor = cmbvendedorctacte.SelectedValue
        End If
        Dim filtro As String = ""
        If chkIgnorarCerosYNegativos.Checked = True Then
            filtro = "having saldo <>0 and saldo >0"
        End If
        Try
            Dim consultaResumenCtaCte As New MySql.Data.MySqlClient.MySqlDataAdapter(
                "select * from resumen_cta_cte where vendedor LIKE '" & vendedor & "'  " & filtro, conexionPrinc)

            Dim tablaResumenCtaCte As New DataTable


            consultaResumenCtaCte.Fill(tablaResumenCtaCte)

            dtestadocuentas.DataSource = tablaResumenCtaCte
            'Dim filaComp() As DataRow = tablaResumenCtaCte.Select()


            'creamos la tabla de datos para las cuentas
            'Dim estadocuentas As New DataTable
            'Dim columestado As DataColumn
            'Dim filaestado As DataRow

            'columestado = New DataColumn
            'columestado.DataType = System.Type.GetType("System.String")
            'columestado.ColumnName = "Cuenta"
            'estadocuentas.Columns.Add(columestado)

            'columestado = New DataColumn
            'columestado.DataType = System.Type.GetType("System.String")
            'columestado.ColumnName = "Razon Social"
            'estadocuentas.Columns.Add(columestado)

            'columestado = New DataColumn
            'columestado.DataType = System.Type.GetType("System.Decimal")
            'columestado.ColumnName = "Saldo"
            'estadocuentas.Columns.Add(columestado)

            'For Each fila As DataRow In tablaResumenCtaCte.Rows


            '    'MsgBox(filapago(0).Item(2))
            '    filaestado = estadocuentas.NewRow
            '    filaestado(0) = fila.Item(0)
            '    filaestado(1) = fila.Item(1)
            '    Dim saldo As Double
            '    Dim filapago() As Data.DataRow
            '    filapago = tablacobr.Select("cuenta like '" & fila(0) & "'")
            '    If filapago.Length = 0 Then
            '        saldo = fila.Item(2)
            '    Else
            '        saldo = Math.Round(fila.Item(2) - filapago(0).Item(2), 2)
            '    End If
            '    filaestado(2) = saldo
            '    If chknegativos.Checked = True And saldo > 0 Then
            '        estadocuentas.Rows.Add(filaestado)
            '    ElseIf chknegativos.Checked = False And saldo <> 0 Then
            '        estadocuentas.Rows.Add(filaestado)
            '    End If
            'Next
            'dtestadocuentas.DataSource = estadocuentas
            'dtestadocuentas.Columns(0).FillWeight = 30
            'dtestadocuentas.Columns(2).FillWeight = 30
            SumarTotal(dtestadocuentas, 4, 0)
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
        where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and condvent.id=fac.condvta and fac.id=" & idFactura, conexionPrinc)

        Dim tablaEmpresa As New DataTable
        tabEmp.Fill(tablaEmpresa)

        Reconectar()

        tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal 
            from fact_items where id_fact=" & idFactura, conexionPrinc)
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
            'dtcategorias.Columns(0).Width = 30

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
                parambusq = " and fac.tipofact in (select donfdesc from fact_conffiscal where tip=1)"
            End If

            If chktodosvendedores.Checked = False And cmbvendedor.SelectedValue = 0 Then
                MsgBox("debe seleccionar un vendedor")
                Exit Sub
            ElseIf chktodosvendedores.Checked = False And cmbvendedor.SelectedValue <> 0 Then
                parambusq &= " and fac.vendedor=" & cmbvendedor.SelectedValue
            End If

            Dim vendedor As String
            If chktodosvendedores.Checked = True Then
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
            'MsgBox(tabFac.SelectCommand.CommandText)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs)
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


            Dim idfactura As Integer = dtcuentaclie.CurrentRow.Cells(6).Value
            Select Case dtcuentaclie.CurrentRow.Cells(7).Value
                Case 996
                    ImprimirRecibos(idfactura)
                Case Else
                    ImprimirFactura(idfactura, 1, False)
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
        mov.movraptip = 996
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

    Private Function SumarTotal(ByRef list As DataGridView, ByVal columna As Integer, ByVal param As Integer) As Double
        Try
            'param 0 es sin instruccion
            'param 1 es para sumar lo cobrado con recibos aplicados

            Dim total As Double = 0

            'ESTE PROCESO ES PARA PODER SUMAR LA COLUMNA INDICADA
            Dim i As Integer
            For i = 0 To list.RowCount - 1
                If param = 1 Then
                    If list.Rows(i).Cells("ReciboAplicado").Value <> "" Then
                        total += FormatNumber(list.Rows(i).Cells(columna).Value, 2, , , TriState.True)
                    End If
                Else
                    total += FormatNumber(list.Rows(i).Cells(columna).Value, 2, , , TriState.True)
                End If
            Next
            Return total

            'For Each fila As DataGridViewRow In dtfacturas.Rows
            '    If fila.Cells("ReciboAplicado").Value <> "" Then
            '        totalCobrado += FormatNumber(fila.Cells(columna).Value, 2)
            '    End If
            '    total += FormatNumber(fila.Cells(columna).Value, 2)
            'Next

            'lbltotalfact.Text = total
            'lbltotalCobrado.Text = "$" & totalCobrado

            'For Each fila As DataGridViewRow In dtlistacob.Rows
            '    total += FormatNumber(fila.Cells(columna).Value, 2)
            'Next
            'lbltotcob.Text = total

            'total = 0

            'For Each fila As DataGridViewRow In dtestadocuentas.Rows
            '    total += FormatNumber(fila.Cells(columna).Value, 2)
            'Next
            'lbltotctacte.Text = total

            'total = 0

            'For Each fila As DataGridViewRow In dtcheques.Rows
            '    total += FormatNumber(fila.Cells(columna).Value, 2)
            'Next
            'lbltotalcheques.Text = total

            'total = 0
            'For Each fila As DataGridViewRow In dtchequespropios.Rows
            '    total += FormatNumber(fila.Cells(columna).Value, 2)
            'Next
            'lbltotalchequespropios.Text = total

        Catch ex As Exception

        End Try
    End Function

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles cmdverestadocuentas.Click
        cargarEstadodeCuentas()
        lbltotctacte.Text = FormatNumber(SumartTotalesColumnaTabla("saldo", dtestadocuentas), 2)

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
            Dim consPtovta As String

            If cmbInforPtoVta2.SelectedValue = 0 Then
                consPtovta = " and fact.ptovta like '%' "
            Else
                consPtovta = " and fact.ptovta = " & cmbInforPtoVta2.SelectedValue & " "
            End If
            tablacob.Clear()
            ' Dim parambusq As String = " and fac.tipofact in ('5') "
            If rdcobranzadiaria.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT fact.fecha, 
                format(sum((select replace(importe,',','.') from fact_tarjetas where comprobante=fact.id)),2,'es_AR') as totalTarjeta, 
                format(sum(replace(total,',','.')) -
                sum((select replace(importe,',','.') from fact_tarjetas where comprobante=fact.id)),2,'es_AR') as totalEfectivo, 
                format(sum(replace(total,',','.')),2,'es_AR') as totalRecibo
                FROM fact_facturas as fact                 
                where fact.tipofact=996 and fact.fecha between '" & desde & "' and '" & hasta & "' " & consPtovta &
                "group by fecha order by fecha desc", conexionPrinc)
                columna = 3
                consulta.Fill(tablacob)
                dtlistacob.DataSource = tablacob
            End If
            If rdcobranzaintervalo.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT fact.id, concat(fis.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) as ReciboNumero, fact.fecha,fact.razon, 
                format((select replace(importe,',','.') from fact_tarjetas where comprobante=fact.id),2,'es_AR') as totalTarjeta, 
                if (fact.id not in (select comprobante from fact_tarjetas),format(replace(total,',','.'),2,'es_AR'),
                format(replace(total,',','.') -
                (select replace(importe,',','.') from fact_tarjetas where comprobante=fact.id),2,'es_AR')) as totalEfectivo,
                
                format(replace(total,',','.'),2,'es_AR') as totalRecibo,

                (select codigoAsiento from cm_libroDiario where comprobanteInterno like ReciboNumero limit 1) as NumeroAsiento
                
                FROM fact_facturas as fact, fact_conffiscal as fis

                where fis.donfdesc=fact.tipofact and fis.ptovta=fact.ptovta and  fact.tipofact=996 and fact.fecha between '" & desde & "' and '" & hasta & "' " & consPtovta &
                "order by id desc", conexionPrinc)
                columna = 6
                'MsgBox(consulta.SelectCommand.CommandText)

                consulta.Fill(tablacob)
                dtlistacob.DataSource = tablacob
                dtlistacob.Columns(0).Visible = False
            End If
            If rdtarjeta.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT fact.id,fact.fecha,fact.razon, concat(fact.ptovta,'-',fact.num_fact) as ReciboNumero,                 
                format((select replace(importe,',','.') as totalTarjeta from fact_tarjetas where comprobante=fact.id and nombre like '%" & cmbTarjetasMarcas.Text.Replace(" ", "%") & "%'),2,'es_AR') as totalTarjeta			
                FROM fact_facturas as fact 
                where fact.tipofact=996 and fact.fecha between'" & desde & "' and '" & hasta & "' 
                and fact.id in (select comprobante from fact_tarjetas) " & consPtovta &
                "order by id desc", conexionPrinc)
                columna = 4
                consulta.Fill(tablacob)
                Dim bindintarjetas As New DataView(tablacob)
                bindintarjetas.RowFilter = " totalTarjeta<>'' "
                dtlistacob.DataSource = bindintarjetas
                dtlistacob.Columns(0).Visible = False
            End If
            If rdefectivo.Checked = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT fact.id,fact.fecha,fact.razon, concat(fact.ptovta,'-',fact.num_fact) as ReciboNumero, 			
                if (fact.id not in (select comprobante from fact_tarjetas),
                format(replace(total,',','.'),2,'es_AR'),format(replace(total,',','.') -
                (select replace(importe,',','.') from fact_tarjetas where comprobante=fact.id),2,'es_AR')) as totalEfectivo	
                FROM fact_facturas as fact 
                where fact.tipofact=996 and fact.fecha between'" & desde & "' and '" & hasta & "' " & consPtovta &
                " having totalEfectivo<>0
                order by id desc", conexionPrinc)
                columna = 4
                consulta.Fill(tablacob)
                dtlistacob.DataSource = tablacob
                dtlistacob.Columns(0).Visible = False
            End If
            lbltotcob.Text = SumarTotal(dtlistacob, columna, 0)
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
            'MsgBox(consulta.SelectCommand.CommandText)

            consulta.Fill(tablacheques)
            dtcheques.DataSource = tablacheques
            lbltotalcheques.Text = SumarTotal(dtcheques, 7, 0)
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
            & "che.fecha_cobro,format(che.importe,2,'es_AR') as importe, che.observaciones " _
            & "from fact_cheques as che " _
            & "where che.tipo_cheque=2 " & consul, conexionPrinc)
            MsgBox(consulta.SelectCommand.CommandText)
            Dim tablacheques As New DataTable

            consulta.Fill(tablacheques)
            dtchequespropios.DataSource = tablacheques
            lbltotalchequespropios.Text = SumarTotal(dtchequespropios, 6, 0)
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
            ImprimirRecibos(idfactura)
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
            lblFacturaElectroPasscertif.Text = "Pass:" & FacturaElectro.passcertificado



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
            If dtcuentaclie.CurrentRow.Cells(7).Value = 996 Or dtcuentaclie.CurrentRow.Cells(7).Value = 991 Or
                dtcuentaclie.CurrentRow.Cells(7).Value = 13 Or dtcuentaclie.CurrentRow.Cells(7).Value = 3 Or
                dtcuentaclie.CurrentRow.Cells(7).Value = 8 Then
                'MsgBox("aplicar recibo")
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
            Dim parambusq As String = " and fact.tipofact=998 "


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

            lbltotalfact.Text = SumarTotal(dtfacturas, columna, 0)
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
            & "cantidad as cant, descripcion, iva ,punit ,ptotal as ptotal, plu as codigo from fact_items where id_fact=" & idFactura, conexionPrinc)
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

            If encabezado(0)(10) = 1 Or encabezado(0)(10) = 2 Or encabezado(0)(10) = 3 Then
                fa = True
            End If

            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            cantidad as cant, descripcion, iva ,format(punit,2,'es_AR') ,format(ptotal,2,'es_AR') as ptotal, cod as codigo,plu from fact_items where id_fact=" & idFactura, conexionPrinc)
            Dim items As New DataTable
            tabFac.Fill(items)
            'tabFac.Fill(fac.Tables("facturax"))
            'Dim items() As DataRow
            'items = fac.Tables("facturax").Select()

            Dim ptovta As String = My.Settings.idPtoVta
            Dim tipoFact As Integer = 998
            Dim num_remit As Integer = ObtenerNumerosFact(tipoFact, ptovta)
            Dim idRemito As Integer
            Dim coef As Double = 0
            Dim SqlQuery As String

            If MsgBox("el numero de remito sera: " & ptovta & "-" & num_remit & "   esto es correcto? ", vbYesNo + vbQuestion) = vbNo Then
                Exit Sub
            End If

            Dim fecha As String = Format(CDate(Now()), "yyyy-MM-dd")
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
            sql.CommandText = "update fact_conffiscal set confnume=" & Val(num_remit) & " where donfdesc= " & tipoFact & " and ptovta=" & ptovta
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

            For i = 0 To items.Rows.Count - 1

                If fa = True Then
                    coef = (items.Rows(i).Item(2) + 100) / 100
                Else
                    coef = 1
                End If
                cod = items.Rows(i).Item(5)
                codbar = items.Rows(i).Item(6)
                cantidad = items.Rows(i).Item(0)
                descripcion = items.Rows(i).Item(1)
                iva = items.Rows(i).Item(2)
                punit = items.Rows(i).Item(3) * coef
                ptotal = items.Rows(i).Item(4) * coef
                Dim idAlmacen As Integer = My.Settings.idAlmacen
                Dim idCaja As Integer = My.Settings.CajaDef
                SqlQuery = "insert into fact_items " _
                & "(cod,cantidad, descripcion, iva, punit, ptotal, tipofact,idAlmacen,idCaja,id_fact,plu) values" _
                & "(?cod, ?cant,?desc,?iva,?punit,?ptot,?tipofact,?idAlmacen,?idCaja,?id_fact,?plu)"

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
                    .AddWithValue("?idAlmacen", idAlmacen)
                    .AddWithValue("?idCaja", idCaja)
                    .AddWithValue("?id_fact", idRemito)
                    .AddWithValue("?plu", codbar)
                End With
                comandoadditm.ExecuteNonQuery()
            Next

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
            MsgBox("Informacion de Tiket AFIP " & vbNewLine &
                       "ULTIMO mje Error: " & fe.UltimoMensajeError & vbNewLine &
                        "ULTIMO numero Error: " & fe.UltimoNumeroError & vbNewLine &
                        "modo: " & fe.Modo & vbNewLine &
                        "cuit: " & fe.cuit & vbNewLine &
                        "token: " & fe.f1token & vbNewLine &
                        "firma: " & fe.f1sign & vbNewLine &
                        "licencia codigo: " & fe.LicenciaCodigo & vbNewLine &
                        "licenciadatos: " & fe.LicenciaDatos & vbNewLine &
                        "licenciafecha: " & fe.LicenciaFecha & vbNewLine &
                        "licenciavalida2020: " & fe.LicenciaValida2020 & vbNewLine &
                        "licencia valida cae: " & fe.f1LicenciaValidaCae & vbNewLine)
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
            & fe.F1DetalleImpNeto & vbNewLine & "ALICUOTAS:" & fe.F1DetalleIvaItemCantidad & " total: " & fe.F1DetalleImpIva & vbNewLine &
             "OTROS TRIBUTOS: " & fe.F1DetalleTributoItemCantidad & " total: " & fe.F1DetalleImpTrib & vbNewLine & vbNewLine
            Dim i As Integer
            For i = 0 To fe.F1DetalleIvaItemCantidad - 1
                fe.f1IndiceItem = i
                txtresultadoconsulta.Text &= "alicuota ID " & fe.F1DetalleIvaId & vbNewLine & " importe neto:" & fe.F1DetalleIvaBaseImp & " importeIva: " & fe.F1DetalleIvaImporte & vbNewLine & vbNewLine
            Next
            txtresultadoconsulta.Text &= "OTROS TRIBUTOS: " & fe.F1DetalleTributoItemCantidad & vbNewLine & vbNewLine
            Dim j As Integer
            For j = 0 To fe.F1DetalleTributoItemCantidad - 1
                fe.f1IndiceItem = j
                txtresultadoconsulta.Text &= "Tributo: " & fe.F1DetalleTributoDesc & " Importe: " & fe.F1DetalleTributoImporte & vbNewLine & vbNewLine
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
        mov.movraptip = 993
        mov.movrapclie = cmbproveedores.SelectedValue
        mov.Show()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        cargarCuentaProv(cmbproveedores.SelectedValue)
    End Sub
    Private Sub dtlistasprecio_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtlistasprecio.CellEndEdit
        Reconectar()
        Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("update fact_listas_precio set nombre=?nmb, utilidad=?util,auxcol=?auxcol where id=?id", conexionPrinc)
        With comandoadd.Parameters
            .AddWithValue("?nmb", dtlistasprecio.Rows(e.RowIndex).Cells(1).Value)
            .AddWithValue("?util", dtlistasprecio.Rows(e.RowIndex).Cells(2).Value)
            .AddWithValue("?auxcol", dtlistasprecio.Rows(e.RowIndex).Cells(3).Value)
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
        '     Dim EnProgreso As New Form
        '     EnProgreso.ControlBox = False
        '     EnProgreso.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        '     EnProgreso.Size = New Point(430, 30)
        '     EnProgreso.StartPosition = FormStartPosition.CenterScreen
        '     EnProgreso.TopMost = True
        '     Dim Etiqueta As New Label
        '     Etiqueta.AutoSize = True
        '     Etiqueta.Text = "La consulta esta en progreso, esto puede tardar unos momentos, por favor espere ..."
        '     Etiqueta.Location = New Point(5, 5)
        '     EnProgreso.Controls.Add(Etiqueta)
        '     'Dim Barra As New ProgressBar
        '     'Barra.Style = ProgressBarStyle.Marquee
        '     'Barra.Size = New Point(270, 40)
        '     'Barra.Location = New Point(10, 30)
        '     'Barra.Value = 100
        '     'EnProgreso.Controls.Add(Barra)
        '     EnProgreso.Show()
        '     Application.DoEvents()

        '     Try
        '         Reconectar()
        '         Dim columna As Integer
        '         Dim fecha As String = Format(CDate(dtpbalancefecha.Value), "yyyy-MM-dd")
        '         'Dim hasta As String = Format(CDate(dtpbalancehasta.Value), "yyyy-MM-dd")
        '         Dim tablabal As New DataTable
        '         tablabal.Clear()
        '         ' Dim parambusq As String = " and fac.tipofact in ('5') "
        '         'If rdbalancediario.Checked = True Then
        '         Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
        'concat(lpad(itm.idAlmacen,4,'0'),'-', lpad(itm.num_fact,8,'0')) as factura,
        '         fact.fecha,  
        '         round(sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad),2) as pcosto,
        'round(sum(itm.ptotal),2) as pventa, 
        '         round(sum(itm.ptotal) - sum(replace(replace(ins.precio,'.',''),',','.') * ((ins.iva+100)/100) * itm.cantidad),2)  as ganancia      
        '         FROM fact_items as itm, fact_insumos as ins, fact_facturas as fact where
        '         ins.id=itm.cod and fact.id=itm.id_fact and 
        '         itm.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') and itm.cod<>0 and 
        '         fact.fecha like '" & fecha & "' group by itm.num_fact", conexionPrinc)
        '         'columna = 6

        '         consulta.Fill(tablabal)
        '         'MsgBox(consulta.SelectCommand.CommandText)
        '         lstbalancecomprobantes.DataSource = tablabal
        '         lblbalancecosto.Text = "Total costo: $" & Math.Round(SumarTotal(lstbalancecomprobantes, 2), 2)
        '         lblbalanceventas.Text = "Total ventas: $" & Math.Round(SumarTotal(lstbalancecomprobantes, 3), 2)
        '         lblbalanceganancia.Text = "Total ganancia: $" & Math.Round(SumarTotal(lstbalancecomprobantes, 4), 2)
        '         EnProgreso.Close()
        '     Catch ex As Exception
        '         MsgBox(ex.Message)
        '         EnProgreso.Close()
        '     End Try
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
            lblbalancecosto.Text = "Total costo: $" & Math.Round(SumarTotal(lstbalancehistorico, 2, 0), 2)
            lblbalanceventas.Text = "Total ventas: $" & Math.Round(SumarTotal(lstbalancehistorico, 1, 0), 2)
            lblbalanceganancia.Text = "Total ganancia: $" & Math.Round(SumarTotal(lstbalancehistorico, 3, 0), 2)
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

    Private Sub TabPage11_Enter(sender As Object, e As EventArgs) Handles tabmoneda.Enter
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


    Private Sub dtlistacob_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtlistacob.ColumnHeaderMouseClick
        Try

            If rdcobranzadiaria.Checked = True Then
                If e.ColumnIndex <= 6 And e.ColumnIndex >= 1 Then
                    'MsgBox(e.ColumnIndex)
                    lbltotcob.Text = SumarTotal(dtlistacob, e.ColumnIndex, 0)
                    lbltotalnombre.Text = "TOTAL " & dtlistacob.Columns(e.ColumnIndex).Name
                End If
            ElseIf rdcobranzaintervalo.Checked = True Then
                If e.ColumnIndex <= 11 And e.ColumnIndex >= 6 Then
                    'MsgBox(e.ColumnIndex)
                    lbltotcob.Text = SumarTotal(dtlistacob, e.ColumnIndex, 0)
                    lbltotalnombre.Text = "TOTAL " & dtlistacob.Columns(e.ColumnIndex).Name
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtfacturas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtfacturas.CellDoubleClick
        Try
            Dim idFactura As Integer = dtfacturas.CurrentRow.Cells(0).Value
            Dim ptovta As Integer = dtfacturas.CurrentRow.Cells(10).Value
            ImprimirFactura(idFactura, ptovta, False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        If cmbperiodocarg.Text = "" Then
            MsgBox("No selecciono ningun perido para visualizar")
            Exit Sub
        End If
        Try
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT  fact.fecha,tip.abrev as tipocom, concat(lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,'8','0')) as nufac, 
            fact.razon,trim(fact.cuit) as cuit, fact.tipocontr, round(fact.subtotal,2) as neto, round(fact.iva21,2) as iva21,
            round(fact.iva105,2) as iva105, round(fact.otroiva,2) as otroiva, 0 as ret_iva, 0 as ret_ib,0 as ret_gan,round(fact.total,2)as total, 
            fact.observaciones as observa, fact.id
            FROM fact_facturas as fact, tipos_comprobantes as tip
            where fact.tipofact in (select donfdesc from tipos_comprobantes where leg=1) and
            tip.donfdesc=fact.tipofact and tip.ptovta=fact.ptovta and 
            fecha like '" & cmbperiodocarg.Text & "-%%'
            order by fact.ptovta,fact.num_fact", conexionPrinc)
            Dim tablaIVAVENTAS As New DataTable
            consulta.Fill(tablaIVAVENTAS)
            dtivaventas.DataSource = tablaIVAVENTAS
            For Each fila As DataGridViewRow In dtivaventas.Rows
                If InStr(fila.Cells(1).Value, "NC") = 1 Then
                    fila.Cells(6).Value = "-" & fila.Cells(6).Value
                    fila.Cells(7).Value = "-" & fila.Cells(7).Value
                    fila.Cells(8).Value = "-" & fila.Cells(8).Value
                    fila.Cells(9).Value = "-" & fila.Cells(9).Value
                    fila.Cells(13).Value = "-" & fila.Cells(13).Value
                    fila.DefaultCellStyle.BackColor = Color.Red
                End If
            Next
            SumarTotalesvtas()
        Catch ex As Exception
        End Try
    End Sub
    Private Function obtenerCodigoDoc(ByRef tipContr As String) As String
        If tipContr = "RESPONSABLE INSCRIPTO" Or tipContr = "MONOTRIBUTO" Or tipContr = "EXCENTO" Or tipContr = "EX" Or tipContr = "RI" Or tipContr = "MON" Then
            Return 80
        Else
            Return 96
        End If
    End Function

    Private Function ObternerCodigoComp(ByRef tipoComp) As String
        If tipoComp = "FA" Then Return "001"
        If tipoComp = "ND" Or tipoComp = "NDA" Or tipoComp = "NDB" Then Return "002"
        If tipoComp = "NC" Or tipoComp = "NCA" Or tipoComp = "NCB" Then Return "003"
        If tipoComp = "FB" Then Return "006"
        If tipoComp = "FC" Then Return "011"
    End Function

    Private Function ObtenerCodigoAlicuota(ByRef tipoAlic As String) As String
        If tipoAlic = "21" Then Return "0005"
        If tipoAlic = "10.5" Then Return "0004"
        If tipoAlic = "27" Then Return "0006"
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim fmt8 As String = String.Format("{0:00000000}")
        'Dim fmt20 As String = String.Format("{0:000000000000000000000}")
        Dim Comprobantes As String
        Dim Alicuotas As String
        Try
            If MsgBox("Esta seguro que desea exportar a LIBRO DIGITAL?", vbQuestion, vbYesNo) = vbYesNo Then
                Exit Sub
            End If
            For Each registro As DataGridViewRow In dtivaventas.Rows
                Dim fcomp As String = Format(CDate(registro.Cells(0).Value.ToString), "yyyyMMdd") 'fecha del comprobante
                Dim codigoComp As String = ObternerCodigoComp(registro.Cells(1).Value) 'Tipo de comprobante
                Dim ptovta As String = Strings.Mid(registro.Cells(2).Value.ToString, 1, InStr(registro.Cells(2).Value, "-") - 1).PadLeft(5, "0") 'punto de venta

                Dim numcbte As String = Strings.Right(registro.Cells(2).Value.ToString, 8).PadLeft(20, "0") 'numero de comprobante
                Dim numcbtehasta As String = numcbte  'numero de comprobante hasta
                Dim codigodoc As String = obtenerCodigoDoc(registro.Cells(5).Value.ToString)
                Dim numidentCUIT As String = Replace(registro.Cells(4).Value.ToString, "-", "").PadLeft(20, "0")
                Dim razonsocial As String = registro.Cells(3).Value.ToString
                If razonsocial.Length > 30 Then razonsocial = razonsocial.Substring(0, 30)
                If razonsocial.Length < 30 Then razonsocial = razonsocial.PadRight(30)

                Dim formatoImporte As String = Replace(FormatNumber(registro.Cells(13).Value, 2), ",", "")
                formatoImporte = Replace(formatoImporte, ".", "")
                formatoImporte = Replace(formatoImporte, "-", "")
                Dim imptotal As String = formatoImporte.PadLeft(15, "0") 'impote total de la operacion

                Dim nogr As String = "000000000000000"
                Dim pernocateg As String = "000000000000000"
                Dim operexen As String = "000000000000000"
                Dim pagocta As String = "000000000000000"
                Dim perIIBB As String = "000000000000000"
                Dim impmuni As String = "000000000000000"
                Dim impint As String = "000000000000000"
                Dim moneda As String = "PES"
                Dim cambio As String = "0001000000"
                Dim cantali As Integer = 0
                Dim neto105 As String
                Dim liq105 As String
                Dim neto21 As String
                Dim liq21 As String
                Dim codigoali As String
                If registro.Cells(7).Value <> 0 And registro.Cells(8).Value = 0 Then
                    cantali = 1
                    neto21 = FormatNumber(registro.Cells(7).Value / 0.21, 2)
                    neto21 = Replace(neto21, ",", "")
                    neto21 = Replace(neto21, ".", "")
                    neto21 = Replace(neto21, "-", "")
                    neto21 = neto21.PadLeft(15, "0")

                    liq21 = Replace(FormatNumber(registro.Cells(7).Value, 2), ",", "")
                    liq21 = Replace(liq21, ".", "")
                    liq21 = Replace(liq21, "-", "")
                    liq21 = liq21.PadLeft(15, "0")

                    codigoali = "0005"

                    Alicuotas &= codigoComp & ptovta & numcbte & neto21 & codigoali & liq21 & vbNewLine

                ElseIf registro.Cells(7).Value = 0 And registro.Cells(8).Value <> 0 Then
                    cantali = 1
                    neto105 = FormatNumber(registro.Cells(8).Value / 0.105, 2)
                    neto105 = Replace(neto105, ",", "")
                    neto105 = Replace(neto105, ".", "")
                    neto105 = Replace(neto105, "-", "")
                    neto105 = neto105.PadLeft(15, "0")

                    liq105 = Replace(FormatNumber(registro.Cells(8).Value, 2), ",", "")
                    liq105 = Replace(liq105, ".", "")
                    liq105 = Replace(liq105, "-", "")
                    liq105 = liq105.PadLeft(15, "0")

                    codigoali = "0004"

                    Alicuotas &= codigoComp & ptovta & numcbte & neto105 & codigoali & liq105 & vbNewLine


                ElseIf registro.Cells(7).Value <> 0 And registro.Cells(8).Value <> 0 Then
                    cantali = 2

                    neto105 = FormatNumber(registro.Cells(8).Value / 0.105, 2)
                    neto105 = Replace(neto105, ",", "")
                    neto105 = Replace(neto105, ".", "")
                    neto105 = Replace(neto105, "-", "")
                    neto105 = neto105.PadLeft(15, "0")

                    liq105 = Replace(registro.Cells(8).Value, ",", "")
                    liq105 = Replace(liq105, ".", "")
                    liq105 = Replace(liq105, "-", "")
                    liq105 = liq105.PadLeft(15, "0")


                    codigoali = "0004"

                    Alicuotas &= codigoComp & ptovta & numcbte & neto105 & codigoali & liq105 & vbNewLine

                    neto21 = FormatNumber(registro.Cells(7).Value / 0.21, 2)
                    neto21 = Replace(neto21, ",", "")
                    neto21 = Replace(neto21, ".", "")
                    neto21 = Replace(neto21, "-", "")
                    neto21 = neto21.PadLeft(15, "0")

                    liq21 = Replace(FormatNumber(registro.Cells(7).Value, 2), ",", "")
                    liq21 = Replace(liq21, ".", "")
                    liq21 = Replace(liq21, "-", "")
                    liq21 = liq21.PadLeft(15, "0")

                    codigoali = "0005"

                    Alicuotas &= codigoComp & ptovta & numcbte & neto21 & codigoali & liq21 & vbNewLine

                End If
                Dim codoper As String = "0"
                Dim otrotrib As String = "000000000000000"
                Dim vtopago As String = "00000000"

                Comprobantes &= fcomp & codigoComp & ptovta & numcbte & numcbtehasta & codigodoc & numidentCUIT & razonsocial & imptotal & nogr & pernocateg & operexen & pagocta _
                & perIIBB & impmuni & impint & moneda & cambio & cantali & codoper & otrotrib & vtopago & vbNewLine
            Next


            carpetadestino.ShowDialog()
            'Dim carpeta As New IO.DirectoryInfo(carpetadestino.SelectedPath)
            Dim nombrecomprobantes = carpetadestino.SelectedPath & "\" & cmbperiodocarg.Text & "_VENTAScomprobantes_" & ".txt"
            Dim nombrealicutas = carpetadestino.SelectedPath & "\" & cmbperiodocarg.Text & "_VENTASalicuotas_" & ".txt"
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If File.Exists(nombrecomprobantes) Then
                strStreamW = File.Open(nombrecomprobantes, FileMode.Open)
            Else
                strStreamW = File.Create(nombrecomprobantes)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)
            strStreamWriter.Write(Comprobantes)
            strStreamWriter.Close()


            If File.Exists(nombrealicutas) Then
                strStreamW = File.Open(nombrealicutas, FileMode.Open)
            Else
                strStreamW = File.Create(nombrealicutas)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)
            strStreamWriter.Write(Alicuotas)
            strStreamWriter.Close()
            MsgBox("archivos generados en la carpeta indicada")




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ivaVentas_Enter(sender As Object, e As EventArgs) Handles ivaVentas.Enter
        Reconectar()
        Dim TablaPeriodo As New MySql.Data.MySqlClient.MySqlDataAdapter("select distinct date_format(fecha,'%Y-%m') from fact_facturas order by fecha desc", conexionPrinc)

        Dim readPeriodo As New DataSet
        TablaPeriodo.Fill(readPeriodo)
        cmbperiodocarg.DataSource = readPeriodo.Tables(0)
        cmbperiodocarg.DisplayMember = readPeriodo.Tables(0).Columns(0).Caption.ToString.ToUpper
        'cmbvendedor.ValueMember = readPeriodo.Tables(0).Columns(0).Caption.ToString
    End Sub


    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Try
            If txtbdSincronizar.Text = "" Then
                MsgBox("debe ingresar una base de datos")
                Exit Sub
            End If
            conexionSEC.ChangeDatabase(txtbdSincronizar.Text)
            Reconectar()
            Dim TablaPeriodo As New MySql.Data.MySqlClient.MySqlDataAdapter("
            SELECT id, concat(mes,'-', ano) FROM iv_periodos
            order by id desc", conexionSEC)

            Dim readPeriodo As New DataSet
            TablaPeriodo.Fill(readPeriodo)
            cmbperiodosincronizar.DataSource = readPeriodo.Tables(0)
            cmbperiodosincronizar.DisplayMember = readPeriodo.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbperiodosincronizar.ValueMember = readPeriodo.Tables(0).Columns(0).Caption.ToString.ToUpper

            cmbperiodosincronizarCOMP.DataSource = readPeriodo.Tables(0)
            cmbperiodosincronizarCOMP.DisplayMember = readPeriodo.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbperiodosincronizarCOMP.ValueMember = readPeriodo.Tables(0).Columns(0).Caption.ToString.ToUpper

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        For Each facturaVenta As DataGridViewRow In dtivaventas.Rows
            Dim fecha As String = Format(CDate(facturaVenta.Cells("fecha").Value.ToString()), "yyyy-MM-dd")
            Dim tipocomp As String = ""
            Select Case facturaVenta.Cells("tipocom").Value.ToString()
                Case "NCA", "NCB", "NCC"
                    tipocomp = "NC"
                Case "NDA", "NDB", "NDC"
                    tipocomp = "ND"
                Case Else
                    tipocomp = facturaVenta.Cells("tipocom").Value
            End Select

            Dim numfac As String = facturaVenta.Cells("nufac").Value
            Dim razon As String = facturaVenta.Cells("razon").Value
            Dim cuit As String = facturaVenta.Cells("cuit").Value
            Dim conIVA As String = ""
            Select Case facturaVenta.Cells("tipocontr").Value.ToString()
                Case "RESPONSABLE INSCRIPTO"
                    conIVA = "RI"
                Case "EXCENTO", "EXENTO"
                    conIVA = "EX"
                Case "CONSUMIDOR FINAL"
                    conIVA = "CF"
                Case "MONOTRIBUTO"
                    conIVA = "MON"
            End Select
            Dim neto As String = facturaVenta.Cells("neto").Value
            Dim iva105 As String = facturaVenta.Cells("iva105").Value
            Dim iva21 As String = facturaVenta.Cells("iva21").Value
            Dim otroiva As String = facturaVenta.Cells("otroiva").Value
            Dim total As String = facturaVenta.Cells("total").Value
            Dim observa As String = ""
            Dim retIV As String = facturaVenta.Cells("ret_iva").Value
            Dim retIB As String = facturaVenta.Cells("ret_ib").Value
            Dim retGAN As String = facturaVenta.Cells("ret_gan").Value
            Dim PTOventa As String = FacturaElectro.puntovtaelect.ToString()
            Dim Provincia As Integer = 1
            Dim bienuso As Integer = 0
            Dim IDPeriodo As Integer = cmbperiodosincronizar.SelectedValue
            Dim sqlQuery As String

            'If tipocomp = "NC" Then
            '    If neto <> 0 Then neto = "-" & neto
            '    If iva105 <> 0 Then iva105 = "-" & iva105
            '    If iva21 <> 0 Then iva21 = "-" & iva21
            '    If otroiva <> 0 Then otroiva = "-" & otroiva
            '    If retIV <> 0 Then retIV = "-" & retIV
            '    If retIB <> 0 Then retIB = "-" & retIB
            '    If retGAN <> 0 Then retGAN = "-" & retGAN
            '    If total <> 0 Then total = "-" & total
            'End If

            Reconectar()
            sqlQuery = "insert into iv_items_ventas(periodo, fecha,tipocom,nufac,razon,cuit,tipocontr,neto,iva105, iva21,otroiva,total,obs,ret_iva,ret_ib,ret_gan,provincia,actividad,bien_uso) " _
                & "values(?per,?fech,?tcomp,?nfac,?raz,?cuit,?tcontr,?neto,?iva105,?iva21,?otroiva,?tot,?obs,?retiva,?retib,?retgan,?prov,?activ,?bien)"
            Dim additem As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionSEC)
            With additem.Parameters
                .AddWithValue("?per", IDperiodo)
                .AddWithValue("?fech", fecha)
                .AddWithValue("?tcomp", tipocomp)
                .AddWithValue("?nfac", numfac)
                .AddWithValue("?raz", razon)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?tcontr", conIVA)
                .AddWithValue("?neto", neto)
                .AddWithValue("?iva105", iva105)
                .AddWithValue("?iva21", iva21)
                .AddWithValue("?otroiva", otroiva)
                .AddWithValue("?tot", total)
                .AddWithValue("?obs", observa.ToUpper)
                .AddWithValue("?retiva", retIV)
                .AddWithValue("?retib", retIB)
                .AddWithValue("?retgan", retGAN)
                .AddWithValue("?prov", Provincia)
                .AddWithValue("?activ", 376)
                .AddWithValue("?bien", bienuso)
            End With
            additem.ExecuteNonQuery()
        Next
        MsgBox("Sincronizacion finalizada")
    End Sub

    Private Sub tablibromayor_Click(sender As Object, e As EventArgs) Handles tablibromayor.Click

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub dtlistacob_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtlistacob.CellContentClick

    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles btnBuscarPlanCta.Click
        Try
            CargarPlanDeCuentas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarPlanDeCuentas()
        Reconectar()
        Dim ConsultaPlanCuenta As New MySql.Data.MySqlClient.MySqlDataAdapter("
            SELECT * FROM cm_planDeCuentas order by grupo,subGrupo,cuenta,subCuenta,cuentaDetalle", conexionSEC)

        Dim TablaPlanCuenta As New DataTable
        ConsultaPlanCuenta.Fill(TablaPlanCuenta)
        dgvPlanCuentas.Rows.Clear()
        For Each cuenta As DataRow In TablaPlanCuenta.Rows
            dgvPlanCuentas.Rows.Add(
                cuenta.Item("id"),
                cuenta.Item("nombreCuenta"),
                cuenta.Item("grupo"),
                cuenta.Item("subGrupo"),
                cuenta.Item("cuenta"),
                cuenta.Item("subCuenta"),
                cuenta.Item("cuentaDetalle"),
                cuenta.Item("cuentaMovimiento"),
                cuenta.Item("cuentaResultado")
                   )
            dgvPlanCuentas.Rows(dgvPlanCuentas.Rows.Count - 1).DefaultCellStyle.BackColor = ColorearPorNumero(cuenta.Item("grupo"))
            'dgvPlanCuentas.Rows(dgvPlanCuentas.Rows.Count - 1).DefaultCellStyle.BackColor = ColorearPorNumero(cuenta.Item("subGrupo"))
            'dgvPlanCuentas.Rows(dgvPlanCuentas.Rows.Count - 1).DefaultCellStyle.BackColor = ColorearPorNumero(cuenta.Item("cuenta"))
            'dgvPlanCuentas.Rows(dgvPlanCuentas.Rows.Count - 1).DefaultCellStyle.BackColor = ColorearPorNumero(cuenta.Item("subCuenta"))

        Next


        'dgvPlanCuentas.DataSource = TablaPlanCuenta
        'dgvPlanCuentas.Columns(0).Visible = False
        'dgvPlanCuentas.Columns(7).Visible = False
        'dgvPlanCuentas.Columns(8).Visible = False

        grpMantenimientoCuenta.Enabled = False
    End Sub
    Private Function ColorearPorNumero(codigo As Integer) As Color
        'Select Case codigo
        '    Case 1
        '        Return Color.FromKnownColor(KnownColor.Red)
        '    Case 2
        '        Return Color.FromKnownColor(KnownColor.YellowGreen)
        '    Case 3
        '        Return Color.FromKnownColor(KnownColor.BlueViolet)
        '    Case 4
        '        Return Color.FromKnownColor(KnownColor.Aqua)
        '    Case 5
        '        Return Color.FromKnownColor(KnownColor.Coral)

        '    Case 6
        Return Color.FromKnownColor(codigo + 50)


        'End Select

    End Function

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        grpMantenimientoCuenta.Enabled = True
        txtCuentaGrupo.Enabled = True
        txtCuentaSubGrupo.Enabled = True
        txtCuentaCta.Enabled = True
        txtCuentaSubCuenta.Enabled = True
        txtCuentaCtaDetalle.Enabled = True
    End Sub


    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Try

            Dim CuentaNombre As String = txtCuentaNombre.Text
            Dim CuentaGrupo As Integer = CInt(txtCuentaGrupo.Text)
            Dim CuentaSubGrupo As Integer = CInt(txtCuentaSubGrupo.Text)
            Dim CuentaCta As Integer = CInt(txtCuentaCta.Text)
            Dim CuentaSubCuenta As Integer = CInt(txtCuentaSubCuenta.Text)
            Dim CuentaCtaDetalle As Integer = CInt(txtCuentaCtaDetalle.Text)
            Dim ctaMovimiento As Integer = 0
            Dim ctaResultado As Integer = 0
            idPLanCuenta = dgvPlanCuentas.CurrentRow.Cells(0).Value
            If chkCuentaMovimiento.Checked = True Then ctaMovimiento = 1
            If chkCuentaResultados.Checked = True Then ctaResultado = 1

            If ModificaPlanDeCuentas = False Then
                If existeCuenta(CuentaGrupo, CuentaSubGrupo, CuentaCta, CuentaSubCuenta, CuentaCtaDetalle) = True Then
                    MsgBox("ya existe una cuenta con el mismo codigo, por favor corrija")
                    Exit Sub
                End If
            End If
            Dim SqlQuery As String = ""
            Reconectar()
            If ModificaPlanDeCuentas = False Then
                SqlQuery = "insert into cm_planDeCuentas  " _
                & "(nombreCuenta,grupo,subGrupo,cuenta,subCuenta,cuentaDetalle,cuentaMovimiento,cuentaResultado) values " _
                & "(?nombreCuenta,?grupo,?subGrupo,?cuenta,?subCuenta,?cuentaDetalle,?cuentaMovimiento,?cuentaResultado)"
            ElseIf ModificaPlanDeCuentas = True Then
                '    MsgBox("modifica")
                SqlQuery = "update cm_planDeCuentas set nombreCuenta= ?nombreCuenta ,grupo=?grupo,
                subGrupo=?subGrupo, cuenta=?cuenta, subCuenta=?subCuenta, cuentaDetalle= ?cuentaDetalle, 
                cuentaMovimiento= ?cuentaMovimiento, cuentaResultado=?cuentaResultado where id=?idCuenta"
            End If

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?nombreCuenta", CuentaNombre)
                .AddWithValue("?grupo", CuentaGrupo)
                .AddWithValue("?subGrupo", CuentaSubGrupo)
                .AddWithValue("?cuenta", CuentaCta)
                .AddWithValue("?subCuenta", CuentaSubCuenta)
                .AddWithValue("?cuentaDetalle", CuentaCtaDetalle)
                .AddWithValue("?cuentaMovimiento", ctaMovimiento)
                .AddWithValue("?cuentaResultado", ctaResultado)
                If ModificaPlanDeCuentas = True Then
                    .AddWithValue("?idCuenta", idPLanCuenta)
                End If
            End With
            'MsgBox(comandoadd.CommandText)
            comandoadd.ExecuteNonQuery()
            btnBuscarPlanCta.PerformClick()

            Dim filaEncontrada = 0
            For Each fila As DataGridViewRow In dgvPlanCuentas.Rows

                If fila.Cells(0).Value = comandoadd.LastInsertedId And ModificaPlanDeCuentas = False Then
                    'MsgBox(fila.Cells(1).Value)
                    fila.Selected = True
                    filaEncontrada = fila.Index
                    Exit For
                ElseIf fila.Cells(0).value = idPLanCuenta And ModificaPlanDeCuentas = True Then

                    'If ModificaPlanDeCuentas = True Then
                    fila.Selected = True
                    filaEncontrada = fila.Index
                    'End If
                End If
            Next
            dgvPlanCuentas.Rows(filaEncontrada).Selected = True
            ' dgvPlanCuentas.CurrentCell = dgvPlanCuentas.Rows(filaEncontrada).Cells(0)
            dgvPlanCuentas.FirstDisplayedScrollingRowIndex = filaEncontrada
            ModificaPlanDeCuentas = False
        Catch ex As Exception

        End Try
    End Sub

    Private Function existeCuenta(G As Integer, sG As Integer, C As Integer, sC As Integer, cD As Integer) As Boolean
        Try
            Dim ConsultaPlanCuenta As New MySql.Data.MySqlClient.MySqlDataAdapter("
            SELECT * FROM cm_planDeCuentas 
            where grupo=" & G & " and  subGrupo=" & sG & " and cuenta=" & C & " and subCuenta= " & sC & " and cuentaDetalle=" & cD, conexionSEC)

            Dim TablaPlanCuenta As New DataTable
            ConsultaPlanCuenta.Fill(TablaPlanCuenta)

            If TablaPlanCuenta.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        If ConsultarPeriodoCerrado(cmbperiodoLibroDiario.Text) = True Then
            MsgBox("el periodo ya esta cerrado, no se pueden agregar asientos")
            Exit Sub
        End If
        addAsiento.Show()
    End Sub

    Private Sub tablibromayor_Enter(sender As Object, e As EventArgs) Handles tablibromayor.Enter
        If cmbperiodoLibroDiario.Items.Count = 0 And cmbCuentas.Items.Count = 0 Then
            IniciarLibroMayor()
        End If
    End Sub

    Private Sub IniciarLibroMayor()
        Reconectar()
        Dim consPlanCuentas As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id, concat(nombreCuenta,'<>',concat(grupo,subgrupo,cuenta,subcuenta,cuentadetalle)) as nombreCuenta
            FROM cm_planDeCuentas order by grupo,subGrupo,cuenta,subCuenta,cuentaDetalle", conexionPrinc)
        Dim dsPlanCuentas As New DataSet
        consPlanCuentas.Fill(dsPlanCuentas)

        cmbCuentas.DataSource = dsPlanCuentas.Tables(0)
        cmbCuentas.DisplayMember = dsPlanCuentas.Tables(0).Columns("nombreCuenta").Caption
        cmbCuentas.ValueMember = dsPlanCuentas.Tables(0).Columns("id").Caption

        CargarPeriodos()

    End Sub

    Public Sub CargarPeriodos()
        Try
            Reconectar()
            Dim TablaPeriodo As New MySql.Data.MySqlClient.MySqlDataAdapter("select distinct date_format(fecha,'%Y-%m') as periodo
            from cm_libroDiario
            having periodo > (select valor from fact_configuraciones where id=77)  
            order by fecha desc", conexionPrinc)

            Dim readPeriodo As New DataSet
            TablaPeriodo.Fill(readPeriodo)
            cmbperiodoLibroDiario.DataSource = readPeriodo.Tables(0)
            cmbperiodoLibroDiario.DisplayMember = readPeriodo.Tables(0).Columns(0).Caption.ToString.ToUpper

            cmbPeriodoLibroMayor.DataSource = readPeriodo.Tables(0)
            cmbPeriodoLibroMayor.DisplayMember = readPeriodo.Tables(0).Columns(0).Caption.ToString.ToUpper

            cmbBalCtasPeriodo.DataSource = readPeriodo.Tables(0)
            cmbBalCtasPeriodo.DisplayMember = readPeriodo.Tables(0).Columns(0).Caption.ToString.ToUpper

        Catch ex As Exception

        End Try
    End Sub
    Public Sub CargarLibroDiario()
        Try

            Reconectar()
            dgvLibroDiario.Rows.Clear()
            Dim consLibroDiario As New MySql.Data.MySqlClient.MySqlDataAdapter("select *  from cm_libroDiario  
            where fecha like '" & cmbperiodoLibroDiario.Text & "-%%' order by fecha desc, codigoAsiento desc", conexionPrinc)
            Dim tabLibroDiario As New DataTable
            consLibroDiario.Fill(tabLibroDiario)
            For Each asientoContable As DataRow In tabLibroDiario.Rows
                dgvLibroDiario.Rows.Add(
                                        asientoContable.Item("comprobanteInterno"),
                                        asientoContable.Item("codigoAsiento"),
                                        asientoContable.Item("fecha"),
                                        asientoContable.Item("concepto"),
                                        FormatCurrency(asientoContable.Item("totalDebe"), 2),
                                        FormatCurrency(asientoContable.Item("totalHaber"), 2),
                                        asientoContable.Item("numPartidas")
                                        )
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        CargarLibroDiario()
    End Sub


    Private Sub cmbCuentas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbCuentas.SelectionChangeCommitted

    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        Try
            addAsiento.ModificarAsiento = True
            addAsiento.IdAsiento = dgvLibroDiario.CurrentRow.Cells(1).Value
            addAsiento.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPlanCuentas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPlanCuentas.CellEnter
        Try
            txtCuentaNombre.Text = dgvPlanCuentas.CurrentRow.Cells("nombreCuenta").Value
            txtCuentaGrupo.Text = dgvPlanCuentas.CurrentRow.Cells("grupo").Value
            txtCuentaSubGrupo.Text = dgvPlanCuentas.CurrentRow.Cells("subGrupo").Value
            txtCuentaCta.Text = dgvPlanCuentas.CurrentRow.Cells("cuenta").Value
            txtCuentaSubCuenta.Text = dgvPlanCuentas.CurrentRow.Cells("subCuenta").Value
            txtCuentaCtaDetalle.Text = dgvPlanCuentas.CurrentRow.Cells("cuentaDetalle").Value

            'MsgBox(dgvPlanCuentas.CurrentRow.Cells("cuentaMovimiento").Value)

            'If dgvPlanCuentas.CurrentRow.Cells("cuentaMovimiento").Value = 1 Then
            chkCuentaMovimiento.Checked = dgvPlanCuentas.CurrentRow.Cells("cuentaMovimiento").Value
            'Else
            '    chkCuentaMovimiento.Checked = False
            'End If

            'If dgvPlanCuentas.CurrentRow.Cells("cuentaResultado").Value = 1 Then
            chkCuentaResultados.Checked = dgvPlanCuentas.CurrentRow.Cells("cuentaResultado").Value
            'Else
            '    chkCuentaResultados.Checked = False
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        Try
            ModificaPlanDeCuentas = True
            grpMantenimientoCuenta.Enabled = True
            txtCuentaGrupo.Enabled = False
            txtCuentaSubGrupo.Enabled = False
            txtCuentaCta.Enabled = False
            txtCuentaSubCuenta.Enabled = False
            txtCuentaCtaDetalle.Enabled = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub tabplancuentas_Enter(sender As Object, e As EventArgs) Handles tabplancuentas.Enter
        CargarPlanDeCuentas()
    End Sub

    Private Sub cmbCuentas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCuentas.SelectedValueChanged
        cargarLibroMayor

    End Sub
    Private Sub CargarLibroMayor()
        Try
            If rdCuentasIndividuales.Checked = True Then

                dgvLibroMayor.Rows.Clear()
                Reconectar()
                Dim idCuentaSel As Integer = cmbCuentas.SelectedValue
                Dim consSaldoCuenta As New MySql.Data.MySqlClient.MySqlDataAdapter("select saldo as saldoAnterior from cm_saldos_cuentas
                where periodo like date_format(date_sub('" & cmbPeriodoLibroMayor.Text & "-01',interval 1 month),'%Y-%m') and
                idCuenta=" & idCuentaSel, conexionPrinc)
                Dim tabSaldoCuenta As New DataTable
                consSaldoCuenta.Fill(tabSaldoCuenta)
                If tabSaldoCuenta.Rows.Count = 0 Then
                    saldoAnteriorCuenta = 0
                Else
                    If IsDBNull(tabSaldoCuenta.Rows(0).Item(0)) Then
                        saldoAnteriorCuenta = 0
                    Else
                        saldoAnteriorCuenta = FormatCurrency(tabSaldoCuenta.Rows(0).Item(0), 2)
                    End If
                End If

                lblSaldoCtaLibroMayor.Text = FormatCurrency(saldoAnteriorCuenta, 2)

                Reconectar()
                Dim consLibroMayor As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT LD.comprobanteInterno, date_format(LM.fecha,'%d-%m-%Y') as fecha,LM.concepto, asi.importeDebe, asi.importeHaber 
                From cm_libroMayor as LM, cm_Asientos as asi, cm_libroDiario as LD
                where LM.codigoAsiento=asi.codigoAsiento and
                LM.fecha like '" & cmbPeriodoLibroMayor.Text & "-%%' and
                LD.codigoAsiento=LM.codigoAsiento and
                (asi.cuentaDebeId= " & idCuentaSel & " or 
                asi.cuentaHaberId=" & idCuentaSel & ")
                order by LM.fecha asc,LD.id asc", conexionPrinc)
                Dim tabLibroMayor As New DataTable
                consLibroMayor.Fill(tabLibroMayor)
                Dim saldoDeudor As Double = 0
                Dim saldoAcreedor As Double = 0

                If saldoAnteriorCuenta > 0 Then
                    saldoDeudor = saldoAnteriorCuenta
                    saldoAcreedor = 0
                ElseIf saldoAnteriorCuenta < 0 Then
                    saldoDeudor = 0
                    saldoAcreedor = saldoAnteriorCuenta * -1
                Else
                    saldoDeudor = 0
                    saldoAcreedor = 0
                End If

                dgvLibroMayor.Rows.Add("", "", "....SALDO ANTERIOR....", "0", "0", FormatCurrency(saldoDeudor, 2), FormatCurrency(saldoAcreedor, 2))

                For Each movimientoCuenta As DataRow In tabLibroMayor.Rows
                    Dim debeActual As Double = movimientoCuenta.Item("importeDebe")
                    Dim haberActual As Double = movimientoCuenta.Item("importeHaber")
                    Dim saldoActual As Double = 0

                    If saldoAcreedor > 0 Then

                        saldoActual = saldoAcreedor - (debeActual - haberActual)
                        saldoDeudor = 0

                        If saldoActual > 0 Then

                            saldoAcreedor = saldoActual
                            saldoDeudor = 0
                        Else
                            saldoDeudor = saldoActual * -1
                            saldoAcreedor = 0
                        End If

                    ElseIf saldoDeudor > 0 Then

                        saldoActual = saldoDeudor + (debeActual - haberActual)
                        saldoAcreedor = 0

                        If saldoActual > 0 Then
                            saldoDeudor = saldoActual
                            saldoAcreedor = 0
                        Else
                            saldoAcreedor = saldoActual * -1
                            saldoDeudor = 0
                        End If
                    Else
                        saldoAcreedor = haberActual
                        saldoDeudor = debeActual

                    End If

                    dgvLibroMayor.Rows.Add(
                                        movimientoCuenta.Item("comprobanteInterno"),
                                        movimientoCuenta.Item("fecha"),
                                        movimientoCuenta.Item("concepto"),
                                        FormatCurrency(movimientoCuenta.Item("importeDebe"), 2),
                                        FormatCurrency(movimientoCuenta.Item("importeHaber"), 2),
                                        FormatCurrency(saldoDeudor, 2),
                                        FormatCurrency(saldoAcreedor, 2)
                                        )
                Next
            End If
            If rdTodasCuentas.Checked = True Then
                dgvLibroMayor.Rows.Clear()
                Reconectar()
                Dim consSaldosAnteriores As New MySql.Data.MySqlClient.MySqlDataAdapter("select CTA.id,CTA.cuentaResultado,CTA.grupo ,CTA.subGrupo,CTA.cuenta,CTA.subCuenta,CTA.cuentaDetalle, 
				concat(CTA.grupo,CTA.subgrupo,CTA.cuenta,'.',CTA.subcuenta,CTA.cuentadetalle,'<>',CTA.nombreCuenta) AS nombreCuenta, 
                '0' as comprobanteInterno, str_to_date('" & cmbPeriodoLibroMayor.Text & "-01','%Y-%m-%d') as fecha, 'saldoAnterior' as concepto,
                (select saldo from cm_saldos_cuentas 
                where idCuenta=CTA.id and periodo like date_format(date_sub('" & cmbPeriodoLibroMayor.Text & "-01',interval 1 month),'%Y-%m')        
                ) as saldoAnterior,
                CONVERT('0',DECIMAL) as importeDebe, CONVERT('0', DECIMAL) as importeHaber														
                from cm_planDeCuentas as CTA 
                where CTA.cuentaMovimiento=1
                order by  CTA.cuentaResultado desc,CTA.grupo asc,CTA.subGrupo asc,CTA.cuenta asc,CTA.subCuenta asc,CTA.cuentaDetalle asc", conexionPrinc)
                Dim tabSaldosAnteriores As New DataTable
                consSaldosAnteriores.Fill(tabSaldosAnteriores)

                Reconectar()
                Dim consLibroMayor As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT CTA.id,CTA.cuentaResultado,CTA.grupo ,CTA.subGrupo,CTA.cuenta,CTA.subCuenta,CTA.cuentaDetalle,
                concat(CTA.grupo,CTA.subgrupo,CTA.cuenta,'.',CTA.subcuenta,CTA.cuentadetalle,'<>',CTA.nombreCuenta) AS nombreCuenta,  
                LD.comprobanteInterno, LM.fecha,LM.concepto, 
                convert('0',decimal) as saldoAnterior,
			    asi.importeDebe, asi.importeHaber 
                From cm_libroMayor as LM, cm_Asientos as asi, cm_libroDiario as LD, cm_planDeCuentas as CTA
                where LM.codigoAsiento=asi.codigoAsiento and
                LM.fecha like '" & cmbPeriodoLibroMayor.Text & "-%%'  and
                LD.codigoAsiento=LM.codigoAsiento and 
                (asi.cuentaDebeId=CTA.id or asi.cuentaHaberId=CTA.id)
                order by  CTA.cuentaResultado desc,CTA.grupo asc,CTA.subGrupo asc,CTA.cuenta asc,CTA.subCuenta asc,CTA.cuentaDetalle asc, LD.fecha, LD.comprobanteInterno asc", conexionPrinc)
                Dim tabLibroMayor As New DataTable
                consLibroMayor.Fill(tabLibroMayor)

                Dim saldoAnterior As Double = 0
                Dim saldoDeudor As Double = 0
                Dim saldoAcreedor As Double = 0
                Dim datosContables As New datosContable

                For Each CtaSaldos As DataRow In tabSaldosAnteriores.Rows
                    'MsgBox(CtaSaldos.Item("saldoAnterior").ToString)
                    Dim idCuenta = CtaSaldos.Item("id")
                    Dim encontrado = 0

                    If Not IsDBNull(CtaSaldos.Item("saldoAnterior")) Then
                        ' Dim fec As New MySql.Data.Types.MySqlDateTime
                        tabLibroMayor.Rows.Add(
                        CtaSaldos.Item("id"),
                        CtaSaldos.Item("cuentaResultado"),
                        CtaSaldos.Item("grupo"),
                        CtaSaldos.Item("subGrupo"),
                        CtaSaldos.Item("cuenta"),
                        CtaSaldos.Item("subCuenta"),
                        CtaSaldos.Item("cuentaDetalle"),
                        CtaSaldos.Item("nombreCuenta"),
                        0,
                        CtaSaldos.Item("fecha"),
                        "....SALDO ANTERIOR....",
                       CtaSaldos.Item("saldoAnterior"), 0)
                    End If
                Next
                Dim i As Integer
                Dim FilasLibro() As DataRow
                'Dim exp As String = ""
                'Dim orden As String = "cuentaResultado desc,grupo asc,subGrupo asc,cuenta asc,subCuenta asc,cuentaDetalle asc"
                FilasLibro = tabLibroMayor.Select("", "cuentaResultado desc,grupo asc,subGrupo asc,cuenta asc,subCuenta asc,cuentaDetalle asc,fecha asc,comprobanteInterno asc")
                'Dim miview As DataView = New DataView(tabLibroMayor)
                'miview.Sort = "cuentaResultado desc,grupo asc,subGrupo asc,cuenta asc,subCuenta asc,cuentaDetalle asc,fecha asc,comprobanteInterno asc"
                'DgvPaginado1.Cargar_Datos(miview.ToTable)
                'MsgBox(movCuenta.Length)
                'For i = movCuenta.GetLowerBound(0) To i = movCuenta.GetUpperBound(0)
                For Each movCuenta As DataRow In FilasLibro
                    'For Each movCuenta As DataRow In tabLibroMayor.Rows
                    Dim importeDebe As Double = 0
                    Dim importeHaber As Double = 0

                    If IsDBNull(movCuenta.Item("saldoAnterior")) Then
                        saldoAnterior = 0
                    Else
                        saldoAnterior = movCuenta.Item("saldoAnterior")
                    End If

                    'MsgBox(saldoAnterior & "-----" & movCuenta.Item("saldoAnterior"))
                    If IsDBNull(movCuenta.Item("importeDebe")) Then
                        importeDebe = 0
                    Else
                        importeDebe = movCuenta.Item("importeDebe")
                    End If

                    If IsDBNull(movCuenta.Item("importeHaber")) Then
                        importeHaber = 0

                    Else
                        importeHaber = movCuenta.Item("importeHaber")
                    End If
                    '   MsgBox(saldoAnteriorCuenta)
                    dgvLibroMayor.Rows.Add(
                        movCuenta.Item("id"),
                        movCuenta.Item("nombreCuenta"),
                        movCuenta.Item("comprobanteInterno"),
                        movCuenta.Item("fecha"),
                        movCuenta.Item("concepto"),
                        FormatCurrency(saldoAnterior, 2),
                        FormatCurrency(importeDebe, 2),
                        FormatCurrency(importeHaber, 2), 0, 0)
                Next
                Dim idCuentaGral As Integer = 0

                For Each movimientoCuenta As DataGridViewRow In dgvLibroMayor.Rows
                    Dim idCuentaActual As Integer = movimientoCuenta.Cells("idCuenta").Value
                    Dim debeActual As Double = CDbl(movimientoCuenta.Cells("debe").Value)
                    Dim haberActual As Double = CDbl(movimientoCuenta.Cells("haber").Value)
                    Dim saldoActual As Double = 0
                    Dim saldoAnteriorCta As Double = 0

                    If idCuentaGral <> idCuentaActual Then
                        idCuentaGral = idCuentaActual
                        saldoAnteriorCta = CDbl(movimientoCuenta.Cells("saldoAnterior").Value)
                        If saldoAnteriorCta > 0 Then
                            saldoDeudor = saldoAnteriorCta
                            saldoAcreedor = 0
                        ElseIf saldoAnteriorCta < 0 Then
                            saldoDeudor = 0
                            saldoAcreedor = saldoAnteriorCta * -1
                        Else
                            saldoDeudor = 0
                            saldoAcreedor = 0
                        End If
                    Else
                        movimientoCuenta.Cells("saldoAnterior").Value = 0
                    End If

                    If saldoAcreedor > 0 Then
                        saldoActual = saldoAcreedor - (debeActual - haberActual)
                        saldoDeudor = 0

                        If saldoActual > 0 Then

                            saldoAcreedor = saldoActual
                            saldoDeudor = 0
                        Else
                            saldoDeudor = saldoActual * -1
                            saldoAcreedor = 0
                        End If

                    ElseIf saldoDeudor > 0 Then

                        saldoActual = saldoDeudor + (debeActual - haberActual)
                        saldoAcreedor = 0

                        If saldoActual > 0 Then
                            saldoDeudor = saldoActual
                            saldoAcreedor = 0
                        Else
                            saldoAcreedor = saldoActual * -1
                            saldoDeudor = 0
                        End If
                    Else
                        saldoAcreedor = haberActual
                        saldoDeudor = debeActual

                    End If
                    movimientoCuenta.Cells("saldoDeudor").Value = FormatCurrency(saldoDeudor, 2)
                    movimientoCuenta.Cells("saldoAcreedor").Value = FormatCurrency(saldoAcreedor, 2)
                Next
            End If


            If rdCuentasIndividuales.Checked = False And rdTodasCuentas.Checked = False Then
                rdCuentasIndividuales.Checked = True

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
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

            Dim datosContables As New datosContable
            Dim desde As String = Format(CDate(dtpdecob.Value), "yyyy-MM-dd")
            Dim hasta As String = Format(CDate(dtphastacob.Value), "yyyy-MM-dd")

            Dim tabContable As New MySql.Data.MySqlClient.MySqlDataAdapter
            Reconectar()

            tabContable.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select LD.fecha,stos.codigoAsiento,LD.comprobanteInterno, LD.concepto, 
            concat(PC.grupo,PC.subgrupo,PC.cuenta,'.',PC.subcuenta,PC.cuentadetalle) as numCta,
            PC.nombreCuenta,
            stos.importeDebe,stos.importeHaber   
            From cm_libroDiario as LD, cm_Asientos as stos, cm_planDeCuentas as PC 
            where
            LD.codigoAsiento=stos.codigoAsiento and
            (PC.id=stos.cuentaDebeId or PC.id=stos.cuentaHaberId) and
            LD.fecha like '" & cmbperiodoLibroDiario.Text & "-%%' order by LD.fecha asc, stos.id ASC
            ", conexionPrinc)

            tabContable.Fill(datosContables.Tables("libroDiario"))
            'Reconectar()

            'tabContable.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select * from cobranzas where fecha between '" & desde & "' and '" & hasta & "'", conexionPrinc)
            'tabContable.Fill(datosContables.Tables("listadorecibos"))
            'End If
            Dim imprimirx As New imprimirFX
            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodo", cmbperiodoLibroDiario.Text))
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\libroDiario.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("libroDiario", datosContables.Tables("libroDiario")))
                '.rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadorecibos")))
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

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
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
        Try
            CargarLibroMayor()
            EnProgreso.Close()
        Catch ex As Exception
            EnProgreso.Close()
        End Try
    End Sub


    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click

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
        dgvListadoCuentaConSaldos.Rows.Clear()
        Try
            Reconectar()
            If rdCtaSaldo.Checked = True Then
                Dim consSaldoCuenta As New MySql.Data.MySqlClient.MySqlDataAdapter("select CTA.id, concat(CTA.grupo,CTA.subGrupo,CTA.cuenta,'.',CTA.subcuenta,CTA.cuentaDetalle) as numCuenta, CTA.nombreCuenta,
				(select saldo from cm_saldos_cuentas 
                where idCuenta=CTA.id and periodo like date_format(date_sub('" & cmbBalCtasPeriodo.Text & "-01',interval 1 month),'%Y-%m')
                and periodo >(select valor from fact_configuraciones where id=77)
                ) as saldoAnterior, 
                
                (select sum(stos.importeDebe)from cm_libroDiario as LD, cm_Asientos as stos 							
                where stos.codigoAsiento=LD.codigoAsiento and
                (stos.cuentaDebeId=CTA.id or stos.cuentaHaberId=CTA.id) and
                LD.fecha like '" & cmbBalCtasPeriodo.Text & "-%%'                
                ) as debitosMes,
                
                (select sum(stos.importeHaber)from cm_libroDiario as LD, cm_Asientos as stos 							
                where stos.codigoAsiento=LD.codigoAsiento and
                (stos.cuentaDebeId=CTA.id or stos.cuentaHaberId=CTA.id) and
                LD.fecha like '" & cmbBalCtasPeriodo.Text & "-%%'                
                ) as creditosMes
                                
                from cm_planDeCuentas as CTA 
                where CTA.cuentaMovimiento=1
                order by  CTA.cuentaResultado desc,CTA.grupo asc,CTA.subGrupo asc,CTA.cuenta asc,CTA.subCuenta asc,CTA.cuentaDetalle asc", conexionPrinc)
                consSaldoCuenta.SelectCommand.CommandTimeout = 300

                'MsgBox(consSaldoCuenta.SelectCommand.CommandText)
                Dim tabSaldoCuenta As New DataTable

                consSaldoCuenta.Fill(tabSaldoCuenta)

                'Dim col As New DataColumn


                For Each saldocuenta As DataRow In tabSaldoCuenta.Rows
                    Dim saldAnterior As Double = 0
                    Dim debMes As Double = 0
                    Dim credMes As Double = 0
                    Dim saldMes As Double = 0
                    Dim saldFinal As Double = 0

                    If IsDBNull(saldocuenta.Item("saldoAnterior")) Then saldAnterior = 0 Else saldAnterior = saldocuenta.Item("saldoAnterior")
                    If IsDBNull(saldocuenta.Item("debitosMes")) Then debMes = 0 Else debMes = saldocuenta.Item("debitosMes")
                    If IsDBNull(saldocuenta.Item("creditosMes")) Then credMes = 0 Else credMes = saldocuenta.Item("creditosMes")

                    saldMes = debMes - credMes
                    saldFinal = saldMes + saldAnterior
                    If saldAnterior = 0 And debMes = 0 And credMes = 0 And saldFinal = 0 Then
                        Continue For
                    End If
                    dgvListadoCuentaConSaldos.Rows.Add(
                                    saldocuenta.Item("id"),
                                    saldocuenta.Item("numCuenta"),
                                    saldocuenta.Item("nombreCuenta"),
                                    FormatCurrency(saldAnterior, 2),
                                    FormatCurrency(debMes, 2),
                                    FormatCurrency(credMes, 2),
                                    FormatCurrency(saldMes, 2),
                                    FormatCurrency(saldFinal, 2)
                                    )
                Next

                CalcularTotalListado()
            End If
            If rdBalance.Checked = True Then

                Dim consbalance As New MySql.Data.MySqlClient.MySqlDataAdapter("
                select CTA.id,concat(CTA.grupo,CTA.subGrupo,CTA.cuenta,'.',CTA.subcuenta,CTA.cuentaDetalle) as numCuenta,CTA.grupo,CTA.subGrupo,CTA.cuenta,CTA.subCuenta,CTA.cuentaDetalle, CTA.nombreCuenta, 
				ifnull((select sum(stos.importeDebe)from cm_libroDiario as LD, cm_Asientos as stos 							
                where stos.codigoAsiento=LD.codigoAsiento and
                (stos.cuentaDebeId=CTA.id or stos.cuentaHaberId=CTA.id) and
                CTA.cuentaMovimiento=1 and
                LD.fecha like '" & cmbBalCtasPeriodo.Text & "-%%'
                ),0) -
                
                ifnull((select sum(stos.importeHaber)from cm_libroDiario as LD, cm_Asientos as stos 							
                where stos.codigoAsiento=LD.codigoAsiento and
                (stos.cuentaDebeId=CTA.id or stos.cuentaHaberId=CTA.id) and
                CTA.cuentaMovimiento=1 and
                LD.fecha like '" & cmbBalCtasPeriodo.Text & "-%%'
                ),0) as MES,
                
                ifnull((select saldo from cm_saldos_cuentas 
                where idCuenta=CTA.id and periodo like date_format(date_sub('" & cmbBalCtasPeriodo.Text & "-01',interval 1 month),'%Y-%m')
                and periodo >(select valor from fact_configuraciones where id=77)
                ),0) as saldoAnterior,
                 CTA.cuentaMovimiento,CTA.cuentaResultado                											
                from cm_planDeCuentas as CTA 	
                order by CTA.grupo asc,CTA.subGrupo asc,CTA.cuenta asc,CTA.subCuenta asc,CTA.cuentaDetalle asc", conexionPrinc)
                Dim tabBalance As New DataTable
                Dim infoBalance() As DataRow
                'MsgBox(consbalance.SelectCommand.CommandText)
                consbalance.SelectCommand.CommandTimeout = 300
                consbalance.Fill(tabBalance)
                Dim tablaBalanceSumas As New DataTable

                Dim datosContables As New datosContable

                For Each cuentaBalance As DataRow In tabBalance.Rows
                    Dim movMes As Double = 0
                    Dim saldoAnterior As Double = 0
                    Dim saldoFinal As Double = 0
                    Dim Ejercicio As Double = 0


                    movMes = cuentaBalance.Item("MES")
                    saldoAnterior = cuentaBalance.Item("saldoAnterior")

                    saldoFinal = movMes + saldoAnterior
                    If cuentaBalance.Item("cuentaMovimiento") = True And cuentaBalance.Item("MES") = 0 And cuentaBalance.Item("saldoAnterior") = 0 Then
                        Continue For
                    End If

                    dgvListadoCuentaConSaldos.Rows.Add(
                        cuentaBalance.Item("id"),
                        cuentaBalance.Item("numCuenta"),
                        cuentaBalance.Item("grupo"),
                        cuentaBalance.Item("subGrupo"),
                        cuentaBalance.Item("cuenta"),
                        cuentaBalance.Item("subCuenta"),
                        cuentaBalance.Item("cuentaDetalle"),
                        cuentaBalance.Item("cuentaResultado"),
                        cuentaBalance.Item("cuentaMovimiento"),
                        cuentaBalance.Item("nombreCuenta"),
                        FormatCurrency(movMes, 2),
                        FormatCurrency(saldoFinal, 2),
                        0)


                    datosContables.Tables("balanceCuentas").Rows.Add(
                        cuentaBalance.Item("grupo"),
                        cuentaBalance.Item("subGrupo"),
                        cuentaBalance.Item("cuenta"),
                        cuentaBalance.Item("subCuenta"),
                        cuentaBalance.Item("cuentaDetalle"),
                        cuentaBalance.Item("nombreCuenta"),
                        movMes,
                        saldoFinal, 0)

                Next

                For Each fila As DataGridViewRow In dgvListadoCuentaConSaldos.Rows
                    Dim ejercicio As Double = 0
                    Dim mtoMes As Double = 0

                    If fila.Cells("cuentaDetalle").Value = 0 And fila.Cells("subCuenta").Value = 0 And fila.Cells("Cuenta").Value = 0 And fila.Cells("subGrupo").Value = 0 Then
                        infoBalance = datosContables.Tables("balanceCuentas").Select(
                            "grupo=" & fila.Cells("grupo").Value)

                        For Each monto As DataRow In infoBalance
                            ejercicio += monto("saldoFinal")
                            mtoMes += monto("MES")
                        Next
                        fila.DefaultCellStyle.BackColor = Color.Coral
                    End If

                    If fila.Cells("cuentaDetalle").Value = 0 And fila.Cells("subCuenta").Value = 0 And fila.Cells("Cuenta").Value = 0 And fila.Cells("subGrupo").Value <> 0 Then
                        infoBalance = datosContables.Tables("balanceCuentas").Select(
                            "grupo=" & fila.Cells("grupo").Value &
                            " and subGrupo=" & fila.Cells("subGrupo").Value)

                        For Each monto As DataRow In infoBalance
                            ejercicio += monto("saldoFinal")
                            mtoMes += monto("MES")
                        Next
                        fila.DefaultCellStyle.BackColor = Color.ForestGreen
                    End If

                    If fila.Cells("cuentaDetalle").Value = 0 And fila.Cells("subCuenta").Value = 0 And fila.Cells("Cuenta").Value <> 0 And fila.Cells("subGrupo").Value <> 0 Then
                        infoBalance = datosContables.Tables("balanceCuentas").Select(
                            "grupo=" & fila.Cells("grupo").Value &
                            " and subGrupo=" & fila.Cells("subGrupo").Value &
                            " and cuenta=" & fila.Cells("Cuenta").Value)

                        For Each monto As DataRow In infoBalance
                            ejercicio += monto("saldoFinal")
                            mtoMes += monto("MES")
                        Next
                        fila.DefaultCellStyle.BackColor = Color.Aqua
                    End If

                    If fila.Cells("cuentaDetalle").Value = 0 And fila.Cells("subCuenta").Value <> 0 And fila.Cells("Cuenta").Value <> 0 And fila.Cells("subGrupo").Value <> 0 Then
                        infoBalance = datosContables.Tables("balanceCuentas").Select(
                            "grupo=" & fila.Cells("grupo").Value &
                            " and subGrupo=" & fila.Cells("subGrupo").Value &
                            " and cuenta=" & fila.Cells("Cuenta").Value &
                            "and subCuenta= " & fila.Cells("subCuenta").Value)

                        For Each monto As DataRow In infoBalance
                            ejercicio += monto("saldoFinal")
                            mtoMes += monto("MES")
                        Next
                        fila.DefaultCellStyle.BackColor = Color.GreenYellow
                    End If

                    txtlog.Text &= fila.Cells("cuentaDetalle").Value & "//" &
                    fila.Cells("subCuenta").Value & "//" &
                    fila.Cells("cuenta").Value & "//" &
                    fila.Cells("subGrupo").Value & "//" &
                    fila.Cells("cuentaResultado").Value & "//" &
                    fila.Cells("cuentaMovimiento").Value & "//" & vbNewLine

                    If fila.Cells("cuentaDetalle").Value = 0 And
                        fila.Cells("subCuenta").Value <> 0 And
                        fila.Cells("cuenta").Value <> 0 And
                        fila.Cells("subGrupo").Value <> 0 And
                        fila.Cells("cuentaResultado").Value = True And
                        fila.Cells("cuentaMovimiento").Value = False Then
                        '    MsgBox("cuenta resultado1")

                        fila.Cells("MES").Value = FormatCurrency(mtoMes, 2)
                        fila.Cells("Ejercicio").Value = FormatCurrency(ejercicio, 2)

                    ElseIf fila.Cells("cuentaDetalle").Value = 0 And
                        fila.Cells("subCuenta").Value = 0 And
                        fila.Cells("cuenta").Value <> 0 And
                        fila.Cells("subGrupo").Value <> 0 And
                        fila.Cells("cuentaResultado").Value = True And
                        fila.Cells("cuentaMovimiento").Value = False Then
                        'MsgBox("cuenta resultado2")

                        fila.Cells("MES").Value = FormatCurrency(mtoMes, 2)
                        fila.Cells("Ejercicio").Value = FormatCurrency(ejercicio, 2)

                    ElseIf fila.Cells("cuentaDetalle").Value = 0 And
                        fila.Cells("subCuenta").Value = 0 And
                        fila.Cells("cuenta").Value = 0 And
                        fila.Cells("subGrupo").Value <> 0 And
                        fila.Cells("cuentaResultado").Value = True And
                        fila.Cells("cuentaMovimiento").Value = False Then
                        'MsgBox("cuenta resultado3")

                        fila.Cells("MES").Value = FormatCurrency(mtoMes, 2)
                        fila.Cells("Ejercicio").Value = FormatCurrency(ejercicio, 2)

                    ElseIf fila.Cells("cuentaDetalle").Value = 0 And
                        fila.Cells("subCuenta").Value = 0 And
                        fila.Cells("cuenta").Value = 0 And
                        fila.Cells("subGrupo").Value = 0 And
                        fila.Cells("cuentaResultado").Value = True And
                        fila.Cells("cuentaMovimiento").Value = False Then
                        'MsgBox("cuenta resultado4")

                        fila.Cells("MES").Value = FormatCurrency(mtoMes, 2)
                        fila.Cells("Ejercicio").Value = FormatCurrency(ejercicio, 2)


                    ElseIf fila.Cells("cuentaDetalle").Value = 0 And
                        fila.Cells("subCuenta").Value <> 0 And
                        fila.Cells("cuenta").Value <> 0 And
                        fila.Cells("subGrupo").Value <> 0 And
                        fila.Cells("cuentaResultado").Value = 0 And
                        fila.Cells("cuentaMovimiento").Value = 0 Then


                        fila.Cells("MES").Value = FormatCurrency(mtoMes, 2)

                    ElseIf fila.Cells("cuentaDetalle").Value = 0 And
                        fila.Cells("subCuenta").Value = 0 And
                        fila.Cells("cuenta").Value <> 0 And
                        fila.Cells("subGrupo").Value <> 0 And
                        fila.Cells("cuentaResultado").Value = 0 And
                        fila.Cells("cuentaMovimiento").Value = 0 Then

                        fila.Cells("Ejercicio").Value = FormatCurrency(ejercicio, 2)

                    ElseIf fila.Cells("cuentaDetalle").Value = 0 And
                        fila.Cells("subCuenta").Value = 0 And
                        fila.Cells("cuenta").Value = 0 And
                        fila.Cells("subGrupo").Value <> 0 And
                        fila.Cells("cuentaResultado").Value = 0 And
                        fila.Cells("cuentaMovimiento").Value = 0 Then


                        fila.Cells("Ejercicio").Value = FormatCurrency(ejercicio, 2)

                    ElseIf fila.Cells("cuentaDetalle").Value = 0 And
                        fila.Cells("subCuenta").Value = 0 And
                        fila.Cells("cuenta").Value = 0 And
                        fila.Cells("subGrupo").Value = 0 And
                        fila.Cells("cuentaResultado").Value = 0 And
                        fila.Cells("cuentaMovimiento").Value = 0 Then

                        fila.Cells("Ejercicio").Value = FormatCurrency(ejercicio, 2)

                    End If
                Next
            End If
            EnProgreso.Close()
        Catch ex As Exception
            EnProgreso.Close()
        End Try
    End Sub
    Private Sub CrearColumnasGrid(tipo As Integer)
        Try


            If tipo = 1 Then
                dgvListadoCuentaConSaldos.Columns.Clear()

                Dim columna1 As New DataGridViewTextBoxColumn
                columna1.Name = "idCuenta"
                columna1.HeaderText = "idCuenta"
                columna1.Visible = False

                dgvListadoCuentaConSaldos.Columns.Add(columna1)

                Dim columna2 As New DataGridViewTextBoxColumn
                columna2.Name = "numCuenta"
                columna2.HeaderText = "numCuenta"
                columna2.FillWeight = 40
                dgvListadoCuentaConSaldos.Columns.Add(columna2)

                Dim columna3 As New DataGridViewTextBoxColumn
                columna3.Name = "nombreCuenta"
                columna3.HeaderText = "nombreCuenta"
                dgvListadoCuentaConSaldos.Columns.Add(columna3)

                Dim columna4 As New DataGridViewTextBoxColumn
                columna4.Name = "saldoAnterior"
                columna4.HeaderText = "saldoAnterior"
                columna4.FillWeight = 50
                dgvListadoCuentaConSaldos.Columns.Add(columna4)

                Dim columna5 As New DataGridViewTextBoxColumn
                columna5.Name = "debitosMes"
                columna5.HeaderText = "debitosMes"
                columna5.FillWeight = 50
                dgvListadoCuentaConSaldos.Columns.Add(columna5)

                Dim columna6 As New DataGridViewTextBoxColumn
                columna6.Name = "creditosMes"
                columna6.HeaderText = "creditosMes"
                columna6.FillWeight = 50
                dgvListadoCuentaConSaldos.Columns.Add(columna6)

                Dim columna7 As New DataGridViewTextBoxColumn
                columna7.Name = "saldoMes"
                columna7.HeaderText = "saldoMes"
                columna7.FillWeight = 50
                dgvListadoCuentaConSaldos.Columns.Add(columna7)

                Dim columna8 As New DataGridViewTextBoxColumn
                columna8.Name = "saldoFinal"
                columna8.HeaderText = "saldoFinal"
                columna8.FillWeight = 50
                dgvListadoCuentaConSaldos.Columns.Add(columna8)




            ElseIf tipo = 2 Then
                dgvListadoCuentaConSaldos.Columns.Clear()
                Dim columna1 As New DataGridViewTextBoxColumn
                columna1.Name = "idCuenta"
                columna1.HeaderText = "idCuenta"
                columna1.Visible = False
                dgvListadoCuentaConSaldos.Columns.Add(columna1)

                Dim columna2 As New DataGridViewTextBoxColumn
                columna2.Name = "numCuenta"
                columna2.HeaderText = "numCuenta"
                columna2.FillWeight = 20
                dgvListadoCuentaConSaldos.Columns.Add(columna2)

                Dim columna9 As New DataGridViewTextBoxColumn
                columna9.Name = "grupo"
                columna9.HeaderText = "grupo"
                columna9.Visible = False
                dgvListadoCuentaConSaldos.Columns.Add(columna9)

                Dim columna10 As New DataGridViewTextBoxColumn
                columna10.Name = "subGrupo"
                columna10.HeaderText = "subGrupo"
                columna10.Visible = False
                dgvListadoCuentaConSaldos.Columns.Add(columna10)

                Dim columna11 As New DataGridViewTextBoxColumn
                columna11.Name = "cuenta"
                columna11.HeaderText = "cuenta"
                columna11.Visible = False
                dgvListadoCuentaConSaldos.Columns.Add(columna11)

                Dim columna12 As New DataGridViewTextBoxColumn
                columna12.Name = "subCuenta"
                columna12.HeaderText = "subCuenta"
                columna12.Visible = False
                dgvListadoCuentaConSaldos.Columns.Add(columna12)

                Dim columna13 As New DataGridViewTextBoxColumn
                columna13.Name = "cuentaDetalle"
                columna13.HeaderText = "cuentaDetalle"
                columna13.Visible = False
                dgvListadoCuentaConSaldos.Columns.Add(columna13)

                Dim columna14 As New DataGridViewTextBoxColumn
                columna14.Name = "cuentaResultado"
                columna14.HeaderText = "cuentaResultado"
                columna14.Visible = False
                dgvListadoCuentaConSaldos.Columns.Add(columna14)

                Dim columna15 As New DataGridViewTextBoxColumn
                columna15.Name = "cuentaMovimiento"
                columna15.HeaderText = "cuentaMovimiento"
                columna15.Visible = False
                dgvListadoCuentaConSaldos.Columns.Add(columna15)

                Dim columna3 As New DataGridViewTextBoxColumn
                columna3.Name = "nombreCuenta"
                columna3.HeaderText = "nombreCuenta"
                dgvListadoCuentaConSaldos.Columns.Add(columna3)

                Dim columna5 As New DataGridViewTextBoxColumn
                columna5.Name = "MES"
                columna5.HeaderText = "MES"
                columna5.FillWeight = 50
                dgvListadoCuentaConSaldos.Columns.Add(columna5)

                Dim columna4 As New DataGridViewTextBoxColumn
                columna4.Name = "saldoFinal"
                columna4.HeaderText = "saldoFinal"
                columna4.FillWeight = 50
                dgvListadoCuentaConSaldos.Columns.Add(columna4)

                Dim columna6 As New DataGridViewTextBoxColumn
                columna6.Name = "EJERCICIO"
                columna6.HeaderText = "EJERCICIO"
                columna6.FillWeight = 50
                dgvListadoCuentaConSaldos.Columns.Add(columna6)

            ElseIf tipo = 3 Then
                dgvLibroMayor.Columns.Clear()
                Dim columna1 As New DataGridViewTextBoxColumn
                columna1.Name = "comprobante"
                columna1.HeaderText = "Comprobante"
                columna1.FillWeight = 30
                dgvLibroMayor.Columns.Add(columna1)

                Dim columna2 As New DataGridViewTextBoxColumn
                columna2.Name = "fecha"
                columna2.HeaderText = "Fecha"
                columna2.FillWeight = 30
                dgvLibroMayor.Columns.Add(columna2)

                Dim columna3 As New DataGridViewTextBoxColumn
                columna3.Name = "concepto"
                columna3.HeaderText = "Concepto"
                'columna3.FillWeight = 3
                dgvLibroMayor.Columns.Add(columna3)

                Dim columna4 As New DataGridViewTextBoxColumn
                columna4.Name = "debe"
                columna4.HeaderText = "Debe"
                columna4.FillWeight = 40
                dgvLibroMayor.Columns.Add(columna4)

                Dim columna5 As New DataGridViewTextBoxColumn
                columna5.Name = "haber"
                columna5.HeaderText = "Haber"
                columna5.FillWeight = 40
                dgvLibroMayor.Columns.Add(columna5)

                Dim columna6 As New DataGridViewTextBoxColumn
                columna6.Name = "saldoDeudor"
                columna6.HeaderText = "Saldo deudor"
                columna6.FillWeight = 50
                dgvLibroMayor.Columns.Add(columna6)

                Dim columna7 As New DataGridViewTextBoxColumn
                columna7.Name = "saldoAcreedor"
                columna7.HeaderText = "Saldo acreedor"
                columna7.FillWeight = 50
                dgvLibroMayor.Columns.Add(columna7)

            ElseIf tipo = 4 Then
                dgvLibroMayor.Columns.Clear()
                Dim columna8 As New DataGridViewTextBoxColumn
                columna8.Name = "idCuenta"
                columna8.HeaderText = "idCuenta"
                columna8.FillWeight = 30
                dgvLibroMayor.Columns.Add(columna8)

                Dim columna9 As New DataGridViewTextBoxColumn
                columna9.Name = "nombreCuenta"
                columna9.HeaderText = "Cuenta"
                columna9.FillWeight = 30
                dgvLibroMayor.Columns.Add(columna9)

                Dim columna1 As New DataGridViewTextBoxColumn
                columna1.Name = "comprobante"
                columna1.HeaderText = "Comprobante"
                columna1.FillWeight = 30
                dgvLibroMayor.Columns.Add(columna1)

                Dim columna2 As New DataGridViewTextBoxColumn
                columna2.Name = "fecha"
                columna2.HeaderText = "Fecha"
                columna2.FillWeight = 30
                dgvLibroMayor.Columns.Add(columna2)

                Dim columna3 As New DataGridViewTextBoxColumn
                columna3.Name = "concepto"
                columna3.HeaderText = "Concepto"
                'columna3.FillWeight = 3
                dgvLibroMayor.Columns.Add(columna3)

                Dim columna10 As New DataGridViewTextBoxColumn
                columna10.Name = "saldoAnterior"
                columna10.HeaderText = "Saldo Anterior"
                columna10.FillWeight = 50
                dgvLibroMayor.Columns.Add(columna10)


                Dim columna4 As New DataGridViewTextBoxColumn
                columna4.Name = "debe"
                columna4.HeaderText = "Debe"
                columna4.FillWeight = 40
                dgvLibroMayor.Columns.Add(columna4)

                Dim columna5 As New DataGridViewTextBoxColumn
                columna5.Name = "haber"
                columna5.HeaderText = "Haber"
                columna5.FillWeight = 40
                dgvLibroMayor.Columns.Add(columna5)

                Dim columna6 As New DataGridViewTextBoxColumn
                columna6.Name = "saldoDeudor"
                columna6.HeaderText = "Saldo deudor"
                columna6.FillWeight = 50
                dgvLibroMayor.Columns.Add(columna6)

                Dim columna7 As New DataGridViewTextBoxColumn
                columna7.Name = "saldoAcreedor"
                columna7.HeaderText = "Saldo acreedor"
                columna7.FillWeight = 50
                dgvLibroMayor.Columns.Add(columna7)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalcularTotalListado()
        Dim debitosMes As Double = 0
        Dim creditosMes As Double = 0
        Dim saldoMes As Double = 0
        Dim saldoFinal As Double = 0

        For Each partida As DataGridViewRow In dgvListadoCuentaConSaldos.Rows
            'MsgBox(partida.Cells(4).Value)
            ' If partida.Index = 0 Then Continue For
            'If partida.Cells(4).Value = "" Or Not IsNumeric(partida.Cells(4).Value) Or partida.Cells(5).Value = "" Or Not IsNumeric(partida.Cells(5).Value) Then
            'MsgBox("una de las partidas esta mal cargada, por favor verifique, no se sumaran totales")
            'partida.Selected = True
            'Exit Sub
            'Else
            debitosMes += partida.Cells(4).Value
            creditosMes += partida.Cells(5).Value
            saldoMes += partida.Cells(6).Value
            saldoFinal += partida.Cells(7).Value
            ' End If
        Next
        dgvTotales.Columns(0).Visible = False
        dgvTotales.Columns(1).Width = dgvListadoCuentaConSaldos.Columns("numCuenta").Width
        dgvTotales.Columns(2).Width = dgvListadoCuentaConSaldos.Columns("nombreCuenta").Width
        dgvTotales.Columns(3).Width = dgvListadoCuentaConSaldos.Columns("saldoAnterior").Width
        dgvTotales.Columns(4).Width = dgvListadoCuentaConSaldos.Columns("debitosMes").Width
        dgvTotales.Columns(5).Width = dgvListadoCuentaConSaldos.Columns("creditosMes").Width
        dgvTotales.Columns(6).Width = dgvListadoCuentaConSaldos.Columns("saldoMes").Width
        dgvTotales.Columns(7).Width = dgvListadoCuentaConSaldos.Columns("saldoFinal").Width

        dgvTotales.Rows.Add("", "", "", "", FormatNumber(debitosMes, 2), FormatNumber(creditosMes, 2), FormatNumber(saldoMes, 2), FormatNumber(saldoFinal, 2))


    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        Try
            Dim datosContables As New datosContable

            If rdCuentasIndividuales.Checked = True Then
                For Each movimiento As DataGridViewRow In dgvLibroMayor.Rows
                    datosContables.Tables("libroMayor").Rows.Add(
                                    movimiento.Cells("fecha").Value,
                                    movimiento.Cells("comprobante").Value,
                                    movimiento.Cells("concepto").Value,
                                    CDbl(movimiento.Cells("debe").Value),
                                    CDbl(movimiento.Cells("haber").Value),
                                    CDbl(movimiento.Cells("saldoDeudor").Value),
                                    CDbl(movimiento.Cells("saldoAcreedor").Value)
                                    )

                Next
            End If
            If rdTodasCuentas.Checked = True Then
                For Each movimiento As DataGridViewRow In dgvLibroMayor.Rows
                    datosContables.Tables("libroMayorTodos").Rows.Add(
                                    movimiento.Cells("idCuenta").Value,
                                    movimiento.Cells("nombreCuenta").Value,
                                    movimiento.Cells("fecha").Value,
                                    movimiento.Cells("comprobante").Value,
                                    movimiento.Cells("concepto").Value,
                                    CDbl(movimiento.Cells("saldoAnterior").Value),
                                    CDbl(movimiento.Cells("debe").Value),
                                    CDbl(movimiento.Cells("haber").Value),
                                    CDbl(movimiento.Cells("saldoDeudor").Value),
                                    CDbl(movimiento.Cells("saldoAcreedor").Value)
                                    )

                Next
            End If
            Dim imprimirx As New imprimirFX
            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            If rdCuentasIndividuales.Checked = True Then
                parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodoCuenta", DatosAcceso.sistema & " PERIODO " & cmbPeriodoLibroMayor.Text & " CUENTA: " & cmbCuentas.Text))
            Else
                parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodoCuenta", DatosAcceso.sistema & " PERIODO " & cmbPeriodoLibroMayor.Text))
            End If
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                If rdCuentasIndividuales.Checked = True Then
                    .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\libroMayor.rdlc"
                Else
                    .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\libroMayorTodos.rdlc"
                End If
                .rptfx.LocalReport.DataSources.Clear()
                If rdCuentasIndividuales.Checked = True Then
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("libroMayor", datosContables.Tables("libroMayor")))

                Else

                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("libroMayorTodos", datosContables.Tables("libroMayorTodos")))
                End If

                '.rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadorecibos")))
                .rptfx.LocalReport.SetParameters(parameters)
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        Try

            Dim datosContables As New datosContable
            If rdCtaSaldo.Checked = True Then

                For Each cuenta As DataGridViewRow In dgvListadoCuentaConSaldos.Rows
                    datosContables.Tables("cuentasConSaldo").Rows.Add(
                                    cuenta.Cells("idCuenta").Value,
                                    cuenta.Cells("numCuenta").Value,
                                    cuenta.Cells(2).Value,
                                    CDbl(cuenta.Cells("saldoAnterior").Value),
                                    CDbl(cuenta.Cells("debitosMes").Value),
                                    CDbl(cuenta.Cells("creditosMes").Value),
                                    CDbl(cuenta.Cells("saldoMes").Value),
                                    CDbl(cuenta.Cells("saldoFinal").Value)
                                    )

                Next
                Dim imprimirx As New imprimirFX
                Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
                parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodo", DatosAcceso.sistema & " LISTADO DE CUENTAS CON SALDOS " & cmbBalCtasPeriodo.Text))
                With imprimirx
                    .MdiParent = Me.MdiParent
                    .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                    .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listadoCuentasConSaldos.rdlc"
                    .rptfx.LocalReport.DataSources.Clear()
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("cuentasConSaldo", datosContables.Tables("cuentasConSaldo")))
                    '.rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadorecibos")))
                    .rptfx.LocalReport.SetParameters(parameters)
                    .rptfx.DocumentMapCollapsed = True
                    .rptfx.RefreshReport()
                    .Show()
                End With
            End If
            If rdBalance.Checked = True Then
                datosContables.Tables("balanceCuentas").Rows.Clear()

                For Each cuenta As DataGridViewRow In dgvListadoCuentaConSaldos.Rows
                    datosContables.Tables("balanceCuentas").Rows.Add(
                                    cuenta.Cells("grupo").Value,
                                    cuenta.Cells("subGrupo").Value,
                                    cuenta.Cells("cuenta").Value,
                                    cuenta.Cells("subCuenta").Value,
                                    cuenta.Cells("cuentaDetalle").Value,
                                    cuenta.Cells("nombreCuenta").Value,
                                    CDbl(cuenta.Cells("MES").Value),
                                    CDbl(cuenta.Cells("saldoFinal").Value),
                                    CDbl(cuenta.Cells("EJERCICIO").Value),
                                    cuenta.Cells("numCuenta").Value,
                                    cuenta.Cells("cuentaResultado").Value,
                                    cuenta.Cells("cuentaMovimiento").Value
                                    )

                Next

                Dim imprimirx As New imprimirFX
                Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
                parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodo", DatosAcceso.sistema & " BALANCE " & cmbBalCtasPeriodo.Text))
                With imprimirx
                    .MdiParent = Me.MdiParent
                    .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                    .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\balanceCuentas.rdlc"
                    .rptfx.LocalReport.DataSources.Clear()
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("balanceCuentas", datosContables.Tables("balanceCuentas")))
                    '.rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadorecibos")))
                    .rptfx.LocalReport.SetParameters(parameters)
                    .rptfx.DocumentMapCollapsed = True
                    .rptfx.RefreshReport()
                    .Show()
                End With


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tabBalanceCtas_Enter(sender As Object, e As EventArgs) Handles tabBalanceCtas.Enter
        If cmbBalCtasPeriodo.Items.Count = 0 Then
            CargarPeriodos()
        End If


    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        Try
            Dim datosContables As New datosContable
            dgvListadoCuentaConSaldos.Rows.Clear()
            Reconectar()


            Dim consBalance As New MySql.Data.MySqlClient.MySqlDataAdapter("select CTA.id,CTA.grupo,CTA.subGrupo,CTA.cuenta,CTA.subCuenta,CTA.cuentaDetalle, CTA.nombreCuenta, ifnull(
				(select sum(stos.importeDebe)-sum(stos.importeHaber) from cm_libroDiario as LD, cm_Asientos as stos 							
                where stos.codigoAsiento=LD.codigoAsiento and
                (stos.cuentaDebeId=CTA.id or stos.cuentaHaberId=CTA.id) and
                LD.fecha<'" & cmbBalCtasPeriodo.Text & "-%%'                
                ),0) as saldoAnterior, 
                
                ifnull((select sum(stos.importeDebe)from cm_libroDiario as LD, cm_Asientos as stos 							
                where stos.codigoAsiento=LD.codigoAsiento and
                (stos.cuentaDebeId=CTA.id or stos.cuentaHaberId=CTA.id) and
                LD.fecha like '" & cmbBalCtasPeriodo.Text & "-%%'
                ),0) -
                
                ifnull((select sum(stos.importeHaber)from cm_libroDiario as LD, cm_Asientos as stos 							
                where stos.codigoAsiento=LD.codigoAsiento and
                (stos.cuentaDebeId=CTA.id or stos.cuentaHaberId=CTA.id) and
                LD.fecha like '" & cmbBalCtasPeriodo.Text & "-%%'               
                ),0) as MES
                                
                from cm_planDeCuentas as CTA 	
                order by CTA.grupo,CTA.subGrupo,CTA.cuenta,CTA.subCuenta,CTA.cuentaDetalle desc", conexionPrinc)

            consBalance.Fill(datosContables.Tables("balanceCuentas"))

            Dim imprimirx As New imprimirFX
            'Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            ' parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodo", cmbperiodoLibroDiario.Text))
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\balanceCuentas.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("balanceCuentas", datosContables.Tables("balanceCuentas")))
                '.rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadorecibos")))
                '    .rptfx.LocalReport.SetParameters(parameters)
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With




        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbperiodoLibroDiario_SelectedValueChangedComitted(sender As Object, e As EventArgs) Handles cmbperiodoLibroDiario.SelectionChangeCommitted



    End Sub

    Private Sub cmbCuentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCuentas.SelectedIndexChanged
        'CargarLibroDiario()
    End Sub

    Private Sub rdCtaSaldo_CheckedChanged(sender As Object, e As EventArgs) Handles rdCtaSaldo.CheckedChanged
        If rdCtaSaldo.Checked = True Then
            dgvListadoCuentaConSaldos.Rows.Clear()
            dgvTotales.Rows.Clear()
            CrearColumnasGrid(1)
        End If
    End Sub

    Private Sub rdBalance_CheckedChanged(sender As Object, e As EventArgs) Handles rdBalance.CheckedChanged
        If rdBalance.Checked = True Then
            dgvListadoCuentaConSaldos.Rows.Clear()
            dgvTotales.Rows.Clear()
            CrearColumnasGrid(2)
        End If
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs)
        Try


            lblSaldoCtaLibroMayor.Text = FormatNumber(saldoAnteriorCuenta, 2)

            Reconectar()
            Dim consLibroMayor As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT CTA.nombreCuenta, CTA.id, LD.comprobanteInterno, LM.fecha,LM.concepto, 
            (select sum(stos.importeDebe)-sum(stos.importeHaber) as saldoAnterior
            from cm_libroDiario as LD, cm_libroMayor as LM, cm_Asientos as stos, cm_planDeCuentas as PC 
            where LM.fecha < '" & cmbPeriodoLibroMayor.Text & "-%%' and
            LM.codigoAsiento=stos.codigoAsiento and
            LD.codigoAsiento=stos.codigoAsiento and
            PC.id=CTA.id and
            (PC.id=stos.cuentaDebeId or PC.id=stos.cuentaHaberId)
            order by stos.id asc) as saldoAnterior,
			asi.importeDebe, asi.importeHaber 
            From cm_libroMayor as LM, cm_Asientos as asi, cm_libroDiario as LD, cm_planDeCuentas as CTA
            where LM.codigoAsiento=asi.codigoAsiento and
            LM.fecha like ''" & cmbPeriodoLibroMayor.Text & "-%%'-%%' and
            LD.codigoAsiento=LM.codigoAsiento and 
            (asi.cuentaDebeId=CTA.id or asi.cuentaHaberId=CTA.id)
             order by CTA.id,fecha asc", conexionPrinc)
            Dim tabLibroMayor As New DataTable
            consLibroMayor.Fill(tabLibroMayor)
            Dim saldoDeudor As Double = 0
            Dim saldoAcreedor As Double = 0

            If saldoAnteriorCuenta > 0 Then
                saldoDeudor = saldoAnteriorCuenta
                saldoAcreedor = 0
            ElseIf saldoAnteriorCuenta < 0 Then
                saldoDeudor = 0
                saldoAcreedor = saldoAnteriorCuenta * -1
            Else
                saldoDeudor = 0
                saldoAcreedor = 0
            End If

            dgvLibroMayor.Rows.Add("", "", "....SALDO ANTERIOR....", "0", "0", saldoDeudor, saldoAcreedor)

            For Each movimientoCuenta As DataRow In tabLibroMayor.Rows
                Dim debeActual As Double = movimientoCuenta.Item("importeDebe")
                Dim haberActual As Double = movimientoCuenta.Item("importeHaber")
                Dim saldoActual As Double = 0

                If saldoAcreedor > 0 Then

                    saldoActual = saldoAcreedor - (debeActual - haberActual)
                    saldoDeudor = 0

                    If saldoActual > 0 Then

                        saldoAcreedor = saldoActual
                        saldoDeudor = 0
                    Else
                        saldoDeudor = saldoActual * -1
                        saldoAcreedor = 0
                    End If

                ElseIf saldoDeudor > 0 Then

                    saldoActual = saldoDeudor + (debeActual - haberActual)
                    saldoAcreedor = 0

                    If saldoActual > 0 Then
                        saldoDeudor = saldoActual
                        saldoAcreedor = 0
                    Else
                        saldoAcreedor = saldoActual * -1
                        saldoDeudor = 0
                    End If
                Else
                    saldoAcreedor = haberActual
                    saldoDeudor = debeActual

                End If

                dgvLibroMayor.Rows.Add(
                                        movimientoCuenta.Item("comprobanteInterno"),
                                        movimientoCuenta.Item("fecha"),
                                        movimientoCuenta.Item("concepto"),
                                        movimientoCuenta.Item("importeDebe"),
                                        movimientoCuenta.Item("importeHaber"),
                                        saldoDeudor,
                                        saldoAcreedor
                                        )
            Next


        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdCuentasIndividuales_CheckedChanged(sender As Object, e As EventArgs) Handles rdCuentasIndividuales.CheckedChanged
        If rdCuentasIndividuales.Checked = True Then
            cmbCuentas.Enabled = True
            lblSaldoCtaLibroMayor.Text = 0
            CrearColumnasGrid(3)
        End If

    End Sub

    Private Sub rdTodasCuentas_CheckedChanged(sender As Object, e As EventArgs) Handles rdTodasCuentas.CheckedChanged
        If rdTodasCuentas.Checked = True Then
            cmbCuentas.Enabled = False
            lblSaldoCtaLibroMayor.Text = 0
            CrearColumnasGrid(4)
        End If
    End Sub

    Private Sub cmbBalCtasPeriodo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBalCtasPeriodo.SelectedValueChanged
        dgvListadoCuentaConSaldos.Rows.Clear()
        dgvTotales.Rows.Clear()
    End Sub


    Private Sub cmbPeriodoLibroMayor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPeriodoLibroMayor.SelectedValueChanged
        CargarLibroMayor()
    End Sub

    Private Sub Panel16_Paint(sender As Object, e As PaintEventArgs) Handles Panel16.Paint

    End Sub

    Private Sub TabPage6_Click(sender As Object, e As EventArgs) Handles tabUsuarios.Click

    End Sub

    Private Sub TabPage6_Enter(sender As Object, e As EventArgs) Handles tabUsuarios.Enter
        Try
            Reconectar()
            Dim consUsuarios As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id, Cliente as usuario, autorizado, codus,clave 
            FROM AuthServ.CliAuth  where bd like '" & DatosAcceso.bd & "'  ", conexionAuth)
            Dim tabUsuarios As New DataTable
            consUsuarios.Fill(tabUsuarios)

            dgvUsuarios.DataSource = tabUsuarios
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabLog_Enter(sender As Object, e As EventArgs) Handles tabLog.Enter
        CargarLogAcceso()
    End Sub

    Private Sub Button26_Click_1(sender As Object, e As EventArgs) Handles Button26.Click
        Dialog1.periodo = cmbperiodoLibroDiario.Text
        Dialog1.Show()

    End Sub

    Private Sub CargarLogAcceso()
        Try
            Reconectar()
            Dim consLog As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT Clie as Usuario, tarea, ip, fecha_hora FROM 
            AuthServ.LogAcc where bd like '" & DatosAcceso.bd & "'  and fecha_hora like '" & Format(dtfechalog.Value, "yyyy-MM-dd") & " %%:%%:%%' order by id desc", conexionAuth)
            Dim tabLog As New DataTable
            consLog.Fill(tabLog)

            ' MsgBox(consLog.SelectCommand.CommandText)
            dgvLog.DataSource = tabLog
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button39_Click_1(sender As Object, e As EventArgs) Handles Button39.Click
        CargarLogAcceso()
    End Sub

    Private Sub tabdtostecni_Click(sender As Object, e As EventArgs) Handles tabdtostecni.Click

    End Sub

    Private Sub servidorCorreo_Click(sender As Object, e As EventArgs) Handles servidorCorreo.Click

    End Sub

    Private Sub servidorCorreo_Enter(sender As Object, e As EventArgs) Handles servidorCorreo.Enter
        Try
            Reconectar()
            Dim consultaDtosMail As New MySql.Data.MySqlClient.MySqlDataAdapter("select id,nombre,texto1 from tecni_datosgenerales where id>=26 and id<=30", conexionPrinc)
            Dim tablaDtosMail As New DataTable
            consultaDtosMail.Fill(tablaDtosMail)
            dgvServidorCorreo.Rows.Clear()
            For Each fila As DataRow In tablaDtosMail.Rows
                dgvServidorCorreo.Rows.Add(fila.Item(0), fila.Item(1), fila.Item(2))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvServidorCorreo_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvServidorCorreo.CellEndEdit
        Try
            If e.ColumnIndex = 2 Then
                Dim id As Integer = dgvServidorCorreo.Rows(e.RowIndex).Cells(0).Value
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("update tecni_datosgenerales set texto1='" &
                                                                          dgvServidorCorreo.CurrentCell.Value & "' where id=" & id, conexionPrinc)
                comandoadd.ExecuteNonQuery()
                MsgBox("valor actualizado")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtfacturas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtfacturas.CellContentClick

    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        Try
            Dim EnProgreso As New Form
            EnProgreso.ControlBox = False
            EnProgreso.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
            EnProgreso.Size = New Point(430, 30)
            EnProgreso.StartPosition = FormStartPosition.CenterScreen
            EnProgreso.TopMost = True
            Dim Etiqueta As New Label
            Etiqueta.AutoSize = True
            Etiqueta.Text = "Cerrando periodo, esto puede tardar unos momentos, por favor espere ..."
            Etiqueta.Location = New Point(5, 5)
            EnProgreso.Controls.Add(Etiqueta)
            EnProgreso.Show()
            Application.DoEvents()

            If rdBalance.Checked = True Then
                MsgBox("Para cerrar el periodo debe visualizar LISTADO DE CUENTAS CON SALDO")
                Exit Sub
            End If
            If dgvListadoCuentaConSaldos.RowCount = 0 Then
                MsgBox("No existen saldos en esta cuenta para este periodo, presione actualizar")
                Exit Sub
            End If
            If ConsultarPeriodoCerrado(cmbperiodoLibroDiario.Text) = True Then
                MsgBox("el periodo ya esta cerrado")
                Exit Sub
            Else

                If MsgBox("Esta seguro que desea cerrar el periodo? no se podran agregar ni modificar asientos contables luego de esta operacion", vbYesNo + vbQuestion, "Cerrar periodo") = vbNo Then
                    Exit Sub
                Else
                    Reconectar()
                    Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("insert into cm_periodos_cerrados (periodo) values ('" & cmbperiodoLibroDiario.Text & "')", conexionPrinc)
                    comandoadd.ExecuteNonQuery()
                    For Each cuentaSaldo As DataGridViewRow In dgvListadoCuentaConSaldos.Rows
                        'MsgBox(cuentaSaldo.Cells(7).Value & "--" & CDbl(cuentaSaldo.Cells(7).Value.ToString.Replace(".", "")))
                        Dim idcuenta As Integer = cuentaSaldo.Cells(0).Value
                        Dim saldotxt As String = remplazarPunto(cuentaSaldo.Cells(7).Value.ToString.Replace(".", "").Replace(".", "."))
                        Dim saldoCuenta As Double = CDbl(cuentaSaldo.Cells(7).Value)
                        'MsgBox(saldoCuenta & "----" & saldotxt)
                        Reconectar()
                        Dim comandoadd2 As New MySql.Data.MySqlClient.MySqlCommand("insert into cm_saldos_cuentas (idCuenta, periodo,saldo)
                        values (?idcuenta,?periodo,?saldo)", conexionPrinc)
                        With comandoadd2.Parameters
                            .AddWithValue("?idcuenta", idcuenta)
                            .AddWithValue("?periodo", cmbBalCtasPeriodo.Text)
                            .AddWithValue("?saldo", saldoCuenta)
                        End With
                        comandoadd2.ExecuteNonQuery()
                    Next


                    MsgBox("Periodo cerrado")
                End If

            End If
            EnProgreso.Close()
        Catch ex As Exception

            MsgBox(ex.Message & vbNewLine & vbNewLine & "CORROBORE IGUALMENTE QUE EL PERIODO ESTE CERRADO Y LOS SALDOS DE LAS CUENTAS")

        End Try


    End Sub

    Private Sub rdtarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles rdtarjeta.CheckedChanged
        If rdtarjeta.Checked = True Then
            cmbTarjetasMarcas.Visible = True
            cmbTarjetasMarcas.Enabled = True
        Else
            cmbTarjetasMarcas.Visible = False
            cmbTarjetasMarcas.Enabled = False
        End If
        Reconectar()
        Dim tablatajetasNombre As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_tarjetasNombres", conexionPrinc)
        Dim readTarjetasNombre As New DataSet
        tablatajetasNombre.Fill(readTarjetasNombre)
        cmbTarjetasMarcas.DataSource = readTarjetasNombre.Tables(0)
        cmbTarjetasMarcas.DisplayMember = readTarjetasNombre.Tables(0).Columns("nombre").Caption.ToString.ToUpper
        cmbTarjetasMarcas.ValueMember = readTarjetasNombre.Tables(0).Columns("id").Caption.ToString
        cmbTarjetasMarcas.SelectedIndex = -1
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodoComp.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbPeriodoComp.SelectionChangeCommitted

    End Sub

    Private Sub cmbperiodocarg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbperiodocarg.SelectedIndexChanged

    End Sub

    Private Sub ivaVentas_Click(sender As Object, e As EventArgs) Handles ivaVentas.Click

    End Sub

    Private Sub ivaVentas_EnabledChanged(sender As Object, e As EventArgs) Handles ivaVentas.EnabledChanged

    End Sub

    Private Sub tabCompras_Click(sender As Object, e As EventArgs) Handles tabCompras.Click

    End Sub

    Private Sub tabCompras_Enter(sender As Object, e As EventArgs) Handles tabCompras.Enter
        Dim TablaPeriodo As New MySql.Data.MySqlClient.MySqlDataAdapter("select distinct date_format(fecha,'%Y-%m') from fact_proveedores_fact_items order by fecha desc", conexionPrinc)

        Dim readPeriodo As New DataSet
        TablaPeriodo.Fill(readPeriodo)
        cmbPeriodoComp.DataSource = readPeriodo.Tables(0)
        cmbPeriodoComp.DisplayMember = readPeriodo.Tables(0).Columns(0).Caption.ToString.ToUpper
        'cmbvendedor.ValueMember = readPeriodo.Tables(0).Columns(0).Caption.ToString
    End Sub

    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        Dim lector As System.Data.IDataReader
        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        Try
            Reconectar()
            Dim consPeriodo As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * from fact_proveedores_fact_items where fecha like '" & cmbPeriodoComp.Text & "-%%'", conexionPrinc)
            Dim tablaPeriodo As New DataTable
            consPeriodo.Fill(tablaPeriodo)
            'sql.Connection = conexionPrinc
            'sql.CommandText =
            'sql.CommandType = CommandType.Text
            'lector = sql.ExecuteReader
            'MsgBox(sql.CommandText)
            dtlibrocomp.Rows.Clear()
            'While lector.Read()
            If tablaPeriodo.Rows.Count = 0 Then
                MsgBox("no se pudieron cargar las facturas del periodo")
                Exit Sub
            End If
            For Each factura As DataRow In tablaPeriodo.Rows
                Dim fecha As String = Format(CDate(factura.Item("fecha").ToString), "dd-MM-yyyy")
                Dim tipocomp As String = factura.Item("tipocom").ToString
                Dim numfac As String = factura.Item("nufac").ToString
                Dim razon As String = factura.Item("razon").ToString
                Dim cuit As String = factura.Item("cuit").ToString
                Dim conIVA As String = factura.Item("tipocontr").ToString
                Dim neto21 As String = factura.Item("neto21").ToString
                Dim neto105 As String = factura.Item("neto105").ToString
                Dim neto27 As String = factura.Item("neto27").ToString
                Dim iva As String = factura.Item("iva").ToString
                Dim monot As String = factura.Item("monot").ToString
                Dim pcuenta As String = factura.Item("acuenta").ToString
                Dim nogrex As String = factura.Item("nogr").ToString
                Dim periv As String = factura.Item("perciva").ToString
                Dim perib As String = factura.Item("percib").ToString
                Dim total As String = factura.Item("total").ToString
                Dim observa As String = factura.Item("obs").ToString
                Dim cuenta_contable As Integer = factura.Item("cuenta_contable").ToString
                Dim idfcomp As Integer = factura.Item("id")

                dtlibrocomp.Rows.Add(fecha, tipocomp, numfac, razon, cuit, conIVA, neto21, neto105, neto27, iva, monot, pcuenta, nogrex, periv, perib, total, observa.ToUpper, cuenta_contable, idfcomp)
                If tipocomp = "NC" Then
                    dtlibrocomp.Rows(dtlibrocomp.RowCount - 1).DefaultCellStyle.BackColor = Color.Red
                End If
                If observa = "BIEN DE USO" Then
                    dtlibrocomp.Rows(dtlibrocomp.RowCount - 1).DefaultCellStyle.BackColor = Color.Green
                End If
            Next

            SumarTotalesCompras()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        'Dim fmt8 As String = String.Format("{0:00000000}")
        'Dim fmt20 As String = String.Format("{0:000000000000000000000}")
        Dim Comprobantes As String
        Dim Alicuotas As String
        Try
            If MsgBox("Esta seguro que desea exportar a LIBRO DIGITAL?", vbQuestion, vbYesNo) = vbYesNo Then
                Exit Sub
            End If
            For Each registro As DataGridViewRow In dtlibrocomp.Rows
                Dim fcomp As String = Format(CDate(registro.Cells(0).Value), "yyyyMMdd") 'fecha del comprobante
                Dim codigoComp As String = ObternerCodigoComp(registro.Cells(1).Value) 'codigo de comprobante
                Dim ptovta As String = Strings.Left(registro.Cells(2).Value.ToString, 4) 'punto de venta
                ptovta = ptovta.PadLeft(5, "0")

                Dim numcbte As String = Strings.Right(registro.Cells(2).Value.ToString, 8) 'numero de comprobante
                numcbte = numcbte.PadLeft(20, "0")

                Dim despIMp As String = " " 'Despacho de importacion
                despIMp = despIMp.PadRight(16, " ")
                Dim codigodoc As String = obtenerCodigoDoc(registro.Cells(5).Value.ToString) 'codigo documento ri / exc

                Dim numidentCUIT As String = registro.Cells(4).Value.ToString
                numidentCUIT = Replace(registro.Cells(4).Value.ToString, "-", "")
                'numidentCUIT = String.Format("{0:00000000000000000000}", numidentCUIT) 'cuit
                numidentCUIT = numidentCUIT.PadLeft(20, "0")

                Dim razonsocial As String = registro.Cells(3).Value.ToString 'razon social
                If razonsocial.Length > 30 Then razonsocial = razonsocial.Substring(0, 30)
                If razonsocial.Length < 30 Then razonsocial = razonsocial.PadRight(30)

                Dim formatoImporte As String = Replace(FormatNumber(registro.Cells(15).Value, 2), ",", "")
                formatoImporte = Replace(formatoImporte, ".", "")
                formatoImporte = Replace(formatoImporte, "-", "")
                Dim imptotal As String = formatoImporte.PadLeft(15, "0") 'impote total de la operacion

                Dim formatonogr As String = Replace(FormatNumber(registro.Cells(12).Value, 2), ",", "")
                formatonogr = Replace(formatonogr, ".", "")
                formatonogr = Replace(formatonogr, "-", "")
                Dim nogr As String = formatonogr.PadLeft(15, "0") 'impote no gravado

                Dim operexen As String = "000000000000000" 'importe excento

                Dim formatopagocta As Double = FormatNumber(registro.Cells(11).Value, 2)
                Dim formatoperiva As Double = FormatNumber(registro.Cells(13).Value, 2)
                Dim pagoctaIVA As String = Replace(FormatNumber(formatopagocta + formatoperiva, 2), ",", "")
                pagoctaIVA = Replace(pagoctaIVA, ".", "")
                pagoctaIVA = Replace(pagoctaIVA, "-", "")
                'formatopagocta = Replace(FormatNumber(, ",", "")
                'formatopagocta = Replace(formatopagocta, ".", "")
                'formatopagocta = Replace(formatopagocta, "-", "")

                pagoctaIVA = pagoctaIVA.PadLeft(15, "0") 'pagos a cuenta iva y percepciones

                Dim pagoctaNAC As String = "000000000000000" 'pago cuenta nacionales

                Dim formatoperIIBB As String = Replace(FormatNumber(registro.Cells(14).Value, 2), ",", "")
                formatoperIIBB = Replace(formatoperIIBB, ".", "")
                formatoperIIBB = Replace(formatoperIIBB, "-", "")
                Dim perIIBB As String = formatoperIIBB.PadLeft(15, "0") 'percepcion IIBB

                Dim impmuni As String = "000000000000000" 'precepc imp munic
                Dim impint As String = "000000000000000" ' impuestos internos
                Dim moneda As String = "PES" 'moneda
                Dim cambio As String = "0001000000" 'cambio

                Dim i As Integer
                Dim cantali As Integer = 0 'CALCULAMOS LA CANTIDAD DE ALICUOTAS QUE TIENE EL COMPROBANTE

                Dim CodOper = "0" 'codigo de operacion
                Dim CredFis As String = Replace(FormatNumber(registro.Cells(9).Value, 2), ",", "") 'credito fiscal (iva)
                CredFis = Replace(CredFis, ".", "")
                CredFis = Replace(CredFis, "-", "")
                CredFis = CredFis.PadLeft(15, "0")

                Dim otrotrib As String = "000000000000000"
                Dim cuitemicore As String = "00000000000"
                Dim denoemicore As String = ""
                denoemicore = denoemicore.PadRight(30, " ")
                Dim ivacomi As String = "000000000000000"

                'fin de la emision de comprobantes

                'inicio del calculo de alicuotas

                Dim neto105 As String
                Dim liq105 As String

                Dim neto21 As String
                Dim liq21 As String

                Dim neto27 As String
                Dim liq27 As String

                Dim codigoali As String


                For i = 6 To 8
                    If registro.Cells(i).Value <> 0 Then
                        cantali += 1
                        'MsgBox(registro.HeaderCell.ToolTipText)}
                        If i = 6 Then codigoali = "0005"
                        If i = 7 Then codigoali = "0004"
                        If i = 8 Then codigoali = "0006"
                        'MsgBox(codigoali)
                        If codigoali = "0004" Then
                            ' MsgBox(codigoali)
                            neto105 = FormatNumber(registro.Cells(i).Value, 2)
                            neto105 = Replace(neto105, ",", "")
                            neto105 = Replace(neto105, ".", "")
                            neto105 = Replace(neto105, "-", "")
                            neto105 = neto105.PadLeft(15, "0")

                            liq105 = Replace(FormatNumber(registro.Cells(i).Value * 0.105, 2), ",", "")
                            liq105 = Replace(liq105, ".", "")
                            liq105 = Replace(liq105, "-", "")
                            liq105 = liq105.PadLeft(15, "0")
                            Alicuotas &= codigoComp & ptovta & numcbte & codigodoc & numidentCUIT & neto105 & codigoali & liq105 & vbNewLine
                        ElseIf codigoali = "0005" Then
                            'MsgBox(codigoali)
                            neto21 = FormatNumber(registro.Cells(i).Value, 2)
                            neto21 = Replace(neto21, ",", "")
                            neto21 = Replace(neto21, ".", "")
                            neto21 = Replace(neto21, "-", "")
                            neto21 = neto21.PadLeft(15, "0")

                            liq21 = Replace(FormatNumber(registro.Cells(i).Value * 0.21, 2), ",", "")
                            liq21 = Replace(liq21, ".", "")
                            liq21 = Replace(liq21, "-", "")
                            liq21 = liq21.PadLeft(15, "0")

                            Alicuotas &= codigoComp & ptovta & numcbte & codigodoc & numidentCUIT & neto21 & codigoali & liq21 & vbNewLine
                        ElseIf codigoali = "0006" Then
                            'MsgBox(codigoali)
                            neto27 = FormatNumber(registro.Cells(i).Value, 2)
                            neto27 = Replace(neto27, ",", "")
                            neto27 = Replace(neto27, ".", "")
                            neto27 = Replace(neto27, "-", "")
                            neto27 = neto27.PadLeft(15, "0")

                            liq27 = Replace(FormatNumber(registro.Cells(i).Value * 0.27, 2), ",", "")
                            liq27 = Replace(liq27, ".", "")
                            liq27 = Replace(liq27, "-", "")
                            liq27 = liq27.PadLeft(15, "0")
                            Alicuotas &= codigoComp & ptovta & numcbte & codigodoc & numidentCUIT & neto27 & codigoali & liq27 & vbNewLine
                        End If
                    End If
                Next

                Comprobantes &= fcomp & codigoComp & ptovta & numcbte & despIMp & codigodoc & numidentCUIT & razonsocial _
                & imptotal & nogr & operexen & pagoctaIVA & pagoctaNAC & perIIBB & impmuni & impint & moneda & cambio _
                & cantali & CodOper & CredFis & otrotrib & cuitemicore & denoemicore & ivacomi & vbNewLine
            Next


            carpetadestino.ShowDialog()
            'Dim carpeta As New IO.DirectoryInfo(carpetadestino.SelectedPath)
            Dim nombrecomprobantes = carpetadestino.SelectedPath & "\" & Replace(cmbPeriodoComp.Text, "/", "") & "_COMPRAScomprobantes_" & DatosAcceso.Cliente.ToString & ".txt"
            Dim nombrealicutas = carpetadestino.SelectedPath & "\" & Replace(cmbPeriodoComp.Text, "/", "") & "_COMPRASalicuotas_" & DatosAcceso.Cliente.ToString & ".txt"
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If File.Exists(nombrecomprobantes) Then
                strStreamW = File.Open(nombrecomprobantes, FileMode.Open)
            Else
                strStreamW = File.Create(nombrecomprobantes)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)
            strStreamWriter.Write(Comprobantes)
            strStreamWriter.Close()
            MsgBox("archivo de comprobantes generado")

            If File.Exists(nombrealicutas) Then
                strStreamW = File.Open(nombrealicutas, FileMode.Open)
            Else
                strStreamW = File.Create(nombrealicutas)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)
            strStreamWriter.Write(Alicuotas)
            strStreamWriter.Close()
            MsgBox("archivo de alicuotas generado")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        Try
            If txtbdSincronizar.Text = "" Then
                MsgBox("debe ingresar una base de datos")
                Exit Sub
            End If
            conexionSEC.ChangeDatabase(txtbdSincronizar.Text)
            Reconectar()
            Dim TablaPeriodo As New MySql.Data.MySqlClient.MySqlDataAdapter("
            SELECT id, concat(mes,'-', ano) FROM iv_periodos
            order by id desc", conexionSEC)

            Dim readPeriodo As New DataSet
            TablaPeriodo.Fill(readPeriodo)
            cmbperiodosincronizar.DataSource = readPeriodo.Tables(0)
            cmbperiodosincronizar.DisplayMember = readPeriodo.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbperiodosincronizar.ValueMember = readPeriodo.Tables(0).Columns(0).Caption.ToString.ToUpper

            'Dim readPeriodo As New DataSet
            '  TablaPeriodo.Fill(readPeriodo)
            cmbperiodosincronizarCOMP.DataSource = readPeriodo.Tables(0)
            cmbperiodosincronizarCOMP.DisplayMember = readPeriodo.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbperiodosincronizarCOMP.ValueMember = readPeriodo.Tables(0).Columns(0).Caption.ToString.ToUpper

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtbdSincronizar_TextChanged(sender As Object, e As EventArgs) Handles txtbdSincronizar.TextChanged
        txtbdsincronizarCOMP.Text = txtbdSincronizar.Text
    End Sub

    Private Sub txtbdsincronizarCOMP_TextChanged(sender As Object, e As EventArgs) Handles txtbdsincronizarCOMP.TextChanged
        txtbdSincronizar.Text = txtbdsincronizarCOMP.Text
    End Sub

    Private Sub dgvUsuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellContentClick

    End Sub

    Private Sub dgvUsuarios_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellEndEdit
        If e.ColumnIndex = 4 Then

            Dim sqlQuery As String = "update AuthServ.CliAuth set clave=sha('" & dgvUsuarios.CurrentRow.Cells("clave").Value & "') where id=" & dgvUsuarios.CurrentRow.Cells("id").Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            'CargaServiciosCloud()
            dgvUsuarios.Rows(e.RowIndex).Selected = True
        ElseIf e.ColumnIndex = 3 Then
            Dim sqlQuery As String = "update AuthServ.CliAuth set codus='" & dgvUsuarios.CurrentRow.Cells("clave").Value & "' where id=" & dgvUsuarios.CurrentRow.Cells("id").Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            'CargaServiciosCloud()
            dgvUsuarios.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        Try
            Dim datosContables As New datosContable
            Dim TablaPlanCuentas As New MySql.Data.MySqlClient.MySqlDataAdapter("
            select concat(CTA.grupo,CTA.subGrupo,CTA.cuenta,'.',CTA.subcuenta,CTA.cuentaDetalle) as numCuenta, CTA.nombreCuenta        
                from cm_planDeCuentas as CTA 	
                order by CTA.grupo asc,CTA.subGrupo asc,CTA.cuenta asc,CTA.subCuenta asc,CTA.cuentaDetalle asc", conexionSEC)
            Dim readPeriodo As New DataSet
            TablaPlanCuentas.Fill(datosContables.Tables("planCuentas"))



            Dim imprimirx As New imprimirFX
            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodoCuenta", DatosAcceso.sistema & " PLAN DE CUENTAS"))
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local

                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\planCuentas.rdlc"

                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("planCuentas", datosContables.Tables("planCuentas")))
                .rptfx.LocalReport.SetParameters(parameters)
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtfacturas_KeyUp(sender As Object, e As KeyEventArgs) Handles dtfacturas.KeyUp
        If e.KeyCode = Keys.Delete And InStr(DatosAcceso.Moduloacc, "SUPERADMIN") = False Then
            MsgBox("NO ESTA AUTORIZADO PARA ELIMINAR COMPROBANTES")
        ElseIf e.KeyCode = Keys.Delete And InStr(DatosAcceso.Moduloacc, "SUPERADMIN") <> False Then

            If MsgBox("esta seguro que desea elminiar este comprobante? esto no se puede deshacer", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                Reconectar()

                Dim comandofact As New MySql.Data.MySqlClient.MySqlCommand("delete  FROM fact_facturas where id=@idComprobante;
                delete  FROM fact_ingreso_egreso where comprobante=@idComprobante;
                delete  FROM fact_cuentaclie where idcomp=@idComprobante;
                delete  FROM cm_Asientos where codigoAsiento=@codigoAsiento;
                delete  FROM cm_libroDiario where codigoAsiento=@codigoAsiento;
                delete  FROM cm_libroMayor where codigoAsiento=@codigoAsiento", conexionPrinc)

                comandofact.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@idComprobante", MySql.Data.MySqlClient.MySqlDbType.Text))
                comandofact.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@codigoAsiento", MySql.Data.MySqlClient.MySqlDbType.Text))
                comandofact.Parameters("@idComprobante").Value = dtfacturas.CurrentRow.Cells(0).Value
                comandofact.Parameters("@codigoAsiento").Value = dtfacturas.CurrentRow.Cells("NumeroAsiento").Value

                comandofact.ExecuteNonQuery()

                MsgBox("Comprobante eliminado")
                cmdbuscar.PerformClick()

            End If

        End If
    End Sub

    Private Sub dgvLibroDiario_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvLibroDiario.KeyUp
        If e.KeyCode = Keys.Delete And InStr(DatosAcceso.Moduloacc, "SUPERADMIN") = False Then
            MsgBox("NO ESTA AUTORIZADO PARA ELIMINAR ASIENTOS CONTABLES")
        ElseIf e.KeyCode = Keys.Delete And InStr(DatosAcceso.Moduloacc, "SUPERADMIN") <> False Then

            If MsgBox("esta seguro que desea elminiar este asiento contable? esto no se puede deshacer", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                Reconectar()

                Dim comandofact As New MySql.Data.MySqlClient.MySqlCommand("delete FROM cm_libroMayor where codigoAsiento =@codigoAsiento;
                delete FROM cm_libroDiario where codigoAsiento=@codigoAsiento;
                delete FROM cm_Asientos where codigoAsiento=@codigoAsiento;", conexionPrinc)
                comandofact.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@codigoAsiento", MySql.Data.MySqlClient.MySqlDbType.Text))
                comandofact.Parameters("@codigoAsiento").Value = dgvLibroDiario.CurrentRow.Cells("CodigoAsiento").Value

                comandofact.ExecuteNonQuery()

                MsgBox("asiento contable eliminado")
                CargarLibroDiario()
            End If

        End If
    End Sub

    Private Sub dtlistacob_KeyUp(sender As Object, e As KeyEventArgs) Handles dtlistacob.KeyUp
        If e.KeyCode = Keys.Delete And InStr(DatosAcceso.Moduloacc, "SUPERADMIN") = False Then
            MsgBox("NO ESTA AUTORIZADO PARA ELIMINAR COMPROBANTES")
        ElseIf e.KeyCode = Keys.Delete And InStr(DatosAcceso.Moduloacc, "SUPERADMIN") <> False Then

            If MsgBox("esta seguro que desea elminiar este comprobante? esto no se puede deshacer", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                Reconectar()

                Dim comandofact As New MySql.Data.MySqlClient.MySqlCommand("
                delete  FROM fact_facturas where id=@idComprobante;
                delete  FROM fact_ingreso_egreso where comprobante=@idComprobante;
                delete  FROM fact_cuentaclie where idcomp=@idComprobante;
                delete  FROM cm_Asientos where codigoAsiento=@codigoAsiento;
                delete  FROM cm_libroDiario where codigoAsiento=@codigoAsiento;
                delete  FROM cm_libroMayor where codigoAsiento=@codigoAsiento", conexionPrinc)

                comandofact.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@idComprobante", MySql.Data.MySqlClient.MySqlDbType.Text))
                comandofact.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@codigoAsiento", MySql.Data.MySqlClient.MySqlDbType.Text))
                comandofact.Parameters("@idComprobante").Value = dtlistacob.CurrentRow.Cells(0).Value
                comandofact.Parameters("@codigoAsiento").Value = dtlistacob.CurrentRow.Cells("NumeroAsiento").Value

                comandofact.ExecuteNonQuery()

                MsgBox("Comprobante eliminado")
                cmdbuscarcomp.PerformClick()

            End If

        End If
    End Sub

    Private Sub btnActualizarEjercicio_Click(sender As Object, e As EventArgs) Handles btnActualizarEjercicio.Click
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
        Try

            dgvDatosEjercicio.DataSource = Nothing
            Reconectar()
            If rdMovimientosEjercicios.Checked = True Then
                Dim consLibroMayor As New MySql.Data.MySqlClient.MySqlDataAdapter("
                SELECT LD.comprobanteInterno, LM.fecha,LM.concepto, asi.importeDebe, asi.importeHaber, '' as saldoDeudor,'' as saldoAcreedor
                From cm_libroMayor as LM, cm_Asientos as asi, cm_libroDiario as LD
                where LM.codigoAsiento=asi.codigoAsiento and
                LM.fecha between 
                (select date_add(date_add(last_day(concat(periodofiscal,'-',periodoCierre,'-01')),interval -1 year),interval 1 day) from cm_ejercicios_cerrados where periodofiscal like '" & cmbañoEjercicio.Text & "') and
                (select last_day(concat(periodofiscal,'-',periodoCierre,'-01')) from cm_ejercicios_cerrados where periodofiscal like '" & cmbañoEjercicio.Text & "')
                and
                LD.codigoAsiento=LM.codigoAsiento and
                (asi.cuentaDebeId= " & cmbCuentaEjercicio.SelectedValue & " or 
                asi.cuentaHaberId= " & cmbCuentaEjercicio.SelectedValue & " ) and
				LM.concepto like '%" & txtconceptoEjercicio.Text.Replace(" ", "%") & "%'
                order by LM.fecha asc,LD.comprobanteInterno asc", conexionPrinc)
                Dim tabLibroMayor As New DataTable
                'MsgBox(consLibroMayor.SelectCommand.CommandText)
                consLibroMayor.Fill(tabLibroMayor)
                dgvDatosEjercicio.DataSource = tabLibroMayor
                Dim saldoDeudor As Double = 0
                Dim saldoAcreedor As Double = 0

                For Each movimientoCuenta As DataGridViewRow In dgvDatosEjercicio.Rows
                    Dim debeActual As Double = movimientoCuenta.Cells("importeDebe").Value
                    Dim haberActual As Double = movimientoCuenta.Cells("importeHaber").Value
                    Dim saldoActual As Double = 0

                    If saldoAcreedor > 0 Then

                        saldoActual = saldoAcreedor - (debeActual - haberActual)
                        saldoDeudor = 0

                        If saldoActual > 0 Then

                            saldoAcreedor = saldoActual
                            saldoDeudor = 0
                        Else
                            saldoDeudor = saldoActual * -1
                            saldoAcreedor = 0
                        End If

                    ElseIf saldoDeudor > 0 Then

                        saldoActual = saldoDeudor + (debeActual - haberActual)
                        saldoAcreedor = 0

                        If saldoActual > 0 Then
                            saldoDeudor = saldoActual
                            saldoAcreedor = 0
                        Else
                            saldoAcreedor = saldoActual * -1
                            saldoDeudor = 0
                        End If
                    Else
                        saldoAcreedor = haberActual
                        saldoDeudor = debeActual

                    End If

                    movimientoCuenta.Cells("importeDebe").Value = movimientoCuenta.Cells("importeDebe").Value
                    movimientoCuenta.Cells("importeHaber").Value = movimientoCuenta.Cells("importeHaber").Value
                    movimientoCuenta.Cells("saldoDeudor").Value = FormatNumber(saldoDeudor, 2)
                    movimientoCuenta.Cells("saldoAcreedor").Value = FormatNumber(saldoAcreedor, 2)

                Next
                dgvDatosEjercicio.Columns("importeDebe").DefaultCellStyle.Format = "N2"
                dgvDatosEjercicio.Columns("importeHaber").DefaultCellStyle.Format = "N2"
                dgvDatosEjercicio.Columns("saldoDeudor").DefaultCellStyle.Format = "N2"
                dgvDatosEjercicio.Columns("saldoAcreedor").DefaultCellStyle.Format = "N2"







            ElseIf rdSumaEjercicio.Checked = True Then
                Dim consLibroMayor As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT MONTHNAME(LM.fecha) AS MES,format(SUM(asi.importeDebe),2,'es_AR') AS DEBE, format(SUM(asi.importeHaber),2,'es_AR') AS HABER 
                From cm_libroMayor as LM, cm_Asientos as asi, cm_libroDiario as LD
                where LM.codigoAsiento=asi.codigoAsiento and
                LM.fecha between 
                (select date_add(date_add(last_day(concat(periodofiscal,'-',periodoCierre,'-01')),interval -1 year),interval 1 day) from cm_ejercicios_cerrados where periodofiscal like '" & cmbañoEjercicio.Text & "') and
                (select last_day(concat(periodofiscal,'-',periodoCierre,'-01')) from cm_ejercicios_cerrados where periodofiscal like '" & cmbañoEjercicio.Text & "')
                and
                LD.codigoAsiento=LM.codigoAsiento and
                (asi.cuentaDebeId= " & cmbCuentaEjercicio.SelectedValue & " or 
                asi.cuentaHaberId=" & cmbCuentaEjercicio.SelectedValue & " ) and
				LM.concepto like '%" & txtconceptoEjercicio.Text.Replace(" ", "%") & "%'
                group by month(LM.fecha)", conexionPrinc)
                Dim tabLibroMayor As New DataTable
                consLibroMayor.Fill(tabLibroMayor)
                'MsgBox(consLibroMayor.SelectCommand.CommandText)
                dgvDatosEjercicio.DataSource = tabLibroMayor
            End If
            EnProgreso.Close()
        Catch ex As Exception
            EnProgreso.Close()
        End Try
    End Sub
    Private Sub tabEjercicios_Enter(sender As Object, e As EventArgs) Handles tabEjercicios.Enter
        If cmbañoEjercicio.Items.Count = 0 Then
            CargarEjerciciosAnteriores()
        End If
    End Sub

    Private Sub CargarEjerciciosAnteriores()
        Reconectar()
        Dim consEjerciciosAnteriores As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT periodoFiscal from cm_ejercicios_cerrados", conexionPrinc)
        Dim dsEjerciciosAnteriores As New DataSet
        consEjerciciosAnteriores.Fill(dsEjerciciosAnteriores)

        cmbañoEjercicio.DataSource = dsEjerciciosAnteriores.Tables(0)
        cmbañoEjercicio.DisplayMember = dsEjerciciosAnteriores.Tables(0).Columns("periodoFiscal").Caption


        Reconectar()
        Dim consPlanCuentas As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id, concat(nombreCuenta,'<>',concat(grupo,subgrupo,cuenta,subcuenta,cuentadetalle)) as nombreCuenta
            FROM cm_planDeCuentas order by grupo,subGrupo,cuenta,subCuenta,cuentaDetalle", conexionPrinc)
        Dim dsPlanCuentas As New DataSet
        consPlanCuentas.Fill(dsPlanCuentas)

        cmbCuentaEjercicio.DataSource = dsPlanCuentas.Tables(0)
        cmbCuentaEjercicio.DisplayMember = dsPlanCuentas.Tables(0).Columns("nombreCuenta").Caption
        cmbCuentaEjercicio.ValueMember = dsPlanCuentas.Tables(0).Columns("id").Caption
        'cmbCuentas.ValueMember = dsEjerciciosAnteriores.Tables(0).Columns("id").Captio     
    End Sub

    Private Sub dtcategorias_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtcategorias.UserAddedRow
        Try
            Reconectar()
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_categoria_insum (nombre) values " _
        & "(?nmb)", conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?nmb", dtcategorias.CurrentRow.Cells(1).Value.ToString.ToUpper)

                '.AddWithValue("?id", dtlistasprecio.Rows(e.RowIndex).Cells(0).Value)
            End With
            comandoadd.ExecuteNonQuery()
            dtcategorias.CurrentRow.Cells(0).Value = comandoadd.LastInsertedId
            'cargarListas()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvDatosEjercicio_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatosEjercicio.CellContentClick

    End Sub

    Private Sub Button51_Click(sender As Object, e As EventArgs) Handles Button51.Click
        GenerarExcel(dgvDatosEjercicio)

    End Sub

    Private Sub tabcontable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabcontable.SelectedIndexChanged

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub TabControl3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl3.SelectedIndexChanged

    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged

    End Sub

    Private Sub TabControl4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl4.SelectedIndexChanged

    End Sub

    Private Sub TabPage14_Click(sender As Object, e As EventArgs) Handles TabPage14.Click

    End Sub

    Private Sub dtlistasprecio_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtlistasprecio.CellContentClick

    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        Try

            For Each facturaCompra As DataGridViewRow In dtlibrocomp.Rows




                Dim fecha As String = Format(CDate(facturaCompra.Cells("fecha").Value), "yyyy-MM-dd")
                Dim tipocomp As String = facturaCompra.Cells("TipoComp").Value
                Dim numfac As String = facturaCompra.Cells("nufac").Value
                Dim razon As String = facturaCompra.Cells("razonComp").Value
                Dim cuit As String = facturaCompra.Cells("cuit").Value
                Dim conIVA As String = facturaCompra.Cells("TCont").Value
                Dim neto21 As String = facturaCompra.Cells("neto21").Value
                Dim neto105 As String = facturaCompra.Cells("neto105").Value
                Dim neto27 As String = facturaCompra.Cells("neto27").Value
                Dim iva As String = facturaCompra.Cells("ivamon").Value
                Dim monot As String = facturaCompra.Cells("monot").Value
                Dim pcuenta As String = facturaCompra.Cells("acuenta").Value
                Dim nogrex As String = facturaCompra.Cells("nogrexe").Value
                Dim periv As String = facturaCompra.Cells("perciva").Value
                Dim perib As String = facturaCompra.Cells("perib").Value
                Dim total As String = facturaCompra.Cells("total").Value
                Dim observa As String = facturaCompra.Cells("observ").Value
                Dim bienuso As Integer = 0
                Dim IdPeriodo As Integer = cmbperiodosincronizarCOMP.SelectedValue
                Dim sqlQuery As String

                'If comprobarComprobanteCompra(numfac, cuit, conexionSEC) = True Then
                '    MsgBox("el comprobante ya fue cargado, por favor verifique")
                '    Exit Sub
                'End If

                'If tipocomp = "NC" Then
                '    If neto21 <> 0 Then neto21 = "-" & neto21
                '    If neto105 <> 0 Then neto105 = "-" & neto105
                '    If neto27 <> 0 Then neto27 = "-" & neto27
                '    If iva <> 0 Then iva = "-" & iva
                '    If monot <> 0 Then monot = "-" & monot
                '    If pcuenta <> 0 Then pcuenta = "-" & pcuenta
                '    If nogrex <> 0 Then nogrex = "-" & nogrex
                '    If periv <> 0 Then periv = "-" & periv
                '    If perib <> 0 Then perib = "-" & perib
                '    If perib <> 0 Then total = "-" & total
                'End If

                Reconectar()
                sqlQuery = "insert into iv_items_compras(periodo, fecha,tipocom,nufac,razon,cuit,tipocontr,neto21,neto105,neto27,iva,monot," _
                    & "acuenta,nogr,perciva,percib,total,obs,bien_uso) " _
                    & "values(?per,?fech,?tcomp,?nfac,?raz,?cuit,?tcontr,?neto21,?neto105,?neto27,?iva,?mon,?acuenta,?nogr,?periva,?perib,?tot,?obs,?bien)"
                Dim additem As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionSEC)
                With additem.Parameters
                    .AddWithValue("?per", IDperiodo)
                    .AddWithValue("?fech", fecha)
                    .AddWithValue("?tcomp", tipocomp)
                    .AddWithValue("?nfac", numfac)
                    .AddWithValue("?raz", razon)
                    .AddWithValue("?cuit", cuit)
                    .AddWithValue("?tcontr", conIVA)
                    .AddWithValue("?neto21", neto21)
                    .AddWithValue("?neto105", neto105)
                    .AddWithValue("?neto27", neto27)
                    .AddWithValue("?iva", iva)
                    .AddWithValue("?mon", monot)
                    .AddWithValue("?acuenta", pcuenta)
                    .AddWithValue("?nogr", nogrex)
                    .AddWithValue("?periva", periv)
                    .AddWithValue("?perib", perib)
                    .AddWithValue("?tot", total)
                    .AddWithValue("?obs", observa.ToUpper)
                    .AddWithValue("?bien", bienuso)
                End With
                additem.ExecuteNonQuery()
            Next

            MsgBox("Sincronización Finalizada")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button48_Click(sender As Object, e As EventArgs) Handles Button48.Click
        GenerarExcel(dgvLibroMayor)
    End Sub

    Private Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click
        MsgBox("contactar administrador")
    End Sub

    Private Sub cmbperiodoLibroDiario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbperiodoLibroDiario.SelectedIndexChanged

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Button49_Click(sender As Object, e As EventArgs) Handles Button49.Click
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
            Dim desde As String = Format(CDate(dtpgastosdesde.Value), "yyyy-MM-dd")
            Dim hasta As String = Format(CDate(dtpgastoshasta.Value), "yyyy-MM-dd")
            Dim tablagtos As New DataTable
            Dim consGtos As String
            Dim consRazonDetalles As String


            consGtos = " and Pfact.fecha between '" & desde & "' and '" & hasta & "'"

            If cmbGtosConcepto.SelectedIndex = -1 Then
                consGtos &= " and ie.concepto like '%' "
            Else
                consGtos &= " and ie.concepto like '" & cmbGtosConcepto.SelectedValue & "' "
            End If

            If cmbGtosCaja.SelectedIndex = -1 Then
                consGtos &= " and ie.caja like '%' "
            Else
                consGtos &= " and ie.caja like '" & cmbGtosCaja.SelectedValue & "' "
            End If
            consRazonDetalles = "having razon like '%" & txtBusquedaRazonOP.Text.Replace(" ", "%") & "%' or detalles like '%" & txtBusquedaRazonOP.Text.Replace(" ", "%") & "%'"

            tablagtos.Clear()
            ' Dim parambusq As String = " and fac.tipofact in ('5') "

            'If rdefectivo.Checked = True Then
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT  Pfact.id, Pfact.fecha,ec.concepto, prov.razon,ie.descripcion as detalles, concat(tip.abrev,' ', Pfact.numero) as comprobante,format(replace(Pfact.monto,',','.'),2,'es_AR') as monto, caja.descripcion
            FROM fact_proveedores_fact as Pfact, tipos_comprobantes as tip, fact_cajas as caja,
            fact_proveedores as prov,fact_ingreso_egreso as ie, fact_egresos_concepto as ec
            where Pfact.tipo=tip.donfdesc and Pfact.idproveedor=prov.id and ie.comprobante=Pfact.id and Pfact.tipo=993 and ec.id= ie.concepto and ie.tipo=2
            and caja.id=ie.caja and tip.ptovta=caja.id            
            " & consGtos & consRazonDetalles & "
            order by Pfact.fecha asc", conexionPrinc)
            columna = 6
            consulta.Fill(tablagtos)
            dgvgastos.DataSource = tablagtos
            dgvgastos.Columns(0).Visible = False
            'End If
            lblGtosTot.Text = SumarTotal(dgvgastos, columna, 0)
            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles dtpgastoshasta.ValueChanged

    End Sub

    Private Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click

        For Each fila As DataGridViewRow In dgvLibroMayor.Rows
            If fila.Cells("Concepto").Value.ToString().Contains("PUBLICIDAD ") Then
                fila.Cells("Concepto").Value = fila.Cells("Concepto").Value.ToString().Replace("PUBLICIDAD ", "")
            ElseIf fila.Cells("Concepto").Value.ToString().Contains("PAGO FACTURA ") Then
                fila.Cells("Concepto").Value = fila.Cells("Concepto").Value.ToString().Replace("PAGO FACTURA ", "")
            End If
        Next
    End Sub

    Private Sub Button52_Click(sender As Object, e As EventArgs) Handles Button52.Click
        Try
            Dim tabItmIVcomp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ds As New DatasetRecibos
            ' Dim lector As System.Data.IDataReader


            Dim empsel As String = DatosAcceso.Cliente
            Dim perisel As String = cmbPeriodoComp.Text
            'Dim hojacomp As Integer = lector("hojacomp")
            Reconectar()

            tabItmIVcomp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT * from fact_proveedores_fact_items where fecha like '" & cmbPeriodoComp.Text & "-%%'", conexionPrinc)
            tabItmIVcomp.Fill(ds.Tables("IvaCompraItems"))

            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("empresa", empsel))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodo", perisel))
            Dim ivshow As New ImprimirIvaCompra
            With ivshow
                .MdiParent = Me.MdiParent
                .rptivacompra.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptivacompra.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Reportes\LibroIvaCompraDetalles.rdlc"
                .rptivacompra.LocalReport.DataSources.Clear()
                .rptivacompra.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("IvaCompraItems")))
                .rptivacompra.LocalReport.SetParameters(parameters)
                .rptivacompra.DocumentMapCollapsed = True
                .rptivacompra.RefreshReport()
                .tipolibro = "compra"
                .hojasant = 0
                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvgastos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvgastos.CellContentClick

    End Sub

    Private Sub dgvgastos_CellStyleContentChanged(sender As Object, e As DataGridViewCellStyleContentChangedEventArgs) Handles dgvgastos.CellStyleContentChanged

    End Sub

    Private Sub dgvgastos_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvgastos.KeyUp
        If e.KeyCode = Keys.Delete And InStr(DatosAcceso.Moduloacc, "SUPERADMIN") = False Then
            MsgBox("NO ESTA AUTORIZADO PARA ELIMINAR COMPROBANTES")
        ElseIf e.KeyCode = Keys.Delete And InStr(DatosAcceso.Moduloacc, "SUPERADMIN") <> False Then

            If MsgBox("esta seguro que desea elminiar este comprobante? esto no se puede deshacer", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                Reconectar()

                Dim comandofact As New MySql.Data.MySqlClient.MySqlCommand("delete  FROM fact_facturas where id=@idComprobante;
                delete  FROM fact_ingreso_egreso where comprobante=@idComprobante;
                delete  FROM fact_cuentaclie where idcomp=@idComprobante;
                delete  FROM cm_Asientos where codigoAsiento=@codigoAsiento;
                delete  FROM cm_libroDiario where codigoAsiento=@codigoAsiento;
                delete  FROM cm_libroMayor where codigoAsiento=@codigoAsiento", conexionPrinc)

                comandofact.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@idComprobante", MySql.Data.MySqlClient.MySqlDbType.Text))
                comandofact.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@codigoAsiento", MySql.Data.MySqlClient.MySqlDbType.Text))
                comandofact.Parameters("@idComprobante").Value = dtfacturas.CurrentRow.Cells(0).Value
                comandofact.Parameters("@codigoAsiento").Value = dtfacturas.CurrentRow.Cells("NumeroAsiento").Value

                comandofact.ExecuteNonQuery()

                MsgBox("Comprobante eliminado")
                cmdbuscar.PerformClick()

            End If

        End If
    End Sub

    Private Sub dgvLibroDiario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLibroDiario.CellContentClick

    End Sub

    Private Sub Panel33_Paint(sender As Object, e As PaintEventArgs) Handles Panel33.Paint

    End Sub

    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles Button53.Click
        Dim idfactura = dgvgastos.CurrentRow.Cells(0).Value
        ImprimirOrdenDePago(idfactura)
    End Sub

    Private Sub cmbperiodoLibroDiario_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbperiodoLibroDiario.SelectedValueChanged
        CargarLibroDiario()
    End Sub

    Private Sub dtchequespropios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtchequespropios.CellContentClick

    End Sub
End Class