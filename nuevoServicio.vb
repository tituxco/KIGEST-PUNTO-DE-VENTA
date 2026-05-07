Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports SIGT__KIGEST.datosEstructura
Imports WSAFIPFE.f1AFIP
Imports WSAFIPFE.lpgAFIP
Imports WSAFIPFE.panmat

Public Class nuevoServicio
    Dim montoInscripcion As Decimal = 0
    Dim montoMensual As Decimal = 0
    Dim montoExamen As Decimal = 0
    Dim fechaInicio As Date
    Dim fechaFin As Date = Format("dd-MM-yyyy", "31-12-" & Year(Now))
    Dim idServicio As Integer
    Dim idAlumno As Integer
    Dim idCliente As Integer
    Dim serviciosDisponibles As List(Of serv_servicios)
    Dim alumnoSeleccionado As New serv_personas
    Dim servicioSeleccionado As New serv_servicios
    Public clienteSeleccionado As New fact_clientes

    Dim modoEdicion As Boolean = False
    Public idContratoRecibido As Integer = 0
    Dim contratoActual As serv_contratos
    Private Sub nuevoServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CargarServicios() ' Siempre cargamos los servicios primero

        ' Si recibimos un ID mayor a 0, activamos el modo edición
        If idContratoRecibido > 0 Then
            CargarContratoParaEdicion(idContratoRecibido)
            ActualizarInterfazDetalle()
            lbltitulo.Text = "Detalle de curso"
        End If
    End Sub

    Public Sub CargarContratoParaEdicion(idContrato As Integer)
        Try
            modoEdicion = True
            ' idContratoRecibido = idContrato

            ' 1. Obtener el contrato
            contratoActual = serv_contratos.BuscarPorID(idContrato)
            If contratoActual Is Nothing Then Exit Sub

            ' 2. Cargar Alumno y Cliente
            alumnoSeleccionado = serv_personas.BuscarPorID(contratoActual.idPersona)
            clienteSeleccionado = fact_clientes.BuscarPorID(alumnoSeleccionado.idCliente)
            ' 3. Cargar Servicio
            servicioSeleccionado = serv_servicios.BuscarPorID(contratoActual.idServicio)

            ' 4. Llenar la Interfaz
            txtDniAlumno.Text = alumnoSeleccionado.dni
            txtApellidoNombre.Text = alumnoSeleccionado.nombre_apellido
            txtCelular.Text = alumnoSeleccionado.celular
            txtDireccion.Text = alumnoSeleccionado.direccion

            txtclientecuenta.Text = clienteSeleccionado.idCliente
            txtclientenombre.Text = clienteSeleccionado.nomapellRazon

            cmbConcepto.SelectedValue = contratoActual.idServicio
            txtCostoInscripcion.Text = contratoActual.montoInscripcion
            txtCuotaMensual.Text = contratoActual.montoMensual
            txtCostoExamen.Text = contratoActual.montoExamen

            ' Ajustar fecha de inicio (solo visual, no se podrá editar)
            ' Intentamos parsear el mesInicio si es posible, sino usamos la fecha actual
            dtpFechaInicio.Value = New DateTime(contratoActual.periodo, DateTime.ParseExact(contratoActual.mesInicio, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month, 1) ' Default o lógica personalizada

            ' 5. Bloquear controles que no se pueden editar
            BloquearControlesEdicion()

            ' 6. Mostrar el plan real (el que ya está en la base de datos)
            CargarPlanRealExistente()

        Catch ex As Exception
            MsgBox("Error al cargar contrato: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarPlanRealExistente()
        Try
            ' Usamos el método que creamos antes para obtener la lista de la BD
            Dim planReal = serv_detalle.ObtenerDeudaPorAlumno(alumnoSeleccionado.id)
            dgvDetallePlan.DataSource = Nothing
            dgvDetallePlan.DataSource = planReal
            ConfigurarGrillaVistaPrevia()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BloquearControlesEdicion()
        txtDniAlumno.Enabled = False
        txtApellidoNombre.Enabled = False
        cmbConcepto.Enabled = False
        dtpFechaInicio.Enabled = False
        txtDireccion.ReadOnly = True
        txtCelular.ReadOnly = True
        cmdclientebuscar.Enabled = False
        txtclientecuenta.ReadOnly = True
        txtCostoInscripcion.ReadOnly = True ' La inscripción ya se generó        
        txtCuotaMensual.ReadOnly = False
        txtCostoExamen.ReadOnly = False
        txtclientenombre.ReadOnly = True

        ' Cambiamos el texto del botón principal
        cmdGuardarEditar.Text = "ACTUALIZAR MONTOS"
    End Sub

    Private Sub CargarServicios()
        Try
            serviciosDisponibles = datosEstructura.serv_servicios.ObtenerTodos()
            cmbConcepto.DataSource = serviciosDisponibles
            ' ESTO ES LO IMPORTANTE:
            cmbConcepto.ValueMember = "id"      ' La propiedad que identifica al objeto
            cmbConcepto.DisplayMember = "nombre" ' La propiedad que se muestra al usuario
            cmbConcepto.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("error: " + ex.Message)
        End Try
    End Sub
    Public Sub cargarDatosClientes()
        Try
            Try
                'cargamos datos de cliente
                txtclientenombre.Text = clienteSeleccionado.nomapellRazon
                txtclientecuenta.Text = clienteSeleccionado.idCliente

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox("error: " + ex.Message)
        End Try
    End Sub
    Private Function guardarAlumno() As Boolean
        Try

            If alumnoSeleccionado Is Nothing Then
                Dim alumno As New serv_personas
                Dim idAlumnoNvo As Integer = 0
                With alumno
                    .nombre_apellido = txtApellidoNombre.Text.ToUpper
                    .dni = txtDniAlumno.Text
                    .celular = txtCelular.Text
                    .direccion = txtDireccion.Text.ToUpper
                    .idCliente = clienteSeleccionado.idCliente
                End With
                idAlumnoNvo = serv_personas.Guardar(alumno)
                If idAlumnoNvo <> 0 Then
                    alumno.id = idAlumnoNvo
                    alumnoSeleccionado = alumno
                    Return True
                Else
                    Return False
                End If
            Else
                If serv_personas.Guardar(alumnoSeleccionado) <> 0 Then
                    Return True
                Else
                    Return False
                End If
            End If
            'MsgBox("Datos del alumno procesados correctamente.", MsgBoxStyle.Information)
        Catch ex As Exception

        End Try
    End Function

    Private Sub cmbConcepto_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbConcepto.SelectionChangeCommitted
        Try
            servicioSeleccionado = CType(cmbConcepto.SelectedItem, serv_servicios)
            txtCostoInscripcion.Text = servicioSeleccionado.montoInscripcion
            txtCuotaMensual.Text = servicioSeleccionado.montoMensual
            txtCostoExamen.Text = servicioSeleccionado.montoExamen
            GenerarVistaPreviaPlan()

        Catch ex As Exception
            MsgBox("error: " + ex.Message)
        End Try
    End Sub

    Private Sub txtDniAlumno_Leave(sender As Object, e As EventArgs) Handles txtDniAlumno.Leave
        Try
            alumnoSeleccionado = serv_personas.BuscarPorDNI(txtDniAlumno.Text)

            If alumnoSeleccionado IsNot Nothing Then
                ' Ya existe, llenamos los campos
                txtApellidoNombre.Text = alumnoSeleccionado.nombre_apellido
                txtCelular.Text = alumnoSeleccionado.celular
                txtDireccion.Text = alumnoSeleccionado.direccion
                txtclientecuenta.Text = alumnoSeleccionado.idCliente
                clienteSeleccionado = fact_clientes.BuscarPorID(alumnoSeleccionado.idCliente)
                txtclientenombre.Text = clienteSeleccionado.nomapellRazon
            Else
                ' No existe, limpiamos para que el usuario complete los datos del nuevo alumno
                txtApellidoNombre.Clear()
                txtCelular.Clear()
                txtDireccion.Clear()
                txtclientecuenta.Text = "0"
                txtclientenombre.Text = ""
                clienteSeleccionado = Nothing
            End If
        Catch ex As Exception
            MsgBox("error: " & ex.Message)
        End Try
    End Sub


    Private Sub txtclientenombre_KeyUp(sender As Object, e As KeyEventArgs) Handles txtclientenombre.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                selclie.llama = "nuevoServicio"
                selclie.busqueda = txtclientenombre.Text
                selclie.dtpersonal.Focus()
                selclie.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDniAlumno_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDniAlumno.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtApellidoNombre.Focus()
        End If
    End Sub

    Private Sub cmdGuardarEditar_Click(sender As Object, e As EventArgs) Handles cmdGuardarEditar.Click

        Try

            If modoEdicion Then
                ActualizarMontosFuturos()
                Exit Sub
            End If

            If clienteSeleccionado Is Nothing Then
                MsgBox("No selecciono cliente de facturacion, reintente")
                Exit Sub
            ElseIf servicioSeleccionado Is Nothing Then
                MsgBox("No selecciono servicio, reintente")
                Exit Sub
            ElseIf alumnoSeleccionado Is Nothing Then
                If guardarAlumno() = False Then
                    MsgBox("no se pudo guardar los datos del alumno")
                End If
            End If

            If Not alumnoSeleccionado Is Nothing And Not clienteSeleccionado Is Nothing And Not servicioSeleccionado Is Nothing Then
                Dim contrato As New serv_contratos
                Dim idContratoNuevo As Integer = 0
                contrato.idPersona = alumnoSeleccionado.id
                contrato.idServicio = servicioSeleccionado.id
                contrato.periodo = dtpFechaInicio.Value.Year
                contrato.mesInicio = MonthName(dtpFechaInicio.Value.Month)
                contrato.mesFin = MonthName(12)
                contrato.activo = 1
                contrato.montoExamen = servicioSeleccionado.montoExamen
                contrato.montoInscripcion = servicioSeleccionado.montoInscripcion
                contrato.montoMensual = servicioSeleccionado.montoMensual

                idContratoNuevo = serv_contratos.Guardar(contrato)
                If idContratoNuevo <> 0 Then
                    contrato.id = idContratoNuevo
                    serv_detalle.GenerarPlanCuotas(contrato, dtpFechaInicio.Value)
                    MsgBox("Curso  guardado correctamente")
                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("error: " & ex.Message)
        End Try
    End Sub

    Private Sub ActualizarMontosFuturos()
        Try
            Dim nuevoMontoMensual As Decimal = CDec(txtCuotaMensual.Text)
            Dim nuevoMontoExamen As Decimal = CDec(txtCostoExamen.Text)

            ' 1. Actualizamos el contrato principal

            serv_contratos.ActualizarMontos(idContratoRecibido, nuevoMontoMensual, nuevoMontoExamen)

            ' 2. Actualizamos el detalle (Solo lo PENDIENTE de aquí en adelante)

            serv_detalle.ActualizarPendientes(idContratoRecibido, nuevoMontoMensual, nuevoMontoExamen)

            MsgBox("Montos actualizados para cuotas pendientes.")
            CargarPlanRealExistente()
            'Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MsgBox("Error al actualizar: " & ex.Message)
        End Try
    End Sub
    Private Sub cmdclientebuscar_Click(sender As Object, e As EventArgs) Handles cmdclientebuscar.Click
        'Try
        '    ''selclie.busqueda = txtclierazon.Text
        '    'selclie.llama = "nuevoServicio"
        '    'selclie.dtpersonal.Focus()
        '    'selclie.Owner = Me

        '    'selclie.ShowDialog()


        '    Using selclie As New selclie  ' Reemplazá por el nombre real de tu clase
        '        selclie.llama = "nuevoServicio"
        '        ' selclie.busqueda = txtclierazon.Text

        '        ' PASO CRUCIAL: Al pasar (Me) como argumento, obligás a que 
        '        ' selclie sea hijo directo del diálogo actual.
        '        If selclie.ShowDialog(Me) = DialogResult.OK Then
        '            ' Aquí procesás el cliente seleccionado si es necesario
        '            'If selclie.clienteSeleccionado IsNot Nothing Then
        '            Me.txtclientecuenta.Text = selclie.clienteSeleccionado.idCliente
        '                Me.txtclientenombre.Text = selclie.clienteSeleccionado.nomapellRazon
        '            'End If
        '        End If
        '    End Using
        'Catch ex As Exception

        'End Try

        ' Seteamos los parámetros estáticos de selclie
        selclie.llama = "nuevoServicio" '"infoAlumno" ' o 
        selclie.busqueda = txtclientenombre.Text ' Opcional: pasar el texto actual

        ' Creamos la instancia
        Using buscador As New selclie
            ' Al pasar "Me", buscador queda por encima de este diálogo
            If buscador.ShowDialog(Me) = DialogResult.OK Then
                ' Si seleccionó algo y cerró con OK
                If buscador.clienteSeleccionado IsNot Nothing Then
                    clienteSeleccionado = buscador.clienteSeleccionado
                    cargarDatosClientes()
                    'Me.txtclientecuenta.Text = buscador.clienteSeleccionado.idCliente
                    'Me.txtclientenombre.Text = buscador.clienteSeleccionado.nomapellRazon
                    ' Si es el form de InfoAlumno, actualizamos el objeto interno
                    '_alumno.idCliente = buscador.clienteSeleccionado.idclientes
                End If
            End If
        End Using
    End Sub

    Private Sub GenerarVistaPreviaPlan()

        ' AGREGAR ESTA LÍNEA: Evitamos que la vista previa pise el plan real en modo edición
        If modoEdicion Then Exit Sub

        ' Validamos que haya un servicio seleccionado

        If servicioSeleccionado Is Nothing Then Exit Sub


        Dim fechaDeInicio As DateTime = dtpFechaInicio.Value

        ' Pasamos los 3 montos: mensual, inscripción y examen
        Dim miPlan = serv_detalle.CalcularPlanSimulado(servicioSeleccionado,
                                                 fechaDeInicio)

        dgvDetallePlan.DataSource = Nothing
        dgvDetallePlan.DataSource = miPlan

        ConfigurarGrillaVistaPrevia()
    End Sub

    Private Sub ConfigurarGrillaVistaPrevia()
        ' Ocultamos IDs que no le interesan al usuario en la previa
        If dgvDetallePlan.Columns.Contains("id") Then dgvDetallePlan.Columns("id").Visible = False
        If dgvDetallePlan.Columns.Contains("idContrato") Then dgvDetallePlan.Columns("idContrato").Visible = False
        If dgvDetallePlan.Columns.Contains("idPersona") Then dgvDetallePlan.Columns("idPersona").Visible = False

        ' Formateamos moneda y fecha
        dgvDetallePlan.Columns("monto").DefaultCellStyle.Format = "C2" ' Formato Moneda local
        dgvDetallePlan.Columns("vencimiento").DefaultCellStyle.Format = "dd/MM/yyyy"

        ' Ajustamos anchos
        dgvDetallePlan.Columns("detalle").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        GenerarVistaPreviaPlan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvDetallePlan.CurrentRow IsNot Nothing Then
            ' 1. Obtenemos los datos de la fila
            Dim idCuota As Integer = Convert.ToInt32(dgvDetallePlan.CurrentRow.Cells("id").Value)
            Dim estado As String = dgvDetallePlan.CurrentRow.Cells("estado").Value.ToString()
            Dim concepto As String = dgvDetallePlan.CurrentRow.Cells("detalle").Value.ToString()
            Dim monto As Decimal = Convert.ToDecimal(dgvDetallePlan.CurrentRow.Cells("monto").Value)

            If idContratoRecibido = 0 Then
                MsgBox("No hay contrato guardado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ' --- MODO 1: REENVIAR RECIBO (Sin tocar la BD) ---
            If Button1.Text = "ENVIAR RECIBO" Then
                ' Generamos el PDF interno usando el ID de la cuota como número de recibo de referencia
                GenerarReciboRDLC_PDF(txtApellidoNombre.Text, concepto, monto, "interno")

                MsgBox("Recibo generado. Preparando envío por WhatsApp...", MsgBoxStyle.Information)

                ' Enviamos el mensaje
                If MsgBox("Desea enviar WhatsApp con el recibo de pago al numero registrado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = vbYes Then
                    EnviarArchivoWhatsapp(txtCelular.Text, My.Settings.capetaAlmacenamDocum, "Hola%2C%20te%20reenvio%20el%20recibo%20del%20mes%3A%20" & concepto)
                    Me.Close()
                End If
                Exit Sub
            End If
                If Button1.Text = "IMPUTAR PAGO" Then


                ' 2. Validamos que no esté pagada ya
                If estado = "PAGADO" Then
                    MsgBox("Esta cuota ya se encuentra pagada.", MsgBoxStyle.Information)
                    Exit Sub
                ElseIf estado = "FACTURADA" Then
                    MsgBox("El pago de la cuota se debe imputar desde el sistema contable.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                If idContratoRecibido = 0 Then
                    MsgBox("No hay contrato guardado.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                ' 3. Confirmamos y cobramos
                If MsgBox("¿Confirmar el pago de esta cuota?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    If serv_detalle.RegistrarPago(idCuota) Then
                        GenerarReciboRDLC_PDF(txtApellidoNombre.Text, dgvDetallePlan.CurrentRow.Cells("detalle").Value, dgvDetallePlan.CurrentRow.Cells("monto").Value, "interno")

                        MsgBox("Pago registrado exitosamente.")

                        ' Refrescamos la grilla para que se ponga en verde
                        CargarPlanRealExistente()

                        If MsgBox("Desea enviar WhatsApp con el recibo de pago al numero registrado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = vbYes Then
                            EnviarArchivoWhatsapp(txtCelular.Text, My.Settings.capetaAlmacenamDocum, "Hola%2C%20te%20reenvio%20el%20recibo%20del%20mes%3A%20" & concepto)
                            Me.Close()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub GenerarReciboRDLC_PDF(alumno As String, concepto As String, monto As Decimal, numRecibo As String)
        Try
            ' 1. CONFIGURAR LA RUTA DE GUARDADO (Ejemplo: Documentos\Kigest_Recibos)
            Dim rutaCarpeta As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Kigest_Recibos")
            If Not Directory.Exists(rutaCarpeta) Then Directory.CreateDirectory(rutaCarpeta)

            Dim nombreArchivo As String = "ReciboInterno_" & alumno.Replace(" ", "_") & "-" & concepto.Replace(" ", "-") & ".pdf"
            Dim rutaCompleta As String = Path.Combine(My.Settings.capetaAlmacenamDocum, nombreArchivo)

            ' 2. CONFIGURAR EL REPORTE LOCAL
            Dim reporte As New LocalReport()
            reporte.ReportPath = Path.Combine(Application.StartupPath, "reportes", "ReciboInterno.rdlc")

            ' Habilitar imágenes externas para poder cargar el logo JPG
            reporte.EnableExternalImages = True

            ' 3. PREPARAR LOS PARÁMETROS Y EL LOGO
            Dim parametros As New List(Of ReportParameter)()

            ' Convertir la ruta local del logo a formato URI para que RDLC la entienda
            Dim rutaLogo As String = Path.Combine(Application.StartupPath, "logo.jpg")
            Dim uriLogo As String = New Uri(rutaLogo).AbsoluteUri

            parametros.Add(New ReportParameter("p_RutaLogo", uriLogo))
            parametros.Add(New ReportParameter("p_NumRecibo", numRecibo))
            parametros.Add(New ReportParameter("p_Fecha", DateTime.Now.ToString("dd/MM/yyyy HH:mm")))
            parametros.Add(New ReportParameter("p_Alumno", alumno))
            parametros.Add(New ReportParameter("p_Concepto", concepto))
            parametros.Add(New ReportParameter("p_Total", monto.ToString("C2")))

            reporte.SetParameters(parametros)

            ' 4. RENDERIZAR Y GUARDAR COMO PDF (La magia sucede acá, sin visor en pantalla)
            Dim bytesPDF As Byte() = reporte.Render("PDF")
            File.WriteAllBytes(rutaCompleta, bytesPDF)

            ' Mensaje final
            MsgBox("Recibo PDF generado exitosamente en:" & vbCrLf & rutaCompleta, MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Error al generar PDF con RDLC: " & ex.Message, MsgBoxStyle.Critical)
            ' Buscamos el error profundo que RDLC está ocultando
            Dim mensajeError As String = ex.Message

            If ex.InnerException IsNot Nothing Then
                mensajeError &= vbCrLf & vbCrLf & "Detalle exacto: " & ex.InnerException.Message

                ' A veces hay un tercer nivel de error escondido
                If ex.InnerException.InnerException IsNot Nothing Then
                    mensajeError &= vbCrLf & "Causa raíz: " & ex.InnerException.InnerException.Message
                End If
            End If

            MsgBox("Error al generar PDF: " & vbCrLf & mensajeError, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvDetallePlan_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDetallePlan.CellFormatting
        If dgvDetallePlan.Columns(e.ColumnIndex).Name = "estado" Then
            Dim estadoActual As String = e.Value.ToString()

            Select Case estadoActual
                Case "PAGADO"
                    e.CellStyle.BackColor = Color.LightGreen
                Case "FACTURADA"
                    e.CellStyle.BackColor = Color.LightSkyBlue ' Celeste para indicar "En proceso"
                    e.CellStyle.ForeColor = Color.Black
                Case "MOROSO"
                    e.CellStyle.BackColor = Color.LightCoral
                    e.CellStyle.ForeColor = Color.White
                Case "PENDIENTE"
                    e.CellStyle.BackColor = Color.White
            End Select
        End If
    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Try
            ' 1. Validaciones iniciales
            If dgvDetallePlan.SelectedRows.Count = 0 Then
                MsgBox("Seleccione al menos una cuota de la lista para facturar.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If idContratoRecibido = 0 Then
                MsgBox("No hay contrato guardado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ' 2. Instanciamos el Punto de Venta
            Dim vta As New puntoventa
            vta.idfacrap = My.Settings.idfacRap

            With vta
                ' ASIGNACIÓN MDI: Lo vinculamos al formulario principal
                ' Si este botón está en un formulario que ya es hijo, usamos Me.MdiParent
                .MdiParent = frmprincipal

                .Idcliente = txtclientecuenta.Text
                .condVta = 2
                .cargarCliente(False)
                .txtcodPLU.Focus()

                Dim idsCuotas As String = ""
                Dim cuotasAgregadas As Integer = 0

                ' 3. Recorremos las cuotas seleccionadas
                For Each filaCuota As DataGridViewRow In dgvDetallePlan.SelectedRows
                    Dim estadoActual As String = filaCuota.Cells("estado").Value.ToString()

                    If estadoActual = "FACTURADA" Then
                        MsgBox("Seleccionó una CUOTA FACTURADA. Debe cobrarla desde el sistema de facturación.", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    If estadoActual <> "PAGADO" Then
                        Dim idCta As String = filaCuota.Cells("id").Value.ToString()
                        Dim concepto As String = filaCuota.Cells("detalle").Value.ToString()
                        Dim monto As Decimal = Convert.ToDecimal(filaCuota.Cells("monto").Value)

                        .dtproductos.Rows.Add("0", "CTA-" & idCta, "1",
                                           "Alumno: " & alumnoSeleccionado.nombre_apellido & " - " & concepto,
                                           "21", monto, monto)

                        idsCuotas &= idCta & ","
                        cuotasAgregadas += 1
                    End If
                Next

                If cuotasAgregadas = 0 Then
                    MsgBox("Las cuotas seleccionadas ya se encuentran pagadas.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                ' 4. Datos adicionales
                .txtobservaciones.Text = "Pago de cuotas curso. Ref ID: " & idsCuotas.TrimEnd(","c)

                ' 5. MOSTRAR COMO MDI CHILD
                ' Usamos .Show() en lugar de .ShowDialog()
                .Show()

                ' Opcional: Si querés que el formulario de alumnos se cierre al abrir el facturador
                Me.Close()
            End With

        Catch ex As Exception
            MsgBox("Error al procesar el pago: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnbajacurso_Click(sender As Object, e As EventArgs) Handles btnbajacurso.Click
        If idContratoRecibido = 0 Then
            MsgBox("No hay contrato guardado.", MsgBoxStyle.Information)
            Exit Sub

        End If
        ' 1. Confirmación de seguridad
        Dim respuesta = MsgBox("¿Confirmar que el alumno abandona este curso? Se desactivará el seguimiento y la facturación.",
                               MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Baja de Curso")

        If respuesta = MsgBoxResult.Yes Then
            ' 2. Ejecutar la baja
            If serv_contratos.DesactivarInscripcion(idContratoRecibido) Then
                MsgBox("Estado actualizado: El alumno ya no figura como activo en este curso.", MsgBoxStyle.Information)
                contratoActual.activo = 0
                ' 3. Refrescar la UI del detalle
                ActualizarInterfazDetalle()

                ' Opcional: Cerrar el detalle o avisar al formulario padre que refresque la grilla general
                Me.DialogResult = DialogResult.OK
            End If
        End If
    End Sub
    Private Sub ActualizarInterfazDetalle()
        ' 1. Verificamos si es un curso nuevo (contrato no existe aún)
        If contratoActual Is Nothing Then
            lblEstadoCurso.Text = "ESTADO: SIN GUARDAR (NUEVO CURSO)"
            lblEstadoCurso.ForeColor = Color.DarkOrange

            btnbajacurso.Enabled = False
            btnPagar.Enabled = False ' No hay cuotas para pagar todavía
            Button1.Enabled = False
            Exit Sub ' Salimos de la función para que no tire error abajo
        End If

        ' 2. Si llegamos acá, el contrato existe. Evaluamos su estado:
        If contratoActual.activo = 0 Then
            lblEstadoCurso.Text = "ESTADO: DESACTIVADO (ABANDONO)"
            lblEstadoCurso.ForeColor = Color.Red

            btnbajacurso.Enabled = False
            Button1.Enabled = False
            btnPagar.Enabled = False
            cmdGuardarEditar.Enabled = False
            cmdclientebuscar.Enabled = False

        Else ' Asumimos activo = 1
            lblEstadoCurso.Text = "ESTADO: ACTIVO (EN CURSO)"
            lblEstadoCurso.ForeColor = Color.Green

            btnbajacurso.Enabled = True
            btnPagar.Enabled = True
            Button1.Enabled = True
            cmdGuardarEditar.Enabled = True
        End If
    End Sub

    Private Sub dgvDetallePlan_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDetallePlan.SelectionChanged
        Try
            If dgvDetallePlan.CurrentRow IsNot Nothing Then
                Dim estado As String = dgvDetallePlan.CurrentRow.Cells("estado").Value.ToString()

                ' Si ya está pagada o facturada fiscalmente, cambiamos a modo Reenvío
                If estado = "PAGADO" OrElse estado = "FACTURADA" Then
                    Button1.Text = "ENVIAR RECIBO"
                    ' Opcional: Cambiarle el color para que sea más intuitivo
                    ' Button1.BackColor = Color.LightSeaGreen 
                Else
                    ' Si está pendiente o moroso, vuelve a su función original
                    Button1.Text = "IMPUTAR PAGO"
                    ' Button1.BackColor = SystemColors.Control
                End If
            End If
        Catch ex As Exception
            ' Evitamos errores si la grilla se está recargando
        End Try
    End Sub
End Class