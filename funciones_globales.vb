Imports System.Data
Imports System.IO
Imports System.Data.OleDb
'Imports Excel = Microsoft.Office.Interop.Excel
'Imports System.Runtime.InteropServices
Module funciones_Globales

    'Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    'End Function

    Public Function ExisteProducto(ByVal codigo As String) As Boolean

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
    Public Function IdProducto(ByVal codigo As String) As Integer

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
                Return Format(numero, "0000000000")
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

            If tablacl.Rows.Count <> 0 Then Return True
            If tablacl.Rows.Count = 0 Then Return False
        Catch ex As Exception

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
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next
            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
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
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT sum(stock) FROM fact_insumos_lotes where idproducto=" & codigo & " and idalmacen= " & DatosAcceso.IdAlmacen, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            ' MsgBox(infocl(0)(0) & ">= " & cant)
            If infocl(0)(0) >= cant Then
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
                Dim consultastock As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id, stock FROM fact_insumos_lotes " _
                & "where stock >0 and idproducto=" & codigo & " order by id asc", conexionPrinc)
                Dim tablastock As New DataTable
                Dim infostock() As DataRow
                consultastock.Fill(tablastock)
                infostock = tablastock.Select("")
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
    Public Sub EnviarMail(ByVal mensaje As String, ByVal para As String, ByVal asunto As String)
        Dim mje As New System.Net.Mail.MailMessage()
        Dim SMTP As New System.Net.Mail.SmtpClient

        Reconectar()
        Dim consultaDtosMail As New MySql.Data.MySqlClient.MySqlDataAdapter("select texto1 from tecni_datosgenerales where id>=26 and id<=30", conexionPrinc)
        Dim tablaDtosMail As New DataTable
        Dim infoDtosMail() As DataRow
        consultaDtosMail.Fill(tablaDtosMail)
        infoDtosMail = tablaDtosMail.Select("")

        SMTP.Credentials = New System.Net.NetworkCredential(infoDtosMail(0)(0).ToString, infoDtosMail(1)(0).ToString)
        SMTP.Host = infoDtosMail(2)(0).ToString
        SMTP.Port = infoDtosMail(3)(0).ToString
        SMTP.EnableSsl = False

        mje.[To].Add(para.ToLower)
        mje.From = New System.Net.Mail.MailAddress(infoDtosMail(0)(0).ToString, infoDtosMail(4)(0).ToString, System.Text.Encoding.UTF8)
        mje.Subject = asunto
        mje.SubjectEncoding = System.Text.Encoding.UTF8
        mje.Body = mensaje
        mje.BodyEncoding = System.Text.Encoding.UTF8
        mje.Priority = System.Net.Mail.MailPriority.Normal
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
End Module

