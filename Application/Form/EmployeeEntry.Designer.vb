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
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EntryButton
        '
        Me.EntryButton.Location = New System.Drawing.Point(307, 101)
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
        Me.NameTextBox.TabIndex = 4
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
        Me.KanaNameTextBox.TabIndex = 4
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
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
End Class
