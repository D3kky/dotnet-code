namespace dotnet_code;
using dotnet_code.Utilities;

public sealed class Engine
{
  public void Run()
  {
    var fullPath = Path.GetFullPath(ArgumentHelpers.Args[Constants.Path] ?? throw new ArgumentException("Solution path not provided"));

    if (!Path.Exists(fullPath)) throw new ArgumentException($"File doesn't exist: {fullPath}");

    
  }
}