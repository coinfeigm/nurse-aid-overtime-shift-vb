Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("clsNSW0060H_NET.clsNSW0060H")> Public Class clsNSW0060H
    Inherits General.ClsBase
	'�v���p�e�B�[
	Private m_HospitalCD As String '�a�@����
	Private m_KangoTCD As String '�Ō�P�ʺ���
	Private m_KangoTNM As String '�Ō�P�ʖ���
	Private m_Calender As String '����ް�敪
	Private m_Year As String '�Ώ۔N
	Private m_Month As String '�Ώی�
	Private m_UserID As String 'հ�ްID
	
	'******************************
	'
	'   ��ʌĂяo�����\�b�h
	'
	'******************************
	Public Sub mShowWindow()

        General.g_ErrorProc = "clsNSW0060HA Show_MonthDataWindow"

        Try
            Dim w_Form As frmNSW0060HA

            'DB�����̎�ʂ��擾����
            General.BasGeneral.g_InstallType = Integer.Parse(General.paGetIniSetting(General.G_STRININAME, General.G_STRSECTION1, "InstallType", Convert.ToString(General.BasGeneral.gInstall_Enum.AccessType_PassThrough)))


            '���ʕa���ꗗ��ʵ�޼ު�Đ���
            w_Form = New frmNSW0060HA

            '�K�v�ް������n��
            w_Form.pSetHospital(m_UserID) = m_HospitalCD
            w_Form.pSetKangoT(m_KangoTNM) = m_KangoTCD
            w_Form.pSelDate = Integer.Parse(m_Year & m_Month & "01")

            '�\��
            w_Form.ShowDialog(pProcessObj)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), General.g_ErrorProc)
        End Try

    End Sub
	
	'Inatalltype�󂯎��
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
	
	'�f�[�^�������i��޼ު��
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
			
			'UPGRADE_WARNING: �I�u�W�F�N�g pCalendar �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			m_Calender = Value
			
		End Set
	End Property
	
	'UPGRADE_NOTE: Class_Initialize �� Class_Initialize_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Private Sub Class_Initialize_Renamed()
		Dim g_TypeFlg As Object
		Dim G_TYOKIN_MSG As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g G_TYOKIN_MSG �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g g_TypeFlg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		g_TypeFlg = G_TYOKIN_MSG '���ߋΖ����ԊǗ��V�X�e��
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
End Class