using Framework.Infrastructure.EntityFramework.Data.Persistence.Configurations;
using Framework.Infrastructure.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voxa.Domain.Users;

namespace Voxa.Infrastructure.Data.Persistence.Configurations.Users;

public class UserConfiguration : EntityTypeConfig<User>
{
    protected override void CustomConfiguration(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(c => c.Id)
            .HasRandomUUID();
        
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(c => c.Password)
            .IsRequired();

        builder.Property(c => c.Role);
        
        builder.HasMany(c => c.Memberships)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}