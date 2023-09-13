using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace VSSystem.IO.Extensions
{
    public static class FileInfoExtension
    {
        const int BUFF_BLOCK_SIZE = 4194304; // 4mb
        const int THREAD_BLOCK_SIZE = 268435456; // 256mb
        public static void FastCopyTo(this FileInfo srcFile, string destinationFileName)
        {

            try
            {
                if (srcFile.Exists)
                {
                    FileInfo destinationFile = new FileInfo(destinationFileName);
                    if (!destinationFile.Directory.Exists)
                    {
                        destinationFile.Directory.Create();
                    }

                    using (var destStream = new FileStream(destinationFileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {

                        try
                        {
                            destStream.SetLength(srcFile.Length);
                            destStream.Close();
                            destStream.Dispose();
                        }
                        catch
                        {
                            throw new Exception("Cannot create destination file");
                        }
                    }

                    int nThread = Convert.ToInt32(srcFile.Length / THREAD_BLOCK_SIZE);

                    var splitSizes = GetSplitSizes(srcFile.Length, nThread);

                    var tasks = splitSizes.Select((ite, idx) => Task.Run(() =>
                    {

                        try
                        {
                            Thread.Sleep(10);
                            using (var srcStream = srcFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                            {

                                srcStream.Seek(ite.Key, SeekOrigin.Begin);

                                using (var destStream = destinationFile.Open(FileMode.Open, FileAccess.Write, FileShare.Write))
                                {
                                    destStream.Seek(ite.Key, SeekOrigin.Begin);
                                    int ret = 0;
                                    long pos = ite.Key;
                                    do
                                    {
                                        byte[] buff = new byte[BUFF_BLOCK_SIZE];
                                        ret = srcStream.Read(buff, 0, buff.Length);
                                        destStream.Write(buff, 0, ret);
                                        pos += ret;
                                    }
                                    while (ret > 0 && pos < ite.Value);

                                    destStream.Close();
                                    destStream.Dispose();
                                }

                                srcStream.Close();
                                srcStream.Dispose();
                            }
                        }
                        catch
                        {
                        }

                    })).ToArray();

                    Task.WaitAll(tasks);

                    File.SetCreationTime(destinationFileName, srcFile.CreationTime);
                    File.SetCreationTimeUtc(destinationFileName, srcFile.CreationTimeUtc);

                    File.SetLastAccessTime(destinationFileName, srcFile.LastAccessTime);
                    File.SetLastAccessTimeUtc(destinationFileName, srcFile.LastAccessTimeUtc);

                    File.SetLastWriteTime(destinationFileName, srcFile.LastWriteTime);
                    File.SetLastWriteTimeUtc(destinationFileName, srcFile.LastWriteTimeUtc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CopyToV2(this FileInfo srcFile, string destinationFileName, bool overwrite = false)
        {

            try
            {
                srcFile.CopyTo(destinationFileName, overwrite);

                //File.SetCreationTime(destinationFileName, srcFile.CreationTime);
                File.SetCreationTimeUtc(destinationFileName, srcFile.CreationTimeUtc);

                //File.SetLastAccessTime(destinationFileName, srcFile.LastAccessTime);
                File.SetLastAccessTimeUtc(destinationFileName, srcFile.LastAccessTimeUtc);

                //File.SetLastWriteTime(destinationFileName, srcFile.LastWriteTime);
                File.SetLastWriteTimeUtc(destinationFileName, srcFile.LastWriteTimeUtc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CopyToV2(this string srcFileName, string destinationFileName, bool overwrite = false)
        {

            try
            {
                CopyToV2(new FileInfo(srcFileName), destinationFileName, overwrite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static List<KeyValuePair<long, long>> GetSplitSizes(long contentLength, int nThread)
        {
            try
            {
                if (nThread <= 0)
                {
                    return new List<KeyValuePair<long, long>>()
                    {
                        new KeyValuePair<long, long>(0, contentLength -1)
                    };
                }
                long ctLength = contentLength;
                long jumpLength = ctLength / nThread;
                List<KeyValuePair<long, long>> result = new List<KeyValuePair<long, long>>();
                long pos = 0;
                do
                {
                    if (jumpLength < ctLength)
                    {
                        result.Add(new KeyValuePair<long, long>(pos, pos + jumpLength - 1));
                        pos += jumpLength;
                        ctLength -= jumpLength;
                    }
                    else
                    {
                        result.Add(new KeyValuePair<long, long>(pos, pos + ctLength - 1));
                        ctLength = 0;
                    }
                } while (ctLength > 0);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsSame(this FileInfo srcFile, FileInfo desFile, bool checkMd5)
        {
            if (desFile.Exists)
            {
                if (srcFile.Length == desFile.Length)
                {
                    if (checkMd5)
                    {
                        var srcMD5 = GetMd5Bytes(srcFile);
                        var destMD5 = GetMd5Bytes(desFile);
                        return srcMD5?.SequenceEqual(destMD5) ?? false;
                    }
                    else
                    {
                        return srcFile.LastWriteTimeUtc.Ticks == desFile.LastWriteTimeUtc.Ticks;
                    }
                }
            }
            return false;
        }
        public static byte[] GetMd5Bytes(this FileInfo file)
        {
            byte[] result = null;
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        result = md5.ComputeHash(stream);
                        stream.Close();
                        stream.Dispose();
                    }
                    md5.Dispose();
                }
            }
            catch { }
            return result;
        }
        public static string GetMd5Base64(this FileInfo file)
        {
            string result = string.Empty;
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        result = Convert.ToBase64String(md5.ComputeHash(stream));
                        stream.Close();
                        stream.Dispose();
                    }
                    md5.Dispose();
                }
            }
            catch { }
            return result;
        }


        public static string GetMd5Hex(this FileInfo file)
        {
            string result = string.Empty;
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var md5Bytes = md5.ComputeHash(stream);
                        result = BitConverter.ToString(md5Bytes).Replace("-", "").ToUpper();
                        stream.Close();
                        stream.Dispose();
                    }
                    md5.Dispose();
                }
            }
            catch { }
            return result;
        }

        public static EFileType GetFileType(this FileInfo file)
        {
            EFileType result = EFileType.Unknown;
            try
            {
                string[] videoExts = new string[] { ".mov", ".mp4", ".flv", ".mpg", ".avi", ".divx", ".wmv" };
                string[] imageExts = new string[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
                string[] audioExts = new string[] { ".mp3", ".mid", ".midi", ".wav", ".wma", ".ogg" };
                string[] textExts = new string[] { ".txt", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".pdf" };

                if (videoExts.Contains(file.Extension, StringComparer.InvariantCultureIgnoreCase))
                {
                    result += (int)EFileType.Video;
                }
                if (imageExts.Contains(file.Extension, StringComparer.InvariantCultureIgnoreCase))
                {
                    result += (int)EFileType.Image;
                }
                if (audioExts.Contains(file.Extension, StringComparer.InvariantCultureIgnoreCase))
                {
                    result += (int)EFileType.Audio;
                }
                if (textExts.Contains(file.Extension, StringComparer.InvariantCultureIgnoreCase))
                {
                    result += (int)EFileType.Text;
                }
            }
            catch { }
            return result;
        }

        public static void CopyToV3(this FileInfo srcFile, string destinationFileName, bool overwrite = false)
        {

            try
            {
                if (srcFile?.Exists ?? false)
                {
                    FileInfo destFile = new FileInfo(destinationFileName);
                    if (!destFile.Directory.Exists)
                    {
                        destFile.Directory.Create();
                    }
                    if (overwrite)
                    {
                        using (var srcStream = srcFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (var desStream = destFile.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
                            {
                                desStream.SetLength(0);
                                srcStream.CopyTo(desStream);
                                desStream.Close();
                            }
                            srcStream.Close();
                        }
                        Thread.Sleep(100);
                        File.SetCreationTimeUtc(destinationFileName, srcFile.CreationTimeUtc);
                        File.SetLastAccessTimeUtc(destinationFileName, srcFile.LastAccessTimeUtc);
                        File.SetLastWriteTimeUtc(destinationFileName, srcFile.LastWriteTimeUtc);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CopyToV3(this string srcFileName, string destinationFileName, bool overwrite = false)
        {
            CopyToV3(new FileInfo(srcFileName), destinationFileName, overwrite);
        }
    }
}
