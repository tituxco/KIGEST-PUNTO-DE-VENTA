Imports System.Security

Public Class nuevaventaleg
    Dim fechagral As String = Format(Now, "dd-MM-yyyy")
    Dim idFactura As Integer
    Dim fa As Boolean

    Private Sub dtproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEndEdit
        Try
            SendKeys.Send("{UP}")
            SendKeys.Send("{TAB}")
            Reconectar()
            If e.ColumnIndex = 1 Then
                If dtproductos.Rows(e.RowIndex).Cells(1).Value <> 0 Then
                    cargarProdCod(e.RowIndex)
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
                    selprod.busqueda = dtproductos.CurrentCell.Value()
                    selprod.fila = dtproductos.CurrentCellAddress.Y
                    selprod.LLAMA = "nuevaventaleg"
                    selprod.dtproductos.Focus()
                    selprod.Show()
                    selprod.TopMost = True
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
                Dim consultaorden As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT tall.mo_monto, tall.estado, tall.trab_estado, (select count(tcn.id) from tecni_taller_insumos as tcn where tcn.idtaller=tall.id) as insumos from tecni_taller as tall where tall.id=" & numOR, conexionPrinc)
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
                dtproductos.Rows(fila).Cells(3).Value = "TRABAJO SEGUN ORDEN NUM: " & numOR
                dtproductos.Rows(fila).Cells(4).Value = "21"
                dtproductos.Rows(fila).Cells(5).Value = infoorden(0)(0)
                dtproductos.Rows(fila).Cells(6).Value = infoorden(0)(0)
                If infoorden(0)(3) <> 0 Then
                    Dim consultaprodorden As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT codigo, cantidad, descripcion, iva, punit, ptotal from tecni_taller_insumos where idtaller=" & numOR, conexionPrinc)
                    Dim tablaprodorden As New DataTable
                    Dim infoprodorden() As DataRow
                    consultaprodorden.Fill(tablaprodorden)
                    infoprodorden = tablaprodorden.Select("")
                    For i = 0 To infoprodorden.GetUpperBound(0)
                        dtproductos.Rows.Add(infoprodorden(i)(0), infoprodorden(i)(1), infoprodorden(i)(2), infoprodorden(i)(3), infoprodorden(i)(4), infoprodorden(i)(5))
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
        ElseIf Val(codPLU <> 0) Then

            Busq = "where id=" & codPLU & " or codigo like '" & codPLU & "'"

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
    Private Function calcularPrecio(ByRef codProd As String) As Double
        Try
            Dim ganancia As String
            Select Case cmblistaprecio.Text
                Case "LISTA1"
                    ganancia = "ganancia"
                Case "LISTA2"
                    ganancia = "utilidad1"
                Case "LISTA3"
                    ganancia = "utilidad2"
                Case Else
                    ganancia = "ganancia"
            End Select
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT precio, iva, moneda FROM fact_insumos where id=" & codProd, conexionPrinc)
            Dim tablaprod As New DataTable
            Dim filasProd() As DataRow
            consulta.Fill(tablaprod)
            'dtproductos.DataSource = tablaprod
            '        dtproductos.Rows.Clear()
            filasProd = tablaprod.Select("")

            'cargamos la moneda perteneciente a este producto
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select (select cotizacion from fact_moneda  where  id =" & filasProd(0)(2) & ") as cotiza, (select valor from fact_configuraciones where  id =1) as lista"
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            Dim cotizacion As Double = FormatNumber(lector("cotiza").ToString)
            'Dim coeflista As Double = (FormatNumber(lector("lista").ToString) + 100) / 100


            Dim precioCosto As Double = FormatNumber(filasProd(0)(0))

            Dim iva As Double = (FormatNumber(filasProd(0)(1)) + 100) / 100
            Dim utilidad As Double = 1
            'Dim InteresLista As Double = (FormatNumber(filasProd(0)(0)) + 100) / 100

            Dim PrecioSinIva As Double
            Dim PrecioVenta As Double

            PrecioSinIva = precioCosto * cotizacion * utilidad
            PrecioVenta = PrecioSinIva * iva

            If cmbtipocontr.SelectedValue = 1 And cmbtipofac.SelectedValue = 3 Then
                Return Math.Round(PrecioSinIva, 2)
            Else
                Return Math.Round(PrecioVenta, 2)
            End If
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
                        Case 4, 7, 13, 5, 6, 8, 9, 14, 15
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
                    End Select
                End If
                subtotal += FormatNumber(dtproductos.Rows(i).Cells(6).Value)

                'If cmbtipofac.SelectedValue = 3 And cmbtipocontr.SelectedValue = 1 Or cmbtipofac.SelectedValue = 4 And cmbtipocontr.SelectedValue = 1 Or cmbtipofac.SelectedValue = 8 And cmbtipocontr.SelectedValue = 1 Then
                '    If dtproductos.Rows(i).Cells(4).Value = "10,5" Then
                '        subtotal105 += FormatNumber(dtproductos.Rows(i).Cells(6).Value)
                '        'subtotal += FormatNumber(dtproductos.Rows(i).Cells(5).Value)
                '    ElseIf dtproductos.Rows(i).Cells(4).Value = "21" Then
                '        subtotal21 += FormatNumber(dtproductos.Rows(i).Cells(6).Value)

                '    Else
                '        Exit Sub
                '    End If
                '    iva105 = Math.Round(subtotal105 * (10.5 / 100), 2)
                '    iva21 = Math.Round(subtotal21 * (21 / 100), 2)
                '    txtiva105.Text = iva105
                '    txtiva21.Text = iva21
                'End If
                'subtotal += FormatNumber(dtproductos.Rows(i).Cells(6).Value)
            Next

            txtsubtotal.Text = Math.Round(subtotal, 2)
            txttotal.Text = subtotal + iva105 + iva21
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarDatosGrales()
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
            cmbvendedor.SelectedIndex = -1
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
            & " cl.iva_tipo, cl.cuit from fact_clientes as cl,  cm_localidad as lc where lc.id=cl.dir_localidad and  idclientes = " & txtctaclie.Text, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            If infocl(0)(3) <> 1 Then
                Select Case cmbtipofac.SelectedValue
                    Case 4 To 6, 7 To 9, 13 To 15
                        MsgBox("El tipo de factura seleccionado no correponde al tipo de contribuyente")
                        txtrazon.Focus()
                        Exit Sub
                End Select
            ElseIf infocl(0)(3) = 1 Then
                Select Case cmbtipofac.SelectedValue
                    Case 1 To 3, 10 To 12, 16 To 18
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
        Catch ex As Exception
        End Try
    End Sub

    Private Sub nuevaventa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

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
            End If
        End If
    End Sub
    Private Sub nuevaventa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatosGrales()
        lblfecha.Text = "Fecha: " & fechagral
        panelcliente.Enabled = False
        dtproductos.ReadOnly = True
    End Sub

    Private Sub cmbtipofac_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbtipofac.SelectionChangeCommitted
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select confnume from fact_conffiscal where id=" & cmbtipofac.SelectedValue
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            txtnufac.Text = CompletarCeros(FormatNumber(lector("confnume").ToString) + 1, 1)
            cmbtipofac.Enabled = False
            txtptovta.Enabled = False
            panelcliente.Enabled = True
            tmrcontrolarnumfact.Enabled = True
            Select Case cmbtipofac.SelectedValue
                Case 4, 5, 6
                    fa = True
            End Select
            If txtptovta.Text = 3 Then
                cmbsolicitarcae.Enabled = True
                cmdguardar.Enabled = False
            Else
                cmbsolicitarcae.Enabled = False
                cmdguardar.Enabled = True
            End If
            
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
            selclie.llama = "nuevaventaleg"
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

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        'Dim idfactura As Integer
        tmrcontrolarnumfact.Enabled = False
        Dim num_fact As Integer
        If cmbvendedor.SelectedValue = 0 Then
            MsgBox("Seleccione vendedor")
            Exit Sub
        End If

        Try
            
            If RestringirNumerosFact(cmbtipofac.SelectedValue, num_fact) = True Then
                MsgBox("El numero de comprobante ya existe para este tipo, por favor verifique")
                Exit Sub
            End If

            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_conffiscal set confnume=" & Val(num_fact) & " where id= " & cmbtipofac.SelectedValue
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            cmdguardar.Enabled = False
            cmdimprimir.Enabled = True
            cmdremito.Enabled = True

        Catch ex As Exception
            tmrcontrolarnumfact.Enabled = True
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdimprimir_Click(sender As Object, e As EventArgs) Handles cmdimprimir.Click
        Try
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas
            Reconectar()
            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, " _
            & "emp.drei as empdrei, emp.logo as emplogo from  fact_empresa as emp" _
            & "", conexionPrinc)
            Dim tablemp As New DataTable
            Dim infoemp() As DataRow
            tabEmp.Fill(tablemp)
            infoemp = tablemp.Select("")



            Dim tablaEncaempresa As New DataTable
            tablaEncaempresa.TableName = "encabezado"
            tablaEncaempresa.Columns.Add("empnombre")
            tablaEncaempresa.Columns.Add("emprazon")
            tablaEncaempresa.Columns.Add("empdire")
            tablaEncaempresa.Columns.Add("emploca")
            tablaEncaempresa.Columns.Add("empcuit")
            tablaEncaempresa.Columns.Add("empib")
            tablaEncaempresa.Columns.Add("empcontr")
            tablaEncaempresa.Columns.Add("empinicioact")
            tablaEncaempresa.Columns.Add("empdrei")
            tablaEncaempresa.Columns.Add("emplogo")
            tablaEncaempresa.Columns.Add("facnum")
            tablaEncaempresa.Columns.Add("facfech")
            tablaEncaempresa.Columns.Add("facrazon")
            tablaEncaempresa.Columns.Add("facdire")
            tablaEncaempresa.Columns.Add("facloca")
            tablaEncaempresa.Columns.Add("factipocontr")
            tablaEncaempresa.Columns.Add("faccuit")
            tablaEncaempresa.Columns.Add("facvend")
            tablaEncaempresa.Columns.Add("faccondvta")
            tablaEncaempresa.Columns.Add("facobserva")
            tablaEncaempresa.Columns.Add("iva105")
            tablaEncaempresa.Columns.Add("iva21")
            tablaEncaempresa.Columns.Add("total")
            tablaEncaempresa.Columns.Add("efectivo")
            tablaEncaempresa.Columns.Add("descfact")
            tablaEncaempresa.Columns.Add("cae")
            tablaEncaempresa.Columns.Add("facletra")
            tablaEncaempresa.Columns.Add("faccodigo")
            tablaEncaempresa.Columns.Add("vtocae")
            tablaEncaempresa.Columns("iva105").DataType = GetType(Double)
            tablaEncaempresa.Columns("iva21").DataType = GetType(Double)
            tablaEncaempresa.Columns("total").DataType = GetType(Double)
            tablaEncaempresa.Columns("efectivo").DataType = GetType(Double)
            'tablaEncaempresa.Columns("emplogo").DataType = GetType(System.Byte())

            Dim datosempresa As DataRow = tablaEncaempresa.NewRow
            datosempresa("empnombre") = infoemp(0)(0)
            datosempresa("emprazon") = infoemp(0)(1)
            datosempresa("empdire") = infoemp(0)(2)
            datosempresa("emploca") = infoemp(0)(3)
            datosempresa("empcuit") = infoemp(0)(4)
            datosempresa("empib") = infoemp(0)(5)
            datosempresa("empcontr") = infoemp(0)(6)
            datosempresa("empdrei") = infoemp(0)(7)
            datosempresa("emplogo") = infoemp(0)(8)
            datosempresa("facnum") = cmbtipofac.Text & " " & txtptovta.Text.PadLeft(4, "0") & "-" & Val(txtnufac.Text).ToString.PadLeft(8, "0")
            datosempresa("facfech") = fechagral
            datosempresa("facrazon") = txtrazon.Text
            datosempresa("facdire") = txtdomicilio.Text
            datosempresa("facloca") = txtciudad.Text
            datosempresa("factipocontr") = cmbtipocontr.Text
            datosempresa("faccuit") = txtcuit.Text
            datosempresa("facvend") = cmbvendedor.Text
            datosempresa("faccondvta") = cmbcondvta.Text
            datosempresa("facobserva") = txtobservaciones.Text
            datosempresa("iva105") = txtiva105.Text
            datosempresa("iva21") = txtiva21.Text
            datosempresa("total") = txttotal.Text
            datosempresa("efectivo") = txttotal.Text
            datosempresa("descfact") = ""
            datosempresa("cae") = lblestadoCAE.Text

            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT letra, codfiscal from fact_conffiscal where id= " & cmbtipofac.SelectedValue, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            'txtrazon.Text = infocl(0)(0)

            datosempresa("facletra") = infocl(0)(0)
            datosempresa("faccodigo") = infocl(0)(1)
            datosempresa("vtocae") = lblvtoCAE.Text

            tablaEncaempresa.Rows.Add(datosempresa)

            Reconectar()

            Dim tablaItem As New DataTable
            tablaItem.Columns.Add("cant")
            tablaItem.Columns.Add("descripcion")
            tablaItem.Columns.Add("iva")
            tablaItem.Columns.Add("punit")
            tablaItem.Columns.Add("ptotal")
            tablaItem.Columns.Add("codigo")
            tablaItem.Columns("iva").DataType = GetType(Double)
            tablaItem.Columns("punit").DataType = GetType(Double)
            tablaItem.Columns("ptotal").DataType = GetType(Double)

            Dim i As Integer
            For i = 0 To dtproductos.RowCount - 2
                Dim filaitem As DataRow = tablaItem.NewRow
                filaitem("cant") = dtproductos.Rows(i).Cells(2).Value
                filaitem("descripcion") = dtproductos.Rows(i).Cells(3).Value
                filaitem("iva") = dtproductos.Rows(i).Cells(4).Value
                filaitem("punit") = dtproductos.Rows(i).Cells(5).Value
                filaitem("ptotal") = dtproductos.Rows(i).Cells(6).Value
                filaitem("codigo") = dtproductos.Rows(i).Cells(0).Value
                tablaItem.Rows.Add(filaitem)
            Next



            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                Select Case txtptovta.Text
                    Case 1
                        Select Case cmbtipofac.SelectedValue
                            Case 1, 4
                                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\facturaleg.rdlc"
                            Case 23 To 26
                                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\facturax.rdlc"
                            Case 7, 13, 10, 16
                                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\notacredleg.rdlc"
                        End Select
                    Case 2
                    Case 3
                        .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\facturaelectro.rdlc"
                End Select

                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", tablaEncaempresa))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", tablaItem))
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()

                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

            If e.ColumnIndex = 1 Then
                Dim consultapedido As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
                & "id from fact_facturas where observaciones like 'PENDIENTE' AND ptovta=1 and num_fact=" & dtpedidosfact.CurrentCell.Value & " and tipofact=9", conexionPrinc)
                Dim tablaped As New DataTable
                Dim infoped() As DataRow
                consultapedido.Fill(tablaped)
                infoped = tablaped.Select("")
                dtpedidosfact.CurrentRow.Cells(0).Value = infoped(0)(0)


                Dim consultapedidoitems As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cod,codint, cantidad, descripcion, iva, punit, ptotal from fact_items where id_fact=" & dtpedidosfact.CurrentRow.Cells(0).Value, conexionPrinc)
                Dim tablaitm As New DataTable
                Dim infoitm() As DataRow
                consultapedidoitems.Fill(tablaitm)
                infoitm = tablaitm.Select("")
                For i = 0 To infoitm.GetUpperBound(0)
                    dtproductos.Rows.Add(infoitm(i)(0), infoitm(i)(1), infoitm(i)(2), infoitm(i)(3), infoitm(i)(4), infoitm(i)(5), infoitm(i)(6))
                Next
                CalcularTotales()
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
            sql.CommandText = "select confnume from fact_conffiscal where id=" & cmbtipofac.SelectedValue
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
        Dim num_fact As Integer = ObtenerNumerosFact(tipoFact)
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
            If RestringirNumerosFact(tipoFact, num_fact) = True Then
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
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\remito.rdlc"
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

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellContentClick

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles cmbsolicitarcae.Click
        Dim fe As New WSAFIPFE.Factura
        Dim nContador As Integer
        Dim nNumero As Integer
        Dim lresultado As Boolean

        Dim cbtetipo As Integer
        Dim doctipo As Integer
        Dim contribtipo As Integer
        Dim idiva As Integer
        Select Case cmbtipofac.SelectedValue
            Case 3
                cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaB
            Case 6
                cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaA
            Case 9
                cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoA
            Case 12
                cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoB
            Case 15
                cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoA
            Case 18
                cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoB
            Case Else
                MsgBox("tipo de comprobante no admitido")
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
                contribtipo = WSAFIPFE.Factura.TipoReponsable.ConsumidorFinal
                doctipo = WSAFIPFE.Factura.TipoDocumento.SinIdentificacionGlobalDiario
                txtcuit.Text = 0
                idiva = 3
            Case 6
                contribtipo = WSAFIPFE.Factura.TipoReponsable.Monotributo
                doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                idiva = 3
            Case Else
                MsgBox("Tipo de contribuyente no admitido")
                Exit Sub
        End Select


        lresultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, "30714086398", Application.StartupPath & "\certificadoIgpFirmado.pfx", Application.StartupPath & "\licencia.lic")
        fe.ArchivoCertificadoPassword = "Abel8383"
        If lresultado Then
            lresultado = fe.f1ObtenerTicketAcceso()

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

            fe.F1DetalleIvaItemCantidad = 1
            fe.f1IndiceItem = 0
            fe.F1DetalleIvaId = idiva
            fe.F1DetalleIvaBaseImp = txtsubtotal.Text
            fe.F1DetalleIvaImporte = txtiva21.Text

            fe.F1DetalleImpTotal = txttotal.Text
            fe.F1DetalleImpTotalConc = 0
            fe.F1DetalleImpNeto = txtsubtotal.Text
            fe.F1DetalleImpIva = txtiva21.Text

            lresultado = fe.F1CAESolicitar()

            If lresultado Then
                If fe.F1RespuestaResultado = "R" Then
                    MsgBox("Solicitud rechazada " & fe.UltimoMensajeError & " - " & fe.UltimoNumeroError)
                    lblobservacionescae.Text = "Resultado: " & fe.F1RespuestaResultado & vbNewLine
                    lblobservacionescae.Text &= "Observaciones: " & fe.F1RespuestaDetalleObservacionMsg1 & fe.F1RespuestaDetalleObservacionMsg
                    Exit Sub
                End If
                lblestadoCAE.Text = "CAE: " & fe.F1RespuestaDetalleCae
                lblvtoCAE.Text = "Vto: " & fe.F1RespuestaDetalleCAEFchVto
                lblobservacionescae.Text = "Resultado: " & fe.F1RespuestaResultado & vbNewLine
                lblobservacionescae.Text &= "Observaciones: " & fe.F1RespuestaDetalleObservacionMsg1

                cmdguardar.Enabled = True
                cmbsolicitarcae.Enabled = False
            Else
                lblobservacionescae.Text = "error: " & fe.F1RespuestaDetalleObservacionMsg & fe.UltimoMensajeError & vbNewLine
                lblobservacionescae.Text &= "Ultimo otorgado: " & fe.F1CompUltimoAutorizado(Val(txtptovta.Text), cbtetipo)
                cmdguardar.Enabled = False
            End If
        End If

    End Sub

    Private Sub txtptovta_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtptovta.SelectedValueChanged
        Try
            Dim tablaftipo As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, abrev from fact_conffiscal where leg=1 and ptovta=" & txtptovta.Text & " and tip=1", conexionPrinc)
            Dim readftipo As New DataSet
            tablaftipo.Fill(readftipo)
            cmbtipofac.DataSource = readftipo.Tables(0)
            cmbtipofac.DisplayMember = readftipo.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbtipofac.ValueMember = readftipo.Tables(0).Columns(0).Caption.ToString
            cmbtipofac.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtrazon_TextChanged(sender As Object, e As EventArgs) Handles txtrazon.TextChanged

    End Sub

    Private Sub cmbtipofac_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtipofac.SelectedIndexChanged

    End Sub
End Class