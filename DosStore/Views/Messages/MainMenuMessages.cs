using Spectre.Console;

namespace DosStore.Views.Messages;

public class MainMenuMessages
{
    public void GoodbayMessage()
    {
        Panel messagePanel = new Panel("Até mais")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
}