using AutoMapper;
using FileUpload.Dtos;
using FileUpload.Model;

namespace FileUpload.Profiles
{
    public class FileCreateProfile : Profile
    {
        public FileCreateProfile()
        {
            CreateMap<FileDetails, FileReadDto>();
            CreateMap<FileCreateDto, FileDetails>();
            CreateMap<FileUpdateDto, FileDetails>();
        }

    }
}