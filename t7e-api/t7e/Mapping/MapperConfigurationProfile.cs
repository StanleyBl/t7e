using AutoMapper;
using t7e.common.Dtos;
using t7e.db.Entities;

namespace t7e.Mapping
{
    public class MapperConfigurationProfile : Profile
    {
        public MapperConfigurationProfile()
        {
            CreateMap<Project, ProjectDto>()
                .AfterMap((src, dest) =>
                {
                    foreach (var language in src.ProjectLanguages)
                    {
                        dest.AvailableLanguages.Add(new LanguageDto
                        {
                            Id = language.LanguageId,
                            LanguageIsoCode = language.Language?.LanguageIsoCode,
                            LanguageName = language.Language?.LanguageName
                        });
                    }
                });

            CreateMap<ProjectDto, Project>()
                .AfterMap((src, dest) =>
                {
                    dest.ProjectLanguages.Clear();
                    foreach (var language in src.AvailableLanguages)
                    {
                        dest.ProjectLanguages.Add(new ProjectLanguage
                        {
                            LanguageId = language.Id,
                            ProjectId = dest.Id
                        });
                    }
                });

            CreateMap<Language, LanguageDto>().ReverseMap();

            CreateMap<TranslationKey, TranslationKeyDto>().ReverseMap();
            CreateMap<Translation, TranslationDto>().ReverseMap();
        }
    }
}
