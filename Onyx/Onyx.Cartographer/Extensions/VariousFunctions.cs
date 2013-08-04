using System;
using System.IO;
using System.Linq;

namespace Onyx.Cartographer.Extensions
{
    public class VariousFunctions
    {
        public static string ByteArrayToHexString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }

        public static byte[] HexStringToByteArray(string hexString)
        {
            return Enumerable.Range(0, hexString.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                     .ToArray();
        }

        public static byte[] StreamToByteArray(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}