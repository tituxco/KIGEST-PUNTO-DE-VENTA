Public Class movimientodecaja
    Dim fechagral As String = Format(Now, "dd-MM-yyyy")
    Dim idfactura As Integer
    Public movrap As Boolean
    Public movraptip As Integer
    Public movrapclie As Integer
    Public movrapFact As Integer
    Public movrapConc As String
    Dim SelFech As New CalendarCell
    Dim ptovta As Integer = DatosAcceso.IdPtoVtaDef

    Public Sub cargarDatosGrales()
        Try
            Reconectar()

            Dim tablaftipo As New MySql.Data.MySqlClient.MySqlDataAdapter("select donfdesc, abrev from fact_conffiscal where (tip=2 or tip=3) and ptovta=" & ptovta, conexionPrinc)
            Dim readftipo As New DataSet
            tablaftipo.Fill(readftipo)
            cmbtipofac.DataSource = readftipo.Tables(0)
            cmbtipofac.DisplayMember = readftipo.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbtipofac.ValueMember = readftipo.Tables(0).Columns(0).Caption.ToString
            cmbtipofac.SelectedIndex = -1

            Reconectar()
            Dim tablaconceptoing As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concepto from fact_ingresos_concepto", conexionPrinc)
            Dim readconcing As New DataSet
            tablaconceptoing.Fill(readconcing)
            cmbconceptoing.DataSource = readconcing.Tables(0)
            cmbconceptoing.DisplayMember = readconcing.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbconceptoing.ValueMember = readconcing.Tables(0).Columns(0).Caption.ToString
            cmbconceptoing.SelectedIndex = -1

            Reconectar()
            Dim tablaconceptoeg As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concepto from fact_egresos_concepto", conexionPrinc)
            Dim readconceg As New DataSet
            tablaconceptoeg.Fill(readconceg)
            cmbconceptoegreso.DataSource = readconceg.Tables(0)
            cmbconceptoegreso.DisplayMember = readconceg.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbconceptoegreso.ValueMember = readconceg.Tables(0).Columns(0).Caption.ToString
            cmbconceptoegreso.SelectedIndex = -1

            Reconectar()
            Dim tablaivat As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_ivatipo", conexionPrinc)
            Dim readivat As New DataSet
            tablaivat.Fill(readivat)
            cmbtipocontr.DataSource = readivat.Tables(0)
            cmbtipocontr.DisplayMember = readivat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbtipocontr.ValueMember = readivat.Tables(0).Columns(0).Caption.ToString
            cmbtipocontr.SelectedIndex = -1

            cmbproviva.DataSource = readivat.Tables(0)
            cmbproviva.DisplayMember = readivat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbproviva.ValueMember = readivat.Tables(0).Columns(0).Caption.ToString
            cmbproviva.SelectedIndex = -1

            Reconectar()
            Dim tablacajas As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_cajas", conexionPrinc)
            Dim readcajas As New DataSet
            Dim readcajas2 As New DataSet
            tablacajas.Fill(readcajas)
            tablacajas.Fill(readcajas2)

            cmbcajas.DataSource = readcajas.Tables(0)
            cmbcajas.DisplayMember = readcajas.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcajas.ValueMember = readcajas.Tables(0).Columns(0).Caption.ToString
            cmbcajas.SelectedValue = My.Settings.CajaDef

            cmbcajaeg.DataSource = readcajas.Tables(0)
            cmbcajaeg.DisplayMember = readcajas.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcajaeg.ValueMember = readcajas.Tables(0).Columns(0).Caption.ToString
            cmbcajaeg.SelectedValue = My.Settings.CajaDef

            cmbctade.DataSource = readcajas.Tables(0)
            cmbctade.DisplayMember = readcajas.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbctade.ValueMember = readcajas.Tables(0).Columns(0).Caption.ToString
            cmbctade.SelectedIndex = -1

            cmbctahacia.DataSource = readcajas2.Tables(0)
            cmbctahacia.DisplayMember = readcajas2.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbctahacia.ValueMember = readcajas2.Tables(0).Columns(0).Caption.ToString
            cmbctahacia.SelectedIndex = -1

            Reconectar()
            Dim tablaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, razon from fact_proveedores", conexionPrinc)
            Dim readprov As New DataSet
            tablaprov.Fill(readprov)
            cmbproveedores.DataSource = readprov.Tables(0)
            cmbproveedores.DisplayMember = readprov.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbproveedores.ValueMember = readprov.Tables(0).Columns(0).Caption.ToString
            cmbproveedores.SelectedIndex = -1

            txtptovta.Text = String.Format("{0:0000}", ptovta)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub cargarCliente()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cl.nomapell_razon as clie, cl.dir_domicilio, lc.nombre," _
            & " cl.iva_tipo, cl.cuit from fact_clientes as cl,  cm_localidad as lc where lc.id=cl.dir_localidad and  idclientes = " & txtctaclie.Text, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            txtrazon.Text = infocl(0)(0)
            txtdomicilio.Text = infocl(0)(1)
            txtciudad.Text = infocl(0)(2)
            cmbtipocontr.SelectedValue = infocl(0)(3)
            txtcuit.Text = infocl(0)(4)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CalcularTotalescobro()
        Try
            Dim totalFact As Double
            Dim totalVal As Double
            Dim totalEfect As Double = FormatNumber(txttotalefectivo.Text)
            Dim totalTarjeta As Double
            Dim totalretenc As Double = FormatNumber(txtretenciones.Text)
            Dim totaltransf As Double = FormatNumber(txttransferencias.Text)

            For Each concfactura As DataGridViewRow In dtconceptos.Rows
                If Not IsNothing(concfactura.Cells(2).Value) Then totalFact += FormatNumber(concfactura.Cells(2).Value, 2)
            Next

            For Each cheque As DataGridViewRow In dtcheques.Rows
                If Not IsNothing(cheque.Cells(3).Value) Then totalVal += FormatNumber(cheque.Cells(3).Value, 2)
            Next

            For Each tarjeta As DataGridViewRow In dttarjetas.Rows
                If Not IsNothing(tarjeta.Cells(0).Value) Then totalTarjeta += FormatNumber(tarjeta.Cells(0).Value, 2)
            Next


            txttotalfact.Text = totalFact
            txttotalvalores.Text = totalVal
            txttotaltarjeta.Text = totalTarjeta
            txttotalrecibo.Text = totalVal + totalEfect + totalretenc + totaltransf + totalTarjeta
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CalcularTotalespago()
        Try
            Dim i As Integer
            Dim totalFact As Double = 0
            Dim totalVal As Double = 0
            Dim totalEfect As Double = 0

            For i = 0 To dtfacturaspago.RowCount - 1
                totalFact += FormatNumber(dtfacturaspago.Rows(i).Cells(2).Value, 2)

            Next

            For i = 0 To dtopcheques.RowCount - 1
                totalVal += FormatNumber(dtopcheques.Rows(i).Cells(4).Value)
            Next

            totalEfect = FormatNumber(txttotalefectivopago.Text)

            txttotalfacturaspago.Text = totalFact
            txttotalvalorespago.Text = totalVal
            txttotalop.Text = totalVal + totalEfect

            'MsgBox("total facturas: " & totalFact & "  total valores: " & totalVal & " total Efect: " & totalEfect & " total OP: " & totalEfect + totalVal)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CalcularTotalesMovimiento()
        Try
            Dim i As Integer
            Dim totalFact As Double = 0
            Dim totalVal As Double = 0
            Dim totalEfect As Double = 0

            For i = 0 To dtmovimientocheques.RowCount - 1
                totalVal += FormatNumber(dtmovimientocheques.Rows(i).Cells(4).Value)
            Next

            totalEfect = FormatNumber(txtmontotrans.Text)


            txtmovimientovalores.Text = totalVal
            txttotalmovimiento.Text = totalVal + totalEfect

            'MsgBox("total facturas: " & totalFact & "  total valores: " & totalVal & " total Efect: " & totalEfect & " total OP: " & totalEfect + totalVal)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtctaclie_KeyUp(sender As Object, e As KeyEventArgs) Handles txtctaclie.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                cargarCliente()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtrazon_KeyUp(sender As Object, e As KeyEventArgs) Handles txtrazon.KeyUp

    End Sub


    Private Sub dtconceptos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtconceptos.CellEndEdit
        Try
            If e.ColumnIndex = 1 And dtconceptos.Rows(e.RowIndex).Cells(1).Value.ToString <> "%" Then
                Reconectar()
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select cta.id,fi.abrev,lpad(fa.ptovta,4,'0'),lpad(fa.num_fact,8,'0'),fa.total,fa.id from fact_conffiscal as fi, fact_facturas as fa, fact_cuentaclie as cta " _
                & "where cta.pago=0 and cta.idcomp=fa.id and fa.tipofact=fi.donfdesc and fa.num_fact like '" & dtconceptos.Rows(e.RowIndex).Cells(1).Value & "' and cta.idclie=" & Val(txtctaclie.Text), conexionPrinc)
                Dim tablacl As New DataTable
                Dim infocl() As DataRow
                consulta.Fill(tablacl)
                infocl = tablacl.Select("")
                If tablacl.Rows.Count = 0 Then
                    MsgBox("No se encuentra el comprobante, no pertenece al cliente o ya esta saldado")
                    Exit Sub
                End If
                dtconceptos.Rows(e.RowIndex).Cells(0).Value = infocl(0)(0)
                dtconceptos.Rows(e.RowIndex).Cells(1).Value = infocl(0)(1) & " " & infocl(0)(2) & "-" & infocl(0)(3)
                dtconceptos.Rows(e.RowIndex).Cells(2).Value = infocl(0)(4)
                dtconceptos.Rows(e.RowIndex).Cells(3).Value = infocl(0)(5)

                CalcularTotalescobro()
            ElseIf e.ColumnIndex = 1 And dtconceptos.Rows(e.RowIndex).Cells(1).Value.ToString = "%" Then
                With selfac
                    .fila = e.RowIndex
                    .LLAMA = "ingreso"
                    .provclie = txtctaclie.Text
                    .Show()
                    .TopMost = True
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub movimientodecaja_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub

    Private Sub movimientodecaja_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F12 Then
            Dim nvafech As String = InputBox("ingrese nueva fecha", "cambio de fecha de factura")
            If nvafech <> "" And IsDate(nvafech) Then
                fechagral = nvafech
                lblfecha.Text = Format(CDate(nvafech), "dd-MMMM-yyyy")
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub movimientodecaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarDatosGrales()
            pagrecibos.Parent = Nothing
            pagordenpago.Parent = Nothing
            pagtrans.Parent = Nothing
            lblfecha.Text = fechagral


            If InStr(DatosAcceso.Moduloacc, "4al") <> False Then
                grpCuentaContable.Visible = True
                Dim consPlanCuentas As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,concat(grupo,subgrupo,cuenta,'.',subcuenta,cuentadetalle) as codigoCuenta, 
                concat(nombreCuenta,'<>',concat(grupo,subgrupo,cuenta,subcuenta,cuentadetalle)) as nombreCuenta
                FROM cm_planDeCuentas where cuentaMovimiento=1 order by grupo,subGrupo,cuenta,subCuenta,cuentaDetalle", conexionPrinc)
                Dim tabCtasDebe As New DataSet
                Dim tabCtasHaber As New DataSet
                consPlanCuentas.Fill(tabCtasDebe)
                consPlanCuentas.Fill(tabCtasHaber)


                cmbCuentaDebe.DataSource = tabCtasDebe.Tables(0)
                cmbCuentaDebe.DisplayMember = tabCtasDebe.Tables(0).Columns("nombreCuenta").Caption.ToString
                cmbCuentaDebe.ValueMember = tabCtasDebe.Tables(0).Columns("id").Caption.ToString

                cmbCuentaHaber.DataSource = tabCtasHaber.Tables(0)
                cmbCuentaHaber.DisplayMember = tabCtasHaber.Tables(0).Columns("nombreCuenta").Caption.ToString
                cmbCuentaHaber.ValueMember = tabCtasHaber.Tables(0).Columns("id").Caption.ToString
            End If

            If movrap = True Then
                Select Case movraptip
                    Case 996
                        cmbtipofac.SelectedValue = movraptip
                        txtctaclie.Text = movrapclie
                        txtconceptos.Text = movrapConc
                        cargarCliente()
                        '                        MsgBox("(" & movrapFact & ")" & cargarInfoFactCobro(movrapFact)(0) & "__" & cargarInfoFactCobro(movrapFact)(1) & "__" & cargarInfoFactCobro(movrapFact)(2) & "__" & cargarInfoFactCobro(movrapFact)(3))
                        'dtconceptos.Rows.Add(cargarInfoFactCobro(movrapFact)(0), cargarInfoFactCobro(movrapFact)(1), cargarInfoFactCobro(movrapFact)(2), cargarInfoFactCobro(movrapFact)(3))
                    Case 993
                        cmbtipofac.SelectedValue = movraptip
                        txtctaclie.Text = movrapclie
                        cmbproveedores.SelectedValue = movrapclie
                End Select

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbtipofac_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbtipofac.SelectedValueChanged
        Try
            If cmbtipofac.SelectedIndex = -1 Then
                txtnufac.Text = ""
                Exit Sub
            End If
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select confnume from fact_conffiscal where donfdesc=" & cmbtipofac.SelectedValue & " and ptovta=" & ptovta

            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            txtnufac.Text = CompletarCeros(FormatNumber(lector("confnume").ToString) + 1, 1)
            If cmbtipofac.SelectedValue = 996 Then
                pagrecibos.Parent = TabControl1
                pagordenpago.Parent = Nothing
                pagtrans.Parent = Nothing
                If InStr(DatosAcceso.Moduloacc, "4al") <> False Then
                    cmbCuentaDebe.SelectedValue = 5
                    cmbCuentaHaber.SelectedValue = 11 'cuenta deudores por publicidad
                End If
            ElseIf cmbtipofac.SelectedValue = 993 Then
                pagrecibos.Parent = Nothing
                pagtrans.Parent = Nothing
                pagordenpago.Parent = TabControl1
                If InStr(DatosAcceso.Moduloacc, "4al") <> False Then
                    cmbCuentaHaber.SelectedValue = 5
                End If
            ElseIf cmbtipofac.SelectedValue = 994 Then
                pagtrans.Parent = TabControl1
                pagordenpago.Parent = Nothing
                pagrecibos.Parent = Nothing
            Else

                pagtrans.Parent = Nothing
                pagordenpago.Parent = Nothing
                pagrecibos.Parent = Nothing
                txtnufac.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ptovta As String = txtptovta.Text

        Dim fecha As String = Format(CDate(fechagral), "yyyy-MM-dd")
        Dim idcliente As String = txtctaclie.Text
        Dim razon As String = txtrazon.Text
        Dim direccion As String = txtdomicilio.Text
        Dim localidad As String = txtciudad.Text
        Dim tipocontr As String = cmbtipocontr.Text
        Dim cuit As String = txtcuit.Text

        Dim totalRecibo As String = remplazarPunto(txttotalrecibo.Text)
        Dim totalRetenciones As String = remplazarPunto(txtretenciones.Text)
        Dim totalTarjetas As String = remplazarPunto(txttotaltarjeta.Text)
        Dim totalCheques As String = remplazarPunto(txttotalvalores.Text)
        Dim totalEfectivo As String = remplazarPunto(txttotalefectivo.Text)
        Dim NetodeRetenciones As String = CDbl(totalRecibo.Replace(".", ",")) - CDbl(totalRetenciones.Replace(".", ","))
        'MsgBox (NetodeRetenciones )
        Dim tipoFact As Integer = cmbtipofac.SelectedValue
        Dim num_fact As Integer = CType(txtnufac.Text, Integer)
        Dim sqlQuery As String
        Dim conceptos As String = txtconceptos.Text.ToUpper


        If Button1.Text = "Cerrar" Then
            Me.Close()
            Exit Sub
        End If

        If InStr(DatosAcceso.Moduloacc, "4al") <> False Then
            If cmbCuentaDebe.SelectedValue = cmbCuentaHaber.SelectedValue Then
                MsgBox("LA CUENTA DE ORIGEN Y DESTINO DEBEN SER DISTINTAS PARA REALIZAR EL MOVIMIENTO")
                Exit Sub
            End If
        Else
            ' MsgBox("no se permite asiento contable")
        End If

        If txttotalefectivo.Text = "" Then
            MsgBox("debe ingresar al menos cero en el monto en efectivo")
            Exit Sub
        End If
        If Not IsNumeric(txttotalrecibo.Text) Or txttotalrecibo.Text = "0" Or txttotalrecibo.Text = "" Then
            MsgBox("el recibo no puede ser cero!")
            Exit Sub
        End If

        Try

            Reconectar()

            If RestringirNumerosFact(cmbtipofac.SelectedValue, num_fact, ptovta) = True Then
                MsgBox("El numero de comprobante ya existe para este tipo y el sistema no pudo reparar el error, 
                por favor contacte con el administrador o repare la numeración manualmente")
                Exit Sub
            End If


            sqlQuery = "insert into fact_facturas  " _
                & "(tipofact,ptovta, num_fact,fecha,id_cliente,razon,direccion,localidad,tipocontr,cuit,total,observaciones) values " _
                & "(?tipofact, ?ptov,?nfac,?fech,?idclie,?razon,?dire,?loca,?tipocont,?cuit,?tot,?observa)"

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?ptov", Val(ptovta))
                .AddWithValue("?tipofact", tipoFact)
                .AddWithValue("?nfac", Val(num_fact))
                .AddWithValue("?fech", fecha)
                .AddWithValue("?idclie", idcliente)
                .AddWithValue("?razon", razon)
                .AddWithValue("?dire", direccion)
                .AddWithValue("?loca", localidad)
                .AddWithValue("?tipocont", tipocontr)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?tot", totalRecibo)
                .AddWithValue("?observa", conceptos)
            End With
            comandoadd.ExecuteNonQuery()
            idfactura = comandoadd.LastInsertedId

            'guardamos el cheque
            For Each cheque As DataGridViewRow In dtcheques.Rows
                Reconectar()
                If Not IsNothing(cheque.Cells(3).Value) Then
                    sqlQuery = "insert into fact_cheques " _
                & "(cliente,comprobante,fecha_cobro,banco,serie,importe,tipo_cheque) values " _
                & "(?cliente,?comprobante,?fcobro,?banco,?serie,?importe,'1')"
                    Dim comandoch As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                    With comandoch.Parameters
                        .AddWithValue("?cliente", idcliente)
                        .AddWithValue("?comprobante", idfactura)
                        .AddWithValue("?banco", cheque.Cells(0).Value.ToString.ToUpper)
                        .AddWithValue("?serie", cheque.Cells(1).Value.ToString.ToUpper)
                        .AddWithValue("?fcobro", cheque.Cells(2).Value)
                        .AddWithValue("?importe", remplazarPunto(cheque.Cells(3).Value))
                    End With
                    comandoch.ExecuteNonQuery()
                End If
            Next

            For Each tarjeta As DataGridViewRow In dttarjetas.Rows
                Reconectar()
                If Not IsNothing(tarjeta.Cells(0).Value) Then
                    sqlQuery = "insert into fact_tarjetas " _
                & "(fecha,nombre,autorizacion,cliente,importe,comprobante) values " _
                & "(?fecha,?nombre,?autorizacion,?cliente,?importe,?comprobante)"
                    Dim comandoch As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                    With comandoch.Parameters
                        .AddWithValue("?cliente", idcliente)
                        .AddWithValue("?comprobante", idfactura)
                        .AddWithValue("?nombre", tarjeta.Cells(1).Value.ToString.ToUpper)
                        .AddWithValue("?autorizacion", tarjeta.Cells(2).Value.ToString.ToUpper)
                        .AddWithValue("?fecha", fecha)
                        .AddWithValue("?importe", remplazarPunto(tarjeta.Cells(0).Value))
                    End With
                    comandoch.ExecuteNonQuery()
                End If
            Next

            If txttransferencias.Text <> "" Or txttransferencias.Text <> "0" Then
                Reconectar()
                sqlQuery = "insert into fact_transferencias (fecha, cliente, importe, comprobante) values " _
                & "(?fecha,?cliente,?importe,?comprobante)"
                Dim comandotrans As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandotrans.Parameters
                    .AddWithValue("?fecha", fecha)
                    .AddWithValue("?cliente", idcliente)
                    .AddWithValue("?importe", remplazarPunto(txttransferencias.Text))
                    .AddWithValue("?comprobante", idfactura)
                    '.AddWithValue("?cuenta", )
                End With
                comandotrans.ExecuteNonQuery()
            End If

            If txtretenciones.Text <> "" Or txtretenciones.Text <> "0" Then
                Reconectar()
                sqlQuery = "insert into fact_retenciones (fecha, cliente, importe, comprobante) values " _
                & "(?fecha,?cliente,?importe,?comprobante)"
                Dim comandoreten As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoreten.Parameters
                    .AddWithValue("?fecha", fecha)
                    .AddWithValue("?cliente", idcliente)
                    .AddWithValue("?importe", remplazarPunto(txtretenciones.Text))
                    .AddWithValue("?comprobante", idfactura)
                    '.AddWithValue("?cuenta", )
                End With
                    comandoreten.ExecuteNonQuery()
                    If InStr(DatosAcceso.Moduloacc, "4al") <> False Then
                        'MsgBox(total & "             " & CDbl(total) & "               " & CDbl(total.Replace(".", ",")))
                        Dim numAsiento As Integer = ObtenerNumeroAsiento()
                        GuardarAsientoContable(numAsiento, cmbtipofac.Text & " " & txtptovta.Text & "-" & txtnufac.Text,
                                               "RETENCIONES " & txtrazon.Text, CDbl(totalRetenciones.Replace(".", ",")), 97,
                                               CDbl(totalRetenciones.Replace(".", ",")), cmbCuentaDebe.SelectedValue, 2, fecha)

                    Else
                        ' MsgBox("no se permite asiento contable")
                    End If
                End If

            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_conffiscal set confnume=" & Val(num_fact) & " where donfdesc= " & cmbtipofac.SelectedValue & " and ptovta=" & ptovta
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            'GUARDAMOS EL MOVIMIENTO DE CUENTA 
            If InStr(DatosAcceso.Moduloacc, "4al") <> False Then
                'MsgBox(total & "             " & CDbl(total) & "               " & CDbl(total.Replace(".", ",")))
                Dim numAsiento As Integer = ObtenerNumeroAsiento()
                GuardarAsientoContable(numAsiento, cmbtipofac.Text & " " & txtptovta.Text & "-" & txtnufac.Text,
                                       "PAGO FACTURA " & txtrazon.Text, CDbl(totalRecibo.Replace(".", ",")), cmbCuentaDebe.SelectedValue,
                                       CDbl(totalRecibo.Replace(".", ",")), cmbCuentaHaber.SelectedValue, 2, fecha)
            Else
                ' MsgBox("no se permite asiento contable")
            End If

            Dim cod As String
            Dim descripcion As String
            Dim ptotal As String
            'Dim num_fact As String           '            Dim sqlQuery As String
            Dim i As Integer
            Dim idAlmacen As Integer = My.Settings.idAlmacen
            Dim idCaja As Integer = My.Settings.CajaDef
            'num_fact = idfactura
            If Val(num_fact) = 0 Then
                MsgBox("No se pueden guardar los items del recibo")
                Exit Sub
            End If

            For Each factconcepto As DataGridViewRow In dtconceptos.Rows
                cod = "0"
                descripcion = factconcepto.Cells(1).Value
                ptotal = factconcepto.Cells(2).Value
                Dim numcomp As String = cmbtipofac.Text & " " & txtptovta.Text & "-" & txtnufac.Text

                'poner factura como pagada

                'Dim lector As System.Data.IDataReader
                'Dim sql As New MySql.Data.MySqlClient.MySqlCommand

                Reconectar()
                sql.Connection = conexionPrinc
                sql.CommandText = "update fact_cuentaclie set pago=1 where id= " & factconcepto.Cells(0).Value
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()

                Reconectar()
                sql.Connection = conexionPrinc
                sql.CommandText = "update fact_facturas set observaciones2=concat(observaciones2,'\n','" & numcomp & "') where id= " & factconcepto.Cells(3).Value
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()

                sqlQuery = "insert into fact_items " _
                & "(cod, descripcion, ptotal, tipofact,idAlmacen,idCaja, id_fact) values" _
                & "(?cod,?desc,?ptot,?tipofact,?idAlmacen,?idCaja,?id_fact)"

                Reconectar()
                Dim addItemRec As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With addItemRec.Parameters
                    .AddWithValue("?cod", cod)
                    .AddWithValue("?desc", descripcion)
                    .AddWithValue("?ptot", ptotal)
                    .AddWithValue("?tipofact", cmbtipofac.SelectedValue)
                    .AddWithValue("?idAlmacen", idAlmacen)
                    .AddWithValue("?idCaja", idCaja)
                    .AddWithValue("?id_fact", idfactura)
                End With
                addItemRec.ExecuteNonQuery()

            Next

            MsgBox("Recibo guardado satisfactoriamente")
            Button1.Text = "Cerrar"

            '    Dim sqlQuery As String

            sqlQuery = "insert into fact_cuentaclie " _
            & "(idclie,idcomp,pago) values" _
            & "(?clie, ?idcomp,'1')"
            Reconectar()
            Dim addCtaClie As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With addCtaClie.Parameters
                .AddWithValue("?clie", txtctaclie.Text)
                .AddWithValue("?idcomp", idfactura)
            End With
            addCtaClie.ExecuteNonQuery()
            'MsgBox("Cuenta corriente actualizada")
            'actualizamos la caja
            '    Dim sqlQuery As String
            sqlQuery = "insert into fact_ingreso_egreso " _
                    & "(concepto,monto,comprobante,caja,tipo,descripcion) values" _
                    & "(?conc,?monto,?comp,?caja,'1',?desc)"

            Reconectar()
            Dim addCaja As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With addCaja.Parameters
                .AddWithValue("?monto", NetodeRetenciones)
                .AddWithValue("?comp", idfactura)
                .AddWithValue("?caja", cmbcajas.SelectedValue)
                .AddWithValue("?conc", cmbconceptoing.SelectedValue)
                .AddWithValue("?desc", txtconceptos.Text.ToUpper)

            End With
            addCaja.ExecuteNonQuery()
            'MsgBox("caja actualizada")
            Button1.Text = "Cerrar"

            'Button1.Enabled = False
            Button3.Enabled = True
        Catch ex As Exception

        End Try
        'End If
    End Sub
    Public Sub cargarCuentaProv(ByRef idprov As Integer)
        Dim debegral As Double = 0
        Dim habergral As Double = 0
        Dim saldo As Double = 0

        Try
            Reconectar()
            Dim consultaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select direccion,
            tipo_iva, cuit, cuentagastos from fact_proveedores where id=" & idprov, conexionPrinc)

            Dim tablaprov As New DataTable
            consultaprov.Fill(tablaprov)
            Dim dtoprov() As DataRow
            dtoprov = tablaprov.Select()
            txtprovdireccion.Text = dtoprov(0)(0)
            cmbproviva.SelectedValue = dtoprov(0)(1)
            txtprovcuit.Text = dtoprov(0)(2)
            If InStr(DatosAcceso.Moduloacc, "4al") <> False Then
                cmbCuentaDebe.SelectedValue = dtoprov(0)("cuentagastos")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbproveedores_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbproveedores.SelectedValueChanged
        Try
            cargarCuentaProv(cmbproveedores.SelectedValue)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles cmbopguardar.Click


        Try
            'Dim idOP As Integer
            Dim num_fact As String = txtptovta.Text & "-" & txtnufac.Text
            Dim numerofact_conf As String = CType(txtnufac.Text, Integer)
            Dim fecha As String = Format(CDate(fechagral), "yyyy-MM-dd")
            Dim idprov As String = cmbproveedores.SelectedValue
            Dim total As String = remplazarPunto(txttotalop.Text)
            Dim tipoFact As Integer = cmbtipofac.SelectedValue


            Dim sqlQuery As String
            If idprov Is Nothing Then idprov = 0


            If RestringirNumerosFact(cmbtipofac.SelectedValue, num_fact, ptovta) = True Then
                MsgBox("El numero de comprobante ya existe para este tipo y el sistema no pudo reparar el error, 
                por favor contacte con el administrador o repare la numeración manualmente")
                Exit Sub
            End If

            Reconectar()
            Dim addfact As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_proveedores_fact  
            (fecha, tipo, numero, monto, vencimiento,idproveedor,tipoingeg) values 
            (?fecha,?tipo,?numero,?monto,?fecha,?prov,'2')", conexionPrinc)
            With addfact.Parameters
                .AddWithValue("?tipo", tipoFact)
                .AddWithValue("?numero", num_fact)
                .AddWithValue("?fecha", fecha)
                .AddWithValue("?monto", total)
                .AddWithValue("?prov", idprov)
                .AddWithValue("?venc", fecha)
                '.AddWithValue("?confnume", numerofact_conf)
            End With
            addfact.ExecuteNonQuery()
            idfactura = addfact.LastInsertedId

            Reconectar()
            Dim UpdFiscal As New MySql.Data.MySqlClient.MySqlCommand("Update fact_conffiscal Set confnume= " & numerofact_conf & " where donfdesc=" & tipoFact & " and ptovta=" & ptovta, conexionPrinc)
            UpdFiscal.ExecuteNonQuery()


            Dim cod As String
            Dim descripcion As String
            Dim ptotal As String
            'Dim num_fact As String
            Dim i As Integer
            'num_fact = idfactura
            If Val(num_fact) = 0 Then
                MsgBox("No se pueden guardar los items de la orden de pago")
                Exit Sub
            End If

            For i = 0 To dtfacturaspago.RowCount - 1
                descripcion = dtfacturaspago.Rows(i).Cells(1).Value
                ptotal = remplazarPunto(dtfacturaspago.Rows(i).Cells(2).Value)
                'poner factura como pagada
                Reconectar()
                Dim actualizaFactProv As New MySql.Data.MySqlClient.MySqlCommand("update fact_proveedores_fact set pagada=1 where id=" & dtfacturaspago.Rows(i).Cells(0).Value, conexionPrinc)
                actualizaFactProv.ExecuteNonQuery()


                Reconectar()
                Dim agregaItemOP As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_pagoitems (descripcion, ptotal,num_fact) values (?desc,?ptot,?num_fact)", conexionPrinc)
                With agregaItemOP.Parameters
                    .AddWithValue("?desc", descripcion)
                    .AddWithValue("?ptot", ptotal)
                    .AddWithValue("?num_fact", idfactura)
                End With
                agregaItemOP.ExecuteNonQuery()
            Next

            For Each cheque As DataGridViewRow In dtopcheques.Rows
                Reconectar()
                Dim SqlCh As String = "update fact_cheques set estado_cheque='4', comprobante_eg='" & idfactura & "' where id=" & cheque.Cells(0).Value
                Dim UpdCheque As New MySql.Data.MySqlClient.MySqlCommand(SqlCh, conexionPrinc)
                UpdCheque.ExecuteNonQuery()
            Next


            MsgBox("Orden de pago guardada satisfactoriamente")

            Reconectar()
            Dim agregaCaja As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_ingreso_egreso " _
                    & "(concepto,monto,comprobante,caja,tipo, descripcion) values" _
                    & "(?conc,?monto,?comp,?caja,'2', ?desc)", conexionPrinc)
            With agregaCaja.Parameters
                .AddWithValue("?monto", remplazarPunto(txttotalop.Text))
                .AddWithValue("?comp", idfactura)
                .AddWithValue("?caja", cmbcajaeg.SelectedValue)
                .AddWithValue("?conc", cmbconceptoegreso.SelectedValue)
                .AddWithValue("?desc", txtdescripcionop.Text.ToUpper)
            End With
            agregaCaja.ExecuteNonQuery()
            If InStr(DatosAcceso.Moduloacc, "4al") <> False Then
                Dim numAsiento As Integer = ObtenerNumeroAsiento()
                GuardarAsientoContable(numAsiento,
                                           cmbtipofac.Text & " " & txtptovta.Text & "-" & txtnufac.Text,
                                           txtdescripcionop.Text.ToUpper & "-" & cmbproveedores.Text,
                                           CDbl(total.Replace(".", ",")),
                                           cmbCuentaDebe.SelectedValue,
                                           CDbl(total.Replace(".", ",")),
                                           cmbCuentaHaber.SelectedValue, 2, fecha)
            End If
            cargarCuentaProv(movrapclie)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Close()
    End Sub

    Private Sub dtfacturaspago_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        Try
            If e.ColumnIndex = 1 And dtfacturaspago.Rows(e.RowIndex).Cells(1).Value.ToString <> "" Then
                With selfac
                    .fila = e.RowIndex
                    .LLAMA = "egreso"
                    .provclie = cmbproveedores.SelectedValue
                    .Show()
                    .TopMost = True
                End With
                CalcularTotalespago()
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub chksinprov_CheckedChanged(sender As Object, e As EventArgs) Handles chksinprov.CheckedChanged
        If chksinprov.CheckState = CheckState.Checked Then
            pnproveedor.Enabled = False
            cmbproveedores.SelectedIndex = -1
        Else
            pnproveedor.Enabled = True
        End If
    End Sub

    Private Sub cmbrealizartrans_Click(sender As Object, e As EventArgs) Handles cmbrealizartrans.Click
        Try
            Dim sqlQuery As String
            Dim idfacturade As Integer
            Dim idfacturahacia As Integer

            Dim ptovta As String = txtptovta.Text
            Dim num_fact As String = txtptovta.Text & "-" & txtnufac.Text
            Dim fecha As String = Format(CDate(fechagral), "yyyy-MM-dd")
            Dim total As String = remplazarPunto(txttotalmovimiento.Text)
            Dim tipoFact As Integer = cmbtipofac.SelectedValue

            If cmbctade.SelectedValue = cmbctahacia.SelectedValue Then
                MsgBox("las cuentas de origen y destino deben ser distintas")
                Exit Sub
            End If

            If cmbctade.SelectedValue = 0 Or cmbctahacia.SelectedValue = 0 Then
                MsgBox("una de las cuentas no es valida, verifique")
                Exit Sub
            End If

            If RestringirNumerosFact(cmbtipofac.SelectedValue, num_fact, ptovta) = True Then
                MsgBox("El numero de comprobante ya existe para este tipo y el sistema no pudo reparar el error, 
                por favor contacte con el administrador o repare la numeración manualmente")
                Exit Sub
            End If
            '********INSERTAMOS EN LA TABLA PROVEEDORES**********************
            Reconectar()
            sqlQuery = "insert into fact_proveedores_fact  " _
                & "(fecha, tipo, numero, monto,tipoingeg) values " _
                & "(?fecha,?tipo,?numero,?monto,'2')"

            Dim comandoaddde As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoaddde.Parameters
                .AddWithValue("?tipo", tipoFact)
                .AddWithValue("?numero", num_fact)
                .AddWithValue("?fecha", fecha)
                .AddWithValue("?monto", total)
            End With
            comandoaddde.ExecuteNonQuery()
            idfacturade = comandoaddde.LastInsertedId


            '******************INSERTAMOS EN LA TABLA DE FACTURAS*******************************
            Reconectar()
            sqlQuery = "insert into fact_facturas  " _
                & "(tipofact,ptovta, num_fact,fecha,total) values " _
                & "(?tipofact, ?ptov,?nfac,?fech,?tot)"

            Dim comandoaddhacia As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoaddhacia.Parameters
                .AddWithValue("?ptov", Val(ptovta))
                .AddWithValue("?tipofact", tipoFact)
                .AddWithValue("?nfac", Val(num_fact))
                .AddWithValue("?fech", fecha)
                .AddWithValue("?tot", total)
            End With
            comandoaddhacia.ExecuteNonQuery()
            idfacturahacia = comandoaddhacia.LastInsertedId

            '********************************************************************************************************************

            '************************actualizamos el numero de transaccion*******************************************************
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_conffiscal set confnume=" & Val(txtnufac.Text) & " where donfdesc= " & cmbtipofac.SelectedValue & " and ptovta=" & ptovta
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()


            '****************************************************************************************************************
            sqlQuery = "insert into fact_ingreso_egreso " _
                & "(concepto,monto,comprobante,caja,tipo) values" _
                & "('10',?monto,?comp,?caja,'2')"

            Reconectar()
            Dim comandoaddeg As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoaddeg.Parameters
                .AddWithValue("?monto", remplazarPunto(txttotalmovimiento.Text))
                .AddWithValue("?comp", idfacturade)
                .AddWithValue("?caja", cmbctade.SelectedValue)

            End With
            comandoaddeg.ExecuteNonQuery()

            sqlQuery = "insert into fact_ingreso_egreso " _
                & "(concepto,monto,comprobante,caja,tipo) values" _
                & "('4',?monto,?comp,?caja,'1')"

            Reconectar()
            Dim comandoadding As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadding.Parameters
                .AddWithValue("?monto", remplazarPunto(txttotalmovimiento.Text))
                .AddWithValue("?comp", idfacturahacia)
                .AddWithValue("?caja", cmbctahacia.SelectedValue)
                .AddWithValue("?conc", cmbconceptoing.SelectedValue)
            End With
            comandoadding.ExecuteNonQuery()

            For Each cheque As DataGridViewRow In dtmovimientocheques.Rows
                Reconectar()
                Dim SqlCh As String = "update fact_cheques set estado_cheque='3', cuenta='" & cmbctahacia.SelectedValue & "', comprobante_eg = '" & idfacturahacia & "'" _
                & " where id =" & cheque.Cells(0).Value

                Dim UpdCheque As New MySql.Data.MySqlClient.MySqlCommand(SqlCh, conexionPrinc)
                UpdCheque.ExecuteNonQuery()
            Next

            '********************realizamos el asiento contable en el caso de que sea necesario
            If InStr(DatosAcceso.Moduloacc, "4al") <> False Then
                Dim numAsiento As Integer = ObtenerNumeroAsiento()
                GuardarAsientoContable(numAsiento,
                                           cmbtipofac.Text & " " & txtptovta.Text & "-" & txtnufac.Text,
                                           "MOVIMIENTO ENTRE CUENTAS",
                                           CDbl(total.Replace(".", ",")),
                                           cmbCuentaDebe.SelectedValue,
                                           CDbl(total.Replace(".", ",")),
                                           cmbCuentaHaber.SelectedValue, 2, fecha)
            End If

            MsgBox("caja actualizada")
            Me.Close()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            'Dim idfactura = dtlistacob.CurrentRow.Cells(0).Value
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabVal As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabtarj As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim totrec As New MySql.Data.MySqlClient.MySqlDataAdapter

            Dim fac As New datosfacturas

            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Reconectar()
            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia As empnombre, emp.razonsocial As emprazon, emp.direccion As empdire, emp.localidad As emploca, " _
            & "emp.cuit As empcuit, emp.ingbrutos As empib, emp.ivatipo As empcontr, emp.inicioact As empinicioact, emp.drei As empdrei, emp.logo As emplogo, " _
            & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum,fac.fecha as facfech,concat(fac.id_cliente,'-',fac.razon) as facrazon, " _
            & "fac.direccion As facdire, fac.localidad As facloca, fac.tipocontr As factipocontr, fac.cuit As faccuit, fac.vendedor As facvend, " _
            & "fac.condvta as faccondvta, fac.iva105, fac.iva21,fac.total,  " _
            & "fac.observaciones as facobserva " _
            & "FROM fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac where emp.id=1 and fis.donfdesc=fac.tipofact and fac.id=" & idfactura, conexionPrinc)
            tabEmp.Fill(fac.Tables("factura_enca"))

            Reconectar()
            tabVal.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "banco, serie as numero, fecha_cobro as fcobro, format(importe,2,'es_AR') as importe from fact_cheques where comprobante = " & idfactura, conexionPrinc)
            tabVal.Fill(fac.Tables("valoresrecibo"))


            Reconectar()
            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "descripcion,format(ptotal,2,'es_AR') as ptotal from fact_items where " _
            & "id_fact=" & idfactura, conexionPrinc)
            tabFac.Fill(fac.Tables("reciboitems"))

            Reconectar()
            tabtarj.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "nombre,autorizacion,format(importe,2,'es_AR') as importe from fact_tarjetas where comprobante=" & idfactura, conexionPrinc)
            tabtarj.Fill(fac.Tables(("tarjetarecbo")))

            Reconectar()
            totrec.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT 
                    fact.id,
                    FORMAT(IFNULL((SELECT (replace(importe,',','.')) FROM fact_cheques WHERE comprobante = fact.id ),0),2,'es_AR') as cheques,
                    FORMAT(IFNULL((SELECT (replace(importe,',','.')) FROM fact_transferencias WHERE comprobante = fact.id ),0),2,'es_AR') as transferencias,
                    FORMAT(IFNULL((SELECT (replace(importe,',','.')) FROM fact_retenciones WHERE comprobante = fact.id),0),2,'es_AR') as retenciones,
                    FORMAT(IFNULL((SELECT (replace(importe,',','.')) FROM fact_tarjetas WHERE comprobante = fact.id),0),2,'es_AR') AS tarjeta,
                    FORMAT(replace(fact.total,',','.'),2,'es_AR') as total 
                    FROM fact_facturas as fact where fact.id= " & idfactura, conexionPrinc)
            totrec.Fill(fac.Tables("totalesrecibo"))

            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\recibo.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("valores", fac.Tables("valoresrecibo")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("reciboitems")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("tarjetas", fac.Tables("tarjetarecbo")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("totalesrecibo", fac.Tables("totalesrecibo")))

                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Esta seguro que desea cargar todas las facturas impagas de este cliente?", vbQuestion + vbYesNo) = vbYes Then
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select cta.id, concat(tip.abrev,' ',lpad(fa.ptovta,4,'0') ,'-', lpad(fa.num_fact,8,'0')) comprobante, " _
            & "case " _
            & "when tip.debcred='D' then " _
            & "fa.total " _
            & "when tip.debcred='C' then " _
            & "concat('-',fa.total) " _
            & "end as total, " _
            & "fa.fecha, fa.id from fact_facturas as fa, " _
            & "fact_conffiscal as tip, fact_cuentaclie as cta where cta.pago=0 and fa.id=cta.idcomp and fa.tipofact=tip.donfdesc and cta.idclie= " & txtctaclie.Text, conexionPrinc)
            Dim tablafac As New DataTable
            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            Dim infofac() As DataRow
            consulta.Fill(tablafac)
            infofac = tablafac.Select("")

            Dim i As Integer
            For i = 0 To infofac.GetUpperBound(0)
                dtconceptos.Rows.Add(infofac(i)(0), infofac(i)(1), infofac(i)(2), infofac(i)(4))
                CalcularTotalescobro()
            Next
            Button4.Enabled = False
        End If
    End Sub

    Private Sub txttotal_Validated(sender As Object, e As EventArgs) Handles txttotalfact.Validated
        If txttotalfact.Text = "" Then txttotalfact.Text = 0
    End Sub

    Private Sub txtefectivo_Validated(sender As Object, e As EventArgs) Handles txttotalefectivo.Validated
        If txttotalefectivo.Text = "" Then txttotalefectivo.Text = 0
        CalcularTotalescobro()
    End Sub

    Private Sub dtcheques_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtcheques.CellValueChanged
        Try
            If e.ColumnIndex = 2 Then
                dtcheques.Item(2, dtcheques.RowCount - 1) = SelFech.Clone
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        With cheques_en_cartera
            .lbltotalfacturas.Text = "Total Facturas: $" & txttotalfacturaspago.Text
            .LLAMA = "OP"
            .AplicarOP = False
            .Show()
        End With
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        With selfac
            .LLAMA = "egreso"
            .provclie = cmbproveedores.SelectedValue
            '.fila = dtcuentaclie.CurrentRow.Cells(2).Value
            .Show()
            .TopMost = True
            .AplicarRec = True
            .lbltotalrecibo.Text = "Total OP: $" & txttotalop.Text & " -- "
        End With
    End Sub

    Private Sub txttotalefectivopago_Validated(sender As Object, e As EventArgs) Handles txttotalefectivopago.Validated
        If txttotalefectivopago.Text = "" Then txttotalefectivopago.Text = 0
        CalcularTotalespago()
    End Sub

    Private Sub cmbopimprimir_Click(sender As Object, e As EventArgs) Handles cmbopimprimir.Click

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        With cheques_en_cartera
            .lbltotalfacturas.Text = ""
            .LLAMA = "OPMOV"
            .AplicarOP = False
            .Show()
        End With
    End Sub

    Private Sub txtretenciones_Validated(sender As Object, e As EventArgs) Handles txtretenciones.Validated
        If txtretenciones.Text = "" Then txtretenciones.Text = 0
        CalcularTotalescobro()
    End Sub

    Private Sub txttransferencias_Validated(sender As Object, e As EventArgs) Handles txttransferencias.Validated
        If txttransferencias.Text = "" Then txttransferencias.Text = 0
        CalcularTotalescobro()
    End Sub

    Private Sub dtconceptos_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtconceptos.UserDeletedRow
        CalcularTotalescobro()
    End Sub

    Private Sub dtcheques_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtcheques.UserDeletedRow
        CalcularTotalescobro()
    End Sub



    Private Sub txtmontotrans_TextChanged(sender As Object, e As EventArgs) Handles txtmontotrans.TextChanged
        CalcularTotalesMovimiento()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With selfac
            .LLAMA = "ingreso"
            .provclie = txtctaclie.Text
            '.fila = dtcuentaclie.CurrentRow.Cells(2).Value
            '.MdiParent = Me.MdiParent
            .TopMost = True
            .AplicarRec = False
            .lbltotalrecibo.Text = "Total Recibo: $" & txttotalrecibo.Text & " -- "
            .Show()
        End With
    End Sub

    Private Sub dtcheques_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtcheques.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub dtcheques_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dtcheques.RowValidating

        CalcularTotalescobro()
    End Sub


    Private Sub dttarjetas_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dttarjetas.RowValidating
        CalcularTotalescobro()

    End Sub


    Private Sub dttarjetas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dttarjetas.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
    End Sub


    Private Sub cmbproveedores_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbproveedores.SelectionChangeCommitted
        cargarCuentaProv(cmbproveedores.SelectedValue)
    End Sub

    Private Sub txtrazon_TextChanged(sender As Object, e As EventArgs) Handles txtrazon.TextChanged

    End Sub

    Private Sub txtrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles txtrazon.KeyDown
        If e.KeyCode = Keys.Enter Then
            selclie.busqueda = txtrazon.Text
            selclie.llama = "movimientodecaja"
            selclie.dtpersonal.Focus()
            selclie.Show()
            selclie.TopMost = True
        End If
    End Sub

    Private Sub cmbproveedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbproveedores.SelectedIndexChanged

    End Sub

    Private Sub cmbtipofac_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtipofac.SelectedIndexChanged

    End Sub

    Private Sub dtopcheques_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtopcheques.CellContentClick

    End Sub

    Private Sub dtopcheques_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtopcheques.UserDeletedRow
        CalcularTotalespago()

    End Sub

    Private Sub dtmovimientocheques_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtmovimientocheques.CellContentClick

    End Sub

    Private Sub dtmovimientocheques_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dtmovimientocheques.UserDeletedRow
        CalcularTotalesMovimiento()

    End Sub

    Private Sub dttarjetas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dttarjetas.CellContentClick

    End Sub

    Private Sub dttarjetas_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dttarjetas.RowLeave
        'Dim row As DataGridViewRow = dttarjetas.Rows(e.RowIndex)
        'For Each cell As DataGridViewCell In row.Cells
        '    If IsNothing(cell.Value) And row.Index = dttarjetas.RowCount - 1 Then
        '        MsgBox("debe completar todos los campos requeridos de tarjeta  " & e.RowIndex & " de " & dttarjetas.RowCount)
        '    End If
        'Next
    End Sub
End Class