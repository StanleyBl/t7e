using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using t7e.db.Services.Interfaces;

namespace t7e.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _languageService.GetAvailableLanguagesAsync();
            return Ok(list);
        }
    }
}
