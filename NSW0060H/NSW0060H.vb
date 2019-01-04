Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("clsNSW0060H_NET.clsNSW0060H")> Public Class clsNSW0060H
    Inherits General.ClsBase
	'プロパティー
	Private m_HospitalCD As String '病院ｺｰﾄﾞ
	Private m_KangoTCD As String '看護単位ｺｰﾄﾞ
	Private m_KangoTNM As String '看護単位名称
	Private m_Calender As String 'ｶﾚﾝﾀﾞｰ区分
	Private m_Year As String '対象年
	Private m_Month As String '対象月
	Private m_UserID As String 'ﾕｰｻﾞｰID
	
	'******************************
	'
	'   画面呼び出しメソッド
	'
	'******************************
	Public Sub mShowWindow()

        General.g_ErrorProc = "clsNSW0060HA Show_MonthDataWindow"

        Try
            Dim w_Form As frmNSW0060HA

            'DBｱｸｾｽの種別を取得する
            General.BasGeneral.g_InstallType = Integer.Parse(General.paGetIniSetting(General.G_STRININAME, General.G_STRSECTION1, "InstallType", Convert.ToString(General.BasGeneral.gInstall_Enum.AccessType_PassThrough)))


            '月別病棟一覧画面ｵﾌﾞｼﾞｪｸﾄ生成
            w_Form = New frmNSW0060HA

            '必要ﾃﾞｰﾀ引き渡し
            w_Form.pSetHospital(m_UserID) = m_HospitalCD
            w_Form.pSetKangoT(m_KangoTNM) = m_KangoTCD
            w_Form.pSelDate = Integer.Parse(m_Year & m_Month & "01")

            '表示
            w_Form.ShowDialog(pProcessObj)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), General.g_ErrorProc)
        End Try

    End Sub
	
	'Inatalltype受け取り
	Public WriteOnly Property pInstallType() As Short
		Set(ByVal Value As Short)
            General.BasGeneral.g_InstallType = Value
		End Set
	End Property
	
	Public WriteOnly Property pHospitalCD() As String
		Set(ByVal Value As String)
			
            m_HospitalCD = Value
			
		End Set
	End Property
	
	Public WriteOnly Property pKangoTCD() As String
		Set(ByVal Value As String)
			
			m_KangoTCD = Value
			
		End Set
	End Property
	
	
	Public WriteOnly Property pKangoTNM() As String
		Set(ByVal Value As String)
			
			m_KangoTNM = Value
			
		End Set
	End Property
	
	Public WriteOnly Property pYear() As String
		Set(ByVal Value As String)
			
			m_Year = Value
			
		End Set
	End Property
	
	Public WriteOnly Property pMonth() As String
		Set(ByVal Value As String)
			
			m_Month = Value
			
		End Set
	End Property
	
	'データ検索部品ｵﾌﾞｼﾞｪｸﾄ
	Public WriteOnly Property pGetDataObj() As Object
		Set(ByVal Value As Object)
            General.g_objGetData = Value
		End Set
	End Property
	
	
	Public WriteOnly Property pUserID() As String
		Set(ByVal Value As String)
			
			m_UserID = Value
			
		End Set
	End Property
	
	
	Public WriteOnly Property p_Calendar() As Object
		Set(ByVal Value As Object)
			
			'UPGRADE_WARNING: オブジェクト pCalendar の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			m_Calender = Value
			
		End Set
	End Property
	
	'UPGRADE_NOTE: Class_Initialize は Class_Initialize_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Private Sub Class_Initialize_Renamed()
		Dim g_TypeFlg As Object
		Dim G_TYOKIN_MSG As Object
		'UPGRADE_WARNING: オブジェクト G_TYOKIN_MSG の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト g_TypeFlg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		g_TypeFlg = G_TYOKIN_MSG '超過勤務時間管理システム
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
End Class