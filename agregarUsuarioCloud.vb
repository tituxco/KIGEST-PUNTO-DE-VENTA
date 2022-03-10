Public Class agregarUsuarioCloud
    Public idDuplicado As Integer
    Public duplicar As Boolean
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Try
            If ComprobarUsuarioAuth(txtCloudUsuario.Text, txtCloudContraseña.Text) = True Then
                MsgBox("ya existe un usuario con los mismos datos, por favor revise")
                Exit Sub
            End If

            Dim sqlQuery As String = "insert into AuthServ.CliAuth (cliente,sistema,usuario,pass,servidor,autorizado,bd,puerto,clave,codus,idINt,servidor_resp) values
            (?nomApell,?empresa,?hostUsuario,?hostPass,?host,'1',?bd,?hostPuerto,sha(?cloudClave),?cloudUsuario,'1',?resp)"
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
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

    Private Sub agregarUsuarioCloud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If duplicar = True Then
            Reconectar()
            Dim consultacloud As New MySql.Data.MySqlClient.MySqlDataAdapter("select *
            from AuthServ.CliAuth where id =" & idDuplicado, conexionPrinc)
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