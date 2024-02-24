Public Class romaneo
    Public Shared idcomprobante As Integer = 0
    Dim cerrada As Boolean = False
    Dim i As Integer
    Dim cargaManual As Boolean = False

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
    End Sub


    Private Sub cargarAlmacenes()
        Reconectar()
        Dim tablaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_insumos_almacenes", conexionPrinc)
        Dim readprov As New DataSet
        Dim readprov2 As new DataSet
        tablaprov.Fill(readprov)
        tablaprov.Fill(readprov2)
        cmbalmacen.DataSource = readprov.Tables(0)
        cmbalmacen.DisplayMember = readprov.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbalmacen.ValueMember = readprov.Tables(0).Columns(0).Caption.ToString
        cmbalmacen.SelectedValue = My.Settings.idAlmacen



        cmbAlmacenHacia.DataSource = readprov2.Tables(0)
        cmbAlmacenHacia.DisplayMember = readprov2.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbAlmacenHacia.ValueMember = readprov2.Tables(0).Columns(0).Caption.ToString
        cmbAlmacenHacia.SelectedIndex = -1
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
        'MsgBox(idfila)
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
        Dim utilidadAux As String = 1
        'Select Case AuxCol
        '    Case 0
        '        utilidadAux = tablaprod(0)(5)
        '    Case 1
        '        utilidadAux = tablaprod(0)(6)
        '    Case 2
        '        utilidadAux = tablaprod(0)(7)
        '    Case Else
        '        utilidadAux = tablaprod(0)(5)

        'End Select
        If contarprod <> 0 And idfila = -1 Then
            dtproductos.Rows(encuentraprod).Cells(2).Value += 1
        ElseIf contarprod <> 0 And idfila <> -1 Then

            If cargaManual = True Then
                'MsgBox(" manual 11")
                dtproductos.Rows(idfila).Cells(0).Value = filasProd(0)("id")
                dtproductos.Rows(idfila).Cells(1).Value = filasProd(0)("codigo")
                dtproductos.Rows(idfila).Cells(2).Value = txtcantPLU.Text
                dtproductos.Rows(idfila).Cells(3).Value = filasProd(0)("descripcion")
                dtproductos.Rows(idfila).Cells(4).Value = filasProd(0)("iva")
                dtproductos.Rows(idfila).Cells(5).Value = FormatNumber(filasProd(0)("precio"), 2)
                dtproductos.Rows(idfila).Cells(6).Value = utilidadAux
                dtproductos.Rows(idfila).Cells(7).Value = 0
                cargaManual = False
            Else
                'MsgBox(" normal 11")
                dtproductos.CurrentRow.Cells(0).Value = filasProd(0)("id")
                dtproductos.CurrentRow.Cells(1).Value = filasProd(0)("codigo")
                dtproductos.CurrentRow.Cells(2).Value = txtcantPLU.Text
                dtproductos.CurrentRow.Cells(3).Value = filasProd(0)("descripcion")
                dtproductos.CurrentRow.Cells(4).Value = filasProd(0)("iva")
                dtproductos.CurrentRow.Cells(5).Value = FormatNumber(filasProd(0)("precio"), 2)
                dtproductos.CurrentRow.Cells(6).Value = utilidadAux
                dtproductos.CurrentRow.Cells(7).Value = 0
                cargaManual = False
            End If


            'dtproductos.Rows.Add(filasProd(0)(0), codigo, txtcantPLU.Text, filasProd(0)(3), filasProd(0)(2),
            'filasProd(0)(4), utilidadAux, 0)
        Else contarprod = 0 And idfila <> -1
            ' MsgBox("resp 22")
            dtproductos.Rows.Add(filasProd(0)("id"), filasProd(0)("codigo"), txtcantPLU.Text, filasProd(0)("descripcion"), filasProd(0)("iva"),
                                    filasProd(0)("precio"), utilidadAux, 0)
        End If

    End Sub


    Private Sub dtgtia_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
        Try
            For Each producto As DataGridViewRow In dtproductos.Rows
                If producto.IsNewRow Then
                    Exit For
                End If
                QuitarStock(producto.Cells("plu").Value, producto.Cells("cant").Value, 0)
            Next
            Reconectar()
            Dim sqlQuery As String
            sqlQuery = "insert into fact_proveedores_fact " _
                            & "(fecha, tipo,numero,idproveedor) values " _
                            & "('" & Format(Now(), "yyyy-MM-dd") & "', " & "'INT'" & ", 'TR-INTERNA','0')"
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteNonQuery()

            idcomprobante = comandoadd.LastInsertedId
            Reconectar()

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
        Dim lotstock As String
        Dim lotidprod As String
        Dim lotfact As Integer
        Dim lotcompracant As String
        Dim lottipoprod As Integer
        Dim sqlQuery As String

        Try
            'If MsgBox("Esta seguro que desea grabar este lote de productos? no podra agregar productos despues", vbYesNo + vbQuestion, "Carga de lote") = vbYes Then
            For Each loteprod As DataGridViewRow In dtproductos.Rows
                If loteprod.IsNewRow Then
                    Exit For
                End If
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
            MsgBox("Transferencia de stock realizada")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()

    End Sub

    Private Sub txtcomprobanteFcompra_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    Private Sub txtcomprobanteFvencimiento_KeyPress(sender As Object, e As KeyPressEventArgs)
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

    Private Sub dtproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
        Dim costo As String
        Dim precio As String = dtproductos.Item(5, e.RowIndex).Value
        Dim iva As String = dtproductos.Item(4, e.RowIndex).Value
        Try
            If e.ColumnIndex = 1 Then
                If dtproductos.CurrentCell.Value <> "" Then
                    'MsgBox(dtproductos.CurrentCell.Value)
                    cargarProdPLU(dtproductos.CurrentCell.Value, e.ColumnIndex)
                End If
            ElseIf e.ColumnIndex = 3 Then
                If chkBusquedaProd.Checked = True Then
                    'If dtproductos.CurrentRow.Cells(1).Value = "" Then
                    selprod.busqueda = dtproductos.CurrentCell.Value()
                    selprod.fila = dtproductos.CurrentCellAddress.Y
                    'MsgBox(dtproductos.CurrentCellAddress.Y)
                    selprod.LLAMA = "romaneo"
                    cargaManual = True
                    selprod.Show()
                    selprod.TopMost = True
                    'End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcodPLU_TextChanged(sender As Object, e As EventArgs) Handles txtcodPLU.TextChanged

    End Sub

    Private Sub txtcodPLU_QueryContinueDrag(sender As Object, e As QueryContinueDragEventArgs) Handles txtcodPLU.QueryContinueDrag

    End Sub

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellContentClick

    End Sub
End Class