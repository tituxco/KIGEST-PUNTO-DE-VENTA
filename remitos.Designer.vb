<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class remitos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(remitos))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnnavegacion = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rdfacturados = New System.Windows.Forms.RadioButton()
        Me.rdpendientes = New System.Windows.Forms.RadioButton()
        Me.txtbusqCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdnuevapers = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.dtpedidos = New System.Windows.Forms.DataGridView()
        Me.pntitulo.SuspendLayout()
        Me.pnnavegacion.SuspendLayout()
        CType(Me.dtpedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1021, 40)
        Me.pntitulo.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(405, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "LISTADO DE REMITOS"
        '
        'pnnavegacion
        '
        Me.pnnavegacion.BackColor = System.Drawing.Color.Gray
        Me.pnnavegacion.Controls.Add(Me.Button1)
        Me.pnnavegacion.Controls.Add(Me.rdfacturados)
        Me.pnnavegacion.Controls.Add(Me.rdpendientes)
        Me.pnnavegacion.Controls.Add(Me.txtbusqCliente)
        Me.pnnavegacion.Controls.Add(Me.Label3)
        Me.pnnavegacion.Controls.Add(Me.cmdnuevapers)
        Me.pnnavegacion.Controls.Add(Me.cmdsalir)
        Me.pnnavegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnnavegacion.Location = New System.Drawing.Point(0, 40)
        Me.pnnavegacion.Name = "pnnavegacion"
        Me.pnnavegacion.Size = New System.Drawing.Size(1021, 91)
        Me.pnnavegacion.TabIndex = 86
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(863, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 91)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "Actualizar/Cargar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rdfacturados
        '
        Me.rdfacturados.AutoSize = True
        Me.rdfacturados.ForeColor = System.Drawing.Color.White
        Me.rdfacturados.Location = New System.Drawing.Point(91, 64)
        Me.rdfacturados.Name = "rdfacturados"
        Me.rdfacturados.Size = New System.Drawing.Size(97, 17)
        Me.rdfacturados.TabIndex = 39
        Me.rdfacturados.Text = "Ver Facturados"
        Me.rdfacturados.UseVisualStyleBackColor = True
        '
        'rdpendientes
        '
        Me.rdpendientes.AutoSize = True
        Me.rdpendientes.Checked = True
        Me.rdpendientes.ForeColor = System.Drawing.Color.White
        Me.rdpendientes.Location = New System.Drawing.Point(91, 40)
        Me.rdpendientes.Name = "rdpendientes"
        Me.rdpendientes.Size = New System.Drawing.Size(97, 17)
        Me.rdpendientes.TabIndex = 38
        Me.rdpendientes.TabStop = True
        Me.rdpendientes.Text = "Ver Pendientes"
        Me.rdpendientes.UseVisualStyleBackColor = True
        '
        'txtbusqCliente
        '
        Me.txtbusqCliente.Location = New System.Drawing.Point(91, 14)
        Me.txtbusqCliente.Name = "txtbusqCliente"
        Me.txtbusqCliente.Size = New System.Drawing.Size(192, 20)
        Me.txtbusqCliente.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(91, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Cliente"
        '
        'cmdnuevapers
        '
        Me.cmdnuevapers.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdnuevapers.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdnuevapers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdnuevapers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnuevapers.ForeColor = System.Drawing.Color.White
        Me.cmdnuevapers.Image = CType(resources.GetObject("cmdnuevapers.Image"), System.Drawing.Image)
        Me.cmdnuevapers.Location = New System.Drawing.Point(0, 0)
        Me.cmdnuevapers.Name = "cmdnuevapers"
        Me.cmdnuevapers.Size = New System.Drawing.Size(75, 91)
        Me.cmdnuevapers.TabIndex = 18
        Me.cmdnuevapers.Text = "Nuevo"
        Me.cmdnuevapers.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdnuevapers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdnuevapers.UseVisualStyleBackColor = True
        '
        'cmdsalir
        '
        Me.cmdsalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdsalir.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdsalir.ForeColor = System.Drawing.Color.White
        Me.cmdsalir.Image = CType(resources.GetObject("cmdsalir.Image"), System.Drawing.Image)
        Me.cmdsalir.Location = New System.Drawing.Point(951, 0)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(70, 91)
        Me.cmdsalir.TabIndex = 17
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdsalir.UseVisualStyleBackColor = True
        '
        'dtpedidos
        '
        Me.dtpedidos.AllowUserToAddRows = False
        Me.dtpedidos.AllowUserToDeleteRows = False
        Me.dtpedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtpedidos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtpedidos.BackgroundColor = System.Drawing.Color.White
        Me.dtpedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtpedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpedidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtpedidos.Location = New System.Drawing.Point(0, 131)
        Me.dtpedidos.MultiSelect = False
        Me.dtpedidos.Name = "dtpedidos"
        Me.dtpedidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtpedidos.Size = New System.Drawing.Size(1021, 360)
        Me.dtpedidos.TabIndex = 87
        '
        'remitos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 491)
        Me.Controls.Add(Me.dtpedidos)
        Me.Controls.Add(Me.pnnavegacion)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "remitos"
        Me.Text = "remitos"
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.pnnavegacion.ResumeLayout(False)
        Me.pnnavegacion.PerformLayout()
        CType(Me.dtpedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents pnnavegacion As Panel
    Friend WithEvents rdfacturados As RadioButton
    Friend WithEvents rdpendientes As RadioButton
    Friend WithEvents txtbusqCliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdnuevapers As Button
    Friend WithEvents cmdsalir As Button
    Friend WithEvents dtpedidos As DataGridView
    Friend WithEvents Button1 As Button
End Class
