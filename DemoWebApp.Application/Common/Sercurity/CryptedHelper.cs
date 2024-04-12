using System.Security.Cryptography;
using System.Text;

namespace DemoWebApp.Application.Common.Sercurity
{
    public class CryptedHelper
    {
        public static byte[] ConvertSecretValueToByte(string secretKey)
        {
            return UnicodeEncoding.UTF8.GetBytes(secretKey);
        }

        public static byte[] EncryptPassWordAes(byte[] key, byte[] iv, string password)
        {
            byte[] cipheredtext;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(password);
                        }

                        cipheredtext = memoryStream.ToArray();
                    }
                }
            }
            return cipheredtext;
        }

        public static string DecryptPassWordAes(byte[] cipheredtext, byte[] key, byte[] iv)
        {
            string password = string.Empty;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                using (MemoryStream memoryStream = new MemoryStream(cipheredtext))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            password = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return password;
        }
    }
}
