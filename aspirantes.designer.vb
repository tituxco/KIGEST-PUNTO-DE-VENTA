<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmaspirantes
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmaspirantes))
        Me.pnnavegacion = New System.Windows.Forms.Panel()
        Me.lblestado = New System.Windows.Forms.Label()
        Me.cmdeliminar = New System.Windows.Forms.Button()
        Me.cmdaceptar = New System.Windows.Forms.Button()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdmodificar = New System.Windows.Forms.Button()
        Me.cmdnuevapers = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbprogresocons = New System.Windows.Forms.ProgressBar()
        Me.pnlistaclientes = New System.Windows.Forms.Panel()
        Me.txtbuscar = New System.Windows.Forms.TextBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmbvendedor = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtnumeroclie = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmblistas = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcuit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcontactos = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtmail = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcelular = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtdomicilio = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtobservaciones = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cmblocalidad = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbcondiva = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtrazon = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkvendedor = New System.Windows.Forms.CheckBox()
        Me.cmbvendedor_lst = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chklocalidad = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.cmblistaloca = New System.Windows.Forms.ComboBox()
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.dgvClientes = New SIGT__KIGEST.DGVPaginado()
        Me.dgvlistaClientes = New SIGT__KIGEST.DGVPaginado()
        Me.pnnavegacion.SuspendLayout()
        Me.pntitulo.SuspendLayout()
        Me.pnlistaclientes.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnnavegacion
        '
        Me.pnnavegacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnnavegacion.Controls.Add(Me.lblestado)
        Me.pnnavegacion.Controls.Add(Me.cmdeliminar)
        Me.pnnavegacion.Controls.Add(Me.cmdaceptar)
        Me.pnnavegacion.Controls.Add(Me.cmdcancelar)
        Me.pnnavegacion.Controls.Add(Me.cmdmodificar)
        Me.pnnavegacion.Controls.Add(Me.cmdnuevapers)
        Me.pnnavegacion.Controls.Add(Me.cmdsalir)
        Me.pnnavegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnnavegacion.Location = New System.Drawing.Point(0, 40)
        Me.pnnavegacion.Name = "pnnavegacion"
        Me.pnnavegacion.Size = New System.Drawing.Size(1107, 89)
        Me.pnnavegacion.TabIndex = 7
        '
        'lblestado
        '
        Me.lblestado.BackColor = System.Drawing.Color.Transparent
        Me.lblestado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblestado.ForeColor = System.Drawing.Color.Lime
        Me.lblestado.Location = New System.Drawing.Point(237, 0)
        Me.lblestado.Name = "lblestado"
        Me.lblestado.Size = New System.Drawing.Size(587, 89)
        Me.lblestado.TabIndex = 36
        Me.lblestado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdeliminar
        '
        Me.cmdeliminar.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdeliminar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdeliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdeliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdeliminar.ForeColor = System.Drawing.Color.White
        Me.cmdeliminar.Image = CType(resources.GetObject("cmdeliminar.Image"), System.Drawing.Image)
        Me.cmdeliminar.Location = New System.Drawing.Point(158, 0)
        Me.cmdeliminar.Name = "cmdeliminar"
        Me.cmdeliminar.Size = New System.Drawing.Size(79, 89)
        Me.cmdeliminar.TabIndex = 31
        Me.cmdeliminar.Text = "Eliminar"
        Me.cmdeliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdeliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdeliminar.UseVisualStyleBackColor = True
        '
        'cmdaceptar
        '
        Me.cmdaceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdaceptar.Enabled = False
        Me.cmdaceptar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdaceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdaceptar.ForeColor = System.Drawing.Color.White
        Me.cmdaceptar.Image = CType(resources.GetObject("cmdaceptar.Image"), System.Drawing.Image)
        Me.cmdaceptar.Location = New System.Drawing.Point(824, 0)
        Me.cmdaceptar.Name = "cmdaceptar"
        Me.cmdaceptar.Size = New System.Drawing.Size(102, 89)
        Me.cmdaceptar.TabIndex = 30
        Me.cmdaceptar.Text = "Guardar"
        Me.cmdaceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdaceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdaceptar.UseVisualStyleBackColor = True
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdcancelar.Enabled = False
        Me.cmdcancelar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdcancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.White
        Me.cmdcancelar.Image = CType(resources.GetObject("cmdcancelar.Image"), System.Drawing.Image)
        Me.cmdcancelar.Location = New System.Drawing.Point(926, 0)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(93, 89)
        Me.cmdcancelar.TabIndex = 27
        Me.cmdcancelar.Text = "Cancelar"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdcancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdcancelar.UseVisualStyleBackColor = True
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
        Me.cmdmodificar.Size = New System.Drawing.Size(83, 89)
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
        Me.cmdnuevapers.Size = New System.Drawing.Size(75, 89)
        Me.cmdnuevapers.TabIndex = 18
        Me.cmdnuevapers.Text = "Agregar"
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
        Me.cmdsalir.Location = New System.Drawing.Point(1019, 0)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(88, 89)
        Me.cmdsalir.TabIndex = 17
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdsalir.UseVisualStyleBackColor = True
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1107, 40)
        Me.pntitulo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CLIENTES"
        '
        'pbprogresocons
        '
        Me.pbprogresocons.Location = New System.Drawing.Point(3, 554)
        Me.pbprogresocons.Name = "pbprogresocons"
        Me.pbprogresocons.Size = New System.Drawing.Size(300, 14)
        Me.pbprogresocons.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbprogresocons.TabIndex = 60
        Me.pbprogresocons.Visible = False
        '
        'pnlistaclientes
        '
        Me.pnlistaclientes.Controls.Add(Me.dgvClientes)
        Me.pnlistaclientes.Controls.Add(Me.txtbuscar)
        Me.pnlistaclientes.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlistaclientes.Location = New System.Drawing.Point(3, 3)
        Me.pnlistaclientes.Name = "pnlistaclientes"
        Me.pnlistaclientes.Size = New System.Drawing.Size(372, 445)
        Me.pnlistaclientes.TabIndex = 63
        '
        'txtbuscar
        '
        Me.txtbuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbuscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbuscar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtbuscar.Location = New System.Drawing.Point(0, 0)
        Me.txtbuscar.Name = "txtbuscar"
        Me.txtbuscar.Size = New System.Drawing.Size(372, 22)
        Me.txtbuscar.TabIndex = 62
        Me.txtbuscar.Text = "INGRESE CLIENTE A BUSCAR"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage2)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(0, 129)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1107, 477)
        Me.TabControl2.TabIndex = 65
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TabControl1)
        Me.TabPage2.Controls.Add(Me.pnlistaclientes)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1099, 451)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "ABM CLIENTES"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(375, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(721, 445)
        Me.TabControl1.TabIndex = 65
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.Controls.Add(Me.cmbvendedor)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtnumeroclie)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cmblistas)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtcuit)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtcontactos)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtmail)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtcelular)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txttelefono)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtdomicilio)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.txtobservaciones)
        Me.TabPage1.Controls.Add(Me.Label42)
        Me.TabPage1.Controls.Add(Me.cmblocalidad)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.cmbcondiva)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtrazon)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(713, 416)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos personales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmbvendedor
        '
        Me.cmbvendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbvendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbvendedor.FormattingEnabled = True
        Me.cmbvendedor.Location = New System.Drawing.Point(263, 360)
        Me.cmbvendedor.Name = "cmbvendedor"
        Me.cmbvendedor.Size = New System.Drawing.Size(236, 24)
        Me.cmbvendedor.TabIndex = 205
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(260, 341)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 16)
        Me.Label8.TabIndex = 206
        Me.Label8.Text = "Vendedor"
        '
        'txtnumeroclie
        '
        Me.txtnumeroclie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumeroclie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumeroclie.ForeColor = System.Drawing.Color.Red
        Me.txtnumeroclie.Location = New System.Drawing.Point(340, 24)
        Me.txtnumeroclie.Name = "txtnumeroclie"
        Me.txtnumeroclie.Size = New System.Drawing.Size(160, 22)
        Me.txtnumeroclie.TabIndex = 203
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(337, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 16)
        Me.Label6.TabIndex = 204
        Me.Label6.Text = "CodigoClie"
        '
        'cmblistas
        '
        Me.cmblistas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmblistas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmblistas.FormattingEnabled = True
        Me.cmblistas.Location = New System.Drawing.Point(264, 314)
        Me.cmblistas.Name = "cmblistas"
        Me.cmblistas.Size = New System.Drawing.Size(236, 24)
        Me.cmblistas.TabIndex = 201
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(261, 295)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 16)
        Me.Label5.TabIndex = 202
        Me.Label5.Text = "Lista de precios"
        '
        'txtcuit
        '
        Me.txtcuit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcuit.Location = New System.Drawing.Point(340, 68)
        Me.txtcuit.Name = "txtcuit"
        Me.txtcuit.Size = New System.Drawing.Size(160, 22)
        Me.txtcuit.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(337, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 200
        Me.Label3.Text = "CUIT"
        '
        'txtcontactos
        '
        Me.txtcontactos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontactos.Location = New System.Drawing.Point(0, 314)
        Me.txtcontactos.Multiline = True
        Me.txtcontactos.Name = "txtcontactos"
        Me.txtcontactos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtcontactos.Size = New System.Drawing.Size(261, 70)
        Me.txtcontactos.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(-3, 295)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 16)
        Me.Label10.TabIndex = 198
        Me.Label10.Text = "Contactos:"
        '
        'txtmail
        '
        Me.txtmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmail.Location = New System.Drawing.Point(0, 264)
        Me.txtmail.Name = "txtmail"
        Me.txtmail.Size = New System.Drawing.Size(500, 22)
        Me.txtmail.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(-3, 245)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 16)
        Me.Label9.TabIndex = 196
        Me.Label9.Text = "Mail:"
        '
        'txtcelular
        '
        Me.txtcelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcelular.Location = New System.Drawing.Point(263, 216)
        Me.txtcelular.Name = "txtcelular"
        Me.txtcelular.Size = New System.Drawing.Size(237, 22)
        Me.txtcelular.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(260, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 16)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "Celular:"
        '
        'txttelefono
        '
        Me.txttelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttelefono.Location = New System.Drawing.Point(0, 216)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(250, 22)
        Me.txttelefono.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(-3, 197)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 16)
        Me.Label11.TabIndex = 187
        Me.Label11.Text = "Teléfono:"
        '
        'txtdomicilio
        '
        Me.txtdomicilio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdomicilio.Location = New System.Drawing.Point(0, 111)
        Me.txtdomicilio.Name = "txtdomicilio"
        Me.txtdomicilio.Size = New System.Drawing.Size(500, 22)
        Me.txtdomicilio.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(-3, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 16)
        Me.Label15.TabIndex = 185
        Me.Label15.Text = "Domicilio:"
        '
        'txtobservaciones
        '
        Me.txtobservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobservaciones.Location = New System.Drawing.Point(0, 415)
        Me.txtobservaciones.Multiline = True
        Me.txtobservaciones.Name = "txtobservaciones"
        Me.txtobservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtobservaciones.Size = New System.Drawing.Size(500, 63)
        Me.txtobservaciones.TabIndex = 9
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(-3, 396)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(117, 16)
        Me.Label42.TabIndex = 183
        Me.Label42.Text = "Observaciones:"
        '
        'cmblocalidad
        '
        Me.cmblocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmblocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmblocalidad.FormattingEnabled = True
        Me.cmblocalidad.Location = New System.Drawing.Point(0, 164)
        Me.cmblocalidad.Name = "cmblocalidad"
        Me.cmblocalidad.Size = New System.Drawing.Size(500, 24)
        Me.cmblocalidad.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(-3, 145)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 16)
        Me.Label16.TabIndex = 182
        Me.Label16.Text = "Localidad:"
        '
        'cmbcondiva
        '
        Me.cmbcondiva.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcondiva.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcondiva.FormattingEnabled = True
        Me.cmbcondiva.Location = New System.Drawing.Point(0, 68)
        Me.cmbcondiva.Name = "cmbcondiva"
        Me.cmbcondiva.Size = New System.Drawing.Size(334, 24)
        Me.cmbcondiva.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(-3, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 16)
        Me.Label13.TabIndex = 164
        Me.Label13.Text = "Cond. IVA"
        '
        'txtrazon
        '
        Me.txtrazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrazon.Location = New System.Drawing.Point(0, 24)
        Me.txtrazon.Name = "txtrazon"
        Me.txtrazon.Size = New System.Drawing.Size(334, 22)
        Me.txtrazon.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(2, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(249, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Apellido y nombres / Razon social:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvlistaClientes)
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1099, 451)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "Listados"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.chkvendedor)
        Me.Panel1.Controls.Add(Me.cmbvendedor_lst)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.chklocalidad)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmdbuscar)
        Me.Panel1.Controls.Add(Me.cmblistaloca)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1093, 74)
        Me.Panel1.TabIndex = 0
        '
        'chkvendedor
        '
        Me.chkvendedor.AutoSize = True
        Me.chkvendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkvendedor.ForeColor = System.Drawing.Color.White
        Me.chkvendedor.Location = New System.Drawing.Point(381, 13)
        Me.chkvendedor.Name = "chkvendedor"
        Me.chkvendedor.Size = New System.Drawing.Size(106, 24)
        Me.chkvendedor.TabIndex = 69
        Me.chkvendedor.Text = "Vendedor"
        Me.chkvendedor.UseVisualStyleBackColor = True
        '
        'cmbvendedor_lst
        '
        Me.cmbvendedor_lst.Enabled = False
        Me.cmbvendedor_lst.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbvendedor_lst.FormattingEnabled = True
        Me.cmbvendedor_lst.Location = New System.Drawing.Point(381, 37)
        Me.cmbvendedor_lst.Name = "cmbvendedor_lst"
        Me.cmbvendedor_lst.Size = New System.Drawing.Size(331, 24)
        Me.cmbvendedor_lst.TabIndex = 68
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(855, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 74)
        Me.Button2.TabIndex = 67
        Me.Button2.Text = "Exportar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'chklocalidad
        '
        Me.chklocalidad.AutoSize = True
        Me.chklocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklocalidad.ForeColor = System.Drawing.Color.White
        Me.chklocalidad.Location = New System.Drawing.Point(5, 16)
        Me.chklocalidad.Name = "chklocalidad"
        Me.chklocalidad.Size = New System.Drawing.Size(105, 24)
        Me.chklocalidad.TabIndex = 66
        Me.chklocalidad.Text = "Localidad"
        Me.chklocalidad.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(930, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 74)
        Me.Button1.TabIndex = 65
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
        Me.cmdbuscar.ForeColor = System.Drawing.Color.White
        Me.cmdbuscar.Image = CType(resources.GetObject("cmdbuscar.Image"), System.Drawing.Image)
        Me.cmdbuscar.Location = New System.Drawing.Point(1012, 0)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(81, 74)
        Me.cmdbuscar.TabIndex = 64
        Me.cmdbuscar.Text = "Buscar"
        Me.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscar.UseVisualStyleBackColor = False
        '
        'cmblistaloca
        '
        Me.cmblistaloca.Enabled = False
        Me.cmblistaloca.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmblistaloca.FormattingEnabled = True
        Me.cmblistaloca.Location = New System.Drawing.Point(5, 40)
        Me.cmblistaloca.Name = "cmblistaloca"
        Me.cmblistaloca.Size = New System.Drawing.Size(331, 24)
        Me.cmblistaloca.TabIndex = 63
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = GetType(System.Configuration.ApplicationSettingsBase)
        '
        'dgvClientes
        '
        Me.dgvClientes.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvClientes.Location = New System.Drawing.Point(0, 22)
        Me.dgvClientes.Name = "dgvClientes"
        Me.dgvClientes.Size = New System.Drawing.Size(372, 423)
        Me.dgvClientes.TabIndex = 63
        '
        'dgvlistaClientes
        '
        Me.dgvlistaClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvlistaClientes.Location = New System.Drawing.Point(3, 77)
        Me.dgvlistaClientes.Name = "dgvlistaClientes"
        Me.dgvlistaClientes.Size = New System.Drawing.Size(1093, 371)
        Me.dgvlistaClientes.TabIndex = 1
        '
        'frmaspirantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1107, 606)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.pbprogresocons)
        Me.Controls.Add(Me.pnnavegacion)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "frmaspirantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnnavegacion.ResumeLayout(False)
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.pnlistaclientes.ResumeLayout(False)
        Me.pnlistaclientes.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnnavegacion As System.Windows.Forms.Panel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdmodificar As System.Windows.Forms.Button
    Friend WithEvents cmdnuevapers As System.Windows.Forms.Button
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents pbprogresocons As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents pnlistaclientes As System.Windows.Forms.Panel
    Friend WithEvents txtbuscar As System.Windows.Forms.TextBox
    Friend WithEvents cmdaceptar As System.Windows.Forms.Button
    Friend WithEvents cmdeliminar As System.Windows.Forms.Button
    Friend WithEvents lblestado As System.Windows.Forms.Label
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtnumeroclie As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmblistas As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcuit As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcontactos As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtmail As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtcelular As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txttelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtdomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtobservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cmblocalidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbcondiva As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtrazon As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmblistaloca As System.Windows.Forms.ComboBox
    Friend WithEvents cmdbuscar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbvendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chklocalidad As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents chkvendedor As CheckBox
    Friend WithEvents cmbvendedor_lst As ComboBox
    Friend WithEvents dgvClientes As DGVPaginado
    Friend WithEvents dgvlistaClientes As DGVPaginado
End Class
