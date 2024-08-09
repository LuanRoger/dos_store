using Spectre.Console;

namespace DosStore.Views.Messages;

public class UpdateProductMessages
{
    public void ProductAmountUpdated()
    {
        Panel messagePanel = new Panel("Quantidade atualizada com sucesso!")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
    
    public void ProductAmountNotUpdated()
    {
        Panel messagePanel = new Panel("Não foi possível atualizar a quantidade do produto.")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
}