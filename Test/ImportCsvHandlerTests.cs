using Microsoft.EntityFrameworkCore;
using SynelTask.Web.Database;
using SynelTask.Web.Features.ImportCsv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test;

public class ImportCsvHandlerTests
{
    [Fact]
    public async Task HandleAsync_ImportsEmployeesFromCsvFile()
    {
        var tempFilePath = Path.GetTempFileName();

        await File.WriteAllTextAsync(tempFilePath, """
            Personnel_Records.Payroll_Number,Personnel_Records.Forenames,Personnel_Records.Surname,Personnel_Records.Date_of_Birth,Personnel_Records.Telephone,Personnel_Records.Mobile,Personnel_Records.Address,Personnel_Records.Address_2,Personnel_Records.Postcode,Personnel_Records.EMail_Home,Personnel_Records.Start_Date
            001,John,Doe,01/01/1990,1234567,9876543,123 Main St,,12345,john.doe@example.com,01/01/2020
            """);

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb_ImportCsv")
            .Options;

        await using var context = new ApplicationDbContext(options);

        var handler = new ImportCsvHandler(context);
        var request = new ImportCsvRequest(tempFilePath);

        var result = await handler.HandleAsync(request);

        Assert.True(result.IsSuccess);
        Assert.Equal(1, result.Value.TotalImports);
        Assert.Single(context.Employees);

        var employee = await context.Employees.FirstAsync();
        Assert.Equal("John", employee.Forenames);
        Assert.Equal("Doe", employee.Surname);
        Assert.Equal("001", employee.PayrollNumber);

        File.Delete(tempFilePath);
    }
}