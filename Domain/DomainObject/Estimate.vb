Option Strict On
Option Infer On
Imports System.Collections.Generic
Imports System.ComponentModel

''' <summary>
''' 見積
''' </summary>
Public Class Estimate
    Implements IDataErrorInfo

#Region "定数"

    ''' <summary>
    ''' 見積の最大行数
    ''' </summary>
    Public Const MAX_ESTIMATE_DETAIL_SIZE As Integer = 20

    Const EstimateNoDoNotEmpty As String = "見積番号は必ず入力が必要です"
    Const EstimateNoIsTooLong As String = "見積番号は20文字以内で入力してください"
    Const CustomerDoNotNothing As String = "顧客は必ず入力が必要です"
    Const CustomerIsNotExist As String = "未登録の顧客です"
    Const TitleDoNotEmpty As String = "件名は必ず入力が必要です"
    Const TitleIsTooLong As String = "件名は50文字以内で入力してください"
    Const DueDateIsTooShort As String = "納期は作成日より前には設定できません"
    Const PaymentConditionDoNotEmpty As String = "支払条件は必ず入力してください"
    Const PaymentConditionIsNotExist As String = "未登録の支払条件です"
    Const PICEmployeeDoNotEmpty As String = "担当従業員は必ず入力してください"
    Const EffectiveDateIsTooShort As String = "見積有効期限は作成日より前には設定できません"
    Const SalesTaxDoNotEmpty As String = "消費税は必ず入力してください"
    Const SalesTaxIsNotExist As String = "未登録の消費税です"
    Const RemarksCantNothing As String = "備考をNothingには設定できません"
    Const RemarksIsTooLong As String = "備考は500文字以内で入力してください"
    Const PICEmployeeIsNotExist As String = "未登録の従業員です"


#End Region

#Region "リポジトリへのポインタ"

    Private _EstimateRepo As IEstimateRepository
    Private _CustomerRepo As ICustomerRepository
    Private _EmployeeRepo As IEmployeeRepository
    Private _PayRepo As IPaymentConditionRepository
    Private _TaxRepo As ISalesTaxRepository

#End Region

#Region "コンストラクタ"

    Public Sub New(ByVal estRepo As IEstimateRepository,
                   ByVal custRepo As ICustomerRepository,
                   ByVal payRepo As IPaymentConditionRepository,
                   ByVal empRepo As IEmployeeRepository,
                   ByVal taxRepo As ISalesTaxRepository)
        _ID = -1
        _EstimateRepo = estRepo
        _CustomerRepo = custRepo
        _PayRepo = payRepo
        _EmployeeRepo = empRepo
        _TaxRepo = taxRepo
        _EstimateNo = String.Empty
        _Customer = Nothing
        _Title = String.Empty
        _DueDate = Date.Today
        _PaymentCondition = Nothing
        _PICEmployee = Nothing
        _EffectiveDate = Date.Today
        _SalesTax = Nothing
        _IssueDate = Date.Today
        _Remarks = String.Empty
        _Details = New List(Of EstimateDetail)
    End Sub

    Public Sub New(ByVal id As Integer,
                   ByVal estRepo As IEstimateRepository,
                   ByVal custRepo As ICustomerRepository,
                   ByVal payRepo As IPaymentConditionRepository,
                   ByVal empRepo As IEmployeeRepository,
                   ByVal taxRepo As ISalesTaxRepository)
        _ID = id
        _EstimateRepo = estRepo
        _CustomerRepo = custRepo
        _PayRepo = payRepo
        _EmployeeRepo = empRepo
        _TaxRepo = taxRepo
        _EstimateNo = String.Empty
        _Customer = Nothing
        _Title = String.Empty
        _DueDate = Date.Today
        _PaymentCondition = Nothing
        _PICEmployee = Nothing
        _EffectiveDate = Date.Today
        _SalesTax = Nothing
        _IssueDate = Date.Today
        _Remarks = String.Empty
        _Details = New List(Of EstimateDetail)
    End Sub

#End Region

