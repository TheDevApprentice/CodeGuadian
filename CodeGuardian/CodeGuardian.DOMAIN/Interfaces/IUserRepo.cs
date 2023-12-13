using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IUserRepo
{
    User GetUserByID(int id);

    User GetAnUserByName(string employeeName);

    List<User> GetAllUsers();

    List<Application> GetUserApplication(int userId);

    List<Application> CheckUserApplicationLicenceKey(int userId, int appid, string licenseKey);
}