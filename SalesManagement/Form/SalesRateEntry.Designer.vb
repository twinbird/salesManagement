<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesRateEntry
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.EntryButton = New System.Windows.Forms.Button()
        Me.ApplyDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ApplyDate, Me.Rate})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(265, 150)
        Me.DataGridView1.TabIndex = 0
        '
        'EntryButton
        '
        Me.EntryButton.Location = New System.Drawing.Point(190, 179)
        Me.EntryButton.Name = "EntryButton"
        Me.EntryButton.Size = New System.Drawing.Size(87, 26)
        Me.EntryButton.TabIndex = 1
        Me.EntryButton.Text = "登録"
        Me.EntryButton.UseVisualStyleBackColor = True
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
        'SalesRateEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 218)
        Me.Controls.Add(Me.EntryButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "SalesRateEntry"
        Me.Text = "消費税管理"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ApplyDate As DataGridViewTextBoxColumn
    Friend WithEvents Rate As DataGridViewTextBoxColumn
    Friend WithEvents EntryButton As Button
End Class
