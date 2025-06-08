using Instructon.Engine.Xml.Elements.Site;

namespace Instructon.Engine.Xml;

public static class Parser
{
    private static T Parse<T>(string xml) where T : class
    {
        if (string.IsNullOrWhiteSpace(xml))
            throw new ArgumentException("XML content cannot be null or empty.", nameof(xml));

        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        using var reader = new StringReader(xml);
        return (T)serializer.Deserialize(reader)!;
    }

    public static SiteConfig ParseSiteConfig(string xml) => Parse<SiteConfig>(xml);

    public static SiteConfig ParseSiteConfigFromFile(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

        if (!File.Exists(filePath))
            throw new FileNotFoundException("The specified file does not exist.", filePath);

        var xml = File.ReadAllText(filePath);
        return ParseSiteConfig(xml);
    }
    
}
