Option Strict On
Option Infer On

''' <summary>
''' 永続化先のバックアップとリストアを提供する
''' </summary>
Public Class InfrastractureBackup

    ''' <summary>
    ''' バックアップする
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function BackupToFile(ByVal path As String) As Boolean
        IO.File.Copy(GetDBPath(), path, True)
        Return True
    End Function

    ''' <summary>
    ''' リストアする
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function RestoreFromFile(ByVal path As String) As Boolean
        IO.File.Copy(path, GetDBPath(), True)
        Return True
    End Function

    ''' <summary>
    ''' SQLite3のDBファイルパスを取得
    ''' </summary>
    ''' <returns></returns>
    Private Shared Function GetDBPath() As String
#If DEBUG Then
        Dim path = "."
#Else
        Dim path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)
#End If
        Return System.IO.Path.Combine(path, "myDb.db")
    End Function

End Class
