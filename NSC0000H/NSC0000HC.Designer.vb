<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmNSC0000HC
#Region "Windows フォーム デザイナによって生成されたコード "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'この呼び出しは、Windows フォーム デザイナで必要です。
		InitializeComponent()
	End Sub
	'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows フォーム デザイナで必要です。
	Private components As System.ComponentModel.IContainer
    Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents _lbl_2 As System.Windows.Forms.Label
	Public WithEvents _lbl_1 As System.Windows.Forms.Label
	Public WithEvents _lbl_0 As System.Windows.Forms.Label
	Public WithEvents lblHospital As System.Windows.Forms.Label
	Public WithEvents lblUserName As System.Windows.Forms.Label
	Public WithEvents _lbl_4 As System.Windows.Forms.Label
	Public WithEvents _lbl_3 As System.Windows.Forms.Label
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNSC0000HC))
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me._lbl_2 = New System.Windows.Forms.Label
        Me._lbl_1 = New System.Windows.Forms.Label
        Me._lbl_0 = New System.Windows.Forms.Label
        Me.lblHospital = New System.Windows.Forms.Label
        Me.lblUserName = New System.Windows.Forms.Label
        Me._lbl_4 = New System.Windows.Forms.Label
        Me._lbl_3 = New System.Windows.Forms.Label
        Me.txtOldPwd = New CustomText.NiszText
        Me.txtNewPwd = New CustomText.NiszText
        Me.txtChkPwd = New CustomText.NiszText
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.Location = New System.Drawing.Point(334, 64)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(100, 33)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.Location = New System.Drawing.Point(334, 14)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(100, 33)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Tag = "OK"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        '_lbl_2
        '
        Me._lbl_2.BackColor = System.Drawing.SystemColors.Control
        Me._lbl_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_2.Location = New System.Drawing.Point(17, 180)
        Me._lbl_2.Name = "_lbl_2"
        Me._lbl_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_2.Size = New System.Drawing.Size(149, 20)
        Me._lbl_2.TabIndex = 11
        Me._lbl_2.Text = "パスワード確認(&F)"
        '
        '_lbl_1
        '
        Me._lbl_1.BackColor = System.Drawing.SystemColors.Control
        Me._lbl_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_1.Location = New System.Drawing.Point(17, 147)
        Me._lbl_1.Name = "_lbl_1"
        Me._lbl_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_1.Size = New System.Drawing.Size(149, 20)
        Me._lbl_1.TabIndex = 10
        Me._lbl_1.Text = "新パスワード(&N)"
        '
        '_lbl_0
        '
        Me._lbl_0.BackColor = System.Drawing.SystemColors.Control
        Me._lbl_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_0.Location = New System.Drawing.Point(17, 114)
        Me._lbl_0.Name = "_lbl_0"
        Me._lbl_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_0.Size = New System.Drawing.Size(149, 20)
        Me._lbl_0.TabIndex = 9
        Me._lbl_0.Text = "旧パスワード(&O)"
        '
        'lblHospital
        '
        Me.lblHospital.BackColor = System.Drawing.SystemColors.Window
        Me.lblHospital.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHospital.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblHospital.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHospital.Location = New System.Drawing.Point(101, 57)
        Me.lblHospital.Name = "lblHospital"
        Me.lblHospital.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblHospital.Size = New System.Drawing.Size(214, 22)
        Me.lblHospital.TabIndex = 1
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.SystemColors.Window
        Me.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUserName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblUserName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUserName.Location = New System.Drawing.Point(101, 17)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblUserName.Size = New System.Drawing.Size(214, 22)
        Me.lblUserName.TabIndex = 0
        '
        '_lbl_4
        '
        Me._lbl_4.BackColor = System.Drawing.SystemColors.Control
        Me._lbl_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_4.Location = New System.Drawing.Point(14, 60)
        Me._lbl_4.Name = "_lbl_4"
        Me._lbl_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_4.Size = New System.Drawing.Size(87, 20)
        Me._lbl_4.TabIndex = 8
        Me._lbl_4.Text = "病院コード"
        '
        '_lbl_3
        '
        Me._lbl_3.BackColor = System.Drawing.SystemColors.Control
        Me._lbl_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lbl_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lbl_3.Location = New System.Drawing.Point(13, 20)
        Me._lbl_3.Name = "_lbl_3"
        Me._lbl_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lbl_3.Size = New System.Drawing.Size(87, 20)
        Me._lbl_3.TabIndex = 7
        Me._lbl_3.Text = "ログインID "
        '
        'txtOldPwd
        '
        Me.txtOldPwd.AutoSize = False
        Me.txtOldPwd.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.txtOldPwd.Format = "Aa9"
        Me.txtOldPwd.HighlightText = True
        Me.txtOldPwd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtOldPwd.Location = New System.Drawing.Point(193, 111)
        Me.txtOldPwd.MaxLength = 10
        Me.txtOldPwd.MaxLengthUnit = "B"
        Me.txtOldPwd.Name = "txtOldPwd"
        Me.txtOldPwd.NumType = False
        Me.txtOldPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPwd.Size = New System.Drawing.Size(122, 22)
        Me.txtOldPwd.TabIndex = 2
        '
        'txtNewPwd
        '
        Me.txtNewPwd.AutoSize = False
        Me.txtNewPwd.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.txtNewPwd.Format = "Aa9"
        Me.txtNewPwd.HighlightText = True
        Me.txtNewPwd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtNewPwd.Location = New System.Drawing.Point(193, 144)
        Me.txtNewPwd.MaxLength = 10
        Me.txtNewPwd.MaxLengthUnit = "B"
        Me.txtNewPwd.Name = "txtNewPwd"
        Me.txtNewPwd.NumType = False
        Me.txtNewPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPwd.Size = New System.Drawing.Size(122, 22)
        Me.txtNewPwd.TabIndex = 3
        '
        'txtChkPwd
        '
        Me.txtChkPwd.AutoSize = False
        Me.txtChkPwd.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.txtChkPwd.Format = "Aa9"
        Me.txtChkPwd.HighlightText = True
        Me.txtChkPwd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtChkPwd.Location = New System.Drawing.Point(193, 177)
        Me.txtChkPwd.MaxLength = 10
        Me.txtChkPwd.MaxLengthUnit = "B"
        Me.txtChkPwd.Name = "txtChkPwd"
        Me.txtChkPwd.NumType = False
        Me.txtChkPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtChkPwd.Size = New System.Drawing.Size(122, 22)
        Me.txtChkPwd.TabIndex = 4
        '
        'frmNSC0000HC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(440, 213)
        Me.Controls.Add(Me.txtChkPwd)
        Me.Controls.Add(Me.txtNewPwd)
        Me.Controls.Add(Me.txtOldPwd)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me._lbl_2)
        Me.Controls.Add(Me._lbl_1)
        Me.Controls.Add(Me._lbl_0)
        Me.Controls.Add(Me.lblHospital)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me._lbl_4)
        Me.Controls.Add(Me._lbl_3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(260, 204)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNSC0000HC"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "パスワードの変更"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtOldPwd As CustomText.NiszText
    Friend WithEvents txtNewPwd As CustomText.NiszText
    Friend WithEvents txtChkPwd As CustomText.NiszText
#End Region 
End Class