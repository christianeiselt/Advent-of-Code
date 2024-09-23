using AdventOfCode2023.Day01;

namespace AdventOfCode2023Tests;

public class SnowCalibrationTests
{
    [Fact]
    public void Test_ExtractCalibrationValuePartOne_ValidInput()
    {
        var calibration = new SnowCalibration(1);

        Assert.Equal(12, calibration.ExtractCalibrationValue("1abc2"));        // First: 1, Last: 2
        Assert.Equal(38, calibration.ExtractCalibrationValue("pqr3stu8vwx"));  // First: 3, Last: 8
        Assert.Equal(15, calibration.ExtractCalibrationValue("a1b2c3d4e5f"));  // First: 1, Last: 5
        Assert.Equal(77, calibration.ExtractCalibrationValue("treb7uchet"));    // First: 7, Last: 7
    }
    
    [Fact]
    public void Test_ExtractCalibrationValuePartTwo_ValidInput()
    {
        var calibration = new SnowCalibration(2);

        Assert.Equal(29, calibration.ExtractCalibrationValue("two1nine"));      // First: 2, Last: 9
        Assert.Equal(83, calibration.ExtractCalibrationValue("eightwothree"));  // First: 8, Last: 3
        Assert.Equal(13, calibration.ExtractCalibrationValue("abcone2threexyz")); // First: 1, Last: 2
        Assert.Equal(24, calibration.ExtractCalibrationValue("xtwone3four"));   // First: 2, Last: 4
        Assert.Equal(42, calibration.ExtractCalibrationValue("4nineeightseven2")); // First: 4, Last: 2
        Assert.Equal(14, calibration.ExtractCalibrationValue("zoneight234"));    // First: 2, Last: 4
        Assert.Equal(76, calibration.ExtractCalibrationValue("7pqrstsixteen"));  // First: 7, Last: 6
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
        var lines = new List<string>
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };

        Assert.Equal(142, calibration.CalculateTotalCalibration(lines));
    }

    [Fact]
    public void Test_CalculateTotalCalibrationPartOne_FromExampleFile()
    {
        var calibration = new SnowCalibration(1);
        
        // Use the relative path to the file, which should now be in the output directory
        string testFilePath = "../../../TestInput/Day01ExampleInputA.txt";
        
        // Ensure the file exists for the test
        if (!File.Exists(testFilePath))
        {
            // Get current working directory
            string currentDirectory = Directory.GetCurrentDirectory();
            
            // Throw exception with additional directory information
            throw new FileNotFoundException($"Test file not found: {testFilePath}. Current directory: {currentDirectory}");
        }
        
        // Read lines from the test input file
        List<string> lines = calibration.ReadLinesFromFile(testFilePath);
        
        // Calculate the total calibration value from the input file
        int totalCalibration = calibration.CalculateTotalCalibration(lines);
        
        // Assert the expected value (this assumes you know the correct result for the input in the file)
        Assert.Equal(142, totalCalibration);  // Update this based on actual file content
    }
    
    [Fact]
    public void Test_CalculateTotalCalibrationPartOne_FromInputFile()
    {
        var calibration = new SnowCalibration(1);
        
        // Use the relative path to the file, which should now be in the output directory
        string testFilePath = "../../../../../aoc_input/day01.txt";
        
        // Ensure the file exists for the test
        if (!File.Exists(testFilePath))
        {
            // Get current working directory
            string currentDirectory = Directory.GetCurrentDirectory();
            
            // Throw exception with additional directory information
            throw new FileNotFoundException($"Test file not found: {testFilePath}. Current directory: {currentDirectory}");
        }
        
        // Read lines from the test input file
        List<string> lines = calibration.ReadLinesFromFile(testFilePath);
        
        // Calculate the total calibration value from the input file
        int totalCalibration = calibration.CalculateTotalCalibration(lines);
        
        // Assert the expected value (this assumes you know the correct result for the input in the file)
        Assert.Equal(54_331, totalCalibration);  // Update this based on actual file content
    }

    [Fact]
    public void Test_CalculateTotalCalibrationPartTwo_FromExampleFile()
    {
        var calibration = new SnowCalibration(2);
        
        // Use the relative path to the file, which should now be in the output directory
        string testFilePath = "../../../TestInput/Day01ExampleInputB.txt";
        
        // Ensure the file exists for the test
        if (!File.Exists(testFilePath))
        {
            // Get current working directory
            string currentDirectory = Directory.GetCurrentDirectory();
            
            // Throw exception with additional directory information
            throw new FileNotFoundException($"Test file not found: {testFilePath}. Current directory: {currentDirectory}");
        }
        
        // Read lines from the test input file
        List<string> lines = calibration.ReadLinesFromFile(testFilePath);
        
        // Calculate the total calibration value from the input file
        int totalCalibration = calibration.CalculateTotalCalibration(lines);
        
        // Assert the expected value (this assumes you know the correct result for the input in the file)
        Assert.Equal(281, totalCalibration);  // Update this based on actual file content
    }
    
    [Fact]
    public void Test_CalculateTotalCalibrationPartTwo_FromInputFile()
    {
        var calibration = new SnowCalibration(2);
        
        // Use the relative path to the file, which should now be in the output directory
        string testFilePath = "../../../../../aoc_input/day01.txt";
        
        // Ensure the file exists for the test
        if (!File.Exists(testFilePath))
        {
            // Get current working directory
            string currentDirectory = Directory.GetCurrentDirectory();
            
            // Throw exception with additional directory information
            throw new FileNotFoundException($"Test file not found: {testFilePath}. Current directory: {currentDirectory}");
        }
        
        // Read lines from the test input file
        var lines = calibration.ReadLinesFromFile(testFilePath);
        
        // Calculate the total calibration value from the input file
        var totalCalibration = calibration.CalculateTotalCalibration(lines);
        
        // Assert the expected value (this assumes you know the correct result for the input in the file)
        Assert.Equal(54_518, totalCalibration);  // Update this based on actual file content
    }
}