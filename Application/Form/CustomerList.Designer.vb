<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerList
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
        Me.CustomerDataGridView = New System.Windows.Forms.DataGridView()
        Me.NewCustomerEntryButton = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SearchGroupBox = New System.Windows.Forms.GroupBox()
        Me.ClearSearchConditionButton = New System.Windows.Forms.Button()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.SearchCustomerNameLabel = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SearchCustomerKanaNameLabel = New System.Windows.Forms.Label()
        Me.SearchPICLabel = New System.Windows.Forms.Label()
        Me.SearchAddressLabel = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.CustomerDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomerDataGridView
        '
        Me.CustomerDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CustomerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CustomerDataGridView.Location = New System.Drawing.Point(12, 127)
        Me.CustomerDataGridView.Name = "CustomerDataGridView"
        Me.CustomerDataGridView.RowTemplate.Height = 21
        Me.CustomerDataGridView.Size = New System.Drawing.Size(611, 267)
        Me.CustomerDataGridView.TabIndex = 0
        '
        'NewCustomerEntryButton
        '
        Me.NewCustomerEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewCustomerEntryButton.Location = New System.Drawing.Point(491, 23)
        Me.NewCustomerEntryButton.Name = "NewCustomerEntryButton"
        Me.NewCustomerEntryButton.Size = New System.Drawing.Size(132, 23)
        Me.NewCustomerEntryButton.TabIndex = 1
        Me.NewCustomerEntryButton.Text = "新しい顧客を追加"
        Me.NewCustomerEntryButton.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(95, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(250, 19)
        Me.TextBox1.TabIndex = 2
        '
        'SearchGroupBox
        '
        Me.SearchGroupBox.Controls.Add(Me.ComboBox1)
        Me.SearchGroupBox.Controls.Add(Me.SearchAddressLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchPICLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchCustomerKanaNameLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchCustomerNameLabel)
        Me.SearchGroupBox.Controls.Add(Me.SearchButton)
        Me.SearchGroupBox.Controls.Add(Me.TextBox3)
        Me.SearchGroupBox.Controls.Add(Me.TextBox2)
        Me.SearchGroupBox.Controls.Add(Me.ClearSearchConditionButton)
        Me.SearchGroupBox.Controls.Add(Me.TextBox1)
        Me.SearchGroupBox.Location = New System.Drawing.Point(22, 12)
        Me.SearchGroupBox.Name = "SearchGroupBox"
        Me.SearchGroupBox.Size = New System.Drawing.Size(453, 109)
        Me.SearchGroupBox.TabIndex = 3
        Me.SearchGroupBox.TabStop = False
        Me.SearchGroupBox.Text = "検索"
        '
        'ClearSearchConditionButton
        '
        Me.ClearSearchConditionButton.Location = New System.Drawing.Point(360, 52)
        Me.ClearSearchConditionButton.Name = "ClearSearchConditionButton"
        Me.ClearSearchConditionButton.Size = New System.Drawing.Size(75, 23)
        Me.ClearSearchConditionButton.TabIndex = 3
        Me.ClearSearchConditionButton.Text = "クリア"
        Me.ClearSearchConditionButton.UseVisualStyleBackColor = True
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(360, 78)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 23)
        Me.SearchButton.TabIndex = 3
        Me.SearchButton.Text = "検索"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'SearchCustomerNameLabel
        '
        Me.SearchCustomerNameLabel.AutoSize = True
        Me.SearchCustomerNameLabel.Location = New System.Drawing.Point(17, 18)
        Me.SearchCustomerNameLabel.Name = "SearchCustomerNameLabel"
        Me.SearchCustomerNameLabel.Size = New System.Drawing.Size(41, 12)
        Me.SearchCustomerNameLabel.TabIndex = 4
        Me.SearchCustomerNameLabel.Text = "顧客名"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(95, 34)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(250, 19)
        Me.TextBox2.TabIndex = 2
        '
        'SearchCustomerKanaNameLabel
        '
        Me.SearchCustomerKanaNameLabel.AutoSize = True
        Me.SearchCustomerKanaNameLabel.Location = New System.Drawing.Point(17, 39)
        Me.SearchCustomerKanaNameLabel.Name = "SearchCustomerKanaNameLabel"
        Me.SearchCustomerKanaNameLabel.Size = New System.Drawing.Size(69, 12)
        Me.SearchCustomerKanaNameLabel.TabIndex = 4
        Me.SearchCustomerKanaNameLabel.Text = "顧客名(かな)"
        '
        'SearchPICLabel
        '
        Me.SearchPICLabel.AutoSize = True
        Me.SearchPICLabel.Location = New System.Drawing.Point(17, 60)
        Me.SearchPICLabel.Name = "SearchPICLabel"
        Me.SearchPICLabel.Size = New System.Drawing.Size(65, 12)
        Me.SearchPICLabel.TabIndex = 4
        Me.SearchPICLabel.Text = "営業担当者"
        '
        'SearchAddressLabel
        '
        Me.SearchAddressLabel.AutoSize = True
        Me.SearchAddressLabel.Location = New System.Drawing.Point(17, 82)
        Me.SearchAddressLabel.Name = "SearchAddressLabel"
        Me.SearchAddressLabel.Size = New System.Drawing.Size(29, 12)
        Me.SearchAddressLabel.TabIndex = 4
        Me.SearchAddressLabel.Text = "住所"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(95, 79)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(250, 19)
        Me.TextBox3.TabIndex = 2
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(95, 56)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(138, 20)
        Me.ComboBox1.TabIndex = 4
        '
        'CustomerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 406)
        Me.Controls.Add(Me.SearchGroupBox)
        Me.Controls.Add(Me.NewCustomerEntryButton)
        Me.Controls.Add(Me.CustomerDataGridView)
        Me.Name = "CustomerList"
        Me.Text = "顧客情報の管理"
        CType(Me.CustomerDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchGroupBox.ResumeLayout(False)
        Me.SearchGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CustomerDataGridView As DataGridView
    Friend WithEvents NewCustomerEntryButton As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents SearchGroupBox As GroupBox
    Friend WithEvents SearchButton As Button
    Friend WithEvents ClearSearchConditionButton As Button
    Friend WithEvents SearchCustomerNameLabel As Label
    Friend WithEvents SearchCustomerKanaNameLabel As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents SearchPICLabel As Label
    Friend WithEvents SearchAddressLabel As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
End Class
