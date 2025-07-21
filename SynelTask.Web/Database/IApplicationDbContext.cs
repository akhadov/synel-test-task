using Microsoft.EntityFrameworkCore;
using SynelTask.Web.Entities;

namespace SynelTask.Web.Database;

public interface IApplicationDbContext
{
    DbSet<Employee> Employees { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
