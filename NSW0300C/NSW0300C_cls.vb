Option Strict Off
Option Explicit On
<Serializable()> <System.Runtime.InteropServices.ProgId("clsGetOverData_NET.clsGetOverData")> Public Class clsGetOverData
    '/****************************************************/
    '/    ���і��́FNurseAID6.5
    '/ ��۸��і��́F���΃f�[�^�擾���i(�J��@�Ή�)
    '/        �h�c�FNSW0300C
    '/        �T�v�F���΂̏����擾����B
    '/
    '/      �쐬�ҁF T.I        CREATE 2010/02/25       �yP-02638�z
    '/      �X�V�ҁF Y.Iguchi          2010/04/08       �yP-02656�z �X�V���e�F(�@�莞�ԉz�������ǉ�)
    '/               M.ishida          2010/04/09       �yP-02707�z �X�V���e�F(���ԊO�͏o�݌v�擾�����ǉ�)
    '/               T.Ishiga          2010/04/15       �yPRE-1520�z �X�V���e�F(100/100���Z�t���O�ǉ�)
    '/
    '/     Copyright (C) Inter co.,ltd 2004
    '/****************************************************/

    '===============================
    '       �萔�錾
    '===============================
    Public Const M_DataFlg_DefaultData As String = "0" '���݂��Ȃ��ꍇ
    Public Const M_DataFlg_GaitoPlanNoData As String = "1" '�Y���v��ԍ�
    Public Const M_DataFlg_BeforePlanNoData As String = "2" '�O��v��ԍ�

    '�ō��`�F�b�N�g�p�萔
    '�ō��v��
    Public Const M_IntDakokuHissu As Short = 0 '�ō��K�{
    Public Const M_IntDakokuHuyo As Short = 1 '�ō��s�v

    '�ō��敪
    Public Const M_StrKbn_Syutu As String = "1" '�o��
    Public Const M_StrKbn_Tai As String = "2" '�ދ�
    Public Const M_StrKbn_Gai As String = "3" '�O�o
    Public Const M_StrKbn_Modori As String = "4" '�߂�

    '�ō��G���[�敪
    Public Const M_IntNotExist As Short = 1 '�ō��Ȃ�
    Public Const M_IntErrDakoku As Short = 2 '�ō����Ԋm�F
    Public Const M_IntSame As Short = 3 '�ō��A��
    Public Const M_IntNotNeed As Short = 4 '�s�v�ȑō�
    Public Const M_IntOverKinmu As Short = 5 '���Ύ��ԕs��
    Public Const M_IntKinmuErr As Short = 6 '�Ζ��Ȃ�
    Public Const M_IntYukoGai As Short = 7 '�L���͈͊O�̑ō�

    '===============================
    '       �ϐ��錾
    '===============================
    '***** �����è��n���� Start *****
    Public m_strHospitalCD As String '�a�@CD
    Public m_lngStaffKbn As Integer '�E���敪
    Public m_strStaffNo As String '�E���ԍ�
    Public m_lngKinmuSyutokuKbn As Integer '�Ζ��擾�敪
    Public m_lngHidukeKbn As Integer '���t�敪   0:�P��� 1:����
    Public m_lngKinmuTargetFlg As Integer '�Ζ��Ώێ�FLG 0:�S�� 1:�Ζ��Ώێ� 2:���ΑΏێ�
    Public m_lngStartDate As Integer '�J�n�N����
    Public m_lngEndDate As Integer '�I���N����
    Public m_strTargetCD As String '�Ώ�CD
    Public G_StrDaikyuMng As String '��x�Ǘ�������E���Ȃ��̔���i0�F��x�Ǘ�����A1�F��x�Ǘ����Ȃ��j
    Public G_StrDateJudgment As String '���΃f�[�^�̓��t����i�O�F�N�����A�P�F���ΔN�����j
    Public G_StrWeekHolCD As String '�T�xCD
    Public G_StrAutoHoliday As String '�����x���o�Ή��i�O�F����A�P�F���Ȃ��j
    Public G_StrHolidayOKKinmuCD As String '�����x���o�Ή\�Ζ�CD
    Public g_lngLastHoliday As Integer '�o�͑ΏۈȑO���߂̋x��
    Public G_StrNenkyuKinmuCD As String '�N�x�̋Ζ�CD�i�����A�J���}��؂�j
    Public G_StrSaiyoCD As String '�Y���E���̗̍p�R�[�h
    Public G_StrKinmuDeptCD As String '�Y���E���̋Ζ������R�[�h
    Public G_StrKinmuCD As String '�Y�����̋Ζ��R�[�h
    Public m_lngJikangaiFlg As Long     '���ԊO�擾�t���O   1�F�\���f�[�^�@1�ȊO�F���F�f�[�^���\���f�[�^

    Public G_StrNot60TimeKinmuCD As String '���ԊO60���ԑΏۊO�Ζ��R�[�h
    Public g_lng60Time As String '����J������
    <Serializable()> Public Structure ovDay_type
        Dim Start As String '���ԊO���ΑъJ�n����
        Dim End_Renamed As String '���ԊO���ΑяI������
    End Structure
    Public g_ovDay() As ovDay_type
    Public g_exchgHolTimeKinmu As String '�x�����Ԃ֊��Z����Ζ�
    '2010/04/08 Y.Iguchi Add End##
    '***** �����è��n���� End *****

    Public g_lngHolidayKensu As Integer '�x���l����
    Public g_lngHolidayIndex As Integer '�x���l����
    Public g_lngHolidayData() As Integer '�x���l�f�[�^
    Public g_lngHolidayDate As Integer '�x�ݔN����
    Public g_lngHolidayDataDate As Integer '�x�����ݎQ�Ɠ��t
    Public g_lngWeeklyHolDate() As Integer '�T�x��
    Public G_StrTouchokuKinmuCD As String '�����Ζ�CD
    Public g_lngTouchokuTanka As Integer '�����P��
    Public g_lngJissekiChokinKensu As Integer '�Ζ����сE���΃f�[�^����
    Public g_lngJissekiChokinIndex As Integer '�Ζ����сE���΃f�[�^����
    Public g_lngJissekiChokinDate As Integer '�Ζ����сE���΃f�[�^���t
    Public g_lngJissekiChokinDataDate As Integer '�Ζ����сE���΃f�[�^���ݎQ�Ɠ��t
    Public g_lngChokinKensu As Integer '���΃f�[�^����
    Public g_lngChokinIndex As Integer '���΃f�[�^����
    Public g_lngTentaiDate As Integer '�]�ޔN����
    Public g_lngDaikyuData() As Integer '��x�Ǘ��f�[�^
    '2010/04/15 Ishiga add start-------------------------------------------
    Public g_100AddFlg As String '100/100���Z�t���O
    '2010/04/15 Ishiga add start-------------------------------------------

    '--------------------------
    '   ���ђ��΃f�[�^�p �\���̌Q
    '--------------------------
    <Serializable()> Public Structure typHistoryData
        Dim strCD As String
        Dim lngStartDate As Integer
        Dim lngEndDate As Integer
    End Structure
    <Serializable()> Public Structure typCDUnit
        Dim strSaiyouCD As String
        Dim strKangoTaniCD As String
        Dim lngStartDate As Integer
        Dim lngEndDate As Integer
    End Structure
    Public g_udtStaffHistory() As typCDUnit
    <Serializable()> Public Structure KinmuTimeDetail
        Dim KinmuCD As String '�Ζ�CD
        Dim Tanka As Short '�P��
        Dim TodayOff As Short '�����x���Z�莞��
        Dim NextOff As Short '�����x���Z�莞��
        Dim Tonight As Short '������ԎZ�莞��
        Dim NextNight As Short '������ԎZ�莞��
        Dim FormalTimeFrom As String '���K�Ζ�����FROM�iHHMM�j�i�ݒ肳��Ă��Ȃ��ꍇ�͋󕶎��j
        Dim FormalTimeTo As String '���K�Ζ�����TO�iHHMM�j�i�ݒ肳��Ă��Ȃ��ꍇ�͋󕶎��j
        Dim JituKinmuTime As String '���Ζ����ԁiHHMM�j�i�ݒ肳��Ă��Ȃ��ꍇ�͋󕶎��j
    End Structure
    <Serializable()> Public Structure typSanteiTime
        <VBFixedArray(999)> Dim SanteiTime() As KinmuTimeDetail '�Z�莞�Ԏ擾�p �z��(2004/11/17 KatouY UPD)�Ζ����Ԃl�ɒl�������ĂȂ��Ƃ��Ή�
        '---2007/07/25 hara add start
        Dim strSaiyoCD As String
        Dim strKinmuDeptCD As String
        '---2007/07/25 hara add end

        'UPGRADE_TODO: ���̍\���̂̃C���X�^���X������������ɂ́A"Initialize" ���Ăяo���Ȃ���΂Ȃ�܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' ���N���b�N���Ă��������B
        Public Sub Initialize()
            ReDim SanteiTime(999)
        End Sub
    End Structure
    Public g_udtHistory() As typSanteiTime
    '--- �Ζ����сE���΃f�[�^�ԋp�l
    <Serializable()> Public Structure typDateRange
        Dim strFrom As String '--- ����FROM
        Dim strTo As String '--- ����TO
    End Structure
    <Serializable()> Public Structure typChokinRiyu
        Dim strRiyuCD As String '--- .fj���Η��RCD
        Dim strRiyuNM As String '--- .fj���Η��R����
        Dim strRiyuRNM As String '--- .fj���Η��R����
    End Structure
    <Serializable()> Public Structure typJissekiChokin
        Dim lngYMD As Integer '--- .fj�N����
        Dim strJissekiKinmuCD As String '--- .fj���ыΖ�CD
        Dim strJissekiKinmuNM As String '--- .fj���ыΖ�����
        Dim strJissekiKinmuMark As String '--- .fj���ыΖ��L��
        '2008/03/07 Muraoka Add ---------
        Dim strJissekiKinmuRKbn As String '--- .fj���ыΖ����R�敪
        Dim strJissekiHalfKinmuFlg As String '--- .fj���є����Ζ�FLG
        '--------------------------------
        Dim strJissekiJituKinmuTime As String '--- .fj���ю��Ζ�����
        Dim strJissekiKinmuTime As typDateRange '--- .fj���ыΖ�����FROM
        Dim strChokinTime() As typDateRange '--- .fj���Ύ���FROM
        Dim lngChokinOrderDate() As Integer
        Dim intChokinTime125() As Short '--- .fj���ߋΖ�����125�i���j
        Dim intChokinTime135() As Short '--- .fj���ߋΖ�����135�i���j
        Dim intChokinTime150() As Short '--- .fj���ߋΖ�����150�i���j
        Dim intChokinTime160() As Short '--- .fj���ߋΖ�����160�i���j
        Dim intChokinTime100() As Short '--- .fj���ߋΖ�����100�i���j'---2007/07/25 hara add
        '2010/04/08 Y.Iguchi Add Start
        Dim intChokinTime150_2() As Short '--- .fj���ߋΖ�����150�i60���ԉz���j�i���j
        Dim intChokinTime175() As Short '--- .fj���ߋΖ�����175�i60���ԉz���j�i���j
        '2010/04/08 Y.Iguchi Add End##
        '2018-08-15 Darren ADD START
        Dim intChokinTime25() As Short
        '2018-08-15 Darren ADD END
        Dim intHolidayTime As Short '--- .fj�x���Ζ����ԁi���j
        Dim intNightTime As Short '--- .fj��ԋΖ����ԁi���j
        Dim strApproveKbn() As String '--- .fj��ԋ敪  ---20061107 iwasaki add
        Dim strChokinRiyu() As typChokinRiyu
        '---2007/09/21 hara add start
        Dim strSaiyoCD As String '--- �̗pCD
        Dim lngJituKinmuTime100 As Integer '--- 100/100�p���Ζ�����(��)
        Dim lngJituKinmuTime100Add As Integer '--- 100/100�Ƃ��Ċ��蓖�ĉ\�Ȏ���(��) = �����Ζ����� - ��������
        Dim bln100chk As Boolean '--- 100/100�Ώۃt���O(True�F�Ώۍ̗pCD ���� ���蓖�ĉ\���Ԃ�����AFalse�F�ȊO)
        '---2007/09/21 hara add end
        '---2007/11/14 hara add start
        Dim strUniqueSeqNo() As String
        '---2007/11/14 hara add end
    End Structure
    Public g_udtJissekiChokin() As typJissekiChokin

    '���Ζ��ׂe
    <Serializable()> Private Structure typCyokinMeisai
        Dim OrderDate As Integer
        Dim CyokinDate As Integer
        Dim BunkatuFlg As String
        Dim CyokinFrom As String
        Dim CyokinTo As String
        Dim ReasonCD As String
        Dim ReasonNM As String
        Dim ReasonRNM As String
        Dim ApproveKbn As String '20061108 iwasaki add
        Dim UniqueSeqNo As String '---2007/11/14 hara add
    End Structure

    <Serializable()> Private Structure typDayKinmuCD
        Dim lngDate As Integer
        Dim strKinmuCD As String
    End Structure

    Private g_DayKinmuCD() As typDayKinmuCD

    '========================
    '  �����Ζ����� �\����
    '========================
    <Serializable()> Private Structure DayWorkTimeType
        Dim strCD() As String '�̗p�b�c
        Dim lngTime As Integer '�����Ζ�����(��)
    End Structure

    <Serializable()> Public Structure GensanDataType
        Dim CD As String
        Dim Time As Integer
    End Structure
    <Serializable()> Public Structure DateTimeType
        Dim lngDate As Integer '���t
        Dim udtData() As GensanDataType
    End Structure
    Public g_DayKoujoTime() As DateTimeType '�T������
    Public g_DayNenkyuTime() As DateTimeType '�N�x����
    <Serializable()> Public Structure Calc_CD_Type
        Dim strCD As String
        Dim strKBN As String
    End Structure
    Public m_JitsuCalcHolBunruiCD() As Calc_CD_Type
    Public m_JitsuCalcKojyoBunruiCD() As Calc_CD_Type
    Public m_100CalcHolBunruiCD() As Calc_CD_Type
    Public m_100CalcKojyoBunruiCD() As Calc_CD_Type
    Public m_lngAppliTime As Integer
    Public m_lngDecisionTime As Integer

    ''' <summary>
    ''' p���ԊO�擾�t���O���Z�b�g����
    ''' </summary>
    ''' <param name="Value">p���ԊO�擾�t���O</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p���ԊO�擾�t���O() As Integer
        Set(ByVal value As Integer)
            m_lngJikangaiFlg = value
        End Set
    End Property

    ''' <summary>
    ''' �擾�����R�[�h�����ɔėp�l��薼�̂��擾
    ''' </summary>
    ''' <param name="p_strCode">�ėp�l���擾����R�[�h</param>
    ''' <param name="p_strMasterID">�ėp�l�̃}�X�^ID</param>
    ''' <returns>����</returns>
    ''' <remarks></remarks>
    Private Function fncGetHanyouName(ByVal p_strCode As String, ByVal p_strMasterID As String) As String
        Dim w_strPreErrorProc As String
        Dim w_strSql As Object
        Dim w_Rs As ADODB.Recordset

        w_strPreErrorProc = General.g_ErrorProc
        General.g_ErrorProc = "BasNSW0300C fncGetHanyouName"
        Try
            '�Ō�P��CD���擾
            w_strSql = "select Name From NS_HANYOU_M"
            w_strSql = w_strSql & " where MasterCD = '" & p_strCode & "'"
            w_strSql = w_strSql & " and MasterID = '" & p_strMasterID & "'"
            w_strSql = w_strSql & " and HospitalCD = '" & Trim(m_strHospitalCD) & "'"

            '�J�[�\���쐬
            w_Rs = General.paDBRecordSetOpen(w_strSql)

            With w_Rs
                If .RecordCount <= 0 Then
                    fncGetHanyouName = ""
                Else
                    fncGetHanyouName = General.paGetDbFieldVal(.Fields("Name"), "")
                End If
                .Close()
            End With
            w_Rs = Nothing

            General.g_ErrorProc = w_strPreErrorProc
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �x���l�f�[�^��N�����Ō������ăC���f�b�N�X���m�肷��
    ''' </summary>
    ''' <returns>True:�Ώۓ��t�����݂���AFalse:�Ώۓ��t�����݂��Ȃ�</returns>
    ''' <remarks></remarks>
    Public Function fncblnHolidayKensaku() As Boolean
        Dim w_strPreErrorProc As String
        w_strPreErrorProc = General.g_ErrorProc
        General.g_ErrorProc = "BasNSW0300C fncblnHolidayKensaku"

        Dim w_lngCount As Integer
        Try
            g_lngHolidayIndex = 0
            For w_lngCount = 1 To g_lngHolidayKensu
                '�f�[�^�̔N�����ƎQ�ƔN�������r
                If g_lngHolidayData(w_lngCount) = g_lngHolidayDataDate Then
                    '�Q�ƔN����������
                    g_lngHolidayIndex = w_lngCount
                    Exit For
                ElseIf g_lngHolidayData(w_lngCount) > g_lngHolidayDataDate Then
                    '�Q�ƔN�������݂���Ȃ�
                    g_lngHolidayIndex = 0
                    Exit For
                End If
            Next w_lngCount

            If g_lngHolidayIndex = 0 Then
                '�Ώۓ��t�����݂��Ȃ�
                fncblnHolidayKensaku = False
                Exit Function
            Else
                fncblnHolidayKensaku = True
            End If

            General.g_ErrorProc = w_strPreErrorProc
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �Ζ����сE���΃f�[�^��N�����Ō������ăC���f�b�N�X���m�肷��
    ''' </summary>
    ''' <returns>True:�Ώۓ��t�����݂���AFalse:�Ώۓ��t�����݂��Ȃ�</returns>
    ''' <remarks></remarks>
    Public Function fncblnJissekiChokinKensaku() As Boolean
        Dim w_strPreErrorProc As String
        w_strPreErrorProc = General.g_ErrorProc
        General.g_ErrorProc = "BasNSW0300C fncblnJissekiChokinKensaku"

        Dim w_lngCount As Integer
        Try
            g_lngJissekiChokinIndex = 0
            For w_lngCount = 1 To g_lngJissekiChokinKensu
                '�f�[�^�̔N�����ƎQ�ƔN�������r
                If g_udtJissekiChokin(w_lngCount).lngYMD = g_lngJissekiChokinDataDate Then
                    '�Q�ƔN����������
                    g_lngJissekiChokinIndex = w_lngCount
                    Exit For
                ElseIf g_udtJissekiChokin(w_lngCount).lngYMD > g_lngJissekiChokinDataDate Then
                    '�Q�ƔN�������݂���Ȃ�
                    g_lngJissekiChokinIndex = 0
                    Exit For
                End If
            Next w_lngCount

            If g_lngJissekiChokinIndex = 0 Then
                '�Ώۓ��t�����݂��Ȃ�
                fncblnJissekiChokinKensaku = False
                Exit Function
            Else
                fncblnJissekiChokinKensaku = True
            End If

            General.g_ErrorProc = w_strPreErrorProc
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �x���l�f�[�^���擾
    ''' </summary>
    ''' <remarks>�����x���o�Ή����s���ꍇ�̂ݏo�͊��ԈȑO�̋x���f�[�^���擾�i�����x���o�Ή��`�F�b�N�p�j</remarks>
    Public Sub subGetHolidayData()
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "subGetHolidayData"

        Dim w_Sql As String
        Dim w_Year As Short
        Dim w_From As Short
        Dim w_To As Short
        Dim w_Cnt As Short
        Dim w_i As Short
        Dim w_Rs As ADODB.Recordset
        '̨���ޥ��޼ު��
        Dim w_YYYY_F As ADODB.Field
        Dim w_MMDD_F As ADODB.Field
        Dim w_LastDate As Integer
        Dim w_LastCnt As Short
        Dim w_strDate As Date
        Dim w_ToDate As String
        Try
            '�Ώی��擾
            w_From = Short.Parse(Right(Convert.ToString(m_lngStartDate), 4))
            w_To = Short.Parse(Right(Convert.ToString(m_lngEndDate), 4))


            '�z��̏�����
            ReDim g_lngHolidayData(0)
            w_LastCnt = 0

            '--- �����x���o�Ή����s���ꍇ�̂�
            If ("0").Equals(G_StrAutoHoliday) Then
                '-----------------------------------------------------------
                '   �o�͊��ԈȑO�̋x���f�[�^���擾�i�����x���o�Ή��`�F�b�N�p�j
                '-----------------------------------------------------------
                w_LastDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, General.paGetDateFromDateInteger(m_lngStartDate)))
                w_Year = Short.Parse(Left(Convert.ToString(w_LastDate), 4)) - 1
                'Select�� �ҏW
                w_Sql = ""
                w_Sql = w_Sql & "SELECT"
                w_Sql = w_Sql & " YearF,"
                w_Sql = w_Sql & " MonthDay "
                w_Sql = w_Sql & "FROM"
                w_Sql = w_Sql & " NS_HOLIDAY_M "
                w_Sql = w_Sql & "WHERE HospitalCD = '" & m_strHospitalCD & "' "
                w_Sql = w_Sql & "  AND (YearF <= " & Convert.ToString(w_Year) & " "
                w_Sql = w_Sql & "   OR (YearF = " & Convert.ToString(Left(Convert.ToString(w_LastDate), 4)) & " "
                w_Sql = w_Sql & "  AND MonthDay >= " & Convert.ToString(101) & " "
                w_Sql = w_Sql & "  AND MonthDay <= " & Integer.Parse(Right(Convert.ToString(w_LastDate), 4)) & " )) "
                w_Sql = w_Sql & "ORDER BY"
                w_Sql = w_Sql & " YearF DESC,"
                w_Sql = w_Sql & " MonthDay DESC "

                w_Rs = General.paDBRecordSetOpen(w_Sql)

                With w_Rs
                    '�ް��̗L�����m�F
                    If .RecordCount > 0 Then
                        '̨���޵�޼ު�Ă̐���
                        w_YYYY_F = .Fields("YearF")
                        w_MMDD_F = .Fields("MonthDay")

                        w_LastCnt = 1
                        ReDim Preserve g_lngHolidayData(w_LastCnt)

                        '--- �P���ڂ����łn�j
                        g_lngLastHoliday = Integer.Parse((w_YYYY_F.Value * 10000) + w_MMDD_F.Value)
                        g_lngHolidayData(w_LastCnt) = g_lngLastHoliday
                        'D.T 2006/12/29 ADD ===========================================================
                        '�����x���o�Ή����s���ݒ�ł��A�x���ݒ肪���݂��Ȃ��ꍇ�͐ݒ��ύX
                    Else
                        G_StrAutoHoliday = "1"
                        '==============================================================================
                    End If
                End With

                w_Rs.Close()
                w_Rs = Nothing
            End If

            w_strDate = General.paGetDateFromDateInteger(m_lngEndDate)
            w_strDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_strDate)
            w_To = Short.Parse(Format(w_strDate, "MMdd"))

            '�I���N�����̗������擾
            w_ToDate = General.paGetDateStringFromDate(w_strDate)

            'Select�� �ҏW
            w_Sql = "Select YearF, MonthDay From NS_HOLIDAY_M "
            w_Sql = w_Sql & "Where HospitalCD = '" & m_strHospitalCD & "' "
            w_Sql = w_Sql & "And YearF >= " & Convert.ToString(Left(Convert.ToString(m_lngStartDate), 4)) & " "
            w_Sql = w_Sql & "Or  YearF <= " & Left(w_ToDate, 4) & " "
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            With w_Rs
                '�ް��̗L�����m�F
                If .RecordCount > 0 Then

                    '�z��̊m��
                    .MoveLast()
                    w_Cnt = .RecordCount
                    g_lngHolidayKensu = w_LastCnt + w_Cnt
                    .MoveFirst()
                    ReDim Preserve g_lngHolidayData(g_lngHolidayKensu)

                    '̨���޵�޼ު�Ă̐���
                    w_YYYY_F = .Fields("YearF")
                    w_MMDD_F = .Fields("MonthDay")

                    For w_i = 1 To w_Cnt
                        g_lngHolidayData(w_LastCnt + w_i) = Integer.Parse((w_YYYY_F.Value * 10000) + w_MMDD_F.Value)
                        .MoveNext()
                    Next w_i

                End If
            End With

            w_Rs.Close()


            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        Finally
            w_Rs = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' �����x���o�Ή\�Ζ�CD�A�N�x�̋Ζ�CD���擾
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub subGetAutoHolidayKinmuCD()
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "subGetAutoHolidayKinmuCD"

        Dim w_strSql As String
        Dim w_Rs As ADODB.Recordset
        Dim w_KinmuCD_F As ADODB.Field
        Dim w_DataCnt As Short
        Dim w_Idx As Short

        G_StrHolidayOKKinmuCD = ""
        Try
            '------------------------------------------------------------
            '  �j���ɏT�x�������ꍇ�A���̌�ŋx���o�Έ����Ƃł���Ζ��̎擾
            '------------------------------------------------------------
            'Select�� �ҏW
            w_strSql = ""
            w_strSql = w_strSql & "SELECT"
            w_strSql = w_strSql & " KinmuCD "
            w_strSql = w_strSql & "FROM"
            w_strSql = w_strSql & " NS_KINMUNAME_M "
            w_strSql = w_strSql & "WHERE HospitalCD = '" & m_strHospitalCD & "' "
            w_strSql = w_strSql & "  AND KinmuKbn = '1' " '--- �Ζ�
            w_strSql = w_strSql & "  AND HalfKinmuFlg = '1' " '--- �S��
            w_strSql = w_strSql & "ORDER BY"
            w_strSql = w_strSql & " KinmuCD "
            w_Rs = General.paDBRecordSetOpen(w_strSql)

            With w_Rs
                '�ް��̗L�����m�F
                If .RecordCount > 0 Then

                    '�z��̊m��
                    .MoveLast()
                    w_DataCnt = .RecordCount
                    .MoveFirst()

                    '̨���޵�޼ު�Ă̐���
                    w_KinmuCD_F = .Fields("KinmuCD")

                    For w_Idx = 1 To w_DataCnt
                        G_StrHolidayOKKinmuCD = G_StrHolidayOKKinmuCD & General.paGetDbFieldVal(w_KinmuCD_F, "") & ","
                        .MoveNext()
                    Next w_Idx
                End If

                .Close()
            End With

            w_Rs = Nothing

            '-------------------------
            '  �N�x�Ώۂ̋Ζ�CD���擾
            '-------------------------
            'Select�� �ҏW
            w_strSql = ""
            w_strSql = w_strSql & "SELECT"
            w_strSql = w_strSql & " KinmuCD "
            w_strSql = w_strSql & "FROM"
            w_strSql = w_strSql & " NS_KINMUNAME_M "
            w_strSql = w_strSql & "WHERE HospitalCD = '" & m_strHospitalCD & "' "
            w_strSql = w_strSql & "  AND HolidayBunruiCD = '" & General.G_STRNENKYUBUNRUI & "' " '--- �x�ݕ��ށ��N�x
            w_strSql = w_strSql & "ORDER BY"
            w_strSql = w_strSql & " KinmuCD "
            w_Rs = General.paDBRecordSetOpen(w_strSql)

            With w_Rs
                '�ް��̗L�����m�F
                If .RecordCount > 0 Then

                    '�z��̊m��
                    .MoveLast()
                    w_DataCnt = .RecordCount
                    .MoveFirst()

                    '̨���޵�޼ު�Ă̐���
                    w_KinmuCD_F = .Fields("KinmuCD")

                    For w_Idx = 1 To w_DataCnt
                        G_StrNenkyuKinmuCD = G_StrNenkyuKinmuCD & General.paGetDbFieldVal(w_KinmuCD_F, "") & ","
                        .MoveNext()
                    Next w_Idx
                End If

                .Close()
            End With



            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        Finally
            w_Rs = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' �E�v�l�̖��̂�S���ި����ص�޼ު�ĂɊi�[
    ''' </summary>
    ''' <param name="p_objDic">��޼ު��</param>
    ''' <returns>�iTRUE�F����AFALSE�F�ُ�j</returns>
    ''' <remarks></remarks>
    Private Function fncSetTekiyouM(ByRef p_objDic As Object) As Boolean


        Dim w_strPreErrorProc As String
        Dim w_strSql As String
        Dim w_Rs As ADODB.Recordset
        Dim w_lngKensu As Integer
        Dim w_lngLoop As Integer

        w_strPreErrorProc = General.g_ErrorProc
        General.g_ErrorProc = "BasNSW0300C fncSetTekiyouM"

        fncSetTekiyouM = False
        Try
            w_strSql = ""
            w_strSql = "select TekiyouCD, Name from NS_TEKIYOU_M"
            w_strSql = w_strSql & " where HospitalCD = '" & Trim(m_strHospitalCD) & "'"

            '�J�[�\���쐬
            w_Rs = General.paDBRecordSetOpen(w_strSql)

            With w_Rs
                If .RecordCount <= 0 Then
                    '�E�v�l�ް��Ȃ�
                Else
                    .MoveLast()
                    w_lngKensu = .RecordCount
                    .MoveFirst()
                    For w_lngLoop = 1 To w_lngKensu
                        ''�ٓ��N�������~���Ŏ擾���Ă���̂ŁA��Ԗڂ��ް������݂̔z�����ɂȂ�
                        p_objDic.Item(.Fields("TekiyouCD").Value) = .Fields("Name").Value & ""
                        .MoveNext()
                    Next w_lngLoop
                End If
                .Close()
            End With
            w_Rs = Nothing

            General.g_ErrorProc = w_strPreErrorProc
            fncSetTekiyouM = True
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ߋΖ����Ԃ��擾����
    ''' </summary>
    ''' <param name="p_lngFrom">p�J�n�N����</param>
    ''' <param name="p_lngTo">p�I���N����</param>
    ''' <returns>�iTRUE�F����AFALSE�F�ُ�j</returns>
    ''' <remarks></remarks>
    Public Function fncGetCyokinData(ByVal p_lngFrom As Integer, ByVal p_lngTo As Integer) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "clsNSJP010 fncGetCyokinData"

        Dim w_i As Short
        Dim w_j As Short
        Dim w_HolFlg As String
        Dim w_TempDate As Date '���t���ޯ���擾�ړI�p
        Dim w_DayIdx As Short '���t���ޯ��
        Dim w_PreDayIdx As Short '�O����ް��̓��t(�ޔ�p �ް�)
        Dim w_Seq As Short '�����ް��p�̲��ޯ��
        Dim w_Time125 As Short '�P���ʒ��Ύ��Ԑ�(���Ύ��Ԍv�Z�֐��̌v�Z����)
        Dim w_Time135 As Short '�@�@�@ �V
        Dim w_Time150 As Short '�@�@�@ �V
        Dim w_Time160 As Short '�@�@�@ �V
        Dim w_Time100 As Short
        '2018-08-23 Darren ADD START
        Dim w_25Range As Integer
        Dim w_25Compare() As String
        Dim w_25Upper As Integer
        Dim w_25Lower As Integer
        '2018-08-23 Darren ADD END
        Dim w_CyokinData As typCyokinMeisai
        Dim w_blnResult As Boolean
        Dim w_WorkDate As Date
        Dim w_CheckDate As Integer
        Dim w_OrderDate_bk As Integer
        Dim w_BunkatuFlg_bk As Short
        Dim w_lngJugHolDate As Integer
        Dim w_HolMCompare As Short
        Dim w_strSaiyoCD As String
        Dim w_lngTime As Integer
        Dim w_lngCDLoop As Integer
        Dim w_lngSaiyoLoop As Integer
        Dim w_lngTimeLoop As Integer
        Dim w_lngTime_J As Integer
        Dim w_lngTime_f As Integer
        Dim w_strKinmuCD As String
        Dim w_lngCyokinFrom As Integer
        Dim w_lngCyokinTo As Integer
        Dim w_lng60Time As Integer
        Dim w_lngOldDate As Integer
        Dim w_dummy() As typJissekiChokin

        fncGetCyokinData = False
        Try
            '���ΒP���v�Z���ɋx���}�X�^�Q�Ɣ���(0:�Q�Ƃ���@1:�Q�Ƃ��Ȃ�)
            w_HolMCompare = Short.Parse(General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "HOLMCOMPARE", Convert.ToString(0), m_strHospitalCD))
            '2018-08-23 Darren ADD START
            w_25Compare = General.paSplit(General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "FURIKAE25OVERKINMUCD", Convert.ToString(0), m_strHospitalCD), ";")
            w_25Upper = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "FURIKAE25UPPERLIMIT", Convert.ToString(0), m_strHospitalCD)
            w_25Lower = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "FURIKAE25LOWERLIMIT", Convert.ToString(0), m_strHospitalCD)
            '2018-08-23 Darren ADD END

            w_lng60Time = Integer.Parse(g_lng60Time)
            w_lngOldDate = Integer.Parse(p_lngFrom.ToString.Substring(0, 6))

            '=======================
            '   �Ζ����ߎ��� �擾
            '=======================
            '�P���ʎ��Ԑ� ������
            w_Time125 = 0
            w_Time135 = 0
            w_Time150 = 0
            w_Time160 = 0
            w_Time100 = 0

            w_WorkDate = General.paGetDateFromDateInteger(p_lngFrom)

            With General.g_objGetData
                .p�E���敪 = m_lngStaffKbn
                .p�E���ԍ� = m_strStaffNo
                .p���t�敪 = m_lngHidukeKbn
                If m_lngJikangaiFlg = 1 Then
                    .p���F�敪 = 1            '--- �����e
                Else
                    .p���F�敪 = 2            '--- ���΂e�E���Β����e
                End If
                .p�J�n�N���� = p_lngFrom
                .p�I���N���� = p_lngTo
                w_blnResult = .mGetOverKinmu
                If w_blnResult = False Then
                Else
                    '--- .f���Ό���
                    w_PreDayIdx = 0
                    '�Y����������ް����� �J��Ԃ�
                    For w_i = 1 To .f���Ό���
                        .p���΍��� = w_i
                        '�ް���Ҕ�
                        '--- .f�N����
                        w_CyokinData.OrderDate = .f�N����
                        '--- .f���ΔN����
                        w_CyokinData.CyokinDate = .f���ΔN����
                        '--- .f���Ε���FLG
                        w_CyokinData.BunkatuFlg = .f���Ε���FLG
                        '--- .f���Ύ���FROM
                        w_CyokinData.CyokinFrom = .f���Ύ���FROM
                        '--- .f���Ύ���TO
                        w_CyokinData.CyokinTo = .f���Ύ���TO
                        '--- .f���Η��RCD
                        w_CyokinData.ReasonCD = .f���Η��RCD
                        '--- .f���Η��R����
                        w_CyokinData.ReasonNM = .f���Η��R����
                        '--- .f���Η��R����
                        w_CyokinData.ReasonRNM = .f���Η��R����
                        '--- .f���ԊO��ԋ敪
                        w_CyokinData.ApproveKbn = .f���ԊO��ԋ敪

                        w_strKinmuCD = .f���΋Ζ�CD

                        w_CyokinData.UniqueSeqNo = .f����UNIQUESEQNO

                        '�������ꂽ�����ް��Ŕ�����s��
                        '�N����
                        If ("0").Equals(G_StrDateJudgment) OrElse ("2").Equals(G_StrDateJudgment) Then
                            w_CheckDate = w_CyokinData.OrderDate
                        Else
                            w_CheckDate = w_CyokinData.CyokinDate
                        End If
                        w_TempDate = General.paGetDateFromDateInteger(w_CheckDate)
                        w_DayIdx = DateDiff(Microsoft.VisualBasic.DateInterval.Day, w_WorkDate, w_TempDate)
                        '--------------------------------------------------------------
                        '   �]�o���ƒ��΂��J�n���������r(�ސE���Ă��邩�ǂ����̌��ɂ�)
                        '--------------------------------------------------------------
                        If g_lngTentaiDate < w_CheckDate Then
                            '�]�o����蒴�Γ����傫���ꍇ��,���ɑސE���Ă���̂Ŋi�[���Ȃ�
                        Else
                            '�����t���_�ł�,�ސE���Ă��Ȃ��ꍇ
                            '========================
                            '   ���ΒP���ʎ��� �Z�o
                            '========================
                            '���Γ��̌����ς�����ꍇ
                            If w_lngOldDate < Integer.Parse(General.paGetDateStringFromInteger(w_CheckDate, General.G_DATE_ENUM.yyyyMM)) Then
                                '60���Ԃ����ɖ߂�
                                w_lng60Time = Integer.Parse(g_lng60Time)
                                w_lngOldDate = Integer.Parse(General.paGetDateStringFromInteger(w_CheckDate, General.G_DATE_ENUM.yyyyMM))
                            End If

                            '�����ް������邩�ǂ������f
                            If String.IsNullOrEmpty(w_CyokinData.CyokinFrom) = False AndAlso String.IsNullOrEmpty(w_CyokinData.CyokinTo) = False Then
                                '--- �N�����擾�ŁA�����t���O�������Ă���΁A�P���Ƃ��ĕԂ��B

                                If (("0").Equals(G_StrDateJudgment) OrElse ("2").Equals(G_StrDateJudgment)) AndAlso ("1").Equals(w_CyokinData.BunkatuFlg) AndAlso w_OrderDate_bk = w_CyokinData.OrderDate AndAlso w_BunkatuFlg_bk = Short.Parse(w_CyokinData.BunkatuFlg) Then
                                    '--- �J�E���g�A�b�v���Ȃ�
                                    w_Seq = UBound(g_udtJissekiChokin(w_DayIdx).strChokinTime)
                                Else
                                    '---------------------------------------
                                    '   �����ɑ��݂��钴�ΐ��� ���ޯ���擾
                                    '---------------------------------------
                                    w_Seq = UBound(g_udtJissekiChokin(w_DayIdx).strChokinTime) + 1

                                    '�����ް������݂���ꍇ
                                    '�Ζ����ߎ��� �z��m��
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).strChokinTime(w_Seq)
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).strChokinRiyu(w_Seq)
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).intChokinTime125(w_Seq)
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).intChokinTime135(w_Seq)
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).intChokinTime150(w_Seq)
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).intChokinTime160(w_Seq)
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq)
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).intChokinTime150_2(w_Seq)
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).intChokinTime175(w_Seq)
                                    '2018-08-15 Darren ADD START
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).intChokinTime25(w_Seq)
                                    '2018-08-15 Darren ADD END
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).lngChokinOrderDate(w_Seq)
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).strApproveKbn(w_Seq)
                                    ReDim Preserve g_udtJissekiChokin(w_DayIdx).strUniqueSeqNo(w_Seq)
                                    g_udtJissekiChokin(w_DayIdx).lngChokinOrderDate(w_Seq) = w_CyokinData.OrderDate
                                    'From
                                    g_udtJissekiChokin(w_DayIdx).strChokinTime(w_Seq).strFrom = General.paFormatZero(Integer.Parse(w_CyokinData.CyokinFrom), 4)
                                End If
                                'To
                                g_udtJissekiChokin(w_DayIdx).strChokinTime(w_Seq).strTo = General.paFormatZero(Integer.Parse(w_CyokinData.CyokinTo), 4)

                                Select Case G_StrDateJudgment
                                    Case Convert.ToString(0), Convert.ToString(1)
                                        '�P�����Γ�
                                        w_lngJugHolDate = w_CyokinData.CyokinDate
                                    Case Else
                                        '�P���N����
                                        w_lngJugHolDate = w_CyokinData.OrderDate
                                End Select

                                '���̓��̋Ζ�CD���擾����
                                For w_j = 1 To UBound(g_DayKinmuCD)
                                    If w_lngJugHolDate = g_DayKinmuCD(w_j).lngDate Then
                                        w_strKinmuCD = g_DayKinmuCD(w_j).strKinmuCD
                                        Exit For
                                    End If
                                Next w_j

                                '�x�����ǂ����𔻒f
                                w_HolFlg = "0"
                                If w_HolMCompare = 0 Then
                                    For w_j = 1 To UBound(g_lngHolidayData)
                                        If w_lngJugHolDate = g_lngHolidayData(w_j) Then
                                            w_HolFlg = "1"
                                            Exit For
                                        End If
                                    Next w_j
                                End If
                                '�Ζ����T�x���ǂ������f
                                For w_j = 1 To UBound(g_lngWeeklyHolDate)
                                    If w_lngJugHolDate = g_lngWeeklyHolDate(w_j) Then
                                        w_HolFlg = "1"
                                        Exit For
                                    End If
                                Next w_j


                                '-------------------------------------------
                                '   ��x�Ǘ�����ꍇ�́A�x���Ζ��𕽓�������
                                '-------------------------------------------
                                If ("0").Equals(G_StrDaikyuMng) Then
                                    For w_j = 1 To UBound(g_lngDaikyuData)
                                        If w_CyokinData.CyokinDate = g_lngDaikyuData(w_j) Then
                                            w_HolFlg = "0"
                                            Exit For
                                        End If
                                    Next w_j
                                End If


                                For w_lngCDLoop = 1 To UBound(g_udtStaffHistory)
                                    '�ٓ��敔��CD
                                    If w_CyokinData.CyokinDate > g_udtStaffHistory(w_lngCDLoop).lngStartDate AndAlso w_CyokinData.CyokinDate <= g_udtStaffHistory(w_lngCDLoop).lngEndDate Then
                                        For w_lngSaiyoLoop = 1 To UBound(g_udtHistory)
                                            '�̗pCD
                                            If g_udtStaffHistory(w_lngCDLoop).strSaiyouCD = g_udtHistory(w_lngSaiyoLoop).strSaiyoCD AndAlso g_udtStaffHistory(w_lngCDLoop).strKangoTaniCD = g_udtHistory(w_lngSaiyoLoop).strKinmuDeptCD Then
                                                For w_lngTimeLoop = 1 To UBound(g_udtHistory(w_lngCDLoop).SanteiTime)
                                                    If g_udtHistory(w_lngCDLoop).SanteiTime(w_lngTimeLoop).KinmuCD = IIf(String.IsNullOrEmpty(w_strKinmuCD), 0, w_strKinmuCD) Then
                                                        w_lngTime = Integer.Parse(g_udtHistory(w_lngCDLoop).SanteiTime(w_lngTimeLoop).JituKinmuTime)
                                                        w_strSaiyoCD = g_udtHistory(w_lngCDLoop).strSaiyoCD
                                                        Exit For
                                                    End If
                                                Next w_lngTimeLoop
                                            End If
                                        Next w_lngSaiyoLoop
                                    End If
                                Next w_lngCDLoop


                                w_lngTime_J = Integer.Parse(Left(General.paFormatZero(w_lngTime, 4), 2))
                                w_lngTime_f = Integer.Parse(Right(General.paFormatZero(w_lngTime, 4), 2))

                                '����
                                w_lngTime = w_lngTime_J * 60

                                '��
                                w_lngTime = w_lngTime + w_lngTime_f

                                '2018-08-14 Darren ADD START
                                '=============
                                '   25/100
                                '=============
                                For Each w_str25Compare As String In w_25Compare
                                    If w_CyokinData.ReasonCD = w_str25Compare Then
                                        w_lngCyokinFrom = Integer.Parse(w_CyokinData.CyokinFrom)
                                        w_lngCyokinTo = Integer.Parse(w_CyokinData.CyokinTo)

                                        If w_lngCyokinFrom > w_lngCyokinTo Then
                                            w_lngCyokinTo = w_lngCyokinTo + 2400
                                        End If

                                        w_lngCyokinFrom = Integer.Parse(fncTimeChangeMinute(Convert.ToString(w_lngCyokinFrom)))
                                        w_lngCyokinTo = Integer.Parse(fncTimeChangeMinute(Convert.ToString(w_lngCyokinTo)))

                                        w_25Range = Math.Abs(w_lngCyokinFrom - w_lngCyokinTo)

                                        If w_25Range >= w_25Lower Then
                                            If w_25Range >= w_25Lower And w_25Range < w_25Upper Then
                                                g_udtJissekiChokin(w_DayIdx).intChokinTime25(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime25(w_Seq) + w_25Lower
                                                w_25Range = w_25Range - w_25Lower
                                            ElseIf w_25Range >= w_25Upper Then
                                                g_udtJissekiChokin(w_DayIdx).intChokinTime25(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime25(w_Seq) + w_25Upper
                                                w_25Range = w_25Range - w_25Upper
                                            End If

                                            w_lngCyokinTo = w_lngCyokinFrom + w_25Range
                                            w_CyokinData.CyokinFrom = Integer.Parse(fncMinuteChangeTime(Convert.ToString(w_lngCyokinFrom)))
                                            w_CyokinData.CyokinTo = Integer.Parse(fncMinuteChangeTime(Convert.ToString(w_lngCyokinTo)))
                                        End If

                                        Exit For
                                    End If
                                Next
                                '2018-08-14 Darren ADD END

                                '=============
                                '   100/100
                                '=============
                                '�ΏۊO�̎��ԊO�����F����Ă���ꍇ�̂�100/100�v�Z����
                                If (m_lngJikangaiFlg <> 1 AndAlso Integer.Parse(w_CyokinData.ApproveKbn) = 1) OrElse m_lngJikangaiFlg = 1 Then
                                    '100/100�擾�����ǂ����H
                                    If g_udtJissekiChokin(w_DayIdx).bln100chk = True Then
                                        '100/100�Ƃ��Ċ��蓖�ĉ\�Ȏ���(��)�����邩�H
                                        If g_udtJissekiChokin(w_DayIdx).lngJituKinmuTime100Add > 0 Then

                                            '���Ύ��Ԃ�Long�^�Ŏ擾
                                            w_lngCyokinFrom = Integer.Parse(w_CyokinData.CyokinFrom)
                                            w_lngCyokinTo = Integer.Parse(w_CyokinData.CyokinTo)

                                            If w_lngCyokinFrom > w_lngCyokinTo Then
                                                '�����܂������ꍇ
                                                w_lngCyokinTo = w_lngCyokinTo + 2400
                                            End If

                                            '���蓖�ĉ\����(��)�𒴋ΊJ�n���Ԃɉ��Z
                                            w_lngCyokinFrom = Integer.Parse(fncTimeChangeMinute(Convert.ToString(w_lngCyokinFrom))) + g_udtJissekiChokin(w_DayIdx).lngJituKinmuTime100Add
                                            w_lngCyokinFrom = Integer.Parse(fncMinuteChangeTime(Convert.ToString(w_lngCyokinFrom)))

                                            If w_lngCyokinFrom <= w_lngCyokinTo Then
                                                g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq) + g_udtJissekiChokin(w_DayIdx).lngJituKinmuTime100Add
                                                g_udtJissekiChokin(w_DayIdx).lngJituKinmuTime100Add = 0
                                                w_CyokinData.CyokinFrom = Convert.ToString(w_lngCyokinFrom)
                                            Else
                                                w_lngCyokinFrom = Integer.Parse(fncTimeChangeMinute(General.paFormatZero(w_lngCyokinFrom, 4)))
                                                w_lngCyokinTo = Integer.Parse(fncTimeChangeMinute(General.paFormatZero(w_lngCyokinTo, 4)))

                                                g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq) + g_udtJissekiChokin(w_DayIdx).lngJituKinmuTime100Add - (w_lngCyokinFrom - w_lngCyokinTo)
                                                g_udtJissekiChokin(w_DayIdx).lngJituKinmuTime100Add = w_lngCyokinFrom - w_lngCyokinTo

                                                '���ߊ��蓖�ĉ\����(��)���擾
                                                w_CyokinData.CyokinFrom = w_CyokinData.CyokinTo
                                            End If
                                        End If
                                    End If
                                End If '-->���F�ς݁H          

                                '�ΏۊO�̎��ԊO�����F����Ă���ꍇ�̂�60���Ԍv�Z����
                                If (m_lngJikangaiFlg <> 1 And Integer.Parse(w_CyokinData.ApproveKbn) = 1) Or m_lngJikangaiFlg = 1 Then
                                    '60���ԑΏۊO�Ζ��R�[�h���H
                                    If InStr(G_StrNot60TimeKinmuCD, General.paFormatSpace(Integer.Parse(w_strKinmuCD), 3)) <= 0 AndAlso String.IsNullOrEmpty(w_strKinmuCD) = False Then
                                        '���Ύ��Ԃ�Long�^�Ŏ擾
                                        w_lngCyokinFrom = Integer.Parse(fncTimeChangeMinute(w_CyokinData.CyokinFrom))
                                        w_lngCyokinTo = Integer.Parse(fncTimeChangeMinute(w_CyokinData.CyokinTo))
                                        If w_lngCyokinFrom > w_lngCyokinTo Then
                                            '���P�ʂȂ̂�24���Ԃ�1440��
                                            w_lngCyokinTo = w_lngCyokinTo + 1440
                                        End If

                                        If ("1").Equals(g_100AddFlg) Then
                                            w_lng60Time = w_lng60Time - g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq)
                                        End If
                                        If w_lng60Time < 0 Then
                                            w_lng60Time = 0
                                        End If
                                        '���Ԕ���
                                        If w_lng60Time >= (w_lngCyokinTo - w_lngCyokinFrom) Then
                                            '�Ώۂ̎��ԊO���܂߂�60���Ԗ����̏ꍇ
                                            w_lng60Time = w_lng60Time - (w_lngCyokinTo - w_lngCyokinFrom)
                                        Else
                                            '�Ώۂ̎��ԊO���܂߂�60���Ԉȏ�̏ꍇ
                                            If w_lng60Time = 0 Then
                                                '���݂̎��ԊO�̎��Ԑ���60���Ԉȏ�̏ꍇ
                                                w_lngCyokinFrom = Integer.Parse(w_CyokinData.CyokinFrom)
                                                w_lngCyokinTo = Integer.Parse(w_CyokinData.CyokinTo)

                                                w_CyokinData.CyokinTo = w_CyokinData.CyokinFrom
                                            Else
                                                '���݂̎��ԊO�̎��Ԑ���60���Ԗ����̏ꍇ
                                                w_lngTime = w_lng60Time
                                                w_lngCyokinTo = Integer.Parse(w_CyokinData.CyokinTo)
                                                w_CyokinData.CyokinTo = Convert.ToString(Integer.Parse(Left(General.paFormatZero(Integer.Parse(w_CyokinData.CyokinFrom), 4), 2)) * 60)
                                                w_CyokinData.CyokinTo = Convert.ToString(Integer.Parse(w_CyokinData.CyokinTo) + Integer.Parse(Right(General.paFormatZero(w_CyokinData.CyokinFrom, 4), 2)) + w_lngTime)
                                                w_CyokinData.CyokinTo = fncMinuteChangeTime(w_CyokinData.CyokinTo)
                                                w_lngCyokinFrom = Integer.Parse(w_CyokinData.CyokinTo)
                                                w_lng60Time = 0
                                            End If
                                            '************************
                                            '   �P���ʋΖ����� �Z�o
                                            '************************
                                            '--- ���ΒP�����̎擾
                                            '--- .p���ΊJ�n����
                                            .p���ΊJ�n���� = Short.Parse(w_lngCyokinFrom)
                                            '--- .p���ΏI������
                                            .p���ΏI������ = Short.Parse(w_lngCyokinTo)
                                            '--- .p�x��FLG
                                            .p�x��FLG = w_HolFlg

                                            '--- .mGetTanka�̒��g
                                            w_blnResult = .mGetTanka
                                            If w_blnResult = False Then
                                            Else
                                                '--- .f���ΒP��1
                                                w_Time125 = .f���ΒP��1
                                                '--- .f���ΒP��2
                                                w_Time135 = .f���ΒP��2
                                                '--- .f���ΒP��3
                                                w_Time150 = .f���ΒP��3
                                                '--- .f���ΒP��4
                                                w_Time160 = .f���ΒP��4

                                                '--------------
                                                '   150/100�A
                                                '--------------
                                                If w_Time125 <> 0 OrElse w_Time135 <> 0 Then
                                                    g_udtJissekiChokin(w_DayIdx).intChokinTime150_2(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime150_2(w_Seq) + w_Time125 + w_Time135
                                                End If

                                                '--------------
                                                '   170/100
                                                '--------------
                                                If w_Time150 <> 0 OrElse w_Time160 <> 0 Then
                                                    g_udtJissekiChokin(w_DayIdx).intChokinTime175(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime175(w_Seq) + w_Time150 + w_Time160
                                                End If
                                            End If
                                        End If '-->�Ώۂ̎��ԊO��60���Ԕ���̎c���Ԃ����傫���H
                                    End If '-->60���ԑΏۊO�Ζ��H
                                End If '-->���F�ς݁H

                                '************************
                                '   �P���ʋΖ����� �Z�o
                                '************************
                                '--- ���ΒP�����̎擾
                                '--- .p���ΊJ�n����
                                .p���ΊJ�n���� = Short.Parse(w_CyokinData.CyokinFrom)
                                '--- .p���ΏI������
                                .p���ΏI������ = Short.Parse(w_CyokinData.CyokinTo)
                                '--- .p�x��FLG
                                .p�x��FLG = w_HolFlg

                                '--- .mGetTanka�̒��g
                                w_blnResult = .mGetTanka
                                If w_blnResult = False Then
                                Else
                                    '--- .f���ΒP��1
                                    w_Time125 = .f���ΒP��1
                                    '--- .f���ΒP��2
                                    w_Time135 = .f���ΒP��2
                                    '--- .f���ΒP��3
                                    w_Time150 = .f���ΒP��3
                                    '--- .f���ΒP��4
                                    w_Time160 = .f���ΒP��4

                                End If

                                '�ʒ��ΒP������ �i�[
                                If w_Time135 = 0 AndAlso w_Time160 = 0 Then
                                    '�j�x���ȊO�̓��̏ꍇ
                                    '--------------
                                    '   125/100
                                    '--------------
                                    If w_Time125 <> 0 Then
                                        g_udtJissekiChokin(w_DayIdx).intChokinTime125(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime125(w_Seq) + w_Time125
                                    End If

                                    '--------------
                                    '   150/100
                                    '--------------
                                    If w_Time150 <> 0 Then
                                        g_udtJissekiChokin(w_DayIdx).intChokinTime150(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime150(w_Seq) + w_Time150
                                    End If
                                ElseIf w_Time125 = 0 AndAlso w_Time150 = 0 Then
                                    '�j�x���̏ꍇ
                                    '--------------
                                    '   135/100
                                    '--------------
                                    If w_Time135 <> 0 Then
                                        g_udtJissekiChokin(w_DayIdx).intChokinTime135(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime135(w_Seq) + w_Time135
                                    End If

                                    '--------------
                                    '   160/100
                                    '--------------
                                    If w_Time160 <> 0 Then
                                        g_udtJissekiChokin(w_DayIdx).intChokinTime160(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime160(w_Seq) + w_Time160
                                    End If
                                End If '�j�x���̔��f�@�I��

                                g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq) + w_Time100

                                g_udtJissekiChokin(w_DayIdx).strChokinRiyu(w_Seq).strRiyuCD = w_CyokinData.ReasonCD
                                g_udtJissekiChokin(w_DayIdx).strChokinRiyu(w_Seq).strRiyuNM = w_CyokinData.ReasonNM
                                g_udtJissekiChokin(w_DayIdx).strChokinRiyu(w_Seq).strRiyuRNM = w_CyokinData.ReasonRNM
                                g_udtJissekiChokin(w_DayIdx).strApproveKbn(w_Seq) = w_CyokinData.ApproveKbn
                                g_udtJissekiChokin(w_DayIdx).strUniqueSeqNo(w_Seq) = w_CyokinData.UniqueSeqNo

                                '--- �N�����̑Ҕ�
                                w_OrderDate_bk = w_CyokinData.OrderDate
                                w_BunkatuFlg_bk = Short.Parse(w_CyokinData.BunkatuFlg)
                            End If '�����ް������邩�ǂ������f�@�I��
                        End If '�ސE���Ă��邩�ǂ������f

                        '���t �ޔ�
                        w_PreDayIdx = w_DayIdx
                    Next w_i
                End If
            End With

            w_dummy = g_udtJissekiChokin
            ReDim g_udtJissekiChokin(0)
            w_j = 0

            For w_i = 0 To UBound(w_dummy)
                w_lngOldDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, w_i, w_WorkDate))
                '���Ԏw��̏ꍇ�A���ԓ��@�P����w��̏ꍇ�A�Ώۓ��t�̎��ԊO�f�[�^���i�[����
                If (m_lngStartDate <= w_lngOldDate AndAlso m_lngEndDate >= w_lngOldDate AndAlso m_lngHidukeKbn = 1) OrElse (m_lngStartDate = w_lngOldDate AndAlso m_lngHidukeKbn = 0) Then
                    ReDim Preserve g_udtJissekiChokin(w_j)
                    g_udtJissekiChokin(w_j) = w_dummy(w_i)
                    w_j = w_j + 1
                End If
            Next w_i
            g_lngJissekiChokinKensu = UBound(g_udtJissekiChokin)

            fncGetCyokinData = True
            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �����ް����擾����
    ''' </summary>
    ''' <param name="p_lngFrom">p�J�n�N����</param>
    ''' <param name="p_lngTo">p�I���N����</param>
    ''' <returns>�iTRUE�F����AFALSE�F�ُ�j</returns>
    ''' <remarks></remarks>
    Public Function fncGetJissekiData(ByVal p_lngFrom As Integer, ByVal p_lngTo As Integer) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "clsNSJP010 fncGetJissekiData"

        Dim w_i As Short
        Dim w_k As Short
        Dim w_s As Short
        Dim w_HolCnt As Short
        Dim w_TodayOff As Short '�x���Z�莞��(������)
        Dim w_NextOff As Short '�@�@ �V �@�@(������)
        Dim w_Tonight As Short '��ԎZ�莞��(������)
        Dim w_NextNight As Short '�@�@ �V �@�@(������)
        Dim w_FormalTimeFrom As String '���K�Ζ�����From
        Dim w_FormalTimeTo As String '���K�Ζ�����To
        Dim w_JituKinmuTime As String '���Ζ�����
        Dim w_KinmuCD As String
        Dim w_KinmuIdx As Short
        Dim w_date As Integer
        Dim w_NextDate As Integer
        Dim w_DayIdx As Short '�z��i�[�p���ޯ��(������)
        Dim w_NextDayIdx As Short '�@�@�@�@�V       (������)
        Dim w_TodayHolFlg As Boolean
        Dim w_NextHolFlg As Boolean
        Dim w_WorkOff() As Integer '�@�@�@�@�V
        Dim w_WorkNight() As Integer '�@�@�@�@�V
        Dim w_Calc As Short
        Dim w_Int1 As Short
        Dim w_HisIndex As Short
        Dim w_WorkDate As Date
        Dim w_TempDate As Date '���t���ޯ���擾�ړI�p
        Dim w_AutoHoliday As Short '�j���ɏT�x�����������ǂ���
        Dim w_AutoHolidayIdx As Short '�j���ɏT�x���������ꍇ�̓Y����
        Dim w_blnResult As Boolean
        Dim w_StartDate As Integer
        Dim w_lngToDate As Integer
        Dim w_DayWorkTime() As DayWorkTimeType
        Dim w_Work As Object
        Dim w_Work2 As Object
        Dim w_Work3 As Object
        Dim w_j As Short
        Dim w_lngJitudouTime As Integer
        Dim w_str As String
        Dim w_AutoHolidayUseFlg As Boolean

        Dim w_lngLoop As Integer
        Dim w_lngJitudouTime2 As Integer

        ReDim g_DayKoujoTime(0)
        ReDim g_DayNenkyuTime(0)
        fncGetJissekiData = False
        Try
            G_StrKinmuCD = ""

            ReDim w_DayWorkTime(0)
            w_str = ""
            w_str = General.paGetItemValue(General.G_STRMAINKEY3, "WORKTIMESET", "DAYWORKTIME", "", m_strHospitalCD)
            w_Work = General.paSplit(w_str, ",")
            ReDim w_DayWorkTime(UBound(w_Work) + 1)
            For w_i = 0 To UBound(w_Work)
                w_Work2 = General.paSplit(w_Work(w_i), ";")
                '���̗pCD
                w_Work3 = General.paSplit(w_Work2(0), "+")
                ReDim w_DayWorkTime(w_i + 1).strCD(UBound(w_Work3) + 1)
                For w_j = 0 To UBound(w_Work3)
                    w_DayWorkTime(w_i + 1).strCD(w_j + 1) = w_Work3(w_j)
                Next w_j
                '��100/100�p ��������
                w_DayWorkTime(w_i + 1).lngTime = w_Work2(1)
            Next w_i

            w_WorkDate = General.paGetDateFromDateInteger(p_lngFrom)
            w_TempDate = General.paGetDateFromDateInteger(p_lngTo)
            g_lngJissekiChokinKensu = DateDiff(Microsoft.VisualBasic.DateInterval.Day, w_WorkDate, w_TempDate)
            w_AutoHoliday = 0

            w_lngToDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_TempDate), General.G_DATE_ENUM.yyyyMMdd)
            g_lngTentaiDate = 0

            ReDim g_udtJissekiChokin(g_lngJissekiChokinKensu)
            For w_i = 0 To g_lngJissekiChokinKensu
                ReDim g_udtJissekiChokin(w_i).strChokinTime(0)
            Next w_i

            ReDim w_WorkOff(g_lngJissekiChokinKensu)
            ReDim w_WorkNight(g_lngJissekiChokinKensu)

            '������������������������������������������������������������������������������
            '   ��x�Ǘ��f�[�^�̎擾
            '������������������������������������������������������������������������������
            If fncGetDaikyuData(p_lngFrom, p_lngTo) = False Then
                Exit Function
            End If

            '���Z�p�̔N�x�ƍT�����擾
            Call fncGetGensaiTime(p_lngFrom, w_lngToDate)

            With General.g_objGetData
                .p�E���敪 = m_lngStaffKbn
                .p�E���ԍ� = m_strStaffNo
                .p���t�敪 = m_lngHidukeKbn
                .p�J�n�N���� = p_lngFrom
                .p�I���N���� = w_lngToDate ' p_lngTo        
                .p�Ζ��擾�敪 = 1 '--- ���т̂�
                .p�m�蕔��CD = "" '--- �����ٓ��ғ��̕ʕ������̎��т��\������悤��
                If ("0").Equals(G_StrAutoHoliday) Then
                    '--- �����x���o�Ή����s���ꍇ�́A�Ώ۔N���ȑO�ɋx�����T�x���������̃`�F�b�N������
                    .p�J�n�N���� = g_lngLastHoliday
                    w_StartDate = g_lngLastHoliday
                Else
                    '--- �����x���o�Ή����s��Ȃ��ꍇ�́A�Ώ۔N���̂�
                    .p�J�n�N���� = p_lngFrom
                    w_StartDate = p_lngFrom
                End If
                .p�I���N���� = w_lngToDate 'p_lngTo
                w_blnResult = .mGetKinmu

                '�ް��̑�������
                If w_blnResult = False Then
                Else
                    '������������������������������������������������������������������������������
                    '   ���уf�[�^�̎擾
                    '������������������������������������������������������������������������������
                    '�ް������݂���ꍇ
                    .p���єN���� = w_StartDate

                    ReDim g_DayKinmuCD(.f���ԓ���)

                    For w_k = 1 To .f���ԓ���
                        '�Ζ����ޥ���t���擾
                        '--- .f���ыΖ�CD
                        w_KinmuCD = .f���ыΖ�CD
                        '--- .f���єN����
                        w_date = .f���єN����

                        G_StrKinmuCD = w_KinmuCD

                        g_DayKinmuCD(w_k).lngDate = w_date
                        g_DayKinmuCD(w_k).strKinmuCD = w_KinmuCD

                        If w_date <> 0 AndAlso w_date < w_lngToDate Then
                            '�����t���v�Z
                            w_TempDate = General.paGetDateFromDateInteger(w_date)
                            w_NextDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_TempDate))
                            '�z��i�[�p�ɓ��t��ҏW
                            w_DayIdx = DateDiff(Microsoft.VisualBasic.DateInterval.Day, w_WorkDate, w_TempDate)
                            w_NextDayIdx = w_DayIdx + 1
                            w_KinmuIdx = Short.Parse(w_KinmuCD)

                            If w_DayIdx < 0 AndAlso ("0").Equals(G_StrAutoHoliday) Then
                                '--- �o�͔͈͈ȑO�̃f�[�^�́A�j�����T�x���ǂ����̃`�F�b�N�̂�
                                '-------------------------------------------------------------------
                                '   �j���ɏT�x�������ꍇ�́A���߂̋Ζ��������I�ɋx���o�Έ����Ƃ���
                                '-------------------------------------------------------------------
                                For w_s = 1 To UBound(g_lngHolidayData)
                                    If w_date = g_lngHolidayData(w_s) AndAlso InStr(G_StrWeekHolCD, General.paFormatSpace(w_KinmuCD, 2)) > 0 Then
                                        w_AutoHoliday = w_AutoHoliday + 1
                                        w_AutoHolidayIdx = w_DayIdx
                                        Exit For
                                    End If
                                Next w_s

                                If w_AutoHoliday > 0 AndAlso w_DayIdx > w_AutoHolidayIdx Then
                                    '�j�x���̏ꍇ�͎����J�z�����������Ȃ�
                                    w_AutoHolidayUseFlg = True
                                    For w_Int1 = 1 To UBound(g_lngHolidayData)
                                        If w_date = g_lngHolidayData(w_Int1) Then
                                            w_AutoHolidayUseFlg = False
                                            Exit For
                                        End If
                                    Next w_Int1
                                    '*************************************************************
                                    If w_AutoHolidayUseFlg = True Then
                                        If InStr(1, G_StrHolidayOKKinmuCD, w_KinmuCD) > 0 Then
                                            '--- �j���Ɂu�T�x�v���������ꍇ�ŁA���߂̋Ζ����x���o�΂Ƃ���B
                                            w_AutoHoliday = w_AutoHoliday - 1
                                        ElseIf InStr(1, G_StrNenkyuKinmuCD, w_KinmuCD) > 0 Then
                                            '--- �j���Ɂu�T�x�v���������ꍇ�ŁA���߂̋Ζ��̑O�Ɂu�N�x�v���擾�����ꍇ
                                            w_AutoHoliday = w_AutoHoliday - 1
                                        End If
                                    End If
                                End If
                            Else
                                '--- �̗p�ƊŌ�P��CD�̑g�������擾
                                w_HisIndex = 0
                                For w_Int1 = 1 To UBound(g_udtStaffHistory)
                                    If g_udtStaffHistory(w_Int1).lngStartDate <= w_date AndAlso w_date <= g_udtStaffHistory(w_Int1).lngEndDate Then
                                        g_lngTentaiDate = g_udtStaffHistory(w_Int1).lngEndDate
                                        w_HisIndex = w_Int1
                                        Exit For
                                    End If
                                Next w_Int1

                                '�T�x�̓����i�[(�P���ʎ��Ԃ�U�蕪����̂ɗ��p)
                                If InStr(G_StrWeekHolCD, General.paFormatSpace(w_KinmuCD, 2)) > 0 Then
                                    w_HolCnt = w_HolCnt + 1
                                    ReDim Preserve g_lngWeeklyHolDate(w_HolCnt)
                                    g_lngWeeklyHolDate(w_HolCnt) = w_date
                                End If

                                '�]�o���ƒ��΂��J�n�������𖈉��r����(�ސE���Ă��邩�ǂ����̌��ɂ�)
                                If g_lngTentaiDate < w_date Then
                                    '�]�o����蒴�Γ����傫���ꍇ��,���ɑސE���Ă���̂Ŋi�[���Ȃ�
                                Else
                                    '�����t���_�ɂ����Ă͑ސE���Ă��Ȃ��ꍇ
                                    '�e�Z�莞�� �擾
                                    w_TodayOff = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).TodayOff '�����x���Z�莞��
                                    w_NextOff = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).NextOff '�����x���Z�莞��
                                    w_Tonight = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).Tonight '������ԎZ�莞��
                                    w_NextNight = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).NextNight '������ԎZ�莞��
                                    w_FormalTimeFrom = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).FormalTimeFrom '���K�Ζ�����FROM
                                    w_FormalTimeTo = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).FormalTimeTo '���K�Ζ�����TO
                                    w_JituKinmuTime = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).JituKinmuTime '���Ζ�����

                                    w_lngJitudouTime = Integer.Parse(fncTimeChangeMinute(w_JituKinmuTime))
                                    For w_i = 1 To UBound(g_DayKoujoTime)
                                        '�T���̓��t���Ζ��̓��t
                                        If g_DayKoujoTime(w_i).lngDate = w_date Then
                                            For w_j = 1 To UBound(g_DayKoujoTime(w_i).udtData)
                                                '���Z�Ώۂ̍T��������
                                                For w_lngLoop = 1 To UBound(m_100CalcKojyoBunruiCD)
                                                    If InStr(m_100CalcKojyoBunruiCD(w_lngLoop).strCD, General.paFormatSpace(g_DayKoujoTime(w_i).udtData(w_j).CD, 2)) > 0 Then
                                                        '                                                w_lngJitudouTime = w_lngJitudouTime - g_DayKoujoTime(w_i).udtData(w_j).Time
                                                        w_lngJitudouTime = w_lngJitudouTime - TimeRound(g_DayKoujoTime(w_i).udtData(w_j).Time, m_100CalcKojyoBunruiCD(w_lngLoop).strKBN)
                                                        If w_lngJitudouTime < 0 Then
                                                            w_lngJitudouTime = 0
                                                        End If
                                                        Exit For

                                                    End If
                                                Next w_lngLoop
                                            Next w_j
                                            Exit For
                                        End If
                                    Next w_i
                                    For w_i = 1 To UBound(g_DayNenkyuTime)
                                        '�N�x�̓��t���Ζ��̓��t
                                        If g_DayNenkyuTime(w_i).lngDate = w_date Then
                                            For w_j = 1 To UBound(g_DayNenkyuTime(w_i).udtData)
                                                '���Z�Ώۂ̔N�x������
                                                For w_lngLoop = 1 To UBound(m_100CalcHolBunruiCD)
                                                    If InStr(m_100CalcHolBunruiCD(w_lngLoop).strCD, General.paFormatSpace(g_DayNenkyuTime(w_i).udtData(w_j).CD, 2)) > 0 Then
                                                        '                                                w_lngJitudouTime = w_lngJitudouTime - g_DayNenkyuTime(w_i).udtData(w_j).Time
                                                        w_lngJitudouTime = w_lngJitudouTime - TimeRound(g_DayNenkyuTime(w_i).udtData(w_j).Time, m_100CalcHolBunruiCD(w_lngLoop).strKBN)
                                                        If w_lngJitudouTime < 0 Then
                                                            w_lngJitudouTime = 0
                                                        End If
                                                        Exit For
                                                    End If
                                                Next w_lngLoop
                                            Next w_j
                                            Exit For
                                        End If
                                    Next w_i

                                    g_udtJissekiChokin(w_DayIdx).lngYMD = w_date

                                    If p_lngFrom = w_date Then
                                        '�o�͑ΏۊJ�n���̑O���̏ꍇ�́A�Ζ�CD�̂݊i�[����
                                        g_udtJissekiChokin(0).strJissekiKinmuCD = w_KinmuCD
                                        g_udtJissekiChokin(0).strJissekiKinmuNM = .f���ыΖ�����
                                        g_udtJissekiChokin(0).strJissekiKinmuMark = .f���ыΖ��L��
                                    Else
                                        '�o�͑ΏۊJ�n���̑O���ȊO�̏ꍇ
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuCD = w_KinmuCD
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuNM = .f���ыΖ�����
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuMark = .f���ыΖ��L��
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuRKbn = .f���ї��R�敪
                                        g_udtJissekiChokin(w_DayIdx).strJissekiHalfKinmuFlg = .f���є����Ζ�FLG
                                        '-------------------
                                        '   �E�����e �i�[
                                        '-------------------
                                        '���K�Ζ�����From
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuTime.strFrom = General.paFormatZero(Integer.Parse(w_FormalTimeFrom), 4)
                                        '���K�Ζ�����To
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuTime.strTo = General.paFormatZero(Integer.Parse(w_FormalTimeTo), 4)
                                        '���Ζ�����
                                        g_udtJissekiChokin(w_DayIdx).strJissekiJituKinmuTime = General.paFormatZero(Integer.Parse(w_JituKinmuTime), 4)

                                        w_lngJitudouTime2 = Integer.Parse(fncTimeChangeMinute(w_JituKinmuTime))

                                        For w_i = 1 To UBound(g_DayKoujoTime)
                                            '�T���̓��t���Ζ��̓��t
                                            If g_DayKoujoTime(w_i).lngDate = w_date Then
                                                For w_j = 1 To UBound(g_DayKoujoTime(w_i).udtData)
                                                    '���Z�Ώۂ̍T��������
                                                    For w_lngLoop = 1 To UBound(m_JitsuCalcKojyoBunruiCD)
                                                        If InStr(m_JitsuCalcKojyoBunruiCD(w_lngLoop).strCD, General.paFormatSpace(g_DayKoujoTime(w_i).udtData(w_j).CD, 2)) > 0 Then
                                                            w_lngJitudouTime2 = w_lngJitudouTime2 - TimeRound(g_DayKoujoTime(w_i).udtData(w_j).Time, m_JitsuCalcKojyoBunruiCD(w_lngLoop).strKBN)
                                                            If w_lngJitudouTime2 < 0 Then
                                                                w_lngJitudouTime2 = 0
                                                            End If
                                                            Exit For
                                                        End If
                                                    Next w_lngLoop
                                                Next w_j
                                                Exit For
                                            End If
                                        Next w_i
                                        For w_i = 1 To UBound(g_DayNenkyuTime)
                                            '�N�x�̓��t���Ζ��̓��t
                                            If g_DayNenkyuTime(w_i).lngDate = w_date Then
                                                For w_j = 1 To UBound(g_DayNenkyuTime(w_i).udtData)
                                                    '���Z�Ώۂ̔N�x������
                                                    For w_lngLoop = 1 To UBound(m_JitsuCalcHolBunruiCD)
                                                        If InStr(m_JitsuCalcHolBunruiCD(w_lngLoop).strCD, General.paFormatSpace(g_DayNenkyuTime(w_i).udtData(w_j).CD, 2)) > 0 Then
                                                            w_lngJitudouTime2 = w_lngJitudouTime2 - TimeRound(g_DayNenkyuTime(w_i).udtData(w_j).Time, m_JitsuCalcHolBunruiCD(w_lngLoop).strKBN)
                                                            If w_lngJitudouTime2 < 0 Then
                                                                w_lngJitudouTime2 = 0
                                                            End If
                                                        End If
                                                    Next w_lngLoop
                                                Next w_j
                                                Exit For
                                            End If
                                        Next w_i

                                        g_udtJissekiChokin(w_DayIdx).strJissekiJituKinmuTime = fncMinuteChangeTime(Convert.ToString(w_lngJitudouTime2))

                                        '�̗pCD
                                        g_udtJissekiChokin(w_DayIdx).strSaiyoCD = g_udtStaffHistory(w_HisIndex).strSaiyouCD

                                        '100/100�p �����Ζ�����(��)
                                        g_udtJissekiChokin(w_DayIdx).lngJituKinmuTime100 = 0
                                        g_udtJissekiChokin(w_DayIdx).bln100chk = False
                                        For w_i = 1 To UBound(w_DayWorkTime)
                                            For w_j = 1 To UBound(w_DayWorkTime(w_i).strCD)
                                                If w_DayWorkTime(w_i).strCD(w_j) = g_udtJissekiChokin(w_DayIdx).strSaiyoCD AndAlso w_DayWorkTime(w_i).lngTime - w_lngJitudouTime > 0 Then
                                                    g_udtJissekiChokin(w_DayIdx).lngJituKinmuTime100 = w_DayWorkTime(w_i).lngTime
                                                    g_udtJissekiChokin(w_DayIdx).lngJituKinmuTime100Add = w_DayWorkTime(w_i).lngTime - w_lngJitudouTime
                                                    g_udtJissekiChokin(w_DayIdx).bln100chk = True
                                                    Exit For
                                                End If
                                            Next w_j
                                            If g_udtJissekiChokin(w_DayIdx).bln100chk = True Then Exit For
                                        Next w_i
                                    End If

                                    '�������j�����ǂ������擾
                                    w_TodayHolFlg = False
                                    For w_s = 1 To UBound(g_lngHolidayData)
                                        If w_date = g_lngHolidayData(w_s) Then
                                            w_TodayHolFlg = True
                                            Exit For
                                        End If
                                    Next w_s
                                    '�������j�����ǂ������擾
                                    w_NextHolFlg = False
                                    For w_s = 1 To UBound(g_lngHolidayData)
                                        If w_NextDate = g_lngHolidayData(w_s) Then
                                            w_NextHolFlg = True
                                            Exit For
                                        End If
                                    Next w_s

                                    If ("0").Equals(G_StrAutoHoliday) Then
                                        '-------------------------------------------------------------------
                                        '   �j���ɏT�x�������ꍇ�́A���߂̋Ζ��������I�ɋx���o�Έ����Ƃ���
                                        '-------------------------------------------------------------------
                                        For w_s = 1 To UBound(g_lngHolidayData)
                                            If w_date = g_lngHolidayData(w_s) AndAlso InStr(G_StrWeekHolCD, General.paFormatSpace(w_KinmuCD, 2)) > 0 Then
                                                w_AutoHoliday = w_AutoHoliday + 1
                                                w_AutoHolidayIdx = w_DayIdx
                                                Exit For
                                            End If
                                        Next w_s

                                        If w_AutoHoliday > 0 AndAlso w_DayIdx > w_AutoHolidayIdx Then
                                            '�j�x���̏ꍇ�͎����J�z�����������Ȃ�
                                            w_AutoHolidayUseFlg = True
                                            For w_Int1 = 1 To UBound(g_lngHolidayData)
                                                If w_date = g_lngHolidayData(w_Int1) Then
                                                    w_AutoHolidayUseFlg = False
                                                    Exit For
                                                End If
                                            Next w_Int1
                                            If w_AutoHolidayUseFlg = True Then
                                                If InStr(1, G_StrHolidayOKKinmuCD, w_KinmuCD) > 0 Then
                                                    '--- �j���Ɂu�T�x�v���������ꍇ�ŁA���߂̋Ζ����x���o�΂Ƃ���B
                                                    w_TodayHolFlg = True
                                                    w_AutoHoliday = w_AutoHoliday - 1
                                                ElseIf InStr(1, G_StrNenkyuKinmuCD, w_KinmuCD) > 0 Then
                                                    '--- �j���Ɂu�T�x�v���������ꍇ�ŁA���߂̋Ζ��̑O�Ɂu�N�x�v���擾�����ꍇ
                                                    w_AutoHoliday = w_AutoHoliday - 1
                                                End If
                                            End If
                                        End If
                                    End If


                                    '-------------------------------------------
                                    '   ��x�Ǘ�����ꍇ�́A�x���Ζ��𕽓�������
                                    '-------------------------------------------
                                    If ("0").Equals(G_StrDaikyuMng) Then
                                        For w_s = 1 To UBound(g_lngDaikyuData)
                                            If w_date = g_lngDaikyuData(w_s) AndAlso w_TodayHolFlg = True Then
                                                w_TodayHolFlg = False
                                            ElseIf w_NextDate = g_lngDaikyuData(w_s) AndAlso w_NextHolFlg = True Then
                                                w_NextHolFlg = False
                                            End If
                                        Next w_s
                                    End If

                                    '-----------------------------
                                    '   �x���Ζ����� �v�Z���i�[
                                    '-----------------------------
                                    '�v�Z�Ώۓ��̐U�蕪��
                                    If p_lngFrom = w_date Then
                                        '�ΏۊJ�n���̑O���̎��͗������݂̂��v�Z
                                        If w_NextHolFlg = True Then
                                            If w_NextOff = 0 Then
                                                '���Ԃ��ݒ肳��Ă��Ȃ����,�������Ȃ�
                                            Else
                                                '�x������
                                                '�����Z�蕪�̎��Ԃ�ܰ��p�z��Ɋi�[
                                                w_WorkOff(w_NextDayIdx) = w_NextOff
                                                g_udtJissekiChokin(w_NextDayIdx).intHolidayTime = w_NextOff
                                            End If
                                        End If
                                    ElseIf w_date = p_lngTo Then
                                        '�ΏۏI�����̎��͓������݂̂��v�Z
                                        If w_TodayHolFlg = True Then
                                            If w_TodayOff = 0 Then
                                                '���Ԃ��ݒ肳��Ă��Ȃ����, �Ζ��ʍ��v �v�Z�̂ݍs��
                                                '�����K�Ζ�������J��z���ꂽ���Ԃ�(�����,)���v�ɉ����邽��
                                            Else
                                                '�O���̐��K�Ζ�������J��z���ꂽ���Ԃ�(�����,)���Z���� �㏑���i�[
                                                w_Calc = w_WorkOff(w_DayIdx) + w_TodayOff
                                                g_udtJissekiChokin(w_DayIdx).intHolidayTime = w_Calc
                                            End If
                                        End If
                                    Else
                                        '�Ώۊ��ԓ��̎��͓����������������v�Z
                                        '������
                                        If w_TodayHolFlg = True Then
                                            If w_TodayOff = 0 Then
                                                '���Ԃ��ݒ肳��Ă��Ȃ����, �Ζ��ʍ��v �v�Z�̂ݍs��
                                                '�����K�Ζ�������J��z���ꂽ���Ԃ�(�����,)���v�ɉ����邽��
                                            Else
                                                '�O���̐��K�Ζ�������J��z���ꂽ���Ԃ�(�����,)���Z���� �㏑���i�[
                                                w_Calc = w_WorkOff(w_DayIdx) + w_TodayOff
                                                g_udtJissekiChokin(w_DayIdx).intHolidayTime = w_Calc
                                            End If
                                        End If
                                        '������
                                        If w_NextHolFlg = True Then
                                            If w_NextOff = 0 Then
                                                '���Ԃ��ݒ肳��Ă��Ȃ����,�������Ȃ�
                                            Else
                                                '�x������
                                                '�����Z�蕪�̎��Ԃ�ܰ��p�z��Ɋi�[
                                                w_WorkOff(w_NextDayIdx) = w_NextOff
                                                g_udtJissekiChokin(w_NextDayIdx).intHolidayTime = w_WorkOff(w_NextDayIdx)
                                            End If
                                        End If
                                    End If '�v�Z�Ώۓ��̐U�蕪�� �I��

                                    '-----------------------------
                                    '   ��ԋΖ����� �v�Z���i�[
                                    '-----------------------------
                                    If p_lngFrom = w_date Then
                                        '�ΏۊJ�n���̑O���̎��͗������݂̂��v�Z
                                        '��Ԏ���
                                        If w_NextNight = 0 Then
                                            '���Ԃ��ݒ肳��Ă��Ȃ����,�������Ȃ�
                                        Else
                                            '�����Z�蕪�̎��Ԃ�ܰ��p�z��Ɋi�[
                                            w_WorkNight(w_NextDayIdx) = w_NextNight
                                            g_udtJissekiChokin(w_NextDayIdx).intNightTime = w_WorkNight(w_NextDayIdx)
                                        End If
                                    ElseIf w_date = p_lngTo Then
                                        '�ΏۏI�����̎��͓������݂̂��v�Z
                                        '��Ԏ���
                                        If w_Tonight = 0 Then
                                            '���Ԃ��ݒ肳��Ă��Ȃ����, �Ζ��ʍ��v �v�Z�̂ݍs��
                                            '�����K�Ζ�������J��z���ꂽ���Ԃ�(�����,)���v�ɉ����邽��
                                        Else
                                            '�O���̐��K�Ζ�������J��z���ꂽ���Ԃ�(�����,)���Z���� �㏑���i�[
                                            w_Calc = w_WorkNight(w_DayIdx) + w_Tonight
                                            g_udtJissekiChokin(w_DayIdx).intNightTime = w_Calc
                                        End If
                                    Else
                                        '�Ώۊ��ԓ��̎��͓����������������v�Z
                                        '������
                                        '��Ԏ���
                                        If w_Tonight = 0 Then
                                            '���Ԃ��ݒ肳��Ă��Ȃ����, �Ζ��ʍ��v �v�Z�̂ݍs��
                                            '�����K�Ζ�������J��z���ꂽ���Ԃ�(�����,)���v�ɉ����邽��
                                        Else
                                            '�O���̐��K�Ζ�������J��z���ꂽ���Ԃ�(�����,)���Z���� �㏑���i�[
                                            w_Calc = w_WorkNight(w_DayIdx) + w_Tonight
                                            g_udtJissekiChokin(w_DayIdx).intNightTime = w_Calc
                                        End If
                                        '������
                                        '��Ԏ���
                                        If w_NextNight = 0 Then
                                            '���Ԃ��ݒ肳��Ă��Ȃ����,�������Ȃ�
                                        Else
                                            '�����Z�蕪�̎��Ԃ�ܰ��p�z��Ɋi�[
                                            w_WorkNight(w_NextDayIdx) = w_NextNight
                                            g_udtJissekiChokin(w_NextDayIdx).intNightTime = w_WorkNight(w_NextDayIdx)
                                        End If
                                    End If
                                End If '�ސE���Ă��邩�H
                            End If
                        ElseIf w_date = w_lngToDate AndAlso w_date <> 0 Then
                            '�T�x�̓����i�[(�P���ʎ��Ԃ�U�蕪����̂ɗ��p)
                            If InStr(G_StrWeekHolCD, General.paFormatSpace(w_KinmuCD, 2)) > 0 Then
                                w_HolCnt = w_HolCnt + 1
                                ReDim Preserve g_lngWeeklyHolDate(w_HolCnt)
                                g_lngWeeklyHolDate(w_HolCnt) = w_date
                            End If
                        End If
                        .m��������()
                    Next w_k
                End If
            End With
            Erase w_WorkOff
            Erase w_WorkNight

            fncGetJissekiData = True

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �̗pCD�E�Ō�P��CD�̑g�����ް����擾����
    ''' </summary>
    ''' <param name="p_lngFrom">p�J�n�N����</param>
    ''' <param name="p_lngTo">p�I���N����</param>
    ''' <returns>�iTRUE�F����AFALSE�F�ُ�j</returns>
    ''' <remarks></remarks>
    Public Function fncGetSaiyo_Kangotani(ByVal p_lngFrom As Integer, ByVal p_lngTo As Integer) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "clsNSJP010 fncGetSaiyo_Kangotani"

        Dim w_Cnt As Short
        Dim w_DataCnt As Short
        Dim w_Int1 As Short
        Dim w_Int2 As Short
        Dim w_StartDate As Integer
        Dim w_EndDate As Integer
        Dim w_udtSaiyou() As typHistoryData
        Dim w_udtKinmuchi() As typHistoryData
        Dim w_blnResult As Boolean

        fncGetSaiyo_Kangotani = False
        Try
            Erase w_udtSaiyou
            Erase w_udtKinmuchi
            ReDim g_udtHistory(0)

            With General.g_objGetData
                .p�E���敪 = m_lngStaffKbn
                .p�E���ԍ� = m_strStaffNo
                .p���t�敪 = m_lngHidukeKbn
                .p�J�n�N���� = p_lngFrom
                .p�I���N���� = p_lngTo
                .p�E���ԍ��ϊ� = 0
                .p�����\�[�gFLG = 0 '--- ����
                .p�V�X�e���敪 = 0 '--- �Ζ��Ǘ�
                w_blnResult = .mStaffInit
                If w_blnResult = False Then
                    '���肦�Ȃ��H
                Else

                    '--- �����̗̍pCD��
                    w_DataCnt = .f�E���Ǘ�����
                    ReDim w_udtSaiyou(w_DataCnt)
                    For w_Cnt = 1 To w_DataCnt
                        .p�E���Ǘ����� = w_Cnt
                        '--- .f�̗p�N����1
                        w_udtSaiyou(w_Cnt).lngStartDate = .f�̗p�N����1
                        '--- .f�]�ޔN����1
                        w_udtSaiyou(w_Cnt).lngEndDate = .f�]�ޔN����1
                        '--- .f�̗p����CD
                        w_udtSaiyou(w_Cnt).strCD = .f�̗p����CD
                    Next w_Cnt
                    '--- �����̊Ō�P��CD��
                    w_DataCnt = .f�Ζ��n�ٓ�����
                    ReDim w_udtKinmuchi(w_DataCnt)
                    For w_Cnt = 1 To w_DataCnt
                        .p�Ζ��n�ٓ����� = w_Cnt
                        '--- .f�Ζ��n�ٓ��N����
                        w_udtKinmuchi(w_Cnt).lngStartDate = .f�Ζ��n�ٓ��N����
                        '--- .f�Ζ��n�I���N����
                        w_udtKinmuchi(w_Cnt).lngEndDate = .f�Ζ��n�I���N����
                        '--- .f�Ō�P��CD1
                        w_udtKinmuchi(w_Cnt).strCD = .f�Ō�P��CD1
                    Next w_Cnt
                End If

                '--- �o�͑Ώی����̊Ō�P��CD�ƍ̗pCD�̑g�������쐬
                w_Int1 = 1
                w_Int2 = 1
                w_Cnt = 1
                Erase g_udtStaffHistory
                ReDim g_udtStaffHistory(0)
                If UBound(w_udtSaiyou) > 0 AndAlso UBound(w_udtKinmuchi) > 0 Then
                    ReDim g_udtStaffHistory(1)
                    g_udtStaffHistory(1).strSaiyouCD = w_udtSaiyou(1).strCD
                    g_udtStaffHistory(1).strKangoTaniCD = w_udtKinmuchi(1).strCD
                    g_udtStaffHistory(1).lngStartDate = p_lngFrom
                    g_udtStaffHistory(1).lngEndDate = p_lngTo
                    w_StartDate = p_lngFrom
                    w_EndDate = p_lngTo
                End If
                '--- �擾�����̗pCD�ƊŌ�P��CD�őg�����쐬
                Do
                    '--- �S���`�F�b�N������A���[�v�𔲂���
                    If w_Int1 >= UBound(w_udtSaiyou) AndAlso w_Int2 >= UBound(w_udtKinmuchi) Then Exit Do

                    If w_udtSaiyou(w_Int1).lngEndDate = w_udtKinmuchi(w_Int2).lngEndDate Then
                        w_EndDate = w_udtSaiyou(w_Int1).lngEndDate
                        w_Int1 = w_Int1 + 1
                        w_Int2 = w_Int2 + 1
                        w_StartDate = w_udtSaiyou(w_Int1).lngStartDate
                    ElseIf w_udtSaiyou(w_Int1).lngEndDate > w_udtKinmuchi(w_Int2).lngEndDate Then
                        w_EndDate = w_udtKinmuchi(w_Int2).lngEndDate
                        w_Int2 = w_Int2 + 1
                        w_StartDate = w_udtKinmuchi(w_Int2).lngStartDate
                    Else
                        w_EndDate = w_udtSaiyou(w_Int1).lngEndDate
                        w_Int1 = w_Int1 + 1
                        w_StartDate = w_udtSaiyou(w_Int1).lngStartDate
                    End If
                    g_udtStaffHistory(w_Cnt).lngEndDate = w_EndDate
                    w_Cnt = UBound(g_udtStaffHistory) + 1
                    ReDim Preserve g_udtStaffHistory(w_Cnt)
                    g_udtStaffHistory(w_Cnt).strSaiyouCD = w_udtSaiyou(w_Int1).strCD
                    g_udtStaffHistory(w_Cnt).strKangoTaniCD = w_udtKinmuchi(w_Int2).strCD
                    g_udtStaffHistory(w_Cnt).lngStartDate = w_StartDate
                    g_udtStaffHistory(w_Cnt).lngEndDate = p_lngTo '--- �_�~�[�ŏo�͖������Z�b�g
                Loop
            End With

            '--- ������
            ReDim g_udtHistory(UBound(g_udtStaffHistory))
            subG_udtHistoryInit()

            fncGetSaiyo_Kangotani = True

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' g_udtHistory�z��̏���������
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subG_udtHistoryInit()
        For i As Integer = 0 To g_udtHistory.Length - 1
            g_udtHistory(i).Initialize()
        Next
    End Sub

    ''' <summary>
    ''' �Z�莞���ް����擾����
    ''' </summary>
    ''' <param name="p_lngFrom">p�J�n�N����</param>
    ''' <param name="p_lngTo">p�I���N����</param>
    ''' <returns>�iTRUE�F����AFALSE�F�ُ�j</returns>
    ''' <remarks></remarks>
    Public Function fncGetSanteiTime(ByVal p_intIndex As Short) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "clsNSJP010 fncGetSanteiTime"

        Dim w_i As Short
        Dim w_KinmuIdx As Short
        Dim w_intMax As Short
        Dim w_blnResult As Boolean

        fncGetSanteiTime = False
        Try
            With General.g_objGetData
                .p�Ō�P��CD = g_udtStaffHistory(p_intIndex).strKangoTaniCD
                .p�̗p����CD = g_udtStaffHistory(p_intIndex).strSaiyouCD
                '--- �Ζ����Ԃl��S���擾���邽�߂ɏ�����
                .p�Ζ�CD = ""
                w_blnResult = .mGetKinmuTime '--- �Ζ����ԃ}�X�^�f�[�^�擾

                If w_blnResult = False Then
                    '���ԃ}�X�^�f�[�^�擾�ł��Ȃ��̂Ōv�Z���Ȃ�(���肦�Ȃ�)
                    ReDim g_lngWeeklyHolDate(0)
                    Exit Function
                Else
                    '--- .f�Ζ����Ԍ���
                    w_intMax = .f�Ζ����Ԍ���
                    g_udtHistory(p_intIndex).strSaiyoCD = g_udtStaffHistory(p_intIndex).strSaiyouCD
                    g_udtHistory(p_intIndex).strKinmuDeptCD = g_udtStaffHistory(p_intIndex).strKangoTaniCD

                    '���ԃ}�X�^�擾�����Ɉ�v�����ꍇ
                    For w_i = 1 To w_intMax
                        '----------------------
                        '   �e�Z�莞�� �擾
                        '----------------------
                        .p�Ζ����ԍ��� = w_i

                        '--- .f�Ζ�CD
                        w_KinmuIdx = .f�Ζ�CD

                        '--- �h�����Ζ�CD�ƈ�v����h�����P�����擾
                        If .f�Ζ�CD = G_StrTouchokuKinmuCD Then
                            '�h�����Ζ��P���i�[
                            g_lngTouchokuTanka = .f�h�����P��
                        End If

                        '--- .f�����x���Z�莞��
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).TodayOff = .f�����x���Z�莞��
                        '--- .f�����x���Z�莞��
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).NextOff = .f�����x���Z�莞��
                        '--- .f������ԎZ�莞��
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).Tonight = .f������ԎZ�莞��
                        '--- .f������ԎZ�莞��
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).NextNight = .f������ԎZ�莞��
                        '--- .f�O���J�n����
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).FormalTimeFrom = .f�O���J�n����
                        '--- .f�㔼�I������
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).FormalTimeTo = .f�㔼�I������
                        '--- .f���Ζ�����
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).JituKinmuTime = .f���Ζ�����
                        '--- .f�Ζ�CD
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).KinmuCD = .f�Ζ�CD

                    Next w_i
                End If
            End With
            fncGetSanteiTime = True

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ��x�Ǘ��f�[�^���擾����
    ''' </summary>
    ''' <param name="p_lngFrom">p�J�n�N����</param>
    ''' <param name="p_lngTo">p�I���N����</param>
    ''' <returns>�iTRUE�F����AFALSE�F�ُ�j</returns>
    ''' <remarks></remarks>
    Private Function fncGetDaikyuData(ByVal p_lngFrom As Integer, ByVal p_lngTo As Integer) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "clsNSJP010 fncGetDaikyuData"

        Dim w_strSql As String
        Dim w_Rs As ADODB.Recordset
        Dim w_lngDataCnt As Integer
        Dim w_Idx As Integer
        Dim w_YMD_F As ADODB.Field

        fncGetDaikyuData = False
        Try
            w_strSql = ""
            w_strSql = w_strSql & "SELECT"
            w_strSql = w_strSql & " WorkHolKinmuDate "
            w_strSql = w_strSql & "FROM"
            w_strSql = w_strSql & " NS_DAIKYUMNG_F "
            w_strSql = w_strSql & "WHERE HospitalCD = '" & m_strHospitalCD & "'"
            w_strSql = w_strSql & "  AND StaffMngID = '" & m_strStaffNo & "'"
            w_strSql = w_strSql & "  AND WorkHolKinmuDate >= " & p_lngFrom & " "
            w_strSql = w_strSql & "  AND WorkHolKinmuDate <= " & p_lngTo & " "
            w_strSql = w_strSql & "ORDER BY"
            w_strSql = w_strSql & " WorkHolKinmuDate "

            '�J�[�\���쐬
            w_Rs = General.paDBRecordSetOpen(w_strSql)

            With w_Rs
                If .RecordCount <= 0 Then
                    w_lngDataCnt = 0
                Else
                    .MoveLast()
                    w_lngDataCnt = .RecordCount
                    .MoveFirst()

                    w_YMD_F = .Fields("WorkHolKinmuDate")
                End If

                ReDim Preserve g_lngDaikyuData(w_lngDataCnt)

                For w_Idx = 1 To w_lngDataCnt
                    g_lngDaikyuData(w_Idx) = Integer.Parse(General.paGetDbFieldVal(w_YMD_F, 0))
                    .MoveNext()
                Next w_Idx

                .Close()
            End With



            fncGetDaikyuData = True

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        Finally
            w_Rs = Nothing
        End Try
    End Function


    ''' <summary>
    ''' �Ζ����Ԍv�Z�iHHMM�𕪂ɕϊ�����B��F0300��180�A0301��181�j
    ''' </summary>
    ''' <param name="p_strTime">���ԁiHHMM�j</param>
    ''' <returns>���ԁi���j</returns>
    ''' <remarks></remarks>
    Private Function fncTimeChangeMinute(ByVal p_strTime As String) As String
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "clsNSJP010 fncTimeChangeMinute"

        Dim w_WorkTime As String
        Dim w_lngTime As Integer
        Dim w_lngTime_J As Integer
        Dim w_lngTime_f As Integer
        Dim w_lngChangeTime As Integer

        Try
            w_WorkTime = p_strTime

            If String.IsNullOrEmpty(w_WorkTime) Then
                w_WorkTime = "0"
            End If

            w_lngTime = Integer.Parse(w_WorkTime)

            w_lngTime_J = Integer.Parse(Left(General.paFormatZero(Integer.Parse(w_WorkTime), 4), 2))
            w_lngTime_f = Integer.Parse(Right(General.paFormatZero(Integer.Parse(w_WorkTime), 4), 2))

            '����
            w_lngChangeTime = w_lngTime_J * 60

            '��
            w_lngChangeTime = w_lngChangeTime + w_lngTime_f

            fncTimeChangeMinute = Convert.ToString(w_lngChangeTime)

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        End Try
    End Function


    ''' <summary>
    ''' �Ζ����Ԍv�Z�i����HHMM�ɕϊ�����B��F180��0300�A181��0301�j
    ''' </summary>
    ''' <param name="p_strTime">���ԁi���j</param>
    ''' <returns>���ԁiHHMM�j</returns>
    ''' <remarks></remarks>
    Private Function fncMinuteChangeTime(ByVal p_strTime As String) As String

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "clsNSJP010 fncMinuteChangeTime"

        Dim w_WorkTime As String
        Dim w_lngTime As Integer
        Dim w_lngTime_J As Integer
        Dim w_lngTime_f As Integer

        Dim w_strTime As String
        Try
            w_WorkTime = p_strTime

            If String.IsNullOrEmpty(w_WorkTime) Then
                w_WorkTime = "0"
            End If

            w_lngTime = Integer.Parse(w_WorkTime)

            w_lngTime_J = w_lngTime \ 60
            w_lngTime_f = w_lngTime Mod 60

            w_strTime = General.paFormatZero(w_lngTime_J, 2) & General.paFormatZero(w_lngTime_f, 2)

            fncMinuteChangeTime = w_strTime

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �̗pCD�E�Ō�P��CD�̑g�����ް����擾����
    ''' </summary>
    ''' <param name="p_lngFrom">p�J�n�N����</param>
    ''' <param name="p_lngTo">p�I���N����</param>
    ''' <returns>�iTRUE�F����AFALSE�F�ُ�j</returns>
    ''' <remarks></remarks>
    Public Function fncGetSaiyo_KangotaniOneDay(ByVal p_lngFrom As Integer, ByVal p_lngTo As Integer) As Boolean
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "clsNSJP010 fncGetSaiyo_KangotaniOneDay"


        Dim w_udtSaiyou() As typHistoryData
        Dim w_udtKinmuchi() As typHistoryData

        fncGetSaiyo_KangotaniOneDay = False
        Try
            Erase w_udtSaiyou
            Erase w_udtKinmuchi
            ReDim g_udtHistory(0)

            ReDim g_udtStaffHistory(1)
            g_udtStaffHistory(1).strSaiyouCD = G_StrSaiyoCD
            g_udtStaffHistory(1).strKangoTaniCD = G_StrKinmuDeptCD
            g_udtStaffHistory(1).lngStartDate = p_lngFrom
            g_udtStaffHistory(1).lngEndDate = p_lngTo

            '--- ������
            ReDim g_udtHistory(UBound(g_udtStaffHistory))
            subG_udtHistoryInit()

            fncGetSaiyo_KangotaniOneDay = True

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �Z�莞���ް����擾����
    ''' </summary>
    ''' <param name="p_lngFrom">p�J�n�N����</param>
    ''' <param name="p_lngTo">p�I���N����</param>
    ''' <returns>�iTRUE�F����AFALSE�F�ُ�j</returns>
    ''' <remarks></remarks>
    Public Function fncGetSanteiTimeOneDay(ByVal p_intIndex As Short) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "clsNSJP010 fncGetSanteiTimeOneDay"

        Dim w_i As Short
        Dim w_KinmuIdx As Short
        Dim w_intMax As Short
        Dim w_blnResult As Boolean

        fncGetSanteiTimeOneDay = False
        Try
            With General.g_objGetData
                .p�Ō�P��CD = g_udtStaffHistory(p_intIndex).strKangoTaniCD
                .p�̗p����CD = g_udtStaffHistory(p_intIndex).strSaiyouCD
                '--- �Ζ����Ԃl��S���擾���邽�߂ɏ�����
                .p�Ζ�CD = G_StrKinmuCD
                w_blnResult = .mGetKinmuTime '--- �Ζ����ԃ}�X�^�f�[�^�擾

                If w_blnResult = False Then
                    '���ԃ}�X�^�f�[�^�擾�ł��Ȃ��̂Ōv�Z���Ȃ�(���肦�Ȃ�)
                    ReDim g_lngWeeklyHolDate(0)
                    Exit Function
                Else
                    '--- .f�Ζ����Ԍ���
                    w_intMax = .f�Ζ����Ԍ���
                    g_udtHistory(p_intIndex).Initialize()
                    g_udtHistory(p_intIndex).strSaiyoCD = g_udtStaffHistory(p_intIndex).strSaiyouCD
                    g_udtHistory(p_intIndex).strKinmuDeptCD = g_udtStaffHistory(p_intIndex).strKangoTaniCD

                    '���ԃ}�X�^�擾�����Ɉ�v�����ꍇ
                    For w_i = 1 To w_intMax
                        '----------------------
                        '   �e�Z�莞�� �擾
                        '----------------------
                        .p�Ζ����ԍ��� = w_i

                        '--- .f�Ζ�CD
                        w_KinmuIdx = .f�Ζ�CD

                        '--- �h�����Ζ�CD�ƈ�v����h�����P�����擾
                        If .f�Ζ�CD = G_StrTouchokuKinmuCD Then
                            '�h�����Ζ��P���i�[
                            g_lngTouchokuTanka = .f�h�����P��
                        End If

                        '--- .f�����x���Z�莞��
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).TodayOff = .f�����x���Z�莞��
                        '--- .f�����x���Z�莞��
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).NextOff = .f�����x���Z�莞��
                        '--- .f������ԎZ�莞��
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).Tonight = .f������ԎZ�莞��
                        '--- .f������ԎZ�莞��
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).NextNight = .f������ԎZ�莞��
                        '--- .f�O���J�n����
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).FormalTimeFrom = .f�O���J�n����
                        '--- .f�㔼�I������
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).FormalTimeTo = .f�㔼�I������
                        '--- .f���Ζ�����
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).JituKinmuTime = .f���Ζ�����
                        '--- .f�Ζ�CD
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).KinmuCD = .f�Ζ�CD

                    Next w_i
                End If
            End With
            fncGetSanteiTimeOneDay = True

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �N�x�E�T�����擾����
    ''' </summary>
    ''' <param name="p_From">p�J�n�N����</param>
    ''' <param name="p_To">p�I���N����</param>
    ''' <returns>�N�x�E�T��</returns>
    ''' <remarks></remarks>
    Public Function fncGetGensaiTime(ByVal p_From As Integer, ByVal p_To As Integer) As Boolean
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "clsNSJP010 fncGetGensaiTime"

        Dim w_lngMaxData As Integer
        Dim w_lngIndex As Integer
        Dim w_lngMaxData2 As Integer
        Dim w_lngIndex2 As Integer
        Dim w_date As Date
        Try
            With General.g_objGetData

                .p�E���敪 = 0
                .p�E���ԍ� = m_strStaffNo
                .p���t�敪 = 1
                .p�J�n�N���� = p_From
                .p�I���N���� = p_To

                If .mGetNenkyu = True Then
                    w_lngMaxData = .f�N�x���ԓ���
                    ReDim g_DayNenkyuTime(w_lngMaxData)

                    w_date = General.paGetDateFromDateInteger(p_From)

                    For w_lngIndex = 1 To w_lngMaxData
                        .p�N�x�N���� = General.paGetDateIntegerFromDate(w_date)

                        g_DayNenkyuTime(w_lngIndex).lngDate = General.paGetDateIntegerFromDate(w_date)

                        w_lngMaxData2 = .f�N�x���ʌ���
                        ReDim g_DayNenkyuTime(w_lngIndex).udtData(w_lngMaxData2)

                        For w_lngIndex2 = 1 To w_lngMaxData2

                            .p�N�x���ʍ��� = w_lngIndex2
                            g_DayNenkyuTime(w_lngIndex).udtData(w_lngIndex2).Time = .f�擾����
                            g_DayNenkyuTime(w_lngIndex).udtData(w_lngIndex2).CD = .f�N�x�x�ݕ���CD
                        Next w_lngIndex2

                        w_date = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_date)
                    Next w_lngIndex

                End If

                .p�E���敪 = 0
                .p�E���ԍ� = m_strStaffNo
                .p���t�敪 = 1
                .p�J�n�N���� = p_From
                .p�I���N���� = p_To
                If .mGetKinmuDetail = True Then

                    w_lngMaxData = .f�Ζ��ڍ׊��ԓ���
                    ReDim g_DayKoujoTime(w_lngMaxData)

                    w_date = General.paGetDateFromDateInteger(p_From)

                    For w_lngIndex = 1 To w_lngMaxData
                        .p�Ζ��ڍהN���� = General.paGetDateIntegerFromDate(w_date)

                        g_DayKoujoTime(w_lngIndex).lngDate = General.paGetDateIntegerFromDate(w_date, General.G_DATE_ENUM.yyyyMMdd)

                        w_lngMaxData2 = .f�Ζ��ڍד��ʌ���
                        ReDim g_DayKoujoTime(w_lngIndex).udtData(w_lngMaxData2)

                        For w_lngIndex2 = 1 To w_lngMaxData2

                            .p�Ζ��ڍד��ʍ��� = w_lngIndex2
                            g_DayKoujoTime(w_lngIndex).udtData(w_lngIndex2).Time = .f�T������
                            g_DayKoujoTime(w_lngIndex).udtData(w_lngIndex2).CD = .f�Ζ��ڍ�CD
                        Next w_lngIndex2

                        w_date = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_date)
                    Next w_lngIndex
                End If
            End With

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �����Ɏ��ԁi���j�ƒ[�������敪���󂯎��A�[��������̎��ԁi���j��Ԃ�<br />
    ''' ���ԁi���j����������HHMM�`���ɕϊ����AMM��[�������敪�ɂ�菈������B<br />
    ''' ���؏グ��HH+1�AMM��0�ɂ��āA�؎̂Ă�MM��0�ɂ��āA�ēx���ԁi���j�`���ɕϊ����ĕԂ�
    ''' </summary>
    ''' <param name="p_lngMinute">���ԁi���j</param>
    ''' <param name="p_strKBN">�[�������敪�i2�F�؏グ�A3�F�؎̂āA����ȊO�F���̂܂܁j</param>
    ''' <returns>���ԁi���j</returns>
    ''' <remarks></remarks>
    Private Function TimeRound(ByVal p_lngMinute As Integer, ByVal p_strKBN As String) As Integer
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "NSW0300C TimeRound"

        Dim w_lngHH As Integer
        Dim w_lngMM As Integer
        Try
            w_lngHH = p_lngMinute \ 60
            w_lngMM = p_lngMinute Mod 60

            Select Case p_strKBN
                '�؏グ
                Case "2"
                    If w_lngMM > 0 Then
                        w_lngHH = w_lngHH + 1
                        w_lngMM = 0
                    End If
                    '�؎̂�
                Case "3"
                    If w_lngMM > 0 Then
                        w_lngMM = 0
                    End If
                    '���̂܂�
                Case Else

            End Select

            TimeRound = w_lngHH * 60 + w_lngMM

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ԊO�͏o�݌v�e���擾����
    ''' </summary>
    ''' <returns>�iTRUE�F����AFALSE�F�ُ�j</returns>
    ''' <remarks></remarks>
    Public Function fncGetOKAppliRuikei() As Boolean


        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
        General.g_ErrorProc = "NSW0300C fncGetOKAppliRuikei"

        Dim w_strSql As String
        Dim w_Rs As ADODB.Recordset
        Dim w_strAddFlg As String
        Dim w_strYYYYMM As String
        Dim w_lngCnt As Integer
        Dim w_lngLoop As Integer

        fncGetOKAppliRuikei = False
        Try
            '�����O�K�v�f�[�^�擾
            w_strAddFlg = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY13, "REEMPLOYADDFLG", "0", m_strHospitalCD)
            w_strYYYYMM = Left(Convert.ToString(m_lngStartDate), 6)

            '���ԊO�͏o�݌v�e���擾
            w_strSql = ""
            w_strSql = w_strSql & "SELECT APPLITIME,"
            w_strSql = w_strSql & "       DECISIONTIME"
            w_strSql = w_strSql & " FROM NS_OVERKINMUAPPLIRUIKEI_F"
            w_strSql = w_strSql & " WHERE HOSPITALCD = '" & m_strHospitalCD & "'"
            w_strSql = w_strSql & "   AND STAFFMNGID = '" & m_strStaffNo & "'"
            w_strSql = w_strSql & "   AND TARGETDATE = '" & w_strYYYYMM & "'"
            If ("0").Equals(w_strAddFlg) Then
                w_strSql = w_strSql & " AND EMPDATE <= " & m_lngStartDate
            End If
            w_strSql = w_strSql & " ORDER BY EMPDATE DESC"

            '�J�[�\���쐬
            w_Rs = General.paDBRecordSetOpen(w_strSql)

            With w_Rs
                If .RecordCount <= 0 Then
                    Exit Function
                Else
                    .MoveLast()
                    w_lngCnt = .RecordCount
                    .MoveFirst()

                    '���Z����̂��ǂ���
                    If ("0").Equals(w_strAddFlg) Then
                        m_lngAppliTime = Integer.Parse(General.paGetDbFieldVal(.Fields("APPLITIME"), 0))
                        m_lngDecisionTime = Integer.Parse(General.paGetDbFieldVal(.Fields("DECISIONTIME"), 0))
                    Else
                        For w_lngLoop = 1 To w_lngCnt
                            m_lngAppliTime = Integer.Parse(m_lngAppliTime + General.paGetDbFieldVal(.Fields("APPLITIME"), 0))
                            m_lngDecisionTime = Integer.Parse(m_lngDecisionTime + General.paGetDbFieldVal(.Fields("DECISIONTIME"), 0))

                            .MoveNext()
                        Next w_lngLoop
                    End If
                End If

                .Close()
            End With

            w_Rs = Nothing

            fncGetOKAppliRuikei = True

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            Throw
        End Try
    End Function


    ''' <summary>
    ''' �f�[�^�擾���i���Z�b�g����
    ''' </summary>
    ''' <param name="Value">�f�[�^�擾���i</param>
    ''' <remarks></remarks>
    Public WriteOnly Property pGetDataObj() As Object
        Set(ByVal Value As Object)
            General.g_objGetData = Value
        End Set
    End Property

    ''' <summary>
    ''' �a�@CD���Z�b�g����
    ''' </summary>
    ''' <param name="Value">�a�@CD</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p�a�@CD() As String
        Set(ByVal Value As String)

            General.g_ErrorProc = "clsStaffData p�a�@CD"
            Try
                m_strHospitalCD = Value
            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p�E���敪���Z�b�g����
    ''' </summary>
    ''' <param name="Value">p�E���敪</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p�E���敪() As Integer
        Set(ByVal Value As Integer)

            General.g_ErrorProc = "clsStaffData p�E���敪"
            Try
                m_lngStaffKbn = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p�E���ԍ����Z�b�g����
    ''' </summary>
    ''' <param name="Value">p�E���ԍ�</param>
    ''' <remarks>
    ''' �E���敪=0�̏ꍇ�A�󂯎�����E���ԍ��͐E���Ǘ��ԍ��Ƃ݂Ȃ�<br />
    ''' �E���敪=1�̏ꍇ�A�󂯎�����E���ԍ��͕\���p�̐E���ԍ��Ƃ݂Ȃ�
    ''' </remarks>
    Public WriteOnly Property p�E���ԍ�() As String
        Set(ByVal Value As String)
            General.g_ErrorProc = "clsStaffData p�E���ԍ�"
            Try
                m_strStaffNo = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' �J�n�N�������Z�b�g����
    ''' </summary>
    ''' <param name="Value">�J�n�N����</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p�J�n�N����() As Integer
        Set(ByVal Value As Integer)

            General.g_ErrorProc = "clsStaffData p�J�n�N����"
            Try
                m_lngStartDate = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' �I���N�������Z�b�g����
    ''' </summary>
    ''' <param name="Value">�I���N����</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p�I���N����() As Integer
        Set(ByVal Value As Integer)
            Try
                General.g_ErrorProc = "clsStaffData p�I���N����"

                m_lngEndDate = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' ���t�敪���Z�b�g����
    ''' </summary>
    ''' <param name="Value">���t�敪�i0:�P����A1:���ԁj</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p���t�敪() As Integer
        Set(ByVal Value As Integer)
            Try
                General.g_ErrorProc = "clsStaffData p���t�敪"

                '0:�P��� 1:����
                m_lngHidukeKbn = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p�Ώ�CD���Z�b�g����
    ''' </summary>
    ''' <param name="Value">p�Ώ�CD</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p�Ώ�CD() As String
        Set(ByVal Value As String)
            Try
                General.g_ErrorProc = "clsStaffData p�Ώ�CD"

                m_strTargetCD = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    '*********************************************************************************
    '�Ζ����сE���΃f�[�^�擾���i START
    '*********************************************************************************

    ''' <summary>
    ''' p�����Ζ�CD���Z�b�g����
    ''' </summary>
    ''' <param name="Value">p�����Ζ�CD</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p�����Ζ�CD() As String
        Set(ByVal Value As String)
            Try
                General.g_ErrorProc = "clsStaffData p�����Ζ�CD"

                G_StrTouchokuKinmuCD = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p�N�������Z�b�g����
    ''' </summary>
    ''' <param name="Value">p�N�����i0:�P����A1:���ԁj</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p�N����() As Integer
        Set(ByVal Value As Integer)
            Try
                General.g_ErrorProc = "clsStaffData p�N����"

                Dim w_blnRc As Boolean

                '���t�敪
                Select Case m_lngHidukeKbn
                    Case 0 '�P���
                        '�Q�ƔN������ݒ�
                        If Value >= m_lngStartDate Then
                            g_lngJissekiChokinDate = Value
                            g_lngJissekiChokinDataDate = Value
                        Else
                            g_lngJissekiChokinDate = 0
                            g_lngJissekiChokinDataDate = 0
                            Exit Property
                        End If

                    Case 1 '����
                        '�Q�ƔN������ݒ�
                        If Value >= m_lngStartDate AndAlso Value <= m_lngEndDate Then
                            g_lngJissekiChokinDate = Value
                            g_lngJissekiChokinDataDate = Value
                        Else
                            g_lngJissekiChokinDate = 0
                            g_lngJissekiChokinDataDate = 0
                            Exit Property
                        End If
                End Select

                '�\��f�[�^����
                w_blnRc = fncblnJissekiChokinKensaku()

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p���Ύ��ԍ������Z�b�g����
    ''' </summary>
    ''' <param name="Value">p���Ύ��ԍ���</param>
    ''' <remarks>p���Ύ��ԍ��������΃f�[�^�����̏ꍇ�Z�b�g���Ȃ�</remarks>
    Public WriteOnly Property p���Ύ��ԍ���() As Short
        Set(ByVal Value As Short)
            Try
                General.g_ErrorProc = "clsStaffData p���Ύ��ԍ���"

                '�f�[�^�����Ƃ̔�r
                If Value > g_lngChokinKensu Then
                    Exit Property
                End If
                '--- ���Ύ��ԍ����̎擾
                g_lngChokinIndex = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' �̗pCD���Z�b�g����
    ''' </summary>
    ''' <param name="Value">�̗pCD</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p�̗pCD() As String
        Set(ByVal Value As String)
            Try
                General.g_ErrorProc = "clsStaffData p�̗pCD"

                G_StrSaiyoCD = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p�Ζ�����CD���Z�b�g����
    ''' </summary>
    ''' <param name="Value">p�Ζ�����CD</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p�Ζ�����CD() As String
        Set(ByVal Value As String)
            Try
                General.g_ErrorProc = "clsStaffData p�Ζ�����CD"

                G_StrKinmuDeptCD = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property
    '==========================================================================================================


    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '_/_/_/                                 �@�J��@�Ή��ǉ���                                         _/_/_/
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '************************�f�[�^�擾���i��޼ުāiNSW0000C�j****************************

    ''' <summary>
    ''' ���ԊO�擾���i���Z�b�g����
    ''' </summary>
    ''' <param name="Value">���ԊO�擾���i</param>
    ''' <remarks></remarks>
    Public WriteOnly Property pGetCyokinObj() As Object
        Set(ByVal Value As Object)
            General.g_objComCyokin = Value
        End Set
    End Property

    ''' <summary>
    ''' ���΃f�[�^�̎擾�w��
    ''' �E���P�ʂŒ��΃f�[�^���擾����O�ɕK�����s����
    ''' </summary>
    ''' <param name="p_strDateJudgment">���΃f�[�^�̓��t����i�O�F�N�����A�P�F���ΔN�����j���ȗ�����0�Ŕ���</param>
    ''' <returns>�iTRUE�F�f�[�^����AFALSE�F0�����̓f�[�^�Ȃ��j</returns>
    ''' <remarks></remarks>
    Public Function mOverKinmuInit(Optional ByVal p_strDateJudgment As String = "") As Boolean

        General.g_ErrorProc = "clsStaffData mOverKinmuInit"

        Dim w_str As String
        Dim w_var As Object
        Dim w_var2 As Object
        Dim w_var3 As Object
        Dim w_lngLoop As Integer
        Dim w_lngLoop2 As Integer

        mOverKinmuInit = False
        Try
            '--- ���ڐݒ�̎擾
            '��x�Ǘ��i�O�F����A�P�F���Ȃ��j
            G_StrDaikyuMng = General.paGetItemValue(General.G_STRMAINKEY2, General.G_STRSUBKEY5, "DAIKYUMNG", "1", m_strHospitalCD)

            If String.IsNullOrEmpty(p_strDateJudgment) Then
                '���΃f�[�^�̓��t����i�O�F�N�����A�P�F���ΔN�����j
                G_StrDateJudgment = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "DATEJUDGMENT", "0", m_strHospitalCD)
            Else
                G_StrDateJudgment = p_strDateJudgment
            End If

            '�T�x
            G_StrWeekHolCD = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "WEEKHOLIDAY", "", m_strHospitalCD)
            '�����x���o�Ή��i�O�F����A�P�F���Ȃ��j
            G_StrAutoHoliday = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "AUTOHOLIDAY", "1", m_strHospitalCD)

            '�������Ԍ��Z�ΏۍT��
            w_str = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "WORKTIMECALCKOJYOBUNRUICD", "", m_strHospitalCD)
            w_var = General.paSplit(w_str, ",")

            ReDim m_JitsuCalcKojyoBunruiCD(UBound(w_var) + 1)

            For w_lngLoop = 0 To UBound(w_var)
                w_var2 = General.paSplit(w_var(w_lngLoop), ";")
                w_str = w_var2(0)
                m_JitsuCalcKojyoBunruiCD(w_lngLoop + 1).strKBN = w_var2(1)
                w_var3 = General.paSplit(w_str, "+")
                For w_lngLoop2 = 0 To UBound(w_var3)
                    m_JitsuCalcKojyoBunruiCD(w_lngLoop + 1).strCD = m_JitsuCalcKojyoBunruiCD(w_lngLoop + 1).strCD & General.paFormatSpace(w_var3(w_lngLoop2), 2) & ","
                Next w_lngLoop2
            Next w_lngLoop

            '�������Ԍ��Z�Ώێ��ԋx
            w_str = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "WORKTIMECALCHOLIDAYBUNRUICD", "", m_strHospitalCD)
            w_var = General.paSplit(w_str, ",")

            ReDim m_JitsuCalcHolBunruiCD(UBound(w_var) + 1)

            For w_lngLoop = 0 To UBound(w_var)
                w_var2 = General.paSplit(w_var(w_lngLoop), ";")
                w_str = w_var2(0)
                m_JitsuCalcHolBunruiCD(w_lngLoop + 1).strKBN = w_var2(1)
                w_var3 = General.paSplit(w_str, "+")
                For w_lngLoop2 = 0 To UBound(w_var3)
                    m_JitsuCalcHolBunruiCD(w_lngLoop + 1).strCD = m_JitsuCalcHolBunruiCD(w_lngLoop + 1).strCD & General.paFormatSpace(w_var3(w_lngLoop2), 2) & ","
                Next w_lngLoop2
            Next w_lngLoop

            '100/100�������Ԍ��Z�ΏۍT��
            w_str = General.paGetItemValue(General.G_STRMAINKEY3, "WORKTIMESET", "100TIMECALCKOJYOBUNRUICD", "", m_strHospitalCD)
            w_var = General.paSplit(w_str, ",")

            ReDim m_100CalcKojyoBunruiCD(UBound(w_var) + 1)

            For w_lngLoop = 0 To UBound(w_var)
                w_var2 = General.paSplit(w_var(w_lngLoop), ";")
                w_str = w_var2(0)
                m_100CalcKojyoBunruiCD(w_lngLoop + 1).strKBN = w_var2(1)
                w_var3 = General.paSplit(w_str, "+")
                For w_lngLoop2 = 0 To UBound(w_var3)
                    m_100CalcKojyoBunruiCD(w_lngLoop + 1).strCD = m_100CalcKojyoBunruiCD(w_lngLoop + 1).strCD & General.paFormatSpace(w_var3(w_lngLoop2), 2) & ","
                Next w_lngLoop2
            Next w_lngLoop

            '100/100�������Ԍ��Z�Ώێ��ԋx
            w_str = General.paGetItemValue(General.G_STRMAINKEY3, "WORKTIMESET", "100TIMECALCHOLIDAYBUNRUICD", "", m_strHospitalCD)
            w_var = General.paSplit(w_str, ",")

            ReDim m_100CalcHolBunruiCD(UBound(w_var) + 1)

            For w_lngLoop = 0 To UBound(w_var)
                w_var2 = General.paSplit(w_var(w_lngLoop), ";")
                w_str = w_var2(0)
                m_100CalcHolBunruiCD(w_lngLoop + 1).strKBN = w_var2(1)
                w_var3 = General.paSplit(w_str, "+")
                For w_lngLoop2 = 0 To UBound(w_var3)
                    m_100CalcHolBunruiCD(w_lngLoop + 1).strCD = m_100CalcHolBunruiCD(w_lngLoop + 1).strCD & General.paFormatSpace(w_var3(w_lngLoop2), 2) & ","
                Next w_lngLoop2
            Next w_lngLoop

            '2010/04/08 Y.Iguchi Add Start
            '�@�莞�ԊO�z���ΏۊO�Ζ��R�[�h
            G_StrNot60TimeKinmuCD = ""
            w_str = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "LEGALHOLIDAYKINMUCD", "", m_strHospitalCD)
            w_var = General.paSplit(w_str, ",")
            For w_lngLoop = 0 To UBound(w_var)
                G_StrNot60TimeKinmuCD = G_StrNot60TimeKinmuCD & General.paFormatSpace(w_var(w_lngLoop), 3) & ","
            Next w_lngLoop
            '�@�莞�ԏ������
            g_lng60Time = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "LIMITTIME", "3600", m_strHospitalCD)
            '100/100���Z�t���O
            g_100AddFlg = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY13, "100TANKAADDFLG", "0", m_strHospitalCD)

            '�����x���o�Ή��ΏۋΖ�CD�̎擾�i�Ζ��敪���u�Ζ��v�Łu�S���v�j
            Call subGetAutoHolidayKinmuCD()

            '�x����� �擾
            Call subGetHolidayData()

            mOverKinmuInit = True
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ыΖ��E���΃f�[�^�̎擾�w��
    ''' �a�@CD�A�E���ԍ����w���Ɏ��s����B
    ''' </summary>
    ''' <returns>�iTRUE�F�f�[�^����AFALSE�F0�����̓f�[�^�Ȃ��j</returns>
    ''' <remarks></remarks>
    Public Function mGetOverKinmuData() As Boolean

        Dim w_lngFrom As Integer
        Dim w_lngTo As Integer
        Dim w_Cnt As Short

        General.g_ErrorProc = "clsStaffData mGetOverKinmuData"

        mGetOverKinmuData = False
        Try
            g_lngJissekiChokinKensu = 0

            '�T�x���̔z�� ������
            ReDim g_lngWeeklyHolDate(0)

            If m_lngHidukeKbn = 0 Then
                '���t�敪���P����̏ꍇ
                w_lngFrom = m_lngStartDate
                w_lngTo = m_lngStartDate
            Else
                '���t�敪�����Ԃ̏ꍇ
                w_lngFrom = m_lngStartDate
                w_lngTo = m_lngEndDate
            End If

            '�J�n���������̏ꍇ�A�J�n���̌��̃f�[�^�͎擾���Ȃ�
            If "01".Equals(Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, General.paGetDateFromDateInteger(w_lngFrom)), "dd")) Then
            Else
                w_lngFrom = Integer.Parse(General.paGetDateStringFromInteger(w_lngFrom, General.G_DATE_ENUM.yyyyMM) & "01")
                w_lngFrom = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, General.paGetDateFromDateInteger(w_lngFrom)), General.G_DATE_ENUM.yyyyMMdd)
            End If
            '2010/04/08 Y.Iguchi Add End##

            '--- �o�͑ΏېE�����̎擾
            '�̗p�E�Ō�P��CD�̑g�����ް� �擾
            Call fncGetSaiyo_Kangotani(w_lngFrom, w_lngTo)

            '--- �擾�����̗p�E�Ō�P��CD�̑g��������Ζ����ԃf�[�^���擾
            For w_Cnt = 1 To UBound(g_udtStaffHistory)
                Call fncGetSanteiTime(w_Cnt)
            Next w_Cnt

            '������������������������������������������������������������������������������
            '   ���уf�[�^�̎擾
            '������������������������������������������������������������������������������
            '�����ް� �擾
            If fncGetJissekiData(w_lngFrom, w_lngTo) = False Then Exit Function

            '������������������������������������������������������������������������������
            '   ���΃f�[�^�̎擾
            '������������������������������������������������������������������������������
            '�����ް� �擾
            If fncGetCyokinData(w_lngFrom, w_lngTo) = False Then Exit Function

            If g_lngJissekiChokinKensu = 0 Then Exit Function

            mGetOverKinmuData = True
        Catch ex As Exception
            Throw
        End Try
    End Function

    '*********************************************************************************
    '�Ζ����сE���΃f�[�^�擾���i START
    '*********************************************************************************

    ''' <summary>
    ''' �����P�����擾����
    ''' </summary>
    ''' <returns>�����P��</returns>
    ''' <remarks></remarks>
    Public Function f�����P��() As Integer
        Try
            General.g_ErrorProc = "clsStaffData f�����P��"

            f�����P�� = g_lngTouchokuTanka

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �N�������擾����
    ''' </summary>
    ''' <returns>�N����</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f�N����() As Integer
        Try
            General.g_ErrorProc = "clsStaffData f�N����"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f�N���� = 0
            Else
                f�N���� = g_udtJissekiChokin(g_lngJissekiChokinIndex).lngYMD
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �Ζ����сE���΃f�[�^�������擾����
    ''' </summary>
    ''' <returns>�Ζ����сE���΃f�[�^����</returns>
    ''' <remarks></remarks>
    Public Function f���ђ��Ό���() As Integer
        Try
            General.g_ErrorProc = "clsStaffData f���ђ��Ό���"

            f���ђ��Ό��� = g_lngJissekiChokinKensu

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ыΖ�CD���擾����
    ''' </summary>
    ''' <returns>���ыΖ�CD</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���ыΖ�CD() As String
        Try
            General.g_ErrorProc = "clsStaffData f���ыΖ�CD"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f���ыΖ�CD = ""
            Else
                f���ыΖ�CD = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuCD
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ыΖ����̂��擾����
    ''' </summary>
    ''' <returns>���ыΖ�����</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���ыΖ�����() As String
        Try
            General.g_ErrorProc = "clsStaffData f���ыΖ�����"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f���ыΖ����� = ""
            Else
                f���ыΖ����� = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuNM
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ыΖ��L�����擾����
    ''' </summary>
    ''' <returns>���ыΖ��L��</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���ыΖ��L��() As String
        Try
            General.g_ErrorProc = "clsStaffData f���ыΖ��L��"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f���ыΖ��L�� = ""
            Else
                f���ыΖ��L�� = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuMark
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ї��R�敪���擾����
    ''' </summary>
    ''' <returns>���ї��R�敪</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���ї��R�敪() As String
        Try
            General.g_ErrorProc = "clsStaffData f���ї��R�敪"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f���ї��R�敪 = ""
            Else
                f���ї��R�敪 = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuRKbn
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���є����Ζ�FLG���擾����
    ''' </summary>
    ''' <returns>���є����Ζ�FLG</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���є����Ζ�FLG() As String
        Try
            General.g_ErrorProc = "clsStaffData f���є����Ζ�FLG"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f���є����Ζ�FLG = ""
            Else
                f���є����Ζ�FLG = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiHalfKinmuFlg
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function
    '------------------------------------------------------------------------------------------------------

    ''' <summary>
    ''' ���ыΖ�����FROM���擾����
    ''' </summary>
    ''' <returns>���ыΖ�����FROM</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���ыΖ�����FROM() As String
        Try
            General.g_ErrorProc = "clsStaffData f���ыΖ�����FROM"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f���ыΖ�����FROM = ""
            Else
                f���ыΖ�����FROM = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuTime.strFrom
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ыΖ�����TO���擾����
    ''' </summary>
    ''' <returns>���ыΖ�����TO</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���ыΖ�����TO() As String
        Try
            General.g_ErrorProc = "clsStaffData f���ыΖ�����TO"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f���ыΖ�����TO = ""
            Else
                f���ыΖ�����TO = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuTime.strTo
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ю��Ζ����Ԃ��擾����
    ''' </summary>
    ''' <returns>���ю��Ζ�����</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���ю��Ζ�����() As String
        Try
            General.g_ErrorProc = "clsStaffData f���ю��Ζ�����"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f���ю��Ζ����� = ""
            Else
                f���ю��Ζ����� = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiJituKinmuTime
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���Ύ��Ԍ������擾����
    ''' </summary>
    ''' <returns>���Ύ��Ԍ���</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f���Ύ��Ԍ���() As Short
        Try
            General.g_ErrorProc = "clsStaffData f���Ύ��Ԍ���"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                g_lngChokinKensu = 0
            Else
                g_lngChokinKensu = UBound(g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinTime)
            End If
            f���Ύ��Ԍ��� = g_lngChokinKensu

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���Ύ���FROM���擾����
    ''' </summary>
    ''' <returns>���Ύ���FROM</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���Ύ���FROM() As String
        Try
            General.g_ErrorProc = "clsStaffData f���Ύ���FROM"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���Ύ���FROM = ""
            Else
                f���Ύ���FROM = g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinTime(g_lngChokinIndex).strFrom
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    '--- 2004.01.05 Add kuro ---

    ''' <summary>
    ''' ���΋Ζ��N�������擾����
    ''' </summary>
    ''' <returns>���΋Ζ��N����</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f���΋Ζ��N����() As Integer
        Try
            General.g_ErrorProc = "clsStaffData f���΋Ζ��N����"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���΋Ζ��N���� = 0
            Else
                f���΋Ζ��N���� = g_udtJissekiChokin(g_lngJissekiChokinIndex).lngChokinOrderDate(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function
    '---------------------------

    ''' <summary>
    ''' ���Ώ�ԋ敪���擾����
    ''' </summary>
    ''' <returns>���Ώ�ԋ敪</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���Ώ�ԋ敪() As String
        Try
            General.g_ErrorProc = "clsStaffData f���Ώ�ԋ敪"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���Ώ�ԋ敪 = ""
            Else
                f���Ώ�ԋ敪 = g_udtJissekiChokin(g_lngJissekiChokinIndex).strApproveKbn(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���Ύ���TO���擾����
    ''' </summary>
    ''' <returns>���Ύ���TO</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���Ύ���TO() As String
        Try
            General.g_ErrorProc = "clsStaffData f���Ύ���TO"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���Ύ���TO = ""
            Else
                f���Ύ���TO = g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinTime(g_lngChokinIndex).strTo
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function


    ''' <summary>
    ''' ����UNIQUESEQNO���擾����
    ''' </summary>
    ''' <returns>����UNIQUESEQNO</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f����UNIQUESEQNO() As String
        Try
            General.g_ErrorProc = "clsStaffData f����UNIQUESEQNO"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f����UNIQUESEQNO = ""
            Else
                f����UNIQUESEQNO = g_udtJissekiChokin(g_lngJissekiChokinIndex).strUniqueSeqNo(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function


    ''' <summary>
    ''' ���ߋΖ�����100���擾����
    ''' </summary>
    ''' <returns>���ߋΖ�����100</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f���ߋΖ�����100() As Short
        Try
            General.g_ErrorProc = "clsStaffData f���ߋΖ�����100"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���ߋΖ�����100 = 0
            Else
                f���ߋΖ�����100 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime100(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function


    ''' <summary>
    ''' ���ߋΖ�����125���擾����
    ''' </summary>
    ''' <returns>���ߋΖ�����125</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f���ߋΖ�����125() As Short
        Try
            General.g_ErrorProc = "clsStaffData f���ߋΖ�����125"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���ߋΖ�����125 = 0
            Else
                f���ߋΖ�����125 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime125(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ߋΖ�����135���擾����
    ''' </summary>
    ''' <returns>���ߋΖ�����135</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f���ߋΖ�����135() As Short
        Try
            General.g_ErrorProc = "clsStaffData f���ߋΖ�����135"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���ߋΖ�����135 = 0
            Else
                f���ߋΖ�����135 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime135(g_lngChokinIndex)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ߋΖ�����150���擾����
    ''' </summary>
    ''' <returns>���ߋΖ�����150</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f���ߋΖ�����150() As Short
        Try
            General.g_ErrorProc = "clsStaffData f���ߋΖ�����150"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���ߋΖ�����150 = 0
            Else
                f���ߋΖ�����150 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime150(g_lngChokinIndex)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ߋΖ�����160���擾����
    ''' </summary>
    ''' <returns>���ߋΖ�����160</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f���ߋΖ�����160() As Short
        Try
            General.g_ErrorProc = "clsStaffData f���ߋΖ�����160"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���ߋΖ�����160 = 0
            Else
                f���ߋΖ�����160 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime160(g_lngChokinIndex)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �x���Ζ����Ԃ��擾����
    ''' </summary>
    ''' <returns>�x���Ζ�����</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f�x���Ζ�����() As Short
        Try
            General.g_ErrorProc = "clsStaffData f�x���Ζ�����"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f�x���Ζ����� = 0
            Else
                f�x���Ζ����� = g_udtJissekiChokin(g_lngJissekiChokinIndex).intHolidayTime
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ��ԋΖ����Ԃ��擾����
    ''' </summary>
    ''' <returns>��ԋΖ�����</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f��ԋΖ�����() As Short
        Try
            General.g_ErrorProc = "clsStaffData f��ԋΖ�����"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f��ԋΖ����� = 0
            Else
                f��ԋΖ����� = g_udtJissekiChokin(g_lngJissekiChokinIndex).intNightTime
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���Η��RCD���擾����
    ''' </summary>
    ''' <returns>���Η��RCD</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���Η��RCD() As String
        Try
            General.g_ErrorProc = "clsStaffData f���Η��RCD"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���Η��RCD = ""
            Else
                f���Η��RCD = g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinRiyu(g_lngChokinIndex).strRiyuCD
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���Η��R���̂��擾����
    ''' </summary>
    ''' <returns>���Η��R����</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���Η��R����() As String
        Try
            General.g_ErrorProc = "clsStaffData f���Η��R����"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���Η��R���� = ""
            Else
                f���Η��R���� = g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinRiyu(g_lngChokinIndex).strRiyuNM
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���Η��R���̂��擾����
    ''' </summary>
    ''' <returns>���Η��R����</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A""���擾����</remarks>
    Public Function f���Η��R����() As String
        Try
            General.g_ErrorProc = "clsStaffData f���Η��R����"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���Η��R���� = ""
            Else
                f���Η��R���� = g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinRiyu(g_lngChokinIndex).strRiyuRNM
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �O������
    ''' �Q�Ɠ��t��O���Ɉړ�����
    ''' </summary>
    ''' <returns>�iTRUE�F�f�[�^����AFALSE�F0�����̓f�[�^�Ȃ��j</returns>
    ''' <remarks>���t�敪���P����̏ꍇ�A�������f<br />
    '''          �Q�ƔN�����������̏ꍇ�A�������f<br />
    '''          �f�[�^�����N����-1���J�n�N������菬�����ꍇ�A�������f
    ''' </remarks>
    Public Function m�O������() As Boolean

        General.g_ErrorProc = "cls�E���ʋΖ� m�O������"

        Dim w_strData As String
        Dim w_blnRc As Boolean

        m�O������ = False
        Try
            '���t�敪���P����Ȃ珈�����f
            If m_lngHidukeKbn = 0 Then
                Exit Function
            End If

            '�Q�ƔN�����������������Ȃ珈�����f
            If g_lngJissekiChokinDate = 0 Then
                Exit Function
            End If

            '�f�[�^�����N����-1���J�n�N������菬������Ώ������f
            w_strData = General.paGetDateStringFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, General.paGetDateFromDateInteger(g_lngJissekiChokinDataDate)), General.G_DATE_ENUM.yyyyMMdd)
            If m_lngStartDate > Integer.Parse(w_strData) Then
                Exit Function
            End If

            g_lngJissekiChokinDataDate = Integer.Parse(w_strData)

            '�\�茟��
            w_blnRc = fncblnJissekiChokinKensaku()
            If w_blnRc = False Then
                Exit Function
            End If

            m�O������ = True

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ��������
    ''' �Q�Ɠ��t�𗂓��Ɉړ�����
    ''' </summary>
    ''' <returns>�iTRUE�F�f�[�^����AFALSE�F0�����̓f�[�^�Ȃ��j</returns>
    ''' <remarks>���t�敪���P����̏ꍇ�A�������f<br />
    '''          �Q�ƔN�����������̏ꍇ�A�������f<br />
    '''          �f�[�^�����N����+1���J�n�N�������傫���ꍇ�A�������f
    ''' </remarks>
    Public Function m��������() As Boolean

        General.g_ErrorProc = "cls�E���ʋΖ� m��������"

        Dim w_strData As String
        Dim w_blnRc As Boolean

        m�������� = False
        Try
            '���t�敪���P����Ȃ珈�����f
            If m_lngHidukeKbn = 0 Then
                Exit Function
            End If

            '�Q�ƔN�����������������Ȃ珈�����f
            If g_lngJissekiChokinDate = 0 Then
                Exit Function
            End If

            '�f�[�^�����N����+1���I���N�������傫����Ώ������f
            w_strData = General.paGetDateStringFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, General.paGetDateFromDateInteger(g_lngJissekiChokinDataDate)), General.G_DATE_ENUM.yyyyMMdd)
            If m_lngEndDate < Integer.Parse(w_strData) Then
                Exit Function
            End If

            g_lngJissekiChokinDataDate = Integer.Parse(w_strData)

            '�\�茟��
            w_blnRc = fncblnJissekiChokinKensaku()
            If w_blnRc = False Then
                Exit Function
            End If

            m�������� = True

        Catch ex As Exception
            Call General.paDllTrpMsg(Err.Description, General.g_ErrorProc)
            Throw
        End Try
    End Function

    Private Sub Class_Terminate_Renamed()

        '���I�z��̉��
        Erase g_lngHolidayData
        Erase g_lngWeeklyHolDate
        Erase g_lngDaikyuData
        Erase g_udtStaffHistory
        Erase g_udtHistory
        Erase g_udtJissekiChokin

    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub

    ''' <summary>
    ''' ���ыΖ��E���΃f�[�^�̎擾�w��(�Y�����̃f�[�^�݂̂��擾����)
    ''' �a�@CD�A�E���ԍ��A�̗p�R�[�h�A�Ζ������R�[�h���w���Ɏ��s����B
    ''' </summary>
    ''' <returns>�iTRUE�F�f�[�^����AFALSE�F0�����̓f�[�^�Ȃ��j</returns>
    ''' <remarks></remarks>
    Public Function mGetOverKinmuDataOneDay() As Boolean

        Dim w_lngFrom As Integer
        Dim w_lngTo As Integer
        Dim w_Cnt As Short

        General.g_ErrorProc = "clsStaffData mGetOverKinmuDataOneDay"

        mGetOverKinmuDataOneDay = False
        Try
            g_lngJissekiChokinKensu = 0

            '�̗p�R�[�h�K�{�`�F�b�N
            If String.IsNullOrEmpty(G_StrSaiyoCD) Then Exit Function

            '�Ζ������R�[�h�K�{�`�F�b�N
            If String.IsNullOrEmpty(G_StrKinmuDeptCD) Then Exit Function

            '�T�x���̔z�� ������
            ReDim g_lngWeeklyHolDate(0)

            If m_lngHidukeKbn = 0 Then
                '���t�敪���P����̏ꍇ
                w_lngFrom = m_lngStartDate
                w_lngTo = m_lngStartDate
            Else
                '���t�敪�����Ԃ̏ꍇ
                w_lngFrom = m_lngStartDate
                w_lngTo = m_lngEndDate
            End If

            '--- �o�͑ΏېE�����̎擾
            '�̗p�E�Ō�P��CD�̑g�����ް� �擾
            Call fncGetSaiyo_KangotaniOneDay(w_lngFrom, w_lngTo)

            '������������������������������������������������������������������������������
            '   ���уf�[�^�̎擾
            '������������������������������������������������������������������������������
            '�����ް� �擾
            If fncGetJissekiData(w_lngFrom, w_lngTo) = False Then Exit Function

            '--- �擾�����̗p�E�Ō�P��CD�E�Ζ�CD�̑g��������Ζ����ԃf�[�^���擾
            For w_Cnt = 1 To UBound(g_udtStaffHistory)
                Call fncGetSanteiTimeOneDay(w_Cnt)
            Next w_Cnt

            '������������������������������������������������������������������������������
            '   ���΃f�[�^�̎擾
            '������������������������������������������������������������������������������
            '�����ް� �擾
            If fncGetCyokinData(w_lngFrom, w_lngTo) = False Then Exit Function

            If g_lngJissekiChokinKensu = 0 Then Exit Function

            mGetOverKinmuDataOneDay = True
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ߋΖ�����150_2���擾����
    ''' </summary>
    ''' <returns>���ߋΖ�����150_2</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f���ߋΖ�����150_2() As Short

        General.g_ErrorProc = "clsStaffData f���ߋΖ�����150_2"
        Try
            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���ߋΖ�����150_2 = 0
            Else
                f���ߋΖ�����150_2 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime150_2(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    '************************DLĻݸ��� f���ߋΖ�����175*****************************
    ''' <summary>
    ''' ���ߋΖ�����175���擾����
    ''' </summary>
    ''' <returns>���ߋΖ�����175</returns>
    ''' <remarks>�Ζ����сE���΃f�[�^�������O�A�܂��́A�Ζ����сE���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�A�܂��́A���΃f�[�^�������O�̏ꍇ�A�O���擾����</remarks>
    Public Function f���ߋΖ�����175() As Short

        General.g_ErrorProc = "clsStaffData f���ߋΖ�����175"
        Try
            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���ߋΖ�����175 = 0
            Else
                f���ߋΖ�����175 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime175(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    '2018-08-15 Darren ADD START
    Public Function f���ߋΖ�����25() As Short
        General.g_ErrorProc = "clsStaffData f���ߋΖ�����25"
        Try
            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f���ߋΖ�����25 = 0
            Else
                f���ߋΖ�����25 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime25(g_lngChokinIndex)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function
    '2018-08-15 Darren ADD END

    ''' <summary>
    ''' ���ԊO�͏o�݌v���ݗL���𔻒肷��
    ''' </summary>
    ''' <returns>�iTRUE�F�f�[�^����AFALSE�F0�����̓f�[�^�Ȃ��j</returns>
    ''' <remarks></remarks>
    Public Function mGetOKAppliRuikei() As Boolean

        General.g_ErrorProc = "clsGetOverData mGetOKAppliRuikei"

        mGetOKAppliRuikei = False
        Try
            m_lngAppliTime = 0
            m_lngDecisionTime = 0

            If fncGetOKAppliRuikei() = False Then Exit Function

            mGetOKAppliRuikei = True

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' ���ߋΖ����Ԃ��擾����
    ''' </summary>
    ''' <returns>���ߋΖ�����</returns>
    ''' <remarks></remarks>
    Public Function f�\������() As Integer
        Try
            General.g_ErrorProc = "clsGetOverData f�\������"

            f�\������ = m_lngAppliTime

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' �m�莞�Ԃ��擾����
    ''' </summary>
    ''' <returns>�m�莞��</returns>
    ''' <remarks></remarks>
    Public Function f�m�莞��() As Integer
        Try
            General.g_ErrorProc = "clsGetOverData f�m�莞��"

            f�m�莞�� = m_lngDecisionTime

        Catch ex As Exception
            Throw
        End Try
    End Function
End Class