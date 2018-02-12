Option Strict On
Option Infer On

Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Domain

<TestClass()> Public Class TestCompanyInformation

    <TestMethod()> Public Sub TestNameShouldNotEmpty()
        Dim c = New CompanyInformation
        With c
            .Name = ""
            .PostalCode = "100-8111"
            .Address1 = "東京都千代田区"
            .Address2 = "千代田1-1"
            .TEL = "03-9999-9999"
            .FAX = "03-8888-8888"
        End With

        Assert.IsFalse(c.Validate)
        Assert.IsTrue(c.HasError)
    End Sub

    <TestMethod()> Public Sub TestNameMaxLength()
        Dim c = New CompanyInformation

        Dim maximum = ""
        For i = 1 To 100
            maximum &= "あ"
        Next

        With c
            .Name = maximum
            .PostalCode = "100-8111"
            .Address1 = "東京都千代田区"
            .Address2 = "千代田1-1"
            .TEL = "03-9999-9999"
            .FAX = "03-8888-8888"
        End With
        Assert.IsTrue(c.Validate)
        Assert.IsFalse(c.HasError)

        c.Name &= "あ"
        Assert.IsFalse(c.Validate)
        Assert.IsTrue(c.HasError)
    End Sub

End Class