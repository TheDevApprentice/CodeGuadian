using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAINE.Interfaces;

public interface IUserService
{
    User GetuserByID(int id);

    User GetAnUserByName(string username);

    List<User> GetAllUsers();

    List<Application> GetUserApplications(int userId);

    List<Application> CheckUserApplicationLicenceKey(int userId, int appid, string licenseKey);
}