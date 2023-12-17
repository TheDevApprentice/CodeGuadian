using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;

public class Organisation : ClientObject
{
    public Organisation()
    {
        OrganisationAdmins = new List<OrganisationAdmin>();
        OrganisationApplications = new List<OrganisationApplication>();
        OrganisationDevs = new List<OrganisationDevs>();
    }
    public Guid Uuid { get; set; } = Guid.NewGuid();
    public ICollection<OrganisationAdmin> OrganisationAdmins { get; set; }

    public ICollection<OrganisationApplication> OrganisationApplications { get; set; }
    public ICollection<OrganisationDevs> OrganisationDevs { get; set; }
}
