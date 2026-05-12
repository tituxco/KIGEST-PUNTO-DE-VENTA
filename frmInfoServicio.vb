Imports SIGT__KIGEST.datosEstructura
Imports SIGT__KIGEST.GestorAcademia
Public Class frmInfoServicio
    Private _servicio As serv_servicios

    ' Constructor
    Public Sub New(servicioALeer As serv_servicios)
        InitializeComponent()
        Me._servicio = servicioALeer
    End Sub
    Private Sub frmInfoServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtnombreCurso.Text = _servicio.nombre
        txtCostoInscripcion.Text = _servicio.montoInscripcion.ToString()
        txtCuotaMensual.Text = _servicio.montoMensual.ToString()
        txtCostoExamen.Text = _servicio.montoExamen.ToString()
    End Sub

    Private Sub cmdGuardarEditar_Click(sender As Object, e As EventArgs) Handles cmdGuardarEditar.Click
        Try
            ' Mapeamos los datos de la interfaz al objeto
            _servicio.nombre = txtnombreCurso.Text.ToUpper()
            _servicio.montoInscripcion = CDec(txtCostoInscripcion.Text)
            _servicio.montoMensual = CDec(txtCuotaMensual.Text)
            _servicio.montoExamen = CDec(txtCostoExamen.Text)

            ' Actualizamos en la Base de Datos
            If serv_servicios.Actualizar(_servicio) Then
                MsgBox("Servicio actualizado correctamente.", MsgBoxStyle.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As InvalidCastException
            MsgBox("Por favor, ingrese valores numéricos válidos en los montos.", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("Error al guardar: " & ex.Message)
        End Try
    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class