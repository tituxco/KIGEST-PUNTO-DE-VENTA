Imports MySql.Data.MySqlClient
Imports SIGT__KIGEST.datosEstructura

Public Class GestorInsumos
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
                    Using comandoadd As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_insumos_almacenes 
                    (nombre,lugar,otrosDatos) values (?nmb,?lugar,?otros)", conn)
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
                                item.lugar = lector("lugar").ToString
                                item.otroDatos = lector("otrosDatos").ToString
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
    Public Class fact_insumos_stock_almacen
        Public Property idAlmacen As Integer
        Public Property nombreAlmacen As String
        Public Property stockDisponible As Decimal

        ' Esto sirve para que si lo metés en un ComboBox se vea lindo (ej: "Mostrador: 15.00")
        Public Overrides Function ToString() As String
            Return $"{nombreAlmacen}: {stockDisponible.ToString("N2")}"
        End Function
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
        Public Property StockPorAlmacenes As New List(Of fact_insumos_stock_almacen)
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
        'para la busqueda en los formularios, no para el selector
        Public Shared Function BusquedaProductos(nombre As String, metodoBusq As Integer, categoria As String,
                                       idProveedor As Integer, soloStock As Boolean, idAlmacen As Integer,
                                       ordenIndex As Integer, paraImprimir As Boolean, Optional idLista As Integer = 0) As DataTable
            Dim dt As New DataTable()

            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim sql As New MySqlCommand()
                    sql.Connection = conn

                    Dim query As New System.Text.StringBuilder()

                    ' Armamos el filtro del almacén dinámicamente
                    Dim filtroAlmacen As String = ""
                    If idAlmacen > 0 Then ' Suponiendo que los IDs reales son > 0
                        filtroAlmacen = " AND idalmacen=@idAlmacen"
                        sql.Parameters.AddWithValue("@idAlmacen", idAlmacen)
                    End If

                    ' 1. SELECT BASE
                    If paraImprimir Then
                        query.Append("SELECT CAST(pro.id AS SIGNED) as CodInterno, pro.descripcion, pro.codigo as PLU, ")
                        ' Le inyectamos el filtro de almacén a la subconsulta
                        query.Append("(SELECT SUM(REPLACE(stock,',','.')) FROM fact_insumos_lotes WHERE idproducto=pro.id" & filtroAlmacen & ") as Stock, ")
                        query.Append("FORMAT((REPLACE(REPLACE(pro.precio, '.', ''), ',', '.') * (SELECT mon.cotizacion FROM fact_moneda AS mon WHERE mon.id = pro.moneda) * (pro.iva + 100) / 100), 2, 'es_AR') AS precioCosto, ")
                        query.Append(ObtenerFormulaPrecioLista() & " AS precioLista, ")
                        query.Append("cat.nombre as categoria ")
                        sql.Parameters.AddWithValue("@idlst", idLista)
                    Else
                        query.Append("SELECT CAST(pro.id AS SIGNED) as CodInterno, CONCAT_WS(' ', pro.descripcion, pro.detalles) AS Descripcion, pro.codigo as PLU, ")
                        ' Le inyectamos el filtro de almacén a la subconsulta
                        query.Append("(SELECT SUM(REPLACE(stock,',','.')) FROM fact_insumos_lotes WHERE idproducto=pro.id" & filtroAlmacen & ") as Stock ")
                    End If

                    ' ==========================================
                    ' ¡ESTO ES LO QUE FALTABA! LAS TABLAS BASE
                    ' ==========================================
                    query.Append("FROM fact_insumos AS pro ")
                    query.Append("INNER JOIN fact_categoria_insum AS cat ON cat.id=pro.categoria ")
                    query.Append("WHERE pro.eliminado = 0 ")
                    ' ==========================================

                    ' 2. FILTROS
                    If Not String.IsNullOrEmpty(nombre) Then
                        If metodoBusq = 1 Then
                            query.Append("AND (pro.descripcion LIKE @busq OR pro.codigo LIKE @busq) ")
                            sql.Parameters.AddWithValue("@busq", "%" & Replace(nombre, " ", "%") & "%")
                        ElseIf metodoBusq = 0 Then
                            query.Append("AND (pro.descripcion LIKE @busq OR pro.codigo LIKE @busq) ")
                            sql.Parameters.AddWithValue("@busq", nombre & "%")
                        Else
                            query.Append("AND pro.descripcion LIKE @busq ")
                            sql.Parameters.AddWithValue("@busq", "%")
                        End If
                    End If

                    If Not String.IsNullOrEmpty(categoria) AndAlso categoria <> "" Then
                        query.Append("AND pro.categoria IN (" & categoria & ") ")
                    End If

                    If idProveedor <> -1 Then
                        query.Append("AND pro.codprov = @prov ")
                        sql.Parameters.AddWithValue("@prov", idProveedor)
                    End If

                    If soloStock Then
                        query.Append("HAVING Stock > 0 ")
                    End If

                    ' 3. ORDEN
                    Select Case ordenIndex
                        Case 0 : query.Append("ORDER BY pro.descripcion ASC ")
                        Case 1 : query.Append("ORDER BY pro.codigo ASC ")
                        Case Else : query.Append("ORDER BY pro.id ASC ")
                    End Select

                    sql.CommandText = query.ToString()

                    ' Dejamos el MsgBox para que puedas verificar que ahora sí se armó bien la consulta
                    'MsgBox(query.ToString())

                    Using adaptador As New MySqlDataAdapter(sql)
                        adaptador.Fill(dt)
                    End Using
                End Using

            Catch ex As Exception
                Throw New Exception("Error al buscar productos: " & ex.Message)
            End Try

            Return dt
        End Function
        Private Shared Function ObtenerFormulaPrecioLista() As String
            Return "CASE (select valor from fact_configuraciones where id=7) " &
                   "WHEN 0 THEN format(replace(replace(pro.precio,'.',''),',','.') * ((select mon.cotizacion from fact_moneda as mon where mon.id=pro.moneda)) * ((pro.iva+100)/100) * " &
                   "CASE (select listas.auxcol from fact_listas_precio as listas where listas.id=@idlst) " &
                   "WHEN 0 THEN ((replace(replace(pro.ganancia,'.',''),',','.') +100)/100) " &
                   "WHEN 1 THEN ((replace(replace(pro.utilidad1,'.',''),',','.')+100)/100) " &
                   "WHEN 2 THEN ((replace(replace(pro.utilidad2,'.',''),',','.')+100)/100) " &
                   "WHEN 3 THEN ((replace(replace(pro.utilidad3,'.',''),',','.')+100)/100) " &
                   "WHEN 4 THEN ((replace(replace(pro.utilidad4,'.',''),',','.')+100)/100) " &
                   "WHEN 5 THEN ((replace(replace(pro.utilidad5,'.',''),',','.')+100)/100) " &
                   "END * (((select listas.utilidad from fact_listas_precio as listas where listas.id=@idlst)+100)/100) ,2,'es_AR') " &
                   "WHEN 1 THEN format(replace(replace(pro.precio,'.',''),',','.') * ((select mon.cotizacion from fact_moneda as mon where mon.id=pro.moneda)) * ((pro.iva+100)/100) * " &
                   "((CASE (select listas.auxcol from fact_listas_precio as listas where listas.id=@idlst) " &
                   "WHEN 0 THEN ((replace(replace(pro.ganancia,'.',''),',','.') +100)/100) " &
                   "WHEN 1 THEN ((replace(replace(pro.utilidad1,'.',''),',','.')+100)/100) " &
                   "WHEN 2 THEN ((replace(replace(pro.utilidad2,'.',''),',','.')+100)/100) " &
                   "WHEN 3 THEN ((replace(replace(pro.utilidad3,'.',''),',','.')+100)/100) " &
                   "WHEN 4 THEN ((replace(replace(pro.utilidad4,'.',''),',','.')+100)/100) " &
                   "WHEN 5 THEN ((replace(replace(pro.utilidad5,'.',''),',','.')+100)/100) " &
                   "END + (((select listas.utilidad from fact_listas_precio as listas where listas.id=@idlst)+100)/100))-1) ,2,'es_AR') END"
        End Function
        Public Shared Function ObtenerDatosCalculoPrecio(idProd As Integer) As DataTable
            Dim dt As New DataTable()
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim query As String = "SELECT prod.precio, (SELECT mon.cotizacion FROM fact_moneda AS mon WHERE mon.id=prod.moneda) AS cotizacion, " &
                                          "prod.iva, prod.ganancia, prod.utilidad1, prod.utilidad2, prod.utilidad3, prod.utilidad4, prod.utilidad5, prod.detalles " &
                                          "FROM fact_insumos AS prod WHERE prod.id = @idProd"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@idProd", idProd)
                        Using adaptador As New MySqlDataAdapter(cmd)
                            adaptador.Fill(dt)
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception("Error al obtener datos para calcular el precio: " & ex.Message)
            End Try
            Return dt
        End Function
        Public Shared Function ObtenerStockPorAlmacen(idProd As Integer) As DataTable
            Dim dt As New DataTable()
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    ' Actualizamos la consulta a la sintaxis moderna con INNER JOIN
                    Dim query As String = "SELECT al.id as idAlmacen, lt.idproducto as ID, al.nombre as Almacen, " &
                                          "SUM(REPLACE(lt.stock, ',', '.')) as Stock " &
                                          "FROM fact_insumos_almacenes AS al " &
                                          "INNER JOIN fact_insumos_lotes AS lt ON lt.idalmacen = al.id " &
                                          "WHERE lt.idproducto = @idProd " &
                                          "GROUP BY lt.idproducto, lt.idalmacen"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@idProd", idProd)
                        Using adaptador As New MySqlDataAdapter(cmd)
                            adaptador.Fill(dt)
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception("Error al obtener el stock por almacén: " & ex.Message)
            End Try
            Return dt
        End Function
        Public Shared Function BuscarPorCodigoOLector(codigoBuscado As String) As fact_insumos
            Try
                codigoBuscado = codigoBuscado.Replace("B", "").Replace("A", "").Replace("b", "").Replace("a", "").Trim()

                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    Dim query As String = "SELECT * FROM fact_insumos WHERE (codigo = @cod OR cod_bar = @cod) AND eliminado = 0 LIMIT 1"

                    Using comando As New MySqlCommand(query, conn)
                        comando.Parameters.AddWithValue("@cod", codigoBuscado)

                        Using lector As MySqlDataReader = comando.ExecuteReader()
                            If lector.Read() Then
                                ' 1. Mapeamos el insumo básico
                                Dim item As fact_insumos = MapearInsumo(lector)

                                ' ¡ATENCIÓN ACÁ! Cerramos el lector ANTES de lanzar otra consulta con la misma conexión
                                lector.Close()

                                ' 2. Vamos a la tabla fact_insumos_lotes a buscar el stock
                                Dim dtStock As DataTable = ObtenerStockPorAlmacen(item.id)

                                ' 3. Llenamos nuestra nueva lista
                                For Each fila As DataRow In dtStock.Rows
                                    Dim stockItem As New fact_insumos_stock_almacen()
                                    stockItem.idAlmacen = Convert.ToInt32(fila("idAlmacen"))
                                    stockItem.nombreAlmacen = fila("Almacen").ToString()
                                    stockItem.stockDisponible = ParsearDecimal(fila("Stock"))

                                    item.StockPorAlmacenes.Add(stockItem)
                                Next

                                Return item
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al buscar el producto: " & ex.Message, MsgBoxStyle.Critical)
            End Try

            Return Nothing
        End Function
        Public Shared Function BuscarPorNombreOCodigo(busqueda As String) As List(Of fact_insumos)
            Dim lista As New List(Of fact_insumos)
            Try
                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    ' Busca coincidencias en descripción o PLU
                    Dim query As String = "SELECT * FROM fact_insumos WHERE eliminado = 0 AND (descripcion LIKE @busq OR codigo LIKE @busq)"
                    Using cmd As New MySqlCommand(query, conn)
                        ' Reemplazamos los espacios por % para que sea una búsqueda inteligente
                        cmd.Parameters.AddWithValue("@busq", "%" & busqueda.Replace(" ", "%") & "%")

                        Using lector As MySqlDataReader = cmd.ExecuteReader()
                            While lector.Read()
                                lista.Add(MapearInsumo(lector))
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al buscar productos: " & ex.Message)
            End Try
            Return lista
        End Function
        Public Shared Sub InyectarStockMasivo(listaProductos As List(Of fact_insumos))
            If listaProductos Is Nothing OrElse listaProductos.Count = 0 Then Return

            Try
                ' Juntamos los IDs de los productos encontrados separados por coma (ej: "15,28,94")
                Dim ids As String = String.Join(",", listaProductos.Select(Function(p) p.id))

                Using conn As New MySqlConnection(CadenaConexion)
                    conn.Open()
                    ' Le agregamos el WHERE para traer SOLO el stock de esos productos
                    Dim query As String = "SELECT lt.idproducto, al.id as idAlmacen, al.nombre as Almacen, " &
                                  "SUM(REPLACE(lt.stock, ',', '.')) as Stock " &
                                  "FROM fact_insumos_lotes AS lt " &
                                  "INNER JOIN fact_insumos_almacenes AS al ON lt.idalmacen = al.id " &
                                  "WHERE lt.idproducto IN (" & ids & ") " &
                                  "GROUP BY lt.idproducto, lt.idalmacen"

                    Using cmd As New MySqlCommand(query, conn)
                        Using lector As MySqlDataReader = cmd.ExecuteReader()
                            While lector.Read()
                                Dim idProd As Integer = Convert.ToInt32(lector("idproducto"))

                                Dim prod = listaProductos.FirstOrDefault(Function(p) p.id = idProd)
                                If prod IsNot Nothing Then
                                    Dim stockItem As New fact_insumos_stock_almacen()
                                    stockItem.idAlmacen = Convert.ToInt32(lector("idAlmacen"))
                                    stockItem.nombreAlmacen = lector("Almacen").ToString()

                                    ' --- USAMOS LA FUNCIÓN SEGURA ---
                                    stockItem.stockDisponible = ParsearDecimal(lector("Stock"))

                                    ' --- DESCOMENTÁ ESTO SOLO PARA PROBAR SI LLEGA EL DATO ---
                                    'MsgBox("Producto ID " & idProd & " - Encontró stock: " & stockItem.stockDisponible)

                                    prod.StockPorAlmacenes.Add(stockItem)
                                End If
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Error al inyectar el stock masivo: " & ex.Message)
            End Try
        End Sub
        Public Function GetStockEnAlmacen(idAlmacenBuscado As Integer) As Decimal
            Dim almacen = StockPorAlmacenes.FirstOrDefault(Function(a) a.idAlmacen = idAlmacenBuscado)
            If almacen IsNot Nothing Then
                Return almacen.stockDisponible
            End If
            Return 0
        End Function
        Public Shared Function CalcularPrecioUnitarioFinal(prod As GestorInsumos.fact_insumos, cotizacionMoneda As Decimal, listaPrecio As GestorInsumos.fact_listaPrecios) As Decimal
            ' 1. Costo base convertido a la moneda de curso
            Dim costoBase As Decimal = prod.precio * cotizacionMoneda

            ' 2. Buscamos la utilidad según la lista de precios seleccionada
            Dim utilidadInsumo As Decimal = 0
            If listaPrecio IsNot Nothing Then
                Select Case listaPrecio.auxcol
                    Case 0 : utilidadInsumo = prod.ganancia
                    Case 1 : utilidadInsumo = prod.utilidad1
                    Case 2 : utilidadInsumo = prod.utilidad2
                    Case 3 : utilidadInsumo = prod.utilidad3
                    Case 4 : utilidadInsumo = prod.utilidad4
                    Case 5 : utilidadInsumo = prod.utilidad5
                End Select
            End If

            ' Aplicamos la ganancia sobre el costo
            Dim precioConGanancia As Decimal = costoBase * (1 + (utilidadInsumo / 100))

            ' 3. Aplicamos el recargo/descuento extra de la Lista de Precios general
            Dim utilidadLista As Decimal = 0
            If listaPrecio IsNot Nothing AndAlso Decimal.TryParse(listaPrecio.utilidad, utilidadLista) Then
                precioConGanancia = precioConGanancia * (1 + (utilidadLista / 100))
            End If

            ' 4. Aplicamos el IVA al final para obtener el precio de venta final
            Dim precioFinalVenta As Decimal = precioConGanancia * (1 + (prod.iva / 100))

            Return Math.Round(precioFinalVenta, 2)
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

    Public Shared Function ComprobarStock(idProducto As Integer, cantidadRequerida As Decimal, idAlmacen As Integer) As Boolean
        Try
            Reconectar()

            ' Usamos INNER JOIN y parámetros. Sumamos todo el stock y sacamos el desc_cantidad
            Dim sql As String = "SELECT SUM(lt.stock) AS stock_total, MAX(prod.desc_cantidad) AS desc_cant " &
                                "FROM fact_insumos_lotes AS lt " &
                                "INNER JOIN fact_insumos AS prod ON lt.idproducto = prod.id " &
                                "WHERE lt.idproducto = @idProd AND lt.idalmacen = @idAlmacen"

            Using cmd As New MySqlCommand(sql, GestorConexiones.conexionPrinc)
                cmd.Parameters.AddWithValue("@idProd", idProducto)
                cmd.Parameters.AddWithValue("@idAlmacen", idAlmacen)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    ' Validamos que devuelva algo y que no sea nulo (por si no hay lotes)
                    If reader.Read() AndAlso Not IsDBNull(reader("stock_total")) Then
                        Dim stockActual As Decimal = Convert.ToDecimal(reader("stock_total"))
                        Dim descCantidad As Decimal = Convert.ToDecimal(reader("desc_cant"))

                        ' Verificamos si alcanza
                        Return stockActual >= (cantidadRequerida * descCantidad)
                    End If
                End Using
            End Using

            ' Si no encontró lotes o stock, es falso
            Return False
        Catch ex As Exception
            ' Podés habilitar un MsgBox acá si querés depurar, pero en general es mejor que solo devuelva False
            Return False
        End Try
    End Function

    Public Shared Function DescontarStockPorLotes(idProducto As Integer, cantidadAQuitar As Decimal, idAlmacen As Integer) As Boolean
        Try
            Reconectar()

            ' Traemos los lotes con stock > 0, ordenados del más viejo al más nuevo (ASC)
            Dim sqlSelect As String = "SELECT lt.id, lt.stock, prod.desc_cantidad " &
                                      "FROM fact_insumos_lotes AS lt " &
                                      "INNER JOIN fact_insumos AS prod ON lt.idproducto = prod.id " &
                                      "WHERE lt.idproducto = @idProd AND lt.idalmacen = @idAlmacen AND lt.stock > 0 " &
                                      "ORDER BY lt.id ASC"

            Dim dtLotes As New DataTable()
            Using cmdSelect As New MySqlCommand(sqlSelect, GestorConexiones.conexionPrinc)
                cmdSelect.Parameters.AddWithValue("@idProd", idProducto)
                cmdSelect.Parameters.AddWithValue("@idAlmacen", idAlmacen)
                Using adapter As New MySqlDataAdapter(cmdSelect)
                    adapter.Fill(dtLotes)
                End Using
            End Using

            If dtLotes.Rows.Count = 0 Then Return False ' No hay lotes para descontar

            ' Leemos el factor de multiplicador del primer lote (es el mismo para todos)
            Dim descCantidad As Decimal = Convert.ToDecimal(dtLotes.Rows(0)("desc_cantidad"))
            Dim cantidadRestante As Decimal = cantidadAQuitar * descCantidad

            For Each row As DataRow In dtLotes.Rows
                If cantidadRestante <= 0 Then Exit For ' Si ya descontamos todo, cortamos el bucle

                Dim idLote As Integer = Convert.ToInt32(row("id"))
                Dim stockLote As Decimal = Convert.ToDecimal(row("stock"))

                ' Calculamos cuánto podemos tomar de este lote sin ir a números negativos
                Dim cantidadATomar As Decimal = Math.Min(stockLote, cantidadRestante)
                Dim nuevoStock As Decimal = stockLote - cantidadATomar

                ' Actualizamos el lote específico
                Dim sqlUpdate As String = "UPDATE fact_insumos_lotes SET stock = @nuevoStock WHERE id = @idLote"
                Using cmdUpdate As New MySqlCommand(sqlUpdate, GestorConexiones.conexionPrinc)
                    cmdUpdate.Parameters.AddWithValue("@nuevoStock", nuevoStock)
                    cmdUpdate.Parameters.AddWithValue("@idLote", idLote)
                    cmdUpdate.ExecuteNonQuery()
                End Using

                ' Le restamos a la deuda global lo que acabamos de tomar
                cantidadRestante -= cantidadATomar
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error al descontar stock por lotes: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Public Shared Function GuardarStockProducto(idComprobante As Integer, idProducto As Integer, cantidad As Decimal, idAlmacen As Integer) As Boolean
        Try
            Reconectar()

            Dim sql As String = "INSERT INTO fact_insumos_lotes (nombre, stock, idproducto, idfactura, compracant, tipo_prod, idalmacen) " &
                                "VALUES (@nombre, @stock, @idProd, @idFactura, @compraCant, @tipoProd, @idAlmacen)"

            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(sql, GestorConexiones.conexionPrinc)
                cmd.Parameters.AddWithValue("@nombre", "-")
                cmd.Parameters.AddWithValue("@stock", cantidad)
                cmd.Parameters.AddWithValue("@idProd", idProducto)
                cmd.Parameters.AddWithValue("@idFactura", idComprobante)
                cmd.Parameters.AddWithValue("@compraCant", cantidad)
                cmd.Parameters.AddWithValue("@tipoProd", 1)
                cmd.Parameters.AddWithValue("@idAlmacen", idAlmacen)

                cmd.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            ' Ahora si falla te avisa y devuelve False
            MsgBox("Error al intentar reingresar el stock: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

End Class
