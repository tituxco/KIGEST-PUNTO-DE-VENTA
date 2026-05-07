Imports SIGT__KIGEST.datosEstructura

Public Class frmInfoAlumno
    ' Propiedad privada para mantener la referencia del alumno que estamos editando
    Private _alumno As serv_personas
    Public clienteSeleccionado As fact_clientes


    ' Constructor que recibe el objeto serv_personas
    Public Sub New(alumnoALeer As serv_personas)
        InitializeComponent()
        Me._alumno = alumnoALeer
        clienteSeleccionado = fact_clientes.BuscarPorID(_alumno.idCliente)
    End Sub
    Private Sub frmInfoAlumno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Rellenamos los campos con los datos del objeto recibido
        txtApellidoNombre.Text = _alumno.nombre_apellido
        txtDniAlumno.Text = _alumno.dni
        txtCelular.Text = _alumno.celular
        txtDireccion.Text = _alumno.direccion
        cargarDatosCliente()

    End Sub
    Public Sub cargarDatosCliente()
        ' Llenamos datos de facturación usando el ID que ya tiene el alumno
        txtclientecuenta.Text = clienteSeleccionado.idCliente
        txtclientenombre.Text = clienteSeleccionado.nomapellRazon
    End Sub
    Private Sub cmdGuardarEditar_Click(sender As Object, e As EventArgs) Handles cmdGuardarEditar.Click
        Try
            ' 1. Actualizamos el objeto con los nuevos datos de los campos
            _alumno.nombre_apellido = txtApellidoNombre.Text
            _alumno.dni = txtDniAlumno.Text
            _alumno.celular = txtCelular.Text
            _alumno.direccion = txtDireccion.Text
            _alumno.idCliente = txtclientecuenta.Text

            ' 2. Llamamos al método de actualizar en la base de datos           
            If serv_personas.Actualizar(_alumno) Then
                MsgBox("Datos actualizados correctamente", MsgBoxStyle.Information)
                Me.DialogResult = DialogResult.OK ' Cerramos con éxito
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("Error al guardar: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdclientebuscar_Click(sender As Object, e As EventArgs) Handles cmdclientebuscar.Click
        selclie.llama = "infoAlumno" '"nuevoServicio" ' ' o 
        selclie.busqueda = txtclientenombre.Text ' Opcional: pasar el texto actual

        ' Creamos la instancia
        Using buscador As New selclie
            ' Al pasar "Me", buscador queda por encima de este diálogo
            If buscador.ShowDialog(Me) = DialogResult.OK Then
                ' Si seleccionó algo y cerró con OK
                If buscador.clienteSeleccionado IsNot Nothing Then
                    clienteSeleccionado = buscador.clienteSeleccionado

                    'Me.txtclientecuenta.Text = buscador.clienteSeleccionado.idCliente
                    'Me.txtclientenombre.Text = buscador.clienteSeleccionado.nomapellRazon
                    ' Si es el form de InfoAlumno, actualizamos el objeto interno
                    _alumno.idCliente = buscador.clienteSeleccionado.idCliente
                    cargarDatosCliente()
                End If
            End If
        End Using
    End Sub
End Class