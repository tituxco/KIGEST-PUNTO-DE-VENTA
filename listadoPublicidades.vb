Imports Org.BouncyCastle.Asn1
Imports System.ComponentModel
Imports System.Globalization
Imports System.Net.WebRequestMethods
Imports System.Text.RegularExpressions
Imports System.Windows.Interop
Imports WSAFIPFE.panmat
Imports System.Data
Public Class listadoPublicidades
    Private cmd As MySql.Data.MySqlClient.MySqlCommand
    Private da As MySql.Data.MySqlClient.MySqlDataAdapter
    Private ds As DataSet
    Dim TipoInforme As Integer
    Dim anioInforme As Integer
    Dim estadoInforme As String
    Dim periodosCancelados As String
    ' --- VARIABLES PARA BÚSQUEDA ASÍNCRONA ---
    Private filtrosActuales As GestorPublicidad.FiltrosPublicidad
    Private tipoVistaActual As GestorPublicidad.TipoVistaPublicidad
    Private dtResultadosListado As DataTable

    ''nuevos
    Private dtResultadosInforme As DataTable
    Private tipoInf As Integer
    Private anioInf As Integer
    Private estadoInf As String
    Private incluirCanceladosInf As Boolean
    Private proyPorInicioInf As Boolean ' Nueva variable de clase
    Private fechaCtaCteInf As Date
    Private busqCtaCteInf As String
    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Try

            ' 1. Efectos visuales de carga
            frmprincipal.pbprincipal.Visible = True
            frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
            frmprincipal.pbprincipal.MarqueeAnimationSpeed = 30
            frmprincipal.lblprocesando.Visible = True

            ' 2. Capturamos qué RadioButton está activo (Hacerlo acá evita errores de "Cross-Thread")
            tipoVistaActual = GestorPublicidad.TipoVistaPublicidad.Vigentes
            If rdAFacturar.Checked Then tipoVistaActual = GestorPublicidad.TipoVistaPublicidad.AFacturar
            If rdAVencer.Checked Then tipoVistaActual = GestorPublicidad.TipoVistaPublicidad.AVencer
            If rdOper.Checked Then tipoVistaActual = GestorPublicidad.TipoVistaPublicidad.Operador

            ' 3. Llenamos nuestro objeto de filtros estricto
            filtrosActuales = New GestorPublicidad.FiltrosPublicidad() With {
                .FechaDesde = dtdesdefact.Value.Date,
                .TextoBusqueda = txtbuscar.Text.Trim(),
                .SoloMorosos = chkSoloMorosos.Checked,
                .SoloSinFacturar = chksinFact.Checked,
                .Concepto = If(cmbconcepto.SelectedIndex <> -1, cmbconcepto.Text.ToUpper(), String.Empty),
                .OrdenarPor = If(cmbOrdenarPor.SelectedIndex <> -1, cmbOrdenarPor.Text, "CLIENTE asc")
            }

            ' Extraemos los IDs de los combos
            If cmbvendedor.SelectedIndex <> -1 AndAlso IsNumeric(cmbvendedor.SelectedValue) Then
                filtrosActuales.IdVendedor = Convert.ToInt32(cmbvendedor.SelectedValue)
            End If

            If cmbcobrador.SelectedIndex <> -1 AndAlso IsNumeric(cmbcobrador.SelectedValue) Then
                filtrosActuales.IdCobrador = Convert.ToInt32(cmbcobrador.SelectedValue)
            End If

            'sgBox(filtrosActuales)
            ' 4. Disparamos la búsqueda asíncrona
            CargarListadoOrdenesAsync.RunWorkerAsync()

        Catch ex As Exception
            MsgBox("Error al preparar la búsqueda: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdver_Click(sender As Object, e As EventArgs) Handles cmdver.Click
        If dgvPrestamos.dgvVista.CurrentRow IsNot Nothing Then
            Dim idPubli As String = dgvPrestamos.dgvVista.CurrentRow.Cells(0).Value.ToString()
            AbrirFormularioPublicidad(idPubli, Nothing, False)

            ' Corrección específica para este botón que sí permite editar
            If frmprincipal.ActiveMdiChild.Name = "NvaPublicidad" Then
                CType(frmprincipal.ActiveMdiChild, NvaPublicidad).cmdGuardarEditar.Enabled = True
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnNuevaPublicidad.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "NvaPublicidad" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New NvaPublicidad
        tec.MdiParent = Me.MdiParent
        tec.diasMora = txtdiasmora.Text

        tec.NvaPubli = True
        tec.Show()
    End Sub

    Private Sub listadoPublicidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tablavend As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,', ', nombre) from fact_vendedor where activo=1", GestorConexiones.conexionPrinc)
        Dim readvend As New DataSet
        tablavend.Fill(readvend)
        cmbvendedor.DataSource = readvend.Tables(0)
        cmbvendedor.DisplayMember = readvend.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbvendedor.ValueMember = readvend.Tables(0).Columns(0).Caption.ToString
        cmbvendedor.SelectedIndex = -1

        Dim tablacob As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,', ', nombre) from fact_cobrador where activo=1", GestorConexiones.conexionPrinc)
        Dim readcob As New DataSet
        tablacob.Fill(readcob)
        cmbcobrador.DataSource = readcob.Tables(0)
        cmbcobrador.DisplayMember = readcob.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbcobrador.ValueMember = readcob.Tables(0).Columns(0).Caption.ToString
        cmbcobrador.SelectedIndex = -1
        dgvPrestamos.dgvVista.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Dim tablacons As New MySql.Data.MySqlClient.MySqlDataAdapter("select DISTINCT (concepto) from rym_prestamo  order by CONCEPTO desc", GestorConexiones.conexionPrinc)
        Dim readcons As New DataSet
        tablacons.Fill(readcons)
        cmbconcepto.DataSource = readcons.Tables(0)
        cmbconcepto.DisplayMember = readcons.Tables(0).Columns(0).Caption.ToString.ToUpper
        cmbconcepto.SelectedIndex = -1
        If InStr(DatosAcceso.Moduloacc, "OPERADORRAD") <> 0 Then
            rdOper.Checked = True
            rdAVencer.Visible = False
            rdvigentes.Visible = False
            btnExportar.Visible = False
            btnFacturar.Visible = False
            btnNuevaPublicidad.Visible = False
            cmdver.Visible = False


        End If
        Me.Text = "LISTADO " & DatosAcceso.ServMensual
        dtdesdefact.Value = obtenerPrimerDiaMes()
        Label1.Text = DatosAcceso.ServMensual
        tabListadoSerivicios.Text = DatosAcceso.ServMensual
        'cmdbuscar.PerformClick()

    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click
        Try
            ' 1. Validamos que haya una fila seleccionada para evitar errores
            If dgvPrestamos.dgvVista.CurrentRow Is Nothing Then Exit Sub

            ' 2. Capturamos los datos de la grilla de forma ESTRICTA
            Dim idPublicidad As Integer = Convert.ToInt32(dgvPrestamos.dgvVista.CurrentRow.Cells("ID_PUBLICIDAD").Value)

            ' IMPORTANTE: Asegurate de que tu grilla ahora traiga el ID de rym_detalle_prestamo (la cuota)
            Dim idCuota As Integer = Convert.ToInt32(dgvPrestamos.dgvVista.CurrentRow.Cells("ID_CUOTA").Value)

            Dim idCliente As Integer = Convert.ToInt32(dgvPrestamos.dgvVista.CurrentRow.Cells("idclientes").Value)
            Dim concepto As String = Convert.ToString(dgvPrestamos.dgvVista.CurrentRow.Cells("CONCEPTO").Value)
            Dim montoMensual As Decimal = Convert.ToDecimal(dgvPrestamos.dgvVista.CurrentRow.Cells("MONTO_MENSUAL").Value)
            Dim vendedor As String = Convert.ToString(dgvPrestamos.dgvVista.CurrentRow.Cells("vendedor").Value)
            Dim observaciones As String = Convert.ToString(dgvPrestamos.dgvVista.CurrentRow.Cells("DESCRIPCION").Value)

            ' 3. Armamos la NUEVA codificación exacta: #idpublicidad-idcuota
            Dim codigoFacturacion As String = $"#{idPublicidad}-{idCuota}"

            ' 4. Verificamos si EXACTAMENTE esta cuota ya fue facturada
            If ElementoFacturado(codigoFacturacion) = True Then
                If MsgBox("ESTA CUOTA DE PUBLICIDAD YA HA SIDO FACTURADA. ¿ESTÁ SEGURO QUE DESEA FACTURARLA NUEVAMENTE?",
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Question,
                      "PUBLICIDAD YA FACTURADA") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            ' 5. Instanciamos el Punto de Venta
            Dim vta As New puntoventa
            vta.MdiParent = Me.MdiParent
            vta.idfacrap = My.Settings.idfacRap

            With vta
                .Idcliente = idCliente.ToString()
                .condVta = 2
                .cargarCliente(False)
                .txtcodPLU.Focus()

                ' Armamos la descripción elegante (Ej: "PUBLICIDAD RADIO #15-3 (MAYO 2024)")
                Dim mesFacturado As String = Now().AddMonths(-1).ToString("MMMM yyyy").ToUpper()
                Dim descripcionItem As String = $"{concepto} {codigoFacturacion} ({mesFacturado})"

                ' Agregamos la fila al facturador (Pasamos los valores numéricos limpios)
                .dtproductos.Rows.Add("0", codigoFacturacion, "1", descripcionItem, "21", montoMensual, montoMensual)

                .condVta = 2
                .lblfacvendedor.Text = vendedor
                .txtobservaciones.Text = observaciones

                ' Mostramos el facturador
                .Show()
            End With

        Catch ex As Exception
            MsgBox("Error al enviar a facturar: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        frmprincipal.pbprincipal.Visible = True
        frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
        frmprincipal.pbprincipal.MarqueeAnimationSpeed = 30

        CargarExcelAsyncListadoOR.RunWorkerAsync()




        frmprincipal.pbprincipal.Visible = True
        frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
        frmprincipal.pbprincipal.MarqueeAnimationSpeed = 30

        CargarExcelAsync.RunWorkerAsync()

    End Sub

    Private Sub rdAFacturar_CheckedChanged(sender As Object, e As EventArgs) Handles rdAFacturar.CheckedChanged
        If rdAFacturar.Checked = True Then
            dtdesdefact.Enabled = False
        Else
            dtdesdefact.Enabled = True
        End If

    End Sub

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged

    End Sub

    Private Sub txtbuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdbuscar.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ' Capturamos valores de la UI
            fechaCtaCteInf = dtpFechaCtaCte.Value
            busqCtaCteInf = txtbusqctacte.Text.Trim()

            ' Visuales de carga (reutilizando lo que ya tenemos)
            frmprincipal.pbprincipal.Visible = True
            frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
            frmprincipal.lblprocesando.Visible = True
            frmprincipal.lblprocesando.Text = "Consultando Cta. Cte., por favor espere..."

            ' Usamos un flag o un modo para que el DoWork sepa qué consulta ejecutar
            ' Por ahora, si solo este botón llama a este proceso:
            CargarCtaCteAsync.RunWorkerAsync()

        Catch ex As Exception
            MsgBox("Error al iniciar consulta: " & ex.Message)
        End Try
    End Sub
    Private Sub CargarCtaCteAsync_DoWork(sender As Object, e As DoWorkEventArgs) Handles CargarCtaCteAsync.DoWork
        Try
            ' Llamada al Gestor
            dtResultadosListado = GestorPublicidad.ObtenerListadoCtaCte(fechaCtaCteInf, busqCtaCteInf)
        Catch ex As Exception
            e.Result = ex
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If dgvCtaCte.dgvVista.CurrentRow IsNot Nothing Then
            Dim idPubli As String = dgvCtaCte.dgvVista.CurrentRow.Cells(0).Value.ToString()
            Dim idVend As Object = dgvCtaCte.dgvVista.CurrentRow.Cells("VENDEDOR").Value
            AbrirFormularioPublicidad(idPubli, idVend, False)
        End If
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsNumeric(txtanio.Text) Then
            MsgBox("Ingrese un año válido para ver (ej: 2026)", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' Capturamos la UI
        anioInf = Convert.ToInt32(txtanio.Text)
        tipoInf = cmbinforme.SelectedIndex
        estadoInf = cmbestadoInforme.Text
        incluirCanceladosInf = chkPeriodosCancelados.CheckState

        proyPorInicioInf = rdporfechadeinicio.Checked

        ' Efectos visuales
        frmprincipal.pbprincipal.Visible = True
        frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
        frmprincipal.lblprocesando.Visible = True

        ' Disparamos el hilo
        CargarDatosAsync.RunWorkerAsync()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        '        GenerarExcel(dgvInformes.dgvVista)
        frmprincipal.pbprincipal.Visible = True
        frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
        frmprincipal.pbprincipal.MarqueeAnimationSpeed = 30

        CargarExcelAsync.RunWorkerAsync()
    End Sub

    Private Sub CargarDatosAsync_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles CargarDatosAsync.DoWork

        Try
            If tipoInf = 0 Then
                ' Informe 0: El Pivot Anual
                ' Obtenemos los datos directamente. Al quitar la suma y la limpieza, 
                ' evitamos cualquier error de conversión de texto a número.
                dtResultadosInforme = GestorPublicidad.ObtenerInformeAnualPivot(anioInf, proyPorInicioInf)

            ElseIf tipoInf = 1 Then
                ' Informe 1: Detallado por Estado
                dtResultadosInforme = GestorPublicidad.ObtenerInformeDetallado(anioInf, estadoInf, incluirCanceladosInf)

            End If

        Catch ex As Exception
            e.Result = ex
        End Try

    End Sub

    Private Sub CargarDatosAsync_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles CargarDatosAsync.ProgressChanged
        'no hay progreso

    End Sub

    Private Sub CargarDatosAsync_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CargarDatosAsync.RunWorkerCompleted
        'frmprincipal.pbprincipal.Visible = False
        'frmprincipal.lblprocesando.Visible = False

        Try
            frmprincipal.pbprincipal.Visible = False
            frmprincipal.lblprocesando.Visible = False

            If e.Result IsNot Nothing AndAlso TypeOf e.Result Is Exception Then
                Dim ex As Exception = DirectCast(e.Result, Exception)
                MsgBox("Error al generar el informe: " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End If
            AddMonthlyTotals(dtResultadosInforme)
            If dtResultadosInforme IsNot Nothing Then
                dgvInformes.Cargar_Datos(dtResultadosInforme)
                If dgvInformes.dgvVista.Columns.Count > 0 Then
                    dgvInformes.dgvVista.Columns(0).Visible = True
                End If
            End If



        Catch ex As Exception
            MsgBox("Error al mostrar el informe: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    ' Extrae número y marcador de una celda (ej: "1234.56 (**)" -> 1234.56, "(**)")
    ' Extrae número y marcador de una celda (ej: "1234.56 (**)" -> 1234.56, "(**)")
    Private Function ExtractNumberAndMarker(cell As String) As Tuple(Of Double, String)
        If String.IsNullOrWhiteSpace(cell) Then
            Return Tuple.Create(0.0, String.Empty)
        End If

        Dim s As String = cell.Trim()

        Dim marker As String = String.Empty
        If s.Contains("(**)") Then
            marker = "(**)"
        ElseIf s.Contains("(*)") Then
            marker = "(*)"
        End If

        If marker <> String.Empty Then
            s = s.Replace(marker, "").Trim()
        End If

        Dim m As Match = Regex.Match(s, "[-]?\d+(\.\d+)?")
        If m.Success Then
            Dim numStr As String = m.Value
            Dim value As Double
            If Double.TryParse(numStr, NumberStyles.Any, CultureInfo.InvariantCulture, value) Then
                Return Tuple.Create(value, marker)
            End If
        End If

        Return Tuple.Create(0.0, marker)
    End Function

    ' Suma totales por columnas mensuales y agrega fila "Total" al DataTable
    Public Sub AddMonthlyTotals(ByRef dt As DataTable)
        Dim months As String() = {"enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"}

        Dim totals(11) As Double
        Dim markers(11) As String
        For i As Integer = 0 To 11
            totals(i) = 0.0
            markers(i) = String.Empty
        Next

        For Each row As DataRow In dt.Rows
            For i As Integer = 0 To months.Length - 1
                Dim colName As String = months(i)
                If dt.Columns.Contains(colName) Then
                    Dim cellObj = row(colName)
                    Dim cellStr As String = If(cellObj Is Nothing OrElse IsDBNull(cellObj), String.Empty, cellObj.ToString())
                    Dim parsed As Tuple(Of Double, String) = ExtractNumberAndMarker(cellStr)
                    totals(i) += parsed.Item1
                    If parsed.Item2 = "(**)" Then
                        markers(i) = "(**)"
                    ElseIf parsed.Item2 = "(*)" AndAlso markers(i) <> "(**)" Then
                        markers(i) = "(*)"
                    End If
                End If
            Next
        Next

        Dim totalRow As DataRow = dt.NewRow()
        If dt.Columns.Contains("IDPUBLICIDAD") Then totalRow("IDPUBLICIDAD") = DBNull.Value
        If dt.Columns.Contains("idClientes") Then totalRow("idClientes") = DBNull.Value
        If dt.Columns.Contains("nomapell_razon") Then totalRow("nomapell_razon") = "TOTAL"
        If dt.Columns.Contains("CONCEPTO") Then totalRow("CONCEPTO") = DBNull.Value
        If dt.Columns.Contains("DESCRIPCION") Then totalRow("DESCRIPCION") = DBNull.Value

        For i As Integer = 0 To months.Length - 1
            Dim colName As String = months(i)
            If dt.Columns.Contains(colName) Then
                Dim formatted As String = totals(i).ToString("N2", CultureInfo.InvariantCulture)
                If markers(i) <> String.Empty Then
                    formatted &= " " & markers(i)
                End If
                totalRow(colName) = formatted
            End If
        Next

        If dt.Columns.Contains("total") Then
            Dim grandTotal As Double = totals.Sum()
            Dim grandMarker As String = String.Empty
            If markers.Any(Function(m) m = "(**)") Then
                grandMarker = "(**)"
            ElseIf markers.Any(Function(m) m = "(*)") Then
                grandMarker = "(*)"
            End If
            Dim formattedGrand As String = grandTotal.ToString("N2", CultureInfo.InvariantCulture)
            If grandMarker <> String.Empty Then formattedGrand &= " " & grandMarker
            totalRow("total") = formattedGrand
        End If

        dt.Rows.Add(totalRow)
    End Sub
    Private Sub CargarExcelAsync_DoWork(sender As Object, e As DoWorkEventArgs) Handles CargarExcelAsync.DoWork
        GenerarExcelDT(dgvInformes.todos_los_datos)
    End Sub

    Private Sub CargarExcelAsync_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CargarExcelAsync.RunWorkerCompleted
        frmprincipal.pbprincipal.Visible = False

        frmprincipal.lblprocesando.Visible = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbestadoInforme.SelectedIndexChanged

    End Sub

    Private Sub tabInformes_Click(sender As Object, e As EventArgs) Handles tabInformes.Click

    End Sub

    Private Sub tabInformes_Enter(sender As Object, e As EventArgs) Handles tabInformes.Enter
        cmbestadoInforme.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            Dim idSeleccionado As String = dgvInformes.dgvVista.CurrentRow.Cells(0).Value.ToString()
            Dim yaAbierto As Boolean = False

            ' 1. Intentar encontrar el formulario abierto
            For Each hijo As Form In Me.MdiParent.MdiChildren
                If hijo.Name = "NvaPublicidad" Then
                    yaAbierto = True
                    hijo.BringToFront()

                    With CType(hijo, NvaPublicidad)
                        .txtBuscaPrestamo.Text = idSeleccionado
                        .txtPrestamo.Text = idSeleccionado
                        .diasMora = txtdiasmora.Text
                        .NvaPubli = False
                        .cmdGuardarEditar.Enabled = False
                        .btnCalcular.Enabled = False
                        .btnPagar.Enabled = True
                        ' Llamamos al método que ahora hace la carga completa (Grilla + Cliente)
                        .CargarDetalle()
                    End With
                    Exit For
                End If
            Next

            ' 2. Si no estaba abierto, lo creamos
            If Not yaAbierto Then
                Dim form As New NvaPublicidad With {
                    .MdiParent = Me.MdiParent
                }
                form.txtBuscaPrestamo.Text = idSeleccionado
                form.txtPrestamo.Text = idSeleccionado
                form.diasMora = txtdiasmora.Text
                form.NvaPubli = False
                form.cmdGuardarEditar.Enabled = False
                form.btnCalcular.Enabled = False
                form.btnPagar.Enabled = True

                ' IMPORTANTE: Llamar a CargarDetalle aquí también
                form.CargarDetalle()
                form.Show()
            End If

        Catch ex As Exception
            MsgBox("Error al abrir el detalle de publicidad: " & ex.Message, MsgBoxStyle.Critical)
        End Try
        'Try
        '    Dim i As Integer
        '    For i = 0 To frmprincipal.MdiChildren.Count - 1
        '        If frmprincipal.MdiChildren(i).Name = "NvaPublicidad" Then
        '            frmprincipal.MdiChildren(i).BringToFront()
        '            With CType(frmprincipal.MdiChildren(i), NvaPublicidad)
        '                .txtBuscaPrestamo.Text = dgvInformes.dgvVista.CurrentRow.Cells(0).Value
        '                .txtPrestamo.Text = dgvInformes.dgvVista.CurrentRow.Cells(0).Value
        '                .diasMora = txtdiasmora.Text
        '                .NvaPubli = False
        '                .cmdGuardarEditar.Enabled = False
        '                .btnCalcular.Enabled = False
        '                .btnPagar.Enabled = True
        '                .CargarDetalle()
        '            End With
        '            Exit Sub
        '        End If
        '    Next

        '    Dim form As New NvaPublicidad
        '    form.MdiParent = Me.MdiParent
        '    form.Show()
        '    form.txtBuscaPrestamo.Text = dgvInformes.dgvVista.CurrentRow.Cells(0).Value
        '    form.txtPrestamo.Text = dgvInformes.dgvVista.CurrentRow.Cells(0).Value
        '    form.NvaPubli = False
        '    form.cmdGuardarEditar.Enabled = False
        '    form.btnCalcular.Enabled = False
        '    form.btnPagar.Enabled = True
        '    form.diasMora = txtdiasmora.Text


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    'Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    '    Try
    '        Dim i As Integer
    '        For i = 0 To frmprincipal.MdiChildren.Count - 1
    '            If frmprincipal.MdiChildren(i).Name = "CONTABLE" Then
    '                frmprincipal.MdiChildren(i).BringToFront()
    '                With CType(frmprincipal.MdiChildren(i), CONTABLE)
    '                    .txtcuentabus.Text = dgvInformes.dgvVista.CurrentRow.Cells("idClientes").Value
    '                    .txtcliebus.Text = dgvInformes.dgvVista.CurrentRow.Cells("nomapell_razon").Value.ToString.ToUpper
    '                    .cargarCuentaClie(Val(dgvInformes.dgvVista.CurrentRow.Cells("idClientes").Value))
    '                    .tabcontable.SelectedTab = .tabcuentasclientes
    '                End With
    '                Exit Sub
    '            End If
    '        Next
    '        Dim ventana As New CONTABLE
    '        ventana.MdiParent = Me.MdiParent
    '        With ventana
    '            .Show()
    '            .txtcuentabus.Text = dgvInformes.dgvVista.CurrentRow.Cells("idClientes").Value
    '            .txtcliebus.Text = dgvInformes.dgvVista.CurrentRow.Cells("nomapell_razon").Value.ToString.ToUpper
    '            .cargarCuentaClie(Val(dgvInformes.dgvVista.CurrentRow.Cells("idClientes").Value))
    '            .tabcontable.SelectedTab = .tabcuentasclientes
    '        End With


    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If dgvInformes.dgvVista.CurrentRow IsNot Nothing Then
            Dim idClie As String = dgvInformes.dgvVista.CurrentRow.Cells("idClientes").Value.ToString()
            Dim nomClie As String = dgvInformes.dgvVista.CurrentRow.Cells("nomapell_razon").Value.ToString()
            AbrirFormularioContable(idClie, nomClie)
        End If
    End Sub
    'Private Sub CargarListadoOrdenesAsync_DoWork(sender As Object, e As DoWorkEventArgs) Handles CargarListadoOrdenesAsync.DoWork
    '    cargarListadoOrdenes()
    'End Sub
    'Private Sub CargarListadoOrdenesAsync_DoWork(sender As Object, e As DoWorkEventArgs) Handles CargarListadoOrdenesAsync.DoWork
    '    Try
    '        ' Acá estamos en el hilo secundario. ¡Solo hablamos con el Gestor, no tocamos la UI!
    '        dtResultadosListado = DominioPublicidad.GestorPublicidad.ObtenerListado(tipoVistaActual, filtrosActuales)
    '    Catch ex As Exception
    '        ' Pasamos el error al hilo principal
    '        e.Result = ex
    '    End Try
    'End Sub


    'Private Sub CargarListadoOrdenesAsync_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CargarListadoOrdenesAsync.RunWorkerCompleted
    '    Try
    '        frmprincipal.pbprincipal.Visible = False
    '        frmprincipal.lblprocesando.Visible = False
    '        dgvPrestamos.dgvVista.Columns(0).Visible = True
    '        dgvPrestamos.dgvVista.Columns("VencActual").Visible = False
    '        dgvPrestamos.dgvVista.Columns("idclientes").Visible = False
    '        dgvPrestamos.dgvVista.Columns("DESCRIPCION").Visible = True
    '        ' dgvPrestamos.dgvVista.Columns("MESES_DEBE").Visible = False
    '        dgvPrestamos.dgvVista.Columns("MONTO_TOTAL").Visible = False
    '        dgvPrestamos.dgvVista.Columns("SALDO").Visible = False
    '        dgvPrestamos.dgvVista.Columns("vendedor").Visible = False
    '        'DataGridView1.DataSource = ds.Tables(0)
    '    Catch ex As Exception

    '    End Try

    'End Sub
    Private Sub CargarListadoOrdenesAsync_DoWork(sender As Object, e As DoWorkEventArgs) Handles CargarListadoOrdenesAsync.DoWork
        Try
            ' Acá estamos en el hilo secundario. ¡Solo hablamos con el Gestor, no tocamos la UI!
            dtResultadosListado = GestorPublicidad.ObtenerListado(tipoVistaActual, filtrosActuales)
        Catch ex As Exception
            ' Pasamos el error al hilo principal
            e.Result = ex
        End Try
    End Sub

    Private Sub CargarListadoOrdenesAsync_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CargarListadoOrdenesAsync.RunWorkerCompleted
        Try
            ' 1. Apagamos la carga visual
            frmprincipal.pbprincipal.Visible = False
            frmprincipal.lblprocesando.Visible = False

            ' 2. Verificamos si hubo un error en el hilo secundario
            If e.Result IsNot Nothing AndAlso TypeOf e.Result Is Exception Then
                Dim ex As Exception = DirectCast(e.Result, Exception)
                MsgBox("Error en la base de datos: " & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End If

            ' 3. Volcamos los datos limpios a la grilla
            If dtResultadosListado IsNot Nothing AndAlso dtResultadosListado.Rows.Count > 0 Then
                dgvPrestamos.Cargar_Datos(dtResultadosListado)

                ' Ocultamos/Mostramos columnas con seguridad verificando que existan
                dgvPrestamos.dgvVista.Columns(0).Visible = True
                If dgvPrestamos.dgvVista.Columns.Contains("VencActual") Then dgvPrestamos.dgvVista.Columns("VencActual").Visible = False
                If dgvPrestamos.dgvVista.Columns.Contains("idclientes") Then dgvPrestamos.dgvVista.Columns("idclientes").Visible = False
                If dgvPrestamos.dgvVista.Columns.Contains("DESCRIPCION") Then dgvPrestamos.dgvVista.Columns("DESCRIPCION").Visible = True
                If dgvPrestamos.dgvVista.Columns.Contains("MONTO_TOTAL") Then dgvPrestamos.dgvVista.Columns("MONTO_TOTAL").Visible = False
                If dgvPrestamos.dgvVista.Columns.Contains("SALDO") Then dgvPrestamos.dgvVista.Columns("SALDO").Visible = False
                If dgvPrestamos.dgvVista.Columns.Contains("vendedor") Then dgvPrestamos.dgvVista.Columns("vendedor").Visible = False
            Else
                dgvPrestamos.Cargar_Datos(Nothing)
                MsgBox("No se encontraron publicidades con los filtros seleccionados.", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("Error al mostrar los datos: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Dim i As Integer
            For i = 0 To frmprincipal.MdiChildren.Count - 1
                If frmprincipal.MdiChildren(i).Name = "CONTABLE" Then
                    frmprincipal.MdiChildren(i).BringToFront()
                    With CType(frmprincipal.MdiChildren(i), CONTABLE)
                        .txtcuentabus.Text = dgvPrestamos.dgvVista.CurrentRow.Cells("idClientes").Value
                        .txtcliebus.Text = dgvPrestamos.dgvVista.CurrentRow.Cells("CLIENTE").Value.ToString.ToUpper
                        .cargarCuentaClie(Val(dgvPrestamos.dgvVista.CurrentRow.Cells("idClientes").Value))
                        .tabcontable.SelectedTab = .tabcuentasclientes
                    End With
                    Exit Sub
                End If
            Next
            Dim ventana As New CONTABLE
            ventana.MdiParent = Me.MdiParent
            With ventana
                .Show()
                .txtcuentabus.Text = dgvPrestamos.dgvVista.CurrentRow.Cells("idClientes").Value
                .txtcliebus.Text = dgvPrestamos.dgvVista.CurrentRow.Cells("CLIENTE").Value.ToString.ToUpper
                .cargarCuentaClie(Val(dgvPrestamos.dgvVista.CurrentRow.Cells("idClientes").Value))
                .tabcontable.SelectedTab = .tabcuentasclientes
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarExcelAsyncListadoOR_DoWork(sender As Object, e As DoWorkEventArgs) Handles CargarExcelAsyncListadoOR.DoWork
        GenerarExcelDT(dgvPrestamos.todos_los_datos)
    End Sub

    Private Sub CargarExcelAsyncListadoOR_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CargarExcelAsyncListadoOR.RunWorkerCompleted
        frmprincipal.pbprincipal.Visible = False

        frmprincipal.lblprocesando.Visible = False
    End Sub


    ' --- MÉTODOS AUXILIARES PARA NAVEGACIÓN ---

    Private Sub AbrirFormularioPublicidad(idPublicidad As String, idVendedor As Object, esNueva As Boolean)
        Try
            ' 1. Buscamos si ya está abierto
            For Each child As Form In frmprincipal.MdiChildren
                If child.Name = "NvaPublicidad" Then
                    child.BringToFront()
                    ConfigurarFormularioPublicidad(CType(child, NvaPublicidad), idPublicidad, idVendedor, esNueva)
                    Exit Sub
                End If
            Next

            ' 2. Si no está abierto, lo creamos
            Dim formNvaPubli As New NvaPublicidad()
            formNvaPubli.MdiParent = Me.MdiParent
            formNvaPubli.Show()
            ConfigurarFormularioPublicidad(formNvaPubli, idPublicidad, idVendedor, esNueva)

        Catch ex As Exception
            MsgBox("Error al abrir publicidad: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ConfigurarFormularioPublicidad(form As NvaPublicidad, idPublicidad As String, idVendedor As Object, esNueva As Boolean)
        form.txtBuscaPrestamo.Text = idPublicidad
        form.txtPrestamo.Text = idPublicidad
        form.diasMora = txtdiasmora.Text
        form.NvaPubli = esNueva

        If Not esNueva Then
            form.cmdGuardarEditar.Enabled = False ' Por defecto apagado, lo prendes si es desde listado general
            form.btnCalcular.Enabled = False
            form.btnPagar.Enabled = True

            ' Si viene un vendedor asignado (desde Cta Cte)
            If idVendedor IsNot Nothing AndAlso Not DBNull.Value.Equals(idVendedor) Then
                form.idVendedor = idVendedor
            End If

            form.CargarDetalle()
        End If
    End Sub

    Private Sub AbrirFormularioContable(idCliente As String, nombreCliente As String)
        Try
            ' 1. Buscamos si ya está abierto
            For Each child As Form In frmprincipal.MdiChildren
                If child.Name = "CONTABLE" Then
                    child.BringToFront()
                    ConfigurarFormularioContable(CType(child, CONTABLE), idCliente, nombreCliente)
                    Exit Sub
                End If
            Next

            ' 2. Si no está abierto, lo creamos
            Dim formContable As New CONTABLE()
            formContable.MdiParent = Me.MdiParent
            formContable.Show()
            ConfigurarFormularioContable(formContable, idCliente, nombreCliente)

        Catch ex As Exception
            MsgBox("Error al abrir cuenta corriente: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ConfigurarFormularioContable(form As CONTABLE, idCliente As String, nombreCliente As String)
        form.txtcuentabus.Text = idCliente
        form.txtcliebus.Text = nombreCliente.ToUpper()
        form.cargarCuentaClie(Val(idCliente))
        form.tabcontable.SelectedTab = form.tabcuentasclientes
    End Sub


End Class