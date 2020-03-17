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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod CLIENTES")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ABM PRODUCTOS")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CONSULTA PRODUCTOS")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MANEJO DE PRECIOS")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MANEJO DE STOCK")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod PRODUCTOS", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode3, TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FC NOTAS DE CREDITO Y DEBITO")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PRESUPUESTOS")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FX - RECIBO CONS FINAL")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FACTURA B/C LEGAL")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FACTURA A LEGAL")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod FACTURACION", New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REPORTE DE VENTAS")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REPORTE DE COBRANZAS")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("BALANCES")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("REMITOS")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MANEJO DE CHEQUES")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CUENTAS CORRIENTES CLIENTES")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CUENTAS CORREINTES PROVEEDORES")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CONTABLE", New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode14, TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19})
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MASTER CAJAS")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CAJA DIARIA")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CAJA", New System.Windows.Forms.TreeNode() {TreeNode21, TreeNode22})
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PROVEEDORES")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("AGENDA DE VENCIMIENTOS")
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod ADMINISTRACION", New System.Windows.Forms.TreeNode() {TreeNode20, TreeNode23, TreeNode24, TreeNode25})
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mod TECNICO")
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("IMPRESION DE ETIQUETAS")
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("MODULOS KIBIT")
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ESPECIALES", New System.Windows.Forms.TreeNode() {TreeNode28, TreeNode29})
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("KIGEST_FACT_SIGT", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode6, TreeNode12, TreeNode26, TreeNode27, TreeNode30})
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.Panel12.SuspendLayout()
        CType(Me.dtcloud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.dtcloud)
        Me.Panel12.Controls.Add(Me.trvmodulos)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(1254, 494)
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
        Me.dtcloud.Size = New System.Drawing.Size(933, 494)
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
        TreeNode6.Name = "Nodo2"
        TreeNode6.Tag = "2"
        TreeNode6.Text = "Mod PRODUCTOS"
        TreeNode7.Name = "Nodo9"
        TreeNode7.Tag = "3a"
        TreeNode7.Text = "FC NOTAS DE CREDITO Y DEBITO"
        TreeNode8.Name = "Nodo10"
        TreeNode8.Tag = "3b"
        TreeNode8.Text = "PRESUPUESTOS"
        TreeNode9.Name = "Nodo11"
        TreeNode9.Tag = "3c"
        TreeNode9.Text = "FX - RECIBO CONS FINAL"
        TreeNode10.Name = "Nodo12"
        TreeNode10.Tag = "3d"
        TreeNode10.Text = "FACTURA B/C LEGAL"
        TreeNode11.Name = "Nodo0"
        TreeNode11.Tag = "3e"
        TreeNode11.Text = "FACTURA A LEGAL"
        TreeNode12.Name = "Nodo8"
        TreeNode12.Tag = "3"
        TreeNode12.Text = "Mod FACTURACION"
        TreeNode13.Name = "Nodo15"
        TreeNode13.Tag = "4aa"
        TreeNode13.Text = "REPORTE DE VENTAS"
        TreeNode14.Name = "Nodo16"
        TreeNode14.Tag = "4ab"
        TreeNode14.Text = "REPORTE DE COBRANZAS"
        TreeNode15.Name = "Nodo17"
        TreeNode15.Tag = "4ac"
        TreeNode15.Text = "BALANCES"
        TreeNode16.Name = "Nodo18"
        TreeNode16.Tag = "4ad"
        TreeNode16.Text = "REMITOS"
        TreeNode17.Name = "Nodo19"
        TreeNode17.Tag = "4ae-4af"
        TreeNode17.Text = "MANEJO DE CHEQUES"
        TreeNode18.Name = "Nodo20"
        TreeNode18.Tag = "4ag-4ah"
        TreeNode18.Text = "CUENTAS CORRIENTES CLIENTES"
        TreeNode19.Name = "Nodo21"
        TreeNode19.Tag = "4ai"
        TreeNode19.Text = "CUENTAS CORREINTES PROVEEDORES"
        TreeNode20.Name = "Nodo14"
        TreeNode20.Tag = "4a"
        TreeNode20.Text = "CONTABLE"
        TreeNode21.Name = "Nodo23"
        TreeNode21.Tag = "4ba"
        TreeNode21.Text = "MASTER CAJAS"
        TreeNode22.Name = "Nodo25"
        TreeNode22.Tag = "4bb"
        TreeNode22.Text = "CAJA DIARIA"
        TreeNode23.Name = "Nodo22"
        TreeNode23.Tag = ""
        TreeNode23.Text = "CAJA"
        TreeNode24.Name = "Nodo26"
        TreeNode24.Tag = "4c"
        TreeNode24.Text = "PROVEEDORES"
        TreeNode25.Name = "Nodo27"
        TreeNode25.Tag = "4d"
        TreeNode25.Text = "AGENDA DE VENCIMIENTOS"
        TreeNode26.Name = "Nodo13"
        TreeNode26.Tag = "4"
        TreeNode26.Text = "Mod ADMINISTRACION"
        TreeNode27.Name = "Nodo28"
        TreeNode27.Tag = "5"
        TreeNode27.Text = "Mod TECNICO"
        TreeNode28.Name = "Nodo30"
        TreeNode28.Tag = "AR01"
        TreeNode28.Text = "IMPRESION DE ETIQUETAS"
        TreeNode29.Name = "Nodo0"
        TreeNode29.Tag = "KIBIT"
        TreeNode29.Text = "MODULOS KIBIT"
        TreeNode30.Name = "Nodo29"
        TreeNode30.Text = "ESPECIALES"
        TreeNode31.Name = "Nodo0"
        TreeNode31.Tag = "KIGEST_FACT_SIGT"
        TreeNode31.Text = "KIGEST_FACT_SIGT"
        Me.trvmodulos.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode31})
        Me.trvmodulos.Size = New System.Drawing.Size(321, 494)
        Me.trvmodulos.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel12)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 99)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1254, 494)
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
        Me.lblBusqueda.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusqueda.ForeColor = System.Drawing.Color.White
        Me.lblBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.lblBusqueda.Name = "lblBusqueda"
        Me.lblBusqueda.Size = New System.Drawing.Size(626, 99)
        Me.lblBusqueda.TabIndex = 77
        Me.lblBusqueda.Text = "EDITAR SERVICIOS DE CLOUDING Y ACCESO A MODULOS DE SISTEMA"
        Me.lblBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
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
        'frmServiciosCloud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1254, 593)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.Name = "frmServiciosCloud"
        Me.Text = "frmServiciosCloud"
        Me.Panel12.ResumeLayout(False)
        CType(Me.dtcloud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
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
End Class
