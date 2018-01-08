Option Strict On
Option Infer On

Imports System.Collections.Generic
Imports System.ComponentModel

''' <summary>
''' 顧客1社を表現する
''' </summary>
Public Class Customer
    Implements IDataErrorInfo

#Region "定数"

    Const NameDoNotEmpty As String = "顧客名は必ず入力が必要です"
    Const NameIsAlreadyExist As String = "この顧客名は既に登録済みです"
    Const NameIsTooLong As String = "顧客名は50文字以内での入力が必要です"
    Const KanaNameDoNotEmpty As String = "顧客名かなは必ず入力が必要です"
    Const KanaNameIsTooLong As String = "顧客名かなは50文字以内での入力が必要です"
    Const PICDoNotEmpty As String = "営業担当者は必ず指定してください"
    Const PICIsNotFound As String = "未登録の従業員は利用できません"
    Const PaymentConditionDoNotEmpty As String = "支払条件は必ず指定してください"
    Const PaymentConditionIsNotFound As String = "未登録の支払条件は利用できません"
    Const PostalCodeDoNotNothing As String = "郵便番号の入力内容が不正です"
    Const PostalCodeLengthMustBeSeven As String = "郵便番号は7桁で入力してください"
    Const Address1IsTooLong As String = "住所1は50文字以内で入力してください"
    Const Address1DoNotEmpty As String = "住所1は必ず入力してください"
    Const Address2DoNotNothing As String = "住所2の入力内容が不正です"
    Const Address2IsTooLong As String = "住所2は50文字以内で入力してください"

#End Region

#Region "リポジトリへのポインタ"

    Private _CustomerRepo As ICustomerRepository
    Private _PaymentConditionRepo As IPaymentConditionRepository
    Private _EmployeeRepo As IEmployeeRepository

#End Region

#Region "コンストラクタ"

    Public Sub New(ByVal custRepo As ICustomerRepository, ByVal payRepo As IPaymentConditionRepository, ByVal empRepo As IEmployeeRepository)
        _ID = -1
        _CustomerRepo = custRepo
        _PaymentConditionRepo = payRepo
        _EmployeeRepo = empRepo
        _Name = String.Empty
        _PIC = Nothing
        _PaymentCondition = Nothing
    End Sub

    Public Sub New(ByVal id As Integer, ByVal custRepo As ICustomerRepository, ByVal payRepo As IPaymentConditionRepository, ByVal empRepo As IEmployeeRepository)
        _ID = id
        _CustomerRepo = custRepo
        _PaymentConditionRepo = payRepo
        _EmployeeRepo = empRepo
        _Name = String.Empty
        _PIC = Nothing
        _PaymentCondition = Nothing
    End Sub

#End Region

#Region "値プロパティ"

    ''' <summary>
    ''' ID(オブジェクトの永続化がされていないものは-1)
    ''' </summary>
    Public ReadOnly Property ID As Integer

    Private _Name As String
    ''' <summary>
    ''' 顧客名
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String
        Set(value As String)
            _Name = value
            ValidateName()
        End Set
        Get
            Return _Name
        End Get
    End Property

    Private _KanaName As String
    ''' <summary>
    ''' 顧客名かな
    ''' </summary>
    ''' <returns></returns>
    Public Property KanaName As String
        Get
            Return _KanaName
        End Get
        Set(value As String)
            _KanaName = value
            ValidateKanaName()
        End Set
    End Property

    Private _PIC As Employee
    ''' <summary>
    ''' 営業担当者
    ''' </summary>
    ''' <returns></returns>
    Public Property PIC As Employee
        Get
            Return _PIC
        End Get
        Set(value As Employee)
            _PIC = value
            ValidatePIC()
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

    Private _PostalCode As String
    ''' <summary>
    ''' 郵便番号
    ''' </summary>
    ''' <returns></returns>
    Public Property PostalCode As String
        Get
            Return _PostalCode
        End Get
        Set(value As String)
            _PostalCode = value
            ValidatePostalCode()
        End Set
    End Property

    Private _Address1 As String
    ''' <summary>
    ''' 住所1
    ''' </summary>
    ''' <returns></returns>
    Public Property Address1 As String
        Get
            Return _Address1
        End Get
        Set(value As String)
            _Address1 = value
            ValidateAddress1()
        End Set
    End Property

    Private _Address2 As String
    ''' <summary>
    ''' 住所2
    ''' </summary>
    ''' <returns></returns>
    Public Property Address2 As String
        Get
            Return _Address2
        End Get
        Set(value As String)
            _Address2 = value
            ValidateAddress2()
        End Set
    End Property


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
        ValidateName()
        ValidateKanaName()
        ValidatePIC()
        ValidatePaymentCondition()
        ValidatePostalCode()
        ValidateAddress1()
        ValidateAddress2()
        Return Me.HasError
    End Function

    ''' <summary>
    ''' 顧客名を検証
    ''' </summary>
    Private Sub ValidateName()
        '一度エラーをクリア
        _errors.Remove(NameOf(Name))

        '名前は未指定ではいけない
        If _Name = String.Empty Then
            _errors(NameOf(Name)) = NameDoNotEmpty
        End If
        '名前は50文字以内でなければならない
        If _Name.Length > 50 Then
            _errors(NameOf(Name)) = NameIsTooLong
        End If
        '同一社名が同じ住所で登録済みの場合は利用できない
        If _CustomerRepo.FindByCustomerNameAndAddress(_Name, _Address1, _Address2) IsNot Nothing Then
            _errors(NameOf(Name)) = NameIsAlreadyExist
        End If
    End Sub

    ''' <summary>
    ''' 顧客名かなを検証
    ''' </summary>
    Private Sub ValidateKanaName()
        '一度エラーをクリア
        _errors.Remove(NameOf(KanaName))

        'かな名は未指定ではいけない
        If _KanaName = String.Empty Then
            _errors(NameOf(KanaName)) = KanaNameDoNotEmpty
        End If
        'かな名は50文字以内でなければならない
        If _KanaName.Length > 50 Then
            _errors(NameOf(KanaName)) = KanaNameIsTooLong
        End If
    End Sub

    ''' <summary>
    ''' 営業担当者名を検証
    ''' </summary>
    Private Sub ValidatePIC()
        '一度エラーをクリア
        _errors.Remove(NameOf(PIC))

        '営業担当者名は必ず入力しなければならない
        If _PIC Is Nothing Then
            _errors(NameOf(PIC)) = PICDoNotEmpty
        End If
        '未登録の従業員は指定できない
        If _EmployeeRepo.FindByID(_PIC.ID) Is Nothing Then
            _errors(NameOf(PIC)) = PICIsNotFound
        End If
    End Sub

    ''' <summary>
    ''' 支払条件を検証
    ''' </summary>
    Private Sub ValidatePaymentCondition()
        '一度エラーをクリア
        _errors.Remove(NameOf(PaymentCondition))

        '支払条件は未指定ではならない
        If _PaymentCondition Is Nothing Then
            _errors(NameOf(PaymentCondition)) = PaymentConditionDoNotEmpty
        End If
        '登録されていない支払条件は利用できない
        If _PaymentConditionRepo.FindByID(_PaymentCondition.ID) Is Nothing Then
            _errors(NameOf(PaymentCondition)) = PaymentConditionIsNotFound
        End If
    End Sub

    ''' <summary>
    ''' 郵便番号を検証
    ''' </summary>
    Private Sub ValidatePostalCode()
        '一度エラーをクリア
        _errors.Remove(NameOf(PostalCode))

        'Nothingは許可しない
        If _PostalCode Is Nothing Then
            _errors(NameOf(PostalCode)) = PostalCodeDoNotNothing
        End If

        '郵便番号は未入力可
        If _PostalCode = String.Empty Then
            Return
        End If

        '郵便番号は必ず7桁
        If _PostalCode.Length <> 7 Then
            _errors(NameOf(PostalCode)) = PostalCodeLengthMustBeSeven
        End If
    End Sub

    ''' <summary>
    ''' 住所1を検証
    ''' </summary>
    Private Sub ValidateAddress1()
        '一度エラーをクリア
        _errors.Remove(NameOf(Address1))

        '住所1は必ず入力
        If _Address1 Is Nothing OrElse _Address1.Length = 0 Then
            _errors(NameOf(Address1)) = Address1DoNotEmpty
        End If

        '住所1は必ず50文字以内
        If _Address1.Length > 50 Then
            _errors(NameOf(_Address1)) = Address1IsTooLong
        End If

        '同一社名が同じ住所で登録済みの場合は利用できない
        If _CustomerRepo.FindByCustomerNameAndAddress(_Name, _Address1, _Address2) IsNot Nothing Then
            _errors(NameOf(Name)) = NameIsAlreadyExist
        End If

    End Sub

    ''' <summary>
    ''' 住所2を検証
    ''' </summary>
    Private Sub ValidateAddress2()
        '一度エラーをクリア
        _errors.Remove(NameOf(Address2))

        'Nothingは許可しない
        If _Address2 Is Nothing Then
            _errors(NameOf(Address2)) = Address2DoNotNothing
        End If

        '住所2は必ず50文字以内
        If _Address2.Length > 50 Then
            _errors(NameOf(_Address2)) = Address2IsTooLong
        End If

        '同一社名が同じ住所で登録済みの場合は利用できない
        If _CustomerRepo.FindByCustomerNameAndAddress(_Name, _Address1, _Address2) IsNot Nothing Then
            _errors(NameOf(Name)) = NameIsAlreadyExist
        End If

    End Sub

#End Region

#Region "CRUD"

    ''' <summary>
    ''' このオブジェクトを永続化する
    ''' </summary>
    ''' <returns>登録成功:True 登録失敗:False</returns>
    Public Function Save() As Boolean
        If _CustomerRepo.Save(Me) = False Then
            Return False
        End If
        _ID = _CustomerRepo.LastInsertID
        Return True
    End Function

#End Region


End Class
