Imports System
Imports System.IO
Imports System.Collections
Public Class empleados
    Dim Idpersonal As String
    Dim modificarPers As Boolean
    Dim agregarPers As Boolean

    Dim pag As Integer
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Dim idsub As String

    Dim Printenca As Boolean = True
    Dim printExp As Boolean = True
    Dim printForm As Boolean = True
    Dim printCurs As Boolean = True
    Dim printExtra As Boolean = True

    Dim ValorPosicionTab As Integer = 0


    Public Sub CargarPersonal()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select idpersonal as IDPers, concat(apellidos,', ', nombre) as Personal from sdo_personal", conexionPrinc)
            Dim tablaPers As New DataTable
            'Dim ds As New DataSet

            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            consulta.Fill(tablaPers)
            dtpersonal.DataSource = tablaPers
            'dtpersonal.Columns(2).Visible = False
            'dtpersonal.Columns(0).Visible = False
        Catch ex As Exception
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
    End Sub

    Private Sub vaciarControles()
        txtnombres.Text = ""
        txtapellido.Text = ""
        txtdocumento.Text = ""
        txtdomicilio.Text = ""
        txttelefono.Text = ""
    End Sub

    Private Sub CargarInfoPers()
        Dim imag As Byte()
        Dim idcat As String
        'pbprogresocons.Visible = True
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim lector2 As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            Dim sql2 As New MySql.Data.MySqlClient.MySqlCommand

            conexionPrinc.ChangeDatabase(database)
            '   conexionprinc.ChangeDatabase(EmpDB)
            sql.Connection = conexionPrinc

            sql.CommandText = "select legajo, nombre, apellidos,doc_tipo, doc_num, fecha_nac, genero,nacionalidad, num_telefono, " _
            & "num_emergencia, num_celular, email, domicilio, localidad, provincia, estado_civil, categoria, calif_categoria, " _
            & "cuil,fecha_ingreso, fecha_baja, direccion_alt, cuil, modo_contr, jornada, convenio, aportebanco, aportefecha, aporteperiodo, " _
            & "sueldobanco, sueldocuenta, lugarpago from sdo_personal where idpersonal=" & Idpersonal

            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            '***********************************DATOS PERSONALES*********************************************

            txtnombres.Text = lector("nombre").ToString
            txtapellido.Text = lector("apellidos").ToString
            cmbtipodoc.SelectedValue = lector("doc_tipo").ToString
            txtdocumento.Text = lector("doc_num").ToString
            dtpfechanac.Value = lector("fecha_nac").ToString
            cmbnacionalidad.SelectedValue = lector("nacionalidad").ToString
            txttelefono.Text = lector("num_telefono").ToString
            txtcelular.Text = lector("num_celular").ToString
            txtmail.Text = lector("email").ToString
            txtdomicilio.Text = lector("domicilio").ToString
            cmbestadocivil.SelectedValue = lector("estado_civil").ToString
            cmbgenero.SelectedValue = lector("genero").ToString
            cmblocalidad.SelectedValue = lector("localidad").ToString
            cmbprovincia.SelectedValue = lector("provincia").ToString
            dtpaltacurr.Value = lector("fecha_ingreso").ToString
            lbledad.Text = DateDiff(DateInterval.Year, dtpfechanac.Value, Date.Today) & " años"
            'txtobservaciones.Text = lector("observaciones").ToString
            txtdiralt.Text = lector("direccion_alt").ToString
            txtcuil.Text = lector("cuil").ToString
            'txtsueldoacord.Text = lector("sueldo_acord").ToString
            cmbcentro_costos.SelectedValue = lector("convenio").ToString
            cmbjornada.SelectedValue = lector("jornada").ToString
            cmbmodocontratacion.SelectedValue = lector("modo_contr").ToString
            cmbcategoria.SelectedValue = lector("categoria").ToString
            txtbancoaportes.Text = lector("aportebanco").ToString
            txtbancohaberes.Text = lector("sueldobanco").ToString
            txtcuentahaberes.Text = lector("sueldocuenta").ToString
            txtperiodoaportes.Text = lector("aporteperiodo").ToString
            dtpfechaaportes.Value = lector("aportefecha").ToString
            txtlugarpago.Text = lector("lugarpago").ToString
            'pbprogresocons.Visible = False
        Catch ex As Exception
            ' pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try

    End Sub

    Private Sub dtpersonal_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtpersonal.CellEnter
        Idpersonal = dtpersonal.CurrentRow.Cells.Item(0).Value
        CargarInfoPers() 'numerofich = dtpersonal.CurrentRow.Cells.Item(2).Value
        dtvresumen.DataSource = Nothing
        If TabControl1.SelectedIndex = 1 Then
            CargarPlanilla()
        End If
        CargarInfoPers()
    End Sub

    Private Sub cmdmodificar_Click(sender As Object, e As EventArgs) Handles cmdmodificar.Click
        cmdaceptar.Visible = True
        cmdnuevapers.Enabled = False
        cmdeliminar.Enabled = False
        cmdcancelar.Visible = True
        dtpersonal.Enabled = False
        modificarPers = True
    End Sub

    Private Sub cmdnuevapers_Click(sender As Object, e As EventArgs) Handles cmdnuevapers.Click
        cmdmodificar.Enabled = False
        cmdeliminar.Enabled = False
        cmdaceptar.Visible = True
        cmdcancelar.Visible = True
        vaciarControles()
        cargarDtosGrales()
        modificarPers = False
        pctfoto.Image = Image.FromFile(Application.StartupPath & "\sinimagen.jpg")
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        cmdmodificar.Enabled = True
        cmdnuevapers.Enabled = True
        cmdeliminar.Enabled = True
        cmdcancelar.Visible = False
        cmdaceptar.Visible = False
        modificarPers = False
    End Sub

    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
        Dim sqlQuery As String
        Dim nombres As String
        Dim apellido As String
        Dim tipodoc As Integer
        Dim nodocumento As String
        Dim fechanac As String
        Dim genero As Integer
        Dim nacionalidad As String
        Dim telefono As String
        Dim celular As String
        Dim fcurriculum As String
        Dim mail As String
        Dim domicilio As String
        Dim localidad As Integer
        Dim provincia As Integer
        Dim convenio As Integer
        Dim estadocivil As Integer

        Dim dir_alt As String
        Dim cuil As String
        Dim categoria As Integer
        Dim sueldoBase As String
        Dim modo_contratacion As Integer
        Dim jornada As Integer
        Dim sueldoAcord As String
        Dim foto As Byte()
        Dim aportebanco As String
        Dim aportefecha As String
        Dim aporteperiodo As String
        Dim sueldobanco As String
        Dim sueldocuenta As String
        Dim lugarpago As String
        '  pbprogresocons.Visible = True

        Reconectar()

        Try
            foto = Imagen_Bytes(pctfoto.Image)
            nombres = txtnombres.Text.ToUpper
            apellido = txtapellido.Text.ToUpper
            tipodoc = cmbtipodoc.SelectedValue
            nodocumento = txtdocumento.Text
            fechanac = Format(dtpfechanac.Value, "yyyy-MM-dd")
            If cmbgenero.SelectedValue = 0 Then
                MsgBox("debe seleccionar un genero")
                Exit Sub
            End If
            genero = cmbgenero.SelectedValue
            nacionalidad = cmbnacionalidad.SelectedValue
            telefono = txttelefono.Text
            celular = txtcelular.Text
            fcurriculum = Format(dtpaltacurr.Value, "yyyy-MM-dd")
            mail = txtmail.Text.ToLower
            domicilio = txtdomicilio.Text.ToUpper
            localidad = cmblocalidad.SelectedValue
            If cmbprovincia.SelectedValue = 0 Then
                MsgBox("Debe seleccionar una provincia")
                Exit Sub
            End If
            provincia = cmbprovincia.SelectedValue

            If cmbestadocivil.SelectedValue = 0 Then
                MsgBox("debe seleccionar un estado civil")
                Exit Sub
            End If
            estadocivil = cmbestadocivil.SelectedValue

            dir_alt = txtdiralt.Text.ToUpper
            cuil = txtcuil.Text

            categoria = cmbcategoria.SelectedValue
            sueldoBase = txtsueldoBase.Text
            modo_contratacion = cmbmodocontratacion.SelectedValue
            jornada = cmbjornada.SelectedValue
            convenio = cmbcentro_costos.SelectedValue
            aportebanco = txtbancoaportes.Text.ToUpper
            aportefecha = dtpfechaaportes.Text
            aporteperiodo = txtperiodoaportes.Text.ToUpper
            sueldobanco = txtbancohaberes.Text.ToUpper
            sueldocuenta = txtcuentahaberes.Text.ToUpper
            lugarpago = txtlugarpago.Text.ToUpper
            'sueldoAcord = txtsueldoacord.Text
            If comprobarCamposObligatorios() = True Then
                MsgBox("Hay campos obligatorios que no fueron completados, por favor verifique")
                Exit Sub
            End If
            Reconectar()

            'verificamos los combos seleccionados, si no se selecciono ninguno, lo agregamos

            If nacionalidad = 0 Then
                'MsgBox("no se selecciono nacionalidad, se agregara")
                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_nacionalidad (nombre) values('" & cmbnacionalidad.Text.ToUpper & "')"
                comando.ExecuteReader()
                nacionalidad = comando.LastInsertedId
            End If
            Reconectar()

            If localidad = 0 Then
                'MsgBox("no se selecciono localidad, se agregara")
                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_localidad (nombre) values('" & cmblocalidad.Text.ToUpper & "')"
                comando.ExecuteReader()
                localidad = comando.LastInsertedId
            End If
            Reconectar()

            If estadocivil = 0 Then
                'MsgBox("No se selecciono estado civil")
                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_estado_civil(nombre) values ('" & cmbestadocivil.Text.ToUpper & "')"
                comando.ExecuteReader(3)
                estadocivil = comando.LastInsertedId
            End If
            Reconectar()

            If cmbcentro_costos.Text = "" And cmbcategoria.Text = "" Then
                MsgBox("debe ingresar o seleccionar un convenio y una categoria")
                Exit Sub
            ElseIf cmbcentro_costos.Text = "" And cmbcategoria.Text <> "" Then
                MsgBox("debe ingresar o seleccionar un convenio")
                Exit Sub
            ElseIf cmbcentro_costos.Text <> "" And cmbcategoria.Text = "" Then
                MsgBox("debe ingresar o seleccionar una categoria")
                Exit Sub
            ElseIf convenio = 0 And categoria = 0 Then
                'msgbox("No se selecciono categoria")
                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_sdo_convenios(nombre) values ('" & cmbcentro_costos.Text.ToUpper & "')"
                comando.ExecuteReader()
                convenio = comando.LastInsertedId

                Reconectar()

                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_sdo_categoria_personal(nombre,idconvenio) values ('" & cmbcategoria.Text.ToUpper & "','" & convenio & "')"
                comando.ExecuteReader()
                categoria = comando.LastInsertedId
            ElseIf convenio <> 0 And categoria = 0 Then

                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_sdo_categoria_personal(nombre,idconvenio) values ('" & cmbcategoria.Text.ToUpper & "','" & convenio & "')"
                comando.ExecuteReader()
                categoria = comando.LastInsertedId
            End If
            If categoria = 0 Or convenio = 0 Then
                MsgBox("No hay categoria o convenio seleccionado o ingresado")
                Exit Sub
            End If

            If modificarPers = False Then
                If ComprobarAspirante(nodocumento) = False Then
                    MsgBox("Ya existe un aspirante con este numero de documento, por favor verifique")
                    Exit Sub
                End If
                sqlQuery = "insert into sdo_personal " _
                & "(nombre, apellidos, genero, doc_tipo, doc_num, fecha_nac, nacionalidad, num_telefono, num_celular, email, domicilio, localidad, " _
                & "provincia, estado_civil, fecha_ingreso,direccion_alt, cuil, categoria, modo_contr, jornada,convenio,empresa, aportebanco, " _
                & "aportefecha, aporteperiodo,sueldobanco, sueldocuenta, lugarpago) values " _
                & "(?nomb, ?ape, ?gen,?dt,?dn,?fn,?nac,?nt,?nc,?mail,?dom,?loc,?pro,?ec,?ac,?dalt,?cuil,?categ,?modocont,?jornada,?convenio, " _
                & "?empresa,?apbanco, ?apfecha, ?apperiodo, ?sdobanco, ?sdocuenta,?lugarpago)"
            ElseIf modificarPers = True Then
                sqlQuery = "update sdo_personal set nombre=?nomb, apellidos=?ape, genero=?gen, doc_tipo=?dt, doc_num=?dn, fecha_nac=?fn, " _
                    & "nacionalidad=?nac, num_telefono=?nt, num_celular=?nc, email=?mail, domicilio=?dom, localidad=?loc, provincia=?pro," _
                    & "estado_civil=?ec, fecha_ingreso=?ac, direccion_alt=?dalt, cuil=?cuil, categoria=?categ, " _
                    & "jornada=?jornada,modo_contr=?modocont, convenio=?convenio,  " _
                    & "aportebanco=?apbanco, aportefecha=?apfecha, aporteperiodo=?apperiodo, sueldobanco=?sdobanco, sueldocuenta=?sdocuenta,  " _
                    & "lugarpago=?lugarpago where idpersonal=?idp"
            End If
            Reconectar()

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)

            With comandoadd.Parameters
                .AddWithValue("?nomb", nombres)
                .AddWithValue("?ape", apellido)
                .AddWithValue("?gen", genero)
                .AddWithValue("?dt", tipodoc)
                .AddWithValue("?dn", nodocumento)
                .AddWithValue("?fn", fechanac)
                .AddWithValue("?nac", nacionalidad)
                .AddWithValue("?nt", telefono)
                .AddWithValue("?nc", celular)
                .AddWithValue("?mail", mail)
                .AddWithValue("?dom", domicilio)
                .AddWithValue("?loc", localidad)
                .AddWithValue("?pro", provincia)
                .AddWithValue("?ec", estadocivil)
                .AddWithValue("?cuil", cuil)
                .AddWithValue("?ac", fcurriculum)
                .AddWithValue("?categ", categoria)
                .AddWithValue("?modocont", modo_contratacion)
                .AddWithValue("?dalt", dir_alt)
                .AddWithValue("?jornada", jornada)
                .AddWithValue("?convenio", convenio)
                .AddWithValue("?empresa", 1)
                .AddWithValue("?apbanco", aportebanco)
                .AddWithValue("?apfecha", aportefecha)
                .AddWithValue("?apperiodo", aporteperiodo)
                .AddWithValue("?sdobanco", sueldobanco)
                .AddWithValue("?sdocuenta", sueldocuenta)
                .AddWithValue("?lugarpago", lugarpago)
                If modificarPers = True Then
                    .AddWithValue("?idp", Idpersonal)
                End If
            End With
            comandoadd.ExecuteNonQuery()

            If modificarPers = True Then
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Personal Modificado correctamente"
                TabControl1.SelectedTab = TabPage1
                dtpersonal.Enabled = False
            ElseIf modificarPers = False Then
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Personal agregado correctamente"
                CargarPersonal()
                Idpersonal = comandoadd.LastInsertedId
                Dim i As Integer
                For i = 0 To dtpersonal.Rows.Count - 1
                    If dtpersonal.Item(0, i).Value = Idpersonal Then
                        dtpersonal.Rows(i).Selected = True
                    End If
                Next
                CargarInfoPers()
                dtpersonal.Enabled = False
            End If
            'pbprogresocons.Visible = False
        Catch ex As Exception
            'pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
        cargarDtosGrales()
        modificarPers = False
        cmdmodificar.Enabled = True
        cmdnuevapers.Enabled = True
        cmdaceptar.Enabled = False
        dtpersonal.Enabled = True
        lblestado.Text = ""
        deshabilitarControles(Me)
    End Sub

    Private Sub cargarDtosGrales()
        'pbprogresocons.Visible = True
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            'conexionprinc.ChangeDatabase(EmpDB)
            Dim tablaestadoC As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_estado_civil order by nombre asc", conexionPrinc)
            Dim tablatipoDoc As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_doc_tipo order by nombre asc", conexionPrinc)
            Dim tablagenero As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_genero order by nombre asc", conexionPrinc)
            Dim tablanacionalidad As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_nacionalidad order by nombre asc", conexionPrinc)
            Dim tablalocalidad As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_localidad order by nombre asc", conexionPrinc)
            Dim tablaprovincia As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_provincias order by nombre asc", conexionPrinc)
            Dim tablaCARNET As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_tipo_carnet order by nombre asc", conexionPrinc)
            Dim tablaGrsang As New MySql.Data.MySqlClient.MySqlDataAdapter("select distinct(gr_sang) from sdo_personal", conexionPrinc)
            Dim tablaCatTra As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_categoria_personal", conexionPrinc)
            Dim tablaModocontr As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_modo_contratacion", conexionPrinc)
            Dim tablaJornada As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_jornada", conexionPrinc)
            Dim tablacostos As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from cm_sdo_convenios", conexionPrinc)
            Dim readcostos As New DataSet
            Dim readjornada As New DataSet
            Dim readmodoContr As New DataSet
            Dim readcatTR As New DataSet
            Dim readGS As New DataSet
            Dim reades As New DataSet
            Dim readtd As New DataSet
            Dim readg As New DataSet
            Dim readn As New DataSet
            Dim readloc As New DataSet
            Dim readpro As New DataSet
            Dim readcar As New DataSet


            'cargamos estado civil
            tablaestadoC.Fill(reades)
            cmbestadocivil.DataSource = reades.Tables(0)
            cmbestadocivil.DisplayMember = reades.Tables(0).Columns(1).Caption.ToString
            cmbestadocivil.ValueMember = reades.Tables(0).Columns(0).Caption.ToString
            cmbestadocivil.SelectedIndex = -1

            'cargamos tipos de documentos
            tablatipoDoc.Fill(readtd)
            cmbtipodoc.DataSource = readtd.Tables(0)
            cmbtipodoc.DisplayMember = readtd.Tables(0).Columns(1).Caption.ToString
            cmbtipodoc.ValueMember = readtd.Tables(0).Columns(0).Caption.ToString
            cmbtipodoc.SelectedIndex = -1

            'cargamos generos
            tablagenero.Fill(readg)
            cmbgenero.DataSource = readg.Tables(0)
            cmbgenero.DisplayMember = readg.Tables(0).Columns(1).Caption.ToString
            cmbgenero.ValueMember = readg.Tables(0).Columns(0).Caption.ToString
            cmbgenero.SelectedIndex = -1

            'cargamos nacionalidad
            tablanacionalidad.Fill(readn)
            cmbnacionalidad.DataSource = readn.Tables(0)
            cmbnacionalidad.DisplayMember = readn.Tables(0).Columns(1).Caption.ToString
            cmbnacionalidad.ValueMember = readn.Tables(0).Columns(0).Caption.ToString
            cmbnacionalidad.SelectedIndex = -1

            'cargamos localidades
            tablalocalidad.Fill(readloc)
            cmblocalidad.DataSource = readloc.Tables(0)
            cmblocalidad.DisplayMember = readloc.Tables(0).Columns(1).Caption.ToString
            cmblocalidad.ValueMember = readloc.Tables(0).Columns(0).Caption.ToString
            cmblocalidad.SelectedIndex = -1

            'cargamos provincias
            tablaprovincia.Fill(readpro)
            cmbprovincia.DataSource = readpro.Tables(0)
            cmbprovincia.DisplayMember = readpro.Tables(0).Columns(1).Caption.ToString
            cmbprovincia.ValueMember = readpro.Tables(0).Columns(0).Caption.ToString
            cmbprovincia.SelectedIndex = -1
            'pbprogresocons.Visible = False



            'cargamos modo de contratacion o periodo de pago
            tablaModocontr.Fill(readmodoContr)
            cmbmodocontratacion.DataSource = readmodoContr.Tables(0)
            cmbmodocontratacion.DisplayMember = readmodoContr.Tables(0).Columns(1).Caption.ToString
            cmbmodocontratacion.ValueMember = readmodoContr.Tables(0).Columns(0).Caption.ToString
            cmbmodocontratacion.SelectedIndex = -1

            'cargamos jornada contratada
            tablaJornada.Fill(readjornada)
            cmbjornada.DataSource = readjornada.Tables(0)
            cmbjornada.DisplayMember = readjornada.Tables(0).Columns(1).Caption.ToString
            cmbjornada.ValueMember = readjornada.Tables(0).Columns(0).Caption.ToString
            cmbjornada.SelectedIndex = -1

            'cargamos centro de costos
            tablacostos.Fill(readcostos)
            cmbcentro_costos.DataSource = readcostos.Tables(0)
            cmbcentro_costos.DisplayMember = readcostos.Tables(0).Columns(1).Caption.ToString
            cmbcentro_costos.ValueMember = readcostos.Tables(0).Columns(0).Caption.ToString
            cmbcentro_costos.SelectedIndex = -1

            'pbprogresocons.Visible = False
        Catch ex As Exception
            'pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try

    End Sub
    Private Function ComprobarAspirante(ByRef doc_num As String) As Boolean
        'pbprogresocons.Visible = True
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            Dim i As Integer = 0
            conexionPrinc.ChangeDatabase(database)
            sql.Connection = conexionPrinc
            sql.CommandText = "select idpersonal from sdo_personal where doc_num like '" & doc_num & "'"
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            While lector.Read()
                i += 1
            End While
            If i <> 0 Then
                Return False
            Else
                Return True
            End If
            'cerrar_Conexiones()
            'pbprogresocons.Visible = False
        Catch ex As Exception

            'pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try

    End Function

    Private Sub deshabilitarControles(ByVal thisform As System.Windows.Forms.Form)
        For Each Cont As Control In TabPage1.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                If tex.ReadOnly = True Then
                    tex.ReadOnly = False
                Else
                    tex.ReadOnly = True
                End If

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                If cbo.Enabled = False Then
                    cbo.Enabled = True
                Else
                    cbo.Enabled = False
                End If
            End If
        Next
        For Each Cont As Control In TabPage2.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                If tex.ReadOnly = True Then
                    tex.ReadOnly = False
                Else
                    tex.ReadOnly = True
                End If

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                If cbo.Enabled = False Then
                    cbo.Enabled = True
                Else
                    cbo.Enabled = False
                End If
            End If
        Next
    End Sub

    Private Function comprobarCamposObligatorios() As Boolean
        If txtnombres.Text = "" Then Return True
        If txtapellido.Text = "" Then Return True
        If txtdocumento.Text = "" Then Return True
        'If cmbgenero.Text = "" Then Return True
        'If cmbestadocivil.Text = "" Then Return True
        'If txtdomicilio.Text = "" Then Return True
        'If cmblocalidad.Text = "" Then Return True
    End Function

    Private Sub configuraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDtosGrales()
        CargarPersonal()
        dtpde.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
        dtptotalde.Value = CDate("01-" & Month(Now) & "-" & Year(Now))
    End Sub

    Private Sub TabPage2_DragOver(sender As Object, e As DragEventArgs) Handles TabPage2.DragOver

    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        CargarPlanilla()
    End Sub
    Private Sub dtpde_ValueChanged(sender As Object, e As EventArgs) Handles dtpde.ValueChanged
        CargarPlanilla()
    End Sub

    Private Sub dtphasta_ValueChanged(sender As Object, e As EventArgs) Handles dtphasta.ValueChanged
        CargarPlanilla()

    End Sub
    Private Sub CargarPlanilla()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id, ingreso_fech as FIngreso, ingreso_hor as HoraIng, egreso_fech as FEgreso, egreso_hor as HoraEgr, " _
            & "TIMEDIFF(concat(egreso_fech, ' ', egreso_hor),concat(ingreso_fech,' ', ingreso_hor)) as HorasTrab " _
            & "from empl_registros where ingreso_fech between '" & Format(dtpde.Value, "yyyy-MM-dd") & "' and '" & Format(dtphasta.Value, "yyyy-MM-dd") & "' and  persona =" & Idpersonal, conexionPrinc)
            Dim tablaPers As New DataTable
            'Dim ds As New DataSet

            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            consulta.Fill(tablaPers)
            dtvresumen.DataSource = tablaPers
            dtvresumen.Columns(0).Visible = False
            'dtpersonal.Columns(2).Visible = False
            'dtpersonal.Columns(0).Visible = False

            Dim i As Integer
            Dim sumhor As TimeSpan
            Dim horacurr As TimeSpan
            For i = 0 To dtvresumen.RowCount - 1
                horacurr = dtvresumen.Rows(i).Cells.Item(5).Value
                sumhor += horacurr
            Next

            lblhorasTrab.Text = sumhor.ToString
            txtcantidadhoras.Text = Math.Round(sumhor.TotalHours, 2)
            calcularSueldo()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargarTotalDetallado()
        Try
            Reconectar()
            dttotales.DataSource = Nothing
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT concat(per.apellidos,', ', per.nombre) as Persona, reg.ingreso_fech as FIngreso, " _
            & "reg.ingreso_hor as HoraIng, reg.egreso_fech as FEgreso, reg.egreso_hor as HoraEgr, " _
            & "TIMEDIFF(concat(reg.egreso_fech, ' ', reg.egreso_hor),concat(reg.ingreso_fech,' ', reg.ingreso_hor)) as HorasTrab " _
            & "from empl_registros as reg, sdo_personal as per where reg.persona=per.idpersonal and ingreso_fech between '" & Format(dtptotalde.Value, "yyyy-MM-dd") & "' and '" & Format(dtptotalhasta.Value, "yyyy-MM-dd") & "'", conexionPrinc)
            Dim tablaPers As New DataTable
            consulta.Fill(tablaPers)
            dttotales.DataSource = tablaPers
            'dttotales.Columns(0).Visible = False
            'dtpersonal.Columns(2).Visible = False
            'dtpersonal.Columns(0).Visible = False

            'Dim i As Integer
            'Dim sumhor As TimeSpan
            'Dim horacurr As TimeSpan
            'For i = 0 To dttotales.RowCount - 1
            '    horacurr = dttotales.Rows(i).Cells.Item(5).Value
            '    sumhor += horacurr
            'Next

            'lblhorasTrab.Text = sumhor.ToString
            'txtcantidadhoras.Text = Math.Round(sumhor.TotalHours, 2)
            'calcularSueldo()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub calcularSueldo()
        Try
            Dim canthor As Double = txtcantidadhoras.Text
            Dim preciohor As Double = txtpreciohora.Text
            Dim montohoras As Double
            Dim montootrosing As Double = txtotrosingmonto.Text
            Dim montodesc As Double = txtdescmonto.Text
            Dim sueldo As Double

            montohoras = canthor * preciohor
            txttotalhoras.Text = Math.Round(montohoras, 2)
            sueldo = montohoras
            sueldo += montootrosing
            sueldo -= montodesc

            txtsueldo.Text = Math.Round(sueldo, 2)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarPlanillaTotal()
        Try
            Reconectar()
            Dim SqlQuery As String
            dttotales.DataSource = Nothing
            If RadioButton2.Checked = True Then
                SqlQuery = "SELECT concat(per.apellidos,', ', per.nombre) as personal, " _
                & "sec_to_time(sum(time_to_sec(TIMEDIFF(concat(re.egreso_fech, ' ', re.egreso_hor),concat(re.ingreso_fech,' ', re.ingreso_hor))))) as HorasTrab " _
                & "from empl_registros as re, sdo_personal as per where re.ingreso_fech between '" & Format(dtptotalde.Value, "yyyy-MM-dd") & "' and '" & Format(dtptotalhasta.Value, "yyyy-MM-dd") & "' and " _
                & "per.id = re.persona group by persona"

            ElseIf RadioButton1.Checked = True Then
                SqlQuery = "SELECT concat(per.apellidos,', ', per.nombre) as Persona, reg.ingreso_fech as FIngreso, " _
            & "reg.ingreso_hor as HoraIng, reg.egreso_fech as FEgreso, reg.egreso_hor as HoraEgr, " _
            & "TIMEDIFF(concat(reg.egreso_fech, ' ', reg.egreso_hor),concat(reg.ingreso_fech,' ', reg.ingreso_hor)) as HorasTrab " _
            & "from empl_registros as reg, sdo_personal as per where reg.persona=per.id and ingreso_fech between '" & Format(dtptotalde.Value, "yyyy-MM-dd") & "' and '" & Format(dtptotalhasta.Value, "yyyy-MM-dd") & "'"
            End If
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(SqlQuery, conexionPrinc)
            Dim tablaPers As New DataTable
            consulta.Fill(tablaPers)
            dttotales.DataSource = tablaPers

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles dtptotalde.ValueChanged
        cargarPlanillaTotal()
    End Sub

    Private Sub dtptotalhasta_ValueChanged(sender As Object, e As EventArgs) Handles dtptotalhasta.ValueChanged
        cargarPlanillaTotal()

    End Sub

    Private Sub dtvresumen_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dtvresumen.CellBeginEdit
        If e.ColumnIndex = 5 Then
            MsgBox("no se puede editar este campo")
        End If
    End Sub

    Private Sub dtvresumen_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtvresumen.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Editar" Then
            dtvresumen.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            dtvresumen.AllowUserToAddRows = True
            dtvresumen.SelectionMode = DataGridViewSelectionMode.CellSelect
            Button1.Text = "Fin Edicion"
            Button3.Enabled = False
        Else
            dtvresumen.EditMode = DataGridViewEditMode.EditProgrammatically
            dtvresumen.AllowUserToAddRows = False
            dtvresumen.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            CargarPlanilla()
            Button1.Text = "Editar"
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosimprimir
            'conexionSEC.ChangeDatabase("kigest_igp")
            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
                & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
                & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo " _
                & "FROM fact_empresa as emp where emp.id=1", conexionPrinc)
            tabEmp.Fill(fac.Tables("membreteenca"))
            Dim imprimirx As New imprimirFX
            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("EmplNombre", txtapellido.Text & ", " & txtnombres.Text))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("EmplDNI", txtdocumento.Text))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("EmplDirecc", txtdomicilio.Text))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("ConcCant", txtcantidadhoras.Text))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("ConcDescr", "HORAS TRABAJADAS"))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("ConcTotal", txttotalhoras.Text))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("RecTotal", txtsueldo.Text))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("RecFecha", "Fecha: " & Format(Now, "dd-MM-yyyy")))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("RecLetras", "Recibi conforme la cantidad de pesos " & EnLetras(txtsueldo.Text)))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("OtroConc", "    " & txtotrosingdescr.Text))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("OtroMonto", txtotrosingmonto.Text))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("DescConc", "    " & txtdescuentosdescr.Text))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("DescMonto", "-" & txtdescmonto.Text))

            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\recibosueldo.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("membreteenca")))
                .rptfx.LocalReport.SetParameters(parameters)
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With


        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcantidadhoras_TextChanged(sender As Object, e As EventArgs) Handles txtcantidadhoras.TextChanged
        calcularSueldo()
    End Sub

    Private Sub txtpreciohora_TextChanged(sender As Object, e As EventArgs) Handles txtpreciohora.TextChanged
        calcularSueldo()
    End Sub

    Private Sub txtsueldo_TextChanged(sender As Object, e As EventArgs) Handles txtsueldo.TextChanged
        'calcularSueldo()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'GenerarExcel(dttotales)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' GenerarExcel(dtvresumen)
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub txtotrosingmonto_TextChanged(sender As Object, e As EventArgs) Handles txtotrosingmonto.TextChanged
        calcularSueldo()
    End Sub

    Private Sub txtdescmonto_TextChanged(sender As Object, e As EventArgs) Handles txtdescmonto.TextChanged
        calcularSueldo()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'GenerarExcel(dtpersonal)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        cargarPlanillaTotal()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        cargarPlanillaTotal()
    End Sub

    Private Sub dtvresumen_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtvresumen.CellEndEdit
        Try
            Reconectar()
            Dim sqlQuery As String
            Dim valor As String = dtvresumen.CurrentCell.Value.ToString
            Dim indice As String = dtvresumen.CurrentRow.Cells(0).Value
            If e.ColumnIndex = 1 Then
                If IsDate(dtvresumen.CurrentCell.Value) Then
                    valor = Format(CDate(valor), "yyyy-MM-dd") 'Format(valor, "yyyy-MM-dd")
                    sqlQuery = "update empl_registros set ingreso_fech='" & valor & "' where id=" & indice
                Else
                    MsgBox("fecha invalida: " & valor)
                End If
            ElseIf e.ColumnIndex = 2 Then
                If IsDate(dtvresumen.CurrentCell.Value.ToString) Then
                    valor = Format(CDate(valor), "HH:mm:ss")
                    sqlQuery = "update empl_registros set ingreso_hor='" & valor & "' where id=" & indice
                Else
                    MsgBox("HORA invalida: " & valor)
                End If
            ElseIf e.ColumnIndex = 3 Then
                If IsDate(dtvresumen.CurrentCell.Value) Then
                    valor = Format(CDate(valor), "yyyy-MM-dd")
                    sqlQuery = "update empl_registros set egreso_fech='" & valor & "' where id=" & indice
                Else
                    MsgBox("fecha invalida: " & valor)
                End If
            ElseIf e.ColumnIndex = 4 Then
                If IsDate(dtvresumen.CurrentCell.Value.ToString) Then
                    valor = Format(CDate(valor), "HH:mm:ss")
                    sqlQuery = "update empl_registros set egreso_hor='" & valor & "' where id=" & indice
                Else
                    MsgBox("HORA invalida: " & valor)
                End If

            End If
            'MsgBox(sqlQuery)
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandoadd.ExecuteReader()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtvresumen_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtvresumen.RowsAdded


    End Sub

    Private Sub dtvresumen_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtvresumen.UserAddedRow
        Try
            Dim sqlquery As String
            sqlquery = "insert into empl_registros(persona) values('" & Idpersonal & "')"
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlquery, conexionPrinc)
            comandoadd.ExecuteNonQuery()
            dtvresumen.CurrentRow.Cells(0).Value = comandoadd.LastInsertedId
            'MsgBox("insertado " & comandoadd.LastInsertedId)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Dim UltId As Integer = CInt(lblultid.Text)
        'If Date.Parse(dtpimpdesde.Value).ToString("yyyy-MM-dd") <= Date.Parse(lblultimp.Text).ToString("yyyy-MM-dd") Then
        '    MsgBox("la fecha de incio de la importacion debe ser mas reciente que la ultima realizada. ")
        '    Exit Sub
        'End If
        dlAbrir.Filter = "Archivos de Texto (*.txt)|*.txt|" &
      "Archivos de log (*.log)|*.log|" &
      "Todos los archivos (*.*)|*.*"
        dlAbrir.Multiselect = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            Dim objReader As New StreamReader(fichero)
            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    arrText.Add(sLine)
                End If
            Loop Until sLine Is Nothing
            objReader.Close()

            For Each sLine In arrText
                'MsgBox(sLine)
                Dim datos() As String
                datos = sLine.Split(vbTab)
                If datos(0) <> "No" Then
                    Dim fechhor() As String = datos(4).Split("  ")
                    Dim idpers As String = datos(2).Replace("0", "")
                    Dim fech As String = fechhor(0).ToString
                    Dim hora As String = fechhor(2).ToString
                    Dim fechainicio As String = Format(dtpimpdesde.Value, "yyyy-MM-dd")
                    If datos(0) > UltId Then
                        txtdatosImportar.Text &= sLine & vbNewLine
                        'Dim fechhor() As String = datos(4).Split("  ")
                        'Dim idpers As Integer = datos(2).Replace("0", "")
                        'Dim fech As String = fechhor(0).ToString
                        'Dim hora As String = fechhor(2).ToString
                        ''MsgBox(fech & " - " & Date.Parse(fech).ToString("yyyy-MM-dd"))
                        'MsgBox(hora & " - " & Date.Parse(hora).ToString("H:mm:ss"))
                        Reconectar()
                        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id from empl_registros where egreso_fech is null and persona=" & idpers, conexionPrinc)
                        Dim tablacl As New DataTable
                        Dim infocl() As DataRow
                        consulta.Fill(tablacl)
                        If tablacl.Rows.Count = 0 Then
                            Reconectar()
                            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("insert into empl_registros (persona, ingreso_fech, ingreso_hor) values (?idpers,?fech,?hora)", conexionPrinc)
                            With comandoadd.Parameters
                                .AddWithValue("?idpers", idpers)
                                .AddWithValue("?fech", Date.Parse(fech).ToString("yyyy-MM-dd"))
                                .AddWithValue("?hora", Date.Parse(hora).ToString("H:mm:ss"))
                            End With
                            comandoadd.ExecuteNonQuery()
                        ElseIf tablacl.Rows.Count <> 0 Then
                            Reconectar()
                            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("update empl_registros set egreso_fech=?fech, egreso_hor=?hora where persona=?idpers and egreso_fech is null", conexionPrinc)
                            With comandoadd.Parameters
                                .AddWithValue("?idpers", idpers)
                                .AddWithValue("?fech", Date.Parse(fech).ToString("yyyy-MM-dd"))
                                .AddWithValue("?hora", Date.Parse(hora).ToString("H:mm:ss"))
                            End With
                            comandoadd.ExecuteNonQuery()
                        End If
                        Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand("update empl_config set ultimport=now() where id=1 ", conexionPrinc)
                        comandoupd.ExecuteNonQuery()
                        Dim comandoupd2 As New MySql.Data.MySqlClient.MySqlCommand("update empl_config set ultimport=" & datos(0) & " where id=2 ", conexionPrinc)
                        comandoupd2.ExecuteNonQuery()
                        lblestadoimport.Text = "Importación finalizada"
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select ultimport from empl_config", conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            lblultimp.Text = infocl(0)(0)
            lblultid.Text = infocl(1)(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub cmdimagen_Click(sender As Object, e As EventArgs) Handles cmdimagen.Click

    End Sub

    Private Sub cmbcentro_costos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcentro_costos.SelectedIndexChanged

    End Sub

    Private Sub cmbcentro_costos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcentro_costos.SelectionChangeCommitted

    End Sub

    Private Sub dtpersonal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtpersonal.CellContentClick

    End Sub

    Private Sub cmbcentro_costos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbcentro_costos.SelectedValueChanged
        Reconectar()
        Try
            Dim tablaCatTra As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_categoria_personal where idconvenio = " & cmbcentro_costos.SelectedValue, conexionPrinc)
            Dim readcatTR As New DataSet
            'cargamos categorias de trabajo
            tablaCatTra.Fill(readcatTR)
            cmbcategoria.DataSource = readcatTR.Tables(0)
            cmbcategoria.DisplayMember = readcatTR.Tables(0).Columns(1).Caption.ToString
            cmbcategoria.ValueMember = readcatTR.Tables(0).Columns(0).Caption.ToString
            cmbcategoria.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub
End Class