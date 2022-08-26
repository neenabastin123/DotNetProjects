using Microsoft.AspNetCore.Http;

namespace FileUpload.Model
{
    public class FileInfo
    {
        public int Id { get; set; }
        public IFormFile file { get; set; }

    }

}