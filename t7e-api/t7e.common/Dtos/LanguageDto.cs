using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t7e.common.Dtos
{
    public class LanguageDto
    {
        public Guid Id { get; set; }

        public string LanguageIsoCode { get; set; }

        public string LanguageName { get; set; }
    }
}
