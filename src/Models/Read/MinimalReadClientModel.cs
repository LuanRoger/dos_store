namespace DosStore.Models.Read;

public class MinimalReadClientModel
{
    public required int id { get; init; }
    public required string nome { get; init; }
    public required string email { get; init; }
}