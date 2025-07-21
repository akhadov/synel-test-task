using SynelTask.Web.Common;

namespace SynelTask.Web.Features.ImportCsv;

public interface IImportCsvHandler
{
    Task<Result<ImportCsvResult>> HandleAsync(
        ImportCsvRequest request,
        CancellationToken cancellationToken = default);
}
