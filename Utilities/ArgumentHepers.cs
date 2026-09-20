namespace dotnet_code.Utilities;

using static dotnet_code.Utilities.Constants;

public static class ArgumentHelpers
{
  public static Dictionary<string, string?> Args = ParseArgs();

  private static Dictionary<string, string?> ParseArgs()
  {
    var args = Environment.GetCommandLineArgs();
    var toReturn = new Dictionary<string, string?>();

    for (int i = 1; i < args.Length; i++)
    {
      if (!args[i].StartsWith(ArgNamePrefix)) throw new ArgumentException("Argument name or format invalid, please insert arguments in format [--name value]");

      var argHasValue = i+1 < args.Length && !args[i+1].StartsWith(ArgNamePrefix);

      if (argHasValue)
      {
        toReturn[args[i]] = args[++i];
      }

      toReturn[args[i]] = null;
    }
    
    return toReturn;
  }
}