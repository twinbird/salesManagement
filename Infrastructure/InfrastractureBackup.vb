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
        IO.File.Copy("myDb.db", path, True)
        Return True
    End Function

    ''' <summary>
    ''' リストアする
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function RestoreFromFile(ByVal path As String) As Boolean
        IO.File.Copy(path, "myDb.db", True)
        Return True
    End Function

End Class
