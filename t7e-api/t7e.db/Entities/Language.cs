using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace t7e.db.Entities
{
    public class Language
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string LanguageIsoCode { get; set; }

        [Required]
        public string LanguageName { get; set; }
    }
}
