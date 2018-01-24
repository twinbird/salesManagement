Option Strict On
Option Infer On

''' <summary>
''' 見積一覧画面
''' </summary>
Public Class EstimateList

    ''' <summary>
    ''' 新しい見積を作成ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NewEstimateEntryButton_Click(sender As Object, e As EventArgs) Handles NewEstimateEntryButton.Click
        Dim form As New EstimateEntry
        form.MdiParent = Me.MdiParent
        form.Show()
    End Sub

End Class