using DosStore.Models.Read;

namespace DosStore.Utils;

public static class MinimalReadSalesModelFormater
{
    public static string FormatSale(MinimalReadSalesModel sale) =>
        $"Venda #{sale.id} - Cliente: {sale.cliente.nome} - Total: R$ {sale.total:F2}";
}