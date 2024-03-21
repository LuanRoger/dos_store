using DosStore.Context;
using DosStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DosStore.Repository;

public class ClientRepository
{
    public async Task<ClienteModel?> GetClientById(int id)
    {
        await using AppDbContext dbContext = new();
        ClienteModel? clienteModel = await dbContext.clientes.FindAsync(id);
        return clienteModel;
    }
    
    public async Task CreateClient(ClienteModel cliente)
    {
        await using AppDbContext dbContext = new();
        await dbContext.AddAsync(cliente);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<ClienteModel>> GetAllClients()
    {
        await using AppDbContext dbContext = new();
        List<ClienteModel> allClients = await dbContext.clientes
            .AsNoTracking()
            .ToListAsync();

        return allClients;
    }

    public async Task<bool> DeleteClientById(int clientId)
    {
        await using AppDbContext dbContext = new();
        ClienteModel? cliente = await dbContext.clientes.
            FindAsync(clientId);
        if(cliente is null)
            return false;
        
        dbContext.clientes.Remove(cliente);

        await dbContext.SaveChangesAsync();
        
        return true;
    }
}