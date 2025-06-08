using System;
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

}
