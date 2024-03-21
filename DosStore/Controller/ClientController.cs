using DosStore.Exceptions;
using DosStore.Models;
using DosStore.Models.Read;
using DosStore.Repository;
using DosStore.Validators;

namespace DosStore.Controller;

public class ClientController
{
    private readonly ClientRepository _clientRepository = new();
    
    public async Task<IReadOnlyList<MinimalReadClientModel>> GetAllClients()
    {
        var allClients = await _clientRepository.GetAllClients();
        var minimalReadClientModels = allClients
            .Select(f => new MinimalReadClientModel
            {
                id = f.id,
                nome = f.nome,
                email = f.email,
            }).ToList();

        return minimalReadClientModels;
    }
    
    public async Task<ClienteModel> GetClientById(int id)
    {
        ClienteModel? client = await _clientRepository.GetClientById(id);
        if(client is null)
            throw new ClientNotFoundException();

        return client;
    }
    
    public async Task CreateClient(ClienteModel cliente)
    {
        await _clientRepository.CreateClient(cliente);
    }

    public bool ValidateEmail(string value)
    {
        return EmailValidator.MatchEmail(value);
    }
    public bool ValidateDdd(string value)
    {
        return value.Length == 2;
    }
    public bool ValidatePhone(string value)
    {
        return value.Length == 9;
    }
    public bool ValidateDiaNascimento(int value)
    {
        return value is >= 1 and <= 31;
    }
    public bool ValidateMesNascimento(int value)
    {
        return value is >= 1 and <= 12;
    }
    public bool ValidateAnoNascimento(int value)
    {
        return value <= DateTime.Now.Year;
    }
}