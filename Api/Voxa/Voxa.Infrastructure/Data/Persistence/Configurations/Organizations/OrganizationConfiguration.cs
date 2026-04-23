using Framework.Infrastructure.EntityFramework.Data.Persistence.Configurations;
using Framework.Infrastructure.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voxa.Domain.Organizations;

namespace Voxa.Infrastructure.Data.Persistence.Configurations.Organizations;

public class OrganizationConfiguration : AuditedAggregateTypeConfiguration<Organization>
{
    protected override void CustomConfiguration(EntityTypeBuilder<Organization> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasRandomUUID();
        
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.HasMany(c => c.Memberships)
            .WithOne(c => c.Organization)
            .HasForeignKey(c => c.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}