Public Class agregarUsuarioCloud
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Try
            If ComprobarUsuarioAuth(txtCloudUsuario.Text, txtCloudContraseña.Text) = True Then
                MsgBox("ya existe un usuario con los mismos datos, por favor revise")
                Exit Sub
            End If

            Dim sqlQuery As String = "insert into AuthServ.CliAuth (cliente,sistema,usuario,pass,servidor,autorizado,bd,puerto,clave,codus,idINt,servidor_resp) values
            (?nomApell,?empresa,?hostUsuario,?hostPass,?host,'1',?bd,?hostPuerto,?cloudClave,?cloudUsuario,'1',?resp)"
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?nomApell", txtCloudNomApell.Text)
                .AddWithValue("?empresa", txtCloudEmpresa.Text)
                .AddWithValue("?hostUsuario", txtCloudHostUsuario.Text)
                .AddWithValue("?hostPass", txtCloudHostContraseña.Text)
                .AddWithValue("?host", txtCloudHost.Text)
                .AddWithValue("?bd", txtCloudBD.Text)
                .AddWithValue("?hostPuerto", txtCloudHostPuerto.Text)
                .AddWithValue("?cloudClave", txtCloudContraseña.Text)
                .AddWithValue("?cloudUsuario", txtCloudUsuario.Text)
                .AddWithValue("?resp", txtCloudHost.Text)
            End With

            comandoadd.ExecuteNonQuery()
            MsgBox("El usuario a sido agregado correctamente")
            With CType(frmprincipal.ActiveMdiChild, frmServiciosCloud)
                .CargaServiciosCloud()
            End With
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        Me.Close()
    End Sub
End Class