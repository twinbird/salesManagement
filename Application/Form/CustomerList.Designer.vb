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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.EditButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.CustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PostalCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FAX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EditButton, Me.CustomerName, Me.PostalCode, Me.Address1, Me.Address2, Me.TEL, Me.FAX})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(760, 336)
        Me.DataGridView1.TabIndex = 0
        '
        'EditButton
        '
        Me.EditButton.HeaderText = ""
        Me.EditButton.Name = "EditButton"
        '
        'CustomerName
        '
        Me.CustomerName.HeaderText = "顧客名"
        Me.CustomerName.Name = "CustomerName"
        '
        'PostalCode
        '
        Me.PostalCode.HeaderText = "郵便番号"
        Me.PostalCode.Name = "PostalCode"
        '
        'Address1
        '
        Me.Address1.HeaderText = "住所1"
        Me.Address1.Name = "Address1"
        '
        'Address2
        '
        Me.Address2.HeaderText = "住所2"
        Me.Address2.Name = "Address2"
        '
        'TEL
        '
        Me.TEL.HeaderText = "TEL"
        Me.TEL.Name = "TEL"
        '
        'FAX
        '
        Me.FAX.HeaderText = "FAX"
        Me.FAX.Name = "FAX"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(640, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(132, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "新しい顧客を追加"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(250, 19)
        Me.TextBox1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 42)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "フィルタ"
        '
        'CustomerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 406)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "CustomerList"
        Me.Text = "顧客情報の管理"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents EditButton As DataGridViewButtonColumn
    Friend WithEvents CustomerName As DataGridViewTextBoxColumn
    Friend WithEvents PostalCode As DataGridViewTextBoxColumn
    Friend WithEvents Address1 As DataGridViewTextBoxColumn
    Friend WithEvents Address2 As DataGridViewTextBoxColumn
    Friend WithEvents TEL As DataGridViewTextBoxColumn
    Friend WithEvents FAX As DataGridViewTextBoxColumn
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
