using Instructon.Engine.Actions;
using Instructon.Engine.Interfaces;
using Instructon.Engine.Xml;
using Instructon.Engine.Xml.Elements.Site;

namespace Instructon.Engine;

public class Instructon
{
    private readonly SiteConfig _siteConfig;

    private Instructon(SiteConfig siteConfig)
    {
        _siteConfig = siteConfig;
    }

    public static Instructon CreateFromFile(string filePath)
    {
        var siteConfig = Parser.ParseSiteConfigFromFile(filePath);
        var retVal = new Instructon(siteConfig);
        retVal.EnsureTopDirExists();
        return retVal;
    }

    private void EnsureTopDirExists()
    {
        if (!Directory.Exists(_siteConfig.ContentDirectory))
        {
            Directory.CreateDirectory(_siteConfig.ContentDirectory);
        }
        if (!Directory.Exists(_siteConfig.OutputDirectory))
        {
            Directory.CreateDirectory(_siteConfig.OutputDirectory);
        }
        if (!string.IsNullOrEmpty(_siteConfig.ImageDirectory) && !Directory.Exists(_siteConfig.ImageDirectory))
        {
            Directory.CreateDirectory(_siteConfig.ImageDirectory);
        }
        if (!string.IsNullOrEmpty(_siteConfig.VideoDirectory) && !Directory.Exists(_siteConfig.VideoDirectory))
        {
            Directory.CreateDirectory(_siteConfig.VideoDirectory);
        }
    }

    public string GetSiteJson() => _siteConfig.ToJsonString();

    public string GetContentDirectory() => _siteConfig.ContentDirectory;

    public List<string> GetLanguages() => _siteConfig.Languages;

    public bool DryActionRun { get; set; } = true;

    public void ExecuteAllActions()
    {
        var actions = FindAllActionsFor();
        foreach (var action in actions)
        {
            action.Execute(this);
        }
    }

    private List<IInstructonAction> FindAllActionsFor()
    {
        var retVal = new List<IInstructonAction>();

        return [.. retVal, .. FindActionsForCreatingTopicDir() 
            , .. FindActionsForCreatingPageFiles()];
    }

    private List<IInstructonAction> FindActionsForCreatingTopicDir()
    {
        var actions = new List<IInstructonAction>();
        foreach (var topic in _siteConfig.Topics)
        {
            if (TopicExists(topic)) continue;
            actions.Add(new CreateTopicDirInstructonAction(topic));
        }
        return actions;
    }

    private List<IInstructonAction> FindActionsForCreatingPageFiles()
    {
        var actions = new List<IInstructonAction>();
        foreach (var topic in _siteConfig.Topics)
        {
            foreach (var page in topic.Pages)
            {
                if (PageFileExists(page)) continue;
                actions.Add(new CreatePageFileInstructonAction(page));
            }
        }
        return actions;
    }

    private bool PageFileExists(Page page)
    {
        if (!TopicExists(page.Topic!)) return false;

        var fullPath = Path.Combine(GetFullPath(page.Topic!), page.Filename);
        return File.Exists(fullPath);
    }

    private bool TopicExists(Topic topic) => Directory.Exists(GetFullPath(topic));

    private string GetFullPath(Topic topic) => Path.Combine(GetContentDirectory(), topic.Directory);

}
