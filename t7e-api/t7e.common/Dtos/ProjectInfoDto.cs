using System;
using System.Collections.Generic;
using System.Linq;

namespace t7e.common.Dtos
{
    public class ProjectInfoDto
    {
        public ProjectInfoDto()
        {
            Translations = new List<TranslationInfoDto>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public int TranslationCount { get; set; }

        public double CompleteCountPercent => Math.Round(Translations.Average(x => x.CompleteCountPercent), 2);

        public double ReviewedCountPercent => Math.Round(Translations.Average(x => x.ReviewedCountPercent), 2);

        public List<TranslationInfoDto> Translations { get; set; }
    }

    public class TranslationInfoDto
    {
        public Guid LanguageId { get; set; }

        public string LanguageIsoCode { get; set; }

        public string LanguageName { get; set; }

        public int CompleteCount { get; set; }

        public double CompleteCountPercent => GetPercentage(CompleteCount, (CompleteCount + IncompleteCount));

        public int IncompleteCount { get; set; }

        public int ReviewedCount { get; set; }

        public double ReviewedCountPercent => GetPercentage(ReviewedCount, (CompleteCount + IncompleteCount));

        private double GetPercentage(int openCount, int totalCount)
        {
            if (totalCount <= 0)
            {
                return 0.0;
            }
            return Math.Round((double)openCount / totalCount * 100.0, 2);
        }
    }
}
