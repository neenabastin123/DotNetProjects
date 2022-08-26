using System;
using System.ComponentModel.DataAnnotations;

namespace FileUpload.Dtos
{
    public class FileReadDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
    }
}