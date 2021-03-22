Imports System.Data.OleDb

Public Class PrestamosForm
    Private cmd As MySql.Data.MySqlClient.MySqlCommand
    Private da As MySql.Data.MySqlClient.MySqlDataAdapter
    Private ds As DataSet
    Public idCliente As Integer

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        txtCuota.Text = Operaciones.Calculacuota(CDbl(txtmonto.Text), CDbl(txtTasaAnual.Text), CInt(txtPlazo.Text))
        GeneraPrestamo()
        btnCalcular.Enabled = False

    End Sub

    Private Sub GeneraPrestamo()
        Dim NoPrestamo As String

        NoPrestamo = "1"

        Consultas("select IF(MAX(ID) IS NULL,0,MAX(ID)) AS ID from  rym_prestamo")
        NoPrestamo = CInt(ds.Tables(0).Rows(0).Item("ID")) + 1


        NoPrestamo = NoPrestamo.ToString.PadLeft(5, "0")
        txtPrestamo.Text = NoPrestamo
        Dim fecha As String = Format(CDate(DateTimePicker1.Value), "yyyy-MM-dd")

        Operaciones.Guardar("insert into rym_prestamo(id_prestamo,fecha,id_cliente,plazo,cuota,monto_prestamo,interes_anual) 
        values('" & NoPrestamo & "','" & fecha & "','" & 0 & "','" & txtPlazo.Text & "','" &
        txtCuota.Text & "','" & txtmonto.Text & "','" & txtTasaAnual.Text & "')", Today.Date)


        Dim Plazo As Integer = txtPlazo.Text
        Dim InteresMensual As Double = FormatNumber(txtTasaAnual.Text, 2) / 100 / 12
        Dim InteresAnual As Double = FormatNumber(txtTasaAnual.Text, 2)
        Dim capitalAmortizado As Double = 0
        Dim FechaPago As Date = DateTimePicker1.Value
        Dim MiCuota As Double = 0

        Dim SaldoInicial As Double = FormatNumber(txtmonto.Text, 2)
        Dim CapitalPagado As Double = 0
        Dim InteresPagado As Double = 0
        Dim capitalRestante As Double = FormatNumber(txtmonto.Text, 2)

        'MsgBox(InteresMensual & "-" & InteresAnual & "-" & SaldoInicial & "-" & capitalRestante)
        'Exit Sub
        If txtCuota.Text = "" Or txtCuota.Text = "0" Then
            MsgBox("debe calcular primero la cuota")
            Exit Sub
        End If
        For i As Integer = 0 To Plazo
            Operaciones.Guardar("insert into rym_detalle_prestamo(id_prestamo,periodo,fecha,cuota,interes,amortizacion,capital_restante,capital_amortizado,
            amortizacion_anticipada) 
            values('" & NoPrestamo & "','" & i & "','" & fecha & "','" & FormatNumber(MiCuota, 2) & "','" & FormatNumber(InteresPagado, 2) & "','" &
            FormatNumber(CapitalPagado, 2) & "','" & FormatNumber(capitalRestante, 2) & "','" & FormatNumber(capitalAmortizado, 2) & "',0)", Today.Date)


            MiCuota = txtCuota.Text
            InteresPagado = SaldoInicial * InteresMensual
            CapitalPagado = MiCuota - InteresPagado
            capitalRestante = capitalRestante - CapitalPagado
            capitalAmortizado = capitalAmortizado + CapitalPagado

            FechaPago = FechaPago.AddMonths(1)
            fecha = Format(CDate(FechaPago), "yyyy-MM-dd")
            SaldoInicial = SaldoInicial - CapitalPagado
            'MsgBox(MiCuota & "-" & InteresPagado & "-" & capitalRestante & "-" & capitalRestante & "-" & capitalAmortizado)
        Next

        txtBuscaPrestamo.Text = NoPrestamo
    End Sub


    Public Sub Consultas(ByVal Cadena As String)
        Reconectar()
        'Dim fecha As MySql.Data.Types.MySqlDateTime()
        cmd = New MySql.Data.MySqlClient.MySqlCommand(Cadena, conexionPrinc)
        cmd.Parameters.AddWithValue("@FECHA", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Today.Date
        cmd.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = "15"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(cmd)

        ds = New DataSet
        da.Fill(ds)

        If ds.Tables(0).Rows.Count > 0 Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            DataGridView1.DataSource = Nothing
        End If

    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT  *  FROM  rym_detalle_prestamo where periodo not in 
        (select periodo from rym_pagos where id_prestamo='" & txtBuscaPrestamo.Text & "') and id_prestamo='" & txtBuscaPrestamo.Text &
        "' and periodo <> 0 order by fecha asc limit 1", conexionPrinc)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            pagosForm.Show()
            pagosForm.lbPrestamo.Text = txtBuscaPrestamo.Text
            pagosForm.lbPeriodo.Text = ds.Tables(0).Rows(0).Item("periodo").ToString
            pagosForm.txtCuota.Text = ds.Tables(0).Rows(0).Item("cuota")
            pagosForm.txtFecha.Text = ds.Tables(0).Rows(0).Item("fecha").ToString
            pagosForm.txtRestante.Text = CDbl(ds.Tables(0).Rows(0).Item("capital_restante")) + CDbl(ds.Tables(0).Rows(0).Item("amortizacion"))
            pagosForm.txtTotal.Text = ds.Tables(0).Rows(0).Item("cuota")
        End If
    End Sub
    Private Sub txtBuscaPrestamo_TextChanged(sender As Object, e As EventArgs) Handles txtBuscaPrestamo.TextChanged
        Consultas("select 
        IF((SELECT count(*) from rym_pagos where ID_PRESTAMO=DTP.ID_PRESTAMO and periodo=DTP.PERIODO)=1,
        'PAGADA',IF(DATEDIFF(NOW(),DTP.FECHA)>@DIASMORA,'MOROSO','DEBE')
        ) AS ESTADO,
        DTP.* 
        from rym_detalle_prestamo AS DTP where id_prestamo='" & txtBuscaPrestamo.Text & "' and PERIODO <>0 order by ID asc")
        Reconectar()
        Dim ConsultaPrestamo As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cli.idclientes, cli.nomapell_razon,pre.MONTO_PRESTAMO,pre.PLAZO, pre.INTERES_ANUAL, pre.FECHA,pre.CUOTA
        FROM rym_prestamo as pre, fact_clientes as cli
        where cli.idclientes=pre.ID_CLIENTE
        and pre.id=" & txtBuscaPrestamo.Text, conexionPrinc)
        Dim DatosPrestamo As New DataTable
        ConsultaPrestamo.Fill(DatosPrestamo)
        If DatosPrestamo.Rows.Count <> 0 Then
            txtclientecuenta.Text = DatosPrestamo(0).Item("idclientes")
            txtclientenombre.Text = DatosPrestamo(0).Item("nomapell_razon")
            txtCuota.Text = DatosPrestamo(0).Item("CUOTA")
            txtmonto.Text = DatosPrestamo(0).Item("MONTO_PRESTAMO")
            txtPlazo.Text = DatosPrestamo(0).Item("PLAZO")
            txtTasaAnual.Text = DatosPrestamo(0).Item("INTERES_ANUAL")

            txtInteresMensual.Text = Math.Round(CDbl(txtTasaAnual.Text) / 12, 2)
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
        IF((SELECT count(*) from rym_pagos where ID_PRESTAMO=DTP.ID_PRESTAMO and periodo=DTP.PERIODO)=1,
        'PAGADA',IF(DATEDIFF(NOW(),DTP.FECHA)>@DIASMORA,'MOROSO','DEBE')
        ) AS ESTADO,
        DTP.* 
        from rym_detalle_prestamo AS DTP where id_prestamo='" & txtBuscaPrestamo.Text & "' and PERIODO <>0 order by ID asc", conexionPrinc)
        Dim tablaPrestamo As New DataTable
        'Dim filasProd() As DataRow
        tablaEmpresa.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo " _
            & "FROM fact_empresa as emp where emp.id=1", conexionPrinc)

        tablaEmpresa.Fill(DatosGenerales.Tables("datosEmpresa"))
        Reconectar()
        consultaPrestamo.Parameters.AddWithValue("@FECHA", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Today.Date
        consultaPrestamo.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = "15"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(consultaPrestamo)
        da.Fill(DatosPrestamo.Tables("Prestamo_Visualizacion"))

        Dim imprimirx As New imprimirFX
        With imprimirx
            .MdiParent = Me.MdiParent
            .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\prestamo_visualizacion.rdlc"
            .rptfx.LocalReport.DataSources.Clear()
            .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", DatosGenerales.Tables("datosEmpresa")))
            .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosPrestamo", DatosPrestamo.Tables("Prestamo_Visualizacion")))
            '.rptfx.LocalReport.SetParameters(parameters)
            .rptfx.DocumentMapCollapsed = True
            .rptfx.RefreshReport()
            .Show()
        End With

    End Sub

   
    Private Sub btnImprimirPagos_Click(sender As Object, e As EventArgs) Handles btnImprimirPagos.Click
        ReporteForm.IDPrestamo = txtBuscaPrestamo.Text
        ReporteForm.Show()
        ReporteForm.ReportePagos()
    End Sub

    Private Sub PrestamosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PrestamosForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If txtPrestamo.Text <> "" And txtclientecuenta.Text = "" And txtclientecuenta.Text = "9999" Then
            Operaciones.Eliminar("delete from pr, dpr Using rym_prestamo As pr, rym_detalle_2prestamo as dpr 
            where pr.ID_PRESTAMO = dpr.ID_PRESTAMO And pr.ID_PRESTAMO ='" & txtPrestamo.Text & "'")
        End If

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles txtclientenombre.KeyUp
        If e.KeyCode = Keys.Enter Then
            selclie.busqueda = txtclientenombre.Text
            selclie.llama = "prestamosform"
            selclie.dtpersonal.Focus()
            selclie.Show()
            selclie.TopMost = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtclientecuenta.Text = "" Or txtclientecuenta.Text = "9999" Then
            MsgBox("Debe seleccionar un cliente para guardar el prestamo")
        Else
            Reconectar()
            cmd = New MySql.Data.MySqlClient.MySqlCommand("update rym_prestamo set ID_CLIENTE='" & txtclientecuenta.Text & "' where ID_PRESTAMO=" & txtBuscaPrestamo.Text, conexionPrinc)
            cmd.ExecuteNonQuery()
            MsgBox("Se otorgo el prestamo al cliente indicado")
            Button1.Enabled = False
        End If
    End Sub

    Private Sub txtTasaAnual_TextChanged(sender As Object, e As EventArgs) Handles txtTasaAnual.TextChanged

    End Sub
End Class