Option Strict Off
Option Explicit On

Friend Class clsMainForm
	'/----------------------------------------------------------------------/
	'/
	'/    ���і��́FMedWorks2.0
	'/        ��ʁF���C�����
	'/        �h�c�FNSC0000H
	'/
	'/
	'/      �쐬�ҁF        CREATE 1997/05/07          REV 01.00
	'/      �X�V�ҁFHirata  UPDATE 2009/04/09          �yPKG-0025�z
	'/                        �X�V���e�F(   )
	'/     Copyright (C) Inter co.,ltd 1997
	'/----------------------------------------------------------------------/
	
    Private m_Form As frmNSC0000HA 'Ҳ�̫�ѵ�޼ު��
	
	Private m_UserNo As String '�����ID�i�E���ԍ��j
	Private m_UserName As String '����Ҏ���
	
	
	'Ҳ݉�ʂ�\������(�Ō�P�ʏ��/�Ζ���/����޳���޳��\��)
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
        '��޼ު�ĉ��
        m_Form = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
	
	'�E���ԍ�
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