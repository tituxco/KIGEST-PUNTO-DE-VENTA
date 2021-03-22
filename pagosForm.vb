Imports System.Data.OleDb

Public Class pagosForm
    Dim CuotaRecalculada As Boolean = False

    Private Sub pagosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtCapital_Leave(sender As Object, e As EventArgs) Handles txtCapital.Leave
        If txtCapital.Text.Length > 0 Then
            txtTotal.Text = CDbl(txtCuota.Text) + CDbl(txtCapital.Text)
        Else
            txtTotal.Text = CDbl(txtCuota.Text)
        End If

    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        If CheckBox1.Checked = True Then
            LiquidaPrestamo()
        Else
            Dim VerificaUltimo As Integer = 0

            Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from rym_detalle_prestamo where id_prestamo='" &
            lbPrestamo.Text & "' order by periodo desc limit 1", conexionPrinc)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                VerificaUltimo = ds.Tables(0).Rows(0).Item("PERIODO")
            End If


            If VerificaUltimo = CInt(lbPeriodo.Text) And CDbl(txtTotal.Text) > 1 Then
                MsgBox("No puede agregar al capital en la última cuota")
                txtCapital.Text = "0"
            End If

            Operaciones.Guardar("insert into rym_pagos(fecha,id_prestamo,periodo,monto_pagado) values(@fecha,'" & lbPrestamo.Text & "','" & lbPeriodo.Text & "','" & txtTotal.Text & "')", Today.Date)

            If CDbl(txtCapital.Text) > 0 Then
                RecalculaPrestamo(lbPrestamo.Text)
            End If
        End If



        MsgBox("Pago realizado con exito")

        PrestamosForm.Consultas("select * from rym_detalle_prestamo where id_prestamo='" & lbPrestamo.Text & "'")

        'Limpiar campos
        '--------------------------------------------------------
        txtCapital.Text = "0"
        txtCuota.Text = "0"
        txtRestante.Text = "0"
        txtTotal.Text = "0"
        CuotaRecalculada = False

        Me.Hide()
    End Sub

    Private Sub RecalculaPrestamo(ByVal NoPrestamo As String)
        Dim Plazo As Integer = 0
        Dim InteresMensual As Double = 0
        Dim InteresAnual As Double = 0
        Dim capitalAmortizado As Double = 0


        Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter("select plazo, interes_anual from rym_prestamo where id_prestamo='" & NoPrestamo & "'", conexionPrinc)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Plazo = ds.Tables(0).Rows(0).Item("plazo").ToString
            InteresMensual = CDbl(ds.Tables(0).Rows(0).Item("interes_anual").ToString) / 100 / 12
            InteresAnual = CDbl(ds.Tables(0).Rows(0).Item("interes_anual").ToString)
        End If

        da = New MySql.Data.MySqlClient.MySqlDataAdapter("select  * from rym_detalle_prestamo where id_prestamo='" & NoPrestamo & "' and periodo < " & CInt(lbPeriodo.Text) & " order by periodo desc limit 1", conexionPrinc)
        ds = New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            capitalAmortizado = ds.Tables(0).Rows(0).Item("CAPITAL_AMORTIZADO").ToString
        End If

        Dim CuotaPagar As Double = txtCuota.Text


        Dim SaldoInicial As Double = CDbl(txtRestante.Text)
        Dim CapitalPagado As Double = 0
        Dim InteresPagado As Double = 0
        Dim capitalRestante As Double = CDbl(txtRestante.Text)


        For i As Integer = CInt(lbPeriodo.Text) To Plazo

            If i = CInt(lbPeriodo.Text) Then
                CuotaPagar = CDbl(txtTotal.Text)
            Else
                If CuotaRecalculada = False Then
                    CuotaPagar = Calculacuota(SaldoInicial, InteresAnual, Plazo - CInt(lbPeriodo.Text))
                    CuotaRecalculada = True
                End If

                txtCapital.Text = 0

            End If

            InteresPagado = SaldoInicial * InteresMensual
            CapitalPagado = CuotaPagar - InteresPagado
            capitalRestante = capitalRestante - CapitalPagado
            capitalAmortizado = capitalAmortizado + CapitalPagado
            Operaciones.Guardar("update rym_detalle_prestamo set interes='" & InteresPagado & "',cuota='" & CuotaPagar & "',amortizacion='" & CapitalPagado & "',capital_restante='" & capitalRestante & "',capital_amortizado='" & capitalAmortizado & "',amortizacion_anticipada='" & CDbl(txtCapital.Text) & "' where periodo=" & i & " and id_prestamo='" & NoPrestamo & "'", Today.Date)

            SaldoInicial = SaldoInicial - CapitalPagado
        Next
    End Sub

    Private Sub LiquidaPrestamo()

        Dim Interes As Double = 0
        Dim CapitalRestante As Double = 0
        Dim UltimoPeriodo As Integer = 0
        Dim CapitalAmortizado As Double = 0
        Dim Amortizacion As Double = 0

        Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from rym_detalle_prestamo where id_prestamo='" & lbPrestamo.Text & "' and periodo=" & lbPeriodo.Text, conexionPrinc)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Amortizacion = CDbl(ds.Tables(0).Rows(0).Item("AMORTIZACION").ToString)
            CapitalRestante = CDbl(ds.Tables(0).Rows(0).Item("CAPITAL_RESTANTE").ToString)
            Interes = CDbl(ds.Tables(0).Rows(0).Item("INTERES").ToString)
            CapitalAmortizado = CDbl(ds.Tables(0).Rows(0).Item("CAPITAL_AMORTIZADO").ToString)
        End If

        da = New MySql.Data.MySqlClient.MySqlDataAdapter("select * from rym_detalle_prestamo where id_prestamo='" & lbPrestamo.Text & "' order by periodo desc", conexionPrinc)
        ds = New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            UltimoPeriodo = CInt(ds.Tables(0).Rows(0).Item("PERIODO").ToString)
        End If

        txtTotal.Text = CapitalRestante + Interes + Amortizacion
        Operaciones.Guardar("insert into pagos(fecha,id_prestamo,periodo,monto_pagado) values(@fecha,'" & lbPrestamo.Text & "','" & lbPeriodo.Text & "','" & txtTotal.Text & "')", Today.Date)

        Operaciones.Guardar("update detalle_prestamo set interes='" & Interes & "',cuota='" & CDbl(txtTotal.Text) & "',amortizacion='" & CapitalRestante & "',capital_restante=0,capital_amortizado='" & (CapitalAmortizado + CapitalRestante) & "',amortizacion_anticipada='" & CDbl(txtCapital.Text) & "' where periodo=" & CInt(lbPeriodo.Text) & " and id_prestamo='" & lbPrestamo.Text & "'", Today.Date)


        For i As Integer = CInt(lbPeriodo.Text) + 1 To UltimoPeriodo
            Operaciones.Guardar("update rym_detalle_prestamo set interes=0,cuota=0,amortizacion=0,capital_restante=0,capital_amortizado=0,amortizacion_anticipada=0 where periodo=" & i & " and id_prestamo='" & lbPrestamo.Text & "'", Today.Date)
            Operaciones.Guardar("insert into rym_pagos(fecha,id_prestamo,periodo,monto_pagado) values(@fecha,'" & lbPrestamo.Text & "','" & i & "',0)", Today.Date)

        Next
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtCapital.ReadOnly = True
            txtTotal.ReadOnly = True

            Dim Interes As Double = 0
            Dim CapitalRestante As Double = 0
            Dim UltimoPeriodo As Integer = 0
            Dim CapitalAmortizado As Double = 0
            Dim Amortizacion As Double = 0

            Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from rym_detalle_prestamo where id_prestamo='" & lbPrestamo.Text & "' and periodo=" & lbPeriodo.Text, conexionPrinc)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Amortizacion = CDbl(ds.Tables(0).Rows(0).Item("AMORTIZACION").ToString)
                CapitalRestante = CDbl(ds.Tables(0).Rows(0).Item("CAPITAL_RESTANTE").ToString)
                Interes = CDbl(ds.Tables(0).Rows(0).Item("INTERES").ToString)
                CapitalAmortizado = CDbl(ds.Tables(0).Rows(0).Item("CAPITAL_AMORTIZADO").ToString)
            End If

            da = New MySql.Data.MySqlClient.MySqlDataAdapter("select  * from rym_detalle_prestamo where id_prestamo='" & lbPrestamo.Text & "' order by periodo desc", conexionPrinc)
            ds = New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                UltimoPeriodo = CInt(ds.Tables(0).Rows(0).Item("PERIODO").ToString)
            End If

            txtTotal.Text = CapitalRestante + Interes + Amortizacion


        Else
            txtCapital.ReadOnly = False
            txtTotal.ReadOnly = False

            txtTotal.Text = CDbl(txtCuota.Text) + CDbl(txtCapital.Text)
        End If
    End Sub
End Class