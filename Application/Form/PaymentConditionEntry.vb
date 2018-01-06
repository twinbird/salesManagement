Option Strict On
Option Infer On

''' <summary>
''' 支払条件登録フォーム
''' </summary>
Public Class PaymentConditionEntry

#Region "プロパティ"

    Private _PaymentCondition As Domain.PaymentCondition
    ''' <summary>
    ''' 編集登録に利用する場合は編集するPaymentConditionのモデルオブジェクトを設定して呼び出しを行う
    ''' </summary>
    Public WriteOnly Property EditPaymentCondition As Domain.PaymentCondition
        Set(value As Domain.PaymentCondition)
            _PaymentCondition = value
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
    Private Sub PaymentConditionEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
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

#End Region

#Region "コントロール制御"

    ''' <summary>
    ''' フォーム内のコントロールの初期設定を実行
    ''' </summary>
    Private Sub SetupControls()
        '=============================================================================
        '各コントロールの表示設定
        '=============================================================================
        '締日
        SetupCutOffComboBox()
        '支払月
        SetupMonthOffsetComboBox()
        '支払日
        SetupDueDateComboBox()

        '=============================================================================
        'ドメインオブジェクトをインスタンス化してフォームコントロールにバインディング
        '=============================================================================

        '編集用にオブジェクトが引き渡されている呼び出しでは引き渡されたインスタンスを利用する
        If _PaymentCondition Is Nothing Then
            '永続化用リポジトリのインスタンスを用意
            Dim paymentRepo = New Infrastructure.PaymentConditionRepositoryImpl()
            'ドメインオブジェクトを生成
            _PaymentCondition = New Domain.PaymentCondition(paymentRepo)
        End If
        'バインディング
        Me.BindingSource.DataSource = _PaymentCondition

        '=============================================================================
        '各コントロールとバインディングオブジェクトを紐づけ
        '=============================================================================
        '支払条件名
        PaymentConditionNameTextBox.DataBindings.Add(NameOf(PaymentConditionNameTextBox.Text), BindingSource, NameOf(_PaymentCondition.Name))
        '締日
        CutOffComboBox.DataBindings.Add(NameOf(CutOffComboBox.SelectedValue), BindingSource, NameOf(_PaymentCondition.CutOff))
        '支払月
        MonthOffsetComboBox.DataBindings.Add(NameOf(MonthOffsetComboBox.SelectedValue), BindingSource, NameOf(_PaymentCondition.MonthOffset))
        '支払日
        DueDateComboBox.DataBindings.Add(NameOf(DueDateComboBox.SelectedValue), BindingSource, NameOf(_PaymentCondition.DueDate))

        '=============================================================================
        'エラープロバイダのデータソースにフォームを紐づけたバインディングソースを割り当て
        '=============================================================================
        ErrorProvider.DataSource = BindingSource
    End Sub

    ''' <summary>
    ''' 締日のコンボボックスを設定
    ''' </summary>
    Private Sub SetupCutOffComboBox()
        Dim displayValues As New List(Of KeyValuePair(Of String, Integer))

        '1日から月末の前の日まで追加
        For i As Integer = 1 To Domain.PaymentCondition.CutOffEndOfMonth - 1
            Dim kvp = New KeyValuePair(Of String, Integer)(i.ToString & "日", i)
            displayValues.Add(kvp)
        Next
        '月末も追加
        displayValues.Add(New KeyValuePair(Of String, Integer)("月末", Domain.PaymentCondition.CutOffEndOfMonth))

        'ComboBoxの設定
        CutOffComboBox.ValueMember = "Value"
        CutOffComboBox.DisplayMember = "Key"
        CutOffComboBox.DataSource = displayValues
    End Sub

    ''' <summary>
    ''' 支払月のコンボボックスを設定
    ''' </summary>
    Private Sub SetupMonthOffsetComboBox()
        Dim displayValues As New List(Of KeyValuePair(Of String, Integer))

        '当月
        displayValues.Add(New KeyValuePair(Of String, Integer)("当月", 0))
        '翌月
        displayValues.Add(New KeyValuePair(Of String, Integer)("翌月", 1))
        '翌々月
        displayValues.Add(New KeyValuePair(Of String, Integer)("翌々月", 2))
        'nか月後
        For i As Integer = 3 To 11
            displayValues.Add(New KeyValuePair(Of String, Integer)(i.ToString & "か月後", i))
        Next
        '翌年
        displayValues.Add(New KeyValuePair(Of String, Integer)("翌年", 12))

        'ComboBoxの設定
        MonthOffsetComboBox.ValueMember = "Value"
        MonthOffsetComboBox.DisplayMember = "Key"
        MonthOffsetComboBox.DataSource = displayValues
    End Sub

    ''' <summary>
    ''' 支払日のコンボボックスを設定
    ''' </summary>
    Private Sub SetupDueDateComboBox()
        Dim displayValues As New List(Of KeyValuePair(Of String, Integer))

        '1日から月末の前の日まで追加
        For i As Integer = 1 To Domain.PaymentCondition.DueDateEndOfMonth - 1
            Dim kvp = New KeyValuePair(Of String, Integer)(i.ToString & "日", i)
            displayValues.Add(kvp)
        Next
        '月末も追加
        displayValues.Add(New KeyValuePair(Of String, Integer)("月末", Domain.PaymentCondition.DueDateEndOfMonth))

        'ComboBoxの設定
        DueDateComboBox.ValueMember = "Value"
        DueDateComboBox.DisplayMember = "Key"
        DueDateComboBox.DataSource = displayValues
    End Sub

#End Region

#Region "永続化"

    ''' <summary>
    ''' フォームの入力内容で登録処理を実行
    ''' </summary>
    ''' <returns>登録成功:True 登録失敗:False</returns>
    Private Function Save() As Boolean
        'ドメインオブジェクトの正当性を確認
        If _PaymentCondition.Validate() = False Then
            'エラー情報を更新
            ErrorProvider.UpdateBinding()
            Return False
        End If
        '登録
        If _PaymentCondition.Save() = False Then
            MessageBox.Show(SaveErrorMessage)
        End If
        Return True
    End Function

#End Region

End Class