Option Strict On
Option Infer On

''' <summary>
''' 自社情報の設定画面
''' </summary>
Public Class CompanyInformationEntry

#Region "メッセージ定数"

    Private Const SaveErrorMessage As String = "保存に失敗しました。時間をおいてもう一度お試しください。"

#End Region

#Region "インスタンス変数"

    Private _Company As Domain.CompanyInformation

#End Region

#Region "イベント"

    ''' <summary>
    ''' 画面ロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CompanyInformationEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        'ドメインオブジェクトをインスタンス化してフォームコントロールにバインディング
        '=============================================================================

        '登録済みオブジェクトを探す
        Dim repo = New Infrastructure.CompanyInformationImpl
        _Company = repo.Find
        'なければ新しく作成
        If _Company Is Nothing Then
            'ドメインオブジェクトを生成
            _Company = New Domain.CompanyInformation
        End If
        'バインディング
        Me.BindingSource.DataSource = _Company

        '=============================================================================
        '各コントロールとバインディングオブジェクトを紐づけ
        '=============================================================================
        '会社名
        NameTextBox.DataBindings.Add(NameOf(NameTextBox.Text), BindingSource, NameOf(_Company.Name))
        '郵便番号
        PostalCodeMaskedTextBox.DataBindings.Add(NameOf(PostalCodeMaskedTextBox.Text), BindingSource, NameOf(_Company.PostalCode))
        '住所1
        Address1TextBox.DataBindings.Add(NameOf(Address1TextBox.Text), BindingSource, NameOf(_Company.Address1))
        '住所2
        Address2TextBox.DataBindings.Add(NameOf(Address2TextBox.Text), BindingSource, NameOf(_Company.Address2))
        'TEL
        TellMaskedTextBox.DataBindings.Add(NameOf(TellMaskedTextBox.Text), BindingSource, NameOf(_Company.TEL))
        'FAX
        FaxMaskedTextBox.DataBindings.Add(NameOf(FaxMaskedTextBox.Text), BindingSource, NameOf(_Company.FAX))

        '=============================================================================
        'エラープロバイダのデータソースにフォームを紐づけたバインディングソースを割り当て
        '=============================================================================
        Me.ErrorProvider.DataSource = BindingSource
    End Sub

#End Region

#Region "永続化"

    ''' <summary>
    ''' フォームの入力内容で登録処理を実行
    ''' </summary>
    ''' <returns>登録成功:True 登録失敗:False</returns>
    Private Function Save() As Boolean
        'ドメインオブジェクトの正当性を確認
        If _Company.Validate() = False Then
            'エラー情報を更新
            Me.ErrorProvider.UpdateBinding()
            Return False
        End If
        '登録
        Dim repo = New Infrastructure.CompanyInformationImpl
        If repo.Save(_Company) = False Then
            MessageBox.Show(SaveErrorMessage)
            Return False
        End If
        Return True
    End Function

#End Region


End Class