Option Strict On
Option Infer On

''' <summary>
''' 顧客情報の管理画面
''' </summary>
Public Class CustomerList

#Region "イベント/コールバック"

    ''' <summary>
    ''' フォームのロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CustomerList_Load(sender As Object, e As EventArgs) Handles Me.Load
        'フォームコントロールの設定
        SetupControls()
    End Sub

    ''' <summary>
    ''' 新しい顧客を追加ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NewCustomerEntryButton_Click(sender As Object, e As EventArgs) Handles NewCustomerEntryButton.Click
        Dim form As New CustomerEntry
        form.MdiParent = Me.MdiParent
        '画面を閉じた際のコールバックを設定
        AddHandler form.FormClosed, AddressOf UpdateCustomerListGridView
        form.Show()
    End Sub

    ''' <summary>
    ''' DataGridViewのコンテンツをクリックしたイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CustomerDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CustomerDataGridView.CellContentClick

        Select Case e.ColumnIndex
            Case 0
                '編集ボタンクリック時
                CustomerDataGridView_EditButtonClick(sender, e)
        End Select

    End Sub

    ''' <summary>
    ''' 登録フォームを終了したときに呼び出されるコールバック関数
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Friend Sub UpdateCustomerListGridView(sender As Object, e As FormClosedEventArgs)
        'データ表示を更新
        UpdateBindingSource()
        'ステータスラベルの更新
        UpdateToolStripStatusLabel()
    End Sub

    ''' <summary>
    ''' 編集ボタンクリック時に呼ばれるメソッド
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CustomerDataGridView_EditButtonClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim gridview = DirectCast(sender, DataGridView)
        Dim custPres As CustomerGridViewPresentation = DirectCast(gridview.CurrentRow.DataBoundItem, CustomerGridViewPresentation)

        Dim form As New CustomerEntry
        form.MdiParent = Me.MdiParent
        '画面を閉じた際のコールバックを設定
        AddHandler form.FormClosed, AddressOf UpdateCustomerListGridView
        '編集するモデルを設定
        form.EditCustomer = custPres.GetCustomer
        form.Show()
    End Sub

    ''' <summary>
    ''' 検索ボタンをクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        '明細データの更新
        UpdateBindingSource()
        'ステータスラベルの更新
        UpdateToolStripStatusLabel()
    End Sub

    ''' <summary>
    ''' 検索条件クリアボタンをクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClearSearchConditionButton_Click(sender As Object, e As EventArgs) Handles ClearSearchConditionButton.Click
        ClearFormSearchCondition()
    End Sub

    ''' <summary>
    ''' フォームのアクティベイトイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CustomerList_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'コンボボックスの設定
        UpdateControlDataSource()
    End Sub

#End Region

#Region "コントロール制御"

    ''' <summary>
    ''' フォームコントロールの設定を行う
    ''' </summary>
    Private Sub SetupControls()
        'コンボボックスの設定
        UpdateControlDataSource()
        'GridViewの設定
        SetupDataGridView()
        'ToolStripStatusLabelの表示内容を更新
        UpdateToolStripStatusLabel()
    End Sub

    ''' <summary>
    ''' 検索のグループボックスの内容をクリア
    ''' </summary>
    Private Sub ClearFormSearchCondition()
        Me.SearchCustomerNameTextBox.Clear()
        Me.SearchCustomerKanaNameTextBox.Clear()
        Me.SearchPICComboBox.SelectedIndex = 0
        Me.SearchAddressTextBox.Clear()
    End Sub

    ''' <summary>
    ''' ToolStripStatusLabelの表示内容を更新
    ''' </summary>
    Private Sub UpdateToolStripStatusLabel()
        Dim repo = New Infrastructure.CustomerRepositoryImpl
        Dim allCount = repo.CountAllCustomer()
        Dim str = String.Format("{0}件中{1}件を表示中", allCount, CustomerDataGridView.Rows.Count)
        Me.ToolStripStatusLabel.Text = str
    End Sub

    ''' <summary>
    ''' 営業担当者のコンボボックスを設定
    ''' </summary>
    Private Sub SetupPICComboBox()
        Dim displayValues As New List(Of KeyValuePair(Of String, Domain.Employee))

        '未選択の値を追加
        Dim emptyRow = New KeyValuePair(Of String, Domain.Employee)(String.Empty, Nothing)
        displayValues.Add(emptyRow)

        '従業員情報を取得してコンボボックスメンバに利用
        Dim repo = New Infrastructure.EmployeeRepositoryImpl
        Dim emps = repo.FindAllEmployee
        For Each e In emps
            Dim kvp = New KeyValuePair(Of String, Domain.Employee)(e.Name, e)
            displayValues.Add(kvp)
        Next

        'ComboBoxの設定
        SearchPICComboBox.ValueMember = "Value"
        SearchPICComboBox.DisplayMember = "Key"
        SearchPICComboBox.DataSource = displayValues
    End Sub

    ''' <summary>
    ''' コントロールのデータソースを更新
    ''' </summary>
    Private Sub UpdateControlDataSource()
        SetupPICComboBox()
    End Sub

#End Region

