using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day01;

public partial class SnowCalibration(int part)
{
    private static readonly Dictionary<string, string> SpelledOutDigits = new()
    {
        ["zero"] = "0",
        ["one"] = "1",
        ["two"] = "2",
        ["three"] = "3",
        ["four"] = "4",
        ["five"] = "5",
        ["six"] = "6",
        ["seven"] = "7",
        ["eight"] = "8",
        ["nine"] = "9"
    };

    public int ExtractCalibrationValue(string line)
    {
        var (firstDigit, lastDigit) = (FindFirstDigit(line), FindLastDigit(line));
        return string.IsNullOrEmpty(firstDigit) || string.IsNullOrEmpty(lastDigit)
            ? 0
            : int.Parse($"{firstDigit}{lastDigit}");
    }

    private string FindFirstDigit(string line)
    {
        return part switch
        {
            1 => MyRegex().Match(line).Value,  // Find the first numeric digit for part 1
            _ => FindDigitWithLowestIndex(line)
        };
    }

    private string FindLastDigit(string line)
    {
        return part switch
        {
            1 => MyRegex().Match(new string(line.Reverse().ToArray())).Value,  // Find the last numeric digit for part 1
            _ => FindDigitWithHighestIndex(line)
        };
    }

    private string FindDigitWithLowestIndex(string line)
    {
        var lowestIndex = int.MaxValue;
        string firstDigit = string.Empty;

        // Check numeric digits and update the lowest index
        foreach (Match match in MyRegex().Matches(line))
        {
            if (match.Index < lowestIndex)
            {
                lowestIndex = match.Index;
                firstDigit = match.Value;
            }
        }

        // Check spelled-out digits and update the lowest index
        foreach (var (word, digit) in SpelledOutDigits)
        {
            var index = line.IndexOf(word, StringComparison.Ordinal);
            if (index >= 0 && index < lowestIndex)
            {
                lowestIndex = index;
                firstDigit = digit;
            }
        }

        return firstDigit;
    }

    private string FindDigitWithHighestIndex(string line)
    {
        var (highestIndex, lastDigit) = (-1, string.Empty);

        // Check numeric digits and update the highest index
        foreach (Match match in MyRegex().Matches(line))
        {
            (highestIndex, lastDigit) = (match.Index > highestIndex ? match.Index : highestIndex, match.Value);
        }

        // Check spelled-out digits and update the highest index
        foreach (var (word, digit) in SpelledOutDigits)
        {
            var index = line.LastIndexOf(word, StringComparison.Ordinal);
            if (index >= 0 && index > highestIndex)
            {
                (highestIndex, lastDigit) = (index, digit);
            }
        }

        return lastDigit;
    }

    public int CalculateTotalCalibration(List<string> lines)
        => lines.Sum(ExtractCalibrationValue);

    public List<string> ReadLinesFromFile(string filePath)
        => File.Exists(filePath)
            ? File.ReadAllLines(filePath).ToList()
            : throw new FileNotFoundException($"File not found: {filePath}");

    [GeneratedRegex(@"\d")]
    private static partial Regex MyRegex();
}
