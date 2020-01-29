<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Presupuestos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Presupuestos))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnnavegacion = New System.Windows.Forms.Panel()
        Me.rdImportar = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdlistacarga = New System.Windows.Forms.Button()
        Me.rdfacturados = New System.Windows.Forms.RadioButton()
        Me.rdpendientes = New System.Windows.Forms.RadioButton()
        Me.txtbusqCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbvendedor = New System.Windows.Forms.ComboBox()
        Me.cmdnvalistacarga = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdeliminar = New System.Windows.Forms.Button()
        Me.cmdmodificar = New System.Windows.Forms.Button()
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
        Me.pntitulo.Size = New System.Drawing.Size(1223, 40)
        Me.pntitulo.TabIndex = 76
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(710, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "LISTADO DE PEDIDOS/PRESUPUESTOS"
        '
        'pnnavegacion
        '
        Me.pnnavegacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnnavegacion.Controls.Add(Me.rdImportar)
        Me.pnnavegacion.Controls.Add(Me.Button2)
        Me.pnnavegacion.Controls.Add(Me.cmdlistacarga)
        Me.pnnavegacion.Controls.Add(Me.rdfacturados)
        Me.pnnavegacion.Controls.Add(Me.rdpendientes)
        Me.pnnavegacion.Controls.Add(Me.txtbusqCliente)
        Me.pnnavegacion.Controls.Add(Me.Label3)
        Me.pnnavegacion.Controls.Add(Me.Label2)
        Me.pnnavegacion.Controls.Add(Me.cmbvendedor)
        Me.pnnavegacion.Controls.Add(Me.cmdnvalistacarga)
        Me.pnnavegacion.Controls.Add(Me.Button1)
        Me.pnnavegacion.Controls.Add(Me.cmdeliminar)
        Me.pnnavegacion.Controls.Add(Me.cmdmodificar)
        Me.pnnavegacion.Controls.Add(Me.cmdnuevapers)
        Me.pnnavegacion.Controls.Add(Me.cmdsalir)
        Me.pnnavegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnnavegacion.Location = New System.Drawing.Point(0, 40)
        Me.pnnavegacion.Name = "pnnavegacion"
        Me.pnnavegacion.Size = New System.Drawing.Size(1223, 91)
        Me.pnnavegacion.TabIndex = 78
        '
        'rdImportar
        '
        Me.rdImportar.AutoSize = True
        Me.rdImportar.ForeColor = System.Drawing.Color.White
        Me.rdImportar.Location = New System.Drawing.Point(474, 53)
        Me.rdImportar.Name = "rdImportar"
        Me.rdImportar.Size = New System.Drawing.Size(102, 17)
        Me.rdImportar.TabIndex = 42
        Me.rdImportar.Text = "Pedidos de APP"
        Me.rdImportar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(741, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 91)
        Me.Button2.TabIndex = 41
        Me.Button2.Text = "Imprimir"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdlistacarga
        '
        Me.cmdlistacarga.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdlistacarga.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdlistacarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdlistacarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlistacarga.ForeColor = System.Drawing.Color.White
        Me.cmdlistacarga.Image = CType(resources.GetObject("cmdlistacarga.Image"), System.Drawing.Image)
        Me.cmdlistacarga.Location = New System.Drawing.Point(849, 0)
        Me.cmdlistacarga.Name = "cmdlistacarga"
        Me.cmdlistacarga.Size = New System.Drawing.Size(108, 91)
        Me.cmdlistacarga.TabIndex = 40
        Me.cmdlistacarga.Text = "L. de carga"
        Me.cmdlistacarga.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdlistacarga.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdlistacarga.UseVisualStyleBackColor = True
        Me.cmdlistacarga.Visible = False
        '
        'rdfacturados
        '
        Me.rdfacturados.AutoSize = True
        Me.rdfacturados.ForeColor = System.Drawing.Color.White
        Me.rdfacturados.Location = New System.Drawing.Point(474, 30)
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
        Me.rdpendientes.Location = New System.Drawing.Point(474, 6)
        Me.rdpendientes.Name = "rdpendientes"
        Me.rdpendientes.Size = New System.Drawing.Size(97, 17)
        Me.rdpendientes.TabIndex = 38
        Me.rdpendientes.TabStop = True
        Me.rdpendientes.Text = "Ver Pendientes"
        Me.rdpendientes.UseVisualStyleBackColor = True
        '
        'txtbusqCliente
        '
        Me.txtbusqCliente.Location = New System.Drawing.Point(243, 60)
        Me.txtbusqCliente.Name = "txtbusqCliente"
        Me.txtbusqCliente.Size = New System.Drawing.Size(192, 20)
        Me.txtbusqCliente.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(243, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(243, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Vendedor"
        '
        'cmbvendedor
        '
        Me.cmbvendedor.FormattingEnabled = True
        Me.cmbvendedor.Location = New System.Drawing.Point(243, 22)
        Me.cmbvendedor.Name = "cmbvendedor"
        Me.cmbvendedor.Size = New System.Drawing.Size(192, 21)
        Me.cmbvendedor.TabIndex = 34
        '
        'cmdnvalistacarga
        '
        Me.cmdnvalistacarga.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdnvalistacarga.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdnvalistacarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdnvalistacarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnvalistacarga.ForeColor = System.Drawing.Color.White
        Me.cmdnvalistacarga.Image = CType(resources.GetObject("cmdnvalistacarga.Image"), System.Drawing.Image)
        Me.cmdnvalistacarga.Location = New System.Drawing.Point(957, 0)
        Me.cmdnvalistacarga.Name = "cmdnvalistacarga"
        Me.cmdnvalistacarga.Size = New System.Drawing.Size(108, 91)
        Me.cmdnvalistacarga.TabIndex = 33
        Me.cmdnvalistacarga.Text = "Nva. carga"
        Me.cmdnvalistacarga.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdnvalistacarga.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdnvalistacarga.UseVisualStyleBackColor = True
        Me.cmdnvalistacarga.Visible = False
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1065, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 91)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "Actualizar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdeliminar
        '
        Me.cmdeliminar.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdeliminar.Enabled = False
        Me.cmdeliminar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdeliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdeliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdeliminar.ForeColor = System.Drawing.Color.White
        Me.cmdeliminar.Image = CType(resources.GetObject("cmdeliminar.Image"), System.Drawing.Image)
        Me.cmdeliminar.Location = New System.Drawing.Point(158, 0)
        Me.cmdeliminar.Name = "cmdeliminar"
        Me.cmdeliminar.Size = New System.Drawing.Size(79, 91)
        Me.cmdeliminar.TabIndex = 31
        Me.cmdeliminar.Text = "Eliminar"
        Me.cmdeliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdeliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdeliminar.UseVisualStyleBackColor = True
        '
        'cmdmodificar
        '
        Me.cmdmodificar.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdmodificar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdmodificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdmodificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdmodificar.ForeColor = System.Drawing.Color.White
        Me.cmdmodificar.Image = CType(resources.GetObject("cmdmodificar.Image"), System.Drawing.Image)
        Me.cmdmodificar.Location = New System.Drawing.Point(75, 0)
        Me.cmdmodificar.Name = "cmdmodificar"
        Me.cmdmodificar.Size = New System.Drawing.Size(83, 91)
        Me.cmdmodificar.TabIndex = 19
        Me.cmdmodificar.Text = "Modificar"
        Me.cmdmodificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdmodificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdmodificar.UseVisualStyleBackColor = True
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
        Me.cmdsalir.Location = New System.Drawing.Point(1153, 0)
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
        Me.dtpedidos.Size = New System.Drawing.Size(1223, 353)
        Me.dtpedidos.TabIndex = 81
        '
        'Presupuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1223, 484)
        Me.Controls.Add(Me.dtpedidos)
        Me.Controls.Add(Me.pnnavegacion)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "Presupuestos"
        Me.Text = "pedidos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.pnnavegacion.ResumeLayout(False)
        Me.pnnavegacion.PerformLayout()
        CType(Me.dtpedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnnavegacion As System.Windows.Forms.Panel
    Friend WithEvents cmdeliminar As System.Windows.Forms.Button
    Friend WithEvents cmdmodificar As System.Windows.Forms.Button
    Friend WithEvents cmdnuevapers As System.Windows.Forms.Button
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdnvalistacarga As System.Windows.Forms.Button
    Friend WithEvents cmbvendedor As System.Windows.Forms.ComboBox
    Friend WithEvents txtbusqCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdfacturados As System.Windows.Forms.RadioButton
    Friend WithEvents rdpendientes As System.Windows.Forms.RadioButton
    Friend WithEvents dtpedidos As System.Windows.Forms.DataGridView
    Friend WithEvents cmdlistacarga As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents rdImportar As RadioButton
End Class
