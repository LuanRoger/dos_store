using Spectre.Console;

namespace DosStore.Views.Messages;

public class CreateSaleMenuMessages
{
    public void ShowCreatedSale()
    {
        Panel messagePanel = new Panel("Venda realizada com sucesso!")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
}