Imports System.Data
Imports WSAFIPFE

Public Class selfac

    Public fila As String
    Public provclie As String
    Public LLAMA As String
    Public AplicarRec As Boolean
    Public EsCredito As Boolean = False ' True si es Recibo/Nota de Crédito, False si es Factura/Débito
    Public IdCuotaPublicidad As Integer = 0

    ' --- NUEVAS PROPIEDADES PARA EL MODO "REASENTAR" ---
    Public FechaFiltro As Date
    Public ImporteFiltro As Double
    Public ComprobanteSeleccionado As String = ""
    Public RazonSeleccionada As String = ""
    Public FechaSeleccionada As Date

    Private Sub selprod_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub SELPAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarFacturas()
    End Sub

    Public Sub CargarFacturas()
        Try
            Reconectar()

            If LLAMA = "ingreso" Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from facturasclientes_impagas where idcliente= " & provclie, GestorConexiones.conexionPrinc)
                Dim tablaPers As New DataTable
                Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
                consulta.Fill(tablaPers)
                dtfacturas.DataSource = tablaPers
                dtfacturas.Columns(0).Visible = False

            ElseIf LLAMA = "egreso" Then
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM facturasproveedores_impagas where idProveedor= " & provclie, GestorConexiones.conexionPrinc)
                Dim tablaPers As New DataTable
                consulta.Fill(tablaPers)
                dtfacturas.DataSource = tablaPers
                dtfacturas.Columns(0).Visible = False

            ElseIf LLAMA = "PUBLIFACT" Then
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

            ElseIf LLAMA = "REASENTAR" Then
                ' Busca facturas, recibos (996) u órdenes con misma fecha, mismo importe y razón social > 45 caracteres
                Dim sql As String = "SELECT 
                            fact.id,
                            CONCAT(COALESCE(fis.abrev, CONCAT('COMP ', fact.tipofact)), ' ', LPAD(fact.ptovta, 4, '0'), '-', LPAD(fact.num_fact, 8, '0')) AS factnum,
                            fact.total,
                            DATE_FORMAT(fact.fecha, '%d-%m-%Y') AS fecha,
                            fact.razon,
                            CHAR_LENGTH(Trim(fact.razon)) As largo_razon,
                            fact.observaciones
                             From fact_facturas As fact
                        Left Join tipos_comprobantes AS fis 
                            On fact.tipofact = fis.donfdesc 
                            And fact.ptovta = fis.ptovta
                        WHERE Date(fact.fecha) = ?fecha
                          And ABS(ABS(CAST(Replace(fact.total, ',', '.') AS DECIMAL(15,2))) - ?importe) < 0.05
                          And CHAR_LENGTH(Trim(fact.razon)) > 30
                        ORDER BY fact.id DESC"

                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(sql, GestorConexiones.conexionPrinc)
                'MsgBox($"{Format(CDate(FechaFiltro.ToString()), "yyyy-MM-dd")}----{ImporteFiltro }")
                consulta.SelectCommand.Parameters.AddWithValue("?fecha", Format(CDate(FechaFiltro.ToString()), "yyyy-MM-dd"))
                consulta.SelectCommand.Parameters.AddWithValue("?importe", ImporteFiltro)

                Dim tabla As New DataTable
                consulta.Fill(tabla)
                'MsgBox(consulta.SelectCommand.CommandText)
                dtfacturas.DataSource = tabla
                If dtfacturas.Columns.Count > 0 Then dtfacturas.Columns(0).Visible = False
            End If

            SumarTotales()
        Catch ex As Exception
            MsgBox("Error al cargar comprobantes:   " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' Método auxiliar para devolver el comprobante seleccionado en modo REASENTAR
    Private Sub ConfirmarSeleccionReasentar()
        If dtfacturas.CurrentRow Is Nothing Then
            MsgBox("Seleccione un comprobante de la lista.", MsgBoxStyle.Exclamation, "Atención")
            Exit Sub
        End If

        ComprobanteSeleccionado = dtfacturas.CurrentRow.Cells("factnum").Value.ToString()
        RazonSeleccionada = dtfacturas.CurrentRow.Cells("razon").Value.ToString()
        FechaSeleccionada = FechaFiltro
        Me.DialogResult = DialogResult.OK
        Me.Close()
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

                Case "REASENTAR"
                    ConfirmarSeleccionReasentar()
                    Exit Sub
            End Select
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtproductos_KeyDown(sender As Object, e As KeyEventArgs) Handles dtfacturas.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Select Case LLAMA
                    Case "REASENTAR"
                        ConfirmarSeleccionReasentar()
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
            End If
            Me.Close()
        Catch ex As Exception
        End Try
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

                Case "REASENTAR"
                    ConfirmarSeleccionReasentar()
                    Exit Sub
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
            ElseIf fila.Selected = True And (LLAMA = "PUBLIFACT" Or LLAMA = "PUBLIPAGO" Or LLAMA = "REASENTAR") Then
                montosel += fila.Cells("total").Value
            End If
        Next
        lbltotalrecibo.Text = "Monto seleccionado: $ " & montosel
    End Sub
End Class