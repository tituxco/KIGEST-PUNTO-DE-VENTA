<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NvaFacturaCompra
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbCtaContable = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtcomprobanteFcompra = New System.Windows.Forms.TextBox()
        Me.gbFactComb = New System.Windows.Forms.GroupBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.txtivafact = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.txttotalfac = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmdcalcFactComb = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtLitrosComb = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCoefComb = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtfacCombNoGrav = New System.Windows.Forms.TextBox()
        Me.GbTiketPeaje = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtcantTik = New System.Windows.Forms.TextBox()
        Me.cmdCalcTik = New System.Windows.Forms.Button()
        Me.cmdTikExc = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtIvaTik = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtmontoTik = New System.Windows.Forms.TextBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.txtnetocom27 = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.txtnetocom105 = New System.Windows.Forms.TextBox()
        Me.chkcomprabiendeuso = New System.Windows.Forms.CheckBox()
        Me.txtfacder = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmdcalcPagoaCuenta = New System.Windows.Forms.Button()
        Me.txtfaciz = New System.Windows.Forms.TextBox()
        Me.dtpfechacomp = New System.Windows.Forms.DateTimePicker()
        Me.cmbrazonComp = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtobservacionesComp = New System.Windows.Forms.TextBox()
        Me.cmdFinalizar = New System.Windows.Forms.Button()
        Me.cmbtipocomComp = New System.Windows.Forms.ComboBox()
        Me.cmbcondivaComp = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txttotalComp = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtivamontoComp = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtnetoComp = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtcuitComp = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtnogrComp = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtperibComp = New System.Windows.Forms.TextBox()
        Me.txtpercivComp = New System.Windows.Forms.TextBox()
        Me.txtpagoacuentaComp = New System.Windows.Forms.TextBox()
        Me.txtmontmonotComp = New System.Windows.Forms.TextBox()
        Me.pntitulo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.gbFactComb.SuspendLayout()
        Me.GbTiketPeaje.SuspendLayout()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(317, 40)
        Me.pntitulo.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(309, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "NUEVA COMPRA"
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.cmbCtaContable)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.txtcomprobanteFcompra)
        Me.Panel3.Controls.Add(Me.gbFactComb)
        Me.Panel3.Controls.Add(Me.GbTiketPeaje)
        Me.Panel3.Controls.Add(Me.Label78)
        Me.Panel3.Controls.Add(Me.txtnetocom27)
        Me.Panel3.Controls.Add(Me.Label77)
        Me.Panel3.Controls.Add(Me.txtnetocom105)
        Me.Panel3.Controls.Add(Me.chkcomprabiendeuso)
        Me.Panel3.Controls.Add(Me.txtfacder)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.cmdcalcPagoaCuenta)
        Me.Panel3.Controls.Add(Me.txtfaciz)
        Me.Panel3.Controls.Add(Me.dtpfechacomp)
        Me.Panel3.Controls.Add(Me.cmbrazonComp)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.txtobservacionesComp)
        Me.Panel3.Controls.Add(Me.cmdFinalizar)
        Me.Panel3.Controls.Add(Me.cmbtipocomComp)
        Me.Panel3.Controls.Add(Me.cmbcondivaComp)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.txttotalComp)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.txtivamontoComp)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.txtnetoComp)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.txtcuitComp)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtnogrComp)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtperibComp)
        Me.Panel3.Controls.Add(Me.txtpercivComp)
        Me.Panel3.Controls.Add(Me.txtpagoacuentaComp)
        Me.Panel3.Controls.Add(Me.txtmontmonotComp)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(317, 520)
        Me.Panel3.TabIndex = 21
        '
        'cmbCtaContable
        '
        Me.cmbCtaContable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCtaContable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCtaContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCtaContable.FormattingEnabled = True
        Me.cmbCtaContable.Location = New System.Drawing.Point(112, 333)
        Me.cmbCtaContable.Name = "cmbCtaContable"
        Me.cmbCtaContable.Size = New System.Drawing.Size(199, 21)
        Me.cmbCtaContable.TabIndex = 502
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(109, 317)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(122, 13)
        Me.Label23.TabIndex = 501
        Me.Label23.Text = "Cuenta contable destino"
        '
        'txtcomprobanteFcompra
        '
        Me.txtcomprobanteFcompra.Location = New System.Drawing.Point(6, 16)
        Me.txtcomprobanteFcompra.Name = "txtcomprobanteFcompra"
        Me.txtcomprobanteFcompra.Size = New System.Drawing.Size(80, 20)
        Me.txtcomprobanteFcompra.TabIndex = 100
        '
        'gbFactComb
        '
        Me.gbFactComb.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.gbFactComb.Controls.Add(Me.Label76)
        Me.gbFactComb.Controls.Add(Me.txtivafact)
        Me.gbFactComb.Controls.Add(Me.Label75)
        Me.gbFactComb.Controls.Add(Me.txttotalfac)
        Me.gbFactComb.Controls.Add(Me.Button4)
        Me.gbFactComb.Controls.Add(Me.cmdcalcFactComb)
        Me.gbFactComb.Controls.Add(Me.Label11)
        Me.gbFactComb.Controls.Add(Me.txtLitrosComb)
        Me.gbFactComb.Controls.Add(Me.Label10)
        Me.gbFactComb.Controls.Add(Me.txtCoefComb)
        Me.gbFactComb.Controls.Add(Me.Label9)
        Me.gbFactComb.Controls.Add(Me.txtfacCombNoGrav)
        Me.gbFactComb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFactComb.Location = New System.Drawing.Point(330, 230)
        Me.gbFactComb.Name = "gbFactComb"
        Me.gbFactComb.Size = New System.Drawing.Size(473, 103)
        Me.gbFactComb.TabIndex = 115
        Me.gbFactComb.TabStop = False
        Me.gbFactComb.Text = "FACTURA COMBUSTIBLE"
        Me.gbFactComb.Visible = False
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.Location = New System.Drawing.Point(91, 18)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(57, 13)
        Me.Label76.TabIndex = 67
        Me.Label76.Text = "% Iva Fact"
        '
        'txtivafact
        '
        Me.txtivafact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtivafact.Location = New System.Drawing.Point(94, 34)
        Me.txtivafact.Name = "txtivafact"
        Me.txtivafact.Size = New System.Drawing.Size(61, 20)
        Me.txtivafact.TabIndex = 68
        Me.txtivafact.Text = "0"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(6, 18)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(79, 13)
        Me.Label75.TabIndex = 65
        Me.Label75.Text = "Total facturado"
        '
        'txttotalfac
        '
        Me.txttotalfac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalfac.Location = New System.Drawing.Point(9, 34)
        Me.txttotalfac.Name = "txttotalfac"
        Me.txttotalfac.Size = New System.Drawing.Size(76, 20)
        Me.txttotalfac.TabIndex = 66
        Me.txttotalfac.Text = "0"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(167, 58)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(161, 23)
        Me.Button4.TabIndex = 64
        Me.Button4.Text = "Cancelar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cmdcalcFactComb
        '
        Me.cmdcalcFactComb.Location = New System.Drawing.Point(9, 58)
        Me.cmdcalcFactComb.Name = "cmdcalcFactComb"
        Me.cmdcalcFactComb.Size = New System.Drawing.Size(139, 23)
        Me.cmdcalcFactComb.TabIndex = 63
        Me.cmdcalcFactComb.Text = "Calcular"
        Me.cmdcalcFactComb.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(158, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Litros"
        '
        'txtLitrosComb
        '
        Me.txtLitrosComb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosComb.Location = New System.Drawing.Point(161, 34)
        Me.txtLitrosComb.Name = "txtLitrosComb"
        Me.txtLitrosComb.Size = New System.Drawing.Size(100, 20)
        Me.txtLitrosComb.TabIndex = 61
        Me.txtLitrosComb.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(268, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Valor imputable $"
        '
        'txtCoefComb
        '
        Me.txtCoefComb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoefComb.Location = New System.Drawing.Point(271, 34)
        Me.txtCoefComb.Name = "txtCoefComb"
        Me.txtCoefComb.Size = New System.Drawing.Size(85, 20)
        Me.txtCoefComb.TabIndex = 62
        Me.txtCoefComb.Text = "0,15"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(362, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Monto total no grav"
        '
        'txtfacCombNoGrav
        '
        Me.txtfacCombNoGrav.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfacCombNoGrav.Location = New System.Drawing.Point(365, 34)
        Me.txtfacCombNoGrav.Name = "txtfacCombNoGrav"
        Me.txtfacCombNoGrav.Size = New System.Drawing.Size(100, 20)
        Me.txtfacCombNoGrav.TabIndex = 60
        Me.txtfacCombNoGrav.Text = "0"
        '
        'GbTiketPeaje
        '
        Me.GbTiketPeaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GbTiketPeaje.Controls.Add(Me.Button2)
        Me.GbTiketPeaje.Controls.Add(Me.Label12)
        Me.GbTiketPeaje.Controls.Add(Me.txtcantTik)
        Me.GbTiketPeaje.Controls.Add(Me.cmdCalcTik)
        Me.GbTiketPeaje.Controls.Add(Me.cmdTikExc)
        Me.GbTiketPeaje.Controls.Add(Me.Label13)
        Me.GbTiketPeaje.Controls.Add(Me.txtIvaTik)
        Me.GbTiketPeaje.Controls.Add(Me.Label14)
        Me.GbTiketPeaje.Controls.Add(Me.txtmontoTik)
        Me.GbTiketPeaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbTiketPeaje.Location = New System.Drawing.Point(330, 122)
        Me.GbTiketPeaje.Name = "GbTiketPeaje"
        Me.GbTiketPeaje.Size = New System.Drawing.Size(330, 102)
        Me.GbTiketPeaje.TabIndex = 18
        Me.GbTiketPeaje.TabStop = False
        Me.GbTiketPeaje.Text = "TIKET PEAJE"
        Me.GbTiketPeaje.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(216, 57)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 23)
        Me.Button2.TabIndex = 55
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(115, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Cant Tiket"
        '
        'txtcantTik
        '
        Me.txtcantTik.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantTik.Location = New System.Drawing.Point(120, 31)
        Me.txtcantTik.Name = "txtcantTik"
        Me.txtcantTik.Size = New System.Drawing.Size(57, 20)
        Me.txtcantTik.TabIndex = 51
        Me.txtcantTik.Text = "0"
        '
        'cmdCalcTik
        '
        Me.cmdCalcTik.Location = New System.Drawing.Point(38, 57)
        Me.cmdCalcTik.Name = "cmdCalcTik"
        Me.cmdCalcTik.Size = New System.Drawing.Size(74, 23)
        Me.cmdCalcTik.TabIndex = 53
        Me.cmdCalcTik.Text = "Calcular"
        Me.cmdCalcTik.UseVisualStyleBackColor = True
        '
        'cmdTikExc
        '
        Me.cmdTikExc.Location = New System.Drawing.Point(118, 57)
        Me.cmdTikExc.Name = "cmdTikExc"
        Me.cmdTikExc.Size = New System.Drawing.Size(86, 23)
        Me.cmdTikExc.TabIndex = 54
        Me.cmdTikExc.Text = "Excento"
        Me.cmdTikExc.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(195, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "IVA"
        '
        'txtIvaTik
        '
        Me.txtIvaTik.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIvaTik.Location = New System.Drawing.Point(192, 31)
        Me.txtIvaTik.Name = "txtIvaTik"
        Me.txtIvaTik.Size = New System.Drawing.Size(100, 20)
        Me.txtIvaTik.TabIndex = 52
        Me.txtIvaTik.Text = "17,355"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(35, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Monto unit"
        '
        'txtmontoTik
        '
        Me.txtmontoTik.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmontoTik.Location = New System.Drawing.Point(38, 31)
        Me.txtmontoTik.Name = "txtmontoTik"
        Me.txtmontoTik.Size = New System.Drawing.Size(76, 20)
        Me.txtmontoTik.TabIndex = 50
        Me.txtmontoTik.Text = "0"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(166, 156)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(45, 13)
        Me.Label78.TabIndex = 226
        Me.Label78.Text = "Neto 27"
        '
        'txtnetocom27
        '
        Me.txtnetocom27.Location = New System.Drawing.Point(166, 172)
        Me.txtnetocom27.Name = "txtnetocom27"
        Me.txtnetocom27.Size = New System.Drawing.Size(72, 20)
        Me.txtnetocom27.TabIndex = 105
        Me.txtnetocom27.Tag = ""
        Me.txtnetocom27.Text = "0"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(87, 156)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(54, 13)
        Me.Label77.TabIndex = 224
        Me.Label77.Text = "Neto 10.5"
        '
        'txtnetocom105
        '
        Me.txtnetocom105.Location = New System.Drawing.Point(87, 172)
        Me.txtnetocom105.Name = "txtnetocom105"
        Me.txtnetocom105.Size = New System.Drawing.Size(72, 20)
        Me.txtnetocom105.TabIndex = 104
        Me.txtnetocom105.Tag = ""
        Me.txtnetocom105.Text = "0"
        '
        'chkcomprabiendeuso
        '
        Me.chkcomprabiendeuso.AutoSize = True
        Me.chkcomprabiendeuso.Location = New System.Drawing.Point(110, 16)
        Me.chkcomprabiendeuso.Name = "chkcomprabiendeuso"
        Me.chkcomprabiendeuso.Size = New System.Drawing.Size(82, 17)
        Me.chkcomprabiendeuso.TabIndex = 120
        Me.chkcomprabiendeuso.Text = "Bien de uso"
        Me.chkcomprabiendeuso.UseVisualStyleBackColor = True
        '
        'txtfacder
        '
        Me.txtfacder.Location = New System.Drawing.Point(178, 133)
        Me.txtfacder.MaxLength = 8
        Me.txtfacder.Name = "txtfacder"
        Me.txtfacder.Size = New System.Drawing.Size(58, 20)
        Me.txtfacder.TabIndex = 102
        Me.txtfacder.Tag = ""
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(141, 117)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 13)
        Me.Label22.TabIndex = 117
        Me.Label22.Text = "NumeroFact"
        '
        'cmdcalcPagoaCuenta
        '
        Me.cmdcalcPagoaCuenta.Location = New System.Drawing.Point(87, 213)
        Me.cmdcalcPagoaCuenta.Name = "cmdcalcPagoaCuenta"
        Me.cmdcalcPagoaCuenta.Size = New System.Drawing.Size(151, 22)
        Me.cmdcalcPagoaCuenta.TabIndex = 118
        Me.cmdcalcPagoaCuenta.Text = "Calculos"
        Me.cmdcalcPagoaCuenta.UseVisualStyleBackColor = True
        '
        'txtfaciz
        '
        Me.txtfaciz.Location = New System.Drawing.Point(141, 133)
        Me.txtfaciz.MaxLength = 4
        Me.txtfaciz.Name = "txtfaciz"
        Me.txtfaciz.Size = New System.Drawing.Size(31, 20)
        Me.txtfaciz.TabIndex = 101
        Me.txtfaciz.Tag = ""
        '
        'dtpfechacomp
        '
        Me.dtpfechacomp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechacomp.Location = New System.Drawing.Point(222, 16)
        Me.dtpfechacomp.Name = "dtpfechacomp"
        Me.dtpfechacomp.Size = New System.Drawing.Size(82, 20)
        Me.dtpfechacomp.TabIndex = 500
        Me.dtpfechacomp.Visible = False
        '
        'cmbrazonComp
        '
        Me.cmbrazonComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbrazonComp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbrazonComp.Enabled = False
        Me.cmbrazonComp.FormattingEnabled = True
        Me.cmbrazonComp.Location = New System.Drawing.Point(6, 55)
        Me.cmbrazonComp.Name = "cmbrazonComp"
        Me.cmbrazonComp.Size = New System.Drawing.Size(301, 21)
        Me.cmbrazonComp.TabIndex = 101
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 407)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "Observaciones"
        '
        'txtobservacionesComp
        '
        Me.txtobservacionesComp.Location = New System.Drawing.Point(6, 423)
        Me.txtobservacionesComp.Name = "txtobservacionesComp"
        Me.txtobservacionesComp.Size = New System.Drawing.Size(176, 20)
        Me.txtobservacionesComp.TabIndex = 112
        '
        'cmdFinalizar
        '
        Me.cmdFinalizar.Location = New System.Drawing.Point(3, 449)
        Me.cmdFinalizar.Name = "cmdFinalizar"
        Me.cmdFinalizar.Size = New System.Drawing.Size(89, 21)
        Me.cmdFinalizar.TabIndex = 113
        Me.cmdFinalizar.Text = "FINALIZAR"
        Me.cmdFinalizar.UseVisualStyleBackColor = True
        '
        'cmbtipocomComp
        '
        Me.cmbtipocomComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtipocomComp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtipocomComp.FormattingEnabled = True
        Me.cmbtipocomComp.Items.AddRange(New Object() {"FA", "FM", "FB", "FC", "NC", "ND", "FX"})
        Me.cmbtipocomComp.Location = New System.Drawing.Point(6, 132)
        Me.cmbtipocomComp.Name = "cmbtipocomComp"
        Me.cmbtipocomComp.Size = New System.Drawing.Size(129, 21)
        Me.cmbtipocomComp.TabIndex = 150
        '
        'cmbcondivaComp
        '
        Me.cmbcondivaComp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcondivaComp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcondivaComp.Enabled = False
        Me.cmbcondivaComp.FormattingEnabled = True
        Me.cmbcondivaComp.Location = New System.Drawing.Point(144, 96)
        Me.cmbcondivaComp.Name = "cmbcondivaComp"
        Me.cmbcondivaComp.Size = New System.Drawing.Size(163, 21)
        Me.cmbcondivaComp.TabIndex = 103
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(5, 357)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(112, 16)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "TOTAL Factura"
        '
        'txttotalComp
        '
        Me.txttotalComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalComp.ForeColor = System.Drawing.Color.Blue
        Me.txttotalComp.Location = New System.Drawing.Point(6, 376)
        Me.txttotalComp.Name = "txttotalComp"
        Me.txttotalComp.ReadOnly = True
        Me.txttotalComp.Size = New System.Drawing.Size(176, 22)
        Me.txttotalComp.TabIndex = 27
        Me.txttotalComp.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 199)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 13)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "Cred. fiscal"
        '
        'txtivamontoComp
        '
        Me.txtivamontoComp.Location = New System.Drawing.Point(6, 215)
        Me.txtivamontoComp.Name = "txtivamontoComp"
        Me.txtivamontoComp.Size = New System.Drawing.Size(56, 20)
        Me.txtivamontoComp.TabIndex = 106
        Me.txtivamontoComp.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 156)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 13)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "Neto 21"
        '
        'txtnetoComp
        '
        Me.txtnetoComp.Location = New System.Drawing.Point(6, 172)
        Me.txtnetoComp.Name = "txtnetoComp"
        Me.txtnetoComp.Size = New System.Drawing.Size(72, 20)
        Me.txtnetoComp.TabIndex = 103
        Me.txtnetoComp.Tag = ""
        Me.txtnetoComp.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(141, 80)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Cond IVA"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 80)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 13)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "CUIT"
        '
        'txtcuitComp
        '
        Me.txtcuitComp.Enabled = False
        Me.txtcuitComp.Location = New System.Drawing.Point(6, 96)
        Me.txtcuitComp.Name = "txtcuitComp"
        Me.txtcuitComp.Size = New System.Drawing.Size(132, 20)
        Me.txtcuitComp.TabIndex = 102
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Fecha"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 317)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "No  GR/EXC"
        '
        'txtnogrComp
        '
        Me.txtnogrComp.Location = New System.Drawing.Point(6, 333)
        Me.txtnogrComp.Name = "txtnogrComp"
        Me.txtnogrComp.Size = New System.Drawing.Size(100, 20)
        Me.txtnogrComp.TabIndex = 111
        Me.txtnogrComp.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 278)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Perc IB"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 278)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Perc IVA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(125, 277)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Perc. Ganancias"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "MONOT monto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Razon Social"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tipo Comp"
        '
        'txtperibComp
        '
        Me.txtperibComp.Location = New System.Drawing.Point(66, 294)
        Me.txtperibComp.Name = "txtperibComp"
        Me.txtperibComp.Size = New System.Drawing.Size(57, 20)
        Me.txtperibComp.TabIndex = 110
        Me.txtperibComp.Text = "0"
        '
        'txtpercivComp
        '
        Me.txtpercivComp.Location = New System.Drawing.Point(6, 294)
        Me.txtpercivComp.Name = "txtpercivComp"
        Me.txtpercivComp.Size = New System.Drawing.Size(51, 20)
        Me.txtpercivComp.TabIndex = 109
        Me.txtpercivComp.Text = "0"
        '
        'txtpagoacuentaComp
        '
        Me.txtpagoacuentaComp.Location = New System.Drawing.Point(128, 294)
        Me.txtpagoacuentaComp.Name = "txtpagoacuentaComp"
        Me.txtpagoacuentaComp.Size = New System.Drawing.Size(66, 20)
        Me.txtpagoacuentaComp.TabIndex = 108
        Me.txtpagoacuentaComp.Text = "0"
        '
        'txtmontmonotComp
        '
        Me.txtmontmonotComp.Location = New System.Drawing.Point(6, 255)
        Me.txtmontmonotComp.Name = "txtmontmonotComp"
        Me.txtmontmonotComp.Size = New System.Drawing.Size(76, 20)
        Me.txtmontmonotComp.TabIndex = 107
        Me.txtmontmonotComp.Text = "0"
        '
        'NvaFacturaCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 560)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pntitulo)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "NvaFacturaCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NvaFacturaCompra"
        Me.TopMost = True
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.gbFactComb.ResumeLayout(False)
        Me.gbFactComb.PerformLayout()
        Me.GbTiketPeaje.ResumeLayout(False)
        Me.GbTiketPeaje.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents gbFactComb As GroupBox
    Friend WithEvents Label76 As Label
    Friend WithEvents txtivafact As TextBox
    Friend WithEvents Label75 As Label
    Friend WithEvents txttotalfac As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents cmdcalcFactComb As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtLitrosComb As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCoefComb As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtfacCombNoGrav As TextBox
    Friend WithEvents GbTiketPeaje As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtcantTik As TextBox
    Friend WithEvents cmdCalcTik As Button
    Friend WithEvents cmdTikExc As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents txtIvaTik As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtmontoTik As TextBox
    Friend WithEvents Label78 As Label
    Friend WithEvents txtnetocom27 As TextBox
    Friend WithEvents Label77 As Label
    Friend WithEvents txtnetocom105 As TextBox
    Friend WithEvents chkcomprabiendeuso As CheckBox
    Friend WithEvents txtfacder As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cmdcalcPagoaCuenta As Button
    Friend WithEvents txtfaciz As TextBox
    Friend WithEvents dtpfechacomp As DateTimePicker
    Friend WithEvents cmbrazonComp As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtobservacionesComp As TextBox
    Friend WithEvents cmdFinalizar As Button
    Friend WithEvents cmbtipocomComp As ComboBox
    Friend WithEvents cmbcondivaComp As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txttotalComp As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtivamontoComp As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtnetoComp As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtcuitComp As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtnogrComp As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtperibComp As TextBox
    Friend WithEvents txtpercivComp As TextBox
    Friend WithEvents txtpagoacuentaComp As TextBox
    Friend WithEvents txtmontmonotComp As TextBox
    Friend WithEvents txtcomprobanteFcompra As TextBox
    Friend WithEvents cmbCtaContable As ComboBox
    Friend WithEvents Label23 As Label
End Class
