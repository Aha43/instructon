using System;
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

    public string GetSiteJson() => _siteConfig.ToPrettyString();

    public string GetContentDirectory() => _siteConfig.ContentDirectory;

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

        return [.. retVal, .. FindActionsForCreatingTopicDir()];
    }

    private List<IInstructonAction> FindActionsForCreatingTopicDir()
    {
        var actions = new List<IInstructonAction>();
        foreach (var topic in _siteConfig.Topics)
        {
            if (TopicDirExists(topic.Path))
            {
                continue; // Skip if the topic directory already exists
            }
            
            actions.Add(new CreateTopicDirInstructonAction(topic.Path));
        }
        return actions;
    }

    private bool TopicDirExists(string topicPath)
    {
        var fullPath = Path.Combine(_siteConfig.ContentDirectory, topicPath);
        return Directory.Exists(fullPath);
    }

}
