Option Strict Off
Option Explicit On
<Serializable()> <System.Runtime.InteropServices.ProgId("clsGetOverData_NET.clsGetOverData")> Public Class clsGetOverData
    '/****************************************************/
    '/    ｼｽﾃﾑ名称：NurseAID6.5
    '/ ﾌﾟﾛｸﾞﾗﾑ名称：超勤データ取得部品(労基法対応)
    '/        ＩＤ：NSW0300C
    '/        概要：超勤の情報を取得する。
    '/
    '/      作成者： T.I        CREATE 2010/02/25       【P-02638】
    '/      更新者： Y.Iguchi          2010/04/08       【P-02656】 更新内容：(法定時間越え処理追加)
    '/               M.ishida          2010/04/09       【P-02707】 更新内容：(時間外届出累計取得処理追加)
    '/               T.Ishiga          2010/04/15       【PRE-1520】 更新内容：(100/100加算フラグ追加)
    '/
    '/     Copyright (C) Inter co.,ltd 2004
    '/****************************************************/

    '===============================
    '       定数宣言
    '===============================
    Public Const M_DataFlg_DefaultData As String = "0" '存在しない場合
    Public Const M_DataFlg_GaitoPlanNoData As String = "1" '該当計画番号
    Public Const M_DataFlg_BeforePlanNoData As String = "2" '前回計画番号

    '打刻チェック使用定数
    '打刻要否
    Public Const M_IntDakokuHissu As Short = 0 '打刻必須
    Public Const M_IntDakokuHuyo As Short = 1 '打刻不要

    '打刻区分
    Public Const M_StrKbn_Syutu As String = "1" '出勤
    Public Const M_StrKbn_Tai As String = "2" '退勤
    Public Const M_StrKbn_Gai As String = "3" '外出
    Public Const M_StrKbn_Modori As String = "4" '戻り

    '打刻エラー区分
    Public Const M_IntNotExist As Short = 1 '打刻なし
    Public Const M_IntErrDakoku As Short = 2 '打刻時間確認
    Public Const M_IntSame As Short = 3 '打刻連続
    Public Const M_IntNotNeed As Short = 4 '不要な打刻
    Public Const M_IntOverKinmu As Short = 5 '超勤時間不正
    Public Const M_IntKinmuErr As Short = 6 '勤務なし
    Public Const M_IntYukoGai As Short = 7 '有効範囲外の打刻

    '===============================
    '       変数宣言
    '===============================
    '***** ﾌﾟﾛﾊﾟﾃｨ受渡項目 Start *****
    Public m_strHospitalCD As String '病院CD
    Public m_lngStaffKbn As Integer '職員区分
    Public m_strStaffNo As String '職員番号
    Public m_lngKinmuSyutokuKbn As Integer '勤務取得区分
    Public m_lngHidukeKbn As Integer '日付区分   0:単一日 1:期間
    Public m_lngKinmuTargetFlg As Integer '勤務対象者FLG 0:全員 1:勤務対象者 2:超勤対象者
    Public m_lngStartDate As Integer '開始年月日
    Public m_lngEndDate As Integer '終了年月日
    Public m_strTargetCD As String '対象CD
    Public G_StrDaikyuMng As String '代休管理をする・しないの判定（0：代休管理する、1：代休管理しない）
    Public G_StrDateJudgment As String '超勤データの日付判定（０：年月日、１：超勤年月日）
    Public G_StrWeekHolCD As String '週休CD
    Public G_StrAutoHoliday As String '自動休日出勤化（０：する、１：しない）
    Public G_StrHolidayOKKinmuCD As String '自動休日出勤可能勤務CD
    Public g_lngLastHoliday As Integer '出力対象以前直近の休日
    Public G_StrNenkyuKinmuCD As String '年休の勤務CD（複数、カンマ区切り）
    Public G_StrSaiyoCD As String '該当職員の採用コード
    Public G_StrKinmuDeptCD As String '該当職員の勤務部署コード
    Public G_StrKinmuCD As String '該当日の勤務コード
    Public m_lngJikangaiFlg As Long     '時間外取得フラグ   1：申請データ　1以外：承認データ＆申請データ

    Public G_StrNot60TimeKinmuCD As String '時間外60時間対象外勤務コード
    Public g_lng60Time As String '所定労働時間
    <Serializable()> Public Structure ovDay_type
        Dim Start As String '時間外日勤帯開始時間
        Dim End_Renamed As String '時間外日勤帯終了時間
    End Structure
    Public g_ovDay() As ovDay_type
    Public g_exchgHolTimeKinmu As String '休日時間へ換算する勤務
    '2010/04/08 Y.Iguchi Add End##
    '***** ﾌﾟﾛﾊﾟﾃｨ受渡項目 End *****

    Public g_lngHolidayKensu As Integer '休日Ｍ件数
    Public g_lngHolidayIndex As Integer '休日Ｍ索引
    Public g_lngHolidayData() As Integer '休日Ｍデータ
    Public g_lngHolidayDate As Integer '休み年月日
    Public g_lngHolidayDataDate As Integer '休日現在参照日付
    Public g_lngWeeklyHolDate() As Integer '週休日
    Public G_StrTouchokuKinmuCD As String '当直勤務CD
    Public g_lngTouchokuTanka As Integer '当直単価
    Public g_lngJissekiChokinKensu As Integer '勤務実績・超勤データ件数
    Public g_lngJissekiChokinIndex As Integer '勤務実績・超勤データ索引
    Public g_lngJissekiChokinDate As Integer '勤務実績・超勤データ日付
    Public g_lngJissekiChokinDataDate As Integer '勤務実績・超勤データ現在参照日付
    Public g_lngChokinKensu As Integer '超勤データ件数
    Public g_lngChokinIndex As Integer '超勤データ索引
    Public g_lngTentaiDate As Integer '転退年月日
    Public g_lngDaikyuData() As Integer '代休管理データ
    '2010/04/15 Ishiga add start-------------------------------------------
    Public g_100AddFlg As String '100/100加算フラグ
    '2010/04/15 Ishiga add start-------------------------------------------

    '--------------------------
    '   実績超勤データ用 構造体群
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
        Dim KinmuCD As String '勤務CD
        Dim Tanka As Short '単価
        Dim TodayOff As Short '当日休日算定時間
        Dim NextOff As Short '翌日休日算定時間
        Dim Tonight As Short '当日夜間算定時間
        Dim NextNight As Short '翌日夜間算定時間
        Dim FormalTimeFrom As String '正規勤務時間FROM（HHMM）（設定されていない場合は空文字）
        Dim FormalTimeTo As String '正規勤務時間TO（HHMM）（設定されていない場合は空文字）
        Dim JituKinmuTime As String '実勤務時間（HHMM）（設定されていない場合は空文字）
    End Structure
    <Serializable()> Public Structure typSanteiTime
        <VBFixedArray(999)> Dim SanteiTime() As KinmuTimeDetail '算定時間取得用 配列(2004/11/17 KatouY UPD)勤務時間Ｍに値が入ってないとき対応
        '---2007/07/25 hara add start
        Dim strSaiyoCD As String
        Dim strKinmuDeptCD As String
        '---2007/07/25 hara add end

        'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
        Public Sub Initialize()
            ReDim SanteiTime(999)
        End Sub
    End Structure
    Public g_udtHistory() As typSanteiTime
    '--- 勤務実績・超勤データ返却値
    <Serializable()> Public Structure typDateRange
        Dim strFrom As String '--- 時間FROM
        Dim strTo As String '--- 時間TO
    End Structure
    <Serializable()> Public Structure typChokinRiyu
        Dim strRiyuCD As String '--- .fj超勤理由CD
        Dim strRiyuNM As String '--- .fj超勤理由名称
        Dim strRiyuRNM As String '--- .fj超勤理由略称
    End Structure
    <Serializable()> Public Structure typJissekiChokin
        Dim lngYMD As Integer '--- .fj年月日
        Dim strJissekiKinmuCD As String '--- .fj実績勤務CD
        Dim strJissekiKinmuNM As String '--- .fj実績勤務名称
        Dim strJissekiKinmuMark As String '--- .fj実績勤務記号
        '2008/03/07 Muraoka Add ---------
        Dim strJissekiKinmuRKbn As String '--- .fj実績勤務理由区分
        Dim strJissekiHalfKinmuFlg As String '--- .fj実績半日勤務FLG
        '--------------------------------
        Dim strJissekiJituKinmuTime As String '--- .fj実績実勤務時間
        Dim strJissekiKinmuTime As typDateRange '--- .fj実績勤務時間FROM
        Dim strChokinTime() As typDateRange '--- .fj超勤時間FROM
        Dim lngChokinOrderDate() As Integer
        Dim intChokinTime125() As Short '--- .fj超過勤務時間125（分）
        Dim intChokinTime135() As Short '--- .fj超過勤務時間135（分）
        Dim intChokinTime150() As Short '--- .fj超過勤務時間150（分）
        Dim intChokinTime160() As Short '--- .fj超過勤務時間160（分）
        Dim intChokinTime100() As Short '--- .fj超過勤務時間100（分）'---2007/07/25 hara add
        '2010/04/08 Y.Iguchi Add Start
        Dim intChokinTime150_2() As Short '--- .fj超過勤務時間150（60時間越え）（分）
        Dim intChokinTime175() As Short '--- .fj超過勤務時間175（60時間越え）（分）
        '2010/04/08 Y.Iguchi Add End##
        '2018-08-15 Darren ADD START
        Dim intChokinTime25() As Short
        '2018-08-15 Darren ADD END
        Dim intHolidayTime As Short '--- .fj休日勤務時間（分）
        Dim intNightTime As Short '--- .fj夜間勤務時間（分）
        Dim strApproveKbn() As String '--- .fj状態区分  ---20061107 iwasaki add
        Dim strChokinRiyu() As typChokinRiyu
        '---2007/09/21 hara add start
        Dim strSaiyoCD As String '--- 採用CD
        Dim lngJituKinmuTime100 As Integer '--- 100/100用実勤務時間(分)
        Dim lngJituKinmuTime100Add As Integer '--- 100/100として割り当て可能な時間(分) = 日実勤務時間 - 実働時間
        Dim bln100chk As Boolean '--- 100/100対象フラグ(True：対象採用CD かつ 割り当て可能時間がある、False：以外)
        '---2007/09/21 hara add end
        '---2007/11/14 hara add start
        Dim strUniqueSeqNo() As String
        '---2007/11/14 hara add end
    End Structure
    Public g_udtJissekiChokin() As typJissekiChokin

    '超勤明細Ｆ
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
    '  日実勤務時間 構造体
    '========================
    <Serializable()> Private Structure DayWorkTimeType
        Dim strCD() As String '採用ＣＤ
        Dim lngTime As Integer '日実勤務時間(分)
    End Structure

    <Serializable()> Public Structure GensanDataType
        Dim CD As String
        Dim Time As Integer
    End Structure
    <Serializable()> Public Structure DateTimeType
        Dim lngDate As Integer '日付
        Dim udtData() As GensanDataType
    End Structure
    Public g_DayKoujoTime() As DateTimeType '控除時間
    Public g_DayNenkyuTime() As DateTimeType '年休時間
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
    ''' p時間外取得フラグをセットする
    ''' </summary>
    ''' <param name="Value">p時間外取得フラグ</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p時間外取得フラグ() As Integer
        Set(ByVal value As Integer)
            m_lngJikangaiFlg = value
        End Set
    End Property

    ''' <summary>
    ''' 取得したコードを元に汎用Ｍより名称を取得
    ''' </summary>
    ''' <param name="p_strCode">汎用Ｍより取得するコード</param>
    ''' <param name="p_strMasterID">汎用ＭのマスタID</param>
    ''' <returns>名称</returns>
    ''' <remarks></remarks>
    Private Function fncGetHanyouName(ByVal p_strCode As String, ByVal p_strMasterID As String) As String
        Dim w_strPreErrorProc As String
        Dim w_strSql As Object
        Dim w_Rs As ADODB.Recordset

        w_strPreErrorProc = General.g_ErrorProc
        General.g_ErrorProc = "BasNSW0300C fncGetHanyouName"
        Try
            '看護単位CDを取得
            w_strSql = "select Name From NS_HANYOU_M"
            w_strSql = w_strSql & " where MasterCD = '" & p_strCode & "'"
            w_strSql = w_strSql & " and MasterID = '" & p_strMasterID & "'"
            w_strSql = w_strSql & " and HospitalCD = '" & Trim(m_strHospitalCD) & "'"

            'カーソル作成
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
    ''' 休日Ｍデータを年月日で検索してインデックスを確定する
    ''' </summary>
    ''' <returns>True:対象日付が存在する、False:対象日付が存在しない</returns>
    ''' <remarks></remarks>
    Public Function fncblnHolidayKensaku() As Boolean
        Dim w_strPreErrorProc As String
        w_strPreErrorProc = General.g_ErrorProc
        General.g_ErrorProc = "BasNSW0300C fncblnHolidayKensaku"

        Dim w_lngCount As Integer
        Try
            g_lngHolidayIndex = 0
            For w_lngCount = 1 To g_lngHolidayKensu
                'データの年月日と参照年月日を比較
                If g_lngHolidayData(w_lngCount) = g_lngHolidayDataDate Then
                    '参照年月日が存在
                    g_lngHolidayIndex = w_lngCount
                    Exit For
                ElseIf g_lngHolidayData(w_lngCount) > g_lngHolidayDataDate Then
                    '参照年月日がみつからない
                    g_lngHolidayIndex = 0
                    Exit For
                End If
            Next w_lngCount

            If g_lngHolidayIndex = 0 Then
                '対象日付が存在しない
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
    ''' 勤務実績・超勤データを年月日で検索してインデックスを確定する
    ''' </summary>
    ''' <returns>True:対象日付が存在する、False:対象日付が存在しない</returns>
    ''' <remarks></remarks>
    Public Function fncblnJissekiChokinKensaku() As Boolean
        Dim w_strPreErrorProc As String
        w_strPreErrorProc = General.g_ErrorProc
        General.g_ErrorProc = "BasNSW0300C fncblnJissekiChokinKensaku"

        Dim w_lngCount As Integer
        Try
            g_lngJissekiChokinIndex = 0
            For w_lngCount = 1 To g_lngJissekiChokinKensu
                'データの年月日と参照年月日を比較
                If g_udtJissekiChokin(w_lngCount).lngYMD = g_lngJissekiChokinDataDate Then
                    '参照年月日が存在
                    g_lngJissekiChokinIndex = w_lngCount
                    Exit For
                ElseIf g_udtJissekiChokin(w_lngCount).lngYMD > g_lngJissekiChokinDataDate Then
                    '参照年月日がみつからない
                    g_lngJissekiChokinIndex = 0
                    Exit For
                End If
            Next w_lngCount

            If g_lngJissekiChokinIndex = 0 Then
                '対象日付が存在しない
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
    ''' 休日Ｍデータを取得
    ''' </summary>
    ''' <remarks>自動休日出勤化を行う場合のみ出力期間以前の休日データを取得（自動休日出勤化チェック用）</remarks>
    Public Sub subGetHolidayData()
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
        General.g_ErrorProc = "subGetHolidayData"

        Dim w_Sql As String
        Dim w_Year As Short
        Dim w_From As Short
        Dim w_To As Short
        Dim w_Cnt As Short
        Dim w_i As Short
        Dim w_Rs As ADODB.Recordset
        'ﾌｨｰﾙﾄﾞ･ｵﾌﾞｼﾞｪｸﾄ
        Dim w_YYYY_F As ADODB.Field
        Dim w_MMDD_F As ADODB.Field
        Dim w_LastDate As Integer
        Dim w_LastCnt As Short
        Dim w_strDate As Date
        Dim w_ToDate As String
        Try
            '対象月取得
            w_From = Short.Parse(Right(Convert.ToString(m_lngStartDate), 4))
            w_To = Short.Parse(Right(Convert.ToString(m_lngEndDate), 4))


            '配列の初期化
            ReDim g_lngHolidayData(0)
            w_LastCnt = 0

            '--- 自動休日出勤化を行う場合のみ
            If ("0").Equals(G_StrAutoHoliday) Then
                '-----------------------------------------------------------
                '   出力期間以前の休日データを取得（自動休日出勤化チェック用）
                '-----------------------------------------------------------
                w_LastDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, General.paGetDateFromDateInteger(m_lngStartDate)))
                w_Year = Short.Parse(Left(Convert.ToString(w_LastDate), 4)) - 1
                'Select文 編集
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
                    'ﾃﾞｰﾀの有無を確認
                    If .RecordCount > 0 Then
                        'ﾌｨｰﾙﾄﾞｵﾌﾞｼﾞｪｸﾄの生成
                        w_YYYY_F = .Fields("YearF")
                        w_MMDD_F = .Fields("MonthDay")

                        w_LastCnt = 1
                        ReDim Preserve g_lngHolidayData(w_LastCnt)

                        '--- １件目だけでＯＫ
                        g_lngLastHoliday = Integer.Parse((w_YYYY_F.Value * 10000) + w_MMDD_F.Value)
                        g_lngHolidayData(w_LastCnt) = g_lngLastHoliday
                        'D.T 2006/12/29 ADD ===========================================================
                        '自動休日出勤化を行う設定でも、休日設定が存在しない場合は設定を変更
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

            '終了年月日の翌日を取得
            w_ToDate = General.paGetDateStringFromDate(w_strDate)

            'Select文 編集
            w_Sql = "Select YearF, MonthDay From NS_HOLIDAY_M "
            w_Sql = w_Sql & "Where HospitalCD = '" & m_strHospitalCD & "' "
            w_Sql = w_Sql & "And YearF >= " & Convert.ToString(Left(Convert.ToString(m_lngStartDate), 4)) & " "
            w_Sql = w_Sql & "Or  YearF <= " & Left(w_ToDate, 4) & " "
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            With w_Rs
                'ﾃﾞｰﾀの有無を確認
                If .RecordCount > 0 Then

                    '配列の確保
                    .MoveLast()
                    w_Cnt = .RecordCount
                    g_lngHolidayKensu = w_LastCnt + w_Cnt
                    .MoveFirst()
                    ReDim Preserve g_lngHolidayData(g_lngHolidayKensu)

                    'ﾌｨｰﾙﾄﾞｵﾌﾞｼﾞｪｸﾄの生成
                    w_YYYY_F = .Fields("YearF")
                    w_MMDD_F = .Fields("MonthDay")

                    For w_i = 1 To w_Cnt
                        g_lngHolidayData(w_LastCnt + w_i) = Integer.Parse((w_YYYY_F.Value * 10000) + w_MMDD_F.Value)
                        .MoveNext()
                    Next w_i

                End If
            End With

            w_Rs.Close()


            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        Finally
            w_Rs = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' 自動休日出勤可能勤務CD、年休の勤務CDを取得
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub subGetAutoHolidayKinmuCD()
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
        General.g_ErrorProc = "subGetAutoHolidayKinmuCD"

        Dim w_strSql As String
        Dim w_Rs As ADODB.Recordset
        Dim w_KinmuCD_F As ADODB.Field
        Dim w_DataCnt As Short
        Dim w_Idx As Short

        G_StrHolidayOKKinmuCD = ""
        Try
            '------------------------------------------------------------
            '  祝日に週休だった場合、その後で休日出勤扱いとできる勤務の取得
            '------------------------------------------------------------
            'Select文 編集
            w_strSql = ""
            w_strSql = w_strSql & "SELECT"
            w_strSql = w_strSql & " KinmuCD "
            w_strSql = w_strSql & "FROM"
            w_strSql = w_strSql & " NS_KINMUNAME_M "
            w_strSql = w_strSql & "WHERE HospitalCD = '" & m_strHospitalCD & "' "
            w_strSql = w_strSql & "  AND KinmuKbn = '1' " '--- 勤務
            w_strSql = w_strSql & "  AND HalfKinmuFlg = '1' " '--- 全日
            w_strSql = w_strSql & "ORDER BY"
            w_strSql = w_strSql & " KinmuCD "
            w_Rs = General.paDBRecordSetOpen(w_strSql)

            With w_Rs
                'ﾃﾞｰﾀの有無を確認
                If .RecordCount > 0 Then

                    '配列の確保
                    .MoveLast()
                    w_DataCnt = .RecordCount
                    .MoveFirst()

                    'ﾌｨｰﾙﾄﾞｵﾌﾞｼﾞｪｸﾄの生成
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
            '  年休対象の勤務CDを取得
            '-------------------------
            'Select文 編集
            w_strSql = ""
            w_strSql = w_strSql & "SELECT"
            w_strSql = w_strSql & " KinmuCD "
            w_strSql = w_strSql & "FROM"
            w_strSql = w_strSql & " NS_KINMUNAME_M "
            w_strSql = w_strSql & "WHERE HospitalCD = '" & m_strHospitalCD & "' "
            w_strSql = w_strSql & "  AND HolidayBunruiCD = '" & General.G_STRNENKYUBUNRUI & "' " '--- 休み分類＝年休
            w_strSql = w_strSql & "ORDER BY"
            w_strSql = w_strSql & " KinmuCD "
            w_Rs = General.paDBRecordSetOpen(w_strSql)

            With w_Rs
                'ﾃﾞｰﾀの有無を確認
                If .RecordCount > 0 Then

                    '配列の確保
                    .MoveLast()
                    w_DataCnt = .RecordCount
                    .MoveFirst()

                    'ﾌｨｰﾙﾄﾞｵﾌﾞｼﾞｪｸﾄの生成
                    w_KinmuCD_F = .Fields("KinmuCD")

                    For w_Idx = 1 To w_DataCnt
                        G_StrNenkyuKinmuCD = G_StrNenkyuKinmuCD & General.paGetDbFieldVal(w_KinmuCD_F, "") & ","
                        .MoveNext()
                    Next w_Idx
                End If

                .Close()
            End With



            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        Finally
            w_Rs = Nothing
        End Try
    End Sub

    ''' <summary>
    ''' 摘要Ｍの名称を全てﾃﾞｨｸｼｮﾅﾘｵﾌﾞｼﾞｪｸﾄに格納
    ''' </summary>
    ''' <param name="p_objDic">ｵﾌﾞｼﾞｪｸﾄ</param>
    ''' <returns>（TRUE：正常、FALSE：異常）</returns>
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

            'カーソル作成
            w_Rs = General.paDBRecordSetOpen(w_strSql)

            With w_Rs
                If .RecordCount <= 0 Then
                    '摘要Ｍﾃﾞｰﾀなし
                Else
                    .MoveLast()
                    w_lngKensu = .RecordCount
                    .MoveFirst()
                    For w_lngLoop = 1 To w_lngKensu
                        ''異動年月日を降順で取得しているので、一番目のﾃﾞｰﾀが現在の配属情報になる
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
    ''' 超過勤務時間を取得する
    ''' </summary>
    ''' <param name="p_lngFrom">p開始年月日</param>
    ''' <param name="p_lngTo">p終了年月日</param>
    ''' <returns>（TRUE：正常、FALSE：異常）</returns>
    ''' <remarks></remarks>
    Public Function fncGetCyokinData(ByVal p_lngFrom As Integer, ByVal p_lngTo As Integer) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
        General.g_ErrorProc = "clsNSJP010 fncGetCyokinData"

        Dim w_i As Short
        Dim w_j As Short
        Dim w_HolFlg As String
        Dim w_TempDate As Date '日付ｲﾝﾃﾞｯｸｽ取得目的用
        Dim w_DayIdx As Short '日付ｲﾝﾃﾞｯｸｽ
        Dim w_PreDayIdx As Short '前回のﾃﾞｰﾀの日付(退避用 ﾃﾞｰﾀ)
        Dim w_Seq As Short '超勤ﾃﾞｰﾀ用のｲﾝﾃﾞｯｸｽ
        Dim w_Time125 As Short '単価別超勤時間数(超勤時間計算関数の計算結果)
        Dim w_Time135 As Short '　　　 〃
        Dim w_Time150 As Short '　　　 〃
        Dim w_Time160 As Short '　　　 〃
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
            '超勤単価計算時に休日マスタ参照判定(0:参照する　1:参照しない)
            w_HolMCompare = Short.Parse(General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "HOLMCOMPARE", Convert.ToString(0), m_strHospitalCD))
            '2018-08-23 Darren ADD START
            w_25Compare = General.paSplit(General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "FURIKAE25OVERKINMUCD", Convert.ToString(0), m_strHospitalCD), ";")
            w_25Upper = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "FURIKAE25UPPERLIMIT", Convert.ToString(0), m_strHospitalCD)
            w_25Lower = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "FURIKAE25LOWERLIMIT", Convert.ToString(0), m_strHospitalCD)
            '2018-08-23 Darren ADD END

            w_lng60Time = Integer.Parse(g_lng60Time)
            w_lngOldDate = Integer.Parse(p_lngFrom.ToString.Substring(0, 6))

            '=======================
            '   勤務命令時間 取得
            '=======================
            '単価別時間数 初期化
            w_Time125 = 0
            w_Time135 = 0
            w_Time150 = 0
            w_Time160 = 0
            w_Time100 = 0

            w_WorkDate = General.paGetDateFromDateInteger(p_lngFrom)

            With General.g_objGetData
                .p職員区分 = m_lngStaffKbn
                .p職員番号 = m_strStaffNo
                .p日付区分 = m_lngHidukeKbn
                If m_lngJikangaiFlg = 1 Then
                    .p承認区分 = 1            '--- 調整Ｆ
                Else
                    .p承認区分 = 2            '--- 超勤Ｆ・超勤調整Ｆ
                End If
                .p開始年月日 = p_lngFrom
                .p終了年月日 = p_lngTo
                w_blnResult = .mGetOverKinmu
                If w_blnResult = False Then
                Else
                    '--- .f超勤件数
                    w_PreDayIdx = 0
                    '該当する日のﾃﾞｰﾀ数分 繰り返し
                    For w_i = 1 To .f超勤件数
                        .p超勤索引 = w_i
                        'ﾃﾞｰﾀを待避
                        '--- .f年月日
                        w_CyokinData.OrderDate = .f年月日
                        '--- .f超勤年月日
                        w_CyokinData.CyokinDate = .f超勤年月日
                        '--- .f超勤分割FLG
                        w_CyokinData.BunkatuFlg = .f超勤分割FLG
                        '--- .f超勤時間FROM
                        w_CyokinData.CyokinFrom = .f超勤時間FROM
                        '--- .f超勤時間TO
                        w_CyokinData.CyokinTo = .f超勤時間TO
                        '--- .f超勤理由CD
                        w_CyokinData.ReasonCD = .f超勤理由CD
                        '--- .f超勤理由名称
                        w_CyokinData.ReasonNM = .f超勤理由名称
                        '--- .f超勤理由略称
                        w_CyokinData.ReasonRNM = .f超勤理由略称
                        '--- .f時間外状態区分
                        w_CyokinData.ApproveKbn = .f時間外状態区分

                        w_strKinmuCD = .f超勤勤務CD

                        w_CyokinData.UniqueSeqNo = .f超勤UNIQUESEQNO

                        '分解された超勤ﾃﾞｰﾀで判定を行う
                        '年月日
                        If ("0").Equals(G_StrDateJudgment) OrElse ("2").Equals(G_StrDateJudgment) Then
                            w_CheckDate = w_CyokinData.OrderDate
                        Else
                            w_CheckDate = w_CyokinData.CyokinDate
                        End If
                        w_TempDate = General.paGetDateFromDateInteger(w_CheckDate)
                        w_DayIdx = DateDiff(Microsoft.VisualBasic.DateInterval.Day, w_WorkDate, w_TempDate)
                        '--------------------------------------------------------------
                        '   転出日と超勤を開始した日を比較(退職しているかどうかの見極め)
                        '--------------------------------------------------------------
                        If g_lngTentaiDate < w_CheckDate Then
                            '転出日より超勤日が大きい場合は,既に退職しているので格納しない
                        Else
                            '現日付時点では,退職していない場合
                            '========================
                            '   超勤単価別時間 算出
                            '========================
                            '超勤日の月が変わった場合
                            If w_lngOldDate < Integer.Parse(General.paGetDateStringFromInteger(w_CheckDate, General.G_DATE_ENUM.yyyyMM)) Then
                                '60時間を元に戻す
                                w_lng60Time = Integer.Parse(g_lng60Time)
                                w_lngOldDate = Integer.Parse(General.paGetDateStringFromInteger(w_CheckDate, General.G_DATE_ENUM.yyyyMM))
                            End If

                            '超勤ﾃﾞｰﾀがあるかどうか判断
                            If String.IsNullOrEmpty(w_CyokinData.CyokinFrom) = False AndAlso String.IsNullOrEmpty(w_CyokinData.CyokinTo) = False Then
                                '--- 年月日取得で、分割フラグが立っていれば、１件として返す。

                                If (("0").Equals(G_StrDateJudgment) OrElse ("2").Equals(G_StrDateJudgment)) AndAlso ("1").Equals(w_CyokinData.BunkatuFlg) AndAlso w_OrderDate_bk = w_CyokinData.OrderDate AndAlso w_BunkatuFlg_bk = Short.Parse(w_CyokinData.BunkatuFlg) Then
                                    '--- カウントアップしない
                                    w_Seq = UBound(g_udtJissekiChokin(w_DayIdx).strChokinTime)
                                Else
                                    '---------------------------------------
                                    '   同日に存在する超勤数分 ｲﾝﾃﾞｯｸｽ取得
                                    '---------------------------------------
                                    w_Seq = UBound(g_udtJissekiChokin(w_DayIdx).strChokinTime) + 1

                                    '超勤ﾃﾞｰﾀが存在する場合
                                    '勤務命令時間 配列確保
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
                                        '単価超勤日
                                        w_lngJugHolDate = w_CyokinData.CyokinDate
                                    Case Else
                                        '単価年月日
                                        w_lngJugHolDate = w_CyokinData.OrderDate
                                End Select

                                'その日の勤務CDを取得する
                                For w_j = 1 To UBound(g_DayKinmuCD)
                                    If w_lngJugHolDate = g_DayKinmuCD(w_j).lngDate Then
                                        w_strKinmuCD = g_DayKinmuCD(w_j).strKinmuCD
                                        Exit For
                                    End If
                                Next w_j

                                '休日かどうかを判断
                                w_HolFlg = "0"
                                If w_HolMCompare = 0 Then
                                    For w_j = 1 To UBound(g_lngHolidayData)
                                        If w_lngJugHolDate = g_lngHolidayData(w_j) Then
                                            w_HolFlg = "1"
                                            Exit For
                                        End If
                                    Next w_j
                                End If
                                '勤務が週休かどうか判断
                                For w_j = 1 To UBound(g_lngWeeklyHolDate)
                                    If w_lngJugHolDate = g_lngWeeklyHolDate(w_j) Then
                                        w_HolFlg = "1"
                                        Exit For
                                    End If
                                Next w_j


                                '-------------------------------------------
                                '   代休管理する場合は、休日勤務を平日扱いに
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
                                    '異動先部署CD
                                    If w_CyokinData.CyokinDate > g_udtStaffHistory(w_lngCDLoop).lngStartDate AndAlso w_CyokinData.CyokinDate <= g_udtStaffHistory(w_lngCDLoop).lngEndDate Then
                                        For w_lngSaiyoLoop = 1 To UBound(g_udtHistory)
                                            '採用CD
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

                                '時間
                                w_lngTime = w_lngTime_J * 60

                                '分
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
                                '対象外の時間外が承認されている場合のみ100/100計算する
                                If (m_lngJikangaiFlg <> 1 AndAlso Integer.Parse(w_CyokinData.ApproveKbn) = 1) OrElse m_lngJikangaiFlg = 1 Then
                                    '100/100取得日かどうか？
                                    If g_udtJissekiChokin(w_DayIdx).bln100chk = True Then
                                        '100/100として割り当て可能な時間(分)があるか？
                                        If g_udtJissekiChokin(w_DayIdx).lngJituKinmuTime100Add > 0 Then

                                            '超勤時間をLong型で取得
                                            w_lngCyokinFrom = Integer.Parse(w_CyokinData.CyokinFrom)
                                            w_lngCyokinTo = Integer.Parse(w_CyokinData.CyokinTo)

                                            If w_lngCyokinFrom > w_lngCyokinTo Then
                                                '日をまたいだ場合
                                                w_lngCyokinTo = w_lngCyokinTo + 2400
                                            End If

                                            '割り当て可能時間(分)を超勤開始時間に加算
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

                                                '超過割り当て可能時間(分)を取得
                                                w_CyokinData.CyokinFrom = w_CyokinData.CyokinTo
                                            End If
                                        End If
                                    End If
                                End If '-->承認済み？          

                                '対象外の時間外が承認されている場合のみ60時間計算する
                                If (m_lngJikangaiFlg <> 1 And Integer.Parse(w_CyokinData.ApproveKbn) = 1) Or m_lngJikangaiFlg = 1 Then
                                    '60時間対象外勤務コードか？
                                    If InStr(G_StrNot60TimeKinmuCD, General.paFormatSpace(Integer.Parse(w_strKinmuCD), 3)) <= 0 AndAlso String.IsNullOrEmpty(w_strKinmuCD) = False Then
                                        '超勤時間をLong型で取得
                                        w_lngCyokinFrom = Integer.Parse(fncTimeChangeMinute(w_CyokinData.CyokinFrom))
                                        w_lngCyokinTo = Integer.Parse(fncTimeChangeMinute(w_CyokinData.CyokinTo))
                                        If w_lngCyokinFrom > w_lngCyokinTo Then
                                            '分単位なので24時間は1440分
                                            w_lngCyokinTo = w_lngCyokinTo + 1440
                                        End If

                                        If ("1").Equals(g_100AddFlg) Then
                                            w_lng60Time = w_lng60Time - g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq)
                                        End If
                                        If w_lng60Time < 0 Then
                                            w_lng60Time = 0
                                        End If
                                        '時間判定
                                        If w_lng60Time >= (w_lngCyokinTo - w_lngCyokinFrom) Then
                                            '対象の時間外を含めて60時間未満の場合
                                            w_lng60Time = w_lng60Time - (w_lngCyokinTo - w_lngCyokinFrom)
                                        Else
                                            '対象の時間外を含めて60時間以上の場合
                                            If w_lng60Time = 0 Then
                                                '現在の時間外の時間数が60時間以上の場合
                                                w_lngCyokinFrom = Integer.Parse(w_CyokinData.CyokinFrom)
                                                w_lngCyokinTo = Integer.Parse(w_CyokinData.CyokinTo)

                                                w_CyokinData.CyokinTo = w_CyokinData.CyokinFrom
                                            Else
                                                '現在の時間外の時間数が60時間未満の場合
                                                w_lngTime = w_lng60Time
                                                w_lngCyokinTo = Integer.Parse(w_CyokinData.CyokinTo)
                                                w_CyokinData.CyokinTo = Convert.ToString(Integer.Parse(Left(General.paFormatZero(Integer.Parse(w_CyokinData.CyokinFrom), 4), 2)) * 60)
                                                w_CyokinData.CyokinTo = Convert.ToString(Integer.Parse(w_CyokinData.CyokinTo) + Integer.Parse(Right(General.paFormatZero(w_CyokinData.CyokinFrom, 4), 2)) + w_lngTime)
                                                w_CyokinData.CyokinTo = fncMinuteChangeTime(w_CyokinData.CyokinTo)
                                                w_lngCyokinFrom = Integer.Parse(w_CyokinData.CyokinTo)
                                                w_lng60Time = 0
                                            End If
                                            '************************
                                            '   単価別勤務時間 算出
                                            '************************
                                            '--- 超勤単価情報の取得
                                            '--- .p超勤開始時間
                                            .p超勤開始時間 = Short.Parse(w_lngCyokinFrom)
                                            '--- .p超勤終了時間
                                            .p超勤終了時間 = Short.Parse(w_lngCyokinTo)
                                            '--- .p休日FLG
                                            .p休日FLG = w_HolFlg

                                            '--- .mGetTankaの中身
                                            w_blnResult = .mGetTanka
                                            If w_blnResult = False Then
                                            Else
                                                '--- .f超勤単価1
                                                w_Time125 = .f超勤単価1
                                                '--- .f超勤単価2
                                                w_Time135 = .f超勤単価2
                                                '--- .f超勤単価3
                                                w_Time150 = .f超勤単価3
                                                '--- .f超勤単価4
                                                w_Time160 = .f超勤単価4

                                                '--------------
                                                '   150/100②
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
                                        End If '-->対象の時間外が60時間判定の残時間よりも大きい？
                                    End If '-->60時間対象外勤務？
                                End If '-->承認済み？

                                '************************
                                '   単価別勤務時間 算出
                                '************************
                                '--- 超勤単価情報の取得
                                '--- .p超勤開始時間
                                .p超勤開始時間 = Short.Parse(w_CyokinData.CyokinFrom)
                                '--- .p超勤終了時間
                                .p超勤終了時間 = Short.Parse(w_CyokinData.CyokinTo)
                                '--- .p休日FLG
                                .p休日FLG = w_HolFlg

                                '--- .mGetTankaの中身
                                w_blnResult = .mGetTanka
                                If w_blnResult = False Then
                                Else
                                    '--- .f超勤単価1
                                    w_Time125 = .f超勤単価1
                                    '--- .f超勤単価2
                                    w_Time135 = .f超勤単価2
                                    '--- .f超勤単価3
                                    w_Time150 = .f超勤単価3
                                    '--- .f超勤単価4
                                    w_Time160 = .f超勤単価4

                                End If

                                '個別超勤単価時間 格納
                                If w_Time135 = 0 AndAlso w_Time160 = 0 Then
                                    '祝休日以外の日の場合
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
                                    '祝休日の場合
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
                                End If '祝休日の判断　終了

                                g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq) = g_udtJissekiChokin(w_DayIdx).intChokinTime100(w_Seq) + w_Time100

                                g_udtJissekiChokin(w_DayIdx).strChokinRiyu(w_Seq).strRiyuCD = w_CyokinData.ReasonCD
                                g_udtJissekiChokin(w_DayIdx).strChokinRiyu(w_Seq).strRiyuNM = w_CyokinData.ReasonNM
                                g_udtJissekiChokin(w_DayIdx).strChokinRiyu(w_Seq).strRiyuRNM = w_CyokinData.ReasonRNM
                                g_udtJissekiChokin(w_DayIdx).strApproveKbn(w_Seq) = w_CyokinData.ApproveKbn
                                g_udtJissekiChokin(w_DayIdx).strUniqueSeqNo(w_Seq) = w_CyokinData.UniqueSeqNo

                                '--- 年月日の待避
                                w_OrderDate_bk = w_CyokinData.OrderDate
                                w_BunkatuFlg_bk = Short.Parse(w_CyokinData.BunkatuFlg)
                            End If '超勤ﾃﾞｰﾀがあるかどうか判断　終了
                        End If '退職しているかどうか判断

                        '日付 退避
                        w_PreDayIdx = w_DayIdx
                    Next w_i
                End If
            End With

            w_dummy = g_udtJissekiChokin
            ReDim g_udtJissekiChokin(0)
            w_j = 0

            For w_i = 0 To UBound(w_dummy)
                w_lngOldDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, w_i, w_WorkDate))
                '期間指定の場合、期間内　単一日指定の場合、対象日付の時間外データを格納する
                If (m_lngStartDate <= w_lngOldDate AndAlso m_lngEndDate >= w_lngOldDate AndAlso m_lngHidukeKbn = 1) OrElse (m_lngStartDate = w_lngOldDate AndAlso m_lngHidukeKbn = 0) Then
                    ReDim Preserve g_udtJissekiChokin(w_j)
                    g_udtJissekiChokin(w_j) = w_dummy(w_i)
                    w_j = w_j + 1
                End If
            Next w_i
            g_lngJissekiChokinKensu = UBound(g_udtJissekiChokin)

            fncGetCyokinData = True
            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 実績ﾃﾞｰﾀを取得する
    ''' </summary>
    ''' <param name="p_lngFrom">p開始年月日</param>
    ''' <param name="p_lngTo">p終了年月日</param>
    ''' <returns>（TRUE：正常、FALSE：異常）</returns>
    ''' <remarks></remarks>
    Public Function fncGetJissekiData(ByVal p_lngFrom As Integer, ByVal p_lngTo As Integer) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
        General.g_ErrorProc = "clsNSJP010 fncGetJissekiData"

        Dim w_i As Short
        Dim w_k As Short
        Dim w_s As Short
        Dim w_HolCnt As Short
        Dim w_TodayOff As Short '休日算定時間(当日分)
        Dim w_NextOff As Short '　　 〃 　　(翌日分)
        Dim w_Tonight As Short '夜間算定時間(当日分)
        Dim w_NextNight As Short '　　 〃 　　(翌日分)
        Dim w_FormalTimeFrom As String '正規勤務時間From
        Dim w_FormalTimeTo As String '正規勤務時間To
        Dim w_JituKinmuTime As String '実勤務時間
        Dim w_KinmuCD As String
        Dim w_KinmuIdx As Short
        Dim w_date As Integer
        Dim w_NextDate As Integer
        Dim w_DayIdx As Short '配列格納用ｲﾝﾃﾞｯｸｽ(当日分)
        Dim w_NextDayIdx As Short '　　　　〃       (翌日分)
        Dim w_TodayHolFlg As Boolean
        Dim w_NextHolFlg As Boolean
        Dim w_WorkOff() As Integer '　　　　〃
        Dim w_WorkNight() As Integer '　　　　〃
        Dim w_Calc As Short
        Dim w_Int1 As Short
        Dim w_HisIndex As Short
        Dim w_WorkDate As Date
        Dim w_TempDate As Date '日付ｲﾝﾃﾞｯｸｽ取得目的用
        Dim w_AutoHoliday As Short '祝日に週休があったかどうか
        Dim w_AutoHolidayIdx As Short '祝日に週休があった場合の添え字
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
                '●採用CD
                w_Work3 = General.paSplit(w_Work2(0), "+")
                ReDim w_DayWorkTime(w_i + 1).strCD(UBound(w_Work3) + 1)
                For w_j = 0 To UBound(w_Work3)
                    w_DayWorkTime(w_i + 1).strCD(w_j + 1) = w_Work3(w_j)
                Next w_j
                '●100/100用 実働時間
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

            '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            '   代休管理データの取得
            '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            If fncGetDaikyuData(p_lngFrom, p_lngTo) = False Then
                Exit Function
            End If

            '減算用の年休と控除を取得
            Call fncGetGensaiTime(p_lngFrom, w_lngToDate)

            With General.g_objGetData
                .p職員区分 = m_lngStaffKbn
                .p職員番号 = m_strStaffNo
                .p日付区分 = m_lngHidukeKbn
                .p開始年月日 = p_lngFrom
                .p終了年月日 = w_lngToDate ' p_lngTo        
                .p勤務取得区分 = 1 '--- 実績のみ
                .p確定部署CD = "" '--- 月中異動者等の別部署分の実績も表示するように
                If ("0").Equals(G_StrAutoHoliday) Then
                    '--- 自動休日出勤化を行う場合は、対象年月以前に休日が週休だったかのチェックをする
                    .p開始年月日 = g_lngLastHoliday
                    w_StartDate = g_lngLastHoliday
                Else
                    '--- 自動休日出勤化を行わない場合は、対象年月のみ
                    .p開始年月日 = p_lngFrom
                    w_StartDate = p_lngFrom
                End If
                .p終了年月日 = w_lngToDate 'p_lngTo
                w_blnResult = .mGetKinmu

                'ﾃﾞｰﾀの存在ﾁｪｯｸ
                If w_blnResult = False Then
                Else
                    '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
                    '   実績データの取得
                    '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
                    'ﾃﾞｰﾀが存在する場合
                    .p実績年月日 = w_StartDate

                    ReDim g_DayKinmuCD(.f期間日数)

                    For w_k = 1 To .f期間日数
                        '勤務ｺｰﾄﾞ･日付を取得
                        '--- .f実績勤務CD
                        w_KinmuCD = .f実績勤務CD
                        '--- .f実績年月日
                        w_date = .f実績年月日

                        G_StrKinmuCD = w_KinmuCD

                        g_DayKinmuCD(w_k).lngDate = w_date
                        g_DayKinmuCD(w_k).strKinmuCD = w_KinmuCD

                        If w_date <> 0 AndAlso w_date < w_lngToDate Then
                            '翌日付を計算
                            w_TempDate = General.paGetDateFromDateInteger(w_date)
                            w_NextDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_TempDate))
                            '配列格納用に日付を編集
                            w_DayIdx = DateDiff(Microsoft.VisualBasic.DateInterval.Day, w_WorkDate, w_TempDate)
                            w_NextDayIdx = w_DayIdx + 1
                            w_KinmuIdx = Short.Parse(w_KinmuCD)

                            If w_DayIdx < 0 AndAlso ("0").Equals(G_StrAutoHoliday) Then
                                '--- 出力範囲以前のデータは、祝日が週休かどうかのチェックのみ
                                '-------------------------------------------------------------------
                                '   祝日に週休だった場合は、直近の勤務を自動的に休日出勤扱いとする
                                '-------------------------------------------------------------------
                                For w_s = 1 To UBound(g_lngHolidayData)
                                    If w_date = g_lngHolidayData(w_s) AndAlso InStr(G_StrWeekHolCD, General.paFormatSpace(w_KinmuCD, 2)) > 0 Then
                                        w_AutoHoliday = w_AutoHoliday + 1
                                        w_AutoHolidayIdx = w_DayIdx
                                        Exit For
                                    End If
                                Next w_s

                                If w_AutoHoliday > 0 AndAlso w_DayIdx > w_AutoHolidayIdx Then
                                    '祝休日の場合は自動繰越分を消化しない
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
                                            '--- 祝日に「週休」があった場合で、直近の勤務を休日出勤とする。
                                            w_AutoHoliday = w_AutoHoliday - 1
                                        ElseIf InStr(1, G_StrNenkyuKinmuCD, w_KinmuCD) > 0 Then
                                            '--- 祝日に「週休」があった場合で、直近の勤務の前に「年休」を取得した場合
                                            w_AutoHoliday = w_AutoHoliday - 1
                                        End If
                                    End If
                                End If
                            Else
                                '--- 採用と看護単位CDの組合せを取得
                                w_HisIndex = 0
                                For w_Int1 = 1 To UBound(g_udtStaffHistory)
                                    If g_udtStaffHistory(w_Int1).lngStartDate <= w_date AndAlso w_date <= g_udtStaffHistory(w_Int1).lngEndDate Then
                                        g_lngTentaiDate = g_udtStaffHistory(w_Int1).lngEndDate
                                        w_HisIndex = w_Int1
                                        Exit For
                                    End If
                                Next w_Int1

                                '週休の日を格納(単価別時間を振り分けるのに利用)
                                If InStr(G_StrWeekHolCD, General.paFormatSpace(w_KinmuCD, 2)) > 0 Then
                                    w_HolCnt = w_HolCnt + 1
                                    ReDim Preserve g_lngWeeklyHolDate(w_HolCnt)
                                    g_lngWeeklyHolDate(w_HolCnt) = w_date
                                End If

                                '転出日と超勤を開始した日を毎回比較する(退職しているかどうかの見極め)
                                If g_lngTentaiDate < w_date Then
                                    '転出日より超勤日が大きい場合は,既に退職しているので格納しない
                                Else
                                    '現日付時点においては退職していない場合
                                    '各算定時間 取得
                                    w_TodayOff = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).TodayOff '当日休日算定時間
                                    w_NextOff = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).NextOff '翌日休日算定時間
                                    w_Tonight = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).Tonight '当日夜間算定時間
                                    w_NextNight = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).NextNight '翌日夜間算定時間
                                    w_FormalTimeFrom = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).FormalTimeFrom '正規勤務時間FROM
                                    w_FormalTimeTo = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).FormalTimeTo '正規勤務時間TO
                                    w_JituKinmuTime = g_udtHistory(w_HisIndex).SanteiTime(w_KinmuIdx).JituKinmuTime '実勤務時間

                                    w_lngJitudouTime = Integer.Parse(fncTimeChangeMinute(w_JituKinmuTime))
                                    For w_i = 1 To UBound(g_DayKoujoTime)
                                        '控除の日付＝勤務の日付
                                        If g_DayKoujoTime(w_i).lngDate = w_date Then
                                            For w_j = 1 To UBound(g_DayKoujoTime(w_i).udtData)
                                                '減算対象の控除か判定
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
                                        '年休の日付＝勤務の日付
                                        If g_DayNenkyuTime(w_i).lngDate = w_date Then
                                            For w_j = 1 To UBound(g_DayNenkyuTime(w_i).udtData)
                                                '減算対象の年休か判定
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
                                        '出力対象開始日の前日の場合は、勤務CDのみ格納する
                                        g_udtJissekiChokin(0).strJissekiKinmuCD = w_KinmuCD
                                        g_udtJissekiChokin(0).strJissekiKinmuNM = .f実績勤務名称
                                        g_udtJissekiChokin(0).strJissekiKinmuMark = .f実績勤務記号
                                    Else
                                        '出力対象開始日の前日以外の場合
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuCD = w_KinmuCD
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuNM = .f実績勤務名称
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuMark = .f実績勤務記号
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuRKbn = .f実績理由区分
                                        g_udtJissekiChokin(w_DayIdx).strJissekiHalfKinmuFlg = .f実績半日勤務FLG
                                        '-------------------
                                        '   職務内容 格納
                                        '-------------------
                                        '正規勤務時間From
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuTime.strFrom = General.paFormatZero(Integer.Parse(w_FormalTimeFrom), 4)
                                        '正規勤務時間To
                                        g_udtJissekiChokin(w_DayIdx).strJissekiKinmuTime.strTo = General.paFormatZero(Integer.Parse(w_FormalTimeTo), 4)
                                        '実勤務時間
                                        g_udtJissekiChokin(w_DayIdx).strJissekiJituKinmuTime = General.paFormatZero(Integer.Parse(w_JituKinmuTime), 4)

                                        w_lngJitudouTime2 = Integer.Parse(fncTimeChangeMinute(w_JituKinmuTime))

                                        For w_i = 1 To UBound(g_DayKoujoTime)
                                            '控除の日付＝勤務の日付
                                            If g_DayKoujoTime(w_i).lngDate = w_date Then
                                                For w_j = 1 To UBound(g_DayKoujoTime(w_i).udtData)
                                                    '減算対象の控除か判定
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
                                            '年休の日付＝勤務の日付
                                            If g_DayNenkyuTime(w_i).lngDate = w_date Then
                                                For w_j = 1 To UBound(g_DayNenkyuTime(w_i).udtData)
                                                    '減算対象の年休か判定
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

                                        '採用CD
                                        g_udtJissekiChokin(w_DayIdx).strSaiyoCD = g_udtStaffHistory(w_HisIndex).strSaiyouCD

                                        '100/100用 日実勤務時間(分)
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

                                    '当日が祝日かどうかを取得
                                    w_TodayHolFlg = False
                                    For w_s = 1 To UBound(g_lngHolidayData)
                                        If w_date = g_lngHolidayData(w_s) Then
                                            w_TodayHolFlg = True
                                            Exit For
                                        End If
                                    Next w_s
                                    '翌日が祝日かどうかを取得
                                    w_NextHolFlg = False
                                    For w_s = 1 To UBound(g_lngHolidayData)
                                        If w_NextDate = g_lngHolidayData(w_s) Then
                                            w_NextHolFlg = True
                                            Exit For
                                        End If
                                    Next w_s

                                    If ("0").Equals(G_StrAutoHoliday) Then
                                        '-------------------------------------------------------------------
                                        '   祝日に週休だった場合は、直近の勤務を自動的に休日出勤扱いとする
                                        '-------------------------------------------------------------------
                                        For w_s = 1 To UBound(g_lngHolidayData)
                                            If w_date = g_lngHolidayData(w_s) AndAlso InStr(G_StrWeekHolCD, General.paFormatSpace(w_KinmuCD, 2)) > 0 Then
                                                w_AutoHoliday = w_AutoHoliday + 1
                                                w_AutoHolidayIdx = w_DayIdx
                                                Exit For
                                            End If
                                        Next w_s

                                        If w_AutoHoliday > 0 AndAlso w_DayIdx > w_AutoHolidayIdx Then
                                            '祝休日の場合は自動繰越分を消化しない
                                            w_AutoHolidayUseFlg = True
                                            For w_Int1 = 1 To UBound(g_lngHolidayData)
                                                If w_date = g_lngHolidayData(w_Int1) Then
                                                    w_AutoHolidayUseFlg = False
                                                    Exit For
                                                End If
                                            Next w_Int1
                                            If w_AutoHolidayUseFlg = True Then
                                                If InStr(1, G_StrHolidayOKKinmuCD, w_KinmuCD) > 0 Then
                                                    '--- 祝日に「週休」があった場合で、直近の勤務を休日出勤とする。
                                                    w_TodayHolFlg = True
                                                    w_AutoHoliday = w_AutoHoliday - 1
                                                ElseIf InStr(1, G_StrNenkyuKinmuCD, w_KinmuCD) > 0 Then
                                                    '--- 祝日に「週休」があった場合で、直近の勤務の前に「年休」を取得した場合
                                                    w_AutoHoliday = w_AutoHoliday - 1
                                                End If
                                            End If
                                        End If
                                    End If


                                    '-------------------------------------------
                                    '   代休管理する場合は、休日勤務を平日扱いに
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
                                    '   休日勤務時間 計算＆格納
                                    '-----------------------------
                                    '計算対象日の振り分け
                                    If p_lngFrom = w_date Then
                                        '対象開始日の前日の時は翌日分のみを計算
                                        If w_NextHolFlg = True Then
                                            If w_NextOff = 0 Then
                                                '時間が設定されていなければ,何もしない
                                            Else
                                                '休日時間
                                                '翌日算定分の時間をﾜｰｸ用配列に格納
                                                w_WorkOff(w_NextDayIdx) = w_NextOff
                                                g_udtJissekiChokin(w_NextDayIdx).intHolidayTime = w_NextOff
                                            End If
                                        End If
                                    ElseIf w_date = p_lngTo Then
                                        '対象終了日の時は当日分のみを計算
                                        If w_TodayHolFlg = True Then
                                            If w_TodayOff = 0 Then
                                                '時間が設定されていなければ, 勤務別合計 計算のみ行う
                                                '↑正規勤務日から繰り越された時間も(あれば,)合計に加えるため
                                            Else
                                                '前日の正規勤務日から繰り越された時間も(あれば,)加算して 上書き格納
                                                w_Calc = w_WorkOff(w_DayIdx) + w_TodayOff
                                                g_udtJissekiChokin(w_DayIdx).intHolidayTime = w_Calc
                                            End If
                                        End If
                                    Else
                                        '対象期間内の時は当日分も翌日分も計算
                                        '当日分
                                        If w_TodayHolFlg = True Then
                                            If w_TodayOff = 0 Then
                                                '時間が設定されていなければ, 勤務別合計 計算のみ行う
                                                '↑正規勤務日から繰り越された時間も(あれば,)合計に加えるため
                                            Else
                                                '前日の正規勤務日から繰り越された時間も(あれば,)加算して 上書き格納
                                                w_Calc = w_WorkOff(w_DayIdx) + w_TodayOff
                                                g_udtJissekiChokin(w_DayIdx).intHolidayTime = w_Calc
                                            End If
                                        End If
                                        '翌日分
                                        If w_NextHolFlg = True Then
                                            If w_NextOff = 0 Then
                                                '時間が設定されていなければ,何もしない
                                            Else
                                                '休日時間
                                                '翌日算定分の時間をﾜｰｸ用配列に格納
                                                w_WorkOff(w_NextDayIdx) = w_NextOff
                                                g_udtJissekiChokin(w_NextDayIdx).intHolidayTime = w_WorkOff(w_NextDayIdx)
                                            End If
                                        End If
                                    End If '計算対象日の振り分け 終了

                                    '-----------------------------
                                    '   夜間勤務時間 計算＆格納
                                    '-----------------------------
                                    If p_lngFrom = w_date Then
                                        '対象開始日の前日の時は翌日分のみを計算
                                        '夜間時間
                                        If w_NextNight = 0 Then
                                            '時間が設定されていなければ,何もしない
                                        Else
                                            '翌日算定分の時間をﾜｰｸ用配列に格納
                                            w_WorkNight(w_NextDayIdx) = w_NextNight
                                            g_udtJissekiChokin(w_NextDayIdx).intNightTime = w_WorkNight(w_NextDayIdx)
                                        End If
                                    ElseIf w_date = p_lngTo Then
                                        '対象終了日の時は当日分のみを計算
                                        '夜間時間
                                        If w_Tonight = 0 Then
                                            '時間が設定されていなければ, 勤務別合計 計算のみ行う
                                            '↑正規勤務日から繰り越された時間も(あれば,)合計に加えるため
                                        Else
                                            '前日の正規勤務日から繰り越された時間も(あれば,)加算して 上書き格納
                                            w_Calc = w_WorkNight(w_DayIdx) + w_Tonight
                                            g_udtJissekiChokin(w_DayIdx).intNightTime = w_Calc
                                        End If
                                    Else
                                        '対象期間内の時は当日分も翌日分も計算
                                        '当日分
                                        '夜間時間
                                        If w_Tonight = 0 Then
                                            '時間が設定されていなければ, 勤務別合計 計算のみ行う
                                            '↑正規勤務日から繰り越された時間も(あれば,)合計に加えるため
                                        Else
                                            '前日の正規勤務日から繰り越された時間も(あれば,)加算して 上書き格納
                                            w_Calc = w_WorkNight(w_DayIdx) + w_Tonight
                                            g_udtJissekiChokin(w_DayIdx).intNightTime = w_Calc
                                        End If
                                        '翌日分
                                        '夜間時間
                                        If w_NextNight = 0 Then
                                            '時間が設定されていなければ,何もしない
                                        Else
                                            '翌日算定分の時間をﾜｰｸ用配列に格納
                                            w_WorkNight(w_NextDayIdx) = w_NextNight
                                            g_udtJissekiChokin(w_NextDayIdx).intNightTime = w_WorkNight(w_NextDayIdx)
                                        End If
                                    End If
                                End If '退職しているか？
                            End If
                        ElseIf w_date = w_lngToDate AndAlso w_date <> 0 Then
                            '週休の日を格納(単価別時間を振り分けるのに利用)
                            If InStr(G_StrWeekHolCD, General.paFormatSpace(w_KinmuCD, 2)) > 0 Then
                                w_HolCnt = w_HolCnt + 1
                                ReDim Preserve g_lngWeeklyHolDate(w_HolCnt)
                                g_lngWeeklyHolDate(w_HolCnt) = w_date
                            End If
                        End If
                        .m翌日実績()
                    Next w_k
                End If
            End With
            Erase w_WorkOff
            Erase w_WorkNight

            fncGetJissekiData = True

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 採用CD・看護単位CDの組合せﾃﾞｰﾀを取得する
    ''' </summary>
    ''' <param name="p_lngFrom">p開始年月日</param>
    ''' <param name="p_lngTo">p終了年月日</param>
    ''' <returns>（TRUE：正常、FALSE：異常）</returns>
    ''' <remarks></remarks>
    Public Function fncGetSaiyo_Kangotani(ByVal p_lngFrom As Integer, ByVal p_lngTo As Integer) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
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
                .p職員区分 = m_lngStaffKbn
                .p職員番号 = m_strStaffNo
                .p日付区分 = m_lngHidukeKbn
                .p開始年月日 = p_lngFrom
                .p終了年月日 = p_lngTo
                .p職員番号変換 = 0
                .p履歴ソートFLG = 0 '--- 昇順
                .pシステム区分 = 0 '--- 勤務管理
                w_blnResult = .mStaffInit
                If w_blnResult = False Then
                    'ありえない？
                Else

                    '--- 月内の採用CD数
                    w_DataCnt = .f職員管理件数
                    ReDim w_udtSaiyou(w_DataCnt)
                    For w_Cnt = 1 To w_DataCnt
                        .p職員管理索引 = w_Cnt
                        '--- .f採用年月日1
                        w_udtSaiyou(w_Cnt).lngStartDate = .f採用年月日1
                        '--- .f転退年月日1
                        w_udtSaiyou(w_Cnt).lngEndDate = .f転退年月日1
                        '--- .f採用条件CD
                        w_udtSaiyou(w_Cnt).strCD = .f採用条件CD
                    Next w_Cnt
                    '--- 月内の看護単位CD数
                    w_DataCnt = .f勤務地異動件数
                    ReDim w_udtKinmuchi(w_DataCnt)
                    For w_Cnt = 1 To w_DataCnt
                        .p勤務地異動索引 = w_Cnt
                        '--- .f勤務地異動年月日
                        w_udtKinmuchi(w_Cnt).lngStartDate = .f勤務地異動年月日
                        '--- .f勤務地終了年月日
                        w_udtKinmuchi(w_Cnt).lngEndDate = .f勤務地終了年月日
                        '--- .f看護単位CD1
                        w_udtKinmuchi(w_Cnt).strCD = .f看護単位CD1
                    Next w_Cnt
                End If

                '--- 出力対象月内の看護単位CDと採用CDの組合せを作成
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
                '--- 取得した採用CDと看護単位CDで組合せ作成
                Do
                    '--- 全部チェックしたら、ループを抜ける
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
                    g_udtStaffHistory(w_Cnt).lngEndDate = p_lngTo '--- ダミーで出力末日をセット
                Loop
            End With

            '--- 初期化
            ReDim g_udtHistory(UBound(g_udtStaffHistory))
            subG_udtHistoryInit()

            fncGetSaiyo_Kangotani = True

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' g_udtHistory配列の初期化処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subG_udtHistoryInit()
        For i As Integer = 0 To g_udtHistory.Length - 1
            g_udtHistory(i).Initialize()
        Next
    End Sub

    ''' <summary>
    ''' 算定時間ﾃﾞｰﾀを取得する
    ''' </summary>
    ''' <param name="p_lngFrom">p開始年月日</param>
    ''' <param name="p_lngTo">p終了年月日</param>
    ''' <returns>（TRUE：正常、FALSE：異常）</returns>
    ''' <remarks></remarks>
    Public Function fncGetSanteiTime(ByVal p_intIndex As Short) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
        General.g_ErrorProc = "clsNSJP010 fncGetSanteiTime"

        Dim w_i As Short
        Dim w_KinmuIdx As Short
        Dim w_intMax As Short
        Dim w_blnResult As Boolean

        fncGetSanteiTime = False
        Try
            With General.g_objGetData
                .p看護単位CD = g_udtStaffHistory(p_intIndex).strKangoTaniCD
                .p採用条件CD = g_udtStaffHistory(p_intIndex).strSaiyouCD
                '--- 勤務時間Ｍを全件取得するために初期化
                .p勤務CD = ""
                w_blnResult = .mGetKinmuTime '--- 勤務時間マスタデータ取得

                If w_blnResult = False Then
                    '時間マスタデータ取得できないので計算しない(ありえない)
                    ReDim g_lngWeeklyHolDate(0)
                    Exit Function
                Else
                    '--- .f勤務時間件数
                    w_intMax = .f勤務時間件数
                    g_udtHistory(p_intIndex).strSaiyoCD = g_udtStaffHistory(p_intIndex).strSaiyouCD
                    g_udtHistory(p_intIndex).strKinmuDeptCD = g_udtStaffHistory(p_intIndex).strKangoTaniCD

                    '時間マスタ取得条件に一致した場合
                    For w_i = 1 To w_intMax
                        '----------------------
                        '   各算定時間 取得
                        '----------------------
                        .p勤務時間索引 = w_i

                        '--- .f勤務CD
                        w_KinmuIdx = .f勤務CD

                        '--- 宿日直勤務CDと一致する宿日直単価を取得
                        If .f勤務CD = G_StrTouchokuKinmuCD Then
                            '宿日直勤務単価格納
                            g_lngTouchokuTanka = .f宿日直単価
                        End If

                        '--- .f当日休日算定時間
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).TodayOff = .f当日休日算定時間
                        '--- .f翌日休日算定時間
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).NextOff = .f翌日休日算定時間
                        '--- .f当日夜間算定時間
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).Tonight = .f当日夜間算定時間
                        '--- .f翌日夜間算定時間
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).NextNight = .f翌日夜間算定時間
                        '--- .f前半開始時刻
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).FormalTimeFrom = .f前半開始時刻
                        '--- .f後半終了時刻
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).FormalTimeTo = .f後半終了時刻
                        '--- .f実勤務時間
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).JituKinmuTime = .f実勤務時間
                        '--- .f勤務CD
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).KinmuCD = .f勤務CD

                    Next w_i
                End If
            End With
            fncGetSanteiTime = True

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 代休管理データを取得する
    ''' </summary>
    ''' <param name="p_lngFrom">p開始年月日</param>
    ''' <param name="p_lngTo">p終了年月日</param>
    ''' <returns>（TRUE：正常、FALSE：異常）</returns>
    ''' <remarks></remarks>
    Private Function fncGetDaikyuData(ByVal p_lngFrom As Integer, ByVal p_lngTo As Integer) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
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

            'カーソル作成
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

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        Finally
            w_Rs = Nothing
        End Try
    End Function


    ''' <summary>
    ''' 勤務時間計算（HHMMを分に変換する。例：0300⇒180、0301⇒181）
    ''' </summary>
    ''' <param name="p_strTime">時間（HHMM）</param>
    ''' <returns>時間（分）</returns>
    ''' <remarks></remarks>
    Private Function fncTimeChangeMinute(ByVal p_strTime As String) As String
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
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

            '時間
            w_lngChangeTime = w_lngTime_J * 60

            '分
            w_lngChangeTime = w_lngChangeTime + w_lngTime_f

            fncTimeChangeMinute = Convert.ToString(w_lngChangeTime)

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        End Try
    End Function


    ''' <summary>
    ''' 勤務時間計算（分をHHMMに変換する。例：180⇒0300、181⇒0301）
    ''' </summary>
    ''' <param name="p_strTime">時間（分）</param>
    ''' <returns>時間（HHMM）</returns>
    ''' <remarks></remarks>
    Private Function fncMinuteChangeTime(ByVal p_strTime As String) As String

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
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

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 採用CD・看護単位CDの組合せﾃﾞｰﾀを取得する
    ''' </summary>
    ''' <param name="p_lngFrom">p開始年月日</param>
    ''' <param name="p_lngTo">p終了年月日</param>
    ''' <returns>（TRUE：正常、FALSE：異常）</returns>
    ''' <remarks></remarks>
    Public Function fncGetSaiyo_KangotaniOneDay(ByVal p_lngFrom As Integer, ByVal p_lngTo As Integer) As Boolean
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
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

            '--- 初期化
            ReDim g_udtHistory(UBound(g_udtStaffHistory))
            subG_udtHistoryInit()

            fncGetSaiyo_KangotaniOneDay = True

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 算定時間ﾃﾞｰﾀを取得する
    ''' </summary>
    ''' <param name="p_lngFrom">p開始年月日</param>
    ''' <param name="p_lngTo">p終了年月日</param>
    ''' <returns>（TRUE：正常、FALSE：異常）</returns>
    ''' <remarks></remarks>
    Public Function fncGetSanteiTimeOneDay(ByVal p_intIndex As Short) As Boolean

        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
        General.g_ErrorProc = "clsNSJP010 fncGetSanteiTimeOneDay"

        Dim w_i As Short
        Dim w_KinmuIdx As Short
        Dim w_intMax As Short
        Dim w_blnResult As Boolean

        fncGetSanteiTimeOneDay = False
        Try
            With General.g_objGetData
                .p看護単位CD = g_udtStaffHistory(p_intIndex).strKangoTaniCD
                .p採用条件CD = g_udtStaffHistory(p_intIndex).strSaiyouCD
                '--- 勤務時間Ｍを全件取得するために初期化
                .p勤務CD = G_StrKinmuCD
                w_blnResult = .mGetKinmuTime '--- 勤務時間マスタデータ取得

                If w_blnResult = False Then
                    '時間マスタデータ取得できないので計算しない(ありえない)
                    ReDim g_lngWeeklyHolDate(0)
                    Exit Function
                Else
                    '--- .f勤務時間件数
                    w_intMax = .f勤務時間件数
                    g_udtHistory(p_intIndex).Initialize()
                    g_udtHistory(p_intIndex).strSaiyoCD = g_udtStaffHistory(p_intIndex).strSaiyouCD
                    g_udtHistory(p_intIndex).strKinmuDeptCD = g_udtStaffHistory(p_intIndex).strKangoTaniCD

                    '時間マスタ取得条件に一致した場合
                    For w_i = 1 To w_intMax
                        '----------------------
                        '   各算定時間 取得
                        '----------------------
                        .p勤務時間索引 = w_i

                        '--- .f勤務CD
                        w_KinmuIdx = .f勤務CD

                        '--- 宿日直勤務CDと一致する宿日直単価を取得
                        If .f勤務CD = G_StrTouchokuKinmuCD Then
                            '宿日直勤務単価格納
                            g_lngTouchokuTanka = .f宿日直単価
                        End If

                        '--- .f当日休日算定時間
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).TodayOff = .f当日休日算定時間
                        '--- .f翌日休日算定時間
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).NextOff = .f翌日休日算定時間
                        '--- .f当日夜間算定時間
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).Tonight = .f当日夜間算定時間
                        '--- .f翌日夜間算定時間
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).NextNight = .f翌日夜間算定時間
                        '--- .f前半開始時刻
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).FormalTimeFrom = .f前半開始時刻
                        '--- .f後半終了時刻
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).FormalTimeTo = .f後半終了時刻
                        '--- .f実勤務時間
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).JituKinmuTime = .f実勤務時間
                        '--- .f勤務CD
                        g_udtHistory(p_intIndex).SanteiTime(w_KinmuIdx).KinmuCD = .f勤務CD

                    Next w_i
                End If
            End With
            fncGetSanteiTimeOneDay = True

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 年休・控除を取得する
    ''' </summary>
    ''' <param name="p_From">p開始年月日</param>
    ''' <param name="p_To">p終了年月日</param>
    ''' <returns>年休・控除</returns>
    ''' <remarks></remarks>
    Public Function fncGetGensaiTime(ByVal p_From As Integer, ByVal p_To As Integer) As Boolean
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
        General.g_ErrorProc = "clsNSJP010 fncGetGensaiTime"

        Dim w_lngMaxData As Integer
        Dim w_lngIndex As Integer
        Dim w_lngMaxData2 As Integer
        Dim w_lngIndex2 As Integer
        Dim w_date As Date
        Try
            With General.g_objGetData

                .p職員区分 = 0
                .p職員番号 = m_strStaffNo
                .p日付区分 = 1
                .p開始年月日 = p_From
                .p終了年月日 = p_To

                If .mGetNenkyu = True Then
                    w_lngMaxData = .f年休期間日数
                    ReDim g_DayNenkyuTime(w_lngMaxData)

                    w_date = General.paGetDateFromDateInteger(p_From)

                    For w_lngIndex = 1 To w_lngMaxData
                        .p年休年月日 = General.paGetDateIntegerFromDate(w_date)

                        g_DayNenkyuTime(w_lngIndex).lngDate = General.paGetDateIntegerFromDate(w_date)

                        w_lngMaxData2 = .f年休日別件数
                        ReDim g_DayNenkyuTime(w_lngIndex).udtData(w_lngMaxData2)

                        For w_lngIndex2 = 1 To w_lngMaxData2

                            .p年休日別索引 = w_lngIndex2
                            g_DayNenkyuTime(w_lngIndex).udtData(w_lngIndex2).Time = .f取得時間
                            g_DayNenkyuTime(w_lngIndex).udtData(w_lngIndex2).CD = .f年休休み分類CD
                        Next w_lngIndex2

                        w_date = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_date)
                    Next w_lngIndex

                End If

                .p職員区分 = 0
                .p職員番号 = m_strStaffNo
                .p日付区分 = 1
                .p開始年月日 = p_From
                .p終了年月日 = p_To
                If .mGetKinmuDetail = True Then

                    w_lngMaxData = .f勤務詳細期間日数
                    ReDim g_DayKoujoTime(w_lngMaxData)

                    w_date = General.paGetDateFromDateInteger(p_From)

                    For w_lngIndex = 1 To w_lngMaxData
                        .p勤務詳細年月日 = General.paGetDateIntegerFromDate(w_date)

                        g_DayKoujoTime(w_lngIndex).lngDate = General.paGetDateIntegerFromDate(w_date, General.G_DATE_ENUM.yyyyMMdd)

                        w_lngMaxData2 = .f勤務詳細日別件数
                        ReDim g_DayKoujoTime(w_lngIndex).udtData(w_lngMaxData2)

                        For w_lngIndex2 = 1 To w_lngMaxData2

                            .p勤務詳細日別索引 = w_lngIndex2
                            g_DayKoujoTime(w_lngIndex).udtData(w_lngIndex2).Time = .f控除時間
                            g_DayKoujoTime(w_lngIndex).udtData(w_lngIndex2).CD = .f勤務詳細CD
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
    ''' 引数に時間（分）と端数処理区分を受け取り、端数処理後の時間（分）を返す<br />
    ''' 時間（分）をいったんHHMM形式に変換し、MMを端数処理区分により処理する。<br />
    ''' ※切上げはHH+1、MMを0にして、切捨てはMMを0にして、再度時間（分）形式に変換して返す
    ''' </summary>
    ''' <param name="p_lngMinute">時間（分）</param>
    ''' <param name="p_strKBN">端数処理区分（2：切上げ、3：切捨て、それ以外：そのまま）</param>
    ''' <returns>時間（分）</returns>
    ''' <remarks></remarks>
    Private Function TimeRound(ByVal p_lngMinute As Integer, ByVal p_strKBN As String) As Integer
        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
        General.g_ErrorProc = "NSW0300C TimeRound"

        Dim w_lngHH As Integer
        Dim w_lngMM As Integer
        Try
            w_lngHH = p_lngMinute \ 60
            w_lngMM = p_lngMinute Mod 60

            Select Case p_strKBN
                '切上げ
                Case "2"
                    If w_lngMM > 0 Then
                        w_lngHH = w_lngHH + 1
                        w_lngMM = 0
                    End If
                    '切捨て
                Case "3"
                    If w_lngMM > 0 Then
                        w_lngMM = 0
                    End If
                    'そのまま
                Case Else

            End Select

            TimeRound = w_lngHH * 60 + w_lngMM

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 時間外届出累計Ｆを取得する
    ''' </summary>
    ''' <returns>（TRUE：正常、FALSE：異常）</returns>
    ''' <remarks></remarks>
    Public Function fncGetOKAppliRuikei() As Boolean


        Dim w_PreErrorProc As String
        w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
        General.g_ErrorProc = "NSW0300C fncGetOKAppliRuikei"

        Dim w_strSql As String
        Dim w_Rs As ADODB.Recordset
        Dim w_strAddFlg As String
        Dim w_strYYYYMM As String
        Dim w_lngCnt As Integer
        Dim w_lngLoop As Integer

        fncGetOKAppliRuikei = False
        Try
            '処理前必要データ取得
            w_strAddFlg = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY13, "REEMPLOYADDFLG", "0", m_strHospitalCD)
            w_strYYYYMM = Left(Convert.ToString(m_lngStartDate), 6)

            '時間外届出累計Ｆを取得
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

            'カーソル作成
            w_Rs = General.paDBRecordSetOpen(w_strSql)

            With w_Rs
                If .RecordCount <= 0 Then
                    Exit Function
                Else
                    .MoveLast()
                    w_lngCnt = .RecordCount
                    .MoveFirst()

                    '加算するのかどうか
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

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            Throw
        End Try
    End Function


    ''' <summary>
    ''' データ取得部品をセットする
    ''' </summary>
    ''' <param name="Value">データ取得部品</param>
    ''' <remarks></remarks>
    Public WriteOnly Property pGetDataObj() As Object
        Set(ByVal Value As Object)
            General.g_objGetData = Value
        End Set
    End Property

    ''' <summary>
    ''' 病院CDをセットする
    ''' </summary>
    ''' <param name="Value">病院CD</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p病院CD() As String
        Set(ByVal Value As String)

            General.g_ErrorProc = "clsStaffData p病院CD"
            Try
                m_strHospitalCD = Value
            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p職員区分をセットする
    ''' </summary>
    ''' <param name="Value">p職員区分</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p職員区分() As Integer
        Set(ByVal Value As Integer)

            General.g_ErrorProc = "clsStaffData p職員区分"
            Try
                m_lngStaffKbn = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p職員番号をセットする
    ''' </summary>
    ''' <param name="Value">p職員番号</param>
    ''' <remarks>
    ''' 職員区分=0の場合、受け取った職員番号は職員管理番号とみなす<br />
    ''' 職員区分=1の場合、受け取った職員番号は表示用の職員番号とみなす
    ''' </remarks>
    Public WriteOnly Property p職員番号() As String
        Set(ByVal Value As String)
            General.g_ErrorProc = "clsStaffData p職員番号"
            Try
                m_strStaffNo = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' 開始年月日をセットする
    ''' </summary>
    ''' <param name="Value">開始年月日</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p開始年月日() As Integer
        Set(ByVal Value As Integer)

            General.g_ErrorProc = "clsStaffData p開始年月日"
            Try
                m_lngStartDate = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' 終了年月日をセットする
    ''' </summary>
    ''' <param name="Value">終了年月日</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p終了年月日() As Integer
        Set(ByVal Value As Integer)
            Try
                General.g_ErrorProc = "clsStaffData p終了年月日"

                m_lngEndDate = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' 日付区分をセットする
    ''' </summary>
    ''' <param name="Value">日付区分（0:単一日、1:期間）</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p日付区分() As Integer
        Set(ByVal Value As Integer)
            Try
                General.g_ErrorProc = "clsStaffData p日付区分"

                '0:単一日 1:期間
                m_lngHidukeKbn = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p対象CDをセットする
    ''' </summary>
    ''' <param name="Value">p対象CD</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p対象CD() As String
        Set(ByVal Value As String)
            Try
                General.g_ErrorProc = "clsStaffData p対象CD"

                m_strTargetCD = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    '*********************************************************************************
    '勤務実績・超勤データ取得部品 START
    '*********************************************************************************

    ''' <summary>
    ''' p当直勤務CDをセットする
    ''' </summary>
    ''' <param name="Value">p当直勤務CD</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p当直勤務CD() As String
        Set(ByVal Value As String)
            Try
                General.g_ErrorProc = "clsStaffData p当直勤務CD"

                G_StrTouchokuKinmuCD = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p年月日をセットする
    ''' </summary>
    ''' <param name="Value">p年月日（0:単一日、1:期間）</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p年月日() As Integer
        Set(ByVal Value As Integer)
            Try
                General.g_ErrorProc = "clsStaffData p年月日"

                Dim w_blnRc As Boolean

                '日付区分
                Select Case m_lngHidukeKbn
                    Case 0 '単一日
                        '参照年月日を設定
                        If Value >= m_lngStartDate Then
                            g_lngJissekiChokinDate = Value
                            g_lngJissekiChokinDataDate = Value
                        Else
                            g_lngJissekiChokinDate = 0
                            g_lngJissekiChokinDataDate = 0
                            Exit Property
                        End If

                    Case 1 '期間
                        '参照年月日を設定
                        If Value >= m_lngStartDate AndAlso Value <= m_lngEndDate Then
                            g_lngJissekiChokinDate = Value
                            g_lngJissekiChokinDataDate = Value
                        Else
                            g_lngJissekiChokinDate = 0
                            g_lngJissekiChokinDataDate = 0
                            Exit Property
                        End If
                End Select

                '予定データ検索
                w_blnRc = fncblnJissekiChokinKensaku()

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p超勤時間索引をセットする
    ''' </summary>
    ''' <param name="Value">p超勤時間索引</param>
    ''' <remarks>p超勤時間索引＞超勤データ件数の場合セットしない</remarks>
    Public WriteOnly Property p超勤時間索引() As Short
        Set(ByVal Value As Short)
            Try
                General.g_ErrorProc = "clsStaffData p超勤時間索引"

                'データ件数との比較
                If Value > g_lngChokinKensu Then
                    Exit Property
                End If
                '--- 超勤時間索引の取得
                g_lngChokinIndex = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' 採用CDをセットする
    ''' </summary>
    ''' <param name="Value">採用CD</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p採用CD() As String
        Set(ByVal Value As String)
            Try
                General.g_ErrorProc = "clsStaffData p採用CD"

                G_StrSaiyoCD = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    ''' <summary>
    ''' p勤務部署CDをセットする
    ''' </summary>
    ''' <param name="Value">p勤務部署CD</param>
    ''' <remarks></remarks>
    Public WriteOnly Property p勤務部署CD() As String
        Set(ByVal Value As String)
            Try
                General.g_ErrorProc = "clsStaffData p勤務部署CD"

                G_StrKinmuDeptCD = Value

            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property
    '==========================================================================================================


    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '_/_/_/                                 　労基法対応追加分                                         _/_/_/
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
    '************************データ取得部品ｵﾌﾞｼﾞｪﾄ（NSW0000C）****************************

    ''' <summary>
    ''' 時間外取得部品をセットする
    ''' </summary>
    ''' <param name="Value">時間外取得部品</param>
    ''' <remarks></remarks>
    Public WriteOnly Property pGetCyokinObj() As Object
        Set(ByVal Value As Object)
            General.g_objComCyokin = Value
        End Set
    End Property

    ''' <summary>
    ''' 超勤データの取得指示
    ''' 職員単位で超勤データを取得する前に必ず実行する
    ''' </summary>
    ''' <param name="p_strDateJudgment">超勤データの日付判定（０：年月日、１：超勤年月日）※省略時は0で判定</param>
    ''' <returns>（TRUE：データあり、FALSE：0件又はデータなし）</returns>
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
            '--- 項目設定の取得
            '代休管理（０：する、１：しない）
            G_StrDaikyuMng = General.paGetItemValue(General.G_STRMAINKEY2, General.G_STRSUBKEY5, "DAIKYUMNG", "1", m_strHospitalCD)

            If String.IsNullOrEmpty(p_strDateJudgment) Then
                '超勤データの日付判定（０：年月日、１：超勤年月日）
                G_StrDateJudgment = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "DATEJUDGMENT", "0", m_strHospitalCD)
            Else
                G_StrDateJudgment = p_strDateJudgment
            End If

            '週休
            G_StrWeekHolCD = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "WEEKHOLIDAY", "", m_strHospitalCD)
            '自動休日出勤化（０：する、１：しない）
            G_StrAutoHoliday = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "AUTOHOLIDAY", "1", m_strHospitalCD)

            '実働時間減算対象控除
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

            '実働時間減算対象時間休
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

            '100/100実働時間減算対象控除
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

            '100/100実働時間減算対象時間休
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
            '法定時間外越え対象外勤務コード
            G_StrNot60TimeKinmuCD = ""
            w_str = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "LEGALHOLIDAYKINMUCD", "", m_strHospitalCD)
            w_var = General.paSplit(w_str, ",")
            For w_lngLoop = 0 To UBound(w_var)
                G_StrNot60TimeKinmuCD = G_StrNot60TimeKinmuCD & General.paFormatSpace(w_var(w_lngLoop), 3) & ","
            Next w_lngLoop
            '法定時間上限時間
            g_lng60Time = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "LIMITTIME", "3600", m_strHospitalCD)
            '100/100加算フラグ
            g_100AddFlg = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY13, "100TANKAADDFLG", "0", m_strHospitalCD)

            '自動休日出勤化対象勤務CDの取得（勤務区分が「勤務」で「全日」）
            Call subGetAutoHolidayKinmuCD()

            '休日情報 取得
            Call subGetHolidayData()

            mOverKinmuInit = True
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 実績勤務・超勤データの取得指示
    ''' 病院CD、職員番号を指定後に実行する。
    ''' </summary>
    ''' <returns>（TRUE：データあり、FALSE：0件又はデータなし）</returns>
    ''' <remarks></remarks>
    Public Function mGetOverKinmuData() As Boolean

        Dim w_lngFrom As Integer
        Dim w_lngTo As Integer
        Dim w_Cnt As Short

        General.g_ErrorProc = "clsStaffData mGetOverKinmuData"

        mGetOverKinmuData = False
        Try
            g_lngJissekiChokinKensu = 0

            '週休日の配列 初期化
            ReDim g_lngWeeklyHolDate(0)

            If m_lngHidukeKbn = 0 Then
                '日付区分＝単一日の場合
                w_lngFrom = m_lngStartDate
                w_lngTo = m_lngStartDate
            Else
                '日付区分＝期間の場合
                w_lngFrom = m_lngStartDate
                w_lngTo = m_lngEndDate
            End If

            '開始日が末日の場合、開始日の月のデータは取得しない
            If "01".Equals(Format(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, General.paGetDateFromDateInteger(w_lngFrom)), "dd")) Then
            Else
                w_lngFrom = Integer.Parse(General.paGetDateStringFromInteger(w_lngFrom, General.G_DATE_ENUM.yyyyMM) & "01")
                w_lngFrom = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, General.paGetDateFromDateInteger(w_lngFrom)), General.G_DATE_ENUM.yyyyMMdd)
            End If
            '2010/04/08 Y.Iguchi Add End##

            '--- 出力対象職員情報の取得
            '採用・看護単位CDの組合せﾃﾞｰﾀ 取得
            Call fncGetSaiyo_Kangotani(w_lngFrom, w_lngTo)

            '--- 取得した採用・看護単位CDの組合せから勤務時間データを取得
            For w_Cnt = 1 To UBound(g_udtStaffHistory)
                Call fncGetSanteiTime(w_Cnt)
            Next w_Cnt

            '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            '   実績データの取得
            '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            '実績ﾃﾞｰﾀ 取得
            If fncGetJissekiData(w_lngFrom, w_lngTo) = False Then Exit Function

            '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            '   超勤データの取得
            '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            '超勤ﾃﾞｰﾀ 取得
            If fncGetCyokinData(w_lngFrom, w_lngTo) = False Then Exit Function

            If g_lngJissekiChokinKensu = 0 Then Exit Function

            mGetOverKinmuData = True
        Catch ex As Exception
            Throw
        End Try
    End Function

    '*********************************************************************************
    '勤務実績・超勤データ取得部品 START
    '*********************************************************************************

    ''' <summary>
    ''' 当直単価を取得する
    ''' </summary>
    ''' <returns>当直単価</returns>
    ''' <remarks></remarks>
    Public Function f当直単価() As Integer
        Try
            General.g_ErrorProc = "clsStaffData f当直単価"

            f当直単価 = g_lngTouchokuTanka

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 年月日を取得する
    ''' </summary>
    ''' <returns>年月日</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f年月日() As Integer
        Try
            General.g_ErrorProc = "clsStaffData f年月日"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f年月日 = 0
            Else
                f年月日 = g_udtJissekiChokin(g_lngJissekiChokinIndex).lngYMD
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 勤務実績・超勤データ件数を取得する
    ''' </summary>
    ''' <returns>勤務実績・超勤データ件数</returns>
    ''' <remarks></remarks>
    Public Function f実績超勤件数() As Integer
        Try
            General.g_ErrorProc = "clsStaffData f実績超勤件数"

            f実績超勤件数 = g_lngJissekiChokinKensu

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 実績勤務CDを取得する
    ''' </summary>
    ''' <returns>実績勤務CD</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f実績勤務CD() As String
        Try
            General.g_ErrorProc = "clsStaffData f実績勤務CD"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f実績勤務CD = ""
            Else
                f実績勤務CD = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuCD
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 実績勤務名称を取得する
    ''' </summary>
    ''' <returns>実績勤務名称</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f実績勤務名称() As String
        Try
            General.g_ErrorProc = "clsStaffData f実績勤務名称"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f実績勤務名称 = ""
            Else
                f実績勤務名称 = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuNM
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 実績勤務記号を取得する
    ''' </summary>
    ''' <returns>実績勤務記号</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f実績勤務記号() As String
        Try
            General.g_ErrorProc = "clsStaffData f実績勤務記号"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f実績勤務記号 = ""
            Else
                f実績勤務記号 = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuMark
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 実績理由区分を取得する
    ''' </summary>
    ''' <returns>実績理由区分</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f実績理由区分() As String
        Try
            General.g_ErrorProc = "clsStaffData f実績理由区分"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f実績理由区分 = ""
            Else
                f実績理由区分 = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuRKbn
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 実績半日勤務FLGを取得する
    ''' </summary>
    ''' <returns>実績半日勤務FLG</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f実績半日勤務FLG() As String
        Try
            General.g_ErrorProc = "clsStaffData f実績半日勤務FLG"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f実績半日勤務FLG = ""
            Else
                f実績半日勤務FLG = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiHalfKinmuFlg
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function
    '------------------------------------------------------------------------------------------------------

    ''' <summary>
    ''' 実績勤務時間FROMを取得する
    ''' </summary>
    ''' <returns>実績勤務時間FROM</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f実績勤務時間FROM() As String
        Try
            General.g_ErrorProc = "clsStaffData f実績勤務時間FROM"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f実績勤務時間FROM = ""
            Else
                f実績勤務時間FROM = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuTime.strFrom
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 実績勤務時間TOを取得する
    ''' </summary>
    ''' <returns>実績勤務時間TO</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f実績勤務時間TO() As String
        Try
            General.g_ErrorProc = "clsStaffData f実績勤務時間TO"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f実績勤務時間TO = ""
            Else
                f実績勤務時間TO = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiKinmuTime.strTo
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 実績実勤務時間を取得する
    ''' </summary>
    ''' <returns>実績実勤務時間</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f実績実勤務時間() As String
        Try
            General.g_ErrorProc = "clsStaffData f実績実勤務時間"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f実績実勤務時間 = ""
            Else
                f実績実勤務時間 = g_udtJissekiChokin(g_lngJissekiChokinIndex).strJissekiJituKinmuTime
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 超勤時間件数を取得する
    ''' </summary>
    ''' <returns>超勤時間件数</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f超勤時間件数() As Short
        Try
            General.g_ErrorProc = "clsStaffData f超勤時間件数"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                g_lngChokinKensu = 0
            Else
                g_lngChokinKensu = UBound(g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinTime)
            End If
            f超勤時間件数 = g_lngChokinKensu

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 超勤時間FROMを取得する
    ''' </summary>
    ''' <returns>超勤時間FROM</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f超勤時間FROM() As String
        Try
            General.g_ErrorProc = "clsStaffData f超勤時間FROM"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超勤時間FROM = ""
            Else
                f超勤時間FROM = g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinTime(g_lngChokinIndex).strFrom
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    '--- 2004.01.05 Add kuro ---

    ''' <summary>
    ''' 超勤勤務年月日を取得する
    ''' </summary>
    ''' <returns>超勤勤務年月日</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f超勤勤務年月日() As Integer
        Try
            General.g_ErrorProc = "clsStaffData f超勤勤務年月日"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超勤勤務年月日 = 0
            Else
                f超勤勤務年月日 = g_udtJissekiChokin(g_lngJissekiChokinIndex).lngChokinOrderDate(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function
    '---------------------------

    ''' <summary>
    ''' 超勤状態区分を取得する
    ''' </summary>
    ''' <returns>超勤状態区分</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f超勤状態区分() As String
        Try
            General.g_ErrorProc = "clsStaffData f超勤状態区分"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超勤状態区分 = ""
            Else
                f超勤状態区分 = g_udtJissekiChokin(g_lngJissekiChokinIndex).strApproveKbn(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 超勤時間TOを取得する
    ''' </summary>
    ''' <returns>超勤時間TO</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f超勤時間TO() As String
        Try
            General.g_ErrorProc = "clsStaffData f超勤時間TO"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超勤時間TO = ""
            Else
                f超勤時間TO = g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinTime(g_lngChokinIndex).strTo
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function


    ''' <summary>
    ''' 超勤UNIQUESEQNOを取得する
    ''' </summary>
    ''' <returns>超勤UNIQUESEQNO</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f超勤UNIQUESEQNO() As String
        Try
            General.g_ErrorProc = "clsStaffData f超勤UNIQUESEQNO"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超勤UNIQUESEQNO = ""
            Else
                f超勤UNIQUESEQNO = g_udtJissekiChokin(g_lngJissekiChokinIndex).strUniqueSeqNo(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function


    ''' <summary>
    ''' 超過勤務時間100を取得する
    ''' </summary>
    ''' <returns>超過勤務時間100</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f超過勤務時間100() As Short
        Try
            General.g_ErrorProc = "clsStaffData f超過勤務時間100"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超過勤務時間100 = 0
            Else
                f超過勤務時間100 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime100(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function


    ''' <summary>
    ''' 超過勤務時間125を取得する
    ''' </summary>
    ''' <returns>超過勤務時間125</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f超過勤務時間125() As Short
        Try
            General.g_ErrorProc = "clsStaffData f超過勤務時間125"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超過勤務時間125 = 0
            Else
                f超過勤務時間125 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime125(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 超過勤務時間135を取得する
    ''' </summary>
    ''' <returns>超過勤務時間135</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f超過勤務時間135() As Short
        Try
            General.g_ErrorProc = "clsStaffData f超過勤務時間135"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超過勤務時間135 = 0
            Else
                f超過勤務時間135 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime135(g_lngChokinIndex)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 超過勤務時間150を取得する
    ''' </summary>
    ''' <returns>超過勤務時間150</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f超過勤務時間150() As Short
        Try
            General.g_ErrorProc = "clsStaffData f超過勤務時間150"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超過勤務時間150 = 0
            Else
                f超過勤務時間150 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime150(g_lngChokinIndex)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 超過勤務時間160を取得する
    ''' </summary>
    ''' <returns>超過勤務時間160</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f超過勤務時間160() As Short
        Try
            General.g_ErrorProc = "clsStaffData f超過勤務時間160"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超過勤務時間160 = 0
            Else
                f超過勤務時間160 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime160(g_lngChokinIndex)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 休日勤務時間を取得する
    ''' </summary>
    ''' <returns>休日勤務時間</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f休日勤務時間() As Short
        Try
            General.g_ErrorProc = "clsStaffData f休日勤務時間"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f休日勤務時間 = 0
            Else
                f休日勤務時間 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intHolidayTime
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 夜間勤務時間を取得する
    ''' </summary>
    ''' <returns>夜間勤務時間</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f夜間勤務時間() As Short
        Try
            General.g_ErrorProc = "clsStaffData f夜間勤務時間"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 Then
                f夜間勤務時間 = 0
            Else
                f夜間勤務時間 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intNightTime
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 超勤理由CDを取得する
    ''' </summary>
    ''' <returns>超勤理由CD</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f超勤理由CD() As String
        Try
            General.g_ErrorProc = "clsStaffData f超勤理由CD"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超勤理由CD = ""
            Else
                f超勤理由CD = g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinRiyu(g_lngChokinIndex).strRiyuCD
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 超勤理由名称を取得する
    ''' </summary>
    ''' <returns>超勤理由名称</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f超勤理由名称() As String
        Try
            General.g_ErrorProc = "clsStaffData f超勤理由名称"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超勤理由名称 = ""
            Else
                f超勤理由名称 = g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinRiyu(g_lngChokinIndex).strRiyuNM
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 超勤理由略称を取得する
    ''' </summary>
    ''' <returns>超勤理由略称</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、""を取得する</remarks>
    Public Function f超勤理由略称() As String
        Try
            General.g_ErrorProc = "clsStaffData f超勤理由略称"

            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超勤理由略称 = ""
            Else
                f超勤理由略称 = g_udtJissekiChokin(g_lngJissekiChokinIndex).strChokinRiyu(g_lngChokinIndex).strRiyuRNM
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 前日超勤
    ''' 参照日付を前日に移動する
    ''' </summary>
    ''' <returns>（TRUE：データあり、FALSE：0件又はデータなし）</returns>
    ''' <remarks>日付区分が単一日の場合、処理中断<br />
    '''          参照年月日が無効の場合、処理中断<br />
    '''          データ検索年月日-1が開始年月日より小さい場合、処理中断
    ''' </remarks>
    Public Function m前日超勤() As Boolean

        General.g_ErrorProc = "cls職員別勤務 m前日超勤"

        Dim w_strData As String
        Dim w_blnRc As Boolean

        m前日超勤 = False
        Try
            '日付区分が単一日なら処理中断
            If m_lngHidukeKbn = 0 Then
                Exit Function
            End If

            '参照年月日が無効だったなら処理中断
            If g_lngJissekiChokinDate = 0 Then
                Exit Function
            End If

            'データ検索年月日-1が開始年月日より小さければ処理中断
            w_strData = General.paGetDateStringFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, General.paGetDateFromDateInteger(g_lngJissekiChokinDataDate)), General.G_DATE_ENUM.yyyyMMdd)
            If m_lngStartDate > Integer.Parse(w_strData) Then
                Exit Function
            End If

            g_lngJissekiChokinDataDate = Integer.Parse(w_strData)

            '予定検索
            w_blnRc = fncblnJissekiChokinKensaku()
            If w_blnRc = False Then
                Exit Function
            End If

            m前日超勤 = True

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 翌日超勤
    ''' 参照日付を翌日に移動する
    ''' </summary>
    ''' <returns>（TRUE：データあり、FALSE：0件又はデータなし）</returns>
    ''' <remarks>日付区分が単一日の場合、処理中断<br />
    '''          参照年月日が無効の場合、処理中断<br />
    '''          データ検索年月日+1が開始年月日より大きい場合、処理中断
    ''' </remarks>
    Public Function m翌日超勤() As Boolean

        General.g_ErrorProc = "cls職員別勤務 m翌日超勤"

        Dim w_strData As String
        Dim w_blnRc As Boolean

        m翌日超勤 = False
        Try
            '日付区分が単一日なら処理中断
            If m_lngHidukeKbn = 0 Then
                Exit Function
            End If

            '参照年月日が無効だったなら処理中断
            If g_lngJissekiChokinDate = 0 Then
                Exit Function
            End If

            'データ検索年月日+1が終了年月日より大きければ処理中断
            w_strData = General.paGetDateStringFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, General.paGetDateFromDateInteger(g_lngJissekiChokinDataDate)), General.G_DATE_ENUM.yyyyMMdd)
            If m_lngEndDate < Integer.Parse(w_strData) Then
                Exit Function
            End If

            g_lngJissekiChokinDataDate = Integer.Parse(w_strData)

            '予定検索
            w_blnRc = fncblnJissekiChokinKensaku()
            If w_blnRc = False Then
                Exit Function
            End If

            m翌日超勤 = True

        Catch ex As Exception
            Call General.paDllTrpMsg(Err.Description, General.g_ErrorProc)
            Throw
        End Try
    End Function

    Private Sub Class_Terminate_Renamed()

        '動的配列の解放
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
    ''' 実績勤務・超勤データの取得指示(該当日のデータのみを取得する)
    ''' 病院CD、職員番号、採用コード、勤務部署コードを指定後に実行する。
    ''' </summary>
    ''' <returns>（TRUE：データあり、FALSE：0件又はデータなし）</returns>
    ''' <remarks></remarks>
    Public Function mGetOverKinmuDataOneDay() As Boolean

        Dim w_lngFrom As Integer
        Dim w_lngTo As Integer
        Dim w_Cnt As Short

        General.g_ErrorProc = "clsStaffData mGetOverKinmuDataOneDay"

        mGetOverKinmuDataOneDay = False
        Try
            g_lngJissekiChokinKensu = 0

            '採用コード必須チェック
            If String.IsNullOrEmpty(G_StrSaiyoCD) Then Exit Function

            '勤務部署コード必須チェック
            If String.IsNullOrEmpty(G_StrKinmuDeptCD) Then Exit Function

            '週休日の配列 初期化
            ReDim g_lngWeeklyHolDate(0)

            If m_lngHidukeKbn = 0 Then
                '日付区分＝単一日の場合
                w_lngFrom = m_lngStartDate
                w_lngTo = m_lngStartDate
            Else
                '日付区分＝期間の場合
                w_lngFrom = m_lngStartDate
                w_lngTo = m_lngEndDate
            End If

            '--- 出力対象職員情報の取得
            '採用・看護単位CDの組合せﾃﾞｰﾀ 取得
            Call fncGetSaiyo_KangotaniOneDay(w_lngFrom, w_lngTo)

            '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            '   実績データの取得
            '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            '実績ﾃﾞｰﾀ 取得
            If fncGetJissekiData(w_lngFrom, w_lngTo) = False Then Exit Function

            '--- 取得した採用・看護単位CD・勤務CDの組合せから勤務時間データを取得
            For w_Cnt = 1 To UBound(g_udtStaffHistory)
                Call fncGetSanteiTimeOneDay(w_Cnt)
            Next w_Cnt

            '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            '   超勤データの取得
            '━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
            '超勤ﾃﾞｰﾀ 取得
            If fncGetCyokinData(w_lngFrom, w_lngTo) = False Then Exit Function

            If g_lngJissekiChokinKensu = 0 Then Exit Function

            mGetOverKinmuDataOneDay = True
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 超過勤務時間150_2を取得する
    ''' </summary>
    ''' <returns>超過勤務時間150_2</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f超過勤務時間150_2() As Short

        General.g_ErrorProc = "clsStaffData f超過勤務時間150_2"
        Try
            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超過勤務時間150_2 = 0
            Else
                f超過勤務時間150_2 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime150_2(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    '************************DLLﾌｧﾝｸｼｮﾝ f超過勤務時間175*****************************
    ''' <summary>
    ''' 超過勤務時間175を取得する
    ''' </summary>
    ''' <returns>超過勤務時間175</returns>
    ''' <remarks>勤務実績・超勤データ件数が０、または、勤務実績・超勤データ索引が０、または、超勤データ件数が０、または、超勤データ索引が０の場合、０を取得する</remarks>
    Public Function f超過勤務時間175() As Short

        General.g_ErrorProc = "clsStaffData f超過勤務時間175"
        Try
            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超過勤務時間175 = 0
            Else
                f超過勤務時間175 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime175(g_lngChokinIndex)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function

    '2018-08-15 Darren ADD START
    Public Function f超過勤務時間25() As Short
        General.g_ErrorProc = "clsStaffData f超過勤務時間25"
        Try
            If g_lngJissekiChokinKensu = 0 OrElse g_lngJissekiChokinIndex = 0 OrElse g_lngChokinKensu = 0 OrElse g_lngChokinIndex = 0 Then
                f超過勤務時間25 = 0
            Else
                f超過勤務時間25 = g_udtJissekiChokin(g_lngJissekiChokinIndex).intChokinTime25(g_lngChokinIndex)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function
    '2018-08-15 Darren ADD END

    ''' <summary>
    ''' 時間外届出累計存在有無を判定する
    ''' </summary>
    ''' <returns>（TRUE：データあり、FALSE：0件又はデータなし）</returns>
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
    ''' 超過勤務時間を取得する
    ''' </summary>
    ''' <returns>超過勤務時間</returns>
    ''' <remarks></remarks>
    Public Function f申請時間() As Integer
        Try
            General.g_ErrorProc = "clsGetOverData f申請時間"

            f申請時間 = m_lngAppliTime

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 確定時間を取得する
    ''' </summary>
    ''' <returns>確定時間</returns>
    ''' <remarks></remarks>
    Public Function f確定時間() As Integer
        Try
            General.g_ErrorProc = "clsGetOverData f確定時間"

            f確定時間 = m_lngDecisionTime

        Catch ex As Exception
            Throw
        End Try
    End Function
End Class