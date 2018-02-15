Option Strict On
Option Infer On

Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Domain
Imports Infrastructure

<TestClass()> Public Class TestCompanyInformation

    <TestInitialize()> Public Sub Setup()
        Dim setting = New InfrastructureSetting
        setting.InitializeDB()
    End Sub

    <TestMethod()> Public Sub TestSaveAndLoad()
        Dim repo = New CompanyInformationImpl
        Dim c = New CompanyInformation
        With c
            .Name = "company name"
            .PostalCode = "001-0001"
            .Address1 = "Address1"
            .Address2 = "Address2"
            .TEL = "00-0000-0000"
            .FAX = "00-0000-0000"
        End With

        Assert.IsTrue(repo.Save(c))
        Assert.AreEqual(repo.Find, repo.Find)

    End Sub

End Class