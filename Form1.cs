using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] LocalPortNames = SerialPort.GetPortNames();
            PortName_cmb.DataSource = LocalPortNames;
            baudRate_cmb.SelectedIndex = 3;
            parity_cmb.SelectedIndex = 0;
            dataBits_cmb.SelectedIndex = 3;
            stopBits_cmb.SelectedIndex = 0;
        }


        private void OpenOrClosePort_btn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                portStatus_ssl.BackColor = Color.Red;
                openOrClosePort_btn.Text = "打开串口";
                return;
            }
            try 
            { 
                serialPort1.Open();
                portStatus_ssl.BackColor = Color.Green;
                openOrClosePort_btn.Text = "关闭串口";
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void PortName_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = PortName_cmb.Text;
        }

        private void BaudRate_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = int.Parse(baudRate_cmb.Text);
        }

        private void Parity_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = parity_cmb.SelectedIndex;
            switch (selectedIndex)
            {
                case 0: serialPort1.Parity = Parity.None; break;
                case 1: serialPort1.Parity = Parity.Odd; break;
                case 2: serialPort1.Parity = Parity.Even; break;
                default: serialPort1.Parity = Parity.None; break;
            }
        }

        private void RTS_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (RTS_chb.Checked) { serialPort1.RtsEnable = true; }
            else { serialPort1.RtsEnable = false; }
        }

        private void DTR_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (DTR_chb.Checked) { serialPort1.DtrEnable = true; }
            else { serialPort1.DtrEnable = false; }
        }

        private void dataBits_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.DataBits = int.Parse(dataBits_cmb.Text);
        }

        private void StopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (stopBits_cmb.SelectedIndex)
            {
                case 0: serialPort1.StopBits = StopBits.One; break;
                case 1: serialPort1.StopBits = StopBits.OnePointFive; break;
                case 2: serialPort1.StopBits = StopBits.Two; break;
            }
        }

        private void manuSend_btn_Click(object sender, EventArgs e)
        {
            byte[] sendBytes;
            //发送数据前勾选了16进制选项，判断文本是否为16进制编码
            //是，发送
            //否，提示
            if (hexa_chb.Checked)
            {
                sendBytes = Transform.HexCodeToBytes(sendArea_rtb.Text);
                if (sendBytes==null)
                {
                    MessageBox.Show("格式错误，请输入正确的16进制编码！");
                    return;
                }
            }
            else { sendBytes = Encoding.GetEncoding("gb2312").GetBytes(sendArea_rtb.Text); }

            if (frameDecode_chb.Checked)
            {
                byte[] frameBytes = frameFormatContext.CreateFrame(sendBytes);
                serialPort1.Write(frameBytes,0,frameBytes.Length);
                sendCount_ssl.Text = $"{int.Parse(sendCount_ssl.Text) + frameBytes.Length}";
                return;
            }
            serialPort1.Write(sendBytes,0,sendBytes.Length);
            sendCount_ssl.Text = $"{int.Parse(sendCount_ssl.Text)+sendBytes.Length}";
        }

        private void hexa_chb_CheckedChanged(object sender, EventArgs e)
        {   
            //勾选16进制选项时，如发送文本框有内容，判断文本是否为16进制编码
            //是16进制编码，不改变文本内容
            //不是16进制编码，将文本转为16进制编码
            if (hexa_chb.Checked)
            {
                if (!string.IsNullOrEmpty(sendArea_rtb.Text))
                {
                    byte[] bytes = Transform.HexCodeToBytes(sendArea_rtb.Text);
                    if (bytes==null) { sendArea_rtb.Text = Transform.StringToHexCode(sendArea_rtb.Text); }
                }
            }
            //取消勾选16进制选项时，如发送文本框有内容，判断文本是否为16进制编码
            //是16进制编码，将16进制编码转为string
            //不是16进制编码，不改变文本内容
            else
            {
                if (!string.IsNullOrEmpty(sendArea_rtb.Text))
                {

                    byte[] bytes = Transform.HexCodeToBytes(sendArea_rtb.Text);
                    if (bytes!=null) { 
                        sendArea_rtb.Text = Encoding.GetEncoding("gb2312").GetString(bytes);
                    }
                }
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("触发接收");
            byte[] receviceBuffer = new byte[serialPort1.BytesToRead];
            serialPort1.Read(receviceBuffer, 0, receviceBuffer.Length);
            Console.WriteLine($"长度{receviceBuffer.Length}");
            //接收区控件
            byte[] receiveAreaTempBytes = receviceBuffer;
            //启用帧解析,使用策略模式实现
            if (frameDecode_chb.Checked)
            {
                foreach (byte b in receviceBuffer)
                {
                    frameByteQueue.Enqueue(b);
                   
                    //Console.WriteLine($"byte:{b}");
                    //没读到帧尾，接收区控件不显示
                    if (!b.Equals(0xA5)) { receiveAreaTempBytes = null; }
                    //读取到帧尾时，触发帧校验
                    if (b.Equals(0xA5))
                    {
                        Console.WriteLine($"找到帧尾");

                        //帧校验只解一帧
                        byte[] frameBytes = frameFormatContext.DecodedFrame(frameByteQueue);
                        if (frameBytes!=null)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            foreach(byte by in frameBytes)
                            {
                                stringBuilder.AppendFormat("{0:X2}", by);
                            }
                            string frameString = stringBuilder.ToString();
                            string[] frameDatas = new string[frameBytes[1]];
                            for (int i = 0; i < frameBytes[1]; i++)
                            {
                                frameDatas[i] = frameString.Substring(4 + i * 2, 2);
                            }
                            Invoke((MethodInvoker)delegate
                            {
                                frame_rtb.Text = frameString;
                                frameData1_tb.Text = frameDatas[0];
                                frameData2_tb.Text = frameDatas[1];
                                frameData3_tb.Text = frameDatas[2];
                                frameData4_tb.Text = frameDatas[3];
                            });
                        }
                        else
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                erroFrameCount_ssl.Text = $"{int.Parse(erroFrameCount_ssl.Text)+1}";
                            });
                            return;
                        }
                        //接收区显示帧的数据位
                        receiveAreaTempBytes = frameBytes.Skip(2).Take(frameBytes[1]).ToArray();
                    }
                }
            }
            if (receiveAreaTempBytes==null) { return; }
            receiveAreaContexList.AddRange(receiveAreaTempBytes);
            //非16进制处理
            if (!receiveHex_chb.Checked)
            {
                receiveAreaTempBuilder.Append(Encoding.GetEncoding("gb2312").GetString(receiveAreaTempBytes));
            }
            //16进制处理
            else
            {
                foreach (byte b in receiveAreaTempBytes)
                {
                    receiveAreaTempBuilder.AppendFormat("{0:X2}", b);
                }
            }
            Invoke((MethodInvoker)delegate
            {
                receiveArea_rtb.Text += receiveAreaTempBuilder.ToString();
                receiveCount_ssl.Text = $"{int.Parse(receiveCount_ssl.Text) + receiveAreaTempBytes.Length}";

            });
            receiveAreaTempBuilder.Clear();
        }

        private void receiveHex_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (!receiveHex_chb.Checked)
            {
                receiveArea_rtb.Text = Encoding.GetEncoding("gb2312").GetString(receiveAreaContexList.ToArray());
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in receiveAreaContexList)
                {
                    try
                    {
                        stringBuilder.AppendFormat("{0:X2}", b);
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                receiveArea_rtb.Text = stringBuilder.ToString();
            }
        }

        private void clearReceiveArea_Click(object sender, EventArgs e)
        {
            receiveAreaContexList.Clear();
            receiveArea_rtb.Text = "";
            receiveCount_ssl.Text = "0";
            erroByteCount_ssl.Text = "0";
            erroFrameCount_ssl.Text = "0";
        }

        private void clearSend_Click(object sender, EventArgs e)
        {
            sendArea_rtb.Text = "";
            sendCount_ssl.Text = "0";
        }

        private void autoSend_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSend_chb.Checked)
            {
                try{timer1.Interval = int.Parse(autoSendTime_txt.Text);}
                catch(FormatException ex){MessageBox.Show(ex.Message);}
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            manuSend_btn_Click(sender, e);
        }

        private void pauseOrContinue_btn_Click(object sender, EventArgs e)
        {
            if(pauseReceiveDate == false)
            {
                serialPort1.DataReceived -= serialPort1_DataReceived;
                serialPort1.ErrorReceived -= serialPort1_ErrorReceived;
                pauseReceiveDate = true;
                pauseOrContinue_btn.Text = "继续接收";
            }
            else
            {
                serialPort1.DiscardInBuffer();
                serialPort1.DataReceived += serialPort1_DataReceived;
                pauseReceiveDate = false;
                pauseOrContinue_btn.Text = "暂停接收";
            }
        }

        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            erroByteCount_ssl.Text = $"{int.Parse(erroByteCount_ssl.Text)+1}";
        }

        private void frameDecode_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (frameDecode_chb.Checked)
            {
                frameFormatContext.FrameFormat = baseFrame;
            }
        }

        public string text;
        private void chooseOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "请选择文件";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                sendFilePath_tb.Text = openFileDialog.FileName;
                StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }
        private void SendFile_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text)) 
            {
                MessageBox.Show("无法发送空文件！");
                return;
            }
            byte[] textBytes = Encoding.GetEncoding("gb2312").GetBytes(text);
            int pageNum = textBytes.Length / 4096;
            int remain = text.Length % 4096;
            try 
            {
                for (int i = 0; i < pageNum; i++)
                {
                    serialPort1.Write(textBytes, i * 4096, 4096);
                    Thread.Sleep(10);
                }
                if (remain > 0)
                {
                    serialPort1.Write(textBytes, pageNum * 4096, remain);
                }
                sendCount_ssl.Text = $"{int.Parse(sendCount_ssl.Text) + textBytes.Length}";
            }
            catch(Exception ex) 
            {
                MessageBox.Show("文件发送失败！");
                Console.WriteLine(ex.Message);
            }
            
        }


        private void chooseSaveFolder_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                SaveFilePath_tb.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void saveToFile_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(receiveArea_rtb.Text)) {
                return;
            }
            string fileName = SaveFilePath_tb.Text + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
            StreamWriter streamWriter = new StreamWriter(fileName);
            streamWriter.Write(receiveArea_rtb.Text);
            streamWriter.Flush();
            streamWriter.Close();
            MessageBox.Show("保存成功！");
        }
    }
}
