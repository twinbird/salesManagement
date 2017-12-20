Option Strict On
Option Infer On

Imports System.Collections.Generic
Imports System.ComponentModel

''' <summary>
''' 支払条件1種類を表現する
''' </summary>
Public Class PaymentCondition
    Implements IDataErrorInfo

#Region "インスタンス変数"

    ''' <summary>
    ''' エラー保持変数
    ''' </summary>
    Private _errors As New Dictionary(Of String, String)

#End Region


#Region "プロパティ"

    ''' <summary>
    ''' 支払条件名
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String

    ''' <summary>
    ''' 支払日付(28日は月末扱い)
    ''' </summary>
    ''' <returns></returns>
    Public Property DueDate As Integer

    ''' <summary>
    ''' 支払月(オフセット)
    ''' </summary>
    ''' <returns></returns>
    Public Property MonthOffset As Integer

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
            Throw New NotImplementedException()
        End Get
    End Property

    ''' <summary>
    ''' このオブジェクト全体で整合性を保てていないエラーがあればメッセージを返す
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property [Error] As String Implements IDataErrorInfo.Error
        Get
            Throw New NotImplementedException()
        End Get
    End Property

#End Region

End Class
