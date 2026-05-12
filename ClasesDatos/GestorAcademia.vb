Imports MySql.Data.MySqlClient
Imports System.Data

Public Class GestorAcademia

    ' --- LÓGICA DE CONEXIÓN DINÁMICA ---
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
    Public Class serv_servicios
        ' Propiedades
        Public Property id As Integer
        Public Property nombre As String
        Public Property otrosDatos As String
        Public Property montoInscripcion As Decimal
        Public Property montoExamen As Decimal
        Public Property montoMensual As Decimal
        Public Property fechaMod As DateTime

        Public Overrides Function ToString() As String
            Return nombre
        End Function

        ' Método Agregar
        Public Shared Sub Agregar(ByRef addID As Integer,
                                   addNombre As String,
                                   addOtrosDatos As String,
                                   addMontoInsc As Decimal,
                                   addMontoExam As Decimal,
                                   addMontoMens As Decimal)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comandoadd As New MySqlCommand("INSERT INTO serv_servicios " &
                    "(nombre, otrosDatos, montoInscripcion, montoExamen, montoMensual) " &
                    "VALUES (?nmb, ?otros, ?insc, ?exam, ?mens)", conn)

                        With comandoadd.Parameters
                            .AddWithValue("?nmb", addNombre)
                            .AddWithValue("?otros", addOtrosDatos)
                            .AddWithValue("?insc", addMontoInsc)
                            .AddWithValue("?exam", addMontoExam)
                            .AddWithValue("?mens", addMontoMens)
                        End With

                        comandoadd.ExecuteNonQuery()
                        addID = comandoadd.LastInsertedId
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al agregar servicio: " & ex.Message)
            End Try
        End Sub

        ' Método ObtenerTodos
        Public Shared Function ObtenerTodos() As List(Of serv_servicios)
            Try
                Dim lista As New List(Of serv_servicios)
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM serv_servicios order by nombre asc", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                lista.Add(MapearServicio(lector))
                            End While
                            lector.Close()
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ' Método BuscarPorID
        Public Shared Function BuscarPorID(idBuscar As Integer) As serv_servicios
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM serv_servicios WHERE id = ?id", conn)
                        comando.Parameters.AddWithValue("?id", idBuscar)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New serv_servicios
                            If lector.Read() Then
                                item = MapearServicio(lector)
                            End If
                            lector.Close()
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ' Método BuscarPorNombre
        Public Shared Function BuscarPorNombre(nombreBuscar As String) As List(Of serv_servicios)
            Try

                Dim lista As New List(Of serv_servicios)
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM serv_servicios WHERE nombre LIKE ?nmb", conn)
                        comando.Parameters.AddWithValue("?nmb", "%" & nombreBuscar & "%")
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                lista.Add(MapearServicio(lector))
                            End While
                            lector.Close()
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function ObtenerReporteServicios() As List(Of ServicioReporte)
            Dim lista As New List(Of ServicioReporte)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim sql As String = "SELECT s.id, s.nombre, s.montoInscripcion, s.montoMensual, s.montoExamen, " &
                            "COUNT(c.id) as cant_alumnos " &
                            "FROM serv_servicios s " &
                            "LEFT JOIN serv_contratos c ON s.id = c.idServicio AND c.activo = 1 " &
                            "GROUP BY s.id " &
                            "ORDER BY s.nombre ASC"

                    Using cmd As New MySqlCommand(sql, conn)
                        Using lector As MySqlDataReader = cmd.ExecuteReader()
                            While lector.Read()
                                Dim rep As New ServicioReporte With {
                        .idServicio = Convert.ToInt32(lector("id")),
                        .nombre = lector("nombre").ToString(),
                        .montoInscripcion = If(IsDBNull(lector("montoInscripcion")), 0D, Convert.ToDecimal(lector("montoInscripcion"))),
                        .montoMensual = If(IsDBNull(lector("montoMensual")), 0D, Convert.ToDecimal(lector("montoMensual"))),
                        .montoExamen = If(IsDBNull(lector("montoExamen")), 0D, Convert.ToDecimal(lector("montoExamen"))),
                        .alumnosActivos = Convert.ToInt32(lector("cant_alumnos"))
                    }
                                lista.Add(rep)
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al obtener listado de servicios: " & ex.Message)
            End Try
            Return lista
        End Function

        Public Shared Function Actualizar(servicio As serv_servicios) As Boolean
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim sql As String = "UPDATE serv_servicios SET " &
                            "nombre = ?nom, " &
                            "montoInscripcion = ?insc, " &
                            "montoMensual = ?men, " &
                            "montoExamen = ?exa " &
                            "WHERE id = ?id"

                    Using cmd As New MySqlCommand(sql, conn)
                        ' Asignamos los valores de las propiedades a los parámetros
                        cmd.Parameters.AddWithValue("?nom", servicio.nombre)
                        cmd.Parameters.AddWithValue("?insc", servicio.montoInscripcion)
                        cmd.Parameters.AddWithValue("?men", servicio.montoMensual)
                        cmd.Parameters.AddWithValue("?exa", servicio.montoExamen)
                        cmd.Parameters.AddWithValue("?id", servicio.id)

                        ' Ejecutamos la actualización
                        Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()

                        ' Si afectó al menos una fila, la actualización fue exitosa
                        Return filasAfectadas > 0
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al actualizar el servicio: " & ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try
        End Function
        ' Función de Mapeo (Siguiendo tu lógica de evitar errores por nulos)
        Private Shared Function MapearServicio(lector As MySqlDataReader) As serv_servicios
            Dim item As New serv_servicios
            item.id = If(IsDBNull(lector("id")), 0, Convert.ToInt32(lector("id")))
            item.nombre = If(IsDBNull(lector("nombre")), "", lector("nombre").ToString)
            item.otrosDatos = If(IsDBNull(lector("otrosDatos")), "", lector("otrosDatos").ToString)

            item.montoInscripcion = If(IsDBNull(lector("montoInscripcion")), 0D, Convert.ToDecimal(lector("montoInscripcion")))
            item.montoExamen = If(IsDBNull(lector("montoExamen")), 0D, Convert.ToDecimal(lector("montoExamen")))
            item.montoMensual = If(IsDBNull(lector("montoMensual")), 0D, Convert.ToDecimal(lector("montoMensual")))

            If Not IsDBNull(lector("fechaMod")) Then
                item.fechaMod = Convert.ToDateTime(lector("fechaMod"))
            End If

            Return item
        End Function
    End Class
    Public Class serv_personas
        ' Propiedades
        Public Property id As Integer
        Public Property nombre_apellido As String
        Public Property dni As String
        Public Property celular As String
        Public Property idCliente As Integer
        Public Property direccion As String

        Public Overrides Function ToString() As String
            Return nombre_apellido
        End Function

        ' Método Agregar
        Public Shared Sub Agregar(ByRef addID As Integer,
                                   addNombre As String,
                                   addDni As String,
                                   addCelular As String,
                                   addIdCliente As Integer,
                                   addDireccion As String)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comandoadd As New MySqlCommand("INSERT INTO serv_personas " &
                    "(nombre_apellido, dni, celular, idCliente, direccion) " &
                    "VALUES (?nmb, ?dni, ?cel, ?idC, ?dir)", conn)

                        With comandoadd.Parameters
                            .AddWithValue("?nmb", addNombre)
                            .AddWithValue("?dni", addDni)
                            .AddWithValue("?cel", addCelular)
                            .AddWithValue("?idC", addIdCliente)
                            .AddWithValue("?dir", addDireccion)
                        End With

                        comandoadd.ExecuteNonQuery()
                        addID = comandoadd.LastInsertedId
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al agregar persona: " & ex.Message)
            End Try
        End Sub

        ' Método ObtenerTodos
        Public Shared Function ObtenerTodos() As List(Of serv_personas)
            Try
                Dim lista As New List(Of serv_personas)
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM serv_personas", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                lista.Add(MapearPersona(lector))
                            End While
                            lector.Close()
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ' Método Buscar por ID
        Public Shared Function BuscarPorID(idBuscar As Integer) As serv_personas
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM serv_personas WHERE id = ?id", conn)
                        comando.Parameters.AddWithValue("?id", idBuscar)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New serv_personas
                            If lector.Read() Then
                                item = MapearPersona(lector)
                            End If
                            lector.Close()
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ' Método Buscar por DNI (Crucial para tu lógica de validación)
        Public Shared Function BuscarPorDNI(dniBuscar As String) As serv_personas
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM serv_personas WHERE dni = ?dni", conn)
                        comando.Parameters.AddWithValue("?dni", dniBuscar)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New serv_personas
                            If lector.Read() Then
                                item = MapearPersona(lector)
                            Else
                                item = Nothing ' Si no existe, devolvemos Nothing para que el Form sepa que debe agregarla
                            End If
                            lector.Close()
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function Guardar(ByRef persona As serv_personas) As Integer
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    If persona.id = 0 Then
                        ' Lógica de Inserción
                        Dim sql As String = "INSERT INTO serv_personas (nombre_apellido, dni, celular, idCliente, direccion) " &
                                        "VALUES (?nmb, ?dni, ?cel, ?idC, ?dir)"

                        Using cmd As New MySqlCommand(sql, conn)
                            With cmd.Parameters
                                .AddWithValue("?nmb", persona.nombre_apellido)
                                .AddWithValue("?dni", persona.dni)
                                .AddWithValue("?cel", persona.celular)
                                .AddWithValue("?idC", persona.idCliente)
                                .AddWithValue("?dir", persona.direccion)
                            End With
                            cmd.ExecuteNonQuery()
                            persona.id = cmd.LastInsertedId ' Actualizamos el ID del objeto
                            Return persona.id
                        End Using
                    Else
                        ' Lógica de Actualización
                        Dim sql As String = "UPDATE serv_personas SET nombre_apellido=?nmb, dni=?dni, " &
                                        "celular=?cel, idCliente=?idC, direccion=?dir WHERE id=?id"

                        Using cmd As New MySqlCommand(sql, conn)
                            With cmd.Parameters
                                .AddWithValue("?nmb", persona.nombre_apellido)
                                .AddWithValue("?dni", persona.dni)
                                .AddWithValue("?cel", persona.celular)
                                .AddWithValue("?idC", persona.idCliente)
                                .AddWithValue("?dir", persona.direccion)
                                .AddWithValue("?id", persona.id)
                            End With
                            cmd.ExecuteNonQuery()
                            Return persona.id
                        End Using

                    End If
                End Using
            Catch ex As Exception
                Return 0
                MsgBox("Error al guardar la persona: " & ex.Message)
            End Try
        End Function

        Public Shared Function ObtenerEstadoGeneralAlumnos() As List(Of AlumnoEstadoReporte)
            Dim lista As New List(Of AlumnoEstadoReporte)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    ' Ya no usamos CAST(d.monto) porque ahora es Decimal nativo
                    Dim sql As String = "SELECT
                                    c.id as idContrato,
                                    p.id, 
                                    p.nombre_apellido, 
                                    p.dni, 
                                    s.nombre as curso,
                                    SUM(CASE WHEN d.estado = 'PENDIENTE' AND d.vencimiento <= CURDATE() 
                                             THEN d.monto ELSE 0 END) as total_deuda,
                                    COUNT(CASE WHEN d.estado = 'PENDIENTE' AND d.vencimiento <= CURDATE() 
                                             THEN 1 END) as cant_vencidas
                                 FROM serv_personas p
                                 INNER JOIN serv_contratos c ON p.id = c.idPersona 
                                 INNER JOIN serv_servicios s ON c.idServicio = s.id
                                 LEFT JOIN serv_detalle d ON c.id = d.idContrato
                                 WHERE c.activo = 1
                                 GROUP BY p.id, s.id
                                 ORDER BY p.nombre_apellido ASC"

                    Using cmd As New MySqlCommand(sql, conn)
                        Using lector As MySqlDataReader = cmd.ExecuteReader
                            While lector.Read
                                Dim r As New AlumnoEstadoReporte
                                r.idContrato = Convert.ToInt32(lector("idContrato"))
                                r.idPersona = Convert.ToInt32(lector("id"))
                                r.nombre_apellido = lector("nombre_apellido").ToString
                                r.dni = lector("dni").ToString
                                r.nombreCurso = lector("curso").ToString

                                ' Al ser decimal en la BD, la lectura es directa y segura
                                r.totalPendiente = If(IsDBNull(lector("total_deuda")), 0D, Convert.ToDecimal(lector("total_deuda")))
                                r.cuotasVencidas = If(IsDBNull(lector("cant_vencidas")), 0, Convert.ToInt32(lector("cant_vencidas")))

                                lista.Add(r)
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error en reporte: " & ex.Message)
            End Try
            Return lista
        End Function

        Public Shared Function ObtenerAlumnosParaABM() As List(Of AlumnoAbmReporte)
            Dim lista As New List(Of AlumnoAbmReporte)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    ' Consulta que cuenta cuántos contratos activos tiene cada persona
                    Dim sql As String = "SELECT p.id, p.nombre_apellido, p.dni, p.celular, " &
                            "COUNT(c.id) as cantidad_activos " &
                            "FROM serv_personas p " &
                            "LEFT JOIN serv_contratos c ON p.id = c.idPersona AND c.activo = 1 " &
                            "GROUP BY p.id " &
                            "ORDER BY p.nombre_apellido ASC"

                    Using cmd As New MySqlCommand(sql, conn)
                        Using lector As MySqlDataReader = cmd.ExecuteReader
                            While lector.Read
                                Dim alu As New AlumnoAbmReporte With {
                        .idPersona = Convert.ToInt32(lector("id")),
                        .nombre_apellido = lector("nombre_apellido").ToString,
                        .dni = lector("dni").ToString,
                        .celular = lector("celular").ToString
                    }

                                Dim cant As Integer = Convert.ToInt32(lector("cantidad_activos"))
                                alu.cursosActivos = If(cant > 0, "SÍ (" & cant & ")", "NO")

                                lista.Add(alu)
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al obtener listado ABM: " & ex.Message)
            End Try
            Return lista
        End Function

        Public Shared Function Actualizar(p As serv_personas) As Boolean
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim sql As String = "UPDATE serv_personas SET nombre_apellido=?nom, dni=?dni, celular=?cel, direccion=?dir, idCliente=?idClie WHERE id=?id"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("?nom", p.nombre_apellido)
                        cmd.Parameters.AddWithValue("?dni", p.dni)
                        cmd.Parameters.AddWithValue("?cel", p.celular)
                        cmd.Parameters.AddWithValue("?dir", p.direccion)
                        cmd.Parameters.AddWithValue("?idClie", p.idCliente)
                        cmd.Parameters.AddWithValue("?id", p.id)
                        cmd.ExecuteNonQuery()
                    End Using
                    Return True
                End Using
            Catch ex As Exception
                MsgBox("Error SQL: " & ex.Message)
                Return False
            End Try
        End Function
        ' Función de Mapeo Blindada
        Private Shared Function MapearPersona(lector As MySqlDataReader) As serv_personas
            Dim item As New serv_personas

            item.id = If(IsDBNull(lector("id")), 0, Convert.ToInt32(lector("id")))
            item.nombre_apellido = If(IsDBNull(lector("nombre_apellido")), "", lector("nombre_apellido").ToString)
            item.dni = If(IsDBNull(lector("dni")), "", lector("dni").ToString)
            item.celular = If(IsDBNull(lector("celular")), "", lector("celular").ToString)
            item.idCliente = If(IsDBNull(lector("idCliente")), 0, Convert.ToInt32(lector("idCliente")))
            item.direccion = If(IsDBNull(lector("direccion")), "", lector("direccion").ToString)
            Return item
        End Function
    End Class
    Public Class serv_contratos
        ' Propiedades
        Public Property id As Integer
        Public Property idServicio As Integer
        Public Property idPersona As Integer
        Public Property periodo As Integer
        Public Property mesInicio As String
        Public Property mesFin As String
        Public Property montoInscripcion As Decimal
        Public Property montoExamen As Decimal
        Public Property montoMensual As Decimal
        Public Property activo As Integer


        Public Shared Function Guardar(nuevoContrato As serv_contratos) As Integer
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim sql As String = "INSERT INTO serv_contratos " &
                    "(idServicio, idPersona,periodo, mesInicio, mesFin, montoInscripcion, montoExamen, montoMensual, activo) " &
                    "VALUES (?idS, ?idP,?per, ?mI, ?mF, ?mIns, ?mEx, ?mMen, ?act)"

                    Using cmd As New MySqlCommand(sql, conn)
                        With cmd.Parameters
                            .AddWithValue("?idS", nuevoContrato.idServicio)
                            .AddWithValue("?idP", nuevoContrato.idPersona)
                            .AddWithValue("?per", nuevoContrato.periodo)
                            .AddWithValue("?mI", nuevoContrato.mesInicio)
                            .AddWithValue("?mF", nuevoContrato.mesFin)
                            .AddWithValue("?mIns", nuevoContrato.montoInscripcion)
                            .AddWithValue("?mEx", nuevoContrato.montoExamen)
                            .AddWithValue("?mMen", nuevoContrato.montoMensual)
                            .AddWithValue("?act", 1) ' Por defecto activo
                        End With

                        cmd.ExecuteNonQuery()
                        Return cmd.LastInsertedId ' Retornamos el ID para generar las cuotas luego
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al registrar contrato: " & ex.Message)
                Return 0
            End Try
        End Function
        Public Shared Sub ActualizarMontos(idC As Integer, montoMen As Decimal, montoExa As Decimal)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using cmd As New MySqlCommand("UPDATE serv_contratos SET montoMensual = ?men, montoExamen = ?exa WHERE id = ?id", conn)
                        cmd.Parameters.AddWithValue("?men", montoMen)
                        cmd.Parameters.AddWithValue("?exa", montoExa)
                        cmd.Parameters.AddWithValue("?id", idC)

                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al actualizar montos en contrato: " & ex.Message)
            End Try
        End Sub
        Public Shared Function BuscarPorID(idBusca As Integer) As serv_contratos
            Dim item As serv_contratos = Nothing
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM serv_contratos WHERE id = ?id", conn)
                        comando.Parameters.AddWithValue("?id", idBusca)

                        Using lector As MySqlDataReader = comando.ExecuteReader
                            If lector.Read() Then
                                ' Llamamos a tu método existente
                                item = MapearContrato(lector)
                            End If
                            lector.Close()
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al buscar contrato por ID: " & ex.Message)
                Return Nothing
            End Try
            Return item
        End Function
        ''' <summary>
        ''' Cambia el estado de una inscripción específica a Inactivo.
        ''' </summary>
        Public Shared Function DesactivarInscripcion(idContrato As Integer) As Boolean
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    ' Usamos 0 para inactivo y 1 para activo
                    Dim sql As String = "UPDATE serv_contratos SET activo = 0 WHERE id = ?id"

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("?id", idContrato)
                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al procesar la baja: " & ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try
        End Function
        Private Shared Function MapearContrato(lector As MySqlDataReader) As serv_contratos
            Dim item As New serv_contratos
            item.id = If(IsDBNull(lector("id")), 0, Convert.ToInt32(lector("id")))
            item.idServicio = If(IsDBNull(lector("idServicio")), 0, Convert.ToInt32(lector("idServicio")))
            item.idPersona = If(IsDBNull(lector("idPersona")), 0, Convert.ToInt32(lector("idPersona")))
            item.periodo = If(IsDBNull(lector("periodo")), 0, Convert.ToInt32(lector("periodo")))
            item.mesInicio = If(IsDBNull(lector("mesInicio")), "MARZO", lector("mesInicio").ToString)
            item.mesFin = If(IsDBNull(lector("mesFin")), "DICIEMBRE", lector("mesFin").ToString)
            item.montoInscripcion = If(IsDBNull(lector("montoInscripcion")), 0D, Convert.ToDecimal(lector("montoInscripcion")))
            item.montoExamen = If(IsDBNull(lector("montoExamen")), 0D, Convert.ToDecimal(lector("montoExamen")))
            item.montoMensual = If(IsDBNull(lector("montoMensual")), 0D, Convert.ToDecimal(lector("montoMensual")))
            item.activo = If(IsDBNull(lector("activo")), 1, Convert.ToInt32(lector("activo")))
            Return item
        End Function
    End Class
    Public Class serv_detalle
        ' Propiedades
        Public Property id As Integer
        Public Property idContrato As Integer
        Public Property idPersona As Integer
        Public Property detalle As String
        Public Property monto As String ' Mantenemos String según tu CREATE TABLE
        Public Property vencimiento As DateTime
        Public Property estado As String

        ' Método para insertar una cuota individual
        Public Shared Sub Agregar(nuevo As serv_detalle)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using cmd As New MySqlCommand("INSERT INTO serv_detalle (idContrato, idPersona, detalle, monto, vencimiento, estado) " &
                                             "VALUES (?idC, ?idP, ?det, ?mon, ?venc, ?est)", conn)
                        With cmd.Parameters
                            .AddWithValue("?idC", nuevo.idContrato)
                            .AddWithValue("?idP", nuevo.idPersona)
                            .AddWithValue("?det", nuevo.detalle)
                            .AddWithValue("?mon", nuevo.monto)
                            .AddWithValue("?venc", nuevo.vencimiento.ToString("yyyy-MM-dd"))
                            .AddWithValue("?est", nuevo.estado)
                        End With
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al insertar detalle: " & ex.Message)
            End Try
        End Sub

        Public Shared Function RegistrarPago(idDetalle As Integer, Optional idComprobanteFacturacion As Integer = 0) As Boolean
            Try
                ' Si querés guardar la fecha de pago o el comprobante, podés agregar esas columnas a tu tabla
                ' Ejemplo ampliado: "UPDATE serv_detalle SET estado = 'PAGADO', fechaPago = CURDATE(), idFactura = ?idFac WHERE id = ?id"
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim sql As String = "UPDATE serv_detalle SET estado = 'PAGADO' WHERE id = ?id"

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("?id", idDetalle)

                        ' Si en el futuro agregás la columna idFactura a serv_detalle, descomentá esto:
                        ' cmd.Parameters.AddWithValue("?idFac", If(idComprobanteFacturacion > 0, idComprobanteFacturacion, DBNull.Value))

                        Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                        Return filasAfectadas > 0
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al registrar el pago: " & ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try
        End Function

        Public Shared Function ActualizarEstado(idDetalle As Integer, nuevoEstado As String) As Boolean
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim sql As String = "UPDATE serv_detalle SET estado = ?est WHERE id = ?id"

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("?est", nuevoEstado)
                        cmd.Parameters.AddWithValue("?id", idDetalle)

                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al cambiar estado: " & ex.Message)
                Return False
            End Try
        End Function
        ' Obtener la lista de cuotas de un alumno
        Public Shared Function ObtenerDeudaPorAlumno(idPer As Integer) As List(Of serv_detalle)
            Dim lista As New List(Of serv_detalle)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using cmd As New MySqlCommand("SELECT * FROM serv_detalle WHERE idPersona = ?id ORDER BY id ASC", conn)
                        cmd.Parameters.AddWithValue("?id", idPer)
                        Using lector As MySqlDataReader = cmd.ExecuteReader
                            While lector.Read
                                lista.Add(MapearDetalle(lector))
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return lista
        End Function
        Public Shared Function CalcularPlanSimulado(ByRef servicio As serv_servicios, ByRef fechaInicio As DateTime) As List(Of serv_detalle)
            Dim listaSimulada As New List(Of serv_detalle)

            ' 1. Agregar Inscripción (Vence hoy)
            Dim insc As New serv_detalle With {
                .detalle = "INSCRIPCION",
                .monto = servicio.montoInscripcion,
                .vencimiento = fechaInicio,
                .estado = "PENDIENTE"
            }
            listaSimulada.Add(insc)

            ' 2. Generar cuotas 
            'hasta diciembre
            Dim mesInicio As Integer = fechaInicio.Month
            Dim mesFin As Integer = 12

            If mesInicio < 3 Then
                mesInicio = 3
                fechaInicio = New DateTime(fechaInicio.Year, mesInicio, 1)
            End If
            Dim j As Integer = 0
            For i As Integer = mesInicio To mesFin
                Dim fechaCuota As DateTime = fechaInicio.AddMonths(j)
                ' Vencimiento fijo los días 10
                Dim vencimientoEfectivo As New DateTime(fechaCuota.Year, fechaCuota.Month, 10)

                Dim cuota As New serv_detalle With {
            .detalle = "CUOTA " & vencimientoEfectivo.ToString("MMMM").ToUpper() & " " & vencimientoEfectivo.Year,
            .monto = servicio.montoMensual,
            .vencimiento = vencimientoEfectivo,
            .estado = "PENDIENTE"
            }
                listaSimulada.Add(cuota)
                j += 1
            Next

            Dim examen As New serv_detalle With {
            .detalle = "DERECHO A EXAMEN",
            .monto = servicio.montoExamen,
            .vencimiento = New DateTime(fechaInicio.Year, 12, 15),
            .estado = "PENDIENTE"
            }
            listaSimulada.Add(examen)
            Return listaSimulada
        End Function
        Public Shared Sub GenerarPlanCuotas(contrato As serv_contratos, fechaInicioSeleccionada As DateTime)
            Try
                Dim anioContrato As Integer = fechaInicioSeleccionada.Year

                ' 1. Generar Inscripción (Vence hoy/momento del contrato)
                Dim insc As New serv_detalle With {
            .idContrato = contrato.id,
            .idPersona = contrato.idPersona,
            .detalle = "INSCRIPCION",
            .monto = contrato.montoInscripcion,
            .vencimiento = DateTime.Now,
            .estado = "PENDIENTE"
        }
                Agregar(insc)

                ' 2. Determinar mes de inicio (Mínimo Marzo)
                Dim mesInicio As Integer = fechaInicioSeleccionada.Month
                If mesInicio < 3 Then mesInicio = 3

                ' 3. Generar Cuotas Mensuales hasta Diciembre
                For m As Integer = mesInicio To 12
                    Dim cuota As New serv_detalle With {
                .idContrato = contrato.id,
                .idPersona = contrato.idPersona,
                .detalle = "CUOTA " & New DateTime(anioContrato, m, 1).ToString("MMMM").ToUpper() & " " & anioContrato,
                .monto = contrato.montoMensual,
                .vencimiento = New DateTime(anioContrato, m, 10), ' Vencimiento día 10
                .estado = "PENDIENTE"
            }
                    Agregar(cuota)
                Next

                ' 4. Generar Derecho a Examen (15 de Diciembre)
                If contrato.montoExamen > 0 Then
                    Dim examen As New serv_detalle With {
                .idContrato = contrato.id,
                .idPersona = contrato.idPersona,
                .detalle = "DERECHO A EXAMEN",
                .monto = contrato.montoExamen,
                .vencimiento = New DateTime(anioContrato, 12, 15),
                .estado = "PENDIENTE"
            }
                    Agregar(examen)
                End If

            Catch ex As Exception
                MsgBox("Error al generar plan completo en BD: " & ex.Message)
            End Try
        End Sub
        Public Shared Sub ActualizarPendientes(idC As Integer, mMen As Decimal, mEx As Decimal)

            Using conn As New MySqlConnection(CadenaConexion)
                conn.Open()
                ' Actualizamos cuotas mensuales pendientes
                Dim sqlCuotas = "UPDATE serv_detalle SET monto=?m WHERE idContrato=?id AND estado='PENDIENTE' AND detalle LIKE 'CUOTA%'"
                Using cmd As New MySqlCommand(sqlCuotas, conn)
                    cmd.Parameters.AddWithValue("?m", mMen)
                    cmd.Parameters.AddWithValue("?id", idC)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Using conn As New MySqlConnection(CadenaConexion)
                conn.Open()
                ' Actualizamos derecho a examen pendiente
                Dim sqlExamen = "UPDATE serv_detalle SET monto=?e WHERE idContrato=?id AND estado='PENDIENTE' AND detalle='DERECHO A EXAMEN'"
                Using cmd As New MySqlCommand(sqlExamen, conn)
                    cmd.Parameters.AddWithValue("?e", mEx)
                    cmd.Parameters.AddWithValue("?id", idC)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub
        Private Shared Function MapearDetalle(lector As MySqlDataReader) As serv_detalle
            Dim item As New serv_detalle
            item.id = If(IsDBNull(lector("id")), 0, Convert.ToInt32(lector("id")))
            item.idContrato = If(IsDBNull(lector("idContrato")), 0, Convert.ToInt32(lector("idContrato")))
            item.idPersona = If(IsDBNull(lector("idPersona")), 0, Convert.ToInt32(lector("idPersona")))
            item.detalle = If(IsDBNull(lector("detalle")), "", lector("detalle").ToString)
            item.monto = If(IsDBNull(lector("monto")), 0D, Convert.ToDecimal(lector("monto"))) ' Cambiado a Decimal
            item.vencimiento = If(IsDBNull(lector("vencimiento")), DateTime.MinValue, Convert.ToDateTime(lector("vencimiento")))
            item.estado = If(IsDBNull(lector("estado")), "PENDIENTE", lector("estado").ToString)
            Return item
        End Function
    End Class
    Public Class AlumnoEstadoReporte
        Public Property idContrato As Integer
        Public Property idPersona As Integer
        Public Property nombre_apellido As String
        Public Property dni As String
        Public Property nombreCurso As String
        Public Property totalPendiente As Decimal
        Public Property cuotasVencidas As Integer

        ' Propiedad calculada para la interfaz
        Public ReadOnly Property estadoFinanciero As String
            Get
                If cuotasVencidas > 0 Then
                    Return "DEUDA: $" & totalPendiente.ToString("N2") & " (" & cuotasVencidas & " cuotas)"
                Else
                    Return "AL DÍA"
                End If
            End Get
        End Property
    End Class
    Public Class AlumnoAbmReporte
        Public Property idPersona As Integer
        Public Property nombre_apellido As String
        Public Property dni As String
        Public Property celular As String
        Public Property cursosActivos As String ' Dirá "SÍ (X)" o "NO"
    End Class
    Public Class ServicioReporte
        Public Property idServicio As Integer
        Public Property nombre As String
        Public Property montoInscripcion As Decimal
        Public Property montoMensual As Decimal
        Public Property montoExamen As Decimal
        Public Property alumnosActivos As Integer
    End Class
End Class