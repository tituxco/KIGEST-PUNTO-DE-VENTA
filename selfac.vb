Public Class selfac

    Public fila As String
    Public provclie As String
    Public LLAMA As String
    Public AplicarRec As Boolean

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
            conexionPrinc.ChangeDatabase(database)
            If LLAMA = "ingreso" Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from facturasclientes_impagas where idcliente= " & provclie, conexionPrinc)
                Dim tablaPers As New DataTable
                Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
                consulta.Fill(tablaPers)
                dtfacturas.DataSource = tablaPers
                dtfacturas.Columns(0).Visible = False
            ElseIf LLAMA = "egreso" Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM facturasproveedores_impagas where idProveedor= " & provclie, conexionPrinc)
                Dim tablaPers As New DataTable
                consulta.Fill(tablaPers)
                dtfacturas.DataSource = tablaPers
                dtfacturas.Columns(0).Visible = False
            End If
            SumarTotales()
        Catch ex As Exception

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
                                Dim consupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_facturas set observaciones2 = '" & fila & "' where id=" & dtfacturas.Rows(i).Cells(4).Value, conexionPrinc)
                                Dim consupd2 As New MySql.Data.MySqlClient.MySqlCommand("update fact_cuentaclie set pago = 1 where idcomp=" & dtfacturas.Rows(i).Cells(4).Value, conexionPrinc)
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
            End Select
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtfacturas.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
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
                            If MsgBox("Esta seguro que desea aplicar el recibo " & fila & " a estos comprobantes?", vbYesNo) = vbNo Then Exit Sub
                            Dim i As Integer
                            For i = 0 To dtfacturas.RowCount - 1
                                If dtfacturas.Rows(i).Selected = True Then
                                    Dim consupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_facturas set observaciones2 = '" & fila & "' where id=" & dtfacturas.Rows(i).Cells(4).Value, conexionPrinc)
                                    Dim consupd2 As New MySql.Data.MySqlClient.MySqlCommand("update fact_cuentaclie set pago = 1 where idcomp=" & dtfacturas.Rows(i).Cells(4).Value, conexionPrinc)
                                    consupd.ExecuteNonQuery()
                                    consupd2.ExecuteNonQuery()
                                End If
                            Next
                            MsgBox("Se ha aplicado el recibo " & fila & " a las facturas seleccionadas")
                            Call CONTABLE.cargarCuentaClie(Val(CONTABLE.txtcuentabus.Text))
                        End If
                    Case "egreso"
                        With CType(frmprincipal.ActiveMdiChild, movimientodecaja)
                            .dtfacturaspago.Rows(fila).Cells(0).Value = dtfacturas.CurrentRow.Cells.Item(0).Value
                            .dtfacturaspago.Rows(fila).Cells(1).Value = dtfacturas.CurrentRow.Cells.Item(1).Value
                            .dtfacturaspago.Rows(fila).Cells(2).Value = dtfacturas.CurrentRow.Cells.Item(2).Value
                            .CalcularTotalespago()
                        End With
                End Select
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtfacturas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtfacturas.CellEnter
        Dim montosel As Double
        For Each fila As DataGridViewRow In dtfacturas.Rows
            If fila.Selected = True Then
                montosel += fila.Cells(2).Value
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
                                Dim consupd As New MySql.Data.MySqlClient.MySqlCommand("update fact_facturas set observaciones2 = '" & fila & "' where id=" & dtfacturas.Rows(i).Cells(4).Value, conexionPrinc)
                                Dim consupd2 As New MySql.Data.MySqlClient.MySqlCommand("update fact_cuentaclie set pago = 1 where idcomp=" & dtfacturas.Rows(i).Cells(4).Value, conexionPrinc)
                                consupd.ExecuteNonQuery()
                                consupd2.ExecuteNonQuery()
                            End If
                        Next
                        MsgBox("Se ha aplicado el recibo " & fila & " a las facturas seleccionadas")
                        CType(frmprincipal.ActiveMdiChild, CONTABLE).cargarCuentaClie(CType(frmprincipal.ActiveMdiChild, movimientodecaja).txtctaclie.Text)
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
            End Select
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtfacturas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtfacturas.CellClick
        Dim montosel As Double
        For Each fila As DataGridViewRow In dtfacturas.Rows
            If fila.Selected = True Then
                montosel += fila.Cells(2).Value
            End If
        Next
        lbltotalrecibo.Text = "Monto seleccionado: $ " & montosel
    End Sub

    Private Sub dtfacturas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtfacturas.CellContentClick

    End Sub
End Class