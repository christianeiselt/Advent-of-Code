namespace AoCShared;

public static class FileHelper
{
    private const string BaseDir = "../../../../../../../_puzzle_inputs_answers";

    private static string ConstructFileName(int day, FileType type, int part, string? suffix)
    {
        return type switch
        {
            FileType.Input => $"day{day:D2}_input.txt",
            FileType.Example when !string.IsNullOrEmpty(suffix) =>
                $"day{day:D2}_part{part}_example_{suffix}_input.txt",
            FileType.Answer when !string.IsNullOrEmpty(suffix) =>
                $"day{day:D2}_part{part}_example_{suffix}_answer.txt",
            FileType.Answer => $"day{day:D2}_part{part}_answer.txt",
            _ => throw new ArgumentException("Invalid file type or missing suffix for example files.")
        };
    }

    private static string ValidateAndGetFilePath(int year, int day, FileType type, int part, string? suffix = null)
    {
        var fileName = ConstructFileName(day, type, part, suffix);
        var filePath = Path.Combine(BaseDir, year.ToString(), fileName);

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"{type} file for year {year}, day {day} not found: {filePath}");

        return filePath;
    }

    private static string GetFile(int year, int day, FileType type, int part = 1, string? suffix = null)
    {
        var filePath = ValidateAndGetFilePath(year, day, type, part, suffix);

        // If the file type is "Answer", return its content; otherwise, return the file path.
        return type == FileType.Answer
            ? File.ReadAllText(filePath).Trim()
            : filePath;
    }

    public static string GetInputFile(int year, int day)
    {
        return GetFile(year, day, FileType.Input);
    }

    public static string GetExampleFile(int year, int day, int part, string suffix)
    {
        if (string.IsNullOrEmpty(suffix))
            throw new ArgumentException("Suffix is required for example files", nameof(suffix));
        return GetFile(year, day, FileType.Example, part, suffix);
    }

    public static string GetAnswer(int year, int day, int part, string? suffix = null)
    {
        return GetFile(year, day, FileType.Answer, part, suffix);
    }

    private enum FileType
    {
        Input,
        Example,
        Answer
    }
}