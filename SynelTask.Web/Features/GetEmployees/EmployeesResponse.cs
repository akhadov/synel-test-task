namespace SynelTask.Web.Features.GetEmployees;

public sealed record EmployeesResponse
{
    public string PayrollNumber { get; init; }
    public string Forenames { get; init; }
    public string Surname { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public string Telephone { get; init; }
    public string Mobile { get; init; }
    public string Address { get; init; }
    public string Address2 { get; init; }
    public string Postcode { get; init; }
    public string EmailHome { get; init; }
    public DateTime? StartDate { get; init; }
}
