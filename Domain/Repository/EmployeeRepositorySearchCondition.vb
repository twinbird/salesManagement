Option Strict On
Option Infer On

''' <summary>
''' 従業員を検索する際に使う検索条件
''' </summary>
Public Class EmployeeRepositorySearchCondition

    ''' <summary>
    ''' 従業員番号(前方一致)
    ''' </summary>
    ''' <returns></returns>
    Property EmployeeNoForwardMatch As String

    ''' <summary>
    ''' 従業員名(前方一致)
    ''' </summary>
    ''' <returns></returns>
    Property EmployeeNameForwardMatch As String

    ''' <summary>
    ''' 従業員名かな(前方一致)
    ''' </summary>
    ''' <returns></returns>
    Property EmployeeNameKanaForwardMatch As String

End Class