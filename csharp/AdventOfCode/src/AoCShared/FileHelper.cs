// <copyright file="FileHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AoCShared;

public static class FileHelper
{
    private const string BaseDir = "../../../../../../../_puzzle_inputs_answers";

    public static List<string> ReadLinesFromFile(string filePath)
    {
        return File.Exists(filePath)
            ? File.ReadAllLines(filePath).ToList()
            : throw new FileNotFoundException($"File not found: {filePath}");
    }

    public static string GetInputFile(int year, int day)
    {
        return GetFile(year, day, FileType.Input);
    }

    public static string GetExampleFile(int year, int day, Part part, string suffix)
    {
        return GetFile(year, day, FileType.Example, part, suffix);
    }

    public static string GetAnswer(int year, int day, Part part, string? suffix = null)
    {
        return GetFile(year, day, FileType.Answer, part, suffix);
    }

    private static string ConstructFileName(int day, FileType type, Part part, string? suffix)
    {
        return type switch
        {
            FileType.Input => $"day{day:D2}_input.txt",
            FileType.Example when !string.IsNullOrEmpty(suffix) =>
                $"day{day:D2}_part{(int)part}_example_{suffix}_input.txt",
            FileType.Answer when !string.IsNullOrEmpty(suffix) =>
                $"day{day:D2}_part{(int)part}_example_{suffix}_answer.txt",
            FileType.Answer => $"day{day:D2}_part{(int)part}_answer.txt",
            _ => throw new ArgumentException("Invalid file type or missing suffix for example files."),
        };
    }

    private static string ValidateAndGetFilePath(int year, int day, FileType type, Part part, string? suffix = null)
    {
        var fileName = ConstructFileName(day, type, part, suffix);
        var filePath = Path.Combine(BaseDir, year.ToString(), fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"{type} file for year {year}, day {day} not found: {filePath}");
        }

        return filePath;
    }

    private static string GetFile(int year, int day, FileType type, Part part = Part.One, string? suffix = null)
    {
        var filePath = ValidateAndGetFilePath(year, day, type, part, suffix);

        // If the file type is "Answer", return its content; otherwise, return the file path.
        return type == FileType.Answer
            ? File.ReadAllText(filePath).Trim()
            : filePath;
    }
}