using Framework.Domain.Entities;
using Voxa.Domain.Users;

namespace Voxa.Domain.Organizations;

public class OrganizationMembership : Entity<Guid>
{
    // REFERENCE
    public virtual Guid UserId { get; set; }
    public virtual Guid OrganizationId { get; set; }
    
    // NAVIGATION
    public virtual User User { get; set; }
    public virtual Organization Organization { get; set; }
    
   
    public virtual OrganizationRole Role { get; set; }
}