using Instructon.Engine.Interfaces;

namespace Instructon.Engine.Base;

public abstract class AbstractInstructonAction(string name, string description) : IInstructonAction
{
    public string Description { get; } = description;
    public string Name { get; } = name;

    public bool Execute(Instructon instructon)
    {
        if (instructon.DryActionRun)
        {
            Console.WriteLine($"Dry run: {Name} - {Description}");
            return true; // In dry run, we assume success
        }

        try
        {
            var retVal = PerformAction(instructon);
            Console.WriteLine($"Executed: {Name} - {Description}");
            return retVal;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing {Name}: {ex.Message}");
            return false;
        }
    }

    protected abstract bool PerformAction(Instructon instructon);
}
