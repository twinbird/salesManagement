Option Strict On
Option Infer On

Imports System.Collections.Generic

''' <summary>
''' 支払条件永続化のための機能表現
''' </summary>
Public Interface IPaymentConditionRepository
    ''' <summary>
    ''' 引数のPaymentConditionを永続化する
    ''' </summary>
    ''' <param name="e">永続化するEmployee</param>
    ''' <returns>False:永続化失敗</returns>
    Function Save(ByVal e As PaymentCondition) As Boolean

    ''' <summary>
    ''' 最後に永続化したオブジェクトのIDを返す
    ''' </summary>
    ''' <returns></returns>
    Function LastInsertID() As Integer

    ''' <summary>
    ''' IDから支払条件モデルオブジェクトを取得
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Function FindByID(ByVal id As Integer) As PaymentCondition

    ''' <summary>
    ''' 支払条件名からモデルオブジェクトを取得
    ''' </summary>
    ''' <returns></returns>
    Function FindByName(ByVal name As String) As PaymentCondition

    ''' <summary>
    ''' 登録済みのすべての支払条件モデルオブジェクトを取得
    ''' </summary>
    ''' <returns></returns>
    Function FindAllPaymentCondition() As List(Of PaymentCondition)

    ''' <summary>
    ''' 引数の条件を満たしたすべての従業員を取得
    ''' </summary>
    ''' <returns></returns>
    Function FindPaymentConditionByCondition(ByVal cond As PaymentConditionRepositorySearchCondition) As List(Of PaymentCondition)

    ''' <summary>
    ''' 登録されている支払条件数を取得する
    ''' </summary>
    ''' <returns></returns>
    Function CountAllPaymentCondition() As Integer

End Interface
