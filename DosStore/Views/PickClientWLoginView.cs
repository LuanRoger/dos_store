using DosStore.Models;
using DosStore.Views.Messages;

namespace DosStore.Views;

public class PickClientWLoginView : IResultedFlowMenu<(UserModel, int)?>
{
    private readonly PickClientsWLoginMessages _messages = new();
    private readonly LoginView _loginView = new();
    
    public async Task<(UserModel, int)?> StartFlow()
    {
        UserModel? clienteModel = await _loginView.StartFlow();
        if(clienteModel is null)
            return null;
        
        PickClientMenu pickClientMenu = new();
        int clientId = await pickClientMenu.StartFlow();
        if(clientId == -1)
        {
            _messages.NoClientsFound();
            return null;
        }
        
        return (clienteModel, clientId);
    }
}