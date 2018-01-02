<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeList
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
        Me.NewEmployeeEntryButton = New System.Windows.Forms.Button()
        Me.FilterGroupBox = New System.Windows.Forms.GroupBox()
        Me.FilterTextBox = New System.Windows.Forms.TextBox()
        Me.EmployeeDataGridView = New System.Windows.Forms.DataGridView()
        Me.FilterButton = New System.Windows.Forms.Button()
        Me.FilterGroupBox.SuspendLayout()
        CType(Me.EmployeeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NewEmployeeEntryButton
        '
        Me.NewEmployeeEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewEmployeeEntryButton.Location = New System.Drawing.Point(353, 27)
        Me.NewEmployeeEntryButton.Name = "NewEmployeeEntryButton"
        Me.NewEmployeeEntryButton.Size = New System.Drawing.Size(136, 23)
        Me.NewEmployeeEntryButton.TabIndex = 0
        Me.NewEmployeeEntryButton.Text = "新しい従業員を登録"
        Me.NewEmployeeEntryButton.UseVisualStyleBackColor = True
        '
        'FilterGroupBox
        '
        Me.FilterGroupBox.Controls.Add(Me.FilterButton)
        Me.FilterGroupBox.Controls.Add(Me.FilterTextBox)
        Me.FilterGroupBox.Location = New System.Drawing.Point(31, 12)
        Me.FilterGroupBox.Name = "FilterGroupBox"
        Me.FilterGroupBox.Size = New System.Drawing.Size(305, 45)
        Me.FilterGroupBox.TabIndex = 1
        Me.FilterGroupBox.TabStop = False
        Me.FilterGroupBox.Text = "フィルタ"
        '
        'FilterTextBox
        '
        Me.FilterTextBox.Location = New System.Drawing.Point(16, 17)
        Me.FilterTextBox.Name = "FilterTextBox"
        Me.FilterTextBox.Size = New System.Drawing.Size(202, 19)
        Me.FilterTextBox.TabIndex = 2
        '
        'EmployeeDataGridView
        '
        Me.EmployeeDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EmployeeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.EmployeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EmployeeDataGridView.Location = New System.Drawing.Point(12, 63)
        Me.EmployeeDataGridView.MultiSelect = False
        Me.EmployeeDataGridView.Name = "EmployeeDataGridView"
        Me.EmployeeDataGridView.RowHeadersVisible = False
        Me.EmployeeDataGridView.RowTemplate.Height = 21
        Me.EmployeeDataGridView.Size = New System.Drawing.Size(477, 186)
        Me.EmployeeDataGridView.TabIndex = 2
        '
        'FilterButton
        '
        Me.FilterButton.Location = New System.Drawing.Point(225, 14)
        Me.FilterButton.Name = "FilterButton"
        Me.FilterButton.Size = New System.Drawing.Size(75, 23)
        Me.FilterButton.TabIndex = 3
        Me.FilterButton.Text = "絞り込み"
        Me.FilterButton.UseVisualStyleBackColor = True
        '
        'EmployeeList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 261)
        Me.Controls.Add(Me.EmployeeDataGridView)
        Me.Controls.Add(Me.FilterGroupBox)
        Me.Controls.Add(Me.NewEmployeeEntryButton)
        Me.Name = "EmployeeList"
        Me.Text = "従業員台帳"
        Me.FilterGroupBox.ResumeLayout(False)
        Me.FilterGroupBox.PerformLayout()
        CType(Me.EmployeeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NewEmployeeEntryButton As Button
    Friend WithEvents FilterGroupBox As GroupBox
    Friend WithEvents FilterTextBox As TextBox
    Friend WithEvents EmployeeDataGridView As DataGridView
    Friend WithEvents FilterButton As Button
End Class
