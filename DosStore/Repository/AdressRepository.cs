using DosStore.Context;
using DosStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DosStore.Repository;

public class AdressRepository
{
    public async Task RegisterAdressForUser(AdressModel adress, ClienteModel client)
    {
        await using AppDbContext dbContext = new();
        await dbContext.adress.AddAsync(adress);
        
        adress.cliente = client;
        
        await dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<AdressModel>> GetClientAdreesById(int clientId)
    {
        await using AppDbContext dbContext = new();
        var adress = await dbContext.adress.Where(f => f.cliente.id == clientId).ToListAsync();
        
        return adress;
    }
}