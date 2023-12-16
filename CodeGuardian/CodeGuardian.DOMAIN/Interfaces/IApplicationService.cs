using CodeGuardian.DOMAIN.Entity.Application;
using License = CodeGuardian.DOMAINE.Entity.License;

namespace CodeGuardian.DOMAINE.Interfaces;

public interface IApplicationService
{
    List<Application> GetAllApplication();

    Application GetApplicationById(Guid id);

    License CheckApplicationLicenceKey(string licenseKeyHash);
}