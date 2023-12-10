using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IAdministratorRepo
{
    User AddAnuser(User userToAdd);
}