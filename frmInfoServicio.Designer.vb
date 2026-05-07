<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoServicio
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
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCostoExamen = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCostoInscripcion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCuotaMensual = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnombreCurso = New System.Windows.Forms.TextBox()
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
        Me.pntitulo.Size = New System.Drawing.Size(310, 54)
        Me.pntitulo.TabIndex = 33
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(310, 24)
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
        Me.Label1.Size = New System.Drawing.Size(195, 29)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Datos del curso"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(28, 170)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 16)
        Me.Label10.TabIndex = 168
        Me.Label10.Text = "Costo Examen:"
        '
        'txtCostoExamen
        '
        Me.txtCostoExamen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoExamen.Location = New System.Drawing.Point(135, 167)
        Me.txtCostoExamen.Name = "txtCostoExamen"
        Me.txtCostoExamen.Size = New System.Drawing.Size(121, 22)
        Me.txtCostoExamen.TabIndex = 167
        Me.txtCostoExamen.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(28, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 16)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "Costo Incripción:"
        '
        'txtCostoInscripcion
        '
        Me.txtCostoInscripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoInscripcion.Location = New System.Drawing.Point(135, 118)
        Me.txtCostoInscripcion.Name = "txtCostoInscripcion"
        Me.txtCostoInscripcion.Size = New System.Drawing.Size(121, 22)
        Me.txtCostoInscripcion.TabIndex = 165
        Me.txtCostoInscripcion.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 16)
        Me.Label4.TabIndex = 163
        Me.Label4.Text = "Cuota Mensual:"
        '
        'txtCuotaMensual
        '
        Me.txtCuotaMensual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuotaMensual.Location = New System.Drawing.Point(135, 142)
        Me.txtCuotaMensual.Name = "txtCuotaMensual"
        Me.txtCuotaMensual.Size = New System.Drawing.Size(121, 22)
        Me.txtCuotaMensual.TabIndex = 160
        Me.txtCuotaMensual.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 16)
        Me.Label2.TabIndex = 169
        Me.Label2.Text = "Nombre del curso"
        '
        'txtnombreCurso
        '
        Me.txtnombreCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombreCurso.Location = New System.Drawing.Point(31, 90)
        Me.txtnombreCurso.Name = "txtnombreCurso"
        Me.txtnombreCurso.Size = New System.Drawing.Size(225, 22)
        Me.txtnombreCurso.TabIndex = 170
        Me.txtnombreCurso.Text = "0"
        '
        'cmdGuardarEditar
        '
        Me.cmdGuardarEditar.Location = New System.Drawing.Point(173, 211)
        Me.cmdGuardarEditar.Name = "cmdGuardarEditar"
        Me.cmdGuardarEditar.Size = New System.Drawing.Size(83, 27)
        Me.cmdGuardarEditar.TabIndex = 188
        Me.cmdGuardarEditar.Text = "Guardar"
        Me.cmdGuardarEditar.UseVisualStyleBackColor = True
        '
        'btnPagar
        '
        Me.btnPagar.Enabled = False
        Me.btnPagar.Location = New System.Drawing.Point(76, 210)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(91, 27)
        Me.btnPagar.TabIndex = 189
        Me.btnPagar.Text = "Cancelar"
        Me.btnPagar.UseVisualStyleBackColor = True
        Me.btnPagar.Visible = False
        '
        'frmInfoServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 281)
        Me.Controls.Add(Me.cmdGuardarEditar)
        Me.Controls.Add(Me.btnPagar)
        Me.Controls.Add(Me.txtnombreCurso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCostoExamen)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCostoInscripcion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCuotaMensual)
        Me.Controls.Add(Me.pntitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoServicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmInfoServicio"
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCostoExamen As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCostoInscripcion As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCuotaMensual As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtnombreCurso As TextBox
    Friend WithEvents cmdGuardarEditar As Button
    Friend WithEvents btnPagar As Button
End Class
