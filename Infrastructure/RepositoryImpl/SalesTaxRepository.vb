Option Strict On
Option Infer On
Imports System.Collections.Generic
Imports Domain

''' <summary>
''' 消費税率の永続化機能
''' </summary>
Public Class SalesTaxRepository
    Implements ISalesTaxRepository

#Region "インスタンス変数"

    Private _LastInsertID As Integer

#End Region

    ''' <summary>
    ''' 引数を永続化する
    ''' </summary>
    ''' <param name="tax"></param>
    ''' <returns></returns>
    Public Function Save(tax As SalesTax) As Boolean Implements ISalesTaxRepository.Save
        '登録済みなら更新/そうでなければ新規登録
        If IsExist(tax) = True Then
            Return Update(tax)
        Else
            Return Create(tax)
        End If
    End Function

    ''' <summary>
    ''' 指定日付の税率を取得する
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    Public Function TaxOn(d As Date) As SalesTax Implements ISalesTaxRepository.TaxOn
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    apply_start_date AS apply_start_date")
                .AppendLine("   ,rate AS tax_rate")
                .AppendLine("FROM")
                .AppendLine("   sales_taxes")
                .AppendLine("WHERE")
                .AppendLine("   apply_start_date <= @apply_start_date")
                .AppendLine("GROUP BY")
                .AppendLine("   apply_start_date")
                .AppendLine("HAVING")
                .AppendLine("   apply_start_date = MIN(apply_start_date)")
            End With

            With q.Parameters
                .Add("@apply_start_date", d)
            End With

            Dim dt = q.ExecQuery
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If

            Dim tax = New SalesTax(Me)
            tax.ApplyStartDate = CDate(dt.Rows(0)("apply_start_date"))
            tax.TaxRate = CDec(dt.Rows(0)("tax_rate"))

            Return tax
        End Using
    End Function

    ''' <summary>
    ''' 登録済みのすべての税率情報を取得する
    ''' </summary>
    ''' <returns></returns>
    Public Function FindAll() As List(Of SalesTax) Implements ISalesTaxRepository.FindAll
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    apply_start_date AS apply_start_date")
                .AppendLine("   ,rate AS tax_rate")
                .AppendLine("FROM")
                .AppendLine("   sales_taxes")
            End With

            Dim dt = q.ExecQuery
            If dt Is Nothing Then
                Return Nothing
            End If

            Dim ret As New List(Of SalesTax)
            For Each r As Data.DataRow In dt.Rows
                Dim tax = New SalesTax(Me)
                tax.ApplyStartDate = CDate(r("apply_start_date"))
                tax.TaxRate = CDec(r("tax_rate"))
                ret.Add(tax)
            Next

            Return ret
        End Using
    End Function

    ''' <summary>
    ''' 適用開始日から税率を取得する
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    Public Function FindByApplyDate(d As Date) As SalesTax Implements ISalesTaxRepository.FindByApplyDate
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    apply_start_date AS apply_start_date")
                .AppendLine("   ,rate AS tax_rate")
                .AppendLine("FROM")
                .AppendLine("   sales_taxes")
                .AppendLine("WHERE")
                .AppendLine("   apply_start_date = @apply_start_date")
            End With

            With q.Parameters
                .Add("@apply_start_date", d)
            End With

            Dim dt = q.ExecQuery
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If

            Dim tax = New SalesTax(Me)
            tax.ApplyStartDate = CDate(dt.Rows(0)("apply_start_date"))
            tax.TaxRate = CDec(dt.Rows(0)("tax_rate"))

            Return tax
        End Using
    End Function

    ''' <summary>
    ''' 最後に新規登録したオブジェクトのIDを返す
    ''' </summary>
    ''' <returns></returns>
    Public Function LastInsertID() As Integer Implements ISalesTaxRepository.LastInsertID
        Return _LastInsertID
    End Function

#Region "Create"

    ''' <summary>
    ''' 引数の税率を新規に登録
    ''' </summary>
    ''' <param name="t"></param>
    ''' <returns></returns>
    Private Function Create(ByVal t As SalesTax) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            accessor.BeginTransaction()

            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO sales_taxes(")
                .AppendLine(" apply_start_date")
                .AppendLine(",rate")
                .AppendLine(",created_at")
                .AppendLine(")")
                .AppendLine("VALUES(")
                .AppendLine(" @apply_start_date")
                .AppendLine(",@rate")
                .AppendLine(",@created_at")
                .AppendLine(")")
            End With

            With q.Parameters
                .Add("@name", t.ApplyStartDate)
                .Add("@rate", t.TaxRate)
                .Add("@created_at", DateTime.Now)
            End With

            Dim ret = q.ExecNonQuery
            If ret <> 1 Then
                accessor.RollBack()
                Return False
            End If


            Dim check_q = accessor.CreateQuery
            With check_q.Query
                .AppendLine("SELECT")
                .AppendLine("   last_insert_rowid()")
            End With

            Dim check_ret = check_q.ExecScalar
            _LastInsertID = CType(check_ret, Integer)

            accessor.Commit()

            Return True
        End Using
    End Function

#End Region

#Region "Refer"

    ''' <summary>
    ''' このIDの税率情報が登録済みならTrue
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function IsExist(ByVal t As SalesTax) As Boolean
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    COUNT(id) AS count")
                .AppendLine("FROM")
                .AppendLine("   sales_taxes")
                .AppendLine("WHERE")
                .AppendLine("   id = @id")
            End With

            With q.Parameters
                .Add("@id", t.ID)
            End With

            Dim count = q.ExecScalar
            If count Is Nothing Then
                Return False
            End If

            If CInt(count) = 0 Then
                Return False
            End If

            Return True
        End Using
    End Function

#End Region

#Region "Update"

    ''' <summary>
    ''' 引数のオブジェクトを更新
    ''' </summary>
    ''' <param name="t"></param>
    ''' <returns></returns>
    Private Function Update(ByVal t As SalesTax) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("UPDATE")
                .AppendLine("    sales_taxes")
                .AppendLine("SET")
                .AppendLine(" apply_start_date = @apply_start_date")
                .AppendLine(",rate = @rate")
                .AppendLine(",updated_at = @updated_at")
            End With

            With q.Parameters
                .Add("@apply_start_date", t.ApplyStartDate)
                .Add("@rate", t.TaxRate)
                .Add("@updated_at", DateTime.Now)
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
