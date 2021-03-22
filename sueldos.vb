Imports System.Text
Imports Microsoft.Reporting.WinForms
Public Class sueldos
    Public ANTIGUEDAD As Double = 0
    Public BASICO As Double = 0
    Public REMUNERATIVO As Double = 0
    Public NOREMUNERATIVO As Double = 0
    Public ANOS As Integer = 0
    Public DEDUCCIONES As Double = 0
    Public CANTIDAD As Double = 0
    Public SUELDO As Double = 0
    Public ITEM As Integer = 0
    Public PORANT As Double = 0
    Public NMBOS As String = ""
    Dim myScript As MSScriptControl.ScriptControl
    Dim Idpersonal As Integer
    Dim CacheItems As New ArrayList


    Private Sub recibos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'frmprincipal.cmdrecibos.Enabled = True
    End Sub

    Private Sub recibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Reconectar()
            'dtitemrecibos.DataSource = ItemsRecibo
            TabPage1.Parent = Nothing
            Me.Text = "RECIBOS: " & database
            lbltitulo.Text = Me.Text
            CargarPersonal()
            'cargar periodos de pago
            Dim tablaperiodo As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_periodos_pago order by id desc", conexionPrinc)
            Dim readperiodo As New DataSet
            tablaperiodo.Fill(readperiodo)
            cmbperiodopago.DataSource = readperiodo.Tables(0)
            cmbperiodopago.DisplayMember = readperiodo.Tables(0).Columns(1).Caption.ToString
            cmbperiodopago.ValueMember = readperiodo.Tables(0).Columns(0).Caption.ToString
            cmbperiodopago.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarPersonal()
        Try
            Reconectar()
            'conexionPrinc.ChangeDatabase(database)<
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select idpersonal as CodINT, concat(apellidos,',  ', nombre) as Nombre from sdo_personal", conexionPrinc)
            Dim tablaPers As New DataTable
            'Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            consulta.Fill(tablaPers)
            dtpersonal.DataSource = tablaPers
            dtpersonal.Columns(0).Visible = False
        Catch ex As Exception
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
    End Sub

    Private Sub cmdnuevo_Click(sender As Object, e As EventArgs) Handles cmdnuevo.Click
        Try
            Reconectar()
            cmdaceptar.Enabled = True
            cmdnuevo.Enabled = False
            dtpersonal.Enabled = False
            CargarDtosGrales()
            TabPage1.Parent = TabControl1
            TabControl1.SelectedTab = TabPage1
            CargarBasico(1)
            cargarInfoPer()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub CargarBasico(ByVal opc As Integer)
        'cargamos el valor del sueldo basico
        Dim lector As System.Data.IDataReader
        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        Dim convenio As Integer
        Dim conceptos As String
        Dim categoria As Integer
        Try
            conexionPrinc.ChangeDatabase(database)
            conexionPrinc.ChangeDatabase(database)
            cmbmes.Text = ""
            cmbmes.SelectedText = MonthName(Month(Now)).ToUpper
            txtano.Text = Year(Now)
            sql.Connection = conexionPrinc
            sql.CommandText = "select convert(left((TIMESTAMPDIFF(MONTH,fecha_ingreso," & Format(dtfecha_pago.Value, "yyyy-MM-dd") & ")-1) /12,2),char(2)) as anos0, convenio, categoria from sdo_personal where idpersonal=" & Idpersonal
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            convenio = lector("convenio").ToString
            categoria = lector("categoria").ToString
            lblantiguedad.Text = ANOS & " AÑOS"
            lector.Close()

            sql.Connection = conexionPrinc
            sql.CommandText = "select * from cm_sdo_centro_costos where categoria_personal= " & categoria & " and  convenio=" & convenio
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            lblinfosueldo.Text = lector("sueldo").ToString
            conceptos = lector("conceptos").ToString

            BASICO = FormatCurrency(lector("sueldo").ToString, 2)
            PORANT = lector("antiguedad").ToString / 100

            'MsgBox(conceptos)
            If opc = 1 Then
                If MsgBox("Desea que se carguen automáticamente los items?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                    CargarItemsSueldo(conceptos)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub CargarItemsSueldo(ByRef items As String)
        Dim codigos() As String
        codigos = Split(items, ",")
        Dim i As Integer
        For i = 0 To codigos.Length - 1
            If codigos(i).Trim <> "" Then
                AgregarItem(codigos(i), True)
            End If
        Next

    End Sub

    Private Sub cmdaddconcepto_Click(sender As Object, e As EventArgs) Handles cmdaddconcepto.Click
        AgregarItem(cmbconceptos.SelectedValue, True)
    End Sub
    Private Sub AgregarItem(ByRef cod As String, ByVal reg As Boolean)
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            Dim tipo As String = ""
            Dim formula As String = ""
            Dim codigo As String = ""
            Dim concepto As String = ""
            Dim monto As String = ""
            Dim unidad As String = ""
            Dim cantidad As String = ""



            conexionPrinc.ChangeDatabase(database)
            conexionPrinc.ChangeDatabase(database)
            sql.Connection = conexionPrinc
            sql.CommandText = "SELECT cs.usar_sueldo, cs.cantidad as Cantidad,cs.codigo as Codigo, cs.concepto as Concepto, ti.nombre as Tipo, cs.monto as Monto, " _
                & "uni.nombre as Unidad, cs.formula as Formula FROM cm_sdo_conceptos_sueldo as cs, cm_sdo_tipos_conceptos_sueldo as ti,cm_sdo_unidades_calculo as uni " _
                & "where cs.tipo=ti.id and cs.unidad=uni.id and cs.codigo like '" & cod & "'"

            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()

            tipo = lector("Tipo").ToString
            codigo = lector("Codigo").ToString
            formula = lector("Formula").ToString
            concepto = lector("Concepto").ToString
            monto = lector("Monto").ToString
            unidad = lector("Unidad").ToString
            cantidad = lector("Cantidad").ToString
            Dim usar As Integer
            usar = lector("usar_sueldo").ToString
            'ejecutamos la funcion
            'variablesIncluir = "Dim BASICO As String = " & BASICO
            'Dim oRetVal As Object = CompileAndRunCode(variablesIncluir & vbCrLf & formula
            Dim myScript = New MSScriptControl.ScriptControl
            myScript.Language = "VBScript"
            With myScript
                .ExecuteStatement("BASICO=" & Str(BASICO))
                .ExecuteStatement("ANTIGUEDAD=" & Str(ANTIGUEDAD))
                .ExecuteStatement("ANOS=" & Str(ANOS))
                .ExecuteStatement("REMUNERATIVO=" & Str(REMUNERATIVO))
                .ExecuteStatement("NOREMUNERATIVO=" & Str(NOREMUNERATIVO))
                .ExecuteStatement("DEDUCCIONES=" & Str(DEDUCCIONES))
                .ExecuteStatement("SUELDO=" & Str(SUELDO))
                .ExecuteStatement("PORANT=" & Str(PORANT))
                '.ExecuteStatement("NMBOS=" & Str(NMBOS))
                '.ExecuteStatement("ANT=" & Str(Math.Round(PORANT * ANOS, 2)))
            End With

            If InStr(formula, "CANTIDAD") <> 0 Then
                cantidad = Val(InputBox("Ingrese cantidad de " & concepto))
                myScript.AddCode("CANTIDAD=" & CStr(cantidad))
            End If
            If InStr(formula, "MONTO") Then
                monto = InputBox("Ingrese monto de " & concepto)
                myScript.AddCode("MONTO=" & CStr(monto))
            End If


            Select Case tipo
                Case "REMUNERATIVO"
                    If formula <> "" Then
                        If usar = 1 Then
                            ITEM += 1
                            If ITEM = 1 Then
                                'BASICO = FormatNumber(BASICO, 2)
                                'BASICO = 0
                            End If
                            'MsgBox(cantidad & "---" & monto)
                            If cantidad = "" Then
                                cantidad = 0
                            End If
                            If monto = "" Then
                                monto = ""
                            End If
                            If cantidad <> 0 And monto <> 0 Then
                                If lblmodocont.Text <> "QUINCENAL" Then
                                    BASICO = 0
                                End If
                                BASICO += Math.Round(FormatNumber(cantidad) * FormatNumber(remplazarcoma(monto)), 2)
                                '   MsgBox("111--" & BASICO)
                            ElseIf cantidad = 0 And monto <> 0 Then
                                If lblmodocont.Text <> "QUINCENAL" Then
                                    'BASICO = 0
                                End If
                                BASICO += FormatNumber((remplazarcoma(monto)), 2)
                                '  MsgBox("222--" & BASICO)
                            ElseIf cantidad <> 0 And monto = 0 Then
                                If lblmodocont.Text <> "QUINCENAL" Then
                                    BASICO = 0
                                End If
                                BASICO = Math.Round(FormatNumber(cantidad) * FormatNumber(BASICO), 2)
                                ' MsgBox("333--" & BASICO)
                            End If
                            'MsgBox(BASICO)
                            usar = 0
                        End If

                        If concepto = "ANTIGUEDAD" Then
                            cantidad = (PORANT * ANOS) * 100
                        End If
                        'MsgBox(cantidad)


                        Dim ResultadoFunc As String = "Public Function Ejecutar()" & vbCrLf & "Ejecutar=" & formula & vbCrLf & " End Function"
                        myScript.AddCode(ResultadoFunc)
                        dtitemrecibos.Rows.Add(codigo, concepto, cantidad & unidad, FormatNumber(myScript.Eval("Ejecutar"), 2))

                        If reg = True Then
                            CacheItems.Add(codigo)
                        End If

                    End If
                    REMUNERATIVO += dtitemrecibos.Rows.Item(dtitemrecibos.RowCount - 1).Cells(3).Value
                    txtsubRemunera.Text = FormatCurrency(REMUNERATIVO, 2)
                Case "NO REMUNERATIVO"
                    If formula <> "" Then
                        Dim ResultadoFunc As String = "Public Function Ejecutar()" & vbCrLf & "Ejecutar=" & formula & vbCrLf & "End Function"
                        myScript.AddCode(ResultadoFunc)
                        dtitemrecibos.Rows.Add(codigo, concepto, cantidad & unidad, "", FormatNumber(myScript.Eval("Ejecutar"), 2))

                        If reg = True Then
                            CacheItems.Add(codigo)
                        End If
                    End If
                    NOREMUNERATIVO += dtitemrecibos.Rows.Item(dtitemrecibos.RowCount - 1).Cells(4).Value
                    txtsubnoremun.Text = FormatCurrency(NOREMUNERATIVO, 2)
                Case "DEDUCCIONES"
                    Dim ResultadoFunc As String = "Public Function Ejecutar()" & vbCrLf & "Ejecutar=" & formula & vbCrLf & "End Function"
                    ' MsgBox(ResultadoFunc)
                    myScript.AddCode(ResultadoFunc)
                    dtitemrecibos.Rows.Add(codigo, concepto, cantidad & unidad, "", "", FormatNumber(myScript.Eval("Ejecutar"), 2))


                    If reg = True Then
                        CacheItems.Add(codigo)
                    End If

                    DEDUCCIONES += dtitemrecibos.Rows.Item(dtitemrecibos.RowCount - 1).Cells(5).Value
                    txtsubdeudcc.Text = FormatCurrency(DEDUCCIONES, 2)
            End Select
            txtcodigo.Clear()
            lblhaber.Text = FormatCurrency((REMUNERATIVO + NOREMUNERATIVO) - DEDUCCIONES, 2)
            lblenletras.Text = EnLetras(FormatCurrency((REMUNERATIVO + NOREMUNERATIVO) - DEDUCCIONES, 2)).ToUpper

            'MsgBox("basico:" & BASICO & ", porant:" & PORANT  & ", antiguedad:" & ANTIGUEDAD)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargarInfoPer()
        Dim lector As System.Data.IDataReader
        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        Dim cadenabd As String
        Try
            Reconectar()

            conexionPrinc.ChangeDatabase(database)
            conexionPrinc.ChangeDatabase(database)
            sql.Connection = conexionPrinc
            cadenabd = database & ".sdo_personal as per," & database & ".cm_sdo_convenios as cen, " & database & ".cm_sdo_jornada as jor," _
                & database & ".cm_sdo_modo_contratacion as mc, " & database & ".cm_sdo_categoria_personal as cat "

            sql.CommandText = "select CASE " _
                & "WHEN (MONTH(per.fecha_ingreso) < MONTH(current_date)) THEN YEAR(current_date) - YEAR(per.fecha_ingreso) " _
                & "WHEN (MONTH(per.fecha_ingreso) = MONTH(current_date)) AND (DAY(per.fecha_ingreso) <= DAY(current_date)) THEN YEAR(current_date) - YEAR(per.fecha_ingreso) " _
                & "ELSE (YEAR(current_date) - YEAR(per.fecha_ingreso)) - 1 " _
                & "END AS anos, concat(per.apellidos,', ', per.nombre) as nombre, per.doc_num, per.fecha_ingreso, per.cuil, " _
                & "cat.nombre as categoria, mc.nombre as modocontrat, jor.nombre as jornada, cen.nombre as convenio " _
                & "from " & cadenabd _
                & "where per.categoria = cat.idcategoria_personal And per.jornada = jor.id And per.modo_contr = mc.id And per.convenio = cen.id " _
                & " and per.idpersonal=" & Idpersonal
            TextBox1.Text = sql.CommandText
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            lblcategoria.Text = lector("categoria").ToString
            lblconvenio.Text = lector("convenio").ToString
            lblcuil.Text = lector("cuil").ToString
            lbldni.Text = lector("doc_num").ToString
            lblfing.Text = Format(lector("fecha_ingreso"), "dd-MM-yyyy")
            lblmodocont.Text = lector("modocontrat").ToString
            lbljornada.Text = lector("jornada").ToString
            ANOS = FormatNumber(lector("anos").ToString, 0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpersonal_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtpersonal.CellEnter
        Idpersonal = dtpersonal.CurrentRow.Cells.Item(0).Value
        CargarDtosGrales()
        cargarInfoPer()
        CargarHistorial()
    End Sub
    Private Sub txtcodigo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcodigo.KeyUp

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        myScript = New MSScriptControl.ScriptControl
        myScript.Language = "VBScript"
        myScript.Reset()
        ANTIGUEDAD = 0
        BASICO = 0
        REMUNERATIVO = 0
        NOREMUNERATIVO = 0
        ANOS = 0
        DEDUCCIONES = 0
        CANTIDAD = 0
        SUELDO = 0
        ITEM = 0
        PORANT = 0
        CacheItems.Clear()
        'txtano.Clear()
        txtcodigo.Clear()
        txtsubdeudcc.Text = ""
        txtsubnoremun.Text = ""
        txtsubRemunera.Text = ""
        'txtano.Text = ""
        'lblantiguedad.Text = ""
        'lblcategoria.Text = ""
        'lblconvenio.Text = ""
        'lblcuil.Text = ""
        'lbldni.Text = ""
        lblestado.Text = ""
        'lblfing.Text = ""
        lblhaber.Text = ""
        'lblinfosueldo.Text = ""
        'lbljornada.Text = ""
        'lblmodocont.Text = ""
        Idpersonal = 0
        TabPage1.Parent = Nothing
        cmdnuevo.Enabled = True
        cmdaceptar.Enabled = False
        dtitemrecibos.DataSource = Nothing
        dtitemrecibos.Rows.Clear()
        dtpersonal.Enabled = True

    End Sub

    Private Sub CargarDtosGrales()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            conexionPrinc.ChangeDatabase(database)

            Dim tablaConcepto As New MySql.Data.MySqlClient.MySqlDataAdapter("select codigo, convert(concat(codigo,' - ',concepto),char(255)) from cm_sdo_conceptos_sueldo order by codigo asc", conexionPrinc)
            Dim readConcepto As New DataSet
            tablaConcepto.Fill(readConcepto)
            cmbconceptos.DataSource = readConcepto.Tables(0)
            cmbconceptos.DisplayMember = readConcepto.Tables(0).Columns(1).Caption.ToString
            cmbconceptos.ValueMember = readConcepto.Tables(0).Columns(0).Caption.ToString
            cmbconceptos.SelectedIndex = -1


        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
        If MsgBox("Todos los datos son correctos?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
            Try
                Dim fecha_pago As String
                Dim total_remun As String
                Dim total_nore As String
                Dim total_desc As String
                Dim total_neto As String
                Dim periodo_pago As String
                Dim mes As String
                Dim ano As String
                Dim antig As String
                Dim sueld As String
                Dim categ As String
                Dim convenio As String
                Dim jornada As String
                Dim modo_con As String
                Dim legajo As String
                Dim dni As String
                Dim nombre As String
                Dim fecha_ingreso As String
                Dim cuil As String
                Dim fpago As String
                Dim sqlQuery As String
                Dim letras As String

                fecha_pago = Format(dtfecha_pago.Value, "dd-MM-yyyy")
                total_remun = FormatNumber(REMUNERATIVO, 2)
                total_nore = FormatNumber(NOREMUNERATIVO, 2)
                total_desc = FormatNumber(DEDUCCIONES, 2)
                total_neto = FormatNumber((REMUNERATIVO + NOREMUNERATIVO) - DEDUCCIONES, 2)
                periodo_pago = cmbperiodopago.Text
                mes = cmbmes.Text()
                ano = txtano.Text
                antig = ANOS
                sueld = FormatNumber(BASICO, 2)
                categ = lblcategoria.Text
                convenio = lblconvenio.Text
                jornada = lbljornada.Text
                modo_con = lblmodocont.Text
                legajo = Idpersonal
                dni = lbldni.Text
                fecha_ingreso = lblfing.Text
                cuil = lblcuil.Text
                letras = lblenletras.Text
                Reconectar()
                conexionPrinc.ChangeDatabase(database)
                sqlQuery = "insert into sdo_recibos (idpersonal, periodo_pago, mes, ano, fecha_pago, total_remunerativo, total_noremunerativo, " _
                    & "total_descuentos, total_neto, antiguedad,  categoria, cuil, fecha_ingreso, convenio, dni, basico, periodoConcat,enLetras) " _
                & "values (?persona,?periodo,?mes,?ano,?fecha,?remu,?noremu,?desc,?neto,?antig,?categ, ?cuil,?fing,?convenio,?dni,?basico,?concat,?letras)"

                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters
                    .AddWithValue("?persona", Idpersonal)
                    .AddWithValue("?periodo", periodo_pago)
                    .AddWithValue("?mes", mes)
                    .AddWithValue("?ano", ano)
                    .AddWithValue("?fecha", fecha_pago)
                    .AddWithValue("?remu", total_remun)
                    .AddWithValue("?noremu", total_nore)
                    .AddWithValue("?desc", total_desc)
                    .AddWithValue("?neto", total_neto)
                    .AddWithValue("?antig", antig)
                    .AddWithValue("?categ", categ)
                    .AddWithValue("?cuil", cuil)
                    .AddWithValue("?fing", fecha_ingreso)
                    .AddWithValue("?convenio", convenio)
                    .AddWithValue("?dni", dni)
                    .AddWithValue("?basico", lblinfosueldo.Text)
                    .AddWithValue("?concat", periodo_pago & " " & mes & " " & ano)
                    .AddWithValue("?letras", letras)
                End With
                comandoadd.ExecuteNonQuery()
                GuardarItems(comandoadd.LastInsertedId)
                MsgBox("Recibo guardado correctamente")
                CargarDtosGrales()
                CargarHistorial()
                myScript = New MSScriptControl.ScriptControl
                myScript.Language = "VBScript"
                myScript.Reset()
                ANTIGUEDAD = 0
                BASICO = 0
                REMUNERATIVO = 0
                NOREMUNERATIVO = 0
                ANOS = 0
                DEDUCCIONES = 0
                CANTIDAD = 0
                SUELDO = 0
                ITEM = 0
                PORANT = 0
                'txtano.Clear()
                txtcodigo.Clear()
                txtsubdeudcc.Text = ""
                txtsubnoremun.Text = ""
                txtsubRemunera.Text = ""
                'txtano.Text = ""
                'lblantiguedad.Text = ""
                'lblcategoria.Text = ""
                'lblconvenio.Text = ""
                'lblcuil.Text = ""
                'lbldni.Text = ""
                lblestado.Text = ""
                'lblfing.Text = ""
                lblhaber.Text = ""
                'lblinfosueldo.Text = ""
                'lbljornada.Text = ""
                'lblmodocont.Text = ""
                'Idpersonal = 0
                TabPage1.Parent = Nothing
                cmdnuevo.Enabled = True
                cmdaceptar.Enabled = False
                dtitemrecibos.DataSource = Nothing
                dtitemrecibos.Rows.Clear()
                dtpersonal.Enabled = True
                CacheItems.Clear()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub GuardarItems(ByRef recibo As Integer)
        Dim i As Integer
        Dim sqlQuery As String
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            For i = 0 To dtitemrecibos.RowCount - 1
                sqlQuery = "insert into sdo_items_recibos (codigo, concepto, unidades, remunerativo, noremunerativo, deducciones, idrecibo) values " _
                & "(?cod,?conc,?uni,?remu,?noremu,?dedu,?idre)"
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                With comandoadd.Parameters
                    .AddWithValue("?cod", dtitemrecibos.Rows.Item(i).Cells(0).Value)
                    .AddWithValue("?conc", dtitemrecibos.Rows.Item(i).Cells(1).Value)
                    .AddWithValue("?uni", dtitemrecibos.Rows.Item(i).Cells(2).Value)
                    .AddWithValue("?remu", dtitemrecibos.Rows.Item(i).Cells(3).Value)
                    .AddWithValue("?noremu", dtitemrecibos.Rows.Item(i).Cells(4).Value)
                    .AddWithValue("?dedu", dtitemrecibos.Rows.Item(i).Cells(5).Value)
                    .AddWithValue("?idre", recibo)
                End With
                comandoadd.ExecuteNonQuery()
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtrecibos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtrecibos.CellEnter
        Dim lector As System.Data.IDataReader
        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        Try
            cargarReciboSel()
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            sql.Connection = conexionPrinc
            sql.CommandText = "select concat(periodo_pago, ' ', mes, ' ', ano) as periodo, total_remunerativo,total_noremunerativo, total_descuentos, total_neto, basico from sdo_recibos where id=" & dtrecibos.CurrentRow.Cells.Item(0).Value
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            lblhperiodo.Text = "PERIODO LIQUIDADO: " & lector("periodo").ToString
            lblhbasico.Text = "SUELDO " & lector("basico").ToString
            lblhremunerativo.Text = "TOTAL REMUNERATIVO: " & FormatCurrency(lector("total_remunerativo").ToString, 2)
            lblhnoremunerativo.Text = "TOTAL NO REMUNERATIVO: " & FormatCurrency(lector("total_noremunerativo").ToString, 2)
            lblhdeducciones.Text = "TOTAL DEDUCCIONES: " & FormatCurrency(lector("total_descuentos").ToString, 2)
            lblhneto.Text = "TOTAL NETO: " & FormatCurrency(lector("total_neto").ToString, 2)

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarHistorial()
        Dim lector As System.Data.IDataReader
        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        Dim i As Integer = 0
        Dim limite As String
        Dim suma As String
        Dim texto As String
        Dim meses As Double
        Try
            Reconectar()
            If lblmodocont.Text = "QUINCENAL" Then
                limite = " limit 0,12"
            ElseIf lblmodocont.Text = "MENSUAL" Then
                limite = " limit 0,6"
            End If
            'cargamos recibos emitidos

            'sql.CommandText = "select id, concat(periodo_pago, ' ', mes, ' ', ano) as periodo from sdo_recibos where idpersonal=" & Idpersonal & " order by id desc " & limite
            'sql.Connection = conexionPrinc
            'sql.CommandType = CommandType.Text
            'lector = sql.ExecuteReader
            'dtrecibos.Rows.Clear()

            'While lector.Read()
            'Dim idrec As String = lector("id").ToString
            'Dim periodorec As String = lector("periodo").ToString
            'dtrecibos.Rows.Add(idrec, periodorec)
            'End While
            'lector.Close()


            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id as NumRec, concat(periodo_pago, ' ', mes, ' ', ano) as Periodo from sdo_recibos where idpersonal=" & Idpersonal & " order by id desc " & limite, conexionPrinc)
            Dim tablarec As New DataTable
            Dim j As Integer
            'Dim filas() As DataRow
            consulta.Fill(tablarec)
            dtrecibos.DataSource = tablarec
            'filas = tablarec.Select("idpersonal=" & Idpersonal)
            'MsgBox(filas.Length)
            'For j = 0 To filas.GetUpperBound(0)
            'dtrecibos.Rows.Add(filas(i)(0), filas(i)(1))
            'Next
            dtrecibos.Columns(0).Visible = False
            Reconectar()
            'calculamos si trabajo mas de 6 meses
            sql.CommandText = "select (TIMESTAMPDIFF(MONTH,fecha_ingreso,CURDATE())) as mesesTrab from sdo_personal where idpersonal=" & Idpersonal
            sql.Connection = conexionPrinc
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            meses = lector("mesesTrab").ToString
            lector.Close()
            Reconectar()
            If meses < 6 And lblmodocont.Text = "MENSUAL" Then
                sql.CommandText = "select max(total_remunerativo) as maxSueldo from sdo_recibos where periodo_pago <> 'AGUINALDO' and idpersonal=" & Idpersonal
                sql.Connection = conexionPrinc
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                lblmaxsueldo.Text = "Mejor sueldo bruto: " & FormatCurrency(lector("maxSueldo"), 2)
                lblsac.Text = "Aguinaldo/SAC: " & FormatCurrency((lector("maxSueldo") * meses) / 12, 2)
                lector.Close()
                Reconectar()
            ElseIf meses >= 6 And lblmodocont.Text = "MENSUAL" Then
                sql.CommandText = "select max(total_remunerativo) as maxSueldo from sdo_recibos where periodo_pago <> 'AGUINALDO' and idpersonal=" & Idpersonal
                sql.Connection = conexionPrinc
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                If Not IsDBNull(("maxSueldo")) Then
                    lblmaxsueldo.Text = "Mejor Sueldo bruto: " & FormatCurrency(lector("maxSueldo"), 2)
                    lblsac.Text = "Aguinaldo/SAC: " & FormatCurrency((lector("maxSueldo") * 6) / 12, 2)
                    lector.Close()
                End If

            ElseIf meses < 6 And lblmodocont.Text = "QUINCENAL" Then
                Dim consultaQUI As New MySql.Data.MySqlClient.MySqlDataAdapter("select mes, sum(format(total_remunerativo,3)) as suma from sdo_recibos where periodo_pago <> 'AGUINALDO' and idpersonal=" & Idpersonal & " group by mes limit 0,12", conexionPrinc)
                Dim tablaQUI As New DataTable
                consultaQUI.Fill(tablaQUI)
                Dim maximo As Object = tablaQUI.Compute("MAX(suma)", "")
                If Not IsDBNull(maximo) Then
                    maximo = Replace(maximo, ",", ".")
                    lblmaxsueldo.Text = "Mejor Sueldo bruto: " & FormatCurrency(maximo, 2)
                    lblsac.Text = "Aguinaldo/SAC: " & FormatCurrency((maximo * meses) / 12, 2)
                End If
            ElseIf meses >= 6 And lblmodocont.Text = "QUINCENAL" Then
                Dim consultaQUI As New MySql.Data.MySqlClient.MySqlDataAdapter("select mes, sum(format(total_remunerativo,3)) as suma from sdo_recibos where periodo_pago <> 'AGUINALDO' and idpersonal=" & Idpersonal & " group by mes", conexionPrinc)
                Dim tablaQUI As New DataTable
                consultaQUI.Fill(tablaQUI)
                Dim maximo As Object = tablaQUI.Compute("MAX(suma)", "")
                If Not IsDBNull(maximo) Then
                    maximo = Replace(maximo, ",", ".")
                    lblmaxsueldo.Text = "Mejor Sueldo bruto: " & FormatCurrency(maximo, 2)
                    lblsac.Text = "Aguinaldo/SAC: " & FormatCurrency((maximo * 6) / 12, 2)
                End If

            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbconceptos_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbconceptos.KeyUp
        If e.KeyCode = Keys.Enter Then
            AgregarItem(cmbconceptos.SelectedValue, True)
        End If
    End Sub

    'Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    '    If conexionPrinc.Database = "" Then
    '        MsgBox("Debe seleccionar una empresa antes de poder imprimir los libros de sueldo")
    '    Else
    '        Dim imprimirlib As New ImprimirLibroSueldo
    '        imprimirlib.MdiParent = Me.MdiParent
    '        imprimirlib.Show()
    '        'imprimirlib.idEmpresa = dtempresas.CurrentRow.Cells.Item(0).Value
    '    End If
    'End Sub

    'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    '    If conexionPrinc.Database = "" Then
    '        MsgBox("Debe seleccionar una empresa antes de poder imprimir recibos")
    '    Else
    '        Dim imprimirEmp As New ImprimirRecibos
    '        imprimirEmp.MdiParent = Me.MdiParent
    '        imprimirEmp.Show()
    '        'imprimirEmp.idEmpresa = dtempresas.CurrentRow.Cells.Item(0).Value
    '    End If
    'End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If conexionPrinc.Database = "" Then
            MsgBox("Debe seleccionar una empresa antes de ver el personal")
        Else
            Dim asp As New empleados
            asp.MdiParent = Me.MdiParent
            asp.Show()
        End If
    End Sub

    Private Sub dtrecibos_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtrecibos.UserDeletingRow
        Dim sqlQuery As String
        Reconectar()
        If MsgBox("Esta seguro que desea eliminar este recibo?", vbYesNo + vbQuestion) = vbYes Then
            Try

                'conexionPrinc.ChangeDatabase(database)
                'sqlQuery = "delete from sdo_recibos where id=" & dtrecibos.CurrentRow.Cells(0).Value
                'Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                'comandoadd.BeginExecuteReader()

                conexionPrinc.ChangeDatabase(database)
                sqlQuery = "delete from sdo_recibos where id=" & dtrecibos.CurrentRow.Cells(0).Value
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                comandoadd.BeginExecuteReader()

                'Reconectar()
                conexionPrinc.ChangeDatabase(database)
                MsgBox(dtrecibos.CurrentRow.Cells(0).Value)
                sqlQuery = "delete from sdo_items_recibos where idrecibo=" & dtrecibos.CurrentRow.Cells(0).Value
                Dim comandoadd2 As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                comandoadd2.BeginExecuteReader()

                'CargarHistorial()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cargarReciboSel()
        Try
            dtrecibohis.Rows.Clear()
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand

            sql.CommandText = "select * from sdo_items_recibos where idrecibo=" & dtrecibos.CurrentRow.Cells(0).Value & " order by codigo asc"
            sql.Connection = conexionPrinc
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            While lector.Read()
                dtrecibohis.Rows.Add(lector("codigo").ToString, lector("concepto").ToString, lector("unidades").ToString, lector("remunerativo").ToString, lector("noremunerativo").ToString, lector("deducciones").ToString)
            End While

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtitemrecibos_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtitemrecibos.ColumnHeaderMouseClick


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim i As Integer
        dtitemrecibos.Rows.Clear()
        myScript = New MSScriptControl.ScriptControl
        myScript.Language = "VBScript"
        myScript.Reset()
        BASICO = 0
        CargarBasico(0)
        REMUNERATIVO = 0
        NOREMUNERATIVO = 0
        DEDUCCIONES = 0

        CacheItems.Sort()
        For i = 0 To CacheItems.Count - 1
            'MsgBox(CacheItems(i))
            AgregarItem(CacheItems(i), False)
        Next
    End Sub

    Private Sub dtitemrecibos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtitemrecibos.CellContentClick

    End Sub

    Private Sub dtitemrecibos_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtitemrecibos.UserDeletingRow
        CacheItems.Remove(dtitemrecibos.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            conexionPrinc.ChangeDatabase(database)

            Dim cadenaBD As String = database & ".sdo_personal as per," & database & ".fact_empresa as emp, " & database & ".sdo_recibos as rec"
            Dim tabRecibos As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabItems As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ds As New DatasetRecibos
            tabRecibos.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select " _
            & "rec.idpersonal, concat(per.apellidos,', ', per.nombre) as nombreapellido, rec.dni as documento, rec.cuil,  " _
            & "rec.fecha_ingreso as fechaingreso, rec.antiguedad, rec.convenio, rec.categoria, " _
            & "concat(rec.periodo_pago,' ', rec.mes,' ', rec.ano) as periodoliquidado, " _
            & "rec.fecha_pago as fechapago, rec.basico as sueldobasico, " _
            & "concat('Empleador: ',emp.razonsocial, '\n', 'Domicilio: ',emp.direccion,'\n','C.U.I.T.: ',emp.cuit) as empresadtos, " _
            & "rec.id as id, rec.total_remunerativo as totrem, rec.total_noremunerativo as totnorem, rec.total_descuentos as totdedu, " _
            & "rec.total_neto as totneto, enletras as letras, sueldobanco, sueldocuenta,aportebanco,aportefecha,aporteperiodo,lugarpago from " _
            & cadenaBD & " where rec.id=" & dtrecibos.CurrentRow.Cells(0).Value & " and rec.idpersonal=per.idpersonal and per.empresa=emp.id ", conexionPrinc)
            ' MsgBox("ok")
            tabItems.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select codigo, concepto, unidades, remunerativo, noremunerativo, deducciones, idrecibo 
            from sdo_items_recibos where idrecibo=" & dtrecibos.CurrentRow.Cells(0).Value & " order by id asc", conexionPrinc)

            tabRecibos.Fill(ds.Tables("ReciboEncabeza"))
            tabItems.Fill(ds.Tables("ReciboItems"))
            With imprimirrecibo
                .rptrecibo.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptrecibo.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\reportes\ReciboEncabezado.rdlc"
                .rptrecibo.LocalReport.DataSources.Clear()
                .rptrecibo.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("EncabezaRecibo", ds.Tables("ReciboEncabeza")))


                AddHandler .rptrecibo.LocalReport.SubreportProcessing, AddressOf Me.SubreportProcessingEventHandler

                .rptrecibo.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ItemsRecibos", ds.Tables("ReciboItems")))
                .rptrecibo.DocumentMapCollapsed = True
                .Show()
                .rptrecibo.RefreshReport()

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim ds As New DatasetRecibos
            Dim tabItems As New MySql.Data.MySqlClient.MySqlDataAdapter
            tabItems.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select codigo, concepto, unidades, remunerativo, noremunerativo, deducciones, idrecibo 
            from sdo_items_recibos where idrecibo=" & dtrecibos.CurrentRow.Cells(0).Value & " order by id asc", conexionPrinc)
            tabItems.Fill(ds.Tables("ReciboItems"))
            e.DataSources.Add(New ReportDataSource("ItemsRecibos", ds.Tables("ReciboItems")))
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
    '    rubricasuel.Show()
    'End Sub

    'Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    'End Sub

    'Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
    'End Sub

    'Private Sub dtpersonal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtpersonal.CellContentClick

    'End Sub

    'Private Sub pntitulo_Paint(sender As Object, e As PaintEventArgs) Handles pntitulo.Paint

    'End Sub

    'Private Sub Button9_Click(sender As Object, e As EventArgs)

    'End Sub

    'Private Sub Panel11_Paint(sender As Object, e As PaintEventArgs) Handles Panel11.Paint

    'End Sub

    'Private Sub TabPage2_Paint(sender As Object, e As PaintEventArgs) Handles TabPage2.Paint


    'End Sub

    'Private Sub TabPage2_DoubleClick(sender As Object, e As EventArgs) Handles TabPage2.DoubleClick

    'End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        CargarPersonal()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class