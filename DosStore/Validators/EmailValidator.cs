using System.Text.RegularExpressions;

namespace DosStore.Validators;

public static partial class EmailValidator
{
    public static bool MatchEmail(string value)
    {
        Regex emailRegex = EmailRegex();
        
        Match isEmailMatch = emailRegex.Match(value);
        return isEmailMatch.Success;
    }
    
    [GeneratedRegex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
    private static partial Regex EmailRegex();
}