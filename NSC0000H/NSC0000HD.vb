Option Strict Off
Option Explicit On

Friend Class frmNSC0000HD
    Inherits General.FormBase

	Private m_strStartMode As String '計画画面表示モード
    Private m_LoadOKFlg As Boolean = True
	Private m_OKCancelFlg As Boolean
	Private m_SelectPlanNo As Integer
	
	Private m_DateNow As Date
    Private m_AfterDataShow As Integer '後表示期間
    Private m_BeforeDataShow As Integer '前表示期間
    Private m_DefSelect As Integer '当月からの相対値

    Private m_UserID As String '20070817 iwasaki add

    Private Structure HospitalInf
        Dim SystemStartDate As Integer
        Dim SystemStartTarm As Integer
        Dim SystemViewType As String
    End Structure
    Private m_HospitalData As HospitalInf

    Private Structure KeikakuCtrl_Type
        Dim PlanNo As Integer '計画番号
        Dim TarmNo As Integer 'ﾀｰﾑ
        Dim PlanStart As Integer '計画期間開始日
        Dim PlanEnd As Integer '計画期間終了日
        Dim LimitDay As Integer '締切日
        Dim LimitDay_R As Integer '実績締切日
        Dim LimitDay_H As Integer '希望締切日
        Dim DataFlg As Boolean 'データの有無（True:データあり，False:データなし）
        Dim UpdateFlg As Boolean 'データ更新の有無（True:更新，False:未更新）
    End Structure
    Private m_KeikakuCtrlData() As KeikakuCtrl_Type

    Private m_KeikakuCtrlIndex() As Integer

    Public ReadOnly Property pLoadOK() As Boolean
        Get
            pLoadOK = m_LoadOKFlg
        End Get
    End Property


    '==================================
    '終了ステータス
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

    '計画画面表示モード
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


            '選択状態取得
            If cmbKikan.SelectedIndex = -1 Then
                '未選択
                ReDim w_strMsg(1)
                w_strMsg(1) = "計画期間"
                Call General.paMsgDsp("NS0002", w_strMsg)
                cmbKikan.Focus()
                Exit Sub
            End If

            '選択期間の計画番号取得
            w_DataIndex = m_KeikakuCtrlIndex(cmbKikan.SelectedIndex)
            m_SelectPlanNo = m_KeikakuCtrlData(w_DataIndex).PlanNo

            'OKﾎﾞﾀﾝ押下（計画画面起動）
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

            'LastUpdTimeDate用
            w_NowDate = Format(Now, "yyyyMMddHHmm")

            'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Call General.paBeginTrans()

            'ﾃﾞｰﾀ件数分Loop
            w_Count = UBound(m_KeikakuCtrlData)
            For w_Loop = 1 To w_Count

                '更新対象か？
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

            'ｺﾐｯﾄ
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

            'ｼｽﾃﾑ日付取得
            m_DateNow = Now

            '施設情報取得
            If Get_HospitalInfData() = False Then
                'データ取得不備
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                ReDim w_strMsg(1)
                w_strMsg(1) = "共通情報"
                Call General.paMsgDsp("NS0032", w_strMsg)
                m_LoadOKFlg = False
                Exit Sub
            End If

            'システム日付とシステム開始日の比較
            If DateDiff(Microsoft.VisualBasic.DateInterval.Day, General.paGetDateFromDateInteger(m_HospitalData.SystemStartDate), m_DateNow) < 0 Then
                'システム開始日が未来日の場合
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                ReDim w_strMsg(1)
                w_strMsg(1) = "システム開始日"
                Call General.paMsgDsp("NS0031", w_strMsg)
                m_LoadOKFlg = False
                Exit Sub
            End If

            w_RegKey = General.G_STRININAME
            '表示計画期間数を取得
            If (General.G_PGMSTARTFLG_CHANGEJISSEKI).Equals(m_strStartMode) OrElse (General.G_PGMSTARTFLG_CHANGEPLAN).Equals(m_strStartMode) Then
                w_KeyHeader = "JISSEKI"
                w_DefAfter = "2"
                w_DefBefore = "9"
                w_DefSelect = "0"
                Me.Text = "勤務変更期間指定"
            Else
                w_KeyHeader = "PLAN"
                w_DefAfter = "3"
                w_DefBefore = "8"
                w_DefSelect = "1"
                Me.Text = "計画期間指定"
            End If
            '後ろ表示期間（デフォルト期間を含めない値とする）
            w_RtnReg = General.paGetItemValue(General.G_STRMAINKEY1, "DISPMONTH", w_KeyHeader & "SHOWAFTER", w_DefAfter, General.g_strHospitalCD)
            If IsNumeric(w_RtnReg) = False Then
                w_RtnReg = w_DefAfter
            End If
            m_AfterDataShow = Integer.Parse(w_RtnReg)
            '前表示期間（デフォルト期間を含めない値とする）
            w_RtnReg = General.paGetItemValue(General.G_STRMAINKEY1, "DISPMONTH", w_KeyHeader & "SHOWBEFORE", w_DefBefore, General.g_strHospitalCD)
            If IsNumeric(w_RtnReg) = False Then
                w_RtnReg = w_DefBefore
            End If
            m_BeforeDataShow = Integer.Parse(w_RtnReg)
            'デフォルト選択期間相対位置（当月から起算する）
            w_RtnReg = General.paGetItemValue(General.G_STRMAINKEY1, "DISPMONTH", w_KeyHeader & "DEFSELECT", w_DefSelect, General.g_strHospitalCD)
            If IsNumeric(w_RtnReg) = False Then
                w_RtnReg = w_DefSelect
            End If
            m_DefSelect = Integer.Parse(w_RtnReg)

            'ｺﾝﾎﾞﾎﾞｯｸｽに計画期間を設定する
            Call Get_KeikakuCtrl()

            '=======================================
            '画面の大きさを設定する
            '=======================================
            '管理方式が一般の場合
            If ("2").Equals(m_HospitalData.SystemViewType) Then
                '表示期間が４週の場合
                cmbKikan.Width = General.paTwipsTopixels(4100)
                w_FormWidth = General.paTwipsTopixels(6200)
                Me.SetBounds(0, 0, w_FormWidth, General.paTwipsTopixels(2010))
                w_ButtonLeft = ((Me.ClientRectangle.Width * 15) - ((cmdOK.Width * 15) * 2.5)) / 2
                w_CancelLeft = w_ButtonLeft + ((cmdOK.Width * 15) * 1.5)
            ElseIf ("3").Equals(m_HospitalData.SystemViewType) Then
                '表示期間が任意の場合
                cmbKikan.Width = General.paTwipsTopixels(2200)
                w_FormWidth = General.paTwipsTopixels(4250)
                Me.SetBounds(0, 0, w_FormWidth, General.paTwipsTopixels(1800))
                w_ButtonLeft = ((Me.ClientRectangle.Width * 15) - ((cmdOK.Width * 15 * 2) + 240)) / 2
                w_CancelLeft = w_ButtonLeft + (cmdOK.Width * 15) + 240
            Else
                '表示期間が１ヶ月の場合
                cmbKikan.Width = General.paTwipsTopixels(2200)
                w_FormWidth = General.paTwipsTopixels(4250)
                Me.SetBounds(0, 0, w_FormWidth, General.paTwipsTopixels(1900))
                w_ButtonLeft = ((Me.ClientRectangle.Width * 15) - ((cmdOK.Width * 15 * 2) + 240)) / 2
                w_CancelLeft = w_ButtonLeft + ((cmdOK.Width * 15) + 240)
            End If

            cmdOK.SetBounds(General.paTwipsTopixels(w_ButtonLeft), General.paTwipsTopixels(900), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
            cmdCancel.SetBounds(General.paTwipsTopixels(w_CancelLeft), General.paTwipsTopixels(900), cmdOK.Width, cmdOK.Height)


            '画面を中央表示する
            Call General.paDspCenter(Me)

            'Cancel押下に設定
            m_OKCancelFlg = False

            'Load処理正常終了
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

            'エラーの戻り値設定
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
                    'データありの場合（1件のみ）
                    .MoveFirst()
                    w_StartDate_F = .Fields("SYSFROMDAY")
                    w_Tarm_F = .Fields("SYSFROMTERM")
                    w_ViewType_F = .Fields("DISPPERIOD")
                    m_HospitalData.SystemStartDate = Integer.Parse(General.paGetDbFieldVal(w_StartDate_F, 0))
                    m_HospitalData.SystemStartTarm = Integer.Parse(General.paGetDbFieldVal(w_Tarm_F, 0))
                    m_HospitalData.SystemViewType = w_ViewType_F.Value & ""
                    'システム開始日が正常か？
                    If IsDate(Format(m_HospitalData.SystemStartDate, "0000/00/00")) = True Then
                        '正常に取得終了
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
    '計画制御Ｆを取得する
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

            'ｼｽﾃﾑ日付を数値型に変換
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
                    'データ無し
                    ReDim m_KeikakuCtrlData(0)
                    w_NowPlanNo = -1
                Else
                    'データが存在する場合
                    .MoveLast()
                    w_Count = .RecordCount
                    .MoveFirst()
                    'ﾌｨｰﾙﾄﾞｵﾌﾞｼﾞｪｸﾄ生成
                    w_PlanNO_F = .Fields("PLANNO")
                    w_TarmNO_F = .Fields("TERM")
                    w_PlanStart_F = .Fields("PLANPERIODFROM")
                    w_PlanEnd_F = .Fields("PLANPERIODTO")
                    w_LimitDay_F = .Fields("PLANDUEDATE")
                    w_RLimitDay_F = .Fields("RESULTDUEDATE")
                    w_HLimitDay_F = .Fields("HOPEDUEDATE")
                    ReDim m_KeikakuCtrlData(w_Count)
                    w_NowPlanNo = -1 '初期化
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
                '当月までの計画制御Ｆを作成する
                Call CreateKeikakuCtrlData(w_DateLong, w_NowPlanNo)
            End If

            'デフォルト表示するPlanNoを計算する
            w_ShowPlanNo = w_NowPlanNo + m_DefSelect
            'ｺﾝﾎﾞﾎﾞｯｸｽに設定するﾃﾞｰﾀの最初と最終PlanNo
            w_ShowStartPlanNo = w_ShowPlanNo - m_BeforeDataShow
            w_ShowEndPlanNo = w_ShowPlanNo + m_AfterDataShow

            '設定すべきPlanNoのﾃﾞｰﾀが存在するか？
            w_Count = UBound(m_KeikakuCtrlData)
            If m_KeikakuCtrlData(w_Count).PlanNo < w_ShowEndPlanNo Then
                '存在しない場合は作成する
                Call CreateKeikakuCtrlData(w_ShowEndPlanNo, w_TempInt)
            End If

            'ﾄﾗﾝｻﾞｸｼｮﾝ開始
            Call General.paBeginTrans()

            'ｺﾝﾎﾞﾎﾞｯｸｽに設定する
            cmbKikan.Items.Clear()
            w_ListIndex = -1
            w_Count = UBound(m_KeikakuCtrlData)
            w_OrderIF_Update = False

            For w_Loop = 1 To w_Count
                '表示対象計画期間？

                If w_ShowStartPlanNo <= m_KeikakuCtrlData(w_Loop).PlanNo AndAlso m_KeikakuCtrlData(w_Loop).PlanNo <= w_ShowEndPlanNo Then
                    '表示対象計画期間の場合

                    'ｺﾝﾎﾞﾎﾞｯｸｽに追加
                    cmbKikan.Items.Add(Get_ComboBoxText(w_Loop))

                    ReDim Preserve m_KeikakuCtrlIndex(cmbKikan.Items.Count)
                    m_KeikakuCtrlIndex(cmbKikan.Items.Count - 1) = w_Loop

                    '選択ListIndex取得
                    If w_ShowPlanNo = m_KeikakuCtrlData(w_Loop).PlanNo Then
                        w_ListIndex = cmbKikan.Items.Count - 1
                    End If

                End If

                'DBに存在しないﾃﾞｰﾀを更新
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

            'ｺﾐｯﾄ
            Call General.paCommit()

            '===============================================================
            '   OrderInterFace 処理
            '===============================================================
            If General.paGetItemValue(General.G_STRMAINKEY1, General.G_STRSUBKEY2, "NUSIF", "0", General.g_strHospitalCD) = "1" AndAlso w_OrderIF_Update = True Then
                '業務分担Ｆ更新
                w_OrderIF_Data = "0301"
                w_OrderIF_Data = w_OrderIF_Data & General.paLeft(General.g_strHospitalCD & Space(2), 2)
                w_OrderIF_Data = w_OrderIF_Data & Format(w_OrderIF_PlanNo, "000")
                '電文作成
                Call General.paOrderInterface_NusIf(w_OrderIF_Data)
            End If

            'ﾘｽﾄのﾃﾞﾌｫﾙﾄ設定
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

            '管理方式が一般の場合
            If ("2").Equals(m_HospitalData.SystemViewType) Then
                '４週表示の場合
                w_Text = w_Text & Format(m_KeikakuCtrlData(pIndex).TarmNo, "00")
                w_Text = w_Text & "回" & Space(1)
                w_Text = w_Text & General.paGetDateStringFromInteger(m_KeikakuCtrlData(pIndex).PlanStart, General.G_DATE_ENUM.yyyy_MM_dd)
                w_Text = w_Text & " ～ "
                w_Text = w_Text & General.paGetDateStringFromInteger(m_KeikakuCtrlData(pIndex).PlanEnd, General.G_DATE_ENUM.yyyy_MM_dd)
            ElseIf ("3").Equals(m_HospitalData.SystemViewType) Then
                '開始日指定の場合
                w_Text = w_Text & Format(General.paGetDateFromDateInteger(m_KeikakuCtrlData(pIndex).PlanStart), "yyyy年 MM月度") & Space(1)
            Else
                '１ヶ月表示の場合
                w_Text = w_Text & General.paLeft(Convert.ToString(m_KeikakuCtrlData(pIndex).PlanStart), 4)
                w_Text = w_Text & "年"
                w_Text = w_Text & Format(Integer.Parse(Mid(Convert.ToString(m_KeikakuCtrlData(pIndex).PlanStart), 5, 2)), "00")
                w_Text = w_Text & "月"
            End If

            Get_ComboBoxText = w_Text

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    '*****************************************************************************************
    '   計画制御Ｆのデータ作成
    '   ﾊﾟﾗﾒｰﾀ：pStopCreate 作成する日付又は計画番号（この引数の値まで作成する）
    '         　pNowPlanNo ｼｽﾃﾑ日付時点での計画番号（必要な場合のみ設定）
    '*****************************************************************************************
    Private Sub CreateKeikakuCtrlData(ByVal pStopCreate As Integer, ByRef pNowPlanNo As Integer)
        Const W_SUBNAME As String = "NSC0000HD CreateKeikakuCtrlData"

        Try
            Dim w_NowDate As Integer
            Dim w_StopType As Boolean 'True：指定日付を含む期間まで作成，False：指定計画番号まで作成
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
            Dim w_DefLimit As Integer '締め切り日のデフォルト（表示期間が4週の場合は、起算日(計画期間開始日)のn日前、1ヶ月の場合は毎月n日 Or 起算日のn日前(ﾏｲﾅｽ設定)）
            Dim w_TempLng As Integer
            Dim w_TempDefLimit As Integer
            Dim w_TempBefore As Date
            '実績締切り基準日用変数
            Dim w_RegRtn2 As String
            Dim w_DefLimit_R As Integer
            Dim w_LimitDate_R As Integer
            Dim w_LimitDayFlg_R As Boolean '
            '希望締切り基準日用変数
            Dim w_RegRtn3 As String
            Dim w_DefLimit_H As Integer
            Dim w_LimitDate_H As Integer
            Dim w_LimitDayFlg_H As Boolean

            w_NowDate = General.paGetDateIntegerFromDate(m_DateNow)

            '締め切り日のデフォルト取得
            w_RegRtn = General.paGetItemValue(General.G_STRMAINKEY3, "DISPMONTH", "DEFPLANLIMIT", "", General.g_strHospitalCD)
            w_RegRtn2 = General.paGetItemValue(General.G_STRMAINKEY3, "DISPMONTH", "DEFRESULTLIMIT", "", General.g_strHospitalCD)
            w_RegRtn3 = General.paGetItemValue(General.G_STRMAINKEY3, "DISPMONTH", "DEFHOPELIMIT", "", General.g_strHospitalCD)
            If IsNumeric(w_RegRtn) = False Then
                '数値として判断できない場合は締め切り日なし
                w_LimitDayFlg = False
            Else
                w_LimitDayFlg = True
                w_DefLimit = Integer.Parse(w_RegRtn)
            End If
            If IsNumeric(w_RegRtn2) = False Then
                '数値として判断できない場合は締め切り日なし
                w_LimitDayFlg_R = False
            Else
                w_LimitDayFlg_R = True
                w_DefLimit_R = Integer.Parse(w_RegRtn2)
            End If
            If IsNumeric(w_RegRtn3) = False Then
                '数値として判断できない場合は締め切り日なし
                w_LimitDayFlg_H = False
            Else
                w_LimitDayFlg_H = True
                w_DefLimit_H = Integer.Parse(w_RegRtn3)
            End If

            '最大作成日付、計画番号を取得
            If IsDate(Format(pStopCreate, "0000/00/00")) = True Then
                w_StopDate = pStopCreate
                w_StopType = True
            Else
                w_StopPlanNo = Integer.Parse(pStopCreate)
                w_StopType = False
            End If

            '既存データの最大Index番号
            w_MaxIndex = UBound(m_KeikakuCtrlData)

            If ("2").Equals(m_HospitalData.SystemViewType) Then
                '表示期間が４週の場合

                'データ作成基準日を設定
                If w_MaxIndex <= 0 Then
                    'ﾃﾞｰﾀがない場合はｼｽﾃﾑ日付
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

                '最大作成日付、又は、計画番号までLoopする
                Do

                    '計画番号を計算する
                    w_PlanNo = w_PlanNo + 1

                    '計画期間終了日を計算する（４週なので28日分）
                    w_EndDate = Date.Parse(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 27, w_StartDate))

                    'ﾀｰﾑ番号を計算
                    w_TramNo = w_TramNo + 1
                    If w_TramNo > 13 Then
                        w_TramNo = 1
                    End If

                    '締め切り日を計算する（デフォルト日で設定する）
                    w_LimitDate = 0 '初期化
                    If w_LimitDayFlg = True Then
                        '４週なのでｎ日前として計算する
                        w_LimitDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1 * w_DefLimit, w_StartDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If
                    w_LimitDate_R = 0
                    If w_LimitDayFlg_R = True Then
                        '実績締切日をｎ日後として計算する
                        w_LimitDate_R = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, w_DefLimit_R, w_EndDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If
                    w_LimitDate_H = 0
                    If w_LimitDayFlg_H = True Then
                        '希望締切日をｎ日前として計算する
                        w_LimitDate_H = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1 * w_DefLimit_H, w_StartDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If

                    '計画制御ﾃﾞｰﾀの配列を拡張する
                    w_MaxIndex = w_MaxIndex + 1
                    ReDim Preserve m_KeikakuCtrlData(w_MaxIndex)
                    '計画制御ﾃﾞｰﾀを格納する
                    m_KeikakuCtrlData(w_MaxIndex).PlanNo = w_PlanNo
                    m_KeikakuCtrlData(w_MaxIndex).PlanStart = General.paGetDateIntegerFromDate(w_StartDate)
                    m_KeikakuCtrlData(w_MaxIndex).PlanEnd = General.paGetDateIntegerFromDate(w_EndDate)
                    m_KeikakuCtrlData(w_MaxIndex).TarmNo = w_TramNo
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay = w_LimitDate
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_R = w_LimitDate_R
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_H = w_LimitDate_H
                    m_KeikakuCtrlData(w_MaxIndex).DataFlg = False
                    m_KeikakuCtrlData(w_MaxIndex).UpdateFlg = False

                    'ｼｽﾃﾑ日付時点での計画番号を退避
                    If General.paGetDateIntegerFromDate(w_StartDate) <= w_NowDate AndAlso w_NowDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                        pNowPlanNo = w_PlanNo
                    End If

                    '最大作成日付、又は、計画番号ならLoop抜け出し
                    If w_StopType = True Then
                        '日付で判断する
                        If w_StopDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                            '最大作成日付を含むデータの場合
                            Exit Do
                        End If
                    Else
                        '計画番号で判断する
                        If w_StopPlanNo <= w_PlanNo Then
                            Exit Do
                        End If
                    End If

                    '計画期間開始日を計算する（計画期間終了日の＋１日）
                    w_StartDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_EndDate)

                Loop

                '任意の場合
            ElseIf ("3").Equals(m_HospitalData.SystemViewType) Then

                'データ作成基準日を設定
                If w_MaxIndex <= 0 Then
                    'ﾃﾞｰﾀがない場合はｼｽﾃﾑ日付
                    w_PlanNo = 0
                    w_StartDate = General.paGetDateFromDateInteger(m_HospitalData.SystemStartDate)
                Else
                    w_PlanNo = m_KeikakuCtrlData(w_MaxIndex).PlanNo
                    w_StartDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, General.paGetDateFromDateInteger(m_KeikakuCtrlData(w_MaxIndex).PlanEnd))
                End If

                '最大作成日付、又は、計画番号までLoopする
                Do

                    '計画番号を計算する
                    w_PlanNo = w_PlanNo + 1

                    '計画期間終了日を計算する →システム開始日付のDD日の前日まで
                    '指定された日付が、翌月に存在する日付か？
                    w_EndDate = DateAdd(Microsoft.VisualBasic.DateInterval.Month, w_PlanNo, General.paGetDateFromDateInteger(m_HospitalData.SystemStartDate))
                    '翌月も存在する日付なら、前日にｼﾌﾄ
                    If Format(w_EndDate, "dd").Equals(Format(w_StartDate, "dd")) Then
                        w_EndDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, w_EndDate)
                    End If

                    '締め切り日を計算する（デフォルト日で設定する）
                    w_LimitDate = 0 '初期化
                    If w_LimitDayFlg = True Then
                        'ｎ日前として計算する
                        w_LimitDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1 * w_DefLimit, w_StartDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If
                    w_LimitDate_R = 0
                    If w_LimitDayFlg_R = True Then
                        '実績締切日をｎ日後として計算する
                        w_LimitDate_R = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, w_DefLimit_R, w_EndDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If
                    w_LimitDate_H = 0
                    If w_LimitDayFlg_H = True Then
                        '希望締切日をｎ日前として計算する
                        w_LimitDate_H = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1 * w_DefLimit_H, w_StartDate), General.G_DATE_ENUM.yyyyMMdd)
                    End If

                    '計画制御ﾃﾞｰﾀの配列を拡張する
                    w_MaxIndex = w_MaxIndex + 1
                    ReDim Preserve m_KeikakuCtrlData(w_MaxIndex)
                    '計画制御ﾃﾞｰﾀを格納する
                    m_KeikakuCtrlData(w_MaxIndex).PlanNo = w_PlanNo
                    m_KeikakuCtrlData(w_MaxIndex).PlanStart = General.paGetDateIntegerFromDate(w_StartDate)
                    m_KeikakuCtrlData(w_MaxIndex).PlanEnd = General.paGetDateIntegerFromDate(w_EndDate)
                    m_KeikakuCtrlData(w_MaxIndex).TarmNo = 0
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay = w_LimitDate
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_R = w_LimitDate_R
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_H = w_LimitDate_H
                    m_KeikakuCtrlData(w_MaxIndex).DataFlg = False
                    m_KeikakuCtrlData(w_MaxIndex).UpdateFlg = False

                    'ｼｽﾃﾑ日付時点での計画番号を退避
                    If General.paGetDateIntegerFromDate(w_StartDate) <= w_NowDate AndAlso w_NowDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                        pNowPlanNo = w_PlanNo
                    End If

                    '最大作成日付、又は、計画番号ならLoop抜け出し
                    If w_StopType = True Then
                        '日付で判断する
                        If w_StopDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                            '最大作成日付を含むデータの場合
                            Exit Do
                        End If
                    Else
                        '計画番号で判断する
                        If w_StopPlanNo <= w_PlanNo Then
                            Exit Do
                        End If
                    End If

                    '計画期間開始日を計算する（計画期間終了日の＋１日）
                    w_StartDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_EndDate)

                Loop

            Else
                '表示期間が１ヶ月の場合

                'データ作成基準日を設定
                If w_MaxIndex <= 0 Then
                    'ﾃﾞｰﾀがない場合はｼｽﾃﾑ日付
                    w_PlanNo = 0
                    w_StartDate = Date.Parse(Format(General.paGetDateFromDateInteger(m_HospitalData.SystemStartDate), "yyyy/MM") & "/01")
                Else
                    w_PlanNo = m_KeikakuCtrlData(w_MaxIndex).PlanNo
                    w_StartDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, General.paGetDateFromDateInteger(m_KeikakuCtrlData(w_MaxIndex).PlanEnd))
                End If

                '最大作成日付、又は、計画番号までLoopする
                Do

                    '計画番号を計算する
                    w_PlanNo = w_PlanNo + 1

                    '計画期間終了日を計算する（１ヶ月なので月末）
                    w_EndDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, w_StartDate))

                    '締め切り日を計算する（デフォルト日で設定する）
                    w_LimitDate = 0 '初期化
                    If w_LimitDayFlg = True AndAlso w_DefLimit <= 31 Then
                        '１ヶ月なので毎月ｎ日 Or n日前として計算する
                        If w_DefLimit <= 0 Then
                            'ﾏｲﾅｽ値の場合はn日前として計算する
                            w_LimitDate = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, w_DefLimit, w_StartDate))
                        Else
                            '1<=w_DefLimit<=31の場合は毎月ｎ日として計算する（月初月末以外にも対応する）
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
                                '当月の日付で計画期間開始日より過去日ならその日を締め切り日とする（例:16日～15日ので計画期間で、10日締め切り日の場合）
                                w_LimitDate = w_TempLng
                            Else
                                w_TempBefore = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -1, w_StartDate)
                                w_TempDefLimit = w_DefLimit
                                Do
                                    'ﾃﾞﾌｫﾙﾄ締め切り日が日付と判断できるまで設定する（例:ﾃﾞﾌｫﾙﾄ締め切り日が30日で 2月の場合など）
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


                    '実績締め切り日を計算する（デフォルト日で設定する）
                    w_LimitDate_R = 0 '初期化
                    If w_LimitDayFlg_R = True AndAlso w_DefLimit_R <= 31 Then
                        '１ヶ月なので毎月ｎ日 Or n日前として計算する
                        If w_DefLimit_R <= 0 Then
                            'ﾏｲﾅｽ値の場合はn日後として計算する
                            w_LimitDate_R = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1 * w_DefLimit_R, w_EndDate))
                        Else
                            '1<=w_DefLimit<=31の場合は毎月ｎ日として計算する（月初月末以外にも対応する）
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
                                '当月の日付で計画期間開始日より過去日ならその日を締め切り日とする（例:16日～15日ので計画期間で、10日締め切り日の場合）
                                w_LimitDate = w_TempLng
                            Else
                                w_TempBefore = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, w_StartDate)
                                w_TempDefLimit = w_DefLimit_R
                                Do
                                    'ﾃﾞﾌｫﾙﾄ締め切り日が日付と判断できるまで設定する（例:ﾃﾞﾌｫﾙﾄ締め切り日が30日で 2月の場合など）
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

                    '希望締め切り日を計算する（デフォルト日で設定する）
                    w_LimitDate_H = 0 '初期化
                    If w_LimitDayFlg_H = True AndAlso w_DefLimit_H <= 31 Then
                        '１ヶ月なので毎月ｎ日 Or n日前として計算する
                        If w_DefLimit_H <= 0 Then
                            'ﾏｲﾅｽ値の場合はn日前として計算する
                            w_LimitDate_H = General.paGetDateIntegerFromDate(DateAdd(Microsoft.VisualBasic.DateInterval.Day, w_DefLimit_H, w_StartDate))
                        Else
                            '1<=w_DefLimit_H<=31の場合は毎月ｎ日として計算する（月初月末以外にも対応する）
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
                                '当月の日付で計画期間開始日より過去日ならその日を締め切り日とする（例:16日～15日ので計画期間で、10日締め切り日の場合）
                                w_LimitDate_H = w_TempLng
                            Else
                                w_TempBefore = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -1, w_StartDate)
                                w_TempDefLimit = w_DefLimit_H
                                Do
                                    'ﾃﾞﾌｫﾙﾄ締め切り日が日付と判断できるまで設定する（例:ﾃﾞﾌｫﾙﾄ締め切り日が30日で 2月の場合など）
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

                    '計画制御ﾃﾞｰﾀの配列を拡張する
                    w_MaxIndex = w_MaxIndex + 1
                    ReDim Preserve m_KeikakuCtrlData(w_MaxIndex)
                    '計画制御ﾃﾞｰﾀを格納する
                    m_KeikakuCtrlData(w_MaxIndex).PlanNo = w_PlanNo
                    m_KeikakuCtrlData(w_MaxIndex).PlanStart = General.paGetDateIntegerFromDate(w_StartDate)
                    m_KeikakuCtrlData(w_MaxIndex).PlanEnd = General.paGetDateIntegerFromDate(w_EndDate)
                    m_KeikakuCtrlData(w_MaxIndex).TarmNo = 0
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay = w_LimitDate
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_R = w_LimitDate_R
                    m_KeikakuCtrlData(w_MaxIndex).LimitDay_H = w_LimitDate_H
                    m_KeikakuCtrlData(w_MaxIndex).DataFlg = False
                    m_KeikakuCtrlData(w_MaxIndex).UpdateFlg = False

                    'ｼｽﾃﾑ日付時点での計画番号を退避
                    If General.paGetDateIntegerFromDate(w_StartDate) <= w_NowDate AndAlso w_NowDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                        pNowPlanNo = w_PlanNo
                    End If

                    '最大作成日付、又は、計画番号ならLoop抜け出し
                    If w_StopType = True Then
                        '日付で判断する
                        If w_StopDate <= General.paGetDateIntegerFromDate(w_EndDate) Then
                            '最大作成日付を含むデータの場合
                            Exit Do
                        End If
                    Else
                        '計画番号で判断する
                        If w_StopPlanNo <= w_PlanNo Then
                            Exit Do
                        End If
                    End If

                    '計画期間開始日を計算する（計画期間終了日の＋１日）
                    w_StartDate = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, w_EndDate)

                Loop

            End If

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub
End Class