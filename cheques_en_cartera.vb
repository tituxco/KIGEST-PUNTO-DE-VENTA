Public Class cheques_en_cartera
    Public LLAMA As String
    Public AplicarOP As Boolean
    Dim filterceros As Windows.Forms.BindingSource = New BindingSource
    Dim filpropios As Windows.Forms.BindingSource = New BindingSource

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cheques_en_cartera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarChequesDeTerceros()
        CargarChequesPropios()

    End Sub

    Private Sub CargarChequesDeTerceros()
        Reconectar()
        Dim busq As String

        If rdEnCartera.Checked = True Then
            busq = " where che.tipo_cheque=1 and che.estado_cheque=1"
        ElseIf rdTransferidos.Checked = True Then
            busq = " where che.tipo_cheque=1 and che.estado_cheque=3 and che.cuenta=" & My.Settings.CajaDef
        End If
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select che.id, che.banco, che.serie, che.fecha_cobro, che.importe " _
            & "from fact_cheques as che " _
            & busq, conexionPrinc)
        ' MsgBox(consulta.SelectCommand.CommandText)
        Dim tablacheques As New DataTable
        consulta.Fill(tablacheques)
        filterceros.DataSource = tablacheques
        dtchequesterceros.DataSource = filterceros
        'dtchequesterceros.Columns(1).Visible = True
        dtchequesterceros.ClearSelection()
        'dtchequesterceros.Columns(0).Visible = False

    End Sub

    Private Sub CargarChequesPropios()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select che.id, che.banco, che.serie, " _
            & "che.fecha_cobro, che.importe " _
            & "from fact_cheques as che " _
            & "where che.tipo_cheque=2 and che.estado_cheque=1", conexionPrinc)
            Dim tablacheques As New DataTable

            consulta.Fill(tablacheques)
            filpropios.DataSource = tablacheques
            dtchequespropios.DataSource = filpropios
            dtchequespropios.Columns(1).Visible = False
            dtchequespropios.ClearSelection()
            dtchequespropios.Columns(0).ReadOnly = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
        Try
            If LLAMA = "OP" Then
                With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                    For Each propio As DataGridViewRow In dtchequespropios.Rows
                        If propio.Selected = True Then
                            .dtopcheques.Rows.Add(propio.Cells(0).Value, propio.Cells(1).Value, propio.Cells(2).Value, propio.Cells(3).Value, remplazarcoma(propio.Cells(4).Value), 2)
                        End If
                    Next

                    For Each tercero As DataGridViewRow In dtchequesterceros.Rows
                        If tercero.Selected = True Then
                            .dtopcheques.Rows.Add(tercero.Cells(0).Value, tercero.Cells(1).Value, tercero.Cells(2).Value, tercero.Cells(3).Value, remplazarcoma(tercero.Cells(4).Value), 1)
                        End If
                    Next
                    .CalcularTotalespago()
                End With
            ElseIf LLAMA = "OPMOV" Then
                With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                    For Each propio As DataGridViewRow In dtchequespropios.Rows
                        If propio.Selected = True Then
                            .dtmovimientocheques.Rows.Add(propio.Cells(0).Value, propio.Cells(1).Value, propio.Cells(2).Value, propio.Cells(3).Value, remplazarcoma(propio.Cells(4).Value), 2)
                        End If
                    Next

                    For Each tercero As DataGridViewRow In dtchequesterceros.Rows
                        If tercero.Selected = True Then
                            .dtmovimientocheques.Rows.Add(tercero.Cells(0).Value, tercero.Cells(1).Value, tercero.Cells(2).Value, tercero.Cells(3).Value, remplazarcoma(tercero.Cells(4).Value), 1)
                        End If
                    Next
                    .CalcularTotalesMovimiento()
                End With
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbtercerosSellNone_Click(sender As Object, e As EventArgs) Handles cmbtercerosSellNone.Click
        dtchequesterceros.ClearSelection()
        sumarTotalCheques()
    End Sub

    Private Sub cmbpropiosSellNone_Click(sender As Object, e As EventArgs) Handles cmbpropiosSellNone.Click
        dtchequespropios.ClearSelection()
        sumarTotalCheques()
    End Sub

    Private Sub dtchequesterceros_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtchequesterceros.CellEnter
        sumarTotalCheques()
    End Sub

    Private Sub sumarTotalCheques()
        Try
            Dim total As Double
            For Each terc As DataGridViewRow In dtchequesterceros.Rows
                If terc.Selected = True Then
                    total += FormatNumber(terc.Cells(4).Value.ToString.Replace(".", ","))
                End If
            Next

            For Each prop As DataGridViewRow In dtchequespropios.Rows
                If prop.Selected = True Then
                    total += FormatNumber(prop.Cells(4).Value.ToString.Replace(".", ","))
                End If
            Next

            lbltotalvalores.Text = "Total Valores: $" & total
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbpropiosSellAll_Click(sender As Object, e As EventArgs) Handles cmbpropiosSellAll.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtfiltraterceros.TextChanged
        filterceros.Filter = "serie like '%" & txtfiltraterceros.Text & "%'"
    End Sub

    Private Sub txtfiltrapropios_TextChanged(sender As Object, e As EventArgs) Handles txtfiltrapropios.TextChanged
        filpropios.Filter = "serie like '%" & txtfiltrapropios.Text & "%'"
    End Sub

    Private Sub dtchequesterceros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtchequesterceros.CellContentClick

    End Sub

    Private Sub dtchequesterceros_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dtchequesterceros.CurrentCellDirtyStateChanged
        If dtchequesterceros.IsCurrentCellDirty Then
            dtchequesterceros.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub cmbtercerosSelAll_Click(sender As Object, e As EventArgs) Handles cmbtercerosSelAll.Click

    End Sub

    Private Sub rdTransferidos_CheckedChanged(sender As Object, e As EventArgs) Handles rdTransferidos.CheckedChanged
        CargarChequesDeTerceros()

    End Sub

    Private Sub rdEnCartera_CheckedChanged(sender As Object, e As EventArgs) Handles rdEnCartera.CheckedChanged
        CargarChequesDeTerceros()
    End Sub
End Class