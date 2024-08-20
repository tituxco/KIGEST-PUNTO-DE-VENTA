Public Class selprod
    Public Shared busqueda As String
    Public Shared fila As String
    Public Shared nomSel As String
    Public Shared hcSel As String
    Public Shared LLAMA As String
    Public Shared cantidad As String

    Private Sub selprod_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub SELPAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkstock.CheckState = My.Settings.mostrarSoloStock
        CargarProductos()
    End Sub
    Public Sub CargarProductos()
        Try
            Dim busquedatxt As String
            Dim busqtxt
            If My.Settings.metodoBusquedaProd = 1 Then
                busquedatxt = Replace(busqueda, " ", "%")
                busqtxt = " descripcion like '%" & busquedatxt & "%' "
            ElseIf My.Settings.metodoBusquedaProd = 0 Then
                busqtxt = " descripcion like '" & busqueda & "%'"
            Else
                busqtxt = " descripcion like '%' "
            End If

            Dim busqStock As String = ""
            If chkstock.Checked = True Then
                busqStock = " having stock >0"
            End If

            Dim visProd As String = ""
            If My.Settings.visualizacionProducto = 0 Then
                visProd = "concat(descripcion,' ', detalles) as descripcion, "
            ElseIf My.Settings.visualizacionProducto = 1 Then
                visProd = "descripcion, "
            End If
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id as IDProd, " & visProd &
            "(select if (isnull(stock),0,sum(replace(stock,',','.'))) from fact_insumos_lotes  where idproducto= ins.id and idalmacen=" & My.Settings.idAlmacen & ") as stock, codigo as COD, round((replace(precio,',','.') * 1.21),2) as precioLista from fact_insumos as ins " _
            & " where " & busqtxt & " and eliminado=0 order by descripcion asc limit 30", conexionPrinc)
            Dim tablaPers As New DataTable
            'Dim ds As New DataSet

            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            consulta.Fill(tablaPers)
            dtproductos.DataSource = tablaPers
            If chkstock.Checked = True Then
                Dim filtro As DataTable = DirectCast(dtproductos.DataSource, DataTable)
                dtproductos.DataSource = filtro.AsEnumerable() _
                    .Where(Function(r) r.Field(Of Double)("stock") > 0) _
                    .CopyToDataTable()
            End If


            'dtpersonal.Columns(2).Visible = False
            'dtproductos.Columns(0).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpersonal_DoubleClick(sender As Object, e As EventArgs) Handles dtproductos.DoubleClick, dtproductos.DoubleClick
        'Try
        '    Select Case LLAMA
        '        Case "nuevaventa"
        '            If dtproductos.CurrentRow.Cells.Item(3).Value.ToString = "" Then
        '                CType(frmprincipal.ActiveMdiChild, nuevaventa).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(0).Value
        '            Else
        '                CType(frmprincipal.ActiveMdiChild, nuevaventa).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(3).Value
        '            End If
        '            CType(frmprincipal.ActiveMdiChild, nuevaventa).cargarProdCod(fila)
        '            CType(frmprincipal.ActiveMdiChild, nuevaventa).CalcularTotales()

        '        Case "nuevopedido"
        '            If dtproductos.CurrentRow.Cells.Item(3).Value.ToString = "" Then
        '                CType(frmprincipal.ActiveMdiChild, nuevopedido).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(0).Value
        '            Else
        '                CType(frmprincipal.ActiveMdiChild, nuevopedido).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(3).Value
        '            End If
        '            CType(frmprincipal.ActiveMdiChild, nuevopedido).cargarProdCod(fila)
        '            CType(frmprincipal.ActiveMdiChild, nuevopedido).CalcularTotales()

        '        Case "fichaequipo"
        '            CType(frmprincipal.ActiveMdiChild, fichaequipo).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(0).Value
        '            CType(frmprincipal.ActiveMdiChild, fichaequipo).cargarProdCod(fila)
        '            CType(frmprincipal.ActiveMdiChild, fichaequipo).CalcularTotales()

        '        Case "ptovta"
        '            If dtproductos.CurrentRow.Cells.Item(3).Value.ToString = "" Then
        '                CType(frmprincipal.ActiveMdiChild, puntoventa).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(0).Value
        '                CType(frmprincipal.ActiveMdiChild, puntoventa).cargarProdCod(fila)
        '            Else
        '                CType(frmprincipal.ActiveMdiChild, puntoventa).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(3).Value
        '                CType(frmprincipal.ActiveMdiChild, puntoventa).cargarProdPLU(dtproductos.CurrentRow.Cells.Item(3).Value, fila)
        '            End If

        '            CType(frmprincipal.ActiveMdiChild, puntoventa).CalcularTotales()

        '    End Select
        '    Me.Close()
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles  dtproductos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case LLAMA
                    Case "nuevaventa"
                        If dtproductos.CurrentRow.Cells.Item(3).Value.ToString = "" Then
                            CType(frmprincipal.ActiveMdiChild, nuevaventa).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(0).Value
                        Else
                            CType(frmprincipal.ActiveMdiChild, nuevaventa).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(3).Value
                        End If
                        CType(frmprincipal.ActiveMdiChild, nuevaventa).cargarProdCod(fila)
                        CType(frmprincipal.ActiveMdiChild, nuevaventa).CalcularTotales()

                    Case "nuevopedido"
                        If dtproductos.CurrentRow.Cells.Item(3).Value.ToString = "" Then
                            CType(frmprincipal.ActiveMdiChild, nuevopedido).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(0).Value
                        Else
                            CType(frmprincipal.ActiveMdiChild, nuevopedido).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(3).Value
                        End If
                        CType(frmprincipal.ActiveMdiChild, nuevopedido).cargarProdCod(fila)
                        CType(frmprincipal.ActiveMdiChild, nuevopedido).CalcularTotales()

                    Case "fichaequipo"
                        CType(frmprincipal.ActiveMdiChild, fichaequipo).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(0).Value
                        CType(frmprincipal.ActiveMdiChild, fichaequipo).cargarProdCod(fila)
                        CType(frmprincipal.ActiveMdiChild, fichaequipo).CalcularTotales()

                    'Case "produccion"
                    '    CType(frmprincipal.ActiveMdiChild, produccion).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(3).Value
                    '    CType(frmprincipal.ActiveMdiChild, produccion).cargarProdCod(fila)
                    Case "ptovta"
                        If dtproductos.CurrentRow.Cells.Item(3).Value.ToString = "" Then
                            CType(frmprincipal.ActiveMdiChild, puntoventa).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(0).Value
                            CType(frmprincipal.ActiveMdiChild, puntoventa).cargarProdCod(fila)
                        Else
                            CType(frmprincipal.ActiveMdiChild, puntoventa).dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(3).Value
                            CType(frmprincipal.ActiveMdiChild, puntoventa).cargarProdPLU(dtproductos.CurrentRow.Cells.Item(3).Value, fila)
                        End If

                        CType(frmprincipal.ActiveMdiChild, puntoventa).CalcularTotales()
                    Case "prodlote"
                        ' MsgBox(dtproductos.CurrentRow.Cells.Item(3).Value)                       
                        addProductosLote.dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(3).Value
                        addProductosLote.cargarProdPLU(dtproductos.CurrentRow.Cells.Item(3).Value, fila)
                        addProductosLote.calcularPrecios2(fila)
                    Case "romaneo"
                        romaneo.dtproductos.Rows(fila).Cells(1).Value = dtproductos.CurrentRow.Cells.Item(3).Value
                        romaneo.cargarProdPLU(dtproductos.CurrentRow.Cells.Item(3).Value, fila)
                        'addProductosLote.calcularPrecios2(fila)

                End Select
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles  dtproductos.CellContentClick

    End Sub

    Private Sub dtproductos_KeyUp(sender As Object, e As KeyEventArgs) Handles  dtproductos.KeyUp

    End Sub

    Private Sub dtproductos_MouseCaptureChanged(sender As Object, e As EventArgs) Handles  dtproductos.MouseCaptureChanged

    End Sub

    Private Sub chkstock_CheckedChanged(sender As Object, e As EventArgs) Handles chkstock.CheckedChanged
        My.Settings.mostrarSoloStock = chkstock.CheckState
        My.Settings.Save()
        funciones_Globales.GuardarConfiguracionTerminal()
        CargarProductos()

    End Sub
End Class