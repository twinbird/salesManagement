Option Strict On
Option Infer On
Imports Domain

Public Class CustomerRepositoryStub
    Implements Domain.ICustomerRepository

    Public Function Save(c As Customer) As Boolean Implements ICustomerRepository.Save
        Throw New NotImplementedException()
    End Function

    Public Function LastInsertID() As Integer Implements ICustomerRepository.LastInsertID
        Throw New NotImplementedException()
    End Function

    Public Function FindByCustomerNameAndAddress(custName As String, addr1 As String, addr2 As String) As Customer Implements ICustomerRepository.FindByCustomerNameAndAddress
        Throw New NotImplementedException()
    End Function

    Public Function FindCustomerByCondition(cond As CustomerRepositorySearchCondition) As List(Of Customer) Implements ICustomerRepository.FindCustomerByCondition
        Throw New NotImplementedException()
    End Function

    Public Function CountAllCustomer() As Integer Implements ICustomerRepository.CountAllCustomer
        Throw New NotImplementedException()
    End Function

    Public Function FindByID(id As Integer) As Customer Implements ICustomerRepository.FindByID
        Throw New NotImplementedException()
    End Function
End Class
