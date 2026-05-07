Imports Microsoft.ReportingServices.Rendering.WordRenderer.WordOpenXmlRenderer.Parser
Imports SIGT__KIGEST.datosEstructura

Public Class listadoServicios
    Private Sub btnNuevaPublicidad_Click(sender As Object, e As EventArgs) Handles btnNuevaPublicidad.Click
        Dim frm As New nuevoServicio

        ' 3. PASAMOS EL ID antes de mostrarlo
        'frm.idContratoRecibido = idC

        ' 4. Abrimos el formulario
        frm.ShowDialog()
    End Sub

    Private Sub ConfigurarEstiloGrilla()
        With dgvlistado
            ' Ocultar columnas de IDs que no se deben mostrar
            If .Columns.Contains("idContrato") Then .Columns("idContrato").Visible = False
            If .Columns.Contains("idPersona") Then .Columns("idPersona").Visible = False

            ' Configurar encabezados
            .Columns("nombre_apellido").HeaderText = "Alumno"
            .Columns("dni").HeaderText = "DNI"
            .Columns("nombreCurso").HeaderText = "Curso / Servicio"
            .Columns("totalPendiente").HeaderText = "Deuda Vencida"
            .Columns("cuotasVencidas").HeaderText = "Cuotas"

            ' Evitar mostrar la propiedad 'estadoFinanciero' si no quieres texto extra, 
            ' o usarla como columna de estado:
            If .Columns.Contains("estadoFinanciero") Then
                .Columns("estadoFinanciero").HeaderText = "Estado Detallado"
                .Columns("estadoFinanciero").Width = 200
            End If

            ' Formato de Moneda y Alineación
            .Columns("totalPendiente").DefaultCellStyle.Format = "C2" ' Moneda local
            .Columns("totalPendiente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("cuotasVencidas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Autoajuste
            .Columns("nombre_apellido").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            ' Aplicar colores según la deuda
            AplicarColoresDeuda()
        End With
    End Sub

    Private Sub AplicarColoresDeuda()
        For Each fila As DataGridViewRow In dgvlistado.Rows
            ' Verificamos que la celda no sea nula y que no sea la fila de nuevo registro
            If fila.Cells("totalPendiente").Value IsNot Nothing AndAlso Not fila.IsNewRow Then
                Dim deuda As Decimal = Convert.ToDecimal(fila.Cells("totalPendiente").Value)

                If deuda > 0 Then
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235)
                    fila.Cells("totalPendiente").Style.ForeColor = Color.Red
                Else
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(235, 255, 235)
                    fila.Cells("totalPendiente").Style.ForeColor = Color.DarkGreen
                End If
            End If
        Next
    End Sub

    Private Sub CargarReporteAlumnos()
        ' 1. Obtener los datos usando tu función
        Dim datos = serv_personas.ObtenerEstadoGeneralAlumnos()

        ' 2. Asignar al DataGridView
        dgvlistado.DataSource = Nothing
        dgvlistado.DataSource = datos

        ' 3. Configurar Apariencia
        ConfigurarEstiloGrilla()
    End Sub
    Private Sub listadoServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarReporteAlumnos()
    End Sub

    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        CargarReporteAlumnos()
    End Sub

    Private Sub cmdver_Click(sender As Object, e As EventArgs) Handles cmdver.Click
        If dgvlistado.CurrentRow IsNot Nothing Then
            ' Capturamos el objeto completo de la fila para evitar errores de índice
            Dim reporte = CType(dgvlistado.CurrentRow.DataBoundItem, AlumnoEstadoReporte)

            Dim frm As New nuevoServicio
            frm.idContratoRecibido = reporte.idContrato ' Usamos la propiedad del objeto
            frm.ShowDialog()

            ' Refrescamos para ver cambios en deudas o nombres
            CargarReporteAlumnos()
        End If
    End Sub
    Private Sub dgvlistado_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvlistado.CellFormatting
        If dgvlistado.Columns(e.ColumnIndex).Name = "totalPendiente" Then
            If e.Value IsNot Nothing AndAlso CDec(e.Value) > 0 Then
                e.CellStyle.ForeColor = Color.Red
                dgvlistado.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235)
            Else
                e.CellStyle.ForeColor = Color.DarkGreen
                dgvlistado.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(235, 255, 235)
            End If
        End If
    End Sub

    Private Sub tabCtaCte_Click(sender As Object, e As EventArgs) Handles tabCtaCte.Click

    End Sub

    Private Sub tabCtaCte_Enter(sender As Object, e As EventArgs) Handles tabCtaCte.Enter
        CargarListaAlumnosABM()
    End Sub
    'Public Sub ActualizarGrilla()
    '    dgvAlumnos.DataSource = Nothing
    '    dgvAlumnos.DataSource = serv_personas.ObtenerAlumnosParaABM()
    '    ConfigurarEstilo()
    'End Sub

    'Private Sub ConfigurarEstilo()
    '    With dgvAlumnos
    '        .Columns("idPersona").Visible = False
    '        .Columns("nombre_apellido").HeaderText = "Nombre y Apellido"
    '        .Columns("nombre_apellido").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '        .Columns("cursosActivos").HeaderText = "Cursos Activos"
    '        .Columns("cursosActivos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With
    'End Sub


    ' =========================================================
    ' SECCIÓN: PESTAÑA DE SERVICIOS / CURSOS
    ' =========================================================

    Public Sub CargarListaServicios()
        dgvServicios.DataSource = Nothing
        dgvServicios.DataSource = serv_servicios.ObtenerReporteServicios()
        ConfigurarEstiloGrillaServicios()
    End Sub

    Private Sub ConfigurarEstiloGrillaServicios()
        With dgvServicios
            .Columns("idServicio").Visible = False
            .Columns("nombre").HeaderText = "Curso / Servicio"
            .Columns("nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("montoInscripcion").HeaderText = "Inscripción"
            .Columns("montoInscripcion").DefaultCellStyle.Format = "C2"
            .Columns("montoMensual").HeaderText = "Cuota"
            .Columns("montoMensual").DefaultCellStyle.Format = "C2"
            .Columns("montoExamen").HeaderText = "Examen"
            .Columns("montoExamen").DefaultCellStyle.Format = "C2"
            .Columns("alumnosActivos").HeaderText = "Alumnos Activos"
            .Columns("alumnosActivos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    ' =========================================================
    ' SECCIÓN: PESTAÑA DE ALUMNOS (ABM)
    ' =========================================================

    Public Sub CargarListaAlumnosABM()
        dgvAlumnos.DataSource = Nothing
        dgvAlumnos.DataSource = serv_personas.ObtenerAlumnosParaABM()
        ConfigurarEstiloGrillaAlumnos()
    End Sub

    Private Sub ConfigurarEstiloGrillaAlumnos()
        With dgvAlumnos
            .Columns("idPersona").Visible = False
            .Columns("nombre_apellido").HeaderText = "Nombre y Apellido"
            .Columns("nombre_apellido").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("cursosActivos").HeaderText = "Cursos Activos"
            .Columns("cursosActivos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If dgvAlumnos.CurrentRow IsNot Nothing Then
            ' 1. Obtenemos el ID de la fila seleccionada (del objeto AlumnoAbmReporte)
            Dim filaSeleccionada = CType(dgvAlumnos.CurrentRow.DataBoundItem, AlumnoAbmReporte)

            ' 2. Buscamos el objeto serv_personas completo
            Dim alumnoFull As serv_personas = serv_personas.BuscarPorID(filaSeleccionada.idPersona)

            If alumnoFull IsNot Nothing Then
                ' 3. Abrimos el formulario de edición como diálogo pasándole el objeto
                Using frmEdit As New frmInfoAlumno(alumnoFull)
                    If frmEdit.ShowDialog(Me) = DialogResult.OK Then
                        ' 4. Si guardó con éxito, refrescamos la grilla
                        CargarListaAlumnosABM()
                    End If
                End Using
            End If
        End If
    End Sub


    Private Sub tabInformes_Enter(sender As Object, e As EventArgs) Handles tabInformes.Enter
        CargarListaServicios()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If dgvServicios.CurrentRow IsNot Nothing Then
            Dim reporte = CType(dgvServicios.CurrentRow.DataBoundItem, ServicioReporte)

            ' Buscamos el objeto servicio completo para editarlo
            Dim servicioFull As serv_servicios = serv_servicios.BuscarPorID(reporte.idServicio)

            If servicioFull IsNot Nothing Then
                ' Abrimos el diálogo de edición
                Using frmEdit As New frmInfoServicio(servicioFull)
                    If frmEdit.ShowDialog(Me) = DialogResult.OK Then
                        CargarListaServicios() ' Refrescamos al guardar
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class