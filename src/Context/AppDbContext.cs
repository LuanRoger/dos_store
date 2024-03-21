using DosStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DosStore.Context;

public class AppDbContext : DbContext
{
    public DbSet<AdressModel> adress { get; set; }
    public DbSet<ClienteModel> clientes { get; set; }
    public DbSet<UserModel> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./main.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .HasData(new UserModel
            {
                id = 1,
                login = "admin",
                senha = "admin"
            });
    }
}