using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        List<byte> receiveAreaContexList = new List<byte>();
        public StringBuilder receiveAreaTempBuilder = new StringBuilder();
        public delegate void UpdataReceiveAreaDel(string s);
        public bool pauseReceiveDate = false;
        public FrameFormatContext frameFormatContext = new FrameFormatContext();
        public BaseFrame baseFrame = new BaseFrame();
        public Queue<byte> frameByteQueue = new Queue<byte>();
        public OpenFileDialog openFileDialog = new OpenFileDialog();
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DTR_chb = new System.Windows.Forms.CheckBox();
            this.RTS_chb = new System.Windows.Forms.CheckBox();
            this.openOrClosePort_btn = new System.Windows.Forms.Button();
            this.stopBits_cmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataBits_cmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.parity_cmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.baudRate_cmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PortName_cmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.portStatus_ssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sendCount_ssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.receiveCount_ssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.erroByteCount_ssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.erroFrameCount_ssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.autoSendTime_txt = new System.Windows.Forms.TextBox();
            this.sendFilePath_tb = new System.Windows.Forms.TextBox();
            this.SendFile_btn = new System.Windows.Forms.Button();
            this.chooseOpenFile_btn = new System.Windows.Forms.Button();
            this.hexa_chb = new System.Windows.Forms.CheckBox();
            this.autoSend_chb = new System.Windows.Forms.CheckBox();
            this.clearSend = new System.Windows.Forms.Button();
            this.manuSend_btn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sendArea_rtb = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pauseOrContinue_btn = new System.Windows.Forms.Button();
            this.receiveArea_rtb = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SaveFilePath_tb = new System.Windows.Forms.TextBox();
            this.saveToFile_btn = new System.Windows.Forms.Button();
            this.chooseSaveFolder_btn = new System.Windows.Forms.Button();
            this.clearReceiveArea = new System.Windows.Forms.Button();
            this.receiveHex_chb = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.frameData4_tb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.frameData3_tb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.frameData2_tb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.frameData1_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.frame_rtb = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.frameDecode_chb = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort1_ErrorReceived);
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DTR_chb);
            this.groupBox1.Controls.Add(this.RTS_chb);
            this.groupBox1.Controls.Add(this.openOrClosePort_btn);
            this.groupBox1.Controls.Add(this.stopBits_cmb);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dataBits_cmb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.parity_cmb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.baudRate_cmb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PortName_cmb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 390);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置";
            // 
            // DTR_chb
            // 
            this.DTR_chb.AutoSize = true;
            this.DTR_chb.Location = new System.Drawing.Point(212, 300);
            this.DTR_chb.Name = "DTR_chb";
            this.DTR_chb.Size = new System.Drawing.Size(61, 22);
            this.DTR_chb.TabIndex = 12;
            this.DTR_chb.Text = "DTR";
            this.DTR_chb.UseVisualStyleBackColor = true;
            this.DTR_chb.CheckedChanged += new System.EventHandler(this.DTR_chb_CheckedChanged);
            // 
            // RTS_chb
            // 
            this.RTS_chb.AutoSize = true;
            this.RTS_chb.Location = new System.Drawing.Point(30, 300);
            this.RTS_chb.Name = "RTS_chb";
            this.RTS_chb.Size = new System.Drawing.Size(61, 22);
            this.RTS_chb.TabIndex = 11;
            this.RTS_chb.Text = "RTS";
            this.RTS_chb.UseVisualStyleBackColor = true;
            this.RTS_chb.CheckedChanged += new System.EventHandler(this.RTS_chb_CheckedChanged);
            // 
            // openOrClosePort_btn
            // 
            this.openOrClosePort_btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.openOrClosePort_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.openOrClosePort_btn.Location = new System.Drawing.Point(3, 329);
            this.openOrClosePort_btn.Name = "openOrClosePort_btn";
            this.openOrClosePort_btn.Size = new System.Drawing.Size(302, 58);
            this.openOrClosePort_btn.TabIndex = 10;
            this.openOrClosePort_btn.Text = "打开串口";
            this.openOrClosePort_btn.UseVisualStyleBackColor = false;
            this.openOrClosePort_btn.Click += new System.EventHandler(this.OpenOrClosePort_btn_Click);
            // 
            // stopBits_cmb
            // 
            this.stopBits_cmb.FormattingEnabled = true;
            this.stopBits_cmb.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.stopBits_cmb.Location = new System.Drawing.Point(110, 248);
            this.stopBits_cmb.Name = "stopBits_cmb";
            this.stopBits_cmb.Size = new System.Drawing.Size(173, 26);
            this.stopBits_cmb.TabIndex = 9;
            this.stopBits_cmb.SelectedIndexChanged += new System.EventHandler(this.StopBits_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "停止位";
            // 
            // dataBits_cmb
            // 
            this.dataBits_cmb.FormattingEnabled = true;
            this.dataBits_cmb.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.dataBits_cmb.Location = new System.Drawing.Point(110, 198);
            this.dataBits_cmb.Name = "dataBits_cmb";
            this.dataBits_cmb.Size = new System.Drawing.Size(173, 26);
            this.dataBits_cmb.TabIndex = 7;
            this.dataBits_cmb.SelectedIndexChanged += new System.EventHandler(this.dataBits_cmb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "数据位";
            // 
            // parity_cmb
            // 
            this.parity_cmb.FormattingEnabled = true;
            this.parity_cmb.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN"});
            this.parity_cmb.Location = new System.Drawing.Point(110, 145);
            this.parity_cmb.Name = "parity_cmb";
            this.parity_cmb.Size = new System.Drawing.Size(173, 26);
            this.parity_cmb.TabIndex = 5;
            this.parity_cmb.SelectedIndexChanged += new System.EventHandler(this.Parity_cmb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "校验类型";
            // 
            // baudRate_cmb
            // 
            this.baudRate_cmb.FormattingEnabled = true;
            this.baudRate_cmb.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "115200"});
            this.baudRate_cmb.Location = new System.Drawing.Point(110, 94);
            this.baudRate_cmb.Name = "baudRate_cmb";
            this.baudRate_cmb.Size = new System.Drawing.Size(173, 26);
            this.baudRate_cmb.TabIndex = 3;
            this.baudRate_cmb.SelectedIndexChanged += new System.EventHandler(this.BaudRate_cmb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率";
            // 
            // PortName_cmb
            // 
            this.PortName_cmb.FormattingEnabled = true;
            this.PortName_cmb.Location = new System.Drawing.Point(110, 36);
            this.PortName_cmb.Name = "PortName_cmb";
            this.PortName_cmb.Size = new System.Drawing.Size(173, 26);
            this.PortName_cmb.TabIndex = 1;
            this.PortName_cmb.SelectedIndexChanged += new System.EventHandler(this.PortName_cmb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.portStatus_ssl,
            this.toolStripStatusLabel6,
            this.sendCount_ssl,
            this.toolStripStatusLabel7,
            this.receiveCount_ssl,
            this.toolStripStatusLabel5,
            this.erroByteCount_ssl,
            this.toolStripStatusLabel8,
            this.erroFrameCount_ssl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 842);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1242, 31);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(100, 24);
            this.toolStripStatusLabel4.Text = "串口状态：";
            // 
            // portStatus_ssl
            // 
            this.portStatus_ssl.ActiveLinkColor = System.Drawing.Color.LightGray;
            this.portStatus_ssl.AutoSize = false;
            this.portStatus_ssl.BackColor = System.Drawing.Color.Red;
            this.portStatus_ssl.Name = "portStatus_ssl";
            this.portStatus_ssl.Size = new System.Drawing.Size(24, 24);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Margin = new System.Windows.Forms.Padding(50, 4, 0, 3);
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(139, 24);
            this.toolStripStatusLabel6.Text = "发送byte计数：";
            // 
            // sendCount_ssl
            // 
            this.sendCount_ssl.Name = "sendCount_ssl";
            this.sendCount_ssl.Size = new System.Drawing.Size(21, 24);
            this.sendCount_ssl.Text = "0";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Margin = new System.Windows.Forms.Padding(50, 4, 0, 3);
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(139, 24);
            this.toolStripStatusLabel7.Text = "接收byte计数：";
            // 
            // receiveCount_ssl
            // 
            this.receiveCount_ssl.AutoSize = false;
            this.receiveCount_ssl.Name = "receiveCount_ssl";
            this.receiveCount_ssl.Size = new System.Drawing.Size(50, 24);
            this.receiveCount_ssl.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Margin = new System.Windows.Forms.Padding(50, 4, 0, 3);
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(118, 24);
            this.toolStripStatusLabel5.Text = "错误字节数：";
            // 
            // erroByteCount_ssl
            // 
            this.erroByteCount_ssl.Name = "erroByteCount_ssl";
            this.erroByteCount_ssl.Size = new System.Drawing.Size(21, 24);
            this.erroByteCount_ssl.Text = "0";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Margin = new System.Windows.Forms.Padding(50, 4, 0, 3);
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(100, 24);
            this.toolStripStatusLabel8.Text = "错误帧数：";
            // 
            // erroFrameCount_ssl
            // 
            this.erroFrameCount_ssl.Name = "erroFrameCount_ssl";
            this.erroFrameCount_ssl.Size = new System.Drawing.Size(21, 24);
            this.erroFrameCount_ssl.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.autoSendTime_txt);
            this.groupBox2.Controls.Add(this.sendFilePath_tb);
            this.groupBox2.Controls.Add(this.SendFile_btn);
            this.groupBox2.Controls.Add(this.chooseOpenFile_btn);
            this.groupBox2.Controls.Add(this.hexa_chb);
            this.groupBox2.Controls.Add(this.autoSend_chb);
            this.groupBox2.Location = new System.Drawing.Point(15, 408);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 219);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送配置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "ms";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "发送周期";
            // 
            // autoSendTime_txt
            // 
            this.autoSendTime_txt.Location = new System.Drawing.Point(154, 74);
            this.autoSendTime_txt.Name = "autoSendTime_txt";
            this.autoSendTime_txt.Size = new System.Drawing.Size(68, 28);
            this.autoSendTime_txt.TabIndex = 7;
            this.autoSendTime_txt.Text = "2000";
            // 
            // sendFilePath_tb
            // 
            this.sendFilePath_tb.Location = new System.Drawing.Point(6, 169);
            this.sendFilePath_tb.Name = "sendFilePath_tb";
            this.sendFilePath_tb.Size = new System.Drawing.Size(264, 28);
            this.sendFilePath_tb.TabIndex = 6;
            // 
            // SendFile_btn
            // 
            this.SendFile_btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SendFile_btn.Location = new System.Drawing.Point(146, 114);
            this.SendFile_btn.Name = "SendFile_btn";
            this.SendFile_btn.Size = new System.Drawing.Size(116, 32);
            this.SendFile_btn.TabIndex = 5;
            this.SendFile_btn.Text = "发送文件";
            this.SendFile_btn.UseVisualStyleBackColor = false;
            this.SendFile_btn.Click += new System.EventHandler(this.SendFile_btn_Click);
            // 
            // chooseOpenFile_btn
            // 
            this.chooseOpenFile_btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chooseOpenFile_btn.Location = new System.Drawing.Point(6, 112);
            this.chooseOpenFile_btn.Name = "chooseOpenFile_btn";
            this.chooseOpenFile_btn.Size = new System.Drawing.Size(116, 34);
            this.chooseOpenFile_btn.TabIndex = 4;
            this.chooseOpenFile_btn.Text = "选择文件";
            this.chooseOpenFile_btn.UseVisualStyleBackColor = false;
            this.chooseOpenFile_btn.Click += new System.EventHandler(this.chooseOpenFile_Click);
            // 
            // hexa_chb
            // 
            this.hexa_chb.AutoSize = true;
            this.hexa_chb.Location = new System.Drawing.Point(156, 37);
            this.hexa_chb.Name = "hexa_chb";
            this.hexa_chb.Size = new System.Drawing.Size(106, 22);
            this.hexa_chb.TabIndex = 1;
            this.hexa_chb.Text = "十六进制";
            this.hexa_chb.UseVisualStyleBackColor = true;
            this.hexa_chb.CheckedChanged += new System.EventHandler(this.hexa_chb_CheckedChanged);
            // 
            // autoSend_chb
            // 
            this.autoSend_chb.AutoSize = true;
            this.autoSend_chb.Location = new System.Drawing.Point(14, 37);
            this.autoSend_chb.Name = "autoSend_chb";
            this.autoSend_chb.Size = new System.Drawing.Size(106, 22);
            this.autoSend_chb.TabIndex = 0;
            this.autoSend_chb.Text = "自动发送";
            this.autoSend_chb.UseVisualStyleBackColor = true;
            this.autoSend_chb.CheckedChanged += new System.EventHandler(this.autoSend_chb_CheckedChanged);
            // 
            // clearSend
            // 
            this.clearSend.AutoSize = true;
            this.clearSend.BackColor = System.Drawing.SystemColors.ControlDark;
            this.clearSend.Location = new System.Drawing.Point(6, 248);
            this.clearSend.Name = "clearSend";
            this.clearSend.Size = new System.Drawing.Size(305, 57);
            this.clearSend.TabIndex = 3;
            this.clearSend.Text = "清空";
            this.clearSend.UseVisualStyleBackColor = false;
            this.clearSend.Click += new System.EventHandler(this.clearSend_Click);
            // 
            // manuSend_btn
            // 
            this.manuSend_btn.AutoSize = true;
            this.manuSend_btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.manuSend_btn.Location = new System.Drawing.Point(307, 248);
            this.manuSend_btn.Name = "manuSend_btn";
            this.manuSend_btn.Size = new System.Drawing.Size(322, 57);
            this.manuSend_btn.TabIndex = 2;
            this.manuSend_btn.Text = "发送";
            this.manuSend_btn.UseVisualStyleBackColor = false;
            this.manuSend_btn.Click += new System.EventHandler(this.manuSend_btn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sendArea_rtb);
            this.groupBox3.Controls.Add(this.manuSend_btn);
            this.groupBox3.Controls.Add(this.clearSend);
            this.groupBox3.Location = new System.Drawing.Point(332, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(635, 322);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送区";
            // 
            // sendArea_rtb
            // 
            this.sendArea_rtb.Location = new System.Drawing.Point(12, 27);
            this.sendArea_rtb.Name = "sendArea_rtb";
            this.sendArea_rtb.Size = new System.Drawing.Size(617, 218);
            this.sendArea_rtb.TabIndex = 0;
            this.sendArea_rtb.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pauseOrContinue_btn);
            this.groupBox4.Controls.Add(this.receiveArea_rtb);
            this.groupBox4.Location = new System.Drawing.Point(332, 359);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(635, 469);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "接收区";
            // 
            // pauseOrContinue_btn
            // 
            this.pauseOrContinue_btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pauseOrContinue_btn.Location = new System.Drawing.Point(-6, 393);
            this.pauseOrContinue_btn.Name = "pauseOrContinue_btn";
            this.pauseOrContinue_btn.Size = new System.Drawing.Size(635, 70);
            this.pauseOrContinue_btn.TabIndex = 7;
            this.pauseOrContinue_btn.Text = "暂停接收";
            this.pauseOrContinue_btn.UseVisualStyleBackColor = false;
            this.pauseOrContinue_btn.Click += new System.EventHandler(this.pauseOrContinue_btn_Click);
            // 
            // receiveArea_rtb
            // 
            this.receiveArea_rtb.Location = new System.Drawing.Point(6, 23);
            this.receiveArea_rtb.Name = "receiveArea_rtb";
            this.receiveArea_rtb.Size = new System.Drawing.Size(623, 364);
            this.receiveArea_rtb.TabIndex = 0;
            this.receiveArea_rtb.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.SaveFilePath_tb);
            this.groupBox5.Controls.Add(this.saveToFile_btn);
            this.groupBox5.Controls.Add(this.chooseSaveFolder_btn);
            this.groupBox5.Controls.Add(this.clearReceiveArea);
            this.groupBox5.Controls.Add(this.receiveHex_chb);
            this.groupBox5.Location = new System.Drawing.Point(15, 633);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(302, 195);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "接收配置";
            // 
            // SaveFilePath_tb
            // 
            this.SaveFilePath_tb.Location = new System.Drawing.Point(14, 147);
            this.SaveFilePath_tb.Name = "SaveFilePath_tb";
            this.SaveFilePath_tb.Size = new System.Drawing.Size(255, 28);
            this.SaveFilePath_tb.TabIndex = 4;
            // 
            // saveToFile_btn
            // 
            this.saveToFile_btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.saveToFile_btn.Location = new System.Drawing.Point(148, 89);
            this.saveToFile_btn.Name = "saveToFile_btn";
            this.saveToFile_btn.Size = new System.Drawing.Size(114, 35);
            this.saveToFile_btn.TabIndex = 3;
            this.saveToFile_btn.Text = "保存";
            this.saveToFile_btn.UseVisualStyleBackColor = false;
            this.saveToFile_btn.Click += new System.EventHandler(this.saveToFile_btn_Click);
            // 
            // chooseSaveFolder_btn
            // 
            this.chooseSaveFolder_btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chooseSaveFolder_btn.Location = new System.Drawing.Point(11, 89);
            this.chooseSaveFolder_btn.Name = "chooseSaveFolder_btn";
            this.chooseSaveFolder_btn.Size = new System.Drawing.Size(111, 35);
            this.chooseSaveFolder_btn.TabIndex = 2;
            this.chooseSaveFolder_btn.Text = "选择文件";
            this.chooseSaveFolder_btn.UseVisualStyleBackColor = false;
            this.chooseSaveFolder_btn.Click += new System.EventHandler(this.chooseSaveFolder_btn_Click);
            // 
            // clearReceiveArea
            // 
            this.clearReceiveArea.BackColor = System.Drawing.SystemColors.ControlDark;
            this.clearReceiveArea.Location = new System.Drawing.Point(11, 36);
            this.clearReceiveArea.Name = "clearReceiveArea";
            this.clearReceiveArea.Size = new System.Drawing.Size(109, 39);
            this.clearReceiveArea.TabIndex = 1;
            this.clearReceiveArea.Text = "清空接收";
            this.clearReceiveArea.UseVisualStyleBackColor = false;
            this.clearReceiveArea.Click += new System.EventHandler(this.clearReceiveArea_Click);
            // 
            // receiveHex_chb
            // 
            this.receiveHex_chb.AutoSize = true;
            this.receiveHex_chb.Location = new System.Drawing.Point(154, 45);
            this.receiveHex_chb.Name = "receiveHex_chb";
            this.receiveHex_chb.Size = new System.Drawing.Size(106, 22);
            this.receiveHex_chb.TabIndex = 0;
            this.receiveHex_chb.Text = "十六进制";
            this.receiveHex_chb.UseVisualStyleBackColor = true;
            this.receiveHex_chb.CheckedChanged += new System.EventHandler(this.receiveHex_chb_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.frameData4_tb);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.frameData3_tb);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.frameData2_tb);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.frameData1_tb);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.frame_rtb);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.frameDecode_chb);
            this.groupBox6.Location = new System.Drawing.Point(973, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(257, 481);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "数据解析";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 446);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 18);
            this.label13.TabIndex = 11;
            this.label13.Text = "数据帧格式：";
            // 
            // frameData4_tb
            // 
            this.frameData4_tb.Location = new System.Drawing.Point(100, 387);
            this.frameData4_tb.Name = "frameData4_tb";
            this.frameData4_tb.Size = new System.Drawing.Size(137, 28);
            this.frameData4_tb.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 390);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 18);
            this.label12.TabIndex = 9;
            this.label12.Text = "数据4";
            // 
            // frameData3_tb
            // 
            this.frameData3_tb.Location = new System.Drawing.Point(100, 344);
            this.frameData3_tb.Name = "frameData3_tb";
            this.frameData3_tb.Size = new System.Drawing.Size(137, 28);
            this.frameData3_tb.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 347);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 18);
            this.label11.TabIndex = 7;
            this.label11.Text = "数据3";
            // 
            // frameData2_tb
            // 
            this.frameData2_tb.Location = new System.Drawing.Point(100, 294);
            this.frameData2_tb.Name = "frameData2_tb";
            this.frameData2_tb.Size = new System.Drawing.Size(137, 28);
            this.frameData2_tb.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 18);
            this.label10.TabIndex = 5;
            this.label10.Text = "数据2";
            // 
            // frameData1_tb
            // 
            this.frameData1_tb.Location = new System.Drawing.Point(100, 248);
            this.frameData1_tb.Name = "frameData1_tb";
            this.frameData1_tb.Size = new System.Drawing.Size(137, 28);
            this.frameData1_tb.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "数据1";
            // 
            // frame_rtb
            // 
            this.frame_rtb.Location = new System.Drawing.Point(19, 136);
            this.frame_rtb.Name = "frame_rtb";
            this.frame_rtb.Size = new System.Drawing.Size(218, 88);
            this.frame_rtb.TabIndex = 2;
            this.frame_rtb.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "帧数据接收区";
            // 
            // frameDecode_chb
            // 
            this.frameDecode_chb.AutoSize = true;
            this.frameDecode_chb.Location = new System.Drawing.Point(19, 49);
            this.frameDecode_chb.Name = "frameDecode_chb";
            this.frameDecode_chb.Size = new System.Drawing.Size(124, 22);
            this.frameDecode_chb.TabIndex = 0;
            this.frameDecode_chb.Text = "启用帧解析";
            this.frameDecode_chb.UseVisualStyleBackColor = true;
            this.frameDecode_chb.CheckedChanged += new System.EventHandler(this.frameDecode_chb_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(970, 506);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(269, 18);
            this.label14.TabIndex = 12;
            this.label14.Text = "DF+数据字节数+数据+CRC校验+A5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 873);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox PortName_cmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox baudRate_cmb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox parity_cmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox stopBits_cmb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox dataBits_cmb;
        private System.Windows.Forms.Button openOrClosePort_btn;
        private System.Windows.Forms.CheckBox DTR_chb;
        private System.Windows.Forms.CheckBox RTS_chb;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel portStatus_ssl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel sendCount_ssl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel receiveCount_ssl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox hexa_chb;
        private System.Windows.Forms.CheckBox autoSend_chb;
        private System.Windows.Forms.Button clearSend;
        private System.Windows.Forms.Button manuSend_btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox sendArea_rtb;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox receiveArea_rtb;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox receiveHex_chb;
        private System.Windows.Forms.Button clearReceiveArea;
        private System.Windows.Forms.Button SendFile_btn;
        private System.Windows.Forms.Button chooseOpenFile_btn;
        private System.Windows.Forms.TextBox sendFilePath_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox autoSendTime_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button chooseSaveFolder_btn;
        private System.Windows.Forms.TextBox SaveFilePath_tb;
        private System.Windows.Forms.Button saveToFile_btn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button pauseOrContinue_btn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox frame_rtb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox frameDecode_chb;
        private System.Windows.Forms.TextBox frameData3_tb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox frameData2_tb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox frameData1_tb;
        private System.Windows.Forms.TextBox frameData4_tb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel erroByteCount_ssl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel erroFrameCount_ssl;
    }
}

