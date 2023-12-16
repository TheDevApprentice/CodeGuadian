using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IAdministratorRepo
{
    Dev AddAnUser(Dev userToAdd);

    List<Application> GetAllApplication();

    Application GetApplicationById(int id);

    List<License> GetAllLicenses();

    License GetLicenseById(int licenceId);

    List<Permission> GetAlPermissions();

    Permission GetPermissionById(int permissionId);

    Dev GetUserByID(int id);

    Dev GetAnUserByName(string employeeName);

    List<Dev> GetAllUsers();
}