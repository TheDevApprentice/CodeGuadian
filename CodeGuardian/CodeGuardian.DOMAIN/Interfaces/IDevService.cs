using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Users.Dev;

namespace CodeGuardian.DOMAINE.Interfaces;

public interface IDevService
{
    Dev GetuserByID(int id);

    Dev GetAnUserByName(string username);

    List<Dev> GetAllUsers();

    List<Application> GetUserApplications(int userId);

    List<Application> CheckUserApplicationLicenceKey(int userId, int appid, string licenseKey);
}