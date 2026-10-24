Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Security
Imports MySql.Data.MySqlClient
Imports WhatsAppApi
'Imports WhatsAppApi
Imports WhatsAppApi.WhatsApp

Public Class reimpresionComprobantes
    Dim IdFactura As Integer
    Private Sub cmdbuscar_Click_1(sender As Object, e As EventArgs) Handles cmdbuscar.Click
        ' 1. Recolectamos TODOS los parámetros de la Pestaña 1 y la antigua Pestaña 3
        Dim parametros As New Dictionary(Of String, Object) From {
        {"Limite", Val(TextBox1.Text)},
        {"NumComprobante", txtNumeroComprobante.Text.Trim()},
        {"RazonSocial", "%" & txtrazonsocial.Text.Trim().Replace(" ", "%") & "%"},
        {"PuntoVenta", If(cmbInforPtoVta.Text = "", "%", cmbInforPtoVta.SelectedValue)},
        {"TipoComprobante", If(cmbTipoComprobante.SelectedValue Is Nothing OrElse cmbTipoComprobante.SelectedValue.ToString() = "-1", "%", cmbTipoComprobante.SelectedValue)},
        {"FechaDesde", dtdesdeCobranza.Value.ToString("yyyy-MM-dd")}, ' Asegurate del nombre de tu control
        {"FechaHasta", dthastaCobranza.Value.ToString("yyyy-MM-dd")},
        {"SoloSinPagar", chksinPagar.Checked}
    }

        ' 2. Iniciamos la animación visual de tu formulario principal
        frmprincipal.pbprincipal.Visible = True
        frmprincipal.pbprincipal.Style = ProgressBarStyle.Marquee
        frmprincipal.lblprocesando.Visible = True

        ' 3. Ejecutamos el hilo secundario
        If Not bgwBuscarFacturas.IsBusy Then
            bgwBuscarFacturas.RunWorkerAsync(parametros)
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ptovta As Integer = dtfacturas.CurrentRow.Cells("ptovta").Value
        IdFactura = dtfacturas.CurrentRow.Cells("id").Value

        Dim imprimirTermico As Boolean = chkImpresionTermica.Checked

        ' En modo manual, si es ticket térmico imprime directo; si es A4, por lo general se prefiere ver el visor (directo = False) 
        ' a menos que quieras forzarlo. Acá lo enlazamos al RadioButton de A4.
        Dim impresionDirecta As Boolean = False

        ' Mandamos la orden al Gestor de Impresión
        GestorImpresion.ImprimirComprobante(IdFactura, ptovta, imprimirTermico, impresionDirecta)

    End Sub


    Private Sub reimpresionComprobantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Reconectar()
            dtdesdeCobranza.Value = obtenerPrimerDiaMes()
            ' dthastaCobranza.Value = Now.Date ' Asumo que tienes una fecha hasta

            ' 1. Cargamos el Combo de Puntos de Venta
            Dim tablaptovta As New DataTable()
            Dim queryPtoVta As String = "SELECT numero, descripcion FROM fact_puntosventa"

            Using conn As New MySqlConnection(GestorConexiones.conexionPrinc.ConnectionString)
                Using cmd As New MySqlCommand(queryPtoVta, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(tablaptovta)
                    End Using
                End Using
            End Using

            ' Agregamos opción "TODOS" a los puntos de venta
            Dim filaTodos As DataRow = tablaptovta.NewRow()
            filaTodos("numero") = -1
            filaTodos("descripcion") = "TODOS LOS PUNTOS"
            tablaptovta.Rows.InsertAt(filaTodos, 0)

            cmbInforPtoVta.DataSource = tablaptovta
            cmbInforPtoVta.DisplayMember = "descripcion"
            cmbInforPtoVta.ValueMember = "numero"

            ' Intentamos setear el punto de venta por defecto
            If tablaptovta.Select("numero = " & My.Settings.idPtoVta).Length > 0 Then
                cmbInforPtoVta.SelectedValue = My.Settings.idPtoVta
            Else
                cmbInforPtoVta.SelectedValue = -1 ' TODOS
            End If

            ' 2. Cargamos los tipos (Esto ahora leerá lo que acabamos de setear en el combo Puntos)
            CargarTiposComprobantes()

            ' 3. Ejecutamos la búsqueda inicial
            cmdbuscar.PerformClick()

        Catch ex As Exception
            MsgBox("Error en carga inicial: " & ex.Message)
        End Try
    End Sub


    ' Función que carga los tipos de comprobantes según el Punto de Venta
    Private Sub CargarTiposComprobantes()
        Try
            If cmbInforPtoVta.SelectedValue Is Nothing Then Exit Sub

            Dim query As String = ""
            Dim ptoVtaSeleccionado As String = cmbInforPtoVta.SelectedValue.ToString()

            ' AHORA NO FILTRAMOS POR DEBCRED, TRAEMOS TODOS (incluido Remitos, etc.)
            If ptoVtaSeleccionado = "%" OrElse ptoVtaSeleccionado = "-1" OrElse String.IsNullOrEmpty(ptoVtaSeleccionado) Then
                query = "SELECT donfdesc, MIN(abrev) as descripcion " &
                    "FROM fact_conffiscal " &
                    "GROUP BY donfdesc " &
                    "ORDER BY donfdesc"
            Else
                query = "SELECT donfdesc, abrev as descripcion " &
                    "FROM fact_conffiscal " &
                    "WHERE ptovta = @ptoVta " &
                    "ORDER BY donfdesc"
            End If

            Dim dtTipos As New DataTable()
            Reconectar()
            Using conn As New MySqlConnection(GestorConexiones.conexionPrinc.ConnectionString)
                Using cmd As New MySqlCommand(query, conn)
                    If ptoVtaSeleccionado <> "%" AndAlso ptoVtaSeleccionado <> "-1" AndAlso Not String.IsNullOrEmpty(ptoVtaSeleccionado) Then
                        cmd.Parameters.AddWithValue("@ptoVta", ptoVtaSeleccionado)
                    End If
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dtTipos)
                    End Using
                End Using
            End Using

            Dim filaTodos As DataRow = dtTipos.NewRow()
            filaTodos("donfdesc") = -1
            filaTodos("descripcion") = "TODOS LOS COMPROBANTES"
            dtTipos.Rows.InsertAt(filaTodos, 0)

            cmbTipoComprobante.DataSource = dtTipos
            cmbTipoComprobante.DisplayMember = "descripcion"
            cmbTipoComprobante.ValueMember = "donfdesc"

        Catch ex As Exception
            MsgBox("Error al cargar los tipos de comprobante: " & ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim idFactura As Integer = dtfacturas.CurrentRow.Cells(0).Value
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabFac As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabEmp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim fac As New datosfacturas
            Dim fa As Boolean

            Reconectar()
            tabEmp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT 
            fac.razon as facrazon, fac.direccion as facdire, fac.localidad as facloca, fac.tipocontr as factipocontr, 
            fac.cuit as faccuit, fac.vendedor as facvend, fac.condvta as faccondvta, fac.total, fac.ptovta, fac.id_cliente,fac.tipofact, fac.remito,DATE_FORMAT(fac.fecha, '%d-%m-%Y'), 
            fac.observaciones
            FROM fact_facturas as fac  
            where fac.id=" & idFactura, GestorConexiones.conexionPrinc)
            Dim encabezado As New DataTable
            tabEmp.Fill(encabezado)

            Select Case encabezado.Rows(0).Item(10)
                Case 998, 2, 3, 7, 8, 991, 993, 994, 995, 996, 997
                    MsgBox("el comprobante no es una factura")
                    Exit Sub
            End Select

            If encabezado.Rows(0).Item(11) <> 0 Then
                MsgBox("Esta factura ya esta remitada")
                Exit Sub
            End If

            If encabezado.Rows(0).Item(10) = 1 Or encabezado.Rows(0).Item(10) = 2 Or encabezado.Rows(0).Item(10) = 3 Then
                fa = True
            End If

            Reconectar()

            tabFac.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select 
            cantidad as cant, descripcion, iva ,format(punit,2,'es_AR') ,format(ptotal,2,'es_AR') as ptotal, cod as codigo,plu from fact_items where id_fact=" & idFactura, GestorConexiones.conexionPrinc)
            Dim items As New DataTable
            tabFac.Fill(items)
            'tabFac.Fill(fac.Tables("facturax"))
            'Dim items() As DataRow
            'items = fac.Tables("facturax").Select()

            Dim ptovta As String = My.Settings.idPtoVta
            Dim tipoFact As Integer = 998
            Dim num_remit As Integer = ObtenerNumerosFact(tipoFact, ptovta)
            Dim idRemito As Integer
            Dim coef As Double = 0
            Dim SqlQuery As String

            If MsgBox("el numero de remito sera: " & ptovta & "-" & num_remit & "   esto es correcto? ", vbYesNo + vbQuestion) = vbNo Then
                Exit Sub
            End If

            Dim fecha As String = Format(CDate(Now()), "yyyy-MM-dd")
            Dim razon As String = encabezado.Rows(0).Item(0)
            Dim direccion As String = encabezado.Rows(0).Item(1)
            Dim localidad As String = encabezado.Rows(0).Item(2)
            Dim tipocontr As String = encabezado.Rows(0).Item(3)
            Dim cuit As String = encabezado.Rows(0).Item(4)
            Dim vendedor As String = encabezado.Rows(0).Item(5)
            Dim condvta As Integer = encabezado.Rows(0).Item(6)
            Dim total As String = encabezado.Rows(0).Item(7)
            Dim idcliente As String = encabezado.Rows(0).Item(9)
            Dim transporte As String = encabezado.Rows(0).Item(13)

            Reconectar()
            SqlQuery = "insert into fact_facturas  
            (tipofact,ptovta, num_fact,fecha,id_cliente,razon,direccion,localidad,tipocontr,cuit,condvta,subtotal,iva105,iva21,total,vendedor,observaciones2) values 
            (?tipofact, ?ptov,?nfac,?fech,?idclie,?razon,?dire,?loca,?tipocont,?cuit,?condvta,?subt,?105,?21,?tot,?vend,?transp)"

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, GestorConexiones.conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?ptov", Val(ptovta))
                .AddWithValue("?tipofact", tipoFact)
                .AddWithValue("?nfac", Val(num_remit))
                .AddWithValue("?fech", fecha)
                .AddWithValue("?idclie", idcliente)
                .AddWithValue("?razon", razon)
                .AddWithValue("?dire", direccion)
                .AddWithValue("?loca", localidad)
                .AddWithValue("?tipocont", tipocontr)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?condvta", condvta)
                .AddWithValue("?subt", 0)
                .AddWithValue("?105", 0)
                .AddWithValue("?21", 0)
                .AddWithValue("?tot", total)
                .AddWithValue("?vend", vendedor)
                .AddWithValue("?transp", transporte)
            End With
            comandoadd.ExecuteNonQuery()
            idRemito = comandoadd.LastInsertedId

            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = GestorConexiones.conexionPrinc
            sql.CommandText = "update fact_conffiscal set confnume=" & Val(num_remit) & " where donfdesc= " & tipoFact & " and ptovta=" & ptovta
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()



            'asignamos el remito a la factura
            SqlQuery = "update fact_facturas set remito=?idremito where id=?idfactura"
            Reconectar()
            Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, GestorConexiones.conexionPrinc)
            With comandoupd.Parameters
                .AddWithValue("?idremito", idRemito)
                .AddWithValue("?idfactura", idFactura)
            End With
            comandoupd.ExecuteNonQuery()



            Dim cod As String
            Dim cantidad As String
            Dim descripcion As String
            Dim iva As String
            Dim punit As String
            Dim ptotal As String
            Dim codbar As String
            Dim i As Integer

            If Val(num_remit) = 0 Then
                MsgBox("No se pueden guardar los items del remito")
                Exit Sub
            End If

            For i = 0 To items.Rows.Count - 1

                If fa = True Then
                    coef = (items.Rows(i).Item(2) + 100) / 100
                Else
                    coef = 1
                End If
                cod = items.Rows(i).Item(5)
                codbar = items.Rows(i).Item(6)
                cantidad = items.Rows(i).Item(0)
                descripcion = items.Rows(i).Item(1)
                iva = items.Rows(i).Item(2)
                punit = items.Rows(i).Item(3) * coef
                ptotal = items.Rows(i).Item(4) * coef

                Dim idAlmacen As Integer = My.Settings.idAlmacen
                Dim idCaja As Integer = My.Settings.CajaDef
                SqlQuery = "insert into fact_items " _
                & "(cod,cantidad, descripcion, iva, punit, ptotal, tipofact,idAlmacen,idCaja,id_fact,plu) values" _
                & "(?cod, ?cant,?desc,?iva,?punit,?ptot,?tipofact,?idAlmacen,?idCaja,?id_fact,?plu)"

                Reconectar()
                Dim comandoadditm As New MySql.Data.MySqlClient.MySqlCommand(SqlQuery, GestorConexiones.conexionPrinc)
                With comandoadditm.Parameters
                    .AddWithValue("?cod", cod)
                    .AddWithValue("?plu", codbar)
                    .AddWithValue("?cant", cantidad)
                    .AddWithValue("?desc", descripcion)
                    .AddWithValue("?iva", iva)
                    .AddWithValue("?punit", punit)
                    .AddWithValue("?ptot", ptotal)
                    .AddWithValue("?tipofact", tipoFact)
                    .AddWithValue("?idAlmacen", idAlmacen)
                    .AddWithValue("?idCaja", idCaja)
                    .AddWithValue("?id_fact", idRemito)

                End With
                'MsgBox(comandoadditm.CommandText)
                comandoadditm.ExecuteNonQuery()
            Next
            MsgBox("Remito generado correctamente, vaya a la pestaña <remitos> para imprimirlo")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdbuscarremitos_Click(sender As Object, e As EventArgs) Handles cmdbuscarremitos.Click
        Dim EnProgreso As New Form
        EnProgreso.ControlBox = False
        EnProgreso.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        EnProgreso.Size = New Point(430, 30)
        EnProgreso.StartPosition = FormStartPosition.CenterScreen
        EnProgreso.TopMost = True
        Dim Etiqueta As New Label
        Etiqueta.AutoSize = True
        Etiqueta.Text = "La consulta esta en progreso, esto puede tardar unos momentos, por favor espere ..."
        Etiqueta.Location = New Point(5, 5)
        EnProgreso.Controls.Add(Etiqueta)
        'Dim Barra As New ProgressBar
        'Barra.Style = ProgressBarStyle.Marquee
        'Barra.Size = New Point(270, 40)
        'Barra.Location = New Point(10, 30)
        'Barra.Value = 100
        'EnProgreso.Controls.Add(Barra)
        EnProgreso.Show()
        Application.DoEvents()
        Dim columna As Integer
        Try

            Dim desde As String = Format(CDate(dtderemitos.Value), "yyyy-MM-dd")
            Dim hasta As String = Format(CDate(dthastaremitos.Value), "yyyy-MM-dd")
            Dim parambusq As String = " and fact.tipofact=998 "


            Reconectar()
            Dim tablaprod As New DataTable
            'Dim filasProd() As DataRow
            'If rdninguno.Checked = True Then
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT " _
                & " fact.id, concat(fis.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) as factnum ,DATE_FORMAT(fact.fecha, '%d-%m-%Y') as fecha,fact.razon,fact.direccion, " _
                & " fact.localidad, con.condicion, " _
                & " fact.observaciones2, fact.tipofact from fact_conffiscal as fis, fact_facturas as fact, fact_condventas as con " _
                & " where fis.donfdesc=fact.tipofact and fis.ptovta=fact.ptovta and con.id=fact.condvta " _
                & " and fact.fecha between '" & desde & "' and '" & hasta & "'" & parambusq & " order by fact.id desc", GestorConexiones.conexionPrinc)
            consulta.Fill(tablaprod)
            'End If
            Dim i As Integer
            dtremitos.DataSource = tablaprod
            dtremitos.Columns(8).Visible = False
            EnProgreso.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            EnProgreso.Close()
        End Try
    End Sub

    Private Sub cmdreimprimirremitos_Click(sender As Object, e As EventArgs) Handles cmdreimprimirremitos.Click
        ImprimirRemito(dtremitos.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub txtNumeroComprobante_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNumeroComprobante.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdbuscar.PerformClick()
        End If
    End Sub

    Private Sub txtrazonsocial_KeyUp(sender As Object, e As KeyEventArgs) Handles txtrazonsocial.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdbuscar.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmdbuscar.PerformClick()
        End If
    End Sub

    Private Sub cmbInforPtoVta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbInforPtoVta.SelectionChangeCommitted
        cmdbuscar.PerformClick()
    End Sub



    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ' 1. Verificamos que haya una fila seleccionada
            If dtfacturas.CurrentRow Is Nothing Then
                MsgBox("Por favor, seleccione una factura de la lista.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' 2. Verificamos si la factura ya tiene un recibo asociado (Tu función original)
            Dim numFactura As String = dtfacturas.CurrentRow.Cells("factnum").Value.ToString()
            If ElementoFacturado(numFactura) = True Then
                MsgBox("LA FACTURA YA TIENE UN RECIBO ASOCIADO, NO SE PUEDE IMPUTAR DOS VECES EL PAGO A UNA MISMA FACTURA", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' 3. Llamamos a tu formulario de recibo rápido
            Dim mov As New reciboRapido()
            ' mov.MdiParent = Me.MdiParent ' Descomentar si usas entorno MDI
            mov.idFactura = CInt(dtfacturas.CurrentRow.Cells("id").Value)
            mov.Show()

        Catch ex As Exception
            MsgBox("Error al intentar abrir el recibo: " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub


    Private Sub reimpresionComprobantes_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Delete And InStr(DatosAcceso.Moduloacc, "SUPERADMIN") = False Then
            MsgBox("NO ESTA AUTORIZADO PARA ELIMINAR FACTURAS")
        ElseIf e.KeyCode = Keys.Delete And InStr(DatosAcceso.Moduloacc, "SUPERADMIN") <> False Then
            If MsgBox("esta seguro que desea elminiar este comprobante? esto no se puede deshacer", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                Reconectar()

                Dim comandofact As New MySql.Data.MySqlClient.MySqlCommand("delete from fact_facturas where id=" & dtfacturas.CurrentRow.Cells(0).Value, GestorConexiones.conexionPrinc)
                comandofact.ExecuteNonQuery()
                Dim comandoItm As New MySql.Data.MySqlClient.MySqlCommand("delete from fact_items where id_fact=" & dtfacturas.CurrentRow.Cells(0).Value, GestorConexiones.conexionPrinc)
                comandoItm.ExecuteNonQuery()
                cmdbuscar.PerformClick()

                MsgBox("comprobante eliminado")
            End If

        End If
    End Sub


    Private Sub bgwBuscarFacturas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwBuscarFacturas.DoWork
        Dim param = DirectCast(e.Argument, Dictionary(Of String, Object))
        Dim dtResultados As New DataTable()

        ' 1. NÚCLEO DE LA CONSULTA (Ahora incluimos TODO por defecto, sin excluir 998 a priori)
        Dim query As String = "SELECT fact.id, concat(fis.abrev,' ',lpad(fact.ptovta,4,'0'),'-',lpad(fact.num_fact,8,'0')) as factnum, " &
                          "DATE_FORMAT(fact.fecha, '%d-%m-%Y') as fecha, fact.razon, fact.direccion, fact.localidad, con.condicion, " &
                          "case when fis.debcred='C' then concat('-',FORMAT(fact.total,2,'es_AR')) else FORMAT(fact.total,2,'es_AR') end as total, " &
                          "fact.observaciones as notas, fact.observaciones2, fact.tipofact, fact.ptovta " &
                          "FROM fact_conffiscal as fis " &
                          "INNER JOIN fact_facturas as fact ON fis.donfdesc = fact.tipofact AND fis.ptovta = fact.ptovta " &
                          "INNER JOIN fact_condventas as con ON con.id = fact.condvta " &
                          "WHERE 1=1 " ' <-- Truco para poder concatenar los "AND" sin problemas

        ' 2. FILTRO DE FECHAS (Obligatorio siempre)
        query &= " AND fact.fecha >= @desde AND fact.fecha <= @hasta "

        ' 3. FILTROS BÁSICOS OPCIONALES
        If param("NumComprobante").ToString() <> "" Then
            query &= " AND fact.num_fact IN (" & param("NumComprobante").ToString() & ") "
        End If

        If param("RazonSocial").ToString() <> "%%" Then
            query &= " AND fact.razon LIKE @razon "
        End If

        ' --- CORRECCIÓN PUNTO DE VENTA ("Todos" vs Específico) ---
        If param("PuntoVenta").ToString() <> "%" AndAlso param("PuntoVenta").ToString() <> "-1" Then
            ' Solo agregamos el WHERE si NO es "Todos" (%)
            query &= " AND fact.ptovta = @ptovta "
        End If

        ' --- CORRECCIÓN TIPO DE COMPROBANTE ("Todos" vs Específico) ---
        If param("TipoComprobante").ToString() <> "%" AndAlso param("TipoComprobante").ToString() <> "-1" Then
            query &= " AND fact.tipofact = @tipoFactura "
        End If

        ' 4. LÓGICA DE COBRANZA ("Sin Pagar") vs BÚSQUEDA GENERAL
        If CBool(param("SoloSinPagar")) Then

            ' Si es Cobranza:
            ' A. Solo queremos comprobantes de Débito (los que generan deuda, 'D')
            query &= " AND fis.debcred = 'D' "
            ' B. Y que no estén pagados (Observaciones2 vacío)
            query &= " AND (fact.observaciones2 = '' OR fact.observaciones2 IS NULL) "

            ' Ordenamiento alfabético para cobranzas
            query &= " ORDER BY fact.razon ASC "

        Else
            ' Si NO es cobranza (Búsqueda General): 
            ' Podemos ver todo: Remitos, Pedidos, Débitos, Créditos.

            ' Solo respetamos el límite (TextBox1)
            Dim limite As Integer = CInt(param("Limite"))
            If limite > 0 Then
                query &= " ORDER BY fact.fecha DESC, fact.razon ASC LIMIT " & limite
            Else
                query &= " ORDER BY fact.fecha DESC, fact.razon ASC "
            End If
        End If

        ' 5. EJECUCIÓN PARAMETRIZADA
        Using conexion As New MySqlConnection(GestorConexiones.conexionPrinc.ConnectionString)
            Using comando As New MySqlCommand(query, conexion)

                ' Aseguramos atrapar todo el día
                comando.Parameters.AddWithValue("@desde", param("FechaDesde").ToString() & " 00:00:00")
                comando.Parameters.AddWithValue("@hasta", param("FechaHasta").ToString() & " 23:59:59")
                comando.Parameters.AddWithValue("@razon", param("RazonSocial"))

                ' Solo agregamos los parámetros si realmente los usamos en la query
                If param("PuntoVenta").ToString() <> "%" AndAlso param("PuntoVenta").ToString() <> "-1" Then
                    comando.Parameters.AddWithValue("@ptovta", param("PuntoVenta"))
                End If

                If param("TipoComprobante").ToString() <> "%" AndAlso param("TipoComprobante").ToString() <> "-1" Then
                    comando.Parameters.AddWithValue("@tipoFactura", param("TipoComprobante"))
                End If

                Using adaptador As New MySqlDataAdapter(comando)
                    adaptador.Fill(dtResultados)
                End Using
            End Using
        End Using

        e.Result = dtResultados
    End Sub

    Private Sub bgwBuscarFacturas_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwBuscarFacturas.RunWorkerCompleted
        Try
            ' Apagamos la animación de la barra
            frmprincipal.pbprincipal.Visible = False
            frmprincipal.lblprocesando.Visible = False

            If e.Error IsNot Nothing Then
                MsgBox("Error en la consulta: " & e.Error.Message, MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim dtResultados As DataTable = TryCast(e.Result, DataTable)

            If dtResultados IsNot Nothing Then
                ' 2. Asignamos los datos a la grilla
                dtfacturas.DataSource = Nothing
                dtfacturas.DataSource = dtResultados

                ' 3. Ocultamos columnas técnicas
                dtfacturas.Columns("id").Visible = False
                dtfacturas.Columns("tipofact").Visible = False

                ' 4. === NUEVO: CALCULAMOS EL TOTAL ===
                ' Usamos tu función existente SumartTotalesColumnaTabla
                ' (Asegúrate de que la etiqueta lblTotal exista en tu Pestaña 1)
                If chksinPagar.Checked = True Then
                    ' Si filtramos "Sin Pagar", mostramos el total de la deuda
                    lblTotal.Text = $"A cobrar: {vbCrLf } ${FormatNumber(SumartTotalesColumnaTabla("total", dtfacturas), 2)}"
                Else
                    ' Si es una búsqueda general, mostramos el total facturado
                    lblTotal.Text = $"Todo: {vbCrLf} ${FormatNumber(SumartTotalesColumnaTabla("total", dtfacturas), 2)}"
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al cargar los datos: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If dtfacturas.CurrentRow IsNot Nothing Then
            Dim idFac As Integer = CInt(dtfacturas.CurrentRow.Cells("id").Value)
            Dim ptoVta As Integer = CInt(dtfacturas.CurrentRow.Cells("ptovta").Value)
            GestorImpresion.GuardarYEnviarComprobantePDF(idFac, ptoVta, False)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If dtfacturas.CurrentRow IsNot Nothing Then
            Dim idFac As Integer = CInt(dtfacturas.CurrentRow.Cells("id").Value)
            Dim ptoVta As Integer = CInt(dtfacturas.CurrentRow.Cells("ptovta").Value)
            GestorImpresion.GuardarYEnviarComprobantePDF(idFac, ptoVta, True)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        GenerarExcel(dtfacturas)

    End Sub
End Class