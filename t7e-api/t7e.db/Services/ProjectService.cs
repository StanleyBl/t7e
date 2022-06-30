using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using t7e.common.Dtos;
using t7e.db.Context;
using t7e.db.Entities;
using t7e.db.Services.Interfaces;

namespace t7e.db.Services
{
    public class ProjectService : IProjectService
    {
        private readonly T7eDbContext _ctx;
        private readonly IMapper _mapper;

        public ProjectService(T7eDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<ProjectDto>> GetProjectListAsync()
        {
            var list = await _ctx.Projects
                .Include(e => e.ProjectLanguages)
                .ThenInclude(e => e.Language)
                .AsNoTracking()
                .ToListAsync();

            return list.Select(x => _mapper.Map<ProjectDto>(x)).ToList();
        }

        public async Task<List<ProjectInfoDto>> GetProjectInfoListAsync()
        {
            var list = await _ctx.Projects
                .Include(e => e.ProjectLanguages)
                .ThenInclude(e => e.Language)
                .Include(e => e.TranskationKeys)
                .ThenInclude(e => e.Translations)
                .AsNoTracking()
                .ToListAsync();

            var result = new List<ProjectInfoDto>();
            foreach (var project in list)
            {
                var entry = new ProjectInfoDto
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    LogoUrl = project.LogoUrl,
                    TranslationCount = project.TranskationKeys.Count
                };

                foreach (var language in project.ProjectLanguages.OrderBy(x => x.Order))
                {
                    var translationEntry = new TranslationInfoDto
                    {
                        LanguageId = language.LanguageId, 
                        LanguageName = language.Language.LanguageName,
                        LanguageIsoCode = language.Language.LanguageIsoCode,
                    };

                    foreach (var key in project.TranskationKeys)
                    {
                        var translation = key.Translations.FirstOrDefault(x => x.LanguageId == language.LanguageId);

                        if (translation == null || string.IsNullOrEmpty(translation?.Value))
                        {
                            translationEntry.IncompleteCount++;
                            continue;
                        }

                        if (translation.Reviewed)
                            translationEntry.ReviewedCount++;

                        if (!string.IsNullOrEmpty(translation.Value))
                            translationEntry.CompleteCount++;
                    }

                    entry.Translations.Add(translationEntry);
                }

                result.Add(entry);
            }

            return result;
        }

        public async Task<ProjectDto> GetProjectByIdAsync(Guid id)
        {
            var result = await _ctx.Projects
                .Include(e => e.ProjectLanguages)
                .ThenInclude(e => e.Language)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ProjectDto>(result);
        }

        public async Task AddOrUpdateProjectAsync(ProjectDto project)
        {
            var currentProject = await _ctx.Projects
                .Include(e => e.ProjectLanguages)
                .FirstOrDefaultAsync(x => x.Id == project.Id);

            if (currentProject == null || project.Id == Guid.Empty)
            {
                var dbProject = _mapper.Map<Project>(project);
                dbProject.Id = Guid.NewGuid();
                _ctx.Projects.Add(dbProject);
            }
            else
            {
                _mapper.Map(project, currentProject);
            }

            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteProject(Guid id)
        {
            var currentProject = await _ctx.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (currentProject != null)
            {
                _ctx.Projects.Remove(currentProject);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task AddLanguageToProjectAsync(Guid projectId, Guid languageId)
        {
            var projectLanguage =
                await _ctx.ProjectLanguages.FirstOrDefaultAsync(x =>
                    x.ProjectId == projectId && x.LanguageId == languageId);

            if (projectLanguage == null)
            {
                _ctx.ProjectLanguages.Add(new ProjectLanguage { LanguageId = languageId, ProjectId = projectId });
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task RemoveLanguageFromProjectAsync(Guid projectId, Guid languageId)
        {
            var projectLanguage =
                await _ctx.ProjectLanguages.FirstOrDefaultAsync(x =>
                    x.ProjectId == projectId && x.LanguageId == languageId);

            if (projectLanguage != null)
            {
                var translations = await _ctx.TranslationKeys
                    .Include(e => e.Translations)
                    .Where(x => x.ProjectId == projectId)
                    .SelectMany(x => x.Translations)
                    .ToListAsync();

                foreach (var translation in translations.Where(x => x.LanguageId == languageId))
                {
                    _ctx.Translations.Remove(translation);
                }

                _ctx.ProjectLanguages.Remove(projectLanguage);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
