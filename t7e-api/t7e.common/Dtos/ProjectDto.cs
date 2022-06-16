using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace t7e.common.Dtos
{
    public class ProjectDto
    {
        public ProjectDto()
        {
            AvailableLanguages = new List<LanguageDto>();
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public List<LanguageDto> AvailableLanguages { get; set; }
    }
}
