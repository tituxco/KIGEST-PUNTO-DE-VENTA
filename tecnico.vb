Imports System.Windows.Forms.DataVisualization.Charting

Public Class tecnico
    Public tablaTALLER As New DataTable
    Dim filtrataller As Windows.Forms.BindingSource = New BindingSource

    Dim tablaTERMINADOS As New DataTable
    Dim filtraterminados As Windows.Forms.BindingSource = New BindingSource

    Dim tablaBAJA As New DataTable
    Dim filtrabaja As Windows.Forms.BindingSource = New BindingSource

    Public Shared refrescarTaller As Boolean
    Public Shared refrescarTrabajos As Boolean
    Dim cargaecli As Boolean
    Private Sub CargarCategoriastrab()
        Reconectar()
        Dim tablacattrab As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from tecni_trabajo_categoria  where id>1", conexionPrinc)
        Dim readcattrab As New DataSet
        tablacattrab.Fill(readcattrab)
        cmbcattrab.DataSource = readcattrab.Tables(0)
        cmbcattrab.DisplayMember = readcattrab.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbcattrab.ValueMember = readcattrab.Tables(0).Columns(0).Caption.ToString
        cmbcattrab.SelectedValue = 2

    End Sub
    Private Sub CargarTipoEq_falla()
        TreeView1.Nodes.Clear()
        Reconectar()
        Dim tablateq As New MySql.Data.MySqlClient.MySqlDataAdapter("select te.id, te.nombre from tecni_equipos_tipo as te " _
        & "where te.id in (select tipo_equ from tecni_equipos) order by te.nombre", conexionPrinc)
        Dim readteq As New DataTable
        Dim infoeq() As DataRow
        tablateq.Fill(readteq)
        infoeq = readteq.Select()
        Dim i As Integer
        For i = 0 To infoeq.GetUpperBound(0) - 1
            Dim nodo As TreeNode = New TreeNode(infoeq(i)(1))
            nodo.Tag = infoeq(i)(0)
            TreeView1.Nodes.Add(nodo)
        Next
    End Sub
    Private Sub CargarMarcas_falla(ByRef TipoEq As Integer)
        'TreeView1.Nodes.Clear()
        Reconectar()
        Dim tablatmar As New MySql.Data.MySqlClient.MySqlDataAdapter("select ma.id, ma.nombre from fact_marcas as ma " _
        & " order by ma.nombre", conexionPrinc)
        Dim readmar As New DataTable
        Dim infomar() As DataRow
        tablatmar.Fill(readmar)
        infomar = readmar.Select()
        Dim i As Integer
        For i = 0 To infomar.GetUpperBound(0) - 1
            Dim nodo As TreeNode = New TreeNode(infomar(i)(1))
            nodo.Tag = infomar(i)(0)
            TreeView1.SelectedNode.Nodes.Add(nodo)

        Next
    End Sub

    Private Sub CargarMarc_falla()
        Reconectar()
        Dim tablamarc As New MySql.Data.MySqlClient.MySqlDataAdapter("select ma.id, ma.nombre from fact_marcas as ma " _
        & "where ma.id in (select marca from tecni_equipos where tipo_equ=" & cmbteq.SelectedValue & ")", conexionPrinc)
        Dim readmarc As New DataSet
        tablamarc.Fill(readmarc)
        cmbmarc.DataSource = readmarc.Tables(0)
        cmbmarc.DisplayMember = readmarc.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbmarc.ValueMember = readmarc.Tables(0).Columns(0).Caption.ToString
        cmbmarc.SelectedIndex = -1
    End Sub

    Private Sub CargarMod_falla()
        Reconectar()
        Dim tablamo As New MySql.Data.MySqlClient.MySqlDataAdapter("select eq.id, mo.nombre from  tecni_equipos as eq, fact_modelos as mo " _
        & "where tipo_equ=" & cmbteq.SelectedValue & " and marca=" & cmbmarc.SelectedValue & " and mo.id=eq.modelo", conexionPrinc)
        Dim readmo As New DataTable
        tablamo.Fill(readmo)
        dtmodelosgral.DataSource = readmo
        dtmodelosgral.Columns(0).Visible = False
    End Sub

    Private Sub CreaColumnas()
        tablaTERMINADOS.Columns.Add("NumOR")
        tablaTERMINADOS.Columns.Add("CodINT")
        tablaTERMINADOS.Columns.Add("FECHA EGRESO")
        tablaTERMINADOS.Columns.Add("CLIENTE")
        tablaTERMINADOS.Columns.Add("EQUIPO")
        tablaTERMINADOS.Columns.Add("ESTADO")
        tablaTERMINADOS.Columns.Add("OBSERVACIONES")

        tablaTALLER.Columns.Add("NumOR")
        tablaTALLER.Columns.Add("FECHA INGRESO")
        tablaTALLER.Columns.Add("CLIENTE")
        tablaTALLER.Columns.Add("EQUIPO")
        tablaTALLER.Columns.Add("SERIE")
        tablaTALLER.Columns.Add("ESTADO")
        tablaTALLER.Columns.Add("OBSERVACIONES")

    End Sub
    Public Sub cargarTaller()
        Try
            If refrescarTaller = False Then
                tablaTALLER.Rows.Clear()
                'dttaller.Rows.Clear()
                Reconectar()
                Dim consultataller As New MySql.Data.MySqlClient.MySqlDataAdapter("select tall.id as ORDEN, " _
                & "tall.fecha_ing as FechaING, CASE tall.trabajo_categoria " _
                & "when 2 then (select nomapell_razon from fact_clientes where idclientes=tall.cliente) " _
                & "when 4 then concat((select nomapell_razon from fact_clientes where idclientes=tall.cliente),'(',tall.infoextra,')') end as Cliente, " _
                & "(select concat(et.nombre,'/',ma.nombre,'/',mo.nombre) from tecni_equipos as eq, tecni_equipos_tipo as et, fact_marcas as ma, fact_modelos as mo " _
                & "where eq.marca=ma.id and eq.modelo=mo.id and eq.tipo_equ=et.id and eq.id=tall.modelo) as EQUIPO, tall.serie as SERIE, " _
                & "est.nombre as ESTADO, tall.observaciones as OBSERVACIONES,tall.estado " _
                & "from tecni_taller as tall, tecni_taller_estado as est where tall.estado=est.id and tall.estado<>8 and tall.estado<>18 and tall.trabajo_categoria=" & cmbcattrab.SelectedValue & " order by tall.id desc", conexionPrinc)

                Dim tablatall As New DataTable
                Dim infotall() As DataRow
                consultataller.Fill(tablatall)
                infotall = tablatall.Select()
                Dim i As Integer
                For i = 0 To infotall.GetUpperBound(0)
                    Dim filaTALLER As DataRow = tablaTALLER.NewRow
                    filaTALLER(0) = infotall(i)(0)
                    filaTALLER(1) = infotall(i)(1)
                    filaTALLER(2) = infotall(i)(2)
                    filaTALLER(3) = infotall(i)(3)
                    filaTALLER(4) = infotall(i)(4)
                    filaTALLER(5) = infotall(i)(5)
                    filaTALLER(6) = infotall(i)(6)
                    tablaTALLER.Rows.Add(filaTALLER)
                    tablaTALLER.AcceptChanges()
                Next
                filtrataller.DataSource = tablaTALLER
                dttaller.DataSource = filtrataller
                dttaller.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dttaller.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                refrescarTaller = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargaTrabajos()
        Try
            If refrescarTrabajos = False Then
                'tablaTERMINADOS.Rows.Clear()
                'dttrabajosterm.Rows.Clear()
                Reconectar()
                Dim consultatrab As New MySql.Data.MySqlClient.MySqlDataAdapter("select tall.id as ORDEN, tall.equipo as CodINT, tall.fecha_eg as FECHA, CASE tall.trabajo_categoria " _
                & "when 2 then (select nomapell_razon from fact_clientes where idclientes=tall.cliente) " _
                & "when 4 then concat((select nomapell_razon from fact_clientes where idclientes=tall.cliente),'(',tall.infoextra,')') end as Cliente," _
                & "(select concat(et.nombre,'/',ma.nombre,'/',mo.nombre) from tecni_equipos as eq, tecni_equipos_tipo as et, fact_marcas as ma, fact_modelos as mo " _
                & "where eq.marca=ma.id and eq.modelo=mo.id and eq.tipo_equ=et.id and eq.id=tall.modelo) as EQUIPO, tall.serie as SERIE, " _
                & "concat(est.nombre,' ', tall.factura) as ESTADO, tall.observaciones as OBSERVACIONES " _
                & "from tecni_taller as tall, tecni_trabajo_estado as est " _
                & "where tall.trab_estado=est.id and tall.estado=8 and fecha_eg between '" & Format(CDate(dtpdesdetrab.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(dtphastatrab.Value), "yyyy-MM-dd") & "' order by actualizado desc", conexionPrinc)

                Dim tablatrab As New DataTable
                'Dim infotrab() As DataRow
                consultatrab.Fill(tablatrab)
                'infotrab = tablatrab.Select()
                'Dim i As Integer
                'For i = 0 To infotrab.GetUpperBound(0)
                'Dim filaTERMINADO As DataRow = tablaTERMINADOS.NewRow
                'filaTERMINADO(0) = infotrab(i)(0)
                'filaTERMINADO(1) = infotrab(i)(7)
                'filaTERMINADO(2) = infotrab(i)(1)
                'filaTERMINADO(3) = infotrab(i)(2)
                'filaTERMINADO(4) = infotrab(i)(3)
                'filaTERMINADO(5) = infotrab(i)(4)
                'filaTERMINADO(6) = infotrab(i)(5)
                'tablaTERMINADOS.Rows.Add(filaTERMINADO)
                'tablaTERMINADOS.AcceptChanges()
                'Next
                filtraterminados.DataSource = tablatrab 'tablaTERMINADOS
                dttrabajosterm.DataSource = filtraterminados
                dttrabajosterm.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dttrabajosterm.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                refrescarTrabajos = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargaEquiposbaja()
        Try
            dtequiposbaja.Rows.Clear()
            Reconectar()
            Dim consultabaja As New MySql.Data.MySqlClient.MySqlDataAdapter("select tall.id as ORDEN,tall.actualizado as FECHA,CASE tall.trabajo_categoria " _
            & "when 2 then (select nomapell_razon from fact_clientes where idclientes=tall.cliente) " _
            & "when 4 then concat((select nomapell_razon from fact_clientes where idclientes=tall.cliente),'(',tall.infoextra,')') end as Cliente," _
            & "(select concat(et.nombre,'/',ma.nombre,'/',mo.nombre) from tecni_equipos as eq, tecni_equipos_tipo as et, fact_marcas as ma, fact_modelos as mo " _
            & "where eq.marca=ma.id and eq.modelo=mo.id and eq.tipo_equ=et.id and eq.id=tall.modelo) as EQUIPO," _
            & "est.nombre as ESTADO,tall.observaciones,tall.trab_estado " _
            & "from tecni_taller as tall, tecni_trabajo_estado as est " _
            & "where tall.trab_estado=est.id and tall.estado=18 order by actualizado desc", conexionPrinc)

            Dim tablabaja As New DataTable
            Dim infobaja() As DataRow
            consultabaja.Fill(tablabaja)
            infobaja = tablabaja.Select()
            Dim i As Integer
            For i = 0 To infobaja.GetUpperBound(0)
                dtequiposbaja.Rows.Add(infobaja(i)(0), infobaja(i)(1), infobaja(i)(2).ToString, infobaja(i)(3).ToString, infobaja(i)(4).ToString, infobaja(i)(5).ToString)
                Select infobaja(i)(6)
                    Case 4
                        dtequiposbaja.Rows(dtequiposbaja.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                    Case 5
                        dtequiposbaja.Rows(dtequiposbaja.RowCount - 1).DefaultCellStyle.BackColor = Color.White
                End Select
            Next
            'dtequiposbaja.DataSource = tablabaja
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargaServiciosCloud()
        Try
            dtcloud.Rows.Clear()
            Reconectar()
            Dim consultacloud As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, cliente, sistema, usuario, pass,servidor,bd, puerto, codus, clave, servidor_resp, modulo,autorizado from AuthServ.CliAuth", conexionPrinc)
            Dim tablacloud As New DataTable
            Dim infocloud() As DataRow
            consultacloud.Fill(tablacloud)
            infocloud = tablacloud.Select()
            Dim i As Integer
            For i = 0 To infocloud.GetUpperBound(0)
                dtcloud.Rows.Add(infocloud(i)(0), infocloud(i)(1), infocloud(i)(2).ToString, infocloud(i)(3).ToString, infocloud(i)(4).ToString, infocloud(i)(5).ToString, infocloud(i)(6).ToString, infocloud(i)(7).ToString, infocloud(i)(8).ToString, infocloud(i)(9).ToString, infocloud(i)(10).ToString, infocloud(i)(11).ToString, infocloud(i)(12).ToString)
                If infocloud(i)(12) = 0 Then
                    dtcloud.Rows(dtcloud.RowCount - 2).DefaultCellStyle.BackColor = Color.OrangeRed
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tabtaller_Enter(sender As Object, e As EventArgs) Handles tabtaller.Enter
        Try
            cargarTaller()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tabtrabajos_Enter(sender As Object, e As EventArgs) Handles tabtrabajos.Enter
        cargaTrabajos()
    End Sub

    Private Sub tabbaja_Enter(sender As Object, e As EventArgs) Handles tabbaja.Enter
        cargaEquiposbaja()
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

    

    Private Sub dtpdesdetrab_ValueChanged(sender As Object, e As EventArgs) Handles dtpdesdetrab.ValueChanged
        Try
            'txtbuscaclieterm.Text = ""
            'txtbuscaorterm.Text = ""
            'tablaTERMINADOS.Rows.Clear()
            refrescarTrabajos = False
            cargaTrabajos()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargarTecnicos()
        Reconectar()
        Dim tablatecnicos As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,',',nombre) from tecni_tecnicos where activo=1", conexionPrinc)
        Dim readtecnicos As New DataSet
        tablatecnicos.Fill(readtecnicos)
        cmbtecnico.DataSource = readtecnicos.Tables(0)
        cmbtecnico.DisplayMember = readtecnicos.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbtecnico.ValueMember = readtecnicos.Tables(0).Columns(0).Caption.ToString
        cmbtecnico.SelectedIndex = -1

    End Sub

    Private Sub tecnico_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        'Try
        '    If e.KeyCode = Keys.F12 Then
        '        If ComprobarUsuarioAdmin(InputBox("Esta acción requiere permisos de administrador, ingrese usuario", "Acceso a informes avanzados"), _
        '        InputBox("Esta acción requiere permisos de administrador, ingrese contraseña", "Acceso a informes avanzados")) = True Then
        '            tabestadisticas.Parent = tbtaller
        '            tabresumen.Parent = tbtaller
        '        Else
        '            MsgBox("No tiene los privilegios necesarios o hubo un error en la comprobacion de su usario")
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub tecnico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpdesdetrab.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
        CreaColumnas()
        CargarTecnicos()
        CargarCategoriastrab()
        chrestad.Series.Clear()
        tabestadisticas.Parent = Nothing
        tabresumen.Parent = Nothing
    End Sub

    Private Sub dtphastatrab_ValueChanged(sender As Object, e As EventArgs) Handles dtphastatrab.ValueChanged
        Try
            'txtbuscaclieterm.Text = ""
            'txtbuscaorterm.Text = ""
            'tablaTERMINADOS.Rows.Clear()
            cargaTrabajos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdimprimirfing_Click(sender As Object, e As EventArgs) Handles cmdimprimirfing.Click
        Try
            Dim NUMor As Integer = dttaller.CurrentRow.Cells(0).Value
            Dim tablaDTGFicha As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dsDTGFicha As New datostaller

            Dim tablaFacturacion As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dsFacturacion As New datosgenerales


            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select texto1 as piecliente, texto2 as pieempresa from tecni_datosgenerales WHERE id=1", conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("datosFichaIngreso"))


            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "concat('ORDEN: ',tall.id) as orden, " _
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
            & "concat('DIRECCION: ', cl.dir_domicilio) as clientedire, " _
            & "concat('SERIE: ', tall.serie) as equiposerie " _
            & "from tecni_taller as tall, fact_clientes as cl, cm_usuarios as us, fact_marcas as ma, fact_modelos as mo, tecni_equipos_tipo as et, " _
            & "tecni_equipos as eq " _
            & "where " _
            & "tall.cliente=cl.idclientes and tall.modelo=eq.id and eq.tipo_equ=et.id and eq.marca=ma.id and eq.modelo=mo.id and tall.recibe=us.id " _
            & "and tall.id=" & Val(NUMor), conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("fichaIngreso"))



            Reconectar()
            tablaFacturacion.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select nombrefantasia, razonsocial, direccion, localidad, cuit, ingbrutos, ivatipo, inicioact, drei from fact_empresa where id=1", conexionPrinc)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
        fichequ.ORden = dttaller.CurrentRow.Cells(0).Value
        fichequ.Show()
    End Sub

    Private Sub cmdrecargar_Click(sender As Object, e As EventArgs) Handles cmdrecargar.Click
        Try
            refrescarTaller = False
            cargarTaller()
            'MsgBox(tablaTALLER.Rows.Count)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdrecargaTrabajos_Click(sender As Object, e As EventArgs) Handles cmdrecargaTrabajos.Click
        Try
            refrescarTrabajos = False
            cargaTrabajos()
            'MsgBox(tablaTALLER.Rows.Count)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Me.Close()
    End Sub

    Private Sub cmbcattrab_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcattrab.SelectionChangeCommitted
        Try
            refrescarTaller = False
            cargarTaller()
            'MsgBox(tablaTALLER.Rows.Count)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim orden As Integer = dttrabajosterm.CurrentRow.Cells(0).Value
            Dim tablaDTGFicha As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dsDTGFicha As New datostaller

            Dim tablaFacturacion As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dsFacturacion As New datosgenerales

            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select texto1 as pie from tecni_datosgenerales WHERE id=2", conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("datosFichaEgreso"))


            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "concat('ORDEN: ',tall.id) as orden, " _
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
            & "concat('DIRECCION: ', cl.dir_domicilio) as clientedire, " _
            & "concat('SERIE: ', tall.serie) as equiposerie " _
            & "from tecni_taller as tall, fact_clientes as cl, cm_usuarios as us, fact_marcas as ma, fact_modelos as mo, tecni_equipos_tipo as et, " _
            & "tecni_equipos as eq " _
            & "where " _
            & "tall.cliente=cl.idclientes and tall.modelo=eq.id and eq.tipo_equ=et.id and eq.marca=ma.id and eq.modelo=mo.id and tall.recibe=us.id " _
            & "and tall.id=" & orden, conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("fichaIngreso"))

            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT tall.falla as falla, tall.tarea_realiz as resolucion, tall.mo_monto as montomo, tall.ins_monto as montoins, tall.trab_monto as montotot, tall.fecha_eg as fecha, concat(te.apellido,', ', te.nombre) as tecnico " _
            & " FROM kigest_fact.tecni_taller as tall, tecni_tecnicos as te where tall.tecnico=te.id and tall.id =" & orden, conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("fichaEgreso"))

            Reconectar()
            tablaFacturacion.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select nombrefantasia, razonsocial, direccion, localidad, cuit, ingbrutos, ivatipo, inicioact, drei from fact_empresa where id=1", conexionPrinc)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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
        fichequ.ORden = dttrabajosterm.CurrentRow.Cells(0).Value
        fichequ.cmdfinalizar.Enabled = False
        fichequ.txtinfoextra.ReadOnly = False
        fichequ.Show()
    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles tabclouding.Enter
        CargaServiciosCloud()
    End Sub

    Private Sub dtcloud_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dtcloud.RowValidated
        Try
            Dim sqlQuery As String = "update AuthServ.CliAuth set cliente=?cliente, sistema=?sistema,usuario=?clusua, pass=?clpass, servidor=?clserv,bd=?clbd,puerto=?clpuerto," _
            & "codus=?auusua,clave=?aupass, servidor_resp=?servresp, modulo=?modulo, autorizado=?autorizado where id=" & dtcloud.Rows(e.RowIndex).Cells(0).Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?cliente", dtcloud.Rows(e.RowIndex).Cells(1).Value.ToString.ToUpper)
                .AddWithValue("?sistema", dtcloud.Rows(e.RowIndex).Cells(2).Value.ToString.ToUpper)
                .AddWithValue("?clusua", dtcloud.Rows(e.RowIndex).Cells(3).Value)
                .AddWithValue("?clpass", dtcloud.Rows(e.RowIndex).Cells(4).Value)
                .AddWithValue("?clserv", dtcloud.Rows(e.RowIndex).Cells(5).Value)
                .AddWithValue("?clbd", dtcloud.Rows(e.RowIndex).Cells(6).Value.ToString.ToLower)
                .AddWithValue("?clpuerto", dtcloud.Rows(e.RowIndex).Cells(7).Value)
                .AddWithValue("?auusua", dtcloud.Rows(e.RowIndex).Cells(8).Value)
                .AddWithValue("?aupass", dtcloud.Rows(e.RowIndex).Cells(9).Value)
                .AddWithValue("?servresp", dtcloud.Rows(e.RowIndex).Cells(10).Value)
                .AddWithValue("?modulo", dtcloud.Rows(e.RowIndex).Cells(11).Value)
                .AddWithValue("?autorizado", dtcloud.Rows(e.RowIndex).Cells(12).Value)
            End With
            comandoadd.ExecuteNonQuery()
            If dtcloud.Rows(e.RowIndex).Cells(12).Value = 0 Then
                dtcloud.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.OrangeRed
            Else
                dtcloud.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles tabbdfallas.Enter
        CargarTipoEq_falla()
    End Sub

    Private Sub cmbteq_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbteq.SelectionChangeCommitted
        CargarMarc_falla()
    End Sub

    Private Sub cmbmarc_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbmarc.SelectionChangeCommitted
        CargarMod_falla()
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Try
            Dim extratec As String
            If cmbtecnico.SelectedIndex <> -1 Then
                extratec = " and tecnico=" & cmbtecnico.SelectedValue
            End If
            Dim consultaestad As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
            & " id as Orden, fecha_ing as Ingreso, fecha_eg as Egreso, mo_monto as MO, ins_monto INS, trab_monto as TOTAL " _
            & " from tecni_taller where estado=8 and fecha_eg between '" & Format(CDate(dtdeestad.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(dthastaestad.Value), "yyyy-MM-dd") & "' " & extratec, conexionPrinc)

            Dim tablaEstad As New DataTable
            consultaestad.Fill(tablaEstad)
            dtestadisticas.DataSource = tablaEstad
            dtestadisticas.Columns(3).FillWeight = 30
            dtestadisticas.Columns(4).FillWeight = 30
            dtestadisticas.Columns(5).FillWeight = 30
            Dim i As Integer
            Dim totmo As Double
            Dim totins As Double
            Dim tottrab As Double
            For i = 0 To dtestadisticas.Rows.Count - 1
                totins += dtestadisticas.Rows(i).Cells(4).Value
                totmo += dtestadisticas.Rows(i).Cells(3).Value
                tottrab += dtestadisticas.Rows(i).Cells(5).Value
            Next
            dttotestad.Rows.Clear()
            dttotestad.Rows.Add("", "", "TOTAL", totmo, totins, tottrab)
            'dttotestad.Rows(dttotales.RowCount - 1).DefaultCellStyle.BackColor = Color.YellowGreen
            'dttotestad.Rows(dttotales.RowCount - 1).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtestadisticas_DoubleClick(sender As Object, e As EventArgs) Handles dtestadisticas.DoubleClick
        Dim i As Integer
        For i = 0 To frmprincipal.MdiChildren.Length - 1
            If frmprincipal.MdiChildren(i).Name = "fichaequipo" Then
                MsgBox("Ya hay una ficha abierta, se mostrara la información de la misma, para ver la nueva ficha primero cierre la anterior", vbCritical)
                frmprincipal.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next
        Dim fichequ As New fichaequipo
        fichequ.MdiParent = Me.MdiParent
        fichequ.ORden = dtestadisticas.CurrentRow.Cells(0).Value
        fichequ.cmdfinalizar.Enabled = False
        'fichequ.txtinfoextra.ReadOnly = False
        fichequ.Show()
    End Sub

    Private Sub MostrarIngresos()
        Try
            chrestad.Series.Clear()
            Reconectar()
            Dim tabla As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
            & " concat(date_format(tec.fecha_ing,'%m'),'/',date_format(tec.fecha_ing,'%Y')) as mes, count(id) as ingresos from tecni_taller as tec " _
            & " where tec.fecha_ing between '" & Format(CDate(dtdegraf.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(dthastagraf.Value), "yyyy-MM-dd") & "'" _
            & " group by date_format(tec.fecha_ing,'%Y-%m')", conexionPrinc)

            Dim readgraf As New DataSet
            tabla.Fill(readgraf, "tec")

            chrestad.DataSource = readgraf.Tables("tec")

            Dim ingresos As New Series
            chrestad.Series.Add(ingresos)
            ingresos.Name = "Ingresos"

            chrestad.Series(ingresos.Name).XValueMember = "mes"
            chrestad.Series(ingresos.Name).YValueMembers = "ingresos"

            chrestad.Series.Item(0).ChartType = SeriesChartType.Line
            chrestad.Series.Item(0).BorderWidth = 3
        Catch ex As Exception

        End Try


    End Sub
    Private Sub MostrarEgresos()
        Try

            chrestad.Series.Clear()
            Reconectar()
            Dim tabla As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
            & " concat(date_format(tec.fecha_eg,'%m'),'/',date_format(tec.fecha_eg,'%Y')) as mes, count(id) as egresos, sum(replace(tec.trab_monto,',','.')) as facturado " _
            & " from tecni_taller as tec " _
            & " where tec.fecha_eg between '" & Format(CDate(dtdegraf.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(dthastagraf.Value), "yyyy-MM-dd") & "'" _
            & " group by date_format(tec.fecha_eg,'%Y-%m')", conexionPrinc)
            Dim readgraf As New DataSet
            tabla.Fill(readgraf, "tec")

            chrestad.DataSource = readgraf.Tables("tec")

            Dim ingresos As New Series

            chrestad.Series.Add(ingresos)

            ingresos.Name = "Egresos"



            chrestad.Series(ingresos.Name).XValueMember = "mes"
            chrestad.Series(ingresos.Name).YValueMembers = "egresos"


            chrestad.Series.Item(0).ChartType = SeriesChartType.Line
            chrestad.Series.Item(0).BorderWidth = 3

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Mostrarfacturados()
        Try

            chrestad.Series.Clear()
            Reconectar()
            Dim tabla As New MySql.Data.MySqlClient.MySqlDataAdapter("select  " _
            & " concat(date_format(tec.fecha_eg,'%m'),'/',date_format(tec.fecha_eg,'%Y')) as mes, " _
            & " if (tec.trab_estado=1, round(sum(replace(tec.trab_monto,',','.')),2),'') as facturado, " _
            & " if (tec.trab_estado=2, round(sum(replace(tec.trab_monto,',','.')),2),'') as ctacte, " _
            & " if (tec.trab_estado=3,round(sum(replace(tec.trab_monto,',','.')),2),'') as espera, " _
            & " round(sum(replace(tec.ins_monto,',','.')),2) as insumos " _
            & " from tecni_taller as tec  where tec.fecha_eg between '" & Format(CDate(dtdegraf.Value), "yyyy-MM-dd") & "' and '" & Format(CDate(dthastagraf.Value), "yyyy-MM-dd") & "' " _
            & " group by date_format(tec.fecha_eg,'%Y-%m')", conexionPrinc)
            Dim readgraf As New DataSet

            tabla.Fill(readgraf, "tec")
            chrestad.DataSource = readgraf.Tables("tec")
            Dim facturado As New Series
            Dim espera As New Series
            Dim ctacte As New Series
            Dim insumos As New Series


            chrestad.Series.Add(facturado)
            chrestad.Series.Add(espera)
            chrestad.Series.Add(ctacte)
            chrestad.Series.Add(insumos)

            facturado.Name = "Facturado"
            espera.Name = "En espera"
            ctacte.Name = "Cta Cte"
            insumos.Name = "Insumos Utilizados"


            chrestad.Series(facturado.Name).XValueMember = "mes"
            chrestad.Series(facturado.Name).YValueMembers = "facturado"

            chrestad.Series(espera.Name).XValueMember = "mes"
            chrestad.Series(espera.Name).YValueMembers = "espera"

            chrestad.Series(ctacte.Name).XValueMember = "mes"
            chrestad.Series(ctacte.Name).YValueMembers = "ctacte"

            chrestad.Series(insumos.Name).XValueMember = "mes"
            chrestad.Series(insumos.Name).YValueMembers = "insumos"

            chrestad.Series.Item(0).ChartType = SeriesChartType.Line
            chrestad.Series.Item(0).BorderWidth = 3
            chrestad.Series.Item(1).ChartType = SeriesChartType.Line
            chrestad.Series.Item(1).BorderWidth = 3
            chrestad.Series.Item(2).ChartType = SeriesChartType.Line
            chrestad.Series.Item(2).BorderWidth = 3
            chrestad.Series.Item(3).ChartType = SeriesChartType.Line
            chrestad.Series.Item(3).BorderWidth = 3

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdingresos_CheckedChanged(sender As Object, e As EventArgs) Handles rdingresos.CheckedChanged
        If rdingresos.Checked = True Then
            MostrarIngresos()
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rdegresos.CheckedChanged
        If rdegresos.Checked = True Then
            MostrarEgresos()
        End If
    End Sub

    Private Sub rdmonto_CheckedChanged(sender As Object, e As EventArgs) Handles rdmonto.CheckedChanged
        If rdmonto.Checked = True Then
            Mostrarfacturados()
        End If
    End Sub

    Private Sub txtbuscarClieTall_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscarClieTall.KeyUp
        Try
            If rdor.Checked = True Then filtrataller.Filter = "NumOR like '%" & txtbuscarClieTall.Text & "%'"
            If rdcliente.Checked = True Then filtrataller.Filter = "CLIENTE like '%" & txtbuscarClieTall.Text & "%'"
            If rdequipo.Checked = True Then filtrataller.Filter = "EQUIPO like '%" & txtbuscarClieTall.Text & "%'"
            If rdserie.Checked = True Then filtrataller.Filter = "SERIE like '%" & txtbuscarClieTall.Text & "%'"
            If rdobservaciones.Checked = True Then filtrataller.Filter = "OBSERVACIONES like '%" & txtbuscarClieTall.Text & "%'"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbuscaclieterm_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscaclieterm.KeyUp
        Try
            If rdtrabCLIE.Checked = True Then filtraterminados.Filter = "CLIENTE like '%" & txtbuscaclieterm.Text & "%'"
            If rdtrabEquipo.Checked = True Then filtraterminados.Filter = "EQUIPO like '%" & txtbuscaclieterm.Text & "%'"
            If rdtrabOBS.Checked = True Then filtraterminados.Filter = "OBSERVACIONES like '%" & txtbuscaclieterm.Text & "%'"
            If rdtrabSERIE.Checked = True Then filtraterminados.Filter = "SERIE like '%" & txtbuscaclieterm.Text & "%'"

            If rdtrabcodint.Checked = True And txtbuscaclieterm.Text = "" Then
                filtraterminados.Filter = "CodINT > 0"
            ElseIf rdtrabcodint.Checked = True And txtbuscaclieterm.Text <> "" Then
                filtraterminados.Filter = "CodINT=" & txtbuscaclieterm.Text
            End If


            If rdtrabOR.Checked = True And txtbuscaclieterm.Text = "" Then
                filtraterminados.Filter = "ORDEN >0"
            ElseIf rdtrabOR.Checked = True And txtbuscaclieterm.Text <> "" Then
                filtraterminados.Filter = "ORDEN = " & txtbuscaclieterm.Text
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            cargaecli = False
            treequipos.Nodes.Clear()
            Reconectar()
            Dim consulta As String
            If rdequiposclieCliente.Checked = True Then
                consulta = " where tecli.propietario like '" & txtequiposclieBusqueda.Text & "'"
            End If

            If rdequiposclieCodInt.Checked = True Then
                consulta = " where tecli.id like '" & txtequiposclieBusqueda.Text & "'"
            End If

            If rdequiposlclieSerie.Checked = True Then
                consulta = " where tecli.serie like '" & txtequiposclieBusqueda.Text & "'"
            End If

            Dim tabla As New MySql.Data.MySqlClient.MySqlDataAdapter("select tecli.id, " _
            & "(select nomapell_razon from fact_clientes where idclientes=tecli.propietario) as cliente, " _
            & "(select concat(et.nombre,'/',ma.nombre,'/',mo.nombre) from tecni_equipos as eq, tecni_equipos_tipo as et, fact_marcas as ma, fact_modelos as mo  " _
            & "where eq.marca=ma.id and eq.modelo=mo.id and eq.tipo_equ=et.id and eq.id=tecli.modelo) as EQUIPO, tecli.serie as SERIE, " _
            & "tecli.estado " _
            & "from tecni_equipos_clientes as tecli " & consulta, conexionPrinc)

            Dim leertab As New DataTable
            Dim itemtab() As DataRow
            tabla.Fill(leertab)
            itemtab = leertab.Select()
            Dim i As Integer
            For i = 0 To itemtab.GetUpperBound(0)
                treequipos.Nodes.Add("CODINT " & itemtab(i)(0))
                treequipos.SelectedNode = treequipos.Nodes(treequipos.Nodes.Count - 1)
                Dim taborden As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
                & "id from tecni_taller where equipo=" & itemtab(i)(0), conexionPrinc)
                Dim leerorden As New DataTable
                Dim itemorden() As DataRow

                taborden.Fill(leerorden)
                itemorden = leerorden.Select()

                Dim j As Integer
                For j = 0 To itemorden.GetUpperBound(0)
                    treequipos.SelectedNode.Nodes.Add("OR " & itemorden(j)(0))
                Next
            Next
            cargaecli = True
        Catch ex As Exception
            cargaecli = True
        End Try
    End Sub

    Private Sub treequipos_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treequipos.AfterSelect
        Try
            If cargaecli = False Then Exit Sub
            Reconectar()
            Dim codigo As Integer
            Dim quitar() As Char = {"C", "O", "D", "I", "N", "T", " "}
            If InStr(treequipos.SelectedNode.Text, "CODINT ") <> 0 Then
                codigo = e.Node.Text.TrimStart(quitar)
            ElseIf InStr(e.Node.Text, "OR ") <> 0 Then
                codigo = e.Node.Parent.Text.TrimStart(quitar)
            End If
            Dim sqlquery As String = "select (select nomapell_razon from fact_clientes where idclientes=ecli.propietario) as cliente, " _
            & "ecli.especificaciones, ecli.serie, ecli.estado, " _
            & "(select concat(et.nombre,'/',ma.nombre,'/',mo.nombre) from tecni_equipos as eq, tecni_equipos_tipo as et, fact_marcas as ma, fact_modelos as mo  " _
            & "where eq.marca=ma.id and eq.modelo=mo.id and eq.tipo_equ=et.id and eq.id=ecli.modelo) as EQUIPO " _
            & "from tecni_equipos_clientes as ecli where ecli.id=" & codigo
            Dim consespec As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlquery, conexionPrinc)
            Dim tabespec As New DataTable
            Dim itemespec() As DataRow

            consespec.Fill(tabespec)
            itemespec = tabespec.Select()
            eclipropietario.Text = itemespec(0)(0)
            ecliequipo.Text = itemespec(0)(4)
            ecliserie.Text = itemespec(0)(2)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub treequipos_DoubleClick(sender As Object, e As EventArgs) Handles treequipos.DoubleClick
        Dim i As Integer
        For i = 0 To frmprincipal.MdiChildren.Length - 1
            If frmprincipal.MdiChildren(i).Name = "fichaequipo" Then
                frmprincipal.MdiChildren(i).BringToFront()
                CType(frmprincipal.ActiveMdiChild, fichaequipo).lblalerta.Visible = True
                Exit Sub
            End If
        Next
        Dim codigo As Integer
        Dim quitar() As Char = {"O", "R", " "}
        If InStr(treequipos.SelectedNode.Text, "OR ") <> 0 Then
            codigo = treequipos.SelectedNode.Text.TrimStart(quitar)
        End If
        Dim fichequ As New fichaequipo
        fichequ.MdiParent = Me.MdiParent
        fichequ.ORden = codigo
        fichequ.cmdfinalizar.Enabled = False
        fichequ.txtinfoextra.ReadOnly = False
        fichequ.Show()
    End Sub
    Private Sub TabPage1_Enter1(sender As Object, e As EventArgs) Handles TabPage1.Enter
        CargarTipoEq_falla()

    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        cargarMarcas_falla(e.Node.Tag)
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub dtcloud_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtcloud.CellContentClick

    End Sub
End Class