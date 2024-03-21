using DosStore.Controller;
using DosStore.Exceptions;
using DosStore.Models;
using DosStore.Views.Messages;
using Spectre.Console;

namespace DosStore.Views;

public class ShowClientView : IFlowMenu
{
    private readonly ClientController _clientController = new();
    private readonly AdressController _adressController = new();
    private readonly PickClientWLoginView _pickClientWLoginView = new();
    private readonly PickClientsWLoginMessages _pickClientsWLoginMessages = new();
    
    public async Task StartFlow()
    {
        var userClientInfo = await _pickClientWLoginView.StartFlow();
        if(!userClientInfo.HasValue && userClientInfo is null)
        {
            return;
        }

        (UserModel _, int clientId) = userClientInfo.Value;

        ClienteModel clientInfo;
        try
        {
            clientInfo = await _clientController.GetClientById(clientId);
        }
        catch (ClientNotFoundException)
        {
            _pickClientsWLoginMessages.NoRegisteredClient();
            return;
        }
        
        var clientAdresses = await _adressController.GetClientAdressById(clientId);

        Tree clientTree = new(clientInfo.nome);
        clientTree.AddNodes(clientInfo.email, clientInfo.tellNumb, clientInfo.dataNascimento.ToLongDateString());
        TreeNode adressNode = clientTree.AddNode("Endereçcos");
        foreach (AdressModel clientAdress in clientAdresses)
        {
            TreeNode specificAdressNode = adressNode.AddNode(clientAdress.rua);
            specificAdressNode.AddNodes(clientAdress.numero, clientAdress.bairro, clientAdress.cep, clientAdress.cidade, 
                clientAdress.complemento, clientAdress.pontoReferencia);
        }
        
        AnsiConsole.Write(clientTree);
    }
}