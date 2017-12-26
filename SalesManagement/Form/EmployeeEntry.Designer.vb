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
        Me.EntryButton = New System.Windows.Forms.Button()
        Me.EmployeeNumberLabel = New System.Windows.Forms.Label()
        Me.EmployeeNumberTextBox = New System.Windows.Forms.TextBox()
        Me.LastNameLabel = New System.Windows.Forms.Label()
        Me.LastNameTextBox = New System.Windows.Forms.TextBox()
        Me.FirstNameLabel = New System.Windows.Forms.Label()
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.KanaLastNameLabel = New System.Windows.Forms.Label()
        Me.KanaLastNameTextBox = New System.Windows.Forms.TextBox()
        Me.KanaFirstNameLabel = New System.Windows.Forms.Label()
        Me.KanaFirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'EntryButton
        '
        Me.EntryButton.Location = New System.Drawing.Point(307, 159)
        Me.EntryButton.Name = "EntryButton"
        Me.EntryButton.Size = New System.Drawing.Size(75, 23)
        Me.EntryButton.TabIndex = 0
        Me.EntryButton.Text = "登録"
        Me.EntryButton.UseVisualStyleBackColor = True
        '
        'EmployeeNumberLabel
        '
        Me.EmployeeNumberLabel.AutoSize = True
        Me.EmployeeNumberLabel.Location = New System.Drawing.Point(33, 19)
        Me.EmployeeNumberLabel.Name = "EmployeeNumberLabel"
        Me.EmployeeNumberLabel.Size = New System.Drawing.Size(55, 12)
        Me.EmployeeNumberLabel.TabIndex = 1
        Me.EmployeeNumberLabel.Text = "従業員No"
        '
        'EmployeeNumberTextBox
        '
        Me.EmployeeNumberTextBox.Location = New System.Drawing.Point(104, 16)
        Me.EmployeeNumberTextBox.Name = "EmployeeNumberTextBox"
        Me.EmployeeNumberTextBox.Size = New System.Drawing.Size(100, 19)
        Me.EmployeeNumberTextBox.TabIndex = 2
        '
        'LastNameLabel
        '
        Me.LastNameLabel.AutoSize = True
        Me.LastNameLabel.Location = New System.Drawing.Point(33, 45)
        Me.LastNameLabel.Name = "LastNameLabel"
        Me.LastNameLabel.Size = New System.Drawing.Size(49, 12)
        Me.LastNameLabel.TabIndex = 3
        Me.LastNameLabel.Text = "名前(姓)"
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.Location = New System.Drawing.Point(104, 42)
        Me.LastNameTextBox.MaxLength = 20
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(278, 19)
        Me.LastNameTextBox.TabIndex = 4
        '
        'FirstNameLabel
        '
        Me.FirstNameLabel.AutoSize = True
        Me.FirstNameLabel.Location = New System.Drawing.Point(33, 71)
        Me.FirstNameLabel.Name = "FirstNameLabel"
        Me.FirstNameLabel.Size = New System.Drawing.Size(49, 12)
        Me.FirstNameLabel.TabIndex = 3
        Me.FirstNameLabel.Text = "名前(名)"
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.Location = New System.Drawing.Point(104, 68)
        Me.FirstNameTextBox.MaxLength = 20
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(278, 19)
        Me.FirstNameTextBox.TabIndex = 4
        '
        'KanaLastNameLabel
        '
        Me.KanaLastNameLabel.AutoSize = True
        Me.KanaLastNameLabel.Location = New System.Drawing.Point(33, 99)
        Me.KanaLastNameLabel.Name = "KanaLastNameLabel"
        Me.KanaLastNameLabel.Size = New System.Drawing.Size(57, 12)
        Me.KanaLastNameLabel.TabIndex = 3
        Me.KanaLastNameLabel.Text = "かな名(姓)"
        '
        'KanaLastNameTextBox
        '
        Me.KanaLastNameTextBox.Location = New System.Drawing.Point(104, 96)
        Me.KanaLastNameTextBox.MaxLength = 20
        Me.KanaLastNameTextBox.Name = "KanaLastNameTextBox"
        Me.KanaLastNameTextBox.Size = New System.Drawing.Size(278, 19)
        Me.KanaLastNameTextBox.TabIndex = 4
        '
        'KanaFirstNameLabel
        '
        Me.KanaFirstNameLabel.AutoSize = True
        Me.KanaFirstNameLabel.Location = New System.Drawing.Point(33, 125)
        Me.KanaFirstNameLabel.Name = "KanaFirstNameLabel"
        Me.KanaFirstNameLabel.Size = New System.Drawing.Size(57, 12)
        Me.KanaFirstNameLabel.TabIndex = 3
        Me.KanaFirstNameLabel.Text = "かな名(名)"
        '
        'KanaFirstNameTextBox
        '
        Me.KanaFirstNameTextBox.Location = New System.Drawing.Point(104, 122)
        Me.KanaFirstNameTextBox.MaxLength = 20
        Me.KanaFirstNameTextBox.Name = "KanaFirstNameTextBox"
        Me.KanaFirstNameTextBox.Size = New System.Drawing.Size(278, 19)
        Me.KanaFirstNameTextBox.TabIndex = 4
        '
        'EmployeeEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 190)
        Me.Controls.Add(Me.KanaFirstNameTextBox)
        Me.Controls.Add(Me.KanaLastNameTextBox)
        Me.Controls.Add(Me.FirstNameTextBox)
        Me.Controls.Add(Me.LastNameTextBox)
        Me.Controls.Add(Me.KanaFirstNameLabel)
        Me.Controls.Add(Me.KanaLastNameLabel)
        Me.Controls.Add(Me.FirstNameLabel)
        Me.Controls.Add(Me.LastNameLabel)
        Me.Controls.Add(Me.EmployeeNumberTextBox)
        Me.Controls.Add(Me.EmployeeNumberLabel)
        Me.Controls.Add(Me.EntryButton)
        Me.Name = "EmployeeEntry"
        Me.Text = "従業員情報の管理"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EntryButton As Button
    Friend WithEvents EmployeeNumberLabel As Label
    Friend WithEvents EmployeeNumberTextBox As TextBox
    Friend WithEvents LastNameLabel As Label
    Friend WithEvents LastNameTextBox As TextBox
    Friend WithEvents FirstNameLabel As Label
    Friend WithEvents FirstNameTextBox As TextBox
    Friend WithEvents KanaLastNameLabel As Label
    Friend WithEvents KanaLastNameTextBox As TextBox
    Friend WithEvents KanaFirstNameLabel As Label
    Friend WithEvents KanaFirstNameTextBox As TextBox
End Class
