Option Strict On
Option Infer On

''' <summary>
''' 実装ヘルパー
''' </summary>
Public Class Helper

    ''' <summary>
    ''' 引数の日付を23:59:59の時刻にした日付を返す
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    Public Shared Function EndOfDate(ByVal d As Date) As DateTime
        Dim nd = New Date(d.Year, d.Month, d.Day, 23, 59, 59)
        Return nd
    End Function

    ''' <summary>
    ''' 引数の日付を0:0:0の時刻にした日付を返す
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    Public Shared Function StartOfDate(ByVal d As Date) As DateTime
        Dim nd = New Date(d.Year, d.Month, d.Day, 0, 0, 0)
        Return nd
    End Function

End Class
