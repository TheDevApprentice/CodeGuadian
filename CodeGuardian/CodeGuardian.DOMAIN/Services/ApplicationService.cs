using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.DOMAINE.Services;

public class ApplicationService : IApplicationService
{
    private IApplicationRepo _applicationRepo;

    // Initialize the user repository to access the methods
    public ApplicationService(IApplicationRepo applicationRepo)
    {
        this._applicationRepo = applicationRepo;
    }

    List<Application> IApplicationService.GetAllApplication()
    {
        return _applicationRepo.GetAllApplication();
    }

    Application IApplicationService.GetApplicationById(int id)
    {
        return _applicationRepo.GetApplicationById(id); 
    }
}