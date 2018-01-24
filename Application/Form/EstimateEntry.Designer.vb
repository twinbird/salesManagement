<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstimateEntry
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
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.TitleTextBox = New System.Windows.Forms.TextBox()
        Me.EstimateNoLabel = New System.Windows.Forms.Label()
        Me.IssueDateLabel = New System.Windows.Forms.Label()
        Me.CustomerLabel = New System.Windows.Forms.Label()
        Me.EntryButton = New System.Windows.Forms.Button()
        Me.PrintPreviewButton = New System.Windows.Forms.Button()
        Me.DetailsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DueDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.DueDateLabel = New System.Windows.Forms.Label()
        Me.PaymentConditionLabel = New System.Windows.Forms.Label()
        Me.PaymentConditionComboBox = New System.Windows.Forms.ComboBox()
        Me.PICEmployeeLabel = New System.Windows.Forms.Label()
        Me.PICEmployeeComboBox = New System.Windows.Forms.ComboBox()
        Me.EffectiveDateLabel = New System.Windows.Forms.Label()
        Me.EffectiveDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.RemarksLabel = New System.Windows.Forms.Label()
        Me.RemarksTextBox = New System.Windows.Forms.TextBox()
        Me.CustomerComboBox = New System.Windows.Forms.ComboBox()
        Me.EstimateNoTextBox = New System.Windows.Forms.TextBox()
        Me.IssueDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.TaxRateLabel = New System.Windows.Forms.Label()
        Me.TaxRateTextBox = New System.Windows.Forms.TextBox()
        Me.EstimatePriceLabel = New System.Windows.Forms.Label()
        Me.EstimatePriceTextBox = New System.Windows.Forms.TextBox()
        Me.EstimatePriceIncludeTaxLabel = New System.Windows.Forms.Label()
        Me.EstimatePriceIncludeTaxTextBox = New System.Windows.Forms.TextBox()
        CType(Me.DetailsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Location = New System.Drawing.Point(14, 39)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(29, 12)
        Me.TitleLabel.TabIndex = 0
        Me.TitleLabel.Text = "件名"
        '
        'TitleTextBox
        '
        Me.TitleTextBox.Location = New System.Drawing.Point(71, 35)
        Me.TitleTextBox.Name = "TitleTextBox"
        Me.TitleTextBox.Size = New System.Drawing.Size(311, 19)
        Me.TitleTextBox.TabIndex = 1
        '
        'EstimateNoLabel
        '
        Me.EstimateNoLabel.AutoSize = True
        Me.EstimateNoLabel.Location = New System.Drawing.Point(14, 16)
        Me.EstimateNoLabel.Name = "EstimateNoLabel"
        Me.EstimateNoLabel.Size = New System.Drawing.Size(53, 12)
        Me.EstimateNoLabel.TabIndex = 0
        Me.EstimateNoLabel.Text = "見積番号"
        '
        'IssueDateLabel
        '
        Me.IssueDateLabel.AutoSize = True
        Me.IssueDateLabel.Location = New System.Drawing.Point(446, 16)
        Me.IssueDateLabel.Name = "IssueDateLabel"
        Me.IssueDateLabel.Size = New System.Drawing.Size(41, 12)
        Me.IssueDateLabel.TabIndex = 0
        Me.IssueDateLabel.Text = "発行日"
        '
        'CustomerLabel
        '
        Me.CustomerLabel.AutoSize = True
        Me.CustomerLabel.Location = New System.Drawing.Point(12, 62)
        Me.CustomerLabel.Name = "CustomerLabel"
        Me.CustomerLabel.Size = New System.Drawing.Size(41, 12)
        Me.CustomerLabel.TabIndex = 0
        Me.CustomerLabel.Text = "顧客名"
        '
        'EntryButton
        '
        Me.EntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EntryButton.Location = New System.Drawing.Point(674, 434)
        Me.EntryButton.Name = "EntryButton"
        Me.EntryButton.Size = New System.Drawing.Size(75, 23)
        Me.EntryButton.TabIndex = 2
        Me.EntryButton.Text = "登録"
        Me.EntryButton.UseVisualStyleBackColor = True
        '
        'PrintPreviewButton
        '
        Me.PrintPreviewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintPreviewButton.Location = New System.Drawing.Point(557, 434)
        Me.PrintPreviewButton.Name = "PrintPreviewButton"
        Me.PrintPreviewButton.Size = New System.Drawing.Size(111, 23)
        Me.PrintPreviewButton.TabIndex = 2
        Me.PrintPreviewButton.Text = "見積書プレビュー"
        Me.PrintPreviewButton.UseVisualStyleBackColor = True
        '
        'DetailsDataGridView
        '
        Me.DetailsDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DetailsDataGridView.Location = New System.Drawing.Point(12, 125)
        Me.DetailsDataGridView.Name = "DetailsDataGridView"
        Me.DetailsDataGridView.RowHeadersVisible = False
        Me.DetailsDataGridView.RowTemplate.Height = 21
        Me.DetailsDataGridView.Size = New System.Drawing.Size(737, 187)
        Me.DetailsDataGridView.TabIndex = 4
        '
        'DueDateDateTimePicker
        '
        Me.DueDateDateTimePicker.Location = New System.Drawing.Point(496, 35)
        Me.DueDateDateTimePicker.Name = "DueDateDateTimePicker"
        Me.DueDateDateTimePicker.Size = New System.Drawing.Size(132, 19)
        Me.DueDateDateTimePicker.TabIndex = 5
        '
        'DueDateLabel
        '
        Me.DueDateLabel.AutoSize = True
        Me.DueDateLabel.Location = New System.Drawing.Point(458, 38)
        Me.DueDateLabel.Name = "DueDateLabel"
        Me.DueDateLabel.Size = New System.Drawing.Size(29, 12)
        Me.DueDateLabel.TabIndex = 0
        Me.DueDateLabel.Text = "納期"
        '
        'PaymentConditionLabel
        '
        Me.PaymentConditionLabel.AutoSize = True
        Me.PaymentConditionLabel.Location = New System.Drawing.Point(12, 88)
        Me.PaymentConditionLabel.Name = "PaymentConditionLabel"
        Me.PaymentConditionLabel.Size = New System.Drawing.Size(53, 12)
        Me.PaymentConditionLabel.TabIndex = 0
        Me.PaymentConditionLabel.Text = "支払条件"
        '
        'PaymentConditionComboBox
        '
        Me.PaymentConditionComboBox.FormattingEnabled = True
        Me.PaymentConditionComboBox.Location = New System.Drawing.Point(71, 85)
        Me.PaymentConditionComboBox.Name = "PaymentConditionComboBox"
        Me.PaymentConditionComboBox.Size = New System.Drawing.Size(206, 20)
        Me.PaymentConditionComboBox.TabIndex = 6
        '
        'PICEmployeeLabel
        '
        Me.PICEmployeeLabel.AutoSize = True
        Me.PICEmployeeLabel.Location = New System.Drawing.Point(434, 85)
        Me.PICEmployeeLabel.Name = "PICEmployeeLabel"
        Me.PICEmployeeLabel.Size = New System.Drawing.Size(53, 12)
        Me.PICEmployeeLabel.TabIndex = 0
        Me.PICEmployeeLabel.Text = "担当営業"
        '
        'PICEmployeeComboBox
        '
        Me.PICEmployeeComboBox.FormattingEnabled = True
        Me.PICEmployeeComboBox.Location = New System.Drawing.Point(496, 82)
        Me.PICEmployeeComboBox.Name = "PICEmployeeComboBox"
        Me.PICEmployeeComboBox.Size = New System.Drawing.Size(132, 20)
        Me.PICEmployeeComboBox.TabIndex = 6
        '
        'EffectiveDateLabel
        '
        Me.EffectiveDateLabel.AutoSize = True
        Me.EffectiveDateLabel.Location = New System.Drawing.Point(410, 62)
        Me.EffectiveDateLabel.Name = "EffectiveDateLabel"
        Me.EffectiveDateLabel.Size = New System.Drawing.Size(77, 12)
        Me.EffectiveDateLabel.TabIndex = 0
        Me.EffectiveDateLabel.Text = "見積有効期限"
        '
        'EffectiveDateDateTimePicker
        '
        Me.EffectiveDateDateTimePicker.Location = New System.Drawing.Point(496, 59)
        Me.EffectiveDateDateTimePicker.Name = "EffectiveDateDateTimePicker"
        Me.EffectiveDateDateTimePicker.Size = New System.Drawing.Size(132, 19)
        Me.EffectiveDateDateTimePicker.TabIndex = 5
        '
        'RemarksLabel
        '
        Me.RemarksLabel.AutoSize = True
        Me.RemarksLabel.Location = New System.Drawing.Point(14, 345)
        Me.RemarksLabel.Name = "RemarksLabel"
        Me.RemarksLabel.Size = New System.Drawing.Size(29, 12)
        Me.RemarksLabel.TabIndex = 7
        Me.RemarksLabel.Text = "備考"
        '
        'RemarksTextBox
        '
        Me.RemarksTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RemarksTextBox.Location = New System.Drawing.Point(14, 360)
        Me.RemarksTextBox.Multiline = True
        Me.RemarksTextBox.Name = "RemarksTextBox"
        Me.RemarksTextBox.Size = New System.Drawing.Size(735, 68)
        Me.RemarksTextBox.TabIndex = 8
        '
        'CustomerComboBox
        '
        Me.CustomerComboBox.FormattingEnabled = True
        Me.CustomerComboBox.Location = New System.Drawing.Point(71, 59)
        Me.CustomerComboBox.Name = "CustomerComboBox"
        Me.CustomerComboBox.Size = New System.Drawing.Size(206, 20)
        Me.CustomerComboBox.TabIndex = 6
        '
        'EstimateNoTextBox
        '
        Me.EstimateNoTextBox.Location = New System.Drawing.Point(71, 13)
        Me.EstimateNoTextBox.Name = "EstimateNoTextBox"
        Me.EstimateNoTextBox.ReadOnly = True
        Me.EstimateNoTextBox.Size = New System.Drawing.Size(206, 19)
        Me.EstimateNoTextBox.TabIndex = 1
        '
        'IssueDateDateTimePicker
        '
        Me.IssueDateDateTimePicker.Location = New System.Drawing.Point(496, 13)
        Me.IssueDateDateTimePicker.Name = "IssueDateDateTimePicker"
        Me.IssueDateDateTimePicker.Size = New System.Drawing.Size(132, 19)
        Me.IssueDateDateTimePicker.TabIndex = 5
        '
        'TaxRateLabel
        '
        Me.TaxRateLabel.AutoSize = True
        Me.TaxRateLabel.Location = New System.Drawing.Point(426, 324)
        Me.TaxRateLabel.Name = "TaxRateLabel"
        Me.TaxRateLabel.Size = New System.Drawing.Size(29, 12)
        Me.TaxRateLabel.TabIndex = 0
        Me.TaxRateLabel.Text = "税率"
        '
        'TaxRateTextBox
        '
        Me.TaxRateTextBox.Location = New System.Drawing.Point(458, 321)
        Me.TaxRateTextBox.Name = "TaxRateTextBox"
        Me.TaxRateTextBox.ReadOnly = True
        Me.TaxRateTextBox.Size = New System.Drawing.Size(46, 19)
        Me.TaxRateTextBox.TabIndex = 1
        '
        'EstimatePriceLabel
        '
        Me.EstimatePriceLabel.AutoSize = True
        Me.EstimatePriceLabel.Location = New System.Drawing.Point(205, 324)
        Me.EstimatePriceLabel.Name = "EstimatePriceLabel"
        Me.EstimatePriceLabel.Size = New System.Drawing.Size(65, 12)
        Me.EstimatePriceLabel.TabIndex = 0
        Me.EstimatePriceLabel.Text = "御見積金額"
        '
        'EstimatePriceTextBox
        '
        Me.EstimatePriceTextBox.Location = New System.Drawing.Point(276, 321)
        Me.EstimatePriceTextBox.Name = "EstimatePriceTextBox"
        Me.EstimatePriceTextBox.ReadOnly = True
        Me.EstimatePriceTextBox.Size = New System.Drawing.Size(139, 19)
        Me.EstimatePriceTextBox.TabIndex = 1
        '
        'EstimatePriceIncludeTaxLabel
        '
        Me.EstimatePriceIncludeTaxLabel.AutoSize = True
        Me.EstimatePriceIncludeTaxLabel.Location = New System.Drawing.Point(510, 324)
        Me.EstimatePriceIncludeTaxLabel.Name = "EstimatePriceIncludeTaxLabel"
        Me.EstimatePriceIncludeTaxLabel.Size = New System.Drawing.Size(97, 12)
        Me.EstimatePriceIncludeTaxLabel.TabIndex = 0
        Me.EstimatePriceIncludeTaxLabel.Text = "御見積金額(税込)"
        '
        'EstimatePriceIncludeTaxTextBox
        '
        Me.EstimatePriceIncludeTaxTextBox.Location = New System.Drawing.Point(612, 321)
        Me.EstimatePriceIncludeTaxTextBox.Name = "EstimatePriceIncludeTaxTextBox"
        Me.EstimatePriceIncludeTaxTextBox.ReadOnly = True
        Me.EstimatePriceIncludeTaxTextBox.Size = New System.Drawing.Size(139, 19)
        Me.EstimatePriceIncludeTaxTextBox.TabIndex = 1
        '
        'EstimateEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 461)
        Me.Controls.Add(Me.RemarksTextBox)
        Me.Controls.Add(Me.RemarksLabel)
        Me.Controls.Add(Me.PICEmployeeComboBox)
        Me.Controls.Add(Me.CustomerComboBox)
        Me.Controls.Add(Me.PaymentConditionComboBox)
        Me.Controls.Add(Me.EffectiveDateDateTimePicker)
        Me.Controls.Add(Me.IssueDateDateTimePicker)
        Me.Controls.Add(Me.DueDateDateTimePicker)
        Me.Controls.Add(Me.DetailsDataGridView)
        Me.Controls.Add(Me.PrintPreviewButton)
        Me.Controls.Add(Me.EntryButton)
        Me.Controls.Add(Me.TaxRateTextBox)
        Me.Controls.Add(Me.EstimatePriceTextBox)
        Me.Controls.Add(Me.EstimatePriceIncludeTaxTextBox)
        Me.Controls.Add(Me.EstimateNoTextBox)
        Me.Controls.Add(Me.TitleTextBox)
        Me.Controls.Add(Me.IssueDateLabel)
        Me.Controls.Add(Me.TaxRateLabel)
        Me.Controls.Add(Me.EstimatePriceLabel)
        Me.Controls.Add(Me.EstimatePriceIncludeTaxLabel)
        Me.Controls.Add(Me.EstimateNoLabel)
        Me.Controls.Add(Me.PICEmployeeLabel)
        Me.Controls.Add(Me.EffectiveDateLabel)
        Me.Controls.Add(Me.PaymentConditionLabel)
        Me.Controls.Add(Me.DueDateLabel)
        Me.Controls.Add(Me.CustomerLabel)
        Me.Controls.Add(Me.TitleLabel)
        Me.Name = "EstimateEntry"
        Me.Text = "見積書の作成"
        CType(Me.DetailsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TitleLabel As Label
    Friend WithEvents TitleTextBox As TextBox
    Friend WithEvents EstimateNoLabel As Label
    Friend WithEvents IssueDateLabel As Label
    Friend WithEvents CustomerLabel As Label
    Friend WithEvents EntryButton As Button
    Friend WithEvents PrintPreviewButton As Button
    Friend WithEvents DetailsDataGridView As DataGridView
    Friend WithEvents DueDateDateTimePicker As DateTimePicker
    Friend WithEvents DueDateLabel As Label
    Friend WithEvents PaymentConditionLabel As Label
    Friend WithEvents PaymentConditionComboBox As ComboBox
    Friend WithEvents PICEmployeeLabel As Label
    Friend WithEvents PICEmployeeComboBox As ComboBox
    Friend WithEvents EffectiveDateLabel As Label
    Friend WithEvents EffectiveDateDateTimePicker As DateTimePicker
    Friend WithEvents RemarksLabel As Label
    Friend WithEvents RemarksTextBox As TextBox
    Friend WithEvents CustomerComboBox As ComboBox
    Friend WithEvents EstimateNoTextBox As TextBox
    Friend WithEvents IssueDateDateTimePicker As DateTimePicker
    Friend WithEvents TaxRateLabel As Label
    Friend WithEvents TaxRateTextBox As TextBox
    Friend WithEvents EstimatePriceLabel As Label
    Friend WithEvents EstimatePriceTextBox As TextBox
    Friend WithEvents EstimatePriceIncludeTaxLabel As Label
    Friend WithEvents EstimatePriceIncludeTaxTextBox As TextBox
End Class
