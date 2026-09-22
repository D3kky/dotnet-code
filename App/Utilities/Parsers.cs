using System.Text.RegularExpressions;
using App.Models;

namespace App.Utilities;

public static class Parsers
{
  private static readonly Regex ProjectRegex = new(@"^Project\(.*?\)\s*=\s*"".*?"",\s*""(?<path>.*?\.[a-z]+proj)""",RegexOptions.Compiled);
  private static readonly Regex ProjectSlnxRegex = new(@"Project\s+Path=""(?<path>.*?\.[a-z]+proj)""", RegexOptions.Compiled);
  public static Workspace GenerateWorkspaceContent(string path)
  {
    var extension = Path.GetExtension(path);

    if (extension != Constants.Sln || extension != Constants.Slnx) throw new ArgumentException($"File must be {Constants.Sln} or {Constants.Slnx}");
    
    var content = File.ReadAllText(path);

    var paths = extension switch
    {
      Constants.Sln => ParseSlnProjectPaths(content),
      Constants.Slnx => ParseSlnxProjectPaths(content),
      
      _ => throw new ArgumentException("File type not supported")
    };

    return new([.. paths.Select(path => new Folder(path))]);
  }

  public static string[] ParseSlnProjectPaths(string content)
    => [.. ProjectRegex.Matches(content).Select(match => match.Groups[Constants.Path].Value)];

  public static string[] ParseSlnxProjectPaths(string content)
    => [.. ProjectSlnxRegex.Matches(content).Select(match => match.Groups[Constants.Path].Value)];
}