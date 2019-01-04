Friend Class Parallel_NSC0000H

    Public Event finished()

    Private m_strHospitalCD As String   '病院CD
    Private m_lngStartIndex As Integer  '処理開始INDEX
    Private m_strInit As String
    Private m_lngStandardDate As Integer
    Private m_lngBeforeDay As Integer
    Private m_DayOverSelectDate As Date '日別超過勤務入力用日付
    Private m_lngEndIndex As Integer    '処理終了INDEX
    Private m_objNSW0000C As NsAid_NSW0000C.clsGetOverData
    Private m_objNSC0010C As NsAid_NSC0010C.clsStaffData
    Private m_objNSW0300C As NsAid_NSW0300C.clsGetOverData
    Private m_objNSA0000C As NsAid_NSA0000C.clsAppliApprove

    Public m_udtDayKinmuJisseki() As frmNSC0000HA.Kinmu_Type
    Public m_udtDayOverKinmu() As frmNSC0000HA.DayOverKinmu_Type
    Public m_udtStaffData() As frmNSC0000HA.Staff_Type
    Public m_udtApproveData() As frmNSC0000HA.Application_Type '【未承認業務】


    Friend Sub New(ByVal p_lngStart As Integer, _
                    ByVal p_lngEnd As Integer, _
                    ByVal p_strInit As String, _
                    ByVal p_lngStandardDate As Integer, _
                    ByVal p_lngBeforeDay As Integer, _
                    ByRef p_udtDayKinmuJisseki() As frmNSC0000HA.Kinmu_Type, _
                    ByRef p_udtDayOverKinmu() As frmNSC0000HA.DayOverKinmu_Type, _
                    ByRef p_udtStaffData() As frmNSC0000HA.Staff_Type, _
                    ByRef p_udtApproveData() As frmNSC0000HA.Application_Type, _
                    ByVal p_objNSW0000C As NsAid_NSW0000C.clsGetOverData, _
                    ByVal p_objNSC0010C As NsAid_NSC0010C.clsStaffData, _
                    ByVal p_objNSW0300C As NsAid_NSW0300C.clsGetOverData, _
                    ByVal p_DayOverSelectDate As Date, _
                    ByVal p_objNSA0000C As NsAid_NSA0000C.clsAppliApprove)

        m_lngStartIndex = p_lngStart
        m_lngEndIndex = p_lngEnd
        m_strInit = p_strInit
        m_lngStandardDate = p_lngStandardDate
        m_lngBeforeDay = p_lngBeforeDay
        m_udtDayKinmuJisseki = p_udtDayKinmuJisseki
        m_udtDayOverKinmu = p_udtDayOverKinmu
        m_udtStaffData = p_udtStaffData
        m_udtApproveData = p_udtApproveData
        m_objNSW0000C = p_objNSW0000C
        m_objNSC0010C = p_objNSC0010C
        m_objNSW0300C = p_objNSW0300C
        m_objNSW0000C.pGetDataObj = m_objNSC0010C
        m_DayOverSelectDate = p_DayOverSelectDate
        m_objNSA0000C = p_objNSA0000C

    End Sub


    Friend Sub Execute()

        For i As Integer = m_lngStartIndex To m_lngEndIndex

            subDayOverKinmu(i)
            If String.IsNullOrEmpty(m_udtDayKinmuJisseki(i).strKinmuCD) = False Then

                '======================
                '勤務時間
                '======================
                Call Get_KinmuTime(i)
            End If

            With m_objNSW0300C
                .p職員番号 = m_udtStaffData(i).strStaffMngID
                .p開始年月日 = General.paGetDateIntegerFromDate(m_DayOverSelectDate)


                If .mGetOKAppliRuikei Then
                    m_udtDayOverKinmu(i).AprYetTimeTotal = .f申請時間
                    m_udtDayOverKinmu(i).AprOverTimeTotal = .f確定時間
                Else
                    m_udtDayOverKinmu(i).AprYetTimeTotal = 0
                    m_udtDayOverKinmu(i).AprOverTimeTotal = 0
                End If
            End With

        Next
    End Sub

    Private Sub subDayOverKinmu(ByVal p_lngStaffIdx As Integer)
        Const W_SUBNAME As String = "paralel subDayOverKinmu3"

        Try
            Dim w_lngLoop As Integer
            Dim w_lngRecCnt As Integer
            Dim w_lngOverKCnt As Integer
            Dim w_lngDate As Integer
            Dim w_blnSaiyoFlg As Boolean
            Dim w_lngOverKLoop As Integer
            Dim w_lngSaiyoLoop As Integer
            Dim w_lngStandardDate As Integer
            Dim w_lngWorkLoop As Integer
            Dim w_lngBeforeDay As Integer

            Dim w_lngAppLoop As Integer
            Dim w_lngAppCnt As Integer
            Dim w_strInit As String
            Dim w_strSaiyoCD As String
            Dim w_strKinmuDeptCD As String

            '初期値設定
            '勤務コード
            m_udtDayKinmuJisseki(p_lngStaffIdx).strKinmuCD = ""
            '勤務名称
            m_udtDayKinmuJisseki(p_lngStaffIdx).strKinmuNm = ""
            '勤務略称
            m_udtDayKinmuJisseki(p_lngStaffIdx).strKinmuSecNm = ""
            '勤務記号
            m_udtDayKinmuJisseki(p_lngStaffIdx).strKinmuMark = ""
            '勤務理由
            m_udtDayKinmuJisseki(p_lngStaffIdx).strKinmuReasonKbn = ""
            '半日勤務FLG
            m_udtDayKinmuJisseki(p_lngStaffIdx).strHalfKinmuFlg = ""
            '---------------------------------------------------------

            '基準日
            w_lngStandardDate = m_lngStandardDate

            '前日
            w_lngBeforeDay = m_lngBeforeDay
            w_strInit = m_strInit

            ReDim m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(0)

            m_objNSC0010C.pUNIQUESEQNO = ""

            w_strSaiyoCD = ""
            w_strKinmuDeptCD = ""
            For w_lngWorkLoop = 1 To UBound(m_udtStaffData(p_lngStaffIdx).SaiyoHistory)
                If m_udtStaffData(p_lngStaffIdx).SaiyoHistory(w_lngWorkLoop).lngStartDate <= w_lngStandardDate AndAlso w_lngStandardDate <= m_udtStaffData(p_lngStaffIdx).SaiyoHistory(w_lngWorkLoop).lngEndDate Then

                    w_strSaiyoCD = m_udtStaffData(p_lngStaffIdx).SaiyoHistory(w_lngWorkLoop).strCD

                End If
            Next w_lngWorkLoop

            For w_lngWorkLoop = 1 To UBound(m_udtStaffData(p_lngStaffIdx).IdoHistory)
                If m_udtStaffData(p_lngStaffIdx).IdoHistory(w_lngWorkLoop).lngStartDate <= w_lngStandardDate AndAlso w_lngStandardDate <= m_udtStaffData(p_lngStaffIdx).IdoHistory(w_lngWorkLoop).lngEndDate Then

                    w_strKinmuDeptCD = m_udtStaffData(p_lngStaffIdx).IdoHistory(w_lngWorkLoop).strCD

                End If
            Next w_lngWorkLoop

            With m_objNSW0000C
                .p病院CD = General.g_strHospitalCD
                .p職員区分 = 0 '職員管理番号
                .p職員番号 = m_udtStaffData(p_lngStaffIdx).strStaffMngID
                .p日付区分 = 1
                .p開始年月日 = w_lngBeforeDay '開始年月日前日
                .p終了年月日 = w_lngStandardDate '終了年月日
                .p採用CD = w_strSaiyoCD
                .p勤務部署CD = w_strKinmuDeptCD
                If .mGetOverKinmuDataOneDay = False Then

                Else
                    w_lngRecCnt = .f実績超勤件数

                    .p年月日 = w_lngStandardDate

                    For w_lngLoop = 1 To w_lngRecCnt
                        w_lngDate = .f年月日

                        If w_lngStandardDate = w_lngDate Then

                            '実績年月日がある場合(勤務実績がある場合)
                            If w_lngDate > 0 Then
                                '採用期間内であるか
                                w_blnSaiyoFlg = False
                                For w_lngSaiyoLoop = 1 To UBound(m_udtStaffData(p_lngStaffIdx).SaiyoHistory)
                                    If m_udtStaffData(p_lngStaffIdx).SaiyoHistory(w_lngSaiyoLoop).lngStartDate <= w_lngDate AndAlso w_lngDate <= m_udtStaffData(p_lngStaffIdx).SaiyoHistory(w_lngSaiyoLoop).lngEndDate Then
                                        'ﾌﾗｸﾞをTrue(在職期間内である)
                                        w_blnSaiyoFlg = True
                                        Exit For
                                    End If
                                Next w_lngSaiyoLoop

                                '-----------------------------
                                '在職期間内の場合のみ格納
                                '-----------------------------
                                If w_blnSaiyoFlg = True Then
                                    '勤務コード
                                    m_udtDayKinmuJisseki(p_lngStaffIdx).strKinmuCD = .f実績勤務CD
                                    '勤務名称
                                    m_udtDayKinmuJisseki(p_lngStaffIdx).strKinmuNm = .f実績勤務名称
                                    '勤務略称
                                    m_udtDayKinmuJisseki(p_lngStaffIdx).strKinmuSecNm = ""
                                    '勤務記号
                                    m_udtDayKinmuJisseki(p_lngStaffIdx).strKinmuMark = .f実績勤務記号
                                    '勤務理由
                                    m_udtDayKinmuJisseki(p_lngStaffIdx).strKinmuReasonKbn = .f実績理由区分
                                    '半日勤務FLG
                                    m_udtDayKinmuJisseki(p_lngStaffIdx).strHalfKinmuFlg = .f実績半日勤務FLG
                                    w_lngOverKCnt = .f超勤時間件数

                                    'ReDim m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(w_lngOverKCnt)

                                    For w_lngOverKLoop = 1 To w_lngOverKCnt
                                        .p超勤時間索引 = w_lngOverKLoop
                                        ReDim Preserve m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(UBound(m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData) + 1)

                                        If "2".Equals(.f超勤状態区分) = False OrElse "4".Equals(.f超勤状態区分) = False OrElse "".Equals(.f超勤状態区分) = False Then
                                            m_udtDayOverKinmu(p_lngStaffIdx).lng100Day = m_udtDayOverKinmu(p_lngStaffIdx).lng100Day + .f超過勤務時間100
                                            m_udtDayOverKinmu(p_lngStaffIdx).lng125Day = m_udtDayOverKinmu(p_lngStaffIdx).lng125Day + .f超過勤務時間125
                                            m_udtDayOverKinmu(p_lngStaffIdx).lng150Day = m_udtDayOverKinmu(p_lngStaffIdx).lng150Day + .f超過勤務時間150
                                            m_udtDayOverKinmu(p_lngStaffIdx).lng135Day = m_udtDayOverKinmu(p_lngStaffIdx).lng135Day + .f超過勤務時間135
                                            m_udtDayOverKinmu(p_lngStaffIdx).lng160Day = m_udtDayOverKinmu(p_lngStaffIdx).lng160Day + .f超過勤務時間160

                                            m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(w_lngOverKLoop).lngFromTime = .f超勤時間FROM
                                            m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(w_lngOverKLoop).lngToTime = .f超勤時間TO
                                            m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(w_lngOverKLoop).strReasonSNm = .f超勤理由略称
                                            m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(w_lngOverKLoop).strStateKbn = .f超勤状態区分
                                        Else
                                            m_udtDayOverKinmu(p_lngStaffIdx).lng100Day = m_udtDayOverKinmu(p_lngStaffIdx).lng100Day + 0
                                            m_udtDayOverKinmu(p_lngStaffIdx).lng125Day = m_udtDayOverKinmu(p_lngStaffIdx).lng125Day + 0
                                            m_udtDayOverKinmu(p_lngStaffIdx).lng150Day = m_udtDayOverKinmu(p_lngStaffIdx).lng150Day + 0
                                            m_udtDayOverKinmu(p_lngStaffIdx).lng135Day = m_udtDayOverKinmu(p_lngStaffIdx).lng135Day + 0
                                            m_udtDayOverKinmu(p_lngStaffIdx).lng160Day = m_udtDayOverKinmu(p_lngStaffIdx).lng160Day + 0

                                            m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(w_lngOverKLoop).lngFromTime = 0
                                            m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(w_lngOverKLoop).lngToTime = 0
                                            m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(w_lngOverKLoop).strReasonSNm = ""
                                            m_udtDayOverKinmu(p_lngStaffIdx).OverKinmuData(w_lngOverKLoop).strStateKbn = .f超勤状態区分
                                        End If

                                    Next w_lngOverKLoop

                                    m_udtDayOverKinmu(p_lngStaffIdx).UNIQUESEQNO = .f超勤UNIQUESEQNO
                                    m_udtDayOverKinmu(p_lngStaffIdx).ApproveLevel = 0

                                    w_lngAppCnt = UBound(m_udtApproveData)
                                    For w_lngAppLoop = 1 To w_lngAppCnt

                                        If (m_udtApproveData(w_lngAppLoop).strUNIQUESEQNO).Equals(m_udtDayOverKinmu(p_lngStaffIdx).UNIQUESEQNO) Then

                                            m_udtDayOverKinmu(p_lngStaffIdx).ApproveLevel = m_udtApproveData(w_lngAppLoop).lngApproveClassLvl
                                            m_udtDayOverKinmu(p_lngStaffIdx).LastUpdDate = m_udtApproveData(w_lngAppLoop).dblLastUpdTimeDate
                                            m_udtDayOverKinmu(p_lngStaffIdx).AppliDate = m_udtApproveData(w_lngAppLoop).lngPeriodFromDate
                                            m_udtDayOverKinmu(p_lngStaffIdx).AppliStaffMngID = m_udtApproveData(w_lngAppLoop).strAppliStaffMngID

                                            Exit For

                                        End If

                                    Next w_lngAppLoop

                                    If m_udtDayOverKinmu(p_lngStaffIdx).ApproveLevel = 0 Then

                                        m_udtDayOverKinmu(p_lngStaffIdx).IconStatus = frmNSC0000HA.M_NO_ICON

                                    Else

                                        m_objNSA0000C.pAppliCD = frmNSC0000HA.M_STRJIKANGAI '届出CD
                                        m_objNSA0000C.pAppliStaffMngID = m_udtStaffData(p_lngStaffIdx).strStaffMngID '申請者の職員管理番号
                                        m_objNSA0000C.pAppliDate = w_lngStandardDate '申請日付
                                        m_objNSA0000C.pUniqueSeqNo = m_udtDayOverKinmu(p_lngStaffIdx).UNIQUESEQNO 'UNIQUESEQNO
                                        m_objNSA0000C.pDispMode = "2" '表示ﾓｰﾄﾞ
                                        m_objNSA0000C.pSyoriKbn = "2" '処理区分
                                        m_objNSA0000C.pApproveStaffMngID = General.g_strUserMngID '承認者職員管理番号

                                        m_objNSA0000C.mJEV_ApproveClassLevel = Convert.ToString(m_udtDayOverKinmu(p_lngStaffIdx).ApproveLevel)
                                        m_objNSA0000C.mJEV_ApproveStaffMngID = General.g_strUserMngID

                                        If m_objNSA0000C.mJudgeVisibleEnable = False Then
                                            m_udtDayOverKinmu(p_lngStaffIdx).IconStatus = frmNSC0000HA.M_NO_ICON
                                        Else

                                            If "1".Equals(.f超勤状態区分) Then
                                                m_udtDayOverKinmu(p_lngStaffIdx).IconStatus = frmNSC0000HA.M_NOT_APPROVE_DUE

                                                '承認ボタンが使えるとき
                                                '→操作待ち　未承認状態
                                            ElseIf "1".Equals(m_objNSA0000C.fJEV_ApproveB) Then
                                                m_udtDayOverKinmu(p_lngStaffIdx).IconStatus = frmNSC0000HA.M_OK_APPROVE

                                                '引き上げ承認ボタンが使えるとき
                                                '→操作不能　未承認状態
                                            ElseIf "1".Equals(m_objNSA0000C.fJEV_ApproveUpB) Then
                                                m_udtDayOverKinmu(p_lngStaffIdx).IconStatus = frmNSC0000HA.M_NOT_APPROVE_BEFORE

                                                'データが存在し、確定されていなくて承認ボタンと引き上げ承認ボタンが使えないとき
                                                '→操作不能　未確定承認状態
                                            Else
                                                m_udtDayOverKinmu(p_lngStaffIdx).IconStatus = frmNSC0000HA.M_NOT_APPROVE_AFTER
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                        .m翌日超勤()
                    Next w_lngLoop
                End If
            End With

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    Private Sub Get_KinmuTime(ByVal p_StaffIdx As Integer)
        Const W_SUBNAME As String = "paralel Get_KinmuTime"

        Try

            Dim w_StartTime_AM As Integer
            Dim w_StartTime_PM As Integer
            Dim w_EndTime_AM As Integer
            Dim w_EndTime_PM As Integer
            Dim w_strSaiyoCD As String
            Dim w_lngWorkLoop As Integer
            Dim w_lngStandardDate As Integer

            w_strSaiyoCD = ""
            '基準日
            w_lngStandardDate = General.paGetDateIntegerFromDate(m_DayOverSelectDate)

            For w_lngWorkLoop = 1 To UBound(m_udtStaffData(p_StaffIdx).SaiyoHistory)
                If m_udtStaffData(p_StaffIdx).SaiyoHistory(w_lngWorkLoop).lngStartDate <= w_lngStandardDate AndAlso m_udtStaffData(p_StaffIdx).SaiyoHistory(w_lngWorkLoop).lngEndDate >= w_lngStandardDate Then
                    w_strSaiyoCD = m_udtStaffData(p_StaffIdx).SaiyoHistory(w_lngWorkLoop).strCD
                    Exit For
                End If
            Next

            With m_objNSC0010C
                .p病院CD = General.g_strHospitalCD
                .p看護単位CD = m_udtStaffData(p_StaffIdx).strKinmuDeptCD
                .p採用条件CD = w_strSaiyoCD
                .p勤務CD = m_udtDayKinmuJisseki(p_StaffIdx).strKinmuCD

                If .mGetKinmuTime = False Then
                    m_udtDayKinmuJisseki(p_StaffIdx).strKinmuFrom = ""
                    m_udtDayKinmuJisseki(p_StaffIdx).strKinmuTo = ""
                    m_udtDayKinmuJisseki(p_StaffIdx).strInputOKTimeChkFlg = ""
                    Exit Sub
                Else
                    .p勤務時間索引 = 1
                    '半日勤務の場合
                    If "2".Equals(m_udtDayKinmuJisseki(p_StaffIdx).strHalfKinmuFlg) Then
                        '半日勤務の場合は前半開始時間と後半開始時間を見て、入力されているほうの終了時間を取得(両方とも入力があった場合は全日と同じ扱いにする)
                        w_StartTime_AM = .f前半開始時刻
                        w_EndTime_AM = .f前半終了時刻
                        w_StartTime_PM = .f後半開始時刻
                        w_EndTime_PM = .f後半終了時刻

                        If w_StartTime_AM = 0 AndAlso w_EndTime_AM = 0 Then
                            '前半勤務時間が両方とも０の場合は後半勤務時間を設定(半日勤務で０時～０時はありえない)
                            m_udtDayKinmuJisseki(p_StaffIdx).strKinmuFrom = Convert.ToString(w_StartTime_PM)
                            m_udtDayKinmuJisseki(p_StaffIdx).strKinmuTo = Convert.ToString(w_EndTime_PM)
                        ElseIf w_EndTime_PM = 0 AndAlso w_EndTime_PM = 0 Then
                            '後半勤務時間が両方とも０の場合は前半勤務時間を設定(半日勤務で０時～０時はありえない)
                            m_udtDayKinmuJisseki(p_StaffIdx).strKinmuFrom = Convert.ToString(w_StartTime_AM)
                            m_udtDayKinmuJisseki(p_StaffIdx).strKinmuTo = Convert.ToString(w_EndTime_AM)
                        Else
                            '前半・後半勤務時間内、どちらかが０以外の場合は全日勤務と同じ扱いとする
                            m_udtDayKinmuJisseki(p_StaffIdx).strKinmuFrom = Convert.ToString(w_StartTime_AM)
                            m_udtDayKinmuJisseki(p_StaffIdx).strKinmuTo = Convert.ToString(w_EndTime_PM)
                        End If
                    Else
                        '前半開始時刻
                        m_udtDayKinmuJisseki(p_StaffIdx).strKinmuFrom = .f前半開始時刻
                        '後半終了時刻
                        m_udtDayKinmuJisseki(p_StaffIdx).strKinmuTo = .f後半終了時刻
                    End If
                    '超勤入力可否
                    m_udtDayKinmuJisseki(p_StaffIdx).strInputOKTimeChkFlg = .f超勤入力可否
                End If
            End With

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub
End Class
