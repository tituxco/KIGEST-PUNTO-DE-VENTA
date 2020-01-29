Public Class ingresoequipo
    Dim fecha As String = Format(Now, "dd-MMMM-yyyy")
    Private Sub ingresoequipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblfecha.Text = "Fecha: " & fecha
        CargarCategoriastrab()
        CargarTipoEquipo()
        cargarMarcas()
        CargarUsuarios()
    End Sub
    Private Sub VaciarInfoclie(ByRef llamador As Control)
        Try
            For Each Cont As Control In panelcliente.Controls
                If TypeOf Cont Is TextBox And TypeOf llamador Is TextBox Then
                    Dim tex As TextBox
                    tex = Cont
                    If llamador.Name <> tex.Name Then
                        tex.Text = ""
                    End If
                ElseIf TypeOf Cont Is ComboBox And TypeOf llamador Is ComboBox Then
                    Dim cbo As ComboBox
                    cbo = Cont
                    If llamador.Name <> cbo.Name Then
                        cbo.SelectedIndex = -1

                    End If

                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub VaciarInfoEquipo()
        Try
            For Each Cont As Control In panelequipo.Controls
                If TypeOf Cont Is TextBox Then
                    Dim tex As TextBox
                    tex = Cont
                    tex.Text = ""

                ElseIf TypeOf Cont Is ComboBox Then
                    Dim cbo As ComboBox
                    cbo = Cont
                    cbo.SelectedIndex = -1
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function ComprobarInformación() As Boolean
        Try
            If cmbcattrab.SelectedValue <= 0 Then
                MsgBox("Debe seleccionar una categoria de trabajo")
                Return False
            End If
            If txtctaclie.Text.Trim = "" Or txtrazon.Text.Trim = "" Then
                MsgBox("Debe ingresar la informacion del cliente")
                Return False
            End If

            If cmbcattrab.SelectedValue = 4 And txtinfoextra.Text.Trim = "" Then
                MsgBox("Debe ingrsar informacion extra de contacto")
                Return False
            End If

            If cmbtipoequ.Text.Trim = "" Or cmbmarcas.Text.Trim = "" Or cmbmodelos.Text.Trim = "" Then
                MsgBox("Debe ingresar información del equipo")
                Return False
            End If

            If txtmotivo.Text.Trim = "" Then
                MsgBox("Debe ingresar un motivo de ingreso")
                Return False
            End If

            If cmbtipoequ.Text = "" Or cmbmarcas.Text = "" Or cmbmodelos.Text = "" Then
                MsgBox("datos de equipo incorrectos")
                Return False
            End If

            If cmbrecibeusuario.Text = "" Or cmbrecibeusuario.SelectedValue = 0 Then
                MsgBox("Debe seleccionar la persona que recibe el equipo")
                Return False
            End If
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub CargarCategoriastrab()
        Reconectar()
        Dim tablacattrab As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from tecni_trabajo_categoria", conexionPrinc)
        Dim readcattrab As New DataSet
        tablacattrab.Fill(readcattrab)
        cmbcattrab.DataSource = readcattrab.Tables(0)
        cmbcattrab.DisplayMember = readcattrab.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbcattrab.ValueMember = readcattrab.Tables(0).Columns(0).Caption.ToString
        cmbcattrab.SelectedIndex = 0

    End Sub

    Private Sub CargarUsuarios()
        Reconectar()
        Dim tablausuarios As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,',',nombre) from cm_usuarios WHERE activo=1 ", conexionPrinc)
        Dim readusuarios As New DataSet
        tablausuarios.Fill(readusuarios)
        cmbrecibeusuario.DataSource = readusuarios.Tables(0)
        cmbrecibeusuario.DisplayMember = readusuarios.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbrecibeusuario.ValueMember = readusuarios.Tables(0).Columns(0).Caption.ToString
        cmbrecibeusuario.SelectedValue = DatosAcceso.UsuarioINT

    End Sub

    Private Sub cargarMarcas()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos marcas
            Dim tablamarca As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_marcas order by nombre asc", conexionPrinc)
            Dim readmarc As New DataSet
            tablamarca.Fill(readmarc)
            cmbmarcas.DataSource = readmarc.Tables(0)
            cmbmarcas.DisplayMember = readmarc.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbmarcas.ValueMember = readmarc.Tables(0).Columns(0).Caption.ToString
            cmbmarcas.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarModelos(ByRef marca As Integer)
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos marcas
            Dim tablamodelo As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_modelos where idmarca=" & marca & " order by nombre asc", conexionPrinc)
            Dim readmod As New DataSet
            tablamodelo.Fill(readmod)
            cmbmodelos.DataSource = readmod.Tables(0)
            cmbmodelos.DisplayMember = readmod.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbmodelos.ValueMember = readmod.Tables(0).Columns(0).Caption.ToString
            cmbmodelos.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub
    Public Sub cargarCliente()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cl.nomapell_razon as clie, cl.dir_domicilio, lc.nombre, " _
            & "concat(cl.telefono,'/',cl.celular), cl.email " _
            & " from fact_clientes as cl,  cm_localidad as lc where lc.id=cl.dir_localidad and  idclientes = " & txtctaclie.Text, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            txtrazon.Text = infocl(0)(0)
            txtdomicilio.Text = infocl(0)(1) & "(" & infocl(0)(2) & ") "
            txttelefono.Text = infocl(0)(3)
            txtmail.Text = infocl(0)(4)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CargarTipoEquipo()
        Try
            Reconectar()
            Dim tablatipoeq As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from tecni_equipos_tipo", conexionPrinc)
            Dim readtipoequ As New DataSet
            tablatipoeq.Fill(readtipoequ)
            cmbtipoequ.DataSource = readtipoequ.Tables(0)
            cmbtipoequ.DisplayMember = readtipoequ.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbtipoequ.ValueMember = readtipoequ.Tables(0).Columns(0).Caption.ToString
            cmbtipoequ.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub
    Public Sub CargarInfoEquipo(ByRef tipo As Integer)
        Try
            Dim busTXT As String
            If tipo = 1 Then
                busTXT = " and ecli.id=" & Val(txtcodint.Text)
            ElseIf tipo = 2 Then
                busTXT = " and ecli.serie like'" & txtnumeroSerie.Text.ToUpper & "'"
            End If
            'MsgBox(busTXT)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select et.id,ma.id,mo.id,ecli.serie " _
            & "from tecni_equipos_clientes as ecli, tecni_equipos as eq, tecni_equipos_tipo as et, fact_marcas as ma, fact_modelos as mo " _
            & "where ecli.modelo=eq.id and eq.tipo_equ=et.id and eq.marca=ma.id and eq.modelo=mo.id " & busTXT, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            cmbtipoequ.SelectedValue = infocl(0)(0)
            cmbmarcas.SelectedValue = infocl(0)(1)
            cmbmodelos.SelectedValue = infocl(0)(2)
            txtnumeroSerie.Text = infocl(0)(3)
            panelequipo.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbcattrab_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbcattrab.SelectedValueChanged
        Try
            If cmbcattrab.SelectedValue = 4 Then
                pninfoextra.Visible = True
            Else
                pninfoextra.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles txtrazon.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtrazon.Text.Trim = "" Then
                MsgBox("Debe ingresar un parametro de busqueda")
                Exit Sub

            End If
            selclie.busqueda = txtrazon.Text
            selclie.llama = "ingresoequipo"
            selclie.dtpersonal.Focus()
            selclie.Show()
            selclie.TopMost = True
        End If
    End Sub

    Private Sub txtrazon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrazon.KeyPress

    End Sub

    Private Sub txtrazon_KeyUp(sender As Object, e As KeyEventArgs) Handles txtrazon.KeyUp

    End Sub

    Private Sub txtctaclie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtctaclie.KeyDown
        VaciarInfoclie(txtctaclie)
        'VaciarInfoEquipo()
    End Sub


    Private Sub txtctaclie_KeyUp(sender As Object, e As KeyEventArgs) Handles txtctaclie.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                cargarCliente()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtctaclie_Leave(sender As Object, e As EventArgs) Handles txtctaclie.Leave
        cargarCliente()
    End Sub

    Private Sub txtcodint_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcodint.KeyDown
        'VaciarInfoEquipo()
    End Sub

    Private Sub txtcodint_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcodint.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If Val(txtctaclie.Text) = 0 And Val(txtcodint.Text) = 0 Then
                    MsgBox("Debe ingresar un numero de equipo")
                    Exit Sub
                ElseIf Val(txtctaclie.Text) <> 0 And Val(txtcodint.Text) = 0 Then
                    selequi.cliente = Val(txtctaclie.Text)
                    selequi.busqueda = Val(txtcodint.Text)
                    selequi.llama = "ingresoequipo"
                    selequi.dtequipos.Focus()
                    selequi.Show()
                    selequi.TopMost = True
                End If
                selequi.cliente = Val(txtctaclie.Text)
                selequi.busqueda = Val(txtcodint.Text)
                selequi.llama = "ingresoequipo"
                selequi.dtequipos.Focus()
                selequi.Show()
                selequi.TopMost = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdimprimir.Click
        Try

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
            & "and tall.id=" & Val(txtnumor.Text), conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("fichaIngreso"))

            Reconectar()
            tablaFacturacion.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select nombrefantasia, razonsocial, concat('Direccion: ',direccion,' - ',otrosdatos) as direccion, localidad, cuit, ingbrutos, ivatipo, inicioact, drei from fact_empresa where id=1", conexionPrinc)
            tablaFacturacion.Fill(dsFacturacion.Tables("datosEmpresa"))

            Dim imping As New imprimiringreso
            With imping
                .MdiParent = Me.MdiParent
                .rptingreso.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
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

    Private Sub cmbmarcas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbmarcas.SelectedValueChanged
        Try
            cargarModelos(cmbmarcas.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Try
            

            tmrComprobarOR.Enabled = False
            If ComprobarInformación() = False Then
                Exit Sub
            End If
            Dim tipotrab As Integer = cmbcattrab.SelectedValue
            Dim cliente As Integer = txtctaclie.Text
            Dim recibio As Integer = cmbrecibeusuario.SelectedValue
            Dim codint As Integer = Val(txtcodint.Text)

            Dim infoextra As String = txtinfoextra.Text.ToUpper & "-" & txtcasavendedora.Text.ToUpper

            Dim tipoeq As Integer = cmbtipoequ.SelectedValue
            Dim marca As Integer = cmbmarcas.SelectedValue
            Dim modelo As Integer = cmbmodelos.SelectedValue
            Dim serie As String = txtnumeroSerie.Text.ToUpper
            Dim equipo As Integer
            Dim numor As Integer = txtnumor.Text
            If tipoeq = 0 Then
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "insert into tecni_equipos_tipo(nombre) values ('" & cmbtipoequ.Text.ToUpper & "')"
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                tipoeq = sql.LastInsertedId
            End If

            If marca = 0 Then
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "insert into fact_marcas (nombre) values ('" & cmbmarcas.Text.ToUpper & "')"
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                marca = sql.LastInsertedId
            End If

            If modelo = 0 Then
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "insert into fact_modelos (idmarca, nombre) values ('" & marca & "','" & cmbmodelos.Text.ToUpper & "')"
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                modelo = sql.LastInsertedId
            End If

            Reconectar()
            Dim consultaeq As New MySql.Data.MySqlClient.MySqlDataAdapter("select id from tecni_equipos where marca=" & marca & " and modelo=" & modelo & " and tipo_equ=" & tipoeq, conexionPrinc)
            Dim tablaeq As New DataTable
            Dim infoeq() As DataRow
            consultaeq.Fill(tablaeq)
            If tablaeq.Rows.Count = 0 Then
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "insert into tecni_equipos (marca, modelo,tipo_equ) values ('" & marca & "','" & modelo & "','" & tipoeq & "')"
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                equipo = sql.LastInsertedId
            ElseIf tablaeq.Rows.Count > 1 Then
                'MsgBox("Hay mas de un modelo para la combinacion - " & tablaeq.Rows.Count)
                infoeq = tablaeq.Select("")
                equipo = infoeq(0)(0)
                'MsgBox(equipo)
            ElseIf tablaeq.Rows.Count = 1 Then
                infoeq = tablaeq.Select("")
                equipo = infoeq(0)(0)
                ' MsgBox(equipo)
            End If
            lblequipo.Text = equipo
            Dim accesorios As String
            Dim motivo As String = txtmotivo.Text.ToUpper
            Dim observaciones As String = txtobservaciones.Text.ToUpper


            If chkcaja.CheckState = CheckState.Checked Then accesorios &= chkcaja.Text & "-"
            If chkbateria.CheckState = CheckState.Checked Then accesorios &= chkbateria.Text & "-"
            If chkcables.CheckState = CheckState.Checked Then accesorios &= chkcables.Text & "-"
            If chkcargador.CheckState = CheckState.Checked Then accesorios &= chkcargador.Text & "-"

            accesorios &= txtaccesorios.Text
            Dim sqlQuery As String
            sqlQuery = "insert into tecni_taller (id,cliente,motivo_ing, accesorios,fecha_ing,modelo,serie,observaciones,trabajo_categoria,infoextra,recibe,equipo,mail,telefono) values " _
            & "(?id,?clie,?mot,?acc,?fing,?mod,?serie,?obs,?cat,?info,?recibe,?equipo,?mail,?tel)"
            Reconectar()
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?id", numor)
                .AddWithValue("?clie", cliente)
                .AddWithValue("?mot", motivo)
                .AddWithValue("?acc", accesorios)
                .AddWithValue("?fing", Format(Now, "yyyy-MM-dd"))
                .AddWithValue("?mod", equipo)
                .AddWithValue("?serie", serie)
                .AddWithValue("?obs", observaciones)
                .AddWithValue("?cat", tipotrab)
                .AddWithValue("?info", infoextra)
                .AddWithValue("?recibe", recibio)
                .AddWithValue("?equipo", codint)
                .AddWithValue("?mail", txtmail.Text.ToLower)
                .AddWithValue("?tel", txttelefono.Text)

            End With
            comandoadd.ExecuteNonQuery()
            MsgBox("Equipo ingresado a taller")
            cmdimprimir.Enabled = True
            cmdguardar.Enabled = False
            tecnico.refrescarTaller = False


            'enviar mail a la casilla
            Dim mail As String = "Estimado Cliente: " & txtrazon.Text & vbNewLine _
                                 & "Se ha ingresado un nuevo equipo con la ORDEN NUMERO: " & txtnumor.Text & vbNewLine _
                                 & "con la siguiente descripción: " & cmbtipoequ.Text & "-" & cmbmarcas.Text & "-" & cmbmodelos.Text & " Serie: " & txtnumeroSerie.Text.ToUpper & vbNewLine _
                                 & "a la brevedad estaremos revisando el equipo y nos comunicaremos por este medio para informarle el progreso del mismo" & vbNewLine _
                                 & "si ud desea consultar por el estado o hacer una consulta, simplemente haga clic en responder a este mensaje " & vbNewLine & vbNewLine _
                                 & "Atte. el equipo tecnico de KIBIT Informática" & vbNewLine _
                                 & "San Martin 142 - Reconquista -  Santa fe" & vbNewLine _
                                 & "03482-427888 | 3482-621473"
            Dim para As String = txtmail.Text.ToLower
            Dim asunto As String = "Ingreso equipo OR:" & txtnumor.Text & txtrazon.Text & "(" & txtinfoextra.Text & ")"
            If chkenviamail.Checked = True Then
                EnviarMail(mail, para, asunto)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub tmrComprobarOR_Tick(sender As Object, e As EventArgs) Handles tmrComprobarOR.Tick
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select max(id) from tecni_taller", conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            If Not IsDBNull(infocl(0)(0)) Then
                txtnumor.Text = infocl(0)(0) + 1
            Else
                txtnumor.Text = "1"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbtipoequ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtipoequ.SelectedIndexChanged

    End Sub

    Private Sub cmbmarcas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmarcas.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If cmbtipoequ.SelectedValue <> 0 And cmbmarcas.SelectedValue <> 0 And cmbmodelos.SelectedValue <> 0 Then
                lblcodexistente.Text = ""
                Dim sqlQuery As String = "select id from tecni_equipos where " _
                & "marca=" & cmbmarcas.SelectedValue & " and tipo_equ= " & cmbtipoequ.SelectedValue & " and modelo=" & cmbmodelos.SelectedValue
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlQuery, conexionPrinc)
                Dim tablaequ As New DataTable
                Dim infoequ() As DataRow
                consulta.Fill(tablaequ)
                infoequ = tablaequ.Select("")
                If infoequ.Count <> 0 Then
                    lblequipo.Text = infoequ(0)(0)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtnumeroSerie_Validated(sender As Object, e As EventArgs) Handles txtnumeroSerie.Validated
        Try
            If txtnumeroSerie.Text = "" Then
                Exit Sub
            End If
            lblcodexistente.Text = ""
            Dim sqlQuery As String = "select id from tecni_equipos_clientes where serie like '" & txtnumeroSerie.Text & "'"
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlQuery, conexionPrinc)
            Dim tablaequ As New DataTable
            Dim infoequ() As DataRow
            consulta.Fill(tablaequ)
            infoequ = tablaequ.Select("")
            If infoequ.Count <> 0 Then
                Timer1.Enabled = True
                lblcodexistente.Text = "COD. EXISTENTE:" & infoequ(0)(0)
            Else
                Timer1.Enabled = False
                lblcodexistente.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If lblcodexistente.Visible = True Then
            lblcodexistente.Visible = False
        Else
            lblcodexistente.Visible = True
        End If
    End Sub

    Private Sub cmbmodelos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbmodelos.SelectionChangeCommitted
        
    End Sub

    Private Sub txtcodint_TabStopChanged(sender As Object, e As EventArgs) Handles txtcodint.TabStopChanged

    End Sub

    Private Sub txtcodint_TextChanged(sender As Object, e As EventArgs) Handles txtcodint.TextChanged

    End Sub

    Private Sub txtctaclie_TextChanged(sender As Object, e As EventArgs) Handles txtctaclie.TextChanged

    End Sub

    Private Sub txtrazon_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtrazon_TextChanged_1(sender As Object, e As EventArgs) Handles txtrazon.TextChanged

    End Sub

    Private Sub chkenviamail_CheckedChanged(sender As Object, e As EventArgs) Handles chkenviamail.CheckedChanged

    End Sub

    Private Sub txtnumeroSerie_TextChanged(sender As Object, e As EventArgs) Handles txtnumeroSerie.TextChanged

    End Sub

    Private Sub txtnumor_TextChanged(sender As Object, e As EventArgs) Handles txtnumor.TextChanged

    End Sub

    Private Sub txtnumor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumor.KeyPress

    End Sub

    Private Sub txtnumor_DoubleClick(sender As Object, e As EventArgs) Handles txtnumor.DoubleClick

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label5_DoubleClick(sender As Object, e As EventArgs) Handles Label5.DoubleClick
        tmrComprobarOR.Enabled = False

        txtnumor.ReadOnly = False
    End Sub
End Class