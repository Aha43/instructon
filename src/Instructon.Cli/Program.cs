// See https://aka.ms/new-console-template for more information
using Instructon.Engine.Xml.Elements.Site;

Console.WriteLine("Hello, World!");

var siteFile = "./site.xml";
if (!File.Exists(siteFile))
{
    Console.WriteLine($"Site configuration file not found: {siteFile}");
    return;
}

var instructon = Instructon.Engine.Instructon.CreateFromFile(siteFile);

System.Console.WriteLine(instructon.GetSiteJson());   

instructon.DryActionRun = false; // Set to false to actually perform actions
instructon.ExecuteAllActions();
