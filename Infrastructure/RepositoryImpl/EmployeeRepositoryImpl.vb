Option Strict On
Option Infer On
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
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("   last_insert_rowid()")
            End With

            Dim check_ret = q.ExecScalar
            _LastInsertId = DirectCast(check_ret, Integer)

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
