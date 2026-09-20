namespace dotnet_code.Models;

public sealed record Workspace(Folder[] Folders);

public sealed record Folder(string Path);