﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionTerminal
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
        Me.txtcajaDef = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txttipoetiqueta = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.txtunidadDef = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.chkimprimirtikets = New System.Windows.Forms.CheckBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.txtidalmacen = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtptovtadef = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.txtidfacrapdef = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTextoPietiket = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdIdInterno = New System.Windows.Forms.RadioButton()
        Me.rdcod_bar = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdcalculo1 = New System.Windows.Forms.RadioButton()
        Me.rdcalculo2 = New System.Windows.Forms.RadioButton()
        Me.txtidmoneda = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtidDevolucion = New System.Windows.Forms.TextBox()
        Me.cmbtipoTiketEtiqueta = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbMetodoBusquedaProd = New System.Windows.Forms.ComboBox()
        Me.txttipotaller = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbVisualizacionProd = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.cmbimpresoraTiket = New System.Windows.Forms.ComboBox()
        Me.cmbImpresoraEtiquetas = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPtoVtaElect = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pntitulo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.AutoScroll = True
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(497, 40)
        Me.pntitulo.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(437, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Configuracion de terminal"
        '
        'txtcajaDef
        '
        Me.txtcajaDef.Location = New System.Drawing.Point(132, 226)
        Me.txtcajaDef.Name = "txtcajaDef"
        Me.txtcajaDef.Size = New System.Drawing.Size(64, 20)
        Me.txtcajaDef.TabIndex = 133
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(4, 230)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(124, 16)
        Me.Label64.TabIndex = 131
        Me.Label64.Text = "Caja por Defecto"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(4, 204)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(155, 16)
        Me.Label63.TabIndex = 130
        Me.Label63.Text = "Nombre Etiquetadora"
        '
        'txttipoetiqueta
        '
        Me.txttipoetiqueta.Location = New System.Drawing.Point(431, 236)
        Me.txttipoetiqueta.Name = "txttipoetiqueta"
        Me.txttipoetiqueta.Size = New System.Drawing.Size(54, 20)
        Me.txttipoetiqueta.TabIndex = 129
        Me.txttipoetiqueta.Text = "0"
        Me.txttipoetiqueta.Visible = False
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(332, 237)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(96, 16)
        Me.Label60.TabIndex = 128
        Me.Label60.Text = "TipoEtiqueta"
        Me.Label60.Visible = False
        '
        'txtunidadDef
        '
        Me.txtunidadDef.Location = New System.Drawing.Point(128, 174)
        Me.txtunidadDef.Name = "txtunidadDef"
        Me.txtunidadDef.Size = New System.Drawing.Size(100, 20)
        Me.txtunidadDef.TabIndex = 127
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(8, 175)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(110, 16)
        Me.Label59.TabIndex = 126
        Me.Label59.Text = "Unidad por def"
        '
        'chkimprimirtikets
        '
        Me.chkimprimirtikets.AutoSize = True
        Me.chkimprimirtikets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkimprimirtikets.Location = New System.Drawing.Point(7, 121)
        Me.chkimprimirtikets.Name = "chkimprimirtikets"
        Me.chkimprimirtikets.Size = New System.Drawing.Size(15, 14)
        Me.chkimprimirtikets.TabIndex = 125
        Me.chkimprimirtikets.UseVisualStyleBackColor = True
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(28, 121)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(175, 16)
        Me.Label57.TabIndex = 123
        Me.Label57.Text = "ImpresoraTiketsNombre"
        '
        'txtidalmacen
        '
        Me.txtidalmacen.Location = New System.Drawing.Point(92, 92)
        Me.txtidalmacen.Name = "txtidalmacen"
        Me.txtidalmacen.Size = New System.Drawing.Size(100, 20)
        Me.txtidalmacen.TabIndex = 122
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(5, 96)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(80, 16)
        Me.Label50.TabIndex = 121
        Me.Label50.Text = "IdAlmacen"
        '
        'txtptovtadef
        '
        Me.txtptovtadef.Location = New System.Drawing.Point(92, 68)
        Me.txtptovtadef.Name = "txtptovtadef"
        Me.txtptovtadef.Size = New System.Drawing.Size(100, 20)
        Me.txtptovtadef.TabIndex = 120
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(5, 72)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(77, 16)
        Me.Label49.TabIndex = 119
        Me.Label49.Text = "PtoVtaDef"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 16)
        Me.Label9.TabIndex = 118
        Me.Label9.Text = "idFACRAP"
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(7, 420)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(136, 23)
        Me.Button18.TabIndex = 117
        Me.Button18.Text = "Guardar config"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'txtidfacrapdef
        '
        Me.txtidfacrapdef.Location = New System.Drawing.Point(92, 42)
        Me.txtidfacrapdef.Name = "txtidfacrapdef"
        Me.txtidfacrapdef.Size = New System.Drawing.Size(100, 20)
        Me.txtidfacrapdef.TabIndex = 116
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 16)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Texto pie tiket"
        '
        'txtTextoPietiket
        '
        Me.txtTextoPietiket.Location = New System.Drawing.Point(121, 145)
        Me.txtTextoPietiket.Name = "txtTextoPietiket"
        Me.txtTextoPietiket.Size = New System.Drawing.Size(244, 20)
        Me.txtTextoPietiket.TabIndex = 135
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 257)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 16)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "ObtenerCodigoAutom"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdIdInterno)
        Me.GroupBox1.Controls.Add(Me.rdcod_bar)
        Me.GroupBox1.Location = New System.Drawing.Point(170, 249)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(141, 34)
        Me.GroupBox1.TabIndex = 137
        Me.GroupBox1.TabStop = False
        '
        'rdIdInterno
        '
        Me.rdIdInterno.AutoSize = True
        Me.rdIdInterno.Location = New System.Drawing.Point(71, 8)
        Me.rdIdInterno.Name = "rdIdInterno"
        Me.rdIdInterno.Size = New System.Drawing.Size(71, 17)
        Me.rdIdInterno.TabIndex = 1
        Me.rdIdInterno.Tag = "id"
        Me.rdIdInterno.Text = "id_interno"
        Me.rdIdInterno.UseVisualStyleBackColor = True
        '
        'rdcod_bar
        '
        Me.rdcod_bar.AutoSize = True
        Me.rdcod_bar.Checked = True
        Me.rdcod_bar.Location = New System.Drawing.Point(1, 8)
        Me.rdcod_bar.Name = "rdcod_bar"
        Me.rdcod_bar.Size = New System.Drawing.Size(64, 17)
        Me.rdcod_bar.TabIndex = 0
        Me.rdcod_bar.TabStop = True
        Me.rdcod_bar.Tag = "cod_bar"
        Me.rdcod_bar.Text = "cod_bar"
        Me.rdcod_bar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 291)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(221, 16)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "Formula de calculo de precios:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdcalculo1)
        Me.GroupBox2.Controls.Add(Me.rdcalculo2)
        Me.GroupBox2.Location = New System.Drawing.Point(228, 282)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(165, 54)
        Me.GroupBox2.TabIndex = 139
        Me.GroupBox2.TabStop = False
        '
        'rdcalculo1
        '
        Me.rdcalculo1.AutoSize = True
        Me.rdcalculo1.Checked = True
        Me.rdcalculo1.Location = New System.Drawing.Point(4, 9)
        Me.rdcalculo1.Name = "rdcalculo1"
        Me.rdcalculo1.Size = New System.Drawing.Size(146, 17)
        Me.rdcalculo1.TabIndex = 1
        Me.rdcalculo1.TabStop = True
        Me.rdcalculo1.Tag = "id"
        Me.rdcalculo1.Text = "costo * iva * lista * utilidad"
        Me.rdcalculo1.UseVisualStyleBackColor = True
        '
        'rdcalculo2
        '
        Me.rdcalculo2.AutoSize = True
        Me.rdcalculo2.Location = New System.Drawing.Point(4, 31)
        Me.rdcalculo2.Name = "rdcalculo2"
        Me.rdcalculo2.Size = New System.Drawing.Size(154, 17)
        Me.rdcalculo2.TabIndex = 0
        Me.rdcalculo2.Tag = "cod_bar"
        Me.rdcalculo2.Text = "costo * iva * (lista + utilidad)"
        Me.rdcalculo2.UseVisualStyleBackColor = True
        '
        'txtidmoneda
        '
        Me.txtidmoneda.Location = New System.Drawing.Point(114, 342)
        Me.txtidmoneda.Name = "txtidmoneda"
        Me.txtidmoneda.Size = New System.Drawing.Size(54, 20)
        Me.txtidmoneda.TabIndex = 141
        Me.txtidmoneda.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 343)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 16)
        Me.Label5.TabIndex = 140
        Me.Label5.Text = "IdMonedaDef"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(207, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 16)
        Me.Label6.TabIndex = 143
        Me.Label6.Text = "idDevolucion"
        '
        'txtidDevolucion
        '
        Me.txtidDevolucion.Location = New System.Drawing.Point(312, 42)
        Me.txtidDevolucion.Name = "txtidDevolucion"
        Me.txtidDevolucion.Size = New System.Drawing.Size(100, 20)
        Me.txtidDevolucion.TabIndex = 142
        '
        'cmbtipoTiketEtiqueta
        '
        Me.cmbtipoTiketEtiqueta.FormattingEnabled = True
        Me.cmbtipoTiketEtiqueta.Items.AddRange(New Object() {"0 - TIKET 58MM EMP1", "1 - TIKET 58MM EMP2", "2 - TIKET 58MM EMP3", "3 - TIKET 80MM - COMBUSTIBLES", "4 - TIKET 80MM - GENERAL"})
        Me.cmbtipoTiketEtiqueta.Location = New System.Drawing.Point(351, 119)
        Me.cmbtipoTiketEtiqueta.Name = "cmbtipoTiketEtiqueta"
        Me.cmbtipoTiketEtiqueta.Size = New System.Drawing.Size(139, 21)
        Me.cmbtipoTiketEtiqueta.TabIndex = 144
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(174, 343)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 16)
        Me.Label7.TabIndex = 145
        Me.Label7.Text = "Modo busquedaProd"
        '
        'cmbMetodoBusquedaProd
        '
        Me.cmbMetodoBusquedaProd.FormattingEnabled = True
        Me.cmbMetodoBusquedaProd.Items.AddRange(New Object() {"0 - Restrictiva (descripcion%)", "1 - Inclusiva (%descripcion%)"})
        Me.cmbMetodoBusquedaProd.Location = New System.Drawing.Point(325, 341)
        Me.cmbMetodoBusquedaProd.Name = "cmbMetodoBusquedaProd"
        Me.cmbMetodoBusquedaProd.Size = New System.Drawing.Size(160, 21)
        Me.cmbMetodoBusquedaProd.TabIndex = 146
        '
        'txttipotaller
        '
        Me.txttipotaller.Location = New System.Drawing.Point(79, 374)
        Me.txttipotaller.Name = "txttipotaller"
        Me.txttipotaller.Size = New System.Drawing.Size(64, 20)
        Me.txttipotaller.TabIndex = 148
        Me.txttipotaller.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 374)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 16)
        Me.Label8.TabIndex = 147
        Me.Label8.Text = "tipoTaller"
        '
        'cmbVisualizacionProd
        '
        Me.cmbVisualizacionProd.FormattingEnabled = True
        Me.cmbVisualizacionProd.Items.AddRange(New Object() {"0 - Descripcion + Detalle", "1 - Descripcion solamente"})
        Me.cmbVisualizacionProd.Location = New System.Drawing.Point(351, 376)
        Me.cmbVisualizacionProd.Name = "cmbVisualizacionProd"
        Me.cmbVisualizacionProd.Size = New System.Drawing.Size(134, 21)
        Me.cmbVisualizacionProd.TabIndex = 150
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(174, 378)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(171, 16)
        Me.Label10.TabIndex = 149
        Me.Label10.Text = "ModoVisualizacionProd"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'cmbimpresoraTiket
        '
        Me.cmbimpresoraTiket.FormattingEnabled = True
        Me.cmbimpresoraTiket.Location = New System.Drawing.Point(205, 119)
        Me.cmbimpresoraTiket.Name = "cmbimpresoraTiket"
        Me.cmbimpresoraTiket.Size = New System.Drawing.Size(140, 21)
        Me.cmbimpresoraTiket.TabIndex = 151
        '
        'cmbImpresoraEtiquetas
        '
        Me.cmbImpresoraEtiquetas.FormattingEnabled = True
        Me.cmbImpresoraEtiquetas.Location = New System.Drawing.Point(161, 203)
        Me.cmbImpresoraEtiquetas.Name = "cmbImpresoraEtiquetas"
        Me.cmbImpresoraEtiquetas.Size = New System.Drawing.Size(160, 21)
        Me.cmbImpresoraEtiquetas.TabIndex = 152
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(207, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 16)
        Me.Label11.TabIndex = 154
        Me.Label11.Text = "puntoVtaElect"
        '
        'txtPtoVtaElect
        '
        Me.txtPtoVtaElect.Location = New System.Drawing.Point(312, 68)
        Me.txtPtoVtaElect.Name = "txtPtoVtaElect"
        Me.txtPtoVtaElect.Size = New System.Drawing.Size(100, 20)
        Me.txtPtoVtaElect.TabIndex = 153
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(149, 420)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 23)
        Me.Button1.TabIndex = 155
        Me.Button1.Text = "cambiar Terminal"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ConfiguracionTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(497, 455)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtPtoVtaElect)
        Me.Controls.Add(Me.cmbImpresoraEtiquetas)
        Me.Controls.Add(Me.cmbimpresoraTiket)
        Me.Controls.Add(Me.cmbVisualizacionProd)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txttipotaller)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbMetodoBusquedaProd)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbtipoTiketEtiqueta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtidDevolucion)
        Me.Controls.Add(Me.txtidmoneda)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTextoPietiket)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcajaDef)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.txttipoetiqueta)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.txtunidadDef)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.chkimprimirtikets)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.txtidalmacen)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.txtptovtadef)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button18)
        Me.Controls.Add(Me.txtidfacrapdef)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "ConfiguracionTerminal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ConfiguracionTerminal"
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pntitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtcajaDef As TextBox
    Friend WithEvents Label64 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents txttipoetiqueta As TextBox
    Friend WithEvents Label60 As Label
    Friend WithEvents txtunidadDef As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents chkimprimirtikets As CheckBox
    Friend WithEvents Label57 As Label
    Friend WithEvents txtidalmacen As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents txtptovtadef As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Button18 As Button
    Friend WithEvents txtidfacrapdef As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTextoPietiket As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdIdInterno As RadioButton
    Friend WithEvents rdcod_bar As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rdcalculo1 As RadioButton
    Friend WithEvents rdcalculo2 As RadioButton
    Friend WithEvents txtidmoneda As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtidDevolucion As TextBox
    Friend WithEvents cmbtipoTiketEtiqueta As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbMetodoBusquedaProd As ComboBox
    Friend WithEvents txttipotaller As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbVisualizacionProd As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents cmbimpresoraTiket As ComboBox
    Friend WithEvents cmbImpresoraEtiquetas As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPtoVtaElect As TextBox
    Friend WithEvents Button1 As Button
End Class
