Imports System.Runtime.InteropServices
Public Class frmaspirantes

    Inherits System.Windows.Forms.Form
    'Public HC As New verhc()
    Dim Idcliente As Integer
    Dim modificarPers As Boolean
    Dim agregarPers As Boolean
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Dim idsub As String
    
    Private Sub frmpersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load        
        deshabilitarControles()
        cargarDtosGrales()
    End Sub
    Private Sub ClienteSeleccionado(cliente As Integer) Handles dgvClientes.SeleccionarItem
        Idcliente = cliente
        CargarInfoPers()
    End Sub
    Public Sub CargarPersonal(ByRef busqueda As String)

        cargarDtosGrales()
        Dim busqtxt As String
        busqueda = busqueda.Replace(" ", "%")
        busqtxt = " where nomapell_razon like @busq or dir_domicilio like @busq or cuit like @busq or telefono like @busq or celular like @busq"

        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select idclientes as Cuenta, nomapell_razon as Cliente, codClie from fact_clientes where nomapell_razon like @busq or dir_domicilio like @busq or cuit like @busq or telefono like @busq or celular like @busq", conexionPrinc)
            consulta.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@busq", MySql.Data.MySqlClient.MySqlDbType.Text))
            consulta.SelectCommand.Parameters("@busq").Value = "%" & busqueda & "%"
            'MsgBox(consulta.SelectCommand.CommandText)
            Dim tablaPers As New DataTable
            consulta.Fill(tablaPers)
            'DgvClientes.Cargar_Datos(tablaPers)

            'BindingSource1.DataSource = tablaPers
            dgvClientes.Cargar_Datos(tablaPers) 'BindingSource1.DataSource
            ''pbprogresocons.Visible = False
            ''cerrar_Conexiones()
            ''dtpersonal.Columns(2).Visible = False
            'dtpersonal.Columns(0).Visible = False
        Catch ex As Exception
            'cerrar_Conexiones()
            'pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
    End Sub

    Private Sub CargarInfoPers()
        Dim imag As Byte()
        vaciarControles()
        Try
            Reconectar()

            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_clientes where idclientes=" & Idcliente, conexionPrinc)
            Dim tablacli As New DataTable
            Dim infocli() As DataRow
            consulta.Fill(tablacli)
            infocli = tablacli.Select("")

            '***********************************DATOS PERSONALES*********************************************
            'Dim posComa As String = InStr(lector("nomapell_razon").ToString, ",")
            txtnumeroclie.Text = infocli(0)(12)
            txtrazon.Text = infocli(0)(1)
            cmbcondiva.SelectedValue = infocli(0)(4)
            txtcuit.Text = infocli(0)(5)
            txttelefono.Text = infocli(0)(6)
            txtcelular.Text = infocli(0)(8)
            txtmail.Text = infocli(0)(9)
            txtdomicilio.Text = infocli(0)(2)
            cmblocalidad.SelectedValue = infocli(0)(3)
            txtcontactos.Text = infocli(0)(7)
            txtobservaciones.Text = infocli(0)(10)
            cmblistas.SelectedValue = infocli(0)(11)
            cmbvendedor.SelectedValue = infocli(0)(13)
        Catch ex As Exception

            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try

    End Sub
    Private Sub cargarDtosGrales()
        pbprogresocons.Visible = True
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos listas
            Dim tablalistas As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_listas_precio", conexionPrinc)
            Dim readlis As New DataSet
            tablalistas.Fill(readlis)
            cmblistas.DataSource = readlis.Tables(0)
            cmblistas.DisplayMember = readlis.Tables(0).Columns(1).Caption.ToString
            cmblistas.ValueMember = readlis.Tables(0).Columns(0).Caption.ToString
            cmblistas.SelectedIndex = -1

            'cargamos localidades
            Dim tablalocalidad As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_localidad", conexionPrinc)
            Dim readloc As New DataSet
            tablalocalidad.Fill(readloc)
            cmblocalidad.DataSource = readloc.Tables(0)
            cmblocalidad.DisplayMember = readloc.Tables(0).Columns(1).Caption.ToString
            cmblocalidad.ValueMember = readloc.Tables(0).Columns(0).Caption.ToString
            cmblocalidad.SelectedIndex = -1
            cmblistaloca.DataSource = readloc.Tables(0)
            cmblistaloca.DisplayMember = readloc.Tables(0).Columns(1).Caption.ToString
            cmblistaloca.ValueMember = readloc.Tables(0).Columns(0).Caption.ToString


            'cargamos tipos de contribuyentes
            Dim tablaivat As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_ivatipo", conexionPrinc)
            Dim readivat As New DataSet
            tablaivat.Fill(readivat)
            cmbcondiva.DataSource = readivat.Tables(0)
            cmbcondiva.DisplayMember = readivat.Tables(0).Columns(1).Caption.ToString
            cmbcondiva.ValueMember = readivat.Tables(0).Columns(0).Caption.ToString
            'cmbcondiva.SelectedValue = 4

            'cargamos vendedores
            Dim tablavend As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,', ', nombre) from fact_vendedor where activo=1", conexionPrinc)
            Dim readvend As New DataSet
            tablavend.Fill(readvend)
            cmbvendedor.DataSource = readvend.Tables(0)
            cmbvendedor.DisplayMember = readvend.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbvendedor.ValueMember = readvend.Tables(0).Columns(0).Caption.ToString
            cmbvendedor.SelectedIndex = -1

            cmbvendedor_lst.DataSource = readvend.Tables(0)
            cmbvendedor_lst.DisplayMember = readvend.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbvendedor_lst.ValueMember = readvend.Tables(0).Columns(0).Caption.ToString
            cmbvendedor_lst.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub


    Private Sub deshabilitarControles()

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

    End Sub

    Private Function Buscar(
            ByVal Columna As String,
            ByVal texto As String,
            ByVal BindingSource As BindingSource) As Integer

        Try
            ' si está vacio salir y no retornar nada  
            If BindingSource1.DataSource Is Nothing Then
                Return -1
            End If

            ' Ejecutar el método Find pasándole los datos  
            Dim fila As Integer = BindingSource.Find(Columna.Trim, texto)

            ' Mover el cursor a la fila obtenida  
            BindingSource.Position = fila

            ' retornar el valor  
            Return fila

            ' errores  
        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
        ' no retornar nada  
        Return -1

    End Function


    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click

        Dim sqlQuery As String

        Dim razon As String
        Dim telefono As String
        Dim celular As String
        Dim domicilio As String
        Dim localidad As String
        Dim observaciones As String
        Dim tipoiva As Integer
        Dim cuit As String
        Dim contacto As String
        Dim mail As String
        Dim numeroClie As String
        Dim vendedor As Integer = cmbvendedor.SelectedValue
        Dim lista As Integer = cmblistas.SelectedValue
        Dim codclie As String = txtnumeroclie.Text
        Try
            Reconectar()
            razon = txtrazon.Text.ToUpper
            tipoiva = cmbcondiva.SelectedValue
            cuit = txtcuit.Text.Replace("-", "")
            telefono = txttelefono.Text
            celular = txtcelular.Text
            domicilio = txtdomicilio.Text.ToUpper
            observaciones = txtobservaciones.Text.ToUpper
            localidad = cmblocalidad.SelectedValue
            contacto = txtcontactos.Text.ToUpper
            mail = txtmail.Text.ToLower
            numeroClie = txtnumeroclie.Text

            If comprobarCamposObligatorios() = True Then
                MsgBox("Hay campos obligatorios que no fueron completados, por favor verifique")
                Exit Sub
            End If

            If localidad = 0 Then
                'MsgBox("no se selecciono localidad, se agregara")

                comando.Connection = conexionPrinc
                comando.CommandText = "insert into  cm_localidad(nombre) values('" & cmblocalidad.Text.ToUpper & "')"
                comando.ExecuteReader()
                localidad = comando.LastInsertedId
            End If
            Reconectar()

            If modificarPers = False Then
                sqlQuery = "insert into fact_clientes " _
                & "(nomapell_razon, dir_domicilio, dir_localidad, iva_tipo, cuit, telefono, contacto, celular, email, observaciones,lista_precios,codClie,vendedor) values " _
                & "(?nomb,?domi,?loca,?iva,?cuit,?tel,?cont,?cel,?mail,?obs,?lista,?codclie,?vendedor)"
            ElseIf modificarPers = True Then
                '  MsgBox("modificando")
                sqlQuery = "update fact_clientes set nomapell_razon=?nomb, dir_domicilio=?domi, dir_localidad=?loca, iva_tipo=?iva, cuit=?cuit, " _
                    & " telefono=?tel, contacto=?cont, celular=?cel, email=?mail, observaciones=?obs, lista_precios=?lista, codClie=?codclie, vendedor=?vendedor where idclientes=?idc"
            End If

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?nomb", razon)
                .AddWithValue("?domi", domicilio)
                .AddWithValue("?loca", localidad)
                .AddWithValue("?iva", tipoiva)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?tel", telefono)
                .AddWithValue("?cont", contacto)
                .AddWithValue("?cel", celular)
                .AddWithValue("?mail", mail)
                .AddWithValue("?obs", observaciones)
                .AddWithValue("?lista", lista)
                .AddWithValue("?codclie", codclie)
                .AddWithValue("?vendedor", vendedor)

                If modificarPers = True Then
                    .AddWithValue("?idc", Idcliente)
                End If
            End With
            comandoadd.ExecuteNonQuery()

            If modificarPers = True Then
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Cliente Modificado correctamente"
                'TabControl1.SelectedTab = TabPage2
                'cmbcattrabajo.Focus()

                dgvClientes.dgvVista.Enabled = False
            ElseIf modificarPers = False Then
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Cliente agregado correctamente"
                cargarDtosGrales()
                'txtbuscar.Text = txtapellido.Text & ", " & txtnombres.Text
                CargarPersonal(txtbuscar.Text)
                CargarInfoPers()
                Idcliente = comandoadd.LastInsertedId
                Dim i As Integer
                For i = 0 To dgvClientes.dgvVista.Rows.Count - 1
                    If dgvClientes.dgvVista.Item(0, i).Value = Idcliente Then
                        dgvClientes.dgvVista.Rows(i).Selected = True
                    End If
                Next

                dgvClientes.dgvVista.Enabled = False
            End If
            modificarPers = False
            cmdmodificar.Enabled = True
            cmdnuevapers.Enabled = True
            cmdeliminar.Enabled = True
            cmdcancelar.Enabled = False
            cmdaceptar.Enabled = False
            dgvClientes.dgvVista.Enabled = True
            txtbuscar.ReadOnly = False
            'lblestado.Text = ""
            deshabilitarControles()
        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub vaciarControles()

        'txtnombres.Text = ""
        txtrazon.Text = ""
        'txtdocumento.Text = ""
        txtdomicilio.Text = ""
        txtobservaciones.Text = ""
        txttelefono.Text = ""
        cmblocalidad.SelectedIndex = -1
        cmbcondiva.SelectedValue = 4
        txtcuit.Text = ""
        txtcelular.Text = ""
        txtcontactos.Text = ""
        txtmail.Text = ""

    End Sub

    Private Function ComprobarAspirante(ByRef dni As String) As Boolean
        pbprogresocons.Visible = True
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            Dim i As Integer = 0
            conexionPrinc.ChangeDatabase(database)
            sql.Connection = conexionPrinc
            sql.CommandText = "select id from pacientes where dni like '" & dni & "'"
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
            cerrar_Conexiones()
            pbprogresocons.Visible = False
        Catch ex As Exception
            cerrar_Conexiones()
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try

    End Function

    Private Sub txtbuscar_GotFocus(sender As Object, e As EventArgs) Handles txtbuscar.GotFocus
        If txtbuscar.Text = "INGRESE CLIENTE A BUSCAR" Then
            txtbuscar.Clear()
        End If
    End Sub

    Private Sub txtbuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyUp

        If e.KeyCode = Keys.Enter Then
            Dim EnProgreso As New Form
            EnProgreso.ControlBox = False
            EnProgreso.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
            EnProgreso.Size = New Point(430, 30)
            EnProgreso.StartPosition = FormStartPosition.CenterScreen
            EnProgreso.TopMost = True
            Dim Etiqueta As New Label
            Etiqueta.AutoSize = True
            Etiqueta.Text = "La consulta esta en progreso, esto puede tardar unos momentos, por favor espere ..."
            Etiqueta.Location = New Point(5, 5)
            EnProgreso.Controls.Add(Etiqueta)
            'Dim Barra As New ProgressBar
            'Barra.Style = ProgressBarStyle.Marquee
            'Barra.Size = New Point(270, 40)
            'Barra.Location = New Point(10, 30)
            'Barra.Value = 100
            'EnProgreso.Controls.Add(Barra)
            EnProgreso.Show()
            Application.DoEvents()
            If txtbuscar.Text.Trim = "" Then
                MsgBox("No se especifico parametro de busqueda")
                Exit Sub
            Else
                dgvClientes.dgvVista.Focus()
            End If
            CargarPersonal(txtbuscar.Text)
            EnProgreso.Close()
        End If

        'BindingSource1.Filter = "Nombre LIKE " & txtbuscar.Text
        'BindingSource1.Filter = "Paciente Like '%" & txtbuscar.Text & "%'"
    End Sub


    Private Function comprobarCamposObligatorios() As Boolean
        'If txtnombres.Text = "" Then Return True
        If txtrazon.Text = "" Then Return True
        If cmbcondiva.SelectedValue <> 4 And txtcuit.Text = "" Then Return True
        If txtdomicilio.Text = "" Then Return True
        If cmblocalidad.Text = "" Then Return True
        If cmbvendedor.Text = "" Then Return True
    End Function

    Private Sub cmdeliminar_Click(sender As Object, e As EventArgs) Handles cmdeliminar.Click
        'If DatosAcceso.Moduloacc <> 6 Then
        '    MsgBox("NO esta autorizado a modificar las los pacientes")
        '    Exit Sub
        'End If
        Try
            Reconectar()
            If MsgBox("Esta seguro que desea eliminar este Cliente?, se borraran todos los datos asociados a él?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Eliminar Cliente") = MsgBoxResult.Ok Then

                comando.Connection = conexionPrinc
                comando.CommandText = "DELETE from fact_clientes where idclientes=" & Idcliente
                comando.ExecuteReader()
                CargarPersonal(txtbuscar.Text)
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Se elimino correctamente"
            End If

        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
    End Sub

    Private Sub cmdnuevapers_Click(sender As Object, e As EventArgs) Handles cmdnuevapers.Click
        'If DatosAcceso.Moduloacc <> 6 Then
        'MsgBox("NO esta autorizado a modificar")
        'Exit Sub
        'End If
        vaciarControles()
        'cargarDtosGrales()
        cmdaceptar.Enabled = True
        cmdaceptar.Enabled = True
        cmdcancelar.Enabled = True
        cmdcancelar.Enabled = True
        dgvClientes.dgvVista.Enabled = False
        cmdnuevapers.Enabled = False
        cmdmodificar.Enabled = False
        cmdeliminar.Enabled = False
        modificarPers = False
        deshabilitarControles()
    End Sub

    Private Sub cmdmodificar_Click(sender As Object, e As EventArgs) Handles cmdmodificar.Click
        'If DatosAcceso.Moduloacc <> 6 Then
        'MsgBox("NO esta autorizado a modificar")
        'Exit Sub
        'End If
        deshabilitarControles()
        cmdaceptar.Enabled = True
        cmdaceptar.Enabled = True
        cmdcancelar.Enabled = True
        cmdcancelar.Enabled = True
        cmdnuevapers.Enabled = False
        cmdmodificar.Enabled = False
        cmdeliminar.Enabled = False
        modificarPers = True
        dgvClientes.dgvVista.Enabled = False
        txtbuscar.ReadOnly = True
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
    End Sub

    Private Sub txtbuscar_LostFocus(sender As Object, e As EventArgs) Handles txtbuscar.LostFocus
        If txtbuscar.Text = "" Then
            txtbuscar.Text = "INGRESE CLIENTE A BUSCAR"
        End If
    End Sub

    Private Sub cmbcondiva_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbcondiva_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbcondiva.SelectedValue <> 4 Then
                txtcuit.Enabled = True
            Else
                txtcuit.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        deshabilitarControles()
        cmdaceptar.Enabled = False
        cmdaceptar.Enabled = False
        cmdcancelar.Enabled = False
        cmdcancelar.Enabled = False
        cmdnuevapers.Enabled = True
        cmdmodificar.Enabled = True
        cmdeliminar.Enabled = True
        dgvClientes.dgvVista.Enabled = True
        txtbuscar.ReadOnly = False
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim EnProgreso As New Form
        EnProgreso.ControlBox = False
        EnProgreso.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        EnProgreso.Size = New Point(430, 30)
        EnProgreso.StartPosition = FormStartPosition.CenterScreen
        EnProgreso.TopMost = True
        Dim Etiqueta As New Label
        Etiqueta.AutoSize = True
        Etiqueta.Text = "La consulta esta en progreso, esto puede tardar unos momentos, por favor espere ..."
        Etiqueta.Location = New Point(5, 5)
        EnProgreso.Controls.Add(Etiqueta)
        'Dim Barra As New ProgressBar
        'Barra.Style = ProgressBarStyle.Marquee
        'Barra.Size = New Point(270, 40)
        'Barra.Location = New Point(10, 30)
        'Barra.Value = 100
        'EnProgreso.Controls.Add(Barra)
        Dim filtraloca As String
        Dim filtravendedor As String
        Dim filtors As String


        If chklocalidad.Checked = True Then
            filtraloca = " and dir_localidad=" & cmblistaloca.SelectedValue
        End If
        If chkvendedor.Checked = True Then
            filtravendedor = " and  vendedor= " & cmbvendedor_lst.SelectedValue
        End If
        EnProgreso.Show()
        Application.DoEvents()
        Try
            Reconectar()

            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
            & "idclientes as Cuenta, nomapell_razon as Cliente,contacto,telefono,celular,dir_domicilio,cuit  from fact_clientes where nomapell_razon like '%'  " & filtraloca & filtravendedor, conexionPrinc)
            'MsgBox(consulta.SelectCommand.CommandText)
            Dim tablaPers As New DataTable

            consulta.Fill(tablaPers)
            dgvlistaClientes.Cargar_Datos(tablaPers)

            EnProgreso.Close()
        Catch ex As Exception
            EnProgreso.Close()

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim fac As New datosfacturas
        Dim filtraloca As String
        Dim filtravendedor As String
        Dim tituloHoja As String
        If chklocalidad.Checked = True Then
            filtraloca = " and dir_localidad=" & cmblistaloca.SelectedValue
            tituloHoja = cmblistaloca.Text
        End If
        If chkvendedor.Checked = True Then
            filtravendedor = " and vendedor=" & cmbvendedor_lst.SelectedValue
            tituloHoja &= " | vend.: " & cmbvendedor_lst.Text
        End If
        Try
            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo " _
            & "FROM fact_empresa as emp where emp.id=1", conexionPrinc)

            tabEmp.Fill(fac.Tables("membreteenca"))
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "idclientes as cuenta, nomapell_razon as cliente,contacto,telefono,celular,dir_domicilio as domicilio, cuit " _
            & "from fact_clientes where nomapell_razon like '%'  " & filtraloca & filtravendedor, conexionPrinc)

            Dim tablaestado As New DataTable
            tabFac.Fill(fac.Tables("listaclientes"))
            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("zona", tituloHoja))

            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listadoclientes.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("membreteenca", fac.Tables("membreteenca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("listaclientes")))
                .rptfx.LocalReport.SetParameters(parameters)
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbcondiva_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcondiva.SelectionChangeCommitted
        If cmbcondiva.SelectedValue = 4 And modificarPers = True Then
            txtcuit.ReadOnly = True
        ElseIf cmbcondiva.SelectedValue <> 4 And modificarPers = True Then
            txtcuit.ReadOnly = False

        End If
    End Sub

    Private Sub txtrazon_Leave(sender As Object, e As EventArgs) Handles txtrazon.Leave
        If ComprobarCliente(txtrazon.Text) = True And txtrazon.Text <> "" Then
            MsgBox("la informacion ingresada del cliente coincide con alguna registrada en la base de datos, por favor verifique si el cliente ya existe")
        End If
    End Sub

    Private Sub txtcuit_Leave(sender As Object, e As EventArgs) Handles txtcuit.Leave
        If ComprobarCliente(txtcuit.Text.Replace("-", "")) = True And txtcuit.Text <> "" Then
            MsgBox("la informacion ingresada del cliente coincide con alguna registrada en la base de datos, por favor verifique si el cliente ya existe")
        End If
    End Sub

    Private Sub txtdomicilio_Leave(sender As Object, e As EventArgs) Handles txtdomicilio.Leave
        'If ComprobarCliente(txtdomicilio.Text) = True And txtdomicilio.Text <> "" Then
        '    MsgBox("la informacion ingresada del cliente coincide con alguna registrada en la base de datos, por favor verifique si el cliente ya existe")
        'End If
    End Sub

    Private Sub txttelefono_Leave(sender As Object, e As EventArgs) Handles txttelefono.Leave
        If ComprobarCliente(txttelefono.Text) = True And txttelefono.Text <> "" Then
            MsgBox("la informacion ingresada del cliente coincide con alguna registrada en la base de datos, por favor verifique si el cliente ya existe")
        End If
    End Sub

    Private Sub txtcelular_Leave(sender As Object, e As EventArgs) Handles txtcelular.Leave
        If ComprobarCliente(txtcelular.Text) = True And txtcelular.Text <> "" Then
            MsgBox("la informacion ingresada del cliente coincide con alguna registrada en la base de datos, por favor verifique si el cliente ya existe")
        End If
    End Sub

    Private Sub txtmail_Leave(sender As Object, e As EventArgs) Handles txtmail.Leave
        If ComprobarCliente(txtmail.Text) = True And txtmail.Text <> "" Then
            MsgBox("la informacion ingresada del cliente coincide con alguna registrada en la base de datos, por favor verifique si el cliente ya existe")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GenerarExcel(dgvlistaClientes.dgvVista)
    End Sub

    Private Sub chklocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chklocalidad.CheckedChanged
        If chklocalidad.Checked = True Then
            cmblistaloca.Enabled = True
        Else
            cmblistaloca.Enabled = False
        End If
    End Sub

    Private Sub chkvendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chkvendedor.CheckedChanged
        If chkvendedor.Checked = True Then
            cmbvendedor_lst.Enabled = True
        Else
            cmbvendedor_lst.Enabled = False
        End If
    End Sub

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged

    End Sub
End Class