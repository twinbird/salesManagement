Option Strict On
Option Infer On

''' <summary>
''' 見積書レポート用(明細)のデータ転送用クラス
''' </summary>
Public Class EstimateDetailReportPresenter

#Region "コンストラクタ"

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="d"></param>
    Public Sub New(ByVal d As Domain.EstimateDetail)
        InitializeByEstimateDetail(d)
    End Sub

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' 項番
    ''' </summary>
    ''' <returns></returns>
    Public Property DisplayNo As Decimal

    ''' <summary>
    ''' 品名
    ''' </summary>
    ''' <returns></returns>
    Public Property ItemName As String

    ''' <summary>
    ''' 数量
    ''' </summary>
    ''' <returns></returns>
    Public Property Quantity As Decimal

    ''' <summary>
    ''' 単価
    ''' </summary>
    ''' <returns></returns>
    Public Property UnitPrice As Decimal

    ''' <summary>
    ''' 金額
    ''' </summary>
    ''' <returns></returns>
    Public Property Price As Decimal


#End Region

#Region "プライベートメソッド"

    ''' <summary>
    ''' 見積明細エンティティから初期化
    ''' </summary>
    Private Sub InitializeByEstimateDetail(ByVal d As Domain.EstimateDetail)
        '項番
        _DisplayNo = d.DisplayOrder
        '品名
        _ItemName = d.ItemName
        '数量
        _Quantity = d.Quantity
        '単価
        _UnitPrice = d.UnitPrice
        '金額
        _Price = (d.Quantity * d.UnitPrice)
    End Sub

#End Region

End Class
