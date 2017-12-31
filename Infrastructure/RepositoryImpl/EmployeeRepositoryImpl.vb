Option Strict On
Option Infer On

Imports System.Collections.Generic
Imports System.Diagnostics
Imports Domain

''' <summary>
''' 従業員情報永続化のための機能
''' </summary>
Public Class EmployeeRepositoryImpl
    Implements IEmployeeRepository

    ''' <summary>
    ''' 引数の従業員情報を永続化します
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Public Function Save(e As Employee) As Boolean Implements IEmployeeRepository.Save
        '登録済みなら更新/そうでなければ新規登録
        If IsExist(e) = True Then
            Return Update(e)
        Else
            Return Create(e)
        End If
    End Function

    ''' <summary>
    ''' 最後に永続化したオブジェクトのIDを返す
    ''' </summary>
    ''' <returns></returns>
    Public Function LastInsertID() As Integer Implements IEmployeeRepository.LastInsertID
        Return _LastInsertId
    End Function

    ''' <summary>
    ''' 従業員番号からモデルオブジェクトを取得
    ''' </summary>
    ''' <returns></returns>
    Public Function FindByEmployeeNo(ByVal empNo As String) As Domain.Employee Implements IEmployeeRepository.FindByEmployeeNo
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    id AS id")
                .AppendLine("   ,employee_number AS employee_number")
                .AppendLine("   ,name AS name")
                .AppendLine("   ,name_kana AS name_kana")
                .AppendLine("FROM")
                .AppendLine("   employees")
                .AppendLine("WHERE")
                .AppendLine("   employee_number = @employee_number")
            End With

            With q.Parameters
                .Add("@employee_number", empNo)
            End With

            Dim dt = q.ExecQuery
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If

            Debug.Assert(dt.Rows.Count = 1)

            'データをモデルに設定して返す
            Dim e = New Domain.Employee(CInt(dt.Rows(0)("id").ToString), Me)
            e.EmployeeNo = dt.Rows(0)("employee_number").ToString
            e.Name = dt.Rows(0)("name").ToString
            e.NameKana = dt.Rows(0)("name_kana").ToString

            Return e
        End Using
    End Function

    ''' <summary>
    ''' 登録済みの従業員のすべてのモデルオブジェクトを取得
    ''' </summary>
    ''' <returns></returns>
    Public Function FindAllEmployee() As List(Of Employee) Implements IEmployeeRepository.FindAllEmployee
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    id AS id")
                .AppendLine("   ,employee_number AS employee_number")
                .AppendLine("   ,name AS name")
                .AppendLine("   ,name_kana AS name_kana")
                .AppendLine("FROM")
                .AppendLine("   employees")
            End With

            Dim dt = q.ExecQuery
            If dt Is Nothing Then
                Return Nothing
            End If

            'データをモデルに設定して返す
            Dim ret As New List(Of Employee)

            For Each r As Data.DataRow In dt.Rows
                Dim e = New Domain.Employee(CInt(r("id").ToString), Me)
                e.EmployeeNo = r("employee_number").ToString
                e.Name = r("name").ToString
                e.NameKana = r("name_kana").ToString

                ret.Add(e)
            Next

            Return ret
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
    ''' 引数の従業員情報を新規にDBへ登録
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Private Function Create(e As Employee) As Boolean
        Debug.Assert(e.ID < 0)

        Using accessor As New ADOWrapper.DBAccessor()
            accessor.BeginTransaction()

            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO employees(")
                .AppendLine(" employee_number")
                .AppendLine(",name")
                .AppendLine(",name_kana")
                .AppendLine(",created_at")
                .AppendLine(")")
                .AppendLine("VALUES(")
                .AppendLine(" @employee_number")
                .AppendLine(",@name")
                .AppendLine(",@name_kana")
                .AppendLine(",@created_at")
                .AppendLine(")")
            End With

            With q.Parameters
                .Add("@employee_number", e.EmployeeNo)
                .Add("@name", e.Name)
                .Add("@name_kana", e.NameKana)
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
            _LastInsertId = CType(check_ret, Integer)

            accessor.Commit()

            Return True
        End Using
    End Function

#End Region

#Region "Refer"

    ''' <summary>
    ''' 引数の従業員情報がすでにDBに登録されていればTrue
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Private Function IsExist(e As Employee) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("   COUNT(id) AS COUNT")
                .AppendLine("FROM")
                .AppendLine("   employees")
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
    ''' 引数の登録済み従業員情報をDBへ更新
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    Private Function Update(e As Employee) As Boolean
        Using accessor As New ADOWrapper.DBAccessor
            accessor.BeginTransaction()

            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("UPDATE")
                .AppendLine("   employees")
                .AppendLine("SET")
                .AppendLine("    employee_number = @employee_number")
                .AppendLine("   ,name = @name")
                .AppendLine("   ,name_kana = @name_kana")
                .AppendLine("   ,updated_at = @updated_at")
                .AppendLine("WHERE")
                .AppendLine("   id = @id")
            End With

            With q.Parameters
                .Add("@employee_number", e.EmployeeNo)
                .Add("@name", e.Name)
                .Add("@name_kana", e.NameKana)
                .Add("@updated_at", DateTime.Now)
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
