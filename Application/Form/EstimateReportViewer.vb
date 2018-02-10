Option Strict On
Option Infer On
Imports Microsoft.Reporting.WinForms

''' <summary>
''' 見積書プレビュー画面
''' </summary>
Public Class EstimateReportViewer

#Region "定数"

    Private Const ESTIMATE_REPORT_FILE_NAME = "Estimate.rdlc"

#End Region

#Region "プロパティ"

    Private _PreviewEstimate As Domain.Estimate

    ''' <summary>
    ''' プレビューする見積
    ''' </summary>
    Public WriteOnly Property PreviewEstimate As Domain.Estimate
        Set(value As Domain.Estimate)
            _PreviewEstimate = value
            UpdateReport()
        End Set
    End Property

#End Region

#Region "イベント"

    ''' <summary>
    ''' ビュワーロード時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EstimateReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateReport()
        Me.ReportViewer.RefreshReport()
        'SubReportProcessingEventHandlerを追加する。
        AddHandler Me.ReportViewer.LocalReport.SubreportProcessing, AddressOf SubReportProcessingEventHandler
    End Sub

    ''' <summary>
    ''' サブレポート処理時に呼び出されるイベント
    ''' サブレポートで使用するデータソースにデータを指定する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub SubReportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        e.DataSources.Add(New ReportDataSource("EstimateDetailDataSet", MakeDetailsList))
    End Sub

#End Region

#Region "レポート制御"

    ''' <summary>
    ''' 明細のサブレポート用にリストを構成する
    ''' </summary>
    ''' <returns></returns>
    Private Function MakeDetailsList() As List(Of EstimateDetailReportPresenter)
        Dim ret As New List(Of EstimateDetailReportPresenter)

        For Each d In _PreviewEstimate.Details
            Dim p = New EstimateDetailReportPresenter(d)
            ret.Add(p)
        Next

        Return ret
    End Function

    ''' <summary>
    ''' レポートを表示する
    ''' </summary>
    Private Sub UpdateReport()
        '一度リセット
        ReportViewer.Reset()
        'サーバを使わずローカル制御
        ReportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        'レポートファイルの場所
        ReportViewer.LocalReport.ReportPath = GetReportFilePath()

        'レポートのデータソースを準備
        BindingSource.DataSource = New EstimateReportPresenter(_PreviewEstimate)
        Dim rds = New ReportDataSource("EstimateDataSet", BindingSource)

        'レポートへデータソースを設定
        ReportViewer.LocalReport.DataSources.Add(rds)
        ReportViewer.RefreshReport()
    End Sub

    ''' <summary>
    ''' レポートファイルのパスを取得
    ''' </summary>
    ''' <returns></returns>
    Private Function GetReportFilePath() As String
#If DEBUG Then
        Return IO.Path.Combine(Environment.CurrentDirectory, "../../Report", ESTIMATE_REPORT_FILE_NAME)

#Else
        return IO.Path.Combine(Environment.CurrentDirectory, "Report", ESTIMATE_REPORT_FILE_NAME)
#End If
    End Function

#End Region

End Class