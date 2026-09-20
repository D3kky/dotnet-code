using System.Text.RegularExpressions;
using dotnet_code.Models;

namespace dotnet_code.Utilities;

public static class Parsers
{
  private static readonly Regex ProjectRegex = new(@"^Project\(.*?\)\s*=\s*"".*?"",\s*""(?<path>.*?\.[a-z]+proj)""",RegexOptions.Compiled);
  public static Workspace GenerateWorkspaceContent(string path)
  {
    var extension = Path.GetExtension(path);

    if (extension != Constants.Sln || extension != Constants.Slnx) throw new ArgumentException($"File must be {Constants.Sln} or {Constants.Slnx}");
    
    var paths = extension switch
    {
      Constants.Sln => ParseSlnProjectPaths(File.ReadAllText(path)),
      
      _ => throw new ArgumentException("File type not supported")
    };

    return new([new("test")]);
  }

  public static string[] ParseSlnProjectPaths(string content)
    => [.. ProjectRegex.Matches(content).Select(match => match.Groups[Constants.Path].Value)];
}