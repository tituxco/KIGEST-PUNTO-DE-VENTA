<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class selCondVta
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtCondVtas = New System.Windows.Forms.DataGridView()
        Me.pntitulo = New System.Windows.Forms.Panel()
        CType(Me.dtCondVtas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pntitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(464, 29)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SELECCIONE CONDICION DE VENTA"
        '
        'dtCondVtas
        '
        Me.dtCondVtas.AllowUserToAddRows = False
        Me.dtCondVtas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtCondVtas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtCondVtas.BackgroundColor = System.Drawing.Color.White
        Me.dtCondVtas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtCondVtas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtCondVtas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtCondVtas.Location = New System.Drawing.Point(0, 30)
        Me.dtCondVtas.MultiSelect = False
        Me.dtCondVtas.Name = "dtCondVtas"
        Me.dtCondVtas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtCondVtas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtCondVtas.Size = New System.Drawing.Size(584, 331)
        Me.dtCondVtas.TabIndex = 70
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(584, 30)
        Me.pntitulo.TabIndex = 69
        '
        'selCondVta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.dtCondVtas)
        Me.Controls.Add(Me.pntitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "selCondVta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "selCondVta"
        CType(Me.dtCondVtas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dtCondVtas As DataGridView
    Friend WithEvents pntitulo As Panel
End Class
