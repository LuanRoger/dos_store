using Spectre.Console;

namespace DosStore.Views.Messages;

public class DeleteClientMessages
{
    public void ShowClientDeleted()
    {
        Panel messagePanel = new Panel("Cliente deletado com sucesso!")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
    
    public void CantDeleteClient()
    {
        Panel messagePanel = new Panel("Näo foi possível deletar o cliente")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
}