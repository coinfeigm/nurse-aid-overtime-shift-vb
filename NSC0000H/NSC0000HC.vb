Option Strict Off
Option Explicit On

Friend Class frmNSC0000HC
    Inherits General.FormBase
	'/----------------------------------------------------------------------/
    '/    ���і��́FMedWorks2.51
	'/        ��ʁF�߽ܰ�ޕύX�޲�۸�
	'/        �h�c�FfrmNSC0000HC
	'/     Copyright (C) Inter co.,ltd 1998
	'/----------------------------------------------------------------------/
	
	'----------------------------------------------------------------------
	'       ��ײ�ްĕϐ�
	'----------------------------------------------------------------------
	Private m_HospitalCD As String '�a�@CD
	Private m_UserID As String 'հ�ްID
	Private m_OldPwd As String '�߽ܰ�� �Y��հ�ްID�̕ύX�O�߽ܰ��
	
    Private m_LastUpdDate As Long '�ŏI�X�V���t

	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		'��� ��۰��
		Me.Close()
    End Sub

	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Const W_SUBNAME As String = "frmNSC0000HC cmdOK_Click"

        Try
            'Ҳ�̫�� ϳ��߲�� "�����v"�ɕύX
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'OK���� ����
            If Not RunOK() Then
                'ERROR�̏ꍇ

                'Ҳ�̫�� ϳ��߲�� "�ʏ�"�ɕύX
                Me.Cursor = System.Windows.Forms.Cursors.Default

                Exit Sub
            End If

            Me.Cursor = System.Windows.Forms.Cursors.Default

            '��� ��۰��
            Me.Close()

        Catch ex As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    Private Sub frmNSC0000HC_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Const W_SUBNAME As String = "frmNSC0000HC Form_Load"

        Try
            Dim w_ImagePath As String

            w_ImagePath = General.paGetIniSetting(General.G_STRININAME, General.G_STRSECTION1, "ImagePath", My.Application.Info.DirectoryPath & "\" & "image\")

            '�߽ܰ�ޕύX��� �����è �ݒ�
            'հ�ްID
            lblUserName.Text = m_UserID

            '�a�@CD�����ޯ�� ��̫�� �ݒ�
            lblHospital.Text = m_HospitalCD

            '̫�� ���� �ݒ�
            Me.Icon = New System.Drawing.Icon(w_ImagePath & "System.ico")

            '��ʒ����Ɉړ�
            Call General.paDspCenter(Me)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    'Password�̕ύX
    Private Function RunOK() As Boolean
        Const W_SUBNAME As String = "frmNSC0000HC RunOK"

        Try
            Dim w_Sql As String
            Dim w_UserCD As String
            Dim w_Password As String
            Dim w_HospitalCD As String
            Dim w_NewPassword As String
            Dim w_ReNewPassword As String
            Dim w_strMsg() As String
            Dim w_SysDate As Long
            Dim w_Rs As ADODB.Recordset
            Dim w_LastUpdDate_F As ADODB.Field
            Dim w_LastUpdDate As Long


            RunOK = False

            '�V�X�e�����t
            w_SysDate = Long.Parse(Format(Now, "yyyyMMddHHmmss"))

            'հ�ް�� �擾
            w_UserCD = lblUserName.Text

            '��Password �擾
            w_Password = txtOldPwd.Text

            '�a�@���� �擾
            w_HospitalCD = Trim(General.paLeft(lblHospital.Text, 2))

            '�p�X���[�h�ɋ�͓o�^�ł��Ȃ�
            If ("").Equals(txtNewPwd.Text) Then
                'հ�ްID ���݂��Ȃ�
                ReDim w_strMsg(1)
                w_strMsg(1) = "�p�X���[�h"
                Call General.paMsgDsp("NS0001", w_strMsg)
                Call General.paSetFocus(txtNewPwd)
                Exit Function
            End If

            '-- Password���� ---------------
            '�啶��/����������ʂȂ����f����
            If StrComp(m_OldPwd, w_Password, 0) <> 0 Then
                '�߽ܰ�� �قȂ�
                ReDim w_strMsg(1)
                w_strMsg(1) = "���p�X���[�h"
                Call General.paMsgDsp("NS0003", w_strMsg)
                Call General.paSetFocus(txtOldPwd)
                '�ُ�I��
                Exit Function
            End If

            '-- �VPassword & Password�m�F ���������� ----------------
            '�VPassword/Password�m�F �擾
            w_NewPassword = txtNewPwd.Text
            w_ReNewPassword = txtChkPwd.Text

            'Password ����(�啶��/����������ʂȂ����f����)
            If StrComp(w_NewPassword, w_ReNewPassword, 0) <> 0 Then
                '�قȂ�ꍇ
                '�װү���ޕ\��
                ReDim w_strMsg(1)
                w_strMsg(1) = "�m�F�p�p�X���[�h"
                Call General.paMsgDsp("NS0003", w_strMsg)
                Call General.paSetFocus(txtChkPwd)
                '�ُ�I��
                Exit Function
            End If

            '-- Password�X�V -------------------
            Call General.paBeginTrans()

            '---------------------
            '�r���`�F�b�N
            '---------------------
            w_Sql = "SELECT LASTUPDTIMEDATE FROM NS_USER_M"
            w_Sql = w_Sql & " WHERE HOSPITALCD = '" & w_HospitalCD & "'"
            w_Sql = w_Sql & " AND USERID = '" & w_UserCD & "'"
            w_Rs = General.paDBRecordSetOpenNoWait(w_Sql)

            If w_Rs Is Nothing Then
                'BUSY���
                Exit Function
            ElseIf w_Rs.RecordCount <= 0 Then
                '�폜����Ă���ꍇ
                ReDim w_strMsg(0)
                Call General.paMsgDsp("NS0044", w_strMsg)

                Exit Function
            Else
                '----------------------
                '�ŏI�X�V���t�`�F�b�N
                '----------------------
                w_LastUpdDate_F = w_Rs.Fields("LASTUPDTIMEDATE")
                '�ŏI�X�V���t
                w_LastUpdDate = Long.Parse(General.paGetDbFieldVal(w_LastUpdDate_F, 0))

                If m_LastUpdDate <> w_LastUpdDate Then
                    '�ύX����Ă���ꍇ
                    ReDim w_strMsg(0)
                    Call General.paMsgDsp("NS0045", w_strMsg)
                    Exit Function
                End If
            End If

            '�X�VSQL�ҏW
            w_Sql = "UPDATE NS_USER_M SET"
            w_Sql = w_Sql & " PASSWD  = '" & w_NewPassword & "'"
            w_Sql = w_Sql & " ,PASSWORDTIMEDATE = " & w_SysDate
            w_Sql = w_Sql & " ,LASTUPDTIMEDATE = " & w_SysDate
            w_Sql = w_Sql & " ,REGISTRANTID = '" & w_UserCD & "'"
            w_Sql = w_Sql & " WHERE USERID = '" & w_UserCD & "' "
            w_Sql = w_Sql & " AND HOSPITALCD = '" & w_HospitalCD & "' "
            Call General.paDBExecute(w_Sql)

            '�R�~�b�g
            Call General.paCommit()

            '����I��
            RunOK = True

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

	'հ�ްID/�a�@CD/���߽ܰ�ނ���ʉ�ʂ��󂯎��
	Public WriteOnly Property pSetData(ByVal p_UserID As String, ByVal p_Hospital As String) As String
		Set(ByVal Value As String)
			m_UserID = p_UserID
			m_HospitalCD = p_Hospital
			m_OldPwd = Value
		End Set
    End Property

	'�ŏI�X�V���t����ʉ�ʂ��󂯎��
    Public WriteOnly Property pLastUpdDate() As Long
        Set(ByVal Value As Long)
            m_LastUpdDate = Value
        End Set
    End Property

    '�e���͕� �L�[�������C�x���g
    Private Sub txtChkPwd_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtChkPwd.KeyPress
        'ENTER KEY
        If eventArgs.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            cmdOK.Focus()
        End If
    End Sub
    Private Sub txtNewPwd_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtNewPwd.KeyPress
        'ENTER KEY
        If eventArgs.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            txtChkPwd.Focus()
        End If
    End Sub
    Private Sub txtOldPwd_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtOldPwd.KeyPress
        'ENTER KEY
        If eventArgs.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            txtNewPwd.Focus()
        End If
    End Sub
End Class