#Region "DataGridView制御"

    ''' <summary>
    ''' DataGridViewのコントロール設定
    ''' </summary>
    Private Sub SetupDataGridView()
        '一度列全体をクリア
        CustomerDataGridView.Columns.Clear()
        '列の自動生成を行わない
        CustomerDataGridView.AutoGenerateColumns = False
        'GridView内での新規行追加不可
        CustomerDataGridView.AllowUserToAddRows = False

        '編集ボタン列を作成
        Dim buttonCol = New DataGridViewButtonColumn
        With buttonCol
            .Name = "editButton"
            .HeaderText = ""
            .Text = "編集"
            .UseColumnTextForButtonValue = True
        End With
        CustomerDataGridView.Columns.Add(buttonCol)

        '顧客名列を作成
        Dim custNameCol = New DataGridViewTextBoxColumn
        With custNameCol
            .Name = "CustomerName"
            .HeaderText = "顧客名"
            .ReadOnly = True
            .DataPropertyName = "CustomerName"
        End With
        CustomerDataGridView.Columns.Add(custNameCol)

        '顧客名かな列を作成
        Dim custKanaNameCol = New DataGridViewTextBoxColumn
        With custKanaNameCol
            .Name = "CustomerKanaName"
            .HeaderText = "名前"
            .DataPropertyName = "CustomerKanaName"
        End With
        CustomerDataGridView.Columns.Add(custKanaNameCol)

        '営業担当者列を作成
        Dim custPICCol = New DataGridViewTextBoxColumn
        With custPICCol
            .Name = "CustomerPIC"
            .HeaderText = "営業担当者"
            .DataPropertyName = "CustomerPIC"
        End With
        CustomerDataGridView.Columns.Add(custPICCol)

        '郵便番号列を作成
        Dim custPostalCodeCol = New DataGridViewTextBoxColumn
        With custPostalCodeCol
            .Name = "CustomerPostalCode"
            .HeaderText = "郵便番号"
            .DataPropertyName = "CustomerPostalCode"
        End With
        CustomerDataGridView.Columns.Add(custPostalCodeCol)

        '住所1列を作成
        Dim custAddress1Col = New DataGridViewTextBoxColumn
        With custAddress1Col
            .Name = "CustomerAddress1"
            .HeaderText = "住所1"
            .DataPropertyName = "CustomerAddress1"
        End With
        CustomerDataGridView.Columns.Add(custAddress1Col)

        '住所2列を作成
        Dim custAddress2Col = New DataGridViewTextBoxColumn
        With custAddress2Col
            .Name = "CustomerAddress2"
            .HeaderText = "住所2"
            .DataPropertyName = "CustomerAddress2"
        End With
        CustomerDataGridView.Columns.Add(custAddress2Col)

        '明細をクリア
        CustomerDataGridView.DataSource = Nothing
    End Sub

    ''' <summary>
    ''' DataGridView用のbindingSourceのデータを更新する
    ''' </summary>
    Private Sub UpdateBindingSource()
        'データ取得用のリポジトリを作成
        Dim repo = New Infrastructure.CustomerRepositoryImpl

        'リポジトリから顧客情報を取得
        Dim cond = New Domain.CustomerRepositorySearchCondition
        With cond
            .NameForwardMatch = Me.SearchCustomerNameTextBox.Text
            .KanaNameForwardMatch = Me.SearchCustomerKanaNameTextBox.Text
            .PIC = TryCast(Me.SearchPICComboBox.SelectedValue, Domain.Employee)
            .AddressForwardMatch = Me.SearchAddressTextBox.Text
        End With
        Dim custs = repo.FindCustomerByCondition(cond)

        'データバインディング用オブジェクトへ変換
        Dim presentation = New List(Of CustomerGridViewPresentation)
        For Each cust As Domain.Customer In custs
            presentation.Add(New CustomerGridViewPresentation(cust))
        Next
        'GridViewへデータを設定
        Dim bindList = New SortableBindingList(Of CustomerGridViewPresentation)(presentation)
        CustomerDataGridView.DataSource = bindList
    End Sub

    ''' <summary>
    ''' DataGridView表示用オブジェクト
    ''' </summary>
    Private Class CustomerGridViewPresentation

        Private ReadOnly _Customer As Domain.Customer

        Public Sub New(ByVal cust As Domain.Customer)
            _Customer = cust
        End Sub

        Public ReadOnly Property CustomerName As String
            Get
                Return _Customer.Name
            End Get
        End Property

        Public ReadOnly Property CustomerKanaName As String
            Get
                Return _Customer.KanaName
            End Get
        End Property

        Public ReadOnly Property CustomerPIC As String
            Get
                Return _Customer.PIC.Name
            End Get
        End Property

        Public ReadOnly Property CustomerPostalCode As String
            Get
                Return _Customer.PostalCode
            End Get
        End Property

        Public ReadOnly Property CustomerAddress1 As String
            Get
                Return _Customer.Address1
            End Get
        End Property

        Public ReadOnly Property CustomerAddress2 As String
            Get
                Return _Customer.Address2
            End Get
        End Property

        Public Function GetCustomer() As Domain.Customer
            Return _Customer
        End Function

    End Class

#End Region

End Class