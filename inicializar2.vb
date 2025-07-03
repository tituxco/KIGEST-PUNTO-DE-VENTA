
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

        ' MsgBox(GetMd5Hash(txtContraseña.Text))

        'guardo los datos de conexion en el caso de que hayan tildado la opcion
        pbprogresocons.Visible = True
        Try
            clav = txtContraseña.Text
            user = txtuser.Text
            If clav = "" Then
                lblEstado.Text = "Debe ingresar clave de acceso"
                Exit Sub
            End If
            'compruebo que este autorizado
            If ConectarAuth() = True Then
                lblEstado.Text = "Conectando"
                If ComprobarAuth() = True Then
                    lblEstado.Text = "Comprobando credenciales"
                    If conectar(serv, port, user, pass, database) = True Then
                        My.Settings.servidor = serv
                        My.Settings.puerto = port
                        My.Settings.bd = database
                        My.Settings.usuario = user
                        My.Settings.pass = pass
                        My.Settings.authpass = txtContraseña.Text
                        My.Settings.authuser = txtuser.Text
                        My.Settings.priv = DatosAcceso.Moduloacc
                        My.Settings.idint = DatosAcceso.UsuarioINT
                        'My.Settings.idAlmacen = DatosAcceso.IdAlmacen
                        My.Settings.Save()



                        If comprobar_base_de_datos_principal() = True Then
                            'compruebo que las tablas de la base de datos principal esten correctas
                            If comprobar_tablas_princ() = True Then
                                If DatosAcceso.debe = 1 Then 'MENSAJE DE DEUDA
                                    MsgBox("ATENCION: SU CUENTA DE CLOUDING REGISTRA DEUDA" & vbNewLine &
                                           "POR FAVOR REGULARICE SU SITUACION, COMUNIQUESE AL TEL: 3482-621473" & vbNewLine & DatosAcceso.mensaje)
                                ElseIf DatosAcceso.debe = 2 Then 'solo un mensaje
                                    MsgBox("ATENCION MENSAJE DEL ADMINISTRADOR;" & vbNewLine & DatosAcceso.mensaje & vbNewLine &
                                           "POR CUALQUIER DUDA, COMUNIQUESE AL TEL: 3482-621473 O AL MAIL: INFO@KIBIT.COM.AR" & vbNewLine)
                                End If
                                frmprincipal.Show()
                                Me.Close()
                            Else
                                lblEstado.Text = "Error en la estructura de las tablas"
                            End If
                        Else
                            lblEstado.Text = "Error en la estructura de la base de datos"
                        End If
                    Else
                        MsgBox("Se conecto correctamente al servidor de autorizacion, pero no se puede conectar a su servidor de trabajo")
                    End If
                Else
                    MsgBox("El servidor de autorizacion no permite acceso al sistema")
                End If
            Else
                MsgBox("no se pudo conectar al servidor de autorizacion, de todos modos se intentara conectar al ultimo servidor utilizado", vbInformation)
                If My.Settings.authpass = txtContraseña.Text And My.Settings.authuser = txtuser.Text Then
                    serv = My.Settings.servidor
                    port = My.Settings.puerto
                    database = My.Settings.servidor
                    user = My.Settings.usuario
                    pass = My.Settings.pass
                    DatosAcceso.Moduloacc = Val(My.Settings.priv.ToString)
                    If conectar(serv, port, user, pass, database) = True Then
                        My.Settings.Save()
                        'en el caso de que no pueda conectar muestro una advertencia
                        lblEstado.Text = "No se pudo conectar al servidor"
                        If comprobar_base_de_datos_principal() = True Then
                            'compruebo que las tablas de la base de datos principal esten correctas
                            If comprobar_tablas_princ() = True Then


                                frmprincipal.Show()
                                Me.Close()
                            Else
                                lblEstado.Text = "Error en la estructura de las tablas"
                            End If
                        Else
                            lblEstado.Text = "Error en la estructura de la base de datos"
                        End If
                    End If
                Else
                    MsgBox("Usuario o contraseña incorrectos")
                    Exit Sub
                End If
                pbprogresocons.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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



            If e.Control And e.Alt And e.KeyCode = Keys.N Then
                pass = InputBox("Ingrese Contraseña", "Contraseña admin")
                If pass <> "Narinas1830" Then
                    Exit Sub
                End If

                frmInicializar.Visible = True
                Me.Visible = False
                Show(frmInicializar)
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://66.97.35.86/kigest_fact_update2/")
    End Sub
End Class