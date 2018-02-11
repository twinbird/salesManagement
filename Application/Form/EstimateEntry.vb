Option Strict On
Option Infer On

Imports System.ComponentModel

''' <summary>
''' 見積作成
''' </summary>
Public Class EstimateEntry

#Region "インスタンス変数"

    ''' <summary>
    ''' 明細のBindingList
    ''' </summary>
    Private _DetailsBindingList As BindingList(Of Domain.EstimateDetail)

#End Region

#Region "プロパティ"

    Private _Estimate As Domain.Estimate
    ''' <summary>
    ''' 編集登録に利用する場合は編集するEstimateのモデルオブジェクトを設定して呼び出しを行う
    ''' </summary>
    Public WriteOnly Property EditEstimate As Domain.Estimate
        Set(value As Domain.Estimate)
            _Estimate = value
        End Set
    End Property

#End Region

#Region "メッセージ定数"

    Private Const SaveErrorMessage As String = "保存に失敗しました。時間をおいてもう一度お試しください。"

#End Region

#Region "イベント"

    ''' <summary>
    ''' 画面ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EstimateEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetupControls()
    End Sub

    ''' <summary>
    ''' 登録ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EntryButton_Click(sender As Object, e As EventArgs) Handles EntryButton.Click
        '登録に成功したら画面を閉じる
        If Save() = True Then
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' フォームをアクティベイト
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EstimateEntry_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'コントロールのデータソースを更新
        UpdateControlDataSource()
    End Sub

    ''' <summary>
    ''' 行追加ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RowAddButton_Click(sender As Object, e As EventArgs) Handles RowAddButton.Click
        AddRowToDetail()
    End Sub

    ''' <summary>
    ''' 行削除ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RowRemoveButton_Click(sender As Object, e As EventArgs) Handles RowRemoveButton.Click
        Dim cr = DetailsDataGridView.CurrentRow
        If cr Is Nothing Then
            Return
        End If
        RemoveRowFromDetail(cr.Index)
    End Sub

    ''' <summary>
    ''' データグリッドビューのデータエラーイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DetailsDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DetailsDataGridView.DataError
        '問題のあったセルをクリアしてしまう
        Dim view As DataGridView = CType(sender, DataGridView)
        view.CancelEdit()
        e.ThrowException = False
    End Sub

    ''' <summary>
    ''' データグリッドビューの検証後に発生するイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DetailsDataGridView_Validated(sender As Object, e As EventArgs) Handles DetailsDataGridView.Validated
        UpdateSummary()
    End Sub

    ''' <summary>
    ''' データグリッドビューのセルの検証後に発生するイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DetailsDataGridView_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DetailsDataGridView.CellValidated
        UpdateSummary()
    End Sub

    ''' <summary>
    ''' 行を1つ上へボタンをクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RowUpButton_Click(sender As Object, e As EventArgs) Handles RowUpButton.Click
        Dim cr = DetailsDataGridView.CurrentRow
        If cr Is Nothing Then
            Return
        End If
        UpToDetail(cr.Index)
        SortByDisplayOrder()
    End Sub

    ''' <summary>
    ''' 行を1つ下へボタンをクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RowDownButton_Click(sender As Object, e As EventArgs) Handles RowDownButton.Click
        Dim cr = DetailsDataGridView.CurrentRow
        If cr Is Nothing Then
            Return
        End If
        DownToDetail(cr.Index)
        SortByDisplayOrder()
    End Sub

    ''' <summary>
    ''' 見積書プレビュークリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PrintPreviewButton_Click(sender As Object, e As EventArgs) Handles PrintPreviewButton.Click
        'プレビューに入る前に検証
        If _Estimate.Validate = False Then
            Return
        End If

        Dim form = New EstimateReportViewer
        form.PreviewEstimate = _Estimate
        form.ShowDialog()
    End Sub


#End Region

#Region "コントロール制御"

    ''' <summary>
    ''' フォーム内のコントロールの初期設定を実行
    ''' </summary>
    Private Sub SetupControls()
        '=============================================================================
        '各コントロールの表示設定
        '=============================================================================
        '営業担当者
        SetupPICComboBox()
        '支払条件
        SetupPaymentConditionComboBox()
        '顧客
        SetupCustomerComboBox()

        '=============================================================================
        'ドメインオブジェクトをインスタンス化してフォームコントロールにバインディング
        '=============================================================================

        '編集用にオブジェクトが引き渡されている呼び出しでは引き渡されたインスタンスを利用する
        If _Estimate Is Nothing Then
            '永続化用リポジトリのインスタンスを用意
            Dim estRepo = New Infrastructure.EstimateRepositoryImpl
            Dim custRepo = New Infrastructure.CustomerRepositoryImpl
            Dim payRepo = New Infrastructure.PaymentConditionRepositoryImpl
            Dim empRepo = New Infrastructure.EmployeeRepositoryImpl
            Dim taxRepo = New Infrastructure.SalesTaxRepositoryImpl
            'ドメインオブジェクトを生成
            _Estimate = New Domain.Estimate(estRepo, custRepo, payRepo, empRepo, taxRepo)
            '今日の税率を設定しておく
            _Estimate.SalesTax = taxRepo.TaxOn(Date.Today)
            '選択中の顧客を設定しておく
            _Estimate.Customer = TryCast(CustomerComboBox.SelectedValue, Domain.Customer)
            '選択中の支払条件を設定しておく
            _Estimate.PaymentCondition = TryCast(PaymentConditionComboBox.SelectedValue, Domain.PaymentCondition)
            '選択中の営業担当者を設定しておく
            _Estimate.PICEmployee = TryCast(PICEmployeeComboBox.SelectedValue, Domain.Employee)
        End If
        'バインディング
        Me.BindingSource.DataSource = _Estimate

        '=============================================================================
        '各コントロールとバインディングオブジェクトを紐づけ
        '=============================================================================
        '見積番号
        EstimateNoTextBox.DataBindings.Add(NameOf(EstimateNoTextBox.Text), BindingSource, NameOf(_Estimate.EstimateNo))
        '件名
        TitleTextBox.DataBindings.Add(NameOf(TitleTextBox.Text), BindingSource, NameOf(_Estimate.Title))
        '顧客
        CustomerComboBox.DataBindings.Add(NameOf(CustomerComboBox.SelectedValue), BindingSource, NameOf(_Estimate.Customer))
        '支払条件
        PaymentConditionComboBox.DataBindings.Add(NameOf(PaymentConditionComboBox.SelectedValue), BindingSource, NameOf(_Estimate.PaymentCondition))
        '発行日
        IssueDateDateTimePicker.DataBindings.Add(NameOf(IssueDateDateTimePicker.Value), BindingSource, NameOf(_Estimate.IssueDate))
        '納期
        DueDateDateTimePicker.DataBindings.Add(NameOf(DueDateDateTimePicker.Value), BindingSource, NameOf(_Estimate.DueDate))
        '見積有効期限
        EffectiveDateDateTimePicker.DataBindings.Add(NameOf(EffectiveDateDateTimePicker.Value), BindingSource, NameOf(_Estimate.EffectiveDate))
        '営業担当者
        PICEmployeeComboBox.DataBindings.Add(NameOf(PICEmployeeComboBox.SelectedValue), BindingSource, NameOf(_Estimate.PICEmployee))
        '備考
        RemarksTextBox.DataBindings.Add(NameOf(RemarksTextBox.Text), BindingSource, NameOf(_Estimate.Remarks))
        '消費税
        TaxRateTextBox.DataBindings.Add(NameOf(TaxRateTextBox.Text), BindingSource, "SalesTax.TaxRate")
        '見積金額
        '金額表示フォーマットに合わせたバインディングを作成
        Dim priceBinding = New Binding(NameOf(EstimatePriceTextBox.Text), BindingSource, NameOf(_Estimate.EstimatePrice))
        priceBinding.FormatString = "C"
        priceBinding.FormattingEnabled = True
        'バインディング
        EstimatePriceTextBox.DataBindings.Add(priceBinding)

        '見積金額税込
        Dim priceTaxBinding = New Binding(NameOf(EstimatePriceIncludeTaxTextBox.Text), BindingSource, NameOf(_Estimate.EstimatePriceIncludeTax))
        '金額表示フォーマットに合わせたバインディングを作成
        priceTaxBinding.FormatString = "C"
        priceTaxBinding.FormattingEnabled = True
        'バインディング
        EstimatePriceIncludeTaxTextBox.DataBindings.Add(priceTaxBinding)

        '明細
        SetupDataGridView()
        _DetailsBindingList = New SortableBindingList(Of Domain.EstimateDetail)(_Estimate.Details)
        DetailsDataGridView.DataSource = _DetailsBindingList

        '=============================================================================
        'エラープロバイダのデータソースにフォームを紐づけたバインディングソースを割り当て
        '=============================================================================
        Me.ErrorProvider.DataSource = BindingSource
    End Sub

    ''' <summary>
    ''' 営業担当者のコンボボックスを設定
    ''' </summary>
    Private Sub SetupPICComboBox()
        Dim displayValues As New List(Of KeyValuePair(Of String, Domain.Employee))

        '従業員情報を取得してコンボボックスメンバに利用
        Dim repo = New Infrastructure.EmployeeRepositoryImpl
        Dim emps = repo.FindAllEmployee
        For Each e In emps
            Dim kvp = New KeyValuePair(Of String, Domain.Employee)(e.Name, e)
            displayValues.Add(kvp)
        Next

        'ComboBoxの設定
        PICEmployeeComboBox.ValueMember = "Value"
        PICEmployeeComboBox.DisplayMember = "Key"
        PICEmployeeComboBox.DataSource = displayValues
    End Sub

    ''' <summary>
    ''' 支払条件のコンボボックスを設定
    ''' </summary>
    Private Sub SetupPaymentConditionComboBox()
        Dim displayValues As New List(Of KeyValuePair(Of String, Domain.PaymentCondition))

        '支払条件情報を取得してコンボボックスメンバに利用
        Dim repo = New Infrastructure.PaymentConditionRepositoryImpl
        Dim pays = repo.FindAllPaymentCondition
        For Each e In pays
            Dim kvp = New KeyValuePair(Of String, Domain.PaymentCondition)(e.Name, e)
            displayValues.Add(kvp)
        Next

        'ComboBoxの設定
        PaymentConditionComboBox.ValueMember = "Value"
        PaymentConditionComboBox.DisplayMember = "Key"
        PaymentConditionComboBox.DataSource = displayValues
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
        CustomerComboBox.ValueMember = "Value"
        CustomerComboBox.DisplayMember = "Key"
        CustomerComboBox.DataSource = displayValues
    End Sub

    ''' <summary>
    ''' コントロールのデータソースを更新
    ''' </summary>
    Private Sub UpdateControlDataSource()
        SetupPICComboBox()
        SetupPaymentConditionComboBox()
        SetupCustomerComboBox()
    End Sub

    ''' <summary>
    ''' 見積金額等の集計欄のデータを更新
    ''' </summary>
    Private Sub UpdateSummary()
        EstimatePriceTextBox.DataBindings.Item(0).ReadValue()
        If TaxRateTextBox.DataBindings.Count > 0 Then
            TaxRateTextBox.DataBindings.Item(0).ReadValue()
        End If
        EstimatePriceIncludeTaxTextBox.DataBindings.Item(0).ReadValue()
    End Sub

