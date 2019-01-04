<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmNSC0000HE
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
    Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNSC0000HE))
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.imdSelDate = New CustomText.NiszMaskedText(Me.components)
        Me.imtSelTime = New CustomText.NiszMaskedText(Me.components)
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.Location = New System.Drawing.Point(24, 88)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(100, 33)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.Location = New System.Drawing.Point(136, 88)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(89, 33)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(105, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "対象時間　："
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(105, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "対象年月日："
        '
        'imdSelDate
        '
        Me.imdSelDate.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.imdSelDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imdSelDate.Format = "D"
        Me.imdSelDate.HighlightText = True
        Me.imdSelDate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.imdSelDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.imdSelDate.Location = New System.Drawing.Point(125, 13)
        Me.imdSelDate.Mask = "0000/00/00"
        Me.imdSelDate.MaxDate = "21001231"
        Me.imdSelDate.MinDate = "18680101"
        Me.imdSelDate.Name = "imdSelDate"
        Me.imdSelDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.imdSelDate.Size = New System.Drawing.Size(100, 22)
        Me.imdSelDate.TabIndex = 0
        '
        'imtSelTime
        '
        Me.imtSelTime.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.imtSelTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imtSelTime.Format = "T"
        Me.imtSelTime.HighlightText = False
        Me.imtSelTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.imtSelTime.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.imtSelTime.Location = New System.Drawing.Point(146, 45)
        Me.imtSelTime.Mask = "00:00"
        Me.imtSelTime.MaxDate = "21001231"
        Me.imtSelTime.MinDate = "18680101"
        Me.imtSelTime.Name = "imtSelTime"
        Me.imtSelTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.imtSelTime.Size = New System.Drawing.Size(60, 22)
        Me.imtSelTime.TabIndex = 1
        '
        'frmNSC0000HE
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(248, 141)
        Me.Controls.Add(Me.imtSelTime)
        Me.Controls.Add(Me.imdSelDate)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(3, 21)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNSC0000HE"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "時間指定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imdSelDate As CustomText.NiszMaskedText
    Friend WithEvents imtSelTime As CustomText.NiszMaskedText
#End Region 
End Class