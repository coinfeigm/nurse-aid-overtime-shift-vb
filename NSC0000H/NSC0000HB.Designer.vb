<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNSC0000HB
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNSC0000HB))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboHospital = New System.Windows.Forms.ComboBox
        Me.cmdPassword = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtUser = New CustomText.NiszText
        Me.txtPassword = New CustomText.NiszText
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(399, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ログインID(&U)"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(399, 396)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "パスワード(&P)"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(400, 432)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "施　　　設(&B)"
        '
        'cboHospital
        '
        Me.cboHospital.BackColor = System.Drawing.SystemColors.Window
        Me.cboHospital.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHospital.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboHospital.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboHospital.Location = New System.Drawing.Point(528, 429)
        Me.cboHospital.Name = "cboHospital"
        Me.cboHospital.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboHospital.Size = New System.Drawing.Size(280, 23)
        Me.cboHospital.TabIndex = 5
        Me.cboHospital.Tag = "Hospital"
        '
        'cmdPassword
        '
        Me.cmdPassword.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPassword.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPassword.Image = CType(resources.GetObject("cmdPassword.Image"), System.Drawing.Image)
        Me.cmdPassword.Location = New System.Drawing.Point(24, 524)
        Me.cmdPassword.Name = "cmdPassword"
        Me.cmdPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPassword.Size = New System.Drawing.Size(100, 33)
        Me.cmdPassword.TabIndex = 8
        Me.cmdPassword.Tag = "Cancel"
        Me.cmdPassword.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPassword.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.Location = New System.Drawing.Point(544, 472)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(100, 33)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Tag = "OK"
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.Location = New System.Drawing.Point(672, 472)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(100, 33)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'txtUser
        '
        Me.txtUser.AutoSize = False
        Me.txtUser.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.txtUser.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtUser.Format = "Aa9"
        Me.txtUser.HighlightText = True
        Me.txtUser.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtUser.Location = New System.Drawing.Point(528, 353)
        Me.txtUser.MaxLength = 10
        Me.txtUser.MaxLengthUnit = "B"
        Me.txtUser.Name = "txtUser"
        Me.txtUser.NumType = False
        Me.txtUser.Size = New System.Drawing.Size(280, 22)
        Me.txtUser.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.AutoSize = False
        Me.txtPassword.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtPassword.Format = "Aa9@"
        Me.txtPassword.HighlightText = True
        Me.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassword.Location = New System.Drawing.Point(528, 393)
        Me.txtPassword.MaxLength = 10
        Me.txtPassword.MaxLengthUnit = "B"
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.NumType = False
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(280, 22)
        Me.txtPassword.TabIndex = 3
        '
        'frmNSC0000HB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(865, 562)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdPassword)
        Me.Controls.Add(Me.cboHospital)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(255, 203)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNSC0000HB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ユーザー名入力"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents cboHospital As System.Windows.Forms.ComboBox
    Public WithEvents cmdPassword As System.Windows.Forms.Button
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtUser As CustomText.NiszText
    Friend WithEvents txtPassword As CustomText.NiszText
End Class
