using Spectre.Console;

namespace DosStore.Views.Messages;

public class CreateClienteMenuMessages
{
    public void ClienteRegisteredSuccessMessage()
    {
        Panel messagePanel = new Panel("Cliente registrado com sucesso!")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
}