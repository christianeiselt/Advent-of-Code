namespace AoCShared.Tests;

public class InputHelperTests
{
    [Fact]
    public void GetInput_ThrowsFileNotFoundException_WhenFileDoesNotExist()
    {
        // Arrange
        const int year = 2099;
        const int day = 99;

        // Act & Assert
        var ex = Assert.Throws<FileNotFoundException>(() => InputHelper.GetInput(year, day));
        Assert.Contains("Input file for 2099 day 99 not found.", ex.Message);
    }

    [Fact]
    public void GetInput_ReturnsCorrectContent_WhenFileExists()
    {
        // Arrange
        const int year = 2023;
        const int day = 1;

        // Act
        var result = InputHelper.GetInput(year, day);

        // Assert
        const string actualFilePath = "../../../../../../../_inputs/2023/day01.txt";
        Assert.Equal(Path.GetFullPath(actualFilePath), result);
    }
    
    [Fact]
    public void GetInput_ThrowsArgumentException_WhenSuffixIsMissing()
    {
        // Arrange
        const string? suffix = null!;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => InputHelper.GetExample(2023,1,suffix));
        Assert.Contains("Suffix cannot be null or whitespace.", ex.Message);
    }

    [Fact]
    public void GetInput_ThrowsFileNotFoundException_WhenSuffixExistsButFileDoesNotExist()
    {
        // Arrange
        const string suffix = "ExB";
        
        // Act & Assert
        var ex = Assert.Throws<FileNotFoundException>(() => InputHelper.GetExample(2099, 99, suffix));
        Assert.Contains("ExB file for 2099 day 99 not found.", ex.Message);
    }

    [Fact]
    public void GetInput_ReturnsCorrectContent_WhenSuffixExists()
    {
        // Arrange
        const string? suffix = "ExA";

        // Act
        var result = InputHelper.GetExample(2023, 1, suffix);

        // Assert
        const string actualFilePath = "../../../../../../../_inputs/2023/day01ExA.txt";
        Assert.Equal(Path.GetFullPath(actualFilePath), result);
    }
}