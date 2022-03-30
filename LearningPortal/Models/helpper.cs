using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LearningPortal
{
    public class helpper
    {
        static string _salt = "*1234567890!@#$%^&*()14344*";
        public static string Encrypt(string toEncrypt, bool useHashing)

        {

            byte[] keyArray;

            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);



            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();

            // Get the key from config file

            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));

            //System.Windows.Forms.MessageBox.Show(key);

            if (useHashing)

            {

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_salt));

                hashmd5.Clear();

            }

            else

                keyArray = UTF8Encoding.UTF8.GetBytes(_salt);



            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;

            tdes.Mode = CipherMode.ECB;

            tdes.Padding = PaddingMode.PKCS7;



            ICryptoTransform cTransform = tdes.CreateEncryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

        public static string Decrypto(string text)
        {
            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();

            // Get the key from config file

            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));

            try
            {

                var hashmd5 = new MD5CryptoServiceProvider();
                byte[] toEncryptArray = Convert.FromBase64String(text);

                byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(_salt));

                hashmd5.Clear();
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                tdes.Clear();

                return Encoding.UTF8.GetString(resultArray);
                //return Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return string.Empty;
            }
        }














        private static byte[] _optionalEntropy = { 9, 8, 7, 6, 5 };



        public static string Encrypt(string plainText)
        {
            return HttpServerUtility.UrlTokenEncode(ProtectedData.Protect(Encoding.UTF8.GetBytes(plainText), _optionalEntropy, DataProtectionScope.LocalMachine));
        }

        public static string Decrypt(string text)
        {
            return Encoding.UTF8.GetString(ProtectedData.Unprotect(HttpServerUtility.UrlTokenDecode(text), _optionalEntropy, DataProtectionScope.LocalMachine));
        }
    }
}