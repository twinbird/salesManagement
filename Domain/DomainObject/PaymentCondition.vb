Option Strict On
Option Infer On

Imports System.Collections.Generic
Imports System.ComponentModel

''' <summary>
''' 支払条件1種類を表現する
''' </summary>
Public Class PaymentCondition
    Implements IDataErrorInfo

#Region "メッセージ定数"

    Const NameIsNotNullOrEmpty As String = "支払条件名は必ず入力しなければなりません"
    Const NameIsTooLong As String = "支払条件名は20文字以内でなければなりません"
    Const DueDateIsOutOfRange As String = "支払日は1～28以内でなければなりません"
    Const MonthOffsetIsOutOfRange As String = "支払月は1～12以内でなければなりません"
    Const CutOffIsOutOfRange As String = "締日は1～28以内でなければなりません"

#End Region

#Region "コンストラクタ"

    Public Sub New()
        _Name = String.Empty
        _DueDate = 0
        _CutOff = 0
        _MonthOffset = 0
    End Sub

#End Region

#Region "プロパティ"

    Private _Name As String
    ''' <summary>
    ''' 支払条件名
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
            ValidateName()
        End Set
    End Property

    Private _DueDate As Integer
    ''' <summary>
    ''' 支払日付(28日は月末扱い)
    ''' </summary>
    ''' <returns></returns>
    Public Property DueDate As Integer
        Get
            Return _DueDate
        End Get
        Set(value As Integer)
            _DueDate = value
        End Set
    End Property

    Private _MonthOffset As Integer
    ''' <summary>
    ''' 支払月(オフセット)
    ''' </summary>
    ''' <returns></returns>
    Public Property MonthOffset As Integer
        Get
            Return _MonthOffset
        End Get
        Set(value As Integer)
            _MonthOffset = value
            ValidateMonthOffset()
        End Set
    End Property

    Private _CutOff As Integer
    ''' <summary>
    ''' 締日(28日は月末扱い)
    ''' </summary>
    ''' <returns></returns>
    Public Property CutOff As Integer
        Get
            Return _CutOff
        End Get
        Set(value As Integer)
            _CutOff = value
            ValidateCutOff()
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
    ''' 支払条件名の検証
    ''' </summary>
    Private Sub ValidateName()
        'エラーを一度全てクリア
        _errors.Remove(NameOf(Name))

        '支払条件名は必ず入力しなければならない
        If _Name Is Nothing OrElse _Name.Length = 0 Then
            _errors(NameOf(Name)) = NameIsNotNullOrEmpty
        End If

        '支払条件名は20文字以内でなければならない
        If _Name.Length >= 20 Then
            _errors(NameOf(Name)) = NameIsTooLong
        End If
    End Sub

    ''' <summary>
    ''' 支払日付の検証
    ''' </summary>
    Private Sub ValidateDueDate()
        'エラーを一度全てクリア
        _errors.Remove(NameOf(DueDate))

        '支払日は1～28の数値でなければならない
        If _DueDate < 1 OrElse 28 < _DueDate Then
            _errors(NameOf(DueDate)) = DueDateIsOutOfRange
        End If
    End Sub

    ''' <summary>
    ''' 支払月の検証
    ''' </summary>
    Private Sub ValidateMonthOffset()
        'エラーを一度全てクリア
        _errors.Remove(NameOf(MonthOffset))

        '支払月は1～28以内でなければならない
        If _MonthOffset < 1 OrElse 12 < _MonthOffset Then
            _errors(NameOf(MonthOffset)) = MonthOffsetIsOutOfRange
        End If
    End Sub

    ''' <summary>
    ''' 締日の検証
    ''' </summary>
    Private Sub ValidateCutOff()
        'エラーを一度全てクリア
        _errors.Remove(NameOf(CutOff))

        '締日は1～28以内でなければならない
        If _CutOff < 1 OrElse 28 < _CutOff Then
            _errors(NameOf(CutOff)) = CutOffIsOutOfRange
        End If
    End Sub

#End Region

End Class
