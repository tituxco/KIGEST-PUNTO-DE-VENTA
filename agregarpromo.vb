Public Class agregarpromo
    Public Shared categoria As Integer
    Public Shared idproducto As Integer
    Public Shared codigo As String

    Private Sub agregarpromo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtcodigo.Text = codigo
        cargarCategoriasProd()
        cargarinfoprod()
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
            cmbcatprod.DataSource = readcat.Tables(0)
            cmbcatprod.DisplayMember = readcat.Tables(0).Columns(1).Caption.ToString.ToUpper
            cmbcatprod.ValueMember = readcat.Tables(0).Columns(0).Caption.ToString
            cmbcatprod.SelectedValue = categoria
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarinfoprod()
        Try
            Reconectar()

            'cargamos categorias
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, codigo, descripcion,categoria from fact_insumos " &
            "where id=" & idproducto & " Or codigo Like '" & txtcodigo.Text & "'", conexionPrinc)
            'MsgBox(consulta.SelectCommand.CommandText)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")
            idproducto = infocl(0)(0)
            txtcodigo.Text = infocl(0)(1)
            txtproducto.Text = infocl(0)(2)
            cmbcatprod.SelectedValue = infocl(0)(3)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcodigo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcodigo.KeyUp
        If e.KeyCode = Keys.Enter Then
            cargarinfoprod()
        End If
    End Sub

    Private Sub txtcodigo_TextChanged(sender As Object, e As EventArgs) Handles txtcodigo.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim productopromo As Integer = idproducto
            Dim compraminprod As String = txtcompramin.Text
            Dim descuentoprod As String = txtdescuento.Text

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_promociones (idproducto,compra_min,descuento_porc) " &
            "values (?idprod,?compra,?porc) ", conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?idprod", productopromo)
                .AddWithValue("?compra", compraminprod)
                .AddWithValue("?porc", descuentoprod)
            End With
            comandoadd.ExecuteNonQuery()
            MsgBox("promocion guardada!")
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim catpromo As Integer = cmbcatprod.SelectedValue
            Dim compramincat As String = txtcompramincat.Text
            Dim descuentocat As String = txtdescuentocat.Text

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand("insert into fact_promociones (idcategoria,compra_min,descuento_porc) " &
            "values (?idcat,?compra,?porc) ", conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?idcat", catpromo)
                .AddWithValue("?compra", compramincat)
                .AddWithValue("?porc", descuentocat)
            End With
            comandoadd.ExecuteNonQuery()
            MsgBox("promocion guardada")
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class