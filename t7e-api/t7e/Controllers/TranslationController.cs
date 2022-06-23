using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using t7e.common.Dtos;
using t7e.db.Services.Interfaces;

namespace t7e.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService _translationService;

        public TranslationController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetTranslations([FromRoute] Guid projectId, [FromQuery] string searchTerm = null)
        {
            var translations = await _translationService.GetTranslationsForProjectAsync(projectId, searchTerm);
            return Ok(translations);
        }

        [HttpPost("key")]
        public async Task<IActionResult> AddKey(TranslationKeyDto key)
        {
            var result = await _translationService.AddKeyAsync(key);
            return Ok(result);
        }

        [HttpPut("key")]
        public async Task<IActionResult> UpdateKey(TranslationKeyDto key)
        {
            var result = await _translationService.UpdateKeyAsync(key);
            return Ok(result);
        }

        [HttpPost("translation")]
        public async Task<IActionResult> AddUpdateTranslation(TranslationDto model)
        {
            var result = await _translationService.UpdateTranslationAsync(model);
            return Ok(result);
        }
    }
}
