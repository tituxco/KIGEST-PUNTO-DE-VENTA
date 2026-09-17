Imports System.Data
Imports WSAFIPFE

Public Class selfac

    Public fila As String
    Public provclie As String
    Public LLAMA As String
    Public AplicarRec As Boolean
    Public EsCredito As Boolean = False ' True si es Recibo/Nota de Crédito, False si es Factura/Débito
    Public IdCuotaPublicidad As Integer = 0
    Private Sub selprod_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub SELPAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarFacturas()
    End Sub

    Public Sub CargarFacturas()
        Try
            Reconectar()
            'GestorConexiones.conexionPrinc.ChangeDatabase(database)

            If LLAMA = "ingreso" Then
                '   Tu lógica original intacta
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from facturasclientes_impagas where idcliente= " & provclie, GestorConexiones.conexionPrinc)
                Dim tablaPers As New DataTable
                Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
                consulta.Fill(tablaPers)
                dtfacturas.DataSource = tablaPers
                dtfacturas.Columns(0).Visible = False

            ElseIf LLAMA = "egreso" Then
                '  Tu lógica original intacta
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM facturasproveedores_impagas where idProveedor= " & provclie, GestorConexiones.conexionPrinc)
                Dim tablaPers As New DataTable
                consulta.Fill(tablaPers)
                dtfacturas.DataSource = tablaPers
                dtfacturas.Columns(0).Visible = False

            ElseIf LLAMA = "PUBLIFACT" Then
                ' SOLO facturas / DÉBITOS del cliente especificado, ordenadas por fecha reciente (Top 10)
                Dim sql As String = "SELECT fact.id, " &
                                "CONCAT(fis.abrev, ' ', LPAD(fact.ptovta, 4, '0'), '-', LPAD(fact.num_fact, 8, '0')) AS factnum, " &
                                "DATE_FORMAT(fact.fecha, '%d-%m-%Y') AS fecha, fact.total " &
                                "FROM fact_facturas AS fact " &
                                "INNER JOIN tipos_comprobantes AS fis ON fact.tipofact = fis.donfdesc AND fact.ptovta = fis.ptovta and fis.debcred ='D' AND fis.tip =1 " &
                                "WHERE fact.id_cliente = " & provclie &
                                " ORDER BY fact.fecha DESC LIMIT 10"

                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(sql, GestorConexiones.conexionPrinc)
                Dim tabla As New DataTable
                consulta.Fill(tabla)
                dtfacturas.DataSource = tabla
                If dtfacturas.Columns.Count > 0 Then dtfacturas.Columns(0).Visible = False

            ElseIf LLAMA = "PUBLIPAGO" Then
                ' SOLO RECIBOS / CRÉDITOS del cliente especificado, ordenados por fecha reciente (Top 10)
                Dim sql As String = "SELECT fact.id, " &
                                "CONCAT(fis.abrev, ' ', LPAD(fact.ptovta, 4, '0'), '-', LPAD(fact.num_fact, 8, '0')) AS factnum, " &
                                "DATE_FORMAT(fact.fecha, '%d-%m-%Y') AS fecha, fact.total " &
                                "FROM fact_facturas AS fact " &
                                "INNER JOIN tipos_comprobantes AS fis ON fact.tipofact = fis.donfdesc AND fact.ptovta = fis.ptovta and fis.debcred ='C' AND fis.tip =2 " &
                                "WHERE fact.id_cliente = " & provclie &
                                " ORDER BY fact.fecha DESC LIMIT 10"

                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(sql, GestorConexiones.conexionPrinc)
                Dim tabla As New DataTable
                consulta.Fill(tabla)
                dtfacturas.DataSource = tabla
                If dtfacturas.Columns.Count > 0 Then dtfacturas.Columns(0).Visible = False

            End If
            SumarTotales()
        Catch ex As Exception
            MsgBox("Error al cargar comprobantes: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub dtpersonal_DoubleClick(sender As Object, e As EventArgs) Handles dtfacturas.DoubleClick
        Try
            Select Case LLAMA
                Case "ingreso"
                    If AplicarRec = False Then
                        With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                            For Each factcob As DataGridViewRow In dtfacturas.Rows
                                If factcob.Selected = True Then
                                    .dtconceptos.Rows.Add(factcob.Cells(0).Value, factcob.Cells(1).Value, factcob.Cells(2).Value, factcob.Cells(4).Value)
                                    .CalcularTotalescobro()
                                End If
                            Next
                        End With
                    Else
                        Dim i As Integer
                        For i = 0 To dtfacturas.RowCount - 1
                            If dtfacturas.Rows(i).Selected = True Then
                                Dim consupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_facturas set observaciones2 = '" & fila & "' where id=" & dtfacturas.Rows(i).Cells(4).Value, GestorConexiones.conexionPrinc)
                                Dim consupd2 As New MySql.Data.MySqlClient.MySqlCommand("update fact_cuentaclie set pago = 1 where idcomp=" & dtfacturas.Rows(i).Cells(4).Value, GestorConexiones.conexionPrinc)
                                consupd.ExecuteNonQuery()
                                consupd2.ExecuteNonQuery()
                            End If
                        Next
                        MsgBox("Se ha aplicado el recibo " & fila & " a las facturas seleccionadas")
                        Call CONTABLE.cargarCuentaClie(Val(CONTABLE.txtcuentabus.Text))
                    End If
                Case "egreso"
                    With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                        For Each factpa As DataGridViewRow In dtfacturas.Rows
                            If factpa.Selected = True Then
                                .dtfacturaspago.Rows.Add(factpa.Cells(0).Value, factpa.Cells(1).Value, factpa.Cells(2).Value)
                                .CalcularTotalespago()
                            End If
                        Next
                    End With

                Case "PUBLIFACT"
                    If MsgBox("esta seguro que desea asignar esta factura a esta cuota de publicidad?", vbYesNo + vbQuestion) = vbYes Then
                        GestorPublicidad.VincularComprobanteAutomatico(IdCuotaPublicidad, dtfacturas.CurrentRow.Cells(0).Value, False)
                        MsgBox("Factura asignada")
                        Me.Close()
                    End If


                Case "PUBLIPAGO"
                    If MsgBox("esta seguro que desea asignar este comprobante como metodo de cancelacion asociado a la factura de esta cuota de publicidad?", vbYesNo + vbQuestion) = vbYes Then
                        GestorPublicidad.VincularComprobanteAutomatico(IdCuotaPublicidad, dtfacturas.CurrentRow.Cells(0).Value, True)
                        MsgBox("comprobante asignado")
                        Me.Close()
                    End If
            End Select
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtfacturas.KeyDown
        Try
            Select Case LLAMA
                Case "ingreso"
                    If AplicarRec = False Then
                        With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                            For Each factcob As DataGridViewRow In dtfacturas.Rows
                                If factcob.Selected = True Then
                                    .dtconceptos.Rows.Add(factcob.Cells(0).Value, factcob.Cells(1).Value, factcob.Cells(2).Value, factcob.Cells(4).Value)
                                    .CalcularTotalescobro()
                                End If
                            Next
                        End With
                    Else
                        Dim i As Integer
                        For i = 0 To dtfacturas.RowCount - 1
                            If dtfacturas.Rows(i).Selected = True Then
                                Dim consupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_facturas set observaciones2 = '" & fila & "' where id=" & dtfacturas.Rows(i).Cells(4).Value, GestorConexiones.conexionPrinc)
                                Dim consupd2 As New MySql.Data.MySqlClient.MySqlCommand("update fact_cuentaclie set pago = 1 where idcomp=" & dtfacturas.Rows(i).Cells(4).Value, GestorConexiones.conexionPrinc)
                                consupd.ExecuteNonQuery()
                                consupd2.ExecuteNonQuery()
                            End If
                        Next
                        MsgBox("Se ha aplicado el recibo " & fila & " a las facturas seleccionadas")
                        Call CONTABLE.cargarCuentaClie(Val(CONTABLE.txtcuentabus.Text))
                    End If
                Case "egreso"
                    With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                        For Each factpa As DataGridViewRow In dtfacturas.Rows
                            If factpa.Selected = True Then
                                .dtfacturaspago.Rows.Add(factpa.Cells(0).Value, factpa.Cells(1).Value, factpa.Cells(2).Value)
                                .CalcularTotalespago()
                            End If
                        Next
                    End With

                Case "PUBLIFACT"
                    If MsgBox("esta seguro que desea asignar esta factura a esta cuota de publicidad?", vbYesNo + vbQuestion) = vbYes Then
                        GestorPublicidad.VincularComprobanteAutomatico(IdCuotaPublicidad, dtfacturas.CurrentRow.Cells(0).Value, False)
                        MsgBox("Factura asignada")
                        Me.Close()
                    End If


                Case "PUBLIPAGO"
                    If MsgBox("esta seguro que desea asignar este comprobante como metodo de cancelacion asociado a la factura de esta cuota de publicidad?", vbYesNo + vbQuestion) = vbYes Then
                        GestorPublicidad.VincularComprobanteAutomatico(IdCuotaPublicidad, dtfacturas.CurrentRow.Cells(0).Value, True)
                        MsgBox("comprobante asignado")
                        Me.Close()
                    End If
            End Select
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtfacturas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtfacturas.CellEnter
        Dim montosel As Double
        For Each fila As DataGridViewRow In dtfacturas.Rows
            If fila.Selected = True And (LLAMA = "ingreso") Then
                montosel += fila.Cells("importe").Value
            ElseIf fila.Selected = True And (LLAMA = "egreso") Then
                montosel += fila.Cells("monto").Value
            ElseIf fila.Selected = True And (LLAMA = "PUBLIFACT" Or LLAMA = "PUBLIPAGO") Then
                montosel += fila.Cells("total").Value
            End If
        Next
        lbltotalrecibo.Text = "Monto seleccionado: $ " & montosel

    End Sub
    Private Sub SumarTotales()
        Try
            Dim total As Double = 0
            For Each fila As DataGridViewRow In dtfacturas.Rows
                total += fila.Cells(2).Value
            Next

            lbltotalfacturas.Text = "Total facturas: $" & total & " -- "
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
        Try
            Select Case LLAMA
                Case "ingreso"
                    If AplicarRec = False Then
                        With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                            For Each factcob As DataGridViewRow In dtfacturas.Rows
                                If factcob.Selected = True Then
                                    .dtconceptos.Rows.Add(factcob.Cells(0).Value, factcob.Cells(1).Value, factcob.Cells(2).Value, factcob.Cells(4).Value)
                                    .CalcularTotalescobro()
                                End If
                            Next
                        End With
                    Else
                        Dim i As Integer
                        For i = 0 To dtfacturas.RowCount - 1
                            If dtfacturas.Rows(i).Selected = True Then
                                Dim consupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_facturas set observaciones2 = '" & fila & "' where id=" & dtfacturas.Rows(i).Cells(4).Value, GestorConexiones.conexionPrinc)
                                Dim consupd2 As New MySql.Data.MySqlClient.MySqlCommand("update fact_cuentaclie set pago = 1 where idcomp=" & dtfacturas.Rows(i).Cells(4).Value, GestorConexiones.conexionPrinc)
                                consupd.ExecuteNonQuery()
                                consupd2.ExecuteNonQuery()
                            End If
                        Next
                        MsgBox("Se ha aplicado el recibo " & fila & " a las facturas seleccionadas")
                        Call CONTABLE.cargarCuentaClie(Val(CONTABLE.txtcuentabus.Text))
                    End If
                Case "egreso"
                    With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                        For Each factpa As DataGridViewRow In dtfacturas.Rows
                            If factpa.Selected = True Then
                                .dtfacturaspago.Rows.Add(factpa.Cells(0).Value, factpa.Cells(1).Value, factpa.Cells(2).Value)
                                .CalcularTotalespago()
                            End If
                        Next
                    End With

                Case "PUBLIFACT"
                    If MsgBox("esta seguro que desea asignar esta factura a esta cuota de publicidad?", vbYesNo + vbQuestion) = vbYes Then
                        GestorPublicidad.VincularComprobanteAutomatico(IdCuotaPublicidad, dtfacturas.CurrentRow.Cells(0).Value, False)
                        MsgBox("Factura asignada")
                        Me.Close()
                    End If


                Case "PUBLIPAGO"
                    If MsgBox("esta seguro que desea asignar este comprobante como metodo de cancelacion asociado a la factura de esta cuota de publicidad?", vbYesNo + vbQuestion) = vbYes Then
                        GestorPublicidad.VincularComprobanteAutomatico(IdCuotaPublicidad, dtfacturas.CurrentRow.Cells(0).Value, True)
                        MsgBox("comprobante asignado")
                        Me.Close()
                    End If
            End Select
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtfacturas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtfacturas.CellClick
        Dim montosel As Double
        For Each fila As DataGridViewRow In dtfacturas.Rows
            If fila.Selected = True And (LLAMA = "ingreso") Then
                montosel += fila.Cells("importe").Value
            ElseIf fila.Selected = True And (LLAMA = "egreso") Then
                montosel += fila.Cells("monto").Value
            ElseIf fila.Selected = True And (LLAMA = "PUBLIFACT" Or LLAMA = "PUBLIPAGO") Then
                montosel += fila.Cells("total").Value
            End If
        Next
        lbltotalrecibo.Text = "Monto seleccionado: $ " & montosel
    End Sub

    Private Sub dtfacturas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtfacturas.CellContentClick

    End Sub
End Class