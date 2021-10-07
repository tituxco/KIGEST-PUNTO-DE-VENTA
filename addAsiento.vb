Public Class addAsiento
    Private BindingSourcePlanCuentas As Windows.Forms.BindingSource = New BindingSource
    Public ModificarAsiento As Boolean
    Public IdAsiento As Integer
    Dim filaActual As Integer

    ' Dim tabPlanCuentas As New DataSet
    Public Sub addAsiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim consPlanCuentas As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,concat(grupo,subgrupo,cuenta,'.',subcuenta,cuentadetalle) as codigoCuenta, 
            concat(nombreCuenta,'<>',concat(grupo,subgrupo,cuenta,subcuenta,cuentadetalle)) as nombreCuenta
            FROM cm_planDeCuentas order by grupo,subGrupo,cuenta,subCuenta,cuentaDetalle", conexionPrinc)
            Dim tabPlanCuentas As New DataSet
            consPlanCuentas.Fill(tabPlanCuentas)

            dgvCuenta.DataSource = tabPlanCuentas.Tables(0)
            dgvCuenta.DisplayMember = tabPlanCuentas.Tables(0).Columns("nombreCuenta").Caption.ToString
            dgvCuenta.ValueMember = tabPlanCuentas.Tables(0).Columns("id").Caption.ToString

            cmbBusquedaCuenta.DataSource = tabPlanCuentas.Tables(0)
            cmbBusquedaCuenta.DisplayMember = tabPlanCuentas.Tables(0).Columns("nombreCuenta").Caption.ToString
            cmbBusquedaCuenta.ValueMember = tabPlanCuentas.Tables(0).Columns("id").Caption.ToString

            If ModificarAsiento = True Then
                Reconectar()
                Dim consLibroDiario As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_libroDiario where codigoAsiento=" & IdAsiento & " limit 1", conexionPrinc)
                Dim tabLibroDiario As New DataTable
                '    MsgBox(consLibroDiario.SelectCommand.CommandText)
                consLibroDiario.Fill(tabLibroDiario)
                txtAsientoNumero.Text = tabLibroDiario.Rows(0).Item("codigoAsiento")
                txtAsientoComprobante.Text = tabLibroDiario.Rows(0).Item("comprobanteInterno")
                txtAsientoConcepto.Text = tabLibroDiario.Rows(0).Item("concepto")
                fchAsientoFecha.Value = CDate(tabLibroDiario.Rows(0).Item("fecha").ToString)

                Reconectar()
                Dim consAsiento As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM cm_Asientos 
                where (cuentaDebeId<>0 or cuentaHaberId<>0) and  codigoAsiento=" & IdAsiento, conexionPrinc)
                Dim tabAsiento As New DataTable
                consAsiento.Fill(tabAsiento)

                For Each Partida As DataRow In tabAsiento.Rows
                    If Partida.Item("cuentaDebeId") <> 0 Then
                        dgvPartidas.Rows.Add(
                                         Partida.Item("cuentaDebeId"),
                                         ObtenerCodigoCuenta(Partida.Item("cuentaDebeId")),
                                         Partida.Item("cuentaDebeId"),
                                         Partida.Item("importeDebe"),
                                         0
                                         )
                    Else
                        dgvPartidas.Rows.Add(
                                        Partida.Item("cuentaHaberId"),
                                        ObtenerCodigoCuenta(Partida.Item("cuentaHaberId")),
                                        Partida.Item("cuentaHaberId"),
                                        0,
                                        Partida.Item("importeHaber")
                                        )
                    End If
                Next
                If ConsultarPeriodoCerrado(Format(fchAsientoFecha.Value, "yyyy-MM")) = True Then
                    dgvPartidas.ReadOnly = True
                    dgvPartidas.AllowUserToAddRows = False
                    dgvPartidas.AllowUserToDeleteRows = False
                End If
                CalcularTotalAsiento()
            Else
                Dim consUltAsiento As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id ,comprobanteInterno, fecha,concepto FROM 
                cm_libroDiario order by id desc limit 1", conexionPrinc)
                Dim tabUltAsiento As New DataTable
                consUltAsiento.Fill(tabUltAsiento)


                txtAsientoNumero.Text = ObtenerNumeroAsiento()
                txtAsientoComprobante.Text = tabUltAsiento.Rows(0).Item(1)
                fchAsientoFecha.Value = Format(CDate(tabUltAsiento.Rows(0).Item(2).ToString), "dd/MM/yyyy")
                'txtAsientoConcepto.Text = tabUltAsiento.Rows(0).Item(3)
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgvPartidas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPartidas.CellEndEdit
        Try
            '  MsgBox(e.ColumnIndex)
            'If e.RowIndex = 0 Then Exit Sub

            If e.ColumnIndex = 1 Then 'dgvPartidas.Columns("Cuenta").Index Then
                If ComprobarCuenta(dgvPartidas.Rows(e.RowIndex).Cells("Cuenta").Value) = False Then
                    MsgBox("la cuenta seleccionada no admite movimientos directos, seleccione una subcuenta")
                    Exit Sub
                End If
                dgvPartidas.Rows(e.RowIndex).Cells(0).Value = dgvPartidas.Rows(e.RowIndex).Cells("Cuenta").Value
                dgvPartidas.Rows(e.RowIndex).Cells(1).Value = ObtenerCodigoCuenta(dgvPartidas.Rows(e.RowIndex).Cells("Cuenta").Value)
            ElseIf e.ColumnIndex = 3 Then
                If dgvPartidas.CurrentCell.Value <> 0 Then dgvPartidas.CurrentCell.Value = FormatNumber(dgvPartidas.CurrentCell.Value)
                CalcularTotalAsiento()
            ElseIf e.ColumnIndex = 4 Then
                If dgvPartidas.CurrentCell.Value <> 0 Then dgvPartidas.CurrentCell.Value = FormatNumber(dgvPartidas.CurrentCell.Value)
                CalcularTotalAsiento()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CalcularTotalAsiento()
        Dim debeTotal As Double = 0
        Dim haberTotal As Double = 0

        For Each partida As DataGridViewRow In dgvPartidas.Rows
            'MsgBox(partida.Cells(4).Value)
            ' If partida.Index = 0 Then Continue For
            'If partida.Cells(4).Value = "" Or Not IsNumeric(partida.Cells(4).Value) Or partida.Cells(5).Value = "" Or Not IsNumeric(partida.Cells(5).Value) Then
            'MsgBox("una de las partidas esta mal cargada, por favor verifique, no se sumaran totales")
            'partida.Selected = True
            'Exit Sub
            'Else
            debeTotal += partida.Cells("DEBE").Value
            haberTotal += partida.Cells("HABER").Value
            ' End If
        Next

        lbltotalDebe.Text = "$" & FormatNumber(debeTotal, 2)
        lbltotalHaber.Text = "$" & FormatNumber(haberTotal, 2)
    End Sub
    Private Function ObtenerCodigoCuenta(idCuenta As Integer) As String
        Try
            Dim consPlanCuentas As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT concat(grupo,subgrupo,cuenta,'.',subcuenta,cuentadetalle) as codigoCuenta                
        FROM cm_planDeCuentas where id=" & idCuenta & " order by grupo,subGrupo,cuenta,subCuenta,cuentaDetalle limit 1", conexionPrinc)
            Dim tabPlanCuentas As New DataTable
            consPlanCuentas.Fill(tabPlanCuentas)
            Return tabPlanCuentas.Rows(0).Item("codigoCuenta")
        Catch ex As exception
        End Try
    End Function

    Private Function ComprobarCuenta(idcuenta) As Boolean
        Try
            Dim consPlanCuentas As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cuentaMovimiento                
        FROM cm_planDeCuentas where id=" & idcuenta & " order by grupo,subGrupo,cuenta,subCuenta,cuentaDetalle limit 1", conexionPrinc)
            Dim tabPlanCuentas As New DataTable
            consPlanCuentas.Fill(tabPlanCuentas)
            Dim cuentaMovimiento = tabPlanCuentas.Rows(0).Item("cuentaMovimiento")
            If cuentaMovimiento = 0 Then
                '      MsgBox("La cuenta seleccionada no acepta movimientos directos, debe seleccionar una subcuenta")
                'dgvPartidas.Rows.Remove(dgvPartidas.CurrentRow)
                '  Exit Sub
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Try
            Dim periodoaConsultar As String = Format(fchAsientoFecha.Value, "yyyy-MM")
            If ConsultarPeriodoCerrado(periodoaConsultar) = True Then
                MsgBox("el periodo ya esta cerrado, no se pueden modificar ni agregar asientos")
                Exit Sub
            End If
            If ModificarAsiento = True Then
                If MsgBox("esta seguro que desea modificar este asiento contable? ", vbYesNo + vbQuestion) = vbNo Then
                    Exit Sub
                Else
                    Dim comandoDelAsiento As New MySql.Data.MySqlClient.MySqlCommand("
                    delete from cm_libroDiario where codigoAsiento=" & IdAsiento, conexionPrinc)
                    Dim comandoDelAsiento2 As New MySql.Data.MySqlClient.MySqlCommand("
                    delete from cm_Asientos where codigoAsiento=" & IdAsiento, conexionPrinc)
                    Dim comandoDelAsiento3 As New MySql.Data.MySqlClient.MySqlCommand("
                    delete from cm_libroMayor where codigoAsiento=" & IdAsiento, conexionPrinc)


                    comandoDelAsiento.ExecuteNonQuery()
                    comandoDelAsiento2.ExecuteNonQuery()
                    comandoDelAsiento3.ExecuteNonQuery()
                End If
            Else



                If MsgBox("Esta seguro que desa agregar este asiento?", vbYesNo + vbQuestion) = vbNo Then
                    Exit Sub
                Else
                    Dim consUltAsiento As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id ,comprobanteInterno, fecha,concepto FROM 
                cm_libroDiario order by id desc limit 1", conexionPrinc)
                    Dim tabUltAsiento As New DataTable
                    consUltAsiento.Fill(tabUltAsiento)


                    txtAsientoNumero.Text = ObtenerNumeroAsiento()
                    'txtAsientoComprobante.Text = tabUltAsiento.Rows(0).Item(1)
                    'fchAsientoFecha.Value = Format(CDate(tabUltAsiento.Rows(0).Item(2).ToString), "dd/MM/yyyy")
                    'txtAsientoConcepto.Text = tabUltAsiento.Rows(0).Item(3)
                End If

            End If

            Dim asientoNumero As Integer = txtAsientoNumero.Text
            Dim asientoComprobante As String = txtAsientoComprobante.Text.ToUpper
            Dim asientoConcepto As String = txtAsientoConcepto.Text.ToUpper
            Dim asientoFecha As String = Format(fchAsientoFecha.Value, "yyyy-MM-dd")

            Dim totalDebe As Double = 0
            Dim totalHaber As Double = 0

            Dim numPartidas As Integer = dgvPartidas.Rows.Count - 1

            For Each partida As DataGridViewRow In dgvPartidas.Rows
                Dim importeDebe As Double = 0
                Dim importeHaber As Double = 0
                Dim cuentaDebeId As Integer = 0
                Dim cuentaHaberId As Integer = 0

                If partida.Cells("DEBE").Value <> 0 Then
                    cuentaDebeId = partida.Cells("idCuenta").Value
                    totalDebe = totalDebe + partida.Cells("DEBE").Value
                    importeDebe = partida.Cells("DEBE").Value
                End If
                If partida.Cells("HABER").Value <> 0 Then
                    cuentaHaberId = partida.Cells("idCuenta").Value
                    'totalHaber = totalHaber + FormatNumber((partida.Cells("HABER").Value), 2)
                    totalHaber = totalHaber + partida.Cells("HABER").Value
                    importeHaber = partida.Cells("HABER").Value
                End If

                Dim agregarPartida As String = "insert into cm_Asientos(codigoAsiento,cuentaDebeId,importeDebe,cuentaHaberId,importeHaber) values
                (?codigoAsiento,?cuentaDebeId,?importeDebe,?cuentaHaberId,?importeHaber)"
                Dim comandoPartida As New MySql.Data.MySqlClient.MySqlCommand(agregarPartida, conexionPrinc)
                With comandoPartida.Parameters
                    .AddWithValue("?codigoAsiento", asientoNumero)
                    .AddWithValue("?cuentaDebeId", cuentaDebeId)
                    .AddWithValue("?importeDebe", importeDebe)
                    .AddWithValue("?cuentaHaberId", cuentaHaberId)
                    .AddWithValue("?importeHaber", importeHaber)
                End With
                comandoPartida.ExecuteNonQuery()
            Next
            'txtresultados.Text = "debetotal:" & totalDebe & "---totalhaber:" & totalHaber

            Dim agregarLibroDiario As String = "insert into cm_libroDiario (comprobanteInterno,codigoAsiento,fecha,concepto,totalDebe,totalHaber,numPartidas) values
            (?comprobanteInterno,?codigoAsiento,?fecha,?concepto,?totalDebe,?totalHaber,?numPartidas)"
            Dim comandoLibroDiario As New MySql.Data.MySqlClient.MySqlCommand(agregarLibroDiario, conexionPrinc)
            With comandoLibroDiario.Parameters
                .AddWithValue("?comprobanteInterno", asientoComprobante)
                .AddWithValue("?codigoAsiento", asientoNumero)
                .AddWithValue("?fecha", asientoFecha)
                .AddWithValue("?concepto", asientoConcepto.ToUpper)
                .AddWithValue("?totalDebe", totalDebe)
                .AddWithValue("?totalHaber", totalHaber)
                .AddWithValue("?numPartidas", numPartidas)
            End With
            comandoLibroDiario.ExecuteNonQuery()

            Dim agregarLibroMayor As String = "insert into cm_libroMayor (fecha,concepto,codigoAsiento) values
            (?fecha,?concepto,?codigoAsiento)"
            Dim comandoLibroMayor As New MySql.Data.MySqlClient.MySqlCommand(agregarLibroMayor, conexionPrinc)
            With comandoLibroMayor.Parameters
                .AddWithValue("?fecha", asientoFecha)
                .AddWithValue("?concepto", asientoConcepto)
                .AddWithValue("?codigoAsiento", asientoNumero)
            End With
            comandoLibroMayor.ExecuteNonQuery()
            With CType(frmprincipal.ActiveMdiChild, CONTABLE)
                .CargarPeriodos()
                .CargarLibroDiario()
            End With

            If chkReabrir.Checked = True Then
                dgvPartidas.Rows.Clear()
                txtAsientoNumero.Text = ObtenerNumeroAsiento() 'addAsiento_Load(me,)
                txtAsientoConcepto.Text = ""
                txtAsientoComprobante.Focus()
                CalcularTotalAsiento()
            Else
                Me.Close()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub addAsiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub

    Private Sub dgvPartidas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPartidas.CellClick
        If e.ColumnIndex = 3 Then
            cmbBusquedaCuenta.Visible = True
            filaActual = e.RowIndex
            cmbBusquedaCuenta.Focus()
            'cmbBusquedaCuenta.Location()
        End If
    End Sub

    Private Sub cmbBusquedaCuenta_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbBusquedaCuenta.KeyUp

    End Sub

    Private Sub cmbBusquedaCuenta_TextChanged(sender As Object, e As EventArgs) Handles cmbBusquedaCuenta.TextChanged
        'Try
        '    'MsgBox("texto " & cmbBusquedaCuenta.Text)
        '    tabPlanCuentas.Tables(0).Select("nombreCuenta like '% " & cmbBusquedaCuenta.Text & " %'")
        '    cmbBusquedaCuenta.DataSource = tabPlanCuentas.Tables(0)
        '    cmbBusquedaCuenta.ValueMember = tabPlanCuentas.Tables(0).Columns("id").Caption
        '    cmbBusquedaCuenta.DisplayMember = tabPlanCuentas.Tables(0).Columns("nombreCuenta").Caption
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub dgvPartidas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPartidas.CellEnter
        Dim Grid As DataGridView = CType(sender, DataGridView)
        Dim Rec As Rectangle
        'Dim Dtp As DataTimePicker

        If e.ColumnIndex = 2 Then ' Si la coolumna es la que quiero

            Rec = Grid.GetCellDisplayRectangle(Grid.CurrentCell.ColumnIndex, Grid.CurrentCell.RowIndex, False)

            cmbBusquedaCuenta.Location = New Point(Rec.Location.X + Grid.Location.X, Rec.Location.Y + Grid.Location.Y)
            cmbBusquedaCuenta.BringToFront()
            filaActual = e.RowIndex
            cmbBusquedaCuenta.Show()

        End If

    End Sub

    Private Sub cmbBusquedaCuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbBusquedaCuenta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If ComprobarCuenta(cmbBusquedaCuenta.SelectedValue) = False Then
                    MsgBox("la cuenta seleccionada no admite movimientos directos, seleccione una subcuenta")
                    Exit Sub
                End If
                'MsgBox(cmbBusquedaCuenta.SelectedValue)
                dgvPartidas.Rows(filaActual).Cells("idCuenta").Value = cmbBusquedaCuenta.SelectedValue
                dgvPartidas.Rows(filaActual).Cells("Codigo").Value = ObtenerCodigoCuenta(cmbBusquedaCuenta.SelectedValue)
                dgvPartidas.Rows(filaActual).Cells("dgvCuenta").Value = cmbBusquedaCuenta.SelectedValue
                dgvPartidas.Rows(filaActual).Cells("DEBE").Selected = True  '  .Focus()
                dgvPartidas.CurrentCell = dgvPartidas.Rows(filaActual).Cells("DEBE")
                dgvPartidas.BeginEdit(True)
                cmbBusquedaCuenta.Visible = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub dgvPartidas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPartidas.CellContentClick

    End Sub

    Private Sub cmbBusquedaCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBusquedaCuenta.SelectedIndexChanged

    End Sub

    Private Sub dgvPartidas_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPartidas.CellLeave

    End Sub
End Class