<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompanyInformationEntry
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
        Me.EntryButton = New System.Windows.Forms.Button()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.PostalCodeLabel = New System.Windows.Forms.Label()
        Me.Address1TextBox = New System.Windows.Forms.TextBox()
        Me.Address1Label = New System.Windows.Forms.Label()
        Me.TelLabel = New System.Windows.Forms.Label()
        Me.Address2TextBox = New System.Windows.Forms.TextBox()
        Me.Address2Label = New System.Windows.Forms.Label()
        Me.FaxLabel = New System.Windows.Forms.Label()
        Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PostalCodeMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.TellMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.FaxMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EntryButton
        '
        Me.EntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EntryButton.Location = New System.Drawing.Point(322, 171)
        Me.EntryButton.Name = "EntryButton"
        Me.EntryButton.Size = New System.Drawing.Size(75, 23)
        Me.EntryButton.TabIndex = 8
        Me.EntryButton.Text = "更新"
        Me.EntryButton.UseVisualStyleBackColor = True
        '
        'NameTextBox
        '
        Me.NameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NameTextBox.Location = New System.Drawing.Point(83, 17)
        Me.NameTextBox.MaxLength = 50
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(314, 19)
        Me.NameTextBox.TabIndex = 1
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(12, 20)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(41, 12)
        Me.NameLabel.TabIndex = 2
        Me.NameLabel.Text = "会社名"
        '
        'PostalCodeLabel
        '
        Me.PostalCodeLabel.AutoSize = True
        Me.PostalCodeLabel.Location = New System.Drawing.Point(12, 44)
        Me.PostalCodeLabel.Name = "PostalCodeLabel"
        Me.PostalCodeLabel.Size = New System.Drawing.Size(53, 12)
        Me.PostalCodeLabel.TabIndex = 2
        Me.PostalCodeLabel.Text = "郵便番号"
        '
        'Address1TextBox
        '
        Me.Address1TextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Address1TextBox.Location = New System.Drawing.Point(83, 64)
        Me.Address1TextBox.MaxLength = 50
        Me.Address1TextBox.Name = "Address1TextBox"
        Me.Address1TextBox.Size = New System.Drawing.Size(314, 19)
        Me.Address1TextBox.TabIndex = 3
        '
        'Address1Label
        '
        Me.Address1Label.AutoSize = True
        Me.Address1Label.Location = New System.Drawing.Point(12, 68)
        Me.Address1Label.Name = "Address1Label"
        Me.Address1Label.Size = New System.Drawing.Size(35, 12)
        Me.Address1Label.TabIndex = 2
        Me.Address1Label.Text = "住所1"
        '
        'TelLabel
        '
        Me.TelLabel.AutoSize = True
        Me.TelLabel.Location = New System.Drawing.Point(12, 118)
        Me.TelLabel.Name = "TelLabel"
        Me.TelLabel.Size = New System.Drawing.Size(53, 12)
        Me.TelLabel.TabIndex = 2
        Me.TelLabel.Text = "電話番号"
        '
        'Address2TextBox
        '
        Me.Address2TextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Address2TextBox.Location = New System.Drawing.Point(83, 89)
        Me.Address2TextBox.MaxLength = 50
        Me.Address2TextBox.Name = "Address2TextBox"
        Me.Address2TextBox.Size = New System.Drawing.Size(314, 19)
        Me.Address2TextBox.TabIndex = 4
        '
        'Address2Label
        '
        Me.Address2Label.AutoSize = True
        Me.Address2Label.Location = New System.Drawing.Point(12, 94)
        Me.Address2Label.Name = "Address2Label"
        Me.Address2Label.Size = New System.Drawing.Size(35, 12)
        Me.Address2Label.TabIndex = 2
        Me.Address2Label.Text = "住所2"
        '
        'FaxLabel
        '
        Me.FaxLabel.AutoSize = True
        Me.FaxLabel.Location = New System.Drawing.Point(12, 143)
        Me.FaxLabel.Name = "FaxLabel"
        Me.FaxLabel.Size = New System.Drawing.Size(51, 12)
        Me.FaxLabel.TabIndex = 2
        Me.FaxLabel.Text = "FAX番号"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'PostalCodeMaskedTextBox
        '
        Me.PostalCodeMaskedTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PostalCodeMaskedTextBox.Location = New System.Drawing.Point(83, 40)
        Me.PostalCodeMaskedTextBox.Mask = "000-0000"
        Me.PostalCodeMaskedTextBox.Name = "PostalCodeMaskedTextBox"
        Me.PostalCodeMaskedTextBox.Size = New System.Drawing.Size(55, 19)
        Me.PostalCodeMaskedTextBox.TabIndex = 9
        '
        'TellMaskedTextBox
        '
        Me.TellMaskedTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TellMaskedTextBox.Location = New System.Drawing.Point(83, 114)
        Me.TellMaskedTextBox.Mask = "99900-9990-0000"
        Me.TellMaskedTextBox.Name = "TellMaskedTextBox"
        Me.TellMaskedTextBox.Size = New System.Drawing.Size(100, 19)
        Me.TellMaskedTextBox.TabIndex = 10
        '
        'FaxMaskedTextBox
        '
        Me.FaxMaskedTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FaxMaskedTextBox.Location = New System.Drawing.Point(83, 136)
        Me.FaxMaskedTextBox.Mask = "99900-9990-0000"
        Me.FaxMaskedTextBox.Name = "FaxMaskedTextBox"
        Me.FaxMaskedTextBox.Size = New System.Drawing.Size(100, 19)
        Me.FaxMaskedTextBox.TabIndex = 10
        '
        'CompanyInformationEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 209)
        Me.Controls.Add(Me.FaxMaskedTextBox)
        Me.Controls.Add(Me.TellMaskedTextBox)
        Me.Controls.Add(Me.PostalCodeMaskedTextBox)
        Me.Controls.Add(Me.FaxLabel)
        Me.Controls.Add(Me.TelLabel)
        Me.Controls.Add(Me.Address2Label)
        Me.Controls.Add(Me.Address2TextBox)
        Me.Controls.Add(Me.Address1Label)
        Me.Controls.Add(Me.Address1TextBox)
        Me.Controls.Add(Me.PostalCodeLabel)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.EntryButton)
        Me.Name = "CompanyInformationEntry"
        Me.Text = "自社情報の設定"
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EntryButton As Button
    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents NameLabel As Label
    Friend WithEvents PostalCodeLabel As Label
    Friend WithEvents Address1TextBox As TextBox
    Friend WithEvents Address1Label As Label
    Friend WithEvents TelLabel As Label
    Friend WithEvents Address2TextBox As TextBox
    Friend WithEvents Address2Label As Label
    Friend WithEvents FaxLabel As Label
    Friend WithEvents BindingSource As BindingSource
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents PostalCodeMaskedTextBox As MaskedTextBox
    Friend WithEvents FaxMaskedTextBox As MaskedTextBox
    Friend WithEvents TellMaskedTextBox As MaskedTextBox
End Class
