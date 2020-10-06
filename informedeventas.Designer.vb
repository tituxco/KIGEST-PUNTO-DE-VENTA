<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class informedeventas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(informedeventas))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.cmbvendedor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAlmacenes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkproductos = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtdiasventa = New System.Windows.Forms.TextBox()
        Me.rdPocaRotacion = New System.Windows.Forms.RadioButton()
        Me.txtInforProd = New System.Windows.Forms.TextBox()
        Me.rdInforProductos = New System.Windows.Forms.RadioButton()
        Me.cmbInforCateg = New System.Windows.Forms.ComboBox()
        Me.cmbInforProv = New System.Windows.Forms.ComboBox()
        Me.rdInforCategoria = New System.Windows.Forms.RadioButton()
        Me.rdInforProv = New System.Windows.Forms.RadioButton()
        Me.rdInforgeneral = New System.Windows.Forms.RadioButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpvtashishasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpvtashisdesde = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnTotales = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblcomistotal = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblcomisobjetivos = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblComisvtas = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblvendedor = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblbalanceganancia = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblBalanProdNodCod = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblbalancecosto = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblvalDevoluciones = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblbalanceventas = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dtdevoluciones = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtgcomisiones = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblcomisiones = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dtventashistoricas = New System.Windows.Forms.DataGridView()
        Me.pntitulo.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel27.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.pnTotales.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dtdevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgcomisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dtventashistoricas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.AutoScroll = True
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1116, 40)
        Me.pntitulo.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(311, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Informe de ventas"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel11.Controls.Add(Me.Button2)
        Me.Panel11.Controls.Add(Me.Button18)
        Me.Panel11.Controls.Add(Me.Panel27)
        Me.Panel11.Controls.Add(Me.GroupBox5)
        Me.Panel11.Controls.Add(Me.GroupBox6)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 40)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1116, 123)
        Me.Panel11.TabIndex = 18
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(956, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 91)
        Me.Button2.TabIndex = 98
        Me.Button2.Text = "Guardar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button18.ForeColor = System.Drawing.Color.White
        Me.Button18.Image = CType(resources.GetObject("Button18.Image"), System.Drawing.Image)
        Me.Button18.Location = New System.Drawing.Point(1036, 0)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(80, 91)
        Me.Button18.TabIndex = 97
        Me.Button18.Text = "Buscar"
        Me.Button18.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button18.UseVisualStyleBackColor = True
        '
        'cmbvendedor
        '
        Me.cmbvendedor.FormattingEnabled = True
        Me.cmbvendedor.Location = New System.Drawing.Point(236, 6)
        Me.cmbvendedor.Name = "cmbvendedor"
        Me.cmbvendedor.Size = New System.Drawing.Size(119, 21)
        Me.cmbvendedor.TabIndex = 94
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(182, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "Vendedor"
        '
        'cmbAlmacenes
        '
        Me.cmbAlmacenes.FormattingEnabled = True
        Me.cmbAlmacenes.Location = New System.Drawing.Point(57, 6)
        Me.cmbAlmacenes.Name = "cmbAlmacenes"
        Me.cmbAlmacenes.Size = New System.Drawing.Size(119, 21)
        Me.cmbAlmacenes.TabIndex = 92
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Almacen"
        '
        'Panel27
        '
        Me.Panel27.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel27.Controls.Add(Me.Button1)
        Me.Panel27.Controls.Add(Me.Button24)
        Me.Panel27.Controls.Add(Me.cmbvendedor)
        Me.Panel27.Controls.Add(Me.Label2)
        Me.Panel27.Controls.Add(Me.Label3)
        Me.Panel27.Controls.Add(Me.cmbAlmacenes)
        Me.Panel27.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel27.Location = New System.Drawing.Point(0, 91)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(1116, 32)
        Me.Panel27.TabIndex = 89
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Location = New System.Drawing.Point(892, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 32)
        Me.Button1.TabIndex = 95
        Me.Button1.Text = "BALANCEO DE STOCK (invis)"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button24
        '
        Me.Button24.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button24.Image = Global.SIGT__KIGEST.My.Resources.Resources.Sync_32px
        Me.Button24.Location = New System.Drawing.Point(1083, 0)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(33, 32)
        Me.Button24.TabIndex = 91
        Me.Button24.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkproductos)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.txtdiasventa)
        Me.GroupBox5.Controls.Add(Me.rdPocaRotacion)
        Me.GroupBox5.Controls.Add(Me.txtInforProd)
        Me.GroupBox5.Controls.Add(Me.rdInforProductos)
        Me.GroupBox5.Controls.Add(Me.cmbInforCateg)
        Me.GroupBox5.Controls.Add(Me.cmbInforProv)
        Me.GroupBox5.Controls.Add(Me.rdInforCategoria)
        Me.GroupBox5.Controls.Add(Me.rdInforProv)
        Me.GroupBox5.Controls.Add(Me.rdInforgeneral)
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(207, 9)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(650, 71)
        Me.GroupBox5.TabIndex = 88
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Filtro"
        '
        'chkproductos
        '
        Me.chkproductos.AutoSize = True
        Me.chkproductos.Location = New System.Drawing.Point(288, 20)
        Me.chkproductos.Name = "chkproductos"
        Me.chkproductos.Size = New System.Drawing.Size(92, 17)
        Me.chkproductos.TabIndex = 97
        Me.chkproductos.Text = "Por productos"
        Me.chkproductos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(455, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "dias"
        '
        'txtdiasventa
        '
        Me.txtdiasventa.Enabled = False
        Me.txtdiasventa.Location = New System.Drawing.Point(424, 43)
        Me.txtdiasventa.Name = "txtdiasventa"
        Me.txtdiasventa.Size = New System.Drawing.Size(31, 20)
        Me.txtdiasventa.TabIndex = 95
        Me.txtdiasventa.Text = "90"
        '
        'rdPocaRotacion
        '
        Me.rdPocaRotacion.AutoSize = True
        Me.rdPocaRotacion.ForeColor = System.Drawing.Color.White
        Me.rdPocaRotacion.Location = New System.Drawing.Point(288, 46)
        Me.rdPocaRotacion.Name = "rdPocaRotacion"
        Me.rdPocaRotacion.Size = New System.Drawing.Size(139, 17)
        Me.rdPocaRotacion.TabIndex = 94
        Me.rdPocaRotacion.TabStop = True
        Me.rdPocaRotacion.Text = "Prod. poca rotación     >"
        Me.rdPocaRotacion.UseVisualStyleBackColor = True
        '
        'txtInforProd
        '
        Me.txtInforProd.Enabled = False
        Me.txtInforProd.Location = New System.Drawing.Point(379, 16)
        Me.txtInforProd.Name = "txtInforProd"
        Me.txtInforProd.Size = New System.Drawing.Size(181, 20)
        Me.txtInforProd.TabIndex = 93
        '
        'rdInforProductos
        '
        Me.rdInforProductos.AutoSize = True
        Me.rdInforProductos.ForeColor = System.Drawing.Color.White
        Me.rdInforProductos.Location = New System.Drawing.Point(518, 46)
        Me.rdInforProductos.Name = "rdInforProductos"
        Me.rdInforProductos.Size = New System.Drawing.Size(92, 17)
        Me.rdInforProductos.TabIndex = 92
        Me.rdInforProductos.TabStop = True
        Me.rdInforProductos.Text = "Por Productos"
        Me.rdInforProductos.UseVisualStyleBackColor = True
        Me.rdInforProductos.Visible = False
        '
        'cmbInforCateg
        '
        Me.cmbInforCateg.Enabled = False
        Me.cmbInforCateg.FormattingEnabled = True
        Me.cmbInforCateg.Location = New System.Drawing.Point(98, 42)
        Me.cmbInforCateg.Name = "cmbInforCateg"
        Me.cmbInforCateg.Size = New System.Drawing.Size(184, 21)
        Me.cmbInforCateg.TabIndex = 90
        '
        'cmbInforProv
        '
        Me.cmbInforProv.Enabled = False
        Me.cmbInforProv.FormattingEnabled = True
        Me.cmbInforProv.Location = New System.Drawing.Point(98, 16)
        Me.cmbInforProv.Name = "cmbInforProv"
        Me.cmbInforProv.Size = New System.Drawing.Size(184, 21)
        Me.cmbInforProv.TabIndex = 89
        '
        'rdInforCategoria
        '
        Me.rdInforCategoria.AutoSize = True
        Me.rdInforCategoria.ForeColor = System.Drawing.Color.White
        Me.rdInforCategoria.Location = New System.Drawing.Point(6, 46)
        Me.rdInforCategoria.Name = "rdInforCategoria"
        Me.rdInforCategoria.Size = New System.Drawing.Size(94, 17)
        Me.rdInforCategoria.TabIndex = 88
        Me.rdInforCategoria.TabStop = True
        Me.rdInforCategoria.Text = "Por Categorias"
        Me.rdInforCategoria.UseVisualStyleBackColor = True
        '
        'rdInforProv
        '
        Me.rdInforProv.AutoSize = True
        Me.rdInforProv.ForeColor = System.Drawing.Color.White
        Me.rdInforProv.Location = New System.Drawing.Point(6, 19)
        Me.rdInforProv.Name = "rdInforProv"
        Me.rdInforProv.Size = New System.Drawing.Size(92, 17)
        Me.rdInforProv.TabIndex = 86
        Me.rdInforProv.TabStop = True
        Me.rdInforProv.Text = "Por proveedor"
        Me.rdInforProv.UseVisualStyleBackColor = True
        '
        'rdInforgeneral
        '
        Me.rdInforgeneral.AutoSize = True
        Me.rdInforgeneral.Checked = True
        Me.rdInforgeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdInforgeneral.ForeColor = System.Drawing.Color.White
        Me.rdInforgeneral.Location = New System.Drawing.Point(566, 17)
        Me.rdInforgeneral.Name = "rdInforgeneral"
        Me.rdInforgeneral.Size = New System.Drawing.Size(72, 17)
        Me.rdInforgeneral.TabIndex = 87
        Me.rdInforgeneral.TabStop = True
        Me.rdInforgeneral.Text = "Sin filtro"
        Me.rdInforgeneral.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.dtpvtashishasta)
        Me.GroupBox6.Controls.Add(Me.dtpvtashisdesde)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.ForeColor = System.Drawing.Color.White
        Me.GroupBox6.Location = New System.Drawing.Point(3, 9)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(198, 71)
        Me.GroupBox6.TabIndex = 82
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Intervalo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 17)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Desde"
        '
        'dtpvtashishasta
        '
        Me.dtpvtashishasta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpvtashishasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpvtashishasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpvtashishasta.Location = New System.Drawing.Point(61, 41)
        Me.dtpvtashishasta.Name = "dtpvtashishasta"
        Me.dtpvtashishasta.Size = New System.Drawing.Size(117, 23)
        Me.dtpvtashishasta.TabIndex = 43
        '
        'dtpvtashisdesde
        '
        Me.dtpvtashisdesde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpvtashisdesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpvtashisdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpvtashisdesde.Location = New System.Drawing.Point(61, 15)
        Me.dtpvtashisdesde.Name = "dtpvtashisdesde"
        Me.dtpvtashisdesde.Size = New System.Drawing.Size(117, 23)
        Me.dtpvtashisdesde.TabIndex = 42
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(6, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 17)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Hasta"
        '
        'pnTotales
        '
        Me.pnTotales.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnTotales.Controls.Add(Me.Panel6)
        Me.pnTotales.Controls.Add(Me.lblbalanceganancia)
        Me.pnTotales.Controls.Add(Me.Label13)
        Me.pnTotales.Controls.Add(Me.lblBalanProdNodCod)
        Me.pnTotales.Controls.Add(Me.Label14)
        Me.pnTotales.Controls.Add(Me.lblbalancecosto)
        Me.pnTotales.Controls.Add(Me.Label12)
        Me.pnTotales.Controls.Add(Me.lblvalDevoluciones)
        Me.pnTotales.Controls.Add(Me.Label11)
        Me.pnTotales.Controls.Add(Me.lblbalanceventas)
        Me.pnTotales.Controls.Add(Me.Label8)
        Me.pnTotales.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnTotales.Location = New System.Drawing.Point(852, 163)
        Me.pnTotales.Name = "pnTotales"
        Me.pnTotales.Size = New System.Drawing.Size(264, 473)
        Me.pnTotales.TabIndex = 20
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.lblcomistotal)
        Me.Panel6.Controls.Add(Me.Label22)
        Me.Panel6.Controls.Add(Me.lblcomisobjetivos)
        Me.Panel6.Controls.Add(Me.Label20)
        Me.Panel6.Controls.Add(Me.lblComisvtas)
        Me.Panel6.Controls.Add(Me.Label17)
        Me.Panel6.Controls.Add(Me.lblvendedor)
        Me.Panel6.Controls.Add(Me.Label15)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 250)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(264, 211)
        Me.Panel6.TabIndex = 95
        '
        'lblcomistotal
        '
        Me.lblcomistotal.AutoSize = True
        Me.lblcomistotal.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblcomistotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcomistotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblcomistotal.Location = New System.Drawing.Point(0, 177)
        Me.lblcomistotal.Name = "lblcomistotal"
        Me.lblcomistotal.Size = New System.Drawing.Size(34, 25)
        Me.lblcomistotal.TabIndex = 90
        Me.lblcomistotal.Text = "$0"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(0, 152)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(186, 25)
        Me.Label22.TabIndex = 89
        Me.Label22.Text = "TOTAL COMISION"
        '
        'lblcomisobjetivos
        '
        Me.lblcomisobjetivos.AutoSize = True
        Me.lblcomisobjetivos.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblcomisobjetivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcomisobjetivos.ForeColor = System.Drawing.Color.White
        Me.lblcomisobjetivos.Location = New System.Drawing.Point(0, 127)
        Me.lblcomisobjetivos.Name = "lblcomisobjetivos"
        Me.lblcomisobjetivos.Size = New System.Drawing.Size(34, 25)
        Me.lblcomisobjetivos.TabIndex = 88
        Me.lblcomisobjetivos.Text = "$0"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(0, 102)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(209, 25)
        Me.Label20.TabIndex = 87
        Me.Label20.Text = "Comision por objetivos"
        '
        'lblComisvtas
        '
        Me.lblComisvtas.AutoSize = True
        Me.lblComisvtas.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblComisvtas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComisvtas.ForeColor = System.Drawing.Color.White
        Me.lblComisvtas.Location = New System.Drawing.Point(0, 77)
        Me.lblComisvtas.Name = "lblComisvtas"
        Me.lblComisvtas.Size = New System.Drawing.Size(34, 25)
        Me.lblComisvtas.TabIndex = 86
        Me.lblComisvtas.Text = "$0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(0, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(258, 25)
        Me.Label17.TabIndex = 85
        Me.Label17.Text = "Comision por ventas totales:"
        '
        'lblvendedor
        '
        Me.lblvendedor.AutoSize = True
        Me.lblvendedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblvendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvendedor.ForeColor = System.Drawing.Color.White
        Me.lblvendedor.Location = New System.Drawing.Point(0, 27)
        Me.lblvendedor.Name = "lblvendedor"
        Me.lblvendedor.Size = New System.Drawing.Size(104, 25)
        Me.lblvendedor.TabIndex = 84
        Me.lblvendedor.Text = "Vendedor:"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Black
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(0, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(262, 27)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = "Calculo de comisiones"
        '
        'lblbalanceganancia
        '
        Me.lblbalanceganancia.AutoSize = True
        Me.lblbalanceganancia.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblbalanceganancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbalanceganancia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblbalanceganancia.Location = New System.Drawing.Point(0, 225)
        Me.lblbalanceganancia.Name = "lblbalanceganancia"
        Me.lblbalanceganancia.Size = New System.Drawing.Size(34, 25)
        Me.lblbalanceganancia.TabIndex = 97
        Me.lblbalanceganancia.Text = "$0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(0, 200)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(189, 25)
        Me.Label13.TabIndex = 96
        Me.Label13.Text = "TOTAL GANANCIA"
        '
        'lblBalanProdNodCod
        '
        Me.lblBalanProdNodCod.AutoSize = True
        Me.lblBalanProdNodCod.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBalanProdNodCod.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalanProdNodCod.ForeColor = System.Drawing.Color.White
        Me.lblBalanProdNodCod.Location = New System.Drawing.Point(0, 175)
        Me.lblBalanProdNodCod.Name = "lblBalanProdNodCod"
        Me.lblBalanProdNodCod.Size = New System.Drawing.Size(34, 25)
        Me.lblBalanProdNodCod.TabIndex = 94
        Me.lblBalanProdNodCod.Text = "$0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(0, 150)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(197, 25)
        Me.Label14.TabIndex = 93
        Me.Label14.Text = "TOTAL Prod NOCod"
        '
        'lblbalancecosto
        '
        Me.lblbalancecosto.AutoSize = True
        Me.lblbalancecosto.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblbalancecosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbalancecosto.ForeColor = System.Drawing.Color.White
        Me.lblbalancecosto.Location = New System.Drawing.Point(0, 125)
        Me.lblbalancecosto.Name = "lblbalancecosto"
        Me.lblbalancecosto.Size = New System.Drawing.Size(34, 25)
        Me.lblbalancecosto.TabIndex = 82
        Me.lblbalancecosto.Text = "$0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(0, 100)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(158, 25)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "TOTAL COSTO"
        '
        'lblvalDevoluciones
        '
        Me.lblvalDevoluciones.AutoSize = True
        Me.lblvalDevoluciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblvalDevoluciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvalDevoluciones.ForeColor = System.Drawing.Color.White
        Me.lblvalDevoluciones.Location = New System.Drawing.Point(0, 75)
        Me.lblvalDevoluciones.Name = "lblvalDevoluciones"
        Me.lblvalDevoluciones.Size = New System.Drawing.Size(34, 25)
        Me.lblvalDevoluciones.TabIndex = 80
        Me.lblvalDevoluciones.Text = "$0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(0, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(243, 25)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "TOTAL DEVOLUCIONES"
        '
        'lblbalanceventas
        '
        Me.lblbalanceventas.AutoSize = True
        Me.lblbalanceventas.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblbalanceventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbalanceventas.ForeColor = System.Drawing.Color.White
        Me.lblbalanceventas.Location = New System.Drawing.Point(0, 25)
        Me.lblbalanceventas.Name = "lblbalanceventas"
        Me.lblbalanceventas.Size = New System.Drawing.Size(34, 25)
        Me.lblbalanceventas.TabIndex = 78
        Me.lblbalanceventas.Text = "$0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 25)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "TOTAL VENTAS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 17)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Ventas totales"
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(852, 22)
        Me.Panel3.TabIndex = 21
        '
        'dtdevoluciones
        '
        Me.dtdevoluciones.AllowUserToAddRows = False
        Me.dtdevoluciones.AllowUserToDeleteRows = False
        Me.dtdevoluciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtdevoluciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtdevoluciones.BackgroundColor = System.Drawing.Color.White
        Me.dtdevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtdevoluciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtdevoluciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtdevoluciones.Location = New System.Drawing.Point(0, 206)
        Me.dtdevoluciones.Name = "dtdevoluciones"
        Me.dtdevoluciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtdevoluciones.Size = New System.Drawing.Size(852, 137)
        Me.dtdevoluciones.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Devoluciones"
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 187)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(852, 19)
        Me.Panel4.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtgcomisiones)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 506)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(852, 130)
        Me.Panel1.TabIndex = 26
        '
        'dtgcomisiones
        '
        Me.dtgcomisiones.AllowUserToAddRows = False
        Me.dtgcomisiones.AllowUserToDeleteRows = False
        Me.dtgcomisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgcomisiones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgcomisiones.BackgroundColor = System.Drawing.Color.White
        Me.dtgcomisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgcomisiones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgcomisiones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgcomisiones.Location = New System.Drawing.Point(0, 21)
        Me.dtgcomisiones.Name = "dtgcomisiones"
        Me.dtgcomisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgcomisiones.Size = New System.Drawing.Size(852, 109)
        Me.dtgcomisiones.TabIndex = 27
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblcomisiones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(852, 21)
        Me.Panel2.TabIndex = 26
        '
        'lblcomisiones
        '
        Me.lblcomisiones.AutoSize = True
        Me.lblcomisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcomisiones.ForeColor = System.Drawing.Color.White
        Me.lblcomisiones.Location = New System.Drawing.Point(3, 0)
        Me.lblcomisiones.Name = "lblcomisiones"
        Me.lblcomisiones.Size = New System.Drawing.Size(266, 17)
        Me.lblcomisiones.TabIndex = 2
        Me.lblcomisiones.Text = "Comisiones por productos objetivos"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dtventashistoricas)
        Me.Panel5.Controls.Add(Me.Panel4)
        Me.Panel5.Controls.Add(Me.dtdevoluciones)
        Me.Panel5.Controls.Add(Me.Panel3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 163)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(852, 343)
        Me.Panel5.TabIndex = 27
        '
        'dtventashistoricas
        '
        Me.dtventashistoricas.AllowUserToAddRows = False
        Me.dtventashistoricas.AllowUserToDeleteRows = False
        Me.dtventashistoricas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtventashistoricas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtventashistoricas.BackgroundColor = System.Drawing.Color.White
        Me.dtventashistoricas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtventashistoricas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtventashistoricas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtventashistoricas.Location = New System.Drawing.Point(0, 22)
        Me.dtventashistoricas.Name = "dtventashistoricas"
        Me.dtventashistoricas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtventashistoricas.Size = New System.Drawing.Size(852, 165)
        Me.dtventashistoricas.TabIndex = 24
        '
        'informedeventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1116, 636)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnTotales)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "informedeventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "informedeventas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel27.ResumeLayout(False)
        Me.Panel27.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.pnTotales.ResumeLayout(False)
        Me.pnTotales.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dtdevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtgcomisiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.dtventashistoricas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtInforProd As TextBox
    Friend WithEvents rdInforProductos As RadioButton
    Friend WithEvents Button24 As Button
    Friend WithEvents cmbInforCateg As ComboBox
    Friend WithEvents cmbInforProv As ComboBox
    Friend WithEvents rdInforCategoria As RadioButton
    Friend WithEvents rdInforProv As RadioButton
    Friend WithEvents rdInforgeneral As RadioButton
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpvtashishasta As DateTimePicker
    Friend WithEvents dtpvtashisdesde As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel27 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbAlmacenes As ComboBox
    Friend WithEvents cmbvendedor As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents pnTotales As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents txtdiasventa As TextBox
    Friend WithEvents rdPocaRotacion As RadioButton
    Friend WithEvents Button18 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents chkproductos As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dtdevoluciones As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtgcomisiones As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblcomisiones As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblbalanceventas As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtventashistoricas As DataGridView
    Friend WithEvents Label12 As Label
    Friend WithEvents lblvalDevoluciones As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblcomistotal As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents lblcomisobjetivos As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lblComisvtas As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblvendedor As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblBalanProdNodCod As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblbalancecosto As Label
    Friend WithEvents lblbalanceganancia As Label
    Friend WithEvents Label13 As Label
End Class
