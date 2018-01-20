Option Strict On
Option Infer On
Imports System.Collections.Generic
Imports Domain

''' <summary>
''' 顧客情報永続化のための機能
''' </summary>
Public Class CustomerRepositoryImpl
    Implements Domain.ICustomerRepository

#Region "インターフェース"

    ''' <summary>
    ''' 引数の顧客情報を永続化します
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Public Function Save(c As Customer) As Boolean Implements ICustomerRepository.Save
        '登録前にバリデーションする
        If c.Validate = False Then
            Return False
        End If
        '登録済みなら更新/そうでなければ新規登録
        If IsExist(c) = True Then
            Return Update(c)
        Else
            Return Create(c)
        End If
    End Function

    ''' <summary>
    ''' 顧客名と住所から顧客のオブジェクトを得る
    ''' </summary>
    ''' <param name="custName"></param>
    ''' <param name="addr1"></param>
    ''' <param name="addr2"></param>
    ''' <returns></returns>
    Public Function FindByCustomerNameAndAddress(custName As String, addr1 As String, addr2 As String) As Customer Implements ICustomerRepository.FindByCustomerNameAndAddress
        Using accessor As New ADOWrapper.DBAccessor
            '===============================================
            'クエリの作成
            '===============================================
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    id AS id")
                .AppendLine("   ,name AS name")
                .AppendLine("   ,kana_name AS kana_name")
                .AppendLine("   ,pic_id AS pic_id")
                .AppendLine("   ,payment_id AS payment_id")
                .AppendLine("   ,postal_code AS postal_code")
                .AppendLine("   ,address1 AS address1")
                .AppendLine("   ,address2 AS address2")
                .AppendLine("FROM")
                .AppendLine("   customers")
                .AppendLine("WHERE")
                .AppendLine("   1 = 1")
                .AppendLine("AND")
                .AppendLine("   name = @cust_name")
                .AppendLine("AND")
                .AppendLine("   address1 = @address1")
                .AppendLine("AND")
                .AppendLine("   address2 = @address2")
            End With

            '===============================================
            'パラメータ設定
            '===============================================
            With q.Parameters
                .Add("@cust_name", custName)
                .Add("@address1", addr1)
                .Add("@address2", addr2)
            End With

            '===============================================
            'クエリ発行
            '===============================================
            Dim dt = q.ExecQuery
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            End If

            '===============================================
            'データをモデルに設定して返す
            '===============================================
            Dim empRepo = New EmployeeRepositoryImpl
            Dim payRepo = New PaymentConditionRepositoryImpl

            Dim c = New Domain.Customer(CInt(dt.Rows(0)("id").ToString), Me, payRepo, empRepo)
            c.Name = dt.Rows(0)("name").ToString
            c.KanaName = dt.Rows(0)("kana_name").ToString
            c.PIC = empRepo.FindByID(CInt(dt.Rows(0)("pic_id")))
            c.PaymentCondition = payRepo.FindByID(CInt(dt.Rows(0)("payment_id")))
            c.PostalCode = dt.Rows(0)("postal_code").ToString
            c.Address1 = dt.Rows(0)("address1").ToString
            c.Address2 = dt.Rows(0)("address2").ToString

            Return c
        End Using
    End Function

    ''' <summary>
    ''' 最後に新規に永続化したオブジェクトのIDを返す
    ''' </summary>
    ''' <returns></returns>
    Public Function LastInsertID() As Integer Implements ICustomerRepository.LastInsertID
        Return _LastInsertId
    End Function

    ''' <summary>
    ''' IDから顧客を探す
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function FindByID(ByVal id As Integer) As Customer Implements ICustomerRepository.FindByID
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    id AS id")
                .AppendLine("   ,name AS name")
                .AppendLine("   ,kana_name AS kana_name")
                .AppendLine("   ,pic_id AS pic_id")
                .AppendLine("   ,payment_id AS payment_id")
                .AppendLine("   ,postal_code AS postal_code")
                .AppendLine("   ,address1 AS address1")
                .AppendLine("   ,address2 AS address2")
                .AppendLine("FROM")
                .AppendLine("   customers")
                .AppendLine("WHERE")
                .AppendLine("   id = @id")
            End With

            With q.Parameters
                .Add("@id", id)
            End With

            '===============================================
            'クエリ発行
            '===============================================
            Dim dt = q.ExecQuery
            If dt Is Nothing Then
                Return Nothing
            End If

            '===============================================
            'データをモデルに設定して返す
            '===============================================
            Dim empRepo = New EmployeeRepositoryImpl
            Dim payRepo = New PaymentConditionRepositoryImpl

            Dim r = dt.Rows(0)

            Dim c = New Domain.Customer(CInt(r("id").ToString), Me, payRepo, empRepo)
            c.Name = r("name").ToString
            c.KanaName = r("kana_name").ToString
            c.PIC = empRepo.FindByID(CInt(r("pic_id")))
            c.PaymentCondition = payRepo.FindByID(CInt(r("payment_id")))
            c.PostalCode = r("postal_code").ToString
            c.Address1 = r("address1").ToString
            c.Address2 = r("address2").ToString

            Return c
        End Using
    End Function

    ''' <summary>
    ''' 引数の条件を満たしたすべての顧客を取得
    ''' </summary>
    ''' <param name="cond"></param>
    ''' <returns></returns>
    Public Function FindCustomerByCondition(cond As CustomerRepositorySearchCondition) As List(Of Customer) Implements ICustomerRepository.FindCustomerByCondition
        Using accessor As New ADOWrapper.DBAccessor
            '===============================================
            'クエリの作成
            '===============================================
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    id AS id")
                .AppendLine("   ,name AS name")
                .AppendLine("   ,kana_name AS kana_name")
                .AppendLine("   ,pic_id AS pic_id")
                .AppendLine("   ,payment_id AS payment_id")
                .AppendLine("   ,postal_code AS postal_code")
                .AppendLine("   ,address1 AS address1")
                .AppendLine("   ,address2 AS address2")
                .AppendLine("FROM")
                .AppendLine("   customers")
                .AppendLine("WHERE")
                .AppendLine("   1 = 1")

                '顧客名(前方一致)
                If cond.NameForwardMatch <> String.Empty Then
                    .AppendLine("AND")
                    .AppendLine("   name LIKE @name")
                End If
                'かな名(前方一致)
                If cond.KanaNameForwardMatch <> String.Empty Then
                    .AppendLine("AND")
                    .AppendLine("   name LIKE @kana_name")
                End If
                '営業担当者
                If cond.PIC IsNot Nothing Then
                    .AppendLine("AND")
                    .AppendLine("   pic_id = @pic_id")
                End If
                '住所(前方一致)
                If cond.AddressForwardMatch <> String.Empty Then
                    .AppendLine("AND")
                    .AppendLine("   (address1 || address2) LIKE @address ")
                End If
            End With

            '===============================================
            'パラメータ設定
            '===============================================
            With q.Parameters
                '顧客名(前方一致)
                If cond.NameForwardMatch <> String.Empty Then
                    .Add("@name", cond.NameForwardMatch & "%")
                End If
                'かな名(前方一致)
                If cond.KanaNameForwardMatch <> String.Empty Then
                    .Add("@kana_name", cond.KanaNameForwardMatch & "%")
                End If
                '営業担当者
                If cond.PIC IsNot Nothing Then
                    .Add("@pic_id", cond.PIC.ID)
                End If
                '住所(前方一致)
                If cond.AddressForwardMatch <> String.Empty Then
                    .Add("@address", cond.AddressForwardMatch & "%")
                End If
            End With

            '===============================================
            'クエリ発行
            '===============================================
            Dim dt = q.ExecQuery
            If dt Is Nothing Then
                Return Nothing
            End If

            '===============================================
            'データをモデルに設定して返す
            '===============================================
            Dim ret As New List(Of Customer)
            Dim empRepo = New EmployeeRepositoryImpl
            Dim payRepo = New PaymentConditionRepositoryImpl

            For Each r As Data.DataRow In dt.Rows
                Dim c = New Domain.Customer(CInt(r("id").ToString), Me, payRepo, empRepo)
                c.Name = r("name").ToString
                c.KanaName = r("kana_name").ToString
                c.PIC = empRepo.FindByID(CInt(r("pic_id")))
                c.PaymentCondition = payRepo.FindByID(CInt(r("payment_id")))
                c.PostalCode = r("postal_code").ToString
                c.Address1 = r("address1").ToString
                c.Address2 = r("address2").ToString

                ret.Add(c)
            Next

            Return ret
        End Using
    End Function

    ''' <summary>
    ''' 登録されている顧客数を取得する
    ''' </summary>
    ''' <returns></returns>
    Public Function CountAllCustomer() As Integer Implements ICustomerRepository.CountAllCustomer
        Using accessor As New ADOWrapper.DBAccessor
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("    COUNT(id) AS employee_count")
                .AppendLine("FROM")
                .AppendLine("   customers")
            End With

            Dim count = q.ExecScalar
            If count Is Nothing Then
                Return 0
            End If

            Return CType(count, Integer)
        End Using
    End Function

#End Region

#Region "インスタンス変数"

    ''' <summary>
    ''' 最後に永続化したオブジェクトのID
    ''' </summary>
    Private _LastInsertId As Integer

