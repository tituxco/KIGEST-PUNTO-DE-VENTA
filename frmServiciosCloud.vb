Public Class frmServiciosCloud
    Dim cadena As String
    'Private BindingSourceemp As Windows.Forms.BindingSource = New BindingSource
    Public Sub CargaServiciosCloud()
        Try
            dtcloud.Rows.Clear()
            Reconectar()
            Dim consultacloud As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, cliente, sistema,bd, codus, clave, modulo,autorizado,debe 
            from AuthServ.CliAuth order by autorizado, sistema, cliente asc", conexionPrinc)
            Dim tablacloud As New DataTable
            Dim infocloud() As DataRow
            consultacloud.Fill(tablacloud)
            infocloud = tablacloud.Select()

            Dim i As Integer
            For i = 0 To infocloud.GetUpperBound(0)
                dtcloud.Rows.Add(infocloud(i)(0), infocloud(i)(1), infocloud(i)(2).ToString, infocloud(i)(3).ToString, infocloud(i)(4).ToString, infocloud(i)(5).ToString, infocloud(i)(6).ToString, infocloud(i)(7).ToString)
                If infocloud(i)(7) = 0 Then

                    dtcloud.Rows(dtcloud.RowCount - 2).DefaultCellStyle.BackColor = Color.OrangeRed
                End If
                If infocloud(i)(8) = 1 Then
                    dtcloud.Rows(dtcloud.RowCount - 2).DefaultCellStyle.BackColor = Color.Green
                ElseIf infocloud(i)(8) = 2 Then
                    dtcloud.Rows(dtcloud.RowCount - 2).DefaultCellStyle.BackColor = Color.Yellow
                End If

            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmServiciosCloud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        trvmodulos.ExpandAll()
        CargaServiciosCloud()
    End Sub
    Private Sub ObtenerCadenaTreeView(ByRef Nodos As TreeNodeCollection)

        For Each Nodo As TreeNode In Nodos
            If Nodo.Nodes.Count = 0 Then
                If Nodo.Checked = True Then cadena &= "-" & Nodo.Tag
            Else
                ObtenerCadenaTreeView(Nodo.Nodes)
            End If
        Next
    End Sub
    Private Sub EstablecerModulosTreeView(ByRef Nodos As TreeNodeCollection)

        For Each Nodo As TreeNode In Nodos
            If Nodo.Nodes.Count = 0 Then
                If InStr(dtcloud.CurrentRow.Cells(6).Value, Nodo.Tag) Then
                    Nodo.Checked = True
                Else
                    Nodo.Checked = False
                End If
            Else
                    EstablecerModulosTreeView(Nodo.Nodes)
            End If
        Next
    End Sub

    Private Sub dtcloud_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtcloud.CellEnter
        EstablecerModulosTreeView(trvmodulos.Nodes)
    End Sub

    Private Sub dtcloud_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dtcloud.RowValidated
        'Try
        '    Dim sqlQuery As String = "update AuthServ.CliAuth set cliente=?cliente, sistema=?sistema,bd=?clbd," _
        '    & "codus=?auusua,clave=?aupass, autorizado=?autorizado where id=" & dtcloud.Rows(e.RowIndex).Cells(0).Value
        '    Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
        '    With comandoadd.Parameters
        '        .AddWithValue("?cliente", dtcloud.Rows(e.RowIndex).Cells(1).Value.ToString.ToUpper)
        '        .AddWithValue("?sistema", dtcloud.Rows(e.RowIndex).Cells(2).Value.ToString.ToUpper)
        '        .AddWithValue("?clbd", dtcloud.Rows(e.RowIndex).Cells(3).Value.ToString)
        '        .AddWithValue("?auusua", dtcloud.Rows(e.RowIndex).Cells(4).Value)
        '        .AddWithValue("?aupass", dtcloud.Rows(e.RowIndex).Cells(5).Value)
        '        .AddWithValue("?autorizado", dtcloud.Rows(e.RowIndex).Cells(7).Value)

        '    End With
        '    comandoadd.ExecuteNonQuery()
        '    If dtcloud.Rows(e.RowIndex).Cells(7).Value = 0 Then
        '        dtcloud.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.OrangeRed
        '    Else
        '        dtcloud.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        '    End If
        '    CargaServiciosCloud()
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        cadena = ""
        ObtenerCadenaTreeView(trvmodulos.Nodes)
        '        MsgBox(cadena)

        If MsgBox("esta seguro que desea actualizar los privilegios de este cliente?", vbYesNo + vbQuestion) = vbNo Then
            Exit Sub
        End If
        Dim sqlQuery As String = "update AuthServ.CliAuth set modulo=?modulo where id=" & dtcloud.CurrentRow.Cells(0).Value
        Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
        With comandoadd.Parameters
            .AddWithValue("?modulo", cadena)
        End With
        comandoadd.ExecuteNonQuery()
        If dtcloud.CurrentRow.Cells(0).Value = 0 Then
            dtcloud.CurrentRow.DefaultCellStyle.BackColor = Color.OrangeRed
        Else
            dtcloud.CurrentRow.DefaultCellStyle.BackColor = Color.White
        End If
        CargaServiciosCloud()
    End Sub

    Private Sub dtcloud_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtcloud.CellContentClick

    End Sub

    Private Sub txtbuscaemp_TextChanged(sender As Object, e As EventArgs) Handles txtbuscaemp.TextChanged
        Dim filaEncontrada As Integer = 0
        Try
            For Each fila As DataGridViewRow In dtcloud.Rows

                If InStr(fila.Cells(1).Value.ToString.ToLower, txtbuscaemp.Text.ToLower) <> 0 Then
                    'MsgBox(fila.Cells(1).Value)
                    fila.Selected = True
                    filaEncontrada = fila.Index
                    Exit For
                End If
            Next
            dtcloud.Rows(filaEncontrada).Selected = True
            dtcloud.FirstDisplayedScrollingRowIndex = filaEncontrada
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        agregarUsuarioCloud.Show()
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click

    End Sub

    Private Sub dtcloud_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtcloud.CellEndEdit
        If e.ColumnIndex = 5 Then
            Dim sqlQuery As String = "update AuthServ.CliAuth set clave=sha('" & dtcloud.CurrentRow.Cells(5).Value & "') where id=" & dtcloud.CurrentRow.Cells(0).Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            CargaServiciosCloud()
            dtcloud.Rows(e.RowIndex).Selected = True
        ElseIf e.ColumnIndex = 7 Then
            Dim sqlQuery As String = "update AuthServ.CliAuth set autorizado ='" & dtcloud.CurrentRow.Cells(7).Value & "' where id=" & dtcloud.CurrentRow.Cells(0).Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            CargaServiciosCloud()
            dtcloud.Rows(e.RowIndex).Selected = True
        ElseIf e.ColumnIndex = 4 Then
            Dim sqlQuery As String = "update AuthServ.CliAuth set codus ='" & dtcloud.CurrentRow.Cells(4).Value & "' where id=" & dtcloud.CurrentRow.Cells(0).Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            CargaServiciosCloud()
            dtcloud.Rows(e.RowIndex).Selected = True
        ElseIf e.ColumnIndex = 3 Then
            Dim sqlQuery As String = "update AuthServ.CliAuth set bd ='" & dtcloud.CurrentRow.Cells(3).Value & "' where id=" & dtcloud.CurrentRow.Cells(0).Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            CargaServiciosCloud()
            dtcloud.Rows(e.RowIndex).Selected = True
        ElseIf e.ColumnIndex = 2 Then
            Dim sqlQuery As String = "update AuthServ.CliAuth set sistema ='" & dtcloud.CurrentRow.Cells(2).Value & "' where id=" & dtcloud.CurrentRow.Cells(0).Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            CargaServiciosCloud()
            dtcloud.Rows(e.RowIndex).Selected = True
        ElseIf e.ColumnIndex = 1 Then
            Dim sqlQuery As String = "update AuthServ.CliAuth set cliente ='" & dtcloud.CurrentRow.Cells(1).Value & "' where id=" & dtcloud.CurrentRow.Cells(0).Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            CargaServiciosCloud()
            dtcloud.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Try
        If rdseleccionadas.Checked = True Then
                Reconectar()
                Dim sqlquery As String
                Dim DATABASE As String
                DATABASE = dtcloud.CurrentRow.Cells("DBClie").Value
                sqlquery = txtsentencias.Text
                conexionSEC.ChangeDatabase(DATABASE)
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlquery, conexionSEC)
                comandoadd.ExecuteNonQuery()
                MsgBox("modificaciones de estructura de BD ejecutadoas")
            ElseIf rdprefijo.Checked = True Then
                Dim i As Integer
                For i = 0 To ListBox1.Items.Count - 1
                    Reconectar()
                    Dim sqlquery As String
                    Dim DATABASE As String
                    DATABASE = ListBox1.Items(i)
                    sqlquery = txtsentencias.Text
                    conexionSEC.ChangeDatabase(DATABASE)
                    Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlquery, conexionSEC)
                On Error Resume Next
                comandoadd.ExecuteNonQuery()


                Console.WriteLine(ListBox1.Items(i) & " se ha modificado")
                Next
                MsgBox("todas las bases de datos se han modificado")
            End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub rdprefijo_CheckedChanged(sender As Object, e As EventArgs) Handles rdprefijo.CheckedChanged

    End Sub

    Private Sub txtprefijobd_TextChanged(sender As Object, e As EventArgs) Handles txtprefijobd.TextChanged

    End Sub

    Private Sub txtprefijobd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtprefijobd.KeyDown
        If e.KeyCode = Keys.Enter Then
            ListBox1.Items.Clear()
            For Each servicio As DataGridViewRow In dtcloud.Rows
                If InStr(servicio.Cells("DBClie").Value, txtprefijobd.Text) <> 0 And ExisteBD(servicio.Cells("DBClie").Value) = False Then
                    ListBox1.Items.Add(servicio.Cells("DBClie").Value)
                End If
            Next
        End If
    End Sub
    Private Function ExisteBD(comparar As String) As Boolean
        Dim i As Integer
        Dim enc As Integer
        For i = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(i) = comparar Then
                enc = enc + 1
            End If
        Next
        If enc = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Delete Then
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        agregarUsuarioCloud.idDuplicado = dtcloud.CurrentRow.Cells("id").Value
        agregarUsuarioCloud.duplicar = True
        agregarUsuarioCloud.Show()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MsgBox("esta seguro que desea cambiar el estado deudor del cliente?", vbYesNo + vbQuestion) = vbNo Then
            Exit Sub
        End If
        Dim mensaje As String = InputBox("Ingrese mensaje", "pasar cliente a deudor", "IMPORTE DEUDA VENCIDA: $")
        Dim sqlQuery As String = "update AuthServ.CliAuth set debe=if(debe=1,0,1), mensaje='" & mensaje & "' where id=" & dtcloud.CurrentRow.Cells(0).Value
        Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)

        comandoadd.ExecuteNonQuery()
        If dtcloud.CurrentRow.DefaultCellStyle.BackColor = Color.Green Then
            dtcloud.CurrentRow.DefaultCellStyle.BackColor = Color.White
        Else
            dtcloud.CurrentRow.DefaultCellStyle.BackColor = Color.Green
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("esta seguro que desea enviar mensaje al cliente?", vbYesNo + vbQuestion) = vbNo Then
            Exit Sub
        End If
        Dim mensaje As String = InputBox("Ingrese mensaje", "enviar mensaje", "MENSAJE: $")
        Dim sqlQuery As String = "update AuthServ.CliAuth set debe=if(debe=2,0,2), mensaje='" & mensaje & "' where id=" & dtcloud.CurrentRow.Cells(0).Value
        Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)

        comandoadd.ExecuteNonQuery()
        If dtcloud.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow Then
            dtcloud.CurrentRow.DefaultCellStyle.BackColor = Color.White
        Else
            dtcloud.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow
        End If
    End Sub
End Class