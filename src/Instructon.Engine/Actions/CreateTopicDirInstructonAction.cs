using Instructon.Engine.Base;
using Instructon.Engine.Xml.Elements.Site;

namespace Instructon.Engine.Actions;

public class CreateTopicDirInstructonAction(Topic topic)
    : AbstractInstructonAction("CreateContentDir", $"Creates content directory {topic.Directory}")
{
    protected override bool PerformAction(Instructon instructon)
    {
        var contentDir = instructon.GetContentDirectory();
        var fullPath = Path.Combine(contentDir, topic.Directory);

        if (Directory.Exists(fullPath))
        {
            Console.WriteLine($"Topic directory '{fullPath}' already exists.");
            return false;
        }
        try
        {
            Directory.CreateDirectory(fullPath);
            Console.WriteLine($"Topic directory '{fullPath}' created successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to create topic directory '{fullPath}': {ex.Message}");
            return false;
        }
    }

}
