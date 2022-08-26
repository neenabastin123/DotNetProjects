using FileUpload.Model;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.Data
{
    public class UploadFileContext : DbContext
    {
        public UploadFileContext(DbContextOptions<UploadFileContext> opt) : base(opt)
        {

        }

        public DbSet<FileDetails> FileDetails { get; set; }

    }
}