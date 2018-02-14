Option Strict On
Option Infer On
Imports Domain

Public Class EmployeeRepositoryStub
    Implements Domain.IEmployeeRepository

    Public Function Save(e As Employee) As Boolean Implements IEmployeeRepository.Save
        Throw New NotImplementedException()
    End Function

    Public Function LastInsertID() As Integer Implements IEmployeeRepository.LastInsertID
        Throw New NotImplementedException()
    End Function

    Public Function FindByID(id As Integer) As Employee Implements IEmployeeRepository.FindByID
        Throw New NotImplementedException()
    End Function

    Public Function FindByEmployeeNo(empNo As String) As Employee Implements IEmployeeRepository.FindByEmployeeNo
        Throw New NotImplementedException()
    End Function

    Public Function FindAllEmployee() As List(Of Employee) Implements IEmployeeRepository.FindAllEmployee
        Throw New NotImplementedException()
    End Function

    Public Function FindEmployeeByCondition(cond As EmployeeRepositorySearchCondition) As List(Of Employee) Implements IEmployeeRepository.FindEmployeeByCondition
        Throw New NotImplementedException()
    End Function

    Public Function CountAllEmployee() As Integer Implements IEmployeeRepository.CountAllEmployee
        Throw New NotImplementedException()
    End Function
End Class
