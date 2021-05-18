Public Class selListaCarga
    Dim tipofact As Integer = 997
    Dim idfactura As Integer
    Private Sub selListaCarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id, fecha,concat(lpad(ptovta,4,'0'),'-',lpad(num_fact,8,'0')) as comprobante 
        from fact_facturas where tipofact=997
        order by fecha desc LIMIT " & My.Settings.paginacion, conexionPrinc)
        Dim tablaped As New DataTable
        consulta.Fill(tablaped)

        dtlistasdecarga.DataSource = tablaped
        dtlistasdecarga.Columns(0).Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            idfactura = dtlistasdecarga.CurrentRow.Cells(0).Value
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas

            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo," _
            & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum,fac.fecha as facfech,concat(fac.id_cliente,'-',fac.razon) as facrazon," _
            & "concat(fac.direccion, ' - ', fac.localidad)  as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit,fac.vendedor as facvend, " _
            & "fac.condvta as faccondvta, fac.observaciones as facobserva,fac.iva105, fac.iva21 " _
            & "FROM fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac where emp.id=1 and fis.donfdesc=fac.tipofact and fac.id=" & idfactura, conexionPrinc)

            tabEmp.Fill(fac.Tables("factura_enca"))
            Reconectar()
            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM ariel_itmlistacarga where idcomprobante=" & idfactura & " order by producto asc", conexionPrinc)
            tabFac.Fill(fac.Tables("ariel_itmlistacarga"))




            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listacarga.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("ariel_itmlistacarga")))

                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtlistasdecarga_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtlistasdecarga.CellContentClick

    End Sub
End Class