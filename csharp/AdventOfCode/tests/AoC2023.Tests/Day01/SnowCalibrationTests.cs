using AoC2023.Day01;
using AoCShared;

namespace AoC2023.Tests.Day01;

public class SnowCalibrationTests
{
    private static string GetAnswer(int year, int day, int part, string? suffix = null)
    {
        return FileHelper.GetAnswer(year, day, part, suffix);
    }

    [Fact]
    public void Test_ExtractCalibrationValuePartOne_ValidInput()
    {
        var calibration = new SnowCalibration(1);

        Assert.Equal(12, calibration.ExtractCalibrationValue("1abc2")); // First: 1, Last: 2
        Assert.Equal(38, calibration.ExtractCalibrationValue("pqr3stu8vwx")); // First: 3, Last: 8
        Assert.Equal(15, calibration.ExtractCalibrationValue("a1b2c3d4e5f")); // First: 1, Last: 5
        Assert.Equal(77, calibration.ExtractCalibrationValue("treb7uchet")); // First: 7, Last: 7
    }

    [Fact]
    public void Test_ExtractCalibrationValuePartTwo_ValidInput()
    {
        var calibration = new SnowCalibration(2);

        Assert.Equal(29, calibration.ExtractCalibrationValue("two1nine")); // First: 2, Last: 9
        Assert.Equal(83, calibration.ExtractCalibrationValue("eightwothree")); // First: 8, Last: 3
        Assert.Equal(13, calibration.ExtractCalibrationValue("abcone2threexyz")); // First: 1, Last: 2
        Assert.Equal(24, calibration.ExtractCalibrationValue("xtwone3four")); // First: 2, Last: 4
        Assert.Equal(42, calibration.ExtractCalibrationValue("4nineeightseven2")); // First: 4, Last: 2
        Assert.Equal(14, calibration.ExtractCalibrationValue("zoneight234")); // First: 2, Last: 4
        Assert.Equal(76, calibration.ExtractCalibrationValue("7pqrstsixteen")); // First: 7, Last: 6
    }

    [Fact]
    public void Test_ExtractCalibrationValue_EmptyOrNoDigits()
    {
        var calibration = new SnowCalibration(1);

        Assert.Equal(0, calibration.ExtractCalibrationValue(""));
        Assert.Equal(0, calibration.ExtractCalibrationValue("abcdef"));
    }

    [Fact]
    public void Test_CalculateTotalCalibration()
    {
        var calibration = new SnowCalibration(1);
        var lines = new List<string> { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };

        Assert.Equal(142, calibration.CalculateTotalCalibration(lines));
    }

    [Fact]
    public void Test_CalculateTotalCalibrationPartOne_FromExampleFile()
    {
        var calibration = new SnowCalibration(1);
        var ExampleFilePath = FileHelper.GetExampleFile(2023, 1, 1, "a");
        if (!File.Exists(ExampleFilePath))
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            throw new FileNotFoundException(
                $"Test file not found: {ExampleFilePath}. Current directory: {currentDirectory}"
            );
        }

        var lines = SnowCalibration.ReadLinesFromFile(ExampleFilePath);

        var totalCalibration = calibration.CalculateTotalCalibration(lines);
        var expectedAnswer = GetAnswer(2023, 1, 1, "a"); // Get the answer for Part 1 Example A

        Assert.Equal(int.Parse(expectedAnswer), totalCalibration);
    }

    [Fact]
    public void Test_CalculateTotalCalibrationPartOne_FromInputFile()
    {
        var calibration = new SnowCalibration(1);
        var InputFilePath = FileHelper.GetInputFile(2023, 1);
        if (!File.Exists(InputFilePath))
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            throw new FileNotFoundException(
                $"Test file not found: {InputFilePath}. Current directory: {currentDirectory}"
            );
        }

        var lines = SnowCalibration.ReadLinesFromFile(InputFilePath);

        var totalCalibration = calibration.CalculateTotalCalibration(lines);
        var expectedAnswer = GetAnswer(2023, 1, 1); // Get the answer for Part 1 from input file

        Assert.Equal(int.Parse(expectedAnswer), totalCalibration);
    }

    [Fact]
    public void Test_CalculateTotalCalibrationPartTwo_FromExampleFile()
    {
        var calibration = new SnowCalibration(2);
        var ExampleFilePath = FileHelper.GetExampleFile(2023, 1, 2, "a");
        if (!File.Exists(ExampleFilePath))
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            throw new FileNotFoundException(
                $"Test file not found: {ExampleFilePath}. Current directory: {currentDirectory}"
            );
        }

        var lines = SnowCalibration.ReadLinesFromFile(ExampleFilePath);

        var totalCalibration = calibration.CalculateTotalCalibration(lines);
        var expectedAnswer = GetAnswer(2023, 1, 2, "a"); // Get the answer for Part 2 Example A

        Assert.Equal(int.Parse(expectedAnswer), totalCalibration);
    }

    [Fact]
    public void Test_CalculateTotalCalibrationPartTwo_FromInputFile()
    {
        var calibration = new SnowCalibration(2);
        var InputFilePath = FileHelper.GetInputFile(2023, 1);

        if (!File.Exists(InputFilePath))
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            throw new FileNotFoundException(
                $"Test file not found: {InputFilePath}. Current directory: {currentDirectory}"
            );
        }

        var lines = SnowCalibration.ReadLinesFromFile(InputFilePath);

        var totalCalibration = calibration.CalculateTotalCalibration(lines);
        var expectedAnswer = GetAnswer(2023, 1, 2); // Get the answer for Part 2 from input file

        Assert.Equal(int.Parse(expectedAnswer), totalCalibration);
    }
}