<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class listadoPublicidades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(listadoPublicidades))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabListadoSerivicios = New System.Windows.Forms.TabPage()
        Me.pnnavegacion = New System.Windows.Forms.Panel()
        Me.cmbvendedor = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdOper = New System.Windows.Forms.RadioButton()
        Me.chksinFact = New System.Windows.Forms.CheckBox()
        Me.rdAVencer = New System.Windows.Forms.RadioButton()
        Me.rdvigentes = New System.Windows.Forms.RadioButton()
        Me.chkSoloMorosos = New System.Windows.Forms.CheckBox()
        Me.btnFacturar = New System.Windows.Forms.Button()
        Me.dtdesdefact = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtdiasmora = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnNuevaPublicidad = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmdver = New System.Windows.Forms.Button()
        Me.txtbuscar = New System.Windows.Forms.TextBox()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvPrestamos = New SIGT__KIGEST.DGVPaginado()
        Me.TabControl1.SuspendLayout()
        Me.tabListadoSerivicios.SuspendLayout()
        Me.pnnavegacion.SuspendLayout()
        Me.pntitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabListadoSerivicios)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1222, 453)
        Me.TabControl1.TabIndex = 76
        '
        'tabListadoSerivicios
        '
        Me.tabListadoSerivicios.Controls.Add(Me.dgvPrestamos)
        Me.tabListadoSerivicios.Controls.Add(Me.pnnavegacion)
        Me.tabListadoSerivicios.Location = New System.Drawing.Point(4, 22)
        Me.tabListadoSerivicios.Name = "tabListadoSerivicios"
        Me.tabListadoSerivicios.Padding = New System.Windows.Forms.Padding(3)
        Me.tabListadoSerivicios.Size = New System.Drawing.Size(1214, 427)
        Me.tabListadoSerivicios.TabIndex = 0
        Me.tabListadoSerivicios.Text = "Listado"
        Me.tabListadoSerivicios.UseVisualStyleBackColor = True
        '
        'pnnavegacion
        '
        Me.pnnavegacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnnavegacion.Controls.Add(Me.cmbvendedor)
        Me.pnnavegacion.Controls.Add(Me.Label5)
        Me.pnnavegacion.Controls.Add(Me.rdOper)
        Me.pnnavegacion.Controls.Add(Me.chksinFact)
        Me.pnnavegacion.Controls.Add(Me.rdAVencer)
        Me.pnnavegacion.Controls.Add(Me.rdvigentes)
        Me.pnnavegacion.Controls.Add(Me.chkSoloMorosos)
        Me.pnnavegacion.Controls.Add(Me.btnFacturar)
        Me.pnnavegacion.Controls.Add(Me.dtdesdefact)
        Me.pnnavegacion.Controls.Add(Me.Label8)
        Me.pnnavegacion.Controls.Add(Me.Label4)
        Me.pnnavegacion.Controls.Add(Me.Label3)
        Me.pnnavegacion.Controls.Add(Me.txtdiasmora)
        Me.pnnavegacion.Controls.Add(Me.Label2)
        Me.pnnavegacion.Controls.Add(Me.btnNuevaPublicidad)
        Me.pnnavegacion.Controls.Add(Me.cmdbuscar)
        Me.pnnavegacion.Controls.Add(Me.Label36)
        Me.pnnavegacion.Controls.Add(Me.cmdver)
        Me.pnnavegacion.Controls.Add(Me.txtbuscar)
        Me.pnnavegacion.Controls.Add(Me.btnExportar)
        Me.pnnavegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnnavegacion.Location = New System.Drawing.Point(3, 3)
        Me.pnnavegacion.Name = "pnnavegacion"
        Me.pnnavegacion.Size = New System.Drawing.Size(1208, 89)
        Me.pnnavegacion.TabIndex = 76
        '
        'cmbvendedor
        '
        Me.cmbvendedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbvendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbvendedor.ForeColor = System.Drawing.Color.White
        Me.cmbvendedor.FormattingEnabled = True
        Me.cmbvendedor.Location = New System.Drawing.Point(473, 32)
        Me.cmbvendedor.Name = "cmbvendedor"
        Me.cmbvendedor.Size = New System.Drawing.Size(185, 23)
        Me.cmbvendedor.TabIndex = 204
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(470, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 203
        Me.Label5.Text = "Vendedor"
        '
        'rdOper
        '
        Me.rdOper.AutoSize = True
        Me.rdOper.ForeColor = System.Drawing.Color.White
        Me.rdOper.Location = New System.Drawing.Point(230, 15)
        Me.rdOper.Name = "rdOper"
        Me.rdOper.Size = New System.Drawing.Size(74, 17)
        Me.rdOper.TabIndex = 202
        Me.rdOper.Text = "Vista Oper"
        Me.rdOper.UseVisualStyleBackColor = True
        '
        'chksinFact
        '
        Me.chksinFact.AutoSize = True
        Me.chksinFact.ForeColor = System.Drawing.Color.White
        Me.chksinFact.Location = New System.Drawing.Point(175, 38)
        Me.chksinFact.Name = "chksinFact"
        Me.chksinFact.Size = New System.Drawing.Size(107, 17)
        Me.chksinFact.TabIndex = 201
        Me.chksinFact.Text = "Sin Factura ACT."
        Me.chksinFact.UseVisualStyleBackColor = True
        '
        'rdAVencer
        '
        Me.rdAVencer.AutoSize = True
        Me.rdAVencer.ForeColor = System.Drawing.Color.White
        Me.rdAVencer.Location = New System.Drawing.Point(156, 15)
        Me.rdAVencer.Name = "rdAVencer"
        Me.rdAVencer.Size = New System.Drawing.Size(68, 17)
        Me.rdAVencer.TabIndex = 200
        Me.rdAVencer.Text = "A vencer"
        Me.rdAVencer.UseVisualStyleBackColor = True
        '
        'rdvigentes
        '
        Me.rdvigentes.AutoSize = True
        Me.rdvigentes.Checked = True
        Me.rdvigentes.ForeColor = System.Drawing.Color.White
        Me.rdvigentes.Location = New System.Drawing.Point(84, 15)
        Me.rdvigentes.Name = "rdvigentes"
        Me.rdvigentes.Size = New System.Drawing.Size(66, 17)
        Me.rdvigentes.TabIndex = 199
        Me.rdvigentes.TabStop = True
        Me.rdvigentes.Text = "Vigentes"
        Me.rdvigentes.UseVisualStyleBackColor = True
        '
        'chkSoloMorosos
        '
        Me.chkSoloMorosos.AutoSize = True
        Me.chkSoloMorosos.ForeColor = System.Drawing.Color.White
        Me.chkSoloMorosos.Location = New System.Drawing.Point(84, 38)
        Me.chkSoloMorosos.Name = "chkSoloMorosos"
        Me.chkSoloMorosos.Size = New System.Drawing.Size(89, 17)
        Me.chkSoloMorosos.TabIndex = 198
        Me.chkSoloMorosos.Text = "Solo morosos"
        Me.chkSoloMorosos.UseVisualStyleBackColor = True
        '
        'btnFacturar
        '
        Me.btnFacturar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnFacturar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacturar.ForeColor = System.Drawing.Color.White
        Me.btnFacturar.Image = Global.SIGT__KIGEST.My.Resources.Resources.factura
        Me.btnFacturar.Location = New System.Drawing.Point(738, 0)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(92, 89)
        Me.btnFacturar.TabIndex = 195
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnFacturar.UseVisualStyleBackColor = True
        '
        'dtdesdefact
        '
        Me.dtdesdefact.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdesdefact.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdesdefact.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtdesdefact.Location = New System.Drawing.Point(331, 32)
        Me.dtdesdefact.Name = "dtdesdefact"
        Me.dtdesdefact.Size = New System.Drawing.Size(117, 23)
        Me.dtdesdefact.TabIndex = 192
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(328, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 17)
        Me.Label8.TabIndex = 194
        Me.Label8.Text = "Posterior a"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(328, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 16)
        Me.Label4.TabIndex = 191
        Me.Label4.Text = "Periodo FIN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(81, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 188
        Me.Label3.Text = "Filtros"
        '
        'txtdiasmora
        '
        Me.txtdiasmora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdiasmora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiasmora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtdiasmora.Location = New System.Drawing.Point(3, 19)
        Me.txtdiasmora.Name = "txtdiasmora"
        Me.txtdiasmora.Size = New System.Drawing.Size(72, 22)
        Me.txtdiasmora.TabIndex = 187
        Me.txtdiasmora.Text = "15"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 186
        Me.Label2.Text = "DiasMora"
        '
        'btnNuevaPublicidad
        '
        Me.btnNuevaPublicidad.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnNuevaPublicidad.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnNuevaPublicidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevaPublicidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevaPublicidad.ForeColor = System.Drawing.Color.White
        Me.btnNuevaPublicidad.Image = Global.SIGT__KIGEST.My.Resources.Resources.Commercial_64px
        Me.btnNuevaPublicidad.Location = New System.Drawing.Point(830, 0)
        Me.btnNuevaPublicidad.Name = "btnNuevaPublicidad"
        Me.btnNuevaPublicidad.Size = New System.Drawing.Size(92, 89)
        Me.btnNuevaPublicidad.TabIndex = 185
        Me.btnNuevaPublicidad.Text = "Nueva"
        Me.btnNuevaPublicidad.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevaPublicidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNuevaPublicidad.UseVisualStyleBackColor = True
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdbuscar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscar.ForeColor = System.Drawing.Color.White
        Me.cmdbuscar.Image = CType(resources.GetObject("cmdbuscar.Image"), System.Drawing.Image)
        Me.cmdbuscar.Location = New System.Drawing.Point(922, 0)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(92, 89)
        Me.cmdbuscar.TabIndex = 184
        Me.cmdbuscar.Text = "Buscar"
        Me.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdbuscar.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(5, 42)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(55, 16)
        Me.Label36.TabIndex = 183
        Me.Label36.Text = "Cliente"
        '
        'cmdver
        '
        Me.cmdver.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdver.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdver.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdver.ForeColor = System.Drawing.Color.White
        Me.cmdver.Image = Global.SIGT__KIGEST.My.Resources.Resources.Eye_64px
        Me.cmdver.Location = New System.Drawing.Point(1014, 0)
        Me.cmdver.Name = "cmdver"
        Me.cmdver.Size = New System.Drawing.Size(92, 89)
        Me.cmdver.TabIndex = 170
        Me.cmdver.Text = "Ver"
        Me.cmdver.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdver.UseVisualStyleBackColor = True
        '
        'txtbuscar
        '
        Me.txtbuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbuscar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtbuscar.Location = New System.Drawing.Point(3, 61)
        Me.txtbuscar.Name = "txtbuscar"
        Me.txtbuscar.Size = New System.Drawing.Size(237, 22)
        Me.txtbuscar.TabIndex = 169
        '
        'btnExportar
        '
        Me.btnExportar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.ForeColor = System.Drawing.Color.White
        Me.btnExportar.Image = Global.SIGT__KIGEST.My.Resources.Resources.Print_64px
        Me.btnExportar.Location = New System.Drawing.Point(1106, 0)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(102, 89)
        Me.btnExportar.TabIndex = 0
        Me.btnExportar.Text = "Imprimir"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1222, 40)
        Me.pntitulo.TabIndex = 75
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "PUBLICIDADES"
        '
        'dgvPrestamos
        '
        Me.dgvPrestamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrestamos.Location = New System.Drawing.Point(3, 92)
        Me.dgvPrestamos.Name = "dgvPrestamos"
        Me.dgvPrestamos.Size = New System.Drawing.Size(1208, 332)
        Me.dgvPrestamos.TabIndex = 78
        '
        'listadoPublicidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 493)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "listadoPublicidades"
        Me.Text = "listadoPublicidades"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.tabListadoSerivicios.ResumeLayout(False)
        Me.pnnavegacion.ResumeLayout(False)
        Me.pnnavegacion.PerformLayout()
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabListadoSerivicios As TabPage
    Friend WithEvents dgvPrestamos As DGVPaginado
    Friend WithEvents pnnavegacion As Panel
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents Label36 As Label
    Friend WithEvents cmdver As Button
    Friend WithEvents txtbuscar As TextBox
    Friend WithEvents btnExportar As Button
    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnNuevaPublicidad As Button
    Friend WithEvents txtdiasmora As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtdesdefact As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents btnFacturar As Button
    Friend WithEvents rdAVencer As RadioButton
    Friend WithEvents rdvigentes As RadioButton
    Friend WithEvents chkSoloMorosos As CheckBox
    Friend WithEvents chksinFact As CheckBox
    Friend WithEvents rdOper As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbvendedor As ComboBox
End Class
