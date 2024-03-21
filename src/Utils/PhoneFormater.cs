namespace DosStore.Utils;

public static class PhoneFormater
{
    public static string FormatPhone(string ddd, string number) => $"({ddd}) {number}";
}