using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace t7e.db.Entities
{
    public class Project
    {
        public Project()
        {
            TranskationKeys = new List<TranslationKey>();
            ProjectLanguages = new List<ProjectLanguage>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }

        public ICollection<TranslationKey> TranskationKeys { get; set; }
        public ICollection<ProjectLanguage> ProjectLanguages { get; set; }
    }
}
