Public Class DGVPaginado
    Private todos_los_datos = New DataTable
    Private total As Integer = 0
    Private pagina As Integer = 0
    Private maximo_paginas As Integer = 0
    Private items_por_pagina As Integer = My.Settings.paginacion
    Public ItemSeleccionado As Integer = 0

    Public Sub Cargar_Datos(dt As DataTable)
        todos_los_datos = dt
        total = dt.Rows.Count
        maximo_paginas = Math.Ceiling(total / items_por_pagina)
        lblPaginasTotales.Text = maximo_paginas
        dgvVista.DataSource = Split(todos_los_datos)
        dgvVista.Columns(0).Visible = False
        HabilitarBotones()
    End Sub

    Private Function Split(dt As DataTable) As DataTable
        lblPagina.Text = pagina + 1
        HabilitarBotones()
        Return dt.Select.Skip(items_por_pagina * pagina).Take(items_por_pagina).CopyToDataTable()
    End Function

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        pagina += 1
        dgvVista.DataSource = Split(todos_los_datos)
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        pagina -= 1
        dgvVista.DataSource = Split(todos_los_datos)
    End Sub

    Private Sub HabilitarBotones()
        If pagina = 0 Then
            btnAnterior.Enabled = False
        Else
            btnAnterior.Enabled = True
        End If

        If pagina = maximo_paginas - 1 Then
            btnSiguiente.Enabled = False
        Else
            btnSiguiente.Enabled = True
        End If
    End Sub

    Public Sub dgvVista_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVista.CellEnter
        RaiseEvent SeleccionarItem(dgvVista.CurrentRow.Cells(0).Value)
        ItemSeleccionado = dgvVista.CurrentRow.Cells(0).Value
    End Sub
    Public Event SeleccionarItem(IdItem As Integer)

    Private Sub dgvVista_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVista.CellContentClick

    End Sub
End Class
