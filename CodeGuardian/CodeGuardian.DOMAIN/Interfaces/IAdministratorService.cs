using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IAdministratorService
{
    Dev AddADevelopper(Dev userToAdd);

    Dev GetUserByID(int id);

    Dev GetAnUserByName(string employeeName);

    List<Dev> GetAllUsers();

    List<Application> GetAllApplication();

    Application GetApplicationById(Guid id);

    List<License> GetAllLicenses();

    License GetLicenseById(Guid licenceId);

    List<Permission> GetAlPermissions();

    Permission GetPermissionById(int permissionId);
}