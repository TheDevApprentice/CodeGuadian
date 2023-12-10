using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAINE.Interfaces;

public interface IApplicationService
{
    List<Application> GetAllApplication();

    Application GetApplicationById(int id);
}