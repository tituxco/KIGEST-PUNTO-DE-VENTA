Imports System.Windows.Controls
Imports Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient

Public Class datosEstructura
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
                Dim cliente As New fact_clientes
                ' Reconectar()
                Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("INSERT INTO fact_clientes 
                (nomapell_razon, dir_domicilio, dir_localidad, iva_tipo, cuit, telefono, contacto, celular, email, observaciones, 
                lista_precios, codClie, vendedor) VALUES
                (?nmb,?domi, ?loca, ?iva, ?cuit,?tel,?cont,?celu,?mail,?obs,?listP,?codClie,?vend)", conexionPrinc)
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
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_clientes)
            Try
                ' Reconectar()
                Dim lista As New List(Of fact_clientes)
                Using comando As New MySqlCommand("SELECT * from fact_clientes", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_clientes
            Try
                'Reconectar()
                Using comando As New MySqlCommand("SELECT * from fact_clientes where idclientes=" & idBuscar, conexionPrinc)
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
            Catch ex As Exception
                Console.WriteLine("error mod cliente: " & ex.Message)
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorNombre(nombreBuscar) As List(Of fact_clientes)
            Try
                'Reconectar()
                Dim lista As New List(Of fact_clientes)
                Using comando As New MySqlCommand("SELECT * from fact_clientes 
                where nomapell_razon like @nombre or cuit like @cuit or dir_domicilio like @domi 
                or telefono like @tel or celular like @celu ", conexionPrinc)
                    comando.Parameters.AddWithValue("@nombre", "%" & nombreBuscar & "%")
                    comando.Parameters.AddWithValue("@cuit", "%" & nombreBuscar & "%")
                    comando.Parameters.AddWithValue("@domi", "%" & nombreBuscar & "%")
                    comando.Parameters.AddWithValue("@tel", "%" & nombreBuscar & "%")
                    comando.Parameters.AddWithValue("@celu", "%" & nombreBuscar & "%")

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
                        Return lista
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
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
                'Reconectar()
                Dim lista As New fact_vendedor
                Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into fact_vendedor (nombre, apellido, comision, activo, listaPrecios) values " & "
                (?nmb,?apell, ?com, ?act, ?lista)", conexionPrinc)
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
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_vendedor)
            Try
                'Reconectar()
                Dim lista As New List(Of fact_vendedor)
                Using comando As New MySqlCommand("SELECT * from fact_vendedor where activo=1", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_vendedor
            Try
                '  Reconectar()
                Using comando As New MySqlCommand("SELECT * from fact_vendedor where id = " & idBuscar & " and activo=1 ", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorNombre(nombreBuscar) As List(Of fact_vendedor)
            Try
                'Reconectar()
                Using comando As New MySqlCommand("SELECT * from fact_vendedor where 
                nombre like '%" & nombreBuscar & "%' or apellido like '" & nombreBuscar & "' and activo=1", conexionPrinc)
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
                'Reconectar()
                Dim localidad As New cm_localidades
                Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into cm_localidad (id,nombre) values " & "(?id,?nmb)", conexionPrinc)
                    With comandoadd.Parameters
                        .AddWithValue("?id", addID)
                        .AddWithValue("?nmb", addNombre)
                    End With
                    comandoadd.ExecuteNonQuery()
                    addID = comandoadd.LastInsertedId
                    localidad.id = addID
                    localidad.nombre = addNombre
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of cm_localidades)
            Try
                ' Reconectar()
                Dim lista As New List(Of cm_localidades)
                Using comando As New MySqlCommand("SELECT * from cm_localidad", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As cm_localidades
            Try
                '           Reconectar()
                Using comando As New MySqlCommand("SELECT * from cm_localidad where id=" & idBuscar, conexionPrinc)
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
                ' Reconectar()
                Dim tipo As New fact_ivaTipo
                Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into fact_ivatipo (id,nombre) values " & "(?id,?nmb)", conexionPrinc)
                    With comandoadd.Parameters
                        .AddWithValue("?id", addID)
                        .AddWithValue("?nmb", addNombre)
                    End With
                    comandoadd.ExecuteNonQuery()
                    addID = comandoadd.LastInsertedId
                    tipo.id = addID
                    tipo.nombre = addNombre
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_ivaTipo)
            Try
                'Reconectar()
                Dim lista As New List(Of fact_ivaTipo)
                Using comando As New MySqlCommand("SELECT * from fact_ivatipo", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_ivaTipo
            Try
                ' Reconectar()
                Using comando As New MySqlCommand("SELECT * from fact_ivatipo where id=" & idBuscar, conexionPrinc)
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
                ' Reconectar()
                Dim listaP As New fact_listaPrecios
                Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into fact_listas_precio (nombre,utilidad,auxcol) values " & "(?nmb,?util,?auxCol)", conexionPrinc)
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
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_listaPrecios)
            Try
                'Reconectar()
                Dim lista As New List(Of fact_listaPrecios)
                Using comando As New MySqlCommand("SELECT * from fact_listas_precio", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_listaPrecios
            Try
                'Reconectar()                
                Using comando As New MySqlCommand("SELECT * from fact_listas_precio where id =" & idBuscar, conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorNombre(nombreBuscar) As List(Of fact_listaPrecios)
            Try
                '  Reconectar()

                Using comando As New MySqlCommand("SELECT * from fact_listas_precio where nombre like '%" & nombreBuscar & "%'", conexionPrinc)
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
                'Reconectar()
                Dim almacen As New fact_insumos_almacenes
                Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("
                insert into cm_localidad (nombre,lugar,otrosDatos) values " & "(?nmb,?lugar,?otros)", conexionPrinc)
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
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Public Shared Function ObtenerTodos() As List(Of fact_insumos_almacenes)
            Try
                ' Reconectar()
                Dim lista As New List(Of fact_insumos_almacenes)
                Using comando As New MySqlCommand("SELECT * from fact_insumos_almacenes", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_insumos_almacenes
            Try
                '           Reconectar()
                Using comando As New MySqlCommand("SELECT * from fact_insumos_almacenes where id=" & idBuscar, conexionPrinc)
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
                'Reconectar()
                Dim lista As New List(Of fact_puntosventa)
                Using comando As New MySqlCommand("SELECT * from fact_puntosventa", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_puntosventa
            Try
                '  Reconectar()
                Using comando As New MySqlCommand("SELECT * from fact_puntosventa where id = " & idBuscar, conexionPrinc)
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
                Dim lista As New List(Of fact_comprobantes_tipo)
                Using comando As New MySqlCommand("SELECT * from fact_comprobantes_tipo", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_comprobantes_tipo
            Try
                '  Reconectar()
                Using comando As New MySqlCommand("SELECT * from fact_comprobantes_tipo where id = " & idBuscar, conexionPrinc)
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
                'Reconectar()
                Dim lista As New List(Of fact_facturasrapidas)
                Using comando As New MySqlCommand("SELECT * from fact_facturasrapidas ", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_facturasrapidas
            Try
                '  Reconectar()
                Using comando As New MySqlCommand("SELECT * from fact_facturasrapidas where id = " & idBuscar, conexionPrinc)
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
                ' Reconectar()
                Dim lista As New List(Of fact_condventas)
                Using comando As New MySqlCommand("SELECT * from fact_condventas", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_condventas
            Try
                '           Reconectar()
                Using comando As New MySqlCommand("SELECT * from fact_condventas where id=" & idBuscar, conexionPrinc)
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
                'Reconectar()
                Dim lista As New List(Of fact_Empresa)
                Using comando As New MySqlCommand("SELECT * from fact_empresa2", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_Empresa
            Try
                '  Reconectar()
                Using comando As New MySqlCommand("SELECT * from fact_empresa2 where idempresa = " & idBuscar, conexionPrinc)
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
                Dim lista As New List(Of fact_insumos)
                ' 1. Consultamos los datos básicos del Insumo
                Using comando As New MySqlCommand("SELECT * FROM fact_insumos WHERE eliminado = 0", conexionPrinc)
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
                ' Reconectar()
                Using comandoadd As New MySqlCommand("INSERT INTO fact_proveedores (razon, direccion, tipo_iva, cuit, informacion_adic, cuentagastos) " &
                                                 "VALUES (?razon, ?dir, ?iva, ?cuit, ?info, ?cuenta)", conexionPrinc)
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
            Catch ex As Exception
                MsgBox("Error al agregar proveedor: " & ex.Message)
            End Try
        End Sub

        ' Método para Obtener todos los registros
        Public Shared Function ObtenerTodos() As List(Of fact_Proveedores)
            Try
                ' Reconectar()
                Dim lista As New List(Of fact_Proveedores)
                Using comando As New MySqlCommand("SELECT * FROM fact_proveedores", conexionPrinc)
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
            Catch ex As Exception
                MsgBox("Error al obtener proveedores: " & ex.Message)
                Return Nothing
            End Try
        End Function

        ' Método para Buscar un proveedor por ID
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_Proveedores
            Try
                ' Reconectar()
                Using comando As New MySqlCommand("SELECT * FROM fact_proveedores WHERE id = ?id", conexionPrinc)
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
                ' Reconectar()
                Using comandoadd As New MySqlCommand("INSERT INTO fact_categoria_insum (nombre, sincro) VALUES (?nom, ?sinc)", conexionPrinc)
                    With comandoadd.Parameters
                        .AddWithValue("?nom", addNombre)
                        .AddWithValue("?sinc", addSincro)
                    End With
                    comandoadd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MsgBox("Error al agregar categoría: " & ex.Message)
            End Try
        End Sub
        ' Método para Obtener todas las categorías
        Public Shared Function ObtenerTodos() As List(Of fact_categoria_insum)
            Try
                ' Reconectar()
                Dim lista As New List(Of fact_categoria_insum)
                Using comando As New MySqlCommand("SELECT * FROM fact_categoria_insum", conexionPrinc)
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
            Catch ex As Exception
                MsgBox("Error al obtener categorías: " & ex.Message)
                Return Nothing
            End Try
        End Function
        ' Método para Buscar por ID
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_categoria_insum
            Try
                ' Reconectar()
                Using comando As New MySqlCommand("SELECT * FROM fact_categoria_insum WHERE id = ?id", conexionPrinc)
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
                ' Reconectar()
                Using comandoadd As New MySqlCommand("INSERT INTO fact_moneda (nombre, cotizacion) VALUES (?nom, ?cot)", conexionPrinc)
                    With comandoadd.Parameters
                        .AddWithValue("?nom", addNombre)
                        .AddWithValue("?cot", addCotizacion)
                    End With
                    comandoadd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MsgBox("Error al agregar moneda: " & ex.Message)
            End Try
        End Sub

        ' Método para Obtener todas
        Public Shared Function ObtenerTodos() As List(Of fact_moneda)
            Try
                Dim lista As New List(Of fact_moneda)
                Using comando As New MySqlCommand("SELECT * FROM fact_moneda", conexionPrinc)
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
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Function

        ' Método para Buscar por ID
        Public Shared Function BuscarPorID(idBuscar As Integer) As fact_moneda
            Try
                Using comando As New MySqlCommand("SELECT * FROM fact_moneda WHERE id = ?id", conexionPrinc)
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
                ' Reconectar()
                Using comandoadd As New MySqlCommand("INSERT INTO cm_planDeCuentas " &
                "(nombreCuenta, grupo, subGrupo, cuenta, subCuenta, cuentaDetalle, cuentaMovimiento, cuentaResultado) " &
                "VALUES (?nom, ?g, ?sg, ?ct, ?sct, ?det, ?mov, ?res)", conexionPrinc)

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
            Catch ex As Exception
                MsgBox("Error al insertar en Plan de Cuentas: " & ex.Message)
            End Try
        End Sub
        ' Método para Obtener todos los registros
        Public Shared Function ObtenerTodos() As List(Of cm_planDeCuentas)
            Try
                Dim lista As New List(Of cm_planDeCuentas)
                ' Ordenado por la jerarquía contable
                Dim sql As String = "SELECT * FROM cm_planDeCuentas ORDER BY grupo, subGrupo, cuenta, subCuenta, cuentaDetalle"

                Using comando As New MySqlCommand(sql, conexionPrinc)
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
                Return lista
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Function
        Public Shared Function BuscarPorID(idBuscar As Integer) As cm_planDeCuentas
            Try
                ' Reconectar()
                ' Usamos parámetros (?id) para mayor seguridad contra inyección SQL
                Using comando As New MySqlCommand("SELECT * FROM cm_planDeCuentas WHERE id = ?id", conexionPrinc)
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
                ' Reconectar()
                Using comandoadd As New MySqlCommand("INSERT INTO serv_servicios " &
                    "(nombre, otrosDatos, montoInscripcion, montoExamen, montoMensual) " &
                    "VALUES (?nmb, ?otros, ?insc, ?exam, ?mens)", conexionPrinc)

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
            Catch ex As Exception
                MsgBox("Error al agregar servicio: " & ex.Message)
            End Try
        End Sub

        ' Método ObtenerTodos
        Public Shared Function ObtenerTodos() As List(Of serv_servicios)
            Try
                Dim lista As New List(Of serv_servicios)
                Using comando As New MySqlCommand("SELECT * FROM serv_servicios order by nombre asc", conexionPrinc)
                    Using lector As MySqlDataReader = comando.ExecuteReader
                        While lector.Read
                            lista.Add(MapearServicio(lector))
                        End While
                        lector.Close()
                        Return lista
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ' Método BuscarPorID
        Public Shared Function BuscarPorID(idBuscar As Integer) As serv_servicios
            Try
                Using comando As New MySqlCommand("SELECT * FROM serv_servicios WHERE id = ?id", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ' Método BuscarPorNombre
        Public Shared Function BuscarPorNombre(nombreBuscar As String) As List(Of serv_servicios)
            Try
                Dim lista As New List(Of serv_servicios)
                Using comando As New MySqlCommand("SELECT * FROM serv_servicios WHERE nombre LIKE ?nmb", conexionPrinc)
                    comando.Parameters.AddWithValue("?nmb", "%" & nombreBuscar & "%")
                    Using lector As MySqlDataReader = comando.ExecuteReader
                        While lector.Read
                            lista.Add(MapearServicio(lector))
                        End While
                        lector.Close()
                        Return lista
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function ObtenerReporteServicios() As List(Of ServicioReporte)
            Dim lista As New List(Of ServicioReporte)
            Try
                ' Contamos los contratos activos asociados a cada servicio
                Dim sql As String = "SELECT s.id, s.nombre, s.montoInscripcion, s.montoMensual, s.montoExamen, " &
                            "COUNT(c.id) as cant_alumnos " &
                            "FROM serv_servicios s " &
                            "LEFT JOIN serv_contratos c ON s.id = c.idServicio AND c.activo = 1 " &
                            "GROUP BY s.id " &
                            "ORDER BY s.nombre ASC"

                Using cmd As New MySqlCommand(sql, conexionPrinc)
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
            Catch ex As Exception
                MsgBox("Error al obtener listado de servicios: " & ex.Message)
            End Try
            Return lista
        End Function

        Public Shared Function Actualizar(servicio As serv_servicios) As Boolean
            Try
                ' Consulta SQL con parámetros para evitar inyecciones y errores de formato
                Dim sql As String = "UPDATE serv_servicios SET " &
                            "nombre = ?nom, " &
                            "montoInscripcion = ?insc, " &
                            "montoMensual = ?men, " &
                            "montoExamen = ?exa " &
                            "WHERE id = ?id"

                Using cmd As New MySqlCommand(sql, conexionPrinc)
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
                ' Reconectar()
                Using comandoadd As New MySqlCommand("INSERT INTO serv_personas " &
                    "(nombre_apellido, dni, celular, idCliente, direccion) " &
                    "VALUES (?nmb, ?dni, ?cel, ?idC, ?dir)", conexionPrinc)

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
            Catch ex As Exception
                MsgBox("Error al agregar persona: " & ex.Message)
            End Try
        End Sub

        ' Método ObtenerTodos
        Public Shared Function ObtenerTodos() As List(Of serv_personas)
            Try
                Dim lista As New List(Of serv_personas)
                Using comando As New MySqlCommand("SELECT * FROM serv_personas", conexionPrinc)
                    Using lector As MySqlDataReader = comando.ExecuteReader
                        While lector.Read
                            lista.Add(MapearPersona(lector))
                        End While
                        lector.Close()
                        Return lista
                    End Using
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ' Método Buscar por ID
        Public Shared Function BuscarPorID(idBuscar As Integer) As serv_personas
            Try
                Using comando As New MySqlCommand("SELECT * FROM serv_personas WHERE id = ?id", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ' Método Buscar por DNI (Crucial para tu lógica de validación)
        Public Shared Function BuscarPorDNI(dniBuscar As String) As serv_personas
            Try
                Using comando As New MySqlCommand("SELECT * FROM serv_personas WHERE dni = ?dni", conexionPrinc)
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
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function Guardar(ByRef persona As serv_personas) As Integer
            Try
                ' Reconectar()
                If persona.id = 0 Then
                    ' Lógica de Inserción
                    Dim sql As String = "INSERT INTO serv_personas (nombre_apellido, dni, celular, idCliente, direccion) " &
                                    "VALUES (?nmb, ?dni, ?cel, ?idC, ?dir)"

                    Using cmd As New MySqlCommand(sql, conexionPrinc)
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

                    Using cmd As New MySqlCommand(sql, conexionPrinc)
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
            Catch ex As Exception
                Return 0
                MsgBox("Error al guardar la persona: " & ex.Message)
            End Try
        End Function

        Public Shared Function ObtenerEstadoGeneralAlumnos() As List(Of AlumnoEstadoReporte)
            Dim lista As New List(Of AlumnoEstadoReporte)
            Try
                ' Reconectar()
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

                Using cmd As New MySqlCommand(sql, conexionPrinc)
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
            Catch ex As Exception
                MsgBox("Error en reporte: " & ex.Message)
            End Try
            Return lista
        End Function

        Public Shared Function ObtenerAlumnosParaABM() As List(Of AlumnoAbmReporte)
            Dim lista As New List(Of AlumnoAbmReporte)
            Try
                ' Consulta que cuenta cuántos contratos activos tiene cada persona
                Dim sql As String = "SELECT p.id, p.nombre_apellido, p.dni, p.celular, " &
                            "COUNT(c.id) as cantidad_activos " &
                            "FROM serv_personas p " &
                            "LEFT JOIN serv_contratos c ON p.id = c.idPersona AND c.activo = 1 " &
                            "GROUP BY p.id " &
                            "ORDER BY p.nombre_apellido ASC"

                Using cmd As New MySqlCommand(sql, conexionPrinc)
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
            Catch ex As Exception
                MsgBox("Error al obtener listado ABM: " & ex.Message)
            End Try
            Return lista
        End Function

        Public Shared Function Actualizar(p As serv_personas) As Boolean
            Try
                Dim sql As String = "UPDATE serv_personas SET nombre_apellido=?nom, dni=?dni, celular=?cel, direccion=?dir, idCliente=?idClie WHERE id=?id"
                Using cmd As New MySqlCommand(sql, conexionPrinc)
                    cmd.Parameters.AddWithValue("?nom", p.nombre_apellido)
                    cmd.Parameters.AddWithValue("?dni", p.dni)
                    cmd.Parameters.AddWithValue("?cel", p.celular)
                    cmd.Parameters.AddWithValue("?dir", p.direccion)
                    cmd.Parameters.AddWithValue("?idClie", p.idCliente)
                    cmd.Parameters.AddWithValue("?id", p.id)
                    cmd.ExecuteNonQuery()
                End Using
                Return True
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
                ' Reconectar()
                Dim sql As String = "INSERT INTO serv_contratos " &
                    "(idServicio, idPersona,periodo, mesInicio, mesFin, montoInscripcion, montoExamen, montoMensual, activo) " &
                    "VALUES (?idS, ?idP,?per, ?mI, ?mF, ?mIns, ?mEx, ?mMen, ?act)"

                Using cmd As New MySqlCommand(sql, conexionPrinc)
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
            Catch ex As Exception
                MsgBox("Error al registrar contrato: " & ex.Message)
                Return 0
            End Try
        End Function
        Public Shared Sub ActualizarMontos(idC As Integer, montoMen As Decimal, montoExa As Decimal)
            Try
                ' Reconectar()
                Using cmd As New MySqlCommand("UPDATE serv_contratos SET montoMensual = ?men, montoExamen = ?exa WHERE id = ?id", conexionPrinc)
                    cmd.Parameters.AddWithValue("?men", montoMen)
                    cmd.Parameters.AddWithValue("?exa", montoExa)
                    cmd.Parameters.AddWithValue("?id", idC)

                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MsgBox("Error al actualizar montos en contrato: " & ex.Message)
            End Try
        End Sub
        Public Shared Function BuscarPorID(idBusca As Integer) As serv_contratos
            Dim item As serv_contratos = Nothing
            Try
                ' Reconectar()
                Using comando As New MySqlCommand("SELECT * FROM serv_contratos WHERE id = ?id", conexionPrinc)
                    comando.Parameters.AddWithValue("?id", idBusca)

                    Using lector As MySqlDataReader = comando.ExecuteReader
                        If lector.Read() Then
                            ' Llamamos a tu método existente
                            item = MapearContrato(lector)
                        End If
                        lector.Close()
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
                ' Usamos 0 para inactivo y 1 para activo
                Dim sql As String = "UPDATE serv_contratos SET activo = 0 WHERE id = ?id"

                Using cmd As New MySqlCommand(sql, conexionPrinc)
                    cmd.Parameters.AddWithValue("?id", idContrato)
                    Return cmd.ExecuteNonQuery() > 0
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
                Using cmd As New MySqlCommand("INSERT INTO serv_detalle (idContrato, idPersona, detalle, monto, vencimiento, estado) " &
                                             "VALUES (?idC, ?idP, ?det, ?mon, ?venc, ?est)", conexionPrinc)
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
            Catch ex As Exception
                MsgBox("Error al insertar detalle: " & ex.Message)
            End Try
        End Sub

        Public Shared Function RegistrarPago(idDetalle As Integer, Optional idComprobanteFacturacion As Integer = 0) As Boolean
            Try
                ' Si querés guardar la fecha de pago o el comprobante, podés agregar esas columnas a tu tabla
                ' Ejemplo ampliado: "UPDATE serv_detalle SET estado = 'PAGADO', fechaPago = CURDATE(), idFactura = ?idFac WHERE id = ?id"

                Dim sql As String = "UPDATE serv_detalle SET estado = 'PAGADO' WHERE id = ?id"

                Using cmd As New MySqlCommand(sql, conexionPrinc)
                    cmd.Parameters.AddWithValue("?id", idDetalle)

                    ' Si en el futuro agregás la columna idFactura a serv_detalle, descomentá esto:
                    ' cmd.Parameters.AddWithValue("?idFac", If(idComprobanteFacturacion > 0, idComprobanteFacturacion, DBNull.Value))

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return filasAfectadas > 0
                End Using
            Catch ex As Exception
                MsgBox("Error al registrar el pago: " & ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try
        End Function

        Public Shared Function ActualizarEstado(idDetalle As Integer, nuevoEstado As String) As Boolean
            Try
                Dim sql As String = "UPDATE serv_detalle SET estado = ?est WHERE id = ?id"

                Using cmd As New MySqlCommand(sql, conexionPrinc)
                    cmd.Parameters.AddWithValue("?est", nuevoEstado)
                    cmd.Parameters.AddWithValue("?id", idDetalle)

                    Return cmd.ExecuteNonQuery() > 0
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
                Using cmd As New MySqlCommand("SELECT * FROM serv_detalle WHERE idPersona = ?id ORDER BY id ASC", conexionPrinc)
                    cmd.Parameters.AddWithValue("?id", idPer)
                    Using lector As MySqlDataReader = cmd.ExecuteReader
                        While lector.Read
                            lista.Add(MapearDetalle(lector))
                        End While
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
            ' Actualizamos cuotas mensuales pendientes
            Dim sqlCuotas = "UPDATE serv_detalle SET monto=?m WHERE idContrato=?id AND estado='PENDIENTE' AND detalle LIKE 'CUOTA%'"
            Using cmd As New MySqlCommand(sqlCuotas, conexionPrinc)
                cmd.Parameters.AddWithValue("?m", mMen)
                cmd.Parameters.AddWithValue("?id", idC)
                cmd.ExecuteNonQuery()
            End Using

            ' Actualizamos derecho a examen pendiente
            Dim sqlExamen = "UPDATE serv_detalle SET monto=?e WHERE idContrato=?id AND estado='PENDIENTE' AND detalle='DERECHO A EXAMEN'"
            Using cmd As New MySqlCommand(sqlExamen, conexionPrinc)
                cmd.Parameters.AddWithValue("?e", mEx)
                cmd.Parameters.AddWithValue("?id", idC)
                cmd.ExecuteNonQuery()
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
