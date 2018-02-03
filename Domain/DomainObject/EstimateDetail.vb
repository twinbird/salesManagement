Option Strict On
Option Infer On
Imports System.Collections.Generic
Imports System.ComponentModel

''' <summary>
''' 見積の明細1行
''' </summary>
Public Class EstimateDetail
    Implements IDataErrorInfo

#Region "定数"

    Const DisplayOrderOutOfRange As String = "明細表示順は0から20の範囲で指定してください"
    Const ItemNameDoNotEmpty As String = "品名は必ず入力してください"
    Const ItemNameIsTooLong As String = "品名は50文字以内で入力してください"
    Const QuantityOutOfRange As String = "数量は1から999の範囲で指定してください"
    Const UnitPriceOutOfRange As String = "単価は0から99999999の範囲で指定してください"

#End Region

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    Public Sub New()
        _ID = -1
    End Sub

#Region "値プロパティ"

    Public ReadOnly Property ID As Integer

    Private _DisplayOrder As Integer
    ''' <summary>
    ''' 明細表示順
    ''' </summary>
    ''' <returns></returns>
    Public Property DisplayOrder As Integer
        Get
            Return _DisplayOrder
        End Get
        Set(value As Integer)
            _DisplayOrder = value
            ValidateDisplayOrder()
        End Set
    End Property

    Private _ItemName As String
    ''' <summary>
    ''' 品名
    ''' </summary>
    ''' <returns></returns>
    Public Property ItemName As String
        Get
            Return _ItemName
        End Get
        Set(value As String)
            _ItemName = value
            ValidateItemName()
        End Set
    End Property

    Private _Quantity As Integer
    ''' <summary>
    ''' 数量
    ''' </summary>
    ''' <returns></returns>
    Public Property Quantity As Integer
        Get
            Return _Quantity
        End Get
        Set(value As Integer)
            _Quantity = value
            ValidateItemName()
        End Set
    End Property

    Private _UnitPrice As Decimal
    ''' <summary>
    ''' 単価
    ''' </summary>
    ''' <returns></returns>
    Public Property UnitPrice As Decimal
        Get
            Return _UnitPrice
        End Get
        Set(value As Decimal)
            _UnitPrice = value
            ValidateUnitPrice()
        End Set
    End Property

#End Region

#Region "エラープロパティ"

    ''' <summary>
    ''' エラー保持変数
    ''' </summary>
    Private _errors As New Dictionary(Of String, String)

    ''' <summary>
    ''' このオブジェクトの状態にエラーがあればTrue
    ''' </summary>
    ''' <returns></returns>
    Public Function HasError() As Boolean
        Return _errors.Count <> 0
    End Function

    ''' <summary>
    ''' 指定プロパティにエラーがあればメッセージを返す
    ''' </summary>
    ''' <param name="columnName"></param>
    ''' <returns></returns>
    Default Public ReadOnly Property Item(columnName As String) As String Implements IDataErrorInfo.Item
        Get
            If _errors.ContainsKey(columnName) = False Then
                Return String.Empty
            End If
            Return _errors(columnName)
        End Get
    End Property

    ''' <summary>
    ''' このオブジェクト全体で整合性を保てていないエラーがあればメッセージを返す
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property [Error] As String Implements IDataErrorInfo.Error
        Get
            Return String.Empty
        End Get
    End Property

#End Region

#Region "検証メソッド"

    ''' <summary>
    ''' このオブジェクトの妥当性を確認する
    ''' </summary>
    ''' <returns></returns>
    Public Function Validate() As Boolean
        ValidateDisplayOrder()
        ValidateItemName()
        ValidateQuantity()
        ValidateUnitPrice()

        Return HasError() = False
    End Function

    ''' <summary>
    ''' 明細表示順を検証
    ''' </summary>
    Private Sub ValidateDisplayOrder()
        'エラーを一度クリア
        _errors.Remove(NameOf(DisplayOrder))

        '表示順は0から20まで
        If _DisplayOrder < 0 Then
            _errors(NameOf(DisplayOrder)) = DisplayOrderOutOfRange
        End If

        If _DisplayOrder > Estimate.MAX_ESTIMATE_DETAIL_SIZE Then
            _errors(NameOf(DisplayOrder)) = DisplayOrderOutOfRange
        End If

    End Sub

    ''' <summary>
    ''' 品名を検証
    ''' </summary>
    Private Sub ValidateItemName()
        'エラーを一度クリア
        _errors.Remove(NameOf(ItemName))

        '品名は未入力不可(Nothingだとその後のエラーチェックで例外の可能性があるので戻す)
        If _ItemName Is Nothing Then
            _errors(NameOf(ItemName)) = ItemNameDoNotEmpty
            Return
        End If

        '品名は未入力不可
        If _ItemName = String.Empty Then
            _errors(NameOf(ItemName)) = ItemNameDoNotEmpty
        End If

        '品名は50文字以内
        If _ItemName.Length > 50 Then
            _errors(NameOf(ItemName)) = ItemNameIsTooLong
        End If

    End Sub

    ''' <summary>
    ''' 数量を検証
    ''' </summary>
    Private Sub ValidateQuantity()
        'エラーを一度クリア
        _errors.Remove(NameOf(Quantity))

        '数量は0から999まで
        If _Quantity < 0 Then
            _errors(NameOf(Quantity)) = QuantityOutOfRange
        End If

        If _Quantity > 999 Then
            _errors(NameOf(Quantity)) = QuantityOutOfRange
        End If
    End Sub

    ''' <summary>
    ''' 単価を検証
    ''' </summary>
    Private Sub ValidateUnitPrice()
        'エラーを一度クリア
        _errors.Remove(NameOf(UnitPrice))

        '単価は0から99999999まで
        If _UnitPrice < 0 Then
            _errors(NameOf(UnitPrice)) = UnitPriceOutOfRange
        End If

        If _UnitPrice > 99999999 Then
            _errors(NameOf(UnitPrice)) = UnitPriceOutOfRange
        End If
    End Sub

#End Region

End Class
