<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class imprimiregreso
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
        Me.datosEmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.datosgenerales = New SIGT__KIGEST.datosgenerales()
        Me.datosFichaIngresoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.datostaller = New SIGT__KIGEST.datostaller()
        Me.fichaIngresoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rptegreso = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.datosEmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datosgenerales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datosFichaIngresoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datostaller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fichaIngresoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'datosEmpresaBindingSource
        '
        Me.datosEmpresaBindingSource.DataMember = "datosEmpresa"
        Me.datosEmpresaBindingSource.DataSource = Me.datosgenerales
        '
        'datosgenerales
        '
        Me.datosgenerales.DataSetName = "datosgenerales"
        Me.datosgenerales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'datosFichaIngresoBindingSource
        '
        Me.datosFichaIngresoBindingSource.DataMember = "datosFichaIngreso"
        Me.datosFichaIngresoBindingSource.DataSource = Me.datostaller
        '
        'datostaller
        '
        Me.datostaller.DataSetName = "datostaller"
        Me.datostaller.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'fichaIngresoBindingSource
        '
        Me.fichaIngresoBindingSource.DataMember = "fichaIngreso"
        Me.fichaIngresoBindingSource.DataSource = Me.datostaller
        '
        'rptegreso
        '
        Me.rptegreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptegreso.Location = New System.Drawing.Point(0, 0)
        Me.rptegreso.Name = "rptegreso"
        Me.rptegreso.ServerReport.BearerToken = Nothing
        Me.rptegreso.Size = New System.Drawing.Size(689, 401)
        Me.rptegreso.TabIndex = 0
        '
        'imprimiregreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 401)
        Me.Controls.Add(Me.rptegreso)
        Me.Name = "imprimiregreso"
        Me.Text = "imprimiregreso"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.datosEmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datosgenerales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datosFichaIngresoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datostaller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fichaIngresoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents datosEmpresaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents datosgenerales As SIGT__KIGEST.datosgenerales
    Friend WithEvents datosFichaIngresoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents datostaller As SIGT__KIGEST.datostaller
    Friend WithEvents fichaIngresoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rptegreso As Microsoft.Reporting.WinForms.ReportViewer
End Class
