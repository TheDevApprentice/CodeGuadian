using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeGuardian.INFRA.Repos;

public class DevRepo : IDevRepo
{
    private CodeGuardianDbContext _dbCodeGuardian;

    public DevRepo(CodeGuardianDbContext CodeGuardianDbContext)
    {
        this._dbCodeGuardian = CodeGuardianDbContext;
    }

    public List<Dev> GetAllUsers()
    {
        return _dbCodeGuardian.Users.Include(u => u.Permissions).ToList();
    }

    public Dev GetAnUserByName(string userName)
    {
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
        Dev user = _dbCodeGuardian.Users.FirstOrDefault(user => user.FirstName == userName /*&& user.Active*/);
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.

        if (user == null)
        {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return null;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }

        return user;
    }

    Dev IDevRepo.GetUserByID(int id)
    {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return _dbCodeGuardian.Users.FirstOrDefault(user => user.Id == id);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }

    List<Application> IDevRepo.GetUserApplication(int userId)
    {
        var user = _dbCodeGuardian.Users.FirstOrDefault(user => user.Id == userId);
        var ids = _dbCodeGuardian.PowerUsersApplications.ToList();
        var application = _dbCodeGuardian.Applications.ToList().Where(ua => ids.Any(w => w.ApplicationId == ua.Id)).ToList();
        return application;
    }

    List<Application> IDevRepo.CheckUserApplicationLicenceKey(int userId, int appid, string licenseKey)
    {
        var user = _dbCodeGuardian.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return null;
        }

        var userApplications = _dbCodeGuardian.PowerUsersApplications
            .Where(ua => ua.PowerUserId == userId)
            .ToList();

        var validApplications = _dbCodeGuardian.Applications
            .Where(app => userApplications.Any(ua => ua.ApplicationId == appid && app.ApplicationLicences.Any(k => k.Licence.KeyHash == licenseKey)))
            .ToList();

        return validApplications;
    }
}