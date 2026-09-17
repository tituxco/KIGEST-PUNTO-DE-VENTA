Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class GestorConexiones

    ' 1. LAS ÚNICAS VARIABLES GLOBALES QUE NECESITAMOS (Accesibles desde todo el sistema)
    Public Shared conexionPrinc As MySqlConnection
    Public Shared conexionSEC As MySqlConnection
    Public Shared conexionColab As MySqlConnection
    Public Shared conexionAuth As MySqlConnection

    ' Genera el Hash MD5
    Public Shared Function GetMd5Hash(input As String) As String
        Using md5Hash As MD5 = MD5.Create()
            Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
            Dim sBuilder As New StringBuilder()
            For i As Integer = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next
            Return sBuilder.ToString()
        End Using
    End Function

    ' Genera el Hash SHA-1
    Public Shared Function GetSha1Hash(input As String) As String
        Using sha1Hash As SHA1 = SHA1.Create()
            Dim data As Byte() = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
            Dim sBuilder As New StringBuilder()
            For i As Integer = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next
            Return sBuilder.ToString()
        End Using
    End Function

    ' Autentica al usuario en AuthServ
    Public Shared Function AutenticarYObtenerConfig(usuario As String, clave As String) As Boolean
        Try
            Dim claveMD5 As String = GetMd5Hash(clave)
            Dim claveSHA1 As String = GetSha1Hash(clave)

            Using conAuth As New MySqlConnection(datosMysql.connectionString)
                conAuth.Open()
                conAuth.ChangeDatabase("AuthServ")

                Dim query As String = "SELECT codus, pass, cliente, sistema, usuario, autorizado, servidor, bd, puerto, modulo, servidor_resp, idInt, debe, mensaje " &
                                      "FROM CliAuth WHERE codus = @user AND (clave = @passMD5 OR clave = @passSHA1)"

                Using comando As New MySqlCommand(query, conAuth)
                    comando.Parameters.AddWithValue("@user", usuario)
                    comando.Parameters.AddWithValue("@passMD5", claveMD5)
                    comando.Parameters.AddWithValue("@passSHA1", claveSHA1)

                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        If lector.Read() Then
                            If Convert.ToInt32(lector("autorizado")) = 1 Then
                                DatosAcceso.pass = lector("pass").ToString()
                                DatosAcceso.Cliente = lector("cliente").ToString()
                                DatosAcceso.sistema = lector("sistema").ToString()
                                DatosAcceso.usuario = lector("usuario").ToString()
                                DatosAcceso.CLOUDserv = lector("servidor").ToString()
                                DatosAcceso.bd = lector("bd").ToString()
                                DatosAcceso.puerto = lector("puerto").ToString()
                                DatosAcceso.Moduloacc = lector("modulo").ToString()
                                DatosAcceso.RESPserv = lector("servidor_resp").ToString()
                                DatosAcceso.UsuarioINT = Convert.ToInt32(lector("idInt"))
                                DatosAcceso.debe = Convert.ToInt32(lector("debe"))
                                DatosAcceso.mensaje = If(IsDBNull(lector("mensaje")), "", lector("mensaje").ToString())
                                Return True
                            Else
                                MsgBox("El servidor indica que no tiene autorización para acceder al sistema.", MsgBoxStyle.Exclamation)
                                Return False
                            End If
                        Else
                            MsgBox("Usuario inexistente o contraseña incorrecta.", MsgBoxStyle.Exclamation)
                            Return False
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error al conectar con el servidor de autenticación: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    ' Conecta a la base de datos principal y secundaria
    Public Shared Function ConectarBaseTrabajo(servidor As String, puerto As String, usuario As String, contraseña As String, bd As String) As Boolean
        Try
            Dim cadenaConexion As String = $"server={servidor};port={puerto};userid={usuario};password={contraseña};database={bd};Allow Zero Datetime=True;Convert Zero Datetime=True;Persist Security Info=True"

            ' 2. INICIALIZAMOS NUESTRAS PROPIAS VARIABLES DE ESTA CLASE
            GestorConexiones.conexionPrinc = New MySqlConnection(cadenaConexion)
            GestorConexiones.conexionSEC = New MySqlConnection(cadenaConexion)
            GestorConexiones.conexionAuth = New MySqlConnection(datosMysql.connectionString)
            GestorConexiones.conexionAuth.Open()
            GestorConexiones.conexionAuth.ChangeDatabase("AuthServ")


            GestorConexiones.conexionPrinc.Open()
            GestorConexiones.conexionSEC.Open()


            Return True
        Catch ex As Exception
            MsgBox("Error al conectar con la base de datos de trabajo: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function
End Class