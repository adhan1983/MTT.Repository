﻿using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace MTT.Application.Domain.Utilities
{
    public static class EncryptHelper
    {
        public static string Encrypt(this string value)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(value);
            using (Aes encryptor = Aes.Create())
            {
                string ENCRYPTIONKEY = "BQDmvbuzxBxKgV9eRhQP_7NmjlCqTqTg1cceAnnSHCMTgQNXBIZx0sY41VVN5y__UNE";

                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ENCRYPTIONKEY, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                encryptor.Key = pdb.GetBytes(32);

                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    value = Convert.ToBase64String(ms.ToArray());
                }
            }
            return value;
        }
        public static string Decrypt(this string value)
        {
            byte[] cipherBytes = Convert.FromBase64String(value);
            using (Aes encryptor = Aes.Create())
            {
                string ENCRYPTIONKEY = "BQDmvbuzxBxKgV9eRhQP_7NmjlCqTqTg1cceAnnSHCMTgQNXBIZx0sY41VVN5y__UNE";

                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ENCRYPTIONKEY, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                encryptor.Key = pdb.GetBytes(32);

                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    value = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return value;
        }
    }
}
