using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAIN.Entity.Users.Dev;
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

    public Dev AddADevelopper(Dev userToAdd)
    {
        Dev newuser = _dbCodeGuardian.Users.Add(new Dev()
        {
            FirstName = userToAdd.FirstName,
            LastName = userToAdd.LastName
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

    List<Dev> IAdministratorRepo.GetAllUsers()
    {
        return _dbCodeGuardian.Users.Include(u => u.Permissions).ToList();
    }

    List<Permission> IAdministratorRepo.GetAlPermissions()
    {
        return _dbCodeGuardian.Permissions.ToList();
    }

    Dev IAdministratorRepo.GetAnUserByName(string username)
    {
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
        Dev user = _dbCodeGuardian.Users.FirstOrDefault(user => user.FirstName == username /*&& user.Active*/);
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

    Dev IAdministratorRepo.GetUserByID(int id)
    {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return _dbCodeGuardian.Users.FirstOrDefault(user => user.Id == id);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }
}