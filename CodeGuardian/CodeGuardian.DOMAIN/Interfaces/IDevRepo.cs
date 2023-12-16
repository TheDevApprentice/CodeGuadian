using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IDevRepo
{
    Dev GetUserByID(int id);

    Dev GetAnUserByName(string employeeName);

    List<Dev> GetAllUsers();

    List<Application> GetUserApplication(int userId);

    List<Application> CheckUserApplicationLicenceKey(int userId, int appid, string licenseKey);
}