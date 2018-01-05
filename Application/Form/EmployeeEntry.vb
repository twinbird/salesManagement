Option Strict On
Option Infer On

''' <summary>
''' 従業員登録画面
''' </summary>
Public Class EmployeeEntry

#Region "プロパティ"

    Private _Employee As Domain.Employee
    ''' <summary>
    ''' 編集登録に利用する場合は編集するEmployeeのモデルオブジェクトを設定して呼び出しを行う
    ''' </summary>
    Public WriteOnly Property EditEmployee As Domain.Employee
        Set(value As Domain.Employee)
            _Employee = value
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
    Private Sub EmployeeEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetupControls()
    End Sub

    ''' <summary>
    ''' 登録ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EntryButton_Click(sender As Object, e As EventArgs) Handles EntryButton.Click
        '登録に成功したら画面を閉じる
        If save() = True Then
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
        'ドメインオブジェクトをインスタンス化してフォームコントロールにバインディング
        '=============================================================================

        '編集用にオブジェクトが引き渡されている呼び出しでは引き渡されたインスタンスを利用する
        If _Employee Is Nothing Then
            '永続化用リポジトリのインスタンスを用意
            Dim employeeRepo = New Infrastructure.EmployeeRepositoryImpl()
            'ドメインオブジェクトを生成
            _Employee = New Domain.Employee(employeeRepo)
        End If
        'バインディング
        Me.BindingSource.DataSource = _Employee

        '=============================================================================
        '各コントロールとバインディングオブジェクトを紐づけ
        '=============================================================================
        '従業員No
        EmployeeNumberTextBox.DataBindings.Add(NameOf(EmployeeNumberTextBox.Text), BindingSource, NameOf(_Employee.EmployeeNo))
        '名前
        NameTextBox.DataBindings.Add(NameOf(NameTextBox.Text), BindingSource, NameOf(_Employee.Name))
        'かな名
        KanaNameTextBox.DataBindings.Add(NameOf(KanaNameTextBox.Text), BindingSource, NameOf(_Employee.NameKana))

        '=============================================================================
        'エラープロバイダのデータソースにフォームを紐づけたバインディングソースを割り当て
        '=============================================================================
        ErrorProvider.DataSource = BindingSource
    End Sub

#End Region

#Region "永続化"

    ''' <summary>
    ''' フォームの入力内容で登録処理を実行
    ''' </summary>
    ''' <returns>登録成功:True 登録失敗:False</returns>
    Private Function save() As Boolean
        'ドメインオブジェクトの正当性を確認
        If _Employee.Validate() = False Then
            'エラー情報を更新
            ErrorProvider.UpdateBinding()
            Return False
        End If
        '登録
        If _Employee.Save() = False Then
            MessageBox.Show(SaveErrorMessage)
        End If
        Return True
    End Function


#End Region

End Class