namespace App;

using System.Diagnostics;
using System.Text.Json;
using App.Models;
using App.Utilities;

public sealed class Engine
{
  public void Run()
  {
    var path = ArgumentHelpers.Args[Constants.Path] ?? throw new ArgumentNullException($"Solution path must be provided");

    if (!Path.Exists(path)) throw new ArgumentException($"File doesn't exist: {path}");

    var name = Path.GetFileNameWithoutExtension(path);
    var workspace = Parsers.GenerateWorkspaceContent(path);

    if (!Directory.Exists(WorkspaceDirectoryPath)) Directory.CreateDirectory(WorkspaceDirectoryPath);

    var fullWorkspaceName = BuildWorkspaceSavePath(name);
    File.WriteAllText(fullWorkspaceName, JsonSerializer.Serialize(workspace, SourceGeneratorContext.Default.Workspace));

    OpenVsCodeWorkspace(fullWorkspaceName);
  }

  private static readonly string WorkspaceDirectoryPath = Path.Join(
    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.DotnetCode, Constants.Workspaces);
  private static string BuildWorkspaceSavePath(string slnName)
    => Path.Join(WorkspaceDirectoryPath, $"{slnName}{Constants.WorkspaceExtension}");

  private static void OpenVsCodeWorkspace(string workspacePath)
  {
    var startInfo = new ProcessStartInfo
    {
      FileName = Constants.VsCodeCommandName,
      Arguments = workspacePath
    };

    _ = Process.Start(startInfo);
  } 
}