#End Region

#Region "DataGridView制御"

    ''' <summary>
    ''' DataGridViewのコントロール設定
    ''' </summary>
    Private Sub SetupDataGridView()
        '一度列全体をクリア
        DetailsDataGridView.Columns.Clear()
        '列の自動生成を行わない
        DetailsDataGridView.AutoGenerateColumns = False
        'GridView内での新規行追加不可
        DetailsDataGridView.AllowUserToAddRows = False

        '表示順列を作成
        Dim displayNoCol = New DataGridViewTextBoxColumn
        With displayNoCol
            .Name = "DisplayOrderCol"
            .HeaderText = "No."
            .ReadOnly = True
            .DataPropertyName = "DisplayOrder"
        End With
        DetailsDataGridView.Columns.Add(displayNoCol)

        '品名列を作成
        Dim itemNameCol = New DataGridViewTextBoxColumn
        With itemNameCol
            .Name = "ItemNameCol"
            .HeaderText = "品名"
            .ReadOnly = False
            .DataPropertyName = "ItemName"
        End With
        DetailsDataGridView.Columns.Add(itemNameCol)

        '数量列を作成
        Dim quantityCol = New DataGridViewTextBoxColumn
        With quantityCol
            .Name = "Quantity"
            .HeaderText = "数量"
            .DataPropertyName = "Quantity"
        End With
        DetailsDataGridView.Columns.Add(quantityCol)

        '単価列を作成
        Dim unitPriceCol = New DataGridViewTextBoxColumn
        With unitPriceCol
            .Name = "UnitPrice"
            .HeaderText = "単価"
            .DataPropertyName = "UnitPrice"
        End With
        DetailsDataGridView.Columns.Add(unitPriceCol)

        '明細をクリア
        DetailsDataGridView.DataSource = Nothing
    End Sub

    ''' <summary>
    ''' 指定行の上の行に明細へ行を追加
    ''' </summary>
    Private Sub AddRowToDetail()
        Dim d = New Domain.EstimateDetail
        _Estimate.AddDetail(d)
        _DetailsBindingList.ResetBindings()
    End Sub

    ''' <summary>
    ''' 指定行を削除
    ''' </summary>
    Private Sub RemoveRowFromDetail(ByVal idx As Integer)
        _Estimate.RemoveDetail(idx)
        _DetailsBindingList.ResetBindings()
    End Sub

    ''' <summary>
    ''' 指定行を上へ1つ移動
    ''' </summary>
    Private Sub UpToDetail(ByVal idx As Integer)
        Dim d = _Estimate.Details(idx)
        _Estimate.UpToDisplayOrder(d.DisplayOrder)
        _DetailsBindingList.ResetBindings()
    End Sub

    ''' <summary>
    ''' 指定行を下へ1つ移動
    ''' </summary>
    ''' <param name="idx"></param>
    Private Sub DownToDetail(ByVal idx As Integer)
        Dim d = _Estimate.Details(idx)
        _Estimate.DownToDisplayOrder(d.DisplayOrder)
        _DetailsBindingList.ResetBindings()
    End Sub

    ''' <summary>
    ''' 表示順でグリッドビューをソートする
    ''' </summary>
    Private Sub SortByDisplayOrder()
        Dim sortCol = DetailsDataGridView.Columns("DisplayOrderCol")
        DetailsDataGridView.Sort(sortCol, ListSortDirection.Ascending)
    End Sub

#End Region

#Region "永続化"

    ''' <summary>
    ''' フォームの入力内容で登録処理を実行
    ''' </summary>
    ''' <returns>登録成功:True 登録失敗:False</returns>
    Private Function Save() As Boolean
        'ドメインオブジェクトの正当性を確認
        If _Estimate.Validate() = False Then
            'エラー情報を更新
            Me.ErrorProvider.UpdateBinding()
            Return False
        End If
        '登録
        If _Estimate.Save() = False Then
            MessageBox.Show(SaveErrorMessage)
        End If
        Return True
    End Function

#End Region

End Class