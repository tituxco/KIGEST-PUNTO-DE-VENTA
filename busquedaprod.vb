Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

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
    'Private Sub cargarProductos(ByRef codigo As String, ByRef nombre As String, ByRef categoria As String)
    '    Dim EnProgreso As New Form
    '    EnProgreso.ControlBox = False
    '    EnProgreso.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
    '    EnProgreso.Size = New Point(430, 30)
    '    EnProgreso.StartPosition = FormStartPosition.CenterScreen
    '    EnProgreso.TopMost = True
    '    Dim Etiqueta As New Label
    '    Etiqueta.AutoSize = True
    '    Etiqueta.Text = "La consulta esta en progreso, esto puede tardar unos momentos, por favor espere ..."
    '    Etiqueta.Location = New Point(5, 5)
    '    EnProgreso.Controls.Add(Etiqueta)
    '    'Dim Barra As New ProgressBar
    '    'Barra.Style = ProgressBarStyle.Marquee
    '    'Barra.Size = New Point(270, 40)
    '    'Barra.Location = New Point(10, 30)
    '    'Barra.Value = 100
    '    'EnProgreso.Controls.Add(Barra)
    '    EnProgreso.Show()
    '    Application.DoEvents()
    '    Try
    '        Reconectar()
    '        'GestorConexiones.conexionPrinc.ChangeDatabase(database)
    '        Dim busqtxt As String

    '        Dim cadenaComp As String
    '        Dim cadenaComp2 As String

    '        Dim busqCat As String
    '        Dim busqCod As String
    '        Dim busqNomb As String
    '        Dim busqStock As String
    '        Dim busqProv As String

    '        Dim separador() As String = {"-", " "}
    '        Dim buscStr = nombre.Split(separador, StringSplitOptions.None)
    '        Dim i As Integer

    '        Dim orderBy As String = ""
    '        Select Case cmbOrdenarPor.SelectedIndex
    '            Case -1
    '                orderBy = " order by pro.id asc"
    '            Case 0
    '                orderBy = " order by pro.descripcion asc"
    '            Case 1
    '                orderBy = " order by pro.codigo asc"
    '        End Select

    '        Dim BusquedaComp As String
    '        If My.Settings.metodoBusquedaProd = 1 Then
    '            BusquedaComp = Replace(nombre, " ", "%")
    '            busqtxt = " pro.descripcion like '%" & BusquedaComp & "%'"
    '        ElseIf My.Settings.metodoBusquedaProd = 0 Then
    '            busqtxt = " pro.descripcion like '" & nombre & "%'"
    '        Else
    '            busqtxt = " pro.descripcion like '%'"
    '        End If

    '        If categoria = "" Then
    '            busqCat = " pro.categoria like '%'"
    '        Else
    '            busqCat = " pro.categoria in (" & categoria & ")"
    '        End If


    '        busqCod = " pro.codigo like '%" & BusquedaComp & "%'"




    '        If cmbproveedor.SelectedIndex = -1 Then
    '            busqProv = " pro.codprov like '%' "
    '        Else
    '            busqProv = " pro.codprov = " & cmbproveedor.SelectedValue
    '        End If

    '        If chkstock.Checked = True Then
    '            busqStock = " having Stock>0 "
    '        Else
    '            busqStock = " "
    '        End If
    '        cadenaComp = "((" & busqtxt & " and " & busqCat & ")" & " or (" & busqCod & " and " & busqCat & ")) and " & busqProv & busqStock & orderBy



    '        Dim idAlmacen As Integer = My.Settings.idAlmacen



    '        'idAlmacen = dgvStock.SelectedRows.Item("idAlmacen").ToString



    '        If imprimirlist = False And imprimiretiq = False Then
    '            'MsgBox(cadenaComp)
    '            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
    '            pro.id as CodInterno, CONCAT_WS(' ', pro.descripcion, pro.detalles) AS Descripcion, pro.codigo as PLU,
    '            (select sum(replace(stock,',','.')) from fact_insumos_lotes  where idproducto=pro.id and idalmacen=" & idAlmacen & ") as Stock 
    '            from fact_insumos as pro, fact_categoria_insum as cat 
    '            where cat.id=pro.categoria and
    '            " & cadenaComp, GestorConexiones.conexionPrinc)
    '            Dim tablaprod As New DataTable
    '            ' MsgBox(consulta.SelectCommand.CommandText)
    '            'Dim filasProd() As DataRow
    '            consulta.Fill(tablaprod)

    '            dgvProductos.Cargar_Datos(tablaprod)
    '            dgvProductos.dgvVista.Columns("PLU").Width = 100
    '            dgvProductos.dgvVista.Columns("Stock").Visible = False

    '            'dtproductos.DataSource = tablaprod
    '            'dtproductos.Columns(0).Width = 100
    '            'dtproductos.Columns(2).Width = 40
    '            'dtproductos.Columns(3).Width = 60
    '        ElseIf imprimirlist = True Or imprimiretiq = True Then

    '            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
    '            Dim fac As New datosfacturas
    '            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select pro.id as CodInterno, pro.descripcion, pro.codigo as PLU,
    '            (select sum(replace(stock,',','.')) from fact_insumos_lotes  where idproducto=pro.id and idalmacen=" & idAlmacen & ") as Stock,  
    '             FORMAT(
    '            (REPLACE(REPLACE(pro.precio, '.', ''), ',', '.') * (SELECT mon.cotizacion FROM fact_moneda AS mon WHERE mon.id = pro.moneda) * (pro.iva + 100) / 100), 
    '            2,'es_AR') AS precioCosto,
    '            case (select valor from fact_configuraciones where id=7)
    '            when 0 then
    '            format(
    '		replace(replace(pro.precio,'.',''),',','.') *
    '		((select mon.cotizacion from fact_moneda as mon where mon.id=pro.moneda)) *
    '		((pro.iva+100)/100) *
    '                    case(select listas.auxcol from fact_listas_precio as listas where listas.id=@idlst) 
    '			when 0 then
    '				((replace(replace(pro.ganancia,'.',''),',','.') +100)/100)
    '			when 1 then
    '				((replace(replace(pro.utilidad1,'.',''),',','.')+100)/100)
    '			when 2 then
    '				((replace(replace(pro.utilidad2,'.',''),',','.')+100)/100)
    '			when 3 then
    '				((replace(replace(pro.utilidad3,'.',''),',','.')+100)/100)
    '			when 4 then
    '				((replace(replace(pro.utilidad4,'.',''),',','.')+100)/100)
    '			when 5 then
    '				((replace(replace(pro.utilidad5,'.',''),',','.')+100)/100)
    '                            end *
    '                    (((select listas.utilidad from fact_listas_precio as listas where listas.id=@idlst)+100)/100)
    ',2,'es_AR')
    '            when 1 then
    '            format(

    '		replace(replace(pro.precio,'.',''),',','.') *
    '		((select mon.cotizacion from fact_moneda as mon where mon.id=pro.moneda)) *
    '		((pro.iva+100)/100) *((
    '                    case(select listas.auxcol from fact_listas_precio as listas where listas.id=@idlst) 
    '			when 0 then
    '				((replace(replace(pro.ganancia,'.',''),',','.') +100)/100)
    '			when 1 then
    '				((replace(replace(pro.utilidad1,'.',''),',','.')+100)/100)
    '			when 2 then
    '				((replace(replace(pro.utilidad2,'.',''),',','.')+100)/100)
    '			when 3 then
    '				((replace(replace(pro.utilidad3,'.',''),',','.')+100)/100)
    '			when 4 then
    '				((replace(replace(pro.utilidad4,'.',''),',','.')+100)/100)
    '			when 5 then
    '				((replace(replace(pro.utilidad5,'.',''),',','.')+100)/100)
    '                            end +
    '                    (((select listas.utilidad from fact_listas_precio as listas where listas.id=@idlst)+100)/100))-1)
    ',2,'es_AR')
    '            end as precioLista, 

    '            cat.nombre as categoria
    '            from fact_insumos as pro, fact_categoria_insum as cat where cat.id=pro.categoria and " & cadenaComp, GestorConexiones.conexionPrinc)
    '            'MsgBox(consulta.SelectCommand.CommandText)
    '            consulta.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@idlst", MySql.Data.MySqlClient.MySqlDbType.Text))
    '            consulta.SelectCommand.Parameters("@idlst").Value = dtlistas.CurrentRow.Cells(3).Value
    '            Dim tablaprod As New DataTable
    '            ' MsgBox(consulta.SelectCommand.CommandText & "______" & dtlistas.CurrentRow.Cells(3).Value)
    '            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
    '            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
    '            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo " _
    '            & "FROM fact_empresa as emp where emp.id=1", GestorConexiones.conexionPrinc)
    '            tabEmp.Fill(fac.Tables("membreteenca"))
    '            Reconectar()

    '            consulta.Fill(fac.Tables("listadoproductos"))


    '            Dim imprimirx As New imprimirFX
    '            With imprimirx
    '                .MdiParent = Me.MdiParent
    '                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
    '                If imprimirlist = True Then
    '                    Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
    '                    'parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("lista", "LISTA: " & dtlistas.CurrentRow.Cells(0).Value.ToString))
    '                    Dim rptfx As Microsoft.Reporting.WinForms.ReportViewer = .rptfx
    '                    rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listadoproductos2.rdlc"
    '                    '.rptfx.LocalReport.SetParameters(parameters)
    '                End If
    '                If imprimiretiq = True Then
    '                    .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\productosetiquetas.rdlc"
    '                End If

    '                .rptfx.LocalReport.DataSources.Clear()
    '                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("membreteenca", fac.Tables("membreteenca")))
    '                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadoproductos")))

    '                .rptfx.DocumentMapCollapsed = True
    '                .rptfx.RefreshReport()
    '                .Show()
    '            End With
    '            imprimirlist = False
    '            imprimiretiq = False

    '        End If

    '        EnProgreso.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        EnProgreso.Close()
    '    End Try
    'End Sub

    Private Sub cargarProductos(ByRef codigo As String, ByRef nombre As String, ByRef categoria As String)
        ' 1. Interfaz Gráfica (Cartel de espera)
        Dim EnProgreso As New Form With {
        .ControlBox = False,
        .FormBorderStyle = FormBorderStyle.Fixed3D,
        .Size = New Point(430, 30),
        .StartPosition = FormStartPosition.CenterScreen,
        .TopMost = True
    }
        Dim Etiqueta As New Label With {
        .AutoSize = True,
        .Text = "La consulta está en progreso, esto puede tardar unos momentos, por favor espere ...",
        .Location = New Point(5, 5)
    }
        EnProgreso.Controls.Add(Etiqueta)
        EnProgreso.Show()
        Application.DoEvents()

        Try
            ' 2. Recolección de parámetros de búsqueda
            Dim idAlmacen As Integer = 0
            Dim nombreAlmacen As String = "TODO"
            Dim idProv As Integer = If(cmbproveedor.SelectedIndex = -1, -1, Convert.ToInt32(cmbproveedor.SelectedValue))
            Dim esParaImprimir As Boolean = (imprimirlist Or imprimiretiq)
            Dim idLista As Integer = If(esParaImprimir AndAlso dtlistas.CurrentRow IsNot Nothing, Convert.ToInt32(dtlistas.CurrentRow.Cells(3).Value), 0)

            ' Verificamos si hay un almacén seleccionado (Ajustá el condicional si tu "Todos" está en el index 0)
            If cmbalmacen.SelectedIndex > -1 Then ' o cmbalmacen.SelectedValue IsNot Nothing
                idAlmacen = Convert.ToInt32(cmbalmacen.SelectedValue)
                nombreAlmacen = cmbalmacen.Text
            End If
            ' -------------------------------------------         

            ' Llamada MÁGICA
            Dim tablaProd As DataTable = GestorInsumos.fact_insumos.BusquedaProductos(
                nombre, My.Settings.metodoBusquedaProd, categoria, idProv,
                chkstock.Checked, idAlmacen, cmbOrdenarPor.SelectedIndex, esParaImprimir, idLista)

            ' Distribución
            If Not esParaImprimir Then
                dgvProductos.Cargar_Datos(tablaProd)
                dgvProductos.dgvVista.Columns("PLU").Width = 100
                dgvProductos.dgvVista.Columns("Stock").Visible = False
            Else
                ' === LOGICA DE IMPRESIÓN ===
                Dim fac As New datosfacturas()
                Reconectar()
                Dim tabEmp As New MySqlDataAdapter("SELECT emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo FROM fact_empresa as emp where emp.id=1", GestorConexiones.conexionPrinc)
                tabEmp.Fill(fac.Tables("membreteenca"))

                Dim imprimirx As New imprimirFX() With {.MdiParent = Me.MdiParent}
                imprimirx.rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local

                If imprimirlist Then
                    imprimirx.rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listadoproductos2.rdlc"
                ElseIf imprimiretiq Then
                    imprimirx.rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\productosetiquetas.rdlc"
                End If

                imprimirx.rptfx.LocalReport.DataSources.Clear()
                imprimirx.rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("membreteenca", fac.Tables("membreteenca")))
                ' Usamos tablaProd directamente como solucionamos antes:
                imprimirx.rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", tablaProd))

                ' === ACÁ LE PASAMOS EL NOMBRE DEL ALMACÉN AL REPORTE ===
                Dim parametrosReporte As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
                parametrosReporte.Add(New Microsoft.Reporting.WinForms.ReportParameter("pAlmacen", "Almacén: " & nombreAlmacen))
                imprimirx.rptfx.LocalReport.SetParameters(parametrosReporte)
                ' ========================================================

                imprimirx.rptfx.DocumentMapCollapsed = True
                imprimirx.rptfx.RefreshReport()
                imprimirx.Show()

                imprimirlist = False
                imprimiretiq = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error en Búsqueda")
        Finally
            EnProgreso.Close()
        End Try
    End Sub
    Private Sub txtbuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyUp

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
        If chkmantenerfiltro.CheckState = CheckState.Unchecked Or txtbuscar.Text = "BUSCAR NOMBRE DE PRODUCTO #CODIGO" Then
            txtbuscar.Text = ""
        End If
    End Sub
    Private Sub cargarCategoriasProd()
        Try
            ' 1. Pedimos todas las categorías ordenadas a nuestra clase (aprovechando lo que ya armamos)
            Dim listaCategorias As List(Of GestorInsumos.fact_categoria_insum) = GestorInsumos.fact_categoria_insum.ObtenerTodos()

            ' Verificamos que haya traído datos
            If listaCategorias IsNot Nothing AndAlso listaCategorias.Count > 0 Then

                ' 2. Asignamos la lista directamente al ComboBox
                cmbcatProd.DataSource = listaCategorias

                ' Indicamos qué propiedad mostrar y cuál usar como valor interno
                cmbcatProd.DisplayMember = "nombre"
                cmbcatProd.ValueMember = "id"

                ' 3. Dejamos el combo sin selección inicial
                cmbcatProd.SelectedIndex = -1

            End If

        Catch ex As Exception
            MsgBox("Error al cargar las categorías de productos: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Public Sub cargarStockAlmacen(idProd As Integer)
        Try
            ' 1. Le pedimos la tabla de stock a nuestra clase
            Dim tablaStock As DataTable = GestorInsumos.fact_insumos.ObtenerStockPorAlmacen(idProd)

            ' 2. Se la pasamos directamente a la grilla
            dgvStock.DataSource = tablaStock

            ' 3. Ocultamos las columnas que no querés que el usuario vea
            If dgvStock.Columns.Contains("idAlmacen") Then dgvStock.Columns("idAlmacen").Visible = False
            If dgvStock.Columns.Contains("ID") Then dgvStock.Columns("ID").Visible = False

        Catch ex As Exception
            MsgBox("Error al cargar el stock del producto: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Public Sub cargarStockAlmacen(idProd As Integer)
    '    Try
    '        Dim consultaPRod As New MySql.Data.MySqlClient.MySqlDataAdapter("select al.id as idAlmacen, lt.idproducto as ID, al.nombre as Almacen, sum(replace(lt.stock,',','.')) as Stock from fact_insumos_almacenes as al, fact_insumos_lotes as lt
    '        where lt.idalmacen = al.id  and lt.idproducto = " & idProd & " group by lt.idproducto, lt.idalmacen", GestorConexiones.conexionPrinc)
    '        Dim tablaprod As New DataTable

    '        consultaPRod.Fill(tablaprod)
    '        dgvStock.DataSource = tablaprod

    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Public Sub calcularPrecios(idProd As Integer)
    '    Try
    '        Dim consultaPRod As New MySql.Data.MySqlClient.MySqlDataAdapter("select prod.precio, (select mon.cotizacion from fact_moneda as mon where mon.id=prod.moneda) as cotizacion,  " &
    '        "prod.iva, prod.ganancia,prod.utilidad1,prod.utilidad2,prod.utilidad3,prod.utilidad4,prod.utilidad5,prod.detalles from fact_insumos as prod where prod.id=" & idProd, GestorConexiones.conexionPrinc)
    '        Dim tablaprod As New DataTable
    '        Dim infoprod() As DataRow
    '        consultaPRod.Fill(tablaprod)
    '        infoprod = tablaprod.Select("")
    '        'MsgBox(infoprod(0)(0))
    '        Dim precioCosto As Double = FormatNumber(infoprod(0)(0), 4)
    '        Dim cotizacion As Double = FormatNumber(infoprod(0)(1), 3)
    '        Dim iva As Double = (FormatNumber(infoprod(0)(2)) + 100) / 100
    '        Dim util As Double = (FormatNumber(infoprod(0)(3)) + 100) / 100
    '        Dim util1 As Double = (FormatNumber(infoprod(0)(4)) + 100) / 100
    '        Dim util2 As Double = (FormatNumber(infoprod(0)(5)) + 100) / 100
    '        Dim util3 As Double = (FormatNumber(infoprod(0)(6)) + 100) / 100
    '        Dim util4 As Double = (FormatNumber(infoprod(0)(7)) + 100) / 100
    '        Dim util5 As Double = (FormatNumber(infoprod(0)(8)) + 100) / 100
    '        Dim util2sum As Double = FormatNumber(infoprod(0)(5))

    '        Dim costoUtil As Double
    '        Dim costoFinal As Double
    '        txtInfoExtraProducto.Text = "Detalles:" & vbNewLine & infoprod(0)("detalles").ToString

    '        costoFinal = precioCosto * iva * cotizacion

    '        Dim i As Integer
    '        For i = 0 To dtlistas.RowCount - 1
    '            Dim utilidad As Double = dtlistas.Rows(i).Cells(1).Value
    '            Dim utilListSum As Double = (utilidad * 100) - 100
    '            Dim sumaUtil As Double = (utilListSum + util2sum + 100) / 100
    '            If dtlistas.Rows(i).Cells(4).Value.ToString = "%" Then
    '                dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad
    '            Else
    '                Select Case dtlistas.Rows(i).Cells(5).Value
    '                    Case 0
    '                        If My.Settings.metodoCalculo = 1 Then
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util
    '                        Else
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util) - 1)
    '                        End If
    '                    Case 1
    '                        If My.Settings.metodoCalculo = 1 Then
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util1
    '                        Else
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util1) - 1)
    '                        End If
    '                    Case 2
    '                        If My.Settings.metodoCalculo = 1 Then
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util2
    '                        Else
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util2) - 1)
    '                        End If
    '                    Case 3
    '                        If My.Settings.metodoCalculo = 1 Then
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util3
    '                        Else
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util3) - 1)
    '                        End If
    '                    Case 4
    '                        If My.Settings.metodoCalculo = 1 Then
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util4
    '                        Else
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util4) - 1)
    '                        End If
    '                    Case 5
    '                        If My.Settings.metodoCalculo = 1 Then
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util5
    '                        Else
    '                            dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util5) - 1)
    '                        End If
    '                End Select

    '            End If
    '        Next
    '        precioCosto = 0
    '        cotizacion = 0
    '        iva = 0
    '        util = 0
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Public Sub calcularPrecios(idProd As Integer)
        Try
            ' 1. Le pedimos a la clase que nos traiga los datos limpios
            Dim tablaprod As DataTable = GestorInsumos.fact_insumos.ObtenerDatosCalculoPrecio(idProd)

            ' Por seguridad, verificamos que haya traído el producto
            If tablaprod.Rows.Count = 0 Then Exit Sub

            Dim infoprod As DataRow = tablaprod.Rows(0)

            ' 2. Leemos los datos usando el NOMBRE de la columna (Es mucho más seguro que usar índices)
            Dim precioCosto As Double = FormatNumber(infoprod("precio"), 4)
            Dim cotizacion As Double = FormatNumber(infoprod("cotizacion"), 3)
            Dim iva As Double = (FormatNumber(infoprod("iva")) + 100) / 100
            Dim util As Double = (FormatNumber(infoprod("ganancia")) + 100) / 100
            Dim util1 As Double = (FormatNumber(infoprod("utilidad1")) + 100) / 100
            Dim util2 As Double = (FormatNumber(infoprod("utilidad2")) + 100) / 100
            Dim util3 As Double = (FormatNumber(infoprod("utilidad3")) + 100) / 100
            Dim util4 As Double = (FormatNumber(infoprod("utilidad4")) + 100) / 100
            Dim util5 As Double = (FormatNumber(infoprod("utilidad5")) + 100) / 100
            Dim util2sum As Double = FormatNumber(infoprod("utilidad2"))

            Dim costoFinal As Double
            txtInfoExtraProducto.Text = "Detalles:" & vbNewLine & infoprod("detalles").ToString()

            ' 3. Cálculo base
            costoFinal = precioCosto * iva * cotizacion

            ' 4. Iteración sobre las listas de precios (Tu lógica original intacta)
            For i As Integer = 0 To dtlistas.RowCount - 1
                Dim utilidad As Double = dtlistas.Rows(i).Cells(1).Value
                Dim utilListSum As Double = (utilidad * 100) - 100
                Dim sumaUtil As Double = (utilListSum + util2sum + 100) / 100

                If dtlistas.Rows(i).Cells(4).Value.ToString = "%" Then
                    dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad
                Else
                    Select Case dtlistas.Rows(i).Cells(5).Value
                        Case 0
                            If My.Settings.metodoCalculo = 1 Then
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util
                            Else
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util) - 1)
                            End If
                        Case 1
                            If My.Settings.metodoCalculo = 1 Then
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util1
                            Else
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util1) - 1)
                            End If
                        Case 2
                            If My.Settings.metodoCalculo = 1 Then
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util2
                            Else
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util2) - 1)
                            End If
                        Case 3
                            If My.Settings.metodoCalculo = 1 Then
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util3
                            Else
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util3) - 1)
                            End If
                        Case 4
                            If My.Settings.metodoCalculo = 1 Then
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util4
                            Else
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util4) - 1)
                            End If
                        Case 5
                            If My.Settings.metodoCalculo = 1 Then
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad * util5
                            Else
                                dtlistas.Rows(i).Cells(2).Value = costoFinal * ((utilidad + util5) - 1)
                            End If
                    End Select
                End If
            Next

            ' No hace falta resetear las variables a 0 al final (precioCosto = 0, etc.) 
            ' porque al declararlas adentro del Sub, mueren solas cuando el Sub termina.

        Catch ex As Exception
            MsgBox("Error al calcular precios: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'Private Sub cargarListas()
    '    Try
    '        Reconectar()
    '        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select nombre, format(utilidad,2,'es_AR'),id,auxcol from fact_listas_precio", GestorConexiones.conexionPrinc)
    '        Dim tablalist As New DataTable
    '        Dim i As Integer
    '        Dim infolist() As DataRow
    '        consulta.Fill(tablalist)

    '        infolist = tablalist.Select("")
    '        For i = 0 To infolist.GetUpperBound(0)
    '            If InStr(infolist(i)(1), "%") <> 0 Then
    '                dtlistas.Rows.Add(infolist(i)(0), FormatNumber((Microsoft.VisualBasic.Right(infolist(i)(1), infolist(i)(1).Length - 1) + 100) / 100, 4), "", infolist(i)(2), "%", infolist(i)(3)) 'FormatNumber(infolist(i)(1) + 100) / 100, "", infolist(i)(2))
    '            Else
    '                dtlistas.Rows.Add(infolist(i)(0), FormatNumber((infolist(i)(1) + 100) / 100, 4), "", infolist(i)(2), "", infolist(i)(3)) 'FormatNumber(infolist(i)(1) + 100) / 100, "", infolist(i)(2))
    '            End If
    '        Next
    '        dtlistas.Columns(4).Visible = False
    '        dtlistas.Columns(5).Visible = False

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub cargarListas()
        Try
            ' Limpiamos la grilla antes de cargar
            dtlistas.Rows.Clear()

            ' 1. Pedimos las listas a nuestra clase
            Dim listasBD As List(Of GestorInsumos.fact_listaPrecios) = GestorInsumos.fact_listaPrecios.ObtenerTodos()

            ' Verificamos que haya traído datos
            If listasBD Is Nothing OrElse listasBD.Count = 0 Then Exit Sub

            ' 2. Recorremos cada lista
            For Each lista As GestorInsumos.fact_listaPrecios In listasBD

                Dim utilidadCalculada As String
                Dim numeroLimpio As Double = 0

                ' 3. Intentamos convertir el valor a número de forma segura
                ' Si lista.utilidad tiene "20", lo guarda en numeroLimpio. 
                ' Si está vacío o tiene letras, lo ignora y numeroLimpio queda en 0.
                If Double.TryParse(lista.utilidad, numeroLimpio) Then
                    utilidadCalculada = FormatNumber((numeroLimpio + 100) / 100, 4)
                Else
                    utilidadCalculada = FormatNumber(1, 4) ' Representa un (0 + 100) / 100
                End If

                ' 4. Agregamos la fila a la grilla
                ' Mandamos un texto vacío "" donde antes iba la marca del porcentaje
                dtlistas.Rows.Add(lista.nombre, utilidadCalculada, "", lista.id, "", lista.auxcol)

            Next

            ' 5. Ocultamos las columnas técnicas (la 4 era la del %, la dejamos oculta por las dudas)
            dtlistas.Columns(4).Visible = False
            dtlistas.Columns(5).Visible = False

        Catch ex As Exception
            MsgBox("Error al cargar las listas de precios: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub cargarProveedores()
        Try
            Reconectar()
            ''GestorConexiones.conexionPrinc.ChangeDatabase(database)

            'cargamos categorias
            Dim tablacatprod As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_proveedores order by razon asc", GestorConexiones.conexionPrinc)
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
        cargarAlmacenes()
        cmbOrdenarPor.SelectedIndex = 0

    End Sub
    Private Sub cargarAlmacenes()
        Try
            ' 1. Pedimos la lista de almacenes directamente a nuestra clase
            Dim listaAlmacenes As List(Of GestorInsumos.fact_insumos_almacenes) = GestorInsumos.fact_insumos_almacenes.ObtenerTodos()

            ' Verificamos que la base de datos haya devuelto datos
            If listaAlmacenes IsNot Nothing AndAlso listaAlmacenes.Count > 0 Then

                ' 2. Le pasamos la lista de objetos al ComboBox
                cmbalmacen.DataSource = listaAlmacenes

                ' Le decimos qué propiedad de la clase mostrar y cuál usar de valor interno
                cmbalmacen.DisplayMember = "nombre"
                cmbalmacen.ValueMember = "id"

                ' 3. Asignamos el almacén por defecto de la configuración
                cmbalmacen.SelectedValue = My.Settings.idAlmacen

            End If

        Catch ex As Exception
            MsgBox("Error al cargar los almacenes: " & ex.Message, MsgBoxStyle.Critical)
        End Try
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
            ' If My.Settings.TipoEtiqueta = 0 Then
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
            bm = Codigos.codigo128(dgvProductos.dgvVista.CurrentRow.Cells(2).Value, False, 30)
            If Not IsNothing(bm) Then
                    PictureBox1.Image = bm
                End If


            ' impresion
            e.Graphics.DrawImage(PictureBox1.Image, 15, 2)
            e.Graphics.DrawString(ProductoCod, font4, Brushes.Black, 35, 33) 'codigo
            'e.Graphics.DrawString(ProEtiquetaCod, font1, Brushes.Black, 0, 0) 'CODIGO DE BARRAS
            'e.Graphics.DrawString("*" & Me.ProId.Trim & "*", font2, Brushes.Black, 50, 47) ' CODIGO NUMERICO
            e.Graphics.DrawString(ProductoDesc, font5, Brushes.Black, 10, 48) 'PRODUCTO
            'e.Graphics.DrawString("x " & ProCantEtiq, font3, Brushes.Black, 0, 70) 'CANTIDAD
            If chkimprimirprecio.CheckState = CheckState.Checked Then
                e.Graphics.DrawString("$" & ProductoPrec, font4, Brushes.Black, 60, 65) 'PRECIO
            End If
            'e.Graphics.DrawImage(Image.FromFile(Application.StartupPath & "\logo2.jpg"), 25, 100)
            'e.Graphics.DrawString("Fecha: " & Format(Now, "dd-MM-yyy HH:mm:ss"), font5, Brushes.Black, 0, 140)
            'LlenarEtiqueta()

            'ElseIf My.Settings.TipoEtiqueta = 1 Then
            '    Dim font2 As New Font("Arial", 8)
            '    Dim font3 As New Font("Arial", 8)
            '    Dim font4 As New Font("Arial", 10)
            '    Dim font5 As New Font("Arial", 6)

            '    Dim ProductoDesc As String = dgvProductos.dgvVista.CurrentRow.Cells(1).Value
            '    Dim ProductoCod As String = dgvProductos.dgvVista.CurrentRow.Cells(2).Value
            '    Dim ProductoPrec As String = Math.Round(dtlistas.CurrentRow.Cells(2).Value, 2)

            '    ''If TextBox1.Text <> "" Then
            '    ''    alto = Convert.ToSingle(TextBox1.Text)
            '    ''End If
            '    Dim bm As Bitmap = Nothing
            '    bm = Codigos.codigo128(dgvProductos.dgvVista.CurrentRow.Cells(2).Value, False, 40)
            '    If Not IsNothing(bm) Then
            '        PictureBox1.Image = bm
            '    End If


            '    ' impresion
            '    e.Graphics.DrawImage(PictureBox1.Image, 35, 0)
            '    e.Graphics.DrawString(ProductoCod, font4, Brushes.Black, 35, 43) 'codigo
            '    'e.Graphics.DrawString(ProEtiquetaCod, font1, Brushes.Black, 0, 0) 'CODIGO DE BARRAS
            '    'e.Graphics.DrawString("*" & Me.ProId.Trim & "*", font2, Brushes.Black, 50, 47) ' CODIGO NUMERICO
            '    e.Graphics.DrawString(ProductoDesc, font5, Brushes.Black, 10, 60) 'PRODUCTO
            '    If chkimprimirprecio.CheckState = CheckState.Checked Then
            '        e.Graphics.DrawString("$" & ProductoPrec, font4, Brushes.Black, 60, 70) 'PRECIO
            '    End If
            'e.Graphics.DrawString("$" & ProductoPrec, font4, Brushes.Black, 60, 70) 'PRECIO
            'e.Graphics.DrawImage(Image.FromFile(Application.StartupPath & "\logo2.jpg"), 25, 100)
            'e.Graphics.DrawString("Fecha: " & Format(Now, "dd-MM-yyy HH:mm:ss"), font5, Brushes.Black, 0, 140)
            'LlenarEtiqueta()


            '' 1. Código de barras más chico de alto (ej: 30 en vez de 40 para ganar espacio)
            'bm = Codigos.codigo128(dgvProductos.dgvVista.CurrentRow.Cells(2).Value, False, 30)

            '' 2. Dibujamos más arriba
            'e.Graphics.DrawImage(PictureBox1.Image, 15, 2)              ' Centrado horizontalmente (ancho 150)
            'e.Graphics.DrawString(ProductoCod, font5, Brushes.Black, 35, 33)   ' Código numérico debajo del de barras
            'e.Graphics.DrawString(ProductoDesc, font5, Brushes.Black, 5, 48)   ' Descripción más arriba
            'If chkimprimirprecio.CheckState = CheckState.Checked Then
            '    e.Graphics.DrawString("$" & ProductoPrec, font4, Brushes.Black, 5, 60) ' Precio al pie
            'End If
            'End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim PrintTxt As New PrintDocument
        Dim pgSize As New PaperSize

        'pgSize.RawKind = Printing.PaperKind.Custom
        'If My.Settings.TipoEtiqueta = 0 Then
        '    pgSize.Width = 180 '196.8 '
        '    pgSize.Height = 173.23 '100
        'ElseIf My.Settings.TipoEtiqueta = 1 Then
        '    pgSize.Width = 196.8 '  135 '180 '196.8 '
        '    pgSize.Height = 118  '78 '173.23 '100

        'End If

        pgSize.RawKind = Printing.PaperKind.Custom

        pgSize.Width = 150 ' Equivale a 38 mm
        pgSize.Height = 79 ' Equivale a 20 mm


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
        cargarStockAlmacen(IdItem)
    End Sub

    Private Sub cmbOrdenarPor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbOrdenarPor.SelectionChangeCommitted
        imprimirlist = False
        cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue)
    End Sub

    Private Sub txtbuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProd.SelectedValue)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkstock_CheckStateChanged(sender As Object, e As EventArgs) Handles chkstock.CheckStateChanged
        If chkstock.CheckState = CheckState.Checked Then
            cmbalmacen.Visible = True
        Else
            cmbalmacen.Visible = False
        End If
    End Sub
End Class

