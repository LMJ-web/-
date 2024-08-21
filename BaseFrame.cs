using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class BaseFrame : FrameFormat
    {
        public override byte[] DecodeFrame(Queue<byte> frameByteQueue)
        {
            List<byte> bytes = new List<byte>();
            //找出帧头
            while (true)
            {
                try 
                {
                    byte b = frameByteQueue.Dequeue();
                    if (b.Equals(0xDF))
                    {
                        bytes.Add(b);
                        break;
                    }
                }catch (InvalidOperationException ex)
                {
                    Console.WriteLine("没找到帧头");
                    return null;
                }
            }

            //记录数据位长度的字节
            byte frameDateLength;
            try
            {
                byte length = frameByteQueue.Dequeue();
                bytes.Add(length);
                frameDateLength = length;
            }catch(InvalidOperationException ex) 
            {
                Console.WriteLine("长度位缺失");
                return null;
            }

            //数据位
            List<byte> frameData = new List<byte>();
            for(int i = 0; i < frameDateLength; i++)
            {
                try 
                {
                    byte b = frameByteQueue.Dequeue();
                    frameData.Add(b);
                    bytes.Add(b);
                }catch (InvalidOperationException ex)
                {
                    Console.WriteLine("数据缺失"); 
                    return null;
                }
            }

            //CRC校验位
            byte[] CRC = new byte[2];
            for(int i=0; i<2; i++)
            {
                try
                {
                    CRC[i] = frameByteQueue.Dequeue();
                    bytes.Add(CRC[i]);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("校验位缺失");
                    return null;
                }
            }

            //进行CRC校验
            byte[] CRC16 = CRC16_IBM.getCRCBytes(frameData.ToArray());
            if (!CRC[0].Equals(CRC16[0]) || !CRC[1].Equals(CRC16[1]))
            {
                Console.WriteLine("CRC校验不通过");
                return null;
            }

            //停止位
            try
            {
                byte stop = frameByteQueue.Dequeue();
                bytes.Add(stop);
                if (!stop.Equals(0xA5)) 
                { 
                    Console.WriteLine("停止位不在正确的位置");; return null; 
                }
            }catch(InvalidOperationException ex)
            {
                Console.WriteLine("停止位缺失");
                return null; 
            }
            return bytes.ToArray();
        }

        //1位帧头+数据长度(1位)+数据+CRC校验位+1位帧尾
        public override byte[] CreateFrame(byte[] frameDate) 
        {
            byte[] frameBytes = new byte[1 + 1 + frameDate.Length + 2 + 1];
            byte frameHead = 0xDF;
            byte frameDataLength = (byte)frameDate.Length;
            frameBytes[0] = frameHead;
            frameBytes[1] = frameDataLength;
            frameDate.CopyTo(frameBytes, 2);
            CRC16_IBM.getCRCBytes(frameDate).CopyTo(frameBytes, 1 + 1 + frameDate.Length);
            frameBytes[frameBytes.Length - 1] = 0xA5;
            return frameBytes;
        }

    }
}
