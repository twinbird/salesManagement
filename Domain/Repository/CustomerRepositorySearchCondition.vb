Option Strict On
Option Infer On

''' <summary>
''' 顧客を検索する際に使う検索条件
''' </summary>
Public Class CustomerRepositorySearchCondition

    ''' <summary>
    ''' 顧客名(前方一致)
    ''' </summary>
    ''' <returns></returns>
    Public Property NameForwardMatch As String

    ''' <summary>
    ''' かな名(前方一致)
    ''' </summary>
    ''' <returns></returns>
    Public Property KanaNameForwardMatch As String

    ''' <summary>
    ''' 営業担当者
    ''' </summary>
    ''' <returns></returns>
    Public Property PIC As Employee

    ''' <summary>
    ''' 住所(前方一致)
    ''' </summary>
    ''' <returns></returns>
    Public Property AddressForwardMatch As String

End Class
