using CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IOrganisationRepo
{
    List<Organisation> GetAllOrganisations();

    Organisation GetOrganisationById(Guid organisationId);
}