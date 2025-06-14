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

        var retVal = new PageDocument
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
            }
        };

        retVal.Content = [
            new Paragraph
            {
                Todos = ["Write introduction paragraph"],
                Texts = localizedTexts
            },
            new Img
            {
                Todos = ["Add image file", "Write alt/caption"],
                File = "images/placeholder.jpg",
                Alt = new AltText
                {
                    Todos = ["Write alt text"],
                    Alts = localizedTexts
                },
                Caption = new Caption
                {
                    Todos = ["Write caption"],
                    Captions = captions
                }
            },
            new Movie
            {
                Todos = ["Add video file", "Write alt/caption"],
                File = "videos/placeholder.mp4",
                Alt = new AltText
                {
                    Todos = ["Write alt text"],
                    Alts = localizedTexts
                },
                Caption = new Caption
                {
                    Todos = ["Write caption"],
                    Captions = captions
                }
            }
        ];

        return retVal;
    }

    
}
