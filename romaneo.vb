Public Class romaneo
    Public Shared idcomprobante As Integer = 0
    Dim cerrada As Boolean = False
    Dim i As Integer

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
        If idcomprobante <> 0 Then
            CargarFactCompra()
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
            txtcomprobanteObservaciones.Text = infocl(0)(6).ToString

            'lblproveedor.Text = "Proveedor: " & infocl(0)(0)
            'lblcomprobante.Text = "Comprobante: NUM " & infocl(0)(1) & "      FECHA " & infocl(0)(2).ToString & "       MONTO: " & infocl(0)(3)
            If infocl(0)(5) = 1 Then
                'MsgBox("ya se cargaron los productos de esta factura, no se puede agregar mas")
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
                dtgtia.Enabled = False
                pnguardar.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub cargarInfoProveedor()
        
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
            dtproductos.Rows.Add(filasProd(0)(0), filasProd(0)(1), txtcantPLU.Text, filasProd(0)(3), filasProd(0)(2), _
                                    filasProd(0)(4), FormatNumber(txtcantPLU.Text) * filasProd(0)(4))
        End If
    End Sub


    Private Sub dtgtia_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgtia.CellEndEdit
        Dim contarprod As Integer = 0
        Dim contarserie As Integer = 0
        Dim encuentraserie As Integer
        Dim encuentraprod As Integer

        If e.ColumnIndex = 1 Then
            If dtproductos.Rows.Count = 0 Then
                cargarProdPLU(dtgtia.Rows(e.RowIndex).Cells(1).Value.ToString)
                SendKeys.Send("{UP}")
                SendKeys.Send("{TAB}")
            Else
                For Each fila As DataGridViewRow In dtproductos.Rows
                    ' MsgBox(fila.Cells(1).Value & "-" & dtgtia.Rows(e.RowIndex).Cells(0).Value)
                    If fila.Cells(1).Value = dtgtia.Rows(e.RowIndex).Cells(1).Value Then
                        contarprod += 1
                        encuentraprod = fila.Index
                    End If
                Next
                If contarprod <> 0 Then
                    dtproductos.Rows(encuentraprod).Cells(2).Value += 1
                    SendKeys.Send("{UP}")
                    SendKeys.Send("{TAB}")
                Else
                    cargarProdPLU(dtgtia.Rows(e.RowIndex).Cells(1).Value)
                    SendKeys.Send("{UP}")
                    SendKeys.Send("{TAB}")
                End If
            End If
        ElseIf e.ColumnIndex = 2 Then
            For Each fila2 As DataGridViewRow In dtgtia.Rows
                ' MsgBox(fila2.Cells(1).Value & "-" & dtgtia.CurrentCell.Value)
                If fila2.Cells(2).Value = dtgtia.CurrentCell.Value Then
                    encuentraserie += 1
                End If
            Next
            If encuentraserie > 1 Then
                MsgBox("Serie encontrado")
                dtgtia.CurrentCell.Value = ""
                SendKeys.Send("{UP}")
            Else
                SendKeys.Send("{UP}")
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub dtgtia_KeyDown(sender As Object, e As KeyEventArgs) Handles dtgtia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dtproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtproductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dtgtia_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgtia.RowsAdded
        dtgtia.Rows(e.RowIndex).Cells(3).Value = 6

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Try

            Dim sqlQuery As String


            Dim fecha As String
            Dim tipo As String
            Dim numero As String
            Dim monto As String
            Dim vencimiento As String
            Dim observaciones As String
            Dim idProveedor As Integer
            'For i = 0 To dtcomprobantes.RowCount - 2

            'If Val(dtcomprobantes.Rows(i).Cells(0).Value) = 0 Then
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
                .AddWithValue("?idp", Idproveedor)
            End With
            comandoadd.ExecuteNonQuery()

            Dim idcomp As Integer = comandoadd.LastInsertedId
            Reconectar()

            sqlQuery = "insert into fact_cuentaprov " _
                        & "(idprov,idcomp) values " _
                        & "(?prov, ?comp)"
            Dim comandoaddcta As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)

            With comandoaddcta.Parameters
                .AddWithValue("?prov", Idproveedor)
                .AddWithValue("?comp", idcomp)

            End With
            comandoaddcta.ExecuteNonQuery()

            MsgBox("Factura ingresada cargada correctamente")

            idcomprobante = comandoadd.LastInsertedId
            'CargarFactCompra()
            GuardarLoteCompra()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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
            If MsgBox("Esta seguro que desea grabar este lote de productos? no podra agregar productos despues", vbYesNo + vbQuestion, "Carga de lote") = vbYes Then
                dtgtia.AllowUserToAddRows = False
                dtproductos.AllowUserToAddRows = False
                For Each gtiaprod As DataGridViewRow In dtgtia.Rows
                    Reconectar()
                    gtiaidprod = gtiaprod.Cells(0).Value
                    gtiacodigo = gtiaprod.Cells(1).Value
                    gtiaserie = gtiaprod.Cells(2).Value
                    gtiameses = gtiaprod.Cells(3).Value
                    gtiacompcompra = idcomprobante

                    sqlQuery = "insert into fact_gtia (idproducto,codigo,serie,mesesgtia,comcompra) values (?idprod,?codigo,?serie,?mesesgtia,?compcompra)"
                    Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                    With comandoadd.Parameters
                        .AddWithValue("?idprod", gtiaidprod)
                        .AddWithValue("?codigo", gtiacodigo)
                        .AddWithValue("?serie", gtiaserie)
                        .AddWithValue("?mesesgtia", gtiameses)
                        .AddWithValue("?compcompra", gtiacompcompra)
                    End With
                    comandoadd.ExecuteNonQuery()
                Next

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
                dtgtia.ReadOnly = True
                dtproductos.ReadOnly = True
                cmdguardar.Enabled = False
                pnadd.Enabled = False
                MsgBox("Lote guardado")
                ' actualizar precios
                If chkactualizarprecios.CheckState = CheckState.Checked Then
                    For Each actualizaprod As DataGridViewRow In dtproductos.Rows
                        Dim costo As Double = actualizaprod.Cells(5).Value
                        Dim iva As Double = actualizaprod.Cells(4).Value
                        Reconectar()
                        Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos set precio='" & costo & "' " _
                        & "where id = " & actualizaprod.Cells(0).Value, conexionPrinc)
                        comandoupd.ExecuteNonQuery()
                    Next
                    MsgBox("Se actualizo la lista de precios")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
            'For i = 0 To dtcomprobantes.RowCount - 2

            'If Val(dtcomprobantes.Rows(i).Cells(0).Value) = 0 Then
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

            MsgBox("Factura ingresada cargada correctamente")

            idcomprobante = comandoadd.LastInsertedId
            'CargarFactCompra()
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

    Private Sub txtcodPLU_TextChanged(sender As Object, e As EventArgs) Handles txtcodPLU.TextChanged

    End Sub

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellContentClick

    End Sub
End Class