using Spectre.Console;

namespace DosStore.Views;

public class ManageClientsView : IMenuView
{
    public char ShowMenu()
    {
       string? menuOptions = AnsiConsole.Prompt(
           new SelectionPrompt<string>()
               .Title("DOS Store")
               .AddChoices([
                   "1 - Cadastrar endereço.",
                   "2 - Deletar usuário.",
                   "0 - Voltar."
               ]));
       char option = menuOptions.First();
       return option;
    }
}