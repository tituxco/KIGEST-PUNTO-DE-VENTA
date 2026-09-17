Imports System.Windows.Controls
Imports Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient
Imports SIGT__KIGEST.GestorFacturacion
Imports SIGT__KIGEST.GestorInsumos

Public Class datosEstructura


    ' --- NUEVA LÓGICA DE CONEXIÓN DINÁMICA ---
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


    Public Class fact_vendedor
        Public Property id As Integer
        Public Property nombre As String
        Public Property apellido As String
        Public Property comision As String
        Public Property activo As Integer
        Public Property idListaPrecios As Integer
        Public Property listaPrecios As fact_listaPrecios
        Public Overrides Function ToString() As String
            Return $"{apellido}, {nombre}"
        End Function

        Public Shared Sub Agregar(addID As Integer,
                           addNombre As String,
                           addApellido As String,
                           addComision As String,
                           addActivo As Integer,
                           addListaPrecios As fact_listaPrecios)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New fact_vendedor
                    Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into fact_vendedor (nombre, apellido, comision, activo, listaPrecios) values " & "
                (?nmb,?apell, ?com, ?act, ?lista)", conn)
                        With comandoadd.Parameters
                            .AddWithValue("?nmb", addNombre)
                            .AddWithValue("?apell", addApellido)
                            .AddWithValue("?com", addComision)
                            .AddWithValue("?act", addActivo)
                            .AddWithValue("?lista", addListaPrecios.id)
                        End With
                        comandoadd.ExecuteNonQuery()
                        addID = comandoadd.LastInsertedId
                        lista.id = addID
                        lista.nombre = addNombre
                        lista.apellido = addApellido
                        lista.comision = addComision
                        lista.activo = addActivo
                        lista.listaPrecios = addListaPrecios
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_vendedor)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_vendedor)
                    Using comando As New MySqlCommand("SELECT * from fact_vendedor where activo=1", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_vendedor
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.apellido = lector("apellido").ToString
                                item.comision = lector("comision").ToString
                                item.activo = lector("activo")
                                item.idListaPrecios = lector("listaPrecios")
                                lista.Add(item)
                            End While
                            lector.Close()
                            For Each vend As fact_vendedor In lista
                                vend.listaPrecios = fact_listaPrecios.BuscarPorID(vend.idListaPrecios)
                            Next
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_vendedor
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_vendedor where id = " & idBuscar & " and activo=1 ", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_vendedor
                            If lector.Read() Then
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.apellido = lector("apellido").ToString
                                item.comision = lector("comision").ToString
                                item.activo = lector("activo")
                                item.idListaPrecios = lector("listaPrecios")
                                lector.Close()
                                item.listaPrecios = fact_listaPrecios.BuscarPorID(item.idListaPrecios)
                            End If
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorNombre(nombreBuscar) As List(Of fact_vendedor)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_vendedor where 
                nombre like '%" & nombreBuscar & "%' or apellido like '" & nombreBuscar & "' and activo=1", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim lista As New List(Of fact_vendedor)
                            While lector.Read
                                Dim item As New fact_vendedor
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.apellido = lector("apellido").ToString
                                item.comision = lector("comision").ToString
                                item.activo = lector("activo")
                                item.idListaPrecios = lector("listaPrecios")
                                lista.Add(item)
                            End While
                            lector.Close()
                            For Each vend As fact_vendedor In lista
                                vend.listaPrecios = fact_listaPrecios.BuscarPorID(vend.idListaPrecios)
                            Next
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
    Public Class cm_localidades
        Public Property id As Integer
        Public Property nombre As String
        Public Overrides Function ToString() As String
            Return nombre
        End Function

        Public Shared Sub Agregar(addID As Integer,
                           addNombre As String)

            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim localidad As New cm_localidades
                    Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into cm_localidad (id,nombre) values " & "(?id,?nmb)", conn)
                        With comandoadd.Parameters
                            .AddWithValue("?id", addID)
                            .AddWithValue("?nmb", addNombre)
                        End With
                        comandoadd.ExecuteNonQuery()
                        addID = comandoadd.LastInsertedId
                        localidad.id = addID
                        localidad.nombre = addNombre
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of cm_localidades)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of cm_localidades)
                    Using comando As New MySqlCommand("SELECT * from cm_localidad", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New cm_localidades
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                lista.Add(item)
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
        Public Shared Function BuscarPorID(idBuscar As Integer) As cm_localidades
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from cm_localidad where id=" & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New cm_localidades
                            If lector.Read() Then
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
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
    End Class



    Public Class fact_condventas
        Public Property id As Integer
        Public Property condicion As String
        Public Overrides Function ToString() As String
            Return condicion
        End Function
        Public Shared Function ObtenerTodos() As List(Of fact_condventas)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_condventas)
                    Using comando As New MySqlCommand("SELECT * from fact_condventas", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_condventas
                                item.id = lector("id")
                                item.condicion = lector("condicion").ToString
                                lista.Add(item)
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
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_condventas
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_condventas where id=" & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_condventas
                            If lector.Read() Then
                                item.id = lector("id")
                                item.condicion = lector("condicion").ToString
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
    End Class
    Public Class fact_Empresa
        Public Property idempresa As Integer
        Public Property nombrefantasia As String
        Public Property razonsocial As String
        Public Property direccion As String
        Public Property localidad As String
        Public Property otrosdatos As String
        Public Property cuit As String
        Public Property ingBrutos As String
        Public Property ivatipo As String
        Public Property inicioact As String
        Public Property drei As String
        Public Property logo As Byte()
        Public Property logo2 As Byte()
        Public Property direccioncertificado As String
        Public Property certificado As Byte()
        Public Property passcertificado As String
        Public Property direccionlicencia As String
        Public Property licencia As Byte()

        Public Overrides Function ToString() As String
            Return $"({nombrefantasia}) {razonsocial}"
        End Function

        Public Shared Function ObtenerTodos() As List(Of fact_Empresa)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_Empresa)
                    Using comando As New MySqlCommand("SELECT * from fact_empresa2", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_Empresa
                                item.idempresa = Convert.ToInt32(lector("idempresa"))
                                item.nombrefantasia = lector("nombrefantasia").ToString()
                                item.razonsocial = lector("razonsocial").ToString()
                                item.direccion = lector("direccion").ToString()
                                item.localidad = lector("localidad").ToString()
                                item.otrosdatos = lector("otrosdatos").ToString()
                                item.cuit = lector("cuit").ToString()
                                item.ingBrutos = lector("ingBrutos").ToString()
                                item.ivatipo = lector("ivatipo").ToString()
                                item.inicioact = Convert.ToDateTime(lector("inicioact"))
                                item.drei = lector("drei").ToString()
                                'item.logo = Imagen_Bytes(lector("logo").ToString()
                                'item.logo2 = lector("logo2").ToString()
                                item.direccioncertificado = lector("direccioncertificado").ToString()
                                'item.certificado = lector("certificado").ToString()
                                item.passcertificado = lector("passcertificado").ToString()
                                item.direccionlicencia = lector("direccionlicencia").ToString()
                                'item.licencia = lector("licencia").ToString()
                                lista.Add(item)
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
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_Empresa
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_empresa2 where idempresa = " & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_Empresa
                            If lector.Read() Then
                                item.idempresa = Convert.ToInt32(lector("idempresa"))
                                item.nombrefantasia = lector("nombrefantasia").ToString()
                                item.razonsocial = lector("razonsocial").ToString()
                                item.direccion = lector("direccion").ToString()
                                item.localidad = lector("localidad").ToString()
                                item.otrosdatos = lector("otrosdatos").ToString()
                                item.cuit = lector("cuit").ToString()
                                item.ingBrutos = lector("ingBrutos").ToString()
                                item.ivatipo = lector("ivatipo").ToString()
                                item.inicioact = Convert.ToDateTime(lector("inicioact"))
                                item.drei = lector("drei").ToString()
                                'item.logo = Imagen_Bytes(lector("logo").ToString()
                                'item.logo2 = lector("logo2").ToString()
                                item.direccioncertificado = lector("direccioncertificado").ToString()
                                'item.certificado = lector("certificado").ToString()
                                item.passcertificado = lector("passcertificado").ToString()
                                item.direccionlicencia = lector("direccionlicencia").ToString()
                                'item.licencia = lector("licencia").ToString()
                            End If
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
    End Class



    Public Class fact_Proveedores
        ' Propiedades
        Public Property id As Integer
        Public Property razon As String
        Public Property direccion As String
        Public Property tipo_iva As fact_ivaTipo
        Public Property tipoIvaID As Integer
        Public Property cuit As String
        Public Property informacion_adic As String
        Public Property cuentagastos As cm_planDeCuentas
        Public Property cuentaGastosID As Integer

        ' Sobrescribir ToString para mostrar la Razón Social en ComboBoxes, etc.
        Public Overrides Function ToString() As String
            Return razon
        End Function

        ' Método para Agregar un nuevo proveedor
        Public Shared Sub Agregar(addRazon As String,
                              addDireccion As String,
                              addTipoIva As fact_ivaTipo,
                              addCuit As String,
                              addInfo As String,
                              addCuenta As cm_planDeCuentas)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comandoadd As New MySqlCommand("INSERT INTO fact_proveedores (razon, direccion, tipo_iva, cuit, informacion_adic, cuentagastos) " &
                                                 "VALUES (?razon, ?dir, ?iva, ?cuit, ?info, ?cuenta)", conn)
                        With comandoadd.Parameters
                            .AddWithValue("?razon", addRazon)
                            .AddWithValue("?dir", addDireccion)
                            .AddWithValue("?iva", addTipoIva.id)
                            .AddWithValue("?cuit", addCuit)
                            .AddWithValue("?info", addInfo)
                            .AddWithValue("?cuenta", addCuenta.id)
                        End With
                        comandoadd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al agregar proveedor: " & ex.Message)
            End Try
        End Sub

        ' Método para Obtener todos los registros
        Public Shared Function ObtenerTodos() As List(Of fact_Proveedores)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_Proveedores)
                    Using comando As New MySqlCommand("SELECT * FROM fact_proveedores", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_Proveedores
                                item.id = Convert.ToInt32(lector("id"))
                                item.razon = lector("razon").ToString
                                item.direccion = lector("direccion").ToString
                                item.tipoIvaID = lector("tipo_iva")
                                item.cuit = lector("cuit").ToString
                                item.informacion_adic = lector("informacion_adic").ToString
                                item.cuentaGastosID = lector("cuentagastos")
                                lista.Add(item)
                            End While
                            lector.Close()
                            For Each itm As fact_Proveedores In lista
                                itm.tipo_iva = fact_ivaTipo.BuscarPorID(itm.tipoIvaID)
                                itm.cuentagastos = cm_planDeCuentas.BuscarPorID(itm.cuentaGastosID)
                            Next
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al obtener proveedores: " & ex.Message)
                Return Nothing
            End Try
        End Function

        ' Método para Buscar un proveedor por ID
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_Proveedores
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM fact_proveedores WHERE id = ?id", conn)
                        comando.Parameters.AddWithValue("?id", idBuscar)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_Proveedores
                            If lector.Read() Then
                                item.id = Convert.ToInt32(lector("id"))
                                item.razon = lector("razon").ToString
                                item.direccion = lector("direccion").ToString
                                item.tipoIvaID = lector("tipo_iva")
                                item.cuit = lector("cuit").ToString
                                item.informacion_adic = lector("informacion_adic").ToString
                                item.cuentaGastosID = lector("cuentagastos")
                                lector.Close()

                                item.tipo_iva = fact_ivaTipo.BuscarPorID(item.tipoIvaID)
                                item.cuentagastos = cm_planDeCuentas.BuscarPorID(item.cuentaGastosID)
                            End If
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al buscar proveedor: " & ex.Message)
                Return Nothing
            End Try
        End Function
    End Class
    Public Class fact_categoria_insum
        ' Propiedades
        Public Property id As Integer
        Public Property nombre As String
        Public Property sincro As String

        Public Overrides Function ToString() As String
            Return nombre
        End Function
        ' Método para Agregar
        Public Shared Sub Agregar(addNombre As String, Optional addSincro As String = "1")
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comandoadd As New MySqlCommand("INSERT INTO fact_categoria_insum (nombre, sincro) VALUES (?nom, ?sinc)", conn)
                        With comandoadd.Parameters
                            .AddWithValue("?nom", addNombre)
                            .AddWithValue("?sinc", addSincro)
                        End With
                        comandoadd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al agregar categoría: " & ex.Message)
            End Try
        End Sub
        ' Método para Obtener todas las categorías
        Public Shared Function ObtenerTodos() As List(Of fact_categoria_insum)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_categoria_insum)
                    Using comando As New MySqlCommand("SELECT * FROM fact_categoria_insum", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_categoria_insum
                                item.id = Convert.ToInt32(lector("id"))
                                item.nombre = lector("nombre").ToString
                                item.sincro = lector("sincro").ToString
                                lista.Add(item)
                            End While
                            lector.Close()
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al obtener categorías: " & ex.Message)
                Return Nothing
            End Try
        End Function
        ' Método para Buscar por ID
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_categoria_insum
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM fact_categoria_insum WHERE id = ?id", conn)
                        comando.Parameters.AddWithValue("?id", idBuscar)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_categoria_insum
                            If lector.Read() Then
                                item.id = Convert.ToInt32(lector("id"))
                                item.nombre = lector("nombre").ToString
                                item.sincro = lector("sincro").ToString
                                lector.Close()
                            End If
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al buscar categoría: " & ex.Message)
                Return Nothing
            End Try
        End Function
    End Class

    Public Class cm_planDeCuentas
        ' Propiedades basadas en la estructura de la tabla
        Public Property id As Integer
        Public Property nombreCuenta As String
        Public Property grupo As Integer
        Public Property subGrupo As Integer
        Public Property cuenta As Integer
        Public Property subCuenta As Integer
        Public Property cuentaDetalle As Integer
        ' tinyint(1) se mapea mejor como Boolean
        Public Property cuentaMovimiento As Boolean
        Public Property cuentaResultado As Boolean

        Public Overrides Function ToString() As String
            Return nombreCuenta
        End Function
        ' Método para Agregar un nuevo registro
        Public Shared Sub Agregar(nombre As String, g As Integer, sg As Integer, ct As Integer,
                              sct As Integer, det As Integer, mov As Boolean, res As Boolean)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comandoadd As New MySqlCommand("INSERT INTO cm_planDeCuentas " &
                "(nombreCuenta, grupo, subGrupo, cuenta, subCuenta, cuentaDetalle, cuentaMovimiento, cuentaResultado) " &
                "VALUES (?nom, ?g, ?sg, ?ct, ?sct, ?det, ?mov, ?res)", conn)

                        With comandoadd.Parameters
                            .AddWithValue("?nom", nombre)
                            .AddWithValue("?g", g)
                            .AddWithValue("?sg", sg)
                            .AddWithValue("?ct", ct)
                            .AddWithValue("?sct", sct)
                            .AddWithValue("?det", det)
                            .AddWithValue("?mov", If(mov, 1, 0)) ' Convierte Boolean a tinyint
                            .AddWithValue("?res", If(res, 1, 0))
                        End With
                        comandoadd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al insertar en Plan de Cuentas: " & ex.Message)
            End Try
        End Sub
        ' Método para Obtener todos los registros
        Public Shared Function ObtenerTodos() As List(Of cm_planDeCuentas)
            Try
                Dim lista As New List(Of cm_planDeCuentas)
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    ' Ordenado por la jerarquía contable
                    Dim sql As String = "SELECT * FROM cm_planDeCuentas ORDER BY grupo, subGrupo, cuenta, subCuenta, cuentaDetalle"

                    Using comando As New MySqlCommand(sql, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New cm_planDeCuentas
                                item.id = Convert.ToInt32(lector("id"))
                                item.nombreCuenta = lector("nombreCuenta").ToString
                                item.grupo = Convert.ToInt32(lector("grupo"))
                                item.subGrupo = Convert.ToInt32(lector("subGrupo"))
                                item.cuenta = Convert.ToInt32(lector("cuenta"))
                                item.subCuenta = Convert.ToInt32(lector("subCuenta"))
                                item.cuentaDetalle = Convert.ToInt32(lector("cuentaDetalle"))
                                ' Conversión de tinyint a Boolean
                                item.cuentaMovimiento = Convert.ToBoolean(lector("cuentaMovimiento"))
                                item.cuentaResultado = Convert.ToBoolean(lector("cuentaResultado"))
                                lista.Add(item)
                            End While
                        End Using
                    End Using
                End Using
                Return lista
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As cm_planDeCuentas
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM cm_planDeCuentas WHERE id = ?id", conn)
                        comando.Parameters.AddWithValue("?id", idBuscar)

                        Using lector As MySqlDataReader = comando.ExecuteReader
                            If lector.Read() Then
                                Dim item As New cm_planDeCuentas
                                item.id = Convert.ToInt32(lector("id"))
                                item.nombreCuenta = lector("nombreCuenta").ToString
                                item.grupo = Convert.ToInt32(lector("grupo"))
                                item.subGrupo = Convert.ToInt32(lector("subGrupo"))
                                item.cuenta = Convert.ToInt32(lector("cuenta"))
                                item.subCuenta = Convert.ToInt32(lector("subCuenta"))
                                item.cuentaDetalle = Convert.ToInt32(lector("cuentaDetalle"))
                                item.cuentaMovimiento = Convert.ToBoolean(lector("cuentaMovimiento"))
                                item.cuentaResultado = Convert.ToBoolean(lector("cuentaResultado"))
                                lector.Close()
                                Return item
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al buscar cuenta: " & ex.Message)
                Return Nothing
            End Try
        End Function
        ' Propiedad adicional para obtener el código contable formateado (opcional)
        Public ReadOnly Property CodigoContable As String
            Get
                ' Simula el zerofill: 1.1.01.01.001
                Return $"{grupo}.{subGrupo}.{cuenta:D2}.{subCuenta:D2}.{cuentaDetalle:D3}"
            End Get
        End Property

    End Class
End Class