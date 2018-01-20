<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerEntry
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
        Me.CompanyNameLabel = New System.Windows.Forms.Label()
        Me.CustomerNameTextBox = New System.Windows.Forms.TextBox()
        Me.PICLabel = New System.Windows.Forms.Label()
        Me.PaymentConditionLabel = New System.Windows.Forms.Label()
        Me.EntryButton = New System.Windows.Forms.Button()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CustomerKanaNameTextBox = New System.Windows.Forms.TextBox()
        Me.PICComboBox = New System.Windows.Forms.ComboBox()
        Me.PaymentConditionComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Address1TextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Address2TextBox = New System.Windows.Forms.TextBox()
        Me.PostalCodeMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FocusEmphasizeProvider = New Application.FocusEmphasizeProvider()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CompanyNameLabel
        '
        Me.CompanyNameLabel.AutoSize = True
        Me.CompanyNameLabel.Location = New System.Drawing.Point(59, 16)
        Me.CompanyNameLabel.Name = "CompanyNameLabel"
        Me.CompanyNameLabel.Size = New System.Drawing.Size(41, 12)
        Me.CompanyNameLabel.TabIndex = 1
        Me.CompanyNameLabel.Text = "顧客名"
        '
        'CustomerNameTextBox
        '
        Me.CustomerNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CustomerNameTextBox.Location = New System.Drawing.Point(106, 13)
        Me.CustomerNameTextBox.Name = "CustomerNameTextBox"
        Me.CustomerNameTextBox.Size = New System.Drawing.Size(261, 19)
        Me.CustomerNameTextBox.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.CustomerNameTextBox, "顧客名を入力します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "最大100文字まで入力できます。")
        '
        'PICLabel
        '
        Me.PICLabel.AutoSize = True
        Me.PICLabel.Location = New System.Drawing.Point(35, 60)
        Me.PICLabel.Name = "PICLabel"
        Me.PICLabel.Size = New System.Drawing.Size(65, 12)
        Me.PICLabel.TabIndex = 1
        Me.PICLabel.Text = "営業担当者"
        '
        'PaymentConditionLabel
        '
        Me.PaymentConditionLabel.AutoSize = True
        Me.PaymentConditionLabel.Location = New System.Drawing.Point(47, 84)
        Me.PaymentConditionLabel.Name = "PaymentConditionLabel"
        Me.PaymentConditionLabel.Size = New System.Drawing.Size(53, 12)
        Me.PaymentConditionLabel.TabIndex = 1
        Me.PaymentConditionLabel.Text = "支払条件"
        '
        'EntryButton
        '
        Me.EntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EntryButton.Location = New System.Drawing.Point(292, 185)
        Me.EntryButton.Name = "EntryButton"
        Me.EntryButton.Size = New System.Drawing.Size(75, 23)
        Me.EntryButton.TabIndex = 7
        Me.EntryButton.Text = "登録"
        Me.EntryButton.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider.ContainerControl = Me
        Me.ErrorProvider.DataSource = Me.BindingSource
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "顧客名(かな)"
        '
        'CustomerKanaNameTextBox
        '
        Me.CustomerKanaNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CustomerKanaNameTextBox.Location = New System.Drawing.Point(106, 35)
        Me.CustomerKanaNameTextBox.Name = "CustomerKanaNameTextBox"
        Me.CustomerKanaNameTextBox.Size = New System.Drawing.Size(261, 19)
        Me.CustomerKanaNameTextBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.CustomerKanaNameTextBox, "顧客名(かな)を入力します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "最大100文字まで入力できます。")
        '
        'PICComboBox
        '
        Me.PICComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PICComboBox.FormattingEnabled = True
        Me.PICComboBox.Location = New System.Drawing.Point(106, 57)
        Me.PICComboBox.Name = "PICComboBox"
        Me.PICComboBox.Size = New System.Drawing.Size(112, 20)
        Me.PICComboBox.TabIndex = 2
        Me.ToolTip.SetToolTip(Me.PICComboBox, "営業担当者を選びます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "選択肢に無い場合は「従業員台帳」へ新しい従業員を登録してください。")
        '
        'PaymentConditionComboBox
        '
        Me.PaymentConditionComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PaymentConditionComboBox.FormattingEnabled = True
        Me.PaymentConditionComboBox.Location = New System.Drawing.Point(106, 81)
        Me.PaymentConditionComboBox.Name = "PaymentConditionComboBox"
        Me.PaymentConditionComboBox.Size = New System.Drawing.Size(261, 20)
        Me.PaymentConditionComboBox.TabIndex = 3
        Me.ToolTip.SetToolTip(Me.PaymentConditionComboBox, "この顧客の標準の支払条件を選びます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "選択肢に無い場合は「支払条件の管理」から新しい支払条件を追加してください。")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "郵便番号"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "住所1"
        '
        'Address1TextBox
        '
        Me.Address1TextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Address1TextBox.Location = New System.Drawing.Point(106, 128)
        Me.Address1TextBox.Name = "Address1TextBox"
        Me.Address1TextBox.Size = New System.Drawing.Size(261, 19)
        Me.Address1TextBox.TabIndex = 5
        Me.ToolTip.SetToolTip(Me.Address1TextBox, "この顧客の住所を入力します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "50文字まで入力できます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "この住所は見積書などで1段目に表示されます。")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "住所2"
        '
        'Address2TextBox
        '
        Me.Address2TextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Address2TextBox.Location = New System.Drawing.Point(106, 151)
        Me.Address2TextBox.Name = "Address2TextBox"
        Me.Address2TextBox.Size = New System.Drawing.Size(261, 19)
        Me.Address2TextBox.TabIndex = 6
        Me.ToolTip.SetToolTip(Me.Address2TextBox, "この顧客の住所を入力します。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "50文字まで入力できます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "この住所は見積書などで2段目に表示されます。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'PostalCodeMaskedTextBox
        '
        Me.PostalCodeMaskedTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PostalCodeMaskedTextBox.Location = New System.Drawing.Point(106, 105)
        Me.PostalCodeMaskedTextBox.Mask = "000-0000"
        Me.PostalCodeMaskedTextBox.Name = "PostalCodeMaskedTextBox"
        Me.PostalCodeMaskedTextBox.Size = New System.Drawing.Size(100, 19)
        Me.PostalCodeMaskedTextBox.TabIndex = 4
        Me.ToolTip.SetToolTip(Me.PostalCodeMaskedTextBox, "この顧客の所在地の郵便番号を入力します。")
        '
        'FocusEmphasizeProvider
        '
        Me.FocusEmphasizeProvider.Target = Me
        '
        'CustomerEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 222)
        Me.Controls.Add(Me.PostalCodeMaskedTextBox)
        Me.Controls.Add(Me.PaymentConditionComboBox)
        Me.Controls.Add(Me.PICComboBox)
        Me.Controls.Add(Me.EntryButton)
        Me.Controls.Add(Me.Address2TextBox)
        Me.Controls.Add(Me.Address1TextBox)
        Me.Controls.Add(Me.CustomerKanaNameTextBox)
        Me.Controls.Add(Me.CustomerNameTextBox)
        Me.Controls.Add(Me.PaymentConditionLabel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PICLabel)
        Me.Controls.Add(Me.CompanyNameLabel)
        Me.Name = "CustomerEntry"
        Me.Text = "顧客の登録"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CompanyNameLabel As Label
    Friend WithEvents CustomerNameTextBox As TextBox
    Friend WithEvents PICLabel As Label
    Friend WithEvents PaymentConditionLabel As Label
    Friend WithEvents EntryButton As Button
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents BindingSource As BindingSource
    Friend WithEvents CustomerKanaNameTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PICComboBox As ComboBox
    Friend WithEvents PaymentConditionComboBox As ComboBox
    Friend WithEvents Address2TextBox As TextBox
    Friend WithEvents Address1TextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PostalCodeMaskedTextBox As MaskedTextBox
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents FocusEmphasizeProvider As FocusEmphasizeProvider
End Class
