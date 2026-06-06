Imports System.Runtime.CompilerServices
Imports WSAFIPFE.anmat
Imports WSAFIPFE.ocAFIPTest

Public Class NvaPublicidad
    Private cmd As MySql.Data.MySqlClient.MySqlCommand
    Private da As MySql.Data.MySqlClient.MySqlDataAdapter
    Private ds As DataSet
    Public idCliente As Integer
    Public diasMora As String
    Public idVendedor As Integer
    Public NvaPubli As Boolean

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

        Dim precioCuota As Double = 0
        Dim cantMeses As Double = 0
        Dim montoTotal As Double = 0
        If rdPorMes.Checked = True Then
            precioCuota = FormatNumber(txtCuota.Text)
            cantMeses = txtPlazo.Text
            montoTotal = precioCuota * cantMeses
            txtmonto.Text = montoTotal
        End If

        txtCuota.Text = Operaciones.Calculacuota(CDbl(txtmonto.Text), CDbl(txtTasaAnual.Text), CInt(txtPlazo.Text))
        PrevisualizarPrestamo()



        'GeneraPrestamo()
        ' btnCalcular.Enabled = False

    End Sub

    Private Sub PrevisualizarPrestamo()



        If txtCuota.Text = "" Or txtCuota.Text = "0" Then
            MsgBox("debe calcular primero la cuota")
            Exit Sub
        End If

        dgvPublicidad.Columns.Clear()
        dgvPublicidad.Rows.Clear()

        dgvPublicidad.Columns.Add("Fechavencimiento", "Fecha Vencimiento")
        dgvPublicidad.Columns.Add("Montomensual", "Monto Mensual")
        dgvPublicidad.ReadOnly = False

        Dim Plazo As Integer = txtPlazo.Text
        Dim InteresMensual As Double = FormatNumber(txtTasaAnual.Text, 2) / 100 / 12
        Dim InteresAnual As Double = FormatNumber(txtTasaAnual.Text, 2)
        Dim capitalAmortizado As Double = 0
        Dim fechaVenc As Date
        Dim FechaGuardar As String
        Dim FechaPago As Date


        If chkAdelantado.Checked = True Then
            FechaPago = dtpFechaInicio.Value
            fechaVenc = dtpFechaInicio.Value.AddDays(-1)
            'FechaGuardar = Format(CDate(DateTimePicker1.Value), "yyyy-MM-dd")
        Else
            'FechaGuardar = Format(CDate(DateTimePicker1.Value), "yyyy-MM-dd")
            FechaPago = dtpFechaInicio.Value.AddMonths(1)
        End If


        Dim MiCuota As Double = 0

        Dim SaldoInicial As Double = FormatNumber(txtmonto.Text, 2)
        Dim CapitalPagado As Double = 0
        Dim InteresPagado As Double = 0
        Dim capitalRestante As Double = FormatNumber(txtmonto.Text, 2)
        'MsgBox(FechaPago)
        For i As Integer = 1 To Plazo
            '    MsgBox(fecha)
            MiCuota = txtCuota.Text
            InteresPagado = SaldoInicial * InteresMensual
            CapitalPagado = MiCuota - InteresPagado
            capitalRestante = capitalRestante - CapitalPagado
            capitalAmortizado = capitalAmortizado + CapitalPagado

            'cuotaPrestamo = tablaPrestamo.NewRow
            If chkAdelantado.Checked = True And i = 1 Then
                FechaGuardar = Format(CDate(FechaPago), "yyyy-MM-dd")
                FechaPago = fechaVenc
            Else
                FechaGuardar = Format(CDate(FechaPago), "yyyy-MM-dd")
            End If

            dgvPublicidad.Rows.Add(FechaGuardar, MiCuota)
            'MsgBox(i & "  ---  " & Plazo)
            'If i = Plazo - 1 Then
            '    FechaPago = FechaPago.AddMonths(1).AddDays(-1)
            'Else
            FechaPago = FechaPago.AddMonths(1)
            'End If
            'FechaGuardar = Format(CDate(FechaPago), "yyyy-MM-dd")
            SaldoInicial = SaldoInicial - CapitalPagado
        Next
        cmdGuardarEditar.Enabled = True
        'dgvPublicidad.DataSource = tablaPrestamo
        'txtBuscaPrestamo.Text = NoPrestamo
    End Sub

    Private Sub GeneraPrestamo()

        If txtCuota.Text = "" Or txtCuota.Text = "0" Then
            MsgBox("debe calcular primero la cuota")
            Exit Sub
        End If

        If txtclientecuenta.Text = "" Or txtclientecuenta.Text = "9999" Then
            MsgBox("Debe seleccionar un cliente para guardar el plan de publicidad")
            Exit Sub
        End If

        If txtdetallePublicidad.Text = "" Then
            MsgBox("Debe ingresar detalle de publicidad")
            Exit Sub
        End If

        If txtconcepto.Text = "" Then
            MsgBox("Debe ingresar Concepto de publicidad")
            Exit Sub
        End If

        Dim NoPrestamo As String
        Dim idCliente As Integer = CInt(txtclientecuenta.Text)
        Dim detallePrestamo As String = txtdetallePublicidad.Text.ToUpper
        NoPrestamo = "1"

        Consultas("select IF(MAX(ID) IS NULL,0,MAX(ID)) AS ID from  rym_prestamo")
        NoPrestamo = CInt(ds.Tables(0).Rows(0).Item("ID")) + 1


        NoPrestamo = NoPrestamo.ToString.PadLeft(5, "0")
        txtPrestamo.Text = NoPrestamo

        Dim fechaVenc As Date
        Dim FechaGuardar As String
        Dim FechaPago As Date

        If chkAdelantado.Checked = True Then
            FechaPago = dtpFechaInicio.Value
            fechaVenc = dtpFechaInicio.Value.AddDays(-1)
            FechaGuardar = Format(CDate(dtpFechaInicio.Value), "yyyy-MM-dd")
        Else
            FechaGuardar = Format(CDate(dtpFechaInicio.Value), "yyyy-MM-dd")
            FechaPago = dtpFechaInicio.Value.AddMonths(1).AddDays(-1)
        End If

        'Dim fecha As String = Format(CDate(DateTimePicker1.Value), "yyyy-MM-dd")

        Operaciones.Guardar("insert into rym_prestamo(id_prestamo,fecha,id_cliente,plazo,cuota,monto_prestamo,interes_anual,descripcion,concepto,observaciones,cobrador) 
        values('" & NoPrestamo & "','" & FechaGuardar & "','" & idCliente & "','" & txtPlazo.Text & "','" &
        txtCuota.Text & "','" & txtmonto.Text & "','" & txtTasaAnual.Text & "','" & detallePrestamo & "','" & txtconcepto.Text.ToUpper & "','" & txtObservaciones.Text.ToUpper & "','" & cmbcobrador.SelectedValue & "')", Today.Date)


        Dim Plazo As Integer = txtPlazo.Text
        Dim InteresMensual As Double = FormatNumber(txtTasaAnual.Text, 2) / 100 / 12
        Dim InteresAnual As Double = FormatNumber(txtTasaAnual.Text, 2)
        Dim capitalAmortizado As Double = 0
        Dim MiCuota As Double = 0

        Dim SaldoInicial As Double = FormatNumber(txtmonto.Text, 2)
        Dim CapitalPagado As Double = 0
        Dim InteresPagado As Double = 0
        Dim capitalRestante As Double = FormatNumber(txtmonto.Text, 2)

        For Each periodo As DataGridViewRow In dgvPublicidad.Rows
            'MsgBox(periodo.Cells("Montomensual").Value)
            MiCuota = periodo.Cells("Montomensual").Value
            ' txtCuota.Text
            InteresPagado = SaldoInicial * InteresMensual
            CapitalPagado = MiCuota - InteresPagado
            capitalRestante = capitalRestante - CapitalPagado
            capitalAmortizado = capitalAmortizado + CapitalPagado

            FechaGuardar = Format(CDate(periodo.Cells("Fechavencimiento").Value.ToString), "yyyy-MM-dd")

            Operaciones.Guardar("insert into rym_detalle_prestamo(id_prestamo,periodo,fecha,cuota,interes,amortizacion,capital_restante,capital_amortizado,
            amortizacion_anticipada) 
            values('" & NoPrestamo & "','" & periodo.Index + 1 & "','" & FechaGuardar & "','" & FormatNumber(MiCuota, 2) & "','" & FormatNumber(InteresPagado, 2) & "','" &
            FormatNumber(CapitalPagado, 2) & "','" & FormatNumber(capitalRestante, 2) & "','" & FormatNumber(capitalAmortizado, 2) & "',0)", Today.Date)

            'FechaPago = FechaPago.AddMonths(1)
            'fecha = Format(CDate(FechaPago), "yyyy-MM-dd")

            SaldoInicial = SaldoInicial - CapitalPagado
            'MsgBox(MiCuota & "-" & InteresPagado & "-" & capitalRestante & "-" & capitalRestante & "-" & capitalAmortizado)
        Next
        dgvPublicidad.ReadOnly = True
        NvaPubli = False
        btnPagar.Enabled = True
        txtBuscaPrestamo.Text = NoPrestamo
        cmdGuardarEditar.Enabled = False
    End Sub


    Public Sub Consultas(ByVal Cadena As String)
        Reconectar()
        'Dim fecha As MySql.Data.Types.MySqlDateTime()
        cmd = New MySql.Data.MySqlClient.MySqlCommand(Cadena, conexionPrinc)
        cmd.Parameters.AddWithValue("@FECHA", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Today.Date
        cmd.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = diasMora
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(cmd)
        'MsgBox(cmd.CommandText)
        ds = New DataSet
        da.Fill(ds)

        If ds.Tables(0).Rows.Count > 0 And NvaPubli = False Then
            'dgvPublicidad.Columns.Clear()
            'dgvPublicidad.Rows.Clear()
            dgvPublicidad.DataSource = ds.Tables(0)
            dgvPublicidad.Columns("ID").Visible = False
            dgvPublicidad.Columns("PERIODO").Visible = False

        Else
            dgvPublicidad.DataSource = Nothing
        End If

    End Sub

    'Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
    '    Dim vta As New puntoventa
    '    vta.MdiParent = Me.MdiParent
    '    vta.idfacrap = My.Settings.idfacRap

    '    With vta
    '        .Idcliente = txtclientecuenta.Text 'dgvPrestamos.dgvVista.CurrentRow.Cells("idclientes").Value
    '        .condVta = 2
    '        .cargarCliente(False)
    '        .txtcodPLU.Focus()
    '        For Each publi As DataGridViewRow In dgvPublicidad.Rows
    '            If publi.Selected = True Then
    '                .dtproductos.Rows.Add("0", "#" & txtPrestamo.Text, "1",
    '             txtconcepto.Text & " #" &
    '             txtPrestamo.Text & " - " &
    '             Format(DateAdd(DateInterval.Month, -1, CDate(publi.Cells("VENCIMIENTO").Value.ToString)), "MMMM yyyy"), "21",
    '             publi.Cells("MONTO").Value,
    '             publi.Cells("MONTO").Value)
    '            End If

    '        Next

    '        .txtobservaciones.Text = txtdetallePublicidad.Text
    '        .condVta = 2
    '        .lblfacvendedor.Text = idVendedor
    '        .Show()
    '    End With
    'End Sub


    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Dim vta As New puntoventa
        vta.MdiParent = Me.MdiParent
        vta.idfacrap = My.Settings.idfacRap

        With vta
            .Idcliente = txtclientecuenta.Text
            .condVta = 2
            .cargarCliente(False)
            .txtcodPLU.Focus()

            For Each publi As DataGridViewRow In dgvPublicidad.Rows
                If publi.Selected = True Then
                    ' AQUÍ ESTÁ EL CAMBIO CLAVE:
                    ' Pasamos el ID del préstamo y el ID único de la cuota (publi.Cells("ID").Value)
                    Dim idCuota As String = publi.Cells("ID").Value.ToString()
                    Dim codigoPlu As String = "#" & txtPrestamo.Text & "-" & idCuota

                    Dim descripcion As String = txtconcepto.Text & " #" & txtPrestamo.Text & " - " &
                      Format(DateAdd(DateInterval.Month, -1, CDate(publi.Cells("VENCIMIENTO").Value.ToString)), "MMMM yyyy")

                    .dtproductos.Rows.Add("0", codigoPlu, "1", descripcion, "21",
                                     publi.Cells("MONTO").Value,
                                     publi.Cells("MONTO").Value)
                End If
            Next

            .txtobservaciones.Text = txtdetallePublicidad.Text
            .condVta = 2
            .lblfacvendedor.Text = idVendedor
            .Show()
        End With
    End Sub
    Private Sub txtBuscaPrestamo_TextChanged(sender As Object, e As EventArgs) Handles txtBuscaPrestamo.TextChanged
        CargarDetalle()
    End Sub


    Public Sub CargarDetalle()
        Try
            ' 1. Llamamos al Gestor para obtener el detalle de cuotas
            Dim dtDetalle As DataTable = GestorPublicidad.ObtenerDetallePublicidad(txtPrestamo.Text, Convert.ToInt32(diasMora))

            ' 2. Asignamos el resultado a la grilla
            If dtDetalle IsNot Nothing AndAlso dtDetalle.Rows.Count > 0 Then
                dgvPublicidad.DataSource = dtDetalle
                dgvPublicidad.Columns("ID").Visible = False
                dgvPublicidad.Columns("PERIODO").Visible = False

                If dgvPublicidad.Columns.Contains("MONTO") Then
                    dgvPublicidad.Columns("MONTO").DefaultCellStyle.Format = "C2"
                    dgvPublicidad.Columns("MONTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Else
                dgvPublicidad.DataSource = Nothing
            End If

            ' 3. Cargamos los datos de cabecera del cliente y préstamo
            Reconectar()
            Dim sqlCabecera As String = "SELECT cli.idclientes, pre.ID_PRESTAMO, cli.nomapell_razon, pre.DESCRIPCION, pre.CONCEPTO, " &
                                    "pre.MONTO_PRESTAMO, pre.PLAZO, pre.INTERES_ANUAL, pre.FECHA, pre.CUOTA, " &
                                    "pre.COBRADOR, pre.OBSERVACIONES " &
                                    "FROM rym_prestamo as pre " &
                                    "INNER JOIN fact_clientes as cli ON cli.idclientes = pre.ID_CLIENTE " &
                                    "WHERE pre.id = '" & txtPrestamo.Text & "'"

            Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlCabecera, conexionPrinc)
            Dim dtCabecera As New DataTable
            da.Fill(dtCabecera)

            If dtCabecera.Rows.Count > 0 Then
                Dim dr As DataRow = dtCabecera.Rows(0)

                ' Completamos los campos con la información del cliente y el préstamo
                txtclientecuenta.Text = dr("idclientes").ToString()
                txtclientenombre.Text = dr("nomapell_razon").ToString()
                txtCuota.Text = dr("CUOTA").ToString()
                txtmonto.Text = dr("MONTO_PRESTAMO").ToString()
                txtPlazo.Text = dr("PLAZO").ToString()
                txtTasaAnual.Text = dr("INTERES_ANUAL").ToString()
                txtconcepto.Text = dr("CONCEPTO").ToString()
                txtdetallePublicidad.Text = dr("DESCRIPCION").ToString()
                txtPrestamo.Text = dr("ID_PRESTAMO").ToString()
                txtObservaciones.Text = dr("OBSERVACIONES").ToString()

                ' Formateo de fecha y cálculos
                If IsDate(dr("FECHA")) Then dtpFechaInicio.Value = CDate(dr("FECHA"))
                Dim tasa As Double = 0
                Double.TryParse(dr("INTERES_ANUAL").ToString(), tasa)
                txtInteresMensual.Text = Math.Round(tasa / 12, 2).ToString()

                ' Configuración de cobradores y estado de controles
                cmbcobrador.SelectedValue = dr("COBRADOR")

                ' Bloqueo de controles para modo visualización
                For Each cont As Control In Me.Controls
                    If TypeOf cont Is TextBox Then
                        CType(cont, TextBox).ReadOnly = True
                    ElseIf TypeOf cont Is DateTimePicker Then
                        CType(cont, DateTimePicker).Enabled = False
                    End If
                Next

                cmdclientebuscar.Enabled = False
                cmbcobrador.Enabled = False
                txtconcepto.Enabled = False
                cmdGuardarEditar.Enabled = True
                cmdGuardarEditar.Text = "Editar"

                ' Usamos esta lógica más robusta:
                Dim fechaRaw As String = dr("FECHA").ToString()
                Dim fechaValida As Date

                If DateTime.TryParse(fechaRaw, fechaValida) Then
                    ' Si la fecha es válida, la asignamos
                    dtpFechaInicio.Value = fechaValida
                    dtpFechaInicio.Enabled = False ' Bloqueamos para edición si es necesario
                Else
                    ' Si la fecha viene vacía o mal, ponemos la fecha actual o la fecha mínima
                    dtpFechaInicio.Value = DateTime.Now
                    dtpFechaInicio.Enabled = False
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al cargar el detalle: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub txtTasaAnual_Leave(sender As Object, e As EventArgs) Handles txtTasaAnual.Leave
        txtInteresMensual.Text = CDbl(txtTasaAnual.Text) / 12
    End Sub


    Private Sub txtInteresMensual_Leave(sender As Object, e As EventArgs) Handles txtInteresMensual.Leave
        txtTasaAnual.Text = CDbl(txtInteresMensual.Text) * 12
    End Sub


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        'ReporteForm.Show()
        'ReporteForm.PrestamoTabla = DataGridView1.DataSource
        'ReporteForm.GenerarReporte()

        Dim tablaEmpresa As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim DatosGenerales As New datosgenerales
        Dim DatosPrestamo As New datosPrestamo
        Dim consultaPrestamo As New MySql.Data.MySqlClient.MySqlCommand("select 
        IF((SELECT count(*) from rym_pagos AS PA where PA.ID_PRESTAMO=DTP.ID_PRESTAMO and PA.periodo=DTP.PERIODO)=1,
        'PAGADA',IF(DATEDIFF(NOW(),DTP.FECHA)>@DIASMORA,'MOROSO','DEBE')
        ) AS ESTADO,
		DTP.PERIODO, DTP.FECHA AS VENCIMIENTO,DTP.CUOTA AS MONTO, PRE.DESCRIPCION, PRE.CONCEPTO, PRE.ID_PRESTAMO,PRE.FECHA
        from rym_detalle_prestamo AS DTP, rym_prestamo as PRE where 
        PRE.ID_PRESTAMO = DTP.ID_PRESTAMO AND
        DTP.ID_PRESTAMO='" & txtBuscaPrestamo.Text & "' and DTP.PERIODO <>0 order by DTP.ID asc", conexionPrinc)
        Dim tablaPrestamo As New DataTable
        'Dim filasProd() As DataRow
        tablaEmpresa.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
        emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
        emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo 
        FROM fact_empresa as emp where emp.id=1", conexionPrinc)

        tablaEmpresa.Fill(DatosGenerales.Tables("datosEmpresa"))
        Reconectar()
        consultaPrestamo.Parameters.AddWithValue("@FECHA", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Today.Date
        consultaPrestamo.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = diasMora
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(consultaPrestamo)
        da.Fill(DatosPrestamo.Tables("Publicidad_Visualizacion"))

        Dim imprimirx As New imprimirFX
        With imprimirx
            .MdiParent = Me.MdiParent
            .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\publicidad_visualizacion.rdlc"
            .rptfx.LocalReport.DataSources.Clear()
            .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", DatosGenerales.Tables("datosEmpresa")))
            .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosPrestamo", DatosPrestamo.Tables("Publicidad_Visualizacion")))
            '.rptfx.LocalReport.SetParameters(parameters)
            .rptfx.DocumentMapCollapsed = True
            .rptfx.RefreshReport()
            .Show()
        End With

    End Sub

    Private Sub PrestamosForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If txtPrestamo.Text <> "" And txtclientecuenta.Text = "" And txtclientecuenta.Text = "9999" Then
            Operaciones.Eliminar("delete from pr, dpr Using rym_prestamo As pr, rym_detalle_prestamo as dpr 
            where pr.ID_PRESTAMO = dpr.ID_PRESTAMO And pr.ID_PRESTAMO ='" & txtPrestamo.Text & "'")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdGuardarEditar.Click
        If NvaPubli = True Then
            GeneraPrestamo()
        Else
            If cmdGuardarEditar.Text = "Editar" Then
                txtdetallePublicidad.Enabled = True
                txtObservaciones.Enabled = True
                txtdetallePublicidad.ReadOnly = False
                txtObservaciones.ReadOnly = False
                cmbcobrador.Enabled = True
                txtconcepto.Enabled = True
                cmdGuardarEditar.Text = "Guardar"
            ElseIf cmdGuardarEditar.Text = "Guardar" Then
                Operaciones.Editar("update rym_prestamo set DESCRIPCION ='" & txtdetallePublicidad.Text.ToUpper & "', 
                CONCEPTO= '" & txtconcepto.Text.ToUpper & "', OBSERVACIONES= '" & txtObservaciones.Text.ToUpper & "', 
                COBRADOR='" & cmbcobrador.SelectedValue & "' where ID_PRESTAMO=" & txtPrestamo.Text)
                cmdGuardarEditar.Text = "Editar"
            End If
        End If

    End Sub

    Private Sub txtclientenombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtclientenombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            selclie.busqueda = txtclientenombre.Text
            selclie.llama = "nvaPublicidad"
            selclie.dtpersonal.Focus()
            selclie.Show()
            selclie.TopMost = True
        End If
    End Sub

    Private Sub NvaPublicidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If InStr(DatosAcceso.Moduloacc, "SUPERADMIN") = False Then
            btnBajaPublicidad.Visible = False
        End If
        Me.Text = "Nva " & DatosAcceso.ServMensual
        Label1.Text = "NUEVO SERVICIO " & DatosAcceso.ServMensual

        Dim tablacob As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,', ', nombre) from fact_cobrador where activo=1", conexionPrinc)
        Dim readcob As New DataSet
        tablacob.Fill(readcob)
        cmbcobrador.DataSource = readcob.Tables(0)
        cmbcobrador.DisplayMember = readcob.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbcobrador.ValueMember = readcob.Tables(0).Columns(0).Caption.ToString

        Dim tablacons As New MySql.Data.MySqlClient.MySqlDataAdapter("select DISTINCT (concepto) from rym_prestamo  order by CONCEPTO desc", conexionPrinc)
        Dim readcons As New DataSet
        tablacons.Fill(readcons)
        txtconcepto.DataSource = readcons.Tables(0)
        txtconcepto.DisplayMember = readcons.Tables(0).Columns(0).Caption.ToString.ToUpper

    End Sub

    Private Sub dgvPublicidad_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPublicidad.CellDoubleClick
        If dgvPublicidad.Columns(e.ColumnIndex).HeaderText = "MONTO" Then 'columna monto Then
            If MsgBox("Desea modificar el importe de este mes en particular?", vbYesNo + vbQuestion, "Modificar publicidad") = MsgBoxResult.Yes Then
                Dim nuevoPrecio As String  '=FormatNumber(txtmonto.Text, 2)
                Dim sumaTotal As Double = 0
                Dim idPeriodo As Integer = dgvPublicidad.CurrentRow.Cells("ID").Value
                Dim idPrestamo As Integer = txtPrestamo.Text
                Dim nuevoPrecioTXT As String

                nuevoPrecio = InputBox("Ingrese el nuevo precio", "Modificar publicidad", dgvPublicidad.Item(e.ColumnIndex, e.RowIndex).Value)
                nuevoPrecioTXT = nuevoPrecio
                If IsNumeric(nuevoPrecio) Then
                    nuevoPrecio = FormatNumber(nuevoPrecio, 2)
                    dgvPublicidad.Item(e.ColumnIndex, e.RowIndex).Value = nuevoPrecio

                    For Each cuota As DataGridViewRow In dgvPublicidad.Rows
                        Dim montoCuota As Double = cuota.Cells("MONTO").Value
                        sumaTotal += montoCuota
                    Next

                    Dim indexInicio As Integer = e.RowIndex
                    Dim indexFinal As Integer = dgvPublicidad.RowCount - 1

                    txtmonto.Text = sumaTotal
                    Dim i As Integer = 0
                    For i = indexInicio To indexFinal
                        'MsgBox(i & "-" & indexFinal)
                        Operaciones.Guardar("update rym_detalle_prestamo set cuota='" & nuevoPrecio & "' where ID= " & dgvPublicidad.Rows(i).Cells("ID").Value, Format(Now(), "yyyy-MM-dd"))
                        dgvPublicidad.Rows(i).Cells("MONTO").Value = nuevoPrecio
                    Next
                    Operaciones.Guardar("update rym_prestamo set CUOTA='" & nuevoPrecioTXT & "', MONTO_PRESTAMO='" & sumaTotal & "' where ID_PRESTAMO= " & idPrestamo, Format(Now(), "yyyy-MM-dd"))


                    'If MsgBox("Desea guardar la informacion?", vbYesNo + vbQuestion, "Modificar publicidad") = MsgBoxResult.Yes Then

                    'End If
                End If
            End If

        End If
    End Sub

    Private Sub cmdclientebuscar_Click(sender As Object, e As EventArgs) Handles cmdclientebuscar.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "frmaspirantes" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim clientes As New frmaspirantes
        clientes.MdiParent = frmprincipal
        clientes.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If dgvPublicidad.CurrentRow.Cells("ESTADO").Value = "PAGADA" Then
                MsgBox("El periodo ya esta pagado")
                Exit Sub
            End If
            Dim periodo As Integer = dgvPublicidad.CurrentRow.Cells("PERIODO").Value
            Dim monto As String = dgvPublicidad.CurrentRow.Cells("MONTO").Value
            Dim fecha As String = Format(CDate(Now), "yyyy-MM-dd")
            Dim sqlQuery As String
            sqlQuery = "insert into rym_pagos (fecha,id_prestamo,periodo,monto_pagado) values (?fecha,?idprestamo,?periodo,?monto)"
            Reconectar()
            Dim addPagoPubli As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With addPagoPubli.Parameters
                .AddWithValue("?fecha", fecha)
                .AddWithValue("?idprestamo", txtPrestamo.Text)
                .AddWithValue("?periodo", periodo)
                .AddWithValue("?monto", monto)
            End With
            addPagoPubli.ExecuteNonQuery()
            MsgBox("Pago imputado correctamente")
            dgvPublicidad.CurrentRow.Cells("ESTADO").Value = "PAGADA"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBajaPublicidad_Click(sender As Object, e As EventArgs) Handles btnBajaPublicidad.Click

        Try
            ' 1. Validar selección y que no sea la fila de totales
            If dgvPublicidad.CurrentRow Is Nothing Then Exit Sub

            Dim cellId = txtPrestamo.Text
            If IsDBNull(cellId) OrElse cellId Is Nothing Then
                MsgBox("Seleccione una publicidad válida (la fila de totales no puede desactivarse).", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim idPub As Integer = Convert.ToInt32(cellId)
            Dim cliente As String = txtclientenombre.Text

            ' 2. Preguntar motivo con Prompt
            Dim motivo As String = InputBox("Ingrese el motivo de la baja para " & cliente & ":", "Baja de Publicidad")

            ' 3. Si cancela o deja vacío, no hacemos nada
            If String.IsNullOrWhiteSpace(motivo) Then
                MsgBox("Debe indicar un motivo para poder desactivar la publicidad.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ' 4. Confirmación final
            If MsgBox("¿Está seguro de desactivar esta publicidad?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                If GestorPublicidad.DesactivarPublicidad(idPub, motivo) Then
                    MsgBox("Publicidad desactivada correctamente.", MsgBoxStyle.Information)
                    ' Refrescar el listado (llamar a tu método de búsqueda)
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class