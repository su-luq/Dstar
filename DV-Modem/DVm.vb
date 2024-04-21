Imports System
Imports System.IO.Ports
Imports System.Threading
Imports System.Management
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO
Imports System.IO

Public Class DVm

    'Declare a Comm Port
    Dim WithEvents ComPort As New SerialPort()
    Dim RB As String
    Dim Debug As Boolean = False
    Dim WidthSimple As UInteger = 480
    Dim WidthDebug As UInteger = 940
    Dim Control As Byte = &HF0
    Dim DelayCounter As UInteger = 65500
    Dim DelayChange As UInteger = 120
    Dim RS232RxBuffer As String = ""
    Dim Inhibicio As Boolean = False
    Dim Group As Boolean = False

    'Functions

    'Funcions pròpies
    'Parse del buffer de Rx de RS232.
    Private Sub RetallRxBuffer()
        Dim lbRx As UInteger
        Dim p As UInteger

        lbRx = Len(RS232RxBuffer)
        If (lbRx >= 2) Then
            p = InStr(2, RS232RxBuffer, "{")
            If p = 0 Then
                RS232RxBuffer = ""
            ElseIf (lbRx > p) Then
                RS232RxBuffer = Mid(RS232RxBuffer, p, lbRx - p)
            End If
        End If
    End Sub
    Private Sub RS232RxBuffer_Parse()
        'Gestió de la recepció de programació.
        Dim lbRx, p As UInteger
        Dim d As String

        lbRx = Len(RS232RxBuffer)
        If (lbRx > 3) Then
            If (Mid(RS232RxBuffer, 1, 1) = "{") Then
                Inhibicio = True
                Select Case Mid(RS232RxBuffer, 2, 1)
                    Case "R"
                        RB_Repeater.Checked = True
                        RetallRxBuffer()
                    Case "S"
                        RB_Simplex.Checked = True
                        RetallRxBuffer()
                    Case "a"
                        If lbRx >= 98 Then
                            ' Recepció de les dades actuals del Mòdem.
                            TB_MyCall.Text = Mid(RS232RxBuffer, 4, 8)
                            TB_MyCall2.Text = Mid(RS232RxBuffer, 13, 4)
                            CB_UrCall.Text = Mid(RS232RxBuffer, 18, 8)
                            TB_RPT1.Text = Mid(RS232RxBuffer, 27, 8)
                            TB_RPT2.Text = Mid(RS232RxBuffer, 36, 8)
                            TB_CRC.Text = Mid(RS232RxBuffer, 45, 4)
                            TB_Latitude.Text = Mid(RS232RxBuffer, 50, 8)
                            TB_Longitude.Text = Mid(RS232RxBuffer, 59, 9)
                            CB_AutoChangeYourCall.Checked = (Mid(RS232RxBuffer, 69, 1) = "1")
                            CB_StandbyBeep.Checked = (Mid(RS232RxBuffer, 71, 1) = "1")
                            CB_TXgpsaFrame.Checked = (Mid(RS232RxBuffer, 73, 1) = "1")
                            TB_Comment.Text = Mid(RS232RxBuffer, 75, 20)
                            RetallRxBuffer()
                        End If
                    Case "M"
                        d = Date.Now
                        d = Mid(d, 1, 6) + Mid(d, 9, 11)
                        If lbRx >= 50 Then
                            p = InStr(2, RS232RxBuffer, "}")
                            If (p > 2) Then TB_Log.Text += d + ": " + Mid(RS232RxBuffer, 2, p - 2) + Chr(13) + Chr(10)
                            RetallRxBuffer()
                        End If
                    Case Else
                        RetallRxBuffer()
                End Select
                Inhibicio = False
            Else
                RetallRxBuffer()
            End If
        End If
    End Sub
    ' Funció de retard (10mS per unitat)
    Private Sub MS_Delay(ByVal t As UInteger)
        Dim p As String
        Dim c As Color
        Dim ct As Integer
        Dim it As Integer
        Dim min As Integer = 0

        p = L_Status.Text
        c = L_Status.ForeColor
        L_Status.Text = "Wait"
        Application.DoEvents()
        ct = DelayCounter
        L_Status.ForeColor = Color.Red
        it = ct + t
        While ct + 60 * min < it
            Application.DoEvents()
            ct = DelayCounter
            If ct = 0 Then min += 1
        End While
        L_Status.Text = p
        L_Status.ForeColor = c
    End Sub
    'Rutina per activar o descativar els controls quan configuro el Modem
    Private Sub MS_Change_Block(ByVal logic As Boolean)
        Dim l As Boolean

        If (Not Group) Then
            If ComPort.IsOpen Then l = (logic And (Not ComPort.DtrEnable)) Else l = logic
            CB_Comm.Enabled = Not logic
            CheckCom.Enabled = logic

            GB_Options.Enabled = l
            B_MyCall.Enabled = l
            B_Comment.Enabled = l
            B_CRC.Enabled = l
            B_Latitude.Enabled = l
            B_Longitude.Enabled = l
            B_MyCall2.Enabled = l
            B_Read_Config.Enabled = l
            B_RPT1.Enabled = l
            B_RPT2.Enabled = l
            B_WriteData.Enabled = l
            B_YourCall_Change.Enabled = l
            B_Read_Config.Enabled = l
            CB_Remote.Enabled = l
            B_ChangeAll.Enabled = l
            T_Parse.Enabled = l
            B_E.Enabled = l
            B_U.Enabled = l
            B_L.Enabled = l
            B_YourCall_CQ.Enabled = l

            GB_DataCtrl.Enabled = logic
            RB_Simplex.Enabled = l
            RB_Repeater.Enabled = l
            RB_Ctrl.Enabled = logic
            RB_Data.Enabled = logic
        End If
    End Sub
    Private Sub MS_ComStatus()
        ' Activem o desactivem els controls pertinents
        MS_Change_Block(ComPort.IsOpen)
        B_CommOpen.Text = IIf(CheckCom.Enabled, "Disconnect", "Connect")
        L_Status.Text = IIf(CheckCom.Enabled, "Connected", "Disconnected")
    End Sub

    Private Sub MS_Send(ByVal c As Char, ByVal t As String, ByVal l As Byte)
        If (ComPort.IsOpen) Then
            If (Len(t) > 0 Or l = 0) Then
                Try
                    ComPort.Write(c + LSet(t, l) + Chr(13))
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            Else
                MsgBox("Paràmetre incorrecte", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("El port no està obert (" & c & ")(" & ScrollStateAutoScrolling & ")", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Function MS_CRC_CNO(ByVal Buffer As String) As UInteger
        Dim crc As UInteger = &HFFFF
        Dim i, j, ch, xorgflag As Byte

        For j = 1 To Len(Buffer)
            ch = Asc(Mid(Buffer, j, 1))
            For i = 0 To 7
                If (((crc Xor ch) And &H1) = &H1) Then xorgflag = 1 Else xorgflag = 0
                crc >>= 1
                If xorgflag = 1 Then crc = crc Xor &H8408
                ch >>= 1
            Next i
        Next j
        crc = ((Not crc) And &HFFFF)
        Return crc
    End Function
    ' DTR control
    Private Sub CB_DTR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_DTR.CheckedChanged
        If ComPort.IsOpen Then
            ComPort.DtrEnable = CB_DTR.Checked
        Else
            MsgBox("El port no està obert", MsgBoxStyle.Critical)
        End If
    End Sub
    ' RTS Control
    Private Sub CB_RTS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_RTS.CheckedChanged
        If ComPort.IsOpen Then
            ComPort.RtsEnable = CB_RTS.Checked
        Else
            MsgBox("El port no està obert", MsgBoxStyle.Critical)
        End If
    End Sub
    ' Form Load
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Llegeixo els ports COM que tinc instal·lats, amb el Namespace System.IO.Ports -> Imports System.IO.Ports
        Me.Text += "D-STAR DV EA3CNO (by EA3HWN Build " + My.Application.Info.Version.ToString() + ")"
        Me.Width = IIf(Debug, WidthDebug, WidthSimple)
        Try
            Dim ports As String() = SerialPort.GetPortNames()

            If CB_Comm.Items.Count > 0 And ports.Length > 0 Then
                CB_Comm.Items.Clear()
            End If

            If ports.Length > 0 Then
                For Each port As String In ports
                    CB_Comm.Items.Add(port)
                Next
            Else
                MessageBox.Show("No se encontraron puertos COM disponibles en el sistema.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        CB_Comm.SelectedIndex = 0
        MS_ComStatus()
        CB_UrCall.DropDownHeight = 350
    End Sub

    Private Sub B_CommOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_CommOpen.Click
        ' Mirem si el COM està tancat.
        If (CB_Comm.Enabled) Then
            ' Si la combo de coms està activa configurem el COM sel·leccionat, en cas contrari ja estem connectats.
            If ComPort.IsOpen Then ComPort.Close()
            ComPort.PortName = CB_Comm.SelectedItem
            ComPort.BaudRate = 9600
            ComPort.Parity = Parity.None
            ComPort.DataBits = 8
            ComPort.StopBits = StopBits.One
            If Not ComPort.IsOpen Then
                ' Si el Comm no està obert, 
                Try
                    ComPort.Open()
                Catch ex As Exception
                    MessageBox.Show("Error al abrir el puerto COM: " & ex.Message)
                End Try
            End If
        Else
            If ComPort.IsOpen Then ComPort.Close()
        End If
        MS_Delay(DelayChange)
        If ComPort.IsOpen Then MS_Send("I", "", 0)
        MS_ComStatus()
    End Sub

    Private Sub B_Enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Enviar.Click
        If ComPort.IsOpen Then ComPort.Write(TB_Send.Text + Chr(13))
    End Sub
    Private Sub ComPortReceive()
        Dim i, k As Integer
        Dim b As Byte

        i = ComPort.BytesToRead
        If i > 0 Then
            k = 32000 ' Caracters/ASCIIs màxims al buffer de debug.
            RB = ComPort.ReadExisting()
            TB_Buffer.Text += RB
            RS232RxBuffer += RB
            TB_RB_Count.Text += i
            For i = 1 To Len(RB)
                b = Asc(Mid(RB, i, 1))
                TB_Receive.Text += "{" + b.ToString("X2") + "}"
            Next
            i = Len(TB_Buffer.Text)
            If (i > k) Then TB_Buffer.Text = Mid(TB_Buffer.Text, i - k + 1, k)
            i = Len(TB_Receive.Text)
            If (i > 4 * k) Then
                TB_Receive.Text = Mid(TB_Receive.Text, i - k * 4 + 1, k * 4)
                TB_RB_Count.Text = k
            End If
        End If
    End Sub
    Private Sub CheckCom_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCom.Tick
        If ComPort.IsOpen Then Call ComPortReceive()
    End Sub

    Private Sub B_RcbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_RcbClear.Click
        TB_Receive.Text = ""
        TB_RB_Count.Text = "0"
    End Sub

    Private Sub B_YourCall_CQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_YourCall_CQ.Click
        CB_UrCall.Text = "CQCQCQ  "
        Cg_Ur_Call()
    End Sub

    Private Sub B_YourCall_Change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_YourCall_Change.Click
        Cg_Ur_Call()
    End Sub


    Private Sub B_MyCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_MyCall.Click
        Cg_My_Call()
    End Sub

    Private Sub B_MyCall2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_MyCall2.Click
        Cg_My_Call2()
    End Sub

    Private Sub B_RPT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_RPT1.Click
        Cg_RPT1()
    End Sub

    Private Sub B_RPT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_RPT2.Click
        Cg_RPT2()
    End Sub

    Private Sub CB_AutoChangeYourCall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_AutoChangeYourCall.CheckedChanged
        If Not Inhibicio Then Cg_AutoChangeYC()
    End Sub

    Private Sub CB_StandbyBeep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_StandbyBeep.CheckedChanged
        If Not Inhibicio Then Cg_StbyBeep()
    End Sub

    Private Sub B_CRC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_CRC.Click
        Cg_CRC()
    End Sub

    Private Sub B_Latitude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Latitude.Click
        Cg_Latitude()
    End Sub

    Private Sub B_Longitude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Longitude.Click
        Cg_Longitude()
    End Sub

    Private Sub B_WriteData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_WriteData.Click
        Cg_WriteData()
    End Sub

    Private Sub B_Comment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Comment.Click
        Cg_Comment()
    End Sub

    Private Sub B_Read_Config_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Read_Config.Click
        Cg_ReadConfig()
    End Sub
    Private Sub P_Debug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_Debug.Click
        Debug = Not Debug
        Me.Width = IIf(Debug, WidthDebug, WidthSimple)
    End Sub
    Private Sub CB_TXgpsaFrame_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_TXgpsaFrame.CheckedChanged
        If Not Inhibicio Then Cg_Txgpsa()
    End Sub

    Private Sub B_Netejar_Buffer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Netejar_Buffer.Click
        TB_Buffer.Text = ""
    End Sub

    Private Sub RB_Simplex_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Simplex.CheckedChanged
        If Not Inhibicio Then
            If RB_Simplex.Checked Then
                GB_DataCtrl.Enabled = False
                If (RB_Simplex.Enabled And ComPort.IsOpen) Then MS_Send("S", "", 0)
                MS_ComStatus()
            End If
        End If
    End Sub
    Private Sub RB_Repeater_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Repeater.CheckedChanged
        If Not Inhibicio Then
            If RB_Repeater.Checked Then
                GB_DataCtrl.Enabled = False
                If RB_Repeater.Enabled Then MS_Send("R", "", 0)
                MS_ComStatus()
            End If
        End If
    End Sub

    Private Sub RB_Ctrl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Ctrl.CheckedChanged
        CB_DTR.Checked = RB_Data.Checked
        MS_ComStatus()
    End Sub

    Private Sub RB_Data_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Data.CheckedChanged
        CB_DTR.Checked = RB_Data.Checked
        MS_ComStatus()
    End Sub

    Private Sub T_Delay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Delay.Tick
        DelayCounter = IIf(DelayCounter < 65535, DelayCounter + 1, 0)
    End Sub
    Private Sub CB_Remote_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Remote.CheckedChanged
        If (CB_Remote.Checked) Then
            MS_Send("V", "", 0)
            MS_Delay(100)
            If RB_Repeater.Checked Then MS_Send("R", "", 0)
            If RB_Simplex.Checked Then MS_Send("S", "", 0)
        Else
            MS_Send("Q", "", 0)
        End If
        MS_ComStatus()
    End Sub
    Private Sub B_Netejar_Log_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Netejar_Log.Click
        TB_Log.Text = ""
    End Sub

    Private Sub B_ChangeAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ChangeAll.Click
        Dim S As UInteger

        S = DelayChange
        DelayChange = 30
        Cg_Group()
        Cg_My_Call()
        Cg_My_Call2()
        Cg_Ur_Call()
        Cg_RPT1()
        Cg_RPT2()
        Cg_Latitude()
        Cg_Longitude()
        Cg_Comment()
        Cg_CRC()
        Cg_AutoChangeYC()
        Cg_StbyBeep()
        Cg_Txgpsa()
        Cg_UnGroup()
        DelayChange = S
    End Sub
    Private Sub Cg_Group()
        MS_Change_Block(False)
        MS_Send("G", "", 0)
        MS_Delay(DelayChange)
        Group = True
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_UnGroup()
        MS_Change_Block(False)
        MS_Send("U", "", 0)
        MS_Delay(DelayChange)
        Group = False
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_Ur_Call()
        Dim s, r As String
        Dim i, j As UInteger

        s = ";" + CB_UrCall.Text
        TB_Buffer.Text += "<s:" + s.ToString + ">"
        If (s.Length > 0) Then
            i = s.LastIndexOf(";") + 1
            TB_Buffer.Text += "<i:" + i.ToString + ">"
            j = s.Length - i
            TB_Buffer.Text += "<j:" + j.ToString + ">"
            r = Mid(s, i + 1, j)
            TB_Buffer.Text += "<r:" + r.ToString + ">"
            MS_Change_Block(False)
            MS_Send("y", r, 8)
            MS_Delay(DelayChange)
            MS_Change_Block(True)
        End If
    End Sub
    Private Sub Cg_My_Call()
        MS_Change_Block(False)
        MS_Send("m", TB_MyCall.Text, 8)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_My_Call2()
        MS_Change_Block(False)
        MS_Send("n", TB_MyCall2.Text, 4)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_RPT1()
        MS_Change_Block(False)
        MS_Send("r", TB_RPT1.Text, 8)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_RPT2()
        MS_Change_Block(False)
        MS_Send("s", TB_RPT2.Text, 8)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_AutoChangeYC()
        MS_Change_Block(False)
        MS_Send("d", IIf(CB_AutoChangeYourCall.Checked, "1", "0"), 1)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_StbyBeep()
        MS_Change_Block(False)
        MS_Send("b", IIf(CB_StandbyBeep.Checked, "1", "0"), 1)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_CRC()
        Dim CRC_Buffer As String        Dim crc As UInteger

        MS_Change_Block(False)

        CRC_Buffer = LSet(TB_MyCall.Text, 6) + ">APDPRS,DSTAR*:!"
        CRC_Buffer += LSet(TB_Latitude.Text, 8) + "/"
        CRC_Buffer += LSet(TB_Longitude.Text, 9) + "y/"
        CRC_Buffer += LSet(TB_Comment.Text, 20) + Chr(13)
        If (Len(CRC_Buffer) = &H3F) Then
            crc = MS_CRC_CNO(CRC_Buffer)
            TB_CRC.Text = Hex(crc)

            MS_Send("v", TB_CRC.Text, 4)
        Else
            MsgBox("Cadena de codificació CRC incorrecte", MsgBoxStyle.Critical)
        End If
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_Latitude()
        MS_Change_Block(False)
        MS_Send("x", TB_Latitude.Text, 8)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_Longitude()
        MS_Change_Block(False)
        MS_Send("z", TB_Longitude.Text, 9)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_WriteData()
        MS_Change_Block(False)
        MS_Send("w", "", 0)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_Comment()
        MS_Change_Block(False)
        MS_Send("t", TB_Comment.Text, 20)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_ReadConfig()
        MS_Change_Block(False)
        MS_Send("a", "", 0)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub
    Private Sub Cg_Txgpsa()
        MS_Change_Block(False)
        MS_Send("e", IIf(CB_TXgpsaFrame.Checked, "1", "0"), 1)
        MS_Delay(DelayChange)
        MS_Change_Block(True)
    End Sub

    Private Sub T_Parse_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Parse.Tick
        RS232RxBuffer_Parse()
    End Sub
    Private Sub B_E_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_E.Click
        CB_UrCall.Text = "       E"
        Cg_Ur_Call()
    End Sub

    Private Sub B_L_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_L.Click
        CB_UrCall.Text = Mid(CB_UrCall.Text + "       ", 1, 7) + "L"
        Cg_Ur_Call()
    End Sub

    Private Sub B_U_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_U.Click
        CB_UrCall.Text = "       U"
        Cg_Ur_Call()
    End Sub

    Private Sub B_EA3HWN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_EA3HWN.Click
        TB_MyCall.Text = "EA3HWN"
        TB_MyCall2.Text = "V71E"
        CB_UrCall.Text = "CQCQCQ"
        TB_RPT1.Text = "EA3HWN B"
        TB_RPT2.Text = "EA3HWN G"
        TB_Latitude.Text = "41.67050"
        TB_Longitude.Text = "1.8635630"
        TB_Comment.Text = "EA3CNO TEST EA3HWN"
    End Sub

    Private Sub TB_Receive_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Receive.TextChanged
        TB_Receive.SelectionLength = TB_Receive.Text.Length
        TB_Receive.ScrollToCaret()
    End Sub

    Private Sub TB_Buffer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Buffer.TextChanged
        TB_Buffer.SelectionStart = TB_Buffer.Text.Length
        TB_Buffer.ScrollToCaret()
    End Sub

    Private Sub TB_Log_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Log.TextChanged
        TB_Log.SelectionStart = TB_Log.Text.Length
        TB_Log.ScrollToCaret()
    End Sub

    Private Sub B_UrCall_Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_UrCall_Load.Click
        Dim OFD As New OpenFileDialog()
        Dim filePath As String
        Dim line As String

        ' Configurar les propietats del quadre de diàleg
        OFD.Title = "Sel·leccionar archiu de UrCall"
        OFD.Filter = "CSV (*.csv)|*.csv"
        OFD.FilterIndex = 1
        OFD.RestoreDirectory = True

        ' Mostrar el quadre de diàleg
        If OFD.ShowDialog() = DialogResult.OK Then
            filePath = OFD.FileName
            TB_Buffer.Text += "(" + filePath + ")"
            Try
                CB_UrCall.Items.Clear()
                Using reader As New StreamReader(filePath)
                    Do
                        line = reader.ReadLine()
                        If (line IsNot Nothing And Mid(line, 1, 1) <= "9") Then CB_UrCall.Items.Add(line)
                    Loop Until line Is Nothing
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al llegir l'arxiu: " & ex.Message)
            End Try
        End If
    End Sub
End Class