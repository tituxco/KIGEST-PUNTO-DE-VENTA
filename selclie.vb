Imports System.ComponentModel

Public Class selclie
    ' Quitamos el "Shared" para evitar cruces de datos si abrís dos buscadores a la vez
    Public busqueda As String = ""
    Public llama As String = ""
    Public clienteSeleccionado As datosEstructura.fact_clientes

    Private Sub SELPAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(busqueda) Then
            txtBusquedaCliente.Text = busqueda
            IniciarBusqueda()
        End If
    End Sub

    Private Sub selclie_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Ponemos el foco en el cuadro de búsqueda apenas aparece el form
        txtBusquedaCliente.Focus()
    End Sub

    Private Sub selclie_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    ' =====================================================================
    ' 1. MOTOR DE BÚSQUEDA UNIFICADO (Orientado a Objetos y Asíncrono)
    ' =====================================================================
    Private Sub txtBusquedaCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusquedaCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrEmpty(txtBusquedaCliente.Text) Then
                MsgBox("Debe ingresar un texto a buscar", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            IniciarBusqueda()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub IniciarBusqueda()
        ' Centralizamos la animación de carga
        frmprincipal.pbprincipal.Visible = True
        frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
        frmprincipal.pbprincipal.MarqueeAnimationSpeed = 30
        frmprincipal.lblprocesando.Visible = True

        ' Pasamos el texto como argumento al Worker
        If Not CargarDatosAsync.IsBusy Then
            CargarDatosAsync.RunWorkerAsync(txtBusquedaCliente.Text)
        End If
    End Sub

    Private Sub CargarDatosAsync_DoWork(sender As Object, e As DoWorkEventArgs) Handles CargarDatosAsync.DoWork
        Dim textoBusqueda As String = e.Argument.ToString()
        e.Result = datosEstructura.fact_clientes.BuscarPorNombre(textoBusqueda)
    End Sub

    Private Sub CargarDatosAsync_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CargarDatosAsync.RunWorkerCompleted
        frmprincipal.pbprincipal.Visible = False
        frmprincipal.lblprocesando.Visible = False

        If e.Error IsNot Nothing Then
            MsgBox("Error en la búsqueda: " & e.Error.Message, MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim listaClientes As List(Of datosEstructura.fact_clientes) = CType(e.Result, List(Of datosEstructura.fact_clientes))
        dtpersonal.DataSource = listaClientes
    End Sub

    ' =====================================================================
    ' 2. LÓGICA DE SELECCIÓN (Sin código duplicado)
    ' =====================================================================
    Private Sub dtpersonal_DoubleClick(sender As Object, e As EventArgs) Handles dtpersonal.DoubleClick
        ConfirmarSeleccion()
    End Sub

    Private Sub dtpersonal_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpersonal.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True ' Evita que el Enter seleccione y baje una fila al mismo tiempo
            ConfirmarSeleccion()
        End If
    End Sub

    Private Sub ConfirmarSeleccion()
        Try
            If dtpersonal.CurrentRow Is Nothing Then Exit Sub

            ' Capturamos el objeto completo (POO puro)
            Me.clienteSeleccionado = CType(dtpersonal.CurrentRow.DataBoundItem, datosEstructura.fact_clientes)

            ' SI ES UN MÓDULO NUEVO O REFACTORIZADO (El padre captura el DialogResult.OK)
            If llama = "nuevoServicio" Or llama = "infoAlumno" Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Exit Sub
            End If

            ' SI ES UN MÓDULO VIEJO (Redirigimos al método Legacy)
            ProcesarLlamadaLegacy()

        Catch ex As Exception
            MsgBox("Error al seleccionar cliente: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' =====================================================================
    ' 3. DEUDA TÉCNICA (Eliminar esto a medida que se refactorice el sistema)
    ' =====================================================================
    Private Sub ProcesarLlamadaLegacy()
        ' Nota: Al usar DataBoundItem ahora siempre tenemos el objeto, ya no leemos la grilla celda por celda.
        Select Case llama
            Case "ptovtaNvo"
                With CType(frmprincipal.ActiveMdiChild, frmPtoVtaNvo)
                    .facturaCliente = Me.clienteSeleccionado
                    .CargarDatosCliente()
                    .CargarDatosVendedor()
                    .CargarDatosListaPrecios()
                End With

            Case "nuevaventa"
                With CType(frmprincipal.ActiveMdiChild, nuevaventa)
                    .txtctaclie.Text = Me.clienteSeleccionado.idCliente
                    .cargarCliente()
                    .cmbcondvta.Focus()
                End With

            Case "ctacte"
                With CType(frmprincipal.ActiveMdiChild, CONTABLE)
                    .txtcuentabus.Text = Me.clienteSeleccionado.idCliente
                    .cargarCuentaClie(Me.clienteSeleccionado.idCliente)
                    .dtcuentaclie.Focus()
                End With

            Case "ingresoequipo"
                With CType(frmprincipal.ActiveMdiChild, ingresoequipo)
                    .txtctaclie.Text = Me.clienteSeleccionado.idCliente
                    .cargarCliente()
                End With

            Case "movimientodecaja"
                With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                    .txtctaclie.Text = Me.clienteSeleccionado.idCliente
                    .cargarCliente()
                End With

            Case "ptovta"
                With CType(frmprincipal.ActiveMdiChild, puntoventa)
                    .Idcliente = Me.clienteSeleccionado.idCliente
                    .txtcliecta.Text = Me.clienteSeleccionado.idCliente
                    .cargarCliente(False)
                    .txtcodPLU.Focus()
                End With

            Case "prestamosform"
                With CType(frmprincipal.ActiveMdiChild, PrestamosForm)
                    .idCliente = Me.clienteSeleccionado.idCliente
                    .txtclientecuenta.Text = Me.clienteSeleccionado.idCliente
                    .txtclientenombre.Text = Me.clienteSeleccionado.nomapellRazon
                End With

            Case "nvaPublicidad"
                With CType(frmprincipal.ActiveMdiChild, NvaPublicidad)
                    .idCliente = Me.clienteSeleccionado.idCliente
                    .txtclientecuenta.Text = Me.clienteSeleccionado.idCliente
                    .txtclientenombre.Text = Me.clienteSeleccionado.nomapellRazon
                    ' Asegurate de que vendedor esté mapeado en tu clase fact_clientes
                    .idVendedor = Me.clienteSeleccionado.idVendedor
                End With

            Case "fichaequipo"
                With CType(frmprincipal.ActiveMdiChild, fichaequipo)
                    .txtctaclie.Text = Me.clienteSeleccionado.idCliente
                    .txtrazon.Text = Me.clienteSeleccionado.nomapellRazon
                End With
        End Select

        Me.Close()
    End Sub
End Class