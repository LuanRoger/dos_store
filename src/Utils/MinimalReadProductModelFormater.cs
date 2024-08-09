using DosStore.Models.Read;

namespace DosStore.Utils;

public static class MinimalReadProductModelFormater
{
    public static string FormatProduct(MinimalReadProductModel product) =>
        $"{product.nome} ({product.quantidade} unidades) - R${product.valor}";
}