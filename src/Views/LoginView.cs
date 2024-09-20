using DosStore.Controller;
using DosStore.Exceptions;
using DosStore.Models;
using Spectre.Console;

namespace DosStore.Views;

public class LoginView : IResultedMenu<UserModel?>
{
    private readonly UserController _clientController = new();
    
    public async Task<UserModel?> StartFlow()
    {
        string login = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite seu login:"));
        string senha = AnsiConsole.Prompt(
            new TextPrompt<string>("Digite sua senha:")
                .Secret());

        UserModel clienteModel;
        try
        {
            clienteModel = await _clientController.GetClientByLoginPassword(login, senha);
        }
        catch (UserNotFoundException)
        {
            Panel errorPanel = new("Usuário e senha inválidos");
            AnsiConsole.Write(errorPanel);
            return null;
        }

        return clienteModel;
    }
}