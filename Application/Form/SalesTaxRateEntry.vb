Option Strict On
Option Infer On
Imports System.ComponentModel

''' <summary>
''' 消費税率の設定画面
''' </summary>
Public Class SalesTaxRateEntry

#Region "インスタンス変数"

    Private _rows As List(Of Domain.SalesTax)
    Private _bindingList As SortableBindingList(Of Domain.SalesTax)
    Private _repo As Infrastructure.SalesTaxRepository

#End Region

#Region "DataGridView制御"

    ''' <summary>
    ''' コントロールとインスタンス変数をセットアップ
    ''' </summary>
    Private Sub Setup()
        'データ取得用のリポジトリを作成
        _repo = New Infrastructure.SalesTaxRepository
        'データグリッドビューの設定
        SetupDataGridView()
    End Sub

    ''' <summary>
    ''' DataGridViewへデータをロード
    ''' </summary>
    Private Sub LoadGridData()
        'リポジトリから情報を取得
        _rows = _repo.FindAll

        'GridViewへデータを設定
        Dim bindList = New SortableBindingList(Of Domain.SalesTax)(_rows)
        SalesTaxDataGridView.DataSource = bindList
        _bindingList = bindList
    End Sub

    ''' <summary>
    ''' 新規行を追加
    ''' </summary>
    Private Sub AddNewRow()
        Dim tax = New Domain.SalesTax(_repo)
        _rows.Add(tax)
        'resetして追加行を反映
        _bindingList.ResetBindings()
    End Sub

    ''' <summary>
    ''' DataGridViewのデータをセーブ
    ''' </summary>
    Private Sub SaveGridData()
        '一度resetしてデータをUIと一致させる
        _bindingList.ResetBindings()
        '保存
        If _repo.Save(_rows) = True Then
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' 従業員のDataGridViewのコントロール設定
    ''' </summary>
    Private Sub SetupDataGridView()
        '一度列全体をクリア
        SalesTaxDataGridView.Columns.Clear()
        '列の自動生成を行わない
        SalesTaxDataGridView.AutoGenerateColumns = False
        'GridView内での新規行追加許可
        SalesTaxDataGridView.AllowUserToAddRows = True

        '適用開始日列を作成
        Dim applyStartDateCol = New DataGridViewTextBoxColumn
        With applyStartDateCol
            .Name = "ApplyStartDate"
            .HeaderText = "適用開始日"
            .ReadOnly = False
            .DataPropertyName = "ApplyStartDate"
        End With
        SalesTaxDataGridView.Columns.Add(applyStartDateCol)

        '税率列を作成
        Dim rateCol = New DataGridViewTextBoxColumn
        With rateCol
            .Name = "Rage"
            .HeaderText = "税率(%)"
            .DataPropertyName = "TaxRateOfPercentage"
        End With
        SalesTaxDataGridView.Columns.Add(rateCol)

        '明細をクリア
        SalesTaxDataGridView.DataSource = Nothing
    End Sub

#End Region

#Region "イベント"

    ''' <summary>
    ''' 画面のアクティベイト時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SalesTaxRateEntry_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        LoadGridData()
    End Sub

    ''' <summary>
    ''' 画面のロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SalesTaxRateEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        Setup()
        LoadGridData()
    End Sub

    ''' <summary>
    ''' 登録ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EntryButton_Click(sender As Object, e As EventArgs) Handles EntryButton.Click
        SaveGridData()
    End Sub

    ''' <summary>
    ''' 行を追加ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NewRowAddButton_Click(sender As Object, e As EventArgs) Handles NewRowAddButton.Click
        AddNewRow()
    End Sub

#End Region

End Class