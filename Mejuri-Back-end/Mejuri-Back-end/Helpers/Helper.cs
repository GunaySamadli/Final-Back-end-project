using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Helpers
{
    public static class Helper
    {
        public static void FileDelete(string path, string fileName)
        {
            string fullPath = Path.Combine(path, fileName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
    }
}
