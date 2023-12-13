using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.DOMAINE.Services;

public class LicenceService : ILicenceService
{
    private ILicenceRepo _licenceRepo;

    public LicenceService(ILicenceRepo licenceRepo)
    {
        this._licenceRepo = licenceRepo;
    }

    List<License> ILicenceService.GetAllLicenses()
    {
        return _licenceRepo.GetAllLicenses();
    }

    License ILicenceService.GetLicenseById(int licenceId)
    {
        return _licenceRepo.GetLicenseById(licenceId);
    }
}