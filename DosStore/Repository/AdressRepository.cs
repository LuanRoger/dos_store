using DosStore.Context;
using DosStore.Models;

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
}