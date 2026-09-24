using System.Text.Json;
using System.Text.Json.Serialization;

namespace App.Models;

public sealed record Workspace(Folder[] Folders, Dictionary<string, string> Settings);

public sealed record Folder(string Path);

[JsonSourceGenerationOptions(WriteIndented = true, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Workspace))]
[JsonSerializable(typeof(JsonElement))]
internal partial class SourceGeneratorContext : JsonSerializerContext { }