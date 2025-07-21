using CsvHelper.Configuration.Attributes;

namespace SynelTask.Web.Entities;

public sealed class Employee
{
    [Ignore]
    public int Id { get; set; }

    [Name("Personnel_Records.Payroll_Number")]
    public string PayrollNumber { get; set; } = string.Empty;

    [Name("Personnel_Records.Forenames")]
    public string Forenames { get; set; } = string.Empty;

    [Name("Personnel_Records.Surname")]
    public string Surname { get; set; } = string.Empty;

    [Name("Personnel_Records.Date_of_Birth")]
    [TypeConverter(typeof(FlexibleDateTimeConverter))]
    public DateTime? DateOfBirth { get; set; }

    [Name("Personnel_Records.Telephone")]
    public string Telephone { get; set; } = string.Empty;

    [Name("Personnel_Records.Mobile")]
    public string Mobile { get; set; } = string.Empty;

    [Name("Personnel_Records.Address")]
    public string Address { get; set; } = string.Empty;

    [Name("Personnel_Records.Address_2")]
    public string Address2 { get; set; } = string.Empty;

    [Name("Personnel_Records.Postcode")]
    public string Postcode { get; set; } = string.Empty;

    [Name("Personnel_Records.EMail_Home")]
    public string EmailHome { get; set; } = string.Empty;

    [Name("Personnel_Records.Start_Date")]
    [TypeConverter(typeof(FlexibleDateTimeConverter))]
    public DateTime? StartDate { get; set; }
}