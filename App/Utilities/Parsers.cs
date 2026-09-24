using System.Text.RegularExpressions;
using App.Models;

namespace App.Utilities;

public static class Parsers
{
  private static readonly Regex ProjectRegex = new(@"^\s*Project\(.*?\)\s*=\s*"".*?"",\s*""(?<path>.*?\.[a-zA-Z]+proj)""", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
  private static readonly Regex ProjectSlnxRegex = new(@"Path\s*=\s*(?:""(?<path>[^""]*?\.[a-zA-Z]+proj)""|'(?<path>[^']*?\.[a-zA-Z]+proj)')", RegexOptions.Compiled | RegexOptions.IgnoreCase);

  public static Workspace GenerateWorkspaceContent(string path)
  {
    var extension = Path.GetExtension(path).TrimStart('.');

    if (extension != Constants.Sln && extension != Constants.Slnx) throw new ArgumentException($"File must be {Constants.Sln} or {Constants.Slnx}");
    
    var content = File.ReadAllText(path);

    var folderPaths = extension switch
    {
      Constants.Sln => ParseSlnProjectPaths(content),
      Constants.Slnx => ParseSlnxProjectPaths(content),
      
      _ => throw new ArgumentException("File type not supported")
    };

    var slnFullPath = Path.GetFullPath(path);
    var slnDir = Path.GetDirectoryName(slnFullPath);

    return new([.. folderPaths.Select(path => new Folder(Path.GetFullPath(path)))], BuildOmnisharpSettings(slnFullPath));
  }

  public static Dictionary<string, string> BuildOmnisharpSettings(string solutionPath)
    => new()
    {
      ["dotnet.defaultSolution"] = solutionPath
    };

  public static string[] ParseSlnProjectPaths(string content)
    => [.. ProjectRegex.Matches(content).Select(match => Path.GetDirectoryName(match.Groups[Constants.Path].Value) ?? throw new ArgumentException("Sln malformed"))];

  public static string[] ParseSlnxProjectPaths(string content)
    => [.. ProjectSlnxRegex.Matches(content).Select(match => Path.GetDirectoryName(match.Groups[Constants.Path].Value) ?? throw new ArgumentNullException("Slnx malformed"))];
}