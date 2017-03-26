using System.Globalization;

namespace ECDSA.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConverterHelper
    {
        public static byte[] HexStringToByteArray(string plainTex)
        {
            var rez = new byte[plainTex.Length / 2];
            for (int i = 0; i < rez.Length; i++)
                rez[i] = byte.Parse($"{plainTex[i * 2]}{ plainTex[i * 2 + 1]}", NumberStyles.AllowHexSpecifier);
            return rez;
        }










        //--
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
