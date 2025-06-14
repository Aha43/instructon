using System.Xml.Serialization;

namespace Instructon.Engine.Xml.Elements.Page;

[XmlRoot("page")]
public class PageDocument
{
    [XmlElement("todo")]
    public List<string> Todos { get; set; } = [];

    [XmlElement("title")]
    public LocalizedBlock? Title { get; set; }

    [XmlElement("par", typeof(Paragraph))]
    [XmlElement("img", typeof(Img))]
    [XmlElement("movie", typeof(Movie))]
    public List<PageContent> Content { get; set; } = [];
}

public abstract class PageContent { }

public class Paragraph : PageContent
{
    [XmlElement("todo")]
    public List<string> Todos { get; set; } = [];

    [XmlElement("text")]
    public List<LocalizedText> Texts { get; set; } = [];
}

public class Caption
{
    [XmlElement("todo")]
    public List<string> Todos { get; set; } = [];

    [XmlElement("caption")]
    public List<LocalizedText> Captions { get; set; } = [];

    [XmlElement("text")]
    public List<LocalizedText> Texts { get; set; } = [];
}

public class AltText
{
    [XmlElement("todo")]
    public List<string> Todos { get; set; } = [];

    [XmlElement("alt")]
    public List<LocalizedText> Alts { get; set; } = [];
}

public class Img : PageContent
{
    [XmlElement("todo")]
    public List<string> Todos { get; set; } = [];

    [XmlElement("file")]
    public string? File { get; set; }

    [XmlElement("alt")]
    public AltText? Alt { get; set; }

    [XmlElement("caption")]
    public Caption? Caption { get; set; }
}

public class Movie : PageContent 
{
    [XmlElement("todo")]
    public List<string> Todos { get; set; } = [];

    [XmlElement("file")]
    public string? File { get; set; }

    [XmlElement("alt")]
    public AltText? Alt { get; set; }

    [XmlElement("caption")]
    public Caption? Caption { get; set; }
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
