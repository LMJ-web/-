using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class FrameFormatContext
    {
        public FrameFormat FrameFormat { get; set; }
        public byte[] DecodedFrame(Queue<byte> frameByteQueue)
        {
            return FrameFormat.DecodeFrame(frameByteQueue);
        }
        public byte[] CreateFrame(byte[] frameData)
        {
            return FrameFormat.CreateFrame(frameData);
        }
    }
}
