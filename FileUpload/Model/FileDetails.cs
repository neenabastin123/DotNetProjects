using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileUpload.Model
{
    public class FileDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public int FileSize { get; set; }

    }
}