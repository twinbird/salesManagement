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
        Me.PostalCodeTextBox = New System.Windows.Forms.TextBox()
        Me.PostalCodeLabel = New System.Windows.Forms.Label()
        Me.Address1TextBox = New System.Windows.Forms.TextBox()
        Me.Address1Label = New System.Windows.Forms.Label()
        Me.TelTextBox = New System.Windows.Forms.TextBox()
        Me.TelLabel = New System.Windows.Forms.Label()
        Me.ApplyDateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.ApplyDateLabel = New System.Windows.Forms.Label()
        Me.Address2TextBox = New System.Windows.Forms.TextBox()
        Me.Address2Label = New System.Windows.Forms.Label()
        Me.FaxTextBox = New System.Windows.Forms.TextBox()
        Me.FaxLabel = New System.Windows.Forms.Label()
        Me.HistoryDataGridView = New System.Windows.Forms.DataGridView()
        Me.applyDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HistoryLabel = New System.Windows.Forms.Label()
        Me.CompanyInformationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CompanyInformationErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.FormTitleLabel = New System.Windows.Forms.Label()
        CType(Me.HistoryDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyInformationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyInformationErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EntryButton
        '
        Me.EntryButton.Location = New System.Drawing.Point(532, 228)
        Me.EntryButton.Name = "EntryButton"
        Me.EntryButton.Size = New System.Drawing.Size(75, 23)
        Me.EntryButton.TabIndex = 8
        Me.EntryButton.Text = "登録"
        Me.EntryButton.UseVisualStyleBackColor = True
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(108, 76)
        Me.NameTextBox.MaxLength = 50
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(314, 19)
        Me.NameTextBox.TabIndex = 1
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(37, 79)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(41, 12)
        Me.NameLabel.TabIndex = 2
        Me.NameLabel.Text = "会社名"
        '
        'PostalCodeTextBox
        '
        Me.PostalCodeTextBox.Location = New System.Drawing.Point(108, 104)
        Me.PostalCodeTextBox.MaxLength = 10
        Me.PostalCodeTextBox.Name = "PostalCodeTextBox"
        Me.PostalCodeTextBox.Size = New System.Drawing.Size(314, 19)
        Me.PostalCodeTextBox.TabIndex = 2
        '
        'PostalCodeLabel
        '
        Me.PostalCodeLabel.AutoSize = True
        Me.PostalCodeLabel.Location = New System.Drawing.Point(37, 108)
        Me.PostalCodeLabel.Name = "PostalCodeLabel"
        Me.PostalCodeLabel.Size = New System.Drawing.Size(53, 12)
        Me.PostalCodeLabel.TabIndex = 2
        Me.PostalCodeLabel.Text = "郵便番号"
        '
        'Address1TextBox
        '
        Me.Address1TextBox.Location = New System.Drawing.Point(108, 129)
        Me.Address1TextBox.MaxLength = 50
        Me.Address1TextBox.Name = "Address1TextBox"
        Me.Address1TextBox.Size = New System.Drawing.Size(314, 19)
        Me.Address1TextBox.TabIndex = 3
        '
        'Address1Label
        '
        Me.Address1Label.AutoSize = True
        Me.Address1Label.Location = New System.Drawing.Point(37, 132)
        Me.Address1Label.Name = "Address1Label"
        Me.Address1Label.Size = New System.Drawing.Size(35, 12)
        Me.Address1Label.TabIndex = 2
        Me.Address1Label.Text = "住所1"
        '
        'TelTextBox
        '
        Me.TelTextBox.Location = New System.Drawing.Point(108, 180)
        Me.TelTextBox.MaxLength = 15
        Me.TelTextBox.Name = "TelTextBox"
        Me.TelTextBox.Size = New System.Drawing.Size(314, 19)
        Me.TelTextBox.TabIndex = 5
        '
        'TelLabel
        '
        Me.TelLabel.AutoSize = True
        Me.TelLabel.Location = New System.Drawing.Point(37, 183)
        Me.TelLabel.Name = "TelLabel"
        Me.TelLabel.Size = New System.Drawing.Size(53, 12)
        Me.TelLabel.TabIndex = 2
        Me.TelLabel.Text = "電話番号"
        '
        'ApplyDateDateTimePicker
        '
        Me.ApplyDateDateTimePicker.Location = New System.Drawing.Point(108, 50)
        Me.ApplyDateDateTimePicker.Name = "ApplyDateDateTimePicker"
        Me.ApplyDateDateTimePicker.Size = New System.Drawing.Size(129, 19)
        Me.ApplyDateDateTimePicker.TabIndex = 0
        '
        'ApplyDateLabel
        '
        Me.ApplyDateLabel.AutoSize = True
        Me.ApplyDateLabel.Location = New System.Drawing.Point(37, 55)
        Me.ApplyDateLabel.Name = "ApplyDateLabel"
        Me.ApplyDateLabel.Size = New System.Drawing.Size(65, 12)
        Me.ApplyDateLabel.TabIndex = 2
        Me.ApplyDateLabel.Text = "適用開始日"
        '
        'Address2TextBox
        '
        Me.Address2TextBox.Location = New System.Drawing.Point(108, 154)
        Me.Address2TextBox.MaxLength = 50
        Me.Address2TextBox.Name = "Address2TextBox"
        Me.Address2TextBox.Size = New System.Drawing.Size(314, 19)
        Me.Address2TextBox.TabIndex = 4
        '
        'Address2Label
        '
        Me.Address2Label.AutoSize = True
        Me.Address2Label.Location = New System.Drawing.Point(37, 157)
        Me.Address2Label.Name = "Address2Label"
        Me.Address2Label.Size = New System.Drawing.Size(35, 12)
        Me.Address2Label.TabIndex = 2
        Me.Address2Label.Text = "住所2"
        '
        'FaxTextBox
        '
        Me.FaxTextBox.Location = New System.Drawing.Point(108, 205)
        Me.FaxTextBox.MaxLength = 15
        Me.FaxTextBox.Name = "FaxTextBox"
        Me.FaxTextBox.Size = New System.Drawing.Size(314, 19)
        Me.FaxTextBox.TabIndex = 6
        '
        'FaxLabel
        '
        Me.FaxLabel.AutoSize = True
        Me.FaxLabel.Location = New System.Drawing.Point(37, 208)
        Me.FaxLabel.Name = "FaxLabel"
        Me.FaxLabel.Size = New System.Drawing.Size(51, 12)
        Me.FaxLabel.TabIndex = 2
        Me.FaxLabel.Text = "FAX番号"
        '
        'HistoryDataGridView
        '
        Me.HistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HistoryDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.applyDate})
        Me.HistoryDataGridView.Location = New System.Drawing.Point(447, 70)
        Me.HistoryDataGridView.Name = "HistoryDataGridView"
        Me.HistoryDataGridView.RowTemplate.Height = 21
        Me.HistoryDataGridView.Size = New System.Drawing.Size(160, 150)
        Me.HistoryDataGridView.TabIndex = 7
        '
        'applyDate
        '
        Me.applyDate.HeaderText = "適用開始日"
        Me.applyDate.Name = "applyDate"
        Me.applyDate.ReadOnly = True
        '
        'HistoryLabel
        '
        Me.HistoryLabel.AutoSize = True
        Me.HistoryLabel.Location = New System.Drawing.Point(445, 55)
        Me.HistoryLabel.Name = "HistoryLabel"
        Me.HistoryLabel.Size = New System.Drawing.Size(29, 12)
        Me.HistoryLabel.TabIndex = 5
        Me.HistoryLabel.Text = "履歴"
        '
        'CompanyInformationErrorProvider
        '
        Me.CompanyInformationErrorProvider.ContainerControl = Me
        '
        'FormTitleLabel
        '
        Me.FormTitleLabel.AutoSize = True
        Me.FormTitleLabel.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormTitleLabel.Location = New System.Drawing.Point(12, 9)
        Me.FormTitleLabel.Name = "FormTitleLabel"
        Me.FormTitleLabel.Size = New System.Drawing.Size(181, 24)
        Me.FormTitleLabel.TabIndex = 9
        Me.FormTitleLabel.Text = "自社情報の設定"
        '
        'CompanyInformationEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 263)
        Me.Controls.Add(Me.FormTitleLabel)
        Me.Controls.Add(Me.HistoryLabel)
        Me.Controls.Add(Me.HistoryDataGridView)
        Me.Controls.Add(Me.ApplyDateDateTimePicker)
        Me.Controls.Add(Me.FaxLabel)
        Me.Controls.Add(Me.FaxTextBox)
        Me.Controls.Add(Me.TelLabel)
        Me.Controls.Add(Me.TelTextBox)
        Me.Controls.Add(Me.Address2Label)
        Me.Controls.Add(Me.Address2TextBox)
        Me.Controls.Add(Me.Address1Label)
        Me.Controls.Add(Me.Address1TextBox)
        Me.Controls.Add(Me.PostalCodeLabel)
        Me.Controls.Add(Me.PostalCodeTextBox)
        Me.Controls.Add(Me.ApplyDateLabel)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.EntryButton)
        Me.Name = "CompanyInformationEntry"
        Me.Text = "自社情報の設定"
        CType(Me.HistoryDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyInformationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyInformationErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EntryButton As Button
    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents NameLabel As Label
    Friend WithEvents PostalCodeTextBox As TextBox
    Friend WithEvents PostalCodeLabel As Label
    Friend WithEvents Address1TextBox As TextBox
    Friend WithEvents Address1Label As Label
    Friend WithEvents TelTextBox As TextBox
    Friend WithEvents TelLabel As Label
    Friend WithEvents ApplyDateDateTimePicker As DateTimePicker
    Friend WithEvents ApplyDateLabel As Label
    Friend WithEvents Address2TextBox As TextBox
    Friend WithEvents Address2Label As Label
    Friend WithEvents FaxTextBox As TextBox
    Friend WithEvents FaxLabel As Label
    Friend WithEvents HistoryDataGridView As DataGridView
    Friend WithEvents HistoryLabel As Label
    Friend WithEvents CompanyInformationBindingSource As BindingSource
    Friend WithEvents CompanyInformationErrorProvider As ErrorProvider
    Friend WithEvents applyDate As DataGridViewTextBoxColumn
    Friend WithEvents FormTitleLabel As Label
End Class
