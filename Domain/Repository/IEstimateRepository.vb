﻿Option Strict On
Option Infer On

''' <summary>
''' 見積永続化のインターフェース
''' </summary>
Public Interface IEstimateRepository

    ''' <summary>
    ''' 引数の見積を保存する
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Function Save(ByVal e As Estimate) As Boolean

    ''' <summary>
    ''' 最後に新規登録した見積のIDを返す
    ''' </summary>
    ''' <returns></returns>
    Function LastInsertID() As Integer

End Interface