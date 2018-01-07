<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PaymentConditionEntry
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
        Me.EntryButton = New System.Windows.Forms.Button()
        Me.PaymentConditionNameLabel = New System.Windows.Forms.Label()
        Me.PaymentConditionNameTextBox = New System.Windows.Forms.TextBox()
        Me.CutOffLabel = New System.Windows.Forms.Label()
        Me.CutOffComboBox = New System.Windows.Forms.ComboBox()
        Me.MonthOffsetLabel = New System.Windows.Forms.Label()
        Me.MonthOffsetComboBox = New System.Windows.Forms.ComboBox()
        Me.DueDateLabel = New System.Windows.Forms.Label()
        Me.DueDateComboBox = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EntryButton
        '
        Me.EntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EntryButton.Location = New System.Drawing.Point(204, 122)
        Me.EntryButton.Name = "EntryButton"
        Me.EntryButton.Size = New System.Drawing.Size(75, 23)
        Me.EntryButton.TabIndex = 0
        Me.EntryButton.Text = "登録"
        Me.EntryButton.UseVisualStyleBackColor = True
        '
        'PaymentConditionNameLabel
        '
        Me.PaymentConditionNameLabel.AutoSize = True
        Me.PaymentConditionNameLabel.Location = New System.Drawing.Point(12, 17)
        Me.PaymentConditionNameLabel.Name = "PaymentConditionNameLabel"
        Me.PaymentConditionNameLabel.Size = New System.Drawing.Size(65, 12)
        Me.PaymentConditionNameLabel.TabIndex = 2
        Me.PaymentConditionNameLabel.Text = "支払条件名"
        '
        'PaymentConditionNameTextBox
        '
        Me.PaymentConditionNameTextBox.Location = New System.Drawing.Point(83, 14)
        Me.PaymentConditionNameTextBox.Name = "PaymentConditionNameTextBox"
        Me.PaymentConditionNameTextBox.Size = New System.Drawing.Size(189, 19)
        Me.PaymentConditionNameTextBox.TabIndex = 3
        Me.ToolTip.SetToolTip(Me.PaymentConditionNameTextBox, "「月末締め翌月現金払い」の様に見積書などに表示する支払条件を入力します。")
        '
        'CutOffLabel
        '
        Me.CutOffLabel.AutoSize = True
        Me.CutOffLabel.Location = New System.Drawing.Point(12, 42)
        Me.CutOffLabel.Name = "CutOffLabel"
        Me.CutOffLabel.Size = New System.Drawing.Size(29, 12)
        Me.CutOffLabel.TabIndex = 5
        Me.CutOffLabel.Text = "締日"
        '
        'CutOffComboBox
        '
        Me.CutOffComboBox.FormattingEnabled = True
        Me.CutOffComboBox.Location = New System.Drawing.Point(83, 39)
        Me.CutOffComboBox.Name = "CutOffComboBox"
        Me.CutOffComboBox.Size = New System.Drawing.Size(65, 20)
        Me.CutOffComboBox.TabIndex = 6
        Me.ToolTip.SetToolTip(Me.CutOffComboBox, "この支払条件の締め日を入力します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "28日以降は「月末」を指定してください。")
        '
        'MonthOffsetLabel
        '
        Me.MonthOffsetLabel.AutoSize = True
        Me.MonthOffsetLabel.Location = New System.Drawing.Point(12, 69)
        Me.MonthOffsetLabel.Name = "MonthOffsetLabel"
        Me.MonthOffsetLabel.Size = New System.Drawing.Size(41, 12)
        Me.MonthOffsetLabel.TabIndex = 5
        Me.MonthOffsetLabel.Text = "支払月"
        '
        'MonthOffsetComboBox
        '
        Me.MonthOffsetComboBox.FormattingEnabled = True
        Me.MonthOffsetComboBox.Location = New System.Drawing.Point(83, 66)
        Me.MonthOffsetComboBox.Name = "MonthOffsetComboBox"
        Me.MonthOffsetComboBox.Size = New System.Drawing.Size(65, 20)
        Me.MonthOffsetComboBox.TabIndex = 6
        Me.ToolTip.SetToolTip(Me.MonthOffsetComboBox, "この支払条件の支払月を入力します。")
        '
        'DueDateLabel
        '
        Me.DueDateLabel.AutoSize = True
        Me.DueDateLabel.Location = New System.Drawing.Point(12, 96)
        Me.DueDateLabel.Name = "DueDateLabel"
        Me.DueDateLabel.Size = New System.Drawing.Size(41, 12)
        Me.DueDateLabel.TabIndex = 5
        Me.DueDateLabel.Text = "支払日"
        '
        'DueDateComboBox
        '
        Me.DueDateComboBox.FormattingEnabled = True
        Me.DueDateComboBox.Location = New System.Drawing.Point(83, 93)
        Me.DueDateComboBox.Name = "DueDateComboBox"
        Me.DueDateComboBox.Size = New System.Drawing.Size(65, 20)
        Me.DueDateComboBox.TabIndex = 6
        Me.ToolTip.SetToolTip(Me.DueDateComboBox, "この支払条件の支払日を入力します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "28日以降の場合は月末を指定してください。")
        '
        'ErrorProvider
        '
        Me.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider.ContainerControl = Me
        '
        'PaymentConditionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 157)
        Me.Controls.Add(Me.DueDateComboBox)
        Me.Controls.Add(Me.MonthOffsetComboBox)
        Me.Controls.Add(Me.CutOffComboBox)
        Me.Controls.Add(Me.DueDateLabel)
        Me.Controls.Add(Me.MonthOffsetLabel)
        Me.Controls.Add(Me.CutOffLabel)
        Me.Controls.Add(Me.PaymentConditionNameTextBox)
        Me.Controls.Add(Me.PaymentConditionNameLabel)
        Me.Controls.Add(Me.EntryButton)
        Me.Name = "PaymentConditionEntry"
        Me.Text = "支払条件の編集"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EntryButton As Button
    Friend WithEvents PaymentConditionNameLabel As Label
    Friend WithEvents PaymentConditionNameTextBox As TextBox
    Friend WithEvents CutOffLabel As Label
    Friend WithEvents CutOffComboBox As ComboBox
    Friend WithEvents MonthOffsetLabel As Label
    Friend WithEvents MonthOffsetComboBox As ComboBox
    Friend WithEvents DueDateLabel As Label
    Friend WithEvents DueDateComboBox As ComboBox
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents BindingSource As BindingSource
    Friend WithEvents ToolTip As ToolTip
End Class
