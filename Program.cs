using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Checksum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePath = args[0];
            byte[] SHA512Bytes = SHA512Checksum(filePath);
            byte[] SHA256Bytes = SHA256Checksum(filePath);
            byte[] MD5Bytes = MD5Checksum(filePath);
            byte[] SHA1Bytes = SHA1Checksum(filePath);
            string SHA512Str = ConvertByteArray(SHA512Bytes);
            string SHA256Str = ConvertByteArray(SHA256Bytes);
            string MD5Str = ConvertByteArray(MD5Bytes);
            string SHA1Str = ConvertByteArray(SHA1Bytes);

            MessageBox.Show($"SHA-512: {SHA512Str}\n\nSHA-256: {SHA256Str}\n\nSHA-1: {SHA1Str}\n\nMD5: {MD5Str}");
        }

        private static byte[] SHA1Checksum(string filePath)
        {
            using (SHA1 SHA = SHA1.Create())
            {
                using (FileStream file = File.OpenRead(filePath))
                {
                    return SHA.ComputeHash(file);
                }
            }
        }

        private static byte[] SHA512Checksum(string filePath)
        {
            using (SHA512 SHA = SHA512.Create())
            {
                using (FileStream file = File.OpenRead(filePath))
                {
                    return SHA.ComputeHash(file);                 
                }
            }
        }

        private static byte[] SHA256Checksum(string filePath)
        {
            using (SHA256 SHA = SHA256.Create())
            {
                using (FileStream file = File.OpenRead(filePath))
                {
                    return SHA.ComputeHash(file);
                }
            }
        }

        private static byte[] MD5Checksum(string filePath)
        {
            using (MD5 MD5 = MD5.Create())
            {
                using (FileStream file = File.OpenRead(filePath))
                {
                    return MD5.ComputeHash(file);
                }
            }
        }

        private static string ConvertByteArray(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "");
        }        
    }    
}