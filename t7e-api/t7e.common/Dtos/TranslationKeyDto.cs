using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t7e.common.Dtos
{
    public class TranslationKeyDto
    {
        public TranslationKeyDto()
        {
            Translations = new List<TranslationDto>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        public string Description { get; set; }

        public List<TranslationDto> Translations { get; set; }
    }
}
