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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbltotalPedidos = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.dtphasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpdesde = New System.Windows.Forms.DateTimePicker()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbvendedor = New System.Windows.Forms.ComboBox()
        Me.rdImportar = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtbusqCliente = New System.Windows.Forms.TextBox()
        Me.rdpendientes = New System.Windows.Forms.RadioButton()
        Me.rdfacturados = New System.Windows.Forms.RadioButton()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdlistacarga = New System.Windows.Forms.Button()
        Me.cmdnvalistacarga = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdeliminar = New System.Windows.Forms.Button()
        Me.cmdmodificar = New System.Windows.Forms.Button()
        Me.cmdnuevapers = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.dgvPedidos = New SIGT__KIGEST.DGVPaginado()
        Me.pntitulo.SuspendLayout()
        Me.pnnavegacion.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1243, 40)
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
        Me.pnnavegacion.Controls.Add(Me.Panel2)
        Me.pnnavegacion.Controls.Add(Me.Button4)
        Me.pnnavegacion.Controls.Add(Me.Label61)
        Me.pnnavegacion.Controls.Add(Me.dtphasta)
        Me.pnnavegacion.Controls.Add(Me.dtpdesde)
        Me.pnnavegacion.Controls.Add(Me.Label62)
        Me.pnnavegacion.Controls.Add(Me.Panel1)
        Me.pnnavegacion.Controls.Add(Me.Button3)
        Me.pnnavegacion.Controls.Add(Me.Button2)
        Me.pnnavegacion.Controls.Add(Me.cmdlistacarga)
        Me.pnnavegacion.Controls.Add(Me.cmdnvalistacarga)
        Me.pnnavegacion.Controls.Add(Me.Button1)
        Me.pnnavegacion.Controls.Add(Me.cmdeliminar)
        Me.pnnavegacion.Controls.Add(Me.cmdmodificar)
        Me.pnnavegacion.Controls.Add(Me.cmdnuevapers)
        Me.pnnavegacion.Controls.Add(Me.cmdsalir)
        Me.pnnavegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnnavegacion.Location = New System.Drawing.Point(0, 40)
        Me.pnnavegacion.Name = "pnnavegacion"
        Me.pnnavegacion.Size = New System.Drawing.Size(1243, 137)
        Me.pnnavegacion.TabIndex = 78
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.lbltotalPedidos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(546, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(201, 137)
        Me.Panel2.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(3, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 17)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "TOTAL"
        '
        'lbltotalPedidos
        '
        Me.lbltotalPedidos.AutoSize = True
        Me.lbltotalPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalPedidos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbltotalPedidos.Location = New System.Drawing.Point(3, 24)
        Me.lbltotalPedidos.Name = "lbltotalPedidos"
        Me.lbltotalPedidos.Size = New System.Drawing.Size(24, 17)
        Me.lbltotalPedidos.TabIndex = 79
        Me.lbltotalPedidos.Text = "$0"
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(747, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(73, 137)
        Me.Button4.TabIndex = 50
        Me.Button4.Text = "Devolucion"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(420, 9)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(49, 17)
        Me.Label61.TabIndex = 48
        Me.Label61.Text = "Desde"
        '
        'dtphasta
        '
        Me.dtphasta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtphasta.Location = New System.Drawing.Point(423, 73)
        Me.dtphasta.Name = "dtphasta"
        Me.dtphasta.Size = New System.Drawing.Size(117, 23)
        Me.dtphasta.TabIndex = 47
        '
        'dtpdesde
        '
        Me.dtpdesde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdesde.Location = New System.Drawing.Point(423, 27)
        Me.dtpdesde.Name = "dtpdesde"
        Me.dtpdesde.Size = New System.Drawing.Size(117, 23)
        Me.dtpdesde.TabIndex = 46
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.White
        Me.Label62.Location = New System.Drawing.Point(420, 53)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(45, 17)
        Me.Label62.TabIndex = 49
        Me.Label62.Text = "Hasta"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbvendedor)
        Me.Panel1.Controls.Add(Me.rdImportar)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtbusqCliente)
        Me.Panel1.Controls.Add(Me.rdpendientes)
        Me.Panel1.Controls.Add(Me.rdfacturados)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(210, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(204, 137)
        Me.Panel1.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Vendedor"
        '
        'cmbvendedor
        '
        Me.cmbvendedor.FormattingEnabled = True
        Me.cmbvendedor.Location = New System.Drawing.Point(6, 29)
        Me.cmbvendedor.Name = "cmbvendedor"
        Me.cmbvendedor.Size = New System.Drawing.Size(192, 21)
        Me.cmbvendedor.TabIndex = 34
        '
        'rdImportar
        '
        Me.rdImportar.AutoSize = True
        Me.rdImportar.ForeColor = System.Drawing.Color.White
        Me.rdImportar.Location = New System.Drawing.Point(117, 93)
        Me.rdImportar.Name = "rdImportar"
        Me.rdImportar.Size = New System.Drawing.Size(63, 17)
        Me.rdImportar.TabIndex = 42
        Me.rdImportar.Text = "Importar"
        Me.rdImportar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Cliente"
        '
        'txtbusqCliente
        '
        Me.txtbusqCliente.Location = New System.Drawing.Point(6, 67)
        Me.txtbusqCliente.Name = "txtbusqCliente"
        Me.txtbusqCliente.Size = New System.Drawing.Size(192, 20)
        Me.txtbusqCliente.TabIndex = 37
        '
        'rdpendientes
        '
        Me.rdpendientes.AutoSize = True
        Me.rdpendientes.Checked = True
        Me.rdpendientes.ForeColor = System.Drawing.Color.White
        Me.rdpendientes.Location = New System.Drawing.Point(9, 93)
        Me.rdpendientes.Name = "rdpendientes"
        Me.rdpendientes.Size = New System.Drawing.Size(50, 17)
        Me.rdpendientes.TabIndex = 38
        Me.rdpendientes.TabStop = True
        Me.rdpendientes.Text = "Pend"
        Me.rdpendientes.UseVisualStyleBackColor = True
        '
        'rdfacturados
        '
        Me.rdfacturados.AutoSize = True
        Me.rdfacturados.ForeColor = System.Drawing.Color.White
        Me.rdfacturados.Location = New System.Drawing.Point(65, 93)
        Me.rdfacturados.Name = "rdfacturados"
        Me.rdfacturados.Size = New System.Drawing.Size(46, 17)
        Me.rdfacturados.TabIndex = 39
        Me.rdfacturados.Text = "Fact"
        Me.rdfacturados.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(820, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(73, 137)
        Me.Button3.TabIndex = 43
        Me.Button3.Text = "Facturar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(893, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 137)
        Me.Button2.TabIndex = 41
        Me.Button2.Text = "Imprimir listado"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdlistacarga
        '
        Me.cmdlistacarga.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdlistacarga.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdlistacarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdlistacarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlistacarga.ForeColor = System.Drawing.Color.White
        Me.cmdlistacarga.Image = CType(resources.GetObject("cmdlistacarga.Image"), System.Drawing.Image)
        Me.cmdlistacarga.Location = New System.Drawing.Point(963, 0)
        Me.cmdlistacarga.Name = "cmdlistacarga"
        Me.cmdlistacarga.Size = New System.Drawing.Size(70, 137)
        Me.cmdlistacarga.TabIndex = 40
        Me.cmdlistacarga.Text = "L. de carga"
        Me.cmdlistacarga.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdlistacarga.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdlistacarga.UseVisualStyleBackColor = True
        Me.cmdlistacarga.Visible = False
        '
        'cmdnvalistacarga
        '
        Me.cmdnvalistacarga.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdnvalistacarga.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdnvalistacarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdnvalistacarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnvalistacarga.ForeColor = System.Drawing.Color.White
        Me.cmdnvalistacarga.Image = CType(resources.GetObject("cmdnvalistacarga.Image"), System.Drawing.Image)
        Me.cmdnvalistacarga.Location = New System.Drawing.Point(1033, 0)
        Me.cmdnvalistacarga.Name = "cmdnvalistacarga"
        Me.cmdnvalistacarga.Size = New System.Drawing.Size(70, 137)
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
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1103, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 137)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "Actualizar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdeliminar
        '
        Me.cmdeliminar.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdeliminar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdeliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdeliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdeliminar.ForeColor = System.Drawing.Color.White
        Me.cmdeliminar.Image = CType(resources.GetObject("cmdeliminar.Image"), System.Drawing.Image)
        Me.cmdeliminar.Location = New System.Drawing.Point(140, 0)
        Me.cmdeliminar.Name = "cmdeliminar"
        Me.cmdeliminar.Size = New System.Drawing.Size(70, 137)
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
        Me.cmdmodificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdmodificar.ForeColor = System.Drawing.Color.White
        Me.cmdmodificar.Image = CType(resources.GetObject("cmdmodificar.Image"), System.Drawing.Image)
        Me.cmdmodificar.Location = New System.Drawing.Point(70, 0)
        Me.cmdmodificar.Name = "cmdmodificar"
        Me.cmdmodificar.Size = New System.Drawing.Size(70, 137)
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
        Me.cmdnuevapers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnuevapers.ForeColor = System.Drawing.Color.White
        Me.cmdnuevapers.Image = CType(resources.GetObject("cmdnuevapers.Image"), System.Drawing.Image)
        Me.cmdnuevapers.Location = New System.Drawing.Point(0, 0)
        Me.cmdnuevapers.Name = "cmdnuevapers"
        Me.cmdnuevapers.Size = New System.Drawing.Size(70, 137)
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
        Me.cmdsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdsalir.ForeColor = System.Drawing.Color.White
        Me.cmdsalir.Image = CType(resources.GetObject("cmdsalir.Image"), System.Drawing.Image)
        Me.cmdsalir.Location = New System.Drawing.Point(1173, 0)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(70, 137)
        Me.cmdsalir.TabIndex = 17
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdsalir.UseVisualStyleBackColor = True
        '
        'dgvPedidos
        '
        Me.dgvPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPedidos.Location = New System.Drawing.Point(0, 177)
        Me.dgvPedidos.Name = "dgvPedidos"
        Me.dgvPedidos.Size = New System.Drawing.Size(1243, 307)
        Me.dgvPedidos.TabIndex = 82
        '
        'Presupuestos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1243, 484)
        Me.Controls.Add(Me.dgvPedidos)
        Me.Controls.Add(Me.pnnavegacion)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "Presupuestos"
        Me.Text = "pedidos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.pnnavegacion.ResumeLayout(False)
        Me.pnnavegacion.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents cmdlistacarga As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents rdImportar As RadioButton
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents lbltotalPedidos As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents dtphasta As DateTimePicker
    Friend WithEvents dtpdesde As DateTimePicker
    Friend WithEvents Label62 As Label
    Friend WithEvents dgvPedidos As DGVPaginado
    Friend WithEvents Button4 As Button
End Class
