using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeGuardian.INFRA.Repos;

public class AdministratorRepo : IAdministratorRepo
{
    private CodeGuardianDbContext _dbCodeGuardian;

    public AdministratorRepo(CodeGuardianDbContext dbCodeGuardian)
    {
        this._dbCodeGuardian = dbCodeGuardian;
    }

    public User AddAnuser(User userToAdd)
    {
        User newuser = _dbCodeGuardian.Users.Add(new User()
        {
            FirstName = userToAdd.FirstName,
            LastName = userToAdd.LastName,
            IsAdmin = userToAdd.IsAdmin
        }).Entity;

        _dbCodeGuardian.SaveChanges();

        return newuser;
    }

    List<Application> IAdministratorRepo.GetAllApplication()
    {
        return _dbCodeGuardian.Applications.ToList();
    }

    List<License> IAdministratorRepo.GetAllLicenses()
    {
        return _dbCodeGuardian.Licenses.ToList();
    }

    List<User> IAdministratorRepo.GetAllUsers()
    {
        return _dbCodeGuardian.Users.Include(u => u.Permissions).ToList();
    }

    List<Permission> IAdministratorRepo.GetAlPermissions()
    {
        return _dbCodeGuardian.Permissions.ToList();
    }

    User IAdministratorRepo.GetAnUserByName(string username)
    {
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
        User user = _dbCodeGuardian.Users.FirstOrDefault(user => user.FirstName == username /*&& user.Active*/);
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.

        if (user == null)
        {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return null;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }

        return user;
    }

    Application IAdministratorRepo.GetApplicationById(int id)
    {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return _dbCodeGuardian.Applications.FirstOrDefault(licence => licence.Id == id);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }

    License IAdministratorRepo.GetLicenseById(int licenceId)
    {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return _dbCodeGuardian.Licenses.FirstOrDefault(licence => licence.Id == licenceId);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }

    Permission IAdministratorRepo.GetPermissionById(int permissionId)
    {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return _dbCodeGuardian.Permissions.FirstOrDefault(licence => licence.Id == permissionId);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }

    User IAdministratorRepo.GetUserByID(int id)
    {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return _dbCodeGuardian.Users.FirstOrDefault(user => user.Id == id);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }
}