Public Class reciboRapido
    Public idFactura As Integer
    Dim ptoVta As Integer = My.Settings.idPtoVta
    Dim numRecibo As Integer
    Dim Concepto As String
    Dim Clie_idCliente As Integer
    Dim Clie_cuit As String
    Dim Clie_tipocontr As String
    Dim Clie_localidad As String
    Dim Clie_direccion As String
    Dim Clie_razonSocial As String

    Dim fac_total As Double
    Dim fac_Numero As String



    Private Sub reciboRapido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
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

            Reconectar()
            Dim consultaFactura As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT 
			(SELECT confnume from fact_conffiscal where donfdesc=996 and ptovta=" & DatosAcceso.IdPtoVtaDef & ") + 1 as recibo, 
            fact.id as idFact, concat(fis.abrev ,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) as factnum,
            fact.razon,fact.direccion, fact.localidad, fact.tipocontr, fact.cuit, 
            fact.id_cliente,format( fact.total,2,'es_AR') as total,(select plu from fact_items where id_fact=fact.id) as concepto            
            from fact_conffiscal as fis,fact_facturas as fact 
            where 
            fis.donfdesc=fact.tipofact and
            fact.id=" & idFactura, conexionPrinc)

            Dim tablaFactura As New DataTable
            consultaFactura.Fill(tablaFactura)
            'Dim dtoprov() As DataRow
            numRecibo = tablaFactura.Rows(0).Item("recibo")
            fac_Numero = tablaFactura.Rows(0).Item("factnum")
            Clie_razonSocial = tablaFactura.Rows(0).Item("razon")
            Clie_idCliente = tablaFactura.Rows(0).Item("id_cliente")
            Clie_cuit = tablaFactura.Rows(0).Item("cuit")
            Clie_direccion = tablaFactura.Rows(0).Item("direccion")
            Clie_localidad = tablaFactura.Rows(0).Item("localidad")
            Clie_tipocontr = tablaFactura.Rows(0).Item("tipocontr")

            fac_total = tablaFactura.Rows(0).Item("total")
            Concepto = tablaFactura.Rows(0).Item("concepto")

            txtRecNumero.Text = String.Format("{0:0000}", ptoVta) & "-" & String.Format("{0:00000000}", numRecibo)
            txtConcepto.Text = Concepto
            txtCliente.Text = Clie_idCliente & "-" & Clie_razonSocial
            txtFactura.Text = fac_Numero
            txtEfectivo.Text = fac_total


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MsgBox("SEGURO???", vbYesNo) = vbNo Then
                Exit Sub
            End If

            Dim idReciboNvo As Integer
            Dim sqlQuery As String
            Dim fecha As String = Format(Now(), "yyyy-MM-dd")

            Dim itm_cod As String = "0"
            Dim itm_descripcion As String = fac_Numero
            Dim itm_ptotal As String = fac_total

            Dim rbo_total As String = txtEfectivo.Text

            Dim idcaja As Integer = cmbcajas.SelectedValue
            sqlQuery = "insert into fact_facturas  " _
                & "(tipofact,ptovta, num_fact,fecha,id_cliente,razon,direccion,localidad,tipocontr,cuit,total,observaciones) values " _
                & "(?tipofact, ?ptov,?nfac,?fech,?idclie,?razon,?dire,?loca,?tipocont,?cuit,?tot,?observa)"

            Dim addFact As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With addFact.Parameters
                .AddWithValue("?ptov", Val(ptoVta))
                .AddWithValue("?tipofact", 996)
                .AddWithValue("?nfac", Val(numRecibo))
                .AddWithValue("?fech", fecha)
                .AddWithValue("?idclie", Clie_idCliente)
                .AddWithValue("?razon", Clie_razonSocial)
                .AddWithValue("?dire", Clie_direccion)
                .AddWithValue("?loca", Clie_localidad)
                .AddWithValue("?tipocont", Clie_tipocontr)
                .AddWithValue("?cuit", Clie_cuit)
                .AddWithValue("?tot", remplazarPunto(rbo_total))
                .AddWithValue("?observa", txtConcepto.Text)
            End With
            addFact.ExecuteNonQuery()
            idReciboNvo = addFact.LastInsertedId

            sqlQuery = "insert into fact_items " _
                & "(cod, descripcion, ptotal, tipofact,idAlmacen,idCaja, id_fact) values" _
                & "(?cod,?desc,?ptot,?tipofact,?idAlmacen,?idCaja,?id_fact)"
            Reconectar()
            Dim addItm As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With addItm.Parameters
                .AddWithValue("?cod", itm_cod)
                .AddWithValue("?desc", itm_descripcion)
                .AddWithValue("?ptot", itm_ptotal)
                .AddWithValue("?tipofact", 996)
                .AddWithValue("?idAlmacen", idAlmacen)
                .AddWithValue("?idCaja", idcaja)
                .AddWithValue("?id_fact", idReciboNvo)
            End With
            addItm.ExecuteNonQuery()

            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_conffiscal set confnume=" & numRecibo & " where donfdesc= 996 and ptovta=" & ptoVta
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            'GUARDAMOS EL MOVIMIENTO DE CUENTA
            If InStr(DatosAcceso.Moduloacc, "4al") <> False Then
                'MsgBox(total & "             " & CDbl(total) & "               " & CDbl(total.Replace(".", ",")))
                Dim numAsiento As Integer = ObtenerNumeroAsiento()
                GuardarAsientoContable(numAsiento, "RBO " & txtRecNumero.Text,
                                           "PAGO FACTURA " & Clie_razonSocial, fac_total, 5, fac_total, 11, 2, fecha)
            End If

            '/***BUSCAMOS EL PERIODO ADEUDADO

            Dim idPublicidad As String = txtConcepto.Text.Replace("#", "")
            Dim idPeriodoPubli As Integer = 0
            Reconectar()
            Dim consultaPeriodo As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM rym_detalle_prestamo as pr 
            where  
            pr.periodo not in(select periodo from rym_pagos where ID_PRESTAMO=pr.ID_PRESTAMO) and
            pr.ID_PRESTAMO=" & idPublicidad & "
            order by pr.periodo asc
            limit 1", conexionPrinc)

            Dim tablaPublicidad As New DataTable
            consultaPeriodo.Fill(tablaPublicidad)

            If tablaPublicidad.Rows.Count <> 0 Then
                idPeriodoPubli = tablaPublicidad.Rows(0).Item("PERIODO")

                '***AGREGAR PAGO A PUBLICIDAD***

                sqlQuery = "insert into rym_pagos (fecha,id_prestamo,periodo,monto_pagado) values (?fecha,?idprestamo,?periodo,?monto)"
                Reconectar()
                Dim addPagoPubli As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With addPagoPubli.Parameters
                    .AddWithValue("?fecha", fecha)
                    .AddWithValue("?idprestamo", idPublicidad)
                    .AddWithValue("?periodo", idPeriodoPubli)
                    .AddWithValue("?monto", fac_total)
                End With
                addPagoPubli.ExecuteNonQuery()
            End If
            '***AGREGAR DINERO A CAJA***

            sqlQuery = "insert into fact_ingreso_egreso 
                    (concepto,monto,comprobante,caja,tipo) values
                    (?conc,?monto,?comp,?caja,'1')"
            Reconectar()
            Dim addIngresoCaja As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With addIngresoCaja.Parameters
                .AddWithValue("?monto", fac_total)
                .AddWithValue("?comp", idReciboNvo)
                .AddWithValue("?caja", idcaja)
                .AddWithValue("?conc", 1)
            End With
            addIngresoCaja.ExecuteNonQuery()

            '****ACTUALIZAMOS LA FACTURA 

            Reconectar()
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_facturas set observaciones2=concat(observaciones2,'\n','" & "RBO " & txtRecNumero.Text & "') where id= " & idFactura
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()


            '****ACTUALIZAMOS LA TABLA DE CUENTA CORRIENTE  

            Reconectar()
            sql.Connection = conexionPrinc
            sql.CommandText = "INSERT INTO fact_cuentaclie (idclie, idcomp, pago) values ('" & Clie_idCliente & "','" & idReciboNvo & "','1' )"
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            Reconectar()
            sql.Connection = conexionPrinc
            sql.CommandText = "update fact_cuentaclie set pago=1 where idcomp=" & idFactura
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "movimientodecaja" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New movimientodecaja
        tec.MdiParent = Me.MdiParent
        tec.movrap = True
        tec.movraptip = 996
        tec.movrapclie = Clie_idCliente
        tec.movrapConc = txtConcepto.Text
        tec.movrapFact = idFactura
        Me.Close()
        tec.Show()
    End Sub
End Class