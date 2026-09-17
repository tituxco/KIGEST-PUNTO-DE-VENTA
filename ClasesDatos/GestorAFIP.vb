' 2. MÉTODO PRINCIPAL (Devuelve True o False)
Imports System.Runtime.CompilerServices
Imports WSAFIPFE.anmat

Public Class GestorAFIP

    ' --- PROPIEDADES DE RESPUESTA ---
    Public Property Autorizada As Boolean = False
    Public Property CAE As String = ""
    Public Property VtoCAE As String = ""
    Public Property CodigoBarras As String = ""
    Public Property MensajeError As String = ""
    Public Property Observaciones As String = ""
    Public Property CodigoQR As Byte() = Nothing

    ' --- MÉTODO PRINCIPAL ---
    Public Function SolicitarCAE(factura As GestorFacturacion.factNuevaFactura_Datos) As Boolean
        ' Reseteamos el estado de la clase
        Me.Autorizada = False
        Me.MensajeError = ""
        Me.Observaciones = ""

        Try
            Dim fe As New WSAFIPFE.Factura()
            Dim lresultado As Boolean

            Dim cbtetipo As Integer
            Dim doctipo As Integer
            Dim contribtipo As Integer
            Dim idiva As Integer
            Dim condIvaReceptor As Integer

            ' 1. MAPEO DE TIPO DE COMPROBANTE
            Select Case factura.tipofact.id
                Case 1 : cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaA
                Case 2 : cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoA
                Case 3 : cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoA
                Case 6 : cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaB
                Case 7 : cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoB
                Case 8 : cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoB
                Case 11 : cbtetipo = WSAFIPFE.Factura.TipoComprobante.FacturaC
                Case 12 : cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaDebitoC
                Case 13 : cbtetipo = WSAFIPFE.Factura.TipoComprobante.NotaCreditoC
                Case Else
                    Me.MensajeError = "Tipo de comprobante no admitido por AFIP."
                    Return False
            End Select

            ' 2. MAPEO DE CONTRIBUYENTE Y DOCUMENTO
            ' (Asumimos que tu clase cliente tiene estas propiedades. Ajustá los IDs según tu base de datos)
            Select Case factura.cliente.ivaTipo.id
                Case 1 ' Inscripto
                    contribtipo = WSAFIPFE.Factura.TipoReponsable.ResponsableInscripto
                    doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                    'condIvaReceptor = 1    'para nueva adecuacion ARCA
                Case 5 ' Exento
                    contribtipo = WSAFIPFE.Factura.TipoReponsable.Exento
                    doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                    'condIvaReceptor = 4    'para nueva adecuacion ARCA
                Case 4 ' Consumidor Final
                    contribtipo = WSAFIPFE.Factura.TipoReponsable.ConsumidorFinal
                    'condIvaReceptor =5    'para nueva adecuacion ARCA
                    If factura.cliente.cuit = "" OrElse factura.cliente.cuit = "0" Then
                        doctipo = WSAFIPFE.Factura.TipoDocumento.SinIdentificacionGlobalDiario
                    Else
                        doctipo = WSAFIPFE.Factura.TipoDocumento.DNI
                    End If
                Case 6 ' Monotributo
                    contribtipo = WSAFIPFE.Factura.TipoReponsable.Monotributo
                    doctipo = WSAFIPFE.Factura.TipoDocumento.CUIT
                    'condIvaReceptor =6    'para nueva adecuacion ARCA
                Case Else
                    Me.MensajeError = "Tipo de contribuyente no admitido."
                    Return False
            End Select

            ' 3. INICIALIZACIÓN AFIP
            lresultado = fe.iniciar(WSAFIPFE.Factura.modoFiscal.Fiscal, EmpresaActual.cuit, EmpresaActual.direccionCertificado, EmpresaActual.direccionLicencia)
            fe.ArchivoCertificadoPassword = EmpresaActual.passCertificado

            If Not lresultado OrElse Not fe.f1ObtenerTicketAcceso() Then
                Me.MensajeError = "Error al obtener ticket AFIP: " & fe.UltimoNumeroError & " - " & fe.UltimoMensajeError
                Return False
            End If

            ' 4. CABECERA
            fe.F1CabeceraCbteTipo = cbtetipo
            fe.F1CabeceraPtoVta = factura.ptovta.id
            fe.F1CabeceraCantReg = 1
            fe.F1DetalleMonId = "PES"
            fe.F1DetalleMonCotiz = 1
            fe.F1DetalleConcepto = 1
            fe.F1DetalleDocTipo = doctipo
            fe.F1DetalleDocNro = factura.cliente.cuit.Replace("-", "")
            fe.F1DetalleCbteDesdeS = factura.num_fact
            fe.F1DetalleCbteHastaS = factura.num_fact
            fe.F1DetalleCbteFch = factura.fecha.ToString("yyyyMMdd")

            ' 5. TOTALES GENERALES
            fe.F1DetalleImpTotal = factura.total
            fe.F1DetalleImpNeto = factura.subtotal
            fe.F1DetalleImpIva = (factura.iva21 + factura.iva105 + factura.otroiva)
            fe.F1DetalleImpTrib = 0 ' Ajustar si tenés tributos en el DTO
            fe.F1DetalleImpTotalConc = 0

            ' 6. CARGA DINÁMICA DE ALÍCUOTAS DE IVA
            ' Calculamos las bases imponibles matemáticamente a partir del monto de IVA del objeto
            If factura.tipofact.id <> 11 AndAlso factura.tipofact.id <> 12 AndAlso factura.tipofact.id <> 13 Then
                Dim cantAlicuotas As Integer = 0 'cant alicuotas

                If factura.iva21 > 0 Then
                    fe.f1IndiceItem = cantAlicuotas
                    fe.F1DetalleIvaId = 5 'alicuota al 21%
                    fe.F1DetalleIvaBaseImp = factura.subtotal21
                    fe.F1DetalleIvaImporte = factura.iva21
                    cantAlicuotas += 1
                End If

                If factura.iva105 > 0 Then
                    fe.f1IndiceItem = cantAlicuotas
                    fe.F1DetalleIvaId = 4 'alicuta al 10,5%
                    fe.F1DetalleIvaBaseImp = factura.subtotal105
                    fe.F1DetalleIvaImporte = factura.iva105
                    cantAlicuotas += 1
                End If

                ' Si hay subtotal exento o no gravado (IVA 0)
                Dim totalGravado As Decimal = Math.Round((factura.subtotal21) + (factura.subtotal105), 2)
                Dim subtotalCero As Decimal = factura.subtotal - totalGravado
                If subtotalCero > 0 Then
                    fe.f1IndiceItem = cantAlicuotas
                    fe.F1DetalleIvaId = 3 ' alicuota al 0%
                    fe.F1DetalleIvaBaseImp = subtotalCero
                    fe.F1DetalleIvaImporte = 0
                    cantAlicuotas += 1
                End If

                fe.F1DetalleIvaItemCantidad = cantAlicuotas
            End If

            'Dim otrosTributos As Decimal = factura.t. + factura.TotalICL

            'If otrosTributos > 0 Then
            '    ' Le decimos al componente la cantidad de ítems de tributos (en tu caso siempre 2)
            '    fe.F1DetalleTributoItemCantidad = 2

            '    ' Índice 0: IDC
            '    fe.f1IndiceItem = 0
            '    fe.F1DetalleTributoId = 1
            '    fe.F1DetalleTributoDesc = "I.D.C. - IMPUESTO A COMBUSTIBLES"
            '    fe.F1DetalleTributoImporte = factura.TotalIDC

            '    ' Índice 1: ICL
            '    fe.f1IndiceItem = 1
            '    fe.F1DetalleTributoId = 1
            '    fe.F1DetalleTributoDesc = "I.C.L. - IMPUESTO A COMBUSTIBLES"
            '    fe.F1DetalleTributoImporte = factura.TotalICL
            'End If


            ' ==========================================================
            ' 2. CONFIGURACIÓN Y GENERACIÓN DEL CÓDIGO QR
            ' ==========================================================
            Dim rutaQR As String = System.IO.Path.Combine(Application.StartupPath, factura.tipofact.id & "-" & factura.ptovta.id & "-" & factura.num_fact & ".png")

            fe.F1DetalleQRArchivo = rutaQR
            fe.f1detalleqrtolerancia = 1
            fe.f1detalleqrresolucion = 4
            fe.f1detalleqrformato = 8

            ' Generamos el archivo físico
            If fe.f1qrGenerar(99) = False Then
                Me.MensajeError = "Error al generar el código QR: " & fe.ArchivoQRError & " " & fe.UltimoMensajeError
                Return False
            End If

            ' 7. SOLICITUD DEL CAE
            If fe.F1CAESolicitar() Then
                    If fe.F1RespuestaResultado = "A" Then
                        ' APROBADA
                        Me.Autorizada = True
                        Me.CAE = fe.F1RespuestaDetalleCae
                        Me.VtoCAE = fe.F1RespuestaDetalleCAEFchVto
                    Me.CodigoBarras = fe.f1CodigoDeBarraAFIP
                    Me.CodigoQR = System.IO.File.ReadAllBytes(rutaQR)
                    Return True
                    Else
                        ' RECHAZADA
                        Me.MensajeError = "Rechazada por AFIP: " & fe.UltimoMensajeError & " - " & fe.UltimoNumeroError
                        Me.Observaciones = fe.F1RespuestaDetalleObservacionMsg1 & " " & fe.F1RespuestaDetalleObservacionMsg
                        Return False
                    End If
                Else
                    ' ERROR DE COMUNICACIÓN
                    Me.MensajeError = "Error de comunicación: " & fe.UltimoMensajeError
                    Return False
                End If

            Catch ex As Exception
                Me.MensajeError = "Excepción interna: " & ex.Message
                Return False
            End Try
        End Function

End Class