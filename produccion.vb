Public Class produccion


    Private Sub cmdbuscar_Click(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        Dim desde As String = Format(CDate(dtdesdefact.Value), "yyyy-MM-dd")
        Dim hasta As String = Format(CDate(dthastafact.Value), "yyyy-MM-dd")

        Dim BusqFacturados As String = ""
        If chkfacturado.Checked = True Then
            BusqFacturados = " and facturado=0 "
        End If
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM 
            fact_insumos_produccion where 
            fecha_alta between '" & desde & "' and '" & hasta & "'" &
            BusqFacturados, conexionPrinc)
        Dim TablaEnvasados As New DataTable

        consulta.Fill(TablaEnvasados)
        dgvProduccionEnvasados.DataSource = TablaEnvasados



    End Sub
End Class