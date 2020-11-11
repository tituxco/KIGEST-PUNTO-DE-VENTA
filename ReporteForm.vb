Imports System.IO

Public Class ReporteForm
    Public IDPrestamo As String
    Public PrestamoTabla As DataTable

    Public Sub GenerarReporte()

        Dim strBuilder As New System.Text.StringBuilder

        'Encabezado
        '---------------------------------------------------------------------

        strBuilder.Append("<table border='0' cellpadding='10' cellspacing='0' style='width:100%'>")
        strBuilder.Append("<tr style='font-size:25px' align='center' >")
        strBuilder.Append("<th>Banco Central Mundial</th>")
        strBuilder.Append("</tr>")
        strBuilder.Append("<tr style='font-size:14px' align='center'>")
        strBuilder.Append("<td>Direccion: Calle 4ta. Frente a la plaza</td>")
        strBuilder.Append("</tr>")
        strBuilder.Append("<tr style='font-size:14px' align='center'>")
        strBuilder.Append("<td> " & "Préstamo # " & IDPrestamo & "</td>")
        strBuilder.Append("</tr>")
        strBuilder.Append("<tr style='font-size:24px' align='center'>")
        strBuilder.Append("<td>Listado de pagos pendientes</td>")
        strBuilder.Append("</tr>")
        strBuilder.Append("</table>")



        'Titulo Reporte
        '----------------------------------------------------------------------
        strBuilder.Append("<table border='0' cellpadding='10' cellspacing='0' style='width:100%'>")
        strBuilder.Append("<tr bgcolor='gainsboro'>") 'Inicio de Titulos
        strBuilder.Append(String.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td>", "PERIODO", "FECHA", "CUOTA", "INTERES", "AMORTIZACION", "CAPITAL_RESTANTE", "CAPITAL_AMORTIZADO", "AMORTIZACION_ANTICIPADA"))
        strBuilder.Append("</tr>")  'Fin de titulos

        'Detalle Reporte
        '--------------------------------------------------------------------
        For Each fila As DataRow In PrestamoTabla.Rows

            'MsgBox("<>")
            strBuilder.Append("<tr>") 'Start the row 
            strBuilder.Append(String.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td>",
                          fila.Item(3), Format(fila.Item(4), "dd/MM/yyyy"), fila.Item(5),
                          fila.Item(6), fila.Item(7),
                          fila.Item(8), fila.Item(9),
                          fila.Item(10)))
            strBuilder.Append("</tr>")  'Finish the row 

        Next


        WebBrowser1.DocumentText = strBuilder.ToString

    End Sub

    Public Sub ReportePagos()
        Dim strBuilder As New System.Text.StringBuilder

        'Encabezado
        '---------------------------------------------------------------------

        strBuilder.Append("<table border='0' cellpadding='10' cellspacing='0' style='width:100%'>")
        strBuilder.Append("<tr style='font-size:25px' align='center' >")
        strBuilder.Append("<th>RYM Constructora</th>")
        strBuilder.Append("</tr>")
        strBuilder.Append("<tr style='font-size:14px' align='center'>")
        strBuilder.Append("<td>Direccion: Amenabar 1026</td>")
        strBuilder.Append("</tr>")
        strBuilder.Append("<tr style='font-size:14px' align='center'>")
        strBuilder.Append("<td> " & "Préstamo # " & IDPrestamo & "</td>")
        strBuilder.Append("</tr>")
        strBuilder.Append("<tr style='font-size:24px' align='center'>")
        strBuilder.Append("<td>Pagos realizados</td>")
        strBuilder.Append("</tr>")
        strBuilder.Append("<tr style='font-size:12px' align='center'>")
        strBuilder.Append("<td>*** Pagos que aparecen con monto '0' es por liquidación de préstamo ***</td>")
        strBuilder.Append("</tr>")
        strBuilder.Append("</table>")


        'Titulo Reporte
        '----------------------------------------------------------------------
        strBuilder.Append("<table border='0' cellpadding='10' cellspacing='0' style='width:100%'>")
        strBuilder.Append("<tr bgcolor='gainsboro'>") 'Inicio de Titulos
        strBuilder.Append(String.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", "FECHA", "PERIODO", "ID_PRESTAMO", "MONTO_PAGADO"))
        strBuilder.Append("</tr>")  'Fin de titulos


        'Detalle Reporte
        '--------------------------------------------------------------------
        Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from rym_pagos where id_prestamo='" & IDPrestamo & "'", conexionPrinc)
        Dim ds As New DataSet
        da.Fill(ds)
        Dim fila As DataRow

        For Each fila In ds.Tables(0).Rows
            strBuilder.Append("<tr>") 'Start the row 
            strBuilder.Append(String.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>",
                         Format(fila("FECHA"), "dd/MM/yyyy"), fila("ID_PRESTAMO"), fila("PERIODO"), Format(fila("MONTO_PAGADO"), "standard")))
            strBuilder.Append("</tr>")  'Finish the row 

        Next

        WebBrowser1.DocumentText = strBuilder.ToString

    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            If (File.Exists(SaveFileDialog1.FileName)) Then

            Else

                System.IO.File.Create(SaveFileDialog1.FileName).Close()
            End If
        End If
        My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, WebBrowser1.DocumentText, False)
        Process.Start(SaveFileDialog1.FileName)
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        WebBrowser1.ShowPrintPreviewDialog()
    End Sub

    Private Sub ReporteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class