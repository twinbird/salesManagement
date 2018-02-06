Public Class EstimateReportViewer
    Private Sub EstimateReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer.RefreshReport()
    End Sub
End Class