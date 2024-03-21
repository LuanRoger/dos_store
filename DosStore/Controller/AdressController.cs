using DosStore.Exceptions;
using DosStore.Models;
using DosStore.Repository;

namespace DosStore.Controller;

public class AdressController
{
    private readonly AdressRepository _adressRepository = new();
    private readonly ClientRepository _clientRepository = new();
    
    public async Task RegisterAdressForUser(AdressModel adress, int clientId)
    {
        ClienteModel? client = await _clientRepository.GetClientById(clientId);
        if(client is null)
            throw new ClientNotFoundException();
        
        await _adressRepository.RegisterAdressForUser(adress, client);
    }
}