namespace DosStore.Models.Read;

public class MinimalReadSalesModel
{
    public required int id { get; init; }
    public required IReadOnlyList<MinimalReadProductModel> produtosComprados { get; init; }
    public required MinimalReadClientModel cliente { get; init; }
    public required double total { get; init; }
}