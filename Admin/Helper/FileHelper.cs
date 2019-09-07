using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Admin.Helper
{
    public class FileHelper
    {
        public string PhotoSave(IFormFile photoFile, string path)
        {
            if (photoFile == null || photoFile.Length <= 0) return string.Empty;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var extension = Path.GetExtension(photoFile.FileName)?.ToLower();

            if (extension == null)
                return string.Empty;

            string[] supportedExtensions = { ".jpg", ".png", ".jpeg", ".gif" };

            if (!supportedExtensions.Contains(extension))
                return string.Empty;

            var getUniqueFileName = GetNextFileName(photoFile.FileName, path);
            var filepath = Path.Combine(path, getUniqueFileName);


            byte[] byteArray = Encoding.UTF8.GetBytes(filepath);
            MemoryStream stream = new MemoryStream(byteArray);
            photoFile.CopyTo(stream);

            return photoFile.FileName;
        }

        public string GetNextFileName(string fileName, string path)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;

            var pathName = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(pathName))
                return string.Empty;

            var extension = Path.GetExtension(fileName);
            var fileNameOnly = Path.Combine(pathName, Path.GetFileNameWithoutExtension(fileName));

            // If the file exists, keep trying until it doesn't
            var i = 0;
            while (File.Exists(fileName))
            {
                i += 1;
                fileName = $"{fileNameOnly}({i}).{extension}";
            }
            return fileName;
        }
    }
}
