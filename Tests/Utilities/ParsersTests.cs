using static App.Utilities.Parsers;
namespace Tests.Utilities;

public class ParsersTests
{
  [Fact]
  public void ParseSlnProjectPaths_ValidContent_ReturnsFolderPaths()
  {
    var sut = ParseSlnProjectPaths(MockData.SlnContent);

    Assert.Equal(MockData.ExpectedPaths, sut);
  }

  [Fact]
  public void ParseSlnxProjectPaaths_ValidContent_ReturnsFolderPaths()
  {
    var sut = ParseSlnxProjectPaths(MockData.SlnxContent);

    Assert.Equal(MockData.ExpectedPaths, sut);
  }
}