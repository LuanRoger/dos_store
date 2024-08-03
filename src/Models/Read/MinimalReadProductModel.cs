namespace DosStore.Models.Read;

public class MinimalReadProductModel
{
    public required int id { get; init; }
    public required string nome { get; init; }
    public required double valor { get; init; }
    public required int quantidade { get; init; }
}