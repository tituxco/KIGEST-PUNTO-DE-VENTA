Public Class GestorUtilidades
    Public Shared Function MostrarProgreso(mensaje As String) As Form
        Dim frmProgreso As New Form()
        With frmProgreso
            .Text = "Procesando..."
            .ControlBox = False
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .StartPosition = FormStartPosition.CenterScreen
            .Size = New Size(400, 110)
            .TopMost = True
            .ShowInTaskbar = False
        End With

        ' Etiqueta de texto
        Dim lbl As New Label()
        With lbl
            .Text = mensaje
            .Location = New Point(20, 20)
            .AutoSize = True
        End With
        frmProgreso.Controls.Add(lbl)

        ' Barra de progreso en modo Marquesina (movimiento continuo)
        Dim barra As New ProgressBar()
        With barra
            .Style = ProgressBarStyle.Marquee
            .MarqueeAnimationSpeed = 30 ' Velocidad del movimiento
            .Location = New Point(20, 50)
            .Size = New Size(340, 25)
        End With
        frmProgreso.Controls.Add(barra)

        ' Mostramos el formulario de forma no modal para que la app siga corriendo
        frmProgreso.Show()
        Application.DoEvents() ' Fuerza a que se dibuje en pantalla al instante

        Return frmProgreso
    End Function


End Class
