Option Strict Off
Option Explicit On

Module BasNSC0000H
	'/----------------------------------------------------------------------/
	'/
	'/    ���і��́F���ʃR���|�[�l���g
	'/        ��ʁF���ʃR���|�[�l���g
	'/        �h�c�FNSC0000H
	'/
	'/
	'/      �쐬�ҁF        CREATE 2006/03/01          REV 01.00
	'/      �X�V�ҁF M.Isida       2008/11/17          �yP-00812�z
    '/      �X�V�ҁF M.N           2008/11/27          �yP-00866�z
	'/      �X�V�ҁF T.Okamoto     2008/12/02          �yP-00853�z
	'/      �X�V�ҁF T.Okamoto     2008/12/02          �yPRE-0279�z
	'/      �X�V�ҁF T.Okamoto     2008/12/16          �yP-00990�z
	'/      �X�V�ҁF T.Okamoto     2008/12/19          �yP-01026�z
	'/      �X�V�ҁF M.N           2008/12/24          �yP-01076�z
	'/      �X�V�ҁF T.Okamoto     2008/12/25          �yP-01065�z
	'/      �X�V�ҁF M.I           2009/01/15          �yP-01151�z
	'/      �X�V�ҁF M.I           2009/01/28          �yP-01310�z
	'/      �X�V�ҁF okamura       2009/04/02          �yP-01573�z
	'/      �X�V�ҁF M.N           2009/06/05          �yPKG-0124�z
	'/      �X�V�ҁF M.I           2009/06/05          �yPKG-0148�z
	'/      �X�V�ҁF M.N           2009/06/09          �yPKG-0220�z
	'/      �X�V�ҁF M.N           2009/06/09          �yPRE-0641�z
	'/      �X�V�ҁF E.S           2009/06/10          �yPRE-0098�z
	'/      �X�V�ҁF M.I           2009/06/11          �yPRE-0129�z
	'/      �X�V�ҁF M.N           2009/06/12          �yPKG-0127�z
	'/      �X�V�ҁF M.N           2009/06/13          �yPKG-0089�z
	'/      �X�V�ҁF E.S           2009/06/16          �yPKG-0162�z
	'/      �X�V�ҁF E.S           2009/06/17          �yPKG-0147�z
	'/      �X�V�ҁF M.N           2009/06/23          �yPRE-0761�z
	'/      �X�V�ҁF M.N           2009/06/25          �yPRE-0772�z
	'/      �X�V�ҁF M.N           2009/06/25          �yPRE-0750�z
	'/      �X�V�ҁF M.N           2009/06/26          �yPRE-0808�z
	'/      �X�V�ҁF M.N           2009/07/02          �yPRE-0843�z
	'/      �X�V�ҁF M.N           2009/07/02          �yPRE-0883�z
	'/      �X�V�ҁF M.I           2009/07/13          �yPRE-0914�z
	'/      �X�V�ҁF E.S           2009/07/13          �yP-02019�z
	'/      �X�V�ҁF E.S           2009/11/16          �yP-02354�z
	'/      �X�V�ҁF                   /  /
	'/
	'/                        �X�V���e�F
	'/     Copyright (C) Inter co.,ltd 1997
	'/----------------------------------------------------------------------/
	
	'�萔
	Public Const G_PROJECTID As String = "NSC0000H"
	
	Public Const G_OBJECTKBN_EXE As String = "1" 'EXE
	Public Const G_OBJECTKBN_DLL As String = "2" 'DLL
	Public Const G_OBJECTKBN_FORM As String = "3" '�t�H�[��
	Public Const G_OBJECTKBN_OTHER As String = "9" '���̑�
	
	Public Const G_PACKAGENAME_MED As String = "MedWorks"
	Public Const G_PACKAGENAME_NSAID As String = "NurseAid"
	
	'�׽��޼ު�Đ錾
	Public g_ClsMain As New clsMainForm '������ʸ׽��޼ު��
	
	Public g_Kyotuinf() As NS001CD_Type '�{�ݏ��z��
	Public g_HolidayM() As Holiday_Type '�x���}�X�^���
	Public g_KinmuM() As KinmuM_Type '�Ζ��}�X�^���i���ׂāj
	Public g_MenuM() As Menu_Type '���j���[�}�X�^
	
    Public g_strSelWardDeptCD As String
	Public g_strSelWardDeptNm As String
	Public g_strSelPostCD As String
	Public g_strSelPostNm As String
	Public g_strSelJobCD As String
	Public g_strSelJobNm As String
	
    Public g_strSelSaikeiFlg As String
	
	
	'==========================
	'�\����:���ʏ��}�X�^
	'==========================
	Public Structure NS001CD_Type
		Dim ByoinCD As String '�{�ݺ���
		Dim Name As String '�{�ݖ���
		Dim Sysdate As Integer '���ъJ�n��
        Dim Systerm As Integer '���ъJ�n���
        Dim Tani As String '�v��P��
        Dim Hyoji As String '�\������
        Dim Fdate As Long 'RegistFirstTimeDate
        Dim Ldate As Long 'LastUpdTimeDate
        Dim UserID As String 'RegistrantID
    End Structure

    '==========================
    '�\���́F�x���}�X�^
    '==========================
    Public Structure Holiday_Type
        Dim lngDate As Integer
        Dim strName As String
        Dim strHolKbn As String
    End Structure

    '==========================
    '�\���́F�Ζ��}�X�^�i�S�āj
    '==========================
    Public Structure KinmuM_Type
        Dim strCD As String '�R�[�h
        Dim strName As String '����
        Dim strMark As String '�L��
        Dim lngDispNo As Integer '�\����
        Dim strKinmuKbn As String '�Ζ��敪�@1�F�Ζ��@2�F�Ζ��ȊO
        Dim strKinmuBunruiCD As String '�Ζ����ށ@1�F�Ζ��@2�F�x�݁@3�F����
        Dim strGtDaikyuFlg As String '��x�擾�@1�F�\�@2�F�s��
        Dim strGetTimeHolFlg As String '���ԋx�Ɂ@1�F�\�@0�F�s��
        Dim strKinmuGroupCD As String '�Ζ��O���[�v�R�[�h
        Dim strHolBunruiCD As String '�x�ݕ���
        Dim strHalfFlg As String '�S�������@1�F�S���@2�F����
        Dim strAMKinmuCD As String 'AM�Ζ��R�[�h
        Dim strPMKinmuCD As String 'PM�Ζ��R�[�h
    End Structure

    '==========================
    '�\����:���j���[�}�X�^
    '==========================
    Public Structure ListBarMenu_Type
        Dim strResCD As String '���\�[�X�R�[�h
        Dim strTitle As String '�^�C�g��
        Dim strObjNm As String '�I�u�W�F�N�g����
        Dim strObjKbn As String '�I�u�W�F�N�g�敪
        Dim strImageNm As String '�C���[�W����
        Dim strHanyoArea As String '�ėp�G���A
        Dim strHanyoArea2 As String '�ėp�G���A�Q
        Dim strSResCD As String '�Z�L�����e�B���\�[�X�R�[�h
        Dim strUpdAuthRangeKbn As String '�X�V�����͈͋敪
        Dim strRefAuthRangeKbn As String '�Q�ƌ����͈͋敪
    End Structure
    Public Structure Menu_Type
        Dim strMenuID As String '���j���[�h�c
        Dim strMenuNm As String '���j���[����
        Dim strMenuTargetKbn As String '���j���[�Ώۋ敪
        Dim ListBarMenu() As ListBarMenu_Type
    End Structure

    '==========================
    ' �Ζ����ԃf�[�^�p �\���̌Q
    '==========================
    Public Structure typHistoryData
        Dim strCD As String
        Dim lngStartDate As Integer
        Dim lngEndDate As Integer
    End Structure
    Public Structure typCDUnit
        Dim strSaiyouCD As String
        Dim strKangoTaniCD As String
        Dim lngStartDate As Integer
        Dim lngEndDate As Integer
    End Structure
    Public g_udtStaffHistory() As typCDUnit
    Public Structure KinmuTimeDetail
        Dim KinmuCD As String '�Ζ�CD
        Dim Tanka As Integer '�P��
        Dim TodayOff As Integer '�����x���Z�莞��
        Dim NextOff As Integer '�����x���Z�莞��
        Dim Tonight As Integer '������ԎZ�莞��
        Dim NextNight As Integer '������ԎZ�莞��
        Dim FormalTimeFrom As String '���K�Ζ�����FROM�iHHMM�j�i�ݒ肳��Ă��Ȃ��ꍇ�͋󕶎��j
        Dim FormalTimeTo As String '���K�Ζ�����TO�iHHMM�j�i�ݒ肳��Ă��Ȃ��ꍇ�͋󕶎��j
        Dim JituKinmuTime As String '���Ζ����ԁiHHMM�j�i�ݒ肳��Ă��Ȃ��ꍇ�͋󕶎��j
    End Structure
    Public Structure typSanteiTime
        <VBFixedArray(999)> Dim SanteiTime() As KinmuTimeDetail '�Z�莞�Ԏ擾�p �z�� �Ζ����Ԃl�ɒl�������ĂȂ��Ƃ��Ή�

        Public Sub Initialize()
            ReDim SanteiTime(999)
        End Sub
    End Structure
    Public g_udtHistory() As typSanteiTime
    Public g_intAccessLogFlg As Integer
    Public g_intUseNAVIFlg As Integer 'NAVI�g�p = "1"

    Public g_ImagePath As String '�C���[�W�p�X

    '========================
    '����ް�̓y�����j�̐F
    '========================
    Public g_Sat_ForeColor As Integer
    Public g_Sun_ForeColor As Integer
    Public g_Hol_ForeColor As Integer


    Public g_strTargetStaffMngID As String '�ΏېE���̐E���Ǘ��ԍ�
    Public g_lngGroupIdx As Integer '�I�𒆂̃O���[�v�C���f�b�N�X
    Public g_lngListIdx As Integer '�I�𒆂̃��X�g�C���f�b�N�X

    '���p�p�b�P�[�W�^�C�v
    Public Structure UserPackage_Type
        Dim strPackageCD As String '�p�b�P�[�W�R�[�h
        Dim strPackageName As String '�p�b�P�[�W����
        Dim strResourceCD As String '���\�[�X�R�[�h
        Dim strTitle As String '�^�C�g��
        Dim strObjectName As String '�I�u�W�F�N�g��
        Dim strObjectKbn As String '�I�u�W�F�N�g�敪
        Dim strSecuResourceCD As String '�Z�L�����e�B���\�[�X�R�[�h
        Dim strMasterKbn As String '�}�X�^�敪
        Dim strMasterID As String '�}�X�^ID
        Dim strUpdAuthRangeKbn As String '�X�V�����͈͋敪
        Dim strRefAuthRangeKbn As String '�Q�ƌ����͈͋敪
    End Structure
    Public g_UserPackage() As UserPackage_Type

    Public Const g_strNSC2000HA As String = "NSC2000HA" '�������ID

    Public g_strMaxUpdAuthRangeKbn As String '�ő�X�V�����͈͋敪
    Public g_strMaxRefAuthRangeKbn As String '�ő�Q�ƌ����͈͋敪

    Public Const G_ModeAdd As Integer = 1 '�ǉ�
    Public Const G_ModeUpdate As Integer = 2 '�ύX

    Public g_SearchDate As Integer '�������ʂ̊��(����F�폜���ر)

    Public Const G_strSaiyoRes As String = "NSC2000HA01" '�̗p���\�[�X�R�[�h
    Public Const G_strKinmuDeptRes As String = "NSC2000HA02" '�Ζ��������\�[�X�R�[�h
    Public Const G_strWardDeptRes As String = "NSC2000HA03" '�z���������\�[�X�R�[�h
    Public Const G_strPostRes As String = "NSC2000HA04" '��E���\�[�X�R�[�h
    Public Const G_strJobRes As String = "NSC2000HA05" '�E�탊�\�[�X�R�[�h
    Public Const G_strKenmuRes As String = "NSC2000HA06" '�������\�[�X�R�[�h
    Public Const G_strMenkyoRes As String = "NSC2000HA07" '�Ƌ����\�[�X�R�[�h
    Public Const G_strShikakuRes As String = "NSC2000HA08" '���i���\�[�X�R�[�h
    Public Const G_strIinRes As String = "NSC2000HA09" '�ψ����\�[�X�R�[�h
    Public Const G_strSyokurekiRes As String = "NSC2000HA10" '�E�����\�[�X�R�[�h
    Public Const G_strIppanGakurekiRes As String = "NSC2000HA11" '��ʊw�����\�[�X�R�[�h
    Public Const G_strSenmonGakurekiRes As String = "NSC2000HA12" '���w�����\�[�X�R�[�h
    Public Const G_strChoukyuRes As String = "NSC2000HA13" '���x���\�[�X�R�[�h
    Public Const G_strSankyuRes As String = "NSC2000HA14" '�Y�x���\�[�X�R�[�h
    Public Const G_strKyoukaiRes As String = "NSC2000HA15" '����\�[�X�R�[�h
    Public Const G_strKazokuRes As String = "NSC2000HA16" '�Ƒ����\�[�X�R�[�h
    Public Const G_strStudyRes As String = "NSC2000HA17" '���C���\�[�X�R�[�h
    Public Const G_strMyLadderRes As String = "NSC2000HA18" '���ȕ]�����\�[�X�R�[�h
    Public Const G_strOtherLadderRes As String = "NSC2000HA19" '���]�����\�[�X�R�[�h
    Public Structure Master_Type
        Dim strCD As String
        Dim strName As String
        Dim strSecName As String
        Dim strSecName2 As String
        Dim lngDispNo As Integer
    End Structure
    Public g_DutyMaster() As Master_Type
    Public g_ApplMaster() As Master_Type


    Public g_End_Flg As Boolean = False
    Public g_Logoff_Flg As Boolean = False

    '���ʃR���|�[�l���g�̃G���g���|�C���g
    Public Sub Main()
        Const W_SUBNAME As String = "BasNSC0000H Main"

        Try
            Dim w_ClsPassword As New clsPassword 'հ�ް�����͵�޼ު��
            Dim w_RegStr As String
            Dim w_strApStartFlg As String
            Dim w_strHosp As String
            Dim w_RegStrPswDispFlg As String
            Dim w_i As Integer
            Dim w_CommandLine As String
            '��d�N���h�~
            Dim mutex As System.Threading.Mutex = New System.Threading.Mutex(False, "NSC0000H")

            'DB�ڑ�
            Call General.paConnect()

            '�N����� ���� (0:�߽ܰ�ޓ��͉��, 1:�����ƭ����)
            '    w_strApStartFlg = General.paGetItemValue(General.G_StrMainKey1, General.G_StrSubKey1, "APSTARTFLG", "0")
            w_RegStr = General.G_SYSTEM_WIN7 & "\" & General.G_STRMAINKEY1
            w_strHosp = General.paGetSetting(w_RegStr, "Current", "HOSPITALCD", "")

            If w_strHosp = "" Then
                w_strHosp = "01"
            End If

            w_strApStartFlg = General.paGetItemValue(General.G_STRMAINKEY1, General.G_STRSUBKEY1, "APSTARTFLG", "0", w_strHosp)

            w_RegStrPswDispFlg = General.paGetSetting(General.G_SYSTEM_WIN7, General.G_STRMAINKEY1, "PSWDISPFLG", "0")

            '�~���[�e�b�N�X�̏��L����v������
            If mutex.WaitOne(0, False) = False Then
                '���łɋN�����Ă���Ɣ��f���ďI��
                End
            End If

            Try
                'DB�����̎�ʂ��擾����
                General.g_InstallType = Integer.Parse(General.paGetIniSetting(General.G_STRININAME, General.G_STRSECTION1, "InstallType", Convert.ToString(General.BasGeneral.gInstall_Enum.AccessType_PassThrough)))

                '===========================================
                '���i�I�u�W�F�N�g����
                '===========================================
                '�Z�L�����e�B�}�X�^���i
                General.g_objSecurity = New NsAid_NSC0000C.clsGetSecurity
                '�E���擾���i
                General.g_objGetData = New NsAid_NSC0010C.clsStaffData
                '�J�����_�[���i
                General.g_objSelectDate = New NsAid_NSC0030C.clsNusDate
                '�E���|�b�v�A�b�v
                General.g_objSelectStaff = New NsAid_NSC0040C.clsStaffPopUp
                '�}�X�^�擾���i
                General.g_objGetMaster = New NsAid_NSC0050C.clsGetMaster
                '�ٓ����擾���i
                General.g_objIdoData = New NsAid_NSC0060C.clsStaffIdo
                '�Ζ������|�b�v�A�b�v ���i
                General.g_objSelectDept = New NsAid_NSC0070C.clsDeptPopUp
                '���F�֘A���i
                General.g_objSyouninData = New NsAid_NSA0000C.clsAppliApprove
                '���ԊO�擾���i
                General.g_objComCyokin = New NsAid_NSW0000C.clsGetOverData
                '�������O���[�v�擾���i
                General.g_objDutyGroup = New NsAid_NSD0000C.clsGetDutyGroup
                '���ԊO�擾���i�i�J��@�Ή��j
                General.g_objWorkBaseInfo = New NsAid_NSW0300C.clsGetOverData

                '�V�X�e����~�����ǂ������f
                If General.CheckSystemStop() = False Then
                    '�V�X�e����~���Ȃ�DB�ڑ���ؒf���ăA�v���P�[�V�������I��������
                    Call General.paDisConnect()
                    '���i�I�u�W�F�N�g���
                    General.g_objSecurity = Nothing
                    General.g_objGetData = Nothing
                    General.g_objSelectDate = Nothing
                    General.g_objGetMaster = Nothing
                    General.g_objIdoData = Nothing
                    General.g_objSelectDept = Nothing
                    General.g_objSyouninData = Nothing
                    General.g_objComCyokin = Nothing
                    General.g_objDutyGroup = Nothing
                    General.g_objWorkBaseInfo = Nothing

                    '--- Ap�I�� ---
                    End
                End If

                '���W�X�g���p�X
                w_RegStr = General.G_SYSTEM_WIN7 & "\" & General.G_STRMAINKEY1

                '�N����� ���� (0:�߽ܰ�ޓ��͉��, 1:�����ƭ����)
                '    If w_strApStartFlg = "1" Then
                If w_strApStartFlg = "1" Or w_RegStrPswDispFlg = "1" Then
                    '�߽ܰ�މ�ʂ�\�������ɏ�����ʕ\��

                    '�����`���@�\�ǉ�
                    If Command() <> "" Then
                        w_CommandLine = Command()
                        '��1����(���p��ID)
                        For w_i = 1 To Len(w_CommandLine)
                            If Mid(w_CommandLine, w_i, 1) = " " Then
                                General.g_LanchUser = Mid(w_CommandLine, 1, w_i - 1)
                                w_CommandLine = Mid(w_CommandLine, w_i + 1, Len(w_CommandLine) - w_i)
                                Exit For
                            End If
                        Next w_i

                        '��2����(�߽ܰ��)
                        General.g_LanchPassword = Mid(w_CommandLine, 1, Len(w_CommandLine))

                        '�����`���N��ON
                        General.g_LuncherFlg = True

                        '�߽ܰ�މ�ʂ̕\��
                        w_ClsPassword.mShowWindow()

                        If General.g_ErrCheck = False Then
                            Call General.paDisConnect()
                            End
                        End If
                    End If

                    '�׽�����è�ɕK�v���ް���ݒ�
                    '���p��ID
                    General.g_strUserID = General.paGetSetting(w_RegStr, "Current", "USERID", "")
                    '���p�Җ�
                    General.g_strUserName = General.paGetSetting(w_RegStr, "Current", "USERNAME", "")
                    '���p�҃O���[�v�R�[�h
                    General.g_strUserGroupCD = General.paGetSetting(w_RegStr, "Current", "USERGROUPCD", "")
                    '���p�ҐE���Ǘ��ԍ�
                    General.g_strUserMngID = General.paGetSetting(w_RegStr, "Current", "USERMNGID", "")
                    '���p�ҏ����Ζ�����CD
                    General.g_strUserKinmuDeptCD = General.paGetSetting(w_RegStr, "Current", "USERKINMUDEPTCD", "")
                    '���p�ҏ����Ζ���������
                    General.g_strUserKinmuDeptNm = General.paGetSetting(w_RegStr, "Current", "USERKINMUDEPTNM", "")
                    '�{��CD
                    General.g_strHospitalCD = General.paGetSetting(w_RegStr, "Current", "HOSPITALCD", "")
                    '�{�ݖ���
                    General.g_strHospitalNm = General.paGetSetting(w_RegStr, "Current", "HOSPITALNM", "")
                    '�I���Ζ�����CD
                    General.g_strSelKinmuDeptCD = General.paGetSetting(w_RegStr, "Current", "KINMUDEPTCD", "")
                    '�I���Ζ���������
                    General.g_strSelKinmuDeptNm = General.paGetSetting(w_RegStr, "Current", "KINMUDEPTNM", "")

                    '�Z�L�����e�B�}�X�^���i
                    With General.g_objSecurity
                        .pHospitalCD = General.g_strHospitalCD '�{�݃R�[�h
                        .pUserID = General.g_strUserID '���p�҃R�[�h
                        .pUserStaffMngID = General.g_strUserMngID '���p�ҐE���Ǘ��ԍ�
                        .pGroupCD = General.g_strUserGroupCD '���p�҃O���[�v�R�[�h
                        .pUserKinmuDeptCD = General.g_strUserKinmuDeptCD '���p�ҏ��������R�[�h
                        .pGetMasterObj = General.g_objGetMaster '�}�X�^�擾���i

                        '��������ь������Ă���Ζ������R�[�h�̋Ζ������}�X�^�����擾����
                        If .mGetUserKinmuDeptInfo(General.paGetDateStringFromDate(Now, General.G_DATE_ENUM.yyyyMMdd)) = False Then

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
                        w_ClsPassword.pEndStatus(False) = False
                    Else
                        '�߽ܰ�މ�ʏI����Ԃ�True��
                        w_ClsPassword.pEndStatus(True) = True
                    End If

                Else
                    '�߽ܰ�މ�ʂ̕\��
                    w_ClsPassword.mShowWindow()
                End If

                '�E���擾���i(NSC0010C)
                General.g_objGetData.p�a�@CD = General.g_strHospitalCD

                '�}�X�^�擾���i(NSC0050C)
                General.g_objGetMaster.pHospitalCD = General.g_strHospitalCD

                '�ٓ����擾���i(NSC0060C)
                General.g_objIdoData.pHospitalCD = General.g_strHospitalCD

                '�Ζ������|�b�v�A�b�v ���i(NSC0070C)
                General.g_objSelectDept.pHospitalCD = General.g_strHospitalCD
                General.g_objSelectDept.pGetMasterObj = General.g_objGetMaster

                '�E���|�b�v�A�b�v���i(NSC0040C)
                General.g_objSelectStaff.pHospitalCD = General.g_strHospitalCD
                General.g_objSelectStaff.pGetMasterObj = General.g_objGetMaster
                General.g_objSelectStaff.pSelectDeptObj = General.g_objSelectDept
                General.g_objSelectStaff.pGetDataObj = General.g_objGetData

                '�J�����_�[���i(NSC0030C)
                With General.g_objSelectDate
                    '�����ݒ���s��
                    .LetMaxDate = General.G_DEFAULT_MAX_DATE '�\���\�ő���t(YYYYMMDD�E�ȗ���)
                    .LetMinDate = General.G_DEFAULT_MIN_DATE '�\���\�ŏ����t(YYYYMMDD�E�ȗ���)
                    .letdefaultdate = General.paGetDateIntegerFromDate(Now) '�����\�����t(YYYYMMDD�E�ȗ���)
                    .LetHospitalCode = General.g_strHospitalCD '�a�@CD��ݒ�
                    .LetNurseAidFLG(True) = vbNullString 'NurseAID��NSHOLIDAYM���Q�Ƃ��邩�ǂ����̐ݒ�
                    .LetHolidayDataType = False '�j�����t�@�C������ǂݍ��ނ��ǂ���
                End With

                '���ԊO�擾���i(NSW0000C)
                General.g_objComCyokin.p�a�@CD = General.g_strHospitalCD
                General.g_objComCyokin.pGetDataObj = General.g_objGetData

                '���ԊO�擾���i�i�J��@�Ή��j(NSW0300C)
                General.g_objWorkBaseInfo.p�a�@CD = General.g_strHospitalCD
                General.g_objWorkBaseInfo.pGetDataObj = General.g_objGetData
                General.g_objWorkBaseInfo.pGetCyokinObj = General.g_objComCyokin

                '�߽ܰ�މ�ʂ̏I����Ԃ��擾
                If w_ClsPassword.pEndStatus = True Then
                    'True�Ȃ�Ώ�����ʋN��
                    g_ClsMain.mShowMainWindow()
                Else

                    Call General.paDisConnect()
                End If

                If g_Logoff_Flg Then
                    g_Logoff_Flg = False
                    Call Main()
                End If
            Finally
                '�~���[�e�b�N�X���������
                mutex.ReleaseMutex()
            End Try

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    '���X�g�o�[���j���[ �擾
    Public Function fncListBarMenu() As Boolean
        Const W_SUBNAME As String = "BasMain fncListBarMenu"

        Try
            Dim w_lngMenuCnt As Integer
            Dim w_lngLoop As Integer
            Dim w_lngLoop2 As Integer
            Dim w_strResCD As String
            Dim w_strPreResCD As String '���\�[�X�R�[�h�ޔ�p
            Dim w_lngGroupIdx As Integer
            Dim w_lngListIdx As Integer
            Dim w_lngDefListIdx As Integer
            Dim w_lngResorceCnt As Integer

            '������
            'ReDim g_MenuM(0)
            ReDim g_MenuM(0)
            ReDim g_MenuM(0).ListBarMenu(0)
            w_strPreResCD = ""

            g_lngGroupIdx = 0
            g_lngListIdx = 0

            '�Z�L�����e�B���i�@���X�g�o�[���j���[�擾
            With General.g_objSecurity
                If .mGetListBarMenu = False Then
                    fncListBarMenu = False
                Else
                    '�g�p�\�ȃ��j���[�h�c�̐�
                    w_lngMenuCnt = .fLB_MenuCount
                    '�f�t�H���g�ŕ\�����郁�j���[��INDEX
                    g_lngGroupIdx = .fLB_MenuDefIdx

                    w_lngDefListIdx = .fLB_MenuDataDefIdx '���ӁF�����\�[�X�R�[�h�ɑ΂��ăp�b�P�[�W�R�[�h�Ⴂ�ŕ�������ꍇ�����邽�߁A���X�g�C���f�b�N�X�����̂܂܂̐����ł͎g�p�ł��Ȃ��ꍇ������

                    For w_lngLoop = 1 To w_lngMenuCnt

                        .mLB_MenuIdx = w_lngLoop

                        '���X�g���j���[�����擾
                        w_lngResorceCnt = .fLB_ResourceCount

                        '���X�g���j���[���P�����Ȃ��ꍇ�͔z��쐬���Ȃ�
                        If w_lngResorceCnt > 0 Then

                            w_lngGroupIdx = UBound(g_MenuM) + 1
                            ReDim Preserve g_MenuM(w_lngGroupIdx)
                            '���X�g���j���[�z�񏉊���
                            ReDim g_MenuM(w_lngGroupIdx).ListBarMenu(0)

                            '�����j���[ID
                            g_MenuM(w_lngGroupIdx).strMenuID = .fLB_MenuID
                            '�����j���[����
                            g_MenuM(w_lngGroupIdx).strMenuNm = .fLB_MenuNm
                            '�����j���[�Ώۋ敪
                            g_MenuM(w_lngGroupIdx).strMenuTargetKbn = .fLB_MenuTargetKbn

                            For w_lngLoop2 = 1 To w_lngResorceCnt
                                .mLB_ResourceIdx = w_lngLoop2

                                '�����\�[�X�R�[�h
                                w_strResCD = .fLB_ResourceCD

                                If w_strPreResCD <> .fLB_ResourceCD Then
                                    w_lngListIdx = UBound(g_MenuM(w_lngGroupIdx).ListBarMenu) + 1
                                    ReDim Preserve g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx)

                                    '�����l���X�g�C���f�b�N�X
                                    If w_lngLoop = g_lngGroupIdx And w_lngLoop2 = w_lngDefListIdx Then
                                        g_lngListIdx = w_lngListIdx
                                    End If

                                    '�����\�[�X�R�[�h
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strResCD = w_strResCD
                                    '���^�C�g��
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strTitle = .fLB_Title
                                    '���I�u�W�F�N�g����
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strObjNm = .fLB_ObjectNm
                                    '���I�u�W�F�N�g�敪
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strObjKbn = .fLB_ObjectKbn
                                    '���Z�L�����e�B���\�[�X�R�[�h
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strSResCD = .fLB_SecuResourceCD
                                    '���X�V�����͈͋敪
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strUpdAuthRangeKbn = .fLB_UpdAuthRangeKbn
                                    '���Q�ƌ����͈͋敪
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strRefAuthRangeKbn = .fLB_RefAuthRangeKbn
                                End If

                                '�ޔ�
                                w_strPreResCD = w_strResCD

                            Next w_lngLoop2
                        End If
                    Next w_lngLoop

                    '�f�t�H���g���j���[�Ɍ������Ȃ��ꍇ�̑Ή�
                    '�f�t�H���g���j���[���Ȃ��ꍇ�A�����I�ɖ{�l����I��
                    If g_lngGroupIdx = 0 And g_lngListIdx = 0 Then
                        g_lngGroupIdx = 1
                        g_lngListIdx = 1
                    End If

                End If
            End With

            '����I��
            fncListBarMenu = True

        Catch ex As Exception
            Call General.paTrpMsg(Convert.ToString(Err.Number), W_SUBNAME)
        End Try
    End Function


    '=======================================================================
    '  �N���v���Z�X�̃`�F�b�N
    '=======================================================================
    Public Function GetProcesses() As Object

        Dim Proc As Object
        Dim w_str As String

        GetProcesses = True
        Try
            w_str = ""
            With GetObject("winmgmts:")
                For Each Proc In .instancesof("win32_process")
                    w_str = Format(Proc.Caption)
                    '            If w_str = "NSK0000H.exe" Or w_str = "NSC0080H.exe" Or w_str = "NSC1000H.exe" Or w_str = "NSC2000H.exe" Then
                    If w_str = "NSK0000H.exe" Or w_str = "NSC0080H.exe" Or w_str = "NSC1000H.exe" Then
                        GetProcesses = False
                    End If
                    w_str = ""
                Next Proc
            End With
        Catch ex As Exception

        End Try
    End Function




    '�I�𕔏��R�[�h�������l�Ƃ��邪�A
    '�Ώۓ����_�̋Ζ������R�[�h�ɕϊ�����
    Public Function funcChangeDeptCD(ByVal p_strMngID As String, ByVal p_lngDate As Integer, ByRef p_strDeptCD As String, ByRef p_strDeptName As String) As Boolean

        Const W_SUBNAME As String = "BasNSC0000H funcChangeDeptCD"

        Dim w_strDefDeptCD As String
        Dim w_strDefDeptName As String

        funcChangeDeptCD = False
        Try
            '    General.g_strHospitalCD
            '    g_strStaffMngID
            '    g_lngSelectDate
            '    General.g_strSelKinmuDeptCD
            '    General.g_strSelKinmuDeptNm

            w_strDefDeptCD = General.g_strSelKinmuDeptCD
            w_strDefDeptName = General.g_strSelKinmuDeptNm

            With General.g_objIdoData

                .pHospitalCD = General.g_strHospitalCD '�{�݃R�[�h
                .pStaffMngID = p_strMngID '�E���Ǘ��ԍ�
                .pDateFlg = 0 '���t�敪(�P���)
                .pDateFrom = p_lngDate '�J�n�N����
                .pDateTo = 0 '�I���N����
                .pSortFlg = 1 '�\�[�g��(�~��)

                If .mGetKinmuDeptIdo() = False Then

                    '�����l�̂܂�
                    p_strDeptCD = w_strDefDeptCD
                    p_strDeptName = w_strDefDeptName
                    Exit Function
                Else

                    '�P����w��Ȃ̂ŁA�Q���ȏ�͎擾����Ȃ�
                    If .fKI_KinmuDeptCount < 1 Then

                        '�����l�̂܂�
                        p_strDeptCD = w_strDefDeptCD
                        p_strDeptName = w_strDefDeptName
                        Exit Function
                    End If

                    .mKI_KinmuDeptIdx = 1

                    p_strDeptCD = .fKI_CD
                    p_strDeptName = .fKI_Name

                End If

            End With

            funcChangeDeptCD = True

        Catch ex As Exception
            Call General.paTrpMsg(Convert.ToString(Err.Number), W_SUBNAME)
        End Try
    End Function
End Module