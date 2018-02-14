Option Strict On
Option Infer On

Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Domain

<TestClass()> Public Class TestCustomer

    <TestMethod()> Public Sub TestNameShouldNotEmpty()
        Dim custRepo As New CustomerRepositoryStub
        Dim payRepo As New PaymentConditionRepositoryStub
        Dim empRepo As New EmployeeRepositoryStub

        Dim c = New Customer(custRepo, payRepo, empRepo)
        With c
            .Name = ""
            .KanaName = ""
            .PostalCode = "100-8111"
            .Address1 = "東京都千代田区"
            .Address2 = "千代田1-1"
            .PIC = Nothing
        End With

        Assert.IsFalse(c.Validate)
        Assert.AreNotEqual(c.Item(NameOf(c.Name)), String.Empty)

    End Sub

End Class