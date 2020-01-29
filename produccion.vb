Public Class produccion

    Private Sub produccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        'If e.KeyChar = "."c Then
        '    e.Handled = True
        '    SendKeys.Send(",")
        'End If
    End Sub

    Private Sub produccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarFechasProd()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargarFechasProd()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id,fecha from fact_produccion order by id desc", conexionPrinc)
            Dim tablaProd As New DataTable
            consulta.Fill(tablaProd)

            dtproduccion.DataSource = tablaProd
            dtproduccion.Columns(0).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdnuevaprod.Click
        Try
            dtfechaprod.Enabled = True
            dtfechaprod.Value = Format(CDate(Now), "dd/MM/yyyy H:m:ss")

            lblestado.Text = "NUEVO LOTE DE PRODUCCION"
            cmdguardarlote.Enabled = True
            cmdnuevaprod.Enabled = False
            dtproductos.Rows.Clear()
            dtproductos.AllowUserToAddRows = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarLote()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select lt.id, pr.codigo,pr.descripcion, concat(lt.stock,' de ', lt.compracant), pr.id from fact_insumos as pr, fact_insumos_lotes  as lt where lt.idproducto=pr.id and lt.tipo_prod=0 and lt.idfactura= " & dtproduccion.CurrentRow.Cells(0).Value, conexionPrinc)
            Dim tablalot As New DataTable
            'Dim ds As New DataSet
            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            Dim itemlot() As DataRow
            Dim i As Integer
            consulta.Fill(tablalot)
            itemlot = tablalot.Select("")
            dtproductos.Rows.Clear()
            For i = 0 To itemlot.GetUpperBound(0)
                dtproductos.Rows.Add(itemlot(i)(0), itemlot(i)(1), itemlot(i)(2), itemlot(i)(3), itemlot(i)(4))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtproduccion_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtproduccion.CellEnter
        Try
            cargarLote()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdguardarlote_Click(sender As Object, e As EventArgs) Handles cmdguardarlote.Click
        Try
            Dim nombre As String
            Dim vencimiento As String
            Dim stock As String
            Dim idproducto As String
            Dim idfactura As String

            Dim i As Integer
            Dim sqlQuery As String


            sqlQuery = "INSERT INTO fact_produccion (fecha) values ('" & Format(CDate(dtfechaprod.Value), "yyyy-MM-dd H:m:ss") & "')"
            Dim addProduccion As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            addProduccion.ExecuteNonQuery()

            For i = 0 To dtproductos.RowCount - 2
                'nombre = dtproductos.Rows(i).Cells(1).Value.ToString.ToUpper
                'vencimiento = Format(CDate(dtproductos.Rows(i).Cells(5).Value), "yyyy-MM-dd")
                stock = dtproductos.Rows(i).Cells(3).Value
                idproducto = dtproductos.Rows(i).Cells(4).Value
                idfactura = addProduccion.LastInsertedId
                Reconectar()
                sqlQuery = "insert into fact_insumos_lotes  " _
                & "(stock, idproducto, idfactura,compracant,tipo_prod) values " _
                & "(?stock, ?idprod, ?idfact,?cantcomp,'0')"
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters
                    .AddWithValue("?stock", stock)
                    .AddWithValue("?idprod", idproducto)
                    .AddWithValue("?idfact", idfactura)
                    .AddWithValue("?cantcomp", stock)
                End With
                comandoadd.ExecuteNonQuery()
                'dtproductos.Rows(i).Cells(0).Value = comandoadd.LastInsertedId
            Next
            MsgBox(i & " Lote guardados")
            dtproductos.AllowUserToAddRows = False
            CargarFechasProd()
            cmdnuevaprod.Enabled = True
            dtfechaprod.Enabled = False
            cmdguardarlote.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
    Public Sub cargarProdCod(ByRef fila As Integer)
        Dim codPLU As String = dtproductos.Rows(fila).Cells(1).Value
        Dim Busq As String
        If codPLU = "" Then
            MsgBox("Debe ingresar un codigo o PLU")
            dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.Red
            Exit Sub
        End If
        If InStr(codPLU, "#") = 1 Then
            Busq = "where cod_bar= " & Microsoft.VisualBasic.Right(codPLU, codPLU.Length - 1)
        ElseIf Val(codPLU <> 0) Then
            Busq = "where codigo=" & codPLU
        End If

        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT codigo,descripcion,id FROM fact_insumos " & Busq, conexionPrinc)
        Dim tablaprod As New DataTable
        Dim filasProd() As DataRow
        consulta.Fill(tablaprod)
        'dtproductos.DataSource = tablaprod
        '        dtproductos.Rows.Clear()
        filasProd = tablaprod.Select("")
        For i = 0 To filasProd.GetUpperBound(0)
            'dtproductos.Rows(fila).Cells(0).Value = filasProd(i)(1)
            dtproductos.Rows(fila).Cells(1).Value = filasProd(i)(0)
            dtproductos.Rows(fila).Cells(2).Value = filasProd(i)(1)
            dtproductos.Rows(fila).Cells(3).Value = 1
            dtproductos.Rows(fila).Cells(4).Value = filasProd(i)(2)
        Next
    End Sub
    Private Sub dtproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEndEdit
        Try
            Reconectar()
            If e.ColumnIndex = 1 Then
                cargarProdCod(e.RowIndex)
            ElseIf e.ColumnIndex = 2 Then
                selprod.busqueda = dtproductos.CurrentCell.Value()
                selprod.fila = dtproductos.CurrentCellAddress.Y
                selprod.LLAMA = "produccion"
                selprod.dtproductos.Focus()
                selprod.Show()
                selprod.TopMost = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        Try

            dtlistaproducc.Rows.Clear()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
            & "itm.cod,itm.descripcion,sum(replace(itm.cantidad,',','.')) as pedido, " _
            & "(select sum(replace(stock,',','.')) from fact_insumos_lotes where idproducto=itm.cod) as stock " _
            & "from fact_facturas as fact, fact_items as itm " _
            & "where   " _
            & "itm.id_fact=fact.id and fact.tipofact=9 and " _
            & "fact.observaciones like 'PENDIENTE' " _
            & "group by itm.cod", conexionPrinc)

            Dim tablalist As New DataTable
            Dim itmlist() As DataRow
            consulta.Fill(tablalist)

            itmlist = tablalist.Select("")
            Dim i As Integer
            For i = 1 To itmlist.GetUpperBound(0)
                dtlistaproducc.Rows.Add(itmlist(i)(0), itmlist(i)(1), itmlist(i)(2), itmlist(i)(3))
            Next

        Catch ex As Exception

        End Try
    End Sub
End Class