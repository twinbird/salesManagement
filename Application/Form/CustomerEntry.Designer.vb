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
        Me.CustomerInfoErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CustomerInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        CType(Me.CustomerInfoErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CompanyNameLabel
        '
        Me.CompanyNameLabel.AutoSize = True
        Me.CompanyNameLabel.Location = New System.Drawing.Point(59, 16)
        Me.CompanyNameLabel.Name = "CompanyNameLabel"
        Me.CompanyNameLabel.Size = New System.Drawing.Size(41, 12)
        Me.CompanyNameLabel.TabIndex = 1
        Me.CompanyNameLabel.Text = "会社名"
        '
        'CustomerNameTextBox
        '
        Me.CustomerNameTextBox.Location = New System.Drawing.Point(106, 13)
        Me.CustomerNameTextBox.Name = "CustomerNameTextBox"
        Me.CustomerNameTextBox.Size = New System.Drawing.Size(261, 19)
        Me.CustomerNameTextBox.TabIndex = 2
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
        Me.EntryButton.Location = New System.Drawing.Point(292, 205)
        Me.EntryButton.Name = "EntryButton"
        Me.EntryButton.Size = New System.Drawing.Size(75, 23)
        Me.EntryButton.TabIndex = 3
        Me.EntryButton.Text = "登録"
        Me.EntryButton.UseVisualStyleBackColor = True
        '
        'CustomerInfoErrorProvider
        '
        Me.CustomerInfoErrorProvider.ContainerControl = Me
        Me.CustomerInfoErrorProvider.DataSource = Me.CustomerInfoBindingSource
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "会社名(かな)"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(106, 35)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(261, 19)
        Me.TextBox1.TabIndex = 2
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(106, 57)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(112, 20)
        Me.ComboBox1.TabIndex = 4
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(106, 81)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(261, 20)
        Me.ComboBox2.TabIndex = 4
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
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(106, 106)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(77, 19)
        Me.TextBox2.TabIndex = 2
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(106, 128)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(261, 19)
        Me.TextBox3.TabIndex = 2
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
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(106, 151)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(261, 19)
        Me.TextBox4.TabIndex = 2
        '
        'CustomerEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 240)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.EntryButton)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
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
        CType(Me.CustomerInfoErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CompanyNameLabel As Label
    Friend WithEvents CustomerNameTextBox As TextBox
    Friend WithEvents PICLabel As Label
    Friend WithEvents PaymentConditionLabel As Label
    Friend WithEvents EntryButton As Button
    Friend WithEvents CustomerInfoErrorProvider As ErrorProvider
    Friend WithEvents CustomerInfoBindingSource As BindingSource
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
