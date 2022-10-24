using System;
using System.Collections.Generic;

namespace t7e.common.Models
{
    public class ImportTranslation
    {
        public ImportTranslation()
        {
            Translations = new Dictionary<string, string>();
        }

        public bool OverrideExisting { get; set; }

        public bool MarkNewAsReviewed { get; set; }

        public Guid LanguageId { get; set; }

        public Guid ProjectId { get; set; }

        public Dictionary<string, string> Translations { get; set; }
    }
}
