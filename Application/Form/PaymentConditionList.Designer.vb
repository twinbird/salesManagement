<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentConditionList
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
        Me.PaymentConditionDataGridView = New System.Windows.Forms.DataGridView()
        Me.EditButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PaymentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CutOff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SearchGroupBox = New System.Windows.Forms.GroupBox()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.ClearSearchConditionButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SearchPaymentConditionNameTextBox = New System.Windows.Forms.TextBox()
        Me.NewPaymentConditionEntryButton = New System.Windows.Forms.Button()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PaymentConditionDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchGroupBox.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'PaymentConditionDataGridView
        '
        Me.PaymentConditionDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PaymentConditionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PaymentConditionDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EditButton, Me.PaymentName, Me.CutOff, Me.PaymentMonth, Me.PaymentDate})
        Me.PaymentConditionDataGridView.Location = New System.Drawing.Point(10, 92)
        Me.PaymentConditionDataGridView.Name = "PaymentConditionDataGridView"
        Me.PaymentConditionDataGridView.RowTemplate.Height = 21
        Me.PaymentConditionDataGridView.Size = New System.Drawing.Size(565, 325)
        Me.PaymentConditionDataGridView.TabIndex = 5
        '
        'EditButton
        '
        Me.EditButton.HeaderText = ""
        Me.EditButton.Name = "EditButton"
        '
        'PaymentName
        '
        Me.PaymentName.HeaderText = "支払条件名"
        Me.PaymentName.Name = "PaymentName"
        '
        'CutOff
        '
        Me.CutOff.HeaderText = "締日"
        Me.CutOff.Name = "CutOff"
        '
        'PaymentMonth
        '
        Me.PaymentMonth.HeaderText = "支払月"
        Me.PaymentMonth.Name = "PaymentMonth"
        '
        'PaymentDate
        '
        Me.PaymentDate.HeaderText = "支払日"
        Me.PaymentDate.Name = "PaymentDate"
        '
        'SearchGroupBox
        '
        Me.SearchGroupBox.Controls.Add(Me.SearchButton)
        Me.SearchGroupBox.Controls.Add(Me.ClearSearchConditionButton)
        Me.SearchGroupBox.Controls.Add(Me.Label1)
        Me.SearchGroupBox.Controls.Add(Me.SearchPaymentConditionNameTextBox)
        Me.SearchGroupBox.Location = New System.Drawing.Point(29, 12)
        Me.SearchGroupBox.Name = "SearchGroupBox"
        Me.SearchGroupBox.Size = New System.Drawing.Size(404, 74)
        Me.SearchGroupBox.TabIndex = 4
        Me.SearchGroupBox.TabStop = False
        Me.SearchGroupBox.Text = "検索"
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(323, 42)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 23)
        Me.SearchButton.TabIndex = 8
        Me.SearchButton.Text = "検索"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'ClearSearchConditionButton
        '
        Me.ClearSearchConditionButton.Location = New System.Drawing.Point(323, 16)
        Me.ClearSearchConditionButton.Name = "ClearSearchConditionButton"
        Me.ClearSearchConditionButton.Size = New System.Drawing.Size(75, 23)
        Me.ClearSearchConditionButton.TabIndex = 8
        Me.ClearSearchConditionButton.Text = "クリア"
        Me.ClearSearchConditionButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "支払条件名"
        '
        'SearchPaymentConditionNameTextBox
        '
        Me.SearchPaymentConditionNameTextBox.Location = New System.Drawing.Point(90, 17)
        Me.SearchPaymentConditionNameTextBox.Name = "SearchPaymentConditionNameTextBox"
        Me.SearchPaymentConditionNameTextBox.Size = New System.Drawing.Size(227, 19)
        Me.SearchPaymentConditionNameTextBox.TabIndex = 2
        '
        'NewPaymentConditionEntryButton
        '
        Me.NewPaymentConditionEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewPaymentConditionEntryButton.Location = New System.Drawing.Point(439, 27)
        Me.NewPaymentConditionEntryButton.Name = "NewPaymentConditionEntryButton"
        Me.NewPaymentConditionEntryButton.Size = New System.Drawing.Size(136, 23)
        Me.NewPaymentConditionEntryButton.TabIndex = 3
        Me.NewPaymentConditionEntryButton.Text = "新しい支払条件を登録"
        Me.NewPaymentConditionEntryButton.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 419)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(587, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(113, 17)
        Me.ToolStripStatusLabel.Text = "ToolStripStatusLabel"
        '
        'PaymentConditionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 441)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.PaymentConditionDataGridView)
        Me.Controls.Add(Me.SearchGroupBox)
        Me.Controls.Add(Me.NewPaymentConditionEntryButton)
        Me.Name = "PaymentConditionList"
        Me.Text = "支払条件の管理"
        CType(Me.PaymentConditionDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchGroupBox.ResumeLayout(False)
        Me.SearchGroupBox.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PaymentConditionDataGridView As DataGridView
    Friend WithEvents SearchGroupBox As GroupBox
    Friend WithEvents SearchPaymentConditionNameTextBox As TextBox
    Friend WithEvents NewPaymentConditionEntryButton As Button
    Friend WithEvents EditButton As DataGridViewButtonColumn
    Friend WithEvents PaymentName As DataGridViewTextBoxColumn
    Friend WithEvents CutOff As DataGridViewTextBoxColumn
    Friend WithEvents PaymentMonth As DataGridViewTextBoxColumn
    Friend WithEvents PaymentDate As DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents Label1 As Label
    Friend WithEvents ClearSearchConditionButton As Button
    Friend WithEvents SearchButton As Button
End Class
