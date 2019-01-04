Option Strict Off
Option Explicit On

Friend Class clsMainForm
	'/----------------------------------------------------------------------/
	'/
	'/    ｼｽﾃﾑ名称：MedWorks2.0
	'/        画面：メイン画面
	'/        ＩＤ：NSC0000H
	'/
	'/
	'/      作成者：        CREATE 1997/05/07          REV 01.00
	'/      更新者：Hirata  UPDATE 2009/04/09          【PKG-0025】
	'/                        更新内容：(   )
	'/     Copyright (C) Inter co.,ltd 1997
	'/----------------------------------------------------------------------/
	
    Private m_Form As frmNSC0000HA 'ﾒｲﾝﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄ
	
	Private m_UserNo As String '操作者ID（職員番号）
	Private m_UserName As String '操作者氏名
	
	
	'ﾒｲﾝ画面を表示する(看護単位情報/勤務状況/ｶﾚﾝﾀﾞｳｨﾝﾄﾞｳを表示)
	Public Sub mShowMainWindow()
        Const W_SUBNAME As String = "clsNSC0000HMain mShowMainWindow"
        Try
            m_Form = New frmNSC0000HA
            m_Form.Pre_Load()
            Application.Run(m_Form)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    Public Sub Class_Terminate_Renamed()
        'ｵﾌﾞｼﾞｪｸﾄ解放
        m_Form = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
	
	'職員番号
    Public Property UserNo() As String
        Get
            UserNo = m_UserNo
        End Get
        Set(ByVal Value As String)
            m_UserNo = Value
        End Set
    End Property
	
	Public Property UserNm() As String
		Get
			UserNm = m_UserName
		End Get
		Set(ByVal Value As String)
			m_UserName = Value
		End Set
	End Property
End Class