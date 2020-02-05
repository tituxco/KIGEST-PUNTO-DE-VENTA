Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Data
Imports System.Data.OleDb
Public Class productos
    Dim modificaProd As Boolean
    Dim imprimirlist As Boolean
    Dim elimColumn As Boolean
    Dim proveedorimport As Integer
    Dim categoriaimport As Integer
    '//////////////////////////////////////////////////////////////////
    Private Sub productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargarListas()


        deshabilitarControles()
        cargarCategoriasProd()
        cargarMarcas()
        cargarMoneda()
        cargarunidades()
        cargarPresentacion()
        cargarProveedores()
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
            cmbcatprod.DataSource = readcat.Tables(0)
            cmbcatprod.DisplayMember = readcat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcatprod.ValueMember = readcat.Tables(0).Columns(0).Caption.ToString
            cmbcatprod.SelectedIndex = -1

            cmbcatProdGral.DataSource = readcat2.Tables(0)
            cmbcatProdGral.DisplayMember = readcat2.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcatProdGral.ValueMember = readcat2.Tables(0).Columns(0).Caption.ToString
            cmbcatProdGral.SelectedIndex = -1

            cmbcategoriaimport.DataSource = readcat2.Tables(0)
            cmbcategoriaimport.DisplayMember = readcat2.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcategoriaimport.ValueMember = readcat2.Tables(0).Columns(0).Caption.ToString
            cmbcategoriaimport.SelectedIndex = -1


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarProveedores()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos categorias
            Dim tablacatprod As New MySql.Data.MySqlClient.MySqlDataAdapter("select id,razon from fact_proveedores order by razon asc", conexionPrinc)
            Dim readcat As New DataSet
            Dim readcat2 As New DataSet
            tablacatprod.Fill(readcat)
            tablacatprod.Fill(readcat2)
            cmbproveedor.DataSource = readcat.Tables(0)
            cmbproveedor.DisplayMember = readcat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbproveedor.ValueMember = readcat.Tables(0).Columns(0).Caption.ToString
            cmbproveedor.SelectedIndex = -1

            cmbproveedorimport.DataSource = readcat.Tables(0)
            cmbproveedorimport.DisplayMember = readcat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbproveedorimport.ValueMember = readcat.Tables(0).Columns(0).Caption.ToString
            cmbproveedorimport.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarMarcas()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos marcas
            Dim tablamarca As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_marcas order by nombre asc", conexionPrinc)
            Dim readmarc As New DataSet
            tablamarca.Fill(readmarc)
            cmbmarcas.DataSource = readmarc.Tables(0)
            cmbmarcas.DisplayMember = readmarc.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbmarcas.ValueMember = readmarc.Tables(0).Columns(0).Caption.ToString
            cmbmarcas.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarunidades()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos marcas
            Dim tablaunidad As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_unidades order by nombre asc", conexionPrinc)
            Dim readunid As New DataSet
            tablaunidad.Fill(readunid)
            cmbunidades.DataSource = readunid.Tables(0)
            cmbunidades.DisplayMember = readunid.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbunidades.ValueMember = readunid.Tables(0).Columns(0).Caption.ToString
            cmbunidades.SelectedValue = 1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarPresentacion()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos marcas
            Dim tablaunidad As New MySql.Data.MySqlClient.MySqlDataAdapter("select distinct(presentacion) from fact_insumos order by presentacion desc", conexionPrinc)
            Dim readunid As New DataSet
            tablaunidad.Fill(readunid)
            cmbpresentacion.DataSource = readunid.Tables(0)
            cmbpresentacion.DisplayMember = readunid.Tables(0).Columns(0).Caption.ToString.ToUpper

            cmbpresentacion.Text = 1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarModelos(ByRef marca As Integer)
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos marcas
            Dim tablamodelo As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_modelos where idmarca=" & marca & " order by nombre asc", conexionPrinc)
            Dim readmod As New DataSet
            tablamodelo.Fill(readmod)
            cmbmodelos.DataSource = readmod.Tables(0)
            cmbmodelos.DisplayMember = readmod.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbmodelos.ValueMember = readmod.Tables(0).Columns(0).Caption.ToString
            cmbmodelos.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarMoneda()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos marcas
            Dim tablamoneda As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_moneda ", conexionPrinc)
            Dim readmone As New DataSet
            tablamoneda.Fill(readmone)
            cmbmoneda.DataSource = readmone.Tables(0)
            cmbmoneda.DisplayMember = readmone.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbmoneda.ValueMember = readmone.Tables(0).Columns(0).Caption.ToString
            cmbmoneda.SelectedIndex = -1


            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select valor from fact_configuraciones where  id = 1"
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            lblintereslista.Text = lector("valor").ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbmarcas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbmarcas.SelectedValueChanged
        Try
            cargarModelos(cmbmarcas.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub deshabilitarControles()

        For Each Cont As Control In TabPage1.Controls
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
            ElseIf TypeOf Cont Is Button Then
                Dim Bot As Button
                Bot = Cont
                If Bot.Enabled = False Then
                    Bot.Enabled = True
                Else
                    Bot.Enabled = False
                End If
            End If
        Next

        For Each Cont As Control In tabcostos.Controls
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

    Private Sub vaciarControles()
        For Each Cont As Control In TabPage1.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                tex.Text = ""

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                cbo.SelectedIndex = -1
            End If
        Next

        For Each Cont As Control In tabcostos.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                tex.Text = ""

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                cbo.SelectedIndex = -1
            End If
        Next
        lbllista.Text = 0
        lbllista1.Text = 0
        lbllista2.Text = 0

        txtiva.Text = My.Settings.ivaDef
        cmbmoneda.SelectedValue = My.Settings.monedaDef
        If My.Settings.calcCosto = 1 Then chkcalcularcosto.CheckState = CheckState.Checked
        lblstock.Text = 0
        txtutilidad.Text = 0
        txtutilidad1.Text = 0
        txtutilidad2.Text = 0
    End Sub

    Private Sub cargarProductos(ByRef codigo As String, ByRef nombre As String, ByRef categoria As String)
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim busqtxt As String

            Dim cadenaComp As String

            Dim busqCat As String
            Dim busqCod As String
            Dim busqNomb As String
            Dim busqStock As String

            Dim separador() As String = {"-", " "}
            Dim buscStr = nombre.Split(separador, StringSplitOptions.None)
            Dim i As Integer

            'For i = 0 To buscStr.Length - 1
            '    If i = 0 Then
            '        busqtxt &= " descripcion like '%" & buscStr(i) & "%' or codigo like '" & buscStr(i) & "%'"
            '    Else
            '        busqtxt &= " and descripcion like '%" & buscStr(i) & "%' or codigo like '" & buscStr(i) & "%'"
            '    End If

            'Next
            Dim BusquedaComp As String

            BusquedaComp = Replace(nombre, " ", "%")
            busqtxt = " descripcion like '%" & BusquedaComp & "%' or codigo like '" & nombre & "'"

            If chkstock.CheckState = CheckState.Checked Then
                busqStock = "and stock >=1"
            Else
                busqStock = "and stock >=0"

            End If

            If nombre = "" Then
                busqNomb = "where eliminado=0 and  descripcion like '%' "
            Else
                busqNomb = "where eliminado=0 and  " & busqtxt
            End If

            If categoria = "" Then
                busqCat = " categoria like '%'"
            Else
                busqCat = " categoria like '" & categoria & "'"
            End If

            If codigo <> "" And Val(codigo) <> 0 Then
                busqCod = " and  id=" & codigo
            End If

            cadenaComp = busqNomb & " And " & busqCat & busqStock & busqCod

            'MsgBox(cadenaComp)

            If imprimirlist = False Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id as CodInterno, descripcion as Producto, codigo as Codigo FROM fact_insumos " & cadenaComp, conexionPrinc)
                Dim tablaprod As New DataTable
                'Dim filasProd() As DataRow
                consulta.Fill(tablaprod)
                dtproductos.DataSource = tablaprod
                'dtproductos.Columns(0).Visible = False
            ElseIf imprimirlist = True Then

                Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
                Dim fac As New datosfacturas
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id as codigo, descripcion FROM fact_insumos " & cadenaComp, conexionPrinc)
                Dim tablaprod As New DataTable
                'Dim filasProd() As DataRow
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
                    .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listadoproductos.rdlc"
                    .rptfx.LocalReport.DataSources.Clear()
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("membreteenca", fac.Tables("membreteenca")))
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listadoproductos")))
                    '.rptfx.LocalReport.SetParameters(parameters)
                    .rptfx.DocumentMapCollapsed = True
                    .rptfx.RefreshReport()
                    .Show()
                End With
                imprimirlist = False
            End If

            dtproductos.Columns(0).Width = 40
            dtproductos.Columns(2).Width = 60

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

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
    Private Sub cargarListas()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select concat(nombre ,' (',utilidad,'%)'), format(utilidad,2,'es_AR'), auxcol from fact_listas_precio", conexionPrinc)
            Dim tablalist As New DataTable
            Dim i As Integer
            Dim infolist() As DataRow
            consulta.Fill(tablalist)

            infolist = tablalist.Select("")
            For i = 0 To infolist.GetUpperBound(0)
                If InStr(infolist(i)(1), "%") <> 0 Then
                    dtlistas.Rows.Add(infolist(i)(0), FormatNumber((Microsoft.VisualBasic.Right(infolist(i)(1), infolist(i)(1).Length - 1) + 100) / 100, 4), "", "%", infolist(i)(2)) 'FormatNumber(infolist(i)(1) + 100) / 100, "", infolist(i)(2))
                Else
                    dtlistas.Rows.Add(infolist(i)(0), FormatNumber((infolist(i)(1) + 100) / 100, 4), "", "", infolist(i)(2)) 'FormatNumber(infolist(i)(1) + 100) / 100, "", infolist(i)(2))
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub calcularPrecios()
        Try
            Dim precioCosto As Double = FormatNumber(txtcosto.Text)
            Dim cotizacion As Double = FormatNumber(lblcotizacion.Text)
            Dim iva As Double = (FormatNumber(txtiva.Text) + 100) / 100
            Dim util As Double = (FormatNumber(txtutilidad.Text) + 100) / 100
            Dim util1 As Double = (FormatNumber(txtutilidad1.Text) + 100) / 100
            Dim util2 As Double = (FormatNumber(txtutilidad2.Text) + 100) / 100

            Dim util2sum As Double = FormatNumber(txtutilidad2.Text)

            Dim costoUtil As Double
            Dim costoFinal As Double

            costoFinal = precioCosto * iva * cotizacion
            'costoUtil = costoFinal * util
            txtcostofinal.Text = Math.Round(costoFinal, 2)

            Dim i As Integer

            For i = 0 To dtlistas.RowCount - 1
                Dim utilidad As Double = dtlistas.Rows(i).Cells(1).Value
                Dim utilListSum As Double = (utilidad * 100) - 100
                Dim sumaUtil As Double = (utilListSum + util2sum + 100) / 100
                If dtlistas.Rows(i).Cells(3).Value.ToString = "%" Then
                    dtlistas.Rows(i).Cells(2).Value = costoFinal * utilidad
                Else
                    Select Case dtlistas.Rows(i).Cells(4).Value
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
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarInfoProd(ByRef codigo As Integer)
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT pro.*, (select sum(stock) from fact_insumos_lotes  where idproducto=pro.id)   
            from fact_insumos as pro where pro.id = " & codigo, conexionPrinc)
            Dim tablaprod As New DataTable
            Dim infoProd() As DataRow
            consulta.Fill(tablaprod)
            infoProd = tablaprod.Select("descripcion like '%'")
            cmbmoneda.SelectedValue = infoProd(0)(14)
            txtproducto.Text = infoProd(0)(1)
            cmbcatprod.SelectedValue = infoProd(0)(8)
            cmbmarcas.SelectedValue = infoProd(0)(9)
            cmbmodelos.SelectedValue = infoProd(0)(10)

            If infoProd(0)(20) = 0 Then
                txtpreciobase.Text = infoProd(0)(2)
                txtcosto.Text = 0
                chkpreciobase.CheckState = CheckState.Unchecked
            ElseIf infoProd(0)(20) = 1 Then
                txtcosto.Text = infoProd(0)(2)
                txtpreciobase.Text = 0
                chkpreciobase.CheckState = CheckState.Checked
            End If
            txtutilidad.Text = infoProd(0)(3)
            txtutilidad1.Text = infoProd(0)(15)
            txtutilidad2.Text = infoProd(0)(16)
            txtiva.Text = infoProd(0)(6)

            txtplu.Text = infoProd(0)(13)
            'txtcodprov.Text = 
            'If infoProd(0)(7) <> 0 Then
            cmbproveedor.SelectedValue = infoProd(0)(7)
            ' Else
            'cmbproveedor.SelectedIndex = 
            'End If

            txtgarantia.Text = infoProd(0)(4)
            txtinfoextra.Text = infoProd(0)(12)
            txtcodigo.Text = infoProd(0)(19)
            cmbtipoprod.SelectedIndex = infoProd(0)(18)
            txtutilidad.Text = infoProd(0)(3)
            cmbunidades.SelectedValue = infoProd(0)(22)
            ' MsgBox(infoProd(0)(24))
            lblultimaMod.Text = infoProd(0)(24).ToString
            cmbpresentacion.Text = infoProd(0)(23)
            If Not IsDBNull(infoProd(0)(17)) Then
                imgFoto.Image = Bytes_Imagen(infoProd(0)(17))
            Else
                imgFoto.Image = Image.FromFile(Application.StartupPath & "\sinimagen.jpg")
            End If
            If IsDBNull(infoProd(0)(25)) Then
                lblstock.Text = "0"
                dtlotesprov.DataSource = Nothing
            Else
                lblstock.Text = infoProd(0)(25)
                Reconectar()
                dtlotesprov.DataSource = Nothing
                If cmbtipoprod.SelectedIndex = 0 Then
                    Dim consProv As New MySql.Data.MySqlClient.MySqlDataAdapter("select concat(lt.nombre,' - ' , pfac.fecha) as LoteFcompra,pfac.numero, pro.razon as Proveedor, concat(lt.stock, ' de ',lt.compracant)  as Stock 
                    from fact_insumos_lotes as lt, fact_proveedores as pro, fact_proveedores_fact as pfac 
                    where  pro.id = pfac.idproveedor and lt.idfactura=pfac.id and idproducto='" & codigo & "'			
                    order by lt.id  desc", conexionPrinc)
                    Dim tablaprov As New DataTable

                    consProv.Fill(tablaprov)
                    dtlotesprov.DataSource = tablaprov
                ElseIf cmbtipoprod.SelectedIndex = 1 Then
                    Dim consProv As New MySql.Data.MySqlClient.MySqlDataAdapter("select pro.fecha as ORIGEN, " _
                    & "lt.stock  as Stock from fact_insumos_lotes as lt, fact_produccion as pro  " _
                    & "where lt.idfactura=pro.id and lt.idproducto=" & codigo & " order by lt.id asc", conexionPrinc)
                    Dim tablaprov As New DataTable

                    consProv.Fill(tablaprov)
                    dtlotesprov.DataSource = tablaprov
                End If
            End If

            'lblventas.Text = infoProd(0)(5)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtbuscar_GotFocus(sender As Object, e As EventArgs) Handles txtbuscar.GotFocus
        txtbuscar.Text = ""
    End Sub

    Private Sub txtbuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyUp

        Try
            If e.KeyCode = Keys.Enter Then
                cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProdGral.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbuscar_LostFocus(sender As Object, e As EventArgs) Handles txtbuscar.LostFocus
        If txtbuscar.Text = "" Then
            txtbuscar.Text = "BUSCAR NOMBRE DE PRODUCTO #CODIGO"
        End If
    End Sub

    Private Sub chkstock_CheckedChanged(sender As Object, e As EventArgs) Handles chkstock.CheckedChanged
        Try
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProdGral.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEnter
        'vaciarControles()
        CargarInfoProd(dtproductos.CurrentRow.Cells(0).Value)
        calcularPrecios()
        cargarDescuentos()
    End Sub

    Private Sub cargarDescuentos()
        Try
            dtdescuentos.Rows.Clear()
            Reconectar()
            Dim consultaDescProd As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT prom.id,concat('Descuento ',' ', prom.descuento_porc ,'%'),prom.compra_min,prom.descuento_porc " &
            "From fact_promociones As prom, fact_insumos As ins Where ins.id = prom.idproducto and prom.idproducto=" & dtproductos.CurrentRow.Cells(0).Value, conexionPrinc)
            Dim tablaDescProd As New DataTable
            Dim filasDescProd() As DataRow
            consultaDescProd.Fill(tablaDescProd)
            filasDescProd = tablaDescProd.Select("")

            For i As Integer = 0 To tablaDescProd.Rows.Count - 1
                dtdescuentos.Rows.Add(filasDescProd(i)(0), filasDescProd(i)(1), filasDescProd(i)(2), filasDescProd(i)(3))
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbmoneda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbmoneda.SelectedValueChanged
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select cotizacion from fact_moneda  where  id = " & cmbmoneda.SelectedValue
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            lblcotizacion.Text = lector("cotizacion").ToString


            txtcosto.Text = txtcosto.Text 'remplazarcoma(txtcosto.Text)
            txtiva.Text = txtiva.Text 'remplazarcoma(txtiva.Text)
            txtutilidad.Text = txtutilidad.Text

            calcularPrecios()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdmodificar_Click(sender As Object, e As EventArgs) Handles cmdmodificar.Click
        deshabilitarControles()
        'TabPage2.Parent = TabControl1
        cmdnuevapers.Enabled = False
        cmdeliminar.Enabled = False
        cmdmodificar.Enabled = False
        cmdaceptar.Enabled = True
        cmdcancelar.Enabled = True
        modificaProd = True
        tabcostos.Parent = TabControl1

    End Sub

    Private Sub cmbcatProdGral_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbcatProdGral.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProdGral.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbcatProdGral_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcatProdGral.SelectionChangeCommitted
        Try
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProdGral.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcosto_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcosto.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If chkcalcularcosto.CheckState = CheckState.Checked Then
                    txtcosto.Text = Math.Round(FormatNumber(txtcosto.Text, 2) / ((FormatNumber(txtiva.Text, 2) + 100) / 100), 2)
                    txtutilidad.Focus()
                    'calcularPrecios()
                Else
                    txtcosto.Text = txtcosto.Text
                    txtutilidad.Focus()
                    calcularPrecios()

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtiva_KeyUp(sender As Object, e As KeyEventArgs) Handles txtiva.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                txtiva.Text = txtiva.Text 'remplazarcoma(txtiva.Text)
                calcularPrecios()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtutilidad_KeyUp(sender As Object, e As KeyEventArgs) Handles txtutilidad.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
                calcularPrecios()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtutilidad_Leave(sender As Object, e As EventArgs) Handles txtutilidad.Leave
        Try

            DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
            calcularPrecios()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtiva_Leave(sender As Object, e As EventArgs) Handles txtiva.Leave
        txtiva.Text = txtiva.Text 'remplazarcoma(txtiva.Text)
    End Sub

    Private Sub txtcosto_Leave(sender As Object, e As EventArgs) Handles txtcosto.Leave

        If chkcalcularcosto.CheckState = CheckState.Checked Then
            '  txtcosto.Text = Math.Round(FormatNumber(txtcosto.Text, 2) / ((FormatNumber(txtiva.Text, 2) + 100) / 100), 2)
            calcularPrecios()
        Else
            txtcosto.Text = txtcosto.Text
            calcularPrecios()
        End If
    End Sub

    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
        Try
            Dim nombre As String = txtproducto.Text.ToUpper
            Dim categoria As Integer = cmbcatprod.SelectedValue
            Dim marca As Integer = cmbmarcas.SelectedValue
            Dim modelo As Integer = cmbmodelos.SelectedValue
            Dim plu As String = txtplu.Text.ToUpper
            Dim codprov As String = cmbproveedor.SelectedValue 'txtcodprov.Text.ToUpper
            Dim garantia As String = txtgarantia.Text.ToUpper
            Dim infoext As String = txtinfoextra.Text.ToUpper
            Dim costo As String
            'If chkpreciobase.CheckState = CheckState.Checked Then
            costo = txtcosto.Text
            'Else
            '    costo = txtpreciobase.Text
            'End If
            Dim iva As String = txtiva.Text
            Dim utilidad As String = txtutilidad.Text
            Dim utilidad1 As String = txtutilidad1.Text
            Dim utilidad2 As String = txtutilidad2.Text
            Dim codigo As String = txtcodigo.Text
            Dim tipo As String = cmbtipoprod.SelectedIndex
            Dim calcular_precio As Integer
            Dim unidades As Integer = cmbunidades.SelectedValue

            If chkpreciobase.CheckState = CheckState.Checked Then
                calcular_precio = 1
            Else
                calcular_precio = 0
            End If
            Dim presentacion As String = cmbpresentacion.Text

            Dim moneda As Integer = cmbmoneda.SelectedValue

            Dim foto As Byte() = Imagen_Bytes(imgFoto.Image)

            'Dim stock As String = txtstoked.Text
            Reconectar()
            If categoria = 0 And cmbcatprod.Text <> "" Then
                Dim comandoad As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_categoria_insum (nombre) values('" & cmbcatprod.Text.ToUpper & "')", conexionPrinc)
                comandoad.ExecuteNonQuery()
                categoria = comandoad.LastInsertedId
            End If

            Reconectar()
            If marca = 0 And cmbmarcas.Text <> "" Then
                Dim comandoad As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_marcas(nombre) values('" & cmbmarcas.Text.ToUpper & "')", conexionPrinc)
                comandoad.ExecuteNonQuery()
                marca = comandoad.LastInsertedId
            End If

            Reconectar()
            If modelo = 0 And cmbmodelos.Text <> "" Then
                Dim comandoad As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_modelos (idmarca,nombre) values('" & marca & "','" & cmbmodelos.Text.ToUpper & "')", conexionPrinc)
                comandoad.ExecuteNonQuery()
                modelo = comandoad.LastInsertedId
            End If

            Reconectar()
            If moneda = 0 And cmbmoneda.Text <> "" Then
                Dim comandoad As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_moneda (nombre,cotizacion) values('" & cmbmoneda.Text.ToUpper & "','1')", conexionPrinc)
                comandoad.ExecuteNonQuery()
                modelo = comandoad.LastInsertedId
            End If

            Dim sqlQuery As String

            If modificaProd = False Then

                sqlQuery = "insert into fact_insumos " _
                & "(descripcion, precio, ganancia, garantia, iva, codprov, categoria, marca, modelo, detalles, cod_bar, moneda,utilidad1,utilidad2, tipo, codigo, calcular_precio,unidades,presentacion,foto) values " _
                & "(?desc, ?prec, ?gan, ?gar, ?iva, ?codprov, ?cat, ?marca, ?modelo, ?det, ?plu, ?mone,?uti1,?uti2,?tipo,?codigo,?calcpcio,?unid,?present,?foto)"
            ElseIf modificaProd = True Then
                sqlQuery = "update fact_insumos set descripcion=?desc, precio=?prec, ganancia=?gan, garantia=?gar, iva=?iva, " _
                    & "codprov=?codprov, categoria=?cat, marca=?marca,modelo=?modelo, detalles=?det,cod_bar=?plu, moneda=?mone," &
                "utilidad1=?uti1,utilidad2=?uti2, tipo=?tipo, codigo=?codigo, calcular_precio=?calcpcio,unidades=?unid, presentacion=?present, foto=?foto where id=?idp"
            End If
            Reconectar()

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?desc", nombre)
                .AddWithValue("?prec", costo)
                .AddWithValue("?gan", utilidad)
                .AddWithValue("?gar", garantia)
                .AddWithValue("?iva", iva)
                .AddWithValue("?codprov", codprov)
                .AddWithValue("?cat", categoria)
                .AddWithValue("?marca", marca)
                .AddWithValue("?modelo", modelo)
                .AddWithValue("?det", infoext)
                .AddWithValue("?plu", codigo)
                .AddWithValue("?mone", moneda)
                .AddWithValue("?uti1", utilidad1)
                .AddWithValue("?uti2", utilidad2)
                .AddWithValue("?calcpcio", calcular_precio)
                .AddWithValue("?unid", unidades)
                .AddWithValue("?present", presentacion)
                .AddWithValue("?tipo", tipo)
                .AddWithValue("?foto", foto)
                .AddWithValue("?codigo", codigo)

                If modificaProd = True Then
                    Dim idProducto As Integer = dtproductos.CurrentRow.Cells(0).Value
                    .AddWithValue("?idp", idProducto)
                End If

            End With
            comandoadd.ExecuteNonQuery()
            MsgBox("Operacion completada correctamente")
            deshabilitarControles()
            'TabPage2.Parent = Nothing
            cmdnuevapers.Enabled = True
            cmdeliminar.Enabled = True
            cmdmodificar.Enabled = True
            cmdaceptar.Enabled = False
            cmdcancelar.Enabled = False
            modificaProd = False
            cargarCategoriasProd()
            cargarMarcas()

            'If modificaProd = False Then
            '    txtbuscar.Text = txtproducto.Text
            '    cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProdGral.SelectedValue)
            'End If

            My.Settings.calcCosto = chkcalcularcosto.CheckState
            My.Settings.ivaDef = txtiva.Text
            My.Settings.monedaDef = cmbmoneda.SelectedValue
            My.Settings.Save()
        Catch ex As Exception
            MsgBox("error al guardar producto" & vbNewLine & ex.Message)

        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        deshabilitarControles()
        'TabPage2.Parent = Nothing
        cmdnuevapers.Enabled = True
        cmdeliminar.Enabled = True
        cmdaceptar.Enabled = False
        cmdcancelar.Enabled = False
        cmdmodificar.Enabled = True
        modificaProd = False
    End Sub

    Private Sub cmdnuevapers_Click(sender As Object, e As EventArgs) Handles cmdnuevapers.Click
        deshabilitarControles()
        'TabPage2.Parent = TabControl1
        cmdnuevapers.Enabled = False
        cmdeliminar.Enabled = False
        cmdmodificar.Enabled = False
        cmdaceptar.Enabled = True
        cmdcancelar.Enabled = True
        modificaProd = False
        vaciarControles()
        cmbproveedor.SelectedValue = 0
    End Sub

    Private Sub txtcodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcodigo.KeyPress
        'If Not IsNumeric(e.KeyChar) Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub txtpreciobase_TextChanged(sender As Object, e As EventArgs)
        calcularPrecios()
    End Sub

    Private Sub cmdeliminar_Click(sender As Object, e As EventArgs) Handles cmdeliminar.Click
        Try
            Dim sqlquery As String
            If MsgBox("Esta seguro que desea eliminar este producto? esta acción no se puede deshacer", vbYesNo + vbQuestion) = vbYes Then
                sqlquery = "delete from fact_insumos where id=" & dtproductos.CurrentRow.Cells(0).Value
                Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand(sqlquery, conexionPrinc)
                comandoupd.ExecuteNonQuery()
                dtproductos.Rows.Remove(dtproductos.CurrentRow)
                MsgBox("Producto eliminado")
                cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProdGral.SelectedValue)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            imprimirlist = True
            cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProdGral.SelectedValue)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        Dim ficheros As String

        Try
            dlAbrir.Filter = "Archivos de excel (*.xls,*.xlsx)|*.xls;*.xlsx"
            dlAbrir.Multiselect = False
            dlAbrir.Title = "Selección de archivo"
            dlAbrir.ShowDialog()
            If dlAbrir.FileName <> "" Then
                ficheros = dlAbrir.FileName
                Dim dt As DataTable = GetDataExcel(ficheros, InputBox("Ingrese nombre de la hoja de excel", "Importar lista de precios", "Hoja1"))
                dtimportados.DataSource = dt
                lblcantprod.Text = dtimportados.RowCount
                'ProgressBar1.Maximum = dtimportados.RowCount
            End If

            ''Dim i As Integer
            ''For i = 0 To 3
            ''dtproductos.Columns(0).HeaderText = "DESCRIPCION"
            'dtproductos.Columns(1).HeaderText = "COD_BARR"
            'dtproductos.Columns(2).HeaderText = "PRESENTACION"
            ''dtproductos.Columns(3).HeaderText = "COSTO"
            ''Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.BackColor = Color.Red Then
            Button4.BackColor = Color.FromArgb(RGB(64, 64, 64))
            elimColumn = False
            Me.Cursor = Cursors.Arrow
            For Each columna As DataGridViewColumn In dtproductos.Columns
                columna.SortMode = DataGridViewColumnSortMode.NotSortable

            Next
        Else
            Button4.BackColor = Color.Red
            Me.Cursor = Cursors.Hand
            elimColumn = True
            For Each columna As DataGridViewColumn In dtproductos.Columns
                columna.SortMode = DataGridViewColumnSortMode.Automatic

            Next
        End If

    End Sub

    Private Sub dtimportados_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtimportados.ColumnHeaderMouseClick
        If elimColumn = True Then
            'MsgBox(dtimportados.Columns.Item(e.ColumnIndex).Name)
            dtimportados.Columns.Remove(dtimportados.Columns.Item(e.ColumnIndex).Name)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles cmdimportar.Click
        frmprincipal.pbprincipal.Visible = True
        cmdimportar.Enabled = False
        proveedorimport = cmbproveedorimport.SelectedValue
        categoriaimport = cmbcategoriaimport.SelectedValue

        ImportarListaPrecios.RunWorkerAsync()

    End Sub


    Private Sub productos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub
    Private Sub ImportarListaPrecios_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ImportarListaPrecios.DoWork
        ImportarLista()

    End Sub
    Private Sub ImportarLista()
        Try
            Dim sqlQuery As String

            Dim sqlQueryadd_INSPref As String = "insert into fact_insumos (id"
            Dim sqlQueryadd_INS As String
            Dim sqlQueryadd_INSValPref As String = ") values (?id"
            Dim sqlQueryadd_INSVal As String

            Dim sqlQueryupd_UPDPref As String = ") On duplicate key update iva=?iva"
            Dim sqlQueryupd_UPDVal As String

            Dim numeromod As Integer = 0
            Dim numeroadd As Integer = 0
            Dim calcularprecio As Integer = 1
            Dim gananciagral As String = txtgananciagral.Text
            Dim registros As Integer = dtimportados.RowCount
            Dim registroactual As Integer = 0
            Dim cod_bar As String
            Dim codigo As String = 0
            Dim descripcion As String
            Dim presentacion As String
            Dim costo As String
            Dim i As Integer

            For Each producto As DataGridViewRow In dtimportados.Rows
                If producto.Cells(0).Value = "" Then
                    Continue For
                End If
                i = 0
                If conexionSEC.State = ConnectionState.Closed Then
                    conexionSEC.Open()
                    conexionSEC.ChangeDatabase(database)
                End If

                Dim iva As String = txtlistaimportaiva.Text
                descripcion = producto.Cells(i).Value.ToString
                i += 1

                If chkimportproveedor.CheckState = CheckState.Checked Then
                    sqlQueryadd_INS = sqlQueryadd_INS & ",codprov"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?codprov"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",codprov=?codprov"
                End If

                If chkimportcateg.CheckState = CheckState.Checked Then
                    sqlQueryadd_INS = sqlQueryadd_INS & ",categoria"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?catprod"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",categoria=?catprod"
                End If
                If chkimportdescripcion.CheckState = CheckState.Checked Then
                    sqlQueryadd_INS = sqlQueryadd_INS & ",descripcion"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?descripcion"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",descripcion=?descripcion"
                End If
                If chkimportcodbar.CheckState = CheckState.Checked Then

                    cod_bar = producto.Cells(i).Value.ToString
                    codigo = producto.Cells(i).Value.ToString
                    i += 1
                    sqlQueryadd_INS = sqlQueryadd_INS & ",cod_bar,codigo"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?cod_bar,?cod_bar"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",cod_bar=?cod_bar,codigo=?cod_bar"
                End If
                If chkimportpresentacion.CheckState = CheckState.Checked Then
                    presentacion = producto.Cells(i).Value.ToString
                    i += 1

                    sqlQueryadd_INS = sqlQueryadd_INS & ",presentacion"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?present"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",presentacion=?present"
                End If
                If chkimportprecio.CheckState = CheckState.Checked Then

                    costo = producto.Cells(i).Value.ToString
                    i += 1

                    sqlQueryadd_INS = sqlQueryadd_INS & ",precio"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?costo"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",precio=?costo"
                End If

                If chkimportprecio.CheckState = CheckState.Checked Then
                    sqlQueryadd_INS = sqlQueryadd_INS & ",iva"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?iva"

                End If

                If chkutilidad.CheckState = CheckState.Checked Then
                    sqlQueryadd_INS = sqlQueryadd_INS & ",ganancia"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?ganan"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",ganancia=?ganan"
                End If

                sqlQueryadd_INS = sqlQueryadd_INS & ",calcular_precio"
                sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?calcpre"
                sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",calcular_precio=?calcpre"


                sqlQuery = sqlQueryadd_INSPref & sqlQueryadd_INS & sqlQueryadd_INSValPref & sqlQueryadd_INSVal & sqlQueryupd_UPDPref & sqlQueryupd_UPDVal
                'MsgBox(sqlQuery)

                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionSEC)
                With comandoadd.Parameters
                    .AddWithValue("?id", ObtenerIDproducto(codigo))
                    .AddWithValue("?codprov", proveedorimport)
                    .AddWithValue("?catprod", categoriaimport)
                    .AddWithValue("?descripcion", descripcion)
                    .AddWithValue("?cod_bar", cod_bar)
                    .AddWithValue("?present", presentacion)
                    .AddWithValue("?costo", costo.Replace("$", ""))
                    .AddWithValue("?iva", iva)
                    .AddWithValue("?ganan", gananciagral)
                    .AddWithValue("?calcpre", calcularprecio)
                End With
                'MsgBox(sqlQuery)
                comandoadd.ExecuteNonQuery()
                registroactual += 1
                sqlQueryadd_INSPref = "insert into fact_insumos (id"
                sqlQueryadd_INS = ""
                sqlQueryadd_INSValPref = ") values (?id"
                sqlQueryadd_INSVal = ""

                sqlQueryupd_UPDPref = ") On duplicate key update iva=?iva"
                sqlQueryupd_UPDVal = ""
                conexionSEC.Close()
                ImportarListaPrecios.ReportProgress(CInt((registroactual / dtimportados.RowCount) * 100))
            Next

        Catch ex As Exception

            conexionSEC.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function ObtenerIDproducto(ByRef codigoProd As String) As String
        Try
            If conexionPrinc.State = ConnectionState.Closed Then
                conexionPrinc.Open()
            End If
            If codigoProd = "" Then
                codigoProd = "0"
            End If
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id FROM fact_insumos  where codigo Like '" & Replace(codigoProd, "'", "") & "'", conexionPrinc)
            Dim tablaprod As New DataTable
            consulta.Fill(tablaprod)
            If tablaprod.Rows.Count <> 0 Then
                Return tablaprod.Rows(0).Item(0)
            Else
                Return ""
            End If
            conexionPrinc.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conexionPrinc.Close()
            Return "''"
        End Try
    End Function

    Private Sub ImportarListaPrecios_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles ImportarListaPrecios.ProgressChanged
        frmprincipal.pbprincipal.Value = e.ProgressPercentage
        lblcantprod.Text = e.ProgressPercentage & "%"
    End Sub

    Private Sub ImportarListaPrecios_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles ImportarListaPrecios.RunWorkerCompleted
        frmprincipal.pbprincipal.Visible = False
        cmdimportar.Enabled = True
        MsgBox("Proceso completado!")
    End Sub

    Private Sub cmdpromoprod_Click(sender As Object, e As EventArgs)
        Try
            Dim porcentajeDesc As Double = InputBox("Ingrese el porcentaje de descuento que desa aplicar a este producto", "Aplicar promocion a producto", "10")
            If IsNothing(porcentajeDesc) Or Not IsNumeric(porcentajeDesc) Or porcentajeDesc = "" Then
                MsgBox("valor invalido")
                Exit Sub
            Else
                Reconectar()
                Dim comandoad As New MySql.Data.MySqlClient.MySqlCommand("", conexionPrinc)
                comandoad.ExecuteNonQuery()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdpromocion_Click(sender As Object, e As EventArgs) Handles cmdpromocion.Click

        agregarpromo.categoria = cmbcatProdGral.SelectedValue
        agregarpromo.idproducto = dtproductos.CurrentRow.Cells(0).Value
        agregarpromo.codigo = dtproductos.CurrentRow.Cells(2).Value
        agregarpromo.Show()
        agregarpromo.TopMost = True

    End Sub

    Private Sub txtutilidad1_KeyUp(sender As Object, e As KeyEventArgs) Handles txtutilidad1.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
                calcularPrecios()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtutilidad1_Leave(sender As Object, e As EventArgs) Handles txtutilidad1.Leave
        Try

            DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
            calcularPrecios()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtutilidad2_KeyUp(sender As Object, e As KeyEventArgs) Handles txtutilidad2.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
                calcularPrecios()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtutilidad2_Leave(sender As Object, e As EventArgs) Handles txtutilidad2.Leave
        Try

            DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
            calcularPrecios()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub dtdescuentos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtdescuentos.CellEndEdit
        Try
            Dim compramin As Double = dtdescuentos.CurrentRow.Cells(2).Value
            Dim descuento As Double = dtdescuentos.CurrentRow.Cells(3).Value
            Dim iddesc As Integer = dtdescuentos.CurrentRow.Cells(0).Value
            Reconectar()
            Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_promociones set compra_min='" & compramin & "', descuento_porc='" & descuento & "' " &
            "where id=" & iddesc, conexionPrinc)
            comandoupd.ExecuteNonQuery()
            MsgBox("Promocion actualizada")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellContentClick

    End Sub

    Private Sub cmdSeleccionar_Click(sender As Object, e As EventArgs) Handles cmdSeleccionar.Click
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        Dim ficheros As String

        Try
            dlAbrir.Filter = "Archivos de imagen (*.jpg)|*.jpg"
            dlAbrir.Multiselect = False
            dlAbrir.Title = "Selección de archivo"
            dlAbrir.ShowDialog()
            If dlAbrir.FileName <> "" Then
                ficheros = dlAbrir.FileName
                lbldireccionimagen.Text = ficheros
                imgFoto.Image = Image.FromFile(ficheros)
            End If

            ''Dim i As Integer
            ''For i = 0 To 3
            ''dtproductos.Columns(0).HeaderText = "DESCRIPCION"
            'dtproductos.Columns(1).HeaderText = "COD_BARR"
            'dtproductos.Columns(2).HeaderText = "PRESENTACION"
            ''dtproductos.Columns(3).HeaderText = "COSTO"
            ''Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub txtcosto_TextChanged(sender As Object, e As EventArgs) Handles txtcosto.TextChanged

    End Sub

    Private Sub chkcalcularcosto_CheckedChanged(sender As Object, e As EventArgs) Handles chkcalcularcosto.CheckedChanged
        My.Settings.calcCosto = chkcalcularcosto.CheckState
        My.Settings.Save()

    End Sub
End Class