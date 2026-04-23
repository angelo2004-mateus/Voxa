using Framework.Domain.Entities.Auditing;

namespace Voxa.Domain.Organizations;

public class Organization : AuditedAggregate<Guid>
{
    public virtual string Name { get; set; }
    
    public virtual IList<OrganizationMembership> Memberships { get; set; }

    public Organization()
    {
        Memberships = new List<OrganizationMembership>();
    }
}