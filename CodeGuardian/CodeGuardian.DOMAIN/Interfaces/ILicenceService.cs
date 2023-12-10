using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAINE.Interfaces;

public interface ILicenceService
{
    List<License> GetAllLicenses();

    License GetLicenseById(int licenceId);
}