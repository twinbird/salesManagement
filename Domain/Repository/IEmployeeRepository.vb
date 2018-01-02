Option Strict On
Option Infer On

Imports System.Collections.Generic

''' <summary>
''' 従業員永続化のための機能表現
''' </summary>
Public Interface IEmployeeRepository

    ''' <summary>
    ''' 引数のEmployeeを永続化する
    ''' </summary>
    ''' <param name="e">永続化するEmployee</param>
    ''' <returns>False:永続化失敗</returns>
    Function Save(ByVal e As Employee) As Boolean

    ''' <summary>
    ''' 最後に永続化したオブジェクトのIDを返す
    ''' </summary>
    ''' <returns></returns>
    Function LastInsertID() As Integer

    ''' <summary>
    ''' 従業員番号からモデルオブジェクトを取得
    ''' </summary>
    ''' <returns></returns>
    Function FindByEmployeeNo(ByVal empNo As String) As Employee

    ''' <summary>
    ''' 登録済みの従業員のすべてのモデルオブジェクトを取得
    ''' </summary>
    ''' <returns></returns>
    Function FindAllEmployee() As List(Of Employee)

    ''' <summary>
    ''' 引数の条件を満たしたすべての従業員を取得
    ''' </summary>
    ''' <returns></returns>
    Function FindEmployeeByCondition(ByVal cond As EmployeeRepositorySearchCondition) As List(Of Employee)

    ''' <summary>
    ''' 登録されている従業員数を取得する
    ''' </summary>
    ''' <returns></returns>
    Function CountAllEmployee() As Integer

End Interface
