using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Common
{
    public static class CommonUtil
    {
        public static async Task<string> fileUploadToDirectory(
            IWebHostEnvironment _webHostEnvironment,
            IFormFile file)
        {
            try
            {
                if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\res\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\res\\");
                }
                using (FileStream fileStream = System.IO.File.Create(
                    _webHostEnvironment.WebRootPath + "\\res\\" + file.FileName))
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Flush();
                    return _webHostEnvironment.WebRootPath + "\\res\\" + file.FileName.ToString();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Upload is a failure" + ex.Message.ToString());
                return null;
            }

        }
    }
}