using DosStore.Models.Read;

namespace DosStore.Utils;

public static class MinimalReadClientModelFormater
{
    public static string FormatClient(MinimalReadClientModel client) =>
        $"{client.nome} ({client.email})";
}