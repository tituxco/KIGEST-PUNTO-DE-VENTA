Imports SIGT__KIGEST.GestorInsumos
Imports WSAFIPFE.panmat
Imports SIGT__KIGEST.funciones_Globales
Imports SIGT__KIGEST.GestorClientes
Imports SIGT__KIGEST.GestorFacturacion
Imports WSAFIPFE.Factura
Imports SIGT__KIGEST.datosEstructura


Public Class frmPtoVtaNvo

    Public facturaCliente As GestorClientes.fact_clientes
    Public facturaListaPrecios As fact_listaPrecios
    Public facturaVendedor As datosEstructura.fact_vendedor
    Public facturaAlmacen As fact_insumos_almacenes
    Public facturaPtoVta As GestorFacturacion.fact_puntosventa
    Public facturaTipoCompobante As GestorFacturacion.fact_comprobantes_tipo
    Public comprobanteDatosGenerales As GestorFacturacion.fact_facturasrapidas
    Public facturaCondicionVenta As datosEstructura.fact_condventas

    Private fechaFacturaSeleccionada As DateTime = DateTime.Now.Date

    Public TotalesActuales As New TotalesFacturaViewModel()

    Public nuevaFactura_Datos As GestorFacturacion.factNuevaFactura_Datos

    Public PedidosVinculados As New List(Of Integer)
    'Public nuevaFactura_Items As GestorFacturacion.factNuevaFactura_Items

    Private Sub frmPtoVtaNvo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Crear el objeto ToolTip
        Dim miToolTip As New ToolTip()

        ' Configurar algunas propiedades opcionales
        miToolTip.AutoPopDelay = 5000   ' tiempo que se muestra (ms)
        miToolTip.InitialDelay = 500    ' retraso antes de aparecer (ms)
        miToolTip.ReshowDelay = 200     ' retraso entre apariciones
        miToolTip.ShowAlways = True     ' que se muestre siempre

        miToolTip.SetToolTip(btnFacturaAlmacenSeleccionar, "Seleccionar Almacen/Local")
        miToolTip.SetToolTip(btnFacturaClienteBuscar, "Seleccionar Cliente")
        miToolTip.SetToolTip(btnFacturaDescuentosRecargos, "Aplicar Descuentos/Recargos")
        miToolTip.SetToolTip(btnFcturaTipoSeleccionar, "Cambiar Tipo de Factura")
        miToolTip.SetToolTip(btnFacturaFinalizar, "Finalizar factura")
        miToolTip.SetToolTip(btnFacturaImprimir, "Imprimir factura")
        miToolTip.SetToolTip(btnFacturaListaPreciosSeleccionar, "Seleccionar Lista de precios")
        miToolTip.SetToolTip(btnFacturaCondicionVentaSeleccionar, "Condición de venta")
        miToolTip.SetToolTip(btnFacturaVendedorSeleccionar, "Seleccionar vendedor")
        miToolTip.SetToolTip(btnProductoBuscar, "Buscar productos")
        miToolTip.SetToolTip(btnAgregarProdGenerico, "Agregar un producto generico")
        miToolTip.SetToolTip(btnLimpiarProductos, "Eliminar lista de productos")

        lblFacturaMensajes.Text = ""

        ' MsgBox(DatosAcceso.IdAlmacen)
        'cargamos cliente por defecto
        facturaCliente = GestorClientes.fact_clientes.BuscarPorID(9999) 'consumidor final por defecto para facturas que no sean a responsanbles inscriptos
        comprobanteDatosGenerales = GestorFacturacion.fact_facturasrapidas.BuscarPorID(DatosAcceso.idFacRap)
        facturaAlmacen = fact_insumos_almacenes.BuscarPorID(DatosAcceso.IdAlmacen)
        facturaCondicionVenta = datosEstructura.fact_condventas.BuscarPorID(1) ' contado por defecto (1)
        facturaVendedor = facturaCliente.vendedor
        facturaPtoVta = GestorFacturacion.fact_puntosventa.BuscarPorID(DatosAcceso.IdPtoVtaDef)

        lblFacturaFechaComprobante.Text = fechaFacturaSeleccionada
        chkFacturaDescontarStock.Checked = DatosAcceso.StockPpref
        rdFacturaImpresionTermica.Checked = My.Settings.ImprTikets
        chkFacturaImpresionAutomatica.Checked = My.Settings.ImprTikets 'esto lo cambiaremos despues para que sea n
        'cargamos datos generales
        CargarDatosCliente()
        CargarDatosVendedor()
        CargarDatosListaPrecios()
        CargarDatosAlmacen()
        CargarDatosCoprobanteSeleccionado()
        CargarDatosCondicionVenta()


        'MsgBox("ASIGNACION INICIAL " & fechaFacturaSeleccionada)
    End Sub
    Public Sub CargarDatosCliente()
        Try
            'cargamos datos de cliente
            lblFacturaClienteNombreApellido.Text = facturaCliente.ToString
            lblFacturaClienteOtrosDatos.Text = facturaCliente.dirDomicilio & " - " & facturaCliente.dirLocalidad.nombre & vbNewLine _
            & facturaCliente.ivaTipo.nombre & ": " & facturaCliente.cuit

            facturaListaPrecios = facturaCliente.listaPrecios
            facturaVendedor = facturaCliente.vendedor
            RecalcularPreciosGrilla()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub CargarDatosCoprobanteSeleccionado()
        Try
            lblFacturaNumComprobante.Text = comprobanteDatosGenerales.punto_venta.descripcion & vbNewLine & comprobanteDatosGenerales.nombre
            facturaTipoCompobante = comprobanteDatosGenerales.tipofact
            facturaPtoVta = comprobanteDatosGenerales.punto_venta

            If comprobanteDatosGenerales.punto_venta.id = FacturaElectro.puntovtaelect Then
                tmrFacturaParpadeoLegal.Enabled = True
            Else
                tmrFacturaParpadeoLegal.Enabled = False
                lblFacturaNumComprobante.Visible = True
            End If
            RecalcularPreciosGrilla()
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
            lblVendedor.Text = "(" & facturaVendedor.id & ") " & facturaVendedor.ToString
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CargarDatosListaPrecios()
        If facturaListaPrecios IsNot Nothing Then
            ' 1. Actualizamos el Label visual en la pantalla
            lblFacturaListaPrecios.Text = "(" & facturaListaPrecios.id & ") " & facturaListaPrecios.ToString
            ' MsgBox("cambio lista")
            ' 2. Recalculamos toda la grilla (por si ya había productos cargados)
            RecalcularPreciosGrilla()
        End If
    End Sub
    Public Sub CargarDatosAlmacen()
        lblFacturaAlmacen.Text = "(" & facturaAlmacen.id & ") " & facturaAlmacen.ToString
    End Sub
    Public Sub CargarDatosCondicionVenta()
        lblFacturaCondicionVenta.Text = "(" & facturaCondicionVenta.id & ") " & facturaCondicionVenta.ToString
    End Sub
    Private Sub cmdCliente_Click(sender As Object, e As EventArgs) Handles btnFacturaClienteBuscar.Click
        'selclie.busqueda = txtclierazon.Text
        selclie.llama = "ptovtaNvo"
        selclie.dtpersonal.Focus()
        selclie.ShowDialog()
    End Sub
    Private Sub cmdListaPrecio_Click(sender As Object, e As EventArgs) Handles btnFacturaListaPreciosSeleccionar.Click
        'selclie.busqueda = txtclierazon.Text
        selListaPrecios.llama = "ptovtaNvo"
        selListaPrecios.dtlistas.Focus()
        selListaPrecios.ShowDialog()
    End Sub
    Private Sub btnFacturaCondicionVentaSeleccionar_Click(sender As Object, e As EventArgs) Handles btnFacturaCondicionVentaSeleccionar.Click
        selCondVta.llama = "ptovtaNvo"
        selCondVta.dtCondVtas.Focus()
        selCondVta.ShowDialog()
    End Sub
    Private Sub cmdAlmacen_Click(sender As Object, e As EventArgs) Handles btnFacturaAlmacenSeleccionar.Click
        selAlmacen.llama = "ptovtaNvo"
        selAlmacen.dtAlmacen.Focus()
        selAlmacen.ShowDialog()
    End Sub
    Private Sub cmdEditar_Click(sender As Object, e As EventArgs) Handles btnFcturaTipoSeleccionar.Click
        selPtoVta.llama = "ptovtaNvo"
        selPtoVta.ptovta = GestorFacturacion.fact_puntosventa.BuscarPorID(DatosAcceso.IdPtoVtaDef)
        selPtoVta.dtPtoVta.Focus()
        selPtoVta.ShowDialog()
    End Sub
    Private Sub btnFacturaVendedorSeleccionar_Click(sender As Object, e As EventArgs) Handles btnFacturaVendedorSeleccionar.Click
        selVendedor.llama = "ptovtaNvo"
        selVendedor.dtvendedor.Focus()
        selVendedor.ShowDialog()
    End Sub
    'Private Sub txtbusquedaAddPlu_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbusquedaAddPlu.KeyDown
    '    Try
    '        If e.KeyCode = Keys.Enter Then
    '            e.SuppressKeyPress = True ' Anula el sonido "ding" de Windows

    '            Dim codigo As String = txtbusquedaAddPlu.Text.Trim()
    '            If codigo = "" Then Return ' Opcional: Acá podrías abrir la ventana de búsqueda manual

    '            ' 1. Pedimos el producto a tu capa de negocio
    '            Dim prod As GestorInsumos.fact_insumos = GestorInsumos.fact_insumos.BuscarPorCodigoOLector(codigo)

    '            ' 2. Lo agregamos a la grilla si existe
    '            If prod IsNot Nothing Then
    '                AgregarProductoAGrilla(prod, 1) ' 1 es la cantidad predeterminada
    '            Else
    '                MsgBox("Producto no encontrado.", MsgBoxStyle.Exclamation, "Atención")
    '            End If

    '            ' 3. Limpiamos para el próximo escaneo
    '            txtbusquedaAddPlu.Text = ""
    '            txtbusquedaAddPlu.Focus()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error: " & ex.Message)
    '    End Try


    'End Sub
    Private Sub txtbusquedaAddPlu_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbusquedaAddPlu.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True ' Anula el sonido "ding" de Windows

                Dim codigo As String = txtbusquedaAddPlu.Text.Trim()
                If codigo = "" Then Return

                Dim prod As GestorInsumos.fact_insumos = Nothing
                Dim cantidadCalculada As Decimal = 1

                ' 1. Verificamos si es un código de Producción Propia (A00 o 00)
                If codigo.StartsWith("A00", StringComparison.OrdinalIgnoreCase) OrElse codigo.StartsWith("00", StringComparison.OrdinalIgnoreCase) Then

                    Dim codigoLimpio As String = codigo.Replace("B", "").Replace("A", "").Replace("b", "").Replace("a", "").Trim()

                    ' --- LLAMAMOS AL GESTOR DE FACTURACIÓN ---
                    prod = GestorFacturacion.BuscarProductoProduccion(codigoLimpio, cantidadCalculada)

                    If prod Is Nothing Then
                        MsgBox("No se encuentra el ticket de producción o ya fue facturado.", MsgBoxStyle.Exclamation, "Atención")
                    End If

                    ' 2. Si no es de producción, hacemos la búsqueda Normal
                Else
                    ' --- LLAMAMOS AL GESTOR DE INSUMOS ---
                    prod = GestorInsumos.fact_insumos.BuscarPorCodigoOLector(codigo)

                    If prod Is Nothing Then
                        MsgBox("Producto no encontrado.", MsgBoxStyle.Exclamation, "Atención")
                    End If
                End If

                ' 3. Si encontramos algo, lo agregamos a la grilla
                If prod IsNot Nothing Then
                    If codigo.StartsWith("A00", StringComparison.OrdinalIgnoreCase) OrElse codigo.StartsWith("00", StringComparison.OrdinalIgnoreCase) Then
                        ' Lo agregamos indicando que es de producción (NO recalcula precios)
                        AgregarProductoAGrilla(prod, cantidadCalculada, True)
                    Else
                        ' Producto común (SÍ recalcula precios según lista)
                        AgregarProductoAGrilla(prod, cantidadCalculada, False)
                    End If
                End If

                ' 4. Limpiamos para el próximo escaneo
                txtbusquedaAddPlu.Text = ""
                txtbusquedaAddPlu.Focus()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub ActualizarProductoEnFila(indexFila As Integer, prod As GestorInsumos.fact_insumos, cantidad As Double)
        ' 1. Obtenemos la cotización (Misma lógica que ya tenés)
        Dim cotizacionItem As Decimal = 1
        If prod.monedaId > 0 Then
            Dim objMoneda As fact_moneda = fact_moneda.BuscarPorID(prod.monedaId)
            If objMoneda IsNot Nothing Then
                cotizacionItem = objMoneda.GetCotizacionNumeric()
                If cotizacionItem = 0 Then cotizacionItem = 1
            End If
        End If

        ' 2. Calculamos el precio unitario final completo
        Dim precioUnitarioFinal As Decimal = fact_insumos.CalcularPrecioUnitarioFinal(prod, cotizacionItem, facturaListaPrecios)
        Dim subtotalLinea As Decimal = precioUnitarioFinal * CDec(cantidad)

        ' 3. Volcamos los datos a la fila EXISTENTE
        Dim fila As DataGridViewRow = dgvFacturaProductos.Rows(indexFila)

        ' ATENCIÓN: Ajustá los nombres "codProducto", "descProducto", etc. a los Name reales de tus columnas
        fila.Cells("codProducto").Value = prod.codigo
        fila.Cells("descProducto").Value = prod.descripcion
        fila.Cells("cantProducto").Value = ParsearDecimal(cantidad)
        fila.Cells("punitProducto").Value = ParsearDecimal(precioUnitarioFinal)
        fila.Cells("ptotalProducto").Value = ParsearDecimal(subtotalLinea)

        ' Guardamos los datos ocultos que tenés en tu Add
        fila.Cells("gananciaProducto").Value = prod.ganancia
        fila.Cells("ivaProducto").Value = prod.iva
        fila.Cells("impFijo1Producto").Value = prod.impuestoFijo01
        fila.Cells("impFijo2Producto").Value = prod.impuestoFijo02
        fila.Cells("idProducto").Value = prod.id
        fila.Cells("monedaProducto").Value = prod.monedaId

        ' Guardamos el objeto en el Tag
        fila.Cells("codProducto").Tag = prod

        ' 4. Actualizamos totales e ítems
        CalcularTotalesFactura()
        ActualizarCantidadTotalItems()
    End Sub
    'Private Sub AgregarProductoAGrilla(prod As GestorInsumos.fact_insumos, cantidad As Double, Optional esDeProduccion As Boolean = False)
    '    Dim precioUnitarioFinal As Decimal = 0

    '    If esDeProduccion Then
    '        ' Si es de producción, respetamos el precio exacto que ya trae cargado el objeto
    '        precioUnitarioFinal = prod.precio
    '    Else
    '        ' 1. Obtenemos la cotización correspondiente a la moneda del producto (Solo para comunes)
    '        Dim cotizacionItem As Decimal = 1
    '        If prod.monedaId > 0 Then
    '            Dim objMoneda As fact_moneda = fact_moneda.BuscarPorID(prod.monedaId)
    '            If objMoneda IsNot Nothing Then
    '                cotizacionItem = objMoneda.GetCotizacionNumeric()
    '                If cotizacionItem = 0 Then cotizacionItem = 1
    '            End If
    '        End If

    '        ' 2. Calculamos el precio unitario final completo para productos normales
    '        precioUnitarioFinal = fact_insumos.CalcularPrecioUnitarioFinal(prod, cotizacionItem, facturaListaPrecios)
    '    End If

    '    Dim subtotalLinea As Decimal = precioUnitarioFinal * CDec(cantidad)

    '    ' 3. Volcamos los datos a la grilla
    '    Dim indexFila As Integer = dgvFacturaProductos.Rows.Add(
    '    prod.codigo,            ' 0: PLU/Codigo
    '    prod.descripcion,       ' 1: DESCRIPCION
    '    cantidad,               ' 2: CANTIDAD
    '    precioUnitarioFinal,    ' 3: P. Unitario
    '    subtotalLinea,          ' 4: P. Total 
    '    prod.ganancia,          ' 5: GANANCIA
    '    prod.iva,               ' 6: IVA
    '    prod.impuestoFijo01,    ' 7: Imp. Fijo 1
    '    prod.impuestoFijo02,    ' 8: Imp. Fijo 2
    '    prod.id,                ' 9: idProducto
    '    prod.monedaId           ' 10: moneda
    ')

    '    Dim filaNueva As DataGridViewRow = dgvFacturaProductos.Rows(indexFila)
    '    filaNueva.Cells("codProducto").Tag = prod
    '    filaNueva.Cells("cantProducto").Tag = cantidad
    '    filaNueva.Cells("punitProducto").Tag = precioUnitarioFinal
    '    filaNueva.Cells("ptotalProducto").Tag = subtotalLinea 

    '    ' 4. Actualizamos totales e ítems
    '    CalcularTotalesFactura()
    '    ActualizarCantidadTotalItems()
    'End Sub
    Private Sub AgregarProductoAGrilla(prod As GestorInsumos.fact_insumos, cantidad As Double, Optional esDeProduccion As Boolean = False)
        Dim precioUnitarioFinal As Decimal = 0

        If esDeProduccion Then
            precioUnitarioFinal = prod.precio
        Else
            Dim cotizacionItem As Decimal = 1
            If prod.monedaId > 0 Then
                Dim objMoneda As fact_moneda = fact_moneda.BuscarPorID(prod.monedaId)
                If objMoneda IsNot Nothing Then
                    cotizacionItem = objMoneda.GetCotizacionNumeric()
                    If cotizacionItem = 0 Then cotizacionItem = 1
                End If
            End If
            precioUnitarioFinal = fact_insumos.CalcularPrecioUnitarioFinal(prod, cotizacionItem, facturaListaPrecios)
        End If

        Dim subtotalLinea As Decimal = precioUnitarioFinal * CDec(cantidad)

        Dim indexFila As Integer = dgvFacturaProductos.Rows.Add(
        prod.codigo,
        prod.descripcion,
        cantidad,
        precioUnitarioFinal,
        subtotalLinea,
        prod.ganancia,
        prod.iva,
        prod.impuestoFijo01,
        prod.impuestoFijo02,
        prod.id,
        prod.monedaId
    )

        Dim filaNueva As DataGridViewRow = dgvFacturaProductos.Rows(indexFila)

        ' GUARDAMOS LOS DATOS EN LOS TAGS DE CADA CELDA CORRESPONDIENTE
        filaNueva.Cells("codProducto").Tag = prod
        filaNueva.Cells("cantProducto").Tag = CDec(cantidad)
        filaNueva.Cells("punitProducto").Tag = CDec(precioUnitarioFinal)
        filaNueva.Cells("ptotalProducto").Tag = CDec(subtotalLinea)

        ' Indicamos por defecto que NO fue modificado manualmente a mano
        filaNueva.Tag = False ' False = Precio de sistema, True = Modificado por operador

        CalcularTotalesFactura()
        ActualizarCantidadTotalItems()
    End Sub
    Private Sub ActualizarCantidadTotalItems()
        Dim cantidadTotal As Decimal = 0

        For Each row As DataGridViewRow In dgvFacturaProductos.Rows
            If Not row.IsNewRow AndAlso row.Cells("cantProducto").Value IsNot Nothing Then
                cantidadTotal += ParsearDecimal(row.Cells("cantProducto").Value)
            End If
        Next

        Dim culturaArg As New System.Globalization.CultureInfo("es-AR")
        lblFacturaCantItems.Text = cantidadTotal.ToString("N2", culturaArg)
    End Sub

    Private Sub RecalcularPreciosGrilla()
        For Each row As DataGridViewRow In dgvFacturaProductos.Rows
            If Not row.IsNewRow Then
                If row.Cells("codProducto").Tag IsNot Nothing Then

                    Dim prod As GestorInsumos.fact_insumos = CType(row.Cells("codProducto").Tag, GestorInsumos.fact_insumos)

                    ' SI ES UN PRODUCTO GENÉRICO ("VARIOS" o id = 0) O FUE MODIFICADO A MANO, NO LO RECALCULAMOS
                    Dim esGenerico As Boolean = (prod.id = 0 OrElse prod.codigo = "VARIOS")
                    Dim modificadoAMano As Boolean = (row.Tag IsNot Nothing AndAlso CBool(row.Tag) = True)

                    If esGenerico OrElse modificadoAMano Then
                        Continue For ' Salta al siguiente sin modificar el precio actual del operador
                    End If

                    Dim cantidad As Decimal = ParsearDecimal(row.Cells("cantProducto").Value)

                    Dim cotizacionItem As Decimal = 1
                    If prod.monedaId > 0 Then
                        Dim objMoneda As fact_moneda = fact_moneda.BuscarPorID(prod.monedaId)
                        If objMoneda IsNot Nothing Then
                            cotizacionItem = objMoneda.GetCotizacionNumeric()
                            If cotizacionItem = 0 Then cotizacionItem = 1
                        End If
                    End If

                    Dim nuevoPrecio As Decimal = fact_insumos.CalcularPrecioUnitarioFinal(prod, cotizacionItem, facturaListaPrecios)
                    Dim nuevoSubtotal As Decimal = Math.Round(nuevoPrecio * cantidad, 2)

                    ' Actualizamos valores y sus Tags
                    row.Cells("punitProducto").Value = nuevoPrecio
                    row.Cells("punitProducto").Tag = nuevoPrecio
                    row.Cells("ptotalProducto").Value = nuevoSubtotal
                    row.Cells("ptotalProducto").Tag = nuevoSubtotal
                End If
            End If
        Next

        CalcularTotalesFactura()
        ActualizarCantidadTotalItems()
    End Sub
    'Private Sub RecalcularPreciosGrilla()
    '    For Each row As DataGridViewRow In dgvFacturaProductos.Rows
    '        ' Evitamos la fila vacía del final
    '        If Not row.IsNewRow Then

    '            ' Buscamos el Tag adentro de la celda específica
    '            If row.Cells("codProducto").Tag IsNot Nothing Then

    '                ' Recuperamos el objeto insumo
    '                Dim prod As GestorInsumos.fact_insumos = CType(row.Cells("codProducto").Tag, GestorInsumos.fact_insumos)

    '                ' --- NUEVO: Usamos el parseo seguro para leer la cantidad ---
    '                Dim cantidad As Decimal = ParsearDecimal(row.Cells("cantProducto").Value)

    '                ' Buscamos la cotización según la moneda del producto
    '                Dim cotizacionItem As Decimal = 1
    '                If prod.monedaId > 0 Then
    '                    Dim objMoneda As fact_moneda = fact_moneda.BuscarPorID(prod.monedaId)
    '                    If objMoneda IsNot Nothing Then
    '                        cotizacionItem = objMoneda.GetCotizacionNumeric()
    '                        If cotizacionItem = 0 Then cotizacionItem = 1
    '                    End If
    '                End If

    '                ' Recalculamos con la función de precios unitarios pasándole su cotización real
    '                Dim nuevoPrecio As Decimal = fact_insumos.CalcularPrecioUnitarioFinal(prod, cotizacionItem, facturaListaPrecios)
    '                Dim nuevoSubtotal As Decimal = Math.Round(nuevoPrecio * cantidad, 2)

    '                ' Actualizamos visualmente las celdas de la grilla
    '                row.Cells("punitProducto").Value = nuevoPrecio
    '                row.Cells("ptotalProducto").Value = nuevoSubtotal
    '            Else
    '                MsgBox("El producto se perdió en la fila: " & row.Index)
    '            End If

    '        End If
    '    Next

    '    ' Actualizamos los totales generales y la cantidad de ítems abajo
    '    CalcularTotalesFactura()
    '    ActualizarCantidadTotalItems()
    'End Sub
    Public Sub AgregarProductoDesdeBuscador(prod As GestorInsumos.fact_insumos, cantidad As Double)
        ' Llamamos directamente a método existente que ya calcula precios y carga la grilla dgvFacturaProductos
        AgregarProductoAGrilla(prod, cantidad)

        ' Opcional: Ponemos el foco nuevamente en el textbox de códigos para seguir escaneando
        txtbusquedaAddPlu.Focus()
    End Sub
    Private Sub CalcularTotalesFactura()
        Dim subtotalNeto As Decimal = 0
        Dim totalIva21 As Decimal = 0
        Dim totalIva105 As Decimal = 0
        Dim totalOtroIva As Decimal = 0
        Dim totalGeneral As Decimal = 0
        Dim otrosTributos As Decimal = 0
        Dim totIDC As Decimal = 0
        Dim totICL As Decimal = 0
        Dim sub21 As Decimal = 0
        Dim sub105 As Decimal = 0
        Dim sub0 As Decimal = 0

        Dim idComprobante As Integer = 0
        If facturaTipoCompobante IsNot Nothing Then
            idComprobante = facturaTipoCompobante.id
        End If

        Dim esComprobanteInterno As Boolean = (idComprobante > 900)
        Dim esFacturaA As Boolean = (idComprobante >= 1 AndAlso idComprobante <= 3)
        Dim esFacturaC As Boolean = (idComprobante >= 11 AndAlso idComprobante <= 13)
        Dim preciosFinales As Boolean = 1 'chkPreciosFinales.Checked

        For Each row As DataGridViewRow In dgvFacturaProductos.Rows
            If Not row.IsNewRow AndAlso row.Cells("codProducto").Tag IsNot Nothing Then

                Dim cantidad As Decimal = ParsearDecimal(row.Cells("cantProducto").Value)
                Dim alicuotaIva As Decimal = ParsearDecimal(row.Cells("ivaProducto").Value)
                Dim precioUnitario As Decimal = 0

                If row.Cells("punitProducto").Tag Is Nothing Then
                    precioUnitario = ParsearDecimal(row.Cells("punitProducto").Value)
                    row.Cells("punitProducto").Tag = precioUnitario
                Else
                    precioUnitario = ParsearDecimal(row.Cells("punitProducto").Tag)
                End If

                If preciosFinales AndAlso esFacturaA Then
                    precioUnitario = precioUnitario / (1 + (alicuotaIva / 100))
                    row.Cells("punitProducto").Value = Math.Round(precioUnitario, 4)
                    row.Cells("ptotalProducto").Value = Math.Round(precioUnitario * cantidad, 2)
                Else
                    row.Cells("punitProducto").Value = Math.Round(precioUnitario, 4)
                    row.Cells("ptotalProducto").Value = Math.Round(precioUnitario * cantidad, 2)
                End If

                Dim totalLinea As Decimal = ParsearDecimal(row.Cells("ptotalProducto").Value)

                If esComprobanteInterno OrElse esFacturaC Then
                    ' Comprobantes Internos / Remitos: Todo pasa de largo sin desglosar IVA
                    subtotalNeto += totalLinea
                    totalGeneral += totalLinea

                    ' Para Facturas C, la AFIP suele requerir que el monto total se envíe como importe Neto No Gravado o Exento 
                    ' (generalmente en la base imponible 0 o sub0). Lo acumulamos acá:
                    'If esFacturaC Then
                    '    sub0 += totalLinea
                    'End If
                Else
                    ' Comprobantes Legales (Facturas A, B, C, etc.)
                    Dim netoCalculado As Decimal = 0
                    Dim ivaCalculado As Decimal = 0

                    If preciosFinales AndAlso Not esFacturaA Then
                        netoCalculado = totalLinea / (1 + (alicuotaIva / 100))
                        ivaCalculado = totalLinea - netoCalculado
                        totalGeneral += totalLinea
                    Else
                        netoCalculado = totalLinea
                        ivaCalculado = totalLinea * (alicuotaIva / 100)
                        totalGeneral += (netoCalculado + ivaCalculado)
                    End If

                    subtotalNeto += netoCalculado

                    If alicuotaIva = 21 OrElse alicuotaIva = 21.0 OrElse alicuotaIva = 21.0 Then
                        totalIva21 += ivaCalculado
                        sub21 += netoCalculado
                    ElseIf alicuotaIva = 10.5 OrElse alicuotaIva = 10.5 Then
                        totalIva105 += ivaCalculado
                        sub105 += netoCalculado
                    ElseIf alicuotaIva > 0 Then
                        totalOtroIva += ivaCalculado
                    Else
                        sub0 += netoCalculado
                    End If
                End If

                If row.Cells("impFijo1Producto") IsNot Nothing AndAlso row.Cells("impFijo1Producto").Value IsNot Nothing AndAlso row.Cells("impFijo1Producto").Value.ToString() <> "" Then
                    Dim idc As Decimal = ParsearDecimal(row.Cells("impFijo1Producto").Value)
                    totIDC += cantidad * idc
                End If
                If row.Cells("impFijo2Producto") IsNot Nothing AndAlso row.Cells("impFijo2Producto").Value IsNot Nothing AndAlso row.Cells("impFijo2Producto").Value.ToString() <> "" Then
                    Dim icl As Decimal = ParsearDecimal(row.Cells("impFijo2Producto").Value)
                    totICL += cantidad * icl
                End If

            End If
        Next

        otrosTributos = totIDC + totICL
        totalGeneral += otrosTributos

        ' 1. GUARDAMOS TODO EN LA CLASE GENERAL DEL FORMULARIO
        TotalesActuales.SubtotalNeto = Math.Round(subtotalNeto, 2)
        TotalesActuales.Iva21 = Math.Round(totalIva21, 2)
        TotalesActuales.Iva105 = Math.Round(totalIva105, 2)
        TotalesActuales.OtroIva = Math.Round(totalOtroIva, 2)
        TotalesActuales.TotalGeneral = Math.Round(totalGeneral, 2)
        TotalesActuales.OtrosTributos = Math.Round(otrosTributos, 2)
        TotalesActuales.TotalIDC = Math.Round(totIDC, 2)
        TotalesActuales.TotalICL = Math.Round(totICL, 2)
        TotalesActuales.Subtotal21 = Math.Round(sub21, 2)
        TotalesActuales.Subtotal105 = Math.Round(sub105, 2)
        TotalesActuales.Subtotal0 = Math.Round(sub0, 2)
        TotalesActuales.TotalImpuestos = TotalesActuales.Iva21 + TotalesActuales.Iva105 + TotalesActuales.OtroIva

        ' 2. REFLEJAMOS VISUALMENTE EN LOS LABELS DESDE LA CLASE
        Dim culturaArg As New System.Globalization.CultureInfo("es-AR")
        lblFacturaSubtotal.Text = TotalesActuales.SubtotalNeto.ToString("C2", culturaArg)
        lblFacturaTotal.Text = TotalesActuales.TotalGeneral.ToString("C2", culturaArg)


        If TotalesActuales.TotalImpuestos = 0 Then
            lblFacturaImpuestos.Text = "$ 0,00"
        Else
            lblFacturaImpuestos.Text = TotalesActuales.TotalImpuestos.ToString("C2", culturaArg)
        End If
    End Sub
    Private Sub txtbusquedaAddPlu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbusquedaAddPlu.KeyPress
        Try
            If e.KeyChar = ("*") Then

                MsgBox("multiplicador")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnProductoBuscar_Click(sender As Object, e As EventArgs) Handles btnProductoBuscar.Click
        ' Instanciamos limpio
        Dim buscador As New selProdNvo()
        buscador.llama = "ptovtaNvo"
        buscador.idAlmacenSeleccionado = facturaAlmacen.id
        buscador.listaPrecioSeleccionada = facturaListaPrecios
        buscador.txtBusquedaProd.Focus()

        ' Si elije un producto y le da Aceptar...
        If buscador.ShowDialog() = DialogResult.OK Then
            If buscador.productoSeleccionado IsNot Nothing Then
                ' Reutilizamos tu rutina que AGREGA una fila nueva al final
                AgregarProductoDesdeBuscador(buscador.productoSeleccionado, 1)
            End If
        End If
    End Sub
    Private Sub btnFacturaFinalizar_Click(sender As Object, e As EventArgs) Handles btnFacturaFinalizar.Click
        CalcularTotalesFactura()
        If TotalesActuales.TotalGeneral = 0 OrElse dgvFacturaProductos.Rows.Count = 0 Then
            MsgBox("NO SE PUEDE CERRAR UNA COMPROBANTE EN CERO (0) O SIN ITEMS")
            Exit Sub
        End If
        Dim tiposValidos As Integer() = {1, 6, 11, 999}
        'a consumidor final solamente se pueden hacer facturas no notas de credito ni de debito
        If Not tiposValidos.Contains(facturaTipoCompobante.id) AndAlso facturaCliente.idCliente <> 9999 Then
            MsgBox("este comprobante no se puede realizar a un consumidor final, debe seleccionar o agregar un cliente")
            Exit Sub
        End If

        If facturaCliente.idCliente = 9999 And facturaCondicionVenta.id <> 1 Then
            MsgBox("No se puede realizar venta o nota de credito a un consumidor final en cuenta corriente, por favor seleccione un cliente o agregue")
            Exit Sub
        End If
        If btnFacturaFinalizar.Tag IsNot Nothing AndAlso btnFacturaFinalizar.Tag.ToString() = "NUEVA_VENTA" Then

            LimpiarPantallaVenta()

            ' RESTAURAMOS EL BOTÓN A SU ASPECTO ORIGINAL
            btnFacturaFinalizar.Text = "Finalizar Venta"
            btnFacturaFinalizar.BackColor = Color.FromArgb(0, 192, 192)
            btnFacturaFinalizar.Image = SIGT__KIGEST.My.Resources.Resources.Checkout
            btnFacturaFinalizar.Tag = "FINALIZAR"

            Exit Sub ' Salimos para no ejecutar el guardado de nuevo
        End If

        LlenarDatosFacturaDesdePantalla()

        ' 1. VALIDAR STOCK PREVIO Y PINTAR
        Dim descontarGlobal As Boolean = chkFacturaDescontarStock.Checked

        If descontarGlobal Then
            For Each row As DataGridViewRow In dgvFacturaProductos.Rows
                If Not row.IsNewRow AndAlso row.Cells("codProducto").Tag IsNot Nothing Then
                    Dim idProd As Integer = CInt(row.Cells("idProducto").Value)
                    Dim cant As Decimal = ParsearDecimal(row.Cells("cantProducto").Value)

                    ' Usamos la nueva función del GestorInsumos
                    If Not GestorInsumos.ComprobarStock(idProd, cant, facturaAlmacen.id) Then
                        row.DefaultCellStyle.BackColor = Color.Red
                    Else
                        row.DefaultCellStyle.BackColor = Color.LightGreen
                    End If
                End If
            Next
        End If


        ' 2. PEDIR CUENTA CONTABLE (Solo si corresponde el módulo)
        If InStr(DatosAcceso.Moduloacc, "4al") <> 0 AndAlso nuevaFactura_Datos.tipofact.id <= 13 Then
            ' Lógica simplificada: en vez de buscar "TV" en la grilla entera de forma rara, preguntamos directo
            Dim numCtaStr = InputBox("¿A qué cuenta desea enviar esta factura?" & vbCrLf &
                             "75 - Ventas Publicidad Radio" & vbCrLf &
                             "76 - Ventas Publicidad Television" & vbCrLf &
                             "77 - Ventas Pequeños Anunciantes", "Envío a cuentas contables", "77")

            If IsNumeric(numCtaStr) Then
                nuevaFactura_Datos.cuentaContable = CInt(numCtaStr)
            Else
                nuevaFactura_Datos.cuentaContable = 77
            End If
        End If

        ' 3. RECOPILAR PEDIDOS ASOCIADOS
        Dim pedidosAcumulados As String = ""
        For Each PedidoFact As DataGridViewRow In dtpedidosfact.Rows
            If PedidoFact.Cells(0).Value IsNot Nothing AndAlso PedidoFact.Cells(0).Value.ToString() <> "" Then
                pedidosAcumulados &= PedidoFact.Cells(0).Value.ToString() & ","
            End If
        Next
        ' Le sacamos la última coma y lo guardamos en el DTO
        If pedidosAcumulados.Length > 0 Then
            nuevaFactura_Datos.listaPedidos = pedidosAcumulados.TrimEnd(","c)
        End If


        '#############################################################

        ' . VALIDACIÓN PREVIA PARA NOTAS DE CRÉDITO O DÉBITO
        Dim tipofact As Integer = nuevaFactura_Datos.tipofact.id

        If tipofact = 2 OrElse tipofact = 3 OrElse tipofact = 7 OrElse tipofact = 8 OrElse tipofact = 12 OrElse tipofact = 13 Then
            Dim tipoCompAsoc As Integer = 0
            Select Case tipofact
                Case 2, 3 : tipoCompAsoc = 1 ' Factura A
                Case 7, 8 : tipoCompAsoc = 6 ' Factura B
                Case 12, 13 : tipoCompAsoc = 11 ' Factura C
            End Select

            Dim cbteAsocStr As String = InputBox("Es una Nota de Crédito/Débito. Ingrese el número de comprobante asociado:", "Comprobante Asociado Requerido")

            If cbteAsocStr = "" OrElse Not IsNumeric(cbteAsocStr) Then
                MsgBox("Es obligatorio ingresar un número de comprobante asociado válido para continuar.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Int32.TryParse(cbteAsocStr, nuevaFactura_Datos.ComprobanteAsociadoNro)
            nuevaFactura_Datos.ComprobanteAsociadoTipo = tipoCompAsoc

            Dim fechaAsoc As String = GestorFacturacion.ObtenerFechaFacturaElectro(nuevaFactura_Datos.ComprobanteAsociadoNro, tipoCompAsoc)
            If String.IsNullOrEmpty(fechaAsoc) Then
                MsgBox("No se pudo encontrar el comprobante asociado o no ha sido autorizado previamente.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            nuevaFactura_Datos.ComprobanteAsociadoFecha = fechaAsoc
        End If



        Dim proximoNum As Integer = GestorFacturacion.ObtenerProximoNumeroComprobante(nuevaFactura_Datos.tipofact.id, nuevaFactura_Datos.ptovta.id)

        If proximoNum = 0 Then
            MsgBox("Se canceló el proceso porque no se pudo obtener el número correlativo.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        ' Actualizamos nuestro objeto DTO con el número 
        nuevaFactura_Datos.num_fact = proximoNum

        Dim nombreComprobante As String = nuevaFactura_Datos.tipofact.nombre   ' O .nombre según lo tengas
        Dim ptoVtaStr As String = nuevaFactura_Datos.ptovta.id.ToString("0000")
        Dim numFactStr As String = proximoNum.ToString("00000000")

        Dim mensajeInicial As String = $"Procesando {nombreComprobante} N° {ptoVtaStr}-{numFactStr}. Por favor espere..."

        ' . LANZAMOS EL FORMULARIO DE PROGRESO CON EL TEXTO 
        Dim frmCarga As Form = GestorUtilidades.MostrarProgreso(mensajeInicial)
        Try
            ' . EVALUAR SI DEBE PASAR POR AFIP O ES INTERNO / NO FISCAL (> 900)
            ' Si el ID es mayor a 900 (comprobante interno/remito) o no es el punto de venta electrónico, NO va a AFIP
            Dim esComprobanteInterno As Boolean = (tipofact > 900)
            Dim esElectronica As Boolean = (nuevaFactura_Datos.ptovta.id = FacturaElectro.puntovtaelect)

            If esElectronica AndAlso Not esComprobanteInterno Then
                ' Actualizamos el texto de progreso para la AFIP
                frmCarga.Text = "Autorizando con AFIP..."

                Dim afip As New GestorAFIP()

                If afip.SolicitarCAE(nuevaFactura_Datos) Then
                    ' Autorizado con éxito: cargamos los datos de CAE al DTO
                    nuevaFactura_Datos.cae = afip.CAE
                    nuevaFactura_Datos.vtocae = DateTime.ParseExact(afip.VtoCAE, "yyyyMMdd", Nothing)
                    nuevaFactura_Datos.codbarra = afip.CodigoBarras
                    nuevaFactura_Datos.codigo_qr = afip.CodigoQR
                Else
                    ' Si la AFIP rechaza, cortamos el proceso
                    MsgBox("ARCA rechazó el comprobante: " & vbCrLf & afip.MensajeError & vbCrLf & afip.Observaciones, MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Else
                ' Es un comprobante interno (> 900) o no electrónico: va directo a la BD local sin CAE
                nuevaFactura_Datos.cae = ""
                nuevaFactura_Datos.codbarra = ""
            End If

            Dim guardadoExitoso As Boolean = GestorFacturacion.GuardarFacturaCompleta(nuevaFactura_Datos)

            If guardadoExitoso Then
                ' 5. DESTRUCCIÓN AUTOMÁTICA DE LA VENTANA DE PROGRESO ANTES DE ABRIR COBRO
                If frmCarga IsNot Nothing AndAlso Not frmCarga.IsDisposed Then
                    frmCarga.Close()
                    frmCarga.Dispose()
                End If

                lblFacturaMensajes.Text = "Comprobante guardado con éxito!"
                lblFacturaMensajes.ForeColor = Color.GreenYellow
                btnFacturaImprimir.Enabled = True
                'btnFacturaFinalizar.Enabled = False

                'Dim tipofact As Integer = nuevaFactura_Datos.tipofact.id
                Dim esNotaCredito As Boolean = (tipofact = 3 Or tipofact = 8 Or tipofact = 13 Or tipofact = 991)

                ' SI ES CONTADO Y NO ES NOTA DE CRÉDITO, ABRIMOS LA VENTANA DE PAGOS
                If nuevaFactura_Datos.condvta.id = 1 AndAlso Not esNotaCredito Then
                    Dim mov As New frmpagoscompra()

                    Dim idComprobanteGuardado As Integer = nuevaFactura_Datos.IdDevuelto

                    mov.NumeroFactura = nuevaFactura_Datos.ptovta.id.ToString("0000") & " - " & nuevaFactura_Datos.num_fact.ToString("00000000")
                    mov.CtaClie = facturaCliente.idCliente.ToString()
                    mov.RazonSocial = facturaCliente.nomapellRazon
                    mov.Direccion = facturaCliente.dirDomicilio
                    mov.Localidad = facturaCliente.dirLocalidad.nombre
                    mov.tipoContr = facturaCliente.ivaTipo.nombre
                    mov.CUIT = facturaCliente.cuit
                    mov.Fecha = nuevaFactura_Datos.fecha.ToString("yyyy-MM-dd")
                    mov.TOTAL = nuevaFactura_Datos.total.ToString()
                    mov.almacen = nuevaFactura_Datos.Almacen.id
                    mov.caja = nuevaFactura_Datos.caja
                    mov.IdFacturaCTA = idComprobanteGuardado
                    mov.IdFacturaComp = idComprobanteGuardado

                    mov.ShowDialog()
                End If

                ' IMPRESIÓN AUTOMÁTICA (Se ejecuta tras cerrar el cobro o directamente si es Cta. Cte.)
                ' Usamos el IdDevuelto que es el ID real recién guardado en la base
                Dim idImprimir As Integer = nuevaFactura_Datos.IdDevuelto
                Dim ptoVtaActual As Integer = nuevaFactura_Datos.ptovta.id

                ' Evaluamos tu nuevo checkbox de impresión automática
                If chkFacturaImpresionAutomatica.Checked AndAlso nuevaFactura_Datos.tipofact.id <> 998 Then

                    ' Vemos qué formato eligió el usuario en los RadioButtons
                    Dim imprimirTermico As Boolean = rdFacturaImpresionTermica.Checked

                    ' Definimos si es venta de contado
                    Dim impresionDirecta As Boolean = (nuevaFactura_Datos.condvta.id = 1)

                    ' Mandamos la orden al Gestor
                    GestorImpresion.ImprimirComprobante(idImprimir, ptoVtaActual, imprimirTermico, impresionDirecta)

                End If

                ' --- CAMBIO DE ESTADO DEL BOTÓN A "NUEVA FACTURA" ---
                btnFacturaFinalizar.Text = "Nueva Factura"
                ' Usamos un rojo suave/tranqui (IndianRed es un rojo opaco, muy agradable a la vista)
                btnFacturaFinalizar.BackColor = Color.IndianRed
                btnFacturaFinalizar.Image = SIGT__KIGEST.My.Resources.Resources.New_Copy_64px2
                btnFacturaFinalizar.Tag = "NUEVA_VENTA"

                ' Verificamos si tenés un checkbox para blanquear/reiniciar de forma automática la venta
                ' (Por ejemplo, chkNuevaVentaAutomatica.Checked)
                If chkFacturaReinicarForm.Checked Then
                    ' Llamamos a tu método que limpia los campos, grilla de ítems, cliente, etc.
                    LimpiarPantallaVenta()

                    ' Volvemos el botón a su estado original de "Finalizar" de inmediato
                    btnFacturaFinalizar.Text = "Finalizar Venta"
                    btnFacturaFinalizar.BackColor = Color.FromArgb(0, 192, 192)
                    btnFacturaFinalizar.Image = SIGT__KIGEST.My.Resources.Resources.Checkout
                    btnFacturaFinalizar.Tag = "FINALIZAR"
                End If

            Else
                MsgBox("Hubo un error al intentar guardar el comprobante en la base de datos.", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("Ocurrió un error inesperado: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            ' 5. DESTRUCCIÓN AUTOMÁTICA DE LA VENTANA DE PROGRESO
            If frmCarga IsNot Nothing AndAlso Not frmCarga.IsDisposed Then
                frmCarga.Close()
                frmCarga.Dispose()
            End If
        End Try
    End Sub
    Private Sub frmPtoVtaNvo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then

            Dim input As String = InputBox("Ingrese la nueva fecha (Formato: DD/MM/AAAA):", "Cambiar Fecha de Factura", fechaFacturaSeleccionada.ToString("dd/MM/yyyy"))

            If input <> "" Then
                Dim nuevaFecha As DateTime
                If DateTime.TryParse(input, nuevaFecha) Then
                    fechaFacturaSeleccionada = nuevaFecha
                    MsgBox("Fecha actualizada a: " & fechaFacturaSeleccionada.ToShortDateString(), MsgBoxStyle.Information)
                    lblFacturaFechaComprobante.Text = fechaFacturaSeleccionada
                    ' (Opcional) Si tenés algún Label en la pantalla que muestre la fecha, actualizalo acá:
                    ' lblFechaVisual.Text = fechaFacturaSeleccionada.ToShortDateString()
                Else
                    MsgBox("El formato de fecha ingresado no es válido. Debe ser DD/MM/AAAA.", MsgBoxStyle.Critical, "Error")
                End If
            End If
            ' Si presionan F11, disparamos el visualizador
        ElseIf e.KeyCode = Keys.F11 Then

            If nuevaFactura_Datos IsNot Nothing Then
                Dim reporte As String = "=== DATOS INTERNOS ===" & vbCrLf &
                                            "Fecha:         " & nuevaFactura_Datos.fecha & vbCrLf &
                                            "Subtotal Neto: " & nuevaFactura_Datos.subtotal.ToString("N2") & vbCrLf &
                                            "IVA 21%:       " & nuevaFactura_Datos.iva21.ToString("N2") & vbCrLf &
                                            "IVA 10,5%:     " & nuevaFactura_Datos.iva105.ToString("N2") & vbCrLf &
                                            "Otro IVA:      " & nuevaFactura_Datos.otroiva.ToString("N2") & vbCrLf &
                                            "----------------------" & vbCrLf &
                                            "TOTAL FINAL:   " & nuevaFactura_Datos.total.ToString("N2")

                MsgBox(reporte)
            Else
                MsgBox("Aún no hay datos en nuevaFactura_Datos.")
            End If

        End If
    End Sub
    Private Sub dgvFacturaProductos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvFacturaProductos.RowsRemoved
        CalcularTotalesFactura()
        ActualizarCantidadTotalItems()
    End Sub

    Private Sub dgvFacturaProductos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturaProductos.CellValueChanged
        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow = dgvFacturaProductos.Rows(e.RowIndex)

        If dgvFacturaProductos.Columns(e.ColumnIndex).Name = "cantProducto" OrElse dgvFacturaProductos.Columns(e.ColumnIndex).Name = "punitProducto" Then

            ' Si el usuario cambió el precio unitario, marcamos la fila como modificada a mano
            If dgvFacturaProductos.Columns(e.ColumnIndex).Name = "punitProducto" Then
                row.Tag = True ' Marcamos que el precio fue alterado por el operador
            End If

            Dim cantidad As Decimal = ParsearDecimal(row.Cells("cantProducto").Value)
            Dim precioUnitario As Decimal = ParsearDecimal(row.Cells("punitProducto").Value)
            ' MsgBox($"PRECIO: {cantidad} * {precioUnitario }")
            ' Actualizamos los tags de la celda
            row.Cells("cantProducto").Tag = cantidad
            row.Cells("punitProducto").Tag = precioUnitario

            Dim subtotalLinea As Decimal = Math.Round(precioUnitario * cantidad, 2)
            row.Cells("ptotalProducto").Value = subtotalLinea
            row.Cells("ptotalProducto").Tag = subtotalLinea
        End If

        CalcularTotalesFactura()
        ActualizarCantidadTotalItems()
    End Sub
    'Private Sub dgvFacturaProductos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturaProductos.CellValueChanged
    '    If e.RowIndex < 0 Then Return

    '    Dim row As DataGridViewRow = dgvFacturaProductos.Rows(e.RowIndex)
    '    If dgvFacturaProductos.Columns(e.ColumnIndex).Name = "cantProducto" Or dgvFacturaProductos.Columns(e.ColumnIndex).Name = "punitProducto" Then

    '        Dim prod As GestorInsumos.fact_insumos = CType(row.Cells("codProducto").Tag, GestorInsumos.fact_insumos)

    '        ' Si el usuario cambió el precio a mano, actualizamos el Tag para que tu rutina no lo pise
    '        If dgvFacturaProductos.Columns(e.ColumnIndex).Name = "punitProducto" Then

    '            '                row.Cells("punitProducto").Tag = ParsearDecimal(row.Cells("punitProducto").Value)
    '            prod.precio =
    '        End If
    '        Dim cantidad As Decimal = ParsearDecimal(row.Cells("cantProducto").Value)
    '        Dim precioUnitario As Decimal = ParsearDecimal(row.Cells("punitProducto").Tag) ' Ahora leemos del Tag actualizado

    '        row.Cells("ptotalProducto").Value = Math.Round(precioUnitario * cantidad, 2)

    '    End If

    '    CalcularTotalesFactura()
    '    ActualizarCantidadTotalItems()
    'End Sub
    Private Sub dgvFacturaProductos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvFacturaProductos.CurrentCellDirtyStateChanged
        If dgvFacturaProductos.IsCurrentCellDirty Then
            dgvFacturaProductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub PedirYAgregarProductoGenerico()
        Using frmModal As New Form()
            frmModal.Text = "Agregar Producto Genérico"
            frmModal.StartPosition = FormStartPosition.CenterParent
            frmModal.FormBorderStyle = FormBorderStyle.FixedDialog
            frmModal.MaximizeBox = False
            frmModal.MinimizeBox = False
            frmModal.ClientSize = New Size(320, 210)

            ' 1. Controles simples
            Dim lblDesc As New Label() With {.Text = "Descripción:", .Left = 20, .Top = 20, .Width = 280}
            Dim txtDesc As New TextBox() With {.Name = "txtDesc", .Left = 20, .Top = 40, .Width = 260, .TabIndex = 0}

            Dim lblCant As New Label() With {.Text = "Cantidad:", .Left = 20, .Top = 75, .Width = 120}
            Dim txtCant As New TextBox() With {.Name = "txtCant", .Left = 20, .Top = 95, .Width = 120, .Text = "1", .TabIndex = 1}

            Dim lblPrecio As New Label() With {.Text = "Precio Unitario Final:", .Left = 150, .Top = 75, .Width = 130}
            Dim txtPrecio As New TextBox() With {.Name = "txtPrecio", .Left = 150, .Top = 95, .Width = 130, .TabIndex = 2}

            Dim btnAceptar As New Button() With {.Text = "Aceptar", .Left = 80, .Top = 145, .Width = 90, .DialogResult = DialogResult.OK, .TabIndex = 3}
            Dim btnCancelar As New Button() With {.Text = "Cancelar", .Left = 180, .Top = 145, .Width = 90, .DialogResult = DialogResult.Cancel, .TabIndex = 4}

            frmModal.CancelButton = btnCancelar

            ' 2. Salto con Enter para no usar el mouse (súper útil)
            Dim MoverConEnter As KeyEventHandler = Sub(s, e)
                                                       If e.KeyCode = Keys.Enter Then
                                                           e.SuppressKeyPress = True
                                                           frmModal.SelectNextControl(CType(s, Control), True, True, True, True)
                                                       End If
                                                   End Sub

            AddHandler txtDesc.KeyDown, MoverConEnter
            AddHandler txtCant.KeyDown, MoverConEnter
            AddHandler txtPrecio.KeyDown, MoverConEnter

            frmModal.Controls.AddRange(New Control() {lblDesc, txtDesc, lblCant, txtCant, lblPrecio, txtPrecio, btnAceptar, btnCancelar})
            txtDesc.Focus()

            ' 3. Procesamos al presionar Aceptar
            If frmModal.ShowDialog(Me) = DialogResult.OK Then
                Dim descripcion As String = txtDesc.Text.ToUpper.Trim()

                ' ACÁ ESTÁ LA MAGIA: Tu función se encarga de todo, escriban punto o coma
                Dim cantidad As Decimal = ParsearDecimal(txtCant.Text)
                Dim precioUnitario As Decimal = ParsearDecimal(txtPrecio.Text)

                If String.IsNullOrEmpty(descripcion) Then
                    MsgBox("Debe ingresar una descripción.", MsgBoxStyle.Exclamation)
                    Return
                End If

                If cantidad <= 0 Then
                    MsgBox("La cantidad no es válida.", MsgBoxStyle.Exclamation)
                    Return
                End If

                If precioUnitario < 0 Then
                    MsgBox("El precio no es válido.", MsgBoxStyle.Exclamation)
                    Return
                End If

                ' 4. Volcamos el producto en la grilla
                Dim prodTemp As New GestorInsumos.fact_insumos()
                prodTemp.id = 0
                prodTemp.codigo = "VARIOS"
                prodTemp.descripcion = descripcion
                prodTemp.ganancia = 0
                prodTemp.iva = 21
                prodTemp.impuestoFijo01 = 0
                prodTemp.impuestoFijo02 = 0
                prodTemp.monedaId = My.Settings.monedaDef

                Dim subtotalLinea As Decimal = Math.Round(precioUnitario * cantidad, 2)

                Dim indexFila As Integer = dgvFacturaProductos.Rows.Add(
                    prodTemp.codigo,
                    prodTemp.descripcion,
                    cantidad,
                    precioUnitario,
                    subtotalLinea,
                    prodTemp.ganancia,
                    prodTemp.iva,
                    prodTemp.impuestoFijo01,
                    prodTemp.impuestoFijo02,
                    prodTemp.id,
                    prodTemp.monedaId
                )

                Dim filaNueva As DataGridViewRow = dgvFacturaProductos.Rows(indexFila)

                ' ASIGNACIÓN CORRECTA DE TAGS PARA EL PRODUCTO GENÉRICO
                filaNueva.Cells("codProducto").Tag = prodTemp
                filaNueva.Cells("cantProducto").Tag = cantidad
                filaNueva.Cells("punitProducto").Tag = precioUnitario
                filaNueva.Cells("ptotalProducto").Tag = subtotalLinea

                ' Marcamos la fila como modificada/genérica para que nadie la pise a cero
                filaNueva.Tag = True

                CalcularTotalesFactura()
                ActualizarCantidadTotalItems()

                txtbusquedaAddPlu.Focus()
            End If
        End Using
    End Sub
    Public Function LlenarDatosFacturaDesdePantalla() As Boolean
        Try
            ' 1. Validaciones obligatorias previas
            If dgvFacturaProductos.Rows.Count = 0 Then
                MsgBox("Debe ingresar al menos un producto para facturar.", MsgBoxStyle.Exclamation, "Atención")
                Return False
            End If

            If String.IsNullOrEmpty(lblFacturaClienteNombreApellido.Text) Then
                MsgBox("Debe seleccionar o ingresar una razón social para el cliente.", MsgBoxStyle.Exclamation, "Cliente requerido")
                Return False
            End If

            If lblFacturaClienteNombreApellido.Text = "CONSUMIDOR FINAL" AndAlso facturaCondicionVenta.id = 2 Then
                MsgBox("Debe seleccionar un cliente válido para poder registrar una venta en cuenta corriente.", MsgBoxStyle.Exclamation, "Cuenta corriente")
                Return False
            End If

            ' 2. Inicializamos el objeto principal DTO si no existe
            If nuevaFactura_Datos Is Nothing Then
                nuevaFactura_Datos = New GestorFacturacion.factNuevaFactura_Datos()
            End If

            ' 3. Llenado de Datos de Cabecera
            nuevaFactura_Datos.tipofact = facturaTipoCompobante ' Objeto de tipo de comprobante activo
            nuevaFactura_Datos.ptovta = facturaPtoVta           ' Objeto de punto de venta activo
            'nuevaFactura_Datos.num_fact = ' Val(lblfactnumero.Text)
            nuevaFactura_Datos.fecha = fechaFacturaSeleccionada
            'MsgBox("LLENDANDO  " & nuevaFactura_Datos.fecha & " con  " & fechaFacturaSeleccionada)
            nuevaFactura_Datos.observaciones = "" 'txtobservaciones.Text
            nuevaFactura_Datos.observaciones2 = ""
            nuevaFactura_Datos.remito = "" ' txttransporte.Text
            nuevaFactura_Datos.condvta = facturaCondicionVenta
            nuevaFactura_Datos.vendedor = facturaVendedor
            nuevaFactura_Datos.Almacen = facturaAlmacen
            nuevaFactura_Datos.caja = GestorCajas.ObtenerCajaActualDefecto()
            nuevaFactura_Datos.cliente = facturaCliente

            ' Totales generales calculados previamente en pantalla
            nuevaFactura_Datos.subtotal = ParsearDecimal(TotalesActuales.SubtotalNeto)
            nuevaFactura_Datos.subtotal21 = ParsearDecimal(TotalesActuales.Subtotal21)
            nuevaFactura_Datos.subtotal105 = ParsearDecimal(TotalesActuales.Subtotal105)
            nuevaFactura_Datos.subtotal0 = ParsearDecimal(TotalesActuales.Subtotal0)



            nuevaFactura_Datos.iva105 = ParsearDecimal(TotalesActuales.Iva105)
            nuevaFactura_Datos.iva21 = ParsearDecimal(TotalesActuales.Iva21)
            nuevaFactura_Datos.otroiva = ParsearDecimal(TotalesActuales.OtroIva)
            nuevaFactura_Datos.total = ParsearDecimal(TotalesActuales.TotalGeneral)
            nuevaFactura_Datos.descontarStock = chkFacturaDescontarStock.Checked

            ' 4. Llenado de la Lista de Ítems (recorriendo la grilla)
            If nuevaFactura_Datos.Items Is Nothing Then
                nuevaFactura_Datos.Items = New List(Of GestorFacturacion.factNuevaFactura_Items)()
            Else
                nuevaFactura_Datos.Items.Clear()
            End If

            For Each row As DataGridViewRow In dgvFacturaProductos.Rows
                If Not row.IsNewRow AndAlso row.Cells("codProducto").Tag IsNot Nothing Then
                    Dim item As New GestorFacturacion.factNuevaFactura_Items()

                    item.cod = row.Cells("idProducto").Value.ToString()
                    item.id = row.Cells("idProducto").Value.ToString() 'redundante?
                    item.plu = If(row.Cells("codProducto") IsNot Nothing AndAlso row.Cells("codProducto").Value IsNot Nothing, row.Cells("codProducto").Value.ToString(), "")
                    item.cantidad = ParsearDecimal(row.Cells("cantProducto").Value)
                    item.descripcion = row.Cells("descProducto").Value.ToString().ToUpper()
                    item.iva = ParsearDecimal(row.Cells("ivaProducto").Value)
                    item.punit = ParsearDecimal(row.Cells("punitProducto").Value)
                    item.ptotal = ParsearDecimal(row.Cells("ptotalProducto").Value)
                    item.Almacen = facturaAlmacen
                    item.idCaja = nuevaFactura_Datos.caja

                    ' Impuestos fijos por ítem
                    item.impuestoFijo01 = If(row.Cells("impFijo1Producto").Value IsNot Nothing AndAlso row.Cells("impFijo1Producto").Value.ToString() <> "", ParsearDecimal(row.Cells("impFijo1Producto").Value), 0)
                    item.impuestoFijo02 = If(row.Cells("impFijo2Producto").Value IsNot Nothing AndAlso row.Cells("impFijo2Producto").Value.ToString() <> "", ParsearDecimal(row.Cells("impFijo2Producto").Value), 0)


                    ' ACÁ TRADUCIMOS EL COLOR A DATO LÓGICO:
                    If row.DefaultCellStyle.BackColor = Color.Red Then
                        item.StockSuficiente = False
                    Else
                        item.StockSuficiente = True
                    End If

                    ' Añadimos el ítem a la lista de la factura
                    nuevaFactura_Datos.Items.Add(item)
                End If
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error al recolectar los datos de la pantalla: " & ex.Message, MsgBoxStyle.Critical, "Error de validación")
            Return False
        End Try
    End Function
    Private Sub btnAgregarProdGenerico_Click(sender As Object, e As EventArgs) Handles btnAgregarProdGenerico.Click
        PedirYAgregarProductoGenerico()
    End Sub
    Private Sub btnFacturaImprimir_Click(sender As Object, e As EventArgs) Handles btnFacturaImprimir.Click
        Dim idComprobanteSeleccionado As Integer = nuevaFactura_Datos.IdDevuelto ' O el ID del comprobante que esté seleccionado en grilla/pantalla
        Dim ptoVtaActual As Integer = nuevaFactura_Datos.ptovta.id
        If nuevaFactura_Datos.tipofact.id <> 998 Then
            ' Vemos qué formato eligió el usuario en los RadioButtons
            Dim imprimirTermico As Boolean = rdFacturaImpresionTermica.Checked

            ' En modo manual, si es ticket térmico imprime directo; si es A4, por lo general se prefiere ver el visor (directo = False) 
            ' a menos que quieras forzarlo. Acá lo enlazamos al RadioButton de A4.
            Dim impresionDirecta As Boolean = imprimirTermico OrElse (nuevaFactura_Datos.condvta.id = 1)

            ' Mandamos la orden al Gestor de Impresión
            GestorImpresion.ImprimirComprobante(idComprobanteSeleccionado, ptoVtaActual, imprimirTermico, impresionDirecta)
        End If
    End Sub
    Private Sub LimpiarPantallaVenta()
        ' 1. Limpiar mensajes y variables temporales de la transacción terminada
        lblFacturaMensajes.Text = ""
        nuevaFactura_Datos = Nothing

        ' 2. MANEJO DEL CLIENTE SEGÚN TIPO DE COMPROBANTE
        ' Verificamos si el comprobante que quedó seleccionado es Factura A (Ajustá el ID si es distinto de 1)
        Dim esFacturaA As Boolean = {1, 2, 3}.Contains(facturaTipoCompobante.id)
        btnFacturaImprimir.Enabled = False
        If esFacturaA Then
            ' Si es Factura A, no puede quedar Consumidor Final. Vaciamos el objeto cliente.
            facturaCliente = Nothing
            ' Limpiamos los labels visuales manualmente porque no hay cliente cargado
            ' (Ajustá los nombres de tus labels según correspondan)
            lblFacturaClienteNombreApellido.Text = "Seleccione un cliente (Resp. Inscripto)..."
            lblFacturaClienteOtrosDatos.Text = "-"
        Else
            ' Si es Factura B, Factura C, o Factura X, forzamos Consumidor Final por defecto
            facturaCliente = GestorClientes.fact_clientes.BuscarPorID(9999)
            CargarDatosCliente() ' Usamos tu propio método para repintar los datos en pantalla
        End If

        ' NOTA IMPORTANTE:
        ' No tocamos facturaAlmacen, facturaVendedor, facturaCondicionVenta ni comprobanteDatosGenerales.
        ' Al no modificarlos, se mantienen exactamente igual que en la venta que acaba de terminar.

        ' 3. VACIAR LA GRILLA DE ÍTEMS
        ' Si usás una grilla visual directamente:
        If dgvFacturaProductos.Rows.Count > 0 Then
            dgvFacturaProductos.Rows.Clear()
        End If
        ' Si tenés un DataTable atado a la grilla, descomentá la siguiente línea:
        ' dtItemsVenta.Clear()
        RecalcularPreciosGrilla()

        ' Si tenés variables globales de acumuladores (como las que arreglamos antes), ponelas a 0 acá:
        ' totalGeneral = 0
        ' subtotalNeto = 0
        ' totalIva21 = 0
        ' ...

        ' 5. FOCO LISTO PARA SEGUIR VENDIENDO
        ' (Asumiendo que tenés un TextBox para el lector de código de barras)
        txtbusquedaAddPlu.Focus()

    End Sub

    Public Sub CargarPedidoRemoto(numPedido As Integer, ptoVtaPedido As Integer, idFilaOrigen As Integer)
        Try
            ' 1. Pedimos los datos limpios al Gestor
            Dim pedidoDato As DatosPedidoFacturar = GestorFacturacion.ObtenerPedidoParaFacturar(numPedido, ptoVtaPedido)

            If pedidoDato Is Nothing Then
                MsgBox("El pedido " & numPedido & " no fue encontrado o ya está facturado.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' 2. Actualizamos el entorno de la venta (Vendedor y Condición)
            ' Asumo que tenés las variables globales o métodos para actualizar la UI:
            facturaCondicionVenta = datosEstructura.fact_condventas.BuscarPorID(pedidoDato.IdCondVta)
            ' Lógica para setear el vendedor en tu sistema (ej: facturaVendedor = ...)
            facturaCliente = fact_clientes.BuscarPorID(pedidoDato.IdCliente)
            facturaVendedor = fact_vendedor.BuscarPorID(pedidoDato.IdVendedor)
            CargarDatosCliente()
            CargarDatosVendedor()

            ' 3. Volcamos los ítems a la grilla visual
            For Each itm As DatosItemPedido In pedidoDato.Items
                ' Ajustá los nombres de las columnas a como se llamen en tu DataGridView (dgvItems)
                dgvFacturaProductos.Rows.Add(itm.Codigo, itm.CodInt, itm.Cantidad, itm.Descripcion, itm.Iva, itm.PUnit, itm.PTotal)
            Next

            ' 4. Guardamos el ID del pedido para actualizarlo después
            PedidosVinculados.Add(pedidoDato.IdPedido)
            CalcularTotalesFactura()


        Catch ex As Exception
            MsgBox("Error al volcar el pedido a la factura: " & ex.Message)
        End Try
    End Sub

    Private Sub btnLimpiarProductos_Click(sender As Object, e As EventArgs) Handles btnLimpiarProductos.Click

        If MsgBox("Esta seguro que desea eliminar todos los items actuales?", vbYesNo + vbQuestion, "Blanquear items") = vbNo Then
            Exit Sub
        End If
        dgvFacturaProductos.Rows.Clear()
        PedidosVinculados.Clear()
        dtpedidosfact.Rows.Clear()
        txtbusquedaAddPlu.Focus()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' 1. Detectamos si el usuario presionó la tecla Enter
        If keyData = Keys.Enter Then

            ' 2. Verificamos que haya una celda activa y sea la de descripción
            If dgvFacturaProductos.CurrentCell IsNot Nothing AndAlso dgvFacturaProductos.CurrentCell.OwningColumn.Name = "descProducto" Then

                ' 3. Verificamos que realmente esté escribiendo (en modo edición)
                If dgvFacturaProductos.IsCurrentCellInEditMode Then

                    ' Rescatamos el control interno para leer el texto
                    Dim txtBusqueda As TextBox = TryCast(dgvFacturaProductos.EditingControl, TextBox)

                    If txtBusqueda IsNot Nothing AndAlso txtBusqueda.Text.Trim() <> "" Then
                        Dim textoBuscado As String = txtBusqueda.Text.Trim()

                        ' --- PASO CLAVE 1: Forzamos a la grilla a confirmar el texto en la celda
                        dgvFacturaProductos.EndEdit()

                        ' --- PASO CLAVE 2: Creamos una instancia NUEVA y limpia de tu buscador
                        Dim buscador As New selProdNvo()

                        ' Le pasamos todos los datos a esta nueva instancia
                        buscador.llama = "ptovtaNvo"
                        buscador.busqueda = textoBuscado ' Acá viaja la palabra exacta que tipeaste
                        buscador.idAlmacenSeleccionado = facturaAlmacen.id
                        buscador.listaPrecioSeleccionada = facturaListaPrecios
                        buscador.RealizarBusqueda()

                        ' Guardamos el índice de la fila donde estamos parados ANTES de abrir el buscador
                        Dim indiceFilaActual As Integer = dgvFacturaProductos.CurrentCell.RowIndex

                        ' Abrimos la ventana
                        If buscador.ShowDialog() = DialogResult.OK Then
                            ' Si eligió un producto, llamamos a nuestra NUEVA rutina para pisar la fila
                            If buscador.productoSeleccionado IsNot Nothing Then
                                ActualizarProductoEnFila(indiceFilaActual, buscador.productoSeleccionado, 1)
                            End If
                        End If

                        Return True ' Matamos el Enter
                    End If

                    ' Devolvemos True para matar el Enter y que no salte a la fila de abajo
                    Return True
                End If
            End If
        End If

        ' Para todo lo demás, que Windows siga su curso normal
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub tmrFacturaParpadeoLegal_Tick(sender As Object, e As EventArgs) Handles tmrFacturaParpadeoLegal.Tick
        If lblFacturaNumComprobante.Visible = True Then
            lblFacturaNumComprobante.Visible = False
        Else
            lblFacturaNumComprobante.Visible = True
        End If


    End Sub

    Private Sub dgvFacturaProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturaProductos.CellContentClick

    End Sub

    Private Sub dgvFacturaProductos_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFacturaProductos.CellValidated

    End Sub
End Class