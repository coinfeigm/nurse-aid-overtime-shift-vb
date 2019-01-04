Option Strict Off
Option Explicit On
Imports System.Collections.Generic
Friend Class frmNSW0060HA
    Inherits General.FormBase
    '�X�V���� **********************************************************************************
    '2005/06/20 ���΃f�[�^�̓��t����
    '[0�F�P�����Γ�-�v��N�����A1�F�P�����Γ�-�v�㒴�Γ��A2�F�P���N����-�v��N����] (001)
    '2012/06/07 �@�蒴�ߋΖ����ԗ�̒ǉ�
    '*******************************************************************************************
    '**** ���گ�ފ֘A�̒萔 ****

    '2018-08-15 Darren UPDATE START
    '���گ�ނ̗�
    'Private Const M_Spr_TyokinMaxCol As Integer = 16 '���Ζ��ו\�����گ�ނ̍ő��
    Private Const M_Spr_TyokinMaxCol As Integer = 18 '���Ζ��ו\�����گ�ނ̍ő��
    '2018-08-15 Darren UPDATE END

    '���Ζ��חp���گ�ޗ񍀖�
    Private Const M_Spr_TyokinNo As Integer = 0 '��
    Private Const M_Spr_TyokinNameCol As Integer = 1 '����
    Private Const M_Spr_BraekCol1 As Integer = 2 '��؂��
    Private Const M_Spr_FirstTanka As Integer = 3 '1�߂̒P��(100/100)
    Private Const M_Spr_SecondTanka As Integer = 4 '2�߂̒P��(125/100)
    Private Const M_Spr_ThirdTanka As Integer = 5 '3�߂̒P��(135/100)
    Private Const M_Spr_FourTanka As Integer = 6 '4�߂̒P��(150/100)
    Private Const M_Spr_FiveTanka As Integer = 7 '5�߂̒P��(160/100)
    Private Const M_Spr_SixTanka As Integer = 8 '6�ڂ̒P��(150/100)
    Private Const M_Spr_SevenTanka As Integer = 9 '7�ڂ̒P��(170/100)
    Private Const M_Spr_TotalBraekCol As Integer = 10 '�e�P���ƍ��v�̋�؂��
    Private Const M_Spr_TotalTanka As Integer = 11 '�P�����v
    Private Const M_Spr_BraekCol2 As Integer = 12 '��؂��
    Private Const M_Spr_NightTanka As Integer = 13 '��Ԏ���(25/100)
    Private Const M_Spr_BraekCol3 As Integer = 14 '��؂��
    '2018-08-15 Darren UPDATE START
    'Private Const M_Spr_HolidayTanka As Integer = 15 '�x������(135/100)
    Private Const M_Spr_HolidayTanka As Integer = 17 '�x������(135/100)
    '2018-08-15 Darren UPDATE END
    '2018-08-15 Darren ADD START
    Private Const M_Spr_BraekCol4 As Integer = 16 '��؂��
    Private Const M_Spr_25 As Integer = 15
    '2018-08-15 Darren ADD START

    '���گ�ނ̍s�̍���
    Private Const M_Spr_RowHeight As Double = 21

    '���گ�ނɕ\���\�ȐE����(��۰ق��Ȃ��ŕ\���ł���ő�l��)
    Private Const M_Spr_NoScrollStaffCnt As Integer = 23

    '���گ�ނ̐F
    'UPGRADE_NOTE: M_Spr_ErrRow_Color �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
    Private M_Spr_ErrRow_Color As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red) '�װ���������Ă���F
    'Private Const M_Spr_GrayArea_Color As Integer = &H8000000F '��Ă��Ȃ��G���A�̐F
    Private Const M_Spr_RowColor1 As Integer = 8454016 '�E�����ް��s�̐F(1��2�͌��݂ɕ\��)
    'UPGRADE_NOTE: M_Spr_RowColor2 �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
    Private M_Spr_RowColor2 As Integer = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White) '�E�����ް��s�̐F

    '*** Ӽޭ�����ٕϐ� ***
    Private m_HospitalCD As String
    Private m_KangoTCD As String
    Private m_KangoTName As String '�Ō�P�ʖ���
    Private m_UserID As String
    Private m_SelDate As Integer '(YYYYMMDD)
    Private m_LoadOK_Flg As Boolean
    Private m_SelectFrom As Integer '�Ώی��̎n�܂�(�\�������Q�Ƃ��Ď擾)
    Private m_SelectTo As Integer '�Ώی��̏I���(�\�������Q�Ƃ��Ď擾)

    Private m_lngTotal100 As Integer
    Private m_lngTotal125 As Integer
    Private m_lngTotal135 As Integer
    Private m_lngTotal150 As Integer
    Private m_lngTotal160 As Integer
    Private m_lngTankaTotal As Integer
    Private m_lngYakanTotal As Integer
    Private m_lngKyujituTotal As Integer

    Private m_lngTotal150_2 As Integer
    Private m_lngTotal175 As Integer
    '2018-08-15 Darren ADD START
    Private m_lngTotal25 As Integer
    '2018-08-15 Darren ADD END

    Private m_lstLblTanka As List(Of Object) = New List(Of Object)  '�R���g���[���z��i���v�P�����x���j
    Private m_lstLblTitle As List(Of Object) = New List(Of Object)  '�R���g���[���z��i�^�C�g�����x���j
    Private m_lstPicTotal As List(Of Object) = New List(Of Object)  '�R���g���[���z��i���v�p�l���j

    Private Structure Cyokin_Type
        Dim EndDay As String
        Dim HalfChk As String
        Dim MonthChk As String
    End Structure
    Private m_Cyokin As Cyokin_Type

    '-------------------------
    '   �E�����/��p �\����
    '-------------------------
    Private Structure IdoHistory_Type
        Dim lngStartDate As Integer
        Dim lngEndDate As Integer
        Dim strCD As String
        Dim strName As String
    End Structure

    '�E����� �i�[�\����
    Private Structure StaffData_type
        Dim strStaffMngNo As String '�E���Ǘ��ԍ�
        Dim strStaffNo As String '�E���ԍ�
        Dim strStaffName As String '�E����
        Dim IdoHistory() As IdoHistory_Type '�ٓ���
        Dim SaiyoHistory() As IdoHistory_Type '�̗p��
        Dim lng125 As Integer '125/100
        Dim lng135 As Integer '135/100
        Dim lng150 As Integer '150/100
        Dim lng160 As Integer '160/100
        Dim lng100 As Integer '125/100
        Dim lngKyujitu As Integer '135/100
        Dim lngYakan As Integer '25/100
        Dim lngTotal As Integer '�l���v
        Dim lngBeforeHalf As Integer '�O�����v
        Dim lngAfterHalf As Integer '�㔼���v

        Dim lng150_2 As Integer '150/100
        Dim lng175 As Integer '170/100
        '2018-08-15 Darren ADD START
        Dim lng25 As Integer '25/100
        '2018-08-15 Darren ADD END

    End Structure
    Private m_StaffData() As StaffData_type

    Private m_objComChokin As NsAid_NSW0300C.clsGetOverData '���΃f�[�^�擾�p�I�u�W�F�N�g

    '���ڐݒ�
    Private m_lngDefSelect As Integer '�f�t�H���g��
    Private m_lngKikanFlg As Integer '���Ԑݒ�

    '1�����E�������v�`�F�b�N(TotalCheck)
    Private Sub TotalCheck()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HA TotalCheck"

            Dim w_ChkTime_Half As String
            Dim w_ChkTime_Month As String
            Dim w_ChkIntTime As Short
            Dim w_MsgText As String
            Dim w_Date As Date
            Dim w_i As Short
            Dim w_BeforeChkFlg As Boolean
            Dim w_AfterChkFlg As Boolean
            Dim w_MonthChkFlg As Boolean
            Dim w_MonthTotal As Integer
            Dim w_strMsg() As String
            Dim w_MsgResult As MsgBoxResult

            w_BeforeChkFlg = False
            w_AfterChkFlg = False
            w_MonthChkFlg = False

            '**** �����ł����� ****
            w_ChkTime_Half = m_Cyokin.HalfChk
            If IsNumeric(w_ChkTime_Half) = False Then
                '���l�Ƃ��Ĕ��f�ł��Ȃ��̂������Ȃ�
                w_ChkTime_Half = "0"
            End If
            '**** 1�����ł����� ****
            w_ChkTime_Month = m_Cyokin.MonthChk
            If IsNumeric(w_ChkTime_Month) = False Then
                '���l�Ƃ��Ĕ��f�ł��Ȃ��̂������Ȃ�
                w_ChkTime_Month = "0"
            End If

            If w_ChkTime_Half <> "0" OrElse w_ChkTime_Month <> "0" Then
                '�`�F�b�N����

                '�E��������Loop
                For w_i = 1 To UBound(m_StaffData)

                    '*** �����`�F�b�N ***
                    If w_ChkTime_Half <> "0" Then
                        '��������̏ꍇ
                        w_ChkIntTime = CShort(w_ChkTime_Half)
                        '�O����1���`15��������
                        If m_StaffData(w_i).lngBeforeHalf > w_ChkIntTime AndAlso w_BeforeChkFlg = False Then
                            '�G���[
                            w_BeforeChkFlg = True
                        End If
                        '�㔼��16���`����������
                        If m_StaffData(w_i).lngAfterHalf > w_ChkIntTime AndAlso w_AfterChkFlg = False Then
                            '�G���[
                            w_AfterChkFlg = True
                        End If
                    End If

                    '*** 1�����ł����� ***
                    If w_ChkTime_Month <> "0" Then
                        '��������̏ꍇ
                        w_ChkIntTime = CShort(w_ChkTime_Month)
                        '1�������v�𕪒P�ʂɕϊ�
                        w_MonthTotal = ((fncChangeTime(m_StaffData(w_i).lngTotal) \ 100) * 60) + (fncChangeTime(m_StaffData(w_i).lngTotal) Mod 100)
                        If w_MonthTotal > Integer.Parse(w_ChkIntTime) AndAlso w_MonthChkFlg = False Then
                            '�װ
                            w_MonthChkFlg = True
                        End If
                    End If

                Next w_i

                '**** �����G���[�̏ꍇ ****
                If w_BeforeChkFlg = True Then
                    '�����ŃG���[���������ꍇ
                    w_Date = General.paGetDateFromDateInteger(m_SelectFrom)
                    w_MsgText = w_Date.Day.ToString & "���`"
                    w_MsgText = w_MsgText & w_Date.AddDays(14).Day.ToString & "��"
                    w_MsgText = w_MsgText & "�̎��ԊO�Ζ��̗݌v����"
                    '*******ү����***********************************
                    ReDim w_strMsg(1)
                    w_strMsg(1) = w_MsgText
                    w_MsgResult = General.paMsgDsp("NS0279", w_strMsg)
                    '************************************************
                    Exit Sub
                End If
                If w_AfterChkFlg = True Then
                    w_Date = General.paGetDateFromDateInteger(m_SelectFrom)
                    w_MsgText = w_Date.AddDays(15).Day.ToString & "���`"
                    w_MsgText = w_MsgText & General.paGetDateFromDateInteger(m_SelectTo).Day.ToString & "��"
                    w_MsgText = w_MsgText & "�̎��ԊO�Ζ��̗݌v����"
                    '*******ү����***********************************
                    ReDim w_strMsg(1)
                    w_strMsg(1) = w_MsgText
                    w_MsgResult = General.paMsgDsp("NS0279", w_strMsg)
                    '************************************************
                End If

                '**** 1�����G���[�̏ꍇ ****
                If w_MonthChkFlg = True Then
                    w_MsgText = "�ꃖ��"
                    w_MsgText = w_MsgText & "�̎��ԊO�Ζ��̗݌v����"
                    '*******ү����***********************************
                    ReDim w_strMsg(1)
                    w_strMsg(1) = w_MsgText
                    w_MsgResult = General.paMsgDsp("NS0279", w_strMsg)
                    '************************************************
                    Exit Sub
                End If

            End If

            General.g_ErrorProc = w_PreErrorProc

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public WriteOnly Property pSetHospital(ByVal p_User As String) As String
        Set(ByVal Value As String)

            m_UserID = p_User
            m_HospitalCD = Value

        End Set
    End Property


    Public WriteOnly Property pSetKangoT(ByVal p_Name As String) As String
        Set(ByVal Value As String)

            m_KangoTName = p_Name
            m_KangoTCD = Value

        End Set
    End Property

    Public WriteOnly Property pSelDate() As Integer
        Set(ByVal Value As Integer)

            m_SelDate = Value

        End Set
    End Property

    Private Sub Get_FromTo()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
            General.g_ErrorProc = "clsNSW0060HA Get_FromTo"


            Dim w_Date1 As Date
            Dim w_Date2 As Date
            Dim w_TempDate As Date
            Dim w_EndDay As String
            Dim w_blnDBFlg As Boolean

            w_blnDBFlg = False

            w_EndDay = m_Cyokin.EndDay
            If IsNumeric(w_EndDay) = False Then
                '���t�Ƃ��Ĕ��f�ł��Ȃ��̂Ō������߂Ƃ���
                w_EndDay = "0"
            End If

            If CShort(w_EndDay) <= 0 OrElse 31 < CShort(w_EndDay) Then
                '���t�Ƃ��Ĕ��f�ł��Ȃ��̂Ō������߂Ƃ���
                w_Date1 = General.paGetDateFromDateInteger(Integer.Parse(m_SelDate.ToString & "01"))
                w_TempDate = w_Date1.AddMonths(1)
                w_Date2 = w_TempDate.AddDays(-1)
            End If

            m_SelectFrom = General.paGetDateIntegerFromDate(w_Date1)
            m_SelectTo = General.paGetDateIntegerFromDate(w_Date2)

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdEnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEnd.Click

        Me.Close()

    End Sub

    Private Sub frmNSW0060HA_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        General.g_ErrorProc = "clsNSW0060HA Form_Load"

        Dim w_str As String
        Dim w_strMsg() As String

        Try

            '�ُ�l�Z�b�g

            m_LoadOK_Flg = False

            subSetControlsList()

            '���i���ް��ް���޼ު�Ăƕa�@CD���
            General.g_objGetData.p�a�@CD = m_HospitalCD

            Cursor.Current = Cursors.WaitCursor

            '���ڐݒ�擾
            Call subGetSettei()

            '�Ώی���FromTo�擾
            Call Get_FromTo()

            '�ΏېE���擾
            If GetStaff() = False Then
                '�Ώ��ް��Ȃ�
                ReDim w_strMsg(1)
                w_strMsg(1) = "�o�͑Ώۂ̐E��"
                Call General.paMsgDsp("NS0008", w_strMsg)
                Cursor.Current = Cursors.Default
                Me.Close()
                Exit Sub
            End If

            '�P���擾
            If GetOverKinmuData() = False Then
                '�Ώ��ް��Ȃ�
                Cursor.Current = Cursors.Default
                Me.Close()
                Exit Sub
            End If

            '���v�v�Z
            Call subAllTotalTime()

            '�I��N��
            w_str = Mid(Convert.ToString(m_SelDate), 1, 4) & "�N" & String.Format("{0,2}", Integer.Parse(Mid(Convert.ToString(m_SelDate), 5, 2))) & "���x"
            lblDate.Text = w_str
            '�Ō�P�ʖ���
            lblKangoName.Text = m_KangoTName
            '�e�P���̖���
            m_lstLblTitle(12).Text = "100/100"
            m_lstLblTitle(3).Text = "125/100"
            m_lstLblTitle(4).Text = "135/100"
            m_lstLblTitle(5).Text = "150/100"
            m_lstLblTitle(6).Text = "160/100"

            m_lstLblTitle(13).Text = "150/100"
            m_lstLblTitle(14).Text = "175/100"

            '���گ�޼�Ă̐ݒ�
            Call Set_SpreadSheet()

            '���گ�ނ��ް���\��
            Call Disp_StaffData()

            '��ʂ̒����\��
            Call General.paDspCenter(Me)

            Cursor.Current = Cursors.Default

            m_LoadOK_Flg = True

        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Call General.paDllTrpMsg(Str(Err.Number), General.g_ErrorProc)
        End Try
    End Sub

    Private Sub Set_SpreadSheet()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HA Set_SpreadSheet"

            Dim w_TotalRows As Integer
            Dim w_Spred_Height As Double
            Dim w_styleCell As FarPoint.Win.Spread.StyleInfo
            Dim w_tcell As New FarPoint.Win.Spread.CellType.TextCellType()

            sprMain.ResumeLayout()

            '���Ζ��׽��گ�޼�Ă̐ݒ�
            With sprMain_Sheet1

                '�ő�񐔐ݒ�
                .ColumnCount = M_Spr_TyokinMaxCol
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ����(�E����+1)��MaxRow�ɂ���
                    .RowCount = UBound(m_StaffData) + 1
                    w_TotalRows = UBound(m_StaffData)
                Else
                    .RowCount = UBound(m_StaffData)
                    w_TotalRows = 0
                End If

                Dim w_intAllColWidth As Integer = 0
                For Each w_col As FarPoint.Win.Spread.Column In .Columns
                    w_intAllColWidth += w_col.Width
                Next

                '��۰��ް�̕\����\��
                If UBound(m_StaffData) <= M_Spr_NoScrollStaffCnt Then
                    '��۰��ް��\��
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
                    sprMain.Width = w_intAllColWidth
                Else
                    '��۰��ް�\��
                    sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Always
                    sprMain.Width = w_intAllColWidth + 17
                End If

                '�s�̍����ݒ�
                .Rows(-1).Height = M_Spr_RowHeight

                '�S������ٌ^�Œ��������ɐݒ�
                w_styleCell = New FarPoint.Win.Spread.StyleInfo
                w_tcell = New FarPoint.Win.Spread.CellType.TextCellType()
                w_styleCell.CellType = w_tcell
                w_styleCell.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                w_styleCell.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
                .Models.Style.SetDirectInfo(-1, -1, w_styleCell)

                '��������ٌ^�ō�����
                w_styleCell = New FarPoint.Win.Spread.StyleInfo
                w_tcell = New FarPoint.Win.Spread.CellType.TextCellType()
                w_styleCell.CellType = w_tcell
                w_styleCell.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                w_styleCell.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
                w_styleCell.BackColor = SystemColors.Control
                Dim w_inBorderNo As New FarPoint.Win.LineBorder(Color.Gray, 1, False, False, True, True)
                Dim w_outBorderNo As New FarPoint.Win.LineBorder(Color.Black, 1, True, True, True, True)
                Dim w_borderNo As New FarPoint.Win.CompoundBorder(w_outBorderNo, w_inBorderNo)
                w_styleCell.Border = w_borderNo
                .Models.Style.SetDirectInfo(-1, M_Spr_TyokinNo, w_styleCell)

                '�E��������Ƌ�؂������ٌ^�ō�����
                w_styleCell = New FarPoint.Win.Spread.StyleInfo
                w_tcell = New FarPoint.Win.Spread.CellType.TextCellType()
                w_styleCell.CellType = w_tcell
                w_styleCell.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
                w_styleCell.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
                .Models.Style.SetDirectInfo(-1, M_Spr_TyokinNameCol, w_styleCell)
                .Models.Style.SetDirectInfo(-1, M_Spr_BraekCol1, w_styleCell)

                '���샂�[�h
                .OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly

                '�r����\��
                w_styleCell = New FarPoint.Win.Spread.StyleInfo
                Dim w_bevelBorder As New FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, Color.Black, Color.Black)
                w_styleCell.Border = w_bevelBorder
                w_styleCell.CellType = w_tcell
                w_styleCell.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
                w_styleCell.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
                .Models.Style.SetDirectInfo(-1, -1, w_styleCell)

                '���گ�ޏ�̍��v�s�̗L��(�E������17�l�ȉ��̏ꍇ�ͽ��گ�ނɍ��v�s��\��)
                If w_TotalRows <> 0 Then
                    '���v�s����گ�ޏ�ɕ\��

                    '�S������ٌ^�Œ��������ɐݒ�
                    w_styleCell = New FarPoint.Win.Spread.StyleInfo
                    w_styleCell.BackColor = SystemColors.Control
                    .Models.Style.SetDirectInfo(w_TotalRows, -1, w_styleCell)

                    '��������ٌ^�ō�����
                    w_styleCell = New FarPoint.Win.Spread.StyleInfo
                    w_styleCell.BackColor = SystemColors.Control
                    .Models.Style.SetDirectInfo(w_TotalRows, M_Spr_TyokinNo, w_styleCell)

                    '�E������������v���ق�
                    w_styleCell = New FarPoint.Win.Spread.StyleInfo
                    w_styleCell.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
                    w_styleCell.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center
                    .SetText(w_TotalRows, M_Spr_TyokinNameCol, "���@�@�v")
                    .Models.Style.SetDirectInfo(w_TotalRows, M_Spr_TyokinNameCol, w_styleCell)

                    '���v�ͽ��گ�ނɕ\�����邽�ߔ�\��
                    Shape.Visible = False
                    lblTotalTitle.Visible = False
                    vseTotalTitle.Visible = False
                    m_lstPicTotal(0).Visible = False
                    m_lstPicTotal(1).Visible = False
                    m_lstPicTotal(2).Visible = False
                    m_lstPicTotal(3).Visible = False
                    m_lstPicTotal(4).Visible = False
                    m_lstPicTotal(5).Visible = False
                    m_lstPicTotal(6).Visible = False
                    m_lstPicTotal(7).Visible = False
                    m_lstPicTotal(8).Visible = False
                    m_lstPicTotal(9).Visible = False

                End If
                .SelectionPolicy = False

                '���گ�ނ̑傫��(��۰قȂ��ŕ\���\�l����������Ă���ꍇ�͏k�߂�)
                If UBound(m_StaffData) <= M_Spr_NoScrollStaffCnt Then
                    w_Spred_Height = .RowCount * M_Spr_RowHeight
                Else
                    w_Spred_Height = M_Spr_NoScrollStaffCnt * M_Spr_RowHeight
                End If
                sprMain.Height = w_Spred_Height + 4

                General.paSpreadSizeFit(sprMain, sprMain.VerticalScrollBarPolicy, sprMain.HorizontalScrollBarPolicy, .RowCount, w_intAllColWidth, sprMain.Height)
            End With

            sprMain.ResumeLayout(True)

            General.g_ErrorProc = w_PreErrorProc

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Disp_StaffData()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HA Disp_StaffData"

            Dim w_i As Integer
            Dim w_VarText As String

            Dim w_ChkTime As String
            Dim w_CheckTotal As Short
            Dim w_RowColor As Integer
            Dim w_TotalRows As Integer
            Dim w_styleCell As FarPoint.Win.Spread.StyleInfo
            Dim w_intRow As Integer
            Dim w_style As FarPoint.Win.Spread.StyleInfo


            '�l�̎��ԍ��v������l�𒴂��Ă���ꍇ�A�ԐF�\���Ƃ���B
            w_ChkTime = m_Cyokin.MonthChk

            'Spread�`�揈���̈ꎞ��~
            sprMain.SuspendLayout()
            '�s�̃X�^�C���̍쐬
            w_style = New FarPoint.Win.Spread.StyleInfo

            '���Ζ��׽��گ�޼�Ăɓ\��t��
            With sprMain_Sheet1

                For w_i = 1 To UBound(m_StaffData)
                    w_intRow = w_i - 1

                    '�\����
                    .SetText(w_intRow, M_Spr_TyokinNo, Convert.ToString(w_i))
                    '����
                    .SetText(w_intRow, M_Spr_TyokinNameCol, m_StaffData(w_i).strStaffName)

                    '��؂�ɃX�y�[�X����
                    .SetText(w_intRow, M_Spr_BraekCol1, " ")

                    '100/110�̎��ԍ��v
                    If m_StaffData(w_i).lng100 > 0 Then
                        .SetText(w_intRow, M_Spr_FirstTanka, fncEditTimeSingle(m_StaffData(w_i).lng100))
                    Else
                        .SetText(w_intRow, M_Spr_FirstTanka, " ")
                    End If

                    '125/110�̎��ԍ��v
                    If m_StaffData(w_i).lng125 > 0 Then
                        .SetText(w_intRow, M_Spr_SecondTanka, fncEditTimeSingle(m_StaffData(w_i).lng125))
                    End If

                    '135/110�̎��ԍ��v
                    If m_StaffData(w_i).lng135 > 0 Then
                        .SetText(w_intRow, M_Spr_ThirdTanka, fncEditTimeSingle(m_StaffData(w_i).lng135))
                    End If

                    '150/110�̎��ԍ��v
                    If m_StaffData(w_i).lng150 > 0 Then
                        .SetText(w_intRow, M_Spr_FourTanka, fncEditTimeSingle(m_StaffData(w_i).lng150))
                    End If

                    '160/110�̎��ԍ��v
                    If m_StaffData(w_i).lng160 > 0 Then
                        .SetText(w_intRow, M_Spr_FiveTanka, fncEditTimeSingle(m_StaffData(w_i).lng160))
                    End If

                    '150/100�̎��ԍ��v
                    If m_StaffData(w_i).lng150_2 > 0 Then
                        .SetText(w_intRow, M_Spr_SixTanka, fncEditTimeSingle(m_StaffData(w_i).lng150_2))
                    End If

                    '175/100�̎��ԍ��v
                    If m_StaffData(w_i).lng175 > 0 Then
                        .SetText(w_intRow, M_Spr_SevenTanka, fncEditTimeSingle(m_StaffData(w_i).lng175))
                    End If

                    '�l�̎��ԍ��v
                    If m_StaffData(w_i).lngTotal > 0 Then
                        .SetText(w_intRow, M_Spr_TotalTanka, fncEditTimeSingle(m_StaffData(w_i).lngTotal))
                    End If

                    '�x���\�����K�v?
                    If IsNumeric(w_ChkTime) = True Then
                        '���l�Ƃ��Ĕ��f�ł���ꍇ�̂���������
                        If CShort(w_ChkTime) <> 0 Then
                            '0�ȊO�Ȃ�����
                            w_CheckTotal = ((m_StaffData(w_i).lngTotal \ 100) * 60) + (m_StaffData(w_i).lngTotal Mod 100)
                            If w_CheckTotal > CShort(w_ChkTime) Then
                                '�װ������ν��گ�ނ̕����F��ς���
                                w_styleCell = New FarPoint.Win.Spread.StyleInfo
                                w_styleCell.ForeColor = System.Drawing.ColorTranslator.FromOle(M_Spr_ErrRow_Color)
                                .Models.Style.SetDirectInfo(w_i, M_Spr_TotalTanka, w_styleCell)
                            End If
                        End If
                    End If

                    '��Ԏ��ԍ��v
                    If m_StaffData(w_i).lngYakan > 0 Then
                        .SetText(w_intRow, M_Spr_NightTanka, fncEditTimeSingle(m_StaffData(w_i).lngYakan))
                    End If

                    '�x�����ԍ��v
                    If m_StaffData(w_i).lngKyujitu > 0 Then
                        .SetText(w_intRow, M_Spr_HolidayTanka, fncEditTimeSingle(m_StaffData(w_i).lngKyujitu))
                    End If

                    '2018-08-15 Darren ADD START
                    If m_StaffData(w_i).lng25 > 0 Then
                        .SetText(w_intRow, M_Spr_25, fncEditTimeSingle(m_StaffData(w_i).lng25))
                    End If
                    '2018-08-15 Darren ADD END

                    '�s�ɐF������
                    If w_RowColor = M_Spr_RowColor1 Then
                        w_RowColor = M_Spr_RowColor2
                    Else
                        w_RowColor = M_Spr_RowColor1
                    End If

                    '�X�^�C���̓K�p
                    w_style.BackColor = System.Drawing.ColorTranslator.FromOle(w_RowColor)
                    .SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single
                    For n As Integer = M_Spr_TyokinNameCol To M_Spr_HolidayTanka
                        .Models.Style.SetDirectInfo(w_intRow, n, w_style)
                    Next
                Next w_i

                '�Ō�P�ʍ��v
                '100/110
                w_VarText = fncEditTimeTotal(m_lngTotal100)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    w_TotalRows = UBound(m_StaffData)
                    .SetText(w_TotalRows, M_Spr_FirstTanka, w_VarText)
                Else
                    m_lstLblTanka(0).Text = w_VarText
                End If
                '125/110
                w_VarText = fncEditTimeTotal(m_lngTotal125)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    w_TotalRows = UBound(m_StaffData)
                    .SetText(w_TotalRows, M_Spr_SecondTanka, w_VarText)
                Else
                    m_lstLblTanka(1).Text = w_VarText
                End If
                '135/100
                w_VarText = fncEditTimeTotal(m_lngTotal135)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    .SetText(w_TotalRows, M_Spr_ThirdTanka, w_VarText)
                Else
                    m_lstLblTanka(2).Text = w_VarText
                End If
                '150/100
                w_VarText = fncEditTimeTotal(m_lngTotal150)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    .SetText(w_TotalRows, M_Spr_FourTanka, w_VarText)
                Else
                    m_lstLblTanka(3).Text = w_VarText
                End If
                '160/100
                w_VarText = fncEditTimeTotal(m_lngTotal160)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    .SetText(w_TotalRows, M_Spr_FiveTanka, w_VarText)
                Else
                    m_lstLblTanka(4).Text = w_VarText
                End If


                '150/100
                w_VarText = fncEditTimeTotal(m_lngTotal150_2)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    .SetText(w_TotalRows, M_Spr_SixTanka, w_VarText)
                Else
                    m_lstLblTanka(5).Text = w_VarText
                End If
                '175/100
                w_VarText = fncEditTimeTotal(m_lngTotal175)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    .SetText(w_TotalRows, M_Spr_SevenTanka, w_VarText)
                Else
                    m_lstLblTanka(6).Text = w_VarText
                End If

                '�P�����v
                w_VarText = fncEditTimeAllTotal(m_lngTankaTotal)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    .SetText(w_TotalRows, M_Spr_TotalTanka, w_VarText)
                Else
                    lblTankaTotal.Text = w_VarText
                End If
                '��ԍ��v
                w_VarText = fncEditTimeTotal(m_lngYakanTotal)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    .SetText(w_TotalRows, M_Spr_NightTanka, w_VarText)
                Else
                    lblYakanTotal.Text = w_VarText
                End If
                '�x�����v
                w_VarText = fncEditTimeTotal(m_lngKyujituTotal)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    .SetText(w_TotalRows, M_Spr_HolidayTanka, w_VarText)
                Else
                    lblOffTotal.Text = w_VarText
                End If
                '2018-08-15 Darren ADD START
                w_VarText = fncEditTimeTotal(m_lngTotal25)
                If UBound(m_StaffData) < M_Spr_NoScrollStaffCnt Then
                    '�E��������۰قȂ��ŕ\���\�l����菭�Ȃ���ν��گ�ނɕ\��
                    .SetText(w_TotalRows, M_Spr_25, w_VarText)
                Else
                    lbl25Total.Text = w_VarText
                End If
                '2018-08-15 Darren ADD END
            End With
            'Spread�`�揈���̍ĊJ
            sprMain.ResumeLayout(True)

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub frmNSW0060HA_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        Try
            General.g_ErrorProc = "clsNSW0060HA Form_QueryUnload"

            If m_LoadOK_Flg = True Then
                '�����E1��������
                Call TotalCheck()
            End If

            Exit Sub

        Catch ex As Exception
            Call General.paDllTrpMsg(Str(Err.Number), General.g_ErrorProc)
            eventArgs.Cancel = Cancel
        End Try
    End Sub

    Private Sub frmNSW0060HA_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            General.g_ErrorProc = "clsNSW0060HA Form_Unload"

            Erase m_StaffData

            Exit Sub
        Catch ex As Exception
            Call General.paDllTrpMsg(Str(Err.Number), General.g_ErrorProc)
        End Try
    End Sub

    Private Function GetStaff() As Boolean
        Dim w_PreErrorProc As String

        Dim w_lngStaffLoop As Integer
        Dim w_lngWorkLoop As Integer
        Dim w_lngStaffCnt As Integer
        Dim w_strStaffMngID As String
        Dim w_Form As frmNSW0060HB
        Dim w_strTEXT As String
        Dim w_strBkStaffMngID As String
        Dim w_lngGetStaffCnt As Integer

        Try
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HA GetStaff"

            '�l�̏�����
            w_strBkStaffMngID = ""
            w_lngGetStaffCnt = 0

            GetStaff = False

            '�z�񏉊���
            ReDim m_StaffData(0)

            With General.g_objGetData

                .p�a�@CD = m_HospitalCD
                .p�E���擾FLG = 0
                .p���t�敪 = 1
                .p�\�[�g�� = 0
                .p�J�n�N���� = m_SelectFrom
                .p�I���N���� = m_SelectTo
                .p�Ζ��Ώ�FLG = 0
                .p�D�揇�� = 0
                .p�Ώ�CD = m_KangoTCD
                .p�`�[���敪 = 0
                .p�V�X�e���敪 = 0

                If .mGetStaff = False Then
                    '�E�������݂��Ȃ��ꍇ
                    Exit Function
                Else
                    w_lngStaffCnt = .f�E������
                    '�����o�ߕ\��̫�ѐݒ�
                    w_Form = New frmNSW0060HB
                    w_Form.Show()
                    w_strTEXT = "�E�������擾��..."
                    Call w_Form.Set_WaitWindow(w_lngStaffCnt, w_strTEXT)

                    For w_lngStaffLoop = 1 To w_lngStaffCnt
                        .p�E������ = w_lngStaffLoop

                        '�E�����ς�����H(�Čٗp�΍�)
                        If w_strBkStaffMngID <> .f�E���Ǘ��ԍ�2 Then
                            '�u���C�N�p�E���Ǘ��ԍ��擾
                            w_strBkStaffMngID = .f�E���Ǘ��ԍ�2

                            '�J�E���g�t�o
                            w_lngGetStaffCnt = w_lngGetStaffCnt + 1

                            '�z��g��
                            ReDim Preserve m_StaffData(w_lngGetStaffCnt)

                            '�E���Ǘ��ԍ�
                            w_strStaffMngID = .f�E���Ǘ��ԍ�2

                            m_StaffData(w_lngGetStaffCnt).strStaffMngNo = w_strStaffMngID

                            '�E���ԍ�
                            m_StaffData(w_lngGetStaffCnt).strStaffNo = .f�E���ԍ�2

                            '�E����
                            m_StaffData(w_lngGetStaffCnt).strStaffName = .f����2

                            '===============================================================
                            'mStaffInit
                            '===============================================================
                            .p�a�@CD = m_HospitalCD
                            .p�E���ԍ��ϊ� = 0
                            .p�E���敪 = 0
                            .p�E���ԍ� = w_strStaffMngID
                            .p���t�敪 = 1
                            .p�J�n�N���� = m_SelectFrom
                            .p�I���N���� = m_SelectTo
                            .p�����\�[�gFLG = 0
                            .p�V�X�e���敪 = 0

                            ReDim m_StaffData(w_lngGetStaffCnt).IdoHistory(0)
                            ReDim m_StaffData(w_lngGetStaffCnt).SaiyoHistory(0)
                            If .mStaffInit() = False Then
                                '�E�������݂��Ȃ��ꍇ
                            Else

                                '�̗p��
                                For w_lngWorkLoop = 1 To .f�E���Ǘ�����
                                    .p�E���Ǘ����� = w_lngWorkLoop
                                    ReDim Preserve m_StaffData(w_lngGetStaffCnt).SaiyoHistory(UBound(m_StaffData(w_lngGetStaffCnt).SaiyoHistory) + 1)
                                    m_StaffData(w_lngGetStaffCnt).SaiyoHistory(w_lngWorkLoop).strCD = .f�̗p����CD
                                    m_StaffData(w_lngGetStaffCnt).SaiyoHistory(w_lngWorkLoop).lngStartDate = .f�̗p�N����1
                                    m_StaffData(w_lngGetStaffCnt).SaiyoHistory(w_lngWorkLoop).lngEndDate = .f�]�ޔN����1
                                Next w_lngWorkLoop

                                '�ٓ���
                                For w_lngWorkLoop = 1 To .f�z���ٓ�����
                                    .p�z���ٓ����� = w_lngWorkLoop
                                    ReDim Preserve m_StaffData(w_lngGetStaffCnt).IdoHistory(UBound(m_StaffData(w_lngGetStaffCnt).IdoHistory) + 1)
                                    m_StaffData(w_lngGetStaffCnt).IdoHistory(w_lngWorkLoop).strCD = .f�z������CD
                                    m_StaffData(w_lngGetStaffCnt).IdoHistory(w_lngWorkLoop).strName = .f�z����������
                                    m_StaffData(w_lngGetStaffCnt).IdoHistory(w_lngWorkLoop).lngStartDate = .f�z���ٓ��N����
                                    m_StaffData(w_lngGetStaffCnt).IdoHistory(w_lngWorkLoop).lngEndDate = .f�z���I���N����
                                Next w_lngWorkLoop

                            End If
                        End If

                        '�������čX�V
                        Call w_Form.SyoriCount(w_lngStaffLoop, w_lngStaffCnt)
                    Next w_lngStaffLoop

                End If
            End With

            w_Form.Close()

            GetStaff = True

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�

        Catch ex As Exception
            If w_Form Is Nothing = False Then
                w_Form.Close()
            End If
            Throw
        End Try
    End Function


    Private Function GetOverKinmuData() As Boolean
        Dim w_PreErrorProc As String

        Dim w_Form As frmNSW0060HB
        Dim w_strTEXT As String
        Dim w_lngStaffCnt As Integer
        Dim w_lngStaffLoop As Integer
        Dim w_lngWorkLoop As Integer
        Dim w_blnSaiyoFlag As Boolean
        Dim w_lngDate As Integer
        Dim w_lngDataCnt As Integer
        Dim w_Idx As Integer
        Dim w_lngOKCnt As Integer
        Dim w_s As Integer
        Dim w_BeforeTo As Integer

        Dim w_Time125 As Integer
        Dim w_Time135 As Integer
        Dim w_Time150 As Integer
        Dim w_Time160 As Integer
        Dim w_Time100 As Integer
        Dim w_lngDayTotal As Integer

        Dim w_lngOneBeforeDate As Integer

        Dim w_Time150_2 As Integer
        Dim w_Time175 As Integer
        '2018-08-15 Darren ADD START
        Dim w_Time25 As Integer
        '2018-08-15 Darren ADD END

        Try
            w_PreErrorProc = General.g_ErrorProc
            General.g_ErrorProc = "clsNSW0060HA GetOverKinmuData"

            GetOverKinmuData = False

            w_lngOneBeforeDate = General.paGetDateIntegerFromDate(General.paGetDateFromDateInteger(m_SelectFrom).AddDays(-1))
            '�����������Ԃ̑O���̏I�������擾
            w_BeforeTo = General.paGetDateIntegerFromDate(General.paGetDateFromDateInteger(m_SelectFrom).AddDays(14))

            '���ɵ�޼ު�Ă���������Ă��邩?
            If m_objComChokin Is Nothing Then
                '��޼ު�Ă���������Ă��Ȃ��ꍇ
                m_objComChokin = New NsAid_NSW0300C.clsGetOverData
                '�e�����è��ݒ肷��
                With m_objComChokin
                    .p�a�@CD = m_HospitalCD
                    .pGetDataObj = General.g_objGetData
                End With
            End If

            m_objComChokin.p���t�敪 = 1 '����
            m_objComChokin.p�J�n�N���� = w_lngOneBeforeDate
            m_objComChokin.p�I���N���� = m_SelectTo
            m_objComChokin.p�Ώ�CD = m_KangoTCD
            If m_objComChokin.mOverKinmuInit(General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "DATEJUDGMENT", "0", m_HospitalCD)) = False Then

            End If

            w_lngStaffCnt = UBound(m_StaffData)
            '�����o�ߕ\��̫�ѐݒ�
            w_Form = New frmNSW0060HB
            w_Form.Show()
            w_strTEXT = "�Ζ��f�[�^���擾�A�v�Z��..."
            Call w_Form.Set_WaitWindow(w_lngStaffCnt, w_strTEXT)


            For w_lngStaffLoop = 1 To w_lngStaffCnt

                With m_objComChokin
                    '--- �o�͑ΏېE�����̎擾
                    .p�a�@CD = m_HospitalCD
                    .p�E���敪 = 0
                    .p�E���ԍ� = m_StaffData(w_lngStaffLoop).strStaffMngNo
                    .p���t�敪 = 1 '--- ����
                    .p�J�n�N���� = w_lngOneBeforeDate
                    .p�I���N���� = m_SelectTo

                    If m_objComChokin.mGetOverKinmuData() = False Then
                    Else

                        w_lngDataCnt = .f���ђ��Ό���
                        .p�N���� = w_lngOneBeforeDate
                        For w_Idx = 0 To w_lngDataCnt

                            w_lngDate = .f�N����

                            w_Time125 = 0
                            w_Time135 = 0
                            w_Time150 = 0
                            w_Time160 = 0
                            w_Time100 = 0
                            w_lngDayTotal = 0

                            w_Time150_2 = 0
                            w_Time175 = 0
                            '2018-08-15 Darren ADD START
                            w_Time25 = 0
                            '2018-08-15 Darren ADD END

                            If w_lngDate > 0 Then

                                w_blnSaiyoFlag = False
                                For w_lngWorkLoop = 1 To UBound(m_StaffData(w_lngStaffLoop).SaiyoHistory)
                                    If m_StaffData(w_lngStaffLoop).SaiyoHistory(w_lngWorkLoop).lngStartDate <= w_lngDate AndAlso w_lngDate <= m_StaffData(w_lngStaffLoop).SaiyoHistory(w_lngWorkLoop).lngEndDate Then
                                        w_blnSaiyoFlag = True
                                        Exit For
                                    End If
                                Next w_lngWorkLoop

                                If w_blnSaiyoFlag = True Then
                                    '�����t���_�ɂ����Ă͑ސE���Ă��Ȃ��ꍇ
                                    If w_lngOneBeforeDate = w_lngDate Then

                                    Else
                                        w_lngOKCnt = .f���Ύ��Ԍ���
                                        For w_s = 1 To w_lngOKCnt
                                            .p���Ύ��ԍ��� = w_s
                                            '========================
                                            '   ���ΒP���ʎ��� �Z�o
                                            '========================
                                            '�����ް������邩�ǂ������f
                                            If .f���Ύ���FROM <> "" AndAlso .f���Ύ���TO <> "" Then
                                                If .f���Ώ�ԋ敪 = "1" Then

                                                    w_Time125 = .f���ߋΖ�����125
                                                    w_Time135 = .f���ߋΖ�����135
                                                    w_Time150 = .f���ߋΖ�����150
                                                    w_Time160 = .f���ߋΖ�����160
                                                    w_Time100 = .f���ߋΖ�����100

                                                    w_Time150_2 = .f���ߋΖ�����150_2
                                                    w_Time175 = .f���ߋΖ�����175

                                                    '2018-08-15 Darren ADD START
                                                    w_Time25 = .f���ߋΖ�����25
                                                    '2018-08-15 Darren ADD END

                                                    'w_lngDayTotal = w_Time125 + w_Time135 + w_Time150 + w_Time160 + w_Time100
                                                    w_lngDayTotal = w_Time125 + w_Time135 + w_Time150 + w_Time160 + w_Time100 + w_Time150_2 + w_Time175 + w_Time25

                                                    '���j�x���ȊO�̓��̏ꍇ
                                                    '--------------
                                                    '   125/100
                                                    '--------------
                                                    If w_Time125 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng125 = m_StaffData(w_lngStaffLoop).lng125 + w_Time125
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time125
                                                    End If
                                                    '--------------
                                                    '   150/100
                                                    '--------------
                                                    If w_Time150 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng150 = m_StaffData(w_lngStaffLoop).lng150 + w_Time150
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time150
                                                    End If
                                                    '���j�x���̏ꍇ
                                                    '--------------
                                                    '   135/100
                                                    '--------------
                                                    If w_Time135 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng135 = m_StaffData(w_lngStaffLoop).lng135 + w_Time135
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time135
                                                    End If
                                                    '--------------
                                                    '   160/100
                                                    '--------------
                                                    If w_Time160 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng160 = m_StaffData(w_lngStaffLoop).lng160 + w_Time160
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time160
                                                    End If

                                                    '--------------
                                                    '   100/100
                                                    '--------------
                                                    If w_Time100 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng100 = m_StaffData(w_lngStaffLoop).lng100 + w_Time100
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time100
                                                    End If


                                                    '--------------
                                                    '   150/100
                                                    '--------------
                                                    If w_Time150_2 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng150_2 = m_StaffData(w_lngStaffLoop).lng150_2 + w_Time150_2
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time150_2
                                                    End If


                                                    '--------------
                                                    '   175/100
                                                    '--------------
                                                    If w_Time175 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng175 = m_StaffData(w_lngStaffLoop).lng175 + w_Time175
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time175
                                                    End If

                                                    '2018-08-15 Darren ADD START
                                                    '--------------
                                                    '   25/100
                                                    '--------------
                                                    If w_Time25 <> 0 Then
                                                        m_StaffData(w_lngStaffLoop).lng25 = m_StaffData(w_lngStaffLoop).lng25 + w_Time25
                                                        m_StaffData(w_lngStaffLoop).lngTotal = m_StaffData(w_lngStaffLoop).lngTotal + w_Time25
                                                    End If
                                                    '2018-08-15 Darren ADD END

                                                End If
                                            End If
                                        Next w_s

                                        '-----------------------------
                                        '   �x���Ζ����� �v�Z���i�[
                                        '-----------------------------
                                        If .f�x���Ζ����� > 0 Then
                                            m_StaffData(w_lngStaffLoop).lngKyujitu = m_StaffData(w_lngStaffLoop).lngKyujitu + .f�x���Ζ�����
                                        End If
                                        '-----------------------------
                                        '   ��ԋΖ����� �v�Z���i�[
                                        '-----------------------------
                                        If .f��ԋΖ����� > 0 Then
                                            m_StaffData(w_lngStaffLoop).lngYakan = m_StaffData(w_lngStaffLoop).lngYakan + .f��ԋΖ�����
                                        End If
                                    End If
                                End If '�ސE���Ă��邩�H

                                If m_SelectFrom <= w_lngDate AndAlso w_lngDate <= w_BeforeTo Then
                                    '�O�����̏ꍇ
                                    m_StaffData(w_lngStaffLoop).lngBeforeHalf = m_StaffData(w_lngStaffLoop).lngBeforeHalf + w_lngDayTotal
                                Else
                                    '�㔼���̏ꍇ
                                    m_StaffData(w_lngStaffLoop).lngAfterHalf = m_StaffData(w_lngStaffLoop).lngAfterHalf + w_lngDayTotal
                                End If
                            End If

                            .m��������()
                        Next w_Idx
                    End If
                End With


                '�������čX�V
                Call w_Form.SyoriCount(w_lngStaffLoop, w_lngStaffCnt)
            Next w_lngStaffLoop

            w_Form.Close()

            GetOverKinmuData = True

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�
        Catch ex As Exception
            If w_Form Is Nothing = False Then
                w_Form.Close()
            End If
            Throw
        End Try
    End Function


    '����ϊ�(90��130)
    Private Function fncChangeTime(ByVal p_lngMiniteTime As Integer) As Integer
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
            General.g_ErrorProc = "clsNSW0060HA fncChangeTime"

            Dim w_Hour As Integer
            Dim w_Min As Integer
            Dim w_lngChangeTime As Integer

            fncChangeTime = 0

            w_Min = p_lngMiniteTime
            w_Hour = (w_Min \ 60)
            w_Min = w_Min Mod 60
            w_lngChangeTime = (w_Hour) * 100 + w_Min

            fncChangeTime = w_lngChangeTime

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�

        Catch ex As Exception
            Throw
        End Try
    End Function

    '���v�v�Z
    Private Sub subAllTotalTime()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
            General.g_ErrorProc = "clsNSW0060HA subAllTotalTime"

            Dim w_lngWorkLoop As Integer

            For w_lngWorkLoop = 1 To UBound(m_StaffData)

                m_lngTotal100 = m_lngTotal100 + m_StaffData(w_lngWorkLoop).lng100
                m_lngTotal125 = m_lngTotal125 + m_StaffData(w_lngWorkLoop).lng125
                m_lngTotal135 = m_lngTotal135 + m_StaffData(w_lngWorkLoop).lng135
                m_lngTotal150 = m_lngTotal150 + m_StaffData(w_lngWorkLoop).lng150
                m_lngTotal160 = m_lngTotal160 + m_StaffData(w_lngWorkLoop).lng160
                m_lngTotal150_2 = m_lngTotal150_2 + m_StaffData(w_lngWorkLoop).lng150_2
                m_lngTotal175 = m_lngTotal175 + m_StaffData(w_lngWorkLoop).lng175
                m_lngTankaTotal = m_lngTankaTotal + m_StaffData(w_lngWorkLoop).lngTotal
                m_lngYakanTotal = m_lngYakanTotal + m_StaffData(w_lngWorkLoop).lngYakan
                m_lngKyujituTotal = m_lngKyujituTotal + m_StaffData(w_lngWorkLoop).lngKyujitu
                '2018-08-15 Darren ADD START
                m_lngTotal25 = m_lngTotal25 + m_StaffData(w_lngWorkLoop).lng25
                '2018-08-15 Darren ADD END

            Next w_lngWorkLoop


            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�

        Catch ex As Exception
            Throw
        End Try
    End Sub

    '���ڐݒ�擾
    Private Sub subGetSettei()
        Try
            Dim w_PreErrorProc As String
            w_PreErrorProc = General.g_ErrorProc '��ۼ��ެ���̈ꎞ�Ҕ�
            General.g_ErrorProc = "clsNSW0060HA subGetSettei"

            m_Cyokin.EndDay = ""
            m_Cyokin.HalfChk = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "OKTIMEHALFMIN", Convert.ToString(0), m_HospitalCD)
            m_Cyokin.MonthChk = General.paGetItemValue(General.G_STRMAINKEY3, General.G_STRSUBKEY1, "OKTIMERUIKEIMIN", Convert.ToString(0), m_HospitalCD)

            m_lngDefSelect = Integer.Parse(General.paGetItemValue(General.G_STRMAINKEY3, "OVERKINMUINFO", "DEFSELECT", Convert.ToString(0), m_HospitalCD))

            m_SelDate = General.paGetDateIntegerFromDate(General.paGetDateFromDateInteger(m_SelDate).AddMonths(m_lngDefSelect), General.G_DATE_ENUM.yyyyMM)

            General.g_ErrorProc = w_PreErrorProc '�Ҕ���ۼ��ެ�������ɖ߂�

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' �R���g���[���z���ݒ肵�܂��B
    ''' </summary>
    Private Sub subSetControlsList()

        '���v�P�����x��
        General.paSetControlList(_picTotal_0, "_lblTanka_", m_lstLblTanka)    '100/100?
        General.paSetControlList(_picTotal_1, "_lblTanka_", m_lstLblTanka, 1) '125/100?
        General.paSetControlList(_picTotal_2, "_lblTanka_", m_lstLblTanka, 2) '135/100?
        General.paSetControlList(_picTotal_3, "_lblTanka_", m_lstLblTanka, 3) '150/100?
        General.paSetControlList(_picTotal_7, "_lblTanka_", m_lstLblTanka, 4) '160/100?
        General.paSetControlList(_picTotal_8, "_lblTanka_", m_lstLblTanka, 5) '150/100?
        General.paSetControlList(_picTotal_9, "_lblTanka_", m_lstLblTanka, 6) '170/100?

        '�^�C�g�����x��
        General.paSetControlList(Me, "_lblTitle_", m_lstLblTitle)

        '���v�p�l��
        General.paSetControlList(Me, "_picTotal_", m_lstPicTotal)

    End Sub

    ''' <summary>
    ''' ���Ԃ�hh:mm�`���ɕҏW���܂��B�i�P���ڗp�j
    ''' </summary>
    ''' <param name="p_intTime">�ҏW�Ώێ���</param>
    ''' <returns>�ҏW�㎞��</returns>
    Private Function fncEditTimeSingle(ByVal p_intTime As Integer) As String
        fncEditTimeSingle = fncEditTime(p_intTime, 5, 4)
    End Function

    ''' <summary>
    ''' ���Ԃ�hh:mm�`���ɕҏW���܂��B�i���v���ڗp�j
    ''' </summary>
    ''' <param name="p_intTime">�ҏW�Ώێ���</param>
    ''' <returns>�ҏW�㎞��</returns>
    Private Function fncEditTimeTotal(ByVal p_intTime As Integer) As String
        fncEditTimeTotal = fncEditTime(p_intTime, 6, 4)
    End Function

    ''' <summary>
    ''' ���Ԃ�hh:mm�`���ɕҏW���܂��B�i���v�̍��v���ڗp�j
    ''' </summary>
    ''' <param name="p_intTime">�ҏW�Ώێ���</param>
    ''' <returns>�ҏW�㎞��</returns>
    Private Function fncEditTimeAllTotal(ByVal p_intTime As Integer) As String
        fncEditTimeAllTotal = fncEditTime(p_intTime, 6, 5)
    End Function

    ''' <summary>
    ''' ���Ԃ�hh:mm�`���ɕҏW���܂��B
    ''' </summary>
    ''' <param name="p_intTime">�ҏW�Ώێ���</param>
    ''' <param name="p_intHourZero">���ԃ[�����ߕҏW�p����</param>
    ''' <param name="p_intHourBrank">���ԋ󔒖��ߕҏW�p����</param>
    ''' <returns>�ҏW�㎞��</returns>
    '''  <remarks>
    ''' hh:mm�`���Ƃ́Ahh����(�󔒖��ߎ��ԋ󔒖��ߕҏW�p��)mm���i�[�����ߗL2���j�ƂȂ�܂��B
    ''' ��F����.�ҏW�Ώێ���=123���߂�l.�ҏW�㎞��="   2:03"
    ''' </remarks>
    Private Function fncEditTime(ByVal p_intTime As Integer, ByVal p_intHourZero As Integer, ByVal p_intHourBrank As Integer) As String
        Dim w_strRes As String = ""
        Dim w_strTime As String = fncChangeTime(p_intTime).ToString
        Dim w_strFormat As String = "{0," & p_intHourBrank.ToString & "}"

        w_strRes = String.Format(w_strFormat, Integer.Parse(General.paLeft(w_strTime.PadLeft(p_intHourZero, "0"), (p_intHourZero - 2))))
        w_strRes += ":"
        w_strRes += General.paRight(w_strTime.PadLeft(4, "0"), 2)

        fncEditTime = w_strRes
    End Function

    ''' <summary>
    ''' �^�C�g���w�i�ĕ`�掞�����B
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub _Title_Paint(ByVal sender As System.Object, ByVal e As PaintEventArgs) Handles _vseTitle_0.Paint, _vseTitle_1.Paint, _vseTitle_2.Paint, _vseTitle_3.Paint, _vseTitle_4.Paint, _vseTitle_5.Paint, _vseTitle_6.Paint, _vseTitle_7.Paint, _vseTitle_8.Paint, _vseTitle_9.Paint, _vseTitle_10.Paint, _vseTitle_11.Paint, _vseTitle_12.Paint, _vseTitle_13.Paint, _vseTitle_14.Paint, _vseTitle_15.Paint, _vseTitle_16.Paint, _vseTitle_17.Paint, vseTotalTitle.Paint

        '�\���ݒ�
        CType(sender, Label).BorderStyle = BorderStyle.None
        Dim g As Graphics = e.Graphics
        ControlPaint.DrawBorder3D(g, sender.ClientRectangle, Border3DStyle.Raised, Border3DSide.All)

    End Sub
End Class