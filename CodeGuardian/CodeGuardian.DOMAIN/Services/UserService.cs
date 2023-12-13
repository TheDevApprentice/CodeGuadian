using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.DOMAINE.Services;

public class UserService : IUserService
{
    private IUserRepo _repoUser;

    public UserService(IUserRepo userRepo)
    {
        this._repoUser = userRepo;
    }

    public List<User> GetAllUsers()
    {
        return _repoUser.GetAllUsers();
    }

    public User GetAnUserByName(string userName)
    {
        if (userName == "")
        {
            throw new ArgumentException("Please enter a valid name, no user has been found.");
        }

        return _repoUser.GetAnUserByName(userName);
    }

    public User GetuserByID(int id)
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

    List<Application> IUserService.CheckUserApplicationLicenceKey(int userId, int appid, string licenseKey)
    {
        return _repoUser.CheckUserApplicationLicenceKey((int)userId, appid, licenseKey);
    }
}