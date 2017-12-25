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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.EditButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.PaymentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CutOff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EditButton, Me.PaymentName, Me.CutOff, Me.PaymentMonth, Me.PaymentDate})
        Me.DataGridView1.Location = New System.Drawing.Point(10, 63)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(477, 186)
        Me.DataGridView1.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 45)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "フィルタ"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 17)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(278, 19)
        Me.TextBox1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(351, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "新しい支払条件を登録"
        Me.Button1.UseVisualStyleBackColor = True
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
        'PaymentConditionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 261)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "PaymentConditionList"
        Me.Text = "支払条件の管理"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents EditButton As DataGridViewButtonColumn
    Friend WithEvents PaymentName As DataGridViewTextBoxColumn
    Friend WithEvents CutOff As DataGridViewTextBoxColumn
    Friend WithEvents PaymentMonth As DataGridViewTextBoxColumn
    Friend WithEvents PaymentDate As DataGridViewTextBoxColumn
End Class
