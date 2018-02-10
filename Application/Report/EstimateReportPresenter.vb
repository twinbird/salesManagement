Option Strict On
Option Infer On

''' <summary>
''' 見積書レポート用のデータ転送用クラス
''' </summary>
Public Class EstimateReportPresenter

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
    Public Property ReportName As String

    ''' <summary>
    ''' 見積番号
    ''' </summary>
    ''' <returns></returns>
    Public Property EstimateNo As String

    ''' <summary>
    ''' 発行日
    ''' </summary>
    ''' <returns></returns>
    Public Property IssueDate As String

    ''' <summary>
    ''' 顧客名
    ''' </summary>
    ''' <returns></returns>
    Public Property CustomerName As String

    ''' <summary>
    ''' 顧客名の敬称
    ''' </summary>
    ''' <returns></returns>
    Public Property Honorific As String

    ''' <summary>
    ''' 件名(表題)
    ''' </summary>
    ''' <returns></returns>
    Public Property TitleLabel As String

    ''' <summary>
    ''' 件名
    ''' </summary>
    ''' <returns></returns>
    Public Property Title As String

    ''' <summary>
    ''' 御見積金額(表題)
    ''' </summary>
    ''' <returns></returns>
    Public Property TotalPriceLabel As String

    ''' <summary>
    ''' 御見積金額
    ''' </summary>
    ''' <returns></returns>
    Public Property TotalPrice As String

    ''' <summary>
    ''' あいさつ文
    ''' </summary>
    ''' <returns></returns>
    Public Property GreetingMessage As String

    ''' <summary>
    ''' 納期(表題)
    ''' </summary>
    ''' <returns></returns>
    Public Property DueDateLabel As String

    ''' <summary>
    ''' 納期
    ''' </summary>
    ''' <returns></returns>
    Public Property DueDate As String

    ''' <summary>
    ''' 支払条件(表題)
    ''' </summary>
    ''' <returns></returns>
    Public Property PaymentConditionLabel As String

    ''' <summary>
    ''' 見積条件
    ''' </summary>
    ''' <returns></returns>
    Public Property PaymentCondition As String

    ''' <summary>
    ''' 見積有効期限(表題)
    ''' </summary>
    ''' <returns></returns>
    Public Property EffectiveDateLabel As String

    ''' <summary>
    ''' 見積有効期限
    ''' </summary>
    ''' <returns></returns>
    Public Property EffectiveDate As String

    ''' <summary>
    ''' 会社名
    ''' </summary>
    ''' <returns></returns>
    Public Property CompanyName As String

    ''' <summary>
    ''' 会社郵便番号
    ''' </summary>
    ''' <returns></returns>
    Public Property CompanyPostalCode As String

    ''' <summary>
    ''' 会社住所1
    ''' </summary>
    ''' <returns></returns>
    Public Property CompanyAddress1 As String

    ''' <summary>
    ''' 会社住所2
    ''' </summary>
    ''' <returns></returns>
    Public Property CompanyAddress2 As String

    ''' <summary>
    ''' 会社TEL
    ''' </summary>
    ''' <returns></returns>
    Public Property CompanyTEL As String

    ''' <summary>
    ''' 会社FAX
    ''' </summary>
    ''' <returns></returns>
    Public Property CompanyFAX As String

    ''' <summary>
    ''' 備考(表題)
    ''' </summary>
    ''' <returns></returns>
    Public Property RemarksLabel As String

    ''' <summary>
    ''' 備考
    ''' </summary>
    ''' <returns></returns>
    Public Property Remarks As String

    ''' <summary>
    ''' 明細
    ''' </summary>
    ''' <returns></returns>
    Public Property Details As List(Of EstimateDetailReportPresenter)

#End Region

#Region "明細用のクラス"

    ''' <summary>
    ''' 見積書レポート用(明細)のデータ転送用クラス
    ''' </summary>
    Public Class EstimateDetailReportPresenter

        ''' <summary>
        ''' 項番
        ''' </summary>
        ''' <returns></returns>
        Public Property DisplayNo As String

        ''' <summary>
        ''' 品名
        ''' </summary>
        ''' <returns></returns>
        Public Property ItemName As String

        ''' <summary>
        ''' 数量
        ''' </summary>
        ''' <returns></returns>
        Public Property Quantity As String

        ''' <summary>
        ''' 単価
        ''' </summary>
        ''' <returns></returns>
        Public Property UnitPrice As String

        ''' <summary>
        ''' 金額
        ''' </summary>
        ''' <returns></returns>
        Public Property Price As String

    End Class

#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' 各プロパティのデフォルト初期値を設定
    ''' </summary>
    Private Sub InitializeDefaultValue()
        _ReportName = "御見積書"
        _Honorific = "御中"
        _TitleLabel = "件名"
        _TotalPriceLabel = "御見積金額"
        _GreetingMessage = "御照会賜りました件、下記の通りお見積致しました。" & "ご検討の程、何卒よろしくお願い申し上げます。"
        _DueDateLabel = "納期"
        _PaymentConditionLabel = "支払条件"
        _EffectiveDateLabel = "見積有効期限"
        _RemarksLabel = "備考"
    End Sub

#End Region

End Class
