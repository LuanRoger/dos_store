using DosStore.Controller;
using DosStore.Models;
using DosStore.Views.Messages;
using Spectre.Console;

namespace DosStore.Views;

public class CreateProductMenuView : ICommandMenuView
{
    private readonly ProductController _productController = new();
    private readonly CreateProductMenuMessages _createProductMenuMessages = new();
    
    public async Task StartFlow()
    {
        string nome = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite o nome do produto: "));
        int quantidade = AnsiConsole.Prompt(
            new TextPrompt<int>("Digite a quantidade atual: ")
                .ValidationErrorMessage("Digite um número válido")
                .Validate(_productController.ValidateAmount));
        double valor = AnsiConsole.Prompt(
            new TextPrompt<double>("Digite o valor do produto (R$): ")
                .ValidationErrorMessage("Digite um valor válido")
                .Validate(_productController.ValidateValue));
        
        ProdutoModel newProduct = new()
        {
            nome = nome,
            quantidade = quantidade,
            valor = valor
        };
        await _productController.RegisterProduct(newProduct);
        _createProductMenuMessages.ProductCreated();
    }
}