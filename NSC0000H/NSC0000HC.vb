Option Strict Off
Option Explicit On

Friend Class frmNSC0000HC
    Inherits General.FormBase
	'/----------------------------------------------------------------------/
    '/    ｼｽﾃﾑ名称：MedWorks2.51
	'/        画面：ﾊﾟｽﾜｰﾄﾞ変更ﾀﾞｲｱﾛｸﾞ
	'/        ＩＤ：frmNSC0000HC
	'/     Copyright (C) Inter co.,ltd 1998
	'/----------------------------------------------------------------------/
	
	'----------------------------------------------------------------------
	'       ﾌﾟﾗｲﾍﾞｰﾄ変数
	'----------------------------------------------------------------------
	Private m_HospitalCD As String '病院CD
	Private m_UserID As String 'ﾕｰｻﾞｰID
	Private m_OldPwd As String 'ﾊﾟｽﾜｰﾄﾞ 該当ﾕｰｻﾞｰIDの変更前ﾊﾟｽﾜｰﾄﾞ
	
    Private m_LastUpdDate As Long '最終更新日付

	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		'ﾒﾓﾘ ｱﾝﾛｰﾄﾞ
		Me.Close()
    End Sub

	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Const W_SUBNAME As String = "frmNSC0000HC cmdOK_Click"

        Try
            'ﾒｲﾝﾌｫｰﾑ ﾏｳｽﾎﾟｲﾝﾀ "砂時計"に変更
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'OKﾎﾞﾀﾝ 押下
            If Not RunOK() Then
                'ERRORの場合

                'ﾒｲﾝﾌｫｰﾑ ﾏｳｽﾎﾟｲﾝﾀ "通常"に変更
                Me.Cursor = System.Windows.Forms.Cursors.Default

                Exit Sub
            End If

            Me.Cursor = System.Windows.Forms.Cursors.Default

            'ﾒﾓﾘ ｱﾝﾛｰﾄﾞ
            Me.Close()

        Catch ex As Exception
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    Private Sub frmNSC0000HC_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Const W_SUBNAME As String = "frmNSC0000HC Form_Load"

        Try
            Dim w_ImagePath As String

            w_ImagePath = General.paGetIniSetting(General.G_STRININAME, General.G_STRSECTION1, "ImagePath", My.Application.Info.DirectoryPath & "\" & "image\")

            'ﾊﾟｽﾜｰﾄﾞ変更画面 ﾌﾟﾛﾊﾟﾃｨ 設定
            'ﾕｰｻﾞｰID
            lblUserName.Text = m_UserID

            '病院CDｺﾝﾎﾞﾎﾞｯｸｽ ﾃﾞﾌｫﾙﾄ 設定
            lblHospital.Text = m_HospitalCD

            'ﾌｫｰﾑ ｱｲｺﾝ 設定
            Me.Icon = New System.Drawing.Icon(w_ImagePath & "System.ico")

            '画面中央に移動
            Call General.paDspCenter(Me)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    'Passwordの変更
    Private Function RunOK() As Boolean
        Const W_SUBNAME As String = "frmNSC0000HC RunOK"

        Try
            Dim w_Sql As String
            Dim w_UserCD As String
            Dim w_Password As String
            Dim w_HospitalCD As String
            Dim w_NewPassword As String
            Dim w_ReNewPassword As String
            Dim w_strMsg() As String
            Dim w_SysDate As Long
            Dim w_Rs As ADODB.Recordset
            Dim w_LastUpdDate_F As ADODB.Field
            Dim w_LastUpdDate As Long


            RunOK = False

            'システム日付
            w_SysDate = Long.Parse(Format(Now, "yyyyMMddHHmmss"))

            'ﾕｰｻﾞｰ名 取得
            w_UserCD = lblUserName.Text

            '旧Password 取得
            w_Password = txtOldPwd.Text

            '病院ｺｰﾄﾞ 取得
            w_HospitalCD = Trim(General.paLeft(lblHospital.Text, 2))

            'パスワードに空は登録できない
            If ("").Equals(txtNewPwd.Text) Then
                'ﾕｰｻﾞｰID 存在しない
                ReDim w_strMsg(1)
                w_strMsg(1) = "パスワード"
                Call General.paMsgDsp("NS0001", w_strMsg)
                Call General.paSetFocus(txtNewPwd)
                Exit Function
            End If

            '-- Password検索 ---------------
            '大文字/小文字を区別なく判断する
            If StrComp(m_OldPwd, w_Password, 0) <> 0 Then
                'ﾊﾟｽﾜｰﾄﾞ 異なる
                ReDim w_strMsg(1)
                w_strMsg(1) = "旧パスワード"
                Call General.paMsgDsp("NS0003", w_strMsg)
                Call General.paSetFocus(txtOldPwd)
                '異常終了
                Exit Function
            End If

            '-- 新Password & Password確認 整合性ﾁｪｯｸ ----------------
            '新Password/Password確認 取得
            w_NewPassword = txtNewPwd.Text
            w_ReNewPassword = txtChkPwd.Text

            'Password ﾁｪｯｸ(大文字/小文字を区別なく判断する)
            If StrComp(w_NewPassword, w_ReNewPassword, 0) <> 0 Then
                '異なる場合
                'ｴﾗｰﾒｯｾｰｼﾞ表示
                ReDim w_strMsg(1)
                w_strMsg(1) = "確認用パスワード"
                Call General.paMsgDsp("NS0003", w_strMsg)
                Call General.paSetFocus(txtChkPwd)
                '異常終了
                Exit Function
            End If

            '-- Password更新 -------------------
            Call General.paBeginTrans()

            '---------------------
            '排他チェック
            '---------------------
            w_Sql = "SELECT LASTUPDTIMEDATE FROM NS_USER_M"
            w_Sql = w_Sql & " WHERE HOSPITALCD = '" & w_HospitalCD & "'"
            w_Sql = w_Sql & " AND USERID = '" & w_UserCD & "'"
            w_Rs = General.paDBRecordSetOpenNoWait(w_Sql)

            If w_Rs Is Nothing Then
                'BUSY状態
                Exit Function
            ElseIf w_Rs.RecordCount <= 0 Then
                '削除されている場合
                ReDim w_strMsg(0)
                Call General.paMsgDsp("NS0044", w_strMsg)

                Exit Function
            Else
                '----------------------
                '最終更新日付チェック
                '----------------------
                w_LastUpdDate_F = w_Rs.Fields("LASTUPDTIMEDATE")
                '最終更新日付
                w_LastUpdDate = Long.Parse(General.paGetDbFieldVal(w_LastUpdDate_F, 0))

                If m_LastUpdDate <> w_LastUpdDate Then
                    '変更されている場合
                    ReDim w_strMsg(0)
                    Call General.paMsgDsp("NS0045", w_strMsg)
                    Exit Function
                End If
            End If

            '更新SQL編集
            w_Sql = "UPDATE NS_USER_M SET"
            w_Sql = w_Sql & " PASSWD  = '" & w_NewPassword & "'"
            w_Sql = w_Sql & " ,PASSWORDTIMEDATE = " & w_SysDate
            w_Sql = w_Sql & " ,LASTUPDTIMEDATE = " & w_SysDate
            w_Sql = w_Sql & " ,REGISTRANTID = '" & w_UserCD & "'"
            w_Sql = w_Sql & " WHERE USERID = '" & w_UserCD & "' "
            w_Sql = w_Sql & " AND HOSPITALCD = '" & w_HospitalCD & "' "
            Call General.paDBExecute(w_Sql)

            'コミット
            Call General.paCommit()

            '正常終了
            RunOK = True

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Function

	'ﾕｰｻﾞｰID/病院CD/旧ﾊﾟｽﾜｰﾄﾞを上位画面より受け取る
	Public WriteOnly Property pSetData(ByVal p_UserID As String, ByVal p_Hospital As String) As String
		Set(ByVal Value As String)
			m_UserID = p_UserID
			m_HospitalCD = p_Hospital
			m_OldPwd = Value
		End Set
    End Property

	'最終更新日付を上位画面より受け取る
    Public WriteOnly Property pLastUpdDate() As Long
        Set(ByVal Value As Long)
            m_LastUpdDate = Value
        End Set
    End Property

    '各入力部 キー押下時イベント
    Private Sub txtChkPwd_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtChkPwd.KeyPress
        'ENTER KEY
        If eventArgs.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            cmdOK.Focus()
        End If
    End Sub
    Private Sub txtNewPwd_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtNewPwd.KeyPress
        'ENTER KEY
        If eventArgs.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            txtChkPwd.Focus()
        End If
    End Sub
    Private Sub txtOldPwd_KeyPressEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtOldPwd.KeyPress
        'ENTER KEY
        If eventArgs.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            txtNewPwd.Focus()
        End If
    End Sub
End Class