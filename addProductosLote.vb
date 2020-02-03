Public Class addProductosLote
    Public Shared idcomprobante As Integer = 0
    Dim cerrada As Boolean = False

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

    Private Sub romaneo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarAlmacenes()
        cargarProveedores()
        cargarCategoriasProd()
        'dtproductos.Columns(4).DefaultCellStyle.NullValue = My.Settings.ivaDef
        chkcalcularcosto.CheckState = My.Settings.calcCosto

        If idcomprobante <> 0 Then
            CargarFactCompra()
        Else
            cmbalmacen.SelectedValue = DatosAcceso.IdAlmacen
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
                cargarProdPLU(txtcodPLU.Text)
            End If
            ' CalcularTotales()
            txtcodPLU.Text = ""
            txtcantPLU.Text = 1
            txtcodPLU.Focus()
        End If
    End Sub
    Public Sub cargarProdPLU(ByRef codigo As String)
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
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,codigo,iva,descripcion,precio FROM fact_insumos " & Busq, conexionPrinc)
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

        If contarprod <> 0 Then
            dtproductos.Rows(encuentraprod).Cells(2).Value += 1

        Else
            dtproductos.Rows.Add(filasProd(0)(0), filasProd(0)(1), txtcantPLU.Text, filasProd(0)(3), filasProd(0)(2),
                                    filasProd(0)(4), FormatNumber(txtcantPLU.Text) * filasProd(0)(4))
        End If
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
            End If
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
                        .AddWithValue("?idalmacen", DatosAcceso.IdAlmacen)
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
                ' actualizar precios
                Me.Close()

            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GuardarProductos()
        Try
            Dim codbar As String
            Dim descripcion As String
            Dim iva As String
            Dim precio As String
            Dim ganancia As String = 1
            Dim codprov As Integer = cmbproveedor.SelectedValue
            Dim moneda As Integer = My.Settings.monedaDef
            Dim categoria As Integer = cmbcatprod.SelectedValue

            For Each producto As DataGridViewRow In dtproductos.Rows

                codbar = producto.Cells(1).Value.ToString.ToUpper
                descripcion = producto.Cells(3).Value.ToString.ToUpper
                precio = producto.Cells(5).Value
                iva = producto.Cells(4).Value

                'MsgBox(producto.Cells(3).Value)


                If ExisteProducto(codbar) = False Then
                    'MsgBox("Producto no existe se agregara")

                    Dim sqlQuery = "insert into fact_insumos (cod_bar,codigo,descripcion,precio,iva,codprov,categoria,moneda,tipo,calcular_precio,unidades,presentacion
                    ) values (
                    ?codbar,?codbar,?descripcion,?precio,?iva,?codprov,?categoria,?moneda,'0','1','1','1')"

                    Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                    With comandoadd.Parameters
                        .AddWithValue("?codbar", codbar)
                        .AddWithValue("?descripcion", descripcion)
                        .AddWithValue("?precio", precio)
                        .AddWithValue("?iva", iva)
                        .AddWithValue("?codprov", codprov)
                        .AddWithValue("?categoria", categoria)
                        .AddWithValue("?moneda", moneda)
                    End With
                    comandoadd.ExecuteNonQuery()
                    Dim idProd As Integer = comandoadd.LastInsertedId
                    producto.Cells(0).Value = idProd
                Else
                    'MsgBox("Producto existe, no se agrega")
                    producto.Cells(0).Value = IdProducto(codbar)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

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
            GuardarProductos()
            GuardarLoteCompra()
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
End Class