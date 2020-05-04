<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DGVPaginado
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.lblPagina = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPaginasTotales = New System.Windows.Forms.Label()
        Me.dgvVista = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dgvVista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSiguiente.Location = New System.Drawing.Point(468, 411)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(38, 23)
        Me.btnSiguiente.TabIndex = 1
        Me.btnSiguiente.Text = ">>>"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAnterior.Location = New System.Drawing.Point(3, 411)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(34, 23)
        Me.btnAnterior.TabIndex = 2
        Me.btnAnterior.Text = "<<<"
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'lblPagina
        '
        Me.lblPagina.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPagina.AutoSize = True
        Me.lblPagina.Location = New System.Drawing.Point(6, 13)
        Me.lblPagina.Name = "lblPagina"
        Me.lblPagina.Size = New System.Drawing.Size(13, 13)
        Me.lblPagina.TabIndex = 3
        Me.lblPagina.Text = "0"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "/"
        '
        'lblPaginasTotales
        '
        Me.lblPaginasTotales.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPaginasTotales.AutoSize = True
        Me.lblPaginasTotales.Location = New System.Drawing.Point(43, 13)
        Me.lblPaginasTotales.Name = "lblPaginasTotales"
        Me.lblPaginasTotales.Size = New System.Drawing.Size(13, 13)
        Me.lblPaginasTotales.TabIndex = 6
        Me.lblPaginasTotales.Text = "0"
        '
        'dgvVista
        '
        Me.dgvVista.AllowUserToAddRows = False
        Me.dgvVista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvVista.BackgroundColor = System.Drawing.Color.White
        Me.dgvVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvVista.Location = New System.Drawing.Point(3, 3)
        Me.dgvVista.MultiSelect = False
        Me.dgvVista.Name = "dgvVista"
        Me.dgvVista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvVista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVista.Size = New System.Drawing.Size(503, 402)
        Me.dgvVista.TabIndex = 65
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Panel1.Controls.Add(Me.lblPagina)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblPaginasTotales)
        Me.Panel1.Location = New System.Drawing.Point(214, 406)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(70, 36)
        Me.Panel1.TabIndex = 67
        '
        'DGVPaginado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvVista)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Name = "DGVPaginado"
        Me.Size = New System.Drawing.Size(509, 442)
        CType(Me.dgvVista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSiguiente As Button
    Friend WithEvents btnAnterior As Button
    Friend WithEvents lblPagina As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPaginasTotales As Label
    Public WithEvents dgvVista As DataGridView
    Friend WithEvents Panel1 As Panel
End Class
