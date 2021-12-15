using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Extentions
{
    public static class FileManager
    {
        public static bool CheckContent(this IFormFile file)
        {
            if (file.ContentType.Contains("image"))
            {
                return true;
            }
            return false;
        }

        public static bool CheckSize(this IFormFile file, int size)
        {
            if (file.Length / 1024 > size)
            {
                return true;
            }
            return false;
        }

        public async static Task<string> SaveImage(this IFormFile file, string path)
        {
            string fileName = Guid.NewGuid() + "_" + file.FileName;
            string filePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}
