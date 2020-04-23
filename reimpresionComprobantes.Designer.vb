<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reimpresionComprobantes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reimpresionComprobantes))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabcomprobantes = New System.Windows.Forms.TabPage()
        Me.dtfacturas = New System.Windows.Forms.DataGridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.chkImprimirA4 = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtremitos = New System.Windows.Forms.DataGridView()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.cmdlistadoremitos = New System.Windows.Forms.Button()
        Me.cmdreimprimirremitos = New System.Windows.Forms.Button()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.dtderemitos = New System.Windows.Forms.DateTimePicker()
        Me.dthastaremitos = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumeroComprobante = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.cmdbuscarremitos = New System.Windows.Forms.Button()
        Me.txtrazonsocial = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.Label1.Size = New System.Drawing.Size(269, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "REIMPRESIÓN"
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
        Me.dtfacturas.Location = New System.Drawing.Point(3, 73)
        Me.dtfacturas.Name = "dtfacturas"
        Me.dtfacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtfacturas.Size = New System.Drawing.Size(1255, 340)
        Me.dtfacturas.TabIndex = 8
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel5.Controls.Add(Me.txtrazonsocial)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.txtNumeroComprobante)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Button4)
        Me.Panel5.Controls.Add(Me.TextBox1)
        Me.Panel5.Controls.Add(Me.chkImprimirA4)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.cmdbuscar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.ForeColor = System.Drawing.Color.White
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1255, 70)
        Me.Panel5.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(3, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(77, 20)
        Me.TextBox1.TabIndex = 59
        Me.TextBox1.Text = "20"
        '
        'chkImprimirA4
        '
        Me.chkImprimirA4.AutoSize = True
        Me.chkImprimirA4.Location = New System.Drawing.Point(5, 53)
        Me.chkImprimirA4.Name = "chkImprimirA4"
        Me.chkImprimirA4.Size = New System.Drawing.Size(100, 17)
        Me.chkImprimirA4.TabIndex = 58
        Me.chkImprimirA4.Text = "No imprimir tiket"
        Me.chkImprimirA4.UseVisualStyleBackColor = True
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Cantidad de comprobantes a mostrar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(207, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Numero de comprobante/s"
        '
        'txtNumeroComprobante
        '
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(210, 27)
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(131, 20)
        Me.txtNumeroComprobante.TabIndex = 63
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(1032, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(78, 70)
        Me.Button4.TabIndex = 60
        Me.Button4.Text = "Remitar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1110, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 70)
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
        Me.cmdbuscar.Size = New System.Drawing.Size(65, 70)
        Me.cmdbuscar.TabIndex = 48
        Me.cmdbuscar.Text = "Buscar"
        Me.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscar.UseVisualStyleBackColor = False
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
        'txtrazonsocial
        '
        Me.txtrazonsocial.Location = New System.Drawing.Point(367, 27)
        Me.txtrazonsocial.Name = "txtrazonsocial"
        Me.txtrazonsocial.Size = New System.Drawing.Size(218, 20)
        Me.txtrazonsocial.TabIndex = 65
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(364, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Razon social/Nombre cliente"
        '
        'reimpresionComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1269, 482)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pntitulo)
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
    Friend WithEvents chkImprimirA4 As CheckBox
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
End Class
