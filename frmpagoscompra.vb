Imports System.ComponentModel

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
        panelefectivo.Visible = True
        panelTarjetas.Visible = False
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
            Me.AcceptButton = cmdfinalizarEfectivo
            cmdfinalizarEfectivo.Focus()
        End If
    End Sub

    Private Sub cmdfinalizar_Click(sender As Object, e As EventArgs) Handles cmdfinalizarEfectivo.Click
        Try

            Dim idAlmacen As Integer = My.Settings.idAlmacen
            Dim idCaja As Integer = My.Settings.CajaDef
            If RestringirNumerosFact(TipoFac, NumRecibo, PtoVta) = True Then
                MsgBox("El numero de comprobante ya existe para este tipo y el sistema no pudo reparar el error, 
                por favor contacte con el administrador o repare la numeración manualmente")
                panelformaspago.Visible = False
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
                .AddWithValue("?observa", "VENTA CONTADO")
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
                & "(cod, descripcion, ptotal, tipofact,idAlmacen,idCaja, id_fact) values" _
                & "(?cod,?desc,?ptot,?tipofact,?idAlmacen,?idCaja,?id_fact)"

            Reconectar()
            Dim comandoaddITM As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, conexionPrinc)
            With comandoaddITM.Parameters
                .AddWithValue("?cod", "0")
                .AddWithValue("?desc", CompletarCeros(Val(PtoVta), 2) & "-" & CompletarCeros(NumRecibo, 1)) 'DESCRIPCION
                .AddWithValue("?ptot", TOTAL)
                .AddWithValue("?tipofact", TipoFac)
                .AddWithValue("?idAlmacen", idAlmacen)
                .AddWithValue("?idCaja", idCaja)
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

            CType(frmprincipal.ActiveMdiChild, puntoventa).Button1.PerformClick()
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
        lbltotalTarjetas.Text = TOTAL
        mov.CalcularTotalescobro()
        Me.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
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
            Reconectar()
            Dim tablatajetasNombre As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_tarjetasNombres", conexionPrinc)
            Dim readTarjetasNombre As New DataSet
            tablatajetasNombre.Fill(readTarjetasNombre)

            txtTarjetaNombre.DataSource = readTarjetasNombre.Tables(0)
            txtTarjetaNombre.DisplayMember = readTarjetasNombre.Tables(0).Columns("nombre").Caption.ToString.ToUpper
            txtTarjetaNombre.ValueMember = readTarjetasNombre.Tables(0).Columns("id").Caption.ToString
            'cmbTarjetasMarcas.SelectedIndex = -1

            panelformaspago.Visible = False
            panelefectivo.Visible = False
            panelTarjetas.Visible = True
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmdFinalizarTarjeta_Click(sender As Object, e As EventArgs) Handles cmdFinalizarTarjeta.Click
        Try
            Dim idAlmacen As Integer = My.Settings.idAlmacen
            Dim idCaja As Integer = My.Settings.CajaDef
            If RestringirNumerosFact(TipoFac, NumRecibo, PtoVta) = True Then
                MsgBox("El numero de comprobante ya existe para este tipo y el sistema no pudo reparar el error, 
                por favor contacte con el administrador o repare la numeración manualmente")
                panelformaspago.Visible = False
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

            'If Not IsNothing(tarjeta.Cells(0).Value) Then
            SqlQuery = "insert into fact_tarjetas " _
                & "(fecha,nombre,autorizacion,cliente,importe,comprobante) values " _
                & "(?fecha,?nombre,?autorizacion,?cliente,?importe,?comprobante)"
            Dim comandoch As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, conexionPrinc)
            With comandoch.Parameters
                .AddWithValue("?cliente", CtaClie)
                .AddWithValue("?comprobante", IdRecibo)
                .AddWithValue("?nombre", txtTarjetaNombre.Text.ToUpper)
                .AddWithValue("?autorizacion", txtTarjetaAutoriza.Text.ToUpper)
                .AddWithValue("?fecha", Fecha)
                .AddWithValue("?importe", TOTAL)
            End With
            comandoch.ExecuteNonQuery()
            'End If

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
                & "(cod, descripcion, ptotal, tipofact,idAlmacen,idCaja, id_fact) values" _
                & "(?cod,?desc,?ptot,?tipofact,?idAlmacen,?idCaja,?id_fact)"

            Reconectar()
            Dim comandoaddITM As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, conexionPrinc)
            With comandoaddITM.Parameters
                .AddWithValue("?cod", "0")
                .AddWithValue("?desc", CompletarCeros(Val(PtoVta), 2) & "-" & CompletarCeros(NumRecibo, 1)) 'DESCRIPCION
                .AddWithValue("?ptot", TOTAL)
                .AddWithValue("?tipofact", TipoFac)
                .AddWithValue("?idAlmacen", idAlmacen)
                .AddWithValue("?idCaja", idCaja)
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
                .AddWithValue("?caja", idCaja)
                .AddWithValue("?conc", "1")
            End With
            comandocaj.ExecuteNonQuery()
            CType(frmprincipal.ActiveMdiChild, puntoventa).Button1.PerformClick()
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtTarjetaNombre_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

            txtTarjetaAutoriza.Focus()
        End If
    End Sub
    Private Sub txtTarjetaAutoriza_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarjetaAutoriza.KeyDown
        If e.KeyCode = Keys.Enter Then

            cmdFinalizarTarjeta.Focus()
        End If
    End Sub

    Private Sub frmpagoscompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmpagoscompra_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class