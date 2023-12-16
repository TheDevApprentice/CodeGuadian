using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;

public class Organisation : ClientObject
{
    public Organisation()
    {
        OrganisationAdmins = new List<OrganisationAdmin>();
        OrganisationApplications = new List<OrganisationApplication>();
    }

    public ICollection<OrganisationAdmin> OrganisationAdmins { get; set; }

    public ICollection<OrganisationApplication> OrganisationApplications { get; set; }
}
