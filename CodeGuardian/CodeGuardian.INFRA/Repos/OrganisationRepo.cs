using CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.INFRA.Repos;

public class OrganisationRepo : IOrganisationRepo
{
    private CodeGuardianDbContext _dbCodeGuardian;

    public OrganisationRepo(CodeGuardianDbContext CodeGuardianDbContext)
    {
        this._dbCodeGuardian = CodeGuardianDbContext;
    }

    public List<Organisation> GetAllOrganisations()
    {
        return _dbCodeGuardian.Organisations.ToList();
    }

    public Organisation GetOrganisationById(Guid organisationId)
    {
        return _dbCodeGuardian.Organisations.FirstOrDefault(licence => licence.Uuid == organisationId);
    }
}