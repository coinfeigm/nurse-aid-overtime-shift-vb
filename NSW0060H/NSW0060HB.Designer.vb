<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmNSW0060HB
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
	Public WithEvents prgBar As System.Windows.Forms.ProgressBar
	Public WithEvents lblSyori As System.Windows.Forms.Label
	Public WithEvents lblCount As System.Windows.Forms.Label
	Public WithEvents picWait As System.Windows.Forms.Panel
	'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
	'Windows フォーム デザイナを使って変更できます。
	'コード エディタを使用して、変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.picWait = New System.Windows.Forms.Panel
        Me.prgBar = New System.Windows.Forms.ProgressBar
        Me.lblSyori = New System.Windows.Forms.Label
        Me.lblCount = New System.Windows.Forms.Label
        Me.picWait.SuspendLayout()
        Me.SuspendLayout()
        '
        'picWait
        '
        Me.picWait.BackColor = System.Drawing.SystemColors.Control
        Me.picWait.Controls.Add(Me.prgBar)
        Me.picWait.Controls.Add(Me.lblSyori)
        Me.picWait.Controls.Add(Me.lblCount)
        Me.picWait.Cursor = System.Windows.Forms.Cursors.Default
        Me.picWait.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.picWait.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picWait.Location = New System.Drawing.Point(0, 0)
        Me.picWait.Name = "picWait"
        Me.picWait.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picWait.Size = New System.Drawing.Size(345, 140)
        Me.picWait.TabIndex = 0
        Me.picWait.TabStop = True
        '
        'prgBar
        '
        Me.prgBar.Location = New System.Drawing.Point(16, 96)
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(313, 33)
        Me.prgBar.TabIndex = 1
        '
        'lblSyori
        '
        Me.lblSyori.BackColor = System.Drawing.Color.Transparent
        Me.lblSyori.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSyori.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSyori.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSyori.Location = New System.Drawing.Point(2, 32)
        Me.lblSyori.Name = "lblSyori"
        Me.lblSyori.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSyori.Size = New System.Drawing.Size(341, 25)
        Me.lblSyori.TabIndex = 3
        Me.lblSyori.Text = "マスタデータを取得中..."
        Me.lblSyori.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Transparent
        Me.lblCount.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCount.Location = New System.Drawing.Point(2, 64)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCount.Size = New System.Drawing.Size(341, 17)
        Me.lblCount.TabIndex = 2
        Me.lblCount.Text = "20/20"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmNSW0060HB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(345, 140)
        Me.Controls.Add(Me.picWait)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(354, 191)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNSW0060HB"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.picWait.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class