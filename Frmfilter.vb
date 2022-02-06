Public Class Frmfilter


    Dim _IECategories As IEnumerable(Of DataRow)

    Public filteredId As Integer = 0

    Dim ColumnsIndex = 0

    Sub New(pCategoriesList As IEnumerable(Of DataRow))

        ' This call is required by the designer.
        InitializeComponent()


        _IECategories = pCategoriesList
        ' Add any initialization after the InitializeComponent() call.
        FilterList()
    End Sub

    Function FilterList(Optional valuertofilter As String = Nothing) As Boolean

        Try

            If _IECategories Is Nothing OrElse _IECategories.Count() = 0 Then
                Return False
            End If

            Dim _categories As IEnumerable(Of DataRow) = Nothing
            gridData.Rows.Clear()
            _categories = _IECategories


            If Not String.IsNullOrEmpty(valuertofilter) Then
                If ColumnsIndex = 0 Then
                    _categories = _categories.Where(Function(w) w("CategoryId").ToString().ToLower().Contains(valuertofilter.ToLower()))
                Else
                    _categories = _categories.Where(Function(w) w("CategoryName").ToString().ToLower().Contains(valuertofilter.ToLower()))
                End If
            End If




            _categories.[Select](Function(r) {
                                   r("CategoryId"),
                                   r("CategoryName")
                                   }).Take(50).ToList().ForEach(Function(i)
                                                                    Return gridData.Rows.Add(i)
                                                                End Function)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Filter Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Return True
    End Function

    Private Sub gridData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridData.CellDoubleClick
        filteredId = If(gridData.Rows(gridData.CurrentCell.RowIndex).Cells(0).Value.ToString().Trim(), 0)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        filteredId = If(gridData.Rows(gridData.CurrentCell.RowIndex).Cells(0).Value.ToString().Trim(), 0)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        filteredId = 0
    End Sub

    Private Sub Frmfilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub gridHeader_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridHeader.KeyPress

    End Sub

    Private Sub gridHeader_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles gridHeader.CellEndEdit

    End Sub
    ' KeyPressEventArgs
    Private Sub Control_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        FilterList(TryCast(sender, Control).Text)
    End Sub
    Private Sub gridHeader_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles gridHeader.EditingControlShowing


        AddHandler e.Control.KeyUp, AddressOf Control_KeyUp


    End Sub


    Private Sub gridHeader_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles gridHeader.CellBeginEdit
        ColumnsIndex = e.ColumnIndex
    End Sub
End Class