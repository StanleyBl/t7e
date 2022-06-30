using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using t7e.common.Dtos;
using t7e.db.Services.Interfaces;

namespace t7e.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _projectService.GetProjectListAsync();
            return Ok(list);
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetInfo()
        {
            var list = await _projectService.GetProjectInfoListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            return Ok(project);
        }

        [HttpPut]
        public async Task<IActionResult> AddOrUpdate(ProjectDto project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _projectService.AddOrUpdateProjectAsync(project);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _projectService.DeleteProject(id);
            return Ok();
        }
    }
}
