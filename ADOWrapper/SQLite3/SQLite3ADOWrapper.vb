Option Strict On
Option Infer On

Imports System
Imports System.Data

''' <summary>
''' SQLite3向けのADO.NETのうすーいラッパー
''' </summary>
Public Class SQLite3ADOWrapper
    Implements IADOWrapper

#Region "インスタンス変数"

    Private m_query As QueryBuilder
    Private m_parameters As SQLite3ADOWrapperParameters
    Private m_connection As IDbConnection

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' SQL実行時に利用するパラメータ
    ''' </summary>
    ''' <returns></returns>
    Public Property Parameters As IADOWrapperParameters Implements IADOWrapper.Parameters
        Get
            Return m_parameters
        End Get
        Set(value As IADOWrapperParameters)
            m_parameters = DirectCast(value, SQLite3ADOWrapperParameters)
        End Set
    End Property

    ''' <summary>
    ''' 実行するSQL
    ''' </summary>
    ''' <returns></returns>
    Public Property Query As QueryBuilder Implements IADOWrapper.Query
        Get
            Return m_query
        End Get
        Set(value As QueryBuilder)
            m_query = value
        End Set
    End Property

#End Region

#Region "パブリックメソッド"

    ''' <summary>
    ''' プロパティに設定された情報でクエリを発行します
    ''' </summary>
    ''' <returns>クエリ結果のデータテーブル</returns>
    Public Function ExecNonQuery() As Integer Implements IADOWrapper.ExecNonQuery
        If m_query Is Nothing Then
            Throw New Exception("Property 'SQL' is not set.")
        End If
        Return executeNonQuery()
    End Function

    ''' <summary>
    ''' プロパティに設定された情報でクエリを発行します
    ''' </summary>
    ''' <returns>影響を与えた行数</returns>
    Public Function ExecQuery() As DataTable Implements IADOWrapper.ExecQuery
        If m_query Is Nothing Then
            Throw New Exception("Property 'SQL' is not set.")
        End If
        Return executeQuery()
    End Function

    ''' <summary>
    ''' プロパティに設定された情報でクエリを発行します
    ''' </summary>
    ''' <returns>クエリ結果セットの最初の行の最初の列。結果セットが空の場合は、null</returns>
    Public Function ExecScalar() As Object Implements IADOWrapper.ExecScalar
        If m_query Is Nothing Then
            Throw New Exception("Property 'SQL' is not set.")
        End If
        Return executeScalar()
    End Function

    ''' <summary>
    ''' 内部で保持しているSQLクエリを返します
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String Implements IADOWrapper.ToString
        Return m_query.ToString
    End Function

#End Region

#Region "フレンドメソッド"

    ''' <summary>
    ''' ADO.NETを使ったデータベースアクセス1回を表します
    ''' </summary>
    Friend Sub New(ByVal con As IDbConnection)
        m_connection = con
        Transaction = Nothing
        m_query = New QueryBuilder
        m_parameters = New SQLite3ADOWrapperParameters
    End Sub

    ''' <summary>
    ''' SQLite3向けDBコネクションクラスのインスタンスを返す
    ''' </summary>
    ''' <returns></returns>
    Friend Shared Function CreateConnection() As IDbConnection
        Return New SQLite.SQLiteConnection
    End Function

    ''' <summary>
    ''' クエリ発行に利用するトランザクション
    ''' </summary>
    ''' <returns></returns>
    Friend Property Transaction As IDbTransaction

#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' Textのコマンドを構築して返す
    ''' </summary>
    ''' <param name="con"></param>
    ''' <returns></returns>
    Private Function createTextCommand(ByVal con As SQLite.SQLiteConnection) As SQLite.SQLiteCommand
        Dim command As SQLite.SQLiteCommand = con.CreateCommand
        With command
            'コネクション指定
            .Connection = con
            'SQLは常にプレーンなテキストコマンド
            .CommandType = CommandType.Text
            '実行するSQL
            .CommandText = m_query.ToString
            'トランザクション
            .Transaction = DirectCast(Transaction, SQLite.SQLiteTransaction2)
            'パラメータがあれば利用
            If m_parameters IsNot Nothing Then
                .Parameters.AddRange(m_parameters.ToArray)
            End If
        End With
        Return command
    End Function

    ''' <summary>
    ''' 影響行数だけを返すクエリを実行
    ''' </summary>
    ''' <returns>影響を与えた行数</returns>
    Private Function executeNonQuery() As Integer
        'コマンド生成
        Dim command = createTextCommand(DirectCast(m_connection, SQLite.SQLiteConnection))

        'クエリ実行
        Return command.ExecuteNonQuery()
    End Function

    ''' <summary>
    ''' クエリを実行して実行結果のデータテーブルを返す
    ''' </summary>
    ''' <returns></returns>
    Private Function executeQuery() As DataTable
        'コマンド生成
        Dim command = createTextCommand(DirectCast(m_connection, SQLite.SQLiteConnection))

        'クエリ実行
        Dim ds As New DataSet
        Dim adapter As New SQLite.SQLiteDataAdapter(command)
        adapter.Fill(ds)

        Return ds.Tables(0)
    End Function

    ''' <summary>
    ''' クエリを実行して実行結果の数値を返す
    ''' </summary>
    ''' <returns>結果セットの最初の行の最初の列。結果セットが空の場合は、null</returns>
    Private Function executeScalar() As Object
        'コマンド生成
        Dim command = createTextCommand(DirectCast(m_connection, SQLite.SQLiteConnection))

        Return command.ExecuteScalar()
    End Function

#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: マネージ状態を破棄します (マネージ オブジェクト)。
            End If

            ' TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下の Finalize() をオーバーライドします。
            ' TODO: 大きなフィールドを null に設定します。
        End If
        disposedValue = True
    End Sub

    ' TODO: 上の Dispose(disposing As Boolean) にアンマネージ リソースを解放するコードが含まれる場合にのみ Finalize() をオーバーライドします。
    'Protected Overrides Sub Finalize()
    '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        Dispose(True)
        ' TODO: 上の Finalize() がオーバーライドされている場合は、次の行のコメントを解除してください。
        ' GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class
