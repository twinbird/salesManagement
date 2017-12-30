Option Strict On
Option Infer On

''' <summary>
''' インフラストラクチャの設定
''' </summary>
Public Class InfrastructureSetting

    Private _ConnectionString As String

    Public Sub New(ByVal connectionString As String)
        _ConnectionString = connectionString
    End Sub

    ''' <summary>
    ''' データベースを初期化する
    ''' </summary>
    ''' <returns></returns>
    Public Function InitializeDB() As Boolean
#If DEBUG Then
        initializeDebugDB()
#End If
        execDDL()
        Return True
    End Function

    ''' <summary>
    ''' DDLを実行
    ''' </summary>
    Private Sub execDDL()
        'DDLを読み込み
        Dim ddl = IO.File.ReadAllText("../../../Infrastructure/DDL/DDL.txt")

        'DDLを実行
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            q.Query.AppendLine(ddl)
            q.ExecNonQuery()
        End Using
    End Sub

    ''' <summary>
    ''' デバッグ用にデータベースを初期化する
    ''' </summary>
    Private Sub initializeDebugDB()
        'SQLiteファイルを削除
        System.IO.File.Delete("myDb.db")
    End Sub

End Class
