using System.Threading.Tasks;
using t7e.common.Dtos;

namespace t7e.db.Services.Interfaces
{
    public interface IImportExportService
    {
        Task ImportTranslationFileAsync(ImportFile model);
    }
}
