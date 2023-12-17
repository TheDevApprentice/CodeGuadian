using CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;

namespace CodeGuardian.DOMAINE.Interfaces;

public interface IOrganisationService
{
    List<Organisation> GetAllOrganisations();

    Organisation GetOrganisationById(Guid organisationId);
}