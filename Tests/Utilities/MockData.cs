namespace Tests.Utilities;

public static class MockData
{
  public const string SlnContent = @"Microsoft Visual Studio Solution File, Format Version 12.00
    # Visual Studio Version 17
    VisualStudioVersion = 17.0.31903.59
    MinimumVisualStudioVersion = 10.0.40219.1
    Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""MyApp"", ""src/MyApp/MyApp.csproj"", ""{A1B2C3D4-E5F6-7890-ABCD-EF0123456789}""
    EndProject
    Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""MyLibrary"", ""src/MyLibrary/MyLibrary.csproj"", ""{B2C3D4E5-F6A7-8901-BCDE-F0123456789A}""
    EndProject
    Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""MyService"", ""src/MyService/MyService.csproj"", ""{C3D4E5F6-A7B8-9012-CDEF-0123456789AB}""
    EndProject
    Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""MyTests"", ""tests/MyTests/MyTests.csproj"", ""{D4E5F6A7-B8C9-0123-DEFA-123456789ABC}""
    EndProject
    Global
      GlobalSection(SolutionConfigurationPlatforms) = preSolution
        Debug|Any CPU = Debug|Any CPU
        Release|Any CPU = Release|Any CPU
      EndGlobalSection
      GlobalSection(ProjectConfigurationPlatforms) = postSolution
        {A1B2C3D4-E5F6-7890-ABCD-EF0123456789}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {A1B2C3D4-E5F6-7890-ABCD-EF0123456789}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {A1B2C3D4-E5F6-7890-ABCD-EF0123456789}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {A1B2C3D4-E5F6-7890-ABCD-EF0123456789}.Release|Any CPU.Build.0 = Release|Any CPU
        {B2C3D4E5-F6A7-8901-BCDE-F0123456789A}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {B2C3D4E5-F6A7-8901-BCDE-F0123456789A}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {B2C3D4E5-F6A7-8901-BCDE-F0123456789A}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {B2C3D4E5-F6A7-8901-BCDE-F0123456789A}.Release|Any CPU.Build.0 = Release|Any CPU
        {C3D4E5F6-A7B8-9012-CDEF-0123456789AB}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {C3D4E5F6-A7B8-9012-CDEF-0123456789AB}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {C3D4E5F6-A7B8-9012-CDEF-0123456789AB}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {C3D4E5F6-A7B8-9012-CDEF-0123456789AB}.Release|Any CPU.Build.0 = Release|Any CPU
        {D4E5F6A7-B8C9-0123-DEFA-123456789ABC}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {D4E5F6A7-B8C9-0123-DEFA-123456789ABC}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {D4E5F6A7-B8C9-0123-DEFA-123456789ABC}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {D4E5F6A7-B8C9-0123-DEFA-123456789ABC}.Release|Any CPU.Build.0 = Release|Any CPU
      EndGlobalSection
      GlobalSection(SolutionProperties) = preSolution
        HideSolutionNode = FALSE
      EndGlobalSection
    EndGlobal";

    public const string SlnxContent = @"<Solution>
      <Project Path=""src/MyApp/MyApp.csproj"" />
      <Project Path=""src/MyLibrary/MyLibrary.csproj"" />
      <Project Path=""src/MyService/MyService.csproj"" />
      <Project Path=""tests/MyTests/MyTests.csproj"" />
      </Solution>";

    public static string[] ExpectedPaths = ["src/MyApp", "src/MyLibrary", "src/MyService", "tests/MyTests", "abcd"];
}