Option Strict On
Option Infer On
Imports System.Collections.Generic

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

    ''' <summary>
    ''' 指定日付に作られた見積の数を返す
    ''' </summary>
    ''' <returns></returns>
    Function CountEstimateOnDay(ByVal d As Date) As Integer

    ''' <summary>
    ''' 登録済みの見積すべての件数を返す
    ''' </summary>
    ''' <returns></returns>
    Function CountAllEstimate() As Integer

    ''' <summary>
    ''' 条件に合致した見積のリストを返す
    ''' </summary>
    ''' <returns></returns>
    Function FindEstimateByCondition(ByVal c As EstimateRepositorySearchCondition) As List(Of Estimate)

End Interface
