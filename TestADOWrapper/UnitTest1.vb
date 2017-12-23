Option Strict On
Option Infer On

Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    Const ConnectionString As String = "data source=myDb.db;foreign keys=true;"

    <TestInitialize> Public Sub SetUp()
        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("DROP TABLE IF EXISTS test")
            End With
            Dim ret = q.ExecNonQuery
        End Using

        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("CREATE TABLE IF NOT EXISTS test (")
                .AppendLine("    id integer primary key AUTOINCREMENT")
                .AppendLine("   ,text varchar(100)")
                .AppendLine(")")
            End With
            Dim ret = q.ExecNonQuery()
        End Using
    End Sub

    <TestMethod()> Public Sub TestExecNonQuery()
        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO test(text) VALUES('text1');")
                .AppendLine("INSERT INTO test(text) VALUES('text1');")
                .AppendLine("INSERT INTO test(text) VALUES('text2');")
                .AppendLine("INSERT INTO test(text) VALUES('text2');")
            End With
            Dim ret = q.ExecNonQuery()
            Assert.AreEqual(4, ret)
        End Using
    End Sub

    <TestMethod()> Public Sub TestTransactionRollback()
        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            accessor.BeginTransaction()

            Try
                Dim q = accessor.CreateQuery
                With q.Query
                    .AppendLine("INSERT INTO test(text) VALUES('text1');")
                End With
                Dim ret = q.ExecNonQuery()
                Assert.AreEqual(1, ret)

                Dim q2 = accessor.CreateQuery
                With q2.Query
                    .AppendLine("INSERT INTO test(text) VALUES('text1');")
                End With
                Dim ret2 = q2.ExecNonQuery()
                Assert.AreEqual(1, ret2)

                Throw New Exception("Deliberately throw exception")

                Dim q3 = accessor.CreateQuery
                With q3.Query
                    .AppendLine("INSERT INTO test(text) VALUES('text1');")
                End With
                Dim ret3 = q3.ExecNonQuery()

                accessor.Commit()

            Catch ex As Exception
                accessor.RollBack()
            End Try
        End Using

        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT * FROM test")
            End With
            Dim retDt = q.ExecQuery
            Dim ret = retDt.Rows.Count

            Assert.AreEqual(0, ret)
        End Using
    End Sub

    <TestMethod()> Public Sub TestTransactionCommit()
        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            accessor.BeginTransaction()

            Try
                Dim q = accessor.CreateQuery
                With q.Query
                    .AppendLine("INSERT INTO test(text) VALUES('text1');")
                End With
                Dim ret = q.ExecNonQuery()
                Assert.AreEqual(1, ret)

                Dim q2 = accessor.CreateQuery
                With q2.Query
                    .AppendLine("INSERT INTO test(text) VALUES('text1');")
                End With
                Dim ret2 = q2.ExecNonQuery()
                Assert.AreEqual(1, ret2)

                Dim q3 = accessor.CreateQuery
                With q3.Query
                    .AppendLine("INSERT INTO test(text) VALUES('text1');")
                End With
                Dim ret3 = q3.ExecNonQuery()

                accessor.Commit()

            Catch ex As Exception
                accessor.RollBack()
            End Try
        End Using

        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT * FROM test")
            End With
            Dim retDt = q.ExecQuery
            Dim ret = retDt.Rows.Count

            Assert.AreEqual(3, ret)
        End Using
    End Sub

    <TestMethod()> Public Sub TestSimpleQuery()
        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO test(text) VALUES('text1');")
                .AppendLine("INSERT INTO test(text) VALUES('text2');")
                .AppendLine("INSERT INTO test(text) VALUES('text3');")
                .AppendLine("INSERT INTO test(text) VALUES('text4');")
            End With
            Dim ret = q.ExecNonQuery()
            Assert.AreEqual(4, ret)
        End Using

        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT * FROM test")
            End With
            Dim dt = q.ExecQuery
            Assert.AreEqual(4, dt.Rows.Count)

            Dim expects = New List(Of String)({"text1", "text2", "text3", "text4"})

            For Each row As DataRow In dt.Rows
                Assert.IsTrue(expects.Contains(row("text").ToString()))
            Next
        End Using

    End Sub

    <TestMethod()> Public Sub TestQueryParameter()
        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO test(text) VALUES('text1');")
                .AppendLine("INSERT INTO test(text) VALUES('text2');")
                .AppendLine("INSERT INTO test(text) VALUES('text3');")
                .AppendLine("INSERT INTO test(text) VALUES('text4');")
            End With
            Dim ret = q.ExecNonQuery()
            Assert.AreEqual(4, ret)
        End Using

        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("   *")
                .AppendLine("FROM")
                .AppendLine("   test")
                .AppendLine("WHERE")
                .AppendLine("   text = @text")
            End With
            With q.Parameters
                .Add("text", "text1")
            End With

            Dim dt = q.ExecQuery
            Assert.AreEqual(1, dt.Rows.Count)
            Assert.AreEqual("text1", dt.Rows(0).Item("text").ToString)
        End Using
    End Sub

    <TestMethod> Public Sub TestScalar()
        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("INSERT INTO test(text) VALUES('text1');")
                .AppendLine("INSERT INTO test(text) VALUES('text2');")
                .AppendLine("INSERT INTO test(text) VALUES('text3');")
                .AppendLine("INSERT INTO test(text) VALUES('text4');")
            End With
            Dim ret = q.ExecNonQuery()
            Assert.AreEqual(4, ret)
        End Using

        Using accessor As New ADOWrapper.DBAccessor(ConnectionString)
            Dim q = accessor.CreateQuery
            With q.Query
                .AppendLine("SELECT")
                .AppendLine("   COUNT(*)")
                .AppendLine("FROM")
                .AppendLine("   test")
            End With

            Dim obj = q.ExecScalar
            Assert.AreEqual(4, CType(obj, Integer))
        End Using

    End Sub

End Class