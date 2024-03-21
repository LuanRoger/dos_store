using Spectre.Console;

namespace DosStore.Views;

public class ManageClientsMenu : IMenuView
{
    public char ShowMenu()
    {
        string? menuOptions = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Gerenciar clientes.")
                .AddChoices([
                    "1 - Cadastrar endereço.",
                    "2 - Deletar usuário.",
                    "0 - Voltar."
                ]));
        char option = menuOptions.First();
        return option;
    }
}