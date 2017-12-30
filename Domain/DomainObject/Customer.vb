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
    Const NameIsTooLong As String = "顧客名は50文字以内での入力が必要です"
    Const PICIsTooLong As String = "窓口担当者名は50文字以内での入力が必要です"
    Const PaymentConditionIsTooLong As String = "支払条件は50文字以内での入力が必要です"

#End Region

#Region "インスタンス変数"

    ''' <summary>
    ''' エラー保持変数
    ''' </summary>
    Private _errors As New Dictionary(Of String, String)

#End Region

#Region "コンストラクタ"

    Public Sub New()
        Me._Name = String.Empty
        Me._PIC = String.Empty
        Me._PaymentCondition = String.Empty
    End Sub

#End Region

#Region "値プロパティ"

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

    Private _PIC As String
    ''' <summary>
    ''' 窓口担当者名
    ''' </summary>
    ''' <returns></returns>
    Public Property PIC As String
        Get
            Return _PIC
        End Get
        Set(value As String)
            _PIC = value
            ValidatePIC()
        End Set
    End Property

    Private _PaymentCondition As String
    ''' <summary>
    ''' 支払条件
    ''' </summary>
    ''' <returns></returns>
    Public Property PaymentCondition As String
        Get
            Return _PaymentCondition
        End Get
        Set(value As String)
            _PaymentCondition = value
            ValidatePaymentCondition()
        End Set
    End Property

#End Region

#Region "エラープロパティ"

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

        '名前は空白ではいけない
        If _Name = String.Empty Then
            _errors(NameOf(Name)) = NameDoNotEmpty
        End If
        '名前は50文字以内でなければならない
        If _Name.Length > 50 Then
            _errors(NameOf(Name)) = NameIsTooLong
        End If
    End Sub

    ''' <summary>
    ''' 窓口担当者名を検証
    ''' </summary>
    Private Sub ValidatePIC()
        '一度エラーをクリア
        _errors.Remove(NameOf(PIC))

        '窓口担当者名は50文字以内でなければならない
        If _PIC.Length > 50 Then
            _errors(NameOf(PIC)) = PICIsTooLong
        End If
    End Sub

    ''' <summary>
    ''' 支払条件を検証
    ''' </summary>
    Private Sub ValidatePaymentCondition()
        '一度エラーをクリア
        _errors.Remove(NameOf(PaymentCondition))

        '支払条件は50文字以内でなければならない
        If _PaymentCondition.Length > 50 Then
            _errors(NameOf(PaymentCondition)) = PaymentConditionIsTooLong
        End If
    End Sub

#End Region

End Class
