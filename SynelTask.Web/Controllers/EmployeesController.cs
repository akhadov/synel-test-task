using Microsoft.AspNetCore.Mvc;
using SynelTask.Web.Features.GetEmployees;
using SynelTask.Web.Features.ImportCsv;

namespace SynelTask.Web.Controllers;

public class EmployeesController : Controller
{
    private readonly IGetEmployeesHandler _getEmployeesHandler;
    private readonly IImportCsvHandler _importCsvHandler;
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(
        ILogger<EmployeesController> logger,
        IGetEmployeesHandler getEmployeesHandler,
        IImportCsvHandler importCsvHandler)
    {
        _logger = logger;
        _getEmployeesHandler = getEmployeesHandler;
        _importCsvHandler = importCsvHandler;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ImportCsv(IFormFile file, CancellationToken cancellationToken)
    {
        if (file == null || file.Length == 0)
        {
            var error = "Please select a valid CSV file.";
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return Json(new { success = false, error });
            TempData["Message"] = error;
            return RedirectToAction("Index");
        }

        var filePath = Path.GetTempFileName();

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream, cancellationToken);
        }

        var result = await _importCsvHandler.HandleAsync(new ImportCsvRequest(filePath), cancellationToken);
        var count = result.Value.TotalImports;

        var successMessage = $"Successfully imported: {count} records.";

        // If AJAX request, return JSON
        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            return Json(new { success = true, count });
        }

        TempData["Message"] = successMessage;
        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var result = await _getEmployeesHandler.HandleAsync(CancellationToken.None);

        if (!result.IsSuccess)
        {
            return BadRequest(new { error = "Could not fetch employees." });
        }
        
        return Json(new { data = result.Value });
    }
}
