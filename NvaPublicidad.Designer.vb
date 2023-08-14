<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NvaPublicidad
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPagar = New System.Windows.Forms.Button()
        Me.txtclientenombre = New System.Windows.Forms.TextBox()
        Me.txtmonto = New System.Windows.Forms.TextBox()
        Me.cmdclientebuscar = New System.Windows.Forms.Button()
        Me.txtBuscaPrestamo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvPublicidad = New System.Windows.Forms.DataGridView()
        Me.txtInteresMensual = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPrestamo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.txtCuota = New System.Windows.Forms.TextBox()
        Me.txtTasaAnual = New System.Windows.Forms.TextBox()
        Me.txtPlazo = New System.Windows.Forms.TextBox()
        Me.txtclientecuenta = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtdetallePublicidad = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtconcepto = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkAdelantado = New System.Windows.Forms.CheckBox()
        Me.pntitulo.SuspendLayout()
        CType(Me.dgvPublicidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(476, 201)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 27)
        Me.Button1.TabIndex = 117
        Me.Button1.Text = "Guardar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnPagar
        '
        Me.btnPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPagar.Enabled = False
        Me.btnPagar.Location = New System.Drawing.Point(332, 201)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(133, 27)
        Me.btnPagar.TabIndex = 99
        Me.btnPagar.Text = "Facturar"
        Me.btnPagar.UseVisualStyleBackColor = True
        '
        'txtclientenombre
        '
        Me.txtclientenombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclientenombre.Location = New System.Drawing.Point(531, 43)
        Me.txtclientenombre.Name = "txtclientenombre"
        Me.txtclientenombre.Size = New System.Drawing.Size(257, 22)
        Me.txtclientenombre.TabIndex = 116
        '
        'txtmonto
        '
        Me.txtmonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto.Location = New System.Drawing.Point(132, 40)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(121, 22)
        Me.txtmonto.TabIndex = 115
        Me.txtmonto.Text = "0"
        '
        'cmdclientebuscar
        '
        Me.cmdclientebuscar.Location = New System.Drawing.Point(794, 43)
        Me.cmdclientebuscar.Name = "cmdclientebuscar"
        Me.cmdclientebuscar.Size = New System.Drawing.Size(30, 23)
        Me.cmdclientebuscar.TabIndex = 114
        Me.cmdclientebuscar.Text = "+"
        Me.cmdclientebuscar.UseVisualStyleBackColor = True
        '
        'txtBuscaPrestamo
        '
        Me.txtBuscaPrestamo.AcceptsReturn = True
        Me.txtBuscaPrestamo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuscaPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscaPrestamo.Location = New System.Drawing.Point(200, 206)
        Me.txtBuscaPrestamo.Name = "txtBuscaPrestamo"
        Me.txtBuscaPrestamo.ReadOnly = True
        Me.txtBuscaPrestamo.Size = New System.Drawing.Size(121, 22)
        Me.txtBuscaPrestamo.TabIndex = 92
        Me.txtBuscaPrestamo.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(391, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 16)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "Cliente:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(66, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 16)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Consultar Prestamo:"
        Me.Label10.Visible = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Location = New System.Drawing.Point(754, 201)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(114, 27)
        Me.btnImprimir.TabIndex = 96
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(875, 40)
        Me.pntitulo.TabIndex = 112
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(592, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "NUEVA PUBLICIDAD/SIMULADOR"
        '
        'dgvPublicidad
        '
        Me.dgvPublicidad.AllowUserToAddRows = False
        Me.dgvPublicidad.AllowUserToDeleteRows = False
        Me.dgvPublicidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPublicidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPublicidad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPublicidad.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvPublicidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPublicidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPublicidad.Location = New System.Drawing.Point(1, 234)
        Me.dgvPublicidad.Name = "dgvPublicidad"
        Me.dgvPublicidad.ReadOnly = True
        Me.dgvPublicidad.RowHeadersVisible = False
        Me.dgvPublicidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPublicidad.Size = New System.Drawing.Size(867, 143)
        Me.dgvPublicidad.TabIndex = 111
        '
        'txtInteresMensual
        '
        Me.txtInteresMensual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInteresMensual.Location = New System.Drawing.Point(685, 302)
        Me.txtInteresMensual.Name = "txtInteresMensual"
        Me.txtInteresMensual.Size = New System.Drawing.Size(121, 22)
        Me.txtInteresMensual.TabIndex = 98
        Me.txtInteresMensual.Text = "0"
        Me.txtInteresMensual.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(392, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 16)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "Publi#"
        '
        'txtPrestamo
        '
        Me.txtPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrestamo.Location = New System.Drawing.Point(452, 90)
        Me.txtPrestamo.Name = "txtPrestamo"
        Me.txtPrestamo.ReadOnly = True
        Me.txtPrestamo.Size = New System.Drawing.Size(121, 22)
        Me.txtPrestamo.TabIndex = 103
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 16)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Fecha de inicio:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(132, 93)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(121, 22)
        Me.dtpFechaInicio.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(557, 305)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Interes mensual:"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(341, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 16)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Monto mensual:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(515, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 16)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Tasa de interés: anual:"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 16)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Cantidad de meses:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(53, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Monto toal:"
        '
        'btnCalcular
        '
        Me.btnCalcular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalcular.Location = New System.Drawing.Point(596, 201)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(152, 27)
        Me.btnCalcular.TabIndex = 106
        Me.btnCalcular.Text = "Previsiualizar"
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'txtCuota
        '
        Me.txtCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuota.Location = New System.Drawing.Point(452, 67)
        Me.txtCuota.Name = "txtCuota"
        Me.txtCuota.ReadOnly = True
        Me.txtCuota.Size = New System.Drawing.Size(121, 22)
        Me.txtCuota.TabIndex = 102
        '
        'txtTasaAnual
        '
        Me.txtTasaAnual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTasaAnual.Location = New System.Drawing.Point(685, 277)
        Me.txtTasaAnual.Name = "txtTasaAnual"
        Me.txtTasaAnual.Size = New System.Drawing.Size(121, 22)
        Me.txtTasaAnual.TabIndex = 97
        Me.txtTasaAnual.Text = "0"
        Me.txtTasaAnual.Visible = False
        '
        'txtPlazo
        '
        Me.txtPlazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlazo.Location = New System.Drawing.Point(132, 67)
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Size = New System.Drawing.Size(121, 22)
        Me.txtPlazo.TabIndex = 95
        Me.txtPlazo.Text = "0"
        '
        'txtclientecuenta
        '
        Me.txtclientecuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclientecuenta.Location = New System.Drawing.Point(452, 43)
        Me.txtclientecuenta.Name = "txtclientecuenta"
        Me.txtclientecuenta.ReadOnly = True
        Me.txtclientecuenta.Size = New System.Drawing.Size(73, 22)
        Me.txtclientecuenta.TabIndex = 93
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(43, 124)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 16)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "Descripcion:"
        '
        'txtdetallePublicidad
        '
        Me.txtdetallePublicidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdetallePublicidad.Location = New System.Drawing.Point(132, 124)
        Me.txtdetallePublicidad.MaxLength = 240
        Me.txtdetallePublicidad.Multiline = True
        Me.txtdetallePublicidad.Name = "txtdetallePublicidad"
        Me.txtdetallePublicidad.Size = New System.Drawing.Size(311, 31)
        Me.txtdetallePublicidad.TabIndex = 119
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(43, 167)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 16)
        Me.Label12.TabIndex = 120
        Me.Label12.Text = "Concepto"
        '
        'txtconcepto
        '
        Me.txtconcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconcepto.Location = New System.Drawing.Point(132, 161)
        Me.txtconcepto.MaxLength = 240
        Me.txtconcepto.Multiline = True
        Me.txtconcepto.Name = "txtconcepto"
        Me.txtconcepto.Size = New System.Drawing.Size(311, 31)
        Me.txtconcepto.TabIndex = 121
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(552, 124)
        Me.txtObservaciones.MaxLength = 240
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(272, 68)
        Me.txtObservaciones.TabIndex = 123
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(446, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 16)
        Me.Label13.TabIndex = 122
        Me.Label13.Text = "Observaciones"
        '
        'chkAdelantado
        '
        Me.chkAdelantado.AutoSize = True
        Me.chkAdelantado.Location = New System.Drawing.Point(259, 44)
        Me.chkAdelantado.Name = "chkAdelantado"
        Me.chkAdelantado.Size = New System.Drawing.Size(108, 17)
        Me.chkAdelantado.TabIndex = 124
        Me.chkAdelantado.Text = "Pago Adelantado"
        Me.chkAdelantado.UseVisualStyleBackColor = True
        '
        'NvaPublicidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 381)
        Me.Controls.Add(Me.chkAdelantado)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtconcepto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtdetallePublicidad)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnPagar)
        Me.Controls.Add(Me.txtclientenombre)
        Me.Controls.Add(Me.txtmonto)
        Me.Controls.Add(Me.cmdclientebuscar)
        Me.Controls.Add(Me.txtBuscaPrestamo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.pntitulo)
        Me.Controls.Add(Me.dgvPublicidad)
        Me.Controls.Add(Me.txtInteresMensual)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPrestamo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtpFechaInicio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.txtCuota)
        Me.Controls.Add(Me.txtTasaAnual)
        Me.Controls.Add(Me.txtPlazo)
        Me.Controls.Add(Me.txtclientecuenta)
        Me.KeyPreview = True
        Me.Name = "NvaPublicidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NvaPublicidad"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        CType(Me.dgvPublicidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents btnPagar As Button
    Friend WithEvents txtclientenombre As TextBox
    Friend WithEvents txtmonto As TextBox
    Friend WithEvents cmdclientebuscar As Button
    Friend WithEvents txtBuscaPrestamo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnImprimir As Button
    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvPublicidad As DataGridView
    Friend WithEvents txtInteresMensual As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPrestamo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnCalcular As Button
    Friend WithEvents txtCuota As TextBox
    Friend WithEvents txtTasaAnual As TextBox
    Friend WithEvents txtPlazo As TextBox
    Friend WithEvents txtclientecuenta As TextBox
    Friend WithEvents Label11 As Label
    Public WithEvents txtdetallePublicidad As TextBox
    Friend WithEvents Label12 As Label
    Public WithEvents txtconcepto As TextBox
    Public WithEvents txtObservaciones As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents chkAdelantado As CheckBox
End Class
