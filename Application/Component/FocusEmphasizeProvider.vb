Option Strict On
Option Infer On

Imports System.ComponentModel

''' <summary>
''' フォーム内のフォーカスの当たっているコントロールを強調するプロバイダ
''' </summary>
Public Class FocusEmphasizeProvider
    Inherits Component

#Region "定数"

    ''' <summary>
    ''' フォーカスが当たっているときの色
    ''' </summary>
    Private ReadOnly FocusColor As Color = Color.SkyBlue

    ''' <summary>
    ''' フォーカスが当たっていないときの色
    ''' </summary>
    Private ReadOnly UnfocusColor As Color = SystemColors.Window

#End Region

#Region "プロパティ"

    Private _target As Form
    ''' <summary>
    ''' 適用フォーム
    ''' </summary>
    ''' <returns></returns>
    Public Property Target As Form
        Get
            Return _target
        End Get
        Set(value As Form)
            _target = value
            If _target Is Nothing Then
                'Nothingなら何もしない
                Return
            End If
            'ターゲットフォームに対してコントロール追加時に発生するイベントを追加する
            AddHandler _target.ControlAdded, AddressOf AddEventOnAttachControl
        End Set
    End Property

#End Region

    ''' <summary>
    ''' フォームにコントロールが追加されたときに呼び出されるイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddEventOnAttachControl(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs)
        '追加されたコントロールに対してイベントを追加する

        'Leaveイベントを追加
        AddHandler e.Control.Enter, AddressOf AddEnterEvent

        'Enterイベントを追加
        AddHandler e.Control.Leave, AddressOf AddLeaveEvent
    End Sub

    ''' <summary>
    ''' フォーム上コントロールに追加されるLeaveイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddLeaveEvent(ByVal sender As Object, ByVal e As EventArgs)
        Dim con As Control = CType(sender, Control)
        con.BackColor = UnfocusColor
    End Sub

    ''' <summary>
    ''' フォーム上コントロールに追加されるEnterイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddEnterEvent(ByVal sender As Object, ByVal e As EventArgs)
        Dim con As Control = CType(sender, Control)
        con.BackColor = FocusColor
    End Sub

End Class
