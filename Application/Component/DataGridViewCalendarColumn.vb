'Microsoft Limited Public License
'本ライセンスは、上記の「本 Web サイトで入手可能なソフトウェアに関する注意」の規定に従い、ライセンス契約なしで本 Web サイトで入手可能な「サンプル」または「例」と表示されているコードの使用について規定するものです。お客様は、かかるコード (以下「ソフトウェア」といいます) を使用した場合、本ライセンスに同意したことになります。 本ライセンスに同意されない場合、そのソフトウェアを使用することはできません。
'1. 定義
'「複製する」、「複製」、「二次的著作物」、「頒布」という用語はそれぞれ、アメリカ合衆国著作権法における場合と同様の意味を有します。
'「投稿物」とは、オリジナルのソフトウェア、またはソフトウェアへの追加もしくは変更を意味します。
'「投稿者」とは、本ライセンスに基づいて投稿を行う人を意味します。
'「使用許諾された特許」とは、投稿物が直接抵触する投稿者の特許クレームを意味します。
'2. 権利の許可
'(A) 著作権の許諾 - 第 3 条の使用許諾条件および制限を含む本ライセンスの規定に従い、各投稿者はお客様に対して、それぞれの投稿物を複製し、投稿物の二次的著作物を作成し、投稿物またはお客様が作成した二次的著作物を頒布するための非独占的かつ地域無制限の著作権を無償で許諾します。
'(B) 特許許諾 - 第 3 条の使用許諾条件および制限を含む本契約書の規定に従い、各投稿者はお客様に対して、本ソフトウェア内の投稿物もしくは本ソフトウェア内の投稿物の二次的著作物につき、使用許諾された特許に基づいて作成、第三者による作成、使用、販売、輸入その他の手段による処分を実施するための非独占的かつ地域無制限の著作権を無償で許諾します。
'3. 条件と制限
'(A) 商標使用許諾の排除 - 本ライセンスはお客様に対し、投稿者の名称、ロゴまたは商標を使用する権利を付与するものではありません。
'(B) 本ソフトウェアによって特許が侵害されたとして、お客様が投稿者に対して特許権に基づく請求を申し立てる場合、かかる投稿者からお客様に付与されていた特許ライセンスは自動的に終了するものとします。
'(C) 本ソフトウェアの一部を頒布する場合、お客様は、本ソフトウェアにある著作権、特許権、商標、帰属権に関するすべての通知をそのまま表示するものとします。
'(D) 本ソフトウェアの一部をソース コード形式で頒布する場合、お客様は、本ライセンスの完全な写しをお客様の頒布物に組み入れることにより、本ライセンスに基づいてのみ頒布を行うことができます。  本ソフトウェアの一部をコンパイル済みコード形式またはオブジェクト コード形式で頒布する場合、お客様は、本ライセンスに準拠したライセンスに基づいてのみ頒布を行うことができます。
'(E) 本ソフトウェアは「現状有姿のまま」で使用許諾されます。本サービスの使用から生じる危険は、お客様が負担するものとします。 投稿者は、他の明示的な保証、担保、または条件については一切の責任を負いません。 お客様の地域の法令によっては、本ライセンスによって変更することのできない、その他の消費者としての権利が存在する場合があります。 お客様の地域の法律によって認められる範囲において、投稿者は、商品性、特定目的適合性および第三者の権利の非侵害性に関する黙示の保証をいたしません。
'(F) プラットフォームの限定 - 第 2 条 (A) 項および第 2 条 (B) 項で付与されるライセンスは、お客様が作成し、Microsoft Windows オペレーティング システム製品上で動作するソフトウェアまたは二次的著作物のみに適用されます。
Option Strict On
Option Infer On

Imports System
Imports System.Windows.Forms

''' <summary>
''' データグリッドビューのカレンダーカラム
''' </summary>
''' <remarks>
''' MSDNのサンプルコードからの転用
''' https://msdn.microsoft.com/ja-jp/library/7tas5c80(v=vs.110).aspx
''' Lisenceの詳細に関しては以下を参照
''' https://msdn.microsoft.com/ja-jp/cc300389
''' </remarks>
Public Class DataGridViewCalendarColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "d"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer,
        ByVal initialFormattedValue As Object,
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue,
            dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl =
            CType(DataGridView.EditingControl, CalendarEditingControl)

        ' Use the default row value when Value property is null.
        If (Me.Value Is Nothing) Then
            ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
        Else
            ctl.Value = CType(Me.Value, DateTime)
        End If
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return DateTime.Now
        End Get
    End Property

End Class

Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Short
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value.ToShortDateString()
        End Get

        Set(ByVal value As Object)
            Try
                ' This will throw an exception of the string is 
                ' null, empty, or not in the format of a date.
                Me.Value = DateTime.Parse(CStr(value))
            Catch
                ' In the case of an exception, just use the default
                ' value so we're not left with a null value.
                Me.Value = DateTime.Now
            End Try
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value.ToShortDateString()

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys,
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right,
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)

    End Sub

End Class
