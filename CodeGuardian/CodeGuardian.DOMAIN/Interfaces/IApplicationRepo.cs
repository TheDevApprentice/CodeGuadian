using CodeGuardian.DOMAIN.Entity.Application;
namespace CodeGuardian.DOMAINE.Interfaces;
using License = CodeGuardian.DOMAINE.Entity.License;

public interface IApplicationRepo
{
    List<Application> GetAllApplication();

    Application GetApplicationById(Guid id);

    License CheckApplicationLicenceKey(string licenseKeyHash);
}