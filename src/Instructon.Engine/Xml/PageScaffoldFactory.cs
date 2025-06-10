using Instructon.Engine.Xml.Elements.Page;

namespace Instructon.Engine.Xml;

public static class PageScaffoldFactory
{
    public static PageDocument CreateScaffold(List<string> languages)
    {
        var localizedTexts = languages.Select(lang => new LocalizedText
        {
            Lang = lang,
            Value = $"TODO: Write content in {lang}",
            Todos = [$"Write proper text in {lang}"]
        }).ToList();

        var captions = languages.Select(lang => new LocalizedText
        {
            Lang = lang,
            Value = $"TODO: Add caption in {lang}"
        }).ToList();

        return new PageDocument
        {
            Todos = ["Scaffolded page. Complete required fields."],
            Title = new LocalizedBlock
            {
                Texts = [.. languages.Select(lang => new LocalizedText
                {
                    Lang = lang,
                    Value = "Untitled Page",
                    Todos = ["Set title"]
                })]
            },
            Paragraph = new Paragraph
            {
                Todos = ["Write introduction paragraph"],
                Texts = localizedTexts
            },
            Image = new MediaBlock
            {
                Todos = ["Add image file", "Write alt/caption"],
                File = new FileRef { Src = "images/placeholder.jpg" },
                Alts = localizedTexts,
                Captions = captions
            },
            Video = new MediaBlock
            {
                Todos = ["Add video file", "Write alt/caption"],
                Video = new FileRef { Src = "videos/placeholder.mp4" },
                Alts = localizedTexts,
                Captions = captions
            }
        };
    }

    
}
