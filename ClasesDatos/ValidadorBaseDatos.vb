Imports MySql.Data.MySqlClient

Public Class ValidadorBaseDatos

    ' Compruebo que exista la base de datos y apunto hacia ella
    Public Shared Function ComprobarBasePrincipal() As Boolean
        Try
            If gestorConexiones.conexionPrinc IsNot Nothing AndAlso gestorConexiones.conexionPrinc.State = ConnectionState.Open Then
                gestorConexiones.conexionPrinc.ChangeDatabase(DatosAcceso.bd)
                Return True
            Else
                MsgBox("La conexión principal no está abierta.", MsgBoxStyle.Critical)
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error al verificar la base de datos: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    ' Compruebo la existencia de las tablas críticas
    Public Shared Function ComprobarTablas() As Boolean
        Try
            If gestorConexiones.conexionPrinc.State <> ConnectionState.Open Then
                MsgBox("Se perdió la conexión antes de revisar las tablas.", MsgBoxStyle.Critical)
                Return False
            End If

            Dim encontrado As Integer = 0
            Using comando As New MySqlCommand("SHOW TABLES;", gestorConexiones.conexionPrinc)
                Using lector As MySqlDataReader = comando.ExecuteReader()
                    While lector.Read()
                        Dim nombreTabla As String = lector(0).ToString().ToLower()

                        ' Consumimos la lista directamente desde tu clase de configuración
                        If datosMysql.TablasRequeridas.Contains(nombreTabla) Then
                            encontrado += 1
                        End If
                    End While
                End Using
            End Using

            ' Validamos dinámicamente contra la cantidad de elementos en la lista (Count)
            If encontrado >= datosMysql.TablasRequeridas.Count Then
                Return True
            Else
                MsgBox("Integridad de base de datos fallida: Faltan tablas básicas en el servidor.", MsgBoxStyle.Exclamation)
                Return False
            End If

        Catch ex As Exception
            MsgBox("Error al comprobar estructura de tablas: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

End Class