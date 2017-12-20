Option Strict On
Option Infer On
Imports SalesManagementDomain

''' <summary>
''' 顧客情報永続化のための機能
''' </summary>
Public Class CustomerRepositoryImpl
    Implements SalesManagementDomain.CustomerRepository

    Public Function Save(c As Customer) As Boolean Implements CustomerRepository.Save
        Throw New NotImplementedException()
    End Function

End Class
