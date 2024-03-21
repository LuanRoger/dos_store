using Spectre.Console;

namespace DosStore.Views.Messages;

public class AddAdressToClientMenuMessages
{
    public void AdressAdded()
    {
        Panel messagePanel = new Panel("Endereço adicionado com sucesso!")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
}