Imports System.Drawing.Printing
Imports System.IO

Public Class imprimirEtiquetasEnBlanco

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim font1 As New Font("Arial", 15, FontStyle.Bold)
        Dim font2 As New Font("Arial", 12)
        Dim font3 As New Font("Arial", 10)
        Dim font4 As New Font("Arial", 8, FontStyle.Bold)

        Dim bmp As New Bitmap(216, 177)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim laBytImagen() As Byte = Nothing

        Reconectar()

        g.FillRectangle(Brushes.White, bmp.GetBounds(GraphicsUnit.Pixel))
        'g.DrawImage(Image.FromStream(Bytes_Imagen(infoemp(0)(1)))
        g.DrawImage(Image.FromFile(Application.StartupPath & "\logo2.jpg"), 0, 0)
        g.DrawString(TextBox1.Text, font1, Brushes.Black, 0, 80) 'PRODUCTO
        g.DrawString(TextBox2.Text, font2, Brushes.Black, 0, 100) 'AROMA
        g.DrawString(TextBox3.Text, font3, Brushes.Black, 0, 120) 'PRESENTACION
        g.DrawString(TextBox4.Text, font4, Brushes.Black, 100, 130) 'PIE

        PictureBox1.Image = New Bitmap(bmp)
    End Sub

    Private Sub ImprimirEtiqueta(ByVal sender As System.Object, ByVal e As PrintPageEventArgs)
        e.Graphics.DrawImage(PictureBox1.Image, 0, 0)

    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim PrintTxt As New PrintDocument
        Dim pgSize As New PaperSize
        Try
            If My.Settings.TipoEtiqueta = 0 Then
                pgSize.Width = 180 '196.8 '
                pgSize.Height = 173.23 '100
            ElseIf My.Settings.TipoEtiqueta = 1 Then
                pgSize.Width = 196.8 '  135 '180 '196.8 '
                pgSize.Height = 118  '78 '173.23 '100
            End If

            PrintTxt.DefaultPageSettings.PaperSize = pgSize
            AddHandler PrintTxt.PrintPage, AddressOf ImprimirEtiqueta
            Dim paginas As Integer = CInt(TextBox5.Text)
            Dim i As Integer
            PrintTxt.PrinterSettings.PrinterName = My.Settings.EtiquetadoraNmb
            For i = 1 To paginas
                PrintTxt.Print()
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class