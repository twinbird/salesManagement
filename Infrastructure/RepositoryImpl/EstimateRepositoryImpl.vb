Option Strict On
Option Infer On
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
        'Debug.Assert(e.ID < 0)

        'Using accessor As New ADOWrapper.DBAccessor()
        '    accessor.BeginTransaction()

        '    Dim q = accessor.CreateQuery
        '    With q.Query
        '        .AppendLine("INSERT INTO employees(")
        '        .AppendLine(" employee_number")
        '        .AppendLine(",name")
        '        .AppendLine(",name_kana")
        '        .AppendLine(",created_at")
        '        .AppendLine(")")
        '        .AppendLine("VALUES(")
        '        .AppendLine(" @employee_number")
        '        .AppendLine(",@name")
        '        .AppendLine(",@name_kana")
        '        .AppendLine(",@created_at")
        '        .AppendLine(")")
        '    End With

        '    With q.Parameters
        '        .Add("@employee_number", e.EmployeeNo)
        '        .Add("@name", e.Name)
        '        .Add("@name_kana", e.NameKana)
        '        .Add("@created_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        '    End With

        '    Dim ret = q.ExecNonQuery

        '    If ret <> 1 Then
        '        accessor.RollBack()
        '        Return False
        '    End If

        '    Dim check_q = accessor.CreateQuery
        '    With check_q.Query
        '        .AppendLine("SELECT")
        '        .AppendLine("   last_insert_rowid()")
        '    End With

        '    Dim check_ret = check_q.ExecScalar
        '    _LastInsertId = CType(check_ret, Integer)

        '    accessor.Commit()

        '    Return True
        'End Using
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
        'Using accessor As New ADOWrapper.DBAccessor
        '    accessor.BeginTransaction()

        '    Dim q = accessor.CreateQuery
        '    With q.Query
        '        .AppendLine("UPDATE")
        '        .AppendLine("   employees")
        '        .AppendLine("SET")
        '        .AppendLine("    employee_number = @employee_number")
        '        .AppendLine("   ,name = @name")
        '        .AppendLine("   ,name_kana = @name_kana")
        '        .AppendLine("   ,updated_at = @updated_at")
        '        .AppendLine("WHERE")
        '        .AppendLine("   id = @id")
        '    End With

        '    With q.Parameters
        '        .Add("@employee_number", e.EmployeeNo)
        '        .Add("@name", e.Name)
        '        .Add("@name_kana", e.NameKana)
        '        .Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        '        .Add("@id", e.ID)
        '    End With

        '    Dim ret = q.ExecNonQuery

        '    If ret <> 1 Then
        '        accessor.RollBack()
        '        Return False
        '    End If

        '    accessor.Commit()
        '    Return True

        'End Using
    End Function

#End Region


End Class
