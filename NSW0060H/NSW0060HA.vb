Option Strict Off
Option Explicit On
Imports System.Collections.Generic
Friend Class frmNSW0060HA
    Inherits General.FormBase
    '更新履歴 **********************************************************************************
    '2005/06/20 超勤データの日付判定
    '[0：単価超勤日-計上年月日、1：単価超勤日-計上超勤日、2：単価年月日-計上年月日] (001)
    '2012/06/07 法定超過勤務時間列の追加
    '*******************************************************************************************
    '**** ｽﾌﾟﾚｯﾄﾞ関連の定数 ****

    '2018-08-15 Darren UPDATE START
    'ｽﾌﾟﾚｯﾄﾞの列数
    'Private Const M_Spr_TyokinMaxCol As Integer = 16 '超勤明細表示ｽﾌﾟﾚｯﾄﾞの最大列数
    Private Const M_Spr_TyokinMaxCol As Integer = 18 '超勤明細表示ｽﾌﾟﾚｯﾄﾞの最大列数
    '2018-08-15 Darren UPDATE END

    '超勤明細用ｽﾌﾟﾚｯﾄﾞ列項目
    Private Const M_Spr_TyokinNo As Integer = 0 '№
    Private Const M_Spr_TyokinNameCol As Integer = 1 '氏名
    Private Const M_Spr_BraekCol1 As Integer = 2 '区切り列
    Private Const M_Spr_FirstTanka As Integer = 3 '1つめの単価(100/100)
    Private Const M_Spr_SecondTanka As Integer = 4 '2つめの単価(125/100)
    Private Const M_Spr_ThirdTanka As Integer = 5 '3つめの単価(135/100)
    Private Const M_Spr_FourTanka As Integer = 6 '4つめの単価(150/100)
    Private Const M_Spr_FiveTanka As Integer = 7 '5つめの単価(160/100)
    Private Const M_Spr_SixTanka As Integer = 8 '6つ目の単価(150/100)
    Private Const M_Spr_SevenTanka As Integer = 9 '7つ目の単価(170/100)
    Private Const M_Spr_TotalBraekCol As Integer = 10 '各単価と合計の区切り列
    Private Const M_Spr_TotalTanka As Integer = 11 '単価合計
    Private Const M_Spr_BraekCol2 As Integer = 12 '区切り列
    Private Const M_Spr_NightTanka As Integer = 13 '夜間時間(25/100)
    Private Const M_Spr_BraekCol3 As Integer = 14 '区切り列
    '2018-08-15 Darren UPDATE START
    'Private Const M_Spr_HolidayTanka As Integer = 15 '休日時間(135/100)
    Private Const M_Spr_HolidayTanka As Integer = 17 '休日時間(135/100)
    '2018-08-15 Darren UPDATE END
    '2018-08-15 Darren ADD START
    Private Const M_Spr_BraekCol4 As Integer = 16 '区切り列
    Private Const M_Spr_25 As Integer = 15
    '2018-08-15 Darren ADD START

    'ｽﾌﾟﾚｯﾄﾞの行の高さ
    Private Const M_Spr_RowHeight As Double = 21

    'ｽﾌﾟﾚｯﾄﾞに表示可能な職員数(ｽｸﾛｰﾙしないで表示できる最大人数)
    Private Const M_Spr_NoScrollStaffCnt As Integer = 23

    'ｽﾌﾟﾚｯﾄﾞの色
    'UPGRADE_NOTE: M_Spr_ErrRow_Color は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
    Private M_Spr_ErrRow_Color As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red) 'ｴﾗｰが発生している色
    'Private Const M_Spr_GrayArea_Color As Integer = &H8000000F 'ｼｰﾄがないエリアの色
    Private Const M_Spr_RowColor1 As Integer = 8454016 '職員のﾃﾞｰﾀ行の色(1と2は交互に表示)
    'UPGRADE_NOTE: M_Spr_RowColor2 は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
    Private M_Spr_RowColor2 As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) '職員のﾃﾞｰﾀ行の色

    '*** ﾓｼﾞｭｰﾙﾚﾍﾞﾙ変数 ***
    Private m_HospitalCD As String
    Private m_KangoTCD As String
    Private m_KangoTName As String '看護単位名称
    Private m_UserID As String
    Private m_SelDate As Integer '(YYYYMMDD)
    Private m_LoadOK_Flg As Boolean
    Private m_SelectFrom As Integer '対象月の始まり(表示日を参照して取得)
    Private m_SelectTo As Integer '対象月の終わり(表示日を参照して取得)

    Private m_lngTotal100 As Integer
    Private m_lngTotal125 As Integer
    Private m_lngTotal135 As Integer
    Private m_lngTotal150 As Integer
    Private m_lngTotal160 As Integer
    Private m_lngTankaTotal As Integer
    Private m_lngYakanTotal As Integer
    Private m_lngKyujituTotal As Integer

    Private m_lngTotal150_2 As Integer
    Private m_lngTotal175 As Integer
    '2018-08-15 Darren ADD START
    Private m_lngTotal25 As Integer
    '2018-08-15 Darren ADD END

    Private m_lstLblTanka As List(Of Object) = New List(Of Object)  'コントロール配列（合計単価ラベル）
    Private m_lstLblTitle As List(Of Object) = New List(Of Object)  'コントロール配列（タイトルラベル）
    Private m_lstPicTotal As List(Of Object) = New List(Of Object)  'コントロール配列（合計パネル）

    Private Structure Cyokin_Type
        Dim EndDay As String
        Dim HalfChk As String
        Dim MonthChk As String
    End Structure
    Private m_Cyokin As Cyokin_Type

    '-------------------------
    '   職員情報/歴用 構造体
    '-------------------------
    Private Structure IdoHistory_Type
        Dim lngStartDate As Integer
        Dim lngEndDate As Integer
        Dim strCD As String
        Dim strName As String
    End Structure

    '職員情報 格納構造体
    Private Structure StaffData_type
        Dim strStaffMngNo As String '職員管理番号
        Dim strStaffNo As String '職員番号
        Dim strStaffName As String '職員名
        Dim IdoHistory() As IdoHistory_Type '異動暦
        Dim SaiyoHistory() As IdoHistory_Type '採用暦
        Dim lng125 As Integer '125/100
        Dim lng135 As Integer '135/100
        Dim lng150 As Integer '150/100
        Dim lng160 As Integer '160/100
        Dim lng100 As Integer '125/100
        Dim lngKyujitu As Integer '135/100
        Dim lngYakan As Integer '25/100
        Dim lngTotal As Integer '個人合計
        Dim lngBeforeHalf As Integer '前半合計
        Dim lngAfterHalf As Integer '後半合計

        Dim lng150_2 As Integer '150/100
        Dim lng175 As Integer '170/100
        '2018-08-15 Darren ADD START
        Dim lng25 As Integer '25/100
        '2018-08-15 Darren ADD END

    End Structure
    Private m_StaffData() As StaffData_type

    Private m_objComChokin As NsAid_NSW0300C.clsGetOverData '超勤データ取得用オブジェクト

    '項目設定
    Private m_lngDefSelect As Integer 'デフォルト日
    Private m_lngKikanFlg As Integer '期間設定

    '1ヶ月・半月合計チェック(TotalCheck)
    Private Sub TotalCheck()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HA TotalCheck"

            Dim w_ChkTime_Half As String
            Dim w_ChkTime_Month As String
            Dim w_ChkIntTime As Short
            Dim w_MsgText As String
            Dim w_Date As Date
            Dim w_i As Short
            Dim w_BeforeChkFlg As Boolean
            Dim w_AfterChkFlg As Boolean
            Dim w_MonthChkFlg As Boolean
            Dim w_MonthTotal As Integer
            Dim w_strMsg() As String
            Dim w_MsgResult As MsgBoxResult

            w_BeforeChkFlg = False
            w_AfterChkFlg = False
            w_MonthChkFlg = False

            '**** 半月でのﾁｪｯｸ ****
            w_ChkTime_Half = m_Cyokin.HalfChk
            If IsNumeric(w_ChkTime_Half) = False Then
                '数値として判断できないのでﾁｪｯｸなし
                w_ChkTime_Half = "0"
            End If
            '**** 1ヶ月でのﾁｪｯｸ ****
            w_ChkTime_Month = m_Cyokin.MonthChk
            If IsNumeric(w_ChkTime_Month) = False Then
                '数値として判断できないのでﾁｪｯｸなし
                w_ChkTime_Month = "0"
            End If

            If w_ChkTime_Half <> "0" OrElse w_ChkTime_Month <> "0" Then
                'チェックあり

                '職員数だけLoop
                For w_i = 1 To UBound(m_StaffData)

                    '*** 半月チェック ***
                    If w_ChkTime_Half <> "0" Then
                        'ﾁｪｯｸありの場合
                        w_ChkIntTime = CShort(w_ChkTime_Half)
                        '前半の1日～15日でﾁｪｯｸ
                        If m_StaffData(w_i).lngBeforeHalf > w_ChkIntTime AndAlso w_BeforeChkFlg = False Then
                            'エラー
                            w_BeforeChkFlg = True
                        End If
                        '後半の16日～末日でﾁｪｯｸ
                        If m_StaffData(w_i).lngAfterHalf > w_ChkIntTime AndAlso w_AfterChkFlg = False Then
                            'エラー
                            w_AfterChkFlg = True
                        End If
                    End If

                    '*** 1ヶ月でのﾁｪｯｸ ***
                    If w_ChkTime_Month <> "0" Then
                        'ﾁｪｯｸありの場合
                        w_ChkIntTime = CShort(w_ChkTime_Month)
                        '1ヶ月合計を分単位に変換
                        w_MonthTotal = ((fncChangeTime(m_StaffData(w_i).lngTotal) \ 100) * 60) + (fncChangeTime(m_StaffData(w_i).lngTotal) Mod 100)
                        If w_MonthTotal > Integer.Parse(w_ChkIntTime) AndAlso w_MonthChkFlg = False Then
                            'ｴﾗｰ
                            w_MonthChkFlg = True
                        End If
                    End If

                Next w_i

                '**** 半月エラーの場合 ****
                If w_BeforeChkFlg = True Then
                    '半月でエラーがあった場合
                    w_Date = General.paGetDateFromDateInteger(m_SelectFrom)
                    w_MsgText = w_Date.Day.ToString & "日～"
                    w_MsgText = w_MsgText & w_Date.AddDays(14).Day.ToString & "日"
                    w_MsgText = w_MsgText & "の時間外勤務の累計時間"
                    '*******ﾒｯｾｰｼﾞ***********************************
                    ReDim w_strMsg(1)
                    w_strMsg(1) = w_MsgText
                    w_MsgResult = General.paMsgDsp("NS0279", w_strMsg)
                    '************************************************
                    Exit Sub
                End If
                If w_AfterChkFlg = True Then
                    w_Date = General.paGetDateFromDateInteger(m_SelectFrom)
                    w_MsgText = w_Date.AddDays(15).Day.ToString & "日～"
                    w_MsgText = w_MsgText & General.paGetDateFromDateInteger(m_SelectTo).Day.ToString & "日"
                    w_MsgText = w_MsgText & "の時間外勤務の累計時間"
                    '*******ﾒｯｾｰｼﾞ***********************************
                    ReDim w_strMsg(1)
                    w_strMsg(1) = w_MsgText
                    w_MsgResult = General.paMsgDsp("NS0279", w_strMsg)
                    '************************************************
                End If

                '**** 1ヶ月エラーの場合 ****
                If w_MonthChkFlg = True Then
                    w_MsgText = "一ヶ月"
                    w_MsgText = w_MsgText & "の時間外勤務の累計時間"
                    '*******ﾒｯｾｰｼﾞ***********************************
                    ReDim w_strMsg(1)
                    w_strMsg(1) = w_MsgText
                    w_MsgResult = General.paMsgDsp("NS0279", w_strMsg)
                    '************************************************
                    Exit Sub
                End If

            End If

            General.g_ErrorProc = w_PreErrorProc

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public WriteOnly Property pSetHospital(ByVal p_User As String) As String
        Set(ByVal Value As String)

            m_UserID = p_User
            m_HospitalCD = Value

        End Set
    End Property


    Public WriteOnly Property pSetKangoT(ByVal p_Name As String) As String
        Set(ByVal Value As String)

            m_KangoTName = p_Name
            m_KangoTCD = Value

        End Set
    End Property

    Public WriteOnly Property pSelDate() As Integer
        Set(ByVal Value As Integer)

            m_SelDate = Value

        End Set
    End Property

    Private Sub Get_FromTo()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
            General.g_ErrorProc = "clsNSW0060HA Get_FromTo"


            Dim w_Date1 As Date
            Dim w_Date2 As Date
            Dim w_TempDate As Date
            Dim w_EndDay As String
            Dim w_blnDBFlg As Boolean

            w_blnDBFlg = False

            w_EndDay = m_Cyokin.EndDay
            If IsNumeric(w_EndDay) = False Then
                '日付として判断できないので月末締めとする
                w_EndDay = "0"
            End If

            If CShort(w_EndDay) <= 0 OrElse 31 < CShort(w_EndDay) Then
                '日付として判断できないので月末締めとする
                w_Date1 = General.paGetDateFromDateInteger(Integer.Parse(m_SelDate.ToString & "01"))
                w_TempDate = w_Date1.AddMonths(1)
                w_Date2 = w_TempDate.AddDays(-1)
            End If

            m_SelectFrom = General.paGetDateIntegerFromDate(w_Date1)
            m_SelectTo = General.paGetDateIntegerFromDate(w_Date2)

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdEnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnd.Click

        Me.Close()

    End Sub

    Private Sub frmNSW0060HA_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        General.g_ErrorProc = "clsNSW0060HA Form_Load"

        Dim w_str As String
        Dim w_strMsg() As String

        Try

            '異常値セット

            m_LoadOK_Flg = False

            subSetControlsList()

            '部品にﾃﾞｰﾀﾍﾞｰｽｵﾌﾞｼﾞｪｸﾄと病院CDをｾｯﾄ
            General.g_objGetData.p病院CD = m_HospitalCD

            Cursor.Current = Cursors.WaitCursor

            '項目設定取得
            Call subGetSettei()

            '対象月のFromTo取得
            Call Get_FromTo()

            '対象職員取得
            If GetStaff() = False Then
                '対象ﾃﾞｰﾀなし
                ReDim w_strMsg(1)
                w_strMsg(1) = "出力対象の職員"
                Call General.paMsgDsp("NS0008", w_strMsg)
                Cursor.Current = Cursors.Default
                Me.Close()
                Exit Sub
            End If

            '単価取得
            If GetOverKinmuData() = False Then
                '対象ﾃﾞｰﾀなし
                Cursor.Current = Cursors.Default
                Me.Close()
                Exit Sub
            End If

            '合計計算
            Call subAllTotalTime()

            '選択年月
            w_str = Mid(Convert.ToString(m_SelDate), 1, 4) & "年" & String.Format("{0,2}", Integer.Parse(Mid(Convert.ToString(m_SelDate), 5, 2))) & "月度"
            lblDate.Text = w_str
            '看護単位名称
            lblKangoName.Text = m_KangoTName
            '各単価の名称
            m_lstLblTitle(12).Text = "100/100"
            m_lstLblTitle(3).Text = "125/100"
            m_lstLblTitle(4).Text = "135/100"
            m_lstLblTitle(5).Text = "150/100"
            m_lstLblTitle(6).Text = "160/100"

            m_lstLblTitle(13).Text = "150/100"
            m_lstLblTitle(14).Text = "175/100"

            'ｽﾌﾟﾚｯﾄﾞｼｰﾄの設定
            Call Set_SpreadSheet()

            'ｽﾌﾟﾚｯﾄﾞにﾃﾞｰﾀを表示
            Call Disp_StaffData()

            '画面の中央表示
            Call General.paDspCenter(Me)

            Cursor.Current = Cursors.Default

            m_LoadOK_Flg = True

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Call General.paDllTrpMsg(Str(Err.Number), General.g_ErrorProc)
        End Try
    End Sub

    Private Sub Set_SpreadSheet()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HA Set_SpreadSheet"

            Dim w_TotalRows As Integer
            Dim w_Spred_Height As Double
            Dim w_styleCell As FarPoint.Win.Spread.StyleInfo
            Dim w_tcell As New FarPoint.Win.Spread.CellType.TextCellType()

            sprMain.ResumeLayout()

            '超勤明細ｽﾌﾟﾚｯﾄﾞｼｰﾄの設定
            With sprMain_Sheet1

                '最大列数設定
                .ColumnCount = M_Spr_TyokinMaxCol
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければ(職員数+1)をMaxRowにする
                    .RowCount = UBound(m_StaffData) + 1
                    w_TotalRows = UBound(m_StaffData)
                Else
                    .RowCount = UBound(m_StaffData)
                    w_TotalRows = 0
                End If

                Dim w_intAllColWidth As Integer = 0
                For Each w_col As FarPoint.Win.Spread.Column In .Columns
                    w_intAllColWidth += w_col.Width
                Next

                'ｽｸﾛｰﾙﾊﾞｰの表示非表示
                If UBound(m_StaffData) <= M_Spr_NoScrollStaffCnt Then
                    'ｽｸﾛｰﾙﾊﾞｰ非表示
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
                    sprMain.Width = w_intAllColWidth
                Else
                    'ｽｸﾛｰﾙﾊﾞｰ表示
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always
                    sprMain.Width = w_intAllColWidth + 17
                End If

                '行の高さ設定
                .Rows(-1).Height = M_Spr_RowHeight

                '全列をﾗﾍﾞﾙ型で中央揃えに設定
                w_styleCell = New FarPoint.Win.Spread.StyleInfo
                w_tcell = New FarPoint.Win.Spread.CellType.TextCellType()
                w_styleCell.CellType = w_tcell
                w_styleCell.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                w_styleCell.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
                .Models.Style.SetDirectInfo(-1, -1, w_styleCell)

                '№列をﾗﾍﾞﾙ型で左揃え
                w_styleCell = New FarPoint.Win.Spread.StyleInfo
                w_tcell = New FarPoint.Win.Spread.CellType.TextCellType()
                w_styleCell.CellType = w_tcell
                w_styleCell.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                w_styleCell.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
                w_styleCell.BackColor = SystemColors.Control
                Dim w_inBorderNo As New FarPoint.Win.LineBorder(Color.Gray, 1, False, False, True, True)
                Dim w_outBorderNo As New FarPoint.Win.LineBorder(Color.Black, 1, True, True, True, True)
                Dim w_borderNo As New FarPoint.Win.CompoundBorder(w_outBorderNo, w_inBorderNo)
                w_styleCell.Border = w_borderNo
                .Models.Style.SetDirectInfo(-1, M_Spr_TyokinNo, w_styleCell)

                '職員氏名列と区切り列をﾗﾍﾞﾙ型で左揃え
                w_styleCell = New FarPoint.Win.Spread.StyleInfo
                w_tcell = New FarPoint.Win.Spread.CellType.TextCellType()
                w_styleCell.CellType = w_tcell
                w_styleCell.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                w_styleCell.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
                .Models.Style.SetDirectInfo(-1, M_Spr_TyokinNameCol, w_styleCell)
                .Models.Style.SetDirectInfo(-1, M_Spr_BraekCol1, w_styleCell)

                '動作モード
                .OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly

                '罫線を表示
                w_styleCell = New FarPoint.Win.Spread.StyleInfo
                Dim w_bevelBorder As New FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, Color.Black, Color.Black)
                w_styleCell.Border = w_bevelBorder
                w_styleCell.CellType = w_tcell
                w_styleCell.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                w_styleCell.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
                .Models.Style.SetDirectInfo(-1, -1, w_styleCell)

                'ｽﾌﾟﾚｯﾄﾞ上の合計行の有無(職員数が17人以下の場合はｽﾌﾟﾚｯﾄﾞに合計行を表示)
                If w_TotalRows <> 0 Then
                    '合計行をｽﾌﾟﾚｯﾄﾞ上に表示

                    '全列をﾗﾍﾞﾙ型で中央揃えに設定
                    w_styleCell = New FarPoint.Win.Spread.StyleInfo
                    w_styleCell.BackColor = SystemColors.Control
                    .Models.Style.SetDirectInfo(w_TotalRows, -1, w_styleCell)

                    '№列をﾗﾍﾞﾙ型で左揃え
                    w_styleCell = New FarPoint.Win.Spread.StyleInfo
                    w_styleCell.BackColor = SystemColors.Control
                    .Models.Style.SetDirectInfo(w_TotalRows, M_Spr_TyokinNo, w_styleCell)

                    '職員氏名列を合計ﾀｲﾄﾙに
                    w_styleCell = New FarPoint.Win.Spread.StyleInfo
                    w_styleCell.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                    w_styleCell.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
                    .SetText(w_TotalRows, M_Spr_TyokinNameCol, "合　　計")
                    .Models.Style.SetDirectInfo(w_TotalRows, M_Spr_TyokinNameCol, w_styleCell)

                    '合計はｽﾌﾟﾚｯﾄﾞに表示するため非表示
                    Shape.Visible = False
                    lblTotalTitle.Visible = False
                    vseTotalTitle.Visible = False
                    m_lstPicTotal(0).Visible = False
                    m_lstPicTotal(1).Visible = False
                    m_lstPicTotal(2).Visible = False
                    m_lstPicTotal(3).Visible = False
                    m_lstPicTotal(4).Visible = False
                    m_lstPicTotal(5).Visible = False
                    m_lstPicTotal(6).Visible = False
                    m_lstPicTotal(7).Visible = False
                    m_lstPicTotal(8).Visible = False
                    m_lstPicTotal(9).Visible = False

                End If
                .SelectionPolicy = False

                'ｽﾌﾟﾚｯﾄﾞの大きさ(ｽｸﾛｰﾙなしで表示可能人数を下回っている場合は縮める)
                If UBound(m_StaffData) <= M_Spr_NoScrollStaffCnt Then
                    w_Spred_Height = .RowCount * M_Spr_RowHeight
                Else
                    w_Spred_Height = M_Spr_NoScrollStaffCnt * M_Spr_RowHeight
                End If
                sprMain.Height = w_Spred_Height + 4

                General.paSpreadSizeFit(sprMain, sprMain.VerticalScrollBarPolicy, sprMain.HorizontalScrollBarPolicy, .RowCount, w_intAllColWidth, sprMain.Height)
            End With

            sprMain.ResumeLayout(True)

            General.g_ErrorProc = w_PreErrorProc

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Disp_StaffData()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HA Disp_StaffData"

            Dim w_i As Integer
            Dim w_VarText As String

            Dim w_ChkTime As String
            Dim w_CheckTotal As Short
            Dim w_RowColor As Integer
            Dim w_TotalRows As Integer
            Dim w_styleCell As FarPoint.Win.Spread.StyleInfo
            Dim w_intRow As Integer
            Dim w_style As FarPoint.Win.Spread.StyleInfo


            '個人の時間合計が上限値を超えている場合、赤色表示とする。
            w_ChkTime = m_Cyokin.MonthChk

            'Spread描画処理の一時停止
            sprMain.SuspendLayout()
            '行のスタイルの作成
            w_style = New FarPoint.Win.Spread.StyleInfo

            '超勤明細ｽﾌﾟﾚｯﾄﾞｼｰﾄに貼り付け
            With sprMain_Sheet1

                For w_i = 1 To UBound(m_StaffData)
                    w_intRow = w_i - 1

                    '表示№
                    .SetText(w_intRow, M_Spr_TyokinNo, Convert.ToString(w_i))
                    '氏名
                    .SetText(w_intRow, M_Spr_TyokinNameCol, m_StaffData(w_i).strStaffName)

                    '区切りにスペース入力
                    .SetText(w_intRow, M_Spr_BraekCol1, " ")

                    '100/110の時間合計
                    If m_StaffData(w_i).lng100 > 0 Then
                        .SetText(w_intRow, M_Spr_FirstTanka, fncEditTimeSingle(m_StaffData(w_i).lng100))
                    Else
                        .SetText(w_intRow, M_Spr_FirstTanka, " ")
                    End If

                    '125/110の時間合計
                    If m_StaffData(w_i).lng125 > 0 Then
                        .SetText(w_intRow, M_Spr_SecondTanka, fncEditTimeSingle(m_StaffData(w_i).lng125))
                    End If

                    '135/110の時間合計
                    If m_StaffData(w_i).lng135 > 0 Then
                        .SetText(w_intRow, M_Spr_ThirdTanka, fncEditTimeSingle(m_StaffData(w_i).lng135))
                    End If

                    '150/110の時間合計
                    If m_StaffData(w_i).lng150 > 0 Then
                        .SetText(w_intRow, M_Spr_FourTanka, fncEditTimeSingle(m_StaffData(w_i).lng150))
                    End If

                    '160/110の時間合計
                    If m_StaffData(w_i).lng160 > 0 Then
                        .SetText(w_intRow, M_Spr_FiveTanka, fncEditTimeSingle(m_StaffData(w_i).lng160))
                    End If

                    '150/100の時間合計
                    If m_StaffData(w_i).lng150_2 > 0 Then
                        .SetText(w_intRow, M_Spr_SixTanka, fncEditTimeSingle(m_StaffData(w_i).lng150_2))
                    End If

                    '175/100の時間合計
                    If m_StaffData(w_i).lng175 > 0 Then
                        .SetText(w_intRow, M_Spr_SevenTanka, fncEditTimeSingle(m_StaffData(w_i).lng175))
                    End If

                    '個人の時間合計
                    If m_StaffData(w_i).lngTotal > 0 Then
                        .SetText(w_intRow, M_Spr_TotalTanka, fncEditTimeSingle(m_StaffData(w_i).lngTotal))
                    End If

                    '警告表示が必要?
                    If IsNumeric(w_ChkTime) = True Then
                        '数値として判断できる場合のみﾁｪｯｸする
                        If CShort(w_ChkTime) <> 0 Then
                            '0以外ならﾁｪｯｸ
                            w_CheckTotal = ((m_StaffData(w_i).lngTotal \ 100) * 60) + (m_StaffData(w_i).lngTotal Mod 100)
                            If w_CheckTotal > CShort(w_ChkTime) Then
                                'ｴﾗｰがあればｽﾌﾟﾚｯﾄﾞの文字色を変える
                                w_styleCell = New FarPoint.Win.Spread.StyleInfo
                                w_styleCell.ForeColor = System.Drawing.ColorTranslator.FromOle(M_Spr_ErrRow_Color)
                                .Models.Style.SetDirectInfo(w_i, M_Spr_TotalTanka, w_styleCell)
                            End If
                        End If
                    End If

                    '夜間時間合計
                    If m_StaffData(w_i).lngYakan > 0 Then
                        .SetText(w_intRow, M_Spr_NightTanka, fncEditTimeSingle(m_StaffData(w_i).lngYakan))
                    End If

                    '休日時間合計
                    If m_StaffData(w_i).lngKyujitu > 0 Then
                        .SetText(w_intRow, M_Spr_HolidayTanka, fncEditTimeSingle(m_StaffData(w_i).lngKyujitu))
                    End If

                    '2018-08-15 Darren ADD START
                    If m_StaffData(w_i).lng25 > 0 Then
                        .SetText(w_intRow, M_Spr_25, fncEditTimeSingle(m_StaffData(w_i).lng25))
                    End If
                    '2018-08-15 Darren ADD END

                    '行に色をつける
                    If w_RowColor = M_Spr_RowColor1 Then
                        w_RowColor = M_Spr_RowColor2
                    Else
                        w_RowColor = M_Spr_RowColor1
                    End If

                    'スタイルの適用
                    w_style.BackColor = System.Drawing.ColorTranslator.FromOle(w_RowColor)
                    .SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single
                    For n As Integer = M_Spr_TyokinNameCol To M_Spr_HolidayTanka
                        .Models.Style.SetDirectInfo(w_intRow, n, w_style)
                    Next
                Next w_i

                '看護単位合計
                '100/110
                w_VarText = fncEditTimeTotal(m_lngTotal100)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    w_TotalRows = UBound(m_StaffData)
                    .SetText(w_TotalRows, M_Spr_FirstTanka, w_VarText)
                Else
                    m_lstLblTanka(0).Text = w_VarText
                End If
                '125/110
                w_VarText = fncEditTimeTotal(m_lngTotal125)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    w_TotalRows = UBound(m_StaffData)
                    .SetText(w_TotalRows, M_Spr_SecondTanka, w_VarText)
                Else
                    m_lstLblTanka(1).Text = w_VarText
                End If
                '135/100
                w_VarText = fncEditTimeTotal(m_lngTotal135)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    .SetText(w_TotalRows, M_Spr_ThirdTanka, w_VarText)
                Else
                    m_lstLblTanka(2).Text = w_VarText
                End If
                '150/100
                w_VarText = fncEditTimeTotal(m_lngTotal150)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    .SetText(w_TotalRows, M_Spr_FourTanka, w_VarText)
                Else
                    m_lstLblTanka(3).Text = w_VarText
                End If
                '160/100
                w_VarText = fncEditTimeTotal(m_lngTotal160)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    .SetText(w_TotalRows, M_Spr_FiveTanka, w_VarText)
                Else
                    m_lstLblTanka(4).Text = w_VarText
                End If


                '150/100
                w_VarText = fncEditTimeTotal(m_lngTotal150_2)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    .SetText(w_TotalRows, M_Spr_SixTanka, w_VarText)
                Else
                    m_lstLblTanka(5).Text = w_VarText
                End If
                '175/100
                w_VarText = fncEditTimeTotal(m_lngTotal175)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    .SetText(w_TotalRows, M_Spr_SevenTanka, w_VarText)
                Else
                    m_lstLblTanka(6).Text = w_VarText
                End If

                '単価合計
                w_VarText = fncEditTimeAllTotal(m_lngTankaTotal)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    .SetText(w_TotalRows, M_Spr_TotalTanka, w_VarText)
                Else
                    lblTankaTotal.Text = w_VarText
                End If
                '夜間合計
                w_VarText = fncEditTimeTotal(m_lngYakanTotal)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    .SetText(w_TotalRows, M_Spr_NightTanka, w_VarText)
                Else
                    lblYakanTotal.Text = w_VarText
                End If
                '休日合計
                w_VarText = fncEditTimeTotal(m_lngKyujituTotal)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    .SetText(w_TotalRows, M_Spr_HolidayTanka, w_VarText)
                Else
                    lblOffTotal.Text = w_VarText
                End If
                '2018-08-15 Darren ADD START
                w_VarText = fncEditTimeTotal(m_lngTotal25)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '職員数がｽｸﾛｰﾙなしで表示可能人数より少なければｽﾌﾟﾚｯﾄﾞに表示
                    .SetText(w_TotalRows, M_Spr_25, w_VarText)
                Else
                    lbl25Total.Text = w_VarText
                End If
                '2018-08-15 Darren ADD END
            End With
            'Spread描画処理の再開
            sprMain.ResumeLayout(True)

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub frmNSW0060HA_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        Try
            General.g_ErrorProc = "clsNSW0060HA Form_QueryUnload"

            If m_LoadOK_Flg = True Then
                '半月・1ヶ月ﾁｪｯｸ
                Call TotalCheck()
            End If

            Exit Sub

        Catch ex As Exception
            Call General.paDllTrpMsg(Str(Err.Number), General.g_ErrorProc)
            eventArgs.Cancel = Cancel
        End Try
    End Sub

    Private Sub frmNSW0060HA_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            General.g_ErrorProc = "clsNSW0060HA Form_Unload"

            Erase m_StaffData

            Exit Sub
        Catch ex As Exception
            Call General.paDllTrpMsg(Str(Err.Number), General.g_ErrorProc)
        End Try
    End Sub

    Private Function GetStaff() As Boolean
        Dim w_PreErrorProc As String

        Dim w_lngStaffLoop As Integer
        Dim w_lngWorkLoop As Integer
        Dim w_lngStaffCnt As Integer
        Dim w_strStaffMngID As String
        Dim w_Form As frmNSW0060HB
        Dim w_strTEXT As String
        Dim w_strBkStaffMngID As String
        Dim w_lngGetStaffCnt As Integer

        Try
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HA GetStaff"

            '値の初期化
            w_strBkStaffMngID = ""
            w_lngGetStaffCnt = 0

            GetStaff = False

            '配列初期化
            ReDim m_StaffData(0)

            With General.g_objGetData

                .p病院CD = m_HospitalCD
                .p職員取得FLG = 0
                .p日付区分 = 1
                .pソート順 = 0
                .p開始年月日 = m_SelectFrom
                .p終了年月日 = m_SelectTo
                .p勤務対象FLG = 0
                .p優先順位 = 0
                .p対象CD = m_KangoTCD
                .pチーム区分 = 0
                .pシステム区分 = 0

                If .mGetStaff = False Then
                    '職員が存在しない場合
                    Exit Function
                Else
                    w_lngStaffCnt = .f職員件数
                    '処理経過表示ﾌｫｰﾑ設定
                    w_Form = New frmNSW0060HB
                    w_Form.Show()
                    w_strTEXT = "職員情報を取得中..."
                    Call w_Form.Set_WaitWindow(w_lngStaffCnt, w_strTEXT)

                    For w_lngStaffLoop = 1 To w_lngStaffCnt
                        .p職員索引 = w_lngStaffLoop

                        '職員が変わった？(再雇用対策)
                        If w_strBkStaffMngID <> .f職員管理番号2 Then
                            'ブレイク用職員管理番号取得
                            w_strBkStaffMngID = .f職員管理番号2

                            'カウントＵＰ
                            w_lngGetStaffCnt = w_lngGetStaffCnt + 1

                            '配列拡張
                            ReDim Preserve m_StaffData(w_lngGetStaffCnt)

                            '職員管理番号
                            w_strStaffMngID = .f職員管理番号2

                            m_StaffData(w_lngGetStaffCnt).strStaffMngNo = w_strStaffMngID

                            '職員番号
                            m_StaffData(w_lngGetStaffCnt).strStaffNo = .f職員番号2

                            '職員名
                            m_StaffData(w_lngGetStaffCnt).strStaffName = .f氏名2

                            '===============================================================
                            'mStaffInit
                            '===============================================================
                            .p病院CD = m_HospitalCD
                            .p職員番号変換 = 0
                            .p職員区分 = 0
                            .p職員番号 = w_strStaffMngID
                            .p日付区分 = 1
                            .p開始年月日 = m_SelectFrom
                            .p終了年月日 = m_SelectTo
                            .p履歴ソートFLG = 0
                            .pシステム区分 = 0

                            ReDim m_StaffData(w_lngGetStaffCnt).IdoHistory(0)
                            ReDim m_StaffData(w_lngGetStaffCnt).SaiyoHistory(0)
                            If .mStaffInit() = False Then
                                '職員が存在しない場合
                            Else

                                '採用暦
                                For w_lngWorkLoop = 1 To .f職員管理件数
                                    .p職員管理索引 = w_lngWorkLoop
                                    ReDim Preserve m_StaffData(w_lngGetStaffCnt).SaiyoHistory(UBound(m_StaffData(w_lngGetStaffCnt).SaiyoHistory) + 1)
                                    m_StaffData(w_lngGetStaffCnt).SaiyoHistory(w_lngWorkLoop).strCD = .f採用条件CD
                                    m_StaffData(w_lngGetStaffCnt).SaiyoHistory(w_lngWorkLoop).lngStartDate = .f採用年月日1
                                    m_StaffData(w_lngGetStaffCnt).SaiyoHistory(w_lngWorkLoop).lngEndDate = .f転退年月日1
                                Next w_lngWorkLoop

                                '異動暦
                                For w_lngWorkLoop = 1 To .f配属異動件数
                                    .p配属異動索引 = w_lngWorkLoop
                                    ReDim Preserve m_StaffData(w_lngGetStaffCnt).IdoHistory(UBound(m_StaffData(w_lngGetStaffCnt).IdoHistory) + 1)
                                    m_StaffData(w_lngGetStaffCnt).IdoHistory(w_lngWorkLoop).strCD = .f配属部署CD
                                    m_StaffData(w_lngGetStaffCnt).IdoHistory(w_lngWorkLoop).strName = .f配属部署名称
                                    m_StaffData(w_lngGetStaffCnt).IdoHistory(w_lngWorkLoop).lngStartDate = .f配属異動年月日
                                    m_StaffData(w_lngGetStaffCnt).IdoHistory(w_lngWorkLoop).lngEndDate = .f配属終了年月日
                                Next w_lngWorkLoop

                            End If
                        End If

                        '処理ｶｳﾝﾄ更新
                        Call w_Form.SyoriCount(w_lngStaffLoop, w_lngStaffCnt)
                    Next w_lngStaffLoop

                End If
            End With

            w_Form.Close()

            GetStaff = True

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す

        Catch ex As Exception
            If w_Form Is Nothing = False Then
                w_Form.Close()
            End If
            Throw
        End Try
    End Function


    Private Function GetOverKinmuData() As Boolean
        Dim w_PreErrorProc As String

        Dim w_Form As frmNSW0060HB
        Dim w_strTEXT As String
        Dim w_lngStaffCnt As Integer
        Dim w_lngStaffLoop As Integer
        Dim w_lngWorkLoop As Integer
        Dim w_blnSaiyoFlag As Boolean
        Dim w_lngDate As Integer
        Dim w_lngDataCnt As Integer
        Dim w_Idx As Integer
        Dim w_lngOKCnt As Integer
        Dim w_s As Integer
        Dim w_BeforeTo As Integer

        Dim w_Time125 As Integer
        Dim w_Time135 As Integer
        Dim w_Time150 As Integer
        Dim w_Time160 As Integer
        Dim w_Time100 As Integer
        Dim w_lngDayTotal As Integer

        Dim w_lngOneBeforeDate As Integer

        Dim w_Time150_2 As Integer
        Dim w_Time175 As Integer
        '2018-08-15 Darren ADD START
        Dim w_Time25 As Integer
        '2018-08-15 Darren ADD END

        Try
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HA GetOverKinmuData"

            GetOverKinmuData = False

            w_lngOneBeforeDate = General.paGetDateIntegerFromDate(General.paGetDateFromDateInteger(m_SelectFrom).AddDays(-1))
            '半月ﾁｪｯｸ期間の前半の終了日を取得
            w_BeforeTo = General.paGetDateIntegerFromDate(General.paGetDateFromDateInteger(m_SelectFrom).AddDays(14))

            '既にｵﾌﾞｼﾞｪｸﾄが生成されているか?
            If m_objComChokin Is Nothing Then
                'ｵﾌﾞｼﾞｪｸﾄが生成されていない場合
                m_objComChokin = New NsAid_NSW0300C.clsGetOverData
                '各ﾌﾟﾛﾊﾟﾃｨを設定する
                With m_objComChokin
                    .p病院CD = m_HospitalCD
                    .pGetDataObj = General.g_objGetData
                End With
            End If

            m_objComChokin.p日付区分 = 1 '期間
            m_objComChokin.p開始年月日 = w_lngOneBeforeDate
            m_objComChokin.p終了年月日 = m_SelectTo
            m_objComChokin.p対象CD = m_KangoTCD
            If m_objComChokin.mOverKinmuInit(General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "DATEJUDGMENT", "0", m_HospitalCD)) = False Then

            End If

            w_lngStaffCnt = UBound(m_StaffData)
            '処理経過表示ﾌｫｰﾑ設定
            w_Form = New frmNSW0060HB
            w_Form.Show()
            w_strTEXT = "勤務データを取得、計算中..."
            Call w_Form.Set_WaitWindow(w_lngStaffCnt, w_strTEXT)


            For w_lngStaffLoop = 1 To w_lngStaffCnt

                With m_objComChokin
                    '--- 出力対象職員情報の取得
                    .p病院CD = m_HospitalCD
                    .p職員区分 = 0
                    .p職員番号 = m_StaffData(w_lngStaffLoop).strStaffMngNo
                    .p日付区分 = 1 '--- 期間
                    .p開始年月日 = w_lngOneBeforeDate
                    .p終了年月日 = m_SelectTo

                    If m_objComChokin.mGetOverKinmuData() = False Then
                    Else

                        w_lngDataCnt = .f実績超勤件数
                        .p年月日 = w_lngOneBeforeDate
                        For w_Idx = 0 To w_lngDataCnt

                            w_lngDate = .f年月日

                            w_Time125 = 0
                            w_Time135 = 0
                            w_Time150 = 0
                            w_Time160 = 0
                            w_Time100 = 0
                            w_lngDayTotal = 0

                            w_Time150_2 = 0
                            w_Time175 = 0
                            '2018-08-15 Darren ADD START
                            w_Time25 = 0
                            '2018-08-15 Darren ADD END

                            If w_lngDate > 0 Then

                                w_blnSaiyoFlag = False
                                For w_lngWorkLoop = 1 To UBound(m_StaffData(w_lngStaffLoop).SaiyoHistory)
                                    If m_StaffData(w_lngStaffLoop).SaiyoHistory(w_lngWorkLoop).lngStartDate <= w_lngDate AndAlso w_lngDate <= m_StaffData(w_lngStaffLoop).SaiyoHistory(w_lngWorkLoop).lngEndDate Then
                                        w_blnSaiyoFlag = True
                                        Exit For
                                    End If
                                Next w_lngWorkLoop

                                If w_blnSaiyoFlag = True Then
                                    '現日付時点においては退職していない場合
                                    If w_lngOneBeforeDate = w_lngDate Then

                                    Else
                                        w_lngOKCnt = .f超勤時間件数
                                        For w_s = 1 To w_lngOKCnt
                                            .p超勤時間索引 = w_s
                                            '========================
                                            '   超勤単価別時間 算出
                                            '========================
                                            '超勤ﾃﾞｰﾀがあるかどうか判断
                                            If .f超勤時間FROM <> "" AndAlso .f超勤時間TO <> "" Then
                                                If .f超勤状態区分 = "1" Then

                                                    w_Time125 = .f超過勤務時間125
                                                    w_Time135 = .f超過勤務時間135
                                                    w_Time150 = .f超過勤務時間150
                                                    w_Time160 = .f超過勤務時間160
                                                    w_Time100 = .f超過勤務時間100

                                                    w_Time150_2 = .f超過勤務時間150_2
                                                    w_Time175 = .f超過勤務時間175

                                                    '2018-08-15 Darren ADD START
                                                    w_Time25 = .f超過勤務時間25
                                                    '2018-08-15 Darren ADD END

                                                    'w_lngDayTotal = w_Time125 + w_Time135 + w_Time150 + w_Time160 + w_Time100
                                                    w_lngDayTotal = w_Time125 + w_Time135 + w_Time150 + w_Time160 + w_Time100 + w_Time150_2 + w_Time175 + w_Time25

                                                    '◆祝休日以外の日の場合
                                                    '--------------
                                                    '   125/100
                                                    '--------------
                                                    If w_Time125 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng125 = m_StaffData(w_lngStaffLoop).lng125 + w_Time125
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time125
                                                    End If
                                                    '--------------
                                                    '   150/100
                                                    '--------------
                                                    If w_Time150 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng150 = m_StaffData(w_lngStaffLoop).lng150 + w_Time150
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time150
                                                    End If
                                                    '◆祝休日の場合
                                                    '--------------
                                                    '   135/100
                                                    '--------------
                                                    If w_Time135 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng135 = m_StaffData(w_lngStaffLoop).lng135 + w_Time135
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time135
                                                    End If
                                                    '--------------
                                                    '   160/100
                                                    '--------------
                                                    If w_Time160 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng160 = m_StaffData(w_lngStaffLoop).lng160 + w_Time160
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time160
                                                    End If

                                                    '--------------
                                                    '   100/100
                                                    '--------------
                                                    If w_Time100 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng100 = m_StaffData(w_lngStaffLoop).lng100 + w_Time100
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time100
                                                    End If


                                                    '--------------
                                                    '   150/100
                                                    '--------------
                                                    If w_Time150_2 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng150_2 = m_StaffData(w_lngStaffLoop).lng150_2 + w_Time150_2
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time150_2
                                                    End If


                                                    '--------------
                                                    '   175/100
                                                    '--------------
                                                    If w_Time175 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng175 = m_StaffData(w_lngStaffLoop).lng175 + w_Time175
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time175
                                                    End If

                                                    '2018-08-15 Darren ADD START
                                                    '--------------
                                                    '   25/100
                                                    '--------------
                                                    If w_Time25 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng25 = m_StaffData(w_lngStaffLoop).lng25 + w_Time25
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time25
                                                    End If
                                                    '2018-08-15 Darren ADD END

                                                End If
                                            End If
                                        Next w_s

                                        '-----------------------------
                                        '   休日勤務時間 計算＆格納
                                        '-----------------------------
                                        If .f休日勤務時間 > 0 Then
                                            m_StaffData(w_lngStaffLoop).lngKyujitu = m_StaffData(w_lngStaffLoop).lngKyujitu + .f休日勤務時間
                                        End If
                                        '-----------------------------
                                        '   夜間勤務時間 計算＆格納
                                        '-----------------------------
                                        If .f夜間勤務時間 > 0 Then
                                            m_StaffData(w_lngStaffLoop).lngYakan = m_StaffData(w_lngStaffLoop).lngYakan + .f夜間勤務時間
                                        End If
                                    End If
                                End If '退職しているか？

                                If m_SelectFrom <= w_lngDate AndAlso w_lngDate <= w_BeforeTo Then
                                    '前半月の場合
                                    m_StaffData(w_lngStaffLoop).lngBeforeHalf = m_StaffData(w_lngStaffLoop).lngBeforeHalf + w_lngDayTotal
                                Else
                                    '後半月の場合
                                    m_StaffData(w_lngStaffLoop).lngAfterHalf = m_StaffData(w_lngStaffLoop).lngAfterHalf + w_lngDayTotal
                                End If
                            End If

                            .m翌日超勤()
                        Next w_Idx
                    End If
                End With


                '処理ｶｳﾝﾄ更新
                Call w_Form.SyoriCount(w_lngStaffLoop, w_lngStaffCnt)
            Next w_lngStaffLoop

            w_Form.Close()

            GetOverKinmuData = True

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す
        Catch ex As Exception
            If w_Form Is Nothing = False Then
                w_Form.Close()
            End If
            Throw
        End Try
    End Function


    '分を変換(90⇒130)
    Private Function fncChangeTime(ByVal p_lngMiniteTime As Integer) As Integer
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
            General.g_ErrorProc = "clsNSW0060HA fncChangeTime"

            Dim w_Hour As Integer
            Dim w_Min As Integer
            Dim w_lngChangeTime As Integer

            fncChangeTime = 0

            w_Min = p_lngMiniteTime
            w_Hour = (w_Min \ 60)
            w_Min = w_Min Mod 60
            w_lngChangeTime = (w_Hour) * 100 + w_Min

            fncChangeTime = w_lngChangeTime

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す

        Catch ex As Exception
            Throw
        End Try
    End Function

    '合計計算
    Private Sub subAllTotalTime()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
            General.g_ErrorProc = "clsNSW0060HA subAllTotalTime"

            Dim w_lngWorkLoop As Integer

            For w_lngWorkLoop = 1 To UBound(m_StaffData)

                m_lngTotal100 = m_lngTotal100 + m_StaffData(w_lngWorkLoop).lng100
                m_lngTotal125 = m_lngTotal125 + m_StaffData(w_lngWorkLoop).lng125
                m_lngTotal135 = m_lngTotal135 + m_StaffData(w_lngWorkLoop).lng135
                m_lngTotal150 = m_lngTotal150 + m_StaffData(w_lngWorkLoop).lng150
                m_lngTotal160 = m_lngTotal160 + m_StaffData(w_lngWorkLoop).lng160
                m_lngTotal150_2 = m_lngTotal150_2 + m_StaffData(w_lngWorkLoop).lng150_2
                m_lngTotal175 = m_lngTotal175 + m_StaffData(w_lngWorkLoop).lng175
                m_lngTankaTotal = m_lngTankaTotal + m_StaffData(w_lngWorkLoop).lngTotal
                m_lngYakanTotal = m_lngYakanTotal + m_StaffData(w_lngWorkLoop).lngYakan
                m_lngKyujituTotal = m_lngKyujituTotal + m_StaffData(w_lngWorkLoop).lngKyujitu
                '2018-08-15 Darren ADD START
                m_lngTotal25 = m_lngTotal25 + m_StaffData(w_lngWorkLoop).lng25
                '2018-08-15 Darren ADD END

            Next w_lngWorkLoop


            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す

        Catch ex As Exception
            Throw
        End Try
    End Sub

    '項目設定取得
    Private Sub subGetSettei()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc 'ﾌﾟﾛｼｰｼﾞｬ名の一時待避
            General.g_ErrorProc = "clsNSW0060HA subGetSettei"

            m_Cyokin.EndDay = ""
            m_Cyokin.HalfChk = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "OKTIMEHALFMIN", Convert.ToString(0), m_HospitalCD)
            m_Cyokin.MonthChk = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "OKTIMERUIKEIMIN", Convert.ToString(0), m_HospitalCD)

            m_lngDefSelect = Integer.Parse(General.paGetItemValue(General.G_STRMAINKEY3, "OVERKINMUINFO", "DEFSELECT", Convert.ToString(0), m_HospitalCD))

            m_SelDate = General.paGetDateIntegerFromDate(General.paGetDateFromDateInteger(m_SelDate).AddMonths(m_lngDefSelect), General.G_DATE_ENUM.yyyyMM)

            General.g_ErrorProc = w_PreErrorProc '待避ﾌﾟﾛｼｰｼﾞｬ名を元に戻す

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' コントロール配列を設定します。
    ''' </summary>
    Private Sub subSetControlsList()

        '合計単価ラベル
        General.paSetControlList(_picTotal_0, "_lblTanka_", m_lstLblTanka)    '100/100?
        General.paSetControlList(_picTotal_1, "_lblTanka_", m_lstLblTanka, 1) '125/100?
        General.paSetControlList(_picTotal_2, "_lblTanka_", m_lstLblTanka, 2) '135/100?
        General.paSetControlList(_picTotal_3, "_lblTanka_", m_lstLblTanka, 3) '150/100?
        General.paSetControlList(_picTotal_7, "_lblTanka_", m_lstLblTanka, 4) '160/100?
        General.paSetControlList(_picTotal_8, "_lblTanka_", m_lstLblTanka, 5) '150/100?
        General.paSetControlList(_picTotal_9, "_lblTanka_", m_lstLblTanka, 6) '170/100?

        'タイトルラベル
        General.paSetControlList(Me, "_lblTitle_", m_lstLblTitle)

        '合計パネル
        General.paSetControlList(Me, "_picTotal_", m_lstPicTotal)

    End Sub

    ''' <summary>
    ''' 時間をhh:mm形式に編集します。（単項目用）
    ''' </summary>
    ''' <param name="p_intTime">編集対象時間</param>
    ''' <returns>編集後時間</returns>
    Private Function fncEditTimeSingle(ByVal p_intTime As Integer) As String
        fncEditTimeSingle = fncEditTime(p_intTime, 5, 4)
    End Function

    ''' <summary>
    ''' 時間をhh:mm形式に編集します。（合計項目用）
    ''' </summary>
    ''' <param name="p_intTime">編集対象時間</param>
    ''' <returns>編集後時間</returns>
    Private Function fncEditTimeTotal(ByVal p_intTime As Integer) As String
        fncEditTimeTotal = fncEditTime(p_intTime, 6, 4)
    End Function

    ''' <summary>
    ''' 時間をhh:mm形式に編集します。（合計の合計項目用）
    ''' </summary>
    ''' <param name="p_intTime">編集対象時間</param>
    ''' <returns>編集後時間</returns>
    Private Function fncEditTimeAllTotal(ByVal p_intTime As Integer) As String
        fncEditTimeAllTotal = fncEditTime(p_intTime, 6, 5)
    End Function

    ''' <summary>
    ''' 時間をhh:mm形式に編集します。
    ''' </summary>
    ''' <param name="p_intTime">編集対象時間</param>
    ''' <param name="p_intHourZero">時間ゼロ埋め編集用桁数</param>
    ''' <param name="p_intHourBrank">時間空白埋め編集用桁数</param>
    ''' <returns>編集後時間</returns>
    '''  <remarks>
    ''' hh:mm形式とは、hh時間(空白埋め時間空白埋め編集用桁)mm分（ゼロ埋め有2桁）となります。
    ''' 例：引数.編集対象時間=123→戻り値.編集後時間="   2:03"
    ''' </remarks>
    Private Function fncEditTime(ByVal p_intTime As Integer, ByVal p_intHourZero As Integer, ByVal p_intHourBrank As Integer) As String
        Dim w_strRes As String = ""
        Dim w_strTime As String = fncChangeTime(p_intTime).ToString
        Dim w_strFormat As String = "{0," & p_intHourBrank.ToString & "}"

        w_strRes = String.Format(w_strFormat, Integer.Parse(General.paLeft(w_strTime.PadLeft(p_intHourZero, "0"), (p_intHourZero - 2))))
        w_strRes += ":"
        w_strRes += General.paRight(w_strTime.PadLeft(4, "0"), 2)

        fncEditTime = w_strRes
    End Function

    ''' <summary>
    ''' タイトル背景再描画時処理。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub _Title_Paint(ByVal sender As System.Object, ByVal e As PaintEventArgs) Handles _vseTitle_0.Paint, _vseTitle_1.Paint, _vseTitle_2.Paint, _vseTitle_3.Paint, _vseTitle_4.Paint, _vseTitle_5.Paint, _vseTitle_6.Paint, _vseTitle_7.Paint, _vseTitle_8.Paint, _vseTitle_9.Paint, _vseTitle_10.Paint, _vseTitle_11.Paint, _vseTitle_12.Paint, _vseTitle_13.Paint, _vseTitle_14.Paint, _vseTitle_15.Paint, _vseTitle_16.Paint, _vseTitle_17.Paint, vseTotalTitle.Paint

        '表示設定
        CType(sender, Label).BorderStyle = BorderStyle.None
        Dim g As Graphics = e.Graphics
        ControlPaint.DrawBorder3D(g, sender.ClientRectangle, Border3DStyle.Raised, Border3DSide.All)

    End Sub
End Class