Imports System.Data.SqlClient
Imports MasterDetailsWithADO.My.Resources



''' <summary>
''' Common conection class to work in all proyect
''' </summary>
Public Class Cnn : Implements ICnn

    Public Sub New()
        _SqlCnn = New SqlConnection(SqlCnnString)
    End Sub

#Region "Vars"
    Private _SqlCnn As SqlConnection
#End Region

#Region "Properties"
    ''' <summary>
    ''' Connection Property
    ''' </summary>
    ''' <returns>SqlConnection</returns>
    Public ReadOnly Property SqlCnn() As SqlConnection Implements ICnn.SqlCnn
        Get
            Return If(_SqlCnn, New SqlConnection(SqlCnnString))
        End Get
    End Property

    ''' <summary>
    ''' Contains the SqlconectionString value 
    ''' </summary>
    ''' <returns>String value with the SqlconectionString </returns>
    Public ReadOnly Property SqlCnnString() As String Implements ICnn.SqlCnnString
        Get
            Return String.Format(CT.StringCnn, CT.User, CT.Pwd, CT.DataBase, CT.Server)
        End Get
    End Property


#End Region






#Region "Functions"

    ''' <summary>
    ''' Test conection to verify that everything Is correct
    ''' </summary>
    ''' <returns> return true if conection is ok or false if conection is failed</returns>
    Public Function Test(Optional cnnString As String = Nothing) As Boolean Implements ICnn.Test

        Try

            If String.IsNullOrEmpty(cnnString) Then
                SqlCnn.Test()
            Else

                Dim _cnn As New SqlConnection(cnnString)
                _cnn.Test()

            End If
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Test conection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Return False
    End Function


#End Region

End Class
