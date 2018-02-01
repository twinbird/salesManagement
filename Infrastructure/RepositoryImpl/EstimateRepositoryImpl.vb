Option Strict On
Option Infer On
Imports System.Collections.Generic
Imports System.Diagnostics
Imports Domain

''' <summary>
''' 見積永続化のための機能
''' </summary>
Public Class EstimateRepositoryImpl
    Implements Domain.IEstimateRepository

    ''' <summary>
    ''' 見積の永続化
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Public Function Save(e As Estimate) As Boolean Implements IEstimateRepository.Save
        '登録前にバリデーションする
        If e.Validate = False Then
            Return False
        End If
        '登録済みなら更新/そうでなければ新規登録
        If IsExist(e) = True Then
            Return Update(e)
        Else
            Return Create(e)
        End If
    End Function

    ''' <summary>
    ''' 最後に新規登録したIDを返す
    ''' </summary>
    ''' <returns></returns>
    Public Function LastInsertID() As Integer Implements IEstimateRepository.LastInsertID
        Return _LastInsertId
    End Function

    ''' <summary>
    ''' 指定日付に作られた見積の数を返す
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    Public Function CountEstimateOnDay(d As Date) As Integer Implements IEstimateRepository.CountEstimateOnDay
        Using accessor As New ADOWrapper.DBAccessor()
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("   COUNT(id) AS COUNT")
                .AppendLine("FROM")
                .AppendLine("   estimates")
                .AppendLine("WHERE")
                .AppendLine("   created_at > strftime(@created_at_start)")
                .AppendLine("AND")
                .AppendLine("   created_at < strftime(@created_at_end)")
            End With

            '翌日の開始時刻
            Dim next_day = d.AddDays(1)
            Dim next_start = New Date(next_day.Year, next_day.Month, next_day.Day, 0, 0, 0)
            '前日の終了時刻
            Dim prev_day = d.AddDays(-1)
            Dim prev_end = New Date(prev_day.Year, prev_day.Month, prev_day.Day, 23, 59, 59)

            With q.Parameters
                .Add("@created_at_start", next_start.ToString("yyyy-MM-dd HH:mm:ss"))
                .Add("@created_at_end", prev_end.ToString("yyyy-MM-dd HH:mm:ss"))
            End With

            Dim n = q.ExecScalar()
            Return CInt(n)
        End Using
    End Function

    ''' <summary>
    ''' 登録済みの見積の件数を返す
    ''' </summary>
    ''' <returns></returns>
    Public Function CountAllEstimate() As Integer Implements IEstimateRepository.CountAllEstimate
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("   COUNT(id) AS COUNT")
                .AppendLine("FROM")
                .AppendLine("   estimates")
            End With

            Dim n = q.ExecScalar()
            Return CInt(n)

        End Using
    End Function

#Region "インスタンス変数"

    ''' <summary>
    ''' 最後に永続化したオブジェクトのID
    ''' </summary>
    Private _LastInsertId As Integer

#End Region

