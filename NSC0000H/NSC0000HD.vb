Option Strict Off
Option Explicit On

Friend Class frmNSC0000HD
    Inherits General.FormBase

	Private m_strStartMode As String '�v���ʕ\�����[�h
    Private m_LoadOKFlg As Boolean = True
	Private m_OKCancelFlg As Boolean
	Private m_SelectPlanNo As Integer
	
	Private m_DateNow As Date
    Private m_AfterDataShow As Integer '��\������
    Private m_BeforeDataShow As Integer '�O�\������
    Private m_DefSelect As Integer '��������̑��Βl

    Private m_UserID As String '20070817 iwasaki add

    Private Structure HospitalInf
        Dim SystemStartDate As Integer
        Dim SystemStartTarm As Integer
        Dim SystemViewType As String
    End Structure
    Private m_HospitalData As HospitalInf

    Private Structure KeikakuCtrl_Type
        Dim PlanNo As Integer '�v��ԍ�
        Dim TarmNo As Integer '���
        Dim PlanStart As Integer '�v����ԊJ�n��
        Dim PlanEnd As Integer '�v����ԏI����
        Dim LimitDay As Integer '���ؓ�
        Dim LimitDay_R As Integer '���ђ��ؓ�
        Dim LimitDay_H As Integer '��]���ؓ�
        Dim DataFlg As Boolean '�f�[�^�̗L���iTrue:�f�[�^����CFalse:�f�[�^�Ȃ��j
        Dim UpdateFlg As Boolean '�f�[�^�X�V�̗L���iTrue:�X�V�CFalse:���X�V�j
    End Structure
    Private m_KeikakuCtrlData() As KeikakuCtrl_Type

    Private m_KeikakuCtrlIndex() As Integer

    Public ReadOnly Property pLoadOK() As Boolean
        Get
            pLoadOK = m_LoadOKFlg
        End Get
    End Property


    '==================================
    '�I���X�e�[�^�X
    '==================================
    Public ReadOnly Property pEndStatus() As Boolean
        Get
            pEndStatus = m_OKCancelFlg
        End Get
    End Property

    Public ReadOnly Property pPlanNo() As Integer
        Get
            pPlanNo = m_SelectPlanNo
        End Get
    End Property

    '�v���ʕ\�����[�h
    Public WriteOnly Property pMode() As String
        Set(ByVal Value As String)
            m_strStartMode = Value
        End Set
    End Property

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Const W_SUBNAME As String = "NSC0000HD cmdOK_Click"
        Try
            Dim w_DataIndex As Integer
            Dim w_strMsg() As String


            '�I����Ԏ擾
            If cmbKikan.SelectedIndex = -1 Then
                '���I��
                ReDim w_strMsg(1)
                w_strMsg(1) = "�v�����"
                Call General.paMsgDsp("NS0002", w_strMsg)
                cmbKikan.Focus()
                Exit Sub
            End If

            '�I�����Ԃ̌v��ԍ��擾
            w_DataIndex = m_KeikakuCtrlIndex(cmbKikan.SelectedIndex)
            m_SelectPlanNo = m_KeikakuCtrlData(w_DataIndex).PlanNo

            'OK���݉����i�v���ʋN���j
            m_OKCancelFlg = True


            Me.Close()

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub


    Private Sub Update_LimitDay()
        Const W_SUBNAME As String = "NSC0000HD Update_LimitDay"

        Try
            Dim w_Sql As String
            Dim w_NowDate As String
            Dim w_Loop As Integer
            Dim w_Count As Integer

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'LastUpdTimeDate�p
            w_NowDate = Format(Now, "yyyyMMddHHmm")

            '��ݻ޸��݊J�n
            Call General.paBeginTrans()

            '�ް�������Loop
            w_Count = UBound(m_KeikakuCtrlData)
            For w_Loop = 1 To w_Count

                '�X�V�Ώۂ��H
                If m_KeikakuCtrlData(w_Loop).UpdateFlg = True Then
                    w_Sql = "UPDATE NS_PLANCONTROL_F SET"
                    w_Sql = w_Sql & " PLANDUEDATE = " & Convert.ToString(m_KeikakuCtrlData(w_Loop).LimitDay)
                    w_Sql = w_Sql & ", RESULTDUEDATE = " & Convert.ToString(m_KeikakuCtrlData(w_Loop).LimitDay_R)
                    w_Sql = w_Sql & ", HOPEDUEDATE = " & Convert.ToString(m_KeikakuCtrlData(w_Loop).LimitDay_H)
                    w_Sql = w_Sql & ", LASTUPDTIMEDATE = " & w_NowDate
                    w_Sql = w_Sql & ", REGISTRANTID = '" & m_UserID & "'"
                    w_Sql = w_Sql & " WHERE PLANNO = " & Convert.ToString(m_KeikakuCtrlData(w_Loop).PlanNo)
                    w_Sql = w_Sql & " AND HOSPITALCD = '" & General.g_strHospitalCD & "'"
                    w_Sql = w_Sql & " "
                    Call General.paDBExecute(w_Sql)
                End If

            Next w_Loop

            '�Я�
            Call General.paCommit()

            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    Private Sub frmNSC0000HD_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Const W_SUBNAME As String = "NSK0000A Form_Load"

        Try
            Dim w_RegKey As String
            Dim w_RtnReg As String
            Dim w_KeyHeader As String
            Dim w_DefAfter As String
            Dim w_DefBefore As String
            Dim w_DefSelect As String
            Dim w_strMsg() As String
            Dim w_FormWidth As Double
            Dim w_ButtonLeft As Double
            Dim w_CancelLeft As Double

            '���ѓ��t�擾
            m_DateNow = Now

            '�{�ݏ��擾
            If Get_HospitalInfData() = False Then
                '�f�[�^�擾�s��
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                ReDim w_strMsg(1)
                w_strMsg(1) = "���ʏ��"
                Call General.paMsgDsp("NS0032", w_strMsg)
                m_LoadOKFlg = False
                Exit Sub
            End If

            '�V�X�e�����t�ƃV�X�e���J�n���̔�r
            If DateDiff(Microsoft.VisualBasic.DateInterval.Day, General.paGetDateFromDateInteger(m_HospitalData.SystemStartDate), m_DateNow) < 0 Then
                '�V�X�e���J�n�����������̏ꍇ
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                ReDim w_strMsg(1)
                w_strMsg(1) = "�V�X�e���J�n��"
                Call General.paMsgDsp("NS0031", w_strMsg)
                m_LoadOKFlg = False
                Exit Sub
            End If

            w_RegKey = General.G_STRININAME
            '�\���v����Ԑ����擾
            If (General.G_PGMSTARTFLG_CHANGEJISSEKI).Equals(m_strStartMode) OrElse (General.G_PGMSTARTFLG_CHANGEPLAN).Equals(m_strStartMode) Then
                w_KeyHeader = "JISSEKI"
                w_DefAfter = "2"
                w_DefBefore = "9"
                w_DefSelect = "0"
                Me.Text = "�Ζ��ύX���Ԏw��"
            Else
                w_KeyHeader = "PLAN"
                w_DefAfter = "3"
                w_DefBefore = "8"
                w_DefSelect = "1"
                Me.Text = "�v����Ԏw��"
            End If
            '���\�����ԁi�f�t�H���g���Ԃ��܂߂Ȃ��l�Ƃ���j
            w_RtnReg = General.paGetItemValue(General.G_STRMAINKEY1, "DISPMONTH", w_KeyHeader & "SHOWAFTER", w_DefAfter, General.g_strHospitalCD)
            If IsNumeric(w_RtnReg) = False Then
                w_RtnReg = w_DefAfter
            End If
            m_AfterDataShow = Integer.Parse(w_RtnReg)
            '�O�\�����ԁi�f�t�H���g���Ԃ��܂߂Ȃ��l�Ƃ���j
            w_RtnReg = General.paGetItemValue(General.G_STRMAINKEY1, "DISPMONTH", w_KeyHeader & "SHOWBEFORE", w_DefBefore, General.g_strHospitalCD)
            If IsNumeric(w_RtnReg) = False Then
                w_RtnReg = w_DefBefore
            End If
            m_BeforeDataShow = Integer.Parse(w_RtnReg)
            '�f�t�H���g�I�����ԑ��Έʒu�i��������N�Z����j
            w_RtnReg = General.paGetItemValue(General.G_STRMAINKEY1, "DISPMONTH", w_KeyHeader & "DEFSELECT", w_DefSelect, General.g_strHospitalCD)
            If IsNumeric(w_RtnReg) = False Then
                w_RtnReg = w_DefSelect
            End If
            m_DefSelect = Integer.Parse(w_RtnReg)

            '�����ޯ���Ɍv����Ԃ�ݒ肷��
            Call Get_KeikakuCtrl()

            '=======================================
            '��ʂ̑傫����ݒ肷��
            '=======================================
            '�Ǘ���������ʂ̏ꍇ
            If ("2").Equals(m_HospitalData.SystemViewType) Then
                '�\�����Ԃ��S�T�̏ꍇ
                cmbKikan.Width = General.paTwipsTopixels(4100)
                w_FormWidth = General.paTwipsTopixels(6200)
                Me.SetBounds(0, 0, w_FormWidth, General.paTwipsTopixels(2010))
                w_ButtonLeft = ((Me.ClientRectangle.Width * 15) - ((cmdOK.Width * 15) * 2.5)) / 2
                w_CancelLeft = w_ButtonLeft + ((cmdOK.Width * 15) * 1.5)
            ElseIf ("3").Equals(m_HospitalData.SystemViewType) Then
                '�\�����Ԃ��C�ӂ̏ꍇ
                cmbKikan.Width = General.paTwipsTopixels(2200)
                w_FormWidth = General.paTwipsTopixels(4250)
                Me.SetBounds(0, 0, w_FormWidth, General.paTwipsTopixels(1800))
                w_ButtonLeft = ((Me.ClientRectangle.Width * 15) - ((cmdOK.Width * 15 * 2) + 240)) / 2
                w_CancelLeft = w_ButtonLeft + (cmdOK.Width * 15) + 240
            Else
                '�\�����Ԃ��P�����̏ꍇ
                cmbKikan.Width = General.paTwipsTopixels(2200)
                w_FormWidth = General.paTwipsTopixels(4250)
                Me.SetBounds(0, 0, w_FormWidth, General.paTwipsTopixels(1900))
                w_ButtonLeft = ((Me.ClientRectangle.Width * 15) - ((cmdOK.Width * 15 * 2) + 240)) / 2
                w_CancelLeft = w_ButtonLeft + ((cmdOK.Width * 15) + 240)
            End If

            cmdOK.SetBounds(General.paTwipsTopixels(w_ButtonLeft), General.paTwipsTopixels(900), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
            cmdCancel.SetBounds(General.paTwipsTopixels(w_CancelLeft), General.paTwipsTopixels(900), cmdOK.Width, cmdOK.Height)


            '��ʂ𒆉��\������
            Call General.paDspCenter(Me)

            'Cancel�����ɐݒ�
            m_OKCancelFlg = False

            'Load��������I��
            m_LoadOKFlg = True

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    Private Function Get_HospitalInfData() As Boolean
        Const W_SUBNAME As String = "NSC0000HD Get_HospitalInfData"

        Try
            Dim w_Sql As String
            Dim w_Rs As ADODB.Recordset
            Dim w_StartDate_F As ADODB.Field
            Dim w_Tarm_F As ADODB.Field
            Dim w_ViewType_F As ADODB.Field

            '�G���[�̖߂�l�ݒ�
            Get_HospitalInfData = False

            w_Sql = "SELECT SYSFROMDAY"
            w_Sql = w_Sql & ", SYSFROMTERM"
            w_Sql = w_Sql & ", DISPPERIOD"
            w_Sql = w_Sql & " FROM NS_COMMONINFO_M"
            w_Sql = w_Sql & " WHERE HOSPITALCD = '" & General.g_strHospitalCD & "'"
            w_Sql = w_Sql & " "
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            With w_Rs
                If .RecordCount > 0 Then
                    '�f�[�^����̏ꍇ�i1���̂݁j
                    .MoveFirst()
                    w_StartDate_F = .Fields("SYSFROMDAY")
                    w_Tarm_F = .Fields("SYSFROMTERM")
                    w_ViewType_F = .Fields("DISPPERIOD")
                    m_HospitalData.SystemStartDate = Integer.Parse(General.paGetDbFieldVal(w_StartDate_F, 0))
                    m_HospitalData.SystemStartTarm = Integer.Parse(General.paGetDbFieldVal(w_Tarm_F, 0))
                    m_HospitalData.SystemViewType = w_ViewType_F.Value & ""
                    '�V�X�e���J�n�������킩�H
                    If IsDate(Format(m_HospitalData.SystemStartDate, "0000/00/00")) = True Then
                        '����Ɏ擾�I��
                        Get_HospitalInfData = True
                    End If
                End If
            End With

            w_Rs.Close()
            w_Rs = Nothing

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function


    '=============================
    '�v�搧��e���擾����
    '=============================
    Private Sub Get_KeikakuCtrl()
        Const W_SUBNAME As String = "NSC0000HD Get_KeikakuCtrl"

        Try
            Dim w_Sql As String
            Dim w_Count As Integer
            Dim w_Loop As Integer
            Dim w_NowPlanNo As Integer
            Dim w_DateLong As Integer
            Dim w_ShowPlanNo As Integer
            Dim w_ShowEndPlanNo As Integer
            Dim w_ShowStartPlanNo As Integer
            Dim w_TempInt As Integer
            Dim w_ListIndex As Integer

            'I/F
            Dim w_OrderIF_PlanNo As Integer
            Dim w_OrderIF_Update As Boolean
            Dim w_OrderIF_Data As String

            Dim w_Rs As ADODB.Recordset
            Dim w_PlanNO_F As ADODB.Field
            Dim w_TarmNO_F As ADODB.Field
            Dim w_PlanStart_F As ADODB.Field
            Dim w_PlanEnd_F As ADODB.Field
            Dim w_LimitDay_F As ADODB.Field
            Dim w_RLimitDay_F As ADODB.Field
            Dim w_HLimitDay_F As ADODB.Field

            '���ѓ��t�𐔒l�^�ɕϊ�
            w_DateLong = General.paGetDateIntegerFromDate(m_DateNow, General.G_DATE_ENUM.yyyyMMdd)

            w_Sql = "SELECT PLANNO"
            w_Sql = w_Sql & ", TERM"
            w_Sql = w_Sql & ", PLANPERIODFROM"
            w_Sql = w_Sql & ", PLANPERIODTO"
            w_Sql = w_Sql & ", PLANDUEDATE"
            w_Sql = w_Sql & ", RESULTDUEDATE"
            w_Sql = w_Sql & ", HOPEDUEDATE"
            w_Sql = w_Sql & " FROM NS_PLANCONTROL_F"
            w_Sql = w_Sql & " WHERE HOSPITALCD = '" & General.g_strHospitalCD & "'"
            w_Sql = w_Sql & " ORDER BY PLANNO"
            w_Sql = w_Sql & " "
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            With w_Rs
                If .RecordCount <= 0 Then
                    '�f�[�^����
                    ReDim m_KeikakuCtrlData(0)
                    w_NowPlanNo = -1
                Else
                    '�f�[�^�����݂���ꍇ
                    .MoveLast()
                    w_Count = .RecordCount
                    .MoveFirst()
                    '̨���޵�޼ު�Đ���
                    w_PlanNO_F = .Fields("PLANNO")
                    w_TarmNO_F = .Fields("TERM")
                    w_PlanStart_F = .Fields("PLANPERIODFROM")
                    w_PlanEnd_F = .Fields("PLANPERIODTO")
                    w_LimitDay_F = .Fields("PLANDUEDATE")
                    w_RLimitDay_F = .Fields("RESULTDUEDATE")
                    w_HLimitDay_F = .Fields("HOPEDUEDATE")
                    ReDim m_KeikakuCtrlData(w_Count)
                    w_NowPlanNo = -1 '������
                    For w_Loop = 1 To w_Count
                        m_KeikakuCtrlData(w_Loop).PlanNo = w_PlanNO_F.Value
                        m_KeikakuCtrlData(w_Loop).TarmNo = Integer.Parse(General.paGetDbFieldVal(w_TarmNO_F, 0))
                        m_KeikakuCtrlData(w_Loop).PlanStart = Integer.Parse(General.paGetDbFieldVal(w_PlanStart_F, 0))
                        m_KeikakuCtrlData(w_Loop).PlanEnd = Integer.Parse(General.paGetDbFieldVal(w_PlanEnd_F, 0))
                        m_KeikakuCtrlData(w_Loop).LimitDay = Integer.Parse(General.paGetDbFieldVal(w_LimitDay_F, 0))
                        m_KeikakuCtrlData(w_Loop).LimitDay_R = Integer.Parse(General.paGetDbFieldVal(w_RLimitDay_F, 0))
                        m_KeikakuCtrlData(w_Loop).LimitDay_H = Integer.Parse(General.paGetDbFieldVal(w_HLimitDay_F, 0))
                        m_KeikakuCtrlData(w_Loop).DataFlg = True
                        m_KeikakuCtrlData(w_Loop).UpdateFlg = False
                        If m_KeikakuCtrlData(w_Loop).PlanStart <= w_DateLong AndAlso w_DateLong <= m_KeikakuCtrlData(w_Loop).PlanEnd Then
                            w_NowPlanNo = m_KeikakuCtrlData(w_Loop).PlanNo
                        End If
                        .MoveNext()
                    Next w_Loop
                End If
            End With
            w_Rs.Close()

            If w_NowPlanNo = -1 Then
                '�����܂ł̌v�搧��e���쐬����
                Call CreateKeikakuCtrlData(w_DateLong, w_NowPlanNo)
            End If

            '�f�t�H���g�\������PlanNo���v�Z����
            w_ShowPlanNo = w_NowPlanNo + m_DefSelect
            '�����ޯ���ɐݒ肷���ް��̍ŏ��ƍŏIPlanNo
            w_ShowStartPlanNo = w_ShowPlanNo - m_BeforeDataShow
            w_ShowEndPlanNo = w_ShowPlanNo + m_AfterDataShow

            '�ݒ肷�ׂ�PlanNo���ް������݂��邩�H
            w_Count = UBound(m_KeikakuCtrlData)
            If m_KeikakuCtrlData(w_Count).PlanNo < w_ShowEndPlanNo Then
                '���݂��Ȃ��ꍇ�͍쐬����
                Call CreateKeikakuCtrlData(w_ShowEndPlanNo, w_TempInt)
            End If

            '��ݻ޸��݊J�n
            Call General.paBeginTrans()

            '�����ޯ���ɐݒ肷��
            cmbKikan.Items.Clear()
            w_ListIndex = -1
            w_Count = UBound(m_KeikakuCtrlData)
            w_OrderIF_Update = False

            For w_Loop = 1 To w_Count
                '�\���Ώیv����ԁH

                If w_ShowStartPlanNo <= m_KeikakuCtrlData(w_Loop).PlanNo AndAlso m_KeikakuCtrlData(w_Loop).PlanNo <= w_ShowEndPlanNo Then
                    '�\���Ώیv����Ԃ̏ꍇ

                    '�����ޯ���ɒǉ�
                    cmbKikan.Items.Add(Get_ComboBoxText(w_Loop))

                    ReDim Preserve m_KeikakuCtrlIndex(cmbKikan.Items.Count)
                    m_KeikakuCtrlIndex(cmbKikan.Items.Count - 1) = w_Loop

                    '�I��ListIndex�擾
                    If w_ShowPlanNo = m_KeikakuCtrlData(w_Loop).PlanNo Then
                        w_ListIndex = cmbKikan.Items.Count - 1
                    End If

                End If

                'DB�ɑ��݂��Ȃ��ް����X�V
                If m_KeikakuCtrlData(w_Loop).DataFlg = False Then

                    w_Sql = "INSERT INTO NS_PLANCONTROL_F ("
                    w_Sql = w_Sql & " HOSPITALCD"
                    w_Sql = w_Sql & ", PLANNO"
                    w_Sql = w_Sql & ", TERM"
                    w_Sql = w_Sql & ", PLANPERIODFROM"
                    w_Sql = w_Sql & ", PLANPERIODTO"
                    w_Sql = w_Sql & ", PLANDUEDATE"
                    w_Sql = w_Sql & ", RESULTDUEDATE"
                    w_Sql = w_Sql & ", HOPEDUEDATE"
                    w_Sql = w_Sql & ", REGISTFIRSTTIMEDATE"
                    w_Sql = w_Sql & ", LASTUPDTIMEDATE"
                    w_Sql = w_Sql & ", REGISTRANTID"
                    w_Sql = w_Sql & " ) VALUES ("
                    w_Sql = w_Sql & " '" & General.g_strHospitalCD & "'"
                    w_Sql = w_Sql & ", " & Convert.ToString(m_KeikakuCtrlData(w_Loop).PlanNo)
                    w_Sql = w_Sql & ", " & Convert.ToString(m_KeikakuCtrlData(w_Loop).TarmNo)
                    w_Sql = w_Sql & ", " & Convert.ToString(m_KeikakuCtrlData(w_Loop).PlanStart)
                    w_Sql = w_Sql & ", " & Convert.ToString(m_KeikakuCtrlData(w_Loop).PlanEnd)
                    w_Sql = w_Sql & ", " & Convert.ToString(m_KeikakuCtrlData(w_Loop).LimitDay)
                    w_Sql = w_Sql & ", " & Convert.ToString(m_KeikakuCtrlData(w_Loop).LimitDay_R)
                    w_Sql = w_Sql & ", " & Convert.ToString(m_KeikakuCtrlData(w_Loop).LimitDay_H)
                    w_Sql = w_Sql & ", " & Format(m_DateNow, "yyyyMMddHHmm")
                    w_Sql = w_Sql & ", " & Format(m_DateNow, "yyyyMMddHHmm")
                    w_Sql = w_Sql & ", '" & m_UserID & "'"
                    w_Sql = w_Sql & " )"
                    w_Sql = w_Sql & " "
                    Call General.paDBExecute(w_Sql)

                    If w_OrderIF_PlanNo > m_KeikakuCtrlData(w_Loop).PlanNo OrElse w_OrderIF_PlanNo = 0 Then
                        w_OrderIF_PlanNo = m_KeikakuCtrlData(w_Loop).PlanNo
                    End If
                    w_OrderIF_Update = True

                End If

            Next w_Loop

            '�Я�
            Call General.paCommit()

            '===============================================================
            '   OrderInterFace ����
            '===============================================================
            If General.paGetItemValue(General.G_STRMAINKEY1, General.G_STRSUBKEY2, "NUSIF", "0", General.g_strHospitalCD) = "1" AndAlso w_OrderIF_Update = True Then
                '�Ɩ����S�e�X�V
                w_OrderIF_Data = "0301"
                w_OrderIF_Data = w_OrderIF_Data & General.paLeft(General.g_strHospitalCD & Space(2), 2)
                w_OrderIF_Data = w_OrderIF_Data & Format(w_OrderIF_PlanNo, "000")
                '�d���쐬
                Call General.paOrderInterface_NusIf(w_OrderIF_Data)
            End If

            'ؽĂ���̫�Đݒ�
            If cmbKikan.Items.Count > 0 Then
                cmbKikan.SelectedIndex = w_ListIndex
            End If

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    Private Function Get_ComboBoxText(ByVal pIndex As Integer) As Object
        Const W_SUBNAME As String = "NSC0000HD Get_ComboBoxText"

        Try
            Dim w_Text As String

            w_Text = Space(1)

            '�Ǘ���������ʂ̏ꍇ
            If ("2").Equals(m_HospitalData.SystemViewType) Then
                '�S�T�\���̏ꍇ
                w_Text = w_Text & Format(m_KeikakuCtrlData(pIndex).TarmNo, "00")
                w_Text = w_Text & "��" & Space(1)
                w_Text = w_Text & General.paGetDateStringFromInteger(m_KeikakuCtrlData(pIndex).PlanStart, General.G_DATE_ENUM.yyyy_MM_dd)
                w_Text = w_Text & " �` "
                w_Text = w_Text & General.paGetDateStringFromInteger(m_KeikakuCtrlData(pIndex).PlanEnd, General.G_DATE_ENUM.yyyy_MM_dd)
            ElseIf ("3").Equals(m_HospitalData.SystemViewType) Then
                '�J�n���w��̏ꍇ
                w_Text = w_Text & Format(General.paGetDateFromDateInteger(m_KeikakuCtrlData(pIndex).PlanStart), "yyyy�N MM���x") & Space(1)
            Else
                '�P�����\���̏ꍇ
                w_Text = w_Text & General.paLeft(Convert.ToString(m_KeikakuCtrlData(pIndex).PlanStart), 4)
                w_Text = w_Text & "�N"
                w_Text = w_Text & Format(Integer.Parse(Mid(Convert.ToString(m_KeikakuCtrlData(pIndex).PlanStart), 5, 2)), "00")
                w_Text = w_Text & "��"
            End If

            Get_ComboBoxText = w_Text

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    '*****************************************************************************************
    '   �v�搧��e�̃f�[�^�쐬
    '   ���Ұ��FpStopCreate �쐬������t���͌v��ԍ��i���̈����̒l�܂ō쐬����j
    '         �@pNowPlanNo ���ѓ��t���_�ł̌v��ԍ��i�K�v�ȏꍇ�̂ݐݒ�j
    '*****************************************************************************************
    Private Sub CreateKeikakuCtrlData(ByVal pStopCreate As Integer, ByRef pNowPlanNo As Integer)
        Const W_SUBNAME As String = "NSC0000HD CreateKeikakuCtrlData"

        Try
            Dim w_NowDate As Integer
            Dim w_StopType As Boolean 'True�F�w����t���܂ފ��Ԃ܂ō쐬�CFalse�F�w��v��ԍ��܂ō쐬
            Dim w_StopDate As Integer
            Dim w_StopPlanNo As Integer
            Dim w_StartDate As Date
            Dim w_EndDate As Date
            Dim w_PlanNo As Integer
            Dim w_TramNo As Integer
            Dim w_LimitDate As Integer
            Dim w_MaxIndex As Integer
            Dim w_RegRtn As String
            Dim w_LimitDayFlg As Boolean '
            Dim w_DefLimit As Integer '���ߐ؂���̃f�t�H���g�i�\�����Ԃ�4�T�̏ꍇ�́A�N�Z��(�v����ԊJ�n��)��n���O�A1�����̏ꍇ�͖���n�� Or �N�Z����n���O(ϲŽ�ݒ�)�j
            Dim w_TempLng As Integer
            Dim w_TempDefLimit As Integer
            Dim w_TempBefore As Date
            '���ђ��؂����p�ϐ�
            Dim w_RegRtn2 As String
            Dim w_DefLimit_R As Integer
            Dim w_LimitDate_R As Integer
            Dim w_LimitDayFlg_R As Boolean '
            '��]���؂����p�ϐ�
            Dim w_RegRtn3 As String
            Dim w_DefLimit_H As Integer
            Dim w_LimitDate_H As Integer
            Dim w_LimitDayFlg_H As Boolean

            w_NowDate = General.paGetDateIntegerFromDate(m_DateNow)

            '���ߐ؂���̃f�t�H���g�擾
            w_RegRtn = General.paGetItemValue(General.G_STRMAINKEY3, "DISPMONTH", "DEFPLANLIMIT", "", General.g_strHospitalCD)
            w_RegRtn2 = General.paGetItemValue(General.G_STRMAINKEY3, "DISPMONTH", "DEFRESULTLIMIT", "", General.g_strHospitalCD)
            w_RegRtn3 = General.paGetItemValue(General.G_STRMAINKEY3, "DISPMONTH", "DEFHOPELIMIT", "", General.g_strHospitalCD)
            If IsNumeric(w_RegRtn) = False Then
                '���l�Ƃ��Ĕ��f�ł��Ȃ��ꍇ�͒��ߐ؂���Ȃ�
                w_LimitDayFlg = False
            Else
                w_LimitDayFlg = True
                w_DefLimit = Integer.Parse(w_RegRtn)
            End If
            If IsNumeric(w_RegRtn2) = False Then
                '���l�Ƃ��Ĕ��f�ł��Ȃ��ꍇ�͒��ߐ؂���Ȃ�
                w_LimitDayFlg_R = False
            Else
                w_LimitDayFlg_R = True
                w_DefLimit_R = Integer.Parse(w_RegRtn2)
            End If
            If IsNumeric(w_RegRtn3) = False Then
                '���l�Ƃ��Ĕ��f�ł��Ȃ��ꍇ�͒��ߐ؂���Ȃ�
                w_LimitDayFlg_H = False
            Else
                w_LimitDayFlg_H = True
                w_DefLimit_H = Integer.Parse(w_RegRtn3)
            End If

            '�ő�쐬���t�A�v��ԍ����擾
            If IsDate(Format(pStopCreate, "0000/00/00")) = True Then
                w_StopDate = pStopCreate
                w_StopType = True
            Else
                w_StopPlanNo = Integer.Parse(pStopCreate)
                w_StopType = False
            End If

            '�����f�[�^�̍ő�Index�ԍ�
            w_MaxIndex = UBound(m_KeikakuCtrlData)

            If ("2").Equals(m_HospitalData.SystemViewType) Then
                '�\�����Ԃ��S�T�̏ꍇ

                '�f�[�^�쐬�����ݒ�
                If w_MaxIndex <= 0 Then
                    '�ް����Ȃ��ꍇ�ͼ��ѓ��t
                    w_PlanNo = 0
                    w_StartDate = General.paGetDateFromDateInteger(m_HospitalData.SystemStartDate)
                    w_TramNo = m_HospitalData.SystemStartTarm - 1
                    If w_TramNo < 0 Then
                        w_TramNo = 0
                    End If
                Else
                    w_PlanNo = m_KeikakuCtrlData(w_MaxIndex).PlanNo
                    w_StartDate = Date.Parse(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, General.paGetDateFromDateInteger(m_KeikakuCtrlData(w_MaxIndex).PlanEnd)))
                    w_TramNo = m_KeikakuCtrlData(w_MaxIndex).TarmNo
                End If

                '�ő�쐬���t�A���́A�v��ԍ��܂�Loop����
                Do

                    '�v��ԍ����v�Z����
                    w_PlanNo = w_PlanNo + 1

                    '�v����ԏI�������v�Z����i�S�T�Ȃ̂�28�����j
                    w_EndDate = Date.Parse(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 27, w_StartDate))

                    '��єԍ����v�Z
                    w_TramNo = w_TramNo + 1
                    If w_TramNo > 13 Then
                        w_TramNo = 1
                    End If

                    '���ߐ؂�����v�Z����i�f�t�H���g���Őݒ肷��j
                    w_LimitDate = 0 '������
                    If w_LimitDayFlg = True Then
                        '�S�T�Ȃ̂ł����O�Ƃ��Čv�Z����
                        w_LimitDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1 * w_DefLimit, w_StartDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If
                    w_LimitDate_R = 0
                    If w_LimitDayFlg_R = True Then
                        '���ђ��ؓ���������Ƃ��Čv�Z����
                        w_LimitDate_R = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, w_DefLimit_R, w_EndDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If
                    w_LimitDate_H = 0
                    If w_LimitDayFlg_H = True Then
                        '��]���ؓ��������O�Ƃ��Čv�Z����
                        w_LimitDate_H = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1 * w_DefLimit_H, w_StartDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If

                    '�v�搧���ް��̔z����g������
                    w_MaxIndex = w_MaxIndex + 1
                    ReDim Preserve m_KeikakuCtrlData(w_MaxIndex)
                    '�v�搧���ް����i�[����
                    m_KeikakuCtrlData(w_MaxIndex).PlanNo = w_PlanNo
                    m_KeikakuCtrlData(w_MaxIndex).PlanStart = General.paGetDateIntegerFromDate(w_StartDate)
                    m_KeikakuCtrlData(w_MaxIndex).PlanEnd = General.paGetDateIntegerFromDate(w_EndDate)
                    m_KeikakuCtrlData(w_MaxIndex).TarmNo = w_TramNo
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay = w_LimitDate
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_R = w_LimitDate_R
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_H = w_LimitDate_H
                    m_KeikakuCtrlData(w_MaxIndex).DataFlg = False
                    m_KeikakuCtrlData(w_MaxIndex).UpdateFlg = False

                    '���ѓ��t���_�ł̌v��ԍ���ޔ�
                    If General.paGetDateIntegerFromDate(w_StartDate) <= w_NowDate AndAlso w_NowDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                        pNowPlanNo = w_PlanNo
                    End If

                    '�ő�쐬���t�A���́A�v��ԍ��Ȃ�Loop�����o��
                    If w_StopType = True Then
                        '���t�Ŕ��f����
                        If w_StopDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                            '�ő�쐬���t���܂ރf�[�^�̏ꍇ
                            Exit Do
                        End If
                    Else
                        '�v��ԍ��Ŕ��f����
                        If w_StopPlanNo <= w_PlanNo Then
                            Exit Do
                        End If
                    End If

                    '�v����ԊJ�n�����v�Z����i�v����ԏI�����́{�P���j
                    w_StartDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_EndDate)

                Loop

                '�C�ӂ̏ꍇ
            ElseIf ("3").Equals(m_HospitalData.SystemViewType) Then

                '�f�[�^�쐬�����ݒ�
                If w_MaxIndex <= 0 Then
                    '�ް����Ȃ��ꍇ�ͼ��ѓ��t
                    w_PlanNo = 0
                    w_StartDate = General.paGetDateFromDateInteger(m_HospitalData.SystemStartDate)
                Else
                    w_PlanNo = m_KeikakuCtrlData(w_MaxIndex).PlanNo
                    w_StartDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, General.paGetDateFromDateInteger(m_KeikakuCtrlData(w_MaxIndex).PlanEnd))
                End If

                '�ő�쐬���t�A���́A�v��ԍ��܂�Loop����
                Do

                    '�v��ԍ����v�Z����
                    w_PlanNo = w_PlanNo + 1

                    '�v����ԏI�������v�Z���� ���V�X�e���J�n���t��DD���̑O���܂�
                    '�w�肳�ꂽ���t���A�����ɑ��݂�����t���H
                    w_EndDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, w_PlanNo, General.paGetDateFromDateInteger(m_HospitalData.SystemStartDate))
                    '���������݂�����t�Ȃ�A�O���ɼ��
                    If Format(w_EndDate, "dd").Equals(Format(w_StartDate, "dd")) Then
                        w_EndDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, w_EndDate)
                    End If

                    '���ߐ؂�����v�Z����i�f�t�H���g���Őݒ肷��j
                    w_LimitDate = 0 '������
                    If w_LimitDayFlg = True Then
                        '�����O�Ƃ��Čv�Z����
                        w_LimitDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1 * w_DefLimit, w_StartDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If
                    w_LimitDate_R = 0
                    If w_LimitDayFlg_R = True Then
                        '���ђ��ؓ���������Ƃ��Čv�Z����
                        w_LimitDate_R = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, w_DefLimit_R, w_EndDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If
                    w_LimitDate_H = 0
                    If w_LimitDayFlg_H = True Then
                        '��]���ؓ��������O�Ƃ��Čv�Z����
                        w_LimitDate_H = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1 * w_DefLimit_H, w_StartDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If

                    '�v�搧���ް��̔z����g������
                    w_MaxIndex = w_MaxIndex + 1
                    ReDim Preserve m_KeikakuCtrlData(w_MaxIndex)
                    '�v�搧���ް����i�[����
                    m_KeikakuCtrlData(w_MaxIndex).PlanNo = w_PlanNo
                    m_KeikakuCtrlData(w_MaxIndex).PlanStart = General.paGetDateIntegerFromDate(w_StartDate)
                    m_KeikakuCtrlData(w_MaxIndex).PlanEnd = General.paGetDateIntegerFromDate(w_EndDate)
                    m_KeikakuCtrlData(w_MaxIndex).TarmNo = 0
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay = w_LimitDate
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_R = w_LimitDate_R
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_H = w_LimitDate_H
                    m_KeikakuCtrlData(w_MaxIndex).DataFlg = False
                    m_KeikakuCtrlData(w_MaxIndex).UpdateFlg = False

                    '���ѓ��t���_�ł̌v��ԍ���ޔ�
                    If General.paGetDateIntegerFromDate(w_StartDate) <= w_NowDate AndAlso w_NowDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                        pNowPlanNo = w_PlanNo
                    End If

                    '�ő�쐬���t�A���́A�v��ԍ��Ȃ�Loop�����o��
                    If w_StopType = True Then
                        '���t�Ŕ��f����
                        If w_StopDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                            '�ő�쐬���t���܂ރf�[�^�̏ꍇ
                            Exit Do
                        End If
                    Else
                        '�v��ԍ��Ŕ��f����
                        If w_StopPlanNo <= w_PlanNo Then
                            Exit Do
                        End If
                    End If

                    '�v����ԊJ�n�����v�Z����i�v����ԏI�����́{�P���j
                    w_StartDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_EndDate)

                Loop

            Else
                '�\�����Ԃ��P�����̏ꍇ

                '�f�[�^�쐬�����ݒ�
                If w_MaxIndex <= 0 Then
                    '�ް����Ȃ��ꍇ�ͼ��ѓ��t
                    w_PlanNo = 0
                    w_StartDate = Date.Parse(Format(General.paGetDateFromDateInteger(m_HospitalData.SystemStartDate), "yyyy/MM") & "/01")
                Else
                    w_PlanNo = m_KeikakuCtrlData(w_MaxIndex).PlanNo
                    w_StartDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, General.paGetDateFromDateInteger(m_KeikakuCtrlData(w_MaxIndex).PlanEnd))
                End If

                '�ő�쐬���t�A���́A�v��ԍ��܂�Loop����
                Do

                    '�v��ԍ����v�Z����
                    w_PlanNo = w_PlanNo + 1

                    '�v����ԏI�������v�Z����i�P�����Ȃ̂Ō����j
                    w_EndDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, w_StartDate))

                    '���ߐ؂�����v�Z����i�f�t�H���g���Őݒ肷��j
                    w_LimitDate = 0 '������
                    If w_LimitDayFlg = True AndAlso w_DefLimit <= 31 Then
                        '�P�����Ȃ̂Ŗ������� Or n���O�Ƃ��Čv�Z����
                        If w_DefLimit <= 0 Then
                            'ϲŽ�l�̏ꍇ��n���O�Ƃ��Čv�Z����
                            w_LimitDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, w_DefLimit, w_StartDate))
                        Else
                            '1<=w_DefLimit<=31�̏ꍇ�͖��������Ƃ��Čv�Z����i���������ȊO�ɂ��Ή�����j
                            w_TempDefLimit = w_DefLimit
                            Do
                                w_TempLng = Integer.Parse(Format(w_StartDate, "yyyyMM") & Format(w_TempDefLimit, "00"))
                                If IsDate(Format(w_TempLng, "0000/00/00")) = True Then
                                    Exit Do
                                Else
                                    w_TempDefLimit = w_TempDefLimit - 1
                                    If w_TempDefLimit <= 0 Then
                                        w_TempLng = 999999999
                                        Exit Do
                                    End If
                                End If
                            Loop
                            If w_TempLng < General.paGetDateIntegerFromDate(w_StartDate) Then
                                '�����̓��t�Ōv����ԊJ�n�����ߋ����Ȃ炻�̓�����ߐ؂���Ƃ���i��:16���`15���̂Ōv����ԂŁA10�����ߐ؂���̏ꍇ�j
                                w_LimitDate = w_TempLng
                            Else
                                w_TempBefore = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -1, w_StartDate)
                                w_TempDefLimit = w_DefLimit
                                Do
                                    '��̫�Ē��ߐ؂�������t�Ɣ��f�ł���܂Őݒ肷��i��:��̫�Ē��ߐ؂����30���� 2���̏ꍇ�Ȃǁj
                                    w_TempLng = Integer.Parse(Format(w_TempBefore, "yyyyMM") & Format(w_TempDefLimit, "00"))
                                    If IsDate(Format(w_TempLng, "0000/00/00")) = True Then
                                        Exit Do
                                    Else
                                        w_TempDefLimit = w_TempDefLimit - 1
                                        If w_TempDefLimit <= 0 Then
                                            w_TempLng = 0
                                            Exit Do
                                        End If
                                    End If
                                Loop
                                w_LimitDate = w_TempLng
                            End If
                        End If
                    End If


                    '���ђ��ߐ؂�����v�Z����i�f�t�H���g���Őݒ肷��j
                    w_LimitDate_R = 0 '������
                    If w_LimitDayFlg_R = True AndAlso w_DefLimit_R <= 31 Then
                        '�P�����Ȃ̂Ŗ������� Or n���O�Ƃ��Čv�Z����
                        If w_DefLimit_R <= 0 Then
                            'ϲŽ�l�̏ꍇ��n����Ƃ��Čv�Z����
                            w_LimitDate_R = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1 * w_DefLimit_R, w_EndDate))
                        Else
                            '1<=w_DefLimit<=31�̏ꍇ�͖��������Ƃ��Čv�Z����i���������ȊO�ɂ��Ή�����j
                            w_TempDefLimit = w_DefLimit_R
                            Do
                                w_TempLng = Integer.Parse(Format(w_StartDate, "yyyyMM") & Format(w_TempDefLimit, "00"))
                                If IsDate(Format(w_TempLng, "0000/00/00")) = True Then
                                    Exit Do
                                Else
                                    w_TempDefLimit = w_TempDefLimit - 1
                                    If w_TempDefLimit <= 0 Then
                                        w_TempLng = 999999999
                                        Exit Do
                                    End If
                                End If
                            Loop
                            If w_TempLng < General.paGetDateIntegerFromDate(w_StartDate) Then
                                '�����̓��t�Ōv����ԊJ�n�����ߋ����Ȃ炻�̓�����ߐ؂���Ƃ���i��:16���`15���̂Ōv����ԂŁA10�����ߐ؂���̏ꍇ�j
                                w_LimitDate = w_TempLng
                            Else
                                w_TempBefore = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, w_StartDate)
                                w_TempDefLimit = w_DefLimit_R
                                Do
                                    '��̫�Ē��ߐ؂�������t�Ɣ��f�ł���܂Őݒ肷��i��:��̫�Ē��ߐ؂����30���� 2���̏ꍇ�Ȃǁj
                                    w_TempLng = Integer.Parse(Format(w_TempBefore, "yyyyMM") & Format(w_TempDefLimit, "00"))
                                    If IsDate(Format(w_TempLng, "0000/00/00")) = True Then
                                        Exit Do
                                    Else
                                        w_TempDefLimit = w_TempDefLimit - 1
                                        If w_TempDefLimit <= 0 Then
                                            w_TempLng = 0
                                            Exit Do
                                        End If
                                    End If
                                Loop
                                w_LimitDate_R = w_TempLng
                            End If
                        End If
                    End If

                    '��]���ߐ؂�����v�Z����i�f�t�H���g���Őݒ肷��j
                    w_LimitDate_H = 0 '������
                    If w_LimitDayFlg_H = True AndAlso w_DefLimit_H <= 31 Then
                        '�P�����Ȃ̂Ŗ������� Or n���O�Ƃ��Čv�Z����
                        If w_DefLimit_H <= 0 Then
                            'ϲŽ�l�̏ꍇ��n���O�Ƃ��Čv�Z����
                            w_LimitDate_H = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, w_DefLimit_H, w_StartDate))
                        Else
                            '1<=w_DefLimit_H<=31�̏ꍇ�͖��������Ƃ��Čv�Z����i���������ȊO�ɂ��Ή�����j
                            w_TempDefLimit = w_DefLimit_H
                            Do
                                w_TempLng = Integer.Parse(Format(w_StartDate, "yyyyMM") & Format(w_TempDefLimit, "00"))
                                If IsDate(Format(w_TempLng, "0000/00/00")) = True Then
                                    Exit Do
                                Else
                                    w_TempDefLimit = w_TempDefLimit - 1
                                    If w_TempDefLimit <= 0 Then
                                        w_TempLng = 999999999
                                        Exit Do
                                    End If
                                End If
                            Loop
                            If w_TempLng < General.paGetDateIntegerFromDate(w_StartDate) Then
                                '�����̓��t�Ōv����ԊJ�n�����ߋ����Ȃ炻�̓�����ߐ؂���Ƃ���i��:16���`15���̂Ōv����ԂŁA10�����ߐ؂���̏ꍇ�j
                                w_LimitDate_H = w_TempLng
                            Else
                                w_TempBefore = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -1, w_StartDate)
                                w_TempDefLimit = w_DefLimit_H
                                Do
                                    '��̫�Ē��ߐ؂�������t�Ɣ��f�ł���܂Őݒ肷��i��:��̫�Ē��ߐ؂����30���� 2���̏ꍇ�Ȃǁj
                                    w_TempLng = Integer.Parse(Format(w_TempBefore, "yyyyMM") & Format(w_TempDefLimit, "00"))
                                    If IsDate(Format(w_TempLng, "0000/00/00")) = True Then
                                        Exit Do
                                    Else
                                        w_TempDefLimit = w_TempDefLimit - 1
                                        If w_TempDefLimit <= 0 Then
                                            w_TempLng = 0
                                            Exit Do
                                        End If
                                    End If
                                Loop
                                w_LimitDate_H = w_TempLng
                            End If
                        End If
                    End If

                    '�v�搧���ް��̔z����g������
                    w_MaxIndex = w_MaxIndex + 1
                    ReDim Preserve m_KeikakuCtrlData(w_MaxIndex)
                    '�v�搧���ް����i�[����
                    m_KeikakuCtrlData(w_MaxIndex).PlanNo = w_PlanNo
                    m_KeikakuCtrlData(w_MaxIndex).PlanStart = General.paGetDateIntegerFromDate(w_StartDate)
                    m_KeikakuCtrlData(w_MaxIndex).PlanEnd = General.paGetDateIntegerFromDate(w_EndDate)
                    m_KeikakuCtrlData(w_MaxIndex).TarmNo = 0
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay = w_LimitDate
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_R = w_LimitDate_R
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_H = w_LimitDate_H
                    m_KeikakuCtrlData(w_MaxIndex).DataFlg = False
                    m_KeikakuCtrlData(w_MaxIndex).UpdateFlg = False

                    '���ѓ��t���_�ł̌v��ԍ���ޔ�
                    If General.paGetDateIntegerFromDate(w_StartDate) <= w_NowDate AndAlso w_NowDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                        pNowPlanNo = w_PlanNo
                    End If

                    '�ő�쐬���t�A���́A�v��ԍ��Ȃ�Loop�����o��
                    If w_StopType = True Then
                        '���t�Ŕ��f����
                        If w_StopDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                            '�ő�쐬���t���܂ރf�[�^�̏ꍇ
                            Exit Do
                        End If
                    Else
                        '�v��ԍ��Ŕ��f����
                        If w_StopPlanNo <= w_PlanNo Then
                            Exit Do
                        End If
                    End If

                    '�v����ԊJ�n�����v�Z����i�v����ԏI�����́{�P���j
                    w_StartDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_EndDate)

                Loop

            End If

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub
End Class