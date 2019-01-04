Imports System.io

Public Class frmNSC0000HB

    Public Sub NSC0000HB_Load()
        DataLoad()

        Dim w_ImagePath As String
        w_ImagePath = General.paGetIniSetting(General.G_STRININAME, General.G_STRSECTION1, "ImagePath", My.Application.Info.DirectoryPath & "\" & "image\")

        'フォームアイコン 設定
        Me.BackgroundImage = System.Drawing.Image.FromFile(w_ImagePath & "BackGround.bmp")
        Me.Icon = New System.Drawing.Icon(w_ImagePath & "System.ico")

        '正常終了
        m_ErrorFlg = True

        If General.g_LuncherFlg <> False Then
            txtPassword.Text = General.g_LanchPassword
            txtUser.Text = General.g_LanchUser
            Call cmdOK_Click(cmdOK, New System.EventArgs())
        End If
    End Sub
    '----------------------------------------------------------------------
    '       ﾌﾟﾗｲﾍﾞｰﾄ変数
    '----------------------------------------------------------------------
    Private m_ErrorFlg As Boolean 'Form_Loadｲﾍﾞﾝﾄ ｴﾗｰﾌﾗｸﾞ(正常:True 異常:False)
    Private m_EndStatus As Boolean '終了状態(OK:True,ｷｬﾝｾﾙ:False)

    Private m_LastUpdDate As Long '最終更新日付

    'ログイン
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Const W_SUBNAME As String = "frmNSC0000HB cmdOK_Click"

        Try
            Dim w_Sql As String
            Dim w_SysDate As Long
            Dim w_HospitalCD As String
            Dim w_UserCD As String

            '病院CD
            w_HospitalCD = Trim(General.paLeft(cboHospital.Text, 2))
            '利用者CD
            w_UserCD = txtUser.Text
            'エラーフラグを元に戻す
            General.g_ErrorFlg = False

            'ﾏｳｽﾎﾟｲﾝﾀ "砂時計"に変更
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'OKﾎﾞﾀﾝ 押下
            If RunOK() = False Then
                'ERRORの場合
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Exit Sub
            Else
                m_EndStatus = True
                Me.Close()
            End If


            'ｼｽﾃﾑ利用権限(計画/超勤)ﾁｪｯｸ
            If Not AccountChk() Then
                '計画/超勤 ともに利用権がない場合
                '        Me.MousePointer = vbDefault
                '        Exit Sub
            End If

            '-------------------------------------------------
            '利用者マスタのログイン日付を更新(排他制御なし)
            '-------------------------------------------------
            w_SysDate = Long.Parse(Format(Now, "yyyyMMddHHmmss"))

            Call General.paBeginTrans()

            w_Sql = "UPDATE NS_USER_M SET"
            w_Sql = w_Sql & " LOGINTIMEDATE = " & w_SysDate
            w_Sql = w_Sql & " WHERE HOSPITALCD = '" & w_HospitalCD & "'"
            w_Sql = w_Sql & " AND USERID = '" & w_UserCD & "'"
            Call General.paDBExecute(w_Sql)

            'コミット
            Call General.paCommit()


            'セキュリティマスタ部品
            With General.g_objSecurity
                .pHospitalCD = General.g_strHospitalCD '施設コード
                .pUserID = General.g_strUserID '利用者コード
                .pUserStaffMngID = General.g_strUserMngID '利用者職員管理番号
                .pGroupCD = General.g_strUserGroupCD '利用者グループコード
                .pUserKinmuDeptCD = General.g_strUserKinmuDeptCD '利用者所属部署コード
                .pGetMasterObj = General.g_objGetMaster 'マスタ取得部品

                '所属および兼務している勤務部署コードの勤務部署マスタ情報を取得する
                If .mGetUserKinmuDeptInfo(General.paGetDateIntegerFromDate(Now, General.G_DATE_ENUM.yyyyMMdd)) = False Then

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
                m_EndStatus = False
            Else
                '終了状態(正常) 設定
                m_EndStatus = True
            End If

            If General.g_LuncherFlg <> True Then
                'ﾒﾓﾘ ｱﾝﾛｰﾄﾞ
                Me.Close()
            End If

        Catch ex As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    '入力ﾁｪｯｸ および ﾚｼﾞｽﾄﾘ設定
    Private Function RunOK() As Boolean
        Const W_SUBNAME As String = "frmNSC0000HB RunOK"

        Try
            Dim w_UserCD As String
            Dim w_Password As String
            Dim w_HospitalCD As String
            Dim w_RegStr As String
            Dim w_ErrMsgNo As Integer

            Dim w_strMsg() As String

            '異常値ｾｯﾄ
            RunOK = False

            'ﾕｰｻﾞｰ名/ﾊﾟｽﾜｰﾄﾞ/施設ｺｰﾄﾞ 取得
            w_UserCD = txtUser.Text
            w_Password = txtPassword.Text
            w_HospitalCD = Trim(General.paLeft(cboHospital.Text, 2))

            '-------------------------------------------------------
            '   ﾕｰｻﾞｰID(職員管理番号),ﾊﾟｽﾜｰﾄﾞ検索
            '-------------------------------------------------------
            If FindUserCD(w_HospitalCD, w_UserCD, w_Password, w_ErrMsgNo) = False Then
                'ERROR
                Select Case w_ErrMsgNo
                    Case 1
                        'ﾕｰｻﾞｰID 存在しない
                        ReDim w_strMsg(1)
                        w_strMsg(1) = "入力されたログインＩＤ"
                        Call General.paMsgDsp("NS0008", w_strMsg)
                        Call General.paSetFocus(txtUser)
                    Case 2
                        'ﾊﾟｽﾜｰﾄﾞ 異なる
                        ReDim w_strMsg(1)
                        w_strMsg(1) = "パスワード"
                        Call General.paMsgDsp("NS0003", w_strMsg)
                        Call General.paSetFocus(txtPassword)
                    Case Else
                End Select
                Exit Function
            End If

            '有効終了日を越えていた場合
            If fncGetEffendDay(w_HospitalCD, w_UserCD) < General.paGetDateIntegerFromDate(Now) Then
                ReDim w_strMsg(3)
                w_strMsg(1) = "ユーザー"
                w_strMsg(2) = "使用期間"
                w_strMsg(3) = "有効日"
                Call General.paMsgDsp("NS0149", w_strMsg)
                Call General.paSetFocus(txtUser)
                Exit Function
            End If

            'ユーザーID/施設CD/施設名称 設定
            General.g_strUserID = w_UserCD
            General.g_strHospitalCD = w_HospitalCD
            General.g_strHospitalNm = Trim(Mid(cboHospital.Text, 3))

            w_RegStr = General.G_SYSTEM_WIN7 & "\" & General.G_STRMAINKEY1
            '選択勤務部署CD
            General.g_strSelKinmuDeptCD = General.paGetSetting(w_RegStr, "Current", "KINMUDEPTCD", "")
            '選択勤務部署名称
            General.g_strSelKinmuDeptNm = General.paGetSetting(w_RegStr, "Current", "KINMUDEPTNM", "")
            General.g_objGetData.p病院CD = General.g_strHospitalCD

            '勤務部署初期化
            General.g_strUserKinmuDeptCD = ""
            General.g_strUserKinmuDeptNm = ""

            '利用者の職員管理番号と、所属部署の取得に変更
            Call GetUserKangoT(w_HospitalCD, w_UserCD)

            '----- ﾚｼﾞｽﾄﾘ設定 ------------------
            w_RegStr = General.G_SYSTEM_WIN7 & "\" & General.G_STRMAINKEY1
            '●利用者ID
            Call General.paSaveSetting(w_RegStr, "Current", "USERID", General.g_strUserID)
            '●利用者名
            Call General.paSaveSetting(w_RegStr, "Current", "USERNAME", General.g_strUserName)
            '●利用者グループコード
            Call General.paSaveSetting(w_RegStr, "Current", "USERGROUPCD", General.g_strUserGroupCD)
            '●利用者職員管理番号
            Call General.paSaveSetting(w_RegStr, "Current", "USERMNGID", General.g_strUserMngID)
            '●利用者所属勤務部署CD
            Call General.paSaveSetting(w_RegStr, "Current", "USERKINMUDEPTCD", General.g_strUserKinmuDeptCD)
            '●利用者所属勤務部署名称
            Call General.paSaveSetting(w_RegStr, "Current", "USERKINMUDEPTNM", General.g_strUserKinmuDeptNm)
            '●施設CD
            Call General.paSaveSetting(w_RegStr, "Current", "HOSPITALCD", General.g_strHospitalCD)
            '●施設名称
            Call General.paSaveSetting(w_RegStr, "Current", "HOSPITALNM", General.g_strHospitalNm)
            '●施設ｺｰﾄﾞ(ListIndex)
            Call General.paSaveSetting(w_RegStr, "Current", "HOSPITALINDEX", Format(cboHospital.SelectedIndex))

            '正常終了
            RunOK = True

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    'ﾕｰｻﾞｰ検索
    Private Function FindUserCD(ByVal p_HospitalCD As String, ByVal p_UserCD As String, ByVal p_Password As String, ByRef p_ErrMsgNo As Integer) As Integer
        Const W_SUBNAME As String = "frmNSC0000HB FindUserCD"

        Try
            Dim w_Index As Integer
            Dim w_Sql As String = String.Empty
            Dim w_Password As String
            Dim w_Rs As ADODB.Recordset
            Dim w_Password_F As ADODB.Field
            Dim w_利用者Name_F As ADODB.Field
            Dim w_GroupCD_F As ADODB.Field

            'ﾒｯｾｰｼﾞｺｰﾄﾞ定数
            Const w_Msg_User As Integer = 1 'ﾕｰｻﾞｰｴﾗｰ
            Const w_Msg_PassWord As Integer = 2 'Passwordｴﾗｰ


            '異常値ｾｯﾄ
            FindUserCD = False

            'ﾕｰｻﾞｰID入力ﾁｪｯｸ
            If Trim(p_UserCD) = "" Then
                'Error ﾕｰｻﾞｰID存在しない
                p_ErrMsgNo = w_Msg_User
                '異常終了
                Exit Function
            End If

            '-- ﾕｰｻﾞ情報取得 ----------------
            w_Sql = w_Sql & "SELECT "
            w_Sql = w_Sql & "NAME, "
            w_Sql = w_Sql & "PASSWD, "
            w_Sql = w_Sql & "GROUPCD "
            w_Sql = w_Sql & "FROM NS_USER_M "
            w_Sql = w_Sql & "WHERE NS_USER_M.UserID = '" & p_UserCD & "' "
            w_Sql = w_Sql & "  AND NS_USER_M.HospitalCD = '" & p_HospitalCD & "' "

            'RecordSet ｵﾌﾞｼﾞｪｸﾄの作成(参照のみ)
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            '0件ﾃﾞｰﾀﾁｪｯｸ
            If w_Rs.RecordCount = 0 Then
                'Error ﾕｰｻﾞｰID存在しない
                p_ErrMsgNo = w_Msg_User

                'ｵﾌﾞｼﾞｪｸﾄ 削除
                w_Rs.Close()
                Exit Function
            Else
                '職員情報ﾏｽﾀにﾕｰｻﾞが存在した場合

                'ﾌｨｰﾙﾄﾞ定義
                w_Password_F = w_Rs.Fields("PASSWD")
                w_利用者Name_F = w_Rs.Fields("NAME")
                w_GroupCD_F = w_Rs.Fields("GROUPCD")

                '大文字/小文字を区別なく判断する
                w_Password = General.paGetDbFieldVal(w_Password_F, "")

                If General.g_LuncherFlg = False Then
                    If StrComp(p_Password, w_Password, 0) <> 0 Then
                        '異なる場合
                        'Error ﾕｰｻﾞｰID存在しない
                        p_ErrMsgNo = w_Msg_PassWord

                        'ｵﾌﾞｼﾞｪｸﾄ 削除
                        w_Rs.Close()
                        Exit Function
                    End If
                End If
                '================================================================================
            End If

            'ﾕｰｻﾞｰ名 取得
            General.g_strUserName = General.paGetDbFieldVal(w_利用者Name_F, "")
            '利用者グループコード
            General.g_strUserGroupCD = General.paGetDbFieldVal(w_GroupCD_F, "")

            'ｵﾌﾞｼﾞｪｸﾄ解放
            w_Rs.Close()


            '-- 共通 ﾃﾞｰﾀ設定 ------------------
            w_Index = cboHospital.SelectedIndex + 1

            '正常終了
            FindUserCD = True

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    '===========================================================================
    '   操作者看護単位情報取得
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

            'システム日付取得
            w_NowDate = General.paGetDateIntegerFromDate(Now)

            '職員管理番号の取得
            w_strSql = ""
            w_strSql = w_strSql & " SELECT STAFFMNGID "
            w_strSql = w_strSql & " FROM   NS_USER_M "
            w_strSql = w_strSql & " WHERE  NS_USER_M.UserID = '" & p_UserID & "' "
            w_strSql = w_strSql & "  AND   NS_USER_M.HospitalCD = '" & p_HosCD & "' "

            w_Rs = General.paDBRecordSetOpen(w_strSql)

            '●利用者の職員管理番号

            '0件ﾃﾞｰﾀﾁｪｯｸ
            If w_Rs.RecordCount = 0 Then

                General.g_strUserMngID = ""

                'ｵﾌﾞｼﾞｪｸﾄ 削除
                w_Rs.Close()
                Exit Sub
            Else
                '職員情報ﾏｽﾀにﾕｰｻﾞが存在した場合

                'ﾌｨｰﾙﾄﾞ定義
                w_StaffMngID_F = w_Rs.Fields("STAFFMNGID")
                '暫定対応
                General.g_strUserMngID = Trim(w_StaffMngID_F.Value & "")

            End If

            '勤務地異動情報Ｆから取得する
            With General.g_objGetData
                .p病院CD = General.g_strHospitalCD
                .p職員番号変換 = 0 'すべての情報
                '        .p職員区分 = 1
                '        .p職員番号 = p_UserID
                .p職員区分 = 0
                .p職員番号 = General.g_strUserMngID
                '================================================================
                .p日付区分 = 0
                .p開始年月日 = w_NowDate
                .p履歴ソートFLG = 0 '昇順
                .pシステム区分 = 1 '職員歴必要なし
                If .mStaffInit = False Then
                    'ﾃﾞｰﾀなし
                    General.g_strUserKinmuDeptCD = ""
                    General.g_strUserKinmuDeptNm = ""
                Else
                    'データがある場合（基本的に１件に絞られるはず）
                    w_lngKensu = General.g_objGetData.f勤務地異動件数
                    For w_lngLoop = 1 To w_lngKensu
                        .p勤務地異動索引 = w_lngLoop
                        w_Code = .f看護単位CD1
                        w_Name = .f看護単位名称1
                    Next w_lngLoop

                    'データ取得
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

            'RecordSet ｵﾌﾞｼﾞｪｸﾄの作成(参照のみ)
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            '0件ﾃﾞｰﾀﾁｪｯｸ
            If w_Rs.RecordCount = 0 Then

                'ｵﾌﾞｼﾞｪｸﾄ 削除
                w_Rs.Close()
                Exit Function
            Else

                'ﾌｨｰﾙﾄﾞ定義
                w_EffendDay_F = w_Rs.Fields("EFFENDDAY")

            End If

            '正常終了
            fncGetEffendDay = w_EffendDay_F.Value

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Const W_SUBNAME As String = "frmNSC0000HB cmdCancel_Click"

        Try
            '終了状態 設定
            m_EndStatus = False

            'ﾌｫｰﾑﾒﾓﾘ解放
            Me.Close()

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    'NSCOMMONINFOMの施設情報を取得
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

            'SELECT文 編集
            w_Sql = "SELECT * FROM NS_COMMONINFO_M "
            w_Sql = w_Sql & "ORDER BY HOSPITALCD "
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            '0件ﾃﾞｰﾀﾁｪｯｸ
            If w_Rs.RecordCount > 0 Then

                '*** With ｽﾃｰﾄﾒﾝﾄ開始 ***
                With w_Rs

                    'ﾃﾞｰﾀｶｳﾝﾄ
                    .MoveLast()
                    w_DataCnt = .RecordCount
                    .MoveFirst()

                    'ﾌｨｰﾙﾄﾞｵﾌﾞｼﾞｪｸﾄ 生成
                    w_HOSPITALCD_F = .Fields("HOSPITALCD")
                    w_Name_F = .Fields("NAME")
                    w_SYSFROMDAY_F = .Fields("SYSFROMDAY")
                    w_SYSFROMTERM_F = .Fields("SYSFROMTERM")
                    w_PLANUNIT_F = .Fields("PLANUNIT")
                    w_DISPPERIOD_F = .Fields("DISPPERIOD")
                    w_REGISTFIRSTTIMEDATE_F = .Fields("REGISTFIRSTTIMEDATE")
                    w_LASTUPDTIMEDATE_F = .Fields("LASTUPDTIMEDATE")
                    w_REGISTRANTID_F = .Fields("REGISTRANTID")

                    '施設CD等 退避配列 再定義
                    ReDim g_Kyotuinf(w_DataCnt)

                    'ﾃﾞｰﾀ件数 繰り返し
                    For w_Int = 1 To w_DataCnt

                        '配列に格納
                        g_Kyotuinf(w_Int).ByoinCD = w_HOSPITALCD_F.Value
                        g_Kyotuinf(w_Int).Name = General.paGetDbFieldVal(w_Name_F, "")
                        g_Kyotuinf(w_Int).Sysdate = Integer.Parse(General.paGetDbFieldVal(w_SYSFROMDAY_F, 0))
                        g_Kyotuinf(w_Int).Systerm = Integer.Parse(General.paGetDbFieldVal(w_SYSFROMTERM_F, 0))
                        g_Kyotuinf(w_Int).Tani = General.paGetDbFieldVal(w_PLANUNIT_F, "")
                        g_Kyotuinf(w_Int).Hyoji = General.paGetDbFieldVal(w_DISPPERIOD_F, "")
                        g_Kyotuinf(w_Int).Fdate = Long.Parse(General.paGetDbFieldVal(w_REGISTFIRSTTIMEDATE_F, 0))
                        g_Kyotuinf(w_Int).Ldate = Long.Parse(General.paGetDbFieldVal(w_LASTUPDTIMEDATE_F, 0))
                        g_Kyotuinf(w_Int).UserID = General.paGetDbFieldVal(w_REGISTRANTID_F, "")

                        'ﾘｽﾄ表示文字列 編集
                        w_Item = General.paLeft(g_Kyotuinf(w_Int).ByoinCD & Space(2), 2) & Space(1) & g_Kyotuinf(w_Int).Name

                        'ｱｲﾃﾑ追加
                        cboHospital.Items.Add(w_Item)

                        '次ﾚｺｰﾄﾞへ移動
                        .MoveNext()

                    Next w_Int

                    'ドロップダウンの一行目を選択
                    cboHospital.SelectedIndex = 0

                    '正常終了
                    DataLoad = True
                    '*** With ｽﾃｰﾄﾒﾝﾄ終了 ***
                End With
            Else
                '0件の場合
                '配列の初期化
                ReDim g_Kyotuinf(0)

                'ｴﾗｰﾒｯｾｰｼﾞ表示
                ReDim w_strMsg(1)
                w_strMsg(1) = "施設情報"
                Call General.paMsgDsp("NS0032", w_strMsg)
                '異常終了
                DataLoad = False
            End If

            'ｵﾌﾞｼﾞｪｸﾄ 削除
            w_Rs.Close()

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    'ﾕｰｻﾞｰのｼｽﾃﾑ利用権のﾁｪｯｸ
    '       勤務管理ｼｽﾃﾑの利用権がない場合(False)
    Private Function AccountChk() As Boolean
        Const W_SUBNAME As String = "frmNSC0000HB AccountChk"

        Try
            Dim w_UserCD As String
            Dim w_HospitalCD As String

            '利用者ID 取得
            w_UserCD = txtUser.Text
            '施設ｺｰﾄﾞ 取得
            w_HospitalCD = Trim(General.paLeft(cboHospital.Text, 2))

            '配列の確保(権限確認用構造体(General.Basに定義))
            Dim w_ACC(2) As General.Authority_Type
            w_ACC(0).ResID = ""
            w_ACC(1).ResID = "K0001" '勤務計画の利用権
            w_ACC(2).ResID = "J0001" '超過勤務管理の利用権

            '配列の解放
            System.Array.Clear(w_ACC, 0, w_ACC.Length)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    'ﾕｰｻﾞｰ名入力画面 終了状態ﾌﾗｸﾞ 取得
    Public ReadOnly Property pEndStatus() As Object
        Get
            pEndStatus = m_EndStatus
        End Get
    End Property
    'フォームロード 終了状態ﾌﾗｸﾞ 取得
    Public ReadOnly Property pLoadStatus() As Object
        Get
            pLoadStatus = m_ErrorFlg
        End Get
    End Property

    Public Sub subFormUnload()
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown

        '[ENTER]対応
        If eventArgs.KeyCode = Keys.Enter Then
            Call cmdOK_Click(cmdOK, New System.EventArgs())
        End If

    End Sub


    Private Sub txtUser_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtUser.KeyDown

        '[ENTER]対応
        If eventArgs.KeyCode = Keys.Enter Then
            Call General.paSetFocus(txtPassword)
        End If

    End Sub

    'パスワード変更画面を表示
    Private Sub cmdPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPassword.Click
        Const W_SUBNAME As String = "frmNSC0000HB cmdPassword_Click"

        Try
            Dim w_UserID As String 'ﾕｰｻﾞｰID
            Dim w_Password As String = String.Empty 'ﾊﾟｽﾜｰﾄﾞ
            Dim w_HospitalCD As String '施設ｺｰﾄﾞ
            Dim w_strMsg() As String

            '入力情報 取得
            w_UserID = txtUser.Text

            'ユーザID入力されているか？
            If Len(w_UserID) = 0 Then
                '未入力の場合
                'ﾕｰｻﾞｰID 存在しない
                ReDim w_strMsg(1)
                w_strMsg(1) = "入力されたログインＩＤ"
                Call General.paMsgDsp("NS0008", w_strMsg)
                Call General.paSetFocus(txtUser)
                Exit Sub
            End If

            '施設ｺｰﾄﾞ/名称
            w_HospitalCD = Trim(General.paLeft(cboHospital.Text, 2))

            'ユーザID存在ﾁｪｯｸ
            If UserChk(w_HospitalCD, w_UserID, w_Password) = False Then
                'ﾕｰｻﾞｰID 存在しない
                ReDim w_strMsg(1)
                w_strMsg(1) = "入力されたログインＩＤ"
                Call General.paMsgDsp("NS0008", w_strMsg)
                Call General.paSetFocus(txtUser)
                Exit Sub
            End If

            'ﾊﾟｽﾜｰﾄﾞ変更
            Call Change_Password(w_UserID, w_HospitalCD, w_Password)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    'Passwordを変更しようとするﾕｰｻﾞ-が存在するかを判定
    Private Function UserChk(ByVal p_Hospital As String, ByVal p_User As String, ByRef p_Password As String) As Boolean
        Const W_SUBNAME As String = "frmNSC0000HB UserChk"

        Try
            Dim w_Sql As String = String.Empty
            Dim w_Rs As ADODB.Recordset
            Dim w_Password_F As ADODB.Field
            Dim w_LastUpdDate_F As ADODB.Field

            '初期化
            m_LastUpdDate = 0

            '-- ﾕｰｻﾞ情報取得 ----------------
            w_Sql = w_Sql & "SELECT "
            w_Sql = w_Sql & "NAME, "
            w_Sql = w_Sql & "PASSWD, "
            w_Sql = w_Sql & "LASTUPDTIMEDATE "
            w_Sql = w_Sql & "FROM NS_USER_M "
            w_Sql = w_Sql & "WHERE NS_USER_M.UserID = '" & p_User & "' "
            w_Sql = w_Sql & "  AND NS_USER_M.HospitalCD = '" & p_Hospital & "' "

            'RecordSet ｵﾌﾞｼﾞｪｸﾄの作成(参照のみ)
            w_Rs = General.paDBRecordSetOpen(w_Sql)

            '0件ﾃﾞｰﾀﾁｪｯｸ
            If w_Rs.RecordCount = 0 Then
                '0件のときﾕｰｻﾞｰID存在しない
                p_Password = ""
                UserChk = False
            Else
                'ﾌｨｰﾙﾄﾞ定義
                w_Password_F = w_Rs.Fields("PASSWD")
                w_LastUpdDate_F = w_Rs.Fields("LASTUPDTIMEDATE")

                'Password取得
                p_Password = General.paGetDbFieldVal(w_Password_F, "")
                '最終更新日付
                m_LastUpdDate = Long.Parse(General.paGetDbFieldVal(w_LastUpdDate_F, 0))

                '正常終了
                UserChk = True
            End If

            w_Rs.Close()

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

    'パスワード変更画面を表示
    Private Function Change_Password(ByVal p_UserID As String, ByVal p_Hospital As String, ByVal p_Password As String) As Boolean
        Const W_SUBNAME As String = "frmNSC0000HB Change_Password"

        Try
            Dim w_Form As frmNSC0000HC = New frmNSC0000HC

            'ｵﾌﾞｼﾞｪｸﾄ作成/ﾊﾟｽﾜｰﾄﾞ入力画面
            w_Form = New frmNSC0000HC

            'ﾕｰｻﾞｰID/施設CD/旧ﾊﾟｽﾜｰﾄﾞ 設定
            w_Form.pSetData(p_UserID, p_Hospital) = p_Password
            '最終更新日付
            w_Form.pLastUpdDate = m_LastUpdDate

            'ﾊﾟｽﾜｰﾄﾞ入力画面 表示
            w_Form.ShowDialog(Me)

            'ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄ 削除
            w_Form = Nothing

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

End Class