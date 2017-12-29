Option Strict On
Option Infer On

''' <summary>
''' 従業員永続化のための機能表現
''' </summary>
Public Interface IEmployeeRepository

    ''' <summary>
    ''' 引数のEmployeeを永続化する
    ''' </summary>
    ''' <param name="e">永続化するEmployee</param>
    ''' <returns>False:永続化失敗</returns>
    Function Save(ByVal e As Employee) As Boolean

    ''' <summary>
    ''' 最後に永続化したオブジェクトのIDを返す
    ''' </summary>
    ''' <returns></returns>
    Function LastInsertID() As Integer

End Interface
