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
        Me.FormTitleLabel = New System.Windows.Forms.Label()
        Me.CompanyNameLabel = New System.Windows.Forms.Label()
        Me.CustomerNameTextBox = New System.Windows.Forms.TextBox()
        Me.PICLabel = New System.Windows.Forms.Label()
        Me.PICTextBox = New System.Windows.Forms.TextBox()
        Me.PaymentConditionLabel = New System.Windows.Forms.Label()
        Me.PaymentConditionTextBox = New System.Windows.Forms.TextBox()
        Me.EntryButton = New System.Windows.Forms.Button()
        Me.CustomerInfoErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CustomerInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.CustomerInfoErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FormTitleLabel
        '
        Me.FormTitleLabel.AutoSize = True
        Me.FormTitleLabel.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormTitleLabel.Location = New System.Drawing.Point(12, 9)
        Me.FormTitleLabel.Name = "FormTitleLabel"
        Me.FormTitleLabel.Size = New System.Drawing.Size(131, 24)
        Me.FormTitleLabel.TabIndex = 0
        Me.FormTitleLabel.Text = "顧客の登録"
        '
        'CompanyNameLabel
        '
        Me.CompanyNameLabel.AutoSize = True
        Me.CompanyNameLabel.Location = New System.Drawing.Point(59, 68)
        Me.CompanyNameLabel.Name = "CompanyNameLabel"
        Me.CompanyNameLabel.Size = New System.Drawing.Size(41, 12)
        Me.CompanyNameLabel.TabIndex = 1
        Me.CompanyNameLabel.Text = "会社名"
        '
        'CustomerNameTextBox
        '
        Me.CustomerNameTextBox.Location = New System.Drawing.Point(106, 65)
        Me.CustomerNameTextBox.Name = "CustomerNameTextBox"
        Me.CustomerNameTextBox.Size = New System.Drawing.Size(261, 19)
        Me.CustomerNameTextBox.TabIndex = 2
        '
        'PICLabel
        '
        Me.PICLabel.AutoSize = True
        Me.PICLabel.Location = New System.Drawing.Point(23, 92)
        Me.PICLabel.Name = "PICLabel"
        Me.PICLabel.Size = New System.Drawing.Size(77, 12)
        Me.PICLabel.TabIndex = 1
        Me.PICLabel.Text = "窓口担当者名"
        '
        'PICTextBox
        '
        Me.PICTextBox.Location = New System.Drawing.Point(106, 89)
        Me.PICTextBox.Name = "PICTextBox"
        Me.PICTextBox.Size = New System.Drawing.Size(261, 19)
        Me.PICTextBox.TabIndex = 2
        '
        'PaymentConditionLabel
        '
        Me.PaymentConditionLabel.AutoSize = True
        Me.PaymentConditionLabel.Location = New System.Drawing.Point(47, 116)
        Me.PaymentConditionLabel.Name = "PaymentConditionLabel"
        Me.PaymentConditionLabel.Size = New System.Drawing.Size(53, 12)
        Me.PaymentConditionLabel.TabIndex = 1
        Me.PaymentConditionLabel.Text = "支払条件"
        '
        'PaymentConditionTextBox
        '
        Me.PaymentConditionTextBox.Location = New System.Drawing.Point(106, 113)
        Me.PaymentConditionTextBox.Name = "PaymentConditionTextBox"
        Me.PaymentConditionTextBox.Size = New System.Drawing.Size(261, 19)
        Me.PaymentConditionTextBox.TabIndex = 2
        '
        'EntryButton
        '
        Me.EntryButton.Location = New System.Drawing.Point(292, 183)
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
        'CustomerEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 240)
        Me.Controls.Add(Me.EntryButton)
        Me.Controls.Add(Me.PaymentConditionTextBox)
        Me.Controls.Add(Me.PICTextBox)
        Me.Controls.Add(Me.CustomerNameTextBox)
        Me.Controls.Add(Me.PaymentConditionLabel)
        Me.Controls.Add(Me.PICLabel)
        Me.Controls.Add(Me.CompanyNameLabel)
        Me.Controls.Add(Me.FormTitleLabel)
        Me.Name = "CustomerEntry"
        Me.Text = "顧客の登録"
        CType(Me.CustomerInfoErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FormTitleLabel As Label
    Friend WithEvents CompanyNameLabel As Label
    Friend WithEvents CustomerNameTextBox As TextBox
    Friend WithEvents PICLabel As Label
    Friend WithEvents PICTextBox As TextBox
    Friend WithEvents PaymentConditionLabel As Label
    Friend WithEvents PaymentConditionTextBox As TextBox
    Friend WithEvents EntryButton As Button
    Friend WithEvents CustomerInfoErrorProvider As ErrorProvider
    Friend WithEvents CustomerInfoBindingSource As BindingSource
End Class
