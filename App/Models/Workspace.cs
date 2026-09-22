namespace App.Models;

public sealed record Workspace(Folder[] Folders);

public sealed record Folder(string Path);