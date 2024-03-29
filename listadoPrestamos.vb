﻿Public Class listadoPrestamos
    Private cmd As MySql.Data.MySqlClient.MySqlCommand
    Private da As MySql.Data.MySqlClient.MySqlDataAdapter
    Private ds As DataSet
    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click

        Reconectar()
        Consultas("SELECT pr.ID_PRESTAMO, pr.FECHA,cl.nomapell_razon as CLIENTE,pr.plazo as PLAZO_MESES,
        (select count(*)-1 from rym_detalle_prestamo as DTP 
	    	where DTP.ID_PRESTAMO 
		    not in (select id FROM rym_pagos as pg where pg.ID_PRESTAMO=DTP.ID_PRESTAMO)
            and DTP.ID_PRESTAMO=pr.ID_PRESTAMO
            )AS DEBE_CUOTAS,
        (select count(*) from rym_detalle_prestamo as DTP 
		    where DTP.ID_PRESTAMO 
		    not in (select id FROM rym_pagos as pg where pg.ID_PRESTAMO=DTP.ID_PRESTAMO)
            and DTP.ID_PRESTAMO=pr.ID_PRESTAMO AND DATEDIFF(NOW(),DTP.FECHA)>@DIASMORA
            )AS MOROSO_CUOTAS,        
        pr.MONTO_PRESTAMO, pr.CUOTA  
        FROM rym_prestamo as pr, fact_clientes as cl
        where pr.ID_CLIENTE=cl.idclientes")
    End Sub

    Public Sub Consultas(ByVal Cadena As String)
        Reconectar()
        'Dim fecha As MySql.Data.Types.MySqlDateTime()
        cmd = New MySql.Data.MySqlClient.MySqlCommand(Cadena, conexionPrinc)
        cmd.Parameters.AddWithValue("@FECHA", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Today.Date
        cmd.Parameters.AddWithValue("@DIASMORA", MySql.Data.MySqlClient.MySqlDbType.Text).Value = "15"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(cmd)

        ds = New DataSet
        da.Fill(ds)

        If ds.Tables(0).Rows.Count > 0 Then
            dgvPrestamos.Cargar_Datos(ds.Tables(0))
            'DataGridView1.DataSource = ds.Tables(0)
        Else
            dgvPrestamos.Cargar_Datos(Nothing)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click

    End Sub

    Private Sub listadoPrestamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdver_Click(sender As Object, e As EventArgs) Handles cmdver.Click
        Try
            Dim i As Integer
            For i = 0 To Me.MdiChildren.Length - 1
                If MdiChildren(i).Name = "PrestamosForm" Then
                    Me.MdiChildren(i).BringToFront()
                    Exit Sub
                End If
            Next

            Dim tec As New PrestamosForm
            tec.MdiParent = Me.MdiParent
            tec.Show()
            tec.txtBuscaPrestamo.Text = dgvPrestamos.dgvVista.CurrentRow.Cells(0).Value
            tec.Button1.Enabled = False
            tec.btnCalcular.Enabled = False
        Catch ex As Exception
        End Try
    End Sub
End Class