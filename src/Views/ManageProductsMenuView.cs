using Spectre.Console;

namespace DosStore.Views;

public class ManageProductsMenuView : IMenuView
{
    public char ShowMenu()
    {
        string? menuOptions = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Gerenciar produtos.")
                .AddChoices([
                    "1 - Cadastrar produto.",
                    "2 - Atualizar quantidade.",
                    "3 - Deletar produto.",
                    "0 - Voltar."
                ]));
        char option = menuOptions.First();
        return option;
    }
}