using System.Diagnostics;
using System.Text.Json;

namespace App.Utilities;

public static class Constants
{
  public const string Sln = "sln";
  public const string Slnx = "slnx";
  public const string ArgNamePrefix = "--";
  public const string Path = "path";

  // TESTUNG
  public const string DotnetCode = nameof(DotnetCode);
  public const string Workspaces = nameof(Workspaces);
  public const string WorkspaceExtension = ".code-workspace";

  public const string VsCodeCommandName = "code";
}