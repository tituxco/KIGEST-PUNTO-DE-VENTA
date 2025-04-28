<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagosCompra2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagosCompra2))
        Me.pnDatosFact = New System.Windows.Forms.Panel()
        Me.cmdsalir = New System.Windows.Forms.Button()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txttotalefectivo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTarjetaNombre = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btntarjeta = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdfinalizarEfectivo = New System.Windows.Forms.Button()
        Me.pnDatosFact.SuspendLayout()
        Me.pntitulo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnDatosFact
        '
        Me.pnDatosFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnDatosFact.Controls.Add(Me.cmdsalir)
        Me.pnDatosFact.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDatosFact.Location = New System.Drawing.Point(0, 40)
        Me.pnDatosFact.Name = "pnDatosFact"
        Me.pnDatosFact.Size = New System.Drawing.Size(732, 92)
        Me.pnDatosFact.TabIndex = 35
        '
        'cmdsalir
        '
        Me.cmdsalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdsalir.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdsalir.ForeColor = System.Drawing.Color.White
        Me.cmdsalir.Image = CType(resources.GetObject("cmdsalir.Image"), System.Drawing.Image)
        Me.cmdsalir.Location = New System.Drawing.Point(630, 0)
        Me.cmdsalir.Name = "cmdsalir"
        Me.cmdsalir.Size = New System.Drawing.Size(102, 92)
        Me.cmdsalir.TabIndex = 187
        Me.cmdsalir.Text = "Salir"
        Me.cmdsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdsalir.UseVisualStyleBackColor = True
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(732, 40)
        Me.pntitulo.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(721, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "PAGO DE FACTURAS - INGRESO A CAJA"
        '
        'txttotalefectivo
        '
        Me.txttotalefectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txttotalefectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalefectivo.Location = New System.Drawing.Point(424, 138)
        Me.txttotalefectivo.Name = "txttotalefectivo"
        Me.txttotalefectivo.Size = New System.Drawing.Size(153, 30)
        Me.txttotalefectivo.TabIndex = 37
        Me.txttotalefectivo.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(207, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(199, 25)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "TOTAL EFECTIVO"
        '
        'txtTarjetaNombre
        '
        Me.txtTarjetaNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTarjetaNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtTarjetaNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTarjetaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarjetaNombre.FormattingEnabled = True
        Me.txtTarjetaNombre.Location = New System.Drawing.Point(57, 33)
        Me.txtTarjetaNombre.Name = "txtTarjetaNombre"
        Me.txtTarjetaNombre.Size = New System.Drawing.Size(321, 32)
        Me.txtTarjetaNombre.TabIndex = 39
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(393, 35)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(153, 30)
        Me.TextBox1.TabIndex = 40
        Me.TextBox1.Text = "0"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(393, 70)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(153, 30)
        Me.TextBox2.TabIndex = 43
        Me.TextBox2.Text = "0"
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(57, 71)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(321, 32)
        Me.ComboBox1.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 25)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "#1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 25)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "#2"
        '
        'btntarjeta
        '
        Me.btntarjeta.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btntarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntarjeta.Location = New System.Drawing.Point(0, 310)
        Me.btntarjeta.Name = "btntarjeta"
        Me.btntarjeta.Size = New System.Drawing.Size(732, 75)
        Me.btntarjeta.TabIndex = 46
        Me.btntarjeta.Text = "OTROS MEDIOS DE PAGO"
        Me.btntarjeta.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTarjetaNombre)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(32, 174)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(660, 123)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Medios electrónicos"
        '
        'cmdfinalizarEfectivo
        '
        Me.cmdfinalizarEfectivo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdfinalizarEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdfinalizarEfectivo.Location = New System.Drawing.Point(0, 385)
        Me.cmdfinalizarEfectivo.Name = "cmdfinalizarEfectivo"
        Me.cmdfinalizarEfectivo.Size = New System.Drawing.Size(732, 75)
        Me.cmdfinalizarEfectivo.TabIndex = 48
        Me.cmdfinalizarEfectivo.Text = "FINALIZAR"
        Me.cmdfinalizarEfectivo.UseVisualStyleBackColor = True
        '
        'frmPagosCompra2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 460)
        Me.Controls.Add(Me.btntarjeta)
        Me.Controls.Add(Me.cmdfinalizarEfectivo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txttotalefectivo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.pnDatosFact)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "frmPagosCompra2"
        Me.Text = "frmPagosCompra2"
        Me.pnDatosFact.ResumeLayout(False)
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnDatosFact As Panel
    Friend WithEvents cmdsalir As Button
    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txttotalefectivo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTarjetaNombre As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btntarjeta As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdfinalizarEfectivo As Button
End Class
