Imports System.ComponentModel
Imports System.Drawing.Printing
Imports SIGT__KIGEST.datosEstructura
Imports SIGT__KIGEST.GestorAcademia
Imports SIGT__KIGEST.GestorFacturacion
Public Class frmpagoscompra

    Public NumeroFactura As String
    Public TipoFac As Integer = 996
    Public CtaClie As Integer
    Public RazonSocial As String
    Public Direccion As String
    Public Localidad As String
    Public tipoContr As String
    Public CUIT As String
    Public Fecha As String
    Public TOTAL As String
    Public IdFacturaCTA As Integer
    Public IdFacturaComp As Integer

    Public caja As Integer
    Public almacen As Integer

    Dim IdRecibo As Integer
    Dim PtoVta As Integer = DatosAcceso.IdPtoVtaDef
    Dim NumRecibo As String

    Private Sub frmpagoscompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub frmpagoscompra_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub frmpagoscompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub

    ' =========================================================================
    ' BOTONES DE SELECCIÓN DE PAGO
    ' =========================================================================

    Private Sub btnefectivo_Click_1(sender As Object, e As EventArgs) Handles btnefectivo.Click
        Dim proxNum As Integer = GestorFacturacion.ObtenerProximoNumeroComprobante(TipoFac, CInt(PtoVta))
        NumRecibo = proxNum.ToString("0")

        Me.Text = "Recibo: " & CompletarCeros(Val(PtoVta), 2) & "-" & CompletarCeros(NumRecibo, 1)
        lbltotalefectivo.Text = TOTAL

        panelformaspago.Visible = False
        panelefectivo.Visible = True
        panelTarjetas.Visible = False
        txtefectivo.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim proxNum As Integer = GestorFacturacion.ObtenerProximoNumeroComprobante(TipoFac, CInt(PtoVta))
        NumRecibo = proxNum.ToString("0")
        Me.Text = "Recibo: " & CompletarCeros(Val(PtoVta), 2) & "-" & CompletarCeros(NumRecibo, 1)

        ' REEMPLAZAMOS EL SQL POR EL GESTOR
        Dim dtTarjetas As DataTable = GestorFacturacion.ObtenerNombresTarjetas()
        If dtTarjetas.Rows.Count > 0 Then
            txtTarjetaNombre.DataSource = dtTarjetas
            txtTarjetaNombre.DisplayMember = dtTarjetas.Columns("nombre").Caption.ToString().ToUpper()
            txtTarjetaNombre.ValueMember = dtTarjetas.Columns("id").Caption.ToString()
        End If

        panelformaspago.Visible = False
        panelefectivo.Visible = False
        panelTarjetas.Visible = True
    End Sub

    Private Sub btntarjeta_Click(sender As Object, e As EventArgs) Handles btntarjeta.Click
        Dim mov As New movimientodecaja()
        mov.MdiParent = frmprincipal
        mov.Show()
        mov.cmbtipofac.SelectedValue = 996
        mov.txtctaclie.Text = CtaClie
        mov.cargarCliente()
        mov.dtconceptos.Rows.Add(IdFacturaCTA, NumeroFactura, TOTAL, IdFacturaComp)
        mov.dtconceptos.Enabled = False
        mov.cmbtipofac.Enabled = False
        mov.Button4.Enabled = False
        mov.txttotalefectivo.Focus()
        mov.AcceptButton = mov.Button1
        mov.CalcularTotalescobro()
        Me.Close()
    End Sub

    ' =========================================================================
    ' EVENTOS DE CAJAS DE TEXTO
    ' =========================================================================

    Private Sub txtefectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtefectivo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim totalDouble As Double = FormatNumber(lbltotalefectivo.Text)
            Dim efectivo As Double = FormatNumber(txtefectivo.Text)
            txtvuelto.Text = (efectivo - totalDouble).ToString("N2")

            Me.AcceptButton = cmdfinalizarEfectivo
            cmdfinalizarEfectivo.Focus()
        End If
    End Sub

    Private Sub txtTarjetaNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarjetaNombre.KeyDown
        If e.KeyCode = Keys.Enter Then txtTarjetaAutoriza.Focus()
    End Sub

    Private Sub txtTarjetaAutoriza_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarjetaAutoriza.KeyDown
        If e.KeyCode = Keys.Enter Then cmdFinalizarTarjeta.Focus()
    End Sub

    ' =========================================================================
    ' FINALIZACIÓN UNIFICADA DE PAGOS
    ' =========================================================================

    Private Sub cmdfinalizar_Click(sender As Object, e As EventArgs) Handles cmdfinalizarEfectivo.Click
        ProcesarPago(False)
    End Sub

    Private Sub cmdFinalizarTarjeta_Click(sender As Object, e As EventArgs) Handles cmdFinalizarTarjeta.Click
        ProcesarPago(True)
    End Sub

    Private Sub ProcesarPago(esTarjeta As Boolean)
        Try
            ' 1. Revalidar correlativo
            'MsgBox("iniciando proceso de pago.....")
            Dim ptoVtaInt As Integer = CInt(PtoVta)
            Dim numReal As Integer = GestorFacturacion.ObtenerProximoNumeroComprobante(TipoFac, ptoVtaInt)
            'MsgBox("paso 1: numero de comprobante obtenido::::> " & numReal)
            If numReal = 0 Then
                MsgBox("No se pudo obtener un correlativo válido.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            NumRecibo = numReal.ToString()

            'MsgBox("paso 2: comprobando que comprobante no exista ")
            If RestringirNumerosFact(TipoFac, NumRecibo, PtoVta) = True Then
                MsgBox("El numero de comprobante ya existe para este tipo.", MsgBoxStyle.Exclamation)
                panelformaspago.Visible = False
                Exit Sub
            End If

            'MsgBox("paso 3: armando paquete de datos de recibo ")
            ' 2. ARMAMOS EL PAQUETE DE DATOS
            Dim datosPago As New DatosReciboCobro() With {
                .TipoFac = TipoFac,
                .PtoVta = ptoVtaInt,
                .NumRecibo = numReal,
                .Fecha = Fecha,
                .CtaClie = CtaClie,
                .RazonSocial = RazonSocial,
                .Direccion = Direccion,
                .Localidad = Localidad,
                .TipoContr = tipoContr,
                .CUIT = CUIT,
                .Total = ParsearDecimal(TOTAL),
                .EsTarjeta = esTarjeta,
                .TarjetaNombre = If(esTarjeta, txtTarjetaNombre.Text.ToUpper(), ""),
                .TarjetaAutorizacion = If(esTarjeta, txtTarjetaAutoriza.Text.ToUpper(), ""),
                .IdFacturaCTA = IdFacturaCTA,
                .IdFacturaComp = IdFacturaComp,
                .IdAlmacen = My.Settings.idAlmacen,
                .IdCaja = My.Settings.CajaDef
            }

            'MsgBox("paso 4: Iniciando guardado de recibo de pago ")
            ' 3. MANDAMOS AL GESTOR
            If GestorFacturacion.GuardarReciboDePago(datosPago, IdRecibo) Then

                '   MsgBox("paso 5: pago guardado, iniciando proceso de validacion de cuotas de subsistemas")
                ' 4. INTEGRACIONES (Limpitas usando el Gestor)
                MarcarCuotasComoPagadas()
                MarcarCuotaComoPagadasPublicidad()
                '  MsgBox("paso 6: proceso de pago de cuotas terminado el imputado correctamente")
                'If frmprincipal.ActiveMdiChild IsNot Nothing AndAlso TypeOf frmprincipal.ActiveMdiChild Is puntoventa Then
                '    CType(frmprincipal.ActiveMdiChild, puntoventa).Button1.PerformClick()
                'End If
                Me.Close()
            Else
                MsgBox("No se pudo registrar el pago. Revise la conexión.", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            MsgBox("Error general al procesar el pago: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    ''sistema de cursos
    Private Sub MarcarCuotasComoPagadas()
        Try
            ' Pedimos los PLUS al Gestor en vez de hacer SELECT acá
            Dim codigosCursos As List(Of String) = GestorFacturacion.ObtenerPLUsPorComprobante(IdFacturaComp, "CTA-%")

            For Each codbar As String In codigosCursos
                Dim idCuota As Integer
                If Integer.TryParse(codbar.Replace("CTA-", ""), idCuota) Then
                    serv_detalle.ActualizarEstado(idCuota, "PAGADO")
                End If
            Next
        Catch ex As Exception
            Console.WriteLine("Error Cursos: " & ex.Message)
        End Try
    End Sub

    'sistema publicidad
    Private Sub MarcarCuotaComoPagadasPublicidad()
        Try
            Dim codigosPubli As List(Of String) = GestorFacturacion.ObtenerPLUsPorComprobante(IdFacturaComp, "#%-%")

            For Each codbar As String In codigosPubli
                Dim partes() As String = codbar.Replace("#", "").Split("-"c)
                If partes.Length = 2 Then
                    Dim idCuota As Integer = Convert.ToInt32(partes(1))
                    GestorPublicidad.VincularComprobanteAutomatico(idCuota, IdRecibo, True)
                End If
            Next
        Catch ex As Exception
            Console.WriteLine("Error Publicidad: " & ex.Message)
        End Try
    End Sub

End Class