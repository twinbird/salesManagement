Option Strict On
Option Infer On

Imports System

''' <summary>
''' データベースへの1コネクション/1トランザクションを表現するクラスです
''' </summary>
Public Class DBAccessor
    Implements IDisposable

#Region "インスタンス変数"

    Private m_connectionString As String
    Private m_connection As System.Data.IDbConnection
    Private m_transaction As System.Data.IDbTransaction
    Private m_ADOWrapperType As String

#End Region

#Region "パブリックメソッド"

    ''' <summary>
    ''' DBの接続インターフェースを提供するクラスです
    ''' </summary>
    ''' <param name="connectionString">接続文字列</param>
    Public Sub New(ByVal connectionString As String)
        m_ADOWrapperType = "SQLite3"
        m_connectionString = connectionString
        connectDB()
    End Sub

    ''' <summary>
    ''' DBの接続インターフェースを提供するクラスです。
    ''' App.configのConnectionString名'mainDB'へ接続します。
    ''' </summary>
    Public Sub New()
        m_ADOWrapperType = "SQLite3"
        m_connectionString = System.Configuration.ConfigurationManager.ConnectionStrings.Item("mainDB").ConnectionString
        connectDB()
    End Sub

    ''' <summary>
    ''' 設定に従って特定DBMS向けのIADOWrapperのインスタンスを生成します
    ''' </summary>
    Public Function CreateQuery() As IADOWrapper
        Return New SQLite3ADOWrapper(m_connection)
    End Function

    ''' <summary>
    ''' このDBAccessorでのトランザクションを開始します
    ''' </summary>
    Public Sub BeginTransaction()
        m_transaction = m_connection.BeginTransaction()
    End Sub

    ''' <summary>
    ''' このDBAccessorでのトランザクションをコミットします
    ''' </summary>
    Public Sub Commit()
        If m_transaction Is Nothing Then
            Throw New Exception("Transaction is not begun.")
        End If
        m_transaction.Commit()
    End Sub

    ''' <summary>
    ''' このDBAccessorでのトランザクションをロールバックします
    ''' </summary>
    Public Sub RollBack()
        If m_transaction Is Nothing Then
            Throw New Exception("Transaction is not begun.")
        End If
        m_transaction.Rollback()
    End Sub

#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' DBへ接続
    ''' </summary>
    Private Sub connectDB()

        Select Case m_ADOWrapperType
            Case "SQLite3"
                'とりあえずSQLiteだけ
                m_connection = SQLite3ADOWrapper.CreateConnection
                m_connection.ConnectionString = m_connectionString
        End Select

        m_connection.Open()

    End Sub

#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 重複する呼び出しを検出するには

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                If m_connection IsNot Nothing Then
                    m_connection.Close()
                    m_connection.Dispose()
                End If
            End If
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
