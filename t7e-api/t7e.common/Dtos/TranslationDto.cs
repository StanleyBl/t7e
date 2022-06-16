using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t7e.common.Dtos
{
    public class TranslationDto
    {
        public Guid Id { get; set; }

        [Required]
        public Guid LanguageId { get; set; }

        [Required]
        public Guid TranslationKeyId { get; set; }

        public string Value { get; set; }

        public bool Reviewed { get; set; }
    }
}
