namespace AoCShared.Tests;

public class FileHelperTests
{
    private const int TestYear = 2024;
    private const int TestDay = 1;
    private const int TestPart = 1;
    private const string TestBaseDir = "../../../../../../../_puzzle_inputs_answers";

    public FileHelperTests()
    {
        // Ensure the base directory exists for testing
        Directory.CreateDirectory(Path.Combine(TestBaseDir, TestYear.ToString()));
    }

    [Fact]
    public void GetInputFile_ValidCase_ReturnsFilePath()
    {
        // Arrange
        var inputFile = Path.Combine(TestBaseDir, TestYear.ToString(), $"day{TestDay:D2}_input.txt");
        File.WriteAllText(inputFile, "Test Input");

        // Act
        var result = FileHelper.GetInputFile(TestYear, TestDay);

        // Assert
        Assert.Equal(inputFile, result);

        // Cleanup
        File.Delete(inputFile);
    }

    [Fact]
    public void GetInputFile_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => FileHelper.GetInputFile(TestYear, TestDay));
    }

    [Fact]
    public void GetExampleFile_ValidCase_ReturnsFilePath()
    {
        // Arrange
        var suffix = "exampleSuffix";
        var exampleFile = Path.Combine(TestBaseDir, TestYear.ToString(),
            $"day{TestDay:D2}_part{TestPart}_example_{suffix}_input.txt");
        File.WriteAllText(exampleFile, "Test Example");

        // Act
        var result = FileHelper.GetExampleFile(TestYear, TestDay, TestPart, suffix);

        // Assert
        Assert.Equal(exampleFile, result);

        // Cleanup
        File.Delete(exampleFile);
    }

    [Fact]
    public void GetExampleFile_MissingSuffix_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => FileHelper.GetExampleFile(TestYear, TestDay, TestPart, null));
    }

    [Fact]
    public void GetAnswerFile_ValidCase_ReturnsFileContent()
    {
        // Arrange
        var answerFile = Path.Combine(TestBaseDir, TestYear.ToString(),
            $"day{TestDay:D2}_part{TestPart}_answer.txt");
        var answerContent = "42";
        File.WriteAllText(answerFile, answerContent);

        // Act
        var result = FileHelper.GetAnswer(TestYear, TestDay, TestPart);

        // Assert
        Assert.Equal(answerContent, result);

        // Cleanup
        File.Delete(answerFile);
    }

    [Fact]
    public void GetAnswerFile_WithSuffix_ReturnsFileContent()
    {
        // Arrange
        var suffix = "exampleSuffix";
        var answerFile = Path.Combine(TestBaseDir, TestYear.ToString(),
            $"day{TestDay:D2}_part{TestPart}_example_{suffix}_answer.txt");
        var answerContent = "84";
        File.WriteAllText(answerFile, answerContent);

        // Act
        var result = FileHelper.GetAnswer(TestYear, TestDay, TestPart, suffix);

        // Assert
        Assert.Equal(answerContent, result);

        // Cleanup
        File.Delete(answerFile);
    }

    [Fact]
    public void GetAnswerFile_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => FileHelper.GetAnswer(TestYear, TestDay, TestPart));
    }

    [Fact]
    public void GetFile_InvalidFileType_ThrowsFileNotFoundException()
    {
        // Act & Assert
        Assert.Throws<FileNotFoundException>(() =>
            FileHelper.GetExampleFile(TestYear, TestDay, TestPart, "invalidSuffix"));
    }
}