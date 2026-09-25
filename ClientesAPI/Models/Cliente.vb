Imports System.ComponentModel.DataAnnotations

Namespace Models
    Public Class Cliente
        Public Property Id As Integer

        <Required>
        <StringLength(100)>
        Public Property Nombre As String = String.Empty

        <Required>
        <StringLength(100)>
        Public Property Apellido As String = String.Empty

        <Required>
        <StringLength(150)>
        <EmailAddress>
        Public Property Email As String = String.Empty

        <StringLength(30)>
        Public Property Telefono As String = String.Empty
    End Class
End Namespace
