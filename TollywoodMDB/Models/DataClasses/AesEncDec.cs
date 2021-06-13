using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;


namespace TollywoodMDB
{
    public class AesEncDec
    {
        public string AesEnc(string password)
        {
            Aes aes = Aes.Create();
            aes.Key = System.Text.ASCIIEncoding.UTF8.GetBytes("TollywoodMDBdcom");
            aes.IV = System.Text.ASCIIEncoding.UTF8.GetBytes("mocdBDMdoowylloT");
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(System.Text.Encoding.UTF8.GetBytes(password), 0, password.Length);

                    csEncrypt.FlushFinalBlock();
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }

        }
        //public string AesDec(string encPassword)
        //{
        //    Aes aes = Aes.Create();
        //    aes.Key = System.Text.ASCIIEncoding.UTF8.GetBytes("DKNYPEPEJEANS73L");
        //    aes.IV = System.Text.ASCIIEncoding.UTF8.GetBytes("PEPEJEANS73LDKNY");
        //    ICryptoTransform Decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        //    using (MemoryStream msDecrypt = new MemoryStream())
        //    {
        //        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, Decryptor, CryptoStreamMode.Write))
        //        {
        //            byte[] passwordBytes = Encoding.UTF8.GetBytes(encPassword);
        //            csDecrypt.Write(passwordBytes,0,encPassword.Length);

        //            return Convert.ToBase64String(msDecrypt.ToArray());
        //        }
        //    }
        //}

    }
}