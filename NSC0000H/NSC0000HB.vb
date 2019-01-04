Imports System.io

Public Class frmNSC0000HB

    Public Sub NSC0000HB_Load()
        DataLoad()

        Dim w_ImagePath As String
        w_ImagePath = General.paGetIniSetting(General.G_STRININAME, General.G_STRSECTION1, "ImagePath", My.Application.Info.DirectoryPath & "\" & "image\")

        '�t�H�[���A�C�R�� �ݒ�
        Me.BackgroundImage = System.Drawing.Image.FromFile(w_ImagePath & "BackGround.bmp")
        Me.Icon = New System.Drawing.Icon(w_ImagePath & "System.ico")

        '����I��
        m_ErrorFlg = True

        If General.g_LuncherFlg <> False Then
            txtPassword.Text = General.g_LanchPassword
            txtUser.Text = General.g_LanchUser
            Call cmdOK_Click(cmdOK, New System.EventArgs())
        End If
    End Sub
    '----------------------------------------------------------------------
    '       ��ײ�ްĕϐ�
    '----------------------------------------------------------------------
    Private m_ErrorFlg As Boolean 'Form_Load����� �װ�׸�(����:True �ُ�:False)
    Private m_EndStatus As Boolean '�I�����(OK:True,��ݾ�:False)

    Private m_LastUpdDate As Long '�ŏI�X�V���t

    '���O�C��
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Const W_SUBNAME As String = "frmNSC0000HB cmdOK_Click"

        Try
            Dim w_Sql As String
            Dim w_SysDate As Long
            Dim w_HospitalCD As String
            Dim w_UserCD As String

            '�a�@CD
            w_HospitalCD = Trim(General.paLeft(cboHospital.Text, 2))
            '���p��CD
            w_UserCD = txtUser.Text
            '�G���[�t���O�����ɖ߂�
            General.g_ErrorFlg = False

            'ϳ��߲�� "�����v"�ɕύX
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'OK���� ����
            If RunOK() = False Then
                'ERROR�̏ꍇ
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Else
                m_EndStatus = True
                Me.Close()
            End If


            '���ї��p����(�v��/����)����
            If Not AccountChk() Then
                '�v��/���� �Ƃ��ɗ��p�����Ȃ��ꍇ
                '        Me.MousePointer = vbDefault
                '        Exit Sub
            End If

            '-------------------------------------------------
            '���p�҃}�X�^�̃��O�C�����t���X�V(�r������Ȃ�)
            '-------------------------------------------------
            w_SysDate = Long.Parse(Format(Now, "yyyyMMddHHmmss"))

            Call General.paBeginTrans()

            w_Sql = "UPDATE NS_USER_M SET"
            w_Sql = w_Sql & " LOGINTIMEDATE = " & w_SysDate
            w_Sql = w_Sql & " WHERE HOSPITALCD = '" & w_HospitalCD & "'"
            w_Sql = w_Sql & " AND USERID = '" & w_UserCD & "'"
            Call General.paDBExecute(w_Sql)

            '�R�~�b�g
            Call General.paCommit()


            '�Z�L�����e�B�}�X�^���i
            With General.g_objSecurity
                .pHospitalCD = General.g_strHospitalCD '�{�݃R�[�h
                .pUserID = General.g_strUserID '���p�҃R�[�h
                .pUserStaffMngID = General.g_strUserMngID '���p�ҐE���Ǘ��ԍ�
                .pGroupCD = General.g_strUserGroupCD '���p�҃O���[�v�R�[�h
                .pUserKinmuDeptCD = General.g_strUserKinmuDeptCD '���p�ҏ��������R�[�h
                .pGetMasterObj = General.g_objGetMaster '�}�X�^�擾���i

                '��������ь������Ă���Ζ������R�[�h�̋Ζ������}�X�^�����擾����
                If .mGetUserKinmuDeptInfo(General.paGetDateIntegerFromDate(Now, General.G_DATE_ENUM.yyyyMMdd)) = False Then

                End If
            End With

            '���F���i(NSA0000C)
            General.g_objSyouninData.pHospitalCD = General.g_strHospitalCD '�{�݃R�[�h
            General.g_objSyouninData.pUserID = General.g_strUserID '���p�҃R�[�h
            General.g_objSyouninData.pUserStaffMngID = General.g_strUserMngID '���p�ҐE���Ǘ��ԍ�
            General.g_objSyouninData.pGroupCD = General.g_strUserGroupCD '���p�҃O���[�v�R�[�h
            General.g_objSyouninData.pWebFlg = False 'WEB�t���O(C/S�FFalse�@WEB:True)
            General.g_objSyouninData.pInstallType = General.g_InstallType '�C���X�g�[���^�C�v
            General.g_objSyouninData.pSecurityObj = General.g_objSecurity '�Z�L�����e�B���i
            General.g_objSyouninData.pGetDataObj = General.g_objGetData
            General.g_objSyouninData.pGetMasterObj = General.g_objGetMaster

            '���������i(NSD0000C)
            General.g_objDutyGroup.pHospitalCD = General.g_strHospitalCD '�{�݃R�[�h
            General.g_objDutyGroup.pUserID = General.g_strUserID '���p�҃R�[�h
            General.g_objDutyGroup.pUserStaffMngID = General.g_strUserMngID '���p�ҐE���Ǘ��ԍ�
            General.g_objDutyGroup.pGroupCD = General.g_strUserGroupCD '���p�҃O���[�v�R�[�h

            '���X�g�o�[���j���[�擾
            If fncListBarMenu() = False Then
                '�I�����(�ُ�) �ݒ�
                m_EndStatus = False
            Else
                '�I�����(����) �ݒ�
                m_EndStatus = True
            End If

            If General.g_LuncherFlg <> True Then
                '��� ��۰��
                Me.Close()
            End If

        Catch ex As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    '�������� ����� ڼ޽�ؐݒ�
    Private Function RunOK() As Boolean
        Const W_SUBNAME As String = "frmNSC0000HB RunOK"

        Try
            Dim w_UserCD As String
            Dim w_Password As String
            Dim w_HospitalCD As String
            Dim w_RegStr As String
            Dim w_ErrMsgNo As Integer

            Dim w_strMsg() As String

            '�ُ�l���
            RunOK = False

            'հ�ް��/�߽ܰ��/�{�ݺ��� �擾
            w_UserCD = txtUser.Text
            w_Password = txtPassword.Text
            w_HospitalCD = Trim(General.paLeft(cboHospital.Text, 2))

            '-------------------------------------------------------
            '   հ�ްID(�E���Ǘ��ԍ�),�߽ܰ�ތ���
            '-------------------------------------------------------
            If FindUserCD(w_HospitalCD, w_UserCD, w_Password, w_ErrMsgNo) = False Then
                'ERROR
                Select Case w_ErrMsgNo
                    Case 1
                        'հ�ްID ���݂��Ȃ�
                        ReDim w_strMsg(1)
                        w_strMsg(1) = "���͂��ꂽ���O�C���h�c"
                        Call General.paMsgDsp("NS0008", w_strMsg)
                        Call General.paSetFocus(txtUser)
                    Case 2
                        '�߽ܰ�� �قȂ�
                        ReDim w_strMsg(1)
                        w_strMsg(1) = "�p�X���[�h"
                        Call General.paMsgDsp("NS0003", w_strMsg)
                        Call General.paSetFocus(txtPassword)
                    Case Else
                End Select
                Exit Function
            End If

            '�L���I�������z���Ă����ꍇ
            If fncGetEffendDay(w_HospitalCD, w_UserCD) < General.paGetDateIntegerFromDate(Now) Then
                ReDim w_strMsg(3)
                w_strMsg(1) = "���[�U�["
                w_strMsg(2) = "�g�p����"
                w_strMsg(3) = "�L����"
                Call General.paMsgDsp("NS0149", w_strMsg)
                Call General.paSetFocus(txtUser)
                Exit Function
            End If

            '���[�U�[ID/�{��CD/�{�ݖ��� �ݒ�
            General.g_strUserID = w_UserCD
            General.g_strHospitalCD = w_HospitalCD
            General.g_strHospitalNm = Trim(Mid(cboHospital.Text, 3))

            w_RegStr = General.G_SYSTEM_WIN7 & "\" & General.G_STRMAINKEY1
            '�I���Ζ�����CD
            General.g_strSelKinmuDeptCD = General.paGetSetting(w_RegStr, "Current", "KINMUDEPTCD", "")
            '�I���Ζ���������
            General.g_strSelKinmuDeptNm = General.paGetSetting(w_RegStr, "Current", "KINMUDEPTNM", "")
            General.g_objGetData.p�a�@CD = General.g_strHospitalCD

            '�Ζ�����������
            General.g_strUserKinmuDeptCD = ""
            General.g_strUserKinmuDeptNm = ""

            '���p�҂̐E���Ǘ��ԍ��ƁA���������̎擾�ɕύX
            Call GetUserKangoT(w_HospitalCD, w_UserCD)

            '----- ڼ޽�ؐݒ� ------------------
            w_RegStr = General.G_SYSTEM_WIN7 & "\" & General.G_STRMAINKEY1
            '�����p��ID
            Call General.paSaveSetting(w_RegStr, "Current", "USERID", General.g_strUserID)
            '�����p�Җ�
            Call General.paSaveSetting(w_RegStr, "Current", "USERNAME", General.g_strUserName)
            '�����p�҃O���[�v�R�[�h
            Call General.paSaveSetting(w_RegStr, "Current", "USERGROUPCD", General.g_strUserGroupCD)
            '�����p�ҐE���Ǘ��ԍ�
            Call General.paSaveSetting(w_RegStr, "Current", "USERMNGID", General.g_strUserMngID)
            '�����p�ҏ����Ζ�����CD
            Call General.paSaveSetting(w_RegStr, "Current", "USERKINMUDEPTCD", General.g_strUserKinmuDeptCD)
            '�����p�ҏ����Ζ���������
            Call General.paSaveSetting(w_RegStr, "Current", "USERKINMUDEPTNM", General.g_strUserKinmuDeptNm)
            '���{��CD
            Call General.paSaveSetting(w_RegStr, "Current", "HOSPITALCD", General.g_strHospitalCD)
            '���{�ݖ���
            Call General.paSaveSetting(w_RegStr, "Current", "HOSPITALNM", General.g_strHospitalNm)
            '���{�ݺ���(ListIndex)
            Call General.paSaveSetting(w_RegStr, "Current", "HOSPITALINDEX", Format(cboHospital.SelectedIndex))

            '����I��
            RunOK = True

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    'հ�ް����
    Private Function FindUserCD(ByVal p_HospitalCD As String, ByVal p_UserCD As String, ByVal p_Password As String, ByRef p_ErrMsgNo As Integer) As Integer
        Const W_SUBNAME As String = "frmNSC0000HB FindUserCD"

        Try
            Dim w_Index As Integer
            Dim w_Sql As String = String.Empty
            Dim w_Password As String
            Dim w_Rs As ADODB.Recordset
            Dim w_Password_F As ADODB.Field
            Dim w_���p��Name_F As ADODB.Field
            Dim w_GroupCD_F As ADODB.Field

            'ү���޺��ޒ萔
            Const w_Msg_User As Integer = 1 'հ�ް�װ
            Const w_Msg_PassWord As Integer = 2 'Password�װ


            '�ُ�l���
            FindUserCD = False

            'հ�ްID��������
            If Trim(p_UserCD) = "" Then
                'Error հ�ްID���݂��Ȃ�
                p_ErrMsgNo = w_Msg_User
                '�ُ�I��
                Exit Function
            End If

            '-- հ�ޏ��擾 ----------------
            w_Sql = w_Sql & "SELECT "
            w_Sql = w_Sql & "NAME, "
            w_Sql = w_Sql & "PASSWD, "
            w_Sql = w_Sql & "GROUPCD "
            w_Sql = w_Sql & "FROM NS_USER_M "
            w_Sql = w_Sql & "WHERE NS_USER_M.UserID = '" & p_UserCD & "' "
            w_Sql = w_Sql & "  AND NS_USER_M.HospitalCD = '" & p_HospitalCD & "' "

            'RecordSet ��޼ު�Ă̍쐬(�Q�Ƃ̂�)
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            '0���ް�����
            If w_Rs.RecordCount = 0 Then
                'Error հ�ްID���݂��Ȃ�
                p_ErrMsgNo = w_Msg_User

                '��޼ު�� �폜
                w_Rs.Close()
                Exit Function
            Else
                '�E�����Ͻ���հ�ނ����݂����ꍇ

                '̨���ޒ�`
                w_Password_F = w_Rs.Fields("PASSWD")
                w_���p��Name_F = w_Rs.Fields("NAME")
                w_GroupCD_F = w_Rs.Fields("GROUPCD")

                '�啶��/����������ʂȂ����f����
                w_Password = General.paGetDbFieldVal(w_Password_F, "")

                If General.g_LuncherFlg = False Then
                    If StrComp(p_Password, w_Password, 0) <> 0 Then
                        '�قȂ�ꍇ
                        'Error հ�ްID���݂��Ȃ�
                        p_ErrMsgNo = w_Msg_PassWord

                        '��޼ު�� �폜
                        w_Rs.Close()
                        Exit Function
                    End If
                End If
                '================================================================================
            End If

            'հ�ް�� �擾
            General.g_strUserName = General.paGetDbFieldVal(w_���p��Name_F, "")
            '���p�҃O���[�v�R�[�h
            General.g_strUserGroupCD = General.paGetDbFieldVal(w_GroupCD_F, "")

            '��޼ު�ĉ��
            w_Rs.Close()


            '-- ���� �ް��ݒ� ------------------
            w_Index = cboHospital.SelectedIndex + 1

            '����I��
            FindUserCD = True

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    '===========================================================================
    '   ����ҊŌ�P�ʏ��擾
    '===========================================================================
    Private Sub GetUserKangoT(ByVal p_HosCD As String, ByVal p_UserID As String)
        Const W_SUBNAME As String = "frmNSC0000HB GetUserKangoT"

        Try
            Dim w_NowDate As Integer
            Dim w_Code As String = String.Empty
            Dim w_Name As String = String.Empty
            Dim w_lngKensu As Integer
            Dim w_lngLoop As Integer

            Dim w_strSql As String
            Dim w_Rs As ADODB.Recordset
            Dim w_StaffMngID_F As ADODB.Field

            '�V�X�e�����t�擾
            w_NowDate = General.paGetDateIntegerFromDate(Now)

            '�E���Ǘ��ԍ��̎擾
            w_strSql = ""
            w_strSql = w_strSql & " SELECT STAFFMNGID "
            w_strSql = w_strSql & " FROM   NS_USER_M "
            w_strSql = w_strSql & " WHERE  NS_USER_M.UserID = '" & p_UserID & "' "
            w_strSql = w_strSql & "  AND   NS_USER_M.HospitalCD = '" & p_HosCD & "' "

            w_Rs = General.paDBRecordSetOpen(w_strSql)

            '�����p�҂̐E���Ǘ��ԍ�

            '0���ް�����
            If w_Rs.RecordCount = 0 Then

                General.g_strUserMngID = ""

                '��޼ު�� �폜
                w_Rs.Close()
                Exit Sub
            Else
                '�E�����Ͻ���հ�ނ����݂����ꍇ

                '̨���ޒ�`
                w_StaffMngID_F = w_Rs.Fields("STAFFMNGID")
                '�b��Ή�
                General.g_strUserMngID = Trim(w_StaffMngID_F.Value & "")

            End If

            '�Ζ��n�ٓ����e����擾����
            With General.g_objGetData
                .p�a�@CD = General.g_strHospitalCD
                .p�E���ԍ��ϊ� = 0 '���ׂĂ̏��
                '        .p�E���敪 = 1
                '        .p�E���ԍ� = p_UserID
                .p�E���敪 = 0
                .p�E���ԍ� = General.g_strUserMngID
                '================================================================
                .p���t�敪 = 0
                .p�J�n�N���� = w_NowDate
                .p�����\�[�gFLG = 0 '����
                .p�V�X�e���敪 = 1 '�E����K�v�Ȃ�
                If .mStaffInit = False Then
                    '�ް��Ȃ�
                    General.g_strUserKinmuDeptCD = ""
                    General.g_strUserKinmuDeptNm = ""
                Else
                    '�f�[�^������ꍇ�i��{�I�ɂP���ɍi����͂��j
                    w_lngKensu = General.g_objGetData.f�Ζ��n�ٓ�����
                    For w_lngLoop = 1 To w_lngKensu
                        .p�Ζ��n�ٓ����� = w_lngLoop
                        w_Code = .f�Ō�P��CD1
                        w_Name = .f�Ō�P�ʖ���1
                    Next w_lngLoop

                    '�f�[�^�擾
                    General.g_strUserKinmuDeptCD = w_Code
                    General.g_strUserKinmuDeptNm = w_Name
                End If
            End With

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    Private Function fncGetEffendDay(ByVal p_HospitalCD As String, ByVal p_UserCD As String) As Integer
        Const W_SUBNAME As String = "frmNSC0000HB EffendDayChk"

        Try
            Dim w_Sql As String = String.Empty
            Dim w_Rs As ADODB.Recordset
            Dim w_EffendDay_F As ADODB.Field

            w_Sql = w_Sql & "SELECT "
            w_Sql = w_Sql & "EFFENDDAY "
            w_Sql = w_Sql & "FROM NS_USER_M "
            w_Sql = w_Sql & "WHERE NS_USER_M.UserID = '" & p_UserCD & "' "
            w_Sql = w_Sql & "  AND NS_USER_M.HospitalCD = '" & p_HospitalCD & "' "

            'RecordSet ��޼ު�Ă̍쐬(�Q�Ƃ̂�)
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            '0���ް�����
            If w_Rs.RecordCount = 0 Then

                '��޼ު�� �폜
                w_Rs.Close()
                Exit Function
            Else

                '̨���ޒ�`
                w_EffendDay_F = w_Rs.Fields("EFFENDDAY")

            End If

            '����I��
            fncGetEffendDay = w_EffendDay_F.Value

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Const W_SUBNAME As String = "frmNSC0000HB cmdCancel_Click"

        Try
            '�I����� �ݒ�
            m_EndStatus = False

            '̫����؉��
            Me.Close()

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    'NSCOMMONINFOM�̎{�ݏ����擾
    Private Function DataLoad() As Integer
        Const W_SUBNAME As String = "frmNSC0000HB DataLoad"

        Try
            Dim w_Int As Integer
            Dim w_DataCnt As Integer
            Dim w_Item As String
            Dim w_Sql As String
            Dim w_Rs As ADODB.Recordset
            Dim w_HOSPITALCD_F As ADODB.Field
            Dim w_Name_F As ADODB.Field
            Dim w_SYSFROMDAY_F As ADODB.Field
            Dim w_SYSFROMTERM_F As ADODB.Field
            Dim w_PLANUNIT_F As ADODB.Field
            Dim w_DISPPERIOD_F As ADODB.Field
            Dim w_REGISTFIRSTTIMEDATE_F As ADODB.Field
            Dim w_LASTUPDTIMEDATE_F As ADODB.Field
            Dim w_REGISTRANTID_F As ADODB.Field

            Dim w_strMsg() As String

            'SELECT�� �ҏW
            w_Sql = "SELECT * FROM NS_COMMONINFO_M "
            w_Sql = w_Sql & "ORDER BY HOSPITALCD "
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            '0���ް�����
            If w_Rs.RecordCount > 0 Then

                '*** With �ð���ĊJ�n ***
                With w_Rs

                    '�ް�����
                    .MoveLast()
                    w_DataCnt = .RecordCount
                    .MoveFirst()

                    '̨���޵�޼ު�� ����
                    w_HOSPITALCD_F = .Fields("HOSPITALCD")
                    w_Name_F = .Fields("NAME")
                    w_SYSFROMDAY_F = .Fields("SYSFROMDAY")
                    w_SYSFROMTERM_F = .Fields("SYSFROMTERM")
                    w_PLANUNIT_F = .Fields("PLANUNIT")
                    w_DISPPERIOD_F = .Fields("DISPPERIOD")
                    w_REGISTFIRSTTIMEDATE_F = .Fields("REGISTFIRSTTIMEDATE")
                    w_LASTUPDTIMEDATE_F = .Fields("LASTUPDTIMEDATE")
                    w_REGISTRANTID_F = .Fields("REGISTRANTID")

                    '�{��CD�� �ޔ�z�� �Ē�`
                    ReDim g_Kyotuinf(w_DataCnt)

                    '�ް����� �J��Ԃ�
                    For w_Int = 1 To w_DataCnt

                        '�z��Ɋi�[
                        g_Kyotuinf(w_Int).ByoinCD = w_HOSPITALCD_F.Value
                        g_Kyotuinf(w_Int).Name = General.paGetDbFieldVal(w_Name_F, "")
                        g_Kyotuinf(w_Int).Sysdate = Integer.Parse(General.paGetDbFieldVal(w_SYSFROMDAY_F, 0))
                        g_Kyotuinf(w_Int).Systerm = Integer.Parse(General.paGetDbFieldVal(w_SYSFROMTERM_F, 0))
                        g_Kyotuinf(w_Int).Tani = General.paGetDbFieldVal(w_PLANUNIT_F, "")
                        g_Kyotuinf(w_Int).Hyoji = General.paGetDbFieldVal(w_DISPPERIOD_F, "")
                        g_Kyotuinf(w_Int).Fdate = Long.Parse(General.paGetDbFieldVal(w_REGISTFIRSTTIMEDATE_F, 0))
                        g_Kyotuinf(w_Int).Ldate = Long.Parse(General.paGetDbFieldVal(w_LASTUPDTIMEDATE_F, 0))
                        g_Kyotuinf(w_Int).UserID = General.paGetDbFieldVal(w_REGISTRANTID_F, "")

                        'ؽĕ\�������� �ҏW
                        w_Item = General.paLeft(g_Kyotuinf(w_Int).ByoinCD & Space(2), 2) & Space(1) & g_Kyotuinf(w_Int).Name

                        '���ђǉ�
                        cboHospital.Items.Add(w_Item)

                        '��ں��ނֈړ�
                        .MoveNext()

                    Next w_Int

                    '�h���b�v�_�E���̈�s�ڂ�I��
                    cboHospital.SelectedIndex = 0

                    '����I��
                    DataLoad = True
                    '*** With �ð���ďI�� ***
                End With
            Else
                '0���̏ꍇ
                '�z��̏�����
                ReDim g_Kyotuinf(0)

                '�װү���ޕ\��
                ReDim w_strMsg(1)
                w_strMsg(1) = "�{�ݏ��"
                Call General.paMsgDsp("NS0032", w_strMsg)
                '�ُ�I��
                DataLoad = False
            End If

            '��޼ު�� �폜
            w_Rs.Close()

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    'հ�ް�̼��ї��p��������
    '       �Ζ��Ǘ����т̗��p�����Ȃ��ꍇ(False)
    Private Function AccountChk() As Boolean
        Const W_SUBNAME As String = "frmNSC0000HB AccountChk"

        Try
            Dim w_UserCD As String
            Dim w_HospitalCD As String

            '���p��ID �擾
            w_UserCD = txtUser.Text
            '�{�ݺ��� �擾
            w_HospitalCD = Trim(General.paLeft(cboHospital.Text, 2))

            '�z��̊m��(�����m�F�p�\����(General.Bas�ɒ�`))
            Dim w_ACC(2) As General.Authority_Type
            w_ACC(0).ResID = ""
            w_ACC(1).ResID = "K0001" '�Ζ��v��̗��p��
            w_ACC(2).ResID = "J0001" '���ߋΖ��Ǘ��̗��p��

            '�z��̉��
            System.Array.Clear(w_ACC, 0, w_ACC.Length)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    'հ�ް�����͉�� �I������׸� �擾
    Public ReadOnly Property pEndStatus() As Object
        Get
            pEndStatus = m_EndStatus
        End Get
    End Property
    '�t�H�[�����[�h �I������׸� �擾
    Public ReadOnly Property pLoadStatus() As Object
        Get
            pLoadStatus = m_ErrorFlg
        End Get
    End Property

    Public Sub subFormUnload()
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown

        '[ENTER]�Ή�
        If eventArgs.KeyCode = Keys.Enter Then
            Call cmdOK_Click(cmdOK, New System.EventArgs())
        End If

    End Sub


    Private Sub txtUser_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtUser.KeyDown

        '[ENTER]�Ή�
        If eventArgs.KeyCode = Keys.Enter Then
            Call General.paSetFocus(txtPassword)
        End If

    End Sub

    '�p�X���[�h�ύX��ʂ�\��
    Private Sub cmdPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPassword.Click
        Const W_SUBNAME As String = "frmNSC0000HB cmdPassword_Click"

        Try
            Dim w_UserID As String 'հ�ްID
            Dim w_Password As String = String.Empty '�߽ܰ��
            Dim w_HospitalCD As String '�{�ݺ���
            Dim w_strMsg() As String

            '���͏�� �擾
            w_UserID = txtUser.Text

            '���[�UID���͂���Ă��邩�H
            If Len(w_UserID) = 0 Then
                '�����͂̏ꍇ
                'հ�ްID ���݂��Ȃ�
                ReDim w_strMsg(1)
                w_strMsg(1) = "���͂��ꂽ���O�C���h�c"
                Call General.paMsgDsp("NS0008", w_strMsg)
                Call General.paSetFocus(txtUser)
                Exit Sub
            End If

            '�{�ݺ���/����
            w_HospitalCD = Trim(General.paLeft(cboHospital.Text, 2))

            '���[�UID��������
            If UserChk(w_HospitalCD, w_UserID, w_Password) = False Then
                'հ�ްID ���݂��Ȃ�
                ReDim w_strMsg(1)
                w_strMsg(1) = "���͂��ꂽ���O�C���h�c"
                Call General.paMsgDsp("NS0008", w_strMsg)
                Call General.paSetFocus(txtUser)
                Exit Sub
            End If

            '�߽ܰ�ޕύX
            Call Change_Password(w_UserID, w_HospitalCD, w_Password)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    'Password��ύX���悤�Ƃ���հ��-�����݂��邩�𔻒�
    Private Function UserChk(ByVal p_Hospital As String, ByVal p_User As String, ByRef p_Password As String) As Boolean
        Const W_SUBNAME As String = "frmNSC0000HB UserChk"

        Try
            Dim w_Sql As String = String.Empty
            Dim w_Rs As ADODB.Recordset
            Dim w_Password_F As ADODB.Field
            Dim w_LastUpdDate_F As ADODB.Field

            '������
            m_LastUpdDate = 0

            '-- հ�ޏ��擾 ----------------
            w_Sql = w_Sql & "SELECT "
            w_Sql = w_Sql & "NAME, "
            w_Sql = w_Sql & "PASSWD, "
            w_Sql = w_Sql & "LASTUPDTIMEDATE "
            w_Sql = w_Sql & "FROM NS_USER_M "
            w_Sql = w_Sql & "WHERE NS_USER_M.UserID = '" & p_User & "' "
            w_Sql = w_Sql & "  AND NS_USER_M.HospitalCD = '" & p_Hospital & "' "

            'RecordSet ��޼ު�Ă̍쐬(�Q�Ƃ̂�)
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            '0���ް�����
            If w_Rs.RecordCount = 0 Then
                '0���̂Ƃ�հ�ްID���݂��Ȃ�
                p_Password = ""
                UserChk = False
            Else
                '̨���ޒ�`
                w_Password_F = w_Rs.Fields("PASSWD")
                w_LastUpdDate_F = w_Rs.Fields("LASTUPDTIMEDATE")

                'Password�擾
                p_Password = General.paGetDbFieldVal(w_Password_F, "")
                '�ŏI�X�V���t
                m_LastUpdDate = Long.Parse(General.paGetDbFieldVal(w_LastUpdDate_F, 0))

                '����I��
                UserChk = True
            End If

            w_Rs.Close()

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    '�p�X���[�h�ύX��ʂ�\��
    Private Function Change_Password(ByVal p_UserID As String, ByVal p_Hospital As String, ByVal p_Password As String) As Boolean
        Const W_SUBNAME As String = "frmNSC0000HB Change_Password"

        Try
            Dim w_Form As frmNSC0000HC = New frmNSC0000HC

            '��޼ު�č쐬/�߽ܰ�ޓ��͉��
            w_Form = New frmNSC0000HC

            'հ�ްID/�{��CD/���߽ܰ�� �ݒ�
            w_Form.pSetData(p_UserID, p_Hospital) = p_Password
            '�ŏI�X�V���t
            w_Form.pLastUpdDate = m_LastUpdDate

            '�߽ܰ�ޓ��͉�� �\��
            w_Form.ShowDialog(Me)

            '̫�ѵ�޼ު�� �폜
            w_Form = Nothing

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

End Class