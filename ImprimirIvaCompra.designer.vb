<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirIvaCompra
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.IvaCompraItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DatasetRecibos = New SIGT__KIGEST.DatasetRecibos()
        Me.rptivacompra = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.IvaCompraItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IvaCompraItemsBindingSource
        '
        Me.IvaCompraItemsBindingSource.DataMember = "IvaCompraItems"
        Me.IvaCompraItemsBindingSource.DataSource = Me.DatasetRecibos
        '
        'DatasetRecibos
        '
        Me.DatasetRecibos.DataSetName = "DatasetRecibos"
        Me.DatasetRecibos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rptivacompra
        '
        Me.rptivacompra.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.IvaCompraItemsBindingSource
        Me.rptivacompra.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptivacompra.LocalReport.ReportEmbeddedResource = "KIGEST___Gestion_Contable.LibroIvaDetalles.rdlc"
        Me.rptivacompra.Location = New System.Drawing.Point(0, 0)
        Me.rptivacompra.Margin = New System.Windows.Forms.Padding(1)
        Me.rptivacompra.Name = "rptivacompra"
        Me.rptivacompra.Size = New System.Drawing.Size(675, 454)
        Me.rptivacompra.TabIndex = 0
        '
        'ImprimirIvaCompra
        '
        Me.ClientSize = New System.Drawing.Size(675, 454)
        Me.Controls.Add(Me.rptivacompra)
        Me.Name = "ImprimirIvaCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.IvaCompraItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbperiodo As System.Windows.Forms.ComboBox
    Friend WithEvents cmdverlibros As System.Windows.Forms.Button
    Friend WithEvents rptlibro As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents rptivacompra As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents IvaCompraItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DatasetRecibos As SIGT__KIGEST.DatasetRecibos
End Class
