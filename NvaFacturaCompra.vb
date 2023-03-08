Imports System.Windows.Controls

Public Class NvaFacturaCompra
    Public idProveedor As Integer
    Dim CondIva As Integer

    Private Function comprobarComprobanteCompra(ByRef comprobante As String, ByRef contribuyente As String) As Boolean
        Try
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id from fact_proveedores_fact_items where nufac like '" & comprobante & "' and " _
            & "replace(cuit,'-','') like '" & Replace(contribuyente, "-", "") & "'", conexionPrinc)
            Dim tablacl As New DataTable
            consulta.Fill(tablacl)
            If tablacl.Rows.Count <> 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            Return False
        End Try
    End Function
    Private Sub cmdFinalizar_Click(sender As Object, e As EventArgs) Handles cmdFinalizar.Click
        Dim fecha As String = Format(CDate(txtcomprobanteFcompra.Text), "yyyy-MM-dd")
        Dim tipocomp As String = cmbtipocomComp.Text
        Dim numfac As String = txtfaciz.Text & "-" & txtfacder.Text
        Dim razon As String = cmbrazonComp.Text
        Dim cuit As String = txtcuitComp.Text
        Dim conIVA As String = cmbcondivaComp.Text
        Dim neto21 As String = txtnetoComp.Text
        Dim neto105 As String = txtnetocom105.Text
        Dim neto27 As String = txtnetocom27.Text
        Dim iva As String = txtivamontoComp.Text
        Dim monot As String = txtmontmonotComp.Text
        Dim pcuenta As String = txtpagoacuentaComp.Text
        Dim nogrex As String = txtnogrComp.Text
        Dim periv As String = txtpercivComp.Text
        Dim perib As String = txtperibComp.Text
        Dim total As String = txttotalComp.Text
        Dim observa As String = txtobservacionesComp.Text
        Dim bienuso As Integer = chkcomprabiendeuso.CheckState
        Dim sqlQuery As String
        Try
            If comprobarComprobanteCompra(numfac, cuit) = True Then
                MsgBox("el comprobante ya fue cargado, por favor verifique")
                Exit Sub
            End If
            Dim tipoComprobante As Integer
            Select Case tipocomp
                Case "FA"
                    tipoComprobante = 1
                Case "FB"
                    tipoComprobante = 6
                Case "FC"
                    tipoComprobante = 11
            End Select

            If tipocomp = "NC" Then
                If neto21 <> 0 Then neto21 = "-" & neto21
                If neto105 <> 0 Then neto105 = "-" & neto105
                If neto27 <> 0 Then neto27 = "-" & neto27
                If iva <> 0 Then iva = "-" & iva
                If monot <> 0 Then monot = "-" & monot
                If pcuenta <> 0 Then pcuenta = "-" & pcuenta
                If nogrex <> 0 Then nogrex = "-" & nogrex
                If periv <> 0 Then periv = "-" & periv
                If perib <> 0 Then perib = "-" & perib
                If perib <> 0 Then total = "-" & total
            End If
            Reconectar()
            sqlQuery = "insert into fact_proveedores_fact(fecha, tipo,numero,monto,vencimiento,idproveedor,tipoingeg,cerrado) values(
             ?fecha,?tipo,?numero,?monto,?vencimiento,?idproveedor,?tipoingeg,?cerrado)"
            Dim addFactProvStock As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With addFactProvStock.Parameters
                .AddWithValue("?fecha", fecha)
                .AddWithValue("?tipo", tipoComprobante)
                .AddWithValue("?numero", numfac)
                .AddWithValue("?monto", total)
                .AddWithValue("?vencimiento", fecha)
                .AddWithValue("?idproveedor", idProveedor)
                .AddWithValue("?tipoingeg", 1)
                .AddWithValue("?cerrado", 0)
            End With
            addFactProvStock.ExecuteNonQuery()

            If chkcomprabiendeuso.CheckState = 1 Then
                observa = "BIEN DE USO"
            End If
            Reconectar()
            sqlQuery = "insert into fact_proveedores_fact_items(periodo, fecha,tipocom,nufac,razon,cuit,tipocontr,neto21,neto105,neto27,iva,monot," _
            & "acuenta,nogr,perciva,percib,total,obs,bien_uso) " _
            & "values(?per,?fech,?tcomp,?nfac,?raz,?cuit,?tcontr,?neto21,?neto105,?neto27,?iva,?mon,?acuenta,?nogr,?periva,?perib,?tot,?obs,?bien)"
            Dim additem As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With additem.Parameters
                .AddWithValue("?per", 0)
                .AddWithValue("?fech", fecha)
                .AddWithValue("?tcomp", tipocomp)
                .AddWithValue("?nfac", numfac)
                .AddWithValue("?raz", razon)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?tcontr", conIVA)
                .AddWithValue("?neto21", neto21)
                .AddWithValue("?neto105", neto105)
                .AddWithValue("?neto27", neto27)
                .AddWithValue("?iva", iva)
                .AddWithValue("?mon", monot)
                .AddWithValue("?acuenta", pcuenta)
                .AddWithValue("?nogr", nogrex)
                .AddWithValue("?periva", periv)
                .AddWithValue("?perib", perib)
                .AddWithValue("?tot", total)
                .AddWithValue("?obs", observa.ToUpper)
                .AddWithValue("?bien", bienuso)
            End With
            additem.ExecuteNonQuery()

            With proveedores
                .cargarCuentaProv(idProveedor)
            End With



            MsgBox("comprobante cargado correctamente")
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub NvaFacturaCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reconectar()
        txtcomprobanteFcompra.Focus()

        'cargar razon social proveedores
        Dim tablarazonSocial As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, razon, replace(cuit,'-','') as cuit, 
        case tipo_iva
        when 1 then 
        'RI'
        when 6 then
        'MON' end as tipoContr  
        from  fact_proveedores where id=" & idProveedor, conexionPrinc)
        'Dim readrazonSocial As New DataSet
        Dim tablaProv As New DataTable
        tablarazonSocial.Fill(tablaProv)
        'tablarazonSocial.Fill(readrazonSocial)
        'cmbrazonComp.DataSource = readrazonSocial.Tables(0)
        'cmbrazonComp.DisplayMember = readrazonSocial.Tables(0).Columns(1).Caption.ToString
        'cmbrazonComp.ValueMember = readrazonSocial.Tables(0).Columns(0).Caption.ToString
        cmbrazonComp.Text = tablaProv.Rows(0).Item("razon").ToString.ToUpper
        cmbcondivaComp.Text = tablaProv.Rows(0).Item("tipoContr")
        If cmbcondivaComp.Text = "RI" Then
            cmbtipocomComp.Text = "FA"
        ElseIf cmbcondivaComp.Text = "MON" Then
            cmbtipocomComp.Text = "FC"
        End If

        txtcuitComp.Text = tablaProv.Rows(0).Item("cuit")






    End Sub
    Private Sub txtperibComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtperibComp.Validating
        If txtperibComp.Text = "" Then txtperibComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtnetoComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnetoComp.Validating
        If txtnetoComp.Text = "" Then txtnetoComp.Text = 0
        Sumar()
    End Sub


    Private Sub txtpercivComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtpercivComp.Validating
        If txtpercivComp.Text = "" Then txtpercivComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtivamontoComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtivamontoComp.Validating
        If txtivamontoComp.Text = "" Then txtivamontoComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtmontmonotComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtmontmonotComp.Validating
        If txtmontmonotComp.Text = "" Then txtmontmonotComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtpagoacuentaComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtpagoacuentaComp.Validating
        If txtpagoacuentaComp.Text = "" Then txtpagoacuentaComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtnogrComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnogrComp.Validating
        If txtnogrComp.Text = "" Then txtnogrComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtnetocom105_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnetocom105.Validating
        If txtnetocom105.Text = "" Then txtnetocom105.Text = 0
        Sumar()
    End Sub

    Private Sub txtnetocom27_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnetocom27.Validating
        If txtnetocom27.Text = "" Then txtnetocom27.Text = 0
        Sumar()
    End Sub

    Private Sub txtfaciz_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtfaciz.Validating
        Dim i As Integer
        Dim ceros As String
        If txtfaciz.TextLength < 4 Then
            For i = 1 To 4 - txtfaciz.TextLength
                ceros = ceros & "0"
            Next
            txtfaciz.Text = ceros & txtfaciz.Text
        End If
    End Sub

    Private Sub txtfacder_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtfacder.Validating
        Dim i As Integer
        Dim ceros As String
        If txtfacder.TextLength < 8 Then
            For i = 1 To 8 - txtfacder.TextLength
                ceros = ceros & "0"
            Next
            txtfacder.Text = ceros & txtfacder.Text
        End If
    End Sub
    Private Sub Sumar()
        Try
            Dim neto21 As Double = FormatNumber(txtnetoComp.Text)
            Dim neto105 As Double = FormatNumber(txtnetocom105.Text)
            Dim neto27 As Double = FormatNumber(txtnetocom27.Text)
            Dim ivatemp As Double = Math.Round(neto21 * 0.21 + neto105 * 0.105 + neto27 * 0.27, 2)
            txtivamontoComp.Text = ivatemp
            Dim ivamont As Double = FormatNumber(txtivamontoComp.Text)
            Dim monot As Double = FormatNumber(txtmontmonotComp.Text)
            Dim pagoCuenta As Double = FormatNumber(txtpagoacuentaComp.Text)
            Dim noGREX As Double = FormatNumber(txtnogrComp.Text)
            Dim percIVA As Double = FormatNumber(txtpercivComp.Text)
            Dim percIB As Double = FormatNumber(txtperibComp.Text)

            txttotalComp.Text = FormatNumber(neto21 + neto105 + neto27 + ivamont + monot + pagoCuenta + noGREX + percIVA + percIB, 2)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtfaciz_TextChanged(sender As Object, e As EventArgs) Handles txtfaciz.TextChanged

    End Sub

    Private Sub NvaFacturaCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'MsgBox("la puta que me pario que funcione")
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcomprobanteFcompra_TextChanged(sender As Object, e As EventArgs) Handles txtcomprobanteFcompra.TextChanged

    End Sub

    Private Sub txtcomprobanteFcompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcomprobanteFcompra.KeyPress
        Dim texto As String = txtcomprobanteFcompra.Text
        'If TypeOf (sender) Is TextBox Then
        'End If
        'texto
        Dim longitud As Integer = texto.Length
        Dim caracter As Char = e.KeyChar
        Dim caracterAlfa As Boolean = False

        If longitud >= 10 And Char.IsControl(caracter) Then
            e.Handled = False
        ElseIf longitud >= 10 And Not Char.IsControl(caracter) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
        If Char.IsDigit(caracter) Then
            caracterAlfa = False
        ElseIf Char.IsControl(caracter) Then
            caracterAlfa = True
        Else
            If caracter = Chr(45) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
            caracterAlfa = True
        End If

        If caracterAlfa = False Then
            Select Case longitud
                Case 1
                    SendKeys.Send("-")
                Case 4
                    SendKeys.Send("-")
            End Select
        End If
    End Sub

    Private Sub cmbtipocomComp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtipocomComp.SelectedIndexChanged

    End Sub

    Private Sub cmbtipocomComp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbtipocomComp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'MsgBox("la puta que me pario que funcione")
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class