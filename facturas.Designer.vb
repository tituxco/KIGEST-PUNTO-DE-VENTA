<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class facturas
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
        Me.paneltareas = New System.Windows.Forms.Panel()
        Me.cmdimprimir = New System.Windows.Forms.Button()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfacturas = New System.Windows.Forms.DataGridView()
        Me.paneltareas.SuspendLayout()
        Me.pntitulo.SuspendLayout()
        CType(Me.dtfacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'paneltareas
        '
        Me.paneltareas.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.paneltareas.Controls.Add(Me.cmdimprimir)
        Me.paneltareas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.paneltareas.Enabled = False
        Me.paneltareas.Location = New System.Drawing.Point(0, 394)
        Me.paneltareas.Name = "paneltareas"
        Me.paneltareas.Size = New System.Drawing.Size(894, 68)
        Me.paneltareas.TabIndex = 82
        '
        'cmdimprimir
        '
        Me.cmdimprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdimprimir.Enabled = False
        Me.cmdimprimir.Location = New System.Drawing.Point(0, 0)
        Me.cmdimprimir.Name = "cmdimprimir"
        Me.cmdimprimir.Size = New System.Drawing.Size(89, 68)
        Me.cmdimprimir.TabIndex = 12
        Me.cmdimprimir.Text = "Imprimir"
        Me.cmdimprimir.UseVisualStyleBackColor = True
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(894, 40)
        Me.pntitulo.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(329, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Listado de facturas"
        '
        'dtfacturas
        '
        Me.dtfacturas.AllowUserToAddRows = False
        Me.dtfacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtfacturas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtfacturas.BackgroundColor = System.Drawing.Color.White
        Me.dtfacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtfacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtfacturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtfacturas.Location = New System.Drawing.Point(0, 40)
        Me.dtfacturas.MultiSelect = False
        Me.dtfacturas.Name = "dtfacturas"
        Me.dtfacturas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtfacturas.Size = New System.Drawing.Size(894, 354)
        Me.dtfacturas.TabIndex = 83
        '
        'facturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 462)
        Me.Controls.Add(Me.dtfacturas)
        Me.Controls.Add(Me.paneltareas)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "facturas"
        Me.Text = "facturas"
        Me.paneltareas.ResumeLayout(False)
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        CType(Me.dtfacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents paneltareas As System.Windows.Forms.Panel
    Friend WithEvents cmdimprimir As System.Windows.Forms.Button
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfacturas As System.Windows.Forms.DataGridView
End Class
