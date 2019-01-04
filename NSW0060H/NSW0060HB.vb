Option Strict Off
Option Explicit On
Friend Class frmNSW0060HB
    Inherits General.FormBase
	
	Public Sub Set_WaitWindow(ByVal p_Max As Short, ByVal p_Text As String)
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HB Set_WaitWindow"

            Dim w_Count As String

            '処理種別を設定
            lblSyori.ForeColor = System.Drawing.Color.Blue
            lblSyori.Text = p_Text
            lblSyori.Refresh()

            '経過表示を更新
            w_Count = "0 / " & Convert.ToString(p_Max)
            lblCount.Text = w_Count
            lblCount.Refresh()

            'ProgressBar更新
            prgBar.Value = 0
            prgBar.Maximum = p_Max

            '画面再描画
            Me.Update()

            General.g_ErrorProc = w_PreErrorProc

        Catch ex As Exception
            Throw
        End Try
	End Sub
	
	Public Sub SyoriCount(ByVal p_Cnt As Short, ByVal p_Max As Short)
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HB SyoriCount"

            Dim w_Count As String

            '経過表示を更新
            w_Count = Convert.ToString(p_Cnt) & " / " & Convert.ToString(p_Max)
            lblCount.Text = w_Count
            lblCount.Refresh()

            'ProgressBar更新
            prgBar.Value = p_Cnt

            '画面再描画
            Me.Update()

            General.g_ErrorProc = w_PreErrorProc

        Catch ex As Exception
            Throw
        End Try
    End Sub
	
	Public WriteOnly Property SyoriText() As String
		Set(ByVal Value As String)
			
			lblSyori.Text = Value
			lblSyori.Refresh()
			
		End Set
	End Property
	
	Private Sub frmNSW0060HB_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try
            General.g_ErrorProc = "clsNSW0060HB Form_Load"

            '初期設定
            picWait.BringToFront()
            picWait.BorderStyle = System.Windows.Forms.BorderStyle.None

            Call General.paDspCenter(Me)

        Catch ex As Exception
            Call General.paDllTrpMsg(Str(Err.Number), General.g_ErrorProc)
        End Try
	End Sub

    Private Sub picWait_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picWait.Paint

        Dim w_PicWidth As Single
        Dim w_PicHeight As Single

        Dim w_graphics As Graphics = e.Graphics

        'ｵﾌﾞｼﾞｪｸﾄのｻｲｽﾞを取得
        w_PicWidth = picWait.ClientRectangle.Width
        w_PicHeight = picWait.ClientRectangle.Height

        '初期設定

        '上辺
        w_graphics.DrawLine(Pens.LightGray, 0, 0, w_PicWidth, 0)
        '左縦
        w_graphics.DrawLine(Pens.LightGray, 0, 0, 0, w_PicHeight)

        '底辺
        w_graphics.DrawLine(Pens.Gray, General.paTwipsTopixels(5), (w_PicHeight - General.paTwipsTopixels(30)), w_PicWidth, (w_PicHeight - General.paTwipsTopixels(30)))
        w_graphics.DrawLine(Pens.LightGray, 0, (w_PicHeight - General.paTwipsTopixels(10)), w_PicWidth, (w_PicHeight - General.paTwipsTopixels(10)))
        '右縦
        w_graphics.DrawLine(Pens.Gray, (w_PicWidth - General.paTwipsTopixels(30)), 0, (w_PicWidth - General.paTwipsTopixels(30)), w_PicHeight)
        w_graphics.DrawLine(Pens.LightGray, (w_PicWidth - General.paTwipsTopixels(10)), 0, (w_PicWidth - General.paTwipsTopixels(10)), w_PicHeight)

        'ﾀｲﾄﾙﾊﾞｰ
        w_graphics.DrawRectangle(Pens.LightSteelBlue, (General.paTwipsTopixels(50)), (General.paTwipsTopixels(50)), (w_PicWidth - General.paTwipsTopixels(110)), (General.paTwipsTopixels(280)))
        e.Graphics.FillRectangle(Brushes.LightSteelBlue, (General.paTwipsTopixels(50)), (General.paTwipsTopixels(50)), (w_PicWidth - General.paTwipsTopixels(110)), (General.paTwipsTopixels(280)))

        'ｷｬﾌﾟｼｮﾝの文字列
        w_graphics.DrawString("時間外勤務状況照会", New Font("MS Pゴシック", 9), Brushes.Black, General.paTwipsTopixels(75), General.paTwipsTopixels(75))

    End Sub
End Class