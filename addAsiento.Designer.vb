<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class addAsiento
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.txtAsientoNumero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtAsientoComprobante = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.fchAsientoFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAsientoConcepto = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.dgvPartidas = New System.Windows.Forms.DataGridView()
        Me.dgvCuenta = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cmbBusquedaCuenta = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbltotalHaber = New System.Windows.Forms.Label()
        Me.lbltotalDebe = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkReabrir = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEBE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HABER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pntitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.chkReabrir)
        Me.pntitulo.Controls.Add(Me.txtAsientoNumero)
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(785, 57)
        Me.pntitulo.TabIndex = 66
        '
        'txtAsientoNumero
        '
        Me.txtAsientoNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAsientoNumero.ForeColor = System.Drawing.Color.Black
        Me.txtAsientoNumero.Location = New System.Drawing.Point(340, 15)
        Me.txtAsientoNumero.Name = "txtAsientoNumero"
        Me.txtAsientoNumero.ReadOnly = True
        Me.txtAsientoNumero.Size = New System.Drawing.Size(117, 35)
        Me.txtAsientoNumero.TabIndex = 77
        Me.txtAsientoNumero.Text = "0"
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(334, 57)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Agregar asiento N°"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtAsientoComprobante)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmdGuardar)
        Me.Panel1.Controls.Add(Me.fchAsientoFecha)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtAsientoConcepto)
        Me.Panel1.Controls.Add(Me.Label68)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(785, 59)
        Me.Panel1.TabIndex = 67
        '
        'txtAsientoComprobante
        '
        Me.txtAsientoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAsientoComprobante.ForeColor = System.Drawing.Color.Black
        Me.txtAsientoComprobante.Location = New System.Drawing.Point(8, 27)
        Me.txtAsientoComprobante.Name = "txtAsientoComprobante"
        Me.txtAsientoComprobante.Size = New System.Drawing.Size(113, 29)
        Me.txtAsientoComprobante.TabIndex = 0
        Me.txtAsientoComprobante.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(4, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 20)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Comprobante"
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.ForeColor = System.Drawing.Color.White
        Me.cmdGuardar.Image = Global.SIGT__KIGEST.My.Resources.Resources.Save_32px
        Me.cmdGuardar.Location = New System.Drawing.Point(710, 0)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(75, 59)
        Me.cmdGuardar.TabIndex = 5
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'fchAsientoFecha
        '
        Me.fchAsientoFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fchAsientoFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fchAsientoFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fchAsientoFecha.Location = New System.Drawing.Point(476, 27)
        Me.fchAsientoFecha.Name = "fchAsientoFecha"
        Me.fchAsientoFecha.Size = New System.Drawing.Size(117, 29)
        Me.fchAsientoFecha.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(472, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Fecha"
        '
        'txtAsientoConcepto
        '
        Me.txtAsientoConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAsientoConcepto.ForeColor = System.Drawing.Color.Black
        Me.txtAsientoConcepto.Location = New System.Drawing.Point(131, 27)
        Me.txtAsientoConcepto.Name = "txtAsientoConcepto"
        Me.txtAsientoConcepto.Size = New System.Drawing.Size(335, 29)
        Me.txtAsientoConcepto.TabIndex = 1
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.White
        Me.Label68.Location = New System.Drawing.Point(127, 3)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(86, 20)
        Me.Label68.TabIndex = 75
        Me.Label68.Text = "Concepto"
        '
        'dgvPartidas
        '
        Me.dgvPartidas.AllowUserToResizeColumns = False
        Me.dgvPartidas.AllowUserToResizeRows = False
        Me.dgvPartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPartidas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPartidas.BackgroundColor = System.Drawing.Color.White
        Me.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idCuenta, Me.Codigo, Me.dgvCuenta, Me.DEBE, Me.HABER})
        Me.dgvPartidas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPartidas.Location = New System.Drawing.Point(0, 116)
        Me.dgvPartidas.MultiSelect = False
        Me.dgvPartidas.Name = "dgvPartidas"
        Me.dgvPartidas.Size = New System.Drawing.Size(785, 257)
        Me.dgvPartidas.TabIndex = 3
        '
        'dgvCuenta
        '
        Me.dgvCuenta.HeaderText = "Cuenta"
        Me.dgvCuenta.Name = "dgvCuenta"
        Me.dgvCuenta.ReadOnly = True
        Me.dgvCuenta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'cmbBusquedaCuenta
        '
        Me.cmbBusquedaCuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbBusquedaCuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBusquedaCuenta.FormattingEnabled = True
        Me.cmbBusquedaCuenta.Location = New System.Drawing.Point(155, 138)
        Me.cmbBusquedaCuenta.Name = "cmbBusquedaCuenta"
        Me.cmbBusquedaCuenta.Size = New System.Drawing.Size(395, 21)
        Me.cmbBusquedaCuenta.TabIndex = 4
        Me.cmbBusquedaCuenta.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lbltotalHaber)
        Me.Panel2.Controls.Add(Me.lbltotalDebe)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 373)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(785, 38)
        Me.Panel2.TabIndex = 68
        '
        'lbltotalHaber
        '
        Me.lbltotalHaber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalHaber.ForeColor = System.Drawing.Color.White
        Me.lbltotalHaber.Location = New System.Drawing.Point(671, 1)
        Me.lbltotalHaber.Name = "lbltotalHaber"
        Me.lbltotalHaber.Size = New System.Drawing.Size(102, 20)
        Me.lbltotalHaber.TabIndex = 78
        Me.lbltotalHaber.Text = "$"
        '
        'lbltotalDebe
        '
        Me.lbltotalDebe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalDebe.ForeColor = System.Drawing.Color.White
        Me.lbltotalDebe.Location = New System.Drawing.Point(556, 1)
        Me.lbltotalDebe.Name = "lbltotalDebe"
        Me.lbltotalDebe.Size = New System.Drawing.Size(109, 20)
        Me.lbltotalDebe.TabIndex = 77
        Me.lbltotalDebe.Text = "$"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(457, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 20)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "TOTALES:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkReabrir
        '
        Me.chkReabrir.AutoSize = True
        Me.chkReabrir.ForeColor = System.Drawing.Color.White
        Me.chkReabrir.Location = New System.Drawing.Point(653, 40)
        Me.chkReabrir.Name = "chkReabrir"
        Me.chkReabrir.Size = New System.Drawing.Size(132, 17)
        Me.chkReabrir.TabIndex = 78
        Me.chkReabrir.Text = "Guardar y agregar otro"
        Me.chkReabrir.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 30.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 104
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 30.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "DEBE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 105
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.FillWeight = 30.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "HABER"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 104
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.FillWeight = 30.0!
        Me.DataGridViewTextBoxColumn4.HeaderText = "HABER"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'idCuenta
        '
        Me.idCuenta.HeaderText = "idCuenta"
        Me.idCuenta.Name = "idCuenta"
        Me.idCuenta.Visible = False
        '
        'Codigo
        '
        Me.Codigo.FillWeight = 30.0!
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'DEBE
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.DEBE.DefaultCellStyle = DataGridViewCellStyle1
        Me.DEBE.FillWeight = 30.0!
        Me.DEBE.HeaderText = "DEBE"
        Me.DEBE.Name = "DEBE"
        '
        'HABER
        '
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.HABER.DefaultCellStyle = DataGridViewCellStyle2
        Me.HABER.FillWeight = 30.0!
        Me.HABER.HeaderText = "HABER"
        Me.HABER.Name = "HABER"
        '
        'addAsiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(785, 411)
        Me.Controls.Add(Me.cmbBusquedaCuenta)
        Me.Controls.Add(Me.dgvPartidas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pntitulo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "addAsiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "addAsiento"
        Me.TopMost = True
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAsientoConcepto As TextBox
    Friend WithEvents Label68 As Label
    Friend WithEvents fchAsientoFecha As DateTimePicker
    Friend WithEvents txtAsientoNumero As TextBox
    Friend WithEvents cmdGuardar As Button
    Friend WithEvents dgvPartidas As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents txtAsientoComprobante As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbBusquedaCuenta As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbltotalHaber As Label
    Friend WithEvents lbltotalDebe As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents idCuenta As DataGridViewTextBoxColumn
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents dgvCuenta As DataGridViewComboBoxColumn
    Friend WithEvents DEBE As DataGridViewTextBoxColumn
    Friend WithEvents HABER As DataGridViewTextBoxColumn
    Friend WithEvents chkReabrir As CheckBox
End Class
