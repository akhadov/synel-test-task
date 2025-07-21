using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace SynelTask.Web.Entities;

public class FlexibleDateTimeConverter : DefaultTypeConverter
{
    private readonly string[] _dateFormats =
    {
        "dd/MM/yyyy",
        "d/MM/yyyy",
        "dd/M/yyyy",
        "d/M/yyyy"
    };

    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text))
            return null;

        foreach (var format in _dateFormats)
        {
            if (DateTime.TryParseExact(text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return DateTime.SpecifyKind(result, DateTimeKind.Utc);
            }
        }

        // If none of the specific formats work, try general parsing
        if (DateTime.TryParse(text, out DateTime generalResult))
        {
            return DateTime.SpecifyKind(generalResult, DateTimeKind.Utc);
        }

        throw new TypeConverterException(this, memberMapData, text, row.Context, $"Unable to parse date '{text}' with any of the expected formats.");
    }
}