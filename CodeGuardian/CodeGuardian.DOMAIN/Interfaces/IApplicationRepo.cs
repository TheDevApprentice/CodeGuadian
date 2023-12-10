using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IApplicationRepo
{
    List<Application> GetAllApplication();

    Application GetApplicationById(int id);
}