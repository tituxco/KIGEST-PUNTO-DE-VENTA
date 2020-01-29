Public Class manejodeprecios

    Dim modificaProd As Boolean
        Dim imprimirlist As Boolean
        Dim imprimiretiq As Boolean
        Dim elimColumn As Boolean

    Private Function busqCod(ByRef busq As String) As String
        Try
            If InStr(busq, "#") = 1 Then
                Return Microsoft.VisualBasic.Right(busq, busq.Length - 1)
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function busqNomb(ByRef busq As String) As String
        Try
            If InStr(busq, "#") = 0 And busq <> "BUSCAR NOMBRE DE PRODUCTO #CODIGO" Then
                Return busq
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub cargarProductos(ByRef codigo As String, ByRef nombre As String, ByRef categoria As String, ByRef proveedor As String)
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
            conexionPrinc.ChangeDatabase(database)
            Dim busqtxt As String

            Dim cadenaComp As String

            Dim busqCat As String
            Dim busqProv As String
            Dim busqCod As String
            Dim busqNomb As String
            Dim busqStock As String

            Dim separador() As String = {"-", " "}
            Dim buscStr = nombre.Split(separador, StringSplitOptions.None)
            Dim i As Integer

            Dim BusquedaComp As String

            BusquedaComp = Replace(nombre, " ", "%")
            busqtxt = " pro.descripcion like '%" & BusquedaComp & "%' or pro.codigo like '" & nombre & "'"

            If nombre = "" Then
                busqNomb = "where pro.eliminado=0 and  pro.descripcion like '%' "
            Else
                busqNomb = "where pro.eliminado=0 and  " & busqtxt
            End If

            If categoria = "" Then
                busqCat = " pro.categoria like '%'"
            Else
                busqCat = " pro.categoria like '" & categoria & "'"
            End If

            If proveedor = "" Then
                busqProv = " pro.codprov like '%'"
            Else
                busqProv = " pro.codprov like '" & proveedor & "'"
            End If

            If codigo <> "" And Val(codigo) <> 0 Then
                busqCod = " and  pro.id=" & codigo
            End If

            cadenaComp = busqNomb & " And " & busqCat & " And " & busqProv & busqStock & busqCod

            If imprimirlist = False And imprimiretiq = False Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT pro.id as CodInterno, pro.descripcion as Descripcion, pro.codigo as PLU, 
            pro.precio as costosiniva, pro.ganancia,pro.utilidad1,pro.utilidad2, (select sum(stock) from fact_insumos_lotes  
            where idproducto=pro.id) as Stock  from fact_insumos as pro " & cadenaComp, conexionPrinc)
                Dim tablaprod As New DataTable
                'Dim filasProd() As DataRow
                consulta.Fill(tablaprod)
                dtproductos.DataSource = tablaprod
                dtproductos.Columns(0).Width = 100
                dtproductos.Columns(0).ReadOnly = True
                dtproductos.Columns(1).ReadOnly = True
                dtproductos.Columns(2).ReadOnly = True

                dtproductos.Columns(3).Width = 100
                dtproductos.Columns(4).Width = 100
                dtproductos.Columns(5).Width = 100
                dtproductos.Columns(6).Width = 100

                dtproductos.Columns(7).Width = 100
                dtproductos.Columns(7).ReadOnly = True

            ElseIf imprimirlist = True Or imprimiretiq = True Then

                'Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
                'Dim fac As New datosfacturas
                'Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select pro.id as CodInterno, pro.descripcion, pro.codigo as PLU,
                '(select sum(stock) from fact_insumos_lotes  where idproducto=pro.id) as Stock,   
                'format(
                'replace(pro.precio,',','.') *
                '((select mon.cotizacion from fact_moneda as mon where mon.id=pro.moneda)) *
                '((pro.iva+100)/100) *
                '((pro.ganancia+100)/100)*
                '(((select listas.utilidad from fact_listas_precio as listas where listas.id=" & dtlistas.CurrentRow.Cells(3).Value & ")+100)/100),2,'es_AR') as precio
                'from fact_insumos as pro   " & cadenaComp, conexionPrinc)
                'MsgBox(consulta.SelectCommand.CommandText)
                'Dim tablaprod As New DataTable
                ''Dim filasProd() As DataRow
                'tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
                '& "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
                '& "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo " _
                '& "FROM fact_empresa as emp where emp.id=1", conexionPrinc)

                'tabEmp.Fill(fac.Tables("membreteenca"))
                'Reconectar()

                'consulta.Fill(fac.Tables("listadoproductos"))
                'Dim imprimirx As New imprimirFX
                'With imprimirx
                '    .MdiParent = Me.MdiParent
                '    .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                '    If imprimirlist = True Then
                '        .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listadoproductos.rdlc"
                '    End If
                '    If imprimiretiq = True Then
                '        .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\productosetiquetas.rdlc"
                '    End If

                '    .rptfx.LocalReport.DataSources.Clear()
                '    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("membreteenca", fac.Tables("membreteenca")))
                '    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadoproductos")))
                '    '.rptfx.LocalReport.SetParameters(parameters)
                '    .rptfx.DocumentMapCollapsed = True
                '    .rptfx.RefreshReport()
                '    .Show()
                'End With
                'imprimirlist = False
                'imprimiretiq = False

            End If

            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub

    Private Sub txtbuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue, cmbproveedor.SelectedValue)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Try
            imprimirlist = True
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue, cmbproveedor.SelectedValue)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtbuscar_LostFocus(sender As Object, e As EventArgs) Handles txtbuscar.LostFocus
        If txtbuscar.Text = "" Then
            txtbuscar.Text = "BUSCAR NOMBRE DE PRODUCTO #CODIGO"
        End If
    End Sub

    Private Sub txtbuscar_GotFocus(sender As Object, e As EventArgs) Handles txtbuscar.GotFocus
        If txtbuscar.Text = "BUSCAR NOMBRE DE PRODUCTO #CODIGO" Then
            txtbuscar.Text = ""
        End If
    End Sub
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
            cmbcatProd.DataSource = readcat.Tables(0)
            cmbcatProd.DisplayMember = readcat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcatProd.ValueMember = readcat.Tables(0).Columns(0).Caption.ToString
            cmbcatProd.SelectedIndex = -1

            cmbcatProd.DataSource = readcat2.Tables(0)
            cmbcatProd.DisplayMember = readcat2.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcatProd.ValueMember = readcat2.Tables(0).Columns(0).Caption.ToString
            cmbcatProd.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub calcularPrecios()
        Try
            Dim consultaPRod As New MySql.Data.MySqlClient.MySqlDataAdapter("select prod.precio, (select mon.cotizacion from fact_moneda as mon where mon.id=prod.moneda) as cotizacion,  " &
            "prod.iva, prod.ganancia as utilidad0, prod.utilidad1, prod.utilidad2 from fact_insumos as prod where prod.id=" & dtproductos.CurrentRow.Cells(0).Value, conexionPrinc)
            Dim tablaprod As New DataTable
            Dim infoprod() As DataRow
            consultaPRod.Fill(tablaprod)
            infoprod = tablaprod.Select("")

            Dim precioCosto As Double = FormatNumber(infoprod(0)(0))
            Dim cotizacion As Double = FormatNumber(infoprod(0)(1))
            Dim iva As Double = (FormatNumber(infoprod(0)(2)) + 100) / 100

            Dim util As Double = (FormatNumber(infoprod(0)(3)) + 100) / 100
            Dim util1 As Double = (FormatNumber(infoprod(0)(4)) + 100) / 100
            Dim util2 As Double = (FormatNumber(infoprod(0)(5)) + 100) / 100

            Dim costoUtil As Double
            Dim costoFinal As Double

            costoFinal = precioCosto * iva * cotizacion

            Dim i As Integer
            For i = 0 To dtlistas.RowCount - 1
                Dim utilidad As Double = dtlistas.Rows(i).Cells(1).Value

                If dtlistas.Rows(i).Cells(4).Value.ToString = "%" Then
                    dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad
                Else
                    Select Case dtlistas.Rows(i).Cells(5).Value
                        Case 0
                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util
                        Case 1
                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util1
                        Case 2
                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util2
                    End Select

                End If
            Next

            precioCosto = 0
            cotizacion = 0
            iva = 0
            util = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cargarListas()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select nombre, utilidad,id,auxcol from fact_listas_precio", conexionPrinc)
            Dim tablalist As New DataTable
            Dim i As Integer
            Dim infolist() As DataRow
            consulta.Fill(tablalist)

            infolist = tablalist.Select("")
            For i = 0 To infolist.GetUpperBound(0)
                If InStr(infolist(i)(1), "%") <> 0 Then
                    dtlistas.Rows.Add(infolist(i)(0), FormatNumber((Microsoft.VisualBasic.Right(infolist(i)(1), infolist(i)(1).Length - 1) + 100) / 100), "", infolist(i)(2), "%", infolist(i)(3)) 'FormatNumber(infolist(i)(1) + 100) / 100, "", infolist(i)(2))
                Else
                    dtlistas.Rows.Add(infolist(i)(0), FormatNumber((infolist(i)(1) + 100) / 100), "", infolist(i)(2), "", infolist(i)(3)) 'FormatNumber(infolist(i)(1) + 100) / 100, "", infolist(i)(2))
                End If
            Next

        Catch ex As Exception

        End Try
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

    Private Sub dtproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEnter
        calcularPrecios()
    End Sub

    Private Sub busquedaprod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarListas()
        cargarCategoriasProd()
        cargarProveedores()
    End Sub

    Private Sub cmbcatProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcatProd.SelectedIndexChanged

    End Sub

    Private Sub cmbcatProd_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcatProd.SelectionChangeCommitted
        Try
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue, cmbproveedor.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Try
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue, cmbproveedor.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cmbcatProd.SelectedIndex = -1
        cmbproveedor.SelectedIndex = -1

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Try
            imprimiretiq = True
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue, cmbproveedor.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEndEdit
        Dim idprod As Integer = dtproductos.CurrentRow.Cells(0).Value
        If e.ColumnIndex = 3 Then
            If IsNumeric(dtproductos.CurrentRow.Cells(3).Value) Then
                Dim costo As String = dtproductos.CurrentRow.Cells(3).Value
                Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos set precio='" & costo & "' where id=" & idprod, conexionPrinc)
                comandoupd.ExecuteNonQuery()
            End If
        ElseIf e.ColumnIndex = 4 Then
            If IsNumeric(dtproductos.CurrentRow.Cells(4).Value) Then
                Dim ganancia As String = dtproductos.CurrentRow.Cells(4).Value
                Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos set ganancia='" & ganancia & "' where id=" & idprod, conexionPrinc)
                comandoupd.ExecuteNonQuery()
            End If
        ElseIf e.ColumnIndex = 5 Then
            If IsNumeric(dtproductos.CurrentRow.Cells(4).Value) Then
                Dim ganancia As String = dtproductos.CurrentRow.Cells(5).Value
                Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos set utilidad1='" & ganancia & "' where id=" & idprod, conexionPrinc)
                comandoupd.ExecuteNonQuery()
            End If
        ElseIf e.ColumnIndex = 6 Then
            If IsNumeric(dtproductos.CurrentRow.Cells(4).Value) Then
                Dim ganancia As String = dtproductos.CurrentRow.Cells(6).Value
                Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos set utilidad2='" & ganancia & "' where id=" & idprod, conexionPrinc)
                comandoupd.ExecuteNonQuery()
            End If

        End If

    End Sub

    Private Sub manejodeprecios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtproductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmdAumProv_Click(sender As Object, e As EventArgs) Handles cmdAumProv.Click
        If MsgBox("Esta seguro que desea realizar esta actualizacion masiva de precios? esta acción no se puede deshacer", vbYesNoCancel + vbQuestion) = MsgBoxResult.Yes Then
            Dim ConsultaSQL As String
            If IsNumeric(txtPorcProv.Text) Then
                If cmbproveedor.SelectedValue <> 0 Then
                    Dim porcentaje As Double = (FormatNumber(txtPorcProv.Text) + 100) / 100
                    Dim codprov As Integer = cmbproveedor.SelectedValue
                    Reconectar()
                    ConsultaSQL = "update fact_insumos set precio= format(replace(precio,',','.') * " & porcentaje.ToString.Replace(",", ".") & ",2,'es_AR') where codprov=" & codprov
                    Dim consulta As New MySql.Data.MySqlClient.MySqlCommand(ConsultaSQL, conexionPrinc)
                    consulta.ExecuteNonQuery()
                    MsgBox("Precios actualizados")
                Else
                    MsgBox("Debe seleccionar un proveedor")
                    Exit Sub
                End If
            Else
                MsgBox("Debe ingresar un numero")
                Exit Sub
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub cmdAumCateg_Click(sender As Object, e As EventArgs) Handles cmdAumCateg.Click
        If MsgBox("Esta seguro que desea realizar esta actualizacion masiva de precios? esta acción no se puede deshacer", vbYesNoCancel + vbQuestion) = MsgBoxResult.Yes Then
            Dim ConsultaSQL As String
            If IsNumeric(txtPorcCateg.Text) Then
                If cmbcatProd.SelectedValue <> 0 Then
                    Dim porcentaje As Double = (FormatNumber(txtPorcCateg.Text) + 100) / 100
                    Dim categoria As Integer = cmbcatProd.SelectedValue
                    Reconectar()
                    ConsultaSQL = "update fact_insumos set precio= format(replace(precio,',','.') * " & porcentaje.ToString.Replace(",", ".") & ",2,'es_AR') where categoria=" & categoria
                    Dim consulta As New MySql.Data.MySqlClient.MySqlCommand(ConsultaSQL, conexionPrinc)
                    consulta.ExecuteNonQuery()
                    MsgBox("Precios actualizados")
                Else
                    MsgBox("Debe seleccionar un proveedor")
                    Exit Sub
                End If
            Else
                MsgBox("Debe ingresar un numero")
                Exit Sub
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub cmadAumTodos_Click(sender As Object, e As EventArgs) Handles cmadAumTodos.Click
        If MsgBox("Esta seguro que desea realizar esta actualizacion masiva de precios? esta acción no se puede deshacer", vbYesNoCancel + vbQuestion) = MsgBoxResult.Yes Then
            Dim ConsultaSQL As String
            If IsNumeric(txtPorcTodos.Text) Then
                Dim porcentaje As Double = (FormatNumber(txtPorcTodos.Text) + 100) / 100
                'MsgBox(porcentaje.ToString.Replace(",", "."))
                Reconectar()
                ConsultaSQL = "update fact_insumos set precio= format(replace(precio,',','.') * " & porcentaje.ToString.Replace(",", ".") & ",2,'es_AR')"
                Dim consulta As New MySql.Data.MySqlClient.MySqlCommand(ConsultaSQL, conexionPrinc)
                consulta.ExecuteNonQuery()
                MsgBox("Precios actualizados")
            Else
                MsgBox("Debe ingresar un numero")
                Exit Sub
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub cmdAumBusq_Click(sender As Object, e As EventArgs) Handles cmdAumBusq.Click
        If MsgBox("Esta seguro que desea realizar esta actualizacion masiva de precios? esta acción no se puede deshacer", vbYesNoCancel + vbQuestion) = MsgBoxResult.Yes Then
            Dim ConsultaSQL As String
            If IsNumeric(txtporcBusq.Text) Then
                Dim porcentaje As Double = (FormatNumber(txtporcBusq.Text) + 100) / 100
                For Each producto As DataGridViewRow In dtproductos.Rows

                    Reconectar()
                    ConsultaSQL = "update fact_insumos set precio= format(replace(precio,',','.') * " & porcentaje.ToString.Replace(",", ".") & ",2,'es_AR') 
                    where id=" & producto.Cells(0).Value
                    Dim consulta As New MySql.Data.MySqlClient.MySqlCommand(ConsultaSQL, conexionPrinc)
                    consulta.ExecuteNonQuery()
                Next
                MsgBox("Precios actualizados, realice nuevamente la busqueda para ver los cambios")
            Else
                MsgBox("Debe ingresar un numero")
                Exit Sub
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "ImportacionPrecios" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim prod As New ImportacionPrecios
        prod.MdiParent = frmprincipal
        prod.Show()
    End Sub
End Class