using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IUserRepo
{
    User GetUserByID(int id);

    User GetAnUserByName(string employeeName);

    List<User> GetAllUsers();
}