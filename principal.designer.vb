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
        Me.pbprincipal = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblprocesando = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblPrincipalDolar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblstatusServer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblEstadoCertificado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblstatusBDprinc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusEmp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblstatusgral = New System.Windows.Forms.ToolStripStatusLabel()
        Me.listaConexiones = New System.Windows.Forms.ToolStripDropDownButton()
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
        Me.cmdServicios = New System.Windows.Forms.ToolStripMenuItem()
        Me.CLOUDSERVERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TALLERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PublicidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpleadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListaDeEmpleadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidaciónDeSueldosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProduccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdPrestamos = New System.Windows.Forms.ToolStripMenuItem()
        Me.SIMULADORToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LISTADOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SALIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNotificaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbempresas = New System.Windows.Forms.ToolStripComboBox()
        Me.dtconexiones = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1.SuspendLayout()
        Me.menugral.SuspendLayout()
        CType(Me.dtconexiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbprincipal, Me.lblprocesando, Me.lblPrincipalDolar, Me.lblstatusServer, Me.lblEstadoCertificado, Me.lblstatusBDprinc, Me.lblStatusEmp, Me.ToolStripStatusLabel1, Me.lblstatusgral, Me.listaConexiones})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 388)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1270, 24)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pbprincipal
        '
        Me.pbprincipal.Name = "pbprincipal"
        Me.pbprincipal.Size = New System.Drawing.Size(100, 18)
        Me.pbprincipal.Visible = False
        '
        'lblprocesando
        '
        Me.lblprocesando.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblprocesando.ForeColor = System.Drawing.Color.Olive
        Me.lblprocesando.Name = "lblprocesando"
        Me.lblprocesando.Size = New System.Drawing.Size(153, 19)
        Me.lblprocesando.Text = "Procesando, espere..."
        Me.lblprocesando.Visible = False
        '
        'lblPrincipalDolar
        '
        Me.lblPrincipalDolar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrincipalDolar.Name = "lblPrincipalDolar"
        Me.lblPrincipalDolar.Size = New System.Drawing.Size(60, 19)
        Me.lblPrincipalDolar.Text = "DOLAR:"
        '
        'lblstatusServer
        '
        Me.lblstatusServer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatusServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblstatusServer.Name = "lblstatusServer"
        Me.lblstatusServer.Size = New System.Drawing.Size(65, 19)
        Me.lblstatusServer.Text = "ConfTerm:"
        '
        'lblEstadoCertificado
        '
        Me.lblEstadoCertificado.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoCertificado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblEstadoCertificado.Name = "lblEstadoCertificado"
        Me.lblEstadoCertificado.Size = New System.Drawing.Size(156, 19)
        Me.lblEstadoCertificado.Text = "VencimientoCertificado:"
        '
        'lblstatusBDprinc
        '
        Me.lblstatusBDprinc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatusBDprinc.ForeColor = System.Drawing.Color.Green
        Me.lblstatusBDprinc.Name = "lblstatusBDprinc"
        Me.lblstatusBDprinc.Size = New System.Drawing.Size(136, 19)
        Me.lblstatusBDprinc.Text = "Base de datos principal:"
        Me.lblstatusBDprinc.ToolTipText = "Nombre de la base de datos principal del sistema"
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
        'listaConexiones
        '
        Me.listaConexiones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.listaConexiones.Image = CType(resources.GetObject("listaConexiones.Image"), System.Drawing.Image)
        Me.listaConexiones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.listaConexiones.Name = "listaConexiones"
        Me.listaConexiones.Size = New System.Drawing.Size(29, 22)
        Me.listaConexiones.Text = "ListaConexiones"
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
        Me.menugral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdclientes, Me.cmdproductos, Me.cmdfacturacion, Me.cmdadministracion, Me.cmdServicios, Me.EmpleadosToolStripMenuItem, Me.ProduccionToolStripMenuItem, Me.cmdPrestamos, Me.SALIRToolStripMenuItem, Me.btnNotificaciones, Me.cmbempresas})
        Me.menugral.Location = New System.Drawing.Point(0, 0)
        Me.menugral.Name = "menugral"
        Me.menugral.Size = New System.Drawing.Size(1270, 40)
        Me.menugral.TabIndex = 15
        Me.menugral.Text = "MenuStrip1"
        '
        'cmdclientes
        '
        Me.cmdclientes.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmdclientes.ForeColor = System.Drawing.Color.White
        Me.cmdclientes.Image = CType(resources.GetObject("cmdclientes.Image"), System.Drawing.Image)
        Me.cmdclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdclientes.Name = "cmdclientes"
        Me.cmdclientes.Size = New System.Drawing.Size(101, 36)
        Me.cmdclientes.Text = "Clientes"
        '
        'cmdproductos
        '
        Me.cmdproductos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ABMProductosToolStripMenuItem, Me.ConsultaDeProductos, Me.ManejoDePreciosToolStripMenuItem, Me.MostradorToolStripMenuItem, Me.StockToolStripMenuItem, Me.EtiquetasEnBlancoToolStripMenuItem})
        Me.cmdproductos.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmdproductos.ForeColor = System.Drawing.Color.White
        Me.cmdproductos.Image = CType(resources.GetObject("cmdproductos.Image"), System.Drawing.Image)
        Me.cmdproductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdproductos.Name = "cmdproductos"
        Me.cmdproductos.Size = New System.Drawing.Size(115, 36)
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
        Me.ABMProductosToolStripMenuItem.Size = New System.Drawing.Size(233, 38)
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
        Me.ConsultaDeProductos.Size = New System.Drawing.Size(233, 38)
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
        Me.ManejoDePreciosToolStripMenuItem.Size = New System.Drawing.Size(233, 38)
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
        Me.MostradorToolStripMenuItem.Size = New System.Drawing.Size(233, 38)
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
        Me.StockToolStripMenuItem.Size = New System.Drawing.Size(233, 38)
        Me.StockToolStripMenuItem.Text = "Stock"
        '
        'EtiquetasEnBlancoToolStripMenuItem
        '
        Me.EtiquetasEnBlancoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.EtiquetasEnBlancoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.EtiquetasEnBlancoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.EtiquetasEnBlancoToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Paper_32px
        Me.EtiquetasEnBlancoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EtiquetasEnBlancoToolStripMenuItem.Name = "EtiquetasEnBlancoToolStripMenuItem"
        Me.EtiquetasEnBlancoToolStripMenuItem.Size = New System.Drawing.Size(233, 38)
        Me.EtiquetasEnBlancoToolStripMenuItem.Text = "Etiquetas en blanco"
        '
        'cmdfacturacion
        '
        Me.cmdfacturacion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaEfacturaToolStripMenuItem, Me.NuevoPedidoToolStripMenuItem, Me.reciboconsfinal, Me.facturabconsfinal, Me.FacturaA, Me.RemitosToolStripMenuItem, Me.ReimpresiónDeComprobantesToolStripMenuItem})
        Me.cmdfacturacion.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmdfacturacion.ForeColor = System.Drawing.Color.White
        Me.cmdfacturacion.Image = CType(resources.GetObject("cmdfacturacion.Image"), System.Drawing.Image)
        Me.cmdfacturacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdfacturacion.Name = "cmdfacturacion"
        Me.cmdfacturacion.Size = New System.Drawing.Size(123, 36)
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
        Me.NuevaEfacturaToolStripMenuItem.Size = New System.Drawing.Size(242, 38)
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
        Me.NuevoPedidoToolStripMenuItem.Size = New System.Drawing.Size(242, 38)
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
        Me.reciboconsfinal.Size = New System.Drawing.Size(242, 38)
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
        Me.facturabconsfinal.Size = New System.Drawing.Size(242, 38)
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
        Me.FacturaA.Size = New System.Drawing.Size(242, 38)
        Me.FacturaA.Text = "Factura A"
        '
        'RemitosToolStripMenuItem
        '
        Me.RemitosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RemitosToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.RemitosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.RemitosToolStripMenuItem.Name = "RemitosToolStripMenuItem"
        Me.RemitosToolStripMenuItem.Size = New System.Drawing.Size(242, 38)
        Me.RemitosToolStripMenuItem.Text = "Remitos"
        '
        'ReimpresiónDeComprobantesToolStripMenuItem
        '
        Me.ReimpresiónDeComprobantesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ReimpresiónDeComprobantesToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReimpresiónDeComprobantesToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ReimpresiónDeComprobantesToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Print_32px
        Me.ReimpresiónDeComprobantesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ReimpresiónDeComprobantesToolStripMenuItem.Name = "ReimpresiónDeComprobantesToolStripMenuItem"
        Me.ReimpresiónDeComprobantesToolStripMenuItem.Size = New System.Drawing.Size(242, 38)
        Me.ReimpresiónDeComprobantesToolStripMenuItem.Text = "Comprobantes emitidos"
        '
        'cmdadministracion
        '
        Me.cmdadministracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdadministracion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformesDeVentasToolStripMenuItem, Me.ContableToolStripMenuItem1, Me.CajaToolStripMenuItem, Me.CajaDiariaToolStripMenuItem, Me.ProveedoresToolStripMenuItem, Me.AgendaDeVencimientosToolStripMenuItem, Me.ConfiguracionDeTerminalToolStripMenuItem})
        Me.cmdadministracion.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmdadministracion.ForeColor = System.Drawing.Color.White
        Me.cmdadministracion.Image = CType(resources.GetObject("cmdadministracion.Image"), System.Drawing.Image)
        Me.cmdadministracion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdadministracion.Name = "cmdadministracion"
        Me.cmdadministracion.Size = New System.Drawing.Size(144, 36)
        Me.cmdadministracion.Text = "Administracion"
        '
        'InformesDeVentasToolStripMenuItem
        '
        Me.InformesDeVentasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.InformesDeVentasToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.InformesDeVentasToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.InformesDeVentasToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Graph_Report_32px
        Me.InformesDeVentasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.InformesDeVentasToolStripMenuItem.Name = "InformesDeVentasToolStripMenuItem"
        Me.InformesDeVentasToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.InformesDeVentasToolStripMenuItem.Text = "Informes"
        '
        'ContableToolStripMenuItem1
        '
        Me.ContableToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ContableToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ContableToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.ContableToolStripMenuItem1.Image = CType(resources.GetObject("ContableToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ContableToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ContableToolStripMenuItem1.Name = "ContableToolStripMenuItem1"
        Me.ContableToolStripMenuItem1.Size = New System.Drawing.Size(252, 38)
        Me.ContableToolStripMenuItem1.Text = "Contable"
        '
        'CajaToolStripMenuItem
        '
        Me.CajaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CajaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CajaToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.CajaToolStripMenuItem.Image = CType(resources.GetObject("CajaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CajaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CajaToolStripMenuItem.Name = "CajaToolStripMenuItem"
        Me.CajaToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.CajaToolStripMenuItem.Text = "Master Cajas"
        '
        'CajaDiariaToolStripMenuItem
        '
        Me.CajaDiariaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CajaDiariaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CajaDiariaToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.CajaDiariaToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Cash_Register_32px
        Me.CajaDiariaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CajaDiariaToolStripMenuItem.Name = "CajaDiariaToolStripMenuItem"
        Me.CajaDiariaToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.CajaDiariaToolStripMenuItem.Text = "Caja Diaria"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProveedoresToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ProveedoresToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ProveedoresToolStripMenuItem.Image = CType(resources.GetObject("ProveedoresToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProveedoresToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'AgendaDeVencimientosToolStripMenuItem
        '
        Me.AgendaDeVencimientosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AgendaDeVencimientosToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.AgendaDeVencimientosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.AgendaDeVencimientosToolStripMenuItem.Image = CType(resources.GetObject("AgendaDeVencimientosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AgendaDeVencimientosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AgendaDeVencimientosToolStripMenuItem.Name = "AgendaDeVencimientosToolStripMenuItem"
        Me.AgendaDeVencimientosToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.AgendaDeVencimientosToolStripMenuItem.Text = "Agenda de vencimientos"
        '
        'ConfiguracionDeTerminalToolStripMenuItem
        '
        Me.ConfiguracionDeTerminalToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ConfiguracionDeTerminalToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ConfiguracionDeTerminalToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ConfiguracionDeTerminalToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Automation_32px
        Me.ConfiguracionDeTerminalToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConfiguracionDeTerminalToolStripMenuItem.Name = "ConfiguracionDeTerminalToolStripMenuItem"
        Me.ConfiguracionDeTerminalToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.ConfiguracionDeTerminalToolStripMenuItem.Text = "Configuracion de terminal"
        '
        'cmdServicios
        '
        Me.cmdServicios.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CLOUDSERVERToolStripMenuItem, Me.TALLERToolStripMenuItem, Me.PublicidadToolStripMenuItem})
        Me.cmdServicios.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmdServicios.ForeColor = System.Drawing.Color.White
        Me.cmdServicios.Image = Global.SIGT__KIGEST.My.Resources.Resources.services_32px
        Me.cmdServicios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdServicios.Name = "cmdServicios"
        Me.cmdServicios.Size = New System.Drawing.Size(105, 36)
        Me.cmdServicios.Text = "Servicios"
        '
        'CLOUDSERVERToolStripMenuItem
        '
        Me.CLOUDSERVERToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CLOUDSERVERToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.CLOUDSERVERToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.CLOUDSERVERToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Cloud_Storage_32px
        Me.CLOUDSERVERToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CLOUDSERVERToolStripMenuItem.Name = "CLOUDSERVERToolStripMenuItem"
        Me.CLOUDSERVERToolStripMenuItem.Size = New System.Drawing.Size(191, 38)
        Me.CLOUDSERVERToolStripMenuItem.Text = "CLOUD SERVER"
        '
        'TALLERToolStripMenuItem
        '
        Me.TALLERToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TALLERToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TALLERToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.TALLERToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Maintenance_32px
        Me.TALLERToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TALLERToolStripMenuItem.Name = "TALLERToolStripMenuItem"
        Me.TALLERToolStripMenuItem.Size = New System.Drawing.Size(191, 38)
        Me.TALLERToolStripMenuItem.Text = "TALLER"
        '
        'PublicidadToolStripMenuItem
        '
        Me.PublicidadToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PublicidadToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.PublicidadToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Commercial_32px
        Me.PublicidadToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PublicidadToolStripMenuItem.Name = "PublicidadToolStripMenuItem"
        Me.PublicidadToolStripMenuItem.Size = New System.Drawing.Size(191, 38)
        Me.PublicidadToolStripMenuItem.Text = "PUBLICIDAD"
        '
        'EmpleadosToolStripMenuItem
        '
        Me.EmpleadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListaDeEmpleadosToolStripMenuItem, Me.LiquidaciónDeSueldosToolStripMenuItem, Me.MantenimientoToolStripMenuItem})
        Me.EmpleadosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.EmpleadosToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.User_Groups_32px
        Me.EmpleadosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EmpleadosToolStripMenuItem.Name = "EmpleadosToolStripMenuItem"
        Me.EmpleadosToolStripMenuItem.Size = New System.Drawing.Size(130, 36)
        Me.EmpleadosToolStripMenuItem.Text = "Empleados"
        '
        'ListaDeEmpleadosToolStripMenuItem
        '
        Me.ListaDeEmpleadosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ListaDeEmpleadosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ListaDeEmpleadosToolStripMenuItem.Name = "ListaDeEmpleadosToolStripMenuItem"
        Me.ListaDeEmpleadosToolStripMenuItem.Size = New System.Drawing.Size(238, 26)
        Me.ListaDeEmpleadosToolStripMenuItem.Text = "Lista de empleados"
        '
        'LiquidaciónDeSueldosToolStripMenuItem
        '
        Me.LiquidaciónDeSueldosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LiquidaciónDeSueldosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.LiquidaciónDeSueldosToolStripMenuItem.Name = "LiquidaciónDeSueldosToolStripMenuItem"
        Me.LiquidaciónDeSueldosToolStripMenuItem.Size = New System.Drawing.Size(238, 26)
        Me.LiquidaciónDeSueldosToolStripMenuItem.Text = "Liquidación de sueldos"
        '
        'MantenimientoToolStripMenuItem
        '
        Me.MantenimientoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MantenimientoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.MantenimientoToolStripMenuItem.Name = "MantenimientoToolStripMenuItem"
        Me.MantenimientoToolStripMenuItem.Size = New System.Drawing.Size(238, 26)
        Me.MantenimientoToolStripMenuItem.Text = "Mantenimiento"
        '
        'ProduccionToolStripMenuItem
        '
        Me.ProduccionToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ProduccionToolStripMenuItem.Name = "ProduccionToolStripMenuItem"
        Me.ProduccionToolStripMenuItem.Size = New System.Drawing.Size(100, 36)
        Me.ProduccionToolStripMenuItem.Text = "Produccion"
        Me.ProduccionToolStripMenuItem.Visible = False
        '
        'cmdPrestamos
        '
        Me.cmdPrestamos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SIMULADORToolStripMenuItem, Me.LISTADOToolStripMenuItem})
        Me.cmdPrestamos.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmdPrestamos.ForeColor = System.Drawing.Color.White
        Me.cmdPrestamos.Image = Global.SIGT__KIGEST.My.Resources.Resources.Bank_Building_32px
        Me.cmdPrestamos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrestamos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.cmdPrestamos.Name = "cmdPrestamos"
        Me.cmdPrestamos.Size = New System.Drawing.Size(117, 36)
        Me.cmdPrestamos.Text = "Prestamos"
        '
        'SIMULADORToolStripMenuItem
        '
        Me.SIMULADORToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SIMULADORToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.SIMULADORToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SIMULADORToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Refund_32px
        Me.SIMULADORToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SIMULADORToolStripMenuItem.Name = "SIMULADORToolStripMenuItem"
        Me.SIMULADORToolStripMenuItem.Size = New System.Drawing.Size(155, 38)
        Me.SIMULADORToolStripMenuItem.Text = "Simulador"
        '
        'LISTADOToolStripMenuItem
        '
        Me.LISTADOToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LISTADOToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LISTADOToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.LISTADOToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Search_Property_32px
        Me.LISTADOToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LISTADOToolStripMenuItem.Name = "LISTADOToolStripMenuItem"
        Me.LISTADOToolStripMenuItem.Size = New System.Drawing.Size(155, 38)
        Me.LISTADOToolStripMenuItem.Text = "Listado"
        '
        'SALIRToolStripMenuItem
        '
        Me.SALIRToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.SALIRToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SALIRToolStripMenuItem.Image = Global.SIGT__KIGEST.My.Resources.Resources.Export_32px_WHITE
        Me.SALIRToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SALIRToolStripMenuItem.Name = "SALIRToolStripMenuItem"
        Me.SALIRToolStripMenuItem.Size = New System.Drawing.Size(88, 36)
        Me.SALIRToolStripMenuItem.Text = "SALIR"
        '
        'btnNotificaciones
        '
        Me.btnNotificaciones.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnNotificaciones.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotificaciones.ForeColor = System.Drawing.Color.White
        Me.btnNotificaciones.Image = Global.SIGT__KIGEST.My.Resources.Resources.alerta_32
        Me.btnNotificaciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNotificaciones.Name = "btnNotificaciones"
        Me.btnNotificaciones.Size = New System.Drawing.Size(44, 36)
        Me.btnNotificaciones.Visible = False
        '
        'cmbempresas
        '
        Me.cmbempresas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmbempresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbempresas.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cmbempresas.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cmbempresas.Name = "cmbempresas"
        Me.cmbempresas.Size = New System.Drawing.Size(250, 36)
        '
        'dtconexiones
        '
        Me.dtconexiones.AllowUserToAddRows = False
        Me.dtconexiones.AllowUserToDeleteRows = False
        Me.dtconexiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtconexiones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtconexiones.BackgroundColor = System.Drawing.Color.White
        Me.dtconexiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtconexiones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtconexiones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtconexiones.Location = New System.Drawing.Point(0, 235)
        Me.dtconexiones.Name = "dtconexiones"
        Me.dtconexiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtconexiones.Size = New System.Drawing.Size(1270, 153)
        Me.dtconexiones.TabIndex = 17
        Me.dtconexiones.Visible = False
        '
        'frmprincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1270, 412)
        Me.Controls.Add(Me.dtconexiones)
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
        CType(Me.dtconexiones, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents EmpleadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdadministracion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProduccionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContableToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdfacturacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevaEfacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoPedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPrestamos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgendaDeVencimientosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents reciboconsfinal As ToolStripMenuItem
    Friend WithEvents facturabconsfinal As ToolStripMenuItem
    Friend WithEvents FacturaA As ToolStripMenuItem
    Friend WithEvents cmdServicios As ToolStripMenuItem
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
    Friend WithEvents SALIRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListaDeEmpleadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LiquidaciónDeSueldosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MantenimientoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents listaConexiones As ToolStripDropDownButton
    Friend WithEvents dtconexiones As DataGridView
    Friend WithEvents PublicidadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblEstadoCertificado As ToolStripStatusLabel
    Friend WithEvents btnNotificaciones As ToolStripMenuItem
    Friend WithEvents cmbempresas As ToolStripComboBox
    Friend WithEvents lblprocesando As ToolStripStatusLabel
End Class
