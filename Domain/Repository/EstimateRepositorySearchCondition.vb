Option Strict On
Option Infer On

''' <summary>
''' 見積検索の条件を表現するクラス
''' </summary>
Public Class EstimateRepositorySearchCondition

    ''' <summary>
    ''' 見積番号に前方一致
    ''' </summary>
    ''' <returns></returns>
    Public Property EstimateNoForwardMatch As String

    ''' <summary>
    ''' 件名に前方一致
    ''' </summary>
    ''' <returns></returns>
    Public Property TitleForwardMatch As String

    ''' <summary>
    ''' 発行日(区間検索の開始日)
    ''' </summary>
    ''' <returns></returns>
    Public Property IssueDateRangeStart As Date

    ''' <summary>
    ''' 発行日(区間検索の終了日)
    ''' </summary>
    ''' <returns></returns>
    Public Property IssueDateRangeEnd As Date

    ''' <summary>
    ''' 見積有効期限(区間検索の開始日)
    ''' </summary>
    ''' <returns></returns>
    Public Property EffectiveDateRangeStart As Date

    ''' <summary>
    ''' 見積有効期限(区間検索の終了日)
    ''' </summary>
    ''' <returns></returns>
    Public Property EffectiveDateRangeEnd As Date

    ''' <summary>
    ''' 担当営業
    ''' </summary>
    ''' <returns></returns>
    Public Property PICEmployee As Employee

    ''' <summary>
    ''' 顧客
    ''' </summary>
    ''' <returns></returns>
    Public Property Customer As Customer

End Class
