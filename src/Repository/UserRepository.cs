using DosStore.Context;
using DosStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DosStore.Repository;

public class UserRepository
{
    public async Task<UserModel?> GetClientByLoginPassword(string login, string password)
    {
        await using AppDbContext dbContext = new();
        UserModel? clienteModel = await dbContext.users
            .FirstOrDefaultAsync(f => f.login == login && f.senha == password);
        return clienteModel;
    }
}