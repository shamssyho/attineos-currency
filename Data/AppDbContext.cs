using AttineosCurrency.Entities;
using Microsoft.EntityFrameworkCore;

namespace AttineosCurrency.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Currency> AttineosCurrencies { get; set; }
}