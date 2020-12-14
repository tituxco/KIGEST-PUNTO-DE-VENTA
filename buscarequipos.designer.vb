<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class buscarequipos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(buscarequipos))
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblresultados = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chksinfacturartrab = New System.Windows.Forms.CheckBox()
        Me.chkterminadostrab = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpdesdetrab = New System.Windows.Forms.DateTimePicker()
        Me.dtphastatrab = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdimprimirfing = New System.Windows.Forms.Button()
        Me.cmdingresataller = New System.Windows.Forms.Button()
        Me.lblBusqueda = New System.Windows.Forms.Label()
        Me.rdgarantias = New System.Windows.Forms.RadioButton()
        Me.rdorden = New System.Windows.Forms.RadioButton()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.rdcodint = New System.Windows.Forms.RadioButton()
        Me.rdserie = New System.Windows.Forms.RadioButton()
        Me.rdcliente = New System.Windows.Forms.RadioButton()
        Me.txtequiposclieBusqueda = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.dtresultado = New System.Windows.Forms.DataGridView()
        Me.rdequipo = New System.Windows.Forms.RadioButton()
        Me.Panel11.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.dtresultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel11.Controls.Add(Me.rdequipo)
        Me.Panel11.Controls.Add(Me.lblresultados)
        Me.Panel11.Controls.Add(Me.Button2)
        Me.Panel11.Controls.Add(Me.chksinfacturartrab)
        Me.Panel11.Controls.Add(Me.chkterminadostrab)
        Me.Panel11.Controls.Add(Me.Label7)
        Me.Panel11.Controls.Add(Me.Label8)
        Me.Panel11.Controls.Add(Me.dtpdesdetrab)
        Me.Panel11.Controls.Add(Me.dtphastatrab)
        Me.Panel11.Controls.Add(Me.Button1)
        Me.Panel11.Controls.Add(Me.cmdimprimirfing)
        Me.Panel11.Controls.Add(Me.cmdingresataller)
        Me.Panel11.Controls.Add(Me.lblBusqueda)
        Me.Panel11.Controls.Add(Me.rdgarantias)
        Me.Panel11.Controls.Add(Me.rdorden)
        Me.Panel11.Controls.Add(Me.cmdbuscar)
        Me.Panel11.Controls.Add(Me.rdcodint)
        Me.Panel11.Controls.Add(Me.rdserie)
        Me.Panel11.Controls.Add(Me.rdcliente)
        Me.Panel11.Controls.Add(Me.txtequiposclieBusqueda)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1267, 99)
        Me.Panel11.TabIndex = 1
        '
        'lblresultados
        '
        Me.lblresultados.AutoSize = True
        Me.lblresultados.BackColor = System.Drawing.Color.Transparent
        Me.lblresultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblresultados.ForeColor = System.Drawing.Color.White
        Me.lblresultados.Location = New System.Drawing.Point(3, 79)
        Me.lblresultados.Name = "lblresultados"
        Me.lblresultados.Size = New System.Drawing.Size(0, 20)
        Me.lblresultados.TabIndex = 88
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(728, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 99)
        Me.Button2.TabIndex = 87
        Me.Button2.Text = "EXPORTAR"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'chksinfacturartrab
        '
        Me.chksinfacturartrab.AutoSize = True
        Me.chksinfacturartrab.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chksinfacturartrab.ForeColor = System.Drawing.Color.White
        Me.chksinfacturartrab.Location = New System.Drawing.Point(632, 63)
        Me.chksinfacturartrab.Name = "chksinfacturartrab"
        Me.chksinfacturartrab.Size = New System.Drawing.Size(92, 17)
        Me.chksinfacturartrab.TabIndex = 86
        Me.chksinfacturartrab.Text = "Sin facturar"
        Me.chksinfacturartrab.UseVisualStyleBackColor = True
        '
        'chkterminadostrab
        '
        Me.chkterminadostrab.AutoSize = True
        Me.chkterminadostrab.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkterminadostrab.ForeColor = System.Drawing.Color.White
        Me.chkterminadostrab.Location = New System.Drawing.Point(632, 40)
        Me.chkterminadostrab.Name = "chkterminadostrab"
        Me.chkterminadostrab.Size = New System.Drawing.Size(91, 17)
        Me.chkterminadostrab.TabIndex = 85
        Me.chkterminadostrab.Text = "Terminados"
        Me.chkterminadostrab.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(236, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 20)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Desde"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(437, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 20)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Hasta"
        '
        'dtpdesdetrab
        '
        Me.dtpdesdetrab.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdesdetrab.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpdesdetrab.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdesdetrab.Location = New System.Drawing.Point(298, 68)
        Me.dtpdesdetrab.Name = "dtpdesdetrab"
        Me.dtpdesdetrab.Size = New System.Drawing.Size(131, 26)
        Me.dtpdesdetrab.TabIndex = 81
        '
        'dtphastatrab
        '
        Me.dtphastatrab.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphastatrab.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphastatrab.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtphastatrab.Location = New System.Drawing.Point(495, 68)
        Me.dtphastatrab.Name = "dtphastatrab"
        Me.dtphastatrab.Size = New System.Drawing.Size(131, 26)
        Me.dtphastatrab.TabIndex = 82
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(843, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 99)
        Me.Button1.TabIndex = 80
        Me.Button1.Text = "Imprimir FEG"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdimprimirfing
        '
        Me.cmdimprimirfing.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdimprimirfing.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdimprimirfing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdimprimirfing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdimprimirfing.ForeColor = System.Drawing.Color.White
        Me.cmdimprimirfing.Image = CType(resources.GetObject("cmdimprimirfing.Image"), System.Drawing.Image)
        Me.cmdimprimirfing.Location = New System.Drawing.Point(958, 0)
        Me.cmdimprimirfing.Name = "cmdimprimirfing"
        Me.cmdimprimirfing.Size = New System.Drawing.Size(115, 99)
        Me.cmdimprimirfing.TabIndex = 79
        Me.cmdimprimirfing.Text = "Imprimir FING"
        Me.cmdimprimirfing.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdimprimirfing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdimprimirfing.UseVisualStyleBackColor = True
        '
        'cmdingresataller
        '
        Me.cmdingresataller.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdingresataller.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdingresataller.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdingresataller.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdingresataller.ForeColor = System.Drawing.Color.White
        Me.cmdingresataller.Image = CType(resources.GetObject("cmdingresataller.Image"), System.Drawing.Image)
        Me.cmdingresataller.Location = New System.Drawing.Point(1073, 0)
        Me.cmdingresataller.Name = "cmdingresataller"
        Me.cmdingresataller.Size = New System.Drawing.Size(102, 99)
        Me.cmdingresataller.TabIndex = 78
        Me.cmdingresataller.Text = "Ingresar"
        Me.cmdingresataller.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdingresataller.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdingresataller.UseVisualStyleBackColor = True
        '
        'lblBusqueda
        '
        Me.lblBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblBusqueda.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusqueda.ForeColor = System.Drawing.Color.White
        Me.lblBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.lblBusqueda.Name = "lblBusqueda"
        Me.lblBusqueda.Size = New System.Drawing.Size(230, 99)
        Me.lblBusqueda.TabIndex = 77
        Me.lblBusqueda.Text = "BUSQUEDA DE EQUIPOS"
        Me.lblBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdgarantias
        '
        Me.rdgarantias.AutoSize = True
        Me.rdgarantias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdgarantias.ForeColor = System.Drawing.Color.White
        Me.rdgarantias.Location = New System.Drawing.Point(589, 12)
        Me.rdgarantias.Name = "rdgarantias"
        Me.rdgarantias.Size = New System.Drawing.Size(81, 17)
        Me.rdgarantias.TabIndex = 76
        Me.rdgarantias.Text = "Clie. Gtia."
        Me.rdgarantias.UseVisualStyleBackColor = True
        '
        'rdorden
        '
        Me.rdorden.AutoSize = True
        Me.rdorden.Checked = True
        Me.rdorden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdorden.ForeColor = System.Drawing.Color.White
        Me.rdorden.Location = New System.Drawing.Point(436, 12)
        Me.rdorden.Name = "rdorden"
        Me.rdorden.Size = New System.Drawing.Size(69, 17)
        Me.rdorden.TabIndex = 75
        Me.rdorden.TabStop = True
        Me.rdorden.Text = "ORDEN"
        Me.rdorden.UseVisualStyleBackColor = True
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdbuscar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscar.ForeColor = System.Drawing.Color.White
        Me.cmdbuscar.Image = CType(resources.GetObject("cmdbuscar.Image"), System.Drawing.Image)
        Me.cmdbuscar.Location = New System.Drawing.Point(1175, 0)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(92, 99)
        Me.cmdbuscar.TabIndex = 74
        Me.cmdbuscar.Text = "Buscar"
        Me.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdbuscar.UseVisualStyleBackColor = True
        '
        'rdcodint
        '
        Me.rdcodint.AutoSize = True
        Me.rdcodint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdcodint.ForeColor = System.Drawing.Color.White
        Me.rdcodint.Location = New System.Drawing.Point(362, 12)
        Me.rdcodint.Name = "rdcodint"
        Me.rdcodint.Size = New System.Drawing.Size(68, 17)
        Me.rdcodint.TabIndex = 72
        Me.rdcodint.Text = "CodINT"
        Me.rdcodint.UseVisualStyleBackColor = True
        '
        'rdserie
        '
        Me.rdserie.AutoSize = True
        Me.rdserie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdserie.ForeColor = System.Drawing.Color.White
        Me.rdserie.Location = New System.Drawing.Point(306, 12)
        Me.rdserie.Name = "rdserie"
        Me.rdserie.Size = New System.Drawing.Size(54, 17)
        Me.rdserie.TabIndex = 71
        Me.rdserie.Text = "Serie"
        Me.rdserie.UseVisualStyleBackColor = True
        '
        'rdcliente
        '
        Me.rdcliente.AutoSize = True
        Me.rdcliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdcliente.ForeColor = System.Drawing.Color.White
        Me.rdcliente.Location = New System.Drawing.Point(236, 12)
        Me.rdcliente.Name = "rdcliente"
        Me.rdcliente.Size = New System.Drawing.Size(64, 17)
        Me.rdcliente.TabIndex = 70
        Me.rdcliente.Text = "Cliente"
        Me.rdcliente.UseVisualStyleBackColor = True
        '
        'txtequiposclieBusqueda
        '
        Me.txtequiposclieBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtequiposclieBusqueda.Location = New System.Drawing.Point(236, 40)
        Me.txtequiposclieBusqueda.Name = "txtequiposclieBusqueda"
        Me.txtequiposclieBusqueda.Size = New System.Drawing.Size(390, 26)
        Me.txtequiposclieBusqueda.TabIndex = 69
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel12)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 99)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1267, 327)
        Me.Panel1.TabIndex = 2
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.dtresultado)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(1267, 327)
        Me.Panel12.TabIndex = 71
        '
        'dtresultado
        '
        Me.dtresultado.AllowUserToAddRows = False
        Me.dtresultado.AllowUserToDeleteRows = False
        Me.dtresultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtresultado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtresultado.BackgroundColor = System.Drawing.Color.White
        Me.dtresultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtresultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtresultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtresultado.Location = New System.Drawing.Point(0, 0)
        Me.dtresultado.MultiSelect = False
        Me.dtresultado.Name = "dtresultado"
        Me.dtresultado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dtresultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtresultado.Size = New System.Drawing.Size(1267, 327)
        Me.dtresultado.TabIndex = 11
        '
        'rdequipo
        '
        Me.rdequipo.AutoSize = True
        Me.rdequipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdequipo.ForeColor = System.Drawing.Color.White
        Me.rdequipo.Location = New System.Drawing.Point(511, 12)
        Me.rdequipo.Name = "rdequipo"
        Me.rdequipo.Size = New System.Drawing.Size(72, 17)
        Me.rdequipo.TabIndex = 89
        Me.rdequipo.Text = "EQUIPO"
        Me.rdequipo.UseVisualStyleBackColor = True
        '
        'buscarequipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 426)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "buscarequipos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "buscarequipos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.dtresultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents cmdbuscar As System.Windows.Forms.Button
    Friend WithEvents rdcodint As System.Windows.Forms.RadioButton
    Friend WithEvents rdserie As System.Windows.Forms.RadioButton
    Friend WithEvents rdcliente As System.Windows.Forms.RadioButton
    Friend WithEvents txtequiposclieBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents rdorden As System.Windows.Forms.RadioButton
    Friend WithEvents rdgarantias As System.Windows.Forms.RadioButton
    Friend WithEvents dtresultado As System.Windows.Forms.DataGridView
    Friend WithEvents lblBusqueda As System.Windows.Forms.Label
    Friend WithEvents cmdingresataller As System.Windows.Forms.Button
    Friend WithEvents cmdimprimirfing As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpdesdetrab As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtphastatrab As System.Windows.Forms.DateTimePicker
    Friend WithEvents chksinfacturartrab As System.Windows.Forms.CheckBox
    Friend WithEvents chkterminadostrab As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblresultados As System.Windows.Forms.Label
    Friend WithEvents rdequipo As RadioButton
End Class
