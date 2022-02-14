Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions

Public Class Data : Implements IData

    Private ReadOnly Cnn As ICnn
    Public Sub New()
        Cnn = Services.Get(Of ICnn)
    End Sub

    Public Function GetDataTable(ByVal tableName As String, Optional sqlString As String = Nothing) As DataTable Implements IData.GetDataTable
        Cnn.SqlCnn.COpen()
        If String.IsNullOrEmpty(sqlString) Then
            sqlString = $"SELECT * FROM {tableName}"
        End If
    End Function
    Public Function GetDataSet(ByVal tableName As String, Optional sqlString As String = Nothing) As DataSet Implements IData.GetDataSet
        Try
            Cnn.SqlCnn.COpen()
            If String.IsNullOrEmpty(sqlString) Then
                sqlString = $"SELECT * FROM {tableName}"
            End If

            Dim _dater As New SqlDataAdapter()
            _dater = GetDataAdapter(tableName, sqlString)
            Dim _ds = New DataSet()
            _dater.Fill(_ds, tableName)
            Cnn.SqlCnn.CClose()
            Return _ds
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in GetDataSet", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing

    End Function




    Public Function GetAllData(Optional where As String = Nothing) As DataSet Implements IData.GetAllData

        Dim _sqlAdapter As SqlDataAdapter
        Dim _dset As DataSet

        Dim _sql As String = "SELECT * FROM Categories"

        If Not String.IsNullOrEmpty(where) Then
            _sql = $"{_sql} WHERE {where}"
        End If



        _dset = GetDataSet("Categories", _sql)



        If (_dset.Tables(0).Rows.Count > 0) Then

            Dim _ids As New List(Of Integer)
            _ids.AddRange(_dset.Tables(0).AsEnumerable.Select(Function(x) CInt(x("CategoryId"))).Distinct().ToArray)


            _sqlAdapter = GetDataAdapter("QuantityPerUnits")
            _sqlAdapter.Fill(_dset, "QuantityPerUnits")


            _sql = $"SELECT * FROM Products WHERE CategoryId IN ({String.Join(",", _ids)})"

            _sqlAdapter = GetDataAdapter("Products", _sql)
            _sqlAdapter.Fill(_dset, "Products")

            _dset.Tables("Categories").Constraints.Add("CategoryId_PK", _dset.Tables("Categories").Columns("CategoryId"), True)
            _dset.Relations.Add("CategoryProduct", _dset.Tables("Categories").Columns("CategoryId"), _dset.Tables("Products").Columns("CategoryId"))

            _sqlAdapter.Dispose()
        End If





        Return _dset



    End Function



    Public Function GetDataAdapter(ByVal tableName As String, Optional sqlString As String = Nothing) As SqlDataAdapter Implements IData.GetDataAdapter
        Try

            Dim _dter As SqlDataAdapter
            Cnn.SqlCnn.COpen()
            If String.IsNullOrEmpty(sqlString) Then
                sqlString = $"SELECT * FROM {tableName}"
            End If

            _dter = New SqlDataAdapter(sqlString, Cnn.SqlCnn)
            Cnn.SqlCnn.CClose()
            Return _dter
        Catch ex As Exception



            MessageBox.Show(ex.Message, "Error in GetAdapter", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return Nothing



    End Function


    Private Function InsertBuider(tableName As String, parameters As List(Of Parameter)) As String

        Dim cols As New List(Of String)
        Dim pars As New List(Of String)

        parameters.ForEach(Sub(p)
                               cols.Add(p.Name)
                               pars.Add($"@{p.Name}")
                           End Sub)

        Return $"INSERT INTO {tableName} ({String.Join(",", cols)}) 
                                   VALUES({String.Join(",", pars)}) SELECT SCOPE_IDENTITY()"


    End Function


    Public Function Insert(TableName As String, parameters As List(Of Parameter)) As Integer Implements IData.Insert

        Dim _rv As Integer
        Try

            Using cmd As New SqlCommand

                With cmd

                    .Connection = Cnn.SqlCnn
                    .CommandType = CommandType.Text
                    .CommandText = InsertBuider(TableName, parameters)

                    parameters.ForEach(Sub(p)
                                           .Parameters.Add($"@{p.Name}", p.DbType).Value = p.Value
                                       End Sub)
                End With


                Cnn.SqlCnn.COpen()
                _rv = cmd.ExecuteNonQuery()
                If _rv <= 0 Then
                    _rv = -1
                    Throw New Exception()
                End If
                Cnn.SqlCnn.CClose()
            End Using

            Return _rv

        Catch ex As Exception


            Return -1

        End Try


    End Function


    Private Function BulkInsert(Table As DataTable)
        Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(Cnn.SqlCnn)
            bulkCopy.DestinationTableName = "dbo.Products"
            Try
                bulkCopy.WriteToServer(Table)

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function


    Private Function UpdateBuider(tableName As String, parameterfilter As List(Of Parameter), parameters As List(Of Parameter)) As String

        '  Dim cols As New List(Of String)
        Dim pars As New List(Of String)
        Dim parsFilter As New List(Of String)

        parameters.ForEach(Sub(p)
                               pars.Add($"{p.Name} = @{p.Name}")
                           End Sub)

        parameterfilter.ForEach(Sub(p)
                                    parsFilter.Add($"{p.Name} = @{p.Name}")
                                End Sub)

        Return $"UPDATE {tableName}  SET {String.Join(",", pars)}
                                   WHERE {String.Join(" AND ", parsFilter)}"


    End Function
    Private Function DeleteBuider(tableName As String, parameterfilter As List(Of Parameter)) As String

        '  Dim cols As New List(Of String)

        Dim parsFilter As New List(Of String)
        parameterfilter.ForEach(Sub(p)
                                    parsFilter.Add($"{p.Name} = @{p.Name}")
                                End Sub)

        Return $"DELETE FROM {tableName}  
                                   WHERE {String.Join(" AND ", parsFilter)}"


    End Function
    Public Function Update(TableName As String, parameterfilter As List(Of Parameter), parameters As List(Of Parameter)) As Boolean Implements IData.Update

        Try


            Using cmd As New SqlCommand

                With cmd

                    .Connection = Cnn.SqlCnn
                    .CommandType = CommandType.Text
                    .CommandText = UpdateBuider(TableName, parameterfilter, parameters)

                    parameters.ForEach(Sub(p)
                                           .Parameters.Add($"@{p.Name}", p.DbType).Value = p.Value
                                       End Sub)


                    parameterfilter.ForEach(Sub(p)
                                                .Parameters.Add($"@{p.Name}", p.DbType).Value = p.Value
                                            End Sub)

                End With


                Cnn.SqlCnn.COpen()
                cmd.ExecuteNonQuery()
                Cnn.SqlCnn.CClose()
            End Using

            Return True


        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function Delete() As Boolean
        Try

            Return True
        Catch ex As Exception

        End Try

        Return False
    End Function

    Public Function Insert(sqlString As Object) As Integer Implements IData.Insert
        Dim _rv As Integer
        Try

            Using cmd As New SqlCommand

                With cmd

                    .Connection = Cnn.SqlCnn
                    .CommandType = CommandType.Text
                    .CommandText = sqlString
                End With


                Cnn.SqlCnn.COpen()
                _rv = cmd.ExecuteNonQuery()
                If _rv <= 0 Then
                    _rv = -1
                    Throw New Exception()
                End If
                Cnn.SqlCnn.CClose()
            End Using

            Return _rv

        Catch ex As Exception


            Return -1

        End Try
    End Function

    Public Function Update(sqlString As Object) As Boolean Implements IData.Update
        Try

            Using cmd As New SqlCommand
                With cmd
                    .Connection = Cnn.SqlCnn
                    .CommandType = CommandType.Text
                    .CommandText = sqlString
                End With
                Cnn.SqlCnn.COpen()
                cmd.ExecuteNonQuery()
                Cnn.SqlCnn.CClose()
            End Using

            Return True


        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Delete(TableName As String, parameterfilter As List(Of Parameter)) As Boolean Implements IData.Delete

        Try


            Using cmd As New SqlCommand

                With cmd

                    .Connection = Cnn.SqlCnn
                    .CommandType = CommandType.Text
                    .CommandText = DeleteBuider(TableName, parameterfilter)



                    parameterfilter.ForEach(Sub(p)
                                                .Parameters.Add($"@{p.Name}", p.DbType).Value = p.Value
                                            End Sub)
                End With


                Cnn.SqlCnn.COpen()
                cmd.ExecuteNonQuery()
                Cnn.SqlCnn.CClose()
            End Using

            Return True


        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Delete(sqlString As Object) As Boolean Implements IData.Delete
        Try

            Using cmd As New SqlCommand
                With cmd
                    .Connection = Cnn.SqlCnn
                    .CommandType = CommandType.Text
                    .CommandText = sqlString
                End With
                Cnn.SqlCnn.COpen()
                cmd.ExecuteNonQuery()
                Cnn.SqlCnn.CClose()
            End Using

            Return True


        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
