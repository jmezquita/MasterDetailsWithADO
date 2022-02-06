Imports System.Data.SqlClient

Public Interface ICnn

    ''' <summary>
    ''' Connection Property
    ''' </summary>
    ''' <returns>SqlConnection</returns>
    ReadOnly Property SqlCnn() As SqlConnection

    ''' <summary>
    ''' Contains the SqlconectionString value 
    ''' </summary>
    ''' <returns>String value with the SqlconectionString </returns>
    ReadOnly Property SqlCnnString() As String

    ''' <summary>
    ''' Test conection to verify that everything Is correct
    ''' </summary>
    ''' <returns> return true if conection is ok or false if conection is failed</returns>
    Function Test(Optional cnnString As String = Nothing) As Boolean

End Interface
