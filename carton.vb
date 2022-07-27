Class carton
    Friend Shared rnd As Random
    Private cuadros As List(Of cuadro)
    Private números As Integer()
    Private suma As Integer()
    Private decena As Integer()

    Public Sub New()
        rnd = New Random()
        Dim desordena As New Desordena()

        números = New Integer(89) {}

        For k As Integer = 0 To números.Length - 1
            números(k) = k + 1
        Next

        Array.Sort(números, 0, 9, desordena)
        Array.Sort(números, 9, 10, desordena)
        Array.Sort(números, 19, 10, desordena)
        Array.Sort(números, 29, 10, desordena)
        Array.Sort(números, 39, 10, desordena)
        Array.Sort(números, 49, 10, desordena)
        Array.Sort(números, 59, 10, desordena)
        Array.Sort(números, 69, 10, desordena)
        Array.Sort(números, 79, 11, desordena)

        cuadros = New List(Of cuadro)()
        suma = New Integer(8) {}
        decena = New Integer(8) {}
    End Sub

    Public Function Agrega(c As cuadro) As Boolean
        Select Case cuadros.Count
            Case 0
                cuadros.Add(c)
                Return True

            Case 1
                decena(8) = cuadros(0).TotalColumna(8) + c.TotalColumna(8)
                If decena(8) < 3 Then
                    Exit Select
                End If
                cuadros.Add(c)
                Return True

            Case 2
                suma(8) = decena(8) + c.TotalColumna(8)
                If suma(8) < 5 Then
                    Exit Select
                End If

                For k As Integer = 7 To 1 Step -1
                    decena(k) = cuadros(0).TotalColumna(k) + cuadros(1).TotalColumna(k) + c.TotalColumna(k)
                    If decena(k) < 4 Then
                        Return False
                    End If
                Next

                ' ok
                decena(8) = suma(8)
                cuadros.Add(c)
                Return True

            Case 3
                suma(8) = decena(8) + c.TotalColumna(8)
                If suma(8) < 7 Then
                    Exit Select
                End If

                For k As Integer = 7 To 1 Step -1
                    suma(k) = decena(k) + c.TotalColumna(k)
                    If suma(k) < 6 Then
                        Return False
                    End If
                Next

                decena(0) = cuadros(0).TotalColumna(0) + cuadros(1).TotalColumna(0) + cuadros(2).TotalColumna(0) + c.TotalColumna(0)
                If (decena(0) < 5) OrElse (decena(0) > 7) Then
                    Exit Select
                End If

                ' ok
                For k As Integer = 1 To 8
                    decena(k) = suma(k)
                Next
                cuadros.Add(c)
                Return True

            Case 4
                suma(8) = decena(8) + c.TotalColumna(8)
                If suma(8) < 9 Then
                    Exit Select
                End If

                For k As Integer = 7 To 1 Step -1
                    suma(k) = decena(k) + c.TotalColumna(k)
                    If (suma(k) < 8) OrElse (suma(k) > 9) Then
                        Return False
                    End If
                Next

                suma(0) = decena(0) + c.TotalColumna(0)
                If (suma(0) < 7) OrElse (suma(0) > 8) Then
                    Exit Select
                End If

                ' ok
                For k As Integer = 0 To 8
                    decena(k) = suma(k)
                Next
                cuadros.Add(c)
                Return True

            Case 5
                suma(8) = decena(8) + c.TotalColumna(8)
                If suma(8) <> 11 Then
                    Exit Select
                End If

                For k As Integer = 7 To 1 Step -1
                    suma(k) = decena(k) + c.TotalColumna(k)
                    If suma(k) <> 10 Then
                        Return False
                    End If
                Next

                suma(0) = decena(0) + c.TotalColumna(0)
                If suma(0) <> 9 Then
                    Exit Select
                End If

                ' ok
                For k As Integer = 0 To 8
                    decena(k) = suma(k)
                Next
                cuadros.Add(c)
                Return True
        End Select

        Return False
    End Function
    Public Sub Imprime()
        Dim pos As Integer = 0
        Dim posX As Integer = 18
        Dim posY As Integer = 3

        Dim k As Integer = 0
        While k < 9
            Dim mascara As Integer = CInt(Math.Truncate(Math.Pow(2, k)))

            For c As Integer = 0 To 5
                Console.BackgroundColor = If((c And 1) = 0, ConsoleColor.Blue, ConsoleColor.Green)
                Console.ForegroundColor = If((c And 1) = 0, ConsoleColor.Yellow, ConsoleColor.Black)
                Console.SetCursorPosition(posX + k * 5, posY)
                posY += 1

                If (cuadros(c).Fila1 And mascara) = mascara Then
                    Console.Write("{0,3} ", números(pos))
                    pos += 1
                Else
                    Console.Write(" -- ")
                End If

                Console.SetCursorPosition(posX + k * 5, posY)
                posY += 1
                If (cuadros(c).Fila2 And mascara) = mascara Then
                    Console.Write("{0,3} ", números(pos))
                    pos += 1
                Else
                    Console.Write(" -- ")
                End If

                Console.SetCursorPosition(posX + k * 5, posY)
                posY += 1
                If (cuadros(c).Fila3 And mascara) = mascara Then
                    Console.Write("{0,3} ", números(pos))
                    pos += 1
                Else
                    Console.Write(" -- ")
                End If
            Next
            k += 1
            posY = 3
        End While
    End Sub

    Friend Class Desordena
        Implements IComparer(Of Integer)

        Public Function Compare(x As Integer, y As Integer) As Integer Implements System.Collections.Generic.IComparer(Of Integer).Compare
            Return rnd.[Next](-10, 10)
        End Function
    End Class
End Class
