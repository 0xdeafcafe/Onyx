using System.Security.Cryptography;
using System.Text;

namespace Onyx.Cartographer.Extensions.Cryptography
{
    public class Sha1Crypto
    {
        public static string ComputeHashToString(string str)
        {
            var enc = Encoding.Unicode.GetEncoder();
            var unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            var result = sha1.ComputeHash(unicodeText);

            var sb = new StringBuilder();
            foreach (var t in result)
                sb.Append(t.ToString("X2"));
            return sb.ToString();
        }
        public static string ComputeHashToString(byte[] byteArr)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            var result = sha1.ComputeHash(byteArr);

            var sb = new StringBuilder();
            foreach (var t in result)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        public static byte[] ComputeHashToByteArray(string str)
        {
            var enc = Encoding.Unicode.GetEncoder();
            var unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            return sha1.ComputeHash(unicodeText);
        }
        public static byte[] ComputeHashToByteArray(byte[] byteArr)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            return sha1.ComputeHash(byteArr);
        }
    }
}