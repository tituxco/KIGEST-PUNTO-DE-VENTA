<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class listadoServicios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(listadoServicios))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabListadoSerivicios = New System.Windows.Forms.TabPage()
        Me.dgvlistado = New System.Windows.Forms.DataGridView()
        Me.pnnavegacion = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.btnFacturar = New System.Windows.Forms.Button()
        Me.btnNuevaPublicidad = New System.Windows.Forms.Button()
        Me.cmdbuscar = New System.Windows.Forms.Button()
        Me.cmdver = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.tabCtaCte = New System.Windows.Forms.TabPage()
        Me.dgvAlumnos = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.tabInformes = New System.Windows.Forms.TabPage()
        Me.dgvServicios = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tabListadoSerivicios.SuspendLayout()
        CType(Me.dgvlistado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnnavegacion.SuspendLayout()
        Me.tabCtaCte.SuspendLayout()
        CType(Me.dgvAlumnos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.tabInformes.SuspendLayout()
        CType(Me.dgvServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pntitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabListadoSerivicios)
        Me.TabControl1.Controls.Add(Me.tabCtaCte)
        Me.TabControl1.Controls.Add(Me.tabInformes)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1254, 410)
        Me.TabControl1.TabIndex = 78
        '
        'tabListadoSerivicios
        '
        Me.tabListadoSerivicios.Controls.Add(Me.dgvlistado)
        Me.tabListadoSerivicios.Controls.Add(Me.pnnavegacion)
        Me.tabListadoSerivicios.Location = New System.Drawing.Point(4, 22)
        Me.tabListadoSerivicios.Name = "tabListadoSerivicios"
        Me.tabListadoSerivicios.Padding = New System.Windows.Forms.Padding(3)
        Me.tabListadoSerivicios.Size = New System.Drawing.Size(1246, 384)
        Me.tabListadoSerivicios.TabIndex = 0
        Me.tabListadoSerivicios.Text = "Cursos activos"
        Me.tabListadoSerivicios.UseVisualStyleBackColor = True
        '
        'dgvlistado
        '
        Me.dgvlistado.AllowUserToAddRows = False
        Me.dgvlistado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvlistado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvlistado.BackgroundColor = System.Drawing.Color.White
        Me.dgvlistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlistado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvlistado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvlistado.Location = New System.Drawing.Point(3, 92)
        Me.dgvlistado.MultiSelect = False
        Me.dgvlistado.Name = "dgvlistado"
        Me.dgvlistado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvlistado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvlistado.Size = New System.Drawing.Size(1240, 289)
        Me.dgvlistado.TabIndex = 77
        '
        'pnnavegacion
        '
        Me.pnnavegacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnnavegacion.Controls.Add(Me.Label2)
        Me.pnnavegacion.Controls.Add(Me.Button8)
        Me.pnnavegacion.Controls.Add(Me.btnFacturar)
        Me.pnnavegacion.Controls.Add(Me.btnNuevaPublicidad)
        Me.pnnavegacion.Controls.Add(Me.cmdbuscar)
        Me.pnnavegacion.Controls.Add(Me.cmdver)
        Me.pnnavegacion.Controls.Add(Me.btnExportar)
        Me.pnnavegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnnavegacion.Location = New System.Drawing.Point(3, 3)
        Me.pnnavegacion.Name = "pnnavegacion"
        Me.pnnavegacion.Size = New System.Drawing.Size(1240, 89)
        Me.pnnavegacion.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(289, 29)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "ALUMNOS CURSANDO"
        '
        'Button8
        '
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Image = Global.SIGT__KIGEST.My.Resources.Resources.business_chat_64px
        Me.Button8.Location = New System.Drawing.Point(756, 0)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(79, 89)
        Me.Button8.TabIndex = 212
        Me.Button8.Text = "Cta.Cte."
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'btnFacturar
        '
        Me.btnFacturar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnFacturar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacturar.ForeColor = System.Drawing.Color.White
        Me.btnFacturar.Image = CType(resources.GetObject("btnFacturar.Image"), System.Drawing.Image)
        Me.btnFacturar.Location = New System.Drawing.Point(835, 0)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(79, 89)
        Me.btnFacturar.TabIndex = 195
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnFacturar.UseVisualStyleBackColor = True
        Me.btnFacturar.Visible = False
        '
        'btnNuevaPublicidad
        '
        Me.btnNuevaPublicidad.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnNuevaPublicidad.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnNuevaPublicidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevaPublicidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevaPublicidad.ForeColor = System.Drawing.Color.White
        Me.btnNuevaPublicidad.Image = CType(resources.GetObject("btnNuevaPublicidad.Image"), System.Drawing.Image)
        Me.btnNuevaPublicidad.Location = New System.Drawing.Point(914, 0)
        Me.btnNuevaPublicidad.Name = "btnNuevaPublicidad"
        Me.btnNuevaPublicidad.Size = New System.Drawing.Size(79, 89)
        Me.btnNuevaPublicidad.TabIndex = 185
        Me.btnNuevaPublicidad.Text = "Nueva"
        Me.btnNuevaPublicidad.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevaPublicidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNuevaPublicidad.UseVisualStyleBackColor = True
        '
        'cmdbuscar
        '
        Me.cmdbuscar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdbuscar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdbuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdbuscar.ForeColor = System.Drawing.Color.White
        Me.cmdbuscar.Image = CType(resources.GetObject("cmdbuscar.Image"), System.Drawing.Image)
        Me.cmdbuscar.Location = New System.Drawing.Point(993, 0)
        Me.cmdbuscar.Name = "cmdbuscar"
        Me.cmdbuscar.Size = New System.Drawing.Size(79, 89)
        Me.cmdbuscar.TabIndex = 184
        Me.cmdbuscar.Text = "Buscar"
        Me.cmdbuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdbuscar.UseVisualStyleBackColor = True
        Me.cmdbuscar.Visible = False
        '
        'cmdver
        '
        Me.cmdver.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdver.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdver.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdver.ForeColor = System.Drawing.Color.White
        Me.cmdver.Image = CType(resources.GetObject("cmdver.Image"), System.Drawing.Image)
        Me.cmdver.Location = New System.Drawing.Point(1072, 0)
        Me.cmdver.Name = "cmdver"
        Me.cmdver.Size = New System.Drawing.Size(79, 89)
        Me.cmdver.TabIndex = 170
        Me.cmdver.Text = "Ver"
        Me.cmdver.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdver.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.ForeColor = System.Drawing.Color.White
        Me.btnExportar.Image = Global.SIGT__KIGEST.My.Resources.Resources.Microsoft_Excel_64px
        Me.btnExportar.Location = New System.Drawing.Point(1151, 0)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(89, 89)
        Me.btnExportar.TabIndex = 0
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'tabCtaCte
        '
        Me.tabCtaCte.Controls.Add(Me.dgvAlumnos)
        Me.tabCtaCte.Controls.Add(Me.Panel1)
        Me.tabCtaCte.Location = New System.Drawing.Point(4, 22)
        Me.tabCtaCte.Name = "tabCtaCte"
        Me.tabCtaCte.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCtaCte.Size = New System.Drawing.Size(1246, 384)
        Me.tabCtaCte.TabIndex = 1
        Me.tabCtaCte.Text = "Listado de alumnos"
        Me.tabCtaCte.UseVisualStyleBackColor = True
        '
        'dgvAlumnos
        '
        Me.dgvAlumnos.AllowUserToAddRows = False
        Me.dgvAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAlumnos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvAlumnos.BackgroundColor = System.Drawing.Color.White
        Me.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAlumnos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAlumnos.Location = New System.Drawing.Point(3, 92)
        Me.dgvAlumnos.MultiSelect = False
        Me.dgvAlumnos.Name = "dgvAlumnos"
        Me.dgvAlumnos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAlumnos.Size = New System.Drawing.Size(1240, 289)
        Me.dgvAlumnos.TabIndex = 78
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1240, 89)
        Me.Panel1.TabIndex = 77
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(295, 29)
        Me.Label7.TabIndex = 195
        Me.Label7.Text = "PADRON DE ALUMNOS"
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(1014, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 89)
        Me.Button3.TabIndex = 184
        Me.Button3.Text = "Buscar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(1086, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(72, 89)
        Me.Button4.TabIndex = 170
        Me.Button4.Text = "Ver"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(1158, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(82, 89)
        Me.Button5.TabIndex = 0
        Me.Button5.Text = "Imprimir"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'tabInformes
        '
        Me.tabInformes.Controls.Add(Me.dgvServicios)
        Me.tabInformes.Controls.Add(Me.Panel2)
        Me.tabInformes.Location = New System.Drawing.Point(4, 22)
        Me.tabInformes.Name = "tabInformes"
        Me.tabInformes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInformes.Size = New System.Drawing.Size(1246, 384)
        Me.tabInformes.TabIndex = 2
        Me.tabInformes.Text = "Listado de cursos"
        Me.tabInformes.UseVisualStyleBackColor = True
        '
        'dgvServicios
        '
        Me.dgvServicios.AllowUserToAddRows = False
        Me.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvServicios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvServicios.BackgroundColor = System.Drawing.Color.White
        Me.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvServicios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvServicios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvServicios.Location = New System.Drawing.Point(3, 92)
        Me.dgvServicios.MultiSelect = False
        Me.dgvServicios.Name = "dgvServicios"
        Me.dgvServicios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvServicios.Size = New System.Drawing.Size(1240, 289)
        Me.dgvServicios.TabIndex = 81
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Button7)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1240, 89)
        Me.Panel2.TabIndex = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(390, 29)
        Me.Label3.TabIndex = 215
        Me.Label3.Text = "ADMINISTRACION DE CURSOS"
        '
        'Button7
        '
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Image = Global.SIGT__KIGEST.My.Resources.Resources.business_chat_64px
        Me.Button7.Location = New System.Drawing.Point(914, 0)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(79, 89)
        Me.Button7.TabIndex = 214
        Me.Button7.Text = "Cta.Cte."
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(993, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(79, 89)
        Me.Button2.TabIndex = 213
        Me.Button2.Text = "Ver"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1072, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 89)
        Me.Button1.TabIndex = 184
        Me.Button1.Text = "Buscar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button6
        '
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Image = Global.SIGT__KIGEST.My.Resources.Resources.Microsoft_Excel_64px1
        Me.Button6.Location = New System.Drawing.Point(1151, 0)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(89, 89)
        Me.Button6.TabIndex = 0
        Me.Button6.Text = "Exportar"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1254, 40)
        Me.pntitulo.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SERVICIO "
        '
        'listadoServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1254, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "listadoServicios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "listadoServicios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.tabListadoSerivicios.ResumeLayout(False)
        CType(Me.dgvlistado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnnavegacion.ResumeLayout(False)
        Me.pnnavegacion.PerformLayout()
        Me.tabCtaCte.ResumeLayout(False)
        CType(Me.dgvAlumnos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabInformes.ResumeLayout(False)
        CType(Me.dgvServicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabListadoSerivicios As TabPage
    Friend WithEvents pnnavegacion As Panel
    Friend WithEvents Button8 As Button
    Friend WithEvents btnFacturar As Button
    Friend WithEvents btnNuevaPublicidad As Button
    Friend WithEvents cmdbuscar As Button
    Friend WithEvents cmdver As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents tabCtaCte As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents tabInformes As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button7 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvlistado As DataGridView
    Friend WithEvents dgvAlumnos As DataGridView
    Friend WithEvents dgvServicios As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
