Imports MySql.Data.MySqlClient
Imports SIGT__KIGEST.datosEstructura
Imports SIGT__KIGEST.GestorFacturacion
Imports SIGT__KIGEST.GestorInsumos

Public Class GestorClientes
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
                    ' Simplificamos el SQL para que sea idéntico al BuscarPorID (sin JOINs)
                    Dim sql As String = "SELECT * FROM fact_clientes WHERE nomapell_razon LIKE @busq OR cuit LIKE @busq"

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@busq", "%" & nombreBuscar & "%")
                        Using lector As MySqlDataReader = cmd.ExecuteReader
                            While lector.Read
                                Dim cli As New fact_clientes

                                ' 1. Mapeo idéntico al de BuscarPorID
                                cli.idCliente = lector("idclientes")
                                cli.nomapellRazon = lector("nomapell_razon").ToString
                                cli.dirDomicilio = lector("dir_domicilio").ToString
                                cli.cuit = lector("cuit").ToString
                                cli.telefono = lector("telefono").ToString
                                cli.contacto = lector("contacto").ToString
                                cli.celular = lector("celular").ToString
                                cli.email = lector("email").ToString
                                cli.observaciones = lector("observaciones").ToString
                                cli.codClie = lector("codClie").ToString

                                cli.idListaPrecios = lector("lista_precios")
                                cli.idIvaTipo = lector("iva_tipo")
                                cli.idLocalidad = lector("dir_localidad")
                                cli.idVendedor = lector("vendedor")
                                'lector.Close()
                                ' 2. Carga profunda de los objetos hijos (Igual que en BuscarPorID)
                                cli.listaPrecios = fact_listaPrecios.BuscarPorID(cli.idListaPrecios)
                                cli.vendedor = fact_vendedor.BuscarPorID(cli.idVendedor)
                                cli.dirLocalidad = cm_localidades.BuscarPorID(cli.idLocalidad)
                                cli.ivaTipo = fact_ivaTipo.BuscarPorID(cli.idIvaTipo)

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
End Class
