<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cheques_en_cartera
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cheques_en_cartera))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.cmdaceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbltotalvalores = New System.Windows.Forms.Label()
        Me.lbltotalfacturas = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtchequesterceros = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtfiltraterceros = New System.Windows.Forms.TextBox()
        Me.cmbtercerosSelAll = New System.Windows.Forms.Button()
        Me.cmbtercerosSellNone = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dtchequespropios = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtfiltrapropios = New System.Windows.Forms.TextBox()
        Me.cmbpropiosSellAll = New System.Windows.Forms.Button()
        Me.cmbpropiosSellNone = New System.Windows.Forms.Button()
        Me.pntitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtchequesterceros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dtchequespropios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.cmdaceptar)
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(533, 61)
        Me.pntitulo.TabIndex = 32
        '
        'cmdaceptar
        '
        Me.cmdaceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdaceptar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdaceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdaceptar.ForeColor = System.Drawing.Color.White
        Me.cmdaceptar.Image = CType(resources.GetObject("cmdaceptar.Image"), System.Drawing.Image)
        Me.cmdaceptar.Location = New System.Drawing.Point(461, 0)
        Me.cmdaceptar.Name = "cmdaceptar"
        Me.cmdaceptar.Size = New System.Drawing.Size(72, 61)
        Me.cmdaceptar.TabIndex = 32
        Me.cmdaceptar.Text = "Aceptar"
        Me.cmdaceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdaceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdaceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(429, 61)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SELECCIONE VALORES"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbltotalvalores)
        Me.Panel1.Controls.Add(Me.lbltotalfacturas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 394)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(533, 23)
        Me.Panel1.TabIndex = 33
        '
        'lbltotalvalores
        '
        Me.lbltotalvalores.AutoSize = True
        Me.lbltotalvalores.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbltotalvalores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalvalores.Location = New System.Drawing.Point(138, 0)
        Me.lbltotalvalores.Name = "lbltotalvalores"
        Me.lbltotalvalores.Size = New System.Drawing.Size(102, 20)
        Me.lbltotalvalores.TabIndex = 3
        Me.lbltotalvalores.Text = "Total Valores"
        '
        'lbltotalfacturas
        '
        Me.lbltotalfacturas.AutoSize = True
        Me.lbltotalfacturas.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbltotalfacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalfacturas.Location = New System.Drawing.Point(0, 0)
        Me.lbltotalfacturas.Name = "lbltotalfacturas"
        Me.lbltotalfacturas.Size = New System.Drawing.Size(138, 20)
        Me.lbltotalfacturas.TabIndex = 2
        Me.lbltotalfacturas.Text = "Total por Facturas"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 61)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(533, 333)
        Me.TabControl1.TabIndex = 34
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtchequesterceros)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(525, 307)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cheques de terceros"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtchequesterceros
        '
        Me.dtchequesterceros.AllowUserToAddRows = False
        Me.dtchequesterceros.AllowUserToDeleteRows = False
        Me.dtchequesterceros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtchequesterceros.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtchequesterceros.BackgroundColor = System.Drawing.Color.White
        Me.dtchequesterceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtchequesterceros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtchequesterceros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtchequesterceros.Location = New System.Drawing.Point(3, 46)
        Me.dtchequesterceros.Name = "dtchequesterceros"
        Me.dtchequesterceros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtchequesterceros.Size = New System.Drawing.Size(519, 258)
        Me.dtchequesterceros.TabIndex = 15
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtfiltraterceros)
        Me.Panel2.Controls.Add(Me.cmbtercerosSelAll)
        Me.Panel2.Controls.Add(Me.cmbtercerosSellNone)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(519, 43)
        Me.Panel2.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Numero"
        '
        'txtfiltraterceros
        '
        Me.txtfiltraterceros.Location = New System.Drawing.Point(61, 17)
        Me.txtfiltraterceros.Name = "txtfiltraterceros"
        Me.txtfiltraterceros.Size = New System.Drawing.Size(163, 20)
        Me.txtfiltraterceros.TabIndex = 3
        '
        'cmbtercerosSelAll
        '
        Me.cmbtercerosSelAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbtercerosSelAll.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmbtercerosSelAll.Image = CType(resources.GetObject("cmbtercerosSelAll.Image"), System.Drawing.Image)
        Me.cmbtercerosSelAll.Location = New System.Drawing.Point(413, 0)
        Me.cmbtercerosSelAll.Name = "cmbtercerosSelAll"
        Me.cmbtercerosSelAll.Size = New System.Drawing.Size(53, 43)
        Me.cmbtercerosSelAll.TabIndex = 2
        Me.cmbtercerosSelAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmbtercerosSelAll.UseVisualStyleBackColor = False
        Me.cmbtercerosSelAll.Visible = False
        '
        'cmbtercerosSellNone
        '
        Me.cmbtercerosSellNone.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbtercerosSellNone.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmbtercerosSellNone.Image = CType(resources.GetObject("cmbtercerosSellNone.Image"), System.Drawing.Image)
        Me.cmbtercerosSellNone.Location = New System.Drawing.Point(466, 0)
        Me.cmbtercerosSellNone.Name = "cmbtercerosSellNone"
        Me.cmbtercerosSellNone.Size = New System.Drawing.Size(53, 43)
        Me.cmbtercerosSellNone.TabIndex = 1
        Me.cmbtercerosSellNone.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmbtercerosSellNone.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dtchequespropios)
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(525, 307)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cheques propios"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dtchequespropios
        '
        Me.dtchequespropios.AllowUserToAddRows = False
        Me.dtchequespropios.AllowUserToDeleteRows = False
        Me.dtchequespropios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtchequespropios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtchequespropios.BackgroundColor = System.Drawing.Color.White
        Me.dtchequespropios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtchequespropios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtchequespropios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtchequespropios.Location = New System.Drawing.Point(3, 46)
        Me.dtchequespropios.Name = "dtchequespropios"
        Me.dtchequespropios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtchequespropios.Size = New System.Drawing.Size(519, 258)
        Me.dtchequespropios.TabIndex = 16
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtfiltrapropios)
        Me.Panel3.Controls.Add(Me.cmbpropiosSellAll)
        Me.Panel3.Controls.Add(Me.cmbpropiosSellNone)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(519, 43)
        Me.Panel3.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Numero"
        '
        'txtfiltrapropios
        '
        Me.txtfiltrapropios.Location = New System.Drawing.Point(61, 16)
        Me.txtfiltrapropios.Name = "txtfiltrapropios"
        Me.txtfiltrapropios.Size = New System.Drawing.Size(163, 20)
        Me.txtfiltrapropios.TabIndex = 5
        '
        'cmbpropiosSellAll
        '
        Me.cmbpropiosSellAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbpropiosSellAll.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmbpropiosSellAll.Image = CType(resources.GetObject("cmbpropiosSellAll.Image"), System.Drawing.Image)
        Me.cmbpropiosSellAll.Location = New System.Drawing.Point(413, 0)
        Me.cmbpropiosSellAll.Name = "cmbpropiosSellAll"
        Me.cmbpropiosSellAll.Size = New System.Drawing.Size(53, 43)
        Me.cmbpropiosSellAll.TabIndex = 2
        Me.cmbpropiosSellAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmbpropiosSellAll.UseVisualStyleBackColor = False
        Me.cmbpropiosSellAll.Visible = False
        '
        'cmbpropiosSellNone
        '
        Me.cmbpropiosSellNone.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbpropiosSellNone.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmbpropiosSellNone.Image = CType(resources.GetObject("cmbpropiosSellNone.Image"), System.Drawing.Image)
        Me.cmbpropiosSellNone.Location = New System.Drawing.Point(466, 0)
        Me.cmbpropiosSellNone.Name = "cmbpropiosSellNone"
        Me.cmbpropiosSellNone.Size = New System.Drawing.Size(53, 43)
        Me.cmbpropiosSellNone.TabIndex = 1
        Me.cmbpropiosSellNone.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmbpropiosSellNone.UseVisualStyleBackColor = False
        '
        'cheques_en_cartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(533, 417)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "cheques_en_cartera"
        Me.Text = "cheques_en_cartera"
        Me.pntitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dtchequesterceros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dtchequespropios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lbltotalvalores As System.Windows.Forms.Label
    Friend WithEvents lbltotalfacturas As System.Windows.Forms.Label
    Friend WithEvents cmdaceptar As System.Windows.Forms.Button
    Friend WithEvents dtchequesterceros As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbtercerosSelAll As System.Windows.Forms.Button
    Friend WithEvents cmbtercerosSellNone As System.Windows.Forms.Button
    Friend WithEvents dtchequespropios As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmbpropiosSellAll As System.Windows.Forms.Button
    Friend WithEvents cmbpropiosSellNone As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtfiltraterceros As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtfiltrapropios As System.Windows.Forms.TextBox
End Class
