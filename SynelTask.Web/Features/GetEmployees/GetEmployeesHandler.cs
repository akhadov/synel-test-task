using Microsoft.EntityFrameworkCore;
using SynelTask.Web.Common;
using SynelTask.Web.Database;

namespace SynelTask.Web.Features.GetEmployees;

public sealed class GetEmployeesHandler(
    IApplicationDbContext context) : IGetEmployeesHandler
{
    public async Task<Result<List<EmployeesResponse>>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result =  await context.Employees
            .OrderBy(e => e.Surname)
            .Select(e => new EmployeesResponse
            {
                PayrollNumber = e.PayrollNumber,
                Forenames = e.Forenames,
                Surname = e.Surname,
                DateOfBirth = e.DateOfBirth,
                Telephone = e.Telephone,
                Mobile = e.Mobile,
                Address = e.Address,
                Address2 = e.Address2,
                Postcode = e.Postcode,
                EmailHome = e.EmailHome,
                StartDate = e.StartDate
            })
            .ToListAsync(cancellationToken);

        return result;
    }
}
