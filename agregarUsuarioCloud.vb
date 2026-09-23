Public Class agregarUsuarioCloud
    Public idDuplicado As Integer
    Public duplicar As Boolean
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        If String.IsNullOrWhiteSpace(txtCloudBD.Text) OrElse String.IsNullOrWhiteSpace(txtCloudHostUsuario.Text) Then
            MsgBox("El nombre de la base de datos y el usuario host son obligatorios.", CType(MsgBoxStyle.Exclamation, MsgBoxStyle), "Atención")
            Exit Sub
        End If

        Dim conexionLocal As MySql.Data.MySqlClient.MySqlConnection = Nothing
        Dim frmCarga As Form = Nothing

        Try
            If GestorConexiones.AutenticarYObtenerConfig(txtCloudUsuario.Text, txtCloudContraseña.Text) = True Then
                MsgBox("Ya existe un usuario con los mismos datos, por favor revise.", CType(MsgBoxStyle.Exclamation, MsgBoxStyle), "Usuario Duplicado")
                Exit Sub
            End If

            ' 1. Iniciamos tu formulario dinámico de progreso
            frmCarga = GestorUtilidades.MostrarProgreso("Iniciando proceso de configuración...")

            Dim bdNueva As String = txtCloudBD.Text.Trim()
            Dim usuarioDB As String = txtCloudHostUsuario.Text.Trim()
            Dim passDB As String = txtCloudHostContraseña.Text.Trim()
            Dim claveMD5 As String = GetMd5Hash(txtCloudContraseña.Text.Trim())

            Dim cadenaConexion As String = GestorConexiones.conexionPrinc.ConnectionString
            conexionLocal = New MySql.Data.MySqlClient.MySqlConnection(cadenaConexion)
            conexionLocal.Open()

            Using cmd As New MySql.Data.MySqlClient.MySqlCommand()
                cmd.Connection = conexionLocal

                ' =====================================================================
                ' PASO 1
                ' =====================================================================
                frmCarga.Controls("lblMensaje").Text = "Paso 1/4: Creando base de datos..."
                Application.DoEvents() ' Fuerza el refresco visual de la barra y el texto

                cmd.CommandText = $"CREATE DATABASE IF NOT EXISTS `{bdNueva}`;"
                cmd.ExecuteNonQuery()

                ' =====================================================================
                ' PASO 2
                ' =====================================================================
                frmCarga.Controls("lblMensaje").Text = "Paso 2/4: Configurando permisos del usuario..."
                Application.DoEvents()

                cmd.CommandText = $"CREATE USER IF NOT EXISTS '{usuarioDB}'@'%' IDENTIFIED BY '{passDB}';"
                cmd.ExecuteNonQuery()

                cmd.CommandText = $"GRANT ALL PRIVILEGES ON `{bdNueva}`.* TO '{usuarioDB}'@'%';"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "FLUSH PRIVILEGES;"
                cmd.ExecuteNonQuery()

                ' =====================================================================
                ' PASO 3
                ' =====================================================================
                frmCarga.Controls("lblMensaje").Text = "Paso 3/4: Analizando estructura maestra..."
                Application.DoEvents()

                cmd.CommandText = "SHOW FULL TABLES FROM `_auditoria_maestra`;"
                Dim tablasMaestras As New List(Of String)()
                Dim vistasMaestras As New List(Of String)()

                Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        If reader.GetString(1) = "VIEW" Then
                            vistasMaestras.Add(reader.GetString(0))
                        Else
                            tablasMaestras.Add(reader.GetString(0))
                        End If
                    End While
                End Using

                ' 3.A: Clonar TABLAS
                frmCarga.Controls("lblMensaje").Text = "Paso 3/4: Clonando tablas y registros iniciales..."
                Application.DoEvents()

                cmd.CommandText = "SET FOREIGN_KEY_CHECKS=0;"
                cmd.ExecuteNonQuery()

                For Each tabla As String In tablasMaestras
                    cmd.CommandText = $"CREATE TABLE `{bdNueva}`.`{tabla}` LIKE `_auditoria_maestra`.`{tabla}`;"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = $"INSERT INTO `{bdNueva}`.`{tabla}` SELECT * FROM `_auditoria_maestra`.`{tabla}`;"
                    cmd.ExecuteNonQuery()
                Next

                cmd.CommandText = "SET FOREIGN_KEY_CHECKS=1;"
                cmd.ExecuteNonQuery()

                ' 3.B: Clonar VISTAS (Con reintentos inteligentes)
                frmCarga.Controls("lblMensaje").Text = "Paso 3/4: Generando vistas dinámicas..."
                Application.DoEvents()

                Dim scriptsVistas As New List(Of String)()
                For Each vista As String In vistasMaestras
                    cmd.CommandText = $"SHOW CREATE VIEW `_auditoria_maestra`.`{vista}`;"
                    Using readerVista As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        If readerVista.Read() Then
                            scriptsVistas.Add(readerVista.GetString(1).Replace("`_auditoria_maestra`", $"`{bdNueva}`"))
                        End If
                    End Using
                Next

                cmd.CommandText = $"USE `{bdNueva}`;"
                cmd.ExecuteNonQuery()

                Dim intentos As Integer = 0
                Dim maxIntentos As Integer = scriptsVistas.Count * 2

                While scriptsVistas.Count > 0 AndAlso intentos < maxIntentos
                    Dim vistasPendientes As New List(Of String)()
                    Dim vistasCreadasEnEstaPasada As Integer = 0

                    For Each script As String In scriptsVistas
                        Try
                            cmd.CommandText = script
                            cmd.ExecuteNonQuery()
                            vistasCreadasEnEstaPasada += 1
                        Catch ex As MySql.Data.MySqlClient.MySqlException
                            vistasPendientes.Add(script)
                        End Try
                    Next

                    If vistasCreadasEnEstaPasada = 0 Then Throw New Exception("Faltan dependencias para crear las vistas.")
                    scriptsVistas = vistasPendientes
                    intentos += 1
                End While

                ' =====================================================================
                ' PASO 4
                ' =====================================================================
                frmCarga.Controls("lblMensaje").Text = "Paso 4/4: Registrando accesos en la nube..."
                Application.DoEvents()

                Dim sqlQuery As String = "INSERT INTO AuthServ.CliAuth (cliente, sistema, usuario, pass, servidor, autorizado, bd, puerto, clave, codus, idInt, servidor_resp, modulo) VALUES " &
                                         "(?nomApell, ?empresa, ?hostUsuario, ?hostPass, ?host, '1', ?bd, ?hostPuerto, ?cloudClave, ?cloudUsuario, '1', ?resp,?modulo)"

                cmd.CommandText = sqlQuery
                cmd.Parameters.Clear()
                With cmd.Parameters
                    .AddWithValue("?nomApell", txtCloudNomApell.Text)
                    .AddWithValue("?empresa", txtCloudEmpresa.Text)
                    .AddWithValue("?hostUsuario", usuarioDB)
                    .AddWithValue("?hostPass", passDB)
                    .AddWithValue("?host", txtCloudHost.Text)
                    .AddWithValue("?bd", bdNueva)
                    .AddWithValue("?hostPuerto", txtCloudHostPuerto.Text)
                    .AddWithValue("?cloudClave", claveMD5)
                    .AddWithValue("?cloudUsuario", txtCloudUsuario.Text)
                    .AddWithValue("?resp", txtCloudHost.Text)
                    .AddWithValue("?modulo", "1-2-2a-2b-2c-2d-3-3a-3b-3c-3d-3e-3f--3z-4a-4aa-4ab-4aj-4ac-4ad-" _
                        & "4ae-4af-4ag-4ah-4ai--4ba-4bb-4bba-4c-4d--4ea-SUPERADMIN-4f--4h-AR01-5PUBLICIDAD-CONF-CONFTERM-CONFVAR-CONFUSER") 'modulos habilitados por defecto
                End With

                cmd.ExecuteNonQuery()
            End Using

            ' Cerramos la ventana de carga al finalizar correctamente
            If frmCarga IsNot Nothing Then frmCarga.Close()

            MsgBox("La base de datos se ha creado, estructurado y el usuario fue agregado correctamente.", CType(MsgBoxStyle.Information, MsgBoxStyle), "Proceso Exitoso")

            With CType(frmprincipal.ActiveMdiChild, frmServiciosCloud)
                .CargaServiciosCloud()
            End With
            Me.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            If frmCarga IsNot Nothing AndAlso Not frmCarga.IsDisposed Then frmCarga.Close()
            MsgBox("Error de base de datos: " & ex.Message, CType(MsgBoxStyle.Critical, MsgBoxStyle), "Error DDL/SQL")
        Catch ex As Exception
            If frmCarga IsNot Nothing AndAlso Not frmCarga.IsDisposed Then frmCarga.Close()
            MsgBox("Ocurrió un error general: " & ex.Message, CType(MsgBoxStyle.Critical, MsgBoxStyle), "Error")
        Finally
            ' Failsafe para la ventana de carga
            If frmCarga IsNot Nothing AndAlso Not frmCarga.IsDisposed Then
                frmCarga.Close()
            End If

            If conexionLocal IsNot Nothing Then
                If conexionLocal.State = ConnectionState.Open Then conexionLocal.Close()
                conexionLocal.Dispose()
            End If
        End Try
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        Me.Close()
    End Sub

    Private Sub agregarUsuarioCloud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If duplicar = True Then
            Reconectar()
            Dim consultacloud As New MySql.Data.MySqlClient.MySqlDataAdapter("select *
            from AuthServ.CliAuth where id =" & idDuplicado, GestorConexiones.conexionPrinc)
            Dim tablacloud As New DataTable
            consultacloud.Fill(tablacloud)
            Dim cliente As String = tablacloud.Rows(0).Item("cliente")
            Dim permisos As String = tablacloud.Rows(0).Item("modulo")
            Dim sistema As String = tablacloud.Rows(0).Item("sistema")
            Dim usuario As String = tablacloud.Rows(0).Item("usuario")
            Dim pass As String = tablacloud.Rows(0).Item("pass")
            Dim servidor As String = tablacloud.Rows(0).Item("servidor")
            Dim autorizado As Integer = 1
            Dim bd As String = tablacloud.Rows(0).Item("bd")
            Dim puerto As String = tablacloud.Rows(0).Item("puerto")
            Dim clave As String = tablacloud.Rows(0).Item("clave")
            Dim codus As String = tablacloud.Rows(0).Item("codus")
            Dim empresa As String = tablacloud.Rows(0).Item("sistema")
            txtCloudBD.Text = bd
            'qtxtCloudContraseña.Text = clave
            txtCloudEmpresa.Text = empresa
            txtCloudHost.Text = servidor
            txtCloudHostContraseña.Text = pass
            txtCloudHostPuerto.Text = puerto
            txtCloudHostUsuario.Text = usuario
            txtCloudNomApell.Text = cliente
            txtCloudUsuario.Text = codus


        End If
    End Sub
End Class