﻿using Spectre.Console;

namespace DosStore.Views;

public class ManageClientsMenuView : IMenuView
{
    public char ShowMenu()
    {
        string? menuOptions = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Gerenciar clientes.")
                .AddChoices([
                    "1 - Cadastrar endereço.",
                    "2 - Deletar cliente.",
                    "0 - Voltar."
                ]));
        char option = menuOptions.First();
        return option;
    }
}
