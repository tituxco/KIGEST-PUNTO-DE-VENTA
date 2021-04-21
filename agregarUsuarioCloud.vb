Public Class agregarUsuarioCloud
    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Try
            If ComprobarUsuarioAuth(txtCloudUsuario.Text, txtCloudContraseña.Text) = True Then
                MsgBox("ya existe un usuario con los mismos datos, por favor revise")
                Exit Sub
            End If


        Catch ex As Exception

        End Try
    End Sub
End Class