using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAINE.Interfaces;

public interface IUserService
{
    User GetuserByID(int id);

    User GetAnUserByName(string username);

    List<User> GetAllUsers();
}