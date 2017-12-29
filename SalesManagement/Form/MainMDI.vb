Imports System.Windows.Forms

Public Class MainMDI

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New System.Windows.Forms.Form
        ' 表示する前に、この MDI フォームの子に設定します
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "ウィンドウ " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "テキスト ファイル (*.txt)|*.txt|すべてのファイル (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: ファイルを開くコードをここに追加します
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "テキスト ファイル (*.txt)|*.txt|すべてのファイル (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: 現在のフォームの内容をファイルに保存するためのコードをここに追加します
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' My.Computer.Clipboard を使用して、選択されたテキストまたはイメージをクリップボードに挿入します
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' My.Computer.Clipboard を使用して、選択されたテキストまたはイメージをクリップボードに挿入します
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'My.Computer.Clipboard.GetText() または My.Computer.Clipboard.GetData を使用して、クリップボードから情報を取得します
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

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

    Private m_ChildFormNumber As Integer

    Private Sub 顧客マスタToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 顧客マスタToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New CustomerEntry
        ' 表示する前に、この MDI フォームの子に設定します
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "ウィンドウ " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub 従業員ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 従業員ToolStripMenuItem.Click
        ' 子フォームの新しいインスタンスを作成します
        Dim ChildForm As New EmployeeEntry
        ' 表示する前に、この MDI フォームの子に設定します
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "ウィンドウ " & m_ChildFormNumber

        ChildForm.Show()
    End Sub
End Class
