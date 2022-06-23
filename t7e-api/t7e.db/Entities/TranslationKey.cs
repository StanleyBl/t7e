using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace t7e.db.Entities
{
    public class TranslationKey
    {
        public TranslationKey()
        {
            Translations = new List<Translation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        public string Description { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public virtual Project Project { get; set; }

        public ICollection<Translation> Translations { get; set; }
    }
}
