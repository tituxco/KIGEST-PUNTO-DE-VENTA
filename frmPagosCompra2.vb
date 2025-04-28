Public Class frmPagosCompra2
    Private Sub frmPagosCompra2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Reconectar()
            'Dim lector As System.Data.IDataReader
            'Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            'sql.Connection = conexionPrinc
            'sql.CommandText = "select confnume from fact_conffiscal where donfdesc=" & TipoFac & " and ptovta= " & PtoVta
            'sql.CommandType = CommandType.Text
            'lector = sql.ExecuteReader
            'lector.Read()

            'NumRecibo = CompletarCeros(FormatNumber(lector("confnume").ToString) + 1, 1)
            'Me.Text = "Recibo: " & CompletarCeros(Val(PtoVta), 2) & "-" & NumRecibo
            'Reconectar()
            Dim tablatajetasNombre As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_tarjetasNombres", conexionPrinc)
            Dim readTarjetasNombre As New DataSet
            tablatajetasNombre.Fill(readTarjetasNombre)

            txtTarjetaNombre.DataSource = readTarjetasNombre.Tables(0)
            txtTarjetaNombre.DisplayMember = readTarjetasNombre.Tables(0).Columns("nombre").Caption.ToString.ToUpper
            txtTarjetaNombre.ValueMember = readTarjetasNombre.Tables(0).Columns("id").Caption.ToString
            'cmbTarjetasMarcas.SelectedIndex = -1

            'panelformaspago.Visible = False
            'panelefectivo.Visible = False
            'panelTarjetas.Visible = True
        Catch ex As Exception

        End Try
    End Sub
End Class