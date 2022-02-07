Imports System.Data.SqlClient
Imports System.Linq
Imports System.Transactions
Imports CrystalDecisions.CrystalReports.Engine
Imports MasterDetailsWithADO.MasterDetailsWithADO

Public Enum Action
    None = 0
    Search = 1
    Filter = 2
    Refresh = 3
    Add = 4
    Edit = 5
    Acept = 6
    Cancel = 7
    Delete = 8
    Print = 9
    Close = 10
End Enum

Public Enum State
    None = 0
    Query = 1
    Insert = 2
    Edit = 3
End Enum


Public Class ProductFormApp


    Private Navigator As New BindingNavigator
    Private Binding As New BindingSource

    Dim itemsText As IEnumerable(Of TextBox)

    Private _CurrentAction As Action

    Private CurrentPositions As Integer = 0


    Public Property CurrentAction() As Action
        Get
            Return _CurrentAction
        End Get
        Set(ByVal value As Action)


            If value <> _CurrentAction OrElse
            _CurrentAction = Action.Filter OrElse
            _CurrentAction = Action.Refresh Then


                Dim isCancel As Boolean
                RaiseEvent BeforeExecuteAction(
                _CurrentAction, value, isCancel)
                If Not isCancel AndAlso Not ExecuteAction(value) Then Return


                _CurrentAction = value


                RaiseEvent AfterExecuteAction(_CurrentAction)
            End If


        End Set
    End Property

    Private _State As State
    Public Property State() As State
        Get
            Return _State
        End Get
        Set(ByVal value As State)

            If value <> _State Then

                Dim isCancel As Boolean
                RaiseEvent BeforeStateChange(
                _State, value, isCancel)
                If isCancel Then Return

                _State = value
                ChangeState()


                RaiseEvent AfterStateChange(_State)
            End If



        End Set
    End Property



    Public Function IsExitRegit() As Boolean
        Return If(_dset?.Tables(0).Rows?.Count > 0, False)
    End Function


    Function ChangeState() As Boolean

        Select Case State
            Case State.Insert

                itemsText.ToList().ForEach(Sub(c)
                                               c.BackColor = Color.AliceBlue
                                               c.Enabled = True
                                           End Sub)


            Case State.Edit
                itemsText.ToList().ForEach(Sub(c)
                                               c.BackColor = Color.LightYellow
                                               c.Enabled = True
                                           End Sub)

            Case State.Query


                itemsText.ToList().ForEach(Sub(c)
                                               c.BackColor = Color.LightYellow
                                               c.Enabled = True
                                               c.Clear()

                                           End Sub)


            Case State.None
                itemsText.ToList().ForEach(Sub(c)
                                               c.BackColor = Color.White
                                               c.Enabled = False
                                           End Sub)
        End Select


        Return True
    End Function


    Sub BindingObject()


        itemsText.ToList().ForEach(Sub(c)
                                       c.DataBindings.Clear()
                                   End Sub)

        txtCodigo.DataBindings.Add("Text", Binding, "CategoryId")
        txtNombre.DataBindings.Add("Text", Binding, "CategoryName")
        txtDescripcion.DataBindings.Add("Text", Binding, "CategoryDescription")
        '      picImage.DataBindings.Add("Image", Binding, "CategoryPicture")

    End Sub

    Private Sub ClearObj()
        itemsText.ToList().ForEach(Sub(c)
                                       c.Clear()
                                   End Sub)

        picImage.Image = Nothing
    End Sub

    Private Function ExecuteAction(pCurrentAction As Action) As Boolean



        Try

            Dim _existReg As Boolean = IsExitRegit()

            Dim _search As Boolean, _filte As Boolean, _refresh As Boolean, _add As Boolean, _edit As Boolean,
                  _acept As Boolean, _cancel As Boolean, _delete As Boolean, _print As Boolean, _close As Boolean

            Dim _readOnlyDtGrid As Boolean = True
            Dim _enableImage As Boolean

            Select Case pCurrentAction

                Case Action.None
                    _search = True
                    _filte = _existReg
                    _refresh = _existReg
                    _add = True
                    _edit = _existReg
                    _delete = _existReg
                    _print = _existReg
                    _close = True
                    State = State.None

                Case Action.Search
                    _acept = True
                    _cancel = True
                    Navigator.BeginInit()
                    btnMoveFirst.Enabled = False
                    btnMovePreview.Enabled = False
                    btnMoveNext.Enabled = False
                    btnMoveLast.Enabled = False
                    picImage.Image = Nothing
                    State = State.Query
                    dtgDetails.DataSource = Nothing
                Case Action.Filter
                    If Not ExecuteFilter() Then
                        Return False
                    End If

                    CurrentAction = Action.None
                    Return True

                Case Action.Refresh
                    ExecuteRefreshQuery()


                    CurrentAction = Action.None
                    Return True

                Case Action.Add

                    _acept = True
                    _cancel = True
                    State = State.Insert
                    _readOnlyDtGrid = False
                    dtgDetails.AllowUserToAddRows = True
                    'dtgMaster.AllowUserToAddRows = True
                    _enableImage = True
                    txtCodigo.Enabled = False
                    picImage.Image = Nothing


                    'Navigator.MoveFirstItem = btnMoveFirst
                    'Navigator.MovePreviousItem = btnMovePreview
                    'Navigator.MoveNextItem = btnMoveNext
                    ''Navigator.MoveLastItem = btnMoveLast
                    Navigator.BeginInit()
                    DetailsTable.BeginInit()
                    btnMoveFirst.Enabled = False
                    btnMovePreview.Enabled = False
                    btnMoveNext.Enabled = False
                    btnMoveLast.Enabled = False
                    ' Navigator.EndInit()
                    _readOnlyDtGrid = False

                Case Action.Edit
                    _acept = True
                    _cancel = True

                    Navigator.BeginInit()
                    DetailsTable.BeginInit()
                    btnMoveFirst.Enabled = False
                    btnMovePreview.Enabled = False
                    btnMoveNext.Enabled = False
                    btnMoveLast.Enabled = False
                    State = State.Edit
                    _enableImage = True
                    txtCodigo.Enabled = False
                    _readOnlyDtGrid = False

                Case Action.Acept

                    AllowLoadChildData = True

                    Select Case State

                        Case State.Query
                            If Not ExecuteQuery() Then
                                Throw New Exception
                            End If
                            Navigator.EndInit()
                           ' SetImage()
                        Case State.Insert
                            If Not ExecuteInsert() Then
                                Throw New Exception
                            End If
                            Navigator.EndInit()
                            DetailsTable.EndInit()
                        Case State.Edit
                            If Not ExecuteEdit() Then
                                Throw New Exception
                            End If
                            Navigator.EndInit()
                            DetailsTable.EndInit()

                    End Select

                    CurrentAction = Action.None
                    Return True
                Case Action.Cancel

                    If State = State.Edit OrElse
                            State = State.Insert Then
                        Dim m As MsgBoxResult = MessageBox.Show("Esta seguro que deseas cancelar la Accion", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If m = MsgBoxResult.No Then
                            Return False
                        End If
                        dtgDetails.AllowUserToAddRows = False

                    End If
                    AllowLoadChildData = True
                    AllowLoadChildData = True
                    DetailsTable.EndInit()
                    Navigator.EndInit()
                    If State <> State.Edit Then
                        ClearObj()
                    End If

                    Binding.CancelEdit()
                    CurrentAction = Action.None



                    'BindingObject()

                    Return True

                Case Action.Delete
                    If Not ExecuteDelete() Then
                        Return False
                    End If


                    Return True
                Case Action.Print
                    ExecutePrint()

                    '  CurrentAction = Action.None
                    Return False
                Case Action.Close
                    Close()



            End Select


            btnSearch.Enabled = _search
            btnFilter.Enabled = _filte
            BtnRefresh.Enabled = _refresh
            BtnNew.Enabled = _add
            btnEdit.Enabled = _edit
            btnAcept.Enabled = _acept
            btnCancel.Enabled = _cancel
            btnDelete.Enabled = _delete
            btnPrint.Enabled = _print
            btnClose.Enabled = _close

            picImage.Enabled = _enableImage
            btnExaminar.Enabled = _enableImage
            dtgDetails.ReadOnly = _readOnlyDtGrid

            Return True


        Catch ex As Exception
            Return False
        End Try




    End Function

    Private Function ExecuteFilter() As Boolean



        '_dsetFilter

        'Dim frm As New Frmfilter(_dset.Tables(0).AsEnumerable)
        'frm.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y)
        'If frm.ShowDialog() = DialogResult.OK Then
        '    _dsetFilter = _dset.Tables(0).Rows.Find(frm.filteredId)
        '    Return True
        'End If


        Return False

    End Function

    Private Sub ExecuteRefreshQuery()
        Try
            BtnRefresh.Enabled = False
            If _dset?.Tables(0)?.Rows?.Count > 0 Then
                _dset = Data.GetAllData($" CategoryId IN({String.Join(",", _idsCurrentfilter.ToArray())})")

                LoadChildData()
                Binding.DataSource = _dset.Tables(0)
                Navigator.BindingSource = Binding
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Refresh Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            BtnRefresh.Enabled = True
        End Try


    End Sub

    Private Function ExecuteDelete() As Boolean
        Try

            Dim m As MsgBoxResult = MessageBox.Show($"Esta seguro que deseas Eliminar el Registro id {txtCodigo.Text}", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If m = MsgBoxResult.No Then
                Return False
            End If


            Using s As New TransactionScope

                'delete Master
                If Not Data.Delete($"DELETE FROM Categories WHERE CategoryId={txtCodigo.Text}") Then
                    Throw New Exception
                End If


                'Delete Detail
                If Not Data.Delete($"DELETE FROM Products WHERE CategoryId={txtCodigo.Text}") Then
                    Throw New Exception
                End If

                s.Complete()
                MessageBox.Show($"El registro id {txtCodigo.Text} se ha eliminado con exito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Question)

                CurrentAction = Action.Refresh
            End Using

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Delete Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try


    End Function

    Private Sub ExecutePrint()
        Try



            Dim Reporte = New ReportClass()
            Dim r As New report()

            Reporte = r
            'Reporte.da
            Reporte.SetDataSource(_dset)

            Dim reportview As New CrystalDecisions.Windows.Forms.CrystalReportViewer With {
                .ReportSource = Reporte
            }


            reportview.Refresh()


            reportview.Dock = DockStyle.Fill
            Dim frm As New frmCrystalReportViewer()
            frm.Controls.Add(reportview)

            frm.ShowDialog()




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in Print Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    'Private Function ExecuteQuery() As Boolean
    '    If LoadData() Then
    '        Return True
    '    End If

    '    Return False
    'End Function

    Private Function ExecuteInsert() As Boolean

        Try
            ''Inser master 
            Using t As New TransactionScope

                Dim pars As New List(Of Parameter)

                If String.IsNullOrEmpty(txtNombre.Text) Then
                    Throw New Exception("")
                End If


                pars.Add(New Parameter("CategoryName", txtNombre.Text))
                pars.Add(New Parameter("CategoryDescription", txtDescripcion.Text))

                If Not picImage.Image Is Nothing Then
                    pars.Add(New Parameter("CategoryPicture", picImage.Image.ConvertImageToByteArray(), SqlDbType.VarBinary))
                End If

                Dim _r = Data.Insert("Categories", pars)

                If _r <= 0 Then
                    Throw New Exception()
                End If

                txtCodigo.Text = _r.ToString()

                t.Complete()
            End Using

            MessageBox.Show("Registro Insertado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in execute insert Action", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try

    End Function

    Private Function ExecuteEdit() As Boolean
        Try
            ''Edit master 
            Using t As New TransactionScope
                Dim pars As New List(Of Parameter)
                Dim parsFilter As New List(Of Parameter)

                If String.IsNullOrEmpty(txtNombre.Text) Then
                    Throw New Exception("")
                End If


                pars.Add(New Parameter("CategoryName", txtNombre.Text))
                pars.Add(New Parameter("CategoryDescription", txtDescripcion.Text))

                If picImage.Image IsNot Nothing Then
                    pars.Add(New Parameter("CategoryPicture", picImage.Image.ConvertImageToByteArray(), SqlDbType.VarBinary))
                End If

                parsFilter.Add(New Parameter("CategoryId", txtCodigo.Text, SqlDbType.Int))

                Dim _r = Data.Update("Categories", parsFilter, pars)
                If Not _r Then
                    Throw New Exception()
                End If

                'Edit details

                pars.Clear()
                parsFilter.Clear()


                dtgDetails.BindingContext(dtgDetails.DataSource).EndCurrentEdit()
                dtgDetails.CommitEdit(DataGridViewDataErrorContexts.Commit)
                DetailsTable.AcceptChanges()

                Dim DetailsChanged As DataTable = DetailsTable.GetChanges



                DetailsChanged?.AsEnumerable.ToList().ForEach(Sub(r)
                                                                  pars.Add(New Parameter("ProductName", r("ProductName")))
                                                                  pars.Add(New Parameter("QuantityPerUnitId", r("QuantityPerUnitId"), SqlDbType.Int))
                                                                  pars.Add(New Parameter("UnitPrice", r("UnitPrice"), SqlDbType.Decimal))
                                                                  pars.Add(New Parameter("UnitInStock", r("UnitInStock"), SqlDbType.Int))
                                                                  pars.Add(New Parameter("MaxStock", r("MaxStock"), SqlDbType.Int))
                                                                  pars.Add(New Parameter("MinStock", r("MinStock"), SqlDbType.Int))

                                                                  parsFilter.Add(New Parameter("ProductId", r("ProductId")))

                                                                  _r = Data.Update("Products", parsFilter, pars)

                                                                  If Not _r Then
                                                                      Throw New Exception()
                                                                  End If
                                                              End Sub)


                t.Complete()
            End Using

            MessageBox.Show($"El registro id {txtCodigo.Text} se ha actualido con exito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in execute edit Action", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    Dim _sqlAdapter As SqlDataAdapter

    Dim _dset As DataSet
    Dim _dsetFilter As DataSet
    Private Data As IData




#Region "Events"
    Public Event BeforeExecuteAction(ByVal oldValue As Action, ByVal NewValue As Action,
                         ByRef Cancel As Boolean)

    Public Event AfterExecuteAction(CurrentValue As Action)


    Public Event BeforeStateChange(ByVal oldValue As State, ByVal NewValue As State,
                         ByRef Cancel As Boolean)

    Public Event AfterStateChange(CurrentValue As State)
#End Region


    Private Function ExecuteQuery() As Boolean

        Dim _rv As Boolean
        Try
            Dim _strwhere As String = "1=1"

            If Not String.IsNullOrEmpty(txtCodigo.Text) Then
                _strwhere = $"{_strwhere} AND CategoryId={txtCodigo.Text}"
            End If

            If Not String.IsNullOrEmpty(txtNombre.Text) Then
                _strwhere = $"{_strwhere} AND CategoryName LIKE '%{txtNombre.Text}%'"
            End If

            If Not String.IsNullOrEmpty(txtDescripcion.Text) Then
                _strwhere = $"{_strwhere} AND CategoryDescription LIKE '%{txtDescripcion.Text}%'"
            End If

            _idsCurrentfilter.Clear()
            _dset = Data.GetAllData(_strwhere)
            cbox.DataSource = _dset.Tables("QuantityPerUnits")





            If _dset.Tables("Categories").Rows.Count > 0 Then

                _idsCurrentfilter.AddRange(_dset.Tables(0).AsEnumerable.Select(Function(x) CInt(x("CategoryId"))).Distinct().ToArray)

                LoadChildData()
                _rv = True
            Else

                MessageBox.Show("No existen registros con esa condición", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _rv = False
            End If



            Binding.DataSource = _dset.Tables("Categories")

            masterCount.Text = _dset.Tables("Categories").Rows.Count
            DetailsCount.Text = _dset.Tables("Products").Rows.Count


            Navigator.BindingSource = Binding
            BindingObject()

            'tsCurrentPosition = Navigator.PositionItem

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in execute query Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _rv = False
        End Try

        Return _rv

    End Function


    Dim _idsCurrentfilter As New List(Of Integer)



    Private Sub ProductFormApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Navigator.MoveFirstItem = btnMoveFirst
        Navigator.MovePreviousItem = btnMovePreview
        Navigator.MoveNextItem = btnMoveNext
        Navigator.MoveLastItem = btnMoveLast
        Navigator.AddNewItem = BtnNew
        Navigator.PositionItem = tsCurrentPosition

        Navigator.BindingSource = Binding


        AddHandler Binding.CurrentChanged, AddressOf ChangeHandler





        itemsText = Me.GetAllControls(GetType(TextBox)).Cast(Of TextBox)

        Services.ConfigureDefaultServices()
        Data = Services.Get(Of IData)

        'LoadData()


        cbox.HeaderText = "Cant/ Unit"
        cbox.DataPropertyName = "QuantityPerUnitId"
        cbox.DisplayMember = "QuantityPerUnitName"
        cbox.ValueMember = "QuantityPerUnitId"
        dtgDetails.AutoGenerateColumns = False

        dtgDetails.Columns.Add(cbox)
        '

        ExecuteAction(Action.None)
        ' ChangeState()
    End Sub

    Private Sub ChangeHandler(sender As Object, e As EventArgs)

        SetImage()
        CurrentPositions = Binding.Position



        'If Not State = State.Query Then
        '    LoadChildData()
        'End If


    End Sub

    Dim cbox As New DataGridViewComboBoxColumn

    Dim DetailsTable As New DataTable()
    Public Sub LoadChildData(Optional IdMaster As Integer = 0)







        dtgDetails.DataSource = Nothing

        If _dset.Tables("Categories").Rows.Count > 0 Then

            Dim _parentRow As DataRow = Nothing

            If IdMaster > 0 Then

                _parentRow = _dset.Tables("Categories").Rows.Find(IdMaster)


            End If




            'If State = State.Query Then
            '    _parentRow = _dset.Tables("Categories").Rows(0)
            'Else
            '    Dim litp As New List(Of Integer)
            '    litp = _dset.Tables("Categories").AsEnumerable().Select(Function(t) _dset.Tables("Categories").Rows.IndexOf(t)).ToList()
            '    If litp.Contains(Binding.Position) Then
            '        _parentRow = _dset.Tables("Categories").Rows(Binding.Position)
            '    End If

            'End If


            If _parentRow IsNot Nothing Then
                Dim _childRows = _parentRow.GetChildRows("CategoryProduct")


                DetailsTable = _dset.Tables("Products").Clone()


                _childRows.ToList().ForEach(Function(v)
                                                DetailsTable.ImportRow(v)
                                                Return True
                                            End Function)



                DetailsTable.AcceptChanges()
                dtgDetails.DataSource = DetailsTable


                ' FillCbox()

            End If

        End If





    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CurrentAction = Action.Close
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        CurrentAction = Action.Search
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        CurrentAction = Action.Filter
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click





        CurrentAction = Action.Refresh
    End Sub

    Private Sub BntNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        CurrentAction = Action.Add
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        CurrentAction = Action.Edit
    End Sub

    Private Sub btnAcept_Click(sender As Object, e As EventArgs) Handles btnAcept.Click
        CurrentAction = Action.Acept
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        CurrentAction = Action.Cancel
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        CurrentAction = Action.Delete
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        CurrentAction = Action.Print
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click

    End Sub

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        Dim file As New OpenFileDialog()
        file.Filter = "Archivo JPG|*.jpg"
        If file.ShowDialog() = DialogResult.OK Then
            picImage.Image = Image.FromFile(file.FileName)
        End If
    End Sub
    Private Sub SetImage()


        Dim _arr = Binding?.Current()?(3)

        If _arr IsNot DBNull.Value AndAlso
            _arr IsNot Nothing AndAlso
            _arr.Length > 0 Then
            picImage.Image = ConvertByteArrayToImage(_arr)
        Else
            picImage.Image = Nothing
        End If
    End Sub

    Dim AllowLoadChildData As Boolean = True
    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

        If Not String.IsNullOrEmpty(txtCodigo.Text) AndAlso AllowLoadChildData Then

            LoadChildData(CInt(txtCodigo.Text))

        Else
            LoadChildData()
        End If

    End Sub

    Private Sub QuitarElFiltroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarElFiltroToolStripMenuItem.Click
        Refresh()
    End Sub

    Private Sub ProductFormApp_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub ProductFormApp_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub





    Private Sub txtCodigo_Enter(sender As Object, e As EventArgs) Handles txtCodigo.Enter
        AllowLoadChildData = False
    End Sub

    Private Sub txtCodigo_Leave(sender As Object, e As EventArgs) Handles txtCodigo.Leave
        AllowLoadChildData = True
    End Sub

    Private Sub btnFilter_ButtonClick(sender As Object, e As EventArgs) Handles btnFilter.ButtonClick

    End Sub
End Class