Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop
Imports Microsoft.Reporting.WinForms

'Imports Excel = Microsoft.Office.Interop.Excel
'Imports System.Runtime.InteropServices
Module funciones_Globales

    Public idFactura As Integer
    Public Function cargarInfoFactCobro(idFactura As Integer) As String()
        ReDim cargarInfoFactCobro(3)
        Dim infoFact As String()
        ReDim infoFact(3)
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from facturasclientes_impagas where idfact= " & idFactura, conexionPrinc)
        Dim tablaPers As New DataTable
        Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
        consulta.Fill(tablaPers)
        If tablaPers.Rows.Count <> 0 Then
            infoFact(0) = tablaPers(0).Item("id")
            infoFact(1) = tablaPers(0).Item("comprobante")
            infoFact(2) = tablaPers(0).Item("importe")
            infoFact(3) = tablaPers(0).Item("idfact")
        End If

        Return infoFact

    End Function
    Public Sub GenerarPDF(Encabezado As DataTable, Items As DataTable, Ruta As String, Archivo As String, reporte As String)

        Try
            Dim deviceInf As String = "<DeviceInfo>
                <EmbedFonts>None</EmbedFonts>
                </DeviceInfo>"
            Dim viewer As New Microsoft.Reporting.WinForms.ReportViewer()
            viewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            viewer.LocalReport.EnableExternalImages = True
            viewer.LocalReport.ReportPath = reporte 'imprimirFX.rptfx.LocalReport.ReportPath 'System.Environment.CurrentDirectory & "\reportes\facturax.rdlc"
            viewer.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", Encabezado))
            viewer.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", Items))


            Dim exportarPDF As Byte() = viewer.LocalReport.Render("PDF", deviceInf)
            Dim NuevoDocumento As New FileStream(Ruta & Archivo, FileMode.Create)
            NuevoDocumento.Write(exportarPDF, 0, exportarPDF.Length)
            NuevoDocumento.Close()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub GuardarLog(Clie As String, usuario As String, bd As String, tarea As String, ip As String)
        Try
            Reconectar()
            Dim agregarLog As String = "insert into AuthServ.LogAcc(Clie,usuario,bd,tarea,ip) values(
            ?Clie,?usuario,?bd,?tarea,?ip)"
            Dim comandoLog As New MySql.Data.MySqlClient.MySqlCommand(agregarLog, conexionAuth)
            With comandoLog.Parameters
                .AddWithValue("?Clie", Clie)
                .AddWithValue("?usuario", usuario)
                .AddWithValue("?bd", bd)
                .AddWithValue("?tarea", tarea)
                .AddWithValue("?ip", ip)
            End With
            comandoLog.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Public Function obtenerPrimerDiaMes() As Date
        Try
            Return CDate("01-" & Month(Now) & "-" & Year(Now))
        Catch ex As Exception

        End Try
    End Function
    Public Function ElementoFacturado(descripcion As String) As Boolean
        Try
            Reconectar()
            Dim consItmFacturado As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT fact.num_fact FROM fact_facturas as fact, fact_items as itm where
            itm.id_fact=fact.id and
            itm.descripcion like '%" & descripcion & "%'", conexionPrinc)
            Dim tabItmFacturado As New DataTable
            consItmFacturado.Fill(tabItmFacturado)
            If tabItmFacturado.Rows.Count <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ConsultarPeriodoCerrado(periodo As String) As Boolean
        Try
            Reconectar()
            Dim consPeriodoCerrado As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT periodo from cm_periodos_cerrados where periodo like '" & periodo & "' limit 1", conexionPrinc)
            Dim tabPeriodoCerrado As New DataTable
            consPeriodoCerrado.Fill(tabPeriodoCerrado)
            If tabPeriodoCerrado.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception

        End Try
    End Function
    Public Function ObtenerNumeroAsiento() As Integer
        Reconectar()
        Dim consNumeroAsiento As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT max(codigoAsiento) as codigoAsiento from cm_libroDiario limit 1", conexionPrinc)
        Dim tabNumeroAsiento As New DataTable
        consNumeroAsiento.Fill(tabNumeroAsiento)
        Dim NumeroAsiento As Integer = 0
        If IsDBNull(tabNumeroAsiento.Rows(0).Item("codigoAsiento")) Then
            NumeroAsiento = 1
        Else
            NumeroAsiento = tabNumeroAsiento.Rows(0).Item("codigoAsiento") + 1
        End If
        Return NumeroAsiento
    End Function

    Public Function GuardarAsientoContable(codigoAsiento As Integer, comprobante As String, concepto As String, importeDebe As Double, cuentaDebeId As Integer,
                                           importeHaber As Double, cuentaHaberId As Integer, numPartidas As Integer, fecha As String) As Boolean
        Try
            If ConsultarPeriodoCerrado(Format(fecha, "yyyy-MM")) = True Then
                Return False
                Exit Function
            End If

            Reconectar()
            If importeDebe <> 0 And importeHaber <> 0 Then
                Dim agregarPartidaDebe As String = "insert into cm_Asientos(codigoAsiento,cuentaDebeId,importeDebe,cuentaHaberId,importeHaber) values
                (?codigoAsiento,?cuentaDebeId,?importeDebe,?cuentaHaberId,?importeHaber)"
                Dim comandoPartidaDebe As New MySql.Data.MySqlClient.MySqlCommand(agregarPartidaDebe, conexionPrinc)
                With comandoPartidaDebe.Parameters
                    .AddWithValue("?codigoAsiento", codigoAsiento)
                    .AddWithValue("?cuentaDebeId", cuentaDebeId)
                    .AddWithValue("?importeDebe", importeDebe)
                    .AddWithValue("?cuentaHaberId", 0)
                    .AddWithValue("?importeHaber", 0)
                End With
                comandoPartidaDebe.ExecuteNonQuery()

                Reconectar()
                Dim agregarPartidaHaber As String = "insert into cm_Asientos(codigoAsiento,cuentaDebeId,importeDebe,cuentaHaberId,importeHaber) values
                (?codigoAsiento,?cuentaDebeId,?importeDebe,?cuentaHaberId,?importeHaber)"
                Dim comandoPartidaHaber As New MySql.Data.MySqlClient.MySqlCommand(agregarPartidaHaber, conexionPrinc)
                With comandoPartidaHaber.Parameters
                    .AddWithValue("?codigoAsiento", codigoAsiento)
                    .AddWithValue("?cuentaDebeId", 0)
                    .AddWithValue("?importeDebe", 0)
                    .AddWithValue("?cuentaHaberId", cuentaHaberId)
                    .AddWithValue("?importeHaber", importeHaber)
                End With
                comandoPartidaHaber.ExecuteNonQuery()

                Dim agregarLibroDiario As String = "insert into cm_libroDiario (comprobanteInterno,codigoAsiento,fecha,concepto,totalDebe,totalHaber,numPartidas) values
            (?comprobanteInterno,?codigoAsiento,?fecha,?concepto,?totalDebe,?totalHaber,?numPartidas)"
                Dim comandoLibroDiario As New MySql.Data.MySqlClient.MySqlCommand(agregarLibroDiario, conexionPrinc)
                With comandoLibroDiario.Parameters
                    .AddWithValue("?comprobanteInterno", comprobante)
                    .AddWithValue("?codigoAsiento", codigoAsiento)
                    .AddWithValue("?fecha", fecha)
                    .AddWithValue("?concepto", concepto.ToUpper)
                    .AddWithValue("?totalDebe", importeDebe)
                    .AddWithValue("?totalHaber", importeHaber)
                    .AddWithValue("?numPartidas", numPartidas)
                End With
                comandoLibroDiario.ExecuteNonQuery()

                Dim agregarLibroMayor As String = "insert into cm_libroMayor (fecha,concepto,codigoAsiento) values
            (?fecha,?concepto,?codigoAsiento)"
                Dim comandoLibroMayor As New MySql.Data.MySqlClient.MySqlCommand(agregarLibroMayor, conexionPrinc)
                With comandoLibroMayor.Parameters
                    .AddWithValue("?fecha", fecha)
                    .AddWithValue("?concepto", concepto.ToUpper)
                    .AddWithValue("?codigoAsiento", codigoAsiento)
                End With
                comandoLibroMayor.ExecuteNonQuery()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function ObtenerFechaFacturaElectro(numFac As Integer, tipoFac As Integer) As String
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT replace(fecha,'-','') as fecha 
                FROM fact_facturas where tipofact=" & tipoFac & " and num_fact=" & numFac & " limit 1", conexionPrinc)
            Dim fecha As New DataTable
            consulta.Fill(fecha)

            If fecha.Rows.Count = 0 Then
                Return ""
            Else
                Return (fecha.Rows(0).Item(0))
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function ObtenerReferenciaControl_tabpage(ByVal nombreControl As String, ByVal Formulario As TabPage) As Control

        ' Recorremos la colección de controles del formulario
        '
        For Each ctrl As Control In Formulario.Controls

            If ctrl.Name.ToLower = nombreControl.ToLower Then
                ' Devolvemos la referencia y abandonamos la función
                Return ctrl
            End If

        Next

        Return Nothing

    End Function
    Public Function ObtenerCotizacion(idMoneda As Integer) As Double
        Reconectar()
        Dim lector As System.Data.IDataReader
        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        sql.Connection = conexionPrinc
        sql.CommandText = "Select (Select cotizacion from fact_moneda  where  id =" & idMoneda & ") As cotiza, (Select valor from fact_configuraciones where  id =1) As lista"
        sql.CommandType = CommandType.Text
        'MsgBox(sql.CommandText)
        lector = sql.ExecuteReader
        lector.Read()
        Dim cotizacion As Double = FormatNumber(lector("cotiza").ToString)
        Return cotizacion
    End Function

    Public Function SumartTotalesColumnaTabla(NombreColumna As String, tabla As DataGridView) As Double
        Dim total As Double
        Dim monto As Double
        For Each fila As DataGridViewRow In tabla.Rows
            monto = FormatNumber(fila.Cells(NombreColumna).Value, 2)
            total += monto
        Next
        Return total
    End Function

    Public Function calcularPrecioProducto(IdProd As String, listaPrecios As Integer, tipofact As Integer) As Double
        Try
            Dim ganancia As Double

            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT precio, ganancia, iva, moneda,utilidad1,utilidad2,utilidad3,utilidad4, utilidad5 FROM fact_insumos where id=" & IdProd, conexionPrinc)
            Dim tablaprod As New DataTable
            Dim filasProd() As DataRow
            consulta.Fill(tablaprod)
            filasProd = tablaprod.Select("")

            'cargamos listas de precios
            Dim consultalis As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,nombre,format(utilidad,2,'es_AR'),auxcol FROM fact_listas_precio where id=" & listaPrecios, conexionPrinc)
            Dim tablalistas As New DataTable
            Dim filaslistas() As DataRow
            consultalis.Fill(tablalistas)
            filaslistas = tablalistas.Select("")

            'cargamos la moneda perteneciente a este producto
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "Select (Select cotizacion from fact_moneda  where  id =" & filasProd(0)(3) & ") As cotiza, (Select valor from fact_configuraciones where  id =1) As lista"
            sql.CommandType = CommandType.Text
            'MsgBox(sql.CommandText)
            lector = sql.ExecuteReader
            lector.Read()
            Dim cotizacion As Double = FormatNumber(lector("cotiza").ToString)
            Dim precioCosto As Double = FormatNumber(filasProd(0)(0))
            Dim iva As Double = (FormatNumber(filasProd(0)(2)) + 100) / 100
            Dim listaTXT As String = filaslistas(0)(2)
            Dim lista As Double
            Dim utilidad As Double
            Dim codaux As Integer = filaslistas(0)(3)

            Dim utilSum As Double = FormatNumber(filasProd(0)(5))
            Dim listaSum As Double = FormatNumber(filaslistas(0)(2))

            Dim SumaUtil As Double = (utilSum + listaSum + 100) / 100

            Select Case codaux
                Case 0
                    utilidad = (FormatNumber(filasProd(0)(1)) + 100) / 100
                Case 1
                    utilidad = (FormatNumber(filasProd(0)(4)) + 100) / 100
                Case 2
                    utilidad = (FormatNumber(filasProd(0)(5)) + 100) / 100
                Case 3
                    utilidad = (FormatNumber(filasProd(0)(6)) + 100) / 100
                Case 4
                    utilidad = (FormatNumber(filasProd(0)(7)) + 100) / 100
                Case 5
                    utilidad = (FormatNumber(filasProd(0)(8)) + 100) / 100
            End Select

            Dim PrecioSinIva As Double
            Dim PrecioVenta As Double

            If InStr(listaTXT, "%") <> 0 Then
                lista = (FormatNumber(listaTXT.Replace("%", "") + 100) / 100)
                PrecioSinIva = precioCosto * cotizacion * lista
                PrecioVenta = PrecioSinIva * iva
            Else
                lista = (FormatNumber(filaslistas(0)(2) + 100) / 100)
                If My.Settings.metodoCalculo = 1 Then
                    PrecioSinIva = precioCosto * cotizacion * lista * utilidad
                    PrecioVenta = PrecioSinIva * iva
                Else
                    PrecioSinIva = precioCosto * cotizacion * ((lista + utilidad) - 1)
                    PrecioVenta = PrecioSinIva * iva
                End If

            End If

            Select Case tipofact
                Case 999, 991, 992, 995, 0
                    Return Math.Round(PrecioVenta, 2)
                Case 6, 8, 11
                    Return Math.Round(PrecioVenta, 2)
                Case Else
                    Return Math.Round(PrecioSinIva, 2)
            End Select
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Sub ImprimirTiketVenta(ByVal sender As System.Object, ByVal e As PrintPageEventArgs)
        ' letra
        'Dim font1 As New Font("EAN-13", 40)
        Dim printfont As New Font("Courier New", 6)
        Dim font3 As New Font("Courier New", 8)
        Dim font4 As New Font("Courier New", 18)
        Dim font5 As New Font("Courier New", 6)
        Dim fontCAE As New Font("Courier New", 5.3, FontStyle.Italic)

        Dim alto As Single = 0
        Dim topMargin As Double '= e.MarginBounds.Top
        Dim yPos As Double = 0
        Dim count As Integer = 0
        Dim texto As String = ""

        Dim codigo As String = ""
        Dim unidad As String = ""
        Dim detalle As String = ""
        Dim valoruni As String = ""
        Dim valortot As String = ""
        Dim tabulacion As String = ""
        Dim compensador As Integer = 0
        Dim total As String = ""
        Dim lvalor As String
        Dim lineatotal As String
        Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ivaProd As String = ""
        Dim fac As New datosfacturas

        Dim facTotal As String = ""
        Dim facSubtotal As String = ""
        Dim FacIva21 As String = ""
        Dim FacIva105 As String = ""

        Dim facCAE As String = ""
        Dim facVtoCAE As String = ""
        Dim facCodBARRA As String = ""



        Reconectar()

        tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
        emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
        emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, 
        concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.f_alta as facfech,
        concat(fac.id_cliente,'-',fac.razon) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, 
        concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21,
        '','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra, format(fac.total,2,'es_AR'),format(fac.subtotal,2,'es_AR')   
        FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac,fact_condventas as condvent  
        where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and condvent.id=fac.condvta and fac.ptovta=fis.ptovta and fac.id=" & idFactura, conexionPrinc)

        Dim tablaEmpresa As New DataTable
        tabEmp.Fill(tablaEmpresa)

        Reconectar()

        tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal 
            from fact_items where id_fact=" & idFactura, conexionPrinc)
        Dim tablaProd As New DataTable
        tabFac.Fill(tablaProd)

        facTotal = tablaEmpresa.Rows(0).Item(30)
        facSubtotal = tablaEmpresa.Rows(0).Item(31)
        FacIva21 = tablaEmpresa.Rows(0).Item(21)
        FacIva105 = ""

        facCAE = tablaEmpresa.Rows(0).Item(25)
        facCodBARRA = tablaEmpresa.Rows(0).Item(29)
        facVtoCAE = tablaEmpresa.Rows(0).Item(28)


        e.Graphics.DrawImage(Image.FromFile(Application.StartupPath & "\logo2.jpg"), 5, 15)
        'fac.Tables("factura_enca")["empnombre"].tostring()

        e.Graphics.DrawString("Razón social: " & tablaEmpresa.Rows(0).Item(0), font5, Brushes.Black, 0, 100) 'RAZON SOCIAL
        e.Graphics.DrawString("Tiket N°: " & tablaEmpresa.Rows(0).Item(10), font5, Brushes.Black, 0, 110) '
        e.Graphics.DrawString("Fecha: " & tablaEmpresa.Rows(0).Item(11).ToString, font5, Brushes.Black, 0, 120) '
        e.Graphics.DrawString("Ciente: " & tablaEmpresa.Rows(0).Item(12), font5, Brushes.Black, 0, 130) '
        e.Graphics.DrawString("#Articulos:" & tablaProd.Rows.Count, font5, Brushes.Black, 0, 140) '
        e.Graphics.DrawString(StrDup(65, "#"), font5, Brushes.Black, 0, 150)
        e.Graphics.DrawString("### TIKET NO VALIDO COMO FACTURA ###", font5, Brushes.Black, 0, 160)
        e.Graphics.DrawString(StrDup(65, "#"), font5, Brushes.Black, 0, 170)
        'e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 180)
        'e.Graphics.DrawString("CODIGO      |    CANT    | PRE. UNI | PRE. TOTAL ", font5, Brushes.Black, 0, 190)
        'e.Graphics.DrawString("DESCRIPCION", font5, Brushes.Black, 0, 200)
        'e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 210)

        Dim i As Integer
        Dim j As Integer
        Dim car As Integer

        For i = 0 To tablaProd.Rows.Count - 1
            codigo = tablaProd.Rows(i).Item(0)
            unidad = tablaProd(i).Item(1)
            detalle = tablaProd(i).Item(2)
            valoruni = tablaProd(i).Item(4)
            valortot = FormatNumber(tablaProd(i).Item(5), 2)
            ivaProd = tablaProd(i).Item(3)
            texto = unidad & " x " & valoruni & Chr(9) & "  (" & ivaProd & ")"
            yPos = 190 + topMargin + (count * printfont.GetHeight(e.Graphics)) ' Calcula la posición en la que se escribe la línea            


            If detalle.Length <= 25 Then
                car = 25 - detalle.Length
                For j = 0 To car
                    detalle &= " "
                Next
            Else
                car = detalle.Length - 25
                detalle = detalle.Remove(26, car - 1)
            End If

            If valortot.Length <= 7 Then
                car = 7 - valortot.Length
                For j = 0 To car
                    valortot = " " & valortot
                Next

            End If


            'If Not row.IsNewRow Then
            e.Graphics.DrawString(texto, printfont, System.Drawing.Brushes.Black, 0, yPos)
            count += 1
            yPos = yPos + 10
            e.Graphics.DrawString(detalle & "  " & valortot, printfont, System.Drawing.Brushes.Black, 0, yPos)
            'total += valor
            'End If

            count += 1

        Next

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




        yPos += 20
        Dim textosub As String = "Subtotal"
        Dim textoIva21 As String = "Alicuota 21%"
        Dim textoTotal As String = "Total"



        Dim lineaSep = StrDup(27, " ")
        e.Graphics.DrawString(lineaSep & "__________", printfont, System.Drawing.Brushes.Black, 0, yPos)
        Dim XXX As Integer = 0

        XXX = 27 - (textosub.Length + facSubtotal.Length)
        lineatotal = StrDup(XXX, ".")
        yPos += 10
        e.Graphics.DrawString(textosub & lineatotal & facSubtotal, font3, System.Drawing.Brushes.Black, 0, yPos)

        XXX = 27 - (textoIva21.Length + FacIva21.Length)
        lineatotal = StrDup(XXX, ".")
        yPos += 10
        e.Graphics.DrawString(textoIva21 & lineatotal & FacIva21, font3, System.Drawing.Brushes.Black, 0, yPos)

        XXX = 27 - (textoTotal.Length + facTotal.Length)
        lineatotal = StrDup(XXX, ".")
        yPos += 10
        e.Graphics.DrawString(textoTotal & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)
        yPos += 30

        e.Graphics.DrawString("Gracias por tu compra!!!", font3, System.Drawing.Brushes.Black, 15, yPos)



    End Sub
    Private Sub ImprimirTiketFiscal(ByVal sender As System.Object, ByVal e As PrintPageEventArgs)
        ' letra
        'Dim font1 As New Font("EAN-13", 40)
        Dim anchoTiket As Integer = My.Settings.TipoEtiqueta
        If anchoTiket = 0 Or anchoTiket = 1 Or anchoTiket = 2 Then

            Dim printfont As New Font("Courier New", 6)
            Dim font3 As New Font("Courier New", 8)
            Dim font4 As New Font("Courier New", 18)
            Dim font5 As New Font("Courier New", 6)
            Dim fontCAE As New Font("Courier New", 5.3, FontStyle.Italic)

            Dim alto As Single = 0
            Dim topMargin As Double '= e.MarginBounds.Top
            Dim yPos As Integer = 0
            Dim count As Integer = 0
            Dim texto As String = ""

            Dim codigo As String = ""
            Dim unidad As String = ""
            Dim detalle As String = ""
            Dim valoruni As String = ""
            Dim valortot As String = ""
            Dim tabulacion As String = ""
            Dim compensador As Integer = 0
            Dim total As String = ""
            Dim lvalor As String
            Dim lineatotal As String
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ivaProd As String = ""
            Dim fac As New datosfacturas

            Dim facTotal As String = ""
            Dim facSubtotal As String = ""
            Dim FacIva21 As String = ""
            Dim FacIva105 As String = ""

            Dim facCAE As String = ""
            Dim facVtoCAE As String = ""
            Dim facCodBARRA As String = ""



            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
            emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
            emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, 
            concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.f_alta as facfech, 
            concat(fac.id_cliente,'-',fac.razon) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, 
            concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21,
            '','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra, format(fac.total,2,'es_AR'),format(fac.subtotal,2,'es_AR'),fac.codigo_qr   
            FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac,fact_condventas as condvent  
            where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and condvent.id=fac.condvta and fac.ptovta=fis.ptovta and fac.id=" & idFactura, conexionPrinc)

            Dim tablaEmpresa As New DataTable
            tabEmp.Fill(tablaEmpresa)

            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal 
            from fact_items where id_fact=" & idFactura, conexionPrinc)
            Dim tablaProd As New DataTable
            tabFac.Fill(tablaProd)

            facTotal = tablaEmpresa.Rows(0).Item(30)
            facSubtotal = tablaEmpresa.Rows(0).Item(31)
            FacIva21 = tablaEmpresa.Rows(0).Item(21)
            FacIva105 = ""

            facCAE = tablaEmpresa.Rows(0).Item(25)
            facCodBARRA = tablaEmpresa.Rows(0).Item(29)
            facVtoCAE = tablaEmpresa.Rows(0).Item(28)
            Dim TipoFact As Integer = tablaEmpresa.Rows(0).Item(24)

            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(1), font5, Brushes.Black, 0, 100) 'RAZON SOCIAL
            e.Graphics.DrawString("CUIT Nro: " & tablaEmpresa.Rows(0).Item(4), font5, Brushes.Black, 0, 110) '
            e.Graphics.DrawString("Ing. Brutos: " & tablaEmpresa.Rows(0).Item(5).ToString, font5, Brushes.Black, 0, 120) '
            e.Graphics.DrawString("Domicilio: " & tablaEmpresa.Rows(0).Item(2), font5, Brushes.Black, 0, 130)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(3), font5, Brushes.Black, 0, 140) '
            e.Graphics.DrawString("Inicio de actividades: " & tablaEmpresa.Rows(0).Item(7), font5, Brushes.Black, 0, 150)
            e.Graphics.DrawString("IVA " & tablaEmpresa.Rows(0).Item(6), font5, Brushes.Black, 0, 160)

            e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 170)
            e.Graphics.DrawString("FACTURA '" & tablaEmpresa.Rows(0).Item(26) & "' (" & tablaEmpresa.Rows(0).Item(27) & ")", font5, Brushes.Black, 0, 180)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(10).ToString, font5, Brushes.Black, 0, 190)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(11).ToString, font5, Brushes.Black, 0, 200)
            e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 210)

            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(12), font5, Brushes.Black, 0, 220)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(13), font5, Brushes.Black, 0, 230)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(14), font5, Brushes.Black, 0, 240)
            e.Graphics.DrawString("CUIT Nro: " & tablaEmpresa.Rows(0).Item(16), font5, Brushes.Black, 0, 250)
            e.Graphics.DrawString("IVA " & tablaEmpresa.Rows(0).Item(15), font5, Brushes.Black, 0, 260)
            e.Graphics.DrawString("CONDICION DE VENTA " & tablaEmpresa.Rows(0).Item(18), font5, Brushes.Black, 0, 270)
            e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 280)

            Dim codigoQRBOX As New PictureBox
            codigoQRBOX.SizeMode = PictureBoxSizeMode.StretchImage
            codigoQRBOX.Width = 100
            codigoQRBOX.Height = 100
            codigoQRBOX.Image = Bytes_Imagen(tablaEmpresa.Rows(0).Item(32))


            Dim i As Integer
            Dim j As Integer
            Dim car As Integer

            For i = 0 To tablaProd.Rows.Count - 1
                codigo = tablaProd.Rows(i).Item(0)
                unidad = tablaProd(i).Item(1)
                detalle = tablaProd(i).Item(2)
                valoruni = tablaProd(i).Item(4)
                valortot = FormatNumber(tablaProd(i).Item(5), 2)
                ivaProd = tablaProd(i).Item(3)
                texto = unidad & " x " & valoruni & Chr(9) & "  (" & ivaProd & ")"
                yPos = 290 + topMargin + (count * printfont.GetHeight(e.Graphics)) ' Calcula la posición en la que se escribe la línea            


                If detalle.Length <= 25 Then
                    car = 25 - detalle.Length
                    For j = 0 To car
                        detalle &= " "
                    Next
                Else
                    car = detalle.Length - 25
                    detalle = detalle.Remove(26, car - 1)
                End If

                If valortot.Length <= 7 Then
                    car = 7 - valortot.Length
                    For j = 0 To car
                        valortot = " " & valortot
                    Next

                End If


                'If Not row.IsNewRow Then
                e.Graphics.DrawString(texto, printfont, System.Drawing.Brushes.Black, 0, yPos)
                count += 1
                yPos = yPos + 10
                e.Graphics.DrawString(detalle & "  " & valortot, printfont, System.Drawing.Brushes.Black, 0, yPos)
                'total += valor
                'End If
                count += 1

            Next
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

            yPos += 20
            Dim textosub As String = "Subtotal"
            Dim textoIva21 As String = "Alicuota 21%"
            Dim textoTotal As String = "Total"



            Dim lineaSep = StrDup(27, " ")
            e.Graphics.DrawString(lineaSep & "__________", printfont, System.Drawing.Brushes.Black, 0, yPos)
            Dim XXX As Integer = 0
            If TipoFact <= 3 Then

                XXX = 27 - (textosub.Length + facSubtotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 10
                e.Graphics.DrawString(textosub & lineatotal & facSubtotal, font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 27 - (textoIva21.Length + FacIva21.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 10
                e.Graphics.DrawString(textoIva21 & lineatotal & FacIva21, font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 27 - (textoTotal.Length + facTotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 10
                e.Graphics.DrawString(textoTotal & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)
                yPos += 30

            Else
                XXX = 27 - (textosub.Length + facTotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 10
                e.Graphics.DrawString(textosub & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 27 - (textoIva21.Length + 1)
                lineatotal = StrDup(XXX, ".")
                yPos += 10
                e.Graphics.DrawString(textoIva21 & lineatotal & "0", font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 27 - (textoTotal.Length + facTotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 10
                e.Graphics.DrawString(textoTotal & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)
                yPos += 30
            End If



            e.Graphics.DrawString("COMPROBANTE AUTORIZADO POR WEB SERVICE", fontCAE, System.Drawing.Brushes.Black, 0, yPos)
            yPos += 10

            e.Graphics.DrawString("CAE: " & facCAE, fontCAE, System.Drawing.Brushes.Black, 0, yPos)
            yPos += 10

            e.Graphics.DrawString("F. Vto CAE: " & facVtoCAE, fontCAE, System.Drawing.Brushes.Black, 0, yPos)
            yPos += 10
            Dim bm_source As New Bitmap(codigoQRBOX.Image)
            Dim bm_dest As New Bitmap(190, 190)
            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
            gr_dest.DrawImage(bm_source, 0, 0,
            bm_dest.Width + 1,
            bm_dest.Height + 1)
            codigoQRBOX.Image = bm_dest

            e.Graphics.DrawImage(codigoQRBOX.Image, 0, yPos)
            yPos += 190

            e.Graphics.DrawString(My.Settings.TextoPieTiket, font3, System.Drawing.Brushes.Black, 15, yPos)
            yPos += 10
            e.Graphics.DrawString("Gracias por tu compra!!!", font3, System.Drawing.Brushes.Black, 15, yPos)

        ElseIf anchoTiket = 3 Then

            Dim printfont As New Font("Courier New", 8)
            Dim font3 As New Font("Courier New", 10)
            Dim font4 As New Font("Courier New", 18)
            Dim font5 As New Font("Courier New", 8)
            Dim fontCAE As New Font("Courier New", 6, FontStyle.Italic)

            Dim alto As Single = 0
            Dim topMargin As Double '= e.MarginBounds.Top
            Dim yPos As Integer = 0
            Dim count As Integer = 0
            Dim texto As String = ""

            Dim codigo As String = ""
            Dim unidad As String = ""
            Dim detalle As String = ""
            Dim valoruni As String = ""
            Dim valorImpuestos As String = ""
            Dim valorTotal As String = ""

            Dim valortot As String = ""
            Dim tabulacion As String = ""
            Dim compensador As Integer = 0
            Dim total As String = ""
            Dim lvalor As String
            Dim lineatotal As String
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ivaProd As String = ""
            Dim fac As New datosfacturas

            Dim facTotal As String = ""
            Dim facSubtotal As String = ""
            Dim FacIva21 As String = ""
            Dim FacIva105 As String = ""

            Dim FacNoGravado As String = ""
            Dim FacIDC As String = ""
            Dim FacICL As String = ""

            Dim facCAE As String = ""
            Dim facVtoCAE As String = ""
            Dim facCodBARRA As String = ""



            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
            emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
            emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, 
            concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.f_alta as facfech, 
            concat(fac.id_cliente,'-',fac.razon) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, 
            concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21,
            '','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra, format(fac.total,2,'es_AR'),format(fac.subtotal,2,'es_AR'), fac.codigo_qr, format(fac.otroiva,2,'es_AR') as noGravado
            FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac,fact_condventas as condvent  
            where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and condvent.id=fac.condvta and fac.ptovta=fis.ptovta and fac.id=" & idFactura, conexionPrinc)

            Dim tablaEmpresa As New DataTable
            tabEmp.Fill(tablaEmpresa)

            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(impuestoFijo01,',','.'),2,'es_AR') as idc,
            format(replace(impuestoFijo02,',','.'),2,'es_AR') as icl,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal 
            from fact_items where id_fact=" & idFactura, conexionPrinc)
            Dim tablaProd As New DataTable
            tabFac.Fill(tablaProd)

            facTotal = tablaEmpresa.Rows(0).Item(30)
            facSubtotal = tablaEmpresa.Rows(0).Item(31)
            FacIva21 = tablaEmpresa.Rows(0).Item(21)

            FacIva105 = ""
            FacIDC = tablaProd.Rows(0).Item("idc")
            FacICL = tablaProd.Rows(0).Item("icl")
            FacNoGravado = CDbl(FacIDC) + CDbl(FacICL)


            facCAE = tablaEmpresa.Rows(0).Item(25)
            facCodBARRA = tablaEmpresa.Rows(0).Item(29)
            facVtoCAE = tablaEmpresa.Rows(0).Item(28)
            Dim TipoFact As Integer = tablaEmpresa.Rows(0).Item(24)

            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(1), font5, Brushes.Black, 0, 100) 'RAZON SOCIAL
            e.Graphics.DrawString("CUIT Nro: " & tablaEmpresa.Rows(0).Item(4), font5, Brushes.Black, 0, 110) '
            e.Graphics.DrawString("Ing. Brutos: " & tablaEmpresa.Rows(0).Item(5).ToString, font5, Brushes.Black, 0, 120) '
            e.Graphics.DrawString("Domicilio: " & tablaEmpresa.Rows(0).Item(2), font5, Brushes.Black, 0, 130)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(3), font5, Brushes.Black, 0, 140) '
            e.Graphics.DrawString("Inicio de actividades: " & tablaEmpresa.Rows(0).Item(7), font5, Brushes.Black, 0, 150)
            e.Graphics.DrawString("IVA " & tablaEmpresa.Rows(0).Item(6), font5, Brushes.Black, 0, 160)

            e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 170)
            e.Graphics.DrawString("FACTURA '" & tablaEmpresa.Rows(0).Item(26) & "' (" & tablaEmpresa.Rows(0).Item(27) & ")", font5, Brushes.Black, 0, 180)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(10).ToString, font5, Brushes.Black, 0, 190)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(11).ToString, font5, Brushes.Black, 0, 200)
            e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 210)

            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(12), font5, Brushes.Black, 0, 220)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(13), font5, Brushes.Black, 0, 230)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(14), font5, Brushes.Black, 0, 240)
            e.Graphics.DrawString("CUIT Nro: " & tablaEmpresa.Rows(0).Item(16), font5, Brushes.Black, 0, 250)
            e.Graphics.DrawString("IVA " & tablaEmpresa.Rows(0).Item(15), font5, Brushes.Black, 0, 260)
            e.Graphics.DrawString("CONDICION DE VENTA " & tablaEmpresa.Rows(0).Item(18), font5, Brushes.Black, 0, 270)
            e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 280)

            Dim codigoQRBOX As New PictureBox
            '            codigoQRBOX.SizeMode = PictureBoxSizeMode
            'codigoQRBOX.Width = 100
            'codigoQRBOX.Height = 100
            codigoQRBOX.Image = Bytes_Imagen(tablaEmpresa.Rows(0).Item(32))


            Dim i As Integer
            Dim j As Integer
            Dim car As Integer

            For i = 0 To tablaProd.Rows.Count - 1
                codigo = tablaProd.Rows(i).Item("plu")
                unidad = tablaProd(i).Item("cant")
                detalle = tablaProd(i).Item("descripcion")
                valoruni = tablaProd(i).Item("punit")
                valorImpuestos = FacNoGravado

                If TipoFact <= 3 Then
                    valortot = FormatNumber(tablaProd(i).Item("ptotal"), 2)

                    'valortot = CDbl(valortot) + CDbl(valorImpuestos)
                    'valortot = FormatNumber(valortot, 2)
                Else
                    valortot = FormatNumber(tablaProd(i).Item("ptotal"), 2)
                    valortot = CDbl(valortot) + CDbl(valorImpuestos)
                    valortot = FormatNumber(valortot, 2)
                End If

                ivaProd = tablaProd(i).Item("iva")
                texto = unidad & " x " & valoruni & Chr(9) & "  (" & ivaProd & ")"
                yPos = 290 + topMargin + (count * printfont.GetHeight(e.Graphics)) ' Calcula la posición en la que se escribe la línea            


                If detalle.Length <= 25 Then
                    car = 25 - detalle.Length
                    For j = 0 To car
                        detalle &= " "
                    Next
                Else
                    car = detalle.Length - 25
                    detalle = detalle.Remove(26, car - 1)
                End If

                If valortot.Length <= 11 Then
                    car = 11 - valortot.Length
                    For j = 0 To car
                        valortot = " " & valortot
                    Next

                End If

                'MsgBox(valortot & "   " & valorImpuestos & "=" & CDbl(valortot) + CDbl(valorImpuestos))
                'If Not row.IsNewRow Then
                e.Graphics.DrawString(texto, printfont, System.Drawing.Brushes.Black, 0, yPos)
                count += 1
                yPos = yPos + 10
                e.Graphics.DrawString(detalle & "  " & valortot, printfont, System.Drawing.Brushes.Black, 0, yPos)
                'total += valor
                'End If
                count += 1

            Next
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

            yPos += 20
            Dim textosub As String = "Neto Gravado"
            Dim textoIva21 As String = "IVA"
            Dim textoNoGravado As String = "Otros Tributos:"
            Dim textoIDC As String = "I.D.C."
            Dim textoICL As String = "I.C.L."
            Dim textoTotal As String = "Total"



            Dim lineaSep = StrDup(32, " ")
            e.Graphics.DrawString(lineaSep & "_______________", printfont, System.Drawing.Brushes.Black, 0, yPos)
            Dim XXX As Integer = 0
            If TipoFact <= 3 Then

                XXX = 32 - (textosub.Length + facSubtotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                e.Graphics.DrawString(textosub & lineatotal & facSubtotal, font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 32 - (textoIva21.Length + FacIva21.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                e.Graphics.DrawString(textoIva21 & lineatotal & FacIva21, font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 32 - (textoNoGravado.Length + FacNoGravado.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                e.Graphics.DrawString(textoNoGravado & lineatotal & FacNoGravado, font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 32 - (textoTotal.Length + facTotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                e.Graphics.DrawString(textoTotal & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)
                yPos += 40
                e.Graphics.DrawString(textoIDC & " $" & FacIDC & "|" & textoICL & " $" & FacICL, fontCAE, System.Drawing.Brushes.Black, 0, yPos)
                yPos += 40
            Else
                XXX = 32 - (textosub.Length + facTotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                e.Graphics.DrawString(textosub & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)

                'XXX = 32 - (textoIva21.Length + 1)
                'lineatotal = StrDup(XXX, ".")
                'yPos += 12
                'e.Graphics.DrawString(textoIva21 & lineatotal & "0", font3, System.Drawing.Brushes.Black, 0, yPos)
                ''MsgBox(facTotal)

                'XXX = 32 - (textoNoGravado.Length + FacNoGravado.Length)
                'lineatotal = StrDup(XXX, ".")
                'yPos += 12
                'e.Graphics.DrawString(textoNoGravado & lineatotal & FacNoGravado, font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 32 - (textoTotal.Length + facTotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                e.Graphics.DrawString(textoTotal & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)
                yPos += 40
                'e.Graphics.DrawString(textoIDC & " $" & FacIDC & "|" & textoICL & " $" & FacICL, fontCAE, System.Drawing.Brushes.Black, 0, yPos)
                'yPos += 40
            End If



            e.Graphics.DrawString("COMPROBANTE AUTORIZADO POR WEB SERVICE", fontCAE, System.Drawing.Brushes.Black, 0, yPos)
            yPos += 10

            e.Graphics.DrawString("CAE: " & facCAE, fontCAE, System.Drawing.Brushes.Black, 0, yPos)
            yPos += 10

            e.Graphics.DrawString("F. Vto CAE: " & facVtoCAE, fontCAE, System.Drawing.Brushes.Black, 0, yPos)
            yPos += 10

            Dim bm_source As New Bitmap(codigoQRBOX.Image, 150, 150)
            bm_source.SetResolution(100.0F, 100.0F)
            'Dim bm_dest As New Bitmap(100, 100)
            'bm_dest.SetResolution(100.0F, 100.0F)
            'Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
            'gr_dest.DrawImage(bm_source, 0, 0,
            'bm_dest.Width + 1,
            'bm_dest.Height + 1)
            'codigoQRBOX.Image = bm_dest

            e.Graphics.DrawImage(bm_source, 0, yPos)
            yPos += 190

            e.Graphics.DrawString(My.Settings.TextoPieTiket, font3, System.Drawing.Brushes.Black, 20, yPos)
            yPos += 10
            e.Graphics.DrawString("Gracias por tu compra!!!", font3, System.Drawing.Brushes.Black, 20, yPos)
        ElseIf anchoTiket = 4 Then

            Dim printfont As New Font("Courier New", 8)
            Dim font3 As New Font("Courier New", 10)
            Dim font4 As New Font("Courier New", 18)
            Dim font5 As New Font("Courier New", 8)
            Dim fontCAE As New Font("Courier New", 6, FontStyle.Italic)

            Dim alto As Single = 0
            Dim topMargin As Double '= e.MarginBounds.Top
            Dim yPos As Integer = 0
            Dim count As Integer = 0
            Dim texto As String = ""

            Dim codigo As String = ""
            Dim unidad As String = ""
            Dim detalle As String = ""
            Dim valoruni As String = ""
            Dim valorImpuestos As String = ""


            Dim valortot As String = ""
            Dim tabulacion As String = ""
            Dim compensador As Integer = 0
            Dim total As String = ""
            Dim lvalor As String
            Dim lineatotal As String
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ivaProd As String = ""
            Dim fac As New datosfacturas

            Dim facTotal As String = ""
            Dim facSubtotal As String = ""
            Dim FacIva21 As String = ""
            Dim FacIva105 As String = ""

            'Dim FacNoGravado As String = ""
            'Dim FacIDC As String = ""
            'Dim FacICL As String = ""

            Dim facCAE As String = ""
            Dim facVtoCAE As String = ""
            Dim facCodBARRA As String = ""



            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
            emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
            emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, 
            concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.f_alta as facfech, 
            concat(fac.id_cliente,'-',fac.razon) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, 
            concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21,
            '','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra, format(fac.total,2,'es_AR'),format(fac.subtotal,2,'es_AR'), fac.codigo_qr, format(fac.otroiva,2,'es_AR') as noGravado
            FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac,fact_condventas as condvent  
            where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and condvent.id=fac.condvta and fac.ptovta=fis.ptovta and fac.id=" & idFactura, conexionPrinc)

            Dim tablaEmpresa As New DataTable
            tabEmp.Fill(tablaEmpresa)

            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(impuestoFijo01,',','.'),2,'es_AR') as idc,
            format(replace(impuestoFijo02,',','.'),2,'es_AR') as icl,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal 
            from fact_items where id_fact=" & idFactura, conexionPrinc)
            Dim tablaProd As New DataTable
            tabFac.Fill(tablaProd)

            facTotal = tablaEmpresa.Rows(0).Item(30)
            facSubtotal = tablaEmpresa.Rows(0).Item(31)
            FacIva21 = tablaEmpresa.Rows(0).Item(21)

            FacIva105 = tablaEmpresa.Rows(0).Item(20)
            'FacIDC = tablaProd.Rows(0).Item("idc")
            'FacICL = tablaProd.Rows(0).Item("icl")
            'FacNoGravado = CDbl(FacIDC) + CDbl(FacICL)


            facCAE = tablaEmpresa.Rows(0).Item(25)
            facCodBARRA = tablaEmpresa.Rows(0).Item(29)
            facVtoCAE = tablaEmpresa.Rows(0).Item(28)
            Dim TipoFact As Integer = tablaEmpresa.Rows(0).Item(24)

            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(1), font5, Brushes.Black, 0, 100) 'RAZON SOCIAL
            e.Graphics.DrawString("CUIT Nro: " & tablaEmpresa.Rows(0).Item(4), font5, Brushes.Black, 0, 110) '
            e.Graphics.DrawString("Ing. Brutos: " & tablaEmpresa.Rows(0).Item(5).ToString, font5, Brushes.Black, 0, 120) '
            e.Graphics.DrawString("Domicilio: " & tablaEmpresa.Rows(0).Item(2), font5, Brushes.Black, 0, 130)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(3), font5, Brushes.Black, 0, 140) '
            e.Graphics.DrawString("Inicio de actividades: " & tablaEmpresa.Rows(0).Item(7), font5, Brushes.Black, 0, 150)
            e.Graphics.DrawString("IVA " & tablaEmpresa.Rows(0).Item(6), font5, Brushes.Black, 0, 160)

            e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 170)
            e.Graphics.DrawString("FACTURA '" & tablaEmpresa.Rows(0).Item(26) & "' (" & tablaEmpresa.Rows(0).Item(27) & ")", font5, Brushes.Black, 0, 180)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(10).ToString, font5, Brushes.Black, 0, 190)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(11).ToString, font5, Brushes.Black, 0, 200)
            e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 210)

            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(12), font5, Brushes.Black, 0, 220)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(13), font5, Brushes.Black, 0, 230)
            e.Graphics.DrawString(tablaEmpresa.Rows(0).Item(14), font5, Brushes.Black, 0, 240)
            e.Graphics.DrawString("CUIT Nro: " & tablaEmpresa.Rows(0).Item(16), font5, Brushes.Black, 0, 250)
            e.Graphics.DrawString("IVA " & tablaEmpresa.Rows(0).Item(15), font5, Brushes.Black, 0, 260)
            e.Graphics.DrawString("CONDICION DE VENTA " & tablaEmpresa.Rows(0).Item(18), font5, Brushes.Black, 0, 270)
            e.Graphics.DrawString(StrDup(65, "*"), font5, Brushes.Black, 0, 280)

            Dim codigoQRBOX As New PictureBox
            '            codigoQRBOX.SizeMode = PictureBoxSizeMode
            'codigoQRBOX.Width = 100
            'codigoQRBOX.Height = 100
            codigoQRBOX.Image = Bytes_Imagen(tablaEmpresa.Rows(0).Item(32))


            Dim i As Integer
            Dim j As Integer
            Dim car As Integer

            For i = 0 To tablaProd.Rows.Count - 1
                codigo = tablaProd.Rows(i).Item("plu")
                unidad = tablaProd(i).Item("cant")
                detalle = tablaProd(i).Item("descripcion")
                valoruni = tablaProd(i).Item("punit")
                'valorImpuestos = FacNoGravado
                If TipoFact <= 3 Then
                    valortot = FormatNumber(tablaProd(i).Item("ptotal"), 2)

                    'valortot = CDbl(valortot) + CDbl(valorImpuestos)
                    'valortot = FormatNumber(valortot, 2)
                Else
                    valortot = FormatNumber(tablaProd(i).Item("ptotal"), 2)
                    valortot = CDbl(valortot) + CDbl(valorImpuestos)
                    valortot = FormatNumber(valortot, 2)
                End If

                ivaProd = tablaProd(i).Item("iva")
                texto = unidad & " x " & valoruni & Chr(9) & "  (" & ivaProd & ")"
                yPos = 290 + topMargin + (count * printfont.GetHeight(e.Graphics)) ' Calcula la posición en la que se escribe la línea            


                If detalle.Length <= 25 Then
                    car = 25 - detalle.Length
                    For j = 0 To car
                        detalle &= " "
                    Next
                Else
                    car = detalle.Length - 25
                    detalle = detalle.Remove(26, car - 1)
                End If

                If valortot.Length <= 11 Then
                    car = 11 - valortot.Length
                    For j = 0 To car
                        valortot = " " & valortot
                    Next

                End If

                'MsgBox(valortot & "   " & valorImpuestos & "=" & CDbl(valortot) + CDbl(valorImpuestos))
                'If Not row.IsNewRow Then
                e.Graphics.DrawString(texto, printfont, System.Drawing.Brushes.Black, 0, yPos)
                count += 1
                yPos = yPos + 10
                e.Graphics.DrawString(detalle & "  " & valortot, printfont, System.Drawing.Brushes.Black, 0, yPos)
                'total += valor
                'End If
                count += 1

            Next
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

            yPos += 20
            Dim textosub As String = "Neto Gravado"
            Dim textoIva21 As String = "IVA"
            'Dim textoNoGravado As String = "Otros Tributos:"
            ' Dim textoIDC As String = "I.D.C."
            'Dim textoICL As String = "I.C.L."
            Dim textoTotal As String = "Total"



            Dim lineaSep = StrDup(32, " ")
            e.Graphics.DrawString(lineaSep & "_______________", printfont, System.Drawing.Brushes.Black, 0, yPos)
            Dim XXX As Integer = 0
            If TipoFact <= 3 Then

                XXX = 32 - (textosub.Length + facSubtotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                e.Graphics.DrawString(textosub & lineatotal & facSubtotal, font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 32 - (textoIva21.Length + FacIva21.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                e.Graphics.DrawString(textoIva21 & lineatotal & FacIva21, font3, System.Drawing.Brushes.Black, 0, yPos)

                '  XXX = 32 - (textoNoGravado.Length + FacNoGravado.Length)
                ' lineatotal = StrDup(XXX, ".")
                ' yPos += 12
                'e.Graphics.DrawString(textoNoGravado & lineatotal & FacNoGravado, font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 32 - (textoTotal.Length + facTotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                ' e.Graphics.DrawString(textoTotal & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)
                'yPos += 40
                'e.Graphics.DrawString(textoIDC & " $" & FacIDC & "|" & textoICL & " $" & FacICL, fontCAE, System.Drawing.Brushes.Black, 0, yPos)
                'yPos += 40
            Else
                XXX = 32 - (textosub.Length + facTotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                e.Graphics.DrawString(textosub & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)

                'XXX = 32 - (textoIva21.Length + 1)
                'lineatotal = StrDup(XXX, ".")
                'yPos += 12
                'e.Graphics.DrawString(textoIva21 & lineatotal & "0", font3, System.Drawing.Brushes.Black, 0, yPos)
                ''MsgBox(facTotal)

                'XXX = 32 - (textoNoGravado.Length + FacNoGravado.Length)
                'lineatotal = StrDup(XXX, ".")
                'yPos += 12
                'e.Graphics.DrawString(textoNoGravado & lineatotal & FacNoGravado, font3, System.Drawing.Brushes.Black, 0, yPos)

                XXX = 32 - (textoTotal.Length + facTotal.Length)
                lineatotal = StrDup(XXX, ".")
                yPos += 12
                e.Graphics.DrawString(textoTotal & lineatotal & facTotal, font3, System.Drawing.Brushes.Black, 0, yPos)
                yPos += 40
                'e.Graphics.DrawString(textoIDC & " $" & FacIDC & "|" & textoICL & " $" & FacICL, fontCAE, System.Drawing.Brushes.Black, 0, yPos)
                'yPos += 40
            End If



            e.Graphics.DrawString("COMPROBANTE AUTORIZADO POR WEB SERVICE", fontCAE, System.Drawing.Brushes.Black, 0, yPos)
            yPos += 10

            e.Graphics.DrawString("CAE: " & facCAE, fontCAE, System.Drawing.Brushes.Black, 0, yPos)
            yPos += 10

            e.Graphics.DrawString("F. Vto CAE: " & facVtoCAE, fontCAE, System.Drawing.Brushes.Black, 0, yPos)
            yPos += 10

            Dim bm_source As New Bitmap(codigoQRBOX.Image, 150, 150)
            bm_source.SetResolution(100.0F, 100.0F)
            'Dim bm_dest As New Bitmap(100, 100)
            'bm_dest.SetResolution(100.0F, 100.0F)
            'Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
            'gr_dest.DrawImage(bm_source, 0, 0,
            'bm_dest.Width + 1,
            'bm_dest.Height + 1)
            'codigoQRBOX.Image = bm_dest

            e.Graphics.DrawImage(bm_source, 0, yPos)
            yPos += 190

            e.Graphics.DrawString(My.Settings.TextoPieTiket, font3, System.Drawing.Brushes.Black, 20, yPos)
            yPos += 10
            e.Graphics.DrawString("Gracias por tu compra!!!", font3, System.Drawing.Brushes.Black, 20, yPos)



        End If


    End Sub
    Public Sub ImprimirFactura(idfact As Integer, ptovta As Integer, directo As Boolean)
        Try
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas

            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  
            emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, 
            emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, 
            concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.fecha as facfech, 
            concat(fac.id_cliente,'-',fac.razon) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, 
            concat(vend.apellido,', ',vend.nombre) as facvend, condvent.condicion as faccondvta, fac.observaciones2 as facobserva,format(fac.iva105,2,'es_AR') as iva105, format(fac.iva21,2,'es_AR') as iva21,            
            '','',fis.donfdesc, fac.cae, fis.letra as facletra, fis.codfiscal as faccodigo, fac.vtocae, fac.codbarra, fac.codigo_qr,fac.observaciones as facobserva2,cl.email  
            FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac,fact_condventas as condvent  
            where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and fis.ptovta=fac.ptovta and condvent.id=fac.condvta and fac.id=" & idfact, conexionPrinc)

            tabEmp.Fill(fac.Tables("factura_enca"))
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            plu,
            format(replace(cantidad,',','.'),2,'es_AR') as cant, descripcion, 
            format(replace(iva,',','.'),2,'es_AR') as iva ,
            format(replace(punit,',','.'),2,'es_AR') as punit ,
            format(replace(ptotal,',','.'),2,'es_AR') as ptotal,
            plu as codigo
            from fact_items where id_fact=" & idfact, conexionPrinc)
            tabFac.Fill(fac.Tables("facturax"))

            Dim direccionReport As String
            If ptovta <> FacturaElectro.puntovtaelect Then
                direccionReport = System.Environment.CurrentDirectory & "\reportes\facturax.rdlc"
            Else
                direccionReport = System.Environment.CurrentDirectory & "\reportes\facturaelectro.rdlc"
            End If
            Dim condVta As String = fac.Tables("factura_enca").Rows(0).Item("faccondvta")
            Dim TipoFact As Integer = fac.Tables("factura_enca").Rows(0).Item("donfdesc")
            'MsgBox(condVta & "___" & TipoFact)
            If TipoFact = 996 Then
                ImprimirRecibos(idfact)
                Exit Sub
            End If
            'Dim PtoVta As Integer =
            If My.Settings.ImprTikets = 1 And condVta = "CONTADO" Then
                Dim PrintTxt As New PrintDocument
                Dim pgSize As New PaperSize
                pgSize.RawKind = Printing.PaperKind.Custom
                pgSize.Width = 147 '196.8 '
                idFactura = idfact
                'pgSize.Height = 173.23 '100
                PrintTxt.DefaultPageSettings.PaperSize = pgSize
                ' evento print

                If ptovta <> FacturaElectro.puntovtaelect Then
                    AddHandler PrintTxt.PrintPage, AddressOf ImprimirTiketVenta
                    PrintTxt.PrinterSettings.PrinterName = My.Settings.ImprTiketsNombre
                    PrintTxt.Print()
                Else
                    AddHandler PrintTxt.PrintPage, AddressOf ImprimirTiketFiscal
                    PrintTxt.PrinterSettings.PrinterName = My.Settings.ImprTiketsNombre
                    PrintTxt.Print()
                End If
            ElseIf My.Settings.ImprTikets = 1 And (condVta = "CTACTE" Or condVta = "CTA. CTE.") Then

                If directo = True Then
                    Using Imprimir As New ImprimirDirecto()
                        Imprimir.Run(fac.Tables("factura_enca"), fac.Tables("facturax"), direccionReport)
                    End Using
                Else
                    Dim imprimirx As New imprimirFX
                    With imprimirx
                        .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                        Select Case TipoFact
                            Case 1 To 3, 6 To 8, 11 To 13
                                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturaelectro.rdlc"
                            Case Else
                                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturax.rdlc"
                        End Select
                        .rptfx.LocalReport.DataSources.Clear()
                        .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                        .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("facturax")))
                        .rptfx.DocumentMapCollapsed = True
                        .rptfx.RefreshReport()
                        .Show()

                    End With
                End If
            Else
                Dim imprimirx As New imprimirFX
                With imprimirx
                    .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                    Select Case TipoFact
                        Case 1 To 3, 6 To 8, 11 To 13
                            .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturaelectro.rdlc"

                        Case Else
                            .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\facturax.rdlc"
                    End Select
                    .rptfx.LocalReport.DataSources.Clear()
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                    .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("facturax")))
                    .rptfx.DocumentMapCollapsed = True
                    .rptfx.RefreshReport()
                    .Show()
                End With

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            'EnProgreso.Close()
        End Try

    End Sub
    Public Sub ImprimirRemito(idremito As Integer)
        Try
            Dim idFactura As Integer = idremito
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas

            Reconectar()

            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia as empnombre,emp.razonsocial as emprazon,emp.direccion as empdire, emp.localidad as emploca, " _
            & "emp.cuit as empcuit, emp.ingbrutos as empib, emp.ivatipo as empcontr,emp.inicioact as empinicioact, emp.drei as empdrei,emp.logo as emplogo, " _
            & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum, fac.fecha as facfech, " _
            & "concat(fac.id_cliente,'-',fac.razon,' - tel: ',cl.telefono) as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr,fac.cuit as faccuit, " _
            & "concat(vend.apellido,', ',vend.nombre) as facvend, fac.condvta as faccondvta, fac.observaciones2 as facobserva,fac.iva105, fac.iva21, fac.total,'',fis.donfdesc as descfact " _
            & "FROM fact_vendedor as vend, fact_clientes as cl, fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac  " _
            & "where vend.id=fac.vendedor and cl.idclientes=fac.id_cliente and emp.id=1 and fis.donfdesc=fac.tipofact and fis.ptovta=fac.ptovta and fac.id=" & idFactura, conexionPrinc)

            tabEmp.Fill(fac.Tables("factura_enca"))
            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "cantidad as cant, descripcion, iva ,punit ,ptotal as ptotal, plu as codigo from fact_items where id_fact=" & idFactura, conexionPrinc)
            tabFac.Fill(fac.Tables("facturax"))
            Dim imprimirx As New imprimirFX
            With imprimirx
                .MdiParent = frmprincipal
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\remito.rdlc"
                '.rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\facturax.rdlc"
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
    Public Sub ImprimirRecibos(idRecibo As Integer)
        Try
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabVal As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabtarj As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim totrec As New MySql.Data.MySqlClient.MySqlDataAdapter

            Dim fac As New datosfacturas

            Reconectar()
            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT  " _
            & "emp.nombrefantasia As empnombre, emp.razonsocial As emprazon, emp.direccion As empdire, emp.localidad As emploca, " _
            & "emp.cuit As empcuit, emp.ingbrutos As empib, emp.ivatipo As empcontr, emp.inicioact As empinicioact, emp.drei As empdrei, emp.logo As emplogo, " _
            & "concat(fis.abrev,' ', LPAD(fac.ptovta,4,'0'),'-',lpad(fac.num_fact,8,'0')) as facnum,fac.fecha as facfech,concat(fac.id_cliente,'-',fac.razon) as facrazon, " _
            & "fac.direccion As facdire, fac.localidad As facloca, fac.tipocontr As factipocontr, fac.cuit As faccuit, fac.vendedor As facvend, " _
            & "fac.condvta as faccondvta, fac.iva105, fac.iva21,fac.total,  " _
            & "fac.observaciones as facobserva " _
            & "FROM fact_conffiscal as fis, fact_empresa as emp, fact_facturas as fac where emp.id=1 and fis.donfdesc=fac.tipofact and fac.id=" & idRecibo, conexionPrinc)
            tabEmp.Fill(fac.Tables("factura_enca"))

            Reconectar()
            tabVal.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "banco, serie as numero, fecha_cobro as fcobro, importe as importe from fact_cheques where comprobante = " & idRecibo, conexionPrinc)
            tabVal.Fill(fac.Tables("valoresrecibo"))


            Reconectar()
            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "descripcion,ptotal as ptotal from fact_items where " _
            & "id_fact=" & idRecibo, conexionPrinc)
            tabFac.Fill(fac.Tables("reciboitems"))

            Reconectar()
            tabtarj.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "nombre,autorizacion,format(importe,2,'es_AR') as importe from fact_tarjetas where comprobante=" & idRecibo, conexionPrinc)
            tabtarj.Fill(fac.Tables(("tarjetarecbo")))

            Reconectar()
            totrec.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT 
                    fact.id,
                    FORMAT(IFNULL((SELECT (replace(importe,',','.')) FROM fact_cheques WHERE comprobante = fact.id ),0),2,'es_AR') as cheques,
                    FORMAT(IFNULL((SELECT (replace(importe,',','.')) FROM fact_transferencias WHERE comprobante = fact.id ),0),2,'es_AR') as transferencias,
                    FORMAT(IFNULL((SELECT (replace(importe,',','.')) FROM fact_retenciones WHERE comprobante = fact.id),0),2,'es_AR') as retenciones,
                    FORMAT(IFNULL((SELECT (replace(importe,',','.')) FROM fact_tarjetas WHERE comprobante = fact.id),0),2,'es_AR') AS tarjeta,
                    FORMAT(replace(fact.total,',','.'),2,'es_AR') as total 
                    FROM fact_facturas as fact where fact.id= " & idRecibo, conexionPrinc)
            totrec.Fill(fac.Tables("totalesrecibo"))

            Dim imprimirx As New imprimirFX
            With imprimirx
                '.MdiParent = Me.MdiParent
                .rptfx.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptfx.LocalReport.ReportPath = System.Environment.CurrentDirectory & " \reportes\recibo.rdlc"
                .rptfx.LocalReport.DataSources.Clear()
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("encabezado", fac.Tables("factura_enca")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("valores", fac.Tables("valoresrecibo")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("items", fac.Tables("reciboitems")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("tarjetas", fac.Tables("tarjetarecbo")))
                .rptfx.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("totalesrecibo", fac.Tables("totalesrecibo")))
                .rptfx.DocumentMapCollapsed = True
                .rptfx.RefreshReport()
                .Show()
            End With
        Catch ex As Exception

        End Try
    End Sub

    'Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    'End Function
    Public Function RepararNumeracionComprobantes() As Boolean
        Try
            Dim tablaComp As New DataTable
            Dim i As Integer
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT max(num_fact) as numfact,tipofact,ptovta 
                                                                    FROM fact_facturas  group by tipofact, ptovta ", conexionPrinc)
            consulta.Fill(tablaComp)

            For i = 0 To tablaComp.Rows.Count - 1
                Reconectar()
                Dim num_Fact As Integer = tablaComp.Rows(i).Item(0)
                Dim tipo_Fact As Integer = tablaComp.Rows(i).Item(1)
                Dim punto_Venta As Integer = tablaComp.Rows(i).Item(2)

                Dim comandocaj As New MySql.Data.MySqlClient.MySqlCommand("update fact_conffiscal set confnume=" & num_Fact & " 
            where donfdesc=" & tipo_Fact & " and " & "ptovta=" & punto_Venta & "
            ", conexionPrinc)
                comandocaj.ExecuteNonQuery()
            Next
            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function
    Public Function ExisteProducto(ByVal codigo As String) As Boolean
        Reconectar()
        Dim sqlQuery As String = "select id from fact_insumos where cod_bar like '" & codigo & "' or codigo like '" & codigo & "'"
        Dim ConsultaProd As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlQuery, conexionPrinc)
        Dim readProd As New DataTable
        ConsultaProd.Fill(readProd)

        If readProd.Rows.Count <> 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function IdProductoObtener(ByVal codigo As String) As Integer
        Reconectar()

        Dim sqlQuery As String = "select id from fact_insumos where cod_bar like '" & codigo & "' or codigo like '" & codigo & "' limit 0,1"
        Dim ConsultaProd As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlQuery, conexionPrinc)
        Dim readProd As New DataTable
        ConsultaProd.Fill(readProd)
        Dim filasProd() As DataRow
        filasProd = readProd.Select("")
        If readProd.Rows.Count <> 0 Then
            Return filasProd(0)(0)
        End If

    End Function
    Public Function CodProductoObtener(ByVal idProd As String) As Integer
        Try
            Reconectar()

            Dim sqlQuery As String = "select cod_bar from fact_insumos where id =" & idProd
            Dim ConsultaProd As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlQuery, conexionPrinc)
            Dim readProd As New DataTable
            ConsultaProd.Fill(readProd)
            Dim filasProd() As DataRow
            filasProd = readProd.Select("")
            If readProd.Rows.Count <> 0 Then
                Return filasProd(0)(0)
            End If
        Catch ex As Exception
        End Try

    End Function

    Public Sub cerrar_Conexiones()
        Try
            'conexionEmp.Close()
            conexionPrinc.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub abrir_Conexiones()
        Try
            'conexionEmp.Open()
            conexionPrinc.Open()
            conexionPrinc.ChangeDatabase(database)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub Reconectar()
        Try
            conexionPrinc.Close()
            conexionPrinc.Open()
            conexionPrinc.ChangeDatabase(database)
        Catch ex As Exception

        End Try
    End Sub

    Public Function reemplazar_espacios(ByRef texto As String) As String
        Dim reemplazo As String
        Try
            reemplazo = Replace(texto, " ", "_").ToUpper
            Return reemplazo
        Catch ex As Exception
            Return "error"
        End Try
    End Function
    Public Function ValidaControles(ByVal ctrlContenedor As Form) As Boolean
        'Recorre todos y cada uno de los controles contenidos en el contenedor
        For Each Control As Control In ctrlContenedor.Controls
            'Si el control que se esta revisando es un textbox
            If TypeOf Control Is TextBox Then
                'Verificamos que tenga informacion
                If Trim(Control.Text) = "" Then
                    'Si no tiene informacion mandamos un MSGBOX con el mensaje apropiado el cual se encuentra en el tag del control
                    MsgBox(Control.Tag, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Application.ProductName)
                    'Pone el foco en el control
                    Control.BackColor = Color.Salmon
                    Control.Focus()
                    'Regresa un falso indicando que los controles no estan llenados correctamente

                    Exit For
                    Return False
                End If
                'Si el control que se esta revisando es un ComboBox   
            ElseIf TypeOf Control Is ComboBox Then
                'Hago un tipo cast para convertirlo a ComboBOx porque por alguna extraña razon no puedo ingresar a sus propiedades correctamente     
                Dim aux As ComboBox = Control
                'Si no tienen ningun elemento seleccionado el combobox mandamos un MSGBOX con el mensaje apropiado el cual se encuentra en el tag del control
                If aux.SelectedValue = Nothing Then
                    MsgBox(Control.Tag, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Application.ProductName)
                    'Pone el foco en el control 
                    Control.Focus()
                    'Regresa un falso indicando que los controles no estan llenados correctamente
                    Return False
                    Exit For
                End If
            End If
        Next
        'Si no hubo ningun problema con los controles regresamos un true indicando que los controles estan llenados correctamente
        Return True
    End Function
    'convertir binario a imágen
    Public Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    'convertir imagen a binario
    Public Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        If Not Imagen Is Nothing Then
            'variable de datos binarios en stream(flujo)
            Dim Bin As New MemoryStream
            'convertir a bytes
            Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            'retorna binario
            Return Bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function

    'Public Function archivo_Bytes(ByVal Imagen As Image) As Byte()
    '    'si hay imagen
    '    If Not Imagen Is Nothing Then
    '        'variable de datos binarios en stream(flujo)
    '        Dim Bin As New MemoryStream
    '        'convertir a bytes
    '        Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
    '        'retorna binario
    '        Return Bin.GetBuffer
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    Public Function remplazarcoma(ByVal cadena As String) As String
        Dim pos As Integer
        pos = InStr(cadena, ".")
        If pos <> 0 Then
            Mid(cadena, pos, pos + 1) = ","
            remplazarcoma = cadena

        Else : remplazarcoma = cadena
        End If

    End Function

    Public Function remplazarPunto(ByVal cadena As String) As String
        Dim pos As Integer
        pos = InStr(cadena, ",")
        If pos <> 0 Then
            Mid(cadena, pos, pos + 1) = "."
            remplazarPunto = cadena

        Else : remplazarPunto = cadena
        End If

    End Function

    Public Function PonerComodinSQL(ByVal cadena As String) As String
        Dim pos As Integer
        pos = InStr(cadena, " ")
        If pos <> 0 Then
            Mid(cadena, pos, pos + 1) = "%"
            PonerComodinSQL = cadena

        Else : PonerComodinSQL = cadena
        End If

    End Function

    Public Function SincronizarBD() As Boolean
        Try
            Dim obj As Object
            Dim archivo As Object
            obj = CreateObject("Scripting.FileSystemObject")
            archivo = obj.createtextfile(Application.StartupPath & "\sincro.xml", True)
            archivo.writeline("<?xml version='1.0' encoding='UTF-8'?>")
            archivo.writeline("<job version='11.1'>")
            archivo.writeline("<syncjob>")
            archivo.writeline("<fkcheck check='yes' />")
            archivo.writeline("<twowaysync twoway='no' />")
            archivo.writeline("<passwords isencoded='no' />")
            archivo.writeline("<source>")
            archivo.writeline("<host>" & DatosAcceso.CLOUDserv & "</host>")
            archivo.writeline("<user>" & DatosAcceso.usuario & "</user>")
            archivo.writeline("<pwd>" & DatosAcceso.pass & "</pwd>")
            archivo.writeline("<port>" & DatosAcceso.puerto & "</port>")
            archivo.writeline("<compressed>1</compressed>")
            archivo.writeline("<ssl>0</ssl>")
            archivo.writeline("<sslauth>0</sslauth>")
            archivo.writeline("<clientkey></clientkey>")
            archivo.writeline("<clientcert></clientcert>")
            archivo.writeline("<cacert></cacert>")
            archivo.writeline("<cipher></cipher>")
            archivo.writeline("<charset></charset>")
            archivo.writeline("<database>" & DatosAcceso.bd & "</database>")
            archivo.writeline("</source>")
            archivo.writeline("<target>")
            archivo.writeline("<host>" & DatosAcceso.RESPserv & "</host>")
            archivo.writeline("<user>" & DatosAcceso.usuario & "</user>")
            archivo.writeline("<pwd>" & DatosAcceso.pass & "</pwd>")
            archivo.writeline("<port>" & DatosAcceso.puerto & "</port>")
            archivo.writeline("<compressed>1</compressed>")
            archivo.writeline("<ssl>0</ssl>")
            archivo.writeline("<sslauth>0</sslauth>")
            archivo.writeline("<clientkey></clientkey>")
            archivo.writeline("<clientcert></clientcert>")
            archivo.writeline("<cacert></cacert>")
            archivo.writeline("<cipher></cipher>")
            archivo.writeline("<charset></charset>")
            archivo.writeline("<database>" & DatosAcceso.bd & "</database>")
            archivo.writeline("</target>")
            archivo.writeline("<tables all='yes'/>")
            archivo.writeline("<sync_action type='directsync'/>")
            archivo.writeline("<abortonerror abort='no' />")
            archivo.writeline("<sendreport send='yes' when='onerror'><smtp>")
            archivo.writeline("<displayname>KIBIT SERVICIO DE SINCRONIZACION</displayname>")
            archivo.writeline("<toemail>info@kibit.com.ar</toemail>")
            archivo.writeline("<fromemail>info@kibit.com.ar</fromemail>")
            archivo.writeline("<replyemail>info@kibit.com.ar</replyemail>")
            archivo.writeline("<host>mail.kibit.com.ar</host>")
            archivo.writeline("<encryption>no</encryption>")
            archivo.writeline("<port>25</port>")
            archivo.writeline("<auth required='yes'>")
            archivo.writeline("<user>info@kibit.com.ar</user>")
            archivo.writeline("<pwd>Narinas1830</pwd>")
            archivo.writeline("</auth>")
            archivo.writeline("<subject>yyyy-mm-dd hh:mm:ss</subject>")
            archivo.writeline("</smtp>")
            archivo.writeline("</sendreport></syncjob>")
            archivo.writeline("</job>")
            archivo.close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SincronizarTabla(ByRef tabla As String) As Boolean
        Try
            Dim obj As Object
            Dim archivo As Object
            obj = CreateObject("Scripting.FileSystemObject")
            archivo = obj.createtextfile(Application.StartupPath & "\sincro.xml", True)
            archivo.writeline("<?xml version='1.0' encoding='UTF-8'?>")
            archivo.writeline("<job version='11.1'>")
            archivo.writeline("<syncjob>")
            archivo.writeline("<fkcheck check='yes' />")
            archivo.writeline("<twowaysync twoway='no' />")
            archivo.writeline("<source>")
            archivo.writeline("<host>" & DatosAcceso.CLOUDserv & "</host>")
            archivo.writeline("<user>" & DatosAcceso.usuario & "</user>")
            archivo.writeline("<pwd>" & DatosAcceso.pass & "</pwd>")
            archivo.writeline("<port>" & DatosAcceso.puerto & "</port>")
            archivo.writeline("<compressed>1</compressed>")
            archivo.writeline("<ssl>0</ssl>")
            archivo.writeline("<sslauth>0</sslauth>")
            archivo.writeline("<clientkey></clientkey>")
            archivo.writeline("<clientcert></clientcert>")
            archivo.writeline("<cacert></cacert>")
            archivo.writeline("<cipher></cipher>")
            archivo.writeline("<charset></charset>")
            archivo.writeline("<database>" & DatosAcceso.bd & "</database>")
            archivo.writeline("</source>")
            archivo.writeline("<target>")
            archivo.writeline("<host>" & DatosAcceso.RESPserv & "</host>")
            archivo.writeline("<user>" & DatosAcceso.usuario & "</user>")
            archivo.writeline("<pwd>" & DatosAcceso.pass & "</pwd>")
            archivo.writeline("<port>" & DatosAcceso.puerto & "</port>")
            archivo.writeline("<compressed>1</compressed>")
            archivo.writeline("<ssl>0</ssl>")
            archivo.writeline("<sslauth>0</sslauth>")
            archivo.writeline("<clientkey></clientkey>")
            archivo.writeline("<clientcert></clientcert>")
            archivo.writeline("<cacert></cacert>")
            archivo.writeline("<cipher></cipher>")
            archivo.writeline("<charset></charset>")
            archivo.writeline("<database>" & DatosAcceso.bd & "</database>")
            archivo.writeline("</target>")

            archivo.writeline("<tables all='no'>")
            archivo.writeline("<table>")
            archivo.writeline("<name>`" & tabla & "`</name>'")
            archivo.writeline("<columns all='yes' />")
            archivo.writeline("</table>")
            archivo.writeline("</tables>")
            archivo.writeline("<sync_action type='directsync'/>")
            archivo.writeline("<abortonerror abort='no' />")
            archivo.writeline("<sendreport send='yes' when='onerror'><smtp>")
            archivo.writeline("<displayname>KIBIT SERVICIO DE SINCRONIZACION</displayname>")
            archivo.writeline("<toemail>info@kibit.com.ar</toemail>")
            archivo.writeline("<fromemail>info@kibit.com.ar</fromemail>")
            archivo.writeline("<replyemail>info@kibit.com.ar</replyemail>")
            archivo.writeline("<host>mail.kibit.com.ar</host>")
            archivo.writeline("<encryption>no</encryption>")
            archivo.writeline("<port>25</port>")
            archivo.writeline("<auth required='yes'>")
            archivo.writeline("<user>info@kibit.com.ar</user>")
            archivo.writeline("<pwd>Hacha123</pwd>")
            archivo.writeline("</auth>")
            archivo.writeline("<subject>yyyy-mm-dd hh:mm:ss</subject>")
            archivo.writeline("</smtp>")
            archivo.writeline("</sendreport></syncjob>")
            archivo.writeline("</job>")
            archivo.close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CompletarCeros(ByVal numero As Integer, ByVal tip As Integer) As String
        Select Case tip
            Case 1
                Return Format(numero, "00000000")
            Case 2
                Return Format(numero, "0000")
        End Select
    End Function

    Public Function RestringirNumerosFact(ByVal tipo As String, ByVal numero As String, ByVal Ptovta As Integer) As Boolean
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id from fact_facturas where num_fact=" & numero & " and tipofact=" & tipo & " and ptovta=" & Ptovta, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)

            If tablacl.Rows.Count <> 0 Then
                If RepararNumeracionComprobantes() = True Then
                    Return False
                Else
                    Return True
                End If

            End If
            If tablacl.Rows.Count = 0 Then Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ObtenerNumerosFact(ByVal tipo As String, ByVal PtoVta As Integer) As Integer
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT confnume+1 from fact_conffiscal where donfdesc=" & tipo & " and ptovta= " & PtoVta, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select()
            Return infocl(0)(0)
        Catch ex As Exception

        End Try
    End Function

    Public Sub GenerarExcel(ByRef ElGrid As DataGridView)
        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Add()
            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount
            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).HeaderText.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    If Not IsNothing(ElGrid.Rows(Fila).Cells(Col).Value) Then
                        'If IsDate(ElGrid.Rows(Fila).Cells(Col).Value.ToString) Then
                        '    exHoja.Cells.Item(Fila + 2, Col + 1) = Format(CDate(ElGrid.Rows(Fila).Cells(Col).Value.ToString), "dd-MM-yyyy")
                        '    exHoja.Cells.Item(Fila + 2, Col + 1).HorizontalAlignment = 1
                        'Else
                        exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value.ToString
                        exHoja.Cells.Item(Fila + 2, Col + 1).HorizontalAlignment = 1
                        ' End If
                    End If
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            'Aplicación visible
            exApp.Application.Visible = True
            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
        End Try
    End Sub

    Public Function comprobarComprobanteCompra(ByRef comprobante As String, ByRef contribuyente As String, conexion As MySql.Data.MySqlClient.MySqlConnection) As Boolean
        Try
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id from iv_items_compras where nufac like '" & comprobante & "' and " _
            & "replace(cuit,'-','') like '" & Replace(contribuyente, "-", "") & "'", conexion)
            Dim tablacl As New DataTable
            consulta.Fill(tablacl)
            If tablacl.Rows.Count <> 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function ComprobarCliente(ByVal parametro As String) As Boolean

        Dim busqtxt As String
        parametro = parametro.Replace(" ", "%")
        busqtxt = " where nomapell_razon like @busq or dir_domicilio like @busq or cuit like @busq or telefono like @busq or celular like @busq"

        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select idclientes as Cuenta, nomapell_razon as Cliente, codClie from fact_clientes where nomapell_razon like @busq or dir_domicilio like @busq or cuit like @busq or telefono like @busq or celular like @busq", conexionPrinc)
            consulta.SelectCommand.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("@busq", MySql.Data.MySqlClient.MySqlDbType.Text))
            consulta.SelectCommand.Parameters("@busq").Value = "%" & parametro & "%"
            Dim tablaPers As New DataTable
            consulta.Fill(tablaPers)

            If tablaPers.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function ComprobarLocalidad(nombre As String) As Integer
        Reconectar()
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM cm_localidad where nombre like '%" & nombre & "%' limit 1", conexionPrinc)
        Dim tabla As New DataTable
        consulta.Fill(tabla)
        If tabla.Rows.Count <> 0 Then
            Return tabla.Rows(0).Item("id")
        Else
            Reconectar()
            Dim comandoADD As New MySql.Data.MySqlClient.MySqlCommand("insert into cm_localidad (nombre) values ('" & nombre & "')", conexionPrinc)
            comandoADD.ExecuteNonQuery()
            Return comandoADD.LastInsertedId
        End If
    End Function
    Public Function ComprobarClienteCUIT(cuit As String) As Boolean

        'Dim busqtxt As String
        'parametro = parametro.Replace(" ", "%")
        'busqtxt = " where nomapell_razon like @busq or dir_domicilio like @busq or cuit like @busq or telefono like @busq or celular like @busq"

        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_clientes where cuit like '" & cuit & "'", conexionPrinc)
            Dim tablaPers As New DataTable
            consulta.Fill(tablaPers)

            If tablaPers.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function ComprobarProveedorCUIT(cuit As String) As Boolean

        'Dim busqtxt As String
        'parametro = parametro.Replace(" ", "%")
        'busqtxt = " where nomapell_razon like @busq or dir_domicilio like @busq or cuit like @busq or telefono like @busq or celular like @busq"

        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_proveedores where cuit like '" & cuit & "'", conexionPrinc)
            Dim tablaPers As New DataTable
            consulta.Fill(tablaPers)

            If tablaPers.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ObtenerNombrePrimeraHoja(ByVal rutaLibro As String) As String
        Dim app As Excel.Application = Nothing
        Try
            app = New Excel.Application()
            Dim wb As Excel.Workbook = app.Workbooks.Open(rutaLibro)
            Dim ws As Excel.Worksheet = CType(wb.Worksheets.Item(1), Excel.Worksheet)
            Dim name As String = ws.Name
            ws = Nothing
            wb.Close()
            wb = Nothing
            Return name
        Catch ex As Exception
            Throw

        Finally
            If (Not app Is Nothing) Then _
                app.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(app)
            app = Nothing
        End Try
    End Function
    Public Function GetDataExcel(
  ByVal fileName As String, ByVal sheetName As String) As DataTable
        Try


            ' Comprobamos los parámetros.
            '
            If ((String.IsNullOrEmpty(fileName)) OrElse
          (String.IsNullOrEmpty(sheetName))) Then _
          Throw New ArgumentNullException()


            Dim extension As String = IO.Path.GetExtension(fileName)

            Dim connString As String = "Data Source=" & fileName

            If (extension = ".xls") Then
                connString &= ";Provider=Microsoft.Jet.OLEDB.4.0;" &
                       "Extended Properties='Excel 8.0;HDR=YES;IMEX=1;Allow Formula=false'"

            ElseIf (extension = ".xlsx") Then
                connString &= ";Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;Allow Formula=false'"
            Else
                Throw New ArgumentException(
                  "La extensión " & extension & " del archivo no está permitida.")
            End If

            Using conexion As New OleDbConnection(connString)

                Dim sql As String = "SELECT * FROM [" & sheetName & "$]"
                Dim adaptador As New OleDbDataAdapter(sql, conexion)

                Dim dt As New DataTable("Excel")

                adaptador.Fill(dt)

                Return dt

            End Using

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Function

    Public Function ComprobarStock(ByRef codigo As String, ByRef cant As String) As Boolean
        Try
            Reconectar()

            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("
            SELECT sum(lt.stock) as stock,prod.desc_cantidad 
            FROM fact_insumos_lotes as lt, fact_insumos as prod 
            where lt.idproducto=prod.id and lt.idproducto=" & codigo & " and lt.idalmacen= " & My.Settings.idAlmacen, conexionPrinc)
            Dim desc_cant As Double
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            desc_cant = infocl(0)("desc_cantidad")
            'MsgBox(consulta.SelectCommand.CommandText)
            'MsgBox(infocl(0)(0) & ">= " & cant * desc_cant)
            If infocl(0)("stock") >= cant * desc_cant Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function QuitarStock(ByRef codigo As String, ByRef cant As String, ByRef idgtia As String) As Boolean
        Dim i As Integer
        Dim lotes As Integer = 0
        Try
            Reconectar()
            If idgtia = 0 Then
                Dim consultastock As New MySql.Data.MySqlClient.MySqlDataAdapter("                
                SELECT lt.id, lt.stock as stock, prod.desc_cantidad 
                FROM fact_insumos_lotes as lt, fact_insumos as prod
                where lt.idproducto=prod.id and lt.idproducto=" & codigo & " and lt.idalmacen= " & My.Settings.idAlmacen & "                
                and lt.stock >0  order by lt.id asc", conexionPrinc)
                Dim tablastock As New DataTable
                Dim infostock() As DataRow
                consultastock.Fill(tablastock)
                infostock = tablastock.Select("")
                Dim desc_cant As Double = infostock(0)("desc_cantidad")
                cant = cant * desc_cant
                'lotes = tablastock.Rows.Count
                Do Until cant = 0
                    If infostock(lotes)(1) <= cant Then
                        cant = cant - infostock(lotes)(1)
                        Reconectar()
                        Dim updstock As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos_lotes set stock=0 where id=" & infostock(lotes)(0), conexionPrinc)
                        updstock.ExecuteNonQuery()
                        lotes += 1
                    ElseIf infostock(lotes)(1) > cant Then
                        Reconectar()
                        Dim updstock As New MySql.Data.MySqlClient.MySqlCommand("update fact_insumos_lotes set stock=stock-" & cant & " where id=" & infostock(lotes)(0), conexionPrinc)
                        updstock.ExecuteNonQuery()
                        cant = 0
                    End If
                Loop
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function QuitarGarantia(ByRef serie As String) As Integer
        Try
            Dim consultapedidoitems As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT ins.id " _
            & "FROM fact_gtia as gtia, fact_insumos_lotes as ins " _
            & "where ins.idproducto=gtia.idproducto and gtia.serie like '" & serie & "'", conexionPrinc)
            ' MsgBox(consultapedidoitems.SelectCommand.CommandText)
            Dim tablaitm As New DataTable
            Dim infoitm() As DataRow
            consultapedidoitems.Fill(tablaitm)
            infoitm = tablaitm.Select("")
            If tablaitm.Rows.Count = 0 Then
                MsgBox("No se encuentra el producto en la tabla de garantias")
                Return 0
            Else
                Return infoitm(0)(0)
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ComprobarGarantia(ByRef serie As String) As String
        Try
            Dim consultapedidoitems As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT prod.codigo " _
                & "FROM fact_gtia as gtia, fact_insumos as prod " _
                & "where prod.codigo=gtia.codigo and gtia.serie like '" & serie & "'", conexionPrinc)
            ' MsgBox(consultapedidoitems.SelectCommand.CommandText)
            Dim tablaitm As New DataTable
            Dim infoitm() As DataRow
            consultapedidoitems.Fill(tablaitm)
            infoitm = tablaitm.Select("")
            If tablaitm.Rows.Count = 0 Then
                'MsgBox("No se encuentra el producto en la tabla de garantias")
                Return 0
            Else
                Return infoitm(0)(0)
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function ValidarDireccionEmail(ByVal direccion As String) As Boolean
        Try
            Dim a As New System.Net.Mail.MailAddress(direccion)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Sub EnviarMail(ByVal mensaje As String, ByVal para As String, ByVal asunto As String, adjunto As System.Net.Mail.Attachment)
        Dim mje As New System.Net.Mail.MailMessage()
        Dim SMTP As New System.Net.Mail.SmtpClient

        Reconectar()
        Dim consultaDtosMail As New MySql.Data.MySqlClient.MySqlDataAdapter("select texto1 from tecni_datosgenerales where id>=26 and id<=33 order by id asc", conexionPrinc)
        Dim tablaDtosMail As New DataTable
        Dim infoDtosMail() As DataRow
        'Dim adjunto As New System.Net.Mail.Attachment(adjunto)

        consultaDtosMail.Fill(tablaDtosMail)
        infoDtosMail = tablaDtosMail.Select("")

        SMTP.Credentials = New System.Net.NetworkCredential(infoDtosMail(0)(0).ToString, infoDtosMail(1)(0).ToString)
        SMTP.Host = infoDtosMail(2)(0).ToString
        SMTP.Port = infoDtosMail(3)(0).ToString
        SMTP.UseDefaultCredentials = infoDtosMail(5)(0).ToString
        SMTP.EnableSsl = infoDtosMail(6)(0).ToString
        'SMTP.
        'System.Net.NetworkCredential NetworkCred = New System.Net.NetworkCredential();
        mje.[To].Add(para.ToLower)
        mje.Attachments.Add(adjunto)
        mje.From = New System.Net.Mail.MailAddress(infoDtosMail(7)(0).ToString, infoDtosMail(4)(0).ToString, System.Text.Encoding.UTF8)
        mje.Subject = asunto
        mje.SubjectEncoding = System.Text.Encoding.UTF8
        mje.Body = mensaje
        mje.BodyEncoding = System.Text.Encoding.UTF8
        mje.Priority = System.Net.Mail.MailPriority.High
        mje.IsBodyHtml = False

        Try
            SMTP.Send(mje)
            MessageBox.Show("Mensaje enviado correctamente", "Exito!", MessageBoxButtons.OK)
        Catch ex As System.Net.Mail.SmtpException
            MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
        End Try
    End Sub

    Public Function CalcularCadenaEAN13(ByVal chaine As String) As String

        Dim i, checksum, first As Integer
        Dim CodeBarre As String
        Dim tableA As Boolean

        CalcularCadenaEAN13 = ""
        If Len(chaine) = 12 Then
            For i = 1 To 12
                If Asc(Mid(chaine, i, 1)) < 48 Or Asc(Mid(chaine, i, 1)) > 57 Then
                    i = 0
                    Exit For
                End If
            Next
            If i = 13 Then
                For i = 2 To 12 Step 2
                    checksum = checksum + Val(Mid(chaine, i, 1))
                Next
                checksum = checksum * 3
                For i = 1 To 11 Step 2
                    checksum = checksum + Val(Mid(chaine, i, 1))
                Next
                chaine = chaine & (10 - checksum Mod 10) Mod 10
                CodeBarre = Left(chaine, 1) & Chr(65 + Val(Mid(chaine, 2, 1)))
                first = Val(Left(chaine, 1))
                For i = 3 To 7
                    tableA = False
                    Select Case i
                        Case 3
                            Select Case first
                                Case 0 To 3
                                    tableA = True
                            End Select
                        Case 4
                            Select Case first
                                Case 0, 4, 7, 8
                                    tableA = True
                            End Select
                        Case 5
                            Select Case first
                                Case 0, 1, 4, 5, 9
                                    tableA = True
                            End Select
                        Case 6
                            Select Case first
                                Case 0, 2, 5, 6, 7
                                    tableA = True
                            End Select
                        Case 7
                            Select Case first
                                Case 0, 3, 6, 8, 9
                                    tableA = True
                            End Select
                    End Select
                    If tableA Then
                        CodeBarre = CodeBarre & Chr(65 + Val(Mid(chaine, i, 1)))
                    Else
                        CodeBarre = CodeBarre & Chr(75 + Val(Mid(chaine, i, 1)))
                    End If
                Next
                CodeBarre = CodeBarre & "*"
                For i = 8 To 13
                    CodeBarre = CodeBarre & Chr(97 + Val(Mid(chaine, i, 1)))
                Next
                CodeBarre = CodeBarre & "+"
                CalcularCadenaEAN13 = CodeBarre
            End If
        End If
    End Function

    Public Function CalcularVerificadorEAN13(ByVal EAN As String)             'calcula digito verificador del EAN13
        '**OK**
        Dim dvc As String = ""      'digito verificador calculado
        Dim iSum As Integer = 0
        Dim iDigit As Integer = 0

        For i As Integer = EAN.Length To 1 Step -1
            iDigit = Convert.ToInt32(EAN.Substring(i - 1, 1))
            If (EAN.Length - i + 1) Mod 2 <> 0 Then
                iSum += iDigit * 3
            Else
                iSum += iDigit
            End If
        Next

        Dim iCheckSum As Integer = (10 - (iSum Mod 10)) Mod 10
        dvc = iCheckSum.ToString()

        Return dvc

    End Function

    Public Function EnLetras(numero As String) As String
        Dim b, paso As Integer
        Dim expresion, entero, deci, flag As String
        numero = Replace(numero, ".", "")
        'numero = remplazarPunto(numero)
        flag = "N"
        For paso = 1 To Len(numero)
            If Mid(numero, paso, 1) = "," Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, paso, 1) 'Extae la parte entera del numero
                Else
                    deci = deci + Mid(numero, paso, 1) 'Extrae la parte decimal del numero
                End If
            End If
        Next paso

        If Len(deci) = 1 Then
            deci = deci & "0"
        End If

        flag = "N"
        If Val(numero) >= -999999999 And Val(numero) <= 999999999 Then 'si el numero esta dentro de 0 a 999.999.999
            For paso = Len(entero) To 1 Step -1
                b = Len(entero) - (paso - 1)
                Select Case paso
                    Case 3, 6, 9
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" And Mid(entero, b + 2, 1) = "0" Then
                                    expresion = expresion & "cien "
                                Else
                                    expresion = expresion & "ciento "
                                End If
                            Case "2"
                                expresion = expresion & "doscientos "
                            Case "3"
                                expresion = expresion & "trescientos "
                            Case "4"
                                expresion = expresion & "cuatrocientos "
                            Case "5"
                                expresion = expresion & "quinientos "
                            Case "6"
                                expresion = expresion & "seiscientos "
                            Case "7"
                                expresion = expresion & "setecientos "
                            Case "8"
                                expresion = expresion & "ochocientos "
                            Case "9"
                                expresion = expresion & "novecientos "
                        End Select

                    Case 2, 5, 8
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    flag = "S"
                                    expresion = expresion & "diez "
                                End If
                                If Mid(entero, b + 1, 1) = "1" Then
                                    flag = "S"
                                    expresion = expresion & "once "
                                End If
                                If Mid(entero, b + 1, 1) = "2" Then
                                    flag = "S"
                                    expresion = expresion & "doce "
                                End If
                                If Mid(entero, b + 1, 1) = "3" Then
                                    flag = "S"
                                    expresion = expresion & "trece "
                                End If
                                If Mid(entero, b + 1, 1) = "4" Then
                                    flag = "S"
                                    expresion = expresion & "catorce "
                                End If
                                If Mid(entero, b + 1, 1) = "5" Then
                                    flag = "S"
                                    expresion = expresion & "quince "
                                End If
                                If Mid(entero, b + 1, 1) > "5" Then
                                    flag = "N"
                                    expresion = expresion & "dieci"
                                End If

                            Case "2"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "veinte "
                                    flag = "S"
                                Else
                                    expresion = expresion & "veinti"
                                    flag = "N"
                                End If

                            Case "3"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "treinta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "treinta y "
                                    flag = "N"
                                End If

                            Case "4"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cuarenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cuarenta y "
                                    flag = "N"
                                End If

                            Case "5"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cincuenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cincuenta y "
                                    flag = "N"
                                End If

                            Case "6"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "sesenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "sesenta y "
                                    flag = "N"
                                End If

                            Case "7"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "setenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "setenta y "
                                    flag = "N"
                                End If

                            Case "8"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "ochenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "ochenta y "
                                    flag = "N"
                                End If

                            Case "9"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "noventa "
                                    flag = "S"
                                Else
                                    expresion = expresion & "noventa y "
                                    flag = "N"
                                End If
                        End Select

                    Case 1, 4, 7
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If flag = "N" Then
                                    If paso = 1 Then
                                        expresion = expresion & "uno "
                                    Else
                                        expresion = expresion & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then
                                    expresion = expresion & "dos "
                                End If
                            Case "3"
                                If flag = "N" Then
                                    expresion = expresion & "tres "
                                End If
                            Case "4"
                                If flag = "N" Then
                                    expresion = expresion & "cuatro "
                                End If
                            Case "5"
                                If flag = "N" Then
                                    expresion = expresion & "cinco "
                                End If
                            Case "6"
                                If flag = "N" Then
                                    expresion = expresion & "seis "
                                End If
                            Case "7"
                                If flag = "N" Then
                                    expresion = expresion & "siete "
                                End If
                            Case "8"
                                If flag = "N" Then
                                    expresion = expresion & "ocho "
                                End If
                            Case "9"
                                If flag = "N" Then
                                    expresion = expresion & "nueve "
                                End If
                        End Select
                End Select
                If paso = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or
                      (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And
                       Len(entero) <= 6) Then
                        expresion = expresion & "mil "
                    End If
                End If
                'If paso = 7 Then
                'If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                'expresion = expresion & "millón "
                'Else
                'expresion = expresion & "millones "
                'End If
                'End If
            Next paso

            If deci <> "" Then
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion & "con " & deci & "/100"
                Else
                    EnLetras = expresion & "con " & deci & "/100"
                End If
            Else
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion
                Else
                    EnLetras = expresion
                End If
            End If
        Else 'si el numero a convertir esta fuera del rango superior e inferior
            EnLetras = ""
        End If
    End Function

End Module

