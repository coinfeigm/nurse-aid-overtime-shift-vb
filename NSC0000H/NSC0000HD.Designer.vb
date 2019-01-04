<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmNSC0000HD
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
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cmbKikan As System.Windows.Forms.ComboBox
	Public WithEvents _lblKomoku_0 As System.Windows.Forms.Label
    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更できます。
    'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNSC0000HD))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmbKikan = New System.Windows.Forms.ComboBox
        Me._lblKomoku_0 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.Location = New System.Drawing.Point(152, 72)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(89, 33)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.Location = New System.Drawing.Point(40, 72)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(100, 33)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmbKikan
        '
        Me.cmbKikan.BackColor = System.Drawing.SystemColors.Window
        Me.cmbKikan.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbKikan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKikan.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbKikan.Location = New System.Drawing.Point(72, 24)
        Me.cmbKikan.Name = "cmbKikan"
        Me.cmbKikan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbKikan.Size = New System.Drawing.Size(147, 23)
        Me.cmbKikan.TabIndex = 0
        '
        '_lblKomoku_0
        '
        Me._lblKomoku_0.BackColor = System.Drawing.Color.Transparent
        Me._lblKomoku_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblKomoku_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._lblKomoku_0.Location = New System.Drawing.Point(8, 27)
        Me._lblKomoku_0.Name = "_lblKomoku_0"
        Me._lblKomoku_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblKomoku_0.Size = New System.Drawing.Size(81, 17)
        Me._lblKomoku_0.TabIndex = 3
        Me._lblKomoku_0.Text = "期間："
        '
        'frmNSC0000HD
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(271, 116)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmbKikan)
        Me.Controls.Add(Me._lblKomoku_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(3, 19)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNSC0000HD"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "期間選択"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class