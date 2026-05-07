Public Class selProdNvo
    Public Shared busqueda As String
    Public Shared fila As String
    Public Shared llama As String
    Dim listaProductos As List(Of
    datosEstructura.fact_insumos)
    Private Sub selProdNvo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            listaProductos = datosEstructura.fact_insumos.ObtenerTodos
            dtproductos.DataSource = listaProductos
        Catch ex As Exception

        End Try
    End Sub
End Class