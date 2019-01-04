Option Strict Off
Option Explicit On

Module BasNSC0000H
	'/----------------------------------------------------------------------/
	'/
	'/    ｼｽﾃﾑ名称：共通コンポーネント
	'/        画面：共通コンポーネント
	'/        ＩＤ：NSC0000H
	'/
	'/
	'/      作成者：        CREATE 2006/03/01          REV 01.00
	'/      更新者： M.Isida       2008/11/17          【P-00812】
    '/      更新者： M.N           2008/11/27          【P-00866】
	'/      更新者： T.Okamoto     2008/12/02          【P-00853】
	'/      更新者： T.Okamoto     2008/12/02          【PRE-0279】
	'/      更新者： T.Okamoto     2008/12/16          【P-00990】
	'/      更新者： T.Okamoto     2008/12/19          【P-01026】
	'/      更新者： M.N           2008/12/24          【P-01076】
	'/      更新者： T.Okamoto     2008/12/25          【P-01065】
	'/      更新者： M.I           2009/01/15          【P-01151】
	'/      更新者： M.I           2009/01/28          【P-01310】
	'/      更新者： okamura       2009/04/02          【P-01573】
	'/      更新者： M.N           2009/06/05          【PKG-0124】
	'/      更新者： M.I           2009/06/05          【PKG-0148】
	'/      更新者： M.N           2009/06/09          【PKG-0220】
	'/      更新者： M.N           2009/06/09          【PRE-0641】
	'/      更新者： E.S           2009/06/10          【PRE-0098】
	'/      更新者： M.I           2009/06/11          【PRE-0129】
	'/      更新者： M.N           2009/06/12          【PKG-0127】
	'/      更新者： M.N           2009/06/13          【PKG-0089】
	'/      更新者： E.S           2009/06/16          【PKG-0162】
	'/      更新者： E.S           2009/06/17          【PKG-0147】
	'/      更新者： M.N           2009/06/23          【PRE-0761】
	'/      更新者： M.N           2009/06/25          【PRE-0772】
	'/      更新者： M.N           2009/06/25          【PRE-0750】
	'/      更新者： M.N           2009/06/26          【PRE-0808】
	'/      更新者： M.N           2009/07/02          【PRE-0843】
	'/      更新者： M.N           2009/07/02          【PRE-0883】
	'/      更新者： M.I           2009/07/13          【PRE-0914】
	'/      更新者： E.S           2009/07/13          【P-02019】
	'/      更新者： E.S           2009/11/16          【P-02354】
	'/      更新者：                   /  /
	'/
	'/                        更新内容：
	'/     Copyright (C) Inter co.,ltd 1997
	'/----------------------------------------------------------------------/
	
	'定数
	Public Const G_PROJECTID As String = "NSC0000H"
	
	Public Const G_OBJECTKBN_EXE As String = "1" 'EXE
	Public Const G_OBJECTKBN_DLL As String = "2" 'DLL
	Public Const G_OBJECTKBN_FORM As String = "3" 'フォーム
	Public Const G_OBJECTKBN_OTHER As String = "9" 'その他
	
	Public Const G_PACKAGENAME_MED As String = "MedWorks"
	Public Const G_PACKAGENAME_NSAID As String = "NurseAid"
	
	'ｸﾗｽｵﾌﾞｼﾞｪｸﾄ宣言
	Public g_ClsMain As New clsMainForm '初期画面ｸﾗｽｵﾌﾞｼﾞｪｸﾄ
	
	Public g_Kyotuinf() As NS001CD_Type '施設情報配列
	Public g_HolidayM() As Holiday_Type '休日マスタ情報
	Public g_KinmuM() As KinmuM_Type '勤務マスタ情報（すべて）
	Public g_MenuM() As Menu_Type 'メニューマスタ
	
    Public g_strSelWardDeptCD As String
	Public g_strSelWardDeptNm As String
	Public g_strSelPostCD As String
	Public g_strSelPostNm As String
	Public g_strSelJobCD As String
	Public g_strSelJobNm As String
	
    Public g_strSelSaikeiFlg As String
	
	
	'==========================
	'構造体:共通情報マスタ
	'==========================
	Public Structure NS001CD_Type
		Dim ByoinCD As String '施設ｺｰﾄﾞ
		Dim Name As String '施設名称
		Dim Sysdate As Integer 'ｼｽﾃﾑ開始日
        Dim Systerm As Integer 'ｼｽﾃﾑ開始ﾀｰﾑ
        Dim Tani As String '計画単位
        Dim Hyoji As String '表示期間
        Dim Fdate As Long 'RegistFirstTimeDate
        Dim Ldate As Long 'LastUpdTimeDate
        Dim UserID As String 'RegistrantID
    End Structure

    '==========================
    '構造体：休日マスタ
    '==========================
    Public Structure Holiday_Type
        Dim lngDate As Integer
        Dim strName As String
        Dim strHolKbn As String
    End Structure

    '==========================
    '構造体：勤務マスタ（全て）
    '==========================
    Public Structure KinmuM_Type
        Dim strCD As String 'コード
        Dim strName As String '名称
        Dim strMark As String '記号
        Dim lngDispNo As Integer '表示順
        Dim strKinmuKbn As String '勤務区分　1：勤務　2：勤務以外
        Dim strKinmuBunruiCD As String '勤務分類　1：勤務　2：休み　3：特殊
        Dim strGtDaikyuFlg As String '代休取得　1：可能　2：不可
        Dim strGetTimeHolFlg As String '時間休暇　1：可能　0：不可
        Dim strKinmuGroupCD As String '勤務グループコード
        Dim strHolBunruiCD As String '休み分類
        Dim strHalfFlg As String '全日半日　1：全日　2：半日
        Dim strAMKinmuCD As String 'AM勤務コード
        Dim strPMKinmuCD As String 'PM勤務コード
    End Structure

    '==========================
    '構造体:メニューマスタ
    '==========================
    Public Structure ListBarMenu_Type
        Dim strResCD As String 'リソースコード
        Dim strTitle As String 'タイトル
        Dim strObjNm As String 'オブジェクト名称
        Dim strObjKbn As String 'オブジェクト区分
        Dim strImageNm As String 'イメージ名称
        Dim strHanyoArea As String '汎用エリア
        Dim strHanyoArea2 As String '汎用エリア２
        Dim strSResCD As String 'セキュリティリソースコード
        Dim strUpdAuthRangeKbn As String '更新権限範囲区分
        Dim strRefAuthRangeKbn As String '参照権限範囲区分
    End Structure
    Public Structure Menu_Type
        Dim strMenuID As String 'メニューＩＤ
        Dim strMenuNm As String 'メニュー名称
        Dim strMenuTargetKbn As String 'メニュー対象区分
        Dim ListBarMenu() As ListBarMenu_Type
    End Structure

    '==========================
    ' 勤務時間データ用 構造体群
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
        Dim KinmuCD As String '勤務CD
        Dim Tanka As Integer '単価
        Dim TodayOff As Integer '当日休日算定時間
        Dim NextOff As Integer '翌日休日算定時間
        Dim Tonight As Integer '当日夜間算定時間
        Dim NextNight As Integer '翌日夜間算定時間
        Dim FormalTimeFrom As String '正規勤務時間FROM（HHMM）（設定されていない場合は空文字）
        Dim FormalTimeTo As String '正規勤務時間TO（HHMM）（設定されていない場合は空文字）
        Dim JituKinmuTime As String '実勤務時間（HHMM）（設定されていない場合は空文字）
    End Structure
    Public Structure typSanteiTime
        <VBFixedArray(999)> Dim SanteiTime() As KinmuTimeDetail '算定時間取得用 配列 勤務時間Ｍに値が入ってないとき対応

        Public Sub Initialize()
            ReDim SanteiTime(999)
        End Sub
    End Structure
    Public g_udtHistory() As typSanteiTime
    Public g_intAccessLogFlg As Integer
    Public g_intUseNAVIFlg As Integer 'NAVI使用 = "1"

    Public g_ImagePath As String 'イメージパス

    '========================
    'ｶﾚﾝﾀﾞｰの土･日･祝の色
    '========================
    Public g_Sat_ForeColor As Integer
    Public g_Sun_ForeColor As Integer
    Public g_Hol_ForeColor As Integer


    Public g_strTargetStaffMngID As String '対象職員の職員管理番号
    Public g_lngGroupIdx As Integer '選択中のグループインデックス
    Public g_lngListIdx As Integer '選択中のリストインデックス

    '利用パッケージタイプ
    Public Structure UserPackage_Type
        Dim strPackageCD As String 'パッケージコード
        Dim strPackageName As String 'パッケージ名称
        Dim strResourceCD As String 'リソースコード
        Dim strTitle As String 'タイトル
        Dim strObjectName As String 'オブジェクト名
        Dim strObjectKbn As String 'オブジェクト区分
        Dim strSecuResourceCD As String 'セキュリティリソースコード
        Dim strMasterKbn As String 'マスタ区分
        Dim strMasterID As String 'マスタID
        Dim strUpdAuthRangeKbn As String '更新権限範囲区分
        Dim strRefAuthRangeKbn As String '参照権限範囲区分
    End Structure
    Public g_UserPackage() As UserPackage_Type

    Public Const g_strNSC2000HA As String = "NSC2000HA" '初期画面ID

    Public g_strMaxUpdAuthRangeKbn As String '最大更新権限範囲区分
    Public g_strMaxRefAuthRangeKbn As String '最大参照権限範囲区分

    Public Const G_ModeAdd As Integer = 1 '追加
    Public Const G_ModeUpdate As Integer = 2 '変更

    Public g_SearchDate As Integer '検索結果の基準日(検索F削除時ｸﾘｱ)

    Public Const G_strSaiyoRes As String = "NSC2000HA01" '採用リソースコード
    Public Const G_strKinmuDeptRes As String = "NSC2000HA02" '勤務部署リソースコード
    Public Const G_strWardDeptRes As String = "NSC2000HA03" '配属部署リソースコード
    Public Const G_strPostRes As String = "NSC2000HA04" '役職リソースコード
    Public Const G_strJobRes As String = "NSC2000HA05" '職種リソースコード
    Public Const G_strKenmuRes As String = "NSC2000HA06" '兼務リソースコード
    Public Const G_strMenkyoRes As String = "NSC2000HA07" '免許リソースコード
    Public Const G_strShikakuRes As String = "NSC2000HA08" '資格リソースコード
    Public Const G_strIinRes As String = "NSC2000HA09" '委員リソースコード
    Public Const G_strSyokurekiRes As String = "NSC2000HA10" '職歴リソースコード
    Public Const G_strIppanGakurekiRes As String = "NSC2000HA11" '一般学歴リソースコード
    Public Const G_strSenmonGakurekiRes As String = "NSC2000HA12" '専門学歴リソースコード
    Public Const G_strChoukyuRes As String = "NSC2000HA13" '長休リソースコード
    Public Const G_strSankyuRes As String = "NSC2000HA14" '産休リソースコード
    Public Const G_strKyoukaiRes As String = "NSC2000HA15" '協会リソースコード
    Public Const G_strKazokuRes As String = "NSC2000HA16" '家族リソースコード
    Public Const G_strStudyRes As String = "NSC2000HA17" '研修リソースコード
    Public Const G_strMyLadderRes As String = "NSC2000HA18" '自己評価リソースコード
    Public Const G_strOtherLadderRes As String = "NSC2000HA19" '他評価リソースコード
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

    '共通コンポーネントのエントリポイント
    Public Sub Main()
        Const W_SUBNAME As String = "BasNSC0000H Main"

        Try
            Dim w_ClsPassword As New clsPassword 'ﾕｰｻﾞｰ名入力ｵﾌﾞｼﾞｪｸﾄ
            Dim w_RegStr As String
            Dim w_strApStartFlg As String
            Dim w_strHosp As String
            Dim w_RegStrPswDispFlg As String
            Dim w_i As Integer
            Dim w_CommandLine As String
            '二重起動防止
            Dim mutex As System.Threading.Mutex = New System.Threading.Mutex(False, "NSC0000H")

            'DB接続
            Call General.paConnect()

            '起動画面 判定 (0:ﾊﾟｽﾜｰﾄﾞ入力画面, 1:初期ﾒﾆｭｰ画面)
            '    w_strApStartFlg = General.paGetItemValue(General.G_StrMainKey1, General.G_StrSubKey1, "APSTARTFLG", "0")
            w_RegStr = General.G_SYSTEM_WIN7 & "\" & General.G_STRMAINKEY1
            w_strHosp = General.paGetSetting(w_RegStr, "Current", "HOSPITALCD", "")

            If w_strHosp = "" Then
                w_strHosp = "01"
            End If

            w_strApStartFlg = General.paGetItemValue(General.G_STRMAINKEY1, General.G_STRSUBKEY1, "APSTARTFLG", "0", w_strHosp)

            w_RegStrPswDispFlg = General.paGetSetting(General.G_SYSTEM_WIN7, General.G_STRMAINKEY1, "PSWDISPFLG", "0")

            'ミューテックスの所有権を要求する
            If mutex.WaitOne(0, False) = False Then
                'すでに起動していると判断して終了
                End
            End If

            Try
                'DBｱｸｾｽの種別を取得する
                General.g_InstallType = Integer.Parse(General.paGetIniSetting(General.G_STRININAME, General.G_STRSECTION1, "InstallType", Convert.ToString(General.BasGeneral.gInstall_Enum.AccessType_PassThrough)))

                '===========================================
                '部品オブジェクト生成
                '===========================================
                'セキュリティマスタ部品
                General.g_objSecurity = New NsAid_NSC0000C.clsGetSecurity
                '職員取得部品
                General.g_objGetData = New NsAid_NSC0010C.clsStaffData
                'カレンダー部品
                General.g_objSelectDate = New NsAid_NSC0030C.clsNusDate
                '職員ポップアップ
                General.g_objSelectStaff = New NsAid_NSC0040C.clsStaffPopUp
                'マスタ取得部品
                General.g_objGetMaster = New NsAid_NSC0050C.clsGetMaster
                '異動情報取得部品
                General.g_objIdoData = New NsAid_NSC0060C.clsStaffIdo
                '勤務部署ポップアップ 部品
                General.g_objSelectDept = New NsAid_NSC0070C.clsDeptPopUp
                '承認関連部品
                General.g_objSyouninData = New NsAid_NSA0000C.clsAppliApprove
                '時間外取得部品
                General.g_objComCyokin = New NsAid_NSW0000C.clsGetOverData
                '日当直グループ取得部品
                General.g_objDutyGroup = New NsAid_NSD0000C.clsGetDutyGroup
                '時間外取得部品（労基法対応）
                General.g_objWorkBaseInfo = New NsAid_NSW0300C.clsGetOverData

                'システム停止中かどうか判断
                If General.CheckSystemStop() = False Then
                    'システム停止中ならDB接続を切断してアプリケーションを終了させる
                    Call General.paDisConnect()
                    '部品オブジェクト解放
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

                    '--- Ap終了 ---
                    End
                End If

                'レジストリパス
                w_RegStr = General.G_SYSTEM_WIN7 & "\" & General.G_STRMAINKEY1

                '起動画面 判定 (0:ﾊﾟｽﾜｰﾄﾞ入力画面, 1:初期ﾒﾆｭｰ画面)
                '    If w_strApStartFlg = "1" Then
                If w_strApStartFlg = "1" Or w_RegStrPswDispFlg = "1" Then
                    'ﾊﾟｽﾜｰﾄﾞ画面を表示せずに初期画面表示

                    'ランチャ機能追加
                    If Command() <> "" Then
                        w_CommandLine = Command()
                        '第1引数(利用者ID)
                        For w_i = 1 To Len(w_CommandLine)
                            If Mid(w_CommandLine, w_i, 1) = " " Then
                                General.g_LanchUser = Mid(w_CommandLine, 1, w_i - 1)
                                w_CommandLine = Mid(w_CommandLine, w_i + 1, Len(w_CommandLine) - w_i)
                                Exit For
                            End If
                        Next w_i

                        '第2引数(ﾊﾟｽﾜｰﾄﾞ)
                        General.g_LanchPassword = Mid(w_CommandLine, 1, Len(w_CommandLine))

                        'ランチャ起動ON
                        General.g_LuncherFlg = True

                        'ﾊﾟｽﾜｰﾄﾞ画面の表示
                        w_ClsPassword.mShowWindow()

                        If General.g_ErrCheck = False Then
                            Call General.paDisConnect()
                            End
                        End If
                    End If

                    'ｸﾗｽﾌﾟﾛﾊﾟﾃｨに必要なﾃﾞｰﾀを設定
                    '利用者ID
                    General.g_strUserID = General.paGetSetting(w_RegStr, "Current", "USERID", "")
                    '利用者名
                    General.g_strUserName = General.paGetSetting(w_RegStr, "Current", "USERNAME", "")
                    '利用者グループコード
                    General.g_strUserGroupCD = General.paGetSetting(w_RegStr, "Current", "USERGROUPCD", "")
                    '利用者職員管理番号
                    General.g_strUserMngID = General.paGetSetting(w_RegStr, "Current", "USERMNGID", "")
                    '利用者所属勤務部署CD
                    General.g_strUserKinmuDeptCD = General.paGetSetting(w_RegStr, "Current", "USERKINMUDEPTCD", "")
                    '利用者所属勤務部署名称
                    General.g_strUserKinmuDeptNm = General.paGetSetting(w_RegStr, "Current", "USERKINMUDEPTNM", "")
                    '施設CD
                    General.g_strHospitalCD = General.paGetSetting(w_RegStr, "Current", "HOSPITALCD", "")
                    '施設名称
                    General.g_strHospitalNm = General.paGetSetting(w_RegStr, "Current", "HOSPITALNM", "")
                    '選択勤務部署CD
                    General.g_strSelKinmuDeptCD = General.paGetSetting(w_RegStr, "Current", "KINMUDEPTCD", "")
                    '選択勤務部署名称
                    General.g_strSelKinmuDeptNm = General.paGetSetting(w_RegStr, "Current", "KINMUDEPTNM", "")

                    'セキュリティマスタ部品
                    With General.g_objSecurity
                        .pHospitalCD = General.g_strHospitalCD '施設コード
                        .pUserID = General.g_strUserID '利用者コード
                        .pUserStaffMngID = General.g_strUserMngID '利用者職員管理番号
                        .pGroupCD = General.g_strUserGroupCD '利用者グループコード
                        .pUserKinmuDeptCD = General.g_strUserKinmuDeptCD '利用者所属部署コード
                        .pGetMasterObj = General.g_objGetMaster 'マスタ取得部品

                        '所属および兼務している勤務部署コードの勤務部署マスタ情報を取得する
                        If .mGetUserKinmuDeptInfo(General.paGetDateStringFromDate(Now, General.G_DATE_ENUM.yyyyMMdd)) = False Then

                        End If
                    End With

                    '承認部品(NSA0000C)
                    General.g_objSyouninData.pHospitalCD = General.g_strHospitalCD '施設コード
                    General.g_objSyouninData.pUserID = General.g_strUserID '利用者コード
                    General.g_objSyouninData.pUserStaffMngID = General.g_strUserMngID '利用者職員管理番号
                    General.g_objSyouninData.pGroupCD = General.g_strUserGroupCD '利用者グループコード
                    General.g_objSyouninData.pWebFlg = False 'WEBフラグ(C/S：False　WEB:True)
                    General.g_objSyouninData.pInstallType = General.g_InstallType 'インストールタイプ
                    General.g_objSyouninData.pSecurityObj = General.g_objSecurity 'セキュリティ部品
                    General.g_objSyouninData.pGetDataObj = General.g_objGetData
                    General.g_objSyouninData.pGetMasterObj = General.g_objGetMaster


                    '日当直部品(NSD0000C)
                    General.g_objDutyGroup.pHospitalCD = General.g_strHospitalCD '施設コード
                    General.g_objDutyGroup.pUserID = General.g_strUserID '利用者コード
                    General.g_objDutyGroup.pUserStaffMngID = General.g_strUserMngID '利用者職員管理番号
                    General.g_objDutyGroup.pGroupCD = General.g_strUserGroupCD '利用者グループコード


                    'リストバーメニュー取得
                    If fncListBarMenu() = False Then
                        '終了状態(異常) 設定
                        w_ClsPassword.pEndStatus(False) = False
                    Else
                        'ﾊﾟｽﾜｰﾄﾞ画面終了状態をTrueに
                        w_ClsPassword.pEndStatus(True) = True
                    End If

                Else
                    'ﾊﾟｽﾜｰﾄﾞ画面の表示
                    w_ClsPassword.mShowWindow()
                End If

                '職員取得部品(NSC0010C)
                General.g_objGetData.p病院CD = General.g_strHospitalCD

                'マスタ取得部品(NSC0050C)
                General.g_objGetMaster.pHospitalCD = General.g_strHospitalCD

                '異動情報取得部品(NSC0060C)
                General.g_objIdoData.pHospitalCD = General.g_strHospitalCD

                '勤務部署ポップアップ 部品(NSC0070C)
                General.g_objSelectDept.pHospitalCD = General.g_strHospitalCD
                General.g_objSelectDept.pGetMasterObj = General.g_objGetMaster

                '職員ポップアップ部品(NSC0040C)
                General.g_objSelectStaff.pHospitalCD = General.g_strHospitalCD
                General.g_objSelectStaff.pGetMasterObj = General.g_objGetMaster
                General.g_objSelectStaff.pSelectDeptObj = General.g_objSelectDept
                General.g_objSelectStaff.pGetDataObj = General.g_objGetData

                'カレンダー部品(NSC0030C)
                With General.g_objSelectDate
                    '初期設定を行う
                    .LetMaxDate = General.G_DEFAULT_MAX_DATE '表示可能最大日付(YYYYMMDD・省略化)
                    .LetMinDate = General.G_DEFAULT_MIN_DATE '表示可能最小日付(YYYYMMDD・省略化)
                    .letdefaultdate = General.paGetDateIntegerFromDate(Now) '初期表示日付(YYYYMMDD・省略化)
                    .LetHospitalCode = General.g_strHospitalCD '病院CDを設定
                    .LetNurseAidFLG(True) = vbNullString 'NurseAIDのNSHOLIDAYMを参照するかどうかの設定
                    .LetHolidayDataType = False '祝日をファイルから読み込むかどうか
                End With

                '時間外取得部品(NSW0000C)
                General.g_objComCyokin.p病院CD = General.g_strHospitalCD
                General.g_objComCyokin.pGetDataObj = General.g_objGetData

                '時間外取得部品（労基法対応）(NSW0300C)
                General.g_objWorkBaseInfo.p病院CD = General.g_strHospitalCD
                General.g_objWorkBaseInfo.pGetDataObj = General.g_objGetData
                General.g_objWorkBaseInfo.pGetCyokinObj = General.g_objComCyokin

                'ﾊﾟｽﾜｰﾄﾞ画面の終了状態を取得
                If w_ClsPassword.pEndStatus = True Then
                    'Trueならば初期画面起動
                    g_ClsMain.mShowMainWindow()
                Else

                    Call General.paDisConnect()
                End If

                If g_Logoff_Flg Then
                    g_Logoff_Flg = False
                    Call Main()
                End If
            Finally
                'ミューテックスを解放する
                mutex.ReleaseMutex()
            End Try

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    'リストバーメニュー 取得
    Public Function fncListBarMenu() As Boolean
        Const W_SUBNAME As String = "BasMain fncListBarMenu"

        Try
            Dim w_lngMenuCnt As Integer
            Dim w_lngLoop As Integer
            Dim w_lngLoop2 As Integer
            Dim w_strResCD As String
            Dim w_strPreResCD As String 'リソースコード退避用
            Dim w_lngGroupIdx As Integer
            Dim w_lngListIdx As Integer
            Dim w_lngDefListIdx As Integer
            Dim w_lngResorceCnt As Integer

            '初期化
            'ReDim g_MenuM(0)
            ReDim g_MenuM(0)
            ReDim g_MenuM(0).ListBarMenu(0)
            w_strPreResCD = ""

            g_lngGroupIdx = 0
            g_lngListIdx = 0

            'セキュリティ部品　リストバーメニュー取得
            With General.g_objSecurity
                If .mGetListBarMenu = False Then
                    fncListBarMenu = False
                Else
                    '使用可能なメニューＩＤの数
                    w_lngMenuCnt = .fLB_MenuCount
                    'デフォルトで表示するメニューのINDEX
                    g_lngGroupIdx = .fLB_MenuDefIdx

                    w_lngDefListIdx = .fLB_MenuDataDefIdx '注意：同リソースコードに対してパッケージコード違いで複数ある場合があるため、リストインデックスもそのままの数字では使用できない場合がある

                    For w_lngLoop = 1 To w_lngMenuCnt

                        .mLB_MenuIdx = w_lngLoop

                        'リストメニュー件数取得
                        w_lngResorceCnt = .fLB_ResourceCount

                        'リストメニューが１件もない場合は配列作成しない
                        If w_lngResorceCnt > 0 Then

                            w_lngGroupIdx = UBound(g_MenuM) + 1
                            ReDim Preserve g_MenuM(w_lngGroupIdx)
                            'リストメニュー配列初期化
                            ReDim g_MenuM(w_lngGroupIdx).ListBarMenu(0)

                            '●メニューID
                            g_MenuM(w_lngGroupIdx).strMenuID = .fLB_MenuID
                            '●メニュー名称
                            g_MenuM(w_lngGroupIdx).strMenuNm = .fLB_MenuNm
                            '●メニュー対象区分
                            g_MenuM(w_lngGroupIdx).strMenuTargetKbn = .fLB_MenuTargetKbn

                            For w_lngLoop2 = 1 To w_lngResorceCnt
                                .mLB_ResourceIdx = w_lngLoop2

                                '●リソースコード
                                w_strResCD = .fLB_ResourceCD

                                If w_strPreResCD <> .fLB_ResourceCD Then
                                    w_lngListIdx = UBound(g_MenuM(w_lngGroupIdx).ListBarMenu) + 1
                                    ReDim Preserve g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx)

                                    '初期値リストインデックス
                                    If w_lngLoop = g_lngGroupIdx And w_lngLoop2 = w_lngDefListIdx Then
                                        g_lngListIdx = w_lngListIdx
                                    End If

                                    '●リソースコード
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strResCD = w_strResCD
                                    '●タイトル
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strTitle = .fLB_Title
                                    '●オブジェクト名称
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strObjNm = .fLB_ObjectNm
                                    '●オブジェクト区分
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strObjKbn = .fLB_ObjectKbn
                                    '●セキュリティリソースコード
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strSResCD = .fLB_SecuResourceCD
                                    '●更新権限範囲区分
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strUpdAuthRangeKbn = .fLB_UpdAuthRangeKbn
                                    '●参照権限範囲区分
                                    g_MenuM(w_lngGroupIdx).ListBarMenu(w_lngListIdx).strRefAuthRangeKbn = .fLB_RefAuthRangeKbn
                                End If

                                '退避
                                w_strPreResCD = w_strResCD

                            Next w_lngLoop2
                        End If
                    Next w_lngLoop

                    'デフォルトメニューに権限がない場合の対応
                    'デフォルトメニューがない場合、強制的に本人情報を選択
                    If g_lngGroupIdx = 0 And g_lngListIdx = 0 Then
                        g_lngGroupIdx = 1
                        g_lngListIdx = 1
                    End If

                End If
            End With

            '正常終了
            fncListBarMenu = True

        Catch ex As Exception
            Call General.paTrpMsg(Convert.ToString(Err.Number), W_SUBNAME)
        End Try
    End Function


    '=======================================================================
    '  起動プロセスのチェック
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




    '選択部署コードを初期値とするが、
    '対象日時点の勤務部署コードに変換する
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

                .pHospitalCD = General.g_strHospitalCD '施設コード
                .pStaffMngID = p_strMngID '職員管理番号
                .pDateFlg = 0 '日付区分(単一日)
                .pDateFrom = p_lngDate '開始年月日
                .pDateTo = 0 '終了年月日
                .pSortFlg = 1 'ソート順(降順)

                If .mGetKinmuDeptIdo() = False Then

                    '初期値のまま
                    p_strDeptCD = w_strDefDeptCD
                    p_strDeptName = w_strDefDeptName
                    Exit Function
                Else

                    '単一日指定なので、２件以上は取得されない
                    If .fKI_KinmuDeptCount < 1 Then

                        '初期値のまま
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