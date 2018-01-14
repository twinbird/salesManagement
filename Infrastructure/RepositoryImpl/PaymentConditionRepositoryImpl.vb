Option Strict On
Option Infer On
Imports System.Collections.Generic
Imports System.Diagnostics
Imports Domain

''' <summary>
''' 支払条件永続化のための機能
''' </summary>
Public Class PaymentConditionRepositoryImpl
    Implements IPaymentConditionRepository

    ''' <summary>
    ''' 引数の支払条件を永続化します
    ''' </summary>
    ''' <param name="pc"></param>
    ''' <returns></returns>
    Public Function Save(pc As PaymentCondition) As Boolean Implements IPaymentConditionRepository.Save
        '登録前にバリデーションする
        If pc.Validate = False Then
            Return False
        End If
        '登録済みなら更新/そうでなければ新規登録
        If IsExist(pc) = True Then
            Return Update(pc)
        Else
            Return Create(pc)
        End If
    End Function

    ''' <summary>
    ''' 最後に永続化したオブジェクトのIDを返します
    ''' </summary>
    ''' <returns></returns>
    Public Function LastInsertID() As Integer Implements IPaymentConditionRepository.LastInsertID
        Return _LastInsertId
    End Function

    ''' <summary>
    ''' IDから支払条件モデルオブジェクトを取得
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function FindByID(id As Integer) As PaymentCondition Implements IPaymentConditionRepository.FindByID
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    id AS id")
                .AppendLine("   ,name AS name")
                .AppendLine("   ,cut_off AS cut_off")
                .AppendLine("   ,due_date AS due_date")
                .AppendLine("   ,month_offset AS month_offset")
                .AppendLine("FROM")
                .AppendLine("   payment_conditions")
                .AppendLine("WHERE")
                .AppendLine("   id = @id")
            End With

            With q.Parameters
                .Add("@id", id)
            End With

            Dim dt = q.ExecQuery
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If

            Debug.Assert(dt.Rows.Count = 1)

            'データをモデルに設定して返す
            Dim pc = New PaymentCondition(CInt(dt.Rows(0)("id").ToString), Me)
            pc.Name = dt.Rows(0)("name").ToString
            pc.CutOff = CInt(dt.Rows(0)("cut_off"))
            pc.DueDate = CInt(dt.Rows(0)("due_date"))
            pc.MonthOffset = CInt(dt.Rows(0)("month_offset"))

            Return pc
        End Using
    End Function

    ''' <summary>
    ''' 引数の名前から支払条件オブジェクトを取得します
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Public Function FindByName(name As String) As PaymentCondition Implements IPaymentConditionRepository.FindByName
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    id AS id")
                .AppendLine("   ,name AS name")
                .AppendLine("   ,cut_off AS cut_off")
                .AppendLine("   ,due_date AS due_date")
                .AppendLine("   ,month_offset AS month_offset")
                .AppendLine("FROM")
                .AppendLine("   payment_conditions")
                .AppendLine("WHERE")
                .AppendLine("   name = @name")
            End With

            With q.Parameters
                .Add("@name", name)
            End With

            Dim dt = q.ExecQuery
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If

            Debug.Assert(dt.Rows.Count = 1)

            'データをモデルに設定して返す
            Dim pc = New PaymentCondition(CInt(dt.Rows(0)("id").ToString), Me)
            pc.Name = dt.Rows(0)("name").ToString
            pc.CutOff = CInt(dt.Rows(0)("cut_off"))
            pc.DueDate = CInt(dt.Rows(0)("due_date"))
            pc.MonthOffset = CInt(dt.Rows(0)("month_offset"))

            Return pc
        End Using
    End Function

    ''' <summary>
    ''' 登録済みの支払条件を全て取得します
    ''' </summary>
    ''' <returns></returns>
    Public Function FindAllPaymentCondition() As List(Of PaymentCondition) Implements IPaymentConditionRepository.FindAllPaymentCondition
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    id AS id")
                .AppendLine("   ,name AS name")
                .AppendLine("   ,cut_off AS cut_off")
                .AppendLine("   ,due_date AS due_date")
                .AppendLine("   ,month_offset AS month_offset")
                .AppendLine("FROM")
                .AppendLine("   payment_conditions")
            End With

            Dim dt = q.ExecQuery
            If dt Is Nothing Then
                Return Nothing
            End If

            'データをモデルに設定して返す
            Dim ret As New List(Of PaymentCondition)

            For Each r As Data.DataRow In dt.Rows
                Dim pc = New PaymentCondition(CInt(r("id").ToString), Me)
                pc.Name = r("name").ToString
                pc.CutOff = CInt(r("cut_off"))
                pc.DueDate = CInt(r("due_date"))
                pc.MonthOffset = CInt(r("month_offset"))
                ret.Add(pc)
            Next

            Return ret
        End Using
    End Function

    ''' <summary>
    ''' 引数の条件を満たした支払条件を取得する
    ''' </summary>
    ''' <param name="cond"></param>
    ''' <returns></returns>
    Public Function FindPaymentConditionByCondition(cond As PaymentConditionRepositorySearchCondition) As List(Of PaymentCondition) Implements IPaymentConditionRepository.FindPaymentConditionByCondition
        Using accessor As New ADOWrapper.DBAccessor
            '===============================================
            'クエリの作成
            '===============================================
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    id AS id")
                .AppendLine("   ,name AS name")
                .AppendLine("   ,cut_off AS cut_off")
                .AppendLine("   ,due_date AS due_date")
                .AppendLine("   ,month_offset AS month_offset")
                .AppendLine("FROM")
                .AppendLine("   payment_conditions")
                .AppendLine("WHERE")
                .AppendLine("   1 = 1")

                '支払条件名(前方一致)
                If cond.PaymentConditionNameForwardMatch <> String.Empty Then
                    .AppendLine("AND")
                    .AppendLine("   name LIKE @name")
                End If
            End With

            '===============================================
            'パラメータ設定
            '===============================================
            With q.Parameters
                '支払条件名(前方一致)
                If cond.PaymentConditionNameForwardMatch <> String.Empty Then
                    .Add("@name", cond.PaymentConditionNameForwardMatch & "%")
                End If
            End With

            Dim dt = q.ExecQuery
            If dt Is Nothing Then
                Return Nothing
            End If

            'データをモデルに設定して返す
            Dim ret As New List(Of PaymentCondition)

            For Each r As Data.DataRow In dt.Rows
                Dim pc = New PaymentCondition(CInt(r("id").ToString), Me)
                pc.Name = r("name").ToString
                pc.CutOff = CInt(r("cut_off"))
                pc.DueDate = CInt(r("due_date"))
                pc.MonthOffset = CInt(r("month_offset"))
                ret.Add(pc)
            Next

            Return ret
        End Using
    End Function

    ''' <summary>
    ''' 登録されている支払条件数を取得する
    ''' </summary>
    ''' <returns></returns>
    Public Function CountAllPaymentCondition() As Integer Implements IPaymentConditionRepository.CountAllPaymentCondition
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    COUNT(id) AS payment_condition_count")
                .AppendLine("FROM")
                .AppendLine("   payment_conditions")
            End With

            Dim count = q.ExecScalar
            If count Is Nothing Then
                Return 0
            End If

            Return CType(count, Integer)
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
    ''' 引数の支払条件情報を新規にDBへ登録
    ''' </summary>
    ''' <param name="pc"></param>
    ''' <returns></returns>
    Private Function Create(pc As PaymentCondition) As Boolean
        Debug.Assert(pc.ID < 0)

        Using accessor As New ADOWrapper.DBAccessor()
            accessor.BeginTransaction()

            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO payment_conditions(")
                .AppendLine(" name")
                .AppendLine(",cut_off")
                .AppendLine(",due_date")
                .AppendLine(",month_offset")
                .AppendLine(",created_at")
                .AppendLine(")")
                .AppendLine("VALUES(")
                .AppendLine(" @name")
                .AppendLine(",@cut_off")
                .AppendLine(",@due_date")
                .AppendLine(",@month_offset")
                .AppendLine(",@created_at")
                .AppendLine(")")
            End With

            With q.Parameters
                .Add("@name", pc.Name)
                .Add("@cut_off", pc.CutOff)
                .Add("@due_date", pc.DueDate)
                .Add("@month_offset", pc.MonthOffset)
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
            _LastInsertId = CType(check_ret, Integer)

            accessor.Commit()

            Return True
        End Using
    End Function

#End Region

#Region "Refer"

    ''' <summary>
    ''' 引数の支払条件情報がすでにDBに登録されていればTrue
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Private Function IsExist(e As PaymentCondition) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("   COUNT(id) AS COUNT")
                .AppendLine("FROM")
                .AppendLine("   payment_conditions")
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
    ''' 引数の登録済み支払条件情報をDBへ更新
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Private Function Update(e As PaymentCondition) As Boolean
        Using accessor As New ADOWrapper.DBAccessor
            accessor.BeginTransaction()

            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("UPDATE")
                .AppendLine("   payment_conditions")
                .AppendLine("SET")
                .AppendLine("    name = @name")
                .AppendLine("   ,cut_off = @cut_off")
                .AppendLine("   ,due_date = @due_date")
                .AppendLine("   ,month_offset = @month_offset")
                .AppendLine("   ,updated_at = @updated_at")
                .AppendLine("WHERE")
                .AppendLine("   id = @id")
            End With

            With q.Parameters
                .Add("@name", e.Name)
                .Add("@cut_off", e.CutOff)
                .Add("@due_date", e.DueDate)
                .Add("@month_offset", e.MonthOffset)
                .Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Add("@id", e.ID)
            End With

            Dim ret = q.ExecNonQuery

            If ret <> 1 Then
                accessor.RollBack()
                Return False
            End If

            accessor.Commit()
            Return True

        End Using
    End Function

#End Region

End Class
