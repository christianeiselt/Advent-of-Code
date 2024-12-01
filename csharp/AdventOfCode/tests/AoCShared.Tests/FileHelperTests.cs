// <copyright file="FileHelperTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AoCShared.Tests;

public class FileHelperTests
{
    private const int TestYear = 2018;
    private const int TestDay = 1;
    private const Part TestPart = Part.One;
    private const string TestBaseDir = "../../../../../../../_puzzle_inputs_answers";

    [Fact]
    public void GetInputFile_ValidCase_ReturnsFilePath()
    {
        // Arrange
        var inputFile = Path.Combine(TestBaseDir, TestYear.ToString(), $"day{TestDay:D2}_input.txt");

        // Act
        var result = FileHelper.GetInputFile(TestYear, TestDay);

        // Assert
        Assert.Equal(inputFile, result);
    }

    [Fact]
    public void GetInputFile_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => FileHelper.GetInputFile(2099, 99));
    }

    [Fact]
    public void GetExampleFile_ValidCase_ReturnsFilePath()
    {
        // Arrange
        const string? suffix = "a";
        var exampleFile = Path.Combine(
            TestBaseDir,
            TestYear.ToString(),
            $"day{TestDay:D2}_part{(int)TestPart}_example_{suffix}_input.txt");

        // Act
        var result = FileHelper.GetExampleFile(TestYear, TestDay, TestPart, suffix);

        // Assert
        Assert.Equal(exampleFile, result);
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
        const string answerContent = "490";

        // Act
        var result = FileHelper.GetAnswer(TestYear, TestDay, TestPart);

        // Assert
        Assert.Equal(answerContent, result);
    }

    [Fact]
    public void GetAnswerFile_WithSuffix_ReturnsFileContent()
    {
        // Arrange
        const string suffix = "a";
        const string answerContent = "3";

        // Act
        var result = FileHelper.GetAnswer(TestYear, TestDay, TestPart, suffix);

        // Assert
        Assert.Equal(answerContent, result);
    }

    [Fact]
    public void GetAnswerFile_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => FileHelper.GetAnswer(2099, 99, TestPart));
    }

    [Fact]
    public void GetFile_InvalidFileType_ThrowsFileNotFoundException()
    {
        // Act & Assert
        Assert.Throws<FileNotFoundException>(
            () =>
                FileHelper.GetExampleFile(TestYear, TestDay, TestPart, "invalidSuffix"));
    }
}