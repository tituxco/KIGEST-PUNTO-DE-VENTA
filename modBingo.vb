Imports System
Imports System.Collections.Generic
Imports System.Linq

Module modBingo
    Dim ListaCuadros As New List(Of Cuadro)()
    Dim Filas As Integer()

    Sub Main()
        ' cada fila es codificada con un número de 9 bits
        ' cada bit representa una columna
        ' el bit 0 representa a la primera columna de la izquierda (primera "decena")
        Filas = New Integer(CInt(Math.Truncate(Math.Pow(2, 9))) - 1) {}

        Dim k As Integer = 0
        While k < Filas.Length


            Filas(k) = System.Math.Max(System.Threading.Interlocked.Increment(k), k - 1)
        End While

        ' selecciona las filas que pasan la comprobación
        Filas = Filas.Where(AddressOf CompruebaFila).ToArray()

        ' cada cuadro debe tener tres filas
        For i As Integer = 0 To Filas.Length - 3
            Dim fila1 As Integer = Filas(i)
            For j As Integer = i + 1 To Filas.Length - 2
                Dim fila2 As Integer = Filas(j)
                Dim mascara As Integer = fila1 And fila2

                For k1 As Integer = j + 1 To Filas.Length - 1
                    Dim fila3 As Integer = Filas(k1)

                    ' 6 columnas con dos números
                    ' 3 columnas con un número
                    If (fila3 And mascara) <> 0 Then
                        Continue For
                    End If
                    If Not SeisColumnas(mascara Or (fila1 And fila3) Or (fila2 And fila3)) Then
                        Continue For
                    End If

                    ListaCuadros.Add(New Cuadro(fila1, fila2, fila3))
                Next
            Next
        Next

        ' el cartón con sus seis cuadros
        Dim carton As New carton()
        Dim rnd As New Random()
        Dim nuevo As Cuadro

        For k1 As Integer = 0 To 5
            Do
                nuevo = ListaCuadros(rnd.[Next](ListaCuadros.Count))
            Loop While Not carton.Agrega(nuevo)
            ListaCuadros.Remove(nuevo)
        Next

        ' imprime
        carton.Imprime()

        ' 
        Console.ReadKey()
    End Sub
    ' la fila debe contener 5 bits encendidos (1)
    ' una fila no puede contener 3 bits consecutivos apagados (0)
    Private Function CompruebaFila(num As Integer) As Boolean
        Dim bits As Integer = 0
        Dim seguidos As Integer = 0

        For k As Integer = 0 To 8
            If (num And 1) = 1 Then
                bits += 1
                seguidos = 0
            Else
                If seguidos = 2 Then
                    Return False
                End If
                seguidos += 1
            End If
            num >>= 1
        Next

        Return bits = 5
    End Function
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
End Module
