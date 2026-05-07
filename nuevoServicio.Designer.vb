<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class nuevoServicio
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbConcepto = New System.Windows.Forms.ComboBox()
        Me.cmdGuardarEditar = New System.Windows.Forms.Button()
        Me.btnPagar = New System.Windows.Forms.Button()
        Me.txtclientenombre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnbajacurso = New System.Windows.Forms.Button()
        Me.txtCuotaMensual = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdclientebuscar = New System.Windows.Forms.Button()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtApellidoNombre = New System.Windows.Forms.TextBox()
        Me.txtDniAlumno = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtclientecuenta = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCostoExamen = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCostoInscripcion = New System.Windows.Forms.TextBox()
        Me.dgvDetallePlan = New System.Windows.Forms.DataGridView()
        Me.lblEstadoCurso = New System.Windows.Forms.Label()
        Me.pntitulo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvDetallePlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.lbltitulo)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(673, 40)
        Me.pntitulo.TabIndex = 113
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.White
        Me.lbltitulo.Location = New System.Drawing.Point(3, 0)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(145, 39)
        Me.lbltitulo.TabIndex = 2
        Me.lbltitulo.Text = "NUEVO"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(223, 233)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 27)
        Me.Button1.TabIndex = 168
        Me.Button1.Text = "Imputar Pago"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbConcepto
        '
        Me.cmbConcepto.FormattingEnabled = True
        Me.cmbConcepto.Items.AddRange(New Object() {"PUBLICIDAD RADIO", "PUBLICIDAD TV", "PUBLICIDAD WEB"})
        Me.cmbConcepto.Location = New System.Drawing.Point(2, 22)
        Me.cmbConcepto.Name = "cmbConcepto"
        Me.cmbConcepto.Size = New System.Drawing.Size(309, 24)
        Me.cmbConcepto.TabIndex = 138
        '
        'cmdGuardarEditar
        '
        Me.cmdGuardarEditar.Location = New System.Drawing.Point(320, 233)
        Me.cmdGuardarEditar.Name = "cmdGuardarEditar"
        Me.cmdGuardarEditar.Size = New System.Drawing.Size(94, 27)
        Me.cmdGuardarEditar.TabIndex = 141
        Me.cmdGuardarEditar.Text = "Guardar"
        Me.cmdGuardarEditar.UseVisualStyleBackColor = True
        '
        'btnPagar
        '
        Me.btnPagar.Enabled = False
        Me.btnPagar.Location = New System.Drawing.Point(126, 233)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(91, 27)
        Me.btnPagar.TabIndex = 148
        Me.btnPagar.Text = "Facturar"
        Me.btnPagar.UseVisualStyleBackColor = True
        '
        'txtclientenombre
        '
        Me.txtclientenombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclientenombre.Location = New System.Drawing.Point(129, 126)
        Me.txtclientenombre.Name = "txtclientenombre"
        Me.txtclientenombre.Size = New System.Drawing.Size(180, 22)
        Me.txtclientenombre.TabIndex = 137
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 16)
        Me.Label8.TabIndex = 158
        Me.Label8.Text = "Apellido y nombre:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(2, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 16)
        Me.Label7.TabIndex = 155
        Me.Label7.Text = "Fecha de inicio:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(109, 126)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(121, 22)
        Me.dtpFechaInicio.TabIndex = 135
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 16)
        Me.Label4.TabIndex = 153
        Me.Label4.Text = "Cuota Mensual:"
        '
        'btnbajacurso
        '
        Me.btnbajacurso.Enabled = False
        Me.btnbajacurso.Location = New System.Drawing.Point(10, 233)
        Me.btnbajacurso.Name = "btnbajacurso"
        Me.btnbajacurso.Size = New System.Drawing.Size(110, 27)
        Me.btnbajacurso.TabIndex = 140
        Me.btnbajacurso.Text = "Baja curso"
        Me.btnbajacurso.UseVisualStyleBackColor = True
        '
        'txtCuotaMensual
        '
        Me.txtCuotaMensual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuotaMensual.Location = New System.Drawing.Point(109, 73)
        Me.txtCuotaMensual.Name = "txtCuotaMensual"
        Me.txtCuotaMensual.ReadOnly = True
        Me.txtCuotaMensual.Size = New System.Drawing.Size(121, 22)
        Me.txtCuotaMensual.TabIndex = 132
        Me.txtCuotaMensual.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmdclientebuscar)
        Me.GroupBox1.Controls.Add(Me.txtCelular)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.txtApellidoNombre)
        Me.GroupBox1.Controls.Add(Me.txtDniAlumno)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtclientenombre)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtclientecuenta)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(333, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(335, 180)
        Me.GroupBox1.TabIndex = 169
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alumno:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(39, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 16)
        Me.Label6.TabIndex = 173
        Me.Label6.Text = "ClienteFactu:"
        '
        'cmdclientebuscar
        '
        Me.cmdclientebuscar.Location = New System.Drawing.Point(305, 126)
        Me.cmdclientebuscar.Name = "cmdclientebuscar"
        Me.cmdclientebuscar.Size = New System.Drawing.Size(30, 23)
        Me.cmdclientebuscar.TabIndex = 172
        Me.cmdclientebuscar.Text = "+"
        Me.cmdclientebuscar.UseVisualStyleBackColor = True
        '
        'txtCelular
        '
        Me.txtCelular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelular.Location = New System.Drawing.Point(129, 98)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(180, 22)
        Me.txtCelular.TabIndex = 171
        '
        'txtDireccion
        '
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(129, 70)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(180, 22)
        Me.txtDireccion.TabIndex = 170
        '
        'txtApellidoNombre
        '
        Me.txtApellidoNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellidoNombre.Location = New System.Drawing.Point(129, 42)
        Me.txtApellidoNombre.Name = "txtApellidoNombre"
        Me.txtApellidoNombre.Size = New System.Drawing.Size(180, 22)
        Me.txtApellidoNombre.TabIndex = 163
        '
        'txtDniAlumno
        '
        Me.txtDniAlumno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDniAlumno.Location = New System.Drawing.Point(129, 14)
        Me.txtDniAlumno.Name = "txtDniAlumno"
        Me.txtDniAlumno.Size = New System.Drawing.Size(180, 22)
        Me.txtDniAlumno.TabIndex = 162
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(58, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 161
        Me.Label5.Text = "Direccion:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(73, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 160
        Me.Label3.Text = "Celular:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(92, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 16)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "DNI:"
        '
        'txtclientecuenta
        '
        Me.txtclientecuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclientecuenta.Location = New System.Drawing.Point(262, 148)
        Me.txtclientecuenta.Name = "txtclientecuenta"
        Me.txtclientecuenta.ReadOnly = True
        Me.txtclientecuenta.Size = New System.Drawing.Size(47, 22)
        Me.txtclientecuenta.TabIndex = 143
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtCostoExamen)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtCostoInscripcion)
        Me.GroupBox2.Controls.Add(Me.cmbConcepto)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtCuotaMensual)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 180)
        Me.GroupBox2.TabIndex = 170
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Carrera:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 16)
        Me.Label10.TabIndex = 159
        Me.Label10.Text = "Costo Examen:"
        '
        'txtCostoExamen
        '
        Me.txtCostoExamen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoExamen.Location = New System.Drawing.Point(109, 98)
        Me.txtCostoExamen.Name = "txtCostoExamen"
        Me.txtCostoExamen.ReadOnly = True
        Me.txtCostoExamen.Size = New System.Drawing.Size(121, 22)
        Me.txtCostoExamen.TabIndex = 158
        Me.txtCostoExamen.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(2, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 16)
        Me.Label9.TabIndex = 157
        Me.Label9.Text = "Costo Incripción:"
        '
        'txtCostoInscripcion
        '
        Me.txtCostoInscripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoInscripcion.Location = New System.Drawing.Point(109, 49)
        Me.txtCostoInscripcion.Name = "txtCostoInscripcion"
        Me.txtCostoInscripcion.ReadOnly = True
        Me.txtCostoInscripcion.Size = New System.Drawing.Size(121, 22)
        Me.txtCostoInscripcion.TabIndex = 156
        Me.txtCostoInscripcion.Text = "0"
        '
        'dgvDetallePlan
        '
        Me.dgvDetallePlan.AllowUserToAddRows = False
        Me.dgvDetallePlan.AllowUserToDeleteRows = False
        Me.dgvDetallePlan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetallePlan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDetallePlan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDetallePlan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvDetallePlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetallePlan.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetallePlan.Location = New System.Drawing.Point(12, 266)
        Me.dgvDetallePlan.Name = "dgvDetallePlan"
        Me.dgvDetallePlan.ReadOnly = True
        Me.dgvDetallePlan.RowHeadersVisible = False
        Me.dgvDetallePlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetallePlan.Size = New System.Drawing.Size(657, 187)
        Me.dgvDetallePlan.TabIndex = 157
        '
        'lblEstadoCurso
        '
        Me.lblEstadoCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoCurso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblEstadoCurso.Location = New System.Drawing.Point(420, 234)
        Me.lblEstadoCurso.Name = "lblEstadoCurso"
        Me.lblEstadoCurso.Size = New System.Drawing.Size(248, 25)
        Me.lblEstadoCurso.TabIndex = 171
        Me.lblEstadoCurso.Text = "ESTADO: SIN GUARDAR"
        Me.lblEstadoCurso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nuevoServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 456)
        Me.Controls.Add(Me.lblEstadoCurso)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdGuardarEditar)
        Me.Controls.Add(Me.btnPagar)
        Me.Controls.Add(Me.dgvDetallePlan)
        Me.Controls.Add(Me.btnbajacurso)
        Me.Controls.Add(Me.pntitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "nuevoServicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nuevoServicio"
        Me.TopMost = True
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvDetallePlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents lbltitulo As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbConcepto As ComboBox
    Friend WithEvents cmdGuardarEditar As Button
    Friend WithEvents btnPagar As Button
    Friend WithEvents txtclientenombre As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents btnbajacurso As Button
    Friend WithEvents txtCuotaMensual As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtclientecuenta As TextBox
    Friend WithEvents txtCelular As TextBox
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents txtApellidoNombre As TextBox
    Friend WithEvents txtDniAlumno As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdclientebuscar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCostoInscripcion As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCostoExamen As TextBox
    Friend WithEvents dgvDetallePlan As DataGridView
    Friend WithEvents lblEstadoCurso As Label
End Class
