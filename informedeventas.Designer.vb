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
        Me.dtventashistoricas = New System.Windows.Forms.DataGridView()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.cmbAlmacenes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.lblbalanceganancia = New System.Windows.Forms.Label()
        Me.lblbalancecosto = New System.Windows.Forms.Label()
        Me.lblbalanceventas = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtInforProd = New System.Windows.Forms.TextBox()
        Me.rdInforProductos = New System.Windows.Forms.RadioButton()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.cmbInforCateg = New System.Windows.Forms.ComboBox()
        Me.cmbInforProv = New System.Windows.Forms.ComboBox()
        Me.rdInforCategoria = New System.Windows.Forms.RadioButton()
        Me.rdInforProv = New System.Windows.Forms.RadioButton()
        Me.rdInforgeneral = New System.Windows.Forms.RadioButton()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpvtashishasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpvtashisdesde = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pntitulo.SuspendLayout()
        CType(Me.dtventashistoricas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.Panel27.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
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
        Me.pntitulo.Size = New System.Drawing.Size(1203, 40)
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
        Me.dtventashistoricas.Location = New System.Drawing.Point(0, 138)
        Me.dtventashistoricas.Name = "dtventashistoricas"
        Me.dtventashistoricas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtventashistoricas.Size = New System.Drawing.Size(1203, 276)
        Me.dtventashistoricas.TabIndex = 19
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel11.Controls.Add(Me.cmbAlmacenes)
        Me.Panel11.Controls.Add(Me.Label2)
        Me.Panel11.Controls.Add(Me.Panel27)
        Me.Panel11.Controls.Add(Me.GroupBox5)
        Me.Panel11.Controls.Add(Me.Button18)
        Me.Panel11.Controls.Add(Me.GroupBox6)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 40)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1203, 98)
        Me.Panel11.TabIndex = 18
        '
        'cmbAlmacenes
        '
        Me.cmbAlmacenes.FormattingEnabled = True
        Me.cmbAlmacenes.Location = New System.Drawing.Point(863, 21)
        Me.cmbAlmacenes.Name = "cmbAlmacenes"
        Me.cmbAlmacenes.Size = New System.Drawing.Size(184, 21)
        Me.cmbAlmacenes.TabIndex = 92
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(863, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Almacen"
        '
        'Panel27
        '
        Me.Panel27.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel27.Controls.Add(Me.lblbalanceganancia)
        Me.Panel27.Controls.Add(Me.lblbalancecosto)
        Me.Panel27.Controls.Add(Me.lblbalanceventas)
        Me.Panel27.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel27.Location = New System.Drawing.Point(0, 70)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(1123, 28)
        Me.Panel27.TabIndex = 89
        '
        'lblbalanceganancia
        '
        Me.lblbalanceganancia.AutoSize = True
        Me.lblbalanceganancia.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblbalanceganancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbalanceganancia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblbalanceganancia.Location = New System.Drawing.Point(68, 0)
        Me.lblbalanceganancia.Name = "lblbalanceganancia"
        Me.lblbalanceganancia.Size = New System.Drawing.Size(34, 25)
        Me.lblbalanceganancia.TabIndex = 78
        Me.lblbalanceganancia.Text = "$0"
        '
        'lblbalancecosto
        '
        Me.lblbalancecosto.AutoSize = True
        Me.lblbalancecosto.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblbalancecosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbalancecosto.ForeColor = System.Drawing.Color.Cyan
        Me.lblbalancecosto.Location = New System.Drawing.Point(34, 0)
        Me.lblbalancecosto.Name = "lblbalancecosto"
        Me.lblbalancecosto.Size = New System.Drawing.Size(34, 25)
        Me.lblbalancecosto.TabIndex = 77
        Me.lblbalancecosto.Text = "$0"
        '
        'lblbalanceventas
        '
        Me.lblbalanceventas.AutoSize = True
        Me.lblbalanceventas.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblbalanceventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbalanceventas.ForeColor = System.Drawing.Color.White
        Me.lblbalanceventas.Location = New System.Drawing.Point(0, 0)
        Me.lblbalanceventas.Name = "lblbalanceventas"
        Me.lblbalanceventas.Size = New System.Drawing.Size(34, 25)
        Me.lblbalanceventas.TabIndex = 76
        Me.lblbalanceventas.Text = "$0"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtInforProd)
        Me.GroupBox5.Controls.Add(Me.rdInforProductos)
        Me.GroupBox5.Controls.Add(Me.Button24)
        Me.GroupBox5.Controls.Add(Me.cmbInforCateg)
        Me.GroupBox5.Controls.Add(Me.cmbInforProv)
        Me.GroupBox5.Controls.Add(Me.rdInforCategoria)
        Me.GroupBox5.Controls.Add(Me.rdInforProv)
        Me.GroupBox5.Controls.Add(Me.rdInforgeneral)
        Me.GroupBox5.ForeColor = System.Drawing.Color.White
        Me.GroupBox5.Location = New System.Drawing.Point(207, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(650, 71)
        Me.GroupBox5.TabIndex = 88
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Filtro"
        '
        'txtInforProd
        '
        Me.txtInforProd.Enabled = False
        Me.txtInforProd.Location = New System.Drawing.Point(455, 41)
        Me.txtInforProd.Name = "txtInforProd"
        Me.txtInforProd.Size = New System.Drawing.Size(181, 20)
        Me.txtInforProd.TabIndex = 93
        '
        'rdInforProductos
        '
        Me.rdInforProductos.AutoSize = True
        Me.rdInforProductos.ForeColor = System.Drawing.Color.White
        Me.rdInforProductos.Location = New System.Drawing.Point(455, 21)
        Me.rdInforProductos.Name = "rdInforProductos"
        Me.rdInforProductos.Size = New System.Drawing.Size(92, 17)
        Me.rdInforProductos.TabIndex = 92
        Me.rdInforProductos.TabStop = True
        Me.rdInforProductos.Text = "Por Productos"
        Me.rdInforProductos.UseVisualStyleBackColor = True
        '
        'Button24
        '
        Me.Button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button24.Image = Global.SIGT__KIGEST.My.Resources.Resources.Sync_32px
        Me.Button24.Location = New System.Drawing.Point(6, 44)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(35, 23)
        Me.Button24.TabIndex = 91
        Me.Button24.UseVisualStyleBackColor = True
        '
        'cmbInforCateg
        '
        Me.cmbInforCateg.Enabled = False
        Me.cmbInforCateg.FormattingEnabled = True
        Me.cmbInforCateg.Location = New System.Drawing.Point(257, 41)
        Me.cmbInforCateg.Name = "cmbInforCateg"
        Me.cmbInforCateg.Size = New System.Drawing.Size(184, 21)
        Me.cmbInforCateg.TabIndex = 90
        '
        'cmbInforProv
        '
        Me.cmbInforProv.Enabled = False
        Me.cmbInforProv.FormattingEnabled = True
        Me.cmbInforProv.Location = New System.Drawing.Point(74, 42)
        Me.cmbInforProv.Name = "cmbInforProv"
        Me.cmbInforProv.Size = New System.Drawing.Size(164, 21)
        Me.cmbInforProv.TabIndex = 89
        '
        'rdInforCategoria
        '
        Me.rdInforCategoria.AutoSize = True
        Me.rdInforCategoria.ForeColor = System.Drawing.Color.White
        Me.rdInforCategoria.Location = New System.Drawing.Point(257, 21)
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
        Me.rdInforProv.Location = New System.Drawing.Point(74, 21)
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
        Me.rdInforgeneral.ForeColor = System.Drawing.Color.White
        Me.rdInforgeneral.Location = New System.Drawing.Point(6, 21)
        Me.rdInforgeneral.Name = "rdInforgeneral"
        Me.rdInforgeneral.Size = New System.Drawing.Size(62, 17)
        Me.rdInforgeneral.TabIndex = 87
        Me.rdInforgeneral.TabStop = True
        Me.rdInforgeneral.Text = "General"
        Me.rdInforgeneral.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button18.ForeColor = System.Drawing.Color.White
        Me.Button18.Image = CType(resources.GetObject("Button18.Image"), System.Drawing.Image)
        Me.Button18.Location = New System.Drawing.Point(1123, 0)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(80, 98)
        Me.Button18.TabIndex = 85
        Me.Button18.Text = "Buscar"
        Me.Button18.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button18.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.dtpvtashishasta)
        Me.GroupBox6.Controls.Add(Me.dtpvtashisdesde)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.ForeColor = System.Drawing.Color.White
        Me.GroupBox6.Location = New System.Drawing.Point(3, 0)
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
        'informedeventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1203, 414)
        Me.Controls.Add(Me.dtventashistoricas)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "informedeventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "informedeventas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        CType(Me.dtventashistoricas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel27.ResumeLayout(False)
        Me.Panel27.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents dtventashistoricas As DataGridView
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
    Friend WithEvents Button18 As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpvtashishasta As DateTimePicker
    Friend WithEvents dtpvtashisdesde As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel27 As Panel
    Friend WithEvents lblbalanceganancia As Label
    Friend WithEvents lblbalancecosto As Label
    Friend WithEvents lblbalanceventas As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbAlmacenes As ComboBox
End Class
