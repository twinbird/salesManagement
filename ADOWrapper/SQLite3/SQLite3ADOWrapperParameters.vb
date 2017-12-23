Option Strict On
Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Data

''' <summary>
''' SQLite3用のパラメータラッパー
''' </summary>
Public Class SQLite3ADOWrapperParameters
    Implements IADOWrapperParameters

#Region "インスタンス変数"

    Private m_paramDictionary As Dictionary(Of String, String)

#End Region

#Region "パブリックメソッド"

    ''' <summary>
    ''' SQL実行時に利用するパラメータを設定します
    ''' </summary>
    ''' <param name="key">名前付けパラメータの名前</param>
    ''' <param name="value">名前付けパラメータに与える値</param>
    Public Sub Add(key As String, value As Decimal) Implements IADOWrapperParameters.Add
        If m_paramDictionary.ContainsKey(key) = True Then
            Throw New Exception(key & " is already added")
        End If
        m_paramDictionary.Add(key, value.ToString)
    End Sub

    ''' <summary>
    ''' SQL実行時に利用するパラメータを設定します
    ''' </summary>
    ''' <param name="key">名前付けパラメータの名前</param>
    ''' <param name="value">名前付けパラメータに与える値</param>
    Public Sub Add(key As String, value As Integer) Implements IADOWrapperParameters.Add
        If m_paramDictionary.ContainsKey(key) = True Then
            Throw New Exception(key & " is already added")
        End If
        m_paramDictionary.Add(key, value.ToString)
    End Sub

    ''' <summary>
    ''' SQL実行時に利用するパラメータを設定します
    ''' </summary>
    ''' <param name="key">名前付けパラメータの名前</param>
    ''' <param name="value">名前付けパラメータに与える値</param>
    Public Sub Add(key As String, value As String) Implements IADOWrapperParameters.Add
        If m_paramDictionary.ContainsKey(key) = True Then
            Throw New Exception(key & " is already added")
        End If
        m_paramDictionary.Add(key, value)
    End Sub

#End Region

#Region "フレンドメソッド"

    Friend Sub New()
        m_paramDictionary = New Dictionary(Of String, String)
    End Sub

    ''' <summary>
    ''' パラメータを配列にして返します
    ''' </summary>
    ''' <returns></returns>
    Friend Function ToArray() As Array
        Dim ret As New List(Of SQLite.SQLiteParameter)
        For Each kvp In m_paramDictionary
            Dim p = New SQLite.SQLiteParameter(kvp.Key, kvp.Value)
            ret.Add(p)
        Next
        Return ret.ToArray()
    End Function

    ''' <summary>
    ''' パラメータ未設定ならTrue
    ''' </summary>
    ''' <returns></returns>
    Friend Function IsZero() As Boolean
        Return m_paramDictionary.Count = 0
    End Function

#End Region

End Class
