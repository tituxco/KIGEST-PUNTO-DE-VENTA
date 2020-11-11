Imports System.Runtime.InteropServices
Public Class proveedores
    Inherits System.Windows.Forms.Form
    'Public HC As New verhc()
    Dim Idproveedor As Integer
    Dim modificarPers As Boolean
    Dim agregarPers As Boolean
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Dim idsub As String
    Dim tipoFac As New DataGridViewComboBoxCell
    Dim SelFech As New CalendarCell


    Private Sub dtpersonal_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtpersonal.CellEnter
        Idproveedor = dtpersonal.CurrentRow.Cells.Item(0).Value
        CargarInfoProv()
        cargarCuentaProv()
    End Sub
    Public Sub CargarPersonal()

        cargarDtosGrales()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id as Cuenta, razon as Proveedor from fact_proveedores order by razon asc", conexionPrinc)
            Dim tablaPers As New DataTable
            'Dim ds As New DataSet

            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            consulta.Fill(tablaPers)
            BindingSource1.DataSource = tablaPers
            dtpersonal.DataSource = BindingSource1.DataSource

            cerrar_Conexiones()
            'dtpersonal.Columns(2).Visible = False
            dtpersonal.Columns(0).Visible = False


        Catch ex As Exception
            cerrar_Conexiones()

            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
    End Sub

    Private Sub CargarInfoProv()
        Dim imag As Byte()
        vaciarControles()
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            conexionPrinc.ChangeDatabase(database)
            sql.Connection = conexionPrinc
            sql.CommandText = "select * from fact_proveedores where id=" & Idproveedor

            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            '***********************************DATOS PERSONALES*********************************************
            'Dim posComa As String = InStr(lector("nomapell_razon").ToString, ",")
            txtrazon.Text = lector("razon").ToString
            cmbcondiva.SelectedValue = lector("tipo_iva")
            txtcuit.Text = lector("cuit").ToString
            txtdomicilio.Text = lector("direccion").ToString
            txtinfo.Text = lector("informacion_adic").ToString
        Catch ex As Exception
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try

    End Sub
    Private Sub cargarDtosGrales()

        Try
            Reconectar()

            'cargamos tipos de contribuyentes
            Dim tablaivat As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_ivatipo", conexionPrinc)
            Dim readivat As New DataSet
            tablaivat.Fill(readivat)
            cmbcondiva.DataSource = readivat.Tables(0)
            cmbcondiva.DisplayMember = readivat.Tables(0).Columns(1).Caption.ToString
            cmbcondiva.ValueMember = readivat.Tables(0).Columns(0).Caption.ToString
            'cmbcondiva.SelectedValue = 4

        Catch ex As Exception

            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try

    End Sub

    Private Sub cargarCuentaProv()
        Try
            dtcomprobantes.Rows.Clear()
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select fa.id, fa.fecha, fa.tipo, fa.numero, fa.monto, fa.vencimiento, fa.observaciones,fa.pagada " _
            & "from fact_proveedores_fact as fa where idproveedor= " & Idproveedor & " order by fa.fecha desc", conexionPrinc)
            Dim tablacta As New DataTable
            'Dim ds As New DataSet
            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            Dim itemCta() As DataRow
            Dim i As Integer
            consulta.Fill(tablacta)
            itemCta = tablacta.Select()

            For i = 0 To itemCta.GetUpperBound(0)
                dtcomprobantes.Rows.Add(itemCta(i)(0), itemCta(i)(1), itemCta(i)(2), itemCta(i)(3), itemCta(i)(4), itemCta(i)(5), itemCta(i)(6))
                'If itemCta(i)(7) = 1 Then
                '    dtcomprobantes.Rows(dtcomprobantes.RowCount - 1).DefaultCellStyle.BackColor = Color.GreenYellow
                'End If
            Next

            ' dtcomprobantes.Item(2, dtcomprobantes.RowCount - 1) = tipoFac.Clone
            dtcomprobantes.Item(1, dtcomprobantes.RowCount - 1) = SelFech.Clone
            dtcomprobantes.Item(5, dtcomprobantes.RowCount - 1) = SelFech.Clone

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

    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click

        Dim sqlQuery As String

        Dim razon As String
        Dim domicilio As String
        Dim tipoiva As Integer
        Dim cuit As String
        Dim info As String

        Try
            Reconectar()
            razon = txtrazon.Text.ToUpper
            tipoiva = cmbcondiva.SelectedValue
            cuit = txtcuit.Text
            domicilio = txtdomicilio.Text.ToUpper

            info = txtinfo.Text.ToUpper

            If comprobarCamposObligatorios() = True Then
                MsgBox("Hay campos obligatorios que no fueron completados, por favor verifique")
                Exit Sub
            End If

            Reconectar()

            If modificarPers = False Then
                sqlQuery = "insert into fact_proveedores " _
                & "(razon,direccion,tipo_iva, cuit, informacion_adic) values " _
                & "(?razon,?dire,?iva,?cuit,?info)"
            ElseIf modificarPers = True Then
                '  MsgBox("modificando")
                sqlQuery = "update fact_proveedores set razon=?razon, direccion=?dire, tipo_iva=?iva, cuit=?cuit, " _
                    & " informacion_adic=?info where id=?idp"
            End If

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?razon", razon)
                .AddWithValue("?dire", domicilio)
                .AddWithValue("?iva", tipoiva)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?info", info)

                If modificarPers = True Then
                    .AddWithValue("?idp", Idproveedor)
                End If
            End With
            comandoadd.ExecuteNonQuery()

            If modificarPers = True Then
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Proveedor Modificado correctamente"
                'TabControl1.SelectedTab = TabPage2
                'cmbcattrabajo.Focus()
                dtpersonal.Enabled = False
            ElseIf modificarPers = False Then
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Proveedor agregado correctamente"
                cargarDtosGrales()
                'txtbuscar.Text = txtapellido.Text & ", " & txtnombres.Text
                CargarPersonal()
                CargarInfoProv()
                Idproveedor = comandoadd.LastInsertedId
                Dim i As Integer
                For i = 0 To dtpersonal.Rows.Count - 1
                    If dtpersonal.Item(0, i).Value = Idproveedor Then
                        dtpersonal.Rows(i).Selected = True
                    End If
                Next

                dtpersonal.Enabled = False
            End If

        Catch ex As Exception

            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
        modificarPers = False
        cmdmodificar.Enabled = True
        cmdnuevapers.Enabled = True
        cmdeliminar.Enabled = True
        cmdcancelar.Enabled = False
        cmdaceptar.Enabled = False
        dtpersonal.Enabled = True

        'lblestado.Text = ""
        deshabilitarControles()
    End Sub

    Private Sub vaciarControles()

        'txtnombres.Text = ""
        txtrazon.Text = ""
        'txtdocumento.Text = ""
        txtdomicilio.Text = ""

        cmbcondiva.SelectedValue = 4
        txtcuit.Text = ""
        txtinfo.Text = ""

    End Sub


    Private Function comprobarCamposObligatorios() As Boolean
        'If txtnombres.Text = "" Then Return True
        If txtrazon.Text = "" Then Return True
        If cmbcondiva.SelectedValue <> 4 And txtcuit.Text = "" Then Return True
        If txtdomicilio.Text = "" Then Return True

    End Function

    Private Sub cmdeliminar_Click(sender As Object, e As EventArgs) Handles cmdeliminar.Click
        If DatosAcceso.Moduloacc <> 6 Then
            MsgBox("NO esta autorizado a modificar las los pacientes")
            Exit Sub
        End If
        Try
            Reconectar()
            If MsgBox("Esta seguro que desea eliminar este Paciente?, se borraran todos los datos asociados a él?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Eliminar Paciente") = MsgBoxResult.Ok Then

                comando.Connection = conexionPrinc
                comando.CommandText = "DELETE from pacientes where id=" & Idproveedor
                comando.ExecuteReader()
                CargarPersonal()
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Se elimino correctamente"
            End If

        Catch ex As Exception

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
        dtpersonal.Enabled = False
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
        dtpersonal.Enabled = False
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()
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
        dtpersonal.Enabled = True
    End Sub

    Private Sub dtcuenta_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtcomprobantes.CellValueChanged
        Try
            If e.ColumnIndex = 1 Then
                dtcomprobantes.Item(1, dtcomprobantes.RowCount - 1) = SelFech.Clone
            ElseIf e.ColumnIndex = 5 Then
                dtcomprobantes.Item(5, dtcomprobantes.RowCount - 1) = SelFech.Clone
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtcuenta_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtcomprobantes.RowsAdded
        'dtcomprobantes.Item(2, dtcomprobantes.RowCount - 1) = tipoFac.Clone
        'dtcomprobantes.Item(5, dtcomprobantes.RowCount - 1) = tipoFac.Clone
    End Sub

    Private Sub dtcuenta_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dtcomprobantes.RowValidating

    End Sub

    Private Sub proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        deshabilitarControles()
        CargarPersonal()
        'cargamos tipos de factura en el combo
        Dim tablafac As New MySql.Data.MySqlClient.MySqlDataAdapter("select donfdesc,  abrev from tipos_comprobantes where debcred like 'D'", conexionPrinc)
        Dim readfac As New DataSet
        tablafac.Fill(readfac)
        tipoFac.DataSource = readfac.Tables(0)
        tipoFac.ValueMember = readfac.Tables(0).Columns(0).Caption.ToString
        tipoFac.DisplayMember = readfac.Tables(0).Columns(1).Caption.ToString




    End Sub

    Private Sub dtcuenta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtcomprobantes.CellContentClick

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim i As Integer
        For i = 0 To frmprincipal.MdiChildren.Length - 1
            If frmprincipal.MdiChildren(i).Name = "movimientocaja" Then
                'frmprincipal.MdiChildren(i).BringToFront()
                MsgBox("la ventana de movimiento de cuenta ya esta abierta, por favor complete la operacion antes de efectuar otra", vbCritical)
                Exit Sub
            End If
        Next

        Dim mov As New movimientodecaja
        mov.MdiParent = Me.MdiParent
        mov.movrap = True
        mov.movraptip = 6
        mov.movrapclie = dtpersonal.CurrentRow.Cells(0).Value
        mov.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        romaneo.idcomprobante = dtcomprobantes.CurrentRow.Cells(0).Value
        romaneo.Show()
        romaneo.TopMost = True
    End Sub

    Private Sub dtcomprobantes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtcomprobantes.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub proveedores_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub dtpersonal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtpersonal.CellContentClick

    End Sub
End Class