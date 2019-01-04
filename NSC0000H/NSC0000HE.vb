Option Strict Off
Option Explicit On

Friend Class frmNSC0000HE
    Inherits General.FormBase
	
	Private m_strSelDate As String
	Private m_strSelTime As String
	Private m_strGetTime As String
	Private m_OKCancelFlg As Boolean
	Private m_LoadOKFlg As Boolean
	
	'==================================
	'終了ステータス
	'==================================
    Public ReadOnly Property pEndState() As Boolean
        Get
            pEndState = m_OKCancelFlg
        End Get
    End Property
	
    Public ReadOnly Property pSelTime() As String
        Get
            pSelTime = m_strGetTime
        End Get
    End Property

	Public WriteOnly Property pSelDate(ByVal p_strDate As String) As String
		Set(ByVal Value As String)
			m_strSelDate = p_strDate
			m_strSelTime = Value
		End Set
	End Property
	
	Public ReadOnly Property pLoadOK() As Boolean
		Get
			pLoadOK = m_LoadOKFlg
		End Get
	End Property
	
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click

        'Cancel押下に設定
        m_OKCancelFlg = False

        Me.Close()
    End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Const W_SUBNAME As String = "NSC0000HE cmdOK_Click"

        Try
            Dim w_strMsg() As String


            '選択状態取得
            If IsDate(imtSelTime.Text) = False OrElse imtSelTime.Value.length <> 4 Then
                '未選択
                ReDim w_strMsg(1)
                w_strMsg(1) = "入力時間"
                Call General.paMsgDsp("NS0003", w_strMsg)
                imtSelTime.Focus()
                Exit Sub
            End If

            m_strGetTime = imtSelTime.GetHourTime & imtSelTime.GetMinTime

            'OKﾎﾞﾀﾝ押下
            m_OKCancelFlg = True

            Me.Close()

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try

    End Sub

    Private Sub frmNSC0000HE_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Const W_SUBNAME As String = "NSC0000HE Form_Load"

        Try
            imdSelDate.Text = Format(Integer.Parse(m_strSelDate), "0000/00/00")
            imdSelDate.Enabled = False
            imtSelTime.Text = Format(Integer.Parse(m_strSelTime), "00:00")

            '画面を中央表示する
            Call General.paDspCenter(Me)

            'Cancel押下に設定
            m_OKCancelFlg = False

            'Load処理正常終了
            m_LoadOKFlg = True

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub
End Class