<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesTaxRateEntry
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
        Me.SalesTaxDataGridView = New System.Windows.Forms.DataGridView()
        Me.ApplyDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntryButton = New System.Windows.Forms.Button()
        Me.NewRowAddButton = New System.Windows.Forms.Button()
        CType(Me.SalesTaxDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SalesTaxDataGridView
        '
        Me.SalesTaxDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SalesTaxDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SalesTaxDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ApplyDate, Me.Rate})
        Me.SalesTaxDataGridView.Location = New System.Drawing.Point(12, 9)
        Me.SalesTaxDataGridView.Name = "SalesTaxDataGridView"
        Me.SalesTaxDataGridView.RowTemplate.Height = 21
        Me.SalesTaxDataGridView.Size = New System.Drawing.Size(265, 298)
        Me.SalesTaxDataGridView.TabIndex = 0
        '
        'ApplyDate
        '
        Me.ApplyDate.HeaderText = "適用開始日"
        Me.ApplyDate.Name = "ApplyDate"
        '
        'Rate
        '
        Me.Rate.HeaderText = "税率"
        Me.Rate.Name = "Rate"
        '
        'EntryButton
        '
        Me.EntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EntryButton.Location = New System.Drawing.Point(190, 313)
        Me.EntryButton.Name = "EntryButton"
        Me.EntryButton.Size = New System.Drawing.Size(87, 26)
        Me.EntryButton.TabIndex = 1
        Me.EntryButton.Text = "登録"
        Me.EntryButton.UseVisualStyleBackColor = True
        '
        'NewRowAddButton
        '
        Me.NewRowAddButton.Location = New System.Drawing.Point(98, 313)
        Me.NewRowAddButton.Name = "NewRowAddButton"
        Me.NewRowAddButton.Size = New System.Drawing.Size(86, 26)
        Me.NewRowAddButton.TabIndex = 2
        Me.NewRowAddButton.Text = "行を追加"
        Me.NewRowAddButton.UseVisualStyleBackColor = True
        '
        'SalesTaxRateEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 350)
        Me.Controls.Add(Me.NewRowAddButton)
        Me.Controls.Add(Me.EntryButton)
        Me.Controls.Add(Me.SalesTaxDataGridView)
        Me.Name = "SalesTaxRateEntry"
        Me.Text = "消費税の設定"
        CType(Me.SalesTaxDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SalesTaxDataGridView As DataGridView
    Friend WithEvents ApplyDate As DataGridViewTextBoxColumn
    Friend WithEvents Rate As DataGridViewTextBoxColumn
    Friend WithEvents EntryButton As Button
    Friend WithEvents NewRowAddButton As Button
End Class
