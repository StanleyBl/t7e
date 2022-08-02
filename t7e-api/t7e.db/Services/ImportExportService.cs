using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using t7e.common.Dtos;
using t7e.db.Services.Interfaces;

namespace t7e.db.Services
{
    public class ImportExportService : IImportExportService
    {
        private readonly ITranslationService _translationService;

        public ImportExportService(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        public async Task ImportTranslationFileAsync(ImportFile model)
        {
            var result = new Dictionary<string, string>();

            switch (model.File.ContentType)
            {
                case "application/json":
                    result = ReadJson();
                    break;
            }
        }

        private Dictionary<string, string> ReadJson()
        {
            return new Dictionary<string, string>();
        }
    }
}
