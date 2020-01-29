'CREO LA INSTANCIA DE MYSQL
Imports MySql.Data.MySqlClient
Module Conexiones
    'CREO LAS VARIABLES GLOBALES DE CONEXION
    Public conexionPrinc As MySqlConnection
    Public conexionSEC As MySqlConnection
    Public conexionAuth As MySqlConnection
    Public conexionColab As MySqlConnection
    'Public conexionEmp As MySqlConnection

    'CREO LAS VARIABLE GLOBALES DE DATOS DE CONEXION
    Public serv As String
    Public port As String
    Public user As String
    Public pass As String
    Public clie As String
    Public clav As String
    Public codus As String
    Public database As String
    Public idInt As Integer
    Public moduloacc As String
    Public idAlmacen As Integer
    Friend comando As MySqlCommand
    Friend leer As MySqlDataReader

    Public Function conectar(ByRef Servidor As String, ByRef Puerto As String, ByRef usuario As String, ByRef contraseña As String, ByRef bd As String) As Boolean
        'REALIZO LA CONEXION CON LOS DATOS OBTENIDOS DEL FORMULARIO INICIALIZAR
        Try
            conexionPrinc = New MySqlConnection
            conexionSEC = New MySqlConnection
            'conexionEmp = New MySqlConnection

            conexionPrinc.ConnectionString = "server=" & Servidor & "; port=" & Puerto & "; userid=" & usuario & "; password=" & contraseña & ";Allow Zero Datetime=True;Convert Zero Datetime=True;Persist Security Info=True"
            'conexionEmp.ConnectionString = conexionPrinc.ConnectionString
            conexionSEC.ConnectionString = conexionPrinc.ConnectionString
            conexionPrinc.Open()
            conexionSEC.Open()
            conexionPrinc.ChangeDatabase(bd)
            conexionSEC.ChangeDatabase(bd)
            'conexionEmp.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function ConectarAuth() As Boolean

        Dim comprobarAuth As New MySqlCommand


        Try
            conexionAuth = New MySqlConnection
            conexionAuth.ConnectionString = "server=authkibit.donweb-remoteip.net; port=3306; userid=kiremoto; password=mecago;Allow Zero Datetime=True;Convert Zero Datetime=True;Persist Security Info=True"
            conexionAuth.Open()

            conexionAuth.ChangeDatabase("AuthServ")

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function ComprobarAuth() As Boolean
        Try
            Dim leerAuth As IDataReader
            Dim i As Integer

            Dim consultaauth As New MySql.Data.MySqlClient.MySqlDataAdapter("select codus, pass,cliente, usuario,autorizado, servidor, bd, puerto,modulo,servidor_resp,idInt from CliAuth where clave like '" & clav & "' and codus like '" & user & "'", conexionAuth)
            Dim tablaauth As New DataTable
            Dim infoauth() As DataRow
            consultaauth.Fill(tablaauth)
            infoauth = tablaauth.Select()
            'txtrazon.Text = infoauth(0)(0)
            If tablaauth.Rows.Count = 0 Then
                MsgBox(" Usuario inexistente o no autorizado")
                Return False
                Exit Function
            End If

            If infoauth(0)(4) = 1 Then
                serv = infoauth(0)(5)
                port = infoauth(0)(7)
                database = infoauth(0)(6)
                user = infoauth(0)(3)
                clie = infoauth(0)(2)
                pass = infoauth(0)(1)
                codus = infoauth(0)(0)
                idInt = infoauth(0)(10)


                DatosAcceso.pass = infoauth(0)(1)
                DatosAcceso.Cliente = infoauth(0)(2)
                DatosAcceso.usuario = infoauth(0)(3)
                DatosAcceso.CLOUDserv = infoauth(0)(5)
                DatosAcceso.bd = infoauth(0)(6)
                DatosAcceso.puerto = infoauth(0)(7)
                DatosAcceso.Moduloacc = infoauth(0)(8)
                DatosAcceso.RESPserv = infoauth(0)(9)
                DatosAcceso.UsuarioINT = infoauth(0)(10)
                'If conectar(serv, port, user, pass, database) = True Then
                'Return True
                'End If
                Return True
            Else
                MsgBox("El servidor de acceso indica que no tiene autorización para acceder al sistema, por favor comuniquese con el administrador")
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Public Function conectarColab() As Boolean
    '    Try
    '        conexionColab = New MySqlConnection

    '        conexionColab.ConnectionString = "server=200.43.113.247; port=3306; userid=kiremoto; password=mecago;Allow Zero Datetime=True;Convert Zero Datetime=True;Persist Security Info=True"
    '        conexionColab.Open()
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try
    'End Function
End Module
