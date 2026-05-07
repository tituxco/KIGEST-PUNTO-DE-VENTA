<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoAlumno
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
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdclientebuscar = New System.Windows.Forms.Button()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtApellidoNombre = New System.Windows.Forms.TextBox()
        Me.txtDniAlumno = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtclientenombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtclientecuenta = New System.Windows.Forms.TextBox()
        Me.cmdGuardarEditar = New System.Windows.Forms.Button()
        Me.btnPagar = New System.Windows.Forms.Button()
        Me.pntitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Panel1)
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(383, 54)
        Me.pntitulo.TabIndex = 32
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(383, 24)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 29)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Datos de alumno"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(43, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 16)
        Me.Label6.TabIndex = 185
        Me.Label6.Text = "ClienteFactu:"
        '
        'cmdclientebuscar
        '
        Me.cmdclientebuscar.Location = New System.Drawing.Point(309, 172)
        Me.cmdclientebuscar.Name = "cmdclientebuscar"
        Me.cmdclientebuscar.Size = New System.Drawing.Size(30, 23)
        Me.cmdclientebuscar.TabIndex = 184
        Me.cmdclientebuscar.Text = "+"
        Me.cmdclientebuscar.UseVisualStyleBackColor = True
        '
        'txtCelular
        '
        Me.txtCelular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelular.Location = New System.Drawing.Point(133, 144)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(180, 22)
        Me.txtCelular.TabIndex = 183
        '
        'txtDireccion
        '
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(133, 116)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(180, 22)
        Me.txtDireccion.TabIndex = 182
        '
        'txtApellidoNombre
        '
        Me.txtApellidoNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellidoNombre.Location = New System.Drawing.Point(133, 88)
        Me.txtApellidoNombre.Name = "txtApellidoNombre"
        Me.txtApellidoNombre.Size = New System.Drawing.Size(180, 22)
        Me.txtApellidoNombre.TabIndex = 181
        '
        'txtDniAlumno
        '
        Me.txtDniAlumno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDniAlumno.Location = New System.Drawing.Point(133, 60)
        Me.txtDniAlumno.Name = "txtDniAlumno"
        Me.txtDniAlumno.Size = New System.Drawing.Size(180, 22)
        Me.txtDniAlumno.TabIndex = 180
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(62, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 179
        Me.Label5.Text = "Direccion:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(77, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 178
        Me.Label3.Text = "Celular:"
        '
        'txtclientenombre
        '
        Me.txtclientenombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclientenombre.Location = New System.Drawing.Point(133, 172)
        Me.txtclientenombre.Name = "txtclientenombre"
        Me.txtclientenombre.Size = New System.Drawing.Size(180, 22)
        Me.txtclientenombre.TabIndex = 174
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(96, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 16)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "DNI:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 16)
        Me.Label8.TabIndex = 176
        Me.Label8.Text = "Apellido y nombre:"
        '
        'txtclientecuenta
        '
        Me.txtclientecuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclientecuenta.Location = New System.Drawing.Point(266, 194)
        Me.txtclientecuenta.Name = "txtclientecuenta"
        Me.txtclientecuenta.ReadOnly = True
        Me.txtclientecuenta.Size = New System.Drawing.Size(47, 22)
        Me.txtclientecuenta.TabIndex = 175
        '
        'cmdGuardarEditar
        '
        Me.cmdGuardarEditar.Location = New System.Drawing.Point(256, 222)
        Me.cmdGuardarEditar.Name = "cmdGuardarEditar"
        Me.cmdGuardarEditar.Size = New System.Drawing.Size(83, 27)
        Me.cmdGuardarEditar.TabIndex = 186
        Me.cmdGuardarEditar.Text = "Guardar"
        Me.cmdGuardarEditar.UseVisualStyleBackColor = True
        '
        'btnPagar
        '
        Me.btnPagar.Enabled = False
        Me.btnPagar.Location = New System.Drawing.Point(159, 221)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(91, 27)
        Me.btnPagar.TabIndex = 187
        Me.btnPagar.Text = "Cancelar"
        Me.btnPagar.UseVisualStyleBackColor = True
        Me.btnPagar.Visible = False
        '
        'frmInfoAlumno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 260)
        Me.Controls.Add(Me.cmdGuardarEditar)
        Me.Controls.Add(Me.btnPagar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdclientebuscar)
        Me.Controls.Add(Me.txtCelular)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.txtApellidoNombre)
        Me.Controls.Add(Me.txtDniAlumno)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtclientenombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtclientecuenta)
        Me.Controls.Add(Me.pntitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoAlumno"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmInfoAlumno"
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdclientebuscar As Button
    Friend WithEvents txtCelular As TextBox
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents txtApellidoNombre As TextBox
    Friend WithEvents txtDniAlumno As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtclientenombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtclientecuenta As TextBox
    Friend WithEvents cmdGuardarEditar As Button
    Friend WithEvents btnPagar As Button
End Class
