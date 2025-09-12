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
        Button1.Enabled = True
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
        Button1.Enabled = False
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
            dgvPublicidad.Columns.Clear()
            dgvPublicidad.Rows.Clear()
            dgvPublicidad.DataSource = ds.Tables(0)
            dgvPublicidad.Columns("ID").Visible = False
            dgvPublicidad.Columns("PERIODO").Visible = False

        Else
            dgvPublicidad.DataSource = Nothing
        End If

    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Dim vta As New puntoventa
        vta.MdiParent = Me.MdiParent
        vta.idfacrap = My.Settings.idfacRap

        With vta
            .Idcliente = txtclientecuenta.Text 'dgvPrestamos.dgvVista.CurrentRow.Cells("idclientes").Value
            .condVta = 2
            .cargarCliente(False)
            .txtcodPLU.Focus()
            For Each publi As DataGridViewRow In dgvPublicidad.Rows
                If publi.Selected = True Then
                    .dtproductos.Rows.Add("0", "#" & txtPrestamo.Text, "1",
                 txtconcepto.Text & " #" &
                 txtPrestamo.Text & " - " &
                 Format(CDate(publi.Cells("VENCIMIENTO").Value.ToString), "MMMM yyyy"), "21",
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
        Consultas("select DTP.ID,
        IF((SELECT count(*) from rym_pagos where ID_PRESTAMO=DTP.ID_PRESTAMO and periodo=DTP.PERIODO)=1,
        'PAGADA',IF(DATEDIFF(NOW(),DTP.FECHA)>@DIASMORA,'MOROSO','DEBE')
        ) AS ESTADO,
		DTP.PERIODO, DTP.FECHA AS VENCIMIENTO,DTP.CUOTA AS MONTO,
        (select group_concat(comp.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) from 
        fact_facturas as fact, fact_items as itm, tipos_comprobantes as comp where
        itm.id_fact= fact.id and fact.tipofact=comp.donfdesc and fact.ptovta=comp.ptovta and 
        itm.plu like concat('%#',DTP.ID_PRESTAMO,'%') and
        date_format(date_add(DTP.FECHA, interval -1 month),'%Y-%m')=
        date_format(str_to_date(
         CASE WHEN INSTR(trim(substring(descripcion,locate('ENERO',descripcion), length(descripcion)-locate('ENERO',descripcion))),'ENERO')<>0 THEN
         REPLACE (trim(substring(descripcion,locate('ENERO',descripcion), length(descripcion)-locate('ENERO',descripcion)+1)),'ENERO','JANUARY')
         WHEN INSTR(trim(substring(descripcion,locate('FEBRERO',descripcion), length(descripcion)-locate('FEBRERO',descripcion))),'FEBRERO')<>0 THEN
         REPLACE (trim(substring(descripcion,locate('FEBRERO',descripcion), length(descripcion)-locate('FEBRERO',descripcion)+1)),'FEBRERO','FEBRUARY')
         WHEN INSTR(trim(substring(descripcion,locate('MARZO',descripcion), length(descripcion)-locate('MARZO',descripcion))),'MARZO')<>0 THEN
         REPLACE (trim(substring(descripcion,locate('MARZO',descripcion), length(descripcion)-locate('MARZO',descripcion)+1)),'MARZO','MARCH')
         WHEN INSTR(trim(substring(descripcion,locate('ABRIL',descripcion), length(descripcion)-locate('ABRIL',descripcion))),'ABRIL')<>0 THEN 
         REPLACE (trim(substring(descripcion,locate('ABRIL',descripcion), length(descripcion)-locate('ABRIL',descripcion)+1)),'ABRIL','APRIL')
         WHEN INSTR(trim(substring(descripcion,locate('MAYO',descripcion), length(descripcion)-locate('MAYO',descripcion))),'MAYO')<>0 THEN 
         REPLACE (trim(substring(descripcion,locate('MAYO',descripcion), length(descripcion)-locate('MAYO',descripcion)+1)),'MAYO','MAY')
         WHEN INSTR(trim(substring(descripcion,locate('JUNIO',descripcion), length(descripcion)-locate('JUNIO',descripcion))),'JUNIO')<>0 THEN 
         REPLACE (trim(substring(descripcion,locate('JUNIO',descripcion), length(descripcion)-locate('JUNIO',descripcion)+1)),'JUNIO','JUNE')
         WHEN INSTR(trim(substring(descripcion,locate('JULIO',descripcion), length(descripcion)-locate('JULIO',descripcion))),'JULIO')<>0 THEN
         REPLACE (trim(substring(descripcion,locate('JULIO',descripcion), length(descripcion)-locate('JULIO',descripcion)+1)),'JULIO','JULY')
         WHEN INSTR(trim(substring(descripcion,locate('AGOSTO',descripcion), length(descripcion)-locate('AGOSTO',descripcion))),'AGOSTO')<>0 THEN
         REPLACE (trim(substring(descripcion,locate('AGOSTO',descripcion), length(descripcion)-locate('AGOSTO',descripcion)+1)),'AGOSTO','AUGUST')
         WHEN INSTR(trim(substring(descripcion,locate('SEPTIEMBRE',descripcion), length(descripcion)-locate('SEPTIEMBRE',descripcion))),'SEPTIEMBRE')<>0 THEN 
         REPLACE (trim(substring(descripcion,locate('SEPTIEMBRE',descripcion), length(descripcion)-locate('SEPTIEMBRE',descripcion)+1)),'SEPTIEMBRE','SEPTEMBER')
         WHEN INSTR(trim(substring(descripcion,locate('OCTUBRE',descripcion), length(descripcion)-locate('OCTUBRE',descripcion))),'OCTUBRE')<>0 THEN 
         REPLACE (trim(substring(descripcion,locate('OCTUBRE',descripcion), length(descripcion)-locate('OCTUBRE',descripcion)+1)),'OCTUBRE','OCTOBER')
         WHEN INSTR(trim(substring(descripcion,locate('NOVIEMBRE',descripcion), length(descripcion)-locate('NOVIEMBRE',descripcion))),'NOVIEMBRE')<>0 THEN 
         REPLACE (trim(substring(descripcion,locate('NOVIEMBRE',descripcion), length(descripcion)-locate('NOVIEMBRE',descripcion)+1)),'NOVIEMBRE','NOVEMBER')
         WHEN INSTR(trim(substring(descripcion,locate('DICIEMBRE',descripcion), length(descripcion)-locate('DICIEMBRE',descripcion))),'DICIEMBRE')<>0 THEN 
         REPLACE (trim(substring(descripcion,locate('DICIEMBRE',descripcion), length(descripcion)-locate('DICIEMBRE',descripcion)+1)),'DICIEMBRE','DECEMBER')
         ELSE '1' END,'%M %Y'),'%Y-%m')
        ) AS FACTURA
        from rym_detalle_prestamo AS DTP where id_prestamo='" & txtBuscaPrestamo.Text & "' and PERIODO <>0 order by ID asc")
        Reconectar()
        Dim ConsultaPrestamo As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cli.idclientes, pre.ID_PRESTAMO,cli.nomapell_razon,pre.DESCRIPCION,pre.CONCEPTO,
        pre.MONTO_PRESTAMO,pre.PLAZO, pre.INTERES_ANUAL, pre.FECHA,pre.CUOTA
        FROM rym_prestamo as pre, fact_clientes as cli
        where cli.idclientes=pre.ID_CLIENTE
        and pre.id=" & txtBuscaPrestamo.Text, conexionPrinc)
        Dim DatosPrestamo As New DataTable
        ConsultaPrestamo.Fill(DatosPrestamo)
        ' MsgBox(ConsultaPrestamo.SelectCommand.CommandText)
        If DatosPrestamo.Rows.Count <> 0 Then
            txtclientecuenta.Text = DatosPrestamo(0).Item("idclientes")
            txtclientenombre.Text = DatosPrestamo(0).Item("nomapell_razon")
            txtCuota.Text = DatosPrestamo(0).Item("CUOTA")
            txtmonto.Text = DatosPrestamo(0).Item("MONTO_PRESTAMO")
            txtPlazo.Text = DatosPrestamo(0).Item("PLAZO")
            txtTasaAnual.Text = DatosPrestamo(0).Item("INTERES_ANUAL")
            txtconcepto.Text = DatosPrestamo(0).Item("CONCEPTO")
            txtdetallePublicidad.Text = DatosPrestamo(0).Item("DESCRIPCION")
            dtpFechaInicio.Value = CDate(DatosPrestamo(0).Item("FECHA").ToString())
            txtInteresMensual.Text = Math.Round(CDbl(txtTasaAnual.Text) / 12, 2)
            txtPrestamo.Text = DatosPrestamo(0).Item("ID_PRESTAMO")
            For Each cont As Control In Me.Controls
                If TypeOf cont Is TextBox Then
                    Dim tex As TextBox
                    tex = cont
                    tex.ReadOnly = True
                ElseIf TypeOf cont Is DateTimePicker Then
                    Dim dt As DateTimePicker
                    dt = cont
                    dt.Enabled = False
                End If
                cmdclientebuscar.Enabled = False
            Next
        End If
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


    'Private Sub btnImprimirPagos_Click(sender As Object, e As EventArgs) Handles btnImprimirPagos.Click
    '    ReporteForm.IDPrestamo = txtBuscaPrestamo.Text
    '    ReporteForm.Show()
    '    ReporteForm.ReportePagos()
    'End Sub

    Private Sub PrestamosForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If txtPrestamo.Text <> "" And txtclientecuenta.Text = "" And txtclientecuenta.Text = "9999" Then
            Operaciones.Eliminar("delete from pr, dpr Using rym_prestamo As pr, rym_detalle_prestamo as dpr 
            where pr.ID_PRESTAMO = dpr.ID_PRESTAMO And pr.ID_PRESTAMO ='" & txtPrestamo.Text & "'")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GeneraPrestamo()

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

    Private Sub dgvPublicidad_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPublicidad.CellContentClick

    End Sub

    Private Sub txtPrestamo_TextChanged(sender As Object, e As EventArgs) Handles txtPrestamo.TextChanged

    End Sub
End Class