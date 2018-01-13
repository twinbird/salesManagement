Option Strict On
Option Infer On

''' <summary>
''' 支払条件の管理を行う画面
''' </summary>
Public Class PaymentConditionList

#Region "イベント/コールバック"

    ''' <summary>
    ''' フォームのロードイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PaymentConditionList_Load(sender As Object, e As EventArgs) Handles Me.Load
        'フォームコントロールの設定
        SetupControls()
    End Sub

    ''' <summary>
    ''' 新しい支払条件を追加ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NewPaymentConditionEntryButton_Click(sender As Object, e As EventArgs) Handles NewPaymentConditionEntryButton.Click
        Dim form As New PaymentConditionEntry
        form.MdiParent = Me.MdiParent
        '画面を閉じた際のコールバックを設定
        AddHandler form.FormClosed, AddressOf UpdatePaymentConditionListGridView
        form.Show()
    End Sub

    ''' <summary>
    ''' DataGridViewのコンテンツをクリックしたイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PaymentConditionDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles PaymentConditionDataGridView.CellContentClick

        Select Case e.ColumnIndex
            Case 0
                '編集ボタンクリック時
                PaymentConditionDataGridView_EditButtonClick(sender, e)
        End Select

    End Sub

    ''' <summary>
    ''' 登録フォームを終了したときに呼び出されるコールバック関数
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Friend Sub UpdatePaymentConditionListGridView(sender As Object, e As FormClosedEventArgs)
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
    Private Sub PaymentConditionDataGridView_EditButtonClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim gridview = DirectCast(sender, DataGridView)
        Dim payPres As PaymentConditionGridViewPresentation = DirectCast(gridview.CurrentRow.DataBoundItem, PaymentConditionGridViewPresentation)

        Dim form As New PaymentConditionEntry
        form.MdiParent = Me.MdiParent
        '画面を閉じた際のコールバックを設定
        AddHandler form.FormClosed, AddressOf UpdatePaymentConditionListGridView
        '編集するモデルを設定
        form.EditPaymentCondition = payPres.GetPaymentCondition
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

#End Region

#Region "コントロール制御"

    ''' <summary>
    ''' フォームコントロールの設定を行う
    ''' </summary>
    Private Sub SetupControls()
        'GridViewの設定
        SetupDataGridView()
        'ToolStripStatusLabelの表示内容を更新
        UpdateToolStripStatusLabel()
    End Sub

    ''' <summary>
    ''' 検索のグループボックスの内容をクリア
    ''' </summary>
    Private Sub ClearFormSearchCondition()
        Me.SearchPaymentConditionNameTextBox.Clear()
    End Sub

    ''' <summary>
    ''' ToolStripStatusLabelの表示内容を更新
    ''' </summary>
    Private Sub UpdateToolStripStatusLabel()
        Dim repo = New Infrastructure.PaymentConditionRepositoryImpl
        Dim allCount = repo.CountAllPaymentCondition()
        Dim str = String.Format("{0}件中{1}件を表示中", allCount, PaymentConditionDataGridView.Rows.Count)
        Me.ToolStripStatusLabel.Text = str
    End Sub

#End Region

