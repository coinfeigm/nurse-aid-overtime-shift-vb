<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmNSC0000HM
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
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cboYearMonth As System.Windows.Forms.ComboBox
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents lblKomoku As System.Windows.Forms.Label
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNSC0000HM))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboYearMonth = New System.Windows.Forms.ComboBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblKomoku = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cboYearMonth
        '
        Me.cboYearMonth.BackColor = System.Drawing.SystemColors.Window
        Me.cboYearMonth.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboYearMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYearMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboYearMonth.Location = New System.Drawing.Point(96, 16)
        Me.cboYearMonth.Name = "cboYearMonth"
        Me.cboYearMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboYearMonth.Size = New System.Drawing.Size(152, 23)
        Me.cboYearMonth.TabIndex = 0
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.Location = New System.Drawing.Point(48, 60)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(100, 33)
        Me.cmdOK.TabIndex = 1
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
        Me.cmdCancel.Location = New System.Drawing.Point(160, 60)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(100, 33)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'lblKomoku
        '
        Me.lblKomoku.BackColor = System.Drawing.Color.Transparent
        Me.lblKomoku.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblKomoku.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblKomoku.Location = New System.Drawing.Point(16, 20)
        Me.lblKomoku.Name = "lblKomoku"
        Me.lblKomoku.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblKomoku.Size = New System.Drawing.Size(89, 17)
        Me.lblKomoku.TabIndex = 3
        Me.lblKomoku.Text = "対象年月"
        '
        'frmNSC0000HM
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(272, 104)
        Me.Controls.Add(Me.cboYearMonth)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblKomoku)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(3, 19)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNSC0000HM"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "対象年月指定"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class