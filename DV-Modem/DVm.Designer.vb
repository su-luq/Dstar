<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DVm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DVm))
        Me.Com = New System.IO.Ports.SerialPort(Me.components)
        Me.CB_DTR = New System.Windows.Forms.CheckBox
        Me.CB_Comm = New System.Windows.Forms.ComboBox
        Me.TB_Send = New System.Windows.Forms.TextBox
        Me.TB_Receive = New System.Windows.Forms.TextBox
        Me.B_Enviar = New System.Windows.Forms.Button
        Me.CheckCom = New System.Windows.Forms.Timer(Me.components)
        Me.B_RcbClear = New System.Windows.Forms.Button
        Me.B_Read_Config = New System.Windows.Forms.Button
        Me.GB_Connection = New System.Windows.Forms.GroupBox
        Me.L_Status = New System.Windows.Forms.Label
        Me.B_CommOpen = New System.Windows.Forms.Button
        Me.RB_Simplex = New System.Windows.Forms.RadioButton
        Me.RB_Repeater = New System.Windows.Forms.RadioButton
        Me.GB_Options = New System.Windows.Forms.GroupBox
        Me.CB_TXgpsaFrame = New System.Windows.Forms.CheckBox
        Me.CB_StandbyBeep = New System.Windows.Forms.CheckBox
        Me.CB_AutoChangeYourCall = New System.Windows.Forms.CheckBox
        Me.P_Debug = New System.Windows.Forms.PictureBox
        Me.GB_CallSigns = New System.Windows.Forms.GroupBox
        Me.B_RPT2 = New System.Windows.Forms.Button
        Me.B_RPT1 = New System.Windows.Forms.Button
        Me.TB_RPT2 = New System.Windows.Forms.TextBox
        Me.L_RPT2 = New System.Windows.Forms.Label
        Me.L_RPT1 = New System.Windows.Forms.Label
        Me.TB_RPT1 = New System.Windows.Forms.TextBox
        Me.B_U = New System.Windows.Forms.Button
        Me.B_UrCall_Load = New System.Windows.Forms.Button
        Me.L_UrCall = New System.Windows.Forms.Label
        Me.B_L = New System.Windows.Forms.Button
        Me.B_MyCall2 = New System.Windows.Forms.Button
        Me.B_E = New System.Windows.Forms.Button
        Me.L_MyCall2 = New System.Windows.Forms.Label
        Me.B_YourCall_CQ = New System.Windows.Forms.Button
        Me.TB_MyCall2 = New System.Windows.Forms.TextBox
        Me.B_YourCall_Change = New System.Windows.Forms.Button
        Me.CB_UrCall = New System.Windows.Forms.ComboBox
        Me.B_MyCall = New System.Windows.Forms.Button
        Me.L_MyCall = New System.Windows.Forms.Label
        Me.TB_MyCall = New System.Windows.Forms.TextBox
        Me.GB_gpsa_Frame = New System.Windows.Forms.GroupBox
        Me.TB_Longitude = New System.Windows.Forms.TextBox
        Me.B_CRC = New System.Windows.Forms.Button
        Me.TB_CRC = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.B_Comment = New System.Windows.Forms.Button
        Me.TB_Comment = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.B_Longitude = New System.Windows.Forms.Button
        Me.L_Longitud = New System.Windows.Forms.Label
        Me.B_Latitude = New System.Windows.Forms.Button
        Me.L_Latitud = New System.Windows.Forms.Label
        Me.TB_Latitude = New System.Windows.Forms.TextBox
        Me.B_WriteData = New System.Windows.Forms.Button
        Me.TB_Buffer = New System.Windows.Forms.TextBox
        Me.TB_RB_Count = New System.Windows.Forms.TextBox
        Me.CB_RTS = New System.Windows.Forms.CheckBox
        Me.G_Debug = New System.Windows.Forms.GroupBox
        Me.B_EA3HWN = New System.Windows.Forms.Button
        Me.B_Netejar_Buffer = New System.Windows.Forms.Button
        Me.GB_Mode = New System.Windows.Forms.GroupBox
        Me.CB_Remote = New System.Windows.Forms.CheckBox
        Me.GB_DataCtrl = New System.Windows.Forms.GroupBox
        Me.RB_Ctrl = New System.Windows.Forms.RadioButton
        Me.RB_Data = New System.Windows.Forms.RadioButton
        Me.T_Delay = New System.Windows.Forms.Timer(Me.components)
        Me.TB_Log = New System.Windows.Forms.TextBox
        Me.B_Netejar_Log = New System.Windows.Forms.Button
        Me.B_ChangeAll = New System.Windows.Forms.Button
        Me.T_Parse = New System.Windows.Forms.Timer(Me.components)
        Me.GB_Connection.SuspendLayout()
        Me.GB_Options.SuspendLayout()
        CType(Me.P_Debug, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_CallSigns.SuspendLayout()
        Me.GB_gpsa_Frame.SuspendLayout()
        Me.G_Debug.SuspendLayout()
        Me.GB_Mode.SuspendLayout()
        Me.GB_DataCtrl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Com
        '
        Me.Com.PortName = "COM7"
        '
        'CB_DTR
        '
        resources.ApplyResources(Me.CB_DTR, "CB_DTR")
        Me.CB_DTR.Name = "CB_DTR"
        Me.CB_DTR.TabStop = False
        Me.CB_DTR.UseVisualStyleBackColor = True
        '
        'CB_Comm
        '
        resources.ApplyResources(Me.CB_Comm, "CB_Comm")
        Me.CB_Comm.FormattingEnabled = True
        Me.CB_Comm.Name = "CB_Comm"
        Me.CB_Comm.Sorted = True
        '
        'TB_Send
        '
        Me.TB_Send.AcceptsReturn = True
        resources.ApplyResources(Me.TB_Send, "TB_Send")
        Me.TB_Send.Name = "TB_Send"
        Me.TB_Send.TabStop = False
        '
        'TB_Receive
        '
        resources.ApplyResources(Me.TB_Receive, "TB_Receive")
        Me.TB_Receive.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TB_Receive.Name = "TB_Receive"
        Me.TB_Receive.ReadOnly = True
        Me.TB_Receive.TabStop = False
        '
        'B_Enviar
        '
        resources.ApplyResources(Me.B_Enviar, "B_Enviar")
        Me.B_Enviar.Name = "B_Enviar"
        Me.B_Enviar.TabStop = False
        Me.B_Enviar.UseVisualStyleBackColor = True
        '
        'CheckCom
        '
        '
        'B_RcbClear
        '
        resources.ApplyResources(Me.B_RcbClear, "B_RcbClear")
        Me.B_RcbClear.Name = "B_RcbClear"
        Me.B_RcbClear.TabStop = False
        Me.B_RcbClear.UseVisualStyleBackColor = True
        '
        'B_Read_Config
        '
        resources.ApplyResources(Me.B_Read_Config, "B_Read_Config")
        Me.B_Read_Config.Name = "B_Read_Config"
        Me.B_Read_Config.UseVisualStyleBackColor = True
        '
        'GB_Connection
        '
        Me.GB_Connection.Controls.Add(Me.L_Status)
        Me.GB_Connection.Controls.Add(Me.B_CommOpen)
        Me.GB_Connection.Controls.Add(Me.CB_Comm)
        resources.ApplyResources(Me.GB_Connection, "GB_Connection")
        Me.GB_Connection.Name = "GB_Connection"
        Me.GB_Connection.TabStop = False
        '
        'L_Status
        '
        resources.ApplyResources(Me.L_Status, "L_Status")
        Me.L_Status.ForeColor = System.Drawing.Color.Red
        Me.L_Status.Name = "L_Status"
        '
        'B_CommOpen
        '
        resources.ApplyResources(Me.B_CommOpen, "B_CommOpen")
        Me.B_CommOpen.Name = "B_CommOpen"
        Me.B_CommOpen.UseVisualStyleBackColor = True
        '
        'RB_Simplex
        '
        resources.ApplyResources(Me.RB_Simplex, "RB_Simplex")
        Me.RB_Simplex.Checked = True
        Me.RB_Simplex.Name = "RB_Simplex"
        Me.RB_Simplex.TabStop = True
        Me.RB_Simplex.UseVisualStyleBackColor = True
        '
        'RB_Repeater
        '
        resources.ApplyResources(Me.RB_Repeater, "RB_Repeater")
        Me.RB_Repeater.Name = "RB_Repeater"
        Me.RB_Repeater.UseVisualStyleBackColor = True
        '
        'GB_Options
        '
        Me.GB_Options.Controls.Add(Me.CB_TXgpsaFrame)
        Me.GB_Options.Controls.Add(Me.CB_StandbyBeep)
        Me.GB_Options.Controls.Add(Me.CB_AutoChangeYourCall)
        resources.ApplyResources(Me.GB_Options, "GB_Options")
        Me.GB_Options.Name = "GB_Options"
        Me.GB_Options.TabStop = False
        '
        'CB_TXgpsaFrame
        '
        resources.ApplyResources(Me.CB_TXgpsaFrame, "CB_TXgpsaFrame")
        Me.CB_TXgpsaFrame.Name = "CB_TXgpsaFrame"
        Me.CB_TXgpsaFrame.TabStop = False
        Me.CB_TXgpsaFrame.UseVisualStyleBackColor = True
        '
        'CB_StandbyBeep
        '
        resources.ApplyResources(Me.CB_StandbyBeep, "CB_StandbyBeep")
        Me.CB_StandbyBeep.Name = "CB_StandbyBeep"
        Me.CB_StandbyBeep.TabStop = False
        Me.CB_StandbyBeep.UseVisualStyleBackColor = True
        '
        'CB_AutoChangeYourCall
        '
        resources.ApplyResources(Me.CB_AutoChangeYourCall, "CB_AutoChangeYourCall")
        Me.CB_AutoChangeYourCall.Name = "CB_AutoChangeYourCall"
        Me.CB_AutoChangeYourCall.TabStop = False
        Me.CB_AutoChangeYourCall.UseVisualStyleBackColor = True
        '
        'P_Debug
        '
        resources.ApplyResources(Me.P_Debug, "P_Debug")
        Me.P_Debug.Name = "P_Debug"
        Me.P_Debug.TabStop = False
        '
        'GB_CallSigns
        '
        resources.ApplyResources(Me.GB_CallSigns, "GB_CallSigns")
        Me.GB_CallSigns.Controls.Add(Me.B_RPT2)
        Me.GB_CallSigns.Controls.Add(Me.B_RPT1)
        Me.GB_CallSigns.Controls.Add(Me.TB_RPT2)
        Me.GB_CallSigns.Controls.Add(Me.L_RPT2)
        Me.GB_CallSigns.Controls.Add(Me.L_RPT1)
        Me.GB_CallSigns.Controls.Add(Me.TB_RPT1)
        Me.GB_CallSigns.Controls.Add(Me.B_U)
        Me.GB_CallSigns.Controls.Add(Me.B_UrCall_Load)
        Me.GB_CallSigns.Controls.Add(Me.L_UrCall)
        Me.GB_CallSigns.Controls.Add(Me.B_L)
        Me.GB_CallSigns.Controls.Add(Me.B_MyCall2)
        Me.GB_CallSigns.Controls.Add(Me.B_E)
        Me.GB_CallSigns.Controls.Add(Me.L_MyCall2)
        Me.GB_CallSigns.Controls.Add(Me.B_YourCall_CQ)
        Me.GB_CallSigns.Controls.Add(Me.TB_MyCall2)
        Me.GB_CallSigns.Controls.Add(Me.B_YourCall_Change)
        Me.GB_CallSigns.Controls.Add(Me.CB_UrCall)
        Me.GB_CallSigns.Controls.Add(Me.B_MyCall)
        Me.GB_CallSigns.Controls.Add(Me.L_MyCall)
        Me.GB_CallSigns.Controls.Add(Me.TB_MyCall)
        Me.GB_CallSigns.Name = "GB_CallSigns"
        Me.GB_CallSigns.TabStop = False
        '
        'B_RPT2
        '
        resources.ApplyResources(Me.B_RPT2, "B_RPT2")
        Me.B_RPT2.Name = "B_RPT2"
        Me.B_RPT2.UseVisualStyleBackColor = True
        '
        'B_RPT1
        '
        resources.ApplyResources(Me.B_RPT1, "B_RPT1")
        Me.B_RPT1.Name = "B_RPT1"
        Me.B_RPT1.UseVisualStyleBackColor = True
        '
        'TB_RPT2
        '
        Me.TB_RPT2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.TB_RPT2, "TB_RPT2")
        Me.TB_RPT2.MaximumSize = New System.Drawing.Size(80, 20)
        Me.TB_RPT2.Name = "TB_RPT2"
        '
        'L_RPT2
        '
        resources.ApplyResources(Me.L_RPT2, "L_RPT2")
        Me.L_RPT2.Name = "L_RPT2"
        '
        'L_RPT1
        '
        resources.ApplyResources(Me.L_RPT1, "L_RPT1")
        Me.L_RPT1.Name = "L_RPT1"
        '
        'TB_RPT1
        '
        Me.TB_RPT1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.TB_RPT1, "TB_RPT1")
        Me.TB_RPT1.MaximumSize = New System.Drawing.Size(90, 20)
        Me.TB_RPT1.Name = "TB_RPT1"
        '
        'B_U
        '
        resources.ApplyResources(Me.B_U, "B_U")
        Me.B_U.MaximumSize = New System.Drawing.Size(20, 23)
        Me.B_U.Name = "B_U"
        Me.B_U.UseVisualStyleBackColor = True
        '
        'B_UrCall_Load
        '
        resources.ApplyResources(Me.B_UrCall_Load, "B_UrCall_Load")
        Me.B_UrCall_Load.Name = "B_UrCall_Load"
        Me.B_UrCall_Load.UseVisualStyleBackColor = True
        '
        'L_UrCall
        '
        resources.ApplyResources(Me.L_UrCall, "L_UrCall")
        Me.L_UrCall.Name = "L_UrCall"
        '
        'B_L
        '
        resources.ApplyResources(Me.B_L, "B_L")
        Me.B_L.MaximumSize = New System.Drawing.Size(20, 23)
        Me.B_L.Name = "B_L"
        Me.B_L.UseVisualStyleBackColor = True
        '
        'B_MyCall2
        '
        resources.ApplyResources(Me.B_MyCall2, "B_MyCall2")
        Me.B_MyCall2.Name = "B_MyCall2"
        Me.B_MyCall2.UseVisualStyleBackColor = True
        '
        'B_E
        '
        resources.ApplyResources(Me.B_E, "B_E")
        Me.B_E.MaximumSize = New System.Drawing.Size(20, 23)
        Me.B_E.Name = "B_E"
        Me.B_E.UseVisualStyleBackColor = True
        '
        'L_MyCall2
        '
        resources.ApplyResources(Me.L_MyCall2, "L_MyCall2")
        Me.L_MyCall2.Name = "L_MyCall2"
        '
        'B_YourCall_CQ
        '
        resources.ApplyResources(Me.B_YourCall_CQ, "B_YourCall_CQ")
        Me.B_YourCall_CQ.MaximumSize = New System.Drawing.Size(23, 23)
        Me.B_YourCall_CQ.Name = "B_YourCall_CQ"
        Me.B_YourCall_CQ.UseVisualStyleBackColor = True
        '
        'TB_MyCall2
        '
        resources.ApplyResources(Me.TB_MyCall2, "TB_MyCall2")
        Me.TB_MyCall2.MaximumSize = New System.Drawing.Size(50, 20)
        Me.TB_MyCall2.Name = "TB_MyCall2"
        '
        'B_YourCall_Change
        '
        resources.ApplyResources(Me.B_YourCall_Change, "B_YourCall_Change")
        Me.B_YourCall_Change.Name = "B_YourCall_Change"
        Me.B_YourCall_Change.UseVisualStyleBackColor = True
        '
        'CB_UrCall
        '
        resources.ApplyResources(Me.CB_UrCall, "CB_UrCall")
        Me.CB_UrCall.FormattingEnabled = True
        Me.CB_UrCall.Name = "CB_UrCall"
        '
        'B_MyCall
        '
        resources.ApplyResources(Me.B_MyCall, "B_MyCall")
        Me.B_MyCall.Name = "B_MyCall"
        Me.B_MyCall.UseVisualStyleBackColor = True
        '
        'L_MyCall
        '
        resources.ApplyResources(Me.L_MyCall, "L_MyCall")
        Me.L_MyCall.Name = "L_MyCall"
        '
        'TB_MyCall
        '
        Me.TB_MyCall.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.TB_MyCall, "TB_MyCall")
        Me.TB_MyCall.MaximumSize = New System.Drawing.Size(90, 21)
        Me.TB_MyCall.MinimumSize = New System.Drawing.Size(90, 20)
        Me.TB_MyCall.Name = "TB_MyCall"
        '
        'GB_gpsa_Frame
        '
        resources.ApplyResources(Me.GB_gpsa_Frame, "GB_gpsa_Frame")
        Me.GB_gpsa_Frame.Controls.Add(Me.TB_Longitude)
        Me.GB_gpsa_Frame.Controls.Add(Me.B_CRC)
        Me.GB_gpsa_Frame.Controls.Add(Me.TB_CRC)
        Me.GB_gpsa_Frame.Controls.Add(Me.Label2)
        Me.GB_gpsa_Frame.Controls.Add(Me.B_Comment)
        Me.GB_gpsa_Frame.Controls.Add(Me.TB_Comment)
        Me.GB_gpsa_Frame.Controls.Add(Me.Label1)
        Me.GB_gpsa_Frame.Controls.Add(Me.B_Longitude)
        Me.GB_gpsa_Frame.Controls.Add(Me.L_Longitud)
        Me.GB_gpsa_Frame.Controls.Add(Me.B_Latitude)
        Me.GB_gpsa_Frame.Controls.Add(Me.L_Latitud)
        Me.GB_gpsa_Frame.Controls.Add(Me.TB_Latitude)
        Me.GB_gpsa_Frame.Name = "GB_gpsa_Frame"
        Me.GB_gpsa_Frame.TabStop = False
        '
        'TB_Longitude
        '
        resources.ApplyResources(Me.TB_Longitude, "TB_Longitude")
        Me.TB_Longitude.MaximumSize = New System.Drawing.Size(90, 20)
        Me.TB_Longitude.MinimumSize = New System.Drawing.Size(90, 20)
        Me.TB_Longitude.Name = "TB_Longitude"
        '
        'B_CRC
        '
        resources.ApplyResources(Me.B_CRC, "B_CRC")
        Me.B_CRC.Name = "B_CRC"
        Me.B_CRC.UseVisualStyleBackColor = True
        '
        'TB_CRC
        '
        resources.ApplyResources(Me.TB_CRC, "TB_CRC")
        Me.TB_CRC.MaximumSize = New System.Drawing.Size(55, 20)
        Me.TB_CRC.MinimumSize = New System.Drawing.Size(30, 20)
        Me.TB_CRC.Name = "TB_CRC"
        Me.TB_CRC.ReadOnly = True
        Me.TB_CRC.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'B_Comment
        '
        resources.ApplyResources(Me.B_Comment, "B_Comment")
        Me.B_Comment.Name = "B_Comment"
        Me.B_Comment.UseVisualStyleBackColor = True
        '
        'TB_Comment
        '
        resources.ApplyResources(Me.TB_Comment, "TB_Comment")
        Me.TB_Comment.MaximumSize = New System.Drawing.Size(216, 20)
        Me.TB_Comment.Name = "TB_Comment"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'B_Longitude
        '
        resources.ApplyResources(Me.B_Longitude, "B_Longitude")
        Me.B_Longitude.Name = "B_Longitude"
        Me.B_Longitude.UseVisualStyleBackColor = True
        '
        'L_Longitud
        '
        resources.ApplyResources(Me.L_Longitud, "L_Longitud")
        Me.L_Longitud.Name = "L_Longitud"
        '
        'B_Latitude
        '
        resources.ApplyResources(Me.B_Latitude, "B_Latitude")
        Me.B_Latitude.Name = "B_Latitude"
        Me.B_Latitude.UseVisualStyleBackColor = True
        '
        'L_Latitud
        '
        resources.ApplyResources(Me.L_Latitud, "L_Latitud")
        Me.L_Latitud.Name = "L_Latitud"
        '
        'TB_Latitude
        '
        resources.ApplyResources(Me.TB_Latitude, "TB_Latitude")
        Me.TB_Latitude.MaximumSize = New System.Drawing.Size(90, 20)
        Me.TB_Latitude.Name = "TB_Latitude"
        '
        'B_WriteData
        '
        resources.ApplyResources(Me.B_WriteData, "B_WriteData")
        Me.B_WriteData.Name = "B_WriteData"
        Me.B_WriteData.UseVisualStyleBackColor = True
        '
        'TB_Buffer
        '
        resources.ApplyResources(Me.TB_Buffer, "TB_Buffer")
        Me.TB_Buffer.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TB_Buffer.Name = "TB_Buffer"
        Me.TB_Buffer.ReadOnly = True
        Me.TB_Buffer.TabStop = False
        '
        'TB_RB_Count
        '
        resources.ApplyResources(Me.TB_RB_Count, "TB_RB_Count")
        Me.TB_RB_Count.Name = "TB_RB_Count"
        Me.TB_RB_Count.TabStop = False
        '
        'CB_RTS
        '
        resources.ApplyResources(Me.CB_RTS, "CB_RTS")
        Me.CB_RTS.Name = "CB_RTS"
        Me.CB_RTS.TabStop = False
        Me.CB_RTS.UseVisualStyleBackColor = True
        '
        'G_Debug
        '
        Me.G_Debug.Controls.Add(Me.B_EA3HWN)
        Me.G_Debug.Controls.Add(Me.TB_Send)
        Me.G_Debug.Controls.Add(Me.TB_RB_Count)
        Me.G_Debug.Controls.Add(Me.B_Netejar_Buffer)
        Me.G_Debug.Controls.Add(Me.CB_RTS)
        Me.G_Debug.Controls.Add(Me.B_Enviar)
        Me.G_Debug.Controls.Add(Me.CB_DTR)
        Me.G_Debug.Controls.Add(Me.TB_Buffer)
        Me.G_Debug.Controls.Add(Me.TB_Receive)
        Me.G_Debug.Controls.Add(Me.B_RcbClear)
        resources.ApplyResources(Me.G_Debug, "G_Debug")
        Me.G_Debug.Name = "G_Debug"
        Me.G_Debug.TabStop = False
        '
        'B_EA3HWN
        '
        resources.ApplyResources(Me.B_EA3HWN, "B_EA3HWN")
        Me.B_EA3HWN.Name = "B_EA3HWN"
        Me.B_EA3HWN.TabStop = False
        Me.B_EA3HWN.UseVisualStyleBackColor = True
        '
        'B_Netejar_Buffer
        '
        resources.ApplyResources(Me.B_Netejar_Buffer, "B_Netejar_Buffer")
        Me.B_Netejar_Buffer.Name = "B_Netejar_Buffer"
        Me.B_Netejar_Buffer.TabStop = False
        Me.B_Netejar_Buffer.UseVisualStyleBackColor = True
        '
        'GB_Mode
        '
        Me.GB_Mode.Controls.Add(Me.CB_Remote)
        Me.GB_Mode.Controls.Add(Me.RB_Repeater)
        Me.GB_Mode.Controls.Add(Me.RB_Simplex)
        resources.ApplyResources(Me.GB_Mode, "GB_Mode")
        Me.GB_Mode.Name = "GB_Mode"
        Me.GB_Mode.TabStop = False
        '
        'CB_Remote
        '
        resources.ApplyResources(Me.CB_Remote, "CB_Remote")
        Me.CB_Remote.Name = "CB_Remote"
        Me.CB_Remote.UseVisualStyleBackColor = True
        '
        'GB_DataCtrl
        '
        Me.GB_DataCtrl.Controls.Add(Me.RB_Ctrl)
        Me.GB_DataCtrl.Controls.Add(Me.RB_Data)
        resources.ApplyResources(Me.GB_DataCtrl, "GB_DataCtrl")
        Me.GB_DataCtrl.Name = "GB_DataCtrl"
        Me.GB_DataCtrl.TabStop = False
        '
        'RB_Ctrl
        '
        resources.ApplyResources(Me.RB_Ctrl, "RB_Ctrl")
        Me.RB_Ctrl.Checked = True
        Me.RB_Ctrl.Name = "RB_Ctrl"
        Me.RB_Ctrl.TabStop = True
        Me.RB_Ctrl.UseVisualStyleBackColor = True
        '
        'RB_Data
        '
        resources.ApplyResources(Me.RB_Data, "RB_Data")
        Me.RB_Data.Name = "RB_Data"
        Me.RB_Data.UseVisualStyleBackColor = True
        '
        'T_Delay
        '
        Me.T_Delay.Enabled = True
        Me.T_Delay.Interval = 10
        '
        'TB_Log
        '
        resources.ApplyResources(Me.TB_Log, "TB_Log")
        Me.TB_Log.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TB_Log.Name = "TB_Log"
        Me.TB_Log.ReadOnly = True
        Me.TB_Log.TabStop = False
        '
        'B_Netejar_Log
        '
        resources.ApplyResources(Me.B_Netejar_Log, "B_Netejar_Log")
        Me.B_Netejar_Log.Name = "B_Netejar_Log"
        Me.B_Netejar_Log.TabStop = False
        Me.B_Netejar_Log.UseVisualStyleBackColor = True
        '
        'B_ChangeAll
        '
        resources.ApplyResources(Me.B_ChangeAll, "B_ChangeAll")
        Me.B_ChangeAll.Name = "B_ChangeAll"
        Me.B_ChangeAll.UseVisualStyleBackColor = True
        '
        'T_Parse
        '
        Me.T_Parse.Interval = 1000
        '
        'DVm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.P_Debug)
        Me.Controls.Add(Me.B_ChangeAll)
        Me.Controls.Add(Me.B_Netejar_Log)
        Me.Controls.Add(Me.TB_Log)
        Me.Controls.Add(Me.GB_DataCtrl)
        Me.Controls.Add(Me.GB_Mode)
        Me.Controls.Add(Me.B_WriteData)
        Me.Controls.Add(Me.B_Read_Config)
        Me.Controls.Add(Me.G_Debug)
        Me.Controls.Add(Me.GB_gpsa_Frame)
        Me.Controls.Add(Me.GB_CallSigns)
        Me.Controls.Add(Me.GB_Options)
        Me.Controls.Add(Me.GB_Connection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "DVm"
        Me.GB_Connection.ResumeLayout(False)
        Me.GB_Connection.PerformLayout()
        Me.GB_Options.ResumeLayout(False)
        Me.GB_Options.PerformLayout()
        CType(Me.P_Debug, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_CallSigns.ResumeLayout(False)
        Me.GB_CallSigns.PerformLayout()
        Me.GB_gpsa_Frame.ResumeLayout(False)
        Me.GB_gpsa_Frame.PerformLayout()
        Me.G_Debug.ResumeLayout(False)
        Me.G_Debug.PerformLayout()
        Me.GB_Mode.ResumeLayout(False)
        Me.GB_Mode.PerformLayout()
        Me.GB_DataCtrl.ResumeLayout(False)
        Me.GB_DataCtrl.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Com As System.IO.Ports.SerialPort
    Friend WithEvents CB_DTR As System.Windows.Forms.CheckBox
    Friend WithEvents CB_Comm As System.Windows.Forms.ComboBox
    Friend WithEvents TB_Send As System.Windows.Forms.TextBox
    Friend WithEvents TB_Receive As System.Windows.Forms.TextBox
    Friend WithEvents B_Enviar As System.Windows.Forms.Button
    Friend WithEvents CheckCom As System.Windows.Forms.Timer
    Friend WithEvents B_RcbClear As System.Windows.Forms.Button
    Friend WithEvents B_Read_Config As System.Windows.Forms.Button
    Friend WithEvents GB_Connection As System.Windows.Forms.GroupBox
    Friend WithEvents GB_Options As System.Windows.Forms.GroupBox
    Friend WithEvents CB_AutoChangeYourCall As System.Windows.Forms.CheckBox
    Friend WithEvents CB_StandbyBeep As System.Windows.Forms.CheckBox
    Friend WithEvents CB_TXgpsaFrame As System.Windows.Forms.CheckBox
    Friend WithEvents GB_CallSigns As System.Windows.Forms.GroupBox
    Friend WithEvents B_YourCall_Change As System.Windows.Forms.Button
    Friend WithEvents B_YourCall_CQ As System.Windows.Forms.Button
    Friend WithEvents B_RPT1 As System.Windows.Forms.Button
    Friend WithEvents TB_RPT1 As System.Windows.Forms.TextBox
    Friend WithEvents B_RPT2 As System.Windows.Forms.Button
    Friend WithEvents TB_RPT2 As System.Windows.Forms.TextBox
    Friend WithEvents B_MyCall As System.Windows.Forms.Button
    Friend WithEvents TB_MyCall As System.Windows.Forms.TextBox
    Friend WithEvents B_MyCall2 As System.Windows.Forms.Button
    Friend WithEvents TB_MyCall2 As System.Windows.Forms.TextBox
    Friend WithEvents GB_gpsa_Frame As System.Windows.Forms.GroupBox
    Friend WithEvents B_CRC As System.Windows.Forms.Button
    Friend WithEvents TB_CRC As System.Windows.Forms.TextBox
    Friend WithEvents B_Comment As System.Windows.Forms.Button
    Friend WithEvents TB_Comment As System.Windows.Forms.TextBox
    Friend WithEvents B_Longitude As System.Windows.Forms.Button
    Friend WithEvents TB_Longitude As System.Windows.Forms.TextBox
    Friend WithEvents B_Latitude As System.Windows.Forms.Button
    Friend WithEvents TB_Latitude As System.Windows.Forms.TextBox
    Friend WithEvents B_WriteData As System.Windows.Forms.Button
    Friend WithEvents TB_Buffer As System.Windows.Forms.TextBox
    Friend WithEvents TB_RB_Count As System.Windows.Forms.TextBox
    Friend WithEvents L_Status As System.Windows.Forms.Label
    Friend WithEvents CB_RTS As System.Windows.Forms.CheckBox
    Friend WithEvents G_Debug As System.Windows.Forms.GroupBox
    Friend WithEvents B_CommOpen As System.Windows.Forms.Button
    Friend WithEvents B_Netejar_Buffer As System.Windows.Forms.Button
    Friend WithEvents RB_Repeater As System.Windows.Forms.RadioButton
    Friend WithEvents RB_Simplex As System.Windows.Forms.RadioButton
    Friend WithEvents GB_Mode As System.Windows.Forms.GroupBox
    Protected Friend WithEvents GB_DataCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents RB_Ctrl As System.Windows.Forms.RadioButton
    Friend WithEvents RB_Data As System.Windows.Forms.RadioButton
    Friend WithEvents T_Delay As System.Windows.Forms.Timer
    Friend WithEvents CB_Remote As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Log As System.Windows.Forms.TextBox
    Friend WithEvents B_Netejar_Log As System.Windows.Forms.Button
    Friend WithEvents P_Debug As System.Windows.Forms.PictureBox
    Friend WithEvents B_ChangeAll As System.Windows.Forms.Button
    Friend WithEvents T_Parse As System.Windows.Forms.Timer
    Friend WithEvents B_L As System.Windows.Forms.Button
    Friend WithEvents B_E As System.Windows.Forms.Button
    Friend WithEvents B_U As System.Windows.Forms.Button
    Friend WithEvents B_EA3HWN As System.Windows.Forms.Button
    Friend WithEvents B_UrCall_Load As System.Windows.Forms.Button
    Friend WithEvents CB_UrCall As System.Windows.Forms.ComboBox
    Friend WithEvents L_MyCall2 As System.Windows.Forms.Label
    Friend WithEvents L_MyCall As System.Windows.Forms.Label
    Friend WithEvents L_UrCall As System.Windows.Forms.Label
    Friend WithEvents L_RPT2 As System.Windows.Forms.Label
    Friend WithEvents L_RPT1 As System.Windows.Forms.Label
    Friend WithEvents L_Latitud As System.Windows.Forms.Label
    Friend WithEvents L_Longitud As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
