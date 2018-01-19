Option Strict On
Option Infer On
Imports System.Collections.Generic
Imports System.ComponentModel

''' <summary>
''' 消費税率を表す
''' </summary>
Public Class SalesTax
    Implements IDataErrorInfo

#Region "定数"

    Private Const ApplyStartDateDoNotDuplicate As String = "適用開始日は重複して登録できません"
    Private Const TaxRateOutOfRange As String = "消費税率は0%から100%の間しか指定できません"

#End Region

#Region "インスタンス変数"

    Private _repo As ISalesTaxRepository

#End Region

#Region "コンストラクタ"

    Public Sub New(ByVal repo As ISalesTaxRepository)
        _ID = -1
        _ApplyStartDate = Date.Today
        _TaxRate = CDec(0.00)
        _repo = repo
    End Sub

    Public Sub New(ByVal id As Integer, ByVal repo As ISalesTaxRepository)
        _ID = id
        _ApplyStartDate = Date.Today
        _TaxRate = CDec(0.00)
        _repo = repo
    End Sub

#End Region

#Region "値プロパティ"

    ''' <summary>
    ''' ID(オブジェクトの永続化がされていないものは-1)
    ''' </summary>
    Public ReadOnly Property ID As Integer

    Private _ApplyStartDate As Date
    ''' <summary>
    ''' 適用開始日
    ''' </summary>
    ''' <returns></returns>
    Public Property ApplyStartDate As Date
        Get
            Return _ApplyStartDate
        End Get
        Set(value As Date)
            _ApplyStartDate = value
            ValidateApplyStartDate()
        End Set
    End Property

    Private _TaxRate As Decimal
    ''' <summary>
    ''' 消費税率
    ''' </summary>
    ''' <returns></returns>
    Public Property TaxRate As Decimal
        Get
            Return _TaxRate
        End Get
        Set(value As Decimal)
            _TaxRate = value
            ValidateTaxRate()
        End Set
    End Property

    ''' <summary>
    ''' パーセント指定の消費税率
    ''' </summary>
    ''' <returns></returns>
    Public Property TaxRateOfPercentage As Decimal
        Get
            Return _TaxRate * CDec(100.0)
        End Get
        Set(value As Decimal)
            _TaxRate = value / CDec(100.0)
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
        ValidateApplyStartDate()
        ValidateTaxRate()
        ValidaateTotal()

        Return Me.HasError = False
    End Function

    ''' <summary>
    ''' 適用開始日の検証
    ''' </summary>
    Private Sub ValidateApplyStartDate()
        '今はチェックがないのでエラーをクリアするだけ
        _errors.Remove(NameOf(ApplyStartDate))
    End Sub

    ''' <summary>
    ''' 消費税率の検証
    ''' </summary>
    Private Sub ValidateTaxRate()
        'エラーを一度クリア
        _errors.Remove(NameOf(TaxRate))

        '消費税率は0～100%までしか指定できない
        If _TaxRate < 0.0 OrElse 1.0 < _TaxRate Then
            _errors(NameOf(TaxRate)) = TaxRateOutOfRange
        End If
    End Sub

    ''' <summary>
    ''' オブジェクト全体での整合性検証
    ''' </summary>
    Private Sub ValidaateTotal()
        '登録済みの日付は重複して登録できない
        Dim tax = _repo.FindByApplyDate(_ApplyStartDate)
        If tax IsNot Nothing AndAlso tax.ID <> _ID Then
            _errors(NameOf(ApplyStartDate)) = ApplyStartDateDoNotDuplicate
        End If
    End Sub

#End Region

End Class