#End Region

#Region "Create"

    ''' <summary>
    ''' 引数の顧客情報を新規にDBへ登録
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function Create(c As Customer) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            accessor.BeginTransaction()

            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO customers(")
                .AppendLine(" name")
                .AppendLine(",kana_name")
                .AppendLine(",pic_id")
                .AppendLine(",payment_id")
                .AppendLine(",postal_code")
                .AppendLine(",address1")
                .AppendLine(",address2")
                .AppendLine(",created_at")
                .AppendLine(")")
                .AppendLine("VALUES(")
                .AppendLine(" @name")
                .AppendLine(",@kana_name")
                .AppendLine(",@pic_id")
                .AppendLine(",@payment_id")
                .AppendLine(",@postal_code")
                .AppendLine(",@address1")
                .AppendLine(",@address2")
                .AppendLine(",@created_at")
                .AppendLine(")")
            End With

            With q.Parameters
                .Add("@name", c.Name)
                .Add("@kana_name", c.KanaName)
                .Add("@pic_id", c.PIC.ID)
                .Add("@payment_id", c.PaymentCondition.ID)
                .Add("@postal_code", c.PostalCode)
                .Add("@address1", c.Address1)
                .Add("@address2", c.Address2)
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
    ''' 引数の顧客情報がすでにDBに登録されていればTrue
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function IsExist(c As Customer) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("   COUNT(id) AS COUNT")
                .AppendLine("FROM")
                .AppendLine("   customers")
                .AppendLine("WHERE")
                .AppendLine("   id = @id")
            End With

            With q.Parameters
                .Add("@id", c.ID)
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
    ''' 引数の登録済み顧客情報がDBへ更新
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    Private Function Update(c As Customer) As Boolean
        Using accessor As New ADOWrapper.DBAccessor()
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("UPDATE")
                .AppendLine("   customers")
                .AppendLine("SET")
                .AppendLine("    name = @name")
                .AppendLine("   ,kana_name = @kana_name")
                .AppendLine("   ,pic_id = @pic_id")
                .AppendLine("   ,payment_id = @payment_id")
                .AppendLine("   ,postal_code = @postal_code")
                .AppendLine("   ,address1 = @address1")
                .AppendLine("   ,address2 = @address2")
                .AppendLine("   ,updated_at = @updated_at")
                .AppendLine("WHERE")
                .AppendLine("   id = @id")
            End With

            With q.Parameters
                .Add("@name", c.Name)
                .Add("@kana_name", c.KanaName)
                .Add("@pic_id", c.PIC.ID)
                .Add("@payment_id", c.PaymentCondition.ID)
                .Add("@postal_code", c.PostalCode)
                .Add("@address1", c.Address1)
                .Add("@address2", c.Address2)
                .Add("@updated_at", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Add("@id", c.ID)
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
