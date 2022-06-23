using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using t7e.common.Dtos;
using t7e.db.Context;
using t7e.db.Entities;
using t7e.db.Services.Interfaces;

namespace t7e.db.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly T7eDbContext _ctx;
        private readonly IMapper _mapper;

        public TranslationService(T7eDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<TranslationKeyDto>> GetTranslationsForProjectAsync(Guid projectId, string searchTerm = null)
        {
            //var result = await _ctx.TranslationKeys
            //    .Include(e => e.Project)
            //    .ThenInclude(e => e.ProjectLanguages)
            //    .ThenInclude(e => e.Language)
            //    .Include(e => e.Translations)
            //    .ThenInclude(e => e.Language)
            //    .Where(x => x.ProjectId == projectId)
            //    .OrderByDescending(x => x.Created)
            //    .AsNoTracking()
            //    .ToListAsync();

            var query = _ctx.TranslationKeys
                .Include(e => e.Project)
                .ThenInclude(e => e.ProjectLanguages)
                .ThenInclude(e => e.Language)
                .Include(e => e.Translations)
                .ThenInclude(e => e.Language)
                .Where(x => x.ProjectId == projectId);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query
                    .Where(x => x.Key.Contains(searchTerm) || x.Description.Contains(searchTerm) ||
                                x.Translations.Any(y => y.Value.Contains(searchTerm)));
            }

            var result = await query
                .OrderByDescending(x => x.Created)
                .AsNoTracking()
                .ToListAsync();

            return result.Select(x => _mapper.Map<TranslationKeyDto>(x)).ToList();
        }

        public async Task<TranslationKeyDto> AddKeyAsync(TranslationKeyDto key)
        {
            try
            {
                var dbKey = _mapper.Map<TranslationKey>(key);
                dbKey.Id = Guid.NewGuid();
                dbKey.Created = DateTime.Now;
                dbKey.Updated = DateTime.Now;
                _ctx.TranslationKeys.Add(dbKey);
                await _ctx.SaveChangesAsync();

                var result = await _ctx.TranslationKeys
                    .Include(e => e.Project)
                    .ThenInclude(e => e.ProjectLanguages)
                    .ThenInclude(e => e.Language)
                    .Include(e => e.Translations)
                    .ThenInclude(e => e.Language)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == dbKey.Id);

                return _mapper.Map<TranslationKeyDto>(result);
            }
            catch (Exception e)
            {
                // log?
                throw e;
            }
        }

        public async Task<TranslationKeyDto> UpdateKeyAsync(TranslationKeyDto key)
        {
            try
            {
                var dbKey = await _ctx.TranslationKeys.FirstOrDefaultAsync(x => x.Id == key.Id);

                if (dbKey == null)
                    return null;

                dbKey.Updated = DateTime.Now;
                dbKey.Key = key.Key;
                dbKey.Description = key.Description;

                await _ctx.SaveChangesAsync();

                return key;
            }
            catch (Exception e)
            {
                // log?
                throw e;
            }
        }

        public async Task RemoveKeyAsync(Guid id)
        {
            var currentKey = await _ctx.TranslationKeys.FirstOrDefaultAsync(x => x.Id == id);

            if (currentKey != null)
            {
                _ctx.TranslationKeys.Remove(currentKey);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<TranslationDto> UpdateTranslationAsync(TranslationDto translation)
        {
            var currentTranslation = await _ctx.Translations.FirstOrDefaultAsync(x => x.Id == translation.Id);

            if (currentTranslation != null)
            {
                _mapper.Map(translation, currentTranslation);
            }
            else
            {
                currentTranslation = _mapper.Map<Translation>(translation);
                currentTranslation.Id = Guid.NewGuid();
                _ctx.Translations.Add(currentTranslation);
            }

            await _ctx.SaveChangesAsync();

            return _mapper.Map<TranslationDto>(currentTranslation);
        }
    }
}
