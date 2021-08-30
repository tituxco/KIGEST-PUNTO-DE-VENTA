<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class caja
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(caja))
        Me.pnnavegacion = New System.Windows.Forms.Panel()
        Me.chkfiltrofecha = New System.Windows.Forms.CheckBox()
        Me.dtpfechacaja = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbcajas = New System.Windows.Forms.ComboBox()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dttotales = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtcaja = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbcierresCajas = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdnuevomov = New System.Windows.Forms.Button()
        Me.cmdcerrarcaja = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.pnnavegacion.SuspendLayout()
        Me.pntitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dttotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtcaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnnavegacion
        '
        Me.pnnavegacion.AutoScroll = True
        Me.pnnavegacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnnavegacion.Controls.Add(Me.Label2)
        Me.pnnavegacion.Controls.Add(Me.cmbcierresCajas)
        Me.pnnavegacion.Controls.Add(Me.Button2)
        Me.pnnavegacion.Controls.Add(Me.Button1)
        Me.pnnavegacion.Controls.Add(Me.chkfiltrofecha)
        Me.pnnavegacion.Controls.Add(Me.dtpfechacaja)
        Me.pnnavegacion.Controls.Add(Me.Label6)
        Me.pnnavegacion.Controls.Add(Me.cmbcajas)
        Me.pnnavegacion.Controls.Add(Me.cmdsalir)
        Me.pnnavegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnnavegacion.Location = New System.Drawing.Point(0, 40)
        Me.pnnavegacion.Name = "pnnavegacion"
        Me.pnnavegacion.Size = New System.Drawing.Size(1015, 88)
        Me.pnnavegacion.TabIndex = 13
        '
        'chkfiltrofecha
        '
        Me.chkfiltrofecha.AutoSize = True
        Me.chkfiltrofecha.BackColor = System.Drawing.Color.Transparent
        Me.chkfiltrofecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkfiltrofecha.ForeColor = System.Drawing.Color.White
        Me.chkfiltrofecha.Location = New System.Drawing.Point(356, 24)
        Me.chkfiltrofecha.Name = "chkfiltrofecha"
        Me.chkfiltrofecha.Size = New System.Drawing.Size(77, 21)
        Me.chkfiltrofecha.TabIndex = 46
        Me.chkfiltrofecha.Text = "CIERRE"
        Me.chkfiltrofecha.UseVisualStyleBackColor = False
        Me.chkfiltrofecha.Visible = False
        '
        'dtpfechacaja
        '
        Me.dtpfechacaja.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechacaja.Enabled = False
        Me.dtpfechacaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechacaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechacaja.Location = New System.Drawing.Point(589, 59)
        Me.dtpfechacaja.Name = "dtpfechacaja"
        Me.dtpfechacaja.Size = New System.Drawing.Size(117, 26)
        Me.dtpfechacaja.TabIndex = 45
        Me.dtpfechacaja.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(7, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 16)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "CAJA"
        '
        'cmbcajas
        '
        Me.cmbcajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcajas.FormattingEnabled = True
        Me.cmbcajas.Location = New System.Drawing.Point(59, 13)
        Me.cmbcajas.Name = "cmbcajas"
        Me.cmbcajas.Size = New System.Drawing.Size(291, 39)
        Me.cmbcajas.TabIndex = 42
        '
        'pntitulo
        '
        Me.pntitulo.AutoScroll = True
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1015, 40)
        Me.pntitulo.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CAJAS"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dttotales)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 319)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1015, 126)
        Me.Panel1.TabIndex = 82
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmdnuevomov)
        Me.Panel2.Controls.Add(Me.cmdcerrarcaja)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 23)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1015, 103)
        Me.Panel2.TabIndex = 85
        '
        'dttotales
        '
        Me.dttotales.AllowUserToDeleteRows = False
        Me.dttotales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dttotales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dttotales.BackgroundColor = System.Drawing.Color.White
        Me.dttotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dttotales.ColumnHeadersVisible = False
        Me.dttotales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.dttotales.Dock = System.Windows.Forms.DockStyle.Top
        Me.dttotales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dttotales.Enabled = False
        Me.dttotales.Location = New System.Drawing.Point(0, 0)
        Me.dttotales.MultiSelect = False
        Me.dttotales.Name = "dttotales"
        Me.dttotales.ReadOnly = True
        Me.dttotales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dttotales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dttotales.Size = New System.Drawing.Size(1015, 23)
        Me.dttotales.TabIndex = 84
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn1.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Concepto"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Detalle"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.FillWeight = 40.0!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ingreso"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.FillWeight = 40.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Egreso"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.FillWeight = 40.0!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Saldo"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'dtcaja
        '
        Me.dtcaja.AllowUserToAddRows = False
        Me.dtcaja.AllowUserToDeleteRows = False
        Me.dtcaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtcaja.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtcaja.BackgroundColor = System.Drawing.Color.White
        Me.dtcaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtcaja.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column6, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dtcaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtcaja.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtcaja.Location = New System.Drawing.Point(0, 128)
        Me.dtcaja.MultiSelect = False
        Me.dtcaja.Name = "dtcaja"
        Me.dtcaja.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtcaja.Size = New System.Drawing.Size(1015, 191)
        Me.dtcaja.TabIndex = 83
        '
        'Column1
        '
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column1.FillWeight = 50.0!
        Me.Column1.HeaderText = "Fecha"
        Me.Column1.Name = "Column1"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Concepto"
        Me.Column6.Name = "Column6"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Detalle"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.FillWeight = 40.0!
        Me.Column3.HeaderText = "Ingreso"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.FillWeight = 40.0!
        Me.Column4.HeaderText = "Egreso"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.FillWeight = 40.0!
        Me.Column5.HeaderText = "Saldo"
        Me.Column5.Name = "Column5"
        '
        'cmbcierresCajas
        '
        Me.cmbcierresCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcierresCajas.FormattingEnabled = True
        Me.cmbcierresCajas.Location = New System.Drawing.Point(430, 13)
        Me.cmbcierresCajas.Name = "cmbcierresCajas"
        Me.cmbcierresCajas.Size = New System.Drawing.Size(276, 39)
        Me.cmbcierresCajas.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(519, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "CIERRE"
        Me.Label2.Visible = False
        '
        'cmdnuevomov
        '
        Me.cmdnuevomov.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdnuevomov.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdnuevomov.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnuevomov.ForeColor = System.Drawing.Color.White
        Me.cmdnuevomov.Image = CType(resources.GetObject("cmdnuevomov.Image"), System.Drawing.Image)
        Me.cmdnuevomov.Location = New System.Drawing.Point(95, 0)
        Me.cmdnuevomov.Name = "cmdnuevomov"
        Me.cmdnuevomov.Size = New System.Drawing.Size(90, 103)
        Me.cmdnuevomov.TabIndex = 1
        Me.cmdnuevomov.Text = "Nuevo mov"
        Me.cmdnuevomov.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdnuevomov.UseVisualStyleBackColor = False
        '
        'cmdcerrarcaja
        '
        Me.cmdcerrarcaja.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcerrarcaja.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdcerrarcaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcerrarcaja.ForeColor = System.Drawing.Color.White
        Me.cmdcerrarcaja.Image = CType(resources.GetObject("cmdcerrarcaja.Image"), System.Drawing.Image)
        Me.cmdcerrarcaja.Location = New System.Drawing.Point(0, 0)
        Me.cmdcerrarcaja.Name = "cmdcerrarcaja"
        Me.cmdcerrarcaja.Size = New System.Drawing.Size(95, 103)
        Me.cmdcerrarcaja.TabIndex = 0
        Me.cmdcerrarcaja.Text = "Cerrar caja"
        Me.cmdcerrarcaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdcerrarcaja.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = Global.SIGT__KIGEST.My.Resources.Resources.Synchronize_64px1
        Me.Button2.Location = New System.Drawing.Point(827, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 88)
        Me.Button2.TabIndex = 48
        Me.Button2.Text = "Actualizar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(746, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 34)
        Me.Button1.TabIndex = 47
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'cmdsalir
        '
        Me.cmdsalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdsalir.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdsalir.ForeColor = System.Drawing.Color.White
        Me.cmdsalir.Image = CType(resources.GetObject("cmdsalir.Image"), System.Drawing.Image)
        Me.cmdsalir.Location = New System.Drawing.Point(921, 0)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(94, 88)
        Me.cmdsalir.TabIndex = 17
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdsalir.UseVisualStyleBackColor = True
        '
        'caja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1015, 445)
        Me.Controls.Add(Me.dtcaja)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnnavegacion)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "caja"
        Me.Text = "caja"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnnavegacion.ResumeLayout(False)
        Me.pnnavegacion.PerformLayout()
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dttotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtcaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnnavegacion As System.Windows.Forms.Panel
    Friend WithEvents cmdsalir As System.Windows.Forms.Button
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbcajas As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtcaja As System.Windows.Forms.DataGridView
    Friend WithEvents dtpfechacaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdcerrarcaja As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdnuevomov As System.Windows.Forms.Button
    Friend WithEvents chkfiltrofecha As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dttotales As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbcierresCajas As ComboBox
End Class
