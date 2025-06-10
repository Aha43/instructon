using Instructon.Engine.Base;
using Instructon.Engine.Xml;
using Instructon.Engine.Xml.Elements.Site;

namespace Instructon.Engine.Actions;

public class CreatePageFileInstructonAction(Page page) : AbstractInstructonAction("Create Page",
    $"Creates page file for {page.Filename}")
{
    protected override bool PerformAction(Instructon instructon)
    {
        var contentDir = instructon.GetContentDirectory();
        var topicDir = Path.Combine(contentDir, page.Topic!.Directory);
        var fullPath = Path.Combine(topicDir, page.Filename);

        var initialPage = PageScaffoldFactory.CreateScaffold(instructon.GetLanguages());
        var xmlContent = initialPage.ToXmlString();

        File.WriteAllText(fullPath, xmlContent);

        return true;
    }
    
}
