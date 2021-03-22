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
        lblregistros.Text = total
        maximo_paginas = Math.Ceiling(total / items_por_pagina)
        lblPaginasTotales.Text = maximo_paginas
        dgvVista.DataSource = Split(todos_los_datos)
        dgvVista.Columns(0).Visible = False
        HabilitarBotones()

    End Sub
    'Private Sub cargarOrden(dt As DataTable)
    '    For Each columna As DataColumn In dt.Columns
    '        cmborden.Items.Add(columna.ColumnName)
    '    Next
    'End Sub
    Private Function Split(dt As DataTable) As DataTable
        Try
            lblPagina.Text = pagina + 1
            HabilitarBotones()
            Return dt.Select.Skip(items_por_pagina * pagina).Take(items_por_pagina).CopyToDataTable()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

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

    Private Sub dgvVista_SelectionChanged(sender As Object, e As EventArgs) Handles dgvVista.SelectionChanged
        Dim i As Integer = 0
        For Each fila As DataGridViewRow In dgvVista.Rows
            If fila.Selected = True Then
                i += 1
            End If
        Next
        If i > 1 Then
            RaiseEvent Multiseleccion(True)
        Else
            RaiseEvent Multiseleccion(False)
        End If
    End Sub

    Public Event SeleccionarItem(IdItem As Integer)
    Public Event Multiseleccion(multiple As Boolean)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTodo.Click
        items_por_pagina = total
        maximo_paginas = Math.Ceiling(total / items_por_pagina)
        lblPaginasTotales.Text = maximo_paginas
        Dim EnProgreso As New Form
        EnProgreso.ControlBox = False
        EnProgreso.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        EnProgreso.Size = New Point(430, 30)
        EnProgreso.StartPosition = FormStartPosition.CenterScreen
        EnProgreso.TopMost = True
        Dim Etiqueta As New Label
        Etiqueta.AutoSize = True
        Etiqueta.Text = "La consulta esta en progreso, esto puede tardar unos momentos, por favor espere ..."
        Etiqueta.Location = New Point(5, 5)
        EnProgreso.Controls.Add(Etiqueta)
        'Dim Barra As New ProgressBar
        'Barra.Style = ProgressBarStyle.Marquee
        'Barra.Size = New Point(270, 40)
        'Barra.Location = New Point(10, 30)
        'Barra.Value = 100
        'EnProgreso.Controls.Add(Barra)
        EnProgreso.Show()
        Application.DoEvents()
        dgvVista.DataSource = Split(todos_los_datos)
        EnProgreso.Close()
    End Sub
End Class
