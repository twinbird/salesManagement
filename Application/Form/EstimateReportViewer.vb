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

    Private Sub EstimateReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateReport()
        Me.ReportViewer.RefreshReport()
    End Sub

#End Region

#Region "レポート制御"

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