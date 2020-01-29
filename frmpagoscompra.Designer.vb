<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmpagoscompra
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.panelformaspago = New System.Windows.Forms.Panel()
        Me.btntarjeta = New System.Windows.Forms.Button()
        Me.btnefectivo = New System.Windows.Forms.Button()
        Me.panelefectivo = New System.Windows.Forms.Panel()
        Me.cmdfinalizar = New System.Windows.Forms.Button()
        Me.txtvuelto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtefectivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltotalefectivo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panelformaspago.SuspendLayout()
        Me.panelefectivo.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelformaspago
        '
        Me.panelformaspago.Controls.Add(Me.btntarjeta)
        Me.panelformaspago.Controls.Add(Me.btnefectivo)
        Me.panelformaspago.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelformaspago.Location = New System.Drawing.Point(0, 0)
        Me.panelformaspago.Name = "panelformaspago"
        Me.panelformaspago.Size = New System.Drawing.Size(304, 231)
        Me.panelformaspago.TabIndex = 2
        '
        'btntarjeta
        '
        Me.btntarjeta.Dock = System.Windows.Forms.DockStyle.Top
        Me.btntarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntarjeta.Location = New System.Drawing.Point(0, 114)
        Me.btntarjeta.Name = "btntarjeta"
        Me.btntarjeta.Size = New System.Drawing.Size(304, 116)
        Me.btntarjeta.TabIndex = 3
        Me.btntarjeta.Text = "OTROS"
        Me.btntarjeta.UseVisualStyleBackColor = True
        '
        'btnefectivo
        '
        Me.btnefectivo.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnefectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnefectivo.Location = New System.Drawing.Point(0, 0)
        Me.btnefectivo.Name = "btnefectivo"
        Me.btnefectivo.Size = New System.Drawing.Size(304, 114)
        Me.btnefectivo.TabIndex = 2
        Me.btnefectivo.Text = "EFECTIVO"
        Me.btnefectivo.UseVisualStyleBackColor = True
        '
        'panelefectivo
        '
        Me.panelefectivo.Controls.Add(Me.cmdfinalizar)
        Me.panelefectivo.Controls.Add(Me.txtvuelto)
        Me.panelefectivo.Controls.Add(Me.Label2)
        Me.panelefectivo.Controls.Add(Me.txtefectivo)
        Me.panelefectivo.Controls.Add(Me.Label1)
        Me.panelefectivo.Controls.Add(Me.lbltotalefectivo)
        Me.panelefectivo.Controls.Add(Me.Label3)
        Me.panelefectivo.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelefectivo.Location = New System.Drawing.Point(0, 231)
        Me.panelefectivo.Name = "panelefectivo"
        Me.panelefectivo.Size = New System.Drawing.Size(304, 223)
        Me.panelefectivo.TabIndex = 3
        '
        'cmdfinalizar
        '
        Me.cmdfinalizar.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdfinalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdfinalizar.Location = New System.Drawing.Point(0, 178)
        Me.cmdfinalizar.Name = "cmdfinalizar"
        Me.cmdfinalizar.Size = New System.Drawing.Size(304, 35)
        Me.cmdfinalizar.TabIndex = 18
        Me.cmdfinalizar.Text = "FINALIZAR"
        Me.cmdfinalizar.UseVisualStyleBackColor = True
        '
        'txtvuelto
        '
        Me.txtvuelto.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtvuelto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtvuelto.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtvuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvuelto.Location = New System.Drawing.Point(0, 132)
        Me.txtvuelto.Name = "txtvuelto"
        Me.txtvuelto.ReadOnly = True
        Me.txtvuelto.Size = New System.Drawing.Size(304, 46)
        Me.txtvuelto.TabIndex = 17
        Me.txtvuelto.Text = "0"
        Me.txtvuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(304, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "VUELTO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtefectivo
        '
        Me.txtefectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtefectivo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtefectivo.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtefectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtefectivo.Location = New System.Drawing.Point(0, 81)
        Me.txtefectivo.Name = "txtefectivo"
        Me.txtefectivo.Size = New System.Drawing.Size(304, 31)
        Me.txtefectivo.TabIndex = 15
        Me.txtefectivo.Text = "0"
        Me.txtefectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(304, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "EFECTIVO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbltotalefectivo
        '
        Me.lbltotalefectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbltotalefectivo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbltotalefectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalefectivo.Location = New System.Drawing.Point(0, 19)
        Me.lbltotalefectivo.Name = "lbltotalefectivo"
        Me.lbltotalefectivo.Size = New System.Drawing.Size(304, 43)
        Me.lbltotalefectivo.TabIndex = 13
        Me.lbltotalefectivo.Text = "TOTAL"
        Me.lbltotalefectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(304, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "TOTAL COMPRA $"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmpagoscompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 231)
        Me.Controls.Add(Me.panelefectivo)
        Me.Controls.Add(Me.panelformaspago)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmpagoscompra"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmpagoscompra"
        Me.panelformaspago.ResumeLayout(False)
        Me.panelefectivo.ResumeLayout(False)
        Me.panelefectivo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelformaspago As Panel
    Friend WithEvents btntarjeta As Button
    Friend WithEvents btnefectivo As Button
    Friend WithEvents panelefectivo As Panel
    Friend WithEvents cmdfinalizar As Button
    Friend WithEvents txtvuelto As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtefectivo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbltotalefectivo As Label
    Friend WithEvents Label3 As Label
End Class
