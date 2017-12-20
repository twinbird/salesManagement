Option Strict On
Option Infer On

''' <summary>
''' 顧客登録画面
''' </summary>
Public Class CustomerEntry

#Region "インスタンス変数"

    Private _customer As SalesManagementDomain.Customer

#End Region

#Region "イベント"

    ''' <summary>
    ''' 登録フォームロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CustomerEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        'ドメインオブジェクトをインスタンス化してフォームコントロールにバインディング
        _customer = New SalesManagementDomain.Customer
        CustomerInfoBindingSource.DataSource = _customer

        '各コントロールとバインディングオブジェクトを紐づけ
        CustomerNameTextBox.DataBindings.Add(NameOf(Text), CustomerInfoBindingSource, NameOf(_customer.Name))

        'エラープロバイダのデータソースにフォームを紐づけたバインディングソースを割り当て
        CustomerInfoErrorProvider.DataSource = CustomerInfoBindingSource
    End Sub

    ''' <summary>
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EntryButton_Click(sender As Object, e As EventArgs) Handles EntryButton.Click
        'ドメインオブジェクトの正当性を確認
        If _customer.Validate() = False Then
            MessageBox.Show("OK")
        End If
        'エラー情報を更新
        CustomerInfoErrorProvider.UpdateBinding()
    End Sub

#End Region



End Class
