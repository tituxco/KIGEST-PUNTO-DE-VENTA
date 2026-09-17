
Public Class frmInicializar2
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cargo los datos guardados del conexion
        ' txtServidor.Text = My.Settings.servidor
        'txtPuerto.Text = My.Settings.puerto
        'txtBaseDatos.Text = My.Settings.bd
        'txtUsuario.Text = My.Settings.usuario
        txtuser.Text = My.Settings.authuser
        lblEstado.TextAlign = ContentAlignment.MiddleCenter
        Me.AcceptButton = cmdAceptar
        'If My.Settings.usuario <> "" Then
        'chkGuardarDatos.Checked = True
        'txtContraseña.Focus()
        'Else
        'chkGuardarDatos.Checked = False
        'End If
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim usuarioInput As String = txtuser.Text.Trim()
        Dim claveInput As String = txtContraseña.Text.Trim()

        If String.IsNullOrEmpty(claveInput) OrElse String.IsNullOrEmpty(usuarioInput) Then
            lblEstado.Text = "Debe ingresar usuario y clave de acceso"
            Return
        End If

        pbprogresocons.Visible = True
        lblEstado.Text = "Autenticando usuario..."
        Application.DoEvents() ' Permite que la interfaz se refresque visualmente

        Try
            ' 1. Autenticar en AuthServ usando nuestra nueva clase (MD5 / SHA1)
            If GestorConexiones.AutenticarYObtenerConfig(usuarioInput, claveInput) Then

                lblEstado.Text = "Conectando al servidor de trabajo..."
                Application.DoEvents()

                ' 2. Conectar a la base de datos principal usando las credenciales obtenidas
                If GestorConexiones.ConectarBaseTrabajo(DatosAcceso.CLOUDserv, DatosAcceso.puerto, DatosAcceso.usuario, DatosAcceso.pass, DatosAcceso.bd) Then

                    ' 3. Guardar en Settings locales
                    My.Settings.servidor = DatosAcceso.CLOUDserv
                    My.Settings.puerto = DatosAcceso.puerto
                    My.Settings.bd = DatosAcceso.bd
                    My.Settings.usuario = DatosAcceso.usuario
                    My.Settings.pass = DatosAcceso.pass
                    My.Settings.authpass = claveInput
                    My.Settings.authuser = usuarioInput
                    My.Settings.priv = DatosAcceso.Moduloacc
                    My.Settings.idint = DatosAcceso.UsuarioINT
                    My.Settings.Save()

                    ' 4. Comprobaciones de integridad de tablas (tus funciones ya existentes)
                    lblEstado.Text = "Verificando estructura de base de datos..."

                    If ValidadorBaseDatos.ComprobarBasePrincipal() AndAlso ValidadorBaseDatos.ComprobarTablas Then

                        ' Mensajes de Clouding (Deuda o Avisos)
                        If DatosAcceso.debe = 1 Then
                            MsgBox("ATENCION: SU CUENTA DE CLOUDING REGISTRA DEUDA" & vbNewLine &
                                   "POR FAVOR REGULARICE SU SITUACION, COMUNIQUESE AL tel- 3482-621473" & vbNewLine &
                                   DatosAcceso.mensaje, MsgBoxStyle.Exclamation)
                        ElseIf DatosAcceso.debe = 2 Then
                            MsgBox("ATENCION MENSAJE DEL ADMINISTRADOR:" & vbNewLine &
                                   DatosAcceso.mensaje & vbNewLine &
                                   "POR CUALQUIER DUDA, COMUNIQUESE AL tel- 3482-621473 O AL MAIL: INFO@KIBIT.COM.AR", MsgBoxStyle.Information)
                        End If

                        ' ÉXITO: Entramos al sistema
                        frmprincipal.Show()
                        Me.Close()
                    Else
                        lblEstado.Text = "Error en la estructura de tablas o BD."
                    End If
                Else
                    lblEstado.Text = "No se pudo acceder a los datos de la empresa."
                End If
            Else
                lblEstado.Text = "Acceso denegado."
            End If

        Catch ex As Exception
            MsgBox("Se produjo un error inesperado: " & ex.Message, MsgBoxStyle.Critical)
            lblEstado.Text = "Error al iniciar."
        Finally
            pbprogresocons.Visible = False
        End Try
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        grserver.Visible = False
        grusuario.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        grserver.Visible = True
        grusuario.Visible = False
    End Sub

    Private Sub frmInicializar2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim keyCTRL As Boolean
        Dim keyALT As Boolean
        Dim keyF As Boolean
        Dim pass As String
        Try



            'If e.Control And e.Alt And e.KeyCode = Keys.N Then
            '    pass = InputBox("Ingrese Contraseña", "Contraseña admin")
            '    If pass <> "Narinas1830" Then
            '        Exit Sub
            '    End If

            '    frmInicializar.Visible = True
            '    Me.Visible = False
            '    Show(frmInicializar)
            '    Me.Close()
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://kicloud.com.ar/kigest_fact_update2/")
    End Sub
End Class