#Region "DataGridView制御"

    ''' <summary>
    ''' DataGridViewのコントロール設定
    ''' </summary>
    Private Sub SetupDataGridView()
        '一度列全体をクリア
        PaymentConditionDataGridView.Columns.Clear()
        '列の自動生成を行わない
        PaymentConditionDataGridView.AutoGenerateColumns = False
        'GridView内での新規行追加不可
        PaymentConditionDataGridView.AllowUserToAddRows = False

        '編集ボタン列を作成
        Dim buttonCol = New DataGridViewButtonColumn
        With buttonCol
            .Name = "editButton"
            .HeaderText = ""
            .Text = "編集"
            .UseColumnTextForButtonValue = True
        End With
        PaymentConditionDataGridView.Columns.Add(buttonCol)

        '支払条件名列を作成
        Dim payName = New DataGridViewTextBoxColumn
        With payName
            .Name = "PaymentConditionName"
            .HeaderText = "支払条件名"
            .ReadOnly = True
            .DataPropertyName = "PaymentConditionName"
        End With
        PaymentConditionDataGridView.Columns.Add(payName)

        '締日列を作成
        Dim payCutOff = New DataGridViewTextBoxColumn
        With payCutOff
            .Name = "CutOff"
            .HeaderText = "締日"
            .DataPropertyName = "CutOff"
        End With
        PaymentConditionDataGridView.Columns.Add(payCutOff)

        '支払月列を作成
        Dim payMonthOffset = New DataGridViewTextBoxColumn
        With payMonthOffset
            .Name = "MonthOffset"
            .HeaderText = "支払月"
            .DataPropertyName = "MonthOffset"
        End With
        PaymentConditionDataGridView.Columns.Add(payMonthOffset)

        '支払日列を作成
        Dim payDueDate = New DataGridViewTextBoxColumn
        With payDueDate
            .Name = "DueDate"
            .HeaderText = "支払日"
            .DataPropertyName = "DueDate"
        End With
        PaymentConditionDataGridView.Columns.Add(payDueDate)

        '明細をクリア
        PaymentConditionDataGridView.DataSource = Nothing
    End Sub

    ''' <summary>
    ''' DataGridView用のbindingSourceのデータを更新する
    ''' </summary>
    Private Sub UpdateBindingSource()
        'データ取得用のリポジトリを作成
        Dim repo = New Infrastructure.PaymentConditionRepositoryImpl

        'リポジトリから情報を取得
        Dim cond = New Domain.PaymentConditionRepositorySearchCondition
        With cond
            .PaymentConditionNameForwardMatch = Me.SearchPaymentConditionNameTextBox.Text
        End With
        Dim pays = repo.FindPaymentConditionByCondition(cond)

        'データバインディング用オブジェクトへ変換
        Dim presentation = New List(Of PaymentConditionGridViewPresentation)
        For Each pay As Domain.PaymentCondition In pays
            presentation.Add(New PaymentConditionGridViewPresentation(pay))
        Next
        'GridViewへデータを設定
        Dim bindList = New SortableBindingList(Of PaymentConditionGridViewPresentation)(presentation)
        PaymentConditionDataGridView.DataSource = bindList
    End Sub

    ''' <summary>
    ''' DataGridView表示用オブジェクト
    ''' </summary>
    Private Class PaymentConditionGridViewPresentation

        Private ReadOnly _PaymentCondition As Domain.PaymentCondition

        Public Sub New(ByVal pc As Domain.PaymentCondition)
            _PaymentCondition = pc
        End Sub

        Public ReadOnly Property PaymentConditionName As String
            Get
                Return _PaymentCondition.Name
            End Get
        End Property

        Public ReadOnly Property CutOff As String
            Get
                If _PaymentCondition.CutOffByEndOfMonth = True Then
                    Return "月末"
                End If
                Return _PaymentCondition.CutOff.ToString
            End Get
        End Property

        Public ReadOnly Property DueDate As String
            Get
                If _PaymentCondition.PayEndOfMonth = True Then
                    Return "月末"
                End If
                Return _PaymentCondition.DueDate.ToString
            End Get
        End Property

        Public ReadOnly Property MonthOffset As String
            Get
                Select Case _PaymentCondition.MonthOffset
                    Case 0
                        Return "当月"
                    Case 1
                        Return "翌月"
                    Case 2
                        Return "翌々月"
                    Case Else
                        Return _PaymentCondition.MonthOffset & "か月後"
                End Select
            End Get
        End Property

        Public Function GetPaymentCondition() As Domain.PaymentCondition
            Return _PaymentCondition
        End Function

    End Class

#End Region


End Class