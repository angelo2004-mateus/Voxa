using Framework.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.Infrastructure.EntityFramework.Data.Persistence.Configurations;

public abstract class AuditedAggregateTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IAudited
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        PerformMapping(builder);
        CustomConfiguration(builder);
    }

    private void PerformMapping(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(c => c.CreationTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
        
        builder.Property(c => c.UpdatedTime)
            .ValueGeneratedOnUpdate()
            .IsRequired(false);
    }
    
    protected abstract void CustomConfiguration(EntityTypeBuilder<TEntity> builder);
}