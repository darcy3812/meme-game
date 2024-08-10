using MemeGame.Application.FileStorage;
using MemeGame.Infrastructure.FileStorages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MemeGame.API.Controllers
{
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IFileStorage _fileStorage;

        public StorageController(IFileStorage fileStorage)
        {
            _fileStorage = fileStorage;
        }

        [HttpPost("api/upload")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload(IFormFile file)
        {

            var filesummary = new FileSummary
            {
                Extension = file.FileName.Split('.')[^1],
                Name = file.FileName.Split('.')[0]

            };
            await _fileStorage.SaveAsync(filesummary, file.OpenReadStream());

            return Ok();
        }

        [HttpPost("api/download")]
        [AllowAnonymous]
        public async Task<IActionResult> Download(int id)
        {
            var file = await _fileStorage.GetContentsAsync(id);

            return File(file.Stream, "image/jpg", fileDownloadName: file.Name);
        }
    }
}
