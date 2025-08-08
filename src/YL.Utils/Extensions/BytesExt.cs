using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace YL.Utils.Extensions
{
    public enum EncodingType
    {
        ASCII,
        UTF8,
        gbk,
        gb2312,
        Default,
        Unicode
    }

    public static class BytesExt
    {
        public static byte[] ToBytes(this string str, EncodingType type = EncodingType.UTF8)
        {
            return type switch
            {
                EncodingType.ASCII => Encoding.ASCII.GetBytes(str),
                EncodingType.UTF8 => Encoding.UTF8.GetBytes(str),
                EncodingType.gbk => Encoding.GetEncoding("gbk").GetBytes(str),
                EncodingType.gb2312 => Encoding.GetEncoding("gb2312").GetBytes(str),
                EncodingType.Default => Encoding.Default.GetBytes(str),
                EncodingType.Unicode => Encoding.Unicode.GetBytes(str),
                _ => Encoding.UTF8.GetBytes(str),
            };
        }

        /// <summary>
        ///
        ///
        /// https://docs.microsoft.com/zh-cn/dotnet/api/system.text.encodinginfo.name?view=netframework-4.7.2
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Encoding GetEncoding(EncodingType type = EncodingType.UTF8)
        {
            return type switch
            {
                EncodingType.ASCII => Encoding.ASCII,
                EncodingType.UTF8 => Encoding.UTF8,
                EncodingType.gbk => Encoding.GetEncoding("gbk"),
                EncodingType.gb2312 => Encoding.GetEncoding(936),
                EncodingType.Default => Encoding.Default,
                EncodingType.Unicode => Encoding.Unicode,
                _ => Encoding.UTF8,
            };
        }

        public static string ByteToString(this byte[] bytes, EncodingType type = EncodingType.UTF8)
        {
            return type switch
            {
                EncodingType.ASCII => Encoding.ASCII.GetString(bytes),
                EncodingType.UTF8 => Encoding.UTF8.GetString(bytes),
                EncodingType.gbk => Encoding.GetEncoding("gbk").GetString(bytes),
                EncodingType.gb2312 => Encoding.GetEncoding("gb2312").GetString(bytes),
                EncodingType.Default => Encoding.Default.GetString(bytes),
                EncodingType.Unicode => Encoding.Unicode.GetString(bytes),
                _ => Encoding.UTF8.GetString(bytes),
            };
        }

        public static Stream ToStream(this byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            return stream;
        }

        public static BinaryReader GetBinaryReader(this byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                var binaryReader = new BinaryReader(memoryStream);
                return binaryReader;
            }
        }

        public static byte[] ToBytes(this Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
            //stream.Seek(0, SeekOrigin.Begin);
            //var bytes = new byte[stream.Length];
            //stream.Read(bytes, 0, bytes.Length);
            //stream.Seek(0, SeekOrigin.Begin);
            //return bytes;
        }

        public static string ReadToString(this Stream stream, Encoding encoding)
        {
            stream.Seek(0, SeekOrigin.Begin);
            string resStr = new StreamReader(stream, encoding).ReadToEnd();
            stream.Seek(0, SeekOrigin.Begin);
            return resStr;
        }

        public static byte[] Compress(this byte[] bytes)
        {
            using (var ms = new MemoryStream())
            {
                using (var gzip = new GZipStream(ms, CompressionMode.Compress))
                {
                    gzip.Write(bytes, 0, bytes.Length);
                }
                return ms.ToArray();
            }
        }

        public static byte[] Decompress(this byte[] bytes)
        {
            using (var ms = new MemoryStream())
            {
                using (var input = new MemoryStream(bytes))
                using (var gzip = new GZipStream(input, CompressionMode.Decompress))
                {
                    gzip.CopyTo(ms);
                }
                return ms.ToArray();
            }
        }

        public static byte[] CompressD(this byte[] bytes)
        {
            using (var ms = new MemoryStream())
            {
                using (var def = new DeflateStream(ms, CompressionMode.Compress))
                {
                    def.Write(bytes, 0, bytes.Length);
                }
                return ms.ToArray();
            }
        }

        public static byte[] DecompressD(this byte[] bytes)
        {
            using (var ms = new MemoryStream())
            {
                using (var input = new MemoryStream(bytes))
                using (var def = new DeflateStream(input, CompressionMode.Decompress))
                {
                    def.CopyTo(ms);
                }
                return ms.ToArray();
            }
        }
    }
}