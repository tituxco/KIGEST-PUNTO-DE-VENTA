Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class GestorITegra
    'Private Shared ReadOnly Property CadenaConexion As String
    '    Get
    '        Return "Server=" & DatosAcceso.CLOUDserv & ";" &
    '               "Port=" & DatosAcceso.puerto & ";" &
    '               "Database=" & DatosAcceso.bd & ";" &
    '               "Uid=" & DatosAcceso.usuario & ";" &
    '               "Pwd=" & DatosAcceso.pass & ";" &
    '               "Default Command Timeout=300;"
    '    End Get
    'End Property
    ''' <summary>
    ''' Exporta los insumos de balanza (tipo = 1) a un archivo TXT para iTegra, 
    ''' omitiendo PLUs mayores a 5 dígitos y registrándolos en una lista de advertencia.
    ''' </summary>
    ''' <param name="rutaDestino">Ruta completa del archivo (ej: C:\iTegra\Importar\PLUS.TXT)</param>
    ''' <param name="insumosOmitidos">Lista devuelta por referencia con los productos ignorados.</param>
    ''' <returns>True si el proceso se completó correctamente.</returns>
    Public Shared Function ExportarProductosITegra(rutaDestino As String, ByRef insumosOmitidos As List(Of String)) As Boolean
        insumosOmitidos = New List(Of String)()

        Try



            Dim query As String = "SELECT id, descripcion, precio " &
                                  "FROM fact_insumos " &
                                  "WHERE tipo = 1 AND eliminado = 0 " &
                                  "ORDER BY id ASC"

            Dim lineas As New List(Of String)()

            Using cmd As New MySqlCommand(query, GestorConexiones.conexionPrinc)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        ' 1. Identificador único: ID del producto
                        Dim idProducto As Integer = Convert.ToInt32(dr("id"))

                        ' Validar que el ID no supere los 5 dígitos permitidos por el código EAN-13
                        If idProducto < 1 OrElse idProducto > 99999 Then
                            Dim descOmitida As String = dr("descripcion").ToString().Trim()
                            insumosOmitidos.Add($"ID: {idProducto} - {descOmitida}")
                            Continue While
                        End If

                        ' 2. Nombre PLU: limpiar punto y coma y saltos de línea (al ser longtext)
                        Dim desc As String = dr("descripcion").ToString() _
                            .Replace(";", " ") _
                            .Replace(vbCr, " ") _
                            .Replace(vbLf, " ") _
                            .Trim()

                        If desc.Length > 28 Then desc = desc.Substring(0, 28)

                        ' 3. Precio formateado con punto decimal (ej: 1850.00)
                        Dim strPrecioRaw As String = dr("precio").ToString().Replace(",", ".").Trim()
                        Dim precio As Decimal = 0D
                        Decimal.TryParse(strPrecioRaw, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, precio)
                        Dim strPrecioFormateado As String = precio.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)

                        ' 4. Armado del renglón CSV:
                        ' numero plu ; codigo plu ; nombre plu ; departamento ; precio ; pesable ; codigo etiqueta
                        Dim linea As String = $"{idProducto};{idProducto};{desc};1;{strPrecioFormateado};P;1"
                        lineas.Add(linea)
                    End While
                End Using
            End Using

            ' Guardar en formato CSV con codificación ANSI (Windows-1252) para respetar tildes y ñ en iTegra
            Dim encodingAnsi As Encoding = Encoding.GetEncoding(1252)
            File.WriteAllLines(rutaDestino, lineas, encodingAnsi)

            Return True

        Catch ex As Exception
            MsgBox("Error al generar CSV para iTegra: " & ex.Message, MsgBoxStyle.Critical, "Exportación iTegra")
            Return False
        End Try
    End Function

End Class