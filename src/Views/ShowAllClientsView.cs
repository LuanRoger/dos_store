using DosStore.Controller;
using DosStore.Models;
using DosStore.Models.Read;
using Spectre.Console;

namespace DosStore.Views;

public class ShowAllClientsView : IFlowMenuView
{
    private readonly ClientController _clientControlle = new();
    private readonly LoginView _loginView = new();
    
    public async Task StartFlow()
    {
        UserModel? clienteModel = await _loginView.StartFlow();
        if(clienteModel is null)
            return;
        
        var clients = await _clientControlle.GetAllClients();

        Table clientsTable = new Table()
            .Title("Clientes cadastrados")
            .Alignment(Justify.Center)
            .Border(TableBorder.Rounded)
            .Expand()
            .AddColumns("Nome")
            .AddColumns("Email");
        
        foreach(MinimalReadClientModel client in clients)
            clientsTable.AddRow(client.nome, client.email);
        
        AnsiConsole.Write(clientsTable);
    }
}