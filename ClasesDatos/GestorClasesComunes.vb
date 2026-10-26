Imports MySql.Data.MySqlClient

Public Class GestorClasesComunes

    Private Shared ReadOnly Property CadenaConexion As String
        Get
            Return "Server=" & DatosAcceso.CLOUDserv & ";" &
                   "Port=" & DatosAcceso.puerto & ";" &
                   "Database=" & DatosAcceso.bd & ";" &
                   "Uid=" & DatosAcceso.usuario & ";" &
                   "Pwd=" & DatosAcceso.pass & ";" &
                   "Default Command Timeout=300;"
        End Get
    End Property
    ' =========================================================================
    ' 1. CLASE LOCALIDADES
    ' =========================================================================
    Public Class cm_localidades
        Public Property id As Integer
        Public Property nombre As String

        ' --- A. Traer todas las localidades para llenar el ComboBox ---
        Public Shared Function ObtenerTodas() As DataTable
            Dim dt As New DataTable()
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    Dim sql As String = "SELECT id, nombre FROM cm_localidad ORDER BY nombre ASC"
                    Using cmd As New MySqlCommand(sql, conn)
                        Using da As New MySqlDataAdapter(cmd)
                            da.Fill(dt)
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al cargar localidades: " & ex.Message)
            End Try
            Return dt
        End Function

        ' --- B. Verificar si existe ---
        Public Shared Function Existe(nombreBuscado As String) As Boolean
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    Dim sql As String = "SELECT COUNT(*) FROM cm_localidad WHERE nombre = @nombre"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@nombre", nombreBuscado.Trim())
                        conn.Open()
                        Dim cantidad As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        Return cantidad > 0
                    End Using
                End Using
            Catch ex As Exception
                Return False
            End Try
        End Function

        ' --- C. Agregar Nueva ---
        Public Shared Function Agregar(nombreNuevo As String) As Integer
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    Dim sql As String = "INSERT INTO cm_localidad (nombre) VALUES (@nombre)"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@nombre", nombreNuevo.Trim().ToUpper())
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        Return Convert.ToInt32(cmd.LastInsertedId)
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception("Error al insertar localidad: " & ex.Message)
            End Try
        End Function

        ' --- D. Obtener ID por Nombre ---
        Public Shared Function ObtenerIdPorNombre(nombreBuscado As String) As Integer
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    Dim sql As String = "SELECT id FROM cm_localidad WHERE nombre = @nombre LIMIT 1"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@nombre", nombreBuscado.Trim())
                        conn.Open()
                        Dim resultado = cmd.ExecuteScalar()
                        If resultado IsNot Nothing Then
                            Return Convert.ToInt32(resultado)
                        End If
                    End Using
                End Using
            Catch ex As Exception
            End Try
            Return -1
        End Function

        ' --- E. Buscar Por ID (La que usabas en fact_clientes) ---
        Public Shared Function BuscarPorID(idBuscado As Integer) As cm_localidades
            Dim loc As cm_localidades = Nothing
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    Dim sql As String = "SELECT id, nombre FROM cm_localidad WHERE id = @id LIMIT 1"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@id", idBuscado)
                        conn.Open()
                        Using lector As MySqlDataReader = cmd.ExecuteReader()
                            If lector.Read() Then
                                loc = New cm_localidades()
                                loc.id = Convert.ToInt32(lector("id"))
                                loc.nombre = lector("nombre").ToString()
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
            End Try
            Return loc
        End Function

    End Class

    ' =========================================================================
    ' 2. ACÁ A FUTURO PODRÁS AGREGAR:
    ' Public Class fact_ivaTipo ...
    ' Public Class fact_condventas ...
    ' =========================================================================

End Class