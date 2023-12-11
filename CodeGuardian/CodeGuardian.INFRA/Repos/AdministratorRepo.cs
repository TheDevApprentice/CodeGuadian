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
        User user = _dbCodeGuardian.Users.FirstOrDefault(user => user.FirstName == username /*&& user.Active*/);

        if (user == null)
        {
            return null;
        }

        return user;
    }

    Application IAdministratorRepo.GetApplicationById(int id)
    {
        return _dbCodeGuardian.Applications.FirstOrDefault(licence => licence.Id == id);
    }

    License IAdministratorRepo.GetLicenseById(int licenceId)
    {
        return _dbCodeGuardian.Licenses.FirstOrDefault(licence => licence.Id == licenceId);
    }

    Permission IAdministratorRepo.GetPermissionById(int permissionId)
    {
        return _dbCodeGuardian.Permissions.FirstOrDefault(licence => licence.Id == permissionId);
    }

    User IAdministratorRepo.GetUserByID(int id)
    {
        return _dbCodeGuardian.Users.FirstOrDefault(user => user.Id == id);
    }
}