Public Class buscarequipos
    Dim cargaecli As Boolean
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Try
            cargaecli = False
            dtresultado.DataSource = Nothing
            Reconectar()
            Dim consulta As String
            If rdcliente.Checked = True Then
                consulta = " cli.nomapell_razon like '%" & txtequiposclieBusqueda.Text & "%'"
            End If
            If rdgarantias.Checked = True Then
                consulta = " tall.infoextra like '%" & txtequiposclieBusqueda.Text & "%'"
            End If
            If rdserie.Checked = True Then
                consulta = " tall.serie like '%" & txtequiposclieBusqueda.Text & "%'"
            End If
            If rdcodint.Checked = True Then
                consulta = " tall.equipo =" & txtequiposclieBusqueda.Text
            End If
            If rdorden.Checked = True Then
                consulta = " tall.id =" & txtequiposclieBusqueda.Text
            End If

            If chkterminadostrab.Checked = True Then
                consulta &= " and tall.estado=8 "
            End If
            If chksinfacturartrab.Checked = True Then
                consulta &= " and tall.trab_estado=3 "
            End If
            'MsgBox(consulta)

            Dim tabla As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
            & "tall.id as ORDEN,(select concat(et.nombre,'/',ma.nombre,'/',mo.nombre) from tecni_equipos as eq, tecni_equipos_tipo as et, fact_marcas as ma, fact_modelos as mo  " _
            & "where eq.marca=ma.id and eq.modelo=mo.id and eq.tipo_equ=et.id and eq.id=tall.modelo) as EQUIPO, tall.serie,  " _
            & "cli.nomapell_razon as Cliente, tall.infoextra as extra,  tall.equipo as codint, " _
            & "te.nombre as estado,  case tall.trab_estado " _
            & "when 0 then (select 'Sin terminar') " _
            & "when 1 then (select concat (fis.abrev, ' ', fa.ptovta,'-', fa.num_fact) from fact_facturas as fa, fact_conffiscal as fis where fis.donfdesc=fa.tipofact and tall.factura=fa.id) " _
            & "when 2 then (select 'CtaCte') " _
            & "when 3 then (select 'Sin facturar') " _
            & "when 4 then (select 'En deposito') " _
            & "when 5 then (select 'de baja') end as factur " _
            & "from tecni_taller as tall,  fact_clientes as cli, tecni_taller_estado as te where " _
            & "fecha_ing between '" & Format(dtpdesdetrab.Value, "yyyy-MM-dd") & "' and '" & Format(dtphastatrab.Value, "yyyy-MM-dd") & "' and " _
            & "cli.idclientes=tall.cliente and tall.estado=te.id and " _
            & consulta, conexionPrinc)

            'MsgBox(tabla.SelectCommand)
            'MsgBox(tabla.SelectCommand.CommandText)
            Dim leertab As New DataTable
            'Dim itemtab() As DataRow
            tabla.Fill(leertab)
            dtresultado.DataSource = leertab
            'itemtab = leertab.Select()
            lblresultados.Text = leertab.Rows.Count & " resultados"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub buscarequipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdbuscar
        dtpdesdetrab.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
        ' Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
    End Sub

    Private Sub dtresultado_DoubleClick(sender As Object, e As EventArgs) Handles dtresultado.DoubleClick
        Dim i As Integer
        For i = 0 To frmprincipal.MdiChildren.Length - 1
            If frmprincipal.MdiChildren(i).Name = "fichaequipo" Then
                frmprincipal.MdiChildren(i).BringToFront()
                CType(frmprincipal.ActiveMdiChild, fichaequipo).lblalerta.Visible = True
                Exit Sub
            End If
        Next
        Dim fichequ As New fichaequipo
        fichequ.MdiParent = Me.MdiParent
        fichequ.ORden = dtresultado.CurrentRow.Cells(0).Value
        fichequ.Show()
    End Sub

    Private Sub rdgarantias_CheckedChanged(sender As Object, e As EventArgs) Handles rdgarantias.CheckedChanged

    End Sub

    Private Sub cmdingresataller_Click(sender As Object, e As EventArgs) Handles cmdingresataller.Click
        Dim i As Integer
        For i = 0 To frmprincipal.MdiChildren.Length - 1
            If frmprincipal.MdiChildren(i).Name = "ingresoequipo" Then
                frmprincipal.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim ingequ As New ingresoequipo
        ingequ.MdiParent = Me.MdiParent
        ingequ.Show()
    End Sub

    Private Sub cmdimprimirfing_Click(sender As Object, e As EventArgs) Handles cmdimprimirfing.Click
        Try
            Dim NUMor As Integer = dtresultado.CurrentRow.Cells(0).Value
            Dim tablaDTGFicha As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dsDTGFicha As New datostaller

            Dim tablaFacturacion As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dsFacturacion As New datosgenerales


            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select texto1 as piecliente, texto2 as pieempresa from tecni_datosgenerales WHERE id=1", conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("datosFichaIngreso"))


            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "lpad(tall.id,4,'0') as orden, " _
            & "concat('FECHA INGRESO: ',tall.fecha_ing) as fecha, case tall.trabajo_categoria " _
            & "when 4 then concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon,'(',tall.infoextra,')') " _
            & "when 2 then concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon) " _
            & "when 3 then concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon) " _
            & "end  as clientectarazon, " _
            & "concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon) as clientectarazon, " _
            & "concat('CODINT: ',tall.equipo) as codint, " _
            & "concat('RECIBIO: ',us.apellido,', ', us.nombre) as recibio, " _
            & "concat('TIPO EQUIPO: ', et.nombre) as equipotipo, " _
            & "concat('MARCA/MODELO: ', ma.nombre,'/', mo.nombre) as equipomarcamodelo, " _
            & "concat('ACCESORIOS: ',tall.accesorios) as accesorios, " _
            & "concat('MOTIVO: ', tall.motivo_ing) as motivo, " _
            & "concat('DIRECCION: ', cl.dir_domicilio,'TEL: ',cl.telefono,'| CEL: ',cl.celular) as clientedire, " _
            & "concat('SERIE: ', tall.serie) as equiposerie " _
            & "from tecni_taller as tall, fact_clientes as cl, cm_usuarios as us, fact_marcas as ma, fact_modelos as mo, tecni_equipos_tipo as et, " _
            & "tecni_equipos as eq " _
            & "where " _
            & "tall.cliente=cl.idclientes and tall.modelo=eq.id and eq.tipo_equ=et.id and eq.marca=ma.id and eq.modelo=mo.id and tall.recibe=us.id " _
            & "and tall.id=" & Val(NUMor), conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("fichaIngreso"))



            Reconectar()
            tablaFacturacion.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select nombrefantasia, razonsocial, concat('Direccion: ',direccion,' - ',otrosdatos) as direccion, localidad, cuit, ingbrutos, ivatipo, inicioact, drei from fact_empresa where id=1", conexionPrinc)
            tablaFacturacion.Fill(dsFacturacion.Tables("datosEmpresa"))

            Dim imping As New imprimiringreso
            With imping
                .MdiParent = Me.MdiParent
                .rptingreso.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptingreso.LocalReport.ReportEmbeddedResource = System.Environment.CurrentDirectory & "\reportes\fichaingreso.rdlc"
                .rptingreso.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\fichaingreso.rdlc"
                .rptingreso.LocalReport.DataSources.Clear()
                .rptingreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosEmp", dsFacturacion.Tables("datosEmpresa")))
                .rptingreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosFing", dsDTGFicha.Tables("datosFichaIngreso")))
                .rptingreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosOrden", dsDTGFicha.Tables("fichaIngreso")))
                .rptingreso.DocumentMapCollapsed = True
                .rptingreso.RefreshReport()
                .Show()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GenerarExcel(dtresultado)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'Dim orden As Integer = 
            Dim tablaDTGFicha As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dsDTGFicha As New datostaller

            Dim tablaFacturacion As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dsFacturacion As New datosgenerales

            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select texto1 as pie from tecni_datosgenerales WHERE id=2", conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("datosFichaEgreso"))


            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "lpad(tall.id,4,'0') as orden, " _
            & "concat('FECHA INGRESO: ',tall.fecha_ing) as fecha, case tall.trabajo_categoria " _
            & "when 4 then concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon,'(',tall.infoextra,')') " _
            & "when 2 then concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon) " _
            & "when 3 then concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon) " _
            & "end  as clientectarazon, " _
            & "concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon) as clientectarazon, " _
            & "concat('CODINT: ',tall.equipo) as codint, " _
            & "concat('RECIBIO: ',us.apellido,', ', us.nombre) as recibio, " _
            & "concat('TIPO EQUIPO: ', et.nombre) as equipotipo, " _
            & "concat('MARCA/MODELO: ', ma.nombre,'/', mo.nombre) as equipomarcamodelo, " _
            & "concat('ACCESORIOS: ',tall.accesorios) as accesorios, " _
            & "concat('MOTIVO: ', tall.motivo_ing) as motivo, " _
            & "concat('DIRECCION: ', cl.dir_domicilio,'TEL: ',cl.telefono,'| CEL: ',cl.celular) as clientedire, " _
            & "concat('SERIE: ', tall.serie) as equiposerie " _
            & "from tecni_taller as tall, fact_clientes as cl, cm_usuarios as us, fact_marcas as ma, fact_modelos as mo, tecni_equipos_tipo as et, " _
            & "tecni_equipos as eq " _
            & "where " _
            & "tall.cliente=cl.idclientes and tall.modelo=eq.id and eq.tipo_equ=et.id and eq.marca=ma.id and eq.modelo=mo.id and tall.recibe=us.id " _
            & "and tall.id=" & dtresultado.CurrentRow.Cells(0).Value, conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("fichaIngreso"))

            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT tall.falla as falla, tall.tarea_realiz as resolucion, tall.mo_monto as montomo, tall.ins_monto as montoins, tall.trab_monto as montotot, tall.fecha_eg as fecha, concat(te.apellido,', ', te.nombre) as tecnico " _
            & " FROM tecni_taller as tall, tecni_tecnicos as te where tall.tecnico=te.id and tall.id =" & dtresultado.CurrentRow.Cells(0).Value, conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("fichaEgreso"))

            Reconectar()
            tablaFacturacion.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select nombrefantasia, razonsocial, concat('Direccion: ',direccion,' - ',otrosdatos) as direccion, localidad, cuit, ingbrutos, ivatipo, inicioact, drei from fact_empresa where id=1", conexionPrinc)
            tablaFacturacion.Fill(dsFacturacion.Tables("datosEmpresa"))

            Dim imping As New imprimiregreso
            With imping
                .MdiParent = Me.MdiParent
                .rptegreso.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptegreso.LocalReport.ReportEmbeddedResource = System.Environment.CurrentDirectory & "\reportes\fichaegreso.rdlc"
                .rptegreso.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\fichaegreso.rdlc"
                .rptegreso.LocalReport.DataSources.Clear()
                .rptegreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosEmp", dsFacturacion.Tables("datosEmpresa")))
                .rptegreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosPieEg", dsDTGFicha.Tables("datosFichaEgreso")))
                .rptegreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosOrden", dsDTGFicha.Tables("fichaIngreso")))
                .rptegreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosEgreso", dsDTGFicha.Tables("fichaEgreso")))
                .rptegreso.DocumentMapCollapsed = True
                .rptegreso.RefreshReport()
                .Show()
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class