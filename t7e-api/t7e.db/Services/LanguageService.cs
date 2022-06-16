using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using t7e.common.Dtos;
using t7e.db.Context;
using t7e.db.Services.Interfaces;

namespace t7e.db.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly T7eDbContext _ctx;
        private readonly IMapper _mapper;

        public LanguageService(T7eDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<LanguageDto>> GetAvailableLanguagesAsync()
        {
            var languages = await _ctx.Languages
                .AsNoTracking()
                .ToListAsync();

            return languages.Select(x => _mapper.Map<LanguageDto>(x)).ToList();
        }
    }
}
