using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace Checksum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePath = args[0];
            //var filePath = @"D:\Downloads\Microsoft Installers\dotnet-hosting-7.0.5-win.exe";
            byte[] SHA512Bytes = SHA512Checksum(filePath);
            byte[] SHA256Bytes = SHA256Checksum(filePath);
            string SHA512Str = ConvertByteArray(SHA512Bytes);
            string SHA256Str = ConvertByteArray(SHA256Bytes);

            MessageBox.Show($"SHA-512: {SHA512Str}\n\nSHA-256: {SHA256Str}");
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

        private static string ConvertByteArray(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "");
        }        
    }    
}