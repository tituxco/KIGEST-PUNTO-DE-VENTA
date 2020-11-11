Public Class selequi
    Public Shared cliente As String
    Public Shared busqueda As String
    Public Shared llama As String
    Private Sub selequi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarEquipos()
    End Sub

    Private Sub cargarEquipos()
        Dim busqtxt As String
        
        Try
            If cliente = "0" Then
                busqtxt = " ecli.propietario>0 "
            Else
                busqtxt = " ecli.propietario=" & cliente
            End If

            If busqueda = "0" Then
                busqtxt = busqtxt & " and ecli.id>0 "
            Else
                busqtxt = busqtxt & " and ecli.id=" & Val(busqueda)
            End If

            Reconectar()
            'MsgBox(busqtxt)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select ecli.id as CODIGO, " _
            & " concat(et.nombre,'/',ma.nombre,'/',mo.nombre) as MODELO,ecli.serie as SERIE, ecli.propietario as CLIENTE" _
            & " from tecni_equipos_clientes as ecli, tecni_equipos_tipo as et, fact_marcas as ma, fact_modelos as mo,tecni_equipos as eq " _
            & " where eq.tipo_equ=et.id and eq.marca=ma.id and eq.modelo=mo.id and ecli.modelo=eq.id and " & busqtxt, conexionPrinc)
            Dim tablapequi As New DataTable
            consulta.Fill(tablapequi)
            dtequipos.DataSource = tablapequi

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtequipos_DoubleClick(sender As Object, e As EventArgs) Handles dtequipos.DoubleClick
        Select Case llama
            Case "ingresoequipo"
                With CType(frmprincipal.ActiveMdiChild, ingresoequipo)
                    .txtcodint.Text = dtequipos.CurrentRow.Cells.Item(0).Value
                    If cliente = 0 Then
                        '.txtctaclie.Text = dtequipos.CurrentRow.Cells.Item(3).Value
                        '.cargarCliente()
                    End If
                    .CargarInfoEquipo(1)
                    .cmbrecibeusuario.Focus()
                    Me.Close()
                End With
                Me.Close()
        End Select
    End Sub

    Private Sub dtequipos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtequipos.KeyDown

    End Sub

    Private Sub dtequipos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtequipos.CellContentClick

    End Sub

    Private Sub dtequipos_KeyUp(sender As Object, e As KeyEventArgs) Handles dtequipos.KeyUp
        If e.KeyCode = Keys.Enter Then
            Select Case llama
                Case "ingresoequipo"
                    'MsgBox("   ")
                    With CType(frmprincipal.ActiveMdiChild, ingresoequipo)
                        .txtcodint.Text = dtequipos.CurrentRow.Cells.Item(0).Value
                        If cliente = 0 Then
                            '.txtctaclie.Text = dtequipos.CurrentRow.Cells.Item(3).Value
                            '.cargarCliente()
                        End If
                        .CargarInfoEquipo(1)
                        .cmbrecibeusuario.Focus()
                        Me.Close()
                    End With
                    Me.Close()
            End Select
        End If
    End Sub
End Class