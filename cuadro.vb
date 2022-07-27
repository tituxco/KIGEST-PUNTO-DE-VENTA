Class cuadro
    Public Fila1 As Integer
    Public Fila2 As Integer
    Public Fila3 As Integer

    Public Sub New(f1 As Integer, f2 As Integer, f3 As Integer)
        Fila1 = f1
        Fila2 = f2
        Fila3 = f3
    End Sub

    ' 6 columnas con 2 números
    Private Function SeisColumnas(num As Integer) As Boolean
        Dim bits As Integer = 0

        For k As Integer = 0 To 8
            If (num And 1) = 1 Then
                bits += 1
            End If
            num >>= 1
        Next

        Return bits = 6
    End Function

    ' Celdas ocupadas en la columna
    Public Function TotalColumna(columna As Integer) As Integer
        Dim mascara As Integer = CInt(Math.Truncate(Math.Pow(2, columna)))

        Dim res As Integer = 0

        If (Fila1 And mascara) = mascara Then
            res += 1
        End If
        If (Fila2 And mascara) = mascara Then
            res += 1
        End If
        If (Fila3 And mascara) = mascara Then
            res += 1
        End If

        Return res
    End Function

End Class
