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
    Const PICDoNotEmpty As String = "営業担当者は必ず指定してください"
    Const PICIsNotFound As String = "未登録の従業員は利用できません"
    Const PaymentConditionDoNotEmpty As String = "支払条件は必ず指定してください"
    Const PaymentConditionIsNotFound As String = "未登録の支払条件は利用できません"

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
    Public ReadOnly _ID As Integer

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

    Private _PIC As Employee
    ''' <summary>
    ''' 窓口担当者名
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
        ValidatePIC()
        ValidatePaymentCondition()
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
        '登録済みの名前は利用できない
        If _CustomerRepo.FindByCustomerName(_Name) IsNot Nothing Then
            _errors(NameOf(Name)) = NameIsAlreadyExist
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

#End Region

End Class
