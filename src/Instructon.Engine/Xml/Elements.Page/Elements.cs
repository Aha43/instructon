using System.Xml.Serialization;

namespace Instructon.Engine.Xml.Elements.Page;

[XmlRoot("page")]
public class PageDocument
{
    [XmlElement("todo")]
    public List<string> Todos { get; set; } = [];

    [XmlElement("title")]
    public LocalizedBlock? Title { get; set; }

    [XmlElement("par")]
    public Paragraph? Paragraph { get; set; }

    [XmlElement("image")]
    public MediaBlock? Image { get; set; }

    [XmlElement("video")]
    public MediaBlock? Video { get; set; }
}

public class Paragraph
{
    [XmlElement("todo")]
    public List<string> Todos { get; set; } = [];

    [XmlElement("text")]
    public List<LocalizedText> Texts { get; set; } = [];
}

public class MediaBlock
{
    [XmlElement("todo")]
    public List<string> Todos { get; set; } = [];

    [XmlElement("file")]
    public FileRef? File { get; set; }

    [XmlElement("video")]
    public FileRef? Video { get; set; }

    [XmlElement("alt")]
    public List<LocalizedText> Alts { get; set; } = [];

    [XmlElement("caption")]
    public List<LocalizedText> Captions { get; set; } = [];
}

public class FileRef
{
    [XmlAttribute("src")]
    public string Src { get; set; } = null!;
}

public class LocalizedBlock
{
    [XmlElement("text")]
    public List<LocalizedText> Texts { get; set; } = [];
}

public class LocalizedText
{
    [XmlAttribute("lang")]
    public string Lang { get; set; } = null!;

    [XmlElement("todo")]
    public List<string> Todos { get; set; } = [];

    [XmlText]
    public string Value { get; set; } = null!;
}
