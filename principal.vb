﻿Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization
Imports System.Security.Cryptography.X509Certificates
Imports iTextSharp.text.pdf.qrcode
Imports Microsoft.ReportingServices.DataProcessing

Public Class frmprincipal
    Public loged As Boolean
    Public IPPublica As String = GetExternalIp()
    Public idFacRapX As Integer = 0 'recibo X
    Public idFacRapCB As Integer = 0 'factura B o C
    Public idFacRapA As Integer = 0 'factura A
    Dim i As Integer

    Private Sub cargarEmpresas()
        Dim tablaEmp As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_empresa2", conexionPrinc)
        Dim readEmp As New DataSet
        tablaEmp.Fill(readEmp)
        cmbempresas.ComboBox.DataSource = readEmp.Tables(0)
        cmbempresas.ComboBox.DisplayMember = readEmp.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbempresas.ComboBox.ValueMember = readEmp.Tables(0).Columns(0).Caption.ToString


        If cmbempresas.ComboBox.Items.Count > 1 Then
            cmbempresas.Visible = True
            cmbempresas.ComboBox.SelectedIndex = 0
        Else
            cmbempresas.Visible = False
            cmbempresas.ComboBox.SelectedIndex = 0
        End If
        Variables_Globales.IdEmpresa = cmbempresas.ComboBox.SelectedValue
    End Sub

    Private Sub cargarConfiguracionDeTerminal()
        Try
            Reconectar()
            Dim idEmpresa = cmbempresas.ComboBox.SelectedValue
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand
            Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand
            Dim consultaTerm As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_terminales where nombreTerminal like '" & NombreEquipo & "' and idEmpresa=" & Variables_Globales.IdEmpresa, conexionPrinc)
            Dim tablaTerm As New DataTable
            consultaTerm.Fill(tablaTerm)
            If tablaTerm.Rows.Count = 0 Then ''si la terminal no esta registrada....
                MsgBox("su terminal no esta registrada en el servidor, se procedera a agregarla para proceder a su configuracion")
                Dim sqlQuery As String = "insert into cm_terminales (nombreTerminal,idEmpresa) values ('" & NombreEquipo & "','" & Variables_Globales.IdEmpresa & "')"
                comandoadd = New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                comandoadd.ExecuteNonQuery()
                Dim idTerminal As Integer = comandoadd.LastInsertedId

                Reconectar()
                Dim consultaConfigTerm As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_terminales_configuracion", conexionPrinc)
                Dim tablaConfigTerm As New DataTable
                Dim infoConfigTerm() As DataRow

                consultaConfigTerm.Fill(tablaConfigTerm)
                If tablaConfigTerm.Rows.Count <= 1 Then ''si solo hay una configuracion disponible....
                    MsgBox("solo existe una configuracion posible para la terminal, se procedera a setearla para su equipo")
                    comandoupd = New MySql.Data.MySqlClient.MySqlCommand("update cm_terminales set idConfiguracion=" & tablaConfigTerm.Rows(0).Item("id") &
                                                                         " where nombreTerminal like '" & NombreEquipo & "' and idTerminal= " & Variables_Globales.IdEmpresa, conexionPrinc)
                    comandoupd.ExecuteNonQuery()
                    MsgBox("Configuracion guardada correctamente")
                Else
                    Dim ConfiguracionesDisponibles As String
                    For Each configuracion As DataRow In tablaConfigTerm.Rows
                        ConfiguracionesDisponibles &= configuracion.Item("id") & " - " & configuracion.Item("descripcion") & " --EMP: " & configuracion.Item("idEmpresa") & vbNewLine
                    Next

                    Dim respuesta As String = ""
                    Do While IsNothing(respuesta) Or Not IsNumeric(respuesta)
                        respuesta = InputBox("Por favor seleccione una configuracion disponible para su terminal y presione OK " & vbNewLine & ConfiguracionesDisponibles, "Aplicar configuracion de terminal", 1)
                    Loop

                    comandoupd = New MySql.Data.MySqlClient.MySqlCommand("update cm_terminales set idConfiguracion=" & respuesta & " where id= " & idTerminal, conexionPrinc)
                    comandoupd.ExecuteNonQuery()
                    MsgBox("Configuracion guardada correctamente")
                End If
                funciones_Globales.aplicarConfiguracionTerminal()
            Else
                'MsgBox("se aplicara configuracion")
                funciones_Globales.aplicarConfiguracionTerminal()
            End If

        Catch exception As Exception
            MsgBox(exception.Message)
        End Try

        'infocl = tablacl.Select("")
    End Sub



    Private Sub frmprincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        GuardarLog(DatosAcceso.Cliente, DatosAcceso.usuario, DatosAcceso.bd, "Cierre de sistema", IPPublica)
        End
    End Sub

    Private Sub frmprincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim keyCTRL As Boolean
        Dim keyALT As Boolean
        Dim key1 As Boolean
        Try
            If e.Control And e.KeyCode = Keys.NumPad1 Then
                reciboconsfinal.PerformClick()
            ElseIf e.Control And e.KeyCode = Keys.NumPad2 Then
                facturabconsfinal.PerformClick()
            ElseIf e.Control And e.KeyCode = Keys.NumPad3 Then
                FacturaA.PerformClick()
            ElseIf e.Control And e.KeyCode = Keys.NumPad4 Then
                ConsultaDeProductos.PerformClick()
            ElseIf e.Control And e.KeyCode = Keys.F12 Then
                Reconectar()
                Dim consultaconex As New MySql.Data.MySqlClient.MySqlDataAdapter("
                SELECT SUBSTRING_INDEX(host, ':', 1) AS IPConexion,db,
                GROUP_CONCAT(DISTINCT USER)   AS users,
                COUNT(*) as conexiones
                FROM   information_schema.processlist
                GROUP  BY IPConexion,db
                ORDER  BY IPConexion,db;", conexionPrinc)
                Dim tablaconex As New DataTable
                'Dim infoconex As Datata
                consultaconex.Fill(tablaconex)
                dtconexiones.DataSource = tablaconex
                If dtconexiones.Visible = True Then dtconexiones.Visible = False Else dtconexiones.Visible = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmprincipal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Function GetExternalIp() As String
        Try
            Dim ExternalIP As String
            ExternalIP = (New System.Net.WebClient()).DownloadString("http://checkip.dyndns.org/")
            ExternalIP = (New System.Text.RegularExpressions.Regex("\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")) _
                     .Matches(ExternalIP)(0).ToString()

            GuardarLog(DatosAcceso.Cliente, DatosAcceso.usuario, DatosAcceso.bd, "Acceso al sistema", ExternalIP & " (" & Environment.MachineName & ")")
            Return ExternalIP & " (" & Environment.MachineName & ")"

        Catch
            Return "ERROR IP"
        End Try
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarEmpresas()
        cargarConfiguracionDeTerminal()
        cargar_valores_generales()


        If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed = True Then
            Me.Text = Application.ProductName & " - V" & System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString & " - Usuario: " & DatosAcceso.Cliente & "-" & DatosAcceso.sistema
            Me.TopMost = False

        Else
            Me.Text = "V- " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.MajorRevision & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.MinorRevision & " - Usuario: " & DatosAcceso.Cliente & "-" & DatosAcceso.sistema
            Me.TopMost = False
            lblstatusBDprinc.Text = "Mi IP: " & IPPublica
        End If

    End Sub
    Private Sub cargar_valores_generales()
        Try
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_configuraciones order by id asc", conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)


            infocl = tablacl.Select("")
            'listaConexiones.DropDownItems.Add()
            If tablacl.Rows.Count > 6 Then
                DatosAcceso.ServMensual = infocl(7)(2) 'como se llama el servicio de mensualidad
            End If

            If InStr(DatosAcceso.Moduloacc, "1") = False Then cmdclientes.Visible = False

            If InStr(DatosAcceso.Moduloacc, "2") = False Then cmdproductos.Visible = False
            If InStr(DatosAcceso.Moduloacc, "2a") = False Then ABMProductosToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "2b") = False Then ConsultaDeProductos.Visible = False
            If InStr(DatosAcceso.Moduloacc, "2c") = False Then ManejoDePreciosToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "2d") = False Then StockToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "CONFTERM") = False Then ConfiguracionDeTerminalToolStripMenuItem.Visible = False

            If InStr(DatosAcceso.Moduloacc, "AR01") = False Then MostradorToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "AR01") = False Then EtiquetasEnBlancoToolStripMenuItem.Visible = False

            If InStr(DatosAcceso.Moduloacc, "3") = False Then cmdfacturacion.Visible = False
            If InStr(DatosAcceso.Moduloacc, "3") = False Then NuevaEfacturaToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "3b") = False Then NuevoPedidoToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "3c") = False Then reciboconsfinal.Visible = False
            If InStr(DatosAcceso.Moduloacc, "3d") = False Then facturabconsfinal.Visible = False
            If InStr(DatosAcceso.Moduloacc, "3e") = False Then FacturaA.Visible = False
            If InStr(DatosAcceso.Moduloacc, "3f") = False Then RemitosToolStripMenuItem.Visible = False

            If InStr(DatosAcceso.Moduloacc, "4") = False Then cmdadministracion.Visible = False
            If InStr(DatosAcceso.Moduloacc, "4ac") = False Then InformesDeVentasToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "4a") = False Then ContableToolStripMenuItem1.Visible = False
            If InStr(DatosAcceso.Moduloacc, "4ba") = False Then CajaToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "4bb") = False Then CajaDiariaToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "4c") = False Then ProveedoresToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "4d") = False Then AgendaDeVencimientosToolStripMenuItem.Visible = False


            If InStr(DatosAcceso.Moduloacc, "5") = False Then cmdServicios.Visible = False 'SERVICIOS
            If InStr(DatosAcceso.Moduloacc, "5KIBIT") = False Then CLOUDSERVERToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "5RYM") = False Then cmdPrestamos.Visible = False
            If InStr(DatosAcceso.Moduloacc, "6") = False Then EmpleadosToolStripMenuItem.Visible = False
            If InStr(DatosAcceso.Moduloacc, "5PUBLICIDAD") = False Then
                PublicidadToolStripMenuItem.Visible = False
            Else
                PublicidadToolStripMenuItem.Text = DatosAcceso.ServMensual
            End If

            If InStr(DatosAcceso.Moduloacc, "5TALLE") = False Then TALLERToolStripMenuItem.Visible = False

            'FacturaElectro.puntovtaelect = infocl(0)(2)
            FacturaElectro.cuit = infocl(1)(2)
            FacturaElectro.certificado = infocl(2)(2)
            FacturaElectro.passcertificado = infocl(3)(2)
            FacturaElectro.licencia = infocl(5)(2)
            ' MsgBox(tablacl.Rows.Count)
            'If tablacl.Rows.Count > 6 Then
            '    DatosAcceso.ServMensual = infocl(6)(2)
            'End If
            Dim cons2 As New MySql.Data.MySqlClient.MySqlDataAdapter("select idvendedor, idtecnico from cm_usuarios where id=" & DatosAcceso.UsuarioINT, conexionPrinc)
            Dim tabla2 As New DataTable
            Dim info2() As DataRow
            cons2.Fill(tabla2)
            info2 = tabla2.Select("")
            ' MsgBox(cons2.SelectCommand.CommandText)
            DatosAcceso.Vendedor = info2(0)(0)
            DatosAcceso.Tecnico = info2(0)(1)
            'DatosAcceso.IdAlmacen = My.Settings.idAlmacen
            DatosAcceso.StockPpref = infocl(4)(2)
            DatosAcceso.idFacRap = My.Settings.idfacRap
            DatosAcceso.IdPtoVtaDef = My.Settings.idPtoVta

            CargarInformacionEmpresa()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub tmrcomprobarConexion_Tick(sender As Object, e As EventArgs) Handles tmrcomprobarConexion.Tick
        'chequeo cada 1 segundo el estado de conexion
        Reconectar()
        Try

            'If conexionPrinc.State = ConnectionState.Broken Or conexionPrinc.State = ConnectionState.Closed Or conexionPrinc.Database = "" Then
            '    pntitulo.Enabled = False
            '    lbltitulo.Text = Application.ProductName & "(desconectado)"
            'Else
            '    pntitulo.Enabled = True
            '    lbltitulo.Text = Application.ProductName
            'End If
            'compruebo las empresas
            'lblstatusServer.Text = "Estado de servidor: " & conexionPrinc.ServerVersion & "-" & My.Settings.servidor & ": " & conexionPrinc.State.ToString'
            lblstatusBDprinc.Text = "Mi IP: " & IPPublica '& Environment.MachineName

            'lblstatcodus.Text = "Codigo de usuario: " & codus
            'lblcolaborativocon.Text = "Colaborativo con: " & conexionColab.Database
            'lblStatusEmp.Text = "Empresa Seleccionada: " & conexionEmp.State.ToString & ">>>" & conexionEmp.Database

        Catch ex As Exception
            lblstatusgral.Text = "Atencion: " & ex.Message
        End Try
    End Sub

    Private Sub CerrarConexionToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ReconectarToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Try
            Reconectar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs)
        Reconectar()
        'lblstatusServer.Text = "Estado de servidor: " & conexionPrinc.State.ToString
        lblstatusBDprinc.Text = "Base de datos principal: " & conexionPrinc.Database
        ' lblStatusEmp.Text = "Empresa Seleccionada: " & conexionEmp.State.ToString & ">>>" & conexionEmp.Database
        'Label2.Text = ""
    End Sub


    Private Sub cmdsalir_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub CientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cmdclientes.Click
        'If InStrRev(DatosAcceso.Moduloacc, 1) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "frmaspirantes" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim clientes As New frmaspirantes
        clientes.MdiParent = Me
        clientes.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cmdproductos.Click

    End Sub

    Private Sub NuevaVentaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'If InStrRev(DatosAcceso.Moduloacc, 4) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "nuevaventa" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim vta As New nuevaventa
        vta.MdiParent = Me
        vta.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ContableToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ContableToolStripMenuItem1.Click
        'If InStrRev(DatosAcceso.Moduloacc, 5) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "CONTABLE" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next
        Dim cont As New CONTABLE
        cont.MdiParent = Me
        cont.Show()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        'If InStrRev(DatosAcceso.Moduloacc, 7) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "proveedores" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim prov As New proveedores
        prov.MdiParent = Me
        prov.Show()
    End Sub

    Private Sub CajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CajaToolStripMenuItem.Click
        'If InStrRev(DatosAcceso.Moduloacc, 6) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "caja" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim caj As New caja
        caj.MdiParent = Me
        caj.Show()
    End Sub

    Private Sub ProduccionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProduccionToolStripMenuItem.Click
        'If InStrRev(DatosAcceso.Moduloacc, 8) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "produccion" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New produccion
        tec.MdiParent = Me
        tec.Show()
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'If InStrRev(DatosAcceso.Moduloacc, 3) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "pedidos" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New Presupuestos
        tec.MdiParent = Me
        tec.Show()
    End Sub




    Private Sub NuevoPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoPedidoToolStripMenuItem.Click
        'If InStrRev(DatosAcceso.Moduloacc, 3) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "pedidos" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New Presupuestos
        tec.MdiParent = Me
        tec.Show()
    End Sub

    Private Sub SincronizacionToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            SincronizarBD()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'If InStrRev(DatosAcceso.Moduloacc, 4) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "nuevaventa" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim vta As New nuevaventa
        vta.MdiParent = Me
        vta.Show()
    End Sub

    Private Sub FXConsFinalToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'If InStrRev(DatosAcceso.Moduloacc, 4) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "nuevaventa" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim vta As New nuevaventa
        vta.MdiParent = Me
        vta.fxINIC = True
        vta.Show()
    End Sub
    Private Sub NuevaEfacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaEfacturaToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "nuevaventa" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim vta As New nuevaventa
        vta.MdiParent = Me
        vta.Show()
    End Sub

    Private Sub AgendaDeVencimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgendaDeVencimientosToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "agendavencimientos" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim vta As New agendavencimientos
        vta.MdiParent = Me
        vta.Show()
    End Sub

    Private Sub reciboconsfinal_Click(sender As Object, e As EventArgs) Handles reciboconsfinal.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "puntoventa" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim vta As New puntoventa
        vta.MdiParent = Me
        vta.idfacrap = idFacRapX
        vta.Idcliente = 9999
        vta.cargarCliente(False)
        vta.txtcodPLU.Focus()
        vta.Show()
    End Sub

    Private Sub facturabconsfinal_Click(sender As Object, e As EventArgs) Handles facturabconsfinal.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "puntoventa" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim vta As New puntoventa
        vta.MdiParent = Me
        vta.idfacrap = idFacRapCB
        vta.Idcliente = 9999
        vta.cargarCliente(False)
        vta.cmdguardar.Enabled = False
        vta.cmdsolicitarcae.Enabled = True
        vta.txtcodPLU.Focus()
        vta.Show()
    End Sub

    Private Sub FacturaA_Click(sender As Object, e As EventArgs) Handles FacturaA.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "puntoventa" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim vta As New puntoventa
        vta.MdiParent = Me
        vta.idfacrap = idFacRapA
        vta.cmdguardar.Enabled = False
        vta.cmdsolicitarcae.Enabled = True
        vta.txtclierazon.Focus()
        vta.Show()
    End Sub

    Private Sub frmprincipal_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

    End Sub

    Private Sub TecnicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cmdServicios.Click

    End Sub

    Private Sub ABMProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMProductosToolStripMenuItem.Click
        'If InStrRev(DatosAcceso.Moduloacc, 2) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "productos" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim prod As New productos
        prod.MdiParent = Me
        prod.Show()
    End Sub

    Private Sub ConsultaDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeProductos.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "busquedaprod" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next
        Dim prod As New busquedaprod
        prod.MdiParent = Me
        prod.Show()
    End Sub
    Private Sub ManejoDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManejoDePreciosToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "manejodeprecios" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim prod As New manejodeprecios
        prod.MdiParent = Me
        prod.Show()
    End Sub
    Private Sub MostradorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostradorToolStripMenuItem.Click
        imprimirEtiquetas.Show()
    End Sub

    Private Sub StockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "manejoStock" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim prod As New manejoStock
        prod.MdiParent = Me
        prod.Show()
    End Sub

    Private Sub ImportarListaDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "ImportacionPrecios" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim prod As New ImportacionPrecios
        prod.MdiParent = Me
        prod.Show()
    End Sub

    Private Sub EtiquetasEnBlancoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EtiquetasEnBlancoToolStripMenuItem.Click
        imprimirEtiquetasEnBlanco.Show()
    End Sub

    Private Sub ReimpresiónDeComprobantesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReimpresiónDeComprobantesToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "reimpresionComprobantes" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim prod As New reimpresionComprobantes
        prod.MdiParent = Me
        prod.Show()
    End Sub

    Private Sub CajaDiariaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CajaDiariaToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "CajaDiaria" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim caj As New CajaDiaria
        caj.MdiParent = Me
        caj.Show()
    End Sub

    Private Sub ConfiguracionDeTerminalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguracionDeTerminalToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "ConfiguracionTerminal" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim caj As New ConfiguracionTerminal
        caj.MdiParent = Me
        caj.Show()
    End Sub

    Private Sub CLOUDSERVERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLOUDSERVERToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "frmServiciosCloud" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim caj As New frmServiciosCloud
        caj.MdiParent = Me
        caj.Show()
    End Sub

    Private Sub InformesDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformesDeVentasToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "informedeventas" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim caj As New informedeventas
        caj.MdiParent = Me
        caj.Show()
    End Sub

    Private Sub RemitosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemitosToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "puntoventa" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim vta As New puntoventa
        vta.MdiParent = Me
        vta.idfacrap = 5
        vta.Idcliente = 9999
        vta.cargarCliente(False)
        vta.txtcodPLU.Focus()
        vta.Show()
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblPrincipalDolar_Click(sender As Object, e As EventArgs) Handles lblPrincipalDolar.Click
        Try
            If InStr(DatosAcceso.Moduloacc, "4ea") = False Then Exit Sub

            Dim Cotizacion As String = InputBox("Ingrese nueva cotizacion de dolar", "Cambiar cotizacion")

            If IsNumeric(Cotizacion) Then
                Reconectar()
                Dim comandoUPD As New MySql.Data.MySqlClient.MySqlCommand("update fact_moneda set cotizacion = '" & Cotizacion.Replace(".", ",") & "' where id=2", conexionPrinc)
                comandoUPD.ExecuteNonQuery()

                lblPrincipalDolar.Text = "DOLAR: " & Cotizacion.Replace(".", ",")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblPrincipalDolar_DoubleClick(sender As Object, e As EventArgs) Handles lblPrincipalDolar.DoubleClick

    End Sub

    Private Sub SIMULADORToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SIMULADORToolStripMenuItem.Click
        'If InStrRev(DatosAcceso.Moduloacc, 4) = 0 Then
        '    MsgBox("NO esta autorizado")
        '    Exit Sub
        'End If
        'Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "prestamosForm" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim vta As New PrestamosForm
        vta.MdiParent = Me
        vta.Show()
    End Sub

    Private Sub TALLERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TALLERToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "buscarequipos" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New buscarequipos
        tec.MdiParent = Me
        'tec.idfacrap = 3
        'tec.cmdguardar.Enabled = False
        'tec.cmdsolicitarcae.Enabled = True
        'tec.txtclierazon.Focus()
        tec.Show()

    End Sub

    Private Sub LISTADOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LISTADOToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "listadoPrestamos" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New listadoPrestamos
        tec.MdiParent = Me
        'tec.idfacrap = 3
        'tec.cmdguardar.Enabled = False
        'tec.cmdsolicitarcae.Enabled = True
        'tec.txtclierazon.Focus()
        tec.Show()
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SALIRToolStripMenuItem.Click
        Application.Restart()
        Application.ExitThread()

    End Sub

    Private Sub cmdProduccion_Click(sender As Object, e As EventArgs)
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "produccion" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New produccion
        tec.MdiParent = Me
        'tec.idfacrap = 3
        'tec.cmdguardar.Enabled = False
        'tec.cmdsolicitarcae.Enabled = True
        'tec.txtclierazon.Focus()
        tec.Show()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpleadosToolStripMenuItem.Click

    End Sub

    Private Sub ListaDeEmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeEmpleadosToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "empleados" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New empleados
        tec.MdiParent = Me
        'tec.idfacrap = 3
        'tec.cmdguardar.Enabled = False
        'tec.cmdsolicitarcae.Enabled = True
        'tec.txtclierazon.Focus()
        tec.Show()
    End Sub

    Private Sub LiquidaciónDeSueldosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiquidaciónDeSueldosToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "sueldos" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New sueldos
        tec.MdiParent = Me
        'tec.idfacrap = 3
        'tec.cmdguardar.Enabled = False
        'tec.cmdsolicitarcae.Enabled = True
        'tec.txtclierazon.Focus()
        tec.Show()
    End Sub

    Private Sub MantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "mantenimiento" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New mantenimiento
        tec.MdiParent = Me
        'tec.idfacrap = 3
        'tec.cmdguardar.Enabled = False
        'tec.cmdsolicitarcae.Enabled = True
        'tec.txtclierazon.Focus()
        tec.Show()
    End Sub

    Private Sub PublicidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PublicidadToolStripMenuItem.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "listadoPublicidades" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New listadoPublicidades
        tec.MdiParent = Me
        'tec.idfacrap = 3
        'tec.cmdguardar.Enabled = False
        'tec.cmdsolicitarcae.Enabled = True
        'tec.txtclierazon.Focus()
        tec.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        modBingo.Main()

    End Sub

    Private Sub btnNotificaciones_Click(sender As Object, e As EventArgs) Handles btnNotificaciones.Click
        If DatosAcceso.debe = 1 Then 'MENSAJE DE DEUDA
            MsgBox("ATENCION: SU CUENTA DE CLOUDING REGISTRA DEUDA" & vbNewLine &
            "POR FAVOR REGULARICE SU SITUACION, COMUNIQUESE AL TEL: 3482-621473" & vbNewLine & DatosAcceso.mensaje)
        ElseIf DatosAcceso.debe = 2 Then 'solo un mensaje
            MsgBox("ATENCION MENSAJE DEL ADMINISTRADOR:" & vbNewLine & DatosAcceso.mensaje & vbNewLine &
            "POR CUALQUIER DUDA, COMUNIQUESE AL TEL: 3482-621473 O AL MAIL: INFO@KIBIT.COM.AR" & vbNewLine)
        End If
    End Sub

    Private Sub frmprincipal_MaximumSizeChanged(sender As Object, e As EventArgs) Handles Me.MaximumSizeChanged

    End Sub

    Private Sub frmprincipal_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            conexionAuth.Close()
            conexionPrinc.Close()
            conexionSEC.Close()


        Catch ex As Exception
            Debug.WriteLine("error " + ex.Message)

        End Try
    End Sub

    Private Sub cmbempresas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbempresas.SelectedIndexChanged

        Try
            If cmbempresas.SelectedIndex <> -1 Then

                CargarInformacionEmpresa(cmbempresas.ComboBox.SelectedValue)

            End If
        Catch ex As Exception

        End Try

    End Sub
End Class