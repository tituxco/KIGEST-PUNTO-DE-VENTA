Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Data
Imports System.Data.OleDb
Public Class ImportacionPrecios
    Dim proveedorimport As Integer
    Dim categoriaimport As Integer
    Dim modificaProd As Boolean
    Dim imprimirlist As Boolean
    Dim elimColumn As Boolean
    'Dim proveedorimport As Integer
    'Dim categoriaimport As Integer
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        Dim ficheros As String

        Try
            dlAbrir.Filter = "Archivos de excel (*.xls,*.xlsx)|*.xls;*.xlsx"
            dlAbrir.Multiselect = False
            dlAbrir.Title = "Selección de archivo"
            dlAbrir.ShowDialog()
            If dlAbrir.FileName <> "" Then
                ficheros = dlAbrir.FileName
                Dim dt As DataTable = GetDataExcel(ficheros, InputBox("Ingrese nombre de la hoja de excel", "Importar lista de precios", "Hoja1"))
                dtimportados.DataSource = dt
                lblcantprod.Text = dtimportados.RowCount
                'ProgressBar1.Maximum = dtimportados.RowCount
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub cmdimportar_Click(sender As Object, e As EventArgs) Handles cmdimportar.Click
        frmprincipal.pbprincipal.Visible = True
        cmdimportar.Enabled = False
        proveedorimport = cmbproveedorimport.SelectedValue
        categoriaimport = cmbcategoriaimport.SelectedValue

        ImportarListaPrecios2.RunWorkerAsync()
    End Sub

    Private Sub ImportarListaPrecios_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ImportarListaPrecios2.DoWork
        ImportarLista()

    End Sub
    Private Sub ImportarLista()
        Try
            Dim sqlQuery As String

            Dim sqlQueryadd_INSPref As String = "insert into fact_insumos (id"
            Dim sqlQueryadd_INS As String
            Dim sqlQueryadd_INSValPref As String = ") values (?id"
            Dim sqlQueryadd_INSVal As String

            Dim sqlQueryupd_UPDPref As String = ") On duplicate key update iva=?iva"
            Dim sqlQueryupd_UPDVal As String

            Dim numeromod As Integer = 0
            Dim numeroadd As Integer = 0
            Dim calcularprecio As Integer = 1
            Dim gananciagral As String = txtgananciagral.Text
            Dim registros As Integer = dtimportados.RowCount
            Dim registroactual As Integer = 0
            Dim cod_bar As String
            Dim codigo As String = 0
            Dim descripcion As String
            Dim presentacion As String
            Dim costo As String
            Dim i As Integer

            For Each producto As DataGridViewRow In dtimportados.Rows
                i = 0
                If conexionSEC.State = ConnectionState.Closed Then
                    conexionSEC.Open()
                    conexionSEC.ChangeDatabase(database)
                End If

                Dim iva As String = txtlistaimportaiva.Text
                descripcion = producto.Cells(i).Value.ToString
                i += 1

                If chkimportproveedor.CheckState = CheckState.Checked Then
                    sqlQueryadd_INS = sqlQueryadd_INS & ",codprov"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?codprov"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",codprov=?codprov"
                End If

                If chkimportcateg.CheckState = CheckState.Checked Then
                    sqlQueryadd_INS = sqlQueryadd_INS & ",categoria"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?catprod"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",categoria=?catprod"
                End If
                If chkimportdescripcion.CheckState = CheckState.Checked Then
                    sqlQueryadd_INS = sqlQueryadd_INS & ",descripcion"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?descripcion"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",descripcion=?descripcion"
                End If
                If chkimportcodbar.CheckState = CheckState.Checked Then

                    cod_bar = producto.Cells(i).Value.ToString
                    codigo = producto.Cells(i).Value.ToString
                    i += 1
                    sqlQueryadd_INS = sqlQueryadd_INS & ",cod_bar,codigo"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?cod_bar,?cod_bar"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",cod_bar=?cod_bar,codigo=?cod_bar"
                End If
                If chkimportpresentacion.CheckState = CheckState.Checked Then
                    presentacion = producto.Cells(i).Value.ToString
                    i += 1

                    sqlQueryadd_INS = sqlQueryadd_INS & ",presentacion"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?present"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",presentacion=?present"
                End If
                If chkimportprecio.CheckState = CheckState.Checked Then

                    costo = producto.Cells(i).Value.ToString
                    i += 1

                    sqlQueryadd_INS = sqlQueryadd_INS & ",precio"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?costo"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",precio=?costo"
                End If

                If chkimportprecio.CheckState = CheckState.Checked Then
                    sqlQueryadd_INS = sqlQueryadd_INS & ",iva"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?iva"

                End If

                If chkutilidad.CheckState = CheckState.Checked Then
                    sqlQueryadd_INS = sqlQueryadd_INS & ",ganancia"
                    sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?ganan"

                    sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",ganancia=?ganan"
                End If

                sqlQueryadd_INS = sqlQueryadd_INS & ",calcular_precio"
                sqlQueryadd_INSVal = sqlQueryadd_INSVal & ",?calcpre"
                sqlQueryupd_UPDVal = sqlQueryupd_UPDVal & ",calcular_precio=?calcpre"


                sqlQuery = sqlQueryadd_INSPref & sqlQueryadd_INS & sqlQueryadd_INSValPref & sqlQueryadd_INSVal & sqlQueryupd_UPDPref & sqlQueryupd_UPDVal
                'MsgBox(sqlQuery)

                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionSEC)
                With comandoadd.Parameters
                    .AddWithValue("?id", ObtenerIDproducto(codigo))
                    .AddWithValue("?codprov", proveedorimport)
                    .AddWithValue("?catprod", categoriaimport)
                    .AddWithValue("?descripcion", descripcion)
                    .AddWithValue("?cod_bar", cod_bar)
                    .AddWithValue("?present", presentacion)
                    .AddWithValue("?costo", costo.Replace("$", ""))
                    .AddWithValue("?iva", iva)
                    .AddWithValue("?ganan", gananciagral)
                    .AddWithValue("?calcpre", calcularprecio)
                End With
                'MsgBox(sqlQuery)
                comandoadd.ExecuteNonQuery()
                registroactual += 1
                sqlQueryadd_INSPref = "insert into fact_insumos (id"
                sqlQueryadd_INS = ""
                sqlQueryadd_INSValPref = ") values (?id"
                sqlQueryadd_INSVal = ""

                sqlQueryupd_UPDPref = ") On duplicate key update iva=?iva"
                sqlQueryupd_UPDVal = ""
                conexionSEC.Close()
                ImportarListaPrecios2.ReportProgress(CInt((registroactual / dtimportados.RowCount) * 100))
            Next

        Catch ex As Exception

            conexionSEC.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ObtenerIDproducto(ByRef codigoProd As String) As String
        Try
            If conexionPrinc.State = ConnectionState.Closed Then
                conexionPrinc.Open()
            End If
            If codigoProd = "" Then
                codigoProd = "0"
            End If
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id FROM fact_insumos  where codigo Like '" & Replace(codigoProd, "'", "") & "'", conexionPrinc)
            Dim tablaprod As New DataTable
            consulta.Fill(tablaprod)
            If tablaprod.Rows.Count <> 0 Then
                Return tablaprod.Rows(0).Item(0)
            Else
                Return ""
            End If
            conexionPrinc.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conexionPrinc.Close()
            Return "''"
        End Try
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.BackColor = Color.Red Then
            Button4.BackColor = Color.FromArgb(RGB(64, 64, 64))
            elimColumn = False
            Me.Cursor = Cursors.Arrow
            'For Each columna As DataGridViewColumn In dtimportados.Columns
            '    columna.SortMode = DataGridViewColumnSortMode.NotSortable

            'Next
        Else
            Button4.BackColor = Color.Red
            Me.Cursor = Cursors.Hand
            elimColumn = True
            'For Each columna As DataGridViewColumn In dtimportados.Columns
            '    columna.SortMode = DataGridViewColumnSortMode.Automatic

            'Next
        End If
    End Sub

    Private Sub dtimportados_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtimportados.ColumnHeaderMouseClick
        If elimColumn = True Then
            'MsgBox(dtimportados.Columns.Item(e.ColumnIndex).Name)
            dtimportados.Columns.Remove(dtimportados.Columns.Item(e.ColumnIndex).Name)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles cmdimportar.Click
        frmprincipal.pbprincipal.Visible = True
        cmdimportar.Enabled = False
        proveedorimport = cmbproveedorimport.SelectedValue
        categoriaimport = cmbcategoriaimport.SelectedValue

        ImportarListaPrecios2.RunWorkerAsync()

    End Sub

    Private Sub cargarCategoriasProd()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos categorias
            Dim tablacatprod As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from fact_categoria_insum order by nombre asc", conexionPrinc)
            Dim readcat As New DataSet
            Dim readcat2 As New DataSet
            tablacatprod.Fill(readcat)
            tablacatprod.Fill(readcat2)

            cmbcategoriaimport.DataSource = readcat2.Tables(0)
            cmbcategoriaimport.DisplayMember = readcat2.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcategoriaimport.ValueMember = readcat2.Tables(0).Columns(0).Caption.ToString
            cmbcategoriaimport.SelectedIndex = -1


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarProveedores()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos categorias
            Dim tablacatprod As New MySql.Data.MySqlClient.MySqlDataAdapter("select id,razon from fact_proveedores order by razon asc", conexionPrinc)
            Dim readcat As New DataSet
            Dim readcat2 As New DataSet
            tablacatprod.Fill(readcat)
            tablacatprod.Fill(readcat2)

            cmbproveedorimport.DataSource = readcat.Tables(0)
            cmbproveedorimport.DisplayMember = readcat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbproveedorimport.ValueMember = readcat.Tables(0).Columns(0).Caption.ToString
            cmbproveedorimport.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportacionPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarCategoriasProd()
        cargarProveedores()

    End Sub

    Private Sub ImportarListaPrecios_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles ImportarListaPrecios2.ProgressChanged
        frmprincipal.pbprincipal.Value = e.ProgressPercentage
        lblcantprod.Text = e.ProgressPercentage & "%"
    End Sub
    Private Sub ImportarListaPrecios_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles ImportarListaPrecios2.RunWorkerCompleted
        frmprincipal.pbprincipal.Visible = False
        cmdimportar.Enabled = True
        MsgBox("Proceso completado!")
    End Sub
End Class