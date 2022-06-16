using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using t7e.common.Dtos;

namespace t7e.db.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<List<LanguageDto>> GetAvailableLanguagesAsync();
    }
}
