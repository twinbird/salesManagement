Option Strict On
Option Infer On

Imports System.ComponentModel

''' <summary>
''' ソート可能なBindingList
''' </summary>
Public Class SortableBindingList(Of T)
    Inherits BindingList(Of T)

#Region "インスタンス変数"

    ''' <summary>
    ''' プロパティ名をキーにしたソートメソッドのディクショナリ
    ''' </summary>
    Private sortComparers As Dictionary(Of String, IComparer(Of T))


#End Region

#Region "コンストラクタ"

    ''' <summary>
    ''' リストを受け付けるコンストラクタ
    ''' </summary>
    ''' <param name="list"></param>
    Public Sub New(ByVal list As IList(Of T))
        MyBase.New(list)
    End Sub


#End Region

#Region "プロパティ"

    Private currentSortDirection As ListSortDirection
    ''' <summary>
    ''' ソートをサポートするか否か
    ''' </summary>
    ''' <returns></returns>
    Protected Overrides ReadOnly Property SupportsSortingCore As Boolean
        Get
            Return True
        End Get
    End Property

    Private currentSortProperty As PropertyDescriptor
    ''' <summary>
    ''' 前回のソートに利用したプロパティ
    ''' </summary>
    ''' <returns></returns>
    Protected Overrides ReadOnly Property SortPropertyCore As PropertyDescriptor
        Get
            Return currentSortProperty
        End Get
    End Property

    Private isSorted As Boolean
    ''' <summary>
    ''' ソート済みならTrue
    ''' </summary>
    ''' <returns></returns>
    Protected Overrides ReadOnly Property IsSortedCore As Boolean
        Get
            Return isSorted
        End Get
    End Property

    ''' <summary>
    ''' 前回のソートに利用した方向
    ''' </summary>
    ''' <returns></returns>
    Protected Overrides ReadOnly Property SortDirectionCore As ListSortDirection
        Get
            Return currentSortDirection
        End Get
    End Property


#End Region

#Region "オーバーライドメソッド"

    ''' <summary>
    ''' ソートを適用
    ''' </summary>
    ''' <param name="prop"></param>
    ''' <param name="direction"></param>
    Protected Overrides Sub ApplySortCore(prop As PropertyDescriptor, direction As ListSortDirection)
        Dim list = CType(Me.Items, List(Of T))

        currentSortProperty = prop
        currentSortDirection = direction
        list.Sort(AddressOf Compare)
        Me.isSorted = True
        Me.OnListChanged(New ListChangedEventArgs(ListChangedType.Reset, -1))
    End Sub

#End Region

#Region "独自メソッド"

    ''' <summary>
    ''' 比較用メソッド
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    Private Function Compare(x As T, y As T) As Integer
        Dim valX As Object = currentSortProperty.GetValue(x)
        Dim valY As Object = currentSortProperty.GetValue(y)

        Dim icX = TryCast(valX, IComparable)
        Dim icY = TryCast(valY, IComparable)

        If (icX Is Nothing AndAlso icY Is Nothing) Then
            Return 0
        End If

        If (icX Is Nothing AndAlso icY IsNot Nothing) Then
            If currentSortDirection = ListSortDirection.Ascending Then
                Return -1
            Else
                Return 1
            End If
        End If

        If (icX IsNot Nothing AndAlso icY Is Nothing) Then
            If currentSortDirection = ListSortDirection.Ascending Then
                Return 1
            Else
                Return -1
            End If
        End If

        If currentSortDirection = ListSortDirection.Ascending Then
            Return icX.CompareTo(icY)
        Else
            Return -(icX.CompareTo(icY))
        End If
    End Function

#End Region

End Class
