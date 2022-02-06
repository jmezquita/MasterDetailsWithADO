Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices



Module ExtensionMethods

#Region "SqlConnection"

    ''' <summary>
    ''' Test Conection
    ''' </summary>
    ''' <param name="cnn"></param>
    <Extension()>
    Public Sub Test(ByVal cnn As SqlConnection)

        Try
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
                cnn.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Test Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Open Conection
    ''' </summary>
    ''' <param name="cnn"></param>
    <Extension()>
    Public Sub COpen(ByVal cnn As SqlConnection)
        Try
            If cnn.State = ConnectionState.Closed Then cnn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Open conection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Close Conection
    ''' </summary>
    ''' <param name="cnn"></param>
    <Extension()>
    Public Sub CClose(ByVal cnn As SqlConnection)
        Try
            If cnn.State = ConnectionState.Open Then cnn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Close conection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region



#Region "Form"
    ''' <summary>
    ''' Get all control
    ''' </summary>
    ''' <param name="cnn"></param>
    <Extension()>
    Public Function GetAllControls(frm As Form, ByVal type As Type) As IEnumerable(Of Control)
        Return GetAll(frm, GetType(TextBox))
    End Function

#End Region



#Region "IMAGE"
    <Extension()>
    Public Function ConvertImageToByteArray(ByVal imageIn As Image) As Byte()
        Dim ms As MemoryStream = New MemoryStream()

        If imageIn IsNot Nothing Then
            imageIn.Save(ms, ImageFormat.Png)
            Return ms.ToArray()
        Else
            Return Nothing
        End If
    End Function



    <Extension()>
    Public Function ConvertByteArrayToImage(ByVal _ArrayByte As Byte()) As Image
        Try
            Dim m_MemoryStream As MemoryStream = New MemoryStream(_ArrayByte)
            Return Image.FromStream(m_MemoryStream)
        Catch __unusedException1__ As Exception
            Return Nothing
        End Try
    End Function

#End Region


End Module