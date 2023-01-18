Imports System.Windows.Forms

Public Class Dialog1
    Public periodo As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT ld.codigoAsiento, ld.comprobanteInterno,ld.fecha, ld.concepto, ld.NumPartidas,(SELECT count(*) FROM cm_Asientos where codigoAsiento=ld.codigoAsiento and (cuentaDebeId<>0 or cuentaHaberId<>0)) AS REALES,
            ROUND((SELECT sum(importeDebe) FROM cm_Asientos where codigoAsiento=ld.codigoAsiento and (cuentaDebeId<>0 or cuentaHaberId<>0)),2) as sumDEBE,
            ROUND((SELECT sum(importeHaber) FROM cm_Asientos where codigoAsiento=ld.codigoAsiento and (cuentaDebeId<>0 or cuentaHaberId<>0)),2) as sumHABER
            FROM cm_libroDiario AS ld where ld.fecha like '" & periodo & "-%%" & "'
            having NumPartidas<>REALES or sumDebe<>sumHaber", conexionPrinc)
            Dim tabla As New DataTable

            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            consulta.Fill(tabla)
            dgvasisentos.DataSource = tabla
        Catch ex As Exception

        End Try
    End Sub
End Class
