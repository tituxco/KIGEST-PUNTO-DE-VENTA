<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class produccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(produccion))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvProduccionEnvasados = New System.Windows.Forms.DataGridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblBusqueda = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grpperiodo = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dthastafact = New System.Windows.Forms.DateTimePicker()
        Me.dtdesdefact = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbltotalfact = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.chkfacturado = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvProduccionEnvasados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpperiodo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1269, 516)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvProduccionEnvasados)
        Me.TabPage1.Controls.Add(Me.Panel5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1261, 490)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Produccion de envasados"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvProduccionEnvasados
        '
        Me.dgvProduccionEnvasados.AllowUserToAddRows = False
        Me.dgvProduccionEnvasados.AllowUserToDeleteRows = False
        Me.dgvProduccionEnvasados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProduccionEnvasados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvProduccionEnvasados.BackgroundColor = System.Drawing.Color.White
        Me.dgvProduccionEnvasados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduccionEnvasados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProduccionEnvasados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvProduccionEnvasados.Location = New System.Drawing.Point(3, 108)
        Me.dgvProduccionEnvasados.Name = "dgvProduccionEnvasados"
        Me.dgvProduccionEnvasados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProduccionEnvasados.Size = New System.Drawing.Size(1255, 379)
        Me.dgvProduccionEnvasados.TabIndex = 9
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel5.Controls.Add(Me.GroupBox1)
        Me.Panel5.Controls.Add(Me.lblBusqueda)
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Controls.Add(Me.grpperiodo)
        Me.Panel5.Controls.Add(Me.lbltotalfact)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.cmdbuscar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.ForeColor = System.Drawing.Color.White
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1255, 105)
        Me.Panel5.TabIndex = 1
        '
        'lblBusqueda
        '
        Me.lblBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusqueda.ForeColor = System.Drawing.Color.White
        Me.lblBusqueda.Location = New System.Drawing.Point(3, 4)
        Me.lblBusqueda.Name = "lblBusqueda"
        Me.lblBusqueda.Size = New System.Drawing.Size(370, 46)
        Me.lblBusqueda.TabIndex = 78
        Me.lblBusqueda.Text = "Produccion de envasados sueltos"
        Me.lblBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(1043, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'grpperiodo
        '
        Me.grpperiodo.Controls.Add(Me.Label7)
        Me.grpperiodo.Controls.Add(Me.dthastafact)
        Me.grpperiodo.Controls.Add(Me.dtdesdefact)
        Me.grpperiodo.Controls.Add(Me.Label8)
        Me.grpperiodo.Location = New System.Drawing.Point(3, 53)
        Me.grpperiodo.Name = "grpperiodo"
        Me.grpperiodo.Size = New System.Drawing.Size(370, 45)
        Me.grpperiodo.TabIndex = 70
        Me.grpperiodo.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 17)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Desde"
        '
        'dthastafact
        '
        Me.dthastafact.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dthastafact.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dthastafact.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dthastafact.Location = New System.Drawing.Point(235, 14)
        Me.dthastafact.Name = "dthastafact"
        Me.dthastafact.Size = New System.Drawing.Size(131, 23)
        Me.dthastafact.TabIndex = 43
        '
        'dtdesdefact
        '
        Me.dtdesdefact.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdesdefact.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdesdefact.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtdesdefact.Location = New System.Drawing.Point(61, 14)
        Me.dtdesdefact.Name = "dtdesdefact"
        Me.dtdesdefact.Size = New System.Drawing.Size(117, 23)
        Me.dtdesdefact.TabIndex = 42
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(184, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 17)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Hasta"
        '
        'lbltotalfact
        '
        Me.lbltotalfact.AutoSize = True
        Me.lbltotalfact.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalfact.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbltotalfact.Location = New System.Drawing.Point(1039, 26)
        Me.lbltotalfact.Name = "lbltotalfact"
        Me.lbltotalfact.Size = New System.Drawing.Size(0, 20)
        Me.lbltotalfact.TabIndex = 65
        Me.lbltotalfact.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1040, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 16)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "TOTAL"
        Me.Label10.Visible = False
        '
        'cmdbuscar
        '
        Me.cmdbuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdbuscar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscar.Image = CType(resources.GetObject("cmdbuscar.Image"), System.Drawing.Image)
        Me.cmdbuscar.Location = New System.Drawing.Point(1175, 0)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(80, 105)
        Me.cmdbuscar.TabIndex = 48
        Me.cmdbuscar.Text = "Buscar"
        Me.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscar.UseVisualStyleBackColor = False
        '
        'chkfacturado
        '
        Me.chkfacturado.AutoSize = True
        Me.chkfacturado.Location = New System.Drawing.Point(6, 19)
        Me.chkfacturado.Name = "chkfacturado"
        Me.chkfacturado.Size = New System.Drawing.Size(93, 17)
        Me.chkfacturado.TabIndex = 79
        Me.chkfacturado.Text = "No facturados"
        Me.chkfacturado.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label54)
        Me.GroupBox1.Controls.Add(Me.chkfacturado)
        Me.GroupBox1.Location = New System.Drawing.Point(379, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(346, 92)
        Me.GroupBox1.TabIndex = 80
        Me.GroupBox1.TabStop = False
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(6, 0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(29, 13)
        Me.Label54.TabIndex = 80
        Me.Label54.Text = "Filtro"
        '
        'produccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1269, 516)
        Me.Controls.Add(Me.TabControl1)
        Me.KeyPreview = True
        Me.Name = "produccion"
        Me.Text = "PRODUCCION"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvProduccionEnvasados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpperiodo.ResumeLayout(False)
        Me.grpperiodo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents grpperiodo As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dthastafact As DateTimePicker
    Friend WithEvents dtdesdefact As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents lbltotalfact As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents lblBusqueda As Label
    Friend WithEvents dgvProduccionEnvasados As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkfacturado As CheckBox
    Friend WithEvents Label54 As Label
End Class
