<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class imprimirEtiquetas
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
        Me.components = New System.ComponentModel.Container()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtCantEtiq = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblprecios = New System.Windows.Forms.Label()
        Me.pnCantidadPerson = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcantperson = New System.Windows.Forms.TextBox()
        Me.cmblistas = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtbuscarprod = New System.Windows.Forms.TextBox()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnCantidades = New System.Windows.Forms.Panel()
        Me.pnProductos = New System.Windows.Forms.Panel()
        Me.Datosfacturas1 = New SIGT__KIGEST.datosfacturas()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pntitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnCantidadPerson.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Datosfacturas1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.PictureBox1)
        Me.pntitulo.Controls.Add(Me.Panel3)
        Me.pntitulo.Controls.Add(Me.lblprecios)
        Me.pntitulo.Controls.Add(Me.pnCantidadPerson)
        Me.pntitulo.Controls.Add(Me.Panel1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1282, 140)
        Me.pntitulo.TabIndex = 66
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Location = New System.Drawing.Point(1051, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 140)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.txtCantEtiq)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1151, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(131, 140)
        Me.Panel3.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(0, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 97)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Imprimir"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtCantEtiq
        '
        Me.txtCantEtiq.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtCantEtiq.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantEtiq.Location = New System.Drawing.Point(0, 17)
        Me.txtCantEtiq.Name = "txtCantEtiq"
        Me.txtCantEtiq.Size = New System.Drawing.Size(131, 26)
        Me.txtCantEtiq.TabIndex = 18
        Me.txtCantEtiq.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 17)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Numero de etiq."
        '
        'lblprecios
        '
        Me.lblprecios.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblprecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 58.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprecios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblprecios.Location = New System.Drawing.Point(814, 0)
        Me.lblprecios.Name = "lblprecios"
        Me.lblprecios.Size = New System.Drawing.Size(337, 140)
        Me.lblprecios.TabIndex = 9
        Me.lblprecios.Text = "$"
        Me.lblprecios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnCantidadPerson
        '
        Me.pnCantidadPerson.Controls.Add(Me.Label1)
        Me.pnCantidadPerson.Controls.Add(Me.txtcantperson)
        Me.pnCantidadPerson.Controls.Add(Me.cmblistas)
        Me.pnCantidadPerson.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnCantidadPerson.Location = New System.Drawing.Point(559, 0)
        Me.pnCantidadPerson.Name = "pnCantidadPerson"
        Me.pnCantidadPerson.Size = New System.Drawing.Size(255, 140)
        Me.pnCantidadPerson.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Cantidad x "
        '
        'txtcantperson
        '
        Me.txtcantperson.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantperson.Location = New System.Drawing.Point(6, 79)
        Me.txtcantperson.Name = "txtcantperson"
        Me.txtcantperson.Size = New System.Drawing.Size(243, 53)
        Me.txtcantperson.TabIndex = 8
        Me.txtcantperson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmblistas
        '
        Me.cmblistas.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmblistas.FormattingEnabled = True
        Me.cmblistas.Location = New System.Drawing.Point(6, 5)
        Me.cmblistas.Name = "cmblistas"
        Me.cmblistas.Size = New System.Drawing.Size(243, 54)
        Me.cmblistas.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtbuscarprod)
        Me.Panel1.Controls.Add(Me.cmbCategoria)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(559, 140)
        Me.Panel1.TabIndex = 7
        '
        'txtbuscarprod
        '
        Me.txtbuscarprod.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbuscarprod.Location = New System.Drawing.Point(9, 79)
        Me.txtbuscarprod.Name = "txtbuscarprod"
        Me.txtbuscarprod.Size = New System.Drawing.Size(544, 53)
        Me.txtbuscarprod.TabIndex = 6
        '
        'cmbCategoria
        '
        Me.cmbCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(9, 5)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(544, 54)
        Me.cmbCategoria.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(274, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Lista de precios"
        '
        'pnCantidades
        '
        Me.pnCantidades.AutoScroll = True
        Me.pnCantidades.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnCantidades.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnCantidades.Location = New System.Drawing.Point(0, 140)
        Me.pnCantidades.Name = "pnCantidades"
        Me.pnCantidades.Size = New System.Drawing.Size(1282, 87)
        Me.pnCantidades.TabIndex = 68
        '
        'pnProductos
        '
        Me.pnProductos.AutoScroll = True
        Me.pnProductos.AutoScrollMargin = New System.Drawing.Size(500, 0)
        Me.pnProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnProductos.Location = New System.Drawing.Point(0, 227)
        Me.pnProductos.Name = "pnProductos"
        Me.pnProductos.Size = New System.Drawing.Size(1282, 278)
        Me.pnProductos.TabIndex = 69
        '
        'Datosfacturas1
        '
        Me.Datosfacturas1.DataSetName = "datosfacturas"
        Me.Datosfacturas1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Timer1
        '
        Me.Timer1.Interval = 150
        '
        'imprimirEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1282, 505)
        Me.Controls.Add(Me.pnProductos)
        Me.Controls.Add(Me.pnCantidades)
        Me.Controls.Add(Me.pntitulo)
        Me.KeyPreview = True
        Me.Name = "imprimirEtiquetas"
        Me.Text = "IMPRESION DE PRODUCCION"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pntitulo.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnCantidadPerson.ResumeLayout(False)
        Me.pnCantidadPerson.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Datosfacturas1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pntitulo As Panel
    Friend WithEvents pnCantidades As Panel
    Friend WithEvents cmbCategoria As ComboBox
    Friend WithEvents pnProductos As Panel
    Friend WithEvents cmblistas As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents lblprecios As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents txtbuscarprod As TextBox
    Friend WithEvents Datosfacturas1 As datosfacturas
    Friend WithEvents Timer1 As Timer
    Friend WithEvents pnCantidadPerson As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtcantperson As TextBox
    Friend WithEvents txtCantEtiq As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
