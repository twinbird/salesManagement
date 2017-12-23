Option Strict On
Option Infer On

Imports System

''' <summary>
''' クエリ構築のためのクラス
''' </summary>
Public Class QueryBuilder

#Region "インスタンス変数"

    Private m_query As Text.StringBuilder

#End Region

#Region "パブリックメソッド"

    Public Sub New()
        m_query = New Text.StringBuilder
    End Sub

    ''' <summary>
    ''' 指定した文字列と行終端記号を構築中のクエリに追加します
    ''' </summary>
    ''' <param name="str"></param>
    Public Sub AppendLine(ByVal str As String)
        m_query.AppendLine(str)
    End Sub

    ''' <summary>
    ''' 構築中のクエリをテキストにして返します
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String
        Return m_query.ToString()
    End Function

#End Region

End Class
