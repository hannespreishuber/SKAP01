Imports System.ComponentModel.DataAnnotations
Imports Newtonsoft.Json

' Modelle, die als Parameter für AccountController-Aktionen verwendet werden.

Public Class AddExternalLoginBindingModel
    <Required>
    <Display(Name := "Externes Zugriffstoken")>
    Public Property ExternalAccessToken As String
End Class

Public Class ChangePasswordBindingModel
    <Required>
    <DataType(DataType.Password)>
    <Display(Name := "Aktuelles Kennwort")>
    Public Property OldPassword As String

    <Required>
    <StringLength(100, ErrorMessage := """{0}"" muss mindestens {2} Zeichen lang sein.", MinimumLength := 6)>
    <DataType(DataType.Password)>
    <Display(Name := "Neues Kennwort")>
    Public Property NewPassword As String

    <DataType(DataType.Password)>
    <Display(Name := "Neues Kennwort bestätigen")>
    <Compare("NewPassword", ErrorMessage := "Das neue Kennwort stimmt nicht mit dem Bestätigungskennwort überein.")>
    Public Property ConfirmPassword As String
End Class

Public Class RegisterBindingModel
    <Required>
    <Display(Name := "E-Mail")>
    Public Property Email As String

    <Required>
    <StringLength(100, ErrorMessage := """{0}"" muss mindestens {2} Zeichen lang sein.", MinimumLength := 6)>
    <DataType(DataType.Password)>
    <Display(Name := "Kennwort")>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name := "Kennwort bestätigen")>
    <Compare("Password", ErrorMessage := "Das Kennwort stimmt nicht dem Bestätigungskennwort überein.")>
    Public Property ConfirmPassword As String
End Class

Public Class RegisterExternalBindingModel
    <Required>
    <Display(Name := "E-Mail")>
    Public Property Email As String
End Class

Public Class RemoveLoginBindingModel
    <Required>
    <Display(Name := "Anmeldeanbieter")>
    Public Property LoginProvider As String

    <Required>
    <Display(Name := "Anbieterschlüssel")>
    Public Property ProviderKey As String
End Class

Public Class SetPasswordBindingModel
    <Required>
    <StringLength(100, ErrorMessage := """{0}"" muss mindestens {2} Zeichen lang sein.", MinimumLength := 6)>
    <DataType(DataType.Password)>
    <Display(Name := "Neues Kennwort")>
    Public Property NewPassword As String

    <DataType(DataType.Password)>
    <Display(Name := "Neues Kennwort bestätigen")>
    <Compare("NewPassword", ErrorMessage := "Das neue Kennwort stimmt nicht mit dem Bestätigungskennwort überein.")>
    Public Property ConfirmPassword As String
End Class
