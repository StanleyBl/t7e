using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using t7e.common.Dtos;
using t7e.db.Services.Interfaces;

namespace t7e.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ImportExportController : ControllerBase
    {
        private readonly IImportExportService _importExportService;

        public ImportExportController(IImportExportService importExportService)
        {
            _importExportService = importExportService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] ImportFile file)
        {
            await _importExportService.ImportTranslationFileAsync(file);
            return Ok();
        }
    }
}
