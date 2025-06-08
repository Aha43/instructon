using System.Text.Json;

namespace Instructon.Engine.Xml.Elements.Site;

public static class Extensions
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true, // for records with positional fields
    };

    public static string ToPrettyString<T>(this T o) where T : class
        => JsonSerializer.Serialize(o, _jsonOptions);

}
