using System;
using System.Threading.Tasks;
using AutoMapper;
using FileUpload.Common;
using FileUpload.Data;
using FileUpload.Dtos;
using FileUpload.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IUploadFileRepo _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public UploadFileController(IUploadFileRepo repository,
         IWebHostEnvironment webHostEnvironment,
         IMapper mapper)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<FileCreateDto> CreateCommand(FileCreateDto fileCreateDto)
        {
            var fileModel = _mapper.Map<FileDetails>(fileCreateDto);
            _repository.CreateFile(fileModel);
            _repository.SaveChanges();
            var fileReadDto = _mapper.Map<FileReadDto>(fileModel);
            return CreatedAtRoute(nameof(GetFileUploadedId), new { Id = fileReadDto.Id }, fileReadDto);
        }

        [HttpPut]
        public async Task<IActionResult> CreateFile([FromForm] FileUpdateDto fileUpdateDto)
        {
            var fileItem = _repository.GetFileUploadedId(fileUpdateDto.Id);
            if (fileItem == null)
            {
                return NotFound();
            }

            if (fileUpdateDto.file.Length > 0)
            {
                try
                {
                    string filePath = await CommonUtil.fileUploadToDirectory(
                        _webHostEnvironment,
                    fileUpdateDto.file);

                    if (filePath == null)
                        return BadRequest("File Uploading Failed");

                    fileItem.FilePath = filePath;
                    _repository.UpdateFile(fileItem);
                    _repository.SaveChanges();
                    return Ok("File Uploaded Successfully");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message.ToString());
                }
            }
            else
            {
                return BadRequest("File is not present. Please check your request body");
            }

        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetFileUploadedId")]
        public ActionResult<FileDetails> GetFileUploadedId(Guid id)
        {
            var fileItem = _repository.GetFileUploadedId(id);
            if (fileItem != null)
            {
                return Ok(fileItem);
            }
            return NotFound();
        }

    }
}