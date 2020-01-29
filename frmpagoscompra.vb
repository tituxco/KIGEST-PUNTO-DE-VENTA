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
    Dim IdRecibo As Integer
    Dim PtoVta As String = DatosAcceso.IdPtoVtaDef
    Dim PagoCaja As Integer = 1
    Dim NumRecibo As String
    Dim SqlQuery As String

    Private Sub btnefectivo_Click_1(sender As Object, e As EventArgs) Handles btnefectivo.Click
        Reconectar()
        Dim lector As System.Data.IDataReader
        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        sql.Connection = conexionPrinc
        sql.CommandText = "select confnume from fact_conffiscal where donfdesc=" & TipoFac & " and ptovta= " & PtoVta
        sql.CommandType = CommandType.Text
        lector = sql.ExecuteReader
        lector.Read()
        NumRecibo = CompletarCeros(FormatNumber(lector("confnume").ToString) + 1, 1)
        Me.Text = "Recibo: " & CompletarCeros(Val(PtoVta), 2) & "-" & NumRecibo
        lbltotalefectivo.Text = TOTAL
        panelformaspago.Visible = False
        txtefectivo.Focus()

    End Sub

    Private Sub frmpagoscompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub

    Private Sub txtefectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtefectivo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim total As Double = FormatNumber(lbltotalefectivo.Text)
            Dim efectivo As Double = FormatNumber(txtefectivo.Text)
            Dim vuelto As Double

            vuelto = efectivo - total
            txtvuelto.Text = vuelto
            Me.AcceptButton = cmdfinalizar
            cmdfinalizar.Focus()
        End If
    End Sub

    Private Sub cmdfinalizar_Click(sender As Object, e As EventArgs) Handles cmdfinalizar.Click
        Try
            If RestringirNumerosFact(TipoFac, NumRecibo, PtoVta) = True Then
                MsgBox("El numero de comprobante ya existe para este tipo, por favor verifique")
                Exit Sub
            End If


            SqlQuery = "insert into fact_facturas  " _
                & "(tipofact,ptovta, num_fact,fecha,id_cliente,razon,direccion,localidad,tipocontr,cuit,total,observaciones) values " _
                & "(?tipofact, ?ptov,?nfac,?fech,?idclie,?razon,?dire,?loca,?tipocont,?cuit,?tot,?observa)"

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?ptov", Val(PtoVta))
                .AddWithValue("?tipofact", TipoFac)
                .AddWithValue("?nfac", Val(NumRecibo))
                .AddWithValue("?fech", Fecha)
                .AddWithValue("?idclie", CtaClie)
                .AddWithValue("?razon", RazonSocial)
                .AddWithValue("?dire", Direccion)
                .AddWithValue("?loca", Localidad)
                .AddWithValue("?tipocont", tipoContr)
                .AddWithValue("?cuit", CUIT)
                .AddWithValue("?tot", TOTAL)
                .AddWithValue("?observa", "VENTA MOSTRADOR")
            End With
            comandoadd.ExecuteNonQuery()
            IdRecibo = comandoadd.LastInsertedId

            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_conffiscal set confnume=" & Val(NumRecibo) & " where donfdesc= " & TipoFac & " and ptovta=" & PtoVta
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            Reconectar()
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_cuentaclie set pago=1 where id= " & IdFacturaCTA
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            Reconectar()
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_facturas set observaciones2='RBO " & CompletarCeros(Val(PtoVta), 2) & "-" & CompletarCeros(NumRecibo, 1) & "' where id= " & IdFacturaComp
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            SqlQuery = "insert into fact_items " _
                & "(cod, descripcion, ptotal, tipofact,ptovta,num_fact, id_fact) values" _
                & "(?cod,?desc,?ptot,?tipofact,ptovta,?num_fact,?id_fact)"

            Reconectar()
            Dim comandoaddITM As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, conexionPrinc)
            With comandoaddITM.Parameters
                .AddWithValue("?cod", "0")
                .AddWithValue("?desc", CompletarCeros(Val(PtoVta), 2) & "-" & CompletarCeros(NumRecibo, 1)) 'DESCRIPCION
                .AddWithValue("?ptot", TOTAL)
                .AddWithValue("?tipofact", TipoFac)
                .AddWithValue("?ptovta", Val(PtoVta))
                .AddWithValue("?num_fact", Val(NumRecibo))
                .AddWithValue("?id_fact", IdRecibo)
            End With
            comandoaddITM.ExecuteNonQuery()
            puntoventa.Button1.Focus()
            'Try 'actualizamos la caja
            Dim ConsultaCaj As String
            ConsultaCaj = "insert into fact_ingreso_egreso " _
                & "(concepto,monto,comprobante,caja,tipo) values" _
                & "(?conc,?monto,?comp,?caja,'1')"

            Reconectar()
            Dim comandocaj As New MySql.Data.MySqlClient.MySqlCommand(ConsultaCaj, conexionPrinc)
            With comandocaj.Parameters
                    .AddWithValue("?monto", TOTAL)
                    .AddWithValue("?comp", IdRecibo)
                    .AddWithValue("?caja", My.Settings.CajaDef)
                .AddWithValue("?conc", "1")
            End With
            comandocaj.ExecuteNonQuery()
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btntarjeta_Click(sender As Object, e As EventArgs) Handles btntarjeta.Click
        Dim mov As New movimientodecaja
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

    'Private Sub frmpagoscompra_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    'puntoventa.cmdimprimir.PerformClick()
    '    If My.Settings.ImprTikets = 1 Then
    '        puntoventa.cmdimprimir.PerformClick()
    '    End If
    'End Sub
End Class