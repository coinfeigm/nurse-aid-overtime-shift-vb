Option Strict Off
Option Explicit On

Friend Class frmNSC0000HM
    Inherits General.FormBase

	Private m_DefDate As String '���ݑI������Ă��錎(Format:"yyyymm")
	Private m_SelectDate As String '�m�����(Format:"yyyymm")
	Private m_KikanDate() As String '���Ԃ̓��t���i�[(Format:"yyyymm")
	Private m_OKCancel As Boolean 'OK���݂���ݾ����݂�(True:OK, False:Cancel)
	
	'�I�������󂯎��(�`���Fyyyymm)
	Public WriteOnly Property pSelDate() As String
		Set(ByVal Value As String)
			m_DefDate = Value
		End Set
	End Property
	
	
	'�I����Ԃ���ъm��N�����Ăяo������ʂɈ��n��
    Public ReadOnly Property pEndState() As Boolean
        Get
            pEndState = m_OKCancel
        End Get
    End Property

    '�I�����Ԃ�
    Public ReadOnly Property pSelectDate() As String
        Get
            pSelectDate = m_SelectDate
        End Get
    End Property
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Const W_SUBNAME As String = "NSC0000HM cmdCancel_Click"

        Try
            'OK���݉���
            m_OKCancel = False

            Me.Close()

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Const W_SUBNAME As String = "NSC0000HM cmdOK_Click"

        Try
            Dim w_Index As Short
            Dim w_strMsg() As String

            If cboYearMonth.SelectedIndex = -1 Then
                ReDim w_strMsg(1)
                w_strMsg(1) = "�\���N����"
                Call General.paMsgDsp("NS0015", w_strMsg)
                Exit Sub
            End If

            '�I�����Ԃ�ؽĲ��ޯ���擾
            w_Index = Integer.Parse(cboYearMonth.SelectedIndex)
            m_SelectDate = m_KikanDate(w_Index)

            'OK���݉���
            m_OKCancel = True

            Me.Close()

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub


    Private Sub frmNSC0000HM_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Const W_SUBNAME As String = "NSC0000HM Form_Load"

        Try
            '���͔N���������ޯ���ݒ�
            Call SetComboDate()

            '�����ɕ\��
            Call General.paDspCenter(Me)

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub


    Private Sub SetComboDate()
        Const W_SUBNAME As String = "NSC0000HM SetComboDate"

        Try
            Dim w_SetKikan As Short '�����ޯ���ɐݒ肷�����
            Dim w_Date As Date
            Dim w_i As Short
            Dim w_Index As Short

            Dim w_SetAfterKikan As Short
            Dim w_MonthCount As Short

            w_SetAfterKikan = Integer.Parse(General.paGetItemValue(General.G_STRMAINKEY2, General.G_STRSUBKEY1, "AFTERINPUTMONTH", "0", General.g_strHospitalCD))

            w_SetKikan = Integer.Parse(General.paGetItemValue(General.G_STRMAINKEY2, General.G_STRSUBKEY1, "INPUTMONTH", "2", General.g_strHospitalCD)) - 1
            w_Date = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -w_SetKikan, Now)

            ReDim m_KikanDate(w_SetKikan + w_SetAfterKikan)

            '�����ޯ������̫�Ĳ��ޯ���ݒ�
            w_Index = w_SetKikan

            '�����ޯ���ɐݒ�
            m_KikanDate(0) = General.paGetDateStringFromDate(w_Date, General.G_DATE_ENUM.yyyyMM)
            w_Index = cboYearMonth.Items.Add(Format(w_Date, "yyyy") & "�N" & Format(Integer.Parse(Format(w_Date, "MM")), "00") & "��")

            If m_KikanDate(0) = m_DefDate Then
                w_Index = 0
            End If

            For w_i = 1 To w_SetKikan

                w_Date = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, w_Date)
                m_KikanDate(w_i) = General.paGetDateStringFromDate(w_Date, General.G_DATE_ENUM.yyyyMM)
                cboYearMonth.Items.Add(Format(w_Date, "yyyy") & "�N" & Format(Integer.Parse(Format(w_Date, "MM")), "00") & "��")

                If m_KikanDate(w_i) = m_DefDate Then
                    w_Index = w_i
                End If

            Next w_i

            w_MonthCount = w_i

            For w_i = 0 To w_SetAfterKikan - 1

                w_Date = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, w_Date)

                m_KikanDate(w_MonthCount + w_i) = General.paGetDateStringFromDate(w_Date, General.G_DATE_ENUM.yyyyMM)
                cboYearMonth.Items.Add(Format(w_Date, "yyyy") & "�N" & Format(Integer.Parse(Format(w_Date, "MM")), "00") & "��")

                If m_KikanDate(w_MonthCount + w_i) = m_DefDate Then
                    w_Index = w_MonthCount + w_i
                End If

            Next w_i

            '��̫�Ă����݂̑I�����ɐݒ�
            cboYearMonth.SelectedIndex = w_Index

        Catch ex As Exception
            Call General.paTrpMsg(Str(Err.Number), W_SUBNAME)
        End Try
    End Sub
End Class