Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms

Public Class GestorImpresion

    ' Variable temporal para mantener el ID actual durante el evento de impresión térmica
    Private Shared idFacturaActual As Integer = 0

    ' =========================================================================
    ' MÉTODO PRINCIPAL DE ENRUTAMIENTO (Controlado por la UI)
    ' =========================================================================
    Public Shared Sub ImprimirComprobante(idfact As Integer, ptovta As Integer, esTermica As Boolean, directo As Boolean)
        Try
            idFacturaActual = idfact ' Guardamos para los eventos de la impresora térmica

            Dim fac As New datosfacturas
            Reconectar()

            ' 1. Consultar Encabezado
            Dim sqlEmp As String = "SELECT emp.nombrefantasia as empnombre, emp.razonsocial as emprazon, emp.direccion as empdire, emp.localidad as emploca, " &
                                   "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr, emp.inicioact as empinicioact, emp.drei as empdrei, emp.logo as emplogo, " &
                                   "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, DATE_FORMAT(fac.f_alta, '%d-%m-%Y') AS facfech, " &
                                   "concat(fac.id_cliente,'-',fac.razon,' - tel ',cl.telefono) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr, fac.cuit as faccuit, " &
                                   "concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva, format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21, " &
                                   "fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra, format(fac.total,2,'es_AR') as factotal, format(fac.subtotal,2,'es_AR') as facsubtotal, fac.codigo_qr, cl.email " &
                                   "FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa2 as emp, fact_facturas as fac, " &
                                   "fact_puntosventa as ptovta, fact_condventas as condvent " &
                                   "WHERE vend.id=fac.vendedor AND cl.idclientes=fac.id_cliente AND " &
                                   "fac.ptovta = ptovta.numero AND ptovta.idEmpresa=emp.idEmpresa AND " &
                                   "fis.donfdesc=fac.tipofact AND fis.ptovta=fac.ptovta AND condvent.id=fac.condvta AND fac.id = @idFac"

            Using cmdEmp As New MySqlCommand(sqlEmp, GestorConexiones.conexionPrinc)
                cmdEmp.Parameters.AddWithValue("@idFac", idfact)
                Using adapter As New MySqlDataAdapter(cmdEmp)
                    adapter.Fill(fac.Tables("factura_enca"))
                End Using
            End Using

            ' 2. Consultar Ítems
            Dim sqlFac As String = "SELECT plu, format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, " &
                                   "format(replace(iva,',','.'),2,'es_AR') as iva, format(replace(punit,',','.'),2,'es_AR') as punit, " &
                                   "format(replace(impuestoFijo01,',','.'),2,'es_AR') as idc, format(replace(impuestoFijo02,',','.'),2,'es_AR') as icl, " &
                                   "format(replace(ptotal,',','.'),2,'es_AR') as ptotal, plu as codigo " &
                                   "FROM fact_items WHERE id_fact = @idFac"

            Using cmdFac As New MySqlCommand(sqlFac, GestorConexiones.conexionPrinc)
                cmdFac.Parameters.AddWithValue("@idFac", idfact)
                Using adapter As New MySqlDataAdapter(cmdFac)
                    adapter.Fill(fac.Tables("facturax"))
                End Using
            End Using

            If fac.Tables("factura_enca").Rows.Count = 0 Then
                MsgBox("No se encontró información para imprimir el comprobante ID: " & idfact, MsgBoxStyle.Exclamation)
                Return
            End If

            Dim rowEnca As DataRow = fac.Tables("factura_enca").Rows(0)
            Dim tipoFact As Integer = Convert.ToInt32(rowEnca("donfdesc"))

            ' Si es recibo interno específico
            If tipoFact = 996 Then
                ' Si tenés la función ImprimirRecibos en otro lado, dejas esto. Si no, adaptalo al formato que necesites.
                ' ImprimirRecibos(idfact)
                Return
            End If

            ' 3. EVALUAR TIPO DE SALIDA SEGÚN LO ELEGIDO POR EL USUARIO EN PANTALLA
            If esTermica Then
                ' --- SALIDA POR IMPRESORA TÉRMICA ---
                Dim printTxt As New PrintDocument()
                Dim pgSize As New PaperSize()
                pgSize.RawKind = PaperKind.Custom
                pgSize.Width = 147
                printTxt.DefaultPageSettings.PaperSize = pgSize

                ' Seleccionar el tipo de ticket térmico
                If ptovta <> FacturaElectro.puntovtaelect Then

                    AddHandler printTxt.PrintPage, AddressOf ImprimirTiketVenta
                Else

                    AddHandler printTxt.PrintPage, AddressOf ImprimirTiketFiscal
                End If

                printTxt.PrinterSettings.PrinterName = My.Settings.ImprTiketsNombre
                printTxt.Print()
            Else
                ' --- SALIDA POR REPORTE A4 (RDLC) ---
                Dim direccionReport As String = If(ptovta <> FacturaElectro.puntovtaelect,
                    System.Environment.CurrentDirectory & "\reportes\facturax.rdlc",
                    System.Environment.CurrentDirectory & "\reportes\facturaelectro.rdlc")

                If directo Then
                    Using imprimir As New ImprimirDirecto()
                        imprimir.Run(fac.Tables("factura_enca"), fac.Tables("facturax"), direccionReport)
                    End Using
                Else
                    Dim imprimirx As New imprimirFX()
                    With imprimirx
                        .rptfx.ProcessingMode = ProcessingMode.Local
                        Select Case tipoFact
                            Case 1 To 3, 6 To 8, 11 To 13
                                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturaelectro.rdlc"
                            Case Else
                                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturax.rdlc"
                        End Select
                        .rptfx.LocalReport.DataSources.Clear()
                        .rptfx.LocalReport.DataSources.Add(New ReportDataSource("encabezado", fac.Tables("factura_enca")))
                        .rptfx.LocalReport.DataSources.Add(New ReportDataSource("items", fac.Tables("facturax")))
                        .rptfx.DocumentMapCollapsed = True
                        .rptfx.RefreshReport()
                        .Show()
                    End With
                End If
            End If

        Catch ex As Exception
            MsgBox("Error en el motor de impresión: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' =========================================================================
    ' RUTINA 1: TICKET NO FISCAL (Impresora Térmica)
    ' =========================================================================
    Private Shared Sub ImprimirTiketVenta(sender As Object, e As PrintPageEventArgs)
        Dim printfont As New Font("Courier New", 6)
        Dim font3 As New Font("Courier New", 8)
        Dim font5 As New Font("Courier New", 6)

        ' Dim yPos As Single = 0

        Reconectar()
        Dim dtEmpresa As New DataTable()
        Dim dtProd As New DataTable()

        Dim sqlE As String = "SELECT emp.nombrefantasia, emp.razonsocial, concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, " &
                             "DATE_FORMAT(fac.f_alta, '%d-%m-%Y') as facfech, concat(fac.id_cliente,'-',fac.razon) as facrazon, " &
                             "format(fac.total,2,'es_AR') as total, format(fac.subtotal,2,'es_AR') as subtotal, format(fac.iva21,2,'es_AR') as iva21 " &
                             "FROM fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac " &
                             "WHERE emp.id=1 AND fis.donfdesc=fac.tipofact AND fac.ptovta=fis.ptovta AND fac.id=" & idFacturaActual

        Using cmd As New MySqlCommand(sqlE, GestorConexiones.conexionPrinc)
            Using da As New MySqlDataAdapter(cmd)
                da.Fill(dtEmpresa)
            End Using
        End Using

        Dim sqlP As String = "SELECT format(cantidad,2,'es_AR') as cant, descripcion, format(iva,2,'es_AR') as iva, format(punit,2,'es_AR') as punit, format(ptotal,2,'es_AR') as ptotal FROM fact_items WHERE id_fact=" & idFacturaActual
        Using cmdP As New MySqlCommand(sqlP, GestorConexiones.conexionPrinc)
            Using da As New MySqlDataAdapter(cmdP)
                da.Fill(dtProd)
            End Using
        End Using

        If dtEmpresa.Rows.Count = 0 Then Return
        Dim rEmp = dtEmpresa.Rows(0)

        ' 1. Imprimimos el Logo
        Dim logoPath As String = Application.StartupPath & "\logo2.jpg"
        If System.IO.File.Exists(logoPath) Then
            e.Graphics.DrawImage(Image.FromFile(logoPath), 5, 15)
        End If

        ' 2. Cabecera (Usando tus posiciones Y exactas: 100, 110, 120...)
        e.Graphics.DrawString("Razón social: " & rEmp("razonsocial").ToString(), font5, Brushes.Black, 0, 100)
        e.Graphics.DrawString("Tiket N°: " & rEmp("facnum").ToString(), font5, Brushes.Black, 0, 110)
        e.Graphics.DrawString("Fecha: " & rEmp("facfech").ToString(), font5, Brushes.Black, 0, 120)
        e.Graphics.DrawString("Ciente: " & rEmp("facrazon").ToString(), font5, Brushes.Black, 0, 130)
        e.Graphics.DrawString("#Articulos:" & dtProd.Rows.Count, font5, Brushes.Black, 0, 140)
        e.Graphics.DrawString(StrDup(65, "#"), font5, Brushes.Black, 0, 150)
        e.Graphics.DrawString("### TIKET NO VALIDO COMO FACTURA ###", font5, Brushes.Black, 0, 160)
        e.Graphics.DrawString(StrDup(65, "#"), font5, Brushes.Black, 0, 170)

        Dim yPos As Integer = 190

        ' 3. Detalle de productos (Respetando el corte a 25 caracteres y los 7 para el precio)
        For Each row As DataRow In dtProd.Rows
            Dim unidad As String = row("cant").ToString()
            Dim detalle As String = row("descripcion").ToString()
            Dim valoruni As String = row("punit").ToString()
            Dim valortot As String = FormatNumber(row("ptotal"), 2)
            Dim ivaProd As String = row("iva").ToString()

            ' Línea 1: Cantidad x Precio + IVA
            Dim texto As String = unidad & " x " & valoruni & Chr(9) & "  (" & ivaProd & ")"
            e.Graphics.DrawString(texto, printfont, Brushes.Black, 0, yPos)
            yPos += 10

            ' Forzamos exactamente 25 caracteres para la descripción
            If detalle.Length <= 25 Then
                detalle = detalle.PadRight(25, " "c)
            Else
                detalle = detalle.Substring(0, 25)
            End If

            ' Forzamos exactamente 7 caracteres para el total
            If valortot.Length <= 7 Then
                valortot = valortot.PadLeft(7, " "c)
            End If

            ' Línea 2: Descripción y Valor total
            e.Graphics.DrawString(detalle & "  " & valortot, printfont, Brushes.Black, 0, yPos)
            yPos += 10
        Next

        yPos += 20 ' Salto antes de la zona de totales

        ' 4. Totales (Recuperando exactamente tu lógica original)
        Dim facSubtotal As String = FormatNumber(rEmp("subtotal"), 2)
        Dim FacIva21 As String = FormatNumber(rEmp("iva21"), 2)
        Dim facTotal As String = FormatNumber(rEmp("total"), 2)
        Dim car As Integer
        Dim j As Integer

        ' --- Relleno de espacios a la izquierda (hasta 7 caracteres) ---
        If FacIva21.Length <= 7 Then
            car = 7 - FacIva21.Length
            For j = 0 To car
                FacIva21 = " " & FacIva21
            Next
        End If

        If facSubtotal.Length <= 7 Then
            car = 7 - facSubtotal.Length
            For j = 0 To car
                facSubtotal = " " & facSubtotal
            Next
        End If

        If facTotal.Length <= 7 Then
            car = 7 - facTotal.Length
            For j = 0 To car
                facTotal = " " & facTotal
            Next
        End If

        ' --- Nombres de los totales ---
        Dim textosub As String = "Subtotal"
        Dim textoIva21 As String = "Alicuota 21%"
        Dim textoTotal As String = "Total"

        Dim lineaSep As String = StrDup(27, " ")
        e.Graphics.DrawString(lineaSep & "__________", printfont, System.Drawing.Brushes.Black, 0, yPos)

        ' --- Impresión de los renglones con StrDup para los puntitos ---
        Dim XXX As Integer = 0
        Dim lineatotal As String = ""

        XXX = 27 - (textosub.Length + facSubtotal.Length)
        If XXX < 0 Then XXX = 0 ' Por si acaso para que no falle el StrDup
        lineatotal = StrDup(XXX, ".")
        yPos += 10
        e.Graphics.DrawString(textosub & lineatotal & facSubtotal, font3, System.Drawing.Brushes.Black, 0, yPos)

        XXX = 27 - (textoIva21.Length + FacIva21.Length)
        If XXX < 0 Then XXX = 0
        lineatotal = StrDup(XXX, ".")
        yPos += 10
        e.Graphics.DrawString(textoIva21 & lineatotal & FacIva21, font3, System.Drawing.Brushes.Black, 0, yPos)

        XXX = 27 - (textoTotal.Length + facTotal.Length)
        If XXX < 0 Then XXX = 0
        lineatotal = StrDup(XXX, ".")
        yPos += 10
        e.Graphics.DrawString(textoTotal & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)

        yPos += 30
        e.Graphics.DrawString("Gracias por tu compra!!!", font3, System.Drawing.Brushes.Black, 15, yPos)
    End Sub

    ' =========================================================================
    ' RUTINA 2: TICKET FISCAL / ELECTRÓNICO TÉRMICO (Con QR y CAE) - 58mm
    ' =========================================================================
    Private Shared Sub ImprimirTiketFiscal(sender As Object, e As PrintPageEventArgs)
        Dim printfont As New Font("Courier New", 6)
        Dim font3 As New Font("Courier New", 8)
        Dim font4 As New Font("Courier New", 18)
        Dim font5 As New Font("Courier New", 6)
        Dim fontCAE As New Font("Courier New", 5.3, FontStyle.Italic)

        Dim yPos As Single = 100
        Reconectar()

        Dim dtEmpresa As New DataTable()
        Dim dtProd As New DataTable()

        ' Le agregué "as tipofact" a fis.donfdesc para poder leerlo fácil después
        Dim sqlE As String = "SELECT emp.razonsocial, emp.direccion, emp.localidad, emp.cuit, emp.ingbrutos, emp.ivatipo, emp.inicioact, " &
                         "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, DATE_FORMAT(fac.f_alta, '%d-%m-%Y') as facfech, " &
                         "fac.razon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr, fac.cuit as faccuit, " &
                         "condvent.condicion as faccondvta, fis.donfdesc as tipofact, fac.cae, fis.letra, fis.codfiscal, fac.vtocae, fac.codigo_qr, " &
                         "format(fac.total,2,'es_AR') as factotal, format(fac.subtotal,2,'es_AR') as facsubtotal, format(fac.iva21,2,'es_AR') as iva21, format(fac.otroiva,2,'es_AR') as noGravado " &
                         "FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac, fact_condventas as condvent " &
                         "WHERE vend.id=fac.vendedor AND cl.idclientes=fac.id_cliente AND emp.id=1 AND fis.donfdesc=fac.tipofact AND condvent.id=fac.condvta AND fac.ptovta=fis.ptovta AND fac.id=" & idFacturaActual

        Using cmd As New MySqlCommand(sqlE, GestorConexiones.conexionPrinc)
            Using da As New MySqlDataAdapter(cmd)
                da.Fill(dtEmpresa)
            End Using
        End Using

        Dim sqlP As String = "SELECT format(cantidad,2,'es_AR') as cant, descripcion, format(iva,2,'es_AR') as iva, format(punit,2,'es_AR') as punit, format(ptotal,2,'es_AR') as ptotal FROM fact_items WHERE id_fact=" & idFacturaActual
        Using cmdP As New MySqlCommand(sqlP, GestorConexiones.conexionPrinc)
            Using da As New MySqlDataAdapter(cmdP)
                da.Fill(dtProd)
            End Using
        End Using

        If dtEmpresa.Rows.Count = 0 Then Return
        Dim r = dtEmpresa.Rows(0)

        e.Graphics.DrawString(r("razonsocial").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString("CUIT Nro: " & r("cuit").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString("Ing. Brutos: " & r("ingbrutos").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString("Domicilio: " & r("direccion").ToString() & " - " & r("localidad").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString("IVA " & r("ivatipo").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 20

        e.Graphics.DrawString(StrDup(40, "*"), font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString($"FACTURA '{r("letra")}' (Cod. {r("codfiscal")})", font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString(r("facnum").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString("Fecha: " & r("facfech").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString(StrDup(40, "*"), font5, Brushes.Black, 0, yPos) : yPos += 10

        e.Graphics.DrawString("Cliente: " & r("razon").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString("CUIT: " & r("faccuit").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString("Cond. IVA: " & r("tipocontr").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 10
        e.Graphics.DrawString("Cond. Venta: " & r("faccondvta").ToString(), font5, Brushes.Black, 0, yPos) : yPos += 15

        For Each row As DataRow In dtProd.Rows
            Dim cant As String = row("cant").ToString()
            Dim desc As String = row("descripcion").ToString()
            Dim pUnit As String = row("punit").ToString()
            Dim pTotal As String = row("ptotal").ToString()
            Dim iva As String = row("iva").ToString()

            If desc.Length > 22 Then desc = desc.Substring(0, 22)

            e.Graphics.DrawString($"{cant} x {pUnit} ({iva}%)", printfont, Brushes.Black, 0, yPos)
            yPos += 10
            e.Graphics.DrawString($"{desc.PadRight(22)} {pTotal.PadLeft(12)}", printfont, Brushes.Black, 0, yPos)
            yPos += 14
        Next

        yPos += 10

        ' --- SECCIÓN DE TOTALES ACTUALIZADA (Con los puntitos y límite de 58mm) ---
        Dim tipoFactura As Integer = Convert.ToInt32(r("tipofact"))
        Dim facSubtotal As String = r("facsubtotal").ToString()
        Dim iva21 As String = r("iva21").ToString()
        Dim facTotal As String = r("factotal").ToString()
        Dim noGrav As String = r("noGravado").ToString()
        Dim maxCaracteres As Integer = 27
        Dim XXX As Integer = 0

        If tipoFactura <= 3 Then ' Factura A
            ' Neto Gravado
            XXX = maxCaracteres - ("Neto Gravado".Length + facSubtotal.Length)
            If XXX < 0 Then XXX = 0
            e.Graphics.DrawString("Neto Gravado" & StrDup(XXX, ".") & facSubtotal, font3, Brushes.Black, 0, yPos) : yPos += 12

            ' IVA 21%
            XXX = maxCaracteres - ("IVA 21%".Length + iva21.Length)
            If XXX < 0 Then XXX = 0
            e.Graphics.DrawString("IVA 21%" & StrDup(XXX, ".") & iva21, font3, Brushes.Black, 0, yPos) : yPos += 12

            ' Otros Tributos (Solo si tiene)
            If noGrav <> "0,00" AndAlso noGrav <> "0.00" Then
                Dim txtTrib As String = "Otros Tributos"
                XXX = maxCaracteres - (txtTrib.Length + noGrav.Length)
                If XXX < 0 Then XXX = 0
                e.Graphics.DrawString(txtTrib & StrDup(XXX, ".") & noGrav, font3, Brushes.Black, 0, yPos) : yPos += 12
            End If
        Else ' Factura B o C (Consumidor Final)
            ' Subtotal
            XXX = maxCaracteres - ("Subtotal".Length + facTotal.Length)
            If XXX < 0 Then XXX = 0
            e.Graphics.DrawString("Subtotal" & StrDup(XXX, ".") & facTotal, font3, Brushes.Black, 0, yPos) : yPos += 12
        End If

        ' Total
        XXX = maxCaracteres - ("Total".Length + facTotal.Length)
        If XXX < 0 Then XXX = 0
        e.Graphics.DrawString("Total" & StrDup(XXX, ".") & facTotal, font3, Brushes.Black, 0, yPos) : yPos += 20
        ' --------------------------------------------------------------------------

        e.Graphics.DrawString("COMPROBANTE AUTORIZADO POR WEB SERVICE", fontCAE, Brushes.Black, 0, yPos) : yPos += 12
        e.Graphics.DrawString("CAE: " & r("cae").ToString(), fontCAE, Brushes.Black, 0, yPos) : yPos += 12
        e.Graphics.DrawString("F. Vto CAE: " & r("vtocae").ToString(), fontCAE, Brushes.Black, 0, yPos) : yPos += 15

        ' Tu código original para el QR intacto
        If Not IsDBNull(r("codigo_qr")) Then
            Dim qrBytes As Byte() = CType(r("codigo_qr"), Byte())
            Using ms As New System.IO.MemoryStream(qrBytes)
                Using imgOrg As Image = Image.FromStream(ms)
                    Using bmpQR As New Bitmap(imgOrg, 120, 120)
                        e.Graphics.DrawImage(bmpQR, 0, yPos)
                        yPos += 130
                    End Using
                End Using
            End Using
        End If

        e.Graphics.DrawString("Gracias por tu compra!", font3, Brushes.Black, 10, yPos)
    End Sub
End Class