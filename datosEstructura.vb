Imports System.Windows.Controls
Imports Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient

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

    Public Class fact_clientes
        Public Property idCliente As Integer
        Public Property nomapellRazon As String
        Public Property dirDomicilio As String
        Public Property idLocalidad As Integer
        Public Property idIvaTipo As Integer
        Public Property idListaPrecios As Integer
        Public Property idVendedor As Integer
        Public Property dirLocalidad As cm_localidades
        Public Property ivaTipo As fact_ivaTipo
        Public Property listaPrecios As fact_listaPrecios
        Public Property vendedor As fact_vendedor
        Public Property cuit As String
        Public Property telefono As String
        Public Property contacto As String
        Public Property celular As String
        Public Property email As String
        Public Property observaciones As String
        Public Property codClie As String
        Public Property f_alta As Date
        Public Property f_mod As Date

        Public Overrides Function ToString() As String
            Return $"({idCliente }) {nomapellRazon}"
        End Function
        Public Shared Sub Agregar(addID As Integer,
                           addNomApellRazon As String,
                           addDomicilio As String,
                           addDirLocalidad As cm_localidades,
                           addIvaTipo As fact_ivaTipo,
                           addListaPrecios As fact_listaPrecios,
                           addVendedor As fact_vendedor,
                           addCuit As Integer,
                           addTelefono As String,
                           addcelular As String,
                           addContacto As String,
                           addEmail As String,
                           addObservaciones As String,
                           addCodClie As String)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim cliente As New fact_clientes
                    ' Reconectar()
                    Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("INSERT INTO fact_clientes 
                (nomapell_razon, dir_domicilio, dir_localidad, iva_tipo, cuit, telefono, contacto, celular, email, observaciones, 
                lista_precios, codClie, vendedor) VALUES
                (?nmb,?domi, ?loca, ?iva, ?cuit,?tel,?cont,?celu,?mail,?obs,?listP,?codClie,?vend)", conn)
                        With comandoadd.Parameters
                            .AddWithValue("?nmb", addNomApellRazon)
                            .AddWithValue("?domi", addDomicilio)
                            .AddWithValue("?loca", addDirLocalidad.id)
                            .AddWithValue("?iva", addIvaTipo.id)
                            .AddWithValue("?cuit", addCuit)
                            .AddWithValue("?tel", addTelefono)
                            .AddWithValue("?cont", addContacto)
                            .AddWithValue("?celu", addcelular)
                            .AddWithValue("?mail", addEmail)
                            .AddWithValue("?obs", addObservaciones)
                            .AddWithValue("?listP", addListaPrecios.id)
                            .AddWithValue("?codCLie", addCodClie)
                            .AddWithValue("?vend", addVendedor.id)
                        End With
                        comandoadd.ExecuteNonQuery()
                        addID = comandoadd.LastInsertedId
                        cliente.idCliente = addID
                        cliente.nomapellRazon = addNomApellRazon
                        cliente.dirDomicilio = addDomicilio
                        cliente.dirLocalidad = addDirLocalidad
                        cliente.ivaTipo = addIvaTipo
                        cliente.cuit = addCuit
                        cliente.telefono = addTelefono
                        cliente.contacto = addContacto
                        cliente.celular = addcelular
                        cliente.email = addEmail
                        cliente.observaciones = addObservaciones
                        cliente.listaPrecios = addListaPrecios
                        cliente.codClie = addCodClie
                        cliente.vendedor = addVendedor
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_clientes)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_clientes)
                    Using comando As New MySqlCommand("SELECT * from fact_clientes", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_clientes
                                item.idCliente = lector("idclientes")
                                item.nomapellRazon = lector("nomapell_razon").ToString
                                item.dirDomicilio = lector("dir_domicilio").ToString
                                item.cuit = lector("cuit").ToString
                                item.telefono = lector("telefono").ToString
                                item.contacto = lector("contacto").ToString
                                item.celular = lector("celular").ToString
                                item.email = lector("email").ToString
                                item.observaciones = lector("observaciones").ToString
                                item.codClie = lector("codClie").ToString
                                item.idListaPrecios = lector("lista_precios")
                                item.idIvaTipo = lector("iva_tipo")
                                item.idLocalidad = lector("dir_localidad")
                                item.idVendedor = lector("vendedor")
                                lista.Add(item)
                            End While
                            lector.Close()
                            For Each item As fact_clientes In lista
                                item.dirLocalidad = cm_localidades.BuscarPorID(item.idLocalidad)
                                item.vendedor = fact_vendedor.BuscarPorID(item.idVendedor)
                                item.ivaTipo = fact_ivaTipo.BuscarPorID(item.idIvaTipo)
                                item.listaPrecios = fact_listaPrecios.BuscarPorID(item.idListaPrecios)
                            Next
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_clientes
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_clientes where idclientes=" & idBuscar, conn)
                        Dim item As New fact_clientes
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            If lector.Read() Then
                                item.idCliente = lector("idclientes")
                                item.nomapellRazon = lector("nomapell_razon").ToString
                                item.dirDomicilio = lector("dir_domicilio").ToString
                                item.cuit = lector("cuit").ToString
                                item.telefono = lector("telefono").ToString
                                item.contacto = lector("contacto").ToString
                                item.celular = lector("celular").ToString
                                item.email = lector("email").ToString
                                item.observaciones = lector("observaciones").ToString
                                item.codClie = lector("codClie").ToString
                                item.idListaPrecios = lector("lista_precios")
                                item.idIvaTipo = lector("iva_tipo")
                                item.idLocalidad = lector("dir_localidad")
                                item.idVendedor = lector("vendedor")
                                lector.Close()
                                item.listaPrecios = fact_listaPrecios.BuscarPorID(item.idListaPrecios)
                                item.vendedor = fact_vendedor.BuscarPorID(item.idVendedor)
                                item.dirLocalidad = cm_localidades.BuscarPorID(item.idLocalidad)
                                item.ivaTipo = fact_ivaTipo.BuscarPorID(item.idIvaTipo)
                                Return item
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Console.WriteLine("error mod cliente: " & ex.Message)
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorNombre(nombreBuscar As String) As List(Of fact_clientes)
            Dim lista As New List(Of fact_clientes)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    ' Traemos todo con JOIN para que sea UNA SOLA consulta
                    Dim sql As String = "SELECT c.*, l.nombre as nom_loc, v.apellido as ape_vend, v.nombre as nom_vend, i.tipo as nom_iva, lp.nombre as nom_lista " &
                                        "FROM fact_clientes c " &
                                        "LEFT JOIN cm_localidad l ON c.dir_localidad = l.id " &
                                        "LEFT JOIN fact_vendedor v ON c.vendedor = v.id " &
                                        "LEFT JOIN fact_ivatipo i ON c.iva_tipo = i.id " &
                                        "LEFT JOIN fact_listas_precio lp ON c.lista_precios = lp.id " &
                                        "WHERE c.nomapell_razon LIKE @busq OR c.cuit LIKE @busq"

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@busq", "%" & nombreBuscar & "%")
                        Using lector As MySqlDataReader = cmd.ExecuteReader
                            While lector.Read
                                Dim cli As New fact_clientes
                                ' Mapeo básico
                                cli.idCliente = Convert.ToInt32(lector("idclientes"))
                                cli.nomapellRazon = lector("nomapell_razon").ToString()
                                cli.cuit = lector("cuit").ToString()

                                ' CARGA INSTANTÁNEA: Creamos los objetos hijos con los datos del JOIN
                                ' Así evitamos volver a consultar la base de datos
                                cli.dirLocalidad = New cm_localidades With {.id = Convert.ToInt32(lector("dir_localidad")), .nombre = lector("nom_loc").ToString()}
                                cli.vendedor = New fact_vendedor With {.id = Convert.ToInt32(lector("vendedor")), .apellido = lector("ape_vend").ToString(), .nombre = lector("nom_vend").ToString()}
                                cli.ivaTipo = New fact_ivaTipo With {.id = Convert.ToInt32(lector("iva_tipo")), .nombre = lector("nom_iva").ToString()}
                                cli.listaPrecios = New fact_listaPrecios With {.id = Convert.ToInt32(lector("lista_precios")), .nombre = lector("nom_lista").ToString()}

                                lista.Add(cli)
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error en búsqueda: " & ex.Message)
            End Try
            Return lista
        End Function
    End Class
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
    Public Class fact_ivaTipo
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
                    Dim tipo As New fact_ivaTipo
                    Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into fact_ivatipo (id,nombre) values " & "(?id,?nmb)", conn)
                        With comandoadd.Parameters
                            .AddWithValue("?id", addID)
                            .AddWithValue("?nmb", addNombre)
                        End With
                        comandoadd.ExecuteNonQuery()
                        addID = comandoadd.LastInsertedId
                        tipo.id = addID
                        tipo.nombre = addNombre
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_ivaTipo)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_ivaTipo)
                    Using comando As New MySqlCommand("SELECT * from fact_ivatipo", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_ivaTipo
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
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_ivaTipo
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_ivatipo where id=" & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_ivaTipo
                            If lector.Read() Then
                                item.id = lector("id")
                                item.nombre = lector("tipo").ToString
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
    Public Class fact_listaPrecios
        Public Property id As Integer
        Public Property nombre As String
        Public Property utilidad As String
        Public Property auxcol As Integer
        Public Overrides Function ToString() As String
            Return nombre
        End Function

        Public Shared Sub Agregar(addID As Integer,
                           addNombre As String,
                           addUtilidad As String,
                           addAuxCol As Integer)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim listaP As New fact_listaPrecios
                    Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into fact_listas_precio (nombre,utilidad,auxcol) values " & "(?nmb,?util,?auxCol)", conn)
                        With comandoadd.Parameters
                            .AddWithValue("?nmb", addNombre)
                            .AddWithValue("?util", addUtilidad)
                            .AddWithValue("?auxCol", addAuxCol)
                        End With
                        comandoadd.ExecuteNonQuery()
                        addID = comandoadd.LastInsertedId
                        listaP.id = addID
                        listaP.nombre = addNombre
                        listaP.utilidad = addUtilidad
                        listaP.auxcol = addAuxCol
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_listaPrecios)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_listaPrecios)
                    Using comando As New MySqlCommand("SELECT * from fact_listas_precio", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_listaPrecios
                                item.id = lector("id")
                                item.nombre = lector("nombre")
                                item.utilidad = lector("utilidad")
                                item.auxcol = lector("auxcol")
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
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_listaPrecios
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_listas_precio where id =" & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_listaPrecios
                            If lector.Read() Then
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.utilidad = lector("utilidad").ToString
                                item.auxcol = lector("auxcol")
                                lector.Close()
                            End If
                            Return item
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorNombre(nombreBuscar) As List(Of fact_listaPrecios)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_listas_precio where nombre like '%" & nombreBuscar & "%'", conn)
                        Dim lista As New List(Of fact_listaPrecios)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_listaPrecios
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.utilidad = lector("utilidad").ToString
                                item.auxcol = lector("auxcol")
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
    End Class
    Public Class fact_insumos_almacenes
        Public Property id As Integer
        Public Property nombre As String
        Public Property lugar As String
        Public Property otroDatos As String
        Public Overrides Function ToString() As String
            Return nombre
        End Function

        Public Shared Sub Agregar(addID As Integer,
                                  addNombre As String,
                                  addLugar As String,
                                  addDatos As String)

            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim almacen As New fact_insumos_almacenes
                    Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into cm_localidad (nombre,lugar,otrosDatos) values " & "(?nmb,?lugar,?otros)", conn)
                        With comandoadd.Parameters
                            .AddWithValue("?nmb", addNombre)
                            .AddWithValue("?lugar", addLugar)
                            .AddWithValue("?otros", addDatos)
                        End With
                        comandoadd.ExecuteNonQuery()
                        addID = comandoadd.LastInsertedId
                        almacen.id = addID
                        almacen.nombre = addNombre
                        almacen.lugar = addLugar
                        almacen.otroDatos = addDatos
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_insumos_almacenes)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_insumos_almacenes)
                    Using comando As New MySqlCommand("SELECT * from fact_insumos_almacenes", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_insumos_almacenes
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.lugar = lector("lugar").ToString
                                item.otroDatos = lector("otrosDatos").ToString
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
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_insumos_almacenes
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_insumos_almacenes where id=" & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_insumos_almacenes
                            If lector.Read() Then
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.nombre = lector("lugar").ToString
                                item.nombre = lector("otrosDatos").ToString
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
    Public Class fact_puntosventa
        Public Property id As Integer
        Public Property numero As Integer
        Public Property descripcion As String
        Public Property idEmpresa As Integer
        Public Property empresa As fact_Empresa
        Public Overrides Function ToString() As String
            Return $"({numero}) {descripcion}"
        End Function

        Public Shared Function ObtenerTodos() As List(Of fact_puntosventa)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_puntosventa)
                    Using comando As New MySqlCommand("SELECT * from fact_puntosventa", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_puntosventa
                                item.id = lector("id")
                                item.numero = lector("numero").ToString
                                item.descripcion = lector("descripcion").ToString
                                item.idEmpresa = lector("idEmpresa")
                                lista.Add(item)
                            End While
                            lector.Close()
                            For Each pto As fact_puntosventa In lista
                                pto.empresa = fact_Empresa.BuscarPorID(pto.idEmpresa)
                            Next
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_puntosventa
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_puntosventa where id = " & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_puntosventa
                            If lector.Read() Then
                                item.id = lector("id")
                                item.numero = lector("numero").ToString
                                item.descripcion = lector("descripcion").ToString
                                item.idEmpresa = lector("idEmpresa")
                                lector.Close()
                                item.empresa = fact_Empresa.BuscarPorID(item.idEmpresa)
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
    Public Class fact_comprobantes_tipo
        Public Property id As Integer
        Public Property nombre As String
        Public Property disp As Integer
        Public Overrides Function ToString() As String
            Return $"{nombre}"
        End Function
        Public Shared Function ObtenerTodos() As List(Of fact_comprobantes_tipo)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_comprobantes_tipo)
                    Using comando As New MySqlCommand("SELECT * from fact_comprobantes_tipo", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_comprobantes_tipo
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.disp = lector("disp")
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
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_comprobantes_tipo
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_comprobantes_tipo where id = " & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_comprobantes_tipo
                            If lector.Read() Then
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.disp = lector("disp")
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
    Public Class fact_facturasrapidas
        Public Property id As Integer
        Public Property nombre As String
        Public Property idPtoVta As Integer
        Public Property punto_venta As fact_puntosventa
        Public Property idTipoFact As Integer
        Public Property tipofact As fact_comprobantes_tipo
        Public Overrides Function ToString() As String
            Return $"({id}) {nombre}"
        End Function
        Public Shared Function ObtenerTodos() As List(Of fact_facturasrapidas)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_facturasrapidas)
                    Using comando As New MySqlCommand("SELECT * from fact_facturasrapidas ", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_facturasrapidas
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.idPtoVta = lector("punto_venta")
                                item.idTipoFact = lector("tipofact")
                                lista.Add(item)
                            End While
                            lector.Close()
                            For Each itm As fact_facturasrapidas In lista
                                itm.punto_venta = fact_puntosventa.BuscarPorID(itm.idPtoVta)
                                itm.tipofact = fact_comprobantes_tipo.BuscarPorID(itm.idTipoFact)
                            Next
                            Return lista
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_facturasrapidas
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * from fact_facturasrapidas where id = " & idBuscar, conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            Dim item As New fact_facturasrapidas
                            If lector.Read() Then
                                item.id = lector("id")
                                item.nombre = lector("nombre").ToString
                                item.idPtoVta = lector("punto_venta")
                                item.idTipoFact = lector("tipofact")
                                lector.Close()
                                item.punto_venta = fact_puntosventa.BuscarPorID(item.idPtoVta)
                                item.tipofact = fact_comprobantes_tipo.BuscarPorID(item.idTipoFact)
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
    Public Class fact_factura
        Public Property id As Integer
        Public Property ptovta As Integer
        Public Property num_fact As Integer
        Public Property fecha As DateTime
        Public Property id_cliente As Integer
        Public Property razon As String
        Public Property direccion As String
        Public Property localidad As String
        Public Property tipocontr As String
        Public Property cuit As String
        Public Property condvta As String
        Public Property subtotal As Decimal
        Public Property iva105 As Decimal
        Public Property iva21 As Decimal
        Public Property otroiva As Decimal
        Public Property total As Decimal
        Public Property vendedor As String
        Public Property tipofact As String
        Public Property observaciones As String
        Public Property observaciones2 As String
        Public Property remito As String
        Public Property cae As String
        Public Property vtocae As String
        Public Property codbarra As String
        Public Property codigo_qr As String
    End Class
    Public Class fact_insumos
        Public Property id As Integer
        Public Property descripcion As String
        Public Property precio As Decimal
        Public Property ganancia As Decimal
        Public Property garantia As String
        Public Property desc_cantidad As Decimal
        Public Property iva As Decimal

        '----------------------------------------------------------
        Public Property codprov As Integer
        Public Property Proveedor As fact_Proveedores
        Public Property categoria As fact_categoria_insum
        Public Property categoriaID As Integer
        Public Property marca As Integer
        Public Property modelo As Integer
        Public Property moneda As fact_moneda
        Public Property monedaId As Integer
        '-----------------------------------------------------------
        Public Property bonif As Decimal
        Public Property detalles As String
        Public Property cod_bar As String
        Public Property utilidad1 As Decimal
        Public Property utilidad2 As Decimal
        Public Property foto As String
        Public Property tipo As String
        Public Property codigo As String
        Public Property calcular_precio As Integer
        Public Property eliminado As Integer
        Public Property unidades As Decimal
        Public Property presentacion As String
        Public Property fechaMod As DateTime
        Public Property utilidad3 As Decimal
        Public Property utilidad4 As Decimal
        Public Property utilidad5 As Decimal
        Public Property impuestoFijo01 As Decimal
        Public Property impuestoFijo02 As Decimal

        Public Shared Function ObtenerTodos() As List(Of fact_insumos)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_insumos)
                    ' 1. Consultamos los datos básicos del Insumo
                    Using comando As New MySqlCommand("SELECT * FROM fact_insumos WHERE eliminado = 0", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                ' Usamos el helper MapearInsumo que definimos antes
                                lista.Add(MapearInsumo(lector))
                            End While
                            lector.Close() ' Cerramos el lector antes de empezar a buscar las relaciones
                        End Using
                    End Using

                    ' 2. Cargamos los objetos relacionados para cada ítem de la lista
                    ' Tal como lo haces en fact_facturasrapidas
                    For Each itm As fact_insumos In lista
                        If itm.codprov > 0 Then
                            itm.Proveedor = fact_Proveedores.BuscarPorID(itm.codprov)
                        End If

                        If itm.categoriaID > 0 Then
                            itm.categoria = fact_categoria_insum.BuscarPorID(itm.categoriaID)
                        End If

                        If itm.monedaId > 0 Then
                            itm.moneda = fact_moneda.BuscarPorID(itm.monedaId)
                        End If
                    Next

                    Return lista
                End Using
            Catch ex As Exception
                MsgBox("Error al obtener insumos con relaciones: " & ex.Message)
                Return Nothing
            End Try
        End Function
        Private Shared Function MapearInsumo(lector As MySqlDataReader) As fact_insumos
            Dim item As New fact_insumos

            ' --- CAMPOS BÁSICOS ---
            item.id = If(IsDBNull(lector("id")), 0, Convert.ToInt32(lector("id")))
            item.descripcion = If(IsDBNull(lector("descripcion")), "", lector("descripcion").ToString)
            item.precio = If(IsDBNull(lector("precio")), 0D, Convert.ToDecimal(lector("precio")))
            item.ganancia = If(IsDBNull(lector("ganancia")), 0D, Convert.ToDecimal(lector("ganancia")))
            item.garantia = If(IsDBNull(lector("garantia")), "", lector("garantia").ToString)
            item.desc_cantidad = If(IsDBNull(lector("desc_cantidad")), 0D, Convert.ToDecimal(lector("desc_cantidad")))
            item.iva = If(IsDBNull(lector("iva")), 0D, Convert.ToDecimal(lector("iva")))

            ' --- RELACIONES (IDs) ---
            item.codprov = If(IsDBNull(lector("codprov")), 0, Convert.ToInt32(lector("codprov")))
            item.categoriaID = If(IsDBNull(lector("categoria")), 0, Convert.ToInt32(lector("categoria")))
            item.monedaId = If(IsDBNull(lector("moneda")), 0, Convert.ToInt32(lector("moneda")))

            ' --- DATOS ADICIONALES ---
            ' Si cod_bar es nulo, ponemos "0" o un texto vacío según prefieras
            item.cod_bar = If(IsDBNull(lector("cod_bar")) OrElse String.IsNullOrEmpty(lector("cod_bar").ToString), "0", lector("cod_bar").ToString)
            item.codigo = If(IsDBNull(lector("codigo")), "", lector("codigo").ToString)
            item.foto = If(IsDBNull(lector("foto")), "", lector("foto").ToString)
            item.tipo = If(IsDBNull(lector("tipo")), "", lector("tipo").ToString)
            item.presentacion = If(IsDBNull(lector("presentacion")), "", lector("presentacion").ToString)

            ' --- FECHAS ---
            If Not IsDBNull(lector("fechaMod")) Then
                item.fechaMod = Convert.ToDateTime(lector("fechaMod"))
            Else
                item.fechaMod = DateTime.MinValue ' Valor por defecto para fecha nula
            End If

            ' --- UTILIDADES E IMPUESTOS (Completados) ---
            item.utilidad1 = If(IsDBNull(lector("utilidad1")), 0D, Convert.ToDecimal(lector("utilidad1")))
            item.utilidad2 = If(IsDBNull(lector("utilidad2")), 0D, Convert.ToDecimal(lector("utilidad2")))
            item.utilidad3 = If(IsDBNull(lector("utilidad3")), 0D, Convert.ToDecimal(lector("utilidad3")))
            item.utilidad4 = If(IsDBNull(lector("utilidad4")), 0D, Convert.ToDecimal(lector("utilidad4")))
            item.utilidad5 = If(IsDBNull(lector("utilidad5")), 0D, Convert.ToDecimal(lector("utilidad5")))

            item.impuestoFijo01 = If(IsDBNull(lector("impuestoFijo01")), 0D, Convert.ToDecimal(lector("impuestoFijo01")))
            item.impuestoFijo02 = If(IsDBNull(lector("impuestoFijo02")), 0D, Convert.ToDecimal(lector("impuestoFijo02")))

            ' --- OTROS CAMPOS DE LA CLASE ---
            item.unidades = If(IsDBNull(lector("unidades")), 0D, Convert.ToDecimal(lector("unidades")))
            item.calcular_precio = If(IsDBNull(lector("calcular_precio")), 0, Convert.ToInt32(lector("calcular_precio")))
            item.eliminado = If(IsDBNull(lector("eliminado")), 0, Convert.ToInt32(lector("eliminado")))

            Return item
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
    Public Class fact_moneda
        ' Propiedades
        Public Property id As Integer
        Public Property nombre As String
        ' Mantenemos String por la BD, pero podemos convertirlo para cálculos
        Public Property cotizacion As String

        Public Overrides Function ToString() As String
            Return nombre
        End Function

        ' Método para Agregar
        Public Shared Sub Agregar(addNombre As String, Optional addCotizacion As String = "1")
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comandoadd As New MySqlCommand("INSERT INTO fact_moneda (nombre, cotizacion) VALUES (?nom, ?cot)", conn)
                        With comandoadd.Parameters
                            .AddWithValue("?nom", addNombre)
                            .AddWithValue("?cot", addCotizacion)
                        End With
                        comandoadd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al agregar moneda: " & ex.Message)
            End Try
        End Sub

        ' Método para Obtener todas
        Public Shared Function ObtenerTodos() As List(Of fact_moneda)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim lista As New List(Of fact_moneda)
                    Using comando As New MySqlCommand("SELECT * FROM fact_moneda", conn)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            While lector.Read
                                Dim item As New fact_moneda
                                item.id = Convert.ToInt32(lector("id"))
                                item.nombre = lector("nombre").ToString
                                item.cotizacion = lector("cotizacion").ToString
                                lista.Add(item)
                            End While
                        End Using
                    End Using

                    Return lista
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Function

        ' Método para Buscar por ID
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_moneda
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Using comando As New MySqlCommand("SELECT * FROM fact_moneda WHERE id = ?id", conn)
                        comando.Parameters.AddWithValue("?id", idBuscar)
                        Using lector As MySqlDataReader = comando.ExecuteReader
                            If lector.Read() Then
                                Dim item As New fact_moneda
                                item.id = Convert.ToInt32(lector("id"))
                                item.nombre = lector("nombre").ToString
                                item.cotizacion = lector("cotizacion").ToString
                                Return item
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Nothing
        End Function

        ' Función extra útil: Obtener cotización numérica
        Public Function GetCotizacionNumeric() As Decimal
            Dim valor As Decimal = 0
            Decimal.TryParse(Me.cotizacion, valor)
            Return valor
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
    Public Class factNuevaFactura_Datos
        Public Property cliente As fact_clientes
        Public Property condvta As fact_condventas
        Public Property ivatipo As fact_ivaTipo
        Public Property vendedor As fact_vendedor
        Public Property tipofact As fact_comprobantes_tipo
        Public Property ptovta As fact_puntosventa
        Public Property num_fact As Integer
        Public Property fecha As DateTime
        Public Property subtotal As Decimal
        Public Property iva105 As Decimal
        Public Property iva21 As Decimal
        Public Property otroiva As Decimal
        Public Property total As Decimal
        Public Property observaciones As String
        Public Property observaciones2 As String
        Public Property remito As String
        Public Property cae As String
        Public Property vtocae As DateTime
        Public Property codbarra As String
        Public Property codigo_qr As String
    End Class
    Public Class factNuevaFactura_Items
        Public Property id As Integer
        Public Property cod As String
        Public Property plu As String
        Public Property cantidad As Decimal
        Public Property descripcion As String
        Public Property iva As Decimal
        Public Property punit As Decimal
        Public Property ptotal As Decimal
        Public Property idCaja As Integer
        Public Property codint As String
        Public Property impuestoFijo01 As Decimal
        Public Property impuestoFijo02 As Decimal
        Public Property fecha_alta As DateTime
        Public Property id_fact As Integer
        Public Property factura As factNuevaFactura_Datos
        Public Property idAlmacen As fact_insumos_almacenes
        Public Property tipofact As fact_comprobantes_tipo
    End Class
End Class