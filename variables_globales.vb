Module Variables_Globales
    Public moduloIVA_Act As Boolean = False
    Public moduloSUELDO_Act As Boolean = False
    Public UltimoPathIMG As String = "c:\"
    Public EmpDB As String = DatosAcceso.bd
    Public Structure Encuesta
        Public Property Pregunta As String
        Public Property Respuesta As String
    End Structure

    Public Structure DatosUsuario
        Public Property Moduloacc As String
        Public Property Cliente As String
        Public Property sistema As String
        Public Property usuario As String
        Public Property pass As String
        Public Property bd As String
        Public Property puerto As String
        Public Property calculoutili As Double
        Public Property CLOUDserv As String
        Public Property RESPserv As String
        Public Property StockPpref As Integer
        Public Property IdAlmacen As Integer
        Public Property UsuarioINT As Integer
        Public Property Vendedor As Integer
        Public Property Tecnico As Integer
        Public Property idFacRap As Integer
        Public Property IdPtoVtaDef As Integer
        Public Property ServMensual As String
        Public Property debe As Integer
        Public Property mensaje As String


    End Structure
    Public DatosAcceso As DatosUsuario

    Public Structure DatosFiscales
        Public Property puntovtaelect As Integer
        Public Property cuit As String
        Public Property certificado As String
        Public Property passcertificado As String
        Public Property licencia As String
    End Structure
    Public FacturaElectro As DatosFiscales
End Module
