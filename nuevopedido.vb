Public Class nuevopedido
    Dim fechagral As String = Format(Now, "dd-MM-yyyy")
    Public idFactura As Integer
    Public modificar As Boolean
    Public Rehacer As Boolean
    Public tipoFac As Integer = 995
    Public ptovta As Integer = DatosAcceso.IdPtoVtaDef
    Public ImportaAPP As Boolean = False

    Private Sub dtproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEndEdit
        Try
            SendKeys.Send("{UP}")
            SendKeys.Send("{TAB}")
            Reconectar()
            If e.ColumnIndex = 1 Then
                'If InStr(dtproductos.Rows(e.RowIndex).Cells(0).Value, "&") Then
                'CargarORRep(e.RowIndex)
                'Else
                If dtproductos.Rows(e.RowIndex).Cells(1).Value <> 0 Then
                    cargarProdCod(e.RowIndex)
                End If
                'End If
                CalcularTotales()
                'calcularEnvases()

            ElseIf e.ColumnIndex = 2 Then
                'If InStr(dtproductos.Rows(e.RowIndex).Cells(0).Value, "&") = 0 And InStr(dtproductos.Rows(e.RowIndex).Cells(0).Value, "0") = 0 Then
                'If ObtenerStock(dtproductos.CurrentRow.Cells(0).Value) < dtproductos.CurrentCell.Value Then
                'MsgBox("Stock insuficiente")
                'dtproductos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                'Exit Sub
                'End If
                'End If
                Dim pUnit As Double = dtproductos.Rows(e.RowIndex).Cells(5).Value
                Dim cant As Double = dtproductos.Rows(e.RowIndex).Cells(2).Value
                dtproductos.Rows(e.RowIndex).Cells(6).Value = Math.Round(pUnit * cant, 2)
                dtproductos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow

                CalcularTotales()
                ' calcularEnvases()
            ElseIf e.ColumnIndex = 3 Then
                If InStr(dtproductos.Rows(e.RowIndex).Cells(0).Value, "&") = 0 Then
                    selprod.busqueda = dtproductos.CurrentCell.Value()
                    selprod.fila = dtproductos.CurrentCellAddress.Y
                    selprod.LLAMA = "nuevopedido"
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
                dtproductos.Rows(fila).Cells(3).Value = "TRABAJO SEGUN ORDEN NUM: " & CompletarCeros(numOR, 2)
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
            Dim ganancia As Double

            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT precio, ganancia, iva, moneda FROM fact_insumos where id=" & codProd, conexionPrinc)
            Dim tablaprod As New DataTable
            Dim filasProd() As DataRow
            consulta.Fill(tablaprod)
            filasProd = tablaprod.Select("")

            'cargamos listas de precios
            Dim consultalis As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT utilidad FROM fact_listas_precio where id=" & cmblistas.SelectedValue, conexionPrinc)
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
            Dim lista As Double = (FormatNumber(filaslistas(0)(0)) + 100) / 100
            'Dim InteresLista As Double = (FormatNumber(filasProd(0)(0)) + 100) / 100

            Dim PrecioSinIva As Double
            Dim PrecioVenta As Double

            PrecioSinIva = precioCosto * cotizacion * utilidad * lista
            PrecioVenta = PrecioSinIva * iva

            'Select Case tipoFac
            '    Case 9
            Return Math.Round(PrecioVenta, 2)
            '    Case Else
            '        Return Math.Round(PrecioSinIva, 2)
            'End Select
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
                'MsgBox(i)
                If tipoFac = 3 And cmbtipocontr.SelectedValue = 1 Then
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
                End If
                subtotal += FormatNumber(dtproductos.Rows(i).Cells(6).Value)
            Next

            txtsubtotal.Text = Math.Round(subtotal, 2)
            txttotal.Text = subtotal + iva105 + iva21
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarDatosGrales()
        Try
            Reconectar()
            'cargamos listas
            Dim tablalistas As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_listas_precio", conexionPrinc)
            Dim readlis As New DataSet
            tablalistas.Fill(readlis)
            cmblistas.DataSource = readlis.Tables(0)
            cmblistas.DisplayMember = readlis.Tables(0).Columns(1).Caption.ToString
            cmblistas.ValueMember = readlis.Tables(0).Columns(0).Caption.ToString
            cmblistas.SelectedIndex = -1

            Reconectar()
            Dim tablaivat As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_ivatipo", conexionPrinc)
            Dim readivat As New DataSet
            tablaivat.Fill(readivat)
            cmbtipocontr.DataSource = readivat.Tables(0)
            cmbtipocontr.DisplayMember = readivat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbtipocontr.ValueMember = readivat.Tables(0).Columns(0).Caption.ToString
            cmbtipocontr.SelectedIndex = -1

            Reconectar()
            Dim tablaconvtta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_condventas", conexionPrinc)
            Dim readconvta As New DataSet
            tablaconvtta.Fill(readconvta)
            cmbcondvta.DataSource = readconvta.Tables(0)
            cmbcondvta.DisplayMember = readconvta.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcondvta.ValueMember = readconvta.Tables(0).Columns(0).Caption.ToString
            cmbcondvta.SelectedIndex = -1

            Reconectar()
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
            & " cl.iva_tipo, cl.cuit, cl.lista_precios from fact_clientes as cl,  cm_localidad as lc where lc.id=cl.dir_localidad and  idclientes = " & txtctaclie.Text, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            If tipoFac = 1 And infocl(0)(3) = 1 Then
                MsgBox("El tipo de factura seleccionado no correponde al tipo de contribuyente")
                txtrazon.Focus()
                Exit Sub
            ElseIf tipoFac = 3 And infocl(0)(3) <> 1 Then
                MsgBox("El tipo de factura seleccionado no correponde al tipo de contribuyente")
                txtrazon.Focus()
                Exit Sub
            End If
            txtrazon.Text = infocl(0)(0)
            txtdomicilio.Text = infocl(0)(1)
            txtciudad.Text = infocl(0)(2)
            cmbtipocontr.SelectedValue = infocl(0)(3)
            txtcuit.Text = infocl(0)(4)
            cmblistas.SelectedValue = infocl(0)(5)
        Catch ex As Exception
        End Try
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
        If modificar = True Or Rehacer = True Then
            cmdguardar.Enabled = True
            dtproductos.ReadOnly = False
            cmdimprimir.Enabled = True
            paneltareas.Enabled = True
            cmbvendedor.Enabled = False
            tmrcontrolarnumfact.Enabled = False
            CargarPedido()
            CalcularTotales()
            'calcularEnvases()
        Else
            dtproductos.ReadOnly = True
            tipoFac = 995
            panelcliente.Enabled = True

        End If
        'panelcliente.Enabled = False

    End Sub

    Private Sub CargarPedido()
        Try
            If modificar = True Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
                & "id_cliente,tipofact,lpad(ptovta,4,'0'),lpad(num_fact,8,'0'), fecha, condvta, vendedor,observaciones2, observaciones from fact_facturas where id=" & idFactura, conexionPrinc)
                Dim tablacl As New DataTable
                Dim infocl() As DataRow
                consulta.Fill(tablacl)
                infocl = tablacl.Select("")
                txtctaclie.Text = infocl(0)(0)
                cargarCliente()
                tipoFac = 995
                txtptovta.Text = infocl(0)(2)
                txtnufac.Text = infocl(0)(3)
                fechagral = infocl(0)(4).ToString
                lblfecha.Text = Format(CDate(fechagral), "dd-MMMM-yyyy")
                cmbcondvta.SelectedValue = infocl(0)(5)
                cmbvendedor.SelectedValue = infocl(0)(6)
                If infocl(0)(8) <> "PENDIENTE" And infocl(0)(8) <> "FACTURADO" Then
                    txtobservaciones.Text = infocl(0)(7) & vbNewLine & infocl(0)(8)
                Else
                    txtobservaciones.Text = infocl(0)(7)
                End If

                Reconectar()

                    If Val(infocl(0)(3)) = 0 Then
                        ImportaAPP = True

                        tmrcontrolarnumfact.Enabled = True
                        Dim idAPP = infocl(0)(7)

                    Dim consulta2 As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cod, plu, cantidad, descripcion, format(iva,2,'es_AR'),format(punit,2,'es_AR'), format(ptotal,2,'es_AR',id FROM fact_items  " _
               & " where codint=" & idAPP, conexionPrinc)
                    Dim tablaprod As New DataTable
                        Dim filasProd() As DataRow
                        consulta2.Fill(tablaprod)
                        filasProd = tablaprod.Select("")
                        panelencabeza.Enabled = False
                        dtproductos.Rows.Clear()
                        For i = 0 To filasProd.GetUpperBound(0)
                            dtproductos.Rows.Add(filasProd(i)(0), filasProd(i)(1), filasProd(i)(2), filasProd(i)(3), filasProd(i)(4), filasProd(i)(5), filasProd(i)(6), filasProd(i)(7))
                        Next
                    Else
                    Dim consulta2 As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cod, plu, cantidad, descripcion, format(iva,2,'es_AR'),format(punit,2,'es_AR'), format(ptotal,2,'es_AR'), id FROM fact_items  " _
                & " where id_fact=" & idFactura, conexionPrinc)
                    Dim tablaprod As New DataTable
                        Dim filasProd() As DataRow
                        consulta2.Fill(tablaprod)
                        filasProd = tablaprod.Select("")
                        panelencabeza.Enabled = False
                        dtproductos.Rows.Clear()
                        For i = 0 To filasProd.GetUpperBound(0)
                            dtproductos.Rows.Add(filasProd(i)(0), filasProd(i)(1), filasProd(i)(2), filasProd(i)(3), filasProd(i)(4), filasProd(i)(5), filasProd(i)(6), filasProd(i)(7))
                        Next
                    End If



                ElseIf Rehacer = True Then
                    Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
                    & "id_cliente,tipofact,lpad(ptovta,4,'0'),lpad(num_fact,8,'0'), fecha, condvta, vendedor from fact_facturas where id=" & idFactura, conexionPrinc)
                    Dim tablacl As New DataTable
                    Dim infocl() As DataRow
                    consulta.Fill(tablacl)
                    infocl = tablacl.Select("")
                    txtctaclie.Text = infocl(0)(0)
                    cargarCliente()
                tipoFac = 995
                'txtptovta.SelectedText = infocl(0)(2)
                'txtnufac.Text = infocl(0)(3)
                tmrcontrolarnumfact.Enabled = True
                    lblfecha.Text = Format(CDate(fechagral), "dd-MMMM-yyyy")
                    cmbcondvta.SelectedValue = infocl(0)(5)
                    cmbvendedor.SelectedValue = infocl(0)(6)

                    Reconectar()
                Dim consulta2 As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cod, codint, cantidad, descripcion, format(iva,2,'es_AR'), format(punit,2,'es_AR'), format(ptotal,2,'es_AR'),id FROM fact_items  " _
                    & " where id_fact=" & idFactura, conexionPrinc)
                Dim tablaprod As New DataTable
                    Dim filasProd() As DataRow
                    consulta2.Fill(tablaprod)
                    filasProd = tablaprod.Select("")
                    panelencabeza.Enabled = False

                    dtproductos.Rows.Clear()
                For i = 0 To filasProd.GetUpperBound(0)
                    dtproductos.Rows.Add(filasProd(i)(0), filasProd(i)(1), filasProd(i)(2), filasProd(i)(3), filasProd(i)(4), filasProd(i)(5), filasProd(i)(6), filasProd(i)(7))
                Next
                'tmrcontrolarnumfact.Enabled = True
                End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarNumComprobante()
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select confnume from tipos_comprobantes where donfdesc=" & tipoFac & " and ptovta=" & ptovta
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            txtnufac.Text = CompletarCeros(FormatNumber(lector("confnume").ToString) + 1, 1)
            ' cmbtipofac.Enabled = False
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
            selclie.llama = "nuevopedido"
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
        Dim num_fact As Integer
        tmrcontrolarnumfact.Enabled = False
        If cmbvendedor.SelectedValue = 0 Then
            MsgBox("Seleccione vendedor")
            Exit Sub
        End If
        If txtctaclie.Text = "" Or Not IsNumeric(txtctaclie.Text) Then
            MsgBox("El cliente debe estar agregado a la base de datos, por favor agregue el cliente desde el modulo ´clientes´")
            Exit Sub

        End If

        Try
            Dim tipoFact As Integer = 995
            num_fact = CType(txtnufac.Text, Integer)
            If modificar = False Then
                Dim ptovta As String = txtptovta.Text

                Dim fecha As String = Format(CDate(fechagral), "yyyy-MM-dd")
                Dim idcliente As String = txtctaclie.Text
                Dim razon As String = txtrazon.Text
                Dim direccion As String = txtdomicilio.Text
                Dim localidad As String = txtciudad.Text
                Dim tipocontr As String = cmbtipocontr.Text
                Dim cuit As String = txtcuit.Text
                Dim condvta As Integer = cmbcondvta.SelectedValue
                Dim subtotal As String = txtsubtotal.Text
                Dim iva105 As String = txtiva105.Text
                Dim iva21 As String = txtiva21.Text
                Dim total As String = txttotal.Text
                Dim vendedor As Integer = cmbvendedor.SelectedValue
                Dim observaciones As String = txtobservaciones.Text.ToUpper

                Dim sqlQuery As String

                If RestringirNumerosFact(tipoFact, num_fact, ptovta) = True Then
                    MsgBox("El numero de comprobante ya existe para este tipo, por favor verifique")
                    Exit Sub
                End If
                Reconectar()
                sqlQuery = "insert into fact_facturas  " _
                    & "(tipofact,ptovta, num_fact,fecha,id_cliente,razon,direccion,localidad,tipocontr,cuit,condvta,subtotal,iva105,iva21,total,vendedor,observaciones,observaciones2) values " _
                    & "(?tipofact, ?ptov,?nfac,?fech,?idclie,?razon,?dire,?loca,?tipocont,?cuit,?condvta,?subt,?105,?21,?tot,?vend,'PENDIENTE',?observa)"

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
                    .AddWithValue("?subt", subtotal)
                    .AddWithValue("?105", iva105)
                    .AddWithValue("?21", iva21)
                    .AddWithValue("?tot", total)
                    .AddWithValue("?vend", vendedor)
                    .AddWithValue("?observa", observaciones)
                End With
                comandoadd.ExecuteNonQuery()
                idFactura = comandoadd.LastInsertedId
            End If

            If modificar = False Or ImportaAPP = True Then
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "update fact_conffiscal set confnume=" & Val(num_fact) & " where donfdesc= " & tipoFac & " and ptovta=" & DatosAcceso.IdPtoVtaDef
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            
            Dim cod As String
            Dim cantidad As String
            Dim descripcion As String
            Dim iva As String
            Dim punit As String
            Dim ptotal As String
            Dim codbar As String
            Dim codint As String
            'Dim num_fact As String

            Dim sqlQuery As String
            Dim i As Integer
            'num_fact = idfactura
            If Val(num_fact) = 0 Then
                MsgBox("No se pueden guardar los items de la factura")
                Exit Sub
            End If
            If modificar = True Then
                Reconectar()
                sqlQuery = "DELETE FROM  fact_items where id_fact=" & idFactura
                Dim comandodelitm As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                comandodelitm.ExecuteNonQuery()



                Reconectar()
                sqlQuery = "update fact_facturas set ptovta= '" & Val(txtptovta.Text) & "', num_fact='" & Val(txtnufac.Text) &
                "', razon='" & txtrazon.Text.ToUpper & "', direccion= '" & txtdomicilio.Text & "', localidad='" & txtciudad.Text &
                "', tipocontr= '" & cmbtipocontr.Text & "', cuit= '" & txtcuit.Text & "', subtotal='" & txtsubtotal.Text &
                "', total='" & txttotal.Text & "', observaciones= 'PENDIENTE', observaciones2='" & txtobservaciones.Text & "' where id=" & idFactura

                Dim comandoUpdped As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                    comandoUpdped.ExecuteNonQuery()
                End If

            For i = 0 To dtproductos.RowCount - 2
                cod = dtproductos.Rows(i).Cells(0).Value
                codbar = dtproductos.Rows(i).Cells(1).Value
                cantidad = dtproductos.Rows(i).Cells(2).Value
                descripcion = dtproductos.Rows(i).Cells(3).Value.ToString.ToUpper
                iva = dtproductos.Rows(i).Cells(4).Value
                punit = dtproductos.Rows(i).Cells(5).Value
                ptotal = dtproductos.Rows(i).Cells(6).Value
                codint = dtproductos.Rows(i).Cells(1).Value

                If cod Is Nothing Then
                    cod = 0
                End If

                sqlQuery = "insert into fact_items " _
                & "(cod,codint,cantidad, descripcion, iva, punit, ptotal, tipofact,ptovta,num_fact,plu,id_fact) values" _
                & "(?cod,?codint, ?cant,?desc,?iva,?punit,?ptot,?tipofact,?ptovta,?num_fact,?plu,?id_fact)"

                Reconectar()
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters
                    .AddWithValue("?cod", cod)
                    .AddWithValue("?cant", cantidad)
                    .AddWithValue("?desc", descripcion)
                    .AddWithValue("?iva", iva)
                    .AddWithValue("?punit", punit)
                    .AddWithValue("?ptot", ptotal)
                    .AddWithValue("?tipofact", tipoFac)
                    .AddWithValue("?ptovta", Val(txtptovta.Text))
                    .AddWithValue("?num_fact", num_fact)
                    .AddWithValue("?id_fact", idFactura)
                    .AddWithValue("?codint", codint)
                    .AddWithValue("?plu", codint)
                End With
                comandoadd.ExecuteNonQuery()

            Next




            MsgBox("Pedido guardado satisfactoriamente")
            panelencabeza.Enabled = False
            panelcliente.Enabled = False
            dtproductos.Enabled = False
            cmdguardar.Enabled = False
            cmdimprimir.Enabled = True
        Catch ex As Exception
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
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo," _
            & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum,fac.fecha as facfech,concat(fac.id_cliente,'-',fac.razon) as facrazon," _
            & "concat(fac.direccion, ' - ', fac.localidad)  as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit,fac.vendedor as facvend, " _
            & "fac.condvta as faccondvta, fac.iva105, fac.iva21,fac.observaciones2 as facobserva " _
            & "FROM fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac where emp.id=1 and fis.donfdesc=fac.tipofact and fac.id=" & idFactura, conexionPrinc)

            tabEmp.Fill(fac.Tables("factura_enca"))
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "cantidad as cant, descripcion,iva,punit,ptotal from fact_items where " _
            & "id_fact=" & idFactura, conexionPrinc)
            tabFac.Fill(fac.Tables("facturax"))

            'If InStrRev(DatosAcceso.Moduloacc, "AR01") <> 0 Then
            '    Dim tabenv As New MySql.Data.MySqlClient.MySqlDataAdapter
            '    tabenv.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " &
            '    "tipo_envase,cantidad from ariel_envases where idpedido=" & idFactura, conexionPrinc)
            '    tabenv.Fill(fac.Tables("envases"))
            'End If


            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\pedido.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("facturax")))
                'If InStrRev(DatosAcceso.Moduloacc, "AR01") <> 0 Then
                '    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("envases", fac.Tables("envases")))
                'End If
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

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtproductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub tmrcontrolarnumfact_Tick(sender As Object, e As EventArgs) Handles tmrcontrolarnumfact.Tick
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select confnume from fact_conffiscal where donfdesc=" & tipoFac & " and ptovta=" & ptovta
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            'MsgBox(FormatNumber(lector("confnume").ToString))
            txtnufac.Text = CompletarCeros(FormatNumber(lector("confnume").ToString) + 1, 1)
            txtptovta.Text = CompletarCeros(ptovta, 2)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub nuevopedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellContentClick

    End Sub
End Class