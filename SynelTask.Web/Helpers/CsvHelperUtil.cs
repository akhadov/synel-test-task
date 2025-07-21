using CsvHelper;
using System.Globalization;

namespace SynelTask.Web.Helpers;

public static class CsvHelperUtil
{
    public static List<T> ReadCsv<T>(string filePath)
    {
        using var reader = new StreamReader(filePath);

        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        return csv.GetRecords<T>().ToList();
    }
}
