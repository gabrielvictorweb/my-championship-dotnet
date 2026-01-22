using Microsoft.EntityFrameworkCore;
using my_championship.Domain.Entities;

namespace my_championship.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Championship> Championships => Set<Championship>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<TeamKey> TeamKeys => Set<TeamKey>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");

        base.OnModelCreating(modelBuilder);
    }
}
