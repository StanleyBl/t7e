using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using t7e.common.Dtos;
using t7e.common.Models;
using t7e.db.Services.Interfaces;

namespace t7e.db.Services
{
    public class ImportExportService : IImportExportService
    {
        private readonly ITranslationService _translationService;
        private readonly IMapper _mapper;

        public ImportExportService(ITranslationService translationService, IMapper mapper)
        {
            _translationService = translationService;
            _mapper = mapper;
        }

        public async Task ImportTranslationFileAsync(ImportFile model)
        {
            var fileContent = await ReadFormFileAsync(model.File);

            var result = new Dictionary<string, string>();

            switch (model.File.ContentType)
            {
                case "application/json":
                    result = ReadJson(fileContent);
                    break;
            }

            if (result.Any())
            {
                var importModel = _mapper.Map<ImportTranslation>(model);
                importModel.Translations = result;

                await _translationService.ImportFromDictionaryAsync(importModel);
            }
        }

        private async Task<string> ReadFormFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return await Task.FromResult((string)null);
            }

            using var reader = new StreamReader(file.OpenReadStream());
            return await reader.ReadToEndAsync();
        }

        private Dictionary<string, string> ReadJson(string fileContent)
        {
            return JObject.Parse(fileContent)
                .Descendants()
                .OfType<JValue>()
                .ToDictionary(jv => jv.Path, jv => jv.ToString(CultureInfo.InvariantCulture));
        }
    }
}