#Region "Create"

    ''' <summary>
    ''' 引数の見積情報を新規にDBへ登録
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Private Function Create(e As Estimate) As Boolean
        Debug.Assert(e.ID < 0)

        Using accessor As New ADOWrapper.DBAccessor()
            accessor.BeginTransaction()

            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO estimates(")
                .AppendLine(" estimate_number")
                .AppendLine(",customer_id")
                .AppendLine(",title")
                .AppendLine(",due_date")
                .AppendLine(",payment_id")
                .AppendLine(",pic_employee_id")
                .AppendLine(",apply_tax_id")
                .AppendLine(",print_date")
                .AppendLine(",effective_date")
                .AppendLine(",remarks")
                .AppendLine(",created_at")
                .AppendLine(")")
                .AppendLine("VALUES(")
                .AppendLine(" @estimate_number")
                .AppendLine(",@customer_id")
                .AppendLine(",@title")
                .AppendLine(",@due_date")
                .AppendLine(",@payment_id")
                .AppendLine(",@pic_employee_id")
                .AppendLine(",@apply_tax_id")
                .AppendLine(",@print_date")
                .AppendLine(",@effective_date")
                .AppendLine(",@remarks")
                .AppendLine(",@created_at")
                .AppendLine(")")
            End With

            With q.Parameters
                .Add("@estimate_number", e.EstimateNo)
                .Add("@customer_id", e.Customer.ID)
                .Add("@title", e.Title)
                .Add("@due_date", e.DueDate.ToString("yyyy-MM-dd HH:mm:ss"))
                .Add("@payment_id", e.PaymentCondition.ID)
                .Add("@pic_employee_id", e.PICEmployee.ID)
                .Add("@apply_tax_id", e.SalesTax.ID)
                .Add("@print_date", e.IssueDate.ToString("yyyy-MM-dd HH:mm:ss"))
                .Add("@effective_date", e.EffectiveDate.ToString("yyyy-MM-dd HH:mm:ss"))
                .Add("@remarks", e.Remarks)
                .Add("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
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
            Dim inserted_id = CType(check_ret, Integer)

            '=========================================
            '明細を登録
            '=========================================
            For Each d As EstimateDetail In e.Details
                CreateDetail(accessor, d, inserted_id)
            Next

            _LastInsertId = inserted_id

            accessor.Commit()

            Return True
        End Using
    End Function

    ''' <summary>
    ''' 明細レコードを新規作成
    ''' </summary>
    ''' <param name="accessor"></param>
    ''' <returns>ロールバックが必要ならfalse</returns>
    Private Function CreateDetail(ByVal accessor As ADOWrapper.DBAccessor, d As EstimateDetail, eid As Integer) As Boolean
        Debug.Assert(d.ID < 0)

        Dim q = accessor.CreateQuery
        With q.Query
            .AppendLine("INSERT INTO estimate_details(")
            .AppendLine(" estimate_id")
            .AppendLine(",display_order")
            .AppendLine(",item_name")
            .AppendLine(",quantity")
            .AppendLine(",unit_price")
            .AppendLine(",created_at")
            .AppendLine(")")
            .AppendLine("VALUES(")
            .AppendLine(" @estimate_id")
            .AppendLine(",@display_order")
            .AppendLine(",@item_name")
            .AppendLine(",@quantity")
            .AppendLine(",@unit_price")
            .AppendLine(",@created_at")
            .AppendLine(")")
        End With

        With q.Parameters
            .Add("@estimate_id", eid)
            .Add("@display_order", d.DisplayOrder)
            .Add("@item_name", d.ItemName)
            .Add("@quantity", d.Quantity)
            .Add("@unit_price", d.UnitPrice)
            .Add("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        End With

        Dim ret = q.ExecNonQuery

        If ret <> 1 Then
            Return False
        End If

        Return True

    End Function

#End Region

#Region "Refer"

    ''' <summary>
    ''' 引数の見積情報がすでにDBに登録されていればTrue
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Private Function IsExist(e As Estimate) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("   COUNT(id) AS COUNT")
                .AppendLine("FROM")
                .AppendLine("   estimates")
                .AppendLine("WHERE")
                .AppendLine("   id = @id")
            End With

            With q.Parameters
                .Add("@id", e.ID)
            End With

            Dim n = q.ExecScalar()
            If CType(n, Decimal) <> 1 Then
                Return False
            End If
            Return True
        End Using
    End Function

#End Region

#Region "Update"

    ''' <summary>
    ''' 引数の登録済み見積情報をDBへ更新
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Private Function Update(e As Estimate) As Boolean
        Using accessor As New ADOWrapper.DBAccessor
            accessor.BeginTransaction()

            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("UPDATE")
                .AppendLine("   estimates")
                .AppendLine("SET")
                .AppendLine(" estimate_number = @estimate_number")
                .AppendLine(",customer_id = @customer_id")
                .AppendLine(",title = @title")
                .AppendLine(",due_date = @due_date")
                .AppendLine(",payment_id = payment_id")
                .AppendLine(",pic_employee_id = @pic_employee_id")
                .AppendLine(",apply_tax_id = @apply_tax_id")
                .AppendLine(",print_date = @print_date")
                .AppendLine(",effective_date = @effective_date")
                .AppendLine(",remarks = @remarks")
                .AppendLine(",updated_at = @updated_at")
                .AppendLine("WHERE")
                .AppendLine("   id = @id")
            End With

            With q.Parameters
                .Add("@estimate_number", e.EstimateNo)
                .Add("@customer_id", e.Customer.ID)
                .Add("@title", e.Title)
                .Add("@due_date", e.DueDate.ToString("yyyy-MM-dd HH:mm:ss"))
                .Add("@payment_id", e.PaymentCondition.ID)
                .Add("@pic_employee_id", e.PICEmployee.ID)
                .Add("@apply_tax_id", e.SalesTax.ID)
                .Add("@print_date", e.IssueDate.ToString("yyyy-MM-dd HH:mm:ss"))
                .Add("@effective_date", e.EffectiveDate.ToString("yyyy-MM-dd HH:mm:ss"))
                .Add("@remarks", e.Remarks)
                .Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            End With

            Dim ret = q.ExecNonQuery

            If ret <> 1 Then
                accessor.RollBack()
                Return False
            End If

            '=========================================
            '明細を更新
            '=========================================
            For Each d As EstimateDetail In e.Details
                UpdateDetail(accessor, d, e.ID)
            Next
            '=========================================
            '明細を削除
            '=========================================
            DeleteDetail(accessor, e.Details, e.ID)

            accessor.Commit()
            Return True

        End Using
    End Function

    ''' <summary>
    ''' 明細レコードを更新
    ''' </summary>
    ''' <param name="accessor"></param>
    ''' <returns>ロールバックが必要ならfalse</returns>
    Private Function UpdateDetail(ByVal accessor As ADOWrapper.DBAccessor, d As EstimateDetail, eid As Integer) As Boolean
        Debug.Assert(d.ID >= 0)

        Dim q = accessor.CreateQuery
        With q.Query
            .AppendLine("UPDATE")
            .AppendLine("   estimate_details")
            .AppendLine("SET")
            .AppendLine(" estimate_id = @estimate_id")
            .AppendLine(",display_order = @display_order")
            .AppendLine(",item_name = @item_name")
            .AppendLine(",quantity = @quantity")
            .AppendLine(",unit_price = @unit_price")
            .AppendLine(",updated_at = @updated_at")
            .AppendLine("WHERE")
            .AppendLine("   id = @id")
        End With

        With q.Parameters
            .Add("@id", d.ID)
            .Add("@estimate_id", eid)
            .Add("@display_order", d.DisplayOrder)
            .Add("@item_name", d.ItemName)
            .Add("@quantity", d.Quantity)
            .Add("@unit_price", d.UnitPrice)
            .Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        End With

        Dim ret = q.ExecNonQuery

        If ret <> 1 Then
            Return False
        End If

        Return True

    End Function

#End Region

#Region "Delete"

    ''' <summary>
    ''' 明細レコードを削除
    ''' </summary>
    ''' <returns>ロールバックが必要ならfalse</returns>
    Private Function DeleteDetail(ByVal accessor As ADOWrapper.DBAccessor, ByVal details As List(Of EstimateDetail), eid As Integer) As Boolean
        Dim q = accessor.CreateQuery
        With q.Query
            .AppendLine("DELETE")
            .AppendLine("   estimate_details")
            .AppendLine("WHERE")
            .AppendLine("   id NOT IN(")
            For Each d As EstimateDetail In details
                .AppendLine("@" + d.ID.ToString)
            Next
            .AppendLine("   )")
        End With

        With q.Parameters
            For Each d As EstimateDetail In details
                .Add("@" + d.ID.ToString, d.ID)
            Next
        End With

        Dim ret = q.ExecNonQuery

        Return True

    End Function

#End Region

End Class
