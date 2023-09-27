using System.Text.RegularExpressions;

namespace PasswordLibrary;

public static class Password
{
    /// <summary>
    /// Уровни сложности пароля
    /// </summary>
    private static List<string> levels = new List<string>()
    {
        "Слишком слабый", "Слабый", "Средний", "Хороший", "Надёжный"
    };
    /// <summary>
    /// Содержит описание условия для достижения уровня.
    /// В порядке возрастания,где последущее должно обязательно включать предыдущие
    /// </summary>
    private static List<string> description = new List<string>()
    {
        "Менее 6 символов",  "Не менее 6 символов", "Содержит как маленькие, так и большие латинские буквы", 
        "Содержит хотя бы одну цифру", "Содержит хотя бы один символ (!, $, #, %)"
    };
    
    public static string Check(string password)
    {
        // For High Secure
        char[] symbols = 
        {
            '$', '!', '%', '#'
        };
        bool BigEng = false, SmallEng = false, Digit = false, Symbol = false;
        foreach (var chr in password)
        {
            if (char.IsDigit(chr))
            {
                Digit = true;
            }
            if (char.IsLetter(chr) && char.IsLower(chr))
            {
                SmallEng = true;
            }
            if (char.IsLetter(chr) && char.IsUpper(chr))
            {
                BigEng = true;
            }
            if (symbols.Contains(chr))
            {
                Symbol = true;
            }
        }

        return password.Length switch
        {
            > 6 when BigEng && SmallEng && Digit && Symbol => levels[4],
            > 6 when BigEng && SmallEng && Digit => levels[3],
            > 6 when BigEng && SmallEng => levels[2],
            > 6 => levels[1],
            _ => levels[0]
        };
    }
}
