Public Class selclie
    Public Shared busqueda As String
    Public Shared fila As String
    Public Shared llama As String

    Private Sub selclie_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub SELPAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPersonal()
    End Sub
    Public Sub CargarPersonal()
        Dim separador() As String = {"-", " "}
        Dim buscStr = busqueda.Split(separador, StringSplitOptions.None)
        Dim i As Integer
        Dim busqtxt As String
        For i = 0 To buscStr.Length - 1
            If i = 0 Then
                busqtxt &= " nomapell_razon like '%" & buscStr(i) & "%'"
            Else
                busqtxt &= " and nomapell_razon like '%" & buscStr(i) & "%'"
            End If

        Next
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select idclientes as Cuenta, nomapell_razon as Cliente, dir_domicilio as Domicilio from fact_clientes where " & busqtxt, conexionPrinc)
            Dim tablaPers As New DataTable

            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            consulta.Fill(tablaPers)
            dtpersonal.DataSource = tablaPers
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpersonal_DoubleClick(sender As Object, e As EventArgs) Handles dtpersonal.DoubleClick
        Try
            Select Case llama
                Case "nuevaventa"
                    With CType(frmprincipal.ActiveMdiChild, nuevaventa)
                        .txtctaclie.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                        .cargarCliente()
                        .cmbcondvta.Focus()
                        Me.Close()
                    End With
                    Me.Close()
                
                Case "ctacte"
                    With CType(frmprincipal.ActiveMdiChild, CONTABLE)
                        .txtcuentabus.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                        .cargarCuentaClie(dtpersonal.CurrentRow.Cells.Item(0).Value)
                        .dtcuentaclie.Focus()
                        Me.Close()
                    End With
                    Me.Close()
                Case "ingresoequipo"
                    With CType(frmprincipal.ActiveMdiChild, ingresoequipo)
                        .txtctaclie.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                        .cargarCliente()
                        '.cmbcondvta.Focus()
                        Me.Close()
                    End With
                Case "movimientodecaja"
                    With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                        .txtctaclie.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                        .cargarCliente()
                        '.cmbrecibeusuario.Focus()

                    End With
                    Me.Close()
                Case "ptovta"
                    With CType(frmprincipal.ActiveMdiChild, puntoventa)
                        .Idcliente = dtpersonal.CurrentRow.Cells.Item(0).Value
                        .txtcliecta.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                        .cargarCliente()
                        '.cmbrecibeusuario.Focus()
                        .txtcodPLU.Focus()
                    End With
                    Me.Close()
                Case "prestamosform"
                    With CType(frmprincipal.ActiveMdiChild, PrestamosForm)
                        .Idcliente = dtpersonal.CurrentRow.Cells.Item(0).Value
                        .txtclientecuenta.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                        .txtclientenombre.Text = dtpersonal.CurrentRow.Cells.Item(1).Value
                    End With
                    Me.Close()
            End Select
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub dtpersonal_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpersonal.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case llama
                    Case "nuevaventa"
                        With CType(frmprincipal.ActiveMdiChild, nuevaventa)
                            .txtctaclie.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                            .cargarCliente()
                            .cmbcondvta.Focus()
                            Me.Close()
                        End With

                    Case "nuevopedido"
                        With CType(frmprincipal.ActiveMdiChild, nuevopedido)
                            .txtctaclie.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                            .cargarCliente()
                            .cmbcondvta.Focus()
                            Me.Close()
                        End With

                    Case "ctacte"
                        With CType(frmprincipal.ActiveMdiChild, CONTABLE)
                            .txtcuentabus.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                            .cargarCuentaClie(dtpersonal.CurrentRow.Cells.Item(0).Value)
                            .dtcuentaclie.Focus()
                            Me.Close()
                        End With

                    Case "ingresoequipo"
                        With CType(frmprincipal.ActiveMdiChild, ingresoequipo)
                            .txtctaclie.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                            .cargarCliente()
                            .cmbrecibeusuario.Focus()
                            Me.Close()
                        End With

                    Case "movimientodecaja"
                        With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                            .txtctaclie.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                            .cargarCliente()
                            '.cmbrecibeusuario.Focus()
                            Me.Close()
                        End With
                    Case "ptovta"
                        With CType(frmprincipal.ActiveMdiChild, puntoventa)
                            .Idcliente = dtpersonal.CurrentRow.Cells.Item(0).Value
                            .txtcliecta.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                            .cargarCliente()
                            '.cmbrecibeusuario.Focus()
                            .txtcodPLU.Focus()
                        End With
                        Me.Close()
                    Case "prestamosform"
                        With CType(frmprincipal.ActiveMdiChild, PrestamosForm)
                            .idCliente = dtpersonal.CurrentRow.Cells.Item(0).Value
                            .txtclientecuenta.Text = dtpersonal.CurrentRow.Cells.Item(0).Value
                            .txtclientenombre.Text = dtpersonal.CurrentRow.Cells.Item(1).Value
                            .txtmonto.Focus()
                        End With
                        Me.Close()

                End Select

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpersonal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtpersonal.CellContentClick

    End Sub

    Private Sub dtpersonal_KeyUp(sender As Object, e As KeyEventArgs) Handles dtpersonal.KeyUp

    End Sub
End Class