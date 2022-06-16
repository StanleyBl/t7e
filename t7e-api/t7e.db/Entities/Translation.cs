using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace t7e.db.Entities
{
    public class Translation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid LanguageId { get; set; }
        public virtual Language Language { get; set; }

        [Required]
        public Guid TranslationKeyId { get; set; }
        public virtual TranslationKey TranslationKey { get; set; }


        public string Value { get; set; }

        public bool Reviewed { get; set; }
    }
}
