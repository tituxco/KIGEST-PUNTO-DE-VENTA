<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServiciosCloud
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode58 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod CLIENTES")
        Dim TreeNode59 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ABM PRODUCTOS")
        Dim TreeNode60 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CONSULTA PRODUCTOS")
        Dim TreeNode61 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MANEJO DE PRECIOS")
        Dim TreeNode62 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MANEJO DE STOCK")
        Dim TreeNode63 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PRODUCCION")
        Dim TreeNode64 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod PRODUCTOS", New System.Windows.Forms.TreeNode() {TreeNode59, TreeNode60, TreeNode61, TreeNode62, TreeNode63})
        Dim TreeNode65 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FC NOTAS DE CREDITO Y DEBITO")
        Dim TreeNode66 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LISTA DE CARGA")
        Dim TreeNode67 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PRESUPUESTOS", New System.Windows.Forms.TreeNode() {TreeNode66})
        Dim TreeNode68 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FX - RECIBO CONS FINAL")
        Dim TreeNode69 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FACTURA B/C LEGAL")
        Dim TreeNode70 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FACTURA A LEGAL")
        Dim TreeNode71 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REMITOS")
        Dim TreeNode72 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("DESACTIVAR STOCK")
        Dim TreeNode73 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("EXTRAS>>", New System.Windows.Forms.TreeNode() {TreeNode72})
        Dim TreeNode74 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod FACTURACION", New System.Windows.Forms.TreeNode() {TreeNode65, TreeNode67, TreeNode68, TreeNode69, TreeNode70, TreeNode71, TreeNode73})
        Dim TreeNode75 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REPORTE DE VENTAS")
        Dim TreeNode76 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REPORTE DE COBRANZAS")
        Dim TreeNode77 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("EXPORTACION A CITI O IVA DIGITAL")
        Dim TreeNode78 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("BALANCES E INFORMES")
        Dim TreeNode79 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REMITOS")
        Dim TreeNode80 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MANEJO DE CHEQUES")
        Dim TreeNode81 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CUENTAS CORRIENTES CLIENTES")
        Dim TreeNode82 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CUENTAS CORRIENTES PROVEEDORES")
        Dim TreeNode83 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PLAN DE CUENTAS")
        Dim TreeNode84 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LIBROS (DIARIO Y MAYOR)")
        Dim TreeNode85 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ASIENTOS CONTABLES")
        Dim TreeNode86 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CONTABLE", New System.Windows.Forms.TreeNode() {TreeNode75, TreeNode76, TreeNode77, TreeNode78, TreeNode79, TreeNode80, TreeNode81, TreeNode82, TreeNode83, TreeNode84, TreeNode85})
        Dim TreeNode87 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MASTER CAJAS")
        Dim TreeNode88 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MOVIMIENTOS DE CAJA")
        Dim TreeNode89 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CAJA DIARIA", New System.Windows.Forms.TreeNode() {TreeNode88})
        Dim TreeNode90 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CAJA", New System.Windows.Forms.TreeNode() {TreeNode87, TreeNode89})
        Dim TreeNode91 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PROVEEDORES")
        Dim TreeNode92 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("AGENDA DE VENCIMIENTOS")
        Dim TreeNode93 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CAMBIAR COTIZACION MONEDA")
        Dim TreeNode94 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ELIMINAR COMPROBANTES Y ASIENTOS")
        Dim TreeNode95 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("EXTRAS>>>", New System.Windows.Forms.TreeNode() {TreeNode93, TreeNode94})
        Dim TreeNode96 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("VENDEDORES")
        Dim TreeNode97 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HISTORIAL PUBLICIDAD")
        Dim TreeNode98 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HISTORIAL VENTAS")
        Dim TreeNode99 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HISTORIALES E INFORMES", New System.Windows.Forms.TreeNode() {TreeNode97, TreeNode98})
        Dim TreeNode100 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod ADMINISTRACION", New System.Windows.Forms.TreeNode() {TreeNode86, TreeNode90, TreeNode91, TreeNode92, TreeNode95, TreeNode96, TreeNode99})
        Dim TreeNode101 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("IMPRESION DE ETIQUETAS")
        Dim TreeNode102 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MODULOS KIBIT")
        Dim TreeNode103 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PRESTAMOS")
        Dim TreeNode104 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("VENTANA OPERADOR")
        Dim TreeNode105 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PUBLICIDAD", New System.Windows.Forms.TreeNode() {TreeNode104})
        Dim TreeNode106 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("TECNICO")
        Dim TreeNode107 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("COMBUSTIBLES/IMPUESTOS EXTRAS")
        Dim TreeNode108 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ESPECIALES-SERVICIOS", New System.Windows.Forms.TreeNode() {TreeNode101, TreeNode102, TreeNode103, TreeNode105, TreeNode106, TreeNode107})
        Dim TreeNode109 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod SUELDOS")
        Dim TreeNode110 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CONFIGURAR TERMINAL")
        Dim TreeNode111 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CONFIGURACIONES VARIAS")
        Dim TreeNode112 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HISTORIAL Y CONFIGURACION DE USUARIOS")
        Dim TreeNode113 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod CONFIGURACIONES", New System.Windows.Forms.TreeNode() {TreeNode110, TreeNode111, TreeNode112})
        Dim TreeNode114 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("KIGEST_FACT_SIGT", New System.Windows.Forms.TreeNode() {TreeNode58, TreeNode64, TreeNode74, TreeNode100, TreeNode108, TreeNode109, TreeNode113})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServiciosCloud))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.dtcloud = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DBClie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trvmodulos = New System.Windows.Forms.TreeView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblresultados = New System.Windows.Forms.Label()
        Me.lblBusqueda = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtbuscaemp = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvLog = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.txtprefijobd = New System.Windows.Forms.TextBox()
        Me.rdseleccionadas = New System.Windows.Forms.RadioButton()
        Me.rdprefijo = New System.Windows.Forms.RadioButton()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtsentencias = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Panel12.SuspendLayout()
        CType(Me.dtcloud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.dtcloud)
        Me.Panel12.Controls.Add(Me.trvmodulos)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(1254, 339)
        Me.Panel12.TabIndex = 71
        '
        'dtcloud
        '
        Me.dtcloud.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtcloud.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dtcloud.BackgroundColor = System.Drawing.Color.White
        Me.dtcloud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtcloud.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Column1, Me.Column2, Me.DBClie, Me.Column9, Me.Column10, Me.Column12, Me.Column6})
        Me.dtcloud.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtcloud.Location = New System.Drawing.Point(321, 0)
        Me.dtcloud.MultiSelect = False
        Me.dtcloud.Name = "dtcloud"
        Me.dtcloud.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtcloud.Size = New System.Drawing.Size(933, 339)
        Me.dtcloud.TabIndex = 71
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cliente"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Sistema"
        Me.Column2.Name = "Column2"
        '
        'DBClie
        '
        Me.DBClie.HeaderText = "CLOUD-bd"
        Me.DBClie.Name = "DBClie"
        '
        'Column9
        '
        Me.Column9.HeaderText = "AUTH-Usuario"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "AUTH-Clave"
        Me.Column10.Name = "Column10"
        '
        'Column12
        '
        Me.Column12.FillWeight = 300.0!
        Me.Column12.HeaderText = "Modulo"
        Me.Column12.Name = "Column12"
        Me.Column12.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "Autorizado"
        Me.Column6.Name = "Column6"
        '
        'trvmodulos
        '
        Me.trvmodulos.CheckBoxes = True
        Me.trvmodulos.Dock = System.Windows.Forms.DockStyle.Left
        Me.trvmodulos.Location = New System.Drawing.Point(0, 0)
        Me.trvmodulos.Name = "trvmodulos"
        TreeNode58.Name = "Nodo1"
        TreeNode58.Tag = "1"
        TreeNode58.Text = "Mod CLIENTES"
        TreeNode59.Name = "Nodo3"
        TreeNode59.Tag = "2a"
        TreeNode59.Text = "ABM PRODUCTOS"
        TreeNode60.Name = "Nodo4"
        TreeNode60.Tag = "2b"
        TreeNode60.Text = "CONSULTA PRODUCTOS"
        TreeNode61.Name = "Nodo5"
        TreeNode61.Tag = "2c"
        TreeNode61.Text = "MANEJO DE PRECIOS"
        TreeNode62.Name = "Nodo7"
        TreeNode62.Tag = "2d"
        TreeNode62.Text = "MANEJO DE STOCK"
        TreeNode63.Name = "Nodo0"
        TreeNode63.Tag = "2e"
        TreeNode63.Text = "PRODUCCION"
        TreeNode64.Name = "Nodo2"
        TreeNode64.Tag = "2"
        TreeNode64.Text = "Mod PRODUCTOS"
        TreeNode65.Name = "Nodo9"
        TreeNode65.Tag = "3a"
        TreeNode65.Text = "FC NOTAS DE CREDITO Y DEBITO"
        TreeNode66.Name = "Nodo0"
        TreeNode66.Tag = "3b-AR01"
        TreeNode66.Text = "LISTA DE CARGA"
        TreeNode67.Name = "Nodo10"
        TreeNode67.Tag = "3b"
        TreeNode67.Text = "PRESUPUESTOS"
        TreeNode68.Name = "Nodo11"
        TreeNode68.Tag = "3c"
        TreeNode68.Text = "FX - RECIBO CONS FINAL"
        TreeNode69.Name = "Nodo12"
        TreeNode69.Tag = "3d"
        TreeNode69.Text = "FACTURA B/C LEGAL"
        TreeNode70.Name = "Nodo0"
        TreeNode70.Tag = "3e"
        TreeNode70.Text = "FACTURA A LEGAL"
        TreeNode71.Name = "Nodo0"
        TreeNode71.Tag = "3f"
        TreeNode71.Text = "REMITOS"
        TreeNode72.Name = "Nodo1"
        TreeNode72.Tag = "3z"
        TreeNode72.Text = "DESACTIVAR STOCK"
        TreeNode73.Name = "Nodo0"
        TreeNode73.Text = "EXTRAS>>"
        TreeNode74.Name = "Nodo8"
        TreeNode74.Tag = "3"
        TreeNode74.Text = "Mod FACTURACION"
        TreeNode75.Name = "Nodo15"
        TreeNode75.Tag = "4aa"
        TreeNode75.Text = "REPORTE DE VENTAS"
        TreeNode76.Name = "Nodo16"
        TreeNode76.Tag = "4ab"
        TreeNode76.Text = "REPORTE DE COBRANZAS"
        TreeNode77.Name = "Nodo0"
        TreeNode77.Tag = "4aj"
        TreeNode77.Text = "EXPORTACION A CITI O IVA DIGITAL"
        TreeNode78.Name = "Nodo17"
        TreeNode78.Tag = "4ac"
        TreeNode78.Text = "BALANCES E INFORMES"
        TreeNode79.Name = "Nodo18"
        TreeNode79.Tag = "4ad"
        TreeNode79.Text = "REMITOS"
        TreeNode80.Name = "Nodo19"
        TreeNode80.Tag = "4ae-4af"
        TreeNode80.Text = "MANEJO DE CHEQUES"
        TreeNode81.Name = "Nodo20"
        TreeNode81.Tag = "4ag-4ah"
        TreeNode81.Text = "CUENTAS CORRIENTES CLIENTES"
        TreeNode82.Name = "Nodo21"
        TreeNode82.Tag = "4ai"
        TreeNode82.Text = "CUENTAS CORRIENTES PROVEEDORES"
        TreeNode83.Name = "Nodo1"
        TreeNode83.Tag = "4ak"
        TreeNode83.Text = "PLAN DE CUENTAS"
        TreeNode84.Name = "Nodo2"
        TreeNode84.Tag = "4ak"
        TreeNode84.Text = "LIBROS (DIARIO Y MAYOR)"
        TreeNode85.Name = "Nodo0"
        TreeNode85.Tag = "4al"
        TreeNode85.Text = "ASIENTOS CONTABLES"
        TreeNode86.Name = "Nodo14"
        TreeNode86.Tag = "4a"
        TreeNode86.Text = "CONTABLE"
        TreeNode87.Name = "Nodo23"
        TreeNode87.Tag = "4ba"
        TreeNode87.Text = "MASTER CAJAS"
        TreeNode88.Name = "Nodo0"
        TreeNode88.Tag = "4bba"
        TreeNode88.Text = "MOVIMIENTOS DE CAJA"
        TreeNode89.Name = "Nodo25"
        TreeNode89.Tag = "4bb"
        TreeNode89.Text = "CAJA DIARIA"
        TreeNode90.Name = "Nodo22"
        TreeNode90.Tag = ""
        TreeNode90.Text = "CAJA"
        TreeNode91.Name = "Nodo26"
        TreeNode91.Tag = "4c"
        TreeNode91.Text = "PROVEEDORES"
        TreeNode92.Name = "Nodo27"
        TreeNode92.Tag = "4d"
        TreeNode92.Text = "AGENDA DE VENCIMIENTOS"
        TreeNode93.Name = "Nodo1"
        TreeNode93.Tag = "4ea"
        TreeNode93.Text = "CAMBIAR COTIZACION MONEDA"
        TreeNode94.Name = "Nodo0"
        TreeNode94.Tag = "SUPERADMIN"
        TreeNode94.Text = "ELIMINAR COMPROBANTES Y ASIENTOS"
        TreeNode95.Name = "Nodo0"
        TreeNode95.Text = "EXTRAS>>>"
        TreeNode96.Name = "Nodo0"
        TreeNode96.Tag = "4f"
        TreeNode96.Text = "VENDEDORES"
        TreeNode97.Name = "Nodo0"
        TreeNode97.Tag = "4g"
        TreeNode97.Text = "HISTORIAL PUBLICIDAD"
        TreeNode98.Name = "Nodo1"
        TreeNode98.Tag = "4h"
        TreeNode98.Text = "HISTORIAL VENTAS"
        TreeNode99.Name = "Nodo0"
        TreeNode99.Text = "HISTORIALES E INFORMES"
        TreeNode100.Name = "Nodo13"
        TreeNode100.Tag = "4"
        TreeNode100.Text = "Mod ADMINISTRACION"
        TreeNode101.Name = "Nodo30"
        TreeNode101.Tag = "AR01"
        TreeNode101.Text = "IMPRESION DE ETIQUETAS"
        TreeNode102.Name = "Nodo0"
        TreeNode102.Tag = "5KIBIT"
        TreeNode102.Text = "MODULOS KIBIT"
        TreeNode103.Name = "Nodo0"
        TreeNode103.Tag = "5RYM"
        TreeNode103.Text = "PRESTAMOS"
        TreeNode104.Name = "Nodo0"
        TreeNode104.Tag = "5PUBLICIDAD-OPERADORRAD"
        TreeNode104.Text = "VENTANA OPERADOR"
        TreeNode105.Name = "Nodo0"
        TreeNode105.Tag = "5PUBLICIDAD"
        TreeNode105.Text = "PUBLICIDAD"
        TreeNode106.Name = "Nodo28"
        TreeNode106.Tag = "5TALLER"
        TreeNode106.Text = "TECNICO"
        TreeNode107.Name = "Nodo0"
        TreeNode107.Tag = "IMPEXTRA"
        TreeNode107.Text = "COMBUSTIBLES/IMPUESTOS EXTRAS"
        TreeNode108.Name = "Nodo29"
        TreeNode108.Tag = "5"
        TreeNode108.Text = "ESPECIALES-SERVICIOS"
        TreeNode109.Name = "Nodo1"
        TreeNode109.Tag = "6"
        TreeNode109.Text = "Mod SUELDOS"
        TreeNode110.Name = "Nodo2"
        TreeNode110.Tag = "CONFTERM"
        TreeNode110.Text = "CONFIGURAR TERMINAL"
        TreeNode111.Name = "Nodo3"
        TreeNode111.Tag = "CONFVAR"
        TreeNode111.Text = "CONFIGURACIONES VARIAS"
        TreeNode112.Name = "Nodo0"
        TreeNode112.Tag = "CONFUSER"
        TreeNode112.Text = "HISTORIAL Y CONFIGURACION DE USUARIOS"
        TreeNode113.Name = "Nodo1"
        TreeNode113.Tag = "CONF"
        TreeNode113.Text = "Mod CONFIGURACIONES"
        TreeNode114.Name = "Nodo0"
        TreeNode114.Tag = "KIGEST_FACT_SIGT"
        TreeNode114.Text = "KIGEST_FACT_SIGT"
        Me.trvmodulos.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode114})
        Me.trvmodulos.Size = New System.Drawing.Size(321, 339)
        Me.trvmodulos.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel12)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 99)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1254, 339)
        Me.Panel1.TabIndex = 4
        '
        'lblresultados
        '
        Me.lblresultados.AutoSize = True
        Me.lblresultados.BackColor = System.Drawing.Color.Transparent
        Me.lblresultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblresultados.ForeColor = System.Drawing.Color.White
        Me.lblresultados.Location = New System.Drawing.Point(3, 79)
        Me.lblresultados.Name = "lblresultados"
        Me.lblresultados.Size = New System.Drawing.Size(0, 20)
        Me.lblresultados.TabIndex = 88
        '
        'lblBusqueda
        '
        Me.lblBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusqueda.ForeColor = System.Drawing.Color.White
        Me.lblBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.lblBusqueda.Name = "lblBusqueda"
        Me.lblBusqueda.Size = New System.Drawing.Size(663, 45)
        Me.lblBusqueda.TabIndex = 77
        Me.lblBusqueda.Text = "EDITAR SERVICIOS DE CLOUDING Y ACCESO A MODULOS DE SISTEMA"
        Me.lblBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel11.Controls.Add(Me.Button7)
        Me.Panel11.Controls.Add(Me.Button6)
        Me.Panel11.Controls.Add(Me.Button5)
        Me.Panel11.Controls.Add(Me.Button3)
        Me.Panel11.Controls.Add(Me.Button2)
        Me.Panel11.Controls.Add(Me.Label17)
        Me.Panel11.Controls.Add(Me.txtbuscaemp)
        Me.Panel11.Controls.Add(Me.Button1)
        Me.Panel11.Controls.Add(Me.lblresultados)
        Me.Panel11.Controls.Add(Me.lblBusqueda)
        Me.Panel11.Controls.Add(Me.cmdbuscar)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1254, 99)
        Me.Panel11.TabIndex = 3
        '
        'Button6
        '
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Image = Global.SIGT__KIGEST.My.Resources.Resources.forward_message_64px
        Me.Button6.Location = New System.Drawing.Point(702, 0)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(92, 99)
        Me.Button6.TabIndex = 95
        Me.Button6.Text = "Mensaje"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Image = Global.SIGT__KIGEST.My.Resources.Resources.business_chat_64px
        Me.Button5.Location = New System.Drawing.Point(794, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(92, 99)
        Me.Button5.TabIndex = 94
        Me.Button5.Text = "Deudor"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = Global.SIGT__KIGEST.My.Resources.Resources.duplicate_contacts_64px
        Me.Button3.Location = New System.Drawing.Point(886, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(92, 99)
        Me.Button3.TabIndex = 93
        Me.Button3.Text = "Duplicar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = Global.SIGT__KIGEST.My.Resources.Resources.Add_User_Male_64px
        Me.Button2.Location = New System.Drawing.Point(978, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 99)
        Me.Button2.TabIndex = 92
        Me.Button2.Text = "Agregar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(322, 76)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(113, 13)
        Me.Label17.TabIndex = 91
        Me.Label17.Text = "BUSCAR CLIENTE"
        '
        'txtbuscaemp
        '
        Me.txtbuscaemp.Location = New System.Drawing.Point(441, 73)
        Me.txtbuscaemp.Name = "txtbuscaemp"
        Me.txtbuscaemp.Size = New System.Drawing.Size(222, 20)
        Me.txtbuscaemp.TabIndex = 90
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1070, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 99)
        Me.Button1.TabIndex = 89
        Me.Button1.Text = "Guardar privilegios"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdbuscar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscar.ForeColor = System.Drawing.Color.White
        Me.cmdbuscar.Image = CType(resources.GetObject("cmdbuscar.Image"), System.Drawing.Image)
        Me.cmdbuscar.Location = New System.Drawing.Point(1162, 0)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(92, 99)
        Me.cmdbuscar.TabIndex = 74
        Me.cmdbuscar.Text = "Buscar"
        Me.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdbuscar.UseVisualStyleBackColor = True
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel20.Controls.Add(Me.GroupBox5)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel20.Location = New System.Drawing.Point(0, 438)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(1254, 155)
        Me.Panel20.TabIndex = 89
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.GroupBox2)
        Me.GroupBox5.Controls.Add(Me.GroupBox1)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1254, 155)
        Me.GroupBox5.TabIndex = 66
        Me.GroupBox5.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvLog)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(422, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(832, 152)
        Me.GroupBox2.TabIndex = 88
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Log de usuarios"
        '
        'dgvLog
        '
        Me.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvLog.BackgroundColor = System.Drawing.Color.White
        Me.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLog.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLog.Location = New System.Drawing.Point(3, 16)
        Me.dgvLog.MultiSelect = False
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvLog.Size = New System.Drawing.Size(826, 133)
        Me.dgvLog.TabIndex = 72
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Controls.Add(Me.txtprefijobd)
        Me.GroupBox1.Controls.Add(Me.rdseleccionadas)
        Me.GroupBox1.Controls.Add(Me.rdprefijo)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.txtsentencias)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(1, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(410, 152)
        Me.GroupBox1.TabIndex = 87
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Normalizacion de base de datos"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(12, 15)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 100)
        Me.ListBox1.TabIndex = 92
        '
        'txtprefijobd
        '
        Me.txtprefijobd.Location = New System.Drawing.Point(157, 128)
        Me.txtprefijobd.Name = "txtprefijobd"
        Me.txtprefijobd.Size = New System.Drawing.Size(137, 20)
        Me.txtprefijobd.TabIndex = 91
        '
        'rdseleccionadas
        '
        Me.rdseleccionadas.AutoSize = True
        Me.rdseleccionadas.Checked = True
        Me.rdseleccionadas.Location = New System.Drawing.Point(6, 130)
        Me.rdseleccionadas.Name = "rdseleccionadas"
        Me.rdseleccionadas.Size = New System.Drawing.Size(90, 17)
        Me.rdseleccionadas.TabIndex = 11
        Me.rdseleccionadas.TabStop = True
        Me.rdseleccionadas.Text = "Seleccionada"
        Me.rdseleccionadas.UseVisualStyleBackColor = True
        '
        'rdprefijo
        '
        Me.rdprefijo.AutoSize = True
        Me.rdprefijo.Location = New System.Drawing.Point(107, 130)
        Me.rdprefijo.Name = "rdprefijo"
        Me.rdprefijo.Size = New System.Drawing.Size(54, 17)
        Me.rdprefijo.TabIndex = 10
        Me.rdprefijo.Text = "Prefijo"
        Me.rdprefijo.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(325, 125)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Ejecutar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtsentencias
        '
        Me.txtsentencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsentencias.Location = New System.Drawing.Point(138, 15)
        Me.txtsentencias.Multiline = True
        Me.txtsentencias.Name = "txtsentencias"
        Me.txtsentencias.Size = New System.Drawing.Size(263, 108)
        Me.txtsentencias.TabIndex = 8
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cliente"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 147
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Sistema"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 149
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "CLOUD-bd"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 148
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "AUTH-Usuario"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 148
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "AUTH-Clave"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 149
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.FillWeight = 300.0!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Modulo"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Autorizado"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 148
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(219, 49)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 96
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'frmServiciosCloud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1254, 593)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel20)
        Me.Name = "frmServiciosCloud"
        Me.Text = "frmServiciosCloud"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel12.ResumeLayout(False)
        CType(Me.dtcloud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel20.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblresultados As Label
    Friend WithEvents lblBusqueda As Label
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents trvmodulos As TreeView
    Friend WithEvents dtcloud As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents txtbuscaemp As TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents Panel20 As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtprefijobd As TextBox
    Friend WithEvents rdseleccionadas As RadioButton
    Friend WithEvents rdprefijo As RadioButton
    Friend WithEvents Button4 As Button
    Friend WithEvents txtsentencias As TextBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button3 As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents DBClie As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvLog As DataGridView
    Friend WithEvents Button7 As Button
End Class
