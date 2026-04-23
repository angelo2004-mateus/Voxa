using Framework.Domain.Entities.Auditing;
using Voxa.Domain.Organizations;

namespace Voxa.Domain.Users;

public class User : AuditedAggregate<Guid>
{
    public virtual string Name { get; set; }
    public virtual string Email { get; set; }
    public virtual string Password { get; set; }
    public virtual UserRole Role { get; set; }
    
    public virtual IList<OrganizationMembership> Memberships { get; set; }

    public User()
    {
        Memberships = new List<OrganizationMembership>();
        Role = UserRole.Customer;
    }
}