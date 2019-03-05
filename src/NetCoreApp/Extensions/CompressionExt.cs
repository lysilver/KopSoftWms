using System.IO;
using System.IO.Compression;

namespace YL.NetCoreApp.Extensions
{
    public class CompressionExt
    {
        public static Stream DecompressWithBrotli(Stream toDecompress)
        {
            MemoryStream decompressedStream = new MemoryStream();
            using (BrotliStream decompressionStream = new BrotliStream(toDecompress, CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(decompressedStream);
            }
            decompressedStream.Position = 0;
            return decompressedStream;
        }

        /// <summary>
        /// Br压缩
        /// </summary>
        /// <param name="toDecompress"></param>
        /// <returns></returns>
        public static Stream CompressWithBrotli(Stream toDecompress)
        {
            MemoryStream decompressedStream = new MemoryStream();
            using (BrotliStream decompressionStream = new BrotliStream(toDecompress, CompressionMode.Compress))
            {
                decompressionStream.CopyTo(decompressedStream);
            }
            decompressedStream.Position = 0;
            return decompressedStream;
        }
    }
}