using System;
using System.Linq;
using FileUpload.Model;

namespace FileUpload.Data
{
    public class UploadFileSQLRepo : IUploadFileRepo
    {
        private readonly UploadFileContext _context;

        public UploadFileSQLRepo(UploadFileContext context)
        {
            _context = context;
        }
        public void CreateFile(FileDetails fileDetails)
        {
            if (fileDetails == null)
            {
                throw new ArgumentNullException(nameof(fileDetails));
            }

            _context.FileDetails.Add(fileDetails);
        }

        public void UpdateFile(FileDetails fileDetails)
        {
            // Do nothing
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public FileDetails GetFileUploadedId(Guid id)
        {
            return _context.FileDetails.FirstOrDefault(p => p.Id == id);
        }

    }
}