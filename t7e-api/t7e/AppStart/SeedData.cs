using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using t7e.db.Context;
using t7e.db.Entities;

namespace t7e.AppStart
{
    public static class SeedData
    {
        public static async Task EnsureLanguages(T7eDbContext context)
        {
            var languageList = new List<Language>();
            languageList.Add(new Language {Id = Guid.NewGuid(), LanguageIsoCode = "en", LanguageName = "English"});
            languageList.Add(new Language {Id = Guid.NewGuid(), LanguageIsoCode = "de", LanguageName = "Deutsch"});
            languageList.Add(new Language {Id = Guid.NewGuid(), LanguageIsoCode = "fr", LanguageName = "Französisch" });

            foreach (var language in languageList)
            {
                var current =
                    await context.Languages.SingleOrDefaultAsync(x => x.LanguageIsoCode == language.LanguageIsoCode);

                if (current != null)
                    continue;

                context.Languages.Add(language);
            }

            await context.SaveChangesAsync();
        }
    }
}
