Option Strict Off
Option Explicit On

Friend Class frmNSC0000HN
    Inherits General.FormBase

	Private Sub cmd_OK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmd_OK.Click
		Me.Close()
	End Sub
	
    Private Sub frmNSC0000HN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Const W_SUBNAME As String = "frmNSC0000HN Form_Load"
        Try
            'システムアイコン
            '    imgSystemIcon.Picture = LoadPicture(g_ImagePath & "System.ico")

            'バージョン情報
            'imgVersion.Picture = LoadPicture(g_ImagePath & "Version.jpg")

            '中央表示
            Call General.paDspCenter(Me)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try

    End Sub
End Class