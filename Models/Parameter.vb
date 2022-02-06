
Public Class Parameter


    Sub New(pName As String, pValue As Object, Optional pDbType As SqlDbType = SqlDbType.VarChar)
        Name = pName
        Value = pValue
        DbType = pDbType
    End Sub


    Public Property Name As String
    Public Property Value As Object
    Public Property DbType As SqlDbType

End Class
