<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeEntry
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
        Me.EmployeeNumberLabel = New System.Windows.Forms.Label()
        Me.EmployeeNumberTextBox = New System.Windows.Forms.TextBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.KanaNameLabel = New System.Windows.Forms.Label()
        Me.KanaNameTextBox = New System.Windows.Forms.TextBox()
        Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FocusEmphasizeProvider = New Application.FocusEmphasizeProvider()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EntryButton
        '
        Me.EntryButton.Location = New System.Drawing.Point(307, 101)
        Me.EntryButton.Name = "EntryButton"
        Me.EntryButton.Size = New System.Drawing.Size(75, 23)
        Me.EntryButton.TabIndex = 3
        Me.EntryButton.Text = "登録"
        Me.EntryButton.UseVisualStyleBackColor = True
        '
        'EmployeeNumberLabel
        '
        Me.EmployeeNumberLabel.AutoSize = True
        Me.EmployeeNumberLabel.Location = New System.Drawing.Point(33, 19)
        Me.EmployeeNumberLabel.Name = "EmployeeNumberLabel"
        Me.EmployeeNumberLabel.Size = New System.Drawing.Size(65, 12)
        Me.EmployeeNumberLabel.TabIndex = 1
        Me.EmployeeNumberLabel.Text = "従業員番号"
        Me.ToolTip.SetToolTip(Me.EmployeeNumberLabel, "従業員に割り当てる番号です。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "この番号は各従業員に一意でなければなりません。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1～5文字で自由な文字で指定できます。")
        '
        'EmployeeNumberTextBox
        '
        Me.EmployeeNumberTextBox.Location = New System.Drawing.Point(104, 16)
        Me.EmployeeNumberTextBox.Name = "EmployeeNumberTextBox"
        Me.EmployeeNumberTextBox.Size = New System.Drawing.Size(100, 19)
        Me.EmployeeNumberTextBox.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.EmployeeNumberTextBox, "従業員に割り当てる番号です。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "この番号は他の従業員と重複してはいけません。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1～5文字で指定できます。")
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(33, 45)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(29, 12)
        Me.NameLabel.TabIndex = 3
        Me.NameLabel.Text = "名前"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(104, 42)
        Me.NameTextBox.MaxLength = 20
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(278, 19)
        Me.NameTextBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.NameTextBox, "従業員の名前です。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1～20文字で指定してください。")
        '
        'KanaNameLabel
        '
        Me.KanaNameLabel.AutoSize = True
        Me.KanaNameLabel.Location = New System.Drawing.Point(33, 70)
        Me.KanaNameLabel.Name = "KanaNameLabel"
        Me.KanaNameLabel.Size = New System.Drawing.Size(37, 12)
        Me.KanaNameLabel.TabIndex = 3
        Me.KanaNameLabel.Text = "かな名"
        '
        'KanaNameTextBox
        '
        Me.KanaNameTextBox.Location = New System.Drawing.Point(104, 67)
        Me.KanaNameTextBox.MaxLength = 20
        Me.KanaNameTextBox.Name = "KanaNameTextBox"
        Me.KanaNameTextBox.Size = New System.Drawing.Size(278, 19)
        Me.KanaNameTextBox.TabIndex = 2
        Me.ToolTip.SetToolTip(Me.KanaNameTextBox, "従業員のひらがなでの名前です。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1～20文字で指定してください。")
        '
        'ErrorProvider
        '
        Me.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider.ContainerControl = Me
        '
        'FocusEmphasizeProvider
        '
        Me.FocusEmphasizeProvider.Target = Me
        '
        'EmployeeEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 137)
        Me.Controls.Add(Me.KanaNameTextBox)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.KanaNameLabel)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.EmployeeNumberTextBox)
        Me.Controls.Add(Me.EmployeeNumberLabel)
        Me.Controls.Add(Me.EntryButton)
        Me.Name = "EmployeeEntry"
        Me.Text = "従業員情報の編集"
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EntryButton As Button
    Friend WithEvents EmployeeNumberLabel As Label
    Friend WithEvents EmployeeNumberTextBox As TextBox
    Friend WithEvents NameLabel As Label
    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents KanaNameLabel As Label
    Friend WithEvents KanaNameTextBox As TextBox
    Friend WithEvents BindingSource As BindingSource
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents FocusEmphasizeProvider As FocusEmphasizeProvider
End Class
