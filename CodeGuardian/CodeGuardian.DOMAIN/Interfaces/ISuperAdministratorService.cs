using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface ISuperAdministratorService
{
    List<Organisation> GetAllOrganisations();

    Organisation GetOrganisationById(Guid organisationId);

    Organisation ModifyOrganisation(Guid organisationId);

    bool DeleteOrganisation(Guid organisationId);


    List<Dev> GetOrganisationDevs(Guid organisationId);

    Dev GetAnUserByName(string employeeName);

    Dev GetOrganisationDevById(Guid organisationId, Guid devId);

    Dev CreateOrganisationDev(Guid organisationId);

    Dev ModifyOrganisationDev(Guid organisationId, Guid devId);

    bool DeleteOrganisationDev(Guid organisationId, Guid devId);


    List<Application> GetAllApplication();

    Application GetApplicationById(Guid id);

    Application RegisterAppForOrganisation(Guid organisationId);

    Application ModifyOrganisationApp(Guid organisationId, Guid appId);

    bool DeleteOrganisationApp(Guid organisationId, Guid appId);


    List<License> GetAllLicenses();

    License GetLicenseById(Guid licenceId);


    List<Permission> GetAlPermissions();

    Permission GetPermissionById(int permissionId);
}