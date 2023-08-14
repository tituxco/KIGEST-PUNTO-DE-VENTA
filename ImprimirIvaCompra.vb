Imports Microsoft.Reporting.WinForms
Public Class ImprimirIvaCompra
    Public tipolibro As String
    Public hojasant As Integer
    Private Sub ImprimirIvaCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.rptivacompra.RefreshReport()
    End Sub

    Private Sub rptivacompra_PrintingBegin(sender As Object, e As ReportPrintEventArgs) Handles rptivacompra.PrintingBegin
        Try
            Reconectar()
            Dim sql As String

        Catch ex As Exception
            MsgBox(ex.Message)
            e.Cancel = True
        End Try
        'Me.Close()
    End Sub
End Class