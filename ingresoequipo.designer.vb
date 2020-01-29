<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ingresoequipo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ingresoequipo))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelcliente = New System.Windows.Forms.Panel()
        Me.chkenviamail = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtmail = New System.Windows.Forms.TextBox()
        Me.lblcodexistente = New System.Windows.Forms.Label()
        Me.cmbrecibeusuario = New System.Windows.Forms.ComboBox()
        Me.cmdguardar = New System.Windows.Forms.Button()
        Me.cmdimprimir = New System.Windows.Forms.Button()
        Me.txtcodint = New System.Windows.Forms.TextBox()
        Me.txtctaclie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtdomicilio = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtrazon = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pninfoextra = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtcasavendedora = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtinfoextra = New System.Windows.Forms.TextBox()
        Me.lblequipo = New System.Windows.Forms.Label()
        Me.paneldatosadicionales = New System.Windows.Forms.Panel()
        Me.chkcables = New System.Windows.Forms.CheckBox()
        Me.chkbateria = New System.Windows.Forms.CheckBox()
        Me.chkcargador = New System.Windows.Forms.CheckBox()
        Me.chkcaja = New System.Windows.Forms.CheckBox()
        Me.txtobservaciones = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtmotivo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtaccesorios = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.panelequipo = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbmodelos = New System.Windows.Forms.ComboBox()
        Me.txtnumeroSerie = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbmarcas = New System.Windows.Forms.ComboBox()
        Me.cmbtipoequ = New System.Windows.Forms.ComboBox()
        Me.tmrComprobarOR = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtnumor = New System.Windows.Forms.TextBox()
        Me.cmbcattrab = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblfecha = New System.Windows.Forms.Label()
        Me.panelingreso = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pntitulo.SuspendLayout()
        Me.panelcliente.SuspendLayout()
        Me.pninfoextra.SuspendLayout()
        Me.paneldatosadicionales.SuspendLayout()
        Me.panelequipo.SuspendLayout()
        Me.panelingreso.SuspendLayout()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1059, 40)
        Me.pntitulo.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(393, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "INGRESO DE EQUIPO"
        '
        'panelcliente
        '
        Me.panelcliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.panelcliente.Controls.Add(Me.chkenviamail)
        Me.panelcliente.Controls.Add(Me.Label23)
        Me.panelcliente.Controls.Add(Me.txttelefono)
        Me.panelcliente.Controls.Add(Me.Label16)
        Me.panelcliente.Controls.Add(Me.txtmail)
        Me.panelcliente.Controls.Add(Me.lblcodexistente)
        Me.panelcliente.Controls.Add(Me.cmbrecibeusuario)
        Me.panelcliente.Controls.Add(Me.cmdguardar)
        Me.panelcliente.Controls.Add(Me.cmdimprimir)
        Me.panelcliente.Controls.Add(Me.txtcodint)
        Me.panelcliente.Controls.Add(Me.txtctaclie)
        Me.panelcliente.Controls.Add(Me.Label2)
        Me.panelcliente.Controls.Add(Me.Label17)
        Me.panelcliente.Controls.Add(Me.txtdomicilio)
        Me.panelcliente.Controls.Add(Me.Label8)
        Me.panelcliente.Controls.Add(Me.txtrazon)
        Me.panelcliente.Controls.Add(Me.Label7)
        Me.panelcliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelcliente.ForeColor = System.Drawing.Color.White
        Me.panelcliente.Location = New System.Drawing.Point(0, 82)
        Me.panelcliente.Name = "panelcliente"
        Me.panelcliente.Size = New System.Drawing.Size(1059, 99)
        Me.panelcliente.TabIndex = 93
        '
        'chkenviamail
        '
        Me.chkenviamail.AutoSize = True
        Me.chkenviamail.Location = New System.Drawing.Point(415, 78)
        Me.chkenviamail.Name = "chkenviamail"
        Me.chkenviamail.Size = New System.Drawing.Size(15, 14)
        Me.chkenviamail.TabIndex = 233
        Me.chkenviamail.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 78)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(92, 16)
        Me.Label23.TabIndex = 232
        Me.Label23.Text = "TELEFONO:"
        '
        'txttelefono
        '
        Me.txttelefono.BackColor = System.Drawing.Color.White
        Me.txttelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttelefono.ForeColor = System.Drawing.Color.Red
        Me.txttelefono.Location = New System.Drawing.Point(96, 74)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(251, 20)
        Me.txttelefono.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(353, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 16)
        Me.Label16.TabIndex = 230
        Me.Label16.Text = "E-Mail:"
        '
        'txtmail
        '
        Me.txtmail.Location = New System.Drawing.Point(431, 74)
        Me.txtmail.Name = "txtmail"
        Me.txtmail.Size = New System.Drawing.Size(272, 20)
        Me.txtmail.TabIndex = 16
        '
        'lblcodexistente
        '
        Me.lblcodexistente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcodexistente.ForeColor = System.Drawing.Color.Fuchsia
        Me.lblcodexistente.Location = New System.Drawing.Point(392, 49)
        Me.lblcodexistente.Name = "lblcodexistente"
        Me.lblcodexistente.Size = New System.Drawing.Size(364, 20)
        Me.lblcodexistente.TabIndex = 228
        Me.lblcodexistente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbrecibeusuario
        '
        Me.cmbrecibeusuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbrecibeusuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbrecibeusuario.Enabled = False
        Me.cmbrecibeusuario.FormattingEnabled = True
        Me.cmbrecibeusuario.Location = New System.Drawing.Point(88, 48)
        Me.cmbrecibeusuario.Name = "cmbrecibeusuario"
        Me.cmbrecibeusuario.Size = New System.Drawing.Size(283, 21)
        Me.cmbrecibeusuario.TabIndex = 4
        '
        'cmdguardar
        '
        Me.cmdguardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdguardar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdguardar.ForeColor = System.Drawing.Color.White
        Me.cmdguardar.Image = CType(resources.GetObject("cmdguardar.Image"), System.Drawing.Image)
        Me.cmdguardar.Location = New System.Drawing.Point(855, 0)
        Me.cmdguardar.Name = "cmdguardar"
        Me.cmdguardar.Size = New System.Drawing.Size(102, 99)
        Me.cmdguardar.TabIndex = 14
        Me.cmdguardar.Text = "Guardar"
        Me.cmdguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdguardar.UseVisualStyleBackColor = True
        '
        'cmdimprimir
        '
        Me.cmdimprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdimprimir.Enabled = False
        Me.cmdimprimir.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdimprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdimprimir.ForeColor = System.Drawing.Color.White
        Me.cmdimprimir.Image = CType(resources.GetObject("cmdimprimir.Image"), System.Drawing.Image)
        Me.cmdimprimir.Location = New System.Drawing.Point(957, 0)
        Me.cmdimprimir.Name = "cmdimprimir"
        Me.cmdimprimir.Size = New System.Drawing.Size(102, 99)
        Me.cmdimprimir.TabIndex = 15
        Me.cmdimprimir.Text = "Imprimir"
        Me.cmdimprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdimprimir.UseVisualStyleBackColor = True
        '
        'txtcodint
        '
        Me.txtcodint.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodint.Location = New System.Drawing.Point(638, 3)
        Me.txtcodint.Name = "txtcodint"
        Me.txtcodint.Size = New System.Drawing.Size(118, 44)
        Me.txtcodint.TabIndex = 3
        '
        'txtctaclie
        '
        Me.txtctaclie.Location = New System.Drawing.Point(75, 3)
        Me.txtctaclie.Name = "txtctaclie"
        Me.txtctaclie.Size = New System.Drawing.Size(91, 20)
        Me.txtctaclie.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(559, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "COD INT:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 16)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "RECIBIO:"
        '
        'txtdomicilio
        '
        Me.txtdomicilio.Location = New System.Drawing.Point(88, 26)
        Me.txtdomicilio.Name = "txtdomicilio"
        Me.txtdomicilio.ReadOnly = True
        Me.txtdomicilio.Size = New System.Drawing.Size(465, 20)
        Me.txtdomicilio.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 16)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "DOMICILIO:"
        '
        'txtrazon
        '
        Me.txtrazon.Location = New System.Drawing.Point(172, 3)
        Me.txtrazon.Name = "txtrazon"
        Me.txtrazon.Size = New System.Drawing.Size(381, 20)
        Me.txtrazon.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "CLIENTE:"
        '
        'pninfoextra
        '
        Me.pninfoextra.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pninfoextra.Controls.Add(Me.Label15)
        Me.pninfoextra.Controls.Add(Me.txtcasavendedora)
        Me.pninfoextra.Controls.Add(Me.Label3)
        Me.pninfoextra.Controls.Add(Me.txtinfoextra)
        Me.pninfoextra.Dock = System.Windows.Forms.DockStyle.Top
        Me.pninfoextra.Location = New System.Drawing.Point(0, 181)
        Me.pninfoextra.Name = "pninfoextra"
        Me.pninfoextra.Size = New System.Drawing.Size(1059, 31)
        Me.pninfoextra.TabIndex = 94
        Me.pninfoextra.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(389, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(129, 16)
        Me.Label15.TabIndex = 54
        Me.Label15.Text = "Casa Vendedora:"
        '
        'txtcasavendedora
        '
        Me.txtcasavendedora.Location = New System.Drawing.Point(520, 5)
        Me.txtcasavendedora.Name = "txtcasavendedora"
        Me.txtcasavendedora.Size = New System.Drawing.Size(273, 20)
        Me.txtcasavendedora.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 16)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Propietario:"
        '
        'txtinfoextra
        '
        Me.txtinfoextra.Location = New System.Drawing.Point(98, 5)
        Me.txtinfoextra.Name = "txtinfoextra"
        Me.txtinfoextra.Size = New System.Drawing.Size(273, 20)
        Me.txtinfoextra.TabIndex = 17
        '
        'lblequipo
        '
        Me.lblequipo.AutoSize = True
        Me.lblequipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblequipo.ForeColor = System.Drawing.Color.White
        Me.lblequipo.Location = New System.Drawing.Point(759, 24)
        Me.lblequipo.Name = "lblequipo"
        Me.lblequipo.Size = New System.Drawing.Size(0, 16)
        Me.lblequipo.TabIndex = 55
        '
        'paneldatosadicionales
        '
        Me.paneldatosadicionales.AutoScroll = True
        Me.paneldatosadicionales.BackColor = System.Drawing.Color.White
        Me.paneldatosadicionales.Controls.Add(Me.chkcables)
        Me.paneldatosadicionales.Controls.Add(Me.chkbateria)
        Me.paneldatosadicionales.Controls.Add(Me.chkcargador)
        Me.paneldatosadicionales.Controls.Add(Me.chkcaja)
        Me.paneldatosadicionales.Controls.Add(Me.txtobservaciones)
        Me.paneldatosadicionales.Controls.Add(Me.Label14)
        Me.paneldatosadicionales.Controls.Add(Me.txtmotivo)
        Me.paneldatosadicionales.Controls.Add(Me.Label13)
        Me.paneldatosadicionales.Controls.Add(Me.txtaccesorios)
        Me.paneldatosadicionales.Controls.Add(Me.Label12)
        Me.paneldatosadicionales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.paneldatosadicionales.Location = New System.Drawing.Point(0, 212)
        Me.paneldatosadicionales.Name = "paneldatosadicionales"
        Me.paneldatosadicionales.Size = New System.Drawing.Size(1059, 324)
        Me.paneldatosadicionales.TabIndex = 95
        '
        'chkcables
        '
        Me.chkcables.AutoSize = True
        Me.chkcables.Location = New System.Drawing.Point(235, 135)
        Me.chkcables.Name = "chkcables"
        Me.chkcables.Size = New System.Drawing.Size(85, 17)
        Me.chkcables.TabIndex = 27
        Me.chkcables.Text = "CABLE USB"
        Me.chkcables.UseVisualStyleBackColor = True
        '
        'chkbateria
        '
        Me.chkbateria.AutoSize = True
        Me.chkbateria.Location = New System.Drawing.Point(157, 135)
        Me.chkbateria.Name = "chkbateria"
        Me.chkbateria.Size = New System.Drawing.Size(72, 17)
        Me.chkbateria.TabIndex = 26
        Me.chkbateria.Text = "BATERIA"
        Me.chkbateria.UseVisualStyleBackColor = True
        '
        'chkcargador
        '
        Me.chkcargador.AutoSize = True
        Me.chkcargador.Location = New System.Drawing.Point(64, 135)
        Me.chkcargador.Name = "chkcargador"
        Me.chkcargador.Size = New System.Drawing.Size(87, 17)
        Me.chkcargador.TabIndex = 25
        Me.chkcargador.Text = "CARGADOR"
        Me.chkcargador.UseVisualStyleBackColor = True
        '
        'chkcaja
        '
        Me.chkcaja.AutoSize = True
        Me.chkcaja.Location = New System.Drawing.Point(6, 135)
        Me.chkcaja.Name = "chkcaja"
        Me.chkcaja.Size = New System.Drawing.Size(52, 17)
        Me.chkcaja.TabIndex = 24
        Me.chkcaja.Text = "CAJA"
        Me.chkcaja.UseVisualStyleBackColor = True
        '
        'txtobservaciones
        '
        Me.txtobservaciones.Location = New System.Drawing.Point(6, 284)
        Me.txtobservaciones.Multiline = True
        Me.txtobservaciones.Name = "txtobservaciones"
        Me.txtobservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtobservaciones.Size = New System.Drawing.Size(750, 56)
        Me.txtobservaciones.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 265)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 16)
        Me.Label14.TabIndex = 223
        Me.Label14.Text = "OBSERVACIONES"
        '
        'txtmotivo
        '
        Me.txtmotivo.Location = New System.Drawing.Point(6, 205)
        Me.txtmotivo.Multiline = True
        Me.txtmotivo.Name = "txtmotivo"
        Me.txtmotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtmotivo.Size = New System.Drawing.Size(750, 56)
        Me.txtmotivo.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 186)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(163, 16)
        Me.Label13.TabIndex = 221
        Me.Label13.Text = "MOTIVO DE INGRESO"
        '
        'txtaccesorios
        '
        Me.txtaccesorios.Location = New System.Drawing.Point(6, 158)
        Me.txtaccesorios.Name = "txtaccesorios"
        Me.txtaccesorios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtaccesorios.Size = New System.Drawing.Size(750, 20)
        Me.txtaccesorios.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 16)
        Me.Label12.TabIndex = 219
        Me.Label12.Text = "ACCESORIOS"
        '
        'panelequipo
        '
        Me.panelequipo.Controls.Add(Me.Button1)
        Me.panelequipo.Controls.Add(Me.lblequipo)
        Me.panelequipo.Controls.Add(Me.cmbmodelos)
        Me.panelequipo.Controls.Add(Me.txtnumeroSerie)
        Me.panelequipo.Controls.Add(Me.Label11)
        Me.panelequipo.Controls.Add(Me.Label10)
        Me.panelequipo.Controls.Add(Me.Label9)
        Me.panelequipo.Controls.Add(Me.Label6)
        Me.panelequipo.Controls.Add(Me.cmbmarcas)
        Me.panelequipo.Controls.Add(Me.cmbtipoequ)
        Me.panelequipo.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelequipo.Location = New System.Drawing.Point(0, 212)
        Me.panelequipo.Name = "panelequipo"
        Me.panelequipo.Size = New System.Drawing.Size(1059, 100)
        Me.panelequipo.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(729, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 21)
        Me.Button1.TabIndex = 226
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbmodelos
        '
        Me.cmbmodelos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmodelos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmodelos.FormattingEnabled = True
        Me.cmbmodelos.Location = New System.Drawing.Point(520, 22)
        Me.cmbmodelos.Name = "cmbmodelos"
        Me.cmbmodelos.Size = New System.Drawing.Size(208, 21)
        Me.cmbmodelos.TabIndex = 22
        '
        'txtnumeroSerie
        '
        Me.txtnumeroSerie.Location = New System.Drawing.Point(6, 75)
        Me.txtnumeroSerie.Name = "txtnumeroSerie"
        Me.txtnumeroSerie.Size = New System.Drawing.Size(750, 20)
        Me.txtnumeroSerie.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(148, 16)
        Me.Label11.TabIndex = 225
        Me.Label11.Text = "NUMERO DE SERIE"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(517, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 16)
        Me.Label10.TabIndex = 224
        Me.Label10.Text = "MODELO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(260, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 16)
        Me.Label9.TabIndex = 223
        Me.Label9.Text = "MARCA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 16)
        Me.Label6.TabIndex = 222
        Me.Label6.Text = "TIPO DE EQUIPO"
        '
        'cmbmarcas
        '
        Me.cmbmarcas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmarcas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmarcas.FormattingEnabled = True
        Me.cmbmarcas.Location = New System.Drawing.Point(263, 22)
        Me.cmbmarcas.Name = "cmbmarcas"
        Me.cmbmarcas.Size = New System.Drawing.Size(236, 21)
        Me.cmbmarcas.TabIndex = 21
        '
        'cmbtipoequ
        '
        Me.cmbtipoequ.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtipoequ.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtipoequ.FormattingEnabled = True
        Me.cmbtipoequ.Location = New System.Drawing.Point(6, 22)
        Me.cmbtipoequ.Name = "cmbtipoequ"
        Me.cmbtipoequ.Size = New System.Drawing.Size(242, 21)
        Me.cmbtipoequ.TabIndex = 20
        '
        'tmrComprobarOR
        '
        Me.tmrComprobarOR.Enabled = True
        Me.tmrComprobarOR.Interval = 5000
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(429, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 16)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "OR numero:"
        '
        'txtnumor
        '
        Me.txtnumor.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtnumor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumor.ForeColor = System.Drawing.Color.White
        Me.txtnumor.Location = New System.Drawing.Point(524, 5)
        Me.txtnumor.Name = "txtnumor"
        Me.txtnumor.ReadOnly = True
        Me.txtnumor.Size = New System.Drawing.Size(125, 29)
        Me.txtnumor.TabIndex = 1
        '
        'cmbcattrab
        '
        Me.cmbcattrab.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcattrab.FormattingEnabled = True
        Me.cmbcattrab.Location = New System.Drawing.Point(123, 6)
        Me.cmbcattrab.Name = "cmbcattrab"
        Me.cmbcattrab.Size = New System.Drawing.Size(295, 28)
        Me.cmbcattrab.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 16)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Tipo de trabajo:"
        '
        'lblfecha
        '
        Me.lblfecha.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfecha.ForeColor = System.Drawing.Color.White
        Me.lblfecha.Location = New System.Drawing.Point(730, 0)
        Me.lblfecha.Name = "lblfecha"
        Me.lblfecha.Size = New System.Drawing.Size(329, 42)
        Me.lblfecha.TabIndex = 41
        Me.lblfecha.Text = "Fecha:"
        Me.lblfecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelingreso
        '
        Me.panelingreso.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.panelingreso.Controls.Add(Me.lblfecha)
        Me.panelingreso.Controls.Add(Me.Label4)
        Me.panelingreso.Controls.Add(Me.cmbcattrab)
        Me.panelingreso.Controls.Add(Me.txtnumor)
        Me.panelingreso.Controls.Add(Me.Label5)
        Me.panelingreso.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelingreso.ForeColor = System.Drawing.Color.White
        Me.panelingreso.Location = New System.Drawing.Point(0, 40)
        Me.panelingreso.Name = "panelingreso"
        Me.panelingreso.Size = New System.Drawing.Size(1059, 42)
        Me.panelingreso.TabIndex = 91
        '
        'Timer1
        '
        Me.Timer1.Interval = 300
        '
        'ingresoequipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 536)
        Me.Controls.Add(Me.panelequipo)
        Me.Controls.Add(Me.paneldatosadicionales)
        Me.Controls.Add(Me.pninfoextra)
        Me.Controls.Add(Me.panelcliente)
        Me.Controls.Add(Me.panelingreso)
        Me.Controls.Add(Me.pntitulo)
        Me.KeyPreview = True
        Me.Name = "ingresoequipo"
        Me.Text = "ingresoequipo"
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.panelcliente.ResumeLayout(False)
        Me.panelcliente.PerformLayout()
        Me.pninfoextra.ResumeLayout(False)
        Me.pninfoextra.PerformLayout()
        Me.paneldatosadicionales.ResumeLayout(False)
        Me.paneldatosadicionales.PerformLayout()
        Me.panelequipo.ResumeLayout(False)
        Me.panelequipo.PerformLayout()
        Me.panelingreso.ResumeLayout(False)
        Me.panelingreso.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents panelcliente As System.Windows.Forms.Panel
    Friend WithEvents txtcodint As System.Windows.Forms.TextBox
    Friend WithEvents txtctaclie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtdomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtrazon As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pninfoextra As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtinfoextra As System.Windows.Forms.TextBox
    Friend WithEvents paneldatosadicionales As System.Windows.Forms.Panel
    Friend WithEvents txtmotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtaccesorios As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdimprimir As System.Windows.Forms.Button
    Friend WithEvents txtobservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents panelequipo As System.Windows.Forms.Panel
    Friend WithEvents txtnumeroSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbmarcas As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtipoequ As System.Windows.Forms.ComboBox
    Friend WithEvents cmdguardar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtcasavendedora As System.Windows.Forms.TextBox
    Friend WithEvents tmrComprobarOR As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtnumor As System.Windows.Forms.TextBox
    Friend WithEvents cmbcattrab As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblfecha As System.Windows.Forms.Label
    Friend WithEvents panelingreso As System.Windows.Forms.Panel
    Friend WithEvents cmbmodelos As System.Windows.Forms.ComboBox
    Friend WithEvents cmbrecibeusuario As System.Windows.Forms.ComboBox
    Friend WithEvents lblequipo As System.Windows.Forms.Label
    Friend WithEvents chkcables As System.Windows.Forms.CheckBox
    Friend WithEvents chkbateria As System.Windows.Forms.CheckBox
    Friend WithEvents chkcargador As System.Windows.Forms.CheckBox
    Friend WithEvents chkcaja As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblcodexistente As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtmail As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txttelefono As System.Windows.Forms.TextBox
    Friend WithEvents chkenviamail As System.Windows.Forms.CheckBox
End Class
