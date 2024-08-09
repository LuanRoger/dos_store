using Spectre.Console;

namespace DosStore.Views.Messages;

public class DeleteProductMessages
{
    public void ProductDeleted()
    {
        Panel messagePanel = new Panel("Produto deletado com sucesso!")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
    
    public void CantDeleteProduct()
    {
        Panel messagePanel = new Panel("Não foi possível deletar o produto.")
            .Border(BoxBorder.Rounded);
        AnsiConsole.Write(messagePanel);
    }
}