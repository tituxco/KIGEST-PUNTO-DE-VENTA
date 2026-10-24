Imports System.ComponentModel
Imports SIGT__KIGEST.GestorClientes


Public Class selclie
    ' Quitamos el "Shared" para evitar cruces de datos si abrís dos buscadores a la vez
    Public busqueda As String = ""
    Public llama As String = ""
    Public clienteSeleccionado As fact_clientes

    Private Sub SELPAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(busqueda) Then
            txtBusquedaCliente.Text = busqueda
            txtBusquedaCliente.Focus()
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
            e.SuppressKeyPress = True
            If String.IsNullOrEmpty(txtBusquedaCliente.Text) Then
                MsgBox("Debe ingresar un texto a buscar", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            IniciarBusqueda()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up Then
            If dtpersonal.Rows.Count > 0 Then
                ' Pasamos el foco a la grilla
                dtpersonal.Focus()

                ' Si la flecha fue hacia abajo y no hay nada seleccionado, forzamos seleccionar la primera fila
                If e.KeyCode = Keys.Down AndAlso dtpersonal.CurrentRow Is Nothing Then
                    dtpersonal.Rows(0).Selected = True
                    dtpersonal.CurrentCell = dtpersonal.Rows(0).Cells(0) ' Ajusta el índice (0) a la columna que quieras enfocar
                End If

                ' Evitamos que la caja de texto procese la flecha (para que no mueva el cursor de texto al final/principio)
                e.Handled = True

            End If
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
        e.Result = fact_clientes.BuscarPorNombre(textoBusqueda)
    End Sub

    Private Sub CargarDatosAsync_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CargarDatosAsync.RunWorkerCompleted
        Try
            frmprincipal.pbprincipal.Visible = False
            frmprincipal.lblprocesando.Visible = False

            ' 1. Verificamos si hubo un error en el hilo secundario
            If e.Error IsNot Nothing Then
                MsgBox("Error en la búsqueda: " & e.Error.Message, MsgBoxStyle.Critical)
                Exit Sub
            End If

            ' 2. Verificamos si se canceló
            If e.Cancelled Then Exit Sub

            ' 3. Intento de conversión segura (TryCast)
            Dim listaClientes = TryCast(e.Result, List(Of fact_clientes))

            If listaClientes IsNot Nothing Then
                ' Si la lista es correcta, la asignamos
                dtpersonal.DataSource = Nothing ' Limpiamos por las dudas
                dtpersonal.DataSource = listaClientes
            Else
                ' Si llega acá, es porque e.Result es de OTRO TIPO (ej. una lista de otra clase)
                MsgBox("Error de tipado: El resultado no es una lista de Clientes. Verifique el DoWork.", MsgBoxStyle.Exclamation)

                ' TIP: Para debuguear, podés ver qué tipo está llegando realmente:
                ' MsgBox("Tipo recibido: " & e.Result.GetType().ToString())
            End If
            ConfigurarColumnasVisibles()
        Catch ex As Exception
            MsgBox("Error en RunWorkerCompleted: " & ex.Message)
        End Try
    End Sub

    Private Sub dtpersonal_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dtpersonal.DataError
        ' Esto evita que Windows lance la ventana emergente roja de error y detenga la aplicación
        e.ThrowException = False

        ' (Opcional) Te sirve a vos como programador para debugear silenciosamente en la consola
        Console.WriteLine($"DataError en Fila {e.RowIndex}, Columna {e.ColumnIndex}: {e.Exception.Message}")
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
            Me.clienteSeleccionado = CType(dtpersonal.CurrentRow.DataBoundItem, fact_clientes)

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
            Case "nuevopedido"
                With CType(frmprincipal.ActiveMdiChild, nuevopedido)
                    .txtctaclie.Text = Me.clienteSeleccionado.idCliente
                    .txtrazon.Text = Me.clienteSeleccionado.nomapellRazon
                    .cargarCliente()
                End With

        End Select

        Me.Close()
    End Sub

    Private Sub ConfigurarColumnasVisibles()
        ' 1. Ocultamos TODAS las columnas que se autogeneran
        For Each col As DataGridViewColumn In dtpersonal.Columns
            col.Visible = False
        Next

        ' 2. Habilitamos y ordenamos solo las que pediste
        If dtpersonal.Columns.Contains("nomapellRazon") Then
            With dtpersonal.Columns("nomapellRazon")
                .Visible = True
                .HeaderText = "Razón Social / Apellido y Nombre"
                .DisplayIndex = 0
                .Width = 200
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill ' Para que ocupe el espacio principal
            End With
        End If

        If dtpersonal.Columns.Contains("dirDomicilio") Then
            With dtpersonal.Columns("dirDomicilio")
                .Visible = True
                .HeaderText = "Domicilio"
                .DisplayIndex = 1
                .Width = 100
            End With
        End If

        If dtpersonal.Columns.Contains("dirLocalidad") Then
            With dtpersonal.Columns("dirLocalidad")
                .Visible = True
                .HeaderText = "Localidad"
                .DisplayIndex = 2
                .Width = 100
            End With
        End If

        If dtpersonal.Columns.Contains("vendedor") Then
            With dtpersonal.Columns("vendedor")
                .Visible = True
                .HeaderText = "Vendedor"
                .DisplayIndex = 3
                .Width = 100
            End With
        End If
    End Sub

    Private Sub txtBusquedaCliente_TextChanged(sender As Object, e As EventArgs) Handles txtBusquedaCliente.TextChanged

    End Sub
End Class