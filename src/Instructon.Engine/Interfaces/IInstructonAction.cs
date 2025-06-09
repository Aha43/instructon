namespace Instructon.Engine.Interfaces;

public interface IInstructonAction
{
    bool Execute(Instructon instructon);
    string Description { get; }
    string Name { get; }
}
