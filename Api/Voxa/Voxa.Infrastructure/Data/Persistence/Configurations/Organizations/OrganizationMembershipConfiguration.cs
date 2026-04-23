using Framework.Infrastructure.EntityFramework.Data.Persistence.Configurations;
using Framework.Infrastructure.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voxa.Domain.Organizations;

namespace Voxa.Infrastructure.Data.Persistence.Configurations.Organizations;

public class OrganizationMembershipConfiguration : EntityTypeConfig<OrganizationMembership>
{
    protected override void CustomConfiguration(EntityTypeBuilder<OrganizationMembership> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasRandomUUID();
        
        builder.HasOne(c => c.User)
            .WithMany(c => c.Memberships)
            .HasForeignKey(c => c.UserId);
        
        builder.HasOne(c => c.Organization)
            .WithMany(c => c.Memberships)
            .HasForeignKey(c => c.OrganizationId);
        
        builder.HasIndex(c => new { c.UserId, c.OrganizationId })
            .IsUnique();;
    }
}