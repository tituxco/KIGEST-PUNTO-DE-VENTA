Module comprobar_tablas
    'compruebo que exista la base de datos indicada al inicio del sistema
    Public Function comprobar_base_de_datos_principal() As Boolean
        Try
            conexionPrinc.ChangeDatabase(database)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function comprobar_tablas_princ() As Boolean
        comando = New MySql.Data.MySqlClient.MySqlCommand
        Dim encontrado As Integer
        Try
            Reconectar()
            comando.Connection = conexionPrinc
            comando.CommandText = "show tables;"
            leer = comando.ExecuteReader
            While leer.Read
                Select Case leer(0)
                    Case "fact_facturas"
                        encontrado = encontrado + 1
                    Case "fact_clientes"
                        encontrado = encontrado + 1
                    Case "fact_vendedor"
                        encontrado = encontrado + 1
                End Select
            End While
            leer.Close()
            'MsgBox(encontrado)
            If encontrado = 3 Then
                'MsgBox("Las tablas basicas estan correctas")

                Return True
            Else
                'MsgBox("se han encontrado solamente " & encontrado & " tablas")

                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try
    End Function


End Module
