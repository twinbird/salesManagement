Option Strict On
Option Infer On

Imports System.Windows.Forms

''' <summary>
''' メインMDIフォーム
''' </summary>
Public Class MainMDI

#Region "インスタンス変数"

    ''' <summary>
    ''' インフラストラクチャの設定用インスタンス
    ''' </summary>
    Private _InfrastructureSetting As Infrastructure.InfrastructureSetting

#End Region

#Region "メニュー(ファイル)"

    ''' <summary>
    ''' アプリケーションの終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

#End Region

#Region "メニュー(編集)"

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' My.Computer.Clipboard を使用して、選択されたテキストまたはイメージをクリップボードに挿入します
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' My.Computer.Clipboard を使用して、選択されたテキストまたはイメージをクリップボードに挿入します
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'My.Computer.Clipboard.GetText() または My.Computer.Clipboard.GetData を使用して、クリップボードから情報を取得します
    End Sub


#End Region

#Region "メニュー(ウィンドウ)"

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' この親のすべての子フォームを閉じます
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub


#End Region

#Region "メニュー(設定)"

    Private Sub 顧客マスタToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 顧客マスタToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New CustomerList
        ' 表示する前に、この MDI フォームの子に設定します
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub 従業員ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 従業員ToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New EmployeeList
        ' 表示する前に、この MDI フォームの子に設定します
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub 支払条件の設定PToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 支払条件の設定PToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New PaymentConditionList
        ' 表示する前に、この MDI フォームの子に設定します
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub


#End Region

#Region "MDIフォームイベント"

    ''' <summary>
    ''' 親MDIウィンドウのロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainMDI_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conStr = Configuration.ConfigurationManager.AppSettings("ConnectionString")
        _InfrastructureSetting = New Infrastructure.InfrastructureSetting(conStr)
        If _InfrastructureSetting.InitializeDB() = False Then
            MessageBox.Show("アプリケーションの初期化でエラーが発生しました。")
            Me.Close()
        End If
    End Sub

#End Region

End Class
