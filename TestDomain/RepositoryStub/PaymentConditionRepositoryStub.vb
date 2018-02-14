Option Strict On
Option Infer On
Imports Domain

Public Class PaymentConditionRepositoryStub
    Implements Domain.IPaymentConditionRepository

    Public Function Save(e As PaymentCondition) As Boolean Implements IPaymentConditionRepository.Save
        Throw New NotImplementedException()
    End Function

    Public Function LastInsertID() As Integer Implements IPaymentConditionRepository.LastInsertID
        Throw New NotImplementedException()
    End Function

    Public Function FindByID(id As Integer) As PaymentCondition Implements IPaymentConditionRepository.FindByID
        Throw New NotImplementedException()
    End Function

    Public Function FindByName(name As String) As PaymentCondition Implements IPaymentConditionRepository.FindByName
        Throw New NotImplementedException()
    End Function

    Public Function FindAllPaymentCondition() As List(Of PaymentCondition) Implements IPaymentConditionRepository.FindAllPaymentCondition
        Throw New NotImplementedException()
    End Function

    Public Function FindPaymentConditionByCondition(cond As PaymentConditionRepositorySearchCondition) As List(Of PaymentCondition) Implements IPaymentConditionRepository.FindPaymentConditionByCondition
        Throw New NotImplementedException()
    End Function

    Public Function CountAllPaymentCondition() As Integer Implements IPaymentConditionRepository.CountAllPaymentCondition
        Throw New NotImplementedException()
    End Function
End Class
