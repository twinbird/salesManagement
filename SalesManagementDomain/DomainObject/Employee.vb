Option Strict On
Option Infer On

Imports System.Collections.Generic
Imports System.ComponentModel

''' <summary>
''' 従業員1名を表す
''' </summary>
Public Class Employee
    Implements IDataErrorInfo

#Region "定数"

    Const EmployeeNoIsTooLong As String = "従業員Noは5文字以内で指定してください"
    Const EmployeeNoIsNotNullOrEmpty As String = "従業員Noは必ず入力してください"

#End Region

#Region "コンストラクタ"

    Public Sub New()
        _EmployeeNo = String.Empty
    End Sub

#End Region

#Region "インスタンス変数"

    ''' <summary>
    ''' エラー保持変数
    ''' </summary>
    Private _errors As New Dictionary(Of String, String)

#End Region

#Region "プロパティ"

    Private _EmployeeNo As String
    ''' <summary>
    ''' 従業員No
    ''' </summary>
    ''' <returns></returns>
    Public Property EmployeeNo As String
        Get
            Return _EmployeeNo
        End Get
        Set(value As String)
            _EmployeeNo = value
            ValidateEmployeeNo()
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
    ''' 従業員Noを検証
    ''' </summary>
    Private Sub ValidateEmployeeNo()
        '一度エラーをクリア
        _errors.Remove(NameOf(EmployeeNo))

        '従業員Noは必ず指定しなければならない
        If _EmployeeNo Is Nothing OrElse _EmployeeNo.Length = 0 Then
            _errors(NameOf(EmployeeNo)) = EmployeeNoIsNotNullOrEmpty
        End If

        '従業員Noは5文字以内でなければならない
        If _EmployeeNo.Length > 5 Then
            _errors(NameOf(EmployeeNo)) = EmployeeNoIsTooLong
        End If
    End Sub

#End Region

End Class
