<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class agendavencimientos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(agendavencimientos))
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnnavegacion = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtphasta = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpdesde = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtagendafacturas = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbltotalfacturas = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtagendachequesterceros = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lbltotalchequesterceros = New System.Windows.Forms.Label()
        Me.dtagendachequespropios = New System.Windows.Forms.DataGridView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lbltotalchequespropios = New System.Windows.Forms.Label()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnnavegacion.SuspendLayout()
        Me.pntitulo.SuspendLayout()
        CType(Me.dtagendafacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dtagendachequesterceros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dtagendachequespropios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = GetType(System.Configuration.ApplicationSettingsBase)
        '
        'pnnavegacion
        '
        Me.pnnavegacion.BackColor = System.Drawing.Color.Gray
        Me.pnnavegacion.Controls.Add(Me.Label2)
        Me.pnnavegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnnavegacion.Location = New System.Drawing.Point(0, 56)
        Me.pnnavegacion.Name = "pnnavegacion"
        Me.pnnavegacion.Size = New System.Drawing.Size(1239, 33)
        Me.pnnavegacion.TabIndex = 67
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(369, 33)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "FACTURAS DE PROVEEDORES"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Button1)
        Me.pntitulo.Controls.Add(Me.dtphasta)
        Me.pntitulo.Controls.Add(Me.Label9)
        Me.pntitulo.Controls.Add(Me.dtpdesde)
        Me.pntitulo.Controls.Add(Me.Label8)
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1239, 56)
        Me.pntitulo.TabIndex = 66
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gray
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1062, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 56)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Ver"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dtphasta
        '
        Me.dtphasta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphasta.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtphasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtphasta.Location = New System.Drawing.Point(862, 0)
        Me.dtphasta.Name = "dtphasta"
        Me.dtphasta.Size = New System.Drawing.Size(200, 30)
        Me.dtphasta.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(782, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 56)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Hasta:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpdesde
        '
        Me.dtpdesde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdesde.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtpdesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdesde.Location = New System.Drawing.Point(582, 0)
        Me.dtpdesde.Name = "dtpdesde"
        Me.dtpdesde.Size = New System.Drawing.Size(200, 30)
        Me.dtpdesde.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(502, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 56)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Desde: "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(502, 56)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "AGENDA DE VENCIMIENTOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtagendafacturas
        '
        Me.dtagendafacturas.AllowUserToAddRows = False
        Me.dtagendafacturas.AllowUserToDeleteRows = False
        Me.dtagendafacturas.AllowUserToResizeColumns = False
        Me.dtagendafacturas.AllowUserToResizeRows = False
        Me.dtagendafacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtagendafacturas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtagendafacturas.BackgroundColor = System.Drawing.Color.White
        Me.dtagendafacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtagendafacturas.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtagendafacturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtagendafacturas.Location = New System.Drawing.Point(0, 89)
        Me.dtagendafacturas.Name = "dtagendafacturas"
        Me.dtagendafacturas.Size = New System.Drawing.Size(1239, 98)
        Me.dtagendafacturas.TabIndex = 68
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.lbltotalfacturas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 187)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1239, 27)
        Me.Panel1.TabIndex = 69
        '
        'lbltotalfacturas
        '
        Me.lbltotalfacturas.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbltotalfacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalfacturas.ForeColor = System.Drawing.Color.White
        Me.lbltotalfacturas.Location = New System.Drawing.Point(128, 0)
        Me.lbltotalfacturas.Name = "lbltotalfacturas"
        Me.lbltotalfacturas.Size = New System.Drawing.Size(1111, 27)
        Me.lbltotalfacturas.TabIndex = 4
        Me.lbltotalfacturas.Text = "TOTAL"
        Me.lbltotalfacturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 545)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1239, 39)
        Me.Panel2.TabIndex = 71
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 214)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1239, 27)
        Me.Panel3.TabIndex = 72
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(369, 27)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "CHEQUES DE TERCEROS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtagendachequesterceros
        '
        Me.dtagendachequesterceros.AllowUserToAddRows = False
        Me.dtagendachequesterceros.AllowUserToDeleteRows = False
        Me.dtagendachequesterceros.AllowUserToResizeColumns = False
        Me.dtagendachequesterceros.AllowUserToResizeRows = False
        Me.dtagendachequesterceros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtagendachequesterceros.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtagendachequesterceros.BackgroundColor = System.Drawing.Color.White
        Me.dtagendachequesterceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtagendachequesterceros.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtagendachequesterceros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtagendachequesterceros.Location = New System.Drawing.Point(0, 241)
        Me.dtagendachequesterceros.Name = "dtagendachequesterceros"
        Me.dtagendachequesterceros.Size = New System.Drawing.Size(1239, 88)
        Me.dtagendachequesterceros.TabIndex = 73
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gray
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 356)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1239, 27)
        Me.Panel4.TabIndex = 75
        Me.Panel4.Visible = False
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(369, 27)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "CHEQUES PROPIOS"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Controls.Add(Me.lbltotalchequesterceros)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 329)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1239, 27)
        Me.Panel5.TabIndex = 74
        '
        'lbltotalchequesterceros
        '
        Me.lbltotalchequesterceros.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbltotalchequesterceros.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalchequesterceros.ForeColor = System.Drawing.Color.White
        Me.lbltotalchequesterceros.Location = New System.Drawing.Point(123, 0)
        Me.lbltotalchequesterceros.Name = "lbltotalchequesterceros"
        Me.lbltotalchequesterceros.Size = New System.Drawing.Size(1116, 27)
        Me.lbltotalchequesterceros.TabIndex = 4
        Me.lbltotalchequesterceros.Text = "TOTAL"
        Me.lbltotalchequesterceros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtagendachequespropios
        '
        Me.dtagendachequespropios.AllowUserToAddRows = False
        Me.dtagendachequespropios.AllowUserToDeleteRows = False
        Me.dtagendachequespropios.AllowUserToResizeColumns = False
        Me.dtagendachequespropios.AllowUserToResizeRows = False
        Me.dtagendachequespropios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtagendachequespropios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtagendachequespropios.BackgroundColor = System.Drawing.Color.White
        Me.dtagendachequespropios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtagendachequespropios.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtagendachequespropios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtagendachequespropios.Location = New System.Drawing.Point(0, 383)
        Me.dtagendachequespropios.Name = "dtagendachequespropios"
        Me.dtagendachequespropios.Size = New System.Drawing.Size(1239, 109)
        Me.dtagendachequespropios.TabIndex = 76
        Me.dtagendachequespropios.Visible = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Gray
        Me.Panel6.Controls.Add(Me.lbltotalchequespropios)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 492)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1239, 26)
        Me.Panel6.TabIndex = 77
        '
        'lbltotalchequespropios
        '
        Me.lbltotalchequespropios.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbltotalchequespropios.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalchequespropios.ForeColor = System.Drawing.Color.White
        Me.lbltotalchequespropios.Location = New System.Drawing.Point(773, 0)
        Me.lbltotalchequespropios.Name = "lbltotalchequespropios"
        Me.lbltotalchequespropios.Size = New System.Drawing.Size(466, 26)
        Me.lbltotalchequespropios.TabIndex = 4
        Me.lbltotalchequespropios.Text = "TOTAL"
        Me.lbltotalchequespropios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbltotalchequespropios.Visible = False
        '
        'agendavencimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 584)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.dtagendachequespropios)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.dtagendachequesterceros)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtagendafacturas)
        Me.Controls.Add(Me.pnnavegacion)
        Me.Controls.Add(Me.pntitulo)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "agendavencimientos"
        Me.Text = "agendavencimientos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnnavegacion.ResumeLayout(False)
        Me.pntitulo.ResumeLayout(False)
        CType(Me.dtagendafacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dtagendachequesterceros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.dtagendachequespropios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MySettingsBindingSource As BindingSource
    Friend WithEvents pnnavegacion As Panel
    Friend WithEvents pntitulo As Panel
    Friend WithEvents dtagendafacturas As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lbltotalfacturas As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents dtagendachequesterceros As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lbltotalchequesterceros As Label
    Friend WithEvents dtagendachequespropios As DataGridView
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lbltotalchequespropios As Label
    Friend WithEvents dtphasta As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpdesde As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
