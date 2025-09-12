Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Data
Imports System.Data.OleDb
Public Class productos
    Dim modificaProd As Boolean
    Dim imprimirlist As Boolean
    Dim imprimirEtiqu As Boolean
    Dim elimColumn As Boolean
    Dim proveedorimport As Integer
    Dim categoriaimport As Integer
    Dim idProductoGral As Integer

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
        If My.Settings.calcCosto = 1 Then chkcalcularcosto.CheckState = CheckState.Checked
        cmbOrdenarPor.SelectedIndex = 0

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

        lblstock.Text = 0
        txtutilidad0.Text = 0
        txtutilidad1.Text = 0
        txtutilidad2.Text = 0
        txtutilidad3.Text = 0
        txtutilidad4.Text = 0
        txtutilidad5.Text = 0
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

            Dim orderBy As String = ""
            Select Case cmbOrdenarPor.SelectedIndex
                Case -1
                    orderBy = " order by id asc"
                Case 0
                    orderBy = " order by descripcion asc"
                Case 1
                    orderBy = " order by codigo asc"
            End Select

            Dim BusquedaComp As String

            If My.Settings.metodoBusquedaProd = 1 Then
                BusquedaComp = Replace(nombre, " ", "%")
                busqtxt = " descripcion like '%" & BusquedaComp & "%' or codigo like '" & nombre & "'"
            ElseIf My.Settings.metodoBusquedaProd = 0 Then
                busqtxt = " descripcion like '" & nombre & "%' or codigo like '" & nombre & "'"
            Else
                busqtxt = " descripcion like '%' or codigo like '" & nombre & "'"
            End If
            If chkstock.CheckState = CheckState.Checked Then
                busqStock = " having stock>0 "
            Else
                busqStock = "  "

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

            cadenaComp = busqNomb & " And " & busqCat & busqCod & busqStock & orderBy

            'MsgBox(cadenaComp)

            If imprimirlist = False Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id as CodInterno, descripcion as Producto, codigo as Codigo 
                FROM fact_insumos as pro " & cadenaComp, conexionPrinc)
                Dim tablaprod As New DataTable
                'MsgBox(consulta.SelectCommand.CommandText)
                'Dim filasProd() As DataRow
                consulta.Fill(tablaprod)
                DgvProductos.Cargar_Datos(tablaprod)
                'dtproductos.DataSource = tablaprod
                'dtproductos.Columns(0).Visible = False
            ElseIf imprimirEtiqu = True Then
                Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
                Dim fac As New datosfacturas
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select pro.id as CodInterno, pro.descripcion, pro.codigo as PLU,
                (select sum(replace(stock,',','.')) from fact_insumos_lotes  where idproducto=pro.id) as Stock,   
                case (select position('%' in listas.utilidad) from fact_listas_precio as listas where listas.id=@idlst)
                when 0 then
                format(
						replace(replace(pro.precio,'.',''),',','.') *
						((select mon.cotizacion from fact_moneda as mon where mon.id=pro.moneda)) *
						((pro.iva+100)/100) *
                        case(select listas.auxcol from fact_listas_precio as listas where listas.id=@idlst) 
							when 0 then
								((replace(replace(pro.ganancia,'.',''),',','.') +100)/100)
							when 1 then
								((replace(replace(pro.utilidad1,'.',''),',','.')+100)/100)
							when 2 then
								((replace(replace(pro.utilidad2,'.',''),',','.')+100)/100)
							when 3 then
								((replace(replace(pro.utilidad3,'.',''),',','.')+100)/100)
							when 4 then
								((replace(replace(pro.utilidad4,'.',''),',','.')+100)/100)
							when 5 then
								((replace(replace(pro.utilidad5,'.',''),',','.')+100)/100)
                                end *
                        (((select listas.utilidad from fact_listas_precio as listas where listas.id=@idlst)+100)/100)
				,2,'es_AR')
                when 1 then
                format(
						replace(replace(pro.precio,'.',''),',','.') *
						((select mon.cotizacion from fact_moneda as mon where mon.id=pro.moneda)) *
						((pro.iva+100)/100) *						
						(((select substring(listas.utilidad from 2) from fact_listas_precio as listas where listas.id=@idlst)+100)/100)
				,2,'es_AR')
                end as precio, 
                
                cat.nombre as categoria
                from fact_insumos as pro, fact_categoria_insum as cat " & cadenaComp, conexionPrinc)
                Dim tablaprod As New DataTable
                consulta.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@idlst", MySql.Data.MySqlClient.MySqlDbType.Text))
                consulta.SelectCommand.Parameters("@idlst").Value = dtlistas.CurrentRow.Cells(3).Value

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
                    .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\productosetiquetas.rdlc"
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

            ' dtproductos.Columns(0).Width = 40
            'dtproductos.Columns(2).Width = 60

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
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select concat(nombre ,' (',utilidad,'%)'), format(utilidad,2,'es_AR'), auxcol from fact_listas_precio order by id asc", conexionPrinc)
            Dim tablalist As New DataTable
            Dim i As Integer
            Dim infolist() As DataRow
            consulta.Fill(tablalist)

            infolist = tablalist.Select("")
            For i = 0 To infolist.GetUpperBound(0)
                Dim etiqueta As String = "lblutilidad" & i
                Dim textbox As String = "txtutilidad" & i
                DirectCast(ObtenerReferenciaControl_tabpage(etiqueta, tabcostos), Label).Visible = True
                DirectCast(ObtenerReferenciaControl_tabpage(textbox, tabcostos), TextBox).Visible = True
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
            Dim precioCosto As Double = FormatNumber(txtcosto.Text, 4)
            Dim cotizacion As Double = FormatNumber(lblcotizacion.Text, 3)
            Dim iva As Double = (FormatNumber(txtiva.Text) + 100) / 100
            Dim util As Double = (FormatNumber(txtutilidad0.Text) + 100) / 100
            Dim util1 As Double = (FormatNumber(txtutilidad1.Text) + 100) / 100
            Dim util2 As Double = (FormatNumber(txtutilidad2.Text) + 100) / 100
            Dim util3 As Double = (FormatNumber(txtutilidad3.Text) + 100) / 100
            Dim util4 As Double = (FormatNumber(txtutilidad4.Text) + 100) / 100
            Dim util5 As Double = (FormatNumber(txtutilidad5.Text) + 100) / 100

            Dim util2sum As Double = FormatNumber(txtutilidad2.Text)

            Dim costoUtil As Double
            Dim costoFinal As Double
            Dim idc As Double = FormatNumber(txtIDC.Text, 3)
            Dim icl As Double = FormatNumber(txtICL.Text, 3)


            Dim tipoproducto As Integer = cmbtipoprod.SelectedIndex

            If tipoproducto = 2 Then
                costoFinal = (precioCosto * iva) + idc + icl
                txtcostofinal.Text = Math.Round(costoFinal, 3)
                Dim i As Integer
                For i = 0 To dtlistas.RowCount - 1
                    Dim utilidad As Double = dtlistas.Rows(i).Cells(1).Value
                    Dim utilListSum As Double = (utilidad * 100) - 100
                    Dim sumaUtil As Double = (utilListSum + util2sum + 100) / 100

                    If dtlistas.Rows(i).Cells(3).Value.ToString = "%" Then
                        dtlistas.Rows(i).Cells(2).Value = (precioCosto * utilidad * iva) + idc + icl
                    Else
                        'MsgBox("aca")
                        Select Case dtlistas.Rows(i).Cells(4).Value


                            Case 0

                                dtlistas.Rows(i).Cells(2).Value = (precioCosto * ((utilidad + util) - 1) * iva) + idc + icl   'costoFinal * ((utilidad + util) - 1)

                            Case 1

                                dtlistas.Rows(i).Cells(2).Value = (precioCosto * ((utilidad + util1) - 1) * iva) + idc + icl

                            Case 2

                                dtlistas.Rows(i).Cells(2).Value = (precioCosto * ((utilidad + util2) - 1) * iva) + idc + icl

                            Case 3

                                dtlistas.Rows(i).Cells(2).Value = (precioCosto * ((utilidad + util3) - 1) * iva) + idc + icl

                            Case 4

                                dtlistas.Rows(i).Cells(2).Value = (precioCosto * ((utilidad + util4) - 1) * iva) + idc + icl

                            Case 5

                                dtlistas.Rows(i).Cells(2).Value = (precioCosto * ((utilidad + util5) - 1) * iva) + idc + icl

                        End Select
                    End If
                Next
            Else
                costoFinal = precioCosto * iva * cotizacion
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

                precioCosto = 0
                cotizacion = 0
                iva = 0
            End If


            'costoUtil = costoFinal * util
            'MsgBox(precioCosto & "*" & iva & "*" & cotizacion)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarInfoProd(ByRef codigo As Integer)
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT pro.*, (select sum(replace(stock,',','.')) from fact_insumos_lotes  where idproducto=pro.id) as stock,   
            (select peso from cm_pesoEspecifico  where id=pro.id) as PEspecifico
            from fact_insumos as pro where pro.id = " & codigo, conexionPrinc)
            'MsgBox(consulta.SelectCommand.CommandText)

            Dim tablaprod As New DataTable
            Dim infoProd() As DataRow
            consulta.Fill(tablaprod)
            infoProd = tablaprod.Select("descripcion like '%'")
            cmbmoneda.SelectedValue = infoProd(0)("moneda")
            txtproducto.Text = infoProd(0)("descripcion")

            cmbcatprod.SelectedValue = infoProd(0)("categoria")
            cmbmarcas.SelectedValue = infoProd(0)("marca")
            cmbmodelos.SelectedValue = infoProd(0)("modelo")
            txtbonificacionMax.Text = infoProd(0)("bonif")
            If infoProd(0)("calcular_precio") = 0 Then
                txtpreciobase.Text = infoProd(0)("precio")
                txtcosto.Text = 0
                chkpreciobase.CheckState = CheckState.Unchecked
            ElseIf infoProd(0)("calcular_precio") = 1 Then
                txtcosto.Text = infoProd(0)("precio")
                txtpreciobase.Text = 0
                chkpreciobase.CheckState = CheckState.Checked
            End If
            txtutilidad0.Text = infoProd(0)("ganancia")
            txtutilidad1.Text = infoProd(0)("utilidad1")
            txtutilidad2.Text = infoProd(0)("utilidad2")
            txtutilidad3.Text = infoProd(0)("utilidad3")
            txtutilidad4.Text = infoProd(0)("utilidad4")
            txtutilidad5.Text = infoProd(0)("utilidad5")
            txtiva.Text = infoProd(0)("iva")

            txtplu.Text = infoProd(0)("cod_bar")
            'txtcodprov.Text = 
            'If infoProd(0)(7) <> 0 Then
            cmbproveedor.SelectedValue = infoProd(0)("codprov")
            ' Else
            'cmbproveedor.SelectedIndex = 
            'End If

            txtgarantia.Text = infoProd(0)("garantia")
            txtinfoextra.Text = infoProd(0)("detalles")
            txtcodigo.Text = infoProd(0)("codigo")
            cmbtipoprod.SelectedIndex = infoProd(0)("tipo")
            ''si es combustible habilitamos otras opciones
            If infoProd(0)("tipo") = 2 Then
                grpImpuestosCombustibles.Visible = True
                txtIDC.Text = infoProd(0)("impuestoFijo01")
                txtICL.Text = infoProd(0)("impuestoFijo02")
            End If

            'txtutilidad0.Text = infoProd(0)("ganancia")
            cmbunidades.SelectedValue = infoProd(0)("unidades")
            ' MsgBox(infoProd(0)(24))
            lblultimaMod.Text = infoProd(0)("fechaMod").ToString
            cmbpresentacion.Text = infoProd(0)("presentacion")
            If Not IsDBNull(infoProd(0)("foto")) Then
                imgFoto.Image = Bytes_Imagen(infoProd(0)("foto"))
            Else
                imgFoto.Image = Image.FromFile(Application.StartupPath & "\sinimagen.jpg")
            End If
            If Not IsDBNull(infoProd(0)("PEspecifico")) Then
                txtPesoEspecifico.Text = infoProd(0)("PEspecifico").ToString
            Else
                txtPesoEspecifico.Text = 0
            End If
            txtmultiplStock.Text = infoProd(0)("desc_cantidad")

            If IsDBNull(infoProd(0)("stock")) Then
                ' MsgBox("nada")

                lblstock.Text = "0"
                dtlotesprov.DataSource = Nothing
            Else
                'MsgBox(infoProd(0)("id") & "_____" & infoProd(0)("stock"))
                'MsgBox("haystock--" & infoProd(0)(27))
                lblstock.Text = infoProd(0)("stock") '.ToString
                Reconectar()
                dtlotesprov.DataSource = Nothing
                If cmbtipoprod.SelectedIndex = 0 Then
                    Dim consProv As New MySql.Data.MySqlClient.MySqlDataAdapter("select concat(lt.nombre,' - ' , pfac.fecha) as LoteFcompra,
                    pfac.numero, pro.razon as Proveedor, lt.compracant as CantidadComprada,
                    (select nombre from fact_insumos_almacenes where id=lt.idalmacen) as Almacen
                    from fact_insumos_lotes as lt, fact_proveedores as pro, fact_proveedores_fact as pfac 
                    where  pro.id = pfac.idproveedor and lt.idfactura=pfac.id and idproducto='" & codigo & "'			
                    order by lt.id  desc", conexionPrinc)
                    'MsgBox(consProv.SelectCommand.CommandText)
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

            'Button8.PerformClick()
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
    Private Sub ProductoSeleccionado(IdProducto As Integer) Handles DgvProductos.SeleccionarItem
        idProductoGral = IdProducto

        CargarInfoProd(idProductoGral)
        calcularPrecios()
        cargarDescuentos()



    End Sub
    Private Sub dtproductos_CellEnter(sender As Object, e As DataGridViewCellEventArgs)
        'vaciarControles()

    End Sub

    Private Sub cargarDescuentos()
        Try
            dtdescuentos.Rows.Clear()
            Reconectar()
            Dim consultaDescProd As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT prom.id,concat(prom.nombrepromo,' ', prom.descuento_porc ,'%'),prom.compra_min,prom.descuento_porc " &
            "From fact_promociones As prom, fact_insumos As ins Where ins.id = prom.idproducto and prom.idproducto=" & idProductoGral, conexionPrinc)
            Dim tablaDescProd As New DataTable
            Dim filasDescProd() As DataRow
            consultaDescProd.Fill(tablaDescProd)
            filasDescProd = tablaDescProd.Select("")

            Reconectar()
            Dim consultaDescCat As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT prom.id,concat(prom.nombrepromo,' ', prom.descuento_porc ,'%'),prom.compra_min,prom.descuento_porc " &
            "From fact_promociones As prom Where  prom.idCategoria=" & cmbcatprod.SelectedValue, conexionPrinc)
            Dim tablaDescCat As New DataTable
            Dim filasDescCat() As DataRow
            consultaDescCat.Fill(tablaDescCat)
            filasDescCat = tablaDescCat.Select("")

            For i As Integer = 0 To tablaDescProd.Rows.Count - 1
                dtdescuentos.Rows.Add(filasDescProd(i)(0), filasDescProd(i)(1), filasDescProd(i)(2), filasDescProd(i)(3))
            Next

            For i As Integer = 0 To tablaDescCat.Rows.Count - 1
                dtdescuentos.Rows.Add(filasDescCat(i)(0), filasDescCat(i)(1), filasDescCat(i)(2), filasDescCat(i)(3))
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
            txtutilidad0.Text = txtutilidad0.Text

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
                    txtutilidad0.Focus()
                    'calcularPrecios()
                Else
                    txtcosto.Text = txtcosto.Text
                    txtutilidad0.Focus()
                    calcularPrecios()

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtiva_KeyUp(sender As Object, e As KeyEventArgs) Handles txtiva.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                '  txtiva.Text = txtiva.Text 'remplazarcoma(txtiva.Text)
                calcularPrecios()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtutilidad_KeyUp(sender As Object, e As KeyEventArgs) Handles txtutilidad0.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                '   DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
                calcularPrecios()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtutilidad_Leave(sender As Object, e As EventArgs) Handles txtutilidad0.Leave
        Try

            'DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
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
            Dim utilidad As String = txtutilidad0.Text
            Dim utilidad1 As String = txtutilidad1.Text
            Dim utilidad2 As String = txtutilidad2.Text
            Dim utilidad3 As String = txtutilidad3.Text
            Dim utilidad4 As String = txtutilidad4.Text
            Dim utilidad5 As String = txtutilidad5.Text

            Dim codigo As String = txtcodigo.Text
            Dim tipo As String = cmbtipoprod.SelectedIndex
            Dim calcular_precio As Integer
            Dim unidades As Integer = cmbunidades.SelectedValue
            Dim bonificacion As String = ""
            Dim desc_cantidad As String = txtmultiplStock.Text
            Dim idc As String = txtIDC.Text
            Dim icl As String = txtICL.Text
            If txtbonificacionMax.Text = "" Then bonificacion = 0 Else bonificacion = txtbonificacionMax.Text
            If codigo <> "" And modificaProd = False Then
                If ExisteProducto(codigo) = True Then
                    MsgBox("ya existe un producto con el CODIGO DE BARRA indicado, por favor verifique")
                    Exit Sub
                End If
            End If
            Dim presentacion As String
            If chkpreciobase.CheckState = CheckState.Checked Then calcular_precio = 1 Else calcular_precio = 0
            If cmbpresentacion.Text = 0 Or cmbpresentacion.Text = "" Then
                presentacion = 1
            Else
                presentacion = cmbpresentacion.Text
            End If

            Dim moneda As Integer = cmbmoneda.SelectedValue
            Dim foto As Byte() = Imagen_Bytes(imgFoto.Image)

            If tipo = 2 Then

                Dim sqlQuery As String

                If modificaProd = False Then
                    sqlQuery = "insert into fact_insumos 
                (descripcion, precio, ganancia, garantia, iva, codprov, categoria, marca, modelo, detalles, cod_bar, 
                moneda,utilidad1,utilidad2, tipo, codigo, calcular_precio,unidades,presentacion,foto,bonif,utilidad3,
                utilidad4,utilidad5,desc_cantidad,impuestoFijo01,impuestoFijo02) values 
                (?desc, ?prec, ?gan, ?gar, ?iva, ?codprov, ?cat, ?marca, ?modelo, ?det, ?plu, 
                ?mone,?uti1,?uti2,?tipo,?codigo,?calcpcio,?unid,?present,?foto,?bonif,?util3,?util4,?util5,
                ?desc_cantidad,?impuestoFijo01,?impuestoFijo02)"
                ElseIf modificaProd = True Then
                    sqlQuery = "update fact_insumos set descripcion=?desc, precio=?prec, ganancia=?gan, garantia=?gar, iva=?iva, 
                codprov=?codprov, categoria=?cat, marca=?marca,modelo=?modelo, detalles=?det,cod_bar=?plu, moneda=?mone,
                utilidad1=?uti1,utilidad2=?uti2, tipo=?tipo, codigo=?codigo, calcular_precio=?calcpcio,unidades=?unid, 
                presentacion=?present, foto=?foto, bonif=?bonif, utilidad3=?util3, utilidad4=?util4, utilidad5=?util5,
                desc_cantidad=?desc_cantidad, impuestoFijo01=?impuestoFijo01,impuestoFijo02=?impuestoFijo02 where id=?idp"
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
                    .AddWithValue("?bonif", bonificacion)
                    .AddWithValue("?util3", utilidad3)
                    .AddWithValue("?util4", utilidad4)
                    .AddWithValue("?util5", utilidad5)
                    .AddWithValue("?desc_cantidad", desc_cantidad)
                    .AddWithValue("?impuestoFijo01", idc)
                    .AddWithValue("?impuestoFijo02", icl)

                    If modificaProd = True Then
                        '    Dim idProducto As Integer = DgvProductos.dgvVista.CurrentRow.Cells(0).Value  'dtproductos.CurrentRow.Cells(0).Value
                        .AddWithValue("?idp", idProductoGral)
                    End If

                End With
                comandoadd.ExecuteNonQuery()

                If txtPesoEspecifico.Text <> "" And IsNumeric(txtPesoEspecifico.Text) Then
                    Dim PesoEspecifio As String = txtPesoEspecifico.Text.Replace(".", ",")
                    Reconectar()
                    Dim comandoPesoEsp As New MySql.Data.MySqlClient.MySqlCommand("insert into cm_pesoEspecifico (id,peso) values (?id,?peso) 
                on duplicate key update peso=?peso", conexionPrinc)
                    comandoPesoEsp.Parameters.AddWithValue("?id", idProductoGral)
                    comandoPesoEsp.Parameters.AddWithValue("?peso", PesoEspecifio)

                    comandoPesoEsp.ExecuteNonQuery()
                End If
            Else
                'Dim stock As String = txtstoked.Text
                Reconectar()
                'If categoria = 0 And cmbcatprod.Text = "" Then
                '    Dim comandoad As New MySql.Data.MySqlClient.MySqlCommand(
                '        "insert into fact_categoria_insum(nombre) values('" & cmbcatprod.Text.ToUpper & "')", conexionPrinc)
                '    '   "SET @ID_CAT=(select MAX(id) from fact_categoria_insum where nombre like '" & cmbcatprod.Text.ToUpper & "');
                '    '   insert into  fact_categoria_insum (id,nombre) values 
                '    '   (@ID_CAT,'" & cmbcatprod.Text.ToUpper & "')
                '    '   ON DUPLICATE KEY UPDATE 
                '    'nombre= '" & cmbcatprod.Text.ToUpper & "'", conexionPrinc)
                '    comandoad.ExecuteNonQuery()
                '    categoria = comandoad.LastInsertedId
                'End If

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
                    sqlQuery = "insert into fact_insumos 
                (descripcion, precio, ganancia, garantia, iva, codprov, categoria, marca, modelo, detalles, cod_bar, 
                moneda,utilidad1,utilidad2, tipo, codigo, calcular_precio,unidades,presentacion,foto,bonif,utilidad3,utilidad4,utilidad5,desc_cantidad) values 
                (?desc, ?prec, ?gan, ?gar, ?iva, ?codprov, ?cat, ?marca, ?modelo, ?det, ?plu, 
                ?mone,?uti1,?uti2,?tipo,?codigo,?calcpcio,?unid,?present,?foto,?bonif,?util3,?util4,?util5,?desc_cantidad)"
                ElseIf modificaProd = True Then
                    sqlQuery = "update fact_insumos set descripcion=?desc, precio=?prec, ganancia=?gan, garantia=?gar, iva=?iva, 
                codprov=?codprov, categoria=?cat, marca=?marca,modelo=?modelo, detalles=?det,cod_bar=?plu, moneda=?mone,
                utilidad1=?uti1,utilidad2=?uti2, tipo=?tipo, codigo=?codigo, calcular_precio=?calcpcio,unidades=?unid, 
                presentacion=?present, foto=?foto, bonif=?bonif, utilidad3=?util3, utilidad4=?util4, utilidad5=?util5,desc_cantidad=?desc_cantidad where id=?idp"
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
                    .AddWithValue("?bonif", bonificacion)
                    .AddWithValue("?util3", utilidad3)
                    .AddWithValue("?util4", utilidad4)
                    .AddWithValue("?util5", utilidad5)
                    .AddWithValue("?desc_cantidad", desc_cantidad)
                    If modificaProd = True Then
                        '    Dim idProducto As Integer = DgvProductos.dgvVista.CurrentRow.Cells(0).Value  'dtproductos.CurrentRow.Cells(0).Value
                        .AddWithValue("?idp", idProductoGral)
                    End If

                End With
                comandoadd.ExecuteNonQuery()

                If txtPesoEspecifico.Text <> "" And IsNumeric(txtPesoEspecifico.Text) Then
                    Dim PesoEspecifio As String = txtPesoEspecifico.Text.Replace(".", ",")
                    Reconectar()
                    Dim comandoPesoEsp As New MySql.Data.MySqlClient.MySqlCommand("insert into cm_pesoEspecifico (id,peso) values (?id,?peso) 
                on duplicate key update peso=?peso", conexionPrinc)
                    comandoPesoEsp.Parameters.AddWithValue("?id", idProductoGral)
                    comandoPesoEsp.Parameters.AddWithValue("?peso", PesoEspecifio)

                    comandoPesoEsp.ExecuteNonQuery()
                End If
            End If
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
            funciones_Globales.GuardarConfiguracionTerminal()
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
        txtmultiplStock.Text = 1

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
                sqlquery = "delete from fact_insumos where id=" & DgvProductos.dgvVista.CurrentRow.Cells(0).Value
                Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand(sqlquery, conexionPrinc)
                comandoupd.ExecuteNonQuery()
                DgvProductos.dgvVista.Rows.Remove(DgvProductos.dgvVista.CurrentRow)
                MsgBox("Producto eliminado")
                cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProdGral.SelectedValue)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            imprimirEtiqu = True

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

                Dim dt As DataTable = GetDataExcel(ficheros, ObtenerNombrePrimeraHoja(ficheros)) 'GetDataExcel(ficheros, InputBox("Ingrese nombre de la hoja de excel", "Importar lista de precios", "Hoja1"))
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
            For Each columna As DataGridViewColumn In DgvProductos.dgvVista.Columns
                columna.SortMode = DataGridViewColumnSortMode.NotSortable

            Next
        Else
            Button4.BackColor = Color.Red
            Me.Cursor = Cursors.Hand
            elimColumn = True
            For Each columna As DataGridViewColumn In DgvProductos.dgvVista.Columns
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
            Dim desc_cantidad As String
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

                If chkimportDescCantidad.CheckState = CheckState.Checked Then
                    desc_cantidad = producto.Cells(i).Value.ToString
                    i += 1

                    sqlQueryadd_INS = sqlQueryadd_INS & ",desc_cantidad"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?desc_cantidad"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",desc_cantidad=?desc_cantidad"
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
                    .AddWithValue("?desc_cantidad", desc_cantidad)
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
        Try
            agregarpromo.categoria = cmbcatProdGral.SelectedValue
            agregarpromo.idproducto = DgvProductos.dgvVista.CurrentRow.Cells(0).Value
            agregarpromo.codigo = DgvProductos.dgvVista.CurrentRow.Cells(2).Value
            agregarpromo.Show()
            agregarpromo.TopMost = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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
            MsgBox("actualizado correctamente")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

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
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub chkcalcularcosto_CheckedChanged(sender As Object, e As EventArgs) Handles chkcalcularcosto.CheckedChanged
        My.Settings.calcCosto = chkcalcularcosto.CheckState
        My.Settings.Save()
        funciones_Globales.GuardarConfiguracionTerminal()

    End Sub

    Private Sub cmbOrdenarPor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbOrdenarPor.SelectionChangeCommitted
        imprimirlist = False
        cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProdGral.SelectedValue)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT max(" & My.Settings.obtCodProd & ")+1 as ProxCod FROM fact_insumos 
            having ProxCod not in(select " & My.Settings.obtCodProd & " from fact_insumos )", conexionPrinc)
            Dim tablaprod As New DataTable
            consulta.Fill(tablaprod)
            'If tablaprod.Rows.Count <> 0 Then
            txtcodigo.Text = tablaprod(0)(0)
            'Else
            'Dim numaleat As New Random(CInt(DateTime.Now.Ticks And 999999))
            '    txtcodigo.Text = numaleat.Next
            'End If
            conexionPrinc.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtutilidad3_KeyUp(sender As Object, e As KeyEventArgs) Handles txtutilidad3.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
                calcularPrecios()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtutilidad4_KeyUp(sender As Object, e As KeyEventArgs) Handles txtutilidad4.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
                calcularPrecios()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged

    End Sub

    Private Sub txtbuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                cargarProductos(busqCod(txtbuscar.Text), busqNomb(txtbuscar.Text), cmbcatProdGral.SelectedValue)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
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

        EnProgreso.Show()
        Application.DoEvents()
        'If cmbvendedor.SelectedIndex = -1 Or Val(txtmesesvtasCliente.Text) = 0 Or Idcliente = 0 Then
        '    MsgBox("Debe seleccionar un cliente y establecer una cantidad de meses para ver")
        '    Exit Sub
        'End If
        txtProductoDescripicionHistorial.Text = txtproducto.Text
        dgvHistorialProductos.DataSource = Nothing
        Dim SqLCons As String
        Try
            Reconectar()
            'If chkHistorialPorProductos.Checked = True Then
            SqLCons = "select itm.cod,itm.descripcion, 
            concat('(',format(sum(itm.cantidad),2,'es_AR'),')',format(sum(itm.ptotal),2,'es_AR'))as totalVenta,
            concat(monthname(fact.fecha),'-',YEAR(fact.fecha)) as Periodo
            from fact_facturas as fact, fact_clientes as cli,fact_items as itm
            where fact.id_cliente= cli.idclientes and fact.id=itm.id_fact
            and fact.tipofact in (select donfdesc from tipos_comprobantes where debcred like 'D') 
            and fact.fecha between date_sub(date_format(now(),'%Y-%m-01'),interval " & Val(txtmesesvtasProducto.Text) & " month) and date_format(now(),'%Y-%m-%d')
            and itm.cod=" & idProductoGral & "				
            group by month(fact.fecha),itm.cod order by month(fact.fecha) asc"

            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(SqLCons, conexionPrinc)
            Dim tablaDatosHistorial As New DataTable
            consulta.Fill(tablaDatosHistorial)
            Dim HistorialCliente As New DataTable

            HistorialCliente.Columns.Add("id")
            'HistorialCliente.Columns.Add("desc")
            Dim textocol As String
            Dim existecol As Boolean = False
            For Each datos As DataRow In tablaDatosHistorial.Rows
                textocol = datos.Item(3)
                For Each columna As DataColumn In HistorialCliente.Columns
                    If textocol = columna.ColumnName Then
                        existecol = True
                        Exit For
                    Else
                        existecol = False
                    End If
                Next
                If existecol = False Then
                    HistorialCliente.Columns.Add(textocol)
                End If
            Next

            Dim idclie As String
            Dim nomapell As String
            Dim totalvta As String
            Dim periodo As String
            Dim AgregarFila As Boolean
            tablaDatosHistorial.DefaultView.Sort = "cod asc"
            tablaDatosHistorial = tablaDatosHistorial.DefaultView.ToTable
            For Each datos As DataRow In tablaDatosHistorial.Rows
                idclie = datos.Item(0)
                ' nomapell = datos.Item(1)
                totalvta = datos.Item(2)
                periodo = datos.Item(3)

                If HistorialCliente.Rows.Count = 0 Then
                    AgregarFila = True
                Else
                    For Each dtosHistorial As DataRow In HistorialCliente.Rows
                        If dtosHistorial.Item("id") = idclie Then
                            dtosHistorial.Item(periodo) = totalvta
                            AgregarFila = False
                        Else
                            AgregarFila = True
                        End If
                    Next
                End If

                If AgregarFila = True Then
                    Dim fila As DataRow = HistorialCliente.NewRow()
                    fila("id") = idclie
                    'fila("desc") = nomapell
                    fila(periodo) = totalvta
                    HistorialCliente.Rows.Add(fila)
                End If
            Next

            dgvHistorialProductos.DataSource = HistorialCliente
            dgvHistorialProductos.Columns(0).Visible = False
            EnProgreso.Close()
        Catch ex As Exception
            EnProgreso.Close()

        End Try
    End Sub

    Private Sub DgvProductos_Load(sender As Object, e As EventArgs) Handles DgvProductos.Load

    End Sub

    Private Sub DgvProductos_MouseEnter(sender As Object, e As EventArgs) Handles DgvProductos.MouseEnter

    End Sub

    Private Sub txtcosto_TextChanged(sender As Object, e As EventArgs) Handles txtcosto.TextChanged

    End Sub

    Private Sub cmbtipoprod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtipoprod.SelectedIndexChanged

    End Sub

    Private Sub cmbtipoprod_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbtipoprod.SelectedValueChanged
        If cmbtipoprod.Text = "COMBUSTIBLES" Then
            grpImpuestosCombustibles.Visible = True
        Else
            grpImpuestosCombustibles.Visible = False
        End If
    End Sub

    Private Sub txtIDC_TextChanged(sender As Object, e As EventArgs) Handles txtIDC.TextChanged

    End Sub

    Private Sub txtutilidad0_TextChanged(sender As Object, e As EventArgs) Handles txtutilidad0.TextChanged

    End Sub

    Private Sub txtIDC_Layout(sender As Object, e As LayoutEventArgs) Handles txtIDC.Layout

    End Sub

    Private Sub txtIDC_KeyUp(sender As Object, e As KeyEventArgs) Handles txtIDC.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                '   DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
                calcularPrecios()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtIDC_Leave(sender As Object, e As EventArgs) Handles txtIDC.Leave
        '   DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
        calcularPrecios()
    End Sub

    Private Sub txtICL_TextChanged(sender As Object, e As EventArgs) Handles txtICL.TextChanged

    End Sub

    Private Sub txtICL_KeyUp(sender As Object, e As KeyEventArgs) Handles txtICL.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                '   DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text 'remplazarcoma(txtutilidad.Text)
                calcularPrecios()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtICL_Leave(sender As Object, e As EventArgs) Handles txtICL.Leave

        calcularPrecios()

    End Sub

    Private Sub tabstock_Click(sender As Object, e As EventArgs) Handles tabstock.Click

    End Sub
End Class