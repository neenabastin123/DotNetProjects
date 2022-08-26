using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Dtos
{
    public class FileUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public IFormFile file { get; set; }
    }
}