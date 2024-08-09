using DosStore.Controller;
using DosStore.Models;
using DosStore.Views.Messages;

namespace DosStore.Views;

public class DeleteClientViewMenu : IFlowMenuView
{
    private readonly PickClientWLoginView _pickClientWLoginView = new();
    private readonly ClientController _clientController = new();
    private readonly DeleteClientMessages _messages = new();
    
    public async Task StartFlow()
    {
        var userClientInfo = await _pickClientWLoginView.StartFlow();
        if(!userClientInfo.HasValue && userClientInfo is null)
            return;
        
        (UserModel _, int clientId) = userClientInfo.Value;

        bool success = await _clientController.DeleteClientById(clientId);

        if (!success)
        {
            _messages.CantDeleteClient();
            return;
        }
        
        _messages.ShowClientDeleted();
    }
}