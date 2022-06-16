using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using t7e.common.Dtos;

namespace t7e.db.Services.Interfaces
{
    public interface ITranslationService
    {
        Task<List<TranslationKeyDto>> GetTranslationsForProjectAsync(Guid projectId);

        Task AddKeyAsync(TranslationKeyDto key);

        Task RemoveKeyAsync(Guid id);

        Task<TranslationDto> UpdateTranslationAsync(TranslationDto translation);
    }
}
