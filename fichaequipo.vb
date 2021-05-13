Public Class fichaequipo
    Public ORden As Integer
    Private ModProd As Boolean = False
    Dim FECHAGRAL As Date = CDate(Now)

    Private Sub fichaequipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub
    Private Sub tmrComprobarOR_Tick(sender As Object, e As EventArgs) Handles tmrComprobarOR.Tick
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select max(id) from tecni_taller", conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            If Not IsDBNull(infocl(0)(0)) Then
                txtnumor.Text = infocl(0)(0) + 1
            Else
                txtnumor.Text = "1"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub fichaequipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            If ORden = 0 Then
                CargarCategoriastrab()
                CargarTipoEquipo()
                cargarMarcas()
                CargarUsuarios()
                CargarTecnicos()
                CargarEstadoTall()
                CargarListas()

                'habilitamos los controles para cargar un trabajo sin haber cargado ficha de ingreso
                cmbcattrab.Enabled = True
                txtctaclie.ReadOnly = False
                txtrazon.ReadOnly = False
                cmbrecibeusuario.Enabled = True
                txtmail.ReadOnly = False
                txttelefono.ReadOnly = False
                cmbtipoequ.Enabled = True
                cmbmodelos.Enabled = True
                cmbmarcas.Enabled = True
                txtnumeroSerie.ReadOnly = False
                txtaccesorios.ReadOnly = False
                txtmotivo.ReadOnly = False
                tmrComprobarOR.Enabled = True
                lblfecha.Text = Format(FECHAGRAL, "dd-MM-yyyy")
                cmbrecibeusuario.SelectedValue = DatosAcceso.UsuarioINT

                'MsgBox("No hay orden que cargar")
            Else
                'lblfecha.Text = "Fecha actual: " & Format(Now, "dd-MMMM-yyyy")
                CargarCategoriastrab()
                CargarTipoEquipo()
                cargarMarcas()
                CargarUsuarios()
                CargarTecnicos()
                CargarEstadoTall()
                CargarListas()
                cargarOrden()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarOrden()
        Try
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT tall.trabajo_categoria, tall.equipo, tall.cliente, cl.nomapell_razon,tall.recibe, eq.tipo_equ,eq.marca,eq.modelo, tall.serie, 
            tall.accesorios, tall.motivo_ing, tall.observaciones, tall.falla, tall.tarea_realiz, format(tall.mo_monto,2,'es_AR') as mo_monto,tall.actualizado,tall.tecnico,tall.infoextra,tall.estado,tall.modelo,tall.fecha_ing, 
            tall.trab_estado, tall.mail, tall.telefono,tall.presupuesto, 
            if (tall.fecha_eg like '0000-00-00','SIN TERMINAR',tall.fecha_eg), cl.lista_precios,
            (select especificaciones from tecni_equipos_clientes where id=tall.equipo) as especificaciones 
            FROM tecni_taller as tall, fact_clientes as cl, tecni_equipos as eq 
            where tall.cliente=cl.idclientes and tall.modelo=eq.id and tall.id=" & ORden, conexionPrinc)
            Dim tablaequipo As New DataTable
            Dim infoequ() As DataRow
            consulta.Fill(tablaequipo)
            infoequ = tablaequipo.Select("")
            cmbcattrab.SelectedValue = infoequ(0)(0)
            txtnumor.Text = CompletarCeros(ORden, 2)
            txtcodint.Text = infoequ(0)(1)
            txtctaclie.Text = infoequ(0)(2)
            txtrazon.Text = infoequ(0)(3)
            cmbrecibeusuario.SelectedValue = infoequ(0)(4)
            cmbtipoequ.SelectedValue = infoequ(0)(5)
            cmbmarcas.SelectedValue = infoequ(0)(6)
            cmbmodelos.SelectedValue = infoequ(0)(7)
            txtnumeroSerie.Text = infoequ(0)(8)
            txtaccesorios.Text = infoequ(0)(9)
            txtmotivo.Text = infoequ(0)(10)
            txtobservaciones.Text = infoequ(0)(11)
            txtfalla.Text = infoequ(0)(12)
            txtresolucion.Text = infoequ(0)(13)
            txtmanoobra.Text = infoequ(0)(14)
            lblfechaact.Text = "Revisado:" & infoequ(0)(15).ToString
            If infoequ(0)(16) = 0 And infoequ(0)(18) <> 8 Then
                cmbtecnico.SelectedValue = DatosAcceso.Tecnico 'infoequ(0)(16)
            Else
                cmbtecnico.SelectedValue = infoequ(0)(16)
            End If

            txtinfoextra.Text = infoequ(0)(17)
            cmbestadotrab.SelectedValue = infoequ(0)(18)
            If infoequ(0)(18) = 8 Then
                cmdfinalizar.Enabled = False
                lblfechafin.Text = "Finalizado: " & infoequ(0)(25).ToString
                cmdimprimir.Enabled = True
            End If
            lblmodelo.Text = infoequ(0)(19)
            lblfecha.Text = "Ingreso: " & infoequ(0)(20).ToString
            If infoequ(0)(21) = 1 Then
                chkfacturado.Checked = True
            End If
            txtmail.Text = infoequ(0)(22).ToString
            txttelefono.Text = infoequ(0)(23).ToString
            txtpresupuesto.Text = infoequ(0)(24).ToString
            'cargamos los repuestos
            txtespecificaciones.Text = infoequ(0)("especificaciones").ToString
            Dim consultarep As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,codigo,plu,cantidad,descripcion,
            format(iva,2,'es_AR') as iva, format(punit,2,'es_AR') as punit,format(ptotal,2,'es_AR') as ptotal,idtaller 
            from tecni_taller_insumos where idtaller=" & ORden, conexionPrinc)
            Dim tablarep As New DataTable
            Dim inforep() As DataRow
            Dim i As Integer
            consultarep.Fill(tablarep)
            inforep = tablarep.Select("")
            dtproductos.Rows.Clear()
            For i = 0 To inforep.GetUpperBound(0)
                dtproductos.Rows.Add(inforep(i)(0), inforep(i)(1), inforep(i)(3), inforep(i)(4), inforep(i)(5), inforep(i)(6), inforep(i)(7))
                dtproductos.Rows(dtproductos.RowCount - 2).DefaultCellStyle.BackColor = Color.GreenYellow
            Next
            cmblistaprecio.SelectedValue = infoequ(0)(26)
            CalcularTotales()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CargarCategoriastrab()
        Reconectar()
        Dim tablacattrab As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from tecni_trabajo_categoria", conexionPrinc)
        Dim readcattrab As New DataSet
        tablacattrab.Fill(readcattrab)
        cmbcattrab.DataSource = readcattrab.Tables(0)
        cmbcattrab.DisplayMember = readcattrab.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbcattrab.ValueMember = readcattrab.Tables(0).Columns(0).Caption.ToString
        cmbcattrab.SelectedIndex = -1

    End Sub

    Private Sub CargarEstadoTall()
        Reconectar()
        Dim tablaesttall As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from tecni_taller_estado where id<>18", conexionPrinc)
        Dim readesttall As New DataSet
        tablaesttall.Fill(readesttall)
        cmbestadotrab.DataSource = readesttall.Tables(0)
        cmbestadotrab.DisplayMember = readesttall.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbestadotrab.ValueMember = readesttall.Tables(0).Columns(0).Caption.ToString
        cmbestadotrab.SelectedIndex = -1

    End Sub

    Private Sub CargarUsuarios()
        Reconectar()
        Dim tablausuarios As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,',',nombre) from cm_usuarios ", conexionPrinc)
        Dim readusuarios As New DataSet
        tablausuarios.Fill(readusuarios)
        cmbrecibeusuario.DataSource = readusuarios.Tables(0)
        cmbrecibeusuario.DisplayMember = readusuarios.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbrecibeusuario.ValueMember = readusuarios.Tables(0).Columns(0).Caption.ToString
        cmbrecibeusuario.SelectedIndex = -1

    End Sub
    Private Sub CargarTecnicos()
        Reconectar()
        Dim tablatecnicos As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(apellido,',',nombre) from tecni_tecnicos where activo=1 ", conexionPrinc)
        Dim readtecnicos As New DataSet
        tablatecnicos.Fill(readtecnicos)
        cmbtecnico.DataSource = readtecnicos.Tables(0)
        cmbtecnico.DisplayMember = readtecnicos.Tables(0).Columns(1).Caption.ToString.ToUpper
        cmbtecnico.ValueMember = readtecnicos.Tables(0).Columns(0).Caption.ToString
        cmbtecnico.SelectedValue = DatosAcceso.Tecnico

    End Sub

    Private Sub cargarMarcas()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos marcas
            Dim tablamarca As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_marcas order by nombre asc", conexionPrinc)
            Dim readmarc As New DataSet
            tablamarca.Fill(readmarc)
            cmbmarcas.DataSource = readmarc.Tables(0)
            cmbmarcas.DisplayMember = readmarc.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbmarcas.ValueMember = readmarc.Tables(0).Columns(0).Caption.ToString
            cmbmarcas.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cargarModelos(ByRef marca As Integer)
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos marcas
            Dim tablamodelo As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from fact_modelos where idmarca=" & marca & " order by nombre asc", conexionPrinc)
            Dim readmod As New DataSet
            tablamodelo.Fill(readmod)
            cmbmodelos.DataSource = readmod.Tables(0)
            cmbmodelos.DisplayMember = readmod.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbmodelos.ValueMember = readmod.Tables(0).Columns(0).Caption.ToString
            cmbmodelos.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargarTipoEquipo()
        Try
            Reconectar()
            Dim tablatipoeq As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from tecni_equipos_tipo", conexionPrinc)
            Dim readtipoequ As New DataSet
            tablatipoeq.Fill(readtipoequ)
            cmbtipoequ.DataSource = readtipoequ.Tables(0)
            cmbtipoequ.DisplayMember = readtipoequ.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbtipoequ.ValueMember = readtipoequ.Tables(0).Columns(0).Caption.ToString
            cmbtipoequ.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarListas()
        Try
            Reconectar()
            Dim tablautil As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_listas_precio", conexionPrinc)
            Dim readutil As New DataSet
            tablautil.Fill(readutil)
            cmblistaprecio.DataSource = readutil.Tables(0)
            cmblistaprecio.DisplayMember = readutil.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmblistaprecio.ValueMember = readutil.Tables(0).Columns(0).Caption.ToString
            cmblistaprecio.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    
    Public Sub cargarProdCod(ByRef fila As Integer)
        Dim codPLU As String = dtproductos.Rows(fila).Cells(1).Value
        Dim Busq As String
        If codPLU = "" Then
            MsgBox("Debe ingresar un codigo o PLU")
            dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.Red
            Exit Sub
        End If
        If InStr(codPLU, "#") = 1 Then
            Busq = "where cod_bar= " & Microsoft.VisualBasic.Right(codPLU, codPLU.Length - 1)
        ElseIf IsNumeric(codPLU) Then
            Busq = "where id=" & codPLU & " or codigo like '" & codPLU & "'"
        ElseIf Not IsNumeric(codPLU) Then
            Busq = "where  codigo like '" & codPLU & "' or cod_bar like '" & codPLU & "'"
        End If

        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id,codigo,iva,descripcion FROM fact_insumos " & Busq, conexionPrinc)
        Dim tablaprod As New DataTable
        Dim filasProd() As DataRow
        'MsgBox(consulta.SelectCommand.CommandText)
        consulta.Fill(tablaprod)
        'dtproductos.DataSource = tablaprod
        '        dtproductos.Rows.Clear()
        filasProd = tablaprod.Select("")
        'cmbcondvta.Enabled = False
        'cmbtipocontr.Enabled = False
        For i = 0 To filasProd.GetUpperBound(0)
            'If ObtenerStock(filasProd(i)(0)) = 0 Then
            '    MsgBox("No hay stock de este producto")
            '    dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.Red
            '    Exit For
            '    Exit Sub
            'End If
            dtproductos.Rows(fila).Cells(0).Value = filasProd(i)(0)
            dtproductos.Rows(fila).Cells(1).Value = filasProd(i)(1)
            dtproductos.Rows(fila).Cells(2).Value = 1
            dtproductos.Rows(fila).Cells(3).Value = filasProd(i)(3)
            dtproductos.Rows(fila).Cells(4).Value = filasProd(i)(2)
            dtproductos.Rows(fila).Cells(5).Value = calcularPrecio(dtproductos.Rows(fila).Cells(0).Value)
            dtproductos.Rows(fila).Cells(6).Value = calcularPrecio(dtproductos.Rows(fila).Cells(0).Value)
            dtproductos.Rows(fila).DefaultCellStyle.BackColor = Color.GreenYellow
        Next
    End Sub

    Private Function calcularPrecio(ByRef codProd As String) As Double
        Try
            Dim ganancia As Double
            
            Reconectar()
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT precio, ganancia, iva, moneda FROM fact_insumos where id=" & codProd, conexionPrinc)
            Dim tablaprod As New DataTable
            Dim filasProd() As DataRow
            consulta.Fill(tablaprod)
            filasProd = tablaprod.Select("")

            'cargamos listas de precios
            Dim consultalis As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT utilidad FROM fact_listas_precio where id=" & cmblistaprecio.SelectedValue, conexionPrinc)
            Dim tablalistas As New DataTable
            Dim filaslistas() As DataRow
            consultalis.Fill(tablalistas)
            filaslistas = tablalistas.Select("")

            'cargamos la moneda perteneciente a este producto
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select (select cotizacion from fact_moneda  where  id =" & filasProd(0)(3) & ") as cotiza, (select valor from fact_configuraciones where  id =1) as lista"
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            Dim cotizacion As Double = FormatNumber(lector("cotiza").ToString)
            'Dim coeflista As Double = (FormatNumber(lector("lista").ToString) + 100) / 100


            Dim precioCosto As Double = FormatNumber(filasProd(0)(0))
            Dim iva As Double = (FormatNumber(filasProd(0)(2)) + 100) / 100
            Dim utilidad As Double = (FormatNumber(filasProd(0)(1)) + 100) / 100
            Dim lista As Double = (FormatNumber(filaslistas(0)(0)) + 100) / 100
            'Dim InteresLista As Double = (FormatNumber(filasProd(0)(0)) + 100) / 100
            ' MsgBox(precioCosto & " " & iva & " " & utilidad & " " & lista)
            Dim PrecioSinIva As Double
            Dim PrecioVenta As Double

            PrecioSinIva = precioCosto * cotizacion * utilidad * lista


            PrecioVenta = PrecioSinIva * iva


            Return Math.Round(PrecioVenta, 2)

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub CalcularTotales()
        Try
            'Dim fila As New DataGridViewRow
            Dim i As Integer
            Dim subtotal As Double
            Dim subtotal105 As Double
            Dim subtotal21 As Double
            Dim iva105 As Double
            Dim iva21 As Double
            Dim total As Double
            Dim manoObra As Double = txtmanoobra.Text
            For i = 0 To dtproductos.RowCount - 2
                subtotal += FormatNumber(dtproductos.Rows(i).Cells(6).Value)
            Next

            txttotalinsumos.Text = FormatNumber(subtotal, 2)
            txttotaltrabajo.Text = FormatNumber(manoObra + subtotal, 2)
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub GuardarEspecificaciones()
    '    Try
    '        Dim sqlQuery As String
    '        sqlQuery = "update tecni_equipos_clientes set especificaciones = " & txtespecificaciones.Text.ToUpper & " where id= " & codint

    '        Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
    '        With comandoadd.Parameters


    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub GuardarOrden(ByRef estado As Integer)
        Try
            Dim cliente As Integer = txtctaclie.Text
            Dim motivoIng As String = txtmotivo.Text.ToUpper
            Dim accesorios As String = txtaccesorios.Text.ToUpper
            'Dim fecha As String = FECHAGRAL
            Dim modelo As Integer = lblmodelo.Text
            Dim trabajoCategoria As Integer = cmbcattrab.SelectedValue
            Dim infoExtra As String = txtinfoextra.Text.ToUpper
            Dim tecnico As Integer = cmbtecnico.SelectedValue
            Dim recibe As Integer = cmbrecibeusuario.SelectedValue

            'Dim estado As Integer = cmbestadotrab.SelectedValue
            Dim falla As String = txtfalla.Text
            Dim resolucion As String = txtresolucion.Text
            Dim observaciones As String = txtobservaciones.Text
            Dim precioMO As String = txtmanoobra.Text.ToString.Replace(".", "").Replace(",", ".")
            Dim precioINS As String = txttotalinsumos.Text.ToString.Replace(".", "").Replace(",", ".")
            Dim precioTOT As String = txttotaltrabajo.Text.ToString.Replace(".", "").Replace(",", ".")
            Dim sqlQuery As String
            Dim codInt As String = txtcodint.Text
            Reconectar()
            sqlQuery = "INSERT INTO tecni_taller(id,equipo,trab_estado,tecnico,estado,falla,tarea_realiz,
            observaciones,trab_monto,ins_monto,mo_monto,infoextra,presupuesto,mail,telefono,serie,
            cliente, motivo_ing,accesorios,fecha_ing,fecha_eg,modelo,trabajo_categoria,recibe) VALUES(
            ?id,?codint,?trabest,?tecnico,?estado,?falla,?resolucion,?observaciones,?preciotot,?precioins,
            ?preciomo,?extra,?presup,?mail,?telefono,?serie,
            ?cliente,?motivoIng,?accesorios,?fechaIng,?fechaEg,?modeloEq,?trabCateg,?recibe)    
            
            ON DUPLICATE KEY UPDATE  equipo=?codint, trab_estado=?trabest, 
            tecnico=?tecnico, estado=?estado, falla=?falla, tarea_realiz=?resolucion, 
            observaciones=?observaciones, trab_monto=?preciotot, ins_monto=?precioins, 
            mo_monto=?preciomo, infoextra=?extra, presupuesto=?presup, mail=?mail, 
            telefono=?telefono, serie=?serie, cliente=?cliente,motivo_ing=?motivoIng,
            accesorios=?accesorios,fecha_ing=?fechaIng,fecha_eg=?fechaEg,modelo=?modeloEq,
            trabajo_categoria=?trabCateg,recibe=?recibe"

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?tecnico", tecnico)
                .AddWithValue("?estado", estado)
                .AddWithValue("?falla", falla)
                .AddWithValue("?resolucion", resolucion)
                .AddWithValue("?observaciones", observaciones)
                .AddWithValue("?preciomo", precioMO)
                .AddWithValue("?preciotot", precioTOT)
                .AddWithValue("?precioins", precioINS)
                .AddWithValue("?extra", txtinfoextra.Text.ToUpper)
                .AddWithValue("?codint", codInt)
                .AddWithValue("?presup", txtpresupuesto.Text)
                .AddWithValue("?mail", txtmail.Text)
                .AddWithValue("?telefono", txttelefono.Text)
                .AddWithValue("?serie", txtnumeroSerie.Text)
                .AddWithValue("?id", ORden)
                .AddWithValue("?cliente", cliente)
                .AddWithValue("?motivoIng", motivoIng)
                .AddWithValue("?accesorios", accesorios)
                .AddWithValue("?fechaIng", Format(FECHAGRAL, "yyyy-MM-dd"))
                .AddWithValue("?fechaEg", Format(FECHAGRAL, "yyyy-MM-dd"))
                .AddWithValue("?modeloEq", modelo)
                .AddWithValue("?trabCateg", trabajoCategoria)
                .AddWithValue("?recibe", recibe)

                If chkfacturado.Checked = True Then
                    .AddWithValue("?trabest", 1)
                Else
                    .AddWithValue("?trabest", 3)
                End If
            End With
            comandoadd.ExecuteNonQuery()

            If codInt = 0 And txtespecificaciones.Text <> "" Then
                MsgBox("no se puede guardar las especificaciones hasta que se finalice la orden")
            Else
                ' guardarEspecificaciones
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim cod As String
            Dim cantidad As String
            Dim descripcion As String
            Dim iva As String
            Dim punit As String
            Dim ptotal As String
            Dim plu As String
            'Dim num_fact As String

            Dim sqlQuery As String
            Dim i As Integer
            sqlQuery = "DELETE FROM tecni_taller_insumos where idtaller=" & ORden
            Reconectar()
            Dim comandodel As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            comandodel.ExecuteNonQuery()

            For i = 0 To dtproductos.RowCount - 2
                If IsNothing(dtproductos.Rows(i).Cells(0).Value) Then
                    cod = 0
                Else
                    cod = dtproductos.Rows(i).Cells(0).Value
                End If
                plu = dtproductos.Rows(i).Cells(1).Value
                cantidad = dtproductos.Rows(i).Cells(2).Value.ToString.Replace(".", "").Replace(",", ".")
                descripcion = dtproductos.Rows(i).Cells(3).Value.ToString.ToUpper
                iva = dtproductos.Rows(i).Cells(4).Value.ToString.Replace(".", "").Replace(",", ".")
                punit = dtproductos.Rows(i).Cells(5).Value.ToString.Replace(".", "").Replace(",", ".")
                ptotal = dtproductos.Rows(i).Cells(6).Value.ToString.Replace(".", "").Replace(",", ".")

                sqlQuery = "insert into tecni_taller_insumos " _
                & "(codigo,plu,cantidad, descripcion, iva, punit, ptotal,idtaller ) values" _
                & "(?cod,?plu, ?cant,?desc,?iva,?punit,?ptot,?tall)"
                Reconectar()
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters
                    .AddWithValue("?cod", cod)
                    .AddWithValue("?plu", plu)
                    .AddWithValue("?cant", cantidad)
                    .AddWithValue("?desc", descripcion)
                    .AddWithValue("?iva", iva)
                    .AddWithValue("?punit", punit)
                    .AddWithValue("?ptot", ptotal)
                    .AddWithValue("?tall", ORden)

                End With
                comandoadd.ExecuteNonQuery()
            Next


            ModProd = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub guardaEquipoCliente()
        Try

            Dim propietario As Integer = Val(txtctaclie.Text)
            Dim serie As String = txtnumeroSerie.Text
            ' Dim modelo As Integer = Val(lblmodelo.Text)
            Dim especificaciones As String = txtespecificaciones.Text.ToUpper
            Dim sqlQuery

            Dim tipoeq As Integer = cmbtipoequ.SelectedValue
            Dim marca As Integer = cmbmarcas.SelectedValue
            Dim modelo As Integer = cmbmodelos.SelectedValue
            '            Dim serie As String = txtnumeroSerie.Text.ToUpper
            Dim equipo As Integer


            If tipoeq = 0 Then
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "insert into tecni_equipos_tipo(nombre) values ('" & cmbtipoequ.Text.ToUpper & "')"
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                tipoeq = sql.LastInsertedId
            End If

            If marca = 0 Then
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "insert into fact_marcas (nombre) values ('" & cmbmarcas.Text.ToUpper & "')"
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                marca = sql.LastInsertedId
            End If

            If modelo = 0 Then
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "insert into fact_modelos (idmarca, nombre) values ('" & marca & "','" & cmbmodelos.Text.ToUpper & "')"
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                modelo = sql.LastInsertedId
            End If

            Reconectar()
            Dim consultaeq As New MySql.Data.MySqlClient.MySqlDataAdapter("select id from tecni_equipos where marca=" & marca & " and modelo=" & modelo & " and tipo_equ=" & tipoeq, conexionPrinc)
            Dim tablaeq As New DataTable
            Dim infoeq() As DataRow
            consultaeq.Fill(tablaeq)
            If tablaeq.Rows.Count = 0 Then
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "insert into tecni_equipos (marca, modelo,tipo_equ) values ('" & marca & "','" & modelo & "','" & tipoeq & "')"
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                equipo = sql.LastInsertedId
            ElseIf tablaeq.Rows.Count > 1 Then
                'MsgBox("Hay mas de un modelo para la combinacion - " & tablaeq.Rows.Count)
                infoeq = tablaeq.Select("")
                equipo = infoeq(0)(0)
                'MsgBox(equipo)
            ElseIf tablaeq.Rows.Count = 1 Then
                infoeq = tablaeq.Select("")
                equipo = infoeq(0)(0)
                ' MsgBox(equipo)
            End If
            lblmodelo.Text = equipo


            sqlQuery = "insert into tecni_equipos_clientes " _
            & "(propietario,serie,estado,modelo, especificaciones ) values" _
            & "(?prop,?ser,'1',?modelo,?especificaciones)"

            Reconectar()
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?prop", propietario)
                .AddWithValue("?ser", serie)
                .AddWithValue("?modelo", equipo)
                .AddWithValue("?especificaciones", especificaciones)
            End With
            comandoadd.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbmarcas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbmarcas.SelectedValueChanged
        Try
            cargarModelos(cmbmarcas.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtproductos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellEndEdit
        SendKeys.Send("{UP}")
        SendKeys.Send("{TAB}")
        Try
            Reconectar()
            If e.ColumnIndex = 1 Then
                '   If dtproductos.Rows(e.RowIndex).Cells(1).Value <> 0 Then
                cargarProdCod(e.RowIndex)
                ' End If
            ElseIf e.ColumnIndex = 2 Then
                'If ObtenerStock(dtproductos.CurrentRow.Cells(1).Value) < dtproductos.CurrentCell.Value Then
                '    MsgBox("Stock insuficiente")
                '    dtproductos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
                '    Exit Sub
                'End If
                Dim pUnit As Double = dtproductos.Rows(e.RowIndex).Cells(5).Value
                Dim cant As Double = dtproductos.Rows(e.RowIndex).Cells(2).Value
                dtproductos.Rows(e.RowIndex).Cells(6).Value = Math.Round(pUnit * cant, 2)
                dtproductos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow
                CalcularTotales()
            ElseIf e.ColumnIndex = 3 Then
                selprod.busqueda = dtproductos.CurrentCell.Value()
                selprod.fila = dtproductos.CurrentCellAddress.Y
                selprod.LLAMA = "fichaequipo"
                selprod.dtproductos.Focus()
                selprod.Show()
                selprod.TopMost = True
            ElseIf e.ColumnIndex = 5 Then
                dtproductos.CurrentCell.Value = dtproductos.CurrentCell.Value
                Dim pUnit As Double = dtproductos.CurrentCell.Value
                Dim cant As Double = dtproductos.Rows(e.RowIndex).Cells(2).Value
                dtproductos.Rows(e.RowIndex).Cells(6).Value = Math.Round(pUnit * cant, 2)
                dtproductos.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.GreenYellow
                CalcularTotales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtmanoobra_Leave(sender As Object, e As EventArgs) Handles txtmanoobra.Leave
        Try
            txtmanoobra.Text = txtmanoobra.Text
            txtmanoobra.SelectionStart = txtmanoobra.TextLength
            CalcularTotales()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        Try
            GuardarOrden(cmbestadotrab.SelectedValue)
            MsgBox("Orden de reparacion actualizada")
            Reconectar()
            Dim consultaDtosMail As New MySql.Data.MySqlClient.MySqlDataAdapter("select texto1 from tecni_datosgenerales where id>=3 and id<=14", conexionPrinc)
            Dim tablaDtosMail As New DataTable
            Dim infoDtosMail() As DataRow
            consultaDtosMail.Fill(tablaDtosMail)
            infoDtosMail = tablaDtosMail.Select("")
            If infoDtosMail.Count > 2 Then
                'enviar mail a la casilla
                Dim mail As String = infoDtosMail(0)(0) & txtrazon.Text & vbNewLine _
                                 & infoDtosMail(1)(0) & " " & txtnumor.Text & vbNewLine _
                                 & infoDtosMail(2)(0) & " " & cmbtipoequ.Text & "-" & cmbmarcas.Text & "-" & cmbmodelos.Text & " Serie: " & txtnumeroSerie.Text.ToUpper & vbNewLine _
                                 & infoDtosMail(3)(0) & " " & txtfalla.Text & vbNewLine _
                                 & infoDtosMail(4)(0) & " " & txtresolucion.Text & vbNewLine _
                                 & infoDtosMail(5)(0) & " " & txtpresupuesto.Text & vbNewLine _
                                 & infoDtosMail(6)(0) & " " & cmbestadotrab.Text & vbNewLine _
                                 & infoDtosMail(7)(0) & " " & vbNewLine & vbNewLine _
                                 & infoDtosMail(8)(0) & " " & vbNewLine _
                                 & infoDtosMail(9)(0) & " " & vbNewLine _
                                 & infoDtosMail(10)(0) & " "
                Dim para As String = txtmail.Text.Replace(",", ".").ToLower
                Dim asunto As String = infoDtosMail(11)(0) & " " & txtnumor.Text & "  " & txtrazon.Text & "(" & txtinfoextra.Text & ")"

                If chkenviamail.Checked = True And cmbestadotrab.SelectedValue <> 8 Then
                    EnviarMail(mail, para, asunto)
                End If
            End If

            cargarOrden()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdfinalizar_Click(sender As Object, e As EventArgs) Handles cmdfinalizar.Click
        Try
            Dim codint As Integer
            Dim numsig As Integer
            ORden = txtnumor.Text
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            'tiene que haber un tecnico
            If cmbtecnico.SelectedIndex = -1 Or cmbtecnico.SelectedValue = 0 Then
                MsgBox("Debe seleccionar el tecnico que realizo el trabajo")
                Exit Sub
            End If

            'averiguamos el numero de equipo nuevo
            If Val(txtcodint.Text) = 0 Then
                sql.Connection = conexionPrinc
                sql.CommandText = "select max(id) as codint from tecni_equipos_clientes"
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                If IsDBNull(lector("codint")) Then
                    numsig = 1
                Else
                    numsig = lector("codint") + 1
                End If

                If MsgBox("EL EQUIPO NO TIENE UN CODIGO INTERNO ASIGNADO. SE LE ASIGNARA EL NUMERO " & numsig & vbNewLine & ". ESTA DE ACUERDO?", vbQuestion + vbYesNo) = vbYes Then
                    guardaEquipoCliente()
                    codint = numsig
                    txtcodint.Text = codint
                Else
                    Exit Sub
                End If
            Else
                codint = Val(txtcodint.Text)
            End If
            tmrComprobarOR.Enabled = False
            GuardarOrden(cmbestadotrab.SelectedValue)


            Reconectar()
            sql.Connection = conexionPrinc
            sql.CommandText = "update tecni_taller set estado=8, trab_estado=3,fecha_eg='" & Format(FECHAGRAL, "yyyy-MM-dd") & "', equipo=" & codint & " where id=" & ORden
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            MsgBox("Orden de reparacion terminada")
            cmdimprimir.Enabled = True
            cmdfinalizar.Enabled = False
            tecnico.refrescarTaller = False
            tecnico.refrescarTrabajos = False
            cargarOrden()

            Reconectar()
            Dim consultaDtosMail As New MySql.Data.MySqlClient.MySqlDataAdapter("select texto1 from tecni_datosgenerales where id>=15 and id<=25", conexionPrinc)
            Dim tablaDtosMail As New DataTable
            Dim infoDtosMail() As DataRow
            consultaDtosMail.Fill(tablaDtosMail)
            infoDtosMail = tablaDtosMail.Select("")
            'enviar mail a la casilla
            Dim mail As String = infoDtosMail(0)(0) & " " & txtrazon.Text & vbNewLine _
                                 & infoDtosMail(1)(0) & " " & txtnumor.Text & vbNewLine _
                                 & infoDtosMail(2)(0) & " " & cmbtipoequ.Text & "-" & cmbmarcas.Text & "-" & cmbmodelos.Text & " Serie: " & txtnumeroSerie.Text.ToUpper & vbNewLine _
                                 & infoDtosMail(3)(0) & " " & txtfalla.Text & vbNewLine _
                                 & infoDtosMail(4)(0) & " " & txtresolucion.Text & vbNewLine _
                                 & infoDtosMail(5)(0) & "  " & txtpresupuesto.Text & vbNewLine _
                                 & infoDtosMail(6)(0) & " " & vbNewLine & vbNewLine _
                                 & infoDtosMail(7)(0) & " " & vbNewLine _
                                 & infoDtosMail(8)(0) & " " & vbNewLine _
                                 & infoDtosMail(9)(0) & " "
            Dim para As String = txtmail.Text.Replace(",", ".").ToLower
            Dim asunto As String = infoDtosMail(10)(0) & " " & txtnumor.Text & txtrazon.Text & "(" & txtinfoextra.Text & ")"




            If chkenviamail.Checked = True Then
                EnviarMail(mail, para, asunto)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdimprimir_Click(sender As Object, e As EventArgs) Handles cmdimprimir.Click
        Try
            'Dim orden As Integer = 
            Dim tablaDTGFicha As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dsDTGFicha As New datostaller

            Dim tablaFacturacion As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dsFacturacion As New datosgenerales

            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select texto1 as pie from tecni_datosgenerales WHERE id=2", conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("datosFichaEgreso"))


            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "lpad(tall.id,4,'0') as orden, " _
            & "concat('FECHA INGRESO: ',tall.fecha_ing) as fecha, case tall.trabajo_categoria " _
            & "when 4 then concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon,'(',tall.infoextra,')') " _
            & "when 2 then concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon) " _
            & "when 3 then concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon) " _
            & "end  as clientectarazon, " _
            & "concat('CLIENTE: ', cl.idclientes,' - ',cl.nomapell_razon) as clientectarazon, " _
            & "concat('CODINT: ',tall.equipo) as codint, " _
            & "concat('RECIBIO: ',us.apellido,', ', us.nombre) as recibio, " _
            & "concat('TIPO EQUIPO: ', et.nombre) as equipotipo, " _
            & "concat('MARCA/MODELO: ', ma.nombre,'/', mo.nombre) as equipomarcamodelo, " _
            & "concat('ACCESORIOS: ',tall.accesorios) as accesorios, " _
            & "concat('MOTIVO: ', tall.motivo_ing) as motivo, " _
            & "concat('DIRECCION: ', cl.dir_domicilio,'TEL: ',cl.telefono,'| CEL: ',cl.celular) as clientedire, " _
            & "concat('SERIE: ', tall.serie) as equiposerie " _
            & "from tecni_taller as tall, fact_clientes as cl, cm_usuarios as us, fact_marcas as ma, fact_modelos as mo, tecni_equipos_tipo as et, " _
            & "tecni_equipos as eq " _
            & "where " _
            & "tall.cliente=cl.idclientes and tall.modelo=eq.id and eq.tipo_equ=et.id and eq.marca=ma.id and eq.modelo=mo.id and tall.recibe=us.id " _
            & "and tall.id=" & ORden, conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("fichaIngreso"))

            Reconectar()
            tablaDTGFicha.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("SELECT tall.falla as falla, tall.tarea_realiz as resolucion, tall.mo_monto as montomo, tall.ins_monto as montoins, tall.trab_monto as montotot, tall.fecha_eg as fecha, concat(te.apellido,', ', te.nombre) as tecnico " _
            & " FROM tecni_taller as tall, tecni_tecnicos as te where tall.tecnico=te.id and tall.id =" & ORden, conexionPrinc)
            tablaDTGFicha.Fill(dsDTGFicha.Tables("fichaEgreso"))

            Reconectar()
            tablaFacturacion.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select nombrefantasia, razonsocial, concat('Direccion: ',direccion,' - ',otrosdatos) as direccion, localidad, cuit, ingbrutos, ivatipo, inicioact, drei from fact_empresa where id=1", conexionPrinc)
            tablaFacturacion.Fill(dsFacturacion.Tables("datosEmpresa"))

            Dim imping As New imprimiregreso
            With imping
                .MdiParent = Me.MdiParent
                .rptegreso.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptegreso.LocalReport.ReportEmbeddedResource = System.Environment.CurrentDirectory & "\reportes\fichaegreso.rdlc"
                .rptegreso.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\fichaegreso.rdlc"
                .rptegreso.LocalReport.DataSources.Clear()
                .rptegreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosEmp", dsFacturacion.Tables("datosEmpresa")))
                .rptegreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosPieEg", dsDTGFicha.Tables("datosFichaEgreso")))
                .rptegreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosOrden", dsDTGFicha.Tables("fichaIngreso")))
                .rptegreso.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("datosEgreso", dsDTGFicha.Tables("fichaEgreso")))
                .rptegreso.DocumentMapCollapsed = True
                .rptegreso.RefreshReport()
                .Show()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub panelequipo_Paint(sender As Object, e As PaintEventArgs) Handles panelequipo.Paint

    End Sub

    Private Sub lblcliente_Click(sender As Object, e As EventArgs) Handles lblcliente.Click

    End Sub

    Private Sub lblcliente_DoubleClick(sender As Object, e As EventArgs) Handles lblcliente.DoubleClick
        Try
            Dim nvoClie As String = InputBox("Ingrese numero de cliente para delegacion de orden", "Delegación de orden de reparacion")
            If Val(nvoClie) <> 0 Then
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "update tecni_taller set cliente=" & nvoClie & " where id=" & ORden
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                cargarOrden()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtproductos_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtproductos.UserDeletingRow
        Try
            Reconectar()
            If Val(e.Row.Cells(0).Value) > 0 Then
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "delete from tecni_taller_insumos where id=" & e.Row.Cells(0).Value
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                CalcularTotales()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtproductos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellValueChanged
        ModProd = True
    End Sub

    Private Sub cmbbaja_Click(sender As Object, e As EventArgs) Handles cmbbaja.Click
        If MsgBox("Esta seguro que desea dar de baja este trabajo y al equipo?", vbYesNo + vbQuestion) = vbYes Then
            cmdguardar.Enabled = False
            cmdfinalizar.Enabled = False
            cmdimprimir.Enabled = False
            Try
                GuardarOrden(18)
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                'tiene que haber un tecnico
                If cmbtecnico.SelectedIndex = -1 Or cmbtecnico.SelectedValue = 0 Then
                    MsgBox("Debe seleccionar el tecnico que realizo el trabajo")
                    Exit Sub
                End If

                Reconectar()
                sql.Connection = conexionPrinc
                sql.CommandText = "update tecni_taller set estado=18, trab_estado=3,fecha_eg='" & Format(Now, "yyyy-MM-dd") & "', equipo=0 where id=" & ORden
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                MsgBox("Orden de reparacion terminada")
                cmdimprimir.Enabled = True
                cmdfinalizar.Enabled = False
                tecnico.refrescarTaller = False
                tecnico.refrescarTrabajos = False
                MsgBox("el equipo fue dado de baja exitosamente")
                Me.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub dtproductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtproductos.CellContentClick

    End Sub

    Private Sub cmbestadotrab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbestadotrab.SelectedIndexChanged
        Try

            If cmbestadotrab.SelectedValue = 8 Then
                chkfacturado.Enabled = True
            Else
                chkfacturado.Enabled = False
                chkfacturado.Checked = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtproductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtproductos.KeyPress
        
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        txtnumeroSerie.Text = InputBox("Ingrese numero de serie", "cambio de numero de serie", txtnumeroSerie.Text).ToUpper

    End Sub

    Private Sub dtproductos_CellErrorTextNeeded(sender As Object, e As DataGridViewCellErrorTextNeededEventArgs) Handles dtproductos.CellErrorTextNeeded

    End Sub

    Private Sub txtobservaciones_TextChanged(sender As Object, e As EventArgs) Handles txtobservaciones.TextChanged

    End Sub

    Private Sub paneldatosadicionales_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub txtnumeroSerie_TextChanged(sender As Object, e As EventArgs) Handles txtnumeroSerie.TextChanged
        If ORden = 0 Then
            Try
                If txtnumeroSerie.Text = "" Then
                    Exit Sub
                End If
                lblcodexistente.Text = ""
                Dim sqlQuery As String = "select id from tecni_equipos_clientes where serie like '" & txtnumeroSerie.Text & "'"
                Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlQuery, conexionPrinc)
                Dim tablaequ As New DataTable
                Dim infoequ() As DataRow
                consulta.Fill(tablaequ)
                infoequ = tablaequ.Select("")
                If infoequ.Count <> 0 Then
                    Timer1.Enabled = True
                    lblcodexistente.Text = "COD. EXISTENTE:" & infoequ(0)(0)
                Else
                    Timer1.Enabled = False
                    lblcodexistente.Text = ""
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtrazon_TextChanged(sender As Object, e As EventArgs) Handles txtrazon.TextChanged

    End Sub

    Private Sub txtrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles txtrazon.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtrazon.Text.Trim = "" Then
                MsgBox("Debe ingresar un parametro de busqueda")
                Exit Sub

            End If
            selclie.busqueda = txtrazon.Text
            selclie.llama = "fichaequipo"
            selclie.dtpersonal.Focus()
            selclie.Show()
            selclie.TopMost = True
        End If
    End Sub

    Private Sub fichaequipo_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.F12
                FECHAGRAL = InputBox("Ingrese la fecha que desea en el formato ej:<25-03-2021>", "Cambio de fecha")
                FECHAGRAL = Format(FECHAGRAL, "dd-MMMM-yyyy")
                lblfecha.Text = FECHAGRAL
        End Select
    End Sub

    Private Sub cmdcargarInfoTrab_Click(sender As Object, e As EventArgs) Handles cmdcargarInfoTrab.Click
        Try
            Dim sqlQuery As String = "select texto1 from tecni_datosgenerales where nombre ='DATOSRELLENAR'"
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlQuery, conexionPrinc)
            Dim tabla As New DataTable

            consulta.Fill(tabla)

            If tabla.Rows.Count <> 0 Then
                txtresolucion.Text = tabla.Rows(0).Item("texto1").ToString.Replace("<br/>", vbCrLf)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdCargarInfoEspecificaciones_Click(sender As Object, e As EventArgs) Handles cmdCargarInfoEspecificaciones.Click
        Try
            Dim sqlQuery As String = "select texto2 from tecni_datosgenerales where nombre ='DATOSRELLENAR' "
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter(sqlQuery, conexionPrinc)
            Dim tabla As New DataTable

            consulta.Fill(tabla)

            If tabla.Rows.Count <> 0 Then
                txtespecificaciones.Text = tabla.Rows(0).Item("texto2").ToString.Replace("<br/>", vbCrLf)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtresolucion_TextChanged(sender As Object, e As EventArgs) Handles txtresolucion.TextChanged

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class