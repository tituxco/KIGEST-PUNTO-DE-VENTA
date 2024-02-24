<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class romaneo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(romaneo))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnDatosFact = New System.Windows.Forms.Panel()
        Me.cmdaceptar = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.pnadd = New System.Windows.Forms.Panel()
        Me.chkBusquedaProd = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbAlmacenHacia = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbalmacen = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblnoplu = New System.Windows.Forms.Label()
        Me.txtcodPLU = New System.Windows.Forms.TextBox()
        Me.txtcantPLU = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dtproductos = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pntitulo.SuspendLayout()
        Me.pnDatosFact.SuspendLayout()
        Me.pnadd.SuspendLayout()
        CType(Me.dtproductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1067, 40)
        Me.pntitulo.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(707, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "TRANSFERENCIA ENTRE SUCURSALES"
        '
        'pnDatosFact
        '
        Me.pnDatosFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnDatosFact.Controls.Add(Me.cmdaceptar)
        Me.pnDatosFact.Controls.Add(Me.cmdsalir)
        Me.pnDatosFact.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDatosFact.Location = New System.Drawing.Point(0, 40)
        Me.pnDatosFact.Name = "pnDatosFact"
        Me.pnDatosFact.Size = New System.Drawing.Size(1067, 99)
        Me.pnDatosFact.TabIndex = 33
        '
        'cmdaceptar
        '
        Me.cmdaceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdaceptar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdaceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdaceptar.ForeColor = System.Drawing.Color.White
        Me.cmdaceptar.Image = CType(resources.GetObject("cmdaceptar.Image"), System.Drawing.Image)
        Me.cmdaceptar.Location = New System.Drawing.Point(863, 0)
        Me.cmdaceptar.Name = "cmdaceptar"
        Me.cmdaceptar.Size = New System.Drawing.Size(102, 99)
        Me.cmdaceptar.TabIndex = 186
        Me.cmdaceptar.Text = "Guardar"
        Me.cmdaceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdaceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdaceptar.UseVisualStyleBackColor = True
        '
        'cmdsalir
        '
        Me.cmdsalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdsalir.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdsalir.ForeColor = System.Drawing.Color.White
        Me.cmdsalir.Image = CType(resources.GetObject("cmdsalir.Image"), System.Drawing.Image)
        Me.cmdsalir.Location = New System.Drawing.Point(965, 0)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(102, 99)
        Me.cmdsalir.TabIndex = 187
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdsalir.UseVisualStyleBackColor = True
        '
        'pnadd
        '
        Me.pnadd.BackColor = System.Drawing.Color.DarkGray
        Me.pnadd.Controls.Add(Me.chkBusquedaProd)
        Me.pnadd.Controls.Add(Me.Label5)
        Me.pnadd.Controls.Add(Me.cmbAlmacenHacia)
        Me.pnadd.Controls.Add(Me.Label8)
        Me.pnadd.Controls.Add(Me.cmbalmacen)
        Me.pnadd.Controls.Add(Me.Label3)
        Me.pnadd.Controls.Add(Me.lblnoplu)
        Me.pnadd.Controls.Add(Me.txtcodPLU)
        Me.pnadd.Controls.Add(Me.txtcantPLU)
        Me.pnadd.Controls.Add(Me.Label25)
        Me.pnadd.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnadd.Location = New System.Drawing.Point(0, 139)
        Me.pnadd.Name = "pnadd"
        Me.pnadd.Size = New System.Drawing.Size(1067, 25)
        Me.pnadd.TabIndex = 81
        '
        'chkBusquedaProd
        '
        Me.chkBusquedaProd.AutoSize = True
        Me.chkBusquedaProd.Location = New System.Drawing.Point(399, 5)
        Me.chkBusquedaProd.Name = "chkBusquedaProd"
        Me.chkBusquedaProd.Size = New System.Drawing.Size(96, 17)
        Me.chkBusquedaProd.TabIndex = 242
        Me.chkBusquedaProd.Text = "BusquedaProd"
        Me.chkBusquedaProd.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(760, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 187
        Me.Label5.Text = "Almacen HACIA"
        '
        'cmbAlmacenHacia
        '
        Me.cmbAlmacenHacia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAlmacenHacia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAlmacenHacia.FormattingEnabled = True
        Me.cmbAlmacenHacia.Location = New System.Drawing.Point(863, 2)
        Me.cmbAlmacenHacia.Name = "cmbAlmacenHacia"
        Me.cmbAlmacenHacia.Size = New System.Drawing.Size(130, 21)
        Me.cmbAlmacenHacia.TabIndex = 186
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(518, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 13)
        Me.Label8.TabIndex = 185
        Me.Label8.Text = "Almacen DESDE"
        '
        'cmbalmacen
        '
        Me.cmbalmacen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbalmacen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbalmacen.FormattingEnabled = True
        Me.cmbalmacen.Location = New System.Drawing.Point(621, 2)
        Me.cmbalmacen.Name = "cmbalmacen"
        Me.cmbalmacen.Size = New System.Drawing.Size(130, 21)
        Me.cmbalmacen.TabIndex = 184
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "Cant."
        '
        'lblnoplu
        '
        Me.lblnoplu.AutoSize = True
        Me.lblnoplu.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnoplu.ForeColor = System.Drawing.Color.Red
        Me.lblnoplu.Location = New System.Drawing.Point(600, 4)
        Me.lblnoplu.Name = "lblnoplu"
        Me.lblnoplu.Size = New System.Drawing.Size(0, 17)
        Me.lblnoplu.TabIndex = 62
        '
        'txtcodPLU
        '
        Me.txtcodPLU.Location = New System.Drawing.Point(198, 3)
        Me.txtcodPLU.Name = "txtcodPLU"
        Me.txtcodPLU.Size = New System.Drawing.Size(195, 20)
        Me.txtcodPLU.TabIndex = 61
        '
        'txtcantPLU
        '
        Me.txtcantPLU.Location = New System.Drawing.Point(48, 3)
        Me.txtcantPLU.Name = "txtcantPLU"
        Me.txtcantPLU.Size = New System.Drawing.Size(40, 20)
        Me.txtcantPLU.TabIndex = 60
        Me.txtcantPLU.Text = "1"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(94, 6)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(97, 16)
        Me.Label25.TabIndex = 59
        Me.Label25.Text = "Ingresar PLU"
        '
        'dtproductos
        '
        Me.dtproductos.AllowUserToResizeColumns = False
        Me.dtproductos.AllowUserToResizeRows = False
        Me.dtproductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtproductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtproductos.BackgroundColor = System.Drawing.Color.White
        Me.dtproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtproductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.plu, Me.cant, Me.producto, Me.Column6, Me.Column4, Me.Column5, Me.Column8})
        Me.dtproductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtproductos.Location = New System.Drawing.Point(0, 164)
        Me.dtproductos.MultiSelect = False
        Me.dtproductos.Name = "dtproductos"
        Me.dtproductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtproductos.Size = New System.Drawing.Size(1067, 387)
        Me.dtproductos.TabIndex = 93
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn1.FillWeight = 10.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 31
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 25.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Codigo/#PLU"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn3.FillWeight = 20.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cant"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 65
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.FillWeight = 140.0!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Producto"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 450
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = "0"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn5.FillWeight = 20.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "IVA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 65
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn6.FillWeight = 20.0!
        Me.DataGridViewTextBoxColumn6.HeaderText = "P. Unit"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        Me.DataGridViewTextBoxColumn6.Width = 64
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = "0"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn7.FillWeight = 20.0!
        Me.DataGridViewTextBoxColumn7.HeaderText = "P. Total"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 57
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn8.FillWeight = 20.0!
        Me.DataGridViewTextBoxColumn8.HeaderText = "PLU"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 241
        '
        'id
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.id.DefaultCellStyle = DataGridViewCellStyle1
        Me.id.FillWeight = 10.0!
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'plu
        '
        Me.plu.FillWeight = 25.0!
        Me.plu.HeaderText = "Codigo/#PLU"
        Me.plu.Name = "plu"
        '
        'cant
        '
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.cant.DefaultCellStyle = DataGridViewCellStyle2
        Me.cant.FillWeight = 20.0!
        Me.cant.HeaderText = "Cant"
        Me.cant.Name = "cant"
        '
        'producto
        '
        Me.producto.FillWeight = 120.0!
        Me.producto.HeaderText = "Producto"
        Me.producto.Name = "producto"
        '
        'Column6
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column6.FillWeight = 20.0!
        Me.Column6.HeaderText = "IVA"
        Me.Column6.Name = "Column6"
        Me.Column6.Visible = False
        '
        'Column4
        '
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column4.FillWeight = 20.0!
        Me.Column4.HeaderText = "P. Unit"
        Me.Column4.Name = "Column4"
        Me.Column4.Visible = False
        '
        'Column5
        '
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column5.FillWeight = 20.0!
        Me.Column5.HeaderText = "Utilidad"
        Me.Column5.Name = "Column5"
        Me.Column5.Visible = False
        '
        'Column8
        '
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column8.FillWeight = 20.0!
        Me.Column8.HeaderText = "P. Final"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Serial"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 241
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Meses gtia."
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 242
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Meses gtia."
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 181
        '
        'romaneo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 551)
        Me.Controls.Add(Me.dtproductos)
        Me.Controls.Add(Me.pnadd)
        Me.Controls.Add(Me.pnDatosFact)
        Me.Controls.Add(Me.pntitulo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "romaneo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "romaneo"
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.pnDatosFact.ResumeLayout(False)
        Me.pnadd.ResumeLayout(False)
        Me.pnadd.PerformLayout()
        CType(Me.dtproductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnDatosFact As System.Windows.Forms.Panel
    Friend WithEvents pnadd As System.Windows.Forms.Panel
    Friend WithEvents lblnoplu As System.Windows.Forms.Label
    Friend WithEvents txtcodPLU As System.Windows.Forms.TextBox
    Friend WithEvents txtcantPLU As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbalmacen As ComboBox
    Friend WithEvents cmdaceptar As Button
    Friend WithEvents cmdsalir As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbAlmacenHacia As ComboBox
    Friend WithEvents dtproductos As DataGridView
    Friend WithEvents chkBusquedaProd As CheckBox
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents plu As DataGridViewTextBoxColumn
    Friend WithEvents cant As DataGridViewTextBoxColumn
    Friend WithEvents producto As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
End Class
