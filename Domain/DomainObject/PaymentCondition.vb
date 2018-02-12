Option Strict On
Option Infer On

Imports System.Collections.Generic
Imports System.ComponentModel

''' <summary>
''' 支払条件1種類を表現する
''' </summary>
Public Class PaymentCondition
    Implements IDataErrorInfo

#Region "定数"

    ''' <summary>
    ''' 締日の月末(この日以降は指定できない)
    ''' </summary>
    Public Const CutOffEndOfMonth As Integer = 28

    ''' <summary>
    ''' 支払日の月末(この日以降は指定できない)
    ''' </summary>
    Public Const DueDateEndOfMonth As Integer = 28

#End Region

#Region "メッセージ定数"

    Const NameIsNotNullOrEmpty As String = "支払条件名は必ず入力しなければなりません"
    Const NameIsTooLong As String = "支払条件名は20文字以内でなければなりません"
    Const DueDateIsOutOfRange As String = "支払日は1～28以内でなければなりません"
    Const MonthOffsetIsOutOfRange As String = "支払月は0～12以内でなければなりません"
    Const CutOffIsOutOfRange As String = "締日は1～28以内でなければなりません"
    Const NameIsAlreadyUsing As String = "この支払条件名は既に登録されています"

#End Region

#Region "リポジトリへのポインタ"

    Private _PaymentConditionRepo As IPaymentConditionRepository

#End Region

#Region "コンストラクタ"

    Public Sub New(ByVal repo As IPaymentConditionRepository)
        _ID = -1
        _Name = String.Empty
        _DueDate = 1
        _CutOff = 1
        _MonthOffset = 0
        _PaymentConditionRepo = repo
    End Sub

    Public Sub New(ByVal id As Integer, ByVal repo As IPaymentConditionRepository)
        _ID = id
        _Name = String.Empty
        _DueDate = 1
        _CutOff = 1
        _MonthOffset = 0
        _PaymentConditionRepo = repo
    End Sub

#End Region

#Region "プロパティ"

    ''' <summary>
    ''' オブジェクトを一意に特定するID(永続化が行われていないものは-1)
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ID As Integer

    Private _Name As String
    ''' <summary>
    ''' 支払条件名
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
            ValidateName()
        End Set
    End Property

    Private _DueDate As Integer
    ''' <summary>
    ''' 支払日付(28日は月末扱い)
    ''' </summary>
    ''' <returns></returns>
    Public Property DueDate As Integer
        Get
            Return _DueDate
        End Get
        Set(value As Integer)
            _DueDate = value
        End Set
    End Property

    ''' <summary>
    ''' 月末支払ならTrue
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property PayEndOfMonth As Boolean
        Get
            '28日なら月末扱い
            If _DueDate = DueDateEndOfMonth Then
                Return True
            End If
            'その他は日付通り
            Return False
        End Get
    End Property

    Private _MonthOffset As Integer
    ''' <summary>
    ''' 支払月(オフセット)
    ''' </summary>
    ''' <returns></returns>
    Public Property MonthOffset As Integer
        Get
            Return _MonthOffset
        End Get
        Set(value As Integer)
            _MonthOffset = value
            ValidateMonthOffset()
        End Set
    End Property

    Private _CutOff As Integer
    ''' <summary>
    ''' 締日(28日は月末扱い)
    ''' </summary>
    ''' <returns></returns>
    Public Property CutOff As Integer
        Get
            Return _CutOff
        End Get
        Set(value As Integer)
            _CutOff = value
            ValidateCutOff()
        End Set
    End Property

    ''' <summary>
    ''' 月末締めならTrue
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property CutOffByEndOfMonth As Boolean
        Get
            '28日なら月末扱い
            If _CutOff = CutOffEndOfMonth Then
                Return True
            End If
            'その他は日付通り
            Return False
        End Get
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
    ''' オブジェクトの整合性チェックを実施
    ''' </summary>
    ''' <returns>不整合:False</returns>
    Public Function Validate() As Boolean
        '各項目個別のチェックを実施
        ValidateName()
        ValidateDueDate()
        ValidateMonthOffset()
        ValidateCutOff()

        '永続化も含めた項目全体の整合性チェックを実施
        'エラーリストのクリアのため他の要素の後に実施しないとならない
        ValidateTotalItems()

        Return Me.HasError = False
    End Function

    ''' <summary>
    ''' 永続化も含めた要素全体の整合性チェックを実施
    ''' </summary>
    Private Sub ValidateTotalItems()
        'ほかのチェックに引っかかってたらDBアクセス前に例外発生があり得るので戻してやる
        If Me.HasError = True Then
            Return
        End If

        '支払条件名は登録済みのものは使えない
        Dim emp = _PaymentConditionRepo.FindByName(_Name)
        If emp IsNot Nothing AndAlso emp.ID <> Me.ID Then
            _errors(NameOf(Name)) = NameIsAlreadyUsing
        End If
    End Sub


    ''' <summary>
    ''' 支払条件名の検証
    ''' </summary>
    Private Sub ValidateName()
        'エラーを一度全てクリア
        _errors.Remove(NameOf(Name))

        '支払条件名は必ず入力しなければならない
        If _Name Is Nothing OrElse _Name.Length = 0 Then
            _errors(NameOf(Name)) = NameIsNotNullOrEmpty
        End If

        '支払条件名は20文字以内でなければならない
        If _Name.Length >= 20 Then
            _errors(NameOf(Name)) = NameIsTooLong
        End If
    End Sub

    ''' <summary>
    ''' 支払日付の検証
    ''' </summary>
    Private Sub ValidateDueDate()
        'エラーを一度全てクリア
        _errors.Remove(NameOf(DueDate))

        '支払日は1～支払の月末日の数値でなければならない
        If _DueDate < 1 OrElse DueDateEndOfMonth < _DueDate Then
            _errors(NameOf(DueDate)) = DueDateIsOutOfRange
        End If
    End Sub

    ''' <summary>
    ''' 支払月の検証
    ''' </summary>
    Private Sub ValidateMonthOffset()
        'エラーを一度全てクリア
        _errors.Remove(NameOf(MonthOffset))

        '支払月は0～12以内でなければならない
        If _MonthOffset < 0 OrElse 12 < _MonthOffset Then
            _errors(NameOf(MonthOffset)) = MonthOffsetIsOutOfRange
        End If
    End Sub

    ''' <summary>
    ''' 締日の検証
    ''' </summary>
    Private Sub ValidateCutOff()
        'エラーを一度全てクリア
        _errors.Remove(NameOf(CutOff))

        '締日は1～28以内でなければならない
        If _CutOff < 1 OrElse CutOffEndOfMonth < _CutOff Then
            _errors(NameOf(CutOff)) = CutOffIsOutOfRange
        End If
    End Sub

#End Region

#Region "CRUD"

    ''' <summary>
    ''' このオブジェクトを永続化する
    ''' </summary>
    ''' <returns>登録成功:True 登録失敗:False</returns>
    Public Function Save() As Boolean
        If _PaymentConditionRepo.Save(Me) = False Then
            Return False
        End If
        Me._ID = _PaymentConditionRepo.LastInsertID
        Return True
    End Function

#End Region

#Region "オーバーライド"

    Public Overrides Function Equals(obj As Object) As Boolean
        '型が異なれば異なる
        If obj.GetType <> GetType(PaymentCondition) Then
            Return False
        End If
        Dim c = DirectCast(obj, PaymentCondition)

        'ID値が同じなら同じ
        Return Me.ID = c.ID
    End Function

#End Region


End Class
