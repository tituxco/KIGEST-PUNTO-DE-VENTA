Public Class addProductosLote
    Public Shared idcomprobante As Integer = 0
    Dim cerrada As Boolean = False
    Dim AuxCol As Integer
    Dim UtilGral As Double


    Private Sub cargarCategoriasProd()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos categorias
            Dim tablacatprod As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_categoria_insum order by nombre asc", conexionPrinc)
            Dim readcat As New DataSet
            Dim readcat2 As New DataSet
            tablacatprod.Fill(readcat)
            tablacatprod.Fill(readcat2)
            cmbcatprod.DataSource = readcat.Tables(0)
            cmbcatprod.DisplayMember = readcat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcatprod.ValueMember = readcat.Tables(0).Columns(0).Caption.ToString
            cmbcatprod.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub romaneo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Control And e.Alt And e.KeyCode = Keys.R Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub romaneo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub
    Private Sub cargarListas()
        Reconectar()
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_listas_precio", conexionPrinc)
        Dim tablalist As New DataSet

        consulta.Fill(tablalist)
        cmblista.DataSource = tablalist.Tables(0)
        cmblista.DisplayMember = tablalist.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmblista.ValueMember = tablalist.Tables(0).Columns(0).Caption.ToString
        cmblista.SelectedValue = 1
    End Sub
    Private Sub romaneo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarAlmacenes()
        cargarProveedores()
        cargarCategoriasProd()
        cargarListas()
        'dtproductos.Columns(4).DefaultCellStyle.NullValue = My.Settings.ivaDef
        chkcalcularcosto.CheckState = My.Settings.calcCosto

        If idcomprobante <> 0 Then
            CargarFactCompra()
            For Each Cont As Control In pnDatosFact.Controls
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
        Else
            cmbalmacen.SelectedValue = My.Settings.idAlmacen
        End If
    End Sub

    Private Sub cargarProveedores()
        Reconectar()
        Dim tablaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, razon from fact_proveedores", conexionPrinc)
        Dim readprov As New DataSet
        tablaprov.Fill(readprov)
        cmbproveedor.DataSource = readprov.Tables(0)
        cmbproveedor.DisplayMember = readprov.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbproveedor.ValueMember = readprov.Tables(0).Columns(0).Caption.ToString
        cmbproveedor.SelectedIndex = -1
    End Sub

    Private Sub cargarAlmacenes()
        Reconectar()
        Dim tablaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_insumos_almacenes", conexionPrinc)
        Dim readprov As New DataSet
        tablaprov.Fill(readprov)
        cmbalmacen.DataSource = readprov.Tables(0)
        cmbalmacen.DisplayMember = readprov.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbalmacen.ValueMember = readprov.Tables(0).Columns(0).Caption.ToString
        cmbalmacen.SelectedIndex = -1
    End Sub
    Private Sub CargarFactCompra()
        Try
            Reconectar()
            ' MsgBox(idcomprobante)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT pro.id, comp.numero,comp.fecha, comp.vencimiento, comp.monto, comp.cerrado, comp.observaciones 
            from fact_proveedores as pro, fact_proveedores_fact as comp 
            where pro.id=comp.idproveedor and comp.id=" & idcomprobante, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            cmbproveedor.SelectedValue = infocl(0)(0)
            txtcomprobanteNum.Text = infocl(0)(1)
            txtcomprobanteFcompra.Text = infocl(0)(2).ToString
            txtcomprobanteFvencimiento.Text = infocl(0)(3).ToString
            txtcomprobanteImporte.Text = infocl(0)(4)
            txtcomprobanteObservaciones.Text = infocl(0)(6)
            'lblproveedor.Text = "Proveedor: " & infocl(0)(0)
            'lblcomprobante.Text = "Comprobante: NUM " & infocl(0)(1) & "      FECHA " & infocl(0)(2).ToString & "       MONTO: " & infocl(0)(3)
            If infocl(0)(5) = 1 Then
                MsgBox("ya se cargaron los productos de esta factura, no se puede agregar mas")
                cerrada = True
            End If

            Reconectar()
            If cerrada = True Then
                Dim conprod As New MySql.Data.MySqlClient.MySqlDataAdapter("" &
                "select prod.id, prod.codigo,rom.compracant,prod.descripcion, prod.iva, prod.precio, rom.idalmacen " &
                "from fact_insumos_lotes As rom, fact_insumos as prod " &
                "where prod.id=rom.idproducto And rom.idfactura =" & idcomprobante, conexionPrinc)
                Dim tablaprod As New DataTable
                'Dim infoprod() As DataRow
                conprod.Fill(tablaprod)
                'infoprod = tablaprod.Select("")
                ' MsgBox(tablaprod.Rows.Count)
                cmbalmacen.SelectedValue = tablaprod.Rows(0).Item(6)
                For i = 0 To tablaprod.Rows.Count - 1
                    dtproductos.Rows.Add(tablaprod.Rows(i).Item(0), tablaprod.Rows(i).Item(1), tablaprod.Rows(i).Item(2), tablaprod.Rows(i).Item(3), tablaprod.Rows(i).Item(4), tablaprod.Rows(i).Item(5))
                    cmbalmacen.SelectedValue = tablaprod.Rows(i).Item("idalmacen")
                Next

                dtproductos.AllowUserToAddRows = False
                dtproductos.EditMode = DataGridViewEditMode.EditProgrammatically
                dtproductos.ScrollBars = ScrollBars.Vertical
                pnadd.Enabled = False

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtcodPLU_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcodPLU.KeyUp
        If e.KeyCode = Keys.Enter Then
            If txtcodPLU.Text <> "" Then
                cargarProdPLU(txtcodPLU.Text, -1)
            End If
            ' CalcularTotales()
            txtcodPLU.Text = ""
            txtcantPLU.Text = 1
            txtcodPLU.Focus()
        End If
    End Sub
    Public Sub cargarProdPLU(ByRef codigo As String, idfila As Integer)
        Dim codPLU As String = codigo
        Dim Busq As String
        Dim contarprod As Integer = 0
        Dim encuentraprod As Integer

        If codPLU = "" Then
            MsgBox("Debe ingresar un codigo o PLU")
            'dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.Red
            Exit Sub
        End If
        If IsNumeric(codPLU) Then
            Busq = "where  id= '" & codPLU & "' or codigo Like '" & codPLU & "' or cod_bar like '" & codPLU & "'"
        ElseIf Not IsNumeric(codPLU) Then
            Busq = "where codigo Like '" & codPLU & "' or cod_bar like '" & codPLU & "'"
        End If

        Reconectar()
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,codigo,iva,descripcion,precio, ganancia, utilidad1, utilidad2 FROM fact_insumos " & Busq, conexionPrinc)
        Dim tablaprod As New DataTable
        Dim filasProd() As DataRow
        ' MsgBox(consulta.SelectCommand.CommandText)
        consulta.Fill(tablaprod)
        If tablaprod.Rows.Count = 0 Then
            lblnoplu.Text = "NO SE ENCUENTRA EL PRODUCTO " & codPLU
            Exit Sub
        Else
            lblnoplu.Text = ""
        End If

        filasProd = tablaprod.Select("")

        For Each fila As DataGridViewRow In dtproductos.Rows
            If fila.Cells(1).Value = codPLU Then
                contarprod += 1
                encuentraprod = fila.Index
            End If
        Next
        Dim utilidadAux As String
        Select Case AuxCol
            Case 0
                utilidadAux = tablaprod(0)(5)
            Case 1
                utilidadAux = tablaprod(0)(6)
            Case 2
                utilidadAux = tablaprod(0)(7)
            Case Else
                utilidadAux = tablaprod(0)(5)

        End Select
        If contarprod <> 0 And idfila = -1 Then
            dtproductos.Rows(encuentraprod).Cells(2).Value += 1
        ElseIf contarprod <> 0 And idfila <> -1 Then
            dtproductos.CurrentRow.Cells(0).Value = filasProd(0)("id")
            dtproductos.CurrentRow.Cells(1).Value = filasProd(0)("codigo")
            dtproductos.CurrentRow.Cells(2).Value = txtcantPLU.Text
            dtproductos.CurrentRow.Cells(3).Value = filasProd(0)("descripcion")
            dtproductos.CurrentRow.Cells(4).Value = filasProd(0)("iva")
            dtproductos.CurrentRow.Cells(5).Value = FormatNumber(filasProd(0)("precio"), 2)
            dtproductos.CurrentRow.Cells(6).Value = utilidadAux
            dtproductos.CurrentRow.Cells(7).Value = 0


            'dtproductos.Rows.Add(filasProd(0)(0), codigo, txtcantPLU.Text, filasProd(0)(3), filasProd(0)(2),
            'filasProd(0)(4), utilidadAux, 0)
        Else contarprod = 0 And
            dtproductos.Rows.Add(filasProd(0)("id"), filasProd(0)("codigo"), txtcantPLU.Text, filasProd(0)("descripcion"), filasProd(0)("iva"),
                                    filasProd(0)("precio"), utilidadAux, 0)
        End If

        calcularPrecios2(dtproductos.Rows.Count - 2)

    End Sub


    Private Sub dtproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEndEdit
        Dim costo As String
        Dim precio As String = dtproductos.Item(5, e.RowIndex).Value
        Dim iva As String = dtproductos.Item(4, e.RowIndex).Value
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")

        Try
            If e.ColumnIndex = 5 And chkcalcularcosto.CheckState = CheckState.Checked Then
                costo = Math.Round(FormatNumber(precio, 2) / ((FormatNumber(iva, 2) + 100) / 100), 2)
                dtproductos.CurrentCell.Value = costo
            ElseIf e.ColumnIndex = 1 Then
                If dtproductos.CurrentCell.Value <> "" Then
                    'MsgBox(dtproductos.CurrentCell.Value)
                    cargarProdPLU(dtproductos.CurrentCell.Value, e.ColumnIndex)
                End If
            End If

            calcularPrecios()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtproductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub GuardarLoteCompra()
        Dim gtiaserie As String
        Dim gtiaidprod As Integer
        Dim gtiacodigo As String
        Dim gtiameses As String
        Dim gtiacompcompra As Integer
        Dim lotstock As Integer
        Dim lotidprod As String
        Dim lotfact As Integer
        Dim lotcompracant As Integer
        Dim lottipoprod As Integer
        Dim sqlQuery As String

        Try
            'If MsgBox("Esta seguro que desea grabar este lote de productos? no podra agregar productos despues", vbYesNo + vbQuestion, "Carga de lote") = vbYes Then
            For Each loteprod As DataGridViewRow In dtproductos.Rows
                Reconectar()
                lotstock = loteprod.Cells(2).Value
                lotidprod = loteprod.Cells(0).Value
                lotfact = idcomprobante
                lotcompracant = lotstock
                lottipoprod = 1

                sqlQuery = "insert into fact_insumos_lotes (nombre,stock,idproducto,idfactura,compracant,tipo_prod,idalmacen) values " _
                    & "(?nombre,?stock,?idprod,?idfactura,?compracant,?tipoprod,?idalmacen)"
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters
                    .AddWithValue("?nombre", "-")
                    .AddWithValue("?stock", lotstock)
                    .AddWithValue("?idprod", lotidprod)
                    .AddWithValue("?idfactura", lotfact)
                    .AddWithValue("?compracant", lotcompracant)
                    .AddWithValue("?tipoprod", lottipoprod)
                    .AddWithValue("?idalmacen", cmbalmacen.SelectedValue)
                End With
                comandoadd.ExecuteNonQuery()
            Next
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_proveedores_fact set cerrado=1 where id= " & idcomprobante
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            dtproductos.ReadOnly = True

            pnadd.Enabled = False
            MsgBox("Lote guardado")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GuardarProductos() As Boolean
        Try
            Dim codbar As String
            Dim descripcion As String
            Dim iva As String
            Dim precio As String
            Dim ganancia As String = 1
            Dim codprov As Integer = cmbproveedor.SelectedValue
            Dim moneda As Integer = My.Settings.monedaDef
            Dim categoria As Integer = cmbcatprod.SelectedValue
            Dim utilprod As String

            'If categoria = 0 Then 'Or categoria = -1 Then
            '    categoria = 0
            'End If

            For Each producto As DataGridViewRow In dtproductos.Rows
                If IsNothing(producto.Cells(1).Value) Then
                    Continue For
                End If

                codbar = producto.Cells(1).Value.ToString.ToUpper
                descripcion = producto.Cells(3).Value.ToString.ToUpper
                precio = producto.Cells(5).Value
                iva = producto.Cells(4).Value
                utilprod = producto.Cells(6).Value
                'MsgBox(producto.Cells(3).Value)
                Dim util0 As String
                Dim util1 As String
                Dim util2 As String

                If IsNothing(utilprod) Then
                    utilprod = 0
                End If
                Select Case AuxCol
                    Case 0
                        util0 = utilprod
                        util1 = 0
                        util2 = 0
                    Case 1
                        util0 = 0
                        util1 = utilprod
                        util2 = 0
                    Case 2
                        util0 = 0
                        util1 = 0
                        util2 = utilprod
                    Case Else
                        util0 = 0
                        util1 = 0
                        util2 = 0
                End Select

                If ExisteProducto(codbar) = False Then
                    'MsgBox("Producto no existe se agregara")

                    Dim sqlQuery = "insert into fact_insumos (cod_bar,codigo,descripcion,precio,iva,codprov,categoria,moneda,tipo,calcular_precio,unidades,presentacion
                    ,ganancia,utilidad1,utilidad2) values (
                    ?codbar,?codbar,?descripcion,?precio,?iva,?codprov,?categoria,?moneda,'0','1','1','1',?util0,?util1,?util2)"

                    Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                    With comandoadd.Parameters
                        .AddWithValue("?codbar", codbar)
                        .AddWithValue("?descripcion", descripcion)
                        .AddWithValue("?precio", precio)
                        .AddWithValue("?iva", iva)
                        .AddWithValue("?codprov", codprov)
                        .AddWithValue("?categoria", categoria)
                        .AddWithValue("?moneda", moneda)
                        .AddWithValue("?util0", util0)
                        .AddWithValue("?util1", util1)
                        .AddWithValue("?util2", util2)
                    End With
                    comandoadd.ExecuteNonQuery()
                    Dim idProd As Integer = comandoadd.LastInsertedId
                    producto.Cells(0).Value = idProd
                Else
                    'MsgBox("Producto existe, no se agrega")
                    producto.Cells(0).Value = IdProductoObtener(codbar)
                    Dim sqlQuery = "update fact_insumos set precio=?precio, ganancia=?util0, utilidad1=?util1,utilidad2=?util2 where id=?idProducto"

                    Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                    With comandoadd.Parameters
                        .AddWithValue("?idProducto", IdProductoObtener(codbar))
                        .AddWithValue("?precio", precio)
                        .AddWithValue("?util0", util0)
                        .AddWithValue("?util1", util1)
                        .AddWithValue("?util2", util2)
                    End With
                    comandoadd.ExecuteNonQuery()
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
        Try

            Dim sqlQuery As String


            Dim fecha As String
            Dim tipo As String
            Dim numero As String
            Dim monto As String
            Dim vencimiento As String
            Dim observaciones As String
            Dim idProveedor As Integer

            If cmbcatprod.SelectedValue = 0 Or cmbcatprod.SelectedIndex = -1 Then
                MsgBox("debe seleccionar una categoria de producto para poder cargar")
                Exit Sub

            End If

            If MsgBox("Esta seguro de cargar este lote de productos?", vbYesNo, vbQuestion) = vbNo Then
                Exit Sub
            End If

            fecha = Format(CDate(txtcomprobanteFcompra.Text), "yyyy-MM-dd")
            tipo = "F"
            numero = txtcomprobanteNum.Text
            monto = txtcomprobanteImporte.Text
            observaciones = txtcomprobanteObservaciones.Text
            idProveedor = cmbproveedor.SelectedValue
            vencimiento = Format(CDate(txtcomprobanteFvencimiento.Text), "yyyy-MM-dd")
            Reconectar()

            sqlQuery = "insert into fact_proveedores_fact " _
                        & "(fecha, tipo,numero, monto,vencimiento,idproveedor,observaciones) values " _
                        & "(?fech, ?tipo, ?numero, ?monto,?venc,?idp,?observ)"
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)

            With comandoadd.Parameters
                .AddWithValue("?fech", fecha)
                .AddWithValue("?tipo", tipo)
                .AddWithValue("?numero", numero)
                .AddWithValue("?monto", monto) 'remplazarPunto(monto))
                .AddWithValue("?venc", vencimiento)
                .AddWithValue("?observ", observaciones)
                .AddWithValue("?idp", idProveedor)
            End With
            comandoadd.ExecuteNonQuery()

            Dim idcomp As Integer = comandoadd.LastInsertedId
            Reconectar()

            sqlQuery = "insert into fact_cuentaprov " _
                        & "(idprov,idcomp) values " _
                        & "(?prov, ?comp)"
            Dim comandoaddcta As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)

            With comandoaddcta.Parameters
                .AddWithValue("?prov", idProveedor)
                .AddWithValue("?comp", idcomp)

            End With
            comandoaddcta.ExecuteNonQuery()

            'MsgBox("Factura ingresada cargada correctamente")

            idcomprobante = comandoadd.LastInsertedId
            If GuardarProductos() = True Then
                GuardarLoteCompra()
                cmdaceptar.Enabled = False
            Else
                MsgBox("hubo un error al guardar los productos, el lote no se guardara")
                cmdaceptar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()

    End Sub

    Private Sub txtcomprobanteFcompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcomprobanteFcompra.KeyPress
        Dim texto As String = DirectCast(sender, TextBox).Text
        Dim longitud As Integer = texto.Length
        Dim caracter As Char = e.KeyChar
        Dim caracterAlfa As Boolean = False

        If longitud >= 10 And Char.IsControl(caracter) Then
            e.Handled = False
        ElseIf longitud >= 10 And Not Char.IsControl(caracter) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
        If Char.IsDigit(caracter) Then
            caracterAlfa = False
        ElseIf Char.IsControl(caracter) Then
            caracterAlfa = True
        Else
            If caracter = Chr(45) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
            caracterAlfa = True
        End If

        If caracterAlfa = False Then
            Select Case longitud
                Case 1
                    SendKeys.Send("-")
                Case 4
                    SendKeys.Send("-")
            End Select
        End If
    End Sub

    Private Sub txtcomprobanteFvencimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcomprobanteFvencimiento.KeyPress
        Dim texto As String = DirectCast(sender, TextBox).Text
        Dim longitud As Integer = texto.Length
        Dim caracter As Char = e.KeyChar
        Dim caracterAlfa As Boolean = False

        If longitud >= 10 And Char.IsControl(caracter) Then
            e.Handled = False
        ElseIf longitud >= 10 And Not Char.IsControl(caracter) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
        If Char.IsDigit(caracter) Then
            caracterAlfa = False
        ElseIf Char.IsControl(caracter) Then
            caracterAlfa = True
        Else
            If caracter = Chr(45) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
            caracterAlfa = True
        End If

        If caracterAlfa = False Then
            Select Case longitud
                Case 1
                    SendKeys.Send("-")
                Case 4
                    SendKeys.Send("-")
            End Select
        End If
    End Sub

    Private Sub dtproductos_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dtproductos.CellBeginEdit
        dtproductos.CurrentRow.Cells(4).Value = My.Settings.ivaDef
    End Sub

    Private Sub chkcalcularcosto_CheckedChanged(sender As Object, e As EventArgs) Handles chkcalcularcosto.CheckedChanged
        My.Settings.calcCosto = chkcalcularcosto.CheckState
        My.Settings.Save()
    End Sub

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellContentClick

    End Sub

    Private Sub cmblista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmblista.SelectedIndexChanged

    End Sub

    Private Sub cmblista_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmblista.SelectedValueChanged
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT utilidad,auxcol FROM fact_listas_precio  where id=" & cmblista.SelectedValue, conexionPrinc)
            Dim tablalist As New DataTable
            Dim filasList() As DataRow

            consulta.Fill(tablalist)
            filasList = tablalist.Select("")
            AuxCol = filasList(0)(1)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub calcularPrecios2(idFila As Integer)
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT utilidad,auxcol FROM fact_listas_precio  where id=" & cmblista.SelectedValue, conexionPrinc)
            Dim tablalist As New DataTable
            Dim filasList() As DataRow

            consulta.Fill(tablalist)
            filasList = tablalist.Select("")

            Reconectar()
            Dim consultaMoneda As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cotizacion  FROM fact_moneda  where id=" & My.Settings.monedaDef, conexionPrinc)
            Dim tablamoneda As New DataTable
            Dim filasmoneda() As DataRow

            consultaMoneda.Fill(tablamoneda)
            filasmoneda = tablamoneda.Select("")

            UtilGral = FormatNumber(filasList(0)("utilidad"), 3)
            AuxCol = filasList(0)("auxcol")
            Dim precioCosto As Double

            If dtproductos.Rows(idFila).Cells(5).Value = "" Then
                precioCosto = 0
            Else
                precioCosto = FormatNumber(dtproductos.Rows(idFila).Cells(5).Value, 2)
            End If

            Dim cotizacion As Double = FormatNumber(filasmoneda(0)("cotizacion"), 2)

            Dim iva As Double = FormatNumber(dtproductos.Rows(idFila).Cells(4).Value, 2)

            iva = (iva + 100) / 100
            Dim costoFinal As Double

            costoFinal = precioCosto * iva * cotizacion

            Dim utilprod2 As Double
            Dim utilgral2 As Double
            Dim UtilProd As Double

            If dtproductos.Rows(idFila).Cells(6).Value = "" Then
                UtilProd = 0
            Else
                UtilProd = FormatNumber(dtproductos.Rows(idFila).Cells(6).Value, 3)
            End If

            Dim utilGralSum As Double = (UtilGral + UtilProd + 100) / 100

            UtilProd = (UtilProd + 100) / 100
            utilgral2 = (UtilGral + 100) / 100
            'MsgBox("costo:" & precioCosto & " ___iva:" & iva & "cotizacion:" & cotizacion)
            'MsgBox("costo:" & precioCosto & " ___final:" & costoFinal & "utilprod:" & UtilProd & " Gral: " & utilgral2 & "-----" & utilGralSum)

            Select Case AuxCol
                Case 0
                    dtproductos.Rows(idFila).Cells(7).Value = costoFinal * utilgral2 * UtilProd
                Case 1
                    dtproductos.Rows(idFila).Cells(7).Value = costoFinal * utilgral2 * UtilProd
                Case 2
                    dtproductos.Rows(idFila).Cells(7).Value = costoFinal * utilGralSum
            End Select

        Catch ex As Exception

        End Try
    End Sub
    Private Sub calcularPrecios()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT utilidad,auxcol FROM fact_listas_precio  where id=" & cmblista.SelectedValue, conexionPrinc)
            Dim tablalist As New DataTable
            Dim filasList() As DataRow

            consulta.Fill(tablalist)
            filasList = tablalist.Select("")

            Reconectar()
            Dim consultaMoneda As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cotizacion  FROM fact_moneda  where id=" & My.Settings.monedaDef, conexionPrinc)
            Dim tablamoneda As New DataTable
            Dim filasmoneda() As DataRow

            consultaMoneda.Fill(tablamoneda)
            filasmoneda = tablamoneda.Select("")

            UtilGral = FormatNumber(filasList(0)(0), 3)
            AuxCol = filasList(0)(1)
            Dim precioCosto As Double

            If dtproductos.CurrentRow.Cells(5).Value = "" Then
                precioCosto = 0
            Else
                precioCosto = FormatNumber(dtproductos.CurrentRow.Cells(5).Value, 2)
            End If

            Dim cotizacion As Double = FormatNumber(filasmoneda(0)(0), 2)

            Dim iva As Double = FormatNumber(dtproductos.CurrentRow.Cells(4).Value, 2)

            iva = (iva + 100) / 100
            Dim costoFinal As Double

            costoFinal = precioCosto * iva * cotizacion

            Dim utilprod2 As Double
            Dim utilgral2 As Double
            Dim UtilProd As Double

            If dtproductos.CurrentRow.Cells(6).Value = "" Then
                UtilProd = 0
            Else
                UtilProd = FormatNumber(dtproductos.CurrentRow.Cells(6).Value, 3)
            End If

            Dim utilGralSum As Double = (UtilGral + UtilProd + 100) / 100

            UtilProd = (UtilProd + 100) / 100
            utilgral2 = (UtilGral + 100) / 100

            'MsgBox("costo:" & precioCosto & " ___final:" & costoFinal & "utilprod:" & UtilProd & " Gral: " & UtilGral & "-----" & utilGralSum)

            Select Case AuxCol
                Case 0
                    If My.Settings.metodoCalculo = 1 Then
                        dtproductos.CurrentRow.Cells(7).Value = costoFinal * utilgral2 * UtilProd
                    Else
                        dtproductos.CurrentRow.Cells(7).Value = costoFinal * ((utilgral2 + UtilProd) - 1)
                    End If

                Case 1
                    If My.Settings.metodoCalculo = 1 Then
                        dtproductos.CurrentRow.Cells(7).Value = costoFinal * utilgral2 * UtilProd
                    Else
                        dtproductos.CurrentRow.Cells(7).Value = costoFinal * ((utilgral2 + UtilProd) - 1)
                    End If

                Case 2
                    If My.Settings.metodoCalculo = 1 Then
                        dtproductos.CurrentRow.Cells(7).Value = costoFinal * utilgral2 * UtilProd
                    Else
                        dtproductos.CurrentRow.Cells(7).Value = costoFinal * ((utilgral2 + UtilProd) - 1)
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GenerarExcel(dtproductos)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim proximoNum As Integer = ObternerCodigoSiguiente()

        For Each fila As DataGridViewRow In dtproductos.Rows
            If fila.Cells(1).Value = proximoNum Then
                proximoNum += 1
            End If
        Next
        dtproductos.Rows.Add("", proximoNum)



    End Sub

    Private Function ObternerCodigoSiguiente() As Integer
        Try
            Dim catsel As String = ""
            If cmbcatprod.SelectedValue > 0 Then
                catsel = " where categoria =" & cmbcatprod.SelectedValue & " and length(" & My.Settings.obtCodProd & ")<7"
            Else
                catsel = "where length(" & My.Settings.obtCodProd & ")<7"
            End If
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT max(" & My.Settings.obtCodProd & ")+1 FROM fact_insumos " & catsel, conexionPrinc)
            Dim tablaprod As New DataTable
            consulta.Fill(tablaprod)
            If tablaprod.Rows.Count <> 0 Then
                Return tablaprod(0)(0)
            Else
                Dim numaleat As New Random(CInt(Date.Now.Ticks And 99999))
                Return numaleat.Next
            End If
            conexionPrinc.Close()

        Catch ex As Exception
            Return 0
        End Try

    End Function
End Class