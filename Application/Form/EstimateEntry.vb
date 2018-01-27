Option Strict On
Option Infer On

''' <summary>
''' 見積作成
''' </summary>
Public Class EstimateEntry

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
        'TaxRateTextBox.DataBindings.Add(NameOf(TaxRateTextBox.Text), BindingSource, NameOf(_Estimate.SalesTax.TaxRate))
        '見積金額
        EstimatePriceTextBox.DataBindings.Add(NameOf(EstimatePriceTextBox.Text), BindingSource, NameOf(_Estimate.EstimatePrice))
        '見積金額税込
        EstimatePriceIncludeTaxTextBox.DataBindings.Add(NameOf(EstimatePriceIncludeTaxTextBox.Text), BindingSource, NameOf(_Estimate.EstimatePriceIncludeTax))

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