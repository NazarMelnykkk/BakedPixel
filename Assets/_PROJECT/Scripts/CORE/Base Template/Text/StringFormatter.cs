using System.Text;

public static class StringFormatter 
{
    /// <summary>
    /// Метод для преобразования строки BlackTea  в формат "Black tea"
    /// </summary>
    public static string ToProperCaseWithSpacesBeforeUppercase(string input)
    {
        var result = new StringBuilder();

        bool isNewWord = true;  

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (char.IsUpper(ch) && i > 0)
            {
                result.Append(' ');
                isNewWord = true;
            }

            if (isNewWord)
            {
                result.Append(char.ToUpper(ch));
                isNewWord = false;
            }
            else
            {
                result.Append(char.ToLower(ch));
            }
        }

        return result.ToString();
    }


    /// <summary>
    /// Метод для добавления пробела перед заглавными буквами
    /// </summary>
    public static string AddSpacesBeforeUppercase(string input)
    {
        var result = new StringBuilder();

        foreach (var ch in input)
        {
            if (char.IsUpper(ch) && result.Length > 0)
            {
                result.Append(' ');
            }
            result.Append(ch);
        }

        return result.ToString();
    }


    /// <summary>
    /// делает строку заглавными
    /// </summary>
    public static string ToUpperCase(string input)
    {
        return input.ToUpper();
    }

    /// <summary>
    /// делает строку строчными
    /// </summary>
    public static string ToLowerCase(string input)
    {
        return input.ToLower();
    }

    /// <summary>
    /// удаляет пробелы в начале и в конце строки
    /// </summary>
    public static string TrimSpaces(string input)
    {
        return input.Trim();
    }
}
