Option Strict On
Option Infer On

''' <summary>
''' 見積書レポート用のデータ転送用クラス
''' </summary>
Public Class EstimateReportPresenter

#Region "コンストラクタ"

    Public Sub New(ByVal estimate As Domain.Estimate)
        InitializeDefaultValue()
        InitializeByEstimate(estimate)

        '自社情報を取得
        Dim repo = New Infrastructure.CompanyInformationImpl
        Dim c = repo.Find

        InitializeByCompany(c)
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
    ''' 支払条件
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

#Region "プライベートメソッド"

    ''' <summary>
    ''' 各プロパティのデフォルト初期値を設定
    ''' </summary>
    Private Sub InitializeDefaultValue()
        _ReportName = "御見積書"
        _Honorific = "御中"
        _TitleLabel = "件名"
        _TotalPriceLabel = "御見積金額(税別)"
        _GreetingMessage = "御照会賜りました件、下記の通りお見積致しました。" & "ご検討の程、何卒よろしくお願い申し上げます。"
        _DueDateLabel = "納期"
        _PaymentConditionLabel = "支払条件"
        _EffectiveDateLabel = "見積有効期限"
        _RemarksLabel = "備考"
    End Sub

    ''' <summary>
    ''' 見積エンティティを利用して初期化
    ''' </summary>
    ''' <param name="e"></param>
    Private Sub InitializeByEstimate(ByVal e As Domain.Estimate)
        '見積番号
        _EstimateNo = e.EstimateNo
        '発行日
        _IssueDate = e.IssueDate.ToString("yyyy/MM/dd")
        '顧客名
        _CustomerName = e.Customer.Name
        '件名
        _Title = e.Title
        '御見積金額
        _TotalPrice = e.EstimatePrice.ToString("C")
        '納期
        _DueDate = e.DueDate.ToString("yyyy/MM/dd")
        '支払条件
        _PaymentCondition = e.PaymentCondition.Name
        '見積有効期限
        _EffectiveDate = e.EffectiveDate.ToString("yyyy/MM/dd")
        '備考
        _Remarks = e.Remarks
    End Sub

    ''' <summary>
    ''' 自社情報を利用して初期化
    ''' </summary>
    ''' <param name="c"></param>
    Private Sub InitializeByCompany(ByVal c As Domain.CompanyInformation)
        '会社名
        _CompanyName = c.Name
        '会社郵便番号
        _CompanyPostalCode = c.PostalCode
        '会社住所1
        _CompanyAddress1 = c.Address1
        '会社住所2
        _CompanyAddress2 = c.Address2
        'TEL
        _CompanyTEL = c.TEL
        'FAX
        _CompanyFAX = c.FAX
    End Sub

#End Region

End Class
