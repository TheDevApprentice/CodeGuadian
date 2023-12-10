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
        User user = _dbCodeGuardian.Users.FirstOrDefault(user => user.FirstName == userName /*&& user.Active*/);

        if (user == null)
        {
            return null;
        }

        return user;
    }

    User IUserRepo.GetUserByID(int id)
    {
        return _dbCodeGuardian.Users.FirstOrDefault(user => user.Id == id);
    }
}