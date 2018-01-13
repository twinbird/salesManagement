Option Strict On
Option Infer On
Imports System.Collections.Generic

''' <summary>
''' 消費税率の永続化機能表現
''' </summary>
Public Interface ISalesTaxRepository

    ''' <summary>
    ''' 引数を永続化する
    ''' </summary>
    ''' <param name="tax"></param>
    ''' <returns></returns>
    Function Save(ByVal tax As SalesTax) As Boolean

    ''' <summary>
    ''' 指定日付の適用税率を取得する
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    Function TaxOn(ByVal d As Date) As SalesTax

    ''' <summary>
    ''' 登録されているすべての税率を取得する
    ''' </summary>
    ''' <returns></returns>
    Function FindAll() As List(Of SalesTax)

    ''' <summary>
    ''' 指定日付から適用開始の税率を取得する
    ''' </summary>
    ''' <returns></returns>
    Function FindByApplyDate(ByVal d As Date) As SalesTax

End Interface
