using CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.DOMAINE.Services;

public class OrganisationService : IOrganisationService
{
    private IOrganisationRepo _organisationRepo;

    public OrganisationService(IOrganisationRepo organisationRepo)
    {
        this._organisationRepo = organisationRepo;
    }

    public List<Organisation> GetAllOrganisations()
    {
        return _organisationRepo.GetAllOrganisations();
    }

    public Organisation GetOrganisationById(Guid organisationId)
    {
        return _organisationRepo.GetOrganisationById(organisationId);
    }
}