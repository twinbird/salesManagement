Option Strict On
Option Infer On
Imports Domain

''' <summary>
''' 顧客情報永続化のための機能
''' </summary>
Public Class CustomerRepositoryImpl
    Implements ICustomerRepository

#Region "インターフェース"

    Public Function Save(c As Customer) As Boolean Implements ICustomerRepository.Save
        '登録済みなら更新/そうでなければ新規登録
        If IsExist(c) = True Then
            Return Update(c)
        Else
            Return Create(c)
        End If
    End Function

#End Region

#Region "Create"

    ''' <summary>
    ''' 引数の顧客情報を新規にDBへ登録
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function Create(c As Customer) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO customers(")
                .AppendLine("")
                .AppendLine(")")
                .AppendLine("VALUES(")
                .AppendLine(")")
            End With

            Dim ret = q.ExecNonQuery

            If ret <> 1 Then
                Return False
            End If
            Return True
        End Using
    End Function

#End Region

#Region "Refer"

    ''' <summary>
    ''' 引数の顧客情報がすでにDBに登録されていればTrue
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function IsExist(c As Customer) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()

        End Using
    End Function

#End Region

#Region "Update"

    ''' <summary>
    ''' 引数の登録済み顧客情報がDBへ更新
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function Update(c As Customer) As Boolean

    End Function

#End Region

#Region "Delete"


#End Region

End Class
