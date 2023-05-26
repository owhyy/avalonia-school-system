using System.Linq;

namespace StudentManagement.ViewModels;

internal static class ValidationUtils
{
    public static bool IsValidGroupCode(object? value)
    {
        if (value is not string i)
            return false;
        return i.Length == 6 && char.IsAsciiLetter(i[0]) && i[1] == '-' && i[2..].All(char.IsDigit);
    }

    public static bool IsValidCourseCode(object? value)
    {
        if (value is not string i)
            return false;
        return i.Length is >= 4 and <= 10;
    }

    public static bool IsGreaterThanZero(object? value)
    {
        return value is > 0;
    }

    public static bool IsValidMark(object? value)
    {
        return value is > 0 and <= 10;
    }
}
