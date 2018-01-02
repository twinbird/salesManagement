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
        Me.ClosingDateLabel = New System.Windows.Forms.Label()
        Me.ClosingDateComboBox = New System.Windows.Forms.ComboBox()
        Me.PaymentOffsetMonthLabel = New System.Windows.Forms.Label()
        Me.PaymentOffsetMonthComboBox = New System.Windows.Forms.ComboBox()
        Me.PaymentDayLabel = New System.Windows.Forms.Label()
        Me.PaymentDayComboBox = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        '
        'ClosingDateLabel
        '
        Me.ClosingDateLabel.AutoSize = True
        Me.ClosingDateLabel.Location = New System.Drawing.Point(12, 42)
        Me.ClosingDateLabel.Name = "ClosingDateLabel"
        Me.ClosingDateLabel.Size = New System.Drawing.Size(29, 12)
        Me.ClosingDateLabel.TabIndex = 5
        Me.ClosingDateLabel.Text = "締日"
        '
        'ClosingDateComboBox
        '
        Me.ClosingDateComboBox.FormattingEnabled = True
        Me.ClosingDateComboBox.Location = New System.Drawing.Point(83, 39)
        Me.ClosingDateComboBox.Name = "ClosingDateComboBox"
        Me.ClosingDateComboBox.Size = New System.Drawing.Size(65, 20)
        Me.ClosingDateComboBox.TabIndex = 6
        '
        'PaymentOffsetMonthLabel
        '
        Me.PaymentOffsetMonthLabel.AutoSize = True
        Me.PaymentOffsetMonthLabel.Location = New System.Drawing.Point(12, 69)
        Me.PaymentOffsetMonthLabel.Name = "PaymentOffsetMonthLabel"
        Me.PaymentOffsetMonthLabel.Size = New System.Drawing.Size(41, 12)
        Me.PaymentOffsetMonthLabel.TabIndex = 5
        Me.PaymentOffsetMonthLabel.Text = "支払月"
        '
        'PaymentOffsetMonthComboBox
        '
        Me.PaymentOffsetMonthComboBox.FormattingEnabled = True
        Me.PaymentOffsetMonthComboBox.Location = New System.Drawing.Point(83, 66)
        Me.PaymentOffsetMonthComboBox.Name = "PaymentOffsetMonthComboBox"
        Me.PaymentOffsetMonthComboBox.Size = New System.Drawing.Size(65, 20)
        Me.PaymentOffsetMonthComboBox.TabIndex = 6
        '
        'PaymentDayLabel
        '
        Me.PaymentDayLabel.AutoSize = True
        Me.PaymentDayLabel.Location = New System.Drawing.Point(12, 96)
        Me.PaymentDayLabel.Name = "PaymentDayLabel"
        Me.PaymentDayLabel.Size = New System.Drawing.Size(41, 12)
        Me.PaymentDayLabel.TabIndex = 5
        Me.PaymentDayLabel.Text = "支払日"
        '
        'PaymentDayComboBox
        '
        Me.PaymentDayComboBox.FormattingEnabled = True
        Me.PaymentDayComboBox.Location = New System.Drawing.Point(83, 93)
        Me.PaymentDayComboBox.Name = "PaymentDayComboBox"
        Me.PaymentDayComboBox.Size = New System.Drawing.Size(65, 20)
        Me.PaymentDayComboBox.TabIndex = 6
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'PaymentConditionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 157)
        Me.Controls.Add(Me.PaymentDayComboBox)
        Me.Controls.Add(Me.PaymentOffsetMonthComboBox)
        Me.Controls.Add(Me.ClosingDateComboBox)
        Me.Controls.Add(Me.PaymentDayLabel)
        Me.Controls.Add(Me.PaymentOffsetMonthLabel)
        Me.Controls.Add(Me.ClosingDateLabel)
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
    Friend WithEvents ClosingDateLabel As Label
    Friend WithEvents ClosingDateComboBox As ComboBox
    Friend WithEvents PaymentOffsetMonthLabel As Label
    Friend WithEvents PaymentOffsetMonthComboBox As ComboBox
    Friend WithEvents PaymentDayLabel As Label
    Friend WithEvents PaymentDayComboBox As ComboBox
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents BindingSource As BindingSource
End Class
