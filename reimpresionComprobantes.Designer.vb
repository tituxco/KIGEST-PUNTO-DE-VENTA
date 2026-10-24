<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class reimpresionComprobantes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reimpresionComprobantes))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabcomprobantes = New System.Windows.Forms.TabPage()
        Me.dtfacturas = New System.Windows.Forms.DataGridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.chksinPagar = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtdesdeCobranza = New System.Windows.Forms.DateTimePicker()
        Me.dthastaCobranza = New System.Windows.Forms.DateTimePicker()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.cmbInforPtoVta = New System.Windows.Forms.ComboBox()
        Me.txtrazonsocial = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.chkImpresionTermica = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtremitos = New System.Windows.Forms.DataGridView()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.cmdlistadoremitos = New System.Windows.Forms.Button()
        Me.cmdreimprimirremitos = New System.Windows.Forms.Button()
        Me.cmdbuscarremitos = New System.Windows.Forms.Button()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.dtderemitos = New System.Windows.Forms.DateTimePicker()
        Me.dthastaremitos = New System.Windows.Forms.DateTimePicker()
        Me.bgwBuscarFacturas = New System.ComponentModel.BackgroundWorker()
        Me.pntitulo.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabcomprobantes.SuspendLayout()
        CType(Me.dtfacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtremitos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel22.SuspendLayout()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1269, 40)
        Me.pntitulo.TabIndex = 73
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(667, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "VISUALIZACION DE COMPROBANTES"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabcomprobantes)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1269, 442)
        Me.TabControl1.TabIndex = 74
        '
        'tabcomprobantes
        '
        Me.tabcomprobantes.Controls.Add(Me.dtfacturas)
        Me.tabcomprobantes.Controls.Add(Me.Panel5)
        Me.tabcomprobantes.Location = New System.Drawing.Point(4, 22)
        Me.tabcomprobantes.Name = "tabcomprobantes"
        Me.tabcomprobantes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabcomprobantes.Size = New System.Drawing.Size(1261, 416)
        Me.tabcomprobantes.TabIndex = 7
        Me.tabcomprobantes.Text = "Ultimas facturas y recibos"
        Me.tabcomprobantes.UseVisualStyleBackColor = True
        '
        'dtfacturas
        '
        Me.dtfacturas.AllowUserToAddRows = False
        Me.dtfacturas.AllowUserToDeleteRows = False
        Me.dtfacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtfacturas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtfacturas.BackgroundColor = System.Drawing.Color.White
        Me.dtfacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtfacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtfacturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtfacturas.Location = New System.Drawing.Point(3, 79)
        Me.dtfacturas.Name = "dtfacturas"
        Me.dtfacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtfacturas.Size = New System.Drawing.Size(1255, 334)
        Me.dtfacturas.TabIndex = 8
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.cmbTipoComprobante)
        Me.Panel5.Controls.Add(Me.lblTotal)
        Me.Panel5.Controls.Add(Me.Button2)
        Me.Panel5.Controls.Add(Me.Button9)
        Me.Panel5.Controls.Add(Me.chksinPagar)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.dtdesdeCobranza)
        Me.Panel5.Controls.Add(Me.dthastaCobranza)
        Me.Panel5.Controls.Add(Me.Button8)
        Me.Panel5.Controls.Add(Me.Button7)
        Me.Panel5.Controls.Add(Me.Label49)
        Me.Panel5.Controls.Add(Me.cmbInforPtoVta)
        Me.Panel5.Controls.Add(Me.txtrazonsocial)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.txtNumeroComprobante)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Button4)
        Me.Panel5.Controls.Add(Me.TextBox1)
        Me.Panel5.Controls.Add(Me.chkImpresionTermica)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.cmdbuscar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.ForeColor = System.Drawing.Color.White
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1255, 76)
        Me.Panel5.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(431, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 13)
        Me.Label7.TabIndex = 97
        Me.Label7.Text = "Tipo de comprobante"
        '
        'cmbTipoComprobante
        '
        Me.cmbTipoComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobante.ForeColor = System.Drawing.Color.White
        Me.cmbTipoComprobante.FormattingEnabled = True
        Me.cmbTipoComprobante.Location = New System.Drawing.Point(432, 51)
        Me.cmbTipoComprobante.Name = "cmbTipoComprobante"
        Me.cmbTipoComprobante.Size = New System.Drawing.Size(125, 23)
        Me.cmbTipoComprobante.TabIndex = 96
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(654, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(62, 25)
        Me.lblTotal.TabIndex = 88
        Me.lblTotal.Text = "Total:"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = Global.SIGT__KIGEST.My.Resources.Resources.Cash_Register_32px1
        Me.Button2.Location = New System.Drawing.Point(716, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(78, 76)
        Me.Button2.TabIndex = 95
        Me.Button2.Text = "Imputar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.White
        Me.Button9.Image = Global.SIGT__KIGEST.My.Resources.Resources.microsoft_excel_32px
        Me.Button9.Location = New System.Drawing.Point(794, 0)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(78, 76)
        Me.Button9.TabIndex = 94
        Me.Button9.Text = "Exportar"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button9.UseVisualStyleBackColor = False
        '
        'chksinPagar
        '
        Me.chksinPagar.AutoSize = True
        Me.chksinPagar.ForeColor = System.Drawing.Color.White
        Me.chksinPagar.Location = New System.Drawing.Point(186, 37)
        Me.chksinPagar.Name = "chksinPagar"
        Me.chksinPagar.Size = New System.Drawing.Size(71, 17)
        Me.chksinPagar.TabIndex = 93
        Me.chksinPagar.Text = "Sin pagar"
        Me.chksinPagar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(5, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Desde"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(5, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 17)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Hasta"
        '
        'dtdesdeCobranza
        '
        Me.dtdesdeCobranza.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdesdeCobranza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdesdeCobranza.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtdesdeCobranza.Location = New System.Drawing.Point(60, 11)
        Me.dtdesdeCobranza.Name = "dtdesdeCobranza"
        Me.dtdesdeCobranza.Size = New System.Drawing.Size(117, 23)
        Me.dtdesdeCobranza.TabIndex = 89
        '
        'dthastaCobranza
        '
        Me.dthastaCobranza.AccessibleName = ""
        Me.dthastaCobranza.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dthastaCobranza.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dthastaCobranza.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dthastaCobranza.Location = New System.Drawing.Point(60, 37)
        Me.dthastaCobranza.Name = "dthastaCobranza"
        Me.dthastaCobranza.Size = New System.Drawing.Size(117, 23)
        Me.dthastaCobranza.TabIndex = 90
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Image = Global.SIGT__KIGEST.My.Resources.Resources.Save_32px1
        Me.Button8.Location = New System.Drawing.Point(872, 0)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(80, 76)
        Me.Button8.TabIndex = 81
        Me.Button8.Text = "Guardar"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Image = Global.SIGT__KIGEST.My.Resources.Resources.secured_letter_32px
        Me.Button7.Location = New System.Drawing.Point(952, 0)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(80, 76)
        Me.Button7.TabIndex = 80
        Me.Button7.Text = "Enviar"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.White
        Me.Label49.Location = New System.Drawing.Point(430, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(80, 13)
        Me.Label49.TabIndex = 79
        Me.Label49.Text = "Punto de venta"
        '
        'cmbInforPtoVta
        '
        Me.cmbInforPtoVta.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbInforPtoVta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInforPtoVta.ForeColor = System.Drawing.Color.White
        Me.cmbInforPtoVta.FormattingEnabled = True
        Me.cmbInforPtoVta.Location = New System.Drawing.Point(431, 14)
        Me.cmbInforPtoVta.Name = "cmbInforPtoVta"
        Me.cmbInforPtoVta.Size = New System.Drawing.Size(125, 23)
        Me.cmbInforPtoVta.TabIndex = 78
        '
        'txtrazonsocial
        '
        Me.txtrazonsocial.Location = New System.Drawing.Point(284, 52)
        Me.txtrazonsocial.Name = "txtrazonsocial"
        Me.txtrazonsocial.Size = New System.Drawing.Size(131, 20)
        Me.txtrazonsocial.TabIndex = 65
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(281, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Razon social/Nombre cliente"
        '
        'txtNumeroComprobante
        '
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(284, 16)
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(131, 20)
        Me.txtNumeroComprobante.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(281, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Numero de comprobante/s"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(183, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Mostrar"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(1032, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(78, 76)
        Me.Button4.TabIndex = 60
        Me.Button4.Text = "Remitar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(186, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(77, 20)
        Me.TextBox1.TabIndex = 59
        Me.TextBox1.Text = "100"
        '
        'chkImpresionTermica
        '
        Me.chkImpresionTermica.AutoSize = True
        Me.chkImpresionTermica.Location = New System.Drawing.Point(186, 52)
        Me.chkImpresionTermica.Name = "chkImpresionTermica"
        Me.chkImpresionTermica.Size = New System.Drawing.Size(64, 17)
        Me.chkImpresionTermica.TabIndex = 58
        Me.chkImpresionTermica.Text = "Termico"
        Me.chkImpresionTermica.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1110, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 76)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "Imprimir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmdbuscar
        '
        Me.cmdbuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdbuscar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscar.Image = CType(resources.GetObject("cmdbuscar.Image"), System.Drawing.Image)
        Me.cmdbuscar.Location = New System.Drawing.Point(1190, 0)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(65, 76)
        Me.cmdbuscar.TabIndex = 48
        Me.cmdbuscar.Text = "Buscar"
        Me.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscar.UseVisualStyleBackColor = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtremitos)
        Me.TabPage1.Controls.Add(Me.Panel22)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1261, 416)
        Me.TabPage1.TabIndex = 8
        Me.TabPage1.Text = "Remitos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtremitos
        '
        Me.dtremitos.AllowUserToAddRows = False
        Me.dtremitos.AllowUserToDeleteRows = False
        Me.dtremitos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtremitos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtremitos.BackgroundColor = System.Drawing.Color.White
        Me.dtremitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtremitos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtremitos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtremitos.Location = New System.Drawing.Point(0, 70)
        Me.dtremitos.Name = "dtremitos"
        Me.dtremitos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtremitos.Size = New System.Drawing.Size(1261, 346)
        Me.dtremitos.TabIndex = 14
        '
        'Panel22
        '
        Me.Panel22.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel22.Controls.Add(Me.cmdlistadoremitos)
        Me.Panel22.Controls.Add(Me.cmdreimprimirremitos)
        Me.Panel22.Controls.Add(Me.cmdbuscarremitos)
        Me.Panel22.Controls.Add(Me.Label43)
        Me.Panel22.Controls.Add(Me.Label44)
        Me.Panel22.Controls.Add(Me.dtderemitos)
        Me.Panel22.Controls.Add(Me.dthastaremitos)
        Me.Panel22.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel22.Location = New System.Drawing.Point(0, 0)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(1261, 70)
        Me.Panel22.TabIndex = 13
        '
        'cmdlistadoremitos
        '
        Me.cmdlistadoremitos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdlistadoremitos.ForeColor = System.Drawing.Color.White
        Me.cmdlistadoremitos.Location = New System.Drawing.Point(198, 36)
        Me.cmdlistadoremitos.Name = "cmdlistadoremitos"
        Me.cmdlistadoremitos.Size = New System.Drawing.Size(138, 23)
        Me.cmdlistadoremitos.TabIndex = 58
        Me.cmdlistadoremitos.Text = "Imprimir listado"
        Me.cmdlistadoremitos.UseVisualStyleBackColor = True
        '
        'cmdreimprimirremitos
        '
        Me.cmdreimprimirremitos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdreimprimirremitos.ForeColor = System.Drawing.Color.White
        Me.cmdreimprimirremitos.Location = New System.Drawing.Point(198, 12)
        Me.cmdreimprimirremitos.Name = "cmdreimprimirremitos"
        Me.cmdreimprimirremitos.Size = New System.Drawing.Size(138, 23)
        Me.cmdreimprimirremitos.TabIndex = 57
        Me.cmdreimprimirremitos.Text = "Reimprimir comprobante"
        Me.cmdreimprimirremitos.UseVisualStyleBackColor = True
        '
        'cmdbuscarremitos
        '
        Me.cmdbuscarremitos.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdbuscarremitos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdbuscarremitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscarremitos.ForeColor = System.Drawing.Color.White
        Me.cmdbuscarremitos.Image = CType(resources.GetObject("cmdbuscarremitos.Image"), System.Drawing.Image)
        Me.cmdbuscarremitos.Location = New System.Drawing.Point(1196, 0)
        Me.cmdbuscarremitos.Name = "cmdbuscarremitos"
        Me.cmdbuscarremitos.Size = New System.Drawing.Size(65, 70)
        Me.cmdbuscarremitos.TabIndex = 48
        Me.cmdbuscarremitos.Text = "Buscar"
        Me.cmdbuscarremitos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscarremitos.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(6, 16)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(49, 17)
        Me.Label43.TabIndex = 44
        Me.Label43.Text = "Desde"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(6, 42)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(45, 17)
        Me.Label44.TabIndex = 45
        Me.Label44.Text = "Hasta"
        '
        'dtderemitos
        '
        Me.dtderemitos.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtderemitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtderemitos.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtderemitos.Location = New System.Drawing.Point(61, 11)
        Me.dtderemitos.Name = "dtderemitos"
        Me.dtderemitos.Size = New System.Drawing.Size(117, 23)
        Me.dtderemitos.TabIndex = 42
        '
        'dthastaremitos
        '
        Me.dthastaremitos.AccessibleName = ""
        Me.dthastaremitos.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dthastaremitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dthastaremitos.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dthastaremitos.Location = New System.Drawing.Point(61, 37)
        Me.dthastaremitos.Name = "dthastaremitos"
        Me.dthastaremitos.Size = New System.Drawing.Size(117, 23)
        Me.dthastaremitos.TabIndex = 43
        '
        'bgwBuscarFacturas
        '
        '
        'reimpresionComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1269, 482)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pntitulo)
        Me.KeyPreview = True
        Me.Name = "reimpresionComprobantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "reimpresionComprobantes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabcomprobantes.ResumeLayout(False)
        CType(Me.dtfacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dtremitos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel22.ResumeLayout(False)
        Me.Panel22.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabcomprobantes As TabPage
    Friend WithEvents dtfacturas As DataGridView
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents chkImpresionTermica As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dtremitos As DataGridView
    Friend WithEvents Panel22 As Panel
    Friend WithEvents cmdlistadoremitos As Button
    Friend WithEvents cmdreimprimirremitos As Button
    Friend WithEvents cmdbuscarremitos As Button
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents dtderemitos As DateTimePicker
    Friend WithEvents dthastaremitos As DateTimePicker
    Friend WithEvents txtNumeroComprobante As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtrazonsocial As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents cmbInforPtoVta As ComboBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents chksinPagar As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtdesdeCobranza As DateTimePicker
    Friend WithEvents dthastaCobranza As DateTimePicker
    Friend WithEvents lblTotal As Label
    Friend WithEvents bgwBuscarFacturas As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button9 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbTipoComprobante As ComboBox
End Class
