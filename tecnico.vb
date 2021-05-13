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



    Private Sub cmdingresataller_Click(sender As Object, e As EventArgs)
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
    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs)
        Me.Close()
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            cargaecli = False
            treequipos.Nodes.Clear()
            Reconectar()
            Dim consulta As String = ""
            If rdequiposclieCliente.Checked = True Then
                consulta = " clie.nomapell_razon like '%" & txtequiposclieBusqueda.Text.Replace(" ", "%") & "%'"
            End If

            If rdequiposclieCodInt.Checked = True Then
                consulta = "  ECli.id like '" & txtequiposclieBusqueda.Text & "'"
            End If

            If rdequiposlclieSerie.Checked = True Then
                consulta = " ECli.serie like '" & txtequiposclieBusqueda.Text & "'"
            End If

            Dim tabla As New MySql.Data.MySqlClient.MySqlDataAdapter("select ECli.id, clie.nomapell_razon, 
            (select concat(et.nombre,'/',ma.nombre,'/',mo.nombre) 
		    from tecni_equipos as eq, tecni_equipos_tipo as et, fact_marcas as ma, fact_modelos as mo  
		    where eq.marca=ma.id and eq.modelo=mo.id and eq.tipo_equ=et.id and eq.id=ECli.modelo) as EQUIPO, 
            ECli.serie as SERIE,
            (select count(*) from tecni_taller where equipo=ECli.id)
            from tecni_equipos_clientes as ECli, fact_clientes as clie 
            where clie.idclientes=ECli.propietario and " & consulta, conexionPrinc)
            'MsgBox(tabla.SelectCommand.CommandText)
            Dim leertab As New DataTable
            Dim itemtab() As DataRow
            tabla.Fill(leertab)
            itemtab = leertab.Select()
            Dim i As Integer
            For i = 0 To itemtab.GetUpperBound(0)
                treequipos.Nodes.Add("(" & itemtab(i)(0) & ") " & itemtab(i)(2)).tag = itemtab(i)(0)

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
        CargarMarcas_falla(e.Node.Tag)
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer
        For i = 0 To frmprincipal.MdiChildren.Length - 1
            If frmprincipal.MdiChildren(i).Name = "fichaequipo" Then
                frmprincipal.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim ingequ As New fichaequipo
        ingequ.MdiParent = Me.MdiParent
        ingequ.Show()
    End Sub

    Private Sub Panel12_Paint(sender As Object, e As PaintEventArgs) Handles Panel12.Paint

    End Sub

    Private Sub treequipos_Click(sender As Object, e As EventArgs) Handles treequipos.Click
        Try
            If cargaecli = False Then Exit Sub
            Reconectar()
            Dim codigo As Integer
            'Dim quitar() As Char = {"C", "O", "D", "I", "N", "T", " "}
            'If InStr(treequipos.SelectedNode.Text, "CODINT ") <> 0 Then
            '    codigo = e.Node.Text.TrimStart(quitar)
            'ElseIf InStr(e.Node.Text, "OR ") <> 0 Then
            '    codigo = e.Node.Parent.Text.TrimStart(quitar)
            'End If

            codigo = treequipos.SelectedNode.Tag
            Dim sqlquery As String = "select (select nomapell_razon from fact_clientes where idclientes=ecli.propietario) as cliente, " _
            & "ecli.especificaciones, ecli.serie, ecli.estado, " _
            & "(select concat(et.nombre,'/',ma.nombre,'/',mo.nombre) from tecni_equipos as eq, tecni_equipos_tipo as et, fact_marcas as ma, fact_modelos as mo  " _
            & "where eq.marca=ma.id and eq.modelo=mo.id and eq.tipo_equ=et.id and eq.id=ecli.modelo) as EQUIPO " _
            & "from tecni_equipos_clientes as ecli where ecli.id=" & codigo

            Dim consespec As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlquery, conexionPrinc)
            Dim tabespec As New DataTable
            Dim itemespec() As DataRow

            'MsgBox(consespec.SelectCommand.CommandText)
            consespec.Fill(tabespec)
            itemespec = tabespec.Select()
            eclipropietario.Text = itemespec(0)(0)
            ecliequipo.Text = itemespec(0)(4)
            ecliserie.Text = itemespec(0)(2)
            txtespecificaciones.Text = itemespec(0)(1)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub txtequiposclieBusqueda_KeyUp(sender As Object, e As KeyEventArgs) Handles txtequiposclieBusqueda.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdbuscar.PerformClick()
        End If
    End Sub
End Class