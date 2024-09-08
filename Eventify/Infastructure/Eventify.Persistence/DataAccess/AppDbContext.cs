using Eventify.Domain.Common;
using Eventify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Persistence.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<Event> Events => Set<Event>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>().OwnsOne(x => x.Location);

        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=EventifyProject;Integrated Security=True;TrustServerCertificate=true;");
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var data = ChangeTracker.Entries<BaseEntity>();
        foreach (var entity in data)
        {
            if (entity.State == EntityState.Added)
                entity.Entity.CreatedDate = DateTime.UtcNow;
            else if (entity.State == EntityState.Modified)
                entity.Entity.UpdatedDate = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
