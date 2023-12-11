using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IAdministratorRepo
{
    User AddAnuser(User userToAdd);

    List<Application> GetAllApplication();

    Application GetApplicationById(int id);

    List<License> GetAllLicenses();

    License GetLicenseById(int licenceId);

    List<Permission> GetAlPermissions();

    Permission GetPermissionById(int permissionId);

    User GetUserByID(int id);

    User GetAnUserByName(string employeeName);

    List<User> GetAllUsers();
}