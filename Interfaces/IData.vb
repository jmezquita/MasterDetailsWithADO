Imports System.Data.SqlClient

Public Interface IData

    Function GetDataTable(ByVal tableName As String, Optional sqlString As String = Nothing) As DataTable
    Function GetDataSet(ByVal tableName As String, Optional sqlString As String = Nothing) As DataSet

    Function GetDataAdapter(ByVal tableName As String, Optional sqlString As String = Nothing) As SqlDataAdapter

    Function GetAllData(Optional where As String = Nothing) As DataSet

    Function Insert(TableName As String, parameters As List(Of Parameter)) As Integer

    Function Insert(sqlString) As Integer

    Function Update(TableName As String, parameterfilter As List(Of Parameter), parameters As List(Of Parameter)) As Boolean
    Function Update(sqlString) As Boolean

    Function Delete(TableName As String, parameterfilter As List(Of Parameter)) As Boolean

    Function Delete(sqlString) As Boolean

End Interface