#Region "値プロパティ"

    ''' <summary>
    ''' ID(オブジェクトの永続化がされていないものは-1)
    ''' </summary>
    Public ReadOnly Property ID As Integer

    Private _EstimateNo As String
    ''' <summary>
    ''' 見積番号
    ''' </summary>
    ''' <returns></returns>
    Public Property EstimateNo As String
        Set(value As String)
            _EstimateNo = value
            ValidateEstimateNo()
        End Set
        Get
            Return _EstimateNo
        End Get
    End Property

    Private _Customer As Customer
    ''' <summary>
    ''' 顧客
    ''' </summary>
    ''' <returns></returns>
    Public Property Customer As Customer
        Get
            Return _Customer
        End Get
        Set(value As Customer)
            _Customer = value
            ValidateCustomer()
        End Set
    End Property

    Private _Title As String
    ''' <summary>
    ''' 件名
    ''' </summary>
    ''' <returns></returns>
    Public Property Title As String
        Get
            Return _Title
        End Get
        Set(value As String)
            _Title = value
            ValidateTitle()
        End Set
    End Property

    Private _DueDate As Date
    ''' <summary>
    ''' 納期
    ''' </summary>
    ''' <returns></returns>
    Public Property DueDate As Date
        Get
            Return _DueDate
        End Get
        Set(value As Date)
            _DueDate = value
            ValidateDueDate()
        End Set
    End Property

    Private _PaymentCondition As PaymentCondition
    ''' <summary>
    ''' 支払条件
    ''' </summary>
    ''' <returns></returns>
    Public Property PaymentCondition As PaymentCondition
        Get
            Return _PaymentCondition
        End Get
        Set(value As PaymentCondition)
            _PaymentCondition = value
            ValidatePaymentCondition()
        End Set
    End Property

    Private _PICEmployee As Employee
    ''' <summary>
    ''' 発行担当従業員
    ''' </summary>
    ''' <returns></returns>
    Public Property PICEmployee As Employee
        Get
            Return _PICEmployee
        End Get
        Set(value As Employee)
            _PICEmployee = value
            ValidatePICEmployee()
        End Set
    End Property

    Private _EffectiveDate As Date
    ''' <summary>
    ''' 見積有効期限
    ''' </summary>
    ''' <returns></returns>
    Public Property EffectiveDate As Date
        Get
            Return _EffectiveDate
        End Get
        Set(value As Date)
            _EffectiveDate = value
            ValidateEffectiveDate()
        End Set
    End Property

    Private _SalesTax As SalesTax
    ''' <summary>
    ''' 消費税
    ''' </summary>
    ''' <returns></returns>
    Public Property SalesTax As SalesTax
        Get
            Return _SalesTax
        End Get
        Set(value As SalesTax)
            _SalesTax = value
            ValidateSalesTax()
        End Set
    End Property

    Private _IssueDate As Date
    ''' <summary>
    ''' 作成日
    ''' </summary>
    ''' <returns></returns>
    Public Property IssueDate As Date
        Get
            Return _IssueDate
        End Get
        Set(value As Date)
            _IssueDate = value
            ValidateIssueDate()
            GetTaxByIssueDate()
        End Set
    End Property

    Private _Remarks As String
    ''' <summary>
    ''' 備考
    ''' </summary>
    ''' <returns></returns>
    Public Property Remarks As String
        Get
            Return _Remarks
        End Get
        Set(value As String)
            _Remarks = value
            ValidateRemarks()
        End Set
    End Property

    ''' <summary>
    ''' 見積金額
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property EstimatePrice As Decimal
        Get
            Dim sum As Decimal = 0
            For Each d In _Details
                sum += d.UnitPrice * d.Quantity
            Next
            Return sum
        End Get
    End Property

    ''' <summary>
    ''' 見積金額(税込)
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property EstimatePriceIncludeTax As Decimal
        Get
            Dim sum As Decimal = 0
            For Each d In _Details
                sum += d.UnitPrice * d.Quantity
            Next
            If _SalesTax Is Nothing Then
                Return sum
            End If
            Dim rate = _SalesTax.TaxRate
            Return sum + (sum * rate)
        End Get
    End Property

    Private _Details As List(Of EstimateDetail)
    ''' <summary>
    ''' 明細
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Details As List(Of EstimateDetail)
        Get
            _Details.Sort(Function(a, b) a.DisplayOrder - b.DisplayOrder)
            Return _Details
        End Get
    End Property

    ''' <summary>
    ''' 明細に新しい行を追加する
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    Public Function AddDetail(ByVal d As EstimateDetail) As Boolean
        '最大件数に達していたら失敗
        If _Details.Count >= MAX_ESTIMATE_DETAIL_SIZE Then
            Return False
        End If
        Dim max_display_order = 0
        For Each item As EstimateDetail In _Details
            If item.DisplayOrder > max_display_order Then
                max_display_order = item.DisplayOrder
            End If
        Next
        d.DisplayOrder = max_display_order + 1
        _Details.Add(d)

        Return True
    End Function

    ''' <summary>
    ''' 指定した表示順の明細を削除する
    ''' </summary>
    ''' <returns></returns>
    Public Function RemoveDetail(ByVal display_order As Integer) As Boolean
        Try
            Dim idx = _Details.FindIndex(Function(x) x.DisplayOrder = display_order)
            _Details.RemoveAt(idx)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' 明細の表示順を1つ上にする
    ''' </summary>
    ''' <param name="display_order"></param>
    ''' <returns></returns>
    Public Function UpToDisplayOrder(ByVal display_order As Integer) As Integer
        Dim min = MAX_ESTIMATE_DETAIL_SIZE + 1
        For Each d In _Details
            If d.DisplayOrder < min Then
                min = d.DisplayOrder
            End If
        Next

        If display_order - 1 < min Then
            Return -1
        End If

        Dim dest = _Details.Find(Function(x) x.DisplayOrder = (display_order - 1))
        Dim src = _Details.Find(Function(x) x.DisplayOrder = display_order)

        dest.DisplayOrder = display_order
        src.DisplayOrder = display_order - 1

        Return src.DisplayOrder
    End Function

    ''' <summary>
    ''' 明細の表示順を1つ下にする
    ''' </summary>
    ''' <param name="display_order"></param>
    ''' <returns></returns>
    Public Function DownToDisplayOrder(ByVal display_order As Integer) As Integer
        Dim max = 0
        For Each d In _Details
            If max < d.DisplayOrder Then
                max = d.DisplayOrder
            End If
        Next

        If display_order + 1 > max Then
            Return -1
        End If

        Dim dest = _Details.Find(Function(x) x.DisplayOrder = (display_order + 1))
        Dim src = _Details.Find(Function(x) x.DisplayOrder = display_order)

        dest.DisplayOrder = display_order
        src.DisplayOrder = display_order + 1

        Return src.DisplayOrder
    End Function

#End Region

#Region "エラープロパティ"

    ''' <summary>
    ''' エラー保持変数
    ''' </summary>
    Private _errors As New Dictionary(Of String, String)

    ''' <summary>
    ''' このオブジェクトの状態にエラーがあればTrue
    ''' </summary>
    ''' <returns></returns>
    Public Function HasError() As Boolean
        For Each d As EstimateDetail In _Details
            If d.HasError = True Then
                Return True
            End If
        Next
        Return _errors.Count <> 0
    End Function

    ''' <summary>
    ''' 指定プロパティにエラーがあればメッセージを返す
    ''' </summary>
    ''' <param name="columnName"></param>
    ''' <returns></returns>
    Default Public ReadOnly Property Item(columnName As String) As String Implements IDataErrorInfo.Item
        Get
            If _errors.ContainsKey(columnName) = False Then
                Return String.Empty
            End If
            Return _errors(columnName)
        End Get
    End Property

    ''' <summary>
    ''' このオブジェクト全体で整合性を保てていないエラーがあればメッセージを返す
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property [Error] As String Implements IDataErrorInfo.Error
        Get
            Return String.Empty
        End Get
    End Property

#End Region

#Region "検証メソッド"

    ''' <summary>
    ''' オブジェクトの整合性チェックを実施
    ''' </summary>
    ''' <returns></returns>
    Public Function Validate() As Boolean
        ValidateEstimateNo()
        ValidateCustomer()
        ValidateTitle()
        ValidatePaymentCondition()
        ValidateDueDate()
        ValidatePICEmployee()
        ValidateEffectiveDate()
        ValidateSalesTax()
        ValidateIssueDate()
        ValidateRemarks()
        ValidateDetails()

        '永続化も含めた項目全体の整合性チェックを実施
        'エラーリストのクリアのため他の要素の後に実施しないとならない
        ValidateTotalItems()

        Return Me.HasError = False
    End Function

    ''' <summary>
    ''' 永続化も含めた要素全体の整合性チェックを実施
    ''' </summary>
    Private Sub ValidateTotalItems()
        'ほかのチェックに引っかかってたらDBアクセス前に例外発生があり得るので戻してやる
        If Me.HasError = True Then
            Return
        End If

        '顧客は登録済みでなければならない
        If _CustomerRepo.FindByID(_Customer.ID) Is Nothing Then
            Me._errors(NameOf(Customer)) = CustomerIsNotExist
        End If

        '支払条件は登録済みでなければならない
        If _PayRepo.FindByID(_PaymentCondition.ID) Is Nothing Then
            Me._errors(NameOf(PaymentCondition)) = PaymentConditionIsNotExist
        End If

        '消費税は登録済みでなければならない
        If _TaxRepo.FindByApplyDate(_SalesTax.ApplyStartDate) Is Nothing Then
            Me._errors(NameOf(SalesTax)) = SalesTaxIsNotExist
        End If

        '担当従業員は登録済みでなければならない
        If _EmployeeRepo.FindByID(_PICEmployee.ID) Is Nothing Then
            Me._errors(NameOf(PICEmployee)) = PICEmployeeIsNotExist
        End If

    End Sub

    ''' <summary>
    ''' 見積番号を検証
    ''' </summary>
    Private Sub ValidateEstimateNo()
        '一度エラーをクリア
        _errors.Remove(NameOf(EstimateNo))

        '新規の見積の場合は永続化時に採番するのでチェックしない
        If ID = -1 Then
            Return
        End If

        '見積番号はNothing不可
        If _EstimateNo Is Nothing Then
            _errors(NameOf(EstimateNo)) = EstimateNoDoNotEmpty
            Return
        End If

        '見積番号は未指定ではいけない
        If _EstimateNo = String.Empty Then
            _errors(NameOf(EstimateNo)) = EstimateNoDoNotEmpty
        End If

        '見積番号は20文字以内でなければならない
        If _EstimateNo.Length > 20 Then
            _errors(NameOf(EstimateNo)) = EstimateNoIsTooLong
        End If
    End Sub

    ''' <summary>
    ''' 顧客を検証
    ''' </summary>
    Private Sub ValidateCustomer()
        '一度エラーをクリア
        _errors.Remove(NameOf(Customer))

        '顧客はNothing不可
        If _Customer Is Nothing Then
            _errors(NameOf(Customer)) = CustomerDoNotNothing
            Return
        End If

    End Sub

    ''' <summary>
    ''' 件名を検証
    ''' </summary>
    Private Sub ValidateTitle()
        '一度エラーをクリア
        _errors.Remove(NameOf(Title))

        '件名はNothing不可
        If _Title Is Nothing Then
            _errors(NameOf(Title)) = TitleDoNotEmpty
            Return
        End If

        '件名は未指定ではいけない
        If _Title = String.Empty Then
            _errors(NameOf(Title)) = TitleDoNotEmpty
        End If

        '件名は50文字以内でなければならない
        If _Title.Length > 50 Then
            _errors(NameOf(Title)) = TitleIsTooLong
        End If
    End Sub

    ''' <summary>
    ''' 納期を検証
    ''' </summary>
    Private Sub ValidateDueDate()
        '一度エラーをクリア
        _errors.Remove(NameOf(DueDate))

        '納期は作成日より前ではならない
        If _DueDate < _IssueDate Then
            _errors(NameOf(DueDate)) = DueDateIsTooShort
        End If
    End Sub

    ''' <summary>
    ''' 支払条件を検証
    ''' </summary>
    Private Sub ValidatePaymentCondition()
        '一度エラーをクリア
        _errors.Remove(NameOf(PaymentCondition))

        '未指定は許可しない
        If _PaymentCondition Is Nothing Then
            _errors(NameOf(PaymentCondition)) = PaymentConditionDoNotEmpty
        End If
    End Sub

    ''' <summary>
    ''' 担当従業員の検証
    ''' </summary>
    Private Sub ValidatePICEmployee()
        '一度エラーをクリア
        _errors.Remove(NameOf(PICEmployee))

        '未指定は許可しない
        If _PICEmployee Is Nothing Then
            _errors(NameOf(PICEmployee)) = PICEmployeeDoNotEmpty
        End If
    End Sub

    ''' <summary>
    ''' 見積有効期限を検証
    ''' </summary>
    Private Sub ValidateEffectiveDate()
        '一度エラーをクリア
        _errors.Remove(NameOf(EffectiveDate))

        '作成日より前は指定できない
        If _EffectiveDate < _IssueDate Then
            _errors(NameOf(EffectiveDate)) = EffectiveDateIsTooShort
        End If
    End Sub

    ''' <summary>
    ''' 消費税を検証
    ''' </summary>
    Private Sub ValidateSalesTax()
        '一度エラーをクリア
        _errors.Remove(NameOf(SalesTax))

        '未指定は許可しない
        If _SalesTax Is Nothing Then
            _errors(NameOf(SalesTax)) = SalesTaxDoNotEmpty
        End If
    End Sub

    ''' <summary>
    ''' 作成日を検証
    ''' </summary>
    Private Sub ValidateIssueDate()
        '一度エラーをクリア
        _errors.Remove(NameOf(IssueDate))
    End Sub

    ''' <summary>
    ''' 備考を検証
    ''' </summary>
    Private Sub ValidateRemarks()
        '一度エラーをクリア
        _errors.Remove(NameOf(Remarks))

        '件名はNothing不可
        If _Remarks Is Nothing Then
            _errors(NameOf(Remarks)) = RemarksCantNothing
            Return
        End If

        '件名は500文字以内でなければならない
        If _Remarks.Length > 500 Then
            _errors(NameOf(Remarks)) = RemarksIsTooLong
        End If
    End Sub

    ''' <summary>
    ''' 明細を検証
    ''' </summary>
    Private Sub ValidateDetails()
        For Each d As EstimateDetail In _Details
            d.Validate()
        Next
    End Sub

#End Region

#Region "CRUD"

    ''' <summary>
    ''' このオブジェクトを永続化する
    ''' </summary>
    ''' <returns>登録成功:True 登録失敗:False</returns>
    Public Function Save() As Boolean
        '新規作成の場合は見積番号を採番
        If ID = -1 Then
            _EstimateNo = CreateEstimateNo()
        End If

        '保存
        If _EstimateRepo.Save(Me) = False Then
            Return False
        End If

        'IDを入れておく
        _ID = _EstimateRepo.LastInsertID
        Return True
    End Function

    ''' <summary>
    ''' 見積番号を採番する
    ''' </summary>
    ''' <returns></returns>
    Private Function CreateEstimateNo() As String
        Dim tday = Date.Today
        '今日の日付(yyyyMMdd) + その日に作られた見積全体での連番3桁(001)
        Dim c = _EstimateRepo.CountEstimateOnDay(tday) + 1
        Return tday.ToString("yyyyMMdd") & c.ToString("000")
    End Function

    ''' <summary>
    ''' 発行日から消費税率を設定する
    ''' </summary>
    ''' <returns></returns>
    Private Sub GetTaxByIssueDate()
        Dim tax = _TaxRepo.TaxOn(_IssueDate)
        _SalesTax = tax
    End Sub

#End Region

End Class
