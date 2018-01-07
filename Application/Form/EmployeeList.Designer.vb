<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeList
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
        Me.NewEmployeeEntryButton = New System.Windows.Forms.Button()
        Me.SearchGroupBox = New System.Windows.Forms.GroupBox()
        Me.ClearSearchConditionButton = New System.Windows.Forms.Button()
        Me.SearchEmployeeNameKanaLabel = New System.Windows.Forms.Label()
        Me.SearchEmployeeNameLabel = New System.Windows.Forms.Label()
        Me.SearchEmployeeNoLabel = New System.Windows.Forms.Label()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.SearchEmployeeNameKanaTextBox = New System.Windows.Forms.TextBox()
        Me.SearchEmployeeNameTextBox = New System.Windows.Forms.TextBox()
        Me.SearchEmployeeNoTextBox = New System.Windows.Forms.TextBox()
        Me.EmployeeDataGridView = New System.Windows.Forms.DataGridView()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SearchGroupBox.SuspendLayout()
        CType(Me.EmployeeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'NewEmployeeEntryButton
        '
        Me.NewEmployeeEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewEmployeeEntryButton.Location = New System.Drawing.Point(301, 22)
        Me.NewEmployeeEntryButton.Name = "NewEmployeeEntryButton"
        Me.NewEmployeeEntryButton.Size = New System.Drawing.Size(136, 23)
        Me.NewEmployeeEntryButton.TabIndex = 0
        Me.NewEmployeeEntryButton.Text = "新しい従業員を登録"
        Me.NewEmployeeEntryButton.UseVisualStyleBackColor = True
        '
        'SearchGroupBox
        '
        Me.SearchGroupBox.Controls.Add(Me.ClearSearchConditionButton)
        Me.SearchGroupBox.Controls.Add(Me.SearchEmployeeNameKanaLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchEmployeeNameLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchEmployeeNoLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchButton)
        Me.SearchGroupBox.Controls.Add(Me.SearchEmployeeNameKanaTextBox)
        Me.SearchGroupBox.Controls.Add(Me.SearchEmployeeNameTextBox)
        Me.SearchGroupBox.Controls.Add(Me.SearchEmployeeNoTextBox)
        Me.SearchGroupBox.Location = New System.Drawing.Point(14, 12)
        Me.SearchGroupBox.Name = "SearchGroupBox"
        Me.SearchGroupBox.Size = New System.Drawing.Size(281, 94)
        Me.SearchGroupBox.TabIndex = 1
        Me.SearchGroupBox.TabStop = False
        Me.SearchGroupBox.Text = "検索"
        '
        'ClearSearchConditionButton
        '
        Me.ClearSearchConditionButton.Location = New System.Drawing.Point(198, 37)
        Me.ClearSearchConditionButton.Name = "ClearSearchConditionButton"
        Me.ClearSearchConditionButton.Size = New System.Drawing.Size(75, 23)
        Me.ClearSearchConditionButton.TabIndex = 3
        Me.ClearSearchConditionButton.Text = "クリア"
        Me.ClearSearchConditionButton.UseVisualStyleBackColor = True
        '
        'SearchEmployeeNameKanaLabel
        '
        Me.SearchEmployeeNameKanaLabel.AutoSize = True
        Me.SearchEmployeeNameKanaLabel.Location = New System.Drawing.Point(32, 67)
        Me.SearchEmployeeNameKanaLabel.Name = "SearchEmployeeNameKanaLabel"
        Me.SearchEmployeeNameKanaLabel.Size = New System.Drawing.Size(37, 12)
        Me.SearchEmployeeNameKanaLabel.TabIndex = 4
        Me.SearchEmployeeNameKanaLabel.Text = "かな名"
        '
        'SearchEmployeeNameLabel
        '
        Me.SearchEmployeeNameLabel.AutoSize = True
        Me.SearchEmployeeNameLabel.Location = New System.Drawing.Point(40, 43)
        Me.SearchEmployeeNameLabel.Name = "SearchEmployeeNameLabel"
        Me.SearchEmployeeNameLabel.Size = New System.Drawing.Size(29, 12)
        Me.SearchEmployeeNameLabel.TabIndex = 4
        Me.SearchEmployeeNameLabel.Text = "名前"
        '
        'SearchEmployeeNoLabel
        '
        Me.SearchEmployeeNoLabel.AutoSize = True
        Me.SearchEmployeeNoLabel.Location = New System.Drawing.Point(9, 21)
        Me.SearchEmployeeNoLabel.Name = "SearchEmployeeNoLabel"
        Me.SearchEmployeeNoLabel.Size = New System.Drawing.Size(65, 12)
        Me.SearchEmployeeNoLabel.TabIndex = 4
        Me.SearchEmployeeNoLabel.Text = "従業員番号"
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(198, 62)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 23)
        Me.SearchButton.TabIndex = 4
        Me.SearchButton.Text = "検索"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'SearchEmployeeNameKanaTextBox
        '
        Me.SearchEmployeeNameKanaTextBox.Location = New System.Drawing.Point(74, 64)
        Me.SearchEmployeeNameKanaTextBox.Name = "SearchEmployeeNameKanaTextBox"
        Me.SearchEmployeeNameKanaTextBox.Size = New System.Drawing.Size(118, 19)
        Me.SearchEmployeeNameKanaTextBox.TabIndex = 2
        Me.ToolTip.SetToolTip(Me.SearchEmployeeNameKanaTextBox, "従業員のひらがなの名前を検索条件に指定します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "この条件は前方一致です。")
        '
        'SearchEmployeeNameTextBox
        '
        Me.SearchEmployeeNameTextBox.Location = New System.Drawing.Point(74, 41)
        Me.SearchEmployeeNameTextBox.Name = "SearchEmployeeNameTextBox"
        Me.SearchEmployeeNameTextBox.Size = New System.Drawing.Size(118, 19)
        Me.SearchEmployeeNameTextBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.SearchEmployeeNameTextBox, "従業員の名前を検索条件に指定します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "この条件は前方一致です。")
        '
        'SearchEmployeeNoTextBox
        '
        Me.SearchEmployeeNoTextBox.Location = New System.Drawing.Point(74, 17)
        Me.SearchEmployeeNoTextBox.Name = "SearchEmployeeNoTextBox"
        Me.SearchEmployeeNoTextBox.Size = New System.Drawing.Size(118, 19)
        Me.SearchEmployeeNoTextBox.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.SearchEmployeeNoTextBox, "従業員番号を検索条件に指定します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "この条件は前方一致です。")
        '
        'EmployeeDataGridView
        '
        Me.EmployeeDataGridView.AllowUserToAddRows = False
        Me.EmployeeDataGridView.AllowUserToDeleteRows = False
        Me.EmployeeDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EmployeeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.EmployeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EmployeeDataGridView.Location = New System.Drawing.Point(12, 112)
        Me.EmployeeDataGridView.MultiSelect = False
        Me.EmployeeDataGridView.Name = "EmployeeDataGridView"
        Me.EmployeeDataGridView.RowHeadersVisible = False
        Me.EmployeeDataGridView.RowTemplate.Height = 21
        Me.EmployeeDataGridView.Size = New System.Drawing.Size(425, 285)
        Me.EmployeeDataGridView.TabIndex = 2
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 387)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(449, 22)
        Me.StatusStrip.TabIndex = 3
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(113, 17)
        Me.ToolStripStatusLabel.Text = "ToolStripStatusLabel"
        '
        'EmployeeList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 409)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.EmployeeDataGridView)
        Me.Controls.Add(Me.SearchGroupBox)
        Me.Controls.Add(Me.NewEmployeeEntryButton)
        Me.Name = "EmployeeList"
        Me.Text = "従業員台帳"
        Me.SearchGroupBox.ResumeLayout(False)
        Me.SearchGroupBox.PerformLayout()
        CType(Me.EmployeeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NewEmployeeEntryButton As Button
    Friend WithEvents SearchGroupBox As GroupBox
    Friend WithEvents SearchEmployeeNoTextBox As TextBox
    Friend WithEvents EmployeeDataGridView As DataGridView
    Friend WithEvents SearchButton As Button
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents SearchEmployeeNoLabel As Label
    Friend WithEvents SearchEmployeeNameLabel As Label
    Friend WithEvents SearchEmployeeNameTextBox As TextBox
    Friend WithEvents SearchEmployeeNameKanaLabel As Label
    Friend WithEvents SearchEmployeeNameKanaTextBox As TextBox
    Friend WithEvents ClearSearchConditionButton As Button
    Friend WithEvents ToolTip As ToolTip
End Class
