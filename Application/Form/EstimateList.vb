Option Strict On
Option Infer On

''' <summary>
''' 見積一覧画面
''' </summary>
Public Class EstimateList

#Region "イベント/コールバック"

    ''' <summary>
    ''' フォームのロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CustomerList_Load(sender As Object, e As EventArgs) Handles Me.Load
        'フォームコントロールの設定
        SetupControls()
    End Sub

    ''' <summary>
    ''' 新しい見積を作成ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NewEstimateEntryButton_Click(sender As Object, e As EventArgs) Handles NewEstimateEntryButton.Click
        Dim form As New EstimateEntry
        form.MdiParent = Me.MdiParent
        form.Show()
    End Sub

    ''' <summary>
    ''' DataGridViewのコンテンツをクリックしたイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CustomerDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles EstimateDataGridView.CellContentClick

        Select Case e.ColumnIndex
            Case 0
                '編集ボタンクリック時
                CustomerDataGridView_EditButtonClick(sender, e)
        End Select

    End Sub

    ''' <summary>
    ''' 登録フォームを終了したときに呼び出されるコールバック関数
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Friend Sub UpdateListGridView(sender As Object, e As FormClosedEventArgs)
        'データ表示を更新
        UpdateBindingSource()
        'ステータスラベルの更新
        UpdateToolStripStatusLabel()
    End Sub

    ''' <summary>
    ''' 編集ボタンクリック時に呼ばれるメソッド
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CustomerDataGridView_EditButtonClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim gridview = DirectCast(sender, DataGridView)
        Dim estPres As EstimateGridViewPresentation = DirectCast(gridview.CurrentRow.DataBoundItem, EstimateGridViewPresentation)

        Dim form As New EstimateEntry
        form.MdiParent = Me.MdiParent
        '画面を閉じた際のコールバックを設定
        AddHandler form.FormClosed, AddressOf UpdateListGridView
        '編集するモデルを設定
        form.EditEstimate = estPres.GetEstimate
        form.Show()
    End Sub

    ''' <summary>
    ''' 検索ボタンをクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        '明細データの更新
        UpdateBindingSource()
        'ステータスラベルの更新
        UpdateToolStripStatusLabel()
    End Sub

    ''' <summary>
    ''' 検索条件クリアボタンをクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClearSearchConditionButton_Click(sender As Object, e As EventArgs) Handles ClearSearchConditionButton.Click
        ClearFormSearchCondition()
    End Sub

    ''' <summary>
    ''' フォームのアクティベイトイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CustomerList_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'コンボボックスの設定
        UpdateControlDataSource()
    End Sub

#End Region

#Region "コントロール制御"

    ''' <summary>
    ''' フォームコントロールの設定を行う
    ''' </summary>
    Private Sub SetupControls()
        'コンボボックスの設定
        UpdateControlDataSource()
        'GridViewの設定
        SetupDataGridView()
        'ToolStripStatusLabelの表示内容を更新
        UpdateToolStripStatusLabel()
    End Sub

    ''' <summary>
    ''' 検索のグループボックスの内容をクリア
    ''' </summary>
    Private Sub ClearFormSearchCondition()
        Me.SearchEstimateNoTextBox.Clear()
        Me.SearchTitleTextBox.Clear()
        Me.SearchIssueDateStartDateTimePicker.Value = Date.Today
        Me.SearchIssueDateEndDateTimePicker.Value = Date.Today
        Me.SearchEffectiveDateStartDateTimePicker.Value = Date.Today
        Me.SearchEffectiveDateEndDateTimePicker.Value = Date.Today
        Me.SearchPICEmployeeComboBox.SelectedIndex = 0
        Me.SearchCustomerComboBox.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' ToolStripStatusLabelの表示内容を更新
    ''' </summary>
    Private Sub UpdateToolStripStatusLabel()
        Dim repo As Domain.IEstimateRepository = New Infrastructure.EstimateRepositoryImpl
        Dim allCount = repo.CountAllEstimate()

        Dim str = String.Format("{0}件中{1}件を表示中", allCount, EstimateDataGridView.Rows.Count)
        Me.ToolStripStatusLabel.Text = str
    End Sub

    ''' <summary>
    ''' 営業担当者のコンボボックスを設定
    ''' </summary>
    Private Sub SetupPICComboBox()
        Dim displayValues As New List(Of KeyValuePair(Of String, Domain.Employee))

        '未選択の値を追加
        Dim emptyRow = New KeyValuePair(Of String, Domain.Employee)(String.Empty, Nothing)
        displayValues.Add(emptyRow)

        '従業員情報を取得してコンボボックスメンバに利用
        Dim repo = New Infrastructure.EmployeeRepositoryImpl
        Dim emps = repo.FindAllEmployee
        For Each e In emps
            Dim kvp = New KeyValuePair(Of String, Domain.Employee)(e.Name, e)
            displayValues.Add(kvp)
        Next

        'ComboBoxの設定
        SearchPICEmployeeComboBox.ValueMember = "Value"
        SearchPICEmployeeComboBox.DisplayMember = "Key"
        SearchPICEmployeeComboBox.DataSource = displayValues
    End Sub

    ''' <summary>
    ''' 顧客のコンボボックスを設定
    ''' </summary>
    Private Sub SetupCustomerComboBox()
        Dim displayValues As New List(Of KeyValuePair(Of String, Domain.Customer))

        '顧客情報を取得してコンボボックスメンバに利用
        Dim repo = New Infrastructure.CustomerRepositoryImpl
        Dim custs = repo.FindCustomerByCondition(New Domain.CustomerRepositorySearchCondition)
        For Each e In custs
            Dim kvp = New KeyValuePair(Of String, Domain.Customer)(e.Name, e)
            displayValues.Add(kvp)
        Next

        'ComboBoxの設定
        SearchCustomerComboBox.ValueMember = "Value"
        SearchCustomerComboBox.DisplayMember = "Key"
        SearchCustomerComboBox.DataSource = displayValues
    End Sub

    ''' <summary>
    ''' コントロールのデータソースを更新
    ''' </summary>
    Private Sub UpdateControlDataSource()
        SetupPICComboBox()
        SetupCustomerComboBox()
    End Sub

#End Region

#Region "DataGridView制御"

    ''' <summary>
    ''' DataGridViewのコントロール設定
    ''' </summary>
    Private Sub SetupDataGridView()
        '一度列全体をクリア
        EstimateDataGridView.Columns.Clear()
        '列の自動生成を行わない
        EstimateDataGridView.AutoGenerateColumns = False
        'GridView内での新規行追加不可
        EstimateDataGridView.AllowUserToAddRows = False

        '編集ボタン列を作成
        Dim buttonCol = New DataGridViewButtonColumn
        With buttonCol
            .Name = "editButton"
            .HeaderText = ""
            .Text = "編集"
            .UseColumnTextForButtonValue = True
        End With
        EstimateDataGridView.Columns.Add(buttonCol)

        '見積番号
        Dim EstimateNoCol = New DataGridViewTextBoxColumn
        With EstimateNoCol
            .Name = "EstimateNoName"
            .HeaderText = "見積番号"
            .ReadOnly = True
            .DataPropertyName = "EstimateNoName"
        End With
        EstimateDataGridView.Columns.Add(EstimateNoCol)

        '顧客名
        Dim CustNameCol = New DataGridViewTextBoxColumn
        With CustNameCol
            .Name = "CustName"
            .HeaderText = "顧客名"
            .ReadOnly = True
            .DataPropertyName = "CustName"
        End With
        EstimateDataGridView.Columns.Add(CustNameCol)

        '件名列を作成
        Dim TitleCol = New DataGridViewTextBoxColumn
        With TitleCol
            .Name = "TitleName"
            .HeaderText = "件名"
            .ReadOnly = True
            .DataPropertyName = "TitleName"
        End With
        EstimateDataGridView.Columns.Add(TitleCol)

        '金額列を作成
        Dim PriceCol = New DataGridViewTextBoxColumn
        With PriceCol
            .Name = "PriceName"
            .HeaderText = "金額"
            .ReadOnly = True
            .DataPropertyName = "PriceName"
        End With
        EstimateDataGridView.Columns.Add(PriceCol)

        '発行日を作成
        Dim IssueDateCol = New DataGridViewCalendarColumn
        With IssueDateCol
            .Name = "IssueDateName"
            .HeaderText = "発行日"
            .ReadOnly = True
            .DataPropertyName = "IssueDateName"
        End With
        EstimateDataGridView.Columns.Add(IssueDateCol)

        '見積有効期限を作成
        Dim EffectiveDateCol = New DataGridViewCalendarColumn
        With EffectiveDateCol
            .Name = "EffectiveDateName"
            .HeaderText = "見積有効期限"
            .ReadOnly = True
            .DataPropertyName = "EffectiveDateName"
        End With
        EstimateDataGridView.Columns.Add(EffectiveDateCol)

        '営業担当者を作成
        Dim PICEmployeeCol = New DataGridViewTextBoxColumn
        With PICEmployeeCol
            .Name = "PICEmployeeName"
            .HeaderText = "営業担当者"
            .ReadOnly = True
            .DataPropertyName = "PICEmployeeName"
        End With
        EstimateDataGridView.Columns.Add(PICEmployeeCol)


        '明細をクリア
        EstimateDataGridView.DataSource = Nothing
    End Sub

    ''' <summary>
    ''' DataGridView用のbindingSourceのデータを更新する
    ''' </summary>
    Private Sub UpdateBindingSource()
        'データ取得用のリポジトリを作成
        Dim repo = New Infrastructure.EstimateRepositoryImpl

        'リポジトリから顧客情報を取得
        Dim cond = New Domain.EstimateRepositorySearchCondition
        With cond
            .EstimateNoForwardMatch = Me.SearchEstimateNoTextBox.Text
            .TitleForwardMatch = Me.SearchTitleTextBox.Text
            .IssueDateRangeStart = Me.SearchIssueDateStartDateTimePicker.Value
            .IssueDateRangeEnd = Me.SearchIssueDateEndDateTimePicker.Value
            .EffectiveDateRangeStart = Me.SearchEffectiveDateStartDateTimePicker.Value
            .EffectiveDateRangeEnd = Me.SearchEffectiveDateEndDateTimePicker.Value
            .PICEmployee = TryCast(Me.SearchPICEmployeeComboBox.SelectedValue, Domain.Employee)
            .Customer = TryCast(Me.SearchCustomerComboBox.SelectedValue, Domain.Customer)
        End With
        Dim estimates = repo.FindEstimateByCondition(cond)

        'データバインディング用オブジェクトへ変換
        Dim presentation = New List(Of EstimateGridViewPresentation)
        For Each est As Domain.Estimate In estimates
            presentation.Add(New EstimateGridViewPresentation(est))
        Next
        'GridViewへデータを設定
        Dim bindList = New SortableBindingList(Of EstimateGridViewPresentation)(presentation)
        EstimateDataGridView.DataSource = bindList
    End Sub

    ''' <summary>
    ''' DataGridView表示用オブジェクト
    ''' </summary>
    Private Class EstimateGridViewPresentation

        Private ReadOnly _Estimate As Domain.Estimate

        Public Sub New(ByVal est As Domain.Estimate)
            _Estimate = est
        End Sub

        Public ReadOnly Property EstimateNoName As String
            Get
                Return _Estimate.EstimateNo
            End Get
        End Property

        Public ReadOnly Property CustName As String
            Get
                Return _Estimate.Customer.Name
            End Get
        End Property

        Public ReadOnly Property TitleName As String
            Get
                Return _Estimate.Title
            End Get
        End Property

        Public ReadOnly Property PriceName As String
            Get
                Return _Estimate.EstimatePrice.ToString
            End Get
        End Property

        Public ReadOnly Property IssueDateName As String
            Get
                Return _Estimate.IssueDate.ToString("yyyy/MM/dd")
            End Get
        End Property

        Public ReadOnly Property EffectiveDateName As String
            Get
                Return _Estimate.EffectiveDate.ToString("yyyy/MM/dd")
            End Get
        End Property

        Public ReadOnly Property PICEmployeeName As String
            Get
                Return _Estimate.PICEmployee.Name
            End Get
        End Property

        Public Function GetEstimate() As Domain.Estimate
            Return _Estimate
        End Function

    End Class

#End Region


End Class