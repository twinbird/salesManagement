Option Strict On
Option Infer On

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
    ''' バックアップの作成
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub バックアップの作成ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles バックアップの作成ToolStripMenuItem.Click
        Using form As New SaveFileDialog
            form.ShowDialog()
            Infrastructure.InfrastractureBackup.BackupToFile(form.FileName)
        End Using
    End Sub

    ''' <summary>
    ''' バックアップのインポート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub バックアップのインポートToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles バックアップのインポートToolStripMenuItem.Click
        Using form As New OpenFileDialog
            form.ShowDialog()
            Infrastructure.InfrastractureBackup.RestoreFromFile(form.FileName)
        End Using
    End Sub

    ''' <summary>
    ''' アプリケーションの終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
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

#Region "見積"

    Private Sub 見積台帳EToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 見積台帳EToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New EstimateList
        ' 表示する前に、この MDI フォームの子に設定します
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub 見積作成MToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 見積作成MToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New EstimateEntry
        ' 表示する前に、この MDI フォームの子に設定します
        ChildForm.MdiParent = Me
        ChildForm.Show()
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

    Private Sub 自社情報の設定SToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 自社情報の設定SToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New CompanyInformationEntry
        ' 表示する前に、この MDI フォームの子に設定します
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub 消費税の設定TToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 消費税の設定TToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New SalesTaxRateEntry
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
