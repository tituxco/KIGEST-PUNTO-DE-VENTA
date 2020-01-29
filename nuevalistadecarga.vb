Public Class nuevalistadecarga
    Dim fechagral As String = Format(Now, "dd-MM-yyyy")
    Public idFactura As Integer
    'Public modificar As Boolean
    'Public Rehacer As Boolean
    Public tipoFac As Integer = 20
    Private Sub nuevalistadecarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatosGrales()
        lblfecha.Text = "Fecha: " & fechagral

    End Sub
    Private Sub cargarDatosGrales()
        Try
            CargarNumComprobante()

            Reconectar()
            dtenvases.Rows.Add("20 Litros", "0", 20)
            dtenvases.Rows.Add("10 Litros", "0", 10)
            dtenvases.Rows.Add("5 Litros", "0", 5)
            dtenvases.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub calcularEnvases()
        Dim volumen As Integer
        Dim CAPenvase As Integer
        Dim CANTenvase As Double
        Dim excedente As Integer
        Try
            For Each envases As DataGridViewRow In dtenvases.Rows
                envases.Cells(1).Value = 0
            Next

            For Each producto As DataGridViewRow In dtproductos.Rows ' recorremos todos los productos del pedido

                volumen = producto.Cells(2).Value
                'MsgBox(ComprobarUnidadPresentacionProd(producto.Cells(0).Value) & producto.Cells(3).Value)

                If ComprobarUnidadPresentacionProd(producto.Cells(0).Value) = 2 Then
                    'MsgBox(producto.Cells(3).Value)
                    For Each envase As DataGridViewRow In dtenvases.Rows
                        Dim envaseEntero() As String
                        CAPenvase = envase.Cells(2).Value
                        CANTenvase = volumen / CAPenvase
                        envaseEntero = Str(CANTenvase).Split(".")
                        If CANTenvase - envaseEntero(0) <> 0 Then
                            envase.Cells(1).Value = envaseEntero(0) + CInt(envase.Cells(1).Value)
                            volumen = volumen - (envaseEntero(0) * CAPenvase)
                        Else
                            envase.Cells(1).Value = envaseEntero(0) + CInt(envase.Cells(1).Value)
                            volumen = volumen - (envaseEntero(0) * CAPenvase)
                        End If

                    Next
                    Dim existe As Boolean = False

                    For Each envase As DataGridViewRow In dtenvases.Rows
                        For Each prodlistacarga As DataGridViewRow In dtlistadecarga.Rows
                            If prodlistacarga.Cells(0).Value = producto.Cells(0).Value And prodlistacarga.Cells(1).Value = envase.Cells(0).Value Then
                                existe = True
                                prodlistacarga.Cells(2).Value = prodlistacarga.Cells(2).Value + envase.Cells(1).Value
                                envase.Cells(1).Value = 0
                                Exit For
                            Else
                                existe = False
                            End If
                        Next
                        If existe = False Then
                            If envase.Cells(1).Value <> 0 Then
                                dtlistadecarga.Rows.Add(producto.Cells(0).Value, envase.Cells(0).Value, envase.Cells(1).Value, producto.Cells(3).Value, 0)
                                envase.Cells(1).Value = 0

                            End If
                        Else

                        End If
                    Next
                    'dtproductos.Rows.Remove(producto)

                ElseIf ComprobarUnidadPresentacionProd(producto.Cells(0).Value) = 1 Then
                    'MsgBox(producto.Cells(3).Value)
                    Dim existe2 As Boolean = False
                    CAPenvase = ObtenerCapPqte(producto.Cells(0).Value)
                    CANTenvase = volumen / CAPenvase
                    Dim bolsaEntera() As String = Str(CANTenvase).Split(".")


                    For Each prodlistacarga As DataGridViewRow In dtlistadecarga.Rows

                        If prodlistacarga.Cells(0).Value = producto.Cells(0).Value Then
                            existe2 = True
                            prodlistacarga.Cells(2).Value = CInt(prodlistacarga.Cells(2).Value) + CInt(bolsaEntera(0))
                            prodlistacarga.Cells(4).Value = (volumen Mod CAPenvase) + CInt(prodlistacarga.Cells(4).Value)

                            Exit For
                        Else
                            existe2 = False
                        End If
                    Next
                    If existe2 = False Then
                        dtlistadecarga.Rows.Add(producto.Cells(0).Value, "Presentacion X" & CAPenvase, bolsaEntera(0), producto.Cells(3).Value, volumen Mod CAPenvase)
                    End If


                    'dtproductos.Rows.Remove(producto)
                End If
            Next
            dtproductos.Rows.Clear()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarNumComprobante()
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select confnume from tipos_comprobantes where id=" & tipoFac
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            txtnufac.Text = CompletarCeros(FormatNumber(lector("confnume").ToString) + 1, 1)
            ' cmbtipofac.Enabled = False
        Catch ex As Exception
        End Try
    End Sub

    Private Function ComprobarUnidadPresentacionProd(ByRef idProd As Integer) As Integer
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select unidades from fact_insumos where id=" & idProd
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            Return lector("unidades")
            ' cmbtipofac.Enabled = False
        Catch ex As Exception
        End Try
    End Function
    Private Function ObtenerCapPqte(ByRef idProd As Integer) As Integer
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select presentacion from fact_insumos where id=" & idProd
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            Return lector("presentacion")
            ' cmbtipofac.Enabled = False
        Catch ex As Exception
        End Try
    End Function

    Private Sub dtpedidosfact_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtpedidosfact.CellEndEdit
        Reconectar()
        Dim consultapedido As New MySql.Data.MySqlClient.MySqlDataAdapter("select " _
        & "id, condvta, vendedor from fact_facturas where observaciones like 'PENDIENTE' AND ptovta=1 and num_fact=" & dtpedidosfact.CurrentCell.Value & " and tipofact=9", conexionPrinc)
        Dim tablaped As New DataTable
        Dim infoped() As DataRow
        consultapedido.Fill(tablaped)
        infoped = tablaped.Select("")
        If tablaped.Rows.Count = 0 Then
            MsgBox("Pedido no encontrado o ya facturado")
            dtpedidosfact.CurrentCell.Value = ""
            SendKeys.Send("{UP}")
            Exit Sub
        End If
        dtpedidosfact.CurrentRow.Cells(0).Value = infoped(0)(0)

        Reconectar()
        Dim consultapedidoitems As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cod, plu, cantidad, descripcion from fact_items where id_fact=" & dtpedidosfact.CurrentRow.Cells(0).Value, conexionPrinc)
        Dim tablaitm As New DataTable
        Dim infoitm() As DataRow
        Dim existe As Boolean = False
        consultapedidoitems.Fill(tablaitm)
        infoitm = tablaitm.Select("")
        For i = 0 To infoitm.GetUpperBound(0)
            For Each producto As DataGridViewRow In dtproductos.Rows
                If infoitm(i)(0) = producto.Cells(0).Value Then
                    'MsgBox("existe")
                    existe = True
                    producto.Cells(2).Value = CType(producto.Cells(2).Value, Double) + CType(infoitm(i)(2), Double)
                    Exit For
                Else
                    existe = False
                End If
            Next
            If existe = False Then
                dtproductos.Rows.Add(infoitm(i)(0), infoitm(i)(1), infoitm(i)(2), infoitm(i)(3))
            End If

        Next
        calcularEnvases()

    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click

        Dim num_fact As Integer
        tmrcontrolarnumfact.Enabled = False


        Try

            num_fact = CType(txtnufac.Text, Integer)

            Dim ptovta As String = txtptovta.Text

            Dim fecha As String = Format(CDate(fechagral), "yyyy-MM-dd")
            Dim idcliente As String = "''" 'txtctaclie.Text
            Dim razon As String = "''" 'txtrazon.Text
            Dim direccion As String = "''" 'txtdomicilio.Text
            Dim localidad As String = "''" 'txtciudad.Text
            Dim tipocontr As String = "''" 'cmbtipocontr.Text
            Dim cuit As String = "''" 'txtcuit.Text
            Dim condvta As Integer = 1
            Dim subtotal As String = 0 'txtsubtotal.Text
            Dim iva105 As String = 0 'txtiva105.Text
            Dim iva21 As String = 0 'txtiva21.Text
            Dim total As String = 0 'txttotal.Text
            Dim vendedor As Integer = 1
            Dim observa As String

            For Each pedido As DataGridViewRow In dtpedidosfact.Rows
                Dim numped As String = String.Format("{0:0000}", 1) & "-" & String.Format("{0:00000000}", pedido.Cells(1).Value)
                observa = observa & numped & vbNewLine
            Next

            Dim sqlQuery As String

            If RestringirNumerosFact(tipoFac, num_fact, ptovta) = True Then
                MsgBox("El numero de comprobante ya existe para este tipo, por favor verifique")
                Exit Sub
            End If
            Reconectar()
            sqlQuery = "insert into fact_facturas  " _
                    & "(tipofact,ptovta, num_fact,fecha,id_cliente,razon,direccion,localidad,tipocontr,cuit,condvta,subtotal,iva105,iva21,total,vendedor,observaciones) values " _
                    & "(?tipofact, ?ptov,?nfac,?fech,?idclie,?razon,?dire,?loca,?tipocont,?cuit,?condvta,?subt,?105,?21,?tot,?vend,?observa)"

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters
                .AddWithValue("?ptov", Val(ptovta))
                .AddWithValue("?tipofact", tipoFac)
                .AddWithValue("?nfac", Val(num_fact))
                .AddWithValue("?fech", fecha)
                .AddWithValue("?idclie", idcliente)
                .AddWithValue("?razon", razon)
                .AddWithValue("?dire", direccion)
                .AddWithValue("?loca", localidad)
                .AddWithValue("?tipocont", tipocontr)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?condvta", condvta)
                .AddWithValue("?subt", subtotal)
                .AddWithValue("?105", iva105)
                .AddWithValue("?21", iva21)
                .AddWithValue("?tot", total)
                .AddWithValue("?vend", vendedor)
                .AddWithValue("?observa", observa)


            End With
                comandoadd.ExecuteNonQuery()
                idFactura = comandoadd.LastInsertedId

                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "update fact_conffiscal set confnume=" & Val(num_fact) & " where id= " & tipoFac
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
            lector.Read()


            Dim idcomprobante As Integer = idFactura
            Dim tipo_envase As String
            Dim cantidad As String
            Dim producto As String
            Dim excedente As String

            Dim i As Integer
            'num_fact = idfactura
            If Val(num_fact) = 0 Then
                MsgBox("No se pueden guardar los items de la factura")
                Exit Sub
            End If


            For Each listadecarga As DataGridViewRow In dtlistadecarga.Rows
                tipo_envase = listadecarga.Cells(1).Value
                cantidad = listadecarga.Cells(2).Value
                producto = listadecarga.Cells(3).Value
                excedente = listadecarga.Cells(4).Value

                sqlQuery = "insert into ariel_itmlistacarga " _
                & "(idcomprobante,tipo_envase,cantidad,producto,excedente) values " _
                & "(?comprobante, ?presenv,?cantidad,?producto,?excedente)"

                Reconectar()
                Dim comandoadditm As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadditm.Parameters
                    .AddWithValue("?comprobante", idFactura)
                    .AddWithValue("?presenv", tipo_envase)
                    .AddWithValue("?cantidad", cantidad)
                    .AddWithValue("?producto", producto)
                    .AddWithValue("?excedente", excedente)
                End With
                comandoadditm.ExecuteNonQuery()

            Next
            MsgBox("Lista de carga guardada satisfactoriamente")
            'panelencabeza.Enabled = False
            panelprod.Enabled = False
            dtproductos.Enabled = False
            cmdguardar.Enabled = False
            cmdimprimir.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tmrcontrolarnumfact_Tick(sender As Object, e As EventArgs) Handles tmrcontrolarnumfact.Tick
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select confnume from fact_conffiscal where id=" & tipoFac
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            txtnufac.Text = CompletarCeros(FormatNumber(lector("confnume").ToString) + 1, 1)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdimprimir_Click(sender As Object, e As EventArgs) Handles cmdimprimir.Click
        Try
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas

            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo," _
            & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum,fac.fecha as facfech,concat(fac.id_cliente,'-',fac.razon) as facrazon," _
            & "concat(fac.direccion, ' - ', fac.localidad)  as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit,fac.vendedor as facvend, " _
            & "fac.condvta as faccondvta, fac.observaciones as facobserva,fac.iva105, fac.iva21 " _
            & "FROM fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac where emp.id=1 and fis.id=fac.tipofact and fac.id=" & idFactura, conexionPrinc)

            tabEmp.Fill(fac.Tables("factura_enca"))
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM ariel_itmlistacarga where idcomprobante=" & idFactura, conexionPrinc)
            tabFac.Fill(fac.Tables("ariel_itmlistacarga"))




            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\listacarga.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("ariel_itmlistacarga")))

                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtpedidosfact_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtpedidosfact.CellContentClick

    End Sub
End Class