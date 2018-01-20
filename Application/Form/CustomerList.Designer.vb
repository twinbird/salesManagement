<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerList
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CustomerDataGridView = New System.Windows.Forms.DataGridView()
        Me.NewCustomerEntryButton = New System.Windows.Forms.Button()
        Me.SearchCustomerNameTextBox = New System.Windows.Forms.TextBox()
        Me.SearchGroupBox = New System.Windows.Forms.GroupBox()
        Me.SearchPICComboBox = New System.Windows.Forms.ComboBox()
        Me.SearchAddressLabel = New System.Windows.Forms.Label()
        Me.SearchPICLabel = New System.Windows.Forms.Label()
        Me.SearchCustomerKanaNameLabel = New System.Windows.Forms.Label()
        Me.SearchCustomerNameLabel = New System.Windows.Forms.Label()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.SearchAddressTextBox = New System.Windows.Forms.TextBox()
        Me.SearchCustomerKanaNameTextBox = New System.Windows.Forms.TextBox()
        Me.ClearSearchConditionButton = New System.Windows.Forms.Button()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FocusEmphasizeProvider = New Application.FocusEmphasizeProvider()
        CType(Me.CustomerDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchGroupBox.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomerDataGridView
        '
        Me.CustomerDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CustomerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CustomerDataGridView.Location = New System.Drawing.Point(12, 127)
        Me.CustomerDataGridView.Name = "CustomerDataGridView"
        Me.CustomerDataGridView.RowHeadersVisible = False
        Me.CustomerDataGridView.RowTemplate.Height = 21
        Me.CustomerDataGridView.Size = New System.Drawing.Size(611, 257)
        Me.CustomerDataGridView.TabIndex = 0
        '
        'NewCustomerEntryButton
        '
        Me.NewCustomerEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewCustomerEntryButton.Location = New System.Drawing.Point(491, 23)
        Me.NewCustomerEntryButton.Name = "NewCustomerEntryButton"
        Me.NewCustomerEntryButton.Size = New System.Drawing.Size(132, 23)
        Me.NewCustomerEntryButton.TabIndex = 0
        Me.NewCustomerEntryButton.Text = "新しい顧客を追加"
        Me.ToolTip.SetToolTip(Me.NewCustomerEntryButton, "新しい顧客を登録する画面を開きます。")
        Me.NewCustomerEntryButton.UseVisualStyleBackColor = True
        '
        'SearchCustomerNameTextBox
        '
        Me.SearchCustomerNameTextBox.Location = New System.Drawing.Point(95, 13)
        Me.SearchCustomerNameTextBox.Name = "SearchCustomerNameTextBox"
        Me.SearchCustomerNameTextBox.Size = New System.Drawing.Size(250, 19)
        Me.SearchCustomerNameTextBox.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.SearchCustomerNameTextBox, "顧客名を検索条件に指定します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "この条件は前方一致です。")
        '
        'SearchGroupBox
        '
        Me.SearchGroupBox.Controls.Add(Me.SearchPICComboBox)
        Me.SearchGroupBox.Controls.Add(Me.SearchAddressLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchPICLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchCustomerKanaNameLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchCustomerNameLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchButton)
        Me.SearchGroupBox.Controls.Add(Me.SearchAddressTextBox)
        Me.SearchGroupBox.Controls.Add(Me.SearchCustomerKanaNameTextBox)
        Me.SearchGroupBox.Controls.Add(Me.ClearSearchConditionButton)
        Me.SearchGroupBox.Controls.Add(Me.SearchCustomerNameTextBox)
        Me.SearchGroupBox.Location = New System.Drawing.Point(22, 12)
        Me.SearchGroupBox.Name = "SearchGroupBox"
        Me.SearchGroupBox.Size = New System.Drawing.Size(453, 109)
        Me.SearchGroupBox.TabIndex = 3
        Me.SearchGroupBox.TabStop = False
        Me.SearchGroupBox.Text = "検索"
        '
        'SearchPICComboBox
        '
        Me.SearchPICComboBox.FormattingEnabled = True
        Me.SearchPICComboBox.Location = New System.Drawing.Point(95, 56)
        Me.SearchPICComboBox.Name = "SearchPICComboBox"
        Me.SearchPICComboBox.Size = New System.Drawing.Size(138, 20)
        Me.SearchPICComboBox.TabIndex = 2
        Me.ToolTip.SetToolTip(Me.SearchPICComboBox, "営業担当者を検索条件に指定します。")
        '
        'SearchAddressLabel
        '
        Me.SearchAddressLabel.AutoSize = True
        Me.SearchAddressLabel.Location = New System.Drawing.Point(17, 82)
        Me.SearchAddressLabel.Name = "SearchAddressLabel"
        Me.SearchAddressLabel.Size = New System.Drawing.Size(29, 12)
        Me.SearchAddressLabel.TabIndex = 4
        Me.SearchAddressLabel.Text = "住所"
        '
        'SearchPICLabel
        '
        Me.SearchPICLabel.AutoSize = True
        Me.SearchPICLabel.Location = New System.Drawing.Point(17, 60)
        Me.SearchPICLabel.Name = "SearchPICLabel"
        Me.SearchPICLabel.Size = New System.Drawing.Size(65, 12)
        Me.SearchPICLabel.TabIndex = 4
        Me.SearchPICLabel.Text = "営業担当者"
        '
        'SearchCustomerKanaNameLabel
        '
        Me.SearchCustomerKanaNameLabel.AutoSize = True
        Me.SearchCustomerKanaNameLabel.Location = New System.Drawing.Point(17, 39)
        Me.SearchCustomerKanaNameLabel.Name = "SearchCustomerKanaNameLabel"
        Me.SearchCustomerKanaNameLabel.Size = New System.Drawing.Size(69, 12)
        Me.SearchCustomerKanaNameLabel.TabIndex = 4
        Me.SearchCustomerKanaNameLabel.Text = "顧客名(かな)"
        '
        'SearchCustomerNameLabel
        '
        Me.SearchCustomerNameLabel.AutoSize = True
        Me.SearchCustomerNameLabel.Location = New System.Drawing.Point(17, 18)
        Me.SearchCustomerNameLabel.Name = "SearchCustomerNameLabel"
        Me.SearchCustomerNameLabel.Size = New System.Drawing.Size(41, 12)
        Me.SearchCustomerNameLabel.TabIndex = 4
        Me.SearchCustomerNameLabel.Text = "顧客名"
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(360, 78)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 23)
        Me.SearchButton.TabIndex = 5
        Me.SearchButton.Text = "検索"
        Me.ToolTip.SetToolTip(Me.SearchButton, "検索して結果を下の表に表示します。")
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'SearchAddressTextBox
        '
        Me.SearchAddressTextBox.Location = New System.Drawing.Point(95, 79)
        Me.SearchAddressTextBox.Name = "SearchAddressTextBox"
        Me.SearchAddressTextBox.Size = New System.Drawing.Size(250, 19)
        Me.SearchAddressTextBox.TabIndex = 3
        Me.ToolTip.SetToolTip(Me.SearchAddressTextBox, "住所を検索条件に指定します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "この条件は住所1と住所2をつなげた文字に対する前方一致です。")
        '
        'SearchCustomerKanaNameTextBox
        '
        Me.SearchCustomerKanaNameTextBox.Location = New System.Drawing.Point(95, 34)
        Me.SearchCustomerKanaNameTextBox.Name = "SearchCustomerKanaNameTextBox"
        Me.SearchCustomerKanaNameTextBox.Size = New System.Drawing.Size(250, 19)
        Me.SearchCustomerKanaNameTextBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.SearchCustomerKanaNameTextBox, "顧客名(かな)を検索条件に指定します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "この条件は前方一致です。")
        '
        'ClearSearchConditionButton
        '
        Me.ClearSearchConditionButton.Location = New System.Drawing.Point(360, 52)
        Me.ClearSearchConditionButton.Name = "ClearSearchConditionButton"
        Me.ClearSearchConditionButton.Size = New System.Drawing.Size(75, 23)
        Me.ClearSearchConditionButton.TabIndex = 4
        Me.ClearSearchConditionButton.Text = "クリア"
        Me.ToolTip.SetToolTip(Me.ClearSearchConditionButton, "検索条件をクリアします。")
        Me.ClearSearchConditionButton.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 384)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(637, 22)
        Me.StatusStrip.TabIndex = 4
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(113, 17)
        Me.ToolStripStatusLabel.Text = "ToolStripStatusLabel"
        '
        'FocusEmphasizeProvider
        '
        Me.FocusEmphasizeProvider.Target = Me
        '
        'CustomerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 406)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.SearchGroupBox)
        Me.Controls.Add(Me.NewCustomerEntryButton)
        Me.Controls.Add(Me.CustomerDataGridView)
        Me.Name = "CustomerList"
        Me.Text = "顧客情報の管理"
        CType(Me.CustomerDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchGroupBox.ResumeLayout(False)
        Me.SearchGroupBox.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CustomerDataGridView As DataGridView
    Friend WithEvents NewCustomerEntryButton As Button
    Friend WithEvents SearchCustomerNameTextBox As TextBox
    Friend WithEvents SearchGroupBox As GroupBox
    Friend WithEvents SearchButton As Button
    Friend WithEvents ClearSearchConditionButton As Button
    Friend WithEvents SearchCustomerNameLabel As Label
    Friend WithEvents SearchCustomerKanaNameLabel As Label
    Friend WithEvents SearchCustomerKanaNameTextBox As TextBox
    Friend WithEvents SearchPICLabel As Label
    Friend WithEvents SearchAddressLabel As Label
    Friend WithEvents SearchAddressTextBox As TextBox
    Friend WithEvents SearchPICComboBox As ComboBox
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents FocusEmphasizeProvider As FocusEmphasizeProvider
End Class
