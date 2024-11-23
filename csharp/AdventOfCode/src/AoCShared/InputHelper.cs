namespace AoCShared;

using System.IO;

public class InputHelper
{
    private const string InputsPath = "../../../../../../../_inputs";
    
    public static string GetInput(int year, int day)
    {
        string filePath = $"{InputsPath}/{year}/day{day:D2}.txt";
        if (File.Exists(filePath)) return Path.GetFullPath(filePath);

        throw new FileNotFoundException($"Input file for {year} day {day} not found.");
    }

    public static string GetExample(int year, int day, string? suffix)
    {
        if (string.IsNullOrWhiteSpace(suffix))
        {
            throw new ArgumentException("Suffix cannot be null or whitespace.", nameof(suffix));
        }

        string filePath = $"{InputsPath}/{year}/day{day:D2}{suffix}.txt";
        if (File.Exists(filePath)) return Path.GetFullPath(filePath);

        throw new FileNotFoundException($"{suffix} file for {year} day {day} not found.");    }
}
