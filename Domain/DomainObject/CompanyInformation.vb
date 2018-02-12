Option Strict On
Option Infer On

Imports System.Collections.Generic
Imports System.ComponentModel

''' <summary>
''' 特定日付時点の自社情報を表すクラス
''' </summary>
Public Class CompanyInformation
    Implements IDataErrorInfo

#Region "定数"

    Private Const NameDoNotEmpty As String = "会社名は必ず入力してください"
    Private Const NameIsTooLong As String = "会社名は100文字以内で入力してください"
    Private Const PostalCodeDoNotNothing As String = "郵便番号を未定義にすることはできません"
    Private Const PostalCodeIsWrongFormat As String = "郵便番号の入力形式が間違っています"
    Private Const Address1DoNotNothing As String = "住所1を未定義にすることはできません"
    Private Const Address1IsTooLong As String = "住所1は50文字以内で入力してください"
    Private Const Address2DoNotNothing As String = "住所2を未定義にすることはできません"
    Private Const Address2IsTooLong As String = "住所2は50文字以内で入力してください"
    Private Const TELDoNotNothing As String = "TELを未定義にすることはできません"
    Private Const TELIsTooLong As String = "TELは15文字以内で入力してください"
    Private Const TELIsWrongFormat As String = "TELの入力形式が間違っています"
    Private Const FAXDoNotNothing As String = "FAXを未定義にすることはできません"
    Private Const FAXIsTooLong As String = "FAXは15文字以内で入力してください"
    Private Const FAXIsWrongFormat As String = "FAXの入力形式が間違っています"

#End Region

#Region "コンストラクタ"

    Public Sub New()
        _ID = -1
        _Name = String.Empty
        _PostalCode = String.Empty
        _Address1 = String.Empty
        _Address2 = String.Empty
        _TEL = String.Empty
        _FAX = String.Empty
    End Sub

    Public Sub New(ByVal id As Integer)
        _ID = id
        _Name = String.Empty
        _PostalCode = String.Empty
        _Address1 = String.Empty
        _Address2 = String.Empty
        _TEL = String.Empty
        _FAX = String.Empty
    End Sub

#End Region

#Region "値プロパティ"

    ''' <summary>
    ''' ID(オブジェクトの永続化がされていないものは-1)
    ''' </summary>
    Public ReadOnly Property ID As Integer

    Private _Name As String
    ''' <summary>
    ''' 会社名
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

    Private _PostalCode As String
    ''' <summary>
    ''' 郵便番号
    ''' </summary>
    ''' <returns></returns>
    Public Property PostalCode As String
        Get
            Return _PostalCode
        End Get
        Set(value As String)
            _PostalCode = value
            ValidatePostalCode()
        End Set
    End Property

    Private _Address1 As String
    ''' <summary>
    ''' 住所1
    ''' </summary>
    ''' <returns></returns>
    Public Property Address1 As String
        Get
            Return _Address1
        End Get
        Set(value As String)
            _Address1 = value
            ValidateAddress1()
        End Set
    End Property

    Private _Address2 As String
    ''' <summary>
    ''' 住所2
    ''' </summary>
    ''' <returns></returns>
    Public Property Address2 As String
        Get
            Return _Address2
        End Get
        Set(value As String)
            _Address2 = value
            ValidateAddress2()
        End Set
    End Property

    Private _TEL As String
    ''' <summary>
    ''' 電話番号
    ''' </summary>
    ''' <returns></returns>
    Public Property TEL As String
        Get
            Return _TEL
        End Get
        Set(value As String)
            _TEL = value
            ValidateTEL()
        End Set
    End Property

    Private _FAX As String
    ''' <summary>
    ''' FAX番号
    ''' </summary>
    ''' <returns></returns>
    Public Property FAX As String
        Get
            Return _FAX
        End Get
        Set(value As String)
            _FAX = value
            ValidateFAX()
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
    ''' オブジェクトの整合性チェックを実施
    ''' </summary>
    ''' <returns></returns>
    Public Function Validate() As Boolean
        ValidateName()
        ValidatePostalCode()
        ValidateAddress1()
        ValidateAddress2()
        ValidateTEL()
        ValidateFAX()

        Return Me.HasError = False
    End Function

    ''' <summary>
    ''' 会社名の検証
    ''' </summary>
    Private Sub ValidateName()
        'エラーを一度クリア
        _errors.Remove(NameOf(Name))

        '名前は未入力不可
        If _Name Is Nothing OrElse _Name.Length = 0 Then
            _errors(NameOf(Name)) = NameDoNotEmpty
            Return
        End If
        '名前は100文字以内
        If _Name.Length > 100 Then
            _errors(NameOf(Name)) = NameIsTooLong
        End If
    End Sub

    ''' <summary>
    ''' 郵便番号の検証
    ''' </summary>
    Private Sub ValidatePostalCode()
        'エラーを一度クリア
        _errors.Remove(NameOf(PostalCode))

        'Nothingは許可しない
        If _PostalCode Is Nothing Then
            _errors(NameOf(PostalCode)) = PostalCodeDoNotNothing
            Return
        End If

        '未入力ならチェック打ち切り
        If _PostalCode = String.Empty Then
            Return
        End If

        '郵便番号の形式を確認
        If Text.RegularExpressions.Regex.IsMatch(
            _PostalCode,
            "\A\d\d\d-\d\d\d\d\z",
            Text.RegularExpressions.RegexOptions.ECMAScript) = False Then
            _errors(NameOf(PostalCode)) = PostalCodeIsWrongFormat
        End If
    End Sub

    ''' <summary>
    ''' 住所1の検証
    ''' </summary>
    Private Sub ValidateAddress1()
        'エラーを一度クリア
        _errors.Remove(NameOf(Address1))

        'Nothingは許可しない
        If _Address1 Is Nothing Then
            _errors(NameOf(Address1)) = Address1DoNotNothing
            Return
        End If

        '住所1は50文字まで
        If _Address1.Length > 50 Then
            _errors(NameOf(Address1)) = Address1IsTooLong
        End If

    End Sub

    ''' <summary>
    ''' 住所2の検証
    ''' </summary>
    Private Sub ValidateAddress2()
        'エラーを一度クリア
        _errors.Remove(NameOf(Address2))

        'Nothingは許可しない
        If _Address1 Is Nothing Then
            _errors(NameOf(Address2)) = Address2DoNotNothing
            Return
        End If

        '住所1は50文字まで
        If _Address2.Length > 50 Then
            _errors(NameOf(Address2)) = Address2IsTooLong
        End If

    End Sub

    ''' <summary>
    ''' 電話番号の検証
    ''' </summary>
    Private Sub ValidateTEL()
        'エラーを一度クリア
        _errors.Remove(NameOf(TEL))

        'Nothingは許可しない
        If _TEL Is Nothing Then
            _errors(NameOf(TEL)) = TELDoNotNothing
            Return
        End If

        'TELは15文字まで
        If _TEL.Length > 15 Then
            _errors(NameOf(TEL)) = TELIsTooLong
        End If

        '電話番号っぽいかチェック
        If _TEL <> String.Empty AndAlso Text.RegularExpressions.Regex.IsMatch(
            _TEL,
            "\A0\d{1,4}-\d{1,4}-\d{4}\z") Then
            _errors(NameOf(TEL)) = TELIsWrongFormat
        End If

    End Sub

    ''' <summary>
    ''' FAX番号の検証
    ''' </summary>
    Private Sub ValidateFAX()
        'エラーを一度クリア
        _errors.Remove(NameOf(FAX))

        'Nothingは許可しない
        If _FAX Is Nothing Then
            _errors(NameOf(FAX)) = FAXDoNotNothing
            Return
        End If

        'FAXは15文字まで
        If _FAX.Length > 15 Then
            _errors(NameOf(FAX)) = FAXIsTooLong
        End If

        'FAX番号っぽいかチェック
        If _FAX <> String.Empty AndAlso Text.RegularExpressions.Regex.IsMatch(
            _FAX,
            "\A0\d{1,4}-\d{1,4}-\d{4}\z") Then
            _errors(NameOf(FAX)) = FAXIsWrongFormat
        End If

    End Sub

#End Region

#Region "オーバーライド"

    Public Overrides Function Equals(obj As Object) As Boolean
        '型が異なれば異なる
        If obj.GetType <> GetType(CompanyInformation) Then
            Return False
        End If
        Dim c = DirectCast(obj, CompanyInformation)

        'ID値が同じなら同じ
        Return Me.ID = c.ID
    End Function

#End Region

End Class
