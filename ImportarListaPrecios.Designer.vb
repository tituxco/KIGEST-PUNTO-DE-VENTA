<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportacionPrecios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportacionPrecios))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblcantprod = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdimportar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.chkutilidad = New System.Windows.Forms.CheckBox()
        Me.chkimportiva = New System.Windows.Forms.CheckBox()
        Me.chkimportprecio = New System.Windows.Forms.CheckBox()
        Me.chkimportpresentacion = New System.Windows.Forms.CheckBox()
        Me.chkimportcodbar = New System.Windows.Forms.CheckBox()
        Me.chkimportdescripcion = New System.Windows.Forms.CheckBox()
        Me.chkimportcateg = New System.Windows.Forms.CheckBox()
        Me.chkimportproveedor = New System.Windows.Forms.CheckBox()
        Me.cmbcategoriaimport = New System.Windows.Forms.ComboBox()
        Me.cmbproveedorimport = New System.Windows.Forms.ComboBox()
        Me.txtlistaimportaiva = New System.Windows.Forms.TextBox()
        Me.chkcalcularprecio = New System.Windows.Forms.CheckBox()
        Me.txtgananciagral = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.dtimportados = New System.Windows.Forms.DataGridView()
        Me.ImportarListaPrecios2 = New System.ComponentModel.BackgroundWorker()
        Me.pntitulo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dtimportados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1076, 40)
        Me.pntitulo.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(549, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "IMPORTAR LISTA DE PRECIOS"
        '
        'lblcantprod
        '
        Me.lblcantprod.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblcantprod.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcantprod.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblcantprod.Location = New System.Drawing.Point(571, 0)
        Me.lblcantprod.Name = "lblcantprod"
        Me.lblcantprod.Size = New System.Drawing.Size(246, 95)
        Me.lblcantprod.TabIndex = 2
        Me.lblcantprod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblcantprod)
        Me.Panel2.Controls.Add(Me.cmdimportar)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.cmdsalir)
        Me.Panel2.Controls.Add(Me.chkutilidad)
        Me.Panel2.Controls.Add(Me.chkimportiva)
        Me.Panel2.Controls.Add(Me.chkimportprecio)
        Me.Panel2.Controls.Add(Me.chkimportpresentacion)
        Me.Panel2.Controls.Add(Me.chkimportcodbar)
        Me.Panel2.Controls.Add(Me.chkimportdescripcion)
        Me.Panel2.Controls.Add(Me.chkimportcateg)
        Me.Panel2.Controls.Add(Me.chkimportproveedor)
        Me.Panel2.Controls.Add(Me.cmbcategoriaimport)
        Me.Panel2.Controls.Add(Me.cmbproveedorimport)
        Me.Panel2.Controls.Add(Me.txtlistaimportaiva)
        Me.Panel2.Controls.Add(Me.chkcalcularprecio)
        Me.Panel2.Controls.Add(Me.txtgananciagral)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1076, 95)
        Me.Panel2.TabIndex = 73
        '
        'cmdimportar
        '
        Me.cmdimportar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdimportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdimportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdimportar.ForeColor = System.Drawing.Color.White
        Me.cmdimportar.Image = CType(resources.GetObject("cmdimportar.Image"), System.Drawing.Image)
        Me.cmdimportar.Location = New System.Drawing.Point(817, 0)
        Me.cmdimportar.Name = "cmdimportar"
        Me.cmdimportar.Size = New System.Drawing.Size(80, 95)
        Me.cmdimportar.TabIndex = 1
        Me.cmdimportar.Text = "Importar"
        Me.cmdimportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdimportar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(897, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(83, 95)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Archivo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdsalir
        '
        Me.cmdsalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdsalir.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdsalir.ForeColor = System.Drawing.Color.White
        Me.cmdsalir.Image = CType(resources.GetObject("cmdsalir.Image"), System.Drawing.Image)
        Me.cmdsalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdsalir.Location = New System.Drawing.Point(980, 0)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(96, 95)
        Me.cmdsalir.TabIndex = 250
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdsalir.UseVisualStyleBackColor = True
        '
        'chkutilidad
        '
        Me.chkutilidad.AutoSize = True
        Me.chkutilidad.ForeColor = System.Drawing.Color.White
        Me.chkutilidad.Location = New System.Drawing.Point(411, 3)
        Me.chkutilidad.Name = "chkutilidad"
        Me.chkutilidad.Size = New System.Drawing.Size(78, 17)
        Me.chkutilidad.TabIndex = 249
        Me.chkutilidad.Text = "Utilidad0 %"
        Me.chkutilidad.UseVisualStyleBackColor = True
        '
        'chkimportiva
        '
        Me.chkimportiva.AutoSize = True
        Me.chkimportiva.Checked = True
        Me.chkimportiva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkimportiva.Enabled = False
        Me.chkimportiva.ForeColor = System.Drawing.Color.White
        Me.chkimportiva.Location = New System.Drawing.Point(385, 58)
        Me.chkimportiva.Name = "chkimportiva"
        Me.chkimportiva.Size = New System.Drawing.Size(43, 17)
        Me.chkimportiva.TabIndex = 248
        Me.chkimportiva.Text = "IVA"
        Me.chkimportiva.UseVisualStyleBackColor = True
        '
        'chkimportprecio
        '
        Me.chkimportprecio.AutoSize = True
        Me.chkimportprecio.Checked = True
        Me.chkimportprecio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkimportprecio.Enabled = False
        Me.chkimportprecio.ForeColor = System.Drawing.Color.White
        Me.chkimportprecio.Location = New System.Drawing.Point(289, 58)
        Me.chkimportprecio.Name = "chkimportprecio"
        Me.chkimportprecio.Size = New System.Drawing.Size(79, 17)
        Me.chkimportprecio.TabIndex = 247
        Me.chkimportprecio.Text = "Pcio. costo"
        Me.chkimportprecio.UseVisualStyleBackColor = True
        '
        'chkimportpresentacion
        '
        Me.chkimportpresentacion.AutoSize = True
        Me.chkimportpresentacion.Checked = True
        Me.chkimportpresentacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkimportpresentacion.ForeColor = System.Drawing.Color.White
        Me.chkimportpresentacion.Location = New System.Drawing.Point(187, 58)
        Me.chkimportpresentacion.Name = "chkimportpresentacion"
        Me.chkimportpresentacion.Size = New System.Drawing.Size(88, 17)
        Me.chkimportpresentacion.TabIndex = 246
        Me.chkimportpresentacion.Text = "Presentación"
        Me.chkimportpresentacion.UseVisualStyleBackColor = True
        '
        'chkimportcodbar
        '
        Me.chkimportcodbar.AutoSize = True
        Me.chkimportcodbar.Checked = True
        Me.chkimportcodbar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkimportcodbar.ForeColor = System.Drawing.Color.White
        Me.chkimportcodbar.Location = New System.Drawing.Point(98, 58)
        Me.chkimportcodbar.Name = "chkimportcodbar"
        Me.chkimportcodbar.Size = New System.Drawing.Size(69, 17)
        Me.chkimportcodbar.TabIndex = 245
        Me.chkimportcodbar.Text = "Cod_barr"
        Me.chkimportcodbar.UseVisualStyleBackColor = True
        '
        'chkimportdescripcion
        '
        Me.chkimportdescripcion.AutoSize = True
        Me.chkimportdescripcion.Checked = True
        Me.chkimportdescripcion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkimportdescripcion.Enabled = False
        Me.chkimportdescripcion.ForeColor = System.Drawing.Color.White
        Me.chkimportdescripcion.Location = New System.Drawing.Point(2, 58)
        Me.chkimportdescripcion.Name = "chkimportdescripcion"
        Me.chkimportdescripcion.Size = New System.Drawing.Size(82, 17)
        Me.chkimportdescripcion.TabIndex = 244
        Me.chkimportdescripcion.Text = "Descripción"
        Me.chkimportdescripcion.UseVisualStyleBackColor = True
        '
        'chkimportcateg
        '
        Me.chkimportcateg.AutoSize = True
        Me.chkimportcateg.ForeColor = System.Drawing.Color.White
        Me.chkimportcateg.Location = New System.Drawing.Point(231, 3)
        Me.chkimportcateg.Name = "chkimportcateg"
        Me.chkimportcateg.Size = New System.Drawing.Size(71, 17)
        Me.chkimportcateg.TabIndex = 243
        Me.chkimportcateg.Text = "Categoria"
        Me.chkimportcateg.UseVisualStyleBackColor = True
        '
        'chkimportproveedor
        '
        Me.chkimportproveedor.AutoSize = True
        Me.chkimportproveedor.Checked = True
        Me.chkimportproveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkimportproveedor.ForeColor = System.Drawing.Color.White
        Me.chkimportproveedor.Location = New System.Drawing.Point(49, 3)
        Me.chkimportproveedor.Name = "chkimportproveedor"
        Me.chkimportproveedor.Size = New System.Drawing.Size(75, 17)
        Me.chkimportproveedor.TabIndex = 242
        Me.chkimportproveedor.Text = "Proveedor"
        Me.chkimportproveedor.UseVisualStyleBackColor = True
        '
        'cmbcategoriaimport
        '
        Me.cmbcategoriaimport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcategoriaimport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcategoriaimport.FormattingEnabled = True
        Me.cmbcategoriaimport.Location = New System.Drawing.Point(231, 25)
        Me.cmbcategoriaimport.Name = "cmbcategoriaimport"
        Me.cmbcategoriaimport.Size = New System.Drawing.Size(173, 21)
        Me.cmbcategoriaimport.TabIndex = 240
        '
        'cmbproveedorimport
        '
        Me.cmbproveedorimport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbproveedorimport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbproveedorimport.FormattingEnabled = True
        Me.cmbproveedorimport.Location = New System.Drawing.Point(49, 25)
        Me.cmbproveedorimport.Name = "cmbproveedorimport"
        Me.cmbproveedorimport.Size = New System.Drawing.Size(176, 21)
        Me.cmbproveedorimport.TabIndex = 238
        '
        'txtlistaimportaiva
        '
        Me.txtlistaimportaiva.Location = New System.Drawing.Point(439, 56)
        Me.txtlistaimportaiva.Name = "txtlistaimportaiva"
        Me.txtlistaimportaiva.Size = New System.Drawing.Size(49, 20)
        Me.txtlistaimportaiva.TabIndex = 9
        Me.txtlistaimportaiva.Text = "21"
        '
        'chkcalcularprecio
        '
        Me.chkcalcularprecio.AutoSize = True
        Me.chkcalcularprecio.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkcalcularprecio.Checked = True
        Me.chkcalcularprecio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkcalcularprecio.ForeColor = System.Drawing.Color.White
        Me.chkcalcularprecio.Location = New System.Drawing.Point(66, 26)
        Me.chkcalcularprecio.Name = "chkcalcularprecio"
        Me.chkcalcularprecio.Size = New System.Drawing.Size(119, 17)
        Me.chkcalcularprecio.TabIndex = 7
        Me.chkcalcularprecio.Text = "Calcular Precio Gral"
        Me.chkcalcularprecio.UseVisualStyleBackColor = True
        Me.chkcalcularprecio.Visible = False
        '
        'txtgananciagral
        '
        Me.txtgananciagral.Location = New System.Drawing.Point(411, 26)
        Me.txtgananciagral.Name = "txtgananciagral"
        Me.txtgananciagral.Size = New System.Drawing.Size(100, 20)
        Me.txtgananciagral.TabIndex = 6
        Me.txtgananciagral.Text = "1"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(0, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(43, 53)
        Me.Button4.TabIndex = 4
        Me.Button4.UseVisualStyleBackColor = False
        '
        'dtimportados
        '
        Me.dtimportados.AllowUserToAddRows = False
        Me.dtimportados.AllowUserToOrderColumns = True
        Me.dtimportados.BackgroundColor = System.Drawing.Color.White
        Me.dtimportados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtimportados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtimportados.Location = New System.Drawing.Point(0, 135)
        Me.dtimportados.Name = "dtimportados"
        Me.dtimportados.Size = New System.Drawing.Size(1076, 334)
        Me.dtimportados.TabIndex = 74
        '
        'ImportarListaPrecios2
        '
        Me.ImportarListaPrecios2.WorkerReportsProgress = True
        Me.ImportarListaPrecios2.WorkerSupportsCancellation = True
        '
        'ImportacionPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1076, 469)
        Me.Controls.Add(Me.dtimportados)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "ImportacionPrecios"
        Me.Text = "ImportarListaPrecios"
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtimportados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblcantprod As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkutilidad As CheckBox
    Friend WithEvents chkimportiva As CheckBox
    Friend WithEvents chkimportprecio As CheckBox
    Friend WithEvents chkimportpresentacion As CheckBox
    Friend WithEvents chkimportcodbar As CheckBox
    Friend WithEvents chkimportdescripcion As CheckBox
    Friend WithEvents chkimportcateg As CheckBox
    Friend WithEvents chkimportproveedor As CheckBox
    Friend WithEvents cmbcategoriaimport As ComboBox
    Friend WithEvents cmbproveedorimport As ComboBox
    Friend WithEvents txtlistaimportaiva As TextBox
    Friend WithEvents chkcalcularprecio As CheckBox
    Friend WithEvents txtgananciagral As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents cmdimportar As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents dtimportados As DataGridView
    Friend WithEvents ImportarListaPrecios2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmdsalir As Button
End Class
