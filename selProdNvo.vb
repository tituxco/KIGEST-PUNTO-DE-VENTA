Imports SIGT__KIGEST.GestorInsumos
Imports System.Linq

Public Class selProdNvo
    Public Shared busqueda As String
    Public Shared fila As String
    Public Shared llama As String

    Public listaPrecioSeleccionada As fact_listaPrecios
    Public idAlmacenSeleccionado As Integer

    ' Declaramos 
    Public Property productoSeleccionado As GestorInsumos.fact_insumos = Nothing


    Private Sub selProdNvo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If busqueda = "" Then
            txtBusquedaProd.Text = ""
            dtproductos.DataSource = Nothing
        Else
            txtBusquedaProd.Text = busqueda
            RealizarBusqueda()
            ' ELIMINAMOS dtproductos.Focus() de acá
        End If
    End Sub
    Private Sub selProdNvo_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' 1. Ponemos el cursor adentro de la caja de texto
        txtBusquedaProd.Focus()

        ' 2. Seleccionamos (pintamos de azul) todo lo que esté escrito
        txtBusquedaProd.SelectAll()
    End Sub

    ' --- Evento cuando el usuario marca o desmarca el stock ---
    Private Sub chkstock_CheckedChanged(sender As Object, e As EventArgs) Handles chkstock.CheckedChanged
        RealizarBusqueda()
    End Sub

    Public Sub RealizarBusqueda()
        Dim textoBuscado As String = txtBusquedaProd.Text.Trim()

        ' Esperamos a que tipee al menos 2 caracteres para no saturar la base
        If textoBuscado.Length < 2 Then
            dtproductos.DataSource = Nothing
            Return
        End If

        ' 1. Buscamos en la base de datos SOLO lo que coincide
        Dim listaEncontrada As New List(Of fact_insumos)
        listaEncontrada = fact_insumos.BuscarPorNombreOCodigo(textoBuscado)

        ' 2. Le inyectamos el stock a esos productos encontrados
        If listaEncontrada.Count > 0 Then
            fact_insumos.InyectarStockMasivo(listaEncontrada)
        End If

        ' 3. Aplicamos el filtro del CheckBox (Solo stock positivo en ESTE almacén)
        'MsgBox(idAlmacenSeleccionado)
        If chkstock.Checked Then
            listaEncontrada = listaEncontrada.Where(Function(p As fact_insumos) p.GetStockEnAlmacen(idAlmacenSeleccionado) > 0).ToList()
        End If

        ' 4. Volcamos la lista filtrada a la grilla
        dtproductos.DataSource = listaEncontrada


        ConfigurarColumnasVisibles()
        CompletarDatosDinamicos()
    End Sub

    Private Sub ConfigurarColumnasVisibles()
        If dtproductos.Columns.Count = 0 Then Return

        ' 1. Ocultamos todo por defecto
        For Each col As DataGridViewColumn In dtproductos.Columns
            col.Visible = False
        Next

        ' 2. Encendemos y configuramos lo esencial
        If dtproductos.Columns.Contains("id") Then
            ' Lo dejo en False porque al cajero no suele servirle ver el ID interno, 
            ' pero cambialo a True si lo necesitan ver.
            dtproductos.Columns("id").Visible = False
        End If
        If dtproductos.Columns.Contains("descripcion") Then
            With dtproductos.Columns("descripcion")
                .Visible = True
                .HeaderText = "Descripción"
                '.Width = 100
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
        End If

        If dtproductos.Columns.Contains("codigo") Then
            With dtproductos.Columns("codigo")
                .Visible = True
                .HeaderText = "Código"
                .Width = 30
            End With
        End If

        ' 3. Columnas extra: Precio Final
        If Not dtproductos.Columns.Contains("colPrecio") Then
            Dim colPrecio As New DataGridViewTextBoxColumn()
            colPrecio.Name = "colPrecio"
            colPrecio.HeaderText = "Precio Final"
            colPrecio.DefaultCellStyle.Format = "C2"
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colPrecio.Width = 30
            dtproductos.Columns.Add(colPrecio)
        Else
            With dtproductos.Columns("colPrecio")
                .Visible = True
                .Width = 30
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        End If

        ' 4. Columnas extra: Stock
        If Not dtproductos.Columns.Contains("colStock") Then
            Dim colStock As New DataGridViewTextBoxColumn()
            colStock.Name = "colStock"
            colStock.HeaderText = "Stock"
            colStock.DefaultCellStyle.Format = "N2"
            colStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colStock.Width = 30
            dtproductos.Columns.Add(colStock)
        Else
            With dtproductos.Columns("colStock")
                .Visible = True
                .Width = 30
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End If
    End Sub

    Private Sub CompletarDatosDinamicos()
        ' (Tu caché de monedas acá) ...

        For Each row As DataGridViewRow In dtproductos.Rows
            Dim prod As fact_insumos = CType(row.DataBoundItem, fact_insumos)
            If prod IsNot Nothing Then
                Dim cotizacion As Decimal = 1 ' (Reemplazá por la lógica real de tu moneda)

                ' Asignamos los valores calculados
                row.Cells("colPrecio").Value = fact_insumos.CalcularPrecioUnitarioFinal(prod, cotizacion, listaPrecioSeleccionada)
                row.Cells("colStock").Value = prod.GetStockEnAlmacen(idAlmacenSeleccionado)
            End If
        Next
    End Sub

    Private Sub txtBusquedaProd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusquedaProd.KeyDown
        If e.KeyCode = Keys.Enter Then
            RealizarBusqueda()
        End If
    End Sub

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellContentClick

    End Sub

    Private Sub dtproductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellDoubleClick
        SeleccionarProductoActual()
    End Sub

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtproductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SeleccionarProductoActual()
        End If
    End Sub


    Private Sub SeleccionarProductoActual()
        If dtproductos.CurrentRow IsNot Nothing Then
            ' Obtenemos el objeto insumo seleccionado de la fila
            Dim prodSeleccionado As GestorInsumos.fact_insumos = CType(dtproductos.CurrentRow.DataBoundItem, GestorInsumos.fact_insumos)

            If prodSeleccionado IsNot Nothing Then
                ' Guardamos el producto en nuestra variable pública
                Me.productoSeleccionado = prodSeleccionado

                ' Le avisamos al sistema que la selección fue exitosa y cerramos
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub
End Class