using System;
using System.ComponentModel.DataAnnotations;

namespace FileUpload.Dtos
{
    public class FileCreateDto
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }
    }
}