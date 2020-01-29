<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class selfac
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(selfac))
        Me.dtfacturas = New System.Windows.Forms.DataGridView()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.cmdaceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblsaldo = New System.Windows.Forms.Label()
        Me.lbltotalfacturas = New System.Windows.Forms.Label()
        Me.lbltotalrecibo = New System.Windows.Forms.Label()
        CType(Me.dtfacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pntitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtfacturas
        '
        Me.dtfacturas.AllowUserToAddRows = False
        Me.dtfacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtfacturas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtfacturas.BackgroundColor = System.Drawing.Color.White
        Me.dtfacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtfacturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtfacturas.Location = New System.Drawing.Point(0, 63)
        Me.dtfacturas.Name = "dtfacturas"
        Me.dtfacturas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtfacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtfacturas.Size = New System.Drawing.Size(615, 282)
        Me.dtfacturas.TabIndex = 66
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.cmdaceptar)
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(615, 57)
        Me.pntitulo.TabIndex = 65
        '
        'cmdaceptar
        '
        Me.cmdaceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdaceptar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdaceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdaceptar.ForeColor = System.Drawing.Color.White
        Me.cmdaceptar.Image = CType(resources.GetObject("cmdaceptar.Image"), System.Drawing.Image)
        Me.cmdaceptar.Location = New System.Drawing.Point(543, 0)
        Me.cmdaceptar.Name = "cmdaceptar"
        Me.cmdaceptar.Size = New System.Drawing.Size(72, 57)
        Me.cmdaceptar.TabIndex = 31
        Me.cmdaceptar.Text = "Aceptar"
        Me.cmdaceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdaceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdaceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(451, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "FACTURAS PENDIENTES"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblsaldo)
        Me.Panel1.Controls.Add(Me.lbltotalfacturas)
        Me.Panel1.Controls.Add(Me.lbltotalrecibo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 351)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(615, 24)
        Me.Panel1.TabIndex = 67
        '
        'lblsaldo
        '
        Me.lblsaldo.AutoSize = True
        Me.lblsaldo.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblsaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsaldo.Location = New System.Drawing.Point(224, 0)
        Me.lblsaldo.Name = "lblsaldo"
        Me.lblsaldo.Size = New System.Drawing.Size(0, 20)
        Me.lblsaldo.TabIndex = 2
        '
        'lbltotalfacturas
        '
        Me.lbltotalfacturas.AutoSize = True
        Me.lbltotalfacturas.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbltotalfacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalfacturas.Location = New System.Drawing.Point(113, 0)
        Me.lbltotalfacturas.Name = "lbltotalfacturas"
        Me.lbltotalfacturas.Size = New System.Drawing.Size(111, 20)
        Me.lbltotalfacturas.TabIndex = 1
        Me.lbltotalfacturas.Text = "Total Facturas"
        '
        'lbltotalrecibo
        '
        Me.lbltotalrecibo.AutoSize = True
        Me.lbltotalrecibo.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbltotalrecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalrecibo.Location = New System.Drawing.Point(0, 0)
        Me.lbltotalrecibo.Name = "lbltotalrecibo"
        Me.lbltotalrecibo.Size = New System.Drawing.Size(113, 20)
        Me.lbltotalrecibo.TabIndex = 0
        Me.lbltotalrecibo.Text = "Total de recibo"
        '
        'selfac
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 375)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtfacturas)
        Me.Controls.Add(Me.pntitulo)
        Me.MaximizeBox = False
        Me.Name = "selfac"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "selfac"
        CType(Me.dtfacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtfacturas As System.Windows.Forms.DataGridView
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbltotalfacturas As System.Windows.Forms.Label
    Friend WithEvents lbltotalrecibo As System.Windows.Forms.Label
    Friend WithEvents lblsaldo As System.Windows.Forms.Label
    Friend WithEvents cmdaceptar As System.Windows.Forms.Button
End Class
