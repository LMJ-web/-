using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class FrameFormat
    {
        public abstract byte[] DecodeFrame(Queue<byte> frameByteQueue);
        public abstract byte[] CreateFrame(byte[] frameData);
    }
}
