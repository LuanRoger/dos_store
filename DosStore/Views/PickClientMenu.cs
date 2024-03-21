using DosStore.Controller;
using DosStore.Models.Read;
using DosStore.Utils;
using Spectre.Console;

namespace DosStore.Views;

public class PickClientMenu : IResultedFlowMenu<int>
{
    private readonly ClientController _clientController = new();
    
    public async Task<int> StartFlow()
    {
        var clients = await _clientController.GetAllClients();
        bool areClients = clients.Any();
        if(!areClients)
            return -1;
        
        MinimalReadClientModel selectedUser = AnsiConsole.Prompt(
            new SelectionPrompt<MinimalReadClientModel>()
                .Title("Qual cliente você deseja escolher?")
                .PageSize(10)
                .MoreChoicesText("[grey](Mova para cima e para baixo para ver mais opções)[/]")
                .AddChoices(clients)
                .UseConverter(MinimalReadClientModelFormater.FormatClient)
            );
        
        return selectedUser.id;
    }
}