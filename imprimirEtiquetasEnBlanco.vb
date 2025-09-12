Imports System.Drawing.Printing
Imports System.IO

Public Class imprimirEtiquetasEnBlanco

    Dim tamEtiq As Size
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RedimensionarEtiqueta()
        Dim tam1 As Single = txttam1.Text
        Dim tam2 As Single = txttam2.Text
        Dim tam3 As Single = txttam3.Text
        Dim tam4 As Single = txttam4.Text

        Dim font1 As New Font("Arial", tam1, FontStyle.Bold)
        Dim font2 As New Font("Arial", tam2)
        Dim font3 As New Font("Arial", tam3)
        Dim font4 As New Font("Arial", tam4, FontStyle.Bold)

        Dim rect1 As Rectangle = New Rectangle(0, 0, tamEtiq.Width, tamEtiq.Height)

        Dim bmp As New Bitmap(tamEtiq.Width, tamEtiq.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim laBytImagen() As Byte = Nothing

        Reconectar()

        Dim anchoImg As Integer = Image.FromFile(Application.StartupPath & "\logo2.jpg").Size.Width
        Dim posInicImg As Integer = (tamEtiq.Width - anchoImg) / 3

        'g.FillRectangle(Brushes.Aqua, bmp.GetBounds(GraphicsUnit.Pixel ))
        g.FillRectangle(Brushes.Aqua, rect1)

        Dim formato As New StringFormat
        Dim formatoCentro As New StringFormat
        Dim formatoMultilinea As New StringFormat
        formato.Alignment = StringAlignment.Near
        formato.LineAlignment = StringAlignment.Near

        'formatoCentro.Alignment = StringAlignment.Center
        'formatoCentro.LineAlignment = StringAlignment.Center





        g.DrawImage(Image.FromFile(Application.StartupPath & "\logo2.jpg"), posInicImg, 0)

        g.DrawString(TextBox1.Text, font1, Brushes.Black, 0, ConvertirCMaPX(txtEspL1.Text), formatoCentro) 'PRODUCTO
        g.DrawString(TextBox2.Text, font2, Brushes.Black, 0, ConvertirCMaPX(txtEspL2.Text), formato) 'AROMA
        g.DrawString(TextBox3.Text, font3, Brushes.Black, 0, ConvertirCMaPX(txtEspL3.Text), formato) 'PRESENTACION
        g.DrawString(TextBox4.Text, font4, Brushes.Black, 100, ConvertirCMaPX(txtEspL4.Text), formato) 'PIE

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
            pgSize.RawKind = Printing.PaperKind.Custom
            'If My.Settings.TipoEtiqueta = 0 Then
            '    pgSize.Width = 180 '216.5 '5,5cm
            '    pgSize.Height = 173.23      '4,4cm
            'ElseIf My.Settings.TipoEtiqueta = 1 Then
            '    pgSize.Width = 196.8 '5cm
            '    pgSize.Height = 118  '3cm
            'End If

            pgSize.Width = tamEtiq.Width
            pgSize.Height = tamEtiq.Height

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RedimensionarEtiqueta()
    End Sub
    Private Sub RedimensionarEtiqueta()
        Dim alto As Double = CDbl(txtalto.Text)
        Dim ancho As Double = CDbl(txtancho.Text)

        tamEtiq.Width = ConvertirCMaPX(ancho)
        tamEtiq.Height = ConvertirCMaPX(alto)

        PictureBox1.Width = tamEtiq.Width
        PictureBox1.Height = tamEtiq.Height

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub imprimirEtiquetasEnBlanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RedimensionarEtiqueta()
    End Sub
End Class