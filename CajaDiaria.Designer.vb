﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CajaDiaria
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CajaDiaria))
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtcaja = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grpdetalleCaja = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblefectivo = New System.Windows.Forms.Label()
        Me.lblcheques = New System.Windows.Forms.Label()
        Me.lbltarjeta = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.cmdnuevomov = New System.Windows.Forms.Button()
        Me.cmdcerrarcaja = New System.Windows.Forms.Button()
        Me.dttotales = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.chkfiltrofecha = New System.Windows.Forms.CheckBox()
        Me.cmbcierresCajas = New System.Windows.Forms.ComboBox()
        Me.dtpfechacaja = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dtcaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.grpdetalleCaja.SuspendLayout()
        CType(Me.dttotales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pntitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Column5
        '
        Me.Column5.FillWeight = 40.0!
        Me.Column5.HeaderText = "Saldo"
        Me.Column5.Name = "Column5"
        '
        'Column3
        '
        Me.Column3.FillWeight = 40.0!
        Me.Column3.HeaderText = "Ingreso"
        Me.Column3.Name = "Column3"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Detalle"
        Me.Column2.Name = "Column2"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Concepto"
        Me.Column6.Name = "Column6"
        '
        'Column1
        '
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.FillWeight = 50.0!
        Me.Column1.HeaderText = "Fecha"
        Me.Column1.Name = "Column1"
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
        Me.dtcaja.Location = New System.Drawing.Point(0, 40)
        Me.dtcaja.MultiSelect = False
        Me.dtcaja.Name = "dtcaja"
        Me.dtcaja.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtcaja.Size = New System.Drawing.Size(971, 164)
        Me.dtcaja.TabIndex = 87
        '
        'Column4
        '
        Me.Column4.FillWeight = 40.0!
        Me.Column4.HeaderText = "Egreso"
        Me.Column4.Name = "Column4"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grpdetalleCaja)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.cmdsalir)
        Me.Panel2.Controls.Add(Me.cmdnuevomov)
        Me.Panel2.Controls.Add(Me.cmdcerrarcaja)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 159)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(971, 103)
        Me.Panel2.TabIndex = 85
        '
        'grpdetalleCaja
        '
        Me.grpdetalleCaja.Controls.Add(Me.Label3)
        Me.grpdetalleCaja.Controls.Add(Me.lblefectivo)
        Me.grpdetalleCaja.Controls.Add(Me.lblcheques)
        Me.grpdetalleCaja.Controls.Add(Me.lbltarjeta)
        Me.grpdetalleCaja.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpdetalleCaja.Location = New System.Drawing.Point(658, 0)
        Me.grpdetalleCaja.Name = "grpdetalleCaja"
        Me.grpdetalleCaja.Size = New System.Drawing.Size(219, 103)
        Me.grpdetalleCaja.TabIndex = 93
        Me.grpdetalleCaja.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 17)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "DETALLE DE CAJA"
        '
        'lblefectivo
        '
        Me.lblefectivo.AutoSize = True
        Me.lblefectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblefectivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblefectivo.Location = New System.Drawing.Point(6, 33)
        Me.lblefectivo.Name = "lblefectivo"
        Me.lblefectivo.Size = New System.Drawing.Size(94, 18)
        Me.lblefectivo.TabIndex = 51
        Me.lblefectivo.Text = "EFECTIVO:"
        '
        'lblcheques
        '
        Me.lblcheques.AutoSize = True
        Me.lblcheques.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcheques.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblcheques.Location = New System.Drawing.Point(6, 74)
        Me.lblcheques.Name = "lblcheques"
        Me.lblcheques.Size = New System.Drawing.Size(95, 18)
        Me.lblcheques.TabIndex = 53
        Me.lblcheques.Text = "CHEQUES:"
        '
        'lbltarjeta
        '
        Me.lbltarjeta.AutoSize = True
        Me.lbltarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltarjeta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbltarjeta.Location = New System.Drawing.Point(6, 53)
        Me.lbltarjeta.Name = "lbltarjeta"
        Me.lbltarjeta.Size = New System.Drawing.Size(85, 18)
        Me.lbltarjeta.TabIndex = 52
        Me.lbltarjeta.Text = "TARJETA:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(185, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 103)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Exportar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cmdsalir
        '
        Me.cmdsalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdsalir.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdsalir.ForeColor = System.Drawing.Color.White
        Me.cmdsalir.Image = CType(resources.GetObject("cmdsalir.Image"), System.Drawing.Image)
        Me.cmdsalir.Location = New System.Drawing.Point(877, 0)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(94, 103)
        Me.cmdsalir.TabIndex = 18
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdsalir.UseVisualStyleBackColor = True
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
        'dttotales
        '
        Me.dttotales.AllowUserToDeleteRows = False
        Me.dttotales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dttotales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dttotales.BackgroundColor = System.Drawing.Color.White
        Me.dttotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dttotales.ColumnHeadersVisible = False
        Me.dttotales.Dock = System.Windows.Forms.DockStyle.Top
        Me.dttotales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dttotales.Enabled = False
        Me.dttotales.Location = New System.Drawing.Point(0, 0)
        Me.dttotales.MultiSelect = False
        Me.dttotales.Name = "dttotales"
        Me.dttotales.ReadOnly = True
        Me.dttotales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dttotales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dttotales.Size = New System.Drawing.Size(971, 159)
        Me.dttotales.TabIndex = 84
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dttotales)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 204)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(971, 262)
        Me.Panel1.TabIndex = 86
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CAJA DIARIA"
        '
        'pntitulo
        '
        Me.pntitulo.AutoScroll = True
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.chkfiltrofecha)
        Me.pntitulo.Controls.Add(Me.cmbcierresCajas)
        Me.pntitulo.Controls.Add(Me.dtpfechacaja)
        Me.pntitulo.Controls.Add(Me.Button1)
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(971, 40)
        Me.pntitulo.TabIndex = 84
        '
        'chkfiltrofecha
        '
        Me.chkfiltrofecha.AutoSize = True
        Me.chkfiltrofecha.BackColor = System.Drawing.Color.Transparent
        Me.chkfiltrofecha.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkfiltrofecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkfiltrofecha.ForeColor = System.Drawing.Color.White
        Me.chkfiltrofecha.Location = New System.Drawing.Point(441, 0)
        Me.chkfiltrofecha.Name = "chkfiltrofecha"
        Me.chkfiltrofecha.Size = New System.Drawing.Size(179, 40)
        Me.chkfiltrofecha.TabIndex = 50
        Me.chkfiltrofecha.Text = "CIERRES ANTERIORES"
        Me.chkfiltrofecha.UseVisualStyleBackColor = False
        '
        'cmbcierresCajas
        '
        Me.cmbcierresCajas.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmbcierresCajas.Enabled = False
        Me.cmbcierresCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcierresCajas.FormattingEnabled = True
        Me.cmbcierresCajas.Location = New System.Drawing.Point(620, 0)
        Me.cmbcierresCajas.Name = "cmbcierresCajas"
        Me.cmbcierresCajas.Size = New System.Drawing.Size(276, 39)
        Me.cmbcierresCajas.TabIndex = 51
        '
        'dtpfechacaja
        '
        Me.dtpfechacaja.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechacaja.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtpfechacaja.Enabled = False
        Me.dtpfechacaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechacaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechacaja.Location = New System.Drawing.Point(240, 0)
        Me.dtpfechacaja.Name = "dtpfechacaja"
        Me.dtpfechacaja.Size = New System.Drawing.Size(201, 41)
        Me.dtpfechacaja.TabIndex = 45
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(896, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 40)
        Me.Button1.TabIndex = 47
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CajaDiaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(971, 466)
        Me.Controls.Add(Me.dtcaja)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "CajaDiaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CajaDiaria"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtcaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.grpdetalleCaja.ResumeLayout(False)
        Me.grpdetalleCaja.PerformLayout()
        CType(Me.dttotales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents dtcaja As DataGridView
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmdnuevomov As Button
    Friend WithEvents cmdcerrarcaja As Button
    Friend WithEvents dttotales As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents pntitulo As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents dtpfechacaja As DateTimePicker
    Friend WithEvents cmdsalir As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cmbcierresCajas As ComboBox
    Friend WithEvents chkfiltrofecha As CheckBox
    Friend WithEvents lblcheques As Label
    Friend WithEvents lbltarjeta As Label
    Friend WithEvents lblefectivo As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents grpdetalleCaja As GroupBox
End Class
