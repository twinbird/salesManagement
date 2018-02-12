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

End Class