'/----------------------------------------------------------------------/
'/
'/    ｼｽﾃﾑ名称：MedWorks2.0
'/ｵﾌﾞｼﾞｪｸﾄ名称：ﾕｰｻﾞ-確認/ﾊﾟｽﾜｰﾄﾞ変更
'/        ＩＤ：NSC0000HPSW.cls
'/
'/
'/      作成者：        CREATE 1997/05/06          REV 01.00
'/      更新者：        UPDATE     /  /            REV 01.01
'/                        更新内容：(   )
'/     Copyright (C) Inter co.,ltd 1997
'/----------------------------------------------------------------------/
Option Explicit On

Public Class clsPassword
    Private m_EndFlg As Boolean     '終了状態(OK:True,ｷｬﾝｾﾙ:False)

    'ﾕｰｻﾞ確認画面の終了状態を受け取る
    Public WriteOnly Property pEndStatus(ByVal p_Flg As Boolean)
        Set(ByVal value)
            m_EndFlg = p_Flg
        End Set
    End Property
    'ﾕｰｻﾞ確認画面の終了状態を引き渡す
    Public ReadOnly Property pEndStatus() As Boolean
        Get
            pEndStatus = m_EndFlg
        End Get
    End Property

    'ﾕｰｻﾞｰ名入力画面を表示する
    Public Sub mShowWindow()
        Const W_SUBNAME As String = "clsNska000a mShowWindow"

        Try
            Dim w_FrmUser As frmNSC0000HB = New frmNSC0000HB

            'ﾛｰﾄﾞ
            Call w_FrmUser.NSC0000HB_Load()

            '表示
            If General.g_LuncherFlg <> True Then
                If w_FrmUser.pLoadStatus = True Then
                    w_FrmUser.ShowDialog()
                End If
            Else
                Call w_FrmUser.subFormUnload()
            End If

            '終了状態ﾌﾗｸﾞ取得
            m_EndFlg = w_FrmUser.pEndStatus
            General.g_ErrCheck = w_FrmUser.pEndStatus

            'ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの解放
            w_FrmUser = Nothing
        Catch ex As Exception
            Call General.paTrpMsg(Str(Err), W_SUBNAME)
        End Try
    End Sub
End Class