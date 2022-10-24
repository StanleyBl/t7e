using System;
using System.Linq;
using AutoMapper;
using t7e.common.Dtos;
using t7e.common.Models;
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

            CreateMap<TranslationKeyDto, TranslationKey>();

            CreateMap<TranslationKey, TranslationKeyDto>()
                .AfterMap((src, dest) =>
                {
                    dest.Translations.Clear();

                    foreach (var lang in src.Project.ProjectLanguages.OrderBy(x => x.Order))
                    {
                        var translation = src.Translations.FirstOrDefault(x => x.LanguageId == lang.LanguageId);
                        if (translation != null)
                        {
                            dest.Translations.Add(new TranslationDto
                            {
                                LanguageId = lang.LanguageId,
                                Reviewed = translation.Reviewed,
                                Id = translation.Id,
                                TranslationKeyId = translation.TranslationKeyId,
                                Value = translation.Value,
                                LanguageName = lang.Language?.LanguageName
                            });
                        }
                        else
                        {
                            dest.Translations.Add(new TranslationDto
                            {
                                Id = Guid.Empty,
                                TranslationKeyId = src.Id,
                                LanguageId = lang.LanguageId,
                                Reviewed = false,
                                LanguageName = lang.Language?.LanguageName
                            });
                        }
                    }
                });

            CreateMap<Translation, TranslationDto>().ReverseMap();

            CreateMap<ImportFile, ImportTranslation>();
        }
    }
}
