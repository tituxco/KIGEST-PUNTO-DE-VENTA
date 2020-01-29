Public Class Presupuestos

    Private Sub cmdnuevapers_Click(sender As Object, e As EventArgs) Handles cmdnuevapers.Click
        Dim i As Integer
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "nuevopedido" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim tec As New nuevopedido
        tec.MdiParent = Me.MdiParent
        tec.Show()
    End Sub

    Private Sub pedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatosGrales()
        cargarPedidos()
    End Sub
    Private Sub cargarDatosGrales()
        Try

            Dim tablavend As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,', ', nombre) from fact_vendedor where activo =1", conexionPrinc)
            Dim readvend As New DataSet
            tablavend.Fill(readvend)
            cmbvendedor.DataSource = readvend.Tables(0)
            cmbvendedor.DisplayMember = readvend.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbvendedor.ValueMember = readvend.Tables(0).Columns(0).Caption.ToString
            cmbvendedor.SelectedIndex = -1

            If InStrRev(DatosAcceso.Moduloacc, "AR01") <> 0 Then
                cmdnvalistacarga.Visible = True
                cmdlistacarga.Visible = True
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub cargarPedidos()
        Try
            Dim ConsultaEXT As String

            If cmbvendedor.SelectedIndex <> -1 Then
                ConsultaEXT &= " and vendedor= " & cmbvendedor.SelectedValue
            End If
            If txtbusqCliente.Text <> "" Then
                ConsultaEXT &= " and razon like '%" & txtbusqCliente.Text & "%'"
            End If
            If rdpendientes.Checked = True Then
                ConsultaEXT &= " and observaciones like 'PENDIENTE'"
            End If
            If rdfacturados.Checked = True Then
                ConsultaEXT &= " and observaciones like 'FACTURADO'"
            End If
            If rdImportar.Checked = True Then
                ConsultaEXT &= " and observaciones <> 'FACTURADO' and observaciones <> 'PENDIENTE'"
            End If

            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select fac.id, " _
            & "concat(lpad(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as pedidonum,fac.fecha,fac.razon,fac.direccion, fac.localidad, con.condicion, format(fac.total,2,'es_AR'), fac.observaciones as estado, fac.observaciones2 as observaciones " _
            & "from fact_facturas as fac, fact_condventas as con where con.id=fac.condvta and fac.tipofact=995" & ConsultaEXT & " order by fac.id desc", conexionPrinc)
            Dim tablaped As New DataTable
            consulta.Fill(tablaped)

            dtpedidos.DataSource = tablaped
            dtpedidos.Columns(0).Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdmodificar_Click(sender As Object, e As EventArgs) Handles cmdmodificar.Click
        Try
            Dim i As Integer
            For i = 0 To Me.MdiChildren.Length - 1
                If MdiChildren(i).Name = "nuevopedido" Then
                    MsgBox("Existe un pedido en curso, cierre primero el pedido en curso e intente nuevamente", vbCritical)
                    Me.MdiChildren(i).BringToFront()
                    Exit Sub
                End If
            Next

            Dim tec As New nuevopedido
            tec.MdiParent = Me.MdiParent
            tec.modificar = True
            tec.idFactura = dtpedidos.CurrentRow.Cells(0).Value
            tec.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs) Handles cmdsalir.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cargarPedidos()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles cmdnvalistacarga.Click
        Try
            Try
                Dim i As Integer
                For i = 0 To Me.MdiChildren.Length - 1
                    If MdiChildren(i).Name = "nuevalistadecarga" Then
                        MsgBox("Existe un pedido en curso, cierre primero el pedido en curso e intente nuevamente", vbCritical)
                        Me.MdiChildren(i).BringToFront()
                        Exit Sub
                    End If
                Next

                Dim tec As New nuevalistadecarga
                tec.MdiParent = Me.MdiParent
                tec.Show()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdeliminar_Click(sender As Object, e As EventArgs) Handles cmdeliminar.Click
        Try
            If MsgBox("Esta seguro que desa eliminar este pedido?", vbQuestion + vbYesNo) = vbNo Then
                Exit Sub
            End If
            Dim idped As Integer = dtpedidos.CurrentRow.Cells(0).Value
            Dim delItm As String = "delete from fact_items where id_fact=" & idped
            Dim delPed As String = "delete from fact_facturas where id=" & idped
            Reconectar()
            Dim comandoDelItm As New MySql.Data.MySqlClient.MySqlCommand(delItm, conexionPrinc)
            comandoDelItm.ExecuteNonQuery()

            Reconectar()
            Dim comandoDelPed As New MySql.Data.MySqlClient.MySqlCommand(delPed, conexionPrinc)
            comandoDelPed.ExecuteNonQuery()

            cargarPedidos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbusqCliente_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbusqCliente.KeyUp

        If e.KeyCode = Keys.Enter Then
            cargarPedidos()
        End If
    End Sub

    Private Sub txtbusqCliente_TextChanged(sender As Object, e As EventArgs) Handles txtbusqCliente.TextChanged

    End Sub

    Private Sub cmdlistacarga_Click(sender As Object, e As EventArgs) Handles cmdlistacarga.Click
        Try
            selListaCarga.Show()
            'selListaCarga.TopMost = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas
            Dim idpedido As Integer = dtpedidos.CurrentRow.Cells(0).Value
            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo," _
            & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum,fac.fecha as facfech,concat(fac.id_cliente,'-',fac.razon) as facrazon," _
            & "concat(fac.direccion, ' - ', fac.localidad)  as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit,fac.vendedor as facvend, " _
            & "fac.condvta as faccondvta, fac.iva105, fac.iva21,fac.observaciones2 as facobserva " _
            & "FROM fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac where emp.id=1 and fis.donfdesc=fac.tipofact and fac.id=" & idpedido, conexionPrinc)

            tabEmp.Fill(fac.Tables("factura_enca"))
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "cantidad as cant, descripcion,iva,punit,ptotal from fact_items where " _
            & "id_fact=" & idpedido, conexionPrinc)
            tabFac.Fill(fac.Tables("facturax"))

            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\pedido.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("facturax")))
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub rdImportar_CheckedChanged(sender As Object, e As EventArgs) Handles rdImportar.CheckedChanged
        If rdImportar.Checked = True Then
            cmdmodificar.Text = "Importar"
        Else
            cmdmodificar.Text = "Modificar"
        End If
        cargarPedidos()
    End Sub

    Private Sub rdfacturados_CheckedChanged(sender As Object, e As EventArgs) Handles rdfacturados.CheckedChanged
        cargarPedidos()
    End Sub

    Private Sub rdpendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rdpendientes.CheckedChanged
        cargarPedidos()
    End Sub
End Class