using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Transform
    {
        //判断16进制编码是否合法，若合法将(string)16进制编码转化为byte[]
        public static byte[] HexCodeToBytes(string hexCode)
        {
            // 检查字符串是否为null或空  
            if (string.IsNullOrEmpty(hexCode))
            {
                return null;
            }
            byte[] hexBytes = new byte[hexCode.Length/2];

            // 遍历字符串，每次检查两个字符  
            for (int i = 0; i < hexCode.Length; i += 2)
            {
                // 如果无法将两个字符转换为byte，或者当前索引加上1超过了字符串长度，则不是合法的16进制字符串  
                if (!byte.TryParse(hexCode.Substring(i, 2), NumberStyles.HexNumber, null, out hexBytes[i/2]) || i + 1 >= hexCode.Length)
                {
                    return null;
                }
            }

            // 如果所有检查都通过了，则字符串是合法的16进制编码
            return hexBytes;
        }

        //将普通字符串转化为(string)16进制编码
        public static string StringToHexCode(string s)
        {
            // 使用GB2312编码将字符串转换为字节数组
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(s);

            // 使用StringBuilder来构建最终的16进制字符串  
            StringBuilder hex = new StringBuilder(bytes.Length * 2);

            foreach (byte b in bytes)
            {
                // 将每个字节转换为两位的16进制数，不足位的前面补0  
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}
