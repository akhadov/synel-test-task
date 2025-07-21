using SynelTask.Web.Common;

namespace SynelTask.Web.Features.GetEmployees
{
    public interface IGetEmployeesHandler
    {
        Task<Result<List<EmployeesResponse>>> HandleAsync(
            CancellationToken cancellationToken = default);
    }
}
