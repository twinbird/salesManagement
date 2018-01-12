Option Strict On
Option Infer On

Imports System.Diagnostics
Imports Domain

''' <summary>
''' 自社情報の永続化のための機能
''' </summary>
Public Class CompanyInformationImpl
    Implements ICompanyInformationRepository

    ''' <summary>
    ''' 引数を永続化する
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Public Function Save(c As CompanyInformation) As Boolean Implements ICompanyInformationRepository.Save
        '登録済みなら更新/そうでなければ新規登録
        If IsExist() = True Then
            Return Update(c)
        Else
            Return Create(c)
        End If
    End Function

    ''' <summary>
    ''' 自社情報を取得する
    ''' </summary>
    ''' <returns></returns>
    Public Function Find() As CompanyInformation Implements ICompanyInformationRepository.Find
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    id AS id")
                .AppendLine("   ,name AS name")
                .AppendLine("   ,postal_code AS postal_code")
                .AppendLine("   ,address1 AS address1")
                .AppendLine("   ,address2 AS address2")
                .AppendLine("   ,tel AS tel")
                .AppendLine("   ,fax AS fax")
                .AppendLine("FROM")
                .AppendLine("   company_information")
            End With

            Dim dt = q.ExecQuery
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If

            Dim r = dt.Rows(0)
            Dim ci = New CompanyInformation(CInt(r("id")))
            With ci
                .Name = r("name").ToString
                .PostalCode = r("postal_code").ToString
                .Address1 = r("address1").ToString
                .Address2 = r("address2").ToString
                .TEL = r("tel").ToString
                .FAX = r("fax").ToString
            End With
            Return ci
        End Using
    End Function

#Region "Create"

    ''' <summary>
    ''' 引数の自社情報を新規に登録
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function Create(ByVal c As CompanyInformation) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO company_information(")
                .AppendLine(" name")
                .AppendLine(",postal_code")
                .AppendLine(",address1")
                .AppendLine(",address2")
                .AppendLine(",tel")
                .AppendLine(",fax")
                .AppendLine(",created_at")
                .AppendLine(")")
                .AppendLine("VALUES(")
                .AppendLine(" @name")
                .AppendLine(",@postal_code")
                .AppendLine(",@address1")
                .AppendLine(",@address2")
                .AppendLine(",@tel")
                .AppendLine(",@fax")
                .AppendLine(",@created_at")
                .AppendLine(")")
            End With

            With q.Parameters
                .Add("@name", c.Name)
                .Add("@postal_code", c.PostalCode)
                .Add("@address1", c.Address1)
                .Add("@address2", c.Address2)
                .Add("@tel", c.TEL)
                .Add("@fax", c.FAX)
                .Add("@created_at", DateTime.Now)
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
    ''' 自社情報が登録済みならTrue
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function IsExist() As Boolean
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    COUNT(id) AS count")
                .AppendLine("FROM")
                .AppendLine("   company_information")
            End With

            Dim count = q.ExecScalar
            If count Is Nothing Then
                Return False
            End If

            If CInt(count) = 0 Then
                Return False
            End If

            Debug.Assert(CInt(count) = 1)

            Return True
        End Using
    End Function

#End Region

#Region "Update"

    ''' <summary>
    ''' 自社情報を更新
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function Update(ByVal c As CompanyInformation) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("UPDATE")
                .AppendLine("    company_information")
                .AppendLine("SET")
                .AppendLine(" name = @name")
                .AppendLine(",postal_code = @postal_code")
                .AppendLine(",address1 = @address1")
                .AppendLine(",address2 = @address2")
                .AppendLine(",tel = @tel")
                .AppendLine(",fax = @fax")
                .AppendLine(",created_at = @created_at")
            End With

            With q.Parameters
                .Add("@name", c.Name)
                .Add("@postal_code", c.PostalCode)
                .Add("@address1", c.Address1)
                .Add("@address2", c.Address2)
                .Add("@tel", c.TEL)
                .Add("@fax", c.FAX)
                .Add("@created_at", DateTime.Now)
            End With

            Dim ret = q.ExecNonQuery

            If ret <> 1 Then
                Return False
            End If
            Return True
        End Using

    End Function

#End Region

End Class
