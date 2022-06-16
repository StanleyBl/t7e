using System;

namespace t7e.db.Entities
{
    public class ProjectLanguage
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
