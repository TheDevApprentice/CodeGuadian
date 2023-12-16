using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.DOMAINE.Services;

public class DevService : IDevService
{
    private IDevRepo _repoUser;

    public DevService(IDevRepo userRepo)
    {
        this._repoUser = userRepo;
    }

    public List<Dev> GetAllUsers()
    {
        return _repoUser.GetAllUsers();
    }

    public Dev GetAnUserByName(string userName)
    {
        if (userName == "")
        {
            throw new ArgumentException("Please enter a valid name, no user has been found.");
        }

        return _repoUser.GetAnUserByName(userName);
    }

    public Dev GetuserByID(int id)
    {
        if (_repoUser.GetUserByID((int)id) == null)
        {
            throw new ArgumentException("Please enter a valid id for the user");
        }

        return _repoUser.GetUserByID((int)id);
    }
    public List<Application> GetUserApplications(int userId)
    {
        if (_repoUser.GetUserApplication((int)userId) == null)
        {
            throw new ArgumentException("Please enter a valid id for the user");
        }

        return _repoUser.GetUserApplication((int)userId);
    }

    List<Application> IDevService.CheckUserApplicationLicenceKey(int userId, int appid, string licenseKey)
    {
        return _repoUser.CheckUserApplicationLicenceKey((int)userId, appid, licenseKey);
    }
}