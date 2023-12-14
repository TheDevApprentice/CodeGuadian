using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeGuardian.INFRA.Repos;

public class UserRepo : IUserRepo
{
    private CodeGuardianDbContext _dbCodeGuardian;

    public UserRepo(CodeGuardianDbContext CodeGuardianDbContext)
    {
        this._dbCodeGuardian = CodeGuardianDbContext;
    }

    public List<User> GetAllUsers()
    {
        return _dbCodeGuardian.Users.Include(u => u.Permissions).ToList();
    }

    public User GetAnUserByName(string userName)
    {
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
        User user = _dbCodeGuardian.Users.FirstOrDefault(user => user.FirstName == userName /*&& user.Active*/);
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.

        if (user == null)
        {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return null;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }

        return user;
    }

    User IUserRepo.GetUserByID(int id)
    {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return _dbCodeGuardian.Users.FirstOrDefault(user => user.Id == id);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }

    List<Application> IUserRepo.GetUserApplication(int userId)
    {
        var user = _dbCodeGuardian.Users.FirstOrDefault(user => user.Id == userId);
        var ids = _dbCodeGuardian.UserApplications.ToList();
        var application = _dbCodeGuardian.Applications.ToList().Where(ua => ids.Any(w => w.ApplicationId == ua.Id)).ToList();
        return application;
    }

    List<Application> IUserRepo.CheckUserApplicationLicenceKey(int userId, int appid, string licenseKey)
    {
        var user = _dbCodeGuardian.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
        {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return null;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }

        var userApplications = _dbCodeGuardian.UserApplications
            .Where(ua => ua.UserId == userId)
            .ToList();

        var validApplications = _dbCodeGuardian.Applications
            .Where(app => userApplications.Any(ua => ua.ApplicationId == appid && app.Licenses.Any(k => k.Key == licenseKey)))
            .ToList();

        return validApplications;
    }
}