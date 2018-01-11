Option Strict On
Option Infer On

''' <summary>
''' 自社情報の永続化機能表現
''' </summary>
Public Interface ICompanyInformationRepository

    ''' <summary>
    ''' 引数を永続化する
    ''' </summary>
    ''' <param name="c">永続化するcustomer</param>
    ''' <returns>False:永続化失敗</returns>
    Function Save(ByVal c As CompanyInformation) As Boolean

    ''' <summary>
    ''' 自社情報を取得する
    ''' </summary>
    ''' <returns></returns>
    Function Find() As CompanyInformation

End Interface
