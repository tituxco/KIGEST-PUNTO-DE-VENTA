Imports System.Security

Public Class nuevaventa
    Dim fechagral As String = Format(Now, "dd-MM-yyyy")
    Dim idFactura As Integer
    Dim fa As Boolean
    Dim tmpguardada As Boolean
    Dim rehacerfact As Boolean
    Dim utilidadlista As Double
    Public fxINIC As Boolean
    Public fcINIC As Boolean

    Private Sub dtproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEndEdit
        Try
            SendKeys.Send("{UP}")
            SendKeys.Send("{TAB}")
            Reconectar()
            If e.ColumnIndex = 1 Then
                
                If IsNumeric(dtproductos.Rows(e.RowIndex).Cells(1).Value) Then
                    cargarProdCod(e.RowIndex)
                Else
                    cargarProdPLU(dtproductos.CurrentCell.Value)
                End If
                CalcularTotales()
            ElseIf e.ColumnIndex = 2 Then
                
                Dim pUnit As Double = dtproductos.Rows(e.RowIndex).Cells(5).Value
                Dim cant As Double = dtproductos.Rows(e.RowIndex).Cells(2).Value
                dtproductos.Rows(e.RowIndex).Cells(6).Value = Math.Round(pUnit * cant, 2)
                dtproductos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow

                CalcularTotales()
            ElseIf e.ColumnIndex = 3 Then
                If InStr(dtproductos.Rows(e.RowIndex).Cells(0).Value, "&") = 0 Then
                    If dtproductos.CurrentRow.Cells(1).Value = "" Then
                        selprod.busqueda = dtproductos.CurrentCell.Value()
                        selprod.fila = dtproductos.CurrentCellAddress.Y
                        selprod.LLAMA = "nuevaventa"
                        selprod.dtproductos.Focus()
                        selprod.Show()
                        selprod.TopMost = True
                    End If
                End If
                ElseIf e.ColumnIndex = 5 Then
                dtproductos.CurrentCell.Value = dtproductos.CurrentCell.Value
                Dim pUnit As Double = dtproductos.CurrentCell.Value
                Dim cant As Double = dtproductos.Rows(e.RowIndex).Cells(2).Value
                dtproductos.Rows(e.RowIndex).Cells(6).Value = Math.Round(pUnit * cant, 2)
                dtproductos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow
                CalcularTotales()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CargarORRep(ByRef fila As Integer)
        Try
            Dim texto As String = dtproductos.Rows(fila).Cells(1).Value
            Dim numOR As String = Microsoft.VisualBasic.Right(texto, texto.Length - 1)

            If numOR <> "" And numOR <> "0" And Val(numOR) <> 0 Then
                Reconectar()
                Dim consultaorden As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT format(tall.mo_monto,2,'es_AR'), tall.estado, tall.trab_estado, (select count(tcn.id) from tecni_taller_insumos as tcn where tcn.idtaller=tall.id) as insumos from tecni_taller as tall where tall.id=" & numOR, conexionPrinc)
                Dim tablaorden As New DataTable
                Dim infoorden() As DataRow
                consultaorden.Fill(tablaorden)
                infoorden = tablaorden.Select("")
                If infoorden(0)(1) <> 8 Then
                    MsgBox("La orden de reparacion no esta finalizada, por favor finalice la orden primero")
                    Exit Sub
                End If
                If infoorden(0)(2) <> 3 Then
                    MsgBox("La orden de reparacion ya esta facturada o dada de baja")
                    Exit Sub
                End If
                dtproductos.Rows(fila).Cells(2).Value = "1"
                dtproductos.Rows(fila).Cells(3).Value = "TRABAJO SEGUN ORDEN NUM: " & CompletarCeros(numOR, 2)
                dtproductos.Rows(fila).Cells(4).Value = "21"
                dtproductos.Rows(fila).Cells(5).Value = infoorden(0)(0)
                dtproductos.Rows(fila).Cells(6).Value = infoorden(0)(0)
                If infoorden(0)(3) <> 0 Then
                    Dim consultaprodorden As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT codigo, cantidad, descripcion, format(iva,2,'es_AR'), format(punit,2,'es_AR'), format(ptotal,2,'es_AR') from tecni_taller_insumos where idtaller=" & numOR, conexionPrinc)
                    Dim tablaprodorden As New DataTable
                    Dim infoprodorden() As DataRow
                    consultaprodorden.Fill(tablaprodorden)
                    infoprodorden = tablaprodorden.Select("")
                    For i = 0 To infoprodorden.GetUpperBound(0)
                        dtproductos.Rows.Add(infoprodorden(i)(0), infoprodorden(i)(0), infoprodorden(i)(1), infoprodorden(i)(2), infoprodorden(i)(3), infoprodorden(i)(4), infoprodorden(i)(5))
                    Next
                End If
                CalcularTotales()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub cargarProdCod(ByRef fila As Integer)

        Dim codPLU As String = dtproductos.Rows(fila).Cells(1).Value
        Dim Busq As String
        If codPLU = "" Then
            MsgBox("Debe ingresar un codigo o PLU")
            dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.Red
            Exit Sub
        End If
        If InStr(codPLU, "#") = 1 Then
            Busq = "where cod_bar= " & Microsoft.VisualBasic.Right(codPLU, codPLU.Length - 1)
        ElseIf IsNumeric(codPLU) Then
            Busq = "where id=" & codPLU & " or codigo like '" & codPLU & "'"
        ElseIf Not IsNumeric(codPLU) Then
            Busq = "where  codigo like '" & codPLU & "' or cod_bar like '" & codPLU & "'"
        End If
        Reconectar()
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,codigo,iva,descripcion FROM fact_insumos " & Busq, conexionPrinc)
        Dim tablaprod As New DataTable
        Dim filasProd() As DataRow
        consulta.Fill(tablaprod)
        'dtproductos.DataSource = tablaprod
        '        dtproductos.Rows.Clear()
        filasProd = tablaprod.Select("")
        cmbcondvta.Enabled = False
        cmbtipocontr.Enabled = False
        For i = 0 To filasProd.GetUpperBound(0)
            'If ObtenerStock(filasProd(i)(0)) = 0 Then
            'MsgBox("No hay stock de este producto")
            'dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.Red
            'Exit For
            'Exit Sub
            'End If
            dtproductos.Rows(fila).Cells(0).Value = filasProd(i)(0)
            If filasProd(i)(1).ToString = "" Then
                dtproductos.Rows(fila).Cells(1).Value = filasProd(i)(0)
            Else
                dtproductos.Rows(fila).Cells(1).Value = filasProd(i)(1)
            End If
            If IsDBNull(dtproductos.Rows(fila).Cells(2)) Then
                dtproductos.Rows(fila).Cells(2).Value = 1
            End If

            dtproductos.Rows(fila).Cells(3).Value = filasProd(i)(3)
            dtproductos.Rows(fila).Cells(4).Value = filasProd(i)(2)
            dtproductos.Rows(fila).Cells(5).Value = calcularPrecio(dtproductos.Rows(fila).Cells(0).Value)

            dtproductos.Rows(fila).Cells(6).Value = calcularPrecio(dtproductos.Rows(fila).Cells(0).Value)
            dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.GreenYellow
        Next
    End Sub

    Public Sub cargarProdPLU(ByRef codigo As String)
        Dim codPLU As String = codigo
        Dim Busq As String
        If InStr(codigo, "&") Then
            CargarORRep(dtproductos.CurrentCellAddress.Y)
            Exit Sub
        End If

        If codPLU = "" Then
            MsgBox("Debe ingresar un codigo o PLU")
            'dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.Red
            Exit Sub
        End If
        If InStr(codPLU, "#") = 1 Then
            Busq = "where cod_bar= " & Microsoft.VisualBasic.Right(codPLU, codPLU.Length - 1)
        ElseIf IsNumeric(codPLU) Then
            Busq = "where id=" & codPLU & " or codigo like '" & codPLU & "'"
        ElseIf Not IsNumeric(codPLU) Then
            Busq = "where  codigo like '" & codPLU & "' or cod_bar like '" & codPLU & "'"
        End If

        Reconectar()
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,codigo,iva,descripcion FROM fact_insumos " & Busq, conexionPrinc)
        Dim tablaprod As New DataTable
        Dim filasProd() As DataRow
        consulta.Fill(tablaprod)
        If tablaprod.Rows.Count = 0 Then
            lblnoplu.Text = "NO SE ENCUENTRA EL PRODUCTO " & codPLU
        Else
            lblnoplu.Text = ""
        End If
        'dtproductos.DataSource = tablaprod
        '        dtproductos.Rows.Clear()
        filasProd = tablaprod.Select("")
        cmbcondvta.Enabled = False
        cmbtipocontr.Enabled = False
        For i = 0 To filasProd.GetUpperBound(0)
            
            dtproductos.Rows.Add(filasProd(i)(0), filasProd(i)(1), txtcantPLU.Text, filasProd(i)(3), filasProd(i)(2), _
                                calcularPrecio(filasProd(i)(0)), FormatNumber(txtcantPLU.Text) * calcularPrecio(filasProd(i)(0)))

        Next
    End Sub
    Private Function calcularPrecio(ByRef codProd As String) As Double
        Try
            Dim ganancia As Double

            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT precio, ganancia, iva, moneda FROM fact_insumos where id=" & codProd, conexionPrinc)
            Dim tablaprod As New DataTable
            Dim filasProd() As DataRow
            consulta.Fill(tablaprod)
            filasProd = tablaprod.Select("")

            'cargamos listas de precios
            Dim consultalis As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT utilidad FROM fact_listas_precio where id=" & cmblistaprecio.SelectedValue, conexionPrinc)
            Dim tablalistas As New DataTable
            Dim filaslistas() As DataRow
            consultalis.Fill(tablalistas)
            filaslistas = tablalistas.Select("")

            'cargamos la moneda perteneciente a este producto
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select (select cotizacion from fact_moneda  where  id =" & filasProd(0)(3) & ") as cotiza, (select valor from fact_configuraciones where  id =1) as lista"
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            Dim cotizacion As Double = FormatNumber(lector("cotiza").ToString)
            'Dim coeflista As Double = (FormatNumber(lector("lista").ToString) + 100) / 100


            Dim precioCosto As Double = FormatNumber(filasProd(0)(0))
            Dim iva As Double = (FormatNumber(filasProd(0)(2)) + 100) / 100
            Dim utilidad As Double = (FormatNumber(filasProd(0)(1)) + 100) / 100
            Dim lista As Double

            Dim PrecioSinIva As Double
            Dim PrecioVenta As Double


            If InStr(filaslistas(0)(0), "%") <> 0 Then
                Dim textLista = Microsoft.VisualBasic.Right(filaslistas(0)(0), filaslistas(0)(0).ToString.Length - 1)
                lista = FormatNumber((textLista + 100) / 100)

                PrecioSinIva = precioCosto * cotizacion * lista
                PrecioVenta = PrecioSinIva * iva

            Else
                lista = (FormatNumber(filaslistas(0)(0)) + 100) / 100

                PrecioSinIva = precioCosto * cotizacion * utilidad * lista
                PrecioVenta = PrecioSinIva * iva
            End If

            Select Case cmbtipofac.SelectedValue
                Case 13, 15, 17, 3, 4, 8
                    Return Math.Round(PrecioSinIva, 2)
                Case Else
                    Return Math.Round(PrecioVenta, 2)
            End Select
        Catch ex As Exception
            Return 0
        End Try
    End Function


    Public Sub CalcularTotales()
        Try
            'Dim fila As New DataGridViewRow
            Dim i As Integer
            Dim subtotal As Double
            Dim subtotal105 As Double
            Dim subtotal21 As Double
            Dim iva105 As Double
            Dim iva21 As Double
            Dim total As Double

            For i = 0 To dtproductos.RowCount - 2
                If cmbtipocontr.SelectedValue = 1 Then
                    Select Case cmbtipofac.SelectedValue
                        Case 3, 13, 4, 15, 8, 17
                            If dtproductos.Rows(i).Cells(4).Value = "10,5" Then
                                subtotal105 += FormatNumber(dtproductos.Rows(i).Cells(6).Value)
                                'subtotal += FormatNumber(dtproductos.Rows(i).Cells(5).Value)
                            ElseIf dtproductos.Rows(i).Cells(4).Value = "21" Then
                                subtotal21 += FormatNumber(dtproductos.Rows(i).Cells(6).Value)

                            Else
                                Exit Sub
                            End If
                            iva105 = Math.Round(subtotal105 * (10.5 / 100), 2)
                            iva21 = Math.Round(subtotal21 * (21 / 100), 2)
                            txtiva105.Text = iva105
                            txtiva21.Text = iva21
                            txtsub21.Text = subtotal21
                            txtsub105.Text = subtotal105
                        Case 2, 12, 29
                            If dtproductos.Rows(i).Cells(4).Value = "10,5" Then
                                subtotal105 += FormatNumber(dtproductos.Rows(i).Cells(6).Value)
                                'subtotal += FormatNumber(dtproductos.Rows(i).Cells(5).Value)
                            ElseIf dtproductos.Rows(i).Cells(4).Value = "21" Then
                                subtotal21 += FormatNumber(dtproductos.Rows(i).Cells(6).Value)

                            Else
                                Exit Sub
                            End If
                    End Select
                Else
                    Select Case cmbtipofac.SelectedValue
                        Case 1, 14, 10, 16, 11, 18
                            If dtproductos.Rows(i).Cells(4).Value = "10,5" Then
                                subtotal105 += Math.Round(FormatNumber(dtproductos.Rows(i).Cells(6).Value) / 1.105, 2)
                                'subtotal += FormatNumber(dtproductos.Rows(i).Cells(5).Value)
                            ElseIf dtproductos.Rows(i).Cells(4).Value = "21" Then

                                subtotal21 += Math.Round(FormatNumber(dtproductos.Rows(i).Cells(6).Value) / 1.21, 2)
                            Else
                                Exit Sub
                            End If
                            iva105 = Math.Round(subtotal105 * (10.5 / 100), 2)
                            iva21 = Math.Round(subtotal21 * (21 / 100), 2)
                            txtiva105.Text = iva105
                            txtiva21.Text = iva21
                            txtsub21.Text = subtotal21
                            txtsub105.Text = subtotal105
                        Case 2, 12, 29, 30, 31, 32
                            If dtproductos.Rows(i).Cells(4).Value = "10,5" Then
                                subtotal105 += FormatNumber(dtproductos.Rows(i).Cells(6).Value)
                                'subtotal += FormatNumber(dtproductos.Rows(i).Cells(5).Value)
                            ElseIf dtproductos.Rows(i).Cells(4).Value = "21" Then
                                subtotal21 += FormatNumber(dtproductos.Rows(i).Cells(6).Value)
                            Else
                                Exit Sub
                            End If
                    End Select
                End If
                'subtotal += FormatNumber(dtproductos.Rows(i).Cells(6).Value)
            Next
            subtotal = Math.Round(subtotal21 + subtotal105, 2)
            txtsubtotal.Text = subtotal
            txttotal.Text = Math.Round(subtotal + iva105 + iva21, 2)
            If rehacerfact = True Then
                'MsgBox(Format(CType(fechagral, Date), "yyyyMMd") & "=" & lblfechacae.Text & "-" & txttotal.Text & "-" & lblimportecae.Text & "-" & txtcuit.Text.Replace("-", "") = lblcuitcae.Text)
                If Format(CType(fechagral, Date), "yyyyMMdd") = lblfechacae.Text And txttotal.Text = lblimportecae.Text And txtcuit.Text.Replace("-", "") = lblcuitcae.Text Then
                    ' MsgBox("no coinciden los datos de la autorizacion con respecto a la factura")
                    cmdguardar.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarDatosGrales() 'igp
        Try
            Reconectar()
                Dim tablaptovta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, numero from fact_puntosventa", conexionPrinc)
                Dim readtptovta As New DataSet
                tablaptovta.Fill(readtptovta)
                txtptovta.DataSource = readtptovta.Tables(0)
                txtptovta.DisplayMember = readtptovta.Tables(0).Columns(1).Caption.ToString
                txtptovta.ValueMember = readtptovta.Tables(0).Columns(0).Caption.ToString
                txtptovta.SelectedIndex = -1


            Dim tablaivat As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_ivatipo", conexionPrinc)
                Dim readivat As New DataSet
                tablaivat.Fill(readivat)
                cmbtipocontr.DataSource = readivat.Tables(0)
                cmbtipocontr.DisplayMember = readivat.Tables(0).Columns(1).Caption.ToString.ToUpper
                cmbtipocontr.ValueMember = readivat.Tables(0).Columns(0).Caption.ToString
                cmbtipocontr.SelectedIndex = -1


                Dim tablaconvtta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_condventas", conexionPrinc)
                Dim readconvta As New DataSet
                tablaconvtta.Fill(readconvta)
                cmbcondvta.DataSource = readconvta.Tables(0)
                cmbcondvta.DisplayMember = readconvta.Tables(0).Columns(1).Caption.ToString.ToUpper
                cmbcondvta.ValueMember = readconvta.Tables(0).Columns(0).Caption.ToString
            cmbcondvta.SelectedIndex = -1

            Dim tablavend As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,', ', nombre) from fact_vendedor where activo=1", conexionPrinc)
                Dim readvend As New DataSet
                tablavend.Fill(readvend)
                cmbvendedor.DataSource = readvend.Tables(0)
                cmbvendedor.DisplayMember = readvend.Tables(0).Columns(1).Caption.ToString.ToUpper
                cmbvendedor.ValueMember = readvend.Tables(0).Columns(0).Caption.ToString
            cmbvendedor.SelectedValue = DatosAcceso.Vendedor

            Dim tablautil As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_listas_precio", conexionPrinc)
                Dim readutil As New DataSet
                tablautil.Fill(readutil)
                cmblistaprecio.DataSource = readutil.Tables(0)
                cmblistaprecio.DisplayMember = readutil.Tables(0).Columns(1).Caption.ToString.ToUpper
                cmblistaprecio.ValueMember = readutil.Tables(0).Columns(0).Caption.ToString
                cmblistaprecio.SelectedIndex = 0

            If fxINIC = True Then
                'MsgBox("si")
                txtptovta.SelectedValue = 1
                'cmbtipofac.SelectedValue = 23
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub deshabilitarControles()

        For Each Cont As Control In panelcliente.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                If tex.ReadOnly = True Then
                    tex.ReadOnly = False
                Else
                    tex.ReadOnly = True
                End If

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                If cbo.Enabled = False Then
                    cbo.Enabled = True
                Else
                    cbo.Enabled = False
                End If
            End If
        Next

    End Sub

    Public Sub cargarCliente()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cl.nomapell_razon as clie, cl.dir_domicilio, lc.nombre," _
            & " cl.iva_tipo, cl.cuit, cl.lista_precios,cl.vendedor from fact_clientes as cl,  cm_localidad as lc where lc.id=cl.dir_localidad and  idclientes = " & txtctaclie.Text, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            If infocl(0)(3) <> 1 Then
                Select Case cmbtipofac.SelectedValue
                    Case 3, 13, 4, 15, 8, 17
                        MsgBox("El tipo de factura seleccionado no correponde al tipo de contribuyente")
                        txtrazon.Focus()
                        Exit Sub
                End Select
            ElseIf infocl(0)(3) = 1 Then
                Select Case cmbtipofac.SelectedValue
                    Case 1, 14, 10, 16, 11, 18
                        MsgBox("El tipo de factura seleccionado no correponde al tipo de contribuyente")
                        txtrazon.Focus()
                        Exit Sub
                End Select
            End If
            'If cmbtipofac.SelectedValue = 1 And infocl(0)(3) = 1 Then
            '    MsgBox("El tipo de factura seleccionado no correponde al tipo de contribuyente")
            '    txtrazon.Focus()
            '    Exit Sub
            'ElseIf cmbtipofac.SelectedValue = 3 And infocl(0)(3) <> 1 Then
            '    MsgBox("El tipo de factura seleccionado no correponde al tipo de contribuyente")
            '    txtrazon.Focus()
            '    Exit Sub
            'End If
            txtrazon.Text = infocl(0)(0)
            txtdomicilio.Text = infocl(0)(1)
            txtciudad.Text = infocl(0)(2)
            cmbtipocontr.SelectedValue = infocl(0)(3)
            txtcuit.Text = infocl(0)(4)
            cmblistaprecio.SelectedValue = infocl(0)(5)
            cmbvendedor.SelectedValue = infocl(0)(6)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub nuevaventa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Control And e.Alt And e.KeyCode = Keys.R Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub nuevaventa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub

    Private Sub nuevaventa_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F12 Then
            Dim nvafech As String = InputBox("ingrese nueva fecha", "cambio de fecha de factura")
            If nvafech <> "" And IsDate(nvafech) Then
                fechagral = nvafech
                lblfecha.Text = Format(CDate(nvafech), "dd-MMMM-yyyy")
                tmrcontrolarnumfact.Enabled = False
                txtnufac.ReadOnly = False
                rehacerfact = True
                cmbsolicitarcae.Text = "Recuperar Info"
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            cmbsolicitarcae.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            cmdguardar.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            cmdimprimir.PerformClick()
        End If
    End Sub
    Private Sub nuevaventa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatosGrales()
        lblfecha.Text = "Fecha: " & fechagral
        panelcliente.Enabled = False
        dtproductos.ReadOnly = True
        'If DatosAcceso.StockPpref = 1 Then
        '    chkquitarstock.Checked = True
        'End If
        'txtctaclie.Text = 9999
        'cargarCliente()
        'cmbcondvta.SelectedValue = 1
        'cmblistaprecio.SelectedValue = 1
        'cmbvendedor.SelectedValue = 1
    End Sub

    Private Sub cmbtipofac_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbtipofac.SelectionChangeCommitted
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select confnume from fact_conffiscal where donfdesc=" & cmbtipofac.SelectedValue & " and ptovta=" & txtptovta.SelectedValue
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            txtnufac.Text = CompletarCeros(FormatNumber(lector("confnume").ToString) + 1, 1)
            cmbtipofac.Enabled = False
            txtptovta.Enabled = False
            panelcliente.Enabled = True
            tmrcontrolarnumfact.Enabled = True
            Select Case cmbtipofac.SelectedValue
                Case 3, 13
                    fa = True
            End Select
            If txtptovta.Text <> 1 Then
                cmbsolicitarcae.Enabled = True
                cmdguardar.Enabled = False
            ElseIf txtptovta.Text = 1 Then
                cmbsolicitarcae.Enabled = False
                cmdguardar.Enabled = True
            End If

            Select Case cmbtipofac.SelectedValue
                Case 2, 3, 7, 8, 12, 13, 991, 992,
                    chkquitarstock.Checked = False
                    chkquitarstock.Enabled = False
            End Select


        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtctaclie_KeyUp(sender As Object, e As KeyEventArgs) Handles txtctaclie.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                cargarCliente()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtrazon_KeyUp(sender As Object, e As KeyEventArgs) Handles txtrazon.KeyUp
        If e.KeyCode = Keys.Enter Then
            selclie.busqueda = txtrazon.Text
            selclie.llama = "nuevaventa"
            selclie.dtpersonal.Focus()
            selclie.Show()
            selclie.TopMost = True
        End If
    End Sub
    Private Sub cmbcondvta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcondvta.SelectionChangeCommitted
        dtproductos.ReadOnly = False
        paneltareas.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub

    Public Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
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
        tmrcontrolarnumfact.Enabled = False
        dtproductos.AllowUserToAddRows = False
        dtpedidosfact.AllowUserToAddRows = False
        'variables para la factura
        Dim num_fact As Integer
        Dim ptovta As String = txtptovta.Text
        Dim fecha As String = Format(CDate(fechagral), "yyyy-MM-dd")
        Dim idcliente As String = txtctaclie.Text
        Dim razon As String = txtrazon.Text
        Dim direccion As String = txtdomicilio.Text
        Dim localidad As String = txtciudad.Text
        Dim tipocontr As String = cmbtipocontr.Text
        Dim cuit As String = txtcuit.Text
        Dim condvta As Integer = cmbcondvta.SelectedValue
        Dim subtotal As String = remplazarPunto(txtsubtotal.Text)
        Dim iva105 As String = remplazarPunto(txtiva105.Text)
        Dim iva21 As String = remplazarPunto(txtiva21.Text)
        Dim total As String = remplazarPunto(txttotal.Text)
        Dim vendedor As Integer = cmbvendedor.SelectedValue
        Dim tipoFact As Integer = cmbtipofac.SelectedValue
        Dim obs2 As String = txtobservaciones.Text
        num_fact = CType(txtnufac.Text, Integer)
        Dim sqlQuery As String

        'variables para los items de factura
        Dim cod As String
        Dim cantidad As String
        Dim descripcion As String
        Dim iva As String
        Dim punit As String
        Dim ptotal As String
        Dim codbar As String
        Dim i As Integer

        'comprobamos que se seleccione un vendedor
        If cmbvendedor.SelectedValue = 0 Then
            MsgBox("Seleccione vendedor")
            Exit Sub
        End If

        'comprobamos que el numero de factura no este en uso
        If RestringirNumerosFact(cmbtipofac.SelectedValue, num_fact, ptovta) = True Then
            MsgBox("El numero de comprobante ya existe para este tipo, por favor verifique")
            Exit Sub
        End If

        'comprobamos que exista stock de los productos
        If chkquitarstock.Checked = True Then
            dtproductos.AllowUserToAddRows = False
            Dim contarstock As Integer = 0
            For Each productoscomp As DataGridViewRow In dtproductos.Rows

                If ComprobarStock(productoscomp.Cells(0).Value, productoscomp.Cells(2).Value) = False Then
                    ' MsgBox("Uno de los productos no pudo ser procesado por falta de stock o es insuficiente, por favor compruebe")
                    productoscomp.DefaultCellStyle.BackColor = Color.Red
                    contarstock += 1 ' Exit Sub
                End If
            Next
            If contarstock > 0 Then
                MsgBox("Uno de los productos no pudo ser procesado por falta de stock o es insuficiente, por favor compruebe los elementos resaltados")
                Exit Sub
            End If
        End If
        Reconectar()
        Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand
        Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand
        Dim Transaccion As MySql.Data.MySqlClient.MySqlTransaction
        Transaccion = conexionPrinc.BeginTransaction

        Try
            'GUARDO LOS DATOS DE LA FACTURA
            sqlQuery = "insert into fact_facturas  " _
            & "(tipofact,ptovta, num_fact,fecha,id_cliente,razon,direccion,localidad,tipocontr,cuit,condvta,subtotal,iva105,iva21,total,vendedor,observaciones2,cae,vtocae,codbarra) values " _
            & "(?tipofact, ?ptov,?nfac,?fech,?idclie,?razon,?dire,?loca,?tipocont,?cuit,?condvta,?subt,?105,?21,?tot,?vend,?obs2,?cae,?vtocae,?codbarra)"
            comandoadd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?ptov", Val(ptovta))
                .AddWithValue("?tipofact", tipoFact)
                .AddWithValue("?nfac", Val(num_fact))
                .AddWithValue("?fech", fecha)
                .AddWithValue("?idclie", idcliente)
                .AddWithValue("?razon", razon)
                .AddWithValue("?dire", direccion)
                .AddWithValue("?loca", localidad)
                .AddWithValue("?tipocont", tipocontr)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?condvta", condvta)
                .AddWithValue("?subt", subtotal)
                .AddWithValue("?105", iva105)
                .AddWithValue("?21", iva21)
                .AddWithValue("?tot", total)
                .AddWithValue("?vend", vendedor)
                .AddWithValue("?obs2", obs2)
                .AddWithValue("?cae", lblestadoCAE.Text.Replace("CAE: ", ""))
                .AddWithValue("?vtocae", lblvtoCAE.Text.Replace("Vto: ", ""))
                .AddWithValue("?codbarra", lblcodigobarras.Text)
            End With
            comandoadd.Transaction = Transaccion
            comandoadd.ExecuteNonQuery()
            idFactura = comandoadd.LastInsertedId

            'actualizo el numero de factura excepto para la factura electronica
            If txtptovta.Text <> 3 Then
                Reconectar()
                sqlQuery = "update fact_conffiscal set confnume=" & Val(num_fact) & " where id= " & cmbtipofac.SelectedValue
                comandoupd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                comandoupd.Transaction = Transaccion
                comandoupd.ExecuteNonQuery()
            End If
            'cargo los items de la factura
            'Dim i As Integer
            For Each itemsFact As DataGridViewRow In dtproductos.Rows
                If Not IsNumeric(itemsFact.Cells(0).Value) Then
                    cod = 0
                Else
                    cod = itemsFact.Cells(0).Value
                End If
                codbar = itemsFact.Cells(1).Value
                cantidad = itemsFact.Cells(2).Value
                descripcion = itemsFact.Cells(3).Value.ToString.ToUpper
                iva = remplazarPunto(itemsFact.Cells(4).Value)
                punit = remplazarPunto(itemsFact.Cells(5).Value)
                ptotal = remplazarPunto(itemsFact.Cells(6).Value)

                'para quitar de stock
                If chkquitarstock.Checked = True Then
                    Dim cant As Double = cantidad
                    Dim codigo As String = cod
                    Dim lotes As Integer = 0

                    Reconectar()
                    Dim consultastock As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id, stock FROM fact_insumos_lotes " _
                    & "where stock >0 and idproducto=" & codigo & " order by id asc", conexionPrinc)
                    Dim tablastock As New DataTable
                    Dim infostock() As DataRow
                    consultastock.Fill(tablastock)
                    infostock = tablastock.Select("")
                    Do Until cant = 0
                        If infostock(lotes)(1) <= cant Then
                            cant = cant - infostock(lotes)(1)
                            Reconectar()
                            Dim updstock As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos_lotes set stock=0 where id=" & infostock(lotes)(0), conexionPrinc)
                            updstock.Transaction = Transaccion
                            updstock.ExecuteNonQuery()
                            lotes += 1
                        ElseIf infostock(lotes)(1) > cant Then
                            Reconectar()
                            Dim updstock As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos_lotes set stock=stock-" & cant & " where id=" & infostock(lotes)(0), conexionPrinc)
                            updstock.Transaction = Transaccion
                            updstock.ExecuteNonQuery()
                            cant = 0
                        End If
                    Loop
                End If

                'guardamos los items
                Reconectar()
                sqlQuery = "insert into fact_items " _
                & "(cod,plu,cantidad, descripcion, iva, punit, ptotal, tipofact,ptovta,num_fact,id_fact) values" _
                & "(?cod,?plu, ?cant,?desc,?iva,?punit,?ptot,?tipofact,?ptovta,?num_fact,?id_fact)"

                comandoadd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters
                    .AddWithValue("?cod", cod)
                    .AddWithValue("?plu", codbar)
                    .AddWithValue("?cant", cantidad)
                    .AddWithValue("?desc", descripcion)
                    .AddWithValue("?iva", iva)
                    .AddWithValue("?punit", punit)
                    .AddWithValue("?ptot", ptotal)
                    .AddWithValue("?tipofact", cmbtipofac.SelectedValue)
                    .AddWithValue("?ptovta", Val(txtptovta.Text))
                    .AddWithValue("?num_fact", num_fact)
                    .AddWithValue("?id_fact", idFactura)
                End With
                comandoadd.Transaction = Transaccion
                comandoadd.ExecuteNonQuery()

                'si hay ordenes de reparacion entre los items le ponemos facturada
                If InStr(itemsFact.Cells(1).Value.ToString, "&") <> 0 Then
                    Dim idtrab As Integer = Microsoft.VisualBasic.Right(itemsFact.Cells(1).Value.ToString, Len(itemsFact.Cells(1).Value.ToString) - 1)
                    sqlQuery = "update tecni_taller set trab_estado=1, factura=" & idFactura & " where id=" & idtrab
                    comandoupd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                    comandoupd.Transaction = Transaccion
                    comandoupd.ExecuteNonQuery()
                End If
            Next

            'dependiendo de la condicion de venta hacemos distintas acciones
            Reconectar()
            sqlQuery = "insert into fact_cuentaclie (idclie,idcomp) values (?clie, ?idcomp)"
            comandoadd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?clie", txtctaclie.Text)
                .AddWithValue("?idcomp", idFactura)
            End With
            comandoadd.Transaction = Transaccion
            comandoadd.ExecuteNonQuery()
            Select Case cmbcondvta.SelectedValue
                Case 2 'cuenta corriente
                    MsgBox("Cuenta corriente actualizada")

                Case 1 'contado genero un recibo

                    Dim j As Integer
                    For j = 0 To frmprincipal.MdiChildren.Length - 1
                        If frmprincipal.MdiChildren(i).Name = "movimientocaja" Then
                            'frmprincipal.MdiChildren(i).BringToFront()
                            MsgBox("La ventana de movimiento de caja esta abierta")
                            Exit Sub
                        End If
                    Next
                    Dim mov As New movimientodecaja
                    mov.MdiParent = Me.MdiParent
                    mov.Show()
                    mov.cmbtipofac.SelectedValue = 5
                    mov.txtctaclie.Text = txtctaclie.Text
                    mov.cargarCliente()
                    mov.dtconceptos.Rows.Add(comandoadd.LastInsertedId, cmbtipofac.Text & " " & txtptovta.Text & " - " & txtnufac.Text, txttotal.Text, idFactura)
                    mov.dtconceptos.Enabled = False
                    mov.cmbtipofac.Enabled = False
                    mov.Button4.Enabled = False
                    mov.txttotalefectivo.Focus()
                    mov.AcceptButton = mov.Button1
                    mov.CalcularTotalescobro()
            End Select

            'PONEMOS FACTURADO AL PEDIDO
            If rdpedido.Checked = True Then
                For Each pedido As DataGridViewRow In dtpedidosfact.Rows
                    If pedido.Cells(0).Value.ToString <> "" Then
                        sqlQuery = "update fact_facturas set observaciones='FACTURADO' where id=" & pedido.Cells(0).Value
                        comandoupd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                        comandoupd.Transaction = Transaccion
                        comandoupd.ExecuteNonQuery()
                    End If
                Next
            ElseIf rdserial.Checked = True Then
                For Each pedido As DataGridViewRow In dtpedidosfact.Rows
                    If pedido.Cells(1).Value.ToString <> "" Then
                        sqlQuery = "update fact_gtia set fventa=?fventa, compvta=?compvta where serie like'" & pedido.Cells(1).Value & "'"
                        comandoupd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                        With comandoupd.Parameters
                            .AddWithValue("?fventa", fecha)
                            .AddWithValue("?compvta", idFactura)
                        End With
                        comandoupd.Transaction = Transaccion
                        comandoupd.ExecuteNonQuery()
                    End If
                Next
            End If

            Transaccion.Commit()
            cmdguardar.Enabled = False

            cmdimprimir.Enabled = True
            cmdremito.Enabled = False
            panelencabeza.Enabled = False
            panelcliente.Enabled = False
            dtproductos.Enabled = False
            ' MsgBox("Factura guardada satisfactoriamente")

        Catch ex As Exception
            tmrcontrolarnumfact.Enabled = True
            Transaccion.Rollback()
            MsgBox(ex.Message)
        End Try
        EnProgreso.Close()
    End Sub

    Public Sub cmdimprimir_Click(sender As Object, e As EventArgs) Handles cmdimprimir.Click
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
            & "concat(vend.apellido,', ',vend.nombre) as facvend, fac.condvta as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21," _
            & "'','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra " _
            & "FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac  " _
            & "where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.id=fac.tipofact and fac.id=" & idFactura, conexionPrinc)

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

            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                If txtptovta.Text <> FacturaElectro.puntovtaelect Then 'Select Case txtptovta.Text

                    Select Case cmbtipofac.SelectedValue
                        Case 1, 3
                            .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturaleg.rdlc"
                        Case 2, 12, 29
                            .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturax.rdlc"
                        Case 4, 10
                            .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\notacredleg.rdlc"
                    End Select
                Else
                    .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturaelectro.rdlc"
                End If ' End Select
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("facturax")))
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()

                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
        EnProgreso.Close()
    End Sub

    Private Sub txtnufac_Leave(sender As Object, e As EventArgs) Handles txtnufac.Leave
        txtnufac.Text = CompletarCeros(txtnufac.Text, 1)
    End Sub

    Private Sub dtproductos_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtproductos.UserDeletedRow
        CalcularTotales()
    End Sub

    Private Sub dtproductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtproductos.KeyPress

        If e.KeyChar = "."c Then
            MsgBox("punto")
            e.Handled = True
            SendKeys.Send(",")
        End If

    End Sub

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtproductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub dtpedidosfact_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtpedidosfact.CellEndEdit
        Try

            If e.ColumnIndex = 1 And rdpedido.Checked = True Then
                Reconectar()
                Dim consultapedido As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
                & "id, condvta, vendedor from fact_facturas where observaciones like 'PENDIENTE' AND ptovta=1 and num_fact=" & dtpedidosfact.CurrentCell.Value & " and tipofact=9", conexionPrinc)
                Dim tablaped As New DataTable
                Dim infoped() As DataRow
                consultapedido.Fill(tablaped)
                infoped = tablaped.Select("")
                If tablaped.Rows.Count = 0 Then
                    MsgBox("Pedido no encontrado o ya facturado")
                    dtpedidosfact.CurrentCell.Value = ""
                    SendKeys.Send("{UP}")
                    Exit Sub
                End If
                dtpedidosfact.CurrentRow.Cells(0).Value = infoped(0)(0)
                cmbcondvta.SelectedValue = infoped(0)(1)
                cmbvendedor.SelectedValue = infoped(0)(2)

                Reconectar()
                Dim consultapedidoitems As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cod,codint, cantidad, descripcion, iva, punit, ptotal from fact_items where id_fact=" & dtpedidosfact.CurrentRow.Cells(0).Value, conexionPrinc)
                Dim tablaitm As New DataTable
                Dim infoitm() As DataRow
                consultapedidoitems.Fill(tablaitm)
                infoitm = tablaitm.Select("")
                For i = 0 To infoitm.GetUpperBound(0)
                    dtproductos.Rows.Add(infoitm(i)(0), infoitm(i)(1), infoitm(i)(2), infoitm(i)(3), infoitm(i)(4), infoitm(i)(5), infoitm(i)(6))
                Next
                rdserial.Enabled = False
                CalcularTotales()
            ElseIf e.ColumnIndex = 1 And rdserial.Checked = True Then
                Reconectar()
                Dim consultapedidoitems As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT prod.codigo " _
                & "FROM fact_gtia as gtia, fact_insumos as prod " _
                & "where prod.codigo=gtia.codigo and gtia.serie like '" & dtpedidosfact.CurrentCell.Value & "'", conexionPrinc)
                ' MsgBox(consultapedidoitems.SelectCommand.CommandText)
                Dim tablaitm As New DataTable
                Dim infoitm() As DataRow
                consultapedidoitems.Fill(tablaitm)
                infoitm = tablaitm.Select("")
                If tablaitm.Rows.Count = 0 Then
                    MsgBox("No se encuentra el producto en la tabla de garantias")
                    dtpedidosfact.CurrentCell.Value = ""
                    SendKeys.Send("{UP}")
                Else
                    cargarProdPLU(infoitm(0)(0))
                    CalcularTotales()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tmrcontrolarnumfact_Tick(sender As Object, e As EventArgs) Handles tmrcontrolarnumfact.Tick
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select confnume from fact_conffiscal where donfdesc=" & cmbtipofac.SelectedValue & " and ptovta=" & txtptovta.SelectedValue
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            txtnufac.Text = CompletarCeros(FormatNumber(lector("confnume").ToString) + 1, 1)
            'cmbtipofac.Enabled = False
            'panelcliente.Enabled = True
            'dtproductos.ReadOnly = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdremito.Click

        Dim ptovta As String = 1
        Dim tipoFact As Integer = 20
        Dim num_fact As Integer = ObtenerNumerosFact(tipoFact, ptovta)
        Dim idRemito As Integer
        Dim coef As Double = 0

        Try
            If MsgBox("el numero de remito sera: " & ptovta & "-" & num_fact & "   esto es correcto? ", vbYesNo + vbQuestion) = vbNo Then
                Exit Sub
            End If

            Dim fecha As String = Format(CDate(fechagral), "yyyy-MM-dd")
            Dim idcliente As String = txtctaclie.Text
            Dim razon As String = txtrazon.Text
            Dim direccion As String = txtdomicilio.Text
            Dim localidad As String = txtciudad.Text
            Dim tipocontr As String = cmbtipocontr.Text
            Dim cuit As String = txtcuit.Text
            Dim condvta As Integer = cmbcondvta.SelectedValue
            Dim transporte As String = txttransporte.Text
            'Dim subtotal As String = txtsubtotal.Text
            'Dim iva105 As String = txtiva105.Text
            'Dim iva21 As String = txtiva21.Text

            Dim total As String = txttotal.Text
            Dim vendedor As Integer = cmbvendedor.SelectedValue

            Dim sqlQuery As String
            If RestringirNumerosFact(tipoFact, num_fact, ptovta) = True Then
                MsgBox("El numero de comprobante ya existe para este tipo, por favor verifique")
                Exit Sub
            End If

            Reconectar()
            sqlQuery = "insert into fact_facturas  " _
                & "(tipofact,ptovta, num_fact,fecha,id_cliente,razon,direccion,localidad,tipocontr,cuit,condvta,subtotal,iva105,iva21,total,vendedor,observaciones2) values " _
                & "(?tipofact, ?ptov,?nfac,?fech,?idclie,?razon,?dire,?loca,?tipocont,?cuit,?condvta,?subt,?105,?21,?tot,?vend,?transp)"

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?ptov", Val(ptovta))
                .AddWithValue("?tipofact", tipoFact)
                .AddWithValue("?nfac", Val(num_fact))
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
            sql.CommandText = "update fact_conffiscal set confnume=" & Val(num_fact) & " where id= " & tipoFact
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
        Catch ex As Exception

        End Try

        Try
            Dim cod As String
            Dim cantidad As String
            Dim descripcion As String
            Dim iva As String
            Dim punit As String
            Dim ptotal As String
            Dim codbar As String
            Dim i As Integer
            Dim sqlQuery As String

            If Val(num_fact) = 0 Then
                MsgBox("No se pueden guardar los items de la factura")
                Exit Sub
            End If

            For i = 0 To dtproductos.RowCount - 2

                If fa = True Then
                    coef = (dtproductos.Rows(i).Cells(4).Value + 100) / 100
                End If
                cod = dtproductos.Rows(i).Cells(0).Value
                codbar = dtproductos.Rows(i).Cells(1).Value
                cantidad = dtproductos.Rows(i).Cells(2).Value
                descripcion = dtproductos.Rows(i).Cells(3).Value
                iva = dtproductos.Rows(i).Cells(4).Value
                punit = dtproductos.Rows(i).Cells(5).Value * coef
                ptotal = dtproductos.Rows(i).Cells(6).Value * coef

                If chkquitarstock.Checked = True Then
                    If Val(cod) <> 0 Then
                        'If QuitarStock(cod, cantidad) = False Then
                        '    MsgBox("No se pudo quitar de stock el item")
                        '    Exit Sub
                        'End If
                    ElseIf Microsoft.VisualBasic.Right(cod, cod.Length - 1).ToString <> "" Then
                    End If
                End If

                sqlQuery = "insert into fact_items " _
                & "(cod,cantidad, descripcion, iva, punit, ptotal, tipofact,ptovta,num_fact,id_fact) values" _
                & "(?cod, ?cant,?desc,?iva,?punit,?ptot,?tipofact,?ptovta,?num_fact,?id_fact)"

                Reconectar()
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters

                    .AddWithValue("?cod", cod)
                    .AddWithValue("?cant", cantidad)
                    .AddWithValue("?desc", descripcion)
                    .AddWithValue("?iva", iva)
                    .AddWithValue("?punit", punit)
                    .AddWithValue("?ptot", ptotal)
                    .AddWithValue("?tipofact", cmbtipofac.SelectedValue)
                    .AddWithValue("?ptovta", Val(txtptovta.Text))
                    .AddWithValue("?num_fact", num_fact)
                    .AddWithValue("?id_fact", idRemito)
                End With
                comandoadd.ExecuteNonQuery()
            Next
            cmdremito.Enabled = False


            'asignamos el remito a la factura
            sqlQuery = "update fact_facturas set remito=?idremito where id=?idfactura"
            Reconectar()
            Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoupd.Parameters
                .AddWithValue("?idremito", idRemito)
                .AddWithValue("?idfactura", idFactura)
            End With
            comandoupd.ExecuteNonQuery()

            'imprimimos

            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas

            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, " _
            & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.fecha as facfech, " _
            & "concat(fac.id_cliente,'-',fac.razon,' - tel: ',cl.telefono) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, " _
            & "concat(vend.apellido,', ',vend.nombre) as facvend, fac.condvta as faccondvta, fac.observaciones2 as facobserva,fac.iva105, fac.iva21," _
            & "fac.total,'',fis.donfdesc " _
            & "FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac  " _
            & "where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.id=fac.tipofact and fac.id=" & idRemito, conexionPrinc)

            tabEmp.Fill(fac.Tables("factura_enca"))
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "cantidad as cant, descripcion,iva,punit,ptotal from fact_items where " _
            & "id_fact=" & idRemito, conexionPrinc)
            tabFac.Fill(fac.Tables("facturax"))

            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\remito.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("facturax")))
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()

                .Show()
            End With

        Catch ex As Exception

        End Try
    End Sub


    Public Sub Button1_Click_1(sender As Object, e As EventArgs) Handles cmbsolicitarcae.Click
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
        '3 0%
        '4 10,50%
        '5 21%
        '6 27%
        '8 5%
        '9 2,50%
        tmrcontrolarnumfact.Enabled = False
        If rehacerfact = True Then
            Dim fe As New WSAFIPFE.Factura
            'Dim nContador As Integer
            'Dim nNumero As Integer
            Dim lresultado As Boolean

            Dim cbtetipo As Integer
            Dim doctipo As Integer
            Dim contribtipo As Integer
            Dim idiva As Integer

            Dim sub21 As Double = FormatNumber(txtsub21.Text, 2)
            Dim sub105 As Double = FormatNumber(txtsub105.Text, 2)
            Dim iva21 As Double = FormatNumber(txtiva21.Text, 2)
            Dim iva105 As Double = FormatNumber(txtiva105.Text, 2)
            Dim subtotal As Double = Math.Round(sub21 + sub105, 2)
            Dim ivatotal As Double = Math.Round(iva21 + iva105, 2)
            Dim total As Double = Math.Round(subtotal + ivatotal, 2)

            Dim existecomp As Boolean
            'MsgBox(cmbtipofac.SelectedValue)
            Select Case cmbtipofac.SelectedValue
                Case 1
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaA
                Case 2
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoA
                Case 3
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoA
                Case 6
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaB
                Case 7
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoB
                Case 8
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoB
                Case 11
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaC
                Case 12
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoC
                Case 13
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoC
                Case Else
                    MsgBox("tipo de comprobante no admitido")
                    EnProgreso.Close()
                    Exit Sub
            End Select

            Select Case cmbtipocontr.SelectedValue
                Case 1
                    contribtipo = WSAFIPFE.Factura.TipoReponsable.ResponsableInscripto
                    doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                    idiva = 5
                Case 5
                    contribtipo = WSAFIPFE.Factura.TipoReponsable.Exento
                    doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                    idiva = 3
                Case 4
                    If txtcuit.Text = "" Then
                        contribtipo = WSAFIPFE.Factura.TipoReponsable.ConsumidorFinal
                        doctipo = WSAFIPFE.Factura.TipoDocumento.SinIdentificacionGlobalDiario
                        txtcuit.Text = 0
                        idiva = 3
                    ElseIf txtcuit.Text <> "" And IsNumeric(txtcuit.Text) Then
                        contribtipo = WSAFIPFE.Factura.TipoReponsable.ConsumidorFinal
                        doctipo = WSAFIPFE.Factura.TipoDocumento.DNI
                        'txtcuit.Text = 0
                        idiva = 3
                    End If
                Case 6
                    contribtipo = WSAFIPFE.Factura.TipoReponsable.Monotributo
                    doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                    idiva = 3
                Case Else
                    MsgBox("Tipo de contribuyente no admitido")
                    EnProgreso.Close()
                    Exit Sub
            End Select

            lresultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, FacturaElectro.cuit, Application.StartupPath & FacturaElectro.certificado, Application.StartupPath & FacturaElectro.licencia)
            fe.ArchivoCertificadoPassword = FacturaElectro.passcertificado
            ' MsgBox(lresultado.ToString)
            If lresultado Then
                lresultado = fe.f1ObtenerTicketAcceso()

            End If

            existecomp = fe.F1CompConsultar(Val(txtptovta.Text), cbtetipo, Val(txtnufac.Text))
            If existecomp Then
                lblestadoCAE.Text = fe.F1RespuestaDetalleCae
                lblvtoCAE.Text = fe.F1RespuestaDetalleCAEFchVto
                lblfechacae.Text = fe.F1RespuestaDetalleCbteFch
                lblimportecae.Text = fe.F1DetalleImpTotal
                lblcuitcae.Text = fe.F1DetalleDocNro
                lblobservacionescae.Text = "Resultado: " & fe.F1RespuestaResultado & vbNewLine
                lblobservacionescae.Text &= "Importe de la factura: " & fe.F1DetalleImpTotal & vbNewLine
                lblobservacionescae.Text &= "Fecha del Comprobante: " & fe.F1DetalleCbteFch & vbNewLine
                lblobservacionescae.Text &= "Cuit del comprador: " & fe.F1DetalleDocNro & vbNewLine
                lblcodigobarras.Text = fe.f1CodigoDeBarraAFIP
                cmdguardar.Enabled = True
            Else
                MsgBox("No existe comprobante")
            End If


            '--------------------------------------------------------------------------------------------

        Else
            'MsgBox("NUEVA")
            Try

                Dim fe As New WSAFIPFE.Factura
                Dim nContador As Integer
                Dim nNumero As Integer
                Dim lresultado As Boolean

                Dim cbtetipo As Integer
                Dim doctipo As Integer
                Dim contribtipo As Integer
                Dim idiva As Integer

                Dim sub21 As Double = FormatNumber(txtsub21.Text, 2)
                Dim sub105 As Double = FormatNumber(txtsub105.Text, 2)
                Dim iva21 As Double = FormatNumber(txtiva21.Text, 2)
                Dim iva105 As Double = FormatNumber(txtiva105.Text, 2)
                Dim sub0 As Double = FormatNumber(txtsub0.Text, 2)
                Dim iva0 As Double = 0

                Dim subtotal As Double = Math.Round(sub21 + sub105, 2)
                Dim ivatotal As Double = Math.Round(iva21 + iva105, 2)
                Dim total As Double = Math.Round(subtotal + ivatotal, 2)

                Select Case cmbtipofac.SelectedValue
                    Case 1
                        cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaA
                    Case 2
                        cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoA
                    Case 3
                        cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoA
                    Case 6
                        cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaB
                    Case 7
                        cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoB
                    Case 8
                        cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoB
                    Case 11
                        cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaC
                    Case 12
                        cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoC
                    Case 13
                        cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoC
                    Case Else
                        MsgBox("tipo de comprobante no admitido")
                        EnProgreso.Close()
                        Exit Sub
                End Select
                'MsgBox("2")
                Select Case cmbtipocontr.SelectedValue
                    Case 1
                        contribtipo = WSAFIPFE.Factura.TipoReponsable.ResponsableInscripto
                        doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                        idiva = 5
                    Case 5
                        contribtipo = WSAFIPFE.Factura.TipoReponsable.Exento
                        doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                        idiva = 3
                    Case 4
                        If txtcuit.Text = "" Then
                            MsgBox("Debe ingresar el DNI o CUIL del cliente")
                            EnProgreso.Close()
                            Exit Sub
                        ElseIf txtcuit.Text <> "" And IsNumeric(txtcuit.Text) And txtcuit.Text <> 0 Then

                            contribtipo = WSAFIPFE.Factura.TipoReponsable.ConsumidorFinal
                            doctipo = WSAFIPFE.Factura.TipoDocumento.DNI
                            'txtcuit.Text = 0
                            idiva = 3
                        Else
                            MsgBox("debe ingresar un DNI o CUIL correcto")
                            EnProgreso.Close()
                            Exit Sub
                        End If
                    Case 6
                        contribtipo = WSAFIPFE.Factura.TipoReponsable.Monotributo
                        doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                        idiva = 3
                    Case Else
                        MsgBox("Tipo de contribuyente no admitido")
                        EnProgreso.Close()
                        Exit Sub
                End Select
                'MsgBox(FacturaElectro.cuit & "-" & FacturaElectro.certificado & "-" & FacturaElectro.licencia & "-" & FacturaElectro.passcertificado)
                lresultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, FacturaElectro.cuit, Application.StartupPath & FacturaElectro.certificado, Application.StartupPath & FacturaElectro.licencia)
                fe.ArchivoCertificadoPassword = FacturaElectro.passcertificado
                If lresultado Then
                    lresultado = fe.f1ObtenerTicketAcceso()
                Else
                    MsgBox("NO SE PUDO OBTENER EL TIKET DE ACCESO A AFIP." & vbNewLine & "Motivo:" & fe.UltimoNumeroError & vbNewLine & fe.UltimoMensajeError)
                    EnProgreso.Close()
                    Exit Sub
                End If

                If lresultado Then
                    fe.F1CabeceraCbteTipo = cbtetipo
                    fe.F1CabeceraPtoVta = Val(txtptovta.Text)
                    fe.F1CabeceraCantReg = 1
                    fe.F1DetalleMonId = "PES"
                    fe.F1DetalleMonCotiz = 1
                    fe.F1DetalleConcepto = 1
                    fe.F1DetalleDocTipo = doctipo
                    fe.F1DetalleDocNro = txtcuit.Text.Replace("-", "")
                    fe.F1DetalleCbteDesdeS = Val(txtnufac.Text)
                    fe.F1DetalleCbteHastaS = Val(txtnufac.Text)
                    fe.F1DetalleCbteFch = Format(Now, "yyyyMMdd")

                    Dim cantiva As Integer

                    If iva105 = 0 And iva21 <> 0 And sub0 = 0 Then
                        '        MsgBox("1")
                        fe.F1DetalleIvaItemCantidad = 1
                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 5
                        fe.F1DetalleIvaBaseImp = sub21
                        fe.F1DetalleIvaImporte = iva21

                    ElseIf iva105 <> 0 And iva21 <> 0 And sub0 = 0 Then
                        '       MsgBox("2")
                        fe.F1DetalleIvaItemCantidad = 2

                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 5
                        fe.F1DetalleIvaBaseImp = sub21
                        fe.F1DetalleIvaImporte = iva21

                        fe.f1IndiceItem = 1
                        fe.F1DetalleIvaId = 4
                        fe.F1DetalleIvaBaseImp = sub105
                        fe.F1DetalleIvaImporte = iva105

                    ElseIf iva105 <> 0 And iva21 = 0 And sub0 = 0 Then
                        '      MsgBox("3")
                        fe.F1DetalleIvaItemCantidad = 1
                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 4
                        fe.F1DetalleIvaBaseImp = sub105
                        fe.F1DetalleIvaImporte = iva105

                    ElseIf iva105 = 0 And iva21 <> 0 And sub0 <> 0 Then
                        '     MsgBox("4")
                        fe.F1DetalleIvaItemCantidad = 2

                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 5
                        fe.F1DetalleIvaBaseImp = sub21
                        fe.F1DetalleIvaImporte = iva21

                        fe.f1IndiceItem = 1
                        fe.F1DetalleIvaId = 3
                        fe.F1DetalleIvaBaseImp = sub0
                        fe.F1DetalleIvaImporte = 0

                    ElseIf iva105 <> 0 And iva21 <> 0 And sub0 <> 0 Then
                        '    MsgBox("5")
                        fe.F1DetalleIvaItemCantidad = 3

                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 5
                        fe.F1DetalleIvaBaseImp = sub21
                        fe.F1DetalleIvaImporte = iva21

                        fe.f1IndiceItem = 1
                        fe.F1DetalleIvaId = 4
                        fe.F1DetalleIvaBaseImp = sub105
                        fe.F1DetalleIvaImporte = iva105

                        fe.f1IndiceItem = 2
                        fe.F1DetalleIvaId = 3
                        fe.F1DetalleIvaBaseImp = sub0
                        fe.F1DetalleIvaImporte = 0


                    ElseIf iva105 <> 0 And iva21 = 0 And sub0 <> 0 Then
                        '   MsgBox("6")
                        fe.F1DetalleIvaItemCantidad = 2

                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 4
                        fe.F1DetalleIvaBaseImp = sub105
                        fe.F1DetalleIvaImporte = iva105

                        fe.f1IndiceItem = 1
                        fe.F1DetalleIvaId = 3
                        fe.F1DetalleIvaBaseImp = sub0
                        fe.F1DetalleIvaImporte = 0

                    End If
                    'MsgBox("4")
                    fe.F1DetalleImpTotal = total
                    fe.F1DetalleImpTotalConc = 0
                    fe.F1DetalleImpNeto = subtotal
                    fe.F1DetalleImpIva = ivatotal
                    'If MsgBox("total: " & total & vbNewLine & "Neto: " & subtotal & vbNewLine & "ImpIVA: " & ivatotal & vbNewLine & vbNewLine & "esta correcto?" & vbYesNo) = MsgBoxResult.Yes Then
                    lresultado = fe.F1CAESolicitar()
                    ' Else
                    'Exit Sub
                    ' end If

                    If lresultado Then
                        If fe.F1RespuestaResultado = "R" Then
                            MsgBox("Solicitud rechazada " & fe.UltimoMensajeError & " - " & fe.UltimoNumeroError)
                            lblobservacionescae.Text = "Resultado: " & fe.F1RespuestaResultado & vbNewLine
                            lblobservacionescae.Text &= "Observaciones: " & fe.F1RespuestaDetalleObservacionMsg1 & fe.F1RespuestaDetalleObservacionMsg
                            lblobservacionescae.Text &= "error: " & fe.F1RespuestaDetalleObservacionMsg & fe.UltimoMensajeError & vbNewLine
                            lblobservacionescae.Text &= "Ultimo otorgado: " & fe.F1CompUltimoAutorizado(Val(txtptovta.Text), cbtetipo)

                            Exit Sub
                        ElseIf fe.F1RespuestaResultado = "A" Then

                            lblestadoCAE.Text = "CAE: " & fe.F1RespuestaDetalleCae
                            lblvtoCAE.Text = "Vto: " & fe.F1RespuestaDetalleCAEFchVto
                            lblobservacionescae.Text = "Resultado: " & fe.F1RespuestaResultado & vbNewLine
                            lblobservacionescae.Text &= "Observaciones: " & fe.F1RespuestaDetalleObservacionMsg1 & vbNewLine
                            lblobservacionescae.Text &= "error: " & fe.F1RespuestaDetalleObservacionMsg & fe.UltimoMensajeError & vbNewLine
                            lblobservacionescae.Text &= "Ultimo otorgado: " & fe.F1CompUltimoAutorizado(Val(txtptovta.Text), cbtetipo)
                            lblcodigobarras.Text = fe.f1CodigoDeBarraAFIP
                            Reconectar()
                            Dim lector As System.Data.IDataReader
                            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                            sql.Connection = conexionPrinc
                            sql.CommandText = "update fact_conffiscal set confnume=" & Val(txtnufac.Text) & " where id= " & cmbtipofac.SelectedValue
                            sql.CommandType = CommandType.Text
                            lector = sql.ExecuteReader
                            lector.Read()
                            cmdguardar.Enabled = True
                            cmbsolicitarcae.Enabled = False
                        End If

                    Else
                        lblobservacionescae.Text = "error: " & fe.F1RespuestaDetalleObservacionMsg & fe.UltimoMensajeError & vbNewLine
                        lblobservacionescae.Text &= "Ultimo otorgado: " & fe.F1CompUltimoAutorizado(Val(txtptovta.Text), cbtetipo)
                        cmdguardar.Enabled = False
                    End If
                End If
            Catch ex As Exception
                tmrcontrolarnumfact.Enabled = True
                MsgBox(ex.Message)
                EnProgreso.Close()
            End Try
        End If
        EnProgreso.Close()
    End Sub

    Private Sub txtcodPLU_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcodPLU.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim encuentraprod As Integer
            Dim contarprod As Integer = 0

            If txtcodPLU.Text = "" Then
                Exit Sub
            End If

            If dtproductos.Rows.Count = 0 Then
                cargarProdPLU(txtcodPLU.Text)

            Else
                For Each fila As DataGridViewRow In dtproductos.Rows
                    If fila.Cells(1).Value = txtcodPLU.Text Then
                        contarprod += 1
                        encuentraprod = fila.Index
                    End If
                Next
                If contarprod <> 0 Then
                    dtproductos.Rows(encuentraprod).Cells(2).Value += 1
                    dtproductos.Rows(encuentraprod).Cells(6).Value = dtproductos.Rows(encuentraprod).Cells(5).Value * dtproductos.Rows(encuentraprod).Cells(2).Value

                Else
                    cargarProdPLU(txtcodPLU.Text)

                End If
            End If
            CalcularTotales()
            txtcodPLU.Text = ""
            txtcantPLU.Text = 1
            txtcodPLU.Focus()
        End If
    End Sub


    Private Sub txtptovta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtptovta.SelectionChangeCommitted
        Try
            Reconectar()
            Dim tablaftipo As New MySql.Data.MySqlClient.MySqlDataAdapter("select donfdesc, abrev from tipos_comprobantes where ptovta=" & txtptovta.SelectedValue & " and tip=1", conexionPrinc)
            Dim readftipo As New DataSet
            'MsgBox(tablaftipo.SelectCommand.CommandText)
            tablaftipo.Fill(readftipo)
            cmbtipofac.DataSource = readftipo.Tables(0)
            cmbtipofac.DisplayMember = readftipo.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbtipofac.ValueMember = readftipo.Tables(0).Columns(0).Caption.ToString
            cmbtipofac.SelectedIndex = -1
            'If fxINIC = True Then
            '    cmbtipofac.SelectedValue = 23
            'End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RecalcularPreciosLista()
        For Each filasprod As DataGridViewRow In dtproductos.Rows
            filasprod.Cells(5).Value = calcularPrecio(filasprod.Cells(0).Value)
            filasprod.Cells(6).Value = filasprod.Cells(5).Value * filasprod.Cells(2).Value
            CalcularTotales()
        Next
    End Sub

    Private Sub cmblistaprecio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmblistaprecio.SelectionChangeCommitted
        RecalcularPreciosLista()
    End Sub

    Private Sub hacerNvaFxCF()
        dtproductos.Rows.Clear()
        CalcularTotales()
        paneltareas.Enabled = True
        tmrcontrolarnumfact.Enabled = True
        dtproductos.AllowUserToAddRows = True
        dtpedidosfact.AllowUserToAddRows = True
        cmdguardar.Enabled = True
        cmdimprimir.Enabled = False
        cmdremito.Enabled = False
        panelencabeza.Enabled = False
        panelcliente.Enabled = False
        dtproductos.Enabled = True
        txtcodPLU.Focus()
    End Sub
    Private Sub Button1_Click_2(sender As Object, e As EventArgs)
        hacerNvaFxCF()
    End Sub

End Class