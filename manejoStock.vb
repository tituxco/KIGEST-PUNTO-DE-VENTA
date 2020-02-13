Imports System.ComponentModel

Public Class manejoStock
    Dim LimMin As Integer = 0
    Dim LimMax As Integer = 0
    Dim constante As Integer
    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        constante = CInt(txtlimitmax.Text)
        LimMin = 0
        LimMax = constante
        txtlimitmax.Text = constante
        lblmostrando.Text = "Mostrando 0 a"
        'ConsultarVentas.RunWorkerAsync()
        ConsultarVtasMes(LimMin, LimMax)
    End Sub
    Private Sub ConsultarVtasMes(ByRef limitmin, ByRef limitmax)
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
            Dim desde As String = Format(CDate(dtdesdefact.Value), "yyyy-MM-dd")
            Dim hasta As String = Format(CDate(dthastafact.Value), "yyyy-MM-dd")
            Dim catprod As String
            Dim proveed As String
            Dim buscnomb As String

            If cmbalmacen.SelectedIndex = -1 Or cmbalmacen.SelectedValue = 0 Then
                MsgBox("Debe seleccionar un almacen")
                EnProgreso.Close()
                Exit Sub
            End If

            If cmbcatProd.SelectedIndex = -1 And cmbproveedor.SelectedIndex = -1 And txtbuscar.Text = "BUSCAR NOMBRE DE PRODUCTO #CODIGO" Then
                If MsgBox("esta seguro que no desea poner filtros a la busqueda? puede causar cuelgue de sistema...", vbYesNo, vbQuestion) = MsgBoxResult.No Then
                    EnProgreso.Close()
                    Exit Sub
                End If
            End If

            If cmbcatProd.SelectedIndex = -1 Or cmbcatProd.SelectedValue = 0 Then
                catprod = " pro.categoria like '%' "
            Else
                catprod = "pro.categoria in (" & cmbcatProd.SelectedValue & ") "
            End If

            If cmbproveedor.SelectedIndex = -1 Or cmbproveedor.SelectedValue = 0 Then
                proveed = " pro.codprov like '%' "
            Else
                proveed = " pro.codprov in (" & cmbproveedor.SelectedValue & ") "
            End If

            If txtbuscar.Text <> "BUSCAR NOMBRE DE PRODUCTO #CODIGO" And InStr(txtbuscar.Text, "#") = 0 Then
                buscnomb = " pro.descripcion like '%" & Replace(txtbuscar.Text, " ", "%") & "%' " 'or pro.cod_bar like '" & txtbuscar.Text & "' "

            ElseIf txtbuscar.Text <> "BUSCAR NOMBRE DE PRODUCTO #CODIGO" And InStr(txtbuscar.Text, "#") <> 0 Then
                buscnomb = " pro.id = " & Replace(txtbuscar.Text, "#", "")
            Else
                buscnomb = " pro.descripcion like '%' "
            End If


            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT fi.cod as CodInterno, pro.descripcion, sum(fi.cantidad) as ventasPeriodo,
            (select sum(stock) from fact_insumos_lotes where idproducto=pro.id and idalmacen=" & cmbalmacen.SelectedValue & ") as StockActualEnAlmacen
            FROM fact_items as fi, fact_facturas as fa , fact_insumos as pro
            where fa.id=fi.id_fact and fi.cod=pro.id and fa.fecha between '" & desde & "' and '" & hasta & "'
            and " & catprod & " and " & proveed & " and " & buscnomb & " 
            group by fi.cod limit " & LimMin & "," & LimMax, conexionPrinc)
            'MsgBox(consulta.SelectCommand.CommandText)
            Dim tablaprod As New DataTable

            consulta.Fill(tablaprod)
            dtproductos.DataSource = tablaprod
            dtproductos.Columns(0).Width = 100
            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LimMin = LimMax
        LimMax += constante
        txtlimitmax.Text = LimMax
        ConsultarVtasMes(LimMin, LimMax)
        lblmostrando.Text = "Mostrando " & LimMin & " a "
    End Sub
    Private Sub cargarCategoriasProd()

        Reconectar()
        conexionPrinc.ChangeDatabase(database)

        'cargamos categorias
        Dim tablacatprod As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_categoria_insum order by nombre asc", conexionPrinc)
        Dim readcat As New DataSet
        Dim readcat2 As New DataSet
        tablacatprod.Fill(readcat)
        'tablacatprod.Fill(readcat2)
        cmbcatProd.DataSource = readcat.Tables(0)
        cmbcatProd.DisplayMember = readcat.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbcatProd.ValueMember = readcat.Tables(0).Columns(0).Caption.ToString
        cmbcatProd.SelectedIndex = -1
    End Sub
    Private Sub cargarProveedores()
        Dim tablaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, razon from fact_proveedores", conexionPrinc)
        Dim readprov As New DataSet
        tablaprov.Fill(readprov)
        cmbproveedor.DataSource = readprov.Tables(0)
        cmbproveedor.DisplayMember = readprov.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbproveedor.ValueMember = readprov.Tables(0).Columns(0).Caption.ToString
        cmbproveedor.SelectedIndex = -1
    End Sub

    Private Sub cargarAlmacenes()
        Dim tablaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_insumos_almacenes", conexionPrinc)
        Dim readprov As New DataSet
        tablaprov.Fill(readprov)
        cmbalmacen.DataSource = readprov.Tables(0)
        cmbalmacen.DisplayMember = readprov.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbalmacen.ValueMember = readprov.Tables(0).Columns(0).Caption.ToString
        cmbalmacen.SelectedIndex = 0
    End Sub
    Private Sub manejoStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarCategoriasProd()
        cargarProveedores()
        cargarAlmacenes()
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtbuscar_LostFocus(sender As Object, e As EventArgs) Handles txtbuscar.LostFocus
        If txtbuscar.Text = "" Then
            txtbuscar.Text = "BUSCAR NOMBRE DE PRODUCTO #CODIGO"
        End If
    End Sub

    Private Sub txtbuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                ConsultarVtasMes(LimMin, LimMax)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbuscar_GotFocus(sender As Object, e As EventArgs) Handles txtbuscar.GotFocus
        txtbuscar.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        romaneo.idcomprobante = 0
        romaneo.Show()
        'romaneo.TopMost = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        addProductosLote.idcomprobante = 0
        addProductosLote.Show()
        'addProductosLote.TopMost = True
    End Sub
End Class