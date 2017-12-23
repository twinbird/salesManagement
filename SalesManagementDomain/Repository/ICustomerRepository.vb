Option Strict On
Option Infer On

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

End Interface
