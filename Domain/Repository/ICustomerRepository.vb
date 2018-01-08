Option Strict On
Option Infer On
Imports System.Collections.Generic

''' <summary>
''' 顧客情報永続化のための機能表現
''' </summary>
Public Interface ICustomerRepository

    ''' <summary>
    ''' 引数のcustomerを永続化する
    ''' </summary>
    ''' <param name="c">永続化するcustomer</param>
    ''' <returns>False:永続化失敗</returns>
    Function Save(ByVal c As Customer) As Boolean

    ''' <summary>
    ''' 最後に永続化したオブジェクトのIDを返す
    ''' </summary>
    ''' <returns></returns>
    Function LastInsertID() As Integer

    ''' <summary>
    ''' 顧客名からモデルオブジェクトを取得
    ''' </summary>
    ''' <returns></returns>
    Function FindByCustomerNameAndAddress(ByVal custName As String, ByVal addr1 As String, ByVal addr2 As String) As Customer

    ''' <summary>
    ''' 引数の条件を満たしたすべての顧客を取得
    ''' </summary>
    ''' <returns></returns>
    Function FindCustomerByCondition(ByVal cond As CustomerRepositorySearchCondition) As List(Of Customer)

    ''' <summary>
    ''' 登録されている顧客数を取得する
    ''' </summary>
    ''' <returns></returns>
    Function CountAllCustomer() As Integer

End Interface
