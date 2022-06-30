using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using t7e.common.Dtos;

namespace t7e.db.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetProjectListAsync();

        Task<List<ProjectInfoDto>> GetProjectInfoListAsync();

        Task<ProjectDto> GetProjectByIdAsync(Guid id);

        Task AddOrUpdateProjectAsync(ProjectDto project);

        Task DeleteProject(Guid id);

        Task AddLanguageToProjectAsync(Guid projectId, Guid languageId);

        Task RemoveLanguageFromProjectAsync(Guid projectId, Guid languageId);
    }
}
