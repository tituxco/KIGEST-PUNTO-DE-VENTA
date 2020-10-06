<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class selListaPrecios
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
        Me.dtlistas = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pntitulo = New System.Windows.Forms.Panel()
        CType(Me.dtlistas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pntitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtlistas
        '
        Me.dtlistas.AllowUserToAddRows = False
        Me.dtlistas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtlistas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtlistas.BackgroundColor = System.Drawing.Color.White
        Me.dtlistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtlistas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtlistas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtlistas.Location = New System.Drawing.Point(0, 40)
        Me.dtlistas.MultiSelect = False
        Me.dtlistas.Name = "dtlistas"
        Me.dtlistas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtlistas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtlistas.Size = New System.Drawing.Size(464, 226)
        Me.dtlistas.TabIndex = 66
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(468, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Seleccionar lista de precios"
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(464, 40)
        Me.pntitulo.TabIndex = 65
        '
        'selListaPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 266)
        Me.Controls.Add(Me.dtlistas)
        Me.Controls.Add(Me.pntitulo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "selListaPrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "selListaPrecios"
        Me.TopMost = True
        CType(Me.dtlistas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtlistas As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents pntitulo As Panel
End Class
