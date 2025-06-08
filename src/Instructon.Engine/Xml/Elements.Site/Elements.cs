using System.Xml.Serialization;

namespace Instructon.Engine.Xml.Elements.Site;

[XmlRoot("site")]
public record SiteConfig
{
    [XmlAttribute("title")]
    public string Title { get; set; } = null!;

    [XmlAttribute("primary-language")]
    public string PrimaryLanguage { get; set; } = "en";

    [XmlAttribute("content-directory")]
    public string ContentDirectory { get; set; } = null!;

    [XmlAttribute("output-directory")]
    public string OutputDirectory { get; set; } = null!;

    [XmlAttribute("image-directory")]
    public string? ImageDirectory { get; set; }

    [XmlAttribute("video-directory")]
    public string? VideoDirectory { get; set; }

    [XmlArray("topics")]
    [XmlArrayItem("topic")]
    public Topic[] Topics { get; set; } = [];
}

public record Topic
{
    [XmlElement("title")]
    public Title Title { get; set; } = null!;

    [XmlArray("pages")]
    [XmlArrayItem("page")]
    public List<PageRef> Pages { get; set; } = [];
}

public record Title
{
    [XmlElement("text")]
    public List<LocalizedText> Texts { get; set; } = [];

    public string GetText(string lang)
    {
        return Texts.Find(t => t.Lang == lang)?.Value ?? string.Empty;
    }
}

public record LocalizedText
{
    [XmlAttribute("lang")]
    public string Lang { get; set; } = "en";

    [XmlText]
    public string Value { get; set; } = string.Empty;
}

public record PageRef
{
    [XmlAttribute("path")]
    public string Path { get; set; } = null!;

    [XmlAttribute("directory")]
    public string Directory { get; set; } = string.Empty;
}
