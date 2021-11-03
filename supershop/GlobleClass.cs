using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.IO;


namespace supershop
{
    public static class GlobleClass
    {
               
        public static DateTime GetDateMMDDYYYY(string strDate)
        {
            string[] datearray = strDate.Split('/');
            DateTime Date = new DateTime(Convert.ToInt32(datearray[2]), Convert.ToInt32(datearray[1]), Convert.ToInt32(datearray[0]));
            return Date;
        }

        public static string GetDateDDMMYYYY(DateTime Date)
        {

            return Date.ToString("dd/MM/yyyy");
        }
        public static class EncryptionHelpers
        {            
            private const string cryptoKey = "cryptoKey";
            private static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };
            // login check for ACM
            static string message = "";
           
            public static string Encrypt(string s)
            {
                if (s == null || s.Length == 0) return string.Empty;

                string result = string.Empty;

                try
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(s);

                    TripleDESCryptoServiceProvider des =
                        new TripleDESCryptoServiceProvider();

                    MD5CryptoServiceProvider MD5 =
                        new MD5CryptoServiceProvider();

                    des.Key =
                        MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                    des.IV = IV;
                    result = Convert.ToBase64String(
                        des.CreateEncryptor().TransformFinalBlock(
                            buffer, 0, buffer.Length));
                }
                catch
                {
                    result = "0";
                }
                if (result.Contains("+"))
                {
                    result = result.Replace("+", "~");
                }
                return result;
            }
            public static string Decrypt(string s)
            {
                if (s.Contains("~"))
                {
                    s = s.Replace("~", "+");
                }

                if (s == null || s.Length == 0) return string.Empty;

                string result = string.Empty;

                try
                {
                    byte[] buffer = Convert.FromBase64String(s);

                    TripleDESCryptoServiceProvider des =
                        new TripleDESCryptoServiceProvider();

                    MD5CryptoServiceProvider MD5 =
                        new MD5CryptoServiceProvider();

                    des.Key =
                        MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                    des.IV = IV;

                    result = Encoding.ASCII.GetString(
                        des.CreateDecryptor().TransformFinalBlock(
                        buffer, 0, buffer.Length));
                }
                catch
                {
                    result = "0";
                }
                return result;
            }

        }               

    }
    public static class EncryptionHelper
    {
        private const string cryptoKey = "cryptoKey";

        // The Initialization Vector for the DES encryption routine
        private static readonly byte[] IV =
            new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        /// <summary>
        /// Encrypts provided string parameter
        /// </summary>
        public static string Encrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;
                result = Convert.ToBase64String(
                    des.CreateEncryptor().TransformFinalBlock(
                        buffer, 0, buffer.Length));
            }
            catch
            {
                result = "0";
            }
            if (result.Contains("+"))
            {
                result = result.Replace("+", "~");
            }
            return result;
        }

        /// <summary>
        /// Decrypts provided string parameter
        /// </summary>
        public static string Decrypt(string s)
        {
            if (s.Contains("~"))
            {
                s = s.Replace("~", "+");
            }

            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Convert.FromBase64String(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;

                result = Encoding.ASCII.GetString(
                    des.CreateDecryptor().TransformFinalBlock(
                    buffer, 0, buffer.Length));
            }
            catch
            {
                result = "0";
            }

            return result;
        }

        //((DMSMaster)Page.Master).WriteLog("MaterialDelivary(11001),ID:" + DocUniqueID.ToString(), "tbl_DMSMaterialDelivary");
       
    }
}
