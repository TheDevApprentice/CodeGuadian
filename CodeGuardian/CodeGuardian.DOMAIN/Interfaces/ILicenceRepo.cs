using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface ILicenceRepo
{
    List<License> GetAllLicenses();

    License GetLicenseById(int licenceId);
}