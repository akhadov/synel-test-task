using Microsoft.EntityFrameworkCore;
using SynelTask.Web.Database;
using SynelTask.Web.Entities;
using SynelTask.Web.Features.GetEmployees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test;

public class GetEmployeesHandlerTests
{
    [Fact]
    public async Task HandleAsync_ReturnsEmployeesSortedBySurname()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb_Employees")
            .Options;

        using var context = new ApplicationDbContext(options);
        context.Employees.AddRange(
            new Employee { Surname = "Brown", Forenames = "Alice", PayrollNumber = "001" },
            new Employee { Surname = "Adams", Forenames = "Bob", PayrollNumber = "002" }
        );
        await context.SaveChangesAsync();

        var handler = new GetEmployeesHandler(context);

        var result = await handler.HandleAsync();

        Assert.NotNull(result.Value);
        Assert.Equal(2, result.Value.Count);
        Assert.Equal("Adams", result.Value[0].Surname);
        Assert.Equal("Brown", result.Value[1].Surname);
    }
}