<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductFormApp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductFormApp))
        Me.dtgDetails = New System.Windows.Forms.DataGridView()
        Me.ProductId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityPerUnitId = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaxStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MinStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnFilter = New System.Windows.Forms.ToolStripSplitButton()
        Me.QuitarElFiltroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMoveFirst = New System.Windows.Forms.ToolStripButton()
        Me.btnMovePreview = New System.Windows.Forms.ToolStripButton()
        Me.btnMoveNext = New System.Windows.Forms.ToolStripButton()
        Me.btnMoveLast = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnAcept = New System.Windows.Forms.ToolStripButton()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.masterCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DetailsCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsCurrentPosition = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Filtradossss = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Filtrados = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.dtgDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMenu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgDetails
        '
        Me.dtgDetails.AllowUserToAddRows = False
        Me.dtgDetails.AllowUserToOrderColumns = True
        Me.dtgDetails.ColumnHeadersHeight = 50
        Me.dtgDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductId, Me.ProductName, Me.QuantityPerUnitId, Me.UnitPrice, Me.UnitInStock, Me.MaxStock, Me.MinStock})
        Me.dtgDetails.Location = New System.Drawing.Point(9, 255)
        Me.dtgDetails.Name = "dtgDetails"
        Me.dtgDetails.RowHeadersWidth = 20
        Me.dtgDetails.RowTemplate.Height = 28
        Me.dtgDetails.Size = New System.Drawing.Size(813, 334)
        Me.dtgDetails.TabIndex = 1
        '
        'ProductId
        '
        Me.ProductId.HeaderText = "Código"
        Me.ProductId.Name = "ProductId"
        Me.ProductId.Width = 70
        '
        'ProductName
        '
        Me.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ProductName.HeaderText = "Nombre"
        Me.ProductName.Name = "ProductName"
        '
        'QuantityPerUnitId
        '
        Me.QuantityPerUnitId.HeaderText = "Cantidad/Unidad"
        Me.QuantityPerUnitId.Name = "QuantityPerUnitId"
        '
        'UnitPrice
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0.00"
        Me.UnitPrice.DefaultCellStyle = DataGridViewCellStyle5
        Me.UnitPrice.HeaderText = "Precio/Unidad"
        Me.UnitPrice.Name = "UnitPrice"
        '
        'UnitInStock
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.UnitInStock.DefaultCellStyle = DataGridViewCellStyle6
        Me.UnitInStock.HeaderText = "Cantidad/Stock"
        Me.UnitInStock.Name = "UnitInStock"
        Me.UnitInStock.Width = 50
        '
        'MaxStock
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.MaxStock.DefaultCellStyle = DataGridViewCellStyle7
        Me.MaxStock.HeaderText = "Max/Stock"
        Me.MaxStock.Name = "MaxStock"
        Me.MaxStock.Width = 50
        '
        'MinStock
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        Me.MinStock.DefaultCellStyle = DataGridViewCellStyle8
        Me.MinStock.HeaderText = "Min/Stock"
        Me.MinStock.Name = "MinStock"
        Me.MinStock.Width = 50
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.BackColor = System.Drawing.Color.Silver
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSearch, Me.btnFilter, Me.BtnRefresh, Me.ToolStripSeparator1, Me.btnMoveFirst, Me.btnMovePreview, Me.btnMoveNext, Me.btnMoveLast, Me.ToolStripSeparator4, Me.BtnNew, Me.btnEdit, Me.btnAcept, Me.btnCancel, Me.btnDelete, Me.ToolStripSeparator2, Me.btnPrint, Me.ToolStripSeparator3, Me.btnClose})
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(822, 70)
        Me.ToolStripMenu.TabIndex = 2
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnSearch.Image = Global.MasterDetailsWithADO.My.Resources.CT.search
        Me.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(52, 67)
        Me.btnSearch.Text = "&Buscar"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnFilter
        '
        Me.btnFilter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitarElFiltroToolStripMenuItem})
        Me.btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), System.Drawing.Image)
        Me.btnFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(64, 67)
        Me.btnFilter.Text = "&Filtrar"
        Me.btnFilter.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'QuitarElFiltroToolStripMenuItem
        '
        Me.QuitarElFiltroToolStripMenuItem.Image = CType(resources.GetObject("QuitarElFiltroToolStripMenuItem.Image"), System.Drawing.Image)
        Me.QuitarElFiltroToolStripMenuItem.Name = "QuitarElFiltroToolStripMenuItem"
        Me.QuitarElFiltroToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.QuitarElFiltroToolStripMenuItem.Text = "Quitar el Filtro"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Image = CType(resources.GetObject("BtnRefresh.Image"), System.Drawing.Image)
        Me.BtnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(59, 67)
        Me.BtnRefresh.Text = "&Refrescar"
        Me.BtnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 70)
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Image = CType(resources.GetObject("btnMoveFirst.Image"), System.Drawing.Image)
        Me.btnMoveFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnMoveFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(52, 67)
        Me.btnMoveFirst.Text = "Primer"
        Me.btnMoveFirst.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMoveFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnMovePreview
        '
        Me.btnMovePreview.Image = CType(resources.GetObject("btnMovePreview.Image"), System.Drawing.Image)
        Me.btnMovePreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnMovePreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMovePreview.Name = "btnMovePreview"
        Me.btnMovePreview.Size = New System.Drawing.Size(54, 67)
        Me.btnMovePreview.Text = "Anterior"
        Me.btnMovePreview.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMovePreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Image = CType(resources.GetObject("btnMoveNext.Image"), System.Drawing.Image)
        Me.btnMoveNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnMoveNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(60, 67)
        Me.btnMoveNext.Text = "Siguiente"
        Me.btnMoveNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMoveNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Image = CType(resources.GetObject("btnMoveLast.Image"), System.Drawing.Image)
        Me.btnMoveLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnMoveLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(52, 67)
        Me.btnMoveLast.Text = "&Ultimo"
        Me.btnMoveLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMoveLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 70)
        '
        'BtnNew
        '
        Me.BtnNew.Image = CType(resources.GetObject("BtnNew.Image"), System.Drawing.Image)
        Me.BtnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(52, 67)
        Me.BtnNew.Text = "&Nuevo"
        Me.BtnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(52, 67)
        Me.btnEdit.Text = "&Editar"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAcept
        '
        Me.btnAcept.Image = CType(resources.GetObject("btnAcept.Image"), System.Drawing.Image)
        Me.btnAcept.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAcept.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAcept.Name = "btnAcept"
        Me.btnAcept.Size = New System.Drawing.Size(52, 67)
        Me.btnAcept.Text = "&Aceptar"
        Me.btnAcept.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAcept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(57, 67)
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(54, 67)
        Me.btnDelete.Text = "E&liminar"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 70)
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(57, 67)
        Me.btnPrint.Text = "&Imprimir"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 70)
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(47, 67)
        Me.btnClose.Text = "&Cerrar"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.masterCount, Me.ToolStripStatusLabel5, Me.DetailsCount, Me.ToolStripStatusLabel4, Me.tsCurrentPosition, Me.Filtradossss, Me.Filtrados})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 592)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(822, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(52, 17)
        Me.ToolStripStatusLabel1.Text = "Oficina"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(53, 17)
        Me.ToolStripStatusLabel2.Text = "Principal"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(49, 17)
        Me.ToolStripStatusLabel3.Text = "Mastro:"
        '
        'masterCount
        '
        Me.masterCount.Name = "masterCount"
        Me.masterCount.Size = New System.Drawing.Size(13, 17)
        Me.masterCount.Text = "0"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(47, 17)
        Me.ToolStripStatusLabel5.Text = "Detalle"
        '
        'DetailsCount
        '
        Me.DetailsCount.Name = "DetailsCount"
        Me.DetailsCount.Size = New System.Drawing.Size(13, 17)
        Me.DetailsCount.Text = "0"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(91, 17)
        Me.ToolStripStatusLabel4.Text = "Posición actual:"
        '
        'tsCurrentPosition
        '
        Me.tsCurrentPosition.Name = "tsCurrentPosition"
        Me.tsCurrentPosition.Size = New System.Drawing.Size(13, 17)
        Me.tsCurrentPosition.Text = "0"
        '
        'Filtradossss
        '
        Me.Filtradossss.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Filtradossss.Name = "Filtradossss"
        Me.Filtradossss.Size = New System.Drawing.Size(57, 17)
        Me.Filtradossss.Text = "Filtrados:"
        '
        'Filtrados
        '
        Me.Filtrados.Name = "Filtrados"
        Me.Filtrados.Size = New System.Drawing.Size(13, 17)
        Me.Filtrados.Text = "0"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(85, 30)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 23)
        Me.txtCodigo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Código:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Descripcion:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(85, 88)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(454, 55)
        Me.txtDescripcion.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(85, 59)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(454, 23)
        Me.txtNombre.TabIndex = 8
        '
        'picImage
        '
        Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage.Location = New System.Drawing.Point(640, 11)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(147, 132)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage.TabIndex = 10
        Me.picImage.TabStop = False
        '
        'btnExaminar
        '
        Me.btnExaminar.Location = New System.Drawing.Point(664, 146)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(94, 23)
        Me.btnExaminar.TabIndex = 11
        Me.btnExaminar.Text = "Examinar"
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.btnExaminar)
        Me.GroupBox1.Controls.Add(Me.picImage)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(813, 176)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Categoria"
        '
        'ProductFormApp
        '
        Me.ClientSize = New System.Drawing.Size(822, 614)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.Controls.Add(Me.dtgDetails)
        Me.Name = "ProductFormApp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Productos"
        CType(Me.dtgDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgDetails As DataGridView
    Friend WithEvents ProductId As DataGridViewTextBoxColumn
    Friend WithEvents ProductName As DataGridViewTextBoxColumn
    Friend WithEvents QuantityPerUnitId As DataGridViewComboBoxColumn
    Friend WithEvents UnitPrice As DataGridViewTextBoxColumn
    Friend WithEvents UnitInStock As DataGridViewTextBoxColumn
    Friend WithEvents MaxStock As DataGridViewTextBoxColumn
    Friend WithEvents MinStock As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripMenu As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents BtnRefresh As ToolStripButton
    Friend WithEvents BtnNew As ToolStripButton
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnAcept As ToolStripButton
    Friend WithEvents btnCancel As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnPrint As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents btnMoveLast As ToolStripButton
    Friend WithEvents btnClose As ToolStripButton
    Friend WithEvents btnMoveFirst As ToolStripButton
    Friend WithEvents btnMovePreview As ToolStripButton
    Friend WithEvents btnMoveNext As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents picImage As PictureBox
    Friend WithEvents btnExaminar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnFilter As ToolStripSplitButton
    Friend WithEvents QuitarElFiltroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents masterCount As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents DetailsCount As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents tsCurrentPosition As ToolStripStatusLabel
    Friend WithEvents Filtradossss As ToolStripStatusLabel
    Friend WithEvents Filtrados As ToolStripStatusLabel
End Class
