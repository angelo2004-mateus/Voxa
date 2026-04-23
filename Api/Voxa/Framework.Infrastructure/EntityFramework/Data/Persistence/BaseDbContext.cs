using Microsoft.EntityFrameworkCore;

namespace Framework.Infrastructure.EntityFramework.Data.Persistence;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        
        ApplyNamingConvention(builder);
    }
    
    private void ApplyNamingConvention(ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.ClrType.Name.ToLower());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.Name.ToLower());
            }
        }
    }
}