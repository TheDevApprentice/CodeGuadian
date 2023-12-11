using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IAdministratorService
{
    User AddAnuser(User userToAdd);

    User GetUserByID(int id);

    User GetAnUserByName(string employeeName);

    List<User> GetAllUsers();

    List<Application> GetAllApplication();

    Application GetApplicationById(int id);

    List<License> GetAllLicenses();

    License GetLicenseById(int licenceId);

    List<Permission> GetAlPermissions();

    Permission GetPermissionById(int permissionId);
}