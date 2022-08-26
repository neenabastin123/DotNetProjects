using System;
using FileUpload.Model;

namespace FileUpload.Data
{
    public interface IUploadFileRepo
    {
        bool SaveChanges();
        void CreateFile(FileDetails fileDetails);
        void UpdateFile(FileDetails fileDetails);
        FileDetails GetFileUploadedId(Guid id);
    }
}