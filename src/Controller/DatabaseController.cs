using DosStore.Context;

namespace DosStore.Controller;

public class DatabaseController
{
    public async Task CreateDatabase()
    {
        await using AppDbContext db = new();
        await db.Database.EnsureCreatedAsync();
    }
    public async Task DropDatabase()
    {
        await using AppDbContext db = new();
        await db.Database.EnsureDeletedAsync();
    }
}