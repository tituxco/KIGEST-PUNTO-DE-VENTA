<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class agregarUsuarioCloud
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(agregarUsuarioCloud))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCloudNomApell = New System.Windows.Forms.TextBox()
        Me.txtCloudEmpresa = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCloudBD = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCloudUsuario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCloudContraseña = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCloudHost = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCloudHostPuerto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCloudHostUsuario = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCloudHostContraseña = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button33 = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.pntitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(402, 40)
        Me.pntitulo.TabIndex = 65
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(387, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Agregar nuevo usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Nombre y apellido"
        '
        'txtCloudNomApell
        '
        Me.txtCloudNomApell.Location = New System.Drawing.Point(126, 63)
        Me.txtCloudNomApell.Name = "txtCloudNomApell"
        Me.txtCloudNomApell.Size = New System.Drawing.Size(175, 20)
        Me.txtCloudNomApell.TabIndex = 67
        '
        'txtCloudEmpresa
        '
        Me.txtCloudEmpresa.Location = New System.Drawing.Point(126, 89)
        Me.txtCloudEmpresa.Name = "txtCloudEmpresa"
        Me.txtCloudEmpresa.Size = New System.Drawing.Size(175, 20)
        Me.txtCloudEmpresa.TabIndex = 69
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Empresa/Sistema"
        '
        'txtCloudBD
        '
        Me.txtCloudBD.Location = New System.Drawing.Point(126, 115)
        Me.txtCloudBD.Name = "txtCloudBD"
        Me.txtCloudBD.Size = New System.Drawing.Size(175, 20)
        Me.txtCloudBD.TabIndex = 71
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(49, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Nombre BD"
        '
        'txtCloudUsuario
        '
        Me.txtCloudUsuario.Location = New System.Drawing.Point(126, 141)
        Me.txtCloudUsuario.Name = "txtCloudUsuario"
        Me.txtCloudUsuario.Size = New System.Drawing.Size(175, 20)
        Me.txtCloudUsuario.TabIndex = 73
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "UsuarioSistema"
        '
        'txtCloudContraseña
        '
        Me.txtCloudContraseña.Location = New System.Drawing.Point(126, 167)
        Me.txtCloudContraseña.Name = "txtCloudContraseña"
        Me.txtCloudContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCloudContraseña.Size = New System.Drawing.Size(175, 20)
        Me.txtCloudContraseña.TabIndex = 75
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "ContraseñaSistema"
        '
        'txtCloudHost
        '
        Me.txtCloudHost.Location = New System.Drawing.Point(126, 193)
        Me.txtCloudHost.Name = "txtCloudHost"
        Me.txtCloudHost.Size = New System.Drawing.Size(175, 20)
        Me.txtCloudHost.TabIndex = 77
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(87, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Host"
        '
        'txtCloudHostPuerto
        '
        Me.txtCloudHostPuerto.Location = New System.Drawing.Point(126, 219)
        Me.txtCloudHostPuerto.Name = "txtCloudHostPuerto"
        Me.txtCloudHostPuerto.Size = New System.Drawing.Size(175, 20)
        Me.txtCloudHostPuerto.TabIndex = 79
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(76, 222)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Puerto"
        '
        'txtCloudHostUsuario
        '
        Me.txtCloudHostUsuario.Location = New System.Drawing.Point(126, 245)
        Me.txtCloudHostUsuario.Name = "txtCloudHostUsuario"
        Me.txtCloudHostUsuario.Size = New System.Drawing.Size(175, 20)
        Me.txtCloudHostUsuario.TabIndex = 81
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(49, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "Usuario BD"
        '
        'txtCloudHostContraseña
        '
        Me.txtCloudHostContraseña.Location = New System.Drawing.Point(126, 271)
        Me.txtCloudHostContraseña.Name = "txtCloudHostContraseña"
        Me.txtCloudHostContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCloudHostContraseña.Size = New System.Drawing.Size(175, 20)
        Me.txtCloudHostContraseña.TabIndex = 83
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(28, 275)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "Contraseña BD"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button33)
        Me.Panel1.Controls.Add(Me.cmdGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 309)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(402, 108)
        Me.Panel1.TabIndex = 92
        '
        'Button33
        '
        Me.Button33.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button33.BackColor = System.Drawing.Color.Transparent
        Me.Button33.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button33.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button33.ForeColor = System.Drawing.Color.White
        Me.Button33.Image = Global.SIGT__KIGEST.My.Resources.Resources.Cancel_64px
        Me.Button33.Location = New System.Drawing.Point(233, 5)
        Me.Button33.Name = "Button33"
        Me.Button33.Size = New System.Drawing.Size(80, 100)
        Me.Button33.TabIndex = 93
        Me.Button33.Text = "Cancela"
        Me.Button33.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button33.UseVisualStyleBackColor = False
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGuardar.BackColor = System.Drawing.Color.Transparent
        Me.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.ForeColor = System.Drawing.Color.White
        Me.cmdGuardar.Image = CType(resources.GetObject("cmdGuardar.Image"), System.Drawing.Image)
        Me.cmdGuardar.Location = New System.Drawing.Point(319, 5)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(80, 100)
        Me.cmdGuardar.TabIndex = 92
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdGuardar.UseVisualStyleBackColor = False
        '
        'agregarUsuarioCloud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(402, 417)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtCloudHostContraseña)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCloudHostUsuario)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCloudHostPuerto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCloudHost)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCloudContraseña)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCloudUsuario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCloudBD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCloudEmpresa)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCloudNomApell)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pntitulo)
        Me.MaximizeBox = False
        Me.Name = "agregarUsuarioCloud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "agregarUsuarioCloud"
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCloudNomApell As TextBox
    Friend WithEvents txtCloudEmpresa As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCloudBD As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCloudUsuario As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCloudContraseña As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCloudHost As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCloudHostPuerto As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCloudHostUsuario As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCloudHostContraseña As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button33 As Button
    Friend WithEvents cmdGuardar As Button
End Class
