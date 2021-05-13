Public Class frmServiciosCloud
    Dim cadena As String
    'Private BindingSourceemp As Windows.Forms.BindingSource = New BindingSource
    Public Sub CargaServiciosCloud()
        Try
            dtcloud.Rows.Clear()
            Reconectar()
            Dim consultacloud As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, cliente, sistema,bd, codus, clave, modulo,autorizado 
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
        Try
            Dim sqlQuery As String = "update AuthServ.CliAuth set cliente=?cliente, sistema=?sistema,bd=?clbd," _
            & "codus=?auusua,clave=?aupass, autorizado=?autorizado where id=" & dtcloud.Rows(e.RowIndex).Cells(0).Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?cliente", dtcloud.Rows(e.RowIndex).Cells(1).Value.ToString.ToUpper)
                .AddWithValue("?sistema", dtcloud.Rows(e.RowIndex).Cells(2).Value.ToString.ToUpper)
                .AddWithValue("?clbd", dtcloud.Rows(e.RowIndex).Cells(3).Value.ToString)
                .AddWithValue("?auusua", dtcloud.Rows(e.RowIndex).Cells(4).Value)
                .AddWithValue("?aupass", dtcloud.Rows(e.RowIndex).Cells(5).Value)
                .AddWithValue("?autorizado", dtcloud.Rows(e.RowIndex).Cells(7).Value)

            End With
            comandoadd.ExecuteNonQuery()
            If dtcloud.Rows(e.RowIndex).Cells(7).Value = 0 Then
                dtcloud.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.OrangeRed
            Else
                dtcloud.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If
            CargaServiciosCloud()
        Catch ex As Exception

        End Try

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
End Class