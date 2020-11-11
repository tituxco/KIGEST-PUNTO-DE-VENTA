<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmprincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmprincipal))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblPrincipalDolar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbprincipal = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblstatusServer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblstatusBDprinc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusEmp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblstatusgral = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrcomprobarConexion = New System.Windows.Forms.Timer(Me.components)
        Me.menugral = New System.Windows.Forms.MenuStrip()
        Me.cmdclientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdproductos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ABMProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaDeProductos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManejoDePreciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostradorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EtiquetasEnBlancoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdfacturacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaEfacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.reciboconsfinal = New System.Windows.Forms.ToolStripMenuItem()
        Me.facturabconsfinal = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturaA = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemitosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReimpresiónDeComprobantesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdadministracion = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformesDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContableToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CajaDiariaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgendaDeVencimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguracionDeTerminalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdtecnico = New System.Windows.Forms.ToolStripMenuItem()
        Me.CLOUDSERVERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TALLERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdPrestamos = New System.Windows.Forms.ToolStripMenuItem()
        Me.SIMULADORToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LISTADOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecibosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FXConsFinalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FCConsFinalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProduccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SincronizacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProducciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.menugral.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPrincipalDolar, Me.pbprincipal, Me.lblstatusServer, Me.lblstatusBDprinc, Me.lblStatusEmp, Me.ToolStripStatusLabel1, Me.lblstatusgral})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 379)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1245, 24)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblPrincipalDolar
        '
        Me.lblPrincipalDolar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrincipalDolar.Name = "lblPrincipalDolar"
        Me.lblPrincipalDolar.Size = New System.Drawing.Size(60, 19)
        Me.lblPrincipalDolar.Text = "DOLAR:"
        '
        'pbprincipal
        '
        Me.pbprincipal.Name = "pbprincipal"
        Me.pbprincipal.Size = New System.Drawing.Size(100, 18)
        Me.pbprincipal.Visible = False
        '
        'lblstatusServer
        '
        Me.lblstatusServer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatusServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblstatusServer.Name = "lblstatusServer"
        Me.lblstatusServer.Size = New System.Drawing.Size(114, 19)
        Me.lblstatusServer.Text = "Estado del Servidor"
        Me.lblstatusServer.ToolTipText = "Estado de la conexion principal con el servidor"
        Me.lblstatusServer.Visible = False
        '
        'lblstatusBDprinc
        '
        Me.lblstatusBDprinc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatusBDprinc.ForeColor = System.Drawing.Color.Green
        Me.lblstatusBDprinc.Name = "lblstatusBDprinc"
        Me.lblstatusBDprinc.Size = New System.Drawing.Size(136, 19)
        Me.lblstatusBDprinc.Text = "Base de datos principal:"
        Me.lblstatusBDprinc.ToolTipText = "Nombre de la base de datos principal del sistema"
        Me.lblstatusBDprinc.Visible = False
        '
        'lblStatusEmp
        '
        Me.lblStatusEmp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusEmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblStatusEmp.Name = "lblStatusEmp"
        Me.lblStatusEmp.Size = New System.Drawing.Size(0, 19)
        Me.lblStatusEmp.ToolTipText = "Empresa con la que se esta trabajando actualmente"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(306, 19)
        Me.ToolStripStatusLabel1.Text = "KIBIT Informática - 3482-621473 - info@kibit.com.ar"
        '
        'lblstatusgral
        '
        Me.lblstatusgral.Name = "lblstatusgral"
        Me.lblstatusgral.Size = New System.Drawing.Size(0, 19)
        '
        'tmrcomprobarConexion
        '
        Me.tmrcomprobarConexion.Enabled = True
        Me.tmrcomprobarConexion.Interval = 100000
        '
        'menugral
        '
        Me.menugral.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.menugral.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.menugral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdclientes, Me.cmdproductos, Me.cmdfacturacion, Me.cmdadministracion, Me.cmdtecnico, Me.cmdPrestamos, Me.VentasToolStripMenuItem, Me.ProduccionToolStripMenuItem, Me.SincronizacionToolStripMenuItem})
        Me.menugral.Location = New System.Drawing.Point(0, 0)
        Me.menugral.Name = "menugral"
        Me.menugral.Size = New System.Drawing.Size(1245, 40)
        Me.menugral.TabIndex = 15
        Me.menugral.Text = "MenuStrip1"
        '
        'cmdclientes
        '
        Me.cmdclientes.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmdclientes.ForeColor = System.Drawing.Color.White
        Me.cmdclientes.Image = CType(resources.GetObject("cmdclientes.Image"), System.Drawing.Image)
        Me.cmdclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdclientes.Name = "cmdclientes"
        Me.cmdclientes.Size = New System.Drawing.Size(105, 36)
        Me.cmdclientes.Text = "Cientes"
        '
        'cmdproductos
        '
        Me.cmdproductos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ABMProductosToolStripMenuItem, Me.ConsultaDeProductos, Me.ManejoDePreciosToolStripMenuItem, Me.MostradorToolStripMenuItem, Me.StockToolStripMenuItem, Me.EtiquetasEnBlancoToolStripMenuItem, Me.ProducciónToolStripMenuItem})
        Me.cmdproductos.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmdproductos.ForeColor = System.Drawing.Color.White
        Me.cmdproductos.Image = CType(resources.GetObject("cmdproductos.Image"), System.Drawing.Image)
        Me.cmdproductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdproductos.Name = "cmdproductos"
        Me.cmdproductos.Size = New System.Drawing.Size(124, 36)
        Me.cmdproductos.Text = "Productos"
        '
        'ABMProductosToolStripMenuItem
        '
        Me.ABMProductosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ABMProductosToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ABMProductosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ABMProductosToolStripMenuItem.Image = CType(resources.GetObject("ABMProductosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ABMProductosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ABMProductosToolStripMenuItem.Name = "ABMProductosToolStripMenuItem"
        Me.ABMProductosToolStripMenuItem.Size = New System.Drawing.Size(234, 38)
        Me.ABMProductosToolStripMenuItem.Text = "ABM Productos"
        '
        'ConsultaDeProductos
        '
        Me.ConsultaDeProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ConsultaDeProductos.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConsultaDeProductos.ForeColor = System.Drawing.Color.White
        Me.ConsultaDeProductos.Image = CType(resources.GetObject("ConsultaDeProductos.Image"), System.Drawing.Image)
        Me.ConsultaDeProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConsultaDeProductos.Name = "ConsultaDeProductos"
        Me.ConsultaDeProductos.Size = New System.Drawing.Size(234, 38)
        Me.ConsultaDeProductos.Text = "Consulta de productos"
        '
        'ManejoDePreciosToolStripMenuItem
        '
        Me.ManejoDePreciosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ManejoDePreciosToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ManejoDePreciosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ManejoDePreciosToolStripMenuItem.Image = CType(resources.GetObject("ManejoDePreciosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ManejoDePreciosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ManejoDePreciosToolStripMenuItem.Name = "ManejoDePreciosToolStripMenuItem"
        Me.ManejoDePreciosToolStripMenuItem.Size = New System.Drawing.Size(234, 38)
        Me.ManejoDePreciosToolStripMenuItem.Text = "Manejo de precios"
        '
        'MostradorToolStripMenuItem
        '
        Me.MostradorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MostradorToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.MostradorToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.MostradorToolStripMenuItem.Image = CType(resources.GetObject("MostradorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MostradorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MostradorToolStripMenuItem.Name = "MostradorToolStripMenuItem"
        Me.MostradorToolStripMenuItem.Size = New System.Drawing.Size(234, 38)
        Me.MostradorToolStripMenuItem.Text = "Despacho Mostrador"
        '
        'StockToolStripMenuItem
        '
        Me.StockToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.StockToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.StockToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.StockToolStripMenuItem.Image = CType(resources.GetObject("StockToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StockToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StockToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.StockToolStripMenuItem.Name = "StockToolStripMenuItem"
        Me.StockToolStripMenuItem.Size = New System.Drawing.Size(234, 38)
        Me.StockToolStripMenuItem.Text = "Stock"
        '
        'EtiquetasEnBlancoToolStripMenuItem
        '
        Me.EtiquetasEnBlancoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.EtiquetasEnBlancoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.EtiquetasEnBlancoToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Paper_32px
        Me.EtiquetasEnBlancoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EtiquetasEnBlancoToolStripMenuItem.Name = "EtiquetasEnBlancoToolStripMenuItem"
        Me.EtiquetasEnBlancoToolStripMenuItem.Size = New System.Drawing.Size(234, 38)
        Me.EtiquetasEnBlancoToolStripMenuItem.Text = "Etiquetas en blanco"
        '
        'cmdfacturacion
        '
        Me.cmdfacturacion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaEfacturaToolStripMenuItem, Me.NuevoPedidoToolStripMenuItem, Me.reciboconsfinal, Me.facturabconsfinal, Me.FacturaA, Me.RemitosToolStripMenuItem, Me.ReimpresiónDeComprobantesToolStripMenuItem})
        Me.cmdfacturacion.ForeColor = System.Drawing.Color.White
        Me.cmdfacturacion.Image = CType(resources.GetObject("cmdfacturacion.Image"), System.Drawing.Image)
        Me.cmdfacturacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdfacturacion.Name = "cmdfacturacion"
        Me.cmdfacturacion.Size = New System.Drawing.Size(133, 36)
        Me.cmdfacturacion.Text = "Facturación"
        '
        'NuevaEfacturaToolStripMenuItem
        '
        Me.NuevaEfacturaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NuevaEfacturaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.NuevaEfacturaToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.NuevaEfacturaToolStripMenuItem.Image = CType(resources.GetObject("NuevaEfacturaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NuevaEfacturaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevaEfacturaToolStripMenuItem.Name = "NuevaEfacturaToolStripMenuItem"
        Me.NuevaEfacturaToolStripMenuItem.Size = New System.Drawing.Size(275, 38)
        Me.NuevaEfacturaToolStripMenuItem.Text = "Recuperar facturas Elect."
        '
        'NuevoPedidoToolStripMenuItem
        '
        Me.NuevoPedidoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NuevoPedidoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.NuevoPedidoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.NuevoPedidoToolStripMenuItem.Image = CType(resources.GetObject("NuevoPedidoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NuevoPedidoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoPedidoToolStripMenuItem.Name = "NuevoPedidoToolStripMenuItem"
        Me.NuevoPedidoToolStripMenuItem.Size = New System.Drawing.Size(275, 38)
        Me.NuevoPedidoToolStripMenuItem.Text = "Presupuestos/Pedidos"
        '
        'reciboconsfinal
        '
        Me.reciboconsfinal.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.reciboconsfinal.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.reciboconsfinal.ForeColor = System.Drawing.Color.White
        Me.reciboconsfinal.Image = CType(resources.GetObject("reciboconsfinal.Image"), System.Drawing.Image)
        Me.reciboconsfinal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.reciboconsfinal.Name = "reciboconsfinal"
        Me.reciboconsfinal.Size = New System.Drawing.Size(275, 38)
        Me.reciboconsfinal.Text = "Recibo Cons. final"
        '
        'facturabconsfinal
        '
        Me.facturabconsfinal.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.facturabconsfinal.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.facturabconsfinal.ForeColor = System.Drawing.Color.White
        Me.facturabconsfinal.Image = CType(resources.GetObject("facturabconsfinal.Image"), System.Drawing.Image)
        Me.facturabconsfinal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.facturabconsfinal.Name = "facturabconsfinal"
        Me.facturabconsfinal.Size = New System.Drawing.Size(275, 38)
        Me.facturabconsfinal.Text = "Factura B / C"
        '
        'FacturaA
        '
        Me.FacturaA.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FacturaA.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FacturaA.ForeColor = System.Drawing.Color.White
        Me.FacturaA.Image = CType(resources.GetObject("FacturaA.Image"), System.Drawing.Image)
        Me.FacturaA.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.FacturaA.Name = "FacturaA"
        Me.FacturaA.Size = New System.Drawing.Size(275, 38)
        Me.FacturaA.Text = "Factura A"
        '
        'RemitosToolStripMenuItem
        '
        Me.RemitosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RemitosToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RemitosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.RemitosToolStripMenuItem.Name = "RemitosToolStripMenuItem"
        Me.RemitosToolStripMenuItem.Size = New System.Drawing.Size(275, 38)
        Me.RemitosToolStripMenuItem.Text = "Remitos"
        '
        'ReimpresiónDeComprobantesToolStripMenuItem
        '
        Me.ReimpresiónDeComprobantesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ReimpresiónDeComprobantesToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReimpresiónDeComprobantesToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ReimpresiónDeComprobantesToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Print_32px
        Me.ReimpresiónDeComprobantesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ReimpresiónDeComprobantesToolStripMenuItem.Name = "ReimpresiónDeComprobantesToolStripMenuItem"
        Me.ReimpresiónDeComprobantesToolStripMenuItem.Size = New System.Drawing.Size(275, 38)
        Me.ReimpresiónDeComprobantesToolStripMenuItem.Text = "Reimpresión de comprobantes"
        '
        'cmdadministracion
        '
        Me.cmdadministracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdadministracion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformesDeVentasToolStripMenuItem, Me.ContableToolStripMenuItem1, Me.CajaToolStripMenuItem, Me.CajaDiariaToolStripMenuItem, Me.ProveedoresToolStripMenuItem, Me.AgendaDeVencimientosToolStripMenuItem, Me.ConfiguracionDeTerminalToolStripMenuItem})
        Me.cmdadministracion.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cmdadministracion.ForeColor = System.Drawing.Color.White
        Me.cmdadministracion.Image = CType(resources.GetObject("cmdadministracion.Image"), System.Drawing.Image)
        Me.cmdadministracion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdadministracion.Name = "cmdadministracion"
        Me.cmdadministracion.Size = New System.Drawing.Size(159, 36)
        Me.cmdadministracion.Text = "Administracion"
        '
        'InformesDeVentasToolStripMenuItem
        '
        Me.InformesDeVentasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.InformesDeVentasToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.InformesDeVentasToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Graph_Report_32px
        Me.InformesDeVentasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.InformesDeVentasToolStripMenuItem.Name = "InformesDeVentasToolStripMenuItem"
        Me.InformesDeVentasToolStripMenuItem.Size = New System.Drawing.Size(277, 38)
        Me.InformesDeVentasToolStripMenuItem.Text = "Informes de ventas"
        '
        'ContableToolStripMenuItem1
        '
        Me.ContableToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ContableToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.ContableToolStripMenuItem1.Image = CType(resources.GetObject("ContableToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ContableToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ContableToolStripMenuItem1.Name = "ContableToolStripMenuItem1"
        Me.ContableToolStripMenuItem1.Size = New System.Drawing.Size(277, 38)
        Me.ContableToolStripMenuItem1.Text = "Contable"
        '
        'CajaToolStripMenuItem
        '
        Me.CajaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CajaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.CajaToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.CajaToolStripMenuItem.Image = CType(resources.GetObject("CajaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CajaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CajaToolStripMenuItem.Name = "CajaToolStripMenuItem"
        Me.CajaToolStripMenuItem.Size = New System.Drawing.Size(277, 38)
        Me.CajaToolStripMenuItem.Text = "Cajas"
        '
        'CajaDiariaToolStripMenuItem
        '
        Me.CajaDiariaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CajaDiariaToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.CajaDiariaToolStripMenuItem.Name = "CajaDiariaToolStripMenuItem"
        Me.CajaDiariaToolStripMenuItem.Size = New System.Drawing.Size(277, 38)
        Me.CajaDiariaToolStripMenuItem.Text = "Caja Diaria"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProveedoresToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ProveedoresToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ProveedoresToolStripMenuItem.Image = CType(resources.GetObject("ProveedoresToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProveedoresToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(277, 38)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'AgendaDeVencimientosToolStripMenuItem
        '
        Me.AgendaDeVencimientosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AgendaDeVencimientosToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.AgendaDeVencimientosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.AgendaDeVencimientosToolStripMenuItem.Image = CType(resources.GetObject("AgendaDeVencimientosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AgendaDeVencimientosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AgendaDeVencimientosToolStripMenuItem.Name = "AgendaDeVencimientosToolStripMenuItem"
        Me.AgendaDeVencimientosToolStripMenuItem.Size = New System.Drawing.Size(277, 38)
        Me.AgendaDeVencimientosToolStripMenuItem.Text = "Agenda de vencimientos"
        '
        'ConfiguracionDeTerminalToolStripMenuItem
        '
        Me.ConfiguracionDeTerminalToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ConfiguracionDeTerminalToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ConfiguracionDeTerminalToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Automation_32px
        Me.ConfiguracionDeTerminalToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConfiguracionDeTerminalToolStripMenuItem.Name = "ConfiguracionDeTerminalToolStripMenuItem"
        Me.ConfiguracionDeTerminalToolStripMenuItem.Size = New System.Drawing.Size(277, 38)
        Me.ConfiguracionDeTerminalToolStripMenuItem.Text = "Configuracion de terminal"
        '
        'cmdtecnico
        '
        Me.cmdtecnico.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CLOUDSERVERToolStripMenuItem, Me.TALLERToolStripMenuItem})
        Me.cmdtecnico.ForeColor = System.Drawing.Color.White
        Me.cmdtecnico.Image = CType(resources.GetObject("cmdtecnico.Image"), System.Drawing.Image)
        Me.cmdtecnico.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdtecnico.Name = "cmdtecnico"
        Me.cmdtecnico.Size = New System.Drawing.Size(104, 36)
        Me.cmdtecnico.Text = "Tecnico"
        '
        'CLOUDSERVERToolStripMenuItem
        '
        Me.CLOUDSERVERToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CLOUDSERVERToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.CLOUDSERVERToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Cloud_Storage_32px
        Me.CLOUDSERVERToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CLOUDSERVERToolStripMenuItem.Name = "CLOUDSERVERToolStripMenuItem"
        Me.CLOUDSERVERToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.CLOUDSERVERToolStripMenuItem.Text = "CLOUD SERVER"
        '
        'TALLERToolStripMenuItem
        '
        Me.TALLERToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TALLERToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.TALLERToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Computer_Support_32px
        Me.TALLERToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TALLERToolStripMenuItem.Name = "TALLERToolStripMenuItem"
        Me.TALLERToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.TALLERToolStripMenuItem.Text = "TALLER"
        '
        'cmdPrestamos
        '
        Me.cmdPrestamos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SIMULADORToolStripMenuItem, Me.LISTADOToolStripMenuItem})
        Me.cmdPrestamos.ForeColor = System.Drawing.Color.White
        Me.cmdPrestamos.Image = Global.SIGT__KIGEST.My.Resources.Resources.Bank_Building_32px
        Me.cmdPrestamos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrestamos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdPrestamos.Name = "cmdPrestamos"
        Me.cmdPrestamos.Size = New System.Drawing.Size(127, 36)
        Me.cmdPrestamos.Text = "Prestamos"
        '
        'SIMULADORToolStripMenuItem
        '
        Me.SIMULADORToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SIMULADORToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SIMULADORToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Refund_32px
        Me.SIMULADORToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SIMULADORToolStripMenuItem.Name = "SIMULADORToolStripMenuItem"
        Me.SIMULADORToolStripMenuItem.Size = New System.Drawing.Size(185, 38)
        Me.SIMULADORToolStripMenuItem.Text = "SIMULADOR"
        '
        'LISTADOToolStripMenuItem
        '
        Me.LISTADOToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LISTADOToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.LISTADOToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Search_Property_32px
        Me.LISTADOToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LISTADOToolStripMenuItem.Name = "LISTADOToolStripMenuItem"
        Me.LISTADOToolStripMenuItem.Size = New System.Drawing.Size(185, 38)
        Me.LISTADOToolStripMenuItem.Text = "LISTADO"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaVentaToolStripMenuItem, Me.PedidosToolStripMenuItem, Me.RecibosToolStripMenuItem, Me.FacturasToolStripMenuItem, Me.FXConsFinalToolStripMenuItem, Me.FCConsFinalToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(68, 36)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        Me.VentasToolStripMenuItem.Visible = False
        '
        'NuevaVentaToolStripMenuItem
        '
        Me.NuevaVentaToolStripMenuItem.Name = "NuevaVentaToolStripMenuItem"
        Me.NuevaVentaToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.NuevaVentaToolStripMenuItem.Text = "Nueva venta"
        '
        'PedidosToolStripMenuItem
        '
        Me.PedidosToolStripMenuItem.Name = "PedidosToolStripMenuItem"
        Me.PedidosToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.PedidosToolStripMenuItem.Text = "Pedidos"
        Me.PedidosToolStripMenuItem.Visible = False
        '
        'RecibosToolStripMenuItem
        '
        Me.RecibosToolStripMenuItem.Name = "RecibosToolStripMenuItem"
        Me.RecibosToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.RecibosToolStripMenuItem.Text = "Recibos"
        Me.RecibosToolStripMenuItem.Visible = False
        '
        'FacturasToolStripMenuItem
        '
        Me.FacturasToolStripMenuItem.Name = "FacturasToolStripMenuItem"
        Me.FacturasToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.FacturasToolStripMenuItem.Text = "Facturas"
        Me.FacturasToolStripMenuItem.Visible = False
        '
        'FXConsFinalToolStripMenuItem
        '
        Me.FXConsFinalToolStripMenuItem.Name = "FXConsFinalToolStripMenuItem"
        Me.FXConsFinalToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.FXConsFinalToolStripMenuItem.Text = "FX Cons. Final"
        Me.FXConsFinalToolStripMenuItem.Visible = False
        '
        'FCConsFinalToolStripMenuItem
        '
        Me.FCConsFinalToolStripMenuItem.Name = "FCConsFinalToolStripMenuItem"
        Me.FCConsFinalToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.FCConsFinalToolStripMenuItem.Text = "FC Cons. Final"
        Me.FCConsFinalToolStripMenuItem.Visible = False
        '
        'ProduccionToolStripMenuItem
        '
        Me.ProduccionToolStripMenuItem.Name = "ProduccionToolStripMenuItem"
        Me.ProduccionToolStripMenuItem.Size = New System.Drawing.Size(100, 36)
        Me.ProduccionToolStripMenuItem.Text = "Produccion"
        Me.ProduccionToolStripMenuItem.Visible = False
        '
        'SincronizacionToolStripMenuItem
        '
        Me.SincronizacionToolStripMenuItem.Name = "SincronizacionToolStripMenuItem"
        Me.SincronizacionToolStripMenuItem.Size = New System.Drawing.Size(123, 36)
        Me.SincronizacionToolStripMenuItem.Text = "Sincronizacion"
        Me.SincronizacionToolStripMenuItem.Visible = False
        '
        'ProducciónToolStripMenuItem
        '
        Me.ProducciónToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProducciónToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ProducciónToolStripMenuItem.Name = "ProducciónToolStripMenuItem"
        Me.ProducciónToolStripMenuItem.Size = New System.Drawing.Size(234, 38)
        Me.ProducciónToolStripMenuItem.Text = "Producción"
        '
        'frmprincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1245, 403)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.menugral)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "frmprincipal"
        Me.Text = "Principal"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.menugral.ResumeLayout(False)
        Me.menugral.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblstatusServer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrcomprobarConexion As System.Windows.Forms.Timer
    Friend WithEvents lblstatusBDprinc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusEmp As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblstatusgral As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents menugral As System.Windows.Forms.MenuStrip
    Friend WithEvents cmdclientes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdproductos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevaVentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PedidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdadministracion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProduccionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContableToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecibosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdfacturacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevaEfacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoPedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SincronizacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FXConsFinalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FCConsFinalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrestamos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgendaDeVencimientosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents reciboconsfinal As ToolStripMenuItem
    Friend WithEvents facturabconsfinal As ToolStripMenuItem
    Friend WithEvents FacturaA As ToolStripMenuItem
    Friend WithEvents cmdtecnico As ToolStripMenuItem
    Friend WithEvents ABMProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultaDeProductos As ToolStripMenuItem
    Friend WithEvents RemitosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pbprincipal As ToolStripProgressBar
    Friend WithEvents ManejoDePreciosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MostradorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EtiquetasEnBlancoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReimpresiónDeComprobantesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CajaDiariaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfiguracionDeTerminalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CLOUDSERVERToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformesDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblPrincipalDolar As ToolStripStatusLabel
    Friend WithEvents SIMULADORToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LISTADOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TALLERToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProducciónToolStripMenuItem As ToolStripMenuItem
End Class
