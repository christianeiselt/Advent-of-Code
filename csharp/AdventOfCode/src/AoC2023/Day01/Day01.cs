// <copyright file="Day01.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AoC2023.Day01;

using AoCShared;

using System.Text.RegularExpressions;

public class Day01(Part part)
{
    private static readonly Regex MyRegex = new(@"\d", RegexOptions.Compiled);

    private static readonly Dictionary<string, string> SpelledOutDigits =
        new()
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
            ["nine"] = "9",
        };

    public int ExtractCalibrationValue(string line)
    {
        var (firstDigit, lastDigit) = (this.FindFirstDigit(line), this.FindLastDigit(line));
        return string.IsNullOrEmpty(firstDigit) || string.IsNullOrEmpty(lastDigit)
            ? 0
            : int.Parse($"{firstDigit}{lastDigit}");
    }

    public int CalculateTotalCalibration(List<string> lines)
    {
        return lines.Sum(this.ExtractCalibrationValue);
    }

    private static string FindDigitWithLowestIndex(string line)
    {
        var lowestIndex = int.MaxValue;
        var firstDigit = string.Empty;

        foreach (Match match in MyRegex.Matches(line))
        {
            if (match.Index >= lowestIndex)
            {
                continue;
            }

            lowestIndex = match.Index;
            firstDigit = match.Value;
        }

        foreach (var (word, digit) in SpelledOutDigits)
        {
            var index = line.IndexOf(word, StringComparison.Ordinal);
            if (index < 0 || index >= lowestIndex)
            {
                continue;
            }

            lowestIndex = index;
            firstDigit = digit;
        }

        return firstDigit;
    }

    private static string FindDigitWithHighestIndex(string line)
    {
        var (highestIndex, lastDigit) = (-1, string.Empty);

        foreach (Match match in MyRegex.Matches(line))
        {
            (highestIndex, lastDigit) = (
                match.Index > highestIndex ? match.Index : highestIndex,
                match.Value);
        }

        foreach (var (word, digit) in SpelledOutDigits)
        {
            var index = line.LastIndexOf(word, StringComparison.Ordinal);
            if (index < 0 || index <= highestIndex)
            {
                continue;
            }

            (highestIndex, lastDigit) = (index, digit);
        }

        return lastDigit;
    }

    private string FindFirstDigit(string line)
    {
        return part == Part.One ? MyRegex.Match(line).Value : FindDigitWithLowestIndex(line);
    }

    private string FindLastDigit(string line)
    {
        return part == Part.One
            ? MyRegex.Match(new string(line.Reverse().ToArray())).Value
            : FindDigitWithHighestIndex(line);
    }
}