using Instructon.Engine.Base;

namespace Instructon.Engine.Actions;

public class CreateTopicDirInstructonAction(string topicDirectory) : AbstractInstructonAction("CreateContentDir", $"Creates content directory {topicDirectory}")
{
    protected override bool PerformAction(Instructon instructon)
    {
        var contentDir = instructon.GetContentDirectory();
        var fullPath = Path.Combine(contentDir, topicDirectory);

        Console.WriteLine($"topicDirectory = {topicDirectory}");
        Console.WriteLine($"contentDir = {contentDir}");
        Console.WriteLine($"fullPath = {fullPath}");

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
