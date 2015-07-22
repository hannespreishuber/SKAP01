Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("training")>
Partial Public Class training
    Public Property Id As Integer

    <StringLength(50)>
    Public Property name As String

    Public Property datum As Date?
End Class
