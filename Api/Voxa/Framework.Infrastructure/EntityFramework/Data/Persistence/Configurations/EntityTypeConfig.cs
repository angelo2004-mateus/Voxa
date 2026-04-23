using Framework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.Infrastructure.EntityFramework.Data.Persistence.Configurations;

public abstract class EntityTypeConfig<TEntity> : IEntityTypeConfiguration<TEntity> where  TEntity : class, IEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        CustomConfiguration(builder);
    }

    protected abstract void CustomConfiguration(EntityTypeBuilder<TEntity> builder);
}