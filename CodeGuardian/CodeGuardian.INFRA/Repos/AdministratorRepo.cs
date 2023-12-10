using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

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
}