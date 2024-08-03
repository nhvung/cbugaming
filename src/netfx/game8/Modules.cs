using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace game8
{
    class Modules
    {
        #region encrypt / decrypt
        public static byte[] Sha256(string value)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            //if (tick > 0)
            //{
            //    byte[] fileTimeBytes = BitConverter.GetBytes(tick);
            //    valueBytes = valueBytes.Union(fileTimeBytes).ToArray();
            //}
            return SHA256.Create().ComputeHash(valueBytes);
        }
        public static byte[] EncryptBinary(byte[] binInput, byte[] keyBytes)
        {
            byte[] result = new byte[0];
            try
            {
                byte[] binKey = keyBytes, binIV = Guid.NewGuid().ToByteArray();
                using (var eAlg = Aes.Create())
                {
                    eAlg.Key = binKey;
                    eAlg.IV = binIV;

                    using (var msEncrypt = new MemoryStream())
                    {
                        msEncrypt.Write(binIV, 0, 8);
                        using (var encryptor = eAlg.CreateEncryptor())
                        {
                            var binEncrypt = encryptor.TransformFinalBlock(binInput, 0, binInput.Length);
                            encryptor.Dispose();
                            msEncrypt.Write(binEncrypt, 0, binEncrypt.Length);
                        }
                        msEncrypt.Write(binIV, 8, 8);
                        msEncrypt.Close();
                        msEncrypt.Dispose();

                        result = msEncrypt.ToArray();
                    }
                    eAlg.Dispose();
                }
            }
            catch //(Exception ex)
            {
            }
            return result;
        }
        public static byte[] DecryptBinary(byte[] binInput, byte[] keyBytes)
        {
            byte[] result = new byte[0];
            try
            {
                byte[] binKey = keyBytes, binIV = new byte[16], binEncrypt = new byte[binInput.Length - 16];
                using (var msEncrypt = new MemoryStream(binInput))
                {
                    msEncrypt.Read(binIV, 0, 8);
                    msEncrypt.Seek(-8, SeekOrigin.End);
                    msEncrypt.Read(binIV, 8, 8);

                    msEncrypt.Seek(8, SeekOrigin.Begin);

                    msEncrypt.Read(binEncrypt, 0, binEncrypt.Length);

                    msEncrypt.Close();
                    msEncrypt.Dispose();
                }

                using (var eAlg = Aes.Create())
                {
                    eAlg.Key = binKey;
                    eAlg.IV = binIV;

                    using (var descryptor = eAlg.CreateDecryptor())
                    {
                        try
                        {
                            result = descryptor.TransformFinalBlock(binEncrypt, 0, binEncrypt.Length);
                        }
                        catch
                        {
                            result = Encoding.UTF8.GetBytes($"<encrypted>");
                        }
                        descryptor.Dispose();
                    }
                    eAlg.Dispose();
                }
            }
            catch //(Exception ex)
            {

            }
            return result;
        }

        public static byte[] Hex2Bytes(string input)
        {
            byte[] result = new byte[0];
            try
            {
                result = new byte[input.Length / 2];
                for (int i = 0; i < input.Length; i += 2)
                {
                    string hexChar = input[i] + "" + input[i + 1];
                    result[i / 2] = Convert.ToByte(hexChar, 16);
                }
            }
            catch { }
            return result;
        }
        public static string EncryptToHexString(string clearTextInput, byte[] keyBytes)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(clearTextInput))
                {
                    return clearTextInput;
                }
                byte[] binInput = Encoding.UTF8.GetBytes(clearTextInput);
                var binOutput = EncryptBinary(binInput, keyBytes);
                result = BitConverter.ToString(binOutput).Replace("-", "");
            }
            catch
            {
            }
            return result;
        }
        public static string DecryptFromHexString(string hexInput, byte[] keyBytes)
        {
            string result = default;
            try
            {
                if (string.IsNullOrEmpty(hexInput))
                {
                    return default;
                }
                byte[] binInput = Hex2Bytes(hexInput);
                var binOutput = DecryptBinary(binInput, keyBytes);
                result = Encoding.UTF8.GetString(binOutput);
            }
            catch { }
            return result;
        }
        public static string Hidden(string input, int hiddenCharacter = 0x6c)
        {
            return string.Join("", input.Select(ite => $"{Convert.ToChar( hiddenCharacter)}"));
        }
        #endregion
    }
}
