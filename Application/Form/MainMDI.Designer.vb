<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMDI
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMDI))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.バックアップの作成ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.バックアップのインポートToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.日常業務ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.見積台帳EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.マスタToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.顧客マスタToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.従業員ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.支払条件の設定PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.消費税の設定TToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.自社情報の設定SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保守契約の管理SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintPreviewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.見積作成MToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.日常業務ToolStripMenuItem, Me.マスタToolStripMenuItem, Me.WindowsMenu, Me.HelpMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(790, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.バックアップの作成ToolStripMenuItem, Me.バックアップのインポートToolStripMenuItem, Me.ToolStripSeparator4, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(67, 20)
        Me.FileMenu.Text = "ファイル(&F)"
        '
        'バックアップの作成ToolStripMenuItem
        '
        Me.バックアップの作成ToolStripMenuItem.Name = "バックアップの作成ToolStripMenuItem"
        Me.バックアップの作成ToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.バックアップの作成ToolStripMenuItem.Text = "バックアップの作成(&B)"
        '
        'バックアップのインポートToolStripMenuItem
        '
        Me.バックアップのインポートToolStripMenuItem.Name = "バックアップのインポートToolStripMenuItem"
        Me.バックアップのインポートToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.バックアップのインポートToolStripMenuItem.Text = "バックアップのインポート(&I)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(189, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ExitToolStripMenuItem.Text = "アプリケーションの終了(&X)"
        '
        '日常業務ToolStripMenuItem
        '
        Me.日常業務ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.見積台帳EToolStripMenuItem, Me.見積作成MToolStripMenuItem})
        Me.日常業務ToolStripMenuItem.Name = "日常業務ToolStripMenuItem"
        Me.日常業務ToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.日常業務ToolStripMenuItem.Text = "見積(&D)"
        '
        '見積台帳EToolStripMenuItem
        '
        Me.見積台帳EToolStripMenuItem.Name = "見積台帳EToolStripMenuItem"
        Me.見積台帳EToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.見積台帳EToolStripMenuItem.Text = "見積管理(&E)"
        '
        'マスタToolStripMenuItem
        '
        Me.マスタToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.顧客マスタToolStripMenuItem, Me.従業員ToolStripMenuItem, Me.支払条件の設定PToolStripMenuItem, Me.消費税の設定TToolStripMenuItem, Me.自社情報の設定SToolStripMenuItem, Me.保守契約の管理SToolStripMenuItem})
        Me.マスタToolStripMenuItem.Name = "マスタToolStripMenuItem"
        Me.マスタToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.マスタToolStripMenuItem.Text = "設定(&C)"
        '
        '顧客マスタToolStripMenuItem
        '
        Me.顧客マスタToolStripMenuItem.Name = "顧客マスタToolStripMenuItem"
        Me.顧客マスタToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.顧客マスタToolStripMenuItem.Text = "顧客台帳(&C)"
        '
        '従業員ToolStripMenuItem
        '
        Me.従業員ToolStripMenuItem.Name = "従業員ToolStripMenuItem"
        Me.従業員ToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.従業員ToolStripMenuItem.Text = "従業員台帳(&E)"
        '
        '支払条件の設定PToolStripMenuItem
        '
        Me.支払条件の設定PToolStripMenuItem.Name = "支払条件の設定PToolStripMenuItem"
        Me.支払条件の設定PToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.支払条件の設定PToolStripMenuItem.Text = "支払条件の設定(&P)"
        '
        '消費税の設定TToolStripMenuItem
        '
        Me.消費税の設定TToolStripMenuItem.Name = "消費税の設定TToolStripMenuItem"
        Me.消費税の設定TToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.消費税の設定TToolStripMenuItem.Text = "消費税の設定(&T)"
        '
        '自社情報の設定SToolStripMenuItem
        '
        Me.自社情報の設定SToolStripMenuItem.Name = "自社情報の設定SToolStripMenuItem"
        Me.自社情報の設定SToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.自社情報の設定SToolStripMenuItem.Text = "自社情報の設定(&M)"
        '
        '保守契約の管理SToolStripMenuItem
        '
        Me.保守契約の管理SToolStripMenuItem.Name = "保守契約の管理SToolStripMenuItem"
        Me.保守契約の管理SToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.保守契約の管理SToolStripMenuItem.Text = "保守契約の管理(&S)"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewWindowToolStripMenuItem, Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(80, 20)
        Me.WindowsMenu.Text = "ウィンドウ(&W)"
        '
        'NewWindowToolStripMenuItem
        '
        Me.NewWindowToolStripMenuItem.Name = "NewWindowToolStripMenuItem"
        Me.NewWindowToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.NewWindowToolStripMenuItem.Text = "新しいウィンドウを開く(&N)"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.CascadeToolStripMenuItem.Text = "重ねて表示(&C)"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.TileVerticalToolStripMenuItem.Text = "左右に並べて表示(&V)"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "上下に並べて表示(&H)"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.CloseAllToolStripMenuItem.Text = "すべて閉じる(&L)"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "アイコンの整列(&A)"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(65, 20)
        Me.HelpMenu.Text = "ヘルプ(&H)"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ContentsToolStripMenuItem.Text = "目次(&C)"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Image = CType(resources.GetObject("IndexToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.IndexToolStripMenuItem.Text = "インデックス(&I)"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Image = CType(resources.GetObject("SearchToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SearchToolStripMenuItem.Text = "検索(&S)"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(164, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.AboutToolStripMenuItem.Text = "バージョン情報(&A)..."
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripSeparator1, Me.PrintToolStripButton, Me.PrintPreviewToolStripButton, Me.ToolStripSeparator2, Me.HelpToolStripButton})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(790, 25)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "新規"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "開く"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "上書き保存"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "印刷"
        '
        'PrintPreviewToolStripButton
        '
        Me.PrintPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintPreviewToolStripButton.Image = CType(resources.GetObject("PrintPreviewToolStripButton.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintPreviewToolStripButton.Name = "PrintPreviewToolStripButton"
        Me.PrintPreviewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintPreviewToolStripButton.Text = "印刷プレビュー"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "ヘルプ"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 442)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(790, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(31, 17)
        Me.ToolStripStatusLabel.Text = "状態"
        '
        '見積作成MToolStripMenuItem
        '
        Me.見積作成MToolStripMenuItem.Name = "見積作成MToolStripMenuItem"
        Me.見積作成MToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.見積作成MToolStripMenuItem.Text = "見積作成(&M)"
        '
        'MainMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 464)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MainMDI"
        Me.Text = "見積管理システム"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintPreviewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents マスタToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 顧客マスタToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 従業員ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 日常業務ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents バックアップの作成ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents バックアップのインポートToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 見積台帳EToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 支払条件の設定PToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 消費税の設定TToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 自社情報の設定SToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 保守契約の管理SToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 見積作成MToolStripMenuItem As ToolStripMenuItem
End Class
