Option Strict On
Option Infer On

''' <summary>
''' 見積書レポート用のデータ転送用クラス
''' </summary>
Public Class ReportDataPresenter

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    Public Sub New()
        InitializeDefaultValue()
    End Sub

    Public Sub New(ByVal estimate As Domain.Estimate)
        InitializeDefaultValue()
    End Sub

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 表題
    ''' </summary>
    ''' <returns></returns>
    Public Property ReportNameTextBox As String

#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' 各プロパティのデフォルト初期値を設定
    ''' </summary>
    Private Sub InitializeDefaultValue()
        _ReportNameTextBox = "御見積書"

    End Sub

#End Region

End Class
