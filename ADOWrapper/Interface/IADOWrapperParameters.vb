Option Strict On
Option Infer On

''' <summary>
''' ADO.NETのパラメータのうすーいラッパー
''' </summary>
Public Interface IADOWrapperParameters

    ''' <summary>
    ''' SQL実行時に利用するパラメータを設定します
    ''' </summary>
    ''' <param name="key">名前付けパラメータの名前</param>
    ''' <param name="value">名前付けパラメータに与える値</param>
    Sub Add(ByVal key As String, ByVal value As String)

    ''' <summary>
    ''' SQL実行時に利用するパラメータを設定します
    ''' </summary>
    ''' <param name="key">名前付けパラメータの名前</param>
    ''' <param name="value">名前付けパラメータに与える値</param>
    Sub Add(ByVal key As String, ByVal value As Integer)

    ''' <summary>
    ''' SQL実行時に利用するパラメータを設定します
    ''' </summary>
    ''' <param name="key">名前付けパラメータの名前</param>
    ''' <param name="value">名前付けパラメータに与える値</param>
    Sub Add(ByVal key As String, ByVal value As Decimal)

End Interface
