﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod CLIENTES")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ABM PRODUCTOS")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CONSULTA PRODUCTOS")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MANEJO DE PRECIOS")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MANEJO DE STOCK")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PRODUCCION")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod PRODUCTOS", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FC NOTAS DE CREDITO Y DEBITO")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PRESUPUESTOS")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FX - RECIBO CONS FINAL")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FACTURA B/C LEGAL")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FACTURA A LEGAL")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REMITOS")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("DESACTIVAR STOCK")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("EXTRAS>>", New System.Windows.Forms.TreeNode() {TreeNode14})
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod FACTURACION", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12, TreeNode13, TreeNode15})
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REPORTE DE VENTAS")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REPORTE DE COBRANZAS")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("EXPORTACION A CITI O IVA DIGITAL")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("BALANCES E INFORMES")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REMITOS")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MANEJO DE CHEQUES")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CUENTAS CORRIENTES CLIENTES")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CUENTAS CORRIENTES PROVEEDORES")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PLAN DE CUENTAS")
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("LIBROS (DIARIO Y MAYOR)")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CONTABLE", New System.Windows.Forms.TreeNode() {TreeNode17, TreeNode18, TreeNode19, TreeNode20, TreeNode21, TreeNode22, TreeNode23, TreeNode24, TreeNode25, TreeNode26})
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MASTER CAJAS")
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MOVIMIENTOS DE CAJA")
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CAJA DIARIA", New System.Windows.Forms.TreeNode() {TreeNode29})
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CAJA", New System.Windows.Forms.TreeNode() {TreeNode28, TreeNode30})
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PROVEEDORES")
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("AGENDA DE VENCIMIENTOS")
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CAMBIAR COTIZACION MONEDA")
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("EXTRAS>>>", New System.Windows.Forms.TreeNode() {TreeNode34})
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("VENDEDORES")
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod ADMINISTRACION", New System.Windows.Forms.TreeNode() {TreeNode27, TreeNode31, TreeNode32, TreeNode33, TreeNode35, TreeNode36})
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod TECNICO")
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("IMPRESION DE ETIQUETAS")
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MODULOS KIBIT")
        Dim TreeNode41 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PRESTAMOS")
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ESPECIALES", New System.Windows.Forms.TreeNode() {TreeNode39, TreeNode40, TreeNode41})
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod SUELDOS")
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("KIGEST_FACT_SIGT", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode7, TreeNode16, TreeNode37, TreeNode38, TreeNode42, TreeNode43})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServiciosCloud))
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.dtcloud = New System.Windows.Forms.DataGridView()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.trvmodulos = New System.Windows.Forms.TreeView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblresultados = New System.Windows.Forms.Label()
        Me.lblBusqueda = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtbuscaemp = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Panel12.SuspendLayout()
        CType(Me.dtcloud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
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
        Me.dtcloud.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13, Me.Column1, Me.Column2, Me.Column7, Me.Column9, Me.Column10, Me.Column12, Me.Column6})
        Me.dtcloud.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtcloud.Location = New System.Drawing.Point(321, 0)
        Me.dtcloud.MultiSelect = False
        Me.dtcloud.Name = "dtcloud"
        Me.dtcloud.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtcloud.Size = New System.Drawing.Size(933, 339)
        Me.dtcloud.TabIndex = 71
        '
        'Column13
        '
        Me.Column13.HeaderText = "id"
        Me.Column13.Name = "Column13"
        Me.Column13.Visible = False
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
        'Column7
        '
        Me.Column7.HeaderText = "CLOUD-bd"
        Me.Column7.Name = "Column7"
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
        TreeNode1.Name = "Nodo1"
        TreeNode1.Tag = "1"
        TreeNode1.Text = "Mod CLIENTES"
        TreeNode2.Name = "Nodo3"
        TreeNode2.Tag = "2a"
        TreeNode2.Text = "ABM PRODUCTOS"
        TreeNode3.Name = "Nodo4"
        TreeNode3.Tag = "2b"
        TreeNode3.Text = "CONSULTA PRODUCTOS"
        TreeNode4.Name = "Nodo5"
        TreeNode4.Tag = "2c"
        TreeNode4.Text = "MANEJO DE PRECIOS"
        TreeNode5.Name = "Nodo7"
        TreeNode5.Tag = "2d"
        TreeNode5.Text = "MANEJO DE STOCK"
        TreeNode6.Name = "Nodo0"
        TreeNode6.Tag = "2e"
        TreeNode6.Text = "PRODUCCION"
        TreeNode7.Name = "Nodo2"
        TreeNode7.Tag = "2"
        TreeNode7.Text = "Mod PRODUCTOS"
        TreeNode8.Name = "Nodo9"
        TreeNode8.Tag = "3a"
        TreeNode8.Text = "FC NOTAS DE CREDITO Y DEBITO"
        TreeNode9.Name = "Nodo10"
        TreeNode9.Tag = "3b"
        TreeNode9.Text = "PRESUPUESTOS"
        TreeNode10.Name = "Nodo11"
        TreeNode10.Tag = "3c"
        TreeNode10.Text = "FX - RECIBO CONS FINAL"
        TreeNode11.Name = "Nodo12"
        TreeNode11.Tag = "3d"
        TreeNode11.Text = "FACTURA B/C LEGAL"
        TreeNode12.Name = "Nodo0"
        TreeNode12.Tag = "3e"
        TreeNode12.Text = "FACTURA A LEGAL"
        TreeNode13.Name = "Nodo0"
        TreeNode13.Tag = "3f"
        TreeNode13.Text = "REMITOS"
        TreeNode14.Name = "Nodo1"
        TreeNode14.Tag = "3z"
        TreeNode14.Text = "DESACTIVAR STOCK"
        TreeNode15.Name = "Nodo0"
        TreeNode15.Text = "EXTRAS>>"
        TreeNode16.Name = "Nodo8"
        TreeNode16.Tag = "3"
        TreeNode16.Text = "Mod FACTURACION"
        TreeNode17.Name = "Nodo15"
        TreeNode17.Tag = "4aa"
        TreeNode17.Text = "REPORTE DE VENTAS"
        TreeNode18.Name = "Nodo16"
        TreeNode18.Tag = "4ab"
        TreeNode18.Text = "REPORTE DE COBRANZAS"
        TreeNode19.Name = "Nodo0"
        TreeNode19.Tag = "4aj"
        TreeNode19.Text = "EXPORTACION A CITI O IVA DIGITAL"
        TreeNode20.Name = "Nodo17"
        TreeNode20.Tag = "4ac"
        TreeNode20.Text = "BALANCES E INFORMES"
        TreeNode21.Name = "Nodo18"
        TreeNode21.Tag = "4ad"
        TreeNode21.Text = "REMITOS"
        TreeNode22.Name = "Nodo19"
        TreeNode22.Tag = "4ae-4af"
        TreeNode22.Text = "MANEJO DE CHEQUES"
        TreeNode23.Name = "Nodo20"
        TreeNode23.Tag = "4ag-4ah"
        TreeNode23.Text = "CUENTAS CORRIENTES CLIENTES"
        TreeNode24.Name = "Nodo21"
        TreeNode24.Tag = "4ai"
        TreeNode24.Text = "CUENTAS CORRIENTES PROVEEDORES"
        TreeNode25.Name = "Nodo1"
        TreeNode25.Tag = "4ak"
        TreeNode25.Text = "PLAN DE CUENTAS"
        TreeNode26.Name = "Nodo2"
        TreeNode26.Tag = "4ak"
        TreeNode26.Text = "LIBROS (DIARIO Y MAYOR)"
        TreeNode27.Name = "Nodo14"
        TreeNode27.Tag = "4a"
        TreeNode27.Text = "CONTABLE"
        TreeNode28.Name = "Nodo23"
        TreeNode28.Tag = "4ba"
        TreeNode28.Text = "MASTER CAJAS"
        TreeNode29.Name = "Nodo0"
        TreeNode29.Tag = "4bba"
        TreeNode29.Text = "MOVIMIENTOS DE CAJA"
        TreeNode30.Name = "Nodo25"
        TreeNode30.Tag = "4bb"
        TreeNode30.Text = "CAJA DIARIA"
        TreeNode31.Name = "Nodo22"
        TreeNode31.Tag = ""
        TreeNode31.Text = "CAJA"
        TreeNode32.Name = "Nodo26"
        TreeNode32.Tag = "4c"
        TreeNode32.Text = "PROVEEDORES"
        TreeNode33.Name = "Nodo27"
        TreeNode33.Tag = "4d"
        TreeNode33.Text = "AGENDA DE VENCIMIENTOS"
        TreeNode34.Name = "Nodo1"
        TreeNode34.Tag = "4ea"
        TreeNode34.Text = "CAMBIAR COTIZACION MONEDA"
        TreeNode35.Name = "Nodo0"
        TreeNode35.Text = "EXTRAS>>>"
        TreeNode36.Name = "Nodo0"
        TreeNode36.Tag = "4f"
        TreeNode36.Text = "VENDEDORES"
        TreeNode37.Name = "Nodo13"
        TreeNode37.Tag = "4"
        TreeNode37.Text = "Mod ADMINISTRACION"
        TreeNode38.Name = "Nodo28"
        TreeNode38.Tag = "5"
        TreeNode38.Text = "Mod TECNICO"
        TreeNode39.Name = "Nodo30"
        TreeNode39.Tag = "AR01"
        TreeNode39.Text = "IMPRESION DE ETIQUETAS"
        TreeNode40.Name = "Nodo0"
        TreeNode40.Tag = "KIBIT"
        TreeNode40.Text = "MODULOS KIBIT"
        TreeNode41.Name = "Nodo0"
        TreeNode41.Tag = "RYM"
        TreeNode41.Text = "PRESTAMOS"
        TreeNode42.Name = "Nodo29"
        TreeNode42.Text = "ESPECIALES"
        TreeNode43.Name = "Nodo1"
        TreeNode43.Tag = "6"
        TreeNode43.Text = "Mod SUELDOS"
        TreeNode44.Name = "Nodo0"
        TreeNode44.Tag = "KIGEST_FACT_SIGT"
        TreeNode44.Text = "KIGEST_FACT_SIGT"
        Me.trvmodulos.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode44})
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
        Me.txtbuscaemp.Size = New System.Drawing.Size(561, 20)
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
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel20.Controls.Add(Me.GroupBox5)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel20.Location = New System.Drawing.Point(0, 438)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(1254, 155)
        Me.Panel20.TabIndex = 89
        Me.Panel20.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button27)
        Me.GroupBox5.Controls.Add(Me.TextBox7)
        Me.GroupBox5.Controls.Add(Me.Label76)
        Me.GroupBox5.Controls.Add(Me.Label75)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1254, 155)
        Me.GroupBox5.TabIndex = 66
        Me.GroupBox5.TabStop = False
        '
        'Button27
        '
        Me.Button27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button27.ForeColor = System.Drawing.Color.White
        Me.Button27.Image = CType(resources.GetObject("Button27.Image"), System.Drawing.Image)
        Me.Button27.Location = New System.Drawing.Point(1168, 49)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(80, 100)
        Me.Button27.TabIndex = 86
        Me.Button27.Text = "Guardar"
        Me.Button27.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button27.UseVisualStyleBackColor = True
        '
        'TextBox7
        '
        Me.TextBox7.Enabled = False
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(9, 39)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(559, 35)
        Me.TextBox7.TabIndex = 80
        Me.TextBox7.Text = "0"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.White
        Me.Label76.Location = New System.Drawing.Point(2, 20)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(152, 16)
        Me.Label76.TabIndex = 79
        Me.Label76.Text = "Nombre de la cuenta"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label75.Location = New System.Drawing.Point(6, 0)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(188, 16)
        Me.Label75.TabIndex = 78
        Me.Label75.Text = "Mantenimiento de cuentas"
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
        Me.GroupBox5.PerformLayout()
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
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
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
    Friend WithEvents Button27 As Button
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label76 As Label
    Friend WithEvents Label75 As Label
End Class
