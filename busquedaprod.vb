Imports System.Drawing.Printing

Public Class busquedaprod
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
    Private Sub cargarProductos(ByRef codigo As String, ByRef nombre As String, ByRef categoria As String)
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
            Dim cadenaComp2 As String

            Dim busqCat As String
            Dim busqCod As String
            Dim busqNomb As String
            Dim busqStock As String
            Dim busqProv As String

            Dim separador() As String = {"-", " "}
            Dim buscStr = nombre.Split(separador, StringSplitOptions.None)
            Dim i As Integer

            Dim orderBy As String = ""
            Select Case cmbOrdenarPor.SelectedIndex
                Case -1
                    orderBy = " order by pro.id asc"
                Case 0
                    orderBy = " order by pro.descripcion asc"
                Case 1
                    orderBy = " order by pro.codigo asc"
            End Select

            Dim BusquedaComp As String

            BusquedaComp = Replace(nombre, " ", "%")
            busqtxt = " pro.descripcion like '%" & BusquedaComp & "%' or cat.id= pro.categoria and pro.codigo like '" & nombre & "'"

            If nombre = "" Then
                busqNomb = " where cat.id=pro.categoria  and  pro.descripcion like '%' "
            Else
                busqNomb = " where cat.id=pro.categoria  and  " & busqtxt
            End If

            If categoria = "" Then
                busqCat = " pro.categoria like '%'"
            Else
                busqCat = " pro.categoria in (" & categoria & ")"
            End If

            If codigo <> "" And Val(codigo) <> 0 Then
                busqCod = " and  pro.id=" & codigo
            End If

            If cmbproveedor.SelectedIndex = -1 Then
                busqProv = " pro.codprov like '%'"
            Else
                busqProv = " pro.codprov = " & cmbproveedor.SelectedValue
            End If
            cadenaComp = busqNomb & " And " & busqCat & " And " & busqProv & busqCod & orderBy
            cadenaComp2 = busqNomb & " And " & busqCat & " And " & busqProv & busqCod
            'MsgBox(cadenaComp)

            If imprimirlist = False And imprimiretiq = False Then
                'MsgBox(cadenaComp)
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT pro.id as CodInterno, pro.descripcion as Descripcion, pro.codigo as PLU, " &
                "(select sum(stock) from fact_insumos_lotes  where idproducto=pro.id) as Stock from fact_insumos as pro, fact_categoria_insum as cat " & cadenaComp, conexionPrinc)
                Dim tablaprod As New DataTable
                'Dim filasProd() As DataRow
                consulta.Fill(tablaprod)

                dgvProductos.Cargar_Datos(tablaprod)
                '       dtproductos.DataSource = tablaprod


                'dtproductos.Columns(0).Width = 100
                'dtproductos.Columns(2).Width = 40
                'dtproductos.Columns(3).Width = 60
            ElseIf imprimirlist = True Or imprimiretiq = True Then

                Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
                Dim fac As New datosfacturas
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select pro.id as CodInterno, pro.descripcion, pro.codigo as PLU,
                (select sum(stock) from fact_insumos_lotes  where idproducto=pro.id) as Stock,   
                case (select position('%' in listas.utilidad) from fact_listas_precio as listas where listas.id=@idlst)
                when 0 then
                format(
						replace(pro.precio,',','.') *
						((select mon.cotizacion from fact_moneda as mon where mon.id=pro.moneda)) *
						((pro.iva+100)/100) *
                        case(select listas.auxcol from fact_listas_precio as listas where listas.id=@idlst) 
							when 0 then
								((pro.ganancia+100)/100)
							when 1 then
								((pro.utilidad1+100)/100)
							when 2 then
								((pro.utilidad2+100)/100)
                                end *
                        (((select listas.utilidad from fact_listas_precio as listas where listas.id=@idlst)+100)/100)
				,2,'es_AR')
                when 1 then
                format(
						replace(pro.precio,',','.') *
						((select mon.cotizacion from fact_moneda as mon where mon.id=pro.moneda)) *
						((pro.iva+100)/100) *						
						(((select substring(listas.utilidad from 2) from fact_listas_precio as listas where listas.id=@idlst)+100)/100)
				,2,'es_AR')
                end as precio, cat.nombre as categoria
                from fact_insumos as pro, fact_categoria_insum as cat " & cadenaComp, conexionPrinc)
                'MsgBox(consulta.SelectCommand.CommandText)
                consulta.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@idlst", MySql.Data.MySqlClient.MySqlDbType.Text))
                consulta.SelectCommand.Parameters("@idlst").Value = dtlistas.CurrentRow.Cells(3).Value
                Dim tablaprod As New DataTable

                tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
                & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
                & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo " _
                & "FROM fact_empresa as emp where emp.id=1", conexionPrinc)
                tabEmp.Fill(fac.Tables("membreteenca"))
                Reconectar()

                consulta.Fill(fac.Tables("listadoproductos"))


                Dim imprimirx As New imprimirFX
                With imprimirx
                    .MdiParent = Me.MdiParent
                    .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                    If imprimirlist = True Then
                        Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
                        'parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("lista", "LISTA: " & dtlistas.CurrentRow.Cells(0).Value.ToString))
                        Dim rptfx As Microsoft.Reporting.WinForms.ReportViewer = .rptfx
                        rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listadoproductos2.rdlc"
                        '.rptfx.LocalReport.SetParameters(parameters)
                    End If
                    If imprimiretiq = True Then
                        .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\productosetiquetas.rdlc"
                    End If

                    .rptfx.LocalReport.DataSources.Clear()
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("membreteenca", fac.Tables("membreteenca")))
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadoproductos")))

                    .rptfx.DocumentMapCollapsed = True
                    .rptfx.RefreshReport()
                    .Show()
                End With
                imprimirlist = False
                imprimiretiq = False

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
                cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            imprimirlist = True
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtbuscar_LostFocus(sender As Object, e As EventArgs) Handles txtbuscar.LostFocus
        If txtbuscar.Text = "" Then
            txtbuscar.Text = "BUSCAR NOMBRE DE PRODUCTO #CODIGO"
        End If
    End Sub

    Private Sub txtbuscar_GotFocus(sender As Object, e As EventArgs) Handles txtbuscar.GotFocus
        If chkmantenerfiltro.CheckState = CheckState.Unchecked Then txtbuscar.Text = ""
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
    Public Sub calcularPrecios(idProd As Integer)
        Try
            Dim consultaPRod As New MySql.Data.MySqlClient.MySqlDataAdapter("select prod.precio, (select mon.cotizacion from fact_moneda as mon where mon.id=prod.moneda) as cotizacion,  " &
            "prod.iva, prod.ganancia,prod.utilidad1,prod.utilidad2 from fact_insumos as prod where prod.id=" & idProd, conexionPrinc)
            Dim tablaprod As New DataTable
            Dim infoprod() As DataRow
            consultaPRod.Fill(tablaprod)
            infoprod = tablaprod.Select("")
            'MsgBox(infoprod(0)(0))
            Dim precioCosto As Double = FormatNumber(infoprod(0)(0), 4)
            Dim cotizacion As Double = FormatNumber(infoprod(0)(1), 3)
            Dim iva As Double = (FormatNumber(infoprod(0)(2)) + 100) / 100
            Dim util As Double = (FormatNumber(infoprod(0)(3)) + 100) / 100
            Dim util1 As Double = (FormatNumber(infoprod(0)(4)) + 100) / 100
            Dim util2 As Double = (FormatNumber(infoprod(0)(5)) + 100) / 100

            Dim util2sum As Double = FormatNumber(infoprod(0)(5))

            Dim costoUtil As Double
            Dim costoFinal As Double

            costoFinal = precioCosto * iva * cotizacion

            Dim i As Integer
            For i = 0 To dtlistas.RowCount - 1
                Dim utilidad As Double = dtlistas.Rows(i).Cells(1).Value
                Dim utilListSum As Double = (utilidad * 100) - 100
                Dim sumaUtil As Double = (utilListSum + util2sum + 100) / 100
                If dtlistas.Rows(i).Cells(4).Value.ToString = "%" Then
                    dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad
                Else
                    Select Case dtlistas.Rows(i).Cells(5).Value
                        Case 0
                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util
                        Case 1
                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util1
                        Case 2
                            dtlistas.Rows(i).Cells(2).Value = costoFinal * sumaUtil
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
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select nombre, format(utilidad,2,'es_AR'),id,auxcol from fact_listas_precio", conexionPrinc)
            Dim tablalist As New DataTable
            Dim i As Integer
            Dim infolist() As DataRow
            consulta.Fill(tablalist)

            infolist = tablalist.Select("")
            For i = 0 To infolist.GetUpperBound(0)
                If InStr(infolist(i)(1), "%") <> 0 Then
                    dtlistas.Rows.Add(infolist(i)(0), FormatNumber((Microsoft.VisualBasic.Right(infolist(i)(1), infolist(i)(1).Length - 1) + 100) / 100, 4), "", infolist(i)(2), "%", infolist(i)(3)) 'FormatNumber(infolist(i)(1) + 100) / 100, "", infolist(i)(2))
                Else
                    dtlistas.Rows.Add(infolist(i)(0), FormatNumber((infolist(i)(1) + 100) / 100, 4), "", infolist(i)(2), "", infolist(i)(3)) 'FormatNumber(infolist(i)(1) + 100) / 100, "", infolist(i)(2))
                End If
            Next
            dtlistas.Columns(4).Visible = False
            dtlistas.Columns(5).Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarProveedores()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos categorias
            Dim tablacatprod As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_proveedores order by razon asc", conexionPrinc)
            Dim readcat As New DataSet
            Dim readcat2 As New DataSet
            tablacatprod.Fill(readcat)
            tablacatprod.Fill(readcat2)
            cmbproveedor.DataSource = readcat.Tables(0)
            cmbproveedor.DisplayMember = readcat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbproveedor.ValueMember = readcat.Tables(0).Columns(0).Caption.ToString
            cmbproveedor.SelectedIndex = -1


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEnter
        'calcularPrecios()
    End Sub

    Private Sub busquedaprod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarListas()
        cargarProveedores()
        cargarCategoriasProd()
    End Sub


    Private Sub cmbcatProd_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcatProd.SelectionChangeCommitted
        Try
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Try
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cmbcatProd.SelectedIndex = -1

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            imprimiretiq = True
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdListasAgregar_Click(sender As Object, e As EventArgs) Handles cmdListasAgregar.Click
        dtlistasImprimir.Rows.Add(cmbcatProd.SelectedValue, cmbcatProd.Text)
    End Sub

    Private Sub cmdListasImprimir_Click(sender As Object, e As EventArgs) Handles cmdListasImprimir.Click
        If dtlistasImprimir.RowCount = 0 Then
            MsgBox("No hay ninguna lista para imprimir")
            Exit Sub
        End If
        Try
            imprimirlist = True
            Dim catprodtext As String
            For Each lista As DataGridViewRow In dtlistasImprimir.Rows
                If catprodtext = "" Then
                    catprodtext = lista.Cells(0).Value
                Else
                    catprodtext &= "," & lista.Cells(0).Value
                End If
            Next
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), catprodtext)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        dtlistasImprimir.Rows.Clear()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If dtlistasImprimir.RowCount = 0 Then
            MsgBox("No hay ninguna lista para imprimir")
            Exit Sub
        End If
        Try
            imprimiretiq = True
            Dim catprodtext As String
            For Each lista As DataGridViewRow In dtlistasImprimir.Rows
                If catprodtext = "" Then
                    catprodtext = lista.Cells(0).Value
                Else
                    catprodtext &= "," & lista.Cells(0).Value
                End If
            Next
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), catprodtext)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbproveedor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbproveedor.SelectionChangeCommitted
        Try
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ImprimirBoleta(ByVal sender As System.Object, ByVal e As PrintPageEventArgs)
        Try
            If My.Settings.TipoEtiqueta = 0 Then
                ' letra
                'Dim font1 As New Font("EAN-13", 40)
                Dim font2 As New Font("Arial", 8)
                Dim font3 As New Font("Arial", 8)
                Dim font4 As New Font("Arial", 10)
                Dim font5 As New Font("Arial", 6)

                Dim ProductoDesc As String = dgvProductos.dgvVista.CurrentRow.Cells(1).Value
                Dim ProductoCod As String = dgvProductos.dgvVista.CurrentRow.Cells(2).Value
                Dim ProductoPrec As String = Math.Round(dtlistas.CurrentRow.Cells(2).Value, 2)

                'If TextBox1.Text <> "" Then
                '    alto = Convert.ToSingle(TextBox1.Text)
                'End If
                Dim bm As Bitmap = Nothing
                bm = Codigos.codigo128(dgvProductos.dgvVista.CurrentRow.Cells(2).Value, False, 40)
                If Not IsNothing(bm) Then
                    PictureBox1.Image = bm
                End If


                ' impresion
                e.Graphics.DrawImage(PictureBox1.Image, 35, 0)
                e.Graphics.DrawString(ProductoCod, font4, Brushes.Black, 35, 43) 'codigo
                'e.Graphics.DrawString(ProEtiquetaCod, font1, Brushes.Black, 0, 0) 'CODIGO DE BARRAS
                'e.Graphics.DrawString("*" & Me.ProId.Trim & "*", font2, Brushes.Black, 50, 47) ' CODIGO NUMERICO
                e.Graphics.DrawString(ProductoDesc, font5, Brushes.Black, 10, 60) 'PRODUCTO
                'e.Graphics.DrawString("x " & ProCantEtiq, font3, Brushes.Black, 0, 70) 'CANTIDAD
                If chkimprimirprecio.CheckState = CheckState.Checked Then
                    e.Graphics.DrawString("$" & ProductoPrec, font4, Brushes.Black, 60, 70) 'PRECIO
                End If
                'e.Graphics.DrawImage(Image.FromFile(Application.StartupPath & "\logo2.jpg"), 25, 100)
                'e.Graphics.DrawString("Fecha: " & Format(Now, "dd-MM-yyy HH:mm:ss"), font5, Brushes.Black, 0, 140)
                'LlenarEtiqueta()

            ElseIf My.Settings.TipoEtiqueta = 1 Then
                    Dim font2 As New Font("Arial", 8)
                Dim font3 As New Font("Arial", 8)
                Dim font4 As New Font("Arial", 10)
                Dim font5 As New Font("Arial", 6)

                Dim ProductoDesc As String = dgvProductos.dgvVista.CurrentRow.Cells(1).Value
                Dim ProductoCod As String = dgvProductos.dgvVista.CurrentRow.Cells(2).Value
                Dim ProductoPrec As String = Math.Round(dtlistas.CurrentRow.Cells(2).Value, 2)

                'If TextBox1.Text <> "" Then
                '    alto = Convert.ToSingle(TextBox1.Text)
                'End If
                Dim bm As Bitmap = Nothing
                bm = Codigos.codigo128(dgvProductos.dgvVista.CurrentRow.Cells(2).Value, False, 40)
                If Not IsNothing(bm) Then
                    PictureBox1.Image = bm
                End If


                ' impresion
                e.Graphics.DrawImage(PictureBox1.Image, 35, 0)
                e.Graphics.DrawString(ProductoCod, font4, Brushes.Black, 35, 43) 'codigo
                'e.Graphics.DrawString(ProEtiquetaCod, font1, Brushes.Black, 0, 0) 'CODIGO DE BARRAS
                'e.Graphics.DrawString("*" & Me.ProId.Trim & "*", font2, Brushes.Black, 50, 47) ' CODIGO NUMERICO
                e.Graphics.DrawString(ProductoDesc, font5, Brushes.Black, 10, 60) 'PRODUCTO
                If chkimprimirprecio.CheckState = CheckState.Checked Then
                    e.Graphics.DrawString("$" & ProductoPrec, font4, Brushes.Black, 60, 70) 'PRECIO
                End If
                'e.Graphics.DrawString("$" & ProductoPrec, font4, Brushes.Black, 60, 70) 'PRECIO
                'e.Graphics.DrawImage(Image.FromFile(Application.StartupPath & "\logo2.jpg"), 25, 100)
                'e.Graphics.DrawString("Fecha: " & Format(Now, "dd-MM-yyy HH:mm:ss"), font5, Brushes.Black, 0, 140)
                'LlenarEtiqueta()

            End If
        Catch ex As Exception
        End Try
    End Sub



    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim PrintTxt As New PrintDocument
        Dim pgSize As New PaperSize

        pgSize.RawKind = Printing.PaperKind.Custom
        If My.Settings.TipoEtiqueta = 0 Then
            pgSize.Width = 180 '196.8 '
            pgSize.Height = 173.23 '100
        ElseIf My.Settings.TipoEtiqueta = 1 Then
            pgSize.Width = 196.8 '  135 '180 '196.8 '
            pgSize.Height = 118  '78 '173.23 '100

        End If

        PrintTxt.DefaultPageSettings.PaperSize = pgSize
        ' evento print
        AddHandler PrintTxt.PrintPage, AddressOf ImprimirBoleta
        PrintTxt.PrinterSettings.PrinterName = My.Settings.EtiquetadoraNmb
        PrintTxt.Print()
        'End If
    End Sub

    Private Sub busquedaprod_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        chkimprimirprecio.Location = Button8.Location
    End Sub

    Private Sub ItemSeleccionado(IdItem As Integer) Handles dgvProductos.SeleccionarItem
        calcularPrecios(IdItem)
    End Sub


    Private Sub cmbOrdenarPor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbOrdenarPor.SelectionChangeCommitted
        imprimirlist = False
        cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue)
    End Sub
End Class