<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class selProdNvo
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkstock = New System.Windows.Forms.CheckBox()
        Me.txtBusquedaCliente = New System.Windows.Forms.TextBox()
        Me.dtproductos = New System.Windows.Forms.DataGridView()
        Me.pntitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtproductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.TextBox1)
        Me.pntitulo.Controls.Add(Me.Panel1)
        Me.pntitulo.Controls.Add(Me.txtBusquedaCliente)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(584, 52)
        Me.pntitulo.TabIndex = 65
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(0, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(584, 22)
        Me.TextBox1.TabIndex = 187
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.chkstock)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 28)
        Me.Panel1.TabIndex = 186
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 29)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "PRODUCTOS"
        '
        'chkstock
        '
        Me.chkstock.AutoSize = True
        Me.chkstock.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkstock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkstock.ForeColor = System.Drawing.Color.White
        Me.chkstock.Location = New System.Drawing.Point(464, 0)
        Me.chkstock.Name = "chkstock"
        Me.chkstock.Size = New System.Drawing.Size(120, 28)
        Me.chkstock.TabIndex = 184
        Me.chkstock.Text = "Solo en stock"
        Me.chkstock.UseVisualStyleBackColor = True
        '
        'txtBusquedaCliente
        '
        Me.txtBusquedaCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBusquedaCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBusquedaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBusquedaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusquedaCliente.ForeColor = System.Drawing.Color.Black
        Me.txtBusquedaCliente.Location = New System.Drawing.Point(0, 0)
        Me.txtBusquedaCliente.Name = "txtBusquedaCliente"
        Me.txtBusquedaCliente.Size = New System.Drawing.Size(584, 22)
        Me.txtBusquedaCliente.TabIndex = 185
        '
        'dtproductos
        '
        Me.dtproductos.AllowUserToAddRows = False
        Me.dtproductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtproductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtproductos.BackgroundColor = System.Drawing.Color.White
        Me.dtproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtproductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtproductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtproductos.Location = New System.Drawing.Point(0, 52)
        Me.dtproductos.MultiSelect = False
        Me.dtproductos.Name = "dtproductos"
        Me.dtproductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtproductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtproductos.Size = New System.Drawing.Size(584, 309)
        Me.dtproductos.TabIndex = 66
        '
        'selProdNvo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.dtproductos)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "selProdNvo"
        Me.Text = "selProdNvo"
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtproductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents chkstock As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtproductos As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtBusquedaCliente As TextBox
End Class
