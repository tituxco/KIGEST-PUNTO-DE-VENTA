Public Class frmPtoVtaNvo

    Public facturaCliente As New datosEstructura.fact_clientes
    Public facturaListaPrecios As New datosEstructura.fact_listaPrecios
    Public facturaVendedor As New datosEstructura.fact_vendedor
    Public facturaAlmacen As New datosEstructura.fact_insumos_almacenes
    Public facturaPtoVta As New datosEstructura.fact_puntosventa
    Public facturaTipoCompobante As New datosEstructura.fact_comprobantes_tipo
    Public comprobanteDatosGenerales As New datosEstructura.fact_facturasrapidas
    Public facturaCondicionVenta As New datosEstructura.fact_condventas


    Public nuevaFactura_Datos As New datosEstructura.factNuevaFactura_Datos
    Public nuevaFactura_Items As New datosEstructura.factNuevaFactura_Items

    Private Sub frmPtoVtaNvo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Crear el objeto ToolTip
        Dim miToolTip As New ToolTip()

        ' Configurar algunas propiedades opcionales
        miToolTip.AutoPopDelay = 5000   ' tiempo que se muestra (ms)
        miToolTip.InitialDelay = 500    ' retraso antes de aparecer (ms)
        miToolTip.ReshowDelay = 200     ' retraso entre apariciones
        miToolTip.ShowAlways = True     ' que se muestre siempre

        miToolTip.SetToolTip(cmdAlmacen, "Seleccionar Almacen/Local")
        miToolTip.SetToolTip(cmdCliente, "Seleccionar Cliente")
        miToolTip.SetToolTip(cmdDescuentosRecargos, "Aplicar Descuentos/Recargos")
        miToolTip.SetToolTip(cmdEditar, "Cambiar Tipo de Factura")
        miToolTip.SetToolTip(cmdFinalizar, "Finalizar factura")
        miToolTip.SetToolTip(cmdImprimir, "Imprimir factura")
        miToolTip.SetToolTip(cmdCondVta, "Seleccionar Vendedor")
        miToolTip.SetToolTip(cmdListaPrecio, "Seleccionar Lista de precios")
        miToolTip.SetToolTip(cmdCondVta, "Condición de venta")



        'cargamos cliente por defecto
        facturaCliente = datosEstructura.fact_clientes.BuscarPorID(9999) 'consumidor final por defecto para facturas que no sean a responsanbles inscriptos
        comprobanteDatosGenerales = datosEstructura.fact_facturasrapidas.BuscarPorID(DatosAcceso.idFacRap)
        facturaAlmacen = datosEstructura.fact_insumos_almacenes.BuscarPorID(DatosAcceso.IdAlmacen)
        facturaCondicionVenta = datosEstructura.fact_condventas.BuscarPorID(1) ' contado por defecto (1)


        'cargamos datos generales
        CargarDatosCliente()
        CargarDatosVendedor()
        CargarDatosListaPrecios()
        CargarDatosAlmacen()
        cargarDatosCoprobanteSeleccionado()
        CargarDatosCondicionVenta()

        facturaPtoVta = datosEstructura.fact_puntosventa.BuscarPorID(DatosAcceso.IdPtoVtaDef)


    End Sub
    Public Sub CargarDatosCliente()
        Try
            'cargamos datos de cliente
            txtClienteNombreApellido.Text = facturaCliente.ToString
            txtClienteOtrosDatos.Text = facturaCliente.dirDomicilio & " - " & facturaCliente.dirLocalidad.nombre & vbNewLine _
            & facturaCliente.ivaTipo.nombre & ": " & facturaCliente.cuit

            facturaListaPrecios = facturaCliente.listaPrecios
            facturaVendedor = facturaCliente.vendedor
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub cargarDatosCoprobanteSeleccionado()
        Try
            txtComprobante.Text = comprobanteDatosGenerales.punto_venta.descripcion & vbNewLine & comprobanteDatosGenerales.nombre
            facturaTipoCompobante = comprobanteDatosGenerales.tipofact
            facturaPtoVta = comprobanteDatosGenerales.punto_venta

        Catch ex As Exception

        End Try
    End Sub

    Public Sub cargarNuevaFacturaDatos()
        Try
            nuevaFactura_Datos.cliente = facturaCliente
            nuevaFactura_Datos.condvta = facturaCondicionVenta
            nuevaFactura_Datos.ivatipo = facturaCliente.ivaTipo
            nuevaFactura_Datos.ptovta = facturaPtoVta
            nuevaFactura_Datos.tipofact = facturaTipoCompobante
            nuevaFactura_Datos.vendedor = facturaVendedor
            nuevaFactura_Datos.condvta = facturaCondicionVenta

        Catch ex As Exception

        End Try
    End Sub
    Public Sub CargarDatosVendedor()
        Try
            txtVendedor.Text = "(" & facturaVendedor.id & ") " & facturaVendedor.ToString
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CargarDatosListaPrecios()
        txtlistaPrecios.Text = "(" & facturaListaPrecios.id & ") " & facturaListaPrecios.ToString
    End Sub
    Public Sub CargarDatosAlmacen()
        txtAlmacen.Text = "(" & facturaAlmacen.id & ") " & facturaAlmacen.ToString
    End Sub

    Public Sub CargarDatosCondicionVenta()
        txtCondicionVenta.Text = "(" & facturaCondicionVenta.id & ") " & facturaCondicionVenta.ToString
    End Sub

    Private Sub cmdCliente_Click(sender As Object, e As EventArgs) Handles cmdCliente.Click
        'selclie.busqueda = txtclierazon.Text
        selclie.llama = "ptovtaNvo"
        selclie.dtpersonal.Focus()
        selclie.ShowDialog()
    End Sub

    Private Sub cmdListaPrecio_Click(sender As Object, e As EventArgs) Handles cmdListaPrecio.Click
        'selclie.busqueda = txtclierazon.Text
        selListaPrecios.llama = "ptovtaNvo"
        selListaPrecios.dtlistas.Focus()
        selListaPrecios.ShowDialog()
    End Sub

    Private Sub cmdVendedor_Click(sender As Object, e As EventArgs) Handles cmdCondVta.Click
        selCondVta.llama = "ptovtaNvo"
        selCondVta.dtCondVtas.Focus()
        selCondVta.ShowDialog()
    End Sub

    Private Sub cmdAlmacen_Click(sender As Object, e As EventArgs) Handles cmdAlmacen.Click
        selAlmacen.llama = "ptovtaNvo"
        selAlmacen.dtAlmacen.Focus()
        selAlmacen.ShowDialog()
    End Sub

    Private Sub cmdEditar_Click(sender As Object, e As EventArgs) Handles cmdEditar.Click
        selPtoVta.llama = "ptovtaNvo"
        selPtoVta.ptovta = datosEstructura.fact_puntosventa.BuscarPorID(DatosAcceso.IdPtoVtaDef)
        selPtoVta.dtPtoVta.Focus()
        selPtoVta.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        selVendedor.llama = "ptovtaNvo"
        selVendedor.dtvendedor.Focus()
        selVendedor.ShowDialog()
    End Sub

    Private Sub txtbusquedaAddPlu_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbusquedaAddPlu.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                MsgBox("buscar")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbusquedaAddPlu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbusquedaAddPlu.KeyPress
        Try
            If e.KeyChar = ("*") Then

                MsgBox("multiplicador")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        selProdNvo.llama = "ptovtaNvo"
        selProdNvo.dtproductos.Focus()
        selProdNvo.ShowDialog()
    End Sub
End Class