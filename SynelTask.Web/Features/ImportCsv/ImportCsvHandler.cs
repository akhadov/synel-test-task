using SynelTask.Web.Common;
using SynelTask.Web.Database;
using SynelTask.Web.Entities;
using SynelTask.Web.Helpers;

namespace SynelTask.Web.Features.ImportCsv;

public sealed class ImportCsvHandler(
    IApplicationDbContext context) : IImportCsvHandler
{
    public async Task<Result<ImportCsvResult>> HandleAsync(ImportCsvRequest request, CancellationToken cancellationToken = default)
    {
        var result = new ImportCsvResult();

        List<Employee> employees = CsvHelperUtil.ReadCsv<Employee>(request.FilePath);

        context.Employees.AddRange(employees);

        await context.SaveChangesAsync(cancellationToken);

        result.TotalImports = employees.Count;

        return Result<ImportCsvResult>.Success(result);
    }
}
