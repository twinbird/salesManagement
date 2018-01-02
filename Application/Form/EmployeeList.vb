Option Strict On
Option Infer On

''' <summary>
''' 従業員台帳を管理する画面
''' </summary>
Public Class EmployeeList

#Region "イベント/コールバック"

    ''' <summary>
    ''' フォームのロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EmployeeList_Load(sender As Object, e As EventArgs) Handles Me.Load
        'フォームコントロールの設定
        SetupControls()
    End Sub

    ''' <summary>
    ''' 新しい従業員を追加ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NewEmployeeEntryButton_Click(sender As Object, e As EventArgs) Handles NewEmployeeEntryButton.Click
        Dim form As New EmployeeEntry
        form.MdiParent = Me.MdiParent
        '画面を閉じた際のコールバックを設定
        AddHandler form.FormClosed, AddressOf UpdateEmployeeListGridView
        form.Show()
    End Sub

    ''' <summary>
    ''' DataGridViewのコンテンツをクリックしたイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EmployeeDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles EmployeeDataGridView.CellContentClick

        Select Case e.ColumnIndex
            Case 0
                '編集ボタンクリック時
                EmployeeDataGridView_EditButtonClick(sender, e)
        End Select

    End Sub

    ''' <summary>
    ''' 登録フォームを終了したときに呼び出されるコールバック関数
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Friend Sub UpdateEmployeeListGridView(sender As Object, e As FormClosedEventArgs)
        'データ表示を更新
        UpdateBindingSource()
    End Sub

    ''' <summary>
    ''' 編集ボタンクリック時に呼ばれるメソッド
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EmployeeDataGridView_EditButtonClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim gridview = DirectCast(sender, DataGridView)
        Dim empDTO As EmployeeGridViewDTO = DirectCast(gridview.CurrentRow.DataBoundItem, EmployeeGridViewDTO)

        Dim form As New EmployeeEntry
        form.MdiParent = Me.MdiParent
        '画面を閉じた際のコールバックを設定
        AddHandler form.FormClosed, AddressOf UpdateEmployeeListGridView
        '編集するモデルを設定
        form.EditEmployee = empDTO.GetEmployee
        form.Show()
    End Sub

    ''' <summary>
    ''' 検索ボタンをクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        UpdateBindingSource()
    End Sub

    ''' <summary>
    ''' 検索条件クリアボタンをクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClearSearchConditionButton_Click(sender As Object, e As EventArgs) Handles ClearSearchConditionButton.Click
        ClearFormSearchCondition()
    End Sub

#End Region

#Region "コントロール制御"

    ''' <summary>
    ''' フォームコントロールの設定を行う
    ''' </summary>
    Private Sub SetupControls()
        'GridViewの設定
        SetupDataGridView()
    End Sub

    ''' <summary>
    ''' 検索のグループボックスの内容をクリア
    ''' </summary>
    Private Sub ClearFormSearchCondition()
        Me.SearchEmployeeNoTextBox.Clear()
        Me.SearchEmployeeNameTextBox.Clear()
        Me.SearchEmployeeNameKanaTextBox.Clear()
    End Sub

#End Region

#Region "DataGridView"

    ''' <summary>
    ''' 従業員のDataGridViewのコントロール設定
    ''' </summary>
    Private Sub SetupDataGridView()
        '一度列全体をクリア
        EmployeeDataGridView.Columns.Clear()
        '列の自動生成を行わない
        EmployeeDataGridView.AutoGenerateColumns = False

        '編集ボタン列を作成
        Dim buttonCol = New DataGridViewButtonColumn
        With buttonCol
            .Name = "editButton"
            .HeaderText = ""
            .Text = "編集"
            .UseColumnTextForButtonValue = True
        End With
        EmployeeDataGridView.Columns.Add(buttonCol)

        '従業員番号列を作成
        Dim empNoCol = New DataGridViewTextBoxColumn
        With empNoCol
            .Name = "EmployeeNo"
            .HeaderText = "従業員番号"
            .ReadOnly = True
            .DataPropertyName = "EmployeeNo"
        End With
        EmployeeDataGridView.Columns.Add(empNoCol)

        '名前列を作成
        Dim empNameCol = New DataGridViewTextBoxColumn
        With empNameCol
            .Name = "EmployeeName"
            .HeaderText = "名前"
            .DataPropertyName = "EmployeeName"
        End With
        EmployeeDataGridView.Columns.Add(empNameCol)

        'かな名列を作成
        Dim empNameKanaCol = New DataGridViewTextBoxColumn
        With empNameKanaCol
            .Name = "EmployeeNameKana"
            .HeaderText = "かな名"
            .DataPropertyName = "EmployeeNameKana"
        End With
        EmployeeDataGridView.Columns.Add(empNameKanaCol)
    End Sub

    ''' <summary>
    ''' 従業員のDataGridView用のbindingSourceのデータを更新する
    ''' </summary>
    Private Sub UpdateBindingSource()
        'データ取得用のリポジトリを作成
        Dim repo = New Infrastructure.EmployeeRepositoryImpl

        'リポジトリから従業員情報を取得
        Dim cond = New Domain.EmployeeRepositorySearchCondition
        With cond
            .EmployeeNoForwardMatch = Me.SearchEmployeeNoTextBox.Text
            .EmployeeNameForwardMatch = Me.SearchEmployeeNameTextBox.Text
            .EmployeeNameKanaForwardMatch = Me.SearchEmployeeNameKanaTextBox.Text
        End With
        Dim emps = repo.FindEmployeeByCondition(cond)

        'データバインディング用オブジェクトへ変換
        Dim dtos = New List(Of EmployeeGridViewDTO)
        For Each emp As Domain.Employee In emps
            dtos.Add(New EmployeeGridViewDTO(emp))
        Next
        'GridViewへデータを設定
        Dim bindList = New SortableBindingList(Of EmployeeGridViewDTO)(dtos)
        EmployeeDataGridView.DataSource = bindList
    End Sub

    ''' <summary>
    ''' DataGridView表示用オブジェクト
    ''' </summary>
    Private Class EmployeeGridViewDTO

        Private ReadOnly _Employee As Domain.Employee

        Public Sub New(ByVal emp As Domain.Employee)
            _Employee = emp
        End Sub

        Public ReadOnly Property EmployeeName As String
            Get
                Return _Employee.Name
            End Get
        End Property

        Public ReadOnly Property EmployeeNameKana As String
            Get
                Return _Employee.NameKana
            End Get
        End Property

        Public ReadOnly Property EmployeeNo As String
            Get
                Return _Employee.EmployeeNo
            End Get
        End Property

        Public Function GetEmployee() As Domain.Employee
            Return _Employee
        End Function

    End Class

#End Region

End Class