using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace YL.Utils.Extensions
{
    public static class FormFileExt
    {
        public static byte[] ReadAllBytes(this IFormFile self)
        {
            using (var reader = new BinaryReader(self.OpenReadStream()))
            {
                return reader.ReadBytes(Convert.ToInt32(self.Length));
            }
        }

        public static Task<byte[]> ReadAllBytesAsync(this IFormFile self)
        {
            return Task.Factory.StartNew(() =>
            {
                using (var reader = new BinaryReader(self.OpenReadStream()))
                {
                    return reader.ReadBytes(Convert.ToInt32(self.Length));
                }
            });
        }
    }
}