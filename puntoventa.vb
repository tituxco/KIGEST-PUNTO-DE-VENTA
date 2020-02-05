Imports System.Drawing.Printing
Imports System.Security

Public Class puntoventa
    Dim fechagral As String = Format(Now, "dd-MM-yyyy")
    Public idfacrap As Integer
    Public Idcliente As Integer
    Dim nombrefact As String
    Dim abrevfact As String
    Dim ptovta As Integer
    Dim tipofact As Integer
    Dim numfact As Integer
    Dim condVta As Integer = 1
    Public listaPrecios As Integer
    Public IdFactura As Integer
    Dim TipoIVAContr As Integer
    Private Sub puntoventa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblfactfecha.Text = "Fecha: " & fechagral

        If DatosAcceso.StockPpref = 1 Then
            chkquitarstock.CheckState = CheckState.Checked
        End If
        cargar_datos_factura()
        txtcodPLU.Focus()
        If InStr(DatosAcceso.Moduloacc, "1") = False Then Button2.Enabled = False


    End Sub
    Public Sub cargar_datos_factura()
        Try

            Dim consfactrap As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT fr.nombre, fis.abrev, lpad(fr.punto_venta, 4, 0) As ptovta, lpad(fis.confnume + 1, 8, 0) As numfact, fr.tipofact 
            From fact_facturasrapidas As fr, fact_conffiscal As fis, fact_puntosventa As ptovta
            Where fis.donfdesc = fr.tipofact And ptovta.id = fis.ptovta And ptovta.id = fr.punto_venta And fr.id = " & idfacrap, conexionPrinc)
            Dim tablafr As New DataTable
            Dim infofr() As DataRow
            consfactrap.Fill(tablafr)
            'If tablafr.Rows.Count = 0 Then
            '    MsgBox("No se encuentra la referencia a la factura o punto de venta")
            '    'Me.Close()
            '    Exit Sub
            'End If
            infofr = tablafr.Select("")
            nombrefact = infofr(0)(0)
            lblfactnombre.Text = nombrefact
            abrevfact = infofr(0)(1)
            lblfactabrev.Text = abrevfact
            ptovta = Val(infofr(0)(2))
            lblfactptovta.Text = infofr(0)(2)
            numfact = Val(infofr(0)(3))
            lblfactnumero.Text = infofr(0)(3)
            tipofact = infofr(0)(4)
            lblfacvendedor.Text = DatosAcceso.Vendedor
            lblfacIdAlmacen.Text = DatosAcceso.IdAlmacen

            dtproductos.Rows.Clear()
            If tipofact <> 13 Then
                Idcliente = 9999
                cargarCliente()
            End If
            If ptovta = FacturaElectro.puntovtaelect Then

                cmdsolicitarcae.Enabled = True
                cmdguardar.Enabled = False
                cmdimprimir.Enabled = False
                cmdcerrar.Enabled = True
            Else
                cmdsolicitarcae.Enabled = False
                cmdguardar.Enabled = True
                cmdimprimir.Enabled = False
                cmdcerrar.Enabled = True
            End If
            dtproductos.AllowUserToAddRows = True
            dtproductos.AllowUserToDeleteRows = True
            dtproductos.Enabled = True
            txtclierazon.Enabled = True
            txtcliecta.Enabled = True
            txtcliecuitcuil.Enabled = True
            txtcodPLU.Focus()

            lblfactiva105.Text = 0
            lblfactiva21.Text = 0
            lblfactsubtotal.Text = 0
            lblfacttotal.Text = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub cargarCliente()
        Try
            txtcliecta.Text = Idcliente
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("Select cl.nomapell_razon As clie, cl.dir_domicilio, lc.nombre As localidad, " _
            & "iv.tipo As tipocontr, cl.cuit, lp.nombre As lista_precios, cl.lista_precios,cl.iva_tipo " _
            & "from fact_clientes As cl,  cm_localidad As lc, fact_ivatipo As iv, fact_listas_precio As lp " _
            & "where lc.id= cl.dir_localidad And iv.id = cl.iva_tipo And lp.id = cl.lista_precios And idclientes = " & txtcliecta.Text, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")

            If tipofact = 1 And infocl(0)(7) <> 1 Then
                MsgBox("El tipo de contribuyente no corresponde para el tipo de factura, por favor verifique")
                txtcliecta.Text = ""
                Exit Sub
            Else
                txtclierazon.Text = infocl(0)(0)
                lblcliedomicilio.Text = infocl(0)(1)
                lblclieciudad.Text = infocl(0)(2)
                lblclietipocontr.Text = infocl(0)(3)
                txtcliecuitcuil.Text = infocl(0)(4)
                lblfactcondvta.Text = "CONTADO"
                lblfactlistaprecios.Text = infocl(0)(5)
                listaPrecios = infocl(0)(6)
                TipoIVAContr = infocl(0)(7)
                'txtcodPLU.Focus()

            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtcliecta_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcliecta.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                cargarCliente()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtclierazon_KeyUp(sender As Object, e As KeyEventArgs) Handles txtclierazon.KeyUp
        If e.KeyCode = Keys.Enter Then
            selclie.busqueda = txtclierazon.Text
            selclie.llama = "ptovta"
            selclie.dtpersonal.Focus()
            selclie.Show()
            selclie.TopMost = True
        End If
    End Sub

    Private Sub dtproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
        Try
            If e.ColumnIndex = 1 Then
                If IsNumeric(dtproductos.Rows(e.RowIndex).Cells(1).Value) Then
                    'cargarProdCod(e.RowIndex)
                    ' Else
                    cargarProdPLU(dtproductos.CurrentCell.Value, e.RowIndex)
                End If
                CalcularTotales()
            ElseIf e.ColumnIndex = 2 Then

                Dim pUnit As Double = dtproductos.Rows(e.RowIndex).Cells(5).Value
                Dim cant As Double = dtproductos.Rows(e.RowIndex).Cells(2).Value
                dtproductos.Rows(e.RowIndex).Cells(6).Value = Math.Round(pUnit * cant, 2)
                dtproductos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow

                CalcularTotales()
            ElseIf e.ColumnIndex = 3 Then
                If InStr(dtproductos.Rows(e.RowIndex).Cells(0).Value, "&") = 0 Then
                    If dtproductos.CurrentRow.Cells(1).Value = "" Then
                        selprod.busqueda = dtproductos.CurrentCell.Value()
                        selprod.fila = dtproductos.CurrentCellAddress.Y
                        selprod.LLAMA = "ptovta"
                        'selprod.dtproductos.Focus()
                        selprod.Show()
                        selprod.TopMost = True
                    End If
                End If
            ElseIf e.ColumnIndex = 5 Then
                dtproductos.CurrentCell.Value = dtproductos.CurrentCell.Value
                Dim pUnit As Double = dtproductos.CurrentCell.Value
                Dim cant As Double = dtproductos.Rows(e.RowIndex).Cells(2).Value
                dtproductos.Rows(e.RowIndex).Cells(6).Value = Math.Round(pUnit * cant, 2)
                dtproductos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow



                CalcularTotales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub puntoventa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If

    End Sub

    Public Sub CalcularTotales()
        Try
            ' MsgBox(tipofact)
            Dim i As Integer
            Dim subtotal As Double
            Dim subtotal105 As Double
            Dim subtotal21 As Double
            Dim iva105 As Double
            Dim iva21 As Double
            Dim total As Double

            For Each producto As DataGridViewRow In dtproductos.Rows
                Select Case tipofact
                    Case 999, 11, 12, 13 'factura x,fc,ndc,ncc

                        If producto.Cells(4).Value = "10,5" Then
                            subtotal105 += FormatNumber(producto.Cells(6).Value)
                        ElseIf producto.Cells(4).Value = "21" Then
                            subtotal21 += FormatNumber(producto.Cells(6).Value)
                        Else
                            Exit Sub
                        End If
                        subtotal = Math.Round(subtotal105 + subtotal21, 2)
                        lblfactsubtotal.Text = subtotal
                        lblfacttotal.Text = Math.Round(subtotal + iva105 + iva21, 2)
                    Case 1
                        If producto.Cells(4).Value = "10,5" Then
                            subtotal105 += FormatNumber(producto.Cells(6).Value)
                        ElseIf producto.Cells(4).Value = "21" Then
                            subtotal21 += FormatNumber(producto.Cells(6).Value)

                        Else
                            Exit Sub
                        End If
                        iva105 = Math.Round(subtotal105 * (10.5 / 100), 2)
                        iva21 = Math.Round(subtotal21 * (21 / 100), 2)
                        lblfactiva105.Text = iva105
                        lblfactiva21.Text = iva21
                        txtsub21.Text = subtotal21
                        txtsub105.Text = subtotal105
                        subtotal = Math.Round(subtotal21 + subtotal105, 2)
                        lblfactsubtotal.Text = subtotal
                        lblfacttotal.Text = Math.Round(subtotal + iva105 + iva21, 2)
                    Case 6
                        If producto.Cells(4).Value = "10,5" Then
                            subtotal105 += Math.Round(FormatNumber(producto.Cells(6).Value) / 1.105, 2)
                        ElseIf producto.Cells(4).Value = "21" Then
                            subtotal21 += Math.Round(FormatNumber(producto.Cells(6).Value) / 1.21, 2)
                        Else
                            Exit Sub
                        End If
                        iva105 = Math.Round(subtotal105 * (10.5 / 100), 2)
                        iva21 = Math.Round(subtotal21 * (21 / 100), 2)
                        lblfactiva105.Text = iva105
                        lblfactiva21.Text = iva21
                        txtsub21.Text = subtotal21
                        txtsub105.Text = subtotal105
                        subtotal = Math.Round(subtotal105 + subtotal21, 2)
                        lblfactsubtotal.Text = subtotal
                        lblfacttotal.Text = Math.Round(subtotal + iva105 + iva21, 2)
                End Select

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub cargarProdCod(ByRef fila As Integer)
        Try
            Dim codPLU As String = dtproductos.Rows(fila).Cells(1).Value
            Dim Busq As String
            If codPLU = "" Then
                MsgBox("Debe ingresar un codigo o PLU")
                dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.Red
                Exit Sub
            End If
            If InStr(codPLU, "#") = 1 Then
                Busq = "where cod_bar= " & Microsoft.VisualBasic.Right(codPLU, codPLU.Length - 1)
            ElseIf IsNumeric(codPLU) Then
                Busq = "where id=" & codPLU & " or codigo like '" & codPLU & "'"
            ElseIf Not IsNumeric(codPLU) Then
                Busq = "where  codigo like '" & codPLU & "' or cod_bar like '" & codPLU & "'"
            End If
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,codigo,iva,descripcion FROM fact_insumos " & Busq, conexionPrinc)
            Dim tablaprod As New DataTable
            Dim filasProd() As DataRow
            consulta.Fill(tablaprod)
            filasProd = tablaprod.Select("")
            Dim descuento As Double
            Dim precio As Double
            For i = 0 To filasProd.GetUpperBound(0)
                'MsgBox(filasProd(i)(0))
                dtproductos.Rows(fila).Cells(0).Value = filasProd(i)(0)
                If filasProd(i)(1).ToString = "" Then
                    dtproductos.Rows(fila).Cells(1).Value = filasProd(i)(0)
                Else
                    dtproductos.Rows(fila).Cells(1).Value = filasProd(i)(1)
                End If
                If IsNothing(dtproductos.Rows(fila).Cells(2)) Or dtproductos.Rows(fila).Cells(2).ToString = "0" Or dtproductos.Rows(fila).Cells(2).ToString = "" Then
                    dtproductos.Rows(fila).Cells(2).Value = 1
                End If
                descuento = calcularPromociones(filasProd(i)(0), FormatNumber(dtproductos.Rows(fila).Cells(2).Value))
                precio = calcularPrecio(dtproductos.Rows(fila).Cells(0).Value) / descuento

                dtproductos.Rows(fila).Cells(3).Value = filasProd(i)(3)
                dtproductos.Rows(fila).Cells(4).Value = filasProd(i)(2)
                dtproductos.Rows(fila).Cells(5).Value = precio

                dtproductos.Rows(fila).Cells(6).Value = precio * FormatNumber(dtproductos.Rows(fila).Cells(2).Value)
                dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.GreenYellow


            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub cargarProdProduccion(ByRef codigo As String, ByRef fila As Integer)
        Reconectar()
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT ins.id,pro.codigobarras,format(replace(replace(pro.cantidad,'.',''),',','.'),3,'es_AR'),pro.producto, ins.iva,
        format(replace(replace(pro.precio,'.',''),',','.')/replace(replace(pro.cantidad,'.',''),',','.'),2,'es_AR') as punit,
        format(replace(replace(pro.precio,'.',''),',','.'),2,'es_AR') as ptotal FROM 
        fact_insumos_produccion as pro, fact_insumos as ins where ins.codigo=pro.codigo_producto and facturado=0 and 
        codigobarras='" & codigo & "'", conexionPrinc)
        Dim tablaprod As New DataTable
        Dim filasProd() As DataRow
        consulta.Fill(tablaprod)

        If tablaprod.Rows.Count = 0 Then
            lblnoplu.Text = "NO SE ENCUENTRA EL PRODUCTO " & codigo
        Else
            lblnoplu.Text = ""
        End If

        filasProd = tablaprod.Select("")
        If tipofact = 13 Then
            For i = 0 To filasProd.GetUpperBound(0)
                If fila = -1 Then
                    dtproductos.Rows.Add(filasProd(i)(0), filasProd(i)(1), filasProd(i)(2), filasProd(i)(3), filasProd(i)(4),
                    Math.Round(filasProd(i)(5) / 1.21, 2), Math.Round(filasProd(i)(6) / 1.21, 2))
                Else
                    dtproductos.Rows(fila).Cells(0).Value = filasProd(i)(0)
                    dtproductos.Rows(fila).Cells(1).Value = filasProd(i)(1)
                    dtproductos.Rows(fila).Cells(2).Value = filasProd(i)(2)
                    dtproductos.Rows(fila).Cells(3).Value = filasProd(i)(3)
                    dtproductos.Rows(fila).Cells(4).Value = filasProd(i)(4)
                    dtproductos.Rows(fila).Cells(5).Value = Math.Round(filasProd(i)(5) / 1.21, 2)
                    dtproductos.Rows(fila).Cells(6).Value = Math.Round(filasProd(i)(6) / 1.21, 2)
                End If
            Next
        Else
            For i = 0 To filasProd.GetUpperBound(0)
                If fila = -1 Then
                    dtproductos.Rows.Add(filasProd(i)(0), filasProd(i)(1), filasProd(i)(2), filasProd(i)(3), filasProd(i)(4),
                    filasProd(i)(5), filasProd(i)(6))
                Else
                    dtproductos.Rows(fila).Cells(0).Value = filasProd(i)(0)
                    dtproductos.Rows(fila).Cells(1).Value = filasProd(i)(1)
                    dtproductos.Rows(fila).Cells(2).Value = filasProd(i)(2)
                    dtproductos.Rows(fila).Cells(3).Value = filasProd(i)(3)
                    dtproductos.Rows(fila).Cells(4).Value = filasProd(i)(4)
                    dtproductos.Rows(fila).Cells(5).Value = filasProd(i)(5)
                    dtproductos.Rows(fila).Cells(6).Value = filasProd(i)(6)
                End If
            Next
        End If


    End Sub
    Public Sub cargarProdPLU(ByRef codigo As String, ByRef fila As Integer)
        Dim codPLU As String = codigo
        Dim Busq As String
        If InStr(codigo, "&") <> 0 Then
            CargarORRep(fila) 'dtproductos.CurrentRow.Index)
            Exit Sub
        ElseIf InStr(codigo, "00") = 1 Then
            cargarProdProduccion(codigo, fila)
            Exit Sub
        End If

        If codPLU = "" Then
            MsgBox("Debe ingresar un codigo o PLU")
            Exit Sub
        End If
        If InStr(codPLU, "#") = 1 Then
            Busq = "where cod_bar= " & Microsoft.VisualBasic.Right(codPLU, codPLU.Length - 1)
        ElseIf IsNumeric(codPLU) Then
            Busq = "where id=" & codPLU & " or codigo like '" & codPLU & "'"
        ElseIf Not IsNumeric(codPLU) Then
            Busq = "where  codigo like '" & codPLU & "' or cod_bar like '" & codPLU & "'"
        End If

        Reconectar()
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,codigo,iva,descripcion FROM fact_insumos " & Busq & " and eliminado=0 group by cod_bar", conexionPrinc)
        Dim tablaprod As New DataTable
        Dim filasProd() As DataRow
        consulta.Fill(tablaprod)
        If tablaprod.Rows.Count = 0 Then
            lblnoplu.Text = "NO SE ENCUENTRA EL PRODUCTO " & codPLU
        Else
            lblnoplu.Text = ""
        End If

        filasProd = tablaprod.Select("")
        Dim promocion As Double
        Dim precio As Double
        For i = 0 To filasProd.GetUpperBound(0)
            promocion = calcularPromociones(filasProd(i)(0), FormatNumber(txtcantPLU.Text))
            precio = calcularPrecio(filasProd(i)(0)) / promocion
            If fila = -1 Then
                dtproductos.Rows.Add(filasProd(i)(0), filasProd(i)(1), txtcantPLU.Text, filasProd(i)(3), filasProd(i)(2),
                precio, FormatNumber(txtcantPLU.Text) * precio)
            Else
                dtproductos.Rows(fila).Cells(0).Value = filasProd(i)(0)
                dtproductos.Rows(fila).Cells(1).Value = filasProd(i)(1)
                dtproductos.Rows(fila).Cells(2).Value = txtcantPLU.Text
                dtproductos.Rows(fila).Cells(3).Value = filasProd(i)(3)
                dtproductos.Rows(fila).Cells(4).Value = filasProd(i)(2)
                dtproductos.Rows(fila).Cells(5).Value = precio
                dtproductos.Rows(fila).Cells(6).Value = FormatNumber(txtcantPLU.Text) * precio
            End If

        Next
    End Sub


    Public Sub CargarORRep(ByRef fila As Integer)
        Try
            Dim texto As String = txtcodPLU.Text 'dtproductos.Rows(fila).Cells(1).Value
            Dim numOR As String = Microsoft.VisualBasic.Right(texto, texto.Length - 1)

            If numOR <> "" And numOR <> "0" And Val(numOR) <> 0 Then
                Reconectar()
                Dim consultaorden As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT tall.mo_monto, tall.estado, tall.trab_estado, (select count(tcn.id) from tecni_taller_insumos as tcn where tcn.idtaller=tall.id) as insumos from tecni_taller as tall where tall.id=" & numOR, conexionPrinc)
                Dim tablaorden As New DataTable
                Dim infoorden() As DataRow
                consultaorden.Fill(tablaorden)
                infoorden = tablaorden.Select("")
                If infoorden(0)(1) <> 8 Then
                    MsgBox("La orden de reparacion no esta finalizada, por favor finalice la orden primero")
                    Exit Sub
                End If
                If infoorden(0)(2) <> 3 Then
                    MsgBox("La orden de reparacion ya esta facturada o dada de baja")
                    Exit Sub
                End If

                If fila = -1 Then
                    dtproductos.Rows.Add("0", "&" & numOR, "1", "TRABAJO SEGUN ORDEN NUM: " & CompletarCeros(numOR, 2), "21", infoorden(0)(0), infoorden(0)(0))
                Else
                    'dtproductos.Rows(fila).Cells(2).Value=%
                    dtproductos.Rows(fila).Cells(2).Value = "1"
                    dtproductos.Rows(fila).Cells(3).Value = "TRABAJO SEGUN ORDEN NUM: " & CompletarCeros(numOR, 2)
                    dtproductos.Rows(fila).Cells(4).Value = "21"
                    dtproductos.Rows(fila).Cells(5).Value = infoorden(0)(0)
                    dtproductos.Rows(fila).Cells(6).Value = infoorden(0)(0)
                End If
                If infoorden(0)(3) <> 0 Then
                    Dim consultaprodorden As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT codigo, cantidad, descripcion, iva, punit, ptotal from tecni_taller_insumos where idtaller=" & numOR, conexionPrinc)
                    Dim tablaprodorden As New DataTable
                    Dim infoprodorden() As DataRow
                    consultaprodorden.Fill(tablaprodorden)
                    infoprodorden = tablaprodorden.Select("")
                    For i = 0 To infoprodorden.GetUpperBound(0)
                        dtproductos.Rows.Add(infoprodorden(i)(0), infoprodorden(i)(0), infoprodorden(i)(1), infoprodorden(i)(2), infoprodorden(i)(3), infoprodorden(i)(4), infoprodorden(i)(5))
                    Next
                End If
                CalcularTotales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function calcularPromociones(ByRef codprod As String, ByRef cant As Double) As Double
        Try
            If chkaplicardesc.CheckState = CheckState.Checked Then
                Dim montomin As Double
                Dim porcdesc As Double
                Reconectar()
                Dim consultaDescProd As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT prom.id,concat('Descuento producto ' , ins.descripcion,' ', prom.descuento_porc ,'%'),prom.compra_min,prom.descuento_porc " &
                "From fact_promociones as prom, fact_insumos as ins where ins.id=prom.idproducto and prom.idproducto=" & codprod, conexionPrinc)
                Dim tablaDescProd As New DataTable
                Dim filasDescProd() As DataRow
                consultaDescProd.Fill(tablaDescProd)
                filasDescProd = tablaDescProd.Select("")
                'MsgBox(consultaDescProd.SelectCommand.CommandText)

                If tablaDescProd.Rows.Count <> 0 Then
                    ' MsgBox(filasDescProd(0)(1))
                    montomin = filasDescProd(0)(2)
                    porcdesc = filasDescProd(0)(3)

                    If cant >= montomin Then
                        Dim existedesc As Boolean = False
                        For Each descuento As DataGridViewRow In dtdescuentos.Rows
                            If descuento.Cells(0).Value = filasDescProd(0)(0) Then
                                existedesc = True
                                Exit For
                            End If
                        Next
                        If existedesc = False Then
                            dtdescuentos.Rows.Add(filasDescProd(0)(0), filasDescProd(0)(1), filasDescProd(0)(3))
                            porcdesc = (CType(filasDescProd(0)(3), Double) + 100) / 100
                            Return porcdesc
                        Else
                            porcdesc = (CType(filasDescProd(0)(3), Double) + 100) / 100
                            Return porcdesc
                        End If
                    End If
                End If

                Reconectar()
                Dim consultaDescCat As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT prom.id, concat('Descuento categoria ' , cat.nombre,' ', prom.descuento_porc ,'%'),prom.compra_min,prom.descuento_porc " &
                    "From fact_promociones As prom, fact_categoria_insum As cat, fact_insumos As ins Where cat.id = prom.idcategoria And cat.id = ins.categoria  " &
                    "And ins.id=" & codprod, conexionPrinc)
                Dim tablaDescCat As New DataTable
                Dim filasDescCat() As DataRow
                consultaDescCat.Fill(tablaDescCat)
                filasDescCat = tablaDescCat.Select("")
                ' MsgBox(consultaDescCat.SelectCommand.CommandText)
                If tablaDescCat.Rows.Count <> 0 Then
                    ' MsgBox(filasDescCat(0)(1))
                    montomin = filasDescCat(0)(2)
                    porcdesc = filasDescCat(0)(3)
                    If cant >= montomin Then
                        Dim existedesc As Boolean = False
                        For Each descuento As DataGridViewRow In dtdescuentos.Rows
                            If descuento.Cells(0).Value = filasDescCat(0)(0) Then
                                existedesc = True
                                Exit For
                            End If
                        Next
                        If existedesc = False Then
                            dtdescuentos.Rows.Add(filasDescCat(0)(0), filasDescCat(0)(1), filasDescCat(0)(3))
                            porcdesc = (CType(filasDescCat(0)(3), Double) + 100) / 100
                            Return porcdesc
                        Else
                            porcdesc = (CType(filasDescCat(0)(3), Double) + 100) / 100
                            Return porcdesc
                        End If

                    End If
                End If
            End If
            Return 1
        Catch ex As Exception
            Return 1
        End Try
    End Function
    Private Function calcularPrecio(ByRef codProd As String) As Double
        Try
            Dim ganancia As Double

            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT precio, ganancia, iva, moneda,utilidad1,utilidad2 FROM fact_insumos where id=" & codProd, conexionPrinc)
            Dim tablaprod As New DataTable
            Dim filasProd() As DataRow
            consulta.Fill(tablaprod)
            filasProd = tablaprod.Select("")

            'cargamos listas de precios
            Dim consultalis As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,nombre,format(utilidad,2,'es_AR'),auxcol FROM fact_listas_precio where id=" & listaPrecios, conexionPrinc)
            Dim tablalistas As New DataTable
            Dim filaslistas() As DataRow
            consultalis.Fill(tablalistas)
            filaslistas = tablalistas.Select("")

            'cargamos la moneda perteneciente a este producto
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "Select (Select cotizacion from fact_moneda  where  id =" & filasProd(0)(3) & ") As cotiza, (Select valor from fact_configuraciones where  id =1) As lista"
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            Dim cotizacion As Double = FormatNumber(lector("cotiza").ToString)
            Dim precioCosto As Double = FormatNumber(filasProd(0)(0))
            Dim iva As Double = (FormatNumber(filasProd(0)(2)) + 100) / 100
            Dim listaTXT As String = filaslistas(0)(2)
            Dim lista As Double
            Dim utilidad As Double
            Dim codaux As Integer = filaslistas(0)(3)

            Dim utilSum As Double = FormatNumber(filasProd(0)(5))
            Dim listaSum As Double = FormatNumber(filaslistas(0)(2))

            Dim SumaUtil As Double = (utilSum + listaSum + 100) / 100

            Select Case codaux
                Case 0
                    utilidad = (FormatNumber(filasProd(0)(1)) + 100) / 100
                Case 1
                    utilidad = (FormatNumber(filasProd(0)(4)) + 100) / 100
                Case 2
                    utilidad = (FormatNumber(filasProd(0)(5)) + 100) / 100
            End Select

            Dim PrecioSinIva As Double
            Dim PrecioVenta As Double

            If InStr(listaTXT, "%") <> 0 Then
                lista = (FormatNumber(listaTXT.Replace("%", "") + 100) / 100)
                PrecioSinIva = precioCosto * cotizacion * lista
                PrecioVenta = PrecioSinIva * iva
            Else
                If codaux = 2 Then
                    lista = (FormatNumber(filaslistas(0)(2) + 100) / 100)
                    PrecioSinIva = precioCosto * cotizacion * SumaUtil
                    PrecioVenta = PrecioSinIva * iva
                Else
                    lista = (FormatNumber(listaTXT + 100) / 100)
                    'MsgBox(precioCosto & "-" & cotizacion & "-" & utilidad & "-" & lista)
                    PrecioSinIva = precioCosto * cotizacion * utilidad * lista
                    PrecioVenta = PrecioSinIva * iva
                End If
            End If


            'PrecioSinIva = precioCosto * cotizacion * utilidad * lista
            'PrecioVenta = PrecioSinIva * iva

            Select Case tipofact
                Case 999, 991, 992
                    Return Math.Round(PrecioVenta, 2)
                Case 6, 8, 11
                    Return Math.Round(PrecioVenta, 2)
                Case Else
                    Return Math.Round(PrecioSinIva, 2)
            End Select
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub txtcodPLU_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcodPLU.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim encuentraprod As Integer
            Dim contarprod As Integer = 0
            Dim plutemp As String = txtcodPLU.Text
            txtcodPLU.Text = txtcodPLU.Text.Replace("B", "").Replace("A", "").Replace("b", "").Replace("a", "")

            If txtcodPLU.Text = "" Then
                txtdescripcionPLU.Focus()
                Exit Sub
            End If

            If dtproductos.Rows.Count = 0 Then
                cargarProdPLU(txtcodPLU.Text, -1)
            Else
                For Each fila As DataGridViewRow In dtproductos.Rows
                    If fila.Cells(1).Value = txtcodPLU.Text Then
                        contarprod += 1
                        encuentraprod = fila.Index
                    End If
                Next
                If contarprod <> 0 Then
                    If InStr(plutemp, "A00") = 0 Then
                        dtproductos.Rows(encuentraprod).Cells(2).Value += CType(txtcantPLU.Text, Double)
                        dtproductos.Rows(encuentraprod).Cells(6).Value = dtproductos.Rows(encuentraprod).Cells(5).Value * dtproductos.Rows(encuentraprod).Cells(2).Value
                    Else
                        lblnoplu.Text = "el producto ya fue escaneado"
                        Exit Sub
                    End If
                ElseIf contarprod = 0 Then
                    cargarProdPLU(txtcodPLU.Text, -1)
                End If
            End If
            CalcularTotales()
            txtcodPLU.Text = ""
            txtcantPLU.Text = 1
            txtcodPLU.Focus()
        End If
    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
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
        tmrcontrolarnumfact.Enabled = False
        dtproductos.AllowUserToAddRows = False
        dtpedidosfact.AllowUserToAddRows = False
        'variables para la factura
        ' Dim num_fact As Integer
        'Dim ptovta As String = ptovta
        Dim fecha As String = Format(CDate(fechagral), "yyyy-MM-dd")
        'Dim idcliente As String = txtctaclie.Text
        Dim razon As String = txtclierazon.Text
        Dim direccion As String = lblcliedomicilio.Text
        Dim localidad As String = lblclieciudad.Text
        Dim tipocontr As String = lblclietipocontr.Text
        Dim cuit As String = txtcliecuitcuil.Text
        'Dim condvta As Integer = cmbcondvta.SelectedValue
        Dim subtotal As String = remplazarPunto(lblfactsubtotal.Text)
        Dim iva105 As String = remplazarPunto(lblfactiva105.Text)
        Dim iva21 As String = remplazarPunto(lblfactiva21.Text)
        Dim total As String = remplazarPunto(lblfacttotal.Text)
        Dim vendedor As Integer = DatosAcceso.Vendedor
        'Dim tipoFact As Integer = cmbtipofac.SelectedValue
        Dim obs2 As String = txtobservaciones.Text
        'num_fact = CType(txtnufac.Text, Integer)
        Dim sqlQuery As String

        'variables para los items de factura
        Dim cod As String
        Dim cantidad As String
        Dim descripcion As String
        Dim iva As String
        Dim punit As String
        Dim ptotal As String
        Dim codbar As String
        Dim i As Integer

        'comprobamos que se seleccione un vendedor
        'If cmbvendedor.SelectedValue = 0 Then
        '    MsgBox("Seleccione vendedor")
        '    Exit Sub
        'End If

        'comprobamos que el numero de factura no este en uso
        If RestringirNumerosFact(tipofact, numfact, ptovta) = True Then
            MsgBox("El numero de comprobante ya existe para este tipo, por favor verifique")
            EnProgreso.Close()
            Exit Sub
        End If

        If dtproductos.RowCount = 0 Then
            MsgBox("debe ingresar productos para facturar")
            EnProgreso.Close()
            Exit Sub
        End If
        If txtcliecta.Text = "9999" And condVta = 2 Then
            MsgBox("Debe seleccionar un cliente para poder poner productos en cuenta corriente")
            Exit Sub
        End If

        'comprobamos que exista stock de los productos
        If chkquitarstock.CheckState = CheckState.Checked Then
            dtproductos.AllowUserToAddRows = False
            Dim contarstock As Integer = 0
            For Each productoscomp As DataGridViewRow In dtproductos.Rows
                If ComprobarStock(productoscomp.Cells(0).Value, productoscomp.Cells(2).Value) = False Then
                    ' MsgBox("Uno de los productos no pudo ser procesado por falta de stock o es insuficiente, por favor compruebe")
                    productoscomp.DefaultCellStyle.BackColor = Color.Red
                    contarstock += 1 ' Exit Sub
                End If
            Next
            If contarstock > 0 Then
                If MsgBox("Uno de los productos no pudo ser procesado por falta de stock o es insuficiente, desea continuar de todas formas? 
                los elementos que no se procesaran estan resaltados en rojo", vbYesNo) = vbNo Then
                    EnProgreso.Close()
                    Exit Sub
                End If
            End If
        End If

        Reconectar()
        Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand
        Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand
        Dim Transaccion As MySql.Data.MySqlClient.MySqlTransaction
        Transaccion = conexionPrinc.BeginTransaction

        Try
            'GUARDO LOS DATOS DE LA FACTURA
            sqlQuery = "insert into fact_facturas  " _
            & "(tipofact,ptovta, num_fact,fecha,id_cliente,razon,direccion,localidad,tipocontr,cuit,condvta,subtotal,iva105,iva21,total,vendedor,observaciones2,cae,vtocae,codbarra) values " _
            & "(?tipofact, ?ptov,?nfac,?fech,?idclie,?razon,?dire,?loca,?tipocont,?cuit,?condvta,?subt,?105,?21,?tot,?vend,?obs2,?cae,?vtocae,?codbarra)"
            comandoadd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?ptov", Val(ptovta))
                .AddWithValue("?tipofact", tipofact)
                .AddWithValue("?nfac", Val(numfact))
                .AddWithValue("?fech", fecha)
                .AddWithValue("?idclie", Idcliente)
                .AddWithValue("?razon", razon)
                .AddWithValue("?dire", direccion)
                .AddWithValue("?loca", localidad)
                .AddWithValue("?tipocont", tipocontr)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?condvta", condVta)
                .AddWithValue("?subt", subtotal)
                .AddWithValue("?105", iva105)
                .AddWithValue("?21", iva21)
                .AddWithValue("?tot", total)
                .AddWithValue("?vend", vendedor)
                .AddWithValue("?obs2", obs2)
                .AddWithValue("?cae", lblestadoCAE.Text.Replace("CAE: ", ""))
                .AddWithValue("?vtocae", lblvtoCAE.Text.Replace("Vto: ", ""))
                .AddWithValue("?codbarra", lblcodigobarras.Text)
            End With
            comandoadd.Transaction = Transaccion
            comandoadd.ExecuteNonQuery()
            IdFactura = comandoadd.LastInsertedId

            'actualizo el numero de factura excepto para la factura electronica
            If ptovta <> FacturaElectro.puntovtaelect Then
                Reconectar()
                sqlQuery = "update fact_conffiscal set confnume=" & Val(numfact) & " where donfdesc= " & tipofact & " and ptovta= " & ptovta
                comandoupd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                comandoupd.Transaction = Transaccion
                comandoupd.ExecuteNonQuery()
            End If
            'cargo los items de la factura
            'Dim i As Integer
            For Each itemsFact As DataGridViewRow In dtproductos.Rows
                If Not IsNumeric(itemsFact.Cells(0).Value) Then
                    cod = 0
                Else
                    cod = itemsFact.Cells(0).Value
                End If
                codbar = itemsFact.Cells(1).Value
                cantidad = itemsFact.Cells(2).Value.ToString.Replace(".", "").ToString.Replace(",", ".")
                descripcion = itemsFact.Cells(3).Value.ToString.ToUpper
                iva = itemsFact.Cells(4).Value.ToString.Replace(".", "").ToString.Replace(",", ".")
                punit = itemsFact.Cells(5).Value.ToString.Replace(".", "").ToString.Replace(",", ".")
                ptotal = itemsFact.Cells(6).Value.ToString.Replace(".", "").ToString.Replace(",", ".")

                'para quitar de stock
                If chkquitarstock.CheckState = CheckState.Checked And itemsFact.DefaultCellStyle.BackColor <> Color.Red Then
                    Dim cant As Double = cantidad
                    Dim codigo As String = cod
                    Dim lotes As Integer = 0

                    Reconectar()
                    Dim consultastock As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id, stock FROM fact_insumos_lotes " _
                    & "where stock >0 and idproducto=" & codigo & " and idalmacen= " & DatosAcceso.IdAlmacen & " order by id asc", conexionPrinc)
                    Dim tablastock As New DataTable
                    Dim infostock() As DataRow
                    consultastock.Fill(tablastock)
                    infostock = tablastock.Select("")
                    Do Until cant = 0
                        If infostock(lotes)(1) <= cant Then
                            cant = cant - infostock(lotes)(1)
                            Reconectar()
                            Dim updstock As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos_lotes Set stock=0 where id=" & infostock(lotes)(0), conexionPrinc)
                            updstock.Transaction = Transaccion
                            updstock.ExecuteNonQuery()
                            lotes += 1
                        ElseIf infostock(lotes)(1) > cant Then
                            Reconectar()
                            Dim updstock As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos_lotes Set stock=stock-" & cant & " where id=" & infostock(lotes)(0), conexionPrinc)
                            updstock.Transaction = Transaccion
                            updstock.ExecuteNonQuery()
                            cant = 0
                        End If
                    Loop
                End If

                'poner sacar los items de produccion

                If InStr(codbar, "00") = 1 Then
                    Reconectar()
                    sqlQuery = "update fact_insumos_produccion Set facturado=1, fecha_venta ='" & fecha & "' where codigobarras= " & codbar
                    comandoupd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                    comandoupd.Transaction = Transaccion
                    comandoupd.ExecuteNonQuery()
                End If


                'guardamos los items
                Reconectar()
                sqlQuery = "insert into fact_items " _
                & "(cod,plu,cantidad, descripcion, iva, punit, ptotal, tipofact,ptovta,num_fact,id_fact) values" _
                & "(?cod,?plu, ?cant,?desc,?iva,?punit,?ptot,?tipofact,?ptovta,?num_fact,?id_fact)"

                comandoadd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters
                    .AddWithValue("?cod", cod)
                    .AddWithValue("?plu", codbar)
                    .AddWithValue("?cant", cantidad)
                    .AddWithValue("?desc", descripcion)
                    .AddWithValue("?iva", iva)
                    .AddWithValue("?punit", punit)
                    .AddWithValue("?ptot", ptotal)
                    .AddWithValue("?tipofact", tipofact)
                    .AddWithValue("?ptovta", ptovta)
                    .AddWithValue("?num_fact", numfact)
                    .AddWithValue("?id_fact", IdFactura)
                End With
                comandoadd.Transaction = Transaccion
                comandoadd.ExecuteNonQuery()

                'si hay ordenes de reparacion entre los items le ponemos facturada
                If InStr(itemsFact.Cells(1).Value.ToString, "&") <> 0 Then
                    Dim idtrab As Integer = Microsoft.VisualBasic.Right(itemsFact.Cells(1).Value.ToString, Len(itemsFact.Cells(1).Value.ToString) - 1)
                    sqlQuery = "update tecni_taller set trab_estado=1, factura=" & IdFactura & " where id=" & idtrab
                    comandoupd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                    comandoupd.Transaction = Transaccion
                    comandoupd.ExecuteNonQuery()
                End If
            Next

            'dependiendo de la condicion de venta hacemos distintas acciones
            Reconectar()
            sqlQuery = "insert into fact_cuentaclie (idclie,idcomp) values (?clie, ?idcomp)"
            comandoadd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?clie", Idcliente)
                .AddWithValue("?idcomp", IdFactura)
            End With
            comandoadd.Transaction = Transaccion
            comandoadd.ExecuteNonQuery()
            Dim j As Integer
            For j = 0 To frmprincipal.MdiChildren.Length - 1
                If frmprincipal.MdiChildren(i).Name = "movimientocaja" Then
                    MsgBox("La ventana de movimiento de caja esta abierta")
                    Exit Sub
                End If
            Next

            If condVta = 1 Then
                Dim mov As New frmpagoscompra
                mov.NumeroFactura = ptovta & " - " & numfact
                mov.CtaClie = txtcliecta.Text
                mov.RazonSocial = txtclierazon.Text
                mov.Direccion = lblcliedomicilio.Text
                mov.Localidad = lblclieciudad.Text
                mov.tipoContr = lblclietipocontr.Text
                mov.CUIT = txtcliecuitcuil.Text
                mov.Fecha = Format(CDate(fechagral), "yyyy-MM-dd")
                mov.TOTAL = lblfacttotal.Text
                mov.IdFacturaCTA = comandoadd.LastInsertedId
                mov.IdFacturaComp = IdFactura
                mov.Show()

            End If
            For Each PedidoFact As DataGridViewRow In dtpedidosfact.Rows
                Dim pedidosFact As String
                If pedidosFact = "" Then pedidosFact = PedidoFact.Cells(0).Value
                If pedidosFact <> "" Then pedidosFact &= ", " & PedidoFact.Cells(0).Value

                sqlQuery = "update fact_facturas set observaciones ='FACTURADO' WHERE tipofact=995 and id in(" & pedidosFact & ")"

                comandoupd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                comandoupd.Transaction = Transaccion
                comandoupd.ExecuteNonQuery()
            Next

            Transaccion.Commit()
            cmdguardar.Enabled = False

            cmdimprimir.Enabled = True
            cmdcerrar.Enabled = False
            txtclierazon.Enabled = False
            txtcliecta.Enabled = False
            txtcliecuitcuil.Enabled = False
            dtproductos.Enabled = False
            ' MsgBox("Factura guardada satisfactoriamente")

            If My.Settings.ImprTikets = 1 Then
                ' MsgBox("imprimirtiket")
                cmdimprimir.PerformClick()
            End If

        Catch ex As Exception
            tmrcontrolarnumfact.Enabled = True
            Transaccion.Rollback()
            MsgBox(ex.Message)
        End Try
        EnProgreso.Close()
    End Sub

    Public Sub cmdimprimir_Click(sender As Object, e As EventArgs) Handles cmdimprimir.Click
        'MsgBox("llamada")
        Dim EnProgreso As New Form
        EnProgreso.ControlBox = False
        EnProgreso.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        EnProgreso.Size = New Point(430, 30)
        EnProgreso.StartPosition = FormStartPosition.CenterScreen
        EnProgreso.TopMost = True
        Dim Etiqueta As New Label
        Etiqueta.AutoSize = True
        Etiqueta.Text = "Imprimiendo comprobante, por favor espere ..."
        Etiqueta.Location = New Point(5, 5)
        EnProgreso.Controls.Add(Etiqueta)

        EnProgreso.Show()
        Application.DoEvents()
        Try
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas

            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, 
concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.fecha as facfech, 
concat(fac.id_cliente,'-',fac.razon) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, 
concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21,
'','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra 
FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac,fact_condventas as condvent  
where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and condvent.id=fac.condvta and fac.id=" & IdFactura, conexionPrinc)

            tabEmp.Fill(fac.Tables("factura_enca"))
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal 
            from fact_items where id_fact=" & IdFactura, conexionPrinc)
            tabFac.Fill(fac.Tables("facturax"))

            Dim direccionReport As String
            If ptovta <> FacturaElectro.puntovtaelect Then
                direccionReport = System.Environment.CurrentDirectory & "\reportes\facturax.rdlc"
            Else
                direccionReport = System.Environment.CurrentDirectory & "\reportes\facturaelectro.rdlc"
            End If
            If My.Settings.ImprTikets = 1 Then
                Dim PrintTxt As New PrintDocument
                Dim pgSize As New PaperSize
                pgSize.RawKind = Printing.PaperKind.Custom
                pgSize.Width = 147 '196.8 '
                'pgSize.Height = 173.23 '100
                PrintTxt.DefaultPageSettings.PaperSize = pgSize
                ' evento print
                AddHandler PrintTxt.PrintPage, AddressOf ImprimirTiketVenta
                PrintTxt.PrinterSettings.PrinterName = My.Settings.ImprTiketsNombre
                PrintTxt.Print()
            Else

                Using Imprimir As New ImprimirDirecto()
                    Imprimir.Run(fac.Tables("factura_enca"), fac.Tables("facturax"), direccionReport)
                    Imprimir.Run(fac.Tables("factura_enca"), fac.Tables("facturax"), direccionReport)
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
        EnProgreso.Close()
    End Sub

    Public Sub ImprimirTiketVenta(ByVal sender As System.Object, ByVal e As PrintPageEventArgs)
        ' letra
        'Dim font1 As New Font("EAN-13", 40)
        Dim printfont As New Font("Courier New", 6)
        Dim font3 As New Font("Courier New", 8)
        Dim font4 As New Font("Courier New", 18)
        Dim font5 As New Font("Courier New", 6)

        Dim alto As Single = 0
        Dim topMargin As Double '= e.MarginBounds.Top
        Dim yPos As Double = 0
        Dim count As Integer = 0
        Dim texto As String = ""

        Dim codigo As String = ""
        Dim unidad As String = ""
        Dim detalle As String = ""
        Dim valoruni As String = ""
        Dim valortot As String = ""
        Dim tabulacion As String = ""
        Dim compensador As Integer = 0
        Dim total As String = ""
        Dim lvalor As String
        Dim lineatotal As String
        Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter

        Dim fac As New datosfacturas


        Reconectar()

        tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, 
concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.fecha as facfech, 
concat(fac.id_cliente,'-',fac.razon) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, 
concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21,
'','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra 
FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac,fact_condventas as condvent  
where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and condvent.id=fac.condvta and fac.id=" & IdFactura, conexionPrinc)

        Dim tablaEmpresa As New DataTable
        Dim filasProd() As DataRow
        'MsgBox(consulta.SelectCommand.CommandText)
        tabEmp.Fill(tablaEmpresa)
        'dtproductos.DataSource = tablaprod
        '        dtproductos.Rows.Clear()
        'filasProd = tablaprod.Select("")

        Reconectar()

        tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal 
            from fact_items where id_fact=" & IdFactura, conexionPrinc)
        tabFac.Fill(fac.Tables("facturax"))

        'e.PageSettings.PrinterSettings.PrinterName = My.Settings.ImprTiketsNombre
        e.Graphics.DrawImage(Image.FromFile(Application.StartupPath & "\logo2.jpg"), 5, 15)
        'fac.Tables("factura_enca")["empnombre"].tostring()

        e.Graphics.DrawString("Razón social: " & tablaEmpresa.Rows(0).Item(0), font5, Brushes.Black, 0, 100) 'RAZON SOCIAL
        e.Graphics.DrawString("Tiket N°: " & tablaEmpresa.Rows(0).Item(10), font5, Brushes.Black, 0, 110) '
        e.Graphics.DrawString("Fecha: " & tablaEmpresa.Rows(0).Item(11).ToString, font5, Brushes.Black, 0, 120) '
        e.Graphics.DrawString("Ciente: " & tablaEmpresa.Rows(0).Item(12), font5, Brushes.Black, 0, 130) '
        e.Graphics.DrawString("#Articulos:" & dtproductos.Rows.Count, font5, Brushes.Black, 0, 140) '
        e.Graphics.DrawString(StrDup(65, "#"), font5, Brushes.Black, 0, 150)
        e.Graphics.DrawString("### TIKET NO VALIDO COMO FACTURA ###", font5, Brushes.Black, 0, 160)
        e.Graphics.DrawString(StrDup(65, "#"), font5, Brushes.Black, 0, 170)
        'e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 180)
        'e.Graphics.DrawString("CODIGO      |    CANT    | PRE. UNI | PRE. TOTAL ", font5, Brushes.Black, 0, 190)
        'e.Graphics.DrawString("DESCRIPCION", font5, Brushes.Black, 0, 200)
        'e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 210)

        For Each row As DataGridViewRow In dtproductos.Rows
            codigo = row.Cells(0).Value.ToString : unidad = row.Cells(2).Value : detalle = row.Cells(3).Value : valoruni = row.Cells(5).Value : valortot = row.Cells(6).Value


            texto = unidad & " x " & valoruni & Chr(9) '& "$" & valortot 'codigo & Chr(9) & Chr(9) & unidad & Chr(9) & "$" & valoruni & Chr(9) & "$" & valortot
            '    texto2 = detalle
            yPos = 180 + topMargin + (count * printfont.GetHeight(e.Graphics)) ' Calcula la posición en la que se escribe la línea
            ' Imprime la línea con el objeto Graphics
            Dim i As Integer
            Dim car As Integer
            If detalle.Length <= 27 Then
                car = 27 - detalle.Length
                For i = 0 To car
                    detalle &= " "
                Next
            Else
                car = detalle.Length - 27
                detalle = detalle.Remove(27, car)
            End If


            If Not row.IsNewRow Then
                e.Graphics.DrawString(texto, printfont, System.Drawing.Brushes.Black, 5, yPos)
                count += 1
                yPos = yPos + 10
                e.Graphics.DrawString(detalle & "  " & valortot, printfont, System.Drawing.Brushes.Black, 5, yPos)
                'total += valor
            End If

            count += 1

        Next
        yPos += 20
        Dim lineaSep = StrDup(25, " ")
        e.Graphics.DrawString(lineaSep & "__________", printfont, System.Drawing.Brushes.Black, 5, yPos)
        Dim XXX As Integer = 0
        XXX = Len(total.ToString)
        lineatotal = StrDup(14 - XXX, ".")
        yPos += 20
        e.Graphics.DrawString("Total" & lineatotal & lblfacttotal.Text, font3, System.Drawing.Brushes.Black, 5, yPos)
        yPos += 30
        e.Graphics.DrawString(My.Settings.TextoPieTiket, font3, System.Drawing.Brushes.Black, 15, yPos)
        yPos += 10
        e.Graphics.DrawString("Gracias por tu compra!!!", font3, System.Drawing.Brushes.Black, 15, yPos)



    End Sub

    Private Sub ImprimirTiketFiscal(ByVal sender As System.Object, ByVal e As PrintPageEventArgs)
        ' letra
        'Dim font1 As New Font("EAN-13", 40)
        Dim printfont As New Font("Courier New", 6)
        Dim font3 As New Font("Courier New", 8)
        Dim font4 As New Font("Courier New", 18)
        Dim font5 As New Font("Courier New", 6)

        Dim alto As Single = 0
        Dim topMargin As Double '= e.MarginBounds.Top
        Dim yPos As Double = 0
        Dim count As Integer = 0
        Dim texto As String = ""

        Dim codigo As String = ""
        Dim unidad As String = ""
        Dim detalle As String = ""
        Dim valoruni As String = ""
        Dim valortot As String = ""
        Dim tabulacion As String = ""
        Dim compensador As Integer = 0
        Dim total As String = ""
        Dim lvalor As String
        Dim lineatotal As String
        Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ivaProd As String = ""
        Dim fac As New datosfacturas


        Reconectar()

        tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
        emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
        emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, 
        concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.fecha as facfech, 
        concat(fac.id_cliente,'-',fac.razon) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, 
        concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21,
        '','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra 
        FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac,fact_condventas as condvent  
        where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and condvent.id=fac.condvta and fac.id=" & IdFactura, conexionPrinc)

        Dim tablaEmpresa As New DataTable
        tabEmp.Fill(tablaEmpresa)

        Reconectar()

        tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal 
            from fact_items where id_fact=" & IdFactura, conexionPrinc)
        Dim tablaProd As New DataTable
        tabFac.Fill(tablaProd)

        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(1), font5, Brushes.Black, 5, 100) 'RAZON SOCIAL
        e.Graphics.DrawString("CUIT Nro: " & tablaEmpresa.Rows(0).Item(4), font5, Brushes.Black, 5, 110) '
        e.Graphics.DrawString("Ing. Brutos: " & tablaEmpresa.Rows(0).Item(5).ToString, font5, Brushes.Black, 5, 120) '
        e.Graphics.DrawString("Domicilio: " & tablaEmpresa.Rows(0).Item(2), font5, Brushes.Black, 5, 130)
        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(3), font5, Brushes.Black, 5, 140) '
        e.Graphics.DrawString("Inicio de actividades: " & tablaEmpresa.Rows(0).Item(7), font5, Brushes.Black, 5, 150)
        e.Graphics.DrawString("IVA " & tablaEmpresa.Rows(0).Item(6), font5, Brushes.Black, 5, 160)

        e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 5, 170)
        e.Graphics.DrawString("FACTURA '" & tablaEmpresa.Rows(0).Item(26) & "' (" & tablaEmpresa.Rows(0).Item(27) & ")", font5, Brushes.Black, 5, 180)
        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(10), font5, Brushes.Black, 5, 190)
        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(11), font5, Brushes.Black, 5, 200)
        e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 5, 210)

        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(12), font5, Brushes.Black, 5, 230)
        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(13), font5, Brushes.Black, 5, 240)
        e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(14), font5, Brushes.Black, 5, 250)
        e.Graphics.DrawString("CUIT Nro: " & tablaEmpresa.Rows(0).Item(16), font5, Brushes.Black, 5, 260)
        e.Graphics.DrawString("IVA " & tablaEmpresa.Rows(0).Item(15), font5, Brushes.Black, 5, 270)
        e.Graphics.DrawString("CONDICION DE VENTA " & tablaEmpresa.Rows(0).Item(18), font5, Brushes.Black, 5, 280)
        e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 5, 290)

        Dim i As Integer
        For i = 0 To tablaProd.Rows.Count - 1
            codigo = tablaProd.Rows(i).Item(0) : unidad = tablaProd(i).Item(1) : detalle = tablaProd(i).Item(2) : valoruni = tablaProd(i).Item(4) : valortot = tablaProd(i).Item(5) : ivaProd = tablaProd(i).Item(3)
            texto = unidad & " x " & valoruni & Chr(9)
            yPos = 290 + topMargin + (count * printfont.GetHeight(e.Graphics)) ' Calcula la posición en la que se escribe la línea            

            Dim j As Integer
            Dim car As Integer

            If detalle.Length <= 27 Then
                car = 27 - detalle.Length
                For j = 0 To car
                    detalle &= " "
                Next
            Else
                car = detalle.Length - 27
                detalle = detalle.Remove(27, car)
            End If


            'If Not row.IsNewRow Then
            e.Graphics.DrawString(texto, printfont, System.Drawing.Brushes.Black, 5, yPos)
            count += 1
            yPos = yPos + 10
            e.Graphics.DrawString(detalle & "  " & valortot, printfont, System.Drawing.Brushes.Black, 5, yPos)
            'total += valor
            'End If
            count += 1

        Next


        For Each row As DataGridViewRow In dtproductos.Rows
            codigo = row.Cells(0).Value.ToString : unidad = row.Cells(2).Value : detalle = row.Cells(3).Value : valoruni = row.Cells(5).Value : valortot = row.Cells(6).Value

            texto = unidad & " x " & valoruni & Chr(9) '& "$" & valortot 'codigo & Chr(9) & Chr(9) & unidad & Chr(9) & "$" & valoruni & Chr(9) & "$" & valortot
            '    texto2 = detalle
            yPos = 290 + topMargin + (count * printfont.GetHeight(e.Graphics)) ' Calcula la posición en la que se escribe la línea
            ' Imprime la línea con el objeto Graphics
            Dim j As Integer
            Dim car As Integer
            If detalle.Length <= 27 Then
                car = 27 - detalle.Length
                For j = 0 To car
                    detalle &= " "
                Next
            Else
                car = detalle.Length - 27
                detalle = detalle.Remove(27, car)
            End If


            If Not row.IsNewRow Then
                e.Graphics.DrawString(texto, printfont, System.Drawing.Brushes.Black, 5, yPos)
                count += 1
                yPos = yPos + 10
                e.Graphics.DrawString(detalle & "  " & valortot, printfont, System.Drawing.Brushes.Black, 5, yPos)
                'total += valor
            End If

            count += 1

        Next
        yPos += 20
        Dim lineaSep = StrDup(25, " ")
        e.Graphics.DrawString(lineaSep & "__________", printfont, System.Drawing.Brushes.Black, 5, yPos)
        Dim XXX As Integer = 0
        XXX = Len(total.ToString)
        lineatotal = StrDup(14 - XXX, ".")
        yPos += 20
        e.Graphics.DrawString("Total" & lineatotal & lblfacttotal.Text, font3, System.Drawing.Brushes.Black, 5, yPos)
        yPos += 30
        e.Graphics.DrawString(My.Settings.TextoPieTiket, font3, System.Drawing.Brushes.Black, 15, yPos)
        yPos += 10
        e.Graphics.DrawString("Gracias por tu compra!!!", font3, System.Drawing.Brushes.Black, 15, yPos)



    End Sub

    Private Sub puntoventa_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.F1
                If condVta = 1 Then
                    condVta = 2
                    lblfactcondvta.Text = "CTA. CTE."
                Else
                    condVta = 1
                    lblfactcondvta.Text = "CONTADO"
                End If
            Case Keys.F2

                selListaPrecios.Show()
                selListaPrecios.TopMost = True

            Case Keys.F3
                If cmdsolicitarcae.Enabled = True Then
                    cmdsolicitarcae.PerformClick()
                End If
            Case Keys.F4
                If cmdguardar.Enabled = True Then
                    cmdguardar.PerformClick()
                End If
            Case Keys.F5
                If cmdimprimir.Enabled = True Then
                    cmdimprimir.PerformClick()
                End If
            Case Keys.F6
                Me.Close()
            Case Keys.F7
                Button1.PerformClick()
        End Select
    End Sub

    Private Sub cmdcerrar_Click(sender As Object, e As EventArgs) Handles cmdcerrar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cargar_datos_factura()

    End Sub

    Private Sub dtpedidosfact_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtpedidosfact.CellEndEdit
        Try

            If e.ColumnIndex = 1 Then
                Reconectar()
                Dim consultapedido As New MySql.Data.MySqlClient.MySqlDataAdapter("Select " _
                & "id, condVta, vendedor from fact_facturas where observaciones Like 'PENDIENTE' AND ptovta=1 and num_fact=" & dtpedidosfact.CurrentCell.Value & " and tipofact=9", conexionPrinc)
        Dim tablaped As New DataTable
                Dim infoped() As DataRow
                consultapedido.Fill(tablaped)
                infoped = tablaped.Select("")
                If tablaped.Rows.Count = 0 Then
                    MsgBox("Pedido no encontrado o ya facturado")
                    dtpedidosfact.CurrentCell.Value = ""
                    SendKeys.Send("{UP}")
                    Exit Sub
                End If
                dtpedidosfact.CurrentRow.Cells(0).Value = infoped(0)(0)
                'cmbcondvta.SelectedValue = infoped(0)(1)
                'cmbvendedor.SelectedValue = infoped(0)(2)

                Reconectar()
                Dim consultapedidoitems As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cod,codint, cantidad, descripcion, iva, punit, ptotal from fact_items where id_fact=" & dtpedidosfact.CurrentRow.Cells(0).Value, conexionPrinc)
                Dim tablaitm As New DataTable
                Dim infoitm() As DataRow
                consultapedidoitems.Fill(tablaitm)
                infoitm = tablaitm.Select("")
                For i = 0 To infoitm.GetUpperBound(0)
                    dtproductos.Rows.Add(infoitm(i)(0), infoitm(i)(1), infoitm(i)(2), infoitm(i)(3), infoitm(i)(4), infoitm(i)(5), infoitm(i)(6))
                Next
                ' rdserial.Enabled = False
                CalcularTotales()
                'ElseIf e.ColumnIndex = 1 And rdserial.Checked = True Then
                '    Reconectar()
                '    Dim consultapedidoitems As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT prod.codigo " _
                '    & "FROM fact_gtia as gtia, fact_insumos as prod " _
                '    & "where prod.codigo=gtia.codigo and gtia.serie like '" & dtpedidosfact.CurrentCell.Value & "'", conexionPrinc)
                '    ' MsgBox(consultapedidoitems.SelectCommand.CommandText)
                '    Dim tablaitm As New DataTable
                '    Dim infoitm() As DataRow
                '    consultapedidoitems.Fill(tablaitm)
                '    infoitm = tablaitm.Select("")
                '    If tablaitm.Rows.Count = 0 Then
                '        MsgBox("No se encuentra el producto en la tabla de garantias")
                '        dtpedidosfact.CurrentCell.Value = ""
                '        SendKeys.Send("{UP}")
                '    Else
                '        cargarProdPLU(infoitm(0)(0))
                '        CalcularTotales()
                '    End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcantPLU_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcantPLU.KeyUp
        If e.KeyCode = Keys.Enter Then
            If txtcodPLU.Text = "" Then
                If IsNumeric(txtcantPLU.Text) And IsNumeric(txtpreciounitPLU.Text) Then
                    dtproductos.Rows.Add(0, 0, FormatNumber(txtcantPLU.Text, 2),
                    txtdescripcionPLU.Text.ToUpper, txtivaPLU.Text, FormatNumber(txtpreciounitPLU.Text, 2), FormatNumber(txtpreciounitPLU.Text, 2) * FormatNumber(txtcantPLU.Text, 2))
                    txtcantPLU.Text = "1"
                    txtdescripcionPLU.Text = ""
                    txtpreciounitPLU.Text = ""
                    txtcodPLU.Text = ""
                    txtcodPLU.Focus()

                    CalcularTotales()
                Else
                    MsgBox("No se puede agregar el item, por favor verifique los datos ingresados")
                End If
            End If
        End If
    End Sub

    Private Sub cmdsolicitarcae_Click(sender As Object, e As EventArgs) Handles cmdsolicitarcae.Click
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
        '3 0%
        '4 10,50%
        '5 21%
        '6 27%
        '8 5%
        '9 2,50%
        tmrcontrolarnumfact.Enabled = False
        '--------------------------------------------------------------------------------------------
        'MsgBox("NUEVA")
        Try

            Dim fe As New WSAFIPFE.Factura
            Dim nContador As Integer
            Dim nNumero As Integer
            Dim lresultado As Boolean

            Dim cbtetipo As Integer
            Dim doctipo As Integer
            Dim contribtipo As Integer
            Dim idiva As Integer

            Dim sub0 As Double = FormatNumber(txtsub0.Text, 2)
            Dim sub21 As Double = FormatNumber(txtsub21.Text, 2)
            Dim sub105 As Double = FormatNumber(txtsub105.Text, 2)
            Dim iva21 As Double = FormatNumber(lblfactiva21.Text, 2)
            Dim iva105 As Double = FormatNumber(lblfactiva105.Text, 2)

            Dim iva0 As Double = 0
            Dim subtotal As Double = 0
            Dim ivatotal As Double = 0
            Dim total As Double = 0

            Select Case tipofact
            ' If tipofact <> 30 Then,31,32' Or tipofact <> 31 Or tipofact <> 32 Then
                Case 11, 12, 13
                    ' MsgBox("c")
                    iva0 = 0
                    subtotal = FormatNumber(lblfactsubtotal.Text, 2) 'Math.Round(sub21 + sub105, 2)
                    ivatotal = 0 'Math.Round(iva21 + iva105, 2)
                    total = subtotal ' Math.Round(subtotal + ivatotal, 2)
                Case Else
                    ' MsgBox("otro ")
                    iva0 = 0
                    subtotal = Math.Round(sub21 + sub105, 2)
                    ivatotal = Math.Round(iva21 + iva105, 2)
                    total = Math.Round(subtotal + ivatotal, 2)
            End Select
            'MsgBox(total)
            Select Case tipofact
                Case 1
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaA
                Case 2
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoA
                Case 3
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoA
                Case 6
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaB
                Case 7
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoB
                Case 8
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoB
                Case 11
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaC
                Case 12
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoC
                Case 13
                    cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoC
                Case Else
                    MsgBox("tipo de comprobante no admitido")
                    EnProgreso.Close()
                    Exit Sub
            End Select
            'MsgBox("2")
            Select Case TipoIVAContr
                Case 1
                    contribtipo = WSAFIPFE.Factura.TipoReponsable.ResponsableInscripto
                    doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                    idiva = 5
                Case 5
                    contribtipo = WSAFIPFE.Factura.TipoReponsable.Exento
                    doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                    idiva = 3
                Case 4
                    If txtcliecuitcuil.Text = "" Then
                        MsgBox("Debe ingresar el DNI o CUIL del cliente")
                        EnProgreso.Close()
                        Exit Sub
                    ElseIf txtcliecuitcuil.Text <> "" And IsNumeric(txtcliecuitcuil.Text) And txtcliecuitcuil.Text <> "0" Then

                        contribtipo = WSAFIPFE.Factura.TipoReponsable.ConsumidorFinal
                        doctipo = WSAFIPFE.Factura.TipoDocumento.DNI
                        'txtcuit.Text = 0
                        idiva = 3
                    Else
                        MsgBox("debe ingresar un DNI o CUIL correcto")
                        EnProgreso.Close()
                        Exit Sub
                    End If
                Case 6
                    contribtipo = WSAFIPFE.Factura.TipoReponsable.Monotributo
                    doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                    idiva = 3
                Case Else
                    MsgBox("Tipo de contribuyente no admitido")
                    EnProgreso.Close()
                    Exit Sub
            End Select
            'MsgBox(FacturaElectro.cuit & "-" & FacturaElectro.certificado & "-" & FacturaElectro.licencia & "-" & FacturaElectro.passcertificado)
            lresultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, FacturaElectro.cuit, Application.StartupPath & FacturaElectro.certificado, Application.StartupPath & FacturaElectro.licencia)
            fe.ArchivoCertificadoPassword = FacturaElectro.passcertificado
            If lresultado = True Then
                lresultado = fe.f1ObtenerTicketAcceso()
                'MsgBox("Tiket obtenido" )
            Else
                MsgBox("NO SE PUDO OBTENER EL TIKET DE ACCESO A AFIP." & vbNewLine & "Motivo:" & fe.UltimoNumeroError & vbNewLine & fe.UltimoMensajeError)
                EnProgreso.Close()
                Exit Sub
            End If


            If lresultado = True Then
                ' MsgBox("Preparando datos")
                fe.F1CabeceraCbteTipo = cbtetipo
                fe.F1CabeceraPtoVta = Val(lblfactptovta.Text)
                fe.F1CabeceraCantReg = 1
                fe.F1DetalleMonId = "PES"
                fe.F1DetalleMonCotiz = 1
                fe.F1DetalleConcepto = 1
                fe.F1DetalleDocTipo = doctipo
                fe.F1DetalleDocNro = txtcliecuitcuil.Text.Replace("-", "")
                fe.F1DetalleCbteDesdeS = Val(lblfactnumero.Text)
                fe.F1DetalleCbteHastaS = Val(lblfactnumero.Text)
                fe.F1DetalleCbteFch = Format(Now, "yyyyMMdd")

                Dim cantiva As Integer

                If tipofact <> 11 Or tipofact <> 12 Or tipofact <> 13 Then
                    'Else
                    If iva105 = 0 And iva21 <> 0 And sub0 = 0 Then
                        '        MsgBox("1")
                        fe.F1DetalleIvaItemCantidad = 1
                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 5
                        fe.F1DetalleIvaBaseImp = sub21
                        fe.F1DetalleIvaImporte = iva21

                    ElseIf iva105 <> 0 And iva21 <> 0 And sub0 = 0 Then
                        '       MsgBox("2")
                        fe.F1DetalleIvaItemCantidad = 2

                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 5
                        fe.F1DetalleIvaBaseImp = sub21
                        fe.F1DetalleIvaImporte = iva21

                        fe.f1IndiceItem = 1
                        fe.F1DetalleIvaId = 4
                        fe.F1DetalleIvaBaseImp = sub105
                        fe.F1DetalleIvaImporte = iva105

                    ElseIf iva105 <> 0 And iva21 = 0 And sub0 = 0 Then
                        '      MsgBox("3")
                        fe.F1DetalleIvaItemCantidad = 1
                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 4
                        fe.F1DetalleIvaBaseImp = sub105
                        fe.F1DetalleIvaImporte = iva105

                    ElseIf iva105 = 0 And iva21 <> 0 And sub0 <> 0 Then
                        '     MsgBox("4")
                        fe.F1DetalleIvaItemCantidad = 2

                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 5
                        fe.F1DetalleIvaBaseImp = sub21
                        fe.F1DetalleIvaImporte = iva21

                        fe.f1IndiceItem = 1
                        fe.F1DetalleIvaId = 3
                        fe.F1DetalleIvaBaseImp = sub0
                        fe.F1DetalleIvaImporte = 0

                    ElseIf iva105 <> 0 And iva21 <> 0 And sub0 <> 0 Then
                        '    MsgBox("5")
                        fe.F1DetalleIvaItemCantidad = 3

                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 5
                        fe.F1DetalleIvaBaseImp = sub21
                        fe.F1DetalleIvaImporte = iva21

                        fe.f1IndiceItem = 1
                        fe.F1DetalleIvaId = 4
                        fe.F1DetalleIvaBaseImp = sub105
                        fe.F1DetalleIvaImporte = iva105

                        fe.f1IndiceItem = 2
                        fe.F1DetalleIvaId = 3
                        fe.F1DetalleIvaBaseImp = sub0
                        fe.F1DetalleIvaImporte = 0


                    ElseIf iva105 <> 0 And iva21 = 0 And sub0 <> 0 Then
                        '   MsgBox("6")
                        fe.F1DetalleIvaItemCantidad = 2

                        fe.f1IndiceItem = 0
                        fe.F1DetalleIvaId = 4
                        fe.F1DetalleIvaBaseImp = sub105
                        fe.F1DetalleIvaImporte = iva105

                        fe.f1IndiceItem = 1
                        fe.F1DetalleIvaId = 3
                        fe.F1DetalleIvaBaseImp = sub0
                        fe.F1DetalleIvaImporte = 0

                    End If
                End If
                'MsgBox("4")
                fe.F1DetalleImpTotal = total
                fe.F1DetalleImpTotalConc = 0
                fe.F1DetalleImpNeto = subtotal
                fe.F1DetalleImpIva = ivatotal
                'If MsgBox("total: " & total & vbNewLine & "Neto: " & subtotal & vbNewLine & "ImpIVA: " & ivatotal & vbNewLine & vbNewLine & "esta correcto?", vbYesNoCancel) = MsgBoxResult.Yes Then
                lresultado = fe.F1CAESolicitar()
                'Else
                'Exit Sub
                'End If

                If lresultado = True Then
                    If fe.F1RespuestaResultado = "R" Then
                        MsgBox("Solicitud rechazada " & fe.UltimoMensajeError & " - " & fe.UltimoNumeroError)
                        lblobservacionescae.Text = "Resultado: " & fe.F1RespuestaResultado & vbNewLine
                        lblobservacionescae.Text &= "Observaciones: " & fe.F1RespuestaDetalleObservacionMsg1 & fe.F1RespuestaDetalleObservacionMsg
                        lblobservacionescae.Text &= "error: " & fe.F1RespuestaDetalleObservacionMsg & fe.UltimoMensajeError & vbNewLine
                        lblobservacionescae.Text &= "Ultimo otorgado: " & fe.F1CompUltimoAutorizado(Val(lblfactptovta.Text), cbtetipo)
                        pncaerechazado.Visible = True
                        pncaeaprobado.Visible = False
                        EnProgreso.Close()
                        Exit Sub
                    ElseIf fe.F1RespuestaResultado = "A" Then

                        lblestadoCAE.Text = "CAE: " & fe.F1RespuestaDetalleCae
                        lblvtoCAE.Text = "Vto: " & fe.F1RespuestaDetalleCAEFchVto
                        lblobservacionescae.Text = "Resultado: " & fe.F1RespuestaResultado & vbNewLine
                        lblobservacionescae.Text &= "Observaciones: " & fe.F1RespuestaDetalleObservacionMsg1 & vbNewLine
                        lblobservacionescae.Text &= "error: " & fe.F1RespuestaDetalleObservacionMsg & fe.UltimoMensajeError & vbNewLine
                        lblobservacionescae.Text &= "Ultimo otorgado: " & fe.F1CompUltimoAutorizado(Val(lblfactptovta.Text), cbtetipo)
                        lblcodigobarras.Text = fe.f1CodigoDeBarraAFIP
                        Reconectar()
                        Dim lector As System.Data.IDataReader
                        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                        sql.Connection = conexionPrinc
                        sql.CommandText = "update fact_conffiscal set confnume=" & Val(lblfactnumero.Text) & " where donfdesc= " & tipofact & " and ptovta=" & ptovta
                        sql.CommandType = CommandType.Text
                        lector = sql.ExecuteReader
                        lector.Read()
                        cmdguardar.Enabled = True
                        cmdsolicitarcae.Enabled = False
                        pncaeaprobado.Visible = True
                        pncaerechazado.Visible = False
                    End If

                Else
                    lblobservacionescae.Text = "error: " & fe.F1RespuestaDetalleObservacionMsg & fe.UltimoMensajeError & vbNewLine
                    lblobservacionescae.Text &= "Ultimo otorgado: " & fe.F1CompUltimoAutorizado(Val(lblfactptovta.Text), cbtetipo)
                    cmdguardar.Enabled = False
                    pncaerechazado.Visible = True
                    pncaeaprobado.Visible = False
                End If
            Else
                MsgBox("Error en el tiket " & vbNewLine & "Error: " & fe.UltimoMensajeError)
            End If
        Catch ex As Exception
            tmrcontrolarnumfact.Enabled = True
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
        EnProgreso.Close()
    End Sub

    Private Sub dtproductos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtproductos.RowsAdded
        'dtproductos.CurrentCell = dtproductos.Rows(e.RowIndex).Cells(1)

    End Sub

    Private Sub txtdescripcionPLU_KeyUp(sender As Object, e As KeyEventArgs) Handles txtdescripcionPLU.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtivaPLU.Focus()
        End If
    End Sub

    Private Sub txtivaPLU_KeyUp(sender As Object, e As KeyEventArgs) Handles txtivaPLU.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtpreciounitPLU.Focus()
        End If
    End Sub

    Private Sub txtpreciounitPLU_KeyUp(sender As Object, e As KeyEventArgs) Handles txtpreciounitPLU.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtcantPLU.Focus()
        End If
    End Sub

    Private Sub txtcodPLU_GotFocus(sender As Object, e As EventArgs) Handles txtcodPLU.GotFocus
        txtcodPLU.BackColor = Color.LightSalmon
    End Sub

    Private Sub txtcodPLU_LostFocus(sender As Object, e As EventArgs) Handles txtcodPLU.LostFocus
        txtcodPLU.BackColor = Color.White
    End Sub
    Private Sub txtdescripcionPLU_LostFocus(sender As Object, e As EventArgs) Handles txtdescripcionPLU.LostFocus
        txtdescripcionPLU.BackColor = Color.White
    End Sub

    Private Sub txtdescripcionPLU_GotFocus(sender As Object, e As EventArgs) Handles txtdescripcionPLU.GotFocus
        txtdescripcionPLU.BackColor = Color.LightSalmon
    End Sub

    Private Sub txtivaPLU_GotFocus(sender As Object, e As EventArgs) Handles txtivaPLU.GotFocus
        txtivaPLU.BackColor = Color.LightSalmon
    End Sub

    Private Sub txtivaPLU_LostFocus(sender As Object, e As EventArgs) Handles txtivaPLU.LostFocus
        txtivaPLU.BackColor = Color.White
    End Sub

    Private Sub txtpreciounitPLU_GotFocus(sender As Object, e As EventArgs) Handles txtpreciounitPLU.GotFocus
        txtpreciounitPLU.BackColor = Color.LightSalmon
    End Sub

    Private Sub txtpreciounitPLU_LostFocus(sender As Object, e As EventArgs) Handles txtpreciounitPLU.LostFocus
        txtpreciounitPLU.BackColor = Color.White
    End Sub

    Private Sub txtcantPLU_GotFocus(sender As Object, e As EventArgs) Handles txtcantPLU.GotFocus
        txtcantPLU.BackColor = Color.LightSalmon
    End Sub

    Private Sub txtcantPLU_LostFocus(sender As Object, e As EventArgs) Handles txtcantPLU.LostFocus
        txtcantPLU.BackColor = Color.White
    End Sub

    Private Sub dtproductos_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtproductos.UserDeletedRow
        CalcularTotales()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ''aspirantes.busqueda = txtclierazon.Text
        'selclie.llama = "ptovta"
        'selclie.dtpersonal.Focus()
        frmaspirantes.Show()
        frmaspirantes.cmdnuevapers.PerformClick()
        frmaspirantes.txtrazon.Focus()
        frmaspirantes.cmblistas.SelectedValue = listaPrecios
        frmaspirantes.cmbvendedor.SelectedValue = DatosAcceso.Vendedor
        'selclie.TopMost = True

    End Sub

    Private Sub txtcodPLU_TextChanged(sender As Object, e As EventArgs) Handles txtcodPLU.TextChanged

    End Sub

    Private Sub dtproductos_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtproductos.RowHeaderMouseClick
        dtproductos.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellContentClick

    End Sub
End Class