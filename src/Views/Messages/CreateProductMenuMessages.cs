using Spectre.Console;

namespace DosStore.Views.Messages;

public class CreateProductMenuMessages
{
    public void ProductCreated()
    {
        Panel messagePanel = new Panel("Produto criado com sucesso!")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
}