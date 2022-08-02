using System;
using Microsoft.AspNetCore.Http;

namespace t7e.common.Dtos
{
    public class ImportFile
    {
        public bool OverrideExisting { get; set; }

        public bool MarkNewAsReviewed { get; set; }

        public Guid LanguageId { get; set; }

        public Guid ProjectId { get; set; }

        public IFormFile File { get; set; }
    }
}
