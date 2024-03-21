using Spectre.Console;

namespace DosStore.Views.Messages;

public class PickClientsWLoginMessages
{
    public void NoClientsFound()
    {
        Panel messagePanel = new Panel("Não há clientes cadastrados!")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
    public void NoRegisteredClient()
    {
        Panel messagePanel = new Panel("Cliente não cadastrado")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
}