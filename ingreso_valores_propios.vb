Public Class ingreso_valores_propios
    Dim selFech As New CalendarCell
    Dim i As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try 'guardamos el cheque
            Dim sqlQuery As String
            For i = 0 To dtcheques.RowCount - 2
                If dtcheques.Rows(i).Cells(0).Value = Nothing Or dtcheques.Rows(i).Cells(3).Value = Nothing Then
                    MsgBox("algunos de los campos de fecha son nulos, por favor complete")
                    Exit Sub
                End If
            Next

            For i = 0 To dtcheques.RowCount - 2
                Reconectar()
                sqlQuery = "insert into fact_cheques " _
            & "(fecha_emision,fecha_cobro,banco,serie,importe,tipo_cheque,observaciones) values " _
            & "(?femis,?fcobro,?banco,?serie,?importe,'2',?obs)"
                Dim comandoch As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoch.Parameters
                    '.AddWithValue("?cliente", idcliente)
                    '.AddWithValue("?comprobante", idfactura)
                    .AddWithValue("?femis", dtcheques.Rows(i).Cells(0).Value)
                    .AddWithValue("?banco", dtcheques.Rows(i).Cells(1).Value.ToString.ToUpper)
                    .AddWithValue("?serie", dtcheques.Rows(i).Cells(2).Value.ToString.ToUpper)
                    .AddWithValue("?fcobro", dtcheques.Rows(i).Cells(3).Value)
                    .AddWithValue("?importe", dtcheques.Rows(i).Cells(4).Value)
                    .AddWithValue("?obs", dtcheques.Rows(i).Cells(5).Value.ToString.ToUpper)
                End With
                comandoch.ExecuteNonQuery()
            Next
            MsgBox("Cheques agregados correctamente")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ingreso_valores_propios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtcheques.Item(0, dtcheques.RowCount - 1) = selFech.Clone
        dtcheques.Item(3, dtcheques.RowCount - 1) = selFech.Clone
    End Sub

    Private Sub dtcheques_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtcheques.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
        Try
            If e.ColumnIndex = 2 Then
                Dim tablaftipo As New MySql.Data.MySqlClient.MySqlDataAdapter("select id from fact_cheques where serie like '" & dtcheques.CurrentCell.Value & "'", conexionPrinc)
                Dim readftipo As New DataTable
                tablaftipo.Fill(readftipo)
                If readftipo.Rows.Count <> 0 Then
                    MsgBox("ya hay un cheque ingresado con este numero de serie, por favor verifique")
                    dtcheques.CurrentCell.Value = ""
                    Exit Sub
                End If
            ElseIf e.ColumnIndex = 4 Then

                sumarImportes()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub sumarImportes()
        Try

            Dim suma As Double
            For i = 0 To dtcheques.RowCount - 2
                suma += FormatNumber(dtcheques.Rows(i).Cells(4).Value, 2)
            Next
            txttotalvalores.Text = suma
        Catch ex As Exception

        End Try

    End Sub
    Private Sub dtcheques_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtcheques.CellValueChanged
        Try
            If e.ColumnIndex = 0 Then
                dtcheques.Item(0, dtcheques.RowCount - 1) = selFech.Clone
            ElseIf e.ColumnIndex = 3 Then
                dtcheques.Item(3, dtcheques.RowCount - 1) = selFech.Clone
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtcheques_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtcheques.RowsAdded
        sumarImportes()
    End Sub

    Private Sub dtcheques_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtcheques.RowsRemoved
        sumarImportes()
    End Sub

    Private Sub ingreso_valores_propios_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub
End Class