using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAINE.Interfaces;
using License = CodeGuardian.DOMAINE.Entity.License;
namespace CodeGuardian.DOMAINE.Services;

public class ApplicationService : IApplicationService
{
    private IApplicationRepo _applicationRepo;


    public ApplicationService(IApplicationRepo applicationRepo)
    {
        this._applicationRepo = applicationRepo;
    }

    License IApplicationService.CheckApplicationLicenceKey(string licenseKeyHash)
    {
        return _applicationRepo.CheckApplicationLicenceKey(licenseKeyHash);
    }

    List<Application> IApplicationService.GetAllApplication()
    {
        return _applicationRepo.GetAllApplication();
    }

    Application IApplicationService.GetApplicationById(Guid id)
    {
        return _applicationRepo.GetApplicationById(id);
    }


}