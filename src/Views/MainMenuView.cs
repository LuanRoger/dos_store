using DosStore.Views.Messages;
using Spectre.Console;

namespace DosStore.Views;

public class MainMenuView : IMenuView
{
    public MainMenuMessages messages { get; } = new();
    
    public char ShowMenu()
    {
        string? menuOptions = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("DOS Store")
                .AddChoices([
                    "1 - Cadastrar cliente.",
                    "2 - Gerenciar clientes.",
                    "3 - Mostrar dados do cliente.",
                    "4 - Mostrar clientes cadastrados.",
                    "5 - Mostrar produtos cadastrados.",
                    "6 - Gerenciar produtos.",
                    "7 - Realizar venda.",
                    "0 - Sair."
                ]));
        char option = menuOptions.First();
        return option;
    }
}