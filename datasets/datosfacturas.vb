Partial Class datosfacturas
    Partial Public Class cotejoPedidosFacturasDataTable
        Private Sub cotejoPedidosFacturasDataTable_cotejoPedidosFacturasRowChanging(sender As Object, e As cotejoPedidosFacturasRowChangeEvent) Handles Me.cotejoPedidosFacturasRowChanging

        End Sub

    End Class

    Partial Public Class datosOrdenPublicidadDataTable
        Private Sub datosOrdenPublicidadDataTable_datosOrdenPublicidadRowChanging(sender As Object, e As datosOrdenPublicidadRowChangeEvent) Handles Me.datosOrdenPublicidadRowChanging

        End Sub

    End Class

    Partial Public Class factura_encaDataTable
        Private Sub factura_encaDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.codigo_qrColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

    Partial Public Class ariel_itmlistacargaDataTable
        Private Sub ariel_itmlistacargaDataTable_ariel_itmlistacargaRowChanging(sender As Object, e As ariel_itmlistacargaRowChangeEvent) Handles Me.ariel_itmlistacargaRowChanging

        End Sub

    End Class
End Class
