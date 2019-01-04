<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNSC0000HA
    Inherits General.FormBase

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNSC0000HA))
        Dim DefaultFocusIndicatorRenderer1 As FarPoint.Win.Spread.DefaultFocusIndicatorRenderer = New FarPoint.Win.Spread.DefaultFocusIndicatorRenderer()
        Dim DefaultScrollBarRenderer1 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim NamedStyle1 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim ComplexBorder1 As FarPoint.Win.ComplexBorder = New FarPoint.Win.ComplexBorder(New FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine))
        Dim DefaultScrollBarRenderer2 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim DefaultScrollBarRenderer3 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim DefaultScrollBarRenderer4 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim DefaultScrollBarRenderer5 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim DefaultScrollBarRenderer6 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim DefaultScrollBarRenderer7 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim DefaultScrollBarRenderer8 As FarPoint.Win.Spread.DefaultScrollBarRenderer = New FarPoint.Win.Spread.DefaultScrollBarRenderer()
        Dim NamedStyle2 As FarPoint.Win.Spread.NamedStyle = New FarPoint.Win.Spread.NamedStyle("Style1")
        Dim ComplexBorder2 As FarPoint.Win.ComplexBorder = New FarPoint.Win.ComplexBorder(New FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine))
        Me.lblSearchData = New System.Windows.Forms.Label()
        Me.lblSearchHead = New System.Windows.Forms.Label()
        Me.lblUserDept = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.picStatus = New System.Windows.Forms.PictureBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.toolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileDateChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFilePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuFileLogOff = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileEnd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuHelpVersion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripContainer4 = New System.Windows.Forms.ToolStripContainer()
        Me.albMenu = New MenuToolStrip.MenuToolStrip()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stbMenuMain = New System.Windows.Forms.MenuStrip()
        Me.ToolStripContainer2 = New System.Windows.Forms.ToolStripContainer()
        Me.vseMain = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.imlSmallIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.imlToolStrip = New System.Windows.Forms.ImageList(Me.components)
        Me.lvwDeptInfo = New System.Windows.Forms.ListView()
        Me.tvwDuty = New System.Windows.Forms.TreeView()
        Me.tvwPersonal = New System.Windows.Forms.TreeView()
        Me.vseApproveInfo = New System.Windows.Forms.Panel()
        Me.cmdChgDate_0 = New System.Windows.Forms.Button()
        Me.cmdApproveInfoCalTo = New System.Windows.Forms.Button()
        Me.cmdApproveInfoCalFrom = New System.Windows.Forms.Button()
        Me.cmdKinmuti = New System.Windows.Forms.Button()
        Me.lblKinmuti = New System.Windows.Forms.Label()
        Me.lblItem_1 = New System.Windows.Forms.Label()
        Me.lblItem_0 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblApproveDate = New System.Windows.Forms.Label()
        Me.cmdChgDate_1 = New System.Windows.Forms.Button()
        Me.cmdAllCheck = New System.Windows.Forms.Button()
        Me.cmdSelDate = New System.Windows.Forms.Button()
        Me.cmdAllClear = New System.Windows.Forms.Button()
        Me.cmbSelectAppl = New System.Windows.Forms.ComboBox()
        Me.imdAppliFrom = New System.Windows.Forms.Label()
        Me.imdAppliTo = New System.Windows.Forms.Label()
        Me.vsePersonalData = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdPersonalDataCalTo = New System.Windows.Forms.Button()
        Me.cmdPersonalDataCalFrom = New System.Windows.Forms.Button()
        Me.cmbPersonalAppli = New System.Windows.Forms.ComboBox()
        Me.imdSearchTo = New CustomText.NiszMaskedText(Me.components)
        Me.imdSearchFrom = New CustomText.NiszMaskedText(Me.components)
        Me.vseCover = New System.Windows.Forms.Panel()
        Me.fraDataGet = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.sspProc = New System.Windows.Forms.Panel()
        Me.cmdSelMonth = New System.Windows.Forms.Button()
        Me.vseCalendar = New System.Windows.Forms.Panel()
        Me.imtSelectTime = New CustomText.NiszMaskedText(Me.components)
        Me.cmdSelectTime = New System.Windows.Forms.Button()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.PnlCalendar = New System.Windows.Forms.Panel()
        Me._lblDate2_6 = New System.Windows.Forms.Label()
        Me._lblDate2_5 = New System.Windows.Forms.Label()
        Me._lblDate2_4 = New System.Windows.Forms.Label()
        Me._lblDate2_3 = New System.Windows.Forms.Label()
        Me._lblDate2_2 = New System.Windows.Forms.Label()
        Me._lblDate2_1 = New System.Windows.Forms.Label()
        Me._lblDate2_0 = New System.Windows.Forms.Label()
        Me._lblDate_13 = New System.Windows.Forms.Label()
        Me._lblDate_12 = New System.Windows.Forms.Label()
        Me._lblDate_11 = New System.Windows.Forms.Label()
        Me._lblDate_10 = New System.Windows.Forms.Label()
        Me._lblDate_9 = New System.Windows.Forms.Label()
        Me._lblDate_8 = New System.Windows.Forms.Label()
        Me._lblDate_7 = New System.Windows.Forms.Label()
        Me._lblDate_20 = New System.Windows.Forms.Label()
        Me._lblDate_19 = New System.Windows.Forms.Label()
        Me._lblDate_18 = New System.Windows.Forms.Label()
        Me._lblDate_17 = New System.Windows.Forms.Label()
        Me._lblDate_16 = New System.Windows.Forms.Label()
        Me._lblDate_15 = New System.Windows.Forms.Label()
        Me._lblDate_14 = New System.Windows.Forms.Label()
        Me._lblDate_41 = New System.Windows.Forms.Label()
        Me._lblDate_40 = New System.Windows.Forms.Label()
        Me._lblDate_39 = New System.Windows.Forms.Label()
        Me._lblDate_38 = New System.Windows.Forms.Label()
        Me._lblDate_37 = New System.Windows.Forms.Label()
        Me._lblDate_36 = New System.Windows.Forms.Label()
        Me._lblDate_35 = New System.Windows.Forms.Label()
        Me._lblDate_34 = New System.Windows.Forms.Label()
        Me._lblDate_33 = New System.Windows.Forms.Label()
        Me._lblDate_32 = New System.Windows.Forms.Label()
        Me._lblDate_31 = New System.Windows.Forms.Label()
        Me._lblDate_30 = New System.Windows.Forms.Label()
        Me._lblDate_27 = New System.Windows.Forms.Label()
        Me._lblDate_26 = New System.Windows.Forms.Label()
        Me._lblDate_25 = New System.Windows.Forms.Label()
        Me._lblDate_24 = New System.Windows.Forms.Label()
        Me._lblDate_23 = New System.Windows.Forms.Label()
        Me._lblDate_29 = New System.Windows.Forms.Label()
        Me._lblDate_22 = New System.Windows.Forms.Label()
        Me._lblDate_28 = New System.Windows.Forms.Label()
        Me._lblDate_21 = New System.Windows.Forms.Label()
        Me._lblDate_6 = New System.Windows.Forms.Label()
        Me._lblDate_5 = New System.Windows.Forms.Label()
        Me._lblDate_4 = New System.Windows.Forms.Label()
        Me._lblDate_3 = New System.Windows.Forms.Label()
        Me._lblDate_2 = New System.Windows.Forms.Label()
        Me._lblDate_1 = New System.Windows.Forms.Label()
        Me._lblDate_0 = New System.Windows.Forms.Label()
        Me._lblDate3_24 = New System.Windows.Forms.Label()
        Me._lblDate3_31 = New System.Windows.Forms.Label()
        Me._lblDate3_38 = New System.Windows.Forms.Label()
        Me._lblDate3_17 = New System.Windows.Forms.Label()
        Me._lblDate3_27 = New System.Windows.Forms.Label()
        Me._lblDate3_34 = New System.Windows.Forms.Label()
        Me._lblDate3_41 = New System.Windows.Forms.Label()
        Me._lblDate3_20 = New System.Windows.Forms.Label()
        Me._lblDate3_13 = New System.Windows.Forms.Label()
        Me._lblDate3_26 = New System.Windows.Forms.Label()
        Me._lblDate3_33 = New System.Windows.Forms.Label()
        Me._lblDate3_40 = New System.Windows.Forms.Label()
        Me._lblDate3_19 = New System.Windows.Forms.Label()
        Me._lblDate3_12 = New System.Windows.Forms.Label()
        Me._lblDate3_25 = New System.Windows.Forms.Label()
        Me._lblDate3_32 = New System.Windows.Forms.Label()
        Me._lblDate3_39 = New System.Windows.Forms.Label()
        Me._lblDate3_18 = New System.Windows.Forms.Label()
        Me._lblDate3_11 = New System.Windows.Forms.Label()
        Me._lblDate3_10 = New System.Windows.Forms.Label()
        Me._lblDate3_23 = New System.Windows.Forms.Label()
        Me._lblDate3_30 = New System.Windows.Forms.Label()
        Me._lblDate3_37 = New System.Windows.Forms.Label()
        Me._lblDate3_16 = New System.Windows.Forms.Label()
        Me._lblDate3_9 = New System.Windows.Forms.Label()
        Me._lblDate3_22 = New System.Windows.Forms.Label()
        Me._lblDate3_29 = New System.Windows.Forms.Label()
        Me._lblDate3_36 = New System.Windows.Forms.Label()
        Me._lblDate3_15 = New System.Windows.Forms.Label()
        Me._lblDate3_8 = New System.Windows.Forms.Label()
        Me._lblDate3_6 = New System.Windows.Forms.Label()
        Me._lblDate3_5 = New System.Windows.Forms.Label()
        Me._lblDate3_4 = New System.Windows.Forms.Label()
        Me._lblDate3_3 = New System.Windows.Forms.Label()
        Me._lblDate3_2 = New System.Windows.Forms.Label()
        Me._lblDate3_1 = New System.Windows.Forms.Label()
        Me._lblDate3_21 = New System.Windows.Forms.Label()
        Me._lblDate3_28 = New System.Windows.Forms.Label()
        Me._lblDate3_35 = New System.Windows.Forms.Label()
        Me._lblDate3_14 = New System.Windows.Forms.Label()
        Me._lblDate3_7 = New System.Windows.Forms.Label()
        Me._lblDate3_0 = New System.Windows.Forms.Label()
        Me.tvwKinmuDept = New System.Windows.Forms.TreeView()
        Me.lvwDeptStaff = New System.Windows.Forms.ListView()
        Me.vseInformation = New System.Windows.Forms.Panel()
        Me.lvwInformation = New System.Windows.Forms.ListView()
        Me.lvwMain = New System.Windows.Forms.ListView()
        Me.vsePersonal = New System.Windows.Forms.Panel()
        Me.sprMatrix = New FarPoint.Win.Spread.FpSpread()
        Me.sprMatrix_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.cmdPersonalTo = New System.Windows.Forms.Button()
        Me.sprKinmuCnt = New FarPoint.Win.Spread.FpSpread()
        Me.sprKinmuCnt_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.cmdPersonalFrom = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.sprTanka = New FarPoint.Win.Spread.FpSpread()
        Me.sprTanka_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.sprOverTime = New FarPoint.Win.Spread.FpSpread()
        Me.sprOverTime_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.imdFrom = New CustomText.NiszMaskedText(Me.components)
        Me.imdTo = New CustomText.NiszMaskedText(Me.components)
        Me.vstKinmuDept = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.vseDutyInfo = New System.Windows.Forms.Panel()
        Me.cmbSelectDuty = New System.Windows.Forms.ComboBox()
        Me.lblDutyDate = New System.Windows.Forms.Label()
        Me.vseDeptInfo = New System.Windows.Forms.Panel()
        Me.lblKinmuDate = New System.Windows.Forms.Label()
        Me.lblDeptInfo = New System.Windows.Forms.Label()
        Me.vseDakokuInfo = New System.Windows.Forms.Panel()
        Me.lblDakokuDate = New System.Windows.Forms.Label()
        Me.vseZaiin = New System.Windows.Forms.Panel()
        Me.lblKikan = New System.Windows.Forms.Label()
        Me.lblKinmuBusyo = New System.Windows.Forms.Label()
        Me.cboKikan = New System.Windows.Forms.ComboBox()
        Me.cboKinmuBusyo = New System.Windows.Forms.ComboBox()
        Me.lblZaiin = New System.Windows.Forms.Label()
        Me.vseLadderInfo = New System.Windows.Forms.Panel()
        Me.cmbLadderDept = New System.Windows.Forms.ComboBox()
        Me.cmbLadderDate = New System.Windows.Forms.ComboBox()
        Me.lblLadder = New System.Windows.Forms.Label()
        Me.vseHaichi = New System.Windows.Forms.Panel()
        Me.imtName2 = New CustomText.NiszText()
        Me.imtName1 = New CustomText.NiszText()
        Me.lblHaichi = New System.Windows.Forms.Label()
        Me.sprSaiyoList = New FarPoint.Win.Spread.FpSpread()
        Me.sprSaiyoList_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.sprJosyuData = New FarPoint.Win.Spread.FpSpread()
        Me.sprJosyuData_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.sprSum2 = New FarPoint.Win.Spread.FpSpread()
        Me.sprSum2_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.sprJobList = New FarPoint.Win.Spread.FpSpread()
        Me.sprJobList_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.sprSum1 = New FarPoint.Win.Spread.FpSpread()
        Me.sprSum1_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.sprKangoshiData = New FarPoint.Win.Spread.FpSpread()
        Me.sprKangoshiData_Sheet1 = New FarPoint.Win.Spread.SheetView()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        CType(Me.picStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolStrip.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStripContainer4.ContentPanel.SuspendLayout()
        Me.ToolStripContainer4.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStripContainer2.ContentPanel.SuspendLayout()
        Me.ToolStripContainer2.SuspendLayout()
        Me.vseMain.SuspendLayout()
        Me.vseApproveInfo.SuspendLayout()
        Me.vsePersonalData.SuspendLayout()
        Me.vseCover.SuspendLayout()
        Me.fraDataGet.SuspendLayout()
        Me.vseCalendar.SuspendLayout()
        Me.PnlCalendar.SuspendLayout()
        Me.vseInformation.SuspendLayout()
        Me.vsePersonal.SuspendLayout()
        CType(Me.sprMatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprMatrix_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprKinmuCnt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprKinmuCnt_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprTanka, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprTanka_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprOverTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprOverTime_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vstKinmuDept.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.vseDutyInfo.SuspendLayout()
        Me.vseDeptInfo.SuspendLayout()
        Me.vseDakokuInfo.SuspendLayout()
        Me.vseZaiin.SuspendLayout()
        Me.vseLadderInfo.SuspendLayout()
        Me.vseHaichi.SuspendLayout()
        CType(Me.sprSaiyoList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprSaiyoList_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprJosyuData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprJosyuData_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprSum2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprSum2_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprJobList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprJobList_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprSum1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprSum1_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprKangoshiData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprKangoshiData_Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSearchData
        '
        Me.lblSearchData.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSearchData.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblSearchData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSearchData.Location = New System.Drawing.Point(626, 81)
        Me.lblSearchData.Name = "lblSearchData"
        Me.lblSearchData.Size = New System.Drawing.Size(474, 23)
        Me.lblSearchData.TabIndex = 7
        Me.lblSearchData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSearchHead
        '
        Me.lblSearchHead.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSearchHead.Location = New System.Drawing.Point(566, 80)
        Me.lblSearchHead.Name = "lblSearchHead"
        Me.lblSearchHead.Size = New System.Drawing.Size(62, 23)
        Me.lblSearchHead.TabIndex = 6
        Me.lblSearchHead.Text = "対象："
        Me.lblSearchHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUserDept
        '
        Me.lblUserDept.BackColor = System.Drawing.SystemColors.Window
        Me.lblUserDept.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUserDept.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUserDept.Location = New System.Drawing.Point(357, 80)
        Me.lblUserDept.Name = "lblUserDept"
        Me.lblUserDept.Size = New System.Drawing.Size(191, 23)
        Me.lblUserDept.TabIndex = 5
        Me.lblUserDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.SystemColors.Window
        Me.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUserName.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(184, 80)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(170, 23)
        Me.lblUserName.TabIndex = 4
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserID
        '
        Me.lblUserID.BackColor = System.Drawing.SystemColors.Window
        Me.lblUserID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUserID.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUserID.Location = New System.Drawing.Point(70, 80)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(111, 23)
        Me.lblUserID.TabIndex = 3
        Me.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picStatus
        '
        Me.picStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picStatus.Location = New System.Drawing.Point(-6, 78)
        Me.picStatus.Name = "picStatus"
        Me.picStatus.Size = New System.Drawing.Size(1282, 29)
        Me.picStatus.TabIndex = 0
        Me.picStatus.TabStop = False
        '
        'lblUser
        '
        Me.lblUser.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.lblUser.Location = New System.Drawing.Point(5, 80)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(64, 23)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "利用者："
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'toolStrip
        '
        Me.toolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.toolStrip.Location = New System.Drawing.Point(-6, 0)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.toolStrip.Size = New System.Drawing.Size(144, 47)
        Me.toolStrip.TabIndex = 23
        Me.toolStrip.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(44, 44)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(44, 44)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(44, 44)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(150, 150)
        '
        'ToolStripContainer1
        '
        Me.ToolStripContainer1.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.toolStrip)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1277, 49)
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1277, 49)
        Me.ToolStripContainer1.TabIndex = 24
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(1272, 24)
        Me.MenuStrip1.TabIndex = 26
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuFileDateChange, Me.menuFilePrint, Me.ToolStripSeparator3, Me.menuFileLogOff, Me.menuFileEnd})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(81, 20)
        Me.mnuFile.Text = "ファイル(&F)"
        '
        'menuFileDateChange
        '
        Me.menuFileDateChange.Name = "menuFileDateChange"
        Me.menuFileDateChange.Size = New System.Drawing.Size(146, 22)
        Me.menuFileDateChange.Text = "入力年月変更"
        '
        'menuFilePrint
        '
        Me.menuFilePrint.Name = "menuFilePrint"
        Me.menuFilePrint.Size = New System.Drawing.Size(146, 22)
        Me.menuFilePrint.Text = "印刷"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(143, 6)
        '
        'menuFileLogOff
        '
        Me.menuFileLogOff.Name = "menuFileLogOff"
        Me.menuFileLogOff.Size = New System.Drawing.Size(146, 22)
        Me.menuFileLogOff.Text = "ログオフ"
        '
        'menuFileEnd
        '
        Me.menuFileEnd.Name = "menuFileEnd"
        Me.menuFileEnd.Size = New System.Drawing.Size(146, 22)
        Me.menuFileEnd.Text = "終了"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuHelpVersion})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(72, 20)
        Me.mnuHelp.Text = "ヘルプ(&H)"
        '
        'menuHelpVersion
        '
        Me.menuHelpVersion.Name = "menuHelpVersion"
        Me.menuHelpVersion.Size = New System.Drawing.Size(183, 22)
        Me.menuHelpVersion.Text = "バージョン情報(&A)..."
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton4.Text = "ToolStripButton4"
        '
        'ToolStripContainer4
        '
        Me.ToolStripContainer4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ToolStripContainer4.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer4.ContentPanel
        '
        Me.ToolStripContainer4.ContentPanel.Controls.Add(Me.albMenu)
        Me.ToolStripContainer4.ContentPanel.Size = New System.Drawing.Size(100, 831)
        Me.ToolStripContainer4.LeftToolStripPanelVisible = False
        Me.ToolStripContainer4.Location = New System.Drawing.Point(0, 108)
        Me.ToolStripContainer4.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripContainer4.Name = "ToolStripContainer4"
        Me.ToolStripContainer4.RightToolStripPanelVisible = False
        Me.ToolStripContainer4.Size = New System.Drawing.Size(100, 831)
        Me.ToolStripContainer4.TabIndex = 29
        Me.ToolStripContainer4.Text = "ToolStripContainer4"
        Me.ToolStripContainer4.TopToolStripPanelVisible = False
        '
        'albMenu
        '
        Me.albMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.albMenu.AutoSize = False
        Me.albMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.albMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.albMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.albMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.albMenu.Location = New System.Drawing.Point(1, 0)
        Me.albMenu.MinimumSize = New System.Drawing.Size(18, 20)
        Me.albMenu.Name = "albMenu"
        Me.albMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.albMenu.Size = New System.Drawing.Size(98, 831)
        Me.albMenu.Stretch = True
        Me.albMenu.TabIndex = 0
        Me.albMenu.Text = "MenuToolStrip1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 937)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StatusStrip1.Size = New System.Drawing.Size(1280, 25)
        Me.StatusStrip1.TabIndex = 30
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(1065, 20)
        Me.ToolStripStatusLabel1.Text = resources.GetString("ToolStripStatusLabel1.Text")
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(100, 20)
        Me.ToolStripStatusLabel2.Text = "2010/06/23"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.AutoSize = False
        Me.ToolStripStatusLabel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(100, 20)
        Me.ToolStripStatusLabel3.Text = "10:10"
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stbMenuMain
        '
        Me.stbMenuMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.stbMenuMain.Dock = System.Windows.Forms.DockStyle.None
        Me.stbMenuMain.GripMargin = New System.Windows.Forms.Padding(0)
        Me.stbMenuMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.stbMenuMain.Location = New System.Drawing.Point(7, 3)
        Me.stbMenuMain.Name = "stbMenuMain"
        Me.stbMenuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.stbMenuMain.Size = New System.Drawing.Size(207, 24)
        Me.stbMenuMain.TabIndex = 31
        Me.stbMenuMain.Text = "MenuStrip2"
        '
        'ToolStripContainer2
        '
        Me.ToolStripContainer2.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer2.ContentPanel
        '
        Me.ToolStripContainer2.ContentPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ToolStripContainer2.ContentPanel.Controls.Add(Me.vseMain)
        Me.ToolStripContainer2.ContentPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripContainer2.ContentPanel.Size = New System.Drawing.Size(1178, 38)
        Me.ToolStripContainer2.LeftToolStripPanelVisible = False
        Me.ToolStripContainer2.Location = New System.Drawing.Point(100, 108)
        Me.ToolStripContainer2.Name = "ToolStripContainer2"
        Me.ToolStripContainer2.RightToolStripPanelVisible = False
        Me.ToolStripContainer2.Size = New System.Drawing.Size(1178, 38)
        Me.ToolStripContainer2.TabIndex = 32
        Me.ToolStripContainer2.Text = "ToolStripContainer2"
        Me.ToolStripContainer2.TopToolStripPanelVisible = False
        '
        'vseMain
        '
        Me.vseMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.vseMain.Controls.Add(Me.stbMenuMain)
        Me.vseMain.Location = New System.Drawing.Point(0, 2)
        Me.vseMain.Margin = New System.Windows.Forms.Padding(0)
        Me.vseMain.Name = "vseMain"
        Me.vseMain.Size = New System.Drawing.Size(1175, 33)
        Me.vseMain.TabIndex = 37
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'imlSmallIcon
        '
        Me.imlSmallIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imlSmallIcon.ImageSize = New System.Drawing.Size(22, 22)
        Me.imlSmallIcon.TransparentColor = System.Drawing.Color.Transparent
        '
        'imlToolStrip
        '
        Me.imlToolStrip.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imlToolStrip.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlToolStrip.TransparentColor = System.Drawing.Color.Transparent
        '
        'lvwDeptInfo
        '
        Me.lvwDeptInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwDeptInfo.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lvwDeptInfo.FullRowSelect = True
        Me.lvwDeptInfo.HideSelection = False
        Me.lvwDeptInfo.Location = New System.Drawing.Point(544, 391)
        Me.lvwDeptInfo.MultiSelect = False
        Me.lvwDeptInfo.Name = "lvwDeptInfo"
        Me.lvwDeptInfo.Size = New System.Drawing.Size(55, 0)
        Me.lvwDeptInfo.TabIndex = 39
        Me.lvwDeptInfo.UseCompatibleStateImageBehavior = False
        Me.lvwDeptInfo.Visible = False
        '
        'tvwDuty
        '
        Me.tvwDuty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvwDuty.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tvwDuty.Location = New System.Drawing.Point(703, 374)
        Me.tvwDuty.Name = "tvwDuty"
        Me.tvwDuty.Size = New System.Drawing.Size(64, 26)
        Me.tvwDuty.TabIndex = 41
        Me.tvwDuty.Visible = False
        '
        'tvwPersonal
        '
        Me.tvwPersonal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvwPersonal.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tvwPersonal.Location = New System.Drawing.Point(620, 374)
        Me.tvwPersonal.Name = "tvwPersonal"
        Me.tvwPersonal.Size = New System.Drawing.Size(64, 26)
        Me.tvwPersonal.TabIndex = 42
        Me.tvwPersonal.Visible = False
        '
        'vseApproveInfo
        '
        Me.vseApproveInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.vseApproveInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vseApproveInfo.Controls.Add(Me.cmdChgDate_0)
        Me.vseApproveInfo.Controls.Add(Me.cmdApproveInfoCalTo)
        Me.vseApproveInfo.Controls.Add(Me.cmdApproveInfoCalFrom)
        Me.vseApproveInfo.Controls.Add(Me.cmdKinmuti)
        Me.vseApproveInfo.Controls.Add(Me.lblKinmuti)
        Me.vseApproveInfo.Controls.Add(Me.lblItem_1)
        Me.vseApproveInfo.Controls.Add(Me.lblItem_0)
        Me.vseApproveInfo.Controls.Add(Me.Label3)
        Me.vseApproveInfo.Controls.Add(Me.lblApproveDate)
        Me.vseApproveInfo.Controls.Add(Me.cmdChgDate_1)
        Me.vseApproveInfo.Controls.Add(Me.cmdAllCheck)
        Me.vseApproveInfo.Controls.Add(Me.cmdSelDate)
        Me.vseApproveInfo.Controls.Add(Me.cmdAllClear)
        Me.vseApproveInfo.Controls.Add(Me.cmbSelectAppl)
        Me.vseApproveInfo.Controls.Add(Me.imdAppliFrom)
        Me.vseApproveInfo.Controls.Add(Me.imdAppliTo)
        Me.vseApproveInfo.Location = New System.Drawing.Point(495, 496)
        Me.vseApproveInfo.Name = "vseApproveInfo"
        Me.vseApproveInfo.Size = New System.Drawing.Size(159, 147)
        Me.vseApproveInfo.TabIndex = 0
        Me.vseApproveInfo.Visible = False
        '
        'cmdChgDate_0
        '
        Me.cmdChgDate_0.Image = CType(resources.GetObject("cmdChgDate_0.Image"), System.Drawing.Image)
        Me.cmdChgDate_0.Location = New System.Drawing.Point(232, 26)
        Me.cmdChgDate_0.Name = "cmdChgDate_0"
        Me.cmdChgDate_0.Size = New System.Drawing.Size(92, 37)
        Me.cmdChgDate_0.TabIndex = 103
        Me.cmdChgDate_0.UseVisualStyleBackColor = True
        '
        'cmdApproveInfoCalTo
        '
        Me.cmdApproveInfoCalTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdApproveInfoCalTo.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdApproveInfoCalTo.Location = New System.Drawing.Point(785, 15)
        Me.cmdApproveInfoCalTo.Name = "cmdApproveInfoCalTo"
        Me.cmdApproveInfoCalTo.Size = New System.Drawing.Size(25, 22)
        Me.cmdApproveInfoCalTo.TabIndex = 4
        Me.cmdApproveInfoCalTo.Text = "…"
        Me.cmdApproveInfoCalTo.UseVisualStyleBackColor = False
        '
        'cmdApproveInfoCalFrom
        '
        Me.cmdApproveInfoCalFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdApproveInfoCalFrom.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdApproveInfoCalFrom.Location = New System.Drawing.Point(626, 15)
        Me.cmdApproveInfoCalFrom.Name = "cmdApproveInfoCalFrom"
        Me.cmdApproveInfoCalFrom.Size = New System.Drawing.Size(25, 22)
        Me.cmdApproveInfoCalFrom.TabIndex = 3
        Me.cmdApproveInfoCalFrom.Text = "…"
        Me.cmdApproveInfoCalFrom.UseVisualStyleBackColor = False
        '
        'cmdKinmuti
        '
        Me.cmdKinmuti.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdKinmuti.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdKinmuti.Location = New System.Drawing.Point(473, 15)
        Me.cmdKinmuti.Name = "cmdKinmuti"
        Me.cmdKinmuti.Size = New System.Drawing.Size(25, 22)
        Me.cmdKinmuti.TabIndex = 5
        Me.cmdKinmuti.Text = "…"
        Me.cmdKinmuti.UseVisualStyleBackColor = False
        '
        'lblKinmuti
        '
        Me.lblKinmuti.BackColor = System.Drawing.Color.White
        Me.lblKinmuti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKinmuti.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKinmuti.Location = New System.Drawing.Point(307, 14)
        Me.lblKinmuti.Name = "lblKinmuti"
        Me.lblKinmuti.Size = New System.Drawing.Size(191, 24)
        Me.lblKinmuti.TabIndex = 100
        Me.lblKinmuti.Text = "勤務地"
        Me.lblKinmuti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItem_1
        '
        Me.lblItem_1.AutoSize = True
        Me.lblItem_1.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblItem_1.Location = New System.Drawing.Point(230, 59)
        Me.lblItem_1.Name = "lblItem_1"
        Me.lblItem_1.Size = New System.Drawing.Size(71, 15)
        Me.lblItem_1.TabIndex = 1
        Me.lblItem_1.Text = "届出区分"
        '
        'lblItem_0
        '
        Me.lblItem_0.AutoSize = True
        Me.lblItem_0.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblItem_0.Location = New System.Drawing.Point(245, 15)
        Me.lblItem_0.Name = "lblItem_0"
        Me.lblItem_0.Size = New System.Drawing.Size(55, 15)
        Me.lblItem_0.TabIndex = 1
        Me.lblItem_0.Text = "勤務地"
        Me.lblItem_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(661, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "～"
        '
        'lblApproveDate
        '
        Me.lblApproveDate.AutoSize = True
        Me.lblApproveDate.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblApproveDate.Location = New System.Drawing.Point(26, 124)
        Me.lblApproveDate.Name = "lblApproveDate"
        Me.lblApproveDate.Size = New System.Drawing.Size(71, 15)
        Me.lblApproveDate.TabIndex = 30
        Me.lblApproveDate.Text = "未承認用"
        '
        'cmdChgDate_1
        '
        Me.cmdChgDate_1.Image = CType(resources.GetObject("cmdChgDate_1.Image"), System.Drawing.Image)
        Me.cmdChgDate_1.Location = New System.Drawing.Point(26, 57)
        Me.cmdChgDate_1.Name = "cmdChgDate_1"
        Me.cmdChgDate_1.Size = New System.Drawing.Size(92, 37)
        Me.cmdChgDate_1.TabIndex = 32
        Me.cmdChgDate_1.UseVisualStyleBackColor = True
        '
        'cmdAllCheck
        '
        Me.cmdAllCheck.Image = CType(resources.GetObject("cmdAllCheck.Image"), System.Drawing.Image)
        Me.cmdAllCheck.Location = New System.Drawing.Point(15, 25)
        Me.cmdAllCheck.Name = "cmdAllCheck"
        Me.cmdAllCheck.Size = New System.Drawing.Size(100, 36)
        Me.cmdAllCheck.TabIndex = 31
        Me.cmdAllCheck.UseVisualStyleBackColor = True
        '
        'cmdSelDate
        '
        Me.cmdSelDate.Image = CType(resources.GetObject("cmdSelDate.Image"), System.Drawing.Image)
        Me.cmdSelDate.Location = New System.Drawing.Point(132, 69)
        Me.cmdSelDate.Name = "cmdSelDate"
        Me.cmdSelDate.Size = New System.Drawing.Size(92, 37)
        Me.cmdSelDate.TabIndex = 32
        Me.cmdSelDate.UseVisualStyleBackColor = True
        '
        'cmdAllClear
        '
        Me.cmdAllClear.Image = CType(resources.GetObject("cmdAllClear.Image"), System.Drawing.Image)
        Me.cmdAllClear.Location = New System.Drawing.Point(126, 25)
        Me.cmdAllClear.Name = "cmdAllClear"
        Me.cmdAllClear.Size = New System.Drawing.Size(100, 36)
        Me.cmdAllClear.TabIndex = 32
        Me.cmdAllClear.UseVisualStyleBackColor = True
        '
        'cmbSelectAppl
        '
        Me.cmbSelectAppl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSelectAppl.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSelectAppl.FormattingEnabled = True
        Me.cmbSelectAppl.Location = New System.Drawing.Point(307, 51)
        Me.cmbSelectAppl.Name = "cmbSelectAppl"
        Me.cmbSelectAppl.Size = New System.Drawing.Size(344, 23)
        Me.cmbSelectAppl.TabIndex = 0
        '
        'imdAppliFrom
        '
        Me.imdAppliFrom.BackColor = System.Drawing.Color.White
        Me.imdAppliFrom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imdAppliFrom.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imdAppliFrom.Location = New System.Drawing.Point(531, 14)
        Me.imdAppliFrom.Name = "imdAppliFrom"
        Me.imdAppliFrom.Size = New System.Drawing.Size(120, 24)
        Me.imdAppliFrom.TabIndex = 104
        Me.imdAppliFrom.Text = "____/__/__"
        Me.imdAppliFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'imdAppliTo
        '
        Me.imdAppliTo.BackColor = System.Drawing.Color.White
        Me.imdAppliTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imdAppliTo.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imdAppliTo.Location = New System.Drawing.Point(690, 14)
        Me.imdAppliTo.Name = "imdAppliTo"
        Me.imdAppliTo.Size = New System.Drawing.Size(120, 24)
        Me.imdAppliTo.TabIndex = 105
        Me.imdAppliTo.Text = "____/__/__"
        Me.imdAppliTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'vsePersonalData
        '
        Me.vsePersonalData.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.vsePersonalData.Controls.Add(Me.Label1)
        Me.vsePersonalData.Controls.Add(Me.cmdPersonalDataCalTo)
        Me.vsePersonalData.Controls.Add(Me.cmdPersonalDataCalFrom)
        Me.vsePersonalData.Controls.Add(Me.cmbPersonalAppli)
        Me.vsePersonalData.Controls.Add(Me.imdSearchTo)
        Me.vsePersonalData.Controls.Add(Me.imdSearchFrom)
        Me.vsePersonalData.Location = New System.Drawing.Point(335, 496)
        Me.vsePersonalData.Name = "vsePersonalData"
        Me.vsePersonalData.Size = New System.Drawing.Size(154, 147)
        Me.vsePersonalData.TabIndex = 44
        Me.vsePersonalData.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(243, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "～"
        '
        'cmdPersonalDataCalTo
        '
        Me.cmdPersonalDataCalTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdPersonalDataCalTo.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdPersonalDataCalTo.Location = New System.Drawing.Point(372, 22)
        Me.cmdPersonalDataCalTo.Name = "cmdPersonalDataCalTo"
        Me.cmdPersonalDataCalTo.Size = New System.Drawing.Size(25, 22)
        Me.cmdPersonalDataCalTo.TabIndex = 77
        Me.cmdPersonalDataCalTo.Text = "…"
        Me.cmdPersonalDataCalTo.UseVisualStyleBackColor = False
        '
        'cmdPersonalDataCalFrom
        '
        Me.cmdPersonalDataCalFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdPersonalDataCalFrom.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdPersonalDataCalFrom.Location = New System.Drawing.Point(204, 22)
        Me.cmdPersonalDataCalFrom.Name = "cmdPersonalDataCalFrom"
        Me.cmdPersonalDataCalFrom.Size = New System.Drawing.Size(25, 22)
        Me.cmdPersonalDataCalFrom.TabIndex = 76
        Me.cmdPersonalDataCalFrom.Text = "…"
        Me.cmdPersonalDataCalFrom.UseVisualStyleBackColor = False
        '
        'cmbPersonalAppli
        '
        Me.cmbPersonalAppli.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbPersonalAppli.FormattingEnabled = True
        Me.cmbPersonalAppli.Location = New System.Drawing.Point(27, 70)
        Me.cmbPersonalAppli.Name = "cmbPersonalAppli"
        Me.cmbPersonalAppli.Size = New System.Drawing.Size(121, 23)
        Me.cmbPersonalAppli.TabIndex = 3
        '
        'imdSearchTo
        '
        Me.imdSearchTo.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.imdSearchTo.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imdSearchTo.Format = "D"
        Me.imdSearchTo.HighlightText = True
        Me.imdSearchTo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.imdSearchTo.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.imdSearchTo.Location = New System.Drawing.Point(277, 22)
        Me.imdSearchTo.Mask = "0000/00/00"
        Me.imdSearchTo.MaxDate = "21001231"
        Me.imdSearchTo.MinDate = "18680101"
        Me.imdSearchTo.Name = "imdSearchTo"
        Me.imdSearchTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.imdSearchTo.Size = New System.Drawing.Size(120, 22)
        Me.imdSearchTo.TabIndex = 2
        '
        'imdSearchFrom
        '
        Me.imdSearchFrom.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.imdSearchFrom.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imdSearchFrom.Format = "D"
        Me.imdSearchFrom.HighlightText = True
        Me.imdSearchFrom.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.imdSearchFrom.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.imdSearchFrom.Location = New System.Drawing.Point(108, 22)
        Me.imdSearchFrom.Mask = "0000/00/00"
        Me.imdSearchFrom.MaxDate = "21001231"
        Me.imdSearchFrom.MinDate = "18680101"
        Me.imdSearchFrom.Name = "imdSearchFrom"
        Me.imdSearchFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.imdSearchFrom.Size = New System.Drawing.Size(120, 22)
        Me.imdSearchFrom.TabIndex = 0
        '
        'vseCover
        '
        Me.vseCover.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vseCover.Controls.Add(Me.fraDataGet)
        Me.vseCover.Location = New System.Drawing.Point(820, 340)
        Me.vseCover.Name = "vseCover"
        Me.vseCover.Size = New System.Drawing.Size(321, 40)
        Me.vseCover.TabIndex = 48
        Me.vseCover.Visible = False
        '
        'fraDataGet
        '
        Me.fraDataGet.Controls.Add(Me.lblStatus)
        Me.fraDataGet.Controls.Add(Me.sspProc)
        Me.fraDataGet.Location = New System.Drawing.Point(3, 13)
        Me.fraDataGet.Name = "fraDataGet"
        Me.fraDataGet.Size = New System.Drawing.Size(315, 80)
        Me.fraDataGet.TabIndex = 49
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("MS Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(83, 33)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(208, 21)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "データ取得中・・・"
        '
        'sspProc
        '
        Me.sspProc.Location = New System.Drawing.Point(16, 21)
        Me.sspProc.Name = "sspProc"
        Me.sspProc.Size = New System.Drawing.Size(48, 47)
        Me.sspProc.TabIndex = 49
        '
        'cmdSelMonth
        '
        Me.cmdSelMonth.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelMonth.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.cmdSelMonth.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSelMonth.Location = New System.Drawing.Point(10, 7)
        Me.cmdSelMonth.Name = "cmdSelMonth"
        Me.cmdSelMonth.Size = New System.Drawing.Size(227, 25)
        Me.cmdSelMonth.TabIndex = 36
        Me.cmdSelMonth.Text = "Button1"
        Me.cmdSelMonth.UseVisualStyleBackColor = False
        '
        'vseCalendar
        '
        Me.vseCalendar.BackColor = System.Drawing.SystemColors.Control
        Me.vseCalendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vseCalendar.Controls.Add(Me.cmdSelMonth)
        Me.vseCalendar.Controls.Add(Me.imtSelectTime)
        Me.vseCalendar.Controls.Add(Me.cmdSelectTime)
        Me.vseCalendar.Controls.Add(Me.lblTime)
        Me.vseCalendar.Controls.Add(Me.PnlCalendar)
        Me.vseCalendar.Location = New System.Drawing.Point(100, 145)
        Me.vseCalendar.Name = "vseCalendar"
        Me.vseCalendar.Size = New System.Drawing.Size(247, 264)
        Me.vseCalendar.TabIndex = 37
        '
        'imtSelectTime
        '
        Me.imtSelectTime.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.imtSelectTime.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imtSelectTime.Format = "T"
        Me.imtSelectTime.HighlightText = False
        Me.imtSelectTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.imtSelectTime.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.imtSelectTime.Location = New System.Drawing.Point(85, 245)
        Me.imtSelectTime.Mask = "00:00"
        Me.imtSelectTime.MaxDate = "21001231"
        Me.imtSelectTime.MinDate = "18680101"
        Me.imtSelectTime.Name = "imtSelectTime"
        Me.imtSelectTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.imtSelectTime.Size = New System.Drawing.Size(74, 22)
        Me.imtSelectTime.TabIndex = 46
        Me.imtSelectTime.Visible = False
        '
        'cmdSelectTime
        '
        Me.cmdSelectTime.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectTime.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSelectTime.Location = New System.Drawing.Point(138, 225)
        Me.cmdSelectTime.Name = "cmdSelectTime"
        Me.cmdSelectTime.Size = New System.Drawing.Size(25, 22)
        Me.cmdSelectTime.TabIndex = 73
        Me.cmdSelectTime.Text = "▼"
        Me.cmdSelectTime.UseVisualStyleBackColor = False
        '
        'lblTime
        '
        Me.lblTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTime.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTime.Location = New System.Drawing.Point(86, 225)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(77, 22)
        Me.lblTime.TabIndex = 75
        Me.lblTime.Text = "Label1"
        Me.lblTime.Visible = False
        '
        'PnlCalendar
        '
        Me.PnlCalendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlCalendar.Controls.Add(Me._lblDate2_6)
        Me.PnlCalendar.Controls.Add(Me._lblDate2_5)
        Me.PnlCalendar.Controls.Add(Me._lblDate2_4)
        Me.PnlCalendar.Controls.Add(Me._lblDate2_3)
        Me.PnlCalendar.Controls.Add(Me._lblDate2_2)
        Me.PnlCalendar.Controls.Add(Me._lblDate2_1)
        Me.PnlCalendar.Controls.Add(Me._lblDate2_0)
        Me.PnlCalendar.Controls.Add(Me._lblDate_13)
        Me.PnlCalendar.Controls.Add(Me._lblDate_12)
        Me.PnlCalendar.Controls.Add(Me._lblDate_11)
        Me.PnlCalendar.Controls.Add(Me._lblDate_10)
        Me.PnlCalendar.Controls.Add(Me._lblDate_9)
        Me.PnlCalendar.Controls.Add(Me._lblDate_8)
        Me.PnlCalendar.Controls.Add(Me._lblDate_7)
        Me.PnlCalendar.Controls.Add(Me._lblDate_20)
        Me.PnlCalendar.Controls.Add(Me._lblDate_19)
        Me.PnlCalendar.Controls.Add(Me._lblDate_18)
        Me.PnlCalendar.Controls.Add(Me._lblDate_17)
        Me.PnlCalendar.Controls.Add(Me._lblDate_16)
        Me.PnlCalendar.Controls.Add(Me._lblDate_15)
        Me.PnlCalendar.Controls.Add(Me._lblDate_14)
        Me.PnlCalendar.Controls.Add(Me._lblDate_41)
        Me.PnlCalendar.Controls.Add(Me._lblDate_40)
        Me.PnlCalendar.Controls.Add(Me._lblDate_39)
        Me.PnlCalendar.Controls.Add(Me._lblDate_38)
        Me.PnlCalendar.Controls.Add(Me._lblDate_37)
        Me.PnlCalendar.Controls.Add(Me._lblDate_36)
        Me.PnlCalendar.Controls.Add(Me._lblDate_35)
        Me.PnlCalendar.Controls.Add(Me._lblDate_34)
        Me.PnlCalendar.Controls.Add(Me._lblDate_33)
        Me.PnlCalendar.Controls.Add(Me._lblDate_32)
        Me.PnlCalendar.Controls.Add(Me._lblDate_31)
        Me.PnlCalendar.Controls.Add(Me._lblDate_30)
        Me.PnlCalendar.Controls.Add(Me._lblDate_27)
        Me.PnlCalendar.Controls.Add(Me._lblDate_26)
        Me.PnlCalendar.Controls.Add(Me._lblDate_25)
        Me.PnlCalendar.Controls.Add(Me._lblDate_24)
        Me.PnlCalendar.Controls.Add(Me._lblDate_23)
        Me.PnlCalendar.Controls.Add(Me._lblDate_29)
        Me.PnlCalendar.Controls.Add(Me._lblDate_22)
        Me.PnlCalendar.Controls.Add(Me._lblDate_28)
        Me.PnlCalendar.Controls.Add(Me._lblDate_21)
        Me.PnlCalendar.Controls.Add(Me._lblDate_6)
        Me.PnlCalendar.Controls.Add(Me._lblDate_5)
        Me.PnlCalendar.Controls.Add(Me._lblDate_4)
        Me.PnlCalendar.Controls.Add(Me._lblDate_3)
        Me.PnlCalendar.Controls.Add(Me._lblDate_2)
        Me.PnlCalendar.Controls.Add(Me._lblDate_1)
        Me.PnlCalendar.Controls.Add(Me._lblDate_0)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_24)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_31)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_38)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_17)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_27)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_34)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_41)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_20)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_13)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_26)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_33)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_40)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_19)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_12)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_25)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_32)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_39)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_18)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_11)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_10)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_23)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_30)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_37)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_16)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_9)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_22)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_29)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_36)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_15)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_8)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_6)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_5)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_4)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_3)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_2)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_1)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_21)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_28)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_35)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_14)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_7)
        Me.PnlCalendar.Controls.Add(Me._lblDate3_0)
        Me.PnlCalendar.Location = New System.Drawing.Point(-1, 38)
        Me.PnlCalendar.Name = "PnlCalendar"
        Me.PnlCalendar.Size = New System.Drawing.Size(247, 178)
        Me.PnlCalendar.TabIndex = 105
        '
        '_lblDate2_6
        '
        Me._lblDate2_6.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate2_6.Location = New System.Drawing.Point(208, 7)
        Me._lblDate2_6.Name = "_lblDate2_6"
        Me._lblDate2_6.Size = New System.Drawing.Size(29, 20)
        Me._lblDate2_6.TabIndex = 7
        Me._lblDate2_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate2_5
        '
        Me._lblDate2_5.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate2_5.Location = New System.Drawing.Point(175, 7)
        Me._lblDate2_5.Name = "_lblDate2_5"
        Me._lblDate2_5.Size = New System.Drawing.Size(29, 20)
        Me._lblDate2_5.TabIndex = 6
        Me._lblDate2_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate2_4
        '
        Me._lblDate2_4.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate2_4.Location = New System.Drawing.Point(142, 7)
        Me._lblDate2_4.Name = "_lblDate2_4"
        Me._lblDate2_4.Size = New System.Drawing.Size(29, 20)
        Me._lblDate2_4.TabIndex = 5
        Me._lblDate2_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate2_3
        '
        Me._lblDate2_3.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate2_3.Location = New System.Drawing.Point(109, 7)
        Me._lblDate2_3.Name = "_lblDate2_3"
        Me._lblDate2_3.Size = New System.Drawing.Size(29, 20)
        Me._lblDate2_3.TabIndex = 4
        Me._lblDate2_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate2_2
        '
        Me._lblDate2_2.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate2_2.Location = New System.Drawing.Point(76, 7)
        Me._lblDate2_2.Name = "_lblDate2_2"
        Me._lblDate2_2.Size = New System.Drawing.Size(29, 20)
        Me._lblDate2_2.TabIndex = 3
        Me._lblDate2_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate2_1
        '
        Me._lblDate2_1.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate2_1.Location = New System.Drawing.Point(43, 7)
        Me._lblDate2_1.Name = "_lblDate2_1"
        Me._lblDate2_1.Size = New System.Drawing.Size(29, 20)
        Me._lblDate2_1.TabIndex = 2
        Me._lblDate2_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate2_0
        '
        Me._lblDate2_0.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate2_0.Location = New System.Drawing.Point(10, 7)
        Me._lblDate2_0.Name = "_lblDate2_0"
        Me._lblDate2_0.Size = New System.Drawing.Size(29, 20)
        Me._lblDate2_0.TabIndex = 1
        Me._lblDate2_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_13
        '
        Me._lblDate_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_13.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_13.Location = New System.Drawing.Point(209, 55)
        Me._lblDate_13.Name = "_lblDate_13"
        Me._lblDate_13.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_13.TabIndex = 21
        Me._lblDate_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_12
        '
        Me._lblDate_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_12.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_12.Location = New System.Drawing.Point(176, 55)
        Me._lblDate_12.Name = "_lblDate_12"
        Me._lblDate_12.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_12.TabIndex = 20
        Me._lblDate_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_11
        '
        Me._lblDate_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_11.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_11.Location = New System.Drawing.Point(143, 55)
        Me._lblDate_11.Name = "_lblDate_11"
        Me._lblDate_11.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_11.TabIndex = 19
        Me._lblDate_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_10
        '
        Me._lblDate_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_10.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_10.Location = New System.Drawing.Point(110, 55)
        Me._lblDate_10.Name = "_lblDate_10"
        Me._lblDate_10.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_10.TabIndex = 18
        Me._lblDate_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_9
        '
        Me._lblDate_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_9.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_9.Location = New System.Drawing.Point(77, 55)
        Me._lblDate_9.Name = "_lblDate_9"
        Me._lblDate_9.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_9.TabIndex = 17
        Me._lblDate_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_8
        '
        Me._lblDate_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_8.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_8.Location = New System.Drawing.Point(44, 55)
        Me._lblDate_8.Name = "_lblDate_8"
        Me._lblDate_8.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_8.TabIndex = 16
        Me._lblDate_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_7
        '
        Me._lblDate_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_7.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_7.Location = New System.Drawing.Point(11, 55)
        Me._lblDate_7.Name = "_lblDate_7"
        Me._lblDate_7.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_7.TabIndex = 15
        Me._lblDate_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_20
        '
        Me._lblDate_20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_20.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_20.Location = New System.Drawing.Point(209, 79)
        Me._lblDate_20.Name = "_lblDate_20"
        Me._lblDate_20.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_20.TabIndex = 30
        Me._lblDate_20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_19
        '
        Me._lblDate_19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_19.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_19.Location = New System.Drawing.Point(176, 79)
        Me._lblDate_19.Name = "_lblDate_19"
        Me._lblDate_19.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_19.TabIndex = 29
        Me._lblDate_19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_18
        '
        Me._lblDate_18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_18.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_18.Location = New System.Drawing.Point(143, 79)
        Me._lblDate_18.Name = "_lblDate_18"
        Me._lblDate_18.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_18.TabIndex = 28
        Me._lblDate_18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_17
        '
        Me._lblDate_17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_17.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_17.Location = New System.Drawing.Point(110, 79)
        Me._lblDate_17.Name = "_lblDate_17"
        Me._lblDate_17.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_17.TabIndex = 27
        Me._lblDate_17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_16
        '
        Me._lblDate_16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_16.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_16.Location = New System.Drawing.Point(77, 79)
        Me._lblDate_16.Name = "_lblDate_16"
        Me._lblDate_16.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_16.TabIndex = 26
        Me._lblDate_16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_15
        '
        Me._lblDate_15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_15.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_15.Location = New System.Drawing.Point(44, 79)
        Me._lblDate_15.Name = "_lblDate_15"
        Me._lblDate_15.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_15.TabIndex = 25
        Me._lblDate_15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_14
        '
        Me._lblDate_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_14.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_14.Location = New System.Drawing.Point(11, 79)
        Me._lblDate_14.Name = "_lblDate_14"
        Me._lblDate_14.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_14.TabIndex = 22
        Me._lblDate_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_41
        '
        Me._lblDate_41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_41.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_41.Location = New System.Drawing.Point(209, 151)
        Me._lblDate_41.Name = "_lblDate_41"
        Me._lblDate_41.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_41.TabIndex = 49
        Me._lblDate_41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_40
        '
        Me._lblDate_40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_40.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_40.Location = New System.Drawing.Point(176, 151)
        Me._lblDate_40.Name = "_lblDate_40"
        Me._lblDate_40.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_40.TabIndex = 48
        Me._lblDate_40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_39
        '
        Me._lblDate_39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_39.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_39.Location = New System.Drawing.Point(143, 151)
        Me._lblDate_39.Name = "_lblDate_39"
        Me._lblDate_39.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_39.TabIndex = 47
        Me._lblDate_39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_38
        '
        Me._lblDate_38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_38.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_38.Location = New System.Drawing.Point(110, 151)
        Me._lblDate_38.Name = "_lblDate_38"
        Me._lblDate_38.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_38.TabIndex = 46
        Me._lblDate_38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_37
        '
        Me._lblDate_37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_37.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_37.Location = New System.Drawing.Point(77, 151)
        Me._lblDate_37.Name = "_lblDate_37"
        Me._lblDate_37.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_37.TabIndex = 45
        Me._lblDate_37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_36
        '
        Me._lblDate_36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_36.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_36.Location = New System.Drawing.Point(44, 151)
        Me._lblDate_36.Name = "_lblDate_36"
        Me._lblDate_36.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_36.TabIndex = 44
        Me._lblDate_36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_35
        '
        Me._lblDate_35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_35.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_35.Location = New System.Drawing.Point(11, 151)
        Me._lblDate_35.Name = "_lblDate_35"
        Me._lblDate_35.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_35.TabIndex = 43
        Me._lblDate_35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_34
        '
        Me._lblDate_34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_34.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_34.Location = New System.Drawing.Point(209, 127)
        Me._lblDate_34.Name = "_lblDate_34"
        Me._lblDate_34.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_34.TabIndex = 42
        Me._lblDate_34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_33
        '
        Me._lblDate_33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_33.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_33.Location = New System.Drawing.Point(176, 127)
        Me._lblDate_33.Name = "_lblDate_33"
        Me._lblDate_33.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_33.TabIndex = 41
        Me._lblDate_33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_32
        '
        Me._lblDate_32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_32.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_32.Location = New System.Drawing.Point(143, 127)
        Me._lblDate_32.Name = "_lblDate_32"
        Me._lblDate_32.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_32.TabIndex = 40
        Me._lblDate_32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_31
        '
        Me._lblDate_31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_31.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_31.Location = New System.Drawing.Point(110, 127)
        Me._lblDate_31.Name = "_lblDate_31"
        Me._lblDate_31.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_31.TabIndex = 39
        Me._lblDate_31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_30
        '
        Me._lblDate_30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_30.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_30.Location = New System.Drawing.Point(77, 127)
        Me._lblDate_30.Name = "_lblDate_30"
        Me._lblDate_30.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_30.TabIndex = 38
        Me._lblDate_30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_27
        '
        Me._lblDate_27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_27.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_27.Location = New System.Drawing.Point(209, 103)
        Me._lblDate_27.Name = "_lblDate_27"
        Me._lblDate_27.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_27.TabIndex = 37
        Me._lblDate_27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_26
        '
        Me._lblDate_26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_26.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_26.Location = New System.Drawing.Point(176, 103)
        Me._lblDate_26.Name = "_lblDate_26"
        Me._lblDate_26.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_26.TabIndex = 36
        Me._lblDate_26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_25
        '
        Me._lblDate_25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_25.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_25.Location = New System.Drawing.Point(143, 103)
        Me._lblDate_25.Name = "_lblDate_25"
        Me._lblDate_25.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_25.TabIndex = 35
        Me._lblDate_25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_24
        '
        Me._lblDate_24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_24.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_24.Location = New System.Drawing.Point(110, 103)
        Me._lblDate_24.Name = "_lblDate_24"
        Me._lblDate_24.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_24.TabIndex = 34
        Me._lblDate_24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_23
        '
        Me._lblDate_23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_23.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_23.Location = New System.Drawing.Point(77, 103)
        Me._lblDate_23.Name = "_lblDate_23"
        Me._lblDate_23.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_23.TabIndex = 33
        Me._lblDate_23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_29
        '
        Me._lblDate_29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_29.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_29.Location = New System.Drawing.Point(44, 127)
        Me._lblDate_29.Name = "_lblDate_29"
        Me._lblDate_29.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_29.TabIndex = 32
        Me._lblDate_29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_22
        '
        Me._lblDate_22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_22.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_22.Location = New System.Drawing.Point(44, 103)
        Me._lblDate_22.Name = "_lblDate_22"
        Me._lblDate_22.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_22.TabIndex = 31
        Me._lblDate_22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_28
        '
        Me._lblDate_28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_28.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_28.Location = New System.Drawing.Point(11, 127)
        Me._lblDate_28.Name = "_lblDate_28"
        Me._lblDate_28.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_28.TabIndex = 24
        Me._lblDate_28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_21
        '
        Me._lblDate_21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_21.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_21.Location = New System.Drawing.Point(11, 103)
        Me._lblDate_21.Name = "_lblDate_21"
        Me._lblDate_21.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_21.TabIndex = 23
        Me._lblDate_21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_6
        '
        Me._lblDate_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_6.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_6.Location = New System.Drawing.Point(209, 33)
        Me._lblDate_6.Name = "_lblDate_6"
        Me._lblDate_6.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_6.TabIndex = 14
        Me._lblDate_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_5
        '
        Me._lblDate_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_5.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_5.Location = New System.Drawing.Point(176, 33)
        Me._lblDate_5.Name = "_lblDate_5"
        Me._lblDate_5.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_5.TabIndex = 13
        Me._lblDate_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_4
        '
        Me._lblDate_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_4.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_4.Location = New System.Drawing.Point(143, 33)
        Me._lblDate_4.Name = "_lblDate_4"
        Me._lblDate_4.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_4.TabIndex = 12
        Me._lblDate_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_3
        '
        Me._lblDate_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_3.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_3.Location = New System.Drawing.Point(110, 33)
        Me._lblDate_3.Name = "_lblDate_3"
        Me._lblDate_3.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_3.TabIndex = 11
        Me._lblDate_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_2
        '
        Me._lblDate_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_2.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_2.Location = New System.Drawing.Point(77, 33)
        Me._lblDate_2.Name = "_lblDate_2"
        Me._lblDate_2.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_2.TabIndex = 10
        Me._lblDate_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_1
        '
        Me._lblDate_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_1.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_1.Location = New System.Drawing.Point(44, 33)
        Me._lblDate_1.Name = "_lblDate_1"
        Me._lblDate_1.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_1.TabIndex = 9
        Me._lblDate_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate_0
        '
        Me._lblDate_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._lblDate_0.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate_0.Location = New System.Drawing.Point(11, 33)
        Me._lblDate_0.Name = "_lblDate_0"
        Me._lblDate_0.Size = New System.Drawing.Size(27, 17)
        Me._lblDate_0.TabIndex = 8
        Me._lblDate_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_24
        '
        Me._lblDate3_24.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_24.Location = New System.Drawing.Point(108, 101)
        Me._lblDate3_24.Name = "_lblDate3_24"
        Me._lblDate3_24.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_24.TabIndex = 51
        Me._lblDate3_24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_31
        '
        Me._lblDate3_31.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_31.Location = New System.Drawing.Point(108, 125)
        Me._lblDate3_31.Name = "_lblDate3_31"
        Me._lblDate3_31.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_31.TabIndex = 51
        Me._lblDate3_31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_38
        '
        Me._lblDate3_38.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_38.Location = New System.Drawing.Point(108, 148)
        Me._lblDate3_38.Name = "_lblDate3_38"
        Me._lblDate3_38.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_38.TabIndex = 51
        Me._lblDate3_38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_17
        '
        Me._lblDate3_17.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_17.Location = New System.Drawing.Point(108, 77)
        Me._lblDate3_17.Name = "_lblDate3_17"
        Me._lblDate3_17.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_17.TabIndex = 51
        Me._lblDate3_17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_27
        '
        Me._lblDate3_27.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_27.Location = New System.Drawing.Point(207, 101)
        Me._lblDate3_27.Name = "_lblDate3_27"
        Me._lblDate3_27.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_27.TabIndex = 53
        Me._lblDate3_27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_34
        '
        Me._lblDate3_34.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_34.Location = New System.Drawing.Point(207, 125)
        Me._lblDate3_34.Name = "_lblDate3_34"
        Me._lblDate3_34.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_34.TabIndex = 53
        Me._lblDate3_34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_41
        '
        Me._lblDate3_41.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_41.Location = New System.Drawing.Point(207, 148)
        Me._lblDate3_41.Name = "_lblDate3_41"
        Me._lblDate3_41.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_41.TabIndex = 53
        Me._lblDate3_41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_20
        '
        Me._lblDate3_20.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_20.Location = New System.Drawing.Point(207, 77)
        Me._lblDate3_20.Name = "_lblDate3_20"
        Me._lblDate3_20.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_20.TabIndex = 53
        Me._lblDate3_20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_13
        '
        Me._lblDate3_13.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_13.Location = New System.Drawing.Point(207, 53)
        Me._lblDate3_13.Name = "_lblDate3_13"
        Me._lblDate3_13.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_13.TabIndex = 53
        Me._lblDate3_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_26
        '
        Me._lblDate3_26.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_26.Location = New System.Drawing.Point(174, 101)
        Me._lblDate3_26.Name = "_lblDate3_26"
        Me._lblDate3_26.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_26.TabIndex = 53
        Me._lblDate3_26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_33
        '
        Me._lblDate3_33.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_33.Location = New System.Drawing.Point(174, 125)
        Me._lblDate3_33.Name = "_lblDate3_33"
        Me._lblDate3_33.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_33.TabIndex = 53
        Me._lblDate3_33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_40
        '
        Me._lblDate3_40.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_40.Location = New System.Drawing.Point(174, 148)
        Me._lblDate3_40.Name = "_lblDate3_40"
        Me._lblDate3_40.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_40.TabIndex = 53
        Me._lblDate3_40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_19
        '
        Me._lblDate3_19.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_19.Location = New System.Drawing.Point(174, 77)
        Me._lblDate3_19.Name = "_lblDate3_19"
        Me._lblDate3_19.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_19.TabIndex = 53
        Me._lblDate3_19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_12
        '
        Me._lblDate3_12.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_12.Location = New System.Drawing.Point(174, 53)
        Me._lblDate3_12.Name = "_lblDate3_12"
        Me._lblDate3_12.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_12.TabIndex = 53
        Me._lblDate3_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_25
        '
        Me._lblDate3_25.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_25.Location = New System.Drawing.Point(141, 101)
        Me._lblDate3_25.Name = "_lblDate3_25"
        Me._lblDate3_25.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_25.TabIndex = 53
        Me._lblDate3_25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_32
        '
        Me._lblDate3_32.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_32.Location = New System.Drawing.Point(141, 125)
        Me._lblDate3_32.Name = "_lblDate3_32"
        Me._lblDate3_32.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_32.TabIndex = 53
        Me._lblDate3_32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_39
        '
        Me._lblDate3_39.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_39.Location = New System.Drawing.Point(141, 148)
        Me._lblDate3_39.Name = "_lblDate3_39"
        Me._lblDate3_39.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_39.TabIndex = 53
        Me._lblDate3_39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_18
        '
        Me._lblDate3_18.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_18.Location = New System.Drawing.Point(141, 77)
        Me._lblDate3_18.Name = "_lblDate3_18"
        Me._lblDate3_18.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_18.TabIndex = 53
        Me._lblDate3_18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_11
        '
        Me._lblDate3_11.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_11.Location = New System.Drawing.Point(141, 53)
        Me._lblDate3_11.Name = "_lblDate3_11"
        Me._lblDate3_11.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_11.TabIndex = 53
        Me._lblDate3_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_10
        '
        Me._lblDate3_10.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_10.Location = New System.Drawing.Point(108, 53)
        Me._lblDate3_10.Name = "_lblDate3_10"
        Me._lblDate3_10.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_10.TabIndex = 53
        Me._lblDate3_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_23
        '
        Me._lblDate3_23.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_23.Location = New System.Drawing.Point(75, 101)
        Me._lblDate3_23.Name = "_lblDate3_23"
        Me._lblDate3_23.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_23.TabIndex = 53
        Me._lblDate3_23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_30
        '
        Me._lblDate3_30.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_30.Location = New System.Drawing.Point(75, 125)
        Me._lblDate3_30.Name = "_lblDate3_30"
        Me._lblDate3_30.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_30.TabIndex = 53
        Me._lblDate3_30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_37
        '
        Me._lblDate3_37.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_37.Location = New System.Drawing.Point(75, 148)
        Me._lblDate3_37.Name = "_lblDate3_37"
        Me._lblDate3_37.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_37.TabIndex = 53
        Me._lblDate3_37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_16
        '
        Me._lblDate3_16.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_16.Location = New System.Drawing.Point(75, 77)
        Me._lblDate3_16.Name = "_lblDate3_16"
        Me._lblDate3_16.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_16.TabIndex = 53
        Me._lblDate3_16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_9
        '
        Me._lblDate3_9.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_9.Location = New System.Drawing.Point(75, 53)
        Me._lblDate3_9.Name = "_lblDate3_9"
        Me._lblDate3_9.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_9.TabIndex = 53
        Me._lblDate3_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_22
        '
        Me._lblDate3_22.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_22.Location = New System.Drawing.Point(42, 101)
        Me._lblDate3_22.Name = "_lblDate3_22"
        Me._lblDate3_22.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_22.TabIndex = 52
        Me._lblDate3_22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_29
        '
        Me._lblDate3_29.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_29.Location = New System.Drawing.Point(42, 125)
        Me._lblDate3_29.Name = "_lblDate3_29"
        Me._lblDate3_29.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_29.TabIndex = 52
        Me._lblDate3_29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_36
        '
        Me._lblDate3_36.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_36.Location = New System.Drawing.Point(42, 148)
        Me._lblDate3_36.Name = "_lblDate3_36"
        Me._lblDate3_36.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_36.TabIndex = 52
        Me._lblDate3_36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_15
        '
        Me._lblDate3_15.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_15.Location = New System.Drawing.Point(42, 77)
        Me._lblDate3_15.Name = "_lblDate3_15"
        Me._lblDate3_15.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_15.TabIndex = 52
        Me._lblDate3_15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_8
        '
        Me._lblDate3_8.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_8.Location = New System.Drawing.Point(42, 53)
        Me._lblDate3_8.Name = "_lblDate3_8"
        Me._lblDate3_8.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_8.TabIndex = 52
        Me._lblDate3_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_6
        '
        Me._lblDate3_6.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_6.Location = New System.Drawing.Point(207, 30)
        Me._lblDate3_6.Name = "_lblDate3_6"
        Me._lblDate3_6.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_6.TabIndex = 53
        Me._lblDate3_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_5
        '
        Me._lblDate3_5.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_5.Location = New System.Drawing.Point(174, 30)
        Me._lblDate3_5.Name = "_lblDate3_5"
        Me._lblDate3_5.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_5.TabIndex = 53
        Me._lblDate3_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_4
        '
        Me._lblDate3_4.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_4.Location = New System.Drawing.Point(141, 30)
        Me._lblDate3_4.Name = "_lblDate3_4"
        Me._lblDate3_4.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_4.TabIndex = 53
        Me._lblDate3_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_3
        '
        Me._lblDate3_3.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_3.Location = New System.Drawing.Point(108, 30)
        Me._lblDate3_3.Name = "_lblDate3_3"
        Me._lblDate3_3.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_3.TabIndex = 53
        Me._lblDate3_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_2
        '
        Me._lblDate3_2.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_2.Location = New System.Drawing.Point(75, 30)
        Me._lblDate3_2.Name = "_lblDate3_2"
        Me._lblDate3_2.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_2.TabIndex = 53
        Me._lblDate3_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_1
        '
        Me._lblDate3_1.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_1.Location = New System.Drawing.Point(42, 30)
        Me._lblDate3_1.Name = "_lblDate3_1"
        Me._lblDate3_1.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_1.TabIndex = 52
        Me._lblDate3_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_21
        '
        Me._lblDate3_21.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_21.Location = New System.Drawing.Point(9, 101)
        Me._lblDate3_21.Name = "_lblDate3_21"
        Me._lblDate3_21.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_21.TabIndex = 50
        Me._lblDate3_21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_28
        '
        Me._lblDate3_28.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_28.Location = New System.Drawing.Point(9, 125)
        Me._lblDate3_28.Name = "_lblDate3_28"
        Me._lblDate3_28.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_28.TabIndex = 50
        Me._lblDate3_28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_35
        '
        Me._lblDate3_35.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_35.Location = New System.Drawing.Point(9, 148)
        Me._lblDate3_35.Name = "_lblDate3_35"
        Me._lblDate3_35.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_35.TabIndex = 50
        Me._lblDate3_35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_14
        '
        Me._lblDate3_14.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_14.Location = New System.Drawing.Point(9, 77)
        Me._lblDate3_14.Name = "_lblDate3_14"
        Me._lblDate3_14.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_14.TabIndex = 50
        Me._lblDate3_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_7
        '
        Me._lblDate3_7.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_7.Location = New System.Drawing.Point(9, 53)
        Me._lblDate3_7.Name = "_lblDate3_7"
        Me._lblDate3_7.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_7.TabIndex = 50
        Me._lblDate3_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblDate3_0
        '
        Me._lblDate3_0.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me._lblDate3_0.Location = New System.Drawing.Point(9, 30)
        Me._lblDate3_0.Name = "_lblDate3_0"
        Me._lblDate3_0.Size = New System.Drawing.Size(31, 22)
        Me._lblDate3_0.TabIndex = 50
        Me._lblDate3_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tvwKinmuDept
        '
        Me.tvwKinmuDept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwKinmuDept.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tvwKinmuDept.FullRowSelect = True
        Me.tvwKinmuDept.HideSelection = False
        Me.tvwKinmuDept.Location = New System.Drawing.Point(3, 3)
        Me.tvwKinmuDept.Name = "tvwKinmuDept"
        Me.tvwKinmuDept.Size = New System.Drawing.Size(180, 144)
        Me.tvwKinmuDept.TabIndex = 105
        Me.tvwKinmuDept.Visible = False
        '
        'lvwDeptStaff
        '
        Me.lvwDeptStaff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwDeptStaff.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lvwDeptStaff.FullRowSelect = True
        Me.lvwDeptStaff.GridLines = True
        Me.lvwDeptStaff.HideSelection = False
        Me.lvwDeptStaff.Location = New System.Drawing.Point(3, 3)
        Me.lvwDeptStaff.MultiSelect = False
        Me.lvwDeptStaff.Name = "lvwDeptStaff"
        Me.lvwDeptStaff.Size = New System.Drawing.Size(180, 223)
        Me.lvwDeptStaff.TabIndex = 17
        Me.lvwDeptStaff.UseCompatibleStateImageBehavior = False
        Me.lvwDeptStaff.Visible = False
        '
        'vseInformation
        '
        Me.vseInformation.BackColor = System.Drawing.SystemColors.Control
        Me.vseInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vseInformation.Controls.Add(Me.lvwInformation)
        Me.vseInformation.Location = New System.Drawing.Point(350, 145)
        Me.vseInformation.Name = "vseInformation"
        Me.vseInformation.Size = New System.Drawing.Size(924, 81)
        Me.vseInformation.TabIndex = 104
        '
        'lvwInformation
        '
        Me.lvwInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwInformation.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lvwInformation.FullRowSelect = True
        Me.lvwInformation.GridLines = True
        Me.lvwInformation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvwInformation.Location = New System.Drawing.Point(3, 5)
        Me.lvwInformation.MultiSelect = False
        Me.lvwInformation.Name = "lvwInformation"
        Me.lvwInformation.Size = New System.Drawing.Size(914, 72)
        Me.lvwInformation.TabIndex = 18
        Me.lvwInformation.UseCompatibleStateImageBehavior = False
        Me.lvwInformation.View = System.Windows.Forms.View.Details
        '
        'lvwMain
        '
        Me.lvwMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwMain.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lvwMain.FullRowSelect = True
        Me.lvwMain.HideSelection = False
        Me.lvwMain.Location = New System.Drawing.Point(544, 443)
        Me.lvwMain.MultiSelect = False
        Me.lvwMain.Name = "lvwMain"
        Me.lvwMain.Size = New System.Drawing.Size(55, 0)
        Me.lvwMain.TabIndex = 51
        Me.lvwMain.UseCompatibleStateImageBehavior = False
        Me.lvwMain.Visible = False
        '
        'vsePersonal
        '
        Me.vsePersonal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.vsePersonal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vsePersonal.Controls.Add(Me.sprMatrix)
        Me.vsePersonal.Controls.Add(Me.cmdPersonalTo)
        Me.vsePersonal.Controls.Add(Me.sprKinmuCnt)
        Me.vsePersonal.Controls.Add(Me.cmdPersonalFrom)
        Me.vsePersonal.Controls.Add(Me.Label2)
        Me.vsePersonal.Controls.Add(Me.sprTanka)
        Me.vsePersonal.Controls.Add(Me.cmbStatus)
        Me.vsePersonal.Controls.Add(Me.sprOverTime)
        Me.vsePersonal.Controls.Add(Me.imdFrom)
        Me.vsePersonal.Controls.Add(Me.imdTo)
        Me.vsePersonal.Location = New System.Drawing.Point(107, 416)
        Me.vsePersonal.Name = "vsePersonal"
        Me.vsePersonal.Size = New System.Drawing.Size(213, 101)
        Me.vsePersonal.TabIndex = 50
        Me.vsePersonal.Visible = False
        '
        'sprMatrix
        '
        Me.sprMatrix.AccessibleDescription = "sprMatrix, Sheet1, Row 0, Column 0, "
        Me.sprMatrix.AllowUserZoom = False
        Me.sprMatrix.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.sprMatrix.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprMatrix.FocusRenderer = DefaultFocusIndicatorRenderer1
        Me.sprMatrix.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sprMatrix.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.sprMatrix.HorizontalScrollBar.Name = ""
        Me.sprMatrix.HorizontalScrollBar.Renderer = DefaultScrollBarRenderer1
        Me.sprMatrix.HorizontalScrollBar.TabIndex = 2
        Me.sprMatrix.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprMatrix.Location = New System.Drawing.Point(129, 13)
        Me.sprMatrix.Name = "sprMatrix"
        NamedStyle1.Border = ComplexBorder1
        NamedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        NamedStyle1.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprMatrix.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle1})
        Me.sprMatrix.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprMatrix.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprMatrix_Sheet1})
        Me.sprMatrix.Size = New System.Drawing.Size(94, 48)
        Me.sprMatrix.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic
        Me.sprMatrix.TabIndex = 84
        Me.sprMatrix.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.sprMatrix.VerticalScrollBar.Name = ""
        Me.sprMatrix.VerticalScrollBar.Renderer = DefaultScrollBarRenderer2
        Me.sprMatrix.VerticalScrollBar.TabIndex = 3
        Me.sprMatrix.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprMatrix.VisualStyles = FarPoint.Win.VisualStyles.Off
        '
        'sprMatrix_Sheet1
        '
        Me.sprMatrix_Sheet1.Reset()
        Me.sprMatrix_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.sprMatrix_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.sprMatrix_Sheet1.ColumnFooter.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprMatrix_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprMatrix_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault"
        Me.sprMatrix_Sheet1.ColumnFooter.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprMatrix_Sheet1.ColumnFooterSheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprMatrix_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprMatrix_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault"
        Me.sprMatrix_Sheet1.ColumnFooterSheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprMatrix_Sheet1.ColumnHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprMatrix_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprMatrix_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.sprMatrix_Sheet1.ColumnHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprMatrix_Sheet1.FilterBar.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprMatrix_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprMatrix_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault"
        Me.sprMatrix_Sheet1.FilterBar.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprMatrix_Sheet1.FilterBarHeaderStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprMatrix_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprMatrix_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault"
        Me.sprMatrix_Sheet1.FilterBarHeaderStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprMatrix_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.[ReadOnly]
        Me.sprMatrix_Sheet1.RowHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprMatrix_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprMatrix_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault"
        Me.sprMatrix_Sheet1.RowHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprMatrix_Sheet1.SheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprMatrix_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprMatrix_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault"
        Me.sprMatrix_Sheet1.SheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprMatrix_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'cmdPersonalTo
        '
        Me.cmdPersonalTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdPersonalTo.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdPersonalTo.Location = New System.Drawing.Point(306, 11)
        Me.cmdPersonalTo.Name = "cmdPersonalTo"
        Me.cmdPersonalTo.Size = New System.Drawing.Size(25, 22)
        Me.cmdPersonalTo.TabIndex = 81
        Me.cmdPersonalTo.Text = "…"
        Me.cmdPersonalTo.UseVisualStyleBackColor = False
        '
        'sprKinmuCnt
        '
        Me.sprKinmuCnt.AccessibleDescription = "sprKinmuCnt, Sheet1, Row 0, Column 1, "
        Me.sprKinmuCnt.AllowUserZoom = False
        Me.sprKinmuCnt.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.sprKinmuCnt.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprKinmuCnt.FocusRenderer = DefaultFocusIndicatorRenderer1
        Me.sprKinmuCnt.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sprKinmuCnt.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.sprKinmuCnt.HorizontalScrollBar.Name = ""
        Me.sprKinmuCnt.HorizontalScrollBar.Renderer = DefaultScrollBarRenderer3
        Me.sprKinmuCnt.HorizontalScrollBar.TabIndex = 2
        Me.sprKinmuCnt.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprKinmuCnt.Location = New System.Drawing.Point(18, 13)
        Me.sprKinmuCnt.Name = "sprKinmuCnt"
        Me.sprKinmuCnt.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprKinmuCnt.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprKinmuCnt_Sheet1})
        Me.sprKinmuCnt.Size = New System.Drawing.Size(105, 57)
        Me.sprKinmuCnt.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic
        Me.sprKinmuCnt.TabIndex = 65
        Me.sprKinmuCnt.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.sprKinmuCnt.VerticalScrollBar.Name = ""
        Me.sprKinmuCnt.VerticalScrollBar.Renderer = DefaultScrollBarRenderer4
        Me.sprKinmuCnt.VerticalScrollBar.TabIndex = 3
        Me.sprKinmuCnt.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprKinmuCnt.VisualStyles = FarPoint.Win.VisualStyles.Off
        '
        'sprKinmuCnt_Sheet1
        '
        Me.sprKinmuCnt_Sheet1.Reset()
        Me.sprKinmuCnt_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.sprKinmuCnt_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.sprKinmuCnt_Sheet1.ActiveColumnIndex = 1
        Me.sprKinmuCnt_Sheet1.Cells.Get(0, 0).Font = New System.Drawing.Font("MS Gothic", 11.25!)
        Me.sprKinmuCnt_Sheet1.ColumnFooter.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprKinmuCnt_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprKinmuCnt_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault"
        Me.sprKinmuCnt_Sheet1.ColumnFooter.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprKinmuCnt_Sheet1.ColumnFooterSheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprKinmuCnt_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprKinmuCnt_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault"
        Me.sprKinmuCnt_Sheet1.ColumnFooterSheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprKinmuCnt_Sheet1.ColumnHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprKinmuCnt_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprKinmuCnt_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.sprKinmuCnt_Sheet1.ColumnHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprKinmuCnt_Sheet1.FilterBar.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprKinmuCnt_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprKinmuCnt_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault"
        Me.sprKinmuCnt_Sheet1.FilterBar.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprKinmuCnt_Sheet1.FilterBarHeaderStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprKinmuCnt_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprKinmuCnt_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault"
        Me.sprKinmuCnt_Sheet1.FilterBarHeaderStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprKinmuCnt_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.[ReadOnly]
        Me.sprKinmuCnt_Sheet1.RowHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprKinmuCnt_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprKinmuCnt_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault"
        Me.sprKinmuCnt_Sheet1.RowHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprKinmuCnt_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.None
        Me.sprKinmuCnt_Sheet1.SheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprKinmuCnt_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprKinmuCnt_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault"
        Me.sprKinmuCnt_Sheet1.SheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprKinmuCnt_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'cmdPersonalFrom
        '
        Me.cmdPersonalFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdPersonalFrom.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdPersonalFrom.Location = New System.Drawing.Point(122, 11)
        Me.cmdPersonalFrom.Name = "cmdPersonalFrom"
        Me.cmdPersonalFrom.Size = New System.Drawing.Size(25, 22)
        Me.cmdPersonalFrom.TabIndex = 80
        Me.cmdPersonalFrom.Text = "…"
        Me.cmdPersonalFrom.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(165, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "～"
        '
        'sprTanka
        '
        Me.sprTanka.AccessibleDescription = "sprTanka, Sheet1, Row 0, Column 0, "
        Me.sprTanka.AllowUserZoom = False
        Me.sprTanka.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.sprTanka.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprTanka.FocusRenderer = DefaultFocusIndicatorRenderer1
        Me.sprTanka.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sprTanka.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.sprTanka.HorizontalScrollBar.Name = ""
        Me.sprTanka.HorizontalScrollBar.Renderer = DefaultScrollBarRenderer5
        Me.sprTanka.HorizontalScrollBar.TabIndex = 2
        Me.sprTanka.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprTanka.Location = New System.Drawing.Point(17, 226)
        Me.sprTanka.Name = "sprTanka"
        Me.sprTanka.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprTanka.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprTanka_Sheet1})
        Me.sprTanka.Size = New System.Drawing.Size(104, 51)
        Me.sprTanka.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic
        Me.sprTanka.TabIndex = 95
        Me.sprTanka.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.sprTanka.VerticalScrollBar.Name = ""
        Me.sprTanka.VerticalScrollBar.Renderer = DefaultScrollBarRenderer6
        Me.sprTanka.VerticalScrollBar.TabIndex = 3
        Me.sprTanka.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprTanka.VisualStyles = FarPoint.Win.VisualStyles.Off
        '
        'sprTanka_Sheet1
        '
        Me.sprTanka_Sheet1.Reset()
        Me.sprTanka_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.sprTanka_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.sprTanka_Sheet1.ColumnFooter.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprTanka_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTanka_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault"
        Me.sprTanka_Sheet1.ColumnFooter.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprTanka_Sheet1.ColumnFooterSheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprTanka_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTanka_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault"
        Me.sprTanka_Sheet1.ColumnFooterSheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprTanka_Sheet1.ColumnHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprTanka_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTanka_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.sprTanka_Sheet1.ColumnHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprTanka_Sheet1.FilterBar.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprTanka_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTanka_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault"
        Me.sprTanka_Sheet1.FilterBar.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprTanka_Sheet1.FilterBarHeaderStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprTanka_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTanka_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault"
        Me.sprTanka_Sheet1.FilterBarHeaderStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprTanka_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.[ReadOnly]
        Me.sprTanka_Sheet1.RowHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprTanka_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTanka_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault"
        Me.sprTanka_Sheet1.RowHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprTanka_Sheet1.SheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprTanka_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprTanka_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault"
        Me.sprTanka_Sheet1.SheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprTanka_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(422, 10)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(338, 23)
        Me.cmbStatus.TabIndex = 3
        '
        'sprOverTime
        '
        Me.sprOverTime.AccessibleDescription = "sprOverTime, Sheet1, Row 0, Column 0, "
        Me.sprOverTime.AllowUserZoom = False
        Me.sprOverTime.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.sprOverTime.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprOverTime.FocusRenderer = DefaultFocusIndicatorRenderer1
        Me.sprOverTime.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sprOverTime.HorizontalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.sprOverTime.HorizontalScrollBar.Name = ""
        Me.sprOverTime.HorizontalScrollBar.Renderer = DefaultScrollBarRenderer7
        Me.sprOverTime.HorizontalScrollBar.TabIndex = 2
        Me.sprOverTime.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprOverTime.Location = New System.Drawing.Point(129, 286)
        Me.sprOverTime.Name = "sprOverTime"
        Me.sprOverTime.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprOverTime.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprOverTime_Sheet1})
        Me.sprOverTime.Size = New System.Drawing.Size(102, 48)
        Me.sprOverTime.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic
        Me.sprOverTime.TabIndex = 106
        Me.sprOverTime.VerticalScrollBar.Buttons = New FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton")
        Me.sprOverTime.VerticalScrollBar.Name = ""
        Me.sprOverTime.VerticalScrollBar.Renderer = DefaultScrollBarRenderer8
        Me.sprOverTime.VerticalScrollBar.TabIndex = 3
        Me.sprOverTime.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprOverTime.VisualStyles = FarPoint.Win.VisualStyles.Off
        '
        'sprOverTime_Sheet1
        '
        Me.sprOverTime_Sheet1.Reset()
        Me.sprOverTime_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.sprOverTime_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.sprOverTime_Sheet1.ColumnFooter.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprOverTime_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprOverTime_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault"
        Me.sprOverTime_Sheet1.ColumnFooter.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprOverTime_Sheet1.ColumnFooterSheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprOverTime_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprOverTime_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault"
        Me.sprOverTime_Sheet1.ColumnFooterSheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprOverTime_Sheet1.ColumnHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprOverTime_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprOverTime_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault"
        Me.sprOverTime_Sheet1.ColumnHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprOverTime_Sheet1.FilterBar.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprOverTime_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprOverTime_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault"
        Me.sprOverTime_Sheet1.FilterBar.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprOverTime_Sheet1.FilterBarHeaderStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprOverTime_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprOverTime_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault"
        Me.sprOverTime_Sheet1.FilterBarHeaderStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprOverTime_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.[ReadOnly]
        Me.sprOverTime_Sheet1.RowHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprOverTime_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprOverTime_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault"
        Me.sprOverTime_Sheet1.RowHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprOverTime_Sheet1.SheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        Me.sprOverTime_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red
        Me.sprOverTime_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault"
        Me.sprOverTime_Sheet1.SheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprOverTime_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'imdFrom
        '
        Me.imdFrom.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.imdFrom.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imdFrom.Format = "D"
        Me.imdFrom.HighlightText = True
        Me.imdFrom.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.imdFrom.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.imdFrom.Location = New System.Drawing.Point(27, 11)
        Me.imdFrom.Mask = "0000/00/00"
        Me.imdFrom.MaxDate = "21001231"
        Me.imdFrom.MinDate = "18680101"
        Me.imdFrom.Name = "imdFrom"
        Me.imdFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.imdFrom.Size = New System.Drawing.Size(120, 22)
        Me.imdFrom.TabIndex = 0
        '
        'imdTo
        '
        Me.imdTo.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.imdTo.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imdTo.Format = "D"
        Me.imdTo.HighlightText = True
        Me.imdTo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.imdTo.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.imdTo.Location = New System.Drawing.Point(211, 11)
        Me.imdTo.Mask = "0000/00/00"
        Me.imdTo.MaxDate = "21001231"
        Me.imdTo.MinDate = "18680101"
        Me.imdTo.Name = "imdTo"
        Me.imdTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.imdTo.Size = New System.Drawing.Size(120, 22)
        Me.imdTo.TabIndex = 2
        '
        'vstKinmuDept
        '
        Me.vstKinmuDept.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.vstKinmuDept.Controls.Add(Me.TabPage1)
        Me.vstKinmuDept.Controls.Add(Me.TabPage2)
        Me.vstKinmuDept.Controls.Add(Me.TabPage3)
        Me.vstKinmuDept.Controls.Add(Me.TabPage4)
        Me.vstKinmuDept.Controls.Add(Me.TabPage5)
        Me.vstKinmuDept.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.vstKinmuDept.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.vstKinmuDept.ItemSize = New System.Drawing.Size(96, 25)
        Me.vstKinmuDept.Location = New System.Drawing.Point(111, 742)
        Me.vstKinmuDept.Margin = New System.Windows.Forms.Padding(0)
        Me.vstKinmuDept.Name = "vstKinmuDept"
        Me.vstKinmuDept.SelectedIndex = 0
        Me.vstKinmuDept.Size = New System.Drawing.Size(194, 183)
        Me.vstKinmuDept.TabIndex = 49
        Me.vstKinmuDept.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tvwKinmuDept)
        Me.TabPage1.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(186, 150)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "勤務部署"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lvwDeptStaff)
        Me.TabPage2.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(186, 229)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "職員一覧"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(186, 229)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "配属部署"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(186, 229)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "役職"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabPage5.Location = New System.Drawing.Point(4, 29)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(186, 229)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "職種"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'vseDutyInfo
        '
        Me.vseDutyInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.vseDutyInfo.Controls.Add(Me.cmbSelectDuty)
        Me.vseDutyInfo.Controls.Add(Me.lblDutyDate)
        Me.vseDutyInfo.Location = New System.Drawing.Point(660, 496)
        Me.vseDutyInfo.Name = "vseDutyInfo"
        Me.vseDutyInfo.Size = New System.Drawing.Size(118, 150)
        Me.vseDutyInfo.TabIndex = 25
        Me.vseDutyInfo.Visible = False
        '
        'cmbSelectDuty
        '
        Me.cmbSelectDuty.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbSelectDuty.FormattingEnabled = True
        Me.cmbSelectDuty.Location = New System.Drawing.Point(247, 30)
        Me.cmbSelectDuty.Name = "cmbSelectDuty"
        Me.cmbSelectDuty.Size = New System.Drawing.Size(121, 23)
        Me.cmbSelectDuty.TabIndex = 43
        '
        'lblDutyDate
        '
        Me.lblDutyDate.AutoSize = True
        Me.lblDutyDate.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDutyDate.Location = New System.Drawing.Point(30, 33)
        Me.lblDutyDate.Name = "lblDutyDate"
        Me.lblDutyDate.Size = New System.Drawing.Size(71, 15)
        Me.lblDutyDate.TabIndex = 26
        Me.lblDutyDate.Text = "日当直用"
        '
        'vseDeptInfo
        '
        Me.vseDeptInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.vseDeptInfo.Controls.Add(Me.lblKinmuDate)
        Me.vseDeptInfo.Controls.Add(Me.lblDeptInfo)
        Me.vseDeptInfo.Location = New System.Drawing.Point(335, 662)
        Me.vseDeptInfo.Name = "vseDeptInfo"
        Me.vseDeptInfo.Size = New System.Drawing.Size(87, 82)
        Me.vseDeptInfo.TabIndex = 11
        Me.vseDeptInfo.Visible = False
        '
        'lblKinmuDate
        '
        Me.lblKinmuDate.AutoSize = True
        Me.lblKinmuDate.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKinmuDate.Location = New System.Drawing.Point(24, 68)
        Me.lblKinmuDate.Name = "lblKinmuDate"
        Me.lblKinmuDate.Size = New System.Drawing.Size(87, 15)
        Me.lblKinmuDate.TabIndex = 23
        Me.lblKinmuDate.Text = "勤務部署用"
        '
        'lblDeptInfo
        '
        Me.lblDeptInfo.AutoSize = True
        Me.lblDeptInfo.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDeptInfo.Location = New System.Drawing.Point(27, 30)
        Me.lblDeptInfo.Name = "lblDeptInfo"
        Me.lblDeptInfo.Size = New System.Drawing.Size(39, 15)
        Me.lblDeptInfo.TabIndex = 22
        Me.lblDeptInfo.Text = "0123"
        '
        'vseDakokuInfo
        '
        Me.vseDakokuInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.vseDakokuInfo.Controls.Add(Me.lblDakokuDate)
        Me.vseDakokuInfo.Location = New System.Drawing.Point(434, 662)
        Me.vseDakokuInfo.Name = "vseDakokuInfo"
        Me.vseDakokuInfo.Size = New System.Drawing.Size(67, 85)
        Me.vseDakokuInfo.TabIndex = 27
        Me.vseDakokuInfo.Visible = False
        '
        'lblDakokuDate
        '
        Me.lblDakokuDate.AutoSize = True
        Me.lblDakokuDate.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDakokuDate.Location = New System.Drawing.Point(27, 30)
        Me.lblDakokuDate.Name = "lblDakokuDate"
        Me.lblDakokuDate.Size = New System.Drawing.Size(71, 15)
        Me.lblDakokuDate.TabIndex = 28
        Me.lblDakokuDate.Text = "出退勤用"
        '
        'vseZaiin
        '
        Me.vseZaiin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.vseZaiin.Controls.Add(Me.lblKikan)
        Me.vseZaiin.Controls.Add(Me.lblKinmuBusyo)
        Me.vseZaiin.Controls.Add(Me.cboKikan)
        Me.vseZaiin.Controls.Add(Me.cboKinmuBusyo)
        Me.vseZaiin.Controls.Add(Me.lblZaiin)
        Me.vseZaiin.Location = New System.Drawing.Point(507, 662)
        Me.vseZaiin.Name = "vseZaiin"
        Me.vseZaiin.Size = New System.Drawing.Size(117, 85)
        Me.vseZaiin.TabIndex = 38
        Me.vseZaiin.Visible = False
        '
        'lblKikan
        '
        Me.lblKikan.AutoSize = True
        Me.lblKikan.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKikan.Location = New System.Drawing.Point(263, 50)
        Me.lblKikan.Name = "lblKikan"
        Me.lblKikan.Size = New System.Drawing.Size(55, 15)
        Me.lblKikan.TabIndex = 53
        Me.lblKikan.Text = "期間："
        '
        'lblKinmuBusyo
        '
        Me.lblKinmuBusyo.AutoSize = True
        Me.lblKinmuBusyo.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblKinmuBusyo.Location = New System.Drawing.Point(30, 50)
        Me.lblKinmuBusyo.Name = "lblKinmuBusyo"
        Me.lblKinmuBusyo.Size = New System.Drawing.Size(103, 15)
        Me.lblKinmuBusyo.TabIndex = 52
        Me.lblKinmuBusyo.Text = "勤務部署用："
        '
        'cboKikan
        '
        Me.cboKikan.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboKikan.FormattingEnabled = True
        Me.cboKikan.Location = New System.Drawing.Point(324, 47)
        Me.cboKikan.Name = "cboKikan"
        Me.cboKikan.Size = New System.Drawing.Size(121, 23)
        Me.cboKikan.TabIndex = 50
        '
        'cboKinmuBusyo
        '
        Me.cboKinmuBusyo.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cboKinmuBusyo.FormattingEnabled = True
        Me.cboKinmuBusyo.Location = New System.Drawing.Point(133, 50)
        Me.cboKinmuBusyo.Name = "cboKinmuBusyo"
        Me.cboKinmuBusyo.Size = New System.Drawing.Size(121, 23)
        Me.cboKinmuBusyo.TabIndex = 50
        '
        'lblZaiin
        '
        Me.lblZaiin.AutoSize = True
        Me.lblZaiin.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblZaiin.Location = New System.Drawing.Point(12, 16)
        Me.lblZaiin.Name = "lblZaiin"
        Me.lblZaiin.Size = New System.Drawing.Size(87, 15)
        Me.lblZaiin.TabIndex = 39
        Me.lblZaiin.Text = "在院照会用"
        '
        'vseLadderInfo
        '
        Me.vseLadderInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.vseLadderInfo.Controls.Add(Me.cmbLadderDept)
        Me.vseLadderInfo.Controls.Add(Me.cmbLadderDate)
        Me.vseLadderInfo.Controls.Add(Me.lblLadder)
        Me.vseLadderInfo.Location = New System.Drawing.Point(800, 511)
        Me.vseLadderInfo.Name = "vseLadderInfo"
        Me.vseLadderInfo.Size = New System.Drawing.Size(75, 124)
        Me.vseLadderInfo.TabIndex = 45
        Me.vseLadderInfo.Visible = False
        '
        'cmbLadderDept
        '
        Me.cmbLadderDept.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbLadderDept.FormattingEnabled = True
        Me.cmbLadderDept.Location = New System.Drawing.Point(313, 42)
        Me.cmbLadderDept.Name = "cmbLadderDept"
        Me.cmbLadderDept.Size = New System.Drawing.Size(121, 23)
        Me.cmbLadderDept.TabIndex = 49
        '
        'cmbLadderDate
        '
        Me.cmbLadderDate.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmbLadderDate.FormattingEnabled = True
        Me.cmbLadderDate.Location = New System.Drawing.Point(173, 42)
        Me.cmbLadderDate.Name = "cmbLadderDate"
        Me.cmbLadderDate.Size = New System.Drawing.Size(121, 23)
        Me.cmbLadderDate.TabIndex = 46
        '
        'lblLadder
        '
        Me.lblLadder.AutoSize = True
        Me.lblLadder.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLadder.Location = New System.Drawing.Point(27, 30)
        Me.lblLadder.Name = "lblLadder"
        Me.lblLadder.Size = New System.Drawing.Size(71, 15)
        Me.lblLadder.TabIndex = 48
        Me.lblLadder.Text = "未承認用"
        '
        'vseHaichi
        '
        Me.vseHaichi.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.vseHaichi.Controls.Add(Me.imtName2)
        Me.vseHaichi.Controls.Add(Me.imtName1)
        Me.vseHaichi.Controls.Add(Me.lblHaichi)
        Me.vseHaichi.Controls.Add(Me.sprSaiyoList)
        Me.vseHaichi.Controls.Add(Me.sprJosyuData)
        Me.vseHaichi.Controls.Add(Me.sprSum2)
        Me.vseHaichi.Controls.Add(Me.sprJobList)
        Me.vseHaichi.Controls.Add(Me.sprSum1)
        Me.vseHaichi.Controls.Add(Me.sprKangoshiData)
        Me.vseHaichi.Location = New System.Drawing.Point(644, 662)
        Me.vseHaichi.Name = "vseHaichi"
        Me.vseHaichi.Size = New System.Drawing.Size(120, 101)
        Me.vseHaichi.TabIndex = 85
        Me.vseHaichi.Visible = False
        '
        'imtName2
        '
        Me.imtName2.AutoSize = False
        Me.imtName2.BackColor = System.Drawing.SystemColors.Window
        Me.imtName2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.imtName2.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.imtName2.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imtName2.Format = ""
        Me.imtName2.HighlightText = False
        Me.imtName2.Location = New System.Drawing.Point(160, 221)
        Me.imtName2.MaxLength = 0
        Me.imtName2.MaxLengthUnit = ""
        Me.imtName2.Name = "imtName2"
        Me.imtName2.NumType = False
        Me.imtName2.ReadOnly = True
        Me.imtName2.Size = New System.Drawing.Size(75, 24)
        Me.imtName2.TabIndex = 94
        Me.imtName2.Text = "かんごし"
        '
        'imtName1
        '
        Me.imtName1.AutoSize = False
        Me.imtName1.BackColor = System.Drawing.SystemColors.Window
        Me.imtName1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.imtName1.EnabledBackColor = System.Drawing.SystemColors.Window
        Me.imtName1.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.imtName1.Format = ""
        Me.imtName1.HighlightText = False
        Me.imtName1.Location = New System.Drawing.Point(160, 184)
        Me.imtName1.MaxLength = 0
        Me.imtName1.MaxLengthUnit = ""
        Me.imtName1.Name = "imtName1"
        Me.imtName1.NumType = False
        Me.imtName1.ReadOnly = True
        Me.imtName1.Size = New System.Drawing.Size(75, 24)
        Me.imtName1.TabIndex = 93
        Me.imtName1.Text = "かんごし"
        '
        'lblHaichi
        '
        Me.lblHaichi.AutoSize = True
        Me.lblHaichi.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblHaichi.Location = New System.Drawing.Point(7, 10)
        Me.lblHaichi.Name = "lblHaichi"
        Me.lblHaichi.Size = New System.Drawing.Size(55, 15)
        Me.lblHaichi.TabIndex = 86
        Me.lblHaichi.Text = "配置用"
        '
        'sprSaiyoList
        '
        Me.sprSaiyoList.AccessibleDescription = "FpSpread1, Sheet1, Row 0, Column 0, "
        Me.sprSaiyoList.AllowUserZoom = False
        Me.sprSaiyoList.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.sprSaiyoList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sprSaiyoList.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprSaiyoList.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sprSaiyoList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprSaiyoList.Location = New System.Drawing.Point(177, 28)
        Me.sprSaiyoList.Name = "sprSaiyoList"
        NamedStyle2.Border = ComplexBorder2
        NamedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General
        NamedStyle2.NoteIndicatorColor = System.Drawing.Color.Red
        NamedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General
        Me.sprSaiyoList.NamedStyles.AddRange(New FarPoint.Win.Spread.NamedStyle() {NamedStyle2})
        Me.sprSaiyoList.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprSaiyoList.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprSaiyoList_Sheet1})
        Me.sprSaiyoList.Size = New System.Drawing.Size(94, 49)
        Me.sprSaiyoList.TabIndex = 88
        Me.sprSaiyoList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'sprSaiyoList_Sheet1
        '
        Me.sprSaiyoList_Sheet1.Reset()
        Me.sprSaiyoList_Sheet1.SheetName = "Sheet1"
        '
        'sprJosyuData
        '
        Me.sprJosyuData.AccessibleDescription = "FpSpread2, Sheet1, Row 0, Column 0, "
        Me.sprJosyuData.AllowUserZoom = False
        Me.sprJosyuData.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.sprJosyuData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sprJosyuData.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprJosyuData.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sprJosyuData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprJosyuData.Location = New System.Drawing.Point(25, 194)
        Me.sprJosyuData.Name = "sprJosyuData"
        Me.sprJosyuData.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprJosyuData.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprJosyuData_Sheet1})
        Me.sprJosyuData.Size = New System.Drawing.Size(104, 51)
        Me.sprJosyuData.TabIndex = 87
        Me.sprJosyuData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'sprJosyuData_Sheet1
        '
        Me.sprJosyuData_Sheet1.Reset()
        Me.sprJosyuData_Sheet1.SheetName = "Sheet1"
        '
        'sprSum2
        '
        Me.sprSum2.AccessibleDescription = "FpSpread3, Sheet1, Row 0, Column 0, "
        Me.sprSum2.AllowUserZoom = False
        Me.sprSum2.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.sprSum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sprSum2.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprSum2.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sprSum2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprSum2.Location = New System.Drawing.Point(28, 271)
        Me.sprSum2.Name = "sprSum2"
        Me.sprSum2.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprSum2.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprSum2_Sheet1})
        Me.sprSum2.Size = New System.Drawing.Size(102, 49)
        Me.sprSum2.TabIndex = 106
        Me.sprSum2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'sprSum2_Sheet1
        '
        Me.sprSum2_Sheet1.Reset()
        Me.sprSum2_Sheet1.SheetName = "Sheet1"
        '
        'sprJobList
        '
        Me.sprJobList.AccessibleDescription = "FpSpread4, Sheet1, Row 0, Column 0, "
        Me.sprJobList.AllowUserZoom = False
        Me.sprJobList.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.sprJobList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sprJobList.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprJobList.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sprJobList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprJobList.Location = New System.Drawing.Point(216, 111)
        Me.sprJobList.Name = "sprJobList"
        Me.sprJobList.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprJobList.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprJobList_Sheet1})
        Me.sprJobList.Size = New System.Drawing.Size(104, 51)
        Me.sprJobList.TabIndex = 91
        Me.sprJobList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'sprJobList_Sheet1
        '
        Me.sprJobList_Sheet1.Reset()
        Me.sprJobList_Sheet1.SheetName = "Sheet1"
        '
        'sprSum1
        '
        Me.sprSum1.AccessibleDescription = "FpSpread5, Sheet1, Row 0, Column 0, "
        Me.sprSum1.AllowUserZoom = False
        Me.sprSum1.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.sprSum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sprSum1.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprSum1.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sprSum1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprSum1.Location = New System.Drawing.Point(26, 125)
        Me.sprSum1.Name = "sprSum1"
        Me.sprSum1.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprSum1.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprSum1_Sheet1})
        Me.sprSum1.Size = New System.Drawing.Size(104, 49)
        Me.sprSum1.TabIndex = 90
        Me.sprSum1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'sprSum1_Sheet1
        '
        Me.sprSum1_Sheet1.Reset()
        Me.sprSum1_Sheet1.SheetName = "Sheet1"
        '
        'sprKangoshiData
        '
        Me.sprKangoshiData.AccessibleDescription = "FpSpread6, Sheet1, Row 0, Column 1, "
        Me.sprKangoshiData.AllowUserZoom = False
        Me.sprKangoshiData.BorderCollapse = FarPoint.Win.Spread.BorderCollapse.Collapse
        Me.sprKangoshiData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sprKangoshiData.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprKangoshiData.Font = New System.Drawing.Font("MS Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sprKangoshiData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        Me.sprKangoshiData.Location = New System.Drawing.Point(37, 49)
        Me.sprKangoshiData.Name = "sprKangoshiData"
        Me.sprKangoshiData.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never
        Me.sprKangoshiData.Sheets.AddRange(New FarPoint.Win.Spread.SheetView() {Me.sprKangoshiData_Sheet1})
        Me.sprKangoshiData.Size = New System.Drawing.Size(105, 57)
        Me.sprKangoshiData.TabIndex = 92
        Me.sprKangoshiData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        '
        'sprKangoshiData_Sheet1
        '
        Me.sprKangoshiData_Sheet1.Reset()
        Me.sprKangoshiData_Sheet1.SheetName = "Sheet1"
        'Formulas and custom names must be loaded with R1C1 reference style
        Me.sprKangoshiData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        Me.sprKangoshiData_Sheet1.ActiveColumnIndex = 1
        Me.sprKangoshiData_Sheet1.Cells.Get(0, 0).Font = New System.Drawing.Font("MS Gothic", 11.25!)
        Me.sprKangoshiData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1
        '
        'frmNSC0000HA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 882)
        Me.Controls.Add(Me.lblSearchHead)
        Me.Controls.Add(Me.vstKinmuDept)
        Me.Controls.Add(Me.tvwPersonal)
        Me.Controls.Add(Me.vseHaichi)
        Me.Controls.Add(Me.vsePersonal)
        Me.Controls.Add(Me.vseCover)
        Me.Controls.Add(Me.tvwDuty)
        Me.Controls.Add(Me.vseApproveInfo)
        Me.Controls.Add(Me.vseInformation)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.vseDutyInfo)
        Me.Controls.Add(Me.vseZaiin)
        Me.Controls.Add(Me.vseLadderInfo)
        Me.Controls.Add(Me.vseDakokuInfo)
        Me.Controls.Add(Me.vseDeptInfo)
        Me.Controls.Add(Me.vsePersonalData)
        Me.Controls.Add(Me.ToolStripContainer4)
        Me.Controls.Add(Me.vseCalendar)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.lblSearchData)
        Me.Controls.Add(Me.lblUserDept)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.lblUserID)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.picStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ToolStripContainer2)
        Me.Controls.Add(Me.lvwDeptInfo)
        Me.Controls.Add(Me.lvwMain)
        Me.Location = New System.Drawing.Point(-4, -4)
        Me.MainMenuStrip = Me.stbMenuMain
        Me.MinimumSize = New System.Drawing.Size(400, 430)
        Me.Name = "frmNSC0000HA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNSC0000HA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.picStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStripContainer4.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer4.ResumeLayout(False)
        Me.ToolStripContainer4.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStripContainer2.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer2.ResumeLayout(False)
        Me.ToolStripContainer2.PerformLayout()
        Me.vseMain.ResumeLayout(False)
        Me.vseMain.PerformLayout()
        Me.vseApproveInfo.ResumeLayout(False)
        Me.vseApproveInfo.PerformLayout()
        Me.vsePersonalData.ResumeLayout(False)
        Me.vsePersonalData.PerformLayout()
        Me.vseCover.ResumeLayout(False)
        Me.fraDataGet.ResumeLayout(False)
        Me.fraDataGet.PerformLayout()
        Me.vseCalendar.ResumeLayout(False)
        Me.vseCalendar.PerformLayout()
        Me.PnlCalendar.ResumeLayout(False)
        Me.vseInformation.ResumeLayout(False)
        Me.vsePersonal.ResumeLayout(False)
        Me.vsePersonal.PerformLayout()
        CType(Me.sprMatrix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprMatrix_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprKinmuCnt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprKinmuCnt_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprTanka, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprTanka_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprOverTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprOverTime_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vstKinmuDept.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.vseDutyInfo.ResumeLayout(False)
        Me.vseDutyInfo.PerformLayout()
        Me.vseDeptInfo.ResumeLayout(False)
        Me.vseDeptInfo.PerformLayout()
        Me.vseDakokuInfo.ResumeLayout(False)
        Me.vseDakokuInfo.PerformLayout()
        Me.vseZaiin.ResumeLayout(False)
        Me.vseZaiin.PerformLayout()
        Me.vseLadderInfo.ResumeLayout(False)
        Me.vseLadderInfo.PerformLayout()
        Me.vseHaichi.ResumeLayout(False)
        Me.vseHaichi.PerformLayout()
        CType(Me.sprSaiyoList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprSaiyoList_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprJosyuData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprJosyuData_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprSum2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprSum2_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprJobList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprJobList_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprSum1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprSum1_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprKangoshiData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprKangoshiData_Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSearchData As System.Windows.Forms.Label
    Friend WithEvents lblSearchHead As System.Windows.Forms.Label
    Friend WithEvents lblUserDept As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents picStatus As System.Windows.Forms.PictureBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbrMenu As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ContentMenuMain As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFileEnd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuHelpVersion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents albMenu As MenuToolStrip.MenuToolStrip
    Friend WithEvents ToolStripContainer4 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripContainer2 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents stbMenuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents imlSmallIcon As System.Windows.Forms.ImageList
    Friend WithEvents imlToolStrip As System.Windows.Forms.ImageList
    Friend WithEvents lvwDeptInfo As System.Windows.Forms.ListView
    Friend WithEvents tvwDuty As System.Windows.Forms.TreeView
    Friend WithEvents tvwPersonal As System.Windows.Forms.TreeView
    Friend WithEvents vseApproveInfo As System.Windows.Forms.Panel
    Friend WithEvents vsePersonalData As System.Windows.Forms.Panel
    Friend WithEvents cmbSelectAppl As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPersonalAppli As System.Windows.Forms.ComboBox
    Friend WithEvents vseCover As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents sspProc As System.Windows.Forms.Panel
    Friend WithEvents fraDataGet As System.Windows.Forms.Panel
    Friend WithEvents cmdSelMonth As System.Windows.Forms.Button
    Friend WithEvents vseCalendar As System.Windows.Forms.Panel
    Friend WithEvents vsePersonal As System.Windows.Forms.Panel
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents sprMatrix As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprKinmuCnt As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprMatrix_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents sprKinmuCnt_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents sprTanka As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprTanka_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents sprOverTime As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprOverTime_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents lvwMain As System.Windows.Forms.ListView
    Friend WithEvents lvwDeptStaff As System.Windows.Forms.ListView
    Friend WithEvents vseInformation As System.Windows.Forms.Panel
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents vseMain As System.Windows.Forms.Panel
    Friend WithEvents tvwKinmuDept As System.Windows.Forms.TreeView
    Friend WithEvents vstKinmuDept As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents PnlCalendar As System.Windows.Forms.Panel
    Friend WithEvents _lblDate_41 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_40 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_39 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_38 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_37 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_36 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_35 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_34 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_33 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_32 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_31 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_30 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_27 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_26 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_25 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_24 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_23 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_29 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_22 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_20 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_19 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_18 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_17 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_16 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_15 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_28 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_21 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_14 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_13 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_12 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_11 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_10 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_9 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_8 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_7 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_6 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_5 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_4 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_3 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_2 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_1 As System.Windows.Forms.Label
    Friend WithEvents _lblDate_0 As System.Windows.Forms.Label
    Friend WithEvents _lblDate2_6 As System.Windows.Forms.Label
    Friend WithEvents _lblDate2_5 As System.Windows.Forms.Label
    Friend WithEvents _lblDate2_4 As System.Windows.Forms.Label
    Friend WithEvents _lblDate2_3 As System.Windows.Forms.Label
    Friend WithEvents _lblDate2_2 As System.Windows.Forms.Label
    Friend WithEvents _lblDate2_1 As System.Windows.Forms.Label
    Friend WithEvents _lblDate2_0 As System.Windows.Forms.Label
    Friend WithEvents cmdAllCheck As System.Windows.Forms.Button
    Friend WithEvents cmdAllClear As System.Windows.Forms.Button
    Friend WithEvents cmdChgDate_0 As System.Windows.Forms.Button
    Friend WithEvents cmdChgDate_1 As System.Windows.Forms.Button
    Friend WithEvents cmdSelDate As System.Windows.Forms.Button
    Friend WithEvents cmdKinmuti As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents vseDutyInfo As System.Windows.Forms.Panel
    Friend WithEvents cmbSelectDuty As System.Windows.Forms.ComboBox
    Friend WithEvents vseDeptInfo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblKinmuDate As System.Windows.Forms.Label
    Friend WithEvents lblDeptInfo As System.Windows.Forms.Label
    Friend WithEvents vseDakokuInfo As System.Windows.Forms.Panel
    Friend WithEvents lblDakokuDate As System.Windows.Forms.Label
    Friend WithEvents vseZaiin As System.Windows.Forms.Panel
    Friend WithEvents lblZaiin As System.Windows.Forms.Label
    Friend WithEvents lblKinmuBusyo As System.Windows.Forms.Label
    Friend WithEvents lblDutyDate As System.Windows.Forms.Label
    Friend WithEvents lblKikan As System.Windows.Forms.Label
    Friend WithEvents cboKikan As System.Windows.Forms.ComboBox
    Friend WithEvents cboKinmuBusyo As System.Windows.Forms.ComboBox
    Friend WithEvents lblApproveDate As System.Windows.Forms.Label
    Friend WithEvents vseLadderInfo As System.Windows.Forms.Panel
    Friend WithEvents cmbLadderDept As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLadderDate As System.Windows.Forms.ComboBox
    Friend WithEvents lblLadder As System.Windows.Forms.Label
    Friend WithEvents lblItem_1 As System.Windows.Forms.Label
    Friend WithEvents lblItem_0 As System.Windows.Forms.Label
    Friend WithEvents lblKinmuti As System.Windows.Forms.Label
    Friend WithEvents cmdSelectTime As System.Windows.Forms.Button
    Friend WithEvents cmdPersonalTo As System.Windows.Forms.Button
    Friend WithEvents cmdPersonalFrom As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdPersonalDataCalFrom As System.Windows.Forms.Button
    Friend WithEvents cmdPersonalDataCalTo As System.Windows.Forms.Button
    Friend WithEvents cmdApproveInfoCalTo As System.Windows.Forms.Button
    Friend WithEvents cmdApproveInfoCalFrom As System.Windows.Forms.Button
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents menuFileDateChange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFilePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuFileLogOff As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents vseHaichi As System.Windows.Forms.Panel
    Friend WithEvents lblHaichi As System.Windows.Forms.Label
    Friend WithEvents sprSaiyoList As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprSaiyoList_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents sprJosyuData As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprJosyuData_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents sprSum2 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprSum2_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents sprJobList As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprJobList_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents sprSum1 As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprSum1_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents sprKangoshiData As FarPoint.Win.Spread.FpSpread
    Friend WithEvents sprKangoshiData_Sheet1 As FarPoint.Win.Spread.SheetView
    Friend WithEvents imtSelectTime As CustomText.NiszMaskedText
    Friend WithEvents imdFrom As CustomText.NiszMaskedText
    Friend WithEvents imdTo As CustomText.NiszMaskedText
    Friend WithEvents imdSearchTo As CustomText.NiszMaskedText
    Friend WithEvents imdSearchFrom As CustomText.NiszMaskedText
    Friend WithEvents imtName1 As CustomText.NiszText
    Friend WithEvents imtName2 As CustomText.NiszText
    Friend WithEvents _lblDate3_0 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_1 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_17 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_6 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_5 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_4 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_3 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_2 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_24 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_31 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_38 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_27 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_34 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_41 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_20 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_13 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_26 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_33 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_40 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_19 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_12 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_25 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_32 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_39 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_18 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_11 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_10 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_23 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_30 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_37 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_16 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_9 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_22 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_29 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_36 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_15 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_8 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_21 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_28 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_35 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_14 As System.Windows.Forms.Label
    Friend WithEvents _lblDate3_7 As System.Windows.Forms.Label
    Private WithEvents imdAppliTo As System.Windows.Forms.Label
    Private WithEvents imdAppliFrom As System.Windows.Forms.Label
    Public WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lvwInformation As System.Windows.Forms.ListView

End Class
