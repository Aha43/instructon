using System.Text.Json;

namespace Instructon.Engine.Xml;

public static class Extensions
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
        IncludeFields = true, // for records with positional fields
    };

    public static string ToJsonString<T>(this T o) where T : class
        => JsonSerializer.Serialize(o, _jsonOptions);

    public static string ToXmlString<T>(this T o) where T : class
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        using var writer = new StringWriter();
        serializer.Serialize(writer, o);
        return writer.ToString();
    }